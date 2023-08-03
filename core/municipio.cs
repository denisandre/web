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
   public class municipio : GXDataArea
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
            A37MunicipioMicroID = (int)(Math.Round(NumberUtil.Val( GetPar( "MunicipioMicroID"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A37MunicipioMicroID", StringUtil.LTrimStr( (decimal)(A37MunicipioMicroID), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_12( A37MunicipioMicroID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_13") == 0 )
         {
            A39MunicipioMicroMesoID = (int)(Math.Round(NumberUtil.Val( GetPar( "MunicipioMicroMesoID"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A39MunicipioMicroMesoID", StringUtil.LTrimStr( (decimal)(A39MunicipioMicroMesoID), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_13( A39MunicipioMicroMesoID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_14") == 0 )
         {
            A41MunicipioMicroMesoUFID = (int)(Math.Round(NumberUtil.Val( GetPar( "MunicipioMicroMesoUFID"), "."), 18, MidpointRounding.ToEven));
            n41MunicipioMicroMesoUFID = false;
            AssignAttri("", false, "A41MunicipioMicroMesoUFID", StringUtil.LTrimStr( (decimal)(A41MunicipioMicroMesoUFID), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_14( A41MunicipioMicroMesoUFID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_15") == 0 )
         {
            A45MunicipioMicroMesoUFRegID = (int)(Math.Round(NumberUtil.Val( GetPar( "MunicipioMicroMesoUFRegID"), "."), 18, MidpointRounding.ToEven));
            n45MunicipioMicroMesoUFRegID = false;
            AssignAttri("", false, "A45MunicipioMicroMesoUFRegID", StringUtil.LTrimStr( (decimal)(A45MunicipioMicroMesoUFRegID), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_15( A45MunicipioMicroMesoUFRegID) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "core.municipio.aspx")), "core.municipio.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "core.municipio.aspx")))) ;
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
                  AV7MunicipioID = (int)(Math.Round(NumberUtil.Val( GetPar( "MunicipioID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7MunicipioID", StringUtil.LTrimStr( (decimal)(AV7MunicipioID), 9, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vMUNICIPIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7MunicipioID), "ZZZ,ZZZ,ZZ9"), context));
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
            Form.Meta.addItem("description", "Município", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtMunicipioID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public municipio( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public municipio( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_MunicipioID )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7MunicipioID = aP1_MunicipioID;
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
            return "municipio_Execute" ;
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMunicipioID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMunicipioID_Internalname, "ID", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMunicipioID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A35MunicipioID), 11, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A35MunicipioID), "ZZZ,ZZZ,ZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMunicipioID_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtMunicipioID_Enabled, 1, "text", "", 11, "chr", 1, "row", 11, 0, 0, 0, 0, -1, 0, true, "core\\ID", "end", false, "", "HLP_core\\municipio.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMunicipioNome_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMunicipioNome_Internalname, "Nome", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMunicipioNome_Internalname, A36MunicipioNome, StringUtil.RTrim( context.localUtil.Format( A36MunicipioNome, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMunicipioNome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtMunicipioNome_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\municipio.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedmunicipiomicroid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockmunicipiomicroid_Internalname, "Microrregião", "", "", lblTextblockmunicipiomicroid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_core\\municipio.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_municipiomicroid.SetProperty("Caption", Combo_municipiomicroid_Caption);
         ucCombo_municipiomicroid.SetProperty("Cls", Combo_municipiomicroid_Cls);
         ucCombo_municipiomicroid.SetProperty("DataListProc", Combo_municipiomicroid_Datalistproc);
         ucCombo_municipiomicroid.SetProperty("DataListProcParametersPrefix", Combo_municipiomicroid_Datalistprocparametersprefix);
         ucCombo_municipiomicroid.SetProperty("EmptyItem", Combo_municipiomicroid_Emptyitem);
         ucCombo_municipiomicroid.SetProperty("DropDownOptionsTitleSettingsIcons", AV16DDO_TitleSettingsIcons);
         ucCombo_municipiomicroid.SetProperty("DropDownOptionsData", AV15MunicipioMicroID_Data);
         ucCombo_municipiomicroid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_municipiomicroid_Internalname, "COMBO_MUNICIPIOMICROIDContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMunicipioMicroID_Internalname, "Microrregião", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMunicipioMicroID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A37MunicipioMicroID), 11, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A37MunicipioMicroID), "ZZZ,ZZZ,ZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMunicipioMicroID_Jsonclick, 0, "Attribute", "", "", "", "", edtMunicipioMicroID_Visible, edtMunicipioMicroID_Enabled, 1, "text", "", 11, "chr", 1, "row", 11, 0, 0, 0, 0, -1, 0, true, "core\\ID", "end", false, "", "HLP_core\\municipio.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMunicipioMicroMesoID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMunicipioMicroMesoID_Internalname, "Mesorregião", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtMunicipioMicroMesoID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A39MunicipioMicroMesoID), 11, 0, ",", "")), StringUtil.LTrim( ((edtMunicipioMicroMesoID_Enabled!=0) ? context.localUtil.Format( (decimal)(A39MunicipioMicroMesoID), "ZZZ,ZZZ,ZZ9") : context.localUtil.Format( (decimal)(A39MunicipioMicroMesoID), "ZZZ,ZZZ,ZZ9"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMunicipioMicroMesoID_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtMunicipioMicroMesoID_Enabled, 0, "text", "", 11, "chr", 1, "row", 11, 0, 0, 0, 0, -1, 0, true, "core\\ID", "end", false, "", "HLP_core\\municipio.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMunicipioMicroMesoUFID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMunicipioMicroMesoUFID_Internalname, "UF", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtMunicipioMicroMesoUFID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A41MunicipioMicroMesoUFID), 11, 0, ",", "")), StringUtil.LTrim( ((edtMunicipioMicroMesoUFID_Enabled!=0) ? context.localUtil.Format( (decimal)(A41MunicipioMicroMesoUFID), "ZZZ,ZZZ,ZZ9") : context.localUtil.Format( (decimal)(A41MunicipioMicroMesoUFID), "ZZZ,ZZZ,ZZ9"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMunicipioMicroMesoUFID_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtMunicipioMicroMesoUFID_Enabled, 0, "text", "", 11, "chr", 1, "row", 11, 0, 0, 0, 0, -1, 0, true, "core\\ID", "end", false, "", "HLP_core\\municipio.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMunicipioMicroMesoUFRegID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMunicipioMicroMesoUFRegID_Internalname, "Região", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtMunicipioMicroMesoUFRegID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A45MunicipioMicroMesoUFRegID), 11, 0, ",", "")), StringUtil.LTrim( ((edtMunicipioMicroMesoUFRegID_Enabled!=0) ? context.localUtil.Format( (decimal)(A45MunicipioMicroMesoUFRegID), "ZZZ,ZZZ,ZZ9") : context.localUtil.Format( (decimal)(A45MunicipioMicroMesoUFRegID), "ZZZ,ZZZ,ZZ9"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMunicipioMicroMesoUFRegID_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtMunicipioMicroMesoUFRegID_Enabled, 0, "text", "", 11, "chr", 1, "row", 11, 0, 0, 0, 0, -1, 0, true, "core\\ID", "end", false, "", "HLP_core\\municipio.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\municipio.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\municipio.htm");
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
         GxWebStd.gx_div_start( context, divSectionattribute_municipiomicroid_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtavCombomunicipiomicroid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20ComboMunicipioMicroID), 11, 0, ",", "")), StringUtil.LTrim( ((edtavCombomunicipiomicroid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV20ComboMunicipioMicroID), "ZZZ,ZZZ,ZZ9") : context.localUtil.Format( (decimal)(AV20ComboMunicipioMicroID), "ZZZ,ZZZ,ZZ9"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombomunicipiomicroid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombomunicipiomicroid_Visible, edtavCombomunicipiomicroid_Enabled, 0, "text", "", 11, "chr", 1, "row", 11, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_core\\municipio.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtMunicipioMicroMesoNome_Internalname, A40MunicipioMicroMesoNome, StringUtil.RTrim( context.localUtil.Format( A40MunicipioMicroMesoNome, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMunicipioMicroMesoNome_Jsonclick, 0, "Attribute", "", "", "", "", edtMunicipioMicroMesoNome_Visible, edtMunicipioMicroMesoNome_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\municipio.htm");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtMunicipioMicroMesoUFSigla_Internalname, A42MunicipioMicroMesoUFSigla, StringUtil.RTrim( context.localUtil.Format( A42MunicipioMicroMesoUFSigla, "@!")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMunicipioMicroMesoUFSigla_Jsonclick, 0, "Attribute", "", "", "", "", edtMunicipioMicroMesoUFSigla_Visible, edtMunicipioMicroMesoUFSigla_Enabled, 0, "text", "", 2, "chr", 1, "row", 2, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\municipio.htm");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtMunicipioMicroMesoUFNome_Internalname, A43MunicipioMicroMesoUFNome, StringUtil.RTrim( context.localUtil.Format( A43MunicipioMicroMesoUFNome, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMunicipioMicroMesoUFNome_Jsonclick, 0, "Attribute", "", "", "", "", edtMunicipioMicroMesoUFNome_Visible, edtMunicipioMicroMesoUFNome_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\municipio.htm");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtMunicipioMicroMesoUFSiglaNome_Internalname, A44MunicipioMicroMesoUFSiglaNome, StringUtil.RTrim( context.localUtil.Format( A44MunicipioMicroMesoUFSiglaNome, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMunicipioMicroMesoUFSiglaNome_Jsonclick, 0, "Attribute", "", "", "", "", edtMunicipioMicroMesoUFSiglaNome_Visible, edtMunicipioMicroMesoUFSiglaNome_Enabled, 0, "text", "", 70, "chr", 1, "row", 70, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\municipio.htm");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtMunicipioMicroMesoUFRegSigla_Internalname, A46MunicipioMicroMesoUFRegSigla, StringUtil.RTrim( context.localUtil.Format( A46MunicipioMicroMesoUFRegSigla, "@!")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMunicipioMicroMesoUFRegSigla_Jsonclick, 0, "Attribute", "", "", "", "", edtMunicipioMicroMesoUFRegSigla_Visible, edtMunicipioMicroMesoUFRegSigla_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\municipio.htm");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtMunicipioMicroMesoUFRegNome_Internalname, A47MunicipioMicroMesoUFRegNome, StringUtil.RTrim( context.localUtil.Format( A47MunicipioMicroMesoUFRegNome, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMunicipioMicroMesoUFRegNome_Jsonclick, 0, "Attribute", "", "", "", "", edtMunicipioMicroMesoUFRegNome_Visible, edtMunicipioMicroMesoUFRegNome_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\municipio.htm");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtMunicipioMicroMesoUFRegSiglaNo_Internalname, A48MunicipioMicroMesoUFRegSiglaNo, StringUtil.RTrim( context.localUtil.Format( A48MunicipioMicroMesoUFRegSiglaNo, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMunicipioMicroMesoUFRegSiglaNo_Jsonclick, 0, "Attribute", "", "", "", "", edtMunicipioMicroMesoUFRegSiglaNo_Visible, edtMunicipioMicroMesoUFRegSiglaNo_Enabled, 0, "text", "", 70, "chr", 1, "row", 70, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\municipio.htm");
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
         E11052 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV16DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( "vMUNICIPIOMICROID_DATA"), AV15MunicipioMicroID_Data);
               /* Read saved values. */
               Z35MunicipioID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z35MunicipioID"), ",", "."), 18, MidpointRounding.ToEven));
               Z44MunicipioMicroMesoUFSiglaNome = cgiGet( "Z44MunicipioMicroMesoUFSiglaNome");
               n44MunicipioMicroMesoUFSiglaNome = (String.IsNullOrEmpty(StringUtil.RTrim( A44MunicipioMicroMesoUFSiglaNome)) ? true : false);
               Z48MunicipioMicroMesoUFRegSiglaNo = cgiGet( "Z48MunicipioMicroMesoUFRegSiglaNo");
               n48MunicipioMicroMesoUFRegSiglaNo = (String.IsNullOrEmpty(StringUtil.RTrim( A48MunicipioMicroMesoUFRegSiglaNo)) ? true : false);
               Z36MunicipioNome = cgiGet( "Z36MunicipioNome");
               Z37MunicipioMicroID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z37MunicipioMicroID"), ",", "."), 18, MidpointRounding.ToEven));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N37MunicipioMicroID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N37MunicipioMicroID"), ",", "."), 18, MidpointRounding.ToEven));
               AV7MunicipioID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vMUNICIPIOID"), ",", "."), 18, MidpointRounding.ToEven));
               AV13Insert_MunicipioMicroID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_MUNICIPIOMICROID"), ",", "."), 18, MidpointRounding.ToEven));
               A38MunicipioMicroNome = cgiGet( "MUNICIPIOMICRONOME");
               AV25Pgmname = cgiGet( "vPGMNAME");
               Combo_municipiomicroid_Objectcall = cgiGet( "COMBO_MUNICIPIOMICROID_Objectcall");
               Combo_municipiomicroid_Class = cgiGet( "COMBO_MUNICIPIOMICROID_Class");
               Combo_municipiomicroid_Icontype = cgiGet( "COMBO_MUNICIPIOMICROID_Icontype");
               Combo_municipiomicroid_Icon = cgiGet( "COMBO_MUNICIPIOMICROID_Icon");
               Combo_municipiomicroid_Caption = cgiGet( "COMBO_MUNICIPIOMICROID_Caption");
               Combo_municipiomicroid_Tooltip = cgiGet( "COMBO_MUNICIPIOMICROID_Tooltip");
               Combo_municipiomicroid_Cls = cgiGet( "COMBO_MUNICIPIOMICROID_Cls");
               Combo_municipiomicroid_Selectedvalue_set = cgiGet( "COMBO_MUNICIPIOMICROID_Selectedvalue_set");
               Combo_municipiomicroid_Selectedvalue_get = cgiGet( "COMBO_MUNICIPIOMICROID_Selectedvalue_get");
               Combo_municipiomicroid_Selectedtext_set = cgiGet( "COMBO_MUNICIPIOMICROID_Selectedtext_set");
               Combo_municipiomicroid_Selectedtext_get = cgiGet( "COMBO_MUNICIPIOMICROID_Selectedtext_get");
               Combo_municipiomicroid_Gamoauthtoken = cgiGet( "COMBO_MUNICIPIOMICROID_Gamoauthtoken");
               Combo_municipiomicroid_Ddointernalname = cgiGet( "COMBO_MUNICIPIOMICROID_Ddointernalname");
               Combo_municipiomicroid_Titlecontrolalign = cgiGet( "COMBO_MUNICIPIOMICROID_Titlecontrolalign");
               Combo_municipiomicroid_Dropdownoptionstype = cgiGet( "COMBO_MUNICIPIOMICROID_Dropdownoptionstype");
               Combo_municipiomicroid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_MUNICIPIOMICROID_Enabled"));
               Combo_municipiomicroid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_MUNICIPIOMICROID_Visible"));
               Combo_municipiomicroid_Titlecontrolidtoreplace = cgiGet( "COMBO_MUNICIPIOMICROID_Titlecontrolidtoreplace");
               Combo_municipiomicroid_Datalisttype = cgiGet( "COMBO_MUNICIPIOMICROID_Datalisttype");
               Combo_municipiomicroid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_MUNICIPIOMICROID_Allowmultipleselection"));
               Combo_municipiomicroid_Datalistfixedvalues = cgiGet( "COMBO_MUNICIPIOMICROID_Datalistfixedvalues");
               Combo_municipiomicroid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_MUNICIPIOMICROID_Isgriditem"));
               Combo_municipiomicroid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_MUNICIPIOMICROID_Hasdescription"));
               Combo_municipiomicroid_Datalistproc = cgiGet( "COMBO_MUNICIPIOMICROID_Datalistproc");
               Combo_municipiomicroid_Datalistprocparametersprefix = cgiGet( "COMBO_MUNICIPIOMICROID_Datalistprocparametersprefix");
               Combo_municipiomicroid_Remoteservicesparameters = cgiGet( "COMBO_MUNICIPIOMICROID_Remoteservicesparameters");
               Combo_municipiomicroid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_MUNICIPIOMICROID_Datalistupdateminimumcharacters"), ",", "."), 18, MidpointRounding.ToEven));
               Combo_municipiomicroid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_MUNICIPIOMICROID_Includeonlyselectedoption"));
               Combo_municipiomicroid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_MUNICIPIOMICROID_Includeselectalloption"));
               Combo_municipiomicroid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_MUNICIPIOMICROID_Emptyitem"));
               Combo_municipiomicroid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_MUNICIPIOMICROID_Includeaddnewoption"));
               Combo_municipiomicroid_Htmltemplate = cgiGet( "COMBO_MUNICIPIOMICROID_Htmltemplate");
               Combo_municipiomicroid_Multiplevaluestype = cgiGet( "COMBO_MUNICIPIOMICROID_Multiplevaluestype");
               Combo_municipiomicroid_Loadingdata = cgiGet( "COMBO_MUNICIPIOMICROID_Loadingdata");
               Combo_municipiomicroid_Noresultsfound = cgiGet( "COMBO_MUNICIPIOMICROID_Noresultsfound");
               Combo_municipiomicroid_Emptyitemtext = cgiGet( "COMBO_MUNICIPIOMICROID_Emptyitemtext");
               Combo_municipiomicroid_Onlyselectedvalues = cgiGet( "COMBO_MUNICIPIOMICROID_Onlyselectedvalues");
               Combo_municipiomicroid_Selectalltext = cgiGet( "COMBO_MUNICIPIOMICROID_Selectalltext");
               Combo_municipiomicroid_Multiplevaluesseparator = cgiGet( "COMBO_MUNICIPIOMICROID_Multiplevaluesseparator");
               Combo_municipiomicroid_Addnewoptiontext = cgiGet( "COMBO_MUNICIPIOMICROID_Addnewoptiontext");
               Combo_municipiomicroid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_MUNICIPIOMICROID_Gxcontroltype"), ",", "."), 18, MidpointRounding.ToEven));
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
               if ( ( ( context.localUtil.CToN( cgiGet( edtMunicipioID_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMunicipioID_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MUNICIPIOID");
                  AnyError = 1;
                  GX_FocusControl = edtMunicipioID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A35MunicipioID = 0;
                  AssignAttri("", false, "A35MunicipioID", StringUtil.LTrimStr( (decimal)(A35MunicipioID), 9, 0));
               }
               else
               {
                  A35MunicipioID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtMunicipioID_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A35MunicipioID", StringUtil.LTrimStr( (decimal)(A35MunicipioID), 9, 0));
               }
               A36MunicipioNome = cgiGet( edtMunicipioNome_Internalname);
               AssignAttri("", false, "A36MunicipioNome", A36MunicipioNome);
               if ( ( ( context.localUtil.CToN( cgiGet( edtMunicipioMicroID_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMunicipioMicroID_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MUNICIPIOMICROID");
                  AnyError = 1;
                  GX_FocusControl = edtMunicipioMicroID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A37MunicipioMicroID = 0;
                  AssignAttri("", false, "A37MunicipioMicroID", StringUtil.LTrimStr( (decimal)(A37MunicipioMicroID), 9, 0));
               }
               else
               {
                  A37MunicipioMicroID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtMunicipioMicroID_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A37MunicipioMicroID", StringUtil.LTrimStr( (decimal)(A37MunicipioMicroID), 9, 0));
               }
               A39MunicipioMicroMesoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtMunicipioMicroMesoID_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A39MunicipioMicroMesoID", StringUtil.LTrimStr( (decimal)(A39MunicipioMicroMesoID), 9, 0));
               A41MunicipioMicroMesoUFID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtMunicipioMicroMesoUFID_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               n41MunicipioMicroMesoUFID = false;
               AssignAttri("", false, "A41MunicipioMicroMesoUFID", StringUtil.LTrimStr( (decimal)(A41MunicipioMicroMesoUFID), 9, 0));
               A45MunicipioMicroMesoUFRegID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtMunicipioMicroMesoUFRegID_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               n45MunicipioMicroMesoUFRegID = false;
               AssignAttri("", false, "A45MunicipioMicroMesoUFRegID", StringUtil.LTrimStr( (decimal)(A45MunicipioMicroMesoUFRegID), 9, 0));
               AV20ComboMunicipioMicroID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavCombomunicipiomicroid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV20ComboMunicipioMicroID", StringUtil.LTrimStr( (decimal)(AV20ComboMunicipioMicroID), 9, 0));
               A40MunicipioMicroMesoNome = cgiGet( edtMunicipioMicroMesoNome_Internalname);
               n40MunicipioMicroMesoNome = false;
               AssignAttri("", false, "A40MunicipioMicroMesoNome", A40MunicipioMicroMesoNome);
               A42MunicipioMicroMesoUFSigla = StringUtil.Upper( cgiGet( edtMunicipioMicroMesoUFSigla_Internalname));
               n42MunicipioMicroMesoUFSigla = false;
               AssignAttri("", false, "A42MunicipioMicroMesoUFSigla", A42MunicipioMicroMesoUFSigla);
               A43MunicipioMicroMesoUFNome = cgiGet( edtMunicipioMicroMesoUFNome_Internalname);
               n43MunicipioMicroMesoUFNome = false;
               AssignAttri("", false, "A43MunicipioMicroMesoUFNome", A43MunicipioMicroMesoUFNome);
               A44MunicipioMicroMesoUFSiglaNome = cgiGet( edtMunicipioMicroMesoUFSiglaNome_Internalname);
               n44MunicipioMicroMesoUFSiglaNome = false;
               AssignAttri("", false, "A44MunicipioMicroMesoUFSiglaNome", A44MunicipioMicroMesoUFSiglaNome);
               A46MunicipioMicroMesoUFRegSigla = StringUtil.Upper( cgiGet( edtMunicipioMicroMesoUFRegSigla_Internalname));
               n46MunicipioMicroMesoUFRegSigla = false;
               AssignAttri("", false, "A46MunicipioMicroMesoUFRegSigla", A46MunicipioMicroMesoUFRegSigla);
               A47MunicipioMicroMesoUFRegNome = cgiGet( edtMunicipioMicroMesoUFRegNome_Internalname);
               n47MunicipioMicroMesoUFRegNome = false;
               AssignAttri("", false, "A47MunicipioMicroMesoUFRegNome", A47MunicipioMicroMesoUFRegNome);
               A48MunicipioMicroMesoUFRegSiglaNo = cgiGet( edtMunicipioMicroMesoUFRegSiglaNo_Internalname);
               n48MunicipioMicroMesoUFRegSiglaNo = false;
               AssignAttri("", false, "A48MunicipioMicroMesoUFRegSiglaNo", A48MunicipioMicroMesoUFRegSiglaNo);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"municipio");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A35MunicipioID != Z35MunicipioID ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("core\\municipio:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A35MunicipioID = (int)(Math.Round(NumberUtil.Val( GetPar( "MunicipioID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A35MunicipioID", StringUtil.LTrimStr( (decimal)(A35MunicipioID), 9, 0));
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
                     sMode5 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode5;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound5 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_050( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "MUNICIPIOID");
                        AnyError = 1;
                        GX_FocusControl = edtMunicipioID_Internalname;
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
                           E11052 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12052 ();
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
            E12052 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll055( ) ;
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
            DisableAttributes055( ) ;
         }
         AssignProp("", false, edtavCombomunicipiomicroid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombomunicipiomicroid_Enabled), 5, 0), true);
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

      protected void CONFIRM_050( )
      {
         BeforeValidate055( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls055( ) ;
            }
            else
            {
               CheckExtendedTable055( ) ;
               CloseExtendedTableCursors055( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption050( )
      {
      }

      protected void E11052( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV16DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV16DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         AV22GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV23GAMErrors);
         Combo_municipiomicroid_Gamoauthtoken = AV22GAMSession.gxTpr_Token;
         ucCombo_municipiomicroid.SendProperty(context, "", false, Combo_municipiomicroid_Internalname, "GAMOAuthToken", Combo_municipiomicroid_Gamoauthtoken);
         edtMunicipioMicroID_Visible = 0;
         AssignProp("", false, edtMunicipioMicroID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMunicipioMicroID_Visible), 5, 0), true);
         AV20ComboMunicipioMicroID = 0;
         AssignAttri("", false, "AV20ComboMunicipioMicroID", StringUtil.LTrimStr( (decimal)(AV20ComboMunicipioMicroID), 9, 0));
         edtavCombomunicipiomicroid_Visible = 0;
         AssignProp("", false, edtavCombomunicipiomicroid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombomunicipiomicroid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOMUNICIPIOMICROID' */
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
               if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "MunicipioMicroID") == 0 )
               {
                  AV13Insert_MunicipioMicroID = (int)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV13Insert_MunicipioMicroID", StringUtil.LTrimStr( (decimal)(AV13Insert_MunicipioMicroID), 9, 0));
                  if ( ! (0==AV13Insert_MunicipioMicroID) )
                  {
                     AV20ComboMunicipioMicroID = AV13Insert_MunicipioMicroID;
                     AssignAttri("", false, "AV20ComboMunicipioMicroID", StringUtil.LTrimStr( (decimal)(AV20ComboMunicipioMicroID), 9, 0));
                     Combo_municipiomicroid_Selectedvalue_set = StringUtil.Trim( StringUtil.Str( (decimal)(AV20ComboMunicipioMicroID), 9, 0));
                     ucCombo_municipiomicroid.SendProperty(context, "", false, Combo_municipiomicroid_Internalname, "SelectedValue_set", Combo_municipiomicroid_Selectedvalue_set);
                     GXt_char2 = AV19Combo_DataJson;
                     new GeneXus.Programs.core.municipioloaddvcombo(context ).execute(  "MunicipioMicroID",  "GET",  false,  AV7MunicipioID,  AV14TrnContextAtt.gxTpr_Attributevalue, out  AV17ComboSelectedValue, out  AV18ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV17ComboSelectedValue", AV17ComboSelectedValue);
                     AssignAttri("", false, "AV18ComboSelectedText", AV18ComboSelectedText);
                     AV19Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV19Combo_DataJson", AV19Combo_DataJson);
                     Combo_municipiomicroid_Selectedtext_set = AV18ComboSelectedText;
                     ucCombo_municipiomicroid.SendProperty(context, "", false, Combo_municipiomicroid_Internalname, "SelectedText_set", Combo_municipiomicroid_Selectedtext_set);
                     Combo_municipiomicroid_Enabled = false;
                     ucCombo_municipiomicroid.SendProperty(context, "", false, Combo_municipiomicroid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_municipiomicroid_Enabled));
                  }
               }
               AV26GXV1 = (int)(AV26GXV1+1);
               AssignAttri("", false, "AV26GXV1", StringUtil.LTrimStr( (decimal)(AV26GXV1), 8, 0));
            }
         }
         edtMunicipioMicroMesoNome_Visible = 0;
         AssignProp("", false, edtMunicipioMicroMesoNome_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMunicipioMicroMesoNome_Visible), 5, 0), true);
         edtMunicipioMicroMesoUFSigla_Visible = 0;
         AssignProp("", false, edtMunicipioMicroMesoUFSigla_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMunicipioMicroMesoUFSigla_Visible), 5, 0), true);
         edtMunicipioMicroMesoUFNome_Visible = 0;
         AssignProp("", false, edtMunicipioMicroMesoUFNome_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMunicipioMicroMesoUFNome_Visible), 5, 0), true);
         edtMunicipioMicroMesoUFSiglaNome_Visible = 0;
         AssignProp("", false, edtMunicipioMicroMesoUFSiglaNome_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMunicipioMicroMesoUFSiglaNome_Visible), 5, 0), true);
         edtMunicipioMicroMesoUFRegSigla_Visible = 0;
         AssignProp("", false, edtMunicipioMicroMesoUFRegSigla_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMunicipioMicroMesoUFRegSigla_Visible), 5, 0), true);
         edtMunicipioMicroMesoUFRegNome_Visible = 0;
         AssignProp("", false, edtMunicipioMicroMesoUFRegNome_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMunicipioMicroMesoUFRegNome_Visible), 5, 0), true);
         edtMunicipioMicroMesoUFRegSiglaNo_Visible = 0;
         AssignProp("", false, edtMunicipioMicroMesoUFRegSiglaNo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMunicipioMicroMesoUFRegSiglaNo_Visible), 5, 0), true);
      }

      protected void E12052( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("core.municipioww.aspx") );
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
         /* 'LOADCOMBOMUNICIPIOMICROID' Routine */
         returnInSub = false;
         GXt_char2 = AV19Combo_DataJson;
         new GeneXus.Programs.core.municipioloaddvcombo(context ).execute(  "MunicipioMicroID",  Gx_mode,  false,  AV7MunicipioID,  "", out  AV17ComboSelectedValue, out  AV18ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV17ComboSelectedValue", AV17ComboSelectedValue);
         AssignAttri("", false, "AV18ComboSelectedText", AV18ComboSelectedText);
         AV19Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV19Combo_DataJson", AV19Combo_DataJson);
         Combo_municipiomicroid_Selectedvalue_set = AV17ComboSelectedValue;
         ucCombo_municipiomicroid.SendProperty(context, "", false, Combo_municipiomicroid_Internalname, "SelectedValue_set", Combo_municipiomicroid_Selectedvalue_set);
         Combo_municipiomicroid_Selectedtext_set = AV18ComboSelectedText;
         ucCombo_municipiomicroid.SendProperty(context, "", false, Combo_municipiomicroid_Internalname, "SelectedText_set", Combo_municipiomicroid_Selectedtext_set);
         AV20ComboMunicipioMicroID = (int)(Math.Round(NumberUtil.Val( AV17ComboSelectedValue, "."), 18, MidpointRounding.ToEven));
         AssignAttri("", false, "AV20ComboMunicipioMicroID", StringUtil.LTrimStr( (decimal)(AV20ComboMunicipioMicroID), 9, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_municipiomicroid_Enabled = false;
            ucCombo_municipiomicroid.SendProperty(context, "", false, Combo_municipiomicroid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_municipiomicroid_Enabled));
         }
      }

      protected void ZM055( short GX_JID )
      {
         if ( ( GX_JID == 11 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z44MunicipioMicroMesoUFSiglaNome = T00053_A44MunicipioMicroMesoUFSiglaNome[0];
               Z48MunicipioMicroMesoUFRegSiglaNo = T00053_A48MunicipioMicroMesoUFRegSiglaNo[0];
               Z36MunicipioNome = T00053_A36MunicipioNome[0];
               Z37MunicipioMicroID = T00053_A37MunicipioMicroID[0];
            }
            else
            {
               Z44MunicipioMicroMesoUFSiglaNome = A44MunicipioMicroMesoUFSiglaNome;
               Z48MunicipioMicroMesoUFRegSiglaNo = A48MunicipioMicroMesoUFRegSiglaNo;
               Z36MunicipioNome = A36MunicipioNome;
               Z37MunicipioMicroID = A37MunicipioMicroID;
            }
         }
         if ( GX_JID == -11 )
         {
            Z44MunicipioMicroMesoUFSiglaNome = A44MunicipioMicroMesoUFSiglaNome;
            Z48MunicipioMicroMesoUFRegSiglaNo = A48MunicipioMicroMesoUFRegSiglaNo;
            Z35MunicipioID = A35MunicipioID;
            Z36MunicipioNome = A36MunicipioNome;
            Z38MunicipioMicroNome = A38MunicipioMicroNome;
            Z39MunicipioMicroMesoID = A39MunicipioMicroMesoID;
            Z40MunicipioMicroMesoNome = A40MunicipioMicroMesoNome;
            Z41MunicipioMicroMesoUFID = A41MunicipioMicroMesoUFID;
            Z42MunicipioMicroMesoUFSigla = A42MunicipioMicroMesoUFSigla;
            Z43MunicipioMicroMesoUFNome = A43MunicipioMicroMesoUFNome;
            Z45MunicipioMicroMesoUFRegID = A45MunicipioMicroMesoUFRegID;
            Z46MunicipioMicroMesoUFRegSigla = A46MunicipioMicroMesoUFRegSigla;
            Z47MunicipioMicroMesoUFRegNome = A47MunicipioMicroMesoUFRegNome;
            Z37MunicipioMicroID = A37MunicipioMicroID;
         }
      }

      protected void standaloneNotModal( )
      {
         AV25Pgmname = "core.municipio";
         AssignAttri("", false, "AV25Pgmname", AV25Pgmname);
         if ( ! (0==AV7MunicipioID) )
         {
            A35MunicipioID = AV7MunicipioID;
            AssignAttri("", false, "A35MunicipioID", StringUtil.LTrimStr( (decimal)(A35MunicipioID), 9, 0));
         }
         if ( ! (0==AV7MunicipioID) )
         {
            edtMunicipioID_Enabled = 0;
            AssignProp("", false, edtMunicipioID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMunicipioID_Enabled), 5, 0), true);
         }
         else
         {
            edtMunicipioID_Enabled = 1;
            AssignProp("", false, edtMunicipioID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMunicipioID_Enabled), 5, 0), true);
         }
         if ( ! (0==AV7MunicipioID) )
         {
            edtMunicipioID_Enabled = 0;
            AssignProp("", false, edtMunicipioID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMunicipioID_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_MunicipioMicroID) )
         {
            edtMunicipioMicroID_Enabled = 0;
            AssignProp("", false, edtMunicipioMicroID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMunicipioMicroID_Enabled), 5, 0), true);
         }
         else
         {
            edtMunicipioMicroID_Enabled = 1;
            AssignProp("", false, edtMunicipioMicroID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMunicipioMicroID_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_MunicipioMicroID) )
         {
            A37MunicipioMicroID = AV13Insert_MunicipioMicroID;
            AssignAttri("", false, "A37MunicipioMicroID", StringUtil.LTrimStr( (decimal)(A37MunicipioMicroID), 9, 0));
         }
         else
         {
            A37MunicipioMicroID = AV20ComboMunicipioMicroID;
            AssignAttri("", false, "A37MunicipioMicroID", StringUtil.LTrimStr( (decimal)(A37MunicipioMicroID), 9, 0));
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
            /* Using cursor T00054 */
            pr_default.execute(2, new Object[] {A37MunicipioMicroID});
            A38MunicipioMicroNome = T00054_A38MunicipioMicroNome[0];
            A39MunicipioMicroMesoID = T00054_A39MunicipioMicroMesoID[0];
            AssignAttri("", false, "A39MunicipioMicroMesoID", StringUtil.LTrimStr( (decimal)(A39MunicipioMicroMesoID), 9, 0));
            pr_default.close(2);
            /* Using cursor T00055 */
            pr_default.execute(3, new Object[] {A39MunicipioMicroMesoID});
            A40MunicipioMicroMesoNome = T00055_A40MunicipioMicroMesoNome[0];
            n40MunicipioMicroMesoNome = T00055_n40MunicipioMicroMesoNome[0];
            AssignAttri("", false, "A40MunicipioMicroMesoNome", A40MunicipioMicroMesoNome);
            A41MunicipioMicroMesoUFID = T00055_A41MunicipioMicroMesoUFID[0];
            n41MunicipioMicroMesoUFID = T00055_n41MunicipioMicroMesoUFID[0];
            AssignAttri("", false, "A41MunicipioMicroMesoUFID", StringUtil.LTrimStr( (decimal)(A41MunicipioMicroMesoUFID), 9, 0));
            pr_default.close(3);
            /* Using cursor T00056 */
            pr_default.execute(4, new Object[] {n41MunicipioMicroMesoUFID, A41MunicipioMicroMesoUFID});
            A42MunicipioMicroMesoUFSigla = T00056_A42MunicipioMicroMesoUFSigla[0];
            n42MunicipioMicroMesoUFSigla = T00056_n42MunicipioMicroMesoUFSigla[0];
            AssignAttri("", false, "A42MunicipioMicroMesoUFSigla", A42MunicipioMicroMesoUFSigla);
            A43MunicipioMicroMesoUFNome = T00056_A43MunicipioMicroMesoUFNome[0];
            n43MunicipioMicroMesoUFNome = T00056_n43MunicipioMicroMesoUFNome[0];
            AssignAttri("", false, "A43MunicipioMicroMesoUFNome", A43MunicipioMicroMesoUFNome);
            A45MunicipioMicroMesoUFRegID = T00056_A45MunicipioMicroMesoUFRegID[0];
            n45MunicipioMicroMesoUFRegID = T00056_n45MunicipioMicroMesoUFRegID[0];
            AssignAttri("", false, "A45MunicipioMicroMesoUFRegID", StringUtil.LTrimStr( (decimal)(A45MunicipioMicroMesoUFRegID), 9, 0));
            pr_default.close(4);
            A44MunicipioMicroMesoUFSiglaNome = StringUtil.Trim( A42MunicipioMicroMesoUFSigla) + " - " + StringUtil.Trim( A43MunicipioMicroMesoUFNome);
            n44MunicipioMicroMesoUFSiglaNome = false;
            AssignAttri("", false, "A44MunicipioMicroMesoUFSiglaNome", A44MunicipioMicroMesoUFSiglaNome);
            /* Using cursor T00057 */
            pr_default.execute(5, new Object[] {n45MunicipioMicroMesoUFRegID, A45MunicipioMicroMesoUFRegID});
            A46MunicipioMicroMesoUFRegSigla = T00057_A46MunicipioMicroMesoUFRegSigla[0];
            n46MunicipioMicroMesoUFRegSigla = T00057_n46MunicipioMicroMesoUFRegSigla[0];
            AssignAttri("", false, "A46MunicipioMicroMesoUFRegSigla", A46MunicipioMicroMesoUFRegSigla);
            A47MunicipioMicroMesoUFRegNome = T00057_A47MunicipioMicroMesoUFRegNome[0];
            n47MunicipioMicroMesoUFRegNome = T00057_n47MunicipioMicroMesoUFRegNome[0];
            AssignAttri("", false, "A47MunicipioMicroMesoUFRegNome", A47MunicipioMicroMesoUFRegNome);
            pr_default.close(5);
            A48MunicipioMicroMesoUFRegSiglaNo = StringUtil.Trim( A46MunicipioMicroMesoUFRegSigla) + " - " + StringUtil.Trim( A47MunicipioMicroMesoUFRegNome);
            n48MunicipioMicroMesoUFRegSiglaNo = false;
            AssignAttri("", false, "A48MunicipioMicroMesoUFRegSiglaNo", A48MunicipioMicroMesoUFRegSiglaNo);
         }
      }

      protected void Load055( )
      {
         /* Using cursor T00058 */
         pr_default.execute(6, new Object[] {A35MunicipioID});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound5 = 1;
            A44MunicipioMicroMesoUFSiglaNome = T00058_A44MunicipioMicroMesoUFSiglaNome[0];
            n44MunicipioMicroMesoUFSiglaNome = T00058_n44MunicipioMicroMesoUFSiglaNome[0];
            AssignAttri("", false, "A44MunicipioMicroMesoUFSiglaNome", A44MunicipioMicroMesoUFSiglaNome);
            A48MunicipioMicroMesoUFRegSiglaNo = T00058_A48MunicipioMicroMesoUFRegSiglaNo[0];
            n48MunicipioMicroMesoUFRegSiglaNo = T00058_n48MunicipioMicroMesoUFRegSiglaNo[0];
            AssignAttri("", false, "A48MunicipioMicroMesoUFRegSiglaNo", A48MunicipioMicroMesoUFRegSiglaNo);
            A36MunicipioNome = T00058_A36MunicipioNome[0];
            AssignAttri("", false, "A36MunicipioNome", A36MunicipioNome);
            A38MunicipioMicroNome = T00058_A38MunicipioMicroNome[0];
            A39MunicipioMicroMesoID = T00058_A39MunicipioMicroMesoID[0];
            AssignAttri("", false, "A39MunicipioMicroMesoID", StringUtil.LTrimStr( (decimal)(A39MunicipioMicroMesoID), 9, 0));
            A40MunicipioMicroMesoNome = T00058_A40MunicipioMicroMesoNome[0];
            n40MunicipioMicroMesoNome = T00058_n40MunicipioMicroMesoNome[0];
            AssignAttri("", false, "A40MunicipioMicroMesoNome", A40MunicipioMicroMesoNome);
            A41MunicipioMicroMesoUFID = T00058_A41MunicipioMicroMesoUFID[0];
            n41MunicipioMicroMesoUFID = T00058_n41MunicipioMicroMesoUFID[0];
            AssignAttri("", false, "A41MunicipioMicroMesoUFID", StringUtil.LTrimStr( (decimal)(A41MunicipioMicroMesoUFID), 9, 0));
            A42MunicipioMicroMesoUFSigla = T00058_A42MunicipioMicroMesoUFSigla[0];
            n42MunicipioMicroMesoUFSigla = T00058_n42MunicipioMicroMesoUFSigla[0];
            AssignAttri("", false, "A42MunicipioMicroMesoUFSigla", A42MunicipioMicroMesoUFSigla);
            A43MunicipioMicroMesoUFNome = T00058_A43MunicipioMicroMesoUFNome[0];
            n43MunicipioMicroMesoUFNome = T00058_n43MunicipioMicroMesoUFNome[0];
            AssignAttri("", false, "A43MunicipioMicroMesoUFNome", A43MunicipioMicroMesoUFNome);
            A45MunicipioMicroMesoUFRegID = T00058_A45MunicipioMicroMesoUFRegID[0];
            n45MunicipioMicroMesoUFRegID = T00058_n45MunicipioMicroMesoUFRegID[0];
            AssignAttri("", false, "A45MunicipioMicroMesoUFRegID", StringUtil.LTrimStr( (decimal)(A45MunicipioMicroMesoUFRegID), 9, 0));
            A46MunicipioMicroMesoUFRegSigla = T00058_A46MunicipioMicroMesoUFRegSigla[0];
            n46MunicipioMicroMesoUFRegSigla = T00058_n46MunicipioMicroMesoUFRegSigla[0];
            AssignAttri("", false, "A46MunicipioMicroMesoUFRegSigla", A46MunicipioMicroMesoUFRegSigla);
            A47MunicipioMicroMesoUFRegNome = T00058_A47MunicipioMicroMesoUFRegNome[0];
            n47MunicipioMicroMesoUFRegNome = T00058_n47MunicipioMicroMesoUFRegNome[0];
            AssignAttri("", false, "A47MunicipioMicroMesoUFRegNome", A47MunicipioMicroMesoUFRegNome);
            A37MunicipioMicroID = T00058_A37MunicipioMicroID[0];
            AssignAttri("", false, "A37MunicipioMicroID", StringUtil.LTrimStr( (decimal)(A37MunicipioMicroID), 9, 0));
            ZM055( -11) ;
         }
         pr_default.close(6);
         OnLoadActions055( ) ;
      }

      protected void OnLoadActions055( )
      {
         A44MunicipioMicroMesoUFSiglaNome = StringUtil.Trim( A42MunicipioMicroMesoUFSigla) + " - " + StringUtil.Trim( A43MunicipioMicroMesoUFNome);
         n44MunicipioMicroMesoUFSiglaNome = false;
         AssignAttri("", false, "A44MunicipioMicroMesoUFSiglaNome", A44MunicipioMicroMesoUFSiglaNome);
         /* Using cursor T00057 */
         pr_default.execute(5, new Object[] {n45MunicipioMicroMesoUFRegID, A45MunicipioMicroMesoUFRegID});
         A46MunicipioMicroMesoUFRegSigla = T00057_A46MunicipioMicroMesoUFRegSigla[0];
         n46MunicipioMicroMesoUFRegSigla = T00057_n46MunicipioMicroMesoUFRegSigla[0];
         AssignAttri("", false, "A46MunicipioMicroMesoUFRegSigla", A46MunicipioMicroMesoUFRegSigla);
         A47MunicipioMicroMesoUFRegNome = T00057_A47MunicipioMicroMesoUFRegNome[0];
         n47MunicipioMicroMesoUFRegNome = T00057_n47MunicipioMicroMesoUFRegNome[0];
         AssignAttri("", false, "A47MunicipioMicroMesoUFRegNome", A47MunicipioMicroMesoUFRegNome);
         pr_default.close(5);
         A48MunicipioMicroMesoUFRegSiglaNo = StringUtil.Trim( A46MunicipioMicroMesoUFRegSigla) + " - " + StringUtil.Trim( A47MunicipioMicroMesoUFRegNome);
         n48MunicipioMicroMesoUFRegSiglaNo = false;
         AssignAttri("", false, "A48MunicipioMicroMesoUFRegSiglaNo", A48MunicipioMicroMesoUFRegSiglaNo);
      }

      protected void CheckExtendedTable055( )
      {
         nIsDirty_5 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T00054 */
         pr_default.execute(2, new Object[] {A37MunicipioMicroID});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("Não existe 'Microregiao -> Municipio'.", "ForeignKeyNotFound", 1, "MUNICIPIOMICROID");
            AnyError = 1;
            GX_FocusControl = edtMunicipioMicroID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A38MunicipioMicroNome = T00054_A38MunicipioMicroNome[0];
         A39MunicipioMicroMesoID = T00054_A39MunicipioMicroMesoID[0];
         AssignAttri("", false, "A39MunicipioMicroMesoID", StringUtil.LTrimStr( (decimal)(A39MunicipioMicroMesoID), 9, 0));
         pr_default.close(2);
         /* Using cursor T00055 */
         pr_default.execute(3, new Object[] {A39MunicipioMicroMesoID});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("Não existe 'tbibge_mesorregiao'.", "ForeignKeyNotFound", 1, "MUNICIPIOMICROMESOID");
            AnyError = 1;
         }
         A40MunicipioMicroMesoNome = T00055_A40MunicipioMicroMesoNome[0];
         n40MunicipioMicroMesoNome = T00055_n40MunicipioMicroMesoNome[0];
         AssignAttri("", false, "A40MunicipioMicroMesoNome", A40MunicipioMicroMesoNome);
         A41MunicipioMicroMesoUFID = T00055_A41MunicipioMicroMesoUFID[0];
         n41MunicipioMicroMesoUFID = T00055_n41MunicipioMicroMesoUFID[0];
         AssignAttri("", false, "A41MunicipioMicroMesoUFID", StringUtil.LTrimStr( (decimal)(A41MunicipioMicroMesoUFID), 9, 0));
         pr_default.close(3);
         /* Using cursor T00056 */
         pr_default.execute(4, new Object[] {n41MunicipioMicroMesoUFID, A41MunicipioMicroMesoUFID});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("Não existe 'Unidade Federativa (Estado)'.", "ForeignKeyNotFound", 1, "MUNICIPIOMICROMESOUFID");
            AnyError = 1;
         }
         A42MunicipioMicroMesoUFSigla = T00056_A42MunicipioMicroMesoUFSigla[0];
         n42MunicipioMicroMesoUFSigla = T00056_n42MunicipioMicroMesoUFSigla[0];
         AssignAttri("", false, "A42MunicipioMicroMesoUFSigla", A42MunicipioMicroMesoUFSigla);
         A43MunicipioMicroMesoUFNome = T00056_A43MunicipioMicroMesoUFNome[0];
         n43MunicipioMicroMesoUFNome = T00056_n43MunicipioMicroMesoUFNome[0];
         AssignAttri("", false, "A43MunicipioMicroMesoUFNome", A43MunicipioMicroMesoUFNome);
         A45MunicipioMicroMesoUFRegID = T00056_A45MunicipioMicroMesoUFRegID[0];
         n45MunicipioMicroMesoUFRegID = T00056_n45MunicipioMicroMesoUFRegID[0];
         AssignAttri("", false, "A45MunicipioMicroMesoUFRegID", StringUtil.LTrimStr( (decimal)(A45MunicipioMicroMesoUFRegID), 9, 0));
         pr_default.close(4);
         nIsDirty_5 = 1;
         A44MunicipioMicroMesoUFSiglaNome = StringUtil.Trim( A42MunicipioMicroMesoUFSigla) + " - " + StringUtil.Trim( A43MunicipioMicroMesoUFNome);
         n44MunicipioMicroMesoUFSiglaNome = false;
         AssignAttri("", false, "A44MunicipioMicroMesoUFSiglaNome", A44MunicipioMicroMesoUFSiglaNome);
         /* Using cursor T00057 */
         pr_default.execute(5, new Object[] {n45MunicipioMicroMesoUFRegID, A45MunicipioMicroMesoUFRegID});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("Não existe 'Região'.", "ForeignKeyNotFound", 1, "MUNICIPIOMICROMESOUFREGID");
            AnyError = 1;
         }
         A46MunicipioMicroMesoUFRegSigla = T00057_A46MunicipioMicroMesoUFRegSigla[0];
         n46MunicipioMicroMesoUFRegSigla = T00057_n46MunicipioMicroMesoUFRegSigla[0];
         AssignAttri("", false, "A46MunicipioMicroMesoUFRegSigla", A46MunicipioMicroMesoUFRegSigla);
         A47MunicipioMicroMesoUFRegNome = T00057_A47MunicipioMicroMesoUFRegNome[0];
         n47MunicipioMicroMesoUFRegNome = T00057_n47MunicipioMicroMesoUFRegNome[0];
         AssignAttri("", false, "A47MunicipioMicroMesoUFRegNome", A47MunicipioMicroMesoUFRegNome);
         pr_default.close(5);
         nIsDirty_5 = 1;
         A48MunicipioMicroMesoUFRegSiglaNo = StringUtil.Trim( A46MunicipioMicroMesoUFRegSigla) + " - " + StringUtil.Trim( A47MunicipioMicroMesoUFRegNome);
         n48MunicipioMicroMesoUFRegSiglaNo = false;
         AssignAttri("", false, "A48MunicipioMicroMesoUFRegSiglaNo", A48MunicipioMicroMesoUFRegSiglaNo);
      }

      protected void CloseExtendedTableCursors055( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
         pr_default.close(5);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_12( int A37MunicipioMicroID )
      {
         /* Using cursor T00059 */
         pr_default.execute(7, new Object[] {A37MunicipioMicroID});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem("Não existe 'Microregiao -> Municipio'.", "ForeignKeyNotFound", 1, "MUNICIPIOMICROID");
            AnyError = 1;
            GX_FocusControl = edtMunicipioMicroID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A38MunicipioMicroNome = T00059_A38MunicipioMicroNome[0];
         A39MunicipioMicroMesoID = T00059_A39MunicipioMicroMesoID[0];
         AssignAttri("", false, "A39MunicipioMicroMesoID", StringUtil.LTrimStr( (decimal)(A39MunicipioMicroMesoID), 9, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A38MunicipioMicroNome)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A39MunicipioMicroMesoID), 9, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void gxLoad_13( int A39MunicipioMicroMesoID )
      {
         /* Using cursor T000510 */
         pr_default.execute(8, new Object[] {A39MunicipioMicroMesoID});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("Não existe 'tbibge_mesorregiao'.", "ForeignKeyNotFound", 1, "MUNICIPIOMICROMESOID");
            AnyError = 1;
         }
         A40MunicipioMicroMesoNome = T000510_A40MunicipioMicroMesoNome[0];
         n40MunicipioMicroMesoNome = T000510_n40MunicipioMicroMesoNome[0];
         AssignAttri("", false, "A40MunicipioMicroMesoNome", A40MunicipioMicroMesoNome);
         A41MunicipioMicroMesoUFID = T000510_A41MunicipioMicroMesoUFID[0];
         n41MunicipioMicroMesoUFID = T000510_n41MunicipioMicroMesoUFID[0];
         AssignAttri("", false, "A41MunicipioMicroMesoUFID", StringUtil.LTrimStr( (decimal)(A41MunicipioMicroMesoUFID), 9, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A40MunicipioMicroMesoNome)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A41MunicipioMicroMesoUFID), 9, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void gxLoad_14( int A41MunicipioMicroMesoUFID )
      {
         /* Using cursor T000511 */
         pr_default.execute(9, new Object[] {n41MunicipioMicroMesoUFID, A41MunicipioMicroMesoUFID});
         if ( (pr_default.getStatus(9) == 101) )
         {
            GX_msglist.addItem("Não existe 'Unidade Federativa (Estado)'.", "ForeignKeyNotFound", 1, "MUNICIPIOMICROMESOUFID");
            AnyError = 1;
         }
         A42MunicipioMicroMesoUFSigla = T000511_A42MunicipioMicroMesoUFSigla[0];
         n42MunicipioMicroMesoUFSigla = T000511_n42MunicipioMicroMesoUFSigla[0];
         AssignAttri("", false, "A42MunicipioMicroMesoUFSigla", A42MunicipioMicroMesoUFSigla);
         A43MunicipioMicroMesoUFNome = T000511_A43MunicipioMicroMesoUFNome[0];
         n43MunicipioMicroMesoUFNome = T000511_n43MunicipioMicroMesoUFNome[0];
         AssignAttri("", false, "A43MunicipioMicroMesoUFNome", A43MunicipioMicroMesoUFNome);
         A45MunicipioMicroMesoUFRegID = T000511_A45MunicipioMicroMesoUFRegID[0];
         n45MunicipioMicroMesoUFRegID = T000511_n45MunicipioMicroMesoUFRegID[0];
         AssignAttri("", false, "A45MunicipioMicroMesoUFRegID", StringUtil.LTrimStr( (decimal)(A45MunicipioMicroMesoUFRegID), 9, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A42MunicipioMicroMesoUFSigla)+"\""+","+"\""+GXUtil.EncodeJSConstant( A43MunicipioMicroMesoUFNome)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A45MunicipioMicroMesoUFRegID), 9, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(9) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(9);
      }

      protected void gxLoad_15( int A45MunicipioMicroMesoUFRegID )
      {
         /* Using cursor T000512 */
         pr_default.execute(10, new Object[] {n45MunicipioMicroMesoUFRegID, A45MunicipioMicroMesoUFRegID});
         if ( (pr_default.getStatus(10) == 101) )
         {
            GX_msglist.addItem("Não existe 'Região'.", "ForeignKeyNotFound", 1, "MUNICIPIOMICROMESOUFREGID");
            AnyError = 1;
         }
         A46MunicipioMicroMesoUFRegSigla = T000512_A46MunicipioMicroMesoUFRegSigla[0];
         n46MunicipioMicroMesoUFRegSigla = T000512_n46MunicipioMicroMesoUFRegSigla[0];
         AssignAttri("", false, "A46MunicipioMicroMesoUFRegSigla", A46MunicipioMicroMesoUFRegSigla);
         A47MunicipioMicroMesoUFRegNome = T000512_A47MunicipioMicroMesoUFRegNome[0];
         n47MunicipioMicroMesoUFRegNome = T000512_n47MunicipioMicroMesoUFRegNome[0];
         AssignAttri("", false, "A47MunicipioMicroMesoUFRegNome", A47MunicipioMicroMesoUFRegNome);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A46MunicipioMicroMesoUFRegSigla)+"\""+","+"\""+GXUtil.EncodeJSConstant( A47MunicipioMicroMesoUFRegNome)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(10) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(10);
      }

      protected void GetKey055( )
      {
         /* Using cursor T000513 */
         pr_default.execute(11, new Object[] {A35MunicipioID});
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound5 = 1;
         }
         else
         {
            RcdFound5 = 0;
         }
         pr_default.close(11);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00053 */
         pr_default.execute(1, new Object[] {A35MunicipioID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM055( 11) ;
            RcdFound5 = 1;
            A35MunicipioID = T00053_A35MunicipioID[0];
            AssignAttri("", false, "A35MunicipioID", StringUtil.LTrimStr( (decimal)(A35MunicipioID), 9, 0));
            A36MunicipioNome = T00053_A36MunicipioNome[0];
            AssignAttri("", false, "A36MunicipioNome", A36MunicipioNome);
            A37MunicipioMicroID = T00053_A37MunicipioMicroID[0];
            AssignAttri("", false, "A37MunicipioMicroID", StringUtil.LTrimStr( (decimal)(A37MunicipioMicroID), 9, 0));
            A44MunicipioMicroMesoUFSiglaNome = T00053_A44MunicipioMicroMesoUFSiglaNome[0];
            n44MunicipioMicroMesoUFSiglaNome = T00053_n44MunicipioMicroMesoUFSiglaNome[0];
            AssignAttri("", false, "A44MunicipioMicroMesoUFSiglaNome", A44MunicipioMicroMesoUFSiglaNome);
            A48MunicipioMicroMesoUFRegSiglaNo = T00053_A48MunicipioMicroMesoUFRegSiglaNo[0];
            n48MunicipioMicroMesoUFRegSiglaNo = T00053_n48MunicipioMicroMesoUFRegSiglaNo[0];
            AssignAttri("", false, "A48MunicipioMicroMesoUFRegSiglaNo", A48MunicipioMicroMesoUFRegSiglaNo);
            Z35MunicipioID = A35MunicipioID;
            sMode5 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load055( ) ;
            if ( AnyError == 1 )
            {
               RcdFound5 = 0;
               InitializeNonKey055( ) ;
            }
            Gx_mode = sMode5;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound5 = 0;
            InitializeNonKey055( ) ;
            sMode5 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode5;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey055( ) ;
         if ( RcdFound5 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound5 = 0;
         /* Using cursor T000514 */
         pr_default.execute(12, new Object[] {A35MunicipioID});
         if ( (pr_default.getStatus(12) != 101) )
         {
            while ( (pr_default.getStatus(12) != 101) && ( ( T000514_A35MunicipioID[0] < A35MunicipioID ) ) )
            {
               pr_default.readNext(12);
            }
            if ( (pr_default.getStatus(12) != 101) && ( ( T000514_A35MunicipioID[0] > A35MunicipioID ) ) )
            {
               A35MunicipioID = T000514_A35MunicipioID[0];
               AssignAttri("", false, "A35MunicipioID", StringUtil.LTrimStr( (decimal)(A35MunicipioID), 9, 0));
               RcdFound5 = 1;
            }
         }
         pr_default.close(12);
      }

      protected void move_previous( )
      {
         RcdFound5 = 0;
         /* Using cursor T000515 */
         pr_default.execute(13, new Object[] {A35MunicipioID});
         if ( (pr_default.getStatus(13) != 101) )
         {
            while ( (pr_default.getStatus(13) != 101) && ( ( T000515_A35MunicipioID[0] > A35MunicipioID ) ) )
            {
               pr_default.readNext(13);
            }
            if ( (pr_default.getStatus(13) != 101) && ( ( T000515_A35MunicipioID[0] < A35MunicipioID ) ) )
            {
               A35MunicipioID = T000515_A35MunicipioID[0];
               AssignAttri("", false, "A35MunicipioID", StringUtil.LTrimStr( (decimal)(A35MunicipioID), 9, 0));
               RcdFound5 = 1;
            }
         }
         pr_default.close(13);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey055( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtMunicipioID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert055( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound5 == 1 )
            {
               if ( A35MunicipioID != Z35MunicipioID )
               {
                  A35MunicipioID = Z35MunicipioID;
                  AssignAttri("", false, "A35MunicipioID", StringUtil.LTrimStr( (decimal)(A35MunicipioID), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "MUNICIPIOID");
                  AnyError = 1;
                  GX_FocusControl = edtMunicipioID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtMunicipioID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update055( ) ;
                  GX_FocusControl = edtMunicipioID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A35MunicipioID != Z35MunicipioID )
               {
                  /* Insert record */
                  GX_FocusControl = edtMunicipioID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert055( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "MUNICIPIOID");
                     AnyError = 1;
                     GX_FocusControl = edtMunicipioID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtMunicipioID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert055( ) ;
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
         if ( A35MunicipioID != Z35MunicipioID )
         {
            A35MunicipioID = Z35MunicipioID;
            AssignAttri("", false, "A35MunicipioID", StringUtil.LTrimStr( (decimal)(A35MunicipioID), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "MUNICIPIOID");
            AnyError = 1;
            GX_FocusControl = edtMunicipioID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtMunicipioID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency055( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00052 */
            pr_default.execute(0, new Object[] {A35MunicipioID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tbibge_municipio"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z44MunicipioMicroMesoUFSiglaNome, T00052_A44MunicipioMicroMesoUFSiglaNome[0]) != 0 ) || ( StringUtil.StrCmp(Z48MunicipioMicroMesoUFRegSiglaNo, T00052_A48MunicipioMicroMesoUFRegSiglaNo[0]) != 0 ) || ( StringUtil.StrCmp(Z36MunicipioNome, T00052_A36MunicipioNome[0]) != 0 ) || ( Z37MunicipioMicroID != T00052_A37MunicipioMicroID[0] ) )
            {
               if ( StringUtil.StrCmp(Z44MunicipioMicroMesoUFSiglaNome, T00052_A44MunicipioMicroMesoUFSiglaNome[0]) != 0 )
               {
                  GXUtil.WriteLog("core.municipio:[seudo value changed for attri]"+"MunicipioMicroMesoUFSiglaNome");
                  GXUtil.WriteLogRaw("Old: ",Z44MunicipioMicroMesoUFSiglaNome);
                  GXUtil.WriteLogRaw("Current: ",T00052_A44MunicipioMicroMesoUFSiglaNome[0]);
               }
               if ( StringUtil.StrCmp(Z48MunicipioMicroMesoUFRegSiglaNo, T00052_A48MunicipioMicroMesoUFRegSiglaNo[0]) != 0 )
               {
                  GXUtil.WriteLog("core.municipio:[seudo value changed for attri]"+"MunicipioMicroMesoUFRegSiglaNo");
                  GXUtil.WriteLogRaw("Old: ",Z48MunicipioMicroMesoUFRegSiglaNo);
                  GXUtil.WriteLogRaw("Current: ",T00052_A48MunicipioMicroMesoUFRegSiglaNo[0]);
               }
               if ( StringUtil.StrCmp(Z36MunicipioNome, T00052_A36MunicipioNome[0]) != 0 )
               {
                  GXUtil.WriteLog("core.municipio:[seudo value changed for attri]"+"MunicipioNome");
                  GXUtil.WriteLogRaw("Old: ",Z36MunicipioNome);
                  GXUtil.WriteLogRaw("Current: ",T00052_A36MunicipioNome[0]);
               }
               if ( Z37MunicipioMicroID != T00052_A37MunicipioMicroID[0] )
               {
                  GXUtil.WriteLog("core.municipio:[seudo value changed for attri]"+"MunicipioMicroID");
                  GXUtil.WriteLogRaw("Old: ",Z37MunicipioMicroID);
                  GXUtil.WriteLogRaw("Current: ",T00052_A37MunicipioMicroID[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"tbibge_municipio"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert055( )
      {
         if ( ! IsAuthorized("municipio_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate055( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable055( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM055( 0) ;
            CheckOptimisticConcurrency055( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm055( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert055( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000516 */
                     pr_default.execute(14, new Object[] {A38MunicipioMicroNome, A39MunicipioMicroMesoID, n40MunicipioMicroMesoNome, A40MunicipioMicroMesoNome, n41MunicipioMicroMesoUFID, A41MunicipioMicroMesoUFID, n42MunicipioMicroMesoUFSigla, A42MunicipioMicroMesoUFSigla, n43MunicipioMicroMesoUFNome, A43MunicipioMicroMesoUFNome, n45MunicipioMicroMesoUFRegID, A45MunicipioMicroMesoUFRegID, n46MunicipioMicroMesoUFRegSigla, A46MunicipioMicroMesoUFRegSigla, n47MunicipioMicroMesoUFRegNome, A47MunicipioMicroMesoUFRegNome, n44MunicipioMicroMesoUFSiglaNome, A44MunicipioMicroMesoUFSiglaNome, n48MunicipioMicroMesoUFRegSiglaNo, A48MunicipioMicroMesoUFRegSiglaNo, A35MunicipioID, A36MunicipioNome, A37MunicipioMicroID});
                     pr_default.close(14);
                     pr_default.SmartCacheProvider.SetUpdated("tbibge_municipio");
                     if ( (pr_default.getStatus(14) == 1) )
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
                           ResetCaption050( ) ;
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
               Load055( ) ;
            }
            EndLevel055( ) ;
         }
         CloseExtendedTableCursors055( ) ;
      }

      protected void Update055( )
      {
         if ( ! IsAuthorized("municipio_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate055( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable055( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency055( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm055( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate055( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000517 */
                     pr_default.execute(15, new Object[] {A38MunicipioMicroNome, A39MunicipioMicroMesoID, n40MunicipioMicroMesoNome, A40MunicipioMicroMesoNome, n41MunicipioMicroMesoUFID, A41MunicipioMicroMesoUFID, n42MunicipioMicroMesoUFSigla, A42MunicipioMicroMesoUFSigla, n43MunicipioMicroMesoUFNome, A43MunicipioMicroMesoUFNome, n45MunicipioMicroMesoUFRegID, A45MunicipioMicroMesoUFRegID, n46MunicipioMicroMesoUFRegSigla, A46MunicipioMicroMesoUFRegSigla, n47MunicipioMicroMesoUFRegNome, A47MunicipioMicroMesoUFRegNome, n44MunicipioMicroMesoUFSiglaNome, A44MunicipioMicroMesoUFSiglaNome, n48MunicipioMicroMesoUFRegSiglaNo, A48MunicipioMicroMesoUFRegSiglaNo, A36MunicipioNome, A37MunicipioMicroID, A35MunicipioID});
                     pr_default.close(15);
                     pr_default.SmartCacheProvider.SetUpdated("tbibge_municipio");
                     if ( (pr_default.getStatus(15) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tbibge_municipio"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate055( ) ;
                     if ( AnyError == 0 )
                     {
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
            EndLevel055( ) ;
         }
         CloseExtendedTableCursors055( ) ;
      }

      protected void DeferredUpdate055( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("municipio_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate055( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency055( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls055( ) ;
            AfterConfirm055( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete055( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000518 */
                  pr_default.execute(16, new Object[] {A35MunicipioID});
                  pr_default.close(16);
                  pr_default.SmartCacheProvider.SetUpdated("tbibge_municipio");
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
         sMode5 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel055( ) ;
         Gx_mode = sMode5;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls055( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000519 */
            pr_default.execute(17, new Object[] {A37MunicipioMicroID});
            A38MunicipioMicroNome = T000519_A38MunicipioMicroNome[0];
            A39MunicipioMicroMesoID = T000519_A39MunicipioMicroMesoID[0];
            AssignAttri("", false, "A39MunicipioMicroMesoID", StringUtil.LTrimStr( (decimal)(A39MunicipioMicroMesoID), 9, 0));
            pr_default.close(17);
            /* Using cursor T000520 */
            pr_default.execute(18, new Object[] {A39MunicipioMicroMesoID});
            A40MunicipioMicroMesoNome = T000520_A40MunicipioMicroMesoNome[0];
            n40MunicipioMicroMesoNome = T000520_n40MunicipioMicroMesoNome[0];
            AssignAttri("", false, "A40MunicipioMicroMesoNome", A40MunicipioMicroMesoNome);
            A41MunicipioMicroMesoUFID = T000520_A41MunicipioMicroMesoUFID[0];
            n41MunicipioMicroMesoUFID = T000520_n41MunicipioMicroMesoUFID[0];
            AssignAttri("", false, "A41MunicipioMicroMesoUFID", StringUtil.LTrimStr( (decimal)(A41MunicipioMicroMesoUFID), 9, 0));
            pr_default.close(18);
            /* Using cursor T000521 */
            pr_default.execute(19, new Object[] {n41MunicipioMicroMesoUFID, A41MunicipioMicroMesoUFID});
            A42MunicipioMicroMesoUFSigla = T000521_A42MunicipioMicroMesoUFSigla[0];
            n42MunicipioMicroMesoUFSigla = T000521_n42MunicipioMicroMesoUFSigla[0];
            AssignAttri("", false, "A42MunicipioMicroMesoUFSigla", A42MunicipioMicroMesoUFSigla);
            A43MunicipioMicroMesoUFNome = T000521_A43MunicipioMicroMesoUFNome[0];
            n43MunicipioMicroMesoUFNome = T000521_n43MunicipioMicroMesoUFNome[0];
            AssignAttri("", false, "A43MunicipioMicroMesoUFNome", A43MunicipioMicroMesoUFNome);
            A45MunicipioMicroMesoUFRegID = T000521_A45MunicipioMicroMesoUFRegID[0];
            n45MunicipioMicroMesoUFRegID = T000521_n45MunicipioMicroMesoUFRegID[0];
            AssignAttri("", false, "A45MunicipioMicroMesoUFRegID", StringUtil.LTrimStr( (decimal)(A45MunicipioMicroMesoUFRegID), 9, 0));
            pr_default.close(19);
            /* Using cursor T000522 */
            pr_default.execute(20, new Object[] {n45MunicipioMicroMesoUFRegID, A45MunicipioMicroMesoUFRegID});
            A46MunicipioMicroMesoUFRegSigla = T000522_A46MunicipioMicroMesoUFRegSigla[0];
            n46MunicipioMicroMesoUFRegSigla = T000522_n46MunicipioMicroMesoUFRegSigla[0];
            AssignAttri("", false, "A46MunicipioMicroMesoUFRegSigla", A46MunicipioMicroMesoUFRegSigla);
            A47MunicipioMicroMesoUFRegNome = T000522_A47MunicipioMicroMesoUFRegNome[0];
            n47MunicipioMicroMesoUFRegNome = T000522_n47MunicipioMicroMesoUFRegNome[0];
            AssignAttri("", false, "A47MunicipioMicroMesoUFRegNome", A47MunicipioMicroMesoUFRegNome);
            pr_default.close(20);
         }
      }

      protected void EndLevel055( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete055( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("core.municipio",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues050( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("core.municipio",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart055( )
      {
         /* Scan By routine */
         /* Using cursor T000523 */
         pr_default.execute(21);
         RcdFound5 = 0;
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound5 = 1;
            A35MunicipioID = T000523_A35MunicipioID[0];
            AssignAttri("", false, "A35MunicipioID", StringUtil.LTrimStr( (decimal)(A35MunicipioID), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext055( )
      {
         /* Scan next routine */
         pr_default.readNext(21);
         RcdFound5 = 0;
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound5 = 1;
            A35MunicipioID = T000523_A35MunicipioID[0];
            AssignAttri("", false, "A35MunicipioID", StringUtil.LTrimStr( (decimal)(A35MunicipioID), 9, 0));
         }
      }

      protected void ScanEnd055( )
      {
         pr_default.close(21);
      }

      protected void AfterConfirm055( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert055( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate055( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete055( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete055( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate055( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes055( )
      {
         edtMunicipioID_Enabled = 0;
         AssignProp("", false, edtMunicipioID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMunicipioID_Enabled), 5, 0), true);
         edtMunicipioNome_Enabled = 0;
         AssignProp("", false, edtMunicipioNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMunicipioNome_Enabled), 5, 0), true);
         edtMunicipioMicroID_Enabled = 0;
         AssignProp("", false, edtMunicipioMicroID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMunicipioMicroID_Enabled), 5, 0), true);
         edtMunicipioMicroMesoID_Enabled = 0;
         AssignProp("", false, edtMunicipioMicroMesoID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMunicipioMicroMesoID_Enabled), 5, 0), true);
         edtMunicipioMicroMesoUFID_Enabled = 0;
         AssignProp("", false, edtMunicipioMicroMesoUFID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMunicipioMicroMesoUFID_Enabled), 5, 0), true);
         edtMunicipioMicroMesoUFRegID_Enabled = 0;
         AssignProp("", false, edtMunicipioMicroMesoUFRegID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMunicipioMicroMesoUFRegID_Enabled), 5, 0), true);
         edtavCombomunicipiomicroid_Enabled = 0;
         AssignProp("", false, edtavCombomunicipiomicroid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombomunicipiomicroid_Enabled), 5, 0), true);
         edtMunicipioMicroMesoNome_Enabled = 0;
         AssignProp("", false, edtMunicipioMicroMesoNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMunicipioMicroMesoNome_Enabled), 5, 0), true);
         edtMunicipioMicroMesoUFSigla_Enabled = 0;
         AssignProp("", false, edtMunicipioMicroMesoUFSigla_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMunicipioMicroMesoUFSigla_Enabled), 5, 0), true);
         edtMunicipioMicroMesoUFNome_Enabled = 0;
         AssignProp("", false, edtMunicipioMicroMesoUFNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMunicipioMicroMesoUFNome_Enabled), 5, 0), true);
         edtMunicipioMicroMesoUFSiglaNome_Enabled = 0;
         AssignProp("", false, edtMunicipioMicroMesoUFSiglaNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMunicipioMicroMesoUFSiglaNome_Enabled), 5, 0), true);
         edtMunicipioMicroMesoUFRegSigla_Enabled = 0;
         AssignProp("", false, edtMunicipioMicroMesoUFRegSigla_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMunicipioMicroMesoUFRegSigla_Enabled), 5, 0), true);
         edtMunicipioMicroMesoUFRegNome_Enabled = 0;
         AssignProp("", false, edtMunicipioMicroMesoUFRegNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMunicipioMicroMesoUFRegNome_Enabled), 5, 0), true);
         edtMunicipioMicroMesoUFRegSiglaNo_Enabled = 0;
         AssignProp("", false, edtMunicipioMicroMesoUFRegSiglaNo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMunicipioMicroMesoUFRegSiglaNo_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes055( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues050( )
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
         GXEncryptionTmp = "core.municipio.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7MunicipioID,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("core.municipio.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"municipio");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("core\\municipio:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z35MunicipioID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z35MunicipioID), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z44MunicipioMicroMesoUFSiglaNome", Z44MunicipioMicroMesoUFSiglaNome);
         GxWebStd.gx_hidden_field( context, "Z48MunicipioMicroMesoUFRegSiglaNo", Z48MunicipioMicroMesoUFRegSiglaNo);
         GxWebStd.gx_hidden_field( context, "Z36MunicipioNome", Z36MunicipioNome);
         GxWebStd.gx_hidden_field( context, "Z37MunicipioMicroID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z37MunicipioMicroID), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N37MunicipioMicroID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A37MunicipioMicroID), 9, 0, ",", "")));
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMUNICIPIOMICROID_DATA", AV15MunicipioMicroID_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMUNICIPIOMICROID_DATA", AV15MunicipioMicroID_Data);
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
         GxWebStd.gx_hidden_field( context, "vMUNICIPIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7MunicipioID), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vMUNICIPIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7MunicipioID), "ZZZ,ZZZ,ZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_MUNICIPIOMICROID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13Insert_MunicipioMicroID), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "MUNICIPIOMICRONOME", A38MunicipioMicroNome);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV25Pgmname));
         GxWebStd.gx_hidden_field( context, "COMBO_MUNICIPIOMICROID_Objectcall", StringUtil.RTrim( Combo_municipiomicroid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_MUNICIPIOMICROID_Cls", StringUtil.RTrim( Combo_municipiomicroid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_MUNICIPIOMICROID_Selectedvalue_set", StringUtil.RTrim( Combo_municipiomicroid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_MUNICIPIOMICROID_Selectedtext_set", StringUtil.RTrim( Combo_municipiomicroid_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_MUNICIPIOMICROID_Gamoauthtoken", StringUtil.RTrim( Combo_municipiomicroid_Gamoauthtoken));
         GxWebStd.gx_hidden_field( context, "COMBO_MUNICIPIOMICROID_Enabled", StringUtil.BoolToStr( Combo_municipiomicroid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_MUNICIPIOMICROID_Datalistproc", StringUtil.RTrim( Combo_municipiomicroid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_MUNICIPIOMICROID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_municipiomicroid_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_MUNICIPIOMICROID_Emptyitem", StringUtil.BoolToStr( Combo_municipiomicroid_Emptyitem));
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
         GXEncryptionTmp = "core.municipio.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7MunicipioID,9,0));
         return formatLink("core.municipio.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "core.municipio" ;
      }

      public override string GetPgmdesc( )
      {
         return "Município" ;
      }

      protected void InitializeNonKey055( )
      {
         A37MunicipioMicroID = 0;
         AssignAttri("", false, "A37MunicipioMicroID", StringUtil.LTrimStr( (decimal)(A37MunicipioMicroID), 9, 0));
         A36MunicipioNome = "";
         AssignAttri("", false, "A36MunicipioNome", A36MunicipioNome);
         A38MunicipioMicroNome = "";
         AssignAttri("", false, "A38MunicipioMicroNome", A38MunicipioMicroNome);
         A39MunicipioMicroMesoID = 0;
         AssignAttri("", false, "A39MunicipioMicroMesoID", StringUtil.LTrimStr( (decimal)(A39MunicipioMicroMesoID), 9, 0));
         A40MunicipioMicroMesoNome = "";
         n40MunicipioMicroMesoNome = false;
         AssignAttri("", false, "A40MunicipioMicroMesoNome", A40MunicipioMicroMesoNome);
         A41MunicipioMicroMesoUFID = 0;
         n41MunicipioMicroMesoUFID = false;
         AssignAttri("", false, "A41MunicipioMicroMesoUFID", StringUtil.LTrimStr( (decimal)(A41MunicipioMicroMesoUFID), 9, 0));
         A42MunicipioMicroMesoUFSigla = "";
         n42MunicipioMicroMesoUFSigla = false;
         AssignAttri("", false, "A42MunicipioMicroMesoUFSigla", A42MunicipioMicroMesoUFSigla);
         A43MunicipioMicroMesoUFNome = "";
         n43MunicipioMicroMesoUFNome = false;
         AssignAttri("", false, "A43MunicipioMicroMesoUFNome", A43MunicipioMicroMesoUFNome);
         A44MunicipioMicroMesoUFSiglaNome = "";
         n44MunicipioMicroMesoUFSiglaNome = false;
         AssignAttri("", false, "A44MunicipioMicroMesoUFSiglaNome", A44MunicipioMicroMesoUFSiglaNome);
         n44MunicipioMicroMesoUFSiglaNome = (String.IsNullOrEmpty(StringUtil.RTrim( A44MunicipioMicroMesoUFSiglaNome)) ? true : false);
         A45MunicipioMicroMesoUFRegID = 0;
         n45MunicipioMicroMesoUFRegID = false;
         AssignAttri("", false, "A45MunicipioMicroMesoUFRegID", StringUtil.LTrimStr( (decimal)(A45MunicipioMicroMesoUFRegID), 9, 0));
         A46MunicipioMicroMesoUFRegSigla = "";
         n46MunicipioMicroMesoUFRegSigla = false;
         AssignAttri("", false, "A46MunicipioMicroMesoUFRegSigla", A46MunicipioMicroMesoUFRegSigla);
         A47MunicipioMicroMesoUFRegNome = "";
         n47MunicipioMicroMesoUFRegNome = false;
         AssignAttri("", false, "A47MunicipioMicroMesoUFRegNome", A47MunicipioMicroMesoUFRegNome);
         A48MunicipioMicroMesoUFRegSiglaNo = "";
         n48MunicipioMicroMesoUFRegSiglaNo = false;
         AssignAttri("", false, "A48MunicipioMicroMesoUFRegSiglaNo", A48MunicipioMicroMesoUFRegSiglaNo);
         n48MunicipioMicroMesoUFRegSiglaNo = (String.IsNullOrEmpty(StringUtil.RTrim( A48MunicipioMicroMesoUFRegSiglaNo)) ? true : false);
         Z44MunicipioMicroMesoUFSiglaNome = "";
         Z48MunicipioMicroMesoUFRegSiglaNo = "";
         Z36MunicipioNome = "";
         Z37MunicipioMicroID = 0;
      }

      protected void InitAll055( )
      {
         A35MunicipioID = 0;
         AssignAttri("", false, "A35MunicipioID", StringUtil.LTrimStr( (decimal)(A35MunicipioID), 9, 0));
         InitializeNonKey055( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202382811592", true, true);
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
         context.AddJavascriptSource("core/municipio.js", "?202382811595", false, true);
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
         edtMunicipioID_Internalname = "MUNICIPIOID";
         edtMunicipioNome_Internalname = "MUNICIPIONOME";
         lblTextblockmunicipiomicroid_Internalname = "TEXTBLOCKMUNICIPIOMICROID";
         Combo_municipiomicroid_Internalname = "COMBO_MUNICIPIOMICROID";
         edtMunicipioMicroID_Internalname = "MUNICIPIOMICROID";
         divTablesplittedmunicipiomicroid_Internalname = "TABLESPLITTEDMUNICIPIOMICROID";
         edtMunicipioMicroMesoID_Internalname = "MUNICIPIOMICROMESOID";
         edtMunicipioMicroMesoUFID_Internalname = "MUNICIPIOMICROMESOUFID";
         edtMunicipioMicroMesoUFRegID_Internalname = "MUNICIPIOMICROMESOUFREGID";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         divTablemain_Internalname = "TABLEMAIN";
         edtavCombomunicipiomicroid_Internalname = "vCOMBOMUNICIPIOMICROID";
         divSectionattribute_municipiomicroid_Internalname = "SECTIONATTRIBUTE_MUNICIPIOMICROID";
         edtMunicipioMicroMesoNome_Internalname = "MUNICIPIOMICROMESONOME";
         edtMunicipioMicroMesoUFSigla_Internalname = "MUNICIPIOMICROMESOUFSIGLA";
         edtMunicipioMicroMesoUFNome_Internalname = "MUNICIPIOMICROMESOUFNOME";
         edtMunicipioMicroMesoUFSiglaNome_Internalname = "MUNICIPIOMICROMESOUFSIGLANOME";
         edtMunicipioMicroMesoUFRegSigla_Internalname = "MUNICIPIOMICROMESOUFREGSIGLA";
         edtMunicipioMicroMesoUFRegNome_Internalname = "MUNICIPIOMICROMESOUFREGNOME";
         edtMunicipioMicroMesoUFRegSiglaNo_Internalname = "MUNICIPIOMICROMESOUFREGSIGLANO";
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
         Form.Caption = "Município";
         edtMunicipioMicroMesoUFRegSiglaNo_Jsonclick = "";
         edtMunicipioMicroMesoUFRegSiglaNo_Enabled = 0;
         edtMunicipioMicroMesoUFRegSiglaNo_Visible = 1;
         edtMunicipioMicroMesoUFRegNome_Jsonclick = "";
         edtMunicipioMicroMesoUFRegNome_Enabled = 0;
         edtMunicipioMicroMesoUFRegNome_Visible = 1;
         edtMunicipioMicroMesoUFRegSigla_Jsonclick = "";
         edtMunicipioMicroMesoUFRegSigla_Enabled = 0;
         edtMunicipioMicroMesoUFRegSigla_Visible = 1;
         edtMunicipioMicroMesoUFSiglaNome_Jsonclick = "";
         edtMunicipioMicroMesoUFSiglaNome_Enabled = 0;
         edtMunicipioMicroMesoUFSiglaNome_Visible = 1;
         edtMunicipioMicroMesoUFNome_Jsonclick = "";
         edtMunicipioMicroMesoUFNome_Enabled = 0;
         edtMunicipioMicroMesoUFNome_Visible = 1;
         edtMunicipioMicroMesoUFSigla_Jsonclick = "";
         edtMunicipioMicroMesoUFSigla_Enabled = 0;
         edtMunicipioMicroMesoUFSigla_Visible = 1;
         edtMunicipioMicroMesoNome_Jsonclick = "";
         edtMunicipioMicroMesoNome_Enabled = 0;
         edtMunicipioMicroMesoNome_Visible = 1;
         edtavCombomunicipiomicroid_Jsonclick = "";
         edtavCombomunicipiomicroid_Enabled = 0;
         edtavCombomunicipiomicroid_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtMunicipioMicroMesoUFRegID_Jsonclick = "";
         edtMunicipioMicroMesoUFRegID_Enabled = 0;
         edtMunicipioMicroMesoUFID_Jsonclick = "";
         edtMunicipioMicroMesoUFID_Enabled = 0;
         edtMunicipioMicroMesoID_Jsonclick = "";
         edtMunicipioMicroMesoID_Enabled = 0;
         edtMunicipioMicroID_Jsonclick = "";
         edtMunicipioMicroID_Enabled = 1;
         edtMunicipioMicroID_Visible = 1;
         Combo_municipiomicroid_Emptyitem = Convert.ToBoolean( 0);
         Combo_municipiomicroid_Datalistprocparametersprefix = " \"ComboName\": \"MunicipioMicroID\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"MunicipioID\": 0";
         Combo_municipiomicroid_Datalistproc = "core.municipioLoadDVCombo";
         Combo_municipiomicroid_Cls = "ExtendedCombo AttributeFL";
         Combo_municipiomicroid_Caption = "";
         Combo_municipiomicroid_Enabled = Convert.ToBoolean( -1);
         edtMunicipioNome_Jsonclick = "";
         edtMunicipioNome_Enabled = 1;
         edtMunicipioID_Jsonclick = "";
         edtMunicipioID_Enabled = 1;
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

      public void Valid_Municipiomicroid( )
      {
         n41MunicipioMicroMesoUFID = false;
         n42MunicipioMicroMesoUFSigla = false;
         n43MunicipioMicroMesoUFNome = false;
         n45MunicipioMicroMesoUFRegID = false;
         n46MunicipioMicroMesoUFRegSigla = false;
         n47MunicipioMicroMesoUFRegNome = false;
         n40MunicipioMicroMesoNome = false;
         n44MunicipioMicroMesoUFSiglaNome = false;
         n48MunicipioMicroMesoUFRegSiglaNo = false;
         /* Using cursor T000519 */
         pr_default.execute(17, new Object[] {A37MunicipioMicroID});
         if ( (pr_default.getStatus(17) == 101) )
         {
            GX_msglist.addItem("Não existe 'Microregiao -> Municipio'.", "ForeignKeyNotFound", 1, "MUNICIPIOMICROID");
            AnyError = 1;
            GX_FocusControl = edtMunicipioMicroID_Internalname;
         }
         A38MunicipioMicroNome = T000519_A38MunicipioMicroNome[0];
         A39MunicipioMicroMesoID = T000519_A39MunicipioMicroMesoID[0];
         pr_default.close(17);
         /* Using cursor T000520 */
         pr_default.execute(18, new Object[] {A39MunicipioMicroMesoID});
         if ( (pr_default.getStatus(18) == 101) )
         {
            GX_msglist.addItem("Não existe 'tbibge_mesorregiao'.", "ForeignKeyNotFound", 1, "MUNICIPIOMICROMESOID");
            AnyError = 1;
         }
         A40MunicipioMicroMesoNome = T000520_A40MunicipioMicroMesoNome[0];
         n40MunicipioMicroMesoNome = T000520_n40MunicipioMicroMesoNome[0];
         A41MunicipioMicroMesoUFID = T000520_A41MunicipioMicroMesoUFID[0];
         n41MunicipioMicroMesoUFID = T000520_n41MunicipioMicroMesoUFID[0];
         pr_default.close(18);
         /* Using cursor T000521 */
         pr_default.execute(19, new Object[] {n41MunicipioMicroMesoUFID, A41MunicipioMicroMesoUFID});
         if ( (pr_default.getStatus(19) == 101) )
         {
            GX_msglist.addItem("Não existe 'Unidade Federativa (Estado)'.", "ForeignKeyNotFound", 1, "MUNICIPIOMICROMESOUFID");
            AnyError = 1;
         }
         A42MunicipioMicroMesoUFSigla = T000521_A42MunicipioMicroMesoUFSigla[0];
         n42MunicipioMicroMesoUFSigla = T000521_n42MunicipioMicroMesoUFSigla[0];
         A43MunicipioMicroMesoUFNome = T000521_A43MunicipioMicroMesoUFNome[0];
         n43MunicipioMicroMesoUFNome = T000521_n43MunicipioMicroMesoUFNome[0];
         A45MunicipioMicroMesoUFRegID = T000521_A45MunicipioMicroMesoUFRegID[0];
         n45MunicipioMicroMesoUFRegID = T000521_n45MunicipioMicroMesoUFRegID[0];
         pr_default.close(19);
         A44MunicipioMicroMesoUFSiglaNome = StringUtil.Trim( A42MunicipioMicroMesoUFSigla) + " - " + StringUtil.Trim( A43MunicipioMicroMesoUFNome);
         n44MunicipioMicroMesoUFSiglaNome = false;
         /* Using cursor T000522 */
         pr_default.execute(20, new Object[] {n45MunicipioMicroMesoUFRegID, A45MunicipioMicroMesoUFRegID});
         if ( (pr_default.getStatus(20) == 101) )
         {
            GX_msglist.addItem("Não existe 'Região'.", "ForeignKeyNotFound", 1, "MUNICIPIOMICROMESOUFREGID");
            AnyError = 1;
         }
         A46MunicipioMicroMesoUFRegSigla = T000522_A46MunicipioMicroMesoUFRegSigla[0];
         n46MunicipioMicroMesoUFRegSigla = T000522_n46MunicipioMicroMesoUFRegSigla[0];
         A47MunicipioMicroMesoUFRegNome = T000522_A47MunicipioMicroMesoUFRegNome[0];
         n47MunicipioMicroMesoUFRegNome = T000522_n47MunicipioMicroMesoUFRegNome[0];
         pr_default.close(20);
         A48MunicipioMicroMesoUFRegSiglaNo = StringUtil.Trim( A46MunicipioMicroMesoUFRegSigla) + " - " + StringUtil.Trim( A47MunicipioMicroMesoUFRegNome);
         n48MunicipioMicroMesoUFRegSiglaNo = false;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A38MunicipioMicroNome", A38MunicipioMicroNome);
         AssignAttri("", false, "A39MunicipioMicroMesoID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A39MunicipioMicroMesoID), 9, 0, ".", "")));
         AssignAttri("", false, "A40MunicipioMicroMesoNome", A40MunicipioMicroMesoNome);
         AssignAttri("", false, "A41MunicipioMicroMesoUFID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A41MunicipioMicroMesoUFID), 9, 0, ".", "")));
         AssignAttri("", false, "A42MunicipioMicroMesoUFSigla", A42MunicipioMicroMesoUFSigla);
         AssignAttri("", false, "A43MunicipioMicroMesoUFNome", A43MunicipioMicroMesoUFNome);
         AssignAttri("", false, "A45MunicipioMicroMesoUFRegID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A45MunicipioMicroMesoUFRegID), 9, 0, ".", "")));
         AssignAttri("", false, "A44MunicipioMicroMesoUFSiglaNome", A44MunicipioMicroMesoUFSiglaNome);
         AssignAttri("", false, "A46MunicipioMicroMesoUFRegSigla", A46MunicipioMicroMesoUFRegSigla);
         AssignAttri("", false, "A47MunicipioMicroMesoUFRegNome", A47MunicipioMicroMesoUFRegNome);
         AssignAttri("", false, "A48MunicipioMicroMesoUFRegSiglaNo", A48MunicipioMicroMesoUFRegSiglaNo);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7MunicipioID',fld:'vMUNICIPIOID',pic:'ZZZ,ZZZ,ZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7MunicipioID',fld:'vMUNICIPIOID',pic:'ZZZ,ZZZ,ZZ9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E12052',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_MUNICIPIOID","{handler:'Valid_Municipioid',iparms:[]");
         setEventMetadata("VALID_MUNICIPIOID",",oparms:[]}");
         setEventMetadata("VALID_MUNICIPIOMICROID","{handler:'Valid_Municipiomicroid',iparms:[{av:'A37MunicipioMicroID',fld:'MUNICIPIOMICROID',pic:'ZZZ,ZZZ,ZZ9'},{av:'A39MunicipioMicroMesoID',fld:'MUNICIPIOMICROMESOID',pic:'ZZZ,ZZZ,ZZ9'},{av:'A41MunicipioMicroMesoUFID',fld:'MUNICIPIOMICROMESOUFID',pic:'ZZZ,ZZZ,ZZ9'},{av:'A42MunicipioMicroMesoUFSigla',fld:'MUNICIPIOMICROMESOUFSIGLA',pic:'@!'},{av:'A43MunicipioMicroMesoUFNome',fld:'MUNICIPIOMICROMESOUFNOME',pic:''},{av:'A45MunicipioMicroMesoUFRegID',fld:'MUNICIPIOMICROMESOUFREGID',pic:'ZZZ,ZZZ,ZZ9'},{av:'A46MunicipioMicroMesoUFRegSigla',fld:'MUNICIPIOMICROMESOUFREGSIGLA',pic:'@!'},{av:'A47MunicipioMicroMesoUFRegNome',fld:'MUNICIPIOMICROMESOUFREGNOME',pic:''},{av:'A38MunicipioMicroNome',fld:'MUNICIPIOMICRONOME',pic:''},{av:'A40MunicipioMicroMesoNome',fld:'MUNICIPIOMICROMESONOME',pic:''},{av:'A44MunicipioMicroMesoUFSiglaNome',fld:'MUNICIPIOMICROMESOUFSIGLANOME',pic:''},{av:'A48MunicipioMicroMesoUFRegSiglaNo',fld:'MUNICIPIOMICROMESOUFREGSIGLANO',pic:''}]");
         setEventMetadata("VALID_MUNICIPIOMICROID",",oparms:[{av:'A38MunicipioMicroNome',fld:'MUNICIPIOMICRONOME',pic:''},{av:'A39MunicipioMicroMesoID',fld:'MUNICIPIOMICROMESOID',pic:'ZZZ,ZZZ,ZZ9'},{av:'A40MunicipioMicroMesoNome',fld:'MUNICIPIOMICROMESONOME',pic:''},{av:'A41MunicipioMicroMesoUFID',fld:'MUNICIPIOMICROMESOUFID',pic:'ZZZ,ZZZ,ZZ9'},{av:'A42MunicipioMicroMesoUFSigla',fld:'MUNICIPIOMICROMESOUFSIGLA',pic:'@!'},{av:'A43MunicipioMicroMesoUFNome',fld:'MUNICIPIOMICROMESOUFNOME',pic:''},{av:'A45MunicipioMicroMesoUFRegID',fld:'MUNICIPIOMICROMESOUFREGID',pic:'ZZZ,ZZZ,ZZ9'},{av:'A44MunicipioMicroMesoUFSiglaNome',fld:'MUNICIPIOMICROMESOUFSIGLANOME',pic:''},{av:'A46MunicipioMicroMesoUFRegSigla',fld:'MUNICIPIOMICROMESOUFREGSIGLA',pic:'@!'},{av:'A47MunicipioMicroMesoUFRegNome',fld:'MUNICIPIOMICROMESOUFREGNOME',pic:''},{av:'A48MunicipioMicroMesoUFRegSiglaNo',fld:'MUNICIPIOMICROMESOUFREGSIGLANO',pic:''}]}");
         setEventMetadata("VALID_MUNICIPIOMICROMESOID","{handler:'Valid_Municipiomicromesoid',iparms:[]");
         setEventMetadata("VALID_MUNICIPIOMICROMESOID",",oparms:[]}");
         setEventMetadata("VALID_MUNICIPIOMICROMESOUFID","{handler:'Valid_Municipiomicromesoufid',iparms:[]");
         setEventMetadata("VALID_MUNICIPIOMICROMESOUFID",",oparms:[]}");
         setEventMetadata("VALID_MUNICIPIOMICROMESOUFREGID","{handler:'Valid_Municipiomicromesoufregid',iparms:[]");
         setEventMetadata("VALID_MUNICIPIOMICROMESOUFREGID",",oparms:[]}");
         setEventMetadata("VALIDV_COMBOMUNICIPIOMICROID","{handler:'Validv_Combomunicipiomicroid',iparms:[]");
         setEventMetadata("VALIDV_COMBOMUNICIPIOMICROID",",oparms:[]}");
         setEventMetadata("VALID_MUNICIPIOMICROMESOUFSIGLA","{handler:'Valid_Municipiomicromesoufsigla',iparms:[]");
         setEventMetadata("VALID_MUNICIPIOMICROMESOUFSIGLA",",oparms:[]}");
         setEventMetadata("VALID_MUNICIPIOMICROMESOUFNOME","{handler:'Valid_Municipiomicromesoufnome',iparms:[]");
         setEventMetadata("VALID_MUNICIPIOMICROMESOUFNOME",",oparms:[]}");
         setEventMetadata("VALID_MUNICIPIOMICROMESOUFREGSIGLA","{handler:'Valid_Municipiomicromesoufregsigla',iparms:[]");
         setEventMetadata("VALID_MUNICIPIOMICROMESOUFREGSIGLA",",oparms:[]}");
         setEventMetadata("VALID_MUNICIPIOMICROMESOUFREGNOME","{handler:'Valid_Municipiomicromesoufregnome',iparms:[]");
         setEventMetadata("VALID_MUNICIPIOMICROMESOUFREGNOME",",oparms:[]}");
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
         pr_default.close(17);
         pr_default.close(18);
         pr_default.close(19);
         pr_default.close(20);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z44MunicipioMicroMesoUFSiglaNome = "";
         Z48MunicipioMicroMesoUFRegSiglaNo = "";
         Z36MunicipioNome = "";
         Combo_municipiomicroid_Selectedvalue_get = "";
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
         A36MunicipioNome = "";
         lblTextblockmunicipiomicroid_Jsonclick = "";
         ucCombo_municipiomicroid = new GXUserControl();
         AV16DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV15MunicipioMicroID_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         A40MunicipioMicroMesoNome = "";
         A42MunicipioMicroMesoUFSigla = "";
         A43MunicipioMicroMesoUFNome = "";
         A44MunicipioMicroMesoUFSiglaNome = "";
         A46MunicipioMicroMesoUFRegSigla = "";
         A47MunicipioMicroMesoUFRegNome = "";
         A48MunicipioMicroMesoUFRegSiglaNo = "";
         A38MunicipioMicroNome = "";
         AV25Pgmname = "";
         Combo_municipiomicroid_Objectcall = "";
         Combo_municipiomicroid_Class = "";
         Combo_municipiomicroid_Icontype = "";
         Combo_municipiomicroid_Icon = "";
         Combo_municipiomicroid_Tooltip = "";
         Combo_municipiomicroid_Selectedvalue_set = "";
         Combo_municipiomicroid_Selectedtext_set = "";
         Combo_municipiomicroid_Selectedtext_get = "";
         Combo_municipiomicroid_Gamoauthtoken = "";
         Combo_municipiomicroid_Ddointernalname = "";
         Combo_municipiomicroid_Titlecontrolalign = "";
         Combo_municipiomicroid_Dropdownoptionstype = "";
         Combo_municipiomicroid_Titlecontrolidtoreplace = "";
         Combo_municipiomicroid_Datalisttype = "";
         Combo_municipiomicroid_Datalistfixedvalues = "";
         Combo_municipiomicroid_Remoteservicesparameters = "";
         Combo_municipiomicroid_Htmltemplate = "";
         Combo_municipiomicroid_Multiplevaluestype = "";
         Combo_municipiomicroid_Loadingdata = "";
         Combo_municipiomicroid_Noresultsfound = "";
         Combo_municipiomicroid_Emptyitemtext = "";
         Combo_municipiomicroid_Onlyselectedvalues = "";
         Combo_municipiomicroid_Selectalltext = "";
         Combo_municipiomicroid_Multiplevaluesseparator = "";
         Combo_municipiomicroid_Addnewoptiontext = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode5 = "";
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
         Z38MunicipioMicroNome = "";
         Z40MunicipioMicroMesoNome = "";
         Z42MunicipioMicroMesoUFSigla = "";
         Z43MunicipioMicroMesoUFNome = "";
         Z46MunicipioMicroMesoUFRegSigla = "";
         Z47MunicipioMicroMesoUFRegNome = "";
         T00054_A38MunicipioMicroNome = new string[] {""} ;
         T00054_A39MunicipioMicroMesoID = new int[1] ;
         T00055_A40MunicipioMicroMesoNome = new string[] {""} ;
         T00055_n40MunicipioMicroMesoNome = new bool[] {false} ;
         T00055_A41MunicipioMicroMesoUFID = new int[1] ;
         T00055_n41MunicipioMicroMesoUFID = new bool[] {false} ;
         T00056_A42MunicipioMicroMesoUFSigla = new string[] {""} ;
         T00056_n42MunicipioMicroMesoUFSigla = new bool[] {false} ;
         T00056_A43MunicipioMicroMesoUFNome = new string[] {""} ;
         T00056_n43MunicipioMicroMesoUFNome = new bool[] {false} ;
         T00056_A45MunicipioMicroMesoUFRegID = new int[1] ;
         T00056_n45MunicipioMicroMesoUFRegID = new bool[] {false} ;
         T00057_A46MunicipioMicroMesoUFRegSigla = new string[] {""} ;
         T00057_n46MunicipioMicroMesoUFRegSigla = new bool[] {false} ;
         T00057_A47MunicipioMicroMesoUFRegNome = new string[] {""} ;
         T00057_n47MunicipioMicroMesoUFRegNome = new bool[] {false} ;
         T00058_A44MunicipioMicroMesoUFSiglaNome = new string[] {""} ;
         T00058_n44MunicipioMicroMesoUFSiglaNome = new bool[] {false} ;
         T00058_A48MunicipioMicroMesoUFRegSiglaNo = new string[] {""} ;
         T00058_n48MunicipioMicroMesoUFRegSiglaNo = new bool[] {false} ;
         T00058_A35MunicipioID = new int[1] ;
         T00058_A36MunicipioNome = new string[] {""} ;
         T00058_A38MunicipioMicroNome = new string[] {""} ;
         T00058_A39MunicipioMicroMesoID = new int[1] ;
         T00058_A40MunicipioMicroMesoNome = new string[] {""} ;
         T00058_n40MunicipioMicroMesoNome = new bool[] {false} ;
         T00058_A41MunicipioMicroMesoUFID = new int[1] ;
         T00058_n41MunicipioMicroMesoUFID = new bool[] {false} ;
         T00058_A42MunicipioMicroMesoUFSigla = new string[] {""} ;
         T00058_n42MunicipioMicroMesoUFSigla = new bool[] {false} ;
         T00058_A43MunicipioMicroMesoUFNome = new string[] {""} ;
         T00058_n43MunicipioMicroMesoUFNome = new bool[] {false} ;
         T00058_A45MunicipioMicroMesoUFRegID = new int[1] ;
         T00058_n45MunicipioMicroMesoUFRegID = new bool[] {false} ;
         T00058_A46MunicipioMicroMesoUFRegSigla = new string[] {""} ;
         T00058_n46MunicipioMicroMesoUFRegSigla = new bool[] {false} ;
         T00058_A47MunicipioMicroMesoUFRegNome = new string[] {""} ;
         T00058_n47MunicipioMicroMesoUFRegNome = new bool[] {false} ;
         T00058_A37MunicipioMicroID = new int[1] ;
         T00059_A38MunicipioMicroNome = new string[] {""} ;
         T00059_A39MunicipioMicroMesoID = new int[1] ;
         T000510_A40MunicipioMicroMesoNome = new string[] {""} ;
         T000510_n40MunicipioMicroMesoNome = new bool[] {false} ;
         T000510_A41MunicipioMicroMesoUFID = new int[1] ;
         T000510_n41MunicipioMicroMesoUFID = new bool[] {false} ;
         T000511_A42MunicipioMicroMesoUFSigla = new string[] {""} ;
         T000511_n42MunicipioMicroMesoUFSigla = new bool[] {false} ;
         T000511_A43MunicipioMicroMesoUFNome = new string[] {""} ;
         T000511_n43MunicipioMicroMesoUFNome = new bool[] {false} ;
         T000511_A45MunicipioMicroMesoUFRegID = new int[1] ;
         T000511_n45MunicipioMicroMesoUFRegID = new bool[] {false} ;
         T000512_A46MunicipioMicroMesoUFRegSigla = new string[] {""} ;
         T000512_n46MunicipioMicroMesoUFRegSigla = new bool[] {false} ;
         T000512_A47MunicipioMicroMesoUFRegNome = new string[] {""} ;
         T000512_n47MunicipioMicroMesoUFRegNome = new bool[] {false} ;
         T000513_A35MunicipioID = new int[1] ;
         T00053_A35MunicipioID = new int[1] ;
         T00053_A36MunicipioNome = new string[] {""} ;
         T00053_A37MunicipioMicroID = new int[1] ;
         T00053_A38MunicipioMicroNome = new string[] {""} ;
         T00053_A39MunicipioMicroMesoID = new int[1] ;
         T00053_A40MunicipioMicroMesoNome = new string[] {""} ;
         T00053_n40MunicipioMicroMesoNome = new bool[] {false} ;
         T00053_A41MunicipioMicroMesoUFID = new int[1] ;
         T00053_n41MunicipioMicroMesoUFID = new bool[] {false} ;
         T00053_A42MunicipioMicroMesoUFSigla = new string[] {""} ;
         T00053_n42MunicipioMicroMesoUFSigla = new bool[] {false} ;
         T00053_A43MunicipioMicroMesoUFNome = new string[] {""} ;
         T00053_n43MunicipioMicroMesoUFNome = new bool[] {false} ;
         T00053_A44MunicipioMicroMesoUFSiglaNome = new string[] {""} ;
         T00053_n44MunicipioMicroMesoUFSiglaNome = new bool[] {false} ;
         T00053_A45MunicipioMicroMesoUFRegID = new int[1] ;
         T00053_n45MunicipioMicroMesoUFRegID = new bool[] {false} ;
         T00053_A46MunicipioMicroMesoUFRegSigla = new string[] {""} ;
         T00053_n46MunicipioMicroMesoUFRegSigla = new bool[] {false} ;
         T00053_A47MunicipioMicroMesoUFRegNome = new string[] {""} ;
         T00053_n47MunicipioMicroMesoUFRegNome = new bool[] {false} ;
         T00053_A48MunicipioMicroMesoUFRegSiglaNo = new string[] {""} ;
         T00053_n48MunicipioMicroMesoUFRegSiglaNo = new bool[] {false} ;
         T000514_A35MunicipioID = new int[1] ;
         T000515_A35MunicipioID = new int[1] ;
         T00052_A35MunicipioID = new int[1] ;
         T00052_A36MunicipioNome = new string[] {""} ;
         T00052_A37MunicipioMicroID = new int[1] ;
         T00052_A38MunicipioMicroNome = new string[] {""} ;
         T00052_A39MunicipioMicroMesoID = new int[1] ;
         T00052_A40MunicipioMicroMesoNome = new string[] {""} ;
         T00052_n40MunicipioMicroMesoNome = new bool[] {false} ;
         T00052_A41MunicipioMicroMesoUFID = new int[1] ;
         T00052_n41MunicipioMicroMesoUFID = new bool[] {false} ;
         T00052_A42MunicipioMicroMesoUFSigla = new string[] {""} ;
         T00052_n42MunicipioMicroMesoUFSigla = new bool[] {false} ;
         T00052_A43MunicipioMicroMesoUFNome = new string[] {""} ;
         T00052_n43MunicipioMicroMesoUFNome = new bool[] {false} ;
         T00052_A44MunicipioMicroMesoUFSiglaNome = new string[] {""} ;
         T00052_n44MunicipioMicroMesoUFSiglaNome = new bool[] {false} ;
         T00052_A45MunicipioMicroMesoUFRegID = new int[1] ;
         T00052_n45MunicipioMicroMesoUFRegID = new bool[] {false} ;
         T00052_A46MunicipioMicroMesoUFRegSigla = new string[] {""} ;
         T00052_n46MunicipioMicroMesoUFRegSigla = new bool[] {false} ;
         T00052_A47MunicipioMicroMesoUFRegNome = new string[] {""} ;
         T00052_n47MunicipioMicroMesoUFRegNome = new bool[] {false} ;
         T00052_A48MunicipioMicroMesoUFRegSiglaNo = new string[] {""} ;
         T00052_n48MunicipioMicroMesoUFRegSiglaNo = new bool[] {false} ;
         T000519_A38MunicipioMicroNome = new string[] {""} ;
         T000519_A39MunicipioMicroMesoID = new int[1] ;
         T000520_A40MunicipioMicroMesoNome = new string[] {""} ;
         T000520_n40MunicipioMicroMesoNome = new bool[] {false} ;
         T000520_A41MunicipioMicroMesoUFID = new int[1] ;
         T000520_n41MunicipioMicroMesoUFID = new bool[] {false} ;
         T000521_A42MunicipioMicroMesoUFSigla = new string[] {""} ;
         T000521_n42MunicipioMicroMesoUFSigla = new bool[] {false} ;
         T000521_A43MunicipioMicroMesoUFNome = new string[] {""} ;
         T000521_n43MunicipioMicroMesoUFNome = new bool[] {false} ;
         T000521_A45MunicipioMicroMesoUFRegID = new int[1] ;
         T000521_n45MunicipioMicroMesoUFRegID = new bool[] {false} ;
         T000522_A46MunicipioMicroMesoUFRegSigla = new string[] {""} ;
         T000522_n46MunicipioMicroMesoUFRegSigla = new bool[] {false} ;
         T000522_A47MunicipioMicroMesoUFRegNome = new string[] {""} ;
         T000522_n47MunicipioMicroMesoUFRegNome = new bool[] {false} ;
         T000523_A35MunicipioID = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.core.municipio__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.municipio__default(),
            new Object[][] {
                new Object[] {
               T00052_A35MunicipioID, T00052_A36MunicipioNome, T00052_A37MunicipioMicroID, T00052_A38MunicipioMicroNome, T00052_A39MunicipioMicroMesoID, T00052_A40MunicipioMicroMesoNome, T00052_n40MunicipioMicroMesoNome, T00052_A41MunicipioMicroMesoUFID, T00052_n41MunicipioMicroMesoUFID, T00052_A42MunicipioMicroMesoUFSigla,
               T00052_n42MunicipioMicroMesoUFSigla, T00052_A43MunicipioMicroMesoUFNome, T00052_n43MunicipioMicroMesoUFNome, T00052_A44MunicipioMicroMesoUFSiglaNome, T00052_n44MunicipioMicroMesoUFSiglaNome, T00052_A45MunicipioMicroMesoUFRegID, T00052_n45MunicipioMicroMesoUFRegID, T00052_A46MunicipioMicroMesoUFRegSigla, T00052_n46MunicipioMicroMesoUFRegSigla, T00052_A47MunicipioMicroMesoUFRegNome,
               T00052_n47MunicipioMicroMesoUFRegNome, T00052_A48MunicipioMicroMesoUFRegSiglaNo, T00052_n48MunicipioMicroMesoUFRegSiglaNo
               }
               , new Object[] {
               T00053_A35MunicipioID, T00053_A36MunicipioNome, T00053_A37MunicipioMicroID, T00053_A38MunicipioMicroNome, T00053_A39MunicipioMicroMesoID, T00053_A40MunicipioMicroMesoNome, T00053_n40MunicipioMicroMesoNome, T00053_A41MunicipioMicroMesoUFID, T00053_n41MunicipioMicroMesoUFID, T00053_A42MunicipioMicroMesoUFSigla,
               T00053_n42MunicipioMicroMesoUFSigla, T00053_A43MunicipioMicroMesoUFNome, T00053_n43MunicipioMicroMesoUFNome, T00053_A44MunicipioMicroMesoUFSiglaNome, T00053_n44MunicipioMicroMesoUFSiglaNome, T00053_A45MunicipioMicroMesoUFRegID, T00053_n45MunicipioMicroMesoUFRegID, T00053_A46MunicipioMicroMesoUFRegSigla, T00053_n46MunicipioMicroMesoUFRegSigla, T00053_A47MunicipioMicroMesoUFRegNome,
               T00053_n47MunicipioMicroMesoUFRegNome, T00053_A48MunicipioMicroMesoUFRegSiglaNo, T00053_n48MunicipioMicroMesoUFRegSiglaNo
               }
               , new Object[] {
               T00054_A38MunicipioMicroNome, T00054_A39MunicipioMicroMesoID
               }
               , new Object[] {
               T00055_A40MunicipioMicroMesoNome, T00055_A41MunicipioMicroMesoUFID
               }
               , new Object[] {
               T00056_A42MunicipioMicroMesoUFSigla, T00056_A43MunicipioMicroMesoUFNome, T00056_A45MunicipioMicroMesoUFRegID
               }
               , new Object[] {
               T00057_A46MunicipioMicroMesoUFRegSigla, T00057_A47MunicipioMicroMesoUFRegNome
               }
               , new Object[] {
               T00058_A44MunicipioMicroMesoUFSiglaNome, T00058_n44MunicipioMicroMesoUFSiglaNome, T00058_A48MunicipioMicroMesoUFRegSiglaNo, T00058_n48MunicipioMicroMesoUFRegSiglaNo, T00058_A35MunicipioID, T00058_A36MunicipioNome, T00058_A38MunicipioMicroNome, T00058_A39MunicipioMicroMesoID, T00058_A40MunicipioMicroMesoNome, T00058_n40MunicipioMicroMesoNome,
               T00058_A41MunicipioMicroMesoUFID, T00058_n41MunicipioMicroMesoUFID, T00058_A42MunicipioMicroMesoUFSigla, T00058_n42MunicipioMicroMesoUFSigla, T00058_A43MunicipioMicroMesoUFNome, T00058_n43MunicipioMicroMesoUFNome, T00058_A45MunicipioMicroMesoUFRegID, T00058_n45MunicipioMicroMesoUFRegID, T00058_A46MunicipioMicroMesoUFRegSigla, T00058_n46MunicipioMicroMesoUFRegSigla,
               T00058_A47MunicipioMicroMesoUFRegNome, T00058_n47MunicipioMicroMesoUFRegNome, T00058_A37MunicipioMicroID
               }
               , new Object[] {
               T00059_A38MunicipioMicroNome, T00059_A39MunicipioMicroMesoID
               }
               , new Object[] {
               T000510_A40MunicipioMicroMesoNome, T000510_A41MunicipioMicroMesoUFID
               }
               , new Object[] {
               T000511_A42MunicipioMicroMesoUFSigla, T000511_A43MunicipioMicroMesoUFNome, T000511_A45MunicipioMicroMesoUFRegID
               }
               , new Object[] {
               T000512_A46MunicipioMicroMesoUFRegSigla, T000512_A47MunicipioMicroMesoUFRegNome
               }
               , new Object[] {
               T000513_A35MunicipioID
               }
               , new Object[] {
               T000514_A35MunicipioID
               }
               , new Object[] {
               T000515_A35MunicipioID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000519_A38MunicipioMicroNome, T000519_A39MunicipioMicroMesoID
               }
               , new Object[] {
               T000520_A40MunicipioMicroMesoNome, T000520_A41MunicipioMicroMesoUFID
               }
               , new Object[] {
               T000521_A42MunicipioMicroMesoUFSigla, T000521_A43MunicipioMicroMesoUFNome, T000521_A45MunicipioMicroMesoUFRegID
               }
               , new Object[] {
               T000522_A46MunicipioMicroMesoUFRegSigla, T000522_A47MunicipioMicroMesoUFRegNome
               }
               , new Object[] {
               T000523_A35MunicipioID
               }
            }
         );
         AV25Pgmname = "core.municipio";
      }

      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short RcdFound5 ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short nIsDirty_5 ;
      private short gxajaxcallmode ;
      private int wcpOAV7MunicipioID ;
      private int Z35MunicipioID ;
      private int Z37MunicipioMicroID ;
      private int N37MunicipioMicroID ;
      private int A37MunicipioMicroID ;
      private int A39MunicipioMicroMesoID ;
      private int A41MunicipioMicroMesoUFID ;
      private int A45MunicipioMicroMesoUFRegID ;
      private int AV7MunicipioID ;
      private int trnEnded ;
      private int A35MunicipioID ;
      private int edtMunicipioID_Enabled ;
      private int edtMunicipioNome_Enabled ;
      private int edtMunicipioMicroID_Visible ;
      private int edtMunicipioMicroID_Enabled ;
      private int edtMunicipioMicroMesoID_Enabled ;
      private int edtMunicipioMicroMesoUFID_Enabled ;
      private int edtMunicipioMicroMesoUFRegID_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int AV20ComboMunicipioMicroID ;
      private int edtavCombomunicipiomicroid_Enabled ;
      private int edtavCombomunicipiomicroid_Visible ;
      private int edtMunicipioMicroMesoNome_Visible ;
      private int edtMunicipioMicroMesoNome_Enabled ;
      private int edtMunicipioMicroMesoUFSigla_Visible ;
      private int edtMunicipioMicroMesoUFSigla_Enabled ;
      private int edtMunicipioMicroMesoUFNome_Visible ;
      private int edtMunicipioMicroMesoUFNome_Enabled ;
      private int edtMunicipioMicroMesoUFSiglaNome_Visible ;
      private int edtMunicipioMicroMesoUFSiglaNome_Enabled ;
      private int edtMunicipioMicroMesoUFRegSigla_Visible ;
      private int edtMunicipioMicroMesoUFRegSigla_Enabled ;
      private int edtMunicipioMicroMesoUFRegNome_Visible ;
      private int edtMunicipioMicroMesoUFRegNome_Enabled ;
      private int edtMunicipioMicroMesoUFRegSiglaNo_Visible ;
      private int edtMunicipioMicroMesoUFRegSiglaNo_Enabled ;
      private int AV13Insert_MunicipioMicroID ;
      private int Combo_municipiomicroid_Datalistupdateminimumcharacters ;
      private int Combo_municipiomicroid_Gxcontroltype ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int AV26GXV1 ;
      private int Z39MunicipioMicroMesoID ;
      private int Z41MunicipioMicroMesoUFID ;
      private int Z45MunicipioMicroMesoUFRegID ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Combo_municipiomicroid_Selectedvalue_get ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtMunicipioID_Internalname ;
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
      private string edtMunicipioID_Jsonclick ;
      private string edtMunicipioNome_Internalname ;
      private string edtMunicipioNome_Jsonclick ;
      private string divTablesplittedmunicipiomicroid_Internalname ;
      private string lblTextblockmunicipiomicroid_Internalname ;
      private string lblTextblockmunicipiomicroid_Jsonclick ;
      private string Combo_municipiomicroid_Caption ;
      private string Combo_municipiomicroid_Cls ;
      private string Combo_municipiomicroid_Datalistproc ;
      private string Combo_municipiomicroid_Datalistprocparametersprefix ;
      private string Combo_municipiomicroid_Internalname ;
      private string edtMunicipioMicroID_Internalname ;
      private string edtMunicipioMicroID_Jsonclick ;
      private string edtMunicipioMicroMesoID_Internalname ;
      private string edtMunicipioMicroMesoID_Jsonclick ;
      private string edtMunicipioMicroMesoUFID_Internalname ;
      private string edtMunicipioMicroMesoUFID_Jsonclick ;
      private string edtMunicipioMicroMesoUFRegID_Internalname ;
      private string edtMunicipioMicroMesoUFRegID_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_municipiomicroid_Internalname ;
      private string edtavCombomunicipiomicroid_Internalname ;
      private string edtavCombomunicipiomicroid_Jsonclick ;
      private string edtMunicipioMicroMesoNome_Internalname ;
      private string edtMunicipioMicroMesoNome_Jsonclick ;
      private string edtMunicipioMicroMesoUFSigla_Internalname ;
      private string edtMunicipioMicroMesoUFSigla_Jsonclick ;
      private string edtMunicipioMicroMesoUFNome_Internalname ;
      private string edtMunicipioMicroMesoUFNome_Jsonclick ;
      private string edtMunicipioMicroMesoUFSiglaNome_Internalname ;
      private string edtMunicipioMicroMesoUFSiglaNome_Jsonclick ;
      private string edtMunicipioMicroMesoUFRegSigla_Internalname ;
      private string edtMunicipioMicroMesoUFRegSigla_Jsonclick ;
      private string edtMunicipioMicroMesoUFRegNome_Internalname ;
      private string edtMunicipioMicroMesoUFRegNome_Jsonclick ;
      private string edtMunicipioMicroMesoUFRegSiglaNo_Internalname ;
      private string edtMunicipioMicroMesoUFRegSiglaNo_Jsonclick ;
      private string AV25Pgmname ;
      private string Combo_municipiomicroid_Objectcall ;
      private string Combo_municipiomicroid_Class ;
      private string Combo_municipiomicroid_Icontype ;
      private string Combo_municipiomicroid_Icon ;
      private string Combo_municipiomicroid_Tooltip ;
      private string Combo_municipiomicroid_Selectedvalue_set ;
      private string Combo_municipiomicroid_Selectedtext_set ;
      private string Combo_municipiomicroid_Selectedtext_get ;
      private string Combo_municipiomicroid_Gamoauthtoken ;
      private string Combo_municipiomicroid_Ddointernalname ;
      private string Combo_municipiomicroid_Titlecontrolalign ;
      private string Combo_municipiomicroid_Dropdownoptionstype ;
      private string Combo_municipiomicroid_Titlecontrolidtoreplace ;
      private string Combo_municipiomicroid_Datalisttype ;
      private string Combo_municipiomicroid_Datalistfixedvalues ;
      private string Combo_municipiomicroid_Remoteservicesparameters ;
      private string Combo_municipiomicroid_Htmltemplate ;
      private string Combo_municipiomicroid_Multiplevaluestype ;
      private string Combo_municipiomicroid_Loadingdata ;
      private string Combo_municipiomicroid_Noresultsfound ;
      private string Combo_municipiomicroid_Emptyitemtext ;
      private string Combo_municipiomicroid_Onlyselectedvalues ;
      private string Combo_municipiomicroid_Selectalltext ;
      private string Combo_municipiomicroid_Multiplevaluesseparator ;
      private string Combo_municipiomicroid_Addnewoptiontext ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string hsh ;
      private string sMode5 ;
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
      private bool n41MunicipioMicroMesoUFID ;
      private bool n45MunicipioMicroMesoUFRegID ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool Combo_municipiomicroid_Emptyitem ;
      private bool n44MunicipioMicroMesoUFSiglaNome ;
      private bool n48MunicipioMicroMesoUFRegSiglaNo ;
      private bool Combo_municipiomicroid_Enabled ;
      private bool Combo_municipiomicroid_Visible ;
      private bool Combo_municipiomicroid_Allowmultipleselection ;
      private bool Combo_municipiomicroid_Isgriditem ;
      private bool Combo_municipiomicroid_Hasdescription ;
      private bool Combo_municipiomicroid_Includeonlyselectedoption ;
      private bool Combo_municipiomicroid_Includeselectalloption ;
      private bool Combo_municipiomicroid_Includeaddnewoption ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool n40MunicipioMicroMesoNome ;
      private bool n42MunicipioMicroMesoUFSigla ;
      private bool n43MunicipioMicroMesoUFNome ;
      private bool n46MunicipioMicroMesoUFRegSigla ;
      private bool n47MunicipioMicroMesoUFRegNome ;
      private bool returnInSub ;
      private string AV19Combo_DataJson ;
      private string Z44MunicipioMicroMesoUFSiglaNome ;
      private string Z48MunicipioMicroMesoUFRegSiglaNo ;
      private string Z36MunicipioNome ;
      private string A36MunicipioNome ;
      private string A40MunicipioMicroMesoNome ;
      private string A42MunicipioMicroMesoUFSigla ;
      private string A43MunicipioMicroMesoUFNome ;
      private string A44MunicipioMicroMesoUFSiglaNome ;
      private string A46MunicipioMicroMesoUFRegSigla ;
      private string A47MunicipioMicroMesoUFRegNome ;
      private string A48MunicipioMicroMesoUFRegSiglaNo ;
      private string A38MunicipioMicroNome ;
      private string AV17ComboSelectedValue ;
      private string AV18ComboSelectedText ;
      private string Z38MunicipioMicroNome ;
      private string Z40MunicipioMicroMesoNome ;
      private string Z42MunicipioMicroMesoUFSigla ;
      private string Z43MunicipioMicroMesoUFNome ;
      private string Z46MunicipioMicroMesoUFRegSigla ;
      private string Z47MunicipioMicroMesoUFRegNome ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucCombo_municipiomicroid ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T00054_A38MunicipioMicroNome ;
      private int[] T00054_A39MunicipioMicroMesoID ;
      private string[] T00055_A40MunicipioMicroMesoNome ;
      private bool[] T00055_n40MunicipioMicroMesoNome ;
      private int[] T00055_A41MunicipioMicroMesoUFID ;
      private bool[] T00055_n41MunicipioMicroMesoUFID ;
      private string[] T00056_A42MunicipioMicroMesoUFSigla ;
      private bool[] T00056_n42MunicipioMicroMesoUFSigla ;
      private string[] T00056_A43MunicipioMicroMesoUFNome ;
      private bool[] T00056_n43MunicipioMicroMesoUFNome ;
      private int[] T00056_A45MunicipioMicroMesoUFRegID ;
      private bool[] T00056_n45MunicipioMicroMesoUFRegID ;
      private string[] T00057_A46MunicipioMicroMesoUFRegSigla ;
      private bool[] T00057_n46MunicipioMicroMesoUFRegSigla ;
      private string[] T00057_A47MunicipioMicroMesoUFRegNome ;
      private bool[] T00057_n47MunicipioMicroMesoUFRegNome ;
      private string[] T00058_A44MunicipioMicroMesoUFSiglaNome ;
      private bool[] T00058_n44MunicipioMicroMesoUFSiglaNome ;
      private string[] T00058_A48MunicipioMicroMesoUFRegSiglaNo ;
      private bool[] T00058_n48MunicipioMicroMesoUFRegSiglaNo ;
      private int[] T00058_A35MunicipioID ;
      private string[] T00058_A36MunicipioNome ;
      private string[] T00058_A38MunicipioMicroNome ;
      private int[] T00058_A39MunicipioMicroMesoID ;
      private string[] T00058_A40MunicipioMicroMesoNome ;
      private bool[] T00058_n40MunicipioMicroMesoNome ;
      private int[] T00058_A41MunicipioMicroMesoUFID ;
      private bool[] T00058_n41MunicipioMicroMesoUFID ;
      private string[] T00058_A42MunicipioMicroMesoUFSigla ;
      private bool[] T00058_n42MunicipioMicroMesoUFSigla ;
      private string[] T00058_A43MunicipioMicroMesoUFNome ;
      private bool[] T00058_n43MunicipioMicroMesoUFNome ;
      private int[] T00058_A45MunicipioMicroMesoUFRegID ;
      private bool[] T00058_n45MunicipioMicroMesoUFRegID ;
      private string[] T00058_A46MunicipioMicroMesoUFRegSigla ;
      private bool[] T00058_n46MunicipioMicroMesoUFRegSigla ;
      private string[] T00058_A47MunicipioMicroMesoUFRegNome ;
      private bool[] T00058_n47MunicipioMicroMesoUFRegNome ;
      private int[] T00058_A37MunicipioMicroID ;
      private string[] T00059_A38MunicipioMicroNome ;
      private int[] T00059_A39MunicipioMicroMesoID ;
      private string[] T000510_A40MunicipioMicroMesoNome ;
      private bool[] T000510_n40MunicipioMicroMesoNome ;
      private int[] T000510_A41MunicipioMicroMesoUFID ;
      private bool[] T000510_n41MunicipioMicroMesoUFID ;
      private string[] T000511_A42MunicipioMicroMesoUFSigla ;
      private bool[] T000511_n42MunicipioMicroMesoUFSigla ;
      private string[] T000511_A43MunicipioMicroMesoUFNome ;
      private bool[] T000511_n43MunicipioMicroMesoUFNome ;
      private int[] T000511_A45MunicipioMicroMesoUFRegID ;
      private bool[] T000511_n45MunicipioMicroMesoUFRegID ;
      private string[] T000512_A46MunicipioMicroMesoUFRegSigla ;
      private bool[] T000512_n46MunicipioMicroMesoUFRegSigla ;
      private string[] T000512_A47MunicipioMicroMesoUFRegNome ;
      private bool[] T000512_n47MunicipioMicroMesoUFRegNome ;
      private int[] T000513_A35MunicipioID ;
      private int[] T00053_A35MunicipioID ;
      private string[] T00053_A36MunicipioNome ;
      private int[] T00053_A37MunicipioMicroID ;
      private string[] T00053_A38MunicipioMicroNome ;
      private int[] T00053_A39MunicipioMicroMesoID ;
      private string[] T00053_A40MunicipioMicroMesoNome ;
      private bool[] T00053_n40MunicipioMicroMesoNome ;
      private int[] T00053_A41MunicipioMicroMesoUFID ;
      private bool[] T00053_n41MunicipioMicroMesoUFID ;
      private string[] T00053_A42MunicipioMicroMesoUFSigla ;
      private bool[] T00053_n42MunicipioMicroMesoUFSigla ;
      private string[] T00053_A43MunicipioMicroMesoUFNome ;
      private bool[] T00053_n43MunicipioMicroMesoUFNome ;
      private string[] T00053_A44MunicipioMicroMesoUFSiglaNome ;
      private bool[] T00053_n44MunicipioMicroMesoUFSiglaNome ;
      private int[] T00053_A45MunicipioMicroMesoUFRegID ;
      private bool[] T00053_n45MunicipioMicroMesoUFRegID ;
      private string[] T00053_A46MunicipioMicroMesoUFRegSigla ;
      private bool[] T00053_n46MunicipioMicroMesoUFRegSigla ;
      private string[] T00053_A47MunicipioMicroMesoUFRegNome ;
      private bool[] T00053_n47MunicipioMicroMesoUFRegNome ;
      private string[] T00053_A48MunicipioMicroMesoUFRegSiglaNo ;
      private bool[] T00053_n48MunicipioMicroMesoUFRegSiglaNo ;
      private int[] T000514_A35MunicipioID ;
      private int[] T000515_A35MunicipioID ;
      private int[] T00052_A35MunicipioID ;
      private string[] T00052_A36MunicipioNome ;
      private int[] T00052_A37MunicipioMicroID ;
      private string[] T00052_A38MunicipioMicroNome ;
      private int[] T00052_A39MunicipioMicroMesoID ;
      private string[] T00052_A40MunicipioMicroMesoNome ;
      private bool[] T00052_n40MunicipioMicroMesoNome ;
      private int[] T00052_A41MunicipioMicroMesoUFID ;
      private bool[] T00052_n41MunicipioMicroMesoUFID ;
      private string[] T00052_A42MunicipioMicroMesoUFSigla ;
      private bool[] T00052_n42MunicipioMicroMesoUFSigla ;
      private string[] T00052_A43MunicipioMicroMesoUFNome ;
      private bool[] T00052_n43MunicipioMicroMesoUFNome ;
      private string[] T00052_A44MunicipioMicroMesoUFSiglaNome ;
      private bool[] T00052_n44MunicipioMicroMesoUFSiglaNome ;
      private int[] T00052_A45MunicipioMicroMesoUFRegID ;
      private bool[] T00052_n45MunicipioMicroMesoUFRegID ;
      private string[] T00052_A46MunicipioMicroMesoUFRegSigla ;
      private bool[] T00052_n46MunicipioMicroMesoUFRegSigla ;
      private string[] T00052_A47MunicipioMicroMesoUFRegNome ;
      private bool[] T00052_n47MunicipioMicroMesoUFRegNome ;
      private string[] T00052_A48MunicipioMicroMesoUFRegSiglaNo ;
      private bool[] T00052_n48MunicipioMicroMesoUFRegSiglaNo ;
      private string[] T000519_A38MunicipioMicroNome ;
      private int[] T000519_A39MunicipioMicroMesoID ;
      private string[] T000520_A40MunicipioMicroMesoNome ;
      private bool[] T000520_n40MunicipioMicroMesoNome ;
      private int[] T000520_A41MunicipioMicroMesoUFID ;
      private bool[] T000520_n41MunicipioMicroMesoUFID ;
      private string[] T000521_A42MunicipioMicroMesoUFSigla ;
      private bool[] T000521_n42MunicipioMicroMesoUFSigla ;
      private string[] T000521_A43MunicipioMicroMesoUFNome ;
      private bool[] T000521_n43MunicipioMicroMesoUFNome ;
      private int[] T000521_A45MunicipioMicroMesoUFRegID ;
      private bool[] T000521_n45MunicipioMicroMesoUFRegID ;
      private string[] T000522_A46MunicipioMicroMesoUFRegSigla ;
      private bool[] T000522_n46MunicipioMicroMesoUFRegSigla ;
      private string[] T000522_A47MunicipioMicroMesoUFRegNome ;
      private bool[] T000522_n47MunicipioMicroMesoUFRegNome ;
      private int[] T000523_A35MunicipioID ;
      private IDataStoreProvider pr_gam ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV15MunicipioMicroID_Data ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV23GAMErrors ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV14TrnContextAtt ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV16DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV22GAMSession ;
   }

   public class municipio__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class municipio__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[14])
       ,new UpdateCursor(def[15])
       ,new UpdateCursor(def[16])
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
        Object[] prmT00058;
        prmT00058 = new Object[] {
        new ParDef("MunicipioID",GXType.Int32,9,0)
        };
        Object[] prmT00054;
        prmT00054 = new Object[] {
        new ParDef("MunicipioMicroID",GXType.Int32,9,0)
        };
        Object[] prmT00055;
        prmT00055 = new Object[] {
        new ParDef("MunicipioMicroMesoID",GXType.Int32,9,0)
        };
        Object[] prmT00056;
        prmT00056 = new Object[] {
        new ParDef("MunicipioMicroMesoUFID",GXType.Int32,9,0){Nullable=true}
        };
        Object[] prmT00057;
        prmT00057 = new Object[] {
        new ParDef("MunicipioMicroMesoUFRegID",GXType.Int32,9,0){Nullable=true}
        };
        Object[] prmT00059;
        prmT00059 = new Object[] {
        new ParDef("MunicipioMicroID",GXType.Int32,9,0)
        };
        Object[] prmT000510;
        prmT000510 = new Object[] {
        new ParDef("MunicipioMicroMesoID",GXType.Int32,9,0)
        };
        Object[] prmT000511;
        prmT000511 = new Object[] {
        new ParDef("MunicipioMicroMesoUFID",GXType.Int32,9,0){Nullable=true}
        };
        Object[] prmT000512;
        prmT000512 = new Object[] {
        new ParDef("MunicipioMicroMesoUFRegID",GXType.Int32,9,0){Nullable=true}
        };
        Object[] prmT000513;
        prmT000513 = new Object[] {
        new ParDef("MunicipioID",GXType.Int32,9,0)
        };
        Object[] prmT00053;
        prmT00053 = new Object[] {
        new ParDef("MunicipioID",GXType.Int32,9,0)
        };
        Object[] prmT000514;
        prmT000514 = new Object[] {
        new ParDef("MunicipioID",GXType.Int32,9,0)
        };
        Object[] prmT000515;
        prmT000515 = new Object[] {
        new ParDef("MunicipioID",GXType.Int32,9,0)
        };
        Object[] prmT00052;
        prmT00052 = new Object[] {
        new ParDef("MunicipioID",GXType.Int32,9,0)
        };
        Object[] prmT000516;
        prmT000516 = new Object[] {
        new ParDef("MunicipioMicroNome",GXType.VarChar,80,0) ,
        new ParDef("MunicipioMicroMesoID",GXType.Int32,9,0) ,
        new ParDef("MunicipioMicroMesoNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("MunicipioMicroMesoUFID",GXType.Int32,9,0){Nullable=true} ,
        new ParDef("MunicipioMicroMesoUFSigla",GXType.VarChar,2,0){Nullable=true} ,
        new ParDef("MunicipioMicroMesoUFNome",GXType.VarChar,50,0){Nullable=true} ,
        new ParDef("MunicipioMicroMesoUFRegID",GXType.Int32,9,0){Nullable=true} ,
        new ParDef("MunicipioMicroMesoUFRegSigla",GXType.VarChar,10,0){Nullable=true} ,
        new ParDef("MunicipioMicroMesoUFRegNome",GXType.VarChar,50,0){Nullable=true} ,
        new ParDef("MunicipioMicroMesoUFSiglaNome",GXType.VarChar,70,0){Nullable=true} ,
        new ParDef("MunicipioMicroMesoUFRegSiglaNo",GXType.VarChar,70,0){Nullable=true} ,
        new ParDef("MunicipioID",GXType.Int32,9,0) ,
        new ParDef("MunicipioNome",GXType.VarChar,80,0) ,
        new ParDef("MunicipioMicroID",GXType.Int32,9,0)
        };
        Object[] prmT000517;
        prmT000517 = new Object[] {
        new ParDef("MunicipioMicroNome",GXType.VarChar,80,0) ,
        new ParDef("MunicipioMicroMesoID",GXType.Int32,9,0) ,
        new ParDef("MunicipioMicroMesoNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("MunicipioMicroMesoUFID",GXType.Int32,9,0){Nullable=true} ,
        new ParDef("MunicipioMicroMesoUFSigla",GXType.VarChar,2,0){Nullable=true} ,
        new ParDef("MunicipioMicroMesoUFNome",GXType.VarChar,50,0){Nullable=true} ,
        new ParDef("MunicipioMicroMesoUFRegID",GXType.Int32,9,0){Nullable=true} ,
        new ParDef("MunicipioMicroMesoUFRegSigla",GXType.VarChar,10,0){Nullable=true} ,
        new ParDef("MunicipioMicroMesoUFRegNome",GXType.VarChar,50,0){Nullable=true} ,
        new ParDef("MunicipioMicroMesoUFSiglaNome",GXType.VarChar,70,0){Nullable=true} ,
        new ParDef("MunicipioMicroMesoUFRegSiglaNo",GXType.VarChar,70,0){Nullable=true} ,
        new ParDef("MunicipioNome",GXType.VarChar,80,0) ,
        new ParDef("MunicipioMicroID",GXType.Int32,9,0) ,
        new ParDef("MunicipioID",GXType.Int32,9,0)
        };
        Object[] prmT000518;
        prmT000518 = new Object[] {
        new ParDef("MunicipioID",GXType.Int32,9,0)
        };
        Object[] prmT000523;
        prmT000523 = new Object[] {
        };
        Object[] prmT000519;
        prmT000519 = new Object[] {
        new ParDef("MunicipioMicroID",GXType.Int32,9,0)
        };
        Object[] prmT000520;
        prmT000520 = new Object[] {
        new ParDef("MunicipioMicroMesoID",GXType.Int32,9,0)
        };
        Object[] prmT000521;
        prmT000521 = new Object[] {
        new ParDef("MunicipioMicroMesoUFID",GXType.Int32,9,0){Nullable=true}
        };
        Object[] prmT000522;
        prmT000522 = new Object[] {
        new ParDef("MunicipioMicroMesoUFRegID",GXType.Int32,9,0){Nullable=true}
        };
        def= new CursorDef[] {
            new CursorDef("T00052", "SELECT MunicipioID, MunicipioNome, MunicipioMicroID, MunicipioMicroNome, MunicipioMicroMesoID, MunicipioMicroMesoNome, MunicipioMicroMesoUFID, MunicipioMicroMesoUFSigla, MunicipioMicroMesoUFNome, MunicipioMicroMesoUFSiglaNome, MunicipioMicroMesoUFRegID, MunicipioMicroMesoUFRegSigla, MunicipioMicroMesoUFRegNome, MunicipioMicroMesoUFRegSiglaNo FROM tbibge_municipio WHERE MunicipioID = :MunicipioID  FOR UPDATE OF tbibge_municipio NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT00052,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00053", "SELECT MunicipioID, MunicipioNome, MunicipioMicroID, MunicipioMicroNome, MunicipioMicroMesoID, MunicipioMicroMesoNome, MunicipioMicroMesoUFID, MunicipioMicroMesoUFSigla, MunicipioMicroMesoUFNome, MunicipioMicroMesoUFSiglaNome, MunicipioMicroMesoUFRegID, MunicipioMicroMesoUFRegSigla, MunicipioMicroMesoUFRegNome, MunicipioMicroMesoUFRegSiglaNo FROM tbibge_municipio WHERE MunicipioID = :MunicipioID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00053,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00054", "SELECT MicrorregiaoNome AS MunicipioMicroNome, MicrorregiaoMesoID AS MunicipioMicroMesoID FROM tbibge_microrregiao WHERE MicrorregiaoID = :MunicipioMicroID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00054,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00055", "SELECT MesorregiaoNome AS MunicipioMicroMesoNome, MesorregiaoUFID AS MunicipioMicroMesoUFID FROM tbibge_mesorregiao WHERE MesorregiaoID = :MunicipioMicroMesoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00055,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00056", "SELECT UFSigla AS MunicipioMicroMesoUFSigla, UFNome AS MunicipioMicroMesoUFNome, UFRegID AS MunicipioMicroMesoUFRegID FROM tbibge_uf WHERE UFID = :MunicipioMicroMesoUFID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00056,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00057", "SELECT RegiaoSigla AS MunicipioMicroMesoUFRegSigla, RegiaoNome AS MunicipioMicroMesoUFRegNome FROM tbibge_regiao WHERE RegiaoID = :MunicipioMicroMesoUFRegID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00057,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00058", "SELECT TM1.MunicipioMicroMesoUFSiglaNome AS MunicipioMicroMesoUFSiglaNome, TM1.MunicipioMicroMesoUFRegSiglaNo AS MunicipioMicroMesoUFRegSiglaNo, TM1.MunicipioID, TM1.MunicipioNome, TM1.MunicipioMicroNome AS MunicipioMicroNome, TM1.MunicipioMicroMesoID AS MunicipioMicroMesoID, TM1.MunicipioMicroMesoNome AS MunicipioMicroMesoNome, TM1.MunicipioMicroMesoUFID AS MunicipioMicroMesoUFID, TM1.MunicipioMicroMesoUFSigla AS MunicipioMicroMesoUFSigla, TM1.MunicipioMicroMesoUFNome AS MunicipioMicroMesoUFNome, TM1.MunicipioMicroMesoUFRegID AS MunicipioMicroMesoUFRegID, TM1.MunicipioMicroMesoUFRegSigla AS MunicipioMicroMesoUFRegSigla, TM1.MunicipioMicroMesoUFRegNome AS MunicipioMicroMesoUFRegNome, TM1.MunicipioMicroID AS MunicipioMicroID FROM (((tbibge_municipio TM1 INNER JOIN tbibge_microrregiao T2 ON T2.MicrorregiaoID = TM1.MunicipioMicroID) INNER JOIN tbibge_mesorregiao T3 ON T3.MesorregiaoID = T2.MicrorregiaoMesoID) INNER JOIN tbibge_uf T4 ON T4.UFID = T3.MesorregiaoUFID) WHERE TM1.MunicipioID = :MunicipioID ORDER BY TM1.MunicipioID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00058,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00059", "SELECT MicrorregiaoNome AS MunicipioMicroNome, MicrorregiaoMesoID AS MunicipioMicroMesoID FROM tbibge_microrregiao WHERE MicrorregiaoID = :MunicipioMicroID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00059,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000510", "SELECT MesorregiaoNome AS MunicipioMicroMesoNome, MesorregiaoUFID AS MunicipioMicroMesoUFID FROM tbibge_mesorregiao WHERE MesorregiaoID = :MunicipioMicroMesoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000510,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000511", "SELECT UFSigla AS MunicipioMicroMesoUFSigla, UFNome AS MunicipioMicroMesoUFNome, UFRegID AS MunicipioMicroMesoUFRegID FROM tbibge_uf WHERE UFID = :MunicipioMicroMesoUFID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000511,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000512", "SELECT RegiaoSigla AS MunicipioMicroMesoUFRegSigla, RegiaoNome AS MunicipioMicroMesoUFRegNome FROM tbibge_regiao WHERE RegiaoID = :MunicipioMicroMesoUFRegID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000512,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000513", "SELECT MunicipioID FROM tbibge_municipio WHERE MunicipioID = :MunicipioID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000513,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000514", "SELECT MunicipioID FROM tbibge_municipio WHERE ( MunicipioID > :MunicipioID) ORDER BY MunicipioID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000514,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000515", "SELECT MunicipioID FROM tbibge_municipio WHERE ( MunicipioID < :MunicipioID) ORDER BY MunicipioID DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000515,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000516", "SAVEPOINT gxupdate;INSERT INTO tbibge_municipio(MunicipioMicroNome, MunicipioMicroMesoID, MunicipioMicroMesoNome, MunicipioMicroMesoUFID, MunicipioMicroMesoUFSigla, MunicipioMicroMesoUFNome, MunicipioMicroMesoUFRegID, MunicipioMicroMesoUFRegSigla, MunicipioMicroMesoUFRegNome, MunicipioMicroMesoUFSiglaNome, MunicipioMicroMesoUFRegSiglaNo, MunicipioID, MunicipioNome, MunicipioMicroID) VALUES(:MunicipioMicroNome, :MunicipioMicroMesoID, :MunicipioMicroMesoNome, :MunicipioMicroMesoUFID, :MunicipioMicroMesoUFSigla, :MunicipioMicroMesoUFNome, :MunicipioMicroMesoUFRegID, :MunicipioMicroMesoUFRegSigla, :MunicipioMicroMesoUFRegNome, :MunicipioMicroMesoUFSiglaNome, :MunicipioMicroMesoUFRegSiglaNo, :MunicipioID, :MunicipioNome, :MunicipioMicroID);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000516)
           ,new CursorDef("T000517", "SAVEPOINT gxupdate;UPDATE tbibge_municipio SET MunicipioMicroNome=:MunicipioMicroNome, MunicipioMicroMesoID=:MunicipioMicroMesoID, MunicipioMicroMesoNome=:MunicipioMicroMesoNome, MunicipioMicroMesoUFID=:MunicipioMicroMesoUFID, MunicipioMicroMesoUFSigla=:MunicipioMicroMesoUFSigla, MunicipioMicroMesoUFNome=:MunicipioMicroMesoUFNome, MunicipioMicroMesoUFRegID=:MunicipioMicroMesoUFRegID, MunicipioMicroMesoUFRegSigla=:MunicipioMicroMesoUFRegSigla, MunicipioMicroMesoUFRegNome=:MunicipioMicroMesoUFRegNome, MunicipioMicroMesoUFSiglaNome=:MunicipioMicroMesoUFSiglaNome, MunicipioMicroMesoUFRegSiglaNo=:MunicipioMicroMesoUFRegSiglaNo, MunicipioNome=:MunicipioNome, MunicipioMicroID=:MunicipioMicroID  WHERE MunicipioID = :MunicipioID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000517)
           ,new CursorDef("T000518", "SAVEPOINT gxupdate;DELETE FROM tbibge_municipio  WHERE MunicipioID = :MunicipioID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000518)
           ,new CursorDef("T000519", "SELECT MicrorregiaoNome AS MunicipioMicroNome, MicrorregiaoMesoID AS MunicipioMicroMesoID FROM tbibge_microrregiao WHERE MicrorregiaoID = :MunicipioMicroID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000519,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000520", "SELECT MesorregiaoNome AS MunicipioMicroMesoNome, MesorregiaoUFID AS MunicipioMicroMesoUFID FROM tbibge_mesorregiao WHERE MesorregiaoID = :MunicipioMicroMesoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000520,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000521", "SELECT UFSigla AS MunicipioMicroMesoUFSigla, UFNome AS MunicipioMicroMesoUFNome, UFRegID AS MunicipioMicroMesoUFRegID FROM tbibge_uf WHERE UFID = :MunicipioMicroMesoUFID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000521,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000522", "SELECT RegiaoSigla AS MunicipioMicroMesoUFRegSigla, RegiaoNome AS MunicipioMicroMesoUFRegNome FROM tbibge_regiao WHERE RegiaoID = :MunicipioMicroMesoUFRegID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000522,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000523", "SELECT MunicipioID FROM tbibge_municipio ORDER BY MunicipioID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000523,100, GxCacheFrequency.OFF ,true,false )
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
              ((int[]) buf[7])[0] = rslt.getInt(7);
              ((bool[]) buf[8])[0] = rslt.wasNull(7);
              ((string[]) buf[9])[0] = rslt.getVarchar(8);
              ((bool[]) buf[10])[0] = rslt.wasNull(8);
              ((string[]) buf[11])[0] = rslt.getVarchar(9);
              ((bool[]) buf[12])[0] = rslt.wasNull(9);
              ((string[]) buf[13])[0] = rslt.getVarchar(10);
              ((bool[]) buf[14])[0] = rslt.wasNull(10);
              ((int[]) buf[15])[0] = rslt.getInt(11);
              ((bool[]) buf[16])[0] = rslt.wasNull(11);
              ((string[]) buf[17])[0] = rslt.getVarchar(12);
              ((bool[]) buf[18])[0] = rslt.wasNull(12);
              ((string[]) buf[19])[0] = rslt.getVarchar(13);
              ((bool[]) buf[20])[0] = rslt.wasNull(13);
              ((string[]) buf[21])[0] = rslt.getVarchar(14);
              ((bool[]) buf[22])[0] = rslt.wasNull(14);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((int[]) buf[4])[0] = rslt.getInt(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              ((int[]) buf[7])[0] = rslt.getInt(7);
              ((bool[]) buf[8])[0] = rslt.wasNull(7);
              ((string[]) buf[9])[0] = rslt.getVarchar(8);
              ((bool[]) buf[10])[0] = rslt.wasNull(8);
              ((string[]) buf[11])[0] = rslt.getVarchar(9);
              ((bool[]) buf[12])[0] = rslt.wasNull(9);
              ((string[]) buf[13])[0] = rslt.getVarchar(10);
              ((bool[]) buf[14])[0] = rslt.wasNull(10);
              ((int[]) buf[15])[0] = rslt.getInt(11);
              ((bool[]) buf[16])[0] = rslt.wasNull(11);
              ((string[]) buf[17])[0] = rslt.getVarchar(12);
              ((bool[]) buf[18])[0] = rslt.wasNull(12);
              ((string[]) buf[19])[0] = rslt.getVarchar(13);
              ((bool[]) buf[20])[0] = rslt.wasNull(13);
              ((string[]) buf[21])[0] = rslt.getVarchar(14);
              ((bool[]) buf[22])[0] = rslt.wasNull(14);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 6 :
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
              ((int[]) buf[10])[0] = rslt.getInt(8);
              ((bool[]) buf[11])[0] = rslt.wasNull(8);
              ((string[]) buf[12])[0] = rslt.getVarchar(9);
              ((bool[]) buf[13])[0] = rslt.wasNull(9);
              ((string[]) buf[14])[0] = rslt.getVarchar(10);
              ((bool[]) buf[15])[0] = rslt.wasNull(10);
              ((int[]) buf[16])[0] = rslt.getInt(11);
              ((bool[]) buf[17])[0] = rslt.wasNull(11);
              ((string[]) buf[18])[0] = rslt.getVarchar(12);
              ((bool[]) buf[19])[0] = rslt.wasNull(12);
              ((string[]) buf[20])[0] = rslt.getVarchar(13);
              ((bool[]) buf[21])[0] = rslt.wasNull(13);
              ((int[]) buf[22])[0] = rslt.getInt(14);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 11 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 12 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 13 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 17 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 18 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 19 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 20 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 21 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
