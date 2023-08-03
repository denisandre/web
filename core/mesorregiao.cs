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
   public class mesorregiao : GXDataArea
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
            A15MesorregiaoUFID = (int)(Math.Round(NumberUtil.Val( GetPar( "MesorregiaoUFID"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A15MesorregiaoUFID", StringUtil.LTrimStr( (decimal)(A15MesorregiaoUFID), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_12( A15MesorregiaoUFID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_13") == 0 )
         {
            A19MesorregiaoUFRegID = (int)(Math.Round(NumberUtil.Val( GetPar( "MesorregiaoUFRegID"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A19MesorregiaoUFRegID", StringUtil.LTrimStr( (decimal)(A19MesorregiaoUFRegID), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_13( A19MesorregiaoUFRegID) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "core.mesorregiao.aspx")), "core.mesorregiao.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "core.mesorregiao.aspx")))) ;
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
                  AV7MesorregiaoID = (int)(Math.Round(NumberUtil.Val( GetPar( "MesorregiaoID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7MesorregiaoID", StringUtil.LTrimStr( (decimal)(AV7MesorregiaoID), 9, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vMESORREGIAOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7MesorregiaoID), "ZZZ,ZZZ,ZZ9"), context));
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
            Form.Meta.addItem("description", "Mesorregião", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtMesorregiaoID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public mesorregiao( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public mesorregiao( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_MesorregiaoID )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7MesorregiaoID = aP1_MesorregiaoID;
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
            return "mesorregiao_Execute" ;
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMesorregiaoID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMesorregiaoID_Internalname, "ID", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMesorregiaoID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A13MesorregiaoID), 11, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A13MesorregiaoID), "ZZZ,ZZZ,ZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMesorregiaoID_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtMesorregiaoID_Enabled, 1, "text", "", 11, "chr", 1, "row", 11, 0, 0, 0, 0, -1, 0, true, "core\\ID", "end", false, "", "HLP_core\\mesorregiao.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMesorregiaoNome_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMesorregiaoNome_Internalname, "Nome", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMesorregiaoNome_Internalname, A14MesorregiaoNome, StringUtil.RTrim( context.localUtil.Format( A14MesorregiaoNome, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMesorregiaoNome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtMesorregiaoNome_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\mesorregiao.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedmesorregiaoufid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockmesorregiaoufid_Internalname, "Unidade Federativa (Estado)", "", "", lblTextblockmesorregiaoufid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_core\\mesorregiao.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_mesorregiaoufid.SetProperty("Caption", Combo_mesorregiaoufid_Caption);
         ucCombo_mesorregiaoufid.SetProperty("Cls", Combo_mesorregiaoufid_Cls);
         ucCombo_mesorregiaoufid.SetProperty("DataListProc", Combo_mesorregiaoufid_Datalistproc);
         ucCombo_mesorregiaoufid.SetProperty("DataListProcParametersPrefix", Combo_mesorregiaoufid_Datalistprocparametersprefix);
         ucCombo_mesorregiaoufid.SetProperty("EmptyItem", Combo_mesorregiaoufid_Emptyitem);
         ucCombo_mesorregiaoufid.SetProperty("DropDownOptionsTitleSettingsIcons", AV16DDO_TitleSettingsIcons);
         ucCombo_mesorregiaoufid.SetProperty("DropDownOptionsData", AV15MesorregiaoUFID_Data);
         ucCombo_mesorregiaoufid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_mesorregiaoufid_Internalname, "COMBO_MESORREGIAOUFIDContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMesorregiaoUFID_Internalname, "UF", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMesorregiaoUFID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A15MesorregiaoUFID), 11, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A15MesorregiaoUFID), "ZZZ,ZZZ,ZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMesorregiaoUFID_Jsonclick, 0, "Attribute", "", "", "", "", edtMesorregiaoUFID_Visible, edtMesorregiaoUFID_Enabled, 1, "text", "", 11, "chr", 1, "row", 11, 0, 0, 0, 0, -1, 0, true, "core\\ID", "end", false, "", "HLP_core\\mesorregiao.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\mesorregiao.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\mesorregiao.htm");
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
         GxWebStd.gx_div_start( context, divSectionattribute_mesorregiaoufid_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtavCombomesorregiaoufid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20ComboMesorregiaoUFID), 11, 0, ",", "")), StringUtil.LTrim( ((edtavCombomesorregiaoufid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV20ComboMesorregiaoUFID), "ZZZ,ZZZ,ZZ9") : context.localUtil.Format( (decimal)(AV20ComboMesorregiaoUFID), "ZZZ,ZZZ,ZZ9"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombomesorregiaoufid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombomesorregiaoufid_Visible, edtavCombomesorregiaoufid_Enabled, 0, "text", "", 11, "chr", 1, "row", 11, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_core\\mesorregiao.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtMesorregiaoUFNome_Internalname, A17MesorregiaoUFNome, StringUtil.RTrim( context.localUtil.Format( A17MesorregiaoUFNome, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMesorregiaoUFNome_Jsonclick, 0, "Attribute", "", "", "", "", edtMesorregiaoUFNome_Visible, edtMesorregiaoUFNome_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\mesorregiao.htm");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtMesorregiaoUFSiglaNome_Internalname, A18MesorregiaoUFSiglaNome, StringUtil.RTrim( context.localUtil.Format( A18MesorregiaoUFSiglaNome, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMesorregiaoUFSiglaNome_Jsonclick, 0, "Attribute", "", "", "", "", edtMesorregiaoUFSiglaNome_Visible, edtMesorregiaoUFSiglaNome_Enabled, 0, "text", "", 70, "chr", 1, "row", 70, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\mesorregiao.htm");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtMesorregiaoUFRegID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A19MesorregiaoUFRegID), 11, 0, ",", "")), StringUtil.LTrim( ((edtMesorregiaoUFRegID_Enabled!=0) ? context.localUtil.Format( (decimal)(A19MesorregiaoUFRegID), "ZZZ,ZZZ,ZZ9") : context.localUtil.Format( (decimal)(A19MesorregiaoUFRegID), "ZZZ,ZZZ,ZZ9"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMesorregiaoUFRegID_Jsonclick, 0, "Attribute", "", "", "", "", edtMesorregiaoUFRegID_Visible, edtMesorregiaoUFRegID_Enabled, 0, "text", "", 11, "chr", 1, "row", 11, 0, 0, 0, 0, -1, 0, true, "core\\ID", "end", false, "", "HLP_core\\mesorregiao.htm");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtMesorregiaoUFRegSigla_Internalname, A20MesorregiaoUFRegSigla, StringUtil.RTrim( context.localUtil.Format( A20MesorregiaoUFRegSigla, "@!")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMesorregiaoUFRegSigla_Jsonclick, 0, "Attribute", "", "", "", "", edtMesorregiaoUFRegSigla_Visible, edtMesorregiaoUFRegSigla_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\mesorregiao.htm");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtMesorregiaoUFRegNome_Internalname, A21MesorregiaoUFRegNome, StringUtil.RTrim( context.localUtil.Format( A21MesorregiaoUFRegNome, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMesorregiaoUFRegNome_Jsonclick, 0, "Attribute", "", "", "", "", edtMesorregiaoUFRegNome_Visible, edtMesorregiaoUFRegNome_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\mesorregiao.htm");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtMesorregiaoUFRegSiglaNome_Internalname, A22MesorregiaoUFRegSiglaNome, StringUtil.RTrim( context.localUtil.Format( A22MesorregiaoUFRegSiglaNome, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMesorregiaoUFRegSiglaNome_Jsonclick, 0, "Attribute", "", "", "", "", edtMesorregiaoUFRegSiglaNome_Visible, edtMesorregiaoUFRegSiglaNome_Enabled, 0, "text", "", 70, "chr", 1, "row", 70, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\mesorregiao.htm");
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
         E11032 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV16DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( "vMESORREGIAOUFID_DATA"), AV15MesorregiaoUFID_Data);
               /* Read saved values. */
               Z13MesorregiaoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z13MesorregiaoID"), ",", "."), 18, MidpointRounding.ToEven));
               Z18MesorregiaoUFSiglaNome = cgiGet( "Z18MesorregiaoUFSiglaNome");
               n18MesorregiaoUFSiglaNome = (String.IsNullOrEmpty(StringUtil.RTrim( A18MesorregiaoUFSiglaNome)) ? true : false);
               Z22MesorregiaoUFRegSiglaNome = cgiGet( "Z22MesorregiaoUFRegSiglaNome");
               n22MesorregiaoUFRegSiglaNome = (String.IsNullOrEmpty(StringUtil.RTrim( A22MesorregiaoUFRegSiglaNome)) ? true : false);
               Z14MesorregiaoNome = cgiGet( "Z14MesorregiaoNome");
               Z15MesorregiaoUFID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z15MesorregiaoUFID"), ",", "."), 18, MidpointRounding.ToEven));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N15MesorregiaoUFID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N15MesorregiaoUFID"), ",", "."), 18, MidpointRounding.ToEven));
               A16MesorregiaoUFSigla = cgiGet( "MESORREGIAOUFSIGLA");
               AV7MesorregiaoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vMESORREGIAOID"), ",", "."), 18, MidpointRounding.ToEven));
               AV13Insert_MesorregiaoUFID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_MESORREGIAOUFID"), ",", "."), 18, MidpointRounding.ToEven));
               AV25Pgmname = cgiGet( "vPGMNAME");
               Combo_mesorregiaoufid_Objectcall = cgiGet( "COMBO_MESORREGIAOUFID_Objectcall");
               Combo_mesorregiaoufid_Class = cgiGet( "COMBO_MESORREGIAOUFID_Class");
               Combo_mesorregiaoufid_Icontype = cgiGet( "COMBO_MESORREGIAOUFID_Icontype");
               Combo_mesorregiaoufid_Icon = cgiGet( "COMBO_MESORREGIAOUFID_Icon");
               Combo_mesorregiaoufid_Caption = cgiGet( "COMBO_MESORREGIAOUFID_Caption");
               Combo_mesorregiaoufid_Tooltip = cgiGet( "COMBO_MESORREGIAOUFID_Tooltip");
               Combo_mesorregiaoufid_Cls = cgiGet( "COMBO_MESORREGIAOUFID_Cls");
               Combo_mesorregiaoufid_Selectedvalue_set = cgiGet( "COMBO_MESORREGIAOUFID_Selectedvalue_set");
               Combo_mesorregiaoufid_Selectedvalue_get = cgiGet( "COMBO_MESORREGIAOUFID_Selectedvalue_get");
               Combo_mesorregiaoufid_Selectedtext_set = cgiGet( "COMBO_MESORREGIAOUFID_Selectedtext_set");
               Combo_mesorregiaoufid_Selectedtext_get = cgiGet( "COMBO_MESORREGIAOUFID_Selectedtext_get");
               Combo_mesorregiaoufid_Gamoauthtoken = cgiGet( "COMBO_MESORREGIAOUFID_Gamoauthtoken");
               Combo_mesorregiaoufid_Ddointernalname = cgiGet( "COMBO_MESORREGIAOUFID_Ddointernalname");
               Combo_mesorregiaoufid_Titlecontrolalign = cgiGet( "COMBO_MESORREGIAOUFID_Titlecontrolalign");
               Combo_mesorregiaoufid_Dropdownoptionstype = cgiGet( "COMBO_MESORREGIAOUFID_Dropdownoptionstype");
               Combo_mesorregiaoufid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_MESORREGIAOUFID_Enabled"));
               Combo_mesorregiaoufid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_MESORREGIAOUFID_Visible"));
               Combo_mesorregiaoufid_Titlecontrolidtoreplace = cgiGet( "COMBO_MESORREGIAOUFID_Titlecontrolidtoreplace");
               Combo_mesorregiaoufid_Datalisttype = cgiGet( "COMBO_MESORREGIAOUFID_Datalisttype");
               Combo_mesorregiaoufid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_MESORREGIAOUFID_Allowmultipleselection"));
               Combo_mesorregiaoufid_Datalistfixedvalues = cgiGet( "COMBO_MESORREGIAOUFID_Datalistfixedvalues");
               Combo_mesorregiaoufid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_MESORREGIAOUFID_Isgriditem"));
               Combo_mesorregiaoufid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_MESORREGIAOUFID_Hasdescription"));
               Combo_mesorregiaoufid_Datalistproc = cgiGet( "COMBO_MESORREGIAOUFID_Datalistproc");
               Combo_mesorregiaoufid_Datalistprocparametersprefix = cgiGet( "COMBO_MESORREGIAOUFID_Datalistprocparametersprefix");
               Combo_mesorregiaoufid_Remoteservicesparameters = cgiGet( "COMBO_MESORREGIAOUFID_Remoteservicesparameters");
               Combo_mesorregiaoufid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_MESORREGIAOUFID_Datalistupdateminimumcharacters"), ",", "."), 18, MidpointRounding.ToEven));
               Combo_mesorregiaoufid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_MESORREGIAOUFID_Includeonlyselectedoption"));
               Combo_mesorregiaoufid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_MESORREGIAOUFID_Includeselectalloption"));
               Combo_mesorregiaoufid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_MESORREGIAOUFID_Emptyitem"));
               Combo_mesorregiaoufid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_MESORREGIAOUFID_Includeaddnewoption"));
               Combo_mesorregiaoufid_Htmltemplate = cgiGet( "COMBO_MESORREGIAOUFID_Htmltemplate");
               Combo_mesorregiaoufid_Multiplevaluestype = cgiGet( "COMBO_MESORREGIAOUFID_Multiplevaluestype");
               Combo_mesorregiaoufid_Loadingdata = cgiGet( "COMBO_MESORREGIAOUFID_Loadingdata");
               Combo_mesorregiaoufid_Noresultsfound = cgiGet( "COMBO_MESORREGIAOUFID_Noresultsfound");
               Combo_mesorregiaoufid_Emptyitemtext = cgiGet( "COMBO_MESORREGIAOUFID_Emptyitemtext");
               Combo_mesorregiaoufid_Onlyselectedvalues = cgiGet( "COMBO_MESORREGIAOUFID_Onlyselectedvalues");
               Combo_mesorregiaoufid_Selectalltext = cgiGet( "COMBO_MESORREGIAOUFID_Selectalltext");
               Combo_mesorregiaoufid_Multiplevaluesseparator = cgiGet( "COMBO_MESORREGIAOUFID_Multiplevaluesseparator");
               Combo_mesorregiaoufid_Addnewoptiontext = cgiGet( "COMBO_MESORREGIAOUFID_Addnewoptiontext");
               Combo_mesorregiaoufid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_MESORREGIAOUFID_Gxcontroltype"), ",", "."), 18, MidpointRounding.ToEven));
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
               if ( ( ( context.localUtil.CToN( cgiGet( edtMesorregiaoID_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMesorregiaoID_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MESORREGIAOID");
                  AnyError = 1;
                  GX_FocusControl = edtMesorregiaoID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A13MesorregiaoID = 0;
                  AssignAttri("", false, "A13MesorregiaoID", StringUtil.LTrimStr( (decimal)(A13MesorregiaoID), 9, 0));
               }
               else
               {
                  A13MesorregiaoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtMesorregiaoID_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A13MesorregiaoID", StringUtil.LTrimStr( (decimal)(A13MesorregiaoID), 9, 0));
               }
               A14MesorregiaoNome = cgiGet( edtMesorregiaoNome_Internalname);
               AssignAttri("", false, "A14MesorregiaoNome", A14MesorregiaoNome);
               if ( ( ( context.localUtil.CToN( cgiGet( edtMesorregiaoUFID_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMesorregiaoUFID_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MESORREGIAOUFID");
                  AnyError = 1;
                  GX_FocusControl = edtMesorregiaoUFID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A15MesorregiaoUFID = 0;
                  AssignAttri("", false, "A15MesorregiaoUFID", StringUtil.LTrimStr( (decimal)(A15MesorregiaoUFID), 9, 0));
               }
               else
               {
                  A15MesorregiaoUFID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtMesorregiaoUFID_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A15MesorregiaoUFID", StringUtil.LTrimStr( (decimal)(A15MesorregiaoUFID), 9, 0));
               }
               AV20ComboMesorregiaoUFID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavCombomesorregiaoufid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV20ComboMesorregiaoUFID", StringUtil.LTrimStr( (decimal)(AV20ComboMesorregiaoUFID), 9, 0));
               A17MesorregiaoUFNome = cgiGet( edtMesorregiaoUFNome_Internalname);
               AssignAttri("", false, "A17MesorregiaoUFNome", A17MesorregiaoUFNome);
               A18MesorregiaoUFSiglaNome = cgiGet( edtMesorregiaoUFSiglaNome_Internalname);
               n18MesorregiaoUFSiglaNome = false;
               AssignAttri("", false, "A18MesorregiaoUFSiglaNome", A18MesorregiaoUFSiglaNome);
               A19MesorregiaoUFRegID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtMesorregiaoUFRegID_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A19MesorregiaoUFRegID", StringUtil.LTrimStr( (decimal)(A19MesorregiaoUFRegID), 9, 0));
               A20MesorregiaoUFRegSigla = StringUtil.Upper( cgiGet( edtMesorregiaoUFRegSigla_Internalname));
               n20MesorregiaoUFRegSigla = false;
               AssignAttri("", false, "A20MesorregiaoUFRegSigla", A20MesorregiaoUFRegSigla);
               A21MesorregiaoUFRegNome = cgiGet( edtMesorregiaoUFRegNome_Internalname);
               n21MesorregiaoUFRegNome = false;
               AssignAttri("", false, "A21MesorregiaoUFRegNome", A21MesorregiaoUFRegNome);
               A22MesorregiaoUFRegSiglaNome = cgiGet( edtMesorregiaoUFRegSiglaNome_Internalname);
               n22MesorregiaoUFRegSiglaNome = false;
               AssignAttri("", false, "A22MesorregiaoUFRegSiglaNome", A22MesorregiaoUFRegSiglaNome);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"mesorregiao");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A13MesorregiaoID != Z13MesorregiaoID ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("core\\mesorregiao:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A13MesorregiaoID = (int)(Math.Round(NumberUtil.Val( GetPar( "MesorregiaoID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A13MesorregiaoID", StringUtil.LTrimStr( (decimal)(A13MesorregiaoID), 9, 0));
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
                     sMode3 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode3;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound3 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_030( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "MESORREGIAOID");
                        AnyError = 1;
                        GX_FocusControl = edtMesorregiaoID_Internalname;
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
                           E11032 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12032 ();
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
            E12032 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll033( ) ;
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
            DisableAttributes033( ) ;
         }
         AssignProp("", false, edtavCombomesorregiaoufid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombomesorregiaoufid_Enabled), 5, 0), true);
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

      protected void CONFIRM_030( )
      {
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls033( ) ;
            }
            else
            {
               CheckExtendedTable033( ) ;
               CloseExtendedTableCursors033( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption030( )
      {
      }

      protected void E11032( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV16DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV16DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         AV22GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV23GAMErrors);
         Combo_mesorregiaoufid_Gamoauthtoken = AV22GAMSession.gxTpr_Token;
         ucCombo_mesorregiaoufid.SendProperty(context, "", false, Combo_mesorregiaoufid_Internalname, "GAMOAuthToken", Combo_mesorregiaoufid_Gamoauthtoken);
         edtMesorregiaoUFID_Visible = 0;
         AssignProp("", false, edtMesorregiaoUFID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMesorregiaoUFID_Visible), 5, 0), true);
         AV20ComboMesorregiaoUFID = 0;
         AssignAttri("", false, "AV20ComboMesorregiaoUFID", StringUtil.LTrimStr( (decimal)(AV20ComboMesorregiaoUFID), 9, 0));
         edtavCombomesorregiaoufid_Visible = 0;
         AssignProp("", false, edtavCombomesorregiaoufid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombomesorregiaoufid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOMESORREGIAOUFID' */
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
               if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "MesorregiaoUFID") == 0 )
               {
                  AV13Insert_MesorregiaoUFID = (int)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV13Insert_MesorregiaoUFID", StringUtil.LTrimStr( (decimal)(AV13Insert_MesorregiaoUFID), 9, 0));
                  if ( ! (0==AV13Insert_MesorregiaoUFID) )
                  {
                     AV20ComboMesorregiaoUFID = AV13Insert_MesorregiaoUFID;
                     AssignAttri("", false, "AV20ComboMesorregiaoUFID", StringUtil.LTrimStr( (decimal)(AV20ComboMesorregiaoUFID), 9, 0));
                     Combo_mesorregiaoufid_Selectedvalue_set = StringUtil.Trim( StringUtil.Str( (decimal)(AV20ComboMesorregiaoUFID), 9, 0));
                     ucCombo_mesorregiaoufid.SendProperty(context, "", false, Combo_mesorregiaoufid_Internalname, "SelectedValue_set", Combo_mesorregiaoufid_Selectedvalue_set);
                     GXt_char2 = AV19Combo_DataJson;
                     new GeneXus.Programs.core.mesorregiaoloaddvcombo(context ).execute(  "MesorregiaoUFID",  "GET",  false,  AV7MesorregiaoID,  AV14TrnContextAtt.gxTpr_Attributevalue, out  AV17ComboSelectedValue, out  AV18ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV17ComboSelectedValue", AV17ComboSelectedValue);
                     AssignAttri("", false, "AV18ComboSelectedText", AV18ComboSelectedText);
                     AV19Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV19Combo_DataJson", AV19Combo_DataJson);
                     Combo_mesorregiaoufid_Selectedtext_set = AV18ComboSelectedText;
                     ucCombo_mesorregiaoufid.SendProperty(context, "", false, Combo_mesorregiaoufid_Internalname, "SelectedText_set", Combo_mesorregiaoufid_Selectedtext_set);
                     Combo_mesorregiaoufid_Enabled = false;
                     ucCombo_mesorregiaoufid.SendProperty(context, "", false, Combo_mesorregiaoufid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_mesorregiaoufid_Enabled));
                  }
               }
               AV26GXV1 = (int)(AV26GXV1+1);
               AssignAttri("", false, "AV26GXV1", StringUtil.LTrimStr( (decimal)(AV26GXV1), 8, 0));
            }
         }
         edtMesorregiaoUFNome_Visible = 0;
         AssignProp("", false, edtMesorregiaoUFNome_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMesorregiaoUFNome_Visible), 5, 0), true);
         edtMesorregiaoUFSiglaNome_Visible = 0;
         AssignProp("", false, edtMesorregiaoUFSiglaNome_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMesorregiaoUFSiglaNome_Visible), 5, 0), true);
         edtMesorregiaoUFRegID_Visible = 0;
         AssignProp("", false, edtMesorregiaoUFRegID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMesorregiaoUFRegID_Visible), 5, 0), true);
         edtMesorregiaoUFRegSigla_Visible = 0;
         AssignProp("", false, edtMesorregiaoUFRegSigla_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMesorregiaoUFRegSigla_Visible), 5, 0), true);
         edtMesorregiaoUFRegNome_Visible = 0;
         AssignProp("", false, edtMesorregiaoUFRegNome_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMesorregiaoUFRegNome_Visible), 5, 0), true);
         edtMesorregiaoUFRegSiglaNome_Visible = 0;
         AssignProp("", false, edtMesorregiaoUFRegSiglaNome_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMesorregiaoUFRegSiglaNome_Visible), 5, 0), true);
      }

      protected void E12032( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("core.mesorregiaoww.aspx") );
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
         /* 'LOADCOMBOMESORREGIAOUFID' Routine */
         returnInSub = false;
         GXt_char2 = AV19Combo_DataJson;
         new GeneXus.Programs.core.mesorregiaoloaddvcombo(context ).execute(  "MesorregiaoUFID",  Gx_mode,  false,  AV7MesorregiaoID,  "", out  AV17ComboSelectedValue, out  AV18ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV17ComboSelectedValue", AV17ComboSelectedValue);
         AssignAttri("", false, "AV18ComboSelectedText", AV18ComboSelectedText);
         AV19Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV19Combo_DataJson", AV19Combo_DataJson);
         Combo_mesorregiaoufid_Selectedvalue_set = AV17ComboSelectedValue;
         ucCombo_mesorregiaoufid.SendProperty(context, "", false, Combo_mesorregiaoufid_Internalname, "SelectedValue_set", Combo_mesorregiaoufid_Selectedvalue_set);
         Combo_mesorregiaoufid_Selectedtext_set = AV18ComboSelectedText;
         ucCombo_mesorregiaoufid.SendProperty(context, "", false, Combo_mesorregiaoufid_Internalname, "SelectedText_set", Combo_mesorregiaoufid_Selectedtext_set);
         AV20ComboMesorregiaoUFID = (int)(Math.Round(NumberUtil.Val( AV17ComboSelectedValue, "."), 18, MidpointRounding.ToEven));
         AssignAttri("", false, "AV20ComboMesorregiaoUFID", StringUtil.LTrimStr( (decimal)(AV20ComboMesorregiaoUFID), 9, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_mesorregiaoufid_Enabled = false;
            ucCombo_mesorregiaoufid.SendProperty(context, "", false, Combo_mesorregiaoufid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_mesorregiaoufid_Enabled));
         }
      }

      protected void ZM033( short GX_JID )
      {
         if ( ( GX_JID == 11 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z18MesorregiaoUFSiglaNome = T00033_A18MesorregiaoUFSiglaNome[0];
               Z22MesorregiaoUFRegSiglaNome = T00033_A22MesorregiaoUFRegSiglaNome[0];
               Z14MesorregiaoNome = T00033_A14MesorregiaoNome[0];
               Z15MesorregiaoUFID = T00033_A15MesorregiaoUFID[0];
            }
            else
            {
               Z18MesorregiaoUFSiglaNome = A18MesorregiaoUFSiglaNome;
               Z22MesorregiaoUFRegSiglaNome = A22MesorregiaoUFRegSiglaNome;
               Z14MesorregiaoNome = A14MesorregiaoNome;
               Z15MesorregiaoUFID = A15MesorregiaoUFID;
            }
         }
         if ( GX_JID == -11 )
         {
            Z18MesorregiaoUFSiglaNome = A18MesorregiaoUFSiglaNome;
            Z22MesorregiaoUFRegSiglaNome = A22MesorregiaoUFRegSiglaNome;
            Z13MesorregiaoID = A13MesorregiaoID;
            Z14MesorregiaoNome = A14MesorregiaoNome;
            Z16MesorregiaoUFSigla = A16MesorregiaoUFSigla;
            Z17MesorregiaoUFNome = A17MesorregiaoUFNome;
            Z19MesorregiaoUFRegID = A19MesorregiaoUFRegID;
            Z20MesorregiaoUFRegSigla = A20MesorregiaoUFRegSigla;
            Z21MesorregiaoUFRegNome = A21MesorregiaoUFRegNome;
            Z15MesorregiaoUFID = A15MesorregiaoUFID;
         }
      }

      protected void standaloneNotModal( )
      {
         AV25Pgmname = "core.mesorregiao";
         AssignAttri("", false, "AV25Pgmname", AV25Pgmname);
         if ( ! (0==AV7MesorregiaoID) )
         {
            A13MesorregiaoID = AV7MesorregiaoID;
            AssignAttri("", false, "A13MesorregiaoID", StringUtil.LTrimStr( (decimal)(A13MesorregiaoID), 9, 0));
         }
         if ( ! (0==AV7MesorregiaoID) )
         {
            edtMesorregiaoID_Enabled = 0;
            AssignProp("", false, edtMesorregiaoID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMesorregiaoID_Enabled), 5, 0), true);
         }
         else
         {
            edtMesorregiaoID_Enabled = 1;
            AssignProp("", false, edtMesorregiaoID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMesorregiaoID_Enabled), 5, 0), true);
         }
         if ( ! (0==AV7MesorregiaoID) )
         {
            edtMesorregiaoID_Enabled = 0;
            AssignProp("", false, edtMesorregiaoID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMesorregiaoID_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_MesorregiaoUFID) )
         {
            edtMesorregiaoUFID_Enabled = 0;
            AssignProp("", false, edtMesorregiaoUFID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMesorregiaoUFID_Enabled), 5, 0), true);
         }
         else
         {
            edtMesorregiaoUFID_Enabled = 1;
            AssignProp("", false, edtMesorregiaoUFID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMesorregiaoUFID_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_MesorregiaoUFID) )
         {
            A15MesorregiaoUFID = AV13Insert_MesorregiaoUFID;
            AssignAttri("", false, "A15MesorregiaoUFID", StringUtil.LTrimStr( (decimal)(A15MesorregiaoUFID), 9, 0));
         }
         else
         {
            A15MesorregiaoUFID = AV20ComboMesorregiaoUFID;
            AssignAttri("", false, "A15MesorregiaoUFID", StringUtil.LTrimStr( (decimal)(A15MesorregiaoUFID), 9, 0));
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
            /* Using cursor T00034 */
            pr_default.execute(2, new Object[] {A15MesorregiaoUFID});
            A16MesorregiaoUFSigla = T00034_A16MesorregiaoUFSigla[0];
            A17MesorregiaoUFNome = T00034_A17MesorregiaoUFNome[0];
            AssignAttri("", false, "A17MesorregiaoUFNome", A17MesorregiaoUFNome);
            A19MesorregiaoUFRegID = T00034_A19MesorregiaoUFRegID[0];
            AssignAttri("", false, "A19MesorregiaoUFRegID", StringUtil.LTrimStr( (decimal)(A19MesorregiaoUFRegID), 9, 0));
            pr_default.close(2);
            A18MesorregiaoUFSiglaNome = StringUtil.Trim( A16MesorregiaoUFSigla) + " - " + StringUtil.Trim( A17MesorregiaoUFNome);
            n18MesorregiaoUFSiglaNome = false;
            AssignAttri("", false, "A18MesorregiaoUFSiglaNome", A18MesorregiaoUFSiglaNome);
            /* Using cursor T00035 */
            pr_default.execute(3, new Object[] {A19MesorregiaoUFRegID});
            A20MesorregiaoUFRegSigla = T00035_A20MesorregiaoUFRegSigla[0];
            n20MesorregiaoUFRegSigla = T00035_n20MesorregiaoUFRegSigla[0];
            AssignAttri("", false, "A20MesorregiaoUFRegSigla", A20MesorregiaoUFRegSigla);
            A21MesorregiaoUFRegNome = T00035_A21MesorregiaoUFRegNome[0];
            n21MesorregiaoUFRegNome = T00035_n21MesorregiaoUFRegNome[0];
            AssignAttri("", false, "A21MesorregiaoUFRegNome", A21MesorregiaoUFRegNome);
            pr_default.close(3);
            A22MesorregiaoUFRegSiglaNome = StringUtil.Trim( A20MesorregiaoUFRegSigla) + " - " + StringUtil.Trim( A21MesorregiaoUFRegNome);
            n22MesorregiaoUFRegSiglaNome = false;
            AssignAttri("", false, "A22MesorregiaoUFRegSiglaNome", A22MesorregiaoUFRegSiglaNome);
         }
      }

      protected void Load033( )
      {
         /* Using cursor T00036 */
         pr_default.execute(4, new Object[] {A13MesorregiaoID});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound3 = 1;
            A18MesorregiaoUFSiglaNome = T00036_A18MesorregiaoUFSiglaNome[0];
            n18MesorregiaoUFSiglaNome = T00036_n18MesorregiaoUFSiglaNome[0];
            AssignAttri("", false, "A18MesorregiaoUFSiglaNome", A18MesorregiaoUFSiglaNome);
            A22MesorregiaoUFRegSiglaNome = T00036_A22MesorregiaoUFRegSiglaNome[0];
            n22MesorregiaoUFRegSiglaNome = T00036_n22MesorregiaoUFRegSiglaNome[0];
            AssignAttri("", false, "A22MesorregiaoUFRegSiglaNome", A22MesorregiaoUFRegSiglaNome);
            A14MesorregiaoNome = T00036_A14MesorregiaoNome[0];
            AssignAttri("", false, "A14MesorregiaoNome", A14MesorregiaoNome);
            A16MesorregiaoUFSigla = T00036_A16MesorregiaoUFSigla[0];
            A17MesorregiaoUFNome = T00036_A17MesorregiaoUFNome[0];
            AssignAttri("", false, "A17MesorregiaoUFNome", A17MesorregiaoUFNome);
            A19MesorregiaoUFRegID = T00036_A19MesorregiaoUFRegID[0];
            AssignAttri("", false, "A19MesorregiaoUFRegID", StringUtil.LTrimStr( (decimal)(A19MesorregiaoUFRegID), 9, 0));
            A20MesorregiaoUFRegSigla = T00036_A20MesorregiaoUFRegSigla[0];
            n20MesorregiaoUFRegSigla = T00036_n20MesorregiaoUFRegSigla[0];
            AssignAttri("", false, "A20MesorregiaoUFRegSigla", A20MesorregiaoUFRegSigla);
            A21MesorregiaoUFRegNome = T00036_A21MesorregiaoUFRegNome[0];
            n21MesorregiaoUFRegNome = T00036_n21MesorregiaoUFRegNome[0];
            AssignAttri("", false, "A21MesorregiaoUFRegNome", A21MesorregiaoUFRegNome);
            A15MesorregiaoUFID = T00036_A15MesorregiaoUFID[0];
            AssignAttri("", false, "A15MesorregiaoUFID", StringUtil.LTrimStr( (decimal)(A15MesorregiaoUFID), 9, 0));
            ZM033( -11) ;
         }
         pr_default.close(4);
         OnLoadActions033( ) ;
      }

      protected void OnLoadActions033( )
      {
         A18MesorregiaoUFSiglaNome = StringUtil.Trim( A16MesorregiaoUFSigla) + " - " + StringUtil.Trim( A17MesorregiaoUFNome);
         n18MesorregiaoUFSiglaNome = false;
         AssignAttri("", false, "A18MesorregiaoUFSiglaNome", A18MesorregiaoUFSiglaNome);
         /* Using cursor T00035 */
         pr_default.execute(3, new Object[] {A19MesorregiaoUFRegID});
         A20MesorregiaoUFRegSigla = T00035_A20MesorregiaoUFRegSigla[0];
         n20MesorregiaoUFRegSigla = T00035_n20MesorregiaoUFRegSigla[0];
         AssignAttri("", false, "A20MesorregiaoUFRegSigla", A20MesorregiaoUFRegSigla);
         A21MesorregiaoUFRegNome = T00035_A21MesorregiaoUFRegNome[0];
         n21MesorregiaoUFRegNome = T00035_n21MesorregiaoUFRegNome[0];
         AssignAttri("", false, "A21MesorregiaoUFRegNome", A21MesorregiaoUFRegNome);
         pr_default.close(3);
         A22MesorregiaoUFRegSiglaNome = StringUtil.Trim( A20MesorregiaoUFRegSigla) + " - " + StringUtil.Trim( A21MesorregiaoUFRegNome);
         n22MesorregiaoUFRegSiglaNome = false;
         AssignAttri("", false, "A22MesorregiaoUFRegSiglaNome", A22MesorregiaoUFRegSiglaNome);
      }

      protected void CheckExtendedTable033( )
      {
         nIsDirty_3 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T00034 */
         pr_default.execute(2, new Object[] {A15MesorregiaoUFID});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("Não existe 'Group UF -> Mesoregião'.", "ForeignKeyNotFound", 1, "MESORREGIAOUFID");
            AnyError = 1;
            GX_FocusControl = edtMesorregiaoUFID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A16MesorregiaoUFSigla = T00034_A16MesorregiaoUFSigla[0];
         A17MesorregiaoUFNome = T00034_A17MesorregiaoUFNome[0];
         AssignAttri("", false, "A17MesorregiaoUFNome", A17MesorregiaoUFNome);
         A19MesorregiaoUFRegID = T00034_A19MesorregiaoUFRegID[0];
         AssignAttri("", false, "A19MesorregiaoUFRegID", StringUtil.LTrimStr( (decimal)(A19MesorregiaoUFRegID), 9, 0));
         pr_default.close(2);
         nIsDirty_3 = 1;
         A18MesorregiaoUFSiglaNome = StringUtil.Trim( A16MesorregiaoUFSigla) + " - " + StringUtil.Trim( A17MesorregiaoUFNome);
         n18MesorregiaoUFSiglaNome = false;
         AssignAttri("", false, "A18MesorregiaoUFSiglaNome", A18MesorregiaoUFSiglaNome);
         /* Using cursor T00035 */
         pr_default.execute(3, new Object[] {A19MesorregiaoUFRegID});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("Não existe 'Região'.", "ForeignKeyNotFound", 1, "MESORREGIAOUFREGID");
            AnyError = 1;
         }
         A20MesorregiaoUFRegSigla = T00035_A20MesorregiaoUFRegSigla[0];
         n20MesorregiaoUFRegSigla = T00035_n20MesorregiaoUFRegSigla[0];
         AssignAttri("", false, "A20MesorregiaoUFRegSigla", A20MesorregiaoUFRegSigla);
         A21MesorregiaoUFRegNome = T00035_A21MesorregiaoUFRegNome[0];
         n21MesorregiaoUFRegNome = T00035_n21MesorregiaoUFRegNome[0];
         AssignAttri("", false, "A21MesorregiaoUFRegNome", A21MesorregiaoUFRegNome);
         pr_default.close(3);
         nIsDirty_3 = 1;
         A22MesorregiaoUFRegSiglaNome = StringUtil.Trim( A20MesorregiaoUFRegSigla) + " - " + StringUtil.Trim( A21MesorregiaoUFRegNome);
         n22MesorregiaoUFRegSiglaNome = false;
         AssignAttri("", false, "A22MesorregiaoUFRegSiglaNome", A22MesorregiaoUFRegSiglaNome);
      }

      protected void CloseExtendedTableCursors033( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_12( int A15MesorregiaoUFID )
      {
         /* Using cursor T00037 */
         pr_default.execute(5, new Object[] {A15MesorregiaoUFID});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("Não existe 'Group UF -> Mesoregião'.", "ForeignKeyNotFound", 1, "MESORREGIAOUFID");
            AnyError = 1;
            GX_FocusControl = edtMesorregiaoUFID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A16MesorregiaoUFSigla = T00037_A16MesorregiaoUFSigla[0];
         A17MesorregiaoUFNome = T00037_A17MesorregiaoUFNome[0];
         AssignAttri("", false, "A17MesorregiaoUFNome", A17MesorregiaoUFNome);
         A19MesorregiaoUFRegID = T00037_A19MesorregiaoUFRegID[0];
         AssignAttri("", false, "A19MesorregiaoUFRegID", StringUtil.LTrimStr( (decimal)(A19MesorregiaoUFRegID), 9, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A16MesorregiaoUFSigla)+"\""+","+"\""+GXUtil.EncodeJSConstant( A17MesorregiaoUFNome)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A19MesorregiaoUFRegID), 9, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void gxLoad_13( int A19MesorregiaoUFRegID )
      {
         /* Using cursor T00038 */
         pr_default.execute(6, new Object[] {A19MesorregiaoUFRegID});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("Não existe 'Região'.", "ForeignKeyNotFound", 1, "MESORREGIAOUFREGID");
            AnyError = 1;
         }
         A20MesorregiaoUFRegSigla = T00038_A20MesorregiaoUFRegSigla[0];
         n20MesorregiaoUFRegSigla = T00038_n20MesorregiaoUFRegSigla[0];
         AssignAttri("", false, "A20MesorregiaoUFRegSigla", A20MesorregiaoUFRegSigla);
         A21MesorregiaoUFRegNome = T00038_A21MesorregiaoUFRegNome[0];
         n21MesorregiaoUFRegNome = T00038_n21MesorregiaoUFRegNome[0];
         AssignAttri("", false, "A21MesorregiaoUFRegNome", A21MesorregiaoUFRegNome);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A20MesorregiaoUFRegSigla)+"\""+","+"\""+GXUtil.EncodeJSConstant( A21MesorregiaoUFRegNome)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void GetKey033( )
      {
         /* Using cursor T00039 */
         pr_default.execute(7, new Object[] {A13MesorregiaoID});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound3 = 1;
         }
         else
         {
            RcdFound3 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00033 */
         pr_default.execute(1, new Object[] {A13MesorregiaoID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM033( 11) ;
            RcdFound3 = 1;
            A13MesorregiaoID = T00033_A13MesorregiaoID[0];
            AssignAttri("", false, "A13MesorregiaoID", StringUtil.LTrimStr( (decimal)(A13MesorregiaoID), 9, 0));
            A14MesorregiaoNome = T00033_A14MesorregiaoNome[0];
            AssignAttri("", false, "A14MesorregiaoNome", A14MesorregiaoNome);
            A15MesorregiaoUFID = T00033_A15MesorregiaoUFID[0];
            AssignAttri("", false, "A15MesorregiaoUFID", StringUtil.LTrimStr( (decimal)(A15MesorregiaoUFID), 9, 0));
            A18MesorregiaoUFSiglaNome = T00033_A18MesorregiaoUFSiglaNome[0];
            n18MesorregiaoUFSiglaNome = T00033_n18MesorregiaoUFSiglaNome[0];
            AssignAttri("", false, "A18MesorregiaoUFSiglaNome", A18MesorregiaoUFSiglaNome);
            A22MesorregiaoUFRegSiglaNome = T00033_A22MesorregiaoUFRegSiglaNome[0];
            n22MesorregiaoUFRegSiglaNome = T00033_n22MesorregiaoUFRegSiglaNome[0];
            AssignAttri("", false, "A22MesorregiaoUFRegSiglaNome", A22MesorregiaoUFRegSiglaNome);
            Z13MesorregiaoID = A13MesorregiaoID;
            sMode3 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load033( ) ;
            if ( AnyError == 1 )
            {
               RcdFound3 = 0;
               InitializeNonKey033( ) ;
            }
            Gx_mode = sMode3;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound3 = 0;
            InitializeNonKey033( ) ;
            sMode3 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode3;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey033( ) ;
         if ( RcdFound3 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound3 = 0;
         /* Using cursor T000310 */
         pr_default.execute(8, new Object[] {A13MesorregiaoID});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T000310_A13MesorregiaoID[0] < A13MesorregiaoID ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T000310_A13MesorregiaoID[0] > A13MesorregiaoID ) ) )
            {
               A13MesorregiaoID = T000310_A13MesorregiaoID[0];
               AssignAttri("", false, "A13MesorregiaoID", StringUtil.LTrimStr( (decimal)(A13MesorregiaoID), 9, 0));
               RcdFound3 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound3 = 0;
         /* Using cursor T000311 */
         pr_default.execute(9, new Object[] {A13MesorregiaoID});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T000311_A13MesorregiaoID[0] > A13MesorregiaoID ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T000311_A13MesorregiaoID[0] < A13MesorregiaoID ) ) )
            {
               A13MesorregiaoID = T000311_A13MesorregiaoID[0];
               AssignAttri("", false, "A13MesorregiaoID", StringUtil.LTrimStr( (decimal)(A13MesorregiaoID), 9, 0));
               RcdFound3 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey033( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtMesorregiaoID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert033( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound3 == 1 )
            {
               if ( A13MesorregiaoID != Z13MesorregiaoID )
               {
                  A13MesorregiaoID = Z13MesorregiaoID;
                  AssignAttri("", false, "A13MesorregiaoID", StringUtil.LTrimStr( (decimal)(A13MesorregiaoID), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "MESORREGIAOID");
                  AnyError = 1;
                  GX_FocusControl = edtMesorregiaoID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtMesorregiaoID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update033( ) ;
                  GX_FocusControl = edtMesorregiaoID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A13MesorregiaoID != Z13MesorregiaoID )
               {
                  /* Insert record */
                  GX_FocusControl = edtMesorregiaoID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert033( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "MESORREGIAOID");
                     AnyError = 1;
                     GX_FocusControl = edtMesorregiaoID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtMesorregiaoID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert033( ) ;
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
         if ( A13MesorregiaoID != Z13MesorregiaoID )
         {
            A13MesorregiaoID = Z13MesorregiaoID;
            AssignAttri("", false, "A13MesorregiaoID", StringUtil.LTrimStr( (decimal)(A13MesorregiaoID), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "MESORREGIAOID");
            AnyError = 1;
            GX_FocusControl = edtMesorregiaoID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtMesorregiaoID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency033( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00032 */
            pr_default.execute(0, new Object[] {A13MesorregiaoID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tbibge_mesorregiao"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z18MesorregiaoUFSiglaNome, T00032_A18MesorregiaoUFSiglaNome[0]) != 0 ) || ( StringUtil.StrCmp(Z22MesorregiaoUFRegSiglaNome, T00032_A22MesorregiaoUFRegSiglaNome[0]) != 0 ) || ( StringUtil.StrCmp(Z14MesorregiaoNome, T00032_A14MesorregiaoNome[0]) != 0 ) || ( Z15MesorregiaoUFID != T00032_A15MesorregiaoUFID[0] ) )
            {
               if ( StringUtil.StrCmp(Z18MesorregiaoUFSiglaNome, T00032_A18MesorregiaoUFSiglaNome[0]) != 0 )
               {
                  GXUtil.WriteLog("core.mesorregiao:[seudo value changed for attri]"+"MesorregiaoUFSiglaNome");
                  GXUtil.WriteLogRaw("Old: ",Z18MesorregiaoUFSiglaNome);
                  GXUtil.WriteLogRaw("Current: ",T00032_A18MesorregiaoUFSiglaNome[0]);
               }
               if ( StringUtil.StrCmp(Z22MesorregiaoUFRegSiglaNome, T00032_A22MesorregiaoUFRegSiglaNome[0]) != 0 )
               {
                  GXUtil.WriteLog("core.mesorregiao:[seudo value changed for attri]"+"MesorregiaoUFRegSiglaNome");
                  GXUtil.WriteLogRaw("Old: ",Z22MesorregiaoUFRegSiglaNome);
                  GXUtil.WriteLogRaw("Current: ",T00032_A22MesorregiaoUFRegSiglaNome[0]);
               }
               if ( StringUtil.StrCmp(Z14MesorregiaoNome, T00032_A14MesorregiaoNome[0]) != 0 )
               {
                  GXUtil.WriteLog("core.mesorregiao:[seudo value changed for attri]"+"MesorregiaoNome");
                  GXUtil.WriteLogRaw("Old: ",Z14MesorregiaoNome);
                  GXUtil.WriteLogRaw("Current: ",T00032_A14MesorregiaoNome[0]);
               }
               if ( Z15MesorregiaoUFID != T00032_A15MesorregiaoUFID[0] )
               {
                  GXUtil.WriteLog("core.mesorregiao:[seudo value changed for attri]"+"MesorregiaoUFID");
                  GXUtil.WriteLogRaw("Old: ",Z15MesorregiaoUFID);
                  GXUtil.WriteLogRaw("Current: ",T00032_A15MesorregiaoUFID[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"tbibge_mesorregiao"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert033( )
      {
         if ( ! IsAuthorized("mesorregiao_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable033( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM033( 0) ;
            CheckOptimisticConcurrency033( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm033( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert033( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000312 */
                     pr_default.execute(10, new Object[] {A16MesorregiaoUFSigla, A17MesorregiaoUFNome, A19MesorregiaoUFRegID, n20MesorregiaoUFRegSigla, A20MesorregiaoUFRegSigla, n21MesorregiaoUFRegNome, A21MesorregiaoUFRegNome, n18MesorregiaoUFSiglaNome, A18MesorregiaoUFSiglaNome, n22MesorregiaoUFRegSiglaNome, A22MesorregiaoUFRegSiglaNome, A13MesorregiaoID, A14MesorregiaoNome, A15MesorregiaoUFID});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("tbibge_mesorregiao");
                     if ( (pr_default.getStatus(10) == 1) )
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
                           ResetCaption030( ) ;
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
               Load033( ) ;
            }
            EndLevel033( ) ;
         }
         CloseExtendedTableCursors033( ) ;
      }

      protected void Update033( )
      {
         if ( ! IsAuthorized("mesorregiao_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable033( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency033( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm033( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate033( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000313 */
                     pr_default.execute(11, new Object[] {A16MesorregiaoUFSigla, A17MesorregiaoUFNome, A19MesorregiaoUFRegID, n20MesorregiaoUFRegSigla, A20MesorregiaoUFRegSigla, n21MesorregiaoUFRegNome, A21MesorregiaoUFRegNome, n18MesorregiaoUFSiglaNome, A18MesorregiaoUFSiglaNome, n22MesorregiaoUFRegSiglaNome, A22MesorregiaoUFRegSiglaNome, A14MesorregiaoNome, A15MesorregiaoUFID, A13MesorregiaoID});
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("tbibge_mesorregiao");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tbibge_mesorregiao"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate033( ) ;
                     if ( AnyError == 0 )
                     {
                        /* API remote call */
                        new tbibge_mesorregiaoupdateredundancy(context ).execute( ref  A13MesorregiaoID) ;
                        AssignAttri("", false, "A13MesorregiaoID", StringUtil.LTrimStr( (decimal)(A13MesorregiaoID), 9, 0));
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
            EndLevel033( ) ;
         }
         CloseExtendedTableCursors033( ) ;
      }

      protected void DeferredUpdate033( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("mesorregiao_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency033( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls033( ) ;
            AfterConfirm033( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete033( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000314 */
                  pr_default.execute(12, new Object[] {A13MesorregiaoID});
                  pr_default.close(12);
                  pr_default.SmartCacheProvider.SetUpdated("tbibge_mesorregiao");
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
         sMode3 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel033( ) ;
         Gx_mode = sMode3;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls033( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000315 */
            pr_default.execute(13, new Object[] {A15MesorregiaoUFID});
            A16MesorregiaoUFSigla = T000315_A16MesorregiaoUFSigla[0];
            A17MesorregiaoUFNome = T000315_A17MesorregiaoUFNome[0];
            AssignAttri("", false, "A17MesorregiaoUFNome", A17MesorregiaoUFNome);
            A19MesorregiaoUFRegID = T000315_A19MesorregiaoUFRegID[0];
            AssignAttri("", false, "A19MesorregiaoUFRegID", StringUtil.LTrimStr( (decimal)(A19MesorregiaoUFRegID), 9, 0));
            pr_default.close(13);
            /* Using cursor T000316 */
            pr_default.execute(14, new Object[] {A19MesorregiaoUFRegID});
            A20MesorregiaoUFRegSigla = T000316_A20MesorregiaoUFRegSigla[0];
            n20MesorregiaoUFRegSigla = T000316_n20MesorregiaoUFRegSigla[0];
            AssignAttri("", false, "A20MesorregiaoUFRegSigla", A20MesorregiaoUFRegSigla);
            A21MesorregiaoUFRegNome = T000316_A21MesorregiaoUFRegNome[0];
            n21MesorregiaoUFRegNome = T000316_n21MesorregiaoUFRegNome[0];
            AssignAttri("", false, "A21MesorregiaoUFRegNome", A21MesorregiaoUFRegNome);
            pr_default.close(14);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000317 */
            pr_default.execute(15, new Object[] {A13MesorregiaoID});
            if ( (pr_default.getStatus(15) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Microrregião"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(15);
         }
      }

      protected void EndLevel033( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete033( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("core.mesorregiao",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues030( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("core.mesorregiao",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart033( )
      {
         /* Scan By routine */
         /* Using cursor T000318 */
         pr_default.execute(16);
         RcdFound3 = 0;
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound3 = 1;
            A13MesorregiaoID = T000318_A13MesorregiaoID[0];
            AssignAttri("", false, "A13MesorregiaoID", StringUtil.LTrimStr( (decimal)(A13MesorregiaoID), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext033( )
      {
         /* Scan next routine */
         pr_default.readNext(16);
         RcdFound3 = 0;
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound3 = 1;
            A13MesorregiaoID = T000318_A13MesorregiaoID[0];
            AssignAttri("", false, "A13MesorregiaoID", StringUtil.LTrimStr( (decimal)(A13MesorregiaoID), 9, 0));
         }
      }

      protected void ScanEnd033( )
      {
         pr_default.close(16);
      }

      protected void AfterConfirm033( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert033( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate033( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete033( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete033( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate033( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes033( )
      {
         edtMesorregiaoID_Enabled = 0;
         AssignProp("", false, edtMesorregiaoID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMesorregiaoID_Enabled), 5, 0), true);
         edtMesorregiaoNome_Enabled = 0;
         AssignProp("", false, edtMesorregiaoNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMesorregiaoNome_Enabled), 5, 0), true);
         edtMesorregiaoUFID_Enabled = 0;
         AssignProp("", false, edtMesorregiaoUFID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMesorregiaoUFID_Enabled), 5, 0), true);
         edtavCombomesorregiaoufid_Enabled = 0;
         AssignProp("", false, edtavCombomesorregiaoufid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombomesorregiaoufid_Enabled), 5, 0), true);
         edtMesorregiaoUFNome_Enabled = 0;
         AssignProp("", false, edtMesorregiaoUFNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMesorregiaoUFNome_Enabled), 5, 0), true);
         edtMesorregiaoUFSiglaNome_Enabled = 0;
         AssignProp("", false, edtMesorregiaoUFSiglaNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMesorregiaoUFSiglaNome_Enabled), 5, 0), true);
         edtMesorregiaoUFRegID_Enabled = 0;
         AssignProp("", false, edtMesorregiaoUFRegID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMesorregiaoUFRegID_Enabled), 5, 0), true);
         edtMesorregiaoUFRegSigla_Enabled = 0;
         AssignProp("", false, edtMesorregiaoUFRegSigla_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMesorregiaoUFRegSigla_Enabled), 5, 0), true);
         edtMesorregiaoUFRegNome_Enabled = 0;
         AssignProp("", false, edtMesorregiaoUFRegNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMesorregiaoUFRegNome_Enabled), 5, 0), true);
         edtMesorregiaoUFRegSiglaNome_Enabled = 0;
         AssignProp("", false, edtMesorregiaoUFRegSiglaNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMesorregiaoUFRegSiglaNome_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes033( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues030( )
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
         GXEncryptionTmp = "core.mesorregiao.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7MesorregiaoID,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("core.mesorregiao.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"mesorregiao");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("core\\mesorregiao:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z13MesorregiaoID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z13MesorregiaoID), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z18MesorregiaoUFSiglaNome", Z18MesorregiaoUFSiglaNome);
         GxWebStd.gx_hidden_field( context, "Z22MesorregiaoUFRegSiglaNome", Z22MesorregiaoUFRegSiglaNome);
         GxWebStd.gx_hidden_field( context, "Z14MesorregiaoNome", Z14MesorregiaoNome);
         GxWebStd.gx_hidden_field( context, "Z15MesorregiaoUFID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z15MesorregiaoUFID), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N15MesorregiaoUFID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A15MesorregiaoUFID), 9, 0, ",", "")));
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMESORREGIAOUFID_DATA", AV15MesorregiaoUFID_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMESORREGIAOUFID_DATA", AV15MesorregiaoUFID_Data);
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
         GxWebStd.gx_hidden_field( context, "MESORREGIAOUFSIGLA", A16MesorregiaoUFSigla);
         GxWebStd.gx_hidden_field( context, "vMESORREGIAOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7MesorregiaoID), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vMESORREGIAOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7MesorregiaoID), "ZZZ,ZZZ,ZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_MESORREGIAOUFID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13Insert_MesorregiaoUFID), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV25Pgmname));
         GxWebStd.gx_hidden_field( context, "COMBO_MESORREGIAOUFID_Objectcall", StringUtil.RTrim( Combo_mesorregiaoufid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_MESORREGIAOUFID_Cls", StringUtil.RTrim( Combo_mesorregiaoufid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_MESORREGIAOUFID_Selectedvalue_set", StringUtil.RTrim( Combo_mesorregiaoufid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_MESORREGIAOUFID_Selectedtext_set", StringUtil.RTrim( Combo_mesorregiaoufid_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_MESORREGIAOUFID_Gamoauthtoken", StringUtil.RTrim( Combo_mesorregiaoufid_Gamoauthtoken));
         GxWebStd.gx_hidden_field( context, "COMBO_MESORREGIAOUFID_Enabled", StringUtil.BoolToStr( Combo_mesorregiaoufid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_MESORREGIAOUFID_Datalistproc", StringUtil.RTrim( Combo_mesorregiaoufid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_MESORREGIAOUFID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_mesorregiaoufid_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_MESORREGIAOUFID_Emptyitem", StringUtil.BoolToStr( Combo_mesorregiaoufid_Emptyitem));
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
         GXEncryptionTmp = "core.mesorregiao.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7MesorregiaoID,9,0));
         return formatLink("core.mesorregiao.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "core.mesorregiao" ;
      }

      public override string GetPgmdesc( )
      {
         return "Mesorregião" ;
      }

      protected void InitializeNonKey033( )
      {
         A15MesorregiaoUFID = 0;
         AssignAttri("", false, "A15MesorregiaoUFID", StringUtil.LTrimStr( (decimal)(A15MesorregiaoUFID), 9, 0));
         A14MesorregiaoNome = "";
         AssignAttri("", false, "A14MesorregiaoNome", A14MesorregiaoNome);
         A16MesorregiaoUFSigla = "";
         AssignAttri("", false, "A16MesorregiaoUFSigla", A16MesorregiaoUFSigla);
         A17MesorregiaoUFNome = "";
         AssignAttri("", false, "A17MesorregiaoUFNome", A17MesorregiaoUFNome);
         A18MesorregiaoUFSiglaNome = "";
         n18MesorregiaoUFSiglaNome = false;
         AssignAttri("", false, "A18MesorregiaoUFSiglaNome", A18MesorregiaoUFSiglaNome);
         n18MesorregiaoUFSiglaNome = (String.IsNullOrEmpty(StringUtil.RTrim( A18MesorregiaoUFSiglaNome)) ? true : false);
         A19MesorregiaoUFRegID = 0;
         AssignAttri("", false, "A19MesorregiaoUFRegID", StringUtil.LTrimStr( (decimal)(A19MesorregiaoUFRegID), 9, 0));
         A20MesorregiaoUFRegSigla = "";
         n20MesorregiaoUFRegSigla = false;
         AssignAttri("", false, "A20MesorregiaoUFRegSigla", A20MesorregiaoUFRegSigla);
         A21MesorregiaoUFRegNome = "";
         n21MesorregiaoUFRegNome = false;
         AssignAttri("", false, "A21MesorregiaoUFRegNome", A21MesorregiaoUFRegNome);
         A22MesorregiaoUFRegSiglaNome = "";
         n22MesorregiaoUFRegSiglaNome = false;
         AssignAttri("", false, "A22MesorregiaoUFRegSiglaNome", A22MesorregiaoUFRegSiglaNome);
         n22MesorregiaoUFRegSiglaNome = (String.IsNullOrEmpty(StringUtil.RTrim( A22MesorregiaoUFRegSiglaNome)) ? true : false);
         Z18MesorregiaoUFSiglaNome = "";
         Z22MesorregiaoUFRegSiglaNome = "";
         Z14MesorregiaoNome = "";
         Z15MesorregiaoUFID = 0;
      }

      protected void InitAll033( )
      {
         A13MesorregiaoID = 0;
         AssignAttri("", false, "A13MesorregiaoID", StringUtil.LTrimStr( (decimal)(A13MesorregiaoID), 9, 0));
         InitializeNonKey033( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2023828111646", true, true);
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
         context.AddJavascriptSource("core/mesorregiao.js", "?2023828111649", false, true);
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
         edtMesorregiaoID_Internalname = "MESORREGIAOID";
         edtMesorregiaoNome_Internalname = "MESORREGIAONOME";
         lblTextblockmesorregiaoufid_Internalname = "TEXTBLOCKMESORREGIAOUFID";
         Combo_mesorregiaoufid_Internalname = "COMBO_MESORREGIAOUFID";
         edtMesorregiaoUFID_Internalname = "MESORREGIAOUFID";
         divTablesplittedmesorregiaoufid_Internalname = "TABLESPLITTEDMESORREGIAOUFID";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         divTablemain_Internalname = "TABLEMAIN";
         edtavCombomesorregiaoufid_Internalname = "vCOMBOMESORREGIAOUFID";
         divSectionattribute_mesorregiaoufid_Internalname = "SECTIONATTRIBUTE_MESORREGIAOUFID";
         edtMesorregiaoUFNome_Internalname = "MESORREGIAOUFNOME";
         edtMesorregiaoUFSiglaNome_Internalname = "MESORREGIAOUFSIGLANOME";
         edtMesorregiaoUFRegID_Internalname = "MESORREGIAOUFREGID";
         edtMesorregiaoUFRegSigla_Internalname = "MESORREGIAOUFREGSIGLA";
         edtMesorregiaoUFRegNome_Internalname = "MESORREGIAOUFREGNOME";
         edtMesorregiaoUFRegSiglaNome_Internalname = "MESORREGIAOUFREGSIGLANOME";
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
         Form.Caption = "Mesorregião";
         edtMesorregiaoUFRegSiglaNome_Jsonclick = "";
         edtMesorregiaoUFRegSiglaNome_Enabled = 0;
         edtMesorregiaoUFRegSiglaNome_Visible = 1;
         edtMesorregiaoUFRegNome_Jsonclick = "";
         edtMesorregiaoUFRegNome_Enabled = 0;
         edtMesorregiaoUFRegNome_Visible = 1;
         edtMesorregiaoUFRegSigla_Jsonclick = "";
         edtMesorregiaoUFRegSigla_Enabled = 0;
         edtMesorregiaoUFRegSigla_Visible = 1;
         edtMesorregiaoUFRegID_Jsonclick = "";
         edtMesorregiaoUFRegID_Enabled = 0;
         edtMesorregiaoUFRegID_Visible = 1;
         edtMesorregiaoUFSiglaNome_Jsonclick = "";
         edtMesorregiaoUFSiglaNome_Enabled = 0;
         edtMesorregiaoUFSiglaNome_Visible = 1;
         edtMesorregiaoUFNome_Jsonclick = "";
         edtMesorregiaoUFNome_Enabled = 0;
         edtMesorregiaoUFNome_Visible = 1;
         edtavCombomesorregiaoufid_Jsonclick = "";
         edtavCombomesorregiaoufid_Enabled = 0;
         edtavCombomesorregiaoufid_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtMesorregiaoUFID_Jsonclick = "";
         edtMesorregiaoUFID_Enabled = 1;
         edtMesorregiaoUFID_Visible = 1;
         Combo_mesorregiaoufid_Emptyitem = Convert.ToBoolean( 0);
         Combo_mesorregiaoufid_Datalistprocparametersprefix = " \"ComboName\": \"MesorregiaoUFID\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"MesorregiaoID\": 0";
         Combo_mesorregiaoufid_Datalistproc = "core.mesorregiaoLoadDVCombo";
         Combo_mesorregiaoufid_Cls = "ExtendedCombo AttributeFL";
         Combo_mesorregiaoufid_Caption = "";
         Combo_mesorregiaoufid_Enabled = Convert.ToBoolean( -1);
         edtMesorregiaoNome_Jsonclick = "";
         edtMesorregiaoNome_Enabled = 1;
         edtMesorregiaoID_Jsonclick = "";
         edtMesorregiaoID_Enabled = 1;
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

      public void Valid_Mesorregiaoufid( )
      {
         n20MesorregiaoUFRegSigla = false;
         n21MesorregiaoUFRegNome = false;
         n18MesorregiaoUFSiglaNome = false;
         n22MesorregiaoUFRegSiglaNome = false;
         /* Using cursor T000315 */
         pr_default.execute(13, new Object[] {A15MesorregiaoUFID});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("Não existe 'Group UF -> Mesoregião'.", "ForeignKeyNotFound", 1, "MESORREGIAOUFID");
            AnyError = 1;
            GX_FocusControl = edtMesorregiaoUFID_Internalname;
         }
         A16MesorregiaoUFSigla = T000315_A16MesorregiaoUFSigla[0];
         A17MesorregiaoUFNome = T000315_A17MesorregiaoUFNome[0];
         A19MesorregiaoUFRegID = T000315_A19MesorregiaoUFRegID[0];
         pr_default.close(13);
         A18MesorregiaoUFSiglaNome = StringUtil.Trim( A16MesorregiaoUFSigla) + " - " + StringUtil.Trim( A17MesorregiaoUFNome);
         n18MesorregiaoUFSiglaNome = false;
         /* Using cursor T000316 */
         pr_default.execute(14, new Object[] {A19MesorregiaoUFRegID});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("Não existe 'Região'.", "ForeignKeyNotFound", 1, "MESORREGIAOUFREGID");
            AnyError = 1;
         }
         A20MesorregiaoUFRegSigla = T000316_A20MesorregiaoUFRegSigla[0];
         n20MesorregiaoUFRegSigla = T000316_n20MesorregiaoUFRegSigla[0];
         A21MesorregiaoUFRegNome = T000316_A21MesorregiaoUFRegNome[0];
         n21MesorregiaoUFRegNome = T000316_n21MesorregiaoUFRegNome[0];
         pr_default.close(14);
         A22MesorregiaoUFRegSiglaNome = StringUtil.Trim( A20MesorregiaoUFRegSigla) + " - " + StringUtil.Trim( A21MesorregiaoUFRegNome);
         n22MesorregiaoUFRegSiglaNome = false;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A16MesorregiaoUFSigla", A16MesorregiaoUFSigla);
         AssignAttri("", false, "A17MesorregiaoUFNome", A17MesorregiaoUFNome);
         AssignAttri("", false, "A19MesorregiaoUFRegID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A19MesorregiaoUFRegID), 9, 0, ".", "")));
         AssignAttri("", false, "A18MesorregiaoUFSiglaNome", A18MesorregiaoUFSiglaNome);
         AssignAttri("", false, "A20MesorregiaoUFRegSigla", A20MesorregiaoUFRegSigla);
         AssignAttri("", false, "A21MesorregiaoUFRegNome", A21MesorregiaoUFRegNome);
         AssignAttri("", false, "A22MesorregiaoUFRegSiglaNome", A22MesorregiaoUFRegSiglaNome);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7MesorregiaoID',fld:'vMESORREGIAOID',pic:'ZZZ,ZZZ,ZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7MesorregiaoID',fld:'vMESORREGIAOID',pic:'ZZZ,ZZZ,ZZ9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E12032',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_MESORREGIAOID","{handler:'Valid_Mesorregiaoid',iparms:[]");
         setEventMetadata("VALID_MESORREGIAOID",",oparms:[]}");
         setEventMetadata("VALID_MESORREGIAOUFID","{handler:'Valid_Mesorregiaoufid',iparms:[{av:'A15MesorregiaoUFID',fld:'MESORREGIAOUFID',pic:'ZZZ,ZZZ,ZZ9'},{av:'A16MesorregiaoUFSigla',fld:'MESORREGIAOUFSIGLA',pic:'@!'},{av:'A17MesorregiaoUFNome',fld:'MESORREGIAOUFNOME',pic:''},{av:'A19MesorregiaoUFRegID',fld:'MESORREGIAOUFREGID',pic:'ZZZ,ZZZ,ZZ9'},{av:'A20MesorregiaoUFRegSigla',fld:'MESORREGIAOUFREGSIGLA',pic:'@!'},{av:'A21MesorregiaoUFRegNome',fld:'MESORREGIAOUFREGNOME',pic:''},{av:'A18MesorregiaoUFSiglaNome',fld:'MESORREGIAOUFSIGLANOME',pic:''},{av:'A22MesorregiaoUFRegSiglaNome',fld:'MESORREGIAOUFREGSIGLANOME',pic:''}]");
         setEventMetadata("VALID_MESORREGIAOUFID",",oparms:[{av:'A16MesorregiaoUFSigla',fld:'MESORREGIAOUFSIGLA',pic:'@!'},{av:'A17MesorregiaoUFNome',fld:'MESORREGIAOUFNOME',pic:''},{av:'A19MesorregiaoUFRegID',fld:'MESORREGIAOUFREGID',pic:'ZZZ,ZZZ,ZZ9'},{av:'A18MesorregiaoUFSiglaNome',fld:'MESORREGIAOUFSIGLANOME',pic:''},{av:'A20MesorregiaoUFRegSigla',fld:'MESORREGIAOUFREGSIGLA',pic:'@!'},{av:'A21MesorregiaoUFRegNome',fld:'MESORREGIAOUFREGNOME',pic:''},{av:'A22MesorregiaoUFRegSiglaNome',fld:'MESORREGIAOUFREGSIGLANOME',pic:''}]}");
         setEventMetadata("VALIDV_COMBOMESORREGIAOUFID","{handler:'Validv_Combomesorregiaoufid',iparms:[]");
         setEventMetadata("VALIDV_COMBOMESORREGIAOUFID",",oparms:[]}");
         setEventMetadata("VALID_MESORREGIAOUFNOME","{handler:'Valid_Mesorregiaoufnome',iparms:[]");
         setEventMetadata("VALID_MESORREGIAOUFNOME",",oparms:[]}");
         setEventMetadata("VALID_MESORREGIAOUFREGID","{handler:'Valid_Mesorregiaoufregid',iparms:[]");
         setEventMetadata("VALID_MESORREGIAOUFREGID",",oparms:[]}");
         setEventMetadata("VALID_MESORREGIAOUFREGSIGLA","{handler:'Valid_Mesorregiaoufregsigla',iparms:[]");
         setEventMetadata("VALID_MESORREGIAOUFREGSIGLA",",oparms:[]}");
         setEventMetadata("VALID_MESORREGIAOUFREGNOME","{handler:'Valid_Mesorregiaoufregnome',iparms:[]");
         setEventMetadata("VALID_MESORREGIAOUFREGNOME",",oparms:[]}");
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
         pr_default.close(13);
         pr_default.close(14);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z18MesorregiaoUFSiglaNome = "";
         Z22MesorregiaoUFRegSiglaNome = "";
         Z14MesorregiaoNome = "";
         Combo_mesorregiaoufid_Selectedvalue_get = "";
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
         A14MesorregiaoNome = "";
         lblTextblockmesorregiaoufid_Jsonclick = "";
         ucCombo_mesorregiaoufid = new GXUserControl();
         AV16DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV15MesorregiaoUFID_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         A17MesorregiaoUFNome = "";
         A18MesorregiaoUFSiglaNome = "";
         A20MesorregiaoUFRegSigla = "";
         A21MesorregiaoUFRegNome = "";
         A22MesorregiaoUFRegSiglaNome = "";
         A16MesorregiaoUFSigla = "";
         AV25Pgmname = "";
         Combo_mesorregiaoufid_Objectcall = "";
         Combo_mesorregiaoufid_Class = "";
         Combo_mesorregiaoufid_Icontype = "";
         Combo_mesorregiaoufid_Icon = "";
         Combo_mesorregiaoufid_Tooltip = "";
         Combo_mesorregiaoufid_Selectedvalue_set = "";
         Combo_mesorregiaoufid_Selectedtext_set = "";
         Combo_mesorregiaoufid_Selectedtext_get = "";
         Combo_mesorregiaoufid_Gamoauthtoken = "";
         Combo_mesorregiaoufid_Ddointernalname = "";
         Combo_mesorregiaoufid_Titlecontrolalign = "";
         Combo_mesorregiaoufid_Dropdownoptionstype = "";
         Combo_mesorregiaoufid_Titlecontrolidtoreplace = "";
         Combo_mesorregiaoufid_Datalisttype = "";
         Combo_mesorregiaoufid_Datalistfixedvalues = "";
         Combo_mesorregiaoufid_Remoteservicesparameters = "";
         Combo_mesorregiaoufid_Htmltemplate = "";
         Combo_mesorregiaoufid_Multiplevaluestype = "";
         Combo_mesorregiaoufid_Loadingdata = "";
         Combo_mesorregiaoufid_Noresultsfound = "";
         Combo_mesorregiaoufid_Emptyitemtext = "";
         Combo_mesorregiaoufid_Onlyselectedvalues = "";
         Combo_mesorregiaoufid_Selectalltext = "";
         Combo_mesorregiaoufid_Multiplevaluesseparator = "";
         Combo_mesorregiaoufid_Addnewoptiontext = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode3 = "";
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
         Z16MesorregiaoUFSigla = "";
         Z17MesorregiaoUFNome = "";
         Z20MesorregiaoUFRegSigla = "";
         Z21MesorregiaoUFRegNome = "";
         T00034_A16MesorregiaoUFSigla = new string[] {""} ;
         T00034_A17MesorregiaoUFNome = new string[] {""} ;
         T00034_A19MesorregiaoUFRegID = new int[1] ;
         T00035_A20MesorregiaoUFRegSigla = new string[] {""} ;
         T00035_n20MesorregiaoUFRegSigla = new bool[] {false} ;
         T00035_A21MesorregiaoUFRegNome = new string[] {""} ;
         T00035_n21MesorregiaoUFRegNome = new bool[] {false} ;
         T00036_A18MesorregiaoUFSiglaNome = new string[] {""} ;
         T00036_n18MesorregiaoUFSiglaNome = new bool[] {false} ;
         T00036_A22MesorregiaoUFRegSiglaNome = new string[] {""} ;
         T00036_n22MesorregiaoUFRegSiglaNome = new bool[] {false} ;
         T00036_A13MesorregiaoID = new int[1] ;
         T00036_A14MesorregiaoNome = new string[] {""} ;
         T00036_A16MesorregiaoUFSigla = new string[] {""} ;
         T00036_A17MesorregiaoUFNome = new string[] {""} ;
         T00036_A19MesorregiaoUFRegID = new int[1] ;
         T00036_A20MesorregiaoUFRegSigla = new string[] {""} ;
         T00036_n20MesorregiaoUFRegSigla = new bool[] {false} ;
         T00036_A21MesorregiaoUFRegNome = new string[] {""} ;
         T00036_n21MesorregiaoUFRegNome = new bool[] {false} ;
         T00036_A15MesorregiaoUFID = new int[1] ;
         T00037_A16MesorregiaoUFSigla = new string[] {""} ;
         T00037_A17MesorregiaoUFNome = new string[] {""} ;
         T00037_A19MesorregiaoUFRegID = new int[1] ;
         T00038_A20MesorregiaoUFRegSigla = new string[] {""} ;
         T00038_n20MesorregiaoUFRegSigla = new bool[] {false} ;
         T00038_A21MesorregiaoUFRegNome = new string[] {""} ;
         T00038_n21MesorregiaoUFRegNome = new bool[] {false} ;
         T00039_A13MesorregiaoID = new int[1] ;
         T00033_A13MesorregiaoID = new int[1] ;
         T00033_A14MesorregiaoNome = new string[] {""} ;
         T00033_A15MesorregiaoUFID = new int[1] ;
         T00033_A16MesorregiaoUFSigla = new string[] {""} ;
         T00033_A17MesorregiaoUFNome = new string[] {""} ;
         T00033_A18MesorregiaoUFSiglaNome = new string[] {""} ;
         T00033_n18MesorregiaoUFSiglaNome = new bool[] {false} ;
         T00033_A19MesorregiaoUFRegID = new int[1] ;
         T00033_A20MesorregiaoUFRegSigla = new string[] {""} ;
         T00033_n20MesorregiaoUFRegSigla = new bool[] {false} ;
         T00033_A21MesorregiaoUFRegNome = new string[] {""} ;
         T00033_n21MesorregiaoUFRegNome = new bool[] {false} ;
         T00033_A22MesorregiaoUFRegSiglaNome = new string[] {""} ;
         T00033_n22MesorregiaoUFRegSiglaNome = new bool[] {false} ;
         T000310_A13MesorregiaoID = new int[1] ;
         T000311_A13MesorregiaoID = new int[1] ;
         T00032_A13MesorregiaoID = new int[1] ;
         T00032_A14MesorregiaoNome = new string[] {""} ;
         T00032_A15MesorregiaoUFID = new int[1] ;
         T00032_A16MesorregiaoUFSigla = new string[] {""} ;
         T00032_A17MesorregiaoUFNome = new string[] {""} ;
         T00032_A18MesorregiaoUFSiglaNome = new string[] {""} ;
         T00032_n18MesorregiaoUFSiglaNome = new bool[] {false} ;
         T00032_A19MesorregiaoUFRegID = new int[1] ;
         T00032_A20MesorregiaoUFRegSigla = new string[] {""} ;
         T00032_n20MesorregiaoUFRegSigla = new bool[] {false} ;
         T00032_A21MesorregiaoUFRegNome = new string[] {""} ;
         T00032_n21MesorregiaoUFRegNome = new bool[] {false} ;
         T00032_A22MesorregiaoUFRegSiglaNome = new string[] {""} ;
         T00032_n22MesorregiaoUFRegSiglaNome = new bool[] {false} ;
         T000315_A16MesorregiaoUFSigla = new string[] {""} ;
         T000315_A17MesorregiaoUFNome = new string[] {""} ;
         T000315_A19MesorregiaoUFRegID = new int[1] ;
         T000316_A20MesorregiaoUFRegSigla = new string[] {""} ;
         T000316_n20MesorregiaoUFRegSigla = new bool[] {false} ;
         T000316_A21MesorregiaoUFRegNome = new string[] {""} ;
         T000316_n21MesorregiaoUFRegNome = new bool[] {false} ;
         T000317_A23MicrorregiaoID = new int[1] ;
         T000318_A13MesorregiaoID = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.core.mesorregiao__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.mesorregiao__default(),
            new Object[][] {
                new Object[] {
               T00032_A13MesorregiaoID, T00032_A14MesorregiaoNome, T00032_A15MesorregiaoUFID, T00032_A16MesorregiaoUFSigla, T00032_A17MesorregiaoUFNome, T00032_A18MesorregiaoUFSiglaNome, T00032_n18MesorregiaoUFSiglaNome, T00032_A19MesorregiaoUFRegID, T00032_A20MesorregiaoUFRegSigla, T00032_n20MesorregiaoUFRegSigla,
               T00032_A21MesorregiaoUFRegNome, T00032_n21MesorregiaoUFRegNome, T00032_A22MesorregiaoUFRegSiglaNome, T00032_n22MesorregiaoUFRegSiglaNome
               }
               , new Object[] {
               T00033_A13MesorregiaoID, T00033_A14MesorregiaoNome, T00033_A15MesorregiaoUFID, T00033_A16MesorregiaoUFSigla, T00033_A17MesorregiaoUFNome, T00033_A18MesorregiaoUFSiglaNome, T00033_n18MesorregiaoUFSiglaNome, T00033_A19MesorregiaoUFRegID, T00033_A20MesorregiaoUFRegSigla, T00033_n20MesorregiaoUFRegSigla,
               T00033_A21MesorregiaoUFRegNome, T00033_n21MesorregiaoUFRegNome, T00033_A22MesorregiaoUFRegSiglaNome, T00033_n22MesorregiaoUFRegSiglaNome
               }
               , new Object[] {
               T00034_A16MesorregiaoUFSigla, T00034_A17MesorregiaoUFNome, T00034_A19MesorregiaoUFRegID
               }
               , new Object[] {
               T00035_A20MesorregiaoUFRegSigla, T00035_A21MesorregiaoUFRegNome
               }
               , new Object[] {
               T00036_A18MesorregiaoUFSiglaNome, T00036_n18MesorregiaoUFSiglaNome, T00036_A22MesorregiaoUFRegSiglaNome, T00036_n22MesorregiaoUFRegSiglaNome, T00036_A13MesorregiaoID, T00036_A14MesorregiaoNome, T00036_A16MesorregiaoUFSigla, T00036_A17MesorregiaoUFNome, T00036_A19MesorregiaoUFRegID, T00036_A20MesorregiaoUFRegSigla,
               T00036_n20MesorregiaoUFRegSigla, T00036_A21MesorregiaoUFRegNome, T00036_n21MesorregiaoUFRegNome, T00036_A15MesorregiaoUFID
               }
               , new Object[] {
               T00037_A16MesorregiaoUFSigla, T00037_A17MesorregiaoUFNome, T00037_A19MesorregiaoUFRegID
               }
               , new Object[] {
               T00038_A20MesorregiaoUFRegSigla, T00038_A21MesorregiaoUFRegNome
               }
               , new Object[] {
               T00039_A13MesorregiaoID
               }
               , new Object[] {
               T000310_A13MesorregiaoID
               }
               , new Object[] {
               T000311_A13MesorregiaoID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000315_A16MesorregiaoUFSigla, T000315_A17MesorregiaoUFNome, T000315_A19MesorregiaoUFRegID
               }
               , new Object[] {
               T000316_A20MesorregiaoUFRegSigla, T000316_A21MesorregiaoUFRegNome
               }
               , new Object[] {
               T000317_A23MicrorregiaoID
               }
               , new Object[] {
               T000318_A13MesorregiaoID
               }
            }
         );
         AV25Pgmname = "core.mesorregiao";
      }

      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short RcdFound3 ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short nIsDirty_3 ;
      private short gxajaxcallmode ;
      private int wcpOAV7MesorregiaoID ;
      private int Z13MesorregiaoID ;
      private int Z15MesorregiaoUFID ;
      private int N15MesorregiaoUFID ;
      private int A15MesorregiaoUFID ;
      private int A19MesorregiaoUFRegID ;
      private int AV7MesorregiaoID ;
      private int trnEnded ;
      private int A13MesorregiaoID ;
      private int edtMesorregiaoID_Enabled ;
      private int edtMesorregiaoNome_Enabled ;
      private int edtMesorregiaoUFID_Visible ;
      private int edtMesorregiaoUFID_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int AV20ComboMesorregiaoUFID ;
      private int edtavCombomesorregiaoufid_Enabled ;
      private int edtavCombomesorregiaoufid_Visible ;
      private int edtMesorregiaoUFNome_Visible ;
      private int edtMesorregiaoUFNome_Enabled ;
      private int edtMesorregiaoUFSiglaNome_Visible ;
      private int edtMesorregiaoUFSiglaNome_Enabled ;
      private int edtMesorregiaoUFRegID_Enabled ;
      private int edtMesorregiaoUFRegID_Visible ;
      private int edtMesorregiaoUFRegSigla_Visible ;
      private int edtMesorregiaoUFRegSigla_Enabled ;
      private int edtMesorregiaoUFRegNome_Visible ;
      private int edtMesorregiaoUFRegNome_Enabled ;
      private int edtMesorregiaoUFRegSiglaNome_Visible ;
      private int edtMesorregiaoUFRegSiglaNome_Enabled ;
      private int AV13Insert_MesorregiaoUFID ;
      private int Combo_mesorregiaoufid_Datalistupdateminimumcharacters ;
      private int Combo_mesorregiaoufid_Gxcontroltype ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int AV26GXV1 ;
      private int Z19MesorregiaoUFRegID ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Combo_mesorregiaoufid_Selectedvalue_get ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtMesorregiaoID_Internalname ;
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
      private string edtMesorregiaoID_Jsonclick ;
      private string edtMesorregiaoNome_Internalname ;
      private string edtMesorregiaoNome_Jsonclick ;
      private string divTablesplittedmesorregiaoufid_Internalname ;
      private string lblTextblockmesorregiaoufid_Internalname ;
      private string lblTextblockmesorregiaoufid_Jsonclick ;
      private string Combo_mesorregiaoufid_Caption ;
      private string Combo_mesorregiaoufid_Cls ;
      private string Combo_mesorregiaoufid_Datalistproc ;
      private string Combo_mesorregiaoufid_Datalistprocparametersprefix ;
      private string Combo_mesorregiaoufid_Internalname ;
      private string edtMesorregiaoUFID_Internalname ;
      private string edtMesorregiaoUFID_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_mesorregiaoufid_Internalname ;
      private string edtavCombomesorregiaoufid_Internalname ;
      private string edtavCombomesorregiaoufid_Jsonclick ;
      private string edtMesorregiaoUFNome_Internalname ;
      private string edtMesorregiaoUFNome_Jsonclick ;
      private string edtMesorregiaoUFSiglaNome_Internalname ;
      private string edtMesorregiaoUFSiglaNome_Jsonclick ;
      private string edtMesorregiaoUFRegID_Internalname ;
      private string edtMesorregiaoUFRegID_Jsonclick ;
      private string edtMesorregiaoUFRegSigla_Internalname ;
      private string edtMesorregiaoUFRegSigla_Jsonclick ;
      private string edtMesorregiaoUFRegNome_Internalname ;
      private string edtMesorregiaoUFRegNome_Jsonclick ;
      private string edtMesorregiaoUFRegSiglaNome_Internalname ;
      private string edtMesorregiaoUFRegSiglaNome_Jsonclick ;
      private string AV25Pgmname ;
      private string Combo_mesorregiaoufid_Objectcall ;
      private string Combo_mesorregiaoufid_Class ;
      private string Combo_mesorregiaoufid_Icontype ;
      private string Combo_mesorregiaoufid_Icon ;
      private string Combo_mesorregiaoufid_Tooltip ;
      private string Combo_mesorregiaoufid_Selectedvalue_set ;
      private string Combo_mesorregiaoufid_Selectedtext_set ;
      private string Combo_mesorregiaoufid_Selectedtext_get ;
      private string Combo_mesorregiaoufid_Gamoauthtoken ;
      private string Combo_mesorregiaoufid_Ddointernalname ;
      private string Combo_mesorregiaoufid_Titlecontrolalign ;
      private string Combo_mesorregiaoufid_Dropdownoptionstype ;
      private string Combo_mesorregiaoufid_Titlecontrolidtoreplace ;
      private string Combo_mesorregiaoufid_Datalisttype ;
      private string Combo_mesorregiaoufid_Datalistfixedvalues ;
      private string Combo_mesorregiaoufid_Remoteservicesparameters ;
      private string Combo_mesorregiaoufid_Htmltemplate ;
      private string Combo_mesorregiaoufid_Multiplevaluestype ;
      private string Combo_mesorregiaoufid_Loadingdata ;
      private string Combo_mesorregiaoufid_Noresultsfound ;
      private string Combo_mesorregiaoufid_Emptyitemtext ;
      private string Combo_mesorregiaoufid_Onlyselectedvalues ;
      private string Combo_mesorregiaoufid_Selectalltext ;
      private string Combo_mesorregiaoufid_Multiplevaluesseparator ;
      private string Combo_mesorregiaoufid_Addnewoptiontext ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string hsh ;
      private string sMode3 ;
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
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool Combo_mesorregiaoufid_Emptyitem ;
      private bool n18MesorregiaoUFSiglaNome ;
      private bool n22MesorregiaoUFRegSiglaNome ;
      private bool Combo_mesorregiaoufid_Enabled ;
      private bool Combo_mesorregiaoufid_Visible ;
      private bool Combo_mesorregiaoufid_Allowmultipleselection ;
      private bool Combo_mesorregiaoufid_Isgriditem ;
      private bool Combo_mesorregiaoufid_Hasdescription ;
      private bool Combo_mesorregiaoufid_Includeonlyselectedoption ;
      private bool Combo_mesorregiaoufid_Includeselectalloption ;
      private bool Combo_mesorregiaoufid_Includeaddnewoption ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool n20MesorregiaoUFRegSigla ;
      private bool n21MesorregiaoUFRegNome ;
      private bool returnInSub ;
      private string AV19Combo_DataJson ;
      private string Z18MesorregiaoUFSiglaNome ;
      private string Z22MesorregiaoUFRegSiglaNome ;
      private string Z14MesorregiaoNome ;
      private string A14MesorregiaoNome ;
      private string A17MesorregiaoUFNome ;
      private string A18MesorregiaoUFSiglaNome ;
      private string A20MesorregiaoUFRegSigla ;
      private string A21MesorregiaoUFRegNome ;
      private string A22MesorregiaoUFRegSiglaNome ;
      private string A16MesorregiaoUFSigla ;
      private string AV17ComboSelectedValue ;
      private string AV18ComboSelectedText ;
      private string Z16MesorregiaoUFSigla ;
      private string Z17MesorregiaoUFNome ;
      private string Z20MesorregiaoUFRegSigla ;
      private string Z21MesorregiaoUFRegNome ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucCombo_mesorregiaoufid ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T00034_A16MesorregiaoUFSigla ;
      private string[] T00034_A17MesorregiaoUFNome ;
      private int[] T00034_A19MesorregiaoUFRegID ;
      private string[] T00035_A20MesorregiaoUFRegSigla ;
      private bool[] T00035_n20MesorregiaoUFRegSigla ;
      private string[] T00035_A21MesorregiaoUFRegNome ;
      private bool[] T00035_n21MesorregiaoUFRegNome ;
      private string[] T00036_A18MesorregiaoUFSiglaNome ;
      private bool[] T00036_n18MesorregiaoUFSiglaNome ;
      private string[] T00036_A22MesorregiaoUFRegSiglaNome ;
      private bool[] T00036_n22MesorregiaoUFRegSiglaNome ;
      private int[] T00036_A13MesorregiaoID ;
      private string[] T00036_A14MesorregiaoNome ;
      private string[] T00036_A16MesorregiaoUFSigla ;
      private string[] T00036_A17MesorregiaoUFNome ;
      private int[] T00036_A19MesorregiaoUFRegID ;
      private string[] T00036_A20MesorregiaoUFRegSigla ;
      private bool[] T00036_n20MesorregiaoUFRegSigla ;
      private string[] T00036_A21MesorregiaoUFRegNome ;
      private bool[] T00036_n21MesorregiaoUFRegNome ;
      private int[] T00036_A15MesorregiaoUFID ;
      private string[] T00037_A16MesorregiaoUFSigla ;
      private string[] T00037_A17MesorregiaoUFNome ;
      private int[] T00037_A19MesorregiaoUFRegID ;
      private string[] T00038_A20MesorregiaoUFRegSigla ;
      private bool[] T00038_n20MesorregiaoUFRegSigla ;
      private string[] T00038_A21MesorregiaoUFRegNome ;
      private bool[] T00038_n21MesorregiaoUFRegNome ;
      private int[] T00039_A13MesorregiaoID ;
      private int[] T00033_A13MesorregiaoID ;
      private string[] T00033_A14MesorregiaoNome ;
      private int[] T00033_A15MesorregiaoUFID ;
      private string[] T00033_A16MesorregiaoUFSigla ;
      private string[] T00033_A17MesorregiaoUFNome ;
      private string[] T00033_A18MesorregiaoUFSiglaNome ;
      private bool[] T00033_n18MesorregiaoUFSiglaNome ;
      private int[] T00033_A19MesorregiaoUFRegID ;
      private string[] T00033_A20MesorregiaoUFRegSigla ;
      private bool[] T00033_n20MesorregiaoUFRegSigla ;
      private string[] T00033_A21MesorregiaoUFRegNome ;
      private bool[] T00033_n21MesorregiaoUFRegNome ;
      private string[] T00033_A22MesorregiaoUFRegSiglaNome ;
      private bool[] T00033_n22MesorregiaoUFRegSiglaNome ;
      private int[] T000310_A13MesorregiaoID ;
      private int[] T000311_A13MesorregiaoID ;
      private int[] T00032_A13MesorregiaoID ;
      private string[] T00032_A14MesorregiaoNome ;
      private int[] T00032_A15MesorregiaoUFID ;
      private string[] T00032_A16MesorregiaoUFSigla ;
      private string[] T00032_A17MesorregiaoUFNome ;
      private string[] T00032_A18MesorregiaoUFSiglaNome ;
      private bool[] T00032_n18MesorregiaoUFSiglaNome ;
      private int[] T00032_A19MesorregiaoUFRegID ;
      private string[] T00032_A20MesorregiaoUFRegSigla ;
      private bool[] T00032_n20MesorregiaoUFRegSigla ;
      private string[] T00032_A21MesorregiaoUFRegNome ;
      private bool[] T00032_n21MesorregiaoUFRegNome ;
      private string[] T00032_A22MesorregiaoUFRegSiglaNome ;
      private bool[] T00032_n22MesorregiaoUFRegSiglaNome ;
      private string[] T000315_A16MesorregiaoUFSigla ;
      private string[] T000315_A17MesorregiaoUFNome ;
      private int[] T000315_A19MesorregiaoUFRegID ;
      private string[] T000316_A20MesorregiaoUFRegSigla ;
      private bool[] T000316_n20MesorregiaoUFRegSigla ;
      private string[] T000316_A21MesorregiaoUFRegNome ;
      private bool[] T000316_n21MesorregiaoUFRegNome ;
      private int[] T000317_A23MicrorregiaoID ;
      private int[] T000318_A13MesorregiaoID ;
      private IDataStoreProvider pr_gam ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV15MesorregiaoUFID_Data ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV23GAMErrors ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV14TrnContextAtt ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV16DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV22GAMSession ;
   }

   public class mesorregiao__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class mesorregiao__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[11])
       ,new UpdateCursor(def[12])
       ,new ForEachCursor(def[13])
       ,new ForEachCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new ForEachCursor(def[16])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00036;
        prmT00036 = new Object[] {
        new ParDef("MesorregiaoID",GXType.Int32,9,0)
        };
        Object[] prmT00034;
        prmT00034 = new Object[] {
        new ParDef("MesorregiaoUFID",GXType.Int32,9,0)
        };
        Object[] prmT00035;
        prmT00035 = new Object[] {
        new ParDef("MesorregiaoUFRegID",GXType.Int32,9,0)
        };
        Object[] prmT00037;
        prmT00037 = new Object[] {
        new ParDef("MesorregiaoUFID",GXType.Int32,9,0)
        };
        Object[] prmT00038;
        prmT00038 = new Object[] {
        new ParDef("MesorregiaoUFRegID",GXType.Int32,9,0)
        };
        Object[] prmT00039;
        prmT00039 = new Object[] {
        new ParDef("MesorregiaoID",GXType.Int32,9,0)
        };
        Object[] prmT00033;
        prmT00033 = new Object[] {
        new ParDef("MesorregiaoID",GXType.Int32,9,0)
        };
        Object[] prmT000310;
        prmT000310 = new Object[] {
        new ParDef("MesorregiaoID",GXType.Int32,9,0)
        };
        Object[] prmT000311;
        prmT000311 = new Object[] {
        new ParDef("MesorregiaoID",GXType.Int32,9,0)
        };
        Object[] prmT00032;
        prmT00032 = new Object[] {
        new ParDef("MesorregiaoID",GXType.Int32,9,0)
        };
        Object[] prmT000312;
        prmT000312 = new Object[] {
        new ParDef("MesorregiaoUFSigla",GXType.VarChar,2,0) ,
        new ParDef("MesorregiaoUFNome",GXType.VarChar,50,0) ,
        new ParDef("MesorregiaoUFRegID",GXType.Int32,9,0) ,
        new ParDef("MesorregiaoUFRegSigla",GXType.VarChar,10,0){Nullable=true} ,
        new ParDef("MesorregiaoUFRegNome",GXType.VarChar,50,0){Nullable=true} ,
        new ParDef("MesorregiaoUFSiglaNome",GXType.VarChar,70,0){Nullable=true} ,
        new ParDef("MesorregiaoUFRegSiglaNome",GXType.VarChar,70,0){Nullable=true} ,
        new ParDef("MesorregiaoID",GXType.Int32,9,0) ,
        new ParDef("MesorregiaoNome",GXType.VarChar,80,0) ,
        new ParDef("MesorregiaoUFID",GXType.Int32,9,0)
        };
        Object[] prmT000313;
        prmT000313 = new Object[] {
        new ParDef("MesorregiaoUFSigla",GXType.VarChar,2,0) ,
        new ParDef("MesorregiaoUFNome",GXType.VarChar,50,0) ,
        new ParDef("MesorregiaoUFRegID",GXType.Int32,9,0) ,
        new ParDef("MesorregiaoUFRegSigla",GXType.VarChar,10,0){Nullable=true} ,
        new ParDef("MesorregiaoUFRegNome",GXType.VarChar,50,0){Nullable=true} ,
        new ParDef("MesorregiaoUFSiglaNome",GXType.VarChar,70,0){Nullable=true} ,
        new ParDef("MesorregiaoUFRegSiglaNome",GXType.VarChar,70,0){Nullable=true} ,
        new ParDef("MesorregiaoNome",GXType.VarChar,80,0) ,
        new ParDef("MesorregiaoUFID",GXType.Int32,9,0) ,
        new ParDef("MesorregiaoID",GXType.Int32,9,0)
        };
        Object[] prmT000314;
        prmT000314 = new Object[] {
        new ParDef("MesorregiaoID",GXType.Int32,9,0)
        };
        Object[] prmT000317;
        prmT000317 = new Object[] {
        new ParDef("MesorregiaoID",GXType.Int32,9,0)
        };
        Object[] prmT000318;
        prmT000318 = new Object[] {
        };
        Object[] prmT000315;
        prmT000315 = new Object[] {
        new ParDef("MesorregiaoUFID",GXType.Int32,9,0)
        };
        Object[] prmT000316;
        prmT000316 = new Object[] {
        new ParDef("MesorregiaoUFRegID",GXType.Int32,9,0)
        };
        def= new CursorDef[] {
            new CursorDef("T00032", "SELECT MesorregiaoID, MesorregiaoNome, MesorregiaoUFID, MesorregiaoUFSigla, MesorregiaoUFNome, MesorregiaoUFSiglaNome, MesorregiaoUFRegID, MesorregiaoUFRegSigla, MesorregiaoUFRegNome, MesorregiaoUFRegSiglaNome FROM tbibge_mesorregiao WHERE MesorregiaoID = :MesorregiaoID  FOR UPDATE OF tbibge_mesorregiao NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT00032,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00033", "SELECT MesorregiaoID, MesorregiaoNome, MesorregiaoUFID, MesorregiaoUFSigla, MesorregiaoUFNome, MesorregiaoUFSiglaNome, MesorregiaoUFRegID, MesorregiaoUFRegSigla, MesorregiaoUFRegNome, MesorregiaoUFRegSiglaNome FROM tbibge_mesorregiao WHERE MesorregiaoID = :MesorregiaoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00033,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00034", "SELECT UFSigla AS MesorregiaoUFSigla, UFNome AS MesorregiaoUFNome, UFRegID AS MesorregiaoUFRegID FROM tbibge_uf WHERE UFID = :MesorregiaoUFID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00034,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00035", "SELECT RegiaoSigla AS MesorregiaoUFRegSigla, RegiaoNome AS MesorregiaoUFRegNome FROM tbibge_regiao WHERE RegiaoID = :MesorregiaoUFRegID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00035,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00036", "SELECT TM1.MesorregiaoUFSiglaNome AS MesorregiaoUFSiglaNome, TM1.MesorregiaoUFRegSiglaNome AS MesorregiaoUFRegSiglaNome, TM1.MesorregiaoID, TM1.MesorregiaoNome, TM1.MesorregiaoUFSigla AS MesorregiaoUFSigla, TM1.MesorregiaoUFNome AS MesorregiaoUFNome, TM1.MesorregiaoUFRegID AS MesorregiaoUFRegID, TM1.MesorregiaoUFRegSigla AS MesorregiaoUFRegSigla, TM1.MesorregiaoUFRegNome AS MesorregiaoUFRegNome, TM1.MesorregiaoUFID AS MesorregiaoUFID FROM (tbibge_mesorregiao TM1 INNER JOIN tbibge_uf T2 ON T2.UFID = TM1.MesorregiaoUFID) WHERE TM1.MesorregiaoID = :MesorregiaoID ORDER BY TM1.MesorregiaoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00036,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00037", "SELECT UFSigla AS MesorregiaoUFSigla, UFNome AS MesorregiaoUFNome, UFRegID AS MesorregiaoUFRegID FROM tbibge_uf WHERE UFID = :MesorregiaoUFID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00037,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00038", "SELECT RegiaoSigla AS MesorregiaoUFRegSigla, RegiaoNome AS MesorregiaoUFRegNome FROM tbibge_regiao WHERE RegiaoID = :MesorregiaoUFRegID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00038,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00039", "SELECT MesorregiaoID FROM tbibge_mesorregiao WHERE MesorregiaoID = :MesorregiaoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00039,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000310", "SELECT MesorregiaoID FROM tbibge_mesorregiao WHERE ( MesorregiaoID > :MesorregiaoID) ORDER BY MesorregiaoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000310,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000311", "SELECT MesorregiaoID FROM tbibge_mesorregiao WHERE ( MesorregiaoID < :MesorregiaoID) ORDER BY MesorregiaoID DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000311,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000312", "SAVEPOINT gxupdate;INSERT INTO tbibge_mesorregiao(MesorregiaoUFSigla, MesorregiaoUFNome, MesorregiaoUFRegID, MesorregiaoUFRegSigla, MesorregiaoUFRegNome, MesorregiaoUFSiglaNome, MesorregiaoUFRegSiglaNome, MesorregiaoID, MesorregiaoNome, MesorregiaoUFID) VALUES(:MesorregiaoUFSigla, :MesorregiaoUFNome, :MesorregiaoUFRegID, :MesorregiaoUFRegSigla, :MesorregiaoUFRegNome, :MesorregiaoUFSiglaNome, :MesorregiaoUFRegSiglaNome, :MesorregiaoID, :MesorregiaoNome, :MesorregiaoUFID);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000312)
           ,new CursorDef("T000313", "SAVEPOINT gxupdate;UPDATE tbibge_mesorregiao SET MesorregiaoUFSigla=:MesorregiaoUFSigla, MesorregiaoUFNome=:MesorregiaoUFNome, MesorregiaoUFRegID=:MesorregiaoUFRegID, MesorregiaoUFRegSigla=:MesorregiaoUFRegSigla, MesorregiaoUFRegNome=:MesorregiaoUFRegNome, MesorregiaoUFSiglaNome=:MesorregiaoUFSiglaNome, MesorregiaoUFRegSiglaNome=:MesorregiaoUFRegSiglaNome, MesorregiaoNome=:MesorregiaoNome, MesorregiaoUFID=:MesorregiaoUFID  WHERE MesorregiaoID = :MesorregiaoID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000313)
           ,new CursorDef("T000314", "SAVEPOINT gxupdate;DELETE FROM tbibge_mesorregiao  WHERE MesorregiaoID = :MesorregiaoID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000314)
           ,new CursorDef("T000315", "SELECT UFSigla AS MesorregiaoUFSigla, UFNome AS MesorregiaoUFNome, UFRegID AS MesorregiaoUFRegID FROM tbibge_uf WHERE UFID = :MesorregiaoUFID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000315,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000316", "SELECT RegiaoSigla AS MesorregiaoUFRegSigla, RegiaoNome AS MesorregiaoUFRegNome FROM tbibge_regiao WHERE RegiaoID = :MesorregiaoUFRegID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000316,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000317", "SELECT MicrorregiaoID FROM tbibge_microrregiao WHERE MicrorregiaoMesoID = :MesorregiaoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000317,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000318", "SELECT MesorregiaoID FROM tbibge_mesorregiao ORDER BY MesorregiaoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000318,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              ((int[]) buf[7])[0] = rslt.getInt(7);
              ((string[]) buf[8])[0] = rslt.getVarchar(8);
              ((bool[]) buf[9])[0] = rslt.wasNull(8);
              ((string[]) buf[10])[0] = rslt.getVarchar(9);
              ((bool[]) buf[11])[0] = rslt.wasNull(9);
              ((string[]) buf[12])[0] = rslt.getVarchar(10);
              ((bool[]) buf[13])[0] = rslt.wasNull(10);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              ((int[]) buf[7])[0] = rslt.getInt(7);
              ((string[]) buf[8])[0] = rslt.getVarchar(8);
              ((bool[]) buf[9])[0] = rslt.wasNull(8);
              ((string[]) buf[10])[0] = rslt.getVarchar(9);
              ((bool[]) buf[11])[0] = rslt.wasNull(9);
              ((string[]) buf[12])[0] = rslt.getVarchar(10);
              ((bool[]) buf[13])[0] = rslt.wasNull(10);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              ((string[]) buf[2])[0] = rslt.getVarchar(2);
              ((bool[]) buf[3])[0] = rslt.wasNull(2);
              ((int[]) buf[4])[0] = rslt.getInt(3);
              ((string[]) buf[5])[0] = rslt.getVarchar(4);
              ((string[]) buf[6])[0] = rslt.getVarchar(5);
              ((string[]) buf[7])[0] = rslt.getVarchar(6);
              ((int[]) buf[8])[0] = rslt.getInt(7);
              ((string[]) buf[9])[0] = rslt.getVarchar(8);
              ((bool[]) buf[10])[0] = rslt.wasNull(8);
              ((string[]) buf[11])[0] = rslt.getVarchar(9);
              ((bool[]) buf[12])[0] = rslt.wasNull(9);
              ((int[]) buf[13])[0] = rslt.getInt(10);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 7 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 8 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 9 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 15 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 16 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
