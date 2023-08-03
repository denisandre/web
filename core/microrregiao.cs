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
   public class microrregiao : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_12") == 0 )
         {
            A25MicrorregiaoMesoID = (int)(Math.Round(NumberUtil.Val( GetPar( "MicrorregiaoMesoID"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A25MicrorregiaoMesoID", StringUtil.LTrimStr( (decimal)(A25MicrorregiaoMesoID), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_12( A25MicrorregiaoMesoID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_13") == 0 )
         {
            A27MicrorregiaoMesoUFID = (int)(Math.Round(NumberUtil.Val( GetPar( "MicrorregiaoMesoUFID"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A27MicrorregiaoMesoUFID", StringUtil.LTrimStr( (decimal)(A27MicrorregiaoMesoUFID), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_13( A27MicrorregiaoMesoUFID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_14") == 0 )
         {
            A31MicrorregiaoMesoUFRegID = (int)(Math.Round(NumberUtil.Val( GetPar( "MicrorregiaoMesoUFRegID"), "."), 18, MidpointRounding.ToEven));
            n31MicrorregiaoMesoUFRegID = false;
            AssignAttri("", false, "A31MicrorregiaoMesoUFRegID", StringUtil.LTrimStr( (decimal)(A31MicrorregiaoMesoUFRegID), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_14( A31MicrorregiaoMesoUFRegID) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "core.microrregiao.aspx")), "core.microrregiao.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "core.microrregiao.aspx")))) ;
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
                  AV7MicrorregiaoID = (int)(Math.Round(NumberUtil.Val( GetPar( "MicrorregiaoID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7MicrorregiaoID", StringUtil.LTrimStr( (decimal)(AV7MicrorregiaoID), 9, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vMICRORREGIAOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7MicrorregiaoID), "ZZZ,ZZZ,ZZ9"), context));
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
            Form.Meta.addItem("description", "Microrregião", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtMicrorregiaoID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public microrregiao( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public microrregiao( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_MicrorregiaoID )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7MicrorregiaoID = aP1_MicrorregiaoID;
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
            return "microrregiao_Execute" ;
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMicrorregiaoID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMicrorregiaoID_Internalname, "ID", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMicrorregiaoID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A23MicrorregiaoID), 11, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A23MicrorregiaoID), "ZZZ,ZZZ,ZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMicrorregiaoID_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtMicrorregiaoID_Enabled, 1, "text", "", 11, "chr", 1, "row", 11, 0, 0, 0, 0, -1, 0, true, "core\\ID", "end", false, "", "HLP_core\\microrregiao.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMicrorregiaoNome_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMicrorregiaoNome_Internalname, "Nome", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMicrorregiaoNome_Internalname, A24MicrorregiaoNome, StringUtil.RTrim( context.localUtil.Format( A24MicrorregiaoNome, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMicrorregiaoNome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtMicrorregiaoNome_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\microrregiao.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedmicrorregiaomesoid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockmicrorregiaomesoid_Internalname, "Mesorregião", "", "", lblTextblockmicrorregiaomesoid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_core\\microrregiao.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_microrregiaomesoid.SetProperty("Caption", Combo_microrregiaomesoid_Caption);
         ucCombo_microrregiaomesoid.SetProperty("Cls", Combo_microrregiaomesoid_Cls);
         ucCombo_microrregiaomesoid.SetProperty("DataListProc", Combo_microrregiaomesoid_Datalistproc);
         ucCombo_microrregiaomesoid.SetProperty("DataListProcParametersPrefix", Combo_microrregiaomesoid_Datalistprocparametersprefix);
         ucCombo_microrregiaomesoid.SetProperty("EmptyItem", Combo_microrregiaomesoid_Emptyitem);
         ucCombo_microrregiaomesoid.SetProperty("DropDownOptionsTitleSettingsIcons", AV16DDO_TitleSettingsIcons);
         ucCombo_microrregiaomesoid.SetProperty("DropDownOptionsData", AV15MicrorregiaoMesoID_Data);
         ucCombo_microrregiaomesoid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_microrregiaomesoid_Internalname, "COMBO_MICRORREGIAOMESOIDContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMicrorregiaoMesoID_Internalname, "Mesoregião", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMicrorregiaoMesoID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A25MicrorregiaoMesoID), 11, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A25MicrorregiaoMesoID), "ZZZ,ZZZ,ZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMicrorregiaoMesoID_Jsonclick, 0, "Attribute", "", "", "", "", edtMicrorregiaoMesoID_Visible, edtMicrorregiaoMesoID_Enabled, 1, "text", "", 11, "chr", 1, "row", 11, 0, 0, 0, 0, -1, 0, true, "core\\ID", "end", false, "", "HLP_core\\microrregiao.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\microrregiao.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\microrregiao.htm");
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
         GxWebStd.gx_div_start( context, divSectionattribute_microrregiaomesoid_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtavCombomicrorregiaomesoid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20ComboMicrorregiaoMesoID), 11, 0, ",", "")), StringUtil.LTrim( ((edtavCombomicrorregiaomesoid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV20ComboMicrorregiaoMesoID), "ZZZ,ZZZ,ZZ9") : context.localUtil.Format( (decimal)(AV20ComboMicrorregiaoMesoID), "ZZZ,ZZZ,ZZ9"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombomicrorregiaomesoid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombomicrorregiaomesoid_Visible, edtavCombomicrorregiaomesoid_Enabled, 0, "text", "", 11, "chr", 1, "row", 11, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_core\\microrregiao.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtMicrorregiaoMesoUFID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A27MicrorregiaoMesoUFID), 11, 0, ",", "")), StringUtil.LTrim( ((edtMicrorregiaoMesoUFID_Enabled!=0) ? context.localUtil.Format( (decimal)(A27MicrorregiaoMesoUFID), "ZZZ,ZZZ,ZZ9") : context.localUtil.Format( (decimal)(A27MicrorregiaoMesoUFID), "ZZZ,ZZZ,ZZ9"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMicrorregiaoMesoUFID_Jsonclick, 0, "Attribute", "", "", "", "", edtMicrorregiaoMesoUFID_Visible, edtMicrorregiaoMesoUFID_Enabled, 0, "text", "", 11, "chr", 1, "row", 11, 0, 0, 0, 0, -1, 0, true, "core\\ID", "end", false, "", "HLP_core\\microrregiao.htm");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtMicrorregiaoMesoUFSigla_Internalname, A28MicrorregiaoMesoUFSigla, StringUtil.RTrim( context.localUtil.Format( A28MicrorregiaoMesoUFSigla, "@!")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMicrorregiaoMesoUFSigla_Jsonclick, 0, "Attribute", "", "", "", "", edtMicrorregiaoMesoUFSigla_Visible, edtMicrorregiaoMesoUFSigla_Enabled, 0, "text", "", 2, "chr", 1, "row", 2, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\microrregiao.htm");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtMicrorregiaoMesoUFNome_Internalname, A29MicrorregiaoMesoUFNome, StringUtil.RTrim( context.localUtil.Format( A29MicrorregiaoMesoUFNome, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMicrorregiaoMesoUFNome_Jsonclick, 0, "Attribute", "", "", "", "", edtMicrorregiaoMesoUFNome_Visible, edtMicrorregiaoMesoUFNome_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\microrregiao.htm");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtMicrorregiaoMesoUFSiglaNome_Internalname, A30MicrorregiaoMesoUFSiglaNome, StringUtil.RTrim( context.localUtil.Format( A30MicrorregiaoMesoUFSiglaNome, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMicrorregiaoMesoUFSiglaNome_Jsonclick, 0, "Attribute", "", "", "", "", edtMicrorregiaoMesoUFSiglaNome_Visible, edtMicrorregiaoMesoUFSiglaNome_Enabled, 0, "text", "", 70, "chr", 1, "row", 70, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\microrregiao.htm");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtMicrorregiaoMesoUFRegID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A31MicrorregiaoMesoUFRegID), 11, 0, ",", "")), StringUtil.LTrim( ((edtMicrorregiaoMesoUFRegID_Enabled!=0) ? context.localUtil.Format( (decimal)(A31MicrorregiaoMesoUFRegID), "ZZZ,ZZZ,ZZ9") : context.localUtil.Format( (decimal)(A31MicrorregiaoMesoUFRegID), "ZZZ,ZZZ,ZZ9"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMicrorregiaoMesoUFRegID_Jsonclick, 0, "Attribute", "", "", "", "", edtMicrorregiaoMesoUFRegID_Visible, edtMicrorregiaoMesoUFRegID_Enabled, 0, "text", "", 11, "chr", 1, "row", 11, 0, 0, 0, 0, -1, 0, true, "core\\ID", "end", false, "", "HLP_core\\microrregiao.htm");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtMicrorregiaoMesoUFRegSigla_Internalname, A32MicrorregiaoMesoUFRegSigla, StringUtil.RTrim( context.localUtil.Format( A32MicrorregiaoMesoUFRegSigla, "@!")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMicrorregiaoMesoUFRegSigla_Jsonclick, 0, "Attribute", "", "", "", "", edtMicrorregiaoMesoUFRegSigla_Visible, edtMicrorregiaoMesoUFRegSigla_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\microrregiao.htm");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtMicrorregiaoMesoUFRegNome_Internalname, A33MicrorregiaoMesoUFRegNome, StringUtil.RTrim( context.localUtil.Format( A33MicrorregiaoMesoUFRegNome, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMicrorregiaoMesoUFRegNome_Jsonclick, 0, "Attribute", "", "", "", "", edtMicrorregiaoMesoUFRegNome_Visible, edtMicrorregiaoMesoUFRegNome_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\microrregiao.htm");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtMicrorregiaoMesoUFRegSiglaNome_Internalname, A34MicrorregiaoMesoUFRegSiglaNome, StringUtil.RTrim( context.localUtil.Format( A34MicrorregiaoMesoUFRegSiglaNome, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMicrorregiaoMesoUFRegSiglaNome_Jsonclick, 0, "Attribute", "", "", "", "", edtMicrorregiaoMesoUFRegSiglaNome_Visible, edtMicrorregiaoMesoUFRegSiglaNome_Enabled, 0, "text", "", 70, "chr", 1, "row", 70, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\microrregiao.htm");
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
         E11042 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV16DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( "vMICRORREGIAOMESOID_DATA"), AV15MicrorregiaoMesoID_Data);
               /* Read saved values. */
               Z23MicrorregiaoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z23MicrorregiaoID"), ",", "."), 18, MidpointRounding.ToEven));
               Z30MicrorregiaoMesoUFSiglaNome = cgiGet( "Z30MicrorregiaoMesoUFSiglaNome");
               n30MicrorregiaoMesoUFSiglaNome = (String.IsNullOrEmpty(StringUtil.RTrim( A30MicrorregiaoMesoUFSiglaNome)) ? true : false);
               Z34MicrorregiaoMesoUFRegSiglaNome = cgiGet( "Z34MicrorregiaoMesoUFRegSiglaNome");
               n34MicrorregiaoMesoUFRegSiglaNome = (String.IsNullOrEmpty(StringUtil.RTrim( A34MicrorregiaoMesoUFRegSiglaNome)) ? true : false);
               Z24MicrorregiaoNome = cgiGet( "Z24MicrorregiaoNome");
               Z25MicrorregiaoMesoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z25MicrorregiaoMesoID"), ",", "."), 18, MidpointRounding.ToEven));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N25MicrorregiaoMesoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N25MicrorregiaoMesoID"), ",", "."), 18, MidpointRounding.ToEven));
               AV7MicrorregiaoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vMICRORREGIAOID"), ",", "."), 18, MidpointRounding.ToEven));
               AV13Insert_MicrorregiaoMesoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_MICRORREGIAOMESOID"), ",", "."), 18, MidpointRounding.ToEven));
               A26MicrorregiaoMesoNome = cgiGet( "MICRORREGIAOMESONOME");
               AV25Pgmname = cgiGet( "vPGMNAME");
               Combo_microrregiaomesoid_Objectcall = cgiGet( "COMBO_MICRORREGIAOMESOID_Objectcall");
               Combo_microrregiaomesoid_Class = cgiGet( "COMBO_MICRORREGIAOMESOID_Class");
               Combo_microrregiaomesoid_Icontype = cgiGet( "COMBO_MICRORREGIAOMESOID_Icontype");
               Combo_microrregiaomesoid_Icon = cgiGet( "COMBO_MICRORREGIAOMESOID_Icon");
               Combo_microrregiaomesoid_Caption = cgiGet( "COMBO_MICRORREGIAOMESOID_Caption");
               Combo_microrregiaomesoid_Tooltip = cgiGet( "COMBO_MICRORREGIAOMESOID_Tooltip");
               Combo_microrregiaomesoid_Cls = cgiGet( "COMBO_MICRORREGIAOMESOID_Cls");
               Combo_microrregiaomesoid_Selectedvalue_set = cgiGet( "COMBO_MICRORREGIAOMESOID_Selectedvalue_set");
               Combo_microrregiaomesoid_Selectedvalue_get = cgiGet( "COMBO_MICRORREGIAOMESOID_Selectedvalue_get");
               Combo_microrregiaomesoid_Selectedtext_set = cgiGet( "COMBO_MICRORREGIAOMESOID_Selectedtext_set");
               Combo_microrregiaomesoid_Selectedtext_get = cgiGet( "COMBO_MICRORREGIAOMESOID_Selectedtext_get");
               Combo_microrregiaomesoid_Gamoauthtoken = cgiGet( "COMBO_MICRORREGIAOMESOID_Gamoauthtoken");
               Combo_microrregiaomesoid_Ddointernalname = cgiGet( "COMBO_MICRORREGIAOMESOID_Ddointernalname");
               Combo_microrregiaomesoid_Titlecontrolalign = cgiGet( "COMBO_MICRORREGIAOMESOID_Titlecontrolalign");
               Combo_microrregiaomesoid_Dropdownoptionstype = cgiGet( "COMBO_MICRORREGIAOMESOID_Dropdownoptionstype");
               Combo_microrregiaomesoid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_MICRORREGIAOMESOID_Enabled"));
               Combo_microrregiaomesoid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_MICRORREGIAOMESOID_Visible"));
               Combo_microrregiaomesoid_Titlecontrolidtoreplace = cgiGet( "COMBO_MICRORREGIAOMESOID_Titlecontrolidtoreplace");
               Combo_microrregiaomesoid_Datalisttype = cgiGet( "COMBO_MICRORREGIAOMESOID_Datalisttype");
               Combo_microrregiaomesoid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_MICRORREGIAOMESOID_Allowmultipleselection"));
               Combo_microrregiaomesoid_Datalistfixedvalues = cgiGet( "COMBO_MICRORREGIAOMESOID_Datalistfixedvalues");
               Combo_microrregiaomesoid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_MICRORREGIAOMESOID_Isgriditem"));
               Combo_microrregiaomesoid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_MICRORREGIAOMESOID_Hasdescription"));
               Combo_microrregiaomesoid_Datalistproc = cgiGet( "COMBO_MICRORREGIAOMESOID_Datalistproc");
               Combo_microrregiaomesoid_Datalistprocparametersprefix = cgiGet( "COMBO_MICRORREGIAOMESOID_Datalistprocparametersprefix");
               Combo_microrregiaomesoid_Remoteservicesparameters = cgiGet( "COMBO_MICRORREGIAOMESOID_Remoteservicesparameters");
               Combo_microrregiaomesoid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_MICRORREGIAOMESOID_Datalistupdateminimumcharacters"), ",", "."), 18, MidpointRounding.ToEven));
               Combo_microrregiaomesoid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_MICRORREGIAOMESOID_Includeonlyselectedoption"));
               Combo_microrregiaomesoid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_MICRORREGIAOMESOID_Includeselectalloption"));
               Combo_microrregiaomesoid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_MICRORREGIAOMESOID_Emptyitem"));
               Combo_microrregiaomesoid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_MICRORREGIAOMESOID_Includeaddnewoption"));
               Combo_microrregiaomesoid_Htmltemplate = cgiGet( "COMBO_MICRORREGIAOMESOID_Htmltemplate");
               Combo_microrregiaomesoid_Multiplevaluestype = cgiGet( "COMBO_MICRORREGIAOMESOID_Multiplevaluestype");
               Combo_microrregiaomesoid_Loadingdata = cgiGet( "COMBO_MICRORREGIAOMESOID_Loadingdata");
               Combo_microrregiaomesoid_Noresultsfound = cgiGet( "COMBO_MICRORREGIAOMESOID_Noresultsfound");
               Combo_microrregiaomesoid_Emptyitemtext = cgiGet( "COMBO_MICRORREGIAOMESOID_Emptyitemtext");
               Combo_microrregiaomesoid_Onlyselectedvalues = cgiGet( "COMBO_MICRORREGIAOMESOID_Onlyselectedvalues");
               Combo_microrregiaomesoid_Selectalltext = cgiGet( "COMBO_MICRORREGIAOMESOID_Selectalltext");
               Combo_microrregiaomesoid_Multiplevaluesseparator = cgiGet( "COMBO_MICRORREGIAOMESOID_Multiplevaluesseparator");
               Combo_microrregiaomesoid_Addnewoptiontext = cgiGet( "COMBO_MICRORREGIAOMESOID_Addnewoptiontext");
               Combo_microrregiaomesoid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_MICRORREGIAOMESOID_Gxcontroltype"), ",", "."), 18, MidpointRounding.ToEven));
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
               if ( ( ( context.localUtil.CToN( cgiGet( edtMicrorregiaoID_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMicrorregiaoID_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MICRORREGIAOID");
                  AnyError = 1;
                  GX_FocusControl = edtMicrorregiaoID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A23MicrorregiaoID = 0;
                  AssignAttri("", false, "A23MicrorregiaoID", StringUtil.LTrimStr( (decimal)(A23MicrorregiaoID), 9, 0));
               }
               else
               {
                  A23MicrorregiaoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtMicrorregiaoID_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A23MicrorregiaoID", StringUtil.LTrimStr( (decimal)(A23MicrorregiaoID), 9, 0));
               }
               A24MicrorregiaoNome = cgiGet( edtMicrorregiaoNome_Internalname);
               AssignAttri("", false, "A24MicrorregiaoNome", A24MicrorregiaoNome);
               if ( ( ( context.localUtil.CToN( cgiGet( edtMicrorregiaoMesoID_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMicrorregiaoMesoID_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MICRORREGIAOMESOID");
                  AnyError = 1;
                  GX_FocusControl = edtMicrorregiaoMesoID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A25MicrorregiaoMesoID = 0;
                  AssignAttri("", false, "A25MicrorregiaoMesoID", StringUtil.LTrimStr( (decimal)(A25MicrorregiaoMesoID), 9, 0));
               }
               else
               {
                  A25MicrorregiaoMesoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtMicrorregiaoMesoID_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A25MicrorregiaoMesoID", StringUtil.LTrimStr( (decimal)(A25MicrorregiaoMesoID), 9, 0));
               }
               AV20ComboMicrorregiaoMesoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavCombomicrorregiaomesoid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV20ComboMicrorregiaoMesoID", StringUtil.LTrimStr( (decimal)(AV20ComboMicrorregiaoMesoID), 9, 0));
               A27MicrorregiaoMesoUFID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtMicrorregiaoMesoUFID_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A27MicrorregiaoMesoUFID", StringUtil.LTrimStr( (decimal)(A27MicrorregiaoMesoUFID), 9, 0));
               A28MicrorregiaoMesoUFSigla = StringUtil.Upper( cgiGet( edtMicrorregiaoMesoUFSigla_Internalname));
               n28MicrorregiaoMesoUFSigla = false;
               AssignAttri("", false, "A28MicrorregiaoMesoUFSigla", A28MicrorregiaoMesoUFSigla);
               A29MicrorregiaoMesoUFNome = cgiGet( edtMicrorregiaoMesoUFNome_Internalname);
               n29MicrorregiaoMesoUFNome = false;
               AssignAttri("", false, "A29MicrorregiaoMesoUFNome", A29MicrorregiaoMesoUFNome);
               A30MicrorregiaoMesoUFSiglaNome = cgiGet( edtMicrorregiaoMesoUFSiglaNome_Internalname);
               n30MicrorregiaoMesoUFSiglaNome = false;
               AssignAttri("", false, "A30MicrorregiaoMesoUFSiglaNome", A30MicrorregiaoMesoUFSiglaNome);
               A31MicrorregiaoMesoUFRegID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtMicrorregiaoMesoUFRegID_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               n31MicrorregiaoMesoUFRegID = false;
               AssignAttri("", false, "A31MicrorregiaoMesoUFRegID", StringUtil.LTrimStr( (decimal)(A31MicrorregiaoMesoUFRegID), 9, 0));
               A32MicrorregiaoMesoUFRegSigla = StringUtil.Upper( cgiGet( edtMicrorregiaoMesoUFRegSigla_Internalname));
               n32MicrorregiaoMesoUFRegSigla = false;
               AssignAttri("", false, "A32MicrorregiaoMesoUFRegSigla", A32MicrorregiaoMesoUFRegSigla);
               A33MicrorregiaoMesoUFRegNome = cgiGet( edtMicrorregiaoMesoUFRegNome_Internalname);
               n33MicrorregiaoMesoUFRegNome = false;
               AssignAttri("", false, "A33MicrorregiaoMesoUFRegNome", A33MicrorregiaoMesoUFRegNome);
               A34MicrorregiaoMesoUFRegSiglaNome = cgiGet( edtMicrorregiaoMesoUFRegSiglaNome_Internalname);
               n34MicrorregiaoMesoUFRegSiglaNome = false;
               AssignAttri("", false, "A34MicrorregiaoMesoUFRegSiglaNome", A34MicrorregiaoMesoUFRegSiglaNome);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"microrregiao");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A23MicrorregiaoID != Z23MicrorregiaoID ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("core\\microrregiao:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A23MicrorregiaoID = (int)(Math.Round(NumberUtil.Val( GetPar( "MicrorregiaoID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A23MicrorregiaoID", StringUtil.LTrimStr( (decimal)(A23MicrorregiaoID), 9, 0));
                  getEqualNoModal( ) ;
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  disable_std_buttons( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  if ( IsDsp( ) )
                  {
                     sMode4 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode4;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound4 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_040( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "MICRORREGIAOID");
                        AnyError = 1;
                        GX_FocusControl = edtMicrorregiaoID_Internalname;
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
                        if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E11042 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12042 ();
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
            E12042 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll044( ) ;
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
            DisableAttributes044( ) ;
         }
         AssignProp("", false, edtavCombomicrorregiaomesoid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombomicrorregiaomesoid_Enabled), 5, 0), true);
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

      protected void CONFIRM_040( )
      {
         BeforeValidate044( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls044( ) ;
            }
            else
            {
               CheckExtendedTable044( ) ;
               CloseExtendedTableCursors044( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption040( )
      {
      }

      protected void E11042( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV16DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV16DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         AV22GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV23GAMErrors);
         Combo_microrregiaomesoid_Gamoauthtoken = AV22GAMSession.gxTpr_Token;
         ucCombo_microrregiaomesoid.SendProperty(context, "", false, Combo_microrregiaomesoid_Internalname, "GAMOAuthToken", Combo_microrregiaomesoid_Gamoauthtoken);
         edtMicrorregiaoMesoID_Visible = 0;
         AssignProp("", false, edtMicrorregiaoMesoID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMicrorregiaoMesoID_Visible), 5, 0), true);
         AV20ComboMicrorregiaoMesoID = 0;
         AssignAttri("", false, "AV20ComboMicrorregiaoMesoID", StringUtil.LTrimStr( (decimal)(AV20ComboMicrorregiaoMesoID), 9, 0));
         edtavCombomicrorregiaomesoid_Visible = 0;
         AssignProp("", false, edtavCombomicrorregiaomesoid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombomicrorregiaomesoid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOMICRORREGIAOMESOID' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV25Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV26GXV1 = 1;
            AssignAttri("", false, "AV26GXV1", StringUtil.LTrimStr( (decimal)(AV26GXV1), 8, 0));
            while ( AV26GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV14TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV26GXV1));
               if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "MicrorregiaoMesoID") == 0 )
               {
                  AV13Insert_MicrorregiaoMesoID = (int)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV13Insert_MicrorregiaoMesoID", StringUtil.LTrimStr( (decimal)(AV13Insert_MicrorregiaoMesoID), 9, 0));
                  if ( ! (0==AV13Insert_MicrorregiaoMesoID) )
                  {
                     AV20ComboMicrorregiaoMesoID = AV13Insert_MicrorregiaoMesoID;
                     AssignAttri("", false, "AV20ComboMicrorregiaoMesoID", StringUtil.LTrimStr( (decimal)(AV20ComboMicrorregiaoMesoID), 9, 0));
                     Combo_microrregiaomesoid_Selectedvalue_set = StringUtil.Trim( StringUtil.Str( (decimal)(AV20ComboMicrorregiaoMesoID), 9, 0));
                     ucCombo_microrregiaomesoid.SendProperty(context, "", false, Combo_microrregiaomesoid_Internalname, "SelectedValue_set", Combo_microrregiaomesoid_Selectedvalue_set);
                     GXt_char2 = AV19Combo_DataJson;
                     new GeneXus.Programs.core.microrregiaoloaddvcombo(context ).execute(  "MicrorregiaoMesoID",  "GET",  false,  AV7MicrorregiaoID,  AV14TrnContextAtt.gxTpr_Attributevalue, out  AV17ComboSelectedValue, out  AV18ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV17ComboSelectedValue", AV17ComboSelectedValue);
                     AssignAttri("", false, "AV18ComboSelectedText", AV18ComboSelectedText);
                     AV19Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV19Combo_DataJson", AV19Combo_DataJson);
                     Combo_microrregiaomesoid_Selectedtext_set = AV18ComboSelectedText;
                     ucCombo_microrregiaomesoid.SendProperty(context, "", false, Combo_microrregiaomesoid_Internalname, "SelectedText_set", Combo_microrregiaomesoid_Selectedtext_set);
                     Combo_microrregiaomesoid_Enabled = false;
                     ucCombo_microrregiaomesoid.SendProperty(context, "", false, Combo_microrregiaomesoid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_microrregiaomesoid_Enabled));
                  }
               }
               AV26GXV1 = (int)(AV26GXV1+1);
               AssignAttri("", false, "AV26GXV1", StringUtil.LTrimStr( (decimal)(AV26GXV1), 8, 0));
            }
         }
         edtMicrorregiaoMesoUFID_Visible = 0;
         AssignProp("", false, edtMicrorregiaoMesoUFID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMicrorregiaoMesoUFID_Visible), 5, 0), true);
         edtMicrorregiaoMesoUFSigla_Visible = 0;
         AssignProp("", false, edtMicrorregiaoMesoUFSigla_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMicrorregiaoMesoUFSigla_Visible), 5, 0), true);
         edtMicrorregiaoMesoUFNome_Visible = 0;
         AssignProp("", false, edtMicrorregiaoMesoUFNome_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMicrorregiaoMesoUFNome_Visible), 5, 0), true);
         edtMicrorregiaoMesoUFSiglaNome_Visible = 0;
         AssignProp("", false, edtMicrorregiaoMesoUFSiglaNome_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMicrorregiaoMesoUFSiglaNome_Visible), 5, 0), true);
         edtMicrorregiaoMesoUFRegID_Visible = 0;
         AssignProp("", false, edtMicrorregiaoMesoUFRegID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMicrorregiaoMesoUFRegID_Visible), 5, 0), true);
         edtMicrorregiaoMesoUFRegSigla_Visible = 0;
         AssignProp("", false, edtMicrorregiaoMesoUFRegSigla_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMicrorregiaoMesoUFRegSigla_Visible), 5, 0), true);
         edtMicrorregiaoMesoUFRegNome_Visible = 0;
         AssignProp("", false, edtMicrorregiaoMesoUFRegNome_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMicrorregiaoMesoUFRegNome_Visible), 5, 0), true);
         edtMicrorregiaoMesoUFRegSiglaNome_Visible = 0;
         AssignProp("", false, edtMicrorregiaoMesoUFRegSiglaNome_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMicrorregiaoMesoUFRegSiglaNome_Visible), 5, 0), true);
      }

      protected void E12042( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("core.microrregiaoww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void S112( )
      {
         /* 'LOADCOMBOMICRORREGIAOMESOID' Routine */
         returnInSub = false;
         GXt_char2 = AV19Combo_DataJson;
         new GeneXus.Programs.core.microrregiaoloaddvcombo(context ).execute(  "MicrorregiaoMesoID",  Gx_mode,  false,  AV7MicrorregiaoID,  "", out  AV17ComboSelectedValue, out  AV18ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV17ComboSelectedValue", AV17ComboSelectedValue);
         AssignAttri("", false, "AV18ComboSelectedText", AV18ComboSelectedText);
         AV19Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV19Combo_DataJson", AV19Combo_DataJson);
         Combo_microrregiaomesoid_Selectedvalue_set = AV17ComboSelectedValue;
         ucCombo_microrregiaomesoid.SendProperty(context, "", false, Combo_microrregiaomesoid_Internalname, "SelectedValue_set", Combo_microrregiaomesoid_Selectedvalue_set);
         Combo_microrregiaomesoid_Selectedtext_set = AV18ComboSelectedText;
         ucCombo_microrregiaomesoid.SendProperty(context, "", false, Combo_microrregiaomesoid_Internalname, "SelectedText_set", Combo_microrregiaomesoid_Selectedtext_set);
         AV20ComboMicrorregiaoMesoID = (int)(Math.Round(NumberUtil.Val( AV17ComboSelectedValue, "."), 18, MidpointRounding.ToEven));
         AssignAttri("", false, "AV20ComboMicrorregiaoMesoID", StringUtil.LTrimStr( (decimal)(AV20ComboMicrorregiaoMesoID), 9, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_microrregiaomesoid_Enabled = false;
            ucCombo_microrregiaomesoid.SendProperty(context, "", false, Combo_microrregiaomesoid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_microrregiaomesoid_Enabled));
         }
      }

      protected void ZM044( short GX_JID )
      {
         if ( ( GX_JID == 11 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z30MicrorregiaoMesoUFSiglaNome = T00043_A30MicrorregiaoMesoUFSiglaNome[0];
               Z34MicrorregiaoMesoUFRegSiglaNome = T00043_A34MicrorregiaoMesoUFRegSiglaNome[0];
               Z24MicrorregiaoNome = T00043_A24MicrorregiaoNome[0];
               Z25MicrorregiaoMesoID = T00043_A25MicrorregiaoMesoID[0];
            }
            else
            {
               Z30MicrorregiaoMesoUFSiglaNome = A30MicrorregiaoMesoUFSiglaNome;
               Z34MicrorregiaoMesoUFRegSiglaNome = A34MicrorregiaoMesoUFRegSiglaNome;
               Z24MicrorregiaoNome = A24MicrorregiaoNome;
               Z25MicrorregiaoMesoID = A25MicrorregiaoMesoID;
            }
         }
         if ( GX_JID == -11 )
         {
            Z30MicrorregiaoMesoUFSiglaNome = A30MicrorregiaoMesoUFSiglaNome;
            Z34MicrorregiaoMesoUFRegSiglaNome = A34MicrorregiaoMesoUFRegSiglaNome;
            Z23MicrorregiaoID = A23MicrorregiaoID;
            Z24MicrorregiaoNome = A24MicrorregiaoNome;
            Z26MicrorregiaoMesoNome = A26MicrorregiaoMesoNome;
            Z27MicrorregiaoMesoUFID = A27MicrorregiaoMesoUFID;
            Z28MicrorregiaoMesoUFSigla = A28MicrorregiaoMesoUFSigla;
            Z29MicrorregiaoMesoUFNome = A29MicrorregiaoMesoUFNome;
            Z31MicrorregiaoMesoUFRegID = A31MicrorregiaoMesoUFRegID;
            Z32MicrorregiaoMesoUFRegSigla = A32MicrorregiaoMesoUFRegSigla;
            Z33MicrorregiaoMesoUFRegNome = A33MicrorregiaoMesoUFRegNome;
            Z25MicrorregiaoMesoID = A25MicrorregiaoMesoID;
         }
      }

      protected void standaloneNotModal( )
      {
         AV25Pgmname = "core.microrregiao";
         AssignAttri("", false, "AV25Pgmname", AV25Pgmname);
         if ( ! (0==AV7MicrorregiaoID) )
         {
            A23MicrorregiaoID = AV7MicrorregiaoID;
            AssignAttri("", false, "A23MicrorregiaoID", StringUtil.LTrimStr( (decimal)(A23MicrorregiaoID), 9, 0));
         }
         if ( ! (0==AV7MicrorregiaoID) )
         {
            edtMicrorregiaoID_Enabled = 0;
            AssignProp("", false, edtMicrorregiaoID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMicrorregiaoID_Enabled), 5, 0), true);
         }
         else
         {
            edtMicrorregiaoID_Enabled = 1;
            AssignProp("", false, edtMicrorregiaoID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMicrorregiaoID_Enabled), 5, 0), true);
         }
         if ( ! (0==AV7MicrorregiaoID) )
         {
            edtMicrorregiaoID_Enabled = 0;
            AssignProp("", false, edtMicrorregiaoID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMicrorregiaoID_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_MicrorregiaoMesoID) )
         {
            edtMicrorregiaoMesoID_Enabled = 0;
            AssignProp("", false, edtMicrorregiaoMesoID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMicrorregiaoMesoID_Enabled), 5, 0), true);
         }
         else
         {
            edtMicrorregiaoMesoID_Enabled = 1;
            AssignProp("", false, edtMicrorregiaoMesoID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMicrorregiaoMesoID_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_MicrorregiaoMesoID) )
         {
            A25MicrorregiaoMesoID = AV13Insert_MicrorregiaoMesoID;
            AssignAttri("", false, "A25MicrorregiaoMesoID", StringUtil.LTrimStr( (decimal)(A25MicrorregiaoMesoID), 9, 0));
         }
         else
         {
            A25MicrorregiaoMesoID = AV20ComboMicrorregiaoMesoID;
            AssignAttri("", false, "A25MicrorregiaoMesoID", StringUtil.LTrimStr( (decimal)(A25MicrorregiaoMesoID), 9, 0));
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
            /* Using cursor T00044 */
            pr_default.execute(2, new Object[] {A25MicrorregiaoMesoID});
            A26MicrorregiaoMesoNome = T00044_A26MicrorregiaoMesoNome[0];
            A27MicrorregiaoMesoUFID = T00044_A27MicrorregiaoMesoUFID[0];
            AssignAttri("", false, "A27MicrorregiaoMesoUFID", StringUtil.LTrimStr( (decimal)(A27MicrorregiaoMesoUFID), 9, 0));
            pr_default.close(2);
            /* Using cursor T00045 */
            pr_default.execute(3, new Object[] {A27MicrorregiaoMesoUFID});
            A28MicrorregiaoMesoUFSigla = T00045_A28MicrorregiaoMesoUFSigla[0];
            n28MicrorregiaoMesoUFSigla = T00045_n28MicrorregiaoMesoUFSigla[0];
            AssignAttri("", false, "A28MicrorregiaoMesoUFSigla", A28MicrorregiaoMesoUFSigla);
            A29MicrorregiaoMesoUFNome = T00045_A29MicrorregiaoMesoUFNome[0];
            n29MicrorregiaoMesoUFNome = T00045_n29MicrorregiaoMesoUFNome[0];
            AssignAttri("", false, "A29MicrorregiaoMesoUFNome", A29MicrorregiaoMesoUFNome);
            A31MicrorregiaoMesoUFRegID = T00045_A31MicrorregiaoMesoUFRegID[0];
            n31MicrorregiaoMesoUFRegID = T00045_n31MicrorregiaoMesoUFRegID[0];
            AssignAttri("", false, "A31MicrorregiaoMesoUFRegID", StringUtil.LTrimStr( (decimal)(A31MicrorregiaoMesoUFRegID), 9, 0));
            pr_default.close(3);
            A30MicrorregiaoMesoUFSiglaNome = StringUtil.Trim( A28MicrorregiaoMesoUFSigla) + " - " + StringUtil.Trim( A29MicrorregiaoMesoUFNome);
            n30MicrorregiaoMesoUFSiglaNome = false;
            AssignAttri("", false, "A30MicrorregiaoMesoUFSiglaNome", A30MicrorregiaoMesoUFSiglaNome);
            /* Using cursor T00046 */
            pr_default.execute(4, new Object[] {n31MicrorregiaoMesoUFRegID, A31MicrorregiaoMesoUFRegID});
            A32MicrorregiaoMesoUFRegSigla = T00046_A32MicrorregiaoMesoUFRegSigla[0];
            n32MicrorregiaoMesoUFRegSigla = T00046_n32MicrorregiaoMesoUFRegSigla[0];
            AssignAttri("", false, "A32MicrorregiaoMesoUFRegSigla", A32MicrorregiaoMesoUFRegSigla);
            A33MicrorregiaoMesoUFRegNome = T00046_A33MicrorregiaoMesoUFRegNome[0];
            n33MicrorregiaoMesoUFRegNome = T00046_n33MicrorregiaoMesoUFRegNome[0];
            AssignAttri("", false, "A33MicrorregiaoMesoUFRegNome", A33MicrorregiaoMesoUFRegNome);
            pr_default.close(4);
            A34MicrorregiaoMesoUFRegSiglaNome = StringUtil.Trim( A32MicrorregiaoMesoUFRegSigla) + " - " + StringUtil.Trim( A33MicrorregiaoMesoUFRegNome);
            n34MicrorregiaoMesoUFRegSiglaNome = false;
            AssignAttri("", false, "A34MicrorregiaoMesoUFRegSiglaNome", A34MicrorregiaoMesoUFRegSiglaNome);
         }
      }

      protected void Load044( )
      {
         /* Using cursor T00047 */
         pr_default.execute(5, new Object[] {A23MicrorregiaoID});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound4 = 1;
            A30MicrorregiaoMesoUFSiglaNome = T00047_A30MicrorregiaoMesoUFSiglaNome[0];
            n30MicrorregiaoMesoUFSiglaNome = T00047_n30MicrorregiaoMesoUFSiglaNome[0];
            AssignAttri("", false, "A30MicrorregiaoMesoUFSiglaNome", A30MicrorregiaoMesoUFSiglaNome);
            A34MicrorregiaoMesoUFRegSiglaNome = T00047_A34MicrorregiaoMesoUFRegSiglaNome[0];
            n34MicrorregiaoMesoUFRegSiglaNome = T00047_n34MicrorregiaoMesoUFRegSiglaNome[0];
            AssignAttri("", false, "A34MicrorregiaoMesoUFRegSiglaNome", A34MicrorregiaoMesoUFRegSiglaNome);
            A24MicrorregiaoNome = T00047_A24MicrorregiaoNome[0];
            AssignAttri("", false, "A24MicrorregiaoNome", A24MicrorregiaoNome);
            A26MicrorregiaoMesoNome = T00047_A26MicrorregiaoMesoNome[0];
            A27MicrorregiaoMesoUFID = T00047_A27MicrorregiaoMesoUFID[0];
            AssignAttri("", false, "A27MicrorregiaoMesoUFID", StringUtil.LTrimStr( (decimal)(A27MicrorregiaoMesoUFID), 9, 0));
            A28MicrorregiaoMesoUFSigla = T00047_A28MicrorregiaoMesoUFSigla[0];
            n28MicrorregiaoMesoUFSigla = T00047_n28MicrorregiaoMesoUFSigla[0];
            AssignAttri("", false, "A28MicrorregiaoMesoUFSigla", A28MicrorregiaoMesoUFSigla);
            A29MicrorregiaoMesoUFNome = T00047_A29MicrorregiaoMesoUFNome[0];
            n29MicrorregiaoMesoUFNome = T00047_n29MicrorregiaoMesoUFNome[0];
            AssignAttri("", false, "A29MicrorregiaoMesoUFNome", A29MicrorregiaoMesoUFNome);
            A31MicrorregiaoMesoUFRegID = T00047_A31MicrorregiaoMesoUFRegID[0];
            n31MicrorregiaoMesoUFRegID = T00047_n31MicrorregiaoMesoUFRegID[0];
            AssignAttri("", false, "A31MicrorregiaoMesoUFRegID", StringUtil.LTrimStr( (decimal)(A31MicrorregiaoMesoUFRegID), 9, 0));
            A32MicrorregiaoMesoUFRegSigla = T00047_A32MicrorregiaoMesoUFRegSigla[0];
            n32MicrorregiaoMesoUFRegSigla = T00047_n32MicrorregiaoMesoUFRegSigla[0];
            AssignAttri("", false, "A32MicrorregiaoMesoUFRegSigla", A32MicrorregiaoMesoUFRegSigla);
            A33MicrorregiaoMesoUFRegNome = T00047_A33MicrorregiaoMesoUFRegNome[0];
            n33MicrorregiaoMesoUFRegNome = T00047_n33MicrorregiaoMesoUFRegNome[0];
            AssignAttri("", false, "A33MicrorregiaoMesoUFRegNome", A33MicrorregiaoMesoUFRegNome);
            A25MicrorregiaoMesoID = T00047_A25MicrorregiaoMesoID[0];
            AssignAttri("", false, "A25MicrorregiaoMesoID", StringUtil.LTrimStr( (decimal)(A25MicrorregiaoMesoID), 9, 0));
            ZM044( -11) ;
         }
         pr_default.close(5);
         OnLoadActions044( ) ;
      }

      protected void OnLoadActions044( )
      {
         A30MicrorregiaoMesoUFSiglaNome = StringUtil.Trim( A28MicrorregiaoMesoUFSigla) + " - " + StringUtil.Trim( A29MicrorregiaoMesoUFNome);
         n30MicrorregiaoMesoUFSiglaNome = false;
         AssignAttri("", false, "A30MicrorregiaoMesoUFSiglaNome", A30MicrorregiaoMesoUFSiglaNome);
         /* Using cursor T00046 */
         pr_default.execute(4, new Object[] {n31MicrorregiaoMesoUFRegID, A31MicrorregiaoMesoUFRegID});
         A32MicrorregiaoMesoUFRegSigla = T00046_A32MicrorregiaoMesoUFRegSigla[0];
         n32MicrorregiaoMesoUFRegSigla = T00046_n32MicrorregiaoMesoUFRegSigla[0];
         AssignAttri("", false, "A32MicrorregiaoMesoUFRegSigla", A32MicrorregiaoMesoUFRegSigla);
         A33MicrorregiaoMesoUFRegNome = T00046_A33MicrorregiaoMesoUFRegNome[0];
         n33MicrorregiaoMesoUFRegNome = T00046_n33MicrorregiaoMesoUFRegNome[0];
         AssignAttri("", false, "A33MicrorregiaoMesoUFRegNome", A33MicrorregiaoMesoUFRegNome);
         pr_default.close(4);
         A34MicrorregiaoMesoUFRegSiglaNome = StringUtil.Trim( A32MicrorregiaoMesoUFRegSigla) + " - " + StringUtil.Trim( A33MicrorregiaoMesoUFRegNome);
         n34MicrorregiaoMesoUFRegSiglaNome = false;
         AssignAttri("", false, "A34MicrorregiaoMesoUFRegSiglaNome", A34MicrorregiaoMesoUFRegSiglaNome);
      }

      protected void CheckExtendedTable044( )
      {
         nIsDirty_4 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T00044 */
         pr_default.execute(2, new Object[] {A25MicrorregiaoMesoID});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("Não existe 'Group Mesoregião -> Microregião'.", "ForeignKeyNotFound", 1, "MICRORREGIAOMESOID");
            AnyError = 1;
            GX_FocusControl = edtMicrorregiaoMesoID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A26MicrorregiaoMesoNome = T00044_A26MicrorregiaoMesoNome[0];
         A27MicrorregiaoMesoUFID = T00044_A27MicrorregiaoMesoUFID[0];
         AssignAttri("", false, "A27MicrorregiaoMesoUFID", StringUtil.LTrimStr( (decimal)(A27MicrorregiaoMesoUFID), 9, 0));
         pr_default.close(2);
         /* Using cursor T00045 */
         pr_default.execute(3, new Object[] {A27MicrorregiaoMesoUFID});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("Não existe 'Unidade Federativa (Estado)'.", "ForeignKeyNotFound", 1, "MICRORREGIAOMESOUFID");
            AnyError = 1;
         }
         A28MicrorregiaoMesoUFSigla = T00045_A28MicrorregiaoMesoUFSigla[0];
         n28MicrorregiaoMesoUFSigla = T00045_n28MicrorregiaoMesoUFSigla[0];
         AssignAttri("", false, "A28MicrorregiaoMesoUFSigla", A28MicrorregiaoMesoUFSigla);
         A29MicrorregiaoMesoUFNome = T00045_A29MicrorregiaoMesoUFNome[0];
         n29MicrorregiaoMesoUFNome = T00045_n29MicrorregiaoMesoUFNome[0];
         AssignAttri("", false, "A29MicrorregiaoMesoUFNome", A29MicrorregiaoMesoUFNome);
         A31MicrorregiaoMesoUFRegID = T00045_A31MicrorregiaoMesoUFRegID[0];
         n31MicrorregiaoMesoUFRegID = T00045_n31MicrorregiaoMesoUFRegID[0];
         AssignAttri("", false, "A31MicrorregiaoMesoUFRegID", StringUtil.LTrimStr( (decimal)(A31MicrorregiaoMesoUFRegID), 9, 0));
         pr_default.close(3);
         nIsDirty_4 = 1;
         A30MicrorregiaoMesoUFSiglaNome = StringUtil.Trim( A28MicrorregiaoMesoUFSigla) + " - " + StringUtil.Trim( A29MicrorregiaoMesoUFNome);
         n30MicrorregiaoMesoUFSiglaNome = false;
         AssignAttri("", false, "A30MicrorregiaoMesoUFSiglaNome", A30MicrorregiaoMesoUFSiglaNome);
         /* Using cursor T00046 */
         pr_default.execute(4, new Object[] {n31MicrorregiaoMesoUFRegID, A31MicrorregiaoMesoUFRegID});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("Não existe 'Região'.", "ForeignKeyNotFound", 1, "MICRORREGIAOMESOUFREGID");
            AnyError = 1;
         }
         A32MicrorregiaoMesoUFRegSigla = T00046_A32MicrorregiaoMesoUFRegSigla[0];
         n32MicrorregiaoMesoUFRegSigla = T00046_n32MicrorregiaoMesoUFRegSigla[0];
         AssignAttri("", false, "A32MicrorregiaoMesoUFRegSigla", A32MicrorregiaoMesoUFRegSigla);
         A33MicrorregiaoMesoUFRegNome = T00046_A33MicrorregiaoMesoUFRegNome[0];
         n33MicrorregiaoMesoUFRegNome = T00046_n33MicrorregiaoMesoUFRegNome[0];
         AssignAttri("", false, "A33MicrorregiaoMesoUFRegNome", A33MicrorregiaoMesoUFRegNome);
         pr_default.close(4);
         nIsDirty_4 = 1;
         A34MicrorregiaoMesoUFRegSiglaNome = StringUtil.Trim( A32MicrorregiaoMesoUFRegSigla) + " - " + StringUtil.Trim( A33MicrorregiaoMesoUFRegNome);
         n34MicrorregiaoMesoUFRegSiglaNome = false;
         AssignAttri("", false, "A34MicrorregiaoMesoUFRegSiglaNome", A34MicrorregiaoMesoUFRegSiglaNome);
      }

      protected void CloseExtendedTableCursors044( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_12( int A25MicrorregiaoMesoID )
      {
         /* Using cursor T00048 */
         pr_default.execute(6, new Object[] {A25MicrorregiaoMesoID});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("Não existe 'Group Mesoregião -> Microregião'.", "ForeignKeyNotFound", 1, "MICRORREGIAOMESOID");
            AnyError = 1;
            GX_FocusControl = edtMicrorregiaoMesoID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A26MicrorregiaoMesoNome = T00048_A26MicrorregiaoMesoNome[0];
         A27MicrorregiaoMesoUFID = T00048_A27MicrorregiaoMesoUFID[0];
         AssignAttri("", false, "A27MicrorregiaoMesoUFID", StringUtil.LTrimStr( (decimal)(A27MicrorregiaoMesoUFID), 9, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A26MicrorregiaoMesoNome)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A27MicrorregiaoMesoUFID), 9, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void gxLoad_13( int A27MicrorregiaoMesoUFID )
      {
         /* Using cursor T00049 */
         pr_default.execute(7, new Object[] {A27MicrorregiaoMesoUFID});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem("Não existe 'Unidade Federativa (Estado)'.", "ForeignKeyNotFound", 1, "MICRORREGIAOMESOUFID");
            AnyError = 1;
         }
         A28MicrorregiaoMesoUFSigla = T00049_A28MicrorregiaoMesoUFSigla[0];
         n28MicrorregiaoMesoUFSigla = T00049_n28MicrorregiaoMesoUFSigla[0];
         AssignAttri("", false, "A28MicrorregiaoMesoUFSigla", A28MicrorregiaoMesoUFSigla);
         A29MicrorregiaoMesoUFNome = T00049_A29MicrorregiaoMesoUFNome[0];
         n29MicrorregiaoMesoUFNome = T00049_n29MicrorregiaoMesoUFNome[0];
         AssignAttri("", false, "A29MicrorregiaoMesoUFNome", A29MicrorregiaoMesoUFNome);
         A31MicrorregiaoMesoUFRegID = T00049_A31MicrorregiaoMesoUFRegID[0];
         n31MicrorregiaoMesoUFRegID = T00049_n31MicrorregiaoMesoUFRegID[0];
         AssignAttri("", false, "A31MicrorregiaoMesoUFRegID", StringUtil.LTrimStr( (decimal)(A31MicrorregiaoMesoUFRegID), 9, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A28MicrorregiaoMesoUFSigla)+"\""+","+"\""+GXUtil.EncodeJSConstant( A29MicrorregiaoMesoUFNome)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A31MicrorregiaoMesoUFRegID), 9, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void gxLoad_14( int A31MicrorregiaoMesoUFRegID )
      {
         /* Using cursor T000410 */
         pr_default.execute(8, new Object[] {n31MicrorregiaoMesoUFRegID, A31MicrorregiaoMesoUFRegID});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("Não existe 'Região'.", "ForeignKeyNotFound", 1, "MICRORREGIAOMESOUFREGID");
            AnyError = 1;
         }
         A32MicrorregiaoMesoUFRegSigla = T000410_A32MicrorregiaoMesoUFRegSigla[0];
         n32MicrorregiaoMesoUFRegSigla = T000410_n32MicrorregiaoMesoUFRegSigla[0];
         AssignAttri("", false, "A32MicrorregiaoMesoUFRegSigla", A32MicrorregiaoMesoUFRegSigla);
         A33MicrorregiaoMesoUFRegNome = T000410_A33MicrorregiaoMesoUFRegNome[0];
         n33MicrorregiaoMesoUFRegNome = T000410_n33MicrorregiaoMesoUFRegNome[0];
         AssignAttri("", false, "A33MicrorregiaoMesoUFRegNome", A33MicrorregiaoMesoUFRegNome);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A32MicrorregiaoMesoUFRegSigla)+"\""+","+"\""+GXUtil.EncodeJSConstant( A33MicrorregiaoMesoUFRegNome)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void GetKey044( )
      {
         /* Using cursor T000411 */
         pr_default.execute(9, new Object[] {A23MicrorregiaoID});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound4 = 1;
         }
         else
         {
            RcdFound4 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00043 */
         pr_default.execute(1, new Object[] {A23MicrorregiaoID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM044( 11) ;
            RcdFound4 = 1;
            A23MicrorregiaoID = T00043_A23MicrorregiaoID[0];
            AssignAttri("", false, "A23MicrorregiaoID", StringUtil.LTrimStr( (decimal)(A23MicrorregiaoID), 9, 0));
            A24MicrorregiaoNome = T00043_A24MicrorregiaoNome[0];
            AssignAttri("", false, "A24MicrorregiaoNome", A24MicrorregiaoNome);
            A25MicrorregiaoMesoID = T00043_A25MicrorregiaoMesoID[0];
            AssignAttri("", false, "A25MicrorregiaoMesoID", StringUtil.LTrimStr( (decimal)(A25MicrorregiaoMesoID), 9, 0));
            A30MicrorregiaoMesoUFSiglaNome = T00043_A30MicrorregiaoMesoUFSiglaNome[0];
            n30MicrorregiaoMesoUFSiglaNome = T00043_n30MicrorregiaoMesoUFSiglaNome[0];
            AssignAttri("", false, "A30MicrorregiaoMesoUFSiglaNome", A30MicrorregiaoMesoUFSiglaNome);
            A34MicrorregiaoMesoUFRegSiglaNome = T00043_A34MicrorregiaoMesoUFRegSiglaNome[0];
            n34MicrorregiaoMesoUFRegSiglaNome = T00043_n34MicrorregiaoMesoUFRegSiglaNome[0];
            AssignAttri("", false, "A34MicrorregiaoMesoUFRegSiglaNome", A34MicrorregiaoMesoUFRegSiglaNome);
            Z23MicrorregiaoID = A23MicrorregiaoID;
            sMode4 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load044( ) ;
            if ( AnyError == 1 )
            {
               RcdFound4 = 0;
               InitializeNonKey044( ) ;
            }
            Gx_mode = sMode4;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound4 = 0;
            InitializeNonKey044( ) ;
            sMode4 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode4;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey044( ) ;
         if ( RcdFound4 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound4 = 0;
         /* Using cursor T000412 */
         pr_default.execute(10, new Object[] {A23MicrorregiaoID});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( T000412_A23MicrorregiaoID[0] < A23MicrorregiaoID ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( T000412_A23MicrorregiaoID[0] > A23MicrorregiaoID ) ) )
            {
               A23MicrorregiaoID = T000412_A23MicrorregiaoID[0];
               AssignAttri("", false, "A23MicrorregiaoID", StringUtil.LTrimStr( (decimal)(A23MicrorregiaoID), 9, 0));
               RcdFound4 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void move_previous( )
      {
         RcdFound4 = 0;
         /* Using cursor T000413 */
         pr_default.execute(11, new Object[] {A23MicrorregiaoID});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( T000413_A23MicrorregiaoID[0] > A23MicrorregiaoID ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( T000413_A23MicrorregiaoID[0] < A23MicrorregiaoID ) ) )
            {
               A23MicrorregiaoID = T000413_A23MicrorregiaoID[0];
               AssignAttri("", false, "A23MicrorregiaoID", StringUtil.LTrimStr( (decimal)(A23MicrorregiaoID), 9, 0));
               RcdFound4 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey044( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtMicrorregiaoID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert044( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound4 == 1 )
            {
               if ( A23MicrorregiaoID != Z23MicrorregiaoID )
               {
                  A23MicrorregiaoID = Z23MicrorregiaoID;
                  AssignAttri("", false, "A23MicrorregiaoID", StringUtil.LTrimStr( (decimal)(A23MicrorregiaoID), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "MICRORREGIAOID");
                  AnyError = 1;
                  GX_FocusControl = edtMicrorregiaoID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtMicrorregiaoID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update044( ) ;
                  GX_FocusControl = edtMicrorregiaoID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A23MicrorregiaoID != Z23MicrorregiaoID )
               {
                  /* Insert record */
                  GX_FocusControl = edtMicrorregiaoID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert044( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "MICRORREGIAOID");
                     AnyError = 1;
                     GX_FocusControl = edtMicrorregiaoID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtMicrorregiaoID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert044( ) ;
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
         if ( A23MicrorregiaoID != Z23MicrorregiaoID )
         {
            A23MicrorregiaoID = Z23MicrorregiaoID;
            AssignAttri("", false, "A23MicrorregiaoID", StringUtil.LTrimStr( (decimal)(A23MicrorregiaoID), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "MICRORREGIAOID");
            AnyError = 1;
            GX_FocusControl = edtMicrorregiaoID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtMicrorregiaoID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency044( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00042 */
            pr_default.execute(0, new Object[] {A23MicrorregiaoID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tbibge_microrregiao"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z30MicrorregiaoMesoUFSiglaNome, T00042_A30MicrorregiaoMesoUFSiglaNome[0]) != 0 ) || ( StringUtil.StrCmp(Z34MicrorregiaoMesoUFRegSiglaNome, T00042_A34MicrorregiaoMesoUFRegSiglaNome[0]) != 0 ) || ( StringUtil.StrCmp(Z24MicrorregiaoNome, T00042_A24MicrorregiaoNome[0]) != 0 ) || ( Z25MicrorregiaoMesoID != T00042_A25MicrorregiaoMesoID[0] ) )
            {
               if ( StringUtil.StrCmp(Z30MicrorregiaoMesoUFSiglaNome, T00042_A30MicrorregiaoMesoUFSiglaNome[0]) != 0 )
               {
                  GXUtil.WriteLog("core.microrregiao:[seudo value changed for attri]"+"MicrorregiaoMesoUFSiglaNome");
                  GXUtil.WriteLogRaw("Old: ",Z30MicrorregiaoMesoUFSiglaNome);
                  GXUtil.WriteLogRaw("Current: ",T00042_A30MicrorregiaoMesoUFSiglaNome[0]);
               }
               if ( StringUtil.StrCmp(Z34MicrorregiaoMesoUFRegSiglaNome, T00042_A34MicrorregiaoMesoUFRegSiglaNome[0]) != 0 )
               {
                  GXUtil.WriteLog("core.microrregiao:[seudo value changed for attri]"+"MicrorregiaoMesoUFRegSiglaNome");
                  GXUtil.WriteLogRaw("Old: ",Z34MicrorregiaoMesoUFRegSiglaNome);
                  GXUtil.WriteLogRaw("Current: ",T00042_A34MicrorregiaoMesoUFRegSiglaNome[0]);
               }
               if ( StringUtil.StrCmp(Z24MicrorregiaoNome, T00042_A24MicrorregiaoNome[0]) != 0 )
               {
                  GXUtil.WriteLog("core.microrregiao:[seudo value changed for attri]"+"MicrorregiaoNome");
                  GXUtil.WriteLogRaw("Old: ",Z24MicrorregiaoNome);
                  GXUtil.WriteLogRaw("Current: ",T00042_A24MicrorregiaoNome[0]);
               }
               if ( Z25MicrorregiaoMesoID != T00042_A25MicrorregiaoMesoID[0] )
               {
                  GXUtil.WriteLog("core.microrregiao:[seudo value changed for attri]"+"MicrorregiaoMesoID");
                  GXUtil.WriteLogRaw("Old: ",Z25MicrorregiaoMesoID);
                  GXUtil.WriteLogRaw("Current: ",T00042_A25MicrorregiaoMesoID[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"tbibge_microrregiao"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert044( )
      {
         if ( ! IsAuthorized("microrregiao_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate044( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable044( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM044( 0) ;
            CheckOptimisticConcurrency044( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm044( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert044( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000414 */
                     pr_default.execute(12, new Object[] {A26MicrorregiaoMesoNome, A27MicrorregiaoMesoUFID, n28MicrorregiaoMesoUFSigla, A28MicrorregiaoMesoUFSigla, n29MicrorregiaoMesoUFNome, A29MicrorregiaoMesoUFNome, n31MicrorregiaoMesoUFRegID, A31MicrorregiaoMesoUFRegID, n32MicrorregiaoMesoUFRegSigla, A32MicrorregiaoMesoUFRegSigla, n33MicrorregiaoMesoUFRegNome, A33MicrorregiaoMesoUFRegNome, n30MicrorregiaoMesoUFSiglaNome, A30MicrorregiaoMesoUFSiglaNome, n34MicrorregiaoMesoUFRegSiglaNome, A34MicrorregiaoMesoUFRegSiglaNome, A23MicrorregiaoID, A24MicrorregiaoNome, A25MicrorregiaoMesoID});
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("tbibge_microrregiao");
                     if ( (pr_default.getStatus(12) == 1) )
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
                           ResetCaption040( ) ;
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
               Load044( ) ;
            }
            EndLevel044( ) ;
         }
         CloseExtendedTableCursors044( ) ;
      }

      protected void Update044( )
      {
         if ( ! IsAuthorized("microrregiao_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate044( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable044( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency044( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm044( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate044( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000415 */
                     pr_default.execute(13, new Object[] {A26MicrorregiaoMesoNome, A27MicrorregiaoMesoUFID, n28MicrorregiaoMesoUFSigla, A28MicrorregiaoMesoUFSigla, n29MicrorregiaoMesoUFNome, A29MicrorregiaoMesoUFNome, n31MicrorregiaoMesoUFRegID, A31MicrorregiaoMesoUFRegID, n32MicrorregiaoMesoUFRegSigla, A32MicrorregiaoMesoUFRegSigla, n33MicrorregiaoMesoUFRegNome, A33MicrorregiaoMesoUFRegNome, n30MicrorregiaoMesoUFSiglaNome, A30MicrorregiaoMesoUFSiglaNome, n34MicrorregiaoMesoUFRegSiglaNome, A34MicrorregiaoMesoUFRegSiglaNome, A24MicrorregiaoNome, A25MicrorregiaoMesoID, A23MicrorregiaoID});
                     pr_default.close(13);
                     pr_default.SmartCacheProvider.SetUpdated("tbibge_microrregiao");
                     if ( (pr_default.getStatus(13) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tbibge_microrregiao"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate044( ) ;
                     if ( AnyError == 0 )
                     {
                        /* API remote call */
                        new tbibge_microrregiaoupdateredundancy(context ).execute( ref  A23MicrorregiaoID) ;
                        AssignAttri("", false, "A23MicrorregiaoID", StringUtil.LTrimStr( (decimal)(A23MicrorregiaoID), 9, 0));
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
            EndLevel044( ) ;
         }
         CloseExtendedTableCursors044( ) ;
      }

      protected void DeferredUpdate044( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("microrregiao_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate044( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency044( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls044( ) ;
            AfterConfirm044( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete044( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000416 */
                  pr_default.execute(14, new Object[] {A23MicrorregiaoID});
                  pr_default.close(14);
                  pr_default.SmartCacheProvider.SetUpdated("tbibge_microrregiao");
                  if ( AnyError == 0 )
                  {
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
         sMode4 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel044( ) ;
         Gx_mode = sMode4;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls044( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000417 */
            pr_default.execute(15, new Object[] {A25MicrorregiaoMesoID});
            A26MicrorregiaoMesoNome = T000417_A26MicrorregiaoMesoNome[0];
            A27MicrorregiaoMesoUFID = T000417_A27MicrorregiaoMesoUFID[0];
            AssignAttri("", false, "A27MicrorregiaoMesoUFID", StringUtil.LTrimStr( (decimal)(A27MicrorregiaoMesoUFID), 9, 0));
            pr_default.close(15);
            /* Using cursor T000418 */
            pr_default.execute(16, new Object[] {A27MicrorregiaoMesoUFID});
            A28MicrorregiaoMesoUFSigla = T000418_A28MicrorregiaoMesoUFSigla[0];
            n28MicrorregiaoMesoUFSigla = T000418_n28MicrorregiaoMesoUFSigla[0];
            AssignAttri("", false, "A28MicrorregiaoMesoUFSigla", A28MicrorregiaoMesoUFSigla);
            A29MicrorregiaoMesoUFNome = T000418_A29MicrorregiaoMesoUFNome[0];
            n29MicrorregiaoMesoUFNome = T000418_n29MicrorregiaoMesoUFNome[0];
            AssignAttri("", false, "A29MicrorregiaoMesoUFNome", A29MicrorregiaoMesoUFNome);
            A31MicrorregiaoMesoUFRegID = T000418_A31MicrorregiaoMesoUFRegID[0];
            n31MicrorregiaoMesoUFRegID = T000418_n31MicrorregiaoMesoUFRegID[0];
            AssignAttri("", false, "A31MicrorregiaoMesoUFRegID", StringUtil.LTrimStr( (decimal)(A31MicrorregiaoMesoUFRegID), 9, 0));
            pr_default.close(16);
            /* Using cursor T000419 */
            pr_default.execute(17, new Object[] {n31MicrorregiaoMesoUFRegID, A31MicrorregiaoMesoUFRegID});
            A32MicrorregiaoMesoUFRegSigla = T000419_A32MicrorregiaoMesoUFRegSigla[0];
            n32MicrorregiaoMesoUFRegSigla = T000419_n32MicrorregiaoMesoUFRegSigla[0];
            AssignAttri("", false, "A32MicrorregiaoMesoUFRegSigla", A32MicrorregiaoMesoUFRegSigla);
            A33MicrorregiaoMesoUFRegNome = T000419_A33MicrorregiaoMesoUFRegNome[0];
            n33MicrorregiaoMesoUFRegNome = T000419_n33MicrorregiaoMesoUFRegNome[0];
            AssignAttri("", false, "A33MicrorregiaoMesoUFRegNome", A33MicrorregiaoMesoUFRegNome);
            pr_default.close(17);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000420 */
            pr_default.execute(18, new Object[] {A23MicrorregiaoID});
            if ( (pr_default.getStatus(18) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Município"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(18);
         }
      }

      protected void EndLevel044( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete044( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("core.microrregiao",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues040( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("core.microrregiao",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart044( )
      {
         /* Scan By routine */
         /* Using cursor T000421 */
         pr_default.execute(19);
         RcdFound4 = 0;
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound4 = 1;
            A23MicrorregiaoID = T000421_A23MicrorregiaoID[0];
            AssignAttri("", false, "A23MicrorregiaoID", StringUtil.LTrimStr( (decimal)(A23MicrorregiaoID), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext044( )
      {
         /* Scan next routine */
         pr_default.readNext(19);
         RcdFound4 = 0;
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound4 = 1;
            A23MicrorregiaoID = T000421_A23MicrorregiaoID[0];
            AssignAttri("", false, "A23MicrorregiaoID", StringUtil.LTrimStr( (decimal)(A23MicrorregiaoID), 9, 0));
         }
      }

      protected void ScanEnd044( )
      {
         pr_default.close(19);
      }

      protected void AfterConfirm044( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert044( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate044( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete044( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete044( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate044( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes044( )
      {
         edtMicrorregiaoID_Enabled = 0;
         AssignProp("", false, edtMicrorregiaoID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMicrorregiaoID_Enabled), 5, 0), true);
         edtMicrorregiaoNome_Enabled = 0;
         AssignProp("", false, edtMicrorregiaoNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMicrorregiaoNome_Enabled), 5, 0), true);
         edtMicrorregiaoMesoID_Enabled = 0;
         AssignProp("", false, edtMicrorregiaoMesoID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMicrorregiaoMesoID_Enabled), 5, 0), true);
         edtavCombomicrorregiaomesoid_Enabled = 0;
         AssignProp("", false, edtavCombomicrorregiaomesoid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombomicrorregiaomesoid_Enabled), 5, 0), true);
         edtMicrorregiaoMesoUFID_Enabled = 0;
         AssignProp("", false, edtMicrorregiaoMesoUFID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMicrorregiaoMesoUFID_Enabled), 5, 0), true);
         edtMicrorregiaoMesoUFSigla_Enabled = 0;
         AssignProp("", false, edtMicrorregiaoMesoUFSigla_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMicrorregiaoMesoUFSigla_Enabled), 5, 0), true);
         edtMicrorregiaoMesoUFNome_Enabled = 0;
         AssignProp("", false, edtMicrorregiaoMesoUFNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMicrorregiaoMesoUFNome_Enabled), 5, 0), true);
         edtMicrorregiaoMesoUFSiglaNome_Enabled = 0;
         AssignProp("", false, edtMicrorregiaoMesoUFSiglaNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMicrorregiaoMesoUFSiglaNome_Enabled), 5, 0), true);
         edtMicrorregiaoMesoUFRegID_Enabled = 0;
         AssignProp("", false, edtMicrorregiaoMesoUFRegID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMicrorregiaoMesoUFRegID_Enabled), 5, 0), true);
         edtMicrorregiaoMesoUFRegSigla_Enabled = 0;
         AssignProp("", false, edtMicrorregiaoMesoUFRegSigla_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMicrorregiaoMesoUFRegSigla_Enabled), 5, 0), true);
         edtMicrorregiaoMesoUFRegNome_Enabled = 0;
         AssignProp("", false, edtMicrorregiaoMesoUFRegNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMicrorregiaoMesoUFRegNome_Enabled), 5, 0), true);
         edtMicrorregiaoMesoUFRegSiglaNome_Enabled = 0;
         AssignProp("", false, edtMicrorregiaoMesoUFRegSiglaNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMicrorregiaoMesoUFRegSiglaNome_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes044( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues040( )
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
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
         GXEncryptionTmp = "core.microrregiao.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7MicrorregiaoID,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("core.microrregiao.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"microrregiao");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("core\\microrregiao:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z23MicrorregiaoID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z23MicrorregiaoID), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z30MicrorregiaoMesoUFSiglaNome", Z30MicrorregiaoMesoUFSiglaNome);
         GxWebStd.gx_hidden_field( context, "Z34MicrorregiaoMesoUFRegSiglaNome", Z34MicrorregiaoMesoUFRegSiglaNome);
         GxWebStd.gx_hidden_field( context, "Z24MicrorregiaoNome", Z24MicrorregiaoNome);
         GxWebStd.gx_hidden_field( context, "Z25MicrorregiaoMesoID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z25MicrorregiaoMesoID), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N25MicrorregiaoMesoID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A25MicrorregiaoMesoID), 9, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV16DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV16DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMICRORREGIAOMESOID_DATA", AV15MicrorregiaoMesoID_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMICRORREGIAOMESOID_DATA", AV15MicrorregiaoMesoID_Data);
         }
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV11TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV11TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV11TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vMICRORREGIAOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7MicrorregiaoID), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vMICRORREGIAOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7MicrorregiaoID), "ZZZ,ZZZ,ZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_MICRORREGIAOMESOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13Insert_MicrorregiaoMesoID), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "MICRORREGIAOMESONOME", A26MicrorregiaoMesoNome);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV25Pgmname));
         GxWebStd.gx_hidden_field( context, "COMBO_MICRORREGIAOMESOID_Objectcall", StringUtil.RTrim( Combo_microrregiaomesoid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_MICRORREGIAOMESOID_Cls", StringUtil.RTrim( Combo_microrregiaomesoid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_MICRORREGIAOMESOID_Selectedvalue_set", StringUtil.RTrim( Combo_microrregiaomesoid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_MICRORREGIAOMESOID_Selectedtext_set", StringUtil.RTrim( Combo_microrregiaomesoid_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_MICRORREGIAOMESOID_Gamoauthtoken", StringUtil.RTrim( Combo_microrregiaomesoid_Gamoauthtoken));
         GxWebStd.gx_hidden_field( context, "COMBO_MICRORREGIAOMESOID_Enabled", StringUtil.BoolToStr( Combo_microrregiaomesoid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_MICRORREGIAOMESOID_Datalistproc", StringUtil.RTrim( Combo_microrregiaomesoid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_MICRORREGIAOMESOID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_microrregiaomesoid_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_MICRORREGIAOMESOID_Emptyitem", StringUtil.BoolToStr( Combo_microrregiaomesoid_Emptyitem));
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
         GXEncryptionTmp = "core.microrregiao.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7MicrorregiaoID,9,0));
         return formatLink("core.microrregiao.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "core.microrregiao" ;
      }

      public override string GetPgmdesc( )
      {
         return "Microrregião" ;
      }

      protected void InitializeNonKey044( )
      {
         A25MicrorregiaoMesoID = 0;
         AssignAttri("", false, "A25MicrorregiaoMesoID", StringUtil.LTrimStr( (decimal)(A25MicrorregiaoMesoID), 9, 0));
         A24MicrorregiaoNome = "";
         AssignAttri("", false, "A24MicrorregiaoNome", A24MicrorregiaoNome);
         A26MicrorregiaoMesoNome = "";
         AssignAttri("", false, "A26MicrorregiaoMesoNome", A26MicrorregiaoMesoNome);
         A27MicrorregiaoMesoUFID = 0;
         AssignAttri("", false, "A27MicrorregiaoMesoUFID", StringUtil.LTrimStr( (decimal)(A27MicrorregiaoMesoUFID), 9, 0));
         A28MicrorregiaoMesoUFSigla = "";
         n28MicrorregiaoMesoUFSigla = false;
         AssignAttri("", false, "A28MicrorregiaoMesoUFSigla", A28MicrorregiaoMesoUFSigla);
         A29MicrorregiaoMesoUFNome = "";
         n29MicrorregiaoMesoUFNome = false;
         AssignAttri("", false, "A29MicrorregiaoMesoUFNome", A29MicrorregiaoMesoUFNome);
         A30MicrorregiaoMesoUFSiglaNome = "";
         n30MicrorregiaoMesoUFSiglaNome = false;
         AssignAttri("", false, "A30MicrorregiaoMesoUFSiglaNome", A30MicrorregiaoMesoUFSiglaNome);
         n30MicrorregiaoMesoUFSiglaNome = (String.IsNullOrEmpty(StringUtil.RTrim( A30MicrorregiaoMesoUFSiglaNome)) ? true : false);
         A31MicrorregiaoMesoUFRegID = 0;
         n31MicrorregiaoMesoUFRegID = false;
         AssignAttri("", false, "A31MicrorregiaoMesoUFRegID", StringUtil.LTrimStr( (decimal)(A31MicrorregiaoMesoUFRegID), 9, 0));
         A32MicrorregiaoMesoUFRegSigla = "";
         n32MicrorregiaoMesoUFRegSigla = false;
         AssignAttri("", false, "A32MicrorregiaoMesoUFRegSigla", A32MicrorregiaoMesoUFRegSigla);
         A33MicrorregiaoMesoUFRegNome = "";
         n33MicrorregiaoMesoUFRegNome = false;
         AssignAttri("", false, "A33MicrorregiaoMesoUFRegNome", A33MicrorregiaoMesoUFRegNome);
         A34MicrorregiaoMesoUFRegSiglaNome = "";
         n34MicrorregiaoMesoUFRegSiglaNome = false;
         AssignAttri("", false, "A34MicrorregiaoMesoUFRegSiglaNome", A34MicrorregiaoMesoUFRegSiglaNome);
         n34MicrorregiaoMesoUFRegSiglaNome = (String.IsNullOrEmpty(StringUtil.RTrim( A34MicrorregiaoMesoUFRegSiglaNome)) ? true : false);
         Z30MicrorregiaoMesoUFSiglaNome = "";
         Z34MicrorregiaoMesoUFRegSiglaNome = "";
         Z24MicrorregiaoNome = "";
         Z25MicrorregiaoMesoID = 0;
      }

      protected void InitAll044( )
      {
         A23MicrorregiaoID = 0;
         AssignAttri("", false, "A23MicrorregiaoID", StringUtil.LTrimStr( (decimal)(A23MicrorregiaoID), 9, 0));
         InitializeNonKey044( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2023828113563", true, true);
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
         context.AddJavascriptSource("core/microrregiao.js", "?2023828113566", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtMicrorregiaoID_Internalname = "MICRORREGIAOID";
         edtMicrorregiaoNome_Internalname = "MICRORREGIAONOME";
         lblTextblockmicrorregiaomesoid_Internalname = "TEXTBLOCKMICRORREGIAOMESOID";
         Combo_microrregiaomesoid_Internalname = "COMBO_MICRORREGIAOMESOID";
         edtMicrorregiaoMesoID_Internalname = "MICRORREGIAOMESOID";
         divTablesplittedmicrorregiaomesoid_Internalname = "TABLESPLITTEDMICRORREGIAOMESOID";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         divTablemain_Internalname = "TABLEMAIN";
         edtavCombomicrorregiaomesoid_Internalname = "vCOMBOMICRORREGIAOMESOID";
         divSectionattribute_microrregiaomesoid_Internalname = "SECTIONATTRIBUTE_MICRORREGIAOMESOID";
         edtMicrorregiaoMesoUFID_Internalname = "MICRORREGIAOMESOUFID";
         edtMicrorregiaoMesoUFSigla_Internalname = "MICRORREGIAOMESOUFSIGLA";
         edtMicrorregiaoMesoUFNome_Internalname = "MICRORREGIAOMESOUFNOME";
         edtMicrorregiaoMesoUFSiglaNome_Internalname = "MICRORREGIAOMESOUFSIGLANOME";
         edtMicrorregiaoMesoUFRegID_Internalname = "MICRORREGIAOMESOUFREGID";
         edtMicrorregiaoMesoUFRegSigla_Internalname = "MICRORREGIAOMESOUFREGSIGLA";
         edtMicrorregiaoMesoUFRegNome_Internalname = "MICRORREGIAOMESOUFREGNOME";
         edtMicrorregiaoMesoUFRegSiglaNome_Internalname = "MICRORREGIAOMESOUFREGSIGLANOME";
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
         Form.Caption = "Microrregião";
         edtMicrorregiaoMesoUFRegSiglaNome_Jsonclick = "";
         edtMicrorregiaoMesoUFRegSiglaNome_Enabled = 0;
         edtMicrorregiaoMesoUFRegSiglaNome_Visible = 1;
         edtMicrorregiaoMesoUFRegNome_Jsonclick = "";
         edtMicrorregiaoMesoUFRegNome_Enabled = 0;
         edtMicrorregiaoMesoUFRegNome_Visible = 1;
         edtMicrorregiaoMesoUFRegSigla_Jsonclick = "";
         edtMicrorregiaoMesoUFRegSigla_Enabled = 0;
         edtMicrorregiaoMesoUFRegSigla_Visible = 1;
         edtMicrorregiaoMesoUFRegID_Jsonclick = "";
         edtMicrorregiaoMesoUFRegID_Enabled = 0;
         edtMicrorregiaoMesoUFRegID_Visible = 1;
         edtMicrorregiaoMesoUFSiglaNome_Jsonclick = "";
         edtMicrorregiaoMesoUFSiglaNome_Enabled = 0;
         edtMicrorregiaoMesoUFSiglaNome_Visible = 1;
         edtMicrorregiaoMesoUFNome_Jsonclick = "";
         edtMicrorregiaoMesoUFNome_Enabled = 0;
         edtMicrorregiaoMesoUFNome_Visible = 1;
         edtMicrorregiaoMesoUFSigla_Jsonclick = "";
         edtMicrorregiaoMesoUFSigla_Enabled = 0;
         edtMicrorregiaoMesoUFSigla_Visible = 1;
         edtMicrorregiaoMesoUFID_Jsonclick = "";
         edtMicrorregiaoMesoUFID_Enabled = 0;
         edtMicrorregiaoMesoUFID_Visible = 1;
         edtavCombomicrorregiaomesoid_Jsonclick = "";
         edtavCombomicrorregiaomesoid_Enabled = 0;
         edtavCombomicrorregiaomesoid_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtMicrorregiaoMesoID_Jsonclick = "";
         edtMicrorregiaoMesoID_Enabled = 1;
         edtMicrorregiaoMesoID_Visible = 1;
         Combo_microrregiaomesoid_Emptyitem = Convert.ToBoolean( 0);
         Combo_microrregiaomesoid_Datalistprocparametersprefix = " \"ComboName\": \"MicrorregiaoMesoID\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"MicrorregiaoID\": 0";
         Combo_microrregiaomesoid_Datalistproc = "core.microrregiaoLoadDVCombo";
         Combo_microrregiaomesoid_Cls = "ExtendedCombo AttributeFL";
         Combo_microrregiaomesoid_Caption = "";
         Combo_microrregiaomesoid_Enabled = Convert.ToBoolean( -1);
         edtMicrorregiaoNome_Jsonclick = "";
         edtMicrorregiaoNome_Enabled = 1;
         edtMicrorregiaoID_Jsonclick = "";
         edtMicrorregiaoID_Enabled = 1;
         Dvpanel_tableattributes_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Iconposition = "Right";
         Dvpanel_tableattributes_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Title = "Informações Gerais";
         Dvpanel_tableattributes_Cls = "PanelCard_IconAndTitle Panel_BaseColor";
         Dvpanel_tableattributes_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tableattributes_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Width = "100%";
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

      public void Valid_Microrregiaomesoid( )
      {
         n28MicrorregiaoMesoUFSigla = false;
         n29MicrorregiaoMesoUFNome = false;
         n31MicrorregiaoMesoUFRegID = false;
         n32MicrorregiaoMesoUFRegSigla = false;
         n33MicrorregiaoMesoUFRegNome = false;
         n30MicrorregiaoMesoUFSiglaNome = false;
         n34MicrorregiaoMesoUFRegSiglaNome = false;
         /* Using cursor T000417 */
         pr_default.execute(15, new Object[] {A25MicrorregiaoMesoID});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("Não existe 'Group Mesoregião -> Microregião'.", "ForeignKeyNotFound", 1, "MICRORREGIAOMESOID");
            AnyError = 1;
            GX_FocusControl = edtMicrorregiaoMesoID_Internalname;
         }
         A26MicrorregiaoMesoNome = T000417_A26MicrorregiaoMesoNome[0];
         A27MicrorregiaoMesoUFID = T000417_A27MicrorregiaoMesoUFID[0];
         pr_default.close(15);
         /* Using cursor T000418 */
         pr_default.execute(16, new Object[] {A27MicrorregiaoMesoUFID});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem("Não existe 'Unidade Federativa (Estado)'.", "ForeignKeyNotFound", 1, "MICRORREGIAOMESOUFID");
            AnyError = 1;
         }
         A28MicrorregiaoMesoUFSigla = T000418_A28MicrorregiaoMesoUFSigla[0];
         n28MicrorregiaoMesoUFSigla = T000418_n28MicrorregiaoMesoUFSigla[0];
         A29MicrorregiaoMesoUFNome = T000418_A29MicrorregiaoMesoUFNome[0];
         n29MicrorregiaoMesoUFNome = T000418_n29MicrorregiaoMesoUFNome[0];
         A31MicrorregiaoMesoUFRegID = T000418_A31MicrorregiaoMesoUFRegID[0];
         n31MicrorregiaoMesoUFRegID = T000418_n31MicrorregiaoMesoUFRegID[0];
         pr_default.close(16);
         A30MicrorregiaoMesoUFSiglaNome = StringUtil.Trim( A28MicrorregiaoMesoUFSigla) + " - " + StringUtil.Trim( A29MicrorregiaoMesoUFNome);
         n30MicrorregiaoMesoUFSiglaNome = false;
         /* Using cursor T000419 */
         pr_default.execute(17, new Object[] {n31MicrorregiaoMesoUFRegID, A31MicrorregiaoMesoUFRegID});
         if ( (pr_default.getStatus(17) == 101) )
         {
            GX_msglist.addItem("Não existe 'Região'.", "ForeignKeyNotFound", 1, "MICRORREGIAOMESOUFREGID");
            AnyError = 1;
         }
         A32MicrorregiaoMesoUFRegSigla = T000419_A32MicrorregiaoMesoUFRegSigla[0];
         n32MicrorregiaoMesoUFRegSigla = T000419_n32MicrorregiaoMesoUFRegSigla[0];
         A33MicrorregiaoMesoUFRegNome = T000419_A33MicrorregiaoMesoUFRegNome[0];
         n33MicrorregiaoMesoUFRegNome = T000419_n33MicrorregiaoMesoUFRegNome[0];
         pr_default.close(17);
         A34MicrorregiaoMesoUFRegSiglaNome = StringUtil.Trim( A32MicrorregiaoMesoUFRegSigla) + " - " + StringUtil.Trim( A33MicrorregiaoMesoUFRegNome);
         n34MicrorregiaoMesoUFRegSiglaNome = false;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A26MicrorregiaoMesoNome", A26MicrorregiaoMesoNome);
         AssignAttri("", false, "A27MicrorregiaoMesoUFID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A27MicrorregiaoMesoUFID), 9, 0, ".", "")));
         AssignAttri("", false, "A28MicrorregiaoMesoUFSigla", A28MicrorregiaoMesoUFSigla);
         AssignAttri("", false, "A29MicrorregiaoMesoUFNome", A29MicrorregiaoMesoUFNome);
         AssignAttri("", false, "A31MicrorregiaoMesoUFRegID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A31MicrorregiaoMesoUFRegID), 9, 0, ".", "")));
         AssignAttri("", false, "A30MicrorregiaoMesoUFSiglaNome", A30MicrorregiaoMesoUFSiglaNome);
         AssignAttri("", false, "A32MicrorregiaoMesoUFRegSigla", A32MicrorregiaoMesoUFRegSigla);
         AssignAttri("", false, "A33MicrorregiaoMesoUFRegNome", A33MicrorregiaoMesoUFRegNome);
         AssignAttri("", false, "A34MicrorregiaoMesoUFRegSiglaNome", A34MicrorregiaoMesoUFRegSiglaNome);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7MicrorregiaoID',fld:'vMICRORREGIAOID',pic:'ZZZ,ZZZ,ZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7MicrorregiaoID',fld:'vMICRORREGIAOID',pic:'ZZZ,ZZZ,ZZ9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E12042',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_MICRORREGIAOID","{handler:'Valid_Microrregiaoid',iparms:[]");
         setEventMetadata("VALID_MICRORREGIAOID",",oparms:[]}");
         setEventMetadata("VALID_MICRORREGIAOMESOID","{handler:'Valid_Microrregiaomesoid',iparms:[{av:'A25MicrorregiaoMesoID',fld:'MICRORREGIAOMESOID',pic:'ZZZ,ZZZ,ZZ9'},{av:'A27MicrorregiaoMesoUFID',fld:'MICRORREGIAOMESOUFID',pic:'ZZZ,ZZZ,ZZ9'},{av:'A28MicrorregiaoMesoUFSigla',fld:'MICRORREGIAOMESOUFSIGLA',pic:'@!'},{av:'A29MicrorregiaoMesoUFNome',fld:'MICRORREGIAOMESOUFNOME',pic:''},{av:'A31MicrorregiaoMesoUFRegID',fld:'MICRORREGIAOMESOUFREGID',pic:'ZZZ,ZZZ,ZZ9'},{av:'A32MicrorregiaoMesoUFRegSigla',fld:'MICRORREGIAOMESOUFREGSIGLA',pic:'@!'},{av:'A33MicrorregiaoMesoUFRegNome',fld:'MICRORREGIAOMESOUFREGNOME',pic:''},{av:'A26MicrorregiaoMesoNome',fld:'MICRORREGIAOMESONOME',pic:''},{av:'A30MicrorregiaoMesoUFSiglaNome',fld:'MICRORREGIAOMESOUFSIGLANOME',pic:''},{av:'A34MicrorregiaoMesoUFRegSiglaNome',fld:'MICRORREGIAOMESOUFREGSIGLANOME',pic:''}]");
         setEventMetadata("VALID_MICRORREGIAOMESOID",",oparms:[{av:'A26MicrorregiaoMesoNome',fld:'MICRORREGIAOMESONOME',pic:''},{av:'A27MicrorregiaoMesoUFID',fld:'MICRORREGIAOMESOUFID',pic:'ZZZ,ZZZ,ZZ9'},{av:'A28MicrorregiaoMesoUFSigla',fld:'MICRORREGIAOMESOUFSIGLA',pic:'@!'},{av:'A29MicrorregiaoMesoUFNome',fld:'MICRORREGIAOMESOUFNOME',pic:''},{av:'A31MicrorregiaoMesoUFRegID',fld:'MICRORREGIAOMESOUFREGID',pic:'ZZZ,ZZZ,ZZ9'},{av:'A30MicrorregiaoMesoUFSiglaNome',fld:'MICRORREGIAOMESOUFSIGLANOME',pic:''},{av:'A32MicrorregiaoMesoUFRegSigla',fld:'MICRORREGIAOMESOUFREGSIGLA',pic:'@!'},{av:'A33MicrorregiaoMesoUFRegNome',fld:'MICRORREGIAOMESOUFREGNOME',pic:''},{av:'A34MicrorregiaoMesoUFRegSiglaNome',fld:'MICRORREGIAOMESOUFREGSIGLANOME',pic:''}]}");
         setEventMetadata("VALIDV_COMBOMICRORREGIAOMESOID","{handler:'Validv_Combomicrorregiaomesoid',iparms:[]");
         setEventMetadata("VALIDV_COMBOMICRORREGIAOMESOID",",oparms:[]}");
         setEventMetadata("VALID_MICRORREGIAOMESOUFID","{handler:'Valid_Microrregiaomesoufid',iparms:[]");
         setEventMetadata("VALID_MICRORREGIAOMESOUFID",",oparms:[]}");
         setEventMetadata("VALID_MICRORREGIAOMESOUFSIGLA","{handler:'Valid_Microrregiaomesoufsigla',iparms:[]");
         setEventMetadata("VALID_MICRORREGIAOMESOUFSIGLA",",oparms:[]}");
         setEventMetadata("VALID_MICRORREGIAOMESOUFNOME","{handler:'Valid_Microrregiaomesoufnome',iparms:[]");
         setEventMetadata("VALID_MICRORREGIAOMESOUFNOME",",oparms:[]}");
         setEventMetadata("VALID_MICRORREGIAOMESOUFREGID","{handler:'Valid_Microrregiaomesoufregid',iparms:[]");
         setEventMetadata("VALID_MICRORREGIAOMESOUFREGID",",oparms:[]}");
         setEventMetadata("VALID_MICRORREGIAOMESOUFREGSIGLA","{handler:'Valid_Microrregiaomesoufregsigla',iparms:[]");
         setEventMetadata("VALID_MICRORREGIAOMESOUFREGSIGLA",",oparms:[]}");
         setEventMetadata("VALID_MICRORREGIAOMESOUFREGNOME","{handler:'Valid_Microrregiaomesoufregnome',iparms:[]");
         setEventMetadata("VALID_MICRORREGIAOMESOUFREGNOME",",oparms:[]}");
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
         pr_default.close(15);
         pr_default.close(16);
         pr_default.close(17);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z30MicrorregiaoMesoUFSiglaNome = "";
         Z34MicrorregiaoMesoUFRegSiglaNome = "";
         Z24MicrorregiaoNome = "";
         Combo_microrregiaomesoid_Selectedvalue_get = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         A24MicrorregiaoNome = "";
         lblTextblockmicrorregiaomesoid_Jsonclick = "";
         ucCombo_microrregiaomesoid = new GXUserControl();
         AV16DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV15MicrorregiaoMesoID_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         A28MicrorregiaoMesoUFSigla = "";
         A29MicrorregiaoMesoUFNome = "";
         A30MicrorregiaoMesoUFSiglaNome = "";
         A32MicrorregiaoMesoUFRegSigla = "";
         A33MicrorregiaoMesoUFRegNome = "";
         A34MicrorregiaoMesoUFRegSiglaNome = "";
         A26MicrorregiaoMesoNome = "";
         AV25Pgmname = "";
         Combo_microrregiaomesoid_Objectcall = "";
         Combo_microrregiaomesoid_Class = "";
         Combo_microrregiaomesoid_Icontype = "";
         Combo_microrregiaomesoid_Icon = "";
         Combo_microrregiaomesoid_Tooltip = "";
         Combo_microrregiaomesoid_Selectedvalue_set = "";
         Combo_microrregiaomesoid_Selectedtext_set = "";
         Combo_microrregiaomesoid_Selectedtext_get = "";
         Combo_microrregiaomesoid_Gamoauthtoken = "";
         Combo_microrregiaomesoid_Ddointernalname = "";
         Combo_microrregiaomesoid_Titlecontrolalign = "";
         Combo_microrregiaomesoid_Dropdownoptionstype = "";
         Combo_microrregiaomesoid_Titlecontrolidtoreplace = "";
         Combo_microrregiaomesoid_Datalisttype = "";
         Combo_microrregiaomesoid_Datalistfixedvalues = "";
         Combo_microrregiaomesoid_Remoteservicesparameters = "";
         Combo_microrregiaomesoid_Htmltemplate = "";
         Combo_microrregiaomesoid_Multiplevaluestype = "";
         Combo_microrregiaomesoid_Loadingdata = "";
         Combo_microrregiaomesoid_Noresultsfound = "";
         Combo_microrregiaomesoid_Emptyitemtext = "";
         Combo_microrregiaomesoid_Onlyselectedvalues = "";
         Combo_microrregiaomesoid_Selectalltext = "";
         Combo_microrregiaomesoid_Multiplevaluesseparator = "";
         Combo_microrregiaomesoid_Addnewoptiontext = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode4 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV22GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV23GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV14TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV19Combo_DataJson = "";
         AV17ComboSelectedValue = "";
         AV18ComboSelectedText = "";
         GXt_char2 = "";
         Z26MicrorregiaoMesoNome = "";
         Z28MicrorregiaoMesoUFSigla = "";
         Z29MicrorregiaoMesoUFNome = "";
         Z32MicrorregiaoMesoUFRegSigla = "";
         Z33MicrorregiaoMesoUFRegNome = "";
         T00044_A26MicrorregiaoMesoNome = new string[] {""} ;
         T00044_A27MicrorregiaoMesoUFID = new int[1] ;
         T00045_A28MicrorregiaoMesoUFSigla = new string[] {""} ;
         T00045_n28MicrorregiaoMesoUFSigla = new bool[] {false} ;
         T00045_A29MicrorregiaoMesoUFNome = new string[] {""} ;
         T00045_n29MicrorregiaoMesoUFNome = new bool[] {false} ;
         T00045_A31MicrorregiaoMesoUFRegID = new int[1] ;
         T00045_n31MicrorregiaoMesoUFRegID = new bool[] {false} ;
         T00046_A32MicrorregiaoMesoUFRegSigla = new string[] {""} ;
         T00046_n32MicrorregiaoMesoUFRegSigla = new bool[] {false} ;
         T00046_A33MicrorregiaoMesoUFRegNome = new string[] {""} ;
         T00046_n33MicrorregiaoMesoUFRegNome = new bool[] {false} ;
         T00047_A30MicrorregiaoMesoUFSiglaNome = new string[] {""} ;
         T00047_n30MicrorregiaoMesoUFSiglaNome = new bool[] {false} ;
         T00047_A34MicrorregiaoMesoUFRegSiglaNome = new string[] {""} ;
         T00047_n34MicrorregiaoMesoUFRegSiglaNome = new bool[] {false} ;
         T00047_A23MicrorregiaoID = new int[1] ;
         T00047_A24MicrorregiaoNome = new string[] {""} ;
         T00047_A26MicrorregiaoMesoNome = new string[] {""} ;
         T00047_A27MicrorregiaoMesoUFID = new int[1] ;
         T00047_A28MicrorregiaoMesoUFSigla = new string[] {""} ;
         T00047_n28MicrorregiaoMesoUFSigla = new bool[] {false} ;
         T00047_A29MicrorregiaoMesoUFNome = new string[] {""} ;
         T00047_n29MicrorregiaoMesoUFNome = new bool[] {false} ;
         T00047_A31MicrorregiaoMesoUFRegID = new int[1] ;
         T00047_n31MicrorregiaoMesoUFRegID = new bool[] {false} ;
         T00047_A32MicrorregiaoMesoUFRegSigla = new string[] {""} ;
         T00047_n32MicrorregiaoMesoUFRegSigla = new bool[] {false} ;
         T00047_A33MicrorregiaoMesoUFRegNome = new string[] {""} ;
         T00047_n33MicrorregiaoMesoUFRegNome = new bool[] {false} ;
         T00047_A25MicrorregiaoMesoID = new int[1] ;
         T00048_A26MicrorregiaoMesoNome = new string[] {""} ;
         T00048_A27MicrorregiaoMesoUFID = new int[1] ;
         T00049_A28MicrorregiaoMesoUFSigla = new string[] {""} ;
         T00049_n28MicrorregiaoMesoUFSigla = new bool[] {false} ;
         T00049_A29MicrorregiaoMesoUFNome = new string[] {""} ;
         T00049_n29MicrorregiaoMesoUFNome = new bool[] {false} ;
         T00049_A31MicrorregiaoMesoUFRegID = new int[1] ;
         T00049_n31MicrorregiaoMesoUFRegID = new bool[] {false} ;
         T000410_A32MicrorregiaoMesoUFRegSigla = new string[] {""} ;
         T000410_n32MicrorregiaoMesoUFRegSigla = new bool[] {false} ;
         T000410_A33MicrorregiaoMesoUFRegNome = new string[] {""} ;
         T000410_n33MicrorregiaoMesoUFRegNome = new bool[] {false} ;
         T000411_A23MicrorregiaoID = new int[1] ;
         T00043_A23MicrorregiaoID = new int[1] ;
         T00043_A24MicrorregiaoNome = new string[] {""} ;
         T00043_A25MicrorregiaoMesoID = new int[1] ;
         T00043_A26MicrorregiaoMesoNome = new string[] {""} ;
         T00043_A27MicrorregiaoMesoUFID = new int[1] ;
         T00043_A28MicrorregiaoMesoUFSigla = new string[] {""} ;
         T00043_n28MicrorregiaoMesoUFSigla = new bool[] {false} ;
         T00043_A29MicrorregiaoMesoUFNome = new string[] {""} ;
         T00043_n29MicrorregiaoMesoUFNome = new bool[] {false} ;
         T00043_A30MicrorregiaoMesoUFSiglaNome = new string[] {""} ;
         T00043_n30MicrorregiaoMesoUFSiglaNome = new bool[] {false} ;
         T00043_A31MicrorregiaoMesoUFRegID = new int[1] ;
         T00043_n31MicrorregiaoMesoUFRegID = new bool[] {false} ;
         T00043_A32MicrorregiaoMesoUFRegSigla = new string[] {""} ;
         T00043_n32MicrorregiaoMesoUFRegSigla = new bool[] {false} ;
         T00043_A33MicrorregiaoMesoUFRegNome = new string[] {""} ;
         T00043_n33MicrorregiaoMesoUFRegNome = new bool[] {false} ;
         T00043_A34MicrorregiaoMesoUFRegSiglaNome = new string[] {""} ;
         T00043_n34MicrorregiaoMesoUFRegSiglaNome = new bool[] {false} ;
         T000412_A23MicrorregiaoID = new int[1] ;
         T000413_A23MicrorregiaoID = new int[1] ;
         T00042_A23MicrorregiaoID = new int[1] ;
         T00042_A24MicrorregiaoNome = new string[] {""} ;
         T00042_A25MicrorregiaoMesoID = new int[1] ;
         T00042_A26MicrorregiaoMesoNome = new string[] {""} ;
         T00042_A27MicrorregiaoMesoUFID = new int[1] ;
         T00042_A28MicrorregiaoMesoUFSigla = new string[] {""} ;
         T00042_n28MicrorregiaoMesoUFSigla = new bool[] {false} ;
         T00042_A29MicrorregiaoMesoUFNome = new string[] {""} ;
         T00042_n29MicrorregiaoMesoUFNome = new bool[] {false} ;
         T00042_A30MicrorregiaoMesoUFSiglaNome = new string[] {""} ;
         T00042_n30MicrorregiaoMesoUFSiglaNome = new bool[] {false} ;
         T00042_A31MicrorregiaoMesoUFRegID = new int[1] ;
         T00042_n31MicrorregiaoMesoUFRegID = new bool[] {false} ;
         T00042_A32MicrorregiaoMesoUFRegSigla = new string[] {""} ;
         T00042_n32MicrorregiaoMesoUFRegSigla = new bool[] {false} ;
         T00042_A33MicrorregiaoMesoUFRegNome = new string[] {""} ;
         T00042_n33MicrorregiaoMesoUFRegNome = new bool[] {false} ;
         T00042_A34MicrorregiaoMesoUFRegSiglaNome = new string[] {""} ;
         T00042_n34MicrorregiaoMesoUFRegSiglaNome = new bool[] {false} ;
         T000417_A26MicrorregiaoMesoNome = new string[] {""} ;
         T000417_A27MicrorregiaoMesoUFID = new int[1] ;
         T000418_A28MicrorregiaoMesoUFSigla = new string[] {""} ;
         T000418_n28MicrorregiaoMesoUFSigla = new bool[] {false} ;
         T000418_A29MicrorregiaoMesoUFNome = new string[] {""} ;
         T000418_n29MicrorregiaoMesoUFNome = new bool[] {false} ;
         T000418_A31MicrorregiaoMesoUFRegID = new int[1] ;
         T000418_n31MicrorregiaoMesoUFRegID = new bool[] {false} ;
         T000419_A32MicrorregiaoMesoUFRegSigla = new string[] {""} ;
         T000419_n32MicrorregiaoMesoUFRegSigla = new bool[] {false} ;
         T000419_A33MicrorregiaoMesoUFRegNome = new string[] {""} ;
         T000419_n33MicrorregiaoMesoUFRegNome = new bool[] {false} ;
         T000420_A35MunicipioID = new int[1] ;
         T000421_A23MicrorregiaoID = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.core.microrregiao__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.microrregiao__default(),
            new Object[][] {
                new Object[] {
               T00042_A23MicrorregiaoID, T00042_A24MicrorregiaoNome, T00042_A25MicrorregiaoMesoID, T00042_A26MicrorregiaoMesoNome, T00042_A27MicrorregiaoMesoUFID, T00042_A28MicrorregiaoMesoUFSigla, T00042_n28MicrorregiaoMesoUFSigla, T00042_A29MicrorregiaoMesoUFNome, T00042_n29MicrorregiaoMesoUFNome, T00042_A30MicrorregiaoMesoUFSiglaNome,
               T00042_n30MicrorregiaoMesoUFSiglaNome, T00042_A31MicrorregiaoMesoUFRegID, T00042_n31MicrorregiaoMesoUFRegID, T00042_A32MicrorregiaoMesoUFRegSigla, T00042_n32MicrorregiaoMesoUFRegSigla, T00042_A33MicrorregiaoMesoUFRegNome, T00042_n33MicrorregiaoMesoUFRegNome, T00042_A34MicrorregiaoMesoUFRegSiglaNome, T00042_n34MicrorregiaoMesoUFRegSiglaNome
               }
               , new Object[] {
               T00043_A23MicrorregiaoID, T00043_A24MicrorregiaoNome, T00043_A25MicrorregiaoMesoID, T00043_A26MicrorregiaoMesoNome, T00043_A27MicrorregiaoMesoUFID, T00043_A28MicrorregiaoMesoUFSigla, T00043_n28MicrorregiaoMesoUFSigla, T00043_A29MicrorregiaoMesoUFNome, T00043_n29MicrorregiaoMesoUFNome, T00043_A30MicrorregiaoMesoUFSiglaNome,
               T00043_n30MicrorregiaoMesoUFSiglaNome, T00043_A31MicrorregiaoMesoUFRegID, T00043_n31MicrorregiaoMesoUFRegID, T00043_A32MicrorregiaoMesoUFRegSigla, T00043_n32MicrorregiaoMesoUFRegSigla, T00043_A33MicrorregiaoMesoUFRegNome, T00043_n33MicrorregiaoMesoUFRegNome, T00043_A34MicrorregiaoMesoUFRegSiglaNome, T00043_n34MicrorregiaoMesoUFRegSiglaNome
               }
               , new Object[] {
               T00044_A26MicrorregiaoMesoNome, T00044_A27MicrorregiaoMesoUFID
               }
               , new Object[] {
               T00045_A28MicrorregiaoMesoUFSigla, T00045_A29MicrorregiaoMesoUFNome, T00045_A31MicrorregiaoMesoUFRegID
               }
               , new Object[] {
               T00046_A32MicrorregiaoMesoUFRegSigla, T00046_A33MicrorregiaoMesoUFRegNome
               }
               , new Object[] {
               T00047_A30MicrorregiaoMesoUFSiglaNome, T00047_n30MicrorregiaoMesoUFSiglaNome, T00047_A34MicrorregiaoMesoUFRegSiglaNome, T00047_n34MicrorregiaoMesoUFRegSiglaNome, T00047_A23MicrorregiaoID, T00047_A24MicrorregiaoNome, T00047_A26MicrorregiaoMesoNome, T00047_A27MicrorregiaoMesoUFID, T00047_A28MicrorregiaoMesoUFSigla, T00047_n28MicrorregiaoMesoUFSigla,
               T00047_A29MicrorregiaoMesoUFNome, T00047_n29MicrorregiaoMesoUFNome, T00047_A31MicrorregiaoMesoUFRegID, T00047_n31MicrorregiaoMesoUFRegID, T00047_A32MicrorregiaoMesoUFRegSigla, T00047_n32MicrorregiaoMesoUFRegSigla, T00047_A33MicrorregiaoMesoUFRegNome, T00047_n33MicrorregiaoMesoUFRegNome, T00047_A25MicrorregiaoMesoID
               }
               , new Object[] {
               T00048_A26MicrorregiaoMesoNome, T00048_A27MicrorregiaoMesoUFID
               }
               , new Object[] {
               T00049_A28MicrorregiaoMesoUFSigla, T00049_A29MicrorregiaoMesoUFNome, T00049_A31MicrorregiaoMesoUFRegID
               }
               , new Object[] {
               T000410_A32MicrorregiaoMesoUFRegSigla, T000410_A33MicrorregiaoMesoUFRegNome
               }
               , new Object[] {
               T000411_A23MicrorregiaoID
               }
               , new Object[] {
               T000412_A23MicrorregiaoID
               }
               , new Object[] {
               T000413_A23MicrorregiaoID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000417_A26MicrorregiaoMesoNome, T000417_A27MicrorregiaoMesoUFID
               }
               , new Object[] {
               T000418_A28MicrorregiaoMesoUFSigla, T000418_A29MicrorregiaoMesoUFNome, T000418_A31MicrorregiaoMesoUFRegID
               }
               , new Object[] {
               T000419_A32MicrorregiaoMesoUFRegSigla, T000419_A33MicrorregiaoMesoUFRegNome
               }
               , new Object[] {
               T000420_A35MunicipioID
               }
               , new Object[] {
               T000421_A23MicrorregiaoID
               }
            }
         );
         AV25Pgmname = "core.microrregiao";
      }

      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short RcdFound4 ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short nIsDirty_4 ;
      private short gxajaxcallmode ;
      private int wcpOAV7MicrorregiaoID ;
      private int Z23MicrorregiaoID ;
      private int Z25MicrorregiaoMesoID ;
      private int N25MicrorregiaoMesoID ;
      private int A25MicrorregiaoMesoID ;
      private int A27MicrorregiaoMesoUFID ;
      private int A31MicrorregiaoMesoUFRegID ;
      private int AV7MicrorregiaoID ;
      private int trnEnded ;
      private int A23MicrorregiaoID ;
      private int edtMicrorregiaoID_Enabled ;
      private int edtMicrorregiaoNome_Enabled ;
      private int edtMicrorregiaoMesoID_Visible ;
      private int edtMicrorregiaoMesoID_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int AV20ComboMicrorregiaoMesoID ;
      private int edtavCombomicrorregiaomesoid_Enabled ;
      private int edtavCombomicrorregiaomesoid_Visible ;
      private int edtMicrorregiaoMesoUFID_Enabled ;
      private int edtMicrorregiaoMesoUFID_Visible ;
      private int edtMicrorregiaoMesoUFSigla_Visible ;
      private int edtMicrorregiaoMesoUFSigla_Enabled ;
      private int edtMicrorregiaoMesoUFNome_Visible ;
      private int edtMicrorregiaoMesoUFNome_Enabled ;
      private int edtMicrorregiaoMesoUFSiglaNome_Visible ;
      private int edtMicrorregiaoMesoUFSiglaNome_Enabled ;
      private int edtMicrorregiaoMesoUFRegID_Enabled ;
      private int edtMicrorregiaoMesoUFRegID_Visible ;
      private int edtMicrorregiaoMesoUFRegSigla_Visible ;
      private int edtMicrorregiaoMesoUFRegSigla_Enabled ;
      private int edtMicrorregiaoMesoUFRegNome_Visible ;
      private int edtMicrorregiaoMesoUFRegNome_Enabled ;
      private int edtMicrorregiaoMesoUFRegSiglaNome_Visible ;
      private int edtMicrorregiaoMesoUFRegSiglaNome_Enabled ;
      private int AV13Insert_MicrorregiaoMesoID ;
      private int Combo_microrregiaomesoid_Datalistupdateminimumcharacters ;
      private int Combo_microrregiaomesoid_Gxcontroltype ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int AV26GXV1 ;
      private int Z27MicrorregiaoMesoUFID ;
      private int Z31MicrorregiaoMesoUFRegID ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Combo_microrregiaomesoid_Selectedvalue_get ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtMicrorregiaoID_Internalname ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string Dvpanel_tableattributes_Width ;
      private string Dvpanel_tableattributes_Cls ;
      private string Dvpanel_tableattributes_Title ;
      private string Dvpanel_tableattributes_Iconposition ;
      private string Dvpanel_tableattributes_Internalname ;
      private string divTableattributes_Internalname ;
      private string TempTags ;
      private string edtMicrorregiaoID_Jsonclick ;
      private string edtMicrorregiaoNome_Internalname ;
      private string edtMicrorregiaoNome_Jsonclick ;
      private string divTablesplittedmicrorregiaomesoid_Internalname ;
      private string lblTextblockmicrorregiaomesoid_Internalname ;
      private string lblTextblockmicrorregiaomesoid_Jsonclick ;
      private string Combo_microrregiaomesoid_Caption ;
      private string Combo_microrregiaomesoid_Cls ;
      private string Combo_microrregiaomesoid_Datalistproc ;
      private string Combo_microrregiaomesoid_Datalistprocparametersprefix ;
      private string Combo_microrregiaomesoid_Internalname ;
      private string edtMicrorregiaoMesoID_Internalname ;
      private string edtMicrorregiaoMesoID_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_microrregiaomesoid_Internalname ;
      private string edtavCombomicrorregiaomesoid_Internalname ;
      private string edtavCombomicrorregiaomesoid_Jsonclick ;
      private string edtMicrorregiaoMesoUFID_Internalname ;
      private string edtMicrorregiaoMesoUFID_Jsonclick ;
      private string edtMicrorregiaoMesoUFSigla_Internalname ;
      private string edtMicrorregiaoMesoUFSigla_Jsonclick ;
      private string edtMicrorregiaoMesoUFNome_Internalname ;
      private string edtMicrorregiaoMesoUFNome_Jsonclick ;
      private string edtMicrorregiaoMesoUFSiglaNome_Internalname ;
      private string edtMicrorregiaoMesoUFSiglaNome_Jsonclick ;
      private string edtMicrorregiaoMesoUFRegID_Internalname ;
      private string edtMicrorregiaoMesoUFRegID_Jsonclick ;
      private string edtMicrorregiaoMesoUFRegSigla_Internalname ;
      private string edtMicrorregiaoMesoUFRegSigla_Jsonclick ;
      private string edtMicrorregiaoMesoUFRegNome_Internalname ;
      private string edtMicrorregiaoMesoUFRegNome_Jsonclick ;
      private string edtMicrorregiaoMesoUFRegSiglaNome_Internalname ;
      private string edtMicrorregiaoMesoUFRegSiglaNome_Jsonclick ;
      private string AV25Pgmname ;
      private string Combo_microrregiaomesoid_Objectcall ;
      private string Combo_microrregiaomesoid_Class ;
      private string Combo_microrregiaomesoid_Icontype ;
      private string Combo_microrregiaomesoid_Icon ;
      private string Combo_microrregiaomesoid_Tooltip ;
      private string Combo_microrregiaomesoid_Selectedvalue_set ;
      private string Combo_microrregiaomesoid_Selectedtext_set ;
      private string Combo_microrregiaomesoid_Selectedtext_get ;
      private string Combo_microrregiaomesoid_Gamoauthtoken ;
      private string Combo_microrregiaomesoid_Ddointernalname ;
      private string Combo_microrregiaomesoid_Titlecontrolalign ;
      private string Combo_microrregiaomesoid_Dropdownoptionstype ;
      private string Combo_microrregiaomesoid_Titlecontrolidtoreplace ;
      private string Combo_microrregiaomesoid_Datalisttype ;
      private string Combo_microrregiaomesoid_Datalistfixedvalues ;
      private string Combo_microrregiaomesoid_Remoteservicesparameters ;
      private string Combo_microrregiaomesoid_Htmltemplate ;
      private string Combo_microrregiaomesoid_Multiplevaluestype ;
      private string Combo_microrregiaomesoid_Loadingdata ;
      private string Combo_microrregiaomesoid_Noresultsfound ;
      private string Combo_microrregiaomesoid_Emptyitemtext ;
      private string Combo_microrregiaomesoid_Onlyselectedvalues ;
      private string Combo_microrregiaomesoid_Selectalltext ;
      private string Combo_microrregiaomesoid_Multiplevaluesseparator ;
      private string Combo_microrregiaomesoid_Addnewoptiontext ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string hsh ;
      private string sMode4 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXt_char2 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXEncryptionTmp ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n31MicrorregiaoMesoUFRegID ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool Combo_microrregiaomesoid_Emptyitem ;
      private bool n30MicrorregiaoMesoUFSiglaNome ;
      private bool n34MicrorregiaoMesoUFRegSiglaNome ;
      private bool Combo_microrregiaomesoid_Enabled ;
      private bool Combo_microrregiaomesoid_Visible ;
      private bool Combo_microrregiaomesoid_Allowmultipleselection ;
      private bool Combo_microrregiaomesoid_Isgriditem ;
      private bool Combo_microrregiaomesoid_Hasdescription ;
      private bool Combo_microrregiaomesoid_Includeonlyselectedoption ;
      private bool Combo_microrregiaomesoid_Includeselectalloption ;
      private bool Combo_microrregiaomesoid_Includeaddnewoption ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool n28MicrorregiaoMesoUFSigla ;
      private bool n29MicrorregiaoMesoUFNome ;
      private bool n32MicrorregiaoMesoUFRegSigla ;
      private bool n33MicrorregiaoMesoUFRegNome ;
      private bool returnInSub ;
      private string AV19Combo_DataJson ;
      private string Z30MicrorregiaoMesoUFSiglaNome ;
      private string Z34MicrorregiaoMesoUFRegSiglaNome ;
      private string Z24MicrorregiaoNome ;
      private string A24MicrorregiaoNome ;
      private string A28MicrorregiaoMesoUFSigla ;
      private string A29MicrorregiaoMesoUFNome ;
      private string A30MicrorregiaoMesoUFSiglaNome ;
      private string A32MicrorregiaoMesoUFRegSigla ;
      private string A33MicrorregiaoMesoUFRegNome ;
      private string A34MicrorregiaoMesoUFRegSiglaNome ;
      private string A26MicrorregiaoMesoNome ;
      private string AV17ComboSelectedValue ;
      private string AV18ComboSelectedText ;
      private string Z26MicrorregiaoMesoNome ;
      private string Z28MicrorregiaoMesoUFSigla ;
      private string Z29MicrorregiaoMesoUFNome ;
      private string Z32MicrorregiaoMesoUFRegSigla ;
      private string Z33MicrorregiaoMesoUFRegNome ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucCombo_microrregiaomesoid ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T00044_A26MicrorregiaoMesoNome ;
      private int[] T00044_A27MicrorregiaoMesoUFID ;
      private string[] T00045_A28MicrorregiaoMesoUFSigla ;
      private bool[] T00045_n28MicrorregiaoMesoUFSigla ;
      private string[] T00045_A29MicrorregiaoMesoUFNome ;
      private bool[] T00045_n29MicrorregiaoMesoUFNome ;
      private int[] T00045_A31MicrorregiaoMesoUFRegID ;
      private bool[] T00045_n31MicrorregiaoMesoUFRegID ;
      private string[] T00046_A32MicrorregiaoMesoUFRegSigla ;
      private bool[] T00046_n32MicrorregiaoMesoUFRegSigla ;
      private string[] T00046_A33MicrorregiaoMesoUFRegNome ;
      private bool[] T00046_n33MicrorregiaoMesoUFRegNome ;
      private string[] T00047_A30MicrorregiaoMesoUFSiglaNome ;
      private bool[] T00047_n30MicrorregiaoMesoUFSiglaNome ;
      private string[] T00047_A34MicrorregiaoMesoUFRegSiglaNome ;
      private bool[] T00047_n34MicrorregiaoMesoUFRegSiglaNome ;
      private int[] T00047_A23MicrorregiaoID ;
      private string[] T00047_A24MicrorregiaoNome ;
      private string[] T00047_A26MicrorregiaoMesoNome ;
      private int[] T00047_A27MicrorregiaoMesoUFID ;
      private string[] T00047_A28MicrorregiaoMesoUFSigla ;
      private bool[] T00047_n28MicrorregiaoMesoUFSigla ;
      private string[] T00047_A29MicrorregiaoMesoUFNome ;
      private bool[] T00047_n29MicrorregiaoMesoUFNome ;
      private int[] T00047_A31MicrorregiaoMesoUFRegID ;
      private bool[] T00047_n31MicrorregiaoMesoUFRegID ;
      private string[] T00047_A32MicrorregiaoMesoUFRegSigla ;
      private bool[] T00047_n32MicrorregiaoMesoUFRegSigla ;
      private string[] T00047_A33MicrorregiaoMesoUFRegNome ;
      private bool[] T00047_n33MicrorregiaoMesoUFRegNome ;
      private int[] T00047_A25MicrorregiaoMesoID ;
      private string[] T00048_A26MicrorregiaoMesoNome ;
      private int[] T00048_A27MicrorregiaoMesoUFID ;
      private string[] T00049_A28MicrorregiaoMesoUFSigla ;
      private bool[] T00049_n28MicrorregiaoMesoUFSigla ;
      private string[] T00049_A29MicrorregiaoMesoUFNome ;
      private bool[] T00049_n29MicrorregiaoMesoUFNome ;
      private int[] T00049_A31MicrorregiaoMesoUFRegID ;
      private bool[] T00049_n31MicrorregiaoMesoUFRegID ;
      private string[] T000410_A32MicrorregiaoMesoUFRegSigla ;
      private bool[] T000410_n32MicrorregiaoMesoUFRegSigla ;
      private string[] T000410_A33MicrorregiaoMesoUFRegNome ;
      private bool[] T000410_n33MicrorregiaoMesoUFRegNome ;
      private int[] T000411_A23MicrorregiaoID ;
      private int[] T00043_A23MicrorregiaoID ;
      private string[] T00043_A24MicrorregiaoNome ;
      private int[] T00043_A25MicrorregiaoMesoID ;
      private string[] T00043_A26MicrorregiaoMesoNome ;
      private int[] T00043_A27MicrorregiaoMesoUFID ;
      private string[] T00043_A28MicrorregiaoMesoUFSigla ;
      private bool[] T00043_n28MicrorregiaoMesoUFSigla ;
      private string[] T00043_A29MicrorregiaoMesoUFNome ;
      private bool[] T00043_n29MicrorregiaoMesoUFNome ;
      private string[] T00043_A30MicrorregiaoMesoUFSiglaNome ;
      private bool[] T00043_n30MicrorregiaoMesoUFSiglaNome ;
      private int[] T00043_A31MicrorregiaoMesoUFRegID ;
      private bool[] T00043_n31MicrorregiaoMesoUFRegID ;
      private string[] T00043_A32MicrorregiaoMesoUFRegSigla ;
      private bool[] T00043_n32MicrorregiaoMesoUFRegSigla ;
      private string[] T00043_A33MicrorregiaoMesoUFRegNome ;
      private bool[] T00043_n33MicrorregiaoMesoUFRegNome ;
      private string[] T00043_A34MicrorregiaoMesoUFRegSiglaNome ;
      private bool[] T00043_n34MicrorregiaoMesoUFRegSiglaNome ;
      private int[] T000412_A23MicrorregiaoID ;
      private int[] T000413_A23MicrorregiaoID ;
      private int[] T00042_A23MicrorregiaoID ;
      private string[] T00042_A24MicrorregiaoNome ;
      private int[] T00042_A25MicrorregiaoMesoID ;
      private string[] T00042_A26MicrorregiaoMesoNome ;
      private int[] T00042_A27MicrorregiaoMesoUFID ;
      private string[] T00042_A28MicrorregiaoMesoUFSigla ;
      private bool[] T00042_n28MicrorregiaoMesoUFSigla ;
      private string[] T00042_A29MicrorregiaoMesoUFNome ;
      private bool[] T00042_n29MicrorregiaoMesoUFNome ;
      private string[] T00042_A30MicrorregiaoMesoUFSiglaNome ;
      private bool[] T00042_n30MicrorregiaoMesoUFSiglaNome ;
      private int[] T00042_A31MicrorregiaoMesoUFRegID ;
      private bool[] T00042_n31MicrorregiaoMesoUFRegID ;
      private string[] T00042_A32MicrorregiaoMesoUFRegSigla ;
      private bool[] T00042_n32MicrorregiaoMesoUFRegSigla ;
      private string[] T00042_A33MicrorregiaoMesoUFRegNome ;
      private bool[] T00042_n33MicrorregiaoMesoUFRegNome ;
      private string[] T00042_A34MicrorregiaoMesoUFRegSiglaNome ;
      private bool[] T00042_n34MicrorregiaoMesoUFRegSiglaNome ;
      private string[] T000417_A26MicrorregiaoMesoNome ;
      private int[] T000417_A27MicrorregiaoMesoUFID ;
      private string[] T000418_A28MicrorregiaoMesoUFSigla ;
      private bool[] T000418_n28MicrorregiaoMesoUFSigla ;
      private string[] T000418_A29MicrorregiaoMesoUFNome ;
      private bool[] T000418_n29MicrorregiaoMesoUFNome ;
      private int[] T000418_A31MicrorregiaoMesoUFRegID ;
      private bool[] T000418_n31MicrorregiaoMesoUFRegID ;
      private string[] T000419_A32MicrorregiaoMesoUFRegSigla ;
      private bool[] T000419_n32MicrorregiaoMesoUFRegSigla ;
      private string[] T000419_A33MicrorregiaoMesoUFRegNome ;
      private bool[] T000419_n33MicrorregiaoMesoUFRegNome ;
      private int[] T000420_A35MunicipioID ;
      private int[] T000421_A23MicrorregiaoID ;
      private IDataStoreProvider pr_gam ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV15MicrorregiaoMesoID_Data ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV23GAMErrors ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV14TrnContextAtt ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV16DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV22GAMSession ;
   }

   public class microrregiao__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class microrregiao__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[13])
       ,new UpdateCursor(def[14])
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
        Object[] prmT00047;
        prmT00047 = new Object[] {
        new ParDef("MicrorregiaoID",GXType.Int32,9,0)
        };
        Object[] prmT00044;
        prmT00044 = new Object[] {
        new ParDef("MicrorregiaoMesoID",GXType.Int32,9,0)
        };
        Object[] prmT00045;
        prmT00045 = new Object[] {
        new ParDef("MicrorregiaoMesoUFID",GXType.Int32,9,0)
        };
        Object[] prmT00046;
        prmT00046 = new Object[] {
        new ParDef("MicrorregiaoMesoUFRegID",GXType.Int32,9,0){Nullable=true}
        };
        Object[] prmT00048;
        prmT00048 = new Object[] {
        new ParDef("MicrorregiaoMesoID",GXType.Int32,9,0)
        };
        Object[] prmT00049;
        prmT00049 = new Object[] {
        new ParDef("MicrorregiaoMesoUFID",GXType.Int32,9,0)
        };
        Object[] prmT000410;
        prmT000410 = new Object[] {
        new ParDef("MicrorregiaoMesoUFRegID",GXType.Int32,9,0){Nullable=true}
        };
        Object[] prmT000411;
        prmT000411 = new Object[] {
        new ParDef("MicrorregiaoID",GXType.Int32,9,0)
        };
        Object[] prmT00043;
        prmT00043 = new Object[] {
        new ParDef("MicrorregiaoID",GXType.Int32,9,0)
        };
        Object[] prmT000412;
        prmT000412 = new Object[] {
        new ParDef("MicrorregiaoID",GXType.Int32,9,0)
        };
        Object[] prmT000413;
        prmT000413 = new Object[] {
        new ParDef("MicrorregiaoID",GXType.Int32,9,0)
        };
        Object[] prmT00042;
        prmT00042 = new Object[] {
        new ParDef("MicrorregiaoID",GXType.Int32,9,0)
        };
        Object[] prmT000414;
        prmT000414 = new Object[] {
        new ParDef("MicrorregiaoMesoNome",GXType.VarChar,80,0) ,
        new ParDef("MicrorregiaoMesoUFID",GXType.Int32,9,0) ,
        new ParDef("MicrorregiaoMesoUFSigla",GXType.VarChar,2,0){Nullable=true} ,
        new ParDef("MicrorregiaoMesoUFNome",GXType.VarChar,50,0){Nullable=true} ,
        new ParDef("MicrorregiaoMesoUFRegID",GXType.Int32,9,0){Nullable=true} ,
        new ParDef("MicrorregiaoMesoUFRegSigla",GXType.VarChar,10,0){Nullable=true} ,
        new ParDef("MicrorregiaoMesoUFRegNome",GXType.VarChar,50,0){Nullable=true} ,
        new ParDef("MicrorregiaoMesoUFSiglaNome",GXType.VarChar,70,0){Nullable=true} ,
        new ParDef("MicrorregiaoMesoUFRegSiglaNome",GXType.VarChar,70,0){Nullable=true} ,
        new ParDef("MicrorregiaoID",GXType.Int32,9,0) ,
        new ParDef("MicrorregiaoNome",GXType.VarChar,80,0) ,
        new ParDef("MicrorregiaoMesoID",GXType.Int32,9,0)
        };
        Object[] prmT000415;
        prmT000415 = new Object[] {
        new ParDef("MicrorregiaoMesoNome",GXType.VarChar,80,0) ,
        new ParDef("MicrorregiaoMesoUFID",GXType.Int32,9,0) ,
        new ParDef("MicrorregiaoMesoUFSigla",GXType.VarChar,2,0){Nullable=true} ,
        new ParDef("MicrorregiaoMesoUFNome",GXType.VarChar,50,0){Nullable=true} ,
        new ParDef("MicrorregiaoMesoUFRegID",GXType.Int32,9,0){Nullable=true} ,
        new ParDef("MicrorregiaoMesoUFRegSigla",GXType.VarChar,10,0){Nullable=true} ,
        new ParDef("MicrorregiaoMesoUFRegNome",GXType.VarChar,50,0){Nullable=true} ,
        new ParDef("MicrorregiaoMesoUFSiglaNome",GXType.VarChar,70,0){Nullable=true} ,
        new ParDef("MicrorregiaoMesoUFRegSiglaNome",GXType.VarChar,70,0){Nullable=true} ,
        new ParDef("MicrorregiaoNome",GXType.VarChar,80,0) ,
        new ParDef("MicrorregiaoMesoID",GXType.Int32,9,0) ,
        new ParDef("MicrorregiaoID",GXType.Int32,9,0)
        };
        Object[] prmT000416;
        prmT000416 = new Object[] {
        new ParDef("MicrorregiaoID",GXType.Int32,9,0)
        };
        Object[] prmT000420;
        prmT000420 = new Object[] {
        new ParDef("MicrorregiaoID",GXType.Int32,9,0)
        };
        Object[] prmT000421;
        prmT000421 = new Object[] {
        };
        Object[] prmT000417;
        prmT000417 = new Object[] {
        new ParDef("MicrorregiaoMesoID",GXType.Int32,9,0)
        };
        Object[] prmT000418;
        prmT000418 = new Object[] {
        new ParDef("MicrorregiaoMesoUFID",GXType.Int32,9,0)
        };
        Object[] prmT000419;
        prmT000419 = new Object[] {
        new ParDef("MicrorregiaoMesoUFRegID",GXType.Int32,9,0){Nullable=true}
        };
        def= new CursorDef[] {
            new CursorDef("T00042", "SELECT MicrorregiaoID, MicrorregiaoNome, MicrorregiaoMesoID, MicrorregiaoMesoNome, MicrorregiaoMesoUFID, MicrorregiaoMesoUFSigla, MicrorregiaoMesoUFNome, MicrorregiaoMesoUFSiglaNome, MicrorregiaoMesoUFRegID, MicrorregiaoMesoUFRegSigla, MicrorregiaoMesoUFRegNome, MicrorregiaoMesoUFRegSiglaNome FROM tbibge_microrregiao WHERE MicrorregiaoID = :MicrorregiaoID  FOR UPDATE OF tbibge_microrregiao NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT00042,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00043", "SELECT MicrorregiaoID, MicrorregiaoNome, MicrorregiaoMesoID, MicrorregiaoMesoNome, MicrorregiaoMesoUFID, MicrorregiaoMesoUFSigla, MicrorregiaoMesoUFNome, MicrorregiaoMesoUFSiglaNome, MicrorregiaoMesoUFRegID, MicrorregiaoMesoUFRegSigla, MicrorregiaoMesoUFRegNome, MicrorregiaoMesoUFRegSiglaNome FROM tbibge_microrregiao WHERE MicrorregiaoID = :MicrorregiaoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00043,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00044", "SELECT MesorregiaoNome AS MicrorregiaoMesoNome, MesorregiaoUFID AS MicrorregiaoMesoUFID FROM tbibge_mesorregiao WHERE MesorregiaoID = :MicrorregiaoMesoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00044,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00045", "SELECT UFSigla AS MicrorregiaoMesoUFSigla, UFNome AS MicrorregiaoMesoUFNome, UFRegID AS MicrorregiaoMesoUFRegID FROM tbibge_uf WHERE UFID = :MicrorregiaoMesoUFID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00045,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00046", "SELECT RegiaoSigla AS MicrorregiaoMesoUFRegSigla, RegiaoNome AS MicrorregiaoMesoUFRegNome FROM tbibge_regiao WHERE RegiaoID = :MicrorregiaoMesoUFRegID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00046,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00047", "SELECT TM1.MicrorregiaoMesoUFSiglaNome AS MicrorregiaoMesoUFSiglaNome, TM1.MicrorregiaoMesoUFRegSiglaNome AS MicrorregiaoMesoUFRegSiglaNome, TM1.MicrorregiaoID, TM1.MicrorregiaoNome, TM1.MicrorregiaoMesoNome AS MicrorregiaoMesoNome, TM1.MicrorregiaoMesoUFID AS MicrorregiaoMesoUFID, TM1.MicrorregiaoMesoUFSigla AS MicrorregiaoMesoUFSigla, TM1.MicrorregiaoMesoUFNome AS MicrorregiaoMesoUFNome, TM1.MicrorregiaoMesoUFRegID AS MicrorregiaoMesoUFRegID, TM1.MicrorregiaoMesoUFRegSigla AS MicrorregiaoMesoUFRegSigla, TM1.MicrorregiaoMesoUFRegNome AS MicrorregiaoMesoUFRegNome, TM1.MicrorregiaoMesoID AS MicrorregiaoMesoID FROM ((tbibge_microrregiao TM1 INNER JOIN tbibge_mesorregiao T2 ON T2.MesorregiaoID = TM1.MicrorregiaoMesoID) INNER JOIN tbibge_uf T3 ON T3.UFID = T2.MesorregiaoUFID) WHERE TM1.MicrorregiaoID = :MicrorregiaoID ORDER BY TM1.MicrorregiaoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00047,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00048", "SELECT MesorregiaoNome AS MicrorregiaoMesoNome, MesorregiaoUFID AS MicrorregiaoMesoUFID FROM tbibge_mesorregiao WHERE MesorregiaoID = :MicrorregiaoMesoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00048,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00049", "SELECT UFSigla AS MicrorregiaoMesoUFSigla, UFNome AS MicrorregiaoMesoUFNome, UFRegID AS MicrorregiaoMesoUFRegID FROM tbibge_uf WHERE UFID = :MicrorregiaoMesoUFID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00049,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000410", "SELECT RegiaoSigla AS MicrorregiaoMesoUFRegSigla, RegiaoNome AS MicrorregiaoMesoUFRegNome FROM tbibge_regiao WHERE RegiaoID = :MicrorregiaoMesoUFRegID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000410,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000411", "SELECT MicrorregiaoID FROM tbibge_microrregiao WHERE MicrorregiaoID = :MicrorregiaoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000411,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000412", "SELECT MicrorregiaoID FROM tbibge_microrregiao WHERE ( MicrorregiaoID > :MicrorregiaoID) ORDER BY MicrorregiaoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000412,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000413", "SELECT MicrorregiaoID FROM tbibge_microrregiao WHERE ( MicrorregiaoID < :MicrorregiaoID) ORDER BY MicrorregiaoID DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000413,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000414", "SAVEPOINT gxupdate;INSERT INTO tbibge_microrregiao(MicrorregiaoMesoNome, MicrorregiaoMesoUFID, MicrorregiaoMesoUFSigla, MicrorregiaoMesoUFNome, MicrorregiaoMesoUFRegID, MicrorregiaoMesoUFRegSigla, MicrorregiaoMesoUFRegNome, MicrorregiaoMesoUFSiglaNome, MicrorregiaoMesoUFRegSiglaNome, MicrorregiaoID, MicrorregiaoNome, MicrorregiaoMesoID) VALUES(:MicrorregiaoMesoNome, :MicrorregiaoMesoUFID, :MicrorregiaoMesoUFSigla, :MicrorregiaoMesoUFNome, :MicrorregiaoMesoUFRegID, :MicrorregiaoMesoUFRegSigla, :MicrorregiaoMesoUFRegNome, :MicrorregiaoMesoUFSiglaNome, :MicrorregiaoMesoUFRegSiglaNome, :MicrorregiaoID, :MicrorregiaoNome, :MicrorregiaoMesoID);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000414)
           ,new CursorDef("T000415", "SAVEPOINT gxupdate;UPDATE tbibge_microrregiao SET MicrorregiaoMesoNome=:MicrorregiaoMesoNome, MicrorregiaoMesoUFID=:MicrorregiaoMesoUFID, MicrorregiaoMesoUFSigla=:MicrorregiaoMesoUFSigla, MicrorregiaoMesoUFNome=:MicrorregiaoMesoUFNome, MicrorregiaoMesoUFRegID=:MicrorregiaoMesoUFRegID, MicrorregiaoMesoUFRegSigla=:MicrorregiaoMesoUFRegSigla, MicrorregiaoMesoUFRegNome=:MicrorregiaoMesoUFRegNome, MicrorregiaoMesoUFSiglaNome=:MicrorregiaoMesoUFSiglaNome, MicrorregiaoMesoUFRegSiglaNome=:MicrorregiaoMesoUFRegSiglaNome, MicrorregiaoNome=:MicrorregiaoNome, MicrorregiaoMesoID=:MicrorregiaoMesoID  WHERE MicrorregiaoID = :MicrorregiaoID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000415)
           ,new CursorDef("T000416", "SAVEPOINT gxupdate;DELETE FROM tbibge_microrregiao  WHERE MicrorregiaoID = :MicrorregiaoID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000416)
           ,new CursorDef("T000417", "SELECT MesorregiaoNome AS MicrorregiaoMesoNome, MesorregiaoUFID AS MicrorregiaoMesoUFID FROM tbibge_mesorregiao WHERE MesorregiaoID = :MicrorregiaoMesoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000417,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000418", "SELECT UFSigla AS MicrorregiaoMesoUFSigla, UFNome AS MicrorregiaoMesoUFNome, UFRegID AS MicrorregiaoMesoUFRegID FROM tbibge_uf WHERE UFID = :MicrorregiaoMesoUFID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000418,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000419", "SELECT RegiaoSigla AS MicrorregiaoMesoUFRegSigla, RegiaoNome AS MicrorregiaoMesoUFRegNome FROM tbibge_regiao WHERE RegiaoID = :MicrorregiaoMesoUFRegID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000419,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000420", "SELECT MunicipioID FROM tbibge_municipio WHERE MunicipioMicroID = :MicrorregiaoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000420,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000421", "SELECT MicrorregiaoID FROM tbibge_microrregiao ORDER BY MicrorregiaoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000421,100, GxCacheFrequency.OFF ,true,false )
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
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((int[]) buf[4])[0] = rslt.getInt(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              ((string[]) buf[7])[0] = rslt.getVarchar(7);
              ((bool[]) buf[8])[0] = rslt.wasNull(7);
              ((string[]) buf[9])[0] = rslt.getVarchar(8);
              ((bool[]) buf[10])[0] = rslt.wasNull(8);
              ((int[]) buf[11])[0] = rslt.getInt(9);
              ((bool[]) buf[12])[0] = rslt.wasNull(9);
              ((string[]) buf[13])[0] = rslt.getVarchar(10);
              ((bool[]) buf[14])[0] = rslt.wasNull(10);
              ((string[]) buf[15])[0] = rslt.getVarchar(11);
              ((bool[]) buf[16])[0] = rslt.wasNull(11);
              ((string[]) buf[17])[0] = rslt.getVarchar(12);
              ((bool[]) buf[18])[0] = rslt.wasNull(12);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((int[]) buf[4])[0] = rslt.getInt(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              ((string[]) buf[7])[0] = rslt.getVarchar(7);
              ((bool[]) buf[8])[0] = rslt.wasNull(7);
              ((string[]) buf[9])[0] = rslt.getVarchar(8);
              ((bool[]) buf[10])[0] = rslt.wasNull(8);
              ((int[]) buf[11])[0] = rslt.getInt(9);
              ((bool[]) buf[12])[0] = rslt.wasNull(9);
              ((string[]) buf[13])[0] = rslt.getVarchar(10);
              ((bool[]) buf[14])[0] = rslt.wasNull(10);
              ((string[]) buf[15])[0] = rslt.getVarchar(11);
              ((bool[]) buf[16])[0] = rslt.wasNull(11);
              ((string[]) buf[17])[0] = rslt.getVarchar(12);
              ((bool[]) buf[18])[0] = rslt.wasNull(12);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              ((string[]) buf[2])[0] = rslt.getVarchar(2);
              ((bool[]) buf[3])[0] = rslt.wasNull(2);
              ((int[]) buf[4])[0] = rslt.getInt(3);
              ((string[]) buf[5])[0] = rslt.getVarchar(4);
              ((string[]) buf[6])[0] = rslt.getVarchar(5);
              ((int[]) buf[7])[0] = rslt.getInt(6);
              ((string[]) buf[8])[0] = rslt.getVarchar(7);
              ((bool[]) buf[9])[0] = rslt.wasNull(7);
              ((string[]) buf[10])[0] = rslt.getVarchar(8);
              ((bool[]) buf[11])[0] = rslt.wasNull(8);
              ((int[]) buf[12])[0] = rslt.getInt(9);
              ((bool[]) buf[13])[0] = rslt.wasNull(9);
              ((string[]) buf[14])[0] = rslt.getVarchar(10);
              ((bool[]) buf[15])[0] = rslt.wasNull(10);
              ((string[]) buf[16])[0] = rslt.getVarchar(11);
              ((bool[]) buf[17])[0] = rslt.wasNull(11);
              ((int[]) buf[18])[0] = rslt.getInt(12);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 9 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 10 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 11 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 16 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 17 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 18 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 19 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
