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
   public class negociopjww : GXDataArea
   {
      public negociopjww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public negociopjww( IGxContext context )
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
         chkavNegdel = new GXCheckbox();
         cmbavDynamicfiltersselector1 = new GXCombobox();
         cmbavDynamicfiltersoperator1 = new GXCombobox();
         cmbavDynamicfiltersselector2 = new GXCombobox();
         cmbavDynamicfiltersoperator2 = new GXCombobox();
         cmbavDynamicfiltersselector3 = new GXCombobox();
         cmbavDynamicfiltersoperator3 = new GXCombobox();
         cmbavGridactions = new GXCombobox();
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
         nRC_GXsfl_115 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_115"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_115_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_115_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_115_idx = GetPar( "sGXsfl_115_idx");
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
         AV20NegAssunto1 = GetPar( "NegAssunto1");
         cmbavDynamicfiltersselector2.FromJSonString( GetNextPar( ));
         AV22DynamicFiltersSelector2 = GetPar( "DynamicFiltersSelector2");
         cmbavDynamicfiltersoperator2.FromJSonString( GetNextPar( ));
         AV23DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator2"), "."), 18, MidpointRounding.ToEven));
         AV24NegAssunto2 = GetPar( "NegAssunto2");
         cmbavDynamicfiltersselector3.FromJSonString( GetNextPar( ));
         AV26DynamicFiltersSelector3 = GetPar( "DynamicFiltersSelector3");
         cmbavDynamicfiltersoperator3.FromJSonString( GetNextPar( ));
         AV27DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator3"), "."), 18, MidpointRounding.ToEven));
         AV28NegAssunto3 = GetPar( "NegAssunto3");
         AV40ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV35ColumnsSelector);
         AV106Pgmname = GetPar( "Pgmname");
         AV103NegDel = StringUtil.StrToBool( GetPar( "NegDel"));
         AV21DynamicFiltersEnabled2 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled2"));
         AV25DynamicFiltersEnabled3 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled3"));
         AV41TFNegCodigo = (long)(Math.Round(NumberUtil.Val( GetPar( "TFNegCodigo"), "."), 18, MidpointRounding.ToEven));
         AV42TFNegCodigo_To = (long)(Math.Round(NumberUtil.Val( GetPar( "TFNegCodigo_To"), "."), 18, MidpointRounding.ToEven));
         AV80TFNegAssunto = GetPar( "TFNegAssunto");
         AV81TFNegAssunto_Sel = GetPar( "TFNegAssunto_Sel");
         AV62TFNegCliNomeFamiliar = GetPar( "TFNegCliNomeFamiliar");
         AV63TFNegCliNomeFamiliar_Sel = GetPar( "TFNegCliNomeFamiliar_Sel");
         AV64TFNegCpjNomFan = GetPar( "TFNegCpjNomFan");
         AV65TFNegCpjNomFan_Sel = GetPar( "TFNegCpjNomFan_Sel");
         AV68TFNegCpjMatricula = (long)(Math.Round(NumberUtil.Val( GetPar( "TFNegCpjMatricula"), "."), 18, MidpointRounding.ToEven));
         AV69TFNegCpjMatricula_To = (long)(Math.Round(NumberUtil.Val( GetPar( "TFNegCpjMatricula_To"), "."), 18, MidpointRounding.ToEven));
         AV74TFNegPjtNome = GetPar( "TFNegPjtNome");
         AV75TFNegPjtNome_Sel = GetPar( "TFNegPjtNome_Sel");
         AV78TFNegAgcNome = GetPar( "TFNegAgcNome");
         AV79TFNegAgcNome_Sel = GetPar( "TFNegAgcNome_Sel");
         AV99TFNegValorAtualizado = NumberUtil.Val( GetPar( "TFNegValorAtualizado"), ".");
         AV100TFNegValorAtualizado_To = NumberUtil.Val( GetPar( "TFNegValorAtualizado_To"), ".");
         AV43TFNegInsData = context.localUtil.ParseDateParm( GetPar( "TFNegInsData"));
         AV44TFNegInsData_To = context.localUtil.ParseDateParm( GetPar( "TFNegInsData_To"));
         AV97TFNegInsUsuNome = GetPar( "TFNegInsUsuNome");
         AV98TFNegInsUsuNome_Sel = GetPar( "TFNegInsUsuNome_Sel");
         AV14OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV15OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV11GridState);
         AV30DynamicFiltersIgnoreFirst = StringUtil.StrToBool( GetPar( "DynamicFiltersIgnoreFirst"));
         AV29DynamicFiltersRemoving = StringUtil.StrToBool( GetPar( "DynamicFiltersRemoving"));
         AV90IsAuthorized_Update = StringUtil.StrToBool( GetPar( "IsAuthorized_Update"));
         AV91IsAuthorized_Delete = StringUtil.StrToBool( GetPar( "IsAuthorized_Delete"));
         AV96IsAuthorized_NegAssunto = StringUtil.StrToBool( GetPar( "IsAuthorized_NegAssunto"));
         AV92IsAuthorized_NegPjtNome = StringUtil.StrToBool( GetPar( "IsAuthorized_NegPjtNome"));
         AV95IsAuthorized_Insert = StringUtil.StrToBool( GetPar( "IsAuthorized_Insert"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20NegAssunto1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24NegAssunto2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28NegAssunto3, AV40ManageFiltersExecutionStep, AV35ColumnsSelector, AV106Pgmname, AV103NegDel, AV21DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV41TFNegCodigo, AV42TFNegCodigo_To, AV80TFNegAssunto, AV81TFNegAssunto_Sel, AV62TFNegCliNomeFamiliar, AV63TFNegCliNomeFamiliar_Sel, AV64TFNegCpjNomFan, AV65TFNegCpjNomFan_Sel, AV68TFNegCpjMatricula, AV69TFNegCpjMatricula_To, AV74TFNegPjtNome, AV75TFNegPjtNome_Sel, AV78TFNegAgcNome, AV79TFNegAgcNome_Sel, AV99TFNegValorAtualizado, AV100TFNegValorAtualizado_To, AV43TFNegInsData, AV44TFNegInsData_To, AV97TFNegInsUsuNome, AV98TFNegInsUsuNome_Sel, AV14OrderedBy, AV15OrderedDsc, AV11GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving, AV90IsAuthorized_Update, AV91IsAuthorized_Delete, AV96IsAuthorized_NegAssunto, AV92IsAuthorized_NegPjtNome, AV95IsAuthorized_Insert) ;
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
            return "negociopjww_Execute" ;
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
         PA3X2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START3X2( ) ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("core.negociopjww.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV106Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV106Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV90IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV90IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV91IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV91IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_NEGASSUNTO", AV96IsAuthorized_NegAssunto);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_NEGASSUNTO", GetSecureSignedToken( "", AV96IsAuthorized_NegAssunto, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_NEGPJTNOME", AV92IsAuthorized_NegPjtNome);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_NEGPJTNOME", GetSecureSignedToken( "", AV92IsAuthorized_NegPjtNome, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV95IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV95IsAuthorized_Insert, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vFILTERFULLTEXT", AV17FilterFullText);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR1", AV18DynamicFiltersSelector1);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19DynamicFiltersOperator1), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vNEGASSUNTO1", AV20NegAssunto1);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR2", AV22DynamicFiltersSelector2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV23DynamicFiltersOperator2), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vNEGASSUNTO2", AV24NegAssunto2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR3", AV26DynamicFiltersSelector3);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV27DynamicFiltersOperator3), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vNEGASSUNTO3", AV28NegAssunto3);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_115", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_115), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV38ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV38ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV86GridCurrentPage), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV87GridPageCount), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV88GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAGEXPORTDATA", AV93AGExportData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAGEXPORTDATA", AV93AGExportData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV82DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV82DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCOLUMNSSELECTOR", AV35ColumnsSelector);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCOLUMNSSELECTOR", AV35ColumnsSelector);
         }
         GxWebStd.gx_hidden_field( context, "vDDO_NEGINSDATAAUXDATE", context.localUtil.DToC( AV45DDO_NegInsDataAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_NEGINSDATAAUXDATETO", context.localUtil.DToC( AV46DDO_NegInsDataAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV40ManageFiltersExecutionStep), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV106Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV106Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED2", AV21DynamicFiltersEnabled2);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED3", AV25DynamicFiltersEnabled3);
         GxWebStd.gx_hidden_field( context, "vTFNEGCODIGO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV41TFNegCodigo), 12, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFNEGCODIGO_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV42TFNegCodigo_To), 12, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFNEGASSUNTO", AV80TFNegAssunto);
         GxWebStd.gx_hidden_field( context, "vTFNEGASSUNTO_SEL", AV81TFNegAssunto_Sel);
         GxWebStd.gx_hidden_field( context, "vTFNEGCLINOMEFAMILIAR", AV62TFNegCliNomeFamiliar);
         GxWebStd.gx_hidden_field( context, "vTFNEGCLINOMEFAMILIAR_SEL", AV63TFNegCliNomeFamiliar_Sel);
         GxWebStd.gx_hidden_field( context, "vTFNEGCPJNOMFAN", AV64TFNegCpjNomFan);
         GxWebStd.gx_hidden_field( context, "vTFNEGCPJNOMFAN_SEL", AV65TFNegCpjNomFan_Sel);
         GxWebStd.gx_hidden_field( context, "vTFNEGCPJMATRICULA", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV68TFNegCpjMatricula), 12, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFNEGCPJMATRICULA_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV69TFNegCpjMatricula_To), 12, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFNEGPJTNOME", AV74TFNegPjtNome);
         GxWebStd.gx_hidden_field( context, "vTFNEGPJTNOME_SEL", AV75TFNegPjtNome_Sel);
         GxWebStd.gx_hidden_field( context, "vTFNEGAGCNOME", AV78TFNegAgcNome);
         GxWebStd.gx_hidden_field( context, "vTFNEGAGCNOME_SEL", AV79TFNegAgcNome_Sel);
         GxWebStd.gx_hidden_field( context, "vTFNEGVALORATUALIZADO", StringUtil.LTrim( StringUtil.NToC( AV99TFNegValorAtualizado, 16, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFNEGVALORATUALIZADO_TO", StringUtil.LTrim( StringUtil.NToC( AV100TFNegValorAtualizado_To, 16, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFNEGINSDATA", context.localUtil.DToC( AV43TFNegInsData, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFNEGINSDATA_TO", context.localUtil.DToC( AV44TFNegInsData_To, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFNEGINSUSUNOME", AV97TFNegInsUsuNome);
         GxWebStd.gx_hidden_field( context, "vTFNEGINSUSUNOME_SEL", AV98TFNegInsUsuNome_Sel);
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
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSIGNOREFIRST", AV30DynamicFiltersIgnoreFirst);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSREMOVING", AV29DynamicFiltersRemoving);
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV90IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV90IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV91IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV91IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_NEGASSUNTO", AV96IsAuthorized_NegAssunto);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_NEGASSUNTO", GetSecureSignedToken( "", AV96IsAuthorized_NegAssunto, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_NEGPJTNOME", AV92IsAuthorized_NegPjtNome);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_NEGPJTNOME", GetSecureSignedToken( "", AV92IsAuthorized_NegPjtNome, context));
         GxWebStd.gx_hidden_field( context, "vNEGID_SELECTED", AV104NegID_Selected.ToString());
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV95IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV95IsAuthorized_Insert, context));
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
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Format", StringUtil.RTrim( Ddo_grid_Format));
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
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_DELETE_Title", StringUtil.RTrim( Dvelop_confirmpanel_delete_Title));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_DELETE_Confirmationtext", StringUtil.RTrim( Dvelop_confirmpanel_delete_Confirmationtext));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_DELETE_Yesbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_delete_Yesbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_DELETE_Nobuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_delete_Nobuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_DELETE_Cancelbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_delete_Cancelbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_DELETE_Yesbuttonposition", StringUtil.RTrim( Dvelop_confirmpanel_delete_Yesbuttonposition));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_DELETE_Confirmtype", StringUtil.RTrim( Dvelop_confirmpanel_delete_Confirmtype));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hascolumnsselector", StringUtil.BoolToStr( Grid_empowerer_Hascolumnsselector));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Fixedcolumns", StringUtil.RTrim( Grid_empowerer_Fixedcolumns));
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
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_DELETE_Result", StringUtil.RTrim( Dvelop_confirmpanel_delete_Result));
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
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_DELETE_Result", StringUtil.RTrim( Dvelop_confirmpanel_delete_Result));
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
            WE3X2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT3X2( ) ;
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
         return formatLink("core.negociopjww.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "core.NegocioPJWW" ;
      }

      public override string GetPgmdesc( )
      {
         return "Oportunidades de Negócio" ;
      }

      protected void WB3X0( )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-xs hidden-sm hidden-md hidden-lg Invisible", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavNegdel_Internalname, "Neg Del", "col-sm-3 AttributeLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 10,'',false,'" + sGXsfl_115_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavNegdel_Internalname, StringUtil.BoolToStr( AV103NegDel), "", "Neg Del", 1, chkavNegdel.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(10, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,10);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(115), 3, 0)+","+"null"+");", "Incluir", bttBtninsert_Jsonclick, 5, "Incluir", "", StyleString, ClassString, bttBtninsert_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\NegocioPJWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
            ClassString = "ColumnsSelector";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnagexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(115), 3, 0)+","+"null"+");", "Exportar", bttBtnagexport_Jsonclick, 0, "Exportar", "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\NegocioPJWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
            ClassString = "hidden-xs";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtneditcolumns_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(115), 3, 0)+","+"null"+");", "Selecionar colunas", bttBtneditcolumns_Jsonclick, 0, "Selecionar colunas", "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\NegocioPJWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnsubscriptions_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(115), 3, 0)+","+"null"+");", "", bttBtnsubscriptions_Jsonclick, 0, "Assinaturas", "", StyleString, ClassString, bttBtnsubscriptions_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\NegocioPJWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            wb_table1_29_3X2( true) ;
         }
         else
         {
            wb_table1_29_3X2( false) ;
         }
         return  ;
      }

      protected void wb_table1_29_3X2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix1_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_core\\NegocioPJWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector1_Internalname, "Dynamic Filters Selector1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'" + sGXsfl_115_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector1, cmbavDynamicfiltersselector1_Internalname, StringUtil.RTrim( AV18DynamicFiltersSelector1), 1, cmbavDynamicfiltersselector1_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR1.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "", true, 0, "HLP_core\\NegocioPJWW.htm");
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", (string)(cmbavDynamicfiltersselector1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle1_Internalname, "valor", "", "", lblDynamicfiltersmiddle1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_core\\NegocioPJWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            wb_table2_53_3X2( true) ;
         }
         else
         {
            wb_table2_53_3X2( false) ;
         }
         return  ;
      }

      protected void wb_table2_53_3X2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix2_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_core\\NegocioPJWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector2_Internalname, "Dynamic Filters Selector2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'" + sGXsfl_115_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector2, cmbavDynamicfiltersselector2_Internalname, StringUtil.RTrim( AV22DynamicFiltersSelector2), 1, cmbavDynamicfiltersselector2_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR2.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,71);\"", "", true, 0, "HLP_core\\NegocioPJWW.htm");
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", (string)(cmbavDynamicfiltersselector2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle2_Internalname, "valor", "", "", lblDynamicfiltersmiddle2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_core\\NegocioPJWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table3_75_3X2( true) ;
         }
         else
         {
            wb_table3_75_3X2( false) ;
         }
         return  ;
      }

      protected void wb_table3_75_3X2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix3_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_core\\NegocioPJWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector3_Internalname, "Dynamic Filters Selector3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'" + sGXsfl_115_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector3, cmbavDynamicfiltersselector3_Internalname, StringUtil.RTrim( AV26DynamicFiltersSelector3), 1, cmbavDynamicfiltersselector3_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR3.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,93);\"", "", true, 0, "HLP_core\\NegocioPJWW.htm");
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", (string)(cmbavDynamicfiltersselector3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle3_Internalname, "valor", "", "", lblDynamicfiltersmiddle3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_core\\NegocioPJWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table4_97_3X2( true) ;
         }
         else
         {
            wb_table4_97_3X2( false) ;
         }
         return  ;
      }

      protected void wb_table4_97_3X2e( bool wbgen )
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
            StartGridControl115( ) ;
         }
         if ( wbEnd == 115 )
         {
            wbEnd = 0;
            nRC_GXsfl_115 = (int)(nGXsfl_115_idx-1);
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV86GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV87GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV88GridAppliedFilters);
            ucGridpaginationbar.Render(context, "dvelop.dvpaginationbar", Gridpaginationbar_Internalname, "GRIDPAGINATIONBARContainer");
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
            ucDdo_agexport.SetProperty("DropDownOptionsData", AV93AGExportData);
            ucDdo_agexport.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_agexport_Internalname, "DDO_AGEXPORTContainer");
            /* User Defined Control */
            ucDdc_subscriptions.SetProperty("IconType", Ddc_subscriptions_Icontype);
            ucDdc_subscriptions.SetProperty("Icon", Ddc_subscriptions_Icon);
            ucDdc_subscriptions.SetProperty("Caption", Ddc_subscriptions_Caption);
            ucDdc_subscriptions.SetProperty("Tooltip", Ddc_subscriptions_Tooltip);
            ucDdc_subscriptions.SetProperty("Cls", Ddc_subscriptions_Cls);
            ucDdc_subscriptions.Render(context, "dvelop.gxbootstrap.ddcomponent", Ddc_subscriptions_Internalname, "DDC_SUBSCRIPTIONSContainer");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblJsdynamicfilters_Internalname, lblJsdynamicfilters_Caption, "", "", lblJsdynamicfilters_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_core\\NegocioPJWW.htm");
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
            ucDdo_grid.SetProperty("Format", Ddo_grid_Format);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV82DDO_TitleSettingsIcons);
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
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsTitleSettingsIcons", AV82DDO_TitleSettingsIcons);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsData", AV35ColumnsSelector);
            ucDdo_gridcolumnsselector.Render(context, "dvelop.gxbootstrap.ddogridcolumnsselector", Ddo_gridcolumnsselector_Internalname, "DDO_GRIDCOLUMNSSELECTORContainer");
            wb_table5_149_3X2( true) ;
         }
         else
         {
            wb_table5_149_3X2( false) ;
         }
         return  ;
      }

      protected void wb_table5_149_3X2e( bool wbgen )
      {
         if ( wbgen )
         {
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.SetProperty("HasColumnsSelector", Grid_empowerer_Hascolumnsselector);
            ucGrid_empowerer.SetProperty("FixedColumns", Grid_empowerer_Fixedcolumns);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDiv_wwpauxwc_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0156"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0156"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( bGXsfl_115_Refreshing )
               {
                  if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                  {
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0156"+"");
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
            GxWebStd.gx_div_start( context, divDdo_neginsdataauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 158,'',false,'" + sGXsfl_115_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_neginsdataauxdatetext_Internalname, AV47DDO_NegInsDataAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV47DDO_NegInsDataAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,158);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_neginsdataauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\NegocioPJWW.htm");
            /* User Defined Control */
            ucTfneginsdata_rangepicker.SetProperty("Start Date", AV45DDO_NegInsDataAuxDate);
            ucTfneginsdata_rangepicker.SetProperty("End Date", AV46DDO_NegInsDataAuxDateTo);
            ucTfneginsdata_rangepicker.Render(context, "wwp.daterangepicker", Tfneginsdata_rangepicker_Internalname, "TFNEGINSDATA_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 115 )
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

      protected void START3X2( )
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
            Form.Meta.addItem("description", "Oportunidades de Negócio", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP3X0( ) ;
      }

      protected void WS3X2( )
      {
         START3X2( ) ;
         EVT3X2( ) ;
      }

      protected void EVT3X2( )
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
                              E113X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E123X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E133X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_AGEXPORT.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E143X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDC_SUBSCRIPTIONS.ONLOADCOMPONENT") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E153X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E163X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E173X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DVELOP_CONFIRMPANEL_DELETE.CLOSE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E183X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters1' */
                              E193X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters2' */
                              E203X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS3'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters3' */
                              E213X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E223X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters1' */
                              E233X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR1.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E243X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters2' */
                              E253X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR2.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E263X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR3.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E273X2 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "VGRIDACTIONS.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "VGRIDACTIONS.CLICK") == 0 ) )
                           {
                              nGXsfl_115_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_115_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_115_idx), 4, 0), 4, "0");
                              SubsflControlProps_1152( ) ;
                              cmbavGridactions.Name = cmbavGridactions_Internalname;
                              cmbavGridactions.CurrentValue = cgiGet( cmbavGridactions_Internalname);
                              AV89GridActions = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavGridactions_Internalname), "."), 18, MidpointRounding.ToEven));
                              AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV89GridActions), 4, 0));
                              A345NegID = StringUtil.StrToGuid( cgiGet( edtNegID_Internalname));
                              A356NegCodigo = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtNegCodigo_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A347NegInsHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtNegInsHora_Internalname), 0));
                              A348NegInsDataHora = context.localUtil.CToT( cgiGet( edtNegInsDataHora_Internalname), 0);
                              A349NegInsUsuID = cgiGet( edtNegInsUsuID_Internalname);
                              n349NegInsUsuID = false;
                              A362NegAssunto = StringUtil.Upper( cgiGet( edtNegAssunto_Internalname));
                              A350NegCliID = StringUtil.StrToGuid( cgiGet( edtNegCliID_Internalname));
                              A351NegCliNomeFamiliar = StringUtil.Upper( cgiGet( edtNegCliNomeFamiliar_Internalname));
                              A352NegCpjID = StringUtil.StrToGuid( cgiGet( edtNegCpjID_Internalname));
                              A353NegCpjNomFan = StringUtil.Upper( cgiGet( edtNegCpjNomFan_Internalname));
                              A354NegCpjRazSocial = StringUtil.Upper( cgiGet( edtNegCpjRazSocial_Internalname));
                              A355NegCpjMatricula = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtNegCpjMatricula_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A357NegPjtID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtNegPjtID_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A358NegPjtSigla = cgiGet( edtNegPjtSigla_Internalname);
                              A359NegPjtNome = StringUtil.Upper( cgiGet( edtNegPjtNome_Internalname));
                              A360NegAgcID = cgiGet( edtNegAgcID_Internalname);
                              n360NegAgcID = false;
                              A361NegAgcNome = StringUtil.Upper( cgiGet( edtNegAgcNome_Internalname));
                              n361NegAgcNome = false;
                              A385NegValorAtualizado = context.localUtil.CToN( cgiGet( edtNegValorAtualizado_Internalname), ",", ".");
                              A346NegInsData = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtNegInsData_Internalname), 0));
                              A364NegInsUsuNome = cgiGet( edtNegInsUsuNome_Internalname);
                              n364NegInsUsuNome = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E283X2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E293X2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E303X2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VGRIDACTIONS.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E313X2 ();
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
                                       /* Set Refresh If Negassunto1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vNEGASSUNTO1"), AV20NegAssunto1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV22DynamicFiltersSelector2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator2 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR2"), ",", ".") != Convert.ToDecimal( AV23DynamicFiltersOperator2 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Negassunto2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vNEGASSUNTO2"), AV24NegAssunto2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV26DynamicFiltersSelector3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator3 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR3"), ",", ".") != Convert.ToDecimal( AV27DynamicFiltersOperator3 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Negassunto3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vNEGASSUNTO3"), AV28NegAssunto3) != 0 )
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
                        if ( nCmpId == 156 )
                        {
                           OldWwpaux_wc = cgiGet( "W0156");
                           if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                           {
                              WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                              WebComp_Wwpaux_wc.ComponentInit();
                              WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                              WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                           }
                           if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                           {
                              WebComp_Wwpaux_wc.componentprocess("W0156", "", sEvt);
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

      protected void WE3X2( )
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

      protected void PA3X2( )
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
               GX_FocusControl = chkavNegdel_Internalname;
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
         SubsflControlProps_1152( ) ;
         while ( nGXsfl_115_idx <= nRC_GXsfl_115 )
         {
            sendrow_1152( ) ;
            nGXsfl_115_idx = ((subGrid_Islastpage==1)&&(nGXsfl_115_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_115_idx+1);
            sGXsfl_115_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_115_idx), 4, 0), 4, "0");
            SubsflControlProps_1152( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       string AV17FilterFullText ,
                                       string AV18DynamicFiltersSelector1 ,
                                       short AV19DynamicFiltersOperator1 ,
                                       string AV20NegAssunto1 ,
                                       string AV22DynamicFiltersSelector2 ,
                                       short AV23DynamicFiltersOperator2 ,
                                       string AV24NegAssunto2 ,
                                       string AV26DynamicFiltersSelector3 ,
                                       short AV27DynamicFiltersOperator3 ,
                                       string AV28NegAssunto3 ,
                                       short AV40ManageFiltersExecutionStep ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV35ColumnsSelector ,
                                       string AV106Pgmname ,
                                       bool AV103NegDel ,
                                       bool AV21DynamicFiltersEnabled2 ,
                                       bool AV25DynamicFiltersEnabled3 ,
                                       long AV41TFNegCodigo ,
                                       long AV42TFNegCodigo_To ,
                                       string AV80TFNegAssunto ,
                                       string AV81TFNegAssunto_Sel ,
                                       string AV62TFNegCliNomeFamiliar ,
                                       string AV63TFNegCliNomeFamiliar_Sel ,
                                       string AV64TFNegCpjNomFan ,
                                       string AV65TFNegCpjNomFan_Sel ,
                                       long AV68TFNegCpjMatricula ,
                                       long AV69TFNegCpjMatricula_To ,
                                       string AV74TFNegPjtNome ,
                                       string AV75TFNegPjtNome_Sel ,
                                       string AV78TFNegAgcNome ,
                                       string AV79TFNegAgcNome_Sel ,
                                       decimal AV99TFNegValorAtualizado ,
                                       decimal AV100TFNegValorAtualizado_To ,
                                       DateTime AV43TFNegInsData ,
                                       DateTime AV44TFNegInsData_To ,
                                       string AV97TFNegInsUsuNome ,
                                       string AV98TFNegInsUsuNome_Sel ,
                                       short AV14OrderedBy ,
                                       bool AV15OrderedDsc ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ,
                                       bool AV30DynamicFiltersIgnoreFirst ,
                                       bool AV29DynamicFiltersRemoving ,
                                       bool AV90IsAuthorized_Update ,
                                       bool AV91IsAuthorized_Delete ,
                                       bool AV96IsAuthorized_NegAssunto ,
                                       bool AV92IsAuthorized_NegPjtNome ,
                                       bool AV95IsAuthorized_Insert )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF3X2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_NEGID", GetSecureSignedToken( "", A345NegID, context));
         GxWebStd.gx_hidden_field( context, "NEGID", A345NegID.ToString());
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
         AV103NegDel = StringUtil.StrToBool( StringUtil.BoolToStr( AV103NegDel));
         AssignAttri("", false, "AV103NegDel", AV103NegDel);
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
            AV22DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV22DynamicFiltersSelector2);
            AssignAttri("", false, "AV22DynamicFiltersSelector2", AV22DynamicFiltersSelector2);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV23DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV23DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV26DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV26DynamicFiltersSelector3);
            AssignAttri("", false, "AV26DynamicFiltersSelector3", AV26DynamicFiltersSelector3);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV27DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF3X2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV106Pgmname = "core.NegocioPJWW";
      }

      protected void RF3X2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 115;
         /* Execute user event: Refresh */
         E293X2 ();
         nGXsfl_115_idx = 1;
         sGXsfl_115_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_115_idx), 4, 0), 4, "0");
         SubsflControlProps_1152( ) ;
         bGXsfl_115_Refreshing = true;
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
            SubsflControlProps_1152( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV108Core_negociopjwwds_2_filterfulltext ,
                                                 AV109Core_negociopjwwds_3_dynamicfiltersselector1 ,
                                                 AV110Core_negociopjwwds_4_dynamicfiltersoperator1 ,
                                                 AV111Core_negociopjwwds_5_negassunto1 ,
                                                 AV112Core_negociopjwwds_6_dynamicfiltersenabled2 ,
                                                 AV113Core_negociopjwwds_7_dynamicfiltersselector2 ,
                                                 AV114Core_negociopjwwds_8_dynamicfiltersoperator2 ,
                                                 AV115Core_negociopjwwds_9_negassunto2 ,
                                                 AV116Core_negociopjwwds_10_dynamicfiltersenabled3 ,
                                                 AV117Core_negociopjwwds_11_dynamicfiltersselector3 ,
                                                 AV118Core_negociopjwwds_12_dynamicfiltersoperator3 ,
                                                 AV119Core_negociopjwwds_13_negassunto3 ,
                                                 AV120Core_negociopjwwds_14_tfnegcodigo ,
                                                 AV121Core_negociopjwwds_15_tfnegcodigo_to ,
                                                 AV123Core_negociopjwwds_17_tfnegassunto_sel ,
                                                 AV122Core_negociopjwwds_16_tfnegassunto ,
                                                 AV125Core_negociopjwwds_19_tfnegclinomefamiliar_sel ,
                                                 AV124Core_negociopjwwds_18_tfnegclinomefamiliar ,
                                                 AV127Core_negociopjwwds_21_tfnegcpjnomfan_sel ,
                                                 AV126Core_negociopjwwds_20_tfnegcpjnomfan ,
                                                 AV128Core_negociopjwwds_22_tfnegcpjmatricula ,
                                                 AV129Core_negociopjwwds_23_tfnegcpjmatricula_to ,
                                                 AV131Core_negociopjwwds_25_tfnegpjtnome_sel ,
                                                 AV130Core_negociopjwwds_24_tfnegpjtnome ,
                                                 AV133Core_negociopjwwds_27_tfnegagcnome_sel ,
                                                 AV132Core_negociopjwwds_26_tfnegagcnome ,
                                                 AV134Core_negociopjwwds_28_tfnegvaloratualizado ,
                                                 AV135Core_negociopjwwds_29_tfnegvaloratualizado_to ,
                                                 AV136Core_negociopjwwds_30_tfneginsdata ,
                                                 AV137Core_negociopjwwds_31_tfneginsdata_to ,
                                                 AV139Core_negociopjwwds_33_tfneginsusunome_sel ,
                                                 AV138Core_negociopjwwds_32_tfneginsusunome ,
                                                 A356NegCodigo ,
                                                 A362NegAssunto ,
                                                 A351NegCliNomeFamiliar ,
                                                 A353NegCpjNomFan ,
                                                 A355NegCpjMatricula ,
                                                 A359NegPjtNome ,
                                                 A361NegAgcNome ,
                                                 A385NegValorAtualizado ,
                                                 A364NegInsUsuNome ,
                                                 A346NegInsData ,
                                                 AV14OrderedBy ,
                                                 AV15OrderedDsc ,
                                                 A572NegDel } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL,
                                                 TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.SHORT,
                                                 TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                                 }
            });
            lV108Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV108Core_negociopjwwds_2_filterfulltext), "%", "");
            lV108Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV108Core_negociopjwwds_2_filterfulltext), "%", "");
            lV108Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV108Core_negociopjwwds_2_filterfulltext), "%", "");
            lV108Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV108Core_negociopjwwds_2_filterfulltext), "%", "");
            lV108Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV108Core_negociopjwwds_2_filterfulltext), "%", "");
            lV108Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV108Core_negociopjwwds_2_filterfulltext), "%", "");
            lV108Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV108Core_negociopjwwds_2_filterfulltext), "%", "");
            lV108Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV108Core_negociopjwwds_2_filterfulltext), "%", "");
            lV108Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV108Core_negociopjwwds_2_filterfulltext), "%", "");
            lV111Core_negociopjwwds_5_negassunto1 = StringUtil.Concat( StringUtil.RTrim( AV111Core_negociopjwwds_5_negassunto1), "%", "");
            lV111Core_negociopjwwds_5_negassunto1 = StringUtil.Concat( StringUtil.RTrim( AV111Core_negociopjwwds_5_negassunto1), "%", "");
            lV115Core_negociopjwwds_9_negassunto2 = StringUtil.Concat( StringUtil.RTrim( AV115Core_negociopjwwds_9_negassunto2), "%", "");
            lV115Core_negociopjwwds_9_negassunto2 = StringUtil.Concat( StringUtil.RTrim( AV115Core_negociopjwwds_9_negassunto2), "%", "");
            lV119Core_negociopjwwds_13_negassunto3 = StringUtil.Concat( StringUtil.RTrim( AV119Core_negociopjwwds_13_negassunto3), "%", "");
            lV119Core_negociopjwwds_13_negassunto3 = StringUtil.Concat( StringUtil.RTrim( AV119Core_negociopjwwds_13_negassunto3), "%", "");
            lV122Core_negociopjwwds_16_tfnegassunto = StringUtil.Concat( StringUtil.RTrim( AV122Core_negociopjwwds_16_tfnegassunto), "%", "");
            lV124Core_negociopjwwds_18_tfnegclinomefamiliar = StringUtil.Concat( StringUtil.RTrim( AV124Core_negociopjwwds_18_tfnegclinomefamiliar), "%", "");
            lV126Core_negociopjwwds_20_tfnegcpjnomfan = StringUtil.Concat( StringUtil.RTrim( AV126Core_negociopjwwds_20_tfnegcpjnomfan), "%", "");
            lV130Core_negociopjwwds_24_tfnegpjtnome = StringUtil.Concat( StringUtil.RTrim( AV130Core_negociopjwwds_24_tfnegpjtnome), "%", "");
            lV132Core_negociopjwwds_26_tfnegagcnome = StringUtil.Concat( StringUtil.RTrim( AV132Core_negociopjwwds_26_tfnegagcnome), "%", "");
            lV138Core_negociopjwwds_32_tfneginsusunome = StringUtil.Concat( StringUtil.RTrim( AV138Core_negociopjwwds_32_tfneginsusunome), "%", "");
            /* Using cursor H003X2 */
            pr_default.execute(0, new Object[] {lV108Core_negociopjwwds_2_filterfulltext, lV108Core_negociopjwwds_2_filterfulltext, lV108Core_negociopjwwds_2_filterfulltext, lV108Core_negociopjwwds_2_filterfulltext, lV108Core_negociopjwwds_2_filterfulltext, lV108Core_negociopjwwds_2_filterfulltext, lV108Core_negociopjwwds_2_filterfulltext, lV108Core_negociopjwwds_2_filterfulltext, lV108Core_negociopjwwds_2_filterfulltext, lV111Core_negociopjwwds_5_negassunto1, lV111Core_negociopjwwds_5_negassunto1, lV115Core_negociopjwwds_9_negassunto2, lV115Core_negociopjwwds_9_negassunto2, lV119Core_negociopjwwds_13_negassunto3, lV119Core_negociopjwwds_13_negassunto3, AV120Core_negociopjwwds_14_tfnegcodigo, AV121Core_negociopjwwds_15_tfnegcodigo_to, lV122Core_negociopjwwds_16_tfnegassunto, AV123Core_negociopjwwds_17_tfnegassunto_sel, lV124Core_negociopjwwds_18_tfnegclinomefamiliar, AV125Core_negociopjwwds_19_tfnegclinomefamiliar_sel, lV126Core_negociopjwwds_20_tfnegcpjnomfan, AV127Core_negociopjwwds_21_tfnegcpjnomfan_sel, AV128Core_negociopjwwds_22_tfnegcpjmatricula, AV129Core_negociopjwwds_23_tfnegcpjmatricula_to, lV130Core_negociopjwwds_24_tfnegpjtnome, AV131Core_negociopjwwds_25_tfnegpjtnome_sel, lV132Core_negociopjwwds_26_tfnegagcnome, AV133Core_negociopjwwds_27_tfnegagcnome_sel, AV134Core_negociopjwwds_28_tfnegvaloratualizado, AV135Core_negociopjwwds_29_tfnegvaloratualizado_to, AV136Core_negociopjwwds_30_tfneginsdata, AV137Core_negociopjwwds_31_tfneginsdata_to, lV138Core_negociopjwwds_32_tfneginsusunome, AV139Core_negociopjwwds_33_tfneginsusunome_sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_115_idx = 1;
            sGXsfl_115_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_115_idx), 4, 0), 4, "0");
            SubsflControlProps_1152( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A572NegDel = H003X2_A572NegDel[0];
               A364NegInsUsuNome = H003X2_A364NegInsUsuNome[0];
               n364NegInsUsuNome = H003X2_n364NegInsUsuNome[0];
               A346NegInsData = H003X2_A346NegInsData[0];
               A385NegValorAtualizado = H003X2_A385NegValorAtualizado[0];
               A361NegAgcNome = H003X2_A361NegAgcNome[0];
               n361NegAgcNome = H003X2_n361NegAgcNome[0];
               A360NegAgcID = H003X2_A360NegAgcID[0];
               n360NegAgcID = H003X2_n360NegAgcID[0];
               A359NegPjtNome = H003X2_A359NegPjtNome[0];
               A358NegPjtSigla = H003X2_A358NegPjtSigla[0];
               A357NegPjtID = H003X2_A357NegPjtID[0];
               A355NegCpjMatricula = H003X2_A355NegCpjMatricula[0];
               A354NegCpjRazSocial = H003X2_A354NegCpjRazSocial[0];
               A353NegCpjNomFan = H003X2_A353NegCpjNomFan[0];
               A352NegCpjID = H003X2_A352NegCpjID[0];
               A351NegCliNomeFamiliar = H003X2_A351NegCliNomeFamiliar[0];
               A350NegCliID = H003X2_A350NegCliID[0];
               A362NegAssunto = H003X2_A362NegAssunto[0];
               A349NegInsUsuID = H003X2_A349NegInsUsuID[0];
               n349NegInsUsuID = H003X2_n349NegInsUsuID[0];
               A348NegInsDataHora = H003X2_A348NegInsDataHora[0];
               A347NegInsHora = H003X2_A347NegInsHora[0];
               A356NegCodigo = H003X2_A356NegCodigo[0];
               A345NegID = H003X2_A345NegID[0];
               A357NegPjtID = H003X2_A357NegPjtID[0];
               A355NegCpjMatricula = H003X2_A355NegCpjMatricula[0];
               A358NegPjtSigla = H003X2_A358NegPjtSigla[0];
               E303X2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 115;
            WB3X0( ) ;
         }
         bGXsfl_115_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes3X2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV106Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV106Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV90IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV90IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV91IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV91IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_NEGASSUNTO", AV96IsAuthorized_NegAssunto);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_NEGASSUNTO", GetSecureSignedToken( "", AV96IsAuthorized_NegAssunto, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_NEGPJTNOME", AV92IsAuthorized_NegPjtNome);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_NEGPJTNOME", GetSecureSignedToken( "", AV92IsAuthorized_NegPjtNome, context));
         GxWebStd.gx_hidden_field( context, "gxhash_NEGID"+"_"+sGXsfl_115_idx, GetSecureSignedToken( sGXsfl_115_idx, A345NegID, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV95IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV95IsAuthorized_Insert, context));
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
         AV107Core_negociopjwwds_1_negdel = AV103NegDel;
         AV108Core_negociopjwwds_2_filterfulltext = AV17FilterFullText;
         AV109Core_negociopjwwds_3_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV110Core_negociopjwwds_4_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV111Core_negociopjwwds_5_negassunto1 = AV20NegAssunto1;
         AV112Core_negociopjwwds_6_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV113Core_negociopjwwds_7_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV114Core_negociopjwwds_8_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV115Core_negociopjwwds_9_negassunto2 = AV24NegAssunto2;
         AV116Core_negociopjwwds_10_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV117Core_negociopjwwds_11_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV118Core_negociopjwwds_12_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV119Core_negociopjwwds_13_negassunto3 = AV28NegAssunto3;
         AV120Core_negociopjwwds_14_tfnegcodigo = AV41TFNegCodigo;
         AV121Core_negociopjwwds_15_tfnegcodigo_to = AV42TFNegCodigo_To;
         AV122Core_negociopjwwds_16_tfnegassunto = AV80TFNegAssunto;
         AV123Core_negociopjwwds_17_tfnegassunto_sel = AV81TFNegAssunto_Sel;
         AV124Core_negociopjwwds_18_tfnegclinomefamiliar = AV62TFNegCliNomeFamiliar;
         AV125Core_negociopjwwds_19_tfnegclinomefamiliar_sel = AV63TFNegCliNomeFamiliar_Sel;
         AV126Core_negociopjwwds_20_tfnegcpjnomfan = AV64TFNegCpjNomFan;
         AV127Core_negociopjwwds_21_tfnegcpjnomfan_sel = AV65TFNegCpjNomFan_Sel;
         AV128Core_negociopjwwds_22_tfnegcpjmatricula = AV68TFNegCpjMatricula;
         AV129Core_negociopjwwds_23_tfnegcpjmatricula_to = AV69TFNegCpjMatricula_To;
         AV130Core_negociopjwwds_24_tfnegpjtnome = AV74TFNegPjtNome;
         AV131Core_negociopjwwds_25_tfnegpjtnome_sel = AV75TFNegPjtNome_Sel;
         AV132Core_negociopjwwds_26_tfnegagcnome = AV78TFNegAgcNome;
         AV133Core_negociopjwwds_27_tfnegagcnome_sel = AV79TFNegAgcNome_Sel;
         AV134Core_negociopjwwds_28_tfnegvaloratualizado = AV99TFNegValorAtualizado;
         AV135Core_negociopjwwds_29_tfnegvaloratualizado_to = AV100TFNegValorAtualizado_To;
         AV136Core_negociopjwwds_30_tfneginsdata = AV43TFNegInsData;
         AV137Core_negociopjwwds_31_tfneginsdata_to = AV44TFNegInsData_To;
         AV138Core_negociopjwwds_32_tfneginsusunome = AV97TFNegInsUsuNome;
         AV139Core_negociopjwwds_33_tfneginsusunome_sel = AV98TFNegInsUsuNome_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV108Core_negociopjwwds_2_filterfulltext ,
                                              AV109Core_negociopjwwds_3_dynamicfiltersselector1 ,
                                              AV110Core_negociopjwwds_4_dynamicfiltersoperator1 ,
                                              AV111Core_negociopjwwds_5_negassunto1 ,
                                              AV112Core_negociopjwwds_6_dynamicfiltersenabled2 ,
                                              AV113Core_negociopjwwds_7_dynamicfiltersselector2 ,
                                              AV114Core_negociopjwwds_8_dynamicfiltersoperator2 ,
                                              AV115Core_negociopjwwds_9_negassunto2 ,
                                              AV116Core_negociopjwwds_10_dynamicfiltersenabled3 ,
                                              AV117Core_negociopjwwds_11_dynamicfiltersselector3 ,
                                              AV118Core_negociopjwwds_12_dynamicfiltersoperator3 ,
                                              AV119Core_negociopjwwds_13_negassunto3 ,
                                              AV120Core_negociopjwwds_14_tfnegcodigo ,
                                              AV121Core_negociopjwwds_15_tfnegcodigo_to ,
                                              AV123Core_negociopjwwds_17_tfnegassunto_sel ,
                                              AV122Core_negociopjwwds_16_tfnegassunto ,
                                              AV125Core_negociopjwwds_19_tfnegclinomefamiliar_sel ,
                                              AV124Core_negociopjwwds_18_tfnegclinomefamiliar ,
                                              AV127Core_negociopjwwds_21_tfnegcpjnomfan_sel ,
                                              AV126Core_negociopjwwds_20_tfnegcpjnomfan ,
                                              AV128Core_negociopjwwds_22_tfnegcpjmatricula ,
                                              AV129Core_negociopjwwds_23_tfnegcpjmatricula_to ,
                                              AV131Core_negociopjwwds_25_tfnegpjtnome_sel ,
                                              AV130Core_negociopjwwds_24_tfnegpjtnome ,
                                              AV133Core_negociopjwwds_27_tfnegagcnome_sel ,
                                              AV132Core_negociopjwwds_26_tfnegagcnome ,
                                              AV134Core_negociopjwwds_28_tfnegvaloratualizado ,
                                              AV135Core_negociopjwwds_29_tfnegvaloratualizado_to ,
                                              AV136Core_negociopjwwds_30_tfneginsdata ,
                                              AV137Core_negociopjwwds_31_tfneginsdata_to ,
                                              AV139Core_negociopjwwds_33_tfneginsusunome_sel ,
                                              AV138Core_negociopjwwds_32_tfneginsusunome ,
                                              A356NegCodigo ,
                                              A362NegAssunto ,
                                              A351NegCliNomeFamiliar ,
                                              A353NegCpjNomFan ,
                                              A355NegCpjMatricula ,
                                              A359NegPjtNome ,
                                              A361NegAgcNome ,
                                              A385NegValorAtualizado ,
                                              A364NegInsUsuNome ,
                                              A346NegInsData ,
                                              AV14OrderedBy ,
                                              AV15OrderedDsc ,
                                              A572NegDel } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.SHORT,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV108Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV108Core_negociopjwwds_2_filterfulltext), "%", "");
         lV108Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV108Core_negociopjwwds_2_filterfulltext), "%", "");
         lV108Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV108Core_negociopjwwds_2_filterfulltext), "%", "");
         lV108Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV108Core_negociopjwwds_2_filterfulltext), "%", "");
         lV108Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV108Core_negociopjwwds_2_filterfulltext), "%", "");
         lV108Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV108Core_negociopjwwds_2_filterfulltext), "%", "");
         lV108Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV108Core_negociopjwwds_2_filterfulltext), "%", "");
         lV108Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV108Core_negociopjwwds_2_filterfulltext), "%", "");
         lV108Core_negociopjwwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV108Core_negociopjwwds_2_filterfulltext), "%", "");
         lV111Core_negociopjwwds_5_negassunto1 = StringUtil.Concat( StringUtil.RTrim( AV111Core_negociopjwwds_5_negassunto1), "%", "");
         lV111Core_negociopjwwds_5_negassunto1 = StringUtil.Concat( StringUtil.RTrim( AV111Core_negociopjwwds_5_negassunto1), "%", "");
         lV115Core_negociopjwwds_9_negassunto2 = StringUtil.Concat( StringUtil.RTrim( AV115Core_negociopjwwds_9_negassunto2), "%", "");
         lV115Core_negociopjwwds_9_negassunto2 = StringUtil.Concat( StringUtil.RTrim( AV115Core_negociopjwwds_9_negassunto2), "%", "");
         lV119Core_negociopjwwds_13_negassunto3 = StringUtil.Concat( StringUtil.RTrim( AV119Core_negociopjwwds_13_negassunto3), "%", "");
         lV119Core_negociopjwwds_13_negassunto3 = StringUtil.Concat( StringUtil.RTrim( AV119Core_negociopjwwds_13_negassunto3), "%", "");
         lV122Core_negociopjwwds_16_tfnegassunto = StringUtil.Concat( StringUtil.RTrim( AV122Core_negociopjwwds_16_tfnegassunto), "%", "");
         lV124Core_negociopjwwds_18_tfnegclinomefamiliar = StringUtil.Concat( StringUtil.RTrim( AV124Core_negociopjwwds_18_tfnegclinomefamiliar), "%", "");
         lV126Core_negociopjwwds_20_tfnegcpjnomfan = StringUtil.Concat( StringUtil.RTrim( AV126Core_negociopjwwds_20_tfnegcpjnomfan), "%", "");
         lV130Core_negociopjwwds_24_tfnegpjtnome = StringUtil.Concat( StringUtil.RTrim( AV130Core_negociopjwwds_24_tfnegpjtnome), "%", "");
         lV132Core_negociopjwwds_26_tfnegagcnome = StringUtil.Concat( StringUtil.RTrim( AV132Core_negociopjwwds_26_tfnegagcnome), "%", "");
         lV138Core_negociopjwwds_32_tfneginsusunome = StringUtil.Concat( StringUtil.RTrim( AV138Core_negociopjwwds_32_tfneginsusunome), "%", "");
         /* Using cursor H003X3 */
         pr_default.execute(1, new Object[] {lV108Core_negociopjwwds_2_filterfulltext, lV108Core_negociopjwwds_2_filterfulltext, lV108Core_negociopjwwds_2_filterfulltext, lV108Core_negociopjwwds_2_filterfulltext, lV108Core_negociopjwwds_2_filterfulltext, lV108Core_negociopjwwds_2_filterfulltext, lV108Core_negociopjwwds_2_filterfulltext, lV108Core_negociopjwwds_2_filterfulltext, lV108Core_negociopjwwds_2_filterfulltext, lV111Core_negociopjwwds_5_negassunto1, lV111Core_negociopjwwds_5_negassunto1, lV115Core_negociopjwwds_9_negassunto2, lV115Core_negociopjwwds_9_negassunto2, lV119Core_negociopjwwds_13_negassunto3, lV119Core_negociopjwwds_13_negassunto3, AV120Core_negociopjwwds_14_tfnegcodigo, AV121Core_negociopjwwds_15_tfnegcodigo_to, lV122Core_negociopjwwds_16_tfnegassunto, AV123Core_negociopjwwds_17_tfnegassunto_sel, lV124Core_negociopjwwds_18_tfnegclinomefamiliar, AV125Core_negociopjwwds_19_tfnegclinomefamiliar_sel, lV126Core_negociopjwwds_20_tfnegcpjnomfan, AV127Core_negociopjwwds_21_tfnegcpjnomfan_sel, AV128Core_negociopjwwds_22_tfnegcpjmatricula, AV129Core_negociopjwwds_23_tfnegcpjmatricula_to, lV130Core_negociopjwwds_24_tfnegpjtnome, AV131Core_negociopjwwds_25_tfnegpjtnome_sel, lV132Core_negociopjwwds_26_tfnegagcnome, AV133Core_negociopjwwds_27_tfnegagcnome_sel, AV134Core_negociopjwwds_28_tfnegvaloratualizado, AV135Core_negociopjwwds_29_tfnegvaloratualizado_to, AV136Core_negociopjwwds_30_tfneginsdata, AV137Core_negociopjwwds_31_tfneginsdata_to, lV138Core_negociopjwwds_32_tfneginsusunome, AV139Core_negociopjwwds_33_tfneginsusunome_sel});
         GRID_nRecordCount = H003X3_AGRID_nRecordCount[0];
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
         AV107Core_negociopjwwds_1_negdel = AV103NegDel;
         AV108Core_negociopjwwds_2_filterfulltext = AV17FilterFullText;
         AV109Core_negociopjwwds_3_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV110Core_negociopjwwds_4_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV111Core_negociopjwwds_5_negassunto1 = AV20NegAssunto1;
         AV112Core_negociopjwwds_6_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV113Core_negociopjwwds_7_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV114Core_negociopjwwds_8_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV115Core_negociopjwwds_9_negassunto2 = AV24NegAssunto2;
         AV116Core_negociopjwwds_10_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV117Core_negociopjwwds_11_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV118Core_negociopjwwds_12_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV119Core_negociopjwwds_13_negassunto3 = AV28NegAssunto3;
         AV120Core_negociopjwwds_14_tfnegcodigo = AV41TFNegCodigo;
         AV121Core_negociopjwwds_15_tfnegcodigo_to = AV42TFNegCodigo_To;
         AV122Core_negociopjwwds_16_tfnegassunto = AV80TFNegAssunto;
         AV123Core_negociopjwwds_17_tfnegassunto_sel = AV81TFNegAssunto_Sel;
         AV124Core_negociopjwwds_18_tfnegclinomefamiliar = AV62TFNegCliNomeFamiliar;
         AV125Core_negociopjwwds_19_tfnegclinomefamiliar_sel = AV63TFNegCliNomeFamiliar_Sel;
         AV126Core_negociopjwwds_20_tfnegcpjnomfan = AV64TFNegCpjNomFan;
         AV127Core_negociopjwwds_21_tfnegcpjnomfan_sel = AV65TFNegCpjNomFan_Sel;
         AV128Core_negociopjwwds_22_tfnegcpjmatricula = AV68TFNegCpjMatricula;
         AV129Core_negociopjwwds_23_tfnegcpjmatricula_to = AV69TFNegCpjMatricula_To;
         AV130Core_negociopjwwds_24_tfnegpjtnome = AV74TFNegPjtNome;
         AV131Core_negociopjwwds_25_tfnegpjtnome_sel = AV75TFNegPjtNome_Sel;
         AV132Core_negociopjwwds_26_tfnegagcnome = AV78TFNegAgcNome;
         AV133Core_negociopjwwds_27_tfnegagcnome_sel = AV79TFNegAgcNome_Sel;
         AV134Core_negociopjwwds_28_tfnegvaloratualizado = AV99TFNegValorAtualizado;
         AV135Core_negociopjwwds_29_tfnegvaloratualizado_to = AV100TFNegValorAtualizado_To;
         AV136Core_negociopjwwds_30_tfneginsdata = AV43TFNegInsData;
         AV137Core_negociopjwwds_31_tfneginsdata_to = AV44TFNegInsData_To;
         AV138Core_negociopjwwds_32_tfneginsusunome = AV97TFNegInsUsuNome;
         AV139Core_negociopjwwds_33_tfneginsusunome_sel = AV98TFNegInsUsuNome_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20NegAssunto1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24NegAssunto2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28NegAssunto3, AV40ManageFiltersExecutionStep, AV35ColumnsSelector, AV106Pgmname, AV103NegDel, AV21DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV41TFNegCodigo, AV42TFNegCodigo_To, AV80TFNegAssunto, AV81TFNegAssunto_Sel, AV62TFNegCliNomeFamiliar, AV63TFNegCliNomeFamiliar_Sel, AV64TFNegCpjNomFan, AV65TFNegCpjNomFan_Sel, AV68TFNegCpjMatricula, AV69TFNegCpjMatricula_To, AV74TFNegPjtNome, AV75TFNegPjtNome_Sel, AV78TFNegAgcNome, AV79TFNegAgcNome_Sel, AV99TFNegValorAtualizado, AV100TFNegValorAtualizado_To, AV43TFNegInsData, AV44TFNegInsData_To, AV97TFNegInsUsuNome, AV98TFNegInsUsuNome_Sel, AV14OrderedBy, AV15OrderedDsc, AV11GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving, AV90IsAuthorized_Update, AV91IsAuthorized_Delete, AV96IsAuthorized_NegAssunto, AV92IsAuthorized_NegPjtNome, AV95IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV107Core_negociopjwwds_1_negdel = AV103NegDel;
         AV108Core_negociopjwwds_2_filterfulltext = AV17FilterFullText;
         AV109Core_negociopjwwds_3_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV110Core_negociopjwwds_4_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV111Core_negociopjwwds_5_negassunto1 = AV20NegAssunto1;
         AV112Core_negociopjwwds_6_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV113Core_negociopjwwds_7_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV114Core_negociopjwwds_8_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV115Core_negociopjwwds_9_negassunto2 = AV24NegAssunto2;
         AV116Core_negociopjwwds_10_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV117Core_negociopjwwds_11_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV118Core_negociopjwwds_12_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV119Core_negociopjwwds_13_negassunto3 = AV28NegAssunto3;
         AV120Core_negociopjwwds_14_tfnegcodigo = AV41TFNegCodigo;
         AV121Core_negociopjwwds_15_tfnegcodigo_to = AV42TFNegCodigo_To;
         AV122Core_negociopjwwds_16_tfnegassunto = AV80TFNegAssunto;
         AV123Core_negociopjwwds_17_tfnegassunto_sel = AV81TFNegAssunto_Sel;
         AV124Core_negociopjwwds_18_tfnegclinomefamiliar = AV62TFNegCliNomeFamiliar;
         AV125Core_negociopjwwds_19_tfnegclinomefamiliar_sel = AV63TFNegCliNomeFamiliar_Sel;
         AV126Core_negociopjwwds_20_tfnegcpjnomfan = AV64TFNegCpjNomFan;
         AV127Core_negociopjwwds_21_tfnegcpjnomfan_sel = AV65TFNegCpjNomFan_Sel;
         AV128Core_negociopjwwds_22_tfnegcpjmatricula = AV68TFNegCpjMatricula;
         AV129Core_negociopjwwds_23_tfnegcpjmatricula_to = AV69TFNegCpjMatricula_To;
         AV130Core_negociopjwwds_24_tfnegpjtnome = AV74TFNegPjtNome;
         AV131Core_negociopjwwds_25_tfnegpjtnome_sel = AV75TFNegPjtNome_Sel;
         AV132Core_negociopjwwds_26_tfnegagcnome = AV78TFNegAgcNome;
         AV133Core_negociopjwwds_27_tfnegagcnome_sel = AV79TFNegAgcNome_Sel;
         AV134Core_negociopjwwds_28_tfnegvaloratualizado = AV99TFNegValorAtualizado;
         AV135Core_negociopjwwds_29_tfnegvaloratualizado_to = AV100TFNegValorAtualizado_To;
         AV136Core_negociopjwwds_30_tfneginsdata = AV43TFNegInsData;
         AV137Core_negociopjwwds_31_tfneginsdata_to = AV44TFNegInsData_To;
         AV138Core_negociopjwwds_32_tfneginsusunome = AV97TFNegInsUsuNome;
         AV139Core_negociopjwwds_33_tfneginsusunome_sel = AV98TFNegInsUsuNome_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20NegAssunto1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24NegAssunto2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28NegAssunto3, AV40ManageFiltersExecutionStep, AV35ColumnsSelector, AV106Pgmname, AV103NegDel, AV21DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV41TFNegCodigo, AV42TFNegCodigo_To, AV80TFNegAssunto, AV81TFNegAssunto_Sel, AV62TFNegCliNomeFamiliar, AV63TFNegCliNomeFamiliar_Sel, AV64TFNegCpjNomFan, AV65TFNegCpjNomFan_Sel, AV68TFNegCpjMatricula, AV69TFNegCpjMatricula_To, AV74TFNegPjtNome, AV75TFNegPjtNome_Sel, AV78TFNegAgcNome, AV79TFNegAgcNome_Sel, AV99TFNegValorAtualizado, AV100TFNegValorAtualizado_To, AV43TFNegInsData, AV44TFNegInsData_To, AV97TFNegInsUsuNome, AV98TFNegInsUsuNome_Sel, AV14OrderedBy, AV15OrderedDsc, AV11GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving, AV90IsAuthorized_Update, AV91IsAuthorized_Delete, AV96IsAuthorized_NegAssunto, AV92IsAuthorized_NegPjtNome, AV95IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV107Core_negociopjwwds_1_negdel = AV103NegDel;
         AV108Core_negociopjwwds_2_filterfulltext = AV17FilterFullText;
         AV109Core_negociopjwwds_3_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV110Core_negociopjwwds_4_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV111Core_negociopjwwds_5_negassunto1 = AV20NegAssunto1;
         AV112Core_negociopjwwds_6_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV113Core_negociopjwwds_7_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV114Core_negociopjwwds_8_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV115Core_negociopjwwds_9_negassunto2 = AV24NegAssunto2;
         AV116Core_negociopjwwds_10_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV117Core_negociopjwwds_11_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV118Core_negociopjwwds_12_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV119Core_negociopjwwds_13_negassunto3 = AV28NegAssunto3;
         AV120Core_negociopjwwds_14_tfnegcodigo = AV41TFNegCodigo;
         AV121Core_negociopjwwds_15_tfnegcodigo_to = AV42TFNegCodigo_To;
         AV122Core_negociopjwwds_16_tfnegassunto = AV80TFNegAssunto;
         AV123Core_negociopjwwds_17_tfnegassunto_sel = AV81TFNegAssunto_Sel;
         AV124Core_negociopjwwds_18_tfnegclinomefamiliar = AV62TFNegCliNomeFamiliar;
         AV125Core_negociopjwwds_19_tfnegclinomefamiliar_sel = AV63TFNegCliNomeFamiliar_Sel;
         AV126Core_negociopjwwds_20_tfnegcpjnomfan = AV64TFNegCpjNomFan;
         AV127Core_negociopjwwds_21_tfnegcpjnomfan_sel = AV65TFNegCpjNomFan_Sel;
         AV128Core_negociopjwwds_22_tfnegcpjmatricula = AV68TFNegCpjMatricula;
         AV129Core_negociopjwwds_23_tfnegcpjmatricula_to = AV69TFNegCpjMatricula_To;
         AV130Core_negociopjwwds_24_tfnegpjtnome = AV74TFNegPjtNome;
         AV131Core_negociopjwwds_25_tfnegpjtnome_sel = AV75TFNegPjtNome_Sel;
         AV132Core_negociopjwwds_26_tfnegagcnome = AV78TFNegAgcNome;
         AV133Core_negociopjwwds_27_tfnegagcnome_sel = AV79TFNegAgcNome_Sel;
         AV134Core_negociopjwwds_28_tfnegvaloratualizado = AV99TFNegValorAtualizado;
         AV135Core_negociopjwwds_29_tfnegvaloratualizado_to = AV100TFNegValorAtualizado_To;
         AV136Core_negociopjwwds_30_tfneginsdata = AV43TFNegInsData;
         AV137Core_negociopjwwds_31_tfneginsdata_to = AV44TFNegInsData_To;
         AV138Core_negociopjwwds_32_tfneginsusunome = AV97TFNegInsUsuNome;
         AV139Core_negociopjwwds_33_tfneginsusunome_sel = AV98TFNegInsUsuNome_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20NegAssunto1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24NegAssunto2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28NegAssunto3, AV40ManageFiltersExecutionStep, AV35ColumnsSelector, AV106Pgmname, AV103NegDel, AV21DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV41TFNegCodigo, AV42TFNegCodigo_To, AV80TFNegAssunto, AV81TFNegAssunto_Sel, AV62TFNegCliNomeFamiliar, AV63TFNegCliNomeFamiliar_Sel, AV64TFNegCpjNomFan, AV65TFNegCpjNomFan_Sel, AV68TFNegCpjMatricula, AV69TFNegCpjMatricula_To, AV74TFNegPjtNome, AV75TFNegPjtNome_Sel, AV78TFNegAgcNome, AV79TFNegAgcNome_Sel, AV99TFNegValorAtualizado, AV100TFNegValorAtualizado_To, AV43TFNegInsData, AV44TFNegInsData_To, AV97TFNegInsUsuNome, AV98TFNegInsUsuNome_Sel, AV14OrderedBy, AV15OrderedDsc, AV11GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving, AV90IsAuthorized_Update, AV91IsAuthorized_Delete, AV96IsAuthorized_NegAssunto, AV92IsAuthorized_NegPjtNome, AV95IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV107Core_negociopjwwds_1_negdel = AV103NegDel;
         AV108Core_negociopjwwds_2_filterfulltext = AV17FilterFullText;
         AV109Core_negociopjwwds_3_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV110Core_negociopjwwds_4_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV111Core_negociopjwwds_5_negassunto1 = AV20NegAssunto1;
         AV112Core_negociopjwwds_6_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV113Core_negociopjwwds_7_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV114Core_negociopjwwds_8_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV115Core_negociopjwwds_9_negassunto2 = AV24NegAssunto2;
         AV116Core_negociopjwwds_10_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV117Core_negociopjwwds_11_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV118Core_negociopjwwds_12_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV119Core_negociopjwwds_13_negassunto3 = AV28NegAssunto3;
         AV120Core_negociopjwwds_14_tfnegcodigo = AV41TFNegCodigo;
         AV121Core_negociopjwwds_15_tfnegcodigo_to = AV42TFNegCodigo_To;
         AV122Core_negociopjwwds_16_tfnegassunto = AV80TFNegAssunto;
         AV123Core_negociopjwwds_17_tfnegassunto_sel = AV81TFNegAssunto_Sel;
         AV124Core_negociopjwwds_18_tfnegclinomefamiliar = AV62TFNegCliNomeFamiliar;
         AV125Core_negociopjwwds_19_tfnegclinomefamiliar_sel = AV63TFNegCliNomeFamiliar_Sel;
         AV126Core_negociopjwwds_20_tfnegcpjnomfan = AV64TFNegCpjNomFan;
         AV127Core_negociopjwwds_21_tfnegcpjnomfan_sel = AV65TFNegCpjNomFan_Sel;
         AV128Core_negociopjwwds_22_tfnegcpjmatricula = AV68TFNegCpjMatricula;
         AV129Core_negociopjwwds_23_tfnegcpjmatricula_to = AV69TFNegCpjMatricula_To;
         AV130Core_negociopjwwds_24_tfnegpjtnome = AV74TFNegPjtNome;
         AV131Core_negociopjwwds_25_tfnegpjtnome_sel = AV75TFNegPjtNome_Sel;
         AV132Core_negociopjwwds_26_tfnegagcnome = AV78TFNegAgcNome;
         AV133Core_negociopjwwds_27_tfnegagcnome_sel = AV79TFNegAgcNome_Sel;
         AV134Core_negociopjwwds_28_tfnegvaloratualizado = AV99TFNegValorAtualizado;
         AV135Core_negociopjwwds_29_tfnegvaloratualizado_to = AV100TFNegValorAtualizado_To;
         AV136Core_negociopjwwds_30_tfneginsdata = AV43TFNegInsData;
         AV137Core_negociopjwwds_31_tfneginsdata_to = AV44TFNegInsData_To;
         AV138Core_negociopjwwds_32_tfneginsusunome = AV97TFNegInsUsuNome;
         AV139Core_negociopjwwds_33_tfneginsusunome_sel = AV98TFNegInsUsuNome_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20NegAssunto1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24NegAssunto2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28NegAssunto3, AV40ManageFiltersExecutionStep, AV35ColumnsSelector, AV106Pgmname, AV103NegDel, AV21DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV41TFNegCodigo, AV42TFNegCodigo_To, AV80TFNegAssunto, AV81TFNegAssunto_Sel, AV62TFNegCliNomeFamiliar, AV63TFNegCliNomeFamiliar_Sel, AV64TFNegCpjNomFan, AV65TFNegCpjNomFan_Sel, AV68TFNegCpjMatricula, AV69TFNegCpjMatricula_To, AV74TFNegPjtNome, AV75TFNegPjtNome_Sel, AV78TFNegAgcNome, AV79TFNegAgcNome_Sel, AV99TFNegValorAtualizado, AV100TFNegValorAtualizado_To, AV43TFNegInsData, AV44TFNegInsData_To, AV97TFNegInsUsuNome, AV98TFNegInsUsuNome_Sel, AV14OrderedBy, AV15OrderedDsc, AV11GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving, AV90IsAuthorized_Update, AV91IsAuthorized_Delete, AV96IsAuthorized_NegAssunto, AV92IsAuthorized_NegPjtNome, AV95IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV107Core_negociopjwwds_1_negdel = AV103NegDel;
         AV108Core_negociopjwwds_2_filterfulltext = AV17FilterFullText;
         AV109Core_negociopjwwds_3_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV110Core_negociopjwwds_4_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV111Core_negociopjwwds_5_negassunto1 = AV20NegAssunto1;
         AV112Core_negociopjwwds_6_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV113Core_negociopjwwds_7_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV114Core_negociopjwwds_8_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV115Core_negociopjwwds_9_negassunto2 = AV24NegAssunto2;
         AV116Core_negociopjwwds_10_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV117Core_negociopjwwds_11_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV118Core_negociopjwwds_12_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV119Core_negociopjwwds_13_negassunto3 = AV28NegAssunto3;
         AV120Core_negociopjwwds_14_tfnegcodigo = AV41TFNegCodigo;
         AV121Core_negociopjwwds_15_tfnegcodigo_to = AV42TFNegCodigo_To;
         AV122Core_negociopjwwds_16_tfnegassunto = AV80TFNegAssunto;
         AV123Core_negociopjwwds_17_tfnegassunto_sel = AV81TFNegAssunto_Sel;
         AV124Core_negociopjwwds_18_tfnegclinomefamiliar = AV62TFNegCliNomeFamiliar;
         AV125Core_negociopjwwds_19_tfnegclinomefamiliar_sel = AV63TFNegCliNomeFamiliar_Sel;
         AV126Core_negociopjwwds_20_tfnegcpjnomfan = AV64TFNegCpjNomFan;
         AV127Core_negociopjwwds_21_tfnegcpjnomfan_sel = AV65TFNegCpjNomFan_Sel;
         AV128Core_negociopjwwds_22_tfnegcpjmatricula = AV68TFNegCpjMatricula;
         AV129Core_negociopjwwds_23_tfnegcpjmatricula_to = AV69TFNegCpjMatricula_To;
         AV130Core_negociopjwwds_24_tfnegpjtnome = AV74TFNegPjtNome;
         AV131Core_negociopjwwds_25_tfnegpjtnome_sel = AV75TFNegPjtNome_Sel;
         AV132Core_negociopjwwds_26_tfnegagcnome = AV78TFNegAgcNome;
         AV133Core_negociopjwwds_27_tfnegagcnome_sel = AV79TFNegAgcNome_Sel;
         AV134Core_negociopjwwds_28_tfnegvaloratualizado = AV99TFNegValorAtualizado;
         AV135Core_negociopjwwds_29_tfnegvaloratualizado_to = AV100TFNegValorAtualizado_To;
         AV136Core_negociopjwwds_30_tfneginsdata = AV43TFNegInsData;
         AV137Core_negociopjwwds_31_tfneginsdata_to = AV44TFNegInsData_To;
         AV138Core_negociopjwwds_32_tfneginsusunome = AV97TFNegInsUsuNome;
         AV139Core_negociopjwwds_33_tfneginsusunome_sel = AV98TFNegInsUsuNome_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20NegAssunto1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24NegAssunto2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28NegAssunto3, AV40ManageFiltersExecutionStep, AV35ColumnsSelector, AV106Pgmname, AV103NegDel, AV21DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV41TFNegCodigo, AV42TFNegCodigo_To, AV80TFNegAssunto, AV81TFNegAssunto_Sel, AV62TFNegCliNomeFamiliar, AV63TFNegCliNomeFamiliar_Sel, AV64TFNegCpjNomFan, AV65TFNegCpjNomFan_Sel, AV68TFNegCpjMatricula, AV69TFNegCpjMatricula_To, AV74TFNegPjtNome, AV75TFNegPjtNome_Sel, AV78TFNegAgcNome, AV79TFNegAgcNome_Sel, AV99TFNegValorAtualizado, AV100TFNegValorAtualizado_To, AV43TFNegInsData, AV44TFNegInsData_To, AV97TFNegInsUsuNome, AV98TFNegInsUsuNome_Sel, AV14OrderedBy, AV15OrderedDsc, AV11GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving, AV90IsAuthorized_Update, AV91IsAuthorized_Delete, AV96IsAuthorized_NegAssunto, AV92IsAuthorized_NegPjtNome, AV95IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV106Pgmname = "core.NegocioPJWW";
         fix_multi_value_controls( ) ;
      }

      protected void STRUP3X0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E283X2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV38ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vAGEXPORTDATA"), AV93AGExportData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV82DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vCOLUMNSSELECTOR"), AV35ColumnsSelector);
            /* Read saved values. */
            nRC_GXsfl_115 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_115"), ",", "."), 18, MidpointRounding.ToEven));
            AV86GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ",", "."), 18, MidpointRounding.ToEven));
            AV87GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ",", "."), 18, MidpointRounding.ToEven));
            AV88GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            AV45DDO_NegInsDataAuxDate = context.localUtil.CToD( cgiGet( "vDDO_NEGINSDATAAUXDATE"), 0);
            AV46DDO_NegInsDataAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_NEGINSDATAAUXDATETO"), 0);
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
            Ddo_grid_Format = cgiGet( "DDO_GRID_Format");
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
            Dvelop_confirmpanel_delete_Title = cgiGet( "DVELOP_CONFIRMPANEL_DELETE_Title");
            Dvelop_confirmpanel_delete_Confirmationtext = cgiGet( "DVELOP_CONFIRMPANEL_DELETE_Confirmationtext");
            Dvelop_confirmpanel_delete_Yesbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_DELETE_Yesbuttoncaption");
            Dvelop_confirmpanel_delete_Nobuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_DELETE_Nobuttoncaption");
            Dvelop_confirmpanel_delete_Cancelbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_DELETE_Cancelbuttoncaption");
            Dvelop_confirmpanel_delete_Yesbuttonposition = cgiGet( "DVELOP_CONFIRMPANEL_DELETE_Yesbuttonposition");
            Dvelop_confirmpanel_delete_Confirmtype = cgiGet( "DVELOP_CONFIRMPANEL_DELETE_Confirmtype");
            Grid_empowerer_Gridinternalname = cgiGet( "GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hastitlesettings"));
            Grid_empowerer_Hascolumnsselector = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hascolumnsselector"));
            Grid_empowerer_Fixedcolumns = cgiGet( "GRID_EMPOWERER_Fixedcolumns");
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
            Dvelop_confirmpanel_delete_Result = cgiGet( "DVELOP_CONFIRMPANEL_DELETE_Result");
            Ddo_agexport_Activeeventkey = cgiGet( "DDO_AGEXPORT_Activeeventkey");
            /* Read variables values. */
            AV103NegDel = StringUtil.StrToBool( cgiGet( chkavNegdel_Internalname));
            AssignAttri("", false, "AV103NegDel", AV103NegDel);
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
            AV20NegAssunto1 = StringUtil.Upper( cgiGet( edtavNegassunto1_Internalname));
            AssignAttri("", false, "AV20NegAssunto1", AV20NegAssunto1);
            cmbavDynamicfiltersselector2.Name = cmbavDynamicfiltersselector2_Internalname;
            cmbavDynamicfiltersselector2.CurrentValue = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AV22DynamicFiltersSelector2 = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AssignAttri("", false, "AV22DynamicFiltersSelector2", AV22DynamicFiltersSelector2);
            cmbavDynamicfiltersoperator2.Name = cmbavDynamicfiltersoperator2_Internalname;
            cmbavDynamicfiltersoperator2.CurrentValue = cgiGet( cmbavDynamicfiltersoperator2_Internalname);
            AV23DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator2_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV23DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
            AV24NegAssunto2 = StringUtil.Upper( cgiGet( edtavNegassunto2_Internalname));
            AssignAttri("", false, "AV24NegAssunto2", AV24NegAssunto2);
            cmbavDynamicfiltersselector3.Name = cmbavDynamicfiltersselector3_Internalname;
            cmbavDynamicfiltersselector3.CurrentValue = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AV26DynamicFiltersSelector3 = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AssignAttri("", false, "AV26DynamicFiltersSelector3", AV26DynamicFiltersSelector3);
            cmbavDynamicfiltersoperator3.Name = cmbavDynamicfiltersoperator3_Internalname;
            cmbavDynamicfiltersoperator3.CurrentValue = cgiGet( cmbavDynamicfiltersoperator3_Internalname);
            AV27DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator3_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
            AV28NegAssunto3 = StringUtil.Upper( cgiGet( edtavNegassunto3_Internalname));
            AssignAttri("", false, "AV28NegAssunto3", AV28NegAssunto3);
            AV47DDO_NegInsDataAuxDateText = cgiGet( edtavDdo_neginsdataauxdatetext_Internalname);
            AssignAttri("", false, "AV47DDO_NegInsDataAuxDateText", AV47DDO_NegInsDataAuxDateText);
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
            if ( StringUtil.StrCmp(cgiGet( "GXH_vNEGASSUNTO1"), AV20NegAssunto1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV22DynamicFiltersSelector2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR2"), ",", ".") != Convert.ToDecimal( AV23DynamicFiltersOperator2 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vNEGASSUNTO2"), AV24NegAssunto2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV26DynamicFiltersSelector3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR3"), ",", ".") != Convert.ToDecimal( AV27DynamicFiltersOperator3 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vNEGASSUNTO3"), AV28NegAssunto3) != 0 )
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
         E283X2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E283X2( )
      {
         /* Start Routine */
         returnInSub = false;
         this.executeUsercontrolMethod("", false, "TFNEGINSDATA_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_neginsdataauxdatetext_Internalname});
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
         AV18DynamicFiltersSelector1 = "NEGASSUNTO";
         AssignAttri("", false, "AV18DynamicFiltersSelector1", AV18DynamicFiltersSelector1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV22DynamicFiltersSelector2 = "NEGASSUNTO";
         AssignAttri("", false, "AV22DynamicFiltersSelector2", AV22DynamicFiltersSelector2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV26DynamicFiltersSelector3 = "NEGASSUNTO";
         AssignAttri("", false, "AV26DynamicFiltersSelector3", AV26DynamicFiltersSelector3);
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
         AV93AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV94AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV94AGExportDataItem.gxTpr_Title = "Excel";
         AV94AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "da69a816-fd11-445b-8aaf-1a2f7f1acc93", "", context.GetTheme( ))));
         AV94AGExportDataItem.gxTpr_Eventkey = "Export";
         AV94AGExportDataItem.gxTpr_Isdivider = false;
         AV93AGExportData.Add(AV94AGExportDataItem, 0);
         AV94AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV94AGExportDataItem.gxTpr_Title = "PDF";
         AV94AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "776fb79c-a0a1-4302-b5e5-d773dbe1a297", "", context.GetTheme( ))));
         AV94AGExportDataItem.gxTpr_Eventkey = "ExportReport";
         AV94AGExportDataItem.gxTpr_Isdivider = false;
         AV93AGExportData.Add(AV94AGExportDataItem, 0);
         Ddc_subscriptions_Titlecontrolidtoreplace = bttBtnsubscriptions_Internalname;
         ucDdc_subscriptions.SendProperty(context, "", false, Ddc_subscriptions_Internalname, "TitleControlIdToReplace", Ddc_subscriptions_Titlecontrolidtoreplace);
         GXt_boolean1 = AV96IsAuthorized_NegAssunto;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "negociopjview_Execute", out  GXt_boolean1) ;
         AV96IsAuthorized_NegAssunto = GXt_boolean1;
         AssignAttri("", false, "AV96IsAuthorized_NegAssunto", AV96IsAuthorized_NegAssunto);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_NEGASSUNTO", GetSecureSignedToken( "", AV96IsAuthorized_NegAssunto, context));
         GXt_boolean1 = AV92IsAuthorized_NegPjtNome;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "clientepjtipoview_Execute", out  GXt_boolean1) ;
         AV92IsAuthorized_NegPjtNome = GXt_boolean1;
         AssignAttri("", false, "AV92IsAuthorized_NegPjtNome", AV92IsAuthorized_NegPjtNome);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_NEGPJTNOME", GetSecureSignedToken( "", AV92IsAuthorized_NegPjtNome, context));
         AV83GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV84GAMErrors);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Ddo_grid_Gamoauthtoken = AV83GAMSession.gxTpr_Token;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GAMOAuthToken", Ddo_grid_Gamoauthtoken);
         Form.Caption = "Oportunidades de Negócio";
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
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S172 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = AV82DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2) ;
         AV82DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2;
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = bttBtneditcolumns_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "TitleControlIdToReplace", Ddo_gridcolumnsselector_Titlecontrolidtoreplace);
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E293X2( )
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
         if ( AV40ManageFiltersExecutionStep == 1 )
         {
            AV40ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV40ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV40ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV40ManageFiltersExecutionStep == 2 )
         {
            AV40ManageFiltersExecutionStep = 0;
            AssignAttri("", false, "AV40ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV40ManageFiltersExecutionStep), 1, 0));
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
         if ( StringUtil.StrCmp(AV37Session.Get("core.NegocioPJWWColumnsSelector"), "") != 0 )
         {
            AV33ColumnsSelectorXML = AV37Session.Get("core.NegocioPJWWColumnsSelector");
            AV35ColumnsSelector.FromXml(AV33ColumnsSelectorXML, null, "", "");
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
         edtNegCodigo_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV35ColumnsSelector.gxTpr_Columns.Item(1)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtNegCodigo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtNegCodigo_Visible), 5, 0), !bGXsfl_115_Refreshing);
         edtNegAssunto_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV35ColumnsSelector.gxTpr_Columns.Item(2)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtNegAssunto_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtNegAssunto_Visible), 5, 0), !bGXsfl_115_Refreshing);
         edtNegCliNomeFamiliar_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV35ColumnsSelector.gxTpr_Columns.Item(3)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtNegCliNomeFamiliar_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtNegCliNomeFamiliar_Visible), 5, 0), !bGXsfl_115_Refreshing);
         edtNegCpjNomFan_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV35ColumnsSelector.gxTpr_Columns.Item(4)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtNegCpjNomFan_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtNegCpjNomFan_Visible), 5, 0), !bGXsfl_115_Refreshing);
         edtNegCpjMatricula_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV35ColumnsSelector.gxTpr_Columns.Item(5)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtNegCpjMatricula_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtNegCpjMatricula_Visible), 5, 0), !bGXsfl_115_Refreshing);
         edtNegPjtNome_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV35ColumnsSelector.gxTpr_Columns.Item(6)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtNegPjtNome_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtNegPjtNome_Visible), 5, 0), !bGXsfl_115_Refreshing);
         edtNegAgcNome_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV35ColumnsSelector.gxTpr_Columns.Item(7)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtNegAgcNome_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtNegAgcNome_Visible), 5, 0), !bGXsfl_115_Refreshing);
         edtNegValorAtualizado_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV35ColumnsSelector.gxTpr_Columns.Item(8)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtNegValorAtualizado_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtNegValorAtualizado_Visible), 5, 0), !bGXsfl_115_Refreshing);
         edtNegInsData_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV35ColumnsSelector.gxTpr_Columns.Item(9)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtNegInsData_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtNegInsData_Visible), 5, 0), !bGXsfl_115_Refreshing);
         edtNegInsUsuNome_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV35ColumnsSelector.gxTpr_Columns.Item(10)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtNegInsUsuNome_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtNegInsUsuNome_Visible), 5, 0), !bGXsfl_115_Refreshing);
         AV86GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV86GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV86GridCurrentPage), 10, 0));
         AV87GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV87GridPageCount", StringUtil.LTrimStr( (decimal)(AV87GridPageCount), 10, 0));
         GXt_char3 = AV88GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV106Pgmname, out  GXt_char3) ;
         AV88GridAppliedFilters = GXt_char3;
         AssignAttri("", false, "AV88GridAppliedFilters", AV88GridAppliedFilters);
         AV107Core_negociopjwwds_1_negdel = AV103NegDel;
         AV108Core_negociopjwwds_2_filterfulltext = AV17FilterFullText;
         AV109Core_negociopjwwds_3_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV110Core_negociopjwwds_4_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV111Core_negociopjwwds_5_negassunto1 = AV20NegAssunto1;
         AV112Core_negociopjwwds_6_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV113Core_negociopjwwds_7_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV114Core_negociopjwwds_8_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV115Core_negociopjwwds_9_negassunto2 = AV24NegAssunto2;
         AV116Core_negociopjwwds_10_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV117Core_negociopjwwds_11_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV118Core_negociopjwwds_12_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV119Core_negociopjwwds_13_negassunto3 = AV28NegAssunto3;
         AV120Core_negociopjwwds_14_tfnegcodigo = AV41TFNegCodigo;
         AV121Core_negociopjwwds_15_tfnegcodigo_to = AV42TFNegCodigo_To;
         AV122Core_negociopjwwds_16_tfnegassunto = AV80TFNegAssunto;
         AV123Core_negociopjwwds_17_tfnegassunto_sel = AV81TFNegAssunto_Sel;
         AV124Core_negociopjwwds_18_tfnegclinomefamiliar = AV62TFNegCliNomeFamiliar;
         AV125Core_negociopjwwds_19_tfnegclinomefamiliar_sel = AV63TFNegCliNomeFamiliar_Sel;
         AV126Core_negociopjwwds_20_tfnegcpjnomfan = AV64TFNegCpjNomFan;
         AV127Core_negociopjwwds_21_tfnegcpjnomfan_sel = AV65TFNegCpjNomFan_Sel;
         AV128Core_negociopjwwds_22_tfnegcpjmatricula = AV68TFNegCpjMatricula;
         AV129Core_negociopjwwds_23_tfnegcpjmatricula_to = AV69TFNegCpjMatricula_To;
         AV130Core_negociopjwwds_24_tfnegpjtnome = AV74TFNegPjtNome;
         AV131Core_negociopjwwds_25_tfnegpjtnome_sel = AV75TFNegPjtNome_Sel;
         AV132Core_negociopjwwds_26_tfnegagcnome = AV78TFNegAgcNome;
         AV133Core_negociopjwwds_27_tfnegagcnome_sel = AV79TFNegAgcNome_Sel;
         AV134Core_negociopjwwds_28_tfnegvaloratualizado = AV99TFNegValorAtualizado;
         AV135Core_negociopjwwds_29_tfnegvaloratualizado_to = AV100TFNegValorAtualizado_To;
         AV136Core_negociopjwwds_30_tfneginsdata = AV43TFNegInsData;
         AV137Core_negociopjwwds_31_tfneginsdata_to = AV44TFNegInsData_To;
         AV138Core_negociopjwwds_32_tfneginsusunome = AV97TFNegInsUsuNome;
         AV139Core_negociopjwwds_33_tfneginsusunome_sel = AV98TFNegInsUsuNome_Sel;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ColumnsSelector", AV35ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ManageFiltersData", AV38ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E123X2( )
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
            AV85PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV85PageToGo) ;
         }
      }

      protected void E133X2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E163X2( )
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "NegCodigo") == 0 )
            {
               AV41TFNegCodigo = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV41TFNegCodigo", StringUtil.LTrimStr( (decimal)(AV41TFNegCodigo), 12, 0));
               AV42TFNegCodigo_To = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV42TFNegCodigo_To", StringUtil.LTrimStr( (decimal)(AV42TFNegCodigo_To), 12, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "NegAssunto") == 0 )
            {
               AV80TFNegAssunto = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV80TFNegAssunto", AV80TFNegAssunto);
               AV81TFNegAssunto_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV81TFNegAssunto_Sel", AV81TFNegAssunto_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "NegCliNomeFamiliar") == 0 )
            {
               AV62TFNegCliNomeFamiliar = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV62TFNegCliNomeFamiliar", AV62TFNegCliNomeFamiliar);
               AV63TFNegCliNomeFamiliar_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV63TFNegCliNomeFamiliar_Sel", AV63TFNegCliNomeFamiliar_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "NegCpjNomFan") == 0 )
            {
               AV64TFNegCpjNomFan = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV64TFNegCpjNomFan", AV64TFNegCpjNomFan);
               AV65TFNegCpjNomFan_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV65TFNegCpjNomFan_Sel", AV65TFNegCpjNomFan_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "NegCpjMatricula") == 0 )
            {
               AV68TFNegCpjMatricula = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV68TFNegCpjMatricula", StringUtil.LTrimStr( (decimal)(AV68TFNegCpjMatricula), 12, 0));
               AV69TFNegCpjMatricula_To = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV69TFNegCpjMatricula_To", StringUtil.LTrimStr( (decimal)(AV69TFNegCpjMatricula_To), 12, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "NegPjtNome") == 0 )
            {
               AV74TFNegPjtNome = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV74TFNegPjtNome", AV74TFNegPjtNome);
               AV75TFNegPjtNome_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV75TFNegPjtNome_Sel", AV75TFNegPjtNome_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "NegAgcNome") == 0 )
            {
               AV78TFNegAgcNome = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV78TFNegAgcNome", AV78TFNegAgcNome);
               AV79TFNegAgcNome_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV79TFNegAgcNome_Sel", AV79TFNegAgcNome_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "NegValorAtualizado") == 0 )
            {
               AV99TFNegValorAtualizado = NumberUtil.Val( Ddo_grid_Filteredtext_get, ".");
               AssignAttri("", false, "AV99TFNegValorAtualizado", StringUtil.LTrimStr( AV99TFNegValorAtualizado, 16, 2));
               AV100TFNegValorAtualizado_To = NumberUtil.Val( Ddo_grid_Filteredtextto_get, ".");
               AssignAttri("", false, "AV100TFNegValorAtualizado_To", StringUtil.LTrimStr( AV100TFNegValorAtualizado_To, 16, 2));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "NegInsData") == 0 )
            {
               AV43TFNegInsData = context.localUtil.CToD( Ddo_grid_Filteredtext_get, 2);
               AssignAttri("", false, "AV43TFNegInsData", context.localUtil.Format(AV43TFNegInsData, "99/99/99"));
               AV44TFNegInsData_To = context.localUtil.CToD( Ddo_grid_Filteredtextto_get, 2);
               AssignAttri("", false, "AV44TFNegInsData_To", context.localUtil.Format(AV44TFNegInsData_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "NegInsUsuNome") == 0 )
            {
               AV97TFNegInsUsuNome = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV97TFNegInsUsuNome", AV97TFNegInsUsuNome);
               AV98TFNegInsUsuNome_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV98TFNegInsUsuNome_Sel", AV98TFNegInsUsuNome_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E303X2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         cmbavGridactions.removeAllItems();
         cmbavGridactions.addItem("0", ";fa fa-bars", 0);
         if ( AV90IsAuthorized_Update )
         {
            cmbavGridactions.addItem("1", StringUtil.Format( "%1;%2", "Alterar", "fa fa-pen", "", "", "", "", "", "", ""), 0);
         }
         if ( AV91IsAuthorized_Delete )
         {
            cmbavGridactions.addItem("2", StringUtil.Format( "%1;%2", "Excluir", "fa fa-times", "", "", "", "", "", "", ""), 0);
         }
         if ( cmbavGridactions.ItemCount == 1 )
         {
            cmbavGridactions_Class = "Invisible";
         }
         else
         {
            cmbavGridactions_Class = "ConvertToDDO";
         }
         if ( AV96IsAuthorized_NegAssunto )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "core.negociopjview.aspx"+UrlEncode(A345NegID.ToString()) + "," + UrlEncode(StringUtil.RTrim(""));
            edtNegAssunto_Link = formatLink("core.negociopjview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         }
         if ( AV92IsAuthorized_NegPjtNome )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "core.clientepjtipoview.aspx"+UrlEncode(StringUtil.LTrimStr(A357NegPjtID,9,0)) + "," + UrlEncode(StringUtil.RTrim(""));
            edtNegPjtNome_Link = formatLink("core.clientepjtipoview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         }
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 115;
         }
         sendrow_1152( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_115_Refreshing )
         {
            DoAjaxLoad(115, GridRow);
         }
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV89GridActions), 4, 0));
      }

      protected void E173X2( )
      {
         /* Ddo_gridcolumnsselector_Oncolumnschanged Routine */
         returnInSub = false;
         AV33ColumnsSelectorXML = Ddo_gridcolumnsselector_Columnsselectorvalues;
         AV35ColumnsSelector.FromJSonString(AV33ColumnsSelectorXML, null);
         new GeneXus.Programs.wwpbaseobjects.savecolumnsselectorstate(context ).execute(  "core.NegocioPJWWColumnsSelector",  (String.IsNullOrEmpty(StringUtil.RTrim( AV33ColumnsSelectorXML)) ? "" : AV35ColumnsSelector.ToXml(false, true, "", ""))) ;
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ColumnsSelector", AV35ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ManageFiltersData", AV38ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E233X2( )
      {
         /* 'AddDynamicFilters1' Routine */
         returnInSub = false;
         AV21DynamicFiltersEnabled2 = true;
         AssignAttri("", false, "AV21DynamicFiltersEnabled2", AV21DynamicFiltersEnabled2);
         imgAdddynamicfilters1_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
         imgRemovedynamicfilters1_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
         /*  Sending Event outputs  */
      }

      protected void E193X2( )
      {
         /* 'RemoveDynamicFilters1' Routine */
         returnInSub = false;
         AV29DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV29DynamicFiltersRemoving", AV29DynamicFiltersRemoving);
         AV30DynamicFiltersIgnoreFirst = true;
         AssignAttri("", false, "AV30DynamicFiltersIgnoreFirst", AV30DynamicFiltersIgnoreFirst);
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
         AV29DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV29DynamicFiltersRemoving", AV29DynamicFiltersRemoving);
         AV30DynamicFiltersIgnoreFirst = false;
         AssignAttri("", false, "AV30DynamicFiltersIgnoreFirst", AV30DynamicFiltersIgnoreFirst);
         gxgrGrid_refresh( subGrid_Rows, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20NegAssunto1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24NegAssunto2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28NegAssunto3, AV40ManageFiltersExecutionStep, AV35ColumnsSelector, AV106Pgmname, AV103NegDel, AV21DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV41TFNegCodigo, AV42TFNegCodigo_To, AV80TFNegAssunto, AV81TFNegAssunto_Sel, AV62TFNegCliNomeFamiliar, AV63TFNegCliNomeFamiliar_Sel, AV64TFNegCpjNomFan, AV65TFNegCpjNomFan_Sel, AV68TFNegCpjMatricula, AV69TFNegCpjMatricula_To, AV74TFNegPjtNome, AV75TFNegPjtNome_Sel, AV78TFNegAgcNome, AV79TFNegAgcNome_Sel, AV99TFNegValorAtualizado, AV100TFNegValorAtualizado_To, AV43TFNegInsData, AV44TFNegInsData_To, AV97TFNegInsUsuNome, AV98TFNegInsUsuNome_Sel, AV14OrderedBy, AV15OrderedDsc, AV11GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving, AV90IsAuthorized_Update, AV91IsAuthorized_Delete, AV96IsAuthorized_NegAssunto, AV92IsAuthorized_NegPjtNome, AV95IsAuthorized_Insert) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ColumnsSelector", AV35ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ManageFiltersData", AV38ManageFiltersData);
      }

      protected void E243X2( )
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

      protected void E253X2( )
      {
         /* 'AddDynamicFilters2' Routine */
         returnInSub = false;
         AV25DynamicFiltersEnabled3 = true;
         AssignAttri("", false, "AV25DynamicFiltersEnabled3", AV25DynamicFiltersEnabled3);
         imgAdddynamicfilters2_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         /*  Sending Event outputs  */
      }

      protected void E203X2( )
      {
         /* 'RemoveDynamicFilters2' Routine */
         returnInSub = false;
         AV29DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV29DynamicFiltersRemoving", AV29DynamicFiltersRemoving);
         AV21DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV21DynamicFiltersEnabled2", AV21DynamicFiltersEnabled2);
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
         AV29DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV29DynamicFiltersRemoving", AV29DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20NegAssunto1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24NegAssunto2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28NegAssunto3, AV40ManageFiltersExecutionStep, AV35ColumnsSelector, AV106Pgmname, AV103NegDel, AV21DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV41TFNegCodigo, AV42TFNegCodigo_To, AV80TFNegAssunto, AV81TFNegAssunto_Sel, AV62TFNegCliNomeFamiliar, AV63TFNegCliNomeFamiliar_Sel, AV64TFNegCpjNomFan, AV65TFNegCpjNomFan_Sel, AV68TFNegCpjMatricula, AV69TFNegCpjMatricula_To, AV74TFNegPjtNome, AV75TFNegPjtNome_Sel, AV78TFNegAgcNome, AV79TFNegAgcNome_Sel, AV99TFNegValorAtualizado, AV100TFNegValorAtualizado_To, AV43TFNegInsData, AV44TFNegInsData_To, AV97TFNegInsUsuNome, AV98TFNegInsUsuNome_Sel, AV14OrderedBy, AV15OrderedDsc, AV11GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving, AV90IsAuthorized_Update, AV91IsAuthorized_Delete, AV96IsAuthorized_NegAssunto, AV92IsAuthorized_NegPjtNome, AV95IsAuthorized_Insert) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ColumnsSelector", AV35ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ManageFiltersData", AV38ManageFiltersData);
      }

      protected void E263X2( )
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

      protected void E213X2( )
      {
         /* 'RemoveDynamicFilters3' Routine */
         returnInSub = false;
         AV29DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV29DynamicFiltersRemoving", AV29DynamicFiltersRemoving);
         AV25DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV25DynamicFiltersEnabled3", AV25DynamicFiltersEnabled3);
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
         AV29DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV29DynamicFiltersRemoving", AV29DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20NegAssunto1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24NegAssunto2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28NegAssunto3, AV40ManageFiltersExecutionStep, AV35ColumnsSelector, AV106Pgmname, AV103NegDel, AV21DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV41TFNegCodigo, AV42TFNegCodigo_To, AV80TFNegAssunto, AV81TFNegAssunto_Sel, AV62TFNegCliNomeFamiliar, AV63TFNegCliNomeFamiliar_Sel, AV64TFNegCpjNomFan, AV65TFNegCpjNomFan_Sel, AV68TFNegCpjMatricula, AV69TFNegCpjMatricula_To, AV74TFNegPjtNome, AV75TFNegPjtNome_Sel, AV78TFNegAgcNome, AV79TFNegAgcNome_Sel, AV99TFNegValorAtualizado, AV100TFNegValorAtualizado_To, AV43TFNegInsData, AV44TFNegInsData_To, AV97TFNegInsUsuNome, AV98TFNegInsUsuNome_Sel, AV14OrderedBy, AV15OrderedDsc, AV11GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving, AV90IsAuthorized_Update, AV91IsAuthorized_Delete, AV96IsAuthorized_NegAssunto, AV92IsAuthorized_NegPjtNome, AV95IsAuthorized_Insert) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ColumnsSelector", AV35ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ManageFiltersData", AV38ManageFiltersData);
      }

      protected void E273X2( )
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

      protected void E113X2( )
      {
         /* Ddo_managefilters_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Clean#>") == 0 )
         {
            /* Execute user subroutine: 'CLEANFILTERS' */
            S242 ();
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
            GXEncryptionTmp = "wwpbaseobjects.savefilteras.aspx"+UrlEncode(StringUtil.RTrim("core.NegocioPJWWFilters")) + "," + UrlEncode(StringUtil.RTrim(AV106Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV40ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV40ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV40ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wwpbaseobjects.managefilters.aspx"+UrlEncode(StringUtil.RTrim("core.NegocioPJWWFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV40ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV40ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV40ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char3 = AV39ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "core.NegocioPJWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char3) ;
            AV39ManageFiltersXml = GXt_char3;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV39ManageFiltersXml)) )
            {
               GX_msglist.addItem("O filtro selecionado não existe mais.");
            }
            else
            {
               /* Execute user subroutine: 'CLEANFILTERS' */
               S242 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV106Pgmname+"GridState",  AV39ManageFiltersXml) ;
               AV11GridState.FromXml(AV39ManageFiltersXml, null, "", "");
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
               S252 ();
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
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ColumnsSelector", AV35ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ManageFiltersData", AV38ManageFiltersData);
      }

      protected void E313X2( )
      {
         /* Gridactions_Click Routine */
         returnInSub = false;
         if ( AV89GridActions == 1 )
         {
            /* Execute user subroutine: 'DO UPDATE' */
            S262 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV89GridActions == 2 )
         {
            /* Execute user subroutine: 'DO DELETE' */
            S272 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         AV89GridActions = 0;
         AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV89GridActions), 4, 0));
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV89GridActions), 4, 0));
         AssignProp("", false, cmbavGridactions_Internalname, "Values", cmbavGridactions.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ColumnsSelector", AV35ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ManageFiltersData", AV38ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E183X2( )
      {
         /* Dvelop_confirmpanel_delete_Close Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Dvelop_confirmpanel_delete_Result, "Yes") == 0 )
         {
            /* Execute user subroutine: 'DO ACTION DELETE' */
            S282 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ColumnsSelector", AV35ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ManageFiltersData", AV38ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E223X2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         if ( AV95IsAuthorized_Insert )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "core.negociopj.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(Guid.Empty.ToString());
            CallWebObject(formatLink("core.negociopj.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem("A ação não encontra-se disponível");
            context.DoAjaxRefresh();
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ColumnsSelector", AV35ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ManageFiltersData", AV38ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E143X2( )
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
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
      }

      protected void E153X2( )
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
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"W0156",(string)"",(string)"NegocioPJ",(short)1,(string)"",(string)""});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0156"+"");
            WebComp_Wwpaux_wc.componentdraw();
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
         AV35ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV35ColumnsSelector,  "NegCodigo",  "",  "Negociação",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV35ColumnsSelector,  "NegAssunto",  "",  "Assunto",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV35ColumnsSelector,  "NegCliNomeFamiliar",  "",  "Cliente",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV35ColumnsSelector,  "NegCpjNomFan",  "",  "Unidade",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV35ColumnsSelector,  "NegCpjMatricula",  "",  "Matrícula",  false,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV35ColumnsSelector,  "NegPjtNome",  "",  "Tipo",  false,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV35ColumnsSelector,  "NegAgcNome",  "",  "Agente Comercial",  false,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV35ColumnsSelector,  "NegValorAtualizado",  "",  "Total em Negócios",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV35ColumnsSelector,  "NegInsData",  "",  "Incluído em",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV35ColumnsSelector,  "NegInsUsuNome",  "",  "Incluído por",  false,  "") ;
         GXt_char3 = AV34UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "core.NegocioPJWWColumnsSelector", out  GXt_char3) ;
         AV34UserCustomValue = GXt_char3;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV34UserCustomValue)) ) )
         {
            AV36ColumnsSelectorAux.FromXml(AV34UserCustomValue, null, "", "");
            new GeneXus.Programs.wwpbaseobjects.wwp_columnselector_updatecolumns(context ).execute( ref  AV36ColumnsSelectorAux, ref  AV35ColumnsSelector) ;
         }
      }

      protected void S182( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         GXt_boolean1 = AV90IsAuthorized_Update;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "negocio_Update", out  GXt_boolean1) ;
         AV90IsAuthorized_Update = GXt_boolean1;
         AssignAttri("", false, "AV90IsAuthorized_Update", AV90IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV90IsAuthorized_Update, context));
         GXt_boolean1 = AV91IsAuthorized_Delete;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "negocio_Delete", out  GXt_boolean1) ;
         AV91IsAuthorized_Delete = GXt_boolean1;
         AssignAttri("", false, "AV91IsAuthorized_Delete", AV91IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV91IsAuthorized_Delete, context));
         GXt_boolean1 = AV95IsAuthorized_Insert;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "negocio_Insert", out  GXt_boolean1) ;
         AV95IsAuthorized_Insert = GXt_boolean1;
         AssignAttri("", false, "AV95IsAuthorized_Insert", AV95IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV95IsAuthorized_Insert, context));
         if ( ! ( AV95IsAuthorized_Insert ) )
         {
            bttBtninsert_Visible = 0;
            AssignProp("", false, bttBtninsert_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtninsert_Visible), 5, 0), true);
         }
         if ( ! ( new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_hassubscriptionstodisplay(context).executeUdp(  "NegocioPJ",  1) ) )
         {
            bttBtnsubscriptions_Visible = 0;
            AssignProp("", false, bttBtnsubscriptions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnsubscriptions_Visible), 5, 0), true);
         }
      }

      protected void S122( )
      {
         /* 'ENABLEDYNAMICFILTERS1' Routine */
         returnInSub = false;
         edtavNegassunto1_Visible = 0;
         AssignProp("", false, edtavNegassunto1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavNegassunto1_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator1.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "NEGASSUNTO") == 0 )
         {
            edtavNegassunto1_Visible = 1;
            AssignProp("", false, edtavNegassunto1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavNegassunto1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
      }

      protected void S132( )
      {
         /* 'ENABLEDYNAMICFILTERS2' Routine */
         returnInSub = false;
         edtavNegassunto2_Visible = 0;
         AssignProp("", false, edtavNegassunto2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavNegassunto2_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator2.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "NEGASSUNTO") == 0 )
         {
            edtavNegassunto2_Visible = 1;
            AssignProp("", false, edtavNegassunto2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavNegassunto2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
      }

      protected void S142( )
      {
         /* 'ENABLEDYNAMICFILTERS3' Routine */
         returnInSub = false;
         edtavNegassunto3_Visible = 0;
         AssignProp("", false, edtavNegassunto3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavNegassunto3_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator3.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "NEGASSUNTO") == 0 )
         {
            edtavNegassunto3_Visible = 1;
            AssignProp("", false, edtavNegassunto3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavNegassunto3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
      }

      protected void S222( )
      {
         /* 'RESETDYNFILTERS' Routine */
         returnInSub = false;
         AV21DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV21DynamicFiltersEnabled2", AV21DynamicFiltersEnabled2);
         AV22DynamicFiltersSelector2 = "NEGASSUNTO";
         AssignAttri("", false, "AV22DynamicFiltersSelector2", AV22DynamicFiltersSelector2);
         AV23DynamicFiltersOperator2 = 0;
         AssignAttri("", false, "AV23DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         AV24NegAssunto2 = "";
         AssignAttri("", false, "AV24NegAssunto2", AV24NegAssunto2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV25DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV25DynamicFiltersEnabled3", AV25DynamicFiltersEnabled3);
         AV26DynamicFiltersSelector3 = "NEGASSUNTO";
         AssignAttri("", false, "AV26DynamicFiltersSelector3", AV26DynamicFiltersSelector3);
         AV27DynamicFiltersOperator3 = 0;
         AssignAttri("", false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AV28NegAssunto3 = "";
         AssignAttri("", false, "AV28NegAssunto3", AV28NegAssunto3);
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
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = AV38ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "core.NegocioPJWWFilters",  "WWPDynFilterHideAll_AL('%1', 3, 0)",  divTabledynamicfilters_Internalname,  true, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4) ;
         AV38ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4;
      }

      protected void S242( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV103NegDel = false;
         AssignAttri("", false, "AV103NegDel", AV103NegDel);
         AV17FilterFullText = "";
         AssignAttri("", false, "AV17FilterFullText", AV17FilterFullText);
         AV41TFNegCodigo = 0;
         AssignAttri("", false, "AV41TFNegCodigo", StringUtil.LTrimStr( (decimal)(AV41TFNegCodigo), 12, 0));
         AV42TFNegCodigo_To = 0;
         AssignAttri("", false, "AV42TFNegCodigo_To", StringUtil.LTrimStr( (decimal)(AV42TFNegCodigo_To), 12, 0));
         AV80TFNegAssunto = "";
         AssignAttri("", false, "AV80TFNegAssunto", AV80TFNegAssunto);
         AV81TFNegAssunto_Sel = "";
         AssignAttri("", false, "AV81TFNegAssunto_Sel", AV81TFNegAssunto_Sel);
         AV62TFNegCliNomeFamiliar = "";
         AssignAttri("", false, "AV62TFNegCliNomeFamiliar", AV62TFNegCliNomeFamiliar);
         AV63TFNegCliNomeFamiliar_Sel = "";
         AssignAttri("", false, "AV63TFNegCliNomeFamiliar_Sel", AV63TFNegCliNomeFamiliar_Sel);
         AV64TFNegCpjNomFan = "";
         AssignAttri("", false, "AV64TFNegCpjNomFan", AV64TFNegCpjNomFan);
         AV65TFNegCpjNomFan_Sel = "";
         AssignAttri("", false, "AV65TFNegCpjNomFan_Sel", AV65TFNegCpjNomFan_Sel);
         AV68TFNegCpjMatricula = 0;
         AssignAttri("", false, "AV68TFNegCpjMatricula", StringUtil.LTrimStr( (decimal)(AV68TFNegCpjMatricula), 12, 0));
         AV69TFNegCpjMatricula_To = 0;
         AssignAttri("", false, "AV69TFNegCpjMatricula_To", StringUtil.LTrimStr( (decimal)(AV69TFNegCpjMatricula_To), 12, 0));
         AV74TFNegPjtNome = "";
         AssignAttri("", false, "AV74TFNegPjtNome", AV74TFNegPjtNome);
         AV75TFNegPjtNome_Sel = "";
         AssignAttri("", false, "AV75TFNegPjtNome_Sel", AV75TFNegPjtNome_Sel);
         AV78TFNegAgcNome = "";
         AssignAttri("", false, "AV78TFNegAgcNome", AV78TFNegAgcNome);
         AV79TFNegAgcNome_Sel = "";
         AssignAttri("", false, "AV79TFNegAgcNome_Sel", AV79TFNegAgcNome_Sel);
         AV99TFNegValorAtualizado = 0;
         AssignAttri("", false, "AV99TFNegValorAtualizado", StringUtil.LTrimStr( AV99TFNegValorAtualizado, 16, 2));
         AV100TFNegValorAtualizado_To = 0;
         AssignAttri("", false, "AV100TFNegValorAtualizado_To", StringUtil.LTrimStr( AV100TFNegValorAtualizado_To, 16, 2));
         AV43TFNegInsData = DateTime.MinValue;
         AssignAttri("", false, "AV43TFNegInsData", context.localUtil.Format(AV43TFNegInsData, "99/99/99"));
         AV44TFNegInsData_To = DateTime.MinValue;
         AssignAttri("", false, "AV44TFNegInsData_To", context.localUtil.Format(AV44TFNegInsData_To, "99/99/99"));
         AV97TFNegInsUsuNome = "";
         AssignAttri("", false, "AV97TFNegInsUsuNome", AV97TFNegInsUsuNome);
         AV98TFNegInsUsuNome_Sel = "";
         AssignAttri("", false, "AV98TFNegInsUsuNome_Sel", AV98TFNegInsUsuNome_Sel);
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
         AV18DynamicFiltersSelector1 = "NEGASSUNTO";
         AssignAttri("", false, "AV18DynamicFiltersSelector1", AV18DynamicFiltersSelector1);
         AV19DynamicFiltersOperator1 = 0;
         AssignAttri("", false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AV20NegAssunto1 = "";
         AssignAttri("", false, "AV20NegAssunto1", AV20NegAssunto1);
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

      protected void S262( )
      {
         /* 'DO UPDATE' Routine */
         returnInSub = false;
         if ( AV90IsAuthorized_Update )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "core.negociopj.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(A345NegID.ToString());
            CallWebObject(formatLink("core.negociopj.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem("A ação não encontra-se disponível");
            context.DoAjaxRefresh();
         }
      }

      protected void S272( )
      {
         /* 'DO DELETE' Routine */
         returnInSub = false;
         if ( AV91IsAuthorized_Delete )
         {
            AV104NegID_Selected = A345NegID;
            AssignAttri("", false, "AV104NegID_Selected", AV104NegID_Selected.ToString());
            this.executeUsercontrolMethod("", false, "DVELOP_CONFIRMPANEL_DELETEContainer", "Confirm", "", new Object[] {});
         }
         else
         {
            GX_msglist.addItem("A ação não encontra-se disponível");
            context.DoAjaxRefresh();
         }
      }

      protected void S282( )
      {
         /* 'DO ACTION DELETE' Routine */
         returnInSub = false;
         if ( 1 == 2 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "core.negociopj.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(AV104NegID_Selected.ToString());
            CallWebObject(formatLink("core.negociopj.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         AV105sdtNegocioPJ = new GeneXus.Programs.core.SdtsdtNegocioPJ(context);
         AV105sdtNegocioPJ.gxTpr_Negid = AV104NegID_Selected;
         new GeneXus.Programs.core.prcnegociopjobterdadosindividual(context ).execute( ref  AV105sdtNegocioPJ) ;
         AV105sdtNegocioPJ.gxTpr_Negdel = true;
         new GeneXus.Programs.core.prcnegociopjmanterdados(context ).execute(  AV105sdtNegocioPJ,  true, out  AV102Messages) ;
         AV140GXV1 = 1;
         while ( AV140GXV1 <= AV102Messages.Count )
         {
            AV101Message = ((GeneXus.Utils.SdtMessages_Message)AV102Messages.Item(AV140GXV1));
            GX_msglist.addItem(AV101Message.gxTpr_Description);
            AV140GXV1 = (int)(AV140GXV1+1);
         }
         gxgrGrid_refresh( subGrid_Rows, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20NegAssunto1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24NegAssunto2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28NegAssunto3, AV40ManageFiltersExecutionStep, AV35ColumnsSelector, AV106Pgmname, AV103NegDel, AV21DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV41TFNegCodigo, AV42TFNegCodigo_To, AV80TFNegAssunto, AV81TFNegAssunto_Sel, AV62TFNegCliNomeFamiliar, AV63TFNegCliNomeFamiliar_Sel, AV64TFNegCpjNomFan, AV65TFNegCpjNomFan_Sel, AV68TFNegCpjMatricula, AV69TFNegCpjMatricula_To, AV74TFNegPjtNome, AV75TFNegPjtNome_Sel, AV78TFNegAgcNome, AV79TFNegAgcNome_Sel, AV99TFNegValorAtualizado, AV100TFNegValorAtualizado_To, AV43TFNegInsData, AV44TFNegInsData_To, AV97TFNegInsUsuNome, AV98TFNegInsUsuNome_Sel, AV14OrderedBy, AV15OrderedDsc, AV11GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving, AV90IsAuthorized_Update, AV91IsAuthorized_Delete, AV96IsAuthorized_NegAssunto, AV92IsAuthorized_NegPjtNome, AV95IsAuthorized_Insert) ;
      }

      protected void S162( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV37Session.Get(AV106Pgmname+"GridState"), "") == 0 )
         {
            AV11GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV106Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV11GridState.FromXml(AV37Session.Get(AV106Pgmname+"GridState"), null, "", "");
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
         S252 ();
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

      protected void S252( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV141GXV2 = 1;
         while ( AV141GXV2 <= AV11GridState.gxTpr_Filtervalues.Count )
         {
            AV12GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV11GridState.gxTpr_Filtervalues.Item(AV141GXV2));
            if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "NEGDEL") == 0 )
            {
               AV103NegDel = BooleanUtil.Val( AV12GridStateFilterValue.gxTpr_Value);
               AssignAttri("", false, "AV103NegDel", AV103NegDel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV17FilterFullText = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV17FilterFullText", AV17FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFNEGCODIGO") == 0 )
            {
               AV41TFNegCodigo = (long)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV41TFNegCodigo", StringUtil.LTrimStr( (decimal)(AV41TFNegCodigo), 12, 0));
               AV42TFNegCodigo_To = (long)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV42TFNegCodigo_To", StringUtil.LTrimStr( (decimal)(AV42TFNegCodigo_To), 12, 0));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFNEGASSUNTO") == 0 )
            {
               AV80TFNegAssunto = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV80TFNegAssunto", AV80TFNegAssunto);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFNEGASSUNTO_SEL") == 0 )
            {
               AV81TFNegAssunto_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV81TFNegAssunto_Sel", AV81TFNegAssunto_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFNEGCLINOMEFAMILIAR") == 0 )
            {
               AV62TFNegCliNomeFamiliar = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV62TFNegCliNomeFamiliar", AV62TFNegCliNomeFamiliar);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFNEGCLINOMEFAMILIAR_SEL") == 0 )
            {
               AV63TFNegCliNomeFamiliar_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV63TFNegCliNomeFamiliar_Sel", AV63TFNegCliNomeFamiliar_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFNEGCPJNOMFAN") == 0 )
            {
               AV64TFNegCpjNomFan = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV64TFNegCpjNomFan", AV64TFNegCpjNomFan);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFNEGCPJNOMFAN_SEL") == 0 )
            {
               AV65TFNegCpjNomFan_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV65TFNegCpjNomFan_Sel", AV65TFNegCpjNomFan_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFNEGCPJMATRICULA") == 0 )
            {
               AV68TFNegCpjMatricula = (long)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV68TFNegCpjMatricula", StringUtil.LTrimStr( (decimal)(AV68TFNegCpjMatricula), 12, 0));
               AV69TFNegCpjMatricula_To = (long)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV69TFNegCpjMatricula_To", StringUtil.LTrimStr( (decimal)(AV69TFNegCpjMatricula_To), 12, 0));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFNEGPJTNOME") == 0 )
            {
               AV74TFNegPjtNome = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV74TFNegPjtNome", AV74TFNegPjtNome);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFNEGPJTNOME_SEL") == 0 )
            {
               AV75TFNegPjtNome_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV75TFNegPjtNome_Sel", AV75TFNegPjtNome_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFNEGAGCNOME") == 0 )
            {
               AV78TFNegAgcNome = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV78TFNegAgcNome", AV78TFNegAgcNome);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFNEGAGCNOME_SEL") == 0 )
            {
               AV79TFNegAgcNome_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV79TFNegAgcNome_Sel", AV79TFNegAgcNome_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFNEGVALORATUALIZADO") == 0 )
            {
               AV99TFNegValorAtualizado = NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, ".");
               AssignAttri("", false, "AV99TFNegValorAtualizado", StringUtil.LTrimStr( AV99TFNegValorAtualizado, 16, 2));
               AV100TFNegValorAtualizado_To = NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, ".");
               AssignAttri("", false, "AV100TFNegValorAtualizado_To", StringUtil.LTrimStr( AV100TFNegValorAtualizado_To, 16, 2));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFNEGINSDATA") == 0 )
            {
               AV43TFNegInsData = context.localUtil.CToD( AV12GridStateFilterValue.gxTpr_Value, 2);
               AssignAttri("", false, "AV43TFNegInsData", context.localUtil.Format(AV43TFNegInsData, "99/99/99"));
               AV44TFNegInsData_To = context.localUtil.CToD( AV12GridStateFilterValue.gxTpr_Valueto, 2);
               AssignAttri("", false, "AV44TFNegInsData_To", context.localUtil.Format(AV44TFNegInsData_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFNEGINSUSUNOME") == 0 )
            {
               AV97TFNegInsUsuNome = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV97TFNegInsUsuNome", AV97TFNegInsUsuNome);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFNEGINSUSUNOME_SEL") == 0 )
            {
               AV98TFNegInsUsuNome_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV98TFNegInsUsuNome_Sel", AV98TFNegInsUsuNome_Sel);
            }
            AV141GXV2 = (int)(AV141GXV2+1);
         }
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV81TFNegAssunto_Sel)),  AV81TFNegAssunto_Sel, out  GXt_char3) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV63TFNegCliNomeFamiliar_Sel)),  AV63TFNegCliNomeFamiliar_Sel, out  GXt_char5) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV65TFNegCpjNomFan_Sel)),  AV65TFNegCpjNomFan_Sel, out  GXt_char6) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV75TFNegPjtNome_Sel)),  AV75TFNegPjtNome_Sel, out  GXt_char7) ;
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV79TFNegAgcNome_Sel)),  AV79TFNegAgcNome_Sel, out  GXt_char8) ;
         GXt_char9 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV98TFNegInsUsuNome_Sel)),  AV98TFNegInsUsuNome_Sel, out  GXt_char9) ;
         Ddo_grid_Selectedvalue_set = "|"+GXt_char3+"|"+GXt_char5+"|"+GXt_char6+"||"+GXt_char7+"|"+GXt_char8+"|||"+GXt_char9;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char9 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV80TFNegAssunto)),  AV80TFNegAssunto, out  GXt_char9) ;
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV62TFNegCliNomeFamiliar)),  AV62TFNegCliNomeFamiliar, out  GXt_char8) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV64TFNegCpjNomFan)),  AV64TFNegCpjNomFan, out  GXt_char7) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV74TFNegPjtNome)),  AV74TFNegPjtNome, out  GXt_char6) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV78TFNegAgcNome)),  AV78TFNegAgcNome, out  GXt_char5) ;
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV97TFNegInsUsuNome)),  AV97TFNegInsUsuNome, out  GXt_char3) ;
         Ddo_grid_Filteredtext_set = ((0==AV41TFNegCodigo) ? "" : StringUtil.Str( (decimal)(AV41TFNegCodigo), 12, 0))+"|"+GXt_char9+"|"+GXt_char8+"|"+GXt_char7+"|"+((0==AV68TFNegCpjMatricula) ? "" : StringUtil.Str( (decimal)(AV68TFNegCpjMatricula), 12, 0))+"|"+GXt_char6+"|"+GXt_char5+"|"+((Convert.ToDecimal(0)==AV99TFNegValorAtualizado) ? "" : StringUtil.Str( AV99TFNegValorAtualizado, 16, 2))+"|"+((DateTime.MinValue==AV43TFNegInsData) ? "" : context.localUtil.DToC( AV43TFNegInsData, 2, "/"))+"|"+GXt_char3;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = ((0==AV42TFNegCodigo_To) ? "" : StringUtil.Str( (decimal)(AV42TFNegCodigo_To), 12, 0))+"||||"+((0==AV69TFNegCpjMatricula_To) ? "" : StringUtil.Str( (decimal)(AV69TFNegCpjMatricula_To), 12, 0))+"|||"+((Convert.ToDecimal(0)==AV100TFNegValorAtualizado_To) ? "" : StringUtil.Str( AV100TFNegValorAtualizado_To, 16, 2))+"|"+((DateTime.MinValue==AV44TFNegInsData_To) ? "" : context.localUtil.DToC( AV44TFNegInsData_To, 2, "/"))+"|";
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
            if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "NEGASSUNTO") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV13GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
               AV20NegAssunto1 = AV13GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV20NegAssunto1", AV20NegAssunto1);
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
               AV21DynamicFiltersEnabled2 = true;
               AssignAttri("", false, "AV21DynamicFiltersEnabled2", AV21DynamicFiltersEnabled2);
               AV13GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV11GridState.gxTpr_Dynamicfilters.Item(2));
               AV22DynamicFiltersSelector2 = AV13GridStateDynamicFilter.gxTpr_Selected;
               AssignAttri("", false, "AV22DynamicFiltersSelector2", AV22DynamicFiltersSelector2);
               if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "NEGASSUNTO") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV13GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV23DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
                  AV24NegAssunto2 = AV13GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV24NegAssunto2", AV24NegAssunto2);
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
                  AV25DynamicFiltersEnabled3 = true;
                  AssignAttri("", false, "AV25DynamicFiltersEnabled3", AV25DynamicFiltersEnabled3);
                  AV13GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV11GridState.gxTpr_Dynamicfilters.Item(3));
                  AV26DynamicFiltersSelector3 = AV13GridStateDynamicFilter.gxTpr_Selected;
                  AssignAttri("", false, "AV26DynamicFiltersSelector3", AV26DynamicFiltersSelector3);
                  if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "NEGASSUNTO") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV13GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
                     AV28NegAssunto3 = AV13GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV28NegAssunto3", AV28NegAssunto3);
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
         if ( AV29DynamicFiltersRemoving )
         {
            lblJsdynamicfilters_Caption = "";
            AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         }
      }

      protected void S192( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV11GridState.FromXml(AV37Session.Get(AV106Pgmname+"GridState"), null, "", "");
         AV11GridState.gxTpr_Orderedby = AV14OrderedBy;
         AV11GridState.gxTpr_Ordereddsc = AV15OrderedDsc;
         AV11GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "NEGDEL",  "Excluído",  !(false==AV103NegDel),  0,  StringUtil.Trim( StringUtil.BoolToStr( AV103NegDel)),  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "FILTERFULLTEXT",  "Filtro principal",  !String.IsNullOrEmpty(StringUtil.RTrim( AV17FilterFullText)),  0,  AV17FilterFullText,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFNEGCODIGO",  "Negociação",  !((0==AV41TFNegCodigo)&&(0==AV42TFNegCodigo_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV41TFNegCodigo), 12, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV42TFNegCodigo_To), 12, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFNEGASSUNTO",  "Assunto",  !String.IsNullOrEmpty(StringUtil.RTrim( AV80TFNegAssunto)),  0,  AV80TFNegAssunto,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV81TFNegAssunto_Sel)),  AV81TFNegAssunto_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFNEGCLINOMEFAMILIAR",  "Cliente",  !String.IsNullOrEmpty(StringUtil.RTrim( AV62TFNegCliNomeFamiliar)),  0,  AV62TFNegCliNomeFamiliar,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV63TFNegCliNomeFamiliar_Sel)),  AV63TFNegCliNomeFamiliar_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFNEGCPJNOMFAN",  "Unidade",  !String.IsNullOrEmpty(StringUtil.RTrim( AV64TFNegCpjNomFan)),  0,  AV64TFNegCpjNomFan,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV65TFNegCpjNomFan_Sel)),  AV65TFNegCpjNomFan_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFNEGCPJMATRICULA",  "Matrícula",  !((0==AV68TFNegCpjMatricula)&&(0==AV69TFNegCpjMatricula_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV68TFNegCpjMatricula), 12, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV69TFNegCpjMatricula_To), 12, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFNEGPJTNOME",  "Tipo",  !String.IsNullOrEmpty(StringUtil.RTrim( AV74TFNegPjtNome)),  0,  AV74TFNegPjtNome,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV75TFNegPjtNome_Sel)),  AV75TFNegPjtNome_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFNEGAGCNOME",  "Agente Comercial",  !String.IsNullOrEmpty(StringUtil.RTrim( AV78TFNegAgcNome)),  0,  AV78TFNegAgcNome,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV79TFNegAgcNome_Sel)),  AV79TFNegAgcNome_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFNEGVALORATUALIZADO",  "Total em Negócios",  !((Convert.ToDecimal(0)==AV99TFNegValorAtualizado)&&(Convert.ToDecimal(0)==AV100TFNegValorAtualizado_To)),  0,  StringUtil.Trim( StringUtil.Str( AV99TFNegValorAtualizado, 16, 2)),  StringUtil.Trim( StringUtil.Str( AV100TFNegValorAtualizado_To, 16, 2))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFNEGINSDATA",  "Incluído em",  !((DateTime.MinValue==AV43TFNegInsData)&&(DateTime.MinValue==AV44TFNegInsData_To)),  0,  StringUtil.Trim( context.localUtil.DToC( AV43TFNegInsData, 2, "/")),  StringUtil.Trim( context.localUtil.DToC( AV44TFNegInsData_To, 2, "/"))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFNEGINSUSUNOME",  "Incluído por",  !String.IsNullOrEmpty(StringUtil.RTrim( AV97TFNegInsUsuNome)),  0,  AV97TFNegInsUsuNome,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV98TFNegInsUsuNome_Sel)),  AV98TFNegInsUsuNome_Sel,  "") ;
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S212 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV11GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV11GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV106Pgmname+"GridState",  AV11GridState.ToXml(false, true, "", "")) ;
      }

      protected void S212( )
      {
         /* 'SAVEDYNFILTERSSTATE' Routine */
         returnInSub = false;
         AV11GridState.gxTpr_Dynamicfilters.Clear();
         if ( ! AV30DynamicFiltersIgnoreFirst )
         {
            AV13GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV13GridStateDynamicFilter.gxTpr_Selected = AV18DynamicFiltersSelector1;
            if ( ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "NEGASSUNTO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV20NegAssunto1)) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = "Assunto";
               AV13GridStateDynamicFilter.gxTpr_Value = AV20NegAssunto1;
               AV13GridStateDynamicFilter.gxTpr_Operator = AV19DynamicFiltersOperator1;
            }
            if ( AV29DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV13GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV11GridState.gxTpr_Dynamicfilters.Add(AV13GridStateDynamicFilter, 0);
            }
         }
         if ( AV21DynamicFiltersEnabled2 )
         {
            AV13GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV13GridStateDynamicFilter.gxTpr_Selected = AV22DynamicFiltersSelector2;
            if ( ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "NEGASSUNTO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV24NegAssunto2)) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = "Assunto";
               AV13GridStateDynamicFilter.gxTpr_Value = AV24NegAssunto2;
               AV13GridStateDynamicFilter.gxTpr_Operator = AV23DynamicFiltersOperator2;
            }
            if ( AV29DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV13GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV11GridState.gxTpr_Dynamicfilters.Add(AV13GridStateDynamicFilter, 0);
            }
         }
         if ( AV25DynamicFiltersEnabled3 )
         {
            AV13GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV13GridStateDynamicFilter.gxTpr_Selected = AV26DynamicFiltersSelector3;
            if ( ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "NEGASSUNTO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV28NegAssunto3)) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = "Assunto";
               AV13GridStateDynamicFilter.gxTpr_Value = AV28NegAssunto3;
               AV13GridStateDynamicFilter.gxTpr_Operator = AV27DynamicFiltersOperator3;
            }
            if ( AV29DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV13GridStateDynamicFilter.gxTpr_Value)) )
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
         AV9TrnContext.gxTpr_Callerobject = AV106Pgmname;
         AV9TrnContext.gxTpr_Callerondelete = true;
         AV9TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString;
         AV9TrnContext.gxTpr_Transactionname = "core.NegocioPJ";
         AV37Session.Set("TrnContext", AV9TrnContext.ToXml(false, true, "", ""));
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
         new GeneXus.Programs.core.negociopjwwexport(context ).execute( out  AV31ExcelFilename, out  AV32ErrorMessage) ;
         if ( StringUtil.StrCmp(AV31ExcelFilename, "") != 0 )
         {
            CallWebObject(formatLink(AV31ExcelFilename) );
            context.wjLocDisableFrm = 0;
         }
         else
         {
            GX_msglist.addItem(AV32ErrorMessage);
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
         Innewwindow1_Target = formatLink("core.negociopjwwexportreport.aspx") ;
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Target", Innewwindow1_Target);
         Innewwindow1_Height = "600";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Height", Innewwindow1_Height);
         Innewwindow1_Width = "800";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Width", Innewwindow1_Width);
         this.executeUsercontrolMethod("", false, "INNEWWINDOW1Container", "OpenWindow", "", new Object[] {});
      }

      protected void wb_table5_149_3X2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTabledvelop_confirmpanel_delete_Internalname, tblTabledvelop_confirmpanel_delete_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucDvelop_confirmpanel_delete.SetProperty("Title", Dvelop_confirmpanel_delete_Title);
            ucDvelop_confirmpanel_delete.SetProperty("ConfirmationText", Dvelop_confirmpanel_delete_Confirmationtext);
            ucDvelop_confirmpanel_delete.SetProperty("YesButtonCaption", Dvelop_confirmpanel_delete_Yesbuttoncaption);
            ucDvelop_confirmpanel_delete.SetProperty("NoButtonCaption", Dvelop_confirmpanel_delete_Nobuttoncaption);
            ucDvelop_confirmpanel_delete.SetProperty("CancelButtonCaption", Dvelop_confirmpanel_delete_Cancelbuttoncaption);
            ucDvelop_confirmpanel_delete.SetProperty("YesButtonPosition", Dvelop_confirmpanel_delete_Yesbuttonposition);
            ucDvelop_confirmpanel_delete.SetProperty("ConfirmType", Dvelop_confirmpanel_delete_Confirmtype);
            ucDvelop_confirmpanel_delete.Render(context, "dvelop.gxbootstrap.confirmpanel", Dvelop_confirmpanel_delete_Internalname, "DVELOP_CONFIRMPANEL_DELETEContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVELOP_CONFIRMPANEL_DELETEContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table5_149_3X2e( true) ;
         }
         else
         {
            wb_table5_149_3X2e( false) ;
         }
      }

      protected void wb_table4_97_3X2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 101,'',false,'" + sGXsfl_115_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator3, cmbavDynamicfiltersoperator3_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0)), 1, cmbavDynamicfiltersoperator3_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator3.Visible, cmbavDynamicfiltersoperator3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,101);\"", "", true, 0, "HLP_core\\NegocioPJWW.htm");
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", (string)(cmbavDynamicfiltersoperator3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_negassunto3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavNegassunto3_Internalname, "Neg Assunto3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'" + sGXsfl_115_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavNegassunto3_Internalname, AV28NegAssunto3, StringUtil.RTrim( context.localUtil.Format( AV28NegAssunto3, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,104);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavNegassunto3_Jsonclick, 0, "Attribute", "", "", "", "", edtavNegassunto3_Visible, edtavNegassunto3_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\NegocioPJWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter3_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 106,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters3_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters3_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters3_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS3\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_core\\NegocioPJWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_97_3X2e( true) ;
         }
         else
         {
            wb_table4_97_3X2e( false) ;
         }
      }

      protected void wb_table3_75_3X2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'" + sGXsfl_115_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator2, cmbavDynamicfiltersoperator2_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0)), 1, cmbavDynamicfiltersoperator2_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator2.Visible, cmbavDynamicfiltersoperator2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,79);\"", "", true, 0, "HLP_core\\NegocioPJWW.htm");
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", (string)(cmbavDynamicfiltersoperator2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_negassunto2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavNegassunto2_Internalname, "Neg Assunto2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'" + sGXsfl_115_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavNegassunto2_Internalname, AV24NegAssunto2, StringUtil.RTrim( context.localUtil.Format( AV24NegAssunto2, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,82);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavNegassunto2_Jsonclick, 0, "Attribute", "", "", "", "", edtavNegassunto2_Visible, edtavNegassunto2_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\NegocioPJWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters2_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters2_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_core\\NegocioPJWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters2_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters2_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_core\\NegocioPJWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_75_3X2e( true) ;
         }
         else
         {
            wb_table3_75_3X2e( false) ;
         }
      }

      protected void wb_table2_53_3X2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'" + sGXsfl_115_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator1, cmbavDynamicfiltersoperator1_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0)), 1, cmbavDynamicfiltersoperator1_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator1.Visible, cmbavDynamicfiltersoperator1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,57);\"", "", true, 0, "HLP_core\\NegocioPJWW.htm");
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", (string)(cmbavDynamicfiltersoperator1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_negassunto1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavNegassunto1_Internalname, "Neg Assunto1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'" + sGXsfl_115_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavNegassunto1_Internalname, AV20NegAssunto1, StringUtil.RTrim( context.localUtil.Format( AV20NegAssunto1, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,60);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavNegassunto1_Jsonclick, 0, "Attribute", "", "", "", "", edtavNegassunto1_Visible, edtavNegassunto1_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\NegocioPJWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters1_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters1_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_core\\NegocioPJWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters1_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters1_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_core\\NegocioPJWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_53_3X2e( true) ;
         }
         else
         {
            wb_table2_53_3X2e( false) ;
         }
      }

      protected void wb_table1_29_3X2( bool wbgen )
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
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV38ManageFiltersData);
            ucDdo_managefilters.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_managefilters_Internalname, "DDO_MANAGEFILTERSContainer");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            wb_table6_34_3X2( true) ;
         }
         else
         {
            wb_table6_34_3X2( false) ;
         }
         return  ;
      }

      protected void wb_table6_34_3X2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_29_3X2e( true) ;
         }
         else
         {
            wb_table1_29_3X2e( false) ;
         }
      }

      protected void wb_table6_34_3X2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'" + sGXsfl_115_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV17FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV17FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Pesquisar", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_core\\NegocioPJWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table6_34_3X2e( true) ;
         }
         else
         {
            wb_table6_34_3X2e( false) ;
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
         PA3X2( ) ;
         WS3X2( ) ;
         WE3X2( ) ;
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
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
         AddStyleSheetFile("DVelop/Shared/daterangepicker/daterangepicker.css", "");
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2023828231294", true, true);
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
         context.AddJavascriptSource("core/negociopjww.js", "?2023828231296", false, true);
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_1152( )
      {
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_115_idx;
         edtNegID_Internalname = "NEGID_"+sGXsfl_115_idx;
         edtNegCodigo_Internalname = "NEGCODIGO_"+sGXsfl_115_idx;
         edtNegInsHora_Internalname = "NEGINSHORA_"+sGXsfl_115_idx;
         edtNegInsDataHora_Internalname = "NEGINSDATAHORA_"+sGXsfl_115_idx;
         edtNegInsUsuID_Internalname = "NEGINSUSUID_"+sGXsfl_115_idx;
         edtNegAssunto_Internalname = "NEGASSUNTO_"+sGXsfl_115_idx;
         edtNegCliID_Internalname = "NEGCLIID_"+sGXsfl_115_idx;
         edtNegCliNomeFamiliar_Internalname = "NEGCLINOMEFAMILIAR_"+sGXsfl_115_idx;
         edtNegCpjID_Internalname = "NEGCPJID_"+sGXsfl_115_idx;
         edtNegCpjNomFan_Internalname = "NEGCPJNOMFAN_"+sGXsfl_115_idx;
         edtNegCpjRazSocial_Internalname = "NEGCPJRAZSOCIAL_"+sGXsfl_115_idx;
         edtNegCpjMatricula_Internalname = "NEGCPJMATRICULA_"+sGXsfl_115_idx;
         edtNegPjtID_Internalname = "NEGPJTID_"+sGXsfl_115_idx;
         edtNegPjtSigla_Internalname = "NEGPJTSIGLA_"+sGXsfl_115_idx;
         edtNegPjtNome_Internalname = "NEGPJTNOME_"+sGXsfl_115_idx;
         edtNegAgcID_Internalname = "NEGAGCID_"+sGXsfl_115_idx;
         edtNegAgcNome_Internalname = "NEGAGCNOME_"+sGXsfl_115_idx;
         edtNegValorAtualizado_Internalname = "NEGVALORATUALIZADO_"+sGXsfl_115_idx;
         edtNegInsData_Internalname = "NEGINSDATA_"+sGXsfl_115_idx;
         edtNegInsUsuNome_Internalname = "NEGINSUSUNOME_"+sGXsfl_115_idx;
      }

      protected void SubsflControlProps_fel_1152( )
      {
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_115_fel_idx;
         edtNegID_Internalname = "NEGID_"+sGXsfl_115_fel_idx;
         edtNegCodigo_Internalname = "NEGCODIGO_"+sGXsfl_115_fel_idx;
         edtNegInsHora_Internalname = "NEGINSHORA_"+sGXsfl_115_fel_idx;
         edtNegInsDataHora_Internalname = "NEGINSDATAHORA_"+sGXsfl_115_fel_idx;
         edtNegInsUsuID_Internalname = "NEGINSUSUID_"+sGXsfl_115_fel_idx;
         edtNegAssunto_Internalname = "NEGASSUNTO_"+sGXsfl_115_fel_idx;
         edtNegCliID_Internalname = "NEGCLIID_"+sGXsfl_115_fel_idx;
         edtNegCliNomeFamiliar_Internalname = "NEGCLINOMEFAMILIAR_"+sGXsfl_115_fel_idx;
         edtNegCpjID_Internalname = "NEGCPJID_"+sGXsfl_115_fel_idx;
         edtNegCpjNomFan_Internalname = "NEGCPJNOMFAN_"+sGXsfl_115_fel_idx;
         edtNegCpjRazSocial_Internalname = "NEGCPJRAZSOCIAL_"+sGXsfl_115_fel_idx;
         edtNegCpjMatricula_Internalname = "NEGCPJMATRICULA_"+sGXsfl_115_fel_idx;
         edtNegPjtID_Internalname = "NEGPJTID_"+sGXsfl_115_fel_idx;
         edtNegPjtSigla_Internalname = "NEGPJTSIGLA_"+sGXsfl_115_fel_idx;
         edtNegPjtNome_Internalname = "NEGPJTNOME_"+sGXsfl_115_fel_idx;
         edtNegAgcID_Internalname = "NEGAGCID_"+sGXsfl_115_fel_idx;
         edtNegAgcNome_Internalname = "NEGAGCNOME_"+sGXsfl_115_fel_idx;
         edtNegValorAtualizado_Internalname = "NEGVALORATUALIZADO_"+sGXsfl_115_fel_idx;
         edtNegInsData_Internalname = "NEGINSDATA_"+sGXsfl_115_fel_idx;
         edtNegInsUsuNome_Internalname = "NEGINSUSUNOME_"+sGXsfl_115_fel_idx;
      }

      protected void sendrow_1152( )
      {
         SubsflControlProps_1152( ) ;
         WB3X0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_115_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_115_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_115_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = " " + ((cmbavGridactions.Enabled!=0)&&(cmbavGridactions.Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 116,'',false,'"+sGXsfl_115_idx+"',115)\"" : " ");
            if ( ( cmbavGridactions.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vGRIDACTIONS_" + sGXsfl_115_idx;
               cmbavGridactions.Name = GXCCtl;
               cmbavGridactions.WebTags = "";
               if ( cmbavGridactions.ItemCount > 0 )
               {
                  AV89GridActions = (short)(Math.Round(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV89GridActions), 4, 0))), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV89GridActions), 4, 0));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavGridactions,(string)cmbavGridactions_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV89GridActions), 4, 0)),(short)1,(string)cmbavGridactions_Jsonclick,(short)5,"'"+""+"'"+",false,"+"'"+"EVGRIDACTIONS.CLICK."+sGXsfl_115_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)cmbavGridactions_Class,(string)"WWActionGroupColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((cmbavGridactions.Enabled!=0)&&(cmbavGridactions.Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,116);\"" : " "),(string)"",(bool)true,(short)0});
            cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV89GridActions), 4, 0));
            AssignProp("", false, cmbavGridactions_Internalname, "Values", (string)(cmbavGridactions.ToJavascriptSource()), !bGXsfl_115_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNegID_Internalname,A345NegID.ToString(),A345NegID.ToString(),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNegID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)115,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtNegCodigo_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNegCodigo_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A356NegCodigo), 12, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A356NegCodigo), "ZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNegCodigo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtNegCodigo_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)12,(short)0,(short)0,(short)115,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNegInsHora_Internalname,context.localUtil.TToC( A347NegInsHora, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A347NegInsHora, "99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNegInsHora_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)5,(short)0,(short)0,(short)115,(short)0,(short)-1,(short)0,(bool)true,(string)"core\\HoraMinuto",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNegInsDataHora_Internalname,context.localUtil.TToC( A348NegInsDataHora, 10, 12, 0, 3, "/", ":", " "),context.localUtil.Format( A348NegInsDataHora, "99/99/9999 99:99:99.999"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNegInsDataHora_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)24,(short)0,(short)0,(short)115,(short)0,(short)-1,(short)0,(bool)true,(string)"core\\DataHoraSegundoMS",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNegInsUsuID_Internalname,StringUtil.RTrim( A349NegInsUsuID),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNegInsUsuID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)115,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXusSecurityCommon\\GAMGUID",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtNegAssunto_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNegAssunto_Internalname,(string)A362NegAssunto,StringUtil.RTrim( context.localUtil.Format( A362NegAssunto, "@!")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtNegAssunto_Link,(string)"",(string)"",(string)"",(string)edtNegAssunto_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtNegAssunto_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)115,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNegCliID_Internalname,A350NegCliID.ToString(),A350NegCliID.ToString(),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNegCliID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)115,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtNegCliNomeFamiliar_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNegCliNomeFamiliar_Internalname,(string)A351NegCliNomeFamiliar,StringUtil.RTrim( context.localUtil.Format( A351NegCliNomeFamiliar, "@!")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNegCliNomeFamiliar_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(int)edtNegCliNomeFamiliar_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)115,(short)0,(short)-1,(short)-1,(bool)true,(string)"core\\Nome",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNegCpjID_Internalname,A352NegCpjID.ToString(),A352NegCpjID.ToString(),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNegCpjID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)115,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtNegCpjNomFan_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNegCpjNomFan_Internalname,(string)A353NegCpjNomFan,StringUtil.RTrim( context.localUtil.Format( A353NegCpjNomFan, "@!")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNegCpjNomFan_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(int)edtNegCpjNomFan_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)115,(short)0,(short)-1,(short)-1,(bool)true,(string)"core\\Nome",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNegCpjRazSocial_Internalname,(string)A354NegCpjRazSocial,StringUtil.RTrim( context.localUtil.Format( A354NegCpjRazSocial, "@!")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNegCpjRazSocial_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)115,(short)0,(short)-1,(short)-1,(bool)true,(string)"core\\Nome",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtNegCpjMatricula_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNegCpjMatricula_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A355NegCpjMatricula), 15, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A355NegCpjMatricula), "ZZZ,ZZZ,ZZZ,ZZ9")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNegCpjMatricula_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtNegCpjMatricula_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)15,(short)0,(short)0,(short)115,(short)0,(short)-1,(short)0,(bool)true,(string)"core\\Matricula",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNegPjtID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A357NegPjtID), 11, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A357NegPjtID), "ZZZ,ZZZ,ZZ9")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNegPjtID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)11,(short)0,(short)0,(short)115,(short)0,(short)-1,(short)0,(bool)true,(string)"core\\ID",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNegPjtSigla_Internalname,(string)A358NegPjtSigla,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNegPjtSigla_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)115,(short)0,(short)-1,(short)-1,(bool)true,(string)"core\\Sigla",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtNegPjtNome_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNegPjtNome_Internalname,(string)A359NegPjtNome,StringUtil.RTrim( context.localUtil.Format( A359NegPjtNome, "@!")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtNegPjtNome_Link,(string)"",(string)"",(string)"",(string)edtNegPjtNome_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtNegPjtNome_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)115,(short)0,(short)-1,(short)-1,(bool)true,(string)"core\\Nome",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNegAgcID_Internalname,StringUtil.RTrim( A360NegAgcID),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNegAgcID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)115,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXusSecurityCommon\\GAMGUID",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtNegAgcNome_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNegAgcNome_Internalname,(string)A361NegAgcNome,StringUtil.RTrim( context.localUtil.Format( A361NegAgcNome, "@!")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNegAgcNome_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(int)edtNegAgcNome_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)115,(short)0,(short)-1,(short)-1,(bool)true,(string)"core\\Nome",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtNegValorAtualizado_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNegValorAtualizado_Internalname,StringUtil.LTrim( StringUtil.NToC( A385NegValorAtualizado, 23, 2, ",", "")),StringUtil.LTrim( context.localUtil.Format( A385NegValorAtualizado, "R$ Z,ZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNegValorAtualizado_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtNegValorAtualizado_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)23,(short)0,(short)0,(short)115,(short)0,(short)-1,(short)0,(bool)true,(string)"core\\Monetario",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtNegInsData_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNegInsData_Internalname,context.localUtil.Format(A346NegInsData, "99/99/99"),context.localUtil.Format( A346NegInsData, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNegInsData_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(int)edtNegInsData_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)115,(short)0,(short)-1,(short)0,(bool)true,(string)"core\\Data",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtNegInsUsuNome_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNegInsUsuNome_Internalname,(string)A364NegInsUsuNome,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNegInsUsuNome_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtNegInsUsuNome_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)115,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes3X2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_115_idx = ((subGrid_Islastpage==1)&&(nGXsfl_115_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_115_idx+1);
            sGXsfl_115_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_115_idx), 4, 0), 4, "0");
            SubsflControlProps_1152( ) ;
         }
         /* End function sendrow_1152 */
      }

      protected void init_web_controls( )
      {
         chkavNegdel.Name = "vNEGDEL";
         chkavNegdel.WebTags = "";
         chkavNegdel.Caption = "";
         AssignProp("", false, chkavNegdel_Internalname, "TitleCaption", chkavNegdel.Caption, true);
         chkavNegdel.CheckedValue = "false";
         AV103NegDel = StringUtil.StrToBool( StringUtil.BoolToStr( AV103NegDel));
         AssignAttri("", false, "AV103NegDel", AV103NegDel);
         cmbavDynamicfiltersselector1.Name = "vDYNAMICFILTERSSELECTOR1";
         cmbavDynamicfiltersselector1.WebTags = "";
         cmbavDynamicfiltersselector1.addItem("NEGASSUNTO", "Assunto", 0);
         if ( cmbavDynamicfiltersselector1.ItemCount > 0 )
         {
            AV18DynamicFiltersSelector1 = cmbavDynamicfiltersselector1.getValidValue(AV18DynamicFiltersSelector1);
            AssignAttri("", false, "AV18DynamicFiltersSelector1", AV18DynamicFiltersSelector1);
         }
         cmbavDynamicfiltersoperator1.Name = "vDYNAMICFILTERSOPERATOR1";
         cmbavDynamicfiltersoperator1.WebTags = "";
         cmbavDynamicfiltersoperator1.addItem("0", "Começa com", 0);
         cmbavDynamicfiltersoperator1.addItem("1", "Contém", 0);
         if ( cmbavDynamicfiltersoperator1.ItemCount > 0 )
         {
            AV19DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         }
         cmbavDynamicfiltersselector2.Name = "vDYNAMICFILTERSSELECTOR2";
         cmbavDynamicfiltersselector2.WebTags = "";
         cmbavDynamicfiltersselector2.addItem("NEGASSUNTO", "Assunto", 0);
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
            AV22DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV22DynamicFiltersSelector2);
            AssignAttri("", false, "AV22DynamicFiltersSelector2", AV22DynamicFiltersSelector2);
         }
         cmbavDynamicfiltersoperator2.Name = "vDYNAMICFILTERSOPERATOR2";
         cmbavDynamicfiltersoperator2.WebTags = "";
         cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
         cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV23DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV23DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         }
         cmbavDynamicfiltersselector3.Name = "vDYNAMICFILTERSSELECTOR3";
         cmbavDynamicfiltersselector3.WebTags = "";
         cmbavDynamicfiltersselector3.addItem("NEGASSUNTO", "Assunto", 0);
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV26DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV26DynamicFiltersSelector3);
            AssignAttri("", false, "AV26DynamicFiltersSelector3", AV26DynamicFiltersSelector3);
         }
         cmbavDynamicfiltersoperator3.Name = "vDYNAMICFILTERSOPERATOR3";
         cmbavDynamicfiltersoperator3.WebTags = "";
         cmbavDynamicfiltersoperator3.addItem("0", "Começa com", 0);
         cmbavDynamicfiltersoperator3.addItem("1", "Contém", 0);
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV27DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         }
         GXCCtl = "vGRIDACTIONS_" + sGXsfl_115_idx;
         cmbavGridactions.Name = GXCCtl;
         cmbavGridactions.WebTags = "";
         if ( cmbavGridactions.ItemCount > 0 )
         {
            AV89GridActions = (short)(Math.Round(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV89GridActions), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV89GridActions), 4, 0));
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl115( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"115\">") ;
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
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+cmbavGridactions_Class+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtNegCodigo_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Negociação") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtNegAssunto_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Assunto") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtNegCliNomeFamiliar_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Cliente") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtNegCpjNomFan_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Unidade") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtNegCpjMatricula_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Matrícula") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtNegPjtNome_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Tipo") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtNegAgcNome_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Agente Comercial") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtNegValorAtualizado_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Total em Negócios") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtNegInsData_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Incluído em") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtNegInsUsuNome_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Incluído por") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV89GridActions), 4, 0, ".", ""))));
            GridColumn.AddObjectProperty("Class", StringUtil.RTrim( cmbavGridactions_Class));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A345NegID.ToString()));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A356NegCodigo), 12, 0, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNegCodigo_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A347NegInsHora, 10, 8, 0, 3, "/", ":", " ")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A348NegInsDataHora, 10, 12, 0, 3, "/", ":", " ")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A349NegInsUsuID)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A362NegAssunto));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtNegAssunto_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNegAssunto_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A350NegCliID.ToString()));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A351NegCliNomeFamiliar));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNegCliNomeFamiliar_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A352NegCpjID.ToString()));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A353NegCpjNomFan));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNegCpjNomFan_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A354NegCpjRazSocial));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A355NegCpjMatricula), 15, 0, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNegCpjMatricula_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A357NegPjtID), 11, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A358NegPjtSigla));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A359NegPjtNome));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtNegPjtNome_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNegPjtNome_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A360NegAgcID)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A361NegAgcNome));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNegAgcNome_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A385NegValorAtualizado, 23, 2, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNegValorAtualizado_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A346NegInsData, "99/99/99")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNegInsData_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A364NegInsUsuNome));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNegInsUsuNome_Visible), 5, 0, ".", "")));
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
         chkavNegdel_Internalname = "vNEGDEL";
         bttBtninsert_Internalname = "BTNINSERT";
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
         edtavNegassunto1_Internalname = "vNEGASSUNTO1";
         cellFilter_negassunto1_cell_Internalname = "FILTER_NEGASSUNTO1_CELL";
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
         edtavNegassunto2_Internalname = "vNEGASSUNTO2";
         cellFilter_negassunto2_cell_Internalname = "FILTER_NEGASSUNTO2_CELL";
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
         edtavNegassunto3_Internalname = "vNEGASSUNTO3";
         cellFilter_negassunto3_cell_Internalname = "FILTER_NEGASSUNTO3_CELL";
         imgRemovedynamicfilters3_Internalname = "REMOVEDYNAMICFILTERS3";
         cellDynamicfilters_removefilter3_cell_Internalname = "DYNAMICFILTERS_REMOVEFILTER3_CELL";
         tblTablemergeddynamicfilters3_Internalname = "TABLEMERGEDDYNAMICFILTERS3";
         divTabledynamicfiltersrow3_Internalname = "TABLEDYNAMICFILTERSROW3";
         divTabledynamicfilters_Internalname = "TABLEDYNAMICFILTERS";
         divAdvancedfilterscontainer_Internalname = "ADVANCEDFILTERSCONTAINER";
         divTableheader_Internalname = "TABLEHEADER";
         cmbavGridactions_Internalname = "vGRIDACTIONS";
         edtNegID_Internalname = "NEGID";
         edtNegCodigo_Internalname = "NEGCODIGO";
         edtNegInsHora_Internalname = "NEGINSHORA";
         edtNegInsDataHora_Internalname = "NEGINSDATAHORA";
         edtNegInsUsuID_Internalname = "NEGINSUSUID";
         edtNegAssunto_Internalname = "NEGASSUNTO";
         edtNegCliID_Internalname = "NEGCLIID";
         edtNegCliNomeFamiliar_Internalname = "NEGCLINOMEFAMILIAR";
         edtNegCpjID_Internalname = "NEGCPJID";
         edtNegCpjNomFan_Internalname = "NEGCPJNOMFAN";
         edtNegCpjRazSocial_Internalname = "NEGCPJRAZSOCIAL";
         edtNegCpjMatricula_Internalname = "NEGCPJMATRICULA";
         edtNegPjtID_Internalname = "NEGPJTID";
         edtNegPjtSigla_Internalname = "NEGPJTSIGLA";
         edtNegPjtNome_Internalname = "NEGPJTNOME";
         edtNegAgcID_Internalname = "NEGAGCID";
         edtNegAgcNome_Internalname = "NEGAGCNOME";
         edtNegValorAtualizado_Internalname = "NEGVALORATUALIZADO";
         edtNegInsData_Internalname = "NEGINSDATA";
         edtNegInsUsuNome_Internalname = "NEGINSUSUNOME";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         Ddo_agexport_Internalname = "DDO_AGEXPORT";
         Ddc_subscriptions_Internalname = "DDC_SUBSCRIPTIONS";
         lblJsdynamicfilters_Internalname = "JSDYNAMICFILTERS";
         Ddo_grid_Internalname = "DDO_GRID";
         Innewwindow1_Internalname = "INNEWWINDOW1";
         Ddo_gridcolumnsselector_Internalname = "DDO_GRIDCOLUMNSSELECTOR";
         Dvelop_confirmpanel_delete_Internalname = "DVELOP_CONFIRMPANEL_DELETE";
         tblTabledvelop_confirmpanel_delete_Internalname = "TABLEDVELOP_CONFIRMPANEL_DELETE";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
         divDiv_wwpauxwc_Internalname = "DIV_WWPAUXWC";
         edtavDdo_neginsdataauxdatetext_Internalname = "vDDO_NEGINSDATAAUXDATETEXT";
         Tfneginsdata_rangepicker_Internalname = "TFNEGINSDATA_RANGEPICKER";
         divDdo_neginsdataauxdates_Internalname = "DDO_NEGINSDATAAUXDATES";
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
         chkavNegdel.Caption = "Neg Del";
         edtNegInsUsuNome_Jsonclick = "";
         edtNegInsData_Jsonclick = "";
         edtNegValorAtualizado_Jsonclick = "";
         edtNegAgcNome_Jsonclick = "";
         edtNegAgcID_Jsonclick = "";
         edtNegPjtNome_Jsonclick = "";
         edtNegPjtNome_Link = "";
         edtNegPjtSigla_Jsonclick = "";
         edtNegPjtID_Jsonclick = "";
         edtNegCpjMatricula_Jsonclick = "";
         edtNegCpjRazSocial_Jsonclick = "";
         edtNegCpjNomFan_Jsonclick = "";
         edtNegCpjID_Jsonclick = "";
         edtNegCliNomeFamiliar_Jsonclick = "";
         edtNegCliID_Jsonclick = "";
         edtNegAssunto_Jsonclick = "";
         edtNegAssunto_Link = "";
         edtNegInsUsuID_Jsonclick = "";
         edtNegInsDataHora_Jsonclick = "";
         edtNegInsHora_Jsonclick = "";
         edtNegCodigo_Jsonclick = "";
         edtNegID_Jsonclick = "";
         cmbavGridactions_Jsonclick = "";
         cmbavGridactions.Visible = -1;
         cmbavGridactions.Enabled = 1;
         cmbavGridactions_Class = "ConvertToDDO";
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         imgRemovedynamicfilters1_Visible = 1;
         imgAdddynamicfilters1_Visible = 1;
         edtavNegassunto1_Jsonclick = "";
         edtavNegassunto1_Enabled = 1;
         cmbavDynamicfiltersoperator1_Jsonclick = "";
         cmbavDynamicfiltersoperator1.Enabled = 1;
         imgRemovedynamicfilters2_Visible = 1;
         imgAdddynamicfilters2_Visible = 1;
         edtavNegassunto2_Jsonclick = "";
         edtavNegassunto2_Enabled = 1;
         cmbavDynamicfiltersoperator2_Jsonclick = "";
         cmbavDynamicfiltersoperator2.Enabled = 1;
         edtavNegassunto3_Jsonclick = "";
         edtavNegassunto3_Enabled = 1;
         cmbavDynamicfiltersoperator3_Jsonclick = "";
         cmbavDynamicfiltersoperator3.Enabled = 1;
         cmbavDynamicfiltersoperator3.Visible = 1;
         edtavNegassunto3_Visible = 1;
         cmbavDynamicfiltersoperator2.Visible = 1;
         edtavNegassunto2_Visible = 1;
         cmbavDynamicfiltersoperator1.Visible = 1;
         edtavNegassunto1_Visible = 1;
         edtNegInsUsuNome_Visible = -1;
         edtNegInsData_Visible = -1;
         edtNegValorAtualizado_Visible = -1;
         edtNegAgcNome_Visible = -1;
         edtNegPjtNome_Visible = -1;
         edtNegCpjMatricula_Visible = -1;
         edtNegCpjNomFan_Visible = -1;
         edtNegCliNomeFamiliar_Visible = -1;
         edtNegAssunto_Visible = -1;
         edtNegCodigo_Visible = -1;
         subGrid_Sortable = 0;
         edtavDdo_neginsdataauxdatetext_Jsonclick = "";
         lblJsdynamicfilters_Caption = "JSDynamicFilters";
         cmbavDynamicfiltersselector3_Jsonclick = "";
         cmbavDynamicfiltersselector3.Enabled = 1;
         cmbavDynamicfiltersselector2_Jsonclick = "";
         cmbavDynamicfiltersselector2.Enabled = 1;
         cmbavDynamicfiltersselector1_Jsonclick = "";
         cmbavDynamicfiltersselector1.Enabled = 1;
         bttBtnsubscriptions_Visible = 1;
         bttBtninsert_Visible = 1;
         chkavNegdel.Enabled = 1;
         Grid_empowerer_Fixedcolumns = "L;;;;;;;;;;;;;;;;;;;;";
         Grid_empowerer_Hascolumnsselector = Convert.ToBoolean( -1);
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Dvelop_confirmpanel_delete_Confirmtype = "1";
         Dvelop_confirmpanel_delete_Yesbuttonposition = "left";
         Dvelop_confirmpanel_delete_Cancelbuttoncaption = "WWP_ConfirmTextCancel";
         Dvelop_confirmpanel_delete_Nobuttoncaption = "WWP_ConfirmTextNo";
         Dvelop_confirmpanel_delete_Yesbuttoncaption = "WWP_ConfirmTextYes";
         Dvelop_confirmpanel_delete_Confirmationtext = "Deseja realmente EXCLUIR a OPORTUNIDADE DE NEGÓCIO?";
         Dvelop_confirmpanel_delete_Title = "Decida";
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
         Ddo_grid_Format = "12.0||||12.0|||16.2||";
         Ddo_grid_Datalistproc = "core.NegocioPJWWGetFilterData";
         Ddo_grid_Datalisttype = "|Dynamic|Dynamic|Dynamic||Dynamic|Dynamic|||Dynamic";
         Ddo_grid_Includedatalist = "|T|T|T||T|T|||T";
         Ddo_grid_Filterisrange = "T||||T|||T|P|";
         Ddo_grid_Filtertype = "Numeric|Character|Character|Character|Numeric|Character|Character|Numeric|Date|Character";
         Ddo_grid_Includefilter = "T";
         Ddo_grid_Fixable = "T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "2|1|3|4|5|6|7|8|9|10";
         Ddo_grid_Columnids = "2:NegCodigo|6:NegAssunto|8:NegCliNomeFamiliar|10:NegCpjNomFan|12:NegCpjMatricula|15:NegPjtNome|17:NegAgcNome|18:NegValorAtualizado|19:NegInsData|20:NegInsUsuNome";
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
         Form.Caption = "Oportunidades de Negócio";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV20NegAssunto1',fld:'vNEGASSUNTO1',pic:'@!'},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV24NegAssunto2',fld:'vNEGASSUNTO2',pic:'@!'},{av:'cmbavDynamicfiltersselector3'},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV28NegAssunto3',fld:'vNEGASSUNTO3',pic:'@!'},{av:'AV106Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV103NegDel',fld:'vNEGDEL',pic:''},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV41TFNegCodigo',fld:'vTFNEGCODIGO',pic:'ZZZZZZZZZZZ9'},{av:'AV42TFNegCodigo_To',fld:'vTFNEGCODIGO_TO',pic:'ZZZZZZZZZZZ9'},{av:'AV80TFNegAssunto',fld:'vTFNEGASSUNTO',pic:'@!'},{av:'AV81TFNegAssunto_Sel',fld:'vTFNEGASSUNTO_SEL',pic:'@!'},{av:'AV62TFNegCliNomeFamiliar',fld:'vTFNEGCLINOMEFAMILIAR',pic:'@!'},{av:'AV63TFNegCliNomeFamiliar_Sel',fld:'vTFNEGCLINOMEFAMILIAR_SEL',pic:'@!'},{av:'AV64TFNegCpjNomFan',fld:'vTFNEGCPJNOMFAN',pic:'@!'},{av:'AV65TFNegCpjNomFan_Sel',fld:'vTFNEGCPJNOMFAN_SEL',pic:'@!'},{av:'AV68TFNegCpjMatricula',fld:'vTFNEGCPJMATRICULA',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV69TFNegCpjMatricula_To',fld:'vTFNEGCPJMATRICULA_TO',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV74TFNegPjtNome',fld:'vTFNEGPJTNOME',pic:'@!'},{av:'AV75TFNegPjtNome_Sel',fld:'vTFNEGPJTNOME_SEL',pic:'@!'},{av:'AV78TFNegAgcNome',fld:'vTFNEGAGCNOME',pic:'@!'},{av:'AV79TFNegAgcNome_Sel',fld:'vTFNEGAGCNOME_SEL',pic:'@!'},{av:'AV99TFNegValorAtualizado',fld:'vTFNEGVALORATUALIZADO',pic:'R$ Z,ZZZ,ZZZ,ZZZ,ZZ9.99'},{av:'AV100TFNegValorAtualizado_To',fld:'vTFNEGVALORATUALIZADO_TO',pic:'R$ Z,ZZZ,ZZZ,ZZZ,ZZ9.99'},{av:'AV43TFNegInsData',fld:'vTFNEGINSDATA',pic:''},{av:'AV44TFNegInsData_To',fld:'vTFNEGINSDATA_TO',pic:''},{av:'AV97TFNegInsUsuNome',fld:'vTFNEGINSUSUNOME',pic:''},{av:'AV98TFNegInsUsuNome_Sel',fld:'vTFNEGINSUSUNOME_SEL',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV90IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV91IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV96IsAuthorized_NegAssunto',fld:'vISAUTHORIZED_NEGASSUNTO',pic:'',hsh:true},{av:'AV92IsAuthorized_NegPjtNome',fld:'vISAUTHORIZED_NEGPJTNOME',pic:'',hsh:true},{av:'AV95IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtNegCodigo_Visible',ctrl:'NEGCODIGO',prop:'Visible'},{av:'edtNegAssunto_Visible',ctrl:'NEGASSUNTO',prop:'Visible'},{av:'edtNegCliNomeFamiliar_Visible',ctrl:'NEGCLINOMEFAMILIAR',prop:'Visible'},{av:'edtNegCpjNomFan_Visible',ctrl:'NEGCPJNOMFAN',prop:'Visible'},{av:'edtNegCpjMatricula_Visible',ctrl:'NEGCPJMATRICULA',prop:'Visible'},{av:'edtNegPjtNome_Visible',ctrl:'NEGPJTNOME',prop:'Visible'},{av:'edtNegAgcNome_Visible',ctrl:'NEGAGCNOME',prop:'Visible'},{av:'edtNegValorAtualizado_Visible',ctrl:'NEGVALORATUALIZADO',prop:'Visible'},{av:'edtNegInsData_Visible',ctrl:'NEGINSDATA',prop:'Visible'},{av:'edtNegInsUsuNome_Visible',ctrl:'NEGINSUSUNOME',prop:'Visible'},{av:'AV86GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV87GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV88GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV90IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV91IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV95IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV38ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E123X2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV20NegAssunto1',fld:'vNEGASSUNTO1',pic:'@!'},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV24NegAssunto2',fld:'vNEGASSUNTO2',pic:'@!'},{av:'cmbavDynamicfiltersselector3'},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV28NegAssunto3',fld:'vNEGASSUNTO3',pic:'@!'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV106Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV103NegDel',fld:'vNEGDEL',pic:''},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV41TFNegCodigo',fld:'vTFNEGCODIGO',pic:'ZZZZZZZZZZZ9'},{av:'AV42TFNegCodigo_To',fld:'vTFNEGCODIGO_TO',pic:'ZZZZZZZZZZZ9'},{av:'AV80TFNegAssunto',fld:'vTFNEGASSUNTO',pic:'@!'},{av:'AV81TFNegAssunto_Sel',fld:'vTFNEGASSUNTO_SEL',pic:'@!'},{av:'AV62TFNegCliNomeFamiliar',fld:'vTFNEGCLINOMEFAMILIAR',pic:'@!'},{av:'AV63TFNegCliNomeFamiliar_Sel',fld:'vTFNEGCLINOMEFAMILIAR_SEL',pic:'@!'},{av:'AV64TFNegCpjNomFan',fld:'vTFNEGCPJNOMFAN',pic:'@!'},{av:'AV65TFNegCpjNomFan_Sel',fld:'vTFNEGCPJNOMFAN_SEL',pic:'@!'},{av:'AV68TFNegCpjMatricula',fld:'vTFNEGCPJMATRICULA',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV69TFNegCpjMatricula_To',fld:'vTFNEGCPJMATRICULA_TO',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV74TFNegPjtNome',fld:'vTFNEGPJTNOME',pic:'@!'},{av:'AV75TFNegPjtNome_Sel',fld:'vTFNEGPJTNOME_SEL',pic:'@!'},{av:'AV78TFNegAgcNome',fld:'vTFNEGAGCNOME',pic:'@!'},{av:'AV79TFNegAgcNome_Sel',fld:'vTFNEGAGCNOME_SEL',pic:'@!'},{av:'AV99TFNegValorAtualizado',fld:'vTFNEGVALORATUALIZADO',pic:'R$ Z,ZZZ,ZZZ,ZZZ,ZZ9.99'},{av:'AV100TFNegValorAtualizado_To',fld:'vTFNEGVALORATUALIZADO_TO',pic:'R$ Z,ZZZ,ZZZ,ZZZ,ZZ9.99'},{av:'AV43TFNegInsData',fld:'vTFNEGINSDATA',pic:''},{av:'AV44TFNegInsData_To',fld:'vTFNEGINSDATA_TO',pic:''},{av:'AV97TFNegInsUsuNome',fld:'vTFNEGINSUSUNOME',pic:''},{av:'AV98TFNegInsUsuNome_Sel',fld:'vTFNEGINSUSUNOME_SEL',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV90IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV91IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV96IsAuthorized_NegAssunto',fld:'vISAUTHORIZED_NEGASSUNTO',pic:'',hsh:true},{av:'AV92IsAuthorized_NegPjtNome',fld:'vISAUTHORIZED_NEGPJTNOME',pic:'',hsh:true},{av:'AV95IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E133X2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV20NegAssunto1',fld:'vNEGASSUNTO1',pic:'@!'},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV24NegAssunto2',fld:'vNEGASSUNTO2',pic:'@!'},{av:'cmbavDynamicfiltersselector3'},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV28NegAssunto3',fld:'vNEGASSUNTO3',pic:'@!'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV106Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV103NegDel',fld:'vNEGDEL',pic:''},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV41TFNegCodigo',fld:'vTFNEGCODIGO',pic:'ZZZZZZZZZZZ9'},{av:'AV42TFNegCodigo_To',fld:'vTFNEGCODIGO_TO',pic:'ZZZZZZZZZZZ9'},{av:'AV80TFNegAssunto',fld:'vTFNEGASSUNTO',pic:'@!'},{av:'AV81TFNegAssunto_Sel',fld:'vTFNEGASSUNTO_SEL',pic:'@!'},{av:'AV62TFNegCliNomeFamiliar',fld:'vTFNEGCLINOMEFAMILIAR',pic:'@!'},{av:'AV63TFNegCliNomeFamiliar_Sel',fld:'vTFNEGCLINOMEFAMILIAR_SEL',pic:'@!'},{av:'AV64TFNegCpjNomFan',fld:'vTFNEGCPJNOMFAN',pic:'@!'},{av:'AV65TFNegCpjNomFan_Sel',fld:'vTFNEGCPJNOMFAN_SEL',pic:'@!'},{av:'AV68TFNegCpjMatricula',fld:'vTFNEGCPJMATRICULA',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV69TFNegCpjMatricula_To',fld:'vTFNEGCPJMATRICULA_TO',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV74TFNegPjtNome',fld:'vTFNEGPJTNOME',pic:'@!'},{av:'AV75TFNegPjtNome_Sel',fld:'vTFNEGPJTNOME_SEL',pic:'@!'},{av:'AV78TFNegAgcNome',fld:'vTFNEGAGCNOME',pic:'@!'},{av:'AV79TFNegAgcNome_Sel',fld:'vTFNEGAGCNOME_SEL',pic:'@!'},{av:'AV99TFNegValorAtualizado',fld:'vTFNEGVALORATUALIZADO',pic:'R$ Z,ZZZ,ZZZ,ZZZ,ZZ9.99'},{av:'AV100TFNegValorAtualizado_To',fld:'vTFNEGVALORATUALIZADO_TO',pic:'R$ Z,ZZZ,ZZZ,ZZZ,ZZ9.99'},{av:'AV43TFNegInsData',fld:'vTFNEGINSDATA',pic:''},{av:'AV44TFNegInsData_To',fld:'vTFNEGINSDATA_TO',pic:''},{av:'AV97TFNegInsUsuNome',fld:'vTFNEGINSUSUNOME',pic:''},{av:'AV98TFNegInsUsuNome_Sel',fld:'vTFNEGINSUSUNOME_SEL',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV90IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV91IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV96IsAuthorized_NegAssunto',fld:'vISAUTHORIZED_NEGASSUNTO',pic:'',hsh:true},{av:'AV92IsAuthorized_NegPjtNome',fld:'vISAUTHORIZED_NEGPJTNOME',pic:'',hsh:true},{av:'AV95IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]}");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","{handler:'E163X2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV20NegAssunto1',fld:'vNEGASSUNTO1',pic:'@!'},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV24NegAssunto2',fld:'vNEGASSUNTO2',pic:'@!'},{av:'cmbavDynamicfiltersselector3'},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV28NegAssunto3',fld:'vNEGASSUNTO3',pic:'@!'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV106Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV103NegDel',fld:'vNEGDEL',pic:''},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV41TFNegCodigo',fld:'vTFNEGCODIGO',pic:'ZZZZZZZZZZZ9'},{av:'AV42TFNegCodigo_To',fld:'vTFNEGCODIGO_TO',pic:'ZZZZZZZZZZZ9'},{av:'AV80TFNegAssunto',fld:'vTFNEGASSUNTO',pic:'@!'},{av:'AV81TFNegAssunto_Sel',fld:'vTFNEGASSUNTO_SEL',pic:'@!'},{av:'AV62TFNegCliNomeFamiliar',fld:'vTFNEGCLINOMEFAMILIAR',pic:'@!'},{av:'AV63TFNegCliNomeFamiliar_Sel',fld:'vTFNEGCLINOMEFAMILIAR_SEL',pic:'@!'},{av:'AV64TFNegCpjNomFan',fld:'vTFNEGCPJNOMFAN',pic:'@!'},{av:'AV65TFNegCpjNomFan_Sel',fld:'vTFNEGCPJNOMFAN_SEL',pic:'@!'},{av:'AV68TFNegCpjMatricula',fld:'vTFNEGCPJMATRICULA',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV69TFNegCpjMatricula_To',fld:'vTFNEGCPJMATRICULA_TO',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV74TFNegPjtNome',fld:'vTFNEGPJTNOME',pic:'@!'},{av:'AV75TFNegPjtNome_Sel',fld:'vTFNEGPJTNOME_SEL',pic:'@!'},{av:'AV78TFNegAgcNome',fld:'vTFNEGAGCNOME',pic:'@!'},{av:'AV79TFNegAgcNome_Sel',fld:'vTFNEGAGCNOME_SEL',pic:'@!'},{av:'AV99TFNegValorAtualizado',fld:'vTFNEGVALORATUALIZADO',pic:'R$ Z,ZZZ,ZZZ,ZZZ,ZZ9.99'},{av:'AV100TFNegValorAtualizado_To',fld:'vTFNEGVALORATUALIZADO_TO',pic:'R$ Z,ZZZ,ZZZ,ZZZ,ZZ9.99'},{av:'AV43TFNegInsData',fld:'vTFNEGINSDATA',pic:''},{av:'AV44TFNegInsData_To',fld:'vTFNEGINSDATA_TO',pic:''},{av:'AV97TFNegInsUsuNome',fld:'vTFNEGINSUSUNOME',pic:''},{av:'AV98TFNegInsUsuNome_Sel',fld:'vTFNEGINSUSUNOME_SEL',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV90IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV91IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV96IsAuthorized_NegAssunto',fld:'vISAUTHORIZED_NEGASSUNTO',pic:'',hsh:true},{av:'AV92IsAuthorized_NegPjtNome',fld:'vISAUTHORIZED_NEGPJTNOME',pic:'',hsh:true},{av:'AV95IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'Ddo_grid_Activeeventkey',ctrl:'DDO_GRID',prop:'ActiveEventKey'},{av:'Ddo_grid_Selectedvalue_get',ctrl:'DDO_GRID',prop:'SelectedValue_get'},{av:'Ddo_grid_Filteredtextto_get',ctrl:'DDO_GRID',prop:'FilteredTextTo_get'},{av:'Ddo_grid_Filteredtext_get',ctrl:'DDO_GRID',prop:'FilteredText_get'},{av:'Ddo_grid_Selectedcolumn',ctrl:'DDO_GRID',prop:'SelectedColumn'}]");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",",oparms:[{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV97TFNegInsUsuNome',fld:'vTFNEGINSUSUNOME',pic:''},{av:'AV98TFNegInsUsuNome_Sel',fld:'vTFNEGINSUSUNOME_SEL',pic:''},{av:'AV43TFNegInsData',fld:'vTFNEGINSDATA',pic:''},{av:'AV44TFNegInsData_To',fld:'vTFNEGINSDATA_TO',pic:''},{av:'AV99TFNegValorAtualizado',fld:'vTFNEGVALORATUALIZADO',pic:'R$ Z,ZZZ,ZZZ,ZZZ,ZZ9.99'},{av:'AV100TFNegValorAtualizado_To',fld:'vTFNEGVALORATUALIZADO_TO',pic:'R$ Z,ZZZ,ZZZ,ZZZ,ZZ9.99'},{av:'AV78TFNegAgcNome',fld:'vTFNEGAGCNOME',pic:'@!'},{av:'AV79TFNegAgcNome_Sel',fld:'vTFNEGAGCNOME_SEL',pic:'@!'},{av:'AV74TFNegPjtNome',fld:'vTFNEGPJTNOME',pic:'@!'},{av:'AV75TFNegPjtNome_Sel',fld:'vTFNEGPJTNOME_SEL',pic:'@!'},{av:'AV68TFNegCpjMatricula',fld:'vTFNEGCPJMATRICULA',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV69TFNegCpjMatricula_To',fld:'vTFNEGCPJMATRICULA_TO',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV64TFNegCpjNomFan',fld:'vTFNEGCPJNOMFAN',pic:'@!'},{av:'AV65TFNegCpjNomFan_Sel',fld:'vTFNEGCPJNOMFAN_SEL',pic:'@!'},{av:'AV62TFNegCliNomeFamiliar',fld:'vTFNEGCLINOMEFAMILIAR',pic:'@!'},{av:'AV63TFNegCliNomeFamiliar_Sel',fld:'vTFNEGCLINOMEFAMILIAR_SEL',pic:'@!'},{av:'AV80TFNegAssunto',fld:'vTFNEGASSUNTO',pic:'@!'},{av:'AV81TFNegAssunto_Sel',fld:'vTFNEGASSUNTO_SEL',pic:'@!'},{av:'AV41TFNegCodigo',fld:'vTFNEGCODIGO',pic:'ZZZZZZZZZZZ9'},{av:'AV42TFNegCodigo_To',fld:'vTFNEGCODIGO_TO',pic:'ZZZZZZZZZZZ9'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E303X2',iparms:[{av:'AV90IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV91IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV96IsAuthorized_NegAssunto',fld:'vISAUTHORIZED_NEGASSUNTO',pic:'',hsh:true},{av:'A345NegID',fld:'NEGID',pic:'',hsh:true},{av:'AV92IsAuthorized_NegPjtNome',fld:'vISAUTHORIZED_NEGPJTNOME',pic:'',hsh:true},{av:'A357NegPjtID',fld:'NEGPJTID',pic:'ZZZ,ZZZ,ZZ9'}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'cmbavGridactions'},{av:'AV89GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9'},{av:'edtNegAssunto_Link',ctrl:'NEGASSUNTO',prop:'Link'},{av:'edtNegPjtNome_Link',ctrl:'NEGPJTNOME',prop:'Link'}]}");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED","{handler:'E173X2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV20NegAssunto1',fld:'vNEGASSUNTO1',pic:'@!'},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV24NegAssunto2',fld:'vNEGASSUNTO2',pic:'@!'},{av:'cmbavDynamicfiltersselector3'},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV28NegAssunto3',fld:'vNEGASSUNTO3',pic:'@!'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV106Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV103NegDel',fld:'vNEGDEL',pic:''},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV41TFNegCodigo',fld:'vTFNEGCODIGO',pic:'ZZZZZZZZZZZ9'},{av:'AV42TFNegCodigo_To',fld:'vTFNEGCODIGO_TO',pic:'ZZZZZZZZZZZ9'},{av:'AV80TFNegAssunto',fld:'vTFNEGASSUNTO',pic:'@!'},{av:'AV81TFNegAssunto_Sel',fld:'vTFNEGASSUNTO_SEL',pic:'@!'},{av:'AV62TFNegCliNomeFamiliar',fld:'vTFNEGCLINOMEFAMILIAR',pic:'@!'},{av:'AV63TFNegCliNomeFamiliar_Sel',fld:'vTFNEGCLINOMEFAMILIAR_SEL',pic:'@!'},{av:'AV64TFNegCpjNomFan',fld:'vTFNEGCPJNOMFAN',pic:'@!'},{av:'AV65TFNegCpjNomFan_Sel',fld:'vTFNEGCPJNOMFAN_SEL',pic:'@!'},{av:'AV68TFNegCpjMatricula',fld:'vTFNEGCPJMATRICULA',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV69TFNegCpjMatricula_To',fld:'vTFNEGCPJMATRICULA_TO',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV74TFNegPjtNome',fld:'vTFNEGPJTNOME',pic:'@!'},{av:'AV75TFNegPjtNome_Sel',fld:'vTFNEGPJTNOME_SEL',pic:'@!'},{av:'AV78TFNegAgcNome',fld:'vTFNEGAGCNOME',pic:'@!'},{av:'AV79TFNegAgcNome_Sel',fld:'vTFNEGAGCNOME_SEL',pic:'@!'},{av:'AV99TFNegValorAtualizado',fld:'vTFNEGVALORATUALIZADO',pic:'R$ Z,ZZZ,ZZZ,ZZZ,ZZ9.99'},{av:'AV100TFNegValorAtualizado_To',fld:'vTFNEGVALORATUALIZADO_TO',pic:'R$ Z,ZZZ,ZZZ,ZZZ,ZZ9.99'},{av:'AV43TFNegInsData',fld:'vTFNEGINSDATA',pic:''},{av:'AV44TFNegInsData_To',fld:'vTFNEGINSDATA_TO',pic:''},{av:'AV97TFNegInsUsuNome',fld:'vTFNEGINSUSUNOME',pic:''},{av:'AV98TFNegInsUsuNome_Sel',fld:'vTFNEGINSUSUNOME_SEL',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV90IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV91IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV96IsAuthorized_NegAssunto',fld:'vISAUTHORIZED_NEGASSUNTO',pic:'',hsh:true},{av:'AV92IsAuthorized_NegPjtNome',fld:'vISAUTHORIZED_NEGPJTNOME',pic:'',hsh:true},{av:'AV95IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'Ddo_gridcolumnsselector_Columnsselectorvalues',ctrl:'DDO_GRIDCOLUMNSSELECTOR',prop:'ColumnsSelectorValues'}]");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED",",oparms:[{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'edtNegCodigo_Visible',ctrl:'NEGCODIGO',prop:'Visible'},{av:'edtNegAssunto_Visible',ctrl:'NEGASSUNTO',prop:'Visible'},{av:'edtNegCliNomeFamiliar_Visible',ctrl:'NEGCLINOMEFAMILIAR',prop:'Visible'},{av:'edtNegCpjNomFan_Visible',ctrl:'NEGCPJNOMFAN',prop:'Visible'},{av:'edtNegCpjMatricula_Visible',ctrl:'NEGCPJMATRICULA',prop:'Visible'},{av:'edtNegPjtNome_Visible',ctrl:'NEGPJTNOME',prop:'Visible'},{av:'edtNegAgcNome_Visible',ctrl:'NEGAGCNOME',prop:'Visible'},{av:'edtNegValorAtualizado_Visible',ctrl:'NEGVALORATUALIZADO',prop:'Visible'},{av:'edtNegInsData_Visible',ctrl:'NEGINSDATA',prop:'Visible'},{av:'edtNegInsUsuNome_Visible',ctrl:'NEGINSUSUNOME',prop:'Visible'},{av:'AV86GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV87GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV88GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV90IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV91IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV95IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV38ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("'ADDDYNAMICFILTERS1'","{handler:'E233X2',iparms:[]");
         setEventMetadata("'ADDDYNAMICFILTERS1'",",oparms:[{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'","{handler:'E193X2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV20NegAssunto1',fld:'vNEGASSUNTO1',pic:'@!'},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV24NegAssunto2',fld:'vNEGASSUNTO2',pic:'@!'},{av:'cmbavDynamicfiltersselector3'},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV28NegAssunto3',fld:'vNEGASSUNTO3',pic:'@!'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV106Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV103NegDel',fld:'vNEGDEL',pic:''},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV41TFNegCodigo',fld:'vTFNEGCODIGO',pic:'ZZZZZZZZZZZ9'},{av:'AV42TFNegCodigo_To',fld:'vTFNEGCODIGO_TO',pic:'ZZZZZZZZZZZ9'},{av:'AV80TFNegAssunto',fld:'vTFNEGASSUNTO',pic:'@!'},{av:'AV81TFNegAssunto_Sel',fld:'vTFNEGASSUNTO_SEL',pic:'@!'},{av:'AV62TFNegCliNomeFamiliar',fld:'vTFNEGCLINOMEFAMILIAR',pic:'@!'},{av:'AV63TFNegCliNomeFamiliar_Sel',fld:'vTFNEGCLINOMEFAMILIAR_SEL',pic:'@!'},{av:'AV64TFNegCpjNomFan',fld:'vTFNEGCPJNOMFAN',pic:'@!'},{av:'AV65TFNegCpjNomFan_Sel',fld:'vTFNEGCPJNOMFAN_SEL',pic:'@!'},{av:'AV68TFNegCpjMatricula',fld:'vTFNEGCPJMATRICULA',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV69TFNegCpjMatricula_To',fld:'vTFNEGCPJMATRICULA_TO',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV74TFNegPjtNome',fld:'vTFNEGPJTNOME',pic:'@!'},{av:'AV75TFNegPjtNome_Sel',fld:'vTFNEGPJTNOME_SEL',pic:'@!'},{av:'AV78TFNegAgcNome',fld:'vTFNEGAGCNOME',pic:'@!'},{av:'AV79TFNegAgcNome_Sel',fld:'vTFNEGAGCNOME_SEL',pic:'@!'},{av:'AV99TFNegValorAtualizado',fld:'vTFNEGVALORATUALIZADO',pic:'R$ Z,ZZZ,ZZZ,ZZZ,ZZ9.99'},{av:'AV100TFNegValorAtualizado_To',fld:'vTFNEGVALORATUALIZADO_TO',pic:'R$ Z,ZZZ,ZZZ,ZZZ,ZZ9.99'},{av:'AV43TFNegInsData',fld:'vTFNEGINSDATA',pic:''},{av:'AV44TFNegInsData_To',fld:'vTFNEGINSDATA_TO',pic:''},{av:'AV97TFNegInsUsuNome',fld:'vTFNEGINSUSUNOME',pic:''},{av:'AV98TFNegInsUsuNome_Sel',fld:'vTFNEGINSUSUNOME_SEL',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV90IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV91IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV96IsAuthorized_NegAssunto',fld:'vISAUTHORIZED_NEGASSUNTO',pic:'',hsh:true},{av:'AV92IsAuthorized_NegPjtNome',fld:'vISAUTHORIZED_NEGPJTNOME',pic:'',hsh:true},{av:'AV95IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'",",oparms:[{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV24NegAssunto2',fld:'vNEGASSUNTO2',pic:'@!'},{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV28NegAssunto3',fld:'vNEGASSUNTO3',pic:'@!'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV20NegAssunto1',fld:'vNEGASSUNTO1',pic:'@!'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'edtavNegassunto2_Visible',ctrl:'vNEGASSUNTO2',prop:'Visible'},{av:'edtavNegassunto3_Visible',ctrl:'vNEGASSUNTO3',prop:'Visible'},{av:'edtavNegassunto1_Visible',ctrl:'vNEGASSUNTO1',prop:'Visible'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtNegCodigo_Visible',ctrl:'NEGCODIGO',prop:'Visible'},{av:'edtNegAssunto_Visible',ctrl:'NEGASSUNTO',prop:'Visible'},{av:'edtNegCliNomeFamiliar_Visible',ctrl:'NEGCLINOMEFAMILIAR',prop:'Visible'},{av:'edtNegCpjNomFan_Visible',ctrl:'NEGCPJNOMFAN',prop:'Visible'},{av:'edtNegCpjMatricula_Visible',ctrl:'NEGCPJMATRICULA',prop:'Visible'},{av:'edtNegPjtNome_Visible',ctrl:'NEGPJTNOME',prop:'Visible'},{av:'edtNegAgcNome_Visible',ctrl:'NEGAGCNOME',prop:'Visible'},{av:'edtNegValorAtualizado_Visible',ctrl:'NEGVALORATUALIZADO',prop:'Visible'},{av:'edtNegInsData_Visible',ctrl:'NEGINSDATA',prop:'Visible'},{av:'edtNegInsUsuNome_Visible',ctrl:'NEGINSUSUNOME',prop:'Visible'},{av:'AV86GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV87GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV88GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV90IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV91IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV95IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV38ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK","{handler:'E243X2',iparms:[{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK",",oparms:[{av:'edtavNegassunto1_Visible',ctrl:'vNEGASSUNTO1',prop:'Visible'},{av:'cmbavDynamicfiltersoperator1'}]}");
         setEventMetadata("'ADDDYNAMICFILTERS2'","{handler:'E253X2',iparms:[]");
         setEventMetadata("'ADDDYNAMICFILTERS2'",",oparms:[{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'","{handler:'E203X2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV20NegAssunto1',fld:'vNEGASSUNTO1',pic:'@!'},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV24NegAssunto2',fld:'vNEGASSUNTO2',pic:'@!'},{av:'cmbavDynamicfiltersselector3'},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV28NegAssunto3',fld:'vNEGASSUNTO3',pic:'@!'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV106Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV103NegDel',fld:'vNEGDEL',pic:''},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV41TFNegCodigo',fld:'vTFNEGCODIGO',pic:'ZZZZZZZZZZZ9'},{av:'AV42TFNegCodigo_To',fld:'vTFNEGCODIGO_TO',pic:'ZZZZZZZZZZZ9'},{av:'AV80TFNegAssunto',fld:'vTFNEGASSUNTO',pic:'@!'},{av:'AV81TFNegAssunto_Sel',fld:'vTFNEGASSUNTO_SEL',pic:'@!'},{av:'AV62TFNegCliNomeFamiliar',fld:'vTFNEGCLINOMEFAMILIAR',pic:'@!'},{av:'AV63TFNegCliNomeFamiliar_Sel',fld:'vTFNEGCLINOMEFAMILIAR_SEL',pic:'@!'},{av:'AV64TFNegCpjNomFan',fld:'vTFNEGCPJNOMFAN',pic:'@!'},{av:'AV65TFNegCpjNomFan_Sel',fld:'vTFNEGCPJNOMFAN_SEL',pic:'@!'},{av:'AV68TFNegCpjMatricula',fld:'vTFNEGCPJMATRICULA',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV69TFNegCpjMatricula_To',fld:'vTFNEGCPJMATRICULA_TO',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV74TFNegPjtNome',fld:'vTFNEGPJTNOME',pic:'@!'},{av:'AV75TFNegPjtNome_Sel',fld:'vTFNEGPJTNOME_SEL',pic:'@!'},{av:'AV78TFNegAgcNome',fld:'vTFNEGAGCNOME',pic:'@!'},{av:'AV79TFNegAgcNome_Sel',fld:'vTFNEGAGCNOME_SEL',pic:'@!'},{av:'AV99TFNegValorAtualizado',fld:'vTFNEGVALORATUALIZADO',pic:'R$ Z,ZZZ,ZZZ,ZZZ,ZZ9.99'},{av:'AV100TFNegValorAtualizado_To',fld:'vTFNEGVALORATUALIZADO_TO',pic:'R$ Z,ZZZ,ZZZ,ZZZ,ZZ9.99'},{av:'AV43TFNegInsData',fld:'vTFNEGINSDATA',pic:''},{av:'AV44TFNegInsData_To',fld:'vTFNEGINSDATA_TO',pic:''},{av:'AV97TFNegInsUsuNome',fld:'vTFNEGINSUSUNOME',pic:''},{av:'AV98TFNegInsUsuNome_Sel',fld:'vTFNEGINSUSUNOME_SEL',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV90IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV91IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV96IsAuthorized_NegAssunto',fld:'vISAUTHORIZED_NEGASSUNTO',pic:'',hsh:true},{av:'AV92IsAuthorized_NegPjtNome',fld:'vISAUTHORIZED_NEGPJTNOME',pic:'',hsh:true},{av:'AV95IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'",",oparms:[{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV24NegAssunto2',fld:'vNEGASSUNTO2',pic:'@!'},{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV28NegAssunto3',fld:'vNEGASSUNTO3',pic:'@!'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV20NegAssunto1',fld:'vNEGASSUNTO1',pic:'@!'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'edtavNegassunto2_Visible',ctrl:'vNEGASSUNTO2',prop:'Visible'},{av:'edtavNegassunto3_Visible',ctrl:'vNEGASSUNTO3',prop:'Visible'},{av:'edtavNegassunto1_Visible',ctrl:'vNEGASSUNTO1',prop:'Visible'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtNegCodigo_Visible',ctrl:'NEGCODIGO',prop:'Visible'},{av:'edtNegAssunto_Visible',ctrl:'NEGASSUNTO',prop:'Visible'},{av:'edtNegCliNomeFamiliar_Visible',ctrl:'NEGCLINOMEFAMILIAR',prop:'Visible'},{av:'edtNegCpjNomFan_Visible',ctrl:'NEGCPJNOMFAN',prop:'Visible'},{av:'edtNegCpjMatricula_Visible',ctrl:'NEGCPJMATRICULA',prop:'Visible'},{av:'edtNegPjtNome_Visible',ctrl:'NEGPJTNOME',prop:'Visible'},{av:'edtNegAgcNome_Visible',ctrl:'NEGAGCNOME',prop:'Visible'},{av:'edtNegValorAtualizado_Visible',ctrl:'NEGVALORATUALIZADO',prop:'Visible'},{av:'edtNegInsData_Visible',ctrl:'NEGINSDATA',prop:'Visible'},{av:'edtNegInsUsuNome_Visible',ctrl:'NEGINSUSUNOME',prop:'Visible'},{av:'AV86GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV87GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV88GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV90IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV91IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV95IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV38ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK","{handler:'E263X2',iparms:[{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK",",oparms:[{av:'edtavNegassunto2_Visible',ctrl:'vNEGASSUNTO2',prop:'Visible'},{av:'cmbavDynamicfiltersoperator2'}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'","{handler:'E213X2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV20NegAssunto1',fld:'vNEGASSUNTO1',pic:'@!'},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV24NegAssunto2',fld:'vNEGASSUNTO2',pic:'@!'},{av:'cmbavDynamicfiltersselector3'},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV28NegAssunto3',fld:'vNEGASSUNTO3',pic:'@!'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV106Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV103NegDel',fld:'vNEGDEL',pic:''},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV41TFNegCodigo',fld:'vTFNEGCODIGO',pic:'ZZZZZZZZZZZ9'},{av:'AV42TFNegCodigo_To',fld:'vTFNEGCODIGO_TO',pic:'ZZZZZZZZZZZ9'},{av:'AV80TFNegAssunto',fld:'vTFNEGASSUNTO',pic:'@!'},{av:'AV81TFNegAssunto_Sel',fld:'vTFNEGASSUNTO_SEL',pic:'@!'},{av:'AV62TFNegCliNomeFamiliar',fld:'vTFNEGCLINOMEFAMILIAR',pic:'@!'},{av:'AV63TFNegCliNomeFamiliar_Sel',fld:'vTFNEGCLINOMEFAMILIAR_SEL',pic:'@!'},{av:'AV64TFNegCpjNomFan',fld:'vTFNEGCPJNOMFAN',pic:'@!'},{av:'AV65TFNegCpjNomFan_Sel',fld:'vTFNEGCPJNOMFAN_SEL',pic:'@!'},{av:'AV68TFNegCpjMatricula',fld:'vTFNEGCPJMATRICULA',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV69TFNegCpjMatricula_To',fld:'vTFNEGCPJMATRICULA_TO',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV74TFNegPjtNome',fld:'vTFNEGPJTNOME',pic:'@!'},{av:'AV75TFNegPjtNome_Sel',fld:'vTFNEGPJTNOME_SEL',pic:'@!'},{av:'AV78TFNegAgcNome',fld:'vTFNEGAGCNOME',pic:'@!'},{av:'AV79TFNegAgcNome_Sel',fld:'vTFNEGAGCNOME_SEL',pic:'@!'},{av:'AV99TFNegValorAtualizado',fld:'vTFNEGVALORATUALIZADO',pic:'R$ Z,ZZZ,ZZZ,ZZZ,ZZ9.99'},{av:'AV100TFNegValorAtualizado_To',fld:'vTFNEGVALORATUALIZADO_TO',pic:'R$ Z,ZZZ,ZZZ,ZZZ,ZZ9.99'},{av:'AV43TFNegInsData',fld:'vTFNEGINSDATA',pic:''},{av:'AV44TFNegInsData_To',fld:'vTFNEGINSDATA_TO',pic:''},{av:'AV97TFNegInsUsuNome',fld:'vTFNEGINSUSUNOME',pic:''},{av:'AV98TFNegInsUsuNome_Sel',fld:'vTFNEGINSUSUNOME_SEL',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV90IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV91IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV96IsAuthorized_NegAssunto',fld:'vISAUTHORIZED_NEGASSUNTO',pic:'',hsh:true},{av:'AV92IsAuthorized_NegPjtNome',fld:'vISAUTHORIZED_NEGPJTNOME',pic:'',hsh:true},{av:'AV95IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'",",oparms:[{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV24NegAssunto2',fld:'vNEGASSUNTO2',pic:'@!'},{av:'cmbavDynamicfiltersselector3'},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV28NegAssunto3',fld:'vNEGASSUNTO3',pic:'@!'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV20NegAssunto1',fld:'vNEGASSUNTO1',pic:'@!'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'edtavNegassunto2_Visible',ctrl:'vNEGASSUNTO2',prop:'Visible'},{av:'edtavNegassunto3_Visible',ctrl:'vNEGASSUNTO3',prop:'Visible'},{av:'edtavNegassunto1_Visible',ctrl:'vNEGASSUNTO1',prop:'Visible'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtNegCodigo_Visible',ctrl:'NEGCODIGO',prop:'Visible'},{av:'edtNegAssunto_Visible',ctrl:'NEGASSUNTO',prop:'Visible'},{av:'edtNegCliNomeFamiliar_Visible',ctrl:'NEGCLINOMEFAMILIAR',prop:'Visible'},{av:'edtNegCpjNomFan_Visible',ctrl:'NEGCPJNOMFAN',prop:'Visible'},{av:'edtNegCpjMatricula_Visible',ctrl:'NEGCPJMATRICULA',prop:'Visible'},{av:'edtNegPjtNome_Visible',ctrl:'NEGPJTNOME',prop:'Visible'},{av:'edtNegAgcNome_Visible',ctrl:'NEGAGCNOME',prop:'Visible'},{av:'edtNegValorAtualizado_Visible',ctrl:'NEGVALORATUALIZADO',prop:'Visible'},{av:'edtNegInsData_Visible',ctrl:'NEGINSDATA',prop:'Visible'},{av:'edtNegInsUsuNome_Visible',ctrl:'NEGINSUSUNOME',prop:'Visible'},{av:'AV86GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV87GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV88GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV90IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV91IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV95IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV38ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK","{handler:'E273X2',iparms:[{av:'cmbavDynamicfiltersselector3'},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK",",oparms:[{av:'edtavNegassunto3_Visible',ctrl:'vNEGASSUNTO3',prop:'Visible'},{av:'cmbavDynamicfiltersoperator3'}]}");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","{handler:'E113X2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV20NegAssunto1',fld:'vNEGASSUNTO1',pic:'@!'},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV24NegAssunto2',fld:'vNEGASSUNTO2',pic:'@!'},{av:'cmbavDynamicfiltersselector3'},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV28NegAssunto3',fld:'vNEGASSUNTO3',pic:'@!'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV106Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV103NegDel',fld:'vNEGDEL',pic:''},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV41TFNegCodigo',fld:'vTFNEGCODIGO',pic:'ZZZZZZZZZZZ9'},{av:'AV42TFNegCodigo_To',fld:'vTFNEGCODIGO_TO',pic:'ZZZZZZZZZZZ9'},{av:'AV80TFNegAssunto',fld:'vTFNEGASSUNTO',pic:'@!'},{av:'AV81TFNegAssunto_Sel',fld:'vTFNEGASSUNTO_SEL',pic:'@!'},{av:'AV62TFNegCliNomeFamiliar',fld:'vTFNEGCLINOMEFAMILIAR',pic:'@!'},{av:'AV63TFNegCliNomeFamiliar_Sel',fld:'vTFNEGCLINOMEFAMILIAR_SEL',pic:'@!'},{av:'AV64TFNegCpjNomFan',fld:'vTFNEGCPJNOMFAN',pic:'@!'},{av:'AV65TFNegCpjNomFan_Sel',fld:'vTFNEGCPJNOMFAN_SEL',pic:'@!'},{av:'AV68TFNegCpjMatricula',fld:'vTFNEGCPJMATRICULA',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV69TFNegCpjMatricula_To',fld:'vTFNEGCPJMATRICULA_TO',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV74TFNegPjtNome',fld:'vTFNEGPJTNOME',pic:'@!'},{av:'AV75TFNegPjtNome_Sel',fld:'vTFNEGPJTNOME_SEL',pic:'@!'},{av:'AV78TFNegAgcNome',fld:'vTFNEGAGCNOME',pic:'@!'},{av:'AV79TFNegAgcNome_Sel',fld:'vTFNEGAGCNOME_SEL',pic:'@!'},{av:'AV99TFNegValorAtualizado',fld:'vTFNEGVALORATUALIZADO',pic:'R$ Z,ZZZ,ZZZ,ZZZ,ZZ9.99'},{av:'AV100TFNegValorAtualizado_To',fld:'vTFNEGVALORATUALIZADO_TO',pic:'R$ Z,ZZZ,ZZZ,ZZZ,ZZ9.99'},{av:'AV43TFNegInsData',fld:'vTFNEGINSDATA',pic:''},{av:'AV44TFNegInsData_To',fld:'vTFNEGINSDATA_TO',pic:''},{av:'AV97TFNegInsUsuNome',fld:'vTFNEGINSUSUNOME',pic:''},{av:'AV98TFNegInsUsuNome_Sel',fld:'vTFNEGINSUSUNOME_SEL',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV90IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV91IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV96IsAuthorized_NegAssunto',fld:'vISAUTHORIZED_NEGASSUNTO',pic:'',hsh:true},{av:'AV92IsAuthorized_NegPjtNome',fld:'vISAUTHORIZED_NEGPJTNOME',pic:'',hsh:true},{av:'AV95IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'Ddo_managefilters_Activeeventkey',ctrl:'DDO_MANAGEFILTERS',prop:'ActiveEventKey'}]");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",",oparms:[{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV103NegDel',fld:'vNEGDEL',pic:''},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV41TFNegCodigo',fld:'vTFNEGCODIGO',pic:'ZZZZZZZZZZZ9'},{av:'AV42TFNegCodigo_To',fld:'vTFNEGCODIGO_TO',pic:'ZZZZZZZZZZZ9'},{av:'AV80TFNegAssunto',fld:'vTFNEGASSUNTO',pic:'@!'},{av:'AV81TFNegAssunto_Sel',fld:'vTFNEGASSUNTO_SEL',pic:'@!'},{av:'AV62TFNegCliNomeFamiliar',fld:'vTFNEGCLINOMEFAMILIAR',pic:'@!'},{av:'AV63TFNegCliNomeFamiliar_Sel',fld:'vTFNEGCLINOMEFAMILIAR_SEL',pic:'@!'},{av:'AV64TFNegCpjNomFan',fld:'vTFNEGCPJNOMFAN',pic:'@!'},{av:'AV65TFNegCpjNomFan_Sel',fld:'vTFNEGCPJNOMFAN_SEL',pic:'@!'},{av:'AV68TFNegCpjMatricula',fld:'vTFNEGCPJMATRICULA',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV69TFNegCpjMatricula_To',fld:'vTFNEGCPJMATRICULA_TO',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV74TFNegPjtNome',fld:'vTFNEGPJTNOME',pic:'@!'},{av:'AV75TFNegPjtNome_Sel',fld:'vTFNEGPJTNOME_SEL',pic:'@!'},{av:'AV78TFNegAgcNome',fld:'vTFNEGAGCNOME',pic:'@!'},{av:'AV79TFNegAgcNome_Sel',fld:'vTFNEGAGCNOME_SEL',pic:'@!'},{av:'AV99TFNegValorAtualizado',fld:'vTFNEGVALORATUALIZADO',pic:'R$ Z,ZZZ,ZZZ,ZZZ,ZZ9.99'},{av:'AV100TFNegValorAtualizado_To',fld:'vTFNEGVALORATUALIZADO_TO',pic:'R$ Z,ZZZ,ZZZ,ZZZ,ZZ9.99'},{av:'AV43TFNegInsData',fld:'vTFNEGINSDATA',pic:''},{av:'AV44TFNegInsData_To',fld:'vTFNEGINSDATA_TO',pic:''},{av:'AV97TFNegInsUsuNome',fld:'vTFNEGINSUSUNOME',pic:''},{av:'AV98TFNegInsUsuNome_Sel',fld:'vTFNEGINSUSUNOME_SEL',pic:''},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV20NegAssunto1',fld:'vNEGASSUNTO1',pic:'@!'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV24NegAssunto2',fld:'vNEGASSUNTO2',pic:'@!'},{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV28NegAssunto3',fld:'vNEGASSUNTO3',pic:'@!'},{av:'edtavNegassunto1_Visible',ctrl:'vNEGASSUNTO1',prop:'Visible'},{av:'edtavNegassunto2_Visible',ctrl:'vNEGASSUNTO2',prop:'Visible'},{av:'edtavNegassunto3_Visible',ctrl:'vNEGASSUNTO3',prop:'Visible'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtNegCodigo_Visible',ctrl:'NEGCODIGO',prop:'Visible'},{av:'edtNegAssunto_Visible',ctrl:'NEGASSUNTO',prop:'Visible'},{av:'edtNegCliNomeFamiliar_Visible',ctrl:'NEGCLINOMEFAMILIAR',prop:'Visible'},{av:'edtNegCpjNomFan_Visible',ctrl:'NEGCPJNOMFAN',prop:'Visible'},{av:'edtNegCpjMatricula_Visible',ctrl:'NEGCPJMATRICULA',prop:'Visible'},{av:'edtNegPjtNome_Visible',ctrl:'NEGPJTNOME',prop:'Visible'},{av:'edtNegAgcNome_Visible',ctrl:'NEGAGCNOME',prop:'Visible'},{av:'edtNegValorAtualizado_Visible',ctrl:'NEGVALORATUALIZADO',prop:'Visible'},{av:'edtNegInsData_Visible',ctrl:'NEGINSDATA',prop:'Visible'},{av:'edtNegInsUsuNome_Visible',ctrl:'NEGINSUSUNOME',prop:'Visible'},{av:'AV86GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV87GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV88GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV90IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV91IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV95IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV38ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VGRIDACTIONS.CLICK","{handler:'E313X2',iparms:[{av:'cmbavGridactions'},{av:'AV89GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9'},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV20NegAssunto1',fld:'vNEGASSUNTO1',pic:'@!'},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV24NegAssunto2',fld:'vNEGASSUNTO2',pic:'@!'},{av:'cmbavDynamicfiltersselector3'},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV28NegAssunto3',fld:'vNEGASSUNTO3',pic:'@!'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV106Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV103NegDel',fld:'vNEGDEL',pic:''},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV41TFNegCodigo',fld:'vTFNEGCODIGO',pic:'ZZZZZZZZZZZ9'},{av:'AV42TFNegCodigo_To',fld:'vTFNEGCODIGO_TO',pic:'ZZZZZZZZZZZ9'},{av:'AV80TFNegAssunto',fld:'vTFNEGASSUNTO',pic:'@!'},{av:'AV81TFNegAssunto_Sel',fld:'vTFNEGASSUNTO_SEL',pic:'@!'},{av:'AV62TFNegCliNomeFamiliar',fld:'vTFNEGCLINOMEFAMILIAR',pic:'@!'},{av:'AV63TFNegCliNomeFamiliar_Sel',fld:'vTFNEGCLINOMEFAMILIAR_SEL',pic:'@!'},{av:'AV64TFNegCpjNomFan',fld:'vTFNEGCPJNOMFAN',pic:'@!'},{av:'AV65TFNegCpjNomFan_Sel',fld:'vTFNEGCPJNOMFAN_SEL',pic:'@!'},{av:'AV68TFNegCpjMatricula',fld:'vTFNEGCPJMATRICULA',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV69TFNegCpjMatricula_To',fld:'vTFNEGCPJMATRICULA_TO',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV74TFNegPjtNome',fld:'vTFNEGPJTNOME',pic:'@!'},{av:'AV75TFNegPjtNome_Sel',fld:'vTFNEGPJTNOME_SEL',pic:'@!'},{av:'AV78TFNegAgcNome',fld:'vTFNEGAGCNOME',pic:'@!'},{av:'AV79TFNegAgcNome_Sel',fld:'vTFNEGAGCNOME_SEL',pic:'@!'},{av:'AV99TFNegValorAtualizado',fld:'vTFNEGVALORATUALIZADO',pic:'R$ Z,ZZZ,ZZZ,ZZZ,ZZ9.99'},{av:'AV100TFNegValorAtualizado_To',fld:'vTFNEGVALORATUALIZADO_TO',pic:'R$ Z,ZZZ,ZZZ,ZZZ,ZZ9.99'},{av:'AV43TFNegInsData',fld:'vTFNEGINSDATA',pic:''},{av:'AV44TFNegInsData_To',fld:'vTFNEGINSDATA_TO',pic:''},{av:'AV97TFNegInsUsuNome',fld:'vTFNEGINSUSUNOME',pic:''},{av:'AV98TFNegInsUsuNome_Sel',fld:'vTFNEGINSUSUNOME_SEL',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV90IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV91IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV96IsAuthorized_NegAssunto',fld:'vISAUTHORIZED_NEGASSUNTO',pic:'',hsh:true},{av:'AV92IsAuthorized_NegPjtNome',fld:'vISAUTHORIZED_NEGPJTNOME',pic:'',hsh:true},{av:'AV95IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'A345NegID',fld:'NEGID',pic:'',hsh:true}]");
         setEventMetadata("VGRIDACTIONS.CLICK",",oparms:[{av:'cmbavGridactions'},{av:'AV89GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9'},{av:'AV104NegID_Selected',fld:'vNEGID_SELECTED',pic:''},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtNegCodigo_Visible',ctrl:'NEGCODIGO',prop:'Visible'},{av:'edtNegAssunto_Visible',ctrl:'NEGASSUNTO',prop:'Visible'},{av:'edtNegCliNomeFamiliar_Visible',ctrl:'NEGCLINOMEFAMILIAR',prop:'Visible'},{av:'edtNegCpjNomFan_Visible',ctrl:'NEGCPJNOMFAN',prop:'Visible'},{av:'edtNegCpjMatricula_Visible',ctrl:'NEGCPJMATRICULA',prop:'Visible'},{av:'edtNegPjtNome_Visible',ctrl:'NEGPJTNOME',prop:'Visible'},{av:'edtNegAgcNome_Visible',ctrl:'NEGAGCNOME',prop:'Visible'},{av:'edtNegValorAtualizado_Visible',ctrl:'NEGVALORATUALIZADO',prop:'Visible'},{av:'edtNegInsData_Visible',ctrl:'NEGINSDATA',prop:'Visible'},{av:'edtNegInsUsuNome_Visible',ctrl:'NEGINSUSUNOME',prop:'Visible'},{av:'AV86GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV87GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV88GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV90IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV91IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV95IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV38ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("DVELOP_CONFIRMPANEL_DELETE.CLOSE","{handler:'E183X2',iparms:[{av:'Dvelop_confirmpanel_delete_Result',ctrl:'DVELOP_CONFIRMPANEL_DELETE',prop:'Result'},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV20NegAssunto1',fld:'vNEGASSUNTO1',pic:'@!'},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV24NegAssunto2',fld:'vNEGASSUNTO2',pic:'@!'},{av:'cmbavDynamicfiltersselector3'},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV28NegAssunto3',fld:'vNEGASSUNTO3',pic:'@!'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV106Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV103NegDel',fld:'vNEGDEL',pic:''},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV41TFNegCodigo',fld:'vTFNEGCODIGO',pic:'ZZZZZZZZZZZ9'},{av:'AV42TFNegCodigo_To',fld:'vTFNEGCODIGO_TO',pic:'ZZZZZZZZZZZ9'},{av:'AV80TFNegAssunto',fld:'vTFNEGASSUNTO',pic:'@!'},{av:'AV81TFNegAssunto_Sel',fld:'vTFNEGASSUNTO_SEL',pic:'@!'},{av:'AV62TFNegCliNomeFamiliar',fld:'vTFNEGCLINOMEFAMILIAR',pic:'@!'},{av:'AV63TFNegCliNomeFamiliar_Sel',fld:'vTFNEGCLINOMEFAMILIAR_SEL',pic:'@!'},{av:'AV64TFNegCpjNomFan',fld:'vTFNEGCPJNOMFAN',pic:'@!'},{av:'AV65TFNegCpjNomFan_Sel',fld:'vTFNEGCPJNOMFAN_SEL',pic:'@!'},{av:'AV68TFNegCpjMatricula',fld:'vTFNEGCPJMATRICULA',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV69TFNegCpjMatricula_To',fld:'vTFNEGCPJMATRICULA_TO',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV74TFNegPjtNome',fld:'vTFNEGPJTNOME',pic:'@!'},{av:'AV75TFNegPjtNome_Sel',fld:'vTFNEGPJTNOME_SEL',pic:'@!'},{av:'AV78TFNegAgcNome',fld:'vTFNEGAGCNOME',pic:'@!'},{av:'AV79TFNegAgcNome_Sel',fld:'vTFNEGAGCNOME_SEL',pic:'@!'},{av:'AV99TFNegValorAtualizado',fld:'vTFNEGVALORATUALIZADO',pic:'R$ Z,ZZZ,ZZZ,ZZZ,ZZ9.99'},{av:'AV100TFNegValorAtualizado_To',fld:'vTFNEGVALORATUALIZADO_TO',pic:'R$ Z,ZZZ,ZZZ,ZZZ,ZZ9.99'},{av:'AV43TFNegInsData',fld:'vTFNEGINSDATA',pic:''},{av:'AV44TFNegInsData_To',fld:'vTFNEGINSDATA_TO',pic:''},{av:'AV97TFNegInsUsuNome',fld:'vTFNEGINSUSUNOME',pic:''},{av:'AV98TFNegInsUsuNome_Sel',fld:'vTFNEGINSUSUNOME_SEL',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV90IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV91IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV96IsAuthorized_NegAssunto',fld:'vISAUTHORIZED_NEGASSUNTO',pic:'',hsh:true},{av:'AV92IsAuthorized_NegPjtNome',fld:'vISAUTHORIZED_NEGPJTNOME',pic:'',hsh:true},{av:'AV95IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'AV104NegID_Selected',fld:'vNEGID_SELECTED',pic:''}]");
         setEventMetadata("DVELOP_CONFIRMPANEL_DELETE.CLOSE",",oparms:[{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtNegCodigo_Visible',ctrl:'NEGCODIGO',prop:'Visible'},{av:'edtNegAssunto_Visible',ctrl:'NEGASSUNTO',prop:'Visible'},{av:'edtNegCliNomeFamiliar_Visible',ctrl:'NEGCLINOMEFAMILIAR',prop:'Visible'},{av:'edtNegCpjNomFan_Visible',ctrl:'NEGCPJNOMFAN',prop:'Visible'},{av:'edtNegCpjMatricula_Visible',ctrl:'NEGCPJMATRICULA',prop:'Visible'},{av:'edtNegPjtNome_Visible',ctrl:'NEGPJTNOME',prop:'Visible'},{av:'edtNegAgcNome_Visible',ctrl:'NEGAGCNOME',prop:'Visible'},{av:'edtNegValorAtualizado_Visible',ctrl:'NEGVALORATUALIZADO',prop:'Visible'},{av:'edtNegInsData_Visible',ctrl:'NEGINSDATA',prop:'Visible'},{av:'edtNegInsUsuNome_Visible',ctrl:'NEGINSUSUNOME',prop:'Visible'},{av:'AV86GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV87GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV88GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV90IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV91IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV95IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV38ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("'DOINSERT'","{handler:'E223X2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV20NegAssunto1',fld:'vNEGASSUNTO1',pic:'@!'},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV24NegAssunto2',fld:'vNEGASSUNTO2',pic:'@!'},{av:'cmbavDynamicfiltersselector3'},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV28NegAssunto3',fld:'vNEGASSUNTO3',pic:'@!'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV106Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV103NegDel',fld:'vNEGDEL',pic:''},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV41TFNegCodigo',fld:'vTFNEGCODIGO',pic:'ZZZZZZZZZZZ9'},{av:'AV42TFNegCodigo_To',fld:'vTFNEGCODIGO_TO',pic:'ZZZZZZZZZZZ9'},{av:'AV80TFNegAssunto',fld:'vTFNEGASSUNTO',pic:'@!'},{av:'AV81TFNegAssunto_Sel',fld:'vTFNEGASSUNTO_SEL',pic:'@!'},{av:'AV62TFNegCliNomeFamiliar',fld:'vTFNEGCLINOMEFAMILIAR',pic:'@!'},{av:'AV63TFNegCliNomeFamiliar_Sel',fld:'vTFNEGCLINOMEFAMILIAR_SEL',pic:'@!'},{av:'AV64TFNegCpjNomFan',fld:'vTFNEGCPJNOMFAN',pic:'@!'},{av:'AV65TFNegCpjNomFan_Sel',fld:'vTFNEGCPJNOMFAN_SEL',pic:'@!'},{av:'AV68TFNegCpjMatricula',fld:'vTFNEGCPJMATRICULA',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV69TFNegCpjMatricula_To',fld:'vTFNEGCPJMATRICULA_TO',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV74TFNegPjtNome',fld:'vTFNEGPJTNOME',pic:'@!'},{av:'AV75TFNegPjtNome_Sel',fld:'vTFNEGPJTNOME_SEL',pic:'@!'},{av:'AV78TFNegAgcNome',fld:'vTFNEGAGCNOME',pic:'@!'},{av:'AV79TFNegAgcNome_Sel',fld:'vTFNEGAGCNOME_SEL',pic:'@!'},{av:'AV99TFNegValorAtualizado',fld:'vTFNEGVALORATUALIZADO',pic:'R$ Z,ZZZ,ZZZ,ZZZ,ZZ9.99'},{av:'AV100TFNegValorAtualizado_To',fld:'vTFNEGVALORATUALIZADO_TO',pic:'R$ Z,ZZZ,ZZZ,ZZZ,ZZ9.99'},{av:'AV43TFNegInsData',fld:'vTFNEGINSDATA',pic:''},{av:'AV44TFNegInsData_To',fld:'vTFNEGINSDATA_TO',pic:''},{av:'AV97TFNegInsUsuNome',fld:'vTFNEGINSUSUNOME',pic:''},{av:'AV98TFNegInsUsuNome_Sel',fld:'vTFNEGINSUSUNOME_SEL',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV90IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV91IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV96IsAuthorized_NegAssunto',fld:'vISAUTHORIZED_NEGASSUNTO',pic:'',hsh:true},{av:'AV92IsAuthorized_NegPjtNome',fld:'vISAUTHORIZED_NEGPJTNOME',pic:'',hsh:true},{av:'AV95IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'A345NegID',fld:'NEGID',pic:'',hsh:true}]");
         setEventMetadata("'DOINSERT'",",oparms:[{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtNegCodigo_Visible',ctrl:'NEGCODIGO',prop:'Visible'},{av:'edtNegAssunto_Visible',ctrl:'NEGASSUNTO',prop:'Visible'},{av:'edtNegCliNomeFamiliar_Visible',ctrl:'NEGCLINOMEFAMILIAR',prop:'Visible'},{av:'edtNegCpjNomFan_Visible',ctrl:'NEGCPJNOMFAN',prop:'Visible'},{av:'edtNegCpjMatricula_Visible',ctrl:'NEGCPJMATRICULA',prop:'Visible'},{av:'edtNegPjtNome_Visible',ctrl:'NEGPJTNOME',prop:'Visible'},{av:'edtNegAgcNome_Visible',ctrl:'NEGAGCNOME',prop:'Visible'},{av:'edtNegValorAtualizado_Visible',ctrl:'NEGVALORATUALIZADO',prop:'Visible'},{av:'edtNegInsData_Visible',ctrl:'NEGINSDATA',prop:'Visible'},{av:'edtNegInsUsuNome_Visible',ctrl:'NEGINSUSUNOME',prop:'Visible'},{av:'AV86GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV87GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV88GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV90IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV91IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV95IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV38ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED","{handler:'E143X2',iparms:[{av:'Ddo_agexport_Activeeventkey',ctrl:'DDO_AGEXPORT',prop:'ActiveEventKey'},{av:'AV106Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV81TFNegAssunto_Sel',fld:'vTFNEGASSUNTO_SEL',pic:'@!'},{av:'AV63TFNegCliNomeFamiliar_Sel',fld:'vTFNEGCLINOMEFAMILIAR_SEL',pic:'@!'},{av:'AV65TFNegCpjNomFan_Sel',fld:'vTFNEGCPJNOMFAN_SEL',pic:'@!'},{av:'AV75TFNegPjtNome_Sel',fld:'vTFNEGPJTNOME_SEL',pic:'@!'},{av:'AV79TFNegAgcNome_Sel',fld:'vTFNEGAGCNOME_SEL',pic:'@!'},{av:'AV98TFNegInsUsuNome_Sel',fld:'vTFNEGINSUSUNOME_SEL',pic:''},{av:'AV41TFNegCodigo',fld:'vTFNEGCODIGO',pic:'ZZZZZZZZZZZ9'},{av:'AV80TFNegAssunto',fld:'vTFNEGASSUNTO',pic:'@!'},{av:'AV62TFNegCliNomeFamiliar',fld:'vTFNEGCLINOMEFAMILIAR',pic:'@!'},{av:'AV64TFNegCpjNomFan',fld:'vTFNEGCPJNOMFAN',pic:'@!'},{av:'AV68TFNegCpjMatricula',fld:'vTFNEGCPJMATRICULA',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV74TFNegPjtNome',fld:'vTFNEGPJTNOME',pic:'@!'},{av:'AV78TFNegAgcNome',fld:'vTFNEGAGCNOME',pic:'@!'},{av:'AV99TFNegValorAtualizado',fld:'vTFNEGVALORATUALIZADO',pic:'R$ Z,ZZZ,ZZZ,ZZZ,ZZ9.99'},{av:'AV43TFNegInsData',fld:'vTFNEGINSDATA',pic:''},{av:'AV97TFNegInsUsuNome',fld:'vTFNEGINSUSUNOME',pic:''},{av:'AV42TFNegCodigo_To',fld:'vTFNEGCODIGO_TO',pic:'ZZZZZZZZZZZ9'},{av:'AV69TFNegCpjMatricula_To',fld:'vTFNEGCPJMATRICULA_TO',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV100TFNegValorAtualizado_To',fld:'vTFNEGVALORATUALIZADO_TO',pic:'R$ Z,ZZZ,ZZZ,ZZZ,ZZ9.99'},{av:'AV44TFNegInsData_To',fld:'vTFNEGINSDATA_TO',pic:''},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''}]");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED",",oparms:[{av:'Innewwindow1_Target',ctrl:'INNEWWINDOW1',prop:'Target'},{av:'Innewwindow1_Height',ctrl:'INNEWWINDOW1',prop:'Height'},{av:'Innewwindow1_Width',ctrl:'INNEWWINDOW1',prop:'Width'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV20NegAssunto1',fld:'vNEGASSUNTO1',pic:'@!'},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV24NegAssunto2',fld:'vNEGASSUNTO2',pic:'@!'},{av:'cmbavDynamicfiltersselector3'},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV28NegAssunto3',fld:'vNEGASSUNTO3',pic:'@!'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV106Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV103NegDel',fld:'vNEGDEL',pic:''},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV41TFNegCodigo',fld:'vTFNEGCODIGO',pic:'ZZZZZZZZZZZ9'},{av:'AV42TFNegCodigo_To',fld:'vTFNEGCODIGO_TO',pic:'ZZZZZZZZZZZ9'},{av:'AV80TFNegAssunto',fld:'vTFNEGASSUNTO',pic:'@!'},{av:'AV81TFNegAssunto_Sel',fld:'vTFNEGASSUNTO_SEL',pic:'@!'},{av:'AV62TFNegCliNomeFamiliar',fld:'vTFNEGCLINOMEFAMILIAR',pic:'@!'},{av:'AV63TFNegCliNomeFamiliar_Sel',fld:'vTFNEGCLINOMEFAMILIAR_SEL',pic:'@!'},{av:'AV64TFNegCpjNomFan',fld:'vTFNEGCPJNOMFAN',pic:'@!'},{av:'AV65TFNegCpjNomFan_Sel',fld:'vTFNEGCPJNOMFAN_SEL',pic:'@!'},{av:'AV68TFNegCpjMatricula',fld:'vTFNEGCPJMATRICULA',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV69TFNegCpjMatricula_To',fld:'vTFNEGCPJMATRICULA_TO',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV74TFNegPjtNome',fld:'vTFNEGPJTNOME',pic:'@!'},{av:'AV75TFNegPjtNome_Sel',fld:'vTFNEGPJTNOME_SEL',pic:'@!'},{av:'AV78TFNegAgcNome',fld:'vTFNEGAGCNOME',pic:'@!'},{av:'AV79TFNegAgcNome_Sel',fld:'vTFNEGAGCNOME_SEL',pic:'@!'},{av:'AV99TFNegValorAtualizado',fld:'vTFNEGVALORATUALIZADO',pic:'R$ Z,ZZZ,ZZZ,ZZZ,ZZ9.99'},{av:'AV100TFNegValorAtualizado_To',fld:'vTFNEGVALORATUALIZADO_TO',pic:'R$ Z,ZZZ,ZZZ,ZZZ,ZZ9.99'},{av:'AV43TFNegInsData',fld:'vTFNEGINSDATA',pic:''},{av:'AV44TFNegInsData_To',fld:'vTFNEGINSDATA_TO',pic:''},{av:'AV97TFNegInsUsuNome',fld:'vTFNEGINSUSUNOME',pic:''},{av:'AV98TFNegInsUsuNome_Sel',fld:'vTFNEGINSUSUNOME_SEL',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV90IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV91IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV96IsAuthorized_NegAssunto',fld:'vISAUTHORIZED_NEGASSUNTO',pic:'',hsh:true},{av:'AV92IsAuthorized_NegPjtNome',fld:'vISAUTHORIZED_NEGPJTNOME',pic:'',hsh:true},{av:'AV95IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'edtavNegassunto1_Visible',ctrl:'vNEGASSUNTO1',prop:'Visible'},{av:'edtavNegassunto2_Visible',ctrl:'vNEGASSUNTO2',prop:'Visible'},{av:'edtavNegassunto3_Visible',ctrl:'vNEGASSUNTO3',prop:'Visible'}]}");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT","{handler:'E153X2',iparms:[]");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT",",oparms:[{ctrl:'WWPAUX_WC'}]}");
         setEventMetadata("VALID_NEGCLIID","{handler:'Valid_Negcliid',iparms:[]");
         setEventMetadata("VALID_NEGCLIID",",oparms:[]}");
         setEventMetadata("VALID_NEGCPJID","{handler:'Valid_Negcpjid',iparms:[]");
         setEventMetadata("VALID_NEGCPJID",",oparms:[]}");
         setEventMetadata("VALID_NEGPJTID","{handler:'Valid_Negpjtid',iparms:[]");
         setEventMetadata("VALID_NEGPJTID",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Neginsusunome',iparms:[]");
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
         Dvelop_confirmpanel_delete_Result = "";
         Ddo_agexport_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV17FilterFullText = "";
         AV18DynamicFiltersSelector1 = "";
         AV20NegAssunto1 = "";
         AV22DynamicFiltersSelector2 = "";
         AV24NegAssunto2 = "";
         AV26DynamicFiltersSelector3 = "";
         AV28NegAssunto3 = "";
         AV35ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV106Pgmname = "";
         AV80TFNegAssunto = "";
         AV81TFNegAssunto_Sel = "";
         AV62TFNegCliNomeFamiliar = "";
         AV63TFNegCliNomeFamiliar_Sel = "";
         AV64TFNegCpjNomFan = "";
         AV65TFNegCpjNomFan_Sel = "";
         AV74TFNegPjtNome = "";
         AV75TFNegPjtNome_Sel = "";
         AV78TFNegAgcNome = "";
         AV79TFNegAgcNome_Sel = "";
         AV43TFNegInsData = DateTime.MinValue;
         AV44TFNegInsData_To = DateTime.MinValue;
         AV97TFNegInsUsuNome = "";
         AV98TFNegInsUsuNome_Sel = "";
         AV11GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV38ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV88GridAppliedFilters = "";
         AV93AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV82DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV45DDO_NegInsDataAuxDate = DateTime.MinValue;
         AV46DDO_NegInsDataAuxDateTo = DateTime.MinValue;
         AV104NegID_Selected = Guid.Empty;
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
         bttBtninsert_Jsonclick = "";
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
         ucDdo_agexport = new GXUserControl();
         ucDdc_subscriptions = new GXUserControl();
         lblJsdynamicfilters_Jsonclick = "";
         ucDdo_grid = new GXUserControl();
         ucInnewwindow1 = new GXUserControl();
         ucDdo_gridcolumnsselector = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         WebComp_Wwpaux_wc_Component = "";
         OldWwpaux_wc = "";
         AV47DDO_NegInsDataAuxDateText = "";
         ucTfneginsdata_rangepicker = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A345NegID = Guid.Empty;
         A347NegInsHora = (DateTime)(DateTime.MinValue);
         A348NegInsDataHora = (DateTime)(DateTime.MinValue);
         A349NegInsUsuID = "";
         A362NegAssunto = "";
         A350NegCliID = Guid.Empty;
         A351NegCliNomeFamiliar = "";
         A352NegCpjID = Guid.Empty;
         A353NegCpjNomFan = "";
         A354NegCpjRazSocial = "";
         A358NegPjtSigla = "";
         A359NegPjtNome = "";
         A360NegAgcID = "";
         A361NegAgcNome = "";
         A346NegInsData = DateTime.MinValue;
         A364NegInsUsuNome = "";
         scmdbuf = "";
         lV108Core_negociopjwwds_2_filterfulltext = "";
         lV111Core_negociopjwwds_5_negassunto1 = "";
         lV115Core_negociopjwwds_9_negassunto2 = "";
         lV119Core_negociopjwwds_13_negassunto3 = "";
         lV122Core_negociopjwwds_16_tfnegassunto = "";
         lV124Core_negociopjwwds_18_tfnegclinomefamiliar = "";
         lV126Core_negociopjwwds_20_tfnegcpjnomfan = "";
         lV130Core_negociopjwwds_24_tfnegpjtnome = "";
         lV132Core_negociopjwwds_26_tfnegagcnome = "";
         lV138Core_negociopjwwds_32_tfneginsusunome = "";
         AV108Core_negociopjwwds_2_filterfulltext = "";
         AV109Core_negociopjwwds_3_dynamicfiltersselector1 = "";
         AV111Core_negociopjwwds_5_negassunto1 = "";
         AV113Core_negociopjwwds_7_dynamicfiltersselector2 = "";
         AV115Core_negociopjwwds_9_negassunto2 = "";
         AV117Core_negociopjwwds_11_dynamicfiltersselector3 = "";
         AV119Core_negociopjwwds_13_negassunto3 = "";
         AV123Core_negociopjwwds_17_tfnegassunto_sel = "";
         AV122Core_negociopjwwds_16_tfnegassunto = "";
         AV125Core_negociopjwwds_19_tfnegclinomefamiliar_sel = "";
         AV124Core_negociopjwwds_18_tfnegclinomefamiliar = "";
         AV127Core_negociopjwwds_21_tfnegcpjnomfan_sel = "";
         AV126Core_negociopjwwds_20_tfnegcpjnomfan = "";
         AV131Core_negociopjwwds_25_tfnegpjtnome_sel = "";
         AV130Core_negociopjwwds_24_tfnegpjtnome = "";
         AV133Core_negociopjwwds_27_tfnegagcnome_sel = "";
         AV132Core_negociopjwwds_26_tfnegagcnome = "";
         AV136Core_negociopjwwds_30_tfneginsdata = DateTime.MinValue;
         AV137Core_negociopjwwds_31_tfneginsdata_to = DateTime.MinValue;
         AV139Core_negociopjwwds_33_tfneginsusunome_sel = "";
         AV138Core_negociopjwwds_32_tfneginsusunome = "";
         H003X2_A572NegDel = new bool[] {false} ;
         H003X2_A364NegInsUsuNome = new string[] {""} ;
         H003X2_n364NegInsUsuNome = new bool[] {false} ;
         H003X2_A346NegInsData = new DateTime[] {DateTime.MinValue} ;
         H003X2_A385NegValorAtualizado = new decimal[1] ;
         H003X2_A361NegAgcNome = new string[] {""} ;
         H003X2_n361NegAgcNome = new bool[] {false} ;
         H003X2_A360NegAgcID = new string[] {""} ;
         H003X2_n360NegAgcID = new bool[] {false} ;
         H003X2_A359NegPjtNome = new string[] {""} ;
         H003X2_A358NegPjtSigla = new string[] {""} ;
         H003X2_A357NegPjtID = new int[1] ;
         H003X2_A355NegCpjMatricula = new long[1] ;
         H003X2_A354NegCpjRazSocial = new string[] {""} ;
         H003X2_A353NegCpjNomFan = new string[] {""} ;
         H003X2_A352NegCpjID = new Guid[] {Guid.Empty} ;
         H003X2_A351NegCliNomeFamiliar = new string[] {""} ;
         H003X2_A350NegCliID = new Guid[] {Guid.Empty} ;
         H003X2_A362NegAssunto = new string[] {""} ;
         H003X2_A349NegInsUsuID = new string[] {""} ;
         H003X2_n349NegInsUsuID = new bool[] {false} ;
         H003X2_A348NegInsDataHora = new DateTime[] {DateTime.MinValue} ;
         H003X2_A347NegInsHora = new DateTime[] {DateTime.MinValue} ;
         H003X2_A356NegCodigo = new long[1] ;
         H003X2_A345NegID = new Guid[] {Guid.Empty} ;
         H003X3_AGRID_nRecordCount = new long[1] ;
         AV8HTTPRequest = new GxHttpRequest( context);
         imgAdddynamicfilters1_Jsonclick = "";
         imgRemovedynamicfilters1_Jsonclick = "";
         imgAdddynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters3_Jsonclick = "";
         AV94AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV83GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV84GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV37Session = context.GetSession();
         AV33ColumnsSelectorXML = "";
         GXEncryptionTmp = "";
         GridRow = new GXWebRow();
         AV39ManageFiltersXml = "";
         AV34UserCustomValue = "";
         AV36ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV105sdtNegocioPJ = new GeneXus.Programs.core.SdtsdtNegocioPJ(context);
         AV102Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV101Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV12GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char9 = "";
         GXt_char8 = "";
         GXt_char7 = "";
         GXt_char6 = "";
         GXt_char5 = "";
         GXt_char3 = "";
         AV13GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV31ExcelFilename = "";
         AV32ErrorMessage = "";
         ucDvelop_confirmpanel_delete = new GXUserControl();
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
         GXCCtl = "";
         ROClassString = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.negociopjww__default(),
            new Object[][] {
                new Object[] {
               H003X2_A572NegDel, H003X2_A364NegInsUsuNome, H003X2_n364NegInsUsuNome, H003X2_A346NegInsData, H003X2_A385NegValorAtualizado, H003X2_A361NegAgcNome, H003X2_n361NegAgcNome, H003X2_A360NegAgcID, H003X2_n360NegAgcID, H003X2_A359NegPjtNome,
               H003X2_A358NegPjtSigla, H003X2_A357NegPjtID, H003X2_A355NegCpjMatricula, H003X2_A354NegCpjRazSocial, H003X2_A353NegCpjNomFan, H003X2_A352NegCpjID, H003X2_A351NegCliNomeFamiliar, H003X2_A350NegCliID, H003X2_A362NegAssunto, H003X2_A349NegInsUsuID,
               H003X2_n349NegInsUsuID, H003X2_A348NegInsDataHora, H003X2_A347NegInsHora, H003X2_A356NegCodigo, H003X2_A345NegID
               }
               , new Object[] {
               H003X3_AGRID_nRecordCount
               }
            }
         );
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         AV106Pgmname = "core.NegocioPJWW";
         /* GeneXus formulas. */
         AV106Pgmname = "core.NegocioPJWW";
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV19DynamicFiltersOperator1 ;
      private short AV23DynamicFiltersOperator2 ;
      private short AV27DynamicFiltersOperator3 ;
      private short AV40ManageFiltersExecutionStep ;
      private short AV14OrderedBy ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV89GridActions ;
      private short nCmpId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short AV110Core_negociopjwwds_4_dynamicfiltersoperator1 ;
      private short AV114Core_negociopjwwds_8_dynamicfiltersoperator2 ;
      private short AV118Core_negociopjwwds_12_dynamicfiltersoperator3 ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_115 ;
      private int nGXsfl_115_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int bttBtninsert_Visible ;
      private int bttBtnsubscriptions_Visible ;
      private int A357NegPjtID ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtNegCodigo_Visible ;
      private int edtNegAssunto_Visible ;
      private int edtNegCliNomeFamiliar_Visible ;
      private int edtNegCpjNomFan_Visible ;
      private int edtNegCpjMatricula_Visible ;
      private int edtNegPjtNome_Visible ;
      private int edtNegAgcNome_Visible ;
      private int edtNegValorAtualizado_Visible ;
      private int edtNegInsData_Visible ;
      private int edtNegInsUsuNome_Visible ;
      private int AV85PageToGo ;
      private int imgAdddynamicfilters1_Visible ;
      private int imgRemovedynamicfilters1_Visible ;
      private int imgAdddynamicfilters2_Visible ;
      private int imgRemovedynamicfilters2_Visible ;
      private int edtavNegassunto1_Visible ;
      private int edtavNegassunto2_Visible ;
      private int edtavNegassunto3_Visible ;
      private int AV140GXV1 ;
      private int AV141GXV2 ;
      private int edtavNegassunto3_Enabled ;
      private int edtavNegassunto2_Enabled ;
      private int edtavNegassunto1_Enabled ;
      private int edtavFilterfulltext_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV41TFNegCodigo ;
      private long AV42TFNegCodigo_To ;
      private long AV68TFNegCpjMatricula ;
      private long AV69TFNegCpjMatricula_To ;
      private long AV86GridCurrentPage ;
      private long AV87GridPageCount ;
      private long A356NegCodigo ;
      private long A355NegCpjMatricula ;
      private long GRID_nCurrentRecord ;
      private long AV120Core_negociopjwwds_14_tfnegcodigo ;
      private long AV121Core_negociopjwwds_15_tfnegcodigo_to ;
      private long AV128Core_negociopjwwds_22_tfnegcpjmatricula ;
      private long AV129Core_negociopjwwds_23_tfnegcpjmatricula_to ;
      private long GRID_nRecordCount ;
      private decimal AV99TFNegValorAtualizado ;
      private decimal AV100TFNegValorAtualizado_To ;
      private decimal A385NegValorAtualizado ;
      private decimal AV134Core_negociopjwwds_28_tfnegvaloratualizado ;
      private decimal AV135Core_negociopjwwds_29_tfnegvaloratualizado_to ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_gridcolumnsselector_Columnsselectorvalues ;
      private string Ddo_managefilters_Activeeventkey ;
      private string Dvelop_confirmpanel_delete_Result ;
      private string Ddo_agexport_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_115_idx="0001" ;
      private string AV106Pgmname ;
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
      private string Ddo_grid_Format ;
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
      private string Dvelop_confirmpanel_delete_Title ;
      private string Dvelop_confirmpanel_delete_Confirmationtext ;
      private string Dvelop_confirmpanel_delete_Yesbuttoncaption ;
      private string Dvelop_confirmpanel_delete_Nobuttoncaption ;
      private string Dvelop_confirmpanel_delete_Cancelbuttoncaption ;
      private string Dvelop_confirmpanel_delete_Yesbuttonposition ;
      private string Dvelop_confirmpanel_delete_Confirmtype ;
      private string Grid_empowerer_Gridinternalname ;
      private string Grid_empowerer_Fixedcolumns ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string chkavNegdel_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string divTableheader_Internalname ;
      private string divTableheadercontent_Internalname ;
      private string divTableactions_Internalname ;
      private string bttBtninsert_Internalname ;
      private string bttBtninsert_Jsonclick ;
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
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Ddo_agexport_Internalname ;
      private string Ddc_subscriptions_Internalname ;
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
      private string divDdo_neginsdataauxdates_Internalname ;
      private string edtavDdo_neginsdataauxdatetext_Internalname ;
      private string edtavDdo_neginsdataauxdatetext_Jsonclick ;
      private string Tfneginsdata_rangepicker_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string cmbavGridactions_Internalname ;
      private string edtNegID_Internalname ;
      private string edtNegCodigo_Internalname ;
      private string edtNegInsHora_Internalname ;
      private string edtNegInsDataHora_Internalname ;
      private string A349NegInsUsuID ;
      private string edtNegInsUsuID_Internalname ;
      private string edtNegAssunto_Internalname ;
      private string edtNegCliID_Internalname ;
      private string edtNegCliNomeFamiliar_Internalname ;
      private string edtNegCpjID_Internalname ;
      private string edtNegCpjNomFan_Internalname ;
      private string edtNegCpjRazSocial_Internalname ;
      private string edtNegCpjMatricula_Internalname ;
      private string edtNegPjtID_Internalname ;
      private string edtNegPjtSigla_Internalname ;
      private string edtNegPjtNome_Internalname ;
      private string A360NegAgcID ;
      private string edtNegAgcID_Internalname ;
      private string edtNegAgcNome_Internalname ;
      private string edtNegValorAtualizado_Internalname ;
      private string edtNegInsData_Internalname ;
      private string edtNegInsUsuNome_Internalname ;
      private string cmbavDynamicfiltersoperator1_Internalname ;
      private string cmbavDynamicfiltersoperator2_Internalname ;
      private string cmbavDynamicfiltersoperator3_Internalname ;
      private string scmdbuf ;
      private string edtavFilterfulltext_Internalname ;
      private string edtavNegassunto1_Internalname ;
      private string edtavNegassunto2_Internalname ;
      private string edtavNegassunto3_Internalname ;
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
      private string cmbavGridactions_Class ;
      private string edtNegAssunto_Link ;
      private string GXEncryptionTmp ;
      private string edtNegPjtNome_Link ;
      private string GXt_char9 ;
      private string GXt_char8 ;
      private string GXt_char7 ;
      private string GXt_char6 ;
      private string GXt_char5 ;
      private string GXt_char3 ;
      private string tblTabledvelop_confirmpanel_delete_Internalname ;
      private string Dvelop_confirmpanel_delete_Internalname ;
      private string tblTablemergeddynamicfilters3_Internalname ;
      private string cmbavDynamicfiltersoperator3_Jsonclick ;
      private string cellFilter_negassunto3_cell_Internalname ;
      private string edtavNegassunto3_Jsonclick ;
      private string cellDynamicfilters_removefilter3_cell_Internalname ;
      private string imgRemovedynamicfilters3_gximage ;
      private string sImgUrl ;
      private string tblTablemergeddynamicfilters2_Internalname ;
      private string cmbavDynamicfiltersoperator2_Jsonclick ;
      private string cellFilter_negassunto2_cell_Internalname ;
      private string edtavNegassunto2_Jsonclick ;
      private string cellDynamicfilters_addfilter2_cell_Internalname ;
      private string imgAdddynamicfilters2_gximage ;
      private string cellDynamicfilters_removefilter2_cell_Internalname ;
      private string imgRemovedynamicfilters2_gximage ;
      private string tblTablemergeddynamicfilters1_Internalname ;
      private string cmbavDynamicfiltersoperator1_Jsonclick ;
      private string cellFilter_negassunto1_cell_Internalname ;
      private string edtavNegassunto1_Jsonclick ;
      private string cellDynamicfilters_addfilter1_cell_Internalname ;
      private string imgAdddynamicfilters1_gximage ;
      private string cellDynamicfilters_removefilter1_cell_Internalname ;
      private string imgRemovedynamicfilters1_gximage ;
      private string tblTablerightheader_Internalname ;
      private string Ddo_managefilters_Caption ;
      private string Ddo_managefilters_Internalname ;
      private string tblTablefilters_Internalname ;
      private string edtavFilterfulltext_Jsonclick ;
      private string sGXsfl_115_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string GXCCtl ;
      private string cmbavGridactions_Jsonclick ;
      private string ROClassString ;
      private string edtNegID_Jsonclick ;
      private string edtNegCodigo_Jsonclick ;
      private string edtNegInsHora_Jsonclick ;
      private string edtNegInsDataHora_Jsonclick ;
      private string edtNegInsUsuID_Jsonclick ;
      private string edtNegAssunto_Jsonclick ;
      private string edtNegCliID_Jsonclick ;
      private string edtNegCliNomeFamiliar_Jsonclick ;
      private string edtNegCpjID_Jsonclick ;
      private string edtNegCpjNomFan_Jsonclick ;
      private string edtNegCpjRazSocial_Jsonclick ;
      private string edtNegCpjMatricula_Jsonclick ;
      private string edtNegPjtID_Jsonclick ;
      private string edtNegPjtSigla_Jsonclick ;
      private string edtNegPjtNome_Jsonclick ;
      private string edtNegAgcID_Jsonclick ;
      private string edtNegAgcNome_Jsonclick ;
      private string edtNegValorAtualizado_Jsonclick ;
      private string edtNegInsData_Jsonclick ;
      private string edtNegInsUsuNome_Jsonclick ;
      private string subGrid_Header ;
      private DateTime A347NegInsHora ;
      private DateTime A348NegInsDataHora ;
      private DateTime AV43TFNegInsData ;
      private DateTime AV44TFNegInsData_To ;
      private DateTime AV45DDO_NegInsDataAuxDate ;
      private DateTime AV46DDO_NegInsDataAuxDateTo ;
      private DateTime A346NegInsData ;
      private DateTime AV136Core_negociopjwwds_30_tfneginsdata ;
      private DateTime AV137Core_negociopjwwds_31_tfneginsdata_to ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV103NegDel ;
      private bool AV21DynamicFiltersEnabled2 ;
      private bool AV25DynamicFiltersEnabled3 ;
      private bool AV15OrderedDsc ;
      private bool AV30DynamicFiltersIgnoreFirst ;
      private bool AV29DynamicFiltersRemoving ;
      private bool AV90IsAuthorized_Update ;
      private bool AV91IsAuthorized_Delete ;
      private bool AV96IsAuthorized_NegAssunto ;
      private bool AV92IsAuthorized_NegPjtNome ;
      private bool AV95IsAuthorized_Insert ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool Grid_empowerer_Hascolumnsselector ;
      private bool wbLoad ;
      private bool bGXsfl_115_Refreshing=false ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n349NegInsUsuID ;
      private bool n360NegAgcID ;
      private bool n361NegAgcNome ;
      private bool n364NegInsUsuNome ;
      private bool gxdyncontrolsrefreshing ;
      private bool AV112Core_negociopjwwds_6_dynamicfiltersenabled2 ;
      private bool AV116Core_negociopjwwds_10_dynamicfiltersenabled3 ;
      private bool A572NegDel ;
      private bool AV107Core_negociopjwwds_1_negdel ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool bDynCreated_Wwpaux_wc ;
      private bool GXt_boolean1 ;
      private string AV33ColumnsSelectorXML ;
      private string AV39ManageFiltersXml ;
      private string AV34UserCustomValue ;
      private string AV17FilterFullText ;
      private string AV18DynamicFiltersSelector1 ;
      private string AV20NegAssunto1 ;
      private string AV22DynamicFiltersSelector2 ;
      private string AV24NegAssunto2 ;
      private string AV26DynamicFiltersSelector3 ;
      private string AV28NegAssunto3 ;
      private string AV80TFNegAssunto ;
      private string AV81TFNegAssunto_Sel ;
      private string AV62TFNegCliNomeFamiliar ;
      private string AV63TFNegCliNomeFamiliar_Sel ;
      private string AV64TFNegCpjNomFan ;
      private string AV65TFNegCpjNomFan_Sel ;
      private string AV74TFNegPjtNome ;
      private string AV75TFNegPjtNome_Sel ;
      private string AV78TFNegAgcNome ;
      private string AV79TFNegAgcNome_Sel ;
      private string AV97TFNegInsUsuNome ;
      private string AV98TFNegInsUsuNome_Sel ;
      private string AV88GridAppliedFilters ;
      private string AV47DDO_NegInsDataAuxDateText ;
      private string A362NegAssunto ;
      private string A351NegCliNomeFamiliar ;
      private string A353NegCpjNomFan ;
      private string A354NegCpjRazSocial ;
      private string A358NegPjtSigla ;
      private string A359NegPjtNome ;
      private string A361NegAgcNome ;
      private string A364NegInsUsuNome ;
      private string lV108Core_negociopjwwds_2_filterfulltext ;
      private string lV111Core_negociopjwwds_5_negassunto1 ;
      private string lV115Core_negociopjwwds_9_negassunto2 ;
      private string lV119Core_negociopjwwds_13_negassunto3 ;
      private string lV122Core_negociopjwwds_16_tfnegassunto ;
      private string lV124Core_negociopjwwds_18_tfnegclinomefamiliar ;
      private string lV126Core_negociopjwwds_20_tfnegcpjnomfan ;
      private string lV130Core_negociopjwwds_24_tfnegpjtnome ;
      private string lV132Core_negociopjwwds_26_tfnegagcnome ;
      private string lV138Core_negociopjwwds_32_tfneginsusunome ;
      private string AV108Core_negociopjwwds_2_filterfulltext ;
      private string AV109Core_negociopjwwds_3_dynamicfiltersselector1 ;
      private string AV111Core_negociopjwwds_5_negassunto1 ;
      private string AV113Core_negociopjwwds_7_dynamicfiltersselector2 ;
      private string AV115Core_negociopjwwds_9_negassunto2 ;
      private string AV117Core_negociopjwwds_11_dynamicfiltersselector3 ;
      private string AV119Core_negociopjwwds_13_negassunto3 ;
      private string AV123Core_negociopjwwds_17_tfnegassunto_sel ;
      private string AV122Core_negociopjwwds_16_tfnegassunto ;
      private string AV125Core_negociopjwwds_19_tfnegclinomefamiliar_sel ;
      private string AV124Core_negociopjwwds_18_tfnegclinomefamiliar ;
      private string AV127Core_negociopjwwds_21_tfnegcpjnomfan_sel ;
      private string AV126Core_negociopjwwds_20_tfnegcpjnomfan ;
      private string AV131Core_negociopjwwds_25_tfnegpjtnome_sel ;
      private string AV130Core_negociopjwwds_24_tfnegpjtnome ;
      private string AV133Core_negociopjwwds_27_tfnegagcnome_sel ;
      private string AV132Core_negociopjwwds_26_tfnegagcnome ;
      private string AV139Core_negociopjwwds_33_tfneginsusunome_sel ;
      private string AV138Core_negociopjwwds_32_tfneginsusunome ;
      private string AV31ExcelFilename ;
      private string AV32ErrorMessage ;
      private Guid AV104NegID_Selected ;
      private Guid A345NegID ;
      private Guid A350NegCliID ;
      private Guid A352NegCpjID ;
      private IGxSession AV37Session ;
      private GXWebComponent WebComp_Wwpaux_wc ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_agexport ;
      private GXUserControl ucDdc_subscriptions ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucInnewwindow1 ;
      private GXUserControl ucDdo_gridcolumnsselector ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucTfneginsdata_rangepicker ;
      private GXUserControl ucDvelop_confirmpanel_delete ;
      private GXUserControl ucDdo_managefilters ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkavNegdel ;
      private GXCombobox cmbavDynamicfiltersselector1 ;
      private GXCombobox cmbavDynamicfiltersoperator1 ;
      private GXCombobox cmbavDynamicfiltersselector2 ;
      private GXCombobox cmbavDynamicfiltersoperator2 ;
      private GXCombobox cmbavDynamicfiltersselector3 ;
      private GXCombobox cmbavDynamicfiltersoperator3 ;
      private GXCombobox cmbavGridactions ;
      private IDataStoreProvider pr_default ;
      private bool[] H003X2_A572NegDel ;
      private string[] H003X2_A364NegInsUsuNome ;
      private bool[] H003X2_n364NegInsUsuNome ;
      private DateTime[] H003X2_A346NegInsData ;
      private decimal[] H003X2_A385NegValorAtualizado ;
      private string[] H003X2_A361NegAgcNome ;
      private bool[] H003X2_n361NegAgcNome ;
      private string[] H003X2_A360NegAgcID ;
      private bool[] H003X2_n360NegAgcID ;
      private string[] H003X2_A359NegPjtNome ;
      private string[] H003X2_A358NegPjtSigla ;
      private int[] H003X2_A357NegPjtID ;
      private long[] H003X2_A355NegCpjMatricula ;
      private string[] H003X2_A354NegCpjRazSocial ;
      private string[] H003X2_A353NegCpjNomFan ;
      private Guid[] H003X2_A352NegCpjID ;
      private string[] H003X2_A351NegCliNomeFamiliar ;
      private Guid[] H003X2_A350NegCliID ;
      private string[] H003X2_A362NegAssunto ;
      private string[] H003X2_A349NegInsUsuID ;
      private bool[] H003X2_n349NegInsUsuID ;
      private DateTime[] H003X2_A348NegInsDataHora ;
      private DateTime[] H003X2_A347NegInsHora ;
      private long[] H003X2_A356NegCodigo ;
      private Guid[] H003X2_A345NegID ;
      private long[] H003X3_AGRID_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV8HTTPRequest ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV38ManageFiltersData ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV93AGExportData ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV84GAMErrors ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV102Messages ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item AV94AGExportDataItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV35ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV36ColumnsSelectorAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV82DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV83GAMSession ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV12GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV13GridStateDynamicFilter ;
      private GeneXus.Utils.SdtMessages_Message AV101Message ;
      private GeneXus.Programs.core.SdtsdtNegocioPJ AV105sdtNegocioPJ ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
   }

   public class negociopjww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H003X2( IGxContext context ,
                                             string AV108Core_negociopjwwds_2_filterfulltext ,
                                             string AV109Core_negociopjwwds_3_dynamicfiltersselector1 ,
                                             short AV110Core_negociopjwwds_4_dynamicfiltersoperator1 ,
                                             string AV111Core_negociopjwwds_5_negassunto1 ,
                                             bool AV112Core_negociopjwwds_6_dynamicfiltersenabled2 ,
                                             string AV113Core_negociopjwwds_7_dynamicfiltersselector2 ,
                                             short AV114Core_negociopjwwds_8_dynamicfiltersoperator2 ,
                                             string AV115Core_negociopjwwds_9_negassunto2 ,
                                             bool AV116Core_negociopjwwds_10_dynamicfiltersenabled3 ,
                                             string AV117Core_negociopjwwds_11_dynamicfiltersselector3 ,
                                             short AV118Core_negociopjwwds_12_dynamicfiltersoperator3 ,
                                             string AV119Core_negociopjwwds_13_negassunto3 ,
                                             long AV120Core_negociopjwwds_14_tfnegcodigo ,
                                             long AV121Core_negociopjwwds_15_tfnegcodigo_to ,
                                             string AV123Core_negociopjwwds_17_tfnegassunto_sel ,
                                             string AV122Core_negociopjwwds_16_tfnegassunto ,
                                             string AV125Core_negociopjwwds_19_tfnegclinomefamiliar_sel ,
                                             string AV124Core_negociopjwwds_18_tfnegclinomefamiliar ,
                                             string AV127Core_negociopjwwds_21_tfnegcpjnomfan_sel ,
                                             string AV126Core_negociopjwwds_20_tfnegcpjnomfan ,
                                             long AV128Core_negociopjwwds_22_tfnegcpjmatricula ,
                                             long AV129Core_negociopjwwds_23_tfnegcpjmatricula_to ,
                                             string AV131Core_negociopjwwds_25_tfnegpjtnome_sel ,
                                             string AV130Core_negociopjwwds_24_tfnegpjtnome ,
                                             string AV133Core_negociopjwwds_27_tfnegagcnome_sel ,
                                             string AV132Core_negociopjwwds_26_tfnegagcnome ,
                                             decimal AV134Core_negociopjwwds_28_tfnegvaloratualizado ,
                                             decimal AV135Core_negociopjwwds_29_tfnegvaloratualizado_to ,
                                             DateTime AV136Core_negociopjwwds_30_tfneginsdata ,
                                             DateTime AV137Core_negociopjwwds_31_tfneginsdata_to ,
                                             string AV139Core_negociopjwwds_33_tfneginsusunome_sel ,
                                             string AV138Core_negociopjwwds_32_tfneginsusunome ,
                                             long A356NegCodigo ,
                                             string A362NegAssunto ,
                                             string A351NegCliNomeFamiliar ,
                                             string A353NegCpjNomFan ,
                                             long A355NegCpjMatricula ,
                                             string A359NegPjtNome ,
                                             string A361NegAgcNome ,
                                             decimal A385NegValorAtualizado ,
                                             string A364NegInsUsuNome ,
                                             DateTime A346NegInsData ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc ,
                                             bool A572NegDel )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int10 = new short[38];
         Object[] GXv_Object11 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.NegDel, T1.NegInsUsuNome, T1.NegInsData, T1.NegValorAtualizado, T1.NegAgcNome, T1.NegAgcID, T1.NegPjtNome AS NegPjtNome, T3.PjtSigla AS NegPjtSigla, T2.CpjTipoId AS NegPjtID, T2.CpjMatricula AS NegCpjMatricula, T1.NegCpjRazSocial AS NegCpjRazSocial, T1.NegCpjNomFan AS NegCpjNomFan, T1.NegCpjID AS NegCpjID, T1.NegCliNomeFamiliar, T1.NegCliID AS NegCliID, T1.NegAssunto, T1.NegInsUsuID, T1.NegInsDataHora, T1.NegInsHora, T1.NegCodigo, T1.NegID";
         sFromString = " FROM ((tb_negociopj T1 INNER JOIN tb_clientepj T2 ON T2.CliID = T1.NegCliID AND T2.CpjID = T1.NegCpjID) INNER JOIN tb_clientepjtipo T3 ON T3.PjtID = T2.CpjTipoId)";
         sOrderString = "";
         AddWhere(sWhereString, "(Not T1.NegDel)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Core_negociopjwwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(T1.NegCodigo,'999999999999'), 2) like '%' || :lV108Core_negociopjwwds_2_filterfulltext) or ( T1.NegAssunto like '%' || :lV108Core_negociopjwwds_2_filterfulltext) or ( T1.NegCliNomeFamiliar like '%' || :lV108Core_negociopjwwds_2_filterfulltext) or ( T1.NegCpjNomFan like '%' || :lV108Core_negociopjwwds_2_filterfulltext) or ( SUBSTR(TO_CHAR(T2.CpjMatricula,'999999999999'), 2) like '%' || :lV108Core_negociopjwwds_2_filterfulltext) or ( T1.NegPjtNome like '%' || :lV108Core_negociopjwwds_2_filterfulltext) or ( T1.NegAgcNome like '%' || :lV108Core_negociopjwwds_2_filterfulltext) or ( SUBSTR(TO_CHAR(T1.NegValorAtualizado,'9999999999990.99'), 2) like '%' || :lV108Core_negociopjwwds_2_filterfulltext) or ( T1.NegInsUsuNome like '%' || :lV108Core_negociopjwwds_2_filterfulltext))");
         }
         else
         {
            GXv_int10[0] = 1;
            GXv_int10[1] = 1;
            GXv_int10[2] = 1;
            GXv_int10[3] = 1;
            GXv_int10[4] = 1;
            GXv_int10[5] = 1;
            GXv_int10[6] = 1;
            GXv_int10[7] = 1;
            GXv_int10[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV109Core_negociopjwwds_3_dynamicfiltersselector1, "NEGASSUNTO") == 0 ) && ( AV110Core_negociopjwwds_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Core_negociopjwwds_5_negassunto1)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto like :lV111Core_negociopjwwds_5_negassunto1)");
         }
         else
         {
            GXv_int10[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV109Core_negociopjwwds_3_dynamicfiltersselector1, "NEGASSUNTO") == 0 ) && ( AV110Core_negociopjwwds_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Core_negociopjwwds_5_negassunto1)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto like '%' || :lV111Core_negociopjwwds_5_negassunto1)");
         }
         else
         {
            GXv_int10[10] = 1;
         }
         if ( AV112Core_negociopjwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Core_negociopjwwds_7_dynamicfiltersselector2, "NEGASSUNTO") == 0 ) && ( AV114Core_negociopjwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Core_negociopjwwds_9_negassunto2)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto like :lV115Core_negociopjwwds_9_negassunto2)");
         }
         else
         {
            GXv_int10[11] = 1;
         }
         if ( AV112Core_negociopjwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Core_negociopjwwds_7_dynamicfiltersselector2, "NEGASSUNTO") == 0 ) && ( AV114Core_negociopjwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Core_negociopjwwds_9_negassunto2)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto like '%' || :lV115Core_negociopjwwds_9_negassunto2)");
         }
         else
         {
            GXv_int10[12] = 1;
         }
         if ( AV116Core_negociopjwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV117Core_negociopjwwds_11_dynamicfiltersselector3, "NEGASSUNTO") == 0 ) && ( AV118Core_negociopjwwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV119Core_negociopjwwds_13_negassunto3)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto like :lV119Core_negociopjwwds_13_negassunto3)");
         }
         else
         {
            GXv_int10[13] = 1;
         }
         if ( AV116Core_negociopjwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV117Core_negociopjwwds_11_dynamicfiltersselector3, "NEGASSUNTO") == 0 ) && ( AV118Core_negociopjwwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV119Core_negociopjwwds_13_negassunto3)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto like '%' || :lV119Core_negociopjwwds_13_negassunto3)");
         }
         else
         {
            GXv_int10[14] = 1;
         }
         if ( ! (0==AV120Core_negociopjwwds_14_tfnegcodigo) )
         {
            AddWhere(sWhereString, "(T1.NegCodigo >= :AV120Core_negociopjwwds_14_tfnegcodigo)");
         }
         else
         {
            GXv_int10[15] = 1;
         }
         if ( ! (0==AV121Core_negociopjwwds_15_tfnegcodigo_to) )
         {
            AddWhere(sWhereString, "(T1.NegCodigo <= :AV121Core_negociopjwwds_15_tfnegcodigo_to)");
         }
         else
         {
            GXv_int10[16] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV123Core_negociopjwwds_17_tfnegassunto_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Core_negociopjwwds_16_tfnegassunto)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto like :lV122Core_negociopjwwds_16_tfnegassunto)");
         }
         else
         {
            GXv_int10[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Core_negociopjwwds_17_tfnegassunto_sel)) && ! ( StringUtil.StrCmp(AV123Core_negociopjwwds_17_tfnegassunto_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto = ( :AV123Core_negociopjwwds_17_tfnegassunto_sel))");
         }
         else
         {
            GXv_int10[18] = 1;
         }
         if ( StringUtil.StrCmp(AV123Core_negociopjwwds_17_tfnegassunto_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.NegAssunto))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV125Core_negociopjwwds_19_tfnegclinomefamiliar_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124Core_negociopjwwds_18_tfnegclinomefamiliar)) ) )
         {
            AddWhere(sWhereString, "(T1.NegCliNomeFamiliar like :lV124Core_negociopjwwds_18_tfnegclinomefamiliar)");
         }
         else
         {
            GXv_int10[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV125Core_negociopjwwds_19_tfnegclinomefamiliar_sel)) && ! ( StringUtil.StrCmp(AV125Core_negociopjwwds_19_tfnegclinomefamiliar_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegCliNomeFamiliar = ( :AV125Core_negociopjwwds_19_tfnegclinomefamiliar_sel))");
         }
         else
         {
            GXv_int10[20] = 1;
         }
         if ( StringUtil.StrCmp(AV125Core_negociopjwwds_19_tfnegclinomefamiliar_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.NegCliNomeFamiliar))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV127Core_negociopjwwds_21_tfnegcpjnomfan_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV126Core_negociopjwwds_20_tfnegcpjnomfan)) ) )
         {
            AddWhere(sWhereString, "(T1.NegCpjNomFan like :lV126Core_negociopjwwds_20_tfnegcpjnomfan)");
         }
         else
         {
            GXv_int10[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV127Core_negociopjwwds_21_tfnegcpjnomfan_sel)) && ! ( StringUtil.StrCmp(AV127Core_negociopjwwds_21_tfnegcpjnomfan_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegCpjNomFan = ( :AV127Core_negociopjwwds_21_tfnegcpjnomfan_sel))");
         }
         else
         {
            GXv_int10[22] = 1;
         }
         if ( StringUtil.StrCmp(AV127Core_negociopjwwds_21_tfnegcpjnomfan_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.NegCpjNomFan))=0))");
         }
         if ( ! (0==AV128Core_negociopjwwds_22_tfnegcpjmatricula) )
         {
            AddWhere(sWhereString, "(T2.CpjMatricula >= :AV128Core_negociopjwwds_22_tfnegcpjmatricula)");
         }
         else
         {
            GXv_int10[23] = 1;
         }
         if ( ! (0==AV129Core_negociopjwwds_23_tfnegcpjmatricula_to) )
         {
            AddWhere(sWhereString, "(T2.CpjMatricula <= :AV129Core_negociopjwwds_23_tfnegcpjmatricula_to)");
         }
         else
         {
            GXv_int10[24] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV131Core_negociopjwwds_25_tfnegpjtnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV130Core_negociopjwwds_24_tfnegpjtnome)) ) )
         {
            AddWhere(sWhereString, "(T1.NegPjtNome like :lV130Core_negociopjwwds_24_tfnegpjtnome)");
         }
         else
         {
            GXv_int10[25] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV131Core_negociopjwwds_25_tfnegpjtnome_sel)) && ! ( StringUtil.StrCmp(AV131Core_negociopjwwds_25_tfnegpjtnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegPjtNome = ( :AV131Core_negociopjwwds_25_tfnegpjtnome_sel))");
         }
         else
         {
            GXv_int10[26] = 1;
         }
         if ( StringUtil.StrCmp(AV131Core_negociopjwwds_25_tfnegpjtnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.NegPjtNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV133Core_negociopjwwds_27_tfnegagcnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV132Core_negociopjwwds_26_tfnegagcnome)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAgcNome like :lV132Core_negociopjwwds_26_tfnegagcnome)");
         }
         else
         {
            GXv_int10[27] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV133Core_negociopjwwds_27_tfnegagcnome_sel)) && ! ( StringUtil.StrCmp(AV133Core_negociopjwwds_27_tfnegagcnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegAgcNome = ( :AV133Core_negociopjwwds_27_tfnegagcnome_sel))");
         }
         else
         {
            GXv_int10[28] = 1;
         }
         if ( StringUtil.StrCmp(AV133Core_negociopjwwds_27_tfnegagcnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.NegAgcNome IS NULL or (char_length(trim(trailing ' ' from T1.NegAgcNome))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV134Core_negociopjwwds_28_tfnegvaloratualizado) )
         {
            AddWhere(sWhereString, "(T1.NegValorAtualizado >= :AV134Core_negociopjwwds_28_tfnegvaloratualizado)");
         }
         else
         {
            GXv_int10[29] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV135Core_negociopjwwds_29_tfnegvaloratualizado_to) )
         {
            AddWhere(sWhereString, "(T1.NegValorAtualizado <= :AV135Core_negociopjwwds_29_tfnegvaloratualizado_to)");
         }
         else
         {
            GXv_int10[30] = 1;
         }
         if ( ! (DateTime.MinValue==AV136Core_negociopjwwds_30_tfneginsdata) )
         {
            AddWhere(sWhereString, "(T1.NegInsData >= :AV136Core_negociopjwwds_30_tfneginsdata)");
         }
         else
         {
            GXv_int10[31] = 1;
         }
         if ( ! (DateTime.MinValue==AV137Core_negociopjwwds_31_tfneginsdata_to) )
         {
            AddWhere(sWhereString, "(T1.NegInsData <= :AV137Core_negociopjwwds_31_tfneginsdata_to)");
         }
         else
         {
            GXv_int10[32] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV139Core_negociopjwwds_33_tfneginsusunome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV138Core_negociopjwwds_32_tfneginsusunome)) ) )
         {
            AddWhere(sWhereString, "(T1.NegInsUsuNome like :lV138Core_negociopjwwds_32_tfneginsusunome)");
         }
         else
         {
            GXv_int10[33] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV139Core_negociopjwwds_33_tfneginsusunome_sel)) && ! ( StringUtil.StrCmp(AV139Core_negociopjwwds_33_tfneginsusunome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegInsUsuNome = ( :AV139Core_negociopjwwds_33_tfneginsusunome_sel))");
         }
         else
         {
            GXv_int10[34] = 1;
         }
         if ( StringUtil.StrCmp(AV139Core_negociopjwwds_33_tfneginsusunome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.NegInsUsuNome IS NULL or (char_length(trim(trailing ' ' from T1.NegInsUsuNome))=0))");
         }
         if ( ( AV14OrderedBy == 1 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.NegAssunto, T1.NegID";
         }
         else if ( ( AV14OrderedBy == 1 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.NegAssunto DESC, T1.NegID";
         }
         else if ( ( AV14OrderedBy == 2 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.NegCodigo";
         }
         else if ( ( AV14OrderedBy == 2 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.NegCodigo DESC";
         }
         else if ( ( AV14OrderedBy == 3 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.NegCliNomeFamiliar, T1.NegID";
         }
         else if ( ( AV14OrderedBy == 3 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.NegCliNomeFamiliar DESC, T1.NegID";
         }
         else if ( ( AV14OrderedBy == 4 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.NegCpjNomFan, T1.NegID";
         }
         else if ( ( AV14OrderedBy == 4 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.NegCpjNomFan DESC, T1.NegID";
         }
         else if ( ( AV14OrderedBy == 5 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T2.CpjMatricula, T1.NegID";
         }
         else if ( ( AV14OrderedBy == 5 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T2.CpjMatricula DESC, T1.NegID";
         }
         else if ( ( AV14OrderedBy == 6 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.NegPjtNome, T1.NegID";
         }
         else if ( ( AV14OrderedBy == 6 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.NegPjtNome DESC, T1.NegID";
         }
         else if ( ( AV14OrderedBy == 7 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.NegAgcNome, T1.NegID";
         }
         else if ( ( AV14OrderedBy == 7 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.NegAgcNome DESC, T1.NegID";
         }
         else if ( ( AV14OrderedBy == 8 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.NegValorAtualizado, T1.NegID";
         }
         else if ( ( AV14OrderedBy == 8 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.NegValorAtualizado DESC, T1.NegID";
         }
         else if ( ( AV14OrderedBy == 9 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.NegInsData, T1.NegID";
         }
         else if ( ( AV14OrderedBy == 9 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.NegInsData DESC, T1.NegID";
         }
         else if ( ( AV14OrderedBy == 10 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.NegInsUsuNome, T1.NegID";
         }
         else if ( ( AV14OrderedBy == 10 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.NegInsUsuNome DESC, T1.NegID";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.NegID";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object11[0] = scmdbuf;
         GXv_Object11[1] = GXv_int10;
         return GXv_Object11 ;
      }

      protected Object[] conditional_H003X3( IGxContext context ,
                                             string AV108Core_negociopjwwds_2_filterfulltext ,
                                             string AV109Core_negociopjwwds_3_dynamicfiltersselector1 ,
                                             short AV110Core_negociopjwwds_4_dynamicfiltersoperator1 ,
                                             string AV111Core_negociopjwwds_5_negassunto1 ,
                                             bool AV112Core_negociopjwwds_6_dynamicfiltersenabled2 ,
                                             string AV113Core_negociopjwwds_7_dynamicfiltersselector2 ,
                                             short AV114Core_negociopjwwds_8_dynamicfiltersoperator2 ,
                                             string AV115Core_negociopjwwds_9_negassunto2 ,
                                             bool AV116Core_negociopjwwds_10_dynamicfiltersenabled3 ,
                                             string AV117Core_negociopjwwds_11_dynamicfiltersselector3 ,
                                             short AV118Core_negociopjwwds_12_dynamicfiltersoperator3 ,
                                             string AV119Core_negociopjwwds_13_negassunto3 ,
                                             long AV120Core_negociopjwwds_14_tfnegcodigo ,
                                             long AV121Core_negociopjwwds_15_tfnegcodigo_to ,
                                             string AV123Core_negociopjwwds_17_tfnegassunto_sel ,
                                             string AV122Core_negociopjwwds_16_tfnegassunto ,
                                             string AV125Core_negociopjwwds_19_tfnegclinomefamiliar_sel ,
                                             string AV124Core_negociopjwwds_18_tfnegclinomefamiliar ,
                                             string AV127Core_negociopjwwds_21_tfnegcpjnomfan_sel ,
                                             string AV126Core_negociopjwwds_20_tfnegcpjnomfan ,
                                             long AV128Core_negociopjwwds_22_tfnegcpjmatricula ,
                                             long AV129Core_negociopjwwds_23_tfnegcpjmatricula_to ,
                                             string AV131Core_negociopjwwds_25_tfnegpjtnome_sel ,
                                             string AV130Core_negociopjwwds_24_tfnegpjtnome ,
                                             string AV133Core_negociopjwwds_27_tfnegagcnome_sel ,
                                             string AV132Core_negociopjwwds_26_tfnegagcnome ,
                                             decimal AV134Core_negociopjwwds_28_tfnegvaloratualizado ,
                                             decimal AV135Core_negociopjwwds_29_tfnegvaloratualizado_to ,
                                             DateTime AV136Core_negociopjwwds_30_tfneginsdata ,
                                             DateTime AV137Core_negociopjwwds_31_tfneginsdata_to ,
                                             string AV139Core_negociopjwwds_33_tfneginsusunome_sel ,
                                             string AV138Core_negociopjwwds_32_tfneginsusunome ,
                                             long A356NegCodigo ,
                                             string A362NegAssunto ,
                                             string A351NegCliNomeFamiliar ,
                                             string A353NegCpjNomFan ,
                                             long A355NegCpjMatricula ,
                                             string A359NegPjtNome ,
                                             string A361NegAgcNome ,
                                             decimal A385NegValorAtualizado ,
                                             string A364NegInsUsuNome ,
                                             DateTime A346NegInsData ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc ,
                                             bool A572NegDel )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int12 = new short[35];
         Object[] GXv_Object13 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM ((tb_negociopj T1 INNER JOIN tb_clientepj T2 ON T2.CliID = T1.NegCliID AND T2.CpjID = T1.NegCpjID) INNER JOIN tb_clientepjtipo T3 ON T3.PjtID = T2.CpjTipoId)";
         AddWhere(sWhereString, "(Not T1.NegDel)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Core_negociopjwwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(T1.NegCodigo,'999999999999'), 2) like '%' || :lV108Core_negociopjwwds_2_filterfulltext) or ( T1.NegAssunto like '%' || :lV108Core_negociopjwwds_2_filterfulltext) or ( T1.NegCliNomeFamiliar like '%' || :lV108Core_negociopjwwds_2_filterfulltext) or ( T1.NegCpjNomFan like '%' || :lV108Core_negociopjwwds_2_filterfulltext) or ( SUBSTR(TO_CHAR(T2.CpjMatricula,'999999999999'), 2) like '%' || :lV108Core_negociopjwwds_2_filterfulltext) or ( T1.NegPjtNome like '%' || :lV108Core_negociopjwwds_2_filterfulltext) or ( T1.NegAgcNome like '%' || :lV108Core_negociopjwwds_2_filterfulltext) or ( SUBSTR(TO_CHAR(T1.NegValorAtualizado,'9999999999990.99'), 2) like '%' || :lV108Core_negociopjwwds_2_filterfulltext) or ( T1.NegInsUsuNome like '%' || :lV108Core_negociopjwwds_2_filterfulltext))");
         }
         else
         {
            GXv_int12[0] = 1;
            GXv_int12[1] = 1;
            GXv_int12[2] = 1;
            GXv_int12[3] = 1;
            GXv_int12[4] = 1;
            GXv_int12[5] = 1;
            GXv_int12[6] = 1;
            GXv_int12[7] = 1;
            GXv_int12[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV109Core_negociopjwwds_3_dynamicfiltersselector1, "NEGASSUNTO") == 0 ) && ( AV110Core_negociopjwwds_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Core_negociopjwwds_5_negassunto1)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto like :lV111Core_negociopjwwds_5_negassunto1)");
         }
         else
         {
            GXv_int12[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV109Core_negociopjwwds_3_dynamicfiltersselector1, "NEGASSUNTO") == 0 ) && ( AV110Core_negociopjwwds_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Core_negociopjwwds_5_negassunto1)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto like '%' || :lV111Core_negociopjwwds_5_negassunto1)");
         }
         else
         {
            GXv_int12[10] = 1;
         }
         if ( AV112Core_negociopjwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Core_negociopjwwds_7_dynamicfiltersselector2, "NEGASSUNTO") == 0 ) && ( AV114Core_negociopjwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Core_negociopjwwds_9_negassunto2)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto like :lV115Core_negociopjwwds_9_negassunto2)");
         }
         else
         {
            GXv_int12[11] = 1;
         }
         if ( AV112Core_negociopjwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Core_negociopjwwds_7_dynamicfiltersselector2, "NEGASSUNTO") == 0 ) && ( AV114Core_negociopjwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Core_negociopjwwds_9_negassunto2)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto like '%' || :lV115Core_negociopjwwds_9_negassunto2)");
         }
         else
         {
            GXv_int12[12] = 1;
         }
         if ( AV116Core_negociopjwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV117Core_negociopjwwds_11_dynamicfiltersselector3, "NEGASSUNTO") == 0 ) && ( AV118Core_negociopjwwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV119Core_negociopjwwds_13_negassunto3)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto like :lV119Core_negociopjwwds_13_negassunto3)");
         }
         else
         {
            GXv_int12[13] = 1;
         }
         if ( AV116Core_negociopjwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV117Core_negociopjwwds_11_dynamicfiltersselector3, "NEGASSUNTO") == 0 ) && ( AV118Core_negociopjwwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV119Core_negociopjwwds_13_negassunto3)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto like '%' || :lV119Core_negociopjwwds_13_negassunto3)");
         }
         else
         {
            GXv_int12[14] = 1;
         }
         if ( ! (0==AV120Core_negociopjwwds_14_tfnegcodigo) )
         {
            AddWhere(sWhereString, "(T1.NegCodigo >= :AV120Core_negociopjwwds_14_tfnegcodigo)");
         }
         else
         {
            GXv_int12[15] = 1;
         }
         if ( ! (0==AV121Core_negociopjwwds_15_tfnegcodigo_to) )
         {
            AddWhere(sWhereString, "(T1.NegCodigo <= :AV121Core_negociopjwwds_15_tfnegcodigo_to)");
         }
         else
         {
            GXv_int12[16] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV123Core_negociopjwwds_17_tfnegassunto_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Core_negociopjwwds_16_tfnegassunto)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto like :lV122Core_negociopjwwds_16_tfnegassunto)");
         }
         else
         {
            GXv_int12[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Core_negociopjwwds_17_tfnegassunto_sel)) && ! ( StringUtil.StrCmp(AV123Core_negociopjwwds_17_tfnegassunto_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto = ( :AV123Core_negociopjwwds_17_tfnegassunto_sel))");
         }
         else
         {
            GXv_int12[18] = 1;
         }
         if ( StringUtil.StrCmp(AV123Core_negociopjwwds_17_tfnegassunto_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.NegAssunto))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV125Core_negociopjwwds_19_tfnegclinomefamiliar_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124Core_negociopjwwds_18_tfnegclinomefamiliar)) ) )
         {
            AddWhere(sWhereString, "(T1.NegCliNomeFamiliar like :lV124Core_negociopjwwds_18_tfnegclinomefamiliar)");
         }
         else
         {
            GXv_int12[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV125Core_negociopjwwds_19_tfnegclinomefamiliar_sel)) && ! ( StringUtil.StrCmp(AV125Core_negociopjwwds_19_tfnegclinomefamiliar_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegCliNomeFamiliar = ( :AV125Core_negociopjwwds_19_tfnegclinomefamiliar_sel))");
         }
         else
         {
            GXv_int12[20] = 1;
         }
         if ( StringUtil.StrCmp(AV125Core_negociopjwwds_19_tfnegclinomefamiliar_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.NegCliNomeFamiliar))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV127Core_negociopjwwds_21_tfnegcpjnomfan_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV126Core_negociopjwwds_20_tfnegcpjnomfan)) ) )
         {
            AddWhere(sWhereString, "(T1.NegCpjNomFan like :lV126Core_negociopjwwds_20_tfnegcpjnomfan)");
         }
         else
         {
            GXv_int12[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV127Core_negociopjwwds_21_tfnegcpjnomfan_sel)) && ! ( StringUtil.StrCmp(AV127Core_negociopjwwds_21_tfnegcpjnomfan_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegCpjNomFan = ( :AV127Core_negociopjwwds_21_tfnegcpjnomfan_sel))");
         }
         else
         {
            GXv_int12[22] = 1;
         }
         if ( StringUtil.StrCmp(AV127Core_negociopjwwds_21_tfnegcpjnomfan_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.NegCpjNomFan))=0))");
         }
         if ( ! (0==AV128Core_negociopjwwds_22_tfnegcpjmatricula) )
         {
            AddWhere(sWhereString, "(T2.CpjMatricula >= :AV128Core_negociopjwwds_22_tfnegcpjmatricula)");
         }
         else
         {
            GXv_int12[23] = 1;
         }
         if ( ! (0==AV129Core_negociopjwwds_23_tfnegcpjmatricula_to) )
         {
            AddWhere(sWhereString, "(T2.CpjMatricula <= :AV129Core_negociopjwwds_23_tfnegcpjmatricula_to)");
         }
         else
         {
            GXv_int12[24] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV131Core_negociopjwwds_25_tfnegpjtnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV130Core_negociopjwwds_24_tfnegpjtnome)) ) )
         {
            AddWhere(sWhereString, "(T1.NegPjtNome like :lV130Core_negociopjwwds_24_tfnegpjtnome)");
         }
         else
         {
            GXv_int12[25] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV131Core_negociopjwwds_25_tfnegpjtnome_sel)) && ! ( StringUtil.StrCmp(AV131Core_negociopjwwds_25_tfnegpjtnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegPjtNome = ( :AV131Core_negociopjwwds_25_tfnegpjtnome_sel))");
         }
         else
         {
            GXv_int12[26] = 1;
         }
         if ( StringUtil.StrCmp(AV131Core_negociopjwwds_25_tfnegpjtnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.NegPjtNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV133Core_negociopjwwds_27_tfnegagcnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV132Core_negociopjwwds_26_tfnegagcnome)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAgcNome like :lV132Core_negociopjwwds_26_tfnegagcnome)");
         }
         else
         {
            GXv_int12[27] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV133Core_negociopjwwds_27_tfnegagcnome_sel)) && ! ( StringUtil.StrCmp(AV133Core_negociopjwwds_27_tfnegagcnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegAgcNome = ( :AV133Core_negociopjwwds_27_tfnegagcnome_sel))");
         }
         else
         {
            GXv_int12[28] = 1;
         }
         if ( StringUtil.StrCmp(AV133Core_negociopjwwds_27_tfnegagcnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.NegAgcNome IS NULL or (char_length(trim(trailing ' ' from T1.NegAgcNome))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV134Core_negociopjwwds_28_tfnegvaloratualizado) )
         {
            AddWhere(sWhereString, "(T1.NegValorAtualizado >= :AV134Core_negociopjwwds_28_tfnegvaloratualizado)");
         }
         else
         {
            GXv_int12[29] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV135Core_negociopjwwds_29_tfnegvaloratualizado_to) )
         {
            AddWhere(sWhereString, "(T1.NegValorAtualizado <= :AV135Core_negociopjwwds_29_tfnegvaloratualizado_to)");
         }
         else
         {
            GXv_int12[30] = 1;
         }
         if ( ! (DateTime.MinValue==AV136Core_negociopjwwds_30_tfneginsdata) )
         {
            AddWhere(sWhereString, "(T1.NegInsData >= :AV136Core_negociopjwwds_30_tfneginsdata)");
         }
         else
         {
            GXv_int12[31] = 1;
         }
         if ( ! (DateTime.MinValue==AV137Core_negociopjwwds_31_tfneginsdata_to) )
         {
            AddWhere(sWhereString, "(T1.NegInsData <= :AV137Core_negociopjwwds_31_tfneginsdata_to)");
         }
         else
         {
            GXv_int12[32] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV139Core_negociopjwwds_33_tfneginsusunome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV138Core_negociopjwwds_32_tfneginsusunome)) ) )
         {
            AddWhere(sWhereString, "(T1.NegInsUsuNome like :lV138Core_negociopjwwds_32_tfneginsusunome)");
         }
         else
         {
            GXv_int12[33] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV139Core_negociopjwwds_33_tfneginsusunome_sel)) && ! ( StringUtil.StrCmp(AV139Core_negociopjwwds_33_tfneginsusunome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegInsUsuNome = ( :AV139Core_negociopjwwds_33_tfneginsusunome_sel))");
         }
         else
         {
            GXv_int12[34] = 1;
         }
         if ( StringUtil.StrCmp(AV139Core_negociopjwwds_33_tfneginsusunome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.NegInsUsuNome IS NULL or (char_length(trim(trailing ' ' from T1.NegInsUsuNome))=0))");
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
         else if ( ( AV14OrderedBy == 9 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 9 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 10 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 10 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( true )
         {
            scmdbuf += "";
         }
         GXv_Object13[0] = scmdbuf;
         GXv_Object13[1] = GXv_int12;
         return GXv_Object13 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H003X2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (long)dynConstraints[12] , (long)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (long)dynConstraints[20] , (long)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (decimal)dynConstraints[26] , (decimal)dynConstraints[27] , (DateTime)dynConstraints[28] , (DateTime)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (long)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (long)dynConstraints[36] , (string)dynConstraints[37] , (string)dynConstraints[38] , (decimal)dynConstraints[39] , (string)dynConstraints[40] , (DateTime)dynConstraints[41] , (short)dynConstraints[42] , (bool)dynConstraints[43] , (bool)dynConstraints[44] );
               case 1 :
                     return conditional_H003X3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (long)dynConstraints[12] , (long)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (long)dynConstraints[20] , (long)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (decimal)dynConstraints[26] , (decimal)dynConstraints[27] , (DateTime)dynConstraints[28] , (DateTime)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (long)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (long)dynConstraints[36] , (string)dynConstraints[37] , (string)dynConstraints[38] , (decimal)dynConstraints[39] , (string)dynConstraints[40] , (DateTime)dynConstraints[41] , (short)dynConstraints[42] , (bool)dynConstraints[43] , (bool)dynConstraints[44] );
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
          Object[] prmH003X2;
          prmH003X2 = new Object[] {
          new ParDef("lV108Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV108Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV108Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV108Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV108Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV108Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV108Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV108Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV108Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV111Core_negociopjwwds_5_negassunto1",GXType.VarChar,80,0) ,
          new ParDef("lV111Core_negociopjwwds_5_negassunto1",GXType.VarChar,80,0) ,
          new ParDef("lV115Core_negociopjwwds_9_negassunto2",GXType.VarChar,80,0) ,
          new ParDef("lV115Core_negociopjwwds_9_negassunto2",GXType.VarChar,80,0) ,
          new ParDef("lV119Core_negociopjwwds_13_negassunto3",GXType.VarChar,80,0) ,
          new ParDef("lV119Core_negociopjwwds_13_negassunto3",GXType.VarChar,80,0) ,
          new ParDef("AV120Core_negociopjwwds_14_tfnegcodigo",GXType.Int64,12,0) ,
          new ParDef("AV121Core_negociopjwwds_15_tfnegcodigo_to",GXType.Int64,12,0) ,
          new ParDef("lV122Core_negociopjwwds_16_tfnegassunto",GXType.VarChar,80,0) ,
          new ParDef("AV123Core_negociopjwwds_17_tfnegassunto_sel",GXType.VarChar,80,0) ,
          new ParDef("lV124Core_negociopjwwds_18_tfnegclinomefamiliar",GXType.VarChar,80,0) ,
          new ParDef("AV125Core_negociopjwwds_19_tfnegclinomefamiliar_sel",GXType.VarChar,80,0) ,
          new ParDef("lV126Core_negociopjwwds_20_tfnegcpjnomfan",GXType.VarChar,80,0) ,
          new ParDef("AV127Core_negociopjwwds_21_tfnegcpjnomfan_sel",GXType.VarChar,80,0) ,
          new ParDef("AV128Core_negociopjwwds_22_tfnegcpjmatricula",GXType.Int64,12,0) ,
          new ParDef("AV129Core_negociopjwwds_23_tfnegcpjmatricula_to",GXType.Int64,12,0) ,
          new ParDef("lV130Core_negociopjwwds_24_tfnegpjtnome",GXType.VarChar,80,0) ,
          new ParDef("AV131Core_negociopjwwds_25_tfnegpjtnome_sel",GXType.VarChar,80,0) ,
          new ParDef("lV132Core_negociopjwwds_26_tfnegagcnome",GXType.VarChar,80,0) ,
          new ParDef("AV133Core_negociopjwwds_27_tfnegagcnome_sel",GXType.VarChar,80,0) ,
          new ParDef("AV134Core_negociopjwwds_28_tfnegvaloratualizado",GXType.Number,16,2) ,
          new ParDef("AV135Core_negociopjwwds_29_tfnegvaloratualizado_to",GXType.Number,16,2) ,
          new ParDef("AV136Core_negociopjwwds_30_tfneginsdata",GXType.Date,8,0) ,
          new ParDef("AV137Core_negociopjwwds_31_tfneginsdata_to",GXType.Date,8,0) ,
          new ParDef("lV138Core_negociopjwwds_32_tfneginsusunome",GXType.VarChar,80,0) ,
          new ParDef("AV139Core_negociopjwwds_33_tfneginsusunome_sel",GXType.VarChar,80,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH003X3;
          prmH003X3 = new Object[] {
          new ParDef("lV108Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV108Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV108Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV108Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV108Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV108Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV108Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV108Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV108Core_negociopjwwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV111Core_negociopjwwds_5_negassunto1",GXType.VarChar,80,0) ,
          new ParDef("lV111Core_negociopjwwds_5_negassunto1",GXType.VarChar,80,0) ,
          new ParDef("lV115Core_negociopjwwds_9_negassunto2",GXType.VarChar,80,0) ,
          new ParDef("lV115Core_negociopjwwds_9_negassunto2",GXType.VarChar,80,0) ,
          new ParDef("lV119Core_negociopjwwds_13_negassunto3",GXType.VarChar,80,0) ,
          new ParDef("lV119Core_negociopjwwds_13_negassunto3",GXType.VarChar,80,0) ,
          new ParDef("AV120Core_negociopjwwds_14_tfnegcodigo",GXType.Int64,12,0) ,
          new ParDef("AV121Core_negociopjwwds_15_tfnegcodigo_to",GXType.Int64,12,0) ,
          new ParDef("lV122Core_negociopjwwds_16_tfnegassunto",GXType.VarChar,80,0) ,
          new ParDef("AV123Core_negociopjwwds_17_tfnegassunto_sel",GXType.VarChar,80,0) ,
          new ParDef("lV124Core_negociopjwwds_18_tfnegclinomefamiliar",GXType.VarChar,80,0) ,
          new ParDef("AV125Core_negociopjwwds_19_tfnegclinomefamiliar_sel",GXType.VarChar,80,0) ,
          new ParDef("lV126Core_negociopjwwds_20_tfnegcpjnomfan",GXType.VarChar,80,0) ,
          new ParDef("AV127Core_negociopjwwds_21_tfnegcpjnomfan_sel",GXType.VarChar,80,0) ,
          new ParDef("AV128Core_negociopjwwds_22_tfnegcpjmatricula",GXType.Int64,12,0) ,
          new ParDef("AV129Core_negociopjwwds_23_tfnegcpjmatricula_to",GXType.Int64,12,0) ,
          new ParDef("lV130Core_negociopjwwds_24_tfnegpjtnome",GXType.VarChar,80,0) ,
          new ParDef("AV131Core_negociopjwwds_25_tfnegpjtnome_sel",GXType.VarChar,80,0) ,
          new ParDef("lV132Core_negociopjwwds_26_tfnegagcnome",GXType.VarChar,80,0) ,
          new ParDef("AV133Core_negociopjwwds_27_tfnegagcnome_sel",GXType.VarChar,80,0) ,
          new ParDef("AV134Core_negociopjwwds_28_tfnegvaloratualizado",GXType.Number,16,2) ,
          new ParDef("AV135Core_negociopjwwds_29_tfnegvaloratualizado_to",GXType.Number,16,2) ,
          new ParDef("AV136Core_negociopjwwds_30_tfneginsdata",GXType.Date,8,0) ,
          new ParDef("AV137Core_negociopjwwds_31_tfneginsdata_to",GXType.Date,8,0) ,
          new ParDef("lV138Core_negociopjwwds_32_tfneginsusunome",GXType.VarChar,80,0) ,
          new ParDef("AV139Core_negociopjwwds_33_tfneginsusunome_sel",GXType.VarChar,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("H003X2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003X2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H003X3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003X3,1, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(3);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((string[]) buf[7])[0] = rslt.getString(6, 40);
                ((bool[]) buf[8])[0] = rslt.wasNull(6);
                ((string[]) buf[9])[0] = rslt.getVarchar(7);
                ((string[]) buf[10])[0] = rslt.getVarchar(8);
                ((int[]) buf[11])[0] = rslt.getInt(9);
                ((long[]) buf[12])[0] = rslt.getLong(10);
                ((string[]) buf[13])[0] = rslt.getVarchar(11);
                ((string[]) buf[14])[0] = rslt.getVarchar(12);
                ((Guid[]) buf[15])[0] = rslt.getGuid(13);
                ((string[]) buf[16])[0] = rslt.getVarchar(14);
                ((Guid[]) buf[17])[0] = rslt.getGuid(15);
                ((string[]) buf[18])[0] = rslt.getVarchar(16);
                ((string[]) buf[19])[0] = rslt.getString(17, 40);
                ((bool[]) buf[20])[0] = rslt.wasNull(17);
                ((DateTime[]) buf[21])[0] = rslt.getGXDateTime(18, true);
                ((DateTime[]) buf[22])[0] = rslt.getGXDateTime(19);
                ((long[]) buf[23])[0] = rslt.getLong(20);
                ((Guid[]) buf[24])[0] = rslt.getGuid(21);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
