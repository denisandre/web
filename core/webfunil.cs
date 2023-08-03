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
   public class webfunil : GXDataArea
   {
      public webfunil( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public webfunil( IGxContext context )
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
         radavSelectlistview = new GXRadio();
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Dummygrid") == 0 )
            {
               gxnrDummygrid_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Dummygrid") == 0 )
            {
               gxgrDummygrid_refresh_invoke( ) ;
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

      protected void gxnrDummygrid_newrow_invoke( )
      {
         nRC_GXsfl_114 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_114"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_114_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_114_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_114_idx = GetPar( "sGXsfl_114_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrDummygrid_newrow( ) ;
         /* End function gxnrDummygrid_newrow_invoke */
      }

      protected void gxgrDummygrid_refresh_invoke( )
      {
         AV45ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV62Pgmname = GetPar( "Pgmname");
         AV21OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         AV23FilterFullText = GetPar( "FilterFullText");
         AV46TFIteNome = GetPar( "TFIteNome");
         AV47TFIteNome_Sel = GetPar( "TFIteNome_Sel");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV11GridState);
         AV36DynamicFiltersIgnoreFirst = StringUtil.StrToBool( GetPar( "DynamicFiltersIgnoreFirst"));
         cmbavDynamicfiltersselector1.FromJSonString( GetNextPar( ));
         AV24DynamicFiltersSelector1 = GetPar( "DynamicFiltersSelector1");
         AV26IteNome1 = GetPar( "IteNome1");
         cmbavDynamicfiltersoperator1.FromJSonString( GetNextPar( ));
         AV25DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator1"), "."), 18, MidpointRounding.ToEven));
         AV35DynamicFiltersRemoving = StringUtil.StrToBool( GetPar( "DynamicFiltersRemoving"));
         AV27DynamicFiltersEnabled2 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled2"));
         cmbavDynamicfiltersselector2.FromJSonString( GetNextPar( ));
         AV28DynamicFiltersSelector2 = GetPar( "DynamicFiltersSelector2");
         AV30IteNome2 = GetPar( "IteNome2");
         cmbavDynamicfiltersoperator2.FromJSonString( GetNextPar( ));
         AV29DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator2"), "."), 18, MidpointRounding.ToEven));
         AV31DynamicFiltersEnabled3 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled3"));
         cmbavDynamicfiltersselector3.FromJSonString( GetNextPar( ));
         AV32DynamicFiltersSelector3 = GetPar( "DynamicFiltersSelector3");
         AV34IteNome3 = GetPar( "IteNome3");
         cmbavDynamicfiltersoperator3.FromJSonString( GetNextPar( ));
         AV33DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator3"), "."), 18, MidpointRounding.ToEven));
         AV57SelectListView = GetPar( "SelectListView");
         AV61IsAuthorized_AdicionarOportunidade = StringUtil.StrToBool( GetPar( "IsAuthorized_AdicionarOportunidade"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrDummygrid_refresh( AV45ManageFiltersExecutionStep, AV62Pgmname, AV21OrderedDsc, AV23FilterFullText, AV46TFIteNome, AV47TFIteNome_Sel, AV11GridState, AV36DynamicFiltersIgnoreFirst, AV24DynamicFiltersSelector1, AV26IteNome1, AV25DynamicFiltersOperator1, AV35DynamicFiltersRemoving, AV27DynamicFiltersEnabled2, AV28DynamicFiltersSelector2, AV30IteNome2, AV29DynamicFiltersOperator2, AV31DynamicFiltersEnabled3, AV32DynamicFiltersSelector3, AV34IteNome3, AV33DynamicFiltersOperator3, AV57SelectListView, AV61IsAuthorized_AdicionarOportunidade) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrDummygrid_refresh_invoke */
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
            return "webfunil_Execute" ;
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
         PA4X2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START4X2( ) ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("core.webfunil.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV62Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV62Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_ADICIONAROPORTUNIDADE", AV61IsAuthorized_AdicionarOportunidade);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_ADICIONAROPORTUNIDADE", GetSecureSignedToken( "", AV61IsAuthorized_AdicionarOportunidade, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_114", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_114), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV43ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV43ManageFiltersData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAGEXPORTDATA", AV55AGExportData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAGEXPORTDATA", AV55AGExportData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV52DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV52DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCOLUMNSSELECTOR", AV41ColumnsSelector);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCOLUMNSSELECTOR", AV41ColumnsSelector);
         }
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV45ManageFiltersExecutionStep), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV62Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV62Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV21OrderedDsc);
         GxWebStd.gx_hidden_field( context, "vTFITENOME", AV46TFIteNome);
         GxWebStd.gx_hidden_field( context, "vTFITENOME_SEL", AV47TFIteNome_Sel);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV11GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV11GridState);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSIGNOREFIRST", AV36DynamicFiltersIgnoreFirst);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSREMOVING", AV35DynamicFiltersRemoving);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED2", AV27DynamicFiltersEnabled2);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED3", AV31DynamicFiltersEnabled3);
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_ADICIONAROPORTUNIDADE", AV61IsAuthorized_AdicionarOportunidade);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_ADICIONAROPORTUNIDADE", GetSecureSignedToken( "", AV61IsAuthorized_AdicionarOportunidade, context));
         GxWebStd.gx_hidden_field( context, "subDummygrid_Recordcount", StringUtil.LTrim( StringUtil.NToC( (decimal)(subDummygrid_Recordcount), 5, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Icontype", StringUtil.RTrim( Ddo_managefilters_Icontype));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Icon", StringUtil.RTrim( Ddo_managefilters_Icon));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Tooltip", StringUtil.RTrim( Ddo_managefilters_Tooltip));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Cls", StringUtil.RTrim( Ddo_managefilters_Cls));
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
         GxWebStd.gx_hidden_field( context, "INNEWWINDOW1_Width", StringUtil.RTrim( Innewwindow1_Width));
         GxWebStd.gx_hidden_field( context, "INNEWWINDOW1_Height", StringUtil.RTrim( Innewwindow1_Height));
         GxWebStd.gx_hidden_field( context, "INNEWWINDOW1_Target", StringUtil.RTrim( Innewwindow1_Target));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Icontype", StringUtil.RTrim( Ddo_gridcolumnsselector_Icontype));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Icon", StringUtil.RTrim( Ddo_gridcolumnsselector_Icon));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Caption", StringUtil.RTrim( Ddo_gridcolumnsselector_Caption));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Tooltip", StringUtil.RTrim( Ddo_gridcolumnsselector_Tooltip));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Cls", StringUtil.RTrim( Ddo_gridcolumnsselector_Cls));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Dropdownoptionstype", StringUtil.RTrim( Ddo_gridcolumnsselector_Dropdownoptionstype));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Visible", StringUtil.BoolToStr( Ddo_gridcolumnsselector_Visible));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Gridinternalname", StringUtil.RTrim( Ddo_gridcolumnsselector_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Titlecontrolidtoreplace", StringUtil.RTrim( Ddo_gridcolumnsselector_Titlecontrolidtoreplace));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues", StringUtil.RTrim( Ddo_gridcolumnsselector_Columnsselectorvalues));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Activeeventkey", StringUtil.RTrim( Ddo_agexport_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues", StringUtil.RTrim( Ddo_gridcolumnsselector_Columnsselectorvalues));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
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
         if ( ! ( WebComp_Datawc == null ) )
         {
            WebComp_Datawc.componentjscripts();
         }
         if ( ! ( WebComp_Selectlistview_wc == null ) )
         {
            WebComp_Selectlistview_wc.componentjscripts();
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
            WE4X2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT4X2( ) ;
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
         return formatLink("core.webfunil.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "core.webfunil" ;
      }

      public override string GetPgmdesc( )
      {
         return "Funil de Vendas" ;
      }

      protected void WB4X0( )
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
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", "", "false");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
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
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnadicionaroportunidade_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(114), 3, 0)+","+"null"+");", "+ Negócio Rápido", bttBtnadicionaroportunidade_Jsonclick, 5, "+ Negócio Rápido", "", StyleString, ClassString, bttBtnadicionaroportunidade_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOADICIONAROPORTUNIDADE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\webfunil.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'',0)\"";
            ClassString = "ColumnsSelector";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnagexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(114), 3, 0)+","+"null"+");", "Exportar", bttBtnagexport_Jsonclick, 0, "Exportar", "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\webfunil.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "hidden-xs";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtneditcolumns_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(114), 3, 0)+","+"null"+");", "Selecionar colunas", bttBtneditcolumns_Jsonclick, 0, "Selecionar colunas", "", StyleString, ClassString, bttBtneditcolumns_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\webfunil.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnsubscriptions_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(114), 3, 0)+","+"null"+");", "", bttBtnsubscriptions_Jsonclick, 0, "Assinaturas", "", StyleString, ClassString, bttBtnsubscriptions_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\webfunil.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablerightheader_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* User Defined Control */
            ucDdo_managefilters.SetProperty("IconType", Ddo_managefilters_Icontype);
            ucDdo_managefilters.SetProperty("Icon", Ddo_managefilters_Icon);
            ucDdo_managefilters.SetProperty("Caption", Ddo_managefilters_Caption);
            ucDdo_managefilters.SetProperty("Tooltip", Ddo_managefilters_Tooltip);
            ucDdo_managefilters.SetProperty("Cls", Ddo_managefilters_Cls);
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV43ManageFiltersData);
            ucDdo_managefilters.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_managefilters_Internalname, "DDO_MANAGEFILTERSContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, "", "Select List View", "gx-form-item ListViewSelectorAttributeLabel", 0, true, "width: 25%;");
            /* Radio button */
            ClassString = "ListViewSelectorAttribute";
            StyleString = "";
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'" + sGXsfl_114_idx + "',0)\"";
            GxWebStd.gx_radio_ctrl( context, radavSelectlistview, radavSelectlistview_Internalname, StringUtil.RTrim( AV57SelectListView), "", 1, 1, 0, 0, StyleString, ClassString, "", "", 0, radavSelectlistview_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", TempTags+" onclick="+"\""+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "HLP_core\\webfunil.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablefilters_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFilterfulltext_Internalname, "Filter Full Text", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'" + sGXsfl_114_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV23FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV23FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Pesquisar", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_core\\webfunil.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix1_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_core\\webfunil.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector1_Internalname, "Dynamic Filters Selector1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_114_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector1, cmbavDynamicfiltersselector1_Internalname, StringUtil.RTrim( AV24DynamicFiltersSelector1), 1, cmbavDynamicfiltersselector1_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR1.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "", true, 0, "HLP_core\\webfunil.htm");
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", (string)(cmbavDynamicfiltersselector1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle1_Internalname, "valor", "", "", lblDynamicfiltersmiddle1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_core\\webfunil.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            wb_table1_50_4X2( true) ;
         }
         else
         {
            wb_table1_50_4X2( false) ;
         }
         return  ;
      }

      protected void wb_table1_50_4X2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix2_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_core\\webfunil.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector2_Internalname, "Dynamic Filters Selector2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'" + sGXsfl_114_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector2, cmbavDynamicfiltersselector2_Internalname, StringUtil.RTrim( AV28DynamicFiltersSelector2), 1, cmbavDynamicfiltersselector2_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR2.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,68);\"", "", true, 0, "HLP_core\\webfunil.htm");
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV28DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", (string)(cmbavDynamicfiltersselector2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle2_Internalname, "valor", "", "", lblDynamicfiltersmiddle2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_core\\webfunil.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table2_72_4X2( true) ;
         }
         else
         {
            wb_table2_72_4X2( false) ;
         }
         return  ;
      }

      protected void wb_table2_72_4X2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix3_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_core\\webfunil.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector3_Internalname, "Dynamic Filters Selector3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 90,'',false,'" + sGXsfl_114_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector3, cmbavDynamicfiltersselector3_Internalname, StringUtil.RTrim( AV32DynamicFiltersSelector3), 1, cmbavDynamicfiltersselector3_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR3.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,90);\"", "", true, 0, "HLP_core\\webfunil.htm");
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV32DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", (string)(cmbavDynamicfiltersselector3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle3_Internalname, "valor", "", "", lblDynamicfiltersmiddle3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_core\\webfunil.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table3_94_4X2( true) ;
         }
         else
         {
            wb_table3_94_4X2( false) ;
         }
         return  ;
      }

      protected void wb_table3_94_4X2e( bool wbgen )
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
            GxWebStd.gx_div_start( context, divDatawc_cell_Internalname, 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0106"+"", StringUtil.RTrim( WebComp_Datawc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0106"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( bGXsfl_114_Refreshing )
               {
                  if ( StringUtil.Len( WebComp_Datawc_Component) != 0 )
                  {
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldDatawc), StringUtil.Lower( WebComp_Datawc_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0106"+"");
                     }
                     WebComp_Datawc.componentdraw();
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldDatawc), StringUtil.Lower( WebComp_Datawc_Component)) != 0 )
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
            ucDdo_agexport.SetProperty("DropDownOptionsData", AV55AGExportData);
            ucDdo_agexport.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_agexport_Internalname, "DDO_AGEXPORTContainer");
            /* User Defined Control */
            ucDdc_subscriptions.SetProperty("IconType", Ddc_subscriptions_Icontype);
            ucDdc_subscriptions.SetProperty("Icon", Ddc_subscriptions_Icon);
            ucDdc_subscriptions.SetProperty("Caption", Ddc_subscriptions_Caption);
            ucDdc_subscriptions.SetProperty("Tooltip", Ddc_subscriptions_Tooltip);
            ucDdc_subscriptions.SetProperty("Cls", Ddc_subscriptions_Cls);
            ucDdc_subscriptions.Render(context, "dvelop.gxbootstrap.ddcomponent", Ddc_subscriptions_Internalname, "DDC_SUBSCRIPTIONSContainer");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTxtstyleselectlistview_Internalname, lblTxtstyleselectlistview_Caption, "", "", lblTxtstyleselectlistview_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_core\\webfunil.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblJsdynamicfilters_Internalname, lblJsdynamicfilters_Caption, "", "", lblJsdynamicfilters_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_core\\webfunil.htm");
            /*  Grid Control  */
            DummygridContainer.SetWrapped(nGXWrapped);
            StartGridControl114( ) ;
         }
         if ( wbEnd == 114 )
         {
            wbEnd = 0;
            nRC_GXsfl_114 = (int)(nGXsfl_114_idx-1);
            if ( DummygridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               AV64GXV3 = nGXsfl_114_idx;
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"DummygridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Dummygrid", DummygridContainer, subDummygrid_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "DummygridContainerData", DummygridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "DummygridContainerData"+"V", DummygridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"DummygridContainerData"+"V"+"\" value='"+DummygridContainer.GridValuesHidden()+"'/>") ;
               }
            }
            /* User Defined Control */
            ucInnewwindow1.Render(context, "innewwindow", Innewwindow1_Internalname, "INNEWWINDOW1Container");
            /* User Defined Control */
            ucDdo_gridcolumnsselector.SetProperty("IconType", Ddo_gridcolumnsselector_Icontype);
            ucDdo_gridcolumnsselector.SetProperty("Icon", Ddo_gridcolumnsselector_Icon);
            ucDdo_gridcolumnsselector.SetProperty("Caption", Ddo_gridcolumnsselector_Caption);
            ucDdo_gridcolumnsselector.SetProperty("Tooltip", Ddo_gridcolumnsselector_Tooltip);
            ucDdo_gridcolumnsselector.SetProperty("Cls", Ddo_gridcolumnsselector_Cls);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsType", Ddo_gridcolumnsselector_Dropdownoptionstype);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsTitleSettingsIcons", AV52DDO_TitleSettingsIcons);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsData", AV41ColumnsSelector);
            ucDdo_gridcolumnsselector.Render(context, "dvelop.gxbootstrap.ddogridcolumnsselector", Ddo_gridcolumnsselector_Internalname, "DDO_GRIDCOLUMNSSELECTORContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDiv_selectlistview_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0119"+"", StringUtil.RTrim( WebComp_Selectlistview_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0119"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( bGXsfl_114_Refreshing )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldSelectlistview_wc), StringUtil.Lower( WebComp_Selectlistview_wc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0119"+"");
                  }
                  WebComp_Selectlistview_wc.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldSelectlistview_wc), StringUtil.Lower( WebComp_Selectlistview_wc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDiv_wwpauxwc_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0121"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0121"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( bGXsfl_114_Refreshing )
               {
                  if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                  {
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0121"+"");
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
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 114 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( DummygridContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  AV64GXV3 = nGXsfl_114_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"DummygridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Dummygrid", DummygridContainer, subDummygrid_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "DummygridContainerData", DummygridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "DummygridContainerData"+"V", DummygridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"DummygridContainerData"+"V"+"\" value='"+DummygridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START4X2( )
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
            Form.Meta.addItem("description", "Funil de Vendas", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP4X0( ) ;
      }

      protected void WS4X2( )
      {
         START4X2( ) ;
         EVT4X2( ) ;
      }

      protected void EVT4X2( )
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
                              E114X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_AGEXPORT.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E124X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDC_SUBSCRIPTIONS.ONLOADCOMPONENT") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E134X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E144X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GLOBALEVENTS.LISTVIEW_UPDATELISTFILTERS") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E154X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters1' */
                              E164X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters2' */
                              E174X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS3'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters3' */
                              E184X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VSELECTLISTVIEW.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E194X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOADICIONAROPORTUNIDADE'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoAdicionarOportunidade' */
                              E204X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GLOBALEVENTS.REFRESHGRIDPARENT") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E214X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR1.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E224X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR2.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E234X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR3.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E244X2 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 14), "DUMMYGRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              nGXsfl_114_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_114_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_114_idx), 4, 0), 4, "0");
                              SubsflControlProps_1142( ) ;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E254X2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E264X2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "DUMMYGRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E274X2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
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
                        if ( nCmpId == 106 )
                        {
                           OldDatawc = cgiGet( "W0106");
                           if ( ( StringUtil.Len( OldDatawc) == 0 ) || ( StringUtil.StrCmp(OldDatawc, WebComp_Datawc_Component) != 0 ) )
                           {
                              WebComp_Datawc = getWebComponent(GetType(), "GeneXus.Programs", OldDatawc, new Object[] {context} );
                              WebComp_Datawc.ComponentInit();
                              WebComp_Datawc.Name = "OldDatawc";
                              WebComp_Datawc_Component = OldDatawc;
                           }
                           if ( StringUtil.Len( WebComp_Datawc_Component) != 0 )
                           {
                              WebComp_Datawc.componentprocess("W0106", "", sEvt);
                           }
                           WebComp_Datawc_Component = OldDatawc;
                        }
                        else if ( nCmpId == 119 )
                        {
                           OldSelectlistview_wc = cgiGet( "W0119");
                           if ( ( StringUtil.Len( OldSelectlistview_wc) == 0 ) || ( StringUtil.StrCmp(OldSelectlistview_wc, WebComp_Selectlistview_wc_Component) != 0 ) )
                           {
                              WebComp_Selectlistview_wc = getWebComponent(GetType(), "GeneXus.Programs", OldSelectlistview_wc, new Object[] {context} );
                              WebComp_Selectlistview_wc.ComponentInit();
                              WebComp_Selectlistview_wc.Name = "OldSelectlistview_wc";
                              WebComp_Selectlistview_wc_Component = OldSelectlistview_wc;
                           }
                           WebComp_Selectlistview_wc.componentprocess("W0119", "", sEvt);
                           WebComp_Selectlistview_wc_Component = OldSelectlistview_wc;
                        }
                        else if ( nCmpId == 121 )
                        {
                           OldWwpaux_wc = cgiGet( "W0121");
                           if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                           {
                              WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                              WebComp_Wwpaux_wc.ComponentInit();
                              WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                              WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                           }
                           if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                           {
                              WebComp_Wwpaux_wc.componentprocess("W0121", "", sEvt);
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

      protected void WE4X2( )
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

      protected void PA4X2( )
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
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrDummygrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_1142( ) ;
         while ( nGXsfl_114_idx <= nRC_GXsfl_114 )
         {
            sendrow_1142( ) ;
            nGXsfl_114_idx = ((subDummygrid_Islastpage==1)&&(nGXsfl_114_idx+1>subDummygrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_114_idx+1);
            sGXsfl_114_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_114_idx), 4, 0), 4, "0");
            SubsflControlProps_1142( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( DummygridContainer)) ;
         /* End function gxnrDummygrid_newrow */
      }

      protected void gxgrDummygrid_refresh( short AV45ManageFiltersExecutionStep ,
                                            string AV62Pgmname ,
                                            bool AV21OrderedDsc ,
                                            string AV23FilterFullText ,
                                            string AV46TFIteNome ,
                                            string AV47TFIteNome_Sel ,
                                            GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ,
                                            bool AV36DynamicFiltersIgnoreFirst ,
                                            string AV24DynamicFiltersSelector1 ,
                                            string AV26IteNome1 ,
                                            short AV25DynamicFiltersOperator1 ,
                                            bool AV35DynamicFiltersRemoving ,
                                            bool AV27DynamicFiltersEnabled2 ,
                                            string AV28DynamicFiltersSelector2 ,
                                            string AV30IteNome2 ,
                                            short AV29DynamicFiltersOperator2 ,
                                            bool AV31DynamicFiltersEnabled3 ,
                                            string AV32DynamicFiltersSelector3 ,
                                            string AV34IteNome3 ,
                                            short AV33DynamicFiltersOperator3 ,
                                            string AV57SelectListView ,
                                            bool AV61IsAuthorized_AdicionarOportunidade )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         DUMMYGRID_nCurrentRecord = 0;
         RF4X2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrDummygrid_refresh */
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
         AssignAttri("", false, "AV57SelectListView", AV57SelectListView);
         if ( cmbavDynamicfiltersselector1.ItemCount > 0 )
         {
            AV24DynamicFiltersSelector1 = cmbavDynamicfiltersselector1.getValidValue(AV24DynamicFiltersSelector1);
            AssignAttri("", false, "AV24DynamicFiltersSelector1", AV24DynamicFiltersSelector1);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator1.ItemCount > 0 )
         {
            AV25DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator1), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV25DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator1), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator1), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
            AV28DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV28DynamicFiltersSelector2);
            AssignAttri("", false, "AV28DynamicFiltersSelector2", AV28DynamicFiltersSelector2);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV28DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV29DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator2), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV29DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV29DynamicFiltersOperator2), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV32DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV32DynamicFiltersSelector3);
            AssignAttri("", false, "AV32DynamicFiltersSelector3", AV32DynamicFiltersSelector3);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV32DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV33DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV33DynamicFiltersOperator3), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV33DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV33DynamicFiltersOperator3), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV33DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF4X2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV62Pgmname = "core.webfunil";
      }

      protected void RF4X2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            DummygridContainer.ClearRows();
         }
         wbStart = 114;
         /* Execute user event: Refresh */
         E264X2 ();
         nGXsfl_114_idx = 1;
         sGXsfl_114_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_114_idx), 4, 0), 4, "0");
         SubsflControlProps_1142( ) ;
         bGXsfl_114_Refreshing = true;
         DummygridContainer.AddObjectProperty("GridName", "Dummygrid");
         DummygridContainer.AddObjectProperty("CmpContext", "");
         DummygridContainer.AddObjectProperty("InMasterPage", "false");
         DummygridContainer.AddObjectProperty("Class", "Grid");
         DummygridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         DummygridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         DummygridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subDummygrid_Backcolorstyle), 1, 0, ".", "")));
         DummygridContainer.PageSize = subDummygrid_fnc_Recordsperpage( );
         if ( subDummygrid_Islastpage != 0 )
         {
            DUMMYGRID_nFirstRecordOnPage = (long)(subDummygrid_fnc_Recordcount( )-subDummygrid_fnc_Recordsperpage( ));
            GxWebStd.gx_hidden_field( context, "DUMMYGRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(DUMMYGRID_nFirstRecordOnPage), 15, 0, ".", "")));
            DummygridContainer.AddObjectProperty("DUMMYGRID_nFirstRecordOnPage", DUMMYGRID_nFirstRecordOnPage);
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Datawc_Component) != 0 )
               {
                  WebComp_Datawc.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               WebComp_Selectlistview_wc.componentstart();
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
            SubsflControlProps_1142( ) ;
            E274X2 ();
            wbEnd = 114;
            WB4X0( ) ;
         }
         bGXsfl_114_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes4X2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV62Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV62Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_ADICIONAROPORTUNIDADE", AV61IsAuthorized_AdicionarOportunidade);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_ADICIONAROPORTUNIDADE", GetSecureSignedToken( "", AV61IsAuthorized_AdicionarOportunidade, context));
      }

      protected int subDummygrid_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subDummygrid_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subDummygrid_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subDummygrid_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void before_start_formulas( )
      {
         AV62Pgmname = "core.webfunil";
         fix_multi_value_controls( ) ;
      }

      protected void STRUP4X0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E254X2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV43ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vAGEXPORTDATA"), AV55AGExportData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV52DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vCOLUMNSSELECTOR"), AV41ColumnsSelector);
            /* Read saved values. */
            nRC_GXsfl_114 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_114"), ",", "."), 18, MidpointRounding.ToEven));
            AV31DynamicFiltersEnabled3 = StringUtil.StrToBool( cgiGet( "vDYNAMICFILTERSENABLED3"));
            AV27DynamicFiltersEnabled2 = StringUtil.StrToBool( cgiGet( "vDYNAMICFILTERSENABLED2"));
            subDummygrid_Recordcount = (int)(Math.Round(context.localUtil.CToN( cgiGet( "subDummygrid_Recordcount"), ",", "."), 18, MidpointRounding.ToEven));
            Ddo_managefilters_Icontype = cgiGet( "DDO_MANAGEFILTERS_Icontype");
            Ddo_managefilters_Icon = cgiGet( "DDO_MANAGEFILTERS_Icon");
            Ddo_managefilters_Tooltip = cgiGet( "DDO_MANAGEFILTERS_Tooltip");
            Ddo_managefilters_Cls = cgiGet( "DDO_MANAGEFILTERS_Cls");
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
            Innewwindow1_Width = cgiGet( "INNEWWINDOW1_Width");
            Innewwindow1_Height = cgiGet( "INNEWWINDOW1_Height");
            Innewwindow1_Target = cgiGet( "INNEWWINDOW1_Target");
            Ddo_gridcolumnsselector_Icontype = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Icontype");
            Ddo_gridcolumnsselector_Icon = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Icon");
            Ddo_gridcolumnsselector_Caption = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Caption");
            Ddo_gridcolumnsselector_Tooltip = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Tooltip");
            Ddo_gridcolumnsselector_Cls = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Cls");
            Ddo_gridcolumnsselector_Dropdownoptionstype = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Dropdownoptionstype");
            Ddo_gridcolumnsselector_Visible = StringUtil.StrToBool( cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Visible"));
            Ddo_gridcolumnsselector_Gridinternalname = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Gridinternalname");
            Ddo_gridcolumnsselector_Titlecontrolidtoreplace = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Titlecontrolidtoreplace");
            Ddo_gridcolumnsselector_Columnsselectorvalues = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues");
            Ddo_managefilters_Activeeventkey = cgiGet( "DDO_MANAGEFILTERS_Activeeventkey");
            Ddo_agexport_Activeeventkey = cgiGet( "DDO_AGEXPORT_Activeeventkey");
            /* Read variables values. */
            AV57SelectListView = cgiGet( radavSelectlistview_Internalname);
            AssignAttri("", false, "AV57SelectListView", AV57SelectListView);
            AV23FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV23FilterFullText", AV23FilterFullText);
            cmbavDynamicfiltersselector1.Name = cmbavDynamicfiltersselector1_Internalname;
            cmbavDynamicfiltersselector1.CurrentValue = cgiGet( cmbavDynamicfiltersselector1_Internalname);
            AV24DynamicFiltersSelector1 = cgiGet( cmbavDynamicfiltersselector1_Internalname);
            AssignAttri("", false, "AV24DynamicFiltersSelector1", AV24DynamicFiltersSelector1);
            cmbavDynamicfiltersoperator1.Name = cmbavDynamicfiltersoperator1_Internalname;
            cmbavDynamicfiltersoperator1.CurrentValue = cgiGet( cmbavDynamicfiltersoperator1_Internalname);
            AV25DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator1_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV25DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator1), 4, 0));
            AV26IteNome1 = StringUtil.Upper( cgiGet( edtavItenome1_Internalname));
            AssignAttri("", false, "AV26IteNome1", AV26IteNome1);
            cmbavDynamicfiltersselector2.Name = cmbavDynamicfiltersselector2_Internalname;
            cmbavDynamicfiltersselector2.CurrentValue = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AV28DynamicFiltersSelector2 = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AssignAttri("", false, "AV28DynamicFiltersSelector2", AV28DynamicFiltersSelector2);
            cmbavDynamicfiltersoperator2.Name = cmbavDynamicfiltersoperator2_Internalname;
            cmbavDynamicfiltersoperator2.CurrentValue = cgiGet( cmbavDynamicfiltersoperator2_Internalname);
            AV29DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator2_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV29DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV29DynamicFiltersOperator2), 4, 0));
            AV30IteNome2 = StringUtil.Upper( cgiGet( edtavItenome2_Internalname));
            AssignAttri("", false, "AV30IteNome2", AV30IteNome2);
            cmbavDynamicfiltersselector3.Name = cmbavDynamicfiltersselector3_Internalname;
            cmbavDynamicfiltersselector3.CurrentValue = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AV32DynamicFiltersSelector3 = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AssignAttri("", false, "AV32DynamicFiltersSelector3", AV32DynamicFiltersSelector3);
            cmbavDynamicfiltersoperator3.Name = cmbavDynamicfiltersoperator3_Internalname;
            cmbavDynamicfiltersoperator3.CurrentValue = cgiGet( cmbavDynamicfiltersoperator3_Internalname);
            AV33DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator3_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV33DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV33DynamicFiltersOperator3), 4, 0));
            AV34IteNome3 = StringUtil.Upper( cgiGet( edtavItenome3_Internalname));
            AssignAttri("", false, "AV34IteNome3", AV34IteNome3);
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
         E254X2 ();
         if (returnInSub) return;
      }

      protected void E254X2( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Object Property */
         if ( true )
         {
            bDynCreated_Datawc = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Datawc_Component), StringUtil.Lower( "core.webfunilCardSmallImageAndInfoView")) != 0 )
         {
            WebComp_Datawc = getWebComponent(GetType(), "GeneXus.Programs", "core.webfunilcardsmallimageandinfoview", new Object[] {context} );
            WebComp_Datawc.ComponentInit();
            WebComp_Datawc.Name = "core.webfunilCardSmallImageAndInfoView";
            WebComp_Datawc_Component = "core.webfunilCardSmallImageAndInfoView";
         }
         if ( StringUtil.Len( WebComp_Datawc_Component) != 0 )
         {
            WebComp_Datawc.setjustcreated();
            WebComp_Datawc.componentprepare(new Object[] {(string)"W0106",(string)""});
            WebComp_Datawc.componentbind(new Object[] {});
         }
         bttBtneditcolumns_Visible = 0;
         AssignProp("", false, bttBtneditcolumns_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtneditcolumns_Visible), 5, 0), true);
         lblTxtstyleselectlistview_Caption = "<script>";
         AssignProp("", false, lblTxtstyleselectlistview_Internalname, "Caption", lblTxtstyleselectlistview_Caption, true);
         lblTxtstyleselectlistview_Caption = lblTxtstyleselectlistview_Caption+StringUtil.Format( "WWP_CreateFontIcon(`label[for='%1%2']`, `fas fa-grip`);", radavSelectlistview_Internalname, "1", "", "", "", "", "", "", "");
         AssignProp("", false, lblTxtstyleselectlistview_Internalname, "Caption", lblTxtstyleselectlistview_Caption, true);
         lblTxtstyleselectlistview_Caption = lblTxtstyleselectlistview_Caption+StringUtil.Format( "WWP_CreateFontIcon(`label[for='%1%2']`, `fas fa-table-list`);", radavSelectlistview_Internalname, "2", "", "", "", "", "", "", "");
         AssignProp("", false, lblTxtstyleselectlistview_Internalname, "Caption", lblTxtstyleselectlistview_Caption, true);
         lblTxtstyleselectlistview_Caption = lblTxtstyleselectlistview_Caption+"</script>";
         AssignProp("", false, lblTxtstyleselectlistview_Internalname, "Caption", lblTxtstyleselectlistview_Caption, true);
         Ddo_gridcolumnsselector_Gridinternalname = "<LISTVIEW>GRID";
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "GridInternalName", Ddo_gridcolumnsselector_Gridinternalname);
         if ( StringUtil.StrCmp(AV8HTTPRequest.Method, "GET") == 0 )
         {
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if (returnInSub) return;
         }
         lblJsdynamicfilters_Caption = "";
         AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         AV24DynamicFiltersSelector1 = "ITENOME";
         AssignAttri("", false, "AV24DynamicFiltersSelector1", AV24DynamicFiltersSelector1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if (returnInSub) return;
         AV28DynamicFiltersSelector2 = "ITENOME";
         AssignAttri("", false, "AV28DynamicFiltersSelector2", AV28DynamicFiltersSelector2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if (returnInSub) return;
         AV32DynamicFiltersSelector3 = "ITENOME";
         AssignAttri("", false, "AV32DynamicFiltersSelector3", AV32DynamicFiltersSelector3);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
         S142 ();
         if (returnInSub) return;
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
         AV55AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV56AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV56AGExportDataItem.gxTpr_Title = "Excel";
         AV56AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "da69a816-fd11-445b-8aaf-1a2f7f1acc93", "", context.GetTheme( ))));
         AV56AGExportDataItem.gxTpr_Eventkey = "Export";
         AV56AGExportDataItem.gxTpr_Isdivider = false;
         AV55AGExportData.Add(AV56AGExportDataItem, 0);
         AV56AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV56AGExportDataItem.gxTpr_Title = "PDF";
         AV56AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "776fb79c-a0a1-4302-b5e5-d773dbe1a297", "", context.GetTheme( ))));
         AV56AGExportDataItem.gxTpr_Eventkey = "ExportReport";
         AV56AGExportDataItem.gxTpr_Isdivider = false;
         AV55AGExportData.Add(AV56AGExportDataItem, 0);
         Ddc_subscriptions_Titlecontrolidtoreplace = bttBtnsubscriptions_Internalname;
         ucDdc_subscriptions.SendProperty(context, "", false, Ddc_subscriptions_Internalname, "TitleControlIdToReplace", Ddc_subscriptions_Titlecontrolidtoreplace);
         Form.Caption = "Funil de Vendas";
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S152 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S162 ();
         if (returnInSub) return;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV52DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV52DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = bttBtneditcolumns_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "TitleControlIdToReplace", Ddo_gridcolumnsselector_Titlecontrolidtoreplace);
      }

      protected void E264X2( )
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
         S172 ();
         if (returnInSub) return;
         if ( AV45ManageFiltersExecutionStep == 1 )
         {
            AV45ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV45ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV45ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV45ManageFiltersExecutionStep == 2 )
         {
            AV45ManageFiltersExecutionStep = 0;
            AssignAttri("", false, "AV45ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV45ManageFiltersExecutionStep), 1, 0));
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if (returnInSub) return;
         }
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S182 ();
         if (returnInSub) return;
         if ( StringUtil.StrCmp(AV16Session.Get("core.webfunilColumnsSelector"), "") != 0 )
         {
            AV39ColumnsSelectorXML = AV16Session.Get("core.webfunilColumnsSelector");
            AV41ColumnsSelector.FromXml(AV39ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S192 ();
            if (returnInSub) return;
         }
         this.executeExternalObjectMethod("", false, "GlobalEvents", "ListView_RefreshView", new Object[] {}, true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ColumnsSelector", AV41ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV43ManageFiltersData", AV43ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E154X2( )
      {
         /* General\GlobalEvents_Listview_updatelistfilters Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CLEANFILTERS' */
         S202 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S162 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV28DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV32DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV33DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
      }

      protected void E144X2( )
      {
         /* Ddo_gridcolumnsselector_Oncolumnschanged Routine */
         returnInSub = false;
         AV39ColumnsSelectorXML = Ddo_gridcolumnsselector_Columnsselectorvalues;
         AV41ColumnsSelector.FromJSonString(AV39ColumnsSelectorXML, null);
         new GeneXus.Programs.wwpbaseobjects.savecolumnsselectorstate(context ).execute(  "core.webfunilColumnsSelector",  (String.IsNullOrEmpty(StringUtil.RTrim( AV39ColumnsSelectorXML)) ? "" : AV41ColumnsSelector.ToXml(false, true, "", ""))) ;
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ColumnsSelector", AV41ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV43ManageFiltersData", AV43ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E164X2( )
      {
         /* 'RemoveDynamicFilters1' Routine */
         returnInSub = false;
         AV35DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV35DynamicFiltersRemoving", AV35DynamicFiltersRemoving);
         AV36DynamicFiltersIgnoreFirst = true;
         AssignAttri("", false, "AV36DynamicFiltersIgnoreFirst", AV36DynamicFiltersIgnoreFirst);
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S212 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'RESETDYNFILTERS' */
         S222 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S232 ();
         if (returnInSub) return;
         AV35DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV35DynamicFiltersRemoving", AV35DynamicFiltersRemoving);
         AV36DynamicFiltersIgnoreFirst = false;
         AssignAttri("", false, "AV36DynamicFiltersIgnoreFirst", AV36DynamicFiltersIgnoreFirst);
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV28DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV32DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV33DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ColumnsSelector", AV41ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV43ManageFiltersData", AV43ManageFiltersData);
      }

      protected void E224X2( )
      {
         /* Dynamicfiltersselector1_Click Routine */
         returnInSub = false;
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void E174X2( )
      {
         /* 'RemoveDynamicFilters2' Routine */
         returnInSub = false;
         AV35DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV35DynamicFiltersRemoving", AV35DynamicFiltersRemoving);
         AV27DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV27DynamicFiltersEnabled2", AV27DynamicFiltersEnabled2);
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S212 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'RESETDYNFILTERS' */
         S222 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S232 ();
         if (returnInSub) return;
         AV35DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV35DynamicFiltersRemoving", AV35DynamicFiltersRemoving);
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV28DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV32DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV33DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ColumnsSelector", AV41ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV43ManageFiltersData", AV43ManageFiltersData);
      }

      protected void E234X2( )
      {
         /* Dynamicfiltersselector2_Click Routine */
         returnInSub = false;
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void E184X2( )
      {
         /* 'RemoveDynamicFilters3' Routine */
         returnInSub = false;
         AV35DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV35DynamicFiltersRemoving", AV35DynamicFiltersRemoving);
         AV31DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV31DynamicFiltersEnabled3", AV31DynamicFiltersEnabled3);
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S212 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'RESETDYNFILTERS' */
         S222 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S232 ();
         if (returnInSub) return;
         AV35DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV35DynamicFiltersRemoving", AV35DynamicFiltersRemoving);
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV28DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV32DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV33DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ColumnsSelector", AV41ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV43ManageFiltersData", AV43ManageFiltersData);
      }

      protected void E244X2( )
      {
         /* Dynamicfiltersselector3_Click Routine */
         returnInSub = false;
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
         S142 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void E114X2( )
      {
         /* Ddo_managefilters_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Clean#>") == 0 )
         {
            /* Execute user subroutine: 'CLEANFILTERS' */
            S202 ();
            if (returnInSub) return;
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Save#>") == 0 )
         {
            /* Execute user subroutine: 'SAVEGRIDSTATE' */
            S182 ();
            if (returnInSub) return;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wwpbaseobjects.savefilteras.aspx"+UrlEncode(StringUtil.RTrim("core.webfunilFilters")) + "," + UrlEncode(StringUtil.RTrim(AV62Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV45ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV45ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV45ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wwpbaseobjects.managefilters.aspx"+UrlEncode(StringUtil.RTrim("core.webfunilFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV45ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV45ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV45ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char2 = AV44ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "core.webfunilFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char2) ;
            AV44ManageFiltersXml = GXt_char2;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV44ManageFiltersXml)) )
            {
               GX_msglist.addItem("O filtro selecionado não existe mais.");
            }
            else
            {
               /* Execute user subroutine: 'CLEANFILTERS' */
               S202 ();
               if (returnInSub) return;
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV62Pgmname+"GridState",  AV44ManageFiltersXml) ;
               AV11GridState.FromXml(AV44ManageFiltersXml, null, "", "");
               AV21OrderedDsc = AV11GridState.gxTpr_Ordereddsc;
               AssignAttri("", false, "AV21OrderedDsc", AV21OrderedDsc);
               /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
               S242 ();
               if (returnInSub) return;
               /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
               S232 ();
               if (returnInSub) return;
               context.DoAjaxRefresh();
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV28DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV32DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV33DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ColumnsSelector", AV41ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV43ManageFiltersData", AV43ManageFiltersData);
      }

      protected void E194X2( )
      {
         /* Selectlistview_Controlvaluechanged Routine */
         returnInSub = false;
         AV11GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV62Pgmname+"GridState"), null, "", "");
         AV11GridState.gxTpr_Currentpage = 1;
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV62Pgmname+"GridState",  AV11GridState.ToXml(false, true, "", "")) ;
         if ( StringUtil.StrCmp(AV57SelectListView, "CardSmallImageAndInfoView") == 0 )
         {
            /* Object Property */
            if ( true )
            {
               bDynCreated_Datawc = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Datawc_Component), StringUtil.Lower( "core.webfunilCardSmallImageAndInfoView")) != 0 )
            {
               WebComp_Datawc = getWebComponent(GetType(), "GeneXus.Programs", "core.webfunilcardsmallimageandinfoview", new Object[] {context} );
               WebComp_Datawc.ComponentInit();
               WebComp_Datawc.Name = "core.webfunilCardSmallImageAndInfoView";
               WebComp_Datawc_Component = "core.webfunilCardSmallImageAndInfoView";
            }
            if ( StringUtil.Len( WebComp_Datawc_Component) != 0 )
            {
               WebComp_Datawc.setjustcreated();
               WebComp_Datawc.componentprepare(new Object[] {(string)"W0106",(string)""});
               WebComp_Datawc.componentbind(new Object[] {});
            }
            if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Datawc )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0106"+"");
               WebComp_Datawc.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
            bttBtneditcolumns_Visible = 0;
            AssignProp("", false, bttBtneditcolumns_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtneditcolumns_Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV57SelectListView, "GridViewIteracoes") == 0 )
         {
            /* Object Property */
            if ( true )
            {
               bDynCreated_Datawc = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Datawc_Component), StringUtil.Lower( "core.webfunilGridViewIteracoes")) != 0 )
            {
               WebComp_Datawc = getWebComponent(GetType(), "GeneXus.Programs", "core.webfunilgridviewiteracoes", new Object[] {context} );
               WebComp_Datawc.ComponentInit();
               WebComp_Datawc.Name = "core.webfunilGridViewIteracoes";
               WebComp_Datawc_Component = "core.webfunilGridViewIteracoes";
            }
            if ( StringUtil.Len( WebComp_Datawc_Component) != 0 )
            {
               WebComp_Datawc.setjustcreated();
               WebComp_Datawc.componentprepare(new Object[] {(string)"W0106",(string)""});
               WebComp_Datawc.componentbind(new Object[] {});
            }
            if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Datawc )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0106"+"");
               WebComp_Datawc.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
            bttBtneditcolumns_Visible = 1;
            AssignProp("", false, bttBtneditcolumns_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtneditcolumns_Visible), 5, 0), true);
            Ddo_gridcolumnsselector_Visible = true;
            ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "Visible", StringUtil.BoolToStr( Ddo_gridcolumnsselector_Visible));
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E204X2( )
      {
         /* 'DoAdicionarOportunidade' Routine */
         returnInSub = false;
         if ( AV61IsAuthorized_AdicionarOportunidade )
         {
            context.PopUp(formatLink("core.negociopjsemfaseprompt.aspx", new object[] {UrlEncode(StringUtil.RTrim("add_oportunidade"))}, new string[] {"NegID_WSKey"}) , new Object[] {});
            context.DoAjaxRefresh();
         }
         else
         {
            GX_msglist.addItem("A ação não encontra-se disponível");
            context.DoAjaxRefresh();
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ColumnsSelector", AV41ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV43ManageFiltersData", AV43ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E124X2( )
      {
         /* Ddo_agexport_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_agexport_Activeeventkey, "Export") == 0 )
         {
            /* Execute user subroutine: 'DOEXPORT' */
            S252 ();
            if (returnInSub) return;
         }
         else if ( StringUtil.StrCmp(Ddo_agexport_Activeeventkey, "ExportReport") == 0 )
         {
            /* Execute user subroutine: 'DOEXPORTREPORT' */
            S262 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV24DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV28DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV32DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV33DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
      }

      protected void E134X2( )
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
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"W0121",(string)"",(string)"Iteracao",(short)1,(string)"",(string)""});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0121"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void S192( )
      {
         /* 'INITIALIZECOLUMNSSELECTOR' Routine */
         returnInSub = false;
         AV41ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV41ColumnsSelector,  "IteNome",  "",  "Iteração",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV41ColumnsSelector,  "IteQtdeOportunidades",  "",  "Quantidade de Oportunidades",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV41ColumnsSelector,  "IteTotalOportunidades",  "",  "Total em Oportunidades",  true,  "") ;
         GXt_char2 = AV40UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "core.webfunilColumnsSelector", out  GXt_char2) ;
         AV40UserCustomValue = GXt_char2;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV40UserCustomValue)) ) )
         {
            AV42ColumnsSelectorAux.FromXml(AV40UserCustomValue, null, "", "");
            new GeneXus.Programs.wwpbaseobjects.wwp_columnselector_updatecolumns(context ).execute( ref  AV42ColumnsSelectorAux, ref  AV41ColumnsSelector) ;
         }
      }

      protected void S172( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         GXt_boolean3 = AV61IsAuthorized_AdicionarOportunidade;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "negociopjprompt_Execute", out  GXt_boolean3) ;
         AV61IsAuthorized_AdicionarOportunidade = GXt_boolean3;
         AssignAttri("", false, "AV61IsAuthorized_AdicionarOportunidade", AV61IsAuthorized_AdicionarOportunidade);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_ADICIONAROPORTUNIDADE", GetSecureSignedToken( "", AV61IsAuthorized_AdicionarOportunidade, context));
         if ( ! ( AV61IsAuthorized_AdicionarOportunidade ) )
         {
            bttBtnadicionaroportunidade_Visible = 0;
            AssignProp("", false, bttBtnadicionaroportunidade_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnadicionaroportunidade_Visible), 5, 0), true);
         }
         if ( ! ( new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_hassubscriptionstodisplay(context).executeUdp(  "Iteracao",  1) ) )
         {
            bttBtnsubscriptions_Visible = 0;
            AssignProp("", false, bttBtnsubscriptions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnsubscriptions_Visible), 5, 0), true);
         }
      }

      protected void S122( )
      {
         /* 'ENABLEDYNAMICFILTERS1' Routine */
         returnInSub = false;
         edtavItenome1_Visible = 0;
         AssignProp("", false, edtavItenome1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavItenome1_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator1.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV24DynamicFiltersSelector1, "ITENOME") == 0 )
         {
            edtavItenome1_Visible = 1;
            AssignProp("", false, edtavItenome1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavItenome1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
      }

      protected void S132( )
      {
         /* 'ENABLEDYNAMICFILTERS2' Routine */
         returnInSub = false;
         edtavItenome2_Visible = 0;
         AssignProp("", false, edtavItenome2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavItenome2_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator2.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV28DynamicFiltersSelector2, "ITENOME") == 0 )
         {
            edtavItenome2_Visible = 1;
            AssignProp("", false, edtavItenome2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavItenome2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
      }

      protected void S142( )
      {
         /* 'ENABLEDYNAMICFILTERS3' Routine */
         returnInSub = false;
         edtavItenome3_Visible = 0;
         AssignProp("", false, edtavItenome3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavItenome3_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator3.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV32DynamicFiltersSelector3, "ITENOME") == 0 )
         {
            edtavItenome3_Visible = 1;
            AssignProp("", false, edtavItenome3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavItenome3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
      }

      protected void S222( )
      {
         /* 'RESETDYNFILTERS' Routine */
         returnInSub = false;
         AV27DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV27DynamicFiltersEnabled2", AV27DynamicFiltersEnabled2);
         AV28DynamicFiltersSelector2 = "ITENOME";
         AssignAttri("", false, "AV28DynamicFiltersSelector2", AV28DynamicFiltersSelector2);
         AV29DynamicFiltersOperator2 = 0;
         AssignAttri("", false, "AV29DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV29DynamicFiltersOperator2), 4, 0));
         AV30IteNome2 = "";
         AssignAttri("", false, "AV30IteNome2", AV30IteNome2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if (returnInSub) return;
         AV31DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV31DynamicFiltersEnabled3", AV31DynamicFiltersEnabled3);
         AV32DynamicFiltersSelector3 = "ITENOME";
         AssignAttri("", false, "AV32DynamicFiltersSelector3", AV32DynamicFiltersSelector3);
         AV33DynamicFiltersOperator3 = 0;
         AssignAttri("", false, "AV33DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV33DynamicFiltersOperator3), 4, 0));
         AV34IteNome3 = "";
         AssignAttri("", false, "AV34IteNome3", AV34IteNome3);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
         S142 ();
         if (returnInSub) return;
      }

      protected void S112( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = AV43ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "core.webfunilFilters",  "WWPDynFilterHideAll_AL('%1', 3, 0)",  divTabledynamicfilters_Internalname,  true, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4) ;
         AV43ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4;
      }

      protected void S202( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV23FilterFullText = "";
         AssignAttri("", false, "AV23FilterFullText", AV23FilterFullText);
         AV46TFIteNome = "";
         AssignAttri("", false, "AV46TFIteNome", AV46TFIteNome);
         AV47TFIteNome_Sel = "";
         AssignAttri("", false, "AV47TFIteNome_Sel", AV47TFIteNome_Sel);
         AV24DynamicFiltersSelector1 = "ITENOME";
         AssignAttri("", false, "AV24DynamicFiltersSelector1", AV24DynamicFiltersSelector1);
         AV25DynamicFiltersOperator1 = 0;
         AssignAttri("", false, "AV25DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator1), 4, 0));
         AV26IteNome1 = "";
         AssignAttri("", false, "AV26IteNome1", AV26IteNome1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'RESETDYNFILTERS' */
         S222 ();
         if (returnInSub) return;
         AV11GridState.gxTpr_Dynamicfilters.Clear();
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S232 ();
         if (returnInSub) return;
      }

      protected void S162( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV16Session.Get(AV62Pgmname+"GridState"), "") == 0 )
         {
            AV11GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV62Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV11GridState.FromXml(AV16Session.Get(AV62Pgmname+"GridState"), null, "", "");
         }
         AV21OrderedDsc = AV11GridState.gxTpr_Ordereddsc;
         AssignAttri("", false, "AV21OrderedDsc", AV21OrderedDsc);
         /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
         S242 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S232 ();
         if (returnInSub) return;
      }

      protected void S242( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV63GXV2 = 1;
         while ( AV63GXV2 <= AV11GridState.gxTpr_Filtervalues.Count )
         {
            AV12GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV11GridState.gxTpr_Filtervalues.Item(AV63GXV2));
            if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV23FilterFullText = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV23FilterFullText", AV23FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFITENOME") == 0 )
            {
               AV46TFIteNome = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV46TFIteNome", AV46TFIteNome);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFITENOME_SEL") == 0 )
            {
               AV47TFIteNome_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV47TFIteNome_Sel", AV47TFIteNome_Sel);
            }
            AV63GXV2 = (int)(AV63GXV2+1);
         }
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
            AV19GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV11GridState.gxTpr_Dynamicfilters.Item(1));
            AV24DynamicFiltersSelector1 = AV19GridStateDynamicFilter.gxTpr_Selected;
            AssignAttri("", false, "AV24DynamicFiltersSelector1", AV24DynamicFiltersSelector1);
            if ( StringUtil.StrCmp(AV24DynamicFiltersSelector1, "ITENOME") == 0 )
            {
               AV25DynamicFiltersOperator1 = AV19GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV25DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator1), 4, 0));
               AV26IteNome1 = AV19GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV26IteNome1", AV26IteNome1);
            }
            /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
            S122 ();
            if (returnInSub) return;
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
               AV27DynamicFiltersEnabled2 = true;
               AssignAttri("", false, "AV27DynamicFiltersEnabled2", AV27DynamicFiltersEnabled2);
               AV19GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV11GridState.gxTpr_Dynamicfilters.Item(2));
               AV28DynamicFiltersSelector2 = AV19GridStateDynamicFilter.gxTpr_Selected;
               AssignAttri("", false, "AV28DynamicFiltersSelector2", AV28DynamicFiltersSelector2);
               if ( StringUtil.StrCmp(AV28DynamicFiltersSelector2, "ITENOME") == 0 )
               {
                  AV29DynamicFiltersOperator2 = AV19GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV29DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV29DynamicFiltersOperator2), 4, 0));
                  AV30IteNome2 = AV19GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV30IteNome2", AV30IteNome2);
               }
               /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
               S132 ();
               if (returnInSub) return;
               if ( AV11GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  lblJsdynamicfilters_Caption = lblJsdynamicfilters_Caption+StringUtil.Format( "WWPDynFilterShow_AL('%1', 3, 0);", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
                  AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
                  imgAdddynamicfilters2_Visible = 0;
                  AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
                  imgRemovedynamicfilters2_Visible = 1;
                  AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
                  AV31DynamicFiltersEnabled3 = true;
                  AssignAttri("", false, "AV31DynamicFiltersEnabled3", AV31DynamicFiltersEnabled3);
                  AV19GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV11GridState.gxTpr_Dynamicfilters.Item(3));
                  AV32DynamicFiltersSelector3 = AV19GridStateDynamicFilter.gxTpr_Selected;
                  AssignAttri("", false, "AV32DynamicFiltersSelector3", AV32DynamicFiltersSelector3);
                  if ( StringUtil.StrCmp(AV32DynamicFiltersSelector3, "ITENOME") == 0 )
                  {
                     AV33DynamicFiltersOperator3 = AV19GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV33DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV33DynamicFiltersOperator3), 4, 0));
                     AV34IteNome3 = AV19GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV34IteNome3", AV34IteNome3);
                  }
                  /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
                  S142 ();
                  if (returnInSub) return;
               }
               lblJsdynamicfilters_Caption = lblJsdynamicfilters_Caption+"});</script>";
               AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
            }
         }
         if ( AV35DynamicFiltersRemoving )
         {
            lblJsdynamicfilters_Caption = "";
            AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         }
      }

      protected void S182( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV11GridState.FromXml(AV16Session.Get(AV62Pgmname+"GridState"), null, "", "");
         AV11GridState.gxTpr_Ordereddsc = AV21OrderedDsc;
         AV11GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "FILTERFULLTEXT",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV23FilterFullText)),  0,  AV23FilterFullText,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFITENOME",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV46TFIteNome)),  0,  AV46TFIteNome,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV47TFIteNome_Sel)),  AV47TFIteNome_Sel,  "") ;
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S212 ();
         if (returnInSub) return;
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV62Pgmname+"GridState",  AV11GridState.ToXml(false, true, "", "")) ;
      }

      protected void S212( )
      {
         /* 'SAVEDYNFILTERSSTATE' Routine */
         returnInSub = false;
         AV11GridState.gxTpr_Dynamicfilters.Clear();
         if ( ! AV36DynamicFiltersIgnoreFirst )
         {
            AV19GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV19GridStateDynamicFilter.gxTpr_Selected = AV24DynamicFiltersSelector1;
            if ( ( StringUtil.StrCmp(AV24DynamicFiltersSelector1, "ITENOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV26IteNome1)) )
            {
               AV19GridStateDynamicFilter.gxTpr_Value = AV26IteNome1;
               AV19GridStateDynamicFilter.gxTpr_Operator = AV25DynamicFiltersOperator1;
            }
            if ( AV35DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV19GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV11GridState.gxTpr_Dynamicfilters.Add(AV19GridStateDynamicFilter, 0);
            }
         }
         if ( AV27DynamicFiltersEnabled2 )
         {
            AV19GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV19GridStateDynamicFilter.gxTpr_Selected = AV28DynamicFiltersSelector2;
            if ( ( StringUtil.StrCmp(AV28DynamicFiltersSelector2, "ITENOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV30IteNome2)) )
            {
               AV19GridStateDynamicFilter.gxTpr_Value = AV30IteNome2;
               AV19GridStateDynamicFilter.gxTpr_Operator = AV29DynamicFiltersOperator2;
            }
            if ( AV35DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV19GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV11GridState.gxTpr_Dynamicfilters.Add(AV19GridStateDynamicFilter, 0);
            }
         }
         if ( AV31DynamicFiltersEnabled3 )
         {
            AV19GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV19GridStateDynamicFilter.gxTpr_Selected = AV32DynamicFiltersSelector3;
            if ( ( StringUtil.StrCmp(AV32DynamicFiltersSelector3, "ITENOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV34IteNome3)) )
            {
               AV19GridStateDynamicFilter.gxTpr_Value = AV34IteNome3;
               AV19GridStateDynamicFilter.gxTpr_Operator = AV33DynamicFiltersOperator3;
            }
            if ( AV35DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV19GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV11GridState.gxTpr_Dynamicfilters.Add(AV19GridStateDynamicFilter, 0);
            }
         }
      }

      protected void S152( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV9TrnContext.gxTpr_Callerobject = AV62Pgmname;
         AV9TrnContext.gxTpr_Callerondelete = true;
         AV9TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString;
         AV9TrnContext.gxTpr_Transactionname = "core.Iteracao";
         AV16Session.Set("TrnContext", AV9TrnContext.ToXml(false, true, "", ""));
      }

      protected void S252( )
      {
         /* 'DOEXPORT' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S162 ();
         if (returnInSub) return;
         new GeneXus.Programs.core.webfunilexport(context ).execute( out  AV37ExcelFilename, out  AV38ErrorMessage) ;
         if ( StringUtil.StrCmp(AV37ExcelFilename, "") != 0 )
         {
            CallWebObject(formatLink(AV37ExcelFilename) );
            context.wjLocDisableFrm = 0;
         }
         else
         {
            GX_msglist.addItem(AV38ErrorMessage);
         }
      }

      protected void S262( )
      {
         /* 'DOEXPORTREPORT' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S162 ();
         if (returnInSub) return;
         Innewwindow1_Target = formatLink("core.webfunilexportreport.aspx") ;
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Target", Innewwindow1_Target);
         Innewwindow1_Height = "600";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Height", Innewwindow1_Height);
         Innewwindow1_Width = "800";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Width", Innewwindow1_Width);
         this.executeUsercontrolMethod("", false, "INNEWWINDOW1Container", "OpenWindow", "", new Object[] {});
      }

      protected void E214X2( )
      {
         /* General\GlobalEvents_Refreshgridparent Routine */
         returnInSub = false;
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ColumnsSelector", AV41ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV43ManageFiltersData", AV43ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      private void E274X2( )
      {
         /* Dummygrid_Load Routine */
         returnInSub = false;
         AV64GXV3 = 1;
         while ( AV64GXV3 <= AV58DummyGridCollection.Count )
         {
            AV58DummyGridCollection.CurrentItem = ((GeneXus.Utils.SdtMessages_Message)AV58DummyGridCollection.Item(AV64GXV3));
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 114;
            }
            AV64GXV3 = (int)(AV64GXV3+1);
         }
      }

      protected void wb_table3_94_4X2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'',false,'" + sGXsfl_114_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator3, cmbavDynamicfiltersoperator3_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV33DynamicFiltersOperator3), 4, 0)), 1, cmbavDynamicfiltersoperator3_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator3.Visible, cmbavDynamicfiltersoperator3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,98);\"", "", true, 0, "HLP_core\\webfunil.htm");
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV33DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", (string)(cmbavDynamicfiltersoperator3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_itenome3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavItenome3_Internalname, "Ite Nome3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 101,'',false,'" + sGXsfl_114_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavItenome3_Internalname, AV34IteNome3, StringUtil.RTrim( context.localUtil.Format( AV34IteNome3, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,101);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavItenome3_Jsonclick, 0, "Attribute", "", "", "", "", edtavItenome3_Visible, edtavItenome3_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\webfunil.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter3_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 103,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters3_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters3_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters3_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS3\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_core\\webfunil.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_94_4X2e( true) ;
         }
         else
         {
            wb_table3_94_4X2e( false) ;
         }
      }

      protected void wb_table2_72_4X2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_114_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator2, cmbavDynamicfiltersoperator2_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator2), 4, 0)), 1, cmbavDynamicfiltersoperator2_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator2.Visible, cmbavDynamicfiltersoperator2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,76);\"", "", true, 0, "HLP_core\\webfunil.htm");
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", (string)(cmbavDynamicfiltersoperator2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_itenome2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavItenome2_Internalname, "Ite Nome2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'" + sGXsfl_114_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavItenome2_Internalname, AV30IteNome2, StringUtil.RTrim( context.localUtil.Format( AV30IteNome2, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavItenome2_Jsonclick, 0, "Attribute", "", "", "", "", edtavItenome2_Visible, edtavItenome2_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\webfunil.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters2_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters2_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgAdddynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"e284x1_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_core\\webfunil.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters2_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters2_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_core\\webfunil.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_72_4X2e( true) ;
         }
         else
         {
            wb_table2_72_4X2e( false) ;
         }
      }

      protected void wb_table1_50_4X2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'" + sGXsfl_114_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator1, cmbavDynamicfiltersoperator1_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator1), 4, 0)), 1, cmbavDynamicfiltersoperator1_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator1.Visible, cmbavDynamicfiltersoperator1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "", true, 0, "HLP_core\\webfunil.htm");
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator1), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", (string)(cmbavDynamicfiltersoperator1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_itenome1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavItenome1_Internalname, "Ite Nome1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'" + sGXsfl_114_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavItenome1_Internalname, AV26IteNome1, StringUtil.RTrim( context.localUtil.Format( AV26IteNome1, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,57);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavItenome1_Jsonclick, 0, "Attribute", "", "", "", "", edtavItenome1_Visible, edtavItenome1_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\webfunil.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters1_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters1_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgAdddynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"e294x1_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_core\\webfunil.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters1_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters1_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_core\\webfunil.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_50_4X2e( true) ;
         }
         else
         {
            wb_table1_50_4X2e( false) ;
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
         PA4X2( ) ;
         WS4X2( ) ;
         WE4X2( ) ;
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
         if ( ! ( WebComp_Datawc == null ) )
         {
            if ( StringUtil.Len( WebComp_Datawc_Component) != 0 )
            {
               WebComp_Datawc.componentthemes();
            }
         }
         if ( ! ( WebComp_Selectlistview_wc == null ) )
         {
            WebComp_Selectlistview_wc.componentthemes();
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202382823104", true, true);
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
         context.AddJavascriptSource("gxdec.js", "?"+context.GetBuildNumber( 211160), false, true);
         context.AddJavascriptSource("core/webfunil.js", "?202382823107", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_1142( )
      {
      }

      protected void SubsflControlProps_fel_1142( )
      {
      }

      protected void sendrow_1142( )
      {
         SubsflControlProps_1142( ) ;
         WB4X0( ) ;
         DummygridRow = GXWebRow.GetNew(context,DummygridContainer);
         if ( subDummygrid_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subDummygrid_Backstyle = 0;
            if ( StringUtil.StrCmp(subDummygrid_Class, "") != 0 )
            {
               subDummygrid_Linesclass = subDummygrid_Class+"Odd";
            }
         }
         else if ( subDummygrid_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subDummygrid_Backstyle = 0;
            subDummygrid_Backcolor = subDummygrid_Allbackcolor;
            if ( StringUtil.StrCmp(subDummygrid_Class, "") != 0 )
            {
               subDummygrid_Linesclass = subDummygrid_Class+"Uniform";
            }
         }
         else if ( subDummygrid_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subDummygrid_Backstyle = 1;
            if ( StringUtil.StrCmp(subDummygrid_Class, "") != 0 )
            {
               subDummygrid_Linesclass = subDummygrid_Class+"Odd";
            }
            subDummygrid_Backcolor = (int)(0x0);
         }
         else if ( subDummygrid_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subDummygrid_Backstyle = 1;
            if ( ((int)((nGXsfl_114_idx) % (2))) == 0 )
            {
               subDummygrid_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subDummygrid_Class, "") != 0 )
               {
                  subDummygrid_Linesclass = subDummygrid_Class+"Even";
               }
            }
            else
            {
               subDummygrid_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subDummygrid_Class, "") != 0 )
               {
                  subDummygrid_Linesclass = subDummygrid_Class+"Odd";
               }
            }
         }
         if ( DummygridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr ") ;
            context.WriteHtmlText( " class=\""+subDummygrid_Linesclass+"\" style=\""+""+"\"") ;
            context.WriteHtmlText( " gxrow=\""+sGXsfl_114_idx+"\">") ;
         }
         send_integrity_lvl_hashes4X2( ) ;
         DummygridContainer.AddRow(DummygridRow);
         nGXsfl_114_idx = ((subDummygrid_Islastpage==1)&&(nGXsfl_114_idx+1>subDummygrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_114_idx+1);
         sGXsfl_114_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_114_idx), 4, 0), 4, "0");
         SubsflControlProps_1142( ) ;
         /* End function sendrow_1142 */
      }

      protected void init_web_controls( )
      {
         radavSelectlistview.Name = "vSELECTLISTVIEW";
         radavSelectlistview.WebTags = "";
         radavSelectlistview.addItem("CardSmallImageAndInfoView", "", 0);
         radavSelectlistview.addItem("GridViewIteracoes", "", 0);
         cmbavDynamicfiltersselector1.Name = "vDYNAMICFILTERSSELECTOR1";
         cmbavDynamicfiltersselector1.WebTags = "";
         cmbavDynamicfiltersselector1.addItem("ITENOME", "Descrição", 0);
         if ( cmbavDynamicfiltersselector1.ItemCount > 0 )
         {
            AV24DynamicFiltersSelector1 = cmbavDynamicfiltersselector1.getValidValue(AV24DynamicFiltersSelector1);
            AssignAttri("", false, "AV24DynamicFiltersSelector1", AV24DynamicFiltersSelector1);
         }
         cmbavDynamicfiltersoperator1.Name = "vDYNAMICFILTERSOPERATOR1";
         cmbavDynamicfiltersoperator1.WebTags = "";
         cmbavDynamicfiltersoperator1.addItem("0", "Começa com", 0);
         cmbavDynamicfiltersoperator1.addItem("1", "Contém", 0);
         if ( cmbavDynamicfiltersoperator1.ItemCount > 0 )
         {
            AV25DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV25DynamicFiltersOperator1), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV25DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV25DynamicFiltersOperator1), 4, 0));
         }
         cmbavDynamicfiltersselector2.Name = "vDYNAMICFILTERSSELECTOR2";
         cmbavDynamicfiltersselector2.WebTags = "";
         cmbavDynamicfiltersselector2.addItem("ITENOME", "Descrição", 0);
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
            AV28DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV28DynamicFiltersSelector2);
            AssignAttri("", false, "AV28DynamicFiltersSelector2", AV28DynamicFiltersSelector2);
         }
         cmbavDynamicfiltersoperator2.Name = "vDYNAMICFILTERSOPERATOR2";
         cmbavDynamicfiltersoperator2.WebTags = "";
         cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
         cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV29DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator2), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV29DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV29DynamicFiltersOperator2), 4, 0));
         }
         cmbavDynamicfiltersselector3.Name = "vDYNAMICFILTERSSELECTOR3";
         cmbavDynamicfiltersselector3.WebTags = "";
         cmbavDynamicfiltersselector3.addItem("ITENOME", "Descrição", 0);
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV32DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV32DynamicFiltersSelector3);
            AssignAttri("", false, "AV32DynamicFiltersSelector3", AV32DynamicFiltersSelector3);
         }
         cmbavDynamicfiltersoperator3.Name = "vDYNAMICFILTERSOPERATOR3";
         cmbavDynamicfiltersoperator3.WebTags = "";
         cmbavDynamicfiltersoperator3.addItem("0", "Começa com", 0);
         cmbavDynamicfiltersoperator3.addItem("1", "Contém", 0);
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV33DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV33DynamicFiltersOperator3), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV33DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV33DynamicFiltersOperator3), 4, 0));
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl114( )
      {
         if ( DummygridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"DummygridContainer"+"DivS\" data-gxgridid=\"114\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subDummygrid_Internalname, subDummygrid_Internalname, "", "Grid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subDummygrid_Backcolorstyle == 0 )
            {
               subDummygrid_Titlebackstyle = 0;
               if ( StringUtil.Len( subDummygrid_Class) > 0 )
               {
                  subDummygrid_Linesclass = subDummygrid_Class+"Title";
               }
            }
            else
            {
               subDummygrid_Titlebackstyle = 1;
               if ( subDummygrid_Backcolorstyle == 1 )
               {
                  subDummygrid_Titlebackcolor = subDummygrid_Allbackcolor;
                  if ( StringUtil.Len( subDummygrid_Class) > 0 )
                  {
                     subDummygrid_Linesclass = subDummygrid_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subDummygrid_Class) > 0 )
                  {
                     subDummygrid_Linesclass = subDummygrid_Class+"Title";
                  }
               }
            }
            context.WriteHtmlTextNl( "</tr>") ;
            DummygridContainer.AddObjectProperty("GridName", "Dummygrid");
         }
         else
         {
            DummygridContainer.AddObjectProperty("GridName", "Dummygrid");
            DummygridContainer.AddObjectProperty("Header", subDummygrid_Header);
            DummygridContainer.AddObjectProperty("Class", "Grid");
            DummygridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            DummygridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            DummygridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subDummygrid_Backcolorstyle), 1, 0, ".", "")));
            DummygridContainer.AddObjectProperty("CmpContext", "");
            DummygridContainer.AddObjectProperty("InMasterPage", "false");
            DummygridContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subDummygrid_Selectedindex), 4, 0, ".", "")));
            DummygridContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subDummygrid_Allowselection), 1, 0, ".", "")));
            DummygridContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subDummygrid_Selectioncolor), 9, 0, ".", "")));
            DummygridContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subDummygrid_Allowhovering), 1, 0, ".", "")));
            DummygridContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subDummygrid_Hoveringcolor), 9, 0, ".", "")));
            DummygridContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subDummygrid_Allowcollapsing), 1, 0, ".", "")));
            DummygridContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subDummygrid_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         bttBtnadicionaroportunidade_Internalname = "BTNADICIONAROPORTUNIDADE";
         bttBtnagexport_Internalname = "BTNAGEXPORT";
         bttBtneditcolumns_Internalname = "BTNEDITCOLUMNS";
         bttBtnsubscriptions_Internalname = "BTNSUBSCRIPTIONS";
         divTableactions_Internalname = "TABLEACTIONS";
         Ddo_managefilters_Internalname = "DDO_MANAGEFILTERS";
         radavSelectlistview_Internalname = "vSELECTLISTVIEW";
         edtavFilterfulltext_Internalname = "vFILTERFULLTEXT";
         divTablefilters_Internalname = "TABLEFILTERS";
         divTablerightheader_Internalname = "TABLERIGHTHEADER";
         divTableheadercontent_Internalname = "TABLEHEADERCONTENT";
         lblDynamicfiltersprefix1_Internalname = "DYNAMICFILTERSPREFIX1";
         cmbavDynamicfiltersselector1_Internalname = "vDYNAMICFILTERSSELECTOR1";
         lblDynamicfiltersmiddle1_Internalname = "DYNAMICFILTERSMIDDLE1";
         cmbavDynamicfiltersoperator1_Internalname = "vDYNAMICFILTERSOPERATOR1";
         edtavItenome1_Internalname = "vITENOME1";
         cellFilter_itenome1_cell_Internalname = "FILTER_ITENOME1_CELL";
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
         edtavItenome2_Internalname = "vITENOME2";
         cellFilter_itenome2_cell_Internalname = "FILTER_ITENOME2_CELL";
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
         edtavItenome3_Internalname = "vITENOME3";
         cellFilter_itenome3_cell_Internalname = "FILTER_ITENOME3_CELL";
         imgRemovedynamicfilters3_Internalname = "REMOVEDYNAMICFILTERS3";
         cellDynamicfilters_removefilter3_cell_Internalname = "DYNAMICFILTERS_REMOVEFILTER3_CELL";
         tblTablemergeddynamicfilters3_Internalname = "TABLEMERGEDDYNAMICFILTERS3";
         divTabledynamicfiltersrow3_Internalname = "TABLEDYNAMICFILTERSROW3";
         divTabledynamicfilters_Internalname = "TABLEDYNAMICFILTERS";
         divAdvancedfilterscontainer_Internalname = "ADVANCEDFILTERSCONTAINER";
         divTableheader_Internalname = "TABLEHEADER";
         divDatawc_cell_Internalname = "DATAWC_CELL";
         divTablemain_Internalname = "TABLEMAIN";
         Ddo_agexport_Internalname = "DDO_AGEXPORT";
         Ddc_subscriptions_Internalname = "DDC_SUBSCRIPTIONS";
         lblTxtstyleselectlistview_Internalname = "TXTSTYLESELECTLISTVIEW";
         lblJsdynamicfilters_Internalname = "JSDYNAMICFILTERS";
         Innewwindow1_Internalname = "INNEWWINDOW1";
         Ddo_gridcolumnsselector_Internalname = "DDO_GRIDCOLUMNSSELECTOR";
         divDiv_selectlistview_Internalname = "DIV_SELECTLISTVIEW";
         divDiv_wwpauxwc_Internalname = "DIV_WWPAUXWC";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subDummygrid_Internalname = "DUMMYGRID";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subDummygrid_Allowcollapsing = 0;
         subDummygrid_Allowselection = 0;
         subDummygrid_Header = "";
         subDummygrid_Class = "Grid";
         imgRemovedynamicfilters1_Visible = 1;
         imgAdddynamicfilters1_Visible = 1;
         edtavItenome1_Jsonclick = "";
         edtavItenome1_Enabled = 1;
         cmbavDynamicfiltersoperator1_Jsonclick = "";
         cmbavDynamicfiltersoperator1.Enabled = 1;
         imgRemovedynamicfilters2_Visible = 1;
         imgAdddynamicfilters2_Visible = 1;
         edtavItenome2_Jsonclick = "";
         edtavItenome2_Enabled = 1;
         cmbavDynamicfiltersoperator2_Jsonclick = "";
         cmbavDynamicfiltersoperator2.Enabled = 1;
         edtavItenome3_Jsonclick = "";
         edtavItenome3_Enabled = 1;
         cmbavDynamicfiltersoperator3_Jsonclick = "";
         cmbavDynamicfiltersoperator3.Enabled = 1;
         cmbavDynamicfiltersoperator3.Visible = 1;
         edtavItenome3_Visible = 1;
         cmbavDynamicfiltersoperator2.Visible = 1;
         edtavItenome2_Visible = 1;
         cmbavDynamicfiltersoperator1.Visible = 1;
         edtavItenome1_Visible = 1;
         subDummygrid_Backcolorstyle = 0;
         lblJsdynamicfilters_Caption = "JSDynamicFilters";
         lblTxtstyleselectlistview_Caption = "Text Block";
         cmbavDynamicfiltersselector3_Jsonclick = "";
         cmbavDynamicfiltersselector3.Enabled = 1;
         cmbavDynamicfiltersselector2_Jsonclick = "";
         cmbavDynamicfiltersselector2.Enabled = 1;
         cmbavDynamicfiltersselector1_Jsonclick = "";
         cmbavDynamicfiltersselector1.Enabled = 1;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         radavSelectlistview_Jsonclick = "";
         bttBtnsubscriptions_Visible = 1;
         bttBtneditcolumns_Visible = 1;
         bttBtnadicionaroportunidade_Visible = 1;
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = "";
         Ddo_gridcolumnsselector_Visible = Convert.ToBoolean( -1);
         Ddo_gridcolumnsselector_Dropdownoptionstype = "GridColumnsSelector";
         Ddo_gridcolumnsselector_Cls = "ColumnsSelector hidden-xs";
         Ddo_gridcolumnsselector_Tooltip = "WWP_EditColumnsTooltip";
         Ddo_gridcolumnsselector_Caption = "Selecionar colunas";
         Ddo_gridcolumnsselector_Icon = "fas fa-cog";
         Ddo_gridcolumnsselector_Icontype = "FontIcon";
         Innewwindow1_Target = "";
         Innewwindow1_Height = "50";
         Innewwindow1_Width = "50";
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
         Ddo_managefilters_Cls = "ManageFilters";
         Ddo_managefilters_Tooltip = "WWP_ManageFiltersTooltip";
         Ddo_managefilters_Icon = "fas fa-filter";
         Ddo_managefilters_Icontype = "FontIcon";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Funil de Vendas";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'DUMMYGRID_nFirstRecordOnPage'},{av:'DUMMYGRID_nEOF'},{av:'AV45ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV23FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV46TFIteNome',fld:'vTFITENOME',pic:'@!'},{av:'AV47TFIteNome_Sel',fld:'vTFITENOME_SEL',pic:'@!'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV36DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV24DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'AV26IteNome1',fld:'vITENOME1',pic:'@!'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV25DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV35DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV27DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV28DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'AV30IteNome2',fld:'vITENOME2',pic:'@!'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV29DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV31DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV32DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'AV34IteNome3',fld:'vITENOME3',pic:'@!'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV33DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'radavSelectlistview'},{av:'AV57SelectListView',fld:'vSELECTLISTVIEW',pic:''},{av:'AV62Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV61IsAuthorized_AdicionarOportunidade',fld:'vISAUTHORIZED_ADICIONAROPORTUNIDADE',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV45ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV41ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV61IsAuthorized_AdicionarOportunidade',fld:'vISAUTHORIZED_ADICIONAROPORTUNIDADE',pic:'',hsh:true},{ctrl:'BTNADICIONAROPORTUNIDADE',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV43ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GLOBALEVENTS.LISTVIEW_UPDATELISTFILTERS","{handler:'E154X2',iparms:[{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV62Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'cmbavDynamicfiltersselector1'},{av:'AV24DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'AV35DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV28DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV32DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''}]");
         setEventMetadata("GLOBALEVENTS.LISTVIEW_UPDATELISTFILTERS",",oparms:[{av:'AV23FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV46TFIteNome',fld:'vTFITENOME',pic:'@!'},{av:'AV47TFIteNome_Sel',fld:'vTFITENOME_SEL',pic:'@!'},{av:'cmbavDynamicfiltersselector1'},{av:'AV24DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV25DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV26IteNome1',fld:'vITENOME1',pic:'@!'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV21OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'edtavItenome1_Visible',ctrl:'vITENOME1',prop:'Visible'},{av:'AV27DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV28DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV29DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV30IteNome2',fld:'vITENOME2',pic:'@!'},{av:'AV31DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV32DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV33DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV34IteNome3',fld:'vITENOME3',pic:'@!'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'edtavItenome2_Visible',ctrl:'vITENOME2',prop:'Visible'},{av:'edtavItenome3_Visible',ctrl:'vITENOME3',prop:'Visible'}]}");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED","{handler:'E144X2',iparms:[{av:'DUMMYGRID_nFirstRecordOnPage'},{av:'DUMMYGRID_nEOF'},{av:'AV45ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV62Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV21OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV23FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV46TFIteNome',fld:'vTFITENOME',pic:'@!'},{av:'AV47TFIteNome_Sel',fld:'vTFITENOME_SEL',pic:'@!'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV36DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV24DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'AV26IteNome1',fld:'vITENOME1',pic:'@!'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV25DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV35DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV27DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV28DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'AV30IteNome2',fld:'vITENOME2',pic:'@!'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV29DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV31DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV32DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'AV34IteNome3',fld:'vITENOME3',pic:'@!'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV33DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'radavSelectlistview'},{av:'AV57SelectListView',fld:'vSELECTLISTVIEW',pic:''},{av:'AV61IsAuthorized_AdicionarOportunidade',fld:'vISAUTHORIZED_ADICIONAROPORTUNIDADE',pic:'',hsh:true},{av:'Ddo_gridcolumnsselector_Columnsselectorvalues',ctrl:'DDO_GRIDCOLUMNSSELECTOR',prop:'ColumnsSelectorValues'}]");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED",",oparms:[{av:'AV41ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV45ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV61IsAuthorized_AdicionarOportunidade',fld:'vISAUTHORIZED_ADICIONAROPORTUNIDADE',pic:'',hsh:true},{ctrl:'BTNADICIONAROPORTUNIDADE',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV43ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("'ADDDYNAMICFILTERS1'","{handler:'E294X1',iparms:[]");
         setEventMetadata("'ADDDYNAMICFILTERS1'",",oparms:[{av:'AV27DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'","{handler:'E164X2',iparms:[{av:'DUMMYGRID_nFirstRecordOnPage'},{av:'DUMMYGRID_nEOF'},{av:'AV45ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV62Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV21OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV23FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV46TFIteNome',fld:'vTFITENOME',pic:'@!'},{av:'AV47TFIteNome_Sel',fld:'vTFITENOME_SEL',pic:'@!'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV36DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV24DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'AV26IteNome1',fld:'vITENOME1',pic:'@!'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV25DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV35DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV27DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV28DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'AV30IteNome2',fld:'vITENOME2',pic:'@!'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV29DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV31DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV32DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'AV34IteNome3',fld:'vITENOME3',pic:'@!'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV33DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'radavSelectlistview'},{av:'AV57SelectListView',fld:'vSELECTLISTVIEW',pic:''},{av:'AV61IsAuthorized_AdicionarOportunidade',fld:'vISAUTHORIZED_ADICIONAROPORTUNIDADE',pic:'',hsh:true}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'",",oparms:[{av:'AV35DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV36DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV28DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV29DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV30IteNome2',fld:'vITENOME2',pic:'@!'},{av:'AV31DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV32DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV33DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV34IteNome3',fld:'vITENOME3',pic:'@!'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV24DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV25DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV26IteNome1',fld:'vITENOME1',pic:'@!'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'edtavItenome2_Visible',ctrl:'vITENOME2',prop:'Visible'},{av:'edtavItenome3_Visible',ctrl:'vITENOME3',prop:'Visible'},{av:'edtavItenome1_Visible',ctrl:'vITENOME1',prop:'Visible'},{av:'AV45ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV41ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV61IsAuthorized_AdicionarOportunidade',fld:'vISAUTHORIZED_ADICIONAROPORTUNIDADE',pic:'',hsh:true},{ctrl:'BTNADICIONAROPORTUNIDADE',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV43ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK","{handler:'E224X2',iparms:[{av:'cmbavDynamicfiltersselector1'},{av:'AV24DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK",",oparms:[{av:'edtavItenome1_Visible',ctrl:'vITENOME1',prop:'Visible'},{av:'cmbavDynamicfiltersoperator1'}]}");
         setEventMetadata("'ADDDYNAMICFILTERS2'","{handler:'E284X1',iparms:[]");
         setEventMetadata("'ADDDYNAMICFILTERS2'",",oparms:[{av:'AV31DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'","{handler:'E174X2',iparms:[{av:'DUMMYGRID_nFirstRecordOnPage'},{av:'DUMMYGRID_nEOF'},{av:'AV45ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV62Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV21OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV23FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV46TFIteNome',fld:'vTFITENOME',pic:'@!'},{av:'AV47TFIteNome_Sel',fld:'vTFITENOME_SEL',pic:'@!'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV36DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV24DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'AV26IteNome1',fld:'vITENOME1',pic:'@!'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV25DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV35DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV27DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV28DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'AV30IteNome2',fld:'vITENOME2',pic:'@!'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV29DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV31DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV32DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'AV34IteNome3',fld:'vITENOME3',pic:'@!'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV33DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'radavSelectlistview'},{av:'AV57SelectListView',fld:'vSELECTLISTVIEW',pic:''},{av:'AV61IsAuthorized_AdicionarOportunidade',fld:'vISAUTHORIZED_ADICIONAROPORTUNIDADE',pic:'',hsh:true}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'",",oparms:[{av:'AV35DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV27DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV28DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV29DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV30IteNome2',fld:'vITENOME2',pic:'@!'},{av:'AV31DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV32DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV33DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV34IteNome3',fld:'vITENOME3',pic:'@!'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV24DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV25DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV26IteNome1',fld:'vITENOME1',pic:'@!'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'edtavItenome2_Visible',ctrl:'vITENOME2',prop:'Visible'},{av:'edtavItenome3_Visible',ctrl:'vITENOME3',prop:'Visible'},{av:'edtavItenome1_Visible',ctrl:'vITENOME1',prop:'Visible'},{av:'AV45ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV41ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV61IsAuthorized_AdicionarOportunidade',fld:'vISAUTHORIZED_ADICIONAROPORTUNIDADE',pic:'',hsh:true},{ctrl:'BTNADICIONAROPORTUNIDADE',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV43ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK","{handler:'E234X2',iparms:[{av:'cmbavDynamicfiltersselector2'},{av:'AV28DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK",",oparms:[{av:'edtavItenome2_Visible',ctrl:'vITENOME2',prop:'Visible'},{av:'cmbavDynamicfiltersoperator2'}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'","{handler:'E184X2',iparms:[{av:'DUMMYGRID_nFirstRecordOnPage'},{av:'DUMMYGRID_nEOF'},{av:'AV45ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV62Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV21OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV23FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV46TFIteNome',fld:'vTFITENOME',pic:'@!'},{av:'AV47TFIteNome_Sel',fld:'vTFITENOME_SEL',pic:'@!'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV36DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV24DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'AV26IteNome1',fld:'vITENOME1',pic:'@!'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV25DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV35DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV27DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV28DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'AV30IteNome2',fld:'vITENOME2',pic:'@!'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV29DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV31DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV32DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'AV34IteNome3',fld:'vITENOME3',pic:'@!'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV33DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'radavSelectlistview'},{av:'AV57SelectListView',fld:'vSELECTLISTVIEW',pic:''},{av:'AV61IsAuthorized_AdicionarOportunidade',fld:'vISAUTHORIZED_ADICIONAROPORTUNIDADE',pic:'',hsh:true}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'",",oparms:[{av:'AV35DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV31DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV27DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV28DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV29DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV30IteNome2',fld:'vITENOME2',pic:'@!'},{av:'cmbavDynamicfiltersselector3'},{av:'AV32DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV33DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV34IteNome3',fld:'vITENOME3',pic:'@!'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV24DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV25DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV26IteNome1',fld:'vITENOME1',pic:'@!'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'edtavItenome2_Visible',ctrl:'vITENOME2',prop:'Visible'},{av:'edtavItenome3_Visible',ctrl:'vITENOME3',prop:'Visible'},{av:'edtavItenome1_Visible',ctrl:'vITENOME1',prop:'Visible'},{av:'AV45ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV41ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV61IsAuthorized_AdicionarOportunidade',fld:'vISAUTHORIZED_ADICIONAROPORTUNIDADE',pic:'',hsh:true},{ctrl:'BTNADICIONAROPORTUNIDADE',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV43ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK","{handler:'E244X2',iparms:[{av:'cmbavDynamicfiltersselector3'},{av:'AV32DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK",",oparms:[{av:'edtavItenome3_Visible',ctrl:'vITENOME3',prop:'Visible'},{av:'cmbavDynamicfiltersoperator3'}]}");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","{handler:'E114X2',iparms:[{av:'DUMMYGRID_nFirstRecordOnPage'},{av:'DUMMYGRID_nEOF'},{av:'AV45ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV62Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV21OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV23FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV46TFIteNome',fld:'vTFITENOME',pic:'@!'},{av:'AV47TFIteNome_Sel',fld:'vTFITENOME_SEL',pic:'@!'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV36DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV24DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'AV26IteNome1',fld:'vITENOME1',pic:'@!'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV25DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV35DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV27DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV28DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'AV30IteNome2',fld:'vITENOME2',pic:'@!'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV29DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV31DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV32DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'AV34IteNome3',fld:'vITENOME3',pic:'@!'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV33DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'radavSelectlistview'},{av:'AV57SelectListView',fld:'vSELECTLISTVIEW',pic:''},{av:'AV61IsAuthorized_AdicionarOportunidade',fld:'vISAUTHORIZED_ADICIONAROPORTUNIDADE',pic:'',hsh:true},{av:'Ddo_managefilters_Activeeventkey',ctrl:'DDO_MANAGEFILTERS',prop:'ActiveEventKey'}]");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",",oparms:[{av:'AV45ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV21OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV23FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV46TFIteNome',fld:'vTFITENOME',pic:'@!'},{av:'AV47TFIteNome_Sel',fld:'vTFITENOME_SEL',pic:'@!'},{av:'cmbavDynamicfiltersselector1'},{av:'AV24DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV25DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV26IteNome1',fld:'vITENOME1',pic:'@!'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV27DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV28DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV29DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV30IteNome2',fld:'vITENOME2',pic:'@!'},{av:'AV31DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV32DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV33DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV34IteNome3',fld:'vITENOME3',pic:'@!'},{av:'edtavItenome1_Visible',ctrl:'vITENOME1',prop:'Visible'},{av:'edtavItenome2_Visible',ctrl:'vITENOME2',prop:'Visible'},{av:'edtavItenome3_Visible',ctrl:'vITENOME3',prop:'Visible'},{av:'AV41ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV61IsAuthorized_AdicionarOportunidade',fld:'vISAUTHORIZED_ADICIONAROPORTUNIDADE',pic:'',hsh:true},{ctrl:'BTNADICIONAROPORTUNIDADE',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV43ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VSELECTLISTVIEW.CONTROLVALUECHANGED","{handler:'E194X2',iparms:[{av:'AV62Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'radavSelectlistview'},{av:'AV57SelectListView',fld:'vSELECTLISTVIEW',pic:''}]");
         setEventMetadata("VSELECTLISTVIEW.CONTROLVALUECHANGED",",oparms:[{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{ctrl:'DATAWC'},{ctrl:'BTNEDITCOLUMNS',prop:'Visible'},{av:'Ddo_gridcolumnsselector_Visible',ctrl:'DDO_GRIDCOLUMNSSELECTOR',prop:'Visible'}]}");
         setEventMetadata("'DOADICIONAROPORTUNIDADE'","{handler:'E204X2',iparms:[{av:'DUMMYGRID_nFirstRecordOnPage'},{av:'DUMMYGRID_nEOF'},{av:'AV45ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV62Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV21OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV23FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV46TFIteNome',fld:'vTFITENOME',pic:'@!'},{av:'AV47TFIteNome_Sel',fld:'vTFITENOME_SEL',pic:'@!'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV36DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV24DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'AV26IteNome1',fld:'vITENOME1',pic:'@!'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV25DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV35DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV27DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV28DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'AV30IteNome2',fld:'vITENOME2',pic:'@!'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV29DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV31DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV32DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'AV34IteNome3',fld:'vITENOME3',pic:'@!'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV33DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'radavSelectlistview'},{av:'AV57SelectListView',fld:'vSELECTLISTVIEW',pic:''},{av:'AV61IsAuthorized_AdicionarOportunidade',fld:'vISAUTHORIZED_ADICIONAROPORTUNIDADE',pic:'',hsh:true}]");
         setEventMetadata("'DOADICIONAROPORTUNIDADE'",",oparms:[{av:'AV45ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV41ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV61IsAuthorized_AdicionarOportunidade',fld:'vISAUTHORIZED_ADICIONAROPORTUNIDADE',pic:'',hsh:true},{ctrl:'BTNADICIONAROPORTUNIDADE',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV43ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED","{handler:'E124X2',iparms:[{av:'Ddo_agexport_Activeeventkey',ctrl:'DDO_AGEXPORT',prop:'ActiveEventKey'},{av:'AV62Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV35DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV24DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV28DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV32DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''}]");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED",",oparms:[{av:'Innewwindow1_Target',ctrl:'INNEWWINDOW1',prop:'Target'},{av:'Innewwindow1_Height',ctrl:'INNEWWINDOW1',prop:'Height'},{av:'Innewwindow1_Width',ctrl:'INNEWWINDOW1',prop:'Width'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV21OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV23FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV46TFIteNome',fld:'vTFITENOME',pic:'@!'},{av:'AV47TFIteNome_Sel',fld:'vTFITENOME_SEL',pic:'@!'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV24DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV25DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV26IteNome1',fld:'vITENOME1',pic:'@!'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV27DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV28DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV29DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV30IteNome2',fld:'vITENOME2',pic:'@!'},{av:'AV31DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV32DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV33DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV34IteNome3',fld:'vITENOME3',pic:'@!'},{av:'edtavItenome1_Visible',ctrl:'vITENOME1',prop:'Visible'},{av:'edtavItenome2_Visible',ctrl:'vITENOME2',prop:'Visible'},{av:'edtavItenome3_Visible',ctrl:'vITENOME3',prop:'Visible'}]}");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT","{handler:'E134X2',iparms:[]");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT",",oparms:[{ctrl:'WWPAUX_WC'}]}");
         setEventMetadata("GLOBALEVENTS.REFRESHGRIDPARENT","{handler:'E214X2',iparms:[{av:'DUMMYGRID_nFirstRecordOnPage'},{av:'DUMMYGRID_nEOF'},{av:'AV45ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV62Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV21OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV23FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV46TFIteNome',fld:'vTFITENOME',pic:'@!'},{av:'AV47TFIteNome_Sel',fld:'vTFITENOME_SEL',pic:'@!'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV36DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV24DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'AV26IteNome1',fld:'vITENOME1',pic:'@!'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV25DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV35DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV27DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV28DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'AV30IteNome2',fld:'vITENOME2',pic:'@!'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV29DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV31DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV32DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'AV34IteNome3',fld:'vITENOME3',pic:'@!'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV33DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'radavSelectlistview'},{av:'AV57SelectListView',fld:'vSELECTLISTVIEW',pic:''},{av:'AV61IsAuthorized_AdicionarOportunidade',fld:'vISAUTHORIZED_ADICIONAROPORTUNIDADE',pic:'',hsh:true}]");
         setEventMetadata("GLOBALEVENTS.REFRESHGRIDPARENT",",oparms:[{av:'AV45ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV41ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV61IsAuthorized_AdicionarOportunidade',fld:'vISAUTHORIZED_ADICIONAROPORTUNIDADE',pic:'',hsh:true},{ctrl:'BTNADICIONAROPORTUNIDADE',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV43ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
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
         Ddo_gridcolumnsselector_Columnsselectorvalues = "";
         Ddo_managefilters_Activeeventkey = "";
         Ddo_agexport_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV62Pgmname = "";
         AV23FilterFullText = "";
         AV46TFIteNome = "";
         AV47TFIteNome_Sel = "";
         AV11GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV24DynamicFiltersSelector1 = "";
         AV26IteNome1 = "";
         AV28DynamicFiltersSelector2 = "";
         AV30IteNome2 = "";
         AV32DynamicFiltersSelector3 = "";
         AV34IteNome3 = "";
         AV57SelectListView = "CardSmallImageAndInfoView";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV43ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV55AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV52DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV41ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         Ddo_agexport_Caption = "";
         Ddo_gridcolumnsselector_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtnadicionaroportunidade_Jsonclick = "";
         bttBtnagexport_Jsonclick = "";
         bttBtneditcolumns_Jsonclick = "";
         bttBtnsubscriptions_Jsonclick = "";
         ucDdo_managefilters = new GXUserControl();
         Ddo_managefilters_Caption = "";
         lblDynamicfiltersprefix1_Jsonclick = "";
         lblDynamicfiltersmiddle1_Jsonclick = "";
         lblDynamicfiltersprefix2_Jsonclick = "";
         lblDynamicfiltersmiddle2_Jsonclick = "";
         lblDynamicfiltersprefix3_Jsonclick = "";
         lblDynamicfiltersmiddle3_Jsonclick = "";
         WebComp_Datawc_Component = "";
         OldDatawc = "";
         ucDdo_agexport = new GXUserControl();
         ucDdc_subscriptions = new GXUserControl();
         lblTxtstyleselectlistview_Jsonclick = "";
         lblJsdynamicfilters_Jsonclick = "";
         DummygridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucInnewwindow1 = new GXUserControl();
         ucDdo_gridcolumnsselector = new GXUserControl();
         WebComp_Selectlistview_wc_Component = "";
         OldSelectlistview_wc = "";
         WebComp_Wwpaux_wc_Component = "";
         OldWwpaux_wc = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV8HTTPRequest = new GxHttpRequest( context);
         imgAdddynamicfilters1_Jsonclick = "";
         imgRemovedynamicfilters1_Jsonclick = "";
         imgAdddynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters3_Jsonclick = "";
         AV56AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV16Session = context.GetSession();
         AV39ColumnsSelectorXML = "";
         GXEncryptionTmp = "";
         AV44ManageFiltersXml = "";
         AV40UserCustomValue = "";
         GXt_char2 = "";
         AV42ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV12GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV19GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV37ExcelFilename = "";
         AV38ErrorMessage = "";
         AV58DummyGridCollection = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         imgRemovedynamicfilters3_gximage = "";
         sImgUrl = "";
         imgAdddynamicfilters2_gximage = "";
         imgRemovedynamicfilters2_gximage = "";
         imgAdddynamicfilters1_gximage = "";
         imgRemovedynamicfilters1_gximage = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         DummygridRow = new GXWebRow();
         subDummygrid_Linesclass = "";
         WebComp_Datawc = new GeneXus.Http.GXNullWebComponent();
         WebComp_Selectlistview_wc = new GeneXus.Http.GXNullWebComponent();
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         AV62Pgmname = "core.webfunil";
         /* GeneXus formulas. */
         AV62Pgmname = "core.webfunil";
      }

      private short nGotPars ;
      private short GxWebError ;
      private short AV45ManageFiltersExecutionStep ;
      private short AV25DynamicFiltersOperator1 ;
      private short AV29DynamicFiltersOperator2 ;
      private short AV33DynamicFiltersOperator3 ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subDummygrid_Backcolorstyle ;
      private short DUMMYGRID_nEOF ;
      private short nGXWrapped ;
      private short subDummygrid_Backstyle ;
      private short subDummygrid_Titlebackstyle ;
      private short subDummygrid_Allowselection ;
      private short subDummygrid_Allowhovering ;
      private short subDummygrid_Allowcollapsing ;
      private short subDummygrid_Collapsed ;
      private int nRC_GXsfl_114 ;
      private int subDummygrid_Recordcount ;
      private int nGXsfl_114_idx=1 ;
      private int bttBtnadicionaroportunidade_Visible ;
      private int bttBtneditcolumns_Visible ;
      private int bttBtnsubscriptions_Visible ;
      private int edtavFilterfulltext_Enabled ;
      private int AV64GXV3 ;
      private int subDummygrid_Islastpage ;
      private int edtavItenome1_Visible ;
      private int edtavItenome2_Visible ;
      private int edtavItenome3_Visible ;
      private int AV63GXV2 ;
      private int imgAdddynamicfilters1_Visible ;
      private int imgRemovedynamicfilters1_Visible ;
      private int imgAdddynamicfilters2_Visible ;
      private int imgRemovedynamicfilters2_Visible ;
      private int edtavItenome3_Enabled ;
      private int edtavItenome2_Enabled ;
      private int edtavItenome1_Enabled ;
      private int idxLst ;
      private int subDummygrid_Backcolor ;
      private int subDummygrid_Allbackcolor ;
      private int subDummygrid_Titlebackcolor ;
      private int subDummygrid_Selectedindex ;
      private int subDummygrid_Selectioncolor ;
      private int subDummygrid_Hoveringcolor ;
      private long DUMMYGRID_nCurrentRecord ;
      private long DUMMYGRID_nFirstRecordOnPage ;
      private string Ddo_gridcolumnsselector_Columnsselectorvalues ;
      private string Ddo_managefilters_Activeeventkey ;
      private string Ddo_agexport_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_114_idx="0001" ;
      private string AV62Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Ddo_managefilters_Icontype ;
      private string Ddo_managefilters_Icon ;
      private string Ddo_managefilters_Tooltip ;
      private string Ddo_managefilters_Cls ;
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
      private string bttBtnadicionaroportunidade_Internalname ;
      private string bttBtnadicionaroportunidade_Jsonclick ;
      private string bttBtnagexport_Internalname ;
      private string bttBtnagexport_Jsonclick ;
      private string bttBtneditcolumns_Internalname ;
      private string bttBtneditcolumns_Jsonclick ;
      private string bttBtnsubscriptions_Internalname ;
      private string bttBtnsubscriptions_Jsonclick ;
      private string divTablerightheader_Internalname ;
      private string Ddo_managefilters_Caption ;
      private string Ddo_managefilters_Internalname ;
      private string radavSelectlistview_Internalname ;
      private string radavSelectlistview_Jsonclick ;
      private string divTablefilters_Internalname ;
      private string edtavFilterfulltext_Internalname ;
      private string edtavFilterfulltext_Jsonclick ;
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
      private string divDatawc_cell_Internalname ;
      private string WebComp_Datawc_Component ;
      private string OldDatawc ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Ddo_agexport_Internalname ;
      private string Ddc_subscriptions_Internalname ;
      private string lblTxtstyleselectlistview_Internalname ;
      private string lblTxtstyleselectlistview_Caption ;
      private string lblTxtstyleselectlistview_Jsonclick ;
      private string lblJsdynamicfilters_Internalname ;
      private string lblJsdynamicfilters_Caption ;
      private string lblJsdynamicfilters_Jsonclick ;
      private string sStyleString ;
      private string subDummygrid_Internalname ;
      private string Innewwindow1_Internalname ;
      private string Ddo_gridcolumnsselector_Internalname ;
      private string divDiv_selectlistview_Internalname ;
      private string WebComp_Selectlistview_wc_Component ;
      private string OldSelectlistview_wc ;
      private string divDiv_wwpauxwc_Internalname ;
      private string WebComp_Wwpaux_wc_Component ;
      private string OldWwpaux_wc ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string cmbavDynamicfiltersoperator1_Internalname ;
      private string cmbavDynamicfiltersoperator2_Internalname ;
      private string cmbavDynamicfiltersoperator3_Internalname ;
      private string edtavItenome1_Internalname ;
      private string edtavItenome2_Internalname ;
      private string edtavItenome3_Internalname ;
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
      private string GXEncryptionTmp ;
      private string GXt_char2 ;
      private string tblTablemergeddynamicfilters3_Internalname ;
      private string cmbavDynamicfiltersoperator3_Jsonclick ;
      private string cellFilter_itenome3_cell_Internalname ;
      private string edtavItenome3_Jsonclick ;
      private string cellDynamicfilters_removefilter3_cell_Internalname ;
      private string imgRemovedynamicfilters3_gximage ;
      private string sImgUrl ;
      private string tblTablemergeddynamicfilters2_Internalname ;
      private string cmbavDynamicfiltersoperator2_Jsonclick ;
      private string cellFilter_itenome2_cell_Internalname ;
      private string edtavItenome2_Jsonclick ;
      private string cellDynamicfilters_addfilter2_cell_Internalname ;
      private string imgAdddynamicfilters2_gximage ;
      private string cellDynamicfilters_removefilter2_cell_Internalname ;
      private string imgRemovedynamicfilters2_gximage ;
      private string tblTablemergeddynamicfilters1_Internalname ;
      private string cmbavDynamicfiltersoperator1_Jsonclick ;
      private string cellFilter_itenome1_cell_Internalname ;
      private string edtavItenome1_Jsonclick ;
      private string cellDynamicfilters_addfilter1_cell_Internalname ;
      private string imgAdddynamicfilters1_gximage ;
      private string cellDynamicfilters_removefilter1_cell_Internalname ;
      private string imgRemovedynamicfilters1_gximage ;
      private string subDummygrid_Class ;
      private string subDummygrid_Linesclass ;
      private string subDummygrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV21OrderedDsc ;
      private bool AV36DynamicFiltersIgnoreFirst ;
      private bool AV35DynamicFiltersRemoving ;
      private bool AV27DynamicFiltersEnabled2 ;
      private bool AV31DynamicFiltersEnabled3 ;
      private bool AV61IsAuthorized_AdicionarOportunidade ;
      private bool Ddo_gridcolumnsselector_Visible ;
      private bool wbLoad ;
      private bool bGXsfl_114_Refreshing=false ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool bDynCreated_Datawc ;
      private bool gx_refresh_fired ;
      private bool bDynCreated_Wwpaux_wc ;
      private bool GXt_boolean3 ;
      private string AV39ColumnsSelectorXML ;
      private string AV44ManageFiltersXml ;
      private string AV40UserCustomValue ;
      private string AV23FilterFullText ;
      private string AV46TFIteNome ;
      private string AV47TFIteNome_Sel ;
      private string AV24DynamicFiltersSelector1 ;
      private string AV26IteNome1 ;
      private string AV28DynamicFiltersSelector2 ;
      private string AV30IteNome2 ;
      private string AV32DynamicFiltersSelector3 ;
      private string AV34IteNome3 ;
      private string AV57SelectListView ;
      private string AV37ExcelFilename ;
      private string AV38ErrorMessage ;
      private IGxSession AV16Session ;
      private GXWebComponent WebComp_Datawc ;
      private GXWebComponent WebComp_Selectlistview_wc ;
      private GXWebComponent WebComp_Wwpaux_wc ;
      private GXWebGrid DummygridContainer ;
      private GXWebRow DummygridRow ;
      private GXUserControl ucDdo_managefilters ;
      private GXUserControl ucDdo_agexport ;
      private GXUserControl ucDdc_subscriptions ;
      private GXUserControl ucInnewwindow1 ;
      private GXUserControl ucDdo_gridcolumnsselector ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXRadio radavSelectlistview ;
      private GXCombobox cmbavDynamicfiltersselector1 ;
      private GXCombobox cmbavDynamicfiltersoperator1 ;
      private GXCombobox cmbavDynamicfiltersselector2 ;
      private GXCombobox cmbavDynamicfiltersoperator2 ;
      private GXCombobox cmbavDynamicfiltersselector3 ;
      private GXCombobox cmbavDynamicfiltersoperator3 ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV8HTTPRequest ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV43ManageFiltersData ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV55AGExportData ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV58DummyGridCollection ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV12GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV19GridStateDynamicFilter ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV41ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV42ColumnsSelectorAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item AV56AGExportDataItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV52DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
   }

}
