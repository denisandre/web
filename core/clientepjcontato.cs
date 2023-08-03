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
   public class clientepjcontato : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_41") == 0 )
         {
            A158CliID = StringUtil.StrToGuid( GetPar( "CliID"));
            AssignAttri("", false, "A158CliID", A158CliID.ToString());
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_41( A158CliID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_42") == 0 )
         {
            A158CliID = StringUtil.StrToGuid( GetPar( "CliID"));
            AssignAttri("", false, "A158CliID", A158CliID.ToString());
            A166CpjID = StringUtil.StrToGuid( GetPar( "CpjID"));
            AssignAttri("", false, "A166CpjID", A166CpjID.ToString());
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_42( A158CliID, A166CpjID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_45") == 0 )
         {
            A365CpjTipoId = (int)(Math.Round(NumberUtil.Val( GetPar( "CpjTipoId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A365CpjTipoId", StringUtil.LTrimStr( (decimal)(A365CpjTipoId), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_45( A365CpjTipoId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_43") == 0 )
         {
            A270CpjConTipoID = (int)(Math.Round(NumberUtil.Val( GetPar( "CpjConTipoID"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A270CpjConTipoID", StringUtil.LTrimStr( (decimal)(A270CpjConTipoID), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_43( A270CpjConTipoID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_44") == 0 )
         {
            A279CpjConGenID = (int)(Math.Round(NumberUtil.Val( GetPar( "CpjConGenID"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A279CpjConGenID", StringUtil.LTrimStr( (decimal)(A279CpjConGenID), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_44( A279CpjConGenID) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "core.clientepjcontato.aspx")), "core.clientepjcontato.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "core.clientepjcontato.aspx")))) ;
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
                  AV7CliID = StringUtil.StrToGuid( GetPar( "CliID"));
                  AssignAttri("", false, "AV7CliID", AV7CliID.ToString());
                  GxWebStd.gx_hidden_field( context, "gxhash_vCLIID", GetSecureSignedToken( "", AV7CliID, context));
                  AV8CpjID = StringUtil.StrToGuid( GetPar( "CpjID"));
                  AssignAttri("", false, "AV8CpjID", AV8CpjID.ToString());
                  GxWebStd.gx_hidden_field( context, "gxhash_vCPJID", GetSecureSignedToken( "", AV8CpjID, context));
                  AV37CpjConSeq = (short)(Math.Round(NumberUtil.Val( GetPar( "CpjConSeq"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV37CpjConSeq", StringUtil.LTrimStr( (decimal)(AV37CpjConSeq), 4, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vCPJCONSEQ", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV37CpjConSeq), "ZZZ9"), context));
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
            Form.Meta.addItem("description", "Contato", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtCpjConTipoID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public clientepjcontato( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public clientepjcontato( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           Guid aP1_CliID ,
                           Guid aP2_CpjID ,
                           short aP3_CpjConSeq )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7CliID = aP1_CliID;
         this.AV8CpjID = aP2_CpjID;
         this.AV37CpjConSeq = aP3_CpjConSeq;
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
            return "clientepjcontato_Execute" ;
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 CellMarginBottom20", "start", "top", "", "", "div");
         /* User Defined Control */
         ucDvpanel_tablecliente.SetProperty("Width", Dvpanel_tablecliente_Width);
         ucDvpanel_tablecliente.SetProperty("AutoWidth", Dvpanel_tablecliente_Autowidth);
         ucDvpanel_tablecliente.SetProperty("AutoHeight", Dvpanel_tablecliente_Autoheight);
         ucDvpanel_tablecliente.SetProperty("Cls", Dvpanel_tablecliente_Cls);
         ucDvpanel_tablecliente.SetProperty("Title", Dvpanel_tablecliente_Title);
         ucDvpanel_tablecliente.SetProperty("Collapsible", Dvpanel_tablecliente_Collapsible);
         ucDvpanel_tablecliente.SetProperty("Collapsed", Dvpanel_tablecliente_Collapsed);
         ucDvpanel_tablecliente.SetProperty("ShowCollapseIcon", Dvpanel_tablecliente_Showcollapseicon);
         ucDvpanel_tablecliente.SetProperty("IconPosition", Dvpanel_tablecliente_Iconposition);
         ucDvpanel_tablecliente.SetProperty("AutoScroll", Dvpanel_tablecliente_Autoscroll);
         ucDvpanel_tablecliente.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tablecliente_Internalname, "DVPANEL_TABLECLIENTEContainer");
         context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLECLIENTEContainer"+"TableCliente"+"\" style=\"display:none;\">") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablecliente_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedcliid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockcliid_Internalname, "Cliente", "", "", lblTextblockcliid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_core\\ClientePJContato.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_cliid.SetProperty("Caption", Combo_cliid_Caption);
         ucCombo_cliid.SetProperty("Cls", Combo_cliid_Cls);
         ucCombo_cliid.SetProperty("EmptyItem", Combo_cliid_Emptyitem);
         ucCombo_cliid.SetProperty("DropDownOptionsTitleSettingsIcons", AV17DDO_TitleSettingsIcons);
         ucCombo_cliid.SetProperty("DropDownOptionsData", AV16CliID_Data);
         ucCombo_cliid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_cliid_Internalname, "COMBO_CLIIDContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCliID_Internalname, "ID", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCliID_Internalname, A158CliID.ToString(), A158CliID.ToString(), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliID_Jsonclick, 0, "Attribute", "", "", "", "", edtCliID_Visible, edtCliID_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_core\\ClientePJContato.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-xs", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTxtesp01_Internalname, "&nbsp;", "", "", lblTxtesp01_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_core\\ClientePJContato.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedcpjid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockcpjid_Internalname, "Unidade", "", "", lblTextblockcpjid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_core\\ClientePJContato.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_cpjid.SetProperty("Caption", Combo_cpjid_Caption);
         ucCombo_cpjid.SetProperty("Cls", Combo_cpjid_Cls);
         ucCombo_cpjid.SetProperty("DataListProc", Combo_cpjid_Datalistproc);
         ucCombo_cpjid.SetProperty("EmptyItem", Combo_cpjid_Emptyitem);
         ucCombo_cpjid.SetProperty("DropDownOptionsTitleSettingsIcons", AV17DDO_TitleSettingsIcons);
         ucCombo_cpjid.SetProperty("DropDownOptionsData", AV44CpjID_Data);
         ucCombo_cpjid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_cpjid_Internalname, "COMBO_CPJIDContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCpjID_Internalname, "ID", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCpjID_Internalname, A166CpjID.ToString(), A166CpjID.ToString(), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCpjID_Jsonclick, 0, "Attribute", "", "", "", "", edtCpjID_Visible, edtCpjID_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_core\\ClientePJContato.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCpjTipoId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCpjTipoId_Internalname, "Tipo", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCpjTipoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A365CpjTipoId), 11, 0, ",", "")), StringUtil.LTrim( ((edtCpjTipoId_Enabled!=0) ? context.localUtil.Format( (decimal)(A365CpjTipoId), "ZZZ,ZZZ,ZZ9") : context.localUtil.Format( (decimal)(A365CpjTipoId), "ZZZ,ZZZ,ZZ9"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCpjTipoId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCpjTipoId_Enabled, 0, "text", "", 11, "chr", 1, "row", 11, 0, 0, 0, 0, -1, 0, true, "core\\ID", "end", false, "", "HLP_core\\ClientePJContato.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCpjMatricula_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCpjMatricula_Internalname, "Matrícula", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCpjMatricula_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A176CpjMatricula), 15, 0, ",", "")), StringUtil.LTrim( ((edtCpjMatricula_Enabled!=0) ? context.localUtil.Format( (decimal)(A176CpjMatricula), "ZZZ,ZZZ,ZZZ,ZZ9") : context.localUtil.Format( (decimal)(A176CpjMatricula), "ZZZ,ZZZ,ZZZ,ZZ9"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCpjMatricula_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCpjMatricula_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 0, -1, 0, true, "core\\Matricula", "end", false, "", "HLP_core\\ClientePJContato.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCpjTelNum_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCpjTelNum_Internalname, "Telefone", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         if ( context.isSmartDevice( ) )
         {
            gxphoneLink = "tel:" + StringUtil.RTrim( A261CpjTelNum);
         }
         GxWebStd.gx_single_line_edit( context, edtCpjTelNum_Internalname, StringUtil.RTrim( A261CpjTelNum), StringUtil.RTrim( context.localUtil.Format( A261CpjTelNum, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtCpjTelNum_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCpjTelNum_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Phone", "start", true, "", "HLP_core\\ClientePJContato.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCpjTelRam_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCpjTelRam_Internalname, "Ramal do Telefone", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCpjTelRam_Internalname, A262CpjTelRam, StringUtil.RTrim( context.localUtil.Format( A262CpjTelRam, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCpjTelRam_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCpjTelRam_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\ClientePJContato.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCpjCelNum_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCpjCelNum_Internalname, "Celular", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         if ( context.isSmartDevice( ) )
         {
            gxphoneLink = "tel:" + StringUtil.RTrim( A263CpjCelNum);
         }
         GxWebStd.gx_single_line_edit( context, edtCpjCelNum_Internalname, StringUtil.RTrim( A263CpjCelNum), StringUtil.RTrim( context.localUtil.Format( A263CpjCelNum, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtCpjCelNum_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCpjCelNum_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Phone", "start", true, "", "HLP_core\\ClientePJContato.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCpjWppNum_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCpjWppNum_Internalname, "WhatsApp", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         if ( context.isSmartDevice( ) )
         {
            gxphoneLink = "tel:" + StringUtil.RTrim( A264CpjWppNum);
         }
         GxWebStd.gx_single_line_edit( context, edtCpjWppNum_Internalname, StringUtil.RTrim( A264CpjWppNum), StringUtil.RTrim( context.localUtil.Format( A264CpjWppNum, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtCpjWppNum_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCpjWppNum_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Phone", "start", true, "", "HLP_core\\ClientePJContato.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCpjWebsite_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCpjWebsite_Internalname, "Website", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCpjWebsite_Internalname, A265CpjWebsite, StringUtil.RTrim( context.localUtil.Format( A265CpjWebsite, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", A265CpjWebsite, "_blank", "", "", edtCpjWebsite_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCpjWebsite_Enabled, 0, "url", "", 80, "chr", 1, "row", 1000, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Url", "start", true, "", "HLP_core\\ClientePJContato.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCpjEmail_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCpjEmail_Internalname, "E-mail", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCpjEmail_Internalname, A266CpjEmail, StringUtil.RTrim( context.localUtil.Format( A266CpjEmail, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "mailto:"+A266CpjEmail, "", "", "", edtCpjEmail_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCpjEmail_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "start", true, "", "HLP_core\\ClientePJContato.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedcpjcontipoid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockcpjcontipoid_Internalname, "Tipo de Contato", "", "", lblTextblockcpjcontipoid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_core\\ClientePJContato.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_cpjcontipoid.SetProperty("Caption", Combo_cpjcontipoid_Caption);
         ucCombo_cpjcontipoid.SetProperty("Cls", Combo_cpjcontipoid_Cls);
         ucCombo_cpjcontipoid.SetProperty("EmptyItem", Combo_cpjcontipoid_Emptyitem);
         ucCombo_cpjcontipoid.SetProperty("IncludeAddNewOption", Combo_cpjcontipoid_Includeaddnewoption);
         ucCombo_cpjcontipoid.SetProperty("DropDownOptionsTitleSettingsIcons", AV17DDO_TitleSettingsIcons);
         ucCombo_cpjcontipoid.SetProperty("DropDownOptionsData", AV32CpjConTipoID_Data);
         ucCombo_cpjcontipoid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_cpjcontipoid_Internalname, "COMBO_CPJCONTIPOIDContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCpjConTipoID_Internalname, "Tipo", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 92,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCpjConTipoID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A270CpjConTipoID), 11, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A270CpjConTipoID), "ZZZ,ZZZ,ZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,92);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCpjConTipoID_Jsonclick, 0, "Attribute", "", "", "", "", edtCpjConTipoID_Visible, edtCpjConTipoID_Enabled, 1, "text", "", 11, "chr", 1, "row", 11, 0, 0, 0, 0, -1, 0, true, "core\\ID", "end", false, "", "HLP_core\\ClientePJContato.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCpjConNome_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCpjConNome_Internalname, "Nome do Contato", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 97,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCpjConNome_Internalname, A275CpjConNome, StringUtil.RTrim( context.localUtil.Format( A275CpjConNome, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,97);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCpjConNome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCpjConNome_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "core\\Nome", "start", true, "", "HLP_core\\ClientePJContato.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCpjConCPFFormat_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCpjConCPFFormat_Internalname, "CPF", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 101,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCpjConCPFFormat_Internalname, A274CpjConCPFFormat, StringUtil.RTrim( context.localUtil.Format( A274CpjConCPFFormat, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,101);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCpjConCPFFormat_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCpjConCPFFormat_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, -1, true, "core\\CPFFormat", "start", true, "", "HLP_core\\ClientePJContato.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCpjConNascimento_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCpjConNascimento_Internalname, "Data de Nascimento", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 105,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtCpjConNascimento_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtCpjConNascimento_Internalname, context.localUtil.Format(A282CpjConNascimento, "99/99/99"), context.localUtil.Format( A282CpjConNascimento, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onblur(this,105);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCpjConNascimento_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCpjConNascimento_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "core\\Data", "end", false, "", "HLP_core\\ClientePJContato.htm");
         GxWebStd.gx_bitmap( context, edtCpjConNascimento_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtCpjConNascimento_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_core\\ClientePJContato.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCpjNomeSocial_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCpjNomeSocial_Internalname, "Como deseja ser chamado", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 110,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCpjNomeSocial_Internalname, A278CpjNomeSocial, StringUtil.RTrim( context.localUtil.Format( A278CpjNomeSocial, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,110);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCpjNomeSocial_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCpjNomeSocial_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "core\\Nome", "start", true, "", "HLP_core\\ClientePJContato.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedcpjcongenid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockcpjcongenid_Internalname, "Gênero", "", "", lblTextblockcpjcongenid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_core\\ClientePJContato.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_cpjcongenid.SetProperty("Caption", Combo_cpjcongenid_Caption);
         ucCombo_cpjcongenid.SetProperty("Cls", Combo_cpjcongenid_Cls);
         ucCombo_cpjcongenid.SetProperty("IncludeAddNewOption", Combo_cpjcongenid_Includeaddnewoption);
         ucCombo_cpjcongenid.SetProperty("EmptyItemText", Combo_cpjcongenid_Emptyitemtext);
         ucCombo_cpjcongenid.SetProperty("DropDownOptionsTitleSettingsIcons", AV17DDO_TitleSettingsIcons);
         ucCombo_cpjcongenid.SetProperty("DropDownOptionsData", AV33CpjConGenID_Data);
         ucCombo_cpjcongenid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_cpjcongenid_Internalname, "COMBO_CPJCONGENIDContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCpjConGenID_Internalname, "Gênero", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 120,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCpjConGenID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A279CpjConGenID), 11, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A279CpjConGenID), "ZZZ,ZZZ,ZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,120);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCpjConGenID_Jsonclick, 0, "Attribute", "", "", "", "", edtCpjConGenID_Visible, edtCpjConGenID_Enabled, 1, "text", "", 11, "chr", 1, "row", 11, 0, 0, 0, 0, -1, 0, true, "core\\ID_Autonum", "end", false, "", "HLP_core\\ClientePJContato.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCpjConCelNum_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCpjConCelNum_Internalname, "Celular", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         if ( context.isSmartDevice( ) )
         {
            gxphoneLink = "tel:" + StringUtil.RTrim( A285CpjConCelNum);
         }
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 125,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCpjConCelNum_Internalname, StringUtil.RTrim( A285CpjConCelNum), StringUtil.RTrim( context.localUtil.Format( A285CpjConCelNum, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,125);\"", "'"+""+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtCpjConCelNum_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCpjConCelNum_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Phone", "start", true, "", "HLP_core\\ClientePJContato.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCpjConWppNum_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCpjConWppNum_Internalname, "WhatsApp", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         if ( context.isSmartDevice( ) )
         {
            gxphoneLink = "tel:" + StringUtil.RTrim( A286CpjConWppNum);
         }
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 129,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCpjConWppNum_Internalname, StringUtil.RTrim( A286CpjConWppNum), StringUtil.RTrim( context.localUtil.Format( A286CpjConWppNum, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,129);\"", "'"+""+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtCpjConWppNum_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCpjConWppNum_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Phone", "start", true, "", "HLP_core\\ClientePJContato.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCpjConTelNum_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCpjConTelNum_Internalname, "Telefone", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         if ( context.isSmartDevice( ) )
         {
            gxphoneLink = "tel:" + StringUtil.RTrim( A283CpjConTelNum);
         }
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 133,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCpjConTelNum_Internalname, StringUtil.RTrim( A283CpjConTelNum), StringUtil.RTrim( context.localUtil.Format( A283CpjConTelNum, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,133);\"", "'"+""+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtCpjConTelNum_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCpjConTelNum_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Phone", "start", true, "", "HLP_core\\ClientePJContato.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCpjConTelRam_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCpjConTelRam_Internalname, "Ramal", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 137,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCpjConTelRam_Internalname, A284CpjConTelRam, StringUtil.RTrim( context.localUtil.Format( A284CpjConTelRam, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,137);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCpjConTelRam_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCpjConTelRam_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\ClientePJContato.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCpjConEmail_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCpjConEmail_Internalname, "E-mail", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 142,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCpjConEmail_Internalname, A287CpjConEmail, StringUtil.RTrim( context.localUtil.Format( A287CpjConEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,142);\"", "'"+""+"'"+",false,"+"'"+""+"'", "mailto:"+A287CpjConEmail, "", "", "", edtCpjConEmail_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCpjConEmail_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "start", true, "", "HLP_core\\ClientePJContato.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCpjConLIn_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCpjConLIn_Internalname, "LinkedIn", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 146,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCpjConLIn_Internalname, A288CpjConLIn, StringUtil.RTrim( context.localUtil.Format( A288CpjConLIn, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,146);\"", "'"+""+"'"+",false,"+"'"+""+"'", A288CpjConLIn, "_blank", "", "", edtCpjConLIn_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCpjConLIn_Enabled, 0, "url", "", 80, "chr", 1, "row", 1000, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Url", "start", true, "", "HLP_core\\ClientePJContato.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 151,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\ClientePJContato.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 153,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\ClientePJContato.htm");
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
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_cliid_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtavCombocliid_Internalname, AV21ComboCliID.ToString(), AV21ComboCliID.ToString(), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombocliid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombocliid_Visible, edtavCombocliid_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_core\\ClientePJContato.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_cpjid_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtavCombocpjid_Internalname, AV45ComboCpjID.ToString(), AV45ComboCpjID.ToString(), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombocpjid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombocpjid_Visible, edtavCombocpjid_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_core\\ClientePJContato.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_cpjcontipoid_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtavCombocpjcontipoid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV40ComboCpjConTipoID), 11, 0, ",", "")), StringUtil.LTrim( ((edtavCombocpjcontipoid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV40ComboCpjConTipoID), "ZZZ,ZZZ,ZZ9") : context.localUtil.Format( (decimal)(AV40ComboCpjConTipoID), "ZZZ,ZZZ,ZZ9"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombocpjcontipoid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombocpjcontipoid_Visible, edtavCombocpjcontipoid_Enabled, 0, "text", "", 11, "chr", 1, "row", 11, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_core\\ClientePJContato.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_cpjcongenid_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtavCombocpjcongenid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV42ComboCpjConGenID), 11, 0, ",", "")), StringUtil.LTrim( ((edtavCombocpjcongenid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV42ComboCpjConGenID), "ZZZ,ZZZ,ZZ9") : context.localUtil.Format( (decimal)(AV42ComboCpjConGenID), "ZZZ,ZZZ,ZZ9"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombocpjcongenid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombocpjcongenid_Visible, edtavCombocpjcongenid_Enabled, 0, "text", "", 11, "chr", 1, "row", 11, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_core\\ClientePJContato.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 165,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCpjConSeq_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A269CpjConSeq), 4, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A269CpjConSeq), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,165);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCpjConSeq_Jsonclick, 0, "Attribute", "", "", "", "", edtCpjConSeq_Visible, edtCpjConSeq_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_core\\ClientePJContato.htm");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCpjConTipoSigla_Internalname, A271CpjConTipoSigla, StringUtil.RTrim( context.localUtil.Format( A271CpjConTipoSigla, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCpjConTipoSigla_Jsonclick, 0, "Attribute", "", "", "", "", edtCpjConTipoSigla_Visible, edtCpjConTipoSigla_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "core\\Sigla", "start", true, "", "HLP_core\\ClientePJContato.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 167,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCpjConCPF_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A273CpjConCPF), 11, 0, ",", "")), StringUtil.LTrim( ((edtCpjConCPF_Enabled!=0) ? context.localUtil.Format( (decimal)(A273CpjConCPF), "ZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A273CpjConCPF), "ZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,167);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCpjConCPF_Jsonclick, 0, "Attribute", "", "", "", "", edtCpjConCPF_Visible, edtCpjConCPF_Enabled, 0, "text", "1", 11, "chr", 1, "row", 11, 0, 0, 0, 0, -1, 0, true, "core\\CPF", "end", false, "", "HLP_core\\ClientePJContato.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 168,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCpjConNomePrim_Internalname, A276CpjConNomePrim, StringUtil.RTrim( context.localUtil.Format( A276CpjConNomePrim, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,168);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCpjConNomePrim_Jsonclick, 0, "Attribute", "", "", "", "", edtCpjConNomePrim_Visible, edtCpjConNomePrim_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "core\\Nome", "start", true, "", "HLP_core\\ClientePJContato.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 169,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCpjConSobrenome_Internalname, A277CpjConSobrenome, StringUtil.RTrim( context.localUtil.Format( A277CpjConSobrenome, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,169);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCpjConSobrenome_Jsonclick, 0, "Attribute", "", "", "", "", edtCpjConSobrenome_Visible, edtCpjConSobrenome_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "core\\Nome", "start", true, "", "HLP_core\\ClientePJContato.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 170,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCpjConUltEnd_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A328CpjConUltEnd), 4, 0, ",", "")), StringUtil.LTrim( ((edtCpjConUltEnd_Enabled!=0) ? context.localUtil.Format( (decimal)(A328CpjConUltEnd), "ZZZ9") : context.localUtil.Format( (decimal)(A328CpjConUltEnd), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,170);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCpjConUltEnd_Jsonclick, 0, "Attribute", "", "", "", "", edtCpjConUltEnd_Visible, edtCpjConUltEnd_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_core\\ClientePJContato.htm");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCpjCNPJ_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A187CpjCNPJ), 14, 0, ",", "")), StringUtil.LTrim( ((edtCpjCNPJ_Enabled!=0) ? context.localUtil.Format( (decimal)(A187CpjCNPJ), "ZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A187CpjCNPJ), "ZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCpjCNPJ_Jsonclick, 0, "Attribute", "", "", "", "", edtCpjCNPJ_Visible, edtCpjCNPJ_Enabled, 0, "text", "1", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "core\\CNPJ", "end", false, "", "HLP_core\\ClientePJContato.htm");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCpjAtivo_Internalname, StringUtil.BoolToStr( A207CpjAtivo), StringUtil.BoolToStr( A207CpjAtivo), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCpjAtivo_Jsonclick, 0, "Attribute", "", "", "", "", edtCpjAtivo_Visible, edtCpjAtivo_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 0, 0, 0, true, "core\\Ativo", "end", false, "", "HLP_core\\ClientePJContato.htm");
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
         E11102 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV17DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( "vCLIID_DATA"), AV16CliID_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vCPJID_DATA"), AV44CpjID_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vCPJCONTIPOID_DATA"), AV32CpjConTipoID_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vCPJCONGENID_DATA"), AV33CpjConGenID_Data);
               /* Read saved values. */
               Z158CliID = StringUtil.StrToGuid( cgiGet( "Z158CliID"));
               Z166CpjID = StringUtil.StrToGuid( cgiGet( "Z166CpjID"));
               Z269CpjConSeq = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z269CpjConSeq"), ",", "."), 18, MidpointRounding.ToEven));
               Z549CpjConDelDataHora = context.localUtil.CToT( cgiGet( "Z549CpjConDelDataHora"), 0);
               n549CpjConDelDataHora = ((DateTime.MinValue==A549CpjConDelDataHora) ? true : false);
               Z550CpjConDelData = context.localUtil.CToT( cgiGet( "Z550CpjConDelData"), 0);
               n550CpjConDelData = ((DateTime.MinValue==A550CpjConDelData) ? true : false);
               Z551CpjConDelHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z551CpjConDelHora"), 0));
               n551CpjConDelHora = ((DateTime.MinValue==A551CpjConDelHora) ? true : false);
               Z552CpjConDelUsuId = cgiGet( "Z552CpjConDelUsuId");
               n552CpjConDelUsuId = (String.IsNullOrEmpty(StringUtil.RTrim( A552CpjConDelUsuId)) ? true : false);
               Z553CpjConDelUsuNome = cgiGet( "Z553CpjConDelUsuNome");
               n553CpjConDelUsuNome = (String.IsNullOrEmpty(StringUtil.RTrim( A553CpjConDelUsuNome)) ? true : false);
               Z273CpjConCPF = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z273CpjConCPF"), ",", "."), 18, MidpointRounding.ToEven));
               Z274CpjConCPFFormat = cgiGet( "Z274CpjConCPFFormat");
               Z275CpjConNome = cgiGet( "Z275CpjConNome");
               Z276CpjConNomePrim = cgiGet( "Z276CpjConNomePrim");
               Z277CpjConSobrenome = cgiGet( "Z277CpjConSobrenome");
               Z278CpjNomeSocial = cgiGet( "Z278CpjNomeSocial");
               Z282CpjConNascimento = context.localUtil.CToD( cgiGet( "Z282CpjConNascimento"), 0);
               Z283CpjConTelNum = cgiGet( "Z283CpjConTelNum");
               n283CpjConTelNum = (String.IsNullOrEmpty(StringUtil.RTrim( A283CpjConTelNum)) ? true : false);
               Z284CpjConTelRam = cgiGet( "Z284CpjConTelRam");
               n284CpjConTelRam = (String.IsNullOrEmpty(StringUtil.RTrim( A284CpjConTelRam)) ? true : false);
               Z285CpjConCelNum = cgiGet( "Z285CpjConCelNum");
               n285CpjConCelNum = (String.IsNullOrEmpty(StringUtil.RTrim( A285CpjConCelNum)) ? true : false);
               Z286CpjConWppNum = cgiGet( "Z286CpjConWppNum");
               n286CpjConWppNum = (String.IsNullOrEmpty(StringUtil.RTrim( A286CpjConWppNum)) ? true : false);
               Z287CpjConEmail = cgiGet( "Z287CpjConEmail");
               n287CpjConEmail = (String.IsNullOrEmpty(StringUtil.RTrim( A287CpjConEmail)) ? true : false);
               Z288CpjConLIn = cgiGet( "Z288CpjConLIn");
               n288CpjConLIn = (String.IsNullOrEmpty(StringUtil.RTrim( A288CpjConLIn)) ? true : false);
               Z328CpjConUltEnd = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z328CpjConUltEnd"), ",", "."), 18, MidpointRounding.ToEven));
               n328CpjConUltEnd = ((0==A328CpjConUltEnd) ? true : false);
               Z548CpjConDel = StringUtil.StrToBool( cgiGet( "Z548CpjConDel"));
               Z270CpjConTipoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z270CpjConTipoID"), ",", "."), 18, MidpointRounding.ToEven));
               Z279CpjConGenID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z279CpjConGenID"), ",", "."), 18, MidpointRounding.ToEven));
               Z170CpjNomeFan = cgiGet( "Z170CpjNomeFan");
               Z171CpjRazaoSoc = cgiGet( "Z171CpjRazaoSoc");
               Z176CpjMatricula = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z176CpjMatricula"), ",", "."), 18, MidpointRounding.ToEven));
               Z187CpjCNPJ = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z187CpjCNPJ"), ",", "."), 18, MidpointRounding.ToEven));
               Z188CpjCNPJFormat = cgiGet( "Z188CpjCNPJFormat");
               Z189CpjIE = cgiGet( "Z189CpjIE");
               Z207CpjAtivo = StringUtil.StrToBool( cgiGet( "Z207CpjAtivo"));
               Z261CpjTelNum = cgiGet( "Z261CpjTelNum");
               Z262CpjTelRam = cgiGet( "Z262CpjTelRam");
               Z263CpjCelNum = cgiGet( "Z263CpjCelNum");
               Z264CpjWppNum = cgiGet( "Z264CpjWppNum");
               Z265CpjWebsite = cgiGet( "Z265CpjWebsite");
               Z266CpjEmail = cgiGet( "Z266CpjEmail");
               Z365CpjTipoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z365CpjTipoId"), ",", "."), 18, MidpointRounding.ToEven));
               A549CpjConDelDataHora = context.localUtil.CToT( cgiGet( "Z549CpjConDelDataHora"), 0);
               n549CpjConDelDataHora = false;
               n549CpjConDelDataHora = ((DateTime.MinValue==A549CpjConDelDataHora) ? true : false);
               A550CpjConDelData = context.localUtil.CToT( cgiGet( "Z550CpjConDelData"), 0);
               n550CpjConDelData = false;
               n550CpjConDelData = ((DateTime.MinValue==A550CpjConDelData) ? true : false);
               A551CpjConDelHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z551CpjConDelHora"), 0));
               n551CpjConDelHora = false;
               n551CpjConDelHora = ((DateTime.MinValue==A551CpjConDelHora) ? true : false);
               A552CpjConDelUsuId = cgiGet( "Z552CpjConDelUsuId");
               n552CpjConDelUsuId = false;
               n552CpjConDelUsuId = (String.IsNullOrEmpty(StringUtil.RTrim( A552CpjConDelUsuId)) ? true : false);
               A553CpjConDelUsuNome = cgiGet( "Z553CpjConDelUsuNome");
               n553CpjConDelUsuNome = false;
               n553CpjConDelUsuNome = (String.IsNullOrEmpty(StringUtil.RTrim( A553CpjConDelUsuNome)) ? true : false);
               A548CpjConDel = StringUtil.StrToBool( cgiGet( "Z548CpjConDel"));
               A170CpjNomeFan = cgiGet( "Z170CpjNomeFan");
               A171CpjRazaoSoc = cgiGet( "Z171CpjRazaoSoc");
               A188CpjCNPJFormat = cgiGet( "Z188CpjCNPJFormat");
               A189CpjIE = cgiGet( "Z189CpjIE");
               O548CpjConDel = StringUtil.StrToBool( cgiGet( "O548CpjConDel"));
               O268CpjUltConSeq = (short)(Math.Round(context.localUtil.CToN( cgiGet( "O268CpjUltConSeq"), ",", "."), 18, MidpointRounding.ToEven));
               n268CpjUltConSeq = ((0==A268CpjUltConSeq) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N270CpjConTipoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N270CpjConTipoID"), ",", "."), 18, MidpointRounding.ToEven));
               N279CpjConGenID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N279CpjConGenID"), ",", "."), 18, MidpointRounding.ToEven));
               AV7CliID = StringUtil.StrToGuid( cgiGet( "vCLIID"));
               AV8CpjID = StringUtil.StrToGuid( cgiGet( "vCPJID"));
               AV37CpjConSeq = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vCPJCONSEQ"), ",", "."), 18, MidpointRounding.ToEven));
               A268CpjUltConSeq = (short)(Math.Round(context.localUtil.CToN( cgiGet( "CPJULTCONSEQ"), ",", "."), 18, MidpointRounding.ToEven));
               n268CpjUltConSeq = ((0==A268CpjUltConSeq) ? true : false);
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ",", "."), 18, MidpointRounding.ToEven));
               AV38Insert_CpjConTipoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_CPJCONTIPOID"), ",", "."), 18, MidpointRounding.ToEven));
               AV39Insert_CpjConGenID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_CPJCONGENID"), ",", "."), 18, MidpointRounding.ToEven));
               A160CliNomeFamiliar = cgiGet( "CLINOMEFAMILIAR");
               A170CpjNomeFan = cgiGet( "CPJNOMEFAN");
               A367CpjTipoNome = cgiGet( "CPJTIPONOME");
               A548CpjConDel = StringUtil.StrToBool( cgiGet( "CPJCONDEL"));
               A549CpjConDelDataHora = context.localUtil.CToT( cgiGet( "CPJCONDELDATAHORA"), 0);
               n549CpjConDelDataHora = ((DateTime.MinValue==A549CpjConDelDataHora) ? true : false);
               A550CpjConDelData = context.localUtil.CToT( cgiGet( "CPJCONDELDATA"), 0);
               n550CpjConDelData = ((DateTime.MinValue==A550CpjConDelData) ? true : false);
               A551CpjConDelHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "CPJCONDELHORA"), 0));
               n551CpjConDelHora = ((DateTime.MinValue==A551CpjConDelHora) ? true : false);
               A552CpjConDelUsuId = cgiGet( "CPJCONDELUSUID");
               n552CpjConDelUsuId = (String.IsNullOrEmpty(StringUtil.RTrim( A552CpjConDelUsuId)) ? true : false);
               A553CpjConDelUsuNome = cgiGet( "CPJCONDELUSUNOME");
               n553CpjConDelUsuNome = (String.IsNullOrEmpty(StringUtil.RTrim( A553CpjConDelUsuNome)) ? true : false);
               ajax_req_read_hidden_sdt(cgiGet( "vAUDITINGOBJECT"), AV47AuditingObject);
               A159CliMatricula = (long)(Math.Round(context.localUtil.CToN( cgiGet( "CLIMATRICULA"), ",", "."), 18, MidpointRounding.ToEven));
               A171CpjRazaoSoc = cgiGet( "CPJRAZAOSOC");
               A188CpjCNPJFormat = cgiGet( "CPJCNPJFORMAT");
               A189CpjIE = cgiGet( "CPJIE");
               A272CpjConTipoNome = cgiGet( "CPJCONTIPONOME");
               A280CpjConGenSigla = cgiGet( "CPJCONGENSIGLA");
               A281CpjConGenNome = cgiGet( "CPJCONGENNOME");
               A366CpjTipoSigla = cgiGet( "CPJTIPOSIGLA");
               AV49Pgmname = cgiGet( "vPGMNAME");
               Combo_cliid_Objectcall = cgiGet( "COMBO_CLIID_Objectcall");
               Combo_cliid_Class = cgiGet( "COMBO_CLIID_Class");
               Combo_cliid_Icontype = cgiGet( "COMBO_CLIID_Icontype");
               Combo_cliid_Icon = cgiGet( "COMBO_CLIID_Icon");
               Combo_cliid_Caption = cgiGet( "COMBO_CLIID_Caption");
               Combo_cliid_Tooltip = cgiGet( "COMBO_CLIID_Tooltip");
               Combo_cliid_Cls = cgiGet( "COMBO_CLIID_Cls");
               Combo_cliid_Selectedvalue_set = cgiGet( "COMBO_CLIID_Selectedvalue_set");
               Combo_cliid_Selectedvalue_get = cgiGet( "COMBO_CLIID_Selectedvalue_get");
               Combo_cliid_Selectedtext_set = cgiGet( "COMBO_CLIID_Selectedtext_set");
               Combo_cliid_Selectedtext_get = cgiGet( "COMBO_CLIID_Selectedtext_get");
               Combo_cliid_Gamoauthtoken = cgiGet( "COMBO_CLIID_Gamoauthtoken");
               Combo_cliid_Ddointernalname = cgiGet( "COMBO_CLIID_Ddointernalname");
               Combo_cliid_Titlecontrolalign = cgiGet( "COMBO_CLIID_Titlecontrolalign");
               Combo_cliid_Dropdownoptionstype = cgiGet( "COMBO_CLIID_Dropdownoptionstype");
               Combo_cliid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_CLIID_Enabled"));
               Combo_cliid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_CLIID_Visible"));
               Combo_cliid_Titlecontrolidtoreplace = cgiGet( "COMBO_CLIID_Titlecontrolidtoreplace");
               Combo_cliid_Datalisttype = cgiGet( "COMBO_CLIID_Datalisttype");
               Combo_cliid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_CLIID_Allowmultipleselection"));
               Combo_cliid_Datalistfixedvalues = cgiGet( "COMBO_CLIID_Datalistfixedvalues");
               Combo_cliid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_CLIID_Isgriditem"));
               Combo_cliid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_CLIID_Hasdescription"));
               Combo_cliid_Datalistproc = cgiGet( "COMBO_CLIID_Datalistproc");
               Combo_cliid_Datalistprocparametersprefix = cgiGet( "COMBO_CLIID_Datalistprocparametersprefix");
               Combo_cliid_Remoteservicesparameters = cgiGet( "COMBO_CLIID_Remoteservicesparameters");
               Combo_cliid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_CLIID_Datalistupdateminimumcharacters"), ",", "."), 18, MidpointRounding.ToEven));
               Combo_cliid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_CLIID_Includeonlyselectedoption"));
               Combo_cliid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_CLIID_Includeselectalloption"));
               Combo_cliid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_CLIID_Emptyitem"));
               Combo_cliid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_CLIID_Includeaddnewoption"));
               Combo_cliid_Htmltemplate = cgiGet( "COMBO_CLIID_Htmltemplate");
               Combo_cliid_Multiplevaluestype = cgiGet( "COMBO_CLIID_Multiplevaluestype");
               Combo_cliid_Loadingdata = cgiGet( "COMBO_CLIID_Loadingdata");
               Combo_cliid_Noresultsfound = cgiGet( "COMBO_CLIID_Noresultsfound");
               Combo_cliid_Emptyitemtext = cgiGet( "COMBO_CLIID_Emptyitemtext");
               Combo_cliid_Onlyselectedvalues = cgiGet( "COMBO_CLIID_Onlyselectedvalues");
               Combo_cliid_Selectalltext = cgiGet( "COMBO_CLIID_Selectalltext");
               Combo_cliid_Multiplevaluesseparator = cgiGet( "COMBO_CLIID_Multiplevaluesseparator");
               Combo_cliid_Addnewoptiontext = cgiGet( "COMBO_CLIID_Addnewoptiontext");
               Combo_cliid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_CLIID_Gxcontroltype"), ",", "."), 18, MidpointRounding.ToEven));
               Combo_cpjid_Objectcall = cgiGet( "COMBO_CPJID_Objectcall");
               Combo_cpjid_Class = cgiGet( "COMBO_CPJID_Class");
               Combo_cpjid_Icontype = cgiGet( "COMBO_CPJID_Icontype");
               Combo_cpjid_Icon = cgiGet( "COMBO_CPJID_Icon");
               Combo_cpjid_Caption = cgiGet( "COMBO_CPJID_Caption");
               Combo_cpjid_Tooltip = cgiGet( "COMBO_CPJID_Tooltip");
               Combo_cpjid_Cls = cgiGet( "COMBO_CPJID_Cls");
               Combo_cpjid_Selectedvalue_set = cgiGet( "COMBO_CPJID_Selectedvalue_set");
               Combo_cpjid_Selectedvalue_get = cgiGet( "COMBO_CPJID_Selectedvalue_get");
               Combo_cpjid_Selectedtext_set = cgiGet( "COMBO_CPJID_Selectedtext_set");
               Combo_cpjid_Selectedtext_get = cgiGet( "COMBO_CPJID_Selectedtext_get");
               Combo_cpjid_Gamoauthtoken = cgiGet( "COMBO_CPJID_Gamoauthtoken");
               Combo_cpjid_Ddointernalname = cgiGet( "COMBO_CPJID_Ddointernalname");
               Combo_cpjid_Titlecontrolalign = cgiGet( "COMBO_CPJID_Titlecontrolalign");
               Combo_cpjid_Dropdownoptionstype = cgiGet( "COMBO_CPJID_Dropdownoptionstype");
               Combo_cpjid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_CPJID_Enabled"));
               Combo_cpjid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_CPJID_Visible"));
               Combo_cpjid_Titlecontrolidtoreplace = cgiGet( "COMBO_CPJID_Titlecontrolidtoreplace");
               Combo_cpjid_Datalisttype = cgiGet( "COMBO_CPJID_Datalisttype");
               Combo_cpjid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_CPJID_Allowmultipleselection"));
               Combo_cpjid_Datalistfixedvalues = cgiGet( "COMBO_CPJID_Datalistfixedvalues");
               Combo_cpjid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_CPJID_Isgriditem"));
               Combo_cpjid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_CPJID_Hasdescription"));
               Combo_cpjid_Datalistproc = cgiGet( "COMBO_CPJID_Datalistproc");
               Combo_cpjid_Datalistprocparametersprefix = cgiGet( "COMBO_CPJID_Datalistprocparametersprefix");
               Combo_cpjid_Remoteservicesparameters = cgiGet( "COMBO_CPJID_Remoteservicesparameters");
               Combo_cpjid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_CPJID_Datalistupdateminimumcharacters"), ",", "."), 18, MidpointRounding.ToEven));
               Combo_cpjid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_CPJID_Includeonlyselectedoption"));
               Combo_cpjid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_CPJID_Includeselectalloption"));
               Combo_cpjid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_CPJID_Emptyitem"));
               Combo_cpjid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_CPJID_Includeaddnewoption"));
               Combo_cpjid_Htmltemplate = cgiGet( "COMBO_CPJID_Htmltemplate");
               Combo_cpjid_Multiplevaluestype = cgiGet( "COMBO_CPJID_Multiplevaluestype");
               Combo_cpjid_Loadingdata = cgiGet( "COMBO_CPJID_Loadingdata");
               Combo_cpjid_Noresultsfound = cgiGet( "COMBO_CPJID_Noresultsfound");
               Combo_cpjid_Emptyitemtext = cgiGet( "COMBO_CPJID_Emptyitemtext");
               Combo_cpjid_Onlyselectedvalues = cgiGet( "COMBO_CPJID_Onlyselectedvalues");
               Combo_cpjid_Selectalltext = cgiGet( "COMBO_CPJID_Selectalltext");
               Combo_cpjid_Multiplevaluesseparator = cgiGet( "COMBO_CPJID_Multiplevaluesseparator");
               Combo_cpjid_Addnewoptiontext = cgiGet( "COMBO_CPJID_Addnewoptiontext");
               Combo_cpjid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_CPJID_Gxcontroltype"), ",", "."), 18, MidpointRounding.ToEven));
               Dvpanel_tablecliente_Objectcall = cgiGet( "DVPANEL_TABLECLIENTE_Objectcall");
               Dvpanel_tablecliente_Class = cgiGet( "DVPANEL_TABLECLIENTE_Class");
               Dvpanel_tablecliente_Enabled = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECLIENTE_Enabled"));
               Dvpanel_tablecliente_Width = cgiGet( "DVPANEL_TABLECLIENTE_Width");
               Dvpanel_tablecliente_Height = cgiGet( "DVPANEL_TABLECLIENTE_Height");
               Dvpanel_tablecliente_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECLIENTE_Autowidth"));
               Dvpanel_tablecliente_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECLIENTE_Autoheight"));
               Dvpanel_tablecliente_Cls = cgiGet( "DVPANEL_TABLECLIENTE_Cls");
               Dvpanel_tablecliente_Showheader = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECLIENTE_Showheader"));
               Dvpanel_tablecliente_Title = cgiGet( "DVPANEL_TABLECLIENTE_Title");
               Dvpanel_tablecliente_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECLIENTE_Collapsible"));
               Dvpanel_tablecliente_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECLIENTE_Collapsed"));
               Dvpanel_tablecliente_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECLIENTE_Showcollapseicon"));
               Dvpanel_tablecliente_Iconposition = cgiGet( "DVPANEL_TABLECLIENTE_Iconposition");
               Dvpanel_tablecliente_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECLIENTE_Autoscroll"));
               Dvpanel_tablecliente_Visible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECLIENTE_Visible"));
               Dvpanel_tablecliente_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "DVPANEL_TABLECLIENTE_Gxcontroltype"), ",", "."), 18, MidpointRounding.ToEven));
               Combo_cpjcontipoid_Objectcall = cgiGet( "COMBO_CPJCONTIPOID_Objectcall");
               Combo_cpjcontipoid_Class = cgiGet( "COMBO_CPJCONTIPOID_Class");
               Combo_cpjcontipoid_Icontype = cgiGet( "COMBO_CPJCONTIPOID_Icontype");
               Combo_cpjcontipoid_Icon = cgiGet( "COMBO_CPJCONTIPOID_Icon");
               Combo_cpjcontipoid_Caption = cgiGet( "COMBO_CPJCONTIPOID_Caption");
               Combo_cpjcontipoid_Tooltip = cgiGet( "COMBO_CPJCONTIPOID_Tooltip");
               Combo_cpjcontipoid_Cls = cgiGet( "COMBO_CPJCONTIPOID_Cls");
               Combo_cpjcontipoid_Selectedvalue_set = cgiGet( "COMBO_CPJCONTIPOID_Selectedvalue_set");
               Combo_cpjcontipoid_Selectedvalue_get = cgiGet( "COMBO_CPJCONTIPOID_Selectedvalue_get");
               Combo_cpjcontipoid_Selectedtext_set = cgiGet( "COMBO_CPJCONTIPOID_Selectedtext_set");
               Combo_cpjcontipoid_Selectedtext_get = cgiGet( "COMBO_CPJCONTIPOID_Selectedtext_get");
               Combo_cpjcontipoid_Gamoauthtoken = cgiGet( "COMBO_CPJCONTIPOID_Gamoauthtoken");
               Combo_cpjcontipoid_Ddointernalname = cgiGet( "COMBO_CPJCONTIPOID_Ddointernalname");
               Combo_cpjcontipoid_Titlecontrolalign = cgiGet( "COMBO_CPJCONTIPOID_Titlecontrolalign");
               Combo_cpjcontipoid_Dropdownoptionstype = cgiGet( "COMBO_CPJCONTIPOID_Dropdownoptionstype");
               Combo_cpjcontipoid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_CPJCONTIPOID_Enabled"));
               Combo_cpjcontipoid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_CPJCONTIPOID_Visible"));
               Combo_cpjcontipoid_Titlecontrolidtoreplace = cgiGet( "COMBO_CPJCONTIPOID_Titlecontrolidtoreplace");
               Combo_cpjcontipoid_Datalisttype = cgiGet( "COMBO_CPJCONTIPOID_Datalisttype");
               Combo_cpjcontipoid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_CPJCONTIPOID_Allowmultipleselection"));
               Combo_cpjcontipoid_Datalistfixedvalues = cgiGet( "COMBO_CPJCONTIPOID_Datalistfixedvalues");
               Combo_cpjcontipoid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_CPJCONTIPOID_Isgriditem"));
               Combo_cpjcontipoid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_CPJCONTIPOID_Hasdescription"));
               Combo_cpjcontipoid_Datalistproc = cgiGet( "COMBO_CPJCONTIPOID_Datalistproc");
               Combo_cpjcontipoid_Datalistprocparametersprefix = cgiGet( "COMBO_CPJCONTIPOID_Datalistprocparametersprefix");
               Combo_cpjcontipoid_Remoteservicesparameters = cgiGet( "COMBO_CPJCONTIPOID_Remoteservicesparameters");
               Combo_cpjcontipoid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_CPJCONTIPOID_Datalistupdateminimumcharacters"), ",", "."), 18, MidpointRounding.ToEven));
               Combo_cpjcontipoid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_CPJCONTIPOID_Includeonlyselectedoption"));
               Combo_cpjcontipoid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_CPJCONTIPOID_Includeselectalloption"));
               Combo_cpjcontipoid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_CPJCONTIPOID_Emptyitem"));
               Combo_cpjcontipoid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_CPJCONTIPOID_Includeaddnewoption"));
               Combo_cpjcontipoid_Htmltemplate = cgiGet( "COMBO_CPJCONTIPOID_Htmltemplate");
               Combo_cpjcontipoid_Multiplevaluestype = cgiGet( "COMBO_CPJCONTIPOID_Multiplevaluestype");
               Combo_cpjcontipoid_Loadingdata = cgiGet( "COMBO_CPJCONTIPOID_Loadingdata");
               Combo_cpjcontipoid_Noresultsfound = cgiGet( "COMBO_CPJCONTIPOID_Noresultsfound");
               Combo_cpjcontipoid_Emptyitemtext = cgiGet( "COMBO_CPJCONTIPOID_Emptyitemtext");
               Combo_cpjcontipoid_Onlyselectedvalues = cgiGet( "COMBO_CPJCONTIPOID_Onlyselectedvalues");
               Combo_cpjcontipoid_Selectalltext = cgiGet( "COMBO_CPJCONTIPOID_Selectalltext");
               Combo_cpjcontipoid_Multiplevaluesseparator = cgiGet( "COMBO_CPJCONTIPOID_Multiplevaluesseparator");
               Combo_cpjcontipoid_Addnewoptiontext = cgiGet( "COMBO_CPJCONTIPOID_Addnewoptiontext");
               Combo_cpjcontipoid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_CPJCONTIPOID_Gxcontroltype"), ",", "."), 18, MidpointRounding.ToEven));
               Combo_cpjcongenid_Objectcall = cgiGet( "COMBO_CPJCONGENID_Objectcall");
               Combo_cpjcongenid_Class = cgiGet( "COMBO_CPJCONGENID_Class");
               Combo_cpjcongenid_Icontype = cgiGet( "COMBO_CPJCONGENID_Icontype");
               Combo_cpjcongenid_Icon = cgiGet( "COMBO_CPJCONGENID_Icon");
               Combo_cpjcongenid_Caption = cgiGet( "COMBO_CPJCONGENID_Caption");
               Combo_cpjcongenid_Tooltip = cgiGet( "COMBO_CPJCONGENID_Tooltip");
               Combo_cpjcongenid_Cls = cgiGet( "COMBO_CPJCONGENID_Cls");
               Combo_cpjcongenid_Selectedvalue_set = cgiGet( "COMBO_CPJCONGENID_Selectedvalue_set");
               Combo_cpjcongenid_Selectedvalue_get = cgiGet( "COMBO_CPJCONGENID_Selectedvalue_get");
               Combo_cpjcongenid_Selectedtext_set = cgiGet( "COMBO_CPJCONGENID_Selectedtext_set");
               Combo_cpjcongenid_Selectedtext_get = cgiGet( "COMBO_CPJCONGENID_Selectedtext_get");
               Combo_cpjcongenid_Gamoauthtoken = cgiGet( "COMBO_CPJCONGENID_Gamoauthtoken");
               Combo_cpjcongenid_Ddointernalname = cgiGet( "COMBO_CPJCONGENID_Ddointernalname");
               Combo_cpjcongenid_Titlecontrolalign = cgiGet( "COMBO_CPJCONGENID_Titlecontrolalign");
               Combo_cpjcongenid_Dropdownoptionstype = cgiGet( "COMBO_CPJCONGENID_Dropdownoptionstype");
               Combo_cpjcongenid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_CPJCONGENID_Enabled"));
               Combo_cpjcongenid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_CPJCONGENID_Visible"));
               Combo_cpjcongenid_Titlecontrolidtoreplace = cgiGet( "COMBO_CPJCONGENID_Titlecontrolidtoreplace");
               Combo_cpjcongenid_Datalisttype = cgiGet( "COMBO_CPJCONGENID_Datalisttype");
               Combo_cpjcongenid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_CPJCONGENID_Allowmultipleselection"));
               Combo_cpjcongenid_Datalistfixedvalues = cgiGet( "COMBO_CPJCONGENID_Datalistfixedvalues");
               Combo_cpjcongenid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_CPJCONGENID_Isgriditem"));
               Combo_cpjcongenid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_CPJCONGENID_Hasdescription"));
               Combo_cpjcongenid_Datalistproc = cgiGet( "COMBO_CPJCONGENID_Datalistproc");
               Combo_cpjcongenid_Datalistprocparametersprefix = cgiGet( "COMBO_CPJCONGENID_Datalistprocparametersprefix");
               Combo_cpjcongenid_Remoteservicesparameters = cgiGet( "COMBO_CPJCONGENID_Remoteservicesparameters");
               Combo_cpjcongenid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_CPJCONGENID_Datalistupdateminimumcharacters"), ",", "."), 18, MidpointRounding.ToEven));
               Combo_cpjcongenid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_CPJCONGENID_Includeonlyselectedoption"));
               Combo_cpjcongenid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_CPJCONGENID_Includeselectalloption"));
               Combo_cpjcongenid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_CPJCONGENID_Emptyitem"));
               Combo_cpjcongenid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_CPJCONGENID_Includeaddnewoption"));
               Combo_cpjcongenid_Htmltemplate = cgiGet( "COMBO_CPJCONGENID_Htmltemplate");
               Combo_cpjcongenid_Multiplevaluestype = cgiGet( "COMBO_CPJCONGENID_Multiplevaluestype");
               Combo_cpjcongenid_Loadingdata = cgiGet( "COMBO_CPJCONGENID_Loadingdata");
               Combo_cpjcongenid_Noresultsfound = cgiGet( "COMBO_CPJCONGENID_Noresultsfound");
               Combo_cpjcongenid_Emptyitemtext = cgiGet( "COMBO_CPJCONGENID_Emptyitemtext");
               Combo_cpjcongenid_Onlyselectedvalues = cgiGet( "COMBO_CPJCONGENID_Onlyselectedvalues");
               Combo_cpjcongenid_Selectalltext = cgiGet( "COMBO_CPJCONGENID_Selectalltext");
               Combo_cpjcongenid_Multiplevaluesseparator = cgiGet( "COMBO_CPJCONGENID_Multiplevaluesseparator");
               Combo_cpjcongenid_Addnewoptiontext = cgiGet( "COMBO_CPJCONGENID_Addnewoptiontext");
               Combo_cpjcongenid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_CPJCONGENID_Gxcontroltype"), ",", "."), 18, MidpointRounding.ToEven));
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
               A158CliID = StringUtil.StrToGuid( cgiGet( edtCliID_Internalname));
               AssignAttri("", false, "A158CliID", A158CliID.ToString());
               A166CpjID = StringUtil.StrToGuid( cgiGet( edtCpjID_Internalname));
               AssignAttri("", false, "A166CpjID", A166CpjID.ToString());
               A365CpjTipoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtCpjTipoId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A365CpjTipoId", StringUtil.LTrimStr( (decimal)(A365CpjTipoId), 9, 0));
               A176CpjMatricula = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtCpjMatricula_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A176CpjMatricula", StringUtil.LTrimStr( (decimal)(A176CpjMatricula), 12, 0));
               A261CpjTelNum = cgiGet( edtCpjTelNum_Internalname);
               n261CpjTelNum = false;
               AssignAttri("", false, "A261CpjTelNum", A261CpjTelNum);
               A262CpjTelRam = cgiGet( edtCpjTelRam_Internalname);
               n262CpjTelRam = false;
               AssignAttri("", false, "A262CpjTelRam", A262CpjTelRam);
               A263CpjCelNum = cgiGet( edtCpjCelNum_Internalname);
               n263CpjCelNum = false;
               AssignAttri("", false, "A263CpjCelNum", A263CpjCelNum);
               A264CpjWppNum = cgiGet( edtCpjWppNum_Internalname);
               n264CpjWppNum = false;
               AssignAttri("", false, "A264CpjWppNum", A264CpjWppNum);
               A265CpjWebsite = cgiGet( edtCpjWebsite_Internalname);
               n265CpjWebsite = false;
               AssignAttri("", false, "A265CpjWebsite", A265CpjWebsite);
               A266CpjEmail = cgiGet( edtCpjEmail_Internalname);
               n266CpjEmail = false;
               AssignAttri("", false, "A266CpjEmail", A266CpjEmail);
               if ( ( ( context.localUtil.CToN( cgiGet( edtCpjConTipoID_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCpjConTipoID_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CPJCONTIPOID");
                  AnyError = 1;
                  GX_FocusControl = edtCpjConTipoID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A270CpjConTipoID = 0;
                  AssignAttri("", false, "A270CpjConTipoID", StringUtil.LTrimStr( (decimal)(A270CpjConTipoID), 9, 0));
               }
               else
               {
                  A270CpjConTipoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtCpjConTipoID_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A270CpjConTipoID", StringUtil.LTrimStr( (decimal)(A270CpjConTipoID), 9, 0));
               }
               A275CpjConNome = StringUtil.Upper( cgiGet( edtCpjConNome_Internalname));
               AssignAttri("", false, "A275CpjConNome", A275CpjConNome);
               A274CpjConCPFFormat = cgiGet( edtCpjConCPFFormat_Internalname);
               AssignAttri("", false, "A274CpjConCPFFormat", A274CpjConCPFFormat);
               if ( context.localUtil.VCDate( cgiGet( edtCpjConNascimento_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Data de Nascimento"}), 1, "CPJCONNASCIMENTO");
                  AnyError = 1;
                  GX_FocusControl = edtCpjConNascimento_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A282CpjConNascimento = DateTime.MinValue;
                  AssignAttri("", false, "A282CpjConNascimento", context.localUtil.Format(A282CpjConNascimento, "99/99/99"));
               }
               else
               {
                  A282CpjConNascimento = context.localUtil.CToD( cgiGet( edtCpjConNascimento_Internalname), 2);
                  AssignAttri("", false, "A282CpjConNascimento", context.localUtil.Format(A282CpjConNascimento, "99/99/99"));
               }
               A278CpjNomeSocial = StringUtil.Upper( cgiGet( edtCpjNomeSocial_Internalname));
               AssignAttri("", false, "A278CpjNomeSocial", A278CpjNomeSocial);
               if ( ( ( context.localUtil.CToN( cgiGet( edtCpjConGenID_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCpjConGenID_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CPJCONGENID");
                  AnyError = 1;
                  GX_FocusControl = edtCpjConGenID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A279CpjConGenID = 0;
                  AssignAttri("", false, "A279CpjConGenID", StringUtil.LTrimStr( (decimal)(A279CpjConGenID), 9, 0));
               }
               else
               {
                  A279CpjConGenID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtCpjConGenID_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A279CpjConGenID", StringUtil.LTrimStr( (decimal)(A279CpjConGenID), 9, 0));
               }
               A285CpjConCelNum = cgiGet( edtCpjConCelNum_Internalname);
               n285CpjConCelNum = false;
               AssignAttri("", false, "A285CpjConCelNum", A285CpjConCelNum);
               n285CpjConCelNum = (String.IsNullOrEmpty(StringUtil.RTrim( A285CpjConCelNum)) ? true : false);
               A286CpjConWppNum = cgiGet( edtCpjConWppNum_Internalname);
               n286CpjConWppNum = false;
               AssignAttri("", false, "A286CpjConWppNum", A286CpjConWppNum);
               n286CpjConWppNum = (String.IsNullOrEmpty(StringUtil.RTrim( A286CpjConWppNum)) ? true : false);
               A283CpjConTelNum = cgiGet( edtCpjConTelNum_Internalname);
               n283CpjConTelNum = false;
               AssignAttri("", false, "A283CpjConTelNum", A283CpjConTelNum);
               n283CpjConTelNum = (String.IsNullOrEmpty(StringUtil.RTrim( A283CpjConTelNum)) ? true : false);
               A284CpjConTelRam = cgiGet( edtCpjConTelRam_Internalname);
               n284CpjConTelRam = false;
               AssignAttri("", false, "A284CpjConTelRam", A284CpjConTelRam);
               n284CpjConTelRam = (String.IsNullOrEmpty(StringUtil.RTrim( A284CpjConTelRam)) ? true : false);
               A287CpjConEmail = cgiGet( edtCpjConEmail_Internalname);
               n287CpjConEmail = false;
               AssignAttri("", false, "A287CpjConEmail", A287CpjConEmail);
               n287CpjConEmail = (String.IsNullOrEmpty(StringUtil.RTrim( A287CpjConEmail)) ? true : false);
               A288CpjConLIn = cgiGet( edtCpjConLIn_Internalname);
               n288CpjConLIn = false;
               AssignAttri("", false, "A288CpjConLIn", A288CpjConLIn);
               n288CpjConLIn = (String.IsNullOrEmpty(StringUtil.RTrim( A288CpjConLIn)) ? true : false);
               AV21ComboCliID = StringUtil.StrToGuid( cgiGet( edtavCombocliid_Internalname));
               AssignAttri("", false, "AV21ComboCliID", AV21ComboCliID.ToString());
               AV45ComboCpjID = StringUtil.StrToGuid( cgiGet( edtavCombocpjid_Internalname));
               AssignAttri("", false, "AV45ComboCpjID", AV45ComboCpjID.ToString());
               AV40ComboCpjConTipoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavCombocpjcontipoid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV40ComboCpjConTipoID", StringUtil.LTrimStr( (decimal)(AV40ComboCpjConTipoID), 9, 0));
               AV42ComboCpjConGenID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavCombocpjcongenid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV42ComboCpjConGenID", StringUtil.LTrimStr( (decimal)(AV42ComboCpjConGenID), 9, 0));
               if ( ( ( context.localUtil.CToN( cgiGet( edtCpjConSeq_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCpjConSeq_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CPJCONSEQ");
                  AnyError = 1;
                  GX_FocusControl = edtCpjConSeq_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A269CpjConSeq = 0;
                  AssignAttri("", false, "A269CpjConSeq", StringUtil.LTrimStr( (decimal)(A269CpjConSeq), 4, 0));
               }
               else
               {
                  A269CpjConSeq = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtCpjConSeq_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A269CpjConSeq", StringUtil.LTrimStr( (decimal)(A269CpjConSeq), 4, 0));
               }
               A271CpjConTipoSigla = cgiGet( edtCpjConTipoSigla_Internalname);
               AssignAttri("", false, "A271CpjConTipoSigla", A271CpjConTipoSigla);
               if ( ( ( context.localUtil.CToN( cgiGet( edtCpjConCPF_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCpjConCPF_Internalname), ",", ".") > Convert.ToDecimal( 99999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CPJCONCPF");
                  AnyError = 1;
                  GX_FocusControl = edtCpjConCPF_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A273CpjConCPF = 0;
                  AssignAttri("", false, "A273CpjConCPF", StringUtil.LTrimStr( (decimal)(A273CpjConCPF), 11, 0));
               }
               else
               {
                  A273CpjConCPF = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtCpjConCPF_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A273CpjConCPF", StringUtil.LTrimStr( (decimal)(A273CpjConCPF), 11, 0));
               }
               A276CpjConNomePrim = StringUtil.Upper( cgiGet( edtCpjConNomePrim_Internalname));
               AssignAttri("", false, "A276CpjConNomePrim", A276CpjConNomePrim);
               A277CpjConSobrenome = StringUtil.Upper( cgiGet( edtCpjConSobrenome_Internalname));
               AssignAttri("", false, "A277CpjConSobrenome", A277CpjConSobrenome);
               if ( ( ( context.localUtil.CToN( cgiGet( edtCpjConUltEnd_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCpjConUltEnd_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CPJCONULTEND");
                  AnyError = 1;
                  GX_FocusControl = edtCpjConUltEnd_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A328CpjConUltEnd = 0;
                  n328CpjConUltEnd = false;
                  AssignAttri("", false, "A328CpjConUltEnd", StringUtil.LTrimStr( (decimal)(A328CpjConUltEnd), 4, 0));
               }
               else
               {
                  A328CpjConUltEnd = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtCpjConUltEnd_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  n328CpjConUltEnd = false;
                  AssignAttri("", false, "A328CpjConUltEnd", StringUtil.LTrimStr( (decimal)(A328CpjConUltEnd), 4, 0));
               }
               n328CpjConUltEnd = ((0==A328CpjConUltEnd) ? true : false);
               A187CpjCNPJ = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtCpjCNPJ_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A187CpjCNPJ", StringUtil.LTrimStr( (decimal)(A187CpjCNPJ), 14, 0));
               A207CpjAtivo = StringUtil.StrToBool( cgiGet( edtCpjAtivo_Internalname));
               AssignAttri("", false, "A207CpjAtivo", A207CpjAtivo);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"ClientePJContato");
               A158CliID = StringUtil.StrToGuid( cgiGet( edtCliID_Internalname));
               AssignAttri("", false, "A158CliID", A158CliID.ToString());
               forbiddenHiddens.Add("CliID", A158CliID.ToString());
               A166CpjID = StringUtil.StrToGuid( cgiGet( edtCpjID_Internalname));
               AssignAttri("", false, "A166CpjID", A166CpjID.ToString());
               forbiddenHiddens.Add("CpjID", A166CpjID.ToString());
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("Pgmname", StringUtil.RTrim( context.localUtil.Format( AV49Pgmname, "")));
               forbiddenHiddens.Add("CpjConDel", StringUtil.BoolToStr( A548CpjConDel));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A158CliID != Z158CliID ) || ( A166CpjID != Z166CpjID ) || ( A269CpjConSeq != Z269CpjConSeq ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("core\\clientepjcontato:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A158CliID = StringUtil.StrToGuid( GetPar( "CliID"));
                  AssignAttri("", false, "A158CliID", A158CliID.ToString());
                  A166CpjID = StringUtil.StrToGuid( GetPar( "CpjID"));
                  AssignAttri("", false, "A166CpjID", A166CpjID.ToString());
                  A269CpjConSeq = (short)(Math.Round(NumberUtil.Val( GetPar( "CpjConSeq"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A269CpjConSeq", StringUtil.LTrimStr( (decimal)(A269CpjConSeq), 4, 0));
                  getEqualNoModal( ) ;
                  if ( ! (0==AV37CpjConSeq) )
                  {
                     A269CpjConSeq = AV37CpjConSeq;
                     AssignAttri("", false, "A269CpjConSeq", StringUtil.LTrimStr( (decimal)(A269CpjConSeq), 4, 0));
                  }
                  else
                  {
                     if ( IsIns( )  && ( Gx_BScreen == 1 ) )
                     {
                        A269CpjConSeq = A268CpjUltConSeq;
                        AssignAttri("", false, "A269CpjConSeq", StringUtil.LTrimStr( (decimal)(A269CpjConSeq), 4, 0));
                     }
                  }
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  disable_std_buttons( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  if ( IsDsp( ) )
                  {
                     sMode32 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     if ( ! (0==AV37CpjConSeq) )
                     {
                        A269CpjConSeq = AV37CpjConSeq;
                        AssignAttri("", false, "A269CpjConSeq", StringUtil.LTrimStr( (decimal)(A269CpjConSeq), 4, 0));
                     }
                     else
                     {
                        if ( IsIns( )  && ( Gx_BScreen == 1 ) )
                        {
                           A269CpjConSeq = A268CpjUltConSeq;
                           AssignAttri("", false, "A269CpjConSeq", StringUtil.LTrimStr( (decimal)(A269CpjConSeq), 4, 0));
                        }
                     }
                     Gx_mode = sMode32;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound32 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_100( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "CLIID");
                        AnyError = 1;
                        GX_FocusControl = edtCliID_Internalname;
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
                        if ( StringUtil.StrCmp(sEvt, "COMBO_CLIID.ONOPTIONCLICKED") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           E12102 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "COMBO_CPJID.ONOPTIONCLICKED") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           E13102 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "COMBO_CPJCONTIPOID.ONOPTIONCLICKED") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           E14102 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "COMBO_CPJCONGENID.ONOPTIONCLICKED") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           E15102 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E11102 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E16102 ();
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
            E16102 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll1032( ) ;
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
            DisableAttributes1032( ) ;
         }
         AssignProp("", false, edtavCombocliid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombocliid_Enabled), 5, 0), true);
         AssignProp("", false, edtavCombocpjid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombocpjid_Enabled), 5, 0), true);
         AssignProp("", false, edtavCombocpjcontipoid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombocpjcontipoid_Enabled), 5, 0), true);
         AssignProp("", false, edtavCombocpjcongenid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombocpjcongenid_Enabled), 5, 0), true);
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

      protected void CONFIRM_100( )
      {
         BeforeValidate1032( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1032( ) ;
            }
            else
            {
               CheckExtendedTable1032( ) ;
               CloseExtendedTableCursors1032( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption100( )
      {
      }

      protected void E11102( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV17DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV17DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         edtCpjConGenID_Visible = 0;
         AssignProp("", false, edtCpjConGenID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCpjConGenID_Visible), 5, 0), true);
         AV42ComboCpjConGenID = 0;
         AssignAttri("", false, "AV42ComboCpjConGenID", StringUtil.LTrimStr( (decimal)(AV42ComboCpjConGenID), 9, 0));
         edtavCombocpjcongenid_Visible = 0;
         AssignProp("", false, edtavCombocpjcongenid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombocpjcongenid_Visible), 5, 0), true);
         edtCpjConTipoID_Visible = 0;
         AssignProp("", false, edtCpjConTipoID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCpjConTipoID_Visible), 5, 0), true);
         AV40ComboCpjConTipoID = 0;
         AssignAttri("", false, "AV40ComboCpjConTipoID", StringUtil.LTrimStr( (decimal)(AV40ComboCpjConTipoID), 9, 0));
         edtavCombocpjcontipoid_Visible = 0;
         AssignProp("", false, edtavCombocpjcontipoid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombocpjcontipoid_Visible), 5, 0), true);
         AV22GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV23GAMErrors);
         Combo_cpjid_Gamoauthtoken = AV22GAMSession.gxTpr_Token;
         ucCombo_cpjid.SendProperty(context, "", false, Combo_cpjid_Internalname, "GAMOAuthToken", Combo_cpjid_Gamoauthtoken);
         edtCpjID_Visible = 0;
         AssignProp("", false, edtCpjID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCpjID_Visible), 5, 0), true);
         AV45ComboCpjID = Guid.Empty;
         AssignAttri("", false, "AV45ComboCpjID", AV45ComboCpjID.ToString());
         edtavCombocpjid_Visible = 0;
         AssignProp("", false, edtavCombocpjid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombocpjid_Visible), 5, 0), true);
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getstyleddvcombo(context ).execute(  "Title and subtitle", out  GXt_char2) ;
         Combo_cpjid_Htmltemplate = GXt_char2;
         ucCombo_cpjid.SendProperty(context, "", false, Combo_cpjid_Internalname, "HTMLTemplate", Combo_cpjid_Htmltemplate);
         edtCliID_Visible = 0;
         AssignProp("", false, edtCliID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCliID_Visible), 5, 0), true);
         AV21ComboCliID = Guid.Empty;
         AssignAttri("", false, "AV21ComboCliID", AV21ComboCliID.ToString());
         edtavCombocliid_Visible = 0;
         AssignProp("", false, edtavCombocliid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombocliid_Visible), 5, 0), true);
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getstyleddvcombo(context ).execute(  "Title and subtitle", out  GXt_char2) ;
         Combo_cliid_Htmltemplate = GXt_char2;
         ucCombo_cliid.SendProperty(context, "", false, Combo_cliid_Internalname, "HTMLTemplate", Combo_cliid_Htmltemplate);
         /* Execute user subroutine: 'LOADCOMBOCLIID' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBOCPJID' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBOCPJCONTIPOID' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBOCPJCONGENID' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV12TrnContext.FromXml(AV13WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV12TrnContext.gxTpr_Transactionname, AV49Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV50GXV1 = 1;
            AssignAttri("", false, "AV50GXV1", StringUtil.LTrimStr( (decimal)(AV50GXV1), 8, 0));
            while ( AV50GXV1 <= AV12TrnContext.gxTpr_Attributes.Count )
            {
               AV15TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV12TrnContext.gxTpr_Attributes.Item(AV50GXV1));
               if ( StringUtil.StrCmp(AV15TrnContextAtt.gxTpr_Attributename, "CpjConTipoID") == 0 )
               {
                  AV38Insert_CpjConTipoID = (int)(Math.Round(NumberUtil.Val( AV15TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV38Insert_CpjConTipoID", StringUtil.LTrimStr( (decimal)(AV38Insert_CpjConTipoID), 9, 0));
                  if ( ! (0==AV38Insert_CpjConTipoID) )
                  {
                     AV40ComboCpjConTipoID = AV38Insert_CpjConTipoID;
                     AssignAttri("", false, "AV40ComboCpjConTipoID", StringUtil.LTrimStr( (decimal)(AV40ComboCpjConTipoID), 9, 0));
                     Combo_cpjcontipoid_Selectedvalue_set = StringUtil.Trim( StringUtil.Str( (decimal)(AV40ComboCpjConTipoID), 9, 0));
                     ucCombo_cpjcontipoid.SendProperty(context, "", false, Combo_cpjcontipoid_Internalname, "SelectedValue_set", Combo_cpjcontipoid_Selectedvalue_set);
                     Combo_cpjcontipoid_Enabled = false;
                     ucCombo_cpjcontipoid.SendProperty(context, "", false, Combo_cpjcontipoid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_cpjcontipoid_Enabled));
                  }
               }
               else if ( StringUtil.StrCmp(AV15TrnContextAtt.gxTpr_Attributename, "CpjConGenID") == 0 )
               {
                  AV39Insert_CpjConGenID = (int)(Math.Round(NumberUtil.Val( AV15TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV39Insert_CpjConGenID", StringUtil.LTrimStr( (decimal)(AV39Insert_CpjConGenID), 9, 0));
                  if ( ! (0==AV39Insert_CpjConGenID) )
                  {
                     AV42ComboCpjConGenID = AV39Insert_CpjConGenID;
                     AssignAttri("", false, "AV42ComboCpjConGenID", StringUtil.LTrimStr( (decimal)(AV42ComboCpjConGenID), 9, 0));
                     Combo_cpjcongenid_Selectedvalue_set = StringUtil.Trim( StringUtil.Str( (decimal)(AV42ComboCpjConGenID), 9, 0));
                     ucCombo_cpjcongenid.SendProperty(context, "", false, Combo_cpjcongenid_Internalname, "SelectedValue_set", Combo_cpjcongenid_Selectedvalue_set);
                     Combo_cpjcongenid_Enabled = false;
                     ucCombo_cpjcongenid.SendProperty(context, "", false, Combo_cpjcongenid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_cpjcongenid_Enabled));
                  }
               }
               AV50GXV1 = (int)(AV50GXV1+1);
               AssignAttri("", false, "AV50GXV1", StringUtil.LTrimStr( (decimal)(AV50GXV1), 8, 0));
            }
         }
         edtCpjConSeq_Visible = 0;
         AssignProp("", false, edtCpjConSeq_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCpjConSeq_Visible), 5, 0), true);
         edtCpjConTipoSigla_Visible = 0;
         AssignProp("", false, edtCpjConTipoSigla_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCpjConTipoSigla_Visible), 5, 0), true);
         edtCpjConCPF_Visible = 0;
         AssignProp("", false, edtCpjConCPF_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCpjConCPF_Visible), 5, 0), true);
         edtCpjConNomePrim_Visible = 0;
         AssignProp("", false, edtCpjConNomePrim_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCpjConNomePrim_Visible), 5, 0), true);
         edtCpjConSobrenome_Visible = 0;
         AssignProp("", false, edtCpjConSobrenome_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCpjConSobrenome_Visible), 5, 0), true);
         edtCpjConUltEnd_Visible = 0;
         AssignProp("", false, edtCpjConUltEnd_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCpjConUltEnd_Visible), 5, 0), true);
         edtCpjCNPJ_Visible = 0;
         AssignProp("", false, edtCpjCNPJ_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCpjCNPJ_Visible), 5, 0), true);
         edtCpjAtivo_Visible = 0;
         AssignProp("", false, edtCpjAtivo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCpjAtivo_Visible), 5, 0), true);
      }

      protected void E16102( )
      {
         /* After Trn Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.audittransaction(context ).execute(  AV47AuditingObject,  AV49Pgmname) ;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV12TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("core.clientepjcontatoww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void E15102( )
      {
         /* Combo_cpjcongenid_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Combo_cpjcongenid_Selectedvalue_get, "<#NEW#>") == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "core.genero.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0));
            context.PopUp(formatLink("core.genero.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
         }
         else if ( StringUtil.StrCmp(Combo_cpjcongenid_Selectedvalue_get, "<#POPUP_CLOSED#>") == 0 )
         {
            GXt_char2 = AV20Combo_DataJson;
            new GeneXus.Programs.core.clientepjcontatoloaddvcombo(context ).execute(  "CpjConGenID",  "NEW",  false,  AV7CliID,  AV8CpjID,  AV37CpjConSeq,  A158CliID,  "", out  AV18ComboSelectedValue, out  AV19ComboSelectedText, out  GXt_char2) ;
            AV20Combo_DataJson = GXt_char2;
            AV33CpjConGenID_Data.FromJSonString(AV20Combo_DataJson, null);
            AV18ComboSelectedValue = AV13WebSession.Get("GENID");
            AV13WebSession.Remove("GENID");
            Combo_cpjcongenid_Selectedvalue_set = AV18ComboSelectedValue;
            ucCombo_cpjcongenid.SendProperty(context, "", false, Combo_cpjcongenid_Internalname, "SelectedValue_set", Combo_cpjcongenid_Selectedvalue_set);
            AV42ComboCpjConGenID = (int)(Math.Round(NumberUtil.Val( AV18ComboSelectedValue, "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV42ComboCpjConGenID", StringUtil.LTrimStr( (decimal)(AV42ComboCpjConGenID), 9, 0));
         }
         else
         {
            AV42ComboCpjConGenID = (int)(Math.Round(NumberUtil.Val( Combo_cpjcongenid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV42ComboCpjConGenID", StringUtil.LTrimStr( (decimal)(AV42ComboCpjConGenID), 9, 0));
            GXt_char2 = AV20Combo_DataJson;
            new GeneXus.Programs.core.clientepjcontatoloaddvcombo(context ).execute(  "CpjConGenID",  "NEW",  false,  AV7CliID,  AV8CpjID,  AV37CpjConSeq,  A158CliID,  "", out  AV18ComboSelectedValue, out  AV19ComboSelectedText, out  GXt_char2) ;
            AV20Combo_DataJson = GXt_char2;
            AV33CpjConGenID_Data.FromJSonString(AV20Combo_DataJson, null);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV33CpjConGenID_Data", AV33CpjConGenID_Data);
      }

      protected void E14102( )
      {
         /* Combo_cpjcontipoid_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Combo_cpjcontipoid_Selectedvalue_get, "<#NEW#>") == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "core.contatotipo.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0));
            context.PopUp(formatLink("core.contatotipo.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
         }
         else if ( StringUtil.StrCmp(Combo_cpjcontipoid_Selectedvalue_get, "<#POPUP_CLOSED#>") == 0 )
         {
            GXt_char2 = AV20Combo_DataJson;
            new GeneXus.Programs.core.clientepjcontatoloaddvcombo(context ).execute(  "CpjConTipoID",  "NEW",  false,  AV7CliID,  AV8CpjID,  AV37CpjConSeq,  A158CliID,  "", out  AV18ComboSelectedValue, out  AV19ComboSelectedText, out  GXt_char2) ;
            AV20Combo_DataJson = GXt_char2;
            AV32CpjConTipoID_Data.FromJSonString(AV20Combo_DataJson, null);
            AV18ComboSelectedValue = AV13WebSession.Get("COTID");
            AV13WebSession.Remove("COTID");
            Combo_cpjcontipoid_Selectedvalue_set = AV18ComboSelectedValue;
            ucCombo_cpjcontipoid.SendProperty(context, "", false, Combo_cpjcontipoid_Internalname, "SelectedValue_set", Combo_cpjcontipoid_Selectedvalue_set);
            AV40ComboCpjConTipoID = (int)(Math.Round(NumberUtil.Val( AV18ComboSelectedValue, "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV40ComboCpjConTipoID", StringUtil.LTrimStr( (decimal)(AV40ComboCpjConTipoID), 9, 0));
         }
         else
         {
            AV40ComboCpjConTipoID = (int)(Math.Round(NumberUtil.Val( Combo_cpjcontipoid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV40ComboCpjConTipoID", StringUtil.LTrimStr( (decimal)(AV40ComboCpjConTipoID), 9, 0));
            GXt_char2 = AV20Combo_DataJson;
            new GeneXus.Programs.core.clientepjcontatoloaddvcombo(context ).execute(  "CpjConTipoID",  "NEW",  false,  AV7CliID,  AV8CpjID,  AV37CpjConSeq,  A158CliID,  "", out  AV18ComboSelectedValue, out  AV19ComboSelectedText, out  GXt_char2) ;
            AV20Combo_DataJson = GXt_char2;
            AV32CpjConTipoID_Data.FromJSonString(AV20Combo_DataJson, null);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV32CpjConTipoID_Data", AV32CpjConTipoID_Data);
      }

      protected void E13102( )
      {
         /* Combo_cpjid_Onoptionclicked Routine */
         returnInSub = false;
         AV45ComboCpjID = StringUtil.StrToGuid( Combo_cpjid_Selectedvalue_get);
         AssignAttri("", false, "AV45ComboCpjID", AV45ComboCpjID.ToString());
         /*  Sending Event outputs  */
      }

      protected void E12102( )
      {
         /* Combo_cliid_Onoptionclicked Routine */
         returnInSub = false;
         AV46Cond_CliID = A158CliID;
         AV21ComboCliID = StringUtil.StrToGuid( Combo_cliid_Selectedvalue_get);
         AssignAttri("", false, "AV21ComboCliID", AV21ComboCliID.ToString());
         if ( AV46Cond_CliID != AV21ComboCliID )
         {
            AV45ComboCpjID = Guid.Empty;
            AssignAttri("", false, "AV45ComboCpjID", AV45ComboCpjID.ToString());
            Combo_cpjid_Selectedvalue_set = "";
            ucCombo_cpjid.SendProperty(context, "", false, Combo_cpjid_Internalname, "SelectedValue_set", Combo_cpjid_Selectedvalue_set);
            Combo_cpjid_Selectedtext_set = "";
            ucCombo_cpjid.SendProperty(context, "", false, Combo_cpjid_Internalname, "SelectedText_set", Combo_cpjid_Selectedtext_set);
         }
         /*  Sending Event outputs  */
      }

      protected void S142( )
      {
         /* 'LOADCOMBOCPJCONGENID' Routine */
         returnInSub = false;
         GXt_boolean3 = false;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "genero_Insert", out  GXt_boolean3) ;
         Combo_cpjcongenid_Includeaddnewoption = GXt_boolean3;
         ucCombo_cpjcongenid.SendProperty(context, "", false, Combo_cpjcongenid_Internalname, "IncludeAddNewOption", StringUtil.BoolToStr( Combo_cpjcongenid_Includeaddnewoption));
         GXt_char2 = AV20Combo_DataJson;
         new GeneXus.Programs.core.clientepjcontatoloaddvcombo(context ).execute(  "CpjConGenID",  Gx_mode,  false,  AV7CliID,  AV8CpjID,  AV37CpjConSeq,  A158CliID,  "", out  AV18ComboSelectedValue, out  AV19ComboSelectedText, out  GXt_char2) ;
         AV20Combo_DataJson = GXt_char2;
         AV33CpjConGenID_Data.FromJSonString(AV20Combo_DataJson, null);
         Combo_cpjcongenid_Selectedvalue_set = AV18ComboSelectedValue;
         ucCombo_cpjcongenid.SendProperty(context, "", false, Combo_cpjcongenid_Internalname, "SelectedValue_set", Combo_cpjcongenid_Selectedvalue_set);
         AV42ComboCpjConGenID = (int)(Math.Round(NumberUtil.Val( AV18ComboSelectedValue, "."), 18, MidpointRounding.ToEven));
         AssignAttri("", false, "AV42ComboCpjConGenID", StringUtil.LTrimStr( (decimal)(AV42ComboCpjConGenID), 9, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_cpjcongenid_Enabled = false;
            ucCombo_cpjcongenid.SendProperty(context, "", false, Combo_cpjcongenid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_cpjcongenid_Enabled));
         }
      }

      protected void S132( )
      {
         /* 'LOADCOMBOCPJCONTIPOID' Routine */
         returnInSub = false;
         GXt_boolean3 = false;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "contatotipo_Insert", out  GXt_boolean3) ;
         Combo_cpjcontipoid_Includeaddnewoption = GXt_boolean3;
         ucCombo_cpjcontipoid.SendProperty(context, "", false, Combo_cpjcontipoid_Internalname, "IncludeAddNewOption", StringUtil.BoolToStr( Combo_cpjcontipoid_Includeaddnewoption));
         GXt_char2 = AV20Combo_DataJson;
         new GeneXus.Programs.core.clientepjcontatoloaddvcombo(context ).execute(  "CpjConTipoID",  Gx_mode,  false,  AV7CliID,  AV8CpjID,  AV37CpjConSeq,  A158CliID,  "", out  AV18ComboSelectedValue, out  AV19ComboSelectedText, out  GXt_char2) ;
         AV20Combo_DataJson = GXt_char2;
         AV32CpjConTipoID_Data.FromJSonString(AV20Combo_DataJson, null);
         Combo_cpjcontipoid_Selectedvalue_set = AV18ComboSelectedValue;
         ucCombo_cpjcontipoid.SendProperty(context, "", false, Combo_cpjcontipoid_Internalname, "SelectedValue_set", Combo_cpjcontipoid_Selectedvalue_set);
         AV40ComboCpjConTipoID = (int)(Math.Round(NumberUtil.Val( AV18ComboSelectedValue, "."), 18, MidpointRounding.ToEven));
         AssignAttri("", false, "AV40ComboCpjConTipoID", StringUtil.LTrimStr( (decimal)(AV40ComboCpjConTipoID), 9, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_cpjcontipoid_Enabled = false;
            ucCombo_cpjcontipoid.SendProperty(context, "", false, Combo_cpjcontipoid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_cpjcontipoid_Enabled));
         }
      }

      protected void S122( )
      {
         /* 'LOADCOMBOCPJID' Routine */
         returnInSub = false;
         Combo_cpjid_Datalistprocparametersprefix = StringUtil.Format( " \"ComboName\": \"CpjID\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"CliID\": \"00000000-0000-0000-0000-000000000000\", \"CpjID\": \"00000000-0000-0000-0000-000000000000\", \"CpjConSeq\": 0, \"Cond_CliID\": \"#%1#\"", edtCliID_Internalname, "", "", "", "", "", "", "", "");
         ucCombo_cpjid.SendProperty(context, "", false, Combo_cpjid_Internalname, "DataListProcParametersPrefix", Combo_cpjid_Datalistprocparametersprefix);
         GXt_char2 = AV20Combo_DataJson;
         new GeneXus.Programs.core.clientepjcontatoloaddvcombo(context ).execute(  "CpjID",  Gx_mode,  false,  AV7CliID,  AV8CpjID,  AV37CpjConSeq,  A158CliID,  "", out  AV18ComboSelectedValue, out  AV19ComboSelectedText, out  GXt_char2) ;
         AV20Combo_DataJson = GXt_char2;
         Combo_cpjid_Selectedvalue_set = AV18ComboSelectedValue;
         ucCombo_cpjid.SendProperty(context, "", false, Combo_cpjid_Internalname, "SelectedValue_set", Combo_cpjid_Selectedvalue_set);
         Combo_cpjid_Selectedtext_set = AV19ComboSelectedText;
         ucCombo_cpjid.SendProperty(context, "", false, Combo_cpjid_Internalname, "SelectedText_set", Combo_cpjid_Selectedtext_set);
         AV45ComboCpjID = StringUtil.StrToGuid( AV18ComboSelectedValue);
         AssignAttri("", false, "AV45ComboCpjID", AV45ComboCpjID.ToString());
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") != 0 ) || ! (Guid.Empty==AV8CpjID) )
         {
            Combo_cpjid_Enabled = false;
            ucCombo_cpjid.SendProperty(context, "", false, Combo_cpjid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_cpjid_Enabled));
         }
      }

      protected void S112( )
      {
         /* 'LOADCOMBOCLIID' Routine */
         returnInSub = false;
         GXt_char2 = AV20Combo_DataJson;
         new GeneXus.Programs.core.clientepjcontatoloaddvcombo(context ).execute(  "CliID",  Gx_mode,  false,  AV7CliID,  AV8CpjID,  AV37CpjConSeq,  A158CliID,  "", out  AV18ComboSelectedValue, out  AV19ComboSelectedText, out  GXt_char2) ;
         AV20Combo_DataJson = GXt_char2;
         AV16CliID_Data.FromJSonString(AV20Combo_DataJson, null);
         Combo_cliid_Selectedvalue_set = AV18ComboSelectedValue;
         ucCombo_cliid.SendProperty(context, "", false, Combo_cliid_Internalname, "SelectedValue_set", Combo_cliid_Selectedvalue_set);
         AV21ComboCliID = StringUtil.StrToGuid( AV18ComboSelectedValue);
         AssignAttri("", false, "AV21ComboCliID", AV21ComboCliID.ToString());
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") != 0 ) || ! (Guid.Empty==AV7CliID) )
         {
            Combo_cliid_Enabled = false;
            ucCombo_cliid.SendProperty(context, "", false, Combo_cliid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_cliid_Enabled));
         }
      }

      protected void ZM1032( short GX_JID )
      {
         if ( ( GX_JID == 39 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z549CpjConDelDataHora = T00103_A549CpjConDelDataHora[0];
               Z550CpjConDelData = T00103_A550CpjConDelData[0];
               Z551CpjConDelHora = T00103_A551CpjConDelHora[0];
               Z552CpjConDelUsuId = T00103_A552CpjConDelUsuId[0];
               Z553CpjConDelUsuNome = T00103_A553CpjConDelUsuNome[0];
               Z273CpjConCPF = T00103_A273CpjConCPF[0];
               Z274CpjConCPFFormat = T00103_A274CpjConCPFFormat[0];
               Z275CpjConNome = T00103_A275CpjConNome[0];
               Z276CpjConNomePrim = T00103_A276CpjConNomePrim[0];
               Z277CpjConSobrenome = T00103_A277CpjConSobrenome[0];
               Z278CpjNomeSocial = T00103_A278CpjNomeSocial[0];
               Z282CpjConNascimento = T00103_A282CpjConNascimento[0];
               Z283CpjConTelNum = T00103_A283CpjConTelNum[0];
               Z284CpjConTelRam = T00103_A284CpjConTelRam[0];
               Z285CpjConCelNum = T00103_A285CpjConCelNum[0];
               Z286CpjConWppNum = T00103_A286CpjConWppNum[0];
               Z287CpjConEmail = T00103_A287CpjConEmail[0];
               Z288CpjConLIn = T00103_A288CpjConLIn[0];
               Z328CpjConUltEnd = T00103_A328CpjConUltEnd[0];
               Z548CpjConDel = T00103_A548CpjConDel[0];
               Z270CpjConTipoID = T00103_A270CpjConTipoID[0];
               Z279CpjConGenID = T00103_A279CpjConGenID[0];
            }
            else
            {
               Z549CpjConDelDataHora = A549CpjConDelDataHora;
               Z550CpjConDelData = A550CpjConDelData;
               Z551CpjConDelHora = A551CpjConDelHora;
               Z552CpjConDelUsuId = A552CpjConDelUsuId;
               Z553CpjConDelUsuNome = A553CpjConDelUsuNome;
               Z273CpjConCPF = A273CpjConCPF;
               Z274CpjConCPFFormat = A274CpjConCPFFormat;
               Z275CpjConNome = A275CpjConNome;
               Z276CpjConNomePrim = A276CpjConNomePrim;
               Z277CpjConSobrenome = A277CpjConSobrenome;
               Z278CpjNomeSocial = A278CpjNomeSocial;
               Z282CpjConNascimento = A282CpjConNascimento;
               Z283CpjConTelNum = A283CpjConTelNum;
               Z284CpjConTelRam = A284CpjConTelRam;
               Z285CpjConCelNum = A285CpjConCelNum;
               Z286CpjConWppNum = A286CpjConWppNum;
               Z287CpjConEmail = A287CpjConEmail;
               Z288CpjConLIn = A288CpjConLIn;
               Z328CpjConUltEnd = A328CpjConUltEnd;
               Z548CpjConDel = A548CpjConDel;
               Z270CpjConTipoID = A270CpjConTipoID;
               Z279CpjConGenID = A279CpjConGenID;
            }
         }
         if ( ( GX_JID == 42 ) || ( GX_JID == 0 ) )
         {
            Z170CpjNomeFan = T00106_A170CpjNomeFan[0];
            Z171CpjRazaoSoc = T00106_A171CpjRazaoSoc[0];
            Z176CpjMatricula = T00106_A176CpjMatricula[0];
            Z187CpjCNPJ = T00106_A187CpjCNPJ[0];
            Z188CpjCNPJFormat = T00106_A188CpjCNPJFormat[0];
            Z189CpjIE = T00106_A189CpjIE[0];
            Z207CpjAtivo = T00106_A207CpjAtivo[0];
            Z261CpjTelNum = T00106_A261CpjTelNum[0];
            Z262CpjTelRam = T00106_A262CpjTelRam[0];
            Z263CpjCelNum = T00106_A263CpjCelNum[0];
            Z264CpjWppNum = T00106_A264CpjWppNum[0];
            Z265CpjWebsite = T00106_A265CpjWebsite[0];
            Z266CpjEmail = T00106_A266CpjEmail[0];
            Z365CpjTipoId = T00106_A365CpjTipoId[0];
         }
         if ( GX_JID == -39 )
         {
            Z269CpjConSeq = A269CpjConSeq;
            Z549CpjConDelDataHora = A549CpjConDelDataHora;
            Z550CpjConDelData = A550CpjConDelData;
            Z551CpjConDelHora = A551CpjConDelHora;
            Z552CpjConDelUsuId = A552CpjConDelUsuId;
            Z553CpjConDelUsuNome = A553CpjConDelUsuNome;
            Z271CpjConTipoSigla = A271CpjConTipoSigla;
            Z272CpjConTipoNome = A272CpjConTipoNome;
            Z273CpjConCPF = A273CpjConCPF;
            Z274CpjConCPFFormat = A274CpjConCPFFormat;
            Z275CpjConNome = A275CpjConNome;
            Z276CpjConNomePrim = A276CpjConNomePrim;
            Z277CpjConSobrenome = A277CpjConSobrenome;
            Z278CpjNomeSocial = A278CpjNomeSocial;
            Z280CpjConGenSigla = A280CpjConGenSigla;
            Z281CpjConGenNome = A281CpjConGenNome;
            Z282CpjConNascimento = A282CpjConNascimento;
            Z283CpjConTelNum = A283CpjConTelNum;
            Z284CpjConTelRam = A284CpjConTelRam;
            Z285CpjConCelNum = A285CpjConCelNum;
            Z286CpjConWppNum = A286CpjConWppNum;
            Z287CpjConEmail = A287CpjConEmail;
            Z288CpjConLIn = A288CpjConLIn;
            Z328CpjConUltEnd = A328CpjConUltEnd;
            Z548CpjConDel = A548CpjConDel;
            Z158CliID = A158CliID;
            Z166CpjID = A166CpjID;
            Z270CpjConTipoID = A270CpjConTipoID;
            Z279CpjConGenID = A279CpjConGenID;
            Z159CliMatricula = A159CliMatricula;
            Z160CliNomeFamiliar = A160CliNomeFamiliar;
            Z268CpjUltConSeq = A268CpjUltConSeq;
            Z170CpjNomeFan = A170CpjNomeFan;
            Z171CpjRazaoSoc = A171CpjRazaoSoc;
            Z176CpjMatricula = A176CpjMatricula;
            Z187CpjCNPJ = A187CpjCNPJ;
            Z188CpjCNPJFormat = A188CpjCNPJFormat;
            Z189CpjIE = A189CpjIE;
            Z207CpjAtivo = A207CpjAtivo;
            Z261CpjTelNum = A261CpjTelNum;
            Z262CpjTelRam = A262CpjTelRam;
            Z263CpjCelNum = A263CpjCelNum;
            Z264CpjWppNum = A264CpjWppNum;
            Z265CpjWebsite = A265CpjWebsite;
            Z266CpjEmail = A266CpjEmail;
            Z365CpjTipoId = A365CpjTipoId;
            Z366CpjTipoSigla = A366CpjTipoSigla;
            Z367CpjTipoNome = A367CpjTipoNome;
         }
      }

      protected void standaloneNotModal( )
      {
         edtCliID_Enabled = 0;
         AssignProp("", false, edtCliID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliID_Enabled), 5, 0), true);
         edtCpjID_Enabled = 0;
         AssignProp("", false, edtCpjID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjID_Enabled), 5, 0), true);
         edtCpjTipoId_Enabled = 0;
         AssignProp("", false, edtCpjTipoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjTipoId_Enabled), 5, 0), true);
         AV49Pgmname = "core.ClientePJContato";
         AssignAttri("", false, "AV49Pgmname", AV49Pgmname);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         edtCliID_Enabled = 0;
         AssignProp("", false, edtCliID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliID_Enabled), 5, 0), true);
         edtCpjID_Enabled = 0;
         AssignProp("", false, edtCpjID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjID_Enabled), 5, 0), true);
         edtCpjTipoId_Enabled = 0;
         AssignProp("", false, edtCpjTipoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjTipoId_Enabled), 5, 0), true);
         if ( ! (0==AV37CpjConSeq) )
         {
            edtCpjConSeq_Enabled = 0;
            AssignProp("", false, edtCpjConSeq_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjConSeq_Enabled), 5, 0), true);
         }
         else
         {
            edtCpjConSeq_Enabled = 1;
            AssignProp("", false, edtCpjConSeq_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjConSeq_Enabled), 5, 0), true);
         }
         if ( ! (0==AV37CpjConSeq) )
         {
            edtCpjConSeq_Enabled = 0;
            AssignProp("", false, edtCpjConSeq_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjConSeq_Enabled), 5, 0), true);
         }
         if ( ! (Guid.Empty==AV8CpjID) )
         {
            A166CpjID = AV8CpjID;
            AssignAttri("", false, "A166CpjID", A166CpjID.ToString());
         }
         else
         {
            A166CpjID = AV45ComboCpjID;
            AssignAttri("", false, "A166CpjID", A166CpjID.ToString());
         }
         if ( ! (Guid.Empty==AV7CliID) )
         {
            A158CliID = AV7CliID;
            AssignAttri("", false, "A158CliID", A158CliID.ToString());
         }
         else
         {
            A158CliID = AV21ComboCliID;
            AssignAttri("", false, "A158CliID", A158CliID.ToString());
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV38Insert_CpjConTipoID) )
         {
            edtCpjConTipoID_Enabled = 0;
            AssignProp("", false, edtCpjConTipoID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjConTipoID_Enabled), 5, 0), true);
         }
         else
         {
            edtCpjConTipoID_Enabled = 1;
            AssignProp("", false, edtCpjConTipoID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjConTipoID_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV39Insert_CpjConGenID) )
         {
            edtCpjConGenID_Enabled = 0;
            AssignProp("", false, edtCpjConGenID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjConGenID_Enabled), 5, 0), true);
         }
         else
         {
            edtCpjConGenID_Enabled = 1;
            AssignProp("", false, edtCpjConGenID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjConGenID_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV38Insert_CpjConTipoID) )
         {
            A270CpjConTipoID = AV38Insert_CpjConTipoID;
            AssignAttri("", false, "A270CpjConTipoID", StringUtil.LTrimStr( (decimal)(A270CpjConTipoID), 9, 0));
         }
         else
         {
            A270CpjConTipoID = AV40ComboCpjConTipoID;
            AssignAttri("", false, "A270CpjConTipoID", StringUtil.LTrimStr( (decimal)(A270CpjConTipoID), 9, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV39Insert_CpjConGenID) )
         {
            A279CpjConGenID = AV39Insert_CpjConGenID;
            AssignAttri("", false, "A279CpjConGenID", StringUtil.LTrimStr( (decimal)(A279CpjConGenID), 9, 0));
         }
         else
         {
            A279CpjConGenID = AV42ComboCpjConGenID;
            AssignAttri("", false, "A279CpjConGenID", StringUtil.LTrimStr( (decimal)(A279CpjConGenID), 9, 0));
         }
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
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T00104 */
            pr_default.execute(2, new Object[] {A158CliID});
            A159CliMatricula = T00104_A159CliMatricula[0];
            A160CliNomeFamiliar = T00104_A160CliNomeFamiliar[0];
            pr_default.close(2);
            /* Using cursor T00106 */
            pr_default.execute(4, new Object[] {A158CliID, A166CpjID});
            ZM1032( 42) ;
            A268CpjUltConSeq = T00106_A268CpjUltConSeq[0];
            n268CpjUltConSeq = T00106_n268CpjUltConSeq[0];
            A170CpjNomeFan = T00106_A170CpjNomeFan[0];
            A171CpjRazaoSoc = T00106_A171CpjRazaoSoc[0];
            A176CpjMatricula = T00106_A176CpjMatricula[0];
            AssignAttri("", false, "A176CpjMatricula", StringUtil.LTrimStr( (decimal)(A176CpjMatricula), 12, 0));
            A187CpjCNPJ = T00106_A187CpjCNPJ[0];
            AssignAttri("", false, "A187CpjCNPJ", StringUtil.LTrimStr( (decimal)(A187CpjCNPJ), 14, 0));
            A188CpjCNPJFormat = T00106_A188CpjCNPJFormat[0];
            A189CpjIE = T00106_A189CpjIE[0];
            A207CpjAtivo = T00106_A207CpjAtivo[0];
            AssignAttri("", false, "A207CpjAtivo", A207CpjAtivo);
            A261CpjTelNum = T00106_A261CpjTelNum[0];
            n261CpjTelNum = T00106_n261CpjTelNum[0];
            AssignAttri("", false, "A261CpjTelNum", A261CpjTelNum);
            A262CpjTelRam = T00106_A262CpjTelRam[0];
            n262CpjTelRam = T00106_n262CpjTelRam[0];
            AssignAttri("", false, "A262CpjTelRam", A262CpjTelRam);
            A263CpjCelNum = T00106_A263CpjCelNum[0];
            n263CpjCelNum = T00106_n263CpjCelNum[0];
            AssignAttri("", false, "A263CpjCelNum", A263CpjCelNum);
            A264CpjWppNum = T00106_A264CpjWppNum[0];
            n264CpjWppNum = T00106_n264CpjWppNum[0];
            AssignAttri("", false, "A264CpjWppNum", A264CpjWppNum);
            A265CpjWebsite = T00106_A265CpjWebsite[0];
            n265CpjWebsite = T00106_n265CpjWebsite[0];
            AssignAttri("", false, "A265CpjWebsite", A265CpjWebsite);
            A266CpjEmail = T00106_A266CpjEmail[0];
            n266CpjEmail = T00106_n266CpjEmail[0];
            AssignAttri("", false, "A266CpjEmail", A266CpjEmail);
            A365CpjTipoId = T00106_A365CpjTipoId[0];
            AssignAttri("", false, "A365CpjTipoId", StringUtil.LTrimStr( (decimal)(A365CpjTipoId), 9, 0));
            O268CpjUltConSeq = A268CpjUltConSeq;
            n268CpjUltConSeq = false;
            AssignAttri("", false, "A268CpjUltConSeq", StringUtil.LTrimStr( (decimal)(A268CpjUltConSeq), 4, 0));
            pr_default.close(4);
            /* Using cursor T00109 */
            pr_default.execute(7, new Object[] {A365CpjTipoId});
            A366CpjTipoSigla = T00109_A366CpjTipoSigla[0];
            A367CpjTipoNome = T00109_A367CpjTipoNome[0];
            pr_default.close(7);
            /* Using cursor T00107 */
            pr_default.execute(5, new Object[] {A270CpjConTipoID});
            A271CpjConTipoSigla = T00107_A271CpjConTipoSigla[0];
            AssignAttri("", false, "A271CpjConTipoSigla", A271CpjConTipoSigla);
            A272CpjConTipoNome = T00107_A272CpjConTipoNome[0];
            pr_default.close(5);
            /* Using cursor T00108 */
            pr_default.execute(6, new Object[] {A279CpjConGenID});
            A280CpjConGenSigla = T00108_A280CpjConGenSigla[0];
            A281CpjConGenNome = T00108_A281CpjConGenNome[0];
            pr_default.close(6);
         }
      }

      protected void Load1032( )
      {
         /* Using cursor T001010 */
         pr_default.execute(8, new Object[] {A158CliID, A166CpjID, A269CpjConSeq});
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound32 = 1;
            A268CpjUltConSeq = T001010_A268CpjUltConSeq[0];
            n268CpjUltConSeq = T001010_n268CpjUltConSeq[0];
            A549CpjConDelDataHora = T001010_A549CpjConDelDataHora[0];
            n549CpjConDelDataHora = T001010_n549CpjConDelDataHora[0];
            A550CpjConDelData = T001010_A550CpjConDelData[0];
            n550CpjConDelData = T001010_n550CpjConDelData[0];
            A551CpjConDelHora = T001010_A551CpjConDelHora[0];
            n551CpjConDelHora = T001010_n551CpjConDelHora[0];
            A552CpjConDelUsuId = T001010_A552CpjConDelUsuId[0];
            n552CpjConDelUsuId = T001010_n552CpjConDelUsuId[0];
            A553CpjConDelUsuNome = T001010_A553CpjConDelUsuNome[0];
            n553CpjConDelUsuNome = T001010_n553CpjConDelUsuNome[0];
            A159CliMatricula = T001010_A159CliMatricula[0];
            A160CliNomeFamiliar = T001010_A160CliNomeFamiliar[0];
            A366CpjTipoSigla = T001010_A366CpjTipoSigla[0];
            A367CpjTipoNome = T001010_A367CpjTipoNome[0];
            A170CpjNomeFan = T001010_A170CpjNomeFan[0];
            A171CpjRazaoSoc = T001010_A171CpjRazaoSoc[0];
            A176CpjMatricula = T001010_A176CpjMatricula[0];
            AssignAttri("", false, "A176CpjMatricula", StringUtil.LTrimStr( (decimal)(A176CpjMatricula), 12, 0));
            A187CpjCNPJ = T001010_A187CpjCNPJ[0];
            AssignAttri("", false, "A187CpjCNPJ", StringUtil.LTrimStr( (decimal)(A187CpjCNPJ), 14, 0));
            A188CpjCNPJFormat = T001010_A188CpjCNPJFormat[0];
            A189CpjIE = T001010_A189CpjIE[0];
            A207CpjAtivo = T001010_A207CpjAtivo[0];
            AssignAttri("", false, "A207CpjAtivo", A207CpjAtivo);
            A261CpjTelNum = T001010_A261CpjTelNum[0];
            n261CpjTelNum = T001010_n261CpjTelNum[0];
            AssignAttri("", false, "A261CpjTelNum", A261CpjTelNum);
            A262CpjTelRam = T001010_A262CpjTelRam[0];
            n262CpjTelRam = T001010_n262CpjTelRam[0];
            AssignAttri("", false, "A262CpjTelRam", A262CpjTelRam);
            A263CpjCelNum = T001010_A263CpjCelNum[0];
            n263CpjCelNum = T001010_n263CpjCelNum[0];
            AssignAttri("", false, "A263CpjCelNum", A263CpjCelNum);
            A264CpjWppNum = T001010_A264CpjWppNum[0];
            n264CpjWppNum = T001010_n264CpjWppNum[0];
            AssignAttri("", false, "A264CpjWppNum", A264CpjWppNum);
            A265CpjWebsite = T001010_A265CpjWebsite[0];
            n265CpjWebsite = T001010_n265CpjWebsite[0];
            AssignAttri("", false, "A265CpjWebsite", A265CpjWebsite);
            A266CpjEmail = T001010_A266CpjEmail[0];
            n266CpjEmail = T001010_n266CpjEmail[0];
            AssignAttri("", false, "A266CpjEmail", A266CpjEmail);
            A271CpjConTipoSigla = T001010_A271CpjConTipoSigla[0];
            AssignAttri("", false, "A271CpjConTipoSigla", A271CpjConTipoSigla);
            A272CpjConTipoNome = T001010_A272CpjConTipoNome[0];
            A273CpjConCPF = T001010_A273CpjConCPF[0];
            AssignAttri("", false, "A273CpjConCPF", StringUtil.LTrimStr( (decimal)(A273CpjConCPF), 11, 0));
            A274CpjConCPFFormat = T001010_A274CpjConCPFFormat[0];
            AssignAttri("", false, "A274CpjConCPFFormat", A274CpjConCPFFormat);
            A275CpjConNome = T001010_A275CpjConNome[0];
            AssignAttri("", false, "A275CpjConNome", A275CpjConNome);
            A276CpjConNomePrim = T001010_A276CpjConNomePrim[0];
            AssignAttri("", false, "A276CpjConNomePrim", A276CpjConNomePrim);
            A277CpjConSobrenome = T001010_A277CpjConSobrenome[0];
            AssignAttri("", false, "A277CpjConSobrenome", A277CpjConSobrenome);
            A278CpjNomeSocial = T001010_A278CpjNomeSocial[0];
            AssignAttri("", false, "A278CpjNomeSocial", A278CpjNomeSocial);
            A280CpjConGenSigla = T001010_A280CpjConGenSigla[0];
            A281CpjConGenNome = T001010_A281CpjConGenNome[0];
            A282CpjConNascimento = T001010_A282CpjConNascimento[0];
            AssignAttri("", false, "A282CpjConNascimento", context.localUtil.Format(A282CpjConNascimento, "99/99/99"));
            A283CpjConTelNum = T001010_A283CpjConTelNum[0];
            n283CpjConTelNum = T001010_n283CpjConTelNum[0];
            AssignAttri("", false, "A283CpjConTelNum", A283CpjConTelNum);
            A284CpjConTelRam = T001010_A284CpjConTelRam[0];
            n284CpjConTelRam = T001010_n284CpjConTelRam[0];
            AssignAttri("", false, "A284CpjConTelRam", A284CpjConTelRam);
            A285CpjConCelNum = T001010_A285CpjConCelNum[0];
            n285CpjConCelNum = T001010_n285CpjConCelNum[0];
            AssignAttri("", false, "A285CpjConCelNum", A285CpjConCelNum);
            A286CpjConWppNum = T001010_A286CpjConWppNum[0];
            n286CpjConWppNum = T001010_n286CpjConWppNum[0];
            AssignAttri("", false, "A286CpjConWppNum", A286CpjConWppNum);
            A287CpjConEmail = T001010_A287CpjConEmail[0];
            n287CpjConEmail = T001010_n287CpjConEmail[0];
            AssignAttri("", false, "A287CpjConEmail", A287CpjConEmail);
            A288CpjConLIn = T001010_A288CpjConLIn[0];
            n288CpjConLIn = T001010_n288CpjConLIn[0];
            AssignAttri("", false, "A288CpjConLIn", A288CpjConLIn);
            A328CpjConUltEnd = T001010_A328CpjConUltEnd[0];
            n328CpjConUltEnd = T001010_n328CpjConUltEnd[0];
            AssignAttri("", false, "A328CpjConUltEnd", StringUtil.LTrimStr( (decimal)(A328CpjConUltEnd), 4, 0));
            A548CpjConDel = T001010_A548CpjConDel[0];
            A270CpjConTipoID = T001010_A270CpjConTipoID[0];
            AssignAttri("", false, "A270CpjConTipoID", StringUtil.LTrimStr( (decimal)(A270CpjConTipoID), 9, 0));
            A279CpjConGenID = T001010_A279CpjConGenID[0];
            AssignAttri("", false, "A279CpjConGenID", StringUtil.LTrimStr( (decimal)(A279CpjConGenID), 9, 0));
            A365CpjTipoId = T001010_A365CpjTipoId[0];
            AssignAttri("", false, "A365CpjTipoId", StringUtil.LTrimStr( (decimal)(A365CpjTipoId), 9, 0));
            ZM1032( -39) ;
         }
         pr_default.close(8);
         OnLoadActions1032( ) ;
      }

      protected void OnLoadActions1032( )
      {
         O268CpjUltConSeq = A268CpjUltConSeq;
         n268CpjUltConSeq = false;
         AssignAttri("", false, "A268CpjUltConSeq", StringUtil.LTrimStr( (decimal)(A268CpjUltConSeq), 4, 0));
         if ( IsIns( )  )
         {
            A268CpjUltConSeq = (short)(O268CpjUltConSeq+1);
            n268CpjUltConSeq = false;
            AssignAttri("", false, "A268CpjUltConSeq", StringUtil.LTrimStr( (decimal)(A268CpjUltConSeq), 4, 0));
         }
         /* Using cursor T00107 */
         pr_default.execute(5, new Object[] {A270CpjConTipoID});
         A271CpjConTipoSigla = T00107_A271CpjConTipoSigla[0];
         AssignAttri("", false, "A271CpjConTipoSigla", A271CpjConTipoSigla);
         A272CpjConTipoNome = T00107_A272CpjConTipoNome[0];
         pr_default.close(5);
         /* Using cursor T00108 */
         pr_default.execute(6, new Object[] {A279CpjConGenID});
         A280CpjConGenSigla = T00108_A280CpjConGenSigla[0];
         A281CpjConGenNome = T00108_A281CpjConGenNome[0];
         pr_default.close(6);
         if ( ! (0==AV37CpjConSeq) )
         {
            A269CpjConSeq = AV37CpjConSeq;
            AssignAttri("", false, "A269CpjConSeq", StringUtil.LTrimStr( (decimal)(A269CpjConSeq), 4, 0));
         }
         else
         {
            if ( IsIns( )  && ( Gx_BScreen == 1 ) )
            {
               A269CpjConSeq = A268CpjUltConSeq;
               AssignAttri("", false, "A269CpjConSeq", StringUtil.LTrimStr( (decimal)(A269CpjConSeq), 4, 0));
            }
         }
      }

      protected void CheckExtendedTable1032( )
      {
         nIsDirty_32 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T00104 */
         pr_default.execute(2, new Object[] {A158CliID});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("Não existe ''.", "ForeignKeyNotFound", 1, "CLIID");
            AnyError = 1;
            GX_FocusControl = edtCliID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A159CliMatricula = T00104_A159CliMatricula[0];
         A160CliNomeFamiliar = T00104_A160CliNomeFamiliar[0];
         pr_default.close(2);
         /* Using cursor T00106 */
         pr_default.execute(4, new Object[] {A158CliID, A166CpjID});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("Não existe ''.", "ForeignKeyNotFound", 1, "CPJID");
            AnyError = 1;
            GX_FocusControl = edtCliID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A268CpjUltConSeq = T00106_A268CpjUltConSeq[0];
         n268CpjUltConSeq = T00106_n268CpjUltConSeq[0];
         A170CpjNomeFan = T00106_A170CpjNomeFan[0];
         A171CpjRazaoSoc = T00106_A171CpjRazaoSoc[0];
         A176CpjMatricula = T00106_A176CpjMatricula[0];
         AssignAttri("", false, "A176CpjMatricula", StringUtil.LTrimStr( (decimal)(A176CpjMatricula), 12, 0));
         A187CpjCNPJ = T00106_A187CpjCNPJ[0];
         AssignAttri("", false, "A187CpjCNPJ", StringUtil.LTrimStr( (decimal)(A187CpjCNPJ), 14, 0));
         A188CpjCNPJFormat = T00106_A188CpjCNPJFormat[0];
         A189CpjIE = T00106_A189CpjIE[0];
         A207CpjAtivo = T00106_A207CpjAtivo[0];
         AssignAttri("", false, "A207CpjAtivo", A207CpjAtivo);
         A261CpjTelNum = T00106_A261CpjTelNum[0];
         n261CpjTelNum = T00106_n261CpjTelNum[0];
         AssignAttri("", false, "A261CpjTelNum", A261CpjTelNum);
         A262CpjTelRam = T00106_A262CpjTelRam[0];
         n262CpjTelRam = T00106_n262CpjTelRam[0];
         AssignAttri("", false, "A262CpjTelRam", A262CpjTelRam);
         A263CpjCelNum = T00106_A263CpjCelNum[0];
         n263CpjCelNum = T00106_n263CpjCelNum[0];
         AssignAttri("", false, "A263CpjCelNum", A263CpjCelNum);
         A264CpjWppNum = T00106_A264CpjWppNum[0];
         n264CpjWppNum = T00106_n264CpjWppNum[0];
         AssignAttri("", false, "A264CpjWppNum", A264CpjWppNum);
         A265CpjWebsite = T00106_A265CpjWebsite[0];
         n265CpjWebsite = T00106_n265CpjWebsite[0];
         AssignAttri("", false, "A265CpjWebsite", A265CpjWebsite);
         A266CpjEmail = T00106_A266CpjEmail[0];
         n266CpjEmail = T00106_n266CpjEmail[0];
         AssignAttri("", false, "A266CpjEmail", A266CpjEmail);
         A365CpjTipoId = T00106_A365CpjTipoId[0];
         AssignAttri("", false, "A365CpjTipoId", StringUtil.LTrimStr( (decimal)(A365CpjTipoId), 9, 0));
         nIsDirty_32 = 1;
         O268CpjUltConSeq = A268CpjUltConSeq;
         n268CpjUltConSeq = false;
         AssignAttri("", false, "A268CpjUltConSeq", StringUtil.LTrimStr( (decimal)(A268CpjUltConSeq), 4, 0));
         pr_default.close(4);
         if ( IsIns( )  )
         {
            nIsDirty_32 = 1;
            A268CpjUltConSeq = (short)(O268CpjUltConSeq+1);
            n268CpjUltConSeq = false;
            AssignAttri("", false, "A268CpjUltConSeq", StringUtil.LTrimStr( (decimal)(A268CpjUltConSeq), 4, 0));
         }
         /* Using cursor T00109 */
         pr_default.execute(7, new Object[] {A365CpjTipoId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem("Não existe 'Cliente PJ -> Cliente PJ Tipo'.", "ForeignKeyNotFound", 1, "CPJTIPOID");
            AnyError = 1;
         }
         A366CpjTipoSigla = T00109_A366CpjTipoSigla[0];
         A367CpjTipoNome = T00109_A367CpjTipoNome[0];
         pr_default.close(7);
         /* Using cursor T001011 */
         pr_default.execute(9, new Object[] {A158CliID, A166CpjID, A273CpjConCPF, A269CpjConSeq});
         if ( (pr_default.getStatus(9) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"ID"+","+"ID"+","+"CPF"}), 1, "CLIID");
            AnyError = 1;
            GX_FocusControl = edtCliID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(9);
         /* Using cursor T00107 */
         pr_default.execute(5, new Object[] {A270CpjConTipoID});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("Não existe 'Tipo Cliente PJ -> Contato Cliente PJ'.", "ForeignKeyNotFound", 1, "CPJCONTIPOID");
            AnyError = 1;
            GX_FocusControl = edtCpjConTipoID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A271CpjConTipoSigla = T00107_A271CpjConTipoSigla[0];
         AssignAttri("", false, "A271CpjConTipoSigla", A271CpjConTipoSigla);
         A272CpjConTipoNome = T00107_A272CpjConTipoNome[0];
         pr_default.close(5);
         if ( (0==A270CpjConTipoID) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Tipo do Contato", "", "", "", "", "", "", "", ""), 1, "CPJCONTIPOID");
            AnyError = 1;
            GX_FocusControl = edtCpjConTipoID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A274CpjConCPFFormat)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "CPF Formatado", "", "", "", "", "", "", "", ""), 1, "CPJCONCPFFORMAT");
            AnyError = 1;
            GX_FocusControl = edtCpjConCPFFormat_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A275CpjConNome)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Nome Completo do Contato", "", "", "", "", "", "", "", ""), 1, "CPJCONNOME");
            AnyError = 1;
            GX_FocusControl = edtCpjConNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A278CpjNomeSocial)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Nome Social", "", "", "", "", "", "", "", ""), 1, "CPJNOMESOCIAL");
            AnyError = 1;
            GX_FocusControl = edtCpjNomeSocial_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00108 */
         pr_default.execute(6, new Object[] {A279CpjConGenID});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("Não existe 'Genero -> Contato Cliente PJ'.", "ForeignKeyNotFound", 1, "CPJCONGENID");
            AnyError = 1;
            GX_FocusControl = edtCpjConGenID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A280CpjConGenSigla = T00108_A280CpjConGenSigla[0];
         A281CpjConGenNome = T00108_A281CpjConGenNome[0];
         pr_default.close(6);
         if ( (0==A279CpjConGenID) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Gênero ID", "", "", "", "", "", "", "", ""), 1, "CPJCONGENID");
            AnyError = 1;
            GX_FocusControl = edtCpjConGenID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( (DateTime.MinValue==A282CpjConNascimento) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Data de Nascimento", "", "", "", "", "", "", "", ""), 1, "CPJCONNASCIMENTO");
            AnyError = 1;
            GX_FocusControl = edtCpjConNascimento_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A285CpjConCelNum)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Celular", "", "", "", "", "", "", "", ""), 1, "CPJCONCELNUM");
            AnyError = 1;
            GX_FocusControl = edtCpjConCelNum_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( GxRegex.IsMatch(A287CpjConEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") || String.IsNullOrEmpty(StringUtil.RTrim( A287CpjConEmail)) ) )
         {
            GX_msglist.addItem("O valor de E-mail não coincide com o padrão especificado", "OutOfRange", 1, "CPJCONEMAIL");
            AnyError = 1;
            GX_FocusControl = edtCpjConEmail_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( GxRegex.IsMatch(A288CpjConLIn,"^((?:[a-zA-Z]+:(//)?)?((?:(?:[a-zA-Z]([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*)(?:\\.(?:([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*))*)|(?:(\\d{1,3}\\.){3}\\d{1,3}))(?::\\d+)?(?:/([a-zA-Z0-9$\\-_@.&+!*\"'(),=;: ]|%[0-9a-fA-F]{2})+)*/?(?:[#?](?:[a-zA-Z0-9$\\-_@.&+!*\"'(),=;: /]|%[0-9a-fA-F]{2})*)?)?\\s*$") || String.IsNullOrEmpty(StringUtil.RTrim( A288CpjConLIn)) ) )
         {
            GX_msglist.addItem("O valor de LinkedIn não coincide com o padrão especificado", "OutOfRange", 1, "CPJCONLIN");
            AnyError = 1;
            GX_FocusControl = edtCpjConLIn_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! (0==AV37CpjConSeq) )
         {
            nIsDirty_32 = 1;
            A269CpjConSeq = AV37CpjConSeq;
            AssignAttri("", false, "A269CpjConSeq", StringUtil.LTrimStr( (decimal)(A269CpjConSeq), 4, 0));
         }
         else
         {
            if ( IsIns( )  && ( Gx_BScreen == 1 ) )
            {
               nIsDirty_32 = 1;
               A269CpjConSeq = A268CpjUltConSeq;
               AssignAttri("", false, "A269CpjConSeq", StringUtil.LTrimStr( (decimal)(A269CpjConSeq), 4, 0));
            }
         }
      }

      protected void CloseExtendedTableCursors1032( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(7);
         pr_default.close(5);
         pr_default.close(6);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_41( Guid A158CliID )
      {
         /* Using cursor T001012 */
         pr_default.execute(10, new Object[] {A158CliID});
         if ( (pr_default.getStatus(10) == 101) )
         {
            GX_msglist.addItem("Não existe ''.", "ForeignKeyNotFound", 1, "CLIID");
            AnyError = 1;
            GX_FocusControl = edtCliID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A159CliMatricula = T001012_A159CliMatricula[0];
         A160CliNomeFamiliar = T001012_A160CliNomeFamiliar[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A159CliMatricula), 12, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( A160CliNomeFamiliar)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(10) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(10);
      }

      protected void gxLoad_42( Guid A158CliID ,
                                Guid A166CpjID )
      {
         /* Using cursor T00106 */
         pr_default.execute(4, new Object[] {A158CliID, A166CpjID});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("Não existe ''.", "ForeignKeyNotFound", 1, "CPJID");
            AnyError = 1;
            GX_FocusControl = edtCliID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A268CpjUltConSeq = T00106_A268CpjUltConSeq[0];
         n268CpjUltConSeq = T00106_n268CpjUltConSeq[0];
         A170CpjNomeFan = T00106_A170CpjNomeFan[0];
         A171CpjRazaoSoc = T00106_A171CpjRazaoSoc[0];
         A176CpjMatricula = T00106_A176CpjMatricula[0];
         AssignAttri("", false, "A176CpjMatricula", StringUtil.LTrimStr( (decimal)(A176CpjMatricula), 12, 0));
         A187CpjCNPJ = T00106_A187CpjCNPJ[0];
         AssignAttri("", false, "A187CpjCNPJ", StringUtil.LTrimStr( (decimal)(A187CpjCNPJ), 14, 0));
         A188CpjCNPJFormat = T00106_A188CpjCNPJFormat[0];
         A189CpjIE = T00106_A189CpjIE[0];
         A207CpjAtivo = T00106_A207CpjAtivo[0];
         AssignAttri("", false, "A207CpjAtivo", A207CpjAtivo);
         A261CpjTelNum = T00106_A261CpjTelNum[0];
         n261CpjTelNum = T00106_n261CpjTelNum[0];
         AssignAttri("", false, "A261CpjTelNum", A261CpjTelNum);
         A262CpjTelRam = T00106_A262CpjTelRam[0];
         n262CpjTelRam = T00106_n262CpjTelRam[0];
         AssignAttri("", false, "A262CpjTelRam", A262CpjTelRam);
         A263CpjCelNum = T00106_A263CpjCelNum[0];
         n263CpjCelNum = T00106_n263CpjCelNum[0];
         AssignAttri("", false, "A263CpjCelNum", A263CpjCelNum);
         A264CpjWppNum = T00106_A264CpjWppNum[0];
         n264CpjWppNum = T00106_n264CpjWppNum[0];
         AssignAttri("", false, "A264CpjWppNum", A264CpjWppNum);
         A265CpjWebsite = T00106_A265CpjWebsite[0];
         n265CpjWebsite = T00106_n265CpjWebsite[0];
         AssignAttri("", false, "A265CpjWebsite", A265CpjWebsite);
         A266CpjEmail = T00106_A266CpjEmail[0];
         n266CpjEmail = T00106_n266CpjEmail[0];
         AssignAttri("", false, "A266CpjEmail", A266CpjEmail);
         A365CpjTipoId = T00106_A365CpjTipoId[0];
         AssignAttri("", false, "A365CpjTipoId", StringUtil.LTrimStr( (decimal)(A365CpjTipoId), 9, 0));
         O268CpjUltConSeq = A268CpjUltConSeq;
         n268CpjUltConSeq = false;
         AssignAttri("", false, "A268CpjUltConSeq", StringUtil.LTrimStr( (decimal)(A268CpjUltConSeq), 4, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A268CpjUltConSeq), 4, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( A170CpjNomeFan)+"\""+","+"\""+GXUtil.EncodeJSConstant( A171CpjRazaoSoc)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A176CpjMatricula), 12, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A187CpjCNPJ), 14, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( A188CpjCNPJFormat)+"\""+","+"\""+GXUtil.EncodeJSConstant( A189CpjIE)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.BoolToStr( A207CpjAtivo))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A261CpjTelNum))+"\""+","+"\""+GXUtil.EncodeJSConstant( A262CpjTelRam)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A263CpjCelNum))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A264CpjWppNum))+"\""+","+"\""+GXUtil.EncodeJSConstant( A265CpjWebsite)+"\""+","+"\""+GXUtil.EncodeJSConstant( A266CpjEmail)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A365CpjTipoId), 9, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void gxLoad_45( int A365CpjTipoId )
      {
         /* Using cursor T001013 */
         pr_default.execute(11, new Object[] {A365CpjTipoId});
         if ( (pr_default.getStatus(11) == 101) )
         {
            GX_msglist.addItem("Não existe 'Cliente PJ -> Cliente PJ Tipo'.", "ForeignKeyNotFound", 1, "CPJTIPOID");
            AnyError = 1;
         }
         A366CpjTipoSigla = T001013_A366CpjTipoSigla[0];
         A367CpjTipoNome = T001013_A367CpjTipoNome[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A366CpjTipoSigla)+"\""+","+"\""+GXUtil.EncodeJSConstant( A367CpjTipoNome)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(11) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(11);
      }

      protected void gxLoad_43( int A270CpjConTipoID )
      {
         /* Using cursor T001014 */
         pr_default.execute(12, new Object[] {A270CpjConTipoID});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem("Não existe 'Tipo Cliente PJ -> Contato Cliente PJ'.", "ForeignKeyNotFound", 1, "CPJCONTIPOID");
            AnyError = 1;
            GX_FocusControl = edtCpjConTipoID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A271CpjConTipoSigla = T001014_A271CpjConTipoSigla[0];
         AssignAttri("", false, "A271CpjConTipoSigla", A271CpjConTipoSigla);
         A272CpjConTipoNome = T001014_A272CpjConTipoNome[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A271CpjConTipoSigla)+"\""+","+"\""+GXUtil.EncodeJSConstant( A272CpjConTipoNome)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(12) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(12);
      }

      protected void gxLoad_44( int A279CpjConGenID )
      {
         /* Using cursor T001015 */
         pr_default.execute(13, new Object[] {A279CpjConGenID});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("Não existe 'Genero -> Contato Cliente PJ'.", "ForeignKeyNotFound", 1, "CPJCONGENID");
            AnyError = 1;
            GX_FocusControl = edtCpjConGenID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A280CpjConGenSigla = T001015_A280CpjConGenSigla[0];
         A281CpjConGenNome = T001015_A281CpjConGenNome[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A280CpjConGenSigla)+"\""+","+"\""+GXUtil.EncodeJSConstant( A281CpjConGenNome)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(13) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(13);
      }

      protected void GetKey1032( )
      {
         /* Using cursor T001016 */
         pr_default.execute(14, new Object[] {A158CliID, A166CpjID, A269CpjConSeq});
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound32 = 1;
         }
         else
         {
            RcdFound32 = 0;
         }
         pr_default.close(14);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00103 */
         pr_default.execute(1, new Object[] {A158CliID, A166CpjID, A269CpjConSeq});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1032( 39) ;
            RcdFound32 = 1;
            A269CpjConSeq = T00103_A269CpjConSeq[0];
            AssignAttri("", false, "A269CpjConSeq", StringUtil.LTrimStr( (decimal)(A269CpjConSeq), 4, 0));
            A549CpjConDelDataHora = T00103_A549CpjConDelDataHora[0];
            n549CpjConDelDataHora = T00103_n549CpjConDelDataHora[0];
            A550CpjConDelData = T00103_A550CpjConDelData[0];
            n550CpjConDelData = T00103_n550CpjConDelData[0];
            A551CpjConDelHora = T00103_A551CpjConDelHora[0];
            n551CpjConDelHora = T00103_n551CpjConDelHora[0];
            A552CpjConDelUsuId = T00103_A552CpjConDelUsuId[0];
            n552CpjConDelUsuId = T00103_n552CpjConDelUsuId[0];
            A553CpjConDelUsuNome = T00103_A553CpjConDelUsuNome[0];
            n553CpjConDelUsuNome = T00103_n553CpjConDelUsuNome[0];
            A273CpjConCPF = T00103_A273CpjConCPF[0];
            AssignAttri("", false, "A273CpjConCPF", StringUtil.LTrimStr( (decimal)(A273CpjConCPF), 11, 0));
            A274CpjConCPFFormat = T00103_A274CpjConCPFFormat[0];
            AssignAttri("", false, "A274CpjConCPFFormat", A274CpjConCPFFormat);
            A275CpjConNome = T00103_A275CpjConNome[0];
            AssignAttri("", false, "A275CpjConNome", A275CpjConNome);
            A276CpjConNomePrim = T00103_A276CpjConNomePrim[0];
            AssignAttri("", false, "A276CpjConNomePrim", A276CpjConNomePrim);
            A277CpjConSobrenome = T00103_A277CpjConSobrenome[0];
            AssignAttri("", false, "A277CpjConSobrenome", A277CpjConSobrenome);
            A278CpjNomeSocial = T00103_A278CpjNomeSocial[0];
            AssignAttri("", false, "A278CpjNomeSocial", A278CpjNomeSocial);
            A282CpjConNascimento = T00103_A282CpjConNascimento[0];
            AssignAttri("", false, "A282CpjConNascimento", context.localUtil.Format(A282CpjConNascimento, "99/99/99"));
            A283CpjConTelNum = T00103_A283CpjConTelNum[0];
            n283CpjConTelNum = T00103_n283CpjConTelNum[0];
            AssignAttri("", false, "A283CpjConTelNum", A283CpjConTelNum);
            A284CpjConTelRam = T00103_A284CpjConTelRam[0];
            n284CpjConTelRam = T00103_n284CpjConTelRam[0];
            AssignAttri("", false, "A284CpjConTelRam", A284CpjConTelRam);
            A285CpjConCelNum = T00103_A285CpjConCelNum[0];
            n285CpjConCelNum = T00103_n285CpjConCelNum[0];
            AssignAttri("", false, "A285CpjConCelNum", A285CpjConCelNum);
            A286CpjConWppNum = T00103_A286CpjConWppNum[0];
            n286CpjConWppNum = T00103_n286CpjConWppNum[0];
            AssignAttri("", false, "A286CpjConWppNum", A286CpjConWppNum);
            A287CpjConEmail = T00103_A287CpjConEmail[0];
            n287CpjConEmail = T00103_n287CpjConEmail[0];
            AssignAttri("", false, "A287CpjConEmail", A287CpjConEmail);
            A288CpjConLIn = T00103_A288CpjConLIn[0];
            n288CpjConLIn = T00103_n288CpjConLIn[0];
            AssignAttri("", false, "A288CpjConLIn", A288CpjConLIn);
            A328CpjConUltEnd = T00103_A328CpjConUltEnd[0];
            n328CpjConUltEnd = T00103_n328CpjConUltEnd[0];
            AssignAttri("", false, "A328CpjConUltEnd", StringUtil.LTrimStr( (decimal)(A328CpjConUltEnd), 4, 0));
            A548CpjConDel = T00103_A548CpjConDel[0];
            A158CliID = T00103_A158CliID[0];
            AssignAttri("", false, "A158CliID", A158CliID.ToString());
            A166CpjID = T00103_A166CpjID[0];
            AssignAttri("", false, "A166CpjID", A166CpjID.ToString());
            A270CpjConTipoID = T00103_A270CpjConTipoID[0];
            AssignAttri("", false, "A270CpjConTipoID", StringUtil.LTrimStr( (decimal)(A270CpjConTipoID), 9, 0));
            A279CpjConGenID = T00103_A279CpjConGenID[0];
            AssignAttri("", false, "A279CpjConGenID", StringUtil.LTrimStr( (decimal)(A279CpjConGenID), 9, 0));
            O548CpjConDel = A548CpjConDel;
            AssignAttri("", false, "A548CpjConDel", A548CpjConDel);
            Z158CliID = A158CliID;
            Z166CpjID = A166CpjID;
            Z269CpjConSeq = A269CpjConSeq;
            sMode32 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load1032( ) ;
            if ( AnyError == 1 )
            {
               RcdFound32 = 0;
               InitializeNonKey1032( ) ;
            }
            Gx_mode = sMode32;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound32 = 0;
            InitializeNonKey1032( ) ;
            sMode32 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode32;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1032( ) ;
         if ( RcdFound32 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound32 = 0;
         /* Using cursor T001017 */
         pr_default.execute(15, new Object[] {A158CliID, A166CpjID, A269CpjConSeq});
         if ( (pr_default.getStatus(15) != 101) )
         {
            while ( (pr_default.getStatus(15) != 101) && ( ( GuidUtil.Compare(T001017_A158CliID[0], A158CliID, 0) < 0 ) || ( T001017_A158CliID[0] == A158CliID ) && ( GuidUtil.Compare(T001017_A166CpjID[0], A166CpjID, 0) < 0 ) || ( T001017_A166CpjID[0] == A166CpjID ) && ( T001017_A158CliID[0] == A158CliID ) && ( T001017_A269CpjConSeq[0] < A269CpjConSeq ) ) )
            {
               pr_default.readNext(15);
            }
            if ( (pr_default.getStatus(15) != 101) && ( ( GuidUtil.Compare(T001017_A158CliID[0], A158CliID, 0) > 0 ) || ( T001017_A158CliID[0] == A158CliID ) && ( GuidUtil.Compare(T001017_A166CpjID[0], A166CpjID, 0) > 0 ) || ( T001017_A166CpjID[0] == A166CpjID ) && ( T001017_A158CliID[0] == A158CliID ) && ( T001017_A269CpjConSeq[0] > A269CpjConSeq ) ) )
            {
               A158CliID = T001017_A158CliID[0];
               AssignAttri("", false, "A158CliID", A158CliID.ToString());
               A166CpjID = T001017_A166CpjID[0];
               AssignAttri("", false, "A166CpjID", A166CpjID.ToString());
               A269CpjConSeq = T001017_A269CpjConSeq[0];
               AssignAttri("", false, "A269CpjConSeq", StringUtil.LTrimStr( (decimal)(A269CpjConSeq), 4, 0));
               RcdFound32 = 1;
            }
         }
         pr_default.close(15);
      }

      protected void move_previous( )
      {
         RcdFound32 = 0;
         /* Using cursor T001018 */
         pr_default.execute(16, new Object[] {A158CliID, A166CpjID, A269CpjConSeq});
         if ( (pr_default.getStatus(16) != 101) )
         {
            while ( (pr_default.getStatus(16) != 101) && ( ( GuidUtil.Compare(T001018_A158CliID[0], A158CliID, 0) > 0 ) || ( T001018_A158CliID[0] == A158CliID ) && ( GuidUtil.Compare(T001018_A166CpjID[0], A166CpjID, 0) > 0 ) || ( T001018_A166CpjID[0] == A166CpjID ) && ( T001018_A158CliID[0] == A158CliID ) && ( T001018_A269CpjConSeq[0] > A269CpjConSeq ) ) )
            {
               pr_default.readNext(16);
            }
            if ( (pr_default.getStatus(16) != 101) && ( ( GuidUtil.Compare(T001018_A158CliID[0], A158CliID, 0) < 0 ) || ( T001018_A158CliID[0] == A158CliID ) && ( GuidUtil.Compare(T001018_A166CpjID[0], A166CpjID, 0) < 0 ) || ( T001018_A166CpjID[0] == A166CpjID ) && ( T001018_A158CliID[0] == A158CliID ) && ( T001018_A269CpjConSeq[0] < A269CpjConSeq ) ) )
            {
               A158CliID = T001018_A158CliID[0];
               AssignAttri("", false, "A158CliID", A158CliID.ToString());
               A166CpjID = T001018_A166CpjID[0];
               AssignAttri("", false, "A166CpjID", A166CpjID.ToString());
               A269CpjConSeq = T001018_A269CpjConSeq[0];
               AssignAttri("", false, "A269CpjConSeq", StringUtil.LTrimStr( (decimal)(A269CpjConSeq), 4, 0));
               RcdFound32 = 1;
            }
         }
         pr_default.close(16);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1032( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtCpjConTipoID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1032( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound32 == 1 )
            {
               if ( ( A158CliID != Z158CliID ) || ( A166CpjID != Z166CpjID ) || ( A269CpjConSeq != Z269CpjConSeq ) )
               {
                  A158CliID = Z158CliID;
                  AssignAttri("", false, "A158CliID", A158CliID.ToString());
                  A166CpjID = Z166CpjID;
                  AssignAttri("", false, "A166CpjID", A166CpjID.ToString());
                  A269CpjConSeq = Z269CpjConSeq;
                  AssignAttri("", false, "A269CpjConSeq", StringUtil.LTrimStr( (decimal)(A269CpjConSeq), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CLIID");
                  AnyError = 1;
                  GX_FocusControl = edtCliID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtCpjConTipoID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update1032( ) ;
                  GX_FocusControl = edtCpjConTipoID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( A158CliID != Z158CliID ) || ( A166CpjID != Z166CpjID ) || ( A269CpjConSeq != Z269CpjConSeq ) )
               {
                  /* Insert record */
                  GX_FocusControl = edtCpjConTipoID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1032( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CLIID");
                     AnyError = 1;
                     GX_FocusControl = edtCliID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtCpjConTipoID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1032( ) ;
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
         if ( ( A158CliID != Z158CliID ) || ( A166CpjID != Z166CpjID ) || ( A269CpjConSeq != Z269CpjConSeq ) )
         {
            A158CliID = Z158CliID;
            AssignAttri("", false, "A158CliID", A158CliID.ToString());
            A166CpjID = Z166CpjID;
            AssignAttri("", false, "A166CpjID", A166CpjID.ToString());
            A269CpjConSeq = Z269CpjConSeq;
            AssignAttri("", false, "A269CpjConSeq", StringUtil.LTrimStr( (decimal)(A269CpjConSeq), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CLIID");
            AnyError = 1;
            GX_FocusControl = edtCliID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtCpjConTipoID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency1032( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00102 */
            pr_default.execute(0, new Object[] {A158CliID, A166CpjID, A269CpjConSeq});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_clientepj_contato"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z549CpjConDelDataHora != T00102_A549CpjConDelDataHora[0] ) || ( Z550CpjConDelData != T00102_A550CpjConDelData[0] ) || ( Z551CpjConDelHora != T00102_A551CpjConDelHora[0] ) || ( StringUtil.StrCmp(Z552CpjConDelUsuId, T00102_A552CpjConDelUsuId[0]) != 0 ) || ( StringUtil.StrCmp(Z553CpjConDelUsuNome, T00102_A553CpjConDelUsuNome[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z273CpjConCPF != T00102_A273CpjConCPF[0] ) || ( StringUtil.StrCmp(Z274CpjConCPFFormat, T00102_A274CpjConCPFFormat[0]) != 0 ) || ( StringUtil.StrCmp(Z275CpjConNome, T00102_A275CpjConNome[0]) != 0 ) || ( StringUtil.StrCmp(Z276CpjConNomePrim, T00102_A276CpjConNomePrim[0]) != 0 ) || ( StringUtil.StrCmp(Z277CpjConSobrenome, T00102_A277CpjConSobrenome[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z278CpjNomeSocial, T00102_A278CpjNomeSocial[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z282CpjConNascimento ) != DateTimeUtil.ResetTime ( T00102_A282CpjConNascimento[0] ) ) || ( StringUtil.StrCmp(Z283CpjConTelNum, T00102_A283CpjConTelNum[0]) != 0 ) || ( StringUtil.StrCmp(Z284CpjConTelRam, T00102_A284CpjConTelRam[0]) != 0 ) || ( StringUtil.StrCmp(Z285CpjConCelNum, T00102_A285CpjConCelNum[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z286CpjConWppNum, T00102_A286CpjConWppNum[0]) != 0 ) || ( StringUtil.StrCmp(Z287CpjConEmail, T00102_A287CpjConEmail[0]) != 0 ) || ( StringUtil.StrCmp(Z288CpjConLIn, T00102_A288CpjConLIn[0]) != 0 ) || ( Z328CpjConUltEnd != T00102_A328CpjConUltEnd[0] ) || ( Z548CpjConDel != T00102_A548CpjConDel[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z270CpjConTipoID != T00102_A270CpjConTipoID[0] ) || ( Z279CpjConGenID != T00102_A279CpjConGenID[0] ) )
            {
               if ( Z549CpjConDelDataHora != T00102_A549CpjConDelDataHora[0] )
               {
                  GXUtil.WriteLog("core.clientepjcontato:[seudo value changed for attri]"+"CpjConDelDataHora");
                  GXUtil.WriteLogRaw("Old: ",Z549CpjConDelDataHora);
                  GXUtil.WriteLogRaw("Current: ",T00102_A549CpjConDelDataHora[0]);
               }
               if ( Z550CpjConDelData != T00102_A550CpjConDelData[0] )
               {
                  GXUtil.WriteLog("core.clientepjcontato:[seudo value changed for attri]"+"CpjConDelData");
                  GXUtil.WriteLogRaw("Old: ",Z550CpjConDelData);
                  GXUtil.WriteLogRaw("Current: ",T00102_A550CpjConDelData[0]);
               }
               if ( Z551CpjConDelHora != T00102_A551CpjConDelHora[0] )
               {
                  GXUtil.WriteLog("core.clientepjcontato:[seudo value changed for attri]"+"CpjConDelHora");
                  GXUtil.WriteLogRaw("Old: ",Z551CpjConDelHora);
                  GXUtil.WriteLogRaw("Current: ",T00102_A551CpjConDelHora[0]);
               }
               if ( StringUtil.StrCmp(Z552CpjConDelUsuId, T00102_A552CpjConDelUsuId[0]) != 0 )
               {
                  GXUtil.WriteLog("core.clientepjcontato:[seudo value changed for attri]"+"CpjConDelUsuId");
                  GXUtil.WriteLogRaw("Old: ",Z552CpjConDelUsuId);
                  GXUtil.WriteLogRaw("Current: ",T00102_A552CpjConDelUsuId[0]);
               }
               if ( StringUtil.StrCmp(Z553CpjConDelUsuNome, T00102_A553CpjConDelUsuNome[0]) != 0 )
               {
                  GXUtil.WriteLog("core.clientepjcontato:[seudo value changed for attri]"+"CpjConDelUsuNome");
                  GXUtil.WriteLogRaw("Old: ",Z553CpjConDelUsuNome);
                  GXUtil.WriteLogRaw("Current: ",T00102_A553CpjConDelUsuNome[0]);
               }
               if ( Z273CpjConCPF != T00102_A273CpjConCPF[0] )
               {
                  GXUtil.WriteLog("core.clientepjcontato:[seudo value changed for attri]"+"CpjConCPF");
                  GXUtil.WriteLogRaw("Old: ",Z273CpjConCPF);
                  GXUtil.WriteLogRaw("Current: ",T00102_A273CpjConCPF[0]);
               }
               if ( StringUtil.StrCmp(Z274CpjConCPFFormat, T00102_A274CpjConCPFFormat[0]) != 0 )
               {
                  GXUtil.WriteLog("core.clientepjcontato:[seudo value changed for attri]"+"CpjConCPFFormat");
                  GXUtil.WriteLogRaw("Old: ",Z274CpjConCPFFormat);
                  GXUtil.WriteLogRaw("Current: ",T00102_A274CpjConCPFFormat[0]);
               }
               if ( StringUtil.StrCmp(Z275CpjConNome, T00102_A275CpjConNome[0]) != 0 )
               {
                  GXUtil.WriteLog("core.clientepjcontato:[seudo value changed for attri]"+"CpjConNome");
                  GXUtil.WriteLogRaw("Old: ",Z275CpjConNome);
                  GXUtil.WriteLogRaw("Current: ",T00102_A275CpjConNome[0]);
               }
               if ( StringUtil.StrCmp(Z276CpjConNomePrim, T00102_A276CpjConNomePrim[0]) != 0 )
               {
                  GXUtil.WriteLog("core.clientepjcontato:[seudo value changed for attri]"+"CpjConNomePrim");
                  GXUtil.WriteLogRaw("Old: ",Z276CpjConNomePrim);
                  GXUtil.WriteLogRaw("Current: ",T00102_A276CpjConNomePrim[0]);
               }
               if ( StringUtil.StrCmp(Z277CpjConSobrenome, T00102_A277CpjConSobrenome[0]) != 0 )
               {
                  GXUtil.WriteLog("core.clientepjcontato:[seudo value changed for attri]"+"CpjConSobrenome");
                  GXUtil.WriteLogRaw("Old: ",Z277CpjConSobrenome);
                  GXUtil.WriteLogRaw("Current: ",T00102_A277CpjConSobrenome[0]);
               }
               if ( StringUtil.StrCmp(Z278CpjNomeSocial, T00102_A278CpjNomeSocial[0]) != 0 )
               {
                  GXUtil.WriteLog("core.clientepjcontato:[seudo value changed for attri]"+"CpjNomeSocial");
                  GXUtil.WriteLogRaw("Old: ",Z278CpjNomeSocial);
                  GXUtil.WriteLogRaw("Current: ",T00102_A278CpjNomeSocial[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z282CpjConNascimento ) != DateTimeUtil.ResetTime ( T00102_A282CpjConNascimento[0] ) )
               {
                  GXUtil.WriteLog("core.clientepjcontato:[seudo value changed for attri]"+"CpjConNascimento");
                  GXUtil.WriteLogRaw("Old: ",Z282CpjConNascimento);
                  GXUtil.WriteLogRaw("Current: ",T00102_A282CpjConNascimento[0]);
               }
               if ( StringUtil.StrCmp(Z283CpjConTelNum, T00102_A283CpjConTelNum[0]) != 0 )
               {
                  GXUtil.WriteLog("core.clientepjcontato:[seudo value changed for attri]"+"CpjConTelNum");
                  GXUtil.WriteLogRaw("Old: ",Z283CpjConTelNum);
                  GXUtil.WriteLogRaw("Current: ",T00102_A283CpjConTelNum[0]);
               }
               if ( StringUtil.StrCmp(Z284CpjConTelRam, T00102_A284CpjConTelRam[0]) != 0 )
               {
                  GXUtil.WriteLog("core.clientepjcontato:[seudo value changed for attri]"+"CpjConTelRam");
                  GXUtil.WriteLogRaw("Old: ",Z284CpjConTelRam);
                  GXUtil.WriteLogRaw("Current: ",T00102_A284CpjConTelRam[0]);
               }
               if ( StringUtil.StrCmp(Z285CpjConCelNum, T00102_A285CpjConCelNum[0]) != 0 )
               {
                  GXUtil.WriteLog("core.clientepjcontato:[seudo value changed for attri]"+"CpjConCelNum");
                  GXUtil.WriteLogRaw("Old: ",Z285CpjConCelNum);
                  GXUtil.WriteLogRaw("Current: ",T00102_A285CpjConCelNum[0]);
               }
               if ( StringUtil.StrCmp(Z286CpjConWppNum, T00102_A286CpjConWppNum[0]) != 0 )
               {
                  GXUtil.WriteLog("core.clientepjcontato:[seudo value changed for attri]"+"CpjConWppNum");
                  GXUtil.WriteLogRaw("Old: ",Z286CpjConWppNum);
                  GXUtil.WriteLogRaw("Current: ",T00102_A286CpjConWppNum[0]);
               }
               if ( StringUtil.StrCmp(Z287CpjConEmail, T00102_A287CpjConEmail[0]) != 0 )
               {
                  GXUtil.WriteLog("core.clientepjcontato:[seudo value changed for attri]"+"CpjConEmail");
                  GXUtil.WriteLogRaw("Old: ",Z287CpjConEmail);
                  GXUtil.WriteLogRaw("Current: ",T00102_A287CpjConEmail[0]);
               }
               if ( StringUtil.StrCmp(Z288CpjConLIn, T00102_A288CpjConLIn[0]) != 0 )
               {
                  GXUtil.WriteLog("core.clientepjcontato:[seudo value changed for attri]"+"CpjConLIn");
                  GXUtil.WriteLogRaw("Old: ",Z288CpjConLIn);
                  GXUtil.WriteLogRaw("Current: ",T00102_A288CpjConLIn[0]);
               }
               if ( Z328CpjConUltEnd != T00102_A328CpjConUltEnd[0] )
               {
                  GXUtil.WriteLog("core.clientepjcontato:[seudo value changed for attri]"+"CpjConUltEnd");
                  GXUtil.WriteLogRaw("Old: ",Z328CpjConUltEnd);
                  GXUtil.WriteLogRaw("Current: ",T00102_A328CpjConUltEnd[0]);
               }
               if ( Z548CpjConDel != T00102_A548CpjConDel[0] )
               {
                  GXUtil.WriteLog("core.clientepjcontato:[seudo value changed for attri]"+"CpjConDel");
                  GXUtil.WriteLogRaw("Old: ",Z548CpjConDel);
                  GXUtil.WriteLogRaw("Current: ",T00102_A548CpjConDel[0]);
               }
               if ( Z270CpjConTipoID != T00102_A270CpjConTipoID[0] )
               {
                  GXUtil.WriteLog("core.clientepjcontato:[seudo value changed for attri]"+"CpjConTipoID");
                  GXUtil.WriteLogRaw("Old: ",Z270CpjConTipoID);
                  GXUtil.WriteLogRaw("Current: ",T00102_A270CpjConTipoID[0]);
               }
               if ( Z279CpjConGenID != T00102_A279CpjConGenID[0] )
               {
                  GXUtil.WriteLog("core.clientepjcontato:[seudo value changed for attri]"+"CpjConGenID");
                  GXUtil.WriteLogRaw("Old: ",Z279CpjConGenID);
                  GXUtil.WriteLogRaw("Current: ",T00102_A279CpjConGenID[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"tb_clientepj_contato"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
         /* Using cursor T001019 */
         pr_default.execute(17, new Object[] {A158CliID, A166CpjID});
         if ( (pr_default.getStatus(17) == 103) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_clientepj"}), "RecordIsLocked", 1, "");
            AnyError = 1;
            return  ;
         }
         if ( ! IsIns( ) )
         {
            Gx_longc = false;
            if ( false || ( StringUtil.StrCmp(Z170CpjNomeFan, T001019_A170CpjNomeFan[0]) != 0 ) || ( StringUtil.StrCmp(Z171CpjRazaoSoc, T001019_A171CpjRazaoSoc[0]) != 0 ) || ( Z176CpjMatricula != T001019_A176CpjMatricula[0] ) || ( Z187CpjCNPJ != T001019_A187CpjCNPJ[0] ) || ( StringUtil.StrCmp(Z188CpjCNPJFormat, T001019_A188CpjCNPJFormat[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z189CpjIE, T001019_A189CpjIE[0]) != 0 ) || ( Z207CpjAtivo != T001019_A207CpjAtivo[0] ) || ( StringUtil.StrCmp(Z261CpjTelNum, T001019_A261CpjTelNum[0]) != 0 ) || ( StringUtil.StrCmp(Z262CpjTelRam, T001019_A262CpjTelRam[0]) != 0 ) || ( StringUtil.StrCmp(Z263CpjCelNum, T001019_A263CpjCelNum[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z264CpjWppNum, T001019_A264CpjWppNum[0]) != 0 ) || ( StringUtil.StrCmp(Z265CpjWebsite, T001019_A265CpjWebsite[0]) != 0 ) || ( StringUtil.StrCmp(Z266CpjEmail, T001019_A266CpjEmail[0]) != 0 ) || ( Z365CpjTipoId != T001019_A365CpjTipoId[0] ) )
            {
               if ( StringUtil.StrCmp(Z170CpjNomeFan, T001019_A170CpjNomeFan[0]) != 0 )
               {
                  GXUtil.WriteLog("core.clientepjcontato:[seudo value changed for attri]"+"CpjNomeFan");
                  GXUtil.WriteLogRaw("Old: ",Z170CpjNomeFan);
                  GXUtil.WriteLogRaw("Current: ",T001019_A170CpjNomeFan[0]);
               }
               if ( StringUtil.StrCmp(Z171CpjRazaoSoc, T001019_A171CpjRazaoSoc[0]) != 0 )
               {
                  GXUtil.WriteLog("core.clientepjcontato:[seudo value changed for attri]"+"CpjRazaoSoc");
                  GXUtil.WriteLogRaw("Old: ",Z171CpjRazaoSoc);
                  GXUtil.WriteLogRaw("Current: ",T001019_A171CpjRazaoSoc[0]);
               }
               if ( Z176CpjMatricula != T001019_A176CpjMatricula[0] )
               {
                  GXUtil.WriteLog("core.clientepjcontato:[seudo value changed for attri]"+"CpjMatricula");
                  GXUtil.WriteLogRaw("Old: ",Z176CpjMatricula);
                  GXUtil.WriteLogRaw("Current: ",T001019_A176CpjMatricula[0]);
               }
               if ( Z187CpjCNPJ != T001019_A187CpjCNPJ[0] )
               {
                  GXUtil.WriteLog("core.clientepjcontato:[seudo value changed for attri]"+"CpjCNPJ");
                  GXUtil.WriteLogRaw("Old: ",Z187CpjCNPJ);
                  GXUtil.WriteLogRaw("Current: ",T001019_A187CpjCNPJ[0]);
               }
               if ( StringUtil.StrCmp(Z188CpjCNPJFormat, T001019_A188CpjCNPJFormat[0]) != 0 )
               {
                  GXUtil.WriteLog("core.clientepjcontato:[seudo value changed for attri]"+"CpjCNPJFormat");
                  GXUtil.WriteLogRaw("Old: ",Z188CpjCNPJFormat);
                  GXUtil.WriteLogRaw("Current: ",T001019_A188CpjCNPJFormat[0]);
               }
               if ( StringUtil.StrCmp(Z189CpjIE, T001019_A189CpjIE[0]) != 0 )
               {
                  GXUtil.WriteLog("core.clientepjcontato:[seudo value changed for attri]"+"CpjIE");
                  GXUtil.WriteLogRaw("Old: ",Z189CpjIE);
                  GXUtil.WriteLogRaw("Current: ",T001019_A189CpjIE[0]);
               }
               if ( Z207CpjAtivo != T001019_A207CpjAtivo[0] )
               {
                  GXUtil.WriteLog("core.clientepjcontato:[seudo value changed for attri]"+"CpjAtivo");
                  GXUtil.WriteLogRaw("Old: ",Z207CpjAtivo);
                  GXUtil.WriteLogRaw("Current: ",T001019_A207CpjAtivo[0]);
               }
               if ( StringUtil.StrCmp(Z261CpjTelNum, T001019_A261CpjTelNum[0]) != 0 )
               {
                  GXUtil.WriteLog("core.clientepjcontato:[seudo value changed for attri]"+"CpjTelNum");
                  GXUtil.WriteLogRaw("Old: ",Z261CpjTelNum);
                  GXUtil.WriteLogRaw("Current: ",T001019_A261CpjTelNum[0]);
               }
               if ( StringUtil.StrCmp(Z262CpjTelRam, T001019_A262CpjTelRam[0]) != 0 )
               {
                  GXUtil.WriteLog("core.clientepjcontato:[seudo value changed for attri]"+"CpjTelRam");
                  GXUtil.WriteLogRaw("Old: ",Z262CpjTelRam);
                  GXUtil.WriteLogRaw("Current: ",T001019_A262CpjTelRam[0]);
               }
               if ( StringUtil.StrCmp(Z263CpjCelNum, T001019_A263CpjCelNum[0]) != 0 )
               {
                  GXUtil.WriteLog("core.clientepjcontato:[seudo value changed for attri]"+"CpjCelNum");
                  GXUtil.WriteLogRaw("Old: ",Z263CpjCelNum);
                  GXUtil.WriteLogRaw("Current: ",T001019_A263CpjCelNum[0]);
               }
               if ( StringUtil.StrCmp(Z264CpjWppNum, T001019_A264CpjWppNum[0]) != 0 )
               {
                  GXUtil.WriteLog("core.clientepjcontato:[seudo value changed for attri]"+"CpjWppNum");
                  GXUtil.WriteLogRaw("Old: ",Z264CpjWppNum);
                  GXUtil.WriteLogRaw("Current: ",T001019_A264CpjWppNum[0]);
               }
               if ( StringUtil.StrCmp(Z265CpjWebsite, T001019_A265CpjWebsite[0]) != 0 )
               {
                  GXUtil.WriteLog("core.clientepjcontato:[seudo value changed for attri]"+"CpjWebsite");
                  GXUtil.WriteLogRaw("Old: ",Z265CpjWebsite);
                  GXUtil.WriteLogRaw("Current: ",T001019_A265CpjWebsite[0]);
               }
               if ( StringUtil.StrCmp(Z266CpjEmail, T001019_A266CpjEmail[0]) != 0 )
               {
                  GXUtil.WriteLog("core.clientepjcontato:[seudo value changed for attri]"+"CpjEmail");
                  GXUtil.WriteLogRaw("Old: ",Z266CpjEmail);
                  GXUtil.WriteLogRaw("Current: ",T001019_A266CpjEmail[0]);
               }
               if ( Z365CpjTipoId != T001019_A365CpjTipoId[0] )
               {
                  GXUtil.WriteLog("core.clientepjcontato:[seudo value changed for attri]"+"CpjTipoId");
                  GXUtil.WriteLogRaw("Old: ",Z365CpjTipoId);
                  GXUtil.WriteLogRaw("Current: ",T001019_A365CpjTipoId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"tb_clientepj"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1032( )
      {
         if ( ! IsAuthorized("clientepjcontato_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1032( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1032( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1032( 0) ;
            CheckOptimisticConcurrency1032( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1032( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1032( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001020 */
                     pr_default.execute(18, new Object[] {A271CpjConTipoSigla, A272CpjConTipoNome, A280CpjConGenSigla, A281CpjConGenNome, A269CpjConSeq, n549CpjConDelDataHora, A549CpjConDelDataHora, n550CpjConDelData, A550CpjConDelData, n551CpjConDelHora, A551CpjConDelHora, n552CpjConDelUsuId, A552CpjConDelUsuId, n553CpjConDelUsuNome, A553CpjConDelUsuNome, A273CpjConCPF, A274CpjConCPFFormat, A275CpjConNome, A276CpjConNomePrim, A277CpjConSobrenome, A278CpjNomeSocial, A282CpjConNascimento, n283CpjConTelNum, A283CpjConTelNum, n284CpjConTelRam, A284CpjConTelRam, n285CpjConCelNum, A285CpjConCelNum, n286CpjConWppNum, A286CpjConWppNum, n287CpjConEmail, A287CpjConEmail, n288CpjConLIn, A288CpjConLIn, n328CpjConUltEnd, A328CpjConUltEnd, A548CpjConDel, A158CliID, A166CpjID, A270CpjConTipoID, A279CpjConGenID});
                     pr_default.close(18);
                     pr_default.SmartCacheProvider.SetUpdated("tb_clientepj_contato");
                     if ( (pr_default.getStatus(18) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        UpdateTablesN11032( ) ;
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption100( ) ;
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
               Load1032( ) ;
            }
            EndLevel1032( ) ;
         }
         CloseExtendedTableCursors1032( ) ;
      }

      protected void Update1032( )
      {
         if ( ! IsAuthorized("clientepjcontato_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1032( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1032( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1032( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1032( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1032( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001021 */
                     pr_default.execute(19, new Object[] {A271CpjConTipoSigla, A272CpjConTipoNome, A280CpjConGenSigla, A281CpjConGenNome, n549CpjConDelDataHora, A549CpjConDelDataHora, n550CpjConDelData, A550CpjConDelData, n551CpjConDelHora, A551CpjConDelHora, n552CpjConDelUsuId, A552CpjConDelUsuId, n553CpjConDelUsuNome, A553CpjConDelUsuNome, A273CpjConCPF, A274CpjConCPFFormat, A275CpjConNome, A276CpjConNomePrim, A277CpjConSobrenome, A278CpjNomeSocial, A282CpjConNascimento, n283CpjConTelNum, A283CpjConTelNum, n284CpjConTelRam, A284CpjConTelRam, n285CpjConCelNum, A285CpjConCelNum, n286CpjConWppNum, A286CpjConWppNum, n287CpjConEmail, A287CpjConEmail, n288CpjConLIn, A288CpjConLIn, n328CpjConUltEnd, A328CpjConUltEnd, A548CpjConDel, A270CpjConTipoID, A279CpjConGenID, A158CliID, A166CpjID, A269CpjConSeq});
                     pr_default.close(19);
                     pr_default.SmartCacheProvider.SetUpdated("tb_clientepj_contato");
                     if ( (pr_default.getStatus(19) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_clientepj_contato"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1032( ) ;
                     if ( AnyError == 0 )
                     {
                        UpdateTablesN11032( ) ;
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
            EndLevel1032( ) ;
         }
         CloseExtendedTableCursors1032( ) ;
      }

      protected void DeferredUpdate1032( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("clientepjcontato_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1032( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1032( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1032( ) ;
            AfterConfirm1032( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1032( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001022 */
                  pr_default.execute(20, new Object[] {A158CliID, A166CpjID, A269CpjConSeq});
                  pr_default.close(20);
                  pr_default.SmartCacheProvider.SetUpdated("tb_clientepj_contato");
                  if ( AnyError == 0 )
                  {
                     UpdateTablesN11032( ) ;
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
         sMode32 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1032( ) ;
         Gx_mode = sMode32;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1032( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T001023 */
            pr_default.execute(21, new Object[] {A158CliID});
            A159CliMatricula = T001023_A159CliMatricula[0];
            A160CliNomeFamiliar = T001023_A160CliNomeFamiliar[0];
            pr_default.close(21);
            /* Using cursor T001024 */
            pr_default.execute(22, new Object[] {A158CliID, A166CpjID});
            Z170CpjNomeFan = T001024_A170CpjNomeFan[0];
            Z171CpjRazaoSoc = T001024_A171CpjRazaoSoc[0];
            Z176CpjMatricula = T001024_A176CpjMatricula[0];
            Z187CpjCNPJ = T001024_A187CpjCNPJ[0];
            Z188CpjCNPJFormat = T001024_A188CpjCNPJFormat[0];
            Z189CpjIE = T001024_A189CpjIE[0];
            Z207CpjAtivo = T001024_A207CpjAtivo[0];
            Z261CpjTelNum = T001024_A261CpjTelNum[0];
            Z262CpjTelRam = T001024_A262CpjTelRam[0];
            Z263CpjCelNum = T001024_A263CpjCelNum[0];
            Z264CpjWppNum = T001024_A264CpjWppNum[0];
            Z265CpjWebsite = T001024_A265CpjWebsite[0];
            Z266CpjEmail = T001024_A266CpjEmail[0];
            Z365CpjTipoId = T001024_A365CpjTipoId[0];
            A268CpjUltConSeq = T001024_A268CpjUltConSeq[0];
            n268CpjUltConSeq = T001024_n268CpjUltConSeq[0];
            A170CpjNomeFan = T001024_A170CpjNomeFan[0];
            A171CpjRazaoSoc = T001024_A171CpjRazaoSoc[0];
            A176CpjMatricula = T001024_A176CpjMatricula[0];
            AssignAttri("", false, "A176CpjMatricula", StringUtil.LTrimStr( (decimal)(A176CpjMatricula), 12, 0));
            A187CpjCNPJ = T001024_A187CpjCNPJ[0];
            AssignAttri("", false, "A187CpjCNPJ", StringUtil.LTrimStr( (decimal)(A187CpjCNPJ), 14, 0));
            A188CpjCNPJFormat = T001024_A188CpjCNPJFormat[0];
            A189CpjIE = T001024_A189CpjIE[0];
            A207CpjAtivo = T001024_A207CpjAtivo[0];
            AssignAttri("", false, "A207CpjAtivo", A207CpjAtivo);
            A261CpjTelNum = T001024_A261CpjTelNum[0];
            n261CpjTelNum = T001024_n261CpjTelNum[0];
            AssignAttri("", false, "A261CpjTelNum", A261CpjTelNum);
            A262CpjTelRam = T001024_A262CpjTelRam[0];
            n262CpjTelRam = T001024_n262CpjTelRam[0];
            AssignAttri("", false, "A262CpjTelRam", A262CpjTelRam);
            A263CpjCelNum = T001024_A263CpjCelNum[0];
            n263CpjCelNum = T001024_n263CpjCelNum[0];
            AssignAttri("", false, "A263CpjCelNum", A263CpjCelNum);
            A264CpjWppNum = T001024_A264CpjWppNum[0];
            n264CpjWppNum = T001024_n264CpjWppNum[0];
            AssignAttri("", false, "A264CpjWppNum", A264CpjWppNum);
            A265CpjWebsite = T001024_A265CpjWebsite[0];
            n265CpjWebsite = T001024_n265CpjWebsite[0];
            AssignAttri("", false, "A265CpjWebsite", A265CpjWebsite);
            A266CpjEmail = T001024_A266CpjEmail[0];
            n266CpjEmail = T001024_n266CpjEmail[0];
            AssignAttri("", false, "A266CpjEmail", A266CpjEmail);
            A365CpjTipoId = T001024_A365CpjTipoId[0];
            AssignAttri("", false, "A365CpjTipoId", StringUtil.LTrimStr( (decimal)(A365CpjTipoId), 9, 0));
            O268CpjUltConSeq = A268CpjUltConSeq;
            n268CpjUltConSeq = false;
            AssignAttri("", false, "A268CpjUltConSeq", StringUtil.LTrimStr( (decimal)(A268CpjUltConSeq), 4, 0));
            pr_default.close(22);
            if ( IsIns( )  )
            {
               A268CpjUltConSeq = (short)(O268CpjUltConSeq+1);
               n268CpjUltConSeq = false;
               AssignAttri("", false, "A268CpjUltConSeq", StringUtil.LTrimStr( (decimal)(A268CpjUltConSeq), 4, 0));
            }
            /* Using cursor T001025 */
            pr_default.execute(23, new Object[] {A365CpjTipoId});
            A366CpjTipoSigla = T001025_A366CpjTipoSigla[0];
            A367CpjTipoNome = T001025_A367CpjTipoNome[0];
            pr_default.close(23);
            /* Using cursor T001026 */
            pr_default.execute(24, new Object[] {A270CpjConTipoID});
            A271CpjConTipoSigla = T001026_A271CpjConTipoSigla[0];
            AssignAttri("", false, "A271CpjConTipoSigla", A271CpjConTipoSigla);
            A272CpjConTipoNome = T001026_A272CpjConTipoNome[0];
            pr_default.close(24);
            /* Using cursor T001027 */
            pr_default.execute(25, new Object[] {A279CpjConGenID});
            A280CpjConGenSigla = T001027_A280CpjConGenSigla[0];
            A281CpjConGenNome = T001027_A281CpjConGenNome[0];
            pr_default.close(25);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T001028 */
            pr_default.execute(26, new Object[] {A158CliID, A166CpjID, A269CpjConSeq});
            if ( (pr_default.getStatus(26) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Endereço do Contato do Cliente PJ"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(26);
         }
      }

      protected void UpdateTablesN11032( )
      {
         /* Using cursor T001029 */
         pr_default.execute(27, new Object[] {n268CpjUltConSeq, A268CpjUltConSeq, A158CliID, A166CpjID});
         pr_default.close(27);
         pr_default.SmartCacheProvider.SetUpdated("tb_clientepj");
      }

      protected void EndLevel1032( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         pr_default.close(17);
         if ( AnyError == 0 )
         {
            BeforeComplete1032( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("core.clientepjcontato",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues100( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("core.clientepjcontato",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1032( )
      {
         /* Scan By routine */
         /* Using cursor T001030 */
         pr_default.execute(28);
         RcdFound32 = 0;
         if ( (pr_default.getStatus(28) != 101) )
         {
            RcdFound32 = 1;
            A158CliID = T001030_A158CliID[0];
            AssignAttri("", false, "A158CliID", A158CliID.ToString());
            A166CpjID = T001030_A166CpjID[0];
            AssignAttri("", false, "A166CpjID", A166CpjID.ToString());
            A269CpjConSeq = T001030_A269CpjConSeq[0];
            AssignAttri("", false, "A269CpjConSeq", StringUtil.LTrimStr( (decimal)(A269CpjConSeq), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1032( )
      {
         /* Scan next routine */
         pr_default.readNext(28);
         RcdFound32 = 0;
         if ( (pr_default.getStatus(28) != 101) )
         {
            RcdFound32 = 1;
            A158CliID = T001030_A158CliID[0];
            AssignAttri("", false, "A158CliID", A158CliID.ToString());
            A166CpjID = T001030_A166CpjID[0];
            AssignAttri("", false, "A166CpjID", A166CpjID.ToString());
            A269CpjConSeq = T001030_A269CpjConSeq[0];
            AssignAttri("", false, "A269CpjConSeq", StringUtil.LTrimStr( (decimal)(A269CpjConSeq), 4, 0));
         }
      }

      protected void ScanEnd1032( )
      {
         pr_default.close(28);
      }

      protected void AfterConfirm1032( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1032( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1032( )
      {
         /* Before Update Rules */
         new GeneXus.Programs.core.loadauditclientepjcontato(context ).execute(  "Y", ref  AV47AuditingObject,  A158CliID,  A166CpjID,  A269CpjConSeq,  Gx_mode) ;
         if ( A548CpjConDel && ( O548CpjConDel != A548CpjConDel ) )
         {
            A549CpjConDelDataHora = DateTimeUtil.NowMS( context);
            n549CpjConDelDataHora = false;
            AssignAttri("", false, "A549CpjConDelDataHora", context.localUtil.TToC( A549CpjConDelDataHora, 10, 12, 0, 3, "/", ":", " "));
         }
         if ( A548CpjConDel && ( O548CpjConDel != A548CpjConDel ) )
         {
            A552CpjConDelUsuId = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getid();
            n552CpjConDelUsuId = false;
            AssignAttri("", false, "A552CpjConDelUsuId", A552CpjConDelUsuId);
         }
         if ( A548CpjConDel && ( O548CpjConDel != A548CpjConDel ) )
         {
            A553CpjConDelUsuNome = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
            n553CpjConDelUsuNome = false;
            AssignAttri("", false, "A553CpjConDelUsuNome", A553CpjConDelUsuNome);
         }
         if ( A548CpjConDel && ( O548CpjConDel != A548CpjConDel ) )
         {
            A550CpjConDelData = DateTimeUtil.ResetTime( DateTimeUtil.ResetTime( A549CpjConDelDataHora) ) ;
            n550CpjConDelData = false;
            AssignAttri("", false, "A550CpjConDelData", context.localUtil.TToC( A550CpjConDelData, 10, 5, 0, 3, "/", ":", " "));
         }
         if ( A548CpjConDel && ( O548CpjConDel != A548CpjConDel ) )
         {
            A551CpjConDelHora = DateTimeUtil.ResetDate( DateTimeUtil.ResetMilliseconds(A549CpjConDelDataHora));
            n551CpjConDelHora = false;
            AssignAttri("", false, "A551CpjConDelHora", context.localUtil.TToC( A551CpjConDelHora, 0, 5, 0, 3, "/", ":", " "));
         }
      }

      protected void BeforeDelete1032( )
      {
         /* Before Delete Rules */
         new GeneXus.Programs.core.loadauditclientepjcontato(context ).execute(  "Y", ref  AV47AuditingObject,  A158CliID,  A166CpjID,  A269CpjConSeq,  Gx_mode) ;
      }

      protected void BeforeComplete1032( )
      {
         /* Before Complete Rules */
         if ( IsIns( )  )
         {
            new GeneXus.Programs.core.loadauditclientepjcontato(context ).execute(  "N", ref  AV47AuditingObject,  A158CliID,  A166CpjID,  A269CpjConSeq,  Gx_mode) ;
         }
         if ( IsUpd( )  )
         {
            new GeneXus.Programs.core.loadauditclientepjcontato(context ).execute(  "N", ref  AV47AuditingObject,  A158CliID,  A166CpjID,  A269CpjConSeq,  Gx_mode) ;
         }
      }

      protected void BeforeValidate1032( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1032( )
      {
         edtCliID_Enabled = 0;
         AssignProp("", false, edtCliID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliID_Enabled), 5, 0), true);
         edtCpjID_Enabled = 0;
         AssignProp("", false, edtCpjID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjID_Enabled), 5, 0), true);
         edtCpjTipoId_Enabled = 0;
         AssignProp("", false, edtCpjTipoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjTipoId_Enabled), 5, 0), true);
         edtCpjMatricula_Enabled = 0;
         AssignProp("", false, edtCpjMatricula_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjMatricula_Enabled), 5, 0), true);
         edtCpjTelNum_Enabled = 0;
         AssignProp("", false, edtCpjTelNum_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjTelNum_Enabled), 5, 0), true);
         edtCpjTelRam_Enabled = 0;
         AssignProp("", false, edtCpjTelRam_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjTelRam_Enabled), 5, 0), true);
         edtCpjCelNum_Enabled = 0;
         AssignProp("", false, edtCpjCelNum_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjCelNum_Enabled), 5, 0), true);
         edtCpjWppNum_Enabled = 0;
         AssignProp("", false, edtCpjWppNum_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjWppNum_Enabled), 5, 0), true);
         edtCpjWebsite_Enabled = 0;
         AssignProp("", false, edtCpjWebsite_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjWebsite_Enabled), 5, 0), true);
         edtCpjEmail_Enabled = 0;
         AssignProp("", false, edtCpjEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjEmail_Enabled), 5, 0), true);
         edtCpjConTipoID_Enabled = 0;
         AssignProp("", false, edtCpjConTipoID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjConTipoID_Enabled), 5, 0), true);
         edtCpjConNome_Enabled = 0;
         AssignProp("", false, edtCpjConNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjConNome_Enabled), 5, 0), true);
         edtCpjConCPFFormat_Enabled = 0;
         AssignProp("", false, edtCpjConCPFFormat_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjConCPFFormat_Enabled), 5, 0), true);
         edtCpjConNascimento_Enabled = 0;
         AssignProp("", false, edtCpjConNascimento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjConNascimento_Enabled), 5, 0), true);
         edtCpjNomeSocial_Enabled = 0;
         AssignProp("", false, edtCpjNomeSocial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjNomeSocial_Enabled), 5, 0), true);
         edtCpjConGenID_Enabled = 0;
         AssignProp("", false, edtCpjConGenID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjConGenID_Enabled), 5, 0), true);
         edtCpjConCelNum_Enabled = 0;
         AssignProp("", false, edtCpjConCelNum_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjConCelNum_Enabled), 5, 0), true);
         edtCpjConWppNum_Enabled = 0;
         AssignProp("", false, edtCpjConWppNum_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjConWppNum_Enabled), 5, 0), true);
         edtCpjConTelNum_Enabled = 0;
         AssignProp("", false, edtCpjConTelNum_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjConTelNum_Enabled), 5, 0), true);
         edtCpjConTelRam_Enabled = 0;
         AssignProp("", false, edtCpjConTelRam_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjConTelRam_Enabled), 5, 0), true);
         edtCpjConEmail_Enabled = 0;
         AssignProp("", false, edtCpjConEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjConEmail_Enabled), 5, 0), true);
         edtCpjConLIn_Enabled = 0;
         AssignProp("", false, edtCpjConLIn_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjConLIn_Enabled), 5, 0), true);
         edtavCombocliid_Enabled = 0;
         AssignProp("", false, edtavCombocliid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombocliid_Enabled), 5, 0), true);
         edtavCombocpjid_Enabled = 0;
         AssignProp("", false, edtavCombocpjid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombocpjid_Enabled), 5, 0), true);
         edtavCombocpjcontipoid_Enabled = 0;
         AssignProp("", false, edtavCombocpjcontipoid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombocpjcontipoid_Enabled), 5, 0), true);
         edtavCombocpjcongenid_Enabled = 0;
         AssignProp("", false, edtavCombocpjcongenid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombocpjcongenid_Enabled), 5, 0), true);
         edtCpjConSeq_Enabled = 0;
         AssignProp("", false, edtCpjConSeq_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjConSeq_Enabled), 5, 0), true);
         edtCpjConTipoSigla_Enabled = 0;
         AssignProp("", false, edtCpjConTipoSigla_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjConTipoSigla_Enabled), 5, 0), true);
         edtCpjConCPF_Enabled = 0;
         AssignProp("", false, edtCpjConCPF_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjConCPF_Enabled), 5, 0), true);
         edtCpjConNomePrim_Enabled = 0;
         AssignProp("", false, edtCpjConNomePrim_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjConNomePrim_Enabled), 5, 0), true);
         edtCpjConSobrenome_Enabled = 0;
         AssignProp("", false, edtCpjConSobrenome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjConSobrenome_Enabled), 5, 0), true);
         edtCpjConUltEnd_Enabled = 0;
         AssignProp("", false, edtCpjConUltEnd_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjConUltEnd_Enabled), 5, 0), true);
         edtCpjCNPJ_Enabled = 0;
         AssignProp("", false, edtCpjCNPJ_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjCNPJ_Enabled), 5, 0), true);
         edtCpjAtivo_Enabled = 0;
         AssignProp("", false, edtCpjAtivo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjAtivo_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1032( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues100( )
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
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
         GXEncryptionTmp = "core.clientepjcontato.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV7CliID.ToString()) + "," + UrlEncode(AV8CpjID.ToString()) + "," + UrlEncode(StringUtil.LTrimStr(AV37CpjConSeq,4,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("core.clientepjcontato.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"ClientePJContato");
         forbiddenHiddens.Add("CliID", A158CliID.ToString());
         forbiddenHiddens.Add("CpjID", A166CpjID.ToString());
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("Pgmname", StringUtil.RTrim( context.localUtil.Format( AV49Pgmname, "")));
         forbiddenHiddens.Add("CpjConDel", StringUtil.BoolToStr( A548CpjConDel));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("core\\clientepjcontato:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z158CliID", Z158CliID.ToString());
         GxWebStd.gx_hidden_field( context, "Z166CpjID", Z166CpjID.ToString());
         GxWebStd.gx_hidden_field( context, "Z269CpjConSeq", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z269CpjConSeq), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z549CpjConDelDataHora", context.localUtil.TToC( Z549CpjConDelDataHora, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z550CpjConDelData", context.localUtil.TToC( Z550CpjConDelData, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z551CpjConDelHora", context.localUtil.TToC( Z551CpjConDelHora, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z552CpjConDelUsuId", StringUtil.RTrim( Z552CpjConDelUsuId));
         GxWebStd.gx_hidden_field( context, "Z553CpjConDelUsuNome", Z553CpjConDelUsuNome);
         GxWebStd.gx_hidden_field( context, "Z273CpjConCPF", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z273CpjConCPF), 11, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z274CpjConCPFFormat", Z274CpjConCPFFormat);
         GxWebStd.gx_hidden_field( context, "Z275CpjConNome", Z275CpjConNome);
         GxWebStd.gx_hidden_field( context, "Z276CpjConNomePrim", Z276CpjConNomePrim);
         GxWebStd.gx_hidden_field( context, "Z277CpjConSobrenome", Z277CpjConSobrenome);
         GxWebStd.gx_hidden_field( context, "Z278CpjNomeSocial", Z278CpjNomeSocial);
         GxWebStd.gx_hidden_field( context, "Z282CpjConNascimento", context.localUtil.DToC( Z282CpjConNascimento, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z283CpjConTelNum", StringUtil.RTrim( Z283CpjConTelNum));
         GxWebStd.gx_hidden_field( context, "Z284CpjConTelRam", Z284CpjConTelRam);
         GxWebStd.gx_hidden_field( context, "Z285CpjConCelNum", StringUtil.RTrim( Z285CpjConCelNum));
         GxWebStd.gx_hidden_field( context, "Z286CpjConWppNum", StringUtil.RTrim( Z286CpjConWppNum));
         GxWebStd.gx_hidden_field( context, "Z287CpjConEmail", Z287CpjConEmail);
         GxWebStd.gx_hidden_field( context, "Z288CpjConLIn", Z288CpjConLIn);
         GxWebStd.gx_hidden_field( context, "Z328CpjConUltEnd", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z328CpjConUltEnd), 4, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "Z548CpjConDel", Z548CpjConDel);
         GxWebStd.gx_hidden_field( context, "Z270CpjConTipoID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z270CpjConTipoID), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z279CpjConGenID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z279CpjConGenID), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z170CpjNomeFan", Z170CpjNomeFan);
         GxWebStd.gx_hidden_field( context, "Z171CpjRazaoSoc", Z171CpjRazaoSoc);
         GxWebStd.gx_hidden_field( context, "Z176CpjMatricula", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z176CpjMatricula), 12, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z187CpjCNPJ", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z187CpjCNPJ), 14, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z188CpjCNPJFormat", Z188CpjCNPJFormat);
         GxWebStd.gx_hidden_field( context, "Z189CpjIE", Z189CpjIE);
         GxWebStd.gx_boolean_hidden_field( context, "Z207CpjAtivo", Z207CpjAtivo);
         GxWebStd.gx_hidden_field( context, "Z261CpjTelNum", StringUtil.RTrim( Z261CpjTelNum));
         GxWebStd.gx_hidden_field( context, "Z262CpjTelRam", Z262CpjTelRam);
         GxWebStd.gx_hidden_field( context, "Z263CpjCelNum", StringUtil.RTrim( Z263CpjCelNum));
         GxWebStd.gx_hidden_field( context, "Z264CpjWppNum", StringUtil.RTrim( Z264CpjWppNum));
         GxWebStd.gx_hidden_field( context, "Z265CpjWebsite", Z265CpjWebsite);
         GxWebStd.gx_hidden_field( context, "Z266CpjEmail", Z266CpjEmail);
         GxWebStd.gx_hidden_field( context, "Z365CpjTipoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z365CpjTipoId), 9, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "O548CpjConDel", O548CpjConDel);
         GxWebStd.gx_hidden_field( context, "O268CpjUltConSeq", StringUtil.LTrim( StringUtil.NToC( (decimal)(O268CpjUltConSeq), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N270CpjConTipoID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A270CpjConTipoID), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N279CpjConGenID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A279CpjConGenID), 9, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV17DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV17DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCLIID_DATA", AV16CliID_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCLIID_DATA", AV16CliID_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCPJID_DATA", AV44CpjID_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCPJID_DATA", AV44CpjID_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCPJCONTIPOID_DATA", AV32CpjConTipoID_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCPJCONTIPOID_DATA", AV32CpjConTipoID_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCPJCONGENID_DATA", AV33CpjConGenID_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCPJCONGENID_DATA", AV33CpjConGenID_Data);
         }
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV12TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV12TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV12TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vCLIID", AV7CliID.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vCLIID", GetSecureSignedToken( "", AV7CliID, context));
         GxWebStd.gx_hidden_field( context, "vCPJID", AV8CpjID.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vCPJID", GetSecureSignedToken( "", AV8CpjID, context));
         GxWebStd.gx_hidden_field( context, "vCPJCONSEQ", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV37CpjConSeq), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCPJCONSEQ", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV37CpjConSeq), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "CPJULTCONSEQ", StringUtil.LTrim( StringUtil.NToC( (decimal)(A268CpjUltConSeq), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_CPJCONTIPOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV38Insert_CpjConTipoID), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_CPJCONGENID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV39Insert_CpjConGenID), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "CLINOMEFAMILIAR", A160CliNomeFamiliar);
         GxWebStd.gx_hidden_field( context, "CPJNOMEFAN", A170CpjNomeFan);
         GxWebStd.gx_hidden_field( context, "CPJTIPONOME", A367CpjTipoNome);
         GxWebStd.gx_boolean_hidden_field( context, "CPJCONDEL", A548CpjConDel);
         GxWebStd.gx_hidden_field( context, "CPJCONDELDATAHORA", context.localUtil.TToC( A549CpjConDelDataHora, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "CPJCONDELDATA", context.localUtil.TToC( A550CpjConDelData, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "CPJCONDELHORA", context.localUtil.TToC( A551CpjConDelHora, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "CPJCONDELUSUID", StringUtil.RTrim( A552CpjConDelUsuId));
         GxWebStd.gx_hidden_field( context, "CPJCONDELUSUNOME", A553CpjConDelUsuNome);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAUDITINGOBJECT", AV47AuditingObject);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAUDITINGOBJECT", AV47AuditingObject);
         }
         GxWebStd.gx_hidden_field( context, "CLIMATRICULA", StringUtil.LTrim( StringUtil.NToC( (decimal)(A159CliMatricula), 12, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "CPJRAZAOSOC", A171CpjRazaoSoc);
         GxWebStd.gx_hidden_field( context, "CPJCNPJFORMAT", A188CpjCNPJFormat);
         GxWebStd.gx_hidden_field( context, "CPJIE", A189CpjIE);
         GxWebStd.gx_hidden_field( context, "CPJCONTIPONOME", A272CpjConTipoNome);
         GxWebStd.gx_hidden_field( context, "CPJCONGENSIGLA", A280CpjConGenSigla);
         GxWebStd.gx_hidden_field( context, "CPJCONGENNOME", A281CpjConGenNome);
         GxWebStd.gx_hidden_field( context, "CPJTIPOSIGLA", A366CpjTipoSigla);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV49Pgmname));
         GxWebStd.gx_hidden_field( context, "COMBO_CLIID_Objectcall", StringUtil.RTrim( Combo_cliid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_CLIID_Cls", StringUtil.RTrim( Combo_cliid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_CLIID_Selectedvalue_set", StringUtil.RTrim( Combo_cliid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_CLIID_Enabled", StringUtil.BoolToStr( Combo_cliid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_CLIID_Emptyitem", StringUtil.BoolToStr( Combo_cliid_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_CLIID_Htmltemplate", StringUtil.RTrim( Combo_cliid_Htmltemplate));
         GxWebStd.gx_hidden_field( context, "COMBO_CPJID_Objectcall", StringUtil.RTrim( Combo_cpjid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_CPJID_Cls", StringUtil.RTrim( Combo_cpjid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_CPJID_Selectedvalue_set", StringUtil.RTrim( Combo_cpjid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_CPJID_Selectedtext_set", StringUtil.RTrim( Combo_cpjid_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_CPJID_Gamoauthtoken", StringUtil.RTrim( Combo_cpjid_Gamoauthtoken));
         GxWebStd.gx_hidden_field( context, "COMBO_CPJID_Enabled", StringUtil.BoolToStr( Combo_cpjid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_CPJID_Datalistproc", StringUtil.RTrim( Combo_cpjid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_CPJID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_cpjid_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_CPJID_Emptyitem", StringUtil.BoolToStr( Combo_cpjid_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_CPJID_Htmltemplate", StringUtil.RTrim( Combo_cpjid_Htmltemplate));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECLIENTE_Objectcall", StringUtil.RTrim( Dvpanel_tablecliente_Objectcall));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECLIENTE_Enabled", StringUtil.BoolToStr( Dvpanel_tablecliente_Enabled));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECLIENTE_Width", StringUtil.RTrim( Dvpanel_tablecliente_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECLIENTE_Autowidth", StringUtil.BoolToStr( Dvpanel_tablecliente_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECLIENTE_Autoheight", StringUtil.BoolToStr( Dvpanel_tablecliente_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECLIENTE_Cls", StringUtil.RTrim( Dvpanel_tablecliente_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECLIENTE_Title", StringUtil.RTrim( Dvpanel_tablecliente_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECLIENTE_Collapsible", StringUtil.BoolToStr( Dvpanel_tablecliente_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECLIENTE_Collapsed", StringUtil.BoolToStr( Dvpanel_tablecliente_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECLIENTE_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tablecliente_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECLIENTE_Iconposition", StringUtil.RTrim( Dvpanel_tablecliente_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECLIENTE_Autoscroll", StringUtil.BoolToStr( Dvpanel_tablecliente_Autoscroll));
         GxWebStd.gx_hidden_field( context, "COMBO_CPJCONTIPOID_Objectcall", StringUtil.RTrim( Combo_cpjcontipoid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_CPJCONTIPOID_Cls", StringUtil.RTrim( Combo_cpjcontipoid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_CPJCONTIPOID_Selectedvalue_set", StringUtil.RTrim( Combo_cpjcontipoid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_CPJCONTIPOID_Enabled", StringUtil.BoolToStr( Combo_cpjcontipoid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_CPJCONTIPOID_Emptyitem", StringUtil.BoolToStr( Combo_cpjcontipoid_Emptyitem));
         GxWebStd.gx_hidden_field( context, "COMBO_CPJCONTIPOID_Includeaddnewoption", StringUtil.BoolToStr( Combo_cpjcontipoid_Includeaddnewoption));
         GxWebStd.gx_hidden_field( context, "COMBO_CPJCONGENID_Objectcall", StringUtil.RTrim( Combo_cpjcongenid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_CPJCONGENID_Cls", StringUtil.RTrim( Combo_cpjcongenid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_CPJCONGENID_Selectedvalue_set", StringUtil.RTrim( Combo_cpjcongenid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_CPJCONGENID_Enabled", StringUtil.BoolToStr( Combo_cpjcongenid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_CPJCONGENID_Includeaddnewoption", StringUtil.BoolToStr( Combo_cpjcongenid_Includeaddnewoption));
         GxWebStd.gx_hidden_field( context, "COMBO_CPJCONGENID_Emptyitemtext", StringUtil.RTrim( Combo_cpjcongenid_Emptyitemtext));
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
         GXEncryptionTmp = "core.clientepjcontato.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV7CliID.ToString()) + "," + UrlEncode(AV8CpjID.ToString()) + "," + UrlEncode(StringUtil.LTrimStr(AV37CpjConSeq,4,0));
         return formatLink("core.clientepjcontato.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "core.ClientePJContato" ;
      }

      public override string GetPgmdesc( )
      {
         return "Contato" ;
      }

      protected void InitializeNonKey1032( )
      {
         A270CpjConTipoID = 0;
         AssignAttri("", false, "A270CpjConTipoID", StringUtil.LTrimStr( (decimal)(A270CpjConTipoID), 9, 0));
         A279CpjConGenID = 0;
         AssignAttri("", false, "A279CpjConGenID", StringUtil.LTrimStr( (decimal)(A279CpjConGenID), 9, 0));
         AV47AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
         A268CpjUltConSeq = 0;
         n268CpjUltConSeq = false;
         AssignAttri("", false, "A268CpjUltConSeq", StringUtil.LTrimStr( (decimal)(A268CpjUltConSeq), 4, 0));
         A549CpjConDelDataHora = (DateTime)(DateTime.MinValue);
         n549CpjConDelDataHora = false;
         AssignAttri("", false, "A549CpjConDelDataHora", context.localUtil.TToC( A549CpjConDelDataHora, 10, 12, 0, 3, "/", ":", " "));
         A550CpjConDelData = (DateTime)(DateTime.MinValue);
         n550CpjConDelData = false;
         AssignAttri("", false, "A550CpjConDelData", context.localUtil.TToC( A550CpjConDelData, 10, 5, 0, 3, "/", ":", " "));
         A551CpjConDelHora = (DateTime)(DateTime.MinValue);
         n551CpjConDelHora = false;
         AssignAttri("", false, "A551CpjConDelHora", context.localUtil.TToC( A551CpjConDelHora, 0, 5, 0, 3, "/", ":", " "));
         A552CpjConDelUsuId = "";
         n552CpjConDelUsuId = false;
         AssignAttri("", false, "A552CpjConDelUsuId", A552CpjConDelUsuId);
         A553CpjConDelUsuNome = "";
         n553CpjConDelUsuNome = false;
         AssignAttri("", false, "A553CpjConDelUsuNome", A553CpjConDelUsuNome);
         A159CliMatricula = 0;
         AssignAttri("", false, "A159CliMatricula", StringUtil.LTrimStr( (decimal)(A159CliMatricula), 12, 0));
         A160CliNomeFamiliar = "";
         AssignAttri("", false, "A160CliNomeFamiliar", A160CliNomeFamiliar);
         A365CpjTipoId = 0;
         AssignAttri("", false, "A365CpjTipoId", StringUtil.LTrimStr( (decimal)(A365CpjTipoId), 9, 0));
         A366CpjTipoSigla = "";
         AssignAttri("", false, "A366CpjTipoSigla", A366CpjTipoSigla);
         A367CpjTipoNome = "";
         AssignAttri("", false, "A367CpjTipoNome", A367CpjTipoNome);
         A170CpjNomeFan = "";
         AssignAttri("", false, "A170CpjNomeFan", A170CpjNomeFan);
         A171CpjRazaoSoc = "";
         AssignAttri("", false, "A171CpjRazaoSoc", A171CpjRazaoSoc);
         A176CpjMatricula = 0;
         AssignAttri("", false, "A176CpjMatricula", StringUtil.LTrimStr( (decimal)(A176CpjMatricula), 12, 0));
         A187CpjCNPJ = 0;
         AssignAttri("", false, "A187CpjCNPJ", StringUtil.LTrimStr( (decimal)(A187CpjCNPJ), 14, 0));
         A188CpjCNPJFormat = "";
         AssignAttri("", false, "A188CpjCNPJFormat", A188CpjCNPJFormat);
         A189CpjIE = "";
         AssignAttri("", false, "A189CpjIE", A189CpjIE);
         A207CpjAtivo = false;
         AssignAttri("", false, "A207CpjAtivo", A207CpjAtivo);
         A261CpjTelNum = "";
         n261CpjTelNum = false;
         AssignAttri("", false, "A261CpjTelNum", A261CpjTelNum);
         A262CpjTelRam = "";
         n262CpjTelRam = false;
         AssignAttri("", false, "A262CpjTelRam", A262CpjTelRam);
         A263CpjCelNum = "";
         n263CpjCelNum = false;
         AssignAttri("", false, "A263CpjCelNum", A263CpjCelNum);
         A264CpjWppNum = "";
         n264CpjWppNum = false;
         AssignAttri("", false, "A264CpjWppNum", A264CpjWppNum);
         A265CpjWebsite = "";
         n265CpjWebsite = false;
         AssignAttri("", false, "A265CpjWebsite", A265CpjWebsite);
         A266CpjEmail = "";
         n266CpjEmail = false;
         AssignAttri("", false, "A266CpjEmail", A266CpjEmail);
         A271CpjConTipoSigla = "";
         AssignAttri("", false, "A271CpjConTipoSigla", A271CpjConTipoSigla);
         A272CpjConTipoNome = "";
         AssignAttri("", false, "A272CpjConTipoNome", A272CpjConTipoNome);
         A273CpjConCPF = 0;
         AssignAttri("", false, "A273CpjConCPF", StringUtil.LTrimStr( (decimal)(A273CpjConCPF), 11, 0));
         A274CpjConCPFFormat = "";
         AssignAttri("", false, "A274CpjConCPFFormat", A274CpjConCPFFormat);
         A275CpjConNome = "";
         AssignAttri("", false, "A275CpjConNome", A275CpjConNome);
         A276CpjConNomePrim = "";
         AssignAttri("", false, "A276CpjConNomePrim", A276CpjConNomePrim);
         A277CpjConSobrenome = "";
         AssignAttri("", false, "A277CpjConSobrenome", A277CpjConSobrenome);
         A278CpjNomeSocial = "";
         AssignAttri("", false, "A278CpjNomeSocial", A278CpjNomeSocial);
         A280CpjConGenSigla = "";
         AssignAttri("", false, "A280CpjConGenSigla", A280CpjConGenSigla);
         A281CpjConGenNome = "";
         AssignAttri("", false, "A281CpjConGenNome", A281CpjConGenNome);
         A282CpjConNascimento = DateTime.MinValue;
         AssignAttri("", false, "A282CpjConNascimento", context.localUtil.Format(A282CpjConNascimento, "99/99/99"));
         A283CpjConTelNum = "";
         n283CpjConTelNum = false;
         AssignAttri("", false, "A283CpjConTelNum", A283CpjConTelNum);
         n283CpjConTelNum = (String.IsNullOrEmpty(StringUtil.RTrim( A283CpjConTelNum)) ? true : false);
         A284CpjConTelRam = "";
         n284CpjConTelRam = false;
         AssignAttri("", false, "A284CpjConTelRam", A284CpjConTelRam);
         n284CpjConTelRam = (String.IsNullOrEmpty(StringUtil.RTrim( A284CpjConTelRam)) ? true : false);
         A285CpjConCelNum = "";
         n285CpjConCelNum = false;
         AssignAttri("", false, "A285CpjConCelNum", A285CpjConCelNum);
         n285CpjConCelNum = (String.IsNullOrEmpty(StringUtil.RTrim( A285CpjConCelNum)) ? true : false);
         A286CpjConWppNum = "";
         n286CpjConWppNum = false;
         AssignAttri("", false, "A286CpjConWppNum", A286CpjConWppNum);
         n286CpjConWppNum = (String.IsNullOrEmpty(StringUtil.RTrim( A286CpjConWppNum)) ? true : false);
         A287CpjConEmail = "";
         n287CpjConEmail = false;
         AssignAttri("", false, "A287CpjConEmail", A287CpjConEmail);
         n287CpjConEmail = (String.IsNullOrEmpty(StringUtil.RTrim( A287CpjConEmail)) ? true : false);
         A288CpjConLIn = "";
         n288CpjConLIn = false;
         AssignAttri("", false, "A288CpjConLIn", A288CpjConLIn);
         n288CpjConLIn = (String.IsNullOrEmpty(StringUtil.RTrim( A288CpjConLIn)) ? true : false);
         A328CpjConUltEnd = 0;
         n328CpjConUltEnd = false;
         AssignAttri("", false, "A328CpjConUltEnd", StringUtil.LTrimStr( (decimal)(A328CpjConUltEnd), 4, 0));
         n328CpjConUltEnd = ((0==A328CpjConUltEnd) ? true : false);
         A548CpjConDel = false;
         AssignAttri("", false, "A548CpjConDel", A548CpjConDel);
         O548CpjConDel = A548CpjConDel;
         AssignAttri("", false, "A548CpjConDel", A548CpjConDel);
         O268CpjUltConSeq = A268CpjUltConSeq;
         n268CpjUltConSeq = false;
         AssignAttri("", false, "A268CpjUltConSeq", StringUtil.LTrimStr( (decimal)(A268CpjUltConSeq), 4, 0));
         Z549CpjConDelDataHora = (DateTime)(DateTime.MinValue);
         Z550CpjConDelData = (DateTime)(DateTime.MinValue);
         Z551CpjConDelHora = (DateTime)(DateTime.MinValue);
         Z552CpjConDelUsuId = "";
         Z553CpjConDelUsuNome = "";
         Z273CpjConCPF = 0;
         Z274CpjConCPFFormat = "";
         Z275CpjConNome = "";
         Z276CpjConNomePrim = "";
         Z277CpjConSobrenome = "";
         Z278CpjNomeSocial = "";
         Z282CpjConNascimento = DateTime.MinValue;
         Z283CpjConTelNum = "";
         Z284CpjConTelRam = "";
         Z285CpjConCelNum = "";
         Z286CpjConWppNum = "";
         Z287CpjConEmail = "";
         Z288CpjConLIn = "";
         Z328CpjConUltEnd = 0;
         Z548CpjConDel = false;
         Z270CpjConTipoID = 0;
         Z279CpjConGenID = 0;
         Z170CpjNomeFan = "";
         Z171CpjRazaoSoc = "";
         Z176CpjMatricula = 0;
         Z187CpjCNPJ = 0;
         Z188CpjCNPJFormat = "";
         Z189CpjIE = "";
         Z207CpjAtivo = false;
         Z261CpjTelNum = "";
         Z262CpjTelRam = "";
         Z263CpjCelNum = "";
         Z264CpjWppNum = "";
         Z265CpjWebsite = "";
         Z266CpjEmail = "";
         Z365CpjTipoId = 0;
      }

      protected void InitAll1032( )
      {
         A158CliID = Guid.Empty;
         AssignAttri("", false, "A158CliID", A158CliID.ToString());
         A166CpjID = Guid.Empty;
         AssignAttri("", false, "A166CpjID", A166CpjID.ToString());
         A269CpjConSeq = 0;
         AssignAttri("", false, "A269CpjConSeq", StringUtil.LTrimStr( (decimal)(A269CpjConSeq), 4, 0));
         InitializeNonKey1032( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2023828144689", true, true);
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
         context.AddJavascriptSource("core/clientepjcontato.js", "?2023828144691", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         lblTextblockcliid_Internalname = "TEXTBLOCKCLIID";
         Combo_cliid_Internalname = "COMBO_CLIID";
         edtCliID_Internalname = "CLIID";
         divTablesplittedcliid_Internalname = "TABLESPLITTEDCLIID";
         lblTxtesp01_Internalname = "TXTESP01";
         lblTextblockcpjid_Internalname = "TEXTBLOCKCPJID";
         Combo_cpjid_Internalname = "COMBO_CPJID";
         edtCpjID_Internalname = "CPJID";
         divTablesplittedcpjid_Internalname = "TABLESPLITTEDCPJID";
         edtCpjTipoId_Internalname = "CPJTIPOID";
         edtCpjMatricula_Internalname = "CPJMATRICULA";
         edtCpjTelNum_Internalname = "CPJTELNUM";
         edtCpjTelRam_Internalname = "CPJTELRAM";
         edtCpjCelNum_Internalname = "CPJCELNUM";
         edtCpjWppNum_Internalname = "CPJWPPNUM";
         edtCpjWebsite_Internalname = "CPJWEBSITE";
         edtCpjEmail_Internalname = "CPJEMAIL";
         divTablecliente_Internalname = "TABLECLIENTE";
         Dvpanel_tablecliente_Internalname = "DVPANEL_TABLECLIENTE";
         lblTextblockcpjcontipoid_Internalname = "TEXTBLOCKCPJCONTIPOID";
         Combo_cpjcontipoid_Internalname = "COMBO_CPJCONTIPOID";
         edtCpjConTipoID_Internalname = "CPJCONTIPOID";
         divTablesplittedcpjcontipoid_Internalname = "TABLESPLITTEDCPJCONTIPOID";
         edtCpjConNome_Internalname = "CPJCONNOME";
         edtCpjConCPFFormat_Internalname = "CPJCONCPFFORMAT";
         edtCpjConNascimento_Internalname = "CPJCONNASCIMENTO";
         edtCpjNomeSocial_Internalname = "CPJNOMESOCIAL";
         lblTextblockcpjcongenid_Internalname = "TEXTBLOCKCPJCONGENID";
         Combo_cpjcongenid_Internalname = "COMBO_CPJCONGENID";
         edtCpjConGenID_Internalname = "CPJCONGENID";
         divTablesplittedcpjcongenid_Internalname = "TABLESPLITTEDCPJCONGENID";
         edtCpjConCelNum_Internalname = "CPJCONCELNUM";
         edtCpjConWppNum_Internalname = "CPJCONWPPNUM";
         edtCpjConTelNum_Internalname = "CPJCONTELNUM";
         edtCpjConTelRam_Internalname = "CPJCONTELRAM";
         edtCpjConEmail_Internalname = "CPJCONEMAIL";
         edtCpjConLIn_Internalname = "CPJCONLIN";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         divTablemain_Internalname = "TABLEMAIN";
         edtavCombocliid_Internalname = "vCOMBOCLIID";
         divSectionattribute_cliid_Internalname = "SECTIONATTRIBUTE_CLIID";
         edtavCombocpjid_Internalname = "vCOMBOCPJID";
         divSectionattribute_cpjid_Internalname = "SECTIONATTRIBUTE_CPJID";
         edtavCombocpjcontipoid_Internalname = "vCOMBOCPJCONTIPOID";
         divSectionattribute_cpjcontipoid_Internalname = "SECTIONATTRIBUTE_CPJCONTIPOID";
         edtavCombocpjcongenid_Internalname = "vCOMBOCPJCONGENID";
         divSectionattribute_cpjcongenid_Internalname = "SECTIONATTRIBUTE_CPJCONGENID";
         edtCpjConSeq_Internalname = "CPJCONSEQ";
         edtCpjConTipoSigla_Internalname = "CPJCONTIPOSIGLA";
         edtCpjConCPF_Internalname = "CPJCONCPF";
         edtCpjConNomePrim_Internalname = "CPJCONNOMEPRIM";
         edtCpjConSobrenome_Internalname = "CPJCONSOBRENOME";
         edtCpjConUltEnd_Internalname = "CPJCONULTEND";
         edtCpjCNPJ_Internalname = "CPJCNPJ";
         edtCpjAtivo_Internalname = "CPJATIVO";
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
         Form.Caption = "Contato";
         Combo_cpjid_Datalistprocparametersprefix = "";
         Combo_cliid_Htmltemplate = "";
         Combo_cpjid_Htmltemplate = "";
         edtCpjAtivo_Jsonclick = "";
         edtCpjAtivo_Enabled = 0;
         edtCpjAtivo_Visible = 1;
         edtCpjCNPJ_Jsonclick = "";
         edtCpjCNPJ_Enabled = 0;
         edtCpjCNPJ_Visible = 1;
         edtCpjConUltEnd_Jsonclick = "";
         edtCpjConUltEnd_Enabled = 1;
         edtCpjConUltEnd_Visible = 1;
         edtCpjConSobrenome_Jsonclick = "";
         edtCpjConSobrenome_Enabled = 1;
         edtCpjConSobrenome_Visible = 1;
         edtCpjConNomePrim_Jsonclick = "";
         edtCpjConNomePrim_Enabled = 1;
         edtCpjConNomePrim_Visible = 1;
         edtCpjConCPF_Jsonclick = "";
         edtCpjConCPF_Enabled = 1;
         edtCpjConCPF_Visible = 1;
         edtCpjConTipoSigla_Jsonclick = "";
         edtCpjConTipoSigla_Enabled = 0;
         edtCpjConTipoSigla_Visible = 1;
         edtCpjConSeq_Jsonclick = "";
         edtCpjConSeq_Enabled = 1;
         edtCpjConSeq_Visible = 1;
         edtavCombocpjcongenid_Jsonclick = "";
         edtavCombocpjcongenid_Enabled = 0;
         edtavCombocpjcongenid_Visible = 1;
         edtavCombocpjcontipoid_Jsonclick = "";
         edtavCombocpjcontipoid_Enabled = 0;
         edtavCombocpjcontipoid_Visible = 1;
         edtavCombocpjid_Jsonclick = "";
         edtavCombocpjid_Enabled = 0;
         edtavCombocpjid_Visible = 1;
         edtavCombocliid_Jsonclick = "";
         edtavCombocliid_Enabled = 0;
         edtavCombocliid_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtCpjConLIn_Jsonclick = "";
         edtCpjConLIn_Enabled = 1;
         edtCpjConEmail_Jsonclick = "";
         edtCpjConEmail_Enabled = 1;
         edtCpjConTelRam_Jsonclick = "";
         edtCpjConTelRam_Enabled = 1;
         edtCpjConTelNum_Jsonclick = "";
         edtCpjConTelNum_Enabled = 1;
         edtCpjConWppNum_Jsonclick = "";
         edtCpjConWppNum_Enabled = 1;
         edtCpjConCelNum_Jsonclick = "";
         edtCpjConCelNum_Enabled = 1;
         edtCpjConGenID_Jsonclick = "";
         edtCpjConGenID_Enabled = 1;
         edtCpjConGenID_Visible = 1;
         Combo_cpjcongenid_Emptyitemtext = "";
         Combo_cpjcongenid_Includeaddnewoption = Convert.ToBoolean( -1);
         Combo_cpjcongenid_Cls = "ExtendedCombo AttributeFL";
         Combo_cpjcongenid_Caption = "";
         Combo_cpjcongenid_Enabled = Convert.ToBoolean( -1);
         edtCpjNomeSocial_Jsonclick = "";
         edtCpjNomeSocial_Enabled = 1;
         edtCpjConNascimento_Jsonclick = "";
         edtCpjConNascimento_Enabled = 1;
         edtCpjConCPFFormat_Jsonclick = "";
         edtCpjConCPFFormat_Enabled = 1;
         edtCpjConNome_Jsonclick = "";
         edtCpjConNome_Enabled = 1;
         edtCpjConTipoID_Jsonclick = "";
         edtCpjConTipoID_Enabled = 1;
         edtCpjConTipoID_Visible = 1;
         Combo_cpjcontipoid_Includeaddnewoption = Convert.ToBoolean( -1);
         Combo_cpjcontipoid_Emptyitem = Convert.ToBoolean( 0);
         Combo_cpjcontipoid_Cls = "ExtendedCombo AttributeFL";
         Combo_cpjcontipoid_Caption = "";
         Combo_cpjcontipoid_Enabled = Convert.ToBoolean( -1);
         Dvpanel_tableattributes_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Iconposition = "Right";
         Dvpanel_tableattributes_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Title = "Informe os dados do contato abaixo";
         Dvpanel_tableattributes_Cls = "PanelCard_IconAndTitle Panel_BaseColor";
         Dvpanel_tableattributes_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tableattributes_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Width = "100%";
         edtCpjEmail_Jsonclick = "";
         edtCpjEmail_Enabled = 0;
         edtCpjWebsite_Jsonclick = "";
         edtCpjWebsite_Enabled = 0;
         edtCpjWppNum_Jsonclick = "";
         edtCpjWppNum_Enabled = 0;
         edtCpjCelNum_Jsonclick = "";
         edtCpjCelNum_Enabled = 0;
         edtCpjTelRam_Jsonclick = "";
         edtCpjTelRam_Enabled = 0;
         edtCpjTelNum_Jsonclick = "";
         edtCpjTelNum_Enabled = 0;
         edtCpjMatricula_Jsonclick = "";
         edtCpjMatricula_Enabled = 0;
         edtCpjTipoId_Jsonclick = "";
         edtCpjTipoId_Enabled = 0;
         edtCpjID_Jsonclick = "";
         edtCpjID_Enabled = 0;
         edtCpjID_Visible = 1;
         Combo_cpjid_Emptyitem = Convert.ToBoolean( 0);
         Combo_cpjid_Datalistproc = "core.ClientePJContatoLoadDVCombo";
         Combo_cpjid_Cls = "ExtendedCombo AttributeFL ExtendedComboTitleAndSubtitle";
         Combo_cpjid_Caption = "";
         Combo_cpjid_Enabled = Convert.ToBoolean( -1);
         edtCliID_Jsonclick = "";
         edtCliID_Enabled = 0;
         edtCliID_Visible = 1;
         Combo_cliid_Emptyitem = Convert.ToBoolean( 0);
         Combo_cliid_Cls = "ExtendedCombo AttributeFL ExtendedComboTitleAndSubtitle";
         Combo_cliid_Caption = "";
         Combo_cliid_Enabled = Convert.ToBoolean( -1);
         Dvpanel_tablecliente_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tablecliente_Iconposition = "Right";
         Dvpanel_tablecliente_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tablecliente_Collapsed = Convert.ToBoolean( 1);
         Dvpanel_tablecliente_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_tablecliente_Title = "[!CLIENTE!]. Unidade [!UNIDADE!] ([!UNIDADE_TIPO!])";
         Dvpanel_tablecliente_Cls = "PanelCard_IconAndTitle Panel_BaseColor";
         Dvpanel_tablecliente_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tablecliente_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tablecliente_Width = "100%";
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

      protected void XC_35_1032( GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV47AuditingObject ,
                                 Guid A158CliID ,
                                 Guid A166CpjID ,
                                 short A269CpjConSeq ,
                                 string Gx_mode )
      {
         new GeneXus.Programs.core.loadauditclientepjcontato(context ).execute(  "Y", ref  AV47AuditingObject,  A158CliID,  A166CpjID,  A269CpjConSeq,  Gx_mode) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.EncodeString( AV47AuditingObject.ToXml(false, true, "", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_36_1032( GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV47AuditingObject ,
                                 Guid A158CliID ,
                                 Guid A166CpjID ,
                                 short A269CpjConSeq ,
                                 string Gx_mode )
      {
         new GeneXus.Programs.core.loadauditclientepjcontato(context ).execute(  "Y", ref  AV47AuditingObject,  A158CliID,  A166CpjID,  A269CpjConSeq,  Gx_mode) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.EncodeString( AV47AuditingObject.ToXml(false, true, "", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_37_1032( string Gx_mode ,
                                 GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV47AuditingObject ,
                                 Guid A158CliID ,
                                 Guid A166CpjID ,
                                 short A269CpjConSeq )
      {
         if ( IsIns( )  )
         {
            new GeneXus.Programs.core.loadauditclientepjcontato(context ).execute(  "N", ref  AV47AuditingObject,  A158CliID,  A166CpjID,  A269CpjConSeq,  Gx_mode) ;
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.EncodeString( AV47AuditingObject.ToXml(false, true, "", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_38_1032( string Gx_mode ,
                                 GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV47AuditingObject ,
                                 Guid A158CliID ,
                                 Guid A166CpjID ,
                                 short A269CpjConSeq )
      {
         if ( IsUpd( )  )
         {
            new GeneXus.Programs.core.loadauditclientepjcontato(context ).execute(  "N", ref  AV47AuditingObject,  A158CliID,  A166CpjID,  A269CpjConSeq,  Gx_mode) ;
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.EncodeString( AV47AuditingObject.ToXml(false, true, "", "")))+"\"") ;
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

      public void Valid_Cliid( )
      {
         /* Using cursor T001023 */
         pr_default.execute(21, new Object[] {A158CliID});
         if ( (pr_default.getStatus(21) == 101) )
         {
            GX_msglist.addItem("Não existe ''.", "ForeignKeyNotFound", 1, "CLIID");
            AnyError = 1;
            GX_FocusControl = edtCliID_Internalname;
         }
         A159CliMatricula = T001023_A159CliMatricula[0];
         A160CliNomeFamiliar = T001023_A160CliNomeFamiliar[0];
         pr_default.close(21);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A159CliMatricula", StringUtil.LTrim( StringUtil.NToC( (decimal)(A159CliMatricula), 12, 0, ".", "")));
         AssignAttri("", false, "A160CliNomeFamiliar", A160CliNomeFamiliar);
      }

      public void Valid_Cpjid( )
      {
         n268CpjUltConSeq = false;
         n261CpjTelNum = false;
         n262CpjTelRam = false;
         n263CpjCelNum = false;
         n264CpjWppNum = false;
         n265CpjWebsite = false;
         n266CpjEmail = false;
         /* Using cursor T001024 */
         pr_default.execute(22, new Object[] {A158CliID, A166CpjID});
         Z170CpjNomeFan = T001024_A170CpjNomeFan[0];
         Z171CpjRazaoSoc = T001024_A171CpjRazaoSoc[0];
         Z176CpjMatricula = T001024_A176CpjMatricula[0];
         Z187CpjCNPJ = T001024_A187CpjCNPJ[0];
         Z188CpjCNPJFormat = T001024_A188CpjCNPJFormat[0];
         Z189CpjIE = T001024_A189CpjIE[0];
         Z207CpjAtivo = T001024_A207CpjAtivo[0];
         Z261CpjTelNum = T001024_A261CpjTelNum[0];
         Z262CpjTelRam = T001024_A262CpjTelRam[0];
         Z263CpjCelNum = T001024_A263CpjCelNum[0];
         Z264CpjWppNum = T001024_A264CpjWppNum[0];
         Z265CpjWebsite = T001024_A265CpjWebsite[0];
         Z266CpjEmail = T001024_A266CpjEmail[0];
         Z365CpjTipoId = T001024_A365CpjTipoId[0];
         if ( (pr_default.getStatus(22) == 101) )
         {
            GX_msglist.addItem("Não existe ''.", "ForeignKeyNotFound", 1, "CPJID");
            AnyError = 1;
            GX_FocusControl = edtCliID_Internalname;
         }
         A268CpjUltConSeq = T001024_A268CpjUltConSeq[0];
         n268CpjUltConSeq = T001024_n268CpjUltConSeq[0];
         A170CpjNomeFan = T001024_A170CpjNomeFan[0];
         A171CpjRazaoSoc = T001024_A171CpjRazaoSoc[0];
         A176CpjMatricula = T001024_A176CpjMatricula[0];
         A187CpjCNPJ = T001024_A187CpjCNPJ[0];
         A188CpjCNPJFormat = T001024_A188CpjCNPJFormat[0];
         A189CpjIE = T001024_A189CpjIE[0];
         A207CpjAtivo = T001024_A207CpjAtivo[0];
         A261CpjTelNum = T001024_A261CpjTelNum[0];
         n261CpjTelNum = T001024_n261CpjTelNum[0];
         A262CpjTelRam = T001024_A262CpjTelRam[0];
         n262CpjTelRam = T001024_n262CpjTelRam[0];
         A263CpjCelNum = T001024_A263CpjCelNum[0];
         n263CpjCelNum = T001024_n263CpjCelNum[0];
         A264CpjWppNum = T001024_A264CpjWppNum[0];
         n264CpjWppNum = T001024_n264CpjWppNum[0];
         A265CpjWebsite = T001024_A265CpjWebsite[0];
         n265CpjWebsite = T001024_n265CpjWebsite[0];
         A266CpjEmail = T001024_A266CpjEmail[0];
         n266CpjEmail = T001024_n266CpjEmail[0];
         A365CpjTipoId = T001024_A365CpjTipoId[0];
         O268CpjUltConSeq = A268CpjUltConSeq;
         n268CpjUltConSeq = false;
         pr_default.close(22);
         if ( IsIns( )  )
         {
            A268CpjUltConSeq = (short)(O268CpjUltConSeq+1);
            n268CpjUltConSeq = false;
         }
         /* Using cursor T001025 */
         pr_default.execute(23, new Object[] {A365CpjTipoId});
         if ( (pr_default.getStatus(23) == 101) )
         {
            GX_msglist.addItem("Não existe 'Cliente PJ -> Cliente PJ Tipo'.", "ForeignKeyNotFound", 1, "CPJTIPOID");
            AnyError = 1;
         }
         A366CpjTipoSigla = T001025_A366CpjTipoSigla[0];
         A367CpjTipoNome = T001025_A367CpjTipoNome[0];
         pr_default.close(23);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "O268CpjUltConSeq", StringUtil.LTrim( StringUtil.NToC( (decimal)(O268CpjUltConSeq), 4, 0, ",", "")));
         AssignAttri("", false, "A268CpjUltConSeq", StringUtil.LTrim( StringUtil.NToC( (decimal)(A268CpjUltConSeq), 4, 0, ".", "")));
         AssignAttri("", false, "A170CpjNomeFan", A170CpjNomeFan);
         AssignAttri("", false, "A171CpjRazaoSoc", A171CpjRazaoSoc);
         AssignAttri("", false, "A176CpjMatricula", StringUtil.LTrim( StringUtil.NToC( (decimal)(A176CpjMatricula), 12, 0, ".", "")));
         AssignAttri("", false, "A187CpjCNPJ", StringUtil.LTrim( StringUtil.NToC( (decimal)(A187CpjCNPJ), 14, 0, ".", "")));
         AssignAttri("", false, "A188CpjCNPJFormat", A188CpjCNPJFormat);
         AssignAttri("", false, "A189CpjIE", A189CpjIE);
         AssignAttri("", false, "A207CpjAtivo", A207CpjAtivo);
         AssignAttri("", false, "A261CpjTelNum", StringUtil.RTrim( A261CpjTelNum));
         AssignAttri("", false, "A262CpjTelRam", A262CpjTelRam);
         AssignAttri("", false, "A263CpjCelNum", StringUtil.RTrim( A263CpjCelNum));
         AssignAttri("", false, "A264CpjWppNum", StringUtil.RTrim( A264CpjWppNum));
         AssignAttri("", false, "A265CpjWebsite", A265CpjWebsite);
         AssignAttri("", false, "A266CpjEmail", A266CpjEmail);
         AssignAttri("", false, "A365CpjTipoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A365CpjTipoId), 9, 0, ".", "")));
         AssignAttri("", false, "A269CpjConSeq", StringUtil.LTrim( StringUtil.NToC( (decimal)(A269CpjConSeq), 4, 0, ".", "")));
         AssignAttri("", false, "A366CpjTipoSigla", A366CpjTipoSigla);
         AssignAttri("", false, "A367CpjTipoNome", A367CpjTipoNome);
      }

      public void Valid_Cpjcontipoid( )
      {
         /* Using cursor T001026 */
         pr_default.execute(24, new Object[] {A270CpjConTipoID});
         if ( (pr_default.getStatus(24) == 101) )
         {
            GX_msglist.addItem("Não existe 'Tipo Cliente PJ -> Contato Cliente PJ'.", "ForeignKeyNotFound", 1, "CPJCONTIPOID");
            AnyError = 1;
            GX_FocusControl = edtCpjConTipoID_Internalname;
         }
         A271CpjConTipoSigla = T001026_A271CpjConTipoSigla[0];
         A272CpjConTipoNome = T001026_A272CpjConTipoNome[0];
         pr_default.close(24);
         if ( (0==A270CpjConTipoID) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Tipo do Contato", "", "", "", "", "", "", "", ""), 1, "CPJCONTIPOID");
            AnyError = 1;
            GX_FocusControl = edtCpjConTipoID_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A271CpjConTipoSigla", A271CpjConTipoSigla);
         AssignAttri("", false, "A272CpjConTipoNome", A272CpjConTipoNome);
      }

      public void Valid_Cpjcongenid( )
      {
         /* Using cursor T001027 */
         pr_default.execute(25, new Object[] {A279CpjConGenID});
         if ( (pr_default.getStatus(25) == 101) )
         {
            GX_msglist.addItem("Não existe 'Genero -> Contato Cliente PJ'.", "ForeignKeyNotFound", 1, "CPJCONGENID");
            AnyError = 1;
            GX_FocusControl = edtCpjConGenID_Internalname;
         }
         A280CpjConGenSigla = T001027_A280CpjConGenSigla[0];
         A281CpjConGenNome = T001027_A281CpjConGenNome[0];
         pr_default.close(25);
         if ( (0==A279CpjConGenID) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Gênero ID", "", "", "", "", "", "", "", ""), 1, "CPJCONGENID");
            AnyError = 1;
            GX_FocusControl = edtCpjConGenID_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A280CpjConGenSigla", A280CpjConGenSigla);
         AssignAttri("", false, "A281CpjConGenNome", A281CpjConGenNome);
      }

      public void Valid_Cpjconcpf( )
      {
         /* Using cursor T001031 */
         pr_default.execute(29, new Object[] {A158CliID, A166CpjID, A273CpjConCPF, A269CpjConSeq});
         if ( (pr_default.getStatus(29) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"ID"+","+"ID"+","+"CPF"}), 1, "CLIID");
            AnyError = 1;
            GX_FocusControl = edtCliID_Internalname;
         }
         pr_default.close(29);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7CliID',fld:'vCLIID',pic:'',hsh:true},{av:'AV8CpjID',fld:'vCPJID',pic:'',hsh:true},{av:'AV37CpjConSeq',fld:'vCPJCONSEQ',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV12TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7CliID',fld:'vCLIID',pic:'',hsh:true},{av:'AV8CpjID',fld:'vCPJID',pic:'',hsh:true},{av:'AV37CpjConSeq',fld:'vCPJCONSEQ',pic:'ZZZ9',hsh:true},{av:'A158CliID',fld:'CLIID',pic:''},{av:'A166CpjID',fld:'CPJID',pic:''},{av:'AV49Pgmname',fld:'vPGMNAME',pic:''},{av:'A548CpjConDel',fld:'CPJCONDEL',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E16102',iparms:[{av:'AV47AuditingObject',fld:'vAUDITINGOBJECT',pic:''},{av:'AV49Pgmname',fld:'vPGMNAME',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV12TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("COMBO_CPJCONGENID.ONOPTIONCLICKED","{handler:'E15102',iparms:[{av:'Combo_cpjcongenid_Selectedvalue_get',ctrl:'COMBO_CPJCONGENID',prop:'SelectedValue_get'},{av:'A279CpjConGenID',fld:'CPJCONGENID',pic:'ZZZ,ZZZ,ZZ9'},{av:'AV7CliID',fld:'vCLIID',pic:'',hsh:true},{av:'AV8CpjID',fld:'vCPJID',pic:'',hsh:true},{av:'AV37CpjConSeq',fld:'vCPJCONSEQ',pic:'ZZZ9',hsh:true},{av:'A158CliID',fld:'CLIID',pic:''}]");
         setEventMetadata("COMBO_CPJCONGENID.ONOPTIONCLICKED",",oparms:[{av:'Combo_cpjcongenid_Selectedvalue_set',ctrl:'COMBO_CPJCONGENID',prop:'SelectedValue_set'},{av:'AV33CpjConGenID_Data',fld:'vCPJCONGENID_DATA',pic:''},{av:'AV42ComboCpjConGenID',fld:'vCOMBOCPJCONGENID',pic:'ZZZ,ZZZ,ZZ9'}]}");
         setEventMetadata("COMBO_CPJCONTIPOID.ONOPTIONCLICKED","{handler:'E14102',iparms:[{av:'Combo_cpjcontipoid_Selectedvalue_get',ctrl:'COMBO_CPJCONTIPOID',prop:'SelectedValue_get'},{av:'A270CpjConTipoID',fld:'CPJCONTIPOID',pic:'ZZZ,ZZZ,ZZ9'},{av:'AV7CliID',fld:'vCLIID',pic:'',hsh:true},{av:'AV8CpjID',fld:'vCPJID',pic:'',hsh:true},{av:'AV37CpjConSeq',fld:'vCPJCONSEQ',pic:'ZZZ9',hsh:true},{av:'A158CliID',fld:'CLIID',pic:''}]");
         setEventMetadata("COMBO_CPJCONTIPOID.ONOPTIONCLICKED",",oparms:[{av:'Combo_cpjcontipoid_Selectedvalue_set',ctrl:'COMBO_CPJCONTIPOID',prop:'SelectedValue_set'},{av:'AV32CpjConTipoID_Data',fld:'vCPJCONTIPOID_DATA',pic:''},{av:'AV40ComboCpjConTipoID',fld:'vCOMBOCPJCONTIPOID',pic:'ZZZ,ZZZ,ZZ9'}]}");
         setEventMetadata("COMBO_CPJID.ONOPTIONCLICKED","{handler:'E13102',iparms:[{av:'Combo_cpjid_Selectedvalue_get',ctrl:'COMBO_CPJID',prop:'SelectedValue_get'}]");
         setEventMetadata("COMBO_CPJID.ONOPTIONCLICKED",",oparms:[{av:'AV45ComboCpjID',fld:'vCOMBOCPJID',pic:''}]}");
         setEventMetadata("COMBO_CLIID.ONOPTIONCLICKED","{handler:'E12102',iparms:[{av:'A158CliID',fld:'CLIID',pic:''},{av:'Combo_cliid_Selectedvalue_get',ctrl:'COMBO_CLIID',prop:'SelectedValue_get'}]");
         setEventMetadata("COMBO_CLIID.ONOPTIONCLICKED",",oparms:[{av:'AV21ComboCliID',fld:'vCOMBOCLIID',pic:''},{av:'AV45ComboCpjID',fld:'vCOMBOCPJID',pic:''},{av:'Combo_cpjid_Selectedvalue_set',ctrl:'COMBO_CPJID',prop:'SelectedValue_set'},{av:'Combo_cpjid_Selectedtext_set',ctrl:'COMBO_CPJID',prop:'SelectedText_set'}]}");
         setEventMetadata("VALID_CLIID","{handler:'Valid_Cliid',iparms:[{av:'A158CliID',fld:'CLIID',pic:''},{av:'A159CliMatricula',fld:'CLIMATRICULA',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'A160CliNomeFamiliar',fld:'CLINOMEFAMILIAR',pic:'@!'}]");
         setEventMetadata("VALID_CLIID",",oparms:[{av:'A159CliMatricula',fld:'CLIMATRICULA',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'A160CliNomeFamiliar',fld:'CLINOMEFAMILIAR',pic:'@!'}]}");
         setEventMetadata("VALID_CPJID","{handler:'Valid_Cpjid',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'O268CpjUltConSeq'},{av:'A158CliID',fld:'CLIID',pic:''},{av:'A166CpjID',fld:'CPJID',pic:''},{av:'A268CpjUltConSeq',fld:'CPJULTCONSEQ',pic:'ZZZ9'},{av:'AV37CpjConSeq',fld:'vCPJCONSEQ',pic:'ZZZ9',hsh:true},{av:'Gx_BScreen',fld:'vGXBSCREEN',pic:'9'},{av:'A365CpjTipoId',fld:'CPJTIPOID',pic:'ZZZ,ZZZ,ZZ9'},{av:'A170CpjNomeFan',fld:'CPJNOMEFAN',pic:'@!'},{av:'A171CpjRazaoSoc',fld:'CPJRAZAOSOC',pic:'@!'},{av:'A176CpjMatricula',fld:'CPJMATRICULA',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'A187CpjCNPJ',fld:'CPJCNPJ',pic:'ZZZZZZZZZZZZZ9'},{av:'A188CpjCNPJFormat',fld:'CPJCNPJFORMAT',pic:''},{av:'A189CpjIE',fld:'CPJIE',pic:'@!'},{av:'A207CpjAtivo',fld:'CPJATIVO',pic:''},{av:'A261CpjTelNum',fld:'CPJTELNUM',pic:''},{av:'A262CpjTelRam',fld:'CPJTELRAM',pic:''},{av:'A263CpjCelNum',fld:'CPJCELNUM',pic:''},{av:'A264CpjWppNum',fld:'CPJWPPNUM',pic:''},{av:'A265CpjWebsite',fld:'CPJWEBSITE',pic:''},{av:'A266CpjEmail',fld:'CPJEMAIL',pic:''},{av:'A269CpjConSeq',fld:'CPJCONSEQ',pic:'ZZZ9'},{av:'A366CpjTipoSigla',fld:'CPJTIPOSIGLA',pic:''},{av:'A367CpjTipoNome',fld:'CPJTIPONOME',pic:'@!'}]");
         setEventMetadata("VALID_CPJID",",oparms:[{av:'O268CpjUltConSeq'},{av:'A268CpjUltConSeq',fld:'CPJULTCONSEQ',pic:'ZZZ9'},{av:'A170CpjNomeFan',fld:'CPJNOMEFAN',pic:'@!'},{av:'A171CpjRazaoSoc',fld:'CPJRAZAOSOC',pic:'@!'},{av:'A176CpjMatricula',fld:'CPJMATRICULA',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'A187CpjCNPJ',fld:'CPJCNPJ',pic:'ZZZZZZZZZZZZZ9'},{av:'A188CpjCNPJFormat',fld:'CPJCNPJFORMAT',pic:''},{av:'A189CpjIE',fld:'CPJIE',pic:'@!'},{av:'A207CpjAtivo',fld:'CPJATIVO',pic:''},{av:'A261CpjTelNum',fld:'CPJTELNUM',pic:''},{av:'A262CpjTelRam',fld:'CPJTELRAM',pic:''},{av:'A263CpjCelNum',fld:'CPJCELNUM',pic:''},{av:'A264CpjWppNum',fld:'CPJWPPNUM',pic:''},{av:'A265CpjWebsite',fld:'CPJWEBSITE',pic:''},{av:'A266CpjEmail',fld:'CPJEMAIL',pic:''},{av:'A365CpjTipoId',fld:'CPJTIPOID',pic:'ZZZ,ZZZ,ZZ9'},{av:'A269CpjConSeq',fld:'CPJCONSEQ',pic:'ZZZ9'},{av:'A366CpjTipoSigla',fld:'CPJTIPOSIGLA',pic:''},{av:'A367CpjTipoNome',fld:'CPJTIPONOME',pic:'@!'}]}");
         setEventMetadata("VALID_CPJTIPOID","{handler:'Valid_Cpjtipoid',iparms:[]");
         setEventMetadata("VALID_CPJTIPOID",",oparms:[]}");
         setEventMetadata("VALID_CPJCONTIPOID","{handler:'Valid_Cpjcontipoid',iparms:[{av:'A270CpjConTipoID',fld:'CPJCONTIPOID',pic:'ZZZ,ZZZ,ZZ9'},{av:'A271CpjConTipoSigla',fld:'CPJCONTIPOSIGLA',pic:''},{av:'A272CpjConTipoNome',fld:'CPJCONTIPONOME',pic:'@!'}]");
         setEventMetadata("VALID_CPJCONTIPOID",",oparms:[{av:'A271CpjConTipoSigla',fld:'CPJCONTIPOSIGLA',pic:''},{av:'A272CpjConTipoNome',fld:'CPJCONTIPONOME',pic:'@!'}]}");
         setEventMetadata("VALID_CPJCONNOME","{handler:'Valid_Cpjconnome',iparms:[]");
         setEventMetadata("VALID_CPJCONNOME",",oparms:[]}");
         setEventMetadata("VALID_CPJCONCPFFORMAT","{handler:'Valid_Cpjconcpfformat',iparms:[]");
         setEventMetadata("VALID_CPJCONCPFFORMAT",",oparms:[]}");
         setEventMetadata("VALID_CPJCONNASCIMENTO","{handler:'Valid_Cpjconnascimento',iparms:[]");
         setEventMetadata("VALID_CPJCONNASCIMENTO",",oparms:[]}");
         setEventMetadata("VALID_CPJNOMESOCIAL","{handler:'Valid_Cpjnomesocial',iparms:[]");
         setEventMetadata("VALID_CPJNOMESOCIAL",",oparms:[]}");
         setEventMetadata("VALID_CPJCONGENID","{handler:'Valid_Cpjcongenid',iparms:[{av:'A279CpjConGenID',fld:'CPJCONGENID',pic:'ZZZ,ZZZ,ZZ9'},{av:'A280CpjConGenSigla',fld:'CPJCONGENSIGLA',pic:''},{av:'A281CpjConGenNome',fld:'CPJCONGENNOME',pic:'@!'}]");
         setEventMetadata("VALID_CPJCONGENID",",oparms:[{av:'A280CpjConGenSigla',fld:'CPJCONGENSIGLA',pic:''},{av:'A281CpjConGenNome',fld:'CPJCONGENNOME',pic:'@!'}]}");
         setEventMetadata("VALID_CPJCONCELNUM","{handler:'Valid_Cpjconcelnum',iparms:[]");
         setEventMetadata("VALID_CPJCONCELNUM",",oparms:[]}");
         setEventMetadata("VALID_CPJCONEMAIL","{handler:'Valid_Cpjconemail',iparms:[]");
         setEventMetadata("VALID_CPJCONEMAIL",",oparms:[]}");
         setEventMetadata("VALID_CPJCONLIN","{handler:'Valid_Cpjconlin',iparms:[]");
         setEventMetadata("VALID_CPJCONLIN",",oparms:[]}");
         setEventMetadata("VALIDV_COMBOCLIID","{handler:'Validv_Combocliid',iparms:[]");
         setEventMetadata("VALIDV_COMBOCLIID",",oparms:[]}");
         setEventMetadata("VALIDV_COMBOCPJID","{handler:'Validv_Combocpjid',iparms:[]");
         setEventMetadata("VALIDV_COMBOCPJID",",oparms:[]}");
         setEventMetadata("VALIDV_COMBOCPJCONTIPOID","{handler:'Validv_Combocpjcontipoid',iparms:[]");
         setEventMetadata("VALIDV_COMBOCPJCONTIPOID",",oparms:[]}");
         setEventMetadata("VALIDV_COMBOCPJCONGENID","{handler:'Validv_Combocpjcongenid',iparms:[]");
         setEventMetadata("VALIDV_COMBOCPJCONGENID",",oparms:[]}");
         setEventMetadata("VALID_CPJCONSEQ","{handler:'Valid_Cpjconseq',iparms:[]");
         setEventMetadata("VALID_CPJCONSEQ",",oparms:[]}");
         setEventMetadata("VALID_CPJCONCPF","{handler:'Valid_Cpjconcpf',iparms:[{av:'A158CliID',fld:'CLIID',pic:''},{av:'A166CpjID',fld:'CPJID',pic:''},{av:'A273CpjConCPF',fld:'CPJCONCPF',pic:'ZZZZZZZZZZ9'},{av:'A269CpjConSeq',fld:'CPJCONSEQ',pic:'ZZZ9'}]");
         setEventMetadata("VALID_CPJCONCPF",",oparms:[]}");
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
         pr_default.close(21);
         pr_default.close(22);
         pr_default.close(24);
         pr_default.close(25);
         pr_default.close(23);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         wcpOAV7CliID = Guid.Empty;
         wcpOAV8CpjID = Guid.Empty;
         Z158CliID = Guid.Empty;
         Z166CpjID = Guid.Empty;
         Z549CpjConDelDataHora = (DateTime)(DateTime.MinValue);
         Z550CpjConDelData = (DateTime)(DateTime.MinValue);
         Z551CpjConDelHora = (DateTime)(DateTime.MinValue);
         Z552CpjConDelUsuId = "";
         Z553CpjConDelUsuNome = "";
         Z274CpjConCPFFormat = "";
         Z275CpjConNome = "";
         Z276CpjConNomePrim = "";
         Z277CpjConSobrenome = "";
         Z278CpjNomeSocial = "";
         Z282CpjConNascimento = DateTime.MinValue;
         Z283CpjConTelNum = "";
         Z284CpjConTelRam = "";
         Z285CpjConCelNum = "";
         Z286CpjConWppNum = "";
         Z287CpjConEmail = "";
         Z288CpjConLIn = "";
         Z170CpjNomeFan = "";
         Z171CpjRazaoSoc = "";
         Z188CpjCNPJFormat = "";
         Z189CpjIE = "";
         Z261CpjTelNum = "";
         Z262CpjTelRam = "";
         Z263CpjCelNum = "";
         Z264CpjWppNum = "";
         Z265CpjWebsite = "";
         Z266CpjEmail = "";
         Combo_cpjcongenid_Selectedvalue_get = "";
         Combo_cpjcontipoid_Selectedvalue_get = "";
         Combo_cpjid_Selectedvalue_get = "";
         Combo_cliid_Selectedvalue_get = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A158CliID = Guid.Empty;
         A166CpjID = Guid.Empty;
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tablecliente = new GXUserControl();
         lblTextblockcliid_Jsonclick = "";
         ucCombo_cliid = new GXUserControl();
         AV17DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV16CliID_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         lblTxtesp01_Jsonclick = "";
         lblTextblockcpjid_Jsonclick = "";
         ucCombo_cpjid = new GXUserControl();
         AV44CpjID_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         gxphoneLink = "";
         A261CpjTelNum = "";
         A262CpjTelRam = "";
         A263CpjCelNum = "";
         A264CpjWppNum = "";
         A265CpjWebsite = "";
         A266CpjEmail = "";
         ucDvpanel_tableattributes = new GXUserControl();
         lblTextblockcpjcontipoid_Jsonclick = "";
         ucCombo_cpjcontipoid = new GXUserControl();
         AV32CpjConTipoID_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         TempTags = "";
         A275CpjConNome = "";
         A274CpjConCPFFormat = "";
         A282CpjConNascimento = DateTime.MinValue;
         A278CpjNomeSocial = "";
         lblTextblockcpjcongenid_Jsonclick = "";
         ucCombo_cpjcongenid = new GXUserControl();
         AV33CpjConGenID_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A285CpjConCelNum = "";
         A286CpjConWppNum = "";
         A283CpjConTelNum = "";
         A284CpjConTelRam = "";
         A287CpjConEmail = "";
         A288CpjConLIn = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         AV21ComboCliID = Guid.Empty;
         AV45ComboCpjID = Guid.Empty;
         A271CpjConTipoSigla = "";
         A276CpjConNomePrim = "";
         A277CpjConSobrenome = "";
         A549CpjConDelDataHora = (DateTime)(DateTime.MinValue);
         A550CpjConDelData = (DateTime)(DateTime.MinValue);
         A551CpjConDelHora = (DateTime)(DateTime.MinValue);
         A552CpjConDelUsuId = "";
         A553CpjConDelUsuNome = "";
         A170CpjNomeFan = "";
         A171CpjRazaoSoc = "";
         A188CpjCNPJFormat = "";
         A189CpjIE = "";
         A160CliNomeFamiliar = "";
         A367CpjTipoNome = "";
         AV47AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
         A272CpjConTipoNome = "";
         A280CpjConGenSigla = "";
         A281CpjConGenNome = "";
         A366CpjTipoSigla = "";
         AV49Pgmname = "";
         Combo_cliid_Objectcall = "";
         Combo_cliid_Class = "";
         Combo_cliid_Icontype = "";
         Combo_cliid_Icon = "";
         Combo_cliid_Tooltip = "";
         Combo_cliid_Selectedvalue_set = "";
         Combo_cliid_Selectedtext_set = "";
         Combo_cliid_Selectedtext_get = "";
         Combo_cliid_Gamoauthtoken = "";
         Combo_cliid_Ddointernalname = "";
         Combo_cliid_Titlecontrolalign = "";
         Combo_cliid_Dropdownoptionstype = "";
         Combo_cliid_Titlecontrolidtoreplace = "";
         Combo_cliid_Datalisttype = "";
         Combo_cliid_Datalistfixedvalues = "";
         Combo_cliid_Datalistproc = "";
         Combo_cliid_Datalistprocparametersprefix = "";
         Combo_cliid_Remoteservicesparameters = "";
         Combo_cliid_Multiplevaluestype = "";
         Combo_cliid_Loadingdata = "";
         Combo_cliid_Noresultsfound = "";
         Combo_cliid_Emptyitemtext = "";
         Combo_cliid_Onlyselectedvalues = "";
         Combo_cliid_Selectalltext = "";
         Combo_cliid_Multiplevaluesseparator = "";
         Combo_cliid_Addnewoptiontext = "";
         Combo_cpjid_Objectcall = "";
         Combo_cpjid_Class = "";
         Combo_cpjid_Icontype = "";
         Combo_cpjid_Icon = "";
         Combo_cpjid_Tooltip = "";
         Combo_cpjid_Selectedvalue_set = "";
         Combo_cpjid_Selectedtext_set = "";
         Combo_cpjid_Selectedtext_get = "";
         Combo_cpjid_Gamoauthtoken = "";
         Combo_cpjid_Ddointernalname = "";
         Combo_cpjid_Titlecontrolalign = "";
         Combo_cpjid_Dropdownoptionstype = "";
         Combo_cpjid_Titlecontrolidtoreplace = "";
         Combo_cpjid_Datalisttype = "";
         Combo_cpjid_Datalistfixedvalues = "";
         Combo_cpjid_Remoteservicesparameters = "";
         Combo_cpjid_Multiplevaluestype = "";
         Combo_cpjid_Loadingdata = "";
         Combo_cpjid_Noresultsfound = "";
         Combo_cpjid_Emptyitemtext = "";
         Combo_cpjid_Onlyselectedvalues = "";
         Combo_cpjid_Selectalltext = "";
         Combo_cpjid_Multiplevaluesseparator = "";
         Combo_cpjid_Addnewoptiontext = "";
         Dvpanel_tablecliente_Objectcall = "";
         Dvpanel_tablecliente_Class = "";
         Dvpanel_tablecliente_Height = "";
         Combo_cpjcontipoid_Objectcall = "";
         Combo_cpjcontipoid_Class = "";
         Combo_cpjcontipoid_Icontype = "";
         Combo_cpjcontipoid_Icon = "";
         Combo_cpjcontipoid_Tooltip = "";
         Combo_cpjcontipoid_Selectedvalue_set = "";
         Combo_cpjcontipoid_Selectedtext_set = "";
         Combo_cpjcontipoid_Selectedtext_get = "";
         Combo_cpjcontipoid_Gamoauthtoken = "";
         Combo_cpjcontipoid_Ddointernalname = "";
         Combo_cpjcontipoid_Titlecontrolalign = "";
         Combo_cpjcontipoid_Dropdownoptionstype = "";
         Combo_cpjcontipoid_Titlecontrolidtoreplace = "";
         Combo_cpjcontipoid_Datalisttype = "";
         Combo_cpjcontipoid_Datalistfixedvalues = "";
         Combo_cpjcontipoid_Datalistproc = "";
         Combo_cpjcontipoid_Datalistprocparametersprefix = "";
         Combo_cpjcontipoid_Remoteservicesparameters = "";
         Combo_cpjcontipoid_Htmltemplate = "";
         Combo_cpjcontipoid_Multiplevaluestype = "";
         Combo_cpjcontipoid_Loadingdata = "";
         Combo_cpjcontipoid_Noresultsfound = "";
         Combo_cpjcontipoid_Emptyitemtext = "";
         Combo_cpjcontipoid_Onlyselectedvalues = "";
         Combo_cpjcontipoid_Selectalltext = "";
         Combo_cpjcontipoid_Multiplevaluesseparator = "";
         Combo_cpjcontipoid_Addnewoptiontext = "";
         Combo_cpjcongenid_Objectcall = "";
         Combo_cpjcongenid_Class = "";
         Combo_cpjcongenid_Icontype = "";
         Combo_cpjcongenid_Icon = "";
         Combo_cpjcongenid_Tooltip = "";
         Combo_cpjcongenid_Selectedvalue_set = "";
         Combo_cpjcongenid_Selectedtext_set = "";
         Combo_cpjcongenid_Selectedtext_get = "";
         Combo_cpjcongenid_Gamoauthtoken = "";
         Combo_cpjcongenid_Ddointernalname = "";
         Combo_cpjcongenid_Titlecontrolalign = "";
         Combo_cpjcongenid_Dropdownoptionstype = "";
         Combo_cpjcongenid_Titlecontrolidtoreplace = "";
         Combo_cpjcongenid_Datalisttype = "";
         Combo_cpjcongenid_Datalistfixedvalues = "";
         Combo_cpjcongenid_Datalistproc = "";
         Combo_cpjcongenid_Datalistprocparametersprefix = "";
         Combo_cpjcongenid_Remoteservicesparameters = "";
         Combo_cpjcongenid_Htmltemplate = "";
         Combo_cpjcongenid_Multiplevaluestype = "";
         Combo_cpjcongenid_Loadingdata = "";
         Combo_cpjcongenid_Noresultsfound = "";
         Combo_cpjcongenid_Onlyselectedvalues = "";
         Combo_cpjcongenid_Selectalltext = "";
         Combo_cpjcongenid_Multiplevaluesseparator = "";
         Combo_cpjcongenid_Addnewoptiontext = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode32 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV22GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV23GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV12TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV13WebSession = context.GetSession();
         AV15TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         GXEncryptionTmp = "";
         AV20Combo_DataJson = "";
         AV18ComboSelectedValue = "";
         AV19ComboSelectedText = "";
         AV46Cond_CliID = Guid.Empty;
         GXt_char2 = "";
         Z271CpjConTipoSigla = "";
         Z272CpjConTipoNome = "";
         Z280CpjConGenSigla = "";
         Z281CpjConGenNome = "";
         Z160CliNomeFamiliar = "";
         Z366CpjTipoSigla = "";
         Z367CpjTipoNome = "";
         T00104_A159CliMatricula = new long[1] ;
         T00104_A160CliNomeFamiliar = new string[] {""} ;
         T00106_A268CpjUltConSeq = new short[1] ;
         T00106_n268CpjUltConSeq = new bool[] {false} ;
         T00106_A170CpjNomeFan = new string[] {""} ;
         T00106_A171CpjRazaoSoc = new string[] {""} ;
         T00106_A176CpjMatricula = new long[1] ;
         T00106_A187CpjCNPJ = new long[1] ;
         T00106_A188CpjCNPJFormat = new string[] {""} ;
         T00106_A189CpjIE = new string[] {""} ;
         T00106_A207CpjAtivo = new bool[] {false} ;
         T00106_A261CpjTelNum = new string[] {""} ;
         T00106_n261CpjTelNum = new bool[] {false} ;
         T00106_A262CpjTelRam = new string[] {""} ;
         T00106_n262CpjTelRam = new bool[] {false} ;
         T00106_A263CpjCelNum = new string[] {""} ;
         T00106_n263CpjCelNum = new bool[] {false} ;
         T00106_A264CpjWppNum = new string[] {""} ;
         T00106_n264CpjWppNum = new bool[] {false} ;
         T00106_A265CpjWebsite = new string[] {""} ;
         T00106_n265CpjWebsite = new bool[] {false} ;
         T00106_A266CpjEmail = new string[] {""} ;
         T00106_n266CpjEmail = new bool[] {false} ;
         T00106_A365CpjTipoId = new int[1] ;
         T00109_A366CpjTipoSigla = new string[] {""} ;
         T00109_A367CpjTipoNome = new string[] {""} ;
         T00107_A271CpjConTipoSigla = new string[] {""} ;
         T00107_A272CpjConTipoNome = new string[] {""} ;
         T00108_A280CpjConGenSigla = new string[] {""} ;
         T00108_A281CpjConGenNome = new string[] {""} ;
         T001010_A269CpjConSeq = new short[1] ;
         T001010_A268CpjUltConSeq = new short[1] ;
         T001010_n268CpjUltConSeq = new bool[] {false} ;
         T001010_A549CpjConDelDataHora = new DateTime[] {DateTime.MinValue} ;
         T001010_n549CpjConDelDataHora = new bool[] {false} ;
         T001010_A550CpjConDelData = new DateTime[] {DateTime.MinValue} ;
         T001010_n550CpjConDelData = new bool[] {false} ;
         T001010_A551CpjConDelHora = new DateTime[] {DateTime.MinValue} ;
         T001010_n551CpjConDelHora = new bool[] {false} ;
         T001010_A552CpjConDelUsuId = new string[] {""} ;
         T001010_n552CpjConDelUsuId = new bool[] {false} ;
         T001010_A553CpjConDelUsuNome = new string[] {""} ;
         T001010_n553CpjConDelUsuNome = new bool[] {false} ;
         T001010_A159CliMatricula = new long[1] ;
         T001010_A160CliNomeFamiliar = new string[] {""} ;
         T001010_A366CpjTipoSigla = new string[] {""} ;
         T001010_A367CpjTipoNome = new string[] {""} ;
         T001010_A170CpjNomeFan = new string[] {""} ;
         T001010_A171CpjRazaoSoc = new string[] {""} ;
         T001010_A176CpjMatricula = new long[1] ;
         T001010_A187CpjCNPJ = new long[1] ;
         T001010_A188CpjCNPJFormat = new string[] {""} ;
         T001010_A189CpjIE = new string[] {""} ;
         T001010_A207CpjAtivo = new bool[] {false} ;
         T001010_A261CpjTelNum = new string[] {""} ;
         T001010_n261CpjTelNum = new bool[] {false} ;
         T001010_A262CpjTelRam = new string[] {""} ;
         T001010_n262CpjTelRam = new bool[] {false} ;
         T001010_A263CpjCelNum = new string[] {""} ;
         T001010_n263CpjCelNum = new bool[] {false} ;
         T001010_A264CpjWppNum = new string[] {""} ;
         T001010_n264CpjWppNum = new bool[] {false} ;
         T001010_A265CpjWebsite = new string[] {""} ;
         T001010_n265CpjWebsite = new bool[] {false} ;
         T001010_A266CpjEmail = new string[] {""} ;
         T001010_n266CpjEmail = new bool[] {false} ;
         T001010_A271CpjConTipoSigla = new string[] {""} ;
         T001010_A272CpjConTipoNome = new string[] {""} ;
         T001010_A273CpjConCPF = new long[1] ;
         T001010_A274CpjConCPFFormat = new string[] {""} ;
         T001010_A275CpjConNome = new string[] {""} ;
         T001010_A276CpjConNomePrim = new string[] {""} ;
         T001010_A277CpjConSobrenome = new string[] {""} ;
         T001010_A278CpjNomeSocial = new string[] {""} ;
         T001010_A280CpjConGenSigla = new string[] {""} ;
         T001010_A281CpjConGenNome = new string[] {""} ;
         T001010_A282CpjConNascimento = new DateTime[] {DateTime.MinValue} ;
         T001010_A283CpjConTelNum = new string[] {""} ;
         T001010_n283CpjConTelNum = new bool[] {false} ;
         T001010_A284CpjConTelRam = new string[] {""} ;
         T001010_n284CpjConTelRam = new bool[] {false} ;
         T001010_A285CpjConCelNum = new string[] {""} ;
         T001010_n285CpjConCelNum = new bool[] {false} ;
         T001010_A286CpjConWppNum = new string[] {""} ;
         T001010_n286CpjConWppNum = new bool[] {false} ;
         T001010_A287CpjConEmail = new string[] {""} ;
         T001010_n287CpjConEmail = new bool[] {false} ;
         T001010_A288CpjConLIn = new string[] {""} ;
         T001010_n288CpjConLIn = new bool[] {false} ;
         T001010_A328CpjConUltEnd = new short[1] ;
         T001010_n328CpjConUltEnd = new bool[] {false} ;
         T001010_A548CpjConDel = new bool[] {false} ;
         T001010_A158CliID = new Guid[] {Guid.Empty} ;
         T001010_A166CpjID = new Guid[] {Guid.Empty} ;
         T001010_A270CpjConTipoID = new int[1] ;
         T001010_A279CpjConGenID = new int[1] ;
         T001010_A365CpjTipoId = new int[1] ;
         T001011_A158CliID = new Guid[] {Guid.Empty} ;
         T001012_A159CliMatricula = new long[1] ;
         T001012_A160CliNomeFamiliar = new string[] {""} ;
         T001013_A366CpjTipoSigla = new string[] {""} ;
         T001013_A367CpjTipoNome = new string[] {""} ;
         T001014_A271CpjConTipoSigla = new string[] {""} ;
         T001014_A272CpjConTipoNome = new string[] {""} ;
         T001015_A280CpjConGenSigla = new string[] {""} ;
         T001015_A281CpjConGenNome = new string[] {""} ;
         T001016_A158CliID = new Guid[] {Guid.Empty} ;
         T001016_A166CpjID = new Guid[] {Guid.Empty} ;
         T001016_A269CpjConSeq = new short[1] ;
         T00103_A269CpjConSeq = new short[1] ;
         T00103_A549CpjConDelDataHora = new DateTime[] {DateTime.MinValue} ;
         T00103_n549CpjConDelDataHora = new bool[] {false} ;
         T00103_A550CpjConDelData = new DateTime[] {DateTime.MinValue} ;
         T00103_n550CpjConDelData = new bool[] {false} ;
         T00103_A551CpjConDelHora = new DateTime[] {DateTime.MinValue} ;
         T00103_n551CpjConDelHora = new bool[] {false} ;
         T00103_A552CpjConDelUsuId = new string[] {""} ;
         T00103_n552CpjConDelUsuId = new bool[] {false} ;
         T00103_A553CpjConDelUsuNome = new string[] {""} ;
         T00103_n553CpjConDelUsuNome = new bool[] {false} ;
         T00103_A273CpjConCPF = new long[1] ;
         T00103_A274CpjConCPFFormat = new string[] {""} ;
         T00103_A275CpjConNome = new string[] {""} ;
         T00103_A276CpjConNomePrim = new string[] {""} ;
         T00103_A277CpjConSobrenome = new string[] {""} ;
         T00103_A278CpjNomeSocial = new string[] {""} ;
         T00103_A282CpjConNascimento = new DateTime[] {DateTime.MinValue} ;
         T00103_A283CpjConTelNum = new string[] {""} ;
         T00103_n283CpjConTelNum = new bool[] {false} ;
         T00103_A284CpjConTelRam = new string[] {""} ;
         T00103_n284CpjConTelRam = new bool[] {false} ;
         T00103_A285CpjConCelNum = new string[] {""} ;
         T00103_n285CpjConCelNum = new bool[] {false} ;
         T00103_A286CpjConWppNum = new string[] {""} ;
         T00103_n286CpjConWppNum = new bool[] {false} ;
         T00103_A287CpjConEmail = new string[] {""} ;
         T00103_n287CpjConEmail = new bool[] {false} ;
         T00103_A288CpjConLIn = new string[] {""} ;
         T00103_n288CpjConLIn = new bool[] {false} ;
         T00103_A328CpjConUltEnd = new short[1] ;
         T00103_n328CpjConUltEnd = new bool[] {false} ;
         T00103_A548CpjConDel = new bool[] {false} ;
         T00103_A158CliID = new Guid[] {Guid.Empty} ;
         T00103_A166CpjID = new Guid[] {Guid.Empty} ;
         T00103_A270CpjConTipoID = new int[1] ;
         T00103_A279CpjConGenID = new int[1] ;
         T00103_A271CpjConTipoSigla = new string[] {""} ;
         T00103_A272CpjConTipoNome = new string[] {""} ;
         T00103_A280CpjConGenSigla = new string[] {""} ;
         T00103_A281CpjConGenNome = new string[] {""} ;
         T001017_A158CliID = new Guid[] {Guid.Empty} ;
         T001017_A166CpjID = new Guid[] {Guid.Empty} ;
         T001017_A269CpjConSeq = new short[1] ;
         T001018_A158CliID = new Guid[] {Guid.Empty} ;
         T001018_A166CpjID = new Guid[] {Guid.Empty} ;
         T001018_A269CpjConSeq = new short[1] ;
         T00102_A269CpjConSeq = new short[1] ;
         T00102_A549CpjConDelDataHora = new DateTime[] {DateTime.MinValue} ;
         T00102_n549CpjConDelDataHora = new bool[] {false} ;
         T00102_A550CpjConDelData = new DateTime[] {DateTime.MinValue} ;
         T00102_n550CpjConDelData = new bool[] {false} ;
         T00102_A551CpjConDelHora = new DateTime[] {DateTime.MinValue} ;
         T00102_n551CpjConDelHora = new bool[] {false} ;
         T00102_A552CpjConDelUsuId = new string[] {""} ;
         T00102_n552CpjConDelUsuId = new bool[] {false} ;
         T00102_A553CpjConDelUsuNome = new string[] {""} ;
         T00102_n553CpjConDelUsuNome = new bool[] {false} ;
         T00102_A273CpjConCPF = new long[1] ;
         T00102_A274CpjConCPFFormat = new string[] {""} ;
         T00102_A275CpjConNome = new string[] {""} ;
         T00102_A276CpjConNomePrim = new string[] {""} ;
         T00102_A277CpjConSobrenome = new string[] {""} ;
         T00102_A278CpjNomeSocial = new string[] {""} ;
         T00102_A282CpjConNascimento = new DateTime[] {DateTime.MinValue} ;
         T00102_A283CpjConTelNum = new string[] {""} ;
         T00102_n283CpjConTelNum = new bool[] {false} ;
         T00102_A284CpjConTelRam = new string[] {""} ;
         T00102_n284CpjConTelRam = new bool[] {false} ;
         T00102_A285CpjConCelNum = new string[] {""} ;
         T00102_n285CpjConCelNum = new bool[] {false} ;
         T00102_A286CpjConWppNum = new string[] {""} ;
         T00102_n286CpjConWppNum = new bool[] {false} ;
         T00102_A287CpjConEmail = new string[] {""} ;
         T00102_n287CpjConEmail = new bool[] {false} ;
         T00102_A288CpjConLIn = new string[] {""} ;
         T00102_n288CpjConLIn = new bool[] {false} ;
         T00102_A328CpjConUltEnd = new short[1] ;
         T00102_n328CpjConUltEnd = new bool[] {false} ;
         T00102_A548CpjConDel = new bool[] {false} ;
         T00102_A158CliID = new Guid[] {Guid.Empty} ;
         T00102_A166CpjID = new Guid[] {Guid.Empty} ;
         T00102_A270CpjConTipoID = new int[1] ;
         T00102_A279CpjConGenID = new int[1] ;
         T00102_A271CpjConTipoSigla = new string[] {""} ;
         T00102_A272CpjConTipoNome = new string[] {""} ;
         T00102_A280CpjConGenSigla = new string[] {""} ;
         T00102_A281CpjConGenNome = new string[] {""} ;
         T001019_A268CpjUltConSeq = new short[1] ;
         T001019_n268CpjUltConSeq = new bool[] {false} ;
         T001019_A170CpjNomeFan = new string[] {""} ;
         T001019_A171CpjRazaoSoc = new string[] {""} ;
         T001019_A176CpjMatricula = new long[1] ;
         T001019_A187CpjCNPJ = new long[1] ;
         T001019_A188CpjCNPJFormat = new string[] {""} ;
         T001019_A189CpjIE = new string[] {""} ;
         T001019_A207CpjAtivo = new bool[] {false} ;
         T001019_A261CpjTelNum = new string[] {""} ;
         T001019_n261CpjTelNum = new bool[] {false} ;
         T001019_A262CpjTelRam = new string[] {""} ;
         T001019_n262CpjTelRam = new bool[] {false} ;
         T001019_A263CpjCelNum = new string[] {""} ;
         T001019_n263CpjCelNum = new bool[] {false} ;
         T001019_A264CpjWppNum = new string[] {""} ;
         T001019_n264CpjWppNum = new bool[] {false} ;
         T001019_A265CpjWebsite = new string[] {""} ;
         T001019_n265CpjWebsite = new bool[] {false} ;
         T001019_A266CpjEmail = new string[] {""} ;
         T001019_n266CpjEmail = new bool[] {false} ;
         T001019_A365CpjTipoId = new int[1] ;
         T001023_A159CliMatricula = new long[1] ;
         T001023_A160CliNomeFamiliar = new string[] {""} ;
         T001024_A268CpjUltConSeq = new short[1] ;
         T001024_n268CpjUltConSeq = new bool[] {false} ;
         T001024_A170CpjNomeFan = new string[] {""} ;
         T001024_A171CpjRazaoSoc = new string[] {""} ;
         T001024_A176CpjMatricula = new long[1] ;
         T001024_A187CpjCNPJ = new long[1] ;
         T001024_A188CpjCNPJFormat = new string[] {""} ;
         T001024_A189CpjIE = new string[] {""} ;
         T001024_A207CpjAtivo = new bool[] {false} ;
         T001024_A261CpjTelNum = new string[] {""} ;
         T001024_n261CpjTelNum = new bool[] {false} ;
         T001024_A262CpjTelRam = new string[] {""} ;
         T001024_n262CpjTelRam = new bool[] {false} ;
         T001024_A263CpjCelNum = new string[] {""} ;
         T001024_n263CpjCelNum = new bool[] {false} ;
         T001024_A264CpjWppNum = new string[] {""} ;
         T001024_n264CpjWppNum = new bool[] {false} ;
         T001024_A265CpjWebsite = new string[] {""} ;
         T001024_n265CpjWebsite = new bool[] {false} ;
         T001024_A266CpjEmail = new string[] {""} ;
         T001024_n266CpjEmail = new bool[] {false} ;
         T001024_A365CpjTipoId = new int[1] ;
         T001025_A366CpjTipoSigla = new string[] {""} ;
         T001025_A367CpjTipoNome = new string[] {""} ;
         T001026_A271CpjConTipoSigla = new string[] {""} ;
         T001026_A272CpjConTipoNome = new string[] {""} ;
         T001027_A280CpjConGenSigla = new string[] {""} ;
         T001027_A281CpjConGenNome = new string[] {""} ;
         T001028_A158CliID = new Guid[] {Guid.Empty} ;
         T001028_A166CpjID = new Guid[] {Guid.Empty} ;
         T001028_A269CpjConSeq = new short[1] ;
         T001028_A329CpjConEndSeq = new short[1] ;
         T001030_A158CliID = new Guid[] {Guid.Empty} ;
         T001030_A166CpjID = new Guid[] {Guid.Empty} ;
         T001030_A269CpjConSeq = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T001031_A158CliID = new Guid[] {Guid.Empty} ;
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.core.clientepjcontato__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.clientepjcontato__default(),
            new Object[][] {
                new Object[] {
               T00102_A269CpjConSeq, T00102_A549CpjConDelDataHora, T00102_n549CpjConDelDataHora, T00102_A550CpjConDelData, T00102_n550CpjConDelData, T00102_A551CpjConDelHora, T00102_n551CpjConDelHora, T00102_A552CpjConDelUsuId, T00102_n552CpjConDelUsuId, T00102_A553CpjConDelUsuNome,
               T00102_n553CpjConDelUsuNome, T00102_A273CpjConCPF, T00102_A274CpjConCPFFormat, T00102_A275CpjConNome, T00102_A276CpjConNomePrim, T00102_A277CpjConSobrenome, T00102_A278CpjNomeSocial, T00102_A282CpjConNascimento, T00102_A283CpjConTelNum, T00102_n283CpjConTelNum,
               T00102_A284CpjConTelRam, T00102_n284CpjConTelRam, T00102_A285CpjConCelNum, T00102_n285CpjConCelNum, T00102_A286CpjConWppNum, T00102_n286CpjConWppNum, T00102_A287CpjConEmail, T00102_n287CpjConEmail, T00102_A288CpjConLIn, T00102_n288CpjConLIn,
               T00102_A328CpjConUltEnd, T00102_n328CpjConUltEnd, T00102_A548CpjConDel, T00102_A158CliID, T00102_A166CpjID, T00102_A270CpjConTipoID, T00102_A279CpjConGenID, T00102_A271CpjConTipoSigla, T00102_A272CpjConTipoNome, T00102_A280CpjConGenSigla,
               T00102_A281CpjConGenNome
               }
               , new Object[] {
               T00103_A269CpjConSeq, T00103_A549CpjConDelDataHora, T00103_n549CpjConDelDataHora, T00103_A550CpjConDelData, T00103_n550CpjConDelData, T00103_A551CpjConDelHora, T00103_n551CpjConDelHora, T00103_A552CpjConDelUsuId, T00103_n552CpjConDelUsuId, T00103_A553CpjConDelUsuNome,
               T00103_n553CpjConDelUsuNome, T00103_A273CpjConCPF, T00103_A274CpjConCPFFormat, T00103_A275CpjConNome, T00103_A276CpjConNomePrim, T00103_A277CpjConSobrenome, T00103_A278CpjNomeSocial, T00103_A282CpjConNascimento, T00103_A283CpjConTelNum, T00103_n283CpjConTelNum,
               T00103_A284CpjConTelRam, T00103_n284CpjConTelRam, T00103_A285CpjConCelNum, T00103_n285CpjConCelNum, T00103_A286CpjConWppNum, T00103_n286CpjConWppNum, T00103_A287CpjConEmail, T00103_n287CpjConEmail, T00103_A288CpjConLIn, T00103_n288CpjConLIn,
               T00103_A328CpjConUltEnd, T00103_n328CpjConUltEnd, T00103_A548CpjConDel, T00103_A158CliID, T00103_A166CpjID, T00103_A270CpjConTipoID, T00103_A279CpjConGenID, T00103_A271CpjConTipoSigla, T00103_A272CpjConTipoNome, T00103_A280CpjConGenSigla,
               T00103_A281CpjConGenNome
               }
               , new Object[] {
               T00104_A159CliMatricula, T00104_A160CliNomeFamiliar
               }
               , new Object[] {
               T00105_A268CpjUltConSeq, T00105_n268CpjUltConSeq, T00105_A170CpjNomeFan, T00105_A171CpjRazaoSoc, T00105_A176CpjMatricula, T00105_A187CpjCNPJ, T00105_A188CpjCNPJFormat, T00105_A189CpjIE, T00105_A207CpjAtivo, T00105_A261CpjTelNum,
               T00105_n261CpjTelNum, T00105_A262CpjTelRam, T00105_n262CpjTelRam, T00105_A263CpjCelNum, T00105_n263CpjCelNum, T00105_A264CpjWppNum, T00105_n264CpjWppNum, T00105_A265CpjWebsite, T00105_n265CpjWebsite, T00105_A266CpjEmail,
               T00105_n266CpjEmail, T00105_A365CpjTipoId
               }
               , new Object[] {
               T00106_A268CpjUltConSeq, T00106_n268CpjUltConSeq, T00106_A170CpjNomeFan, T00106_A171CpjRazaoSoc, T00106_A176CpjMatricula, T00106_A187CpjCNPJ, T00106_A188CpjCNPJFormat, T00106_A189CpjIE, T00106_A207CpjAtivo, T00106_A261CpjTelNum,
               T00106_n261CpjTelNum, T00106_A262CpjTelRam, T00106_n262CpjTelRam, T00106_A263CpjCelNum, T00106_n263CpjCelNum, T00106_A264CpjWppNum, T00106_n264CpjWppNum, T00106_A265CpjWebsite, T00106_n265CpjWebsite, T00106_A266CpjEmail,
               T00106_n266CpjEmail, T00106_A365CpjTipoId
               }
               , new Object[] {
               T00107_A271CpjConTipoSigla, T00107_A272CpjConTipoNome
               }
               , new Object[] {
               T00108_A280CpjConGenSigla, T00108_A281CpjConGenNome
               }
               , new Object[] {
               T00109_A366CpjTipoSigla, T00109_A367CpjTipoNome
               }
               , new Object[] {
               T001010_A269CpjConSeq, T001010_A268CpjUltConSeq, T001010_n268CpjUltConSeq, T001010_A549CpjConDelDataHora, T001010_n549CpjConDelDataHora, T001010_A550CpjConDelData, T001010_n550CpjConDelData, T001010_A551CpjConDelHora, T001010_n551CpjConDelHora, T001010_A552CpjConDelUsuId,
               T001010_n552CpjConDelUsuId, T001010_A553CpjConDelUsuNome, T001010_n553CpjConDelUsuNome, T001010_A159CliMatricula, T001010_A160CliNomeFamiliar, T001010_A366CpjTipoSigla, T001010_A367CpjTipoNome, T001010_A170CpjNomeFan, T001010_A171CpjRazaoSoc, T001010_A176CpjMatricula,
               T001010_A187CpjCNPJ, T001010_A188CpjCNPJFormat, T001010_A189CpjIE, T001010_A207CpjAtivo, T001010_A261CpjTelNum, T001010_n261CpjTelNum, T001010_A262CpjTelRam, T001010_n262CpjTelRam, T001010_A263CpjCelNum, T001010_n263CpjCelNum,
               T001010_A264CpjWppNum, T001010_n264CpjWppNum, T001010_A265CpjWebsite, T001010_n265CpjWebsite, T001010_A266CpjEmail, T001010_n266CpjEmail, T001010_A271CpjConTipoSigla, T001010_A272CpjConTipoNome, T001010_A273CpjConCPF, T001010_A274CpjConCPFFormat,
               T001010_A275CpjConNome, T001010_A276CpjConNomePrim, T001010_A277CpjConSobrenome, T001010_A278CpjNomeSocial, T001010_A280CpjConGenSigla, T001010_A281CpjConGenNome, T001010_A282CpjConNascimento, T001010_A283CpjConTelNum, T001010_n283CpjConTelNum, T001010_A284CpjConTelRam,
               T001010_n284CpjConTelRam, T001010_A285CpjConCelNum, T001010_n285CpjConCelNum, T001010_A286CpjConWppNum, T001010_n286CpjConWppNum, T001010_A287CpjConEmail, T001010_n287CpjConEmail, T001010_A288CpjConLIn, T001010_n288CpjConLIn, T001010_A328CpjConUltEnd,
               T001010_n328CpjConUltEnd, T001010_A548CpjConDel, T001010_A158CliID, T001010_A166CpjID, T001010_A270CpjConTipoID, T001010_A279CpjConGenID, T001010_A365CpjTipoId
               }
               , new Object[] {
               T001011_A158CliID
               }
               , new Object[] {
               T001012_A159CliMatricula, T001012_A160CliNomeFamiliar
               }
               , new Object[] {
               T001013_A366CpjTipoSigla, T001013_A367CpjTipoNome
               }
               , new Object[] {
               T001014_A271CpjConTipoSigla, T001014_A272CpjConTipoNome
               }
               , new Object[] {
               T001015_A280CpjConGenSigla, T001015_A281CpjConGenNome
               }
               , new Object[] {
               T001016_A158CliID, T001016_A166CpjID, T001016_A269CpjConSeq
               }
               , new Object[] {
               T001017_A158CliID, T001017_A166CpjID, T001017_A269CpjConSeq
               }
               , new Object[] {
               T001018_A158CliID, T001018_A166CpjID, T001018_A269CpjConSeq
               }
               , new Object[] {
               T001019_A268CpjUltConSeq, T001019_n268CpjUltConSeq, T001019_A170CpjNomeFan, T001019_A171CpjRazaoSoc, T001019_A176CpjMatricula, T001019_A187CpjCNPJ, T001019_A188CpjCNPJFormat, T001019_A189CpjIE, T001019_A207CpjAtivo, T001019_A261CpjTelNum,
               T001019_n261CpjTelNum, T001019_A262CpjTelRam, T001019_n262CpjTelRam, T001019_A263CpjCelNum, T001019_n263CpjCelNum, T001019_A264CpjWppNum, T001019_n264CpjWppNum, T001019_A265CpjWebsite, T001019_n265CpjWebsite, T001019_A266CpjEmail,
               T001019_n266CpjEmail, T001019_A365CpjTipoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001023_A159CliMatricula, T001023_A160CliNomeFamiliar
               }
               , new Object[] {
               T001024_A268CpjUltConSeq, T001024_n268CpjUltConSeq, T001024_A170CpjNomeFan, T001024_A171CpjRazaoSoc, T001024_A176CpjMatricula, T001024_A187CpjCNPJ, T001024_A188CpjCNPJFormat, T001024_A189CpjIE, T001024_A207CpjAtivo, T001024_A261CpjTelNum,
               T001024_n261CpjTelNum, T001024_A262CpjTelRam, T001024_n262CpjTelRam, T001024_A263CpjCelNum, T001024_n263CpjCelNum, T001024_A264CpjWppNum, T001024_n264CpjWppNum, T001024_A265CpjWebsite, T001024_n265CpjWebsite, T001024_A266CpjEmail,
               T001024_n266CpjEmail, T001024_A365CpjTipoId
               }
               , new Object[] {
               T001025_A366CpjTipoSigla, T001025_A367CpjTipoNome
               }
               , new Object[] {
               T001026_A271CpjConTipoSigla, T001026_A272CpjConTipoNome
               }
               , new Object[] {
               T001027_A280CpjConGenSigla, T001027_A281CpjConGenNome
               }
               , new Object[] {
               T001028_A158CliID, T001028_A166CpjID, T001028_A269CpjConSeq, T001028_A329CpjConEndSeq
               }
               , new Object[] {
               }
               , new Object[] {
               T001030_A158CliID, T001030_A166CpjID, T001030_A269CpjConSeq
               }
               , new Object[] {
               T001031_A158CliID
               }
            }
         );
         AV49Pgmname = "core.ClientePJContato";
      }

      private short wcpOAV37CpjConSeq ;
      private short Z269CpjConSeq ;
      private short Z328CpjConUltEnd ;
      private short O268CpjUltConSeq ;
      private short GxWebError ;
      private short AV37CpjConSeq ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A269CpjConSeq ;
      private short A328CpjConUltEnd ;
      private short A268CpjUltConSeq ;
      private short Gx_BScreen ;
      private short RcdFound32 ;
      private short gxcookieaux ;
      private short GX_JID ;
      private short Z268CpjUltConSeq ;
      private short nIsDirty_32 ;
      private short gxajaxcallmode ;
      private short ZO268CpjUltConSeq ;
      private int Z270CpjConTipoID ;
      private int Z279CpjConGenID ;
      private int Z365CpjTipoId ;
      private int N270CpjConTipoID ;
      private int N279CpjConGenID ;
      private int A365CpjTipoId ;
      private int A270CpjConTipoID ;
      private int A279CpjConGenID ;
      private int trnEnded ;
      private int edtCliID_Visible ;
      private int edtCliID_Enabled ;
      private int edtCpjID_Visible ;
      private int edtCpjID_Enabled ;
      private int edtCpjTipoId_Enabled ;
      private int edtCpjMatricula_Enabled ;
      private int edtCpjTelNum_Enabled ;
      private int edtCpjTelRam_Enabled ;
      private int edtCpjCelNum_Enabled ;
      private int edtCpjWppNum_Enabled ;
      private int edtCpjWebsite_Enabled ;
      private int edtCpjEmail_Enabled ;
      private int edtCpjConTipoID_Visible ;
      private int edtCpjConTipoID_Enabled ;
      private int edtCpjConNome_Enabled ;
      private int edtCpjConCPFFormat_Enabled ;
      private int edtCpjConNascimento_Enabled ;
      private int edtCpjNomeSocial_Enabled ;
      private int edtCpjConGenID_Visible ;
      private int edtCpjConGenID_Enabled ;
      private int edtCpjConCelNum_Enabled ;
      private int edtCpjConWppNum_Enabled ;
      private int edtCpjConTelNum_Enabled ;
      private int edtCpjConTelRam_Enabled ;
      private int edtCpjConEmail_Enabled ;
      private int edtCpjConLIn_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int edtavCombocliid_Visible ;
      private int edtavCombocliid_Enabled ;
      private int edtavCombocpjid_Visible ;
      private int edtavCombocpjid_Enabled ;
      private int AV40ComboCpjConTipoID ;
      private int edtavCombocpjcontipoid_Enabled ;
      private int edtavCombocpjcontipoid_Visible ;
      private int AV42ComboCpjConGenID ;
      private int edtavCombocpjcongenid_Enabled ;
      private int edtavCombocpjcongenid_Visible ;
      private int edtCpjConSeq_Visible ;
      private int edtCpjConSeq_Enabled ;
      private int edtCpjConTipoSigla_Visible ;
      private int edtCpjConTipoSigla_Enabled ;
      private int edtCpjConCPF_Enabled ;
      private int edtCpjConCPF_Visible ;
      private int edtCpjConNomePrim_Visible ;
      private int edtCpjConNomePrim_Enabled ;
      private int edtCpjConSobrenome_Visible ;
      private int edtCpjConSobrenome_Enabled ;
      private int edtCpjConUltEnd_Enabled ;
      private int edtCpjConUltEnd_Visible ;
      private int edtCpjCNPJ_Enabled ;
      private int edtCpjCNPJ_Visible ;
      private int edtCpjAtivo_Visible ;
      private int edtCpjAtivo_Enabled ;
      private int AV38Insert_CpjConTipoID ;
      private int AV39Insert_CpjConGenID ;
      private int Combo_cliid_Datalistupdateminimumcharacters ;
      private int Combo_cliid_Gxcontroltype ;
      private int Combo_cpjid_Datalistupdateminimumcharacters ;
      private int Combo_cpjid_Gxcontroltype ;
      private int Dvpanel_tablecliente_Gxcontroltype ;
      private int Combo_cpjcontipoid_Datalistupdateminimumcharacters ;
      private int Combo_cpjcontipoid_Gxcontroltype ;
      private int Combo_cpjcongenid_Datalistupdateminimumcharacters ;
      private int Combo_cpjcongenid_Gxcontroltype ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int AV50GXV1 ;
      private int idxLst ;
      private long Z273CpjConCPF ;
      private long Z176CpjMatricula ;
      private long Z187CpjCNPJ ;
      private long A176CpjMatricula ;
      private long A273CpjConCPF ;
      private long A187CpjCNPJ ;
      private long A159CliMatricula ;
      private long Z159CliMatricula ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z552CpjConDelUsuId ;
      private string Z283CpjConTelNum ;
      private string Z285CpjConCelNum ;
      private string Z286CpjConWppNum ;
      private string Z261CpjTelNum ;
      private string Z263CpjCelNum ;
      private string Z264CpjWppNum ;
      private string Combo_cpjcongenid_Selectedvalue_get ;
      private string Combo_cpjcontipoid_Selectedvalue_get ;
      private string Combo_cpjid_Selectedvalue_get ;
      private string Combo_cliid_Selectedvalue_get ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtCpjConTipoID_Internalname ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string Dvpanel_tablecliente_Width ;
      private string Dvpanel_tablecliente_Cls ;
      private string Dvpanel_tablecliente_Title ;
      private string Dvpanel_tablecliente_Iconposition ;
      private string Dvpanel_tablecliente_Internalname ;
      private string divTablecliente_Internalname ;
      private string divTablesplittedcliid_Internalname ;
      private string lblTextblockcliid_Internalname ;
      private string lblTextblockcliid_Jsonclick ;
      private string Combo_cliid_Caption ;
      private string Combo_cliid_Cls ;
      private string Combo_cliid_Internalname ;
      private string edtCliID_Internalname ;
      private string edtCliID_Jsonclick ;
      private string lblTxtesp01_Internalname ;
      private string lblTxtesp01_Jsonclick ;
      private string divTablesplittedcpjid_Internalname ;
      private string lblTextblockcpjid_Internalname ;
      private string lblTextblockcpjid_Jsonclick ;
      private string Combo_cpjid_Caption ;
      private string Combo_cpjid_Cls ;
      private string Combo_cpjid_Datalistproc ;
      private string Combo_cpjid_Internalname ;
      private string edtCpjID_Internalname ;
      private string edtCpjID_Jsonclick ;
      private string edtCpjTipoId_Internalname ;
      private string edtCpjTipoId_Jsonclick ;
      private string edtCpjMatricula_Internalname ;
      private string edtCpjMatricula_Jsonclick ;
      private string edtCpjTelNum_Internalname ;
      private string gxphoneLink ;
      private string A261CpjTelNum ;
      private string edtCpjTelNum_Jsonclick ;
      private string edtCpjTelRam_Internalname ;
      private string edtCpjTelRam_Jsonclick ;
      private string edtCpjCelNum_Internalname ;
      private string A263CpjCelNum ;
      private string edtCpjCelNum_Jsonclick ;
      private string edtCpjWppNum_Internalname ;
      private string A264CpjWppNum ;
      private string edtCpjWppNum_Jsonclick ;
      private string edtCpjWebsite_Internalname ;
      private string edtCpjWebsite_Jsonclick ;
      private string edtCpjEmail_Internalname ;
      private string edtCpjEmail_Jsonclick ;
      private string Dvpanel_tableattributes_Width ;
      private string Dvpanel_tableattributes_Cls ;
      private string Dvpanel_tableattributes_Title ;
      private string Dvpanel_tableattributes_Iconposition ;
      private string Dvpanel_tableattributes_Internalname ;
      private string divTableattributes_Internalname ;
      private string divTablesplittedcpjcontipoid_Internalname ;
      private string lblTextblockcpjcontipoid_Internalname ;
      private string lblTextblockcpjcontipoid_Jsonclick ;
      private string Combo_cpjcontipoid_Caption ;
      private string Combo_cpjcontipoid_Cls ;
      private string Combo_cpjcontipoid_Internalname ;
      private string TempTags ;
      private string edtCpjConTipoID_Jsonclick ;
      private string edtCpjConNome_Internalname ;
      private string edtCpjConNome_Jsonclick ;
      private string edtCpjConCPFFormat_Internalname ;
      private string edtCpjConCPFFormat_Jsonclick ;
      private string edtCpjConNascimento_Internalname ;
      private string edtCpjConNascimento_Jsonclick ;
      private string edtCpjNomeSocial_Internalname ;
      private string edtCpjNomeSocial_Jsonclick ;
      private string divTablesplittedcpjcongenid_Internalname ;
      private string lblTextblockcpjcongenid_Internalname ;
      private string lblTextblockcpjcongenid_Jsonclick ;
      private string Combo_cpjcongenid_Caption ;
      private string Combo_cpjcongenid_Cls ;
      private string Combo_cpjcongenid_Emptyitemtext ;
      private string Combo_cpjcongenid_Internalname ;
      private string edtCpjConGenID_Internalname ;
      private string edtCpjConGenID_Jsonclick ;
      private string edtCpjConCelNum_Internalname ;
      private string A285CpjConCelNum ;
      private string edtCpjConCelNum_Jsonclick ;
      private string edtCpjConWppNum_Internalname ;
      private string A286CpjConWppNum ;
      private string edtCpjConWppNum_Jsonclick ;
      private string edtCpjConTelNum_Internalname ;
      private string A283CpjConTelNum ;
      private string edtCpjConTelNum_Jsonclick ;
      private string edtCpjConTelRam_Internalname ;
      private string edtCpjConTelRam_Jsonclick ;
      private string edtCpjConEmail_Internalname ;
      private string edtCpjConEmail_Jsonclick ;
      private string edtCpjConLIn_Internalname ;
      private string edtCpjConLIn_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_cliid_Internalname ;
      private string edtavCombocliid_Internalname ;
      private string edtavCombocliid_Jsonclick ;
      private string divSectionattribute_cpjid_Internalname ;
      private string edtavCombocpjid_Internalname ;
      private string edtavCombocpjid_Jsonclick ;
      private string divSectionattribute_cpjcontipoid_Internalname ;
      private string edtavCombocpjcontipoid_Internalname ;
      private string edtavCombocpjcontipoid_Jsonclick ;
      private string divSectionattribute_cpjcongenid_Internalname ;
      private string edtavCombocpjcongenid_Internalname ;
      private string edtavCombocpjcongenid_Jsonclick ;
      private string edtCpjConSeq_Internalname ;
      private string edtCpjConSeq_Jsonclick ;
      private string edtCpjConTipoSigla_Internalname ;
      private string edtCpjConTipoSigla_Jsonclick ;
      private string edtCpjConCPF_Internalname ;
      private string edtCpjConCPF_Jsonclick ;
      private string edtCpjConNomePrim_Internalname ;
      private string edtCpjConNomePrim_Jsonclick ;
      private string edtCpjConSobrenome_Internalname ;
      private string edtCpjConSobrenome_Jsonclick ;
      private string edtCpjConUltEnd_Internalname ;
      private string edtCpjConUltEnd_Jsonclick ;
      private string edtCpjCNPJ_Internalname ;
      private string edtCpjCNPJ_Jsonclick ;
      private string edtCpjAtivo_Internalname ;
      private string edtCpjAtivo_Jsonclick ;
      private string A552CpjConDelUsuId ;
      private string AV49Pgmname ;
      private string Combo_cliid_Objectcall ;
      private string Combo_cliid_Class ;
      private string Combo_cliid_Icontype ;
      private string Combo_cliid_Icon ;
      private string Combo_cliid_Tooltip ;
      private string Combo_cliid_Selectedvalue_set ;
      private string Combo_cliid_Selectedtext_set ;
      private string Combo_cliid_Selectedtext_get ;
      private string Combo_cliid_Gamoauthtoken ;
      private string Combo_cliid_Ddointernalname ;
      private string Combo_cliid_Titlecontrolalign ;
      private string Combo_cliid_Dropdownoptionstype ;
      private string Combo_cliid_Titlecontrolidtoreplace ;
      private string Combo_cliid_Datalisttype ;
      private string Combo_cliid_Datalistfixedvalues ;
      private string Combo_cliid_Datalistproc ;
      private string Combo_cliid_Datalistprocparametersprefix ;
      private string Combo_cliid_Remoteservicesparameters ;
      private string Combo_cliid_Htmltemplate ;
      private string Combo_cliid_Multiplevaluestype ;
      private string Combo_cliid_Loadingdata ;
      private string Combo_cliid_Noresultsfound ;
      private string Combo_cliid_Emptyitemtext ;
      private string Combo_cliid_Onlyselectedvalues ;
      private string Combo_cliid_Selectalltext ;
      private string Combo_cliid_Multiplevaluesseparator ;
      private string Combo_cliid_Addnewoptiontext ;
      private string Combo_cpjid_Objectcall ;
      private string Combo_cpjid_Class ;
      private string Combo_cpjid_Icontype ;
      private string Combo_cpjid_Icon ;
      private string Combo_cpjid_Tooltip ;
      private string Combo_cpjid_Selectedvalue_set ;
      private string Combo_cpjid_Selectedtext_set ;
      private string Combo_cpjid_Selectedtext_get ;
      private string Combo_cpjid_Gamoauthtoken ;
      private string Combo_cpjid_Ddointernalname ;
      private string Combo_cpjid_Titlecontrolalign ;
      private string Combo_cpjid_Dropdownoptionstype ;
      private string Combo_cpjid_Titlecontrolidtoreplace ;
      private string Combo_cpjid_Datalisttype ;
      private string Combo_cpjid_Datalistfixedvalues ;
      private string Combo_cpjid_Datalistprocparametersprefix ;
      private string Combo_cpjid_Remoteservicesparameters ;
      private string Combo_cpjid_Htmltemplate ;
      private string Combo_cpjid_Multiplevaluestype ;
      private string Combo_cpjid_Loadingdata ;
      private string Combo_cpjid_Noresultsfound ;
      private string Combo_cpjid_Emptyitemtext ;
      private string Combo_cpjid_Onlyselectedvalues ;
      private string Combo_cpjid_Selectalltext ;
      private string Combo_cpjid_Multiplevaluesseparator ;
      private string Combo_cpjid_Addnewoptiontext ;
      private string Dvpanel_tablecliente_Objectcall ;
      private string Dvpanel_tablecliente_Class ;
      private string Dvpanel_tablecliente_Height ;
      private string Combo_cpjcontipoid_Objectcall ;
      private string Combo_cpjcontipoid_Class ;
      private string Combo_cpjcontipoid_Icontype ;
      private string Combo_cpjcontipoid_Icon ;
      private string Combo_cpjcontipoid_Tooltip ;
      private string Combo_cpjcontipoid_Selectedvalue_set ;
      private string Combo_cpjcontipoid_Selectedtext_set ;
      private string Combo_cpjcontipoid_Selectedtext_get ;
      private string Combo_cpjcontipoid_Gamoauthtoken ;
      private string Combo_cpjcontipoid_Ddointernalname ;
      private string Combo_cpjcontipoid_Titlecontrolalign ;
      private string Combo_cpjcontipoid_Dropdownoptionstype ;
      private string Combo_cpjcontipoid_Titlecontrolidtoreplace ;
      private string Combo_cpjcontipoid_Datalisttype ;
      private string Combo_cpjcontipoid_Datalistfixedvalues ;
      private string Combo_cpjcontipoid_Datalistproc ;
      private string Combo_cpjcontipoid_Datalistprocparametersprefix ;
      private string Combo_cpjcontipoid_Remoteservicesparameters ;
      private string Combo_cpjcontipoid_Htmltemplate ;
      private string Combo_cpjcontipoid_Multiplevaluestype ;
      private string Combo_cpjcontipoid_Loadingdata ;
      private string Combo_cpjcontipoid_Noresultsfound ;
      private string Combo_cpjcontipoid_Emptyitemtext ;
      private string Combo_cpjcontipoid_Onlyselectedvalues ;
      private string Combo_cpjcontipoid_Selectalltext ;
      private string Combo_cpjcontipoid_Multiplevaluesseparator ;
      private string Combo_cpjcontipoid_Addnewoptiontext ;
      private string Combo_cpjcongenid_Objectcall ;
      private string Combo_cpjcongenid_Class ;
      private string Combo_cpjcongenid_Icontype ;
      private string Combo_cpjcongenid_Icon ;
      private string Combo_cpjcongenid_Tooltip ;
      private string Combo_cpjcongenid_Selectedvalue_set ;
      private string Combo_cpjcongenid_Selectedtext_set ;
      private string Combo_cpjcongenid_Selectedtext_get ;
      private string Combo_cpjcongenid_Gamoauthtoken ;
      private string Combo_cpjcongenid_Ddointernalname ;
      private string Combo_cpjcongenid_Titlecontrolalign ;
      private string Combo_cpjcongenid_Dropdownoptionstype ;
      private string Combo_cpjcongenid_Titlecontrolidtoreplace ;
      private string Combo_cpjcongenid_Datalisttype ;
      private string Combo_cpjcongenid_Datalistfixedvalues ;
      private string Combo_cpjcongenid_Datalistproc ;
      private string Combo_cpjcongenid_Datalistprocparametersprefix ;
      private string Combo_cpjcongenid_Remoteservicesparameters ;
      private string Combo_cpjcongenid_Htmltemplate ;
      private string Combo_cpjcongenid_Multiplevaluestype ;
      private string Combo_cpjcongenid_Loadingdata ;
      private string Combo_cpjcongenid_Noresultsfound ;
      private string Combo_cpjcongenid_Onlyselectedvalues ;
      private string Combo_cpjcongenid_Selectalltext ;
      private string Combo_cpjcongenid_Multiplevaluesseparator ;
      private string Combo_cpjcongenid_Addnewoptiontext ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string hsh ;
      private string sMode32 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXEncryptionTmp ;
      private string GXt_char2 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z549CpjConDelDataHora ;
      private DateTime Z550CpjConDelData ;
      private DateTime Z551CpjConDelHora ;
      private DateTime A549CpjConDelDataHora ;
      private DateTime A550CpjConDelData ;
      private DateTime A551CpjConDelHora ;
      private DateTime Z282CpjConNascimento ;
      private DateTime A282CpjConNascimento ;
      private bool Z548CpjConDel ;
      private bool Z207CpjAtivo ;
      private bool O548CpjConDel ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Dvpanel_tablecliente_Autowidth ;
      private bool Dvpanel_tablecliente_Autoheight ;
      private bool Dvpanel_tablecliente_Collapsible ;
      private bool Dvpanel_tablecliente_Collapsed ;
      private bool Dvpanel_tablecliente_Showcollapseicon ;
      private bool Dvpanel_tablecliente_Autoscroll ;
      private bool Combo_cliid_Emptyitem ;
      private bool Combo_cpjid_Emptyitem ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool Combo_cpjcontipoid_Emptyitem ;
      private bool Combo_cpjcontipoid_Includeaddnewoption ;
      private bool Combo_cpjcongenid_Includeaddnewoption ;
      private bool A207CpjAtivo ;
      private bool n549CpjConDelDataHora ;
      private bool n550CpjConDelData ;
      private bool n551CpjConDelHora ;
      private bool n552CpjConDelUsuId ;
      private bool n553CpjConDelUsuNome ;
      private bool n283CpjConTelNum ;
      private bool n284CpjConTelRam ;
      private bool n285CpjConCelNum ;
      private bool n286CpjConWppNum ;
      private bool n287CpjConEmail ;
      private bool n288CpjConLIn ;
      private bool n328CpjConUltEnd ;
      private bool A548CpjConDel ;
      private bool n268CpjUltConSeq ;
      private bool Combo_cliid_Enabled ;
      private bool Combo_cliid_Visible ;
      private bool Combo_cliid_Allowmultipleselection ;
      private bool Combo_cliid_Isgriditem ;
      private bool Combo_cliid_Hasdescription ;
      private bool Combo_cliid_Includeonlyselectedoption ;
      private bool Combo_cliid_Includeselectalloption ;
      private bool Combo_cliid_Includeaddnewoption ;
      private bool Combo_cpjid_Enabled ;
      private bool Combo_cpjid_Visible ;
      private bool Combo_cpjid_Allowmultipleselection ;
      private bool Combo_cpjid_Isgriditem ;
      private bool Combo_cpjid_Hasdescription ;
      private bool Combo_cpjid_Includeonlyselectedoption ;
      private bool Combo_cpjid_Includeselectalloption ;
      private bool Combo_cpjid_Includeaddnewoption ;
      private bool Dvpanel_tablecliente_Enabled ;
      private bool Dvpanel_tablecliente_Showheader ;
      private bool Dvpanel_tablecliente_Visible ;
      private bool Combo_cpjcontipoid_Enabled ;
      private bool Combo_cpjcontipoid_Visible ;
      private bool Combo_cpjcontipoid_Allowmultipleselection ;
      private bool Combo_cpjcontipoid_Isgriditem ;
      private bool Combo_cpjcontipoid_Hasdescription ;
      private bool Combo_cpjcontipoid_Includeonlyselectedoption ;
      private bool Combo_cpjcontipoid_Includeselectalloption ;
      private bool Combo_cpjcongenid_Enabled ;
      private bool Combo_cpjcongenid_Visible ;
      private bool Combo_cpjcongenid_Allowmultipleselection ;
      private bool Combo_cpjcongenid_Isgriditem ;
      private bool Combo_cpjcongenid_Hasdescription ;
      private bool Combo_cpjcongenid_Includeonlyselectedoption ;
      private bool Combo_cpjcongenid_Includeselectalloption ;
      private bool Combo_cpjcongenid_Emptyitem ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool n261CpjTelNum ;
      private bool n262CpjTelRam ;
      private bool n263CpjCelNum ;
      private bool n264CpjWppNum ;
      private bool n265CpjWebsite ;
      private bool n266CpjEmail ;
      private bool returnInSub ;
      private bool GXt_boolean3 ;
      private bool Gx_longc ;
      private string AV20Combo_DataJson ;
      private string Z553CpjConDelUsuNome ;
      private string Z274CpjConCPFFormat ;
      private string Z275CpjConNome ;
      private string Z276CpjConNomePrim ;
      private string Z277CpjConSobrenome ;
      private string Z278CpjNomeSocial ;
      private string Z284CpjConTelRam ;
      private string Z287CpjConEmail ;
      private string Z288CpjConLIn ;
      private string Z170CpjNomeFan ;
      private string Z171CpjRazaoSoc ;
      private string Z188CpjCNPJFormat ;
      private string Z189CpjIE ;
      private string Z262CpjTelRam ;
      private string Z265CpjWebsite ;
      private string Z266CpjEmail ;
      private string A262CpjTelRam ;
      private string A265CpjWebsite ;
      private string A266CpjEmail ;
      private string A275CpjConNome ;
      private string A274CpjConCPFFormat ;
      private string A278CpjNomeSocial ;
      private string A284CpjConTelRam ;
      private string A287CpjConEmail ;
      private string A288CpjConLIn ;
      private string A271CpjConTipoSigla ;
      private string A276CpjConNomePrim ;
      private string A277CpjConSobrenome ;
      private string A553CpjConDelUsuNome ;
      private string A170CpjNomeFan ;
      private string A171CpjRazaoSoc ;
      private string A188CpjCNPJFormat ;
      private string A189CpjIE ;
      private string A160CliNomeFamiliar ;
      private string A367CpjTipoNome ;
      private string A272CpjConTipoNome ;
      private string A280CpjConGenSigla ;
      private string A281CpjConGenNome ;
      private string A366CpjTipoSigla ;
      private string AV18ComboSelectedValue ;
      private string AV19ComboSelectedText ;
      private string Z271CpjConTipoSigla ;
      private string Z272CpjConTipoNome ;
      private string Z280CpjConGenSigla ;
      private string Z281CpjConGenNome ;
      private string Z160CliNomeFamiliar ;
      private string Z366CpjTipoSigla ;
      private string Z367CpjTipoNome ;
      private Guid wcpOAV7CliID ;
      private Guid wcpOAV8CpjID ;
      private Guid Z158CliID ;
      private Guid Z166CpjID ;
      private Guid A158CliID ;
      private Guid A166CpjID ;
      private Guid AV7CliID ;
      private Guid AV8CpjID ;
      private Guid AV21ComboCliID ;
      private Guid AV45ComboCpjID ;
      private Guid AV46Cond_CliID ;
      private IGxSession AV13WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tablecliente ;
      private GXUserControl ucCombo_cliid ;
      private GXUserControl ucCombo_cpjid ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucCombo_cpjcontipoid ;
      private GXUserControl ucCombo_cpjcongenid ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] T00104_A159CliMatricula ;
      private string[] T00104_A160CliNomeFamiliar ;
      private short[] T00106_A268CpjUltConSeq ;
      private bool[] T00106_n268CpjUltConSeq ;
      private string[] T00106_A170CpjNomeFan ;
      private string[] T00106_A171CpjRazaoSoc ;
      private long[] T00106_A176CpjMatricula ;
      private long[] T00106_A187CpjCNPJ ;
      private string[] T00106_A188CpjCNPJFormat ;
      private string[] T00106_A189CpjIE ;
      private bool[] T00106_A207CpjAtivo ;
      private string[] T00106_A261CpjTelNum ;
      private bool[] T00106_n261CpjTelNum ;
      private string[] T00106_A262CpjTelRam ;
      private bool[] T00106_n262CpjTelRam ;
      private string[] T00106_A263CpjCelNum ;
      private bool[] T00106_n263CpjCelNum ;
      private string[] T00106_A264CpjWppNum ;
      private bool[] T00106_n264CpjWppNum ;
      private string[] T00106_A265CpjWebsite ;
      private bool[] T00106_n265CpjWebsite ;
      private string[] T00106_A266CpjEmail ;
      private bool[] T00106_n266CpjEmail ;
      private int[] T00106_A365CpjTipoId ;
      private string[] T00109_A366CpjTipoSigla ;
      private string[] T00109_A367CpjTipoNome ;
      private string[] T00107_A271CpjConTipoSigla ;
      private string[] T00107_A272CpjConTipoNome ;
      private string[] T00108_A280CpjConGenSigla ;
      private string[] T00108_A281CpjConGenNome ;
      private short[] T001010_A269CpjConSeq ;
      private short[] T001010_A268CpjUltConSeq ;
      private bool[] T001010_n268CpjUltConSeq ;
      private DateTime[] T001010_A549CpjConDelDataHora ;
      private bool[] T001010_n549CpjConDelDataHora ;
      private DateTime[] T001010_A550CpjConDelData ;
      private bool[] T001010_n550CpjConDelData ;
      private DateTime[] T001010_A551CpjConDelHora ;
      private bool[] T001010_n551CpjConDelHora ;
      private string[] T001010_A552CpjConDelUsuId ;
      private bool[] T001010_n552CpjConDelUsuId ;
      private string[] T001010_A553CpjConDelUsuNome ;
      private bool[] T001010_n553CpjConDelUsuNome ;
      private long[] T001010_A159CliMatricula ;
      private string[] T001010_A160CliNomeFamiliar ;
      private string[] T001010_A366CpjTipoSigla ;
      private string[] T001010_A367CpjTipoNome ;
      private string[] T001010_A170CpjNomeFan ;
      private string[] T001010_A171CpjRazaoSoc ;
      private long[] T001010_A176CpjMatricula ;
      private long[] T001010_A187CpjCNPJ ;
      private string[] T001010_A188CpjCNPJFormat ;
      private string[] T001010_A189CpjIE ;
      private bool[] T001010_A207CpjAtivo ;
      private string[] T001010_A261CpjTelNum ;
      private bool[] T001010_n261CpjTelNum ;
      private string[] T001010_A262CpjTelRam ;
      private bool[] T001010_n262CpjTelRam ;
      private string[] T001010_A263CpjCelNum ;
      private bool[] T001010_n263CpjCelNum ;
      private string[] T001010_A264CpjWppNum ;
      private bool[] T001010_n264CpjWppNum ;
      private string[] T001010_A265CpjWebsite ;
      private bool[] T001010_n265CpjWebsite ;
      private string[] T001010_A266CpjEmail ;
      private bool[] T001010_n266CpjEmail ;
      private string[] T001010_A271CpjConTipoSigla ;
      private string[] T001010_A272CpjConTipoNome ;
      private long[] T001010_A273CpjConCPF ;
      private string[] T001010_A274CpjConCPFFormat ;
      private string[] T001010_A275CpjConNome ;
      private string[] T001010_A276CpjConNomePrim ;
      private string[] T001010_A277CpjConSobrenome ;
      private string[] T001010_A278CpjNomeSocial ;
      private string[] T001010_A280CpjConGenSigla ;
      private string[] T001010_A281CpjConGenNome ;
      private DateTime[] T001010_A282CpjConNascimento ;
      private string[] T001010_A283CpjConTelNum ;
      private bool[] T001010_n283CpjConTelNum ;
      private string[] T001010_A284CpjConTelRam ;
      private bool[] T001010_n284CpjConTelRam ;
      private string[] T001010_A285CpjConCelNum ;
      private bool[] T001010_n285CpjConCelNum ;
      private string[] T001010_A286CpjConWppNum ;
      private bool[] T001010_n286CpjConWppNum ;
      private string[] T001010_A287CpjConEmail ;
      private bool[] T001010_n287CpjConEmail ;
      private string[] T001010_A288CpjConLIn ;
      private bool[] T001010_n288CpjConLIn ;
      private short[] T001010_A328CpjConUltEnd ;
      private bool[] T001010_n328CpjConUltEnd ;
      private bool[] T001010_A548CpjConDel ;
      private Guid[] T001010_A158CliID ;
      private Guid[] T001010_A166CpjID ;
      private int[] T001010_A270CpjConTipoID ;
      private int[] T001010_A279CpjConGenID ;
      private int[] T001010_A365CpjTipoId ;
      private Guid[] T001011_A158CliID ;
      private long[] T001012_A159CliMatricula ;
      private string[] T001012_A160CliNomeFamiliar ;
      private string[] T001013_A366CpjTipoSigla ;
      private string[] T001013_A367CpjTipoNome ;
      private string[] T001014_A271CpjConTipoSigla ;
      private string[] T001014_A272CpjConTipoNome ;
      private string[] T001015_A280CpjConGenSigla ;
      private string[] T001015_A281CpjConGenNome ;
      private Guid[] T001016_A158CliID ;
      private Guid[] T001016_A166CpjID ;
      private short[] T001016_A269CpjConSeq ;
      private short[] T00103_A269CpjConSeq ;
      private DateTime[] T00103_A549CpjConDelDataHora ;
      private bool[] T00103_n549CpjConDelDataHora ;
      private DateTime[] T00103_A550CpjConDelData ;
      private bool[] T00103_n550CpjConDelData ;
      private DateTime[] T00103_A551CpjConDelHora ;
      private bool[] T00103_n551CpjConDelHora ;
      private string[] T00103_A552CpjConDelUsuId ;
      private bool[] T00103_n552CpjConDelUsuId ;
      private string[] T00103_A553CpjConDelUsuNome ;
      private bool[] T00103_n553CpjConDelUsuNome ;
      private long[] T00103_A273CpjConCPF ;
      private string[] T00103_A274CpjConCPFFormat ;
      private string[] T00103_A275CpjConNome ;
      private string[] T00103_A276CpjConNomePrim ;
      private string[] T00103_A277CpjConSobrenome ;
      private string[] T00103_A278CpjNomeSocial ;
      private DateTime[] T00103_A282CpjConNascimento ;
      private string[] T00103_A283CpjConTelNum ;
      private bool[] T00103_n283CpjConTelNum ;
      private string[] T00103_A284CpjConTelRam ;
      private bool[] T00103_n284CpjConTelRam ;
      private string[] T00103_A285CpjConCelNum ;
      private bool[] T00103_n285CpjConCelNum ;
      private string[] T00103_A286CpjConWppNum ;
      private bool[] T00103_n286CpjConWppNum ;
      private string[] T00103_A287CpjConEmail ;
      private bool[] T00103_n287CpjConEmail ;
      private string[] T00103_A288CpjConLIn ;
      private bool[] T00103_n288CpjConLIn ;
      private short[] T00103_A328CpjConUltEnd ;
      private bool[] T00103_n328CpjConUltEnd ;
      private bool[] T00103_A548CpjConDel ;
      private Guid[] T00103_A158CliID ;
      private Guid[] T00103_A166CpjID ;
      private int[] T00103_A270CpjConTipoID ;
      private int[] T00103_A279CpjConGenID ;
      private string[] T00103_A271CpjConTipoSigla ;
      private string[] T00103_A272CpjConTipoNome ;
      private string[] T00103_A280CpjConGenSigla ;
      private string[] T00103_A281CpjConGenNome ;
      private Guid[] T001017_A158CliID ;
      private Guid[] T001017_A166CpjID ;
      private short[] T001017_A269CpjConSeq ;
      private Guid[] T001018_A158CliID ;
      private Guid[] T001018_A166CpjID ;
      private short[] T001018_A269CpjConSeq ;
      private short[] T00102_A269CpjConSeq ;
      private DateTime[] T00102_A549CpjConDelDataHora ;
      private bool[] T00102_n549CpjConDelDataHora ;
      private DateTime[] T00102_A550CpjConDelData ;
      private bool[] T00102_n550CpjConDelData ;
      private DateTime[] T00102_A551CpjConDelHora ;
      private bool[] T00102_n551CpjConDelHora ;
      private string[] T00102_A552CpjConDelUsuId ;
      private bool[] T00102_n552CpjConDelUsuId ;
      private string[] T00102_A553CpjConDelUsuNome ;
      private bool[] T00102_n553CpjConDelUsuNome ;
      private long[] T00102_A273CpjConCPF ;
      private string[] T00102_A274CpjConCPFFormat ;
      private string[] T00102_A275CpjConNome ;
      private string[] T00102_A276CpjConNomePrim ;
      private string[] T00102_A277CpjConSobrenome ;
      private string[] T00102_A278CpjNomeSocial ;
      private DateTime[] T00102_A282CpjConNascimento ;
      private string[] T00102_A283CpjConTelNum ;
      private bool[] T00102_n283CpjConTelNum ;
      private string[] T00102_A284CpjConTelRam ;
      private bool[] T00102_n284CpjConTelRam ;
      private string[] T00102_A285CpjConCelNum ;
      private bool[] T00102_n285CpjConCelNum ;
      private string[] T00102_A286CpjConWppNum ;
      private bool[] T00102_n286CpjConWppNum ;
      private string[] T00102_A287CpjConEmail ;
      private bool[] T00102_n287CpjConEmail ;
      private string[] T00102_A288CpjConLIn ;
      private bool[] T00102_n288CpjConLIn ;
      private short[] T00102_A328CpjConUltEnd ;
      private bool[] T00102_n328CpjConUltEnd ;
      private bool[] T00102_A548CpjConDel ;
      private Guid[] T00102_A158CliID ;
      private Guid[] T00102_A166CpjID ;
      private int[] T00102_A270CpjConTipoID ;
      private int[] T00102_A279CpjConGenID ;
      private string[] T00102_A271CpjConTipoSigla ;
      private string[] T00102_A272CpjConTipoNome ;
      private string[] T00102_A280CpjConGenSigla ;
      private string[] T00102_A281CpjConGenNome ;
      private short[] T001019_A268CpjUltConSeq ;
      private bool[] T001019_n268CpjUltConSeq ;
      private string[] T001019_A170CpjNomeFan ;
      private string[] T001019_A171CpjRazaoSoc ;
      private long[] T001019_A176CpjMatricula ;
      private long[] T001019_A187CpjCNPJ ;
      private string[] T001019_A188CpjCNPJFormat ;
      private string[] T001019_A189CpjIE ;
      private bool[] T001019_A207CpjAtivo ;
      private string[] T001019_A261CpjTelNum ;
      private bool[] T001019_n261CpjTelNum ;
      private string[] T001019_A262CpjTelRam ;
      private bool[] T001019_n262CpjTelRam ;
      private string[] T001019_A263CpjCelNum ;
      private bool[] T001019_n263CpjCelNum ;
      private string[] T001019_A264CpjWppNum ;
      private bool[] T001019_n264CpjWppNum ;
      private string[] T001019_A265CpjWebsite ;
      private bool[] T001019_n265CpjWebsite ;
      private string[] T001019_A266CpjEmail ;
      private bool[] T001019_n266CpjEmail ;
      private int[] T001019_A365CpjTipoId ;
      private long[] T001023_A159CliMatricula ;
      private string[] T001023_A160CliNomeFamiliar ;
      private short[] T001024_A268CpjUltConSeq ;
      private bool[] T001024_n268CpjUltConSeq ;
      private string[] T001024_A170CpjNomeFan ;
      private string[] T001024_A171CpjRazaoSoc ;
      private long[] T001024_A176CpjMatricula ;
      private long[] T001024_A187CpjCNPJ ;
      private string[] T001024_A188CpjCNPJFormat ;
      private string[] T001024_A189CpjIE ;
      private bool[] T001024_A207CpjAtivo ;
      private string[] T001024_A261CpjTelNum ;
      private bool[] T001024_n261CpjTelNum ;
      private string[] T001024_A262CpjTelRam ;
      private bool[] T001024_n262CpjTelRam ;
      private string[] T001024_A263CpjCelNum ;
      private bool[] T001024_n263CpjCelNum ;
      private string[] T001024_A264CpjWppNum ;
      private bool[] T001024_n264CpjWppNum ;
      private string[] T001024_A265CpjWebsite ;
      private bool[] T001024_n265CpjWebsite ;
      private string[] T001024_A266CpjEmail ;
      private bool[] T001024_n266CpjEmail ;
      private int[] T001024_A365CpjTipoId ;
      private string[] T001025_A366CpjTipoSigla ;
      private string[] T001025_A367CpjTipoNome ;
      private string[] T001026_A271CpjConTipoSigla ;
      private string[] T001026_A272CpjConTipoNome ;
      private string[] T001027_A280CpjConGenSigla ;
      private string[] T001027_A281CpjConGenNome ;
      private Guid[] T001028_A158CliID ;
      private Guid[] T001028_A166CpjID ;
      private short[] T001028_A269CpjConSeq ;
      private short[] T001028_A329CpjConEndSeq ;
      private Guid[] T001030_A158CliID ;
      private Guid[] T001030_A166CpjID ;
      private short[] T001030_A269CpjConSeq ;
      private Guid[] T001031_A158CliID ;
      private IDataStoreProvider pr_gam ;
      private short[] T00105_A268CpjUltConSeq ;
      private string[] T00105_A170CpjNomeFan ;
      private string[] T00105_A171CpjRazaoSoc ;
      private long[] T00105_A176CpjMatricula ;
      private long[] T00105_A187CpjCNPJ ;
      private string[] T00105_A188CpjCNPJFormat ;
      private string[] T00105_A189CpjIE ;
      private bool[] T00105_A207CpjAtivo ;
      private string[] T00105_A261CpjTelNum ;
      private string[] T00105_A262CpjTelRam ;
      private string[] T00105_A263CpjCelNum ;
      private string[] T00105_A264CpjWppNum ;
      private string[] T00105_A265CpjWebsite ;
      private string[] T00105_A266CpjEmail ;
      private int[] T00105_A365CpjTipoId ;
      private bool[] T00105_n268CpjUltConSeq ;
      private bool[] T00105_n261CpjTelNum ;
      private bool[] T00105_n262CpjTelRam ;
      private bool[] T00105_n263CpjCelNum ;
      private bool[] T00105_n264CpjWppNum ;
      private bool[] T00105_n265CpjWebsite ;
      private bool[] T00105_n266CpjEmail ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV16CliID_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV44CpjID_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV32CpjConTipoID_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV33CpjConGenID_Data ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV23GAMErrors ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV12TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV15TrnContextAtt ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV17DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV22GAMSession ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV47AuditingObject ;
   }

   public class clientepjcontato__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class clientepjcontato__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[12])
       ,new ForEachCursor(def[13])
       ,new ForEachCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new ForEachCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new UpdateCursor(def[18])
       ,new UpdateCursor(def[19])
       ,new UpdateCursor(def[20])
       ,new ForEachCursor(def[21])
       ,new ForEachCursor(def[22])
       ,new ForEachCursor(def[23])
       ,new ForEachCursor(def[24])
       ,new ForEachCursor(def[25])
       ,new ForEachCursor(def[26])
       ,new UpdateCursor(def[27])
       ,new ForEachCursor(def[28])
       ,new ForEachCursor(def[29])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00105;
        prmT00105 = new Object[] {
        new ParDef("CliID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("CpjID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT001010;
        prmT001010 = new Object[] {
        new ParDef("CliID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("CpjID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("CpjConSeq",GXType.Int16,4,0)
        };
        Object[] prmT00104;
        prmT00104 = new Object[] {
        new ParDef("CliID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT00109;
        prmT00109 = new Object[] {
        new ParDef("CpjTipoId",GXType.Int32,9,0)
        };
        Object[] prmT001011;
        prmT001011 = new Object[] {
        new ParDef("CliID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("CpjID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("CpjConCPF",GXType.Int64,11,0) ,
        new ParDef("CpjConSeq",GXType.Int16,4,0)
        };
        Object[] prmT00107;
        prmT00107 = new Object[] {
        new ParDef("CpjConTipoID",GXType.Int32,9,0)
        };
        Object[] prmT00108;
        prmT00108 = new Object[] {
        new ParDef("CpjConGenID",GXType.Int32,9,0)
        };
        Object[] prmT001012;
        prmT001012 = new Object[] {
        new ParDef("CliID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT00106;
        prmT00106 = new Object[] {
        new ParDef("CliID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("CpjID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT001013;
        prmT001013 = new Object[] {
        new ParDef("CpjTipoId",GXType.Int32,9,0)
        };
        Object[] prmT001014;
        prmT001014 = new Object[] {
        new ParDef("CpjConTipoID",GXType.Int32,9,0)
        };
        Object[] prmT001015;
        prmT001015 = new Object[] {
        new ParDef("CpjConGenID",GXType.Int32,9,0)
        };
        Object[] prmT001016;
        prmT001016 = new Object[] {
        new ParDef("CliID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("CpjID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("CpjConSeq",GXType.Int16,4,0)
        };
        Object[] prmT00103;
        prmT00103 = new Object[] {
        new ParDef("CliID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("CpjID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("CpjConSeq",GXType.Int16,4,0)
        };
        Object[] prmT001017;
        prmT001017 = new Object[] {
        new ParDef("CliID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("CpjID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("CpjConSeq",GXType.Int16,4,0)
        };
        Object[] prmT001018;
        prmT001018 = new Object[] {
        new ParDef("CliID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("CpjID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("CpjConSeq",GXType.Int16,4,0)
        };
        Object[] prmT00102;
        prmT00102 = new Object[] {
        new ParDef("CliID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("CpjID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("CpjConSeq",GXType.Int16,4,0)
        };
        Object[] prmT001019;
        prmT001019 = new Object[] {
        new ParDef("CliID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("CpjID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT001020;
        prmT001020 = new Object[] {
        new ParDef("CpjConTipoSigla",GXType.VarChar,20,0) ,
        new ParDef("CpjConTipoNome",GXType.VarChar,80,0) ,
        new ParDef("CpjConGenSigla",GXType.VarChar,20,0) ,
        new ParDef("CpjConGenNome",GXType.VarChar,80,0) ,
        new ParDef("CpjConSeq",GXType.Int16,4,0) ,
        new ParDef("CpjConDelDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("CpjConDelData",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("CpjConDelHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("CpjConDelUsuId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("CpjConDelUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("CpjConCPF",GXType.Int64,11,0) ,
        new ParDef("CpjConCPFFormat",GXType.VarChar,14,0) ,
        new ParDef("CpjConNome",GXType.VarChar,80,0) ,
        new ParDef("CpjConNomePrim",GXType.VarChar,80,0) ,
        new ParDef("CpjConSobrenome",GXType.VarChar,80,0) ,
        new ParDef("CpjNomeSocial",GXType.VarChar,80,0) ,
        new ParDef("CpjConNascimento",GXType.Date,8,0) ,
        new ParDef("CpjConTelNum",GXType.Char,20,0){Nullable=true} ,
        new ParDef("CpjConTelRam",GXType.VarChar,10,0){Nullable=true} ,
        new ParDef("CpjConCelNum",GXType.Char,20,0){Nullable=true} ,
        new ParDef("CpjConWppNum",GXType.Char,20,0){Nullable=true} ,
        new ParDef("CpjConEmail",GXType.VarChar,100,0){Nullable=true} ,
        new ParDef("CpjConLIn",GXType.VarChar,1000,0){Nullable=true} ,
        new ParDef("CpjConUltEnd",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("CpjConDel",GXType.Boolean,4,0) ,
        new ParDef("CliID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("CpjID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("CpjConTipoID",GXType.Int32,9,0) ,
        new ParDef("CpjConGenID",GXType.Int32,9,0)
        };
        Object[] prmT001021;
        prmT001021 = new Object[] {
        new ParDef("CpjConTipoSigla",GXType.VarChar,20,0) ,
        new ParDef("CpjConTipoNome",GXType.VarChar,80,0) ,
        new ParDef("CpjConGenSigla",GXType.VarChar,20,0) ,
        new ParDef("CpjConGenNome",GXType.VarChar,80,0) ,
        new ParDef("CpjConDelDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("CpjConDelData",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("CpjConDelHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("CpjConDelUsuId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("CpjConDelUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("CpjConCPF",GXType.Int64,11,0) ,
        new ParDef("CpjConCPFFormat",GXType.VarChar,14,0) ,
        new ParDef("CpjConNome",GXType.VarChar,80,0) ,
        new ParDef("CpjConNomePrim",GXType.VarChar,80,0) ,
        new ParDef("CpjConSobrenome",GXType.VarChar,80,0) ,
        new ParDef("CpjNomeSocial",GXType.VarChar,80,0) ,
        new ParDef("CpjConNascimento",GXType.Date,8,0) ,
        new ParDef("CpjConTelNum",GXType.Char,20,0){Nullable=true} ,
        new ParDef("CpjConTelRam",GXType.VarChar,10,0){Nullable=true} ,
        new ParDef("CpjConCelNum",GXType.Char,20,0){Nullable=true} ,
        new ParDef("CpjConWppNum",GXType.Char,20,0){Nullable=true} ,
        new ParDef("CpjConEmail",GXType.VarChar,100,0){Nullable=true} ,
        new ParDef("CpjConLIn",GXType.VarChar,1000,0){Nullable=true} ,
        new ParDef("CpjConUltEnd",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("CpjConDel",GXType.Boolean,4,0) ,
        new ParDef("CpjConTipoID",GXType.Int32,9,0) ,
        new ParDef("CpjConGenID",GXType.Int32,9,0) ,
        new ParDef("CliID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("CpjID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("CpjConSeq",GXType.Int16,4,0)
        };
        Object[] prmT001022;
        prmT001022 = new Object[] {
        new ParDef("CliID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("CpjID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("CpjConSeq",GXType.Int16,4,0)
        };
        Object[] prmT001028;
        prmT001028 = new Object[] {
        new ParDef("CliID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("CpjID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("CpjConSeq",GXType.Int16,4,0)
        };
        Object[] prmT001029;
        prmT001029 = new Object[] {
        new ParDef("CpjUltConSeq",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("CliID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("CpjID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT001030;
        prmT001030 = new Object[] {
        };
        Object[] prmT001023;
        prmT001023 = new Object[] {
        new ParDef("CliID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT001024;
        prmT001024 = new Object[] {
        new ParDef("CliID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("CpjID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT001025;
        prmT001025 = new Object[] {
        new ParDef("CpjTipoId",GXType.Int32,9,0)
        };
        Object[] prmT001026;
        prmT001026 = new Object[] {
        new ParDef("CpjConTipoID",GXType.Int32,9,0)
        };
        Object[] prmT001027;
        prmT001027 = new Object[] {
        new ParDef("CpjConGenID",GXType.Int32,9,0)
        };
        Object[] prmT001031;
        prmT001031 = new Object[] {
        new ParDef("CliID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("CpjID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("CpjConCPF",GXType.Int64,11,0) ,
        new ParDef("CpjConSeq",GXType.Int16,4,0)
        };
        def= new CursorDef[] {
            new CursorDef("T00102", "SELECT CpjConSeq, CpjConDelDataHora, CpjConDelData, CpjConDelHora, CpjConDelUsuId, CpjConDelUsuNome, CpjConCPF, CpjConCPFFormat, CpjConNome, CpjConNomePrim, CpjConSobrenome, CpjNomeSocial, CpjConNascimento, CpjConTelNum, CpjConTelRam, CpjConCelNum, CpjConWppNum, CpjConEmail, CpjConLIn, CpjConUltEnd, CpjConDel, CliID, CpjID, CpjConTipoID, CpjConGenID, CpjConTipoSigla, CpjConTipoNome, CpjConGenSigla, CpjConGenNome FROM tb_clientepj_contato WHERE CliID = :CliID AND CpjID = :CpjID AND CpjConSeq = :CpjConSeq  FOR UPDATE OF tb_clientepj_contato NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT00102,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00103", "SELECT CpjConSeq, CpjConDelDataHora, CpjConDelData, CpjConDelHora, CpjConDelUsuId, CpjConDelUsuNome, CpjConCPF, CpjConCPFFormat, CpjConNome, CpjConNomePrim, CpjConSobrenome, CpjNomeSocial, CpjConNascimento, CpjConTelNum, CpjConTelRam, CpjConCelNum, CpjConWppNum, CpjConEmail, CpjConLIn, CpjConUltEnd, CpjConDel, CliID, CpjID, CpjConTipoID, CpjConGenID, CpjConTipoSigla, CpjConTipoNome, CpjConGenSigla, CpjConGenNome FROM tb_clientepj_contato WHERE CliID = :CliID AND CpjID = :CpjID AND CpjConSeq = :CpjConSeq ",true, GxErrorMask.GX_NOMASK, false, this,prmT00103,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00104", "SELECT CliMatricula, CliNomeFamiliar FROM tb_cliente WHERE CliID = :CliID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00104,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00105", "SELECT CpjUltConSeq, CpjNomeFan, CpjRazaoSoc, CpjMatricula, CpjCNPJ, CpjCNPJFormat, CpjIE, CpjAtivo, CpjTelNum, CpjTelRam, CpjCelNum, CpjWppNum, CpjWebsite, CpjEmail, CpjTipoId FROM tb_clientepj WHERE CliID = :CliID AND CpjID = :CpjID  FOR UPDATE OF tb_clientepj NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT00105,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00106", "SELECT CpjUltConSeq, CpjNomeFan, CpjRazaoSoc, CpjMatricula, CpjCNPJ, CpjCNPJFormat, CpjIE, CpjAtivo, CpjTelNum, CpjTelRam, CpjCelNum, CpjWppNum, CpjWebsite, CpjEmail, CpjTipoId FROM tb_clientepj WHERE CliID = :CliID AND CpjID = :CpjID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00106,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00107", "SELECT PjtSigla AS CpjConTipoSigla, PjtNome AS CpjConTipoNome FROM tb_clientepjtipo WHERE PjtID = :CpjConTipoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00107,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00108", "SELECT GenSigla AS CpjConGenSigla, GenNome AS CpjConGenNome FROM tb_genero WHERE GenID = :CpjConGenID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00108,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00109", "SELECT PjtSigla AS CpjTipoSigla, PjtNome AS CpjTipoNome FROM tb_clientepjtipo WHERE PjtID = :CpjTipoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00109,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001010", "SELECT TM1.CpjConSeq, T3.CpjUltConSeq, TM1.CpjConDelDataHora, TM1.CpjConDelData, TM1.CpjConDelHora, TM1.CpjConDelUsuId, TM1.CpjConDelUsuNome, T2.CliMatricula, T2.CliNomeFamiliar, T4.PjtSigla AS CpjTipoSigla, T4.PjtNome AS CpjTipoNome, T3.CpjNomeFan, T3.CpjRazaoSoc, T3.CpjMatricula, T3.CpjCNPJ, T3.CpjCNPJFormat, T3.CpjIE, T3.CpjAtivo, T3.CpjTelNum, T3.CpjTelRam, T3.CpjCelNum, T3.CpjWppNum, T3.CpjWebsite, T3.CpjEmail, TM1.CpjConTipoSigla AS CpjConTipoSigla, TM1.CpjConTipoNome AS CpjConTipoNome, TM1.CpjConCPF, TM1.CpjConCPFFormat, TM1.CpjConNome, TM1.CpjConNomePrim, TM1.CpjConSobrenome, TM1.CpjNomeSocial, TM1.CpjConGenSigla AS CpjConGenSigla, TM1.CpjConGenNome AS CpjConGenNome, TM1.CpjConNascimento, TM1.CpjConTelNum, TM1.CpjConTelRam, TM1.CpjConCelNum, TM1.CpjConWppNum, TM1.CpjConEmail, TM1.CpjConLIn, TM1.CpjConUltEnd, TM1.CpjConDel, TM1.CliID, TM1.CpjID, TM1.CpjConTipoID AS CpjConTipoID, TM1.CpjConGenID AS CpjConGenID, T3.CpjTipoId AS CpjTipoId FROM (((tb_clientepj_contato TM1 INNER JOIN tb_cliente T2 ON T2.CliID = TM1.CliID) INNER JOIN tb_clientepj T3 ON T3.CliID = TM1.CliID AND T3.CpjID = TM1.CpjID) INNER JOIN tb_clientepjtipo T4 ON T4.PjtID = T3.CpjTipoId) WHERE TM1.CliID = :CliID and TM1.CpjID = :CpjID and TM1.CpjConSeq = :CpjConSeq ORDER BY TM1.CliID, TM1.CpjID, TM1.CpjConSeq ",true, GxErrorMask.GX_NOMASK, false, this,prmT001010,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001011", "SELECT CliID FROM tb_clientepj_contato WHERE (CliID = :CliID AND CpjID = :CpjID AND CpjConCPF = :CpjConCPF) AND (Not ( CliID = :CliID and CpjID = :CpjID and CpjConSeq = :CpjConSeq)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT001011,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001012", "SELECT CliMatricula, CliNomeFamiliar FROM tb_cliente WHERE CliID = :CliID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001012,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001013", "SELECT PjtSigla AS CpjTipoSigla, PjtNome AS CpjTipoNome FROM tb_clientepjtipo WHERE PjtID = :CpjTipoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001013,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001014", "SELECT PjtSigla AS CpjConTipoSigla, PjtNome AS CpjConTipoNome FROM tb_clientepjtipo WHERE PjtID = :CpjConTipoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001014,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001015", "SELECT GenSigla AS CpjConGenSigla, GenNome AS CpjConGenNome FROM tb_genero WHERE GenID = :CpjConGenID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001015,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001016", "SELECT CliID, CpjID, CpjConSeq FROM tb_clientepj_contato WHERE CliID = :CliID AND CpjID = :CpjID AND CpjConSeq = :CpjConSeq ",true, GxErrorMask.GX_NOMASK, false, this,prmT001016,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001017", "SELECT CliID, CpjID, CpjConSeq FROM tb_clientepj_contato WHERE ( CliID > :CliID or CliID = :CliID and CpjID > :CpjID or CpjID = :CpjID and CliID = :CliID and CpjConSeq > :CpjConSeq) ORDER BY CliID, CpjID, CpjConSeq ",true, GxErrorMask.GX_NOMASK, false, this,prmT001017,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001018", "SELECT CliID, CpjID, CpjConSeq FROM tb_clientepj_contato WHERE ( CliID < :CliID or CliID = :CliID and CpjID < :CpjID or CpjID = :CpjID and CliID = :CliID and CpjConSeq < :CpjConSeq) ORDER BY CliID DESC, CpjID DESC, CpjConSeq DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT001018,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001019", "SELECT CpjUltConSeq, CpjNomeFan, CpjRazaoSoc, CpjMatricula, CpjCNPJ, CpjCNPJFormat, CpjIE, CpjAtivo, CpjTelNum, CpjTelRam, CpjCelNum, CpjWppNum, CpjWebsite, CpjEmail, CpjTipoId FROM tb_clientepj WHERE CliID = :CliID AND CpjID = :CpjID  FOR UPDATE OF tb_clientepj NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT001019,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001020", "SAVEPOINT gxupdate;INSERT INTO tb_clientepj_contato(CpjConTipoSigla, CpjConTipoNome, CpjConGenSigla, CpjConGenNome, CpjConSeq, CpjConDelDataHora, CpjConDelData, CpjConDelHora, CpjConDelUsuId, CpjConDelUsuNome, CpjConCPF, CpjConCPFFormat, CpjConNome, CpjConNomePrim, CpjConSobrenome, CpjNomeSocial, CpjConNascimento, CpjConTelNum, CpjConTelRam, CpjConCelNum, CpjConWppNum, CpjConEmail, CpjConLIn, CpjConUltEnd, CpjConDel, CliID, CpjID, CpjConTipoID, CpjConGenID) VALUES(:CpjConTipoSigla, :CpjConTipoNome, :CpjConGenSigla, :CpjConGenNome, :CpjConSeq, :CpjConDelDataHora, :CpjConDelData, :CpjConDelHora, :CpjConDelUsuId, :CpjConDelUsuNome, :CpjConCPF, :CpjConCPFFormat, :CpjConNome, :CpjConNomePrim, :CpjConSobrenome, :CpjNomeSocial, :CpjConNascimento, :CpjConTelNum, :CpjConTelRam, :CpjConCelNum, :CpjConWppNum, :CpjConEmail, :CpjConLIn, :CpjConUltEnd, :CpjConDel, :CliID, :CpjID, :CpjConTipoID, :CpjConGenID);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT001020)
           ,new CursorDef("T001021", "SAVEPOINT gxupdate;UPDATE tb_clientepj_contato SET CpjConTipoSigla=:CpjConTipoSigla, CpjConTipoNome=:CpjConTipoNome, CpjConGenSigla=:CpjConGenSigla, CpjConGenNome=:CpjConGenNome, CpjConDelDataHora=:CpjConDelDataHora, CpjConDelData=:CpjConDelData, CpjConDelHora=:CpjConDelHora, CpjConDelUsuId=:CpjConDelUsuId, CpjConDelUsuNome=:CpjConDelUsuNome, CpjConCPF=:CpjConCPF, CpjConCPFFormat=:CpjConCPFFormat, CpjConNome=:CpjConNome, CpjConNomePrim=:CpjConNomePrim, CpjConSobrenome=:CpjConSobrenome, CpjNomeSocial=:CpjNomeSocial, CpjConNascimento=:CpjConNascimento, CpjConTelNum=:CpjConTelNum, CpjConTelRam=:CpjConTelRam, CpjConCelNum=:CpjConCelNum, CpjConWppNum=:CpjConWppNum, CpjConEmail=:CpjConEmail, CpjConLIn=:CpjConLIn, CpjConUltEnd=:CpjConUltEnd, CpjConDel=:CpjConDel, CpjConTipoID=:CpjConTipoID, CpjConGenID=:CpjConGenID  WHERE CliID = :CliID AND CpjID = :CpjID AND CpjConSeq = :CpjConSeq;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001021)
           ,new CursorDef("T001022", "SAVEPOINT gxupdate;DELETE FROM tb_clientepj_contato  WHERE CliID = :CliID AND CpjID = :CpjID AND CpjConSeq = :CpjConSeq;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001022)
           ,new CursorDef("T001023", "SELECT CliMatricula, CliNomeFamiliar FROM tb_cliente WHERE CliID = :CliID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001023,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001024", "SELECT CpjUltConSeq, CpjNomeFan, CpjRazaoSoc, CpjMatricula, CpjCNPJ, CpjCNPJFormat, CpjIE, CpjAtivo, CpjTelNum, CpjTelRam, CpjCelNum, CpjWppNum, CpjWebsite, CpjEmail, CpjTipoId FROM tb_clientepj WHERE CliID = :CliID AND CpjID = :CpjID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001024,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001025", "SELECT PjtSigla AS CpjTipoSigla, PjtNome AS CpjTipoNome FROM tb_clientepjtipo WHERE PjtID = :CpjTipoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001025,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001026", "SELECT PjtSigla AS CpjConTipoSigla, PjtNome AS CpjConTipoNome FROM tb_clientepjtipo WHERE PjtID = :CpjConTipoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001026,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001027", "SELECT GenSigla AS CpjConGenSigla, GenNome AS CpjConGenNome FROM tb_genero WHERE GenID = :CpjConGenID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001027,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001028", "SELECT CliID, CpjID, CpjConSeq, CpjConEndSeq FROM tb_clientepj_contato_end WHERE CliID = :CliID AND CpjID = :CpjID AND CpjConSeq = :CpjConSeq ",true, GxErrorMask.GX_NOMASK, false, this,prmT001028,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001029", "SAVEPOINT gxupdate;UPDATE tb_clientepj SET CpjUltConSeq=:CpjUltConSeq  WHERE CliID = :CliID AND CpjID = :CpjID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001029)
           ,new CursorDef("T001030", "SELECT CliID, CpjID, CpjConSeq FROM tb_clientepj_contato ORDER BY CliID, CpjID, CpjConSeq ",true, GxErrorMask.GX_NOMASK, false, this,prmT001030,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001031", "SELECT CliID FROM tb_clientepj_contato WHERE (CliID = :CliID AND CpjID = :CpjID AND CpjConCPF = :CpjConCPF) AND (Not ( CliID = :CliID and CpjID = :CpjID and CpjConSeq = :CpjConSeq)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT001031,1, GxCacheFrequency.OFF ,true,false )
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
              ((short[]) buf[0])[0] = rslt.getShort(1);
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
              ((long[]) buf[11])[0] = rslt.getLong(7);
              ((string[]) buf[12])[0] = rslt.getVarchar(8);
              ((string[]) buf[13])[0] = rslt.getVarchar(9);
              ((string[]) buf[14])[0] = rslt.getVarchar(10);
              ((string[]) buf[15])[0] = rslt.getVarchar(11);
              ((string[]) buf[16])[0] = rslt.getVarchar(12);
              ((DateTime[]) buf[17])[0] = rslt.getGXDate(13);
              ((string[]) buf[18])[0] = rslt.getString(14, 20);
              ((bool[]) buf[19])[0] = rslt.wasNull(14);
              ((string[]) buf[20])[0] = rslt.getVarchar(15);
              ((bool[]) buf[21])[0] = rslt.wasNull(15);
              ((string[]) buf[22])[0] = rslt.getString(16, 20);
              ((bool[]) buf[23])[0] = rslt.wasNull(16);
              ((string[]) buf[24])[0] = rslt.getString(17, 20);
              ((bool[]) buf[25])[0] = rslt.wasNull(17);
              ((string[]) buf[26])[0] = rslt.getVarchar(18);
              ((bool[]) buf[27])[0] = rslt.wasNull(18);
              ((string[]) buf[28])[0] = rslt.getVarchar(19);
              ((bool[]) buf[29])[0] = rslt.wasNull(19);
              ((short[]) buf[30])[0] = rslt.getShort(20);
              ((bool[]) buf[31])[0] = rslt.wasNull(20);
              ((bool[]) buf[32])[0] = rslt.getBool(21);
              ((Guid[]) buf[33])[0] = rslt.getGuid(22);
              ((Guid[]) buf[34])[0] = rslt.getGuid(23);
              ((int[]) buf[35])[0] = rslt.getInt(24);
              ((int[]) buf[36])[0] = rslt.getInt(25);
              ((string[]) buf[37])[0] = rslt.getVarchar(26);
              ((string[]) buf[38])[0] = rslt.getVarchar(27);
              ((string[]) buf[39])[0] = rslt.getVarchar(28);
              ((string[]) buf[40])[0] = rslt.getVarchar(29);
              return;
           case 1 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
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
              ((long[]) buf[11])[0] = rslt.getLong(7);
              ((string[]) buf[12])[0] = rslt.getVarchar(8);
              ((string[]) buf[13])[0] = rslt.getVarchar(9);
              ((string[]) buf[14])[0] = rslt.getVarchar(10);
              ((string[]) buf[15])[0] = rslt.getVarchar(11);
              ((string[]) buf[16])[0] = rslt.getVarchar(12);
              ((DateTime[]) buf[17])[0] = rslt.getGXDate(13);
              ((string[]) buf[18])[0] = rslt.getString(14, 20);
              ((bool[]) buf[19])[0] = rslt.wasNull(14);
              ((string[]) buf[20])[0] = rslt.getVarchar(15);
              ((bool[]) buf[21])[0] = rslt.wasNull(15);
              ((string[]) buf[22])[0] = rslt.getString(16, 20);
              ((bool[]) buf[23])[0] = rslt.wasNull(16);
              ((string[]) buf[24])[0] = rslt.getString(17, 20);
              ((bool[]) buf[25])[0] = rslt.wasNull(17);
              ((string[]) buf[26])[0] = rslt.getVarchar(18);
              ((bool[]) buf[27])[0] = rslt.wasNull(18);
              ((string[]) buf[28])[0] = rslt.getVarchar(19);
              ((bool[]) buf[29])[0] = rslt.wasNull(19);
              ((short[]) buf[30])[0] = rslt.getShort(20);
              ((bool[]) buf[31])[0] = rslt.wasNull(20);
              ((bool[]) buf[32])[0] = rslt.getBool(21);
              ((Guid[]) buf[33])[0] = rslt.getGuid(22);
              ((Guid[]) buf[34])[0] = rslt.getGuid(23);
              ((int[]) buf[35])[0] = rslt.getInt(24);
              ((int[]) buf[36])[0] = rslt.getInt(25);
              ((string[]) buf[37])[0] = rslt.getVarchar(26);
              ((string[]) buf[38])[0] = rslt.getVarchar(27);
              ((string[]) buf[39])[0] = rslt.getVarchar(28);
              ((string[]) buf[40])[0] = rslt.getVarchar(29);
              return;
           case 2 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 3 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              ((string[]) buf[2])[0] = rslt.getVarchar(2);
              ((string[]) buf[3])[0] = rslt.getVarchar(3);
              ((long[]) buf[4])[0] = rslt.getLong(4);
              ((long[]) buf[5])[0] = rslt.getLong(5);
              ((string[]) buf[6])[0] = rslt.getVarchar(6);
              ((string[]) buf[7])[0] = rslt.getVarchar(7);
              ((bool[]) buf[8])[0] = rslt.getBool(8);
              ((string[]) buf[9])[0] = rslt.getString(9, 20);
              ((bool[]) buf[10])[0] = rslt.wasNull(9);
              ((string[]) buf[11])[0] = rslt.getVarchar(10);
              ((bool[]) buf[12])[0] = rslt.wasNull(10);
              ((string[]) buf[13])[0] = rslt.getString(11, 20);
              ((bool[]) buf[14])[0] = rslt.wasNull(11);
              ((string[]) buf[15])[0] = rslt.getString(12, 20);
              ((bool[]) buf[16])[0] = rslt.wasNull(12);
              ((string[]) buf[17])[0] = rslt.getVarchar(13);
              ((bool[]) buf[18])[0] = rslt.wasNull(13);
              ((string[]) buf[19])[0] = rslt.getVarchar(14);
              ((bool[]) buf[20])[0] = rslt.wasNull(14);
              ((int[]) buf[21])[0] = rslt.getInt(15);
              return;
           case 4 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              ((string[]) buf[2])[0] = rslt.getVarchar(2);
              ((string[]) buf[3])[0] = rslt.getVarchar(3);
              ((long[]) buf[4])[0] = rslt.getLong(4);
              ((long[]) buf[5])[0] = rslt.getLong(5);
              ((string[]) buf[6])[0] = rslt.getVarchar(6);
              ((string[]) buf[7])[0] = rslt.getVarchar(7);
              ((bool[]) buf[8])[0] = rslt.getBool(8);
              ((string[]) buf[9])[0] = rslt.getString(9, 20);
              ((bool[]) buf[10])[0] = rslt.wasNull(9);
              ((string[]) buf[11])[0] = rslt.getVarchar(10);
              ((bool[]) buf[12])[0] = rslt.wasNull(10);
              ((string[]) buf[13])[0] = rslt.getString(11, 20);
              ((bool[]) buf[14])[0] = rslt.wasNull(11);
              ((string[]) buf[15])[0] = rslt.getString(12, 20);
              ((bool[]) buf[16])[0] = rslt.wasNull(12);
              ((string[]) buf[17])[0] = rslt.getVarchar(13);
              ((bool[]) buf[18])[0] = rslt.wasNull(13);
              ((string[]) buf[19])[0] = rslt.getVarchar(14);
              ((bool[]) buf[20])[0] = rslt.wasNull(14);
              ((int[]) buf[21])[0] = rslt.getInt(15);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 8 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3, true);
              ((bool[]) buf[4])[0] = rslt.wasNull(3);
              ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(4);
              ((bool[]) buf[6])[0] = rslt.wasNull(4);
              ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(5);
              ((bool[]) buf[8])[0] = rslt.wasNull(5);
              ((string[]) buf[9])[0] = rslt.getString(6, 40);
              ((bool[]) buf[10])[0] = rslt.wasNull(6);
              ((string[]) buf[11])[0] = rslt.getVarchar(7);
              ((bool[]) buf[12])[0] = rslt.wasNull(7);
              ((long[]) buf[13])[0] = rslt.getLong(8);
              ((string[]) buf[14])[0] = rslt.getVarchar(9);
              ((string[]) buf[15])[0] = rslt.getVarchar(10);
              ((string[]) buf[16])[0] = rslt.getVarchar(11);
              ((string[]) buf[17])[0] = rslt.getVarchar(12);
              ((string[]) buf[18])[0] = rslt.getVarchar(13);
              ((long[]) buf[19])[0] = rslt.getLong(14);
              ((long[]) buf[20])[0] = rslt.getLong(15);
              ((string[]) buf[21])[0] = rslt.getVarchar(16);
              ((string[]) buf[22])[0] = rslt.getVarchar(17);
              ((bool[]) buf[23])[0] = rslt.getBool(18);
              ((string[]) buf[24])[0] = rslt.getString(19, 20);
              ((bool[]) buf[25])[0] = rslt.wasNull(19);
              ((string[]) buf[26])[0] = rslt.getVarchar(20);
              ((bool[]) buf[27])[0] = rslt.wasNull(20);
              ((string[]) buf[28])[0] = rslt.getString(21, 20);
              ((bool[]) buf[29])[0] = rslt.wasNull(21);
              ((string[]) buf[30])[0] = rslt.getString(22, 20);
              ((bool[]) buf[31])[0] = rslt.wasNull(22);
              ((string[]) buf[32])[0] = rslt.getVarchar(23);
              ((bool[]) buf[33])[0] = rslt.wasNull(23);
              ((string[]) buf[34])[0] = rslt.getVarchar(24);
              ((bool[]) buf[35])[0] = rslt.wasNull(24);
              ((string[]) buf[36])[0] = rslt.getVarchar(25);
              ((string[]) buf[37])[0] = rslt.getVarchar(26);
              ((long[]) buf[38])[0] = rslt.getLong(27);
              ((string[]) buf[39])[0] = rslt.getVarchar(28);
              ((string[]) buf[40])[0] = rslt.getVarchar(29);
              ((string[]) buf[41])[0] = rslt.getVarchar(30);
              ((string[]) buf[42])[0] = rslt.getVarchar(31);
              ((string[]) buf[43])[0] = rslt.getVarchar(32);
              ((string[]) buf[44])[0] = rslt.getVarchar(33);
              ((string[]) buf[45])[0] = rslt.getVarchar(34);
              ((DateTime[]) buf[46])[0] = rslt.getGXDate(35);
              ((string[]) buf[47])[0] = rslt.getString(36, 20);
              ((bool[]) buf[48])[0] = rslt.wasNull(36);
              ((string[]) buf[49])[0] = rslt.getVarchar(37);
              ((bool[]) buf[50])[0] = rslt.wasNull(37);
              ((string[]) buf[51])[0] = rslt.getString(38, 20);
              ((bool[]) buf[52])[0] = rslt.wasNull(38);
              ((string[]) buf[53])[0] = rslt.getString(39, 20);
              ((bool[]) buf[54])[0] = rslt.wasNull(39);
              ((string[]) buf[55])[0] = rslt.getVarchar(40);
              ((bool[]) buf[56])[0] = rslt.wasNull(40);
              ((string[]) buf[57])[0] = rslt.getVarchar(41);
              ((bool[]) buf[58])[0] = rslt.wasNull(41);
              ((short[]) buf[59])[0] = rslt.getShort(42);
              ((bool[]) buf[60])[0] = rslt.wasNull(42);
              ((bool[]) buf[61])[0] = rslt.getBool(43);
              ((Guid[]) buf[62])[0] = rslt.getGuid(44);
              ((Guid[]) buf[63])[0] = rslt.getGuid(45);
              ((int[]) buf[64])[0] = rslt.getInt(46);
              ((int[]) buf[65])[0] = rslt.getInt(47);
              ((int[]) buf[66])[0] = rslt.getInt(48);
              return;
           case 9 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 10 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 14 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              return;
           case 15 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              return;
           case 16 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              return;
           case 17 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              ((string[]) buf[2])[0] = rslt.getVarchar(2);
              ((string[]) buf[3])[0] = rslt.getVarchar(3);
              ((long[]) buf[4])[0] = rslt.getLong(4);
              ((long[]) buf[5])[0] = rslt.getLong(5);
              ((string[]) buf[6])[0] = rslt.getVarchar(6);
              ((string[]) buf[7])[0] = rslt.getVarchar(7);
              ((bool[]) buf[8])[0] = rslt.getBool(8);
              ((string[]) buf[9])[0] = rslt.getString(9, 20);
              ((bool[]) buf[10])[0] = rslt.wasNull(9);
              ((string[]) buf[11])[0] = rslt.getVarchar(10);
              ((bool[]) buf[12])[0] = rslt.wasNull(10);
              ((string[]) buf[13])[0] = rslt.getString(11, 20);
              ((bool[]) buf[14])[0] = rslt.wasNull(11);
              ((string[]) buf[15])[0] = rslt.getString(12, 20);
              ((bool[]) buf[16])[0] = rslt.wasNull(12);
              ((string[]) buf[17])[0] = rslt.getVarchar(13);
              ((bool[]) buf[18])[0] = rslt.wasNull(13);
              ((string[]) buf[19])[0] = rslt.getVarchar(14);
              ((bool[]) buf[20])[0] = rslt.wasNull(14);
              ((int[]) buf[21])[0] = rslt.getInt(15);
              return;
           case 21 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 22 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              ((string[]) buf[2])[0] = rslt.getVarchar(2);
              ((string[]) buf[3])[0] = rslt.getVarchar(3);
              ((long[]) buf[4])[0] = rslt.getLong(4);
              ((long[]) buf[5])[0] = rslt.getLong(5);
              ((string[]) buf[6])[0] = rslt.getVarchar(6);
              ((string[]) buf[7])[0] = rslt.getVarchar(7);
              ((bool[]) buf[8])[0] = rslt.getBool(8);
              ((string[]) buf[9])[0] = rslt.getString(9, 20);
              ((bool[]) buf[10])[0] = rslt.wasNull(9);
              ((string[]) buf[11])[0] = rslt.getVarchar(10);
              ((bool[]) buf[12])[0] = rslt.wasNull(10);
              ((string[]) buf[13])[0] = rslt.getString(11, 20);
              ((bool[]) buf[14])[0] = rslt.wasNull(11);
              ((string[]) buf[15])[0] = rslt.getString(12, 20);
              ((bool[]) buf[16])[0] = rslt.wasNull(12);
              ((string[]) buf[17])[0] = rslt.getVarchar(13);
              ((bool[]) buf[18])[0] = rslt.wasNull(13);
              ((string[]) buf[19])[0] = rslt.getVarchar(14);
              ((bool[]) buf[20])[0] = rslt.wasNull(14);
              ((int[]) buf[21])[0] = rslt.getInt(15);
              return;
           case 23 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 24 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 25 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 26 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              return;
           case 28 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              return;
           case 29 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
     }
  }

}

}
