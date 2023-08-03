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
using GeneXus.Http.Server;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs.core {
   public class auditww : GXDataArea
   {
      public auditww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public auditww( IGxContext context )
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
         cmbavDynamicfiltersselector1 = new GXCombobox();
         cmbavDynamicfiltersoperator1 = new GXCombobox();
         cmbavDynamicfiltersselector2 = new GXCombobox();
         cmbavDynamicfiltersoperator2 = new GXCombobox();
         cmbavDynamicfiltersselector3 = new GXCombobox();
         cmbavDynamicfiltersoperator3 = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid") == 0 )
            {
               gxnrGrid_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid") == 0 )
            {
               gxgrGrid_refresh_invoke( ) ;
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
         }
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGrid_newrow_invoke( )
      {
         nRC_GXsfl_118 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_118"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_118_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_118_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_118_idx = GetPar( "sGXsfl_118_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGrid_newrow( ) ;
         /* End function gxnrGrid_newrow_invoke */
      }

      protected void gxgrGrid_refresh_invoke( )
      {
         subGrid_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGrid_Rows"), "."), 18, MidpointRounding.ToEven));
         AV17FilterFullText = GetPar( "FilterFullText");
         cmbavDynamicfiltersselector1.FromJSonString( GetNextPar( ));
         AV18DynamicFiltersSelector1 = GetPar( "DynamicFiltersSelector1");
         cmbavDynamicfiltersoperator1.FromJSonString( GetNextPar( ));
         AV19DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator1"), "."), 18, MidpointRounding.ToEven));
         cmbavDynamicfiltersselector2.FromJSonString( GetNextPar( ));
         AV23DynamicFiltersSelector2 = GetPar( "DynamicFiltersSelector2");
         cmbavDynamicfiltersoperator2.FromJSonString( GetNextPar( ));
         AV24DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator2"), "."), 18, MidpointRounding.ToEven));
         cmbavDynamicfiltersselector3.FromJSonString( GetNextPar( ));
         AV28DynamicFiltersSelector3 = GetPar( "DynamicFiltersSelector3");
         cmbavDynamicfiltersoperator3.FromJSonString( GetNextPar( ));
         AV29DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator3"), "."), 18, MidpointRounding.ToEven));
         AV20AuditDate1 = context.localUtil.ParseDateParm( GetPar( "AuditDate1"));
         AV25AuditDate2 = context.localUtil.ParseDateParm( GetPar( "AuditDate2"));
         AV30AuditDate3 = context.localUtil.ParseDateParm( GetPar( "AuditDate3"));
         AV43ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV38ColumnsSelector);
         AV87Pgmname = GetPar( "Pgmname");
         AV21AuditDate_To1 = context.localUtil.ParseDateParm( GetPar( "AuditDate_To1"));
         AV22DynamicFiltersEnabled2 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled2"));
         AV26AuditDate_To2 = context.localUtil.ParseDateParm( GetPar( "AuditDate_To2"));
         AV27DynamicFiltersEnabled3 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled3"));
         AV31AuditDate_To3 = context.localUtil.ParseDateParm( GetPar( "AuditDate_To3"));
         AV81TFAuditDateTime = context.localUtil.ParseDTimeParm( GetPar( "TFAuditDateTime"));
         AV82TFAuditDateTime_To = context.localUtil.ParseDTimeParm( GetPar( "TFAuditDateTime_To"));
         AV44TFAuditDate = context.localUtil.ParseDateParm( GetPar( "TFAuditDate"));
         AV45TFAuditDate_To = context.localUtil.ParseDateParm( GetPar( "TFAuditDate_To"));
         AV49TFAuditTime = DateTimeUtil.ResetDate(context.localUtil.ParseDTimeParm( GetPar( "TFAuditTime")));
         AV50TFAuditTime_To = DateTimeUtil.ResetDate(context.localUtil.ParseDTimeParm( GetPar( "TFAuditTime_To")));
         AV54TFAuditTableName = GetPar( "TFAuditTableName");
         AV55TFAuditTableName_Sel = GetPar( "TFAuditTableName_Sel");
         AV62TFAuditAction = GetPar( "TFAuditAction");
         AV63TFAuditAction_Sel = GetPar( "TFAuditAction_Sel");
         AV56TFAuditShortDescription = GetPar( "TFAuditShortDescription");
         AV57TFAuditShortDescription_Sel = GetPar( "TFAuditShortDescription_Sel");
         AV58TFAuditDescription = GetPar( "TFAuditDescription");
         AV59TFAuditDescription_Sel = GetPar( "TFAuditDescription_Sel");
         AV60TFAuditGAMUserName = GetPar( "TFAuditGAMUserName");
         AV61TFAuditGAMUserName_Sel = GetPar( "TFAuditGAMUserName_Sel");
         AV14OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV15OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV11GridState);
         AV33DynamicFiltersIgnoreFirst = StringUtil.StrToBool( GetPar( "DynamicFiltersIgnoreFirst"));
         AV32DynamicFiltersRemoving = StringUtil.StrToBool( GetPar( "DynamicFiltersRemoving"));
         AV80IsAuthorized_AuditDate = StringUtil.StrToBool( GetPar( "IsAuthorized_AuditDate"));
         Gx_date = context.localUtil.ParseDateParm( GetPar( "Gx_date"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV20AuditDate1, AV25AuditDate2, AV30AuditDate3, AV43ManageFiltersExecutionStep, AV38ColumnsSelector, AV87Pgmname, AV21AuditDate_To1, AV22DynamicFiltersEnabled2, AV26AuditDate_To2, AV27DynamicFiltersEnabled3, AV31AuditDate_To3, AV81TFAuditDateTime, AV82TFAuditDateTime_To, AV44TFAuditDate, AV45TFAuditDate_To, AV49TFAuditTime, AV50TFAuditTime_To, AV54TFAuditTableName, AV55TFAuditTableName_Sel, AV62TFAuditAction, AV63TFAuditAction_Sel, AV56TFAuditShortDescription, AV57TFAuditShortDescription_Sel, AV58TFAuditDescription, AV59TFAuditDescription_Sel, AV60TFAuditGAMUserName, AV61TFAuditGAMUserName_Sel, AV14OrderedBy, AV15OrderedDsc, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV80IsAuthorized_AuditDate, Gx_date) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid_refresh_invoke */
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
            return "auditww_Execute" ;
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
         PA5O2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START5O2( ) ;
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
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 211160), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 211160), false, true);
         context.AddJavascriptSource("calendar-pt.js", "?"+context.GetBuildNumber( 211160), false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"false\" data-Skiponenter=\"false\"";
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("core.auditww.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV87Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV87Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_AUDITDATE", AV80IsAuthorized_AuditDate);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_AUDITDATE", GetSecureSignedToken( "", AV80IsAuthorized_AuditDate, context));
         GxWebStd.gx_hidden_field( context, "vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vTODAY", GetSecureSignedToken( "", Gx_date, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vFILTERFULLTEXT", AV17FilterFullText);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR1", AV18DynamicFiltersSelector1);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19DynamicFiltersOperator1), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR2", AV23DynamicFiltersSelector2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24DynamicFiltersOperator2), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR3", AV28DynamicFiltersSelector3);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV29DynamicFiltersOperator3), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vAUDITDATE1", context.localUtil.Format(AV20AuditDate1, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "GXH_vAUDITDATE2", context.localUtil.Format(AV25AuditDate2, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "GXH_vAUDITDATE3", context.localUtil.Format(AV30AuditDate3, "99/99/99"));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_118", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_118), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV41ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV41ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV68GridCurrentPage), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV69GridPageCount), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV70GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAGEXPORTDATA", AV74AGExportData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAGEXPORTDATA", AV74AGExportData);
         }
         GxWebStd.gx_hidden_field( context, "vAUDITDATE1", context.localUtil.DToC( AV20AuditDate1, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vAUDITDATE_TO1", context.localUtil.DToC( AV21AuditDate_To1, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vAUDITDATE2", context.localUtil.DToC( AV25AuditDate2, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vAUDITDATE_TO2", context.localUtil.DToC( AV26AuditDate_To2, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vAUDITDATE3", context.localUtil.DToC( AV30AuditDate3, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vAUDITDATE_TO3", context.localUtil.DToC( AV31AuditDate_To3, 0, "/"));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV64DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV64DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCOLUMNSSELECTOR", AV38ColumnsSelector);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCOLUMNSSELECTOR", AV38ColumnsSelector);
         }
         GxWebStd.gx_hidden_field( context, "vDDO_AUDITDATETIMEAUXDATE", context.localUtil.DToC( AV83DDO_AuditDateTimeAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_AUDITDATETIMEAUXDATETO", context.localUtil.DToC( AV84DDO_AuditDateTimeAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_AUDITDATEAUXDATE", context.localUtil.DToC( AV46DDO_AuditDateAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_AUDITDATEAUXDATETO", context.localUtil.DToC( AV47DDO_AuditDateAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_AUDITTIMEAUXDATE", context.localUtil.DToC( AV51DDO_AuditTimeAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_AUDITTIMEAUXDATETO", context.localUtil.DToC( AV52DDO_AuditTimeAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV43ManageFiltersExecutionStep), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV87Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV87Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED2", AV22DynamicFiltersEnabled2);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED3", AV27DynamicFiltersEnabled3);
         GxWebStd.gx_hidden_field( context, "vTFAUDITDATETIME", context.localUtil.TToC( AV81TFAuditDateTime, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vTFAUDITDATETIME_TO", context.localUtil.TToC( AV82TFAuditDateTime_To, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vTFAUDITDATE", context.localUtil.DToC( AV44TFAuditDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFAUDITDATE_TO", context.localUtil.DToC( AV45TFAuditDate_To, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFAUDITTIME", context.localUtil.TToC( AV49TFAuditTime, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vTFAUDITTIME_TO", context.localUtil.TToC( AV50TFAuditTime_To, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vTFAUDITTABLENAME", AV54TFAuditTableName);
         GxWebStd.gx_hidden_field( context, "vTFAUDITTABLENAME_SEL", AV55TFAuditTableName_Sel);
         GxWebStd.gx_hidden_field( context, "vTFAUDITACTION", AV62TFAuditAction);
         GxWebStd.gx_hidden_field( context, "vTFAUDITACTION_SEL", AV63TFAuditAction_Sel);
         GxWebStd.gx_hidden_field( context, "vTFAUDITSHORTDESCRIPTION", AV56TFAuditShortDescription);
         GxWebStd.gx_hidden_field( context, "vTFAUDITSHORTDESCRIPTION_SEL", AV57TFAuditShortDescription_Sel);
         GxWebStd.gx_hidden_field( context, "vTFAUDITDESCRIPTION", AV58TFAuditDescription);
         GxWebStd.gx_hidden_field( context, "vTFAUDITDESCRIPTION_SEL", AV59TFAuditDescription_Sel);
         GxWebStd.gx_hidden_field( context, "vTFAUDITGAMUSERNAME", AV60TFAuditGAMUserName);
         GxWebStd.gx_hidden_field( context, "vTFAUDITGAMUSERNAME_SEL", AV61TFAuditGAMUserName_Sel);
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV15OrderedDsc);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV11GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV11GridState);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSIGNOREFIRST", AV33DynamicFiltersIgnoreFirst);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSREMOVING", AV32DynamicFiltersRemoving);
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_AUDITDATE", AV80IsAuthorized_AuditDate);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_AUDITDATE", GetSecureSignedToken( "", AV80IsAuthorized_AuditDate, context));
         GxWebStd.gx_hidden_field( context, "vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vTODAY", GetSecureSignedToken( "", Gx_date, context));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Icontype", StringUtil.RTrim( Ddo_managefilters_Icontype));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Icon", StringUtil.RTrim( Ddo_managefilters_Icon));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Tooltip", StringUtil.RTrim( Ddo_managefilters_Tooltip));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Cls", StringUtil.RTrim( Ddo_managefilters_Cls));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Class", StringUtil.RTrim( Gridpaginationbar_Class));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Showfirst", StringUtil.BoolToStr( Gridpaginationbar_Showfirst));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Showprevious", StringUtil.BoolToStr( Gridpaginationbar_Showprevious));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Shownext", StringUtil.BoolToStr( Gridpaginationbar_Shownext));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Showlast", StringUtil.BoolToStr( Gridpaginationbar_Showlast));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Pagestoshow", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Pagestoshow), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Pagingbuttonsposition", StringUtil.RTrim( Gridpaginationbar_Pagingbuttonsposition));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Pagingcaptionposition", StringUtil.RTrim( Gridpaginationbar_Pagingcaptionposition));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Emptygridclass", StringUtil.RTrim( Gridpaginationbar_Emptygridclass));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselector", StringUtil.BoolToStr( Gridpaginationbar_Rowsperpageselector));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageoptions", StringUtil.RTrim( Gridpaginationbar_Rowsperpageoptions));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_First", StringUtil.RTrim( Gridpaginationbar_First));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Previous", StringUtil.RTrim( Gridpaginationbar_Previous));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Next", StringUtil.RTrim( Gridpaginationbar_Next));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Last", StringUtil.RTrim( Gridpaginationbar_Last));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Caption", StringUtil.RTrim( Gridpaginationbar_Caption));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Emptygridcaption", StringUtil.RTrim( Gridpaginationbar_Emptygridcaption));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpagecaption", StringUtil.RTrim( Gridpaginationbar_Rowsperpagecaption));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Icontype", StringUtil.RTrim( Ddo_agexport_Icontype));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Icon", StringUtil.RTrim( Ddo_agexport_Icon));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Caption", StringUtil.RTrim( Ddo_agexport_Caption));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Cls", StringUtil.RTrim( Ddo_agexport_Cls));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Titlecontrolidtoreplace", StringUtil.RTrim( Ddo_agexport_Titlecontrolidtoreplace));
         GxWebStd.gx_hidden_field( context, "DDC_SUBSCRIPTIONS_Icontype", StringUtil.RTrim( Ddc_subscriptions_Icontype));
         GxWebStd.gx_hidden_field( context, "DDC_SUBSCRIPTIONS_Icon", StringUtil.RTrim( Ddc_subscriptions_Icon));
         GxWebStd.gx_hidden_field( context, "DDC_SUBSCRIPTIONS_Caption", StringUtil.RTrim( Ddc_subscriptions_Caption));
         GxWebStd.gx_hidden_field( context, "DDC_SUBSCRIPTIONS_Tooltip", StringUtil.RTrim( Ddc_subscriptions_Tooltip));
         GxWebStd.gx_hidden_field( context, "DDC_SUBSCRIPTIONS_Cls", StringUtil.RTrim( Ddc_subscriptions_Cls));
         GxWebStd.gx_hidden_field( context, "DDC_SUBSCRIPTIONS_Titlecontrolidtoreplace", StringUtil.RTrim( Ddc_subscriptions_Titlecontrolidtoreplace));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Caption", StringUtil.RTrim( Ddo_grid_Caption));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_set", StringUtil.RTrim( Ddo_grid_Filteredtext_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_set", StringUtil.RTrim( Ddo_grid_Filteredtextto_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_set", StringUtil.RTrim( Ddo_grid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Gamoauthtoken", StringUtil.RTrim( Ddo_grid_Gamoauthtoken));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Gridinternalname", StringUtil.RTrim( Ddo_grid_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnids", StringUtil.RTrim( Ddo_grid_Columnids));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnssortvalues", StringUtil.RTrim( Ddo_grid_Columnssortvalues));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includesortasc", StringUtil.RTrim( Ddo_grid_Includesortasc));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Fixable", StringUtil.RTrim( Ddo_grid_Fixable));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Sortedstatus", StringUtil.RTrim( Ddo_grid_Sortedstatus));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includefilter", StringUtil.RTrim( Ddo_grid_Includefilter));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filtertype", StringUtil.RTrim( Ddo_grid_Filtertype));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filterisrange", StringUtil.RTrim( Ddo_grid_Filterisrange));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includedatalist", StringUtil.RTrim( Ddo_grid_Includedatalist));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalisttype", StringUtil.RTrim( Ddo_grid_Datalisttype));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistproc", StringUtil.RTrim( Ddo_grid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "INNEWWINDOW1_Width", StringUtil.RTrim( Innewwindow1_Width));
         GxWebStd.gx_hidden_field( context, "INNEWWINDOW1_Height", StringUtil.RTrim( Innewwindow1_Height));
         GxWebStd.gx_hidden_field( context, "INNEWWINDOW1_Target", StringUtil.RTrim( Innewwindow1_Target));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Icontype", StringUtil.RTrim( Ddo_gridcolumnsselector_Icontype));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Icon", StringUtil.RTrim( Ddo_gridcolumnsselector_Icon));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Caption", StringUtil.RTrim( Ddo_gridcolumnsselector_Caption));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Tooltip", StringUtil.RTrim( Ddo_gridcolumnsselector_Tooltip));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Cls", StringUtil.RTrim( Ddo_gridcolumnsselector_Cls));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Dropdownoptionstype", StringUtil.RTrim( Ddo_gridcolumnsselector_Dropdownoptionstype));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Gridinternalname", StringUtil.RTrim( Ddo_gridcolumnsselector_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Titlecontrolidtoreplace", StringUtil.RTrim( Ddo_gridcolumnsselector_Titlecontrolidtoreplace));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hascolumnsselector", StringUtil.BoolToStr( Grid_empowerer_Hascolumnsselector));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues", StringUtil.RTrim( Ddo_gridcolumnsselector_Columnsselectorvalues));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Activeeventkey", StringUtil.RTrim( Ddo_agexport_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues", StringUtil.RTrim( Ddo_gridcolumnsselector_Columnsselectorvalues));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Activeeventkey", StringUtil.RTrim( Ddo_agexport_Activeeventkey));
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
         if ( ! ( WebComp_Grid_dwc == null ) )
         {
            WebComp_Grid_dwc.componentjscripts();
         }
         if ( ! ( WebComp_Wwpaux_wc == null ) )
         {
            WebComp_Wwpaux_wc.componentjscripts();
         }
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE5O2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT5O2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return false ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("core.auditww.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "core.AuditWW" ;
      }

      public override string GetPgmdesc( )
      {
         return " Auditoria dos Dados" ;
      }

      protected void WB5O0( )
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
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMainWithShadow", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellPaddingBottom", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableheader_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableheadercontent_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableactions_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroupColorFilledActions", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 17,'',false,'',0)\"";
            ClassString = "ColumnsSelector";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnagexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(118), 3, 0)+","+"null"+");", "Exportar", bttBtnagexport_Jsonclick, 0, "Exportar", "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\AuditWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'',0)\"";
            ClassString = "hidden-xs";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtneditcolumns_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(118), 3, 0)+","+"null"+");", "Selecionar colunas", bttBtneditcolumns_Jsonclick, 0, "Selecionar colunas", "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\AuditWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnsubscriptions_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(118), 3, 0)+","+"null"+");", "", bttBtnsubscriptions_Jsonclick, 0, "Assinaturas", "", StyleString, ClassString, bttBtnsubscriptions_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\AuditWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            wb_table1_23_5O2( true) ;
         }
         else
         {
            wb_table1_23_5O2( false) ;
         }
         return  ;
      }

      protected void wb_table1_23_5O2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "CellAdvancedFiltersHidden", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAdvancedfilterscontainer_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;justify-content:flex-end;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabledynamicfilters_Internalname, 1, 0, "px", 0, "px", "TableDynamicFiltersFlex", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DynRowVisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabledynamicfiltersrow1_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix1_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_core\\AuditWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector1_Internalname, "Dynamic Filters Selector1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'" + sGXsfl_118_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector1, cmbavDynamicfiltersselector1_Internalname, StringUtil.RTrim( AV18DynamicFiltersSelector1), 1, cmbavDynamicfiltersselector1_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR1.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "", true, 0, "HLP_core\\AuditWW.htm");
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", (string)(cmbavDynamicfiltersselector1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle1_Internalname, "valor", "", "", lblDynamicfiltersmiddle1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_core\\AuditWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            wb_table2_47_5O2( true) ;
         }
         else
         {
            wb_table2_47_5O2( false) ;
         }
         return  ;
      }

      protected void wb_table2_47_5O2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabledynamicfiltersrow2_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix2_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_core\\AuditWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector2_Internalname, "Dynamic Filters Selector2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'" + sGXsfl_118_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector2, cmbavDynamicfiltersselector2_Internalname, StringUtil.RTrim( AV23DynamicFiltersSelector2), 1, cmbavDynamicfiltersselector2_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR2.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,68);\"", "", true, 0, "HLP_core\\AuditWW.htm");
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", (string)(cmbavDynamicfiltersselector2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle2_Internalname, "valor", "", "", lblDynamicfiltersmiddle2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_core\\AuditWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table3_72_5O2( true) ;
         }
         else
         {
            wb_table3_72_5O2( false) ;
         }
         return  ;
      }

      protected void wb_table3_72_5O2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabledynamicfiltersrow3_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix3_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_core\\AuditWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector3_Internalname, "Dynamic Filters Selector3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'" + sGXsfl_118_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector3, cmbavDynamicfiltersselector3_Internalname, StringUtil.RTrim( AV28DynamicFiltersSelector3), 1, cmbavDynamicfiltersselector3_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR3.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,93);\"", "", true, 0, "HLP_core\\AuditWW.htm");
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV28DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", (string)(cmbavDynamicfiltersselector3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle3_Internalname, "valor", "", "", lblDynamicfiltersmiddle3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_core\\AuditWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table4_97_5O2( true) ;
         }
         else
         {
            wb_table4_97_5O2( false) ;
         }
         return  ;
      }

      protected void wb_table4_97_5O2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell HasGridEmpowerer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtablewithpaginationbar_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl118( ) ;
         }
         if ( wbEnd == 118 )
         {
            wbEnd = 0;
            nRC_GXsfl_118 = (int)(nGXsfl_118_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer, subGrid_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucGridpaginationbar.SetProperty("Class", Gridpaginationbar_Class);
            ucGridpaginationbar.SetProperty("ShowFirst", Gridpaginationbar_Showfirst);
            ucGridpaginationbar.SetProperty("ShowPrevious", Gridpaginationbar_Showprevious);
            ucGridpaginationbar.SetProperty("ShowNext", Gridpaginationbar_Shownext);
            ucGridpaginationbar.SetProperty("ShowLast", Gridpaginationbar_Showlast);
            ucGridpaginationbar.SetProperty("PagesToShow", Gridpaginationbar_Pagestoshow);
            ucGridpaginationbar.SetProperty("PagingButtonsPosition", Gridpaginationbar_Pagingbuttonsposition);
            ucGridpaginationbar.SetProperty("PagingCaptionPosition", Gridpaginationbar_Pagingcaptionposition);
            ucGridpaginationbar.SetProperty("EmptyGridClass", Gridpaginationbar_Emptygridclass);
            ucGridpaginationbar.SetProperty("RowsPerPageSelector", Gridpaginationbar_Rowsperpageselector);
            ucGridpaginationbar.SetProperty("RowsPerPageOptions", Gridpaginationbar_Rowsperpageoptions);
            ucGridpaginationbar.SetProperty("First", Gridpaginationbar_First);
            ucGridpaginationbar.SetProperty("Previous", Gridpaginationbar_Previous);
            ucGridpaginationbar.SetProperty("Next", Gridpaginationbar_Next);
            ucGridpaginationbar.SetProperty("Last", Gridpaginationbar_Last);
            ucGridpaginationbar.SetProperty("Caption", Gridpaginationbar_Caption);
            ucGridpaginationbar.SetProperty("EmptyGridCaption", Gridpaginationbar_Emptygridcaption);
            ucGridpaginationbar.SetProperty("RowsPerPageCaption", Gridpaginationbar_Rowsperpagecaption);
            ucGridpaginationbar.SetProperty("CurrentPage", AV68GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV69GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV70GridAppliedFilters);
            ucGridpaginationbar.Render(context, "dvelop.dvpaginationbar", Gridpaginationbar_Internalname, "GRIDPAGINATIONBARContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCell_grid_dwc_Internalname, 1, 0, "px", 0, "px", divCell_grid_dwc_Class, "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0134"+"", StringUtil.RTrim( WebComp_Grid_dwc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0134"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( bGXsfl_118_Refreshing )
               {
                  if ( StringUtil.Len( WebComp_Grid_dwc_Component) != 0 )
                  {
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldGrid_dwc), StringUtil.Lower( WebComp_Grid_dwc_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0134"+"");
                     }
                     WebComp_Grid_dwc.componentdraw();
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldGrid_dwc), StringUtil.Lower( WebComp_Grid_dwc_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspEndCmp();
                     }
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divHtml_bottomauxiliarcontrols_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDdo_agexport.SetProperty("IconType", Ddo_agexport_Icontype);
            ucDdo_agexport.SetProperty("Icon", Ddo_agexport_Icon);
            ucDdo_agexport.SetProperty("Caption", Ddo_agexport_Caption);
            ucDdo_agexport.SetProperty("Cls", Ddo_agexport_Cls);
            ucDdo_agexport.SetProperty("DropDownOptionsData", AV74AGExportData);
            ucDdo_agexport.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_agexport_Internalname, "DDO_AGEXPORTContainer");
            /* User Defined Control */
            ucDdc_subscriptions.SetProperty("IconType", Ddc_subscriptions_Icontype);
            ucDdc_subscriptions.SetProperty("Icon", Ddc_subscriptions_Icon);
            ucDdc_subscriptions.SetProperty("Caption", Ddc_subscriptions_Caption);
            ucDdc_subscriptions.SetProperty("Tooltip", Ddc_subscriptions_Tooltip);
            ucDdc_subscriptions.SetProperty("Cls", Ddc_subscriptions_Cls);
            ucDdc_subscriptions.Render(context, "dvelop.gxbootstrap.ddcomponent", Ddc_subscriptions_Internalname, "DDC_SUBSCRIPTIONSContainer");
            /* User Defined Control */
            ucAuditdate_rangepicker1.SetProperty("Start Date", AV20AuditDate1);
            ucAuditdate_rangepicker1.SetProperty("End Date", AV21AuditDate_To1);
            ucAuditdate_rangepicker1.Render(context, "wwp.daterangepicker", Auditdate_rangepicker1_Internalname, "AUDITDATE_RANGEPICKER1Container");
            /* User Defined Control */
            ucAuditdate_rangepicker2.SetProperty("Start Date", AV25AuditDate2);
            ucAuditdate_rangepicker2.SetProperty("End Date", AV26AuditDate_To2);
            ucAuditdate_rangepicker2.Render(context, "wwp.daterangepicker", Auditdate_rangepicker2_Internalname, "AUDITDATE_RANGEPICKER2Container");
            /* User Defined Control */
            ucAuditdate_rangepicker3.SetProperty("Start Date", AV30AuditDate3);
            ucAuditdate_rangepicker3.SetProperty("End Date", AV31AuditDate_To3);
            ucAuditdate_rangepicker3.Render(context, "wwp.daterangepicker", Auditdate_rangepicker3_Internalname, "AUDITDATE_RANGEPICKER3Container");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblJsdynamicfilters_Internalname, lblJsdynamicfilters_Caption, "", "", lblJsdynamicfilters_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_core\\AuditWW.htm");
            /* User Defined Control */
            ucDdo_grid.SetProperty("Caption", Ddo_grid_Caption);
            ucDdo_grid.SetProperty("ColumnIds", Ddo_grid_Columnids);
            ucDdo_grid.SetProperty("ColumnsSortValues", Ddo_grid_Columnssortvalues);
            ucDdo_grid.SetProperty("IncludeSortASC", Ddo_grid_Includesortasc);
            ucDdo_grid.SetProperty("Fixable", Ddo_grid_Fixable);
            ucDdo_grid.SetProperty("IncludeFilter", Ddo_grid_Includefilter);
            ucDdo_grid.SetProperty("FilterType", Ddo_grid_Filtertype);
            ucDdo_grid.SetProperty("FilterIsRange", Ddo_grid_Filterisrange);
            ucDdo_grid.SetProperty("IncludeDataList", Ddo_grid_Includedatalist);
            ucDdo_grid.SetProperty("DataListType", Ddo_grid_Datalisttype);
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV64DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucInnewwindow1.Render(context, "innewwindow", Innewwindow1_Internalname, "INNEWWINDOW1Container");
            /* User Defined Control */
            ucDdo_gridcolumnsselector.SetProperty("IconType", Ddo_gridcolumnsselector_Icontype);
            ucDdo_gridcolumnsselector.SetProperty("Icon", Ddo_gridcolumnsselector_Icon);
            ucDdo_gridcolumnsselector.SetProperty("Caption", Ddo_gridcolumnsselector_Caption);
            ucDdo_gridcolumnsselector.SetProperty("Tooltip", Ddo_gridcolumnsselector_Tooltip);
            ucDdo_gridcolumnsselector.SetProperty("Cls", Ddo_gridcolumnsselector_Cls);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsType", Ddo_gridcolumnsselector_Dropdownoptionstype);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsTitleSettingsIcons", AV64DDO_TitleSettingsIcons);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsData", AV38ColumnsSelector);
            ucDdo_gridcolumnsselector.Render(context, "dvelop.gxbootstrap.ddogridcolumnsselector", Ddo_gridcolumnsselector_Internalname, "DDO_GRIDCOLUMNSSELECTORContainer");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.SetProperty("HasColumnsSelector", Grid_empowerer_Hascolumnsselector);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDiv_wwpauxwc_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0149"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0149"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( bGXsfl_118_Refreshing )
               {
                  if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                  {
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0149"+"");
                     }
                     WebComp_Wwpaux_wc.componentdraw();
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspEndCmp();
                     }
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_auditdatetimeauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 151,'',false,'" + sGXsfl_118_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_auditdatetimeauxdatetext_Internalname, AV85DDO_AuditDateTimeAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV85DDO_AuditDateTimeAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,151);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_auditdatetimeauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\AuditWW.htm");
            /* User Defined Control */
            ucTfauditdatetime_rangepicker.SetProperty("Start Date", AV83DDO_AuditDateTimeAuxDate);
            ucTfauditdatetime_rangepicker.SetProperty("End Date", AV84DDO_AuditDateTimeAuxDateTo);
            ucTfauditdatetime_rangepicker.Render(context, "wwp.daterangepicker", Tfauditdatetime_rangepicker_Internalname, "TFAUDITDATETIME_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_auditdateauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 154,'',false,'" + sGXsfl_118_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_auditdateauxdatetext_Internalname, AV48DDO_AuditDateAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV48DDO_AuditDateAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,154);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_auditdateauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\AuditWW.htm");
            /* User Defined Control */
            ucTfauditdate_rangepicker.SetProperty("Start Date", AV46DDO_AuditDateAuxDate);
            ucTfauditdate_rangepicker.SetProperty("End Date", AV47DDO_AuditDateAuxDateTo);
            ucTfauditdate_rangepicker.Render(context, "wwp.daterangepicker", Tfauditdate_rangepicker_Internalname, "TFAUDITDATE_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_audittimeauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 157,'',false,'" + sGXsfl_118_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_audittimeauxdatetext_Internalname, AV53DDO_AuditTimeAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV53DDO_AuditTimeAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,157);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_audittimeauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\AuditWW.htm");
            /* User Defined Control */
            ucTfaudittime_rangepicker.SetProperty("Start Date", AV51DDO_AuditTimeAuxDate);
            ucTfaudittime_rangepicker.SetProperty("End Date", AV52DDO_AuditTimeAuxDateTo);
            ucTfaudittime_rangepicker.Render(context, "wwp.daterangepicker", Tfaudittime_rangepicker_Internalname, "TFAUDITTIME_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 118 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer, subGrid_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START5O2( )
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
            Form.Meta.addItem("description", " Auditoria dos Dados", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP5O0( ) ;
      }

      protected void WS5O2( )
      {
         START5O2( ) ;
         EVT5O2( ) ;
      }

      protected void EVT5O2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "DDO_MANAGEFILTERS.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E115O2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E125O2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E135O2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_AGEXPORT.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E145O2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDC_SUBSCRIPTIONS.ONLOADCOMPONENT") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E155O2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "AUDITDATE_RANGEPICKER1.DATERANGECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E165O2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "AUDITDATE_RANGEPICKER2.DATERANGECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E175O2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "AUDITDATE_RANGEPICKER3.DATERANGECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E185O2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E195O2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E205O2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters1' */
                              E215O2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters2' */
                              E225O2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS3'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters3' */
                              E235O2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters1' */
                              E245O2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR1.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E255O2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSOPERATOR1.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E265O2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters2' */
                              E275O2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR2.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E285O2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSOPERATOR2.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E295O2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR3.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E305O2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSOPERATOR3.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E315O2 ();
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
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 25), "VDETAILWEBCOMPONENT.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 25), "VDETAILWEBCOMPONENT.CLICK") == 0 ) )
                           {
                              nGXsfl_118_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_118_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_118_idx), 4, 0), 4, "0");
                              SubsflControlProps_1182( ) ;
                              AV86DetailWebComponent = cgiGet( edtavDetailwebcomponent_Internalname);
                              AssignAttri("", false, edtavDetailwebcomponent_Internalname, AV86DetailWebComponent);
                              A493AuditID = StringUtil.StrToGuid( cgiGet( edtAuditID_Internalname));
                              A496AuditDateTime = context.localUtil.CToT( cgiGet( edtAuditDateTime_Internalname), 0);
                              A494AuditDate = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtAuditDate_Internalname), 0));
                              A495AuditTime = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtAuditTime_Internalname), 0));
                              A497AuditTableName = cgiGet( edtAuditTableName_Internalname);
                              A502AuditAction = cgiGet( edtAuditAction_Internalname);
                              A499AuditShortDescription = cgiGet( edtAuditShortDescription_Internalname);
                              A498AuditDescription = cgiGet( edtAuditDescription_Internalname);
                              A501AuditGAMUserName = StringUtil.Upper( cgiGet( edtAuditGAMUserName_Internalname));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E325O2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E335O2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E345O2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VDETAILWEBCOMPONENT.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E355O2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Filterfulltext Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV17FilterFullText) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR1"), AV18DynamicFiltersSelector1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator1 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR1"), ",", ".") != Convert.ToDecimal( AV19DynamicFiltersOperator1 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV23DynamicFiltersSelector2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator2 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR2"), ",", ".") != Convert.ToDecimal( AV24DynamicFiltersOperator2 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV28DynamicFiltersSelector3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator3 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR3"), ",", ".") != Convert.ToDecimal( AV29DynamicFiltersOperator3 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Auditdate1 Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vAUDITDATE1"), 0) != AV20AuditDate1 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Auditdate2 Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vAUDITDATE2"), 0) != AV25AuditDate2 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Auditdate3 Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vAUDITDATE3"), 0) != AV30AuditDate3 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                       }
                                       dynload_actions( ) ;
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                 }
                              }
                              else
                              {
                              }
                           }
                        }
                     }
                     else if ( StringUtil.StrCmp(sEvtType, "W") == 0 )
                     {
                        sEvtType = StringUtil.Left( sEvt, 4);
                        sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                        nCmpId = (short)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                        if ( nCmpId == 134 )
                        {
                           OldGrid_dwc = cgiGet( "W0134");
                           if ( ( StringUtil.Len( OldGrid_dwc) == 0 ) || ( StringUtil.StrCmp(OldGrid_dwc, WebComp_Grid_dwc_Component) != 0 ) )
                           {
                              WebComp_Grid_dwc = getWebComponent(GetType(), "GeneXus.Programs", OldGrid_dwc, new Object[] {context} );
                              WebComp_Grid_dwc.ComponentInit();
                              WebComp_Grid_dwc.Name = "OldGrid_dwc";
                              WebComp_Grid_dwc_Component = OldGrid_dwc;
                           }
                           if ( StringUtil.Len( WebComp_Grid_dwc_Component) != 0 )
                           {
                              WebComp_Grid_dwc.componentprocess("W0134", "", sEvt);
                           }
                           WebComp_Grid_dwc_Component = OldGrid_dwc;
                        }
                        else if ( nCmpId == 149 )
                        {
                           OldWwpaux_wc = cgiGet( "W0149");
                           if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                           {
                              WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                              WebComp_Wwpaux_wc.ComponentInit();
                              WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                              WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                           }
                           if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                           {
                              WebComp_Wwpaux_wc.componentprocess("W0149", "", sEvt);
                           }
                           WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE5O2( )
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

      protected void PA5O2( )
      {
         if ( nDonePA == 0 )
         {
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
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = edtavFilterfulltext_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_1182( ) ;
         while ( nGXsfl_118_idx <= nRC_GXsfl_118 )
         {
            sendrow_1182( ) ;
            nGXsfl_118_idx = ((subGrid_Islastpage==1)&&(nGXsfl_118_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_118_idx+1);
            sGXsfl_118_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_118_idx), 4, 0), 4, "0");
            SubsflControlProps_1182( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       string AV17FilterFullText ,
                                       string AV18DynamicFiltersSelector1 ,
                                       short AV19DynamicFiltersOperator1 ,
                                       string AV23DynamicFiltersSelector2 ,
                                       short AV24DynamicFiltersOperator2 ,
                                       string AV28DynamicFiltersSelector3 ,
                                       short AV29DynamicFiltersOperator3 ,
                                       DateTime AV20AuditDate1 ,
                                       DateTime AV25AuditDate2 ,
                                       DateTime AV30AuditDate3 ,
                                       short AV43ManageFiltersExecutionStep ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV38ColumnsSelector ,
                                       string AV87Pgmname ,
                                       DateTime AV21AuditDate_To1 ,
                                       bool AV22DynamicFiltersEnabled2 ,
                                       DateTime AV26AuditDate_To2 ,
                                       bool AV27DynamicFiltersEnabled3 ,
                                       DateTime AV31AuditDate_To3 ,
                                       DateTime AV81TFAuditDateTime ,
                                       DateTime AV82TFAuditDateTime_To ,
                                       DateTime AV44TFAuditDate ,
                                       DateTime AV45TFAuditDate_To ,
                                       DateTime AV49TFAuditTime ,
                                       DateTime AV50TFAuditTime_To ,
                                       string AV54TFAuditTableName ,
                                       string AV55TFAuditTableName_Sel ,
                                       string AV62TFAuditAction ,
                                       string AV63TFAuditAction_Sel ,
                                       string AV56TFAuditShortDescription ,
                                       string AV57TFAuditShortDescription_Sel ,
                                       string AV58TFAuditDescription ,
                                       string AV59TFAuditDescription_Sel ,
                                       string AV60TFAuditGAMUserName ,
                                       string AV61TFAuditGAMUserName_Sel ,
                                       short AV14OrderedBy ,
                                       bool AV15OrderedDsc ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ,
                                       bool AV33DynamicFiltersIgnoreFirst ,
                                       bool AV32DynamicFiltersRemoving ,
                                       bool AV80IsAuthorized_AuditDate ,
                                       DateTime Gx_date )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF5O2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_AUDITID", GetSecureSignedToken( "", A493AuditID, context));
         GxWebStd.gx_hidden_field( context, "AUDITID", A493AuditID.ToString());
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
         if ( cmbavDynamicfiltersselector1.ItemCount > 0 )
         {
            AV18DynamicFiltersSelector1 = cmbavDynamicfiltersselector1.getValidValue(AV18DynamicFiltersSelector1);
            AssignAttri("", false, "AV18DynamicFiltersSelector1", AV18DynamicFiltersSelector1);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator1.ItemCount > 0 )
         {
            AV19DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
            AV23DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV23DynamicFiltersSelector2);
            AssignAttri("", false, "AV23DynamicFiltersSelector2", AV23DynamicFiltersSelector2);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV24DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV24DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV28DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV28DynamicFiltersSelector3);
            AssignAttri("", false, "AV28DynamicFiltersSelector3", AV28DynamicFiltersSelector3);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV28DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV29DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV29DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF5O2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
         AV87Pgmname = "core.AuditWW";
         edtavDetailwebcomponent_Enabled = 0;
         AssignProp("", false, edtavDetailwebcomponent_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDetailwebcomponent_Enabled), 5, 0), !bGXsfl_118_Refreshing);
      }

      protected void RF5O2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 118;
         /* Execute user event: Refresh */
         E335O2 ();
         nGXsfl_118_idx = 1;
         sGXsfl_118_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_118_idx), 4, 0), 4, "0");
         SubsflControlProps_1182( ) ;
         bGXsfl_118_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", "");
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Grid_dwc_Component) != 0 )
               {
                  WebComp_Grid_dwc.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
               {
                  WebComp_Wwpaux_wc.componentstart();
               }
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_1182( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV88Core_auditwwds_1_filterfulltext ,
                                                 AV89Core_auditwwds_2_dynamicfiltersselector1 ,
                                                 AV90Core_auditwwds_3_dynamicfiltersoperator1 ,
                                                 AV91Core_auditwwds_4_auditdate1 ,
                                                 AV92Core_auditwwds_5_auditdate_to1 ,
                                                 AV93Core_auditwwds_6_dynamicfiltersenabled2 ,
                                                 AV94Core_auditwwds_7_dynamicfiltersselector2 ,
                                                 AV95Core_auditwwds_8_dynamicfiltersoperator2 ,
                                                 AV96Core_auditwwds_9_auditdate2 ,
                                                 AV97Core_auditwwds_10_auditdate_to2 ,
                                                 AV98Core_auditwwds_11_dynamicfiltersenabled3 ,
                                                 AV99Core_auditwwds_12_dynamicfiltersselector3 ,
                                                 AV100Core_auditwwds_13_dynamicfiltersoperator3 ,
                                                 AV101Core_auditwwds_14_auditdate3 ,
                                                 AV102Core_auditwwds_15_auditdate_to3 ,
                                                 AV103Core_auditwwds_16_tfauditdatetime ,
                                                 AV104Core_auditwwds_17_tfauditdatetime_to ,
                                                 AV105Core_auditwwds_18_tfauditdate ,
                                                 AV106Core_auditwwds_19_tfauditdate_to ,
                                                 AV107Core_auditwwds_20_tfaudittime ,
                                                 AV108Core_auditwwds_21_tfaudittime_to ,
                                                 AV110Core_auditwwds_23_tfaudittablename_sel ,
                                                 AV109Core_auditwwds_22_tfaudittablename ,
                                                 AV112Core_auditwwds_25_tfauditaction_sel ,
                                                 AV111Core_auditwwds_24_tfauditaction ,
                                                 AV114Core_auditwwds_27_tfauditshortdescription_sel ,
                                                 AV113Core_auditwwds_26_tfauditshortdescription ,
                                                 AV116Core_auditwwds_29_tfauditdescription_sel ,
                                                 AV115Core_auditwwds_28_tfauditdescription ,
                                                 AV118Core_auditwwds_31_tfauditgamusername_sel ,
                                                 AV117Core_auditwwds_30_tfauditgamusername ,
                                                 A497AuditTableName ,
                                                 A502AuditAction ,
                                                 A499AuditShortDescription ,
                                                 A498AuditDescription ,
                                                 A501AuditGAMUserName ,
                                                 A494AuditDate ,
                                                 A496AuditDateTime ,
                                                 A495AuditTime ,
                                                 AV14OrderedBy ,
                                                 AV15OrderedDsc } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE,
                                                 TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE,
                                                 TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV88Core_auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV88Core_auditwwds_1_filterfulltext), "%", "");
            lV88Core_auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV88Core_auditwwds_1_filterfulltext), "%", "");
            lV88Core_auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV88Core_auditwwds_1_filterfulltext), "%", "");
            lV88Core_auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV88Core_auditwwds_1_filterfulltext), "%", "");
            lV88Core_auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV88Core_auditwwds_1_filterfulltext), "%", "");
            lV109Core_auditwwds_22_tfaudittablename = StringUtil.Concat( StringUtil.RTrim( AV109Core_auditwwds_22_tfaudittablename), "%", "");
            lV111Core_auditwwds_24_tfauditaction = StringUtil.Concat( StringUtil.RTrim( AV111Core_auditwwds_24_tfauditaction), "%", "");
            lV113Core_auditwwds_26_tfauditshortdescription = StringUtil.Concat( StringUtil.RTrim( AV113Core_auditwwds_26_tfauditshortdescription), "%", "");
            lV115Core_auditwwds_28_tfauditdescription = StringUtil.Concat( StringUtil.RTrim( AV115Core_auditwwds_28_tfauditdescription), "%", "");
            lV117Core_auditwwds_30_tfauditgamusername = StringUtil.Concat( StringUtil.RTrim( AV117Core_auditwwds_30_tfauditgamusername), "%", "");
            /* Using cursor H005O2 */
            pr_default.execute(0, new Object[] {lV88Core_auditwwds_1_filterfulltext, lV88Core_auditwwds_1_filterfulltext, lV88Core_auditwwds_1_filterfulltext, lV88Core_auditwwds_1_filterfulltext, lV88Core_auditwwds_1_filterfulltext, AV91Core_auditwwds_4_auditdate1, AV92Core_auditwwds_5_auditdate_to1, AV91Core_auditwwds_4_auditdate1, AV91Core_auditwwds_4_auditdate1, AV91Core_auditwwds_4_auditdate1, AV96Core_auditwwds_9_auditdate2, AV97Core_auditwwds_10_auditdate_to2, AV96Core_auditwwds_9_auditdate2, AV96Core_auditwwds_9_auditdate2, AV96Core_auditwwds_9_auditdate2, AV101Core_auditwwds_14_auditdate3, AV102Core_auditwwds_15_auditdate_to3, AV101Core_auditwwds_14_auditdate3, AV101Core_auditwwds_14_auditdate3, AV101Core_auditwwds_14_auditdate3, AV103Core_auditwwds_16_tfauditdatetime, AV104Core_auditwwds_17_tfauditdatetime_to, AV105Core_auditwwds_18_tfauditdate, AV106Core_auditwwds_19_tfauditdate_to, AV107Core_auditwwds_20_tfaudittime, AV108Core_auditwwds_21_tfaudittime_to, lV109Core_auditwwds_22_tfaudittablename, AV110Core_auditwwds_23_tfaudittablename_sel, lV111Core_auditwwds_24_tfauditaction, AV112Core_auditwwds_25_tfauditaction_sel, lV113Core_auditwwds_26_tfauditshortdescription, AV114Core_auditwwds_27_tfauditshortdescription_sel, lV115Core_auditwwds_28_tfauditdescription, AV116Core_auditwwds_29_tfauditdescription_sel, lV117Core_auditwwds_30_tfauditgamusername, AV118Core_auditwwds_31_tfauditgamusername_sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_118_idx = 1;
            sGXsfl_118_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_118_idx), 4, 0), 4, "0");
            SubsflControlProps_1182( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A501AuditGAMUserName = H005O2_A501AuditGAMUserName[0];
               A498AuditDescription = H005O2_A498AuditDescription[0];
               A499AuditShortDescription = H005O2_A499AuditShortDescription[0];
               A502AuditAction = H005O2_A502AuditAction[0];
               A497AuditTableName = H005O2_A497AuditTableName[0];
               A495AuditTime = H005O2_A495AuditTime[0];
               A494AuditDate = H005O2_A494AuditDate[0];
               A496AuditDateTime = H005O2_A496AuditDateTime[0];
               A493AuditID = H005O2_A493AuditID[0];
               E345O2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 118;
            WB5O0( ) ;
         }
         bGXsfl_118_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes5O2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV87Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV87Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_AUDITDATE", AV80IsAuthorized_AuditDate);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_AUDITDATE", GetSecureSignedToken( "", AV80IsAuthorized_AuditDate, context));
         GxWebStd.gx_hidden_field( context, "vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vTODAY", GetSecureSignedToken( "", Gx_date, context));
         GxWebStd.gx_hidden_field( context, "gxhash_AUDITID"+"_"+sGXsfl_118_idx, GetSecureSignedToken( sGXsfl_118_idx, A493AuditID, context));
      }

      protected int subGrid_fnc_Pagecount( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGrid_fnc_Recordcount( )
      {
         AV88Core_auditwwds_1_filterfulltext = AV17FilterFullText;
         AV89Core_auditwwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV90Core_auditwwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV91Core_auditwwds_4_auditdate1 = AV20AuditDate1;
         AV92Core_auditwwds_5_auditdate_to1 = AV21AuditDate_To1;
         AV93Core_auditwwds_6_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV94Core_auditwwds_7_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV95Core_auditwwds_8_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV96Core_auditwwds_9_auditdate2 = AV25AuditDate2;
         AV97Core_auditwwds_10_auditdate_to2 = AV26AuditDate_To2;
         AV98Core_auditwwds_11_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV99Core_auditwwds_12_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV100Core_auditwwds_13_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV101Core_auditwwds_14_auditdate3 = AV30AuditDate3;
         AV102Core_auditwwds_15_auditdate_to3 = AV31AuditDate_To3;
         AV103Core_auditwwds_16_tfauditdatetime = AV81TFAuditDateTime;
         AV104Core_auditwwds_17_tfauditdatetime_to = AV82TFAuditDateTime_To;
         AV105Core_auditwwds_18_tfauditdate = AV44TFAuditDate;
         AV106Core_auditwwds_19_tfauditdate_to = AV45TFAuditDate_To;
         AV107Core_auditwwds_20_tfaudittime = AV49TFAuditTime;
         AV108Core_auditwwds_21_tfaudittime_to = AV50TFAuditTime_To;
         AV109Core_auditwwds_22_tfaudittablename = AV54TFAuditTableName;
         AV110Core_auditwwds_23_tfaudittablename_sel = AV55TFAuditTableName_Sel;
         AV111Core_auditwwds_24_tfauditaction = AV62TFAuditAction;
         AV112Core_auditwwds_25_tfauditaction_sel = AV63TFAuditAction_Sel;
         AV113Core_auditwwds_26_tfauditshortdescription = AV56TFAuditShortDescription;
         AV114Core_auditwwds_27_tfauditshortdescription_sel = AV57TFAuditShortDescription_Sel;
         AV115Core_auditwwds_28_tfauditdescription = AV58TFAuditDescription;
         AV116Core_auditwwds_29_tfauditdescription_sel = AV59TFAuditDescription_Sel;
         AV117Core_auditwwds_30_tfauditgamusername = AV60TFAuditGAMUserName;
         AV118Core_auditwwds_31_tfauditgamusername_sel = AV61TFAuditGAMUserName_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV88Core_auditwwds_1_filterfulltext ,
                                              AV89Core_auditwwds_2_dynamicfiltersselector1 ,
                                              AV90Core_auditwwds_3_dynamicfiltersoperator1 ,
                                              AV91Core_auditwwds_4_auditdate1 ,
                                              AV92Core_auditwwds_5_auditdate_to1 ,
                                              AV93Core_auditwwds_6_dynamicfiltersenabled2 ,
                                              AV94Core_auditwwds_7_dynamicfiltersselector2 ,
                                              AV95Core_auditwwds_8_dynamicfiltersoperator2 ,
                                              AV96Core_auditwwds_9_auditdate2 ,
                                              AV97Core_auditwwds_10_auditdate_to2 ,
                                              AV98Core_auditwwds_11_dynamicfiltersenabled3 ,
                                              AV99Core_auditwwds_12_dynamicfiltersselector3 ,
                                              AV100Core_auditwwds_13_dynamicfiltersoperator3 ,
                                              AV101Core_auditwwds_14_auditdate3 ,
                                              AV102Core_auditwwds_15_auditdate_to3 ,
                                              AV103Core_auditwwds_16_tfauditdatetime ,
                                              AV104Core_auditwwds_17_tfauditdatetime_to ,
                                              AV105Core_auditwwds_18_tfauditdate ,
                                              AV106Core_auditwwds_19_tfauditdate_to ,
                                              AV107Core_auditwwds_20_tfaudittime ,
                                              AV108Core_auditwwds_21_tfaudittime_to ,
                                              AV110Core_auditwwds_23_tfaudittablename_sel ,
                                              AV109Core_auditwwds_22_tfaudittablename ,
                                              AV112Core_auditwwds_25_tfauditaction_sel ,
                                              AV111Core_auditwwds_24_tfauditaction ,
                                              AV114Core_auditwwds_27_tfauditshortdescription_sel ,
                                              AV113Core_auditwwds_26_tfauditshortdescription ,
                                              AV116Core_auditwwds_29_tfauditdescription_sel ,
                                              AV115Core_auditwwds_28_tfauditdescription ,
                                              AV118Core_auditwwds_31_tfauditgamusername_sel ,
                                              AV117Core_auditwwds_30_tfauditgamusername ,
                                              A497AuditTableName ,
                                              A502AuditAction ,
                                              A499AuditShortDescription ,
                                              A498AuditDescription ,
                                              A501AuditGAMUserName ,
                                              A494AuditDate ,
                                              A496AuditDateTime ,
                                              A495AuditTime ,
                                              AV14OrderedBy ,
                                              AV15OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV88Core_auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV88Core_auditwwds_1_filterfulltext), "%", "");
         lV88Core_auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV88Core_auditwwds_1_filterfulltext), "%", "");
         lV88Core_auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV88Core_auditwwds_1_filterfulltext), "%", "");
         lV88Core_auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV88Core_auditwwds_1_filterfulltext), "%", "");
         lV88Core_auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV88Core_auditwwds_1_filterfulltext), "%", "");
         lV109Core_auditwwds_22_tfaudittablename = StringUtil.Concat( StringUtil.RTrim( AV109Core_auditwwds_22_tfaudittablename), "%", "");
         lV111Core_auditwwds_24_tfauditaction = StringUtil.Concat( StringUtil.RTrim( AV111Core_auditwwds_24_tfauditaction), "%", "");
         lV113Core_auditwwds_26_tfauditshortdescription = StringUtil.Concat( StringUtil.RTrim( AV113Core_auditwwds_26_tfauditshortdescription), "%", "");
         lV115Core_auditwwds_28_tfauditdescription = StringUtil.Concat( StringUtil.RTrim( AV115Core_auditwwds_28_tfauditdescription), "%", "");
         lV117Core_auditwwds_30_tfauditgamusername = StringUtil.Concat( StringUtil.RTrim( AV117Core_auditwwds_30_tfauditgamusername), "%", "");
         /* Using cursor H005O3 */
         pr_default.execute(1, new Object[] {lV88Core_auditwwds_1_filterfulltext, lV88Core_auditwwds_1_filterfulltext, lV88Core_auditwwds_1_filterfulltext, lV88Core_auditwwds_1_filterfulltext, lV88Core_auditwwds_1_filterfulltext, AV91Core_auditwwds_4_auditdate1, AV92Core_auditwwds_5_auditdate_to1, AV91Core_auditwwds_4_auditdate1, AV91Core_auditwwds_4_auditdate1, AV91Core_auditwwds_4_auditdate1, AV96Core_auditwwds_9_auditdate2, AV97Core_auditwwds_10_auditdate_to2, AV96Core_auditwwds_9_auditdate2, AV96Core_auditwwds_9_auditdate2, AV96Core_auditwwds_9_auditdate2, AV101Core_auditwwds_14_auditdate3, AV102Core_auditwwds_15_auditdate_to3, AV101Core_auditwwds_14_auditdate3, AV101Core_auditwwds_14_auditdate3, AV101Core_auditwwds_14_auditdate3, AV103Core_auditwwds_16_tfauditdatetime, AV104Core_auditwwds_17_tfauditdatetime_to, AV105Core_auditwwds_18_tfauditdate, AV106Core_auditwwds_19_tfauditdate_to, AV107Core_auditwwds_20_tfaudittime, AV108Core_auditwwds_21_tfaudittime_to, lV109Core_auditwwds_22_tfaudittablename, AV110Core_auditwwds_23_tfaudittablename_sel, lV111Core_auditwwds_24_tfauditaction, AV112Core_auditwwds_25_tfauditaction_sel, lV113Core_auditwwds_26_tfauditshortdescription, AV114Core_auditwwds_27_tfauditshortdescription_sel, lV115Core_auditwwds_28_tfauditdescription, AV116Core_auditwwds_29_tfauditdescription_sel, lV117Core_auditwwds_30_tfauditgamusername, AV118Core_auditwwds_31_tfauditgamusername_sel});
         GRID_nRecordCount = H005O3_AGRID_nRecordCount[0];
         pr_default.close(1);
         return (int)(GRID_nRecordCount) ;
      }

      protected int subGrid_fnc_Recordsperpage( )
      {
         if ( subGrid_Rows > 0 )
         {
            return subGrid_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGrid_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nFirstRecordOnPage/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgrid_firstpage( )
      {
         AV88Core_auditwwds_1_filterfulltext = AV17FilterFullText;
         AV89Core_auditwwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV90Core_auditwwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV91Core_auditwwds_4_auditdate1 = AV20AuditDate1;
         AV92Core_auditwwds_5_auditdate_to1 = AV21AuditDate_To1;
         AV93Core_auditwwds_6_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV94Core_auditwwds_7_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV95Core_auditwwds_8_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV96Core_auditwwds_9_auditdate2 = AV25AuditDate2;
         AV97Core_auditwwds_10_auditdate_to2 = AV26AuditDate_To2;
         AV98Core_auditwwds_11_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV99Core_auditwwds_12_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV100Core_auditwwds_13_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV101Core_auditwwds_14_auditdate3 = AV30AuditDate3;
         AV102Core_auditwwds_15_auditdate_to3 = AV31AuditDate_To3;
         AV103Core_auditwwds_16_tfauditdatetime = AV81TFAuditDateTime;
         AV104Core_auditwwds_17_tfauditdatetime_to = AV82TFAuditDateTime_To;
         AV105Core_auditwwds_18_tfauditdate = AV44TFAuditDate;
         AV106Core_auditwwds_19_tfauditdate_to = AV45TFAuditDate_To;
         AV107Core_auditwwds_20_tfaudittime = AV49TFAuditTime;
         AV108Core_auditwwds_21_tfaudittime_to = AV50TFAuditTime_To;
         AV109Core_auditwwds_22_tfaudittablename = AV54TFAuditTableName;
         AV110Core_auditwwds_23_tfaudittablename_sel = AV55TFAuditTableName_Sel;
         AV111Core_auditwwds_24_tfauditaction = AV62TFAuditAction;
         AV112Core_auditwwds_25_tfauditaction_sel = AV63TFAuditAction_Sel;
         AV113Core_auditwwds_26_tfauditshortdescription = AV56TFAuditShortDescription;
         AV114Core_auditwwds_27_tfauditshortdescription_sel = AV57TFAuditShortDescription_Sel;
         AV115Core_auditwwds_28_tfauditdescription = AV58TFAuditDescription;
         AV116Core_auditwwds_29_tfauditdescription_sel = AV59TFAuditDescription_Sel;
         AV117Core_auditwwds_30_tfauditgamusername = AV60TFAuditGAMUserName;
         AV118Core_auditwwds_31_tfauditgamusername_sel = AV61TFAuditGAMUserName_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV20AuditDate1, AV25AuditDate2, AV30AuditDate3, AV43ManageFiltersExecutionStep, AV38ColumnsSelector, AV87Pgmname, AV21AuditDate_To1, AV22DynamicFiltersEnabled2, AV26AuditDate_To2, AV27DynamicFiltersEnabled3, AV31AuditDate_To3, AV81TFAuditDateTime, AV82TFAuditDateTime_To, AV44TFAuditDate, AV45TFAuditDate_To, AV49TFAuditTime, AV50TFAuditTime_To, AV54TFAuditTableName, AV55TFAuditTableName_Sel, AV62TFAuditAction, AV63TFAuditAction_Sel, AV56TFAuditShortDescription, AV57TFAuditShortDescription_Sel, AV58TFAuditDescription, AV59TFAuditDescription_Sel, AV60TFAuditGAMUserName, AV61TFAuditGAMUserName_Sel, AV14OrderedBy, AV15OrderedDsc, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV80IsAuthorized_AuditDate, Gx_date) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV88Core_auditwwds_1_filterfulltext = AV17FilterFullText;
         AV89Core_auditwwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV90Core_auditwwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV91Core_auditwwds_4_auditdate1 = AV20AuditDate1;
         AV92Core_auditwwds_5_auditdate_to1 = AV21AuditDate_To1;
         AV93Core_auditwwds_6_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV94Core_auditwwds_7_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV95Core_auditwwds_8_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV96Core_auditwwds_9_auditdate2 = AV25AuditDate2;
         AV97Core_auditwwds_10_auditdate_to2 = AV26AuditDate_To2;
         AV98Core_auditwwds_11_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV99Core_auditwwds_12_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV100Core_auditwwds_13_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV101Core_auditwwds_14_auditdate3 = AV30AuditDate3;
         AV102Core_auditwwds_15_auditdate_to3 = AV31AuditDate_To3;
         AV103Core_auditwwds_16_tfauditdatetime = AV81TFAuditDateTime;
         AV104Core_auditwwds_17_tfauditdatetime_to = AV82TFAuditDateTime_To;
         AV105Core_auditwwds_18_tfauditdate = AV44TFAuditDate;
         AV106Core_auditwwds_19_tfauditdate_to = AV45TFAuditDate_To;
         AV107Core_auditwwds_20_tfaudittime = AV49TFAuditTime;
         AV108Core_auditwwds_21_tfaudittime_to = AV50TFAuditTime_To;
         AV109Core_auditwwds_22_tfaudittablename = AV54TFAuditTableName;
         AV110Core_auditwwds_23_tfaudittablename_sel = AV55TFAuditTableName_Sel;
         AV111Core_auditwwds_24_tfauditaction = AV62TFAuditAction;
         AV112Core_auditwwds_25_tfauditaction_sel = AV63TFAuditAction_Sel;
         AV113Core_auditwwds_26_tfauditshortdescription = AV56TFAuditShortDescription;
         AV114Core_auditwwds_27_tfauditshortdescription_sel = AV57TFAuditShortDescription_Sel;
         AV115Core_auditwwds_28_tfauditdescription = AV58TFAuditDescription;
         AV116Core_auditwwds_29_tfauditdescription_sel = AV59TFAuditDescription_Sel;
         AV117Core_auditwwds_30_tfauditgamusername = AV60TFAuditGAMUserName;
         AV118Core_auditwwds_31_tfauditgamusername_sel = AV61TFAuditGAMUserName_Sel;
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ( GRID_nRecordCount >= subGrid_fnc_Recordsperpage( ) ) && ( GRID_nEOF == 0 ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV20AuditDate1, AV25AuditDate2, AV30AuditDate3, AV43ManageFiltersExecutionStep, AV38ColumnsSelector, AV87Pgmname, AV21AuditDate_To1, AV22DynamicFiltersEnabled2, AV26AuditDate_To2, AV27DynamicFiltersEnabled3, AV31AuditDate_To3, AV81TFAuditDateTime, AV82TFAuditDateTime_To, AV44TFAuditDate, AV45TFAuditDate_To, AV49TFAuditTime, AV50TFAuditTime_To, AV54TFAuditTableName, AV55TFAuditTableName_Sel, AV62TFAuditAction, AV63TFAuditAction_Sel, AV56TFAuditShortDescription, AV57TFAuditShortDescription_Sel, AV58TFAuditDescription, AV59TFAuditDescription_Sel, AV60TFAuditGAMUserName, AV61TFAuditGAMUserName_Sel, AV14OrderedBy, AV15OrderedDsc, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV80IsAuthorized_AuditDate, Gx_date) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV88Core_auditwwds_1_filterfulltext = AV17FilterFullText;
         AV89Core_auditwwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV90Core_auditwwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV91Core_auditwwds_4_auditdate1 = AV20AuditDate1;
         AV92Core_auditwwds_5_auditdate_to1 = AV21AuditDate_To1;
         AV93Core_auditwwds_6_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV94Core_auditwwds_7_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV95Core_auditwwds_8_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV96Core_auditwwds_9_auditdate2 = AV25AuditDate2;
         AV97Core_auditwwds_10_auditdate_to2 = AV26AuditDate_To2;
         AV98Core_auditwwds_11_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV99Core_auditwwds_12_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV100Core_auditwwds_13_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV101Core_auditwwds_14_auditdate3 = AV30AuditDate3;
         AV102Core_auditwwds_15_auditdate_to3 = AV31AuditDate_To3;
         AV103Core_auditwwds_16_tfauditdatetime = AV81TFAuditDateTime;
         AV104Core_auditwwds_17_tfauditdatetime_to = AV82TFAuditDateTime_To;
         AV105Core_auditwwds_18_tfauditdate = AV44TFAuditDate;
         AV106Core_auditwwds_19_tfauditdate_to = AV45TFAuditDate_To;
         AV107Core_auditwwds_20_tfaudittime = AV49TFAuditTime;
         AV108Core_auditwwds_21_tfaudittime_to = AV50TFAuditTime_To;
         AV109Core_auditwwds_22_tfaudittablename = AV54TFAuditTableName;
         AV110Core_auditwwds_23_tfaudittablename_sel = AV55TFAuditTableName_Sel;
         AV111Core_auditwwds_24_tfauditaction = AV62TFAuditAction;
         AV112Core_auditwwds_25_tfauditaction_sel = AV63TFAuditAction_Sel;
         AV113Core_auditwwds_26_tfauditshortdescription = AV56TFAuditShortDescription;
         AV114Core_auditwwds_27_tfauditshortdescription_sel = AV57TFAuditShortDescription_Sel;
         AV115Core_auditwwds_28_tfauditdescription = AV58TFAuditDescription;
         AV116Core_auditwwds_29_tfauditdescription_sel = AV59TFAuditDescription_Sel;
         AV117Core_auditwwds_30_tfauditgamusername = AV60TFAuditGAMUserName;
         AV118Core_auditwwds_31_tfauditgamusername_sel = AV61TFAuditGAMUserName_Sel;
         if ( GRID_nFirstRecordOnPage >= subGrid_fnc_Recordsperpage( ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage-subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV20AuditDate1, AV25AuditDate2, AV30AuditDate3, AV43ManageFiltersExecutionStep, AV38ColumnsSelector, AV87Pgmname, AV21AuditDate_To1, AV22DynamicFiltersEnabled2, AV26AuditDate_To2, AV27DynamicFiltersEnabled3, AV31AuditDate_To3, AV81TFAuditDateTime, AV82TFAuditDateTime_To, AV44TFAuditDate, AV45TFAuditDate_To, AV49TFAuditTime, AV50TFAuditTime_To, AV54TFAuditTableName, AV55TFAuditTableName_Sel, AV62TFAuditAction, AV63TFAuditAction_Sel, AV56TFAuditShortDescription, AV57TFAuditShortDescription_Sel, AV58TFAuditDescription, AV59TFAuditDescription_Sel, AV60TFAuditGAMUserName, AV61TFAuditGAMUserName_Sel, AV14OrderedBy, AV15OrderedDsc, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV80IsAuthorized_AuditDate, Gx_date) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV88Core_auditwwds_1_filterfulltext = AV17FilterFullText;
         AV89Core_auditwwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV90Core_auditwwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV91Core_auditwwds_4_auditdate1 = AV20AuditDate1;
         AV92Core_auditwwds_5_auditdate_to1 = AV21AuditDate_To1;
         AV93Core_auditwwds_6_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV94Core_auditwwds_7_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV95Core_auditwwds_8_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV96Core_auditwwds_9_auditdate2 = AV25AuditDate2;
         AV97Core_auditwwds_10_auditdate_to2 = AV26AuditDate_To2;
         AV98Core_auditwwds_11_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV99Core_auditwwds_12_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV100Core_auditwwds_13_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV101Core_auditwwds_14_auditdate3 = AV30AuditDate3;
         AV102Core_auditwwds_15_auditdate_to3 = AV31AuditDate_To3;
         AV103Core_auditwwds_16_tfauditdatetime = AV81TFAuditDateTime;
         AV104Core_auditwwds_17_tfauditdatetime_to = AV82TFAuditDateTime_To;
         AV105Core_auditwwds_18_tfauditdate = AV44TFAuditDate;
         AV106Core_auditwwds_19_tfauditdate_to = AV45TFAuditDate_To;
         AV107Core_auditwwds_20_tfaudittime = AV49TFAuditTime;
         AV108Core_auditwwds_21_tfaudittime_to = AV50TFAuditTime_To;
         AV109Core_auditwwds_22_tfaudittablename = AV54TFAuditTableName;
         AV110Core_auditwwds_23_tfaudittablename_sel = AV55TFAuditTableName_Sel;
         AV111Core_auditwwds_24_tfauditaction = AV62TFAuditAction;
         AV112Core_auditwwds_25_tfauditaction_sel = AV63TFAuditAction_Sel;
         AV113Core_auditwwds_26_tfauditshortdescription = AV56TFAuditShortDescription;
         AV114Core_auditwwds_27_tfauditshortdescription_sel = AV57TFAuditShortDescription_Sel;
         AV115Core_auditwwds_28_tfauditdescription = AV58TFAuditDescription;
         AV116Core_auditwwds_29_tfauditdescription_sel = AV59TFAuditDescription_Sel;
         AV117Core_auditwwds_30_tfauditgamusername = AV60TFAuditGAMUserName;
         AV118Core_auditwwds_31_tfauditgamusername_sel = AV61TFAuditGAMUserName_Sel;
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( GRID_nRecordCount > subGrid_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-subGrid_fnc_Recordsperpage( ));
            }
            else
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV20AuditDate1, AV25AuditDate2, AV30AuditDate3, AV43ManageFiltersExecutionStep, AV38ColumnsSelector, AV87Pgmname, AV21AuditDate_To1, AV22DynamicFiltersEnabled2, AV26AuditDate_To2, AV27DynamicFiltersEnabled3, AV31AuditDate_To3, AV81TFAuditDateTime, AV82TFAuditDateTime_To, AV44TFAuditDate, AV45TFAuditDate_To, AV49TFAuditTime, AV50TFAuditTime_To, AV54TFAuditTableName, AV55TFAuditTableName_Sel, AV62TFAuditAction, AV63TFAuditAction_Sel, AV56TFAuditShortDescription, AV57TFAuditShortDescription_Sel, AV58TFAuditDescription, AV59TFAuditDescription_Sel, AV60TFAuditGAMUserName, AV61TFAuditGAMUserName_Sel, AV14OrderedBy, AV15OrderedDsc, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV80IsAuthorized_AuditDate, Gx_date) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV88Core_auditwwds_1_filterfulltext = AV17FilterFullText;
         AV89Core_auditwwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV90Core_auditwwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV91Core_auditwwds_4_auditdate1 = AV20AuditDate1;
         AV92Core_auditwwds_5_auditdate_to1 = AV21AuditDate_To1;
         AV93Core_auditwwds_6_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV94Core_auditwwds_7_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV95Core_auditwwds_8_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV96Core_auditwwds_9_auditdate2 = AV25AuditDate2;
         AV97Core_auditwwds_10_auditdate_to2 = AV26AuditDate_To2;
         AV98Core_auditwwds_11_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV99Core_auditwwds_12_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV100Core_auditwwds_13_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV101Core_auditwwds_14_auditdate3 = AV30AuditDate3;
         AV102Core_auditwwds_15_auditdate_to3 = AV31AuditDate_To3;
         AV103Core_auditwwds_16_tfauditdatetime = AV81TFAuditDateTime;
         AV104Core_auditwwds_17_tfauditdatetime_to = AV82TFAuditDateTime_To;
         AV105Core_auditwwds_18_tfauditdate = AV44TFAuditDate;
         AV106Core_auditwwds_19_tfauditdate_to = AV45TFAuditDate_To;
         AV107Core_auditwwds_20_tfaudittime = AV49TFAuditTime;
         AV108Core_auditwwds_21_tfaudittime_to = AV50TFAuditTime_To;
         AV109Core_auditwwds_22_tfaudittablename = AV54TFAuditTableName;
         AV110Core_auditwwds_23_tfaudittablename_sel = AV55TFAuditTableName_Sel;
         AV111Core_auditwwds_24_tfauditaction = AV62TFAuditAction;
         AV112Core_auditwwds_25_tfauditaction_sel = AV63TFAuditAction_Sel;
         AV113Core_auditwwds_26_tfauditshortdescription = AV56TFAuditShortDescription;
         AV114Core_auditwwds_27_tfauditshortdescription_sel = AV57TFAuditShortDescription_Sel;
         AV115Core_auditwwds_28_tfauditdescription = AV58TFAuditDescription;
         AV116Core_auditwwds_29_tfauditdescription_sel = AV59TFAuditDescription_Sel;
         AV117Core_auditwwds_30_tfauditgamusername = AV60TFAuditGAMUserName;
         AV118Core_auditwwds_31_tfauditgamusername_sel = AV61TFAuditGAMUserName_Sel;
         if ( nPageNo > 0 )
         {
            GRID_nFirstRecordOnPage = (long)(subGrid_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV20AuditDate1, AV25AuditDate2, AV30AuditDate3, AV43ManageFiltersExecutionStep, AV38ColumnsSelector, AV87Pgmname, AV21AuditDate_To1, AV22DynamicFiltersEnabled2, AV26AuditDate_To2, AV27DynamicFiltersEnabled3, AV31AuditDate_To3, AV81TFAuditDateTime, AV82TFAuditDateTime_To, AV44TFAuditDate, AV45TFAuditDate_To, AV49TFAuditTime, AV50TFAuditTime_To, AV54TFAuditTableName, AV55TFAuditTableName_Sel, AV62TFAuditAction, AV63TFAuditAction_Sel, AV56TFAuditShortDescription, AV57TFAuditShortDescription_Sel, AV58TFAuditDescription, AV59TFAuditDescription_Sel, AV60TFAuditGAMUserName, AV61TFAuditGAMUserName_Sel, AV14OrderedBy, AV15OrderedDsc, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV80IsAuthorized_AuditDate, Gx_date) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         Gx_date = DateTimeUtil.Today( context);
         AV87Pgmname = "core.AuditWW";
         edtavDetailwebcomponent_Enabled = 0;
         AssignProp("", false, edtavDetailwebcomponent_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDetailwebcomponent_Enabled), 5, 0), !bGXsfl_118_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP5O0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E325O2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV41ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vAGEXPORTDATA"), AV74AGExportData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV64DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vCOLUMNSSELECTOR"), AV38ColumnsSelector);
            /* Read saved values. */
            nRC_GXsfl_118 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_118"), ",", "."), 18, MidpointRounding.ToEven));
            AV68GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ",", "."), 18, MidpointRounding.ToEven));
            AV69GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ",", "."), 18, MidpointRounding.ToEven));
            AV70GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            AV20AuditDate1 = context.localUtil.CToD( cgiGet( "vAUDITDATE1"), 0);
            AV21AuditDate_To1 = context.localUtil.CToD( cgiGet( "vAUDITDATE_TO1"), 0);
            AV25AuditDate2 = context.localUtil.CToD( cgiGet( "vAUDITDATE2"), 0);
            AV26AuditDate_To2 = context.localUtil.CToD( cgiGet( "vAUDITDATE_TO2"), 0);
            AV30AuditDate3 = context.localUtil.CToD( cgiGet( "vAUDITDATE3"), 0);
            AV31AuditDate_To3 = context.localUtil.CToD( cgiGet( "vAUDITDATE_TO3"), 0);
            AV83DDO_AuditDateTimeAuxDate = context.localUtil.CToD( cgiGet( "vDDO_AUDITDATETIMEAUXDATE"), 0);
            AV84DDO_AuditDateTimeAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_AUDITDATETIMEAUXDATETO"), 0);
            AV46DDO_AuditDateAuxDate = context.localUtil.CToD( cgiGet( "vDDO_AUDITDATEAUXDATE"), 0);
            AV47DDO_AuditDateAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_AUDITDATEAUXDATETO"), 0);
            AV51DDO_AuditTimeAuxDate = context.localUtil.CToD( cgiGet( "vDDO_AUDITTIMEAUXDATE"), 0);
            AV52DDO_AuditTimeAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_AUDITTIMEAUXDATETO"), 0);
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), ",", "."), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nEOF"), ",", "."), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Ddo_managefilters_Icontype = cgiGet( "DDO_MANAGEFILTERS_Icontype");
            Ddo_managefilters_Icon = cgiGet( "DDO_MANAGEFILTERS_Icon");
            Ddo_managefilters_Tooltip = cgiGet( "DDO_MANAGEFILTERS_Tooltip");
            Ddo_managefilters_Cls = cgiGet( "DDO_MANAGEFILTERS_Cls");
            Gridpaginationbar_Class = cgiGet( "GRIDPAGINATIONBAR_Class");
            Gridpaginationbar_Showfirst = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Showfirst"));
            Gridpaginationbar_Showprevious = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Showprevious"));
            Gridpaginationbar_Shownext = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Shownext"));
            Gridpaginationbar_Showlast = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Showlast"));
            Gridpaginationbar_Pagestoshow = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Pagestoshow"), ",", "."), 18, MidpointRounding.ToEven));
            Gridpaginationbar_Pagingbuttonsposition = cgiGet( "GRIDPAGINATIONBAR_Pagingbuttonsposition");
            Gridpaginationbar_Pagingcaptionposition = cgiGet( "GRIDPAGINATIONBAR_Pagingcaptionposition");
            Gridpaginationbar_Emptygridclass = cgiGet( "GRIDPAGINATIONBAR_Emptygridclass");
            Gridpaginationbar_Rowsperpageselector = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselector"));
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), ",", "."), 18, MidpointRounding.ToEven));
            Gridpaginationbar_Rowsperpageoptions = cgiGet( "GRIDPAGINATIONBAR_Rowsperpageoptions");
            Gridpaginationbar_First = cgiGet( "GRIDPAGINATIONBAR_First");
            Gridpaginationbar_Previous = cgiGet( "GRIDPAGINATIONBAR_Previous");
            Gridpaginationbar_Next = cgiGet( "GRIDPAGINATIONBAR_Next");
            Gridpaginationbar_Last = cgiGet( "GRIDPAGINATIONBAR_Last");
            Gridpaginationbar_Caption = cgiGet( "GRIDPAGINATIONBAR_Caption");
            Gridpaginationbar_Emptygridcaption = cgiGet( "GRIDPAGINATIONBAR_Emptygridcaption");
            Gridpaginationbar_Rowsperpagecaption = cgiGet( "GRIDPAGINATIONBAR_Rowsperpagecaption");
            Ddo_agexport_Icontype = cgiGet( "DDO_AGEXPORT_Icontype");
            Ddo_agexport_Icon = cgiGet( "DDO_AGEXPORT_Icon");
            Ddo_agexport_Caption = cgiGet( "DDO_AGEXPORT_Caption");
            Ddo_agexport_Cls = cgiGet( "DDO_AGEXPORT_Cls");
            Ddo_agexport_Titlecontrolidtoreplace = cgiGet( "DDO_AGEXPORT_Titlecontrolidtoreplace");
            Ddc_subscriptions_Icontype = cgiGet( "DDC_SUBSCRIPTIONS_Icontype");
            Ddc_subscriptions_Icon = cgiGet( "DDC_SUBSCRIPTIONS_Icon");
            Ddc_subscriptions_Caption = cgiGet( "DDC_SUBSCRIPTIONS_Caption");
            Ddc_subscriptions_Tooltip = cgiGet( "DDC_SUBSCRIPTIONS_Tooltip");
            Ddc_subscriptions_Cls = cgiGet( "DDC_SUBSCRIPTIONS_Cls");
            Ddc_subscriptions_Titlecontrolidtoreplace = cgiGet( "DDC_SUBSCRIPTIONS_Titlecontrolidtoreplace");
            Ddo_grid_Caption = cgiGet( "DDO_GRID_Caption");
            Ddo_grid_Filteredtext_set = cgiGet( "DDO_GRID_Filteredtext_set");
            Ddo_grid_Filteredtextto_set = cgiGet( "DDO_GRID_Filteredtextto_set");
            Ddo_grid_Selectedvalue_set = cgiGet( "DDO_GRID_Selectedvalue_set");
            Ddo_grid_Gamoauthtoken = cgiGet( "DDO_GRID_Gamoauthtoken");
            Ddo_grid_Gridinternalname = cgiGet( "DDO_GRID_Gridinternalname");
            Ddo_grid_Columnids = cgiGet( "DDO_GRID_Columnids");
            Ddo_grid_Columnssortvalues = cgiGet( "DDO_GRID_Columnssortvalues");
            Ddo_grid_Includesortasc = cgiGet( "DDO_GRID_Includesortasc");
            Ddo_grid_Fixable = cgiGet( "DDO_GRID_Fixable");
            Ddo_grid_Sortedstatus = cgiGet( "DDO_GRID_Sortedstatus");
            Ddo_grid_Includefilter = cgiGet( "DDO_GRID_Includefilter");
            Ddo_grid_Filtertype = cgiGet( "DDO_GRID_Filtertype");
            Ddo_grid_Filterisrange = cgiGet( "DDO_GRID_Filterisrange");
            Ddo_grid_Includedatalist = cgiGet( "DDO_GRID_Includedatalist");
            Ddo_grid_Datalisttype = cgiGet( "DDO_GRID_Datalisttype");
            Ddo_grid_Datalistproc = cgiGet( "DDO_GRID_Datalistproc");
            Innewwindow1_Width = cgiGet( "INNEWWINDOW1_Width");
            Innewwindow1_Height = cgiGet( "INNEWWINDOW1_Height");
            Innewwindow1_Target = cgiGet( "INNEWWINDOW1_Target");
            Ddo_gridcolumnsselector_Icontype = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Icontype");
            Ddo_gridcolumnsselector_Icon = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Icon");
            Ddo_gridcolumnsselector_Caption = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Caption");
            Ddo_gridcolumnsselector_Tooltip = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Tooltip");
            Ddo_gridcolumnsselector_Cls = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Cls");
            Ddo_gridcolumnsselector_Dropdownoptionstype = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Dropdownoptionstype");
            Ddo_gridcolumnsselector_Gridinternalname = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Gridinternalname");
            Ddo_gridcolumnsselector_Titlecontrolidtoreplace = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Titlecontrolidtoreplace");
            Grid_empowerer_Gridinternalname = cgiGet( "GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hastitlesettings"));
            Grid_empowerer_Hascolumnsselector = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hascolumnsselector"));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Gridpaginationbar_Selectedpage = cgiGet( "GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), ",", "."), 18, MidpointRounding.ToEven));
            Ddo_grid_Activeeventkey = cgiGet( "DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( "DDO_GRID_Selectedvalue_get");
            Ddo_grid_Filteredtextto_get = cgiGet( "DDO_GRID_Filteredtextto_get");
            Ddo_grid_Filteredtext_get = cgiGet( "DDO_GRID_Filteredtext_get");
            Ddo_grid_Selectedcolumn = cgiGet( "DDO_GRID_Selectedcolumn");
            Ddo_gridcolumnsselector_Columnsselectorvalues = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues");
            Ddo_managefilters_Activeeventkey = cgiGet( "DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Ddo_agexport_Activeeventkey = cgiGet( "DDO_AGEXPORT_Activeeventkey");
            /* Read variables values. */
            AV17FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV17FilterFullText", AV17FilterFullText);
            cmbavDynamicfiltersselector1.Name = cmbavDynamicfiltersselector1_Internalname;
            cmbavDynamicfiltersselector1.CurrentValue = cgiGet( cmbavDynamicfiltersselector1_Internalname);
            AV18DynamicFiltersSelector1 = cgiGet( cmbavDynamicfiltersselector1_Internalname);
            AssignAttri("", false, "AV18DynamicFiltersSelector1", AV18DynamicFiltersSelector1);
            cmbavDynamicfiltersoperator1.Name = cmbavDynamicfiltersoperator1_Internalname;
            cmbavDynamicfiltersoperator1.CurrentValue = cgiGet( cmbavDynamicfiltersoperator1_Internalname);
            AV19DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator1_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
            AV77AuditDate_RangeText1 = cgiGet( edtavAuditdate_rangetext1_Internalname);
            AssignAttri("", false, "AV77AuditDate_RangeText1", AV77AuditDate_RangeText1);
            cmbavDynamicfiltersselector2.Name = cmbavDynamicfiltersselector2_Internalname;
            cmbavDynamicfiltersselector2.CurrentValue = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AV23DynamicFiltersSelector2 = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AssignAttri("", false, "AV23DynamicFiltersSelector2", AV23DynamicFiltersSelector2);
            cmbavDynamicfiltersoperator2.Name = cmbavDynamicfiltersoperator2_Internalname;
            cmbavDynamicfiltersoperator2.CurrentValue = cgiGet( cmbavDynamicfiltersoperator2_Internalname);
            AV24DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator2_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV24DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
            AV78AuditDate_RangeText2 = cgiGet( edtavAuditdate_rangetext2_Internalname);
            AssignAttri("", false, "AV78AuditDate_RangeText2", AV78AuditDate_RangeText2);
            cmbavDynamicfiltersselector3.Name = cmbavDynamicfiltersselector3_Internalname;
            cmbavDynamicfiltersselector3.CurrentValue = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AV28DynamicFiltersSelector3 = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AssignAttri("", false, "AV28DynamicFiltersSelector3", AV28DynamicFiltersSelector3);
            cmbavDynamicfiltersoperator3.Name = cmbavDynamicfiltersoperator3_Internalname;
            cmbavDynamicfiltersoperator3.CurrentValue = cgiGet( cmbavDynamicfiltersoperator3_Internalname);
            AV29DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator3_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV29DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
            AV79AuditDate_RangeText3 = cgiGet( edtavAuditdate_rangetext3_Internalname);
            AssignAttri("", false, "AV79AuditDate_RangeText3", AV79AuditDate_RangeText3);
            AV85DDO_AuditDateTimeAuxDateText = cgiGet( edtavDdo_auditdatetimeauxdatetext_Internalname);
            AssignAttri("", false, "AV85DDO_AuditDateTimeAuxDateText", AV85DDO_AuditDateTimeAuxDateText);
            AV48DDO_AuditDateAuxDateText = cgiGet( edtavDdo_auditdateauxdatetext_Internalname);
            AssignAttri("", false, "AV48DDO_AuditDateAuxDateText", AV48DDO_AuditDateAuxDateText);
            AV53DDO_AuditTimeAuxDateText = cgiGet( edtavDdo_audittimeauxdatetext_Internalname);
            AssignAttri("", false, "AV53DDO_AuditTimeAuxDateText", AV53DDO_AuditTimeAuxDateText);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV17FilterFullText) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR1"), AV18DynamicFiltersSelector1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR1"), ",", ".") != Convert.ToDecimal( AV19DynamicFiltersOperator1 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV23DynamicFiltersSelector2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR2"), ",", ".") != Convert.ToDecimal( AV24DynamicFiltersOperator2 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV28DynamicFiltersSelector3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR3"), ",", ".") != Convert.ToDecimal( AV29DynamicFiltersOperator3 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vAUDITDATE1"), 2) ) != DateTimeUtil.ResetTime ( AV20AuditDate1 ) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vAUDITDATE2"), 2) ) != DateTimeUtil.ResetTime ( AV25AuditDate2 ) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vAUDITDATE3"), 2) ) != DateTimeUtil.ResetTime ( AV30AuditDate3 ) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E325O2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E325O2( )
      {
         /* Start Routine */
         returnInSub = false;
         this.executeUsercontrolMethod("", false, "TFAUDITTIME_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_audittimeauxdatetext_Internalname});
         this.executeUsercontrolMethod("", false, "TFAUDITDATE_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_auditdateauxdatetext_Internalname});
         this.executeUsercontrolMethod("", false, "TFAUDITDATETIME_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_auditdatetimeauxdatetext_Internalname});
         divCell_grid_dwc_Class = "Invisible WCD_"+StringUtil.Upper( subGrid_Internalname);
         AssignProp("", false, divCell_grid_dwc_Internalname, "Class", divCell_grid_dwc_Class, true);
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         Ddo_gridcolumnsselector_Gridinternalname = subGrid_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "GridInternalName", Ddo_gridcolumnsselector_Gridinternalname);
         if ( StringUtil.StrCmp(AV8HTTPRequest.Method, "GET") == 0 )
         {
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         lblJsdynamicfilters_Caption = "";
         AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         this.executeUsercontrolMethod("", false, "AUDITDATE_RANGEPICKER1Container", "Attach", "", new Object[] {(string)edtavAuditdate_rangetext1_Internalname});
         AV18DynamicFiltersSelector1 = "AUDITDATE";
         AssignAttri("", false, "AV18DynamicFiltersSelector1", AV18DynamicFiltersSelector1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         this.executeUsercontrolMethod("", false, "AUDITDATE_RANGEPICKER2Container", "Attach", "", new Object[] {(string)edtavAuditdate_rangetext2_Internalname});
         AV23DynamicFiltersSelector2 = "AUDITDATE";
         AssignAttri("", false, "AV23DynamicFiltersSelector2", AV23DynamicFiltersSelector2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         this.executeUsercontrolMethod("", false, "AUDITDATE_RANGEPICKER3Container", "Attach", "", new Object[] {(string)edtavAuditdate_rangetext3_Internalname});
         AV28DynamicFiltersSelector3 = "AUDITDATE";
         AssignAttri("", false, "AV28DynamicFiltersSelector3", AV28DynamicFiltersSelector3);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         imgAdddynamicfilters1_Jsonclick = StringUtil.Format( "WWPDynFilterShow_AL('%1', 2, 0)", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
         AssignProp("", false, imgAdddynamicfilters1_Internalname, "Jsonclick", imgAdddynamicfilters1_Jsonclick, true);
         imgRemovedynamicfilters1_Jsonclick = StringUtil.Format( "WWPDynFilterHideLast_AL('%1', 3, 0)", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
         AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Jsonclick", imgRemovedynamicfilters1_Jsonclick, true);
         imgAdddynamicfilters2_Jsonclick = StringUtil.Format( "WWPDynFilterShow_AL('%1', 3, 0)", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Jsonclick", imgAdddynamicfilters2_Jsonclick, true);
         imgRemovedynamicfilters2_Jsonclick = StringUtil.Format( "WWPDynFilterHideLast_AL('%1', 3, 0)", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Jsonclick", imgRemovedynamicfilters2_Jsonclick, true);
         imgRemovedynamicfilters3_Jsonclick = StringUtil.Format( "WWPDynFilterHideLast_AL('%1', 3, 0)", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
         AssignProp("", false, imgRemovedynamicfilters3_Internalname, "Jsonclick", imgRemovedynamicfilters3_Jsonclick, true);
         Ddo_agexport_Titlecontrolidtoreplace = bttBtnagexport_Internalname;
         ucDdo_agexport.SendProperty(context, "", false, Ddo_agexport_Internalname, "TitleControlIdToReplace", Ddo_agexport_Titlecontrolidtoreplace);
         AV74AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV75AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV75AGExportDataItem.gxTpr_Title = "Excel";
         AV75AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "da69a816-fd11-445b-8aaf-1a2f7f1acc93", "", context.GetTheme( ))));
         AV75AGExportDataItem.gxTpr_Eventkey = "Export";
         AV75AGExportDataItem.gxTpr_Isdivider = false;
         AV74AGExportData.Add(AV75AGExportDataItem, 0);
         AV75AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV75AGExportDataItem.gxTpr_Title = "PDF";
         AV75AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "776fb79c-a0a1-4302-b5e5-d773dbe1a297", "", context.GetTheme( ))));
         AV75AGExportDataItem.gxTpr_Eventkey = "ExportReport";
         AV75AGExportDataItem.gxTpr_Isdivider = false;
         AV74AGExportData.Add(AV75AGExportDataItem, 0);
         Ddc_subscriptions_Titlecontrolidtoreplace = bttBtnsubscriptions_Internalname;
         ucDdc_subscriptions.SendProperty(context, "", false, Ddc_subscriptions_Internalname, "TitleControlIdToReplace", Ddc_subscriptions_Titlecontrolidtoreplace);
         GXt_boolean1 = AV80IsAuthorized_AuditDate;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "auditview_Execute", out  GXt_boolean1) ;
         AV80IsAuthorized_AuditDate = GXt_boolean1;
         AssignAttri("", false, "AV80IsAuthorized_AuditDate", AV80IsAuthorized_AuditDate);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_AUDITDATE", GetSecureSignedToken( "", AV80IsAuthorized_AuditDate, context));
         AV65GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV66GAMErrors);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Ddo_grid_Gamoauthtoken = AV65GAMSession.gxTpr_Token;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GAMOAuthToken", Ddo_grid_Gamoauthtoken);
         Form.Caption = " Auditoria dos Dados";
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( AV14OrderedBy < 1 )
         {
            AV14OrderedBy = 1;
            AssignAttri("", false, "AV14OrderedBy", StringUtil.LTrimStr( (decimal)(AV14OrderedBy), 4, 0));
            AV15OrderedDsc = true;
            AssignAttri("", false, "AV15OrderedDsc", AV15OrderedDsc);
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S172 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = AV64DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2) ;
         AV64DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2;
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = bttBtneditcolumns_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "TitleControlIdToReplace", Ddo_gridcolumnsselector_Titlecontrolidtoreplace);
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E335O2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S182 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( AV43ManageFiltersExecutionStep == 1 )
         {
            AV43ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV43ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV43ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV43ManageFiltersExecutionStep == 2 )
         {
            AV43ManageFiltersExecutionStep = 0;
            AssignAttri("", false, "AV43ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV43ManageFiltersExecutionStep), 1, 0));
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( StringUtil.StrCmp(AV40Session.Get("core.AuditWWColumnsSelector"), "") != 0 )
         {
            AV36ColumnsSelectorXML = AV40Session.Get("core.AuditWWColumnsSelector");
            AV38ColumnsSelector.FromXml(AV36ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S202 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         edtAuditDateTime_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV38ColumnsSelector.gxTpr_Columns.Item(1)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtAuditDateTime_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtAuditDateTime_Visible), 5, 0), !bGXsfl_118_Refreshing);
         edtAuditDate_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV38ColumnsSelector.gxTpr_Columns.Item(2)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtAuditDate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtAuditDate_Visible), 5, 0), !bGXsfl_118_Refreshing);
         edtAuditTime_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV38ColumnsSelector.gxTpr_Columns.Item(3)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtAuditTime_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtAuditTime_Visible), 5, 0), !bGXsfl_118_Refreshing);
         edtAuditTableName_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV38ColumnsSelector.gxTpr_Columns.Item(4)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtAuditTableName_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtAuditTableName_Visible), 5, 0), !bGXsfl_118_Refreshing);
         edtAuditAction_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV38ColumnsSelector.gxTpr_Columns.Item(5)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtAuditAction_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtAuditAction_Visible), 5, 0), !bGXsfl_118_Refreshing);
         edtAuditShortDescription_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV38ColumnsSelector.gxTpr_Columns.Item(6)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtAuditShortDescription_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtAuditShortDescription_Visible), 5, 0), !bGXsfl_118_Refreshing);
         edtAuditDescription_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV38ColumnsSelector.gxTpr_Columns.Item(7)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtAuditDescription_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtAuditDescription_Visible), 5, 0), !bGXsfl_118_Refreshing);
         edtAuditGAMUserName_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV38ColumnsSelector.gxTpr_Columns.Item(8)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtAuditGAMUserName_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtAuditGAMUserName_Visible), 5, 0), !bGXsfl_118_Refreshing);
         AV68GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV68GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV68GridCurrentPage), 10, 0));
         AV69GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV69GridPageCount", StringUtil.LTrimStr( (decimal)(AV69GridPageCount), 10, 0));
         GXt_char3 = AV70GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV87Pgmname, out  GXt_char3) ;
         AV70GridAppliedFilters = GXt_char3;
         AssignAttri("", false, "AV70GridAppliedFilters", AV70GridAppliedFilters);
         AV88Core_auditwwds_1_filterfulltext = AV17FilterFullText;
         AV89Core_auditwwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV90Core_auditwwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV91Core_auditwwds_4_auditdate1 = AV20AuditDate1;
         AV92Core_auditwwds_5_auditdate_to1 = AV21AuditDate_To1;
         AV93Core_auditwwds_6_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV94Core_auditwwds_7_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV95Core_auditwwds_8_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV96Core_auditwwds_9_auditdate2 = AV25AuditDate2;
         AV97Core_auditwwds_10_auditdate_to2 = AV26AuditDate_To2;
         AV98Core_auditwwds_11_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV99Core_auditwwds_12_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV100Core_auditwwds_13_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV101Core_auditwwds_14_auditdate3 = AV30AuditDate3;
         AV102Core_auditwwds_15_auditdate_to3 = AV31AuditDate_To3;
         AV103Core_auditwwds_16_tfauditdatetime = AV81TFAuditDateTime;
         AV104Core_auditwwds_17_tfauditdatetime_to = AV82TFAuditDateTime_To;
         AV105Core_auditwwds_18_tfauditdate = AV44TFAuditDate;
         AV106Core_auditwwds_19_tfauditdate_to = AV45TFAuditDate_To;
         AV107Core_auditwwds_20_tfaudittime = AV49TFAuditTime;
         AV108Core_auditwwds_21_tfaudittime_to = AV50TFAuditTime_To;
         AV109Core_auditwwds_22_tfaudittablename = AV54TFAuditTableName;
         AV110Core_auditwwds_23_tfaudittablename_sel = AV55TFAuditTableName_Sel;
         AV111Core_auditwwds_24_tfauditaction = AV62TFAuditAction;
         AV112Core_auditwwds_25_tfauditaction_sel = AV63TFAuditAction_Sel;
         AV113Core_auditwwds_26_tfauditshortdescription = AV56TFAuditShortDescription;
         AV114Core_auditwwds_27_tfauditshortdescription_sel = AV57TFAuditShortDescription_Sel;
         AV115Core_auditwwds_28_tfauditdescription = AV58TFAuditDescription;
         AV116Core_auditwwds_29_tfauditdescription_sel = AV59TFAuditDescription_Sel;
         AV117Core_auditwwds_30_tfauditgamusername = AV60TFAuditGAMUserName;
         AV118Core_auditwwds_31_tfauditgamusername_sel = AV61TFAuditGAMUserName_Sel;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ColumnsSelector", AV38ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E125O2( )
      {
         /* Gridpaginationbar_Changepage Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gridpaginationbar_Selectedpage, "Previous") == 0 )
         {
            subgrid_previouspage( ) ;
         }
         else if ( StringUtil.StrCmp(Gridpaginationbar_Selectedpage, "Next") == 0 )
         {
            subgrid_nextpage( ) ;
         }
         else
         {
            AV67PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV67PageToGo) ;
         }
      }

      protected void E135O2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E195O2( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV14OrderedBy = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV14OrderedBy", StringUtil.LTrimStr( (decimal)(AV14OrderedBy), 4, 0));
            AV15OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri("", false, "AV15OrderedDsc", AV15OrderedDsc);
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S172 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            subgrid_firstpage( ) ;
         }
         else if ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#Filter#>") == 0 )
         {
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "AuditDateTime") == 0 )
            {
               AV81TFAuditDateTime = context.localUtil.CToT( Ddo_grid_Filteredtext_get, 2);
               AssignAttri("", false, "AV81TFAuditDateTime", context.localUtil.TToC( AV81TFAuditDateTime, 10, 12, 0, 3, "/", ":", " "));
               AV82TFAuditDateTime_To = context.localUtil.CToT( Ddo_grid_Filteredtextto_get, 2);
               AssignAttri("", false, "AV82TFAuditDateTime_To", context.localUtil.TToC( AV82TFAuditDateTime_To, 10, 12, 0, 3, "/", ":", " "));
               if ( ! (DateTime.MinValue==AV82TFAuditDateTime_To) )
               {
                  AV82TFAuditDateTime_To = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( AV82TFAuditDateTime_To)), (short)(DateTimeUtil.Month( AV82TFAuditDateTime_To)), (short)(DateTimeUtil.Day( AV82TFAuditDateTime_To)), 23, 59, 59);
                  AssignAttri("", false, "AV82TFAuditDateTime_To", context.localUtil.TToC( AV82TFAuditDateTime_To, 10, 12, 0, 3, "/", ":", " "));
               }
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "AuditDate") == 0 )
            {
               AV44TFAuditDate = context.localUtil.CToD( Ddo_grid_Filteredtext_get, 2);
               AssignAttri("", false, "AV44TFAuditDate", context.localUtil.Format(AV44TFAuditDate, "99/99/99"));
               AV45TFAuditDate_To = context.localUtil.CToD( Ddo_grid_Filteredtextto_get, 2);
               AssignAttri("", false, "AV45TFAuditDate_To", context.localUtil.Format(AV45TFAuditDate_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "AuditTime") == 0 )
            {
               AV49TFAuditTime = DateTimeUtil.ResetDate(context.localUtil.CToT( Ddo_grid_Filteredtext_get, 2));
               AssignAttri("", false, "AV49TFAuditTime", context.localUtil.TToC( AV49TFAuditTime, 0, 5, 0, 3, "/", ":", " "));
               AV50TFAuditTime_To = DateTimeUtil.ResetDate(context.localUtil.CToT( Ddo_grid_Filteredtextto_get, 2));
               AssignAttri("", false, "AV50TFAuditTime_To", context.localUtil.TToC( AV50TFAuditTime_To, 0, 5, 0, 3, "/", ":", " "));
               if ( ! (DateTime.MinValue==AV50TFAuditTime_To) )
               {
                  AV50TFAuditTime_To = DateTimeUtil.ResetDate(context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( AV50TFAuditTime_To)), (short)(DateTimeUtil.Month( AV50TFAuditTime_To)), (short)(DateTimeUtil.Day( AV50TFAuditTime_To)), 23, 59, 59));
                  AssignAttri("", false, "AV50TFAuditTime_To", context.localUtil.TToC( AV50TFAuditTime_To, 0, 5, 0, 3, "/", ":", " "));
               }
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "AuditTableName") == 0 )
            {
               AV54TFAuditTableName = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV54TFAuditTableName", AV54TFAuditTableName);
               AV55TFAuditTableName_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV55TFAuditTableName_Sel", AV55TFAuditTableName_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "AuditAction") == 0 )
            {
               AV62TFAuditAction = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV62TFAuditAction", AV62TFAuditAction);
               AV63TFAuditAction_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV63TFAuditAction_Sel", AV63TFAuditAction_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "AuditShortDescription") == 0 )
            {
               AV56TFAuditShortDescription = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV56TFAuditShortDescription", AV56TFAuditShortDescription);
               AV57TFAuditShortDescription_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV57TFAuditShortDescription_Sel", AV57TFAuditShortDescription_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "AuditDescription") == 0 )
            {
               AV58TFAuditDescription = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV58TFAuditDescription", AV58TFAuditDescription);
               AV59TFAuditDescription_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV59TFAuditDescription_Sel", AV59TFAuditDescription_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "AuditGAMUserName") == 0 )
            {
               AV60TFAuditGAMUserName = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV60TFAuditGAMUserName", AV60TFAuditGAMUserName);
               AV61TFAuditGAMUserName_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV61TFAuditGAMUserName_Sel", AV61TFAuditGAMUserName_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E345O2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV86DetailWebComponent = "<i class=\"fas fa-angle-right ArrowIcon\"></i>";
         AssignAttri("", false, edtavDetailwebcomponent_Internalname, AV86DetailWebComponent);
         if ( AV80IsAuthorized_AuditDate )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "core.auditview.aspx"+UrlEncode(A493AuditID.ToString()) + "," + UrlEncode(StringUtil.RTrim(""));
            edtAuditDate_Link = formatLink("core.auditview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         }
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 118;
         }
         sendrow_1182( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_118_Refreshing )
         {
            DoAjaxLoad(118, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E205O2( )
      {
         /* Ddo_gridcolumnsselector_Oncolumnschanged Routine */
         returnInSub = false;
         AV36ColumnsSelectorXML = Ddo_gridcolumnsselector_Columnsselectorvalues;
         AV38ColumnsSelector.FromJSonString(AV36ColumnsSelectorXML, null);
         new GeneXus.Programs.wwpbaseobjects.savecolumnsselectorstate(context ).execute(  "core.AuditWWColumnsSelector",  (String.IsNullOrEmpty(StringUtil.RTrim( AV36ColumnsSelectorXML)) ? "" : AV38ColumnsSelector.ToXml(false, true, "", ""))) ;
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ColumnsSelector", AV38ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E245O2( )
      {
         /* 'AddDynamicFilters1' Routine */
         returnInSub = false;
         AV22DynamicFiltersEnabled2 = true;
         AssignAttri("", false, "AV22DynamicFiltersEnabled2", AV22DynamicFiltersEnabled2);
         imgAdddynamicfilters1_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
         imgRemovedynamicfilters1_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
         /*  Sending Event outputs  */
      }

      protected void E215O2( )
      {
         /* 'RemoveDynamicFilters1' Routine */
         returnInSub = false;
         AV32DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV32DynamicFiltersRemoving", AV32DynamicFiltersRemoving);
         AV33DynamicFiltersIgnoreFirst = true;
         AssignAttri("", false, "AV33DynamicFiltersIgnoreFirst", AV33DynamicFiltersIgnoreFirst);
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S212 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'RESETDYNFILTERS' */
         S222 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S232 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV32DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV32DynamicFiltersRemoving", AV32DynamicFiltersRemoving);
         AV33DynamicFiltersIgnoreFirst = false;
         AssignAttri("", false, "AV33DynamicFiltersIgnoreFirst", AV33DynamicFiltersIgnoreFirst);
         gxgrGrid_refresh( subGrid_Rows, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV20AuditDate1, AV25AuditDate2, AV30AuditDate3, AV43ManageFiltersExecutionStep, AV38ColumnsSelector, AV87Pgmname, AV21AuditDate_To1, AV22DynamicFiltersEnabled2, AV26AuditDate_To2, AV27DynamicFiltersEnabled3, AV31AuditDate_To3, AV81TFAuditDateTime, AV82TFAuditDateTime_To, AV44TFAuditDate, AV45TFAuditDate_To, AV49TFAuditTime, AV50TFAuditTime_To, AV54TFAuditTableName, AV55TFAuditTableName_Sel, AV62TFAuditAction, AV63TFAuditAction_Sel, AV56TFAuditShortDescription, AV57TFAuditShortDescription_Sel, AV58TFAuditDescription, AV59TFAuditDescription_Sel, AV60TFAuditGAMUserName, AV61TFAuditGAMUserName_Sel, AV14OrderedBy, AV15OrderedDsc, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV80IsAuthorized_AuditDate, Gx_date) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV28DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ColumnsSelector", AV38ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
      }

      protected void E255O2( )
      {
         /* Dynamicfiltersselector1_Click Routine */
         returnInSub = false;
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      protected void E165O2( )
      {
         /* Auditdate_rangepicker1_Daterangechanged Routine */
         returnInSub = false;
         AssignAttri("", false, "AV20AuditDate1", context.localUtil.Format(AV20AuditDate1, "99/99/99"));
         AssignAttri("", false, "AV21AuditDate_To1", context.localUtil.Format(AV21AuditDate_To1, "99/99/99"));
         gxgrGrid_refresh( subGrid_Rows, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV20AuditDate1, AV25AuditDate2, AV30AuditDate3, AV43ManageFiltersExecutionStep, AV38ColumnsSelector, AV87Pgmname, AV21AuditDate_To1, AV22DynamicFiltersEnabled2, AV26AuditDate_To2, AV27DynamicFiltersEnabled3, AV31AuditDate_To3, AV81TFAuditDateTime, AV82TFAuditDateTime_To, AV44TFAuditDate, AV45TFAuditDate_To, AV49TFAuditTime, AV50TFAuditTime_To, AV54TFAuditTableName, AV55TFAuditTableName_Sel, AV62TFAuditAction, AV63TFAuditAction_Sel, AV56TFAuditShortDescription, AV57TFAuditShortDescription_Sel, AV58TFAuditDescription, AV59TFAuditDescription_Sel, AV60TFAuditGAMUserName, AV61TFAuditGAMUserName_Sel, AV14OrderedBy, AV15OrderedDsc, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV80IsAuthorized_AuditDate, Gx_date) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ColumnsSelector", AV38ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E265O2( )
      {
         /* Dynamicfiltersoperator1_Click Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "AUDITDATE") == 0 )
         {
            AV20AuditDate1 = DateTime.MinValue;
            AssignAttri("", false, "AV20AuditDate1", context.localUtil.Format(AV20AuditDate1, "99/99/99"));
            AV21AuditDate_To1 = DateTime.MinValue;
            AssignAttri("", false, "AV21AuditDate_To1", context.localUtil.Format(AV21AuditDate_To1, "99/99/99"));
            /* Execute user subroutine: 'UPDATEAUDITDATE1OPERATORVALUES' */
            S242 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            gxgrGrid_refresh( subGrid_Rows, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV20AuditDate1, AV25AuditDate2, AV30AuditDate3, AV43ManageFiltersExecutionStep, AV38ColumnsSelector, AV87Pgmname, AV21AuditDate_To1, AV22DynamicFiltersEnabled2, AV26AuditDate_To2, AV27DynamicFiltersEnabled3, AV31AuditDate_To3, AV81TFAuditDateTime, AV82TFAuditDateTime_To, AV44TFAuditDate, AV45TFAuditDate_To, AV49TFAuditTime, AV50TFAuditTime_To, AV54TFAuditTableName, AV55TFAuditTableName_Sel, AV62TFAuditAction, AV63TFAuditAction_Sel, AV56TFAuditShortDescription, AV57TFAuditShortDescription_Sel, AV58TFAuditDescription, AV59TFAuditDescription_Sel, AV60TFAuditGAMUserName, AV61TFAuditGAMUserName_Sel, AV14OrderedBy, AV15OrderedDsc, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV80IsAuthorized_AuditDate, Gx_date) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ColumnsSelector", AV38ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E275O2( )
      {
         /* 'AddDynamicFilters2' Routine */
         returnInSub = false;
         AV27DynamicFiltersEnabled3 = true;
         AssignAttri("", false, "AV27DynamicFiltersEnabled3", AV27DynamicFiltersEnabled3);
         imgAdddynamicfilters2_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         /*  Sending Event outputs  */
      }

      protected void E225O2( )
      {
         /* 'RemoveDynamicFilters2' Routine */
         returnInSub = false;
         AV32DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV32DynamicFiltersRemoving", AV32DynamicFiltersRemoving);
         AV22DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV22DynamicFiltersEnabled2", AV22DynamicFiltersEnabled2);
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S212 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'RESETDYNFILTERS' */
         S222 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S232 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV32DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV32DynamicFiltersRemoving", AV32DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV20AuditDate1, AV25AuditDate2, AV30AuditDate3, AV43ManageFiltersExecutionStep, AV38ColumnsSelector, AV87Pgmname, AV21AuditDate_To1, AV22DynamicFiltersEnabled2, AV26AuditDate_To2, AV27DynamicFiltersEnabled3, AV31AuditDate_To3, AV81TFAuditDateTime, AV82TFAuditDateTime_To, AV44TFAuditDate, AV45TFAuditDate_To, AV49TFAuditTime, AV50TFAuditTime_To, AV54TFAuditTableName, AV55TFAuditTableName_Sel, AV62TFAuditAction, AV63TFAuditAction_Sel, AV56TFAuditShortDescription, AV57TFAuditShortDescription_Sel, AV58TFAuditDescription, AV59TFAuditDescription_Sel, AV60TFAuditGAMUserName, AV61TFAuditGAMUserName_Sel, AV14OrderedBy, AV15OrderedDsc, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV80IsAuthorized_AuditDate, Gx_date) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV28DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ColumnsSelector", AV38ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
      }

      protected void E285O2( )
      {
         /* Dynamicfiltersselector2_Click Routine */
         returnInSub = false;
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      protected void E175O2( )
      {
         /* Auditdate_rangepicker2_Daterangechanged Routine */
         returnInSub = false;
         AssignAttri("", false, "AV25AuditDate2", context.localUtil.Format(AV25AuditDate2, "99/99/99"));
         AssignAttri("", false, "AV26AuditDate_To2", context.localUtil.Format(AV26AuditDate_To2, "99/99/99"));
         gxgrGrid_refresh( subGrid_Rows, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV20AuditDate1, AV25AuditDate2, AV30AuditDate3, AV43ManageFiltersExecutionStep, AV38ColumnsSelector, AV87Pgmname, AV21AuditDate_To1, AV22DynamicFiltersEnabled2, AV26AuditDate_To2, AV27DynamicFiltersEnabled3, AV31AuditDate_To3, AV81TFAuditDateTime, AV82TFAuditDateTime_To, AV44TFAuditDate, AV45TFAuditDate_To, AV49TFAuditTime, AV50TFAuditTime_To, AV54TFAuditTableName, AV55TFAuditTableName_Sel, AV62TFAuditAction, AV63TFAuditAction_Sel, AV56TFAuditShortDescription, AV57TFAuditShortDescription_Sel, AV58TFAuditDescription, AV59TFAuditDescription_Sel, AV60TFAuditGAMUserName, AV61TFAuditGAMUserName_Sel, AV14OrderedBy, AV15OrderedDsc, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV80IsAuthorized_AuditDate, Gx_date) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ColumnsSelector", AV38ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E295O2( )
      {
         /* Dynamicfiltersoperator2_Click Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "AUDITDATE") == 0 )
         {
            AV25AuditDate2 = DateTime.MinValue;
            AssignAttri("", false, "AV25AuditDate2", context.localUtil.Format(AV25AuditDate2, "99/99/99"));
            AV26AuditDate_To2 = DateTime.MinValue;
            AssignAttri("", false, "AV26AuditDate_To2", context.localUtil.Format(AV26AuditDate_To2, "99/99/99"));
            /* Execute user subroutine: 'UPDATEAUDITDATE2OPERATORVALUES' */
            S252 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            gxgrGrid_refresh( subGrid_Rows, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV20AuditDate1, AV25AuditDate2, AV30AuditDate3, AV43ManageFiltersExecutionStep, AV38ColumnsSelector, AV87Pgmname, AV21AuditDate_To1, AV22DynamicFiltersEnabled2, AV26AuditDate_To2, AV27DynamicFiltersEnabled3, AV31AuditDate_To3, AV81TFAuditDateTime, AV82TFAuditDateTime_To, AV44TFAuditDate, AV45TFAuditDate_To, AV49TFAuditTime, AV50TFAuditTime_To, AV54TFAuditTableName, AV55TFAuditTableName_Sel, AV62TFAuditAction, AV63TFAuditAction_Sel, AV56TFAuditShortDescription, AV57TFAuditShortDescription_Sel, AV58TFAuditDescription, AV59TFAuditDescription_Sel, AV60TFAuditGAMUserName, AV61TFAuditGAMUserName_Sel, AV14OrderedBy, AV15OrderedDsc, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV80IsAuthorized_AuditDate, Gx_date) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ColumnsSelector", AV38ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E235O2( )
      {
         /* 'RemoveDynamicFilters3' Routine */
         returnInSub = false;
         AV32DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV32DynamicFiltersRemoving", AV32DynamicFiltersRemoving);
         AV27DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV27DynamicFiltersEnabled3", AV27DynamicFiltersEnabled3);
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S212 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'RESETDYNFILTERS' */
         S222 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S232 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV32DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV32DynamicFiltersRemoving", AV32DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV20AuditDate1, AV25AuditDate2, AV30AuditDate3, AV43ManageFiltersExecutionStep, AV38ColumnsSelector, AV87Pgmname, AV21AuditDate_To1, AV22DynamicFiltersEnabled2, AV26AuditDate_To2, AV27DynamicFiltersEnabled3, AV31AuditDate_To3, AV81TFAuditDateTime, AV82TFAuditDateTime_To, AV44TFAuditDate, AV45TFAuditDate_To, AV49TFAuditTime, AV50TFAuditTime_To, AV54TFAuditTableName, AV55TFAuditTableName_Sel, AV62TFAuditAction, AV63TFAuditAction_Sel, AV56TFAuditShortDescription, AV57TFAuditShortDescription_Sel, AV58TFAuditDescription, AV59TFAuditDescription_Sel, AV60TFAuditGAMUserName, AV61TFAuditGAMUserName_Sel, AV14OrderedBy, AV15OrderedDsc, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV80IsAuthorized_AuditDate, Gx_date) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV28DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ColumnsSelector", AV38ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
      }

      protected void E305O2( )
      {
         /* Dynamicfiltersselector3_Click Routine */
         returnInSub = false;
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      protected void E185O2( )
      {
         /* Auditdate_rangepicker3_Daterangechanged Routine */
         returnInSub = false;
         AssignAttri("", false, "AV30AuditDate3", context.localUtil.Format(AV30AuditDate3, "99/99/99"));
         AssignAttri("", false, "AV31AuditDate_To3", context.localUtil.Format(AV31AuditDate_To3, "99/99/99"));
         gxgrGrid_refresh( subGrid_Rows, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV20AuditDate1, AV25AuditDate2, AV30AuditDate3, AV43ManageFiltersExecutionStep, AV38ColumnsSelector, AV87Pgmname, AV21AuditDate_To1, AV22DynamicFiltersEnabled2, AV26AuditDate_To2, AV27DynamicFiltersEnabled3, AV31AuditDate_To3, AV81TFAuditDateTime, AV82TFAuditDateTime_To, AV44TFAuditDate, AV45TFAuditDate_To, AV49TFAuditTime, AV50TFAuditTime_To, AV54TFAuditTableName, AV55TFAuditTableName_Sel, AV62TFAuditAction, AV63TFAuditAction_Sel, AV56TFAuditShortDescription, AV57TFAuditShortDescription_Sel, AV58TFAuditDescription, AV59TFAuditDescription_Sel, AV60TFAuditGAMUserName, AV61TFAuditGAMUserName_Sel, AV14OrderedBy, AV15OrderedDsc, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV80IsAuthorized_AuditDate, Gx_date) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ColumnsSelector", AV38ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E315O2( )
      {
         /* Dynamicfiltersoperator3_Click Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "AUDITDATE") == 0 )
         {
            AV30AuditDate3 = DateTime.MinValue;
            AssignAttri("", false, "AV30AuditDate3", context.localUtil.Format(AV30AuditDate3, "99/99/99"));
            AV31AuditDate_To3 = DateTime.MinValue;
            AssignAttri("", false, "AV31AuditDate_To3", context.localUtil.Format(AV31AuditDate_To3, "99/99/99"));
            /* Execute user subroutine: 'UPDATEAUDITDATE3OPERATORVALUES' */
            S262 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            gxgrGrid_refresh( subGrid_Rows, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV20AuditDate1, AV25AuditDate2, AV30AuditDate3, AV43ManageFiltersExecutionStep, AV38ColumnsSelector, AV87Pgmname, AV21AuditDate_To1, AV22DynamicFiltersEnabled2, AV26AuditDate_To2, AV27DynamicFiltersEnabled3, AV31AuditDate_To3, AV81TFAuditDateTime, AV82TFAuditDateTime_To, AV44TFAuditDate, AV45TFAuditDate_To, AV49TFAuditTime, AV50TFAuditTime_To, AV54TFAuditTableName, AV55TFAuditTableName_Sel, AV62TFAuditAction, AV63TFAuditAction_Sel, AV56TFAuditShortDescription, AV57TFAuditShortDescription_Sel, AV58TFAuditDescription, AV59TFAuditDescription_Sel, AV60TFAuditGAMUserName, AV61TFAuditGAMUserName_Sel, AV14OrderedBy, AV15OrderedDsc, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV80IsAuthorized_AuditDate, Gx_date) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ColumnsSelector", AV38ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E115O2( )
      {
         /* Ddo_managefilters_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Clean#>") == 0 )
         {
            /* Execute user subroutine: 'CLEANFILTERS' */
            S272 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            subgrid_firstpage( ) ;
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Save#>") == 0 )
         {
            /* Execute user subroutine: 'SAVEGRIDSTATE' */
            S192 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wwpbaseobjects.savefilteras.aspx"+UrlEncode(StringUtil.RTrim("core.AuditWWFilters")) + "," + UrlEncode(StringUtil.RTrim(AV87Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV43ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV43ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV43ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wwpbaseobjects.managefilters.aspx"+UrlEncode(StringUtil.RTrim("core.AuditWWFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV43ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV43ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV43ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char3 = AV42ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "core.AuditWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char3) ;
            AV42ManageFiltersXml = GXt_char3;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV42ManageFiltersXml)) )
            {
               GX_msglist.addItem("O filtro selecionado não existe mais.");
            }
            else
            {
               /* Execute user subroutine: 'CLEANFILTERS' */
               S272 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV87Pgmname+"GridState",  AV42ManageFiltersXml) ;
               AV11GridState.FromXml(AV42ManageFiltersXml, null, "", "");
               AV14OrderedBy = AV11GridState.gxTpr_Orderedby;
               AssignAttri("", false, "AV14OrderedBy", StringUtil.LTrimStr( (decimal)(AV14OrderedBy), 4, 0));
               AV15OrderedDsc = AV11GridState.gxTpr_Ordereddsc;
               AssignAttri("", false, "AV15OrderedDsc", AV15OrderedDsc);
               /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
               S172 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
               S282 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
               S232 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               subgrid_firstpage( ) ;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV28DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ColumnsSelector", AV38ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
      }

      protected void E145O2( )
      {
         /* Ddo_agexport_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_agexport_Activeeventkey, "Export") == 0 )
         {
            /* Execute user subroutine: 'DOEXPORT' */
            S292 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(Ddo_agexport_Activeeventkey, "ExportReport") == 0 )
         {
            /* Execute user subroutine: 'DOEXPORTREPORT' */
            S302 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV28DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
      }

      protected void E155O2( )
      {
         /* Ddc_subscriptions_Onloadcomponent Routine */
         returnInSub = false;
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wwpaux_wc = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wwpaux_wc_Component), StringUtil.Lower( "WWPBaseObjects.Subscriptions.WWP_SubscriptionsPanel")) != 0 )
         {
            WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", "wwpbaseobjects.subscriptions.wwp_subscriptionspanel", new Object[] {context} );
            WebComp_Wwpaux_wc.ComponentInit();
            WebComp_Wwpaux_wc.Name = "WWPBaseObjects.Subscriptions.WWP_SubscriptionsPanel";
            WebComp_Wwpaux_wc_Component = "WWPBaseObjects.Subscriptions.WWP_SubscriptionsPanel";
         }
         if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
         {
            WebComp_Wwpaux_wc.setjustcreated();
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"W0149",(string)"",(string)"Audit",(short)1,(string)"",(string)""});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0149"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void E355O2( )
      {
         /* Detailwebcomponent_Click Routine */
         returnInSub = false;
         /* Object Property */
         if ( true )
         {
            bDynCreated_Grid_dwc = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Grid_dwc_Component), StringUtil.Lower( "core.AuditGeneral")) != 0 )
         {
            WebComp_Grid_dwc = getWebComponent(GetType(), "GeneXus.Programs", "core.auditgeneral", new Object[] {context} );
            WebComp_Grid_dwc.ComponentInit();
            WebComp_Grid_dwc.Name = "core.AuditGeneral";
            WebComp_Grid_dwc_Component = "core.AuditGeneral";
         }
         if ( StringUtil.Len( WebComp_Grid_dwc_Component) != 0 )
         {
            WebComp_Grid_dwc.setjustcreated();
            WebComp_Grid_dwc.componentprepare(new Object[] {(string)"W0134",(string)"",(Guid)A493AuditID});
            WebComp_Grid_dwc.componentbind(new Object[] {(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Grid_dwc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0134"+"");
            WebComp_Grid_dwc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void S172( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV14OrderedBy), 4, 0))+":"+(AV15OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S202( )
      {
         /* 'INITIALIZECOLUMNSSELECTOR' Routine */
         returnInSub = false;
         AV38ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV38ColumnsSelector,  "AuditDateTime",  "",  "Data/Hora",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV38ColumnsSelector,  "AuditDate",  "",  "Data",  false,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV38ColumnsSelector,  "AuditTime",  "",  "Hora",  false,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV38ColumnsSelector,  "AuditTableName",  "",  "Tabela",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV38ColumnsSelector,  "AuditAction",  "",  "Ação",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV38ColumnsSelector,  "AuditShortDescription",  "",  "Descrição",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV38ColumnsSelector,  "AuditDescription",  "",  "Detalhes",  false,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV38ColumnsSelector,  "AuditGAMUserName",  "",  "Usuário",  true,  "") ;
         GXt_char3 = AV37UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "core.AuditWWColumnsSelector", out  GXt_char3) ;
         AV37UserCustomValue = GXt_char3;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV37UserCustomValue)) ) )
         {
            AV39ColumnsSelectorAux.FromXml(AV37UserCustomValue, null, "", "");
            new GeneXus.Programs.wwpbaseobjects.wwp_columnselector_updatecolumns(context ).execute( ref  AV39ColumnsSelectorAux, ref  AV38ColumnsSelector) ;
         }
      }

      protected void S182( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         if ( ! ( new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_hassubscriptionstodisplay(context).executeUdp(  "Audit",  1) ) )
         {
            bttBtnsubscriptions_Visible = 0;
            AssignProp("", false, bttBtnsubscriptions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnsubscriptions_Visible), 5, 0), true);
         }
      }

      protected void S122( )
      {
         /* 'ENABLEDYNAMICFILTERS1' Routine */
         returnInSub = false;
         tblTablemergeddynamicfiltersauditdate1_Visible = 0;
         AssignProp("", false, tblTablemergeddynamicfiltersauditdate1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblTablemergeddynamicfiltersauditdate1_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator1.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "AUDITDATE") == 0 )
         {
            tblTablemergeddynamicfiltersauditdate1_Visible = 1;
            AssignProp("", false, tblTablemergeddynamicfiltersauditdate1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblTablemergeddynamicfiltersauditdate1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
            /* Execute user subroutine: 'UPDATEAUDITDATE1OPERATORVALUES' */
            S242 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
      }

      protected void S242( )
      {
         /* 'UPDATEAUDITDATE1OPERATORVALUES' Routine */
         returnInSub = false;
         cellAuditdate_range_cell1_Class = "Invisible";
         AssignProp("", false, cellAuditdate_range_cell1_Internalname, "Class", cellAuditdate_range_cell1_Class, true);
         if ( AV19DynamicFiltersOperator1 == 0 )
         {
            cellAuditdate_range_cell1_Class = "";
            AssignProp("", false, cellAuditdate_range_cell1_Internalname, "Class", cellAuditdate_range_cell1_Class, true);
         }
         else if ( AV19DynamicFiltersOperator1 == 1 )
         {
            AV20AuditDate1 = Gx_date;
            AssignAttri("", false, "AV20AuditDate1", context.localUtil.Format(AV20AuditDate1, "99/99/99"));
         }
         else if ( AV19DynamicFiltersOperator1 == 2 )
         {
            AV20AuditDate1 = Gx_date;
            AssignAttri("", false, "AV20AuditDate1", context.localUtil.Format(AV20AuditDate1, "99/99/99"));
         }
         else if ( AV19DynamicFiltersOperator1 == 3 )
         {
            AV20AuditDate1 = Gx_date;
            AssignAttri("", false, "AV20AuditDate1", context.localUtil.Format(AV20AuditDate1, "99/99/99"));
         }
      }

      protected void S132( )
      {
         /* 'ENABLEDYNAMICFILTERS2' Routine */
         returnInSub = false;
         tblTablemergeddynamicfiltersauditdate2_Visible = 0;
         AssignProp("", false, tblTablemergeddynamicfiltersauditdate2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblTablemergeddynamicfiltersauditdate2_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator2.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "AUDITDATE") == 0 )
         {
            tblTablemergeddynamicfiltersauditdate2_Visible = 1;
            AssignProp("", false, tblTablemergeddynamicfiltersauditdate2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblTablemergeddynamicfiltersauditdate2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
            /* Execute user subroutine: 'UPDATEAUDITDATE2OPERATORVALUES' */
            S252 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
      }

      protected void S252( )
      {
         /* 'UPDATEAUDITDATE2OPERATORVALUES' Routine */
         returnInSub = false;
         cellAuditdate_range_cell2_Class = "Invisible";
         AssignProp("", false, cellAuditdate_range_cell2_Internalname, "Class", cellAuditdate_range_cell2_Class, true);
         if ( AV24DynamicFiltersOperator2 == 0 )
         {
            cellAuditdate_range_cell2_Class = "";
            AssignProp("", false, cellAuditdate_range_cell2_Internalname, "Class", cellAuditdate_range_cell2_Class, true);
         }
         else if ( AV24DynamicFiltersOperator2 == 1 )
         {
            AV25AuditDate2 = Gx_date;
            AssignAttri("", false, "AV25AuditDate2", context.localUtil.Format(AV25AuditDate2, "99/99/99"));
         }
         else if ( AV24DynamicFiltersOperator2 == 2 )
         {
            AV25AuditDate2 = Gx_date;
            AssignAttri("", false, "AV25AuditDate2", context.localUtil.Format(AV25AuditDate2, "99/99/99"));
         }
         else if ( AV24DynamicFiltersOperator2 == 3 )
         {
            AV25AuditDate2 = Gx_date;
            AssignAttri("", false, "AV25AuditDate2", context.localUtil.Format(AV25AuditDate2, "99/99/99"));
         }
      }

      protected void S142( )
      {
         /* 'ENABLEDYNAMICFILTERS3' Routine */
         returnInSub = false;
         tblTablemergeddynamicfiltersauditdate3_Visible = 0;
         AssignProp("", false, tblTablemergeddynamicfiltersauditdate3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblTablemergeddynamicfiltersauditdate3_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator3.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "AUDITDATE") == 0 )
         {
            tblTablemergeddynamicfiltersauditdate3_Visible = 1;
            AssignProp("", false, tblTablemergeddynamicfiltersauditdate3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblTablemergeddynamicfiltersauditdate3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
            /* Execute user subroutine: 'UPDATEAUDITDATE3OPERATORVALUES' */
            S262 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
      }

      protected void S262( )
      {
         /* 'UPDATEAUDITDATE3OPERATORVALUES' Routine */
         returnInSub = false;
         cellAuditdate_range_cell3_Class = "Invisible";
         AssignProp("", false, cellAuditdate_range_cell3_Internalname, "Class", cellAuditdate_range_cell3_Class, true);
         if ( AV29DynamicFiltersOperator3 == 0 )
         {
            cellAuditdate_range_cell3_Class = "";
            AssignProp("", false, cellAuditdate_range_cell3_Internalname, "Class", cellAuditdate_range_cell3_Class, true);
         }
         else if ( AV29DynamicFiltersOperator3 == 1 )
         {
            AV30AuditDate3 = Gx_date;
            AssignAttri("", false, "AV30AuditDate3", context.localUtil.Format(AV30AuditDate3, "99/99/99"));
         }
         else if ( AV29DynamicFiltersOperator3 == 2 )
         {
            AV30AuditDate3 = Gx_date;
            AssignAttri("", false, "AV30AuditDate3", context.localUtil.Format(AV30AuditDate3, "99/99/99"));
         }
         else if ( AV29DynamicFiltersOperator3 == 3 )
         {
            AV30AuditDate3 = Gx_date;
            AssignAttri("", false, "AV30AuditDate3", context.localUtil.Format(AV30AuditDate3, "99/99/99"));
         }
      }

      protected void S222( )
      {
         /* 'RESETDYNFILTERS' Routine */
         returnInSub = false;
         AV22DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV22DynamicFiltersEnabled2", AV22DynamicFiltersEnabled2);
         AV23DynamicFiltersSelector2 = "AUDITDATE";
         AssignAttri("", false, "AV23DynamicFiltersSelector2", AV23DynamicFiltersSelector2);
         AV24DynamicFiltersOperator2 = 0;
         AssignAttri("", false, "AV24DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         AV25AuditDate2 = DateTime.MinValue;
         AssignAttri("", false, "AV25AuditDate2", context.localUtil.Format(AV25AuditDate2, "99/99/99"));
         AV26AuditDate_To2 = DateTime.MinValue;
         AssignAttri("", false, "AV26AuditDate_To2", context.localUtil.Format(AV26AuditDate_To2, "99/99/99"));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV27DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV27DynamicFiltersEnabled3", AV27DynamicFiltersEnabled3);
         AV28DynamicFiltersSelector3 = "AUDITDATE";
         AssignAttri("", false, "AV28DynamicFiltersSelector3", AV28DynamicFiltersSelector3);
         AV29DynamicFiltersOperator3 = 0;
         AssignAttri("", false, "AV29DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         AV30AuditDate3 = DateTime.MinValue;
         AssignAttri("", false, "AV30AuditDate3", context.localUtil.Format(AV30AuditDate3, "99/99/99"));
         AV31AuditDate_To3 = DateTime.MinValue;
         AssignAttri("", false, "AV31AuditDate_To3", context.localUtil.Format(AV31AuditDate_To3, "99/99/99"));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S112( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = AV41ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "core.AuditWWFilters",  "WWPDynFilterHideAll_AL('%1', 3, 0)",  divTabledynamicfilters_Internalname,  true, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4) ;
         AV41ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4;
      }

      protected void S272( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV17FilterFullText = "";
         AssignAttri("", false, "AV17FilterFullText", AV17FilterFullText);
         AV81TFAuditDateTime = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "AV81TFAuditDateTime", context.localUtil.TToC( AV81TFAuditDateTime, 10, 12, 0, 3, "/", ":", " "));
         AV82TFAuditDateTime_To = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "AV82TFAuditDateTime_To", context.localUtil.TToC( AV82TFAuditDateTime_To, 10, 12, 0, 3, "/", ":", " "));
         AV44TFAuditDate = DateTime.MinValue;
         AssignAttri("", false, "AV44TFAuditDate", context.localUtil.Format(AV44TFAuditDate, "99/99/99"));
         AV45TFAuditDate_To = DateTime.MinValue;
         AssignAttri("", false, "AV45TFAuditDate_To", context.localUtil.Format(AV45TFAuditDate_To, "99/99/99"));
         AV49TFAuditTime = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "AV49TFAuditTime", context.localUtil.TToC( AV49TFAuditTime, 0, 5, 0, 3, "/", ":", " "));
         AV50TFAuditTime_To = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "AV50TFAuditTime_To", context.localUtil.TToC( AV50TFAuditTime_To, 0, 5, 0, 3, "/", ":", " "));
         AV54TFAuditTableName = "";
         AssignAttri("", false, "AV54TFAuditTableName", AV54TFAuditTableName);
         AV55TFAuditTableName_Sel = "";
         AssignAttri("", false, "AV55TFAuditTableName_Sel", AV55TFAuditTableName_Sel);
         AV62TFAuditAction = "";
         AssignAttri("", false, "AV62TFAuditAction", AV62TFAuditAction);
         AV63TFAuditAction_Sel = "";
         AssignAttri("", false, "AV63TFAuditAction_Sel", AV63TFAuditAction_Sel);
         AV56TFAuditShortDescription = "";
         AssignAttri("", false, "AV56TFAuditShortDescription", AV56TFAuditShortDescription);
         AV57TFAuditShortDescription_Sel = "";
         AssignAttri("", false, "AV57TFAuditShortDescription_Sel", AV57TFAuditShortDescription_Sel);
         AV58TFAuditDescription = "";
         AssignAttri("", false, "AV58TFAuditDescription", AV58TFAuditDescription);
         AV59TFAuditDescription_Sel = "";
         AssignAttri("", false, "AV59TFAuditDescription_Sel", AV59TFAuditDescription_Sel);
         AV60TFAuditGAMUserName = "";
         AssignAttri("", false, "AV60TFAuditGAMUserName", AV60TFAuditGAMUserName);
         AV61TFAuditGAMUserName_Sel = "";
         AssignAttri("", false, "AV61TFAuditGAMUserName_Sel", AV61TFAuditGAMUserName_Sel);
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
         AV18DynamicFiltersSelector1 = "AUDITDATE";
         AssignAttri("", false, "AV18DynamicFiltersSelector1", AV18DynamicFiltersSelector1);
         AV19DynamicFiltersOperator1 = 0;
         AssignAttri("", false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AV20AuditDate1 = DateTime.MinValue;
         AssignAttri("", false, "AV20AuditDate1", context.localUtil.Format(AV20AuditDate1, "99/99/99"));
         AV21AuditDate_To1 = DateTime.MinValue;
         AssignAttri("", false, "AV21AuditDate_To1", context.localUtil.Format(AV21AuditDate_To1, "99/99/99"));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'RESETDYNFILTERS' */
         S222 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV11GridState.gxTpr_Dynamicfilters.Clear();
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S232 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S162( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV40Session.Get(AV87Pgmname+"GridState"), "") == 0 )
         {
            AV11GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV87Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV11GridState.FromXml(AV40Session.Get(AV87Pgmname+"GridState"), null, "", "");
         }
         AV14OrderedBy = AV11GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV14OrderedBy", StringUtil.LTrimStr( (decimal)(AV14OrderedBy), 4, 0));
         AV15OrderedDsc = AV11GridState.gxTpr_Ordereddsc;
         AssignAttri("", false, "AV15OrderedDsc", AV15OrderedDsc);
         /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
         S172 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
         S282 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S232 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV11GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV11GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV11GridState.gxTpr_Currentpage) ;
      }

      protected void S282( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV120GXV1 = 1;
         while ( AV120GXV1 <= AV11GridState.gxTpr_Filtervalues.Count )
         {
            AV12GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV11GridState.gxTpr_Filtervalues.Item(AV120GXV1));
            if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV17FilterFullText = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV17FilterFullText", AV17FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFAUDITDATETIME") == 0 )
            {
               AV81TFAuditDateTime = context.localUtil.CToT( AV12GridStateFilterValue.gxTpr_Value, 2);
               AssignAttri("", false, "AV81TFAuditDateTime", context.localUtil.TToC( AV81TFAuditDateTime, 10, 12, 0, 3, "/", ":", " "));
               AV82TFAuditDateTime_To = context.localUtil.CToT( AV12GridStateFilterValue.gxTpr_Valueto, 2);
               AssignAttri("", false, "AV82TFAuditDateTime_To", context.localUtil.TToC( AV82TFAuditDateTime_To, 10, 12, 0, 3, "/", ":", " "));
               AV83DDO_AuditDateTimeAuxDate = DateTimeUtil.ResetTime(AV81TFAuditDateTime);
               AssignAttri("", false, "AV83DDO_AuditDateTimeAuxDate", context.localUtil.Format(AV83DDO_AuditDateTimeAuxDate, "99/99/9999"));
               AV84DDO_AuditDateTimeAuxDateTo = DateTimeUtil.ResetTime(AV82TFAuditDateTime_To);
               AssignAttri("", false, "AV84DDO_AuditDateTimeAuxDateTo", context.localUtil.Format(AV84DDO_AuditDateTimeAuxDateTo, "99/99/9999"));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFAUDITDATE") == 0 )
            {
               AV44TFAuditDate = context.localUtil.CToD( AV12GridStateFilterValue.gxTpr_Value, 2);
               AssignAttri("", false, "AV44TFAuditDate", context.localUtil.Format(AV44TFAuditDate, "99/99/99"));
               AV45TFAuditDate_To = context.localUtil.CToD( AV12GridStateFilterValue.gxTpr_Valueto, 2);
               AssignAttri("", false, "AV45TFAuditDate_To", context.localUtil.Format(AV45TFAuditDate_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFAUDITTIME") == 0 )
            {
               AV49TFAuditTime = DateTimeUtil.ResetDate(context.localUtil.CToT( AV12GridStateFilterValue.gxTpr_Value, 2));
               AssignAttri("", false, "AV49TFAuditTime", context.localUtil.TToC( AV49TFAuditTime, 0, 5, 0, 3, "/", ":", " "));
               AV50TFAuditTime_To = DateTimeUtil.ResetDate(context.localUtil.CToT( AV12GridStateFilterValue.gxTpr_Valueto, 2));
               AssignAttri("", false, "AV50TFAuditTime_To", context.localUtil.TToC( AV50TFAuditTime_To, 0, 5, 0, 3, "/", ":", " "));
               AV51DDO_AuditTimeAuxDate = DateTimeUtil.ResetTime(AV49TFAuditTime);
               AssignAttri("", false, "AV51DDO_AuditTimeAuxDate", context.localUtil.Format(AV51DDO_AuditTimeAuxDate, "99/99/99"));
               AV52DDO_AuditTimeAuxDateTo = DateTimeUtil.ResetTime(AV50TFAuditTime_To);
               AssignAttri("", false, "AV52DDO_AuditTimeAuxDateTo", context.localUtil.Format(AV52DDO_AuditTimeAuxDateTo, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFAUDITTABLENAME") == 0 )
            {
               AV54TFAuditTableName = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV54TFAuditTableName", AV54TFAuditTableName);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFAUDITTABLENAME_SEL") == 0 )
            {
               AV55TFAuditTableName_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV55TFAuditTableName_Sel", AV55TFAuditTableName_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFAUDITACTION") == 0 )
            {
               AV62TFAuditAction = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV62TFAuditAction", AV62TFAuditAction);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFAUDITACTION_SEL") == 0 )
            {
               AV63TFAuditAction_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV63TFAuditAction_Sel", AV63TFAuditAction_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFAUDITSHORTDESCRIPTION") == 0 )
            {
               AV56TFAuditShortDescription = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV56TFAuditShortDescription", AV56TFAuditShortDescription);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFAUDITSHORTDESCRIPTION_SEL") == 0 )
            {
               AV57TFAuditShortDescription_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV57TFAuditShortDescription_Sel", AV57TFAuditShortDescription_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFAUDITDESCRIPTION") == 0 )
            {
               AV58TFAuditDescription = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV58TFAuditDescription", AV58TFAuditDescription);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFAUDITDESCRIPTION_SEL") == 0 )
            {
               AV59TFAuditDescription_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV59TFAuditDescription_Sel", AV59TFAuditDescription_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFAUDITGAMUSERNAME") == 0 )
            {
               AV60TFAuditGAMUserName = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV60TFAuditGAMUserName", AV60TFAuditGAMUserName);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFAUDITGAMUSERNAME_SEL") == 0 )
            {
               AV61TFAuditGAMUserName_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV61TFAuditGAMUserName_Sel", AV61TFAuditGAMUserName_Sel);
            }
            AV120GXV1 = (int)(AV120GXV1+1);
         }
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV55TFAuditTableName_Sel)),  AV55TFAuditTableName_Sel, out  GXt_char3) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV63TFAuditAction_Sel)),  AV63TFAuditAction_Sel, out  GXt_char5) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV57TFAuditShortDescription_Sel)),  AV57TFAuditShortDescription_Sel, out  GXt_char6) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV59TFAuditDescription_Sel)),  AV59TFAuditDescription_Sel, out  GXt_char7) ;
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV61TFAuditGAMUserName_Sel)),  AV61TFAuditGAMUserName_Sel, out  GXt_char8) ;
         Ddo_grid_Selectedvalue_set = "|||"+GXt_char3+"|"+GXt_char5+"|"+GXt_char6+"|"+GXt_char7+"|"+GXt_char8;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV54TFAuditTableName)),  AV54TFAuditTableName, out  GXt_char8) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV62TFAuditAction)),  AV62TFAuditAction, out  GXt_char7) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV56TFAuditShortDescription)),  AV56TFAuditShortDescription, out  GXt_char6) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV58TFAuditDescription)),  AV58TFAuditDescription, out  GXt_char5) ;
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV60TFAuditGAMUserName)),  AV60TFAuditGAMUserName, out  GXt_char3) ;
         Ddo_grid_Filteredtext_set = ((DateTime.MinValue==AV81TFAuditDateTime) ? "" : context.localUtil.DToC( AV83DDO_AuditDateTimeAuxDate, 2, "/"))+"|"+((DateTime.MinValue==AV44TFAuditDate) ? "" : context.localUtil.DToC( AV44TFAuditDate, 2, "/"))+"|"+((DateTime.MinValue==AV49TFAuditTime) ? "" : context.localUtil.DToC( AV51DDO_AuditTimeAuxDate, 2, "/"))+"|"+GXt_char8+"|"+GXt_char7+"|"+GXt_char6+"|"+GXt_char5+"|"+GXt_char3;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = ((DateTime.MinValue==AV82TFAuditDateTime_To) ? "" : context.localUtil.DToC( AV84DDO_AuditDateTimeAuxDateTo, 2, "/"))+"|"+((DateTime.MinValue==AV45TFAuditDate_To) ? "" : context.localUtil.DToC( AV45TFAuditDate_To, 2, "/"))+"|"+((DateTime.MinValue==AV50TFAuditTime_To) ? "" : context.localUtil.DToC( AV52DDO_AuditTimeAuxDateTo, 2, "/"))+"|||||";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S232( )
      {
         /* 'LOADDYNFILTERSSTATE' Routine */
         returnInSub = false;
         imgAdddynamicfilters1_Visible = 1;
         AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
         imgRemovedynamicfilters1_Visible = 0;
         AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
         imgAdddynamicfilters2_Visible = 1;
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 0;
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         if ( AV11GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV13GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV11GridState.gxTpr_Dynamicfilters.Item(1));
            AV18DynamicFiltersSelector1 = AV13GridStateDynamicFilter.gxTpr_Selected;
            AssignAttri("", false, "AV18DynamicFiltersSelector1", AV18DynamicFiltersSelector1);
            if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "AUDITDATE") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV13GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
               AV20AuditDate1 = context.localUtil.CToD( AV13GridStateDynamicFilter.gxTpr_Value, 2);
               AssignAttri("", false, "AV20AuditDate1", context.localUtil.Format(AV20AuditDate1, "99/99/99"));
               AV21AuditDate_To1 = context.localUtil.CToD( AV13GridStateDynamicFilter.gxTpr_Valueto, 2);
               AssignAttri("", false, "AV21AuditDate_To1", context.localUtil.Format(AV21AuditDate_To1, "99/99/99"));
            }
            /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
            S122 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            if ( AV11GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               lblJsdynamicfilters_Caption = "<script type=\"text/javascript\">$(document).ready(function() {";
               AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
               lblJsdynamicfilters_Caption = lblJsdynamicfilters_Caption+StringUtil.Format( "WWPDynFilterShow_AL('%1', 2, 0);", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
               AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
               imgAdddynamicfilters1_Visible = 0;
               AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
               imgRemovedynamicfilters1_Visible = 1;
               AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
               AV22DynamicFiltersEnabled2 = true;
               AssignAttri("", false, "AV22DynamicFiltersEnabled2", AV22DynamicFiltersEnabled2);
               AV13GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV11GridState.gxTpr_Dynamicfilters.Item(2));
               AV23DynamicFiltersSelector2 = AV13GridStateDynamicFilter.gxTpr_Selected;
               AssignAttri("", false, "AV23DynamicFiltersSelector2", AV23DynamicFiltersSelector2);
               if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "AUDITDATE") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV13GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV24DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
                  AV25AuditDate2 = context.localUtil.CToD( AV13GridStateDynamicFilter.gxTpr_Value, 2);
                  AssignAttri("", false, "AV25AuditDate2", context.localUtil.Format(AV25AuditDate2, "99/99/99"));
                  AV26AuditDate_To2 = context.localUtil.CToD( AV13GridStateDynamicFilter.gxTpr_Valueto, 2);
                  AssignAttri("", false, "AV26AuditDate_To2", context.localUtil.Format(AV26AuditDate_To2, "99/99/99"));
               }
               /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
               S132 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               if ( AV11GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  lblJsdynamicfilters_Caption = lblJsdynamicfilters_Caption+StringUtil.Format( "WWPDynFilterShow_AL('%1', 3, 0);", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
                  AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
                  imgAdddynamicfilters2_Visible = 0;
                  AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
                  imgRemovedynamicfilters2_Visible = 1;
                  AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
                  AV27DynamicFiltersEnabled3 = true;
                  AssignAttri("", false, "AV27DynamicFiltersEnabled3", AV27DynamicFiltersEnabled3);
                  AV13GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV11GridState.gxTpr_Dynamicfilters.Item(3));
                  AV28DynamicFiltersSelector3 = AV13GridStateDynamicFilter.gxTpr_Selected;
                  AssignAttri("", false, "AV28DynamicFiltersSelector3", AV28DynamicFiltersSelector3);
                  if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "AUDITDATE") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV13GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV29DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
                     AV30AuditDate3 = context.localUtil.CToD( AV13GridStateDynamicFilter.gxTpr_Value, 2);
                     AssignAttri("", false, "AV30AuditDate3", context.localUtil.Format(AV30AuditDate3, "99/99/99"));
                     AV31AuditDate_To3 = context.localUtil.CToD( AV13GridStateDynamicFilter.gxTpr_Valueto, 2);
                     AssignAttri("", false, "AV31AuditDate_To3", context.localUtil.Format(AV31AuditDate_To3, "99/99/99"));
                  }
                  /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
                  S142 ();
                  if ( returnInSub )
                  {
                     returnInSub = true;
                     if (true) return;
                  }
               }
               lblJsdynamicfilters_Caption = lblJsdynamicfilters_Caption+"});</script>";
               AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
            }
         }
         if ( AV32DynamicFiltersRemoving )
         {
            lblJsdynamicfilters_Caption = "";
            AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         }
      }

      protected void S192( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV11GridState.FromXml(AV40Session.Get(AV87Pgmname+"GridState"), null, "", "");
         AV11GridState.gxTpr_Orderedby = AV14OrderedBy;
         AV11GridState.gxTpr_Ordereddsc = AV15OrderedDsc;
         AV11GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "FILTERFULLTEXT",  "Filtro principal",  !String.IsNullOrEmpty(StringUtil.RTrim( AV17FilterFullText)),  0,  AV17FilterFullText,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFAUDITDATETIME",  "Data/Hora",  !((DateTime.MinValue==AV81TFAuditDateTime)&&(DateTime.MinValue==AV82TFAuditDateTime_To)),  0,  StringUtil.Trim( context.localUtil.TToC( AV81TFAuditDateTime, 10, 12, 0, 3, "/", ":", " ")),  StringUtil.Trim( context.localUtil.TToC( AV82TFAuditDateTime_To, 10, 12, 0, 3, "/", ":", " "))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFAUDITDATE",  "Data",  !((DateTime.MinValue==AV44TFAuditDate)&&(DateTime.MinValue==AV45TFAuditDate_To)),  0,  StringUtil.Trim( context.localUtil.DToC( AV44TFAuditDate, 2, "/")),  StringUtil.Trim( context.localUtil.DToC( AV45TFAuditDate_To, 2, "/"))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFAUDITTIME",  "Hora",  !((DateTime.MinValue==AV49TFAuditTime)&&(DateTime.MinValue==AV50TFAuditTime_To)),  0,  StringUtil.Trim( context.localUtil.TToC( AV49TFAuditTime, 0, 5, 0, 3, "/", ":", " ")),  StringUtil.Trim( context.localUtil.TToC( AV50TFAuditTime_To, 0, 5, 0, 3, "/", ":", " "))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFAUDITTABLENAME",  "Tabela",  !String.IsNullOrEmpty(StringUtil.RTrim( AV54TFAuditTableName)),  0,  AV54TFAuditTableName,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV55TFAuditTableName_Sel)),  AV55TFAuditTableName_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFAUDITACTION",  "Ação",  !String.IsNullOrEmpty(StringUtil.RTrim( AV62TFAuditAction)),  0,  AV62TFAuditAction,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV63TFAuditAction_Sel)),  AV63TFAuditAction_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFAUDITSHORTDESCRIPTION",  "Descrição",  !String.IsNullOrEmpty(StringUtil.RTrim( AV56TFAuditShortDescription)),  0,  AV56TFAuditShortDescription,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV57TFAuditShortDescription_Sel)),  AV57TFAuditShortDescription_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFAUDITDESCRIPTION",  "Detalhes",  !String.IsNullOrEmpty(StringUtil.RTrim( AV58TFAuditDescription)),  0,  AV58TFAuditDescription,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV59TFAuditDescription_Sel)),  AV59TFAuditDescription_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFAUDITGAMUSERNAME",  "Usuário",  !String.IsNullOrEmpty(StringUtil.RTrim( AV60TFAuditGAMUserName)),  0,  AV60TFAuditGAMUserName,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV61TFAuditGAMUserName_Sel)),  AV61TFAuditGAMUserName_Sel,  "") ;
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S212 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV11GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV11GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV87Pgmname+"GridState",  AV11GridState.ToXml(false, true, "", "")) ;
      }

      protected void S212( )
      {
         /* 'SAVEDYNFILTERSSTATE' Routine */
         returnInSub = false;
         AV11GridState.gxTpr_Dynamicfilters.Clear();
         if ( ! AV33DynamicFiltersIgnoreFirst )
         {
            AV13GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV13GridStateDynamicFilter.gxTpr_Selected = AV18DynamicFiltersSelector1;
            if ( ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "AUDITDATE") == 0 ) && ! ( (DateTime.MinValue==AV20AuditDate1) && (DateTime.MinValue==AV21AuditDate_To1) ) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = "Data";
               AV13GridStateDynamicFilter.gxTpr_Value = context.localUtil.DToC( AV20AuditDate1, 2, "/");
               AV13GridStateDynamicFilter.gxTpr_Operator = AV19DynamicFiltersOperator1;
               AV13GridStateDynamicFilter.gxTpr_Valueto = context.localUtil.DToC( AV21AuditDate_To1, 2, "/");
            }
            if ( AV32DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV13GridStateDynamicFilter.gxTpr_Value)) || ! String.IsNullOrEmpty(StringUtil.RTrim( AV13GridStateDynamicFilter.gxTpr_Valueto)) )
            {
               AV11GridState.gxTpr_Dynamicfilters.Add(AV13GridStateDynamicFilter, 0);
            }
         }
         if ( AV22DynamicFiltersEnabled2 )
         {
            AV13GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV13GridStateDynamicFilter.gxTpr_Selected = AV23DynamicFiltersSelector2;
            if ( ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "AUDITDATE") == 0 ) && ! ( (DateTime.MinValue==AV25AuditDate2) && (DateTime.MinValue==AV26AuditDate_To2) ) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = "Data";
               AV13GridStateDynamicFilter.gxTpr_Value = context.localUtil.DToC( AV25AuditDate2, 2, "/");
               AV13GridStateDynamicFilter.gxTpr_Operator = AV24DynamicFiltersOperator2;
               AV13GridStateDynamicFilter.gxTpr_Valueto = context.localUtil.DToC( AV26AuditDate_To2, 2, "/");
            }
            if ( AV32DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV13GridStateDynamicFilter.gxTpr_Value)) || ! String.IsNullOrEmpty(StringUtil.RTrim( AV13GridStateDynamicFilter.gxTpr_Valueto)) )
            {
               AV11GridState.gxTpr_Dynamicfilters.Add(AV13GridStateDynamicFilter, 0);
            }
         }
         if ( AV27DynamicFiltersEnabled3 )
         {
            AV13GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV13GridStateDynamicFilter.gxTpr_Selected = AV28DynamicFiltersSelector3;
            if ( ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "AUDITDATE") == 0 ) && ! ( (DateTime.MinValue==AV30AuditDate3) && (DateTime.MinValue==AV31AuditDate_To3) ) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = "Data";
               AV13GridStateDynamicFilter.gxTpr_Value = context.localUtil.DToC( AV30AuditDate3, 2, "/");
               AV13GridStateDynamicFilter.gxTpr_Operator = AV29DynamicFiltersOperator3;
               AV13GridStateDynamicFilter.gxTpr_Valueto = context.localUtil.DToC( AV31AuditDate_To3, 2, "/");
            }
            if ( AV32DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV13GridStateDynamicFilter.gxTpr_Value)) || ! String.IsNullOrEmpty(StringUtil.RTrim( AV13GridStateDynamicFilter.gxTpr_Valueto)) )
            {
               AV11GridState.gxTpr_Dynamicfilters.Add(AV13GridStateDynamicFilter, 0);
            }
         }
      }

      protected void S152( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV9TrnContext.gxTpr_Callerobject = AV87Pgmname;
         AV9TrnContext.gxTpr_Callerondelete = true;
         AV9TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString;
         AV9TrnContext.gxTpr_Transactionname = "core.Audit";
         AV40Session.Set("TrnContext", AV9TrnContext.ToXml(false, true, "", ""));
      }

      protected void S292( )
      {
         /* 'DOEXPORT' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         new GeneXus.Programs.core.auditwwexport(context ).execute( out  AV34ExcelFilename, out  AV35ErrorMessage) ;
         if ( StringUtil.StrCmp(AV34ExcelFilename, "") != 0 )
         {
            CallWebObject(formatLink(AV34ExcelFilename) );
            context.wjLocDisableFrm = 0;
         }
         else
         {
            GX_msglist.addItem(AV35ErrorMessage);
         }
      }

      protected void S302( )
      {
         /* 'DOEXPORTREPORT' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         Innewwindow1_Target = formatLink("core.auditwwexportreport.aspx") ;
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Target", Innewwindow1_Target);
         Innewwindow1_Height = "600";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Height", Innewwindow1_Height);
         Innewwindow1_Width = "800";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Width", Innewwindow1_Width);
         this.executeUsercontrolMethod("", false, "INNEWWINDOW1Container", "OpenWindow", "", new Object[] {});
      }

      protected void wb_table4_97_5O2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergeddynamicfilters3_Internalname, tblTablemergeddynamicfilters3_Internalname, "", "Table", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersoperator3_Internalname, "Dynamic Filters Operator3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 101,'',false,'" + sGXsfl_118_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator3, cmbavDynamicfiltersoperator3_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0)), 1, cmbavDynamicfiltersoperator3_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSOPERATOR3.CLICK."+"'", "int", "", cmbavDynamicfiltersoperator3.Visible, cmbavDynamicfiltersoperator3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,101);\"", "", true, 0, "HLP_core\\AuditWW.htm");
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", (string)(cmbavDynamicfiltersoperator3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_auditdate3_cell_Internalname+"\"  class=''>") ;
            wb_table5_103_5O2( true) ;
         }
         else
         {
            wb_table5_103_5O2( false) ;
         }
         return  ;
      }

      protected void wb_table5_103_5O2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter3_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 109,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters3_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters3_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters3_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS3\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_core\\AuditWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_97_5O2e( true) ;
         }
         else
         {
            wb_table4_97_5O2e( false) ;
         }
      }

      protected void wb_table5_103_5O2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            if ( tblTablemergeddynamicfiltersauditdate3_Visible == 0 )
            {
               sStyleString += "display:none;";
            }
            GxWebStd.gx_table_start( context, tblTablemergeddynamicfiltersauditdate3_Internalname, tblTablemergeddynamicfiltersauditdate3_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td id=\""+cellAuditdate_range_cell3_Internalname+"\"  class='"+cellAuditdate_range_cell3_Class+"'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavAuditdate_rangetext3_Internalname, "Audit Date_Range Text3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 107,'',false,'" + sGXsfl_118_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAuditdate_rangetext3_Internalname, AV79AuditDate_RangeText3, StringUtil.RTrim( context.localUtil.Format( AV79AuditDate_RangeText3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,107);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAuditdate_rangetext3_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavAuditdate_rangetext3_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\AuditWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table5_103_5O2e( true) ;
         }
         else
         {
            wb_table5_103_5O2e( false) ;
         }
      }

      protected void wb_table3_72_5O2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergeddynamicfilters2_Internalname, tblTablemergeddynamicfilters2_Internalname, "", "Table", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersoperator2_Internalname, "Dynamic Filters Operator2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_118_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator2, cmbavDynamicfiltersoperator2_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0)), 1, cmbavDynamicfiltersoperator2_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSOPERATOR2.CLICK."+"'", "int", "", cmbavDynamicfiltersoperator2.Visible, cmbavDynamicfiltersoperator2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,76);\"", "", true, 0, "HLP_core\\AuditWW.htm");
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", (string)(cmbavDynamicfiltersoperator2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_auditdate2_cell_Internalname+"\"  class=''>") ;
            wb_table6_78_5O2( true) ;
         }
         else
         {
            wb_table6_78_5O2( false) ;
         }
         return  ;
      }

      protected void wb_table6_78_5O2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters2_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters2_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_core\\AuditWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters2_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters2_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_core\\AuditWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_72_5O2e( true) ;
         }
         else
         {
            wb_table3_72_5O2e( false) ;
         }
      }

      protected void wb_table6_78_5O2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            if ( tblTablemergeddynamicfiltersauditdate2_Visible == 0 )
            {
               sStyleString += "display:none;";
            }
            GxWebStd.gx_table_start( context, tblTablemergeddynamicfiltersauditdate2_Internalname, tblTablemergeddynamicfiltersauditdate2_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td id=\""+cellAuditdate_range_cell2_Internalname+"\"  class='"+cellAuditdate_range_cell2_Class+"'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavAuditdate_rangetext2_Internalname, "Audit Date_Range Text2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'" + sGXsfl_118_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAuditdate_rangetext2_Internalname, AV78AuditDate_RangeText2, StringUtil.RTrim( context.localUtil.Format( AV78AuditDate_RangeText2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,82);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAuditdate_rangetext2_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavAuditdate_rangetext2_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\AuditWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table6_78_5O2e( true) ;
         }
         else
         {
            wb_table6_78_5O2e( false) ;
         }
      }

      protected void wb_table2_47_5O2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergeddynamicfilters1_Internalname, tblTablemergeddynamicfilters1_Internalname, "", "Table", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersoperator1_Internalname, "Dynamic Filters Operator1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'" + sGXsfl_118_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator1, cmbavDynamicfiltersoperator1_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0)), 1, cmbavDynamicfiltersoperator1_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSOPERATOR1.CLICK."+"'", "int", "", cmbavDynamicfiltersoperator1.Visible, cmbavDynamicfiltersoperator1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", "", true, 0, "HLP_core\\AuditWW.htm");
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", (string)(cmbavDynamicfiltersoperator1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_auditdate1_cell_Internalname+"\"  class=''>") ;
            wb_table7_53_5O2( true) ;
         }
         else
         {
            wb_table7_53_5O2( false) ;
         }
         return  ;
      }

      protected void wb_table7_53_5O2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters1_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters1_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_core\\AuditWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters1_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters1_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_core\\AuditWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_47_5O2e( true) ;
         }
         else
         {
            wb_table2_47_5O2e( false) ;
         }
      }

      protected void wb_table7_53_5O2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            if ( tblTablemergeddynamicfiltersauditdate1_Visible == 0 )
            {
               sStyleString += "display:none;";
            }
            GxWebStd.gx_table_start( context, tblTablemergeddynamicfiltersauditdate1_Internalname, tblTablemergeddynamicfiltersauditdate1_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td id=\""+cellAuditdate_range_cell1_Internalname+"\"  class='"+cellAuditdate_range_cell1_Class+"'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavAuditdate_rangetext1_Internalname, "Audit Date_Range Text1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'" + sGXsfl_118_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAuditdate_rangetext1_Internalname, AV77AuditDate_RangeText1, StringUtil.RTrim( context.localUtil.Format( AV77AuditDate_RangeText1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,57);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAuditdate_rangetext1_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavAuditdate_rangetext1_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\AuditWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table7_53_5O2e( true) ;
         }
         else
         {
            wb_table7_53_5O2e( false) ;
         }
      }

      protected void wb_table1_23_5O2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablerightheader_Internalname, tblTablerightheader_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* User Defined Control */
            ucDdo_managefilters.SetProperty("IconType", Ddo_managefilters_Icontype);
            ucDdo_managefilters.SetProperty("Icon", Ddo_managefilters_Icon);
            ucDdo_managefilters.SetProperty("Caption", Ddo_managefilters_Caption);
            ucDdo_managefilters.SetProperty("Tooltip", Ddo_managefilters_Tooltip);
            ucDdo_managefilters.SetProperty("Cls", Ddo_managefilters_Cls);
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV41ManageFiltersData);
            ucDdo_managefilters.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_managefilters_Internalname, "DDO_MANAGEFILTERSContainer");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            wb_table8_28_5O2( true) ;
         }
         else
         {
            wb_table8_28_5O2( false) ;
         }
         return  ;
      }

      protected void wb_table8_28_5O2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_23_5O2e( true) ;
         }
         else
         {
            wb_table1_23_5O2e( false) ;
         }
      }

      protected void wb_table8_28_5O2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablefilters_Internalname, tblTablefilters_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFilterfulltext_Internalname, "Filter Full Text", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'" + sGXsfl_118_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV17FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV17FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Pesquisar", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_core\\AuditWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table8_28_5O2e( true) ;
         }
         else
         {
            wb_table8_28_5O2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
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
         PA5O2( ) ;
         WS5O2( ) ;
         WE5O2( ) ;
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
         AddStyleSheetFile("DVelop/DVPaginationBar/DVPaginationBar.css", "");
         AddStyleSheetFile("DVelop/Shared/daterangepicker/daterangepicker.css", "");
         AddStyleSheetFile("DVelop/Shared/daterangepicker/daterangepicker.css", "");
         AddStyleSheetFile("DVelop/Shared/daterangepicker/daterangepicker.css", "");
         AddStyleSheetFile("DVelop/Shared/daterangepicker/daterangepicker.css", "");
         AddStyleSheetFile("DVelop/Shared/daterangepicker/daterangepicker.css", "");
         AddStyleSheetFile("DVelop/Shared/daterangepicker/daterangepicker.css", "");
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         if ( ! ( WebComp_Grid_dwc == null ) )
         {
            if ( StringUtil.Len( WebComp_Grid_dwc_Component) != 0 )
            {
               WebComp_Grid_dwc.componentthemes();
            }
         }
         if ( ! ( WebComp_Wwpaux_wc == null ) )
         {
            if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
            {
               WebComp_Wwpaux_wc.componentthemes();
            }
         }
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202382823308", true, true);
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
         context.AddJavascriptSource("core/auditww.js", "?2023828233010", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_1182( )
      {
         edtavDetailwebcomponent_Internalname = "vDETAILWEBCOMPONENT_"+sGXsfl_118_idx;
         edtAuditID_Internalname = "AUDITID_"+sGXsfl_118_idx;
         edtAuditDateTime_Internalname = "AUDITDATETIME_"+sGXsfl_118_idx;
         edtAuditDate_Internalname = "AUDITDATE_"+sGXsfl_118_idx;
         edtAuditTime_Internalname = "AUDITTIME_"+sGXsfl_118_idx;
         edtAuditTableName_Internalname = "AUDITTABLENAME_"+sGXsfl_118_idx;
         edtAuditAction_Internalname = "AUDITACTION_"+sGXsfl_118_idx;
         edtAuditShortDescription_Internalname = "AUDITSHORTDESCRIPTION_"+sGXsfl_118_idx;
         edtAuditDescription_Internalname = "AUDITDESCRIPTION_"+sGXsfl_118_idx;
         edtAuditGAMUserName_Internalname = "AUDITGAMUSERNAME_"+sGXsfl_118_idx;
      }

      protected void SubsflControlProps_fel_1182( )
      {
         edtavDetailwebcomponent_Internalname = "vDETAILWEBCOMPONENT_"+sGXsfl_118_fel_idx;
         edtAuditID_Internalname = "AUDITID_"+sGXsfl_118_fel_idx;
         edtAuditDateTime_Internalname = "AUDITDATETIME_"+sGXsfl_118_fel_idx;
         edtAuditDate_Internalname = "AUDITDATE_"+sGXsfl_118_fel_idx;
         edtAuditTime_Internalname = "AUDITTIME_"+sGXsfl_118_fel_idx;
         edtAuditTableName_Internalname = "AUDITTABLENAME_"+sGXsfl_118_fel_idx;
         edtAuditAction_Internalname = "AUDITACTION_"+sGXsfl_118_fel_idx;
         edtAuditShortDescription_Internalname = "AUDITSHORTDESCRIPTION_"+sGXsfl_118_fel_idx;
         edtAuditDescription_Internalname = "AUDITDESCRIPTION_"+sGXsfl_118_fel_idx;
         edtAuditGAMUserName_Internalname = "AUDITGAMUSERNAME_"+sGXsfl_118_fel_idx;
      }

      protected void sendrow_1182( )
      {
         SubsflControlProps_1182( ) ;
         WB5O0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_118_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
         {
            GridRow = GXWebRow.GetNew(context,GridContainer);
            if ( subGrid_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
            }
            else if ( subGrid_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid_Backstyle = 0;
               subGrid_Backcolor = subGrid_Allbackcolor;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Uniform";
               }
            }
            else if ( subGrid_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
               subGrid_Backcolor = (int)(0x0);
            }
            else if ( subGrid_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( ((int)((nGXsfl_118_idx) % (2))) == 0 )
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Even";
                  }
               }
               else
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Odd";
                  }
               }
            }
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"GridWithPaginationBar WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_118_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavDetailwebcomponent_Enabled!=0)&&(edtavDetailwebcomponent_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 119,'',false,'"+sGXsfl_118_idx+"',118)\"" : " ");
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDetailwebcomponent_Internalname,StringUtil.RTrim( AV86DetailWebComponent),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavDetailwebcomponent_Enabled!=0)&&(edtavDetailwebcomponent_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,119);\"" : " "),"'"+""+"'"+",false,"+"'"+"EVDETAILWEBCOMPONENT.CLICK."+sGXsfl_118_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavDetailwebcomponent_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn WCD_ActionColumn",(string)"",(short)-1,(int)edtavDetailwebcomponent_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)118,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAuditID_Internalname,A493AuditID.ToString(),A493AuditID.ToString(),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAuditID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)118,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtAuditDateTime_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAuditDateTime_Internalname,context.localUtil.TToC( A496AuditDateTime, 10, 12, 0, 3, "/", ":", " "),context.localUtil.Format( A496AuditDateTime, "99/99/9999 99:99:99.999"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAuditDateTime_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtAuditDateTime_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)24,(short)0,(short)0,(short)118,(short)0,(short)-1,(short)0,(bool)true,(string)"core\\DataHoraSegundoMS",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtAuditDate_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAuditDate_Internalname,context.localUtil.Format(A494AuditDate, "99/99/99"),context.localUtil.Format( A494AuditDate, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtAuditDate_Link,(string)"",(string)"",(string)"",(string)edtAuditDate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtAuditDate_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)118,(short)0,(short)-1,(short)0,(bool)true,(string)"core\\Data",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtAuditTime_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAuditTime_Internalname,context.localUtil.TToC( A495AuditTime, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A495AuditTime, "99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAuditTime_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtAuditTime_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)5,(short)0,(short)0,(short)118,(short)0,(short)-1,(short)0,(bool)true,(string)"core\\HoraMinuto",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtAuditTableName_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAuditTableName_Internalname,(string)A497AuditTableName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAuditTableName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtAuditTableName_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)118,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtAuditAction_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAuditAction_Internalname,(string)A502AuditAction,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAuditAction_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtAuditAction_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)118,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtAuditShortDescription_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAuditShortDescription_Internalname,(string)A499AuditShortDescription,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAuditShortDescription_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtAuditShortDescription_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)400,(short)0,(short)0,(short)118,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtAuditDescription_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAuditDescription_Internalname,(string)A498AuditDescription,(string)A498AuditDescription,(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAuditDescription_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtAuditDescription_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(int)2097152,(short)0,(short)0,(short)118,(short)0,(short)0,(short)-1,(bool)true,(string)"",(string)"start",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtAuditGAMUserName_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAuditGAMUserName_Internalname,(string)A501AuditGAMUserName,StringUtil.RTrim( context.localUtil.Format( A501AuditGAMUserName, "@!")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAuditGAMUserName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtAuditGAMUserName_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)118,(short)0,(short)-1,(short)-1,(bool)true,(string)"core\\Nome",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes5O2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_118_idx = ((subGrid_Islastpage==1)&&(nGXsfl_118_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_118_idx+1);
            sGXsfl_118_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_118_idx), 4, 0), 4, "0");
            SubsflControlProps_1182( ) ;
         }
         /* End function sendrow_1182 */
      }

      protected void init_web_controls( )
      {
         cmbavDynamicfiltersselector1.Name = "vDYNAMICFILTERSSELECTOR1";
         cmbavDynamicfiltersselector1.WebTags = "";
         cmbavDynamicfiltersselector1.addItem("AUDITDATE", "Data", 0);
         if ( cmbavDynamicfiltersselector1.ItemCount > 0 )
         {
            AV18DynamicFiltersSelector1 = cmbavDynamicfiltersselector1.getValidValue(AV18DynamicFiltersSelector1);
            AssignAttri("", false, "AV18DynamicFiltersSelector1", AV18DynamicFiltersSelector1);
         }
         cmbavDynamicfiltersoperator1.Name = "vDYNAMICFILTERSOPERATOR1";
         cmbavDynamicfiltersoperator1.WebTags = "";
         cmbavDynamicfiltersoperator1.addItem("0", "Período", 0);
         cmbavDynamicfiltersoperator1.addItem("1", "Passado", 0);
         cmbavDynamicfiltersoperator1.addItem("2", "Hoje", 0);
         cmbavDynamicfiltersoperator1.addItem("3", "No futuro", 0);
         if ( cmbavDynamicfiltersoperator1.ItemCount > 0 )
         {
            AV19DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         }
         cmbavDynamicfiltersselector2.Name = "vDYNAMICFILTERSSELECTOR2";
         cmbavDynamicfiltersselector2.WebTags = "";
         cmbavDynamicfiltersselector2.addItem("AUDITDATE", "Data", 0);
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
            AV23DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV23DynamicFiltersSelector2);
            AssignAttri("", false, "AV23DynamicFiltersSelector2", AV23DynamicFiltersSelector2);
         }
         cmbavDynamicfiltersoperator2.Name = "vDYNAMICFILTERSOPERATOR2";
         cmbavDynamicfiltersoperator2.WebTags = "";
         cmbavDynamicfiltersoperator2.addItem("0", "Período", 0);
         cmbavDynamicfiltersoperator2.addItem("1", "Passado", 0);
         cmbavDynamicfiltersoperator2.addItem("2", "Hoje", 0);
         cmbavDynamicfiltersoperator2.addItem("3", "No futuro", 0);
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV24DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV24DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         }
         cmbavDynamicfiltersselector3.Name = "vDYNAMICFILTERSSELECTOR3";
         cmbavDynamicfiltersselector3.WebTags = "";
         cmbavDynamicfiltersselector3.addItem("AUDITDATE", "Data", 0);
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV28DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV28DynamicFiltersSelector3);
            AssignAttri("", false, "AV28DynamicFiltersSelector3", AV28DynamicFiltersSelector3);
         }
         cmbavDynamicfiltersoperator3.Name = "vDYNAMICFILTERSOPERATOR3";
         cmbavDynamicfiltersoperator3.WebTags = "";
         cmbavDynamicfiltersoperator3.addItem("0", "Período", 0);
         cmbavDynamicfiltersoperator3.addItem("1", "Passado", 0);
         cmbavDynamicfiltersoperator3.addItem("2", "Hoje", 0);
         cmbavDynamicfiltersoperator3.addItem("3", "No futuro", 0);
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV29DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV29DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl118( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"118\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid_Internalname, subGrid_Internalname, "", "GridWithPaginationBar WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGrid_Backcolorstyle == 0 )
            {
               subGrid_Titlebackstyle = 0;
               if ( StringUtil.Len( subGrid_Class) > 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Title";
               }
            }
            else
            {
               subGrid_Titlebackstyle = 1;
               if ( subGrid_Backcolorstyle == 1 )
               {
                  subGrid_Titlebackcolor = subGrid_Allbackcolor;
                  if ( StringUtil.Len( subGrid_Class) > 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGrid_Class) > 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtAuditDateTime_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Data/Hora") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtAuditDate_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Data") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtAuditTime_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Hora") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtAuditTableName_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Tabela") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtAuditAction_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Ação") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtAuditShortDescription_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Descrição") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtAuditDescription_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Detalhes") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtAuditGAMUserName_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Usuário") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GridContainer.AddObjectProperty("GridName", "Grid");
         }
         else
         {
            if ( isAjaxCallMode( ) )
            {
               GridContainer = new GXWebGrid( context);
            }
            else
            {
               GridContainer.Clear();
            }
            GridContainer.SetWrapped(nGXWrapped);
            GridContainer.AddObjectProperty("GridName", "Grid");
            GridContainer.AddObjectProperty("Header", subGrid_Header);
            GridContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
            GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("CmpContext", "");
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV86DetailWebComponent)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDetailwebcomponent_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A493AuditID.ToString()));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A496AuditDateTime, 10, 12, 0, 3, "/", ":", " ")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAuditDateTime_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A494AuditDate, "99/99/99")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtAuditDate_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAuditDate_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A495AuditTime, 10, 8, 0, 3, "/", ":", " ")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAuditTime_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A497AuditTableName));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAuditTableName_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A502AuditAction));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAuditAction_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A499AuditShortDescription));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAuditShortDescription_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A498AuditDescription));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAuditDescription_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A501AuditGAMUserName));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAuditGAMUserName_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectedindex), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowselection), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectioncolor), 9, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowhovering), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Hoveringcolor), 9, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowcollapsing), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         bttBtnagexport_Internalname = "BTNAGEXPORT";
         bttBtneditcolumns_Internalname = "BTNEDITCOLUMNS";
         bttBtnsubscriptions_Internalname = "BTNSUBSCRIPTIONS";
         divTableactions_Internalname = "TABLEACTIONS";
         Ddo_managefilters_Internalname = "DDO_MANAGEFILTERS";
         edtavFilterfulltext_Internalname = "vFILTERFULLTEXT";
         tblTablefilters_Internalname = "TABLEFILTERS";
         tblTablerightheader_Internalname = "TABLERIGHTHEADER";
         divTableheadercontent_Internalname = "TABLEHEADERCONTENT";
         lblDynamicfiltersprefix1_Internalname = "DYNAMICFILTERSPREFIX1";
         cmbavDynamicfiltersselector1_Internalname = "vDYNAMICFILTERSSELECTOR1";
         lblDynamicfiltersmiddle1_Internalname = "DYNAMICFILTERSMIDDLE1";
         cmbavDynamicfiltersoperator1_Internalname = "vDYNAMICFILTERSOPERATOR1";
         edtavAuditdate_rangetext1_Internalname = "vAUDITDATE_RANGETEXT1";
         cellAuditdate_range_cell1_Internalname = "AUDITDATE_RANGE_CELL1";
         tblTablemergeddynamicfiltersauditdate1_Internalname = "TABLEMERGEDDYNAMICFILTERSAUDITDATE1";
         cellFilter_auditdate1_cell_Internalname = "FILTER_AUDITDATE1_CELL";
         imgAdddynamicfilters1_Internalname = "ADDDYNAMICFILTERS1";
         cellDynamicfilters_addfilter1_cell_Internalname = "DYNAMICFILTERS_ADDFILTER1_CELL";
         imgRemovedynamicfilters1_Internalname = "REMOVEDYNAMICFILTERS1";
         cellDynamicfilters_removefilter1_cell_Internalname = "DYNAMICFILTERS_REMOVEFILTER1_CELL";
         tblTablemergeddynamicfilters1_Internalname = "TABLEMERGEDDYNAMICFILTERS1";
         divTabledynamicfiltersrow1_Internalname = "TABLEDYNAMICFILTERSROW1";
         lblDynamicfiltersprefix2_Internalname = "DYNAMICFILTERSPREFIX2";
         cmbavDynamicfiltersselector2_Internalname = "vDYNAMICFILTERSSELECTOR2";
         lblDynamicfiltersmiddle2_Internalname = "DYNAMICFILTERSMIDDLE2";
         cmbavDynamicfiltersoperator2_Internalname = "vDYNAMICFILTERSOPERATOR2";
         edtavAuditdate_rangetext2_Internalname = "vAUDITDATE_RANGETEXT2";
         cellAuditdate_range_cell2_Internalname = "AUDITDATE_RANGE_CELL2";
         tblTablemergeddynamicfiltersauditdate2_Internalname = "TABLEMERGEDDYNAMICFILTERSAUDITDATE2";
         cellFilter_auditdate2_cell_Internalname = "FILTER_AUDITDATE2_CELL";
         imgAdddynamicfilters2_Internalname = "ADDDYNAMICFILTERS2";
         cellDynamicfilters_addfilter2_cell_Internalname = "DYNAMICFILTERS_ADDFILTER2_CELL";
         imgRemovedynamicfilters2_Internalname = "REMOVEDYNAMICFILTERS2";
         cellDynamicfilters_removefilter2_cell_Internalname = "DYNAMICFILTERS_REMOVEFILTER2_CELL";
         tblTablemergeddynamicfilters2_Internalname = "TABLEMERGEDDYNAMICFILTERS2";
         divTabledynamicfiltersrow2_Internalname = "TABLEDYNAMICFILTERSROW2";
         lblDynamicfiltersprefix3_Internalname = "DYNAMICFILTERSPREFIX3";
         cmbavDynamicfiltersselector3_Internalname = "vDYNAMICFILTERSSELECTOR3";
         lblDynamicfiltersmiddle3_Internalname = "DYNAMICFILTERSMIDDLE3";
         cmbavDynamicfiltersoperator3_Internalname = "vDYNAMICFILTERSOPERATOR3";
         edtavAuditdate_rangetext3_Internalname = "vAUDITDATE_RANGETEXT3";
         cellAuditdate_range_cell3_Internalname = "AUDITDATE_RANGE_CELL3";
         tblTablemergeddynamicfiltersauditdate3_Internalname = "TABLEMERGEDDYNAMICFILTERSAUDITDATE3";
         cellFilter_auditdate3_cell_Internalname = "FILTER_AUDITDATE3_CELL";
         imgRemovedynamicfilters3_Internalname = "REMOVEDYNAMICFILTERS3";
         cellDynamicfilters_removefilter3_cell_Internalname = "DYNAMICFILTERS_REMOVEFILTER3_CELL";
         tblTablemergeddynamicfilters3_Internalname = "TABLEMERGEDDYNAMICFILTERS3";
         divTabledynamicfiltersrow3_Internalname = "TABLEDYNAMICFILTERSROW3";
         divTabledynamicfilters_Internalname = "TABLEDYNAMICFILTERS";
         divAdvancedfilterscontainer_Internalname = "ADVANCEDFILTERSCONTAINER";
         divTableheader_Internalname = "TABLEHEADER";
         edtavDetailwebcomponent_Internalname = "vDETAILWEBCOMPONENT";
         edtAuditID_Internalname = "AUDITID";
         edtAuditDateTime_Internalname = "AUDITDATETIME";
         edtAuditDate_Internalname = "AUDITDATE";
         edtAuditTime_Internalname = "AUDITTIME";
         edtAuditTableName_Internalname = "AUDITTABLENAME";
         edtAuditAction_Internalname = "AUDITACTION";
         edtAuditShortDescription_Internalname = "AUDITSHORTDESCRIPTION";
         edtAuditDescription_Internalname = "AUDITDESCRIPTION";
         edtAuditGAMUserName_Internalname = "AUDITGAMUSERNAME";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divCell_grid_dwc_Internalname = "CELL_GRID_DWC";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         Ddo_agexport_Internalname = "DDO_AGEXPORT";
         Ddc_subscriptions_Internalname = "DDC_SUBSCRIPTIONS";
         Auditdate_rangepicker1_Internalname = "AUDITDATE_RANGEPICKER1";
         Auditdate_rangepicker2_Internalname = "AUDITDATE_RANGEPICKER2";
         Auditdate_rangepicker3_Internalname = "AUDITDATE_RANGEPICKER3";
         lblJsdynamicfilters_Internalname = "JSDYNAMICFILTERS";
         Ddo_grid_Internalname = "DDO_GRID";
         Innewwindow1_Internalname = "INNEWWINDOW1";
         Ddo_gridcolumnsselector_Internalname = "DDO_GRIDCOLUMNSSELECTOR";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
         divDiv_wwpauxwc_Internalname = "DIV_WWPAUXWC";
         edtavDdo_auditdatetimeauxdatetext_Internalname = "vDDO_AUDITDATETIMEAUXDATETEXT";
         Tfauditdatetime_rangepicker_Internalname = "TFAUDITDATETIME_RANGEPICKER";
         divDdo_auditdatetimeauxdates_Internalname = "DDO_AUDITDATETIMEAUXDATES";
         edtavDdo_auditdateauxdatetext_Internalname = "vDDO_AUDITDATEAUXDATETEXT";
         Tfauditdate_rangepicker_Internalname = "TFAUDITDATE_RANGEPICKER";
         divDdo_auditdateauxdates_Internalname = "DDO_AUDITDATEAUXDATES";
         edtavDdo_audittimeauxdatetext_Internalname = "vDDO_AUDITTIMEAUXDATETEXT";
         Tfaudittime_rangepicker_Internalname = "TFAUDITTIME_RANGEPICKER";
         divDdo_audittimeauxdates_Internalname = "DDO_AUDITTIMEAUXDATES";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subGrid_Internalname = "GRID";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         subGrid_Header = "";
         edtAuditGAMUserName_Jsonclick = "";
         edtAuditDescription_Jsonclick = "";
         edtAuditShortDescription_Jsonclick = "";
         edtAuditAction_Jsonclick = "";
         edtAuditTableName_Jsonclick = "";
         edtAuditTime_Jsonclick = "";
         edtAuditDate_Jsonclick = "";
         edtAuditDate_Link = "";
         edtAuditDateTime_Jsonclick = "";
         edtAuditID_Jsonclick = "";
         edtavDetailwebcomponent_Jsonclick = "";
         edtavDetailwebcomponent_Visible = -1;
         edtavDetailwebcomponent_Enabled = 1;
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         edtavAuditdate_rangetext1_Jsonclick = "";
         edtavAuditdate_rangetext1_Enabled = 1;
         imgRemovedynamicfilters1_Visible = 1;
         imgAdddynamicfilters1_Visible = 1;
         cmbavDynamicfiltersoperator1_Jsonclick = "";
         cmbavDynamicfiltersoperator1.Enabled = 1;
         edtavAuditdate_rangetext2_Jsonclick = "";
         edtavAuditdate_rangetext2_Enabled = 1;
         imgRemovedynamicfilters2_Visible = 1;
         imgAdddynamicfilters2_Visible = 1;
         cmbavDynamicfiltersoperator2_Jsonclick = "";
         cmbavDynamicfiltersoperator2.Enabled = 1;
         edtavAuditdate_rangetext3_Jsonclick = "";
         edtavAuditdate_rangetext3_Enabled = 1;
         cmbavDynamicfiltersoperator3_Jsonclick = "";
         cmbavDynamicfiltersoperator3.Enabled = 1;
         cellAuditdate_range_cell3_Class = "MergeDataCell";
         cmbavDynamicfiltersoperator3.Visible = 1;
         tblTablemergeddynamicfiltersauditdate3_Visible = 1;
         cellAuditdate_range_cell2_Class = "MergeDataCell";
         cmbavDynamicfiltersoperator2.Visible = 1;
         tblTablemergeddynamicfiltersauditdate2_Visible = 1;
         cellAuditdate_range_cell1_Class = "MergeDataCell";
         cmbavDynamicfiltersoperator1.Visible = 1;
         tblTablemergeddynamicfiltersauditdate1_Visible = 1;
         edtAuditGAMUserName_Visible = -1;
         edtAuditDescription_Visible = -1;
         edtAuditShortDescription_Visible = -1;
         edtAuditAction_Visible = -1;
         edtAuditTableName_Visible = -1;
         edtAuditTime_Visible = -1;
         edtAuditDate_Visible = -1;
         edtAuditDateTime_Visible = -1;
         subGrid_Sortable = 0;
         edtavDdo_audittimeauxdatetext_Jsonclick = "";
         edtavDdo_auditdateauxdatetext_Jsonclick = "";
         edtavDdo_auditdatetimeauxdatetext_Jsonclick = "";
         lblJsdynamicfilters_Caption = "JSDynamicFilters";
         divCell_grid_dwc_Class = "col-xs-12";
         cmbavDynamicfiltersselector3_Jsonclick = "";
         cmbavDynamicfiltersselector3.Enabled = 1;
         cmbavDynamicfiltersselector2_Jsonclick = "";
         cmbavDynamicfiltersselector2.Enabled = 1;
         cmbavDynamicfiltersselector1_Jsonclick = "";
         cmbavDynamicfiltersselector1.Enabled = 1;
         bttBtnsubscriptions_Visible = 1;
         Grid_empowerer_Hascolumnsselector = Convert.ToBoolean( -1);
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = "";
         Ddo_gridcolumnsselector_Dropdownoptionstype = "GridColumnsSelector";
         Ddo_gridcolumnsselector_Cls = "ColumnsSelector hidden-xs";
         Ddo_gridcolumnsselector_Tooltip = "WWP_EditColumnsTooltip";
         Ddo_gridcolumnsselector_Caption = "Selecionar colunas";
         Ddo_gridcolumnsselector_Icon = "fas fa-cog";
         Ddo_gridcolumnsselector_Icontype = "FontIcon";
         Innewwindow1_Target = "";
         Innewwindow1_Height = "50";
         Innewwindow1_Width = "50";
         Ddo_grid_Datalistproc = "core.AuditWWGetFilterData";
         Ddo_grid_Datalisttype = "|||Dynamic|Dynamic|Dynamic|Dynamic|Dynamic";
         Ddo_grid_Includedatalist = "|||T|T|T|T|T";
         Ddo_grid_Filterisrange = "P|P|P|||||";
         Ddo_grid_Filtertype = "Date|Date|Date|Character|Character|Character|Character|Character";
         Ddo_grid_Includefilter = "T";
         Ddo_grid_Fixable = "T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "1|2|3|4|5|6|7|8";
         Ddo_grid_Columnids = "2:AuditDateTime|3:AuditDate|4:AuditTime|5:AuditTableName|6:AuditAction|7:AuditShortDescription|8:AuditDescription|9:AuditGAMUserName";
         Ddo_grid_Gridinternalname = "";
         Ddc_subscriptions_Titlecontrolidtoreplace = "";
         Ddc_subscriptions_Cls = "ColumnsSelector";
         Ddc_subscriptions_Tooltip = "WWP_Subscriptions_Tooltip";
         Ddc_subscriptions_Caption = "";
         Ddc_subscriptions_Icon = "fas fa-rss";
         Ddc_subscriptions_Icontype = "FontIcon";
         Ddo_agexport_Titlecontrolidtoreplace = "";
         Ddo_agexport_Cls = "ColumnsSelector";
         Ddo_agexport_Icon = "fas fa-download";
         Ddo_agexport_Icontype = "FontIcon";
         Gridpaginationbar_Rowsperpagecaption = "WWP_PagingRowsPerPage";
         Gridpaginationbar_Emptygridcaption = "WWP_PagingEmptyGridCaption";
         Gridpaginationbar_Caption = "Página <CURRENT_PAGE> de <TOTAL_PAGES>";
         Gridpaginationbar_Last = "WWP_PagingLastCaption";
         Gridpaginationbar_Next = "WWP_PagingNextCaption";
         Gridpaginationbar_Previous = "WWP_PagingPreviousCaption";
         Gridpaginationbar_First = "WWP_PagingFirstCaption";
         Gridpaginationbar_Rowsperpageoptions = "5:WWP_Rows5,10:WWP_Rows10,20:WWP_Rows20,50:WWP_Rows50";
         Gridpaginationbar_Rowsperpageselectedvalue = 10;
         Gridpaginationbar_Rowsperpageselector = Convert.ToBoolean( -1);
         Gridpaginationbar_Emptygridclass = "PaginationBarEmptyGrid";
         Gridpaginationbar_Pagingcaptionposition = "Left";
         Gridpaginationbar_Pagingbuttonsposition = "Left";
         Gridpaginationbar_Pagestoshow = 5;
         Gridpaginationbar_Showlast = Convert.ToBoolean( -1);
         Gridpaginationbar_Shownext = Convert.ToBoolean( -1);
         Gridpaginationbar_Showprevious = Convert.ToBoolean( -1);
         Gridpaginationbar_Showfirst = Convert.ToBoolean( -1);
         Gridpaginationbar_Class = "PaginationBar";
         Ddo_managefilters_Cls = "ManageFilters";
         Ddo_managefilters_Tooltip = "WWP_ManageFiltersTooltip";
         Ddo_managefilters_Icon = "fas fa-filter";
         Ddo_managefilters_Icontype = "FontIcon";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = " Auditoria dos Dados";
         subGrid_Rows = 0;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV20AuditDate1',fld:'vAUDITDATE1',pic:''},{av:'AV25AuditDate2',fld:'vAUDITDATE2',pic:''},{av:'AV30AuditDate3',fld:'vAUDITDATE3',pic:''},{av:'AV87Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV21AuditDate_To1',fld:'vAUDITDATE_TO1',pic:''},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV26AuditDate_To2',fld:'vAUDITDATE_TO2',pic:''},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV31AuditDate_To3',fld:'vAUDITDATE_TO3',pic:''},{av:'AV81TFAuditDateTime',fld:'vTFAUDITDATETIME',pic:'99/99/9999 99:99:99.999'},{av:'AV82TFAuditDateTime_To',fld:'vTFAUDITDATETIME_TO',pic:'99/99/9999 99:99:99.999'},{av:'AV44TFAuditDate',fld:'vTFAUDITDATE',pic:''},{av:'AV45TFAuditDate_To',fld:'vTFAUDITDATE_TO',pic:''},{av:'AV49TFAuditTime',fld:'vTFAUDITTIME',pic:'99:99'},{av:'AV50TFAuditTime_To',fld:'vTFAUDITTIME_TO',pic:'99:99'},{av:'AV54TFAuditTableName',fld:'vTFAUDITTABLENAME',pic:''},{av:'AV55TFAuditTableName_Sel',fld:'vTFAUDITTABLENAME_SEL',pic:''},{av:'AV62TFAuditAction',fld:'vTFAUDITACTION',pic:''},{av:'AV63TFAuditAction_Sel',fld:'vTFAUDITACTION_SEL',pic:''},{av:'AV56TFAuditShortDescription',fld:'vTFAUDITSHORTDESCRIPTION',pic:''},{av:'AV57TFAuditShortDescription_Sel',fld:'vTFAUDITSHORTDESCRIPTION_SEL',pic:''},{av:'AV58TFAuditDescription',fld:'vTFAUDITDESCRIPTION',pic:''},{av:'AV59TFAuditDescription_Sel',fld:'vTFAUDITDESCRIPTION_SEL',pic:''},{av:'AV60TFAuditGAMUserName',fld:'vTFAUDITGAMUSERNAME',pic:'@!'},{av:'AV61TFAuditGAMUserName_Sel',fld:'vTFAUDITGAMUSERNAME_SEL',pic:'@!'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV80IsAuthorized_AuditDate',fld:'vISAUTHORIZED_AUDITDATE',pic:'',hsh:true},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtAuditDateTime_Visible',ctrl:'AUDITDATETIME',prop:'Visible'},{av:'edtAuditDate_Visible',ctrl:'AUDITDATE',prop:'Visible'},{av:'edtAuditTime_Visible',ctrl:'AUDITTIME',prop:'Visible'},{av:'edtAuditTableName_Visible',ctrl:'AUDITTABLENAME',prop:'Visible'},{av:'edtAuditAction_Visible',ctrl:'AUDITACTION',prop:'Visible'},{av:'edtAuditShortDescription_Visible',ctrl:'AUDITSHORTDESCRIPTION',prop:'Visible'},{av:'edtAuditDescription_Visible',ctrl:'AUDITDESCRIPTION',prop:'Visible'},{av:'edtAuditGAMUserName_Visible',ctrl:'AUDITGAMUSERNAME',prop:'Visible'},{av:'AV68GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV69GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV70GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E125O2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV20AuditDate1',fld:'vAUDITDATE1',pic:''},{av:'AV25AuditDate2',fld:'vAUDITDATE2',pic:''},{av:'AV30AuditDate3',fld:'vAUDITDATE3',pic:''},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV87Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV21AuditDate_To1',fld:'vAUDITDATE_TO1',pic:''},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV26AuditDate_To2',fld:'vAUDITDATE_TO2',pic:''},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV31AuditDate_To3',fld:'vAUDITDATE_TO3',pic:''},{av:'AV81TFAuditDateTime',fld:'vTFAUDITDATETIME',pic:'99/99/9999 99:99:99.999'},{av:'AV82TFAuditDateTime_To',fld:'vTFAUDITDATETIME_TO',pic:'99/99/9999 99:99:99.999'},{av:'AV44TFAuditDate',fld:'vTFAUDITDATE',pic:''},{av:'AV45TFAuditDate_To',fld:'vTFAUDITDATE_TO',pic:''},{av:'AV49TFAuditTime',fld:'vTFAUDITTIME',pic:'99:99'},{av:'AV50TFAuditTime_To',fld:'vTFAUDITTIME_TO',pic:'99:99'},{av:'AV54TFAuditTableName',fld:'vTFAUDITTABLENAME',pic:''},{av:'AV55TFAuditTableName_Sel',fld:'vTFAUDITTABLENAME_SEL',pic:''},{av:'AV62TFAuditAction',fld:'vTFAUDITACTION',pic:''},{av:'AV63TFAuditAction_Sel',fld:'vTFAUDITACTION_SEL',pic:''},{av:'AV56TFAuditShortDescription',fld:'vTFAUDITSHORTDESCRIPTION',pic:''},{av:'AV57TFAuditShortDescription_Sel',fld:'vTFAUDITSHORTDESCRIPTION_SEL',pic:''},{av:'AV58TFAuditDescription',fld:'vTFAUDITDESCRIPTION',pic:''},{av:'AV59TFAuditDescription_Sel',fld:'vTFAUDITDESCRIPTION_SEL',pic:''},{av:'AV60TFAuditGAMUserName',fld:'vTFAUDITGAMUSERNAME',pic:'@!'},{av:'AV61TFAuditGAMUserName_Sel',fld:'vTFAUDITGAMUSERNAME_SEL',pic:'@!'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV80IsAuthorized_AuditDate',fld:'vISAUTHORIZED_AUDITDATE',pic:'',hsh:true},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E135O2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV20AuditDate1',fld:'vAUDITDATE1',pic:''},{av:'AV25AuditDate2',fld:'vAUDITDATE2',pic:''},{av:'AV30AuditDate3',fld:'vAUDITDATE3',pic:''},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV87Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV21AuditDate_To1',fld:'vAUDITDATE_TO1',pic:''},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV26AuditDate_To2',fld:'vAUDITDATE_TO2',pic:''},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV31AuditDate_To3',fld:'vAUDITDATE_TO3',pic:''},{av:'AV81TFAuditDateTime',fld:'vTFAUDITDATETIME',pic:'99/99/9999 99:99:99.999'},{av:'AV82TFAuditDateTime_To',fld:'vTFAUDITDATETIME_TO',pic:'99/99/9999 99:99:99.999'},{av:'AV44TFAuditDate',fld:'vTFAUDITDATE',pic:''},{av:'AV45TFAuditDate_To',fld:'vTFAUDITDATE_TO',pic:''},{av:'AV49TFAuditTime',fld:'vTFAUDITTIME',pic:'99:99'},{av:'AV50TFAuditTime_To',fld:'vTFAUDITTIME_TO',pic:'99:99'},{av:'AV54TFAuditTableName',fld:'vTFAUDITTABLENAME',pic:''},{av:'AV55TFAuditTableName_Sel',fld:'vTFAUDITTABLENAME_SEL',pic:''},{av:'AV62TFAuditAction',fld:'vTFAUDITACTION',pic:''},{av:'AV63TFAuditAction_Sel',fld:'vTFAUDITACTION_SEL',pic:''},{av:'AV56TFAuditShortDescription',fld:'vTFAUDITSHORTDESCRIPTION',pic:''},{av:'AV57TFAuditShortDescription_Sel',fld:'vTFAUDITSHORTDESCRIPTION_SEL',pic:''},{av:'AV58TFAuditDescription',fld:'vTFAUDITDESCRIPTION',pic:''},{av:'AV59TFAuditDescription_Sel',fld:'vTFAUDITDESCRIPTION_SEL',pic:''},{av:'AV60TFAuditGAMUserName',fld:'vTFAUDITGAMUSERNAME',pic:'@!'},{av:'AV61TFAuditGAMUserName_Sel',fld:'vTFAUDITGAMUSERNAME_SEL',pic:'@!'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV80IsAuthorized_AuditDate',fld:'vISAUTHORIZED_AUDITDATE',pic:'',hsh:true},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]}");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","{handler:'E195O2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV20AuditDate1',fld:'vAUDITDATE1',pic:''},{av:'AV25AuditDate2',fld:'vAUDITDATE2',pic:''},{av:'AV30AuditDate3',fld:'vAUDITDATE3',pic:''},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV87Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV21AuditDate_To1',fld:'vAUDITDATE_TO1',pic:''},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV26AuditDate_To2',fld:'vAUDITDATE_TO2',pic:''},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV31AuditDate_To3',fld:'vAUDITDATE_TO3',pic:''},{av:'AV81TFAuditDateTime',fld:'vTFAUDITDATETIME',pic:'99/99/9999 99:99:99.999'},{av:'AV82TFAuditDateTime_To',fld:'vTFAUDITDATETIME_TO',pic:'99/99/9999 99:99:99.999'},{av:'AV44TFAuditDate',fld:'vTFAUDITDATE',pic:''},{av:'AV45TFAuditDate_To',fld:'vTFAUDITDATE_TO',pic:''},{av:'AV49TFAuditTime',fld:'vTFAUDITTIME',pic:'99:99'},{av:'AV50TFAuditTime_To',fld:'vTFAUDITTIME_TO',pic:'99:99'},{av:'AV54TFAuditTableName',fld:'vTFAUDITTABLENAME',pic:''},{av:'AV55TFAuditTableName_Sel',fld:'vTFAUDITTABLENAME_SEL',pic:''},{av:'AV62TFAuditAction',fld:'vTFAUDITACTION',pic:''},{av:'AV63TFAuditAction_Sel',fld:'vTFAUDITACTION_SEL',pic:''},{av:'AV56TFAuditShortDescription',fld:'vTFAUDITSHORTDESCRIPTION',pic:''},{av:'AV57TFAuditShortDescription_Sel',fld:'vTFAUDITSHORTDESCRIPTION_SEL',pic:''},{av:'AV58TFAuditDescription',fld:'vTFAUDITDESCRIPTION',pic:''},{av:'AV59TFAuditDescription_Sel',fld:'vTFAUDITDESCRIPTION_SEL',pic:''},{av:'AV60TFAuditGAMUserName',fld:'vTFAUDITGAMUSERNAME',pic:'@!'},{av:'AV61TFAuditGAMUserName_Sel',fld:'vTFAUDITGAMUSERNAME_SEL',pic:'@!'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV80IsAuthorized_AuditDate',fld:'vISAUTHORIZED_AUDITDATE',pic:'',hsh:true},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true},{av:'Ddo_grid_Activeeventkey',ctrl:'DDO_GRID',prop:'ActiveEventKey'},{av:'Ddo_grid_Selectedvalue_get',ctrl:'DDO_GRID',prop:'SelectedValue_get'},{av:'Ddo_grid_Filteredtextto_get',ctrl:'DDO_GRID',prop:'FilteredTextTo_get'},{av:'Ddo_grid_Filteredtext_get',ctrl:'DDO_GRID',prop:'FilteredText_get'},{av:'Ddo_grid_Selectedcolumn',ctrl:'DDO_GRID',prop:'SelectedColumn'}]");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",",oparms:[{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV60TFAuditGAMUserName',fld:'vTFAUDITGAMUSERNAME',pic:'@!'},{av:'AV61TFAuditGAMUserName_Sel',fld:'vTFAUDITGAMUSERNAME_SEL',pic:'@!'},{av:'AV58TFAuditDescription',fld:'vTFAUDITDESCRIPTION',pic:''},{av:'AV59TFAuditDescription_Sel',fld:'vTFAUDITDESCRIPTION_SEL',pic:''},{av:'AV56TFAuditShortDescription',fld:'vTFAUDITSHORTDESCRIPTION',pic:''},{av:'AV57TFAuditShortDescription_Sel',fld:'vTFAUDITSHORTDESCRIPTION_SEL',pic:''},{av:'AV62TFAuditAction',fld:'vTFAUDITACTION',pic:''},{av:'AV63TFAuditAction_Sel',fld:'vTFAUDITACTION_SEL',pic:''},{av:'AV54TFAuditTableName',fld:'vTFAUDITTABLENAME',pic:''},{av:'AV55TFAuditTableName_Sel',fld:'vTFAUDITTABLENAME_SEL',pic:''},{av:'AV49TFAuditTime',fld:'vTFAUDITTIME',pic:'99:99'},{av:'AV50TFAuditTime_To',fld:'vTFAUDITTIME_TO',pic:'99:99'},{av:'AV44TFAuditDate',fld:'vTFAUDITDATE',pic:''},{av:'AV45TFAuditDate_To',fld:'vTFAUDITDATE_TO',pic:''},{av:'AV81TFAuditDateTime',fld:'vTFAUDITDATETIME',pic:'99/99/9999 99:99:99.999'},{av:'AV82TFAuditDateTime_To',fld:'vTFAUDITDATETIME_TO',pic:'99/99/9999 99:99:99.999'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E345O2',iparms:[{av:'AV80IsAuthorized_AuditDate',fld:'vISAUTHORIZED_AUDITDATE',pic:'',hsh:true},{av:'A493AuditID',fld:'AUDITID',pic:'',hsh:true}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'AV86DetailWebComponent',fld:'vDETAILWEBCOMPONENT',pic:''},{av:'edtAuditDate_Link',ctrl:'AUDITDATE',prop:'Link'}]}");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED","{handler:'E205O2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV20AuditDate1',fld:'vAUDITDATE1',pic:''},{av:'AV25AuditDate2',fld:'vAUDITDATE2',pic:''},{av:'AV30AuditDate3',fld:'vAUDITDATE3',pic:''},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV87Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV21AuditDate_To1',fld:'vAUDITDATE_TO1',pic:''},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV26AuditDate_To2',fld:'vAUDITDATE_TO2',pic:''},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV31AuditDate_To3',fld:'vAUDITDATE_TO3',pic:''},{av:'AV81TFAuditDateTime',fld:'vTFAUDITDATETIME',pic:'99/99/9999 99:99:99.999'},{av:'AV82TFAuditDateTime_To',fld:'vTFAUDITDATETIME_TO',pic:'99/99/9999 99:99:99.999'},{av:'AV44TFAuditDate',fld:'vTFAUDITDATE',pic:''},{av:'AV45TFAuditDate_To',fld:'vTFAUDITDATE_TO',pic:''},{av:'AV49TFAuditTime',fld:'vTFAUDITTIME',pic:'99:99'},{av:'AV50TFAuditTime_To',fld:'vTFAUDITTIME_TO',pic:'99:99'},{av:'AV54TFAuditTableName',fld:'vTFAUDITTABLENAME',pic:''},{av:'AV55TFAuditTableName_Sel',fld:'vTFAUDITTABLENAME_SEL',pic:''},{av:'AV62TFAuditAction',fld:'vTFAUDITACTION',pic:''},{av:'AV63TFAuditAction_Sel',fld:'vTFAUDITACTION_SEL',pic:''},{av:'AV56TFAuditShortDescription',fld:'vTFAUDITSHORTDESCRIPTION',pic:''},{av:'AV57TFAuditShortDescription_Sel',fld:'vTFAUDITSHORTDESCRIPTION_SEL',pic:''},{av:'AV58TFAuditDescription',fld:'vTFAUDITDESCRIPTION',pic:''},{av:'AV59TFAuditDescription_Sel',fld:'vTFAUDITDESCRIPTION_SEL',pic:''},{av:'AV60TFAuditGAMUserName',fld:'vTFAUDITGAMUSERNAME',pic:'@!'},{av:'AV61TFAuditGAMUserName_Sel',fld:'vTFAUDITGAMUSERNAME_SEL',pic:'@!'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV80IsAuthorized_AuditDate',fld:'vISAUTHORIZED_AUDITDATE',pic:'',hsh:true},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true},{av:'Ddo_gridcolumnsselector_Columnsselectorvalues',ctrl:'DDO_GRIDCOLUMNSSELECTOR',prop:'ColumnsSelectorValues'}]");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED",",oparms:[{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'edtAuditDateTime_Visible',ctrl:'AUDITDATETIME',prop:'Visible'},{av:'edtAuditDate_Visible',ctrl:'AUDITDATE',prop:'Visible'},{av:'edtAuditTime_Visible',ctrl:'AUDITTIME',prop:'Visible'},{av:'edtAuditTableName_Visible',ctrl:'AUDITTABLENAME',prop:'Visible'},{av:'edtAuditAction_Visible',ctrl:'AUDITACTION',prop:'Visible'},{av:'edtAuditShortDescription_Visible',ctrl:'AUDITSHORTDESCRIPTION',prop:'Visible'},{av:'edtAuditDescription_Visible',ctrl:'AUDITDESCRIPTION',prop:'Visible'},{av:'edtAuditGAMUserName_Visible',ctrl:'AUDITGAMUSERNAME',prop:'Visible'},{av:'AV68GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV69GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV70GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("'ADDDYNAMICFILTERS1'","{handler:'E245O2',iparms:[]");
         setEventMetadata("'ADDDYNAMICFILTERS1'",",oparms:[{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'","{handler:'E215O2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV20AuditDate1',fld:'vAUDITDATE1',pic:''},{av:'AV25AuditDate2',fld:'vAUDITDATE2',pic:''},{av:'AV30AuditDate3',fld:'vAUDITDATE3',pic:''},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV87Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV21AuditDate_To1',fld:'vAUDITDATE_TO1',pic:''},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV26AuditDate_To2',fld:'vAUDITDATE_TO2',pic:''},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV31AuditDate_To3',fld:'vAUDITDATE_TO3',pic:''},{av:'AV81TFAuditDateTime',fld:'vTFAUDITDATETIME',pic:'99/99/9999 99:99:99.999'},{av:'AV82TFAuditDateTime_To',fld:'vTFAUDITDATETIME_TO',pic:'99/99/9999 99:99:99.999'},{av:'AV44TFAuditDate',fld:'vTFAUDITDATE',pic:''},{av:'AV45TFAuditDate_To',fld:'vTFAUDITDATE_TO',pic:''},{av:'AV49TFAuditTime',fld:'vTFAUDITTIME',pic:'99:99'},{av:'AV50TFAuditTime_To',fld:'vTFAUDITTIME_TO',pic:'99:99'},{av:'AV54TFAuditTableName',fld:'vTFAUDITTABLENAME',pic:''},{av:'AV55TFAuditTableName_Sel',fld:'vTFAUDITTABLENAME_SEL',pic:''},{av:'AV62TFAuditAction',fld:'vTFAUDITACTION',pic:''},{av:'AV63TFAuditAction_Sel',fld:'vTFAUDITACTION_SEL',pic:''},{av:'AV56TFAuditShortDescription',fld:'vTFAUDITSHORTDESCRIPTION',pic:''},{av:'AV57TFAuditShortDescription_Sel',fld:'vTFAUDITSHORTDESCRIPTION_SEL',pic:''},{av:'AV58TFAuditDescription',fld:'vTFAUDITDESCRIPTION',pic:''},{av:'AV59TFAuditDescription_Sel',fld:'vTFAUDITDESCRIPTION_SEL',pic:''},{av:'AV60TFAuditGAMUserName',fld:'vTFAUDITGAMUSERNAME',pic:'@!'},{av:'AV61TFAuditGAMUserName_Sel',fld:'vTFAUDITGAMUSERNAME_SEL',pic:'@!'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV80IsAuthorized_AuditDate',fld:'vISAUTHORIZED_AUDITDATE',pic:'',hsh:true},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'",",oparms:[{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV25AuditDate2',fld:'vAUDITDATE2',pic:''},{av:'AV26AuditDate_To2',fld:'vAUDITDATE_TO2',pic:''},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV30AuditDate3',fld:'vAUDITDATE3',pic:''},{av:'AV31AuditDate_To3',fld:'vAUDITDATE_TO3',pic:''},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV20AuditDate1',fld:'vAUDITDATE1',pic:''},{av:'AV21AuditDate_To1',fld:'vAUDITDATE_TO1',pic:''},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'tblTablemergeddynamicfiltersauditdate2_Visible',ctrl:'TABLEMERGEDDYNAMICFILTERSAUDITDATE2',prop:'Visible'},{av:'tblTablemergeddynamicfiltersauditdate3_Visible',ctrl:'TABLEMERGEDDYNAMICFILTERSAUDITDATE3',prop:'Visible'},{av:'tblTablemergeddynamicfiltersauditdate1_Visible',ctrl:'TABLEMERGEDDYNAMICFILTERSAUDITDATE1',prop:'Visible'},{av:'cellAuditdate_range_cell2_Class',ctrl:'AUDITDATE_RANGE_CELL2',prop:'Class'},{av:'cellAuditdate_range_cell3_Class',ctrl:'AUDITDATE_RANGE_CELL3',prop:'Class'},{av:'cellAuditdate_range_cell1_Class',ctrl:'AUDITDATE_RANGE_CELL1',prop:'Class'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtAuditDateTime_Visible',ctrl:'AUDITDATETIME',prop:'Visible'},{av:'edtAuditDate_Visible',ctrl:'AUDITDATE',prop:'Visible'},{av:'edtAuditTime_Visible',ctrl:'AUDITTIME',prop:'Visible'},{av:'edtAuditTableName_Visible',ctrl:'AUDITTABLENAME',prop:'Visible'},{av:'edtAuditAction_Visible',ctrl:'AUDITACTION',prop:'Visible'},{av:'edtAuditShortDescription_Visible',ctrl:'AUDITSHORTDESCRIPTION',prop:'Visible'},{av:'edtAuditDescription_Visible',ctrl:'AUDITDESCRIPTION',prop:'Visible'},{av:'edtAuditGAMUserName_Visible',ctrl:'AUDITGAMUSERNAME',prop:'Visible'},{av:'AV68GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV69GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV70GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK","{handler:'E255O2',iparms:[{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK",",oparms:[{av:'tblTablemergeddynamicfiltersauditdate1_Visible',ctrl:'TABLEMERGEDDYNAMICFILTERSAUDITDATE1',prop:'Visible'},{av:'cmbavDynamicfiltersoperator1'},{av:'cellAuditdate_range_cell1_Class',ctrl:'AUDITDATE_RANGE_CELL1',prop:'Class'},{av:'AV20AuditDate1',fld:'vAUDITDATE1',pic:''}]}");
         setEventMetadata("AUDITDATE_RANGEPICKER1.DATERANGECHANGED","{handler:'E165O2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV20AuditDate1',fld:'vAUDITDATE1',pic:''},{av:'AV25AuditDate2',fld:'vAUDITDATE2',pic:''},{av:'AV30AuditDate3',fld:'vAUDITDATE3',pic:''},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV87Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV21AuditDate_To1',fld:'vAUDITDATE_TO1',pic:''},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV26AuditDate_To2',fld:'vAUDITDATE_TO2',pic:''},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV31AuditDate_To3',fld:'vAUDITDATE_TO3',pic:''},{av:'AV81TFAuditDateTime',fld:'vTFAUDITDATETIME',pic:'99/99/9999 99:99:99.999'},{av:'AV82TFAuditDateTime_To',fld:'vTFAUDITDATETIME_TO',pic:'99/99/9999 99:99:99.999'},{av:'AV44TFAuditDate',fld:'vTFAUDITDATE',pic:''},{av:'AV45TFAuditDate_To',fld:'vTFAUDITDATE_TO',pic:''},{av:'AV49TFAuditTime',fld:'vTFAUDITTIME',pic:'99:99'},{av:'AV50TFAuditTime_To',fld:'vTFAUDITTIME_TO',pic:'99:99'},{av:'AV54TFAuditTableName',fld:'vTFAUDITTABLENAME',pic:''},{av:'AV55TFAuditTableName_Sel',fld:'vTFAUDITTABLENAME_SEL',pic:''},{av:'AV62TFAuditAction',fld:'vTFAUDITACTION',pic:''},{av:'AV63TFAuditAction_Sel',fld:'vTFAUDITACTION_SEL',pic:''},{av:'AV56TFAuditShortDescription',fld:'vTFAUDITSHORTDESCRIPTION',pic:''},{av:'AV57TFAuditShortDescription_Sel',fld:'vTFAUDITSHORTDESCRIPTION_SEL',pic:''},{av:'AV58TFAuditDescription',fld:'vTFAUDITDESCRIPTION',pic:''},{av:'AV59TFAuditDescription_Sel',fld:'vTFAUDITDESCRIPTION_SEL',pic:''},{av:'AV60TFAuditGAMUserName',fld:'vTFAUDITGAMUSERNAME',pic:'@!'},{av:'AV61TFAuditGAMUserName_Sel',fld:'vTFAUDITGAMUSERNAME_SEL',pic:'@!'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV80IsAuthorized_AuditDate',fld:'vISAUTHORIZED_AUDITDATE',pic:'',hsh:true},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true}]");
         setEventMetadata("AUDITDATE_RANGEPICKER1.DATERANGECHANGED",",oparms:[{av:'AV20AuditDate1',fld:'vAUDITDATE1',pic:''},{av:'AV21AuditDate_To1',fld:'vAUDITDATE_TO1',pic:''},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtAuditDateTime_Visible',ctrl:'AUDITDATETIME',prop:'Visible'},{av:'edtAuditDate_Visible',ctrl:'AUDITDATE',prop:'Visible'},{av:'edtAuditTime_Visible',ctrl:'AUDITTIME',prop:'Visible'},{av:'edtAuditTableName_Visible',ctrl:'AUDITTABLENAME',prop:'Visible'},{av:'edtAuditAction_Visible',ctrl:'AUDITACTION',prop:'Visible'},{av:'edtAuditShortDescription_Visible',ctrl:'AUDITSHORTDESCRIPTION',prop:'Visible'},{av:'edtAuditDescription_Visible',ctrl:'AUDITDESCRIPTION',prop:'Visible'},{av:'edtAuditGAMUserName_Visible',ctrl:'AUDITGAMUSERNAME',prop:'Visible'},{av:'AV68GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV69GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV70GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSOPERATOR1.CLICK","{handler:'E265O2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV20AuditDate1',fld:'vAUDITDATE1',pic:''},{av:'AV25AuditDate2',fld:'vAUDITDATE2',pic:''},{av:'AV30AuditDate3',fld:'vAUDITDATE3',pic:''},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV87Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV21AuditDate_To1',fld:'vAUDITDATE_TO1',pic:''},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV26AuditDate_To2',fld:'vAUDITDATE_TO2',pic:''},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV31AuditDate_To3',fld:'vAUDITDATE_TO3',pic:''},{av:'AV81TFAuditDateTime',fld:'vTFAUDITDATETIME',pic:'99/99/9999 99:99:99.999'},{av:'AV82TFAuditDateTime_To',fld:'vTFAUDITDATETIME_TO',pic:'99/99/9999 99:99:99.999'},{av:'AV44TFAuditDate',fld:'vTFAUDITDATE',pic:''},{av:'AV45TFAuditDate_To',fld:'vTFAUDITDATE_TO',pic:''},{av:'AV49TFAuditTime',fld:'vTFAUDITTIME',pic:'99:99'},{av:'AV50TFAuditTime_To',fld:'vTFAUDITTIME_TO',pic:'99:99'},{av:'AV54TFAuditTableName',fld:'vTFAUDITTABLENAME',pic:''},{av:'AV55TFAuditTableName_Sel',fld:'vTFAUDITTABLENAME_SEL',pic:''},{av:'AV62TFAuditAction',fld:'vTFAUDITACTION',pic:''},{av:'AV63TFAuditAction_Sel',fld:'vTFAUDITACTION_SEL',pic:''},{av:'AV56TFAuditShortDescription',fld:'vTFAUDITSHORTDESCRIPTION',pic:''},{av:'AV57TFAuditShortDescription_Sel',fld:'vTFAUDITSHORTDESCRIPTION_SEL',pic:''},{av:'AV58TFAuditDescription',fld:'vTFAUDITDESCRIPTION',pic:''},{av:'AV59TFAuditDescription_Sel',fld:'vTFAUDITDESCRIPTION_SEL',pic:''},{av:'AV60TFAuditGAMUserName',fld:'vTFAUDITGAMUSERNAME',pic:'@!'},{av:'AV61TFAuditGAMUserName_Sel',fld:'vTFAUDITGAMUSERNAME_SEL',pic:'@!'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV80IsAuthorized_AuditDate',fld:'vISAUTHORIZED_AUDITDATE',pic:'',hsh:true},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true}]");
         setEventMetadata("VDYNAMICFILTERSOPERATOR1.CLICK",",oparms:[{av:'AV20AuditDate1',fld:'vAUDITDATE1',pic:''},{av:'AV21AuditDate_To1',fld:'vAUDITDATE_TO1',pic:''},{av:'cellAuditdate_range_cell1_Class',ctrl:'AUDITDATE_RANGE_CELL1',prop:'Class'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtAuditDateTime_Visible',ctrl:'AUDITDATETIME',prop:'Visible'},{av:'edtAuditDate_Visible',ctrl:'AUDITDATE',prop:'Visible'},{av:'edtAuditTime_Visible',ctrl:'AUDITTIME',prop:'Visible'},{av:'edtAuditTableName_Visible',ctrl:'AUDITTABLENAME',prop:'Visible'},{av:'edtAuditAction_Visible',ctrl:'AUDITACTION',prop:'Visible'},{av:'edtAuditShortDescription_Visible',ctrl:'AUDITSHORTDESCRIPTION',prop:'Visible'},{av:'edtAuditDescription_Visible',ctrl:'AUDITDESCRIPTION',prop:'Visible'},{av:'edtAuditGAMUserName_Visible',ctrl:'AUDITGAMUSERNAME',prop:'Visible'},{av:'AV68GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV69GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV70GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("'ADDDYNAMICFILTERS2'","{handler:'E275O2',iparms:[]");
         setEventMetadata("'ADDDYNAMICFILTERS2'",",oparms:[{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'","{handler:'E225O2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV20AuditDate1',fld:'vAUDITDATE1',pic:''},{av:'AV25AuditDate2',fld:'vAUDITDATE2',pic:''},{av:'AV30AuditDate3',fld:'vAUDITDATE3',pic:''},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV87Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV21AuditDate_To1',fld:'vAUDITDATE_TO1',pic:''},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV26AuditDate_To2',fld:'vAUDITDATE_TO2',pic:''},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV31AuditDate_To3',fld:'vAUDITDATE_TO3',pic:''},{av:'AV81TFAuditDateTime',fld:'vTFAUDITDATETIME',pic:'99/99/9999 99:99:99.999'},{av:'AV82TFAuditDateTime_To',fld:'vTFAUDITDATETIME_TO',pic:'99/99/9999 99:99:99.999'},{av:'AV44TFAuditDate',fld:'vTFAUDITDATE',pic:''},{av:'AV45TFAuditDate_To',fld:'vTFAUDITDATE_TO',pic:''},{av:'AV49TFAuditTime',fld:'vTFAUDITTIME',pic:'99:99'},{av:'AV50TFAuditTime_To',fld:'vTFAUDITTIME_TO',pic:'99:99'},{av:'AV54TFAuditTableName',fld:'vTFAUDITTABLENAME',pic:''},{av:'AV55TFAuditTableName_Sel',fld:'vTFAUDITTABLENAME_SEL',pic:''},{av:'AV62TFAuditAction',fld:'vTFAUDITACTION',pic:''},{av:'AV63TFAuditAction_Sel',fld:'vTFAUDITACTION_SEL',pic:''},{av:'AV56TFAuditShortDescription',fld:'vTFAUDITSHORTDESCRIPTION',pic:''},{av:'AV57TFAuditShortDescription_Sel',fld:'vTFAUDITSHORTDESCRIPTION_SEL',pic:''},{av:'AV58TFAuditDescription',fld:'vTFAUDITDESCRIPTION',pic:''},{av:'AV59TFAuditDescription_Sel',fld:'vTFAUDITDESCRIPTION_SEL',pic:''},{av:'AV60TFAuditGAMUserName',fld:'vTFAUDITGAMUSERNAME',pic:'@!'},{av:'AV61TFAuditGAMUserName_Sel',fld:'vTFAUDITGAMUSERNAME_SEL',pic:'@!'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV80IsAuthorized_AuditDate',fld:'vISAUTHORIZED_AUDITDATE',pic:'',hsh:true},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'",",oparms:[{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV25AuditDate2',fld:'vAUDITDATE2',pic:''},{av:'AV26AuditDate_To2',fld:'vAUDITDATE_TO2',pic:''},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV30AuditDate3',fld:'vAUDITDATE3',pic:''},{av:'AV31AuditDate_To3',fld:'vAUDITDATE_TO3',pic:''},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV20AuditDate1',fld:'vAUDITDATE1',pic:''},{av:'AV21AuditDate_To1',fld:'vAUDITDATE_TO1',pic:''},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'tblTablemergeddynamicfiltersauditdate2_Visible',ctrl:'TABLEMERGEDDYNAMICFILTERSAUDITDATE2',prop:'Visible'},{av:'tblTablemergeddynamicfiltersauditdate3_Visible',ctrl:'TABLEMERGEDDYNAMICFILTERSAUDITDATE3',prop:'Visible'},{av:'tblTablemergeddynamicfiltersauditdate1_Visible',ctrl:'TABLEMERGEDDYNAMICFILTERSAUDITDATE1',prop:'Visible'},{av:'cellAuditdate_range_cell2_Class',ctrl:'AUDITDATE_RANGE_CELL2',prop:'Class'},{av:'cellAuditdate_range_cell3_Class',ctrl:'AUDITDATE_RANGE_CELL3',prop:'Class'},{av:'cellAuditdate_range_cell1_Class',ctrl:'AUDITDATE_RANGE_CELL1',prop:'Class'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtAuditDateTime_Visible',ctrl:'AUDITDATETIME',prop:'Visible'},{av:'edtAuditDate_Visible',ctrl:'AUDITDATE',prop:'Visible'},{av:'edtAuditTime_Visible',ctrl:'AUDITTIME',prop:'Visible'},{av:'edtAuditTableName_Visible',ctrl:'AUDITTABLENAME',prop:'Visible'},{av:'edtAuditAction_Visible',ctrl:'AUDITACTION',prop:'Visible'},{av:'edtAuditShortDescription_Visible',ctrl:'AUDITSHORTDESCRIPTION',prop:'Visible'},{av:'edtAuditDescription_Visible',ctrl:'AUDITDESCRIPTION',prop:'Visible'},{av:'edtAuditGAMUserName_Visible',ctrl:'AUDITGAMUSERNAME',prop:'Visible'},{av:'AV68GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV69GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV70GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK","{handler:'E285O2',iparms:[{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK",",oparms:[{av:'tblTablemergeddynamicfiltersauditdate2_Visible',ctrl:'TABLEMERGEDDYNAMICFILTERSAUDITDATE2',prop:'Visible'},{av:'cmbavDynamicfiltersoperator2'},{av:'cellAuditdate_range_cell2_Class',ctrl:'AUDITDATE_RANGE_CELL2',prop:'Class'},{av:'AV25AuditDate2',fld:'vAUDITDATE2',pic:''}]}");
         setEventMetadata("AUDITDATE_RANGEPICKER2.DATERANGECHANGED","{handler:'E175O2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV20AuditDate1',fld:'vAUDITDATE1',pic:''},{av:'AV25AuditDate2',fld:'vAUDITDATE2',pic:''},{av:'AV30AuditDate3',fld:'vAUDITDATE3',pic:''},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV87Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV21AuditDate_To1',fld:'vAUDITDATE_TO1',pic:''},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV26AuditDate_To2',fld:'vAUDITDATE_TO2',pic:''},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV31AuditDate_To3',fld:'vAUDITDATE_TO3',pic:''},{av:'AV81TFAuditDateTime',fld:'vTFAUDITDATETIME',pic:'99/99/9999 99:99:99.999'},{av:'AV82TFAuditDateTime_To',fld:'vTFAUDITDATETIME_TO',pic:'99/99/9999 99:99:99.999'},{av:'AV44TFAuditDate',fld:'vTFAUDITDATE',pic:''},{av:'AV45TFAuditDate_To',fld:'vTFAUDITDATE_TO',pic:''},{av:'AV49TFAuditTime',fld:'vTFAUDITTIME',pic:'99:99'},{av:'AV50TFAuditTime_To',fld:'vTFAUDITTIME_TO',pic:'99:99'},{av:'AV54TFAuditTableName',fld:'vTFAUDITTABLENAME',pic:''},{av:'AV55TFAuditTableName_Sel',fld:'vTFAUDITTABLENAME_SEL',pic:''},{av:'AV62TFAuditAction',fld:'vTFAUDITACTION',pic:''},{av:'AV63TFAuditAction_Sel',fld:'vTFAUDITACTION_SEL',pic:''},{av:'AV56TFAuditShortDescription',fld:'vTFAUDITSHORTDESCRIPTION',pic:''},{av:'AV57TFAuditShortDescription_Sel',fld:'vTFAUDITSHORTDESCRIPTION_SEL',pic:''},{av:'AV58TFAuditDescription',fld:'vTFAUDITDESCRIPTION',pic:''},{av:'AV59TFAuditDescription_Sel',fld:'vTFAUDITDESCRIPTION_SEL',pic:''},{av:'AV60TFAuditGAMUserName',fld:'vTFAUDITGAMUSERNAME',pic:'@!'},{av:'AV61TFAuditGAMUserName_Sel',fld:'vTFAUDITGAMUSERNAME_SEL',pic:'@!'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV80IsAuthorized_AuditDate',fld:'vISAUTHORIZED_AUDITDATE',pic:'',hsh:true},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true}]");
         setEventMetadata("AUDITDATE_RANGEPICKER2.DATERANGECHANGED",",oparms:[{av:'AV25AuditDate2',fld:'vAUDITDATE2',pic:''},{av:'AV26AuditDate_To2',fld:'vAUDITDATE_TO2',pic:''},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtAuditDateTime_Visible',ctrl:'AUDITDATETIME',prop:'Visible'},{av:'edtAuditDate_Visible',ctrl:'AUDITDATE',prop:'Visible'},{av:'edtAuditTime_Visible',ctrl:'AUDITTIME',prop:'Visible'},{av:'edtAuditTableName_Visible',ctrl:'AUDITTABLENAME',prop:'Visible'},{av:'edtAuditAction_Visible',ctrl:'AUDITACTION',prop:'Visible'},{av:'edtAuditShortDescription_Visible',ctrl:'AUDITSHORTDESCRIPTION',prop:'Visible'},{av:'edtAuditDescription_Visible',ctrl:'AUDITDESCRIPTION',prop:'Visible'},{av:'edtAuditGAMUserName_Visible',ctrl:'AUDITGAMUSERNAME',prop:'Visible'},{av:'AV68GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV69GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV70GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSOPERATOR2.CLICK","{handler:'E295O2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV20AuditDate1',fld:'vAUDITDATE1',pic:''},{av:'AV25AuditDate2',fld:'vAUDITDATE2',pic:''},{av:'AV30AuditDate3',fld:'vAUDITDATE3',pic:''},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV87Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV21AuditDate_To1',fld:'vAUDITDATE_TO1',pic:''},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV26AuditDate_To2',fld:'vAUDITDATE_TO2',pic:''},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV31AuditDate_To3',fld:'vAUDITDATE_TO3',pic:''},{av:'AV81TFAuditDateTime',fld:'vTFAUDITDATETIME',pic:'99/99/9999 99:99:99.999'},{av:'AV82TFAuditDateTime_To',fld:'vTFAUDITDATETIME_TO',pic:'99/99/9999 99:99:99.999'},{av:'AV44TFAuditDate',fld:'vTFAUDITDATE',pic:''},{av:'AV45TFAuditDate_To',fld:'vTFAUDITDATE_TO',pic:''},{av:'AV49TFAuditTime',fld:'vTFAUDITTIME',pic:'99:99'},{av:'AV50TFAuditTime_To',fld:'vTFAUDITTIME_TO',pic:'99:99'},{av:'AV54TFAuditTableName',fld:'vTFAUDITTABLENAME',pic:''},{av:'AV55TFAuditTableName_Sel',fld:'vTFAUDITTABLENAME_SEL',pic:''},{av:'AV62TFAuditAction',fld:'vTFAUDITACTION',pic:''},{av:'AV63TFAuditAction_Sel',fld:'vTFAUDITACTION_SEL',pic:''},{av:'AV56TFAuditShortDescription',fld:'vTFAUDITSHORTDESCRIPTION',pic:''},{av:'AV57TFAuditShortDescription_Sel',fld:'vTFAUDITSHORTDESCRIPTION_SEL',pic:''},{av:'AV58TFAuditDescription',fld:'vTFAUDITDESCRIPTION',pic:''},{av:'AV59TFAuditDescription_Sel',fld:'vTFAUDITDESCRIPTION_SEL',pic:''},{av:'AV60TFAuditGAMUserName',fld:'vTFAUDITGAMUSERNAME',pic:'@!'},{av:'AV61TFAuditGAMUserName_Sel',fld:'vTFAUDITGAMUSERNAME_SEL',pic:'@!'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV80IsAuthorized_AuditDate',fld:'vISAUTHORIZED_AUDITDATE',pic:'',hsh:true},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true}]");
         setEventMetadata("VDYNAMICFILTERSOPERATOR2.CLICK",",oparms:[{av:'AV25AuditDate2',fld:'vAUDITDATE2',pic:''},{av:'AV26AuditDate_To2',fld:'vAUDITDATE_TO2',pic:''},{av:'cellAuditdate_range_cell2_Class',ctrl:'AUDITDATE_RANGE_CELL2',prop:'Class'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtAuditDateTime_Visible',ctrl:'AUDITDATETIME',prop:'Visible'},{av:'edtAuditDate_Visible',ctrl:'AUDITDATE',prop:'Visible'},{av:'edtAuditTime_Visible',ctrl:'AUDITTIME',prop:'Visible'},{av:'edtAuditTableName_Visible',ctrl:'AUDITTABLENAME',prop:'Visible'},{av:'edtAuditAction_Visible',ctrl:'AUDITACTION',prop:'Visible'},{av:'edtAuditShortDescription_Visible',ctrl:'AUDITSHORTDESCRIPTION',prop:'Visible'},{av:'edtAuditDescription_Visible',ctrl:'AUDITDESCRIPTION',prop:'Visible'},{av:'edtAuditGAMUserName_Visible',ctrl:'AUDITGAMUSERNAME',prop:'Visible'},{av:'AV68GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV69GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV70GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'","{handler:'E235O2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV20AuditDate1',fld:'vAUDITDATE1',pic:''},{av:'AV25AuditDate2',fld:'vAUDITDATE2',pic:''},{av:'AV30AuditDate3',fld:'vAUDITDATE3',pic:''},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV87Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV21AuditDate_To1',fld:'vAUDITDATE_TO1',pic:''},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV26AuditDate_To2',fld:'vAUDITDATE_TO2',pic:''},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV31AuditDate_To3',fld:'vAUDITDATE_TO3',pic:''},{av:'AV81TFAuditDateTime',fld:'vTFAUDITDATETIME',pic:'99/99/9999 99:99:99.999'},{av:'AV82TFAuditDateTime_To',fld:'vTFAUDITDATETIME_TO',pic:'99/99/9999 99:99:99.999'},{av:'AV44TFAuditDate',fld:'vTFAUDITDATE',pic:''},{av:'AV45TFAuditDate_To',fld:'vTFAUDITDATE_TO',pic:''},{av:'AV49TFAuditTime',fld:'vTFAUDITTIME',pic:'99:99'},{av:'AV50TFAuditTime_To',fld:'vTFAUDITTIME_TO',pic:'99:99'},{av:'AV54TFAuditTableName',fld:'vTFAUDITTABLENAME',pic:''},{av:'AV55TFAuditTableName_Sel',fld:'vTFAUDITTABLENAME_SEL',pic:''},{av:'AV62TFAuditAction',fld:'vTFAUDITACTION',pic:''},{av:'AV63TFAuditAction_Sel',fld:'vTFAUDITACTION_SEL',pic:''},{av:'AV56TFAuditShortDescription',fld:'vTFAUDITSHORTDESCRIPTION',pic:''},{av:'AV57TFAuditShortDescription_Sel',fld:'vTFAUDITSHORTDESCRIPTION_SEL',pic:''},{av:'AV58TFAuditDescription',fld:'vTFAUDITDESCRIPTION',pic:''},{av:'AV59TFAuditDescription_Sel',fld:'vTFAUDITDESCRIPTION_SEL',pic:''},{av:'AV60TFAuditGAMUserName',fld:'vTFAUDITGAMUSERNAME',pic:'@!'},{av:'AV61TFAuditGAMUserName_Sel',fld:'vTFAUDITGAMUSERNAME_SEL',pic:'@!'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV80IsAuthorized_AuditDate',fld:'vISAUTHORIZED_AUDITDATE',pic:'',hsh:true},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'",",oparms:[{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV25AuditDate2',fld:'vAUDITDATE2',pic:''},{av:'AV26AuditDate_To2',fld:'vAUDITDATE_TO2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV30AuditDate3',fld:'vAUDITDATE3',pic:''},{av:'AV31AuditDate_To3',fld:'vAUDITDATE_TO3',pic:''},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV20AuditDate1',fld:'vAUDITDATE1',pic:''},{av:'AV21AuditDate_To1',fld:'vAUDITDATE_TO1',pic:''},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'tblTablemergeddynamicfiltersauditdate2_Visible',ctrl:'TABLEMERGEDDYNAMICFILTERSAUDITDATE2',prop:'Visible'},{av:'tblTablemergeddynamicfiltersauditdate3_Visible',ctrl:'TABLEMERGEDDYNAMICFILTERSAUDITDATE3',prop:'Visible'},{av:'tblTablemergeddynamicfiltersauditdate1_Visible',ctrl:'TABLEMERGEDDYNAMICFILTERSAUDITDATE1',prop:'Visible'},{av:'cellAuditdate_range_cell2_Class',ctrl:'AUDITDATE_RANGE_CELL2',prop:'Class'},{av:'cellAuditdate_range_cell3_Class',ctrl:'AUDITDATE_RANGE_CELL3',prop:'Class'},{av:'cellAuditdate_range_cell1_Class',ctrl:'AUDITDATE_RANGE_CELL1',prop:'Class'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtAuditDateTime_Visible',ctrl:'AUDITDATETIME',prop:'Visible'},{av:'edtAuditDate_Visible',ctrl:'AUDITDATE',prop:'Visible'},{av:'edtAuditTime_Visible',ctrl:'AUDITTIME',prop:'Visible'},{av:'edtAuditTableName_Visible',ctrl:'AUDITTABLENAME',prop:'Visible'},{av:'edtAuditAction_Visible',ctrl:'AUDITACTION',prop:'Visible'},{av:'edtAuditShortDescription_Visible',ctrl:'AUDITSHORTDESCRIPTION',prop:'Visible'},{av:'edtAuditDescription_Visible',ctrl:'AUDITDESCRIPTION',prop:'Visible'},{av:'edtAuditGAMUserName_Visible',ctrl:'AUDITGAMUSERNAME',prop:'Visible'},{av:'AV68GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV69GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV70GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK","{handler:'E305O2',iparms:[{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK",",oparms:[{av:'tblTablemergeddynamicfiltersauditdate3_Visible',ctrl:'TABLEMERGEDDYNAMICFILTERSAUDITDATE3',prop:'Visible'},{av:'cmbavDynamicfiltersoperator3'},{av:'cellAuditdate_range_cell3_Class',ctrl:'AUDITDATE_RANGE_CELL3',prop:'Class'},{av:'AV30AuditDate3',fld:'vAUDITDATE3',pic:''}]}");
         setEventMetadata("AUDITDATE_RANGEPICKER3.DATERANGECHANGED","{handler:'E185O2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV20AuditDate1',fld:'vAUDITDATE1',pic:''},{av:'AV25AuditDate2',fld:'vAUDITDATE2',pic:''},{av:'AV30AuditDate3',fld:'vAUDITDATE3',pic:''},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV87Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV21AuditDate_To1',fld:'vAUDITDATE_TO1',pic:''},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV26AuditDate_To2',fld:'vAUDITDATE_TO2',pic:''},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV31AuditDate_To3',fld:'vAUDITDATE_TO3',pic:''},{av:'AV81TFAuditDateTime',fld:'vTFAUDITDATETIME',pic:'99/99/9999 99:99:99.999'},{av:'AV82TFAuditDateTime_To',fld:'vTFAUDITDATETIME_TO',pic:'99/99/9999 99:99:99.999'},{av:'AV44TFAuditDate',fld:'vTFAUDITDATE',pic:''},{av:'AV45TFAuditDate_To',fld:'vTFAUDITDATE_TO',pic:''},{av:'AV49TFAuditTime',fld:'vTFAUDITTIME',pic:'99:99'},{av:'AV50TFAuditTime_To',fld:'vTFAUDITTIME_TO',pic:'99:99'},{av:'AV54TFAuditTableName',fld:'vTFAUDITTABLENAME',pic:''},{av:'AV55TFAuditTableName_Sel',fld:'vTFAUDITTABLENAME_SEL',pic:''},{av:'AV62TFAuditAction',fld:'vTFAUDITACTION',pic:''},{av:'AV63TFAuditAction_Sel',fld:'vTFAUDITACTION_SEL',pic:''},{av:'AV56TFAuditShortDescription',fld:'vTFAUDITSHORTDESCRIPTION',pic:''},{av:'AV57TFAuditShortDescription_Sel',fld:'vTFAUDITSHORTDESCRIPTION_SEL',pic:''},{av:'AV58TFAuditDescription',fld:'vTFAUDITDESCRIPTION',pic:''},{av:'AV59TFAuditDescription_Sel',fld:'vTFAUDITDESCRIPTION_SEL',pic:''},{av:'AV60TFAuditGAMUserName',fld:'vTFAUDITGAMUSERNAME',pic:'@!'},{av:'AV61TFAuditGAMUserName_Sel',fld:'vTFAUDITGAMUSERNAME_SEL',pic:'@!'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV80IsAuthorized_AuditDate',fld:'vISAUTHORIZED_AUDITDATE',pic:'',hsh:true},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true}]");
         setEventMetadata("AUDITDATE_RANGEPICKER3.DATERANGECHANGED",",oparms:[{av:'AV30AuditDate3',fld:'vAUDITDATE3',pic:''},{av:'AV31AuditDate_To3',fld:'vAUDITDATE_TO3',pic:''},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtAuditDateTime_Visible',ctrl:'AUDITDATETIME',prop:'Visible'},{av:'edtAuditDate_Visible',ctrl:'AUDITDATE',prop:'Visible'},{av:'edtAuditTime_Visible',ctrl:'AUDITTIME',prop:'Visible'},{av:'edtAuditTableName_Visible',ctrl:'AUDITTABLENAME',prop:'Visible'},{av:'edtAuditAction_Visible',ctrl:'AUDITACTION',prop:'Visible'},{av:'edtAuditShortDescription_Visible',ctrl:'AUDITSHORTDESCRIPTION',prop:'Visible'},{av:'edtAuditDescription_Visible',ctrl:'AUDITDESCRIPTION',prop:'Visible'},{av:'edtAuditGAMUserName_Visible',ctrl:'AUDITGAMUSERNAME',prop:'Visible'},{av:'AV68GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV69GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV70GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSOPERATOR3.CLICK","{handler:'E315O2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV20AuditDate1',fld:'vAUDITDATE1',pic:''},{av:'AV25AuditDate2',fld:'vAUDITDATE2',pic:''},{av:'AV30AuditDate3',fld:'vAUDITDATE3',pic:''},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV87Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV21AuditDate_To1',fld:'vAUDITDATE_TO1',pic:''},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV26AuditDate_To2',fld:'vAUDITDATE_TO2',pic:''},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV31AuditDate_To3',fld:'vAUDITDATE_TO3',pic:''},{av:'AV81TFAuditDateTime',fld:'vTFAUDITDATETIME',pic:'99/99/9999 99:99:99.999'},{av:'AV82TFAuditDateTime_To',fld:'vTFAUDITDATETIME_TO',pic:'99/99/9999 99:99:99.999'},{av:'AV44TFAuditDate',fld:'vTFAUDITDATE',pic:''},{av:'AV45TFAuditDate_To',fld:'vTFAUDITDATE_TO',pic:''},{av:'AV49TFAuditTime',fld:'vTFAUDITTIME',pic:'99:99'},{av:'AV50TFAuditTime_To',fld:'vTFAUDITTIME_TO',pic:'99:99'},{av:'AV54TFAuditTableName',fld:'vTFAUDITTABLENAME',pic:''},{av:'AV55TFAuditTableName_Sel',fld:'vTFAUDITTABLENAME_SEL',pic:''},{av:'AV62TFAuditAction',fld:'vTFAUDITACTION',pic:''},{av:'AV63TFAuditAction_Sel',fld:'vTFAUDITACTION_SEL',pic:''},{av:'AV56TFAuditShortDescription',fld:'vTFAUDITSHORTDESCRIPTION',pic:''},{av:'AV57TFAuditShortDescription_Sel',fld:'vTFAUDITSHORTDESCRIPTION_SEL',pic:''},{av:'AV58TFAuditDescription',fld:'vTFAUDITDESCRIPTION',pic:''},{av:'AV59TFAuditDescription_Sel',fld:'vTFAUDITDESCRIPTION_SEL',pic:''},{av:'AV60TFAuditGAMUserName',fld:'vTFAUDITGAMUSERNAME',pic:'@!'},{av:'AV61TFAuditGAMUserName_Sel',fld:'vTFAUDITGAMUSERNAME_SEL',pic:'@!'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV80IsAuthorized_AuditDate',fld:'vISAUTHORIZED_AUDITDATE',pic:'',hsh:true},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true}]");
         setEventMetadata("VDYNAMICFILTERSOPERATOR3.CLICK",",oparms:[{av:'AV30AuditDate3',fld:'vAUDITDATE3',pic:''},{av:'AV31AuditDate_To3',fld:'vAUDITDATE_TO3',pic:''},{av:'cellAuditdate_range_cell3_Class',ctrl:'AUDITDATE_RANGE_CELL3',prop:'Class'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtAuditDateTime_Visible',ctrl:'AUDITDATETIME',prop:'Visible'},{av:'edtAuditDate_Visible',ctrl:'AUDITDATE',prop:'Visible'},{av:'edtAuditTime_Visible',ctrl:'AUDITTIME',prop:'Visible'},{av:'edtAuditTableName_Visible',ctrl:'AUDITTABLENAME',prop:'Visible'},{av:'edtAuditAction_Visible',ctrl:'AUDITACTION',prop:'Visible'},{av:'edtAuditShortDescription_Visible',ctrl:'AUDITSHORTDESCRIPTION',prop:'Visible'},{av:'edtAuditDescription_Visible',ctrl:'AUDITDESCRIPTION',prop:'Visible'},{av:'edtAuditGAMUserName_Visible',ctrl:'AUDITGAMUSERNAME',prop:'Visible'},{av:'AV68GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV69GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV70GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","{handler:'E115O2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV20AuditDate1',fld:'vAUDITDATE1',pic:''},{av:'AV25AuditDate2',fld:'vAUDITDATE2',pic:''},{av:'AV30AuditDate3',fld:'vAUDITDATE3',pic:''},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV87Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV21AuditDate_To1',fld:'vAUDITDATE_TO1',pic:''},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV26AuditDate_To2',fld:'vAUDITDATE_TO2',pic:''},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV31AuditDate_To3',fld:'vAUDITDATE_TO3',pic:''},{av:'AV81TFAuditDateTime',fld:'vTFAUDITDATETIME',pic:'99/99/9999 99:99:99.999'},{av:'AV82TFAuditDateTime_To',fld:'vTFAUDITDATETIME_TO',pic:'99/99/9999 99:99:99.999'},{av:'AV44TFAuditDate',fld:'vTFAUDITDATE',pic:''},{av:'AV45TFAuditDate_To',fld:'vTFAUDITDATE_TO',pic:''},{av:'AV49TFAuditTime',fld:'vTFAUDITTIME',pic:'99:99'},{av:'AV50TFAuditTime_To',fld:'vTFAUDITTIME_TO',pic:'99:99'},{av:'AV54TFAuditTableName',fld:'vTFAUDITTABLENAME',pic:''},{av:'AV55TFAuditTableName_Sel',fld:'vTFAUDITTABLENAME_SEL',pic:''},{av:'AV62TFAuditAction',fld:'vTFAUDITACTION',pic:''},{av:'AV63TFAuditAction_Sel',fld:'vTFAUDITACTION_SEL',pic:''},{av:'AV56TFAuditShortDescription',fld:'vTFAUDITSHORTDESCRIPTION',pic:''},{av:'AV57TFAuditShortDescription_Sel',fld:'vTFAUDITSHORTDESCRIPTION_SEL',pic:''},{av:'AV58TFAuditDescription',fld:'vTFAUDITDESCRIPTION',pic:''},{av:'AV59TFAuditDescription_Sel',fld:'vTFAUDITDESCRIPTION_SEL',pic:''},{av:'AV60TFAuditGAMUserName',fld:'vTFAUDITGAMUSERNAME',pic:'@!'},{av:'AV61TFAuditGAMUserName_Sel',fld:'vTFAUDITGAMUSERNAME_SEL',pic:'@!'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV80IsAuthorized_AuditDate',fld:'vISAUTHORIZED_AUDITDATE',pic:'',hsh:true},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true},{av:'Ddo_managefilters_Activeeventkey',ctrl:'DDO_MANAGEFILTERS',prop:'ActiveEventKey'},{av:'AV83DDO_AuditDateTimeAuxDate',fld:'vDDO_AUDITDATETIMEAUXDATE',pic:''},{av:'AV51DDO_AuditTimeAuxDate',fld:'vDDO_AUDITTIMEAUXDATE',pic:''},{av:'AV84DDO_AuditDateTimeAuxDateTo',fld:'vDDO_AUDITDATETIMEAUXDATETO',pic:''},{av:'AV52DDO_AuditTimeAuxDateTo',fld:'vDDO_AUDITTIMEAUXDATETO',pic:''}]");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",",oparms:[{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV81TFAuditDateTime',fld:'vTFAUDITDATETIME',pic:'99/99/9999 99:99:99.999'},{av:'AV82TFAuditDateTime_To',fld:'vTFAUDITDATETIME_TO',pic:'99/99/9999 99:99:99.999'},{av:'AV44TFAuditDate',fld:'vTFAUDITDATE',pic:''},{av:'AV45TFAuditDate_To',fld:'vTFAUDITDATE_TO',pic:''},{av:'AV49TFAuditTime',fld:'vTFAUDITTIME',pic:'99:99'},{av:'AV50TFAuditTime_To',fld:'vTFAUDITTIME_TO',pic:'99:99'},{av:'AV54TFAuditTableName',fld:'vTFAUDITTABLENAME',pic:''},{av:'AV55TFAuditTableName_Sel',fld:'vTFAUDITTABLENAME_SEL',pic:''},{av:'AV62TFAuditAction',fld:'vTFAUDITACTION',pic:''},{av:'AV63TFAuditAction_Sel',fld:'vTFAUDITACTION_SEL',pic:''},{av:'AV56TFAuditShortDescription',fld:'vTFAUDITSHORTDESCRIPTION',pic:''},{av:'AV57TFAuditShortDescription_Sel',fld:'vTFAUDITSHORTDESCRIPTION_SEL',pic:''},{av:'AV58TFAuditDescription',fld:'vTFAUDITDESCRIPTION',pic:''},{av:'AV59TFAuditDescription_Sel',fld:'vTFAUDITDESCRIPTION_SEL',pic:''},{av:'AV60TFAuditGAMUserName',fld:'vTFAUDITGAMUSERNAME',pic:'@!'},{av:'AV61TFAuditGAMUserName_Sel',fld:'vTFAUDITGAMUSERNAME_SEL',pic:'@!'},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV20AuditDate1',fld:'vAUDITDATE1',pic:''},{av:'AV21AuditDate_To1',fld:'vAUDITDATE_TO1',pic:''},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'AV51DDO_AuditTimeAuxDate',fld:'vDDO_AUDITTIMEAUXDATE',pic:''},{av:'AV52DDO_AuditTimeAuxDateTo',fld:'vDDO_AUDITTIMEAUXDATETO',pic:''},{av:'AV83DDO_AuditDateTimeAuxDate',fld:'vDDO_AUDITDATETIMEAUXDATE',pic:''},{av:'AV84DDO_AuditDateTimeAuxDateTo',fld:'vDDO_AUDITDATETIMEAUXDATETO',pic:''},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV25AuditDate2',fld:'vAUDITDATE2',pic:''},{av:'AV26AuditDate_To2',fld:'vAUDITDATE_TO2',pic:''},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV30AuditDate3',fld:'vAUDITDATE3',pic:''},{av:'AV31AuditDate_To3',fld:'vAUDITDATE_TO3',pic:''},{av:'tblTablemergeddynamicfiltersauditdate1_Visible',ctrl:'TABLEMERGEDDYNAMICFILTERSAUDITDATE1',prop:'Visible'},{av:'tblTablemergeddynamicfiltersauditdate2_Visible',ctrl:'TABLEMERGEDDYNAMICFILTERSAUDITDATE2',prop:'Visible'},{av:'tblTablemergeddynamicfiltersauditdate3_Visible',ctrl:'TABLEMERGEDDYNAMICFILTERSAUDITDATE3',prop:'Visible'},{av:'cellAuditdate_range_cell1_Class',ctrl:'AUDITDATE_RANGE_CELL1',prop:'Class'},{av:'cellAuditdate_range_cell2_Class',ctrl:'AUDITDATE_RANGE_CELL2',prop:'Class'},{av:'cellAuditdate_range_cell3_Class',ctrl:'AUDITDATE_RANGE_CELL3',prop:'Class'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtAuditDateTime_Visible',ctrl:'AUDITDATETIME',prop:'Visible'},{av:'edtAuditDate_Visible',ctrl:'AUDITDATE',prop:'Visible'},{av:'edtAuditTime_Visible',ctrl:'AUDITTIME',prop:'Visible'},{av:'edtAuditTableName_Visible',ctrl:'AUDITTABLENAME',prop:'Visible'},{av:'edtAuditAction_Visible',ctrl:'AUDITACTION',prop:'Visible'},{av:'edtAuditShortDescription_Visible',ctrl:'AUDITSHORTDESCRIPTION',prop:'Visible'},{av:'edtAuditDescription_Visible',ctrl:'AUDITDESCRIPTION',prop:'Visible'},{av:'edtAuditGAMUserName_Visible',ctrl:'AUDITGAMUSERNAME',prop:'Visible'},{av:'AV68GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV69GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV70GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED","{handler:'E145O2',iparms:[{av:'Ddo_agexport_Activeeventkey',ctrl:'DDO_AGEXPORT',prop:'ActiveEventKey'},{av:'AV87Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV55TFAuditTableName_Sel',fld:'vTFAUDITTABLENAME_SEL',pic:''},{av:'AV63TFAuditAction_Sel',fld:'vTFAUDITACTION_SEL',pic:''},{av:'AV57TFAuditShortDescription_Sel',fld:'vTFAUDITSHORTDESCRIPTION_SEL',pic:''},{av:'AV59TFAuditDescription_Sel',fld:'vTFAUDITDESCRIPTION_SEL',pic:''},{av:'AV61TFAuditGAMUserName_Sel',fld:'vTFAUDITGAMUSERNAME_SEL',pic:'@!'},{av:'AV81TFAuditDateTime',fld:'vTFAUDITDATETIME',pic:'99/99/9999 99:99:99.999'},{av:'AV83DDO_AuditDateTimeAuxDate',fld:'vDDO_AUDITDATETIMEAUXDATE',pic:''},{av:'AV44TFAuditDate',fld:'vTFAUDITDATE',pic:''},{av:'AV49TFAuditTime',fld:'vTFAUDITTIME',pic:'99:99'},{av:'AV51DDO_AuditTimeAuxDate',fld:'vDDO_AUDITTIMEAUXDATE',pic:''},{av:'AV54TFAuditTableName',fld:'vTFAUDITTABLENAME',pic:''},{av:'AV62TFAuditAction',fld:'vTFAUDITACTION',pic:''},{av:'AV56TFAuditShortDescription',fld:'vTFAUDITSHORTDESCRIPTION',pic:''},{av:'AV58TFAuditDescription',fld:'vTFAUDITDESCRIPTION',pic:''},{av:'AV60TFAuditGAMUserName',fld:'vTFAUDITGAMUSERNAME',pic:'@!'},{av:'AV82TFAuditDateTime_To',fld:'vTFAUDITDATETIME_TO',pic:'99/99/9999 99:99:99.999'},{av:'AV84DDO_AuditDateTimeAuxDateTo',fld:'vDDO_AUDITDATETIMEAUXDATETO',pic:''},{av:'AV45TFAuditDate_To',fld:'vTFAUDITDATE_TO',pic:''},{av:'AV50TFAuditTime_To',fld:'vTFAUDITTIME_TO',pic:'99:99'},{av:'AV52DDO_AuditTimeAuxDateTo',fld:'vDDO_AUDITTIMEAUXDATETO',pic:''},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'}]");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED",",oparms:[{av:'Innewwindow1_Target',ctrl:'INNEWWINDOW1',prop:'Target'},{av:'Innewwindow1_Height',ctrl:'INNEWWINDOW1',prop:'Height'},{av:'Innewwindow1_Width',ctrl:'INNEWWINDOW1',prop:'Width'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV20AuditDate1',fld:'vAUDITDATE1',pic:''},{av:'AV25AuditDate2',fld:'vAUDITDATE2',pic:''},{av:'AV30AuditDate3',fld:'vAUDITDATE3',pic:''},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV87Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV21AuditDate_To1',fld:'vAUDITDATE_TO1',pic:''},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV26AuditDate_To2',fld:'vAUDITDATE_TO2',pic:''},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV31AuditDate_To3',fld:'vAUDITDATE_TO3',pic:''},{av:'AV81TFAuditDateTime',fld:'vTFAUDITDATETIME',pic:'99/99/9999 99:99:99.999'},{av:'AV82TFAuditDateTime_To',fld:'vTFAUDITDATETIME_TO',pic:'99/99/9999 99:99:99.999'},{av:'AV44TFAuditDate',fld:'vTFAUDITDATE',pic:''},{av:'AV45TFAuditDate_To',fld:'vTFAUDITDATE_TO',pic:''},{av:'AV49TFAuditTime',fld:'vTFAUDITTIME',pic:'99:99'},{av:'AV50TFAuditTime_To',fld:'vTFAUDITTIME_TO',pic:'99:99'},{av:'AV54TFAuditTableName',fld:'vTFAUDITTABLENAME',pic:''},{av:'AV55TFAuditTableName_Sel',fld:'vTFAUDITTABLENAME_SEL',pic:''},{av:'AV62TFAuditAction',fld:'vTFAUDITACTION',pic:''},{av:'AV63TFAuditAction_Sel',fld:'vTFAUDITACTION_SEL',pic:''},{av:'AV56TFAuditShortDescription',fld:'vTFAUDITSHORTDESCRIPTION',pic:''},{av:'AV57TFAuditShortDescription_Sel',fld:'vTFAUDITSHORTDESCRIPTION_SEL',pic:''},{av:'AV58TFAuditDescription',fld:'vTFAUDITDESCRIPTION',pic:''},{av:'AV59TFAuditDescription_Sel',fld:'vTFAUDITDESCRIPTION_SEL',pic:''},{av:'AV60TFAuditGAMUserName',fld:'vTFAUDITGAMUSERNAME',pic:'@!'},{av:'AV61TFAuditGAMUserName_Sel',fld:'vTFAUDITGAMUSERNAME_SEL',pic:'@!'},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV80IsAuthorized_AuditDate',fld:'vISAUTHORIZED_AUDITDATE',pic:'',hsh:true},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'AV51DDO_AuditTimeAuxDate',fld:'vDDO_AUDITTIMEAUXDATE',pic:''},{av:'AV52DDO_AuditTimeAuxDateTo',fld:'vDDO_AUDITTIMEAUXDATETO',pic:''},{av:'AV83DDO_AuditDateTimeAuxDate',fld:'vDDO_AUDITDATETIMEAUXDATE',pic:''},{av:'AV84DDO_AuditDateTimeAuxDateTo',fld:'vDDO_AUDITDATETIMEAUXDATETO',pic:''},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'tblTablemergeddynamicfiltersauditdate1_Visible',ctrl:'TABLEMERGEDDYNAMICFILTERSAUDITDATE1',prop:'Visible'},{av:'tblTablemergeddynamicfiltersauditdate2_Visible',ctrl:'TABLEMERGEDDYNAMICFILTERSAUDITDATE2',prop:'Visible'},{av:'tblTablemergeddynamicfiltersauditdate3_Visible',ctrl:'TABLEMERGEDDYNAMICFILTERSAUDITDATE3',prop:'Visible'},{av:'cellAuditdate_range_cell1_Class',ctrl:'AUDITDATE_RANGE_CELL1',prop:'Class'},{av:'cellAuditdate_range_cell2_Class',ctrl:'AUDITDATE_RANGE_CELL2',prop:'Class'},{av:'cellAuditdate_range_cell3_Class',ctrl:'AUDITDATE_RANGE_CELL3',prop:'Class'}]}");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT","{handler:'E155O2',iparms:[]");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT",",oparms:[{ctrl:'WWPAUX_WC'}]}");
         setEventMetadata("VDETAILWEBCOMPONENT.CLICK","{handler:'E355O2',iparms:[{av:'A493AuditID',fld:'AUDITID',pic:'',hsh:true}]");
         setEventMetadata("VDETAILWEBCOMPONENT.CLICK",",oparms:[{ctrl:'GRID_DWC'}]}");
         setEventMetadata("NULL","{handler:'Valid_Auditgamusername',iparms:[]");
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
      }

      public override void initialize( )
      {
         Gridpaginationbar_Selectedpage = "";
         Ddo_grid_Activeeventkey = "";
         Ddo_grid_Selectedvalue_get = "";
         Ddo_grid_Filteredtextto_get = "";
         Ddo_grid_Filteredtext_get = "";
         Ddo_grid_Selectedcolumn = "";
         Ddo_gridcolumnsselector_Columnsselectorvalues = "";
         Ddo_managefilters_Activeeventkey = "";
         Ddo_agexport_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV17FilterFullText = "";
         AV18DynamicFiltersSelector1 = "";
         AV23DynamicFiltersSelector2 = "";
         AV28DynamicFiltersSelector3 = "";
         AV20AuditDate1 = DateTime.MinValue;
         AV25AuditDate2 = DateTime.MinValue;
         AV30AuditDate3 = DateTime.MinValue;
         AV38ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV87Pgmname = "";
         AV21AuditDate_To1 = DateTime.MinValue;
         AV26AuditDate_To2 = DateTime.MinValue;
         AV31AuditDate_To3 = DateTime.MinValue;
         AV81TFAuditDateTime = (DateTime)(DateTime.MinValue);
         AV82TFAuditDateTime_To = (DateTime)(DateTime.MinValue);
         AV44TFAuditDate = DateTime.MinValue;
         AV45TFAuditDate_To = DateTime.MinValue;
         AV49TFAuditTime = (DateTime)(DateTime.MinValue);
         AV50TFAuditTime_To = (DateTime)(DateTime.MinValue);
         AV54TFAuditTableName = "";
         AV55TFAuditTableName_Sel = "";
         AV62TFAuditAction = "";
         AV63TFAuditAction_Sel = "";
         AV56TFAuditShortDescription = "";
         AV57TFAuditShortDescription_Sel = "";
         AV58TFAuditDescription = "";
         AV59TFAuditDescription_Sel = "";
         AV60TFAuditGAMUserName = "";
         AV61TFAuditGAMUserName_Sel = "";
         AV11GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         Gx_date = DateTime.MinValue;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV41ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV70GridAppliedFilters = "";
         AV74AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV64DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV83DDO_AuditDateTimeAuxDate = DateTime.MinValue;
         AV84DDO_AuditDateTimeAuxDateTo = DateTime.MinValue;
         AV46DDO_AuditDateAuxDate = DateTime.MinValue;
         AV47DDO_AuditDateAuxDateTo = DateTime.MinValue;
         AV51DDO_AuditTimeAuxDate = DateTime.MinValue;
         AV52DDO_AuditTimeAuxDateTo = DateTime.MinValue;
         Ddo_agexport_Caption = "";
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Filteredtextto_set = "";
         Ddo_grid_Selectedvalue_set = "";
         Ddo_grid_Gamoauthtoken = "";
         Ddo_grid_Sortedstatus = "";
         Ddo_gridcolumnsselector_Gridinternalname = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtnagexport_Jsonclick = "";
         bttBtneditcolumns_Jsonclick = "";
         bttBtnsubscriptions_Jsonclick = "";
         lblDynamicfiltersprefix1_Jsonclick = "";
         lblDynamicfiltersmiddle1_Jsonclick = "";
         lblDynamicfiltersprefix2_Jsonclick = "";
         lblDynamicfiltersmiddle2_Jsonclick = "";
         lblDynamicfiltersprefix3_Jsonclick = "";
         lblDynamicfiltersmiddle3_Jsonclick = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridpaginationbar = new GXUserControl();
         WebComp_Grid_dwc_Component = "";
         OldGrid_dwc = "";
         ucDdo_agexport = new GXUserControl();
         ucDdc_subscriptions = new GXUserControl();
         ucAuditdate_rangepicker1 = new GXUserControl();
         ucAuditdate_rangepicker2 = new GXUserControl();
         ucAuditdate_rangepicker3 = new GXUserControl();
         lblJsdynamicfilters_Jsonclick = "";
         ucDdo_grid = new GXUserControl();
         ucInnewwindow1 = new GXUserControl();
         ucDdo_gridcolumnsselector = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         WebComp_Wwpaux_wc_Component = "";
         OldWwpaux_wc = "";
         AV85DDO_AuditDateTimeAuxDateText = "";
         ucTfauditdatetime_rangepicker = new GXUserControl();
         AV48DDO_AuditDateAuxDateText = "";
         ucTfauditdate_rangepicker = new GXUserControl();
         AV53DDO_AuditTimeAuxDateText = "";
         ucTfaudittime_rangepicker = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV86DetailWebComponent = "";
         A493AuditID = Guid.Empty;
         A496AuditDateTime = (DateTime)(DateTime.MinValue);
         A494AuditDate = DateTime.MinValue;
         A495AuditTime = (DateTime)(DateTime.MinValue);
         A497AuditTableName = "";
         A502AuditAction = "";
         A499AuditShortDescription = "";
         A498AuditDescription = "";
         A501AuditGAMUserName = "";
         scmdbuf = "";
         lV88Core_auditwwds_1_filterfulltext = "";
         lV109Core_auditwwds_22_tfaudittablename = "";
         lV111Core_auditwwds_24_tfauditaction = "";
         lV113Core_auditwwds_26_tfauditshortdescription = "";
         lV115Core_auditwwds_28_tfauditdescription = "";
         lV117Core_auditwwds_30_tfauditgamusername = "";
         AV88Core_auditwwds_1_filterfulltext = "";
         AV89Core_auditwwds_2_dynamicfiltersselector1 = "";
         AV91Core_auditwwds_4_auditdate1 = DateTime.MinValue;
         AV92Core_auditwwds_5_auditdate_to1 = DateTime.MinValue;
         AV94Core_auditwwds_7_dynamicfiltersselector2 = "";
         AV96Core_auditwwds_9_auditdate2 = DateTime.MinValue;
         AV97Core_auditwwds_10_auditdate_to2 = DateTime.MinValue;
         AV99Core_auditwwds_12_dynamicfiltersselector3 = "";
         AV101Core_auditwwds_14_auditdate3 = DateTime.MinValue;
         AV102Core_auditwwds_15_auditdate_to3 = DateTime.MinValue;
         AV103Core_auditwwds_16_tfauditdatetime = (DateTime)(DateTime.MinValue);
         AV104Core_auditwwds_17_tfauditdatetime_to = (DateTime)(DateTime.MinValue);
         AV105Core_auditwwds_18_tfauditdate = DateTime.MinValue;
         AV106Core_auditwwds_19_tfauditdate_to = DateTime.MinValue;
         AV107Core_auditwwds_20_tfaudittime = (DateTime)(DateTime.MinValue);
         AV108Core_auditwwds_21_tfaudittime_to = (DateTime)(DateTime.MinValue);
         AV110Core_auditwwds_23_tfaudittablename_sel = "";
         AV109Core_auditwwds_22_tfaudittablename = "";
         AV112Core_auditwwds_25_tfauditaction_sel = "";
         AV111Core_auditwwds_24_tfauditaction = "";
         AV114Core_auditwwds_27_tfauditshortdescription_sel = "";
         AV113Core_auditwwds_26_tfauditshortdescription = "";
         AV116Core_auditwwds_29_tfauditdescription_sel = "";
         AV115Core_auditwwds_28_tfauditdescription = "";
         AV118Core_auditwwds_31_tfauditgamusername_sel = "";
         AV117Core_auditwwds_30_tfauditgamusername = "";
         H005O2_A501AuditGAMUserName = new string[] {""} ;
         H005O2_A498AuditDescription = new string[] {""} ;
         H005O2_A499AuditShortDescription = new string[] {""} ;
         H005O2_A502AuditAction = new string[] {""} ;
         H005O2_A497AuditTableName = new string[] {""} ;
         H005O2_A495AuditTime = new DateTime[] {DateTime.MinValue} ;
         H005O2_A494AuditDate = new DateTime[] {DateTime.MinValue} ;
         H005O2_A496AuditDateTime = new DateTime[] {DateTime.MinValue} ;
         H005O2_A493AuditID = new Guid[] {Guid.Empty} ;
         H005O3_AGRID_nRecordCount = new long[1] ;
         AV77AuditDate_RangeText1 = "";
         AV78AuditDate_RangeText2 = "";
         AV79AuditDate_RangeText3 = "";
         AV8HTTPRequest = new GxHttpRequest( context);
         imgAdddynamicfilters1_Jsonclick = "";
         imgRemovedynamicfilters1_Jsonclick = "";
         imgAdddynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters3_Jsonclick = "";
         AV75AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV65GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV66GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV40Session = context.GetSession();
         AV36ColumnsSelectorXML = "";
         GXEncryptionTmp = "";
         GridRow = new GXWebRow();
         AV42ManageFiltersXml = "";
         AV37UserCustomValue = "";
         AV39ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV12GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char8 = "";
         GXt_char7 = "";
         GXt_char6 = "";
         GXt_char5 = "";
         GXt_char3 = "";
         AV13GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV34ExcelFilename = "";
         AV35ErrorMessage = "";
         imgRemovedynamicfilters3_gximage = "";
         sImgUrl = "";
         imgAdddynamicfilters2_gximage = "";
         imgRemovedynamicfilters2_gximage = "";
         imgAdddynamicfilters1_gximage = "";
         imgRemovedynamicfilters1_gximage = "";
         ucDdo_managefilters = new GXUserControl();
         Ddo_managefilters_Caption = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.auditww__default(),
            new Object[][] {
                new Object[] {
               H005O2_A501AuditGAMUserName, H005O2_A498AuditDescription, H005O2_A499AuditShortDescription, H005O2_A502AuditAction, H005O2_A497AuditTableName, H005O2_A495AuditTime, H005O2_A494AuditDate, H005O2_A496AuditDateTime, H005O2_A493AuditID
               }
               , new Object[] {
               H005O3_AGRID_nRecordCount
               }
            }
         );
         WebComp_Grid_dwc = new GeneXus.Http.GXNullWebComponent();
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         Gx_date = DateTimeUtil.Today( context);
         AV87Pgmname = "core.AuditWW";
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
         AV87Pgmname = "core.AuditWW";
         edtavDetailwebcomponent_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV19DynamicFiltersOperator1 ;
      private short AV24DynamicFiltersOperator2 ;
      private short AV29DynamicFiltersOperator3 ;
      private short AV43ManageFiltersExecutionStep ;
      private short AV14OrderedBy ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short AV90Core_auditwwds_3_dynamicfiltersoperator1 ;
      private short AV95Core_auditwwds_8_dynamicfiltersoperator2 ;
      private short AV100Core_auditwwds_13_dynamicfiltersoperator3 ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_118 ;
      private int nGXsfl_118_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int bttBtnsubscriptions_Visible ;
      private int subGrid_Islastpage ;
      private int edtavDetailwebcomponent_Enabled ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtAuditDateTime_Visible ;
      private int edtAuditDate_Visible ;
      private int edtAuditTime_Visible ;
      private int edtAuditTableName_Visible ;
      private int edtAuditAction_Visible ;
      private int edtAuditShortDescription_Visible ;
      private int edtAuditDescription_Visible ;
      private int edtAuditGAMUserName_Visible ;
      private int AV67PageToGo ;
      private int imgAdddynamicfilters1_Visible ;
      private int imgRemovedynamicfilters1_Visible ;
      private int imgAdddynamicfilters2_Visible ;
      private int imgRemovedynamicfilters2_Visible ;
      private int tblTablemergeddynamicfiltersauditdate1_Visible ;
      private int tblTablemergeddynamicfiltersauditdate2_Visible ;
      private int tblTablemergeddynamicfiltersauditdate3_Visible ;
      private int AV120GXV1 ;
      private int edtavAuditdate_rangetext3_Enabled ;
      private int edtavAuditdate_rangetext2_Enabled ;
      private int edtavAuditdate_rangetext1_Enabled ;
      private int edtavFilterfulltext_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int edtavDetailwebcomponent_Visible ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV68GridCurrentPage ;
      private long AV69GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_gridcolumnsselector_Columnsselectorvalues ;
      private string Ddo_managefilters_Activeeventkey ;
      private string Ddo_agexport_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_118_idx="0001" ;
      private string AV87Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Ddo_managefilters_Icontype ;
      private string Ddo_managefilters_Icon ;
      private string Ddo_managefilters_Tooltip ;
      private string Ddo_managefilters_Cls ;
      private string Gridpaginationbar_Class ;
      private string Gridpaginationbar_Pagingbuttonsposition ;
      private string Gridpaginationbar_Pagingcaptionposition ;
      private string Gridpaginationbar_Emptygridclass ;
      private string Gridpaginationbar_Rowsperpageoptions ;
      private string Gridpaginationbar_First ;
      private string Gridpaginationbar_Previous ;
      private string Gridpaginationbar_Next ;
      private string Gridpaginationbar_Last ;
      private string Gridpaginationbar_Caption ;
      private string Gridpaginationbar_Emptygridcaption ;
      private string Gridpaginationbar_Rowsperpagecaption ;
      private string Ddo_agexport_Icontype ;
      private string Ddo_agexport_Icon ;
      private string Ddo_agexport_Caption ;
      private string Ddo_agexport_Cls ;
      private string Ddo_agexport_Titlecontrolidtoreplace ;
      private string Ddc_subscriptions_Icontype ;
      private string Ddc_subscriptions_Icon ;
      private string Ddc_subscriptions_Caption ;
      private string Ddc_subscriptions_Tooltip ;
      private string Ddc_subscriptions_Cls ;
      private string Ddc_subscriptions_Titlecontrolidtoreplace ;
      private string Ddo_grid_Caption ;
      private string Ddo_grid_Filteredtext_set ;
      private string Ddo_grid_Filteredtextto_set ;
      private string Ddo_grid_Selectedvalue_set ;
      private string Ddo_grid_Gamoauthtoken ;
      private string Ddo_grid_Gridinternalname ;
      private string Ddo_grid_Columnids ;
      private string Ddo_grid_Columnssortvalues ;
      private string Ddo_grid_Includesortasc ;
      private string Ddo_grid_Fixable ;
      private string Ddo_grid_Sortedstatus ;
      private string Ddo_grid_Includefilter ;
      private string Ddo_grid_Filtertype ;
      private string Ddo_grid_Filterisrange ;
      private string Ddo_grid_Includedatalist ;
      private string Ddo_grid_Datalisttype ;
      private string Ddo_grid_Datalistproc ;
      private string Innewwindow1_Width ;
      private string Innewwindow1_Height ;
      private string Innewwindow1_Target ;
      private string Ddo_gridcolumnsselector_Icontype ;
      private string Ddo_gridcolumnsselector_Icon ;
      private string Ddo_gridcolumnsselector_Caption ;
      private string Ddo_gridcolumnsselector_Tooltip ;
      private string Ddo_gridcolumnsselector_Cls ;
      private string Ddo_gridcolumnsselector_Dropdownoptionstype ;
      private string Ddo_gridcolumnsselector_Gridinternalname ;
      private string Ddo_gridcolumnsselector_Titlecontrolidtoreplace ;
      private string Grid_empowerer_Gridinternalname ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string divTableheader_Internalname ;
      private string divTableheadercontent_Internalname ;
      private string divTableactions_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtnagexport_Internalname ;
      private string bttBtnagexport_Jsonclick ;
      private string bttBtneditcolumns_Internalname ;
      private string bttBtneditcolumns_Jsonclick ;
      private string bttBtnsubscriptions_Internalname ;
      private string bttBtnsubscriptions_Jsonclick ;
      private string divAdvancedfilterscontainer_Internalname ;
      private string divTabledynamicfilters_Internalname ;
      private string divTabledynamicfiltersrow1_Internalname ;
      private string lblDynamicfiltersprefix1_Internalname ;
      private string lblDynamicfiltersprefix1_Jsonclick ;
      private string cmbavDynamicfiltersselector1_Internalname ;
      private string cmbavDynamicfiltersselector1_Jsonclick ;
      private string lblDynamicfiltersmiddle1_Internalname ;
      private string lblDynamicfiltersmiddle1_Jsonclick ;
      private string divTabledynamicfiltersrow2_Internalname ;
      private string lblDynamicfiltersprefix2_Internalname ;
      private string lblDynamicfiltersprefix2_Jsonclick ;
      private string cmbavDynamicfiltersselector2_Internalname ;
      private string cmbavDynamicfiltersselector2_Jsonclick ;
      private string lblDynamicfiltersmiddle2_Internalname ;
      private string lblDynamicfiltersmiddle2_Jsonclick ;
      private string divTabledynamicfiltersrow3_Internalname ;
      private string lblDynamicfiltersprefix3_Internalname ;
      private string lblDynamicfiltersprefix3_Jsonclick ;
      private string cmbavDynamicfiltersselector3_Internalname ;
      private string cmbavDynamicfiltersselector3_Jsonclick ;
      private string lblDynamicfiltersmiddle3_Internalname ;
      private string lblDynamicfiltersmiddle3_Jsonclick ;
      private string divGridtablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string Gridpaginationbar_Internalname ;
      private string divCell_grid_dwc_Internalname ;
      private string divCell_grid_dwc_Class ;
      private string WebComp_Grid_dwc_Component ;
      private string OldGrid_dwc ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Ddo_agexport_Internalname ;
      private string Ddc_subscriptions_Internalname ;
      private string Auditdate_rangepicker1_Internalname ;
      private string Auditdate_rangepicker2_Internalname ;
      private string Auditdate_rangepicker3_Internalname ;
      private string lblJsdynamicfilters_Internalname ;
      private string lblJsdynamicfilters_Caption ;
      private string lblJsdynamicfilters_Jsonclick ;
      private string Ddo_grid_Internalname ;
      private string Innewwindow1_Internalname ;
      private string Ddo_gridcolumnsselector_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string divDiv_wwpauxwc_Internalname ;
      private string WebComp_Wwpaux_wc_Component ;
      private string OldWwpaux_wc ;
      private string divDdo_auditdatetimeauxdates_Internalname ;
      private string edtavDdo_auditdatetimeauxdatetext_Internalname ;
      private string edtavDdo_auditdatetimeauxdatetext_Jsonclick ;
      private string Tfauditdatetime_rangepicker_Internalname ;
      private string divDdo_auditdateauxdates_Internalname ;
      private string edtavDdo_auditdateauxdatetext_Internalname ;
      private string edtavDdo_auditdateauxdatetext_Jsonclick ;
      private string Tfauditdate_rangepicker_Internalname ;
      private string divDdo_audittimeauxdates_Internalname ;
      private string edtavDdo_audittimeauxdatetext_Internalname ;
      private string edtavDdo_audittimeauxdatetext_Jsonclick ;
      private string Tfaudittime_rangepicker_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV86DetailWebComponent ;
      private string edtavDetailwebcomponent_Internalname ;
      private string edtAuditID_Internalname ;
      private string edtAuditDateTime_Internalname ;
      private string edtAuditDate_Internalname ;
      private string edtAuditTime_Internalname ;
      private string edtAuditTableName_Internalname ;
      private string edtAuditAction_Internalname ;
      private string edtAuditShortDescription_Internalname ;
      private string edtAuditDescription_Internalname ;
      private string edtAuditGAMUserName_Internalname ;
      private string edtavFilterfulltext_Internalname ;
      private string cmbavDynamicfiltersoperator1_Internalname ;
      private string cmbavDynamicfiltersoperator2_Internalname ;
      private string cmbavDynamicfiltersoperator3_Internalname ;
      private string scmdbuf ;
      private string edtavAuditdate_rangetext1_Internalname ;
      private string edtavAuditdate_rangetext2_Internalname ;
      private string edtavAuditdate_rangetext3_Internalname ;
      private string imgAdddynamicfilters1_Jsonclick ;
      private string imgAdddynamicfilters1_Internalname ;
      private string imgRemovedynamicfilters1_Jsonclick ;
      private string imgRemovedynamicfilters1_Internalname ;
      private string imgAdddynamicfilters2_Jsonclick ;
      private string imgAdddynamicfilters2_Internalname ;
      private string imgRemovedynamicfilters2_Jsonclick ;
      private string imgRemovedynamicfilters2_Internalname ;
      private string imgRemovedynamicfilters3_Jsonclick ;
      private string imgRemovedynamicfilters3_Internalname ;
      private string edtAuditDate_Link ;
      private string GXEncryptionTmp ;
      private string tblTablemergeddynamicfiltersauditdate1_Internalname ;
      private string cellAuditdate_range_cell1_Class ;
      private string cellAuditdate_range_cell1_Internalname ;
      private string tblTablemergeddynamicfiltersauditdate2_Internalname ;
      private string cellAuditdate_range_cell2_Class ;
      private string cellAuditdate_range_cell2_Internalname ;
      private string tblTablemergeddynamicfiltersauditdate3_Internalname ;
      private string cellAuditdate_range_cell3_Class ;
      private string cellAuditdate_range_cell3_Internalname ;
      private string GXt_char8 ;
      private string GXt_char7 ;
      private string GXt_char6 ;
      private string GXt_char5 ;
      private string GXt_char3 ;
      private string tblTablemergeddynamicfilters3_Internalname ;
      private string cmbavDynamicfiltersoperator3_Jsonclick ;
      private string cellFilter_auditdate3_cell_Internalname ;
      private string cellDynamicfilters_removefilter3_cell_Internalname ;
      private string imgRemovedynamicfilters3_gximage ;
      private string sImgUrl ;
      private string edtavAuditdate_rangetext3_Jsonclick ;
      private string tblTablemergeddynamicfilters2_Internalname ;
      private string cmbavDynamicfiltersoperator2_Jsonclick ;
      private string cellFilter_auditdate2_cell_Internalname ;
      private string cellDynamicfilters_addfilter2_cell_Internalname ;
      private string imgAdddynamicfilters2_gximage ;
      private string cellDynamicfilters_removefilter2_cell_Internalname ;
      private string imgRemovedynamicfilters2_gximage ;
      private string edtavAuditdate_rangetext2_Jsonclick ;
      private string tblTablemergeddynamicfilters1_Internalname ;
      private string cmbavDynamicfiltersoperator1_Jsonclick ;
      private string cellFilter_auditdate1_cell_Internalname ;
      private string cellDynamicfilters_addfilter1_cell_Internalname ;
      private string imgAdddynamicfilters1_gximage ;
      private string cellDynamicfilters_removefilter1_cell_Internalname ;
      private string imgRemovedynamicfilters1_gximage ;
      private string edtavAuditdate_rangetext1_Jsonclick ;
      private string tblTablerightheader_Internalname ;
      private string Ddo_managefilters_Caption ;
      private string Ddo_managefilters_Internalname ;
      private string tblTablefilters_Internalname ;
      private string edtavFilterfulltext_Jsonclick ;
      private string sGXsfl_118_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavDetailwebcomponent_Jsonclick ;
      private string edtAuditID_Jsonclick ;
      private string edtAuditDateTime_Jsonclick ;
      private string edtAuditDate_Jsonclick ;
      private string edtAuditTime_Jsonclick ;
      private string edtAuditTableName_Jsonclick ;
      private string edtAuditAction_Jsonclick ;
      private string edtAuditShortDescription_Jsonclick ;
      private string edtAuditDescription_Jsonclick ;
      private string edtAuditGAMUserName_Jsonclick ;
      private string subGrid_Header ;
      private DateTime AV81TFAuditDateTime ;
      private DateTime AV82TFAuditDateTime_To ;
      private DateTime AV49TFAuditTime ;
      private DateTime AV50TFAuditTime_To ;
      private DateTime A496AuditDateTime ;
      private DateTime A495AuditTime ;
      private DateTime AV103Core_auditwwds_16_tfauditdatetime ;
      private DateTime AV104Core_auditwwds_17_tfauditdatetime_to ;
      private DateTime AV107Core_auditwwds_20_tfaudittime ;
      private DateTime AV108Core_auditwwds_21_tfaudittime_to ;
      private DateTime AV20AuditDate1 ;
      private DateTime AV25AuditDate2 ;
      private DateTime AV30AuditDate3 ;
      private DateTime AV21AuditDate_To1 ;
      private DateTime AV26AuditDate_To2 ;
      private DateTime AV31AuditDate_To3 ;
      private DateTime AV44TFAuditDate ;
      private DateTime AV45TFAuditDate_To ;
      private DateTime Gx_date ;
      private DateTime AV83DDO_AuditDateTimeAuxDate ;
      private DateTime AV84DDO_AuditDateTimeAuxDateTo ;
      private DateTime AV46DDO_AuditDateAuxDate ;
      private DateTime AV47DDO_AuditDateAuxDateTo ;
      private DateTime AV51DDO_AuditTimeAuxDate ;
      private DateTime AV52DDO_AuditTimeAuxDateTo ;
      private DateTime A494AuditDate ;
      private DateTime AV91Core_auditwwds_4_auditdate1 ;
      private DateTime AV92Core_auditwwds_5_auditdate_to1 ;
      private DateTime AV96Core_auditwwds_9_auditdate2 ;
      private DateTime AV97Core_auditwwds_10_auditdate_to2 ;
      private DateTime AV101Core_auditwwds_14_auditdate3 ;
      private DateTime AV102Core_auditwwds_15_auditdate_to3 ;
      private DateTime AV105Core_auditwwds_18_tfauditdate ;
      private DateTime AV106Core_auditwwds_19_tfauditdate_to ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV22DynamicFiltersEnabled2 ;
      private bool AV27DynamicFiltersEnabled3 ;
      private bool AV15OrderedDsc ;
      private bool AV33DynamicFiltersIgnoreFirst ;
      private bool AV32DynamicFiltersRemoving ;
      private bool AV80IsAuthorized_AuditDate ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool Grid_empowerer_Hascolumnsselector ;
      private bool wbLoad ;
      private bool bGXsfl_118_Refreshing=false ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool AV93Core_auditwwds_6_dynamicfiltersenabled2 ;
      private bool AV98Core_auditwwds_11_dynamicfiltersenabled3 ;
      private bool returnInSub ;
      private bool GXt_boolean1 ;
      private bool gx_refresh_fired ;
      private bool bDynCreated_Wwpaux_wc ;
      private bool bDynCreated_Grid_dwc ;
      private string A498AuditDescription ;
      private string AV36ColumnsSelectorXML ;
      private string AV42ManageFiltersXml ;
      private string AV37UserCustomValue ;
      private string AV17FilterFullText ;
      private string AV18DynamicFiltersSelector1 ;
      private string AV23DynamicFiltersSelector2 ;
      private string AV28DynamicFiltersSelector3 ;
      private string AV54TFAuditTableName ;
      private string AV55TFAuditTableName_Sel ;
      private string AV62TFAuditAction ;
      private string AV63TFAuditAction_Sel ;
      private string AV56TFAuditShortDescription ;
      private string AV57TFAuditShortDescription_Sel ;
      private string AV58TFAuditDescription ;
      private string AV59TFAuditDescription_Sel ;
      private string AV60TFAuditGAMUserName ;
      private string AV61TFAuditGAMUserName_Sel ;
      private string AV70GridAppliedFilters ;
      private string AV85DDO_AuditDateTimeAuxDateText ;
      private string AV48DDO_AuditDateAuxDateText ;
      private string AV53DDO_AuditTimeAuxDateText ;
      private string A497AuditTableName ;
      private string A502AuditAction ;
      private string A499AuditShortDescription ;
      private string A501AuditGAMUserName ;
      private string lV88Core_auditwwds_1_filterfulltext ;
      private string lV109Core_auditwwds_22_tfaudittablename ;
      private string lV111Core_auditwwds_24_tfauditaction ;
      private string lV113Core_auditwwds_26_tfauditshortdescription ;
      private string lV115Core_auditwwds_28_tfauditdescription ;
      private string lV117Core_auditwwds_30_tfauditgamusername ;
      private string AV88Core_auditwwds_1_filterfulltext ;
      private string AV89Core_auditwwds_2_dynamicfiltersselector1 ;
      private string AV94Core_auditwwds_7_dynamicfiltersselector2 ;
      private string AV99Core_auditwwds_12_dynamicfiltersselector3 ;
      private string AV110Core_auditwwds_23_tfaudittablename_sel ;
      private string AV109Core_auditwwds_22_tfaudittablename ;
      private string AV112Core_auditwwds_25_tfauditaction_sel ;
      private string AV111Core_auditwwds_24_tfauditaction ;
      private string AV114Core_auditwwds_27_tfauditshortdescription_sel ;
      private string AV113Core_auditwwds_26_tfauditshortdescription ;
      private string AV116Core_auditwwds_29_tfauditdescription_sel ;
      private string AV115Core_auditwwds_28_tfauditdescription ;
      private string AV118Core_auditwwds_31_tfauditgamusername_sel ;
      private string AV117Core_auditwwds_30_tfauditgamusername ;
      private string AV77AuditDate_RangeText1 ;
      private string AV78AuditDate_RangeText2 ;
      private string AV79AuditDate_RangeText3 ;
      private string AV34ExcelFilename ;
      private string AV35ErrorMessage ;
      private Guid A493AuditID ;
      private IGxSession AV40Session ;
      private GXWebComponent WebComp_Grid_dwc ;
      private GXWebComponent WebComp_Wwpaux_wc ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_agexport ;
      private GXUserControl ucDdc_subscriptions ;
      private GXUserControl ucAuditdate_rangepicker1 ;
      private GXUserControl ucAuditdate_rangepicker2 ;
      private GXUserControl ucAuditdate_rangepicker3 ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucInnewwindow1 ;
      private GXUserControl ucDdo_gridcolumnsselector ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucTfauditdatetime_rangepicker ;
      private GXUserControl ucTfauditdate_rangepicker ;
      private GXUserControl ucTfaudittime_rangepicker ;
      private GXUserControl ucDdo_managefilters ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavDynamicfiltersselector1 ;
      private GXCombobox cmbavDynamicfiltersoperator1 ;
      private GXCombobox cmbavDynamicfiltersselector2 ;
      private GXCombobox cmbavDynamicfiltersoperator2 ;
      private GXCombobox cmbavDynamicfiltersselector3 ;
      private GXCombobox cmbavDynamicfiltersoperator3 ;
      private IDataStoreProvider pr_default ;
      private string[] H005O2_A501AuditGAMUserName ;
      private string[] H005O2_A498AuditDescription ;
      private string[] H005O2_A499AuditShortDescription ;
      private string[] H005O2_A502AuditAction ;
      private string[] H005O2_A497AuditTableName ;
      private DateTime[] H005O2_A495AuditTime ;
      private DateTime[] H005O2_A494AuditDate ;
      private DateTime[] H005O2_A496AuditDateTime ;
      private Guid[] H005O2_A493AuditID ;
      private long[] H005O3_AGRID_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV8HTTPRequest ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV41ManageFiltersData ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV74AGExportData ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV66GAMErrors ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV12GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV13GridStateDynamicFilter ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV38ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV39ColumnsSelectorAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item AV75AGExportDataItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV64DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV65GAMSession ;
   }

   public class auditww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H005O2( IGxContext context ,
                                             string AV88Core_auditwwds_1_filterfulltext ,
                                             string AV89Core_auditwwds_2_dynamicfiltersselector1 ,
                                             short AV90Core_auditwwds_3_dynamicfiltersoperator1 ,
                                             DateTime AV91Core_auditwwds_4_auditdate1 ,
                                             DateTime AV92Core_auditwwds_5_auditdate_to1 ,
                                             bool AV93Core_auditwwds_6_dynamicfiltersenabled2 ,
                                             string AV94Core_auditwwds_7_dynamicfiltersselector2 ,
                                             short AV95Core_auditwwds_8_dynamicfiltersoperator2 ,
                                             DateTime AV96Core_auditwwds_9_auditdate2 ,
                                             DateTime AV97Core_auditwwds_10_auditdate_to2 ,
                                             bool AV98Core_auditwwds_11_dynamicfiltersenabled3 ,
                                             string AV99Core_auditwwds_12_dynamicfiltersselector3 ,
                                             short AV100Core_auditwwds_13_dynamicfiltersoperator3 ,
                                             DateTime AV101Core_auditwwds_14_auditdate3 ,
                                             DateTime AV102Core_auditwwds_15_auditdate_to3 ,
                                             DateTime AV103Core_auditwwds_16_tfauditdatetime ,
                                             DateTime AV104Core_auditwwds_17_tfauditdatetime_to ,
                                             DateTime AV105Core_auditwwds_18_tfauditdate ,
                                             DateTime AV106Core_auditwwds_19_tfauditdate_to ,
                                             DateTime AV107Core_auditwwds_20_tfaudittime ,
                                             DateTime AV108Core_auditwwds_21_tfaudittime_to ,
                                             string AV110Core_auditwwds_23_tfaudittablename_sel ,
                                             string AV109Core_auditwwds_22_tfaudittablename ,
                                             string AV112Core_auditwwds_25_tfauditaction_sel ,
                                             string AV111Core_auditwwds_24_tfauditaction ,
                                             string AV114Core_auditwwds_27_tfauditshortdescription_sel ,
                                             string AV113Core_auditwwds_26_tfauditshortdescription ,
                                             string AV116Core_auditwwds_29_tfauditdescription_sel ,
                                             string AV115Core_auditwwds_28_tfauditdescription ,
                                             string AV118Core_auditwwds_31_tfauditgamusername_sel ,
                                             string AV117Core_auditwwds_30_tfauditgamusername ,
                                             string A497AuditTableName ,
                                             string A502AuditAction ,
                                             string A499AuditShortDescription ,
                                             string A498AuditDescription ,
                                             string A501AuditGAMUserName ,
                                             DateTime A494AuditDate ,
                                             DateTime A496AuditDateTime ,
                                             DateTime A495AuditTime ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[39];
         Object[] GXv_Object10 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " AuditGAMUserName, AuditDescription, AuditShortDescription, AuditAction, AuditTableName, AuditTime, AuditDate, AuditDateTime, AuditID";
         sFromString = " FROM tb_audit";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Core_auditwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( AuditTableName like '%' || :lV88Core_auditwwds_1_filterfulltext) or ( AuditAction like '%' || :lV88Core_auditwwds_1_filterfulltext) or ( AuditShortDescription like '%' || :lV88Core_auditwwds_1_filterfulltext) or ( AuditDescription like '%' || :lV88Core_auditwwds_1_filterfulltext) or ( AuditGAMUserName like '%' || :lV88Core_auditwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int9[0] = 1;
            GXv_int9[1] = 1;
            GXv_int9[2] = 1;
            GXv_int9[3] = 1;
            GXv_int9[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV89Core_auditwwds_2_dynamicfiltersselector1, "AUDITDATE") == 0 ) && ( AV90Core_auditwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (DateTime.MinValue==AV91Core_auditwwds_4_auditdate1) ) )
         {
            AddWhere(sWhereString, "(AuditDate >= :AV91Core_auditwwds_4_auditdate1)");
         }
         else
         {
            GXv_int9[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV89Core_auditwwds_2_dynamicfiltersselector1, "AUDITDATE") == 0 ) && ( AV90Core_auditwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (DateTime.MinValue==AV92Core_auditwwds_5_auditdate_to1) ) )
         {
            AddWhere(sWhereString, "(AuditDate <= :AV92Core_auditwwds_5_auditdate_to1)");
         }
         else
         {
            GXv_int9[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV89Core_auditwwds_2_dynamicfiltersselector1, "AUDITDATE") == 0 ) && ( AV90Core_auditwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (DateTime.MinValue==AV91Core_auditwwds_4_auditdate1) ) )
         {
            AddWhere(sWhereString, "(AuditDate < :AV91Core_auditwwds_4_auditdate1)");
         }
         else
         {
            GXv_int9[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV89Core_auditwwds_2_dynamicfiltersselector1, "AUDITDATE") == 0 ) && ( AV90Core_auditwwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (DateTime.MinValue==AV91Core_auditwwds_4_auditdate1) ) )
         {
            AddWhere(sWhereString, "(AuditDate = :AV91Core_auditwwds_4_auditdate1)");
         }
         else
         {
            GXv_int9[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV89Core_auditwwds_2_dynamicfiltersselector1, "AUDITDATE") == 0 ) && ( AV90Core_auditwwds_3_dynamicfiltersoperator1 == 3 ) && ( ! (DateTime.MinValue==AV91Core_auditwwds_4_auditdate1) ) )
         {
            AddWhere(sWhereString, "(AuditDate > :AV91Core_auditwwds_4_auditdate1)");
         }
         else
         {
            GXv_int9[9] = 1;
         }
         if ( AV93Core_auditwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV94Core_auditwwds_7_dynamicfiltersselector2, "AUDITDATE") == 0 ) && ( AV95Core_auditwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! (DateTime.MinValue==AV96Core_auditwwds_9_auditdate2) ) )
         {
            AddWhere(sWhereString, "(AuditDate >= :AV96Core_auditwwds_9_auditdate2)");
         }
         else
         {
            GXv_int9[10] = 1;
         }
         if ( AV93Core_auditwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV94Core_auditwwds_7_dynamicfiltersselector2, "AUDITDATE") == 0 ) && ( AV95Core_auditwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! (DateTime.MinValue==AV97Core_auditwwds_10_auditdate_to2) ) )
         {
            AddWhere(sWhereString, "(AuditDate <= :AV97Core_auditwwds_10_auditdate_to2)");
         }
         else
         {
            GXv_int9[11] = 1;
         }
         if ( AV93Core_auditwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV94Core_auditwwds_7_dynamicfiltersselector2, "AUDITDATE") == 0 ) && ( AV95Core_auditwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! (DateTime.MinValue==AV96Core_auditwwds_9_auditdate2) ) )
         {
            AddWhere(sWhereString, "(AuditDate < :AV96Core_auditwwds_9_auditdate2)");
         }
         else
         {
            GXv_int9[12] = 1;
         }
         if ( AV93Core_auditwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV94Core_auditwwds_7_dynamicfiltersselector2, "AUDITDATE") == 0 ) && ( AV95Core_auditwwds_8_dynamicfiltersoperator2 == 2 ) && ( ! (DateTime.MinValue==AV96Core_auditwwds_9_auditdate2) ) )
         {
            AddWhere(sWhereString, "(AuditDate = :AV96Core_auditwwds_9_auditdate2)");
         }
         else
         {
            GXv_int9[13] = 1;
         }
         if ( AV93Core_auditwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV94Core_auditwwds_7_dynamicfiltersselector2, "AUDITDATE") == 0 ) && ( AV95Core_auditwwds_8_dynamicfiltersoperator2 == 3 ) && ( ! (DateTime.MinValue==AV96Core_auditwwds_9_auditdate2) ) )
         {
            AddWhere(sWhereString, "(AuditDate > :AV96Core_auditwwds_9_auditdate2)");
         }
         else
         {
            GXv_int9[14] = 1;
         }
         if ( AV98Core_auditwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Core_auditwwds_12_dynamicfiltersselector3, "AUDITDATE") == 0 ) && ( AV100Core_auditwwds_13_dynamicfiltersoperator3 == 0 ) && ( ! (DateTime.MinValue==AV101Core_auditwwds_14_auditdate3) ) )
         {
            AddWhere(sWhereString, "(AuditDate >= :AV101Core_auditwwds_14_auditdate3)");
         }
         else
         {
            GXv_int9[15] = 1;
         }
         if ( AV98Core_auditwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Core_auditwwds_12_dynamicfiltersselector3, "AUDITDATE") == 0 ) && ( AV100Core_auditwwds_13_dynamicfiltersoperator3 == 0 ) && ( ! (DateTime.MinValue==AV102Core_auditwwds_15_auditdate_to3) ) )
         {
            AddWhere(sWhereString, "(AuditDate <= :AV102Core_auditwwds_15_auditdate_to3)");
         }
         else
         {
            GXv_int9[16] = 1;
         }
         if ( AV98Core_auditwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Core_auditwwds_12_dynamicfiltersselector3, "AUDITDATE") == 0 ) && ( AV100Core_auditwwds_13_dynamicfiltersoperator3 == 1 ) && ( ! (DateTime.MinValue==AV101Core_auditwwds_14_auditdate3) ) )
         {
            AddWhere(sWhereString, "(AuditDate < :AV101Core_auditwwds_14_auditdate3)");
         }
         else
         {
            GXv_int9[17] = 1;
         }
         if ( AV98Core_auditwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Core_auditwwds_12_dynamicfiltersselector3, "AUDITDATE") == 0 ) && ( AV100Core_auditwwds_13_dynamicfiltersoperator3 == 2 ) && ( ! (DateTime.MinValue==AV101Core_auditwwds_14_auditdate3) ) )
         {
            AddWhere(sWhereString, "(AuditDate = :AV101Core_auditwwds_14_auditdate3)");
         }
         else
         {
            GXv_int9[18] = 1;
         }
         if ( AV98Core_auditwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Core_auditwwds_12_dynamicfiltersselector3, "AUDITDATE") == 0 ) && ( AV100Core_auditwwds_13_dynamicfiltersoperator3 == 3 ) && ( ! (DateTime.MinValue==AV101Core_auditwwds_14_auditdate3) ) )
         {
            AddWhere(sWhereString, "(AuditDate > :AV101Core_auditwwds_14_auditdate3)");
         }
         else
         {
            GXv_int9[19] = 1;
         }
         if ( ! (DateTime.MinValue==AV103Core_auditwwds_16_tfauditdatetime) )
         {
            AddWhere(sWhereString, "(AuditDateTime >= :AV103Core_auditwwds_16_tfauditdatetime)");
         }
         else
         {
            GXv_int9[20] = 1;
         }
         if ( ! (DateTime.MinValue==AV104Core_auditwwds_17_tfauditdatetime_to) )
         {
            AddWhere(sWhereString, "(AuditDateTime <= :AV104Core_auditwwds_17_tfauditdatetime_to)");
         }
         else
         {
            GXv_int9[21] = 1;
         }
         if ( ! (DateTime.MinValue==AV105Core_auditwwds_18_tfauditdate) )
         {
            AddWhere(sWhereString, "(AuditDate >= :AV105Core_auditwwds_18_tfauditdate)");
         }
         else
         {
            GXv_int9[22] = 1;
         }
         if ( ! (DateTime.MinValue==AV106Core_auditwwds_19_tfauditdate_to) )
         {
            AddWhere(sWhereString, "(AuditDate <= :AV106Core_auditwwds_19_tfauditdate_to)");
         }
         else
         {
            GXv_int9[23] = 1;
         }
         if ( ! (DateTime.MinValue==AV107Core_auditwwds_20_tfaudittime) )
         {
            AddWhere(sWhereString, "(AuditTime >= :AV107Core_auditwwds_20_tfaudittime)");
         }
         else
         {
            GXv_int9[24] = 1;
         }
         if ( ! (DateTime.MinValue==AV108Core_auditwwds_21_tfaudittime_to) )
         {
            AddWhere(sWhereString, "(AuditTime <= :AV108Core_auditwwds_21_tfaudittime_to)");
         }
         else
         {
            GXv_int9[25] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV110Core_auditwwds_23_tfaudittablename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Core_auditwwds_22_tfaudittablename)) ) )
         {
            AddWhere(sWhereString, "(AuditTableName like :lV109Core_auditwwds_22_tfaudittablename)");
         }
         else
         {
            GXv_int9[26] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Core_auditwwds_23_tfaudittablename_sel)) && ! ( StringUtil.StrCmp(AV110Core_auditwwds_23_tfaudittablename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(AuditTableName = ( :AV110Core_auditwwds_23_tfaudittablename_sel))");
         }
         else
         {
            GXv_int9[27] = 1;
         }
         if ( StringUtil.StrCmp(AV110Core_auditwwds_23_tfaudittablename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from AuditTableName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV112Core_auditwwds_25_tfauditaction_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Core_auditwwds_24_tfauditaction)) ) )
         {
            AddWhere(sWhereString, "(AuditAction like :lV111Core_auditwwds_24_tfauditaction)");
         }
         else
         {
            GXv_int9[28] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Core_auditwwds_25_tfauditaction_sel)) && ! ( StringUtil.StrCmp(AV112Core_auditwwds_25_tfauditaction_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(AuditAction = ( :AV112Core_auditwwds_25_tfauditaction_sel))");
         }
         else
         {
            GXv_int9[29] = 1;
         }
         if ( StringUtil.StrCmp(AV112Core_auditwwds_25_tfauditaction_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from AuditAction))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV114Core_auditwwds_27_tfauditshortdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Core_auditwwds_26_tfauditshortdescription)) ) )
         {
            AddWhere(sWhereString, "(AuditShortDescription like :lV113Core_auditwwds_26_tfauditshortdescription)");
         }
         else
         {
            GXv_int9[30] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Core_auditwwds_27_tfauditshortdescription_sel)) && ! ( StringUtil.StrCmp(AV114Core_auditwwds_27_tfauditshortdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(AuditShortDescription = ( :AV114Core_auditwwds_27_tfauditshortdescription_sel))");
         }
         else
         {
            GXv_int9[31] = 1;
         }
         if ( StringUtil.StrCmp(AV114Core_auditwwds_27_tfauditshortdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from AuditShortDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV116Core_auditwwds_29_tfauditdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Core_auditwwds_28_tfauditdescription)) ) )
         {
            AddWhere(sWhereString, "(AuditDescription like :lV115Core_auditwwds_28_tfauditdescription)");
         }
         else
         {
            GXv_int9[32] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Core_auditwwds_29_tfauditdescription_sel)) && ! ( StringUtil.StrCmp(AV116Core_auditwwds_29_tfauditdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(AuditDescription = ( :AV116Core_auditwwds_29_tfauditdescription_sel))");
         }
         else
         {
            GXv_int9[33] = 1;
         }
         if ( StringUtil.StrCmp(AV116Core_auditwwds_29_tfauditdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from AuditDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV118Core_auditwwds_31_tfauditgamusername_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Core_auditwwds_30_tfauditgamusername)) ) )
         {
            AddWhere(sWhereString, "(AuditGAMUserName like :lV117Core_auditwwds_30_tfauditgamusername)");
         }
         else
         {
            GXv_int9[34] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Core_auditwwds_31_tfauditgamusername_sel)) && ! ( StringUtil.StrCmp(AV118Core_auditwwds_31_tfauditgamusername_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(AuditGAMUserName = ( :AV118Core_auditwwds_31_tfauditgamusername_sel))");
         }
         else
         {
            GXv_int9[35] = 1;
         }
         if ( StringUtil.StrCmp(AV118Core_auditwwds_31_tfauditgamusername_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from AuditGAMUserName))=0))");
         }
         if ( ( AV14OrderedBy == 1 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY AuditDateTime, AuditID";
         }
         else if ( ( AV14OrderedBy == 1 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY AuditDateTime DESC, AuditID";
         }
         else if ( ( AV14OrderedBy == 2 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY AuditDate, AuditID";
         }
         else if ( ( AV14OrderedBy == 2 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY AuditDate DESC, AuditID";
         }
         else if ( ( AV14OrderedBy == 3 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY AuditTime, AuditID";
         }
         else if ( ( AV14OrderedBy == 3 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY AuditTime DESC, AuditID";
         }
         else if ( ( AV14OrderedBy == 4 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY AuditTableName, AuditID";
         }
         else if ( ( AV14OrderedBy == 4 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY AuditTableName DESC, AuditID";
         }
         else if ( ( AV14OrderedBy == 5 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY AuditAction, AuditID";
         }
         else if ( ( AV14OrderedBy == 5 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY AuditAction DESC, AuditID";
         }
         else if ( ( AV14OrderedBy == 6 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY AuditShortDescription, AuditID";
         }
         else if ( ( AV14OrderedBy == 6 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY AuditShortDescription DESC, AuditID";
         }
         else if ( ( AV14OrderedBy == 7 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY AuditDescription, AuditID";
         }
         else if ( ( AV14OrderedBy == 7 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY AuditDescription DESC, AuditID";
         }
         else if ( ( AV14OrderedBy == 8 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY AuditGAMUserName, AuditID";
         }
         else if ( ( AV14OrderedBy == 8 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY AuditGAMUserName DESC, AuditID";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY AuditID";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object10[0] = scmdbuf;
         GXv_Object10[1] = GXv_int9;
         return GXv_Object10 ;
      }

      protected Object[] conditional_H005O3( IGxContext context ,
                                             string AV88Core_auditwwds_1_filterfulltext ,
                                             string AV89Core_auditwwds_2_dynamicfiltersselector1 ,
                                             short AV90Core_auditwwds_3_dynamicfiltersoperator1 ,
                                             DateTime AV91Core_auditwwds_4_auditdate1 ,
                                             DateTime AV92Core_auditwwds_5_auditdate_to1 ,
                                             bool AV93Core_auditwwds_6_dynamicfiltersenabled2 ,
                                             string AV94Core_auditwwds_7_dynamicfiltersselector2 ,
                                             short AV95Core_auditwwds_8_dynamicfiltersoperator2 ,
                                             DateTime AV96Core_auditwwds_9_auditdate2 ,
                                             DateTime AV97Core_auditwwds_10_auditdate_to2 ,
                                             bool AV98Core_auditwwds_11_dynamicfiltersenabled3 ,
                                             string AV99Core_auditwwds_12_dynamicfiltersselector3 ,
                                             short AV100Core_auditwwds_13_dynamicfiltersoperator3 ,
                                             DateTime AV101Core_auditwwds_14_auditdate3 ,
                                             DateTime AV102Core_auditwwds_15_auditdate_to3 ,
                                             DateTime AV103Core_auditwwds_16_tfauditdatetime ,
                                             DateTime AV104Core_auditwwds_17_tfauditdatetime_to ,
                                             DateTime AV105Core_auditwwds_18_tfauditdate ,
                                             DateTime AV106Core_auditwwds_19_tfauditdate_to ,
                                             DateTime AV107Core_auditwwds_20_tfaudittime ,
                                             DateTime AV108Core_auditwwds_21_tfaudittime_to ,
                                             string AV110Core_auditwwds_23_tfaudittablename_sel ,
                                             string AV109Core_auditwwds_22_tfaudittablename ,
                                             string AV112Core_auditwwds_25_tfauditaction_sel ,
                                             string AV111Core_auditwwds_24_tfauditaction ,
                                             string AV114Core_auditwwds_27_tfauditshortdescription_sel ,
                                             string AV113Core_auditwwds_26_tfauditshortdescription ,
                                             string AV116Core_auditwwds_29_tfauditdescription_sel ,
                                             string AV115Core_auditwwds_28_tfauditdescription ,
                                             string AV118Core_auditwwds_31_tfauditgamusername_sel ,
                                             string AV117Core_auditwwds_30_tfauditgamusername ,
                                             string A497AuditTableName ,
                                             string A502AuditAction ,
                                             string A499AuditShortDescription ,
                                             string A498AuditDescription ,
                                             string A501AuditGAMUserName ,
                                             DateTime A494AuditDate ,
                                             DateTime A496AuditDateTime ,
                                             DateTime A495AuditTime ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int11 = new short[36];
         Object[] GXv_Object12 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM tb_audit";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Core_auditwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( AuditTableName like '%' || :lV88Core_auditwwds_1_filterfulltext) or ( AuditAction like '%' || :lV88Core_auditwwds_1_filterfulltext) or ( AuditShortDescription like '%' || :lV88Core_auditwwds_1_filterfulltext) or ( AuditDescription like '%' || :lV88Core_auditwwds_1_filterfulltext) or ( AuditGAMUserName like '%' || :lV88Core_auditwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int11[0] = 1;
            GXv_int11[1] = 1;
            GXv_int11[2] = 1;
            GXv_int11[3] = 1;
            GXv_int11[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV89Core_auditwwds_2_dynamicfiltersselector1, "AUDITDATE") == 0 ) && ( AV90Core_auditwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (DateTime.MinValue==AV91Core_auditwwds_4_auditdate1) ) )
         {
            AddWhere(sWhereString, "(AuditDate >= :AV91Core_auditwwds_4_auditdate1)");
         }
         else
         {
            GXv_int11[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV89Core_auditwwds_2_dynamicfiltersselector1, "AUDITDATE") == 0 ) && ( AV90Core_auditwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (DateTime.MinValue==AV92Core_auditwwds_5_auditdate_to1) ) )
         {
            AddWhere(sWhereString, "(AuditDate <= :AV92Core_auditwwds_5_auditdate_to1)");
         }
         else
         {
            GXv_int11[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV89Core_auditwwds_2_dynamicfiltersselector1, "AUDITDATE") == 0 ) && ( AV90Core_auditwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (DateTime.MinValue==AV91Core_auditwwds_4_auditdate1) ) )
         {
            AddWhere(sWhereString, "(AuditDate < :AV91Core_auditwwds_4_auditdate1)");
         }
         else
         {
            GXv_int11[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV89Core_auditwwds_2_dynamicfiltersselector1, "AUDITDATE") == 0 ) && ( AV90Core_auditwwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (DateTime.MinValue==AV91Core_auditwwds_4_auditdate1) ) )
         {
            AddWhere(sWhereString, "(AuditDate = :AV91Core_auditwwds_4_auditdate1)");
         }
         else
         {
            GXv_int11[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV89Core_auditwwds_2_dynamicfiltersselector1, "AUDITDATE") == 0 ) && ( AV90Core_auditwwds_3_dynamicfiltersoperator1 == 3 ) && ( ! (DateTime.MinValue==AV91Core_auditwwds_4_auditdate1) ) )
         {
            AddWhere(sWhereString, "(AuditDate > :AV91Core_auditwwds_4_auditdate1)");
         }
         else
         {
            GXv_int11[9] = 1;
         }
         if ( AV93Core_auditwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV94Core_auditwwds_7_dynamicfiltersselector2, "AUDITDATE") == 0 ) && ( AV95Core_auditwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! (DateTime.MinValue==AV96Core_auditwwds_9_auditdate2) ) )
         {
            AddWhere(sWhereString, "(AuditDate >= :AV96Core_auditwwds_9_auditdate2)");
         }
         else
         {
            GXv_int11[10] = 1;
         }
         if ( AV93Core_auditwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV94Core_auditwwds_7_dynamicfiltersselector2, "AUDITDATE") == 0 ) && ( AV95Core_auditwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! (DateTime.MinValue==AV97Core_auditwwds_10_auditdate_to2) ) )
         {
            AddWhere(sWhereString, "(AuditDate <= :AV97Core_auditwwds_10_auditdate_to2)");
         }
         else
         {
            GXv_int11[11] = 1;
         }
         if ( AV93Core_auditwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV94Core_auditwwds_7_dynamicfiltersselector2, "AUDITDATE") == 0 ) && ( AV95Core_auditwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! (DateTime.MinValue==AV96Core_auditwwds_9_auditdate2) ) )
         {
            AddWhere(sWhereString, "(AuditDate < :AV96Core_auditwwds_9_auditdate2)");
         }
         else
         {
            GXv_int11[12] = 1;
         }
         if ( AV93Core_auditwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV94Core_auditwwds_7_dynamicfiltersselector2, "AUDITDATE") == 0 ) && ( AV95Core_auditwwds_8_dynamicfiltersoperator2 == 2 ) && ( ! (DateTime.MinValue==AV96Core_auditwwds_9_auditdate2) ) )
         {
            AddWhere(sWhereString, "(AuditDate = :AV96Core_auditwwds_9_auditdate2)");
         }
         else
         {
            GXv_int11[13] = 1;
         }
         if ( AV93Core_auditwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV94Core_auditwwds_7_dynamicfiltersselector2, "AUDITDATE") == 0 ) && ( AV95Core_auditwwds_8_dynamicfiltersoperator2 == 3 ) && ( ! (DateTime.MinValue==AV96Core_auditwwds_9_auditdate2) ) )
         {
            AddWhere(sWhereString, "(AuditDate > :AV96Core_auditwwds_9_auditdate2)");
         }
         else
         {
            GXv_int11[14] = 1;
         }
         if ( AV98Core_auditwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Core_auditwwds_12_dynamicfiltersselector3, "AUDITDATE") == 0 ) && ( AV100Core_auditwwds_13_dynamicfiltersoperator3 == 0 ) && ( ! (DateTime.MinValue==AV101Core_auditwwds_14_auditdate3) ) )
         {
            AddWhere(sWhereString, "(AuditDate >= :AV101Core_auditwwds_14_auditdate3)");
         }
         else
         {
            GXv_int11[15] = 1;
         }
         if ( AV98Core_auditwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Core_auditwwds_12_dynamicfiltersselector3, "AUDITDATE") == 0 ) && ( AV100Core_auditwwds_13_dynamicfiltersoperator3 == 0 ) && ( ! (DateTime.MinValue==AV102Core_auditwwds_15_auditdate_to3) ) )
         {
            AddWhere(sWhereString, "(AuditDate <= :AV102Core_auditwwds_15_auditdate_to3)");
         }
         else
         {
            GXv_int11[16] = 1;
         }
         if ( AV98Core_auditwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Core_auditwwds_12_dynamicfiltersselector3, "AUDITDATE") == 0 ) && ( AV100Core_auditwwds_13_dynamicfiltersoperator3 == 1 ) && ( ! (DateTime.MinValue==AV101Core_auditwwds_14_auditdate3) ) )
         {
            AddWhere(sWhereString, "(AuditDate < :AV101Core_auditwwds_14_auditdate3)");
         }
         else
         {
            GXv_int11[17] = 1;
         }
         if ( AV98Core_auditwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Core_auditwwds_12_dynamicfiltersselector3, "AUDITDATE") == 0 ) && ( AV100Core_auditwwds_13_dynamicfiltersoperator3 == 2 ) && ( ! (DateTime.MinValue==AV101Core_auditwwds_14_auditdate3) ) )
         {
            AddWhere(sWhereString, "(AuditDate = :AV101Core_auditwwds_14_auditdate3)");
         }
         else
         {
            GXv_int11[18] = 1;
         }
         if ( AV98Core_auditwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV99Core_auditwwds_12_dynamicfiltersselector3, "AUDITDATE") == 0 ) && ( AV100Core_auditwwds_13_dynamicfiltersoperator3 == 3 ) && ( ! (DateTime.MinValue==AV101Core_auditwwds_14_auditdate3) ) )
         {
            AddWhere(sWhereString, "(AuditDate > :AV101Core_auditwwds_14_auditdate3)");
         }
         else
         {
            GXv_int11[19] = 1;
         }
         if ( ! (DateTime.MinValue==AV103Core_auditwwds_16_tfauditdatetime) )
         {
            AddWhere(sWhereString, "(AuditDateTime >= :AV103Core_auditwwds_16_tfauditdatetime)");
         }
         else
         {
            GXv_int11[20] = 1;
         }
         if ( ! (DateTime.MinValue==AV104Core_auditwwds_17_tfauditdatetime_to) )
         {
            AddWhere(sWhereString, "(AuditDateTime <= :AV104Core_auditwwds_17_tfauditdatetime_to)");
         }
         else
         {
            GXv_int11[21] = 1;
         }
         if ( ! (DateTime.MinValue==AV105Core_auditwwds_18_tfauditdate) )
         {
            AddWhere(sWhereString, "(AuditDate >= :AV105Core_auditwwds_18_tfauditdate)");
         }
         else
         {
            GXv_int11[22] = 1;
         }
         if ( ! (DateTime.MinValue==AV106Core_auditwwds_19_tfauditdate_to) )
         {
            AddWhere(sWhereString, "(AuditDate <= :AV106Core_auditwwds_19_tfauditdate_to)");
         }
         else
         {
            GXv_int11[23] = 1;
         }
         if ( ! (DateTime.MinValue==AV107Core_auditwwds_20_tfaudittime) )
         {
            AddWhere(sWhereString, "(AuditTime >= :AV107Core_auditwwds_20_tfaudittime)");
         }
         else
         {
            GXv_int11[24] = 1;
         }
         if ( ! (DateTime.MinValue==AV108Core_auditwwds_21_tfaudittime_to) )
         {
            AddWhere(sWhereString, "(AuditTime <= :AV108Core_auditwwds_21_tfaudittime_to)");
         }
         else
         {
            GXv_int11[25] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV110Core_auditwwds_23_tfaudittablename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Core_auditwwds_22_tfaudittablename)) ) )
         {
            AddWhere(sWhereString, "(AuditTableName like :lV109Core_auditwwds_22_tfaudittablename)");
         }
         else
         {
            GXv_int11[26] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Core_auditwwds_23_tfaudittablename_sel)) && ! ( StringUtil.StrCmp(AV110Core_auditwwds_23_tfaudittablename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(AuditTableName = ( :AV110Core_auditwwds_23_tfaudittablename_sel))");
         }
         else
         {
            GXv_int11[27] = 1;
         }
         if ( StringUtil.StrCmp(AV110Core_auditwwds_23_tfaudittablename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from AuditTableName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV112Core_auditwwds_25_tfauditaction_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Core_auditwwds_24_tfauditaction)) ) )
         {
            AddWhere(sWhereString, "(AuditAction like :lV111Core_auditwwds_24_tfauditaction)");
         }
         else
         {
            GXv_int11[28] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Core_auditwwds_25_tfauditaction_sel)) && ! ( StringUtil.StrCmp(AV112Core_auditwwds_25_tfauditaction_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(AuditAction = ( :AV112Core_auditwwds_25_tfauditaction_sel))");
         }
         else
         {
            GXv_int11[29] = 1;
         }
         if ( StringUtil.StrCmp(AV112Core_auditwwds_25_tfauditaction_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from AuditAction))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV114Core_auditwwds_27_tfauditshortdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Core_auditwwds_26_tfauditshortdescription)) ) )
         {
            AddWhere(sWhereString, "(AuditShortDescription like :lV113Core_auditwwds_26_tfauditshortdescription)");
         }
         else
         {
            GXv_int11[30] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Core_auditwwds_27_tfauditshortdescription_sel)) && ! ( StringUtil.StrCmp(AV114Core_auditwwds_27_tfauditshortdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(AuditShortDescription = ( :AV114Core_auditwwds_27_tfauditshortdescription_sel))");
         }
         else
         {
            GXv_int11[31] = 1;
         }
         if ( StringUtil.StrCmp(AV114Core_auditwwds_27_tfauditshortdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from AuditShortDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV116Core_auditwwds_29_tfauditdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Core_auditwwds_28_tfauditdescription)) ) )
         {
            AddWhere(sWhereString, "(AuditDescription like :lV115Core_auditwwds_28_tfauditdescription)");
         }
         else
         {
            GXv_int11[32] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Core_auditwwds_29_tfauditdescription_sel)) && ! ( StringUtil.StrCmp(AV116Core_auditwwds_29_tfauditdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(AuditDescription = ( :AV116Core_auditwwds_29_tfauditdescription_sel))");
         }
         else
         {
            GXv_int11[33] = 1;
         }
         if ( StringUtil.StrCmp(AV116Core_auditwwds_29_tfauditdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from AuditDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV118Core_auditwwds_31_tfauditgamusername_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Core_auditwwds_30_tfauditgamusername)) ) )
         {
            AddWhere(sWhereString, "(AuditGAMUserName like :lV117Core_auditwwds_30_tfauditgamusername)");
         }
         else
         {
            GXv_int11[34] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Core_auditwwds_31_tfauditgamusername_sel)) && ! ( StringUtil.StrCmp(AV118Core_auditwwds_31_tfauditgamusername_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(AuditGAMUserName = ( :AV118Core_auditwwds_31_tfauditgamusername_sel))");
         }
         else
         {
            GXv_int11[35] = 1;
         }
         if ( StringUtil.StrCmp(AV118Core_auditwwds_31_tfauditgamusername_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from AuditGAMUserName))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV14OrderedBy == 1 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 1 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 2 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 2 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 3 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 3 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 4 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 4 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 5 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 5 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 6 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 6 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 7 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 7 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 8 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 8 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( true )
         {
            scmdbuf += "";
         }
         GXv_Object12[0] = scmdbuf;
         GXv_Object12[1] = GXv_int11;
         return GXv_Object12 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H005O2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (DateTime)dynConstraints[13] , (DateTime)dynConstraints[14] , (DateTime)dynConstraints[15] , (DateTime)dynConstraints[16] , (DateTime)dynConstraints[17] , (DateTime)dynConstraints[18] , (DateTime)dynConstraints[19] , (DateTime)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (DateTime)dynConstraints[36] , (DateTime)dynConstraints[37] , (DateTime)dynConstraints[38] , (short)dynConstraints[39] , (bool)dynConstraints[40] );
               case 1 :
                     return conditional_H005O3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (DateTime)dynConstraints[13] , (DateTime)dynConstraints[14] , (DateTime)dynConstraints[15] , (DateTime)dynConstraints[16] , (DateTime)dynConstraints[17] , (DateTime)dynConstraints[18] , (DateTime)dynConstraints[19] , (DateTime)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (DateTime)dynConstraints[36] , (DateTime)dynConstraints[37] , (DateTime)dynConstraints[38] , (short)dynConstraints[39] , (bool)dynConstraints[40] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH005O2;
          prmH005O2 = new Object[] {
          new ParDef("lV88Core_auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV88Core_auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV88Core_auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV88Core_auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV88Core_auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV91Core_auditwwds_4_auditdate1",GXType.Date,8,0) ,
          new ParDef("AV92Core_auditwwds_5_auditdate_to1",GXType.Date,8,0) ,
          new ParDef("AV91Core_auditwwds_4_auditdate1",GXType.Date,8,0) ,
          new ParDef("AV91Core_auditwwds_4_auditdate1",GXType.Date,8,0) ,
          new ParDef("AV91Core_auditwwds_4_auditdate1",GXType.Date,8,0) ,
          new ParDef("AV96Core_auditwwds_9_auditdate2",GXType.Date,8,0) ,
          new ParDef("AV97Core_auditwwds_10_auditdate_to2",GXType.Date,8,0) ,
          new ParDef("AV96Core_auditwwds_9_auditdate2",GXType.Date,8,0) ,
          new ParDef("AV96Core_auditwwds_9_auditdate2",GXType.Date,8,0) ,
          new ParDef("AV96Core_auditwwds_9_auditdate2",GXType.Date,8,0) ,
          new ParDef("AV101Core_auditwwds_14_auditdate3",GXType.Date,8,0) ,
          new ParDef("AV102Core_auditwwds_15_auditdate_to3",GXType.Date,8,0) ,
          new ParDef("AV101Core_auditwwds_14_auditdate3",GXType.Date,8,0) ,
          new ParDef("AV101Core_auditwwds_14_auditdate3",GXType.Date,8,0) ,
          new ParDef("AV101Core_auditwwds_14_auditdate3",GXType.Date,8,0) ,
          new ParDef("AV103Core_auditwwds_16_tfauditdatetime",GXType.DateTime2,10,12) ,
          new ParDef("AV104Core_auditwwds_17_tfauditdatetime_to",GXType.DateTime2,10,12) ,
          new ParDef("AV105Core_auditwwds_18_tfauditdate",GXType.Date,8,0) ,
          new ParDef("AV106Core_auditwwds_19_tfauditdate_to",GXType.Date,8,0) ,
          new ParDef("AV107Core_auditwwds_20_tfaudittime",GXType.DateTime,0,5) ,
          new ParDef("AV108Core_auditwwds_21_tfaudittime_to",GXType.DateTime,0,5) ,
          new ParDef("lV109Core_auditwwds_22_tfaudittablename",GXType.VarChar,80,0) ,
          new ParDef("AV110Core_auditwwds_23_tfaudittablename_sel",GXType.VarChar,80,0) ,
          new ParDef("lV111Core_auditwwds_24_tfauditaction",GXType.VarChar,40,0) ,
          new ParDef("AV112Core_auditwwds_25_tfauditaction_sel",GXType.VarChar,40,0) ,
          new ParDef("lV113Core_auditwwds_26_tfauditshortdescription",GXType.VarChar,400,0) ,
          new ParDef("AV114Core_auditwwds_27_tfauditshortdescription_sel",GXType.VarChar,400,0) ,
          new ParDef("lV115Core_auditwwds_28_tfauditdescription",GXType.VarChar,200,0) ,
          new ParDef("AV116Core_auditwwds_29_tfauditdescription_sel",GXType.VarChar,200,0) ,
          new ParDef("lV117Core_auditwwds_30_tfauditgamusername",GXType.VarChar,80,0) ,
          new ParDef("AV118Core_auditwwds_31_tfauditgamusername_sel",GXType.VarChar,80,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH005O3;
          prmH005O3 = new Object[] {
          new ParDef("lV88Core_auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV88Core_auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV88Core_auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV88Core_auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV88Core_auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV91Core_auditwwds_4_auditdate1",GXType.Date,8,0) ,
          new ParDef("AV92Core_auditwwds_5_auditdate_to1",GXType.Date,8,0) ,
          new ParDef("AV91Core_auditwwds_4_auditdate1",GXType.Date,8,0) ,
          new ParDef("AV91Core_auditwwds_4_auditdate1",GXType.Date,8,0) ,
          new ParDef("AV91Core_auditwwds_4_auditdate1",GXType.Date,8,0) ,
          new ParDef("AV96Core_auditwwds_9_auditdate2",GXType.Date,8,0) ,
          new ParDef("AV97Core_auditwwds_10_auditdate_to2",GXType.Date,8,0) ,
          new ParDef("AV96Core_auditwwds_9_auditdate2",GXType.Date,8,0) ,
          new ParDef("AV96Core_auditwwds_9_auditdate2",GXType.Date,8,0) ,
          new ParDef("AV96Core_auditwwds_9_auditdate2",GXType.Date,8,0) ,
          new ParDef("AV101Core_auditwwds_14_auditdate3",GXType.Date,8,0) ,
          new ParDef("AV102Core_auditwwds_15_auditdate_to3",GXType.Date,8,0) ,
          new ParDef("AV101Core_auditwwds_14_auditdate3",GXType.Date,8,0) ,
          new ParDef("AV101Core_auditwwds_14_auditdate3",GXType.Date,8,0) ,
          new ParDef("AV101Core_auditwwds_14_auditdate3",GXType.Date,8,0) ,
          new ParDef("AV103Core_auditwwds_16_tfauditdatetime",GXType.DateTime2,10,12) ,
          new ParDef("AV104Core_auditwwds_17_tfauditdatetime_to",GXType.DateTime2,10,12) ,
          new ParDef("AV105Core_auditwwds_18_tfauditdate",GXType.Date,8,0) ,
          new ParDef("AV106Core_auditwwds_19_tfauditdate_to",GXType.Date,8,0) ,
          new ParDef("AV107Core_auditwwds_20_tfaudittime",GXType.DateTime,0,5) ,
          new ParDef("AV108Core_auditwwds_21_tfaudittime_to",GXType.DateTime,0,5) ,
          new ParDef("lV109Core_auditwwds_22_tfaudittablename",GXType.VarChar,80,0) ,
          new ParDef("AV110Core_auditwwds_23_tfaudittablename_sel",GXType.VarChar,80,0) ,
          new ParDef("lV111Core_auditwwds_24_tfauditaction",GXType.VarChar,40,0) ,
          new ParDef("AV112Core_auditwwds_25_tfauditaction_sel",GXType.VarChar,40,0) ,
          new ParDef("lV113Core_auditwwds_26_tfauditshortdescription",GXType.VarChar,400,0) ,
          new ParDef("AV114Core_auditwwds_27_tfauditshortdescription_sel",GXType.VarChar,400,0) ,
          new ParDef("lV115Core_auditwwds_28_tfauditdescription",GXType.VarChar,200,0) ,
          new ParDef("AV116Core_auditwwds_29_tfauditdescription_sel",GXType.VarChar,200,0) ,
          new ParDef("lV117Core_auditwwds_30_tfauditgamusername",GXType.VarChar,80,0) ,
          new ParDef("AV118Core_auditwwds_31_tfauditgamusername_sel",GXType.VarChar,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("H005O2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005O2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H005O3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005O3,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
                ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(8, true);
                ((Guid[]) buf[8])[0] = rslt.getGuid(9);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
