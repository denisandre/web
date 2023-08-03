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
   public class documentoww : GXDataArea
   {
      public documentoww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public documentoww( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_DocOrigem ,
                           string aP1_DocOrigemID )
      {
         this.AV66DocOrigem = aP0_DocOrigem;
         this.AV67DocOrigemID = aP1_DocOrigemID;
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
         cmbavGridactions = new GXCombobox();
         chkDocContrato = new GXCheckbox();
         chkDocAssinado = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "DocOrigem");
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
               gxfirstwebparm = GetFirstPar( "DocOrigem");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "DocOrigem");
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
         nRC_GXsfl_138 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_138"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_138_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_138_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_138_idx = GetPar( "sGXsfl_138_idx");
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
         AV20DocVersao1 = (short)(Math.Round(NumberUtil.Val( GetPar( "DocVersao1"), "."), 18, MidpointRounding.ToEven));
         AV21DocTipoSigla1 = GetPar( "DocTipoSigla1");
         cmbavDynamicfiltersselector2.FromJSonString( GetNextPar( ));
         AV23DynamicFiltersSelector2 = GetPar( "DynamicFiltersSelector2");
         cmbavDynamicfiltersoperator2.FromJSonString( GetNextPar( ));
         AV24DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator2"), "."), 18, MidpointRounding.ToEven));
         AV25DocVersao2 = (short)(Math.Round(NumberUtil.Val( GetPar( "DocVersao2"), "."), 18, MidpointRounding.ToEven));
         AV26DocTipoSigla2 = GetPar( "DocTipoSigla2");
         cmbavDynamicfiltersselector3.FromJSonString( GetNextPar( ));
         AV28DynamicFiltersSelector3 = GetPar( "DynamicFiltersSelector3");
         cmbavDynamicfiltersoperator3.FromJSonString( GetNextPar( ));
         AV29DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator3"), "."), 18, MidpointRounding.ToEven));
         AV30DocVersao3 = (short)(Math.Round(NumberUtil.Val( GetPar( "DocVersao3"), "."), 18, MidpointRounding.ToEven));
         AV31DocTipoSigla3 = GetPar( "DocTipoSigla3");
         AV66DocOrigem = GetPar( "DocOrigem");
         AV67DocOrigemID = GetPar( "DocOrigemID");
         AV43ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV22DynamicFiltersEnabled2 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled2"));
         AV27DynamicFiltersEnabled3 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled3"));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV38ColumnsSelector);
         AV80Pgmname = GetPar( "Pgmname");
         AV68DocOrigem_Filtro = GetPar( "DocOrigem_Filtro");
         AV69DocOrigemID_Filtro = GetPar( "DocOrigemID_Filtro");
         AV46TFDocTipoNome = GetPar( "TFDocTipoNome");
         AV47TFDocTipoNome_Sel = GetPar( "TFDocTipoNome_Sel");
         AV44TFDocNome = GetPar( "TFDocNome");
         AV45TFDocNome_Sel = GetPar( "TFDocNome_Sel");
         AV74TFDocVersao = (short)(Math.Round(NumberUtil.Val( GetPar( "TFDocVersao"), "."), 18, MidpointRounding.ToEven));
         AV75TFDocVersao_To = (short)(Math.Round(NumberUtil.Val( GetPar( "TFDocVersao_To"), "."), 18, MidpointRounding.ToEven));
         AV48TFDocInsDataHora = context.localUtil.ParseDTimeParm( GetPar( "TFDocInsDataHora"));
         AV49TFDocInsDataHora_To = context.localUtil.ParseDTimeParm( GetPar( "TFDocInsDataHora_To"));
         AV72TFDocContrato_Sel = (short)(Math.Round(NumberUtil.Val( GetPar( "TFDocContrato_Sel"), "."), 18, MidpointRounding.ToEven));
         AV73TFDocAssinado_Sel = (short)(Math.Round(NumberUtil.Val( GetPar( "TFDocAssinado_Sel"), "."), 18, MidpointRounding.ToEven));
         AV14OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV15OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV11GridState);
         AV33DynamicFiltersIgnoreFirst = StringUtil.StrToBool( GetPar( "DynamicFiltersIgnoreFirst"));
         AV32DynamicFiltersRemoving = StringUtil.StrToBool( GetPar( "DynamicFiltersRemoving"));
         AV61IsAuthorized_Update = StringUtil.StrToBool( GetPar( "IsAuthorized_Update"));
         AV62IsAuthorized_Delete = StringUtil.StrToBool( GetPar( "IsAuthorized_Delete"));
         AV76IsAuthorized_NovaVersao = StringUtil.StrToBool( GetPar( "IsAuthorized_NovaVersao"));
         AV70IsAuthorized_DocNome = StringUtil.StrToBool( GetPar( "IsAuthorized_DocNome"));
         AV65IsAuthorized_Insert = StringUtil.StrToBool( GetPar( "IsAuthorized_Insert"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20DocVersao1, AV21DocTipoSigla1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25DocVersao2, AV26DocTipoSigla2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV30DocVersao3, AV31DocTipoSigla3, AV66DocOrigem, AV67DocOrigemID, AV43ManageFiltersExecutionStep, AV22DynamicFiltersEnabled2, AV27DynamicFiltersEnabled3, AV38ColumnsSelector, AV80Pgmname, AV68DocOrigem_Filtro, AV69DocOrigemID_Filtro, AV46TFDocTipoNome, AV47TFDocTipoNome_Sel, AV44TFDocNome, AV45TFDocNome_Sel, AV74TFDocVersao, AV75TFDocVersao_To, AV48TFDocInsDataHora, AV49TFDocInsDataHora_To, AV72TFDocContrato_Sel, AV73TFDocAssinado_Sel, AV14OrderedBy, AV15OrderedDsc, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV61IsAuthorized_Update, AV62IsAuthorized_Delete, AV76IsAuthorized_NovaVersao, AV70IsAuthorized_DocNome, AV65IsAuthorized_Insert) ;
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
            return "documentoww_Execute" ;
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
         PA5C2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START5C2( ) ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "core.documentoww.aspx"+UrlEncode(StringUtil.RTrim(AV66DocOrigem)) + "," + UrlEncode(StringUtil.RTrim(AV67DocOrigemID));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("core.documentoww.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV80Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV80Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV61IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV61IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV62IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV62IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_NOVAVERSAO", AV76IsAuthorized_NovaVersao);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_NOVAVERSAO", GetSecureSignedToken( "", AV76IsAuthorized_NovaVersao, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DOCNOME", AV70IsAuthorized_DocNome);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DOCNOME", GetSecureSignedToken( "", AV70IsAuthorized_DocNome, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV65IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV65IsAuthorized_Insert, context));
         GxWebStd.gx_hidden_field( context, "gxhash_vDOCORIGEM", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV66DocOrigem, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vDOCORIGEMID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV67DocOrigemID, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vFILTERFULLTEXT", AV17FilterFullText);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR1", AV18DynamicFiltersSelector1);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19DynamicFiltersOperator1), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vDOCVERSAO1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20DocVersao1), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vDOCTIPOSIGLA1", AV21DocTipoSigla1);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR2", AV23DynamicFiltersSelector2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24DynamicFiltersOperator2), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vDOCVERSAO2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25DocVersao2), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vDOCTIPOSIGLA2", AV26DocTipoSigla2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR3", AV28DynamicFiltersSelector3);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV29DynamicFiltersOperator3), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vDOCVERSAO3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV30DocVersao3), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vDOCTIPOSIGLA3", AV31DocTipoSigla3);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_138", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_138), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV41ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV41ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV57GridCurrentPage), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV58GridPageCount), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV59GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAGEXPORTDATA", AV63AGExportData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAGEXPORTDATA", AV63AGExportData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV53DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV53DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCOLUMNSSELECTOR", AV38ColumnsSelector);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCOLUMNSSELECTOR", AV38ColumnsSelector);
         }
         GxWebStd.gx_hidden_field( context, "vDDO_DOCINSDATAHORAAUXDATE", context.localUtil.DToC( AV50DDO_DocInsDataHoraAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_DOCINSDATAHORAAUXDATETO", context.localUtil.DToC( AV51DDO_DocInsDataHoraAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV43ManageFiltersExecutionStep), 1, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED2", AV22DynamicFiltersEnabled2);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED3", AV27DynamicFiltersEnabled3);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV80Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV80Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTFDOCTIPONOME", AV46TFDocTipoNome);
         GxWebStd.gx_hidden_field( context, "vTFDOCTIPONOME_SEL", AV47TFDocTipoNome_Sel);
         GxWebStd.gx_hidden_field( context, "vTFDOCNOME", AV44TFDocNome);
         GxWebStd.gx_hidden_field( context, "vTFDOCNOME_SEL", AV45TFDocNome_Sel);
         GxWebStd.gx_hidden_field( context, "vTFDOCVERSAO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV74TFDocVersao), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFDOCVERSAO_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV75TFDocVersao_To), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFDOCINSDATAHORA", context.localUtil.TToC( AV48TFDocInsDataHora, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vTFDOCINSDATAHORA_TO", context.localUtil.TToC( AV49TFDocInsDataHora_To, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vTFDOCCONTRATO_SEL", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV72TFDocContrato_Sel), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFDOCASSINADO_SEL", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV73TFDocAssinado_Sel), 1, 0, ",", "")));
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
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV61IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV61IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV62IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV62IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_NOVAVERSAO", AV76IsAuthorized_NovaVersao);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_NOVAVERSAO", GetSecureSignedToken( "", AV76IsAuthorized_NovaVersao, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DOCNOME", AV70IsAuthorized_DocNome);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DOCNOME", GetSecureSignedToken( "", AV70IsAuthorized_DocNome, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDTDOCUMENTO", AV77sdtDocumento);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDTDOCUMENTO", AV77sdtDocumento);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV65IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV65IsAuthorized_Insert, context));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEOPORTUNIDADE_Width", StringUtil.RTrim( Dvpanel_tableoportunidade_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEOPORTUNIDADE_Autowidth", StringUtil.BoolToStr( Dvpanel_tableoportunidade_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEOPORTUNIDADE_Autoheight", StringUtil.BoolToStr( Dvpanel_tableoportunidade_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEOPORTUNIDADE_Cls", StringUtil.RTrim( Dvpanel_tableoportunidade_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEOPORTUNIDADE_Title", StringUtil.RTrim( Dvpanel_tableoportunidade_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEOPORTUNIDADE_Collapsible", StringUtil.BoolToStr( Dvpanel_tableoportunidade_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEOPORTUNIDADE_Collapsed", StringUtil.BoolToStr( Dvpanel_tableoportunidade_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEOPORTUNIDADE_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tableoportunidade_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEOPORTUNIDADE_Iconposition", StringUtil.RTrim( Dvpanel_tableoportunidade_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEOPORTUNIDADE_Autoscroll", StringUtil.BoolToStr( Dvpanel_tableoportunidade_Autoscroll));
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
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistfixedvalues", StringUtil.RTrim( Ddo_grid_Datalistfixedvalues));
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
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_NOVAVERSAO_Title", StringUtil.RTrim( Dvelop_confirmpanel_novaversao_Title));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_NOVAVERSAO_Confirmationtext", StringUtil.RTrim( Dvelop_confirmpanel_novaversao_Confirmationtext));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_NOVAVERSAO_Yesbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_novaversao_Yesbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_NOVAVERSAO_Nobuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_novaversao_Nobuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_NOVAVERSAO_Cancelbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_novaversao_Cancelbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_NOVAVERSAO_Yesbuttonposition", StringUtil.RTrim( Dvelop_confirmpanel_novaversao_Yesbuttonposition));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_NOVAVERSAO_Confirmtype", StringUtil.RTrim( Dvelop_confirmpanel_novaversao_Confirmtype));
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
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_NOVAVERSAO_Result", StringUtil.RTrim( Dvelop_confirmpanel_novaversao_Result));
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
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_NOVAVERSAO_Result", StringUtil.RTrim( Dvelop_confirmpanel_novaversao_Result));
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
         if ( ! ( WebComp_Wcnegociopjgeneral == null ) )
         {
            WebComp_Wcnegociopjgeneral.componentjscripts();
         }
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
            WE5C2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT5C2( ) ;
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "core.documentoww.aspx"+UrlEncode(StringUtil.RTrim(AV66DocOrigem)) + "," + UrlEncode(StringUtil.RTrim(AV67DocOrigemID));
         return formatLink("core.documentoww.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "core.DocumentoWW" ;
      }

      public override string GetPgmdesc( )
      {
         return " Documento" ;
      }

      protected void WB5C0( )
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
            GxWebStd.gx_div_start( context, divDvpanel_tableoportunidade_cell_Internalname, 1, 0, "px", 0, "px", divDvpanel_tableoportunidade_cell_Class, "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_tableoportunidade.SetProperty("Width", Dvpanel_tableoportunidade_Width);
            ucDvpanel_tableoportunidade.SetProperty("AutoWidth", Dvpanel_tableoportunidade_Autowidth);
            ucDvpanel_tableoportunidade.SetProperty("AutoHeight", Dvpanel_tableoportunidade_Autoheight);
            ucDvpanel_tableoportunidade.SetProperty("Cls", Dvpanel_tableoportunidade_Cls);
            ucDvpanel_tableoportunidade.SetProperty("Title", Dvpanel_tableoportunidade_Title);
            ucDvpanel_tableoportunidade.SetProperty("Collapsible", Dvpanel_tableoportunidade_Collapsible);
            ucDvpanel_tableoportunidade.SetProperty("Collapsed", Dvpanel_tableoportunidade_Collapsed);
            ucDvpanel_tableoportunidade.SetProperty("ShowCollapseIcon", Dvpanel_tableoportunidade_Showcollapseicon);
            ucDvpanel_tableoportunidade.SetProperty("IconPosition", Dvpanel_tableoportunidade_Iconposition);
            ucDvpanel_tableoportunidade.SetProperty("AutoScroll", Dvpanel_tableoportunidade_Autoscroll);
            ucDvpanel_tableoportunidade.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tableoportunidade_Internalname, "DVPANEL_TABLEOPORTUNIDADEContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLEOPORTUNIDADEContainer"+"TableOportunidade"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableoportunidade_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0014"+"", StringUtil.RTrim( WebComp_Wcnegociopjgeneral_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0014"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( bGXsfl_138_Refreshing )
               {
                  if ( StringUtil.Len( WebComp_Wcnegociopjgeneral_Component) != 0 )
                  {
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWcnegociopjgeneral), StringUtil.Lower( WebComp_Wcnegociopjgeneral_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0014"+"");
                     }
                     WebComp_Wcnegociopjgeneral.componentdraw();
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWcnegociopjgeneral), StringUtil.Lower( WebComp_Wcnegociopjgeneral_Component)) != 0 )
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
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-xs hidden-sm hidden-md hidden-lg", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavDocorigem_filtro_Internalname, "Doc Origem_Filtro", "col-sm-3 InvisibleLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'" + sGXsfl_138_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDocorigem_filtro_Internalname, AV68DocOrigem_Filtro, StringUtil.RTrim( context.localUtil.Format( AV68DocOrigem_Filtro, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,18);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDocorigem_filtro_Jsonclick, 0, "Invisible", "", "", "", "", 1, edtavDocorigem_filtro_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\DocumentoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-xs hidden-sm hidden-md hidden-lg", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavDocorigemid_filtro_Internalname, "Doc Origem ID_Filtro", "col-sm-3 InvisibleLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'" + sGXsfl_138_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDocorigemid_filtro_Internalname, AV69DocOrigemID_Filtro, StringUtil.RTrim( context.localUtil.Format( AV69DocOrigemID_Filtro, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDocorigemid_filtro_Jsonclick, 0, "Invisible", "", "", "", "", 1, edtavDocorigemid_filtro_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\DocumentoWW.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
            ClassString = "BtnDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(138), 3, 0)+","+"null"+");", "Voltar", bttBtncancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\DocumentoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(138), 3, 0)+","+"null"+");", "Incluir", bttBtninsert_Jsonclick, 5, "Incluir", "", StyleString, ClassString, bttBtninsert_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\DocumentoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
            ClassString = "ColumnsSelector";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnagexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(138), 3, 0)+","+"null"+");", "Exportar", bttBtnagexport_Jsonclick, 0, "Exportar", "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\DocumentoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
            ClassString = "hidden-xs";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtneditcolumns_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(138), 3, 0)+","+"null"+");", "Selecionar colunas", bttBtneditcolumns_Jsonclick, 0, "Selecionar colunas", "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\DocumentoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnsubscriptions_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(138), 3, 0)+","+"null"+");", "", bttBtnsubscriptions_Jsonclick, 0, "Assinaturas", "", StyleString, ClassString, bttBtnsubscriptions_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\DocumentoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            wb_table1_43_5C2( true) ;
         }
         else
         {
            wb_table1_43_5C2( false) ;
         }
         return  ;
      }

      protected void wb_table1_43_5C2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix1_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_core\\DocumentoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector1_Internalname, "Dynamic Filters Selector1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'" + sGXsfl_138_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector1, cmbavDynamicfiltersselector1_Internalname, StringUtil.RTrim( AV18DynamicFiltersSelector1), 1, cmbavDynamicfiltersselector1_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR1.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,63);\"", "", true, 0, "HLP_core\\DocumentoWW.htm");
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", (string)(cmbavDynamicfiltersselector1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle1_Internalname, "valor", "", "", lblDynamicfiltersmiddle1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_core\\DocumentoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            wb_table2_67_5C2( true) ;
         }
         else
         {
            wb_table2_67_5C2( false) ;
         }
         return  ;
      }

      protected void wb_table2_67_5C2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix2_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_core\\DocumentoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector2_Internalname, "Dynamic Filters Selector2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'" + sGXsfl_138_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector2, cmbavDynamicfiltersselector2_Internalname, StringUtil.RTrim( AV23DynamicFiltersSelector2), 1, cmbavDynamicfiltersselector2_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR2.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,88);\"", "", true, 0, "HLP_core\\DocumentoWW.htm");
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", (string)(cmbavDynamicfiltersselector2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle2_Internalname, "valor", "", "", lblDynamicfiltersmiddle2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_core\\DocumentoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table3_92_5C2( true) ;
         }
         else
         {
            wb_table3_92_5C2( false) ;
         }
         return  ;
      }

      protected void wb_table3_92_5C2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix3_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_core\\DocumentoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector3_Internalname, "Dynamic Filters Selector3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 113,'',false,'" + sGXsfl_138_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector3, cmbavDynamicfiltersselector3_Internalname, StringUtil.RTrim( AV28DynamicFiltersSelector3), 1, cmbavDynamicfiltersselector3_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR3.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,113);\"", "", true, 0, "HLP_core\\DocumentoWW.htm");
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV28DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", (string)(cmbavDynamicfiltersselector3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle3_Internalname, "valor", "", "", lblDynamicfiltersmiddle3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_core\\DocumentoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table4_117_5C2( true) ;
         }
         else
         {
            wb_table4_117_5C2( false) ;
         }
         return  ;
      }

      protected void wb_table4_117_5C2e( bool wbgen )
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
            StartGridControl138( ) ;
         }
         if ( wbEnd == 138 )
         {
            wbEnd = 0;
            nRC_GXsfl_138 = (int)(nGXsfl_138_idx-1);
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV57GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV58GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV59GridAppliedFilters);
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
               GxWebStd.gx_hidden_field( context, "W0157"+"", StringUtil.RTrim( WebComp_Grid_dwc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0157"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( bGXsfl_138_Refreshing )
               {
                  if ( StringUtil.Len( WebComp_Grid_dwc_Component) != 0 )
                  {
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldGrid_dwc), StringUtil.Lower( WebComp_Grid_dwc_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0157"+"");
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
            ucDdo_agexport.SetProperty("DropDownOptionsData", AV63AGExportData);
            ucDdo_agexport.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_agexport_Internalname, "DDO_AGEXPORTContainer");
            /* User Defined Control */
            ucDdc_subscriptions.SetProperty("IconType", Ddc_subscriptions_Icontype);
            ucDdc_subscriptions.SetProperty("Icon", Ddc_subscriptions_Icon);
            ucDdc_subscriptions.SetProperty("Caption", Ddc_subscriptions_Caption);
            ucDdc_subscriptions.SetProperty("Tooltip", Ddc_subscriptions_Tooltip);
            ucDdc_subscriptions.SetProperty("Cls", Ddc_subscriptions_Cls);
            ucDdc_subscriptions.Render(context, "dvelop.gxbootstrap.ddcomponent", Ddc_subscriptions_Internalname, "DDC_SUBSCRIPTIONSContainer");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblJsdynamicfilters_Internalname, lblJsdynamicfilters_Caption, "", "", lblJsdynamicfilters_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_core\\DocumentoWW.htm");
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
            ucDdo_grid.SetProperty("DataListFixedValues", Ddo_grid_Datalistfixedvalues);
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("Format", Ddo_grid_Format);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV53DDO_TitleSettingsIcons);
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
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsTitleSettingsIcons", AV53DDO_TitleSettingsIcons);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsData", AV38ColumnsSelector);
            ucDdo_gridcolumnsselector.Render(context, "dvelop.gxbootstrap.ddogridcolumnsselector", Ddo_gridcolumnsselector_Internalname, "DDO_GRIDCOLUMNSSELECTORContainer");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtavDocorigem_Internalname, AV66DocOrigem, StringUtil.RTrim( context.localUtil.Format( AV66DocOrigem, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDocorigem_Jsonclick, 0, "Attribute", "", "", "", "", edtavDocorigem_Visible, 0, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\DocumentoWW.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtavDocorigemid_Internalname, AV67DocOrigemID, StringUtil.RTrim( context.localUtil.Format( AV67DocOrigemID, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDocorigemid_Jsonclick, 0, "Attribute", "", "", "", "", edtavDocorigemid_Visible, 0, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\DocumentoWW.htm");
            wb_table5_169_5C2( true) ;
         }
         else
         {
            wb_table5_169_5C2( false) ;
         }
         return  ;
      }

      protected void wb_table5_169_5C2e( bool wbgen )
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
               GxWebStd.gx_hidden_field( context, "W0176"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0176"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( bGXsfl_138_Refreshing )
               {
                  if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                  {
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0176"+"");
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
            GxWebStd.gx_div_start( context, divDdo_docinsdatahoraauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 178,'',false,'" + sGXsfl_138_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_docinsdatahoraauxdatetext_Internalname, AV52DDO_DocInsDataHoraAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV52DDO_DocInsDataHoraAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,178);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_docinsdatahoraauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\DocumentoWW.htm");
            /* User Defined Control */
            ucTfdocinsdatahora_rangepicker.SetProperty("Start Date", AV50DDO_DocInsDataHoraAuxDate);
            ucTfdocinsdatahora_rangepicker.SetProperty("End Date", AV51DDO_DocInsDataHoraAuxDateTo);
            ucTfdocinsdatahora_rangepicker.Render(context, "wwp.daterangepicker", Tfdocinsdatahora_rangepicker_Internalname, "TFDOCINSDATAHORA_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 138 )
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

      protected void START5C2( )
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
            Form.Meta.addItem("description", " Documento", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP5C0( ) ;
      }

      protected void WS5C2( )
      {
         START5C2( ) ;
         EVT5C2( ) ;
      }

      protected void EVT5C2( )
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
                              E115C2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E125C2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E135C2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_AGEXPORT.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E145C2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDC_SUBSCRIPTIONS.ONLOADCOMPONENT") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E155C2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E165C2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E175C2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DVELOP_CONFIRMPANEL_NOVAVERSAO.CLOSE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E185C2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters1' */
                              E195C2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters2' */
                              E205C2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS3'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters3' */
                              E215C2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E225C2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters1' */
                              E235C2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR1.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E245C2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters2' */
                              E255C2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR2.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E265C2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR3.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E275C2 ();
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
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "VGRIDACTIONS.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 25), "VDETAILWEBCOMPONENT.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 25), "VDETAILWEBCOMPONENT.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "VGRIDACTIONS.CLICK") == 0 ) )
                           {
                              nGXsfl_138_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_138_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_138_idx), 4, 0), 4, "0");
                              SubsflControlProps_1382( ) ;
                              AV71DetailWebComponent = cgiGet( edtavDetailwebcomponent_Internalname);
                              AssignAttri("", false, edtavDetailwebcomponent_Internalname, AV71DetailWebComponent);
                              cmbavGridactions.Name = cmbavGridactions_Internalname;
                              cmbavGridactions.CurrentValue = cgiGet( cmbavGridactions_Internalname);
                              AV60GridActions = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavGridactions_Internalname), "."), 18, MidpointRounding.ToEven));
                              AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV60GridActions), 4, 0));
                              A289DocID = StringUtil.StrToGuid( cgiGet( edtDocID_Internalname));
                              A290DocOrigem = cgiGet( edtDocOrigem_Internalname);
                              A291DocOrigemID = cgiGet( edtDocOrigemID_Internalname);
                              A148DocTipoNome = StringUtil.Upper( cgiGet( edtDocTipoNome_Internalname));
                              A305DocNome = StringUtil.Upper( cgiGet( edtDocNome_Internalname));
                              A325DocVersao = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtDocVersao_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A294DocInsDataHora = context.localUtil.CToT( cgiGet( edtDocInsDataHora_Internalname), 0);
                              A480DocContrato = StringUtil.StrToBool( cgiGet( chkDocContrato_Internalname));
                              A481DocAssinado = StringUtil.StrToBool( cgiGet( chkDocAssinado_Internalname));
                              A146DocTipoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtDocTipoID_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A326DocVersaoIDPai = StringUtil.StrToGuid( cgiGet( edtDocVersaoIDPai_Internalname));
                              n326DocVersaoIDPai = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E285C2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E295C2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E305C2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VGRIDACTIONS.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E315C2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VDETAILWEBCOMPONENT.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E325C2 ();
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
                                       /* Set Refresh If Docversao1 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDOCVERSAO1"), ",", ".") != Convert.ToDecimal( AV20DocVersao1 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Doctiposigla1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDOCTIPOSIGLA1"), AV21DocTipoSigla1) != 0 )
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
                                       /* Set Refresh If Docversao2 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDOCVERSAO2"), ",", ".") != Convert.ToDecimal( AV25DocVersao2 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Doctiposigla2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDOCTIPOSIGLA2"), AV26DocTipoSigla2) != 0 )
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
                                       /* Set Refresh If Docversao3 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDOCVERSAO3"), ",", ".") != Convert.ToDecimal( AV30DocVersao3 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Doctiposigla3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDOCTIPOSIGLA3"), AV31DocTipoSigla3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                       }
                                       dynload_actions( ) ;
                                    }
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
                        if ( nCmpId == 14 )
                        {
                           OldWcnegociopjgeneral = cgiGet( "W0014");
                           if ( ( StringUtil.Len( OldWcnegociopjgeneral) == 0 ) || ( StringUtil.StrCmp(OldWcnegociopjgeneral, WebComp_Wcnegociopjgeneral_Component) != 0 ) )
                           {
                              WebComp_Wcnegociopjgeneral = getWebComponent(GetType(), "GeneXus.Programs", OldWcnegociopjgeneral, new Object[] {context} );
                              WebComp_Wcnegociopjgeneral.ComponentInit();
                              WebComp_Wcnegociopjgeneral.Name = "OldWcnegociopjgeneral";
                              WebComp_Wcnegociopjgeneral_Component = OldWcnegociopjgeneral;
                           }
                           if ( StringUtil.Len( WebComp_Wcnegociopjgeneral_Component) != 0 )
                           {
                              WebComp_Wcnegociopjgeneral.componentprocess("W0014", "", sEvt);
                           }
                           WebComp_Wcnegociopjgeneral_Component = OldWcnegociopjgeneral;
                        }
                        else if ( nCmpId == 157 )
                        {
                           OldGrid_dwc = cgiGet( "W0157");
                           if ( ( StringUtil.Len( OldGrid_dwc) == 0 ) || ( StringUtil.StrCmp(OldGrid_dwc, WebComp_Grid_dwc_Component) != 0 ) )
                           {
                              WebComp_Grid_dwc = getWebComponent(GetType(), "GeneXus.Programs", OldGrid_dwc, new Object[] {context} );
                              WebComp_Grid_dwc.ComponentInit();
                              WebComp_Grid_dwc.Name = "OldGrid_dwc";
                              WebComp_Grid_dwc_Component = OldGrid_dwc;
                           }
                           if ( StringUtil.Len( WebComp_Grid_dwc_Component) != 0 )
                           {
                              WebComp_Grid_dwc.componentprocess("W0157", "", sEvt);
                           }
                           WebComp_Grid_dwc_Component = OldGrid_dwc;
                        }
                        else if ( nCmpId == 176 )
                        {
                           OldWwpaux_wc = cgiGet( "W0176");
                           if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                           {
                              WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                              WebComp_Wwpaux_wc.ComponentInit();
                              WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                              WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                           }
                           if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                           {
                              WebComp_Wwpaux_wc.componentprocess("W0176", "", sEvt);
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

      protected void WE5C2( )
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

      protected void PA5C2( )
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
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "core.documentoww.aspx")), "core.documentoww.aspx") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "core.documentoww.aspx")))) ;
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
                  gxfirstwebparm = GetFirstPar( "DocOrigem");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV66DocOrigem = gxfirstwebparm;
                     AssignAttri("", false, "AV66DocOrigem", AV66DocOrigem);
                     GxWebStd.gx_hidden_field( context, "gxhash_vDOCORIGEM", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV66DocOrigem, "")), context));
                     if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
                     {
                        AV67DocOrigemID = GetPar( "DocOrigemID");
                        AssignAttri("", false, "AV67DocOrigemID", AV67DocOrigemID);
                        GxWebStd.gx_hidden_field( context, "gxhash_vDOCORIGEMID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV67DocOrigemID, "")), context));
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
               GX_FocusControl = edtavDocorigem_filtro_Internalname;
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
         SubsflControlProps_1382( ) ;
         while ( nGXsfl_138_idx <= nRC_GXsfl_138 )
         {
            sendrow_1382( ) ;
            nGXsfl_138_idx = ((subGrid_Islastpage==1)&&(nGXsfl_138_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_138_idx+1);
            sGXsfl_138_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_138_idx), 4, 0), 4, "0");
            SubsflControlProps_1382( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       string AV17FilterFullText ,
                                       string AV18DynamicFiltersSelector1 ,
                                       short AV19DynamicFiltersOperator1 ,
                                       short AV20DocVersao1 ,
                                       string AV21DocTipoSigla1 ,
                                       string AV23DynamicFiltersSelector2 ,
                                       short AV24DynamicFiltersOperator2 ,
                                       short AV25DocVersao2 ,
                                       string AV26DocTipoSigla2 ,
                                       string AV28DynamicFiltersSelector3 ,
                                       short AV29DynamicFiltersOperator3 ,
                                       short AV30DocVersao3 ,
                                       string AV31DocTipoSigla3 ,
                                       string AV66DocOrigem ,
                                       string AV67DocOrigemID ,
                                       short AV43ManageFiltersExecutionStep ,
                                       bool AV22DynamicFiltersEnabled2 ,
                                       bool AV27DynamicFiltersEnabled3 ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV38ColumnsSelector ,
                                       string AV80Pgmname ,
                                       string AV68DocOrigem_Filtro ,
                                       string AV69DocOrigemID_Filtro ,
                                       string AV46TFDocTipoNome ,
                                       string AV47TFDocTipoNome_Sel ,
                                       string AV44TFDocNome ,
                                       string AV45TFDocNome_Sel ,
                                       short AV74TFDocVersao ,
                                       short AV75TFDocVersao_To ,
                                       DateTime AV48TFDocInsDataHora ,
                                       DateTime AV49TFDocInsDataHora_To ,
                                       short AV72TFDocContrato_Sel ,
                                       short AV73TFDocAssinado_Sel ,
                                       short AV14OrderedBy ,
                                       bool AV15OrderedDsc ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ,
                                       bool AV33DynamicFiltersIgnoreFirst ,
                                       bool AV32DynamicFiltersRemoving ,
                                       bool AV61IsAuthorized_Update ,
                                       bool AV62IsAuthorized_Delete ,
                                       bool AV76IsAuthorized_NovaVersao ,
                                       bool AV70IsAuthorized_DocNome ,
                                       bool AV65IsAuthorized_Insert )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF5C2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_DOCID", GetSecureSignedToken( "", A289DocID, context));
         GxWebStd.gx_hidden_field( context, "DOCID", A289DocID.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_DOCTIPOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A146DocTipoID), "ZZZ,ZZZ,ZZ9"), context));
         GxWebStd.gx_hidden_field( context, "DOCTIPOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A146DocTipoID), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_DOCVERSAOIDPAI", GetSecureSignedToken( "", A326DocVersaoIDPai, context));
         GxWebStd.gx_hidden_field( context, "DOCVERSAOIDPAI", A326DocVersaoIDPai.ToString());
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
         RF5C2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV80Pgmname = "core.DocumentoWW";
         edtavDetailwebcomponent_Enabled = 0;
         AssignProp("", false, edtavDetailwebcomponent_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDetailwebcomponent_Enabled), 5, 0), !bGXsfl_138_Refreshing);
      }

      protected void RF5C2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 138;
         /* Execute user event: Refresh */
         E295C2 ();
         nGXsfl_138_idx = 1;
         sGXsfl_138_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_138_idx), 4, 0), 4, "0");
         SubsflControlProps_1382( ) ;
         bGXsfl_138_Refreshing = true;
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
               if ( StringUtil.Len( WebComp_Wcnegociopjgeneral_Component) != 0 )
               {
                  WebComp_Wcnegociopjgeneral.componentstart();
               }
            }
         }
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
            SubsflControlProps_1382( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV83Core_documentowwds_3_filterfulltext ,
                                                 AV84Core_documentowwds_4_dynamicfiltersselector1 ,
                                                 AV85Core_documentowwds_5_dynamicfiltersoperator1 ,
                                                 AV86Core_documentowwds_6_docversao1 ,
                                                 AV87Core_documentowwds_7_doctiposigla1 ,
                                                 AV88Core_documentowwds_8_dynamicfiltersenabled2 ,
                                                 AV89Core_documentowwds_9_dynamicfiltersselector2 ,
                                                 AV90Core_documentowwds_10_dynamicfiltersoperator2 ,
                                                 AV91Core_documentowwds_11_docversao2 ,
                                                 AV92Core_documentowwds_12_doctiposigla2 ,
                                                 AV93Core_documentowwds_13_dynamicfiltersenabled3 ,
                                                 AV94Core_documentowwds_14_dynamicfiltersselector3 ,
                                                 AV95Core_documentowwds_15_dynamicfiltersoperator3 ,
                                                 AV96Core_documentowwds_16_docversao3 ,
                                                 AV97Core_documentowwds_17_doctiposigla3 ,
                                                 AV99Core_documentowwds_19_tfdoctiponome_sel ,
                                                 AV98Core_documentowwds_18_tfdoctiponome ,
                                                 AV101Core_documentowwds_21_tfdocnome_sel ,
                                                 AV100Core_documentowwds_20_tfdocnome ,
                                                 AV102Core_documentowwds_22_tfdocversao ,
                                                 AV103Core_documentowwds_23_tfdocversao_to ,
                                                 AV104Core_documentowwds_24_tfdocinsdatahora ,
                                                 AV105Core_documentowwds_25_tfdocinsdatahora_to ,
                                                 AV106Core_documentowwds_26_tfdoccontrato_sel ,
                                                 AV107Core_documentowwds_27_tfdocassinado_sel ,
                                                 A148DocTipoNome ,
                                                 A305DocNome ,
                                                 A325DocVersao ,
                                                 A147DocTipoSigla ,
                                                 A294DocInsDataHora ,
                                                 A480DocContrato ,
                                                 A481DocAssinado ,
                                                 AV14OrderedBy ,
                                                 AV15OrderedDsc ,
                                                 A290DocOrigem ,
                                                 AV66DocOrigem ,
                                                 A291DocOrigemID ,
                                                 AV67DocOrigemID ,
                                                 A640DocAtivo } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT,
                                                 TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN,
                                                 TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                                 }
            });
            lV83Core_documentowwds_3_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV83Core_documentowwds_3_filterfulltext), "%", "");
            lV83Core_documentowwds_3_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV83Core_documentowwds_3_filterfulltext), "%", "");
            lV83Core_documentowwds_3_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV83Core_documentowwds_3_filterfulltext), "%", "");
            lV87Core_documentowwds_7_doctiposigla1 = StringUtil.Concat( StringUtil.RTrim( AV87Core_documentowwds_7_doctiposigla1), "%", "");
            lV87Core_documentowwds_7_doctiposigla1 = StringUtil.Concat( StringUtil.RTrim( AV87Core_documentowwds_7_doctiposigla1), "%", "");
            lV92Core_documentowwds_12_doctiposigla2 = StringUtil.Concat( StringUtil.RTrim( AV92Core_documentowwds_12_doctiposigla2), "%", "");
            lV92Core_documentowwds_12_doctiposigla2 = StringUtil.Concat( StringUtil.RTrim( AV92Core_documentowwds_12_doctiposigla2), "%", "");
            lV97Core_documentowwds_17_doctiposigla3 = StringUtil.Concat( StringUtil.RTrim( AV97Core_documentowwds_17_doctiposigla3), "%", "");
            lV97Core_documentowwds_17_doctiposigla3 = StringUtil.Concat( StringUtil.RTrim( AV97Core_documentowwds_17_doctiposigla3), "%", "");
            lV98Core_documentowwds_18_tfdoctiponome = StringUtil.Concat( StringUtil.RTrim( AV98Core_documentowwds_18_tfdoctiponome), "%", "");
            lV100Core_documentowwds_20_tfdocnome = StringUtil.Concat( StringUtil.RTrim( AV100Core_documentowwds_20_tfdocnome), "%", "");
            /* Using cursor H005C2 */
            pr_default.execute(0, new Object[] {AV66DocOrigem, AV67DocOrigemID, lV83Core_documentowwds_3_filterfulltext, lV83Core_documentowwds_3_filterfulltext, lV83Core_documentowwds_3_filterfulltext, AV86Core_documentowwds_6_docversao1, AV86Core_documentowwds_6_docversao1, AV86Core_documentowwds_6_docversao1, lV87Core_documentowwds_7_doctiposigla1, lV87Core_documentowwds_7_doctiposigla1, AV91Core_documentowwds_11_docversao2, AV91Core_documentowwds_11_docversao2, AV91Core_documentowwds_11_docversao2, lV92Core_documentowwds_12_doctiposigla2, lV92Core_documentowwds_12_doctiposigla2, AV96Core_documentowwds_16_docversao3, AV96Core_documentowwds_16_docversao3, AV96Core_documentowwds_16_docversao3, lV97Core_documentowwds_17_doctiposigla3, lV97Core_documentowwds_17_doctiposigla3, lV98Core_documentowwds_18_tfdoctiponome, AV99Core_documentowwds_19_tfdoctiponome_sel, lV100Core_documentowwds_20_tfdocnome, AV101Core_documentowwds_21_tfdocnome_sel, AV102Core_documentowwds_22_tfdocversao, AV103Core_documentowwds_23_tfdocversao_to, AV104Core_documentowwds_24_tfdocinsdatahora, AV105Core_documentowwds_25_tfdocinsdatahora_to, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_138_idx = 1;
            sGXsfl_138_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_138_idx), 4, 0), 4, "0");
            SubsflControlProps_1382( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A640DocAtivo = H005C2_A640DocAtivo[0];
               n640DocAtivo = H005C2_n640DocAtivo[0];
               A147DocTipoSigla = H005C2_A147DocTipoSigla[0];
               A326DocVersaoIDPai = H005C2_A326DocVersaoIDPai[0];
               n326DocVersaoIDPai = H005C2_n326DocVersaoIDPai[0];
               A146DocTipoID = H005C2_A146DocTipoID[0];
               A481DocAssinado = H005C2_A481DocAssinado[0];
               A480DocContrato = H005C2_A480DocContrato[0];
               A294DocInsDataHora = H005C2_A294DocInsDataHora[0];
               A325DocVersao = H005C2_A325DocVersao[0];
               A305DocNome = H005C2_A305DocNome[0];
               A148DocTipoNome = H005C2_A148DocTipoNome[0];
               A291DocOrigemID = H005C2_A291DocOrigemID[0];
               A290DocOrigem = H005C2_A290DocOrigem[0];
               A289DocID = H005C2_A289DocID[0];
               A147DocTipoSigla = H005C2_A147DocTipoSigla[0];
               A148DocTipoNome = H005C2_A148DocTipoNome[0];
               E305C2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 138;
            WB5C0( ) ;
         }
         bGXsfl_138_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes5C2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV80Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV80Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV61IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV61IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV62IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV62IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_NOVAVERSAO", AV76IsAuthorized_NovaVersao);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_NOVAVERSAO", GetSecureSignedToken( "", AV76IsAuthorized_NovaVersao, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DOCNOME", AV70IsAuthorized_DocNome);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DOCNOME", GetSecureSignedToken( "", AV70IsAuthorized_DocNome, context));
         GxWebStd.gx_hidden_field( context, "gxhash_DOCID"+"_"+sGXsfl_138_idx, GetSecureSignedToken( sGXsfl_138_idx, A289DocID, context));
         GxWebStd.gx_hidden_field( context, "gxhash_DOCTIPOID"+"_"+sGXsfl_138_idx, GetSecureSignedToken( sGXsfl_138_idx, context.localUtil.Format( (decimal)(A146DocTipoID), "ZZZ,ZZZ,ZZ9"), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV65IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV65IsAuthorized_Insert, context));
         GxWebStd.gx_hidden_field( context, "gxhash_DOCVERSAOIDPAI"+"_"+sGXsfl_138_idx, GetSecureSignedToken( sGXsfl_138_idx, A326DocVersaoIDPai, context));
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
         AV81Core_documentowwds_1_docorigem_filtro = AV68DocOrigem_Filtro;
         AV82Core_documentowwds_2_docorigemid_filtro = AV69DocOrigemID_Filtro;
         AV83Core_documentowwds_3_filterfulltext = AV17FilterFullText;
         AV84Core_documentowwds_4_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV85Core_documentowwds_5_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV86Core_documentowwds_6_docversao1 = AV20DocVersao1;
         AV87Core_documentowwds_7_doctiposigla1 = AV21DocTipoSigla1;
         AV88Core_documentowwds_8_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV89Core_documentowwds_9_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV90Core_documentowwds_10_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV91Core_documentowwds_11_docversao2 = AV25DocVersao2;
         AV92Core_documentowwds_12_doctiposigla2 = AV26DocTipoSigla2;
         AV93Core_documentowwds_13_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV94Core_documentowwds_14_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV95Core_documentowwds_15_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV96Core_documentowwds_16_docversao3 = AV30DocVersao3;
         AV97Core_documentowwds_17_doctiposigla3 = AV31DocTipoSigla3;
         AV98Core_documentowwds_18_tfdoctiponome = AV46TFDocTipoNome;
         AV99Core_documentowwds_19_tfdoctiponome_sel = AV47TFDocTipoNome_Sel;
         AV100Core_documentowwds_20_tfdocnome = AV44TFDocNome;
         AV101Core_documentowwds_21_tfdocnome_sel = AV45TFDocNome_Sel;
         AV102Core_documentowwds_22_tfdocversao = AV74TFDocVersao;
         AV103Core_documentowwds_23_tfdocversao_to = AV75TFDocVersao_To;
         AV104Core_documentowwds_24_tfdocinsdatahora = AV48TFDocInsDataHora;
         AV105Core_documentowwds_25_tfdocinsdatahora_to = AV49TFDocInsDataHora_To;
         AV106Core_documentowwds_26_tfdoccontrato_sel = AV72TFDocContrato_Sel;
         AV107Core_documentowwds_27_tfdocassinado_sel = AV73TFDocAssinado_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV83Core_documentowwds_3_filterfulltext ,
                                              AV84Core_documentowwds_4_dynamicfiltersselector1 ,
                                              AV85Core_documentowwds_5_dynamicfiltersoperator1 ,
                                              AV86Core_documentowwds_6_docversao1 ,
                                              AV87Core_documentowwds_7_doctiposigla1 ,
                                              AV88Core_documentowwds_8_dynamicfiltersenabled2 ,
                                              AV89Core_documentowwds_9_dynamicfiltersselector2 ,
                                              AV90Core_documentowwds_10_dynamicfiltersoperator2 ,
                                              AV91Core_documentowwds_11_docversao2 ,
                                              AV92Core_documentowwds_12_doctiposigla2 ,
                                              AV93Core_documentowwds_13_dynamicfiltersenabled3 ,
                                              AV94Core_documentowwds_14_dynamicfiltersselector3 ,
                                              AV95Core_documentowwds_15_dynamicfiltersoperator3 ,
                                              AV96Core_documentowwds_16_docversao3 ,
                                              AV97Core_documentowwds_17_doctiposigla3 ,
                                              AV99Core_documentowwds_19_tfdoctiponome_sel ,
                                              AV98Core_documentowwds_18_tfdoctiponome ,
                                              AV101Core_documentowwds_21_tfdocnome_sel ,
                                              AV100Core_documentowwds_20_tfdocnome ,
                                              AV102Core_documentowwds_22_tfdocversao ,
                                              AV103Core_documentowwds_23_tfdocversao_to ,
                                              AV104Core_documentowwds_24_tfdocinsdatahora ,
                                              AV105Core_documentowwds_25_tfdocinsdatahora_to ,
                                              AV106Core_documentowwds_26_tfdoccontrato_sel ,
                                              AV107Core_documentowwds_27_tfdocassinado_sel ,
                                              A148DocTipoNome ,
                                              A305DocNome ,
                                              A325DocVersao ,
                                              A147DocTipoSigla ,
                                              A294DocInsDataHora ,
                                              A480DocContrato ,
                                              A481DocAssinado ,
                                              AV14OrderedBy ,
                                              AV15OrderedDsc ,
                                              A290DocOrigem ,
                                              AV66DocOrigem ,
                                              A291DocOrigemID ,
                                              AV67DocOrigemID ,
                                              A640DocAtivo } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV83Core_documentowwds_3_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV83Core_documentowwds_3_filterfulltext), "%", "");
         lV83Core_documentowwds_3_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV83Core_documentowwds_3_filterfulltext), "%", "");
         lV83Core_documentowwds_3_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV83Core_documentowwds_3_filterfulltext), "%", "");
         lV87Core_documentowwds_7_doctiposigla1 = StringUtil.Concat( StringUtil.RTrim( AV87Core_documentowwds_7_doctiposigla1), "%", "");
         lV87Core_documentowwds_7_doctiposigla1 = StringUtil.Concat( StringUtil.RTrim( AV87Core_documentowwds_7_doctiposigla1), "%", "");
         lV92Core_documentowwds_12_doctiposigla2 = StringUtil.Concat( StringUtil.RTrim( AV92Core_documentowwds_12_doctiposigla2), "%", "");
         lV92Core_documentowwds_12_doctiposigla2 = StringUtil.Concat( StringUtil.RTrim( AV92Core_documentowwds_12_doctiposigla2), "%", "");
         lV97Core_documentowwds_17_doctiposigla3 = StringUtil.Concat( StringUtil.RTrim( AV97Core_documentowwds_17_doctiposigla3), "%", "");
         lV97Core_documentowwds_17_doctiposigla3 = StringUtil.Concat( StringUtil.RTrim( AV97Core_documentowwds_17_doctiposigla3), "%", "");
         lV98Core_documentowwds_18_tfdoctiponome = StringUtil.Concat( StringUtil.RTrim( AV98Core_documentowwds_18_tfdoctiponome), "%", "");
         lV100Core_documentowwds_20_tfdocnome = StringUtil.Concat( StringUtil.RTrim( AV100Core_documentowwds_20_tfdocnome), "%", "");
         /* Using cursor H005C3 */
         pr_default.execute(1, new Object[] {AV66DocOrigem, AV67DocOrigemID, lV83Core_documentowwds_3_filterfulltext, lV83Core_documentowwds_3_filterfulltext, lV83Core_documentowwds_3_filterfulltext, AV86Core_documentowwds_6_docversao1, AV86Core_documentowwds_6_docversao1, AV86Core_documentowwds_6_docversao1, lV87Core_documentowwds_7_doctiposigla1, lV87Core_documentowwds_7_doctiposigla1, AV91Core_documentowwds_11_docversao2, AV91Core_documentowwds_11_docversao2, AV91Core_documentowwds_11_docversao2, lV92Core_documentowwds_12_doctiposigla2, lV92Core_documentowwds_12_doctiposigla2, AV96Core_documentowwds_16_docversao3, AV96Core_documentowwds_16_docversao3, AV96Core_documentowwds_16_docversao3, lV97Core_documentowwds_17_doctiposigla3, lV97Core_documentowwds_17_doctiposigla3, lV98Core_documentowwds_18_tfdoctiponome, AV99Core_documentowwds_19_tfdoctiponome_sel, lV100Core_documentowwds_20_tfdocnome, AV101Core_documentowwds_21_tfdocnome_sel, AV102Core_documentowwds_22_tfdocversao, AV103Core_documentowwds_23_tfdocversao_to, AV104Core_documentowwds_24_tfdocinsdatahora, AV105Core_documentowwds_25_tfdocinsdatahora_to});
         GRID_nRecordCount = H005C3_AGRID_nRecordCount[0];
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
         AV81Core_documentowwds_1_docorigem_filtro = AV68DocOrigem_Filtro;
         AV82Core_documentowwds_2_docorigemid_filtro = AV69DocOrigemID_Filtro;
         AV83Core_documentowwds_3_filterfulltext = AV17FilterFullText;
         AV84Core_documentowwds_4_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV85Core_documentowwds_5_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV86Core_documentowwds_6_docversao1 = AV20DocVersao1;
         AV87Core_documentowwds_7_doctiposigla1 = AV21DocTipoSigla1;
         AV88Core_documentowwds_8_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV89Core_documentowwds_9_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV90Core_documentowwds_10_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV91Core_documentowwds_11_docversao2 = AV25DocVersao2;
         AV92Core_documentowwds_12_doctiposigla2 = AV26DocTipoSigla2;
         AV93Core_documentowwds_13_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV94Core_documentowwds_14_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV95Core_documentowwds_15_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV96Core_documentowwds_16_docversao3 = AV30DocVersao3;
         AV97Core_documentowwds_17_doctiposigla3 = AV31DocTipoSigla3;
         AV98Core_documentowwds_18_tfdoctiponome = AV46TFDocTipoNome;
         AV99Core_documentowwds_19_tfdoctiponome_sel = AV47TFDocTipoNome_Sel;
         AV100Core_documentowwds_20_tfdocnome = AV44TFDocNome;
         AV101Core_documentowwds_21_tfdocnome_sel = AV45TFDocNome_Sel;
         AV102Core_documentowwds_22_tfdocversao = AV74TFDocVersao;
         AV103Core_documentowwds_23_tfdocversao_to = AV75TFDocVersao_To;
         AV104Core_documentowwds_24_tfdocinsdatahora = AV48TFDocInsDataHora;
         AV105Core_documentowwds_25_tfdocinsdatahora_to = AV49TFDocInsDataHora_To;
         AV106Core_documentowwds_26_tfdoccontrato_sel = AV72TFDocContrato_Sel;
         AV107Core_documentowwds_27_tfdocassinado_sel = AV73TFDocAssinado_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20DocVersao1, AV21DocTipoSigla1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25DocVersao2, AV26DocTipoSigla2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV30DocVersao3, AV31DocTipoSigla3, AV66DocOrigem, AV67DocOrigemID, AV43ManageFiltersExecutionStep, AV22DynamicFiltersEnabled2, AV27DynamicFiltersEnabled3, AV38ColumnsSelector, AV80Pgmname, AV68DocOrigem_Filtro, AV69DocOrigemID_Filtro, AV46TFDocTipoNome, AV47TFDocTipoNome_Sel, AV44TFDocNome, AV45TFDocNome_Sel, AV74TFDocVersao, AV75TFDocVersao_To, AV48TFDocInsDataHora, AV49TFDocInsDataHora_To, AV72TFDocContrato_Sel, AV73TFDocAssinado_Sel, AV14OrderedBy, AV15OrderedDsc, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV61IsAuthorized_Update, AV62IsAuthorized_Delete, AV76IsAuthorized_NovaVersao, AV70IsAuthorized_DocNome, AV65IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV81Core_documentowwds_1_docorigem_filtro = AV68DocOrigem_Filtro;
         AV82Core_documentowwds_2_docorigemid_filtro = AV69DocOrigemID_Filtro;
         AV83Core_documentowwds_3_filterfulltext = AV17FilterFullText;
         AV84Core_documentowwds_4_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV85Core_documentowwds_5_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV86Core_documentowwds_6_docversao1 = AV20DocVersao1;
         AV87Core_documentowwds_7_doctiposigla1 = AV21DocTipoSigla1;
         AV88Core_documentowwds_8_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV89Core_documentowwds_9_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV90Core_documentowwds_10_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV91Core_documentowwds_11_docversao2 = AV25DocVersao2;
         AV92Core_documentowwds_12_doctiposigla2 = AV26DocTipoSigla2;
         AV93Core_documentowwds_13_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV94Core_documentowwds_14_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV95Core_documentowwds_15_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV96Core_documentowwds_16_docversao3 = AV30DocVersao3;
         AV97Core_documentowwds_17_doctiposigla3 = AV31DocTipoSigla3;
         AV98Core_documentowwds_18_tfdoctiponome = AV46TFDocTipoNome;
         AV99Core_documentowwds_19_tfdoctiponome_sel = AV47TFDocTipoNome_Sel;
         AV100Core_documentowwds_20_tfdocnome = AV44TFDocNome;
         AV101Core_documentowwds_21_tfdocnome_sel = AV45TFDocNome_Sel;
         AV102Core_documentowwds_22_tfdocversao = AV74TFDocVersao;
         AV103Core_documentowwds_23_tfdocversao_to = AV75TFDocVersao_To;
         AV104Core_documentowwds_24_tfdocinsdatahora = AV48TFDocInsDataHora;
         AV105Core_documentowwds_25_tfdocinsdatahora_to = AV49TFDocInsDataHora_To;
         AV106Core_documentowwds_26_tfdoccontrato_sel = AV72TFDocContrato_Sel;
         AV107Core_documentowwds_27_tfdocassinado_sel = AV73TFDocAssinado_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20DocVersao1, AV21DocTipoSigla1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25DocVersao2, AV26DocTipoSigla2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV30DocVersao3, AV31DocTipoSigla3, AV66DocOrigem, AV67DocOrigemID, AV43ManageFiltersExecutionStep, AV22DynamicFiltersEnabled2, AV27DynamicFiltersEnabled3, AV38ColumnsSelector, AV80Pgmname, AV68DocOrigem_Filtro, AV69DocOrigemID_Filtro, AV46TFDocTipoNome, AV47TFDocTipoNome_Sel, AV44TFDocNome, AV45TFDocNome_Sel, AV74TFDocVersao, AV75TFDocVersao_To, AV48TFDocInsDataHora, AV49TFDocInsDataHora_To, AV72TFDocContrato_Sel, AV73TFDocAssinado_Sel, AV14OrderedBy, AV15OrderedDsc, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV61IsAuthorized_Update, AV62IsAuthorized_Delete, AV76IsAuthorized_NovaVersao, AV70IsAuthorized_DocNome, AV65IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV81Core_documentowwds_1_docorigem_filtro = AV68DocOrigem_Filtro;
         AV82Core_documentowwds_2_docorigemid_filtro = AV69DocOrigemID_Filtro;
         AV83Core_documentowwds_3_filterfulltext = AV17FilterFullText;
         AV84Core_documentowwds_4_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV85Core_documentowwds_5_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV86Core_documentowwds_6_docversao1 = AV20DocVersao1;
         AV87Core_documentowwds_7_doctiposigla1 = AV21DocTipoSigla1;
         AV88Core_documentowwds_8_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV89Core_documentowwds_9_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV90Core_documentowwds_10_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV91Core_documentowwds_11_docversao2 = AV25DocVersao2;
         AV92Core_documentowwds_12_doctiposigla2 = AV26DocTipoSigla2;
         AV93Core_documentowwds_13_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV94Core_documentowwds_14_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV95Core_documentowwds_15_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV96Core_documentowwds_16_docversao3 = AV30DocVersao3;
         AV97Core_documentowwds_17_doctiposigla3 = AV31DocTipoSigla3;
         AV98Core_documentowwds_18_tfdoctiponome = AV46TFDocTipoNome;
         AV99Core_documentowwds_19_tfdoctiponome_sel = AV47TFDocTipoNome_Sel;
         AV100Core_documentowwds_20_tfdocnome = AV44TFDocNome;
         AV101Core_documentowwds_21_tfdocnome_sel = AV45TFDocNome_Sel;
         AV102Core_documentowwds_22_tfdocversao = AV74TFDocVersao;
         AV103Core_documentowwds_23_tfdocversao_to = AV75TFDocVersao_To;
         AV104Core_documentowwds_24_tfdocinsdatahora = AV48TFDocInsDataHora;
         AV105Core_documentowwds_25_tfdocinsdatahora_to = AV49TFDocInsDataHora_To;
         AV106Core_documentowwds_26_tfdoccontrato_sel = AV72TFDocContrato_Sel;
         AV107Core_documentowwds_27_tfdocassinado_sel = AV73TFDocAssinado_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20DocVersao1, AV21DocTipoSigla1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25DocVersao2, AV26DocTipoSigla2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV30DocVersao3, AV31DocTipoSigla3, AV66DocOrigem, AV67DocOrigemID, AV43ManageFiltersExecutionStep, AV22DynamicFiltersEnabled2, AV27DynamicFiltersEnabled3, AV38ColumnsSelector, AV80Pgmname, AV68DocOrigem_Filtro, AV69DocOrigemID_Filtro, AV46TFDocTipoNome, AV47TFDocTipoNome_Sel, AV44TFDocNome, AV45TFDocNome_Sel, AV74TFDocVersao, AV75TFDocVersao_To, AV48TFDocInsDataHora, AV49TFDocInsDataHora_To, AV72TFDocContrato_Sel, AV73TFDocAssinado_Sel, AV14OrderedBy, AV15OrderedDsc, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV61IsAuthorized_Update, AV62IsAuthorized_Delete, AV76IsAuthorized_NovaVersao, AV70IsAuthorized_DocNome, AV65IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV81Core_documentowwds_1_docorigem_filtro = AV68DocOrigem_Filtro;
         AV82Core_documentowwds_2_docorigemid_filtro = AV69DocOrigemID_Filtro;
         AV83Core_documentowwds_3_filterfulltext = AV17FilterFullText;
         AV84Core_documentowwds_4_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV85Core_documentowwds_5_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV86Core_documentowwds_6_docversao1 = AV20DocVersao1;
         AV87Core_documentowwds_7_doctiposigla1 = AV21DocTipoSigla1;
         AV88Core_documentowwds_8_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV89Core_documentowwds_9_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV90Core_documentowwds_10_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV91Core_documentowwds_11_docversao2 = AV25DocVersao2;
         AV92Core_documentowwds_12_doctiposigla2 = AV26DocTipoSigla2;
         AV93Core_documentowwds_13_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV94Core_documentowwds_14_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV95Core_documentowwds_15_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV96Core_documentowwds_16_docversao3 = AV30DocVersao3;
         AV97Core_documentowwds_17_doctiposigla3 = AV31DocTipoSigla3;
         AV98Core_documentowwds_18_tfdoctiponome = AV46TFDocTipoNome;
         AV99Core_documentowwds_19_tfdoctiponome_sel = AV47TFDocTipoNome_Sel;
         AV100Core_documentowwds_20_tfdocnome = AV44TFDocNome;
         AV101Core_documentowwds_21_tfdocnome_sel = AV45TFDocNome_Sel;
         AV102Core_documentowwds_22_tfdocversao = AV74TFDocVersao;
         AV103Core_documentowwds_23_tfdocversao_to = AV75TFDocVersao_To;
         AV104Core_documentowwds_24_tfdocinsdatahora = AV48TFDocInsDataHora;
         AV105Core_documentowwds_25_tfdocinsdatahora_to = AV49TFDocInsDataHora_To;
         AV106Core_documentowwds_26_tfdoccontrato_sel = AV72TFDocContrato_Sel;
         AV107Core_documentowwds_27_tfdocassinado_sel = AV73TFDocAssinado_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20DocVersao1, AV21DocTipoSigla1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25DocVersao2, AV26DocTipoSigla2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV30DocVersao3, AV31DocTipoSigla3, AV66DocOrigem, AV67DocOrigemID, AV43ManageFiltersExecutionStep, AV22DynamicFiltersEnabled2, AV27DynamicFiltersEnabled3, AV38ColumnsSelector, AV80Pgmname, AV68DocOrigem_Filtro, AV69DocOrigemID_Filtro, AV46TFDocTipoNome, AV47TFDocTipoNome_Sel, AV44TFDocNome, AV45TFDocNome_Sel, AV74TFDocVersao, AV75TFDocVersao_To, AV48TFDocInsDataHora, AV49TFDocInsDataHora_To, AV72TFDocContrato_Sel, AV73TFDocAssinado_Sel, AV14OrderedBy, AV15OrderedDsc, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV61IsAuthorized_Update, AV62IsAuthorized_Delete, AV76IsAuthorized_NovaVersao, AV70IsAuthorized_DocNome, AV65IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV81Core_documentowwds_1_docorigem_filtro = AV68DocOrigem_Filtro;
         AV82Core_documentowwds_2_docorigemid_filtro = AV69DocOrigemID_Filtro;
         AV83Core_documentowwds_3_filterfulltext = AV17FilterFullText;
         AV84Core_documentowwds_4_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV85Core_documentowwds_5_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV86Core_documentowwds_6_docversao1 = AV20DocVersao1;
         AV87Core_documentowwds_7_doctiposigla1 = AV21DocTipoSigla1;
         AV88Core_documentowwds_8_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV89Core_documentowwds_9_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV90Core_documentowwds_10_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV91Core_documentowwds_11_docversao2 = AV25DocVersao2;
         AV92Core_documentowwds_12_doctiposigla2 = AV26DocTipoSigla2;
         AV93Core_documentowwds_13_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV94Core_documentowwds_14_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV95Core_documentowwds_15_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV96Core_documentowwds_16_docversao3 = AV30DocVersao3;
         AV97Core_documentowwds_17_doctiposigla3 = AV31DocTipoSigla3;
         AV98Core_documentowwds_18_tfdoctiponome = AV46TFDocTipoNome;
         AV99Core_documentowwds_19_tfdoctiponome_sel = AV47TFDocTipoNome_Sel;
         AV100Core_documentowwds_20_tfdocnome = AV44TFDocNome;
         AV101Core_documentowwds_21_tfdocnome_sel = AV45TFDocNome_Sel;
         AV102Core_documentowwds_22_tfdocversao = AV74TFDocVersao;
         AV103Core_documentowwds_23_tfdocversao_to = AV75TFDocVersao_To;
         AV104Core_documentowwds_24_tfdocinsdatahora = AV48TFDocInsDataHora;
         AV105Core_documentowwds_25_tfdocinsdatahora_to = AV49TFDocInsDataHora_To;
         AV106Core_documentowwds_26_tfdoccontrato_sel = AV72TFDocContrato_Sel;
         AV107Core_documentowwds_27_tfdocassinado_sel = AV73TFDocAssinado_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20DocVersao1, AV21DocTipoSigla1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25DocVersao2, AV26DocTipoSigla2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV30DocVersao3, AV31DocTipoSigla3, AV66DocOrigem, AV67DocOrigemID, AV43ManageFiltersExecutionStep, AV22DynamicFiltersEnabled2, AV27DynamicFiltersEnabled3, AV38ColumnsSelector, AV80Pgmname, AV68DocOrigem_Filtro, AV69DocOrigemID_Filtro, AV46TFDocTipoNome, AV47TFDocTipoNome_Sel, AV44TFDocNome, AV45TFDocNome_Sel, AV74TFDocVersao, AV75TFDocVersao_To, AV48TFDocInsDataHora, AV49TFDocInsDataHora_To, AV72TFDocContrato_Sel, AV73TFDocAssinado_Sel, AV14OrderedBy, AV15OrderedDsc, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV61IsAuthorized_Update, AV62IsAuthorized_Delete, AV76IsAuthorized_NovaVersao, AV70IsAuthorized_DocNome, AV65IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV80Pgmname = "core.DocumentoWW";
         edtavDetailwebcomponent_Enabled = 0;
         AssignProp("", false, edtavDetailwebcomponent_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDetailwebcomponent_Enabled), 5, 0), !bGXsfl_138_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP5C0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E285C2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV41ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vAGEXPORTDATA"), AV63AGExportData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV53DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vCOLUMNSSELECTOR"), AV38ColumnsSelector);
            /* Read saved values. */
            nRC_GXsfl_138 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_138"), ",", "."), 18, MidpointRounding.ToEven));
            AV57GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ",", "."), 18, MidpointRounding.ToEven));
            AV58GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ",", "."), 18, MidpointRounding.ToEven));
            AV59GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            AV50DDO_DocInsDataHoraAuxDate = context.localUtil.CToD( cgiGet( "vDDO_DOCINSDATAHORAAUXDATE"), 0);
            AV51DDO_DocInsDataHoraAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_DOCINSDATAHORAAUXDATETO"), 0);
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), ",", "."), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nEOF"), ",", "."), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Dvpanel_tableoportunidade_Width = cgiGet( "DVPANEL_TABLEOPORTUNIDADE_Width");
            Dvpanel_tableoportunidade_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEOPORTUNIDADE_Autowidth"));
            Dvpanel_tableoportunidade_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEOPORTUNIDADE_Autoheight"));
            Dvpanel_tableoportunidade_Cls = cgiGet( "DVPANEL_TABLEOPORTUNIDADE_Cls");
            Dvpanel_tableoportunidade_Title = cgiGet( "DVPANEL_TABLEOPORTUNIDADE_Title");
            Dvpanel_tableoportunidade_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEOPORTUNIDADE_Collapsible"));
            Dvpanel_tableoportunidade_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEOPORTUNIDADE_Collapsed"));
            Dvpanel_tableoportunidade_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEOPORTUNIDADE_Showcollapseicon"));
            Dvpanel_tableoportunidade_Iconposition = cgiGet( "DVPANEL_TABLEOPORTUNIDADE_Iconposition");
            Dvpanel_tableoportunidade_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEOPORTUNIDADE_Autoscroll"));
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
            Ddo_grid_Datalistfixedvalues = cgiGet( "DDO_GRID_Datalistfixedvalues");
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
            Dvelop_confirmpanel_novaversao_Title = cgiGet( "DVELOP_CONFIRMPANEL_NOVAVERSAO_Title");
            Dvelop_confirmpanel_novaversao_Confirmationtext = cgiGet( "DVELOP_CONFIRMPANEL_NOVAVERSAO_Confirmationtext");
            Dvelop_confirmpanel_novaversao_Yesbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_NOVAVERSAO_Yesbuttoncaption");
            Dvelop_confirmpanel_novaversao_Nobuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_NOVAVERSAO_Nobuttoncaption");
            Dvelop_confirmpanel_novaversao_Cancelbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_NOVAVERSAO_Cancelbuttoncaption");
            Dvelop_confirmpanel_novaversao_Yesbuttonposition = cgiGet( "DVELOP_CONFIRMPANEL_NOVAVERSAO_Yesbuttonposition");
            Dvelop_confirmpanel_novaversao_Confirmtype = cgiGet( "DVELOP_CONFIRMPANEL_NOVAVERSAO_Confirmtype");
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
            Dvelop_confirmpanel_novaversao_Result = cgiGet( "DVELOP_CONFIRMPANEL_NOVAVERSAO_Result");
            Ddo_agexport_Activeeventkey = cgiGet( "DDO_AGEXPORT_Activeeventkey");
            /* Read variables values. */
            AV68DocOrigem_Filtro = cgiGet( edtavDocorigem_filtro_Internalname);
            AssignAttri("", false, "AV68DocOrigem_Filtro", AV68DocOrigem_Filtro);
            AV69DocOrigemID_Filtro = cgiGet( edtavDocorigemid_filtro_Internalname);
            AssignAttri("", false, "AV69DocOrigemID_Filtro", AV69DocOrigemID_Filtro);
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
            if ( ( ( context.localUtil.CToN( cgiGet( edtavDocversao1_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavDocversao1_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vDOCVERSAO1");
               GX_FocusControl = edtavDocversao1_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV20DocVersao1 = 0;
               AssignAttri("", false, "AV20DocVersao1", StringUtil.LTrimStr( (decimal)(AV20DocVersao1), 4, 0));
            }
            else
            {
               AV20DocVersao1 = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavDocversao1_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV20DocVersao1", StringUtil.LTrimStr( (decimal)(AV20DocVersao1), 4, 0));
            }
            AV21DocTipoSigla1 = cgiGet( edtavDoctiposigla1_Internalname);
            AssignAttri("", false, "AV21DocTipoSigla1", AV21DocTipoSigla1);
            cmbavDynamicfiltersselector2.Name = cmbavDynamicfiltersselector2_Internalname;
            cmbavDynamicfiltersselector2.CurrentValue = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AV23DynamicFiltersSelector2 = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AssignAttri("", false, "AV23DynamicFiltersSelector2", AV23DynamicFiltersSelector2);
            cmbavDynamicfiltersoperator2.Name = cmbavDynamicfiltersoperator2_Internalname;
            cmbavDynamicfiltersoperator2.CurrentValue = cgiGet( cmbavDynamicfiltersoperator2_Internalname);
            AV24DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator2_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV24DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
            if ( ( ( context.localUtil.CToN( cgiGet( edtavDocversao2_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavDocversao2_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vDOCVERSAO2");
               GX_FocusControl = edtavDocversao2_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV25DocVersao2 = 0;
               AssignAttri("", false, "AV25DocVersao2", StringUtil.LTrimStr( (decimal)(AV25DocVersao2), 4, 0));
            }
            else
            {
               AV25DocVersao2 = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavDocversao2_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV25DocVersao2", StringUtil.LTrimStr( (decimal)(AV25DocVersao2), 4, 0));
            }
            AV26DocTipoSigla2 = cgiGet( edtavDoctiposigla2_Internalname);
            AssignAttri("", false, "AV26DocTipoSigla2", AV26DocTipoSigla2);
            cmbavDynamicfiltersselector3.Name = cmbavDynamicfiltersselector3_Internalname;
            cmbavDynamicfiltersselector3.CurrentValue = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AV28DynamicFiltersSelector3 = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AssignAttri("", false, "AV28DynamicFiltersSelector3", AV28DynamicFiltersSelector3);
            cmbavDynamicfiltersoperator3.Name = cmbavDynamicfiltersoperator3_Internalname;
            cmbavDynamicfiltersoperator3.CurrentValue = cgiGet( cmbavDynamicfiltersoperator3_Internalname);
            AV29DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator3_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV29DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
            if ( ( ( context.localUtil.CToN( cgiGet( edtavDocversao3_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavDocversao3_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vDOCVERSAO3");
               GX_FocusControl = edtavDocversao3_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV30DocVersao3 = 0;
               AssignAttri("", false, "AV30DocVersao3", StringUtil.LTrimStr( (decimal)(AV30DocVersao3), 4, 0));
            }
            else
            {
               AV30DocVersao3 = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavDocversao3_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV30DocVersao3", StringUtil.LTrimStr( (decimal)(AV30DocVersao3), 4, 0));
            }
            AV31DocTipoSigla3 = cgiGet( edtavDoctiposigla3_Internalname);
            AssignAttri("", false, "AV31DocTipoSigla3", AV31DocTipoSigla3);
            AV52DDO_DocInsDataHoraAuxDateText = cgiGet( edtavDdo_docinsdatahoraauxdatetext_Internalname);
            AssignAttri("", false, "AV52DDO_DocInsDataHoraAuxDateText", AV52DDO_DocInsDataHoraAuxDateText);
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
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDOCVERSAO1"), ",", ".") != Convert.ToDecimal( AV20DocVersao1 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDOCTIPOSIGLA1"), AV21DocTipoSigla1) != 0 )
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
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDOCVERSAO2"), ",", ".") != Convert.ToDecimal( AV25DocVersao2 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDOCTIPOSIGLA2"), AV26DocTipoSigla2) != 0 )
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
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDOCVERSAO3"), ",", ".") != Convert.ToDecimal( AV30DocVersao3 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDOCTIPOSIGLA3"), AV31DocTipoSigla3) != 0 )
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
         E285C2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E285C2( )
      {
         /* Start Routine */
         returnInSub = false;
         this.executeUsercontrolMethod("", false, "TFDOCINSDATAHORA_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_docinsdatahoraauxdatetext_Internalname});
         divCell_grid_dwc_Class = "Invisible WCD_"+StringUtil.Upper( subGrid_Internalname);
         AssignProp("", false, divCell_grid_dwc_Internalname, "Class", divCell_grid_dwc_Class, true);
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         edtavDocorigem_Visible = 0;
         AssignProp("", false, edtavDocorigem_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDocorigem_Visible), 5, 0), true);
         edtavDocorigemid_Visible = 0;
         AssignProp("", false, edtavDocorigemid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDocorigemid_Visible), 5, 0), true);
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         Ddo_gridcolumnsselector_Gridinternalname = subGrid_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "GridInternalName", Ddo_gridcolumnsselector_Gridinternalname);
         if ( StringUtil.StrCmp(AV8HTTPRequest.Method, "GET") == 0 )
         {
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S122 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         lblJsdynamicfilters_Caption = "";
         AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         AV18DynamicFiltersSelector1 = "DOCVERSAO";
         AssignAttri("", false, "AV18DynamicFiltersSelector1", AV18DynamicFiltersSelector1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV23DynamicFiltersSelector2 = "DOCVERSAO";
         AssignAttri("", false, "AV23DynamicFiltersSelector2", AV23DynamicFiltersSelector2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV28DynamicFiltersSelector3 = "DOCVERSAO";
         AssignAttri("", false, "AV28DynamicFiltersSelector3", AV28DynamicFiltersSelector3);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
         S152 ();
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
         AV63AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV64AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV64AGExportDataItem.gxTpr_Title = "Excel";
         AV64AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "da69a816-fd11-445b-8aaf-1a2f7f1acc93", "", context.GetTheme( ))));
         AV64AGExportDataItem.gxTpr_Eventkey = "Export";
         AV64AGExportDataItem.gxTpr_Isdivider = false;
         AV63AGExportData.Add(AV64AGExportDataItem, 0);
         AV64AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV64AGExportDataItem.gxTpr_Title = "PDF";
         AV64AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "776fb79c-a0a1-4302-b5e5-d773dbe1a297", "", context.GetTheme( ))));
         AV64AGExportDataItem.gxTpr_Eventkey = "ExportReport";
         AV64AGExportDataItem.gxTpr_Isdivider = false;
         AV63AGExportData.Add(AV64AGExportDataItem, 0);
         Ddc_subscriptions_Titlecontrolidtoreplace = bttBtnsubscriptions_Internalname;
         ucDdc_subscriptions.SendProperty(context, "", false, Ddc_subscriptions_Internalname, "TitleControlIdToReplace", Ddc_subscriptions_Titlecontrolidtoreplace);
         GXt_boolean1 = AV70IsAuthorized_DocNome;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "documentoview_Execute", out  GXt_boolean1) ;
         AV70IsAuthorized_DocNome = GXt_boolean1;
         AssignAttri("", false, "AV70IsAuthorized_DocNome", AV70IsAuthorized_DocNome);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DOCNOME", GetSecureSignedToken( "", AV70IsAuthorized_DocNome, context));
         AV54GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV55GAMErrors);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Ddo_grid_Gamoauthtoken = AV54GAMSession.gxTpr_Token;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GAMOAuthToken", Ddo_grid_Gamoauthtoken);
         Form.Caption = " Documento";
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S172 ();
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
            S182 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wcnegociopjgeneral = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcnegociopjgeneral_Component), StringUtil.Lower( "core.NegocioPJVerDetalhes")) != 0 )
         {
            WebComp_Wcnegociopjgeneral = getWebComponent(GetType(), "GeneXus.Programs", "core.negociopjverdetalhes", new Object[] {context} );
            WebComp_Wcnegociopjgeneral.ComponentInit();
            WebComp_Wcnegociopjgeneral.Name = "core.NegocioPJVerDetalhes";
            WebComp_Wcnegociopjgeneral_Component = "core.NegocioPJVerDetalhes";
         }
         if ( StringUtil.Len( WebComp_Wcnegociopjgeneral_Component) != 0 )
         {
            WebComp_Wcnegociopjgeneral.setjustcreated();
            WebComp_Wcnegociopjgeneral.componentprepare(new Object[] {(string)"W0014",(string)"",StringUtil.StrToGuid( StringUtil.Trim( AV67DocOrigemID))});
            WebComp_Wcnegociopjgeneral.componentbind(new Object[] {(string)""+""+"vDOCORIGEMID"+""+""});
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = AV53DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2) ;
         AV53DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2;
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = bttBtneditcolumns_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "TitleControlIdToReplace", Ddo_gridcolumnsselector_Titlecontrolidtoreplace);
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E295C2( )
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
         S192 ();
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
            S122 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         cmbavDynamicfiltersoperator1.removeAllItems();
         if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "DOCVERSAO") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", ">=", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "=", 0);
            cmbavDynamicfiltersoperator1.addItem("2", "<=", 0);
         }
         else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "DOCTIPOSIGLA") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Começa com", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Contém", 0);
         }
         if ( AV22DynamicFiltersEnabled2 )
         {
            cmbavDynamicfiltersoperator2.removeAllItems();
            if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "DOCVERSAO") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", ">=", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "=", 0);
               cmbavDynamicfiltersoperator2.addItem("2", "<=", 0);
            }
            else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "DOCTIPOSIGLA") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
            }
            if ( AV27DynamicFiltersEnabled3 )
            {
               cmbavDynamicfiltersoperator3.removeAllItems();
               if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "DOCVERSAO") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", ">=", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "=", 0);
                  cmbavDynamicfiltersoperator3.addItem("2", "<=", 0);
               }
               else if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "DOCTIPOSIGLA") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "Começa com", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "Contém", 0);
               }
            }
         }
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S202 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( StringUtil.StrCmp(AV40Session.Get("core.DocumentoWWColumnsSelector"), "") != 0 )
         {
            AV36ColumnsSelectorXML = AV40Session.Get("core.DocumentoWWColumnsSelector");
            AV38ColumnsSelector.FromXml(AV36ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S212 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         edtDocTipoNome_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV38ColumnsSelector.gxTpr_Columns.Item(1)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtDocTipoNome_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtDocTipoNome_Visible), 5, 0), !bGXsfl_138_Refreshing);
         edtDocNome_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV38ColumnsSelector.gxTpr_Columns.Item(2)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtDocNome_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtDocNome_Visible), 5, 0), !bGXsfl_138_Refreshing);
         edtDocVersao_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV38ColumnsSelector.gxTpr_Columns.Item(3)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtDocVersao_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtDocVersao_Visible), 5, 0), !bGXsfl_138_Refreshing);
         edtDocInsDataHora_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV38ColumnsSelector.gxTpr_Columns.Item(4)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtDocInsDataHora_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtDocInsDataHora_Visible), 5, 0), !bGXsfl_138_Refreshing);
         chkDocContrato.Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV38ColumnsSelector.gxTpr_Columns.Item(5)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, chkDocContrato_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkDocContrato.Visible), 5, 0), !bGXsfl_138_Refreshing);
         chkDocAssinado.Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV38ColumnsSelector.gxTpr_Columns.Item(6)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, chkDocAssinado_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkDocAssinado.Visible), 5, 0), !bGXsfl_138_Refreshing);
         AV57GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV57GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV57GridCurrentPage), 10, 0));
         AV58GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV58GridPageCount", StringUtil.LTrimStr( (decimal)(AV58GridPageCount), 10, 0));
         GXt_char3 = AV59GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV80Pgmname, out  GXt_char3) ;
         AV59GridAppliedFilters = GXt_char3;
         AssignAttri("", false, "AV59GridAppliedFilters", AV59GridAppliedFilters);
         AV81Core_documentowwds_1_docorigem_filtro = AV68DocOrigem_Filtro;
         AV82Core_documentowwds_2_docorigemid_filtro = AV69DocOrigemID_Filtro;
         AV83Core_documentowwds_3_filterfulltext = AV17FilterFullText;
         AV84Core_documentowwds_4_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV85Core_documentowwds_5_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV86Core_documentowwds_6_docversao1 = AV20DocVersao1;
         AV87Core_documentowwds_7_doctiposigla1 = AV21DocTipoSigla1;
         AV88Core_documentowwds_8_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV89Core_documentowwds_9_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV90Core_documentowwds_10_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV91Core_documentowwds_11_docversao2 = AV25DocVersao2;
         AV92Core_documentowwds_12_doctiposigla2 = AV26DocTipoSigla2;
         AV93Core_documentowwds_13_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV94Core_documentowwds_14_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV95Core_documentowwds_15_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV96Core_documentowwds_16_docversao3 = AV30DocVersao3;
         AV97Core_documentowwds_17_doctiposigla3 = AV31DocTipoSigla3;
         AV98Core_documentowwds_18_tfdoctiponome = AV46TFDocTipoNome;
         AV99Core_documentowwds_19_tfdoctiponome_sel = AV47TFDocTipoNome_Sel;
         AV100Core_documentowwds_20_tfdocnome = AV44TFDocNome;
         AV101Core_documentowwds_21_tfdocnome_sel = AV45TFDocNome_Sel;
         AV102Core_documentowwds_22_tfdocversao = AV74TFDocVersao;
         AV103Core_documentowwds_23_tfdocversao_to = AV75TFDocVersao_To;
         AV104Core_documentowwds_24_tfdocinsdatahora = AV48TFDocInsDataHora;
         AV105Core_documentowwds_25_tfdocinsdatahora_to = AV49TFDocInsDataHora_To;
         AV106Core_documentowwds_26_tfdoccontrato_sel = AV72TFDocContrato_Sel;
         AV107Core_documentowwds_27_tfdocassinado_sel = AV73TFDocAssinado_Sel;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ColumnsSelector", AV38ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E125C2( )
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
            AV56PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV56PageToGo) ;
         }
      }

      protected void E135C2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E165C2( )
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
            S182 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            subgrid_firstpage( ) ;
         }
         else if ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#Filter#>") == 0 )
         {
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "DocTipoNome") == 0 )
            {
               AV46TFDocTipoNome = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV46TFDocTipoNome", AV46TFDocTipoNome);
               AV47TFDocTipoNome_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV47TFDocTipoNome_Sel", AV47TFDocTipoNome_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "DocNome") == 0 )
            {
               AV44TFDocNome = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV44TFDocNome", AV44TFDocNome);
               AV45TFDocNome_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV45TFDocNome_Sel", AV45TFDocNome_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "DocVersao") == 0 )
            {
               AV74TFDocVersao = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV74TFDocVersao", StringUtil.LTrimStr( (decimal)(AV74TFDocVersao), 4, 0));
               AV75TFDocVersao_To = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV75TFDocVersao_To", StringUtil.LTrimStr( (decimal)(AV75TFDocVersao_To), 4, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "DocInsDataHora") == 0 )
            {
               AV48TFDocInsDataHora = context.localUtil.CToT( Ddo_grid_Filteredtext_get, 2);
               AssignAttri("", false, "AV48TFDocInsDataHora", context.localUtil.TToC( AV48TFDocInsDataHora, 10, 12, 0, 3, "/", ":", " "));
               AV49TFDocInsDataHora_To = context.localUtil.CToT( Ddo_grid_Filteredtextto_get, 2);
               AssignAttri("", false, "AV49TFDocInsDataHora_To", context.localUtil.TToC( AV49TFDocInsDataHora_To, 10, 12, 0, 3, "/", ":", " "));
               if ( ! (DateTime.MinValue==AV49TFDocInsDataHora_To) )
               {
                  AV49TFDocInsDataHora_To = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( AV49TFDocInsDataHora_To)), (short)(DateTimeUtil.Month( AV49TFDocInsDataHora_To)), (short)(DateTimeUtil.Day( AV49TFDocInsDataHora_To)), 23, 59, 59);
                  AssignAttri("", false, "AV49TFDocInsDataHora_To", context.localUtil.TToC( AV49TFDocInsDataHora_To, 10, 12, 0, 3, "/", ":", " "));
               }
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "DocContrato") == 0 )
            {
               AV72TFDocContrato_Sel = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV72TFDocContrato_Sel", StringUtil.Str( (decimal)(AV72TFDocContrato_Sel), 1, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "DocAssinado") == 0 )
            {
               AV73TFDocAssinado_Sel = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV73TFDocAssinado_Sel", StringUtil.Str( (decimal)(AV73TFDocAssinado_Sel), 1, 0));
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E305C2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV71DetailWebComponent = "<i class=\"fas fa-angle-right ArrowIcon\"></i>";
         AssignAttri("", false, edtavDetailwebcomponent_Internalname, AV71DetailWebComponent);
         cmbavGridactions.removeAllItems();
         cmbavGridactions.addItem("0", ";fa fa-bars", 0);
         if ( AV61IsAuthorized_Update )
         {
            cmbavGridactions.addItem("1", StringUtil.Format( "%1;%2", "Alterar", "fa fa-pen", "", "", "", "", "", "", ""), 0);
         }
         if ( AV62IsAuthorized_Delete )
         {
            cmbavGridactions.addItem("2", StringUtil.Format( "%1;%2", "Excluir", "fa fa-times", "", "", "", "", "", "", ""), 0);
         }
         if ( AV76IsAuthorized_NovaVersao )
         {
            cmbavGridactions.addItem("3", StringUtil.Format( "%1;%2", "Nova Versão", "fa-solid fa-clone", "", "", "", "", "", "", ""), 0);
         }
         if ( cmbavGridactions.ItemCount == 1 )
         {
            cmbavGridactions_Class = "Invisible";
         }
         else
         {
            cmbavGridactions_Class = "ConvertToDDO";
         }
         if ( AV70IsAuthorized_DocNome )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "core.documentoview.aspx"+UrlEncode(A289DocID.ToString()) + "," + UrlEncode(StringUtil.RTrim(""));
            edtDocNome_Link = formatLink("core.documentoview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         }
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 138;
         }
         sendrow_1382( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_138_Refreshing )
         {
            DoAjaxLoad(138, GridRow);
         }
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV60GridActions), 4, 0));
      }

      protected void E175C2( )
      {
         /* Ddo_gridcolumnsselector_Oncolumnschanged Routine */
         returnInSub = false;
         AV36ColumnsSelectorXML = Ddo_gridcolumnsselector_Columnsselectorvalues;
         AV38ColumnsSelector.FromJSonString(AV36ColumnsSelectorXML, null);
         new GeneXus.Programs.wwpbaseobjects.savecolumnsselectorstate(context ).execute(  "core.DocumentoWWColumnsSelector",  (String.IsNullOrEmpty(StringUtil.RTrim( AV36ColumnsSelectorXML)) ? "" : AV38ColumnsSelector.ToXml(false, true, "", ""))) ;
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ColumnsSelector", AV38ColumnsSelector);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E235C2( )
      {
         /* 'AddDynamicFilters1' Routine */
         returnInSub = false;
         AV22DynamicFiltersEnabled2 = true;
         AssignAttri("", false, "AV22DynamicFiltersEnabled2", AV22DynamicFiltersEnabled2);
         imgAdddynamicfilters1_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
         imgRemovedynamicfilters1_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
         gxgrGrid_refresh( subGrid_Rows, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20DocVersao1, AV21DocTipoSigla1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25DocVersao2, AV26DocTipoSigla2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV30DocVersao3, AV31DocTipoSigla3, AV66DocOrigem, AV67DocOrigemID, AV43ManageFiltersExecutionStep, AV22DynamicFiltersEnabled2, AV27DynamicFiltersEnabled3, AV38ColumnsSelector, AV80Pgmname, AV68DocOrigem_Filtro, AV69DocOrigemID_Filtro, AV46TFDocTipoNome, AV47TFDocTipoNome_Sel, AV44TFDocNome, AV45TFDocNome_Sel, AV74TFDocVersao, AV75TFDocVersao_To, AV48TFDocInsDataHora, AV49TFDocInsDataHora_To, AV72TFDocContrato_Sel, AV73TFDocAssinado_Sel, AV14OrderedBy, AV15OrderedDsc, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV61IsAuthorized_Update, AV62IsAuthorized_Delete, AV76IsAuthorized_NovaVersao, AV70IsAuthorized_DocNome, AV65IsAuthorized_Insert) ;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ColumnsSelector", AV38ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E195C2( )
      {
         /* 'RemoveDynamicFilters1' Routine */
         returnInSub = false;
         AV32DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV32DynamicFiltersRemoving", AV32DynamicFiltersRemoving);
         AV33DynamicFiltersIgnoreFirst = true;
         AssignAttri("", false, "AV33DynamicFiltersIgnoreFirst", AV33DynamicFiltersIgnoreFirst);
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S222 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'RESETDYNFILTERS' */
         S232 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S242 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV32DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV32DynamicFiltersRemoving", AV32DynamicFiltersRemoving);
         AV33DynamicFiltersIgnoreFirst = false;
         AssignAttri("", false, "AV33DynamicFiltersIgnoreFirst", AV33DynamicFiltersIgnoreFirst);
         gxgrGrid_refresh( subGrid_Rows, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20DocVersao1, AV21DocTipoSigla1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25DocVersao2, AV26DocTipoSigla2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV30DocVersao3, AV31DocTipoSigla3, AV66DocOrigem, AV67DocOrigemID, AV43ManageFiltersExecutionStep, AV22DynamicFiltersEnabled2, AV27DynamicFiltersEnabled3, AV38ColumnsSelector, AV80Pgmname, AV68DocOrigem_Filtro, AV69DocOrigemID_Filtro, AV46TFDocTipoNome, AV47TFDocTipoNome_Sel, AV44TFDocNome, AV45TFDocNome_Sel, AV74TFDocVersao, AV75TFDocVersao_To, AV48TFDocInsDataHora, AV49TFDocInsDataHora_To, AV72TFDocContrato_Sel, AV73TFDocAssinado_Sel, AV14OrderedBy, AV15OrderedDsc, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV61IsAuthorized_Update, AV62IsAuthorized_Delete, AV76IsAuthorized_NovaVersao, AV70IsAuthorized_DocNome, AV65IsAuthorized_Insert) ;
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

      protected void E245C2( )
      {
         /* Dynamicfiltersselector1_Click Routine */
         returnInSub = false;
         AV19DynamicFiltersOperator1 = 0;
         AssignAttri("", false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
      }

      protected void E255C2( )
      {
         /* 'AddDynamicFilters2' Routine */
         returnInSub = false;
         AV27DynamicFiltersEnabled3 = true;
         AssignAttri("", false, "AV27DynamicFiltersEnabled3", AV27DynamicFiltersEnabled3);
         imgAdddynamicfilters2_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         gxgrGrid_refresh( subGrid_Rows, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20DocVersao1, AV21DocTipoSigla1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25DocVersao2, AV26DocTipoSigla2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV30DocVersao3, AV31DocTipoSigla3, AV66DocOrigem, AV67DocOrigemID, AV43ManageFiltersExecutionStep, AV22DynamicFiltersEnabled2, AV27DynamicFiltersEnabled3, AV38ColumnsSelector, AV80Pgmname, AV68DocOrigem_Filtro, AV69DocOrigemID_Filtro, AV46TFDocTipoNome, AV47TFDocTipoNome_Sel, AV44TFDocNome, AV45TFDocNome_Sel, AV74TFDocVersao, AV75TFDocVersao_To, AV48TFDocInsDataHora, AV49TFDocInsDataHora_To, AV72TFDocContrato_Sel, AV73TFDocAssinado_Sel, AV14OrderedBy, AV15OrderedDsc, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV61IsAuthorized_Update, AV62IsAuthorized_Delete, AV76IsAuthorized_NovaVersao, AV70IsAuthorized_DocNome, AV65IsAuthorized_Insert) ;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ColumnsSelector", AV38ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E205C2( )
      {
         /* 'RemoveDynamicFilters2' Routine */
         returnInSub = false;
         AV32DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV32DynamicFiltersRemoving", AV32DynamicFiltersRemoving);
         AV22DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV22DynamicFiltersEnabled2", AV22DynamicFiltersEnabled2);
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S222 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'RESETDYNFILTERS' */
         S232 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S242 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV32DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV32DynamicFiltersRemoving", AV32DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20DocVersao1, AV21DocTipoSigla1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25DocVersao2, AV26DocTipoSigla2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV30DocVersao3, AV31DocTipoSigla3, AV66DocOrigem, AV67DocOrigemID, AV43ManageFiltersExecutionStep, AV22DynamicFiltersEnabled2, AV27DynamicFiltersEnabled3, AV38ColumnsSelector, AV80Pgmname, AV68DocOrigem_Filtro, AV69DocOrigemID_Filtro, AV46TFDocTipoNome, AV47TFDocTipoNome_Sel, AV44TFDocNome, AV45TFDocNome_Sel, AV74TFDocVersao, AV75TFDocVersao_To, AV48TFDocInsDataHora, AV49TFDocInsDataHora_To, AV72TFDocContrato_Sel, AV73TFDocAssinado_Sel, AV14OrderedBy, AV15OrderedDsc, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV61IsAuthorized_Update, AV62IsAuthorized_Delete, AV76IsAuthorized_NovaVersao, AV70IsAuthorized_DocNome, AV65IsAuthorized_Insert) ;
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

      protected void E265C2( )
      {
         /* Dynamicfiltersselector2_Click Routine */
         returnInSub = false;
         AV24DynamicFiltersOperator2 = 0;
         AssignAttri("", false, "AV24DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
      }

      protected void E215C2( )
      {
         /* 'RemoveDynamicFilters3' Routine */
         returnInSub = false;
         AV32DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV32DynamicFiltersRemoving", AV32DynamicFiltersRemoving);
         AV27DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV27DynamicFiltersEnabled3", AV27DynamicFiltersEnabled3);
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S222 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'RESETDYNFILTERS' */
         S232 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S242 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV32DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV32DynamicFiltersRemoving", AV32DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20DocVersao1, AV21DocTipoSigla1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV25DocVersao2, AV26DocTipoSigla2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV30DocVersao3, AV31DocTipoSigla3, AV66DocOrigem, AV67DocOrigemID, AV43ManageFiltersExecutionStep, AV22DynamicFiltersEnabled2, AV27DynamicFiltersEnabled3, AV38ColumnsSelector, AV80Pgmname, AV68DocOrigem_Filtro, AV69DocOrigemID_Filtro, AV46TFDocTipoNome, AV47TFDocTipoNome_Sel, AV44TFDocNome, AV45TFDocNome_Sel, AV74TFDocVersao, AV75TFDocVersao_To, AV48TFDocInsDataHora, AV49TFDocInsDataHora_To, AV72TFDocContrato_Sel, AV73TFDocAssinado_Sel, AV14OrderedBy, AV15OrderedDsc, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV61IsAuthorized_Update, AV62IsAuthorized_Delete, AV76IsAuthorized_NovaVersao, AV70IsAuthorized_DocNome, AV65IsAuthorized_Insert) ;
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

      protected void E275C2( )
      {
         /* Dynamicfiltersselector3_Click Routine */
         returnInSub = false;
         AV29DynamicFiltersOperator3 = 0;
         AssignAttri("", false, "AV29DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
      }

      protected void E115C2( )
      {
         /* Ddo_managefilters_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Clean#>") == 0 )
         {
            /* Execute user subroutine: 'CLEANFILTERS' */
            S252 ();
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
            S202 ();
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
            GXEncryptionTmp = "wwpbaseobjects.savefilteras.aspx"+UrlEncode(StringUtil.RTrim("core.DocumentoWWFilters")) + "," + UrlEncode(StringUtil.RTrim(AV80Pgmname+"GridState"));
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
            GXEncryptionTmp = "wwpbaseobjects.managefilters.aspx"+UrlEncode(StringUtil.RTrim("core.DocumentoWWFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV43ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV43ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV43ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char3 = AV42ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "core.DocumentoWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char3) ;
            AV42ManageFiltersXml = GXt_char3;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV42ManageFiltersXml)) )
            {
               GX_msglist.addItem("O filtro selecionado não existe mais.");
            }
            else
            {
               /* Execute user subroutine: 'CLEANFILTERS' */
               S252 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV80Pgmname+"GridState",  AV42ManageFiltersXml) ;
               AV11GridState.FromXml(AV42ManageFiltersXml, null, "", "");
               AV14OrderedBy = AV11GridState.gxTpr_Orderedby;
               AssignAttri("", false, "AV14OrderedBy", StringUtil.LTrimStr( (decimal)(AV14OrderedBy), 4, 0));
               AV15OrderedDsc = AV11GridState.gxTpr_Ordereddsc;
               AssignAttri("", false, "AV15OrderedDsc", AV15OrderedDsc);
               /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
               S182 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
               S262 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
               S242 ();
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

      protected void E315C2( )
      {
         /* Gridactions_Click Routine */
         returnInSub = false;
         if ( AV60GridActions == 1 )
         {
            /* Execute user subroutine: 'DO UPDATE' */
            S272 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV60GridActions == 2 )
         {
            /* Execute user subroutine: 'DO DELETE' */
            S282 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV60GridActions == 3 )
         {
            /* Execute user subroutine: 'DO NOVAVERSAO' */
            S292 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         AV60GridActions = 0;
         AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV60GridActions), 4, 0));
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV60GridActions), 4, 0));
         AssignProp("", false, cmbavGridactions_Internalname, "Values", cmbavGridactions.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ColumnsSelector", AV38ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E185C2( )
      {
         /* Dvelop_confirmpanel_novaversao_Close Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Dvelop_confirmpanel_novaversao_Result, "Yes") == 0 )
         {
            /* Execute user subroutine: 'DO ACTION NOVAVERSAO' */
            S302 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV77sdtDocumento", AV77sdtDocumento);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ColumnsSelector", AV38ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E225C2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         if ( AV65IsAuthorized_Insert )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "core.documento.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(Guid.Empty.ToString()) + "," + UrlEncode(StringUtil.RTrim(AV66DocOrigem)) + "," + UrlEncode(StringUtil.RTrim(AV67DocOrigemID));
            CallWebObject(formatLink("core.documento.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem("A ação não encontra-se disponível");
            context.DoAjaxRefresh();
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ColumnsSelector", AV38ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E145C2( )
      {
         /* Ddo_agexport_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_agexport_Activeeventkey, "Export") == 0 )
         {
            /* Execute user subroutine: 'DOEXPORT' */
            S312 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(Ddo_agexport_Activeeventkey, "ExportReport") == 0 )
         {
            /* Execute user subroutine: 'DOEXPORTREPORT' */
            S322 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /*  Sending Event outputs  */
      }

      protected void E155C2( )
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
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"W0176",(string)"",(string)"Documento",(short)1,(string)"",(string)""});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0176"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void E325C2( )
      {
         /* Detailwebcomponent_Click Routine */
         returnInSub = false;
         /* Object Property */
         if ( true )
         {
            bDynCreated_Grid_dwc = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Grid_dwc_Component), StringUtil.Lower( "core.wcDocumentoArquivo")) != 0 )
         {
            WebComp_Grid_dwc = getWebComponent(GetType(), "GeneXus.Programs", "core.wcdocumentoarquivo", new Object[] {context} );
            WebComp_Grid_dwc.ComponentInit();
            WebComp_Grid_dwc.Name = "core.wcDocumentoArquivo";
            WebComp_Grid_dwc_Component = "core.wcDocumentoArquivo";
         }
         if ( StringUtil.Len( WebComp_Grid_dwc_Component) != 0 )
         {
            WebComp_Grid_dwc.setjustcreated();
            WebComp_Grid_dwc.componentprepare(new Object[] {(string)"W0157",(string)"",(Guid)A289DocID,(Guid)A326DocVersaoIDPai});
            WebComp_Grid_dwc.componentbind(new Object[] {(string)"",(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Grid_dwc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0157"+"");
            WebComp_Grid_dwc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void S182( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV14OrderedBy), 4, 0))+":"+(AV15OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S212( )
      {
         /* 'INITIALIZECOLUMNSSELECTOR' Routine */
         returnInSub = false;
         AV38ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV38ColumnsSelector,  "DocTipoNome",  "",  "Tipo",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV38ColumnsSelector,  "DocNome",  "",  "Descrição",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV38ColumnsSelector,  "DocVersao",  "",  "Versão",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV38ColumnsSelector,  "DocInsDataHora",  "",  "Incluído em",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV38ColumnsSelector,  "DocContrato",  "",  "Contrato",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV38ColumnsSelector,  "DocAssinado",  "",  "Assinado",  true,  "") ;
         GXt_char3 = AV37UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "core.DocumentoWWColumnsSelector", out  GXt_char3) ;
         AV37UserCustomValue = GXt_char3;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV37UserCustomValue)) ) )
         {
            AV39ColumnsSelectorAux.FromXml(AV37UserCustomValue, null, "", "");
            new GeneXus.Programs.wwpbaseobjects.wwp_columnselector_updatecolumns(context ).execute( ref  AV39ColumnsSelectorAux, ref  AV38ColumnsSelector) ;
         }
      }

      protected void S192( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         GXt_boolean1 = AV61IsAuthorized_Update;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "documento_Update", out  GXt_boolean1) ;
         AV61IsAuthorized_Update = GXt_boolean1;
         AssignAttri("", false, "AV61IsAuthorized_Update", AV61IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV61IsAuthorized_Update, context));
         GXt_boolean1 = AV62IsAuthorized_Delete;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "documento_Delete", out  GXt_boolean1) ;
         AV62IsAuthorized_Delete = GXt_boolean1;
         AssignAttri("", false, "AV62IsAuthorized_Delete", AV62IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV62IsAuthorized_Delete, context));
         GXt_boolean1 = AV76IsAuthorized_NovaVersao;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "documento_Execute", out  GXt_boolean1) ;
         AV76IsAuthorized_NovaVersao = GXt_boolean1;
         AssignAttri("", false, "AV76IsAuthorized_NovaVersao", AV76IsAuthorized_NovaVersao);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_NOVAVERSAO", GetSecureSignedToken( "", AV76IsAuthorized_NovaVersao, context));
         GXt_boolean1 = AV65IsAuthorized_Insert;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "documento_Insert", out  GXt_boolean1) ;
         AV65IsAuthorized_Insert = GXt_boolean1;
         AssignAttri("", false, "AV65IsAuthorized_Insert", AV65IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV65IsAuthorized_Insert, context));
         if ( ! ( AV65IsAuthorized_Insert ) )
         {
            bttBtninsert_Visible = 0;
            AssignProp("", false, bttBtninsert_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtninsert_Visible), 5, 0), true);
         }
         if ( ! ( new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_hassubscriptionstodisplay(context).executeUdp(  "Documento",  1) ) )
         {
            bttBtnsubscriptions_Visible = 0;
            AssignProp("", false, bttBtnsubscriptions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnsubscriptions_Visible), 5, 0), true);
         }
      }

      protected void S132( )
      {
         /* 'ENABLEDYNAMICFILTERS1' Routine */
         returnInSub = false;
         edtavDocversao1_Visible = 0;
         AssignProp("", false, edtavDocversao1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDocversao1_Visible), 5, 0), true);
         edtavDoctiposigla1_Visible = 0;
         AssignProp("", false, edtavDoctiposigla1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDoctiposigla1_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator1.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "DOCVERSAO") == 0 )
         {
            edtavDocversao1_Visible = 1;
            AssignProp("", false, edtavDocversao1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDocversao1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "DOCTIPOSIGLA") == 0 )
         {
            edtavDoctiposigla1_Visible = 1;
            AssignProp("", false, edtavDoctiposigla1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDoctiposigla1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
      }

      protected void S142( )
      {
         /* 'ENABLEDYNAMICFILTERS2' Routine */
         returnInSub = false;
         edtavDocversao2_Visible = 0;
         AssignProp("", false, edtavDocversao2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDocversao2_Visible), 5, 0), true);
         edtavDoctiposigla2_Visible = 0;
         AssignProp("", false, edtavDoctiposigla2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDoctiposigla2_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator2.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "DOCVERSAO") == 0 )
         {
            edtavDocversao2_Visible = 1;
            AssignProp("", false, edtavDocversao2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDocversao2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "DOCTIPOSIGLA") == 0 )
         {
            edtavDoctiposigla2_Visible = 1;
            AssignProp("", false, edtavDoctiposigla2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDoctiposigla2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
      }

      protected void S152( )
      {
         /* 'ENABLEDYNAMICFILTERS3' Routine */
         returnInSub = false;
         edtavDocversao3_Visible = 0;
         AssignProp("", false, edtavDocversao3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDocversao3_Visible), 5, 0), true);
         edtavDoctiposigla3_Visible = 0;
         AssignProp("", false, edtavDoctiposigla3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDoctiposigla3_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator3.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "DOCVERSAO") == 0 )
         {
            edtavDocversao3_Visible = 1;
            AssignProp("", false, edtavDocversao3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDocversao3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "DOCTIPOSIGLA") == 0 )
         {
            edtavDoctiposigla3_Visible = 1;
            AssignProp("", false, edtavDoctiposigla3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDoctiposigla3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
      }

      protected void S232( )
      {
         /* 'RESETDYNFILTERS' Routine */
         returnInSub = false;
         AV22DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV22DynamicFiltersEnabled2", AV22DynamicFiltersEnabled2);
         AV23DynamicFiltersSelector2 = "DOCVERSAO";
         AssignAttri("", false, "AV23DynamicFiltersSelector2", AV23DynamicFiltersSelector2);
         AV24DynamicFiltersOperator2 = 0;
         AssignAttri("", false, "AV24DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         AV25DocVersao2 = 0;
         AssignAttri("", false, "AV25DocVersao2", StringUtil.LTrimStr( (decimal)(AV25DocVersao2), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV27DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV27DynamicFiltersEnabled3", AV27DynamicFiltersEnabled3);
         AV28DynamicFiltersSelector3 = "DOCVERSAO";
         AssignAttri("", false, "AV28DynamicFiltersSelector3", AV28DynamicFiltersSelector3);
         AV29DynamicFiltersOperator3 = 0;
         AssignAttri("", false, "AV29DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         AV30DocVersao3 = 0;
         AssignAttri("", false, "AV30DocVersao3", StringUtil.LTrimStr( (decimal)(AV30DocVersao3), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S122( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = AV41ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "core.DocumentoWWFilters",  "WWPDynFilterHideAll_AL('%1', 3, 0)",  divTabledynamicfilters_Internalname,  true, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4) ;
         AV41ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4;
      }

      protected void S252( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV68DocOrigem_Filtro = "";
         AssignAttri("", false, "AV68DocOrigem_Filtro", AV68DocOrigem_Filtro);
         AV69DocOrigemID_Filtro = "";
         AssignAttri("", false, "AV69DocOrigemID_Filtro", AV69DocOrigemID_Filtro);
         AV17FilterFullText = "";
         AssignAttri("", false, "AV17FilterFullText", AV17FilterFullText);
         AV46TFDocTipoNome = "";
         AssignAttri("", false, "AV46TFDocTipoNome", AV46TFDocTipoNome);
         AV47TFDocTipoNome_Sel = "";
         AssignAttri("", false, "AV47TFDocTipoNome_Sel", AV47TFDocTipoNome_Sel);
         AV44TFDocNome = "";
         AssignAttri("", false, "AV44TFDocNome", AV44TFDocNome);
         AV45TFDocNome_Sel = "";
         AssignAttri("", false, "AV45TFDocNome_Sel", AV45TFDocNome_Sel);
         AV74TFDocVersao = 0;
         AssignAttri("", false, "AV74TFDocVersao", StringUtil.LTrimStr( (decimal)(AV74TFDocVersao), 4, 0));
         AV75TFDocVersao_To = 0;
         AssignAttri("", false, "AV75TFDocVersao_To", StringUtil.LTrimStr( (decimal)(AV75TFDocVersao_To), 4, 0));
         AV48TFDocInsDataHora = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "AV48TFDocInsDataHora", context.localUtil.TToC( AV48TFDocInsDataHora, 10, 12, 0, 3, "/", ":", " "));
         AV49TFDocInsDataHora_To = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "AV49TFDocInsDataHora_To", context.localUtil.TToC( AV49TFDocInsDataHora_To, 10, 12, 0, 3, "/", ":", " "));
         AV72TFDocContrato_Sel = 0;
         AssignAttri("", false, "AV72TFDocContrato_Sel", StringUtil.Str( (decimal)(AV72TFDocContrato_Sel), 1, 0));
         AV73TFDocAssinado_Sel = 0;
         AssignAttri("", false, "AV73TFDocAssinado_Sel", StringUtil.Str( (decimal)(AV73TFDocAssinado_Sel), 1, 0));
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
         AV18DynamicFiltersSelector1 = "DOCVERSAO";
         AssignAttri("", false, "AV18DynamicFiltersSelector1", AV18DynamicFiltersSelector1);
         AV19DynamicFiltersOperator1 = 0;
         AssignAttri("", false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AV20DocVersao1 = 0;
         AssignAttri("", false, "AV20DocVersao1", StringUtil.LTrimStr( (decimal)(AV20DocVersao1), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'RESETDYNFILTERS' */
         S232 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV11GridState.gxTpr_Dynamicfilters.Clear();
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S242 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S272( )
      {
         /* 'DO UPDATE' Routine */
         returnInSub = false;
         if ( AV61IsAuthorized_Update )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "core.documento.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(A289DocID.ToString()) + "," + UrlEncode(StringUtil.RTrim(AV66DocOrigem)) + "," + UrlEncode(StringUtil.RTrim(AV67DocOrigemID));
            CallWebObject(formatLink("core.documento.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem("A ação não encontra-se disponível");
            context.DoAjaxRefresh();
         }
      }

      protected void S282( )
      {
         /* 'DO DELETE' Routine */
         returnInSub = false;
         if ( AV62IsAuthorized_Delete )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "core.documento.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(A289DocID.ToString()) + "," + UrlEncode(StringUtil.RTrim(AV66DocOrigem)) + "," + UrlEncode(StringUtil.RTrim(AV67DocOrigemID));
            CallWebObject(formatLink("core.documento.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem("A ação não encontra-se disponível");
            context.DoAjaxRefresh();
         }
      }

      protected void S292( )
      {
         /* 'DO NOVAVERSAO' Routine */
         returnInSub = false;
         if ( AV76IsAuthorized_NovaVersao )
         {
            this.executeUsercontrolMethod("", false, "DVELOP_CONFIRMPANEL_NOVAVERSAOContainer", "Confirm", "", new Object[] {});
         }
         else
         {
            GX_msglist.addItem("A ação não encontra-se disponível");
            context.DoAjaxRefresh();
         }
      }

      protected void S302( )
      {
         /* 'DO ACTION NOVAVERSAO' Routine */
         returnInSub = false;
         AV77sdtDocumento.gxTpr_Docid = A289DocID;
         new GeneXus.Programs.core.prcdocumentoobterdadosindividual(context ).execute( ref  AV77sdtDocumento) ;
         AV79webSessionParm = "sdtDocumento_" + StringUtil.Trim( AV66DocOrigem) + "_" + StringUtil.Trim( AV67DocOrigemID);
         AV78webSession.Set(AV79webSessionParm, AV77sdtDocumento.ToJSonString(false, true));
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV9TrnContext.gxTpr_Transactionname = "core.Documento";
         AV10TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV10TrnContextAtt.gxTpr_Attributename = "DocVersaoIDPai";
         AV10TrnContextAtt.gxTpr_Attributevalue = A289DocID.ToString();
         AV9TrnContext.gxTpr_Attributes.Add(AV10TrnContextAtt, 0);
         AV10TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV10TrnContextAtt.gxTpr_Attributename = "DocTipoID";
         AV10TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(A146DocTipoID), 9, 0);
         AV9TrnContext.gxTpr_Attributes.Add(AV10TrnContextAtt, 0);
         AV78webSession.Set("TrnContext", AV9TrnContext.ToXml(false, true, "", ""));
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "core.documento.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(Guid.Empty.ToString()) + "," + UrlEncode(StringUtil.RTrim(AV66DocOrigem)) + "," + UrlEncode(StringUtil.RTrim(AV67DocOrigemID));
         CallWebObject(formatLink("core.documento.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
         context.DoAjaxRefresh();
      }

      protected void S172( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV40Session.Get(AV80Pgmname+"GridState"), "") == 0 )
         {
            AV11GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV80Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV11GridState.FromXml(AV40Session.Get(AV80Pgmname+"GridState"), null, "", "");
         }
         AV14OrderedBy = AV11GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV14OrderedBy", StringUtil.LTrimStr( (decimal)(AV14OrderedBy), 4, 0));
         AV15OrderedDsc = AV11GridState.gxTpr_Ordereddsc;
         AssignAttri("", false, "AV15OrderedDsc", AV15OrderedDsc);
         /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
         S182 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
         S262 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S242 ();
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

      protected void S262( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV108GXV1 = 1;
         while ( AV108GXV1 <= AV11GridState.gxTpr_Filtervalues.Count )
         {
            AV12GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV11GridState.gxTpr_Filtervalues.Item(AV108GXV1));
            if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "DOCORIGEM_FILTRO") == 0 )
            {
               AV68DocOrigem_Filtro = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV68DocOrigem_Filtro", AV68DocOrigem_Filtro);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "DOCORIGEMID_FILTRO") == 0 )
            {
               AV69DocOrigemID_Filtro = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV69DocOrigemID_Filtro", AV69DocOrigemID_Filtro);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV17FilterFullText = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV17FilterFullText", AV17FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFDOCTIPONOME") == 0 )
            {
               AV46TFDocTipoNome = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV46TFDocTipoNome", AV46TFDocTipoNome);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFDOCTIPONOME_SEL") == 0 )
            {
               AV47TFDocTipoNome_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV47TFDocTipoNome_Sel", AV47TFDocTipoNome_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFDOCNOME") == 0 )
            {
               AV44TFDocNome = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV44TFDocNome", AV44TFDocNome);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFDOCNOME_SEL") == 0 )
            {
               AV45TFDocNome_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV45TFDocNome_Sel", AV45TFDocNome_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFDOCVERSAO") == 0 )
            {
               AV74TFDocVersao = (short)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV74TFDocVersao", StringUtil.LTrimStr( (decimal)(AV74TFDocVersao), 4, 0));
               AV75TFDocVersao_To = (short)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV75TFDocVersao_To", StringUtil.LTrimStr( (decimal)(AV75TFDocVersao_To), 4, 0));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFDOCINSDATAHORA") == 0 )
            {
               AV48TFDocInsDataHora = context.localUtil.CToT( AV12GridStateFilterValue.gxTpr_Value, 2);
               AssignAttri("", false, "AV48TFDocInsDataHora", context.localUtil.TToC( AV48TFDocInsDataHora, 10, 12, 0, 3, "/", ":", " "));
               AV49TFDocInsDataHora_To = context.localUtil.CToT( AV12GridStateFilterValue.gxTpr_Valueto, 2);
               AssignAttri("", false, "AV49TFDocInsDataHora_To", context.localUtil.TToC( AV49TFDocInsDataHora_To, 10, 12, 0, 3, "/", ":", " "));
               AV50DDO_DocInsDataHoraAuxDate = DateTimeUtil.ResetTime(AV48TFDocInsDataHora);
               AssignAttri("", false, "AV50DDO_DocInsDataHoraAuxDate", context.localUtil.Format(AV50DDO_DocInsDataHoraAuxDate, "99/99/9999"));
               AV51DDO_DocInsDataHoraAuxDateTo = DateTimeUtil.ResetTime(AV49TFDocInsDataHora_To);
               AssignAttri("", false, "AV51DDO_DocInsDataHoraAuxDateTo", context.localUtil.Format(AV51DDO_DocInsDataHoraAuxDateTo, "99/99/9999"));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFDOCCONTRATO_SEL") == 0 )
            {
               AV72TFDocContrato_Sel = (short)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV72TFDocContrato_Sel", StringUtil.Str( (decimal)(AV72TFDocContrato_Sel), 1, 0));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFDOCASSINADO_SEL") == 0 )
            {
               AV73TFDocAssinado_Sel = (short)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV73TFDocAssinado_Sel", StringUtil.Str( (decimal)(AV73TFDocAssinado_Sel), 1, 0));
            }
            AV108GXV1 = (int)(AV108GXV1+1);
         }
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV47TFDocTipoNome_Sel)),  AV47TFDocTipoNome_Sel, out  GXt_char3) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV45TFDocNome_Sel)),  AV45TFDocNome_Sel, out  GXt_char5) ;
         Ddo_grid_Selectedvalue_set = GXt_char3+"|"+GXt_char5+"|||"+((0==AV72TFDocContrato_Sel) ? "" : StringUtil.Str( (decimal)(AV72TFDocContrato_Sel), 1, 0))+"|"+((0==AV73TFDocAssinado_Sel) ? "" : StringUtil.Str( (decimal)(AV73TFDocAssinado_Sel), 1, 0));
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV46TFDocTipoNome)),  AV46TFDocTipoNome, out  GXt_char5) ;
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV44TFDocNome)),  AV44TFDocNome, out  GXt_char3) ;
         Ddo_grid_Filteredtext_set = GXt_char5+"|"+GXt_char3+"|"+((0==AV74TFDocVersao) ? "" : StringUtil.Str( (decimal)(AV74TFDocVersao), 4, 0))+"|"+((DateTime.MinValue==AV48TFDocInsDataHora) ? "" : context.localUtil.DToC( AV50DDO_DocInsDataHoraAuxDate, 2, "/"))+"||";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "||"+((0==AV75TFDocVersao_To) ? "" : StringUtil.Str( (decimal)(AV75TFDocVersao_To), 4, 0))+"|"+((DateTime.MinValue==AV49TFDocInsDataHora_To) ? "" : context.localUtil.DToC( AV51DDO_DocInsDataHoraAuxDateTo, 2, "/"))+"||";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S242( )
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
            if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "DOCVERSAO") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV13GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
               AV20DocVersao1 = (short)(Math.Round(NumberUtil.Val( AV13GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV20DocVersao1", StringUtil.LTrimStr( (decimal)(AV20DocVersao1), 4, 0));
            }
            else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "DOCTIPOSIGLA") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV13GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
               AV21DocTipoSigla1 = AV13GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV21DocTipoSigla1", AV21DocTipoSigla1);
            }
            /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
            S132 ();
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
               if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "DOCVERSAO") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV13GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV24DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
                  AV25DocVersao2 = (short)(Math.Round(NumberUtil.Val( AV13GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV25DocVersao2", StringUtil.LTrimStr( (decimal)(AV25DocVersao2), 4, 0));
               }
               else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "DOCTIPOSIGLA") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV13GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV24DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
                  AV26DocTipoSigla2 = AV13GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV26DocTipoSigla2", AV26DocTipoSigla2);
               }
               /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
               S142 ();
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
                  if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "DOCVERSAO") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV13GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV29DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
                     AV30DocVersao3 = (short)(Math.Round(NumberUtil.Val( AV13GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, "AV30DocVersao3", StringUtil.LTrimStr( (decimal)(AV30DocVersao3), 4, 0));
                  }
                  else if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "DOCTIPOSIGLA") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV13GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV29DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
                     AV31DocTipoSigla3 = AV13GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV31DocTipoSigla3", AV31DocTipoSigla3);
                  }
                  /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
                  S152 ();
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

      protected void S202( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV11GridState.FromXml(AV40Session.Get(AV80Pgmname+"GridState"), null, "", "");
         AV11GridState.gxTpr_Orderedby = AV14OrderedBy;
         AV11GridState.gxTpr_Ordereddsc = AV15OrderedDsc;
         AV11GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "DOCORIGEM_FILTRO",  "Origem",  !String.IsNullOrEmpty(StringUtil.RTrim( AV68DocOrigem_Filtro)),  0,  AV68DocOrigem_Filtro,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "DOCORIGEMID_FILTRO",  "da Origem",  !String.IsNullOrEmpty(StringUtil.RTrim( AV69DocOrigemID_Filtro)),  0,  AV69DocOrigemID_Filtro,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "FILTERFULLTEXT",  "Filtro principal",  !String.IsNullOrEmpty(StringUtil.RTrim( AV17FilterFullText)),  0,  AV17FilterFullText,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFDOCTIPONOME",  "Tipo",  !String.IsNullOrEmpty(StringUtil.RTrim( AV46TFDocTipoNome)),  0,  AV46TFDocTipoNome,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV47TFDocTipoNome_Sel)),  AV47TFDocTipoNome_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFDOCNOME",  "Descrição",  !String.IsNullOrEmpty(StringUtil.RTrim( AV44TFDocNome)),  0,  AV44TFDocNome,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV45TFDocNome_Sel)),  AV45TFDocNome_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFDOCVERSAO",  "Versão",  !((0==AV74TFDocVersao)&&(0==AV75TFDocVersao_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV74TFDocVersao), 4, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV75TFDocVersao_To), 4, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFDOCINSDATAHORA",  "Incluído em",  !((DateTime.MinValue==AV48TFDocInsDataHora)&&(DateTime.MinValue==AV49TFDocInsDataHora_To)),  0,  StringUtil.Trim( context.localUtil.TToC( AV48TFDocInsDataHora, 10, 12, 0, 3, "/", ":", " ")),  StringUtil.Trim( context.localUtil.TToC( AV49TFDocInsDataHora_To, 10, 12, 0, 3, "/", ":", " "))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFDOCCONTRATO_SEL",  "Contrato",  !(0==AV72TFDocContrato_Sel),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV72TFDocContrato_Sel), 1, 0)),  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFDOCASSINADO_SEL",  "Assinado",  !(0==AV73TFDocAssinado_Sel),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV73TFDocAssinado_Sel), 1, 0)),  "") ;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66DocOrigem)) )
         {
            AV12GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
            AV12GridStateFilterValue.gxTpr_Name = "PARM_&DOCORIGEM";
            AV12GridStateFilterValue.gxTpr_Value = AV66DocOrigem;
            AV11GridState.gxTpr_Filtervalues.Add(AV12GridStateFilterValue, 0);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67DocOrigemID)) )
         {
            AV12GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
            AV12GridStateFilterValue.gxTpr_Name = "PARM_&DOCORIGEMID";
            AV12GridStateFilterValue.gxTpr_Value = AV67DocOrigemID;
            AV11GridState.gxTpr_Filtervalues.Add(AV12GridStateFilterValue, 0);
         }
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S222 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV11GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV11GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV80Pgmname+"GridState",  AV11GridState.ToXml(false, true, "", "")) ;
      }

      protected void S222( )
      {
         /* 'SAVEDYNFILTERSSTATE' Routine */
         returnInSub = false;
         AV11GridState.gxTpr_Dynamicfilters.Clear();
         if ( ! AV33DynamicFiltersIgnoreFirst )
         {
            AV13GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV13GridStateDynamicFilter.gxTpr_Selected = AV18DynamicFiltersSelector1;
            if ( ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "DOCVERSAO") == 0 ) && ! (0==AV20DocVersao1) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = "Versão";
               AV13GridStateDynamicFilter.gxTpr_Value = StringUtil.Str( (decimal)(AV20DocVersao1), 4, 0);
               AV13GridStateDynamicFilter.gxTpr_Operator = AV19DynamicFiltersOperator1;
            }
            else if ( ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "DOCTIPOSIGLA") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV21DocTipoSigla1)) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = "Sigla";
               AV13GridStateDynamicFilter.gxTpr_Value = AV21DocTipoSigla1;
               AV13GridStateDynamicFilter.gxTpr_Operator = AV19DynamicFiltersOperator1;
            }
            if ( AV32DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV13GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV11GridState.gxTpr_Dynamicfilters.Add(AV13GridStateDynamicFilter, 0);
            }
         }
         if ( AV22DynamicFiltersEnabled2 )
         {
            AV13GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV13GridStateDynamicFilter.gxTpr_Selected = AV23DynamicFiltersSelector2;
            if ( ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "DOCVERSAO") == 0 ) && ! (0==AV25DocVersao2) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = "Versão";
               AV13GridStateDynamicFilter.gxTpr_Value = StringUtil.Str( (decimal)(AV25DocVersao2), 4, 0);
               AV13GridStateDynamicFilter.gxTpr_Operator = AV24DynamicFiltersOperator2;
            }
            else if ( ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "DOCTIPOSIGLA") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV26DocTipoSigla2)) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = "Sigla";
               AV13GridStateDynamicFilter.gxTpr_Value = AV26DocTipoSigla2;
               AV13GridStateDynamicFilter.gxTpr_Operator = AV24DynamicFiltersOperator2;
            }
            if ( AV32DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV13GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV11GridState.gxTpr_Dynamicfilters.Add(AV13GridStateDynamicFilter, 0);
            }
         }
         if ( AV27DynamicFiltersEnabled3 )
         {
            AV13GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV13GridStateDynamicFilter.gxTpr_Selected = AV28DynamicFiltersSelector3;
            if ( ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "DOCVERSAO") == 0 ) && ! (0==AV30DocVersao3) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = "Versão";
               AV13GridStateDynamicFilter.gxTpr_Value = StringUtil.Str( (decimal)(AV30DocVersao3), 4, 0);
               AV13GridStateDynamicFilter.gxTpr_Operator = AV29DynamicFiltersOperator3;
            }
            else if ( ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "DOCTIPOSIGLA") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV31DocTipoSigla3)) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = "Sigla";
               AV13GridStateDynamicFilter.gxTpr_Value = AV31DocTipoSigla3;
               AV13GridStateDynamicFilter.gxTpr_Operator = AV29DynamicFiltersOperator3;
            }
            if ( AV32DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV13GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV11GridState.gxTpr_Dynamicfilters.Add(AV13GridStateDynamicFilter, 0);
            }
         }
      }

      protected void S162( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV9TrnContext.gxTpr_Callerobject = AV80Pgmname;
         AV9TrnContext.gxTpr_Callerondelete = true;
         AV9TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString;
         AV9TrnContext.gxTpr_Transactionname = "core.Documento";
         AV40Session.Set("TrnContext", AV9TrnContext.ToXml(false, true, "", ""));
      }

      protected void S312( )
      {
         /* 'DOEXPORT' Routine */
         returnInSub = false;
         new GeneXus.Programs.core.documentowwexport(context ).execute( out  AV34ExcelFilename, out  AV35ErrorMessage) ;
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

      protected void S322( )
      {
         /* 'DOEXPORTREPORT' Routine */
         returnInSub = false;
         Innewwindow1_Target = formatLink("core.documentowwexportreport.aspx") ;
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Target", Innewwindow1_Target);
         Innewwindow1_Height = "600";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Height", Innewwindow1_Height);
         Innewwindow1_Width = "800";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Width", Innewwindow1_Width);
         this.executeUsercontrolMethod("", false, "INNEWWINDOW1Container", "OpenWindow", "", new Object[] {});
      }

      protected void S112( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         if ( ! ( ( StringUtil.StrCmp(AV66DocOrigem, "NEGOCIOPJ") == 0 ) ) )
         {
            divDvpanel_tableoportunidade_cell_Class = "Invisible";
            AssignProp("", false, divDvpanel_tableoportunidade_cell_Internalname, "Class", divDvpanel_tableoportunidade_cell_Class, true);
         }
         else
         {
            divDvpanel_tableoportunidade_cell_Class = "col-xs-12 CellMarginBottom20";
            AssignProp("", false, divDvpanel_tableoportunidade_cell_Internalname, "Class", divDvpanel_tableoportunidade_cell_Class, true);
         }
         if ( StringUtil.StrCmp(AV66DocOrigem, "NEGOCIOPJ") == 0 )
         {
            /* Using cursor H005C4 */
            pr_default.execute(2, new Object[] {AV67DocOrigemID});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A345NegID = H005C4_A345NegID[0];
               A362NegAssunto = H005C4_A362NegAssunto[0];
               A356NegCodigo = H005C4_A356NegCodigo[0];
               Dvpanel_tableoportunidade_Title = StringUtil.StringReplace( StringUtil.StringReplace( Dvpanel_tableoportunidade_Title, "[!NEGCODIGO!]", StringUtil.Trim( StringUtil.Str( (decimal)(A356NegCodigo), 12, 0))), "[!NEGASSUNTO!]", StringUtil.Trim( A362NegAssunto));
               ucDvpanel_tableoportunidade.SendProperty(context, "", false, Dvpanel_tableoportunidade_Internalname, "Title", Dvpanel_tableoportunidade_Title);
               pr_default.readNext(2);
            }
            pr_default.close(2);
         }
      }

      protected void wb_table5_169_5C2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTabledvelop_confirmpanel_novaversao_Internalname, tblTabledvelop_confirmpanel_novaversao_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucDvelop_confirmpanel_novaversao.SetProperty("Title", Dvelop_confirmpanel_novaversao_Title);
            ucDvelop_confirmpanel_novaversao.SetProperty("ConfirmationText", Dvelop_confirmpanel_novaversao_Confirmationtext);
            ucDvelop_confirmpanel_novaversao.SetProperty("YesButtonCaption", Dvelop_confirmpanel_novaversao_Yesbuttoncaption);
            ucDvelop_confirmpanel_novaversao.SetProperty("NoButtonCaption", Dvelop_confirmpanel_novaversao_Nobuttoncaption);
            ucDvelop_confirmpanel_novaversao.SetProperty("CancelButtonCaption", Dvelop_confirmpanel_novaversao_Cancelbuttoncaption);
            ucDvelop_confirmpanel_novaversao.SetProperty("YesButtonPosition", Dvelop_confirmpanel_novaversao_Yesbuttonposition);
            ucDvelop_confirmpanel_novaversao.SetProperty("ConfirmType", Dvelop_confirmpanel_novaversao_Confirmtype);
            ucDvelop_confirmpanel_novaversao.Render(context, "dvelop.gxbootstrap.confirmpanel", Dvelop_confirmpanel_novaversao_Internalname, "DVELOP_CONFIRMPANEL_NOVAVERSAOContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVELOP_CONFIRMPANEL_NOVAVERSAOContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table5_169_5C2e( true) ;
         }
         else
         {
            wb_table5_169_5C2e( false) ;
         }
      }

      protected void wb_table4_117_5C2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 121,'',false,'" + sGXsfl_138_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator3, cmbavDynamicfiltersoperator3_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0)), 1, cmbavDynamicfiltersoperator3_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator3.Visible, cmbavDynamicfiltersoperator3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,121);\"", "", true, 0, "HLP_core\\DocumentoWW.htm");
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", (string)(cmbavDynamicfiltersoperator3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_docversao3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavDocversao3_Internalname, "Doc Versao3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 124,'',false,'" + sGXsfl_138_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDocversao3_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV30DocVersao3), 4, 0, ",", "")), StringUtil.LTrim( ((edtavDocversao3_Enabled!=0) ? context.localUtil.Format( (decimal)(AV30DocVersao3), "ZZZ9") : context.localUtil.Format( (decimal)(AV30DocVersao3), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,124);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDocversao3_Jsonclick, 0, "Attribute", "", "", "", "", edtavDocversao3_Visible, edtavDocversao3_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_core\\DocumentoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_doctiposigla3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavDoctiposigla3_Internalname, "Doc Tipo Sigla3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 127,'',false,'" + sGXsfl_138_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDoctiposigla3_Internalname, AV31DocTipoSigla3, StringUtil.RTrim( context.localUtil.Format( AV31DocTipoSigla3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,127);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDoctiposigla3_Jsonclick, 0, "Attribute", "", "", "", "", edtavDoctiposigla3_Visible, edtavDoctiposigla3_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\DocumentoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter3_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 129,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters3_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters3_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters3_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS3\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_core\\DocumentoWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_117_5C2e( true) ;
         }
         else
         {
            wb_table4_117_5C2e( false) ;
         }
      }

      protected void wb_table3_92_5C2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'" + sGXsfl_138_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator2, cmbavDynamicfiltersoperator2_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0)), 1, cmbavDynamicfiltersoperator2_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator2.Visible, cmbavDynamicfiltersoperator2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,96);\"", "", true, 0, "HLP_core\\DocumentoWW.htm");
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", (string)(cmbavDynamicfiltersoperator2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_docversao2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavDocversao2_Internalname, "Doc Versao2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'" + sGXsfl_138_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDocversao2_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25DocVersao2), 4, 0, ",", "")), StringUtil.LTrim( ((edtavDocversao2_Enabled!=0) ? context.localUtil.Format( (decimal)(AV25DocVersao2), "ZZZ9") : context.localUtil.Format( (decimal)(AV25DocVersao2), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,99);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDocversao2_Jsonclick, 0, "Attribute", "", "", "", "", edtavDocversao2_Visible, edtavDocversao2_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_core\\DocumentoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_doctiposigla2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavDoctiposigla2_Internalname, "Doc Tipo Sigla2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 102,'',false,'" + sGXsfl_138_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDoctiposigla2_Internalname, AV26DocTipoSigla2, StringUtil.RTrim( context.localUtil.Format( AV26DocTipoSigla2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,102);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDoctiposigla2_Jsonclick, 0, "Attribute", "", "", "", "", edtavDoctiposigla2_Visible, edtavDoctiposigla2_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\DocumentoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters2_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters2_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_core\\DocumentoWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 106,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters2_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters2_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_core\\DocumentoWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_92_5C2e( true) ;
         }
         else
         {
            wb_table3_92_5C2e( false) ;
         }
      }

      protected void wb_table2_67_5C2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'" + sGXsfl_138_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator1, cmbavDynamicfiltersoperator1_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0)), 1, cmbavDynamicfiltersoperator1_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator1.Visible, cmbavDynamicfiltersoperator1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,71);\"", "", true, 0, "HLP_core\\DocumentoWW.htm");
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", (string)(cmbavDynamicfiltersoperator1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_docversao1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavDocversao1_Internalname, "Doc Versao1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'" + sGXsfl_138_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDocversao1_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20DocVersao1), 4, 0, ",", "")), StringUtil.LTrim( ((edtavDocversao1_Enabled!=0) ? context.localUtil.Format( (decimal)(AV20DocVersao1), "ZZZ9") : context.localUtil.Format( (decimal)(AV20DocVersao1), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDocversao1_Jsonclick, 0, "Attribute", "", "", "", "", edtavDocversao1_Visible, edtavDocversao1_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_core\\DocumentoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_doctiposigla1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavDoctiposigla1_Internalname, "Doc Tipo Sigla1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'',false,'" + sGXsfl_138_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDoctiposigla1_Internalname, AV21DocTipoSigla1, StringUtil.RTrim( context.localUtil.Format( AV21DocTipoSigla1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,77);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDoctiposigla1_Jsonclick, 0, "Attribute", "", "", "", "", edtavDoctiposigla1_Visible, edtavDoctiposigla1_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\DocumentoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters1_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters1_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_core\\DocumentoWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters1_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters1_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_core\\DocumentoWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_67_5C2e( true) ;
         }
         else
         {
            wb_table2_67_5C2e( false) ;
         }
      }

      protected void wb_table1_43_5C2( bool wbgen )
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
            wb_table6_48_5C2( true) ;
         }
         else
         {
            wb_table6_48_5C2( false) ;
         }
         return  ;
      }

      protected void wb_table6_48_5C2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_43_5C2e( true) ;
         }
         else
         {
            wb_table1_43_5C2e( false) ;
         }
      }

      protected void wb_table6_48_5C2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'" + sGXsfl_138_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV17FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV17FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,52);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Pesquisar", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_core\\DocumentoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table6_48_5C2e( true) ;
         }
         else
         {
            wb_table6_48_5C2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV66DocOrigem = (string)getParm(obj,0);
         AssignAttri("", false, "AV66DocOrigem", AV66DocOrigem);
         GxWebStd.gx_hidden_field( context, "gxhash_vDOCORIGEM", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV66DocOrigem, "")), context));
         AV67DocOrigemID = (string)getParm(obj,1);
         AssignAttri("", false, "AV67DocOrigemID", AV67DocOrigemID);
         GxWebStd.gx_hidden_field( context, "gxhash_vDOCORIGEMID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV67DocOrigemID, "")), context));
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
         PA5C2( ) ;
         WS5C2( ) ;
         WE5C2( ) ;
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
         if ( ! ( WebComp_Wcnegociopjgeneral == null ) )
         {
            if ( StringUtil.Len( WebComp_Wcnegociopjgeneral_Component) != 0 )
            {
               WebComp_Wcnegociopjgeneral.componentthemes();
            }
         }
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2023828234313", true, true);
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
         context.AddJavascriptSource("core/documentoww.js", "?2023828234315", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
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

      protected void SubsflControlProps_1382( )
      {
         edtavDetailwebcomponent_Internalname = "vDETAILWEBCOMPONENT_"+sGXsfl_138_idx;
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_138_idx;
         edtDocID_Internalname = "DOCID_"+sGXsfl_138_idx;
         edtDocOrigem_Internalname = "DOCORIGEM_"+sGXsfl_138_idx;
         edtDocOrigemID_Internalname = "DOCORIGEMID_"+sGXsfl_138_idx;
         edtDocTipoNome_Internalname = "DOCTIPONOME_"+sGXsfl_138_idx;
         edtDocNome_Internalname = "DOCNOME_"+sGXsfl_138_idx;
         edtDocVersao_Internalname = "DOCVERSAO_"+sGXsfl_138_idx;
         edtDocInsDataHora_Internalname = "DOCINSDATAHORA_"+sGXsfl_138_idx;
         chkDocContrato_Internalname = "DOCCONTRATO_"+sGXsfl_138_idx;
         chkDocAssinado_Internalname = "DOCASSINADO_"+sGXsfl_138_idx;
         edtDocTipoID_Internalname = "DOCTIPOID_"+sGXsfl_138_idx;
         edtDocVersaoIDPai_Internalname = "DOCVERSAOIDPAI_"+sGXsfl_138_idx;
      }

      protected void SubsflControlProps_fel_1382( )
      {
         edtavDetailwebcomponent_Internalname = "vDETAILWEBCOMPONENT_"+sGXsfl_138_fel_idx;
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_138_fel_idx;
         edtDocID_Internalname = "DOCID_"+sGXsfl_138_fel_idx;
         edtDocOrigem_Internalname = "DOCORIGEM_"+sGXsfl_138_fel_idx;
         edtDocOrigemID_Internalname = "DOCORIGEMID_"+sGXsfl_138_fel_idx;
         edtDocTipoNome_Internalname = "DOCTIPONOME_"+sGXsfl_138_fel_idx;
         edtDocNome_Internalname = "DOCNOME_"+sGXsfl_138_fel_idx;
         edtDocVersao_Internalname = "DOCVERSAO_"+sGXsfl_138_fel_idx;
         edtDocInsDataHora_Internalname = "DOCINSDATAHORA_"+sGXsfl_138_fel_idx;
         chkDocContrato_Internalname = "DOCCONTRATO_"+sGXsfl_138_fel_idx;
         chkDocAssinado_Internalname = "DOCASSINADO_"+sGXsfl_138_fel_idx;
         edtDocTipoID_Internalname = "DOCTIPOID_"+sGXsfl_138_fel_idx;
         edtDocVersaoIDPai_Internalname = "DOCVERSAOIDPAI_"+sGXsfl_138_fel_idx;
      }

      protected void sendrow_1382( )
      {
         SubsflControlProps_1382( ) ;
         WB5C0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_138_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_138_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_138_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavDetailwebcomponent_Enabled!=0)&&(edtavDetailwebcomponent_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 139,'',false,'"+sGXsfl_138_idx+"',138)\"" : " ");
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDetailwebcomponent_Internalname,StringUtil.RTrim( AV71DetailWebComponent),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavDetailwebcomponent_Enabled!=0)&&(edtavDetailwebcomponent_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,139);\"" : " "),"'"+""+"'"+",false,"+"'"+"EVDETAILWEBCOMPONENT.CLICK."+sGXsfl_138_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavDetailwebcomponent_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWIconActionColumn WCD_ActionColumn",(string)"",(short)-1,(int)edtavDetailwebcomponent_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)1,(short)138,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = " " + ((cmbavGridactions.Enabled!=0)&&(cmbavGridactions.Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 140,'',false,'"+sGXsfl_138_idx+"',138)\"" : " ");
            if ( ( cmbavGridactions.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vGRIDACTIONS_" + sGXsfl_138_idx;
               cmbavGridactions.Name = GXCCtl;
               cmbavGridactions.WebTags = "";
               if ( cmbavGridactions.ItemCount > 0 )
               {
                  AV60GridActions = (short)(Math.Round(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV60GridActions), 4, 0))), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV60GridActions), 4, 0));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavGridactions,(string)cmbavGridactions_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV60GridActions), 4, 0)),(short)1,(string)cmbavGridactions_Jsonclick,(short)5,"'"+""+"'"+",false,"+"'"+"EVGRIDACTIONS.CLICK."+sGXsfl_138_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)cmbavGridactions_Class,(string)"WWActionGroupColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((cmbavGridactions.Enabled!=0)&&(cmbavGridactions.Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,140);\"" : " "),(string)"",(bool)true,(short)0});
            cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV60GridActions), 4, 0));
            AssignProp("", false, cmbavGridactions_Internalname, "Values", (string)(cmbavGridactions.ToJavascriptSource()), !bGXsfl_138_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDocID_Internalname,A289DocID.ToString(),A289DocID.ToString(),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDocID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)138,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDocOrigem_Internalname,(string)A290DocOrigem,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDocOrigem_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)138,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDocOrigemID_Internalname,(string)A291DocOrigemID,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDocOrigemID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)50,(short)0,(short)0,(short)138,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtDocTipoNome_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDocTipoNome_Internalname,(string)A148DocTipoNome,StringUtil.RTrim( context.localUtil.Format( A148DocTipoNome, "@!")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDocTipoNome_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtDocTipoNome_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)138,(short)0,(short)-1,(short)-1,(bool)true,(string)"core\\Nome",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtDocNome_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDocNome_Internalname,(string)A305DocNome,StringUtil.RTrim( context.localUtil.Format( A305DocNome, "@!")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtDocNome_Link,(string)"",(string)"",(string)"",(string)edtDocNome_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtDocNome_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)138,(short)0,(short)-1,(short)-1,(bool)true,(string)"core\\Nome",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtDocVersao_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDocVersao_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A325DocVersao), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A325DocVersao), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDocVersao_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtDocVersao_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)138,(short)0,(short)-1,(short)0,(bool)true,(string)"core\\Versao",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtDocInsDataHora_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDocInsDataHora_Internalname,context.localUtil.TToC( A294DocInsDataHora, 10, 12, 0, 3, "/", ":", " "),context.localUtil.Format( A294DocInsDataHora, "99/99/9999 99:99:99.999"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDocInsDataHora_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtDocInsDataHora_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)24,(short)0,(short)0,(short)138,(short)0,(short)-1,(short)0,(bool)true,(string)"core\\DataHoraSegundoMS",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((chkDocContrato.Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "DOCCONTRATO_" + sGXsfl_138_idx;
            chkDocContrato.Name = GXCCtl;
            chkDocContrato.WebTags = "";
            chkDocContrato.Caption = "";
            AssignProp("", false, chkDocContrato_Internalname, "TitleCaption", chkDocContrato.Caption, !bGXsfl_138_Refreshing);
            chkDocContrato.CheckedValue = "false";
            A480DocContrato = StringUtil.StrToBool( StringUtil.BoolToStr( A480DocContrato));
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkDocContrato_Internalname,StringUtil.BoolToStr( A480DocContrato),(string)"",(string)"",chkDocContrato.Visible,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((chkDocAssinado.Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "DOCASSINADO_" + sGXsfl_138_idx;
            chkDocAssinado.Name = GXCCtl;
            chkDocAssinado.WebTags = "";
            chkDocAssinado.Caption = "";
            AssignProp("", false, chkDocAssinado_Internalname, "TitleCaption", chkDocAssinado.Caption, !bGXsfl_138_Refreshing);
            chkDocAssinado.CheckedValue = "false";
            A481DocAssinado = StringUtil.StrToBool( StringUtil.BoolToStr( A481DocAssinado));
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkDocAssinado_Internalname,StringUtil.BoolToStr( A481DocAssinado),(string)"",(string)"",chkDocAssinado.Visible,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDocTipoID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A146DocTipoID), 11, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A146DocTipoID), "ZZZ,ZZZ,ZZ9")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDocTipoID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)11,(short)0,(short)0,(short)138,(short)0,(short)-1,(short)0,(bool)true,(string)"core\\ID_Autonum",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDocVersaoIDPai_Internalname,A326DocVersaoIDPai.ToString(),A326DocVersaoIDPai.ToString(),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDocVersaoIDPai_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)138,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
            send_integrity_lvl_hashes5C2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_138_idx = ((subGrid_Islastpage==1)&&(nGXsfl_138_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_138_idx+1);
            sGXsfl_138_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_138_idx), 4, 0), 4, "0");
            SubsflControlProps_1382( ) ;
         }
         /* End function sendrow_1382 */
      }

      protected void init_web_controls( )
      {
         cmbavDynamicfiltersselector1.Name = "vDYNAMICFILTERSSELECTOR1";
         cmbavDynamicfiltersselector1.WebTags = "";
         cmbavDynamicfiltersselector1.addItem("DOCVERSAO", "Versão", 0);
         cmbavDynamicfiltersselector1.addItem("DOCTIPOSIGLA", "Sigla", 0);
         if ( cmbavDynamicfiltersselector1.ItemCount > 0 )
         {
            AV18DynamicFiltersSelector1 = cmbavDynamicfiltersselector1.getValidValue(AV18DynamicFiltersSelector1);
            AssignAttri("", false, "AV18DynamicFiltersSelector1", AV18DynamicFiltersSelector1);
         }
         cmbavDynamicfiltersoperator1.Name = "vDYNAMICFILTERSOPERATOR1";
         cmbavDynamicfiltersoperator1.WebTags = "";
         cmbavDynamicfiltersoperator1.addItem("0", ">=", 0);
         cmbavDynamicfiltersoperator1.addItem("1", "=", 0);
         cmbavDynamicfiltersoperator1.addItem("2", "<=", 0);
         if ( cmbavDynamicfiltersoperator1.ItemCount > 0 )
         {
            AV19DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         }
         cmbavDynamicfiltersselector2.Name = "vDYNAMICFILTERSSELECTOR2";
         cmbavDynamicfiltersselector2.WebTags = "";
         cmbavDynamicfiltersselector2.addItem("DOCVERSAO", "Versão", 0);
         cmbavDynamicfiltersselector2.addItem("DOCTIPOSIGLA", "Sigla", 0);
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
            AV23DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV23DynamicFiltersSelector2);
            AssignAttri("", false, "AV23DynamicFiltersSelector2", AV23DynamicFiltersSelector2);
         }
         cmbavDynamicfiltersoperator2.Name = "vDYNAMICFILTERSOPERATOR2";
         cmbavDynamicfiltersoperator2.WebTags = "";
         cmbavDynamicfiltersoperator2.addItem("0", ">=", 0);
         cmbavDynamicfiltersoperator2.addItem("1", "=", 0);
         cmbavDynamicfiltersoperator2.addItem("2", "<=", 0);
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV24DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV24DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         }
         cmbavDynamicfiltersselector3.Name = "vDYNAMICFILTERSSELECTOR3";
         cmbavDynamicfiltersselector3.WebTags = "";
         cmbavDynamicfiltersselector3.addItem("DOCVERSAO", "Versão", 0);
         cmbavDynamicfiltersselector3.addItem("DOCTIPOSIGLA", "Sigla", 0);
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV28DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV28DynamicFiltersSelector3);
            AssignAttri("", false, "AV28DynamicFiltersSelector3", AV28DynamicFiltersSelector3);
         }
         cmbavDynamicfiltersoperator3.Name = "vDYNAMICFILTERSOPERATOR3";
         cmbavDynamicfiltersoperator3.WebTags = "";
         cmbavDynamicfiltersoperator3.addItem("0", ">=", 0);
         cmbavDynamicfiltersoperator3.addItem("1", "=", 0);
         cmbavDynamicfiltersoperator3.addItem("2", "<=", 0);
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV29DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV29DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         }
         GXCCtl = "vGRIDACTIONS_" + sGXsfl_138_idx;
         cmbavGridactions.Name = GXCCtl;
         cmbavGridactions.WebTags = "";
         if ( cmbavGridactions.ItemCount > 0 )
         {
            AV60GridActions = (short)(Math.Round(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV60GridActions), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV60GridActions), 4, 0));
         }
         GXCCtl = "DOCCONTRATO_" + sGXsfl_138_idx;
         chkDocContrato.Name = GXCCtl;
         chkDocContrato.WebTags = "";
         chkDocContrato.Caption = "";
         AssignProp("", false, chkDocContrato_Internalname, "TitleCaption", chkDocContrato.Caption, !bGXsfl_138_Refreshing);
         chkDocContrato.CheckedValue = "false";
         A480DocContrato = StringUtil.StrToBool( StringUtil.BoolToStr( A480DocContrato));
         GXCCtl = "DOCASSINADO_" + sGXsfl_138_idx;
         chkDocAssinado.Name = GXCCtl;
         chkDocAssinado.WebTags = "";
         chkDocAssinado.Caption = "";
         AssignProp("", false, chkDocAssinado_Internalname, "TitleCaption", chkDocAssinado.Caption, !bGXsfl_138_Refreshing);
         chkDocAssinado.CheckedValue = "false";
         A481DocAssinado = StringUtil.StrToBool( StringUtil.BoolToStr( A481DocAssinado));
         /* End function init_web_controls */
      }

      protected void StartGridControl138( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"138\">") ;
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
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+cmbavGridactions_Class+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtDocTipoNome_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Tipo") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtDocNome_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Descrição") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtDocVersao_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Versão") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtDocInsDataHora_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Incluído em") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((chkDocContrato.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Contrato") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((chkDocAssinado.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Assinado") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV71DetailWebComponent)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDetailwebcomponent_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV60GridActions), 4, 0, ".", ""))));
            GridColumn.AddObjectProperty("Class", StringUtil.RTrim( cmbavGridactions_Class));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A289DocID.ToString()));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A290DocOrigem));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A291DocOrigemID));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A148DocTipoNome));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtDocTipoNome_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A305DocNome));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtDocNome_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtDocNome_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A325DocVersao), 4, 0, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtDocVersao_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A294DocInsDataHora, 10, 12, 0, 3, "/", ":", " ")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtDocInsDataHora_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( A480DocContrato)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkDocContrato.Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( A481DocAssinado)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkDocAssinado.Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A146DocTipoID), 11, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A326DocVersaoIDPai.ToString()));
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
         divTableoportunidade_Internalname = "TABLEOPORTUNIDADE";
         Dvpanel_tableoportunidade_Internalname = "DVPANEL_TABLEOPORTUNIDADE";
         divDvpanel_tableoportunidade_cell_Internalname = "DVPANEL_TABLEOPORTUNIDADE_CELL";
         edtavDocorigem_filtro_Internalname = "vDOCORIGEM_FILTRO";
         edtavDocorigemid_filtro_Internalname = "vDOCORIGEMID_FILTRO";
         bttBtncancel_Internalname = "BTNCANCEL";
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
         edtavDocversao1_Internalname = "vDOCVERSAO1";
         cellFilter_docversao1_cell_Internalname = "FILTER_DOCVERSAO1_CELL";
         edtavDoctiposigla1_Internalname = "vDOCTIPOSIGLA1";
         cellFilter_doctiposigla1_cell_Internalname = "FILTER_DOCTIPOSIGLA1_CELL";
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
         edtavDocversao2_Internalname = "vDOCVERSAO2";
         cellFilter_docversao2_cell_Internalname = "FILTER_DOCVERSAO2_CELL";
         edtavDoctiposigla2_Internalname = "vDOCTIPOSIGLA2";
         cellFilter_doctiposigla2_cell_Internalname = "FILTER_DOCTIPOSIGLA2_CELL";
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
         edtavDocversao3_Internalname = "vDOCVERSAO3";
         cellFilter_docversao3_cell_Internalname = "FILTER_DOCVERSAO3_CELL";
         edtavDoctiposigla3_Internalname = "vDOCTIPOSIGLA3";
         cellFilter_doctiposigla3_cell_Internalname = "FILTER_DOCTIPOSIGLA3_CELL";
         imgRemovedynamicfilters3_Internalname = "REMOVEDYNAMICFILTERS3";
         cellDynamicfilters_removefilter3_cell_Internalname = "DYNAMICFILTERS_REMOVEFILTER3_CELL";
         tblTablemergeddynamicfilters3_Internalname = "TABLEMERGEDDYNAMICFILTERS3";
         divTabledynamicfiltersrow3_Internalname = "TABLEDYNAMICFILTERSROW3";
         divTabledynamicfilters_Internalname = "TABLEDYNAMICFILTERS";
         divAdvancedfilterscontainer_Internalname = "ADVANCEDFILTERSCONTAINER";
         divTableheader_Internalname = "TABLEHEADER";
         edtavDetailwebcomponent_Internalname = "vDETAILWEBCOMPONENT";
         cmbavGridactions_Internalname = "vGRIDACTIONS";
         edtDocID_Internalname = "DOCID";
         edtDocOrigem_Internalname = "DOCORIGEM";
         edtDocOrigemID_Internalname = "DOCORIGEMID";
         edtDocTipoNome_Internalname = "DOCTIPONOME";
         edtDocNome_Internalname = "DOCNOME";
         edtDocVersao_Internalname = "DOCVERSAO";
         edtDocInsDataHora_Internalname = "DOCINSDATAHORA";
         chkDocContrato_Internalname = "DOCCONTRATO";
         chkDocAssinado_Internalname = "DOCASSINADO";
         edtDocTipoID_Internalname = "DOCTIPOID";
         edtDocVersaoIDPai_Internalname = "DOCVERSAOIDPAI";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divCell_grid_dwc_Internalname = "CELL_GRID_DWC";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         Ddo_agexport_Internalname = "DDO_AGEXPORT";
         Ddc_subscriptions_Internalname = "DDC_SUBSCRIPTIONS";
         lblJsdynamicfilters_Internalname = "JSDYNAMICFILTERS";
         Ddo_grid_Internalname = "DDO_GRID";
         Innewwindow1_Internalname = "INNEWWINDOW1";
         Ddo_gridcolumnsselector_Internalname = "DDO_GRIDCOLUMNSSELECTOR";
         edtavDocorigem_Internalname = "vDOCORIGEM";
         edtavDocorigemid_Internalname = "vDOCORIGEMID";
         Dvelop_confirmpanel_novaversao_Internalname = "DVELOP_CONFIRMPANEL_NOVAVERSAO";
         tblTabledvelop_confirmpanel_novaversao_Internalname = "TABLEDVELOP_CONFIRMPANEL_NOVAVERSAO";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
         divDiv_wwpauxwc_Internalname = "DIV_WWPAUXWC";
         edtavDdo_docinsdatahoraauxdatetext_Internalname = "vDDO_DOCINSDATAHORAAUXDATETEXT";
         Tfdocinsdatahora_rangepicker_Internalname = "TFDOCINSDATAHORA_RANGEPICKER";
         divDdo_docinsdatahoraauxdates_Internalname = "DDO_DOCINSDATAHORAAUXDATES";
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
         edtDocVersaoIDPai_Jsonclick = "";
         edtDocTipoID_Jsonclick = "";
         chkDocAssinado.Caption = "";
         chkDocContrato.Caption = "";
         edtDocInsDataHora_Jsonclick = "";
         edtDocVersao_Jsonclick = "";
         edtDocNome_Jsonclick = "";
         edtDocNome_Link = "";
         edtDocTipoNome_Jsonclick = "";
         edtDocOrigemID_Jsonclick = "";
         edtDocOrigem_Jsonclick = "";
         edtDocID_Jsonclick = "";
         cmbavGridactions_Jsonclick = "";
         cmbavGridactions.Visible = -1;
         cmbavGridactions.Enabled = 1;
         cmbavGridactions_Class = "ConvertToDDO";
         edtavDetailwebcomponent_Jsonclick = "";
         edtavDetailwebcomponent_Visible = -1;
         edtavDetailwebcomponent_Enabled = 1;
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         imgRemovedynamicfilters1_Visible = 1;
         imgAdddynamicfilters1_Visible = 1;
         edtavDoctiposigla1_Jsonclick = "";
         edtavDoctiposigla1_Enabled = 1;
         edtavDocversao1_Jsonclick = "";
         edtavDocversao1_Enabled = 1;
         cmbavDynamicfiltersoperator1_Jsonclick = "";
         cmbavDynamicfiltersoperator1.Enabled = 1;
         imgRemovedynamicfilters2_Visible = 1;
         imgAdddynamicfilters2_Visible = 1;
         edtavDoctiposigla2_Jsonclick = "";
         edtavDoctiposigla2_Enabled = 1;
         edtavDocversao2_Jsonclick = "";
         edtavDocversao2_Enabled = 1;
         cmbavDynamicfiltersoperator2_Jsonclick = "";
         cmbavDynamicfiltersoperator2.Enabled = 1;
         edtavDoctiposigla3_Jsonclick = "";
         edtavDoctiposigla3_Enabled = 1;
         edtavDocversao3_Jsonclick = "";
         edtavDocversao3_Enabled = 1;
         cmbavDynamicfiltersoperator3_Jsonclick = "";
         cmbavDynamicfiltersoperator3.Enabled = 1;
         cmbavDynamicfiltersoperator3.Visible = 1;
         edtavDoctiposigla3_Visible = 1;
         edtavDocversao3_Visible = 1;
         cmbavDynamicfiltersoperator2.Visible = 1;
         edtavDoctiposigla2_Visible = 1;
         edtavDocversao2_Visible = 1;
         cmbavDynamicfiltersoperator1.Visible = 1;
         edtavDoctiposigla1_Visible = 1;
         edtavDocversao1_Visible = 1;
         chkDocAssinado.Visible = -1;
         chkDocContrato.Visible = -1;
         edtDocInsDataHora_Visible = -1;
         edtDocVersao_Visible = -1;
         edtDocNome_Visible = -1;
         edtDocTipoNome_Visible = -1;
         subGrid_Sortable = 0;
         edtavDdo_docinsdatahoraauxdatetext_Jsonclick = "";
         edtavDocorigemid_Jsonclick = "";
         edtavDocorigemid_Visible = 1;
         edtavDocorigem_Jsonclick = "";
         edtavDocorigem_Visible = 1;
         lblJsdynamicfilters_Caption = "JSDynamicFilters";
         divCell_grid_dwc_Class = "col-xs-12";
         cmbavDynamicfiltersselector3_Jsonclick = "";
         cmbavDynamicfiltersselector3.Enabled = 1;
         cmbavDynamicfiltersselector2_Jsonclick = "";
         cmbavDynamicfiltersselector2.Enabled = 1;
         cmbavDynamicfiltersselector1_Jsonclick = "";
         cmbavDynamicfiltersselector1.Enabled = 1;
         bttBtnsubscriptions_Visible = 1;
         bttBtninsert_Visible = 1;
         edtavDocorigemid_filtro_Jsonclick = "";
         edtavDocorigemid_filtro_Enabled = 1;
         edtavDocorigem_filtro_Jsonclick = "";
         edtavDocorigem_filtro_Enabled = 1;
         divDvpanel_tableoportunidade_cell_Class = "col-xs-12";
         Grid_empowerer_Fixedcolumns = ";L;;;;;;;;;;;";
         Grid_empowerer_Hascolumnsselector = Convert.ToBoolean( -1);
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Dvelop_confirmpanel_novaversao_Confirmtype = "1";
         Dvelop_confirmpanel_novaversao_Yesbuttonposition = "left";
         Dvelop_confirmpanel_novaversao_Cancelbuttoncaption = "WWP_ConfirmTextCancel";
         Dvelop_confirmpanel_novaversao_Nobuttoncaption = "WWP_ConfirmTextNo";
         Dvelop_confirmpanel_novaversao_Yesbuttoncaption = "WWP_ConfirmTextYes";
         Dvelop_confirmpanel_novaversao_Confirmationtext = "Deseja realmente Incluir uma Nova Versão do Documento?";
         Dvelop_confirmpanel_novaversao_Title = "Decida";
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
         Ddo_grid_Format = "||4.0|||";
         Ddo_grid_Datalistproc = "core.DocumentoWWGetFilterData";
         Ddo_grid_Datalistfixedvalues = "||||1:WWP_TSChecked,2:WWP_TSUnChecked|1:WWP_TSChecked,2:WWP_TSUnChecked";
         Ddo_grid_Datalisttype = "Dynamic|Dynamic|||FixedValues|FixedValues";
         Ddo_grid_Includedatalist = "T|T|||T|T";
         Ddo_grid_Filterisrange = "||T|P||";
         Ddo_grid_Filtertype = "Character|Character|Numeric|Date||";
         Ddo_grid_Includefilter = "T|T|T|T||";
         Ddo_grid_Fixable = "T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "2|3|4|5|6|7";
         Ddo_grid_Columnids = "5:DocTipoNome|6:DocNome|7:DocVersao|8:DocInsDataHora|9:DocContrato|10:DocAssinado";
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
         Dvpanel_tableoportunidade_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableoportunidade_Iconposition = "Right";
         Dvpanel_tableoportunidade_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableoportunidade_Collapsed = Convert.ToBoolean( 1);
         Dvpanel_tableoportunidade_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_tableoportunidade_Title = "Negociação [!NEGCODIGO!]: [!NEGASSUNTO!]";
         Dvpanel_tableoportunidade_Cls = "PanelCard_IconAndTitle Panel_BaseColor";
         Dvpanel_tableoportunidade_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tableoportunidade_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tableoportunidade_Width = "100%";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = " Documento";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV20DocVersao1',fld:'vDOCVERSAO1',pic:'ZZZ9'},{av:'AV21DocTipoSigla1',fld:'vDOCTIPOSIGLA1',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV25DocVersao2',fld:'vDOCVERSAO2',pic:'ZZZ9'},{av:'AV26DocTipoSigla2',fld:'vDOCTIPOSIGLA2',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV30DocVersao3',fld:'vDOCVERSAO3',pic:'ZZZ9'},{av:'AV31DocTipoSigla3',fld:'vDOCTIPOSIGLA3',pic:''},{av:'AV66DocOrigem',fld:'vDOCORIGEM',pic:'',hsh:true},{av:'AV67DocOrigemID',fld:'vDOCORIGEMID',pic:'',hsh:true},{av:'AV80Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV68DocOrigem_Filtro',fld:'vDOCORIGEM_FILTRO',pic:''},{av:'AV69DocOrigemID_Filtro',fld:'vDOCORIGEMID_FILTRO',pic:''},{av:'AV46TFDocTipoNome',fld:'vTFDOCTIPONOME',pic:'@!'},{av:'AV47TFDocTipoNome_Sel',fld:'vTFDOCTIPONOME_SEL',pic:'@!'},{av:'AV44TFDocNome',fld:'vTFDOCNOME',pic:'@!'},{av:'AV45TFDocNome_Sel',fld:'vTFDOCNOME_SEL',pic:'@!'},{av:'AV74TFDocVersao',fld:'vTFDOCVERSAO',pic:'ZZZ9'},{av:'AV75TFDocVersao_To',fld:'vTFDOCVERSAO_TO',pic:'ZZZ9'},{av:'AV48TFDocInsDataHora',fld:'vTFDOCINSDATAHORA',pic:'99/99/9999 99:99:99.999'},{av:'AV49TFDocInsDataHora_To',fld:'vTFDOCINSDATAHORA_TO',pic:'99/99/9999 99:99:99.999'},{av:'AV72TFDocContrato_Sel',fld:'vTFDOCCONTRATO_SEL',pic:'9'},{av:'AV73TFDocAssinado_Sel',fld:'vTFDOCASSINADO_SEL',pic:'9'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV61IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV62IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV76IsAuthorized_NovaVersao',fld:'vISAUTHORIZED_NOVAVERSAO',pic:'',hsh:true},{av:'AV70IsAuthorized_DocNome',fld:'vISAUTHORIZED_DOCNOME',pic:'',hsh:true},{av:'AV65IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtDocTipoNome_Visible',ctrl:'DOCTIPONOME',prop:'Visible'},{av:'edtDocNome_Visible',ctrl:'DOCNOME',prop:'Visible'},{av:'edtDocVersao_Visible',ctrl:'DOCVERSAO',prop:'Visible'},{av:'edtDocInsDataHora_Visible',ctrl:'DOCINSDATAHORA',prop:'Visible'},{av:'chkDocContrato.Visible',ctrl:'DOCCONTRATO',prop:'Visible'},{av:'chkDocAssinado.Visible',ctrl:'DOCASSINADO',prop:'Visible'},{av:'AV57GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV58GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV59GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV61IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV62IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV76IsAuthorized_NovaVersao',fld:'vISAUTHORIZED_NOVAVERSAO',pic:'',hsh:true},{av:'AV65IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E125C2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV20DocVersao1',fld:'vDOCVERSAO1',pic:'ZZZ9'},{av:'AV21DocTipoSigla1',fld:'vDOCTIPOSIGLA1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV25DocVersao2',fld:'vDOCVERSAO2',pic:'ZZZ9'},{av:'AV26DocTipoSigla2',fld:'vDOCTIPOSIGLA2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV30DocVersao3',fld:'vDOCVERSAO3',pic:'ZZZ9'},{av:'AV31DocTipoSigla3',fld:'vDOCTIPOSIGLA3',pic:''},{av:'AV66DocOrigem',fld:'vDOCORIGEM',pic:'',hsh:true},{av:'AV67DocOrigemID',fld:'vDOCORIGEMID',pic:'',hsh:true},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV80Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV68DocOrigem_Filtro',fld:'vDOCORIGEM_FILTRO',pic:''},{av:'AV69DocOrigemID_Filtro',fld:'vDOCORIGEMID_FILTRO',pic:''},{av:'AV46TFDocTipoNome',fld:'vTFDOCTIPONOME',pic:'@!'},{av:'AV47TFDocTipoNome_Sel',fld:'vTFDOCTIPONOME_SEL',pic:'@!'},{av:'AV44TFDocNome',fld:'vTFDOCNOME',pic:'@!'},{av:'AV45TFDocNome_Sel',fld:'vTFDOCNOME_SEL',pic:'@!'},{av:'AV74TFDocVersao',fld:'vTFDOCVERSAO',pic:'ZZZ9'},{av:'AV75TFDocVersao_To',fld:'vTFDOCVERSAO_TO',pic:'ZZZ9'},{av:'AV48TFDocInsDataHora',fld:'vTFDOCINSDATAHORA',pic:'99/99/9999 99:99:99.999'},{av:'AV49TFDocInsDataHora_To',fld:'vTFDOCINSDATAHORA_TO',pic:'99/99/9999 99:99:99.999'},{av:'AV72TFDocContrato_Sel',fld:'vTFDOCCONTRATO_SEL',pic:'9'},{av:'AV73TFDocAssinado_Sel',fld:'vTFDOCASSINADO_SEL',pic:'9'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV61IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV62IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV76IsAuthorized_NovaVersao',fld:'vISAUTHORIZED_NOVAVERSAO',pic:'',hsh:true},{av:'AV70IsAuthorized_DocNome',fld:'vISAUTHORIZED_DOCNOME',pic:'',hsh:true},{av:'AV65IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E135C2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV20DocVersao1',fld:'vDOCVERSAO1',pic:'ZZZ9'},{av:'AV21DocTipoSigla1',fld:'vDOCTIPOSIGLA1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV25DocVersao2',fld:'vDOCVERSAO2',pic:'ZZZ9'},{av:'AV26DocTipoSigla2',fld:'vDOCTIPOSIGLA2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV30DocVersao3',fld:'vDOCVERSAO3',pic:'ZZZ9'},{av:'AV31DocTipoSigla3',fld:'vDOCTIPOSIGLA3',pic:''},{av:'AV66DocOrigem',fld:'vDOCORIGEM',pic:'',hsh:true},{av:'AV67DocOrigemID',fld:'vDOCORIGEMID',pic:'',hsh:true},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV80Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV68DocOrigem_Filtro',fld:'vDOCORIGEM_FILTRO',pic:''},{av:'AV69DocOrigemID_Filtro',fld:'vDOCORIGEMID_FILTRO',pic:''},{av:'AV46TFDocTipoNome',fld:'vTFDOCTIPONOME',pic:'@!'},{av:'AV47TFDocTipoNome_Sel',fld:'vTFDOCTIPONOME_SEL',pic:'@!'},{av:'AV44TFDocNome',fld:'vTFDOCNOME',pic:'@!'},{av:'AV45TFDocNome_Sel',fld:'vTFDOCNOME_SEL',pic:'@!'},{av:'AV74TFDocVersao',fld:'vTFDOCVERSAO',pic:'ZZZ9'},{av:'AV75TFDocVersao_To',fld:'vTFDOCVERSAO_TO',pic:'ZZZ9'},{av:'AV48TFDocInsDataHora',fld:'vTFDOCINSDATAHORA',pic:'99/99/9999 99:99:99.999'},{av:'AV49TFDocInsDataHora_To',fld:'vTFDOCINSDATAHORA_TO',pic:'99/99/9999 99:99:99.999'},{av:'AV72TFDocContrato_Sel',fld:'vTFDOCCONTRATO_SEL',pic:'9'},{av:'AV73TFDocAssinado_Sel',fld:'vTFDOCASSINADO_SEL',pic:'9'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV61IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV62IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV76IsAuthorized_NovaVersao',fld:'vISAUTHORIZED_NOVAVERSAO',pic:'',hsh:true},{av:'AV70IsAuthorized_DocNome',fld:'vISAUTHORIZED_DOCNOME',pic:'',hsh:true},{av:'AV65IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]}");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","{handler:'E165C2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV20DocVersao1',fld:'vDOCVERSAO1',pic:'ZZZ9'},{av:'AV21DocTipoSigla1',fld:'vDOCTIPOSIGLA1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV25DocVersao2',fld:'vDOCVERSAO2',pic:'ZZZ9'},{av:'AV26DocTipoSigla2',fld:'vDOCTIPOSIGLA2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV30DocVersao3',fld:'vDOCVERSAO3',pic:'ZZZ9'},{av:'AV31DocTipoSigla3',fld:'vDOCTIPOSIGLA3',pic:''},{av:'AV66DocOrigem',fld:'vDOCORIGEM',pic:'',hsh:true},{av:'AV67DocOrigemID',fld:'vDOCORIGEMID',pic:'',hsh:true},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV80Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV68DocOrigem_Filtro',fld:'vDOCORIGEM_FILTRO',pic:''},{av:'AV69DocOrigemID_Filtro',fld:'vDOCORIGEMID_FILTRO',pic:''},{av:'AV46TFDocTipoNome',fld:'vTFDOCTIPONOME',pic:'@!'},{av:'AV47TFDocTipoNome_Sel',fld:'vTFDOCTIPONOME_SEL',pic:'@!'},{av:'AV44TFDocNome',fld:'vTFDOCNOME',pic:'@!'},{av:'AV45TFDocNome_Sel',fld:'vTFDOCNOME_SEL',pic:'@!'},{av:'AV74TFDocVersao',fld:'vTFDOCVERSAO',pic:'ZZZ9'},{av:'AV75TFDocVersao_To',fld:'vTFDOCVERSAO_TO',pic:'ZZZ9'},{av:'AV48TFDocInsDataHora',fld:'vTFDOCINSDATAHORA',pic:'99/99/9999 99:99:99.999'},{av:'AV49TFDocInsDataHora_To',fld:'vTFDOCINSDATAHORA_TO',pic:'99/99/9999 99:99:99.999'},{av:'AV72TFDocContrato_Sel',fld:'vTFDOCCONTRATO_SEL',pic:'9'},{av:'AV73TFDocAssinado_Sel',fld:'vTFDOCASSINADO_SEL',pic:'9'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV61IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV62IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV76IsAuthorized_NovaVersao',fld:'vISAUTHORIZED_NOVAVERSAO',pic:'',hsh:true},{av:'AV70IsAuthorized_DocNome',fld:'vISAUTHORIZED_DOCNOME',pic:'',hsh:true},{av:'AV65IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'Ddo_grid_Activeeventkey',ctrl:'DDO_GRID',prop:'ActiveEventKey'},{av:'Ddo_grid_Selectedvalue_get',ctrl:'DDO_GRID',prop:'SelectedValue_get'},{av:'Ddo_grid_Filteredtextto_get',ctrl:'DDO_GRID',prop:'FilteredTextTo_get'},{av:'Ddo_grid_Filteredtext_get',ctrl:'DDO_GRID',prop:'FilteredText_get'},{av:'Ddo_grid_Selectedcolumn',ctrl:'DDO_GRID',prop:'SelectedColumn'}]");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",",oparms:[{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV73TFDocAssinado_Sel',fld:'vTFDOCASSINADO_SEL',pic:'9'},{av:'AV72TFDocContrato_Sel',fld:'vTFDOCCONTRATO_SEL',pic:'9'},{av:'AV48TFDocInsDataHora',fld:'vTFDOCINSDATAHORA',pic:'99/99/9999 99:99:99.999'},{av:'AV49TFDocInsDataHora_To',fld:'vTFDOCINSDATAHORA_TO',pic:'99/99/9999 99:99:99.999'},{av:'AV74TFDocVersao',fld:'vTFDOCVERSAO',pic:'ZZZ9'},{av:'AV75TFDocVersao_To',fld:'vTFDOCVERSAO_TO',pic:'ZZZ9'},{av:'AV44TFDocNome',fld:'vTFDOCNOME',pic:'@!'},{av:'AV45TFDocNome_Sel',fld:'vTFDOCNOME_SEL',pic:'@!'},{av:'AV46TFDocTipoNome',fld:'vTFDOCTIPONOME',pic:'@!'},{av:'AV47TFDocTipoNome_Sel',fld:'vTFDOCTIPONOME_SEL',pic:'@!'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E305C2',iparms:[{av:'AV61IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV62IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV76IsAuthorized_NovaVersao',fld:'vISAUTHORIZED_NOVAVERSAO',pic:'',hsh:true},{av:'AV70IsAuthorized_DocNome',fld:'vISAUTHORIZED_DOCNOME',pic:'',hsh:true},{av:'A289DocID',fld:'DOCID',pic:'',hsh:true}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'AV71DetailWebComponent',fld:'vDETAILWEBCOMPONENT',pic:''},{av:'cmbavGridactions'},{av:'AV60GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9'},{av:'edtDocNome_Link',ctrl:'DOCNOME',prop:'Link'}]}");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED","{handler:'E175C2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV20DocVersao1',fld:'vDOCVERSAO1',pic:'ZZZ9'},{av:'AV21DocTipoSigla1',fld:'vDOCTIPOSIGLA1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV25DocVersao2',fld:'vDOCVERSAO2',pic:'ZZZ9'},{av:'AV26DocTipoSigla2',fld:'vDOCTIPOSIGLA2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV30DocVersao3',fld:'vDOCVERSAO3',pic:'ZZZ9'},{av:'AV31DocTipoSigla3',fld:'vDOCTIPOSIGLA3',pic:''},{av:'AV66DocOrigem',fld:'vDOCORIGEM',pic:'',hsh:true},{av:'AV67DocOrigemID',fld:'vDOCORIGEMID',pic:'',hsh:true},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV80Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV68DocOrigem_Filtro',fld:'vDOCORIGEM_FILTRO',pic:''},{av:'AV69DocOrigemID_Filtro',fld:'vDOCORIGEMID_FILTRO',pic:''},{av:'AV46TFDocTipoNome',fld:'vTFDOCTIPONOME',pic:'@!'},{av:'AV47TFDocTipoNome_Sel',fld:'vTFDOCTIPONOME_SEL',pic:'@!'},{av:'AV44TFDocNome',fld:'vTFDOCNOME',pic:'@!'},{av:'AV45TFDocNome_Sel',fld:'vTFDOCNOME_SEL',pic:'@!'},{av:'AV74TFDocVersao',fld:'vTFDOCVERSAO',pic:'ZZZ9'},{av:'AV75TFDocVersao_To',fld:'vTFDOCVERSAO_TO',pic:'ZZZ9'},{av:'AV48TFDocInsDataHora',fld:'vTFDOCINSDATAHORA',pic:'99/99/9999 99:99:99.999'},{av:'AV49TFDocInsDataHora_To',fld:'vTFDOCINSDATAHORA_TO',pic:'99/99/9999 99:99:99.999'},{av:'AV72TFDocContrato_Sel',fld:'vTFDOCCONTRATO_SEL',pic:'9'},{av:'AV73TFDocAssinado_Sel',fld:'vTFDOCASSINADO_SEL',pic:'9'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV61IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV62IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV76IsAuthorized_NovaVersao',fld:'vISAUTHORIZED_NOVAVERSAO',pic:'',hsh:true},{av:'AV70IsAuthorized_DocNome',fld:'vISAUTHORIZED_DOCNOME',pic:'',hsh:true},{av:'AV65IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'Ddo_gridcolumnsselector_Columnsselectorvalues',ctrl:'DDO_GRIDCOLUMNSSELECTOR',prop:'ColumnsSelectorValues'}]");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED",",oparms:[{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'edtDocTipoNome_Visible',ctrl:'DOCTIPONOME',prop:'Visible'},{av:'edtDocNome_Visible',ctrl:'DOCNOME',prop:'Visible'},{av:'edtDocVersao_Visible',ctrl:'DOCVERSAO',prop:'Visible'},{av:'edtDocInsDataHora_Visible',ctrl:'DOCINSDATAHORA',prop:'Visible'},{av:'chkDocContrato.Visible',ctrl:'DOCCONTRATO',prop:'Visible'},{av:'chkDocAssinado.Visible',ctrl:'DOCASSINADO',prop:'Visible'},{av:'AV57GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV58GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV59GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV61IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV62IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV76IsAuthorized_NovaVersao',fld:'vISAUTHORIZED_NOVAVERSAO',pic:'',hsh:true},{av:'AV65IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("'ADDDYNAMICFILTERS1'","{handler:'E235C2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV20DocVersao1',fld:'vDOCVERSAO1',pic:'ZZZ9'},{av:'AV21DocTipoSigla1',fld:'vDOCTIPOSIGLA1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV25DocVersao2',fld:'vDOCVERSAO2',pic:'ZZZ9'},{av:'AV26DocTipoSigla2',fld:'vDOCTIPOSIGLA2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV30DocVersao3',fld:'vDOCVERSAO3',pic:'ZZZ9'},{av:'AV31DocTipoSigla3',fld:'vDOCTIPOSIGLA3',pic:''},{av:'AV66DocOrigem',fld:'vDOCORIGEM',pic:'',hsh:true},{av:'AV67DocOrigemID',fld:'vDOCORIGEMID',pic:'',hsh:true},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV80Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV68DocOrigem_Filtro',fld:'vDOCORIGEM_FILTRO',pic:''},{av:'AV69DocOrigemID_Filtro',fld:'vDOCORIGEMID_FILTRO',pic:''},{av:'AV46TFDocTipoNome',fld:'vTFDOCTIPONOME',pic:'@!'},{av:'AV47TFDocTipoNome_Sel',fld:'vTFDOCTIPONOME_SEL',pic:'@!'},{av:'AV44TFDocNome',fld:'vTFDOCNOME',pic:'@!'},{av:'AV45TFDocNome_Sel',fld:'vTFDOCNOME_SEL',pic:'@!'},{av:'AV74TFDocVersao',fld:'vTFDOCVERSAO',pic:'ZZZ9'},{av:'AV75TFDocVersao_To',fld:'vTFDOCVERSAO_TO',pic:'ZZZ9'},{av:'AV48TFDocInsDataHora',fld:'vTFDOCINSDATAHORA',pic:'99/99/9999 99:99:99.999'},{av:'AV49TFDocInsDataHora_To',fld:'vTFDOCINSDATAHORA_TO',pic:'99/99/9999 99:99:99.999'},{av:'AV72TFDocContrato_Sel',fld:'vTFDOCCONTRATO_SEL',pic:'9'},{av:'AV73TFDocAssinado_Sel',fld:'vTFDOCASSINADO_SEL',pic:'9'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV61IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV62IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV76IsAuthorized_NovaVersao',fld:'vISAUTHORIZED_NOVAVERSAO',pic:'',hsh:true},{av:'AV70IsAuthorized_DocNome',fld:'vISAUTHORIZED_DOCNOME',pic:'',hsh:true},{av:'AV65IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true}]");
         setEventMetadata("'ADDDYNAMICFILTERS1'",",oparms:[{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtDocTipoNome_Visible',ctrl:'DOCTIPONOME',prop:'Visible'},{av:'edtDocNome_Visible',ctrl:'DOCNOME',prop:'Visible'},{av:'edtDocVersao_Visible',ctrl:'DOCVERSAO',prop:'Visible'},{av:'edtDocInsDataHora_Visible',ctrl:'DOCINSDATAHORA',prop:'Visible'},{av:'chkDocContrato.Visible',ctrl:'DOCCONTRATO',prop:'Visible'},{av:'chkDocAssinado.Visible',ctrl:'DOCASSINADO',prop:'Visible'},{av:'AV57GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV58GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV59GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV61IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV62IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV76IsAuthorized_NovaVersao',fld:'vISAUTHORIZED_NOVAVERSAO',pic:'',hsh:true},{av:'AV65IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'","{handler:'E195C2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV20DocVersao1',fld:'vDOCVERSAO1',pic:'ZZZ9'},{av:'AV21DocTipoSigla1',fld:'vDOCTIPOSIGLA1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV25DocVersao2',fld:'vDOCVERSAO2',pic:'ZZZ9'},{av:'AV26DocTipoSigla2',fld:'vDOCTIPOSIGLA2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV30DocVersao3',fld:'vDOCVERSAO3',pic:'ZZZ9'},{av:'AV31DocTipoSigla3',fld:'vDOCTIPOSIGLA3',pic:''},{av:'AV66DocOrigem',fld:'vDOCORIGEM',pic:'',hsh:true},{av:'AV67DocOrigemID',fld:'vDOCORIGEMID',pic:'',hsh:true},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV80Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV68DocOrigem_Filtro',fld:'vDOCORIGEM_FILTRO',pic:''},{av:'AV69DocOrigemID_Filtro',fld:'vDOCORIGEMID_FILTRO',pic:''},{av:'AV46TFDocTipoNome',fld:'vTFDOCTIPONOME',pic:'@!'},{av:'AV47TFDocTipoNome_Sel',fld:'vTFDOCTIPONOME_SEL',pic:'@!'},{av:'AV44TFDocNome',fld:'vTFDOCNOME',pic:'@!'},{av:'AV45TFDocNome_Sel',fld:'vTFDOCNOME_SEL',pic:'@!'},{av:'AV74TFDocVersao',fld:'vTFDOCVERSAO',pic:'ZZZ9'},{av:'AV75TFDocVersao_To',fld:'vTFDOCVERSAO_TO',pic:'ZZZ9'},{av:'AV48TFDocInsDataHora',fld:'vTFDOCINSDATAHORA',pic:'99/99/9999 99:99:99.999'},{av:'AV49TFDocInsDataHora_To',fld:'vTFDOCINSDATAHORA_TO',pic:'99/99/9999 99:99:99.999'},{av:'AV72TFDocContrato_Sel',fld:'vTFDOCCONTRATO_SEL',pic:'9'},{av:'AV73TFDocAssinado_Sel',fld:'vTFDOCASSINADO_SEL',pic:'9'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV61IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV62IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV76IsAuthorized_NovaVersao',fld:'vISAUTHORIZED_NOVAVERSAO',pic:'',hsh:true},{av:'AV70IsAuthorized_DocNome',fld:'vISAUTHORIZED_DOCNOME',pic:'',hsh:true},{av:'AV65IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'",",oparms:[{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV25DocVersao2',fld:'vDOCVERSAO2',pic:'ZZZ9'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV30DocVersao3',fld:'vDOCVERSAO3',pic:'ZZZ9'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV20DocVersao1',fld:'vDOCVERSAO1',pic:'ZZZ9'},{av:'AV21DocTipoSigla1',fld:'vDOCTIPOSIGLA1',pic:''},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV26DocTipoSigla2',fld:'vDOCTIPOSIGLA2',pic:''},{av:'AV31DocTipoSigla3',fld:'vDOCTIPOSIGLA3',pic:''},{av:'edtavDocversao2_Visible',ctrl:'vDOCVERSAO2',prop:'Visible'},{av:'edtavDoctiposigla2_Visible',ctrl:'vDOCTIPOSIGLA2',prop:'Visible'},{av:'edtavDocversao3_Visible',ctrl:'vDOCVERSAO3',prop:'Visible'},{av:'edtavDoctiposigla3_Visible',ctrl:'vDOCTIPOSIGLA3',prop:'Visible'},{av:'edtavDocversao1_Visible',ctrl:'vDOCVERSAO1',prop:'Visible'},{av:'edtavDoctiposigla1_Visible',ctrl:'vDOCTIPOSIGLA1',prop:'Visible'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtDocTipoNome_Visible',ctrl:'DOCTIPONOME',prop:'Visible'},{av:'edtDocNome_Visible',ctrl:'DOCNOME',prop:'Visible'},{av:'edtDocVersao_Visible',ctrl:'DOCVERSAO',prop:'Visible'},{av:'edtDocInsDataHora_Visible',ctrl:'DOCINSDATAHORA',prop:'Visible'},{av:'chkDocContrato.Visible',ctrl:'DOCCONTRATO',prop:'Visible'},{av:'chkDocAssinado.Visible',ctrl:'DOCASSINADO',prop:'Visible'},{av:'AV57GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV58GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV59GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV61IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV62IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV76IsAuthorized_NovaVersao',fld:'vISAUTHORIZED_NOVAVERSAO',pic:'',hsh:true},{av:'AV65IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK","{handler:'E245C2',iparms:[{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK",",oparms:[{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'edtavDocversao1_Visible',ctrl:'vDOCVERSAO1',prop:'Visible'},{av:'edtavDoctiposigla1_Visible',ctrl:'vDOCTIPOSIGLA1',prop:'Visible'}]}");
         setEventMetadata("'ADDDYNAMICFILTERS2'","{handler:'E255C2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV20DocVersao1',fld:'vDOCVERSAO1',pic:'ZZZ9'},{av:'AV21DocTipoSigla1',fld:'vDOCTIPOSIGLA1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV25DocVersao2',fld:'vDOCVERSAO2',pic:'ZZZ9'},{av:'AV26DocTipoSigla2',fld:'vDOCTIPOSIGLA2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV30DocVersao3',fld:'vDOCVERSAO3',pic:'ZZZ9'},{av:'AV31DocTipoSigla3',fld:'vDOCTIPOSIGLA3',pic:''},{av:'AV66DocOrigem',fld:'vDOCORIGEM',pic:'',hsh:true},{av:'AV67DocOrigemID',fld:'vDOCORIGEMID',pic:'',hsh:true},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV80Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV68DocOrigem_Filtro',fld:'vDOCORIGEM_FILTRO',pic:''},{av:'AV69DocOrigemID_Filtro',fld:'vDOCORIGEMID_FILTRO',pic:''},{av:'AV46TFDocTipoNome',fld:'vTFDOCTIPONOME',pic:'@!'},{av:'AV47TFDocTipoNome_Sel',fld:'vTFDOCTIPONOME_SEL',pic:'@!'},{av:'AV44TFDocNome',fld:'vTFDOCNOME',pic:'@!'},{av:'AV45TFDocNome_Sel',fld:'vTFDOCNOME_SEL',pic:'@!'},{av:'AV74TFDocVersao',fld:'vTFDOCVERSAO',pic:'ZZZ9'},{av:'AV75TFDocVersao_To',fld:'vTFDOCVERSAO_TO',pic:'ZZZ9'},{av:'AV48TFDocInsDataHora',fld:'vTFDOCINSDATAHORA',pic:'99/99/9999 99:99:99.999'},{av:'AV49TFDocInsDataHora_To',fld:'vTFDOCINSDATAHORA_TO',pic:'99/99/9999 99:99:99.999'},{av:'AV72TFDocContrato_Sel',fld:'vTFDOCCONTRATO_SEL',pic:'9'},{av:'AV73TFDocAssinado_Sel',fld:'vTFDOCASSINADO_SEL',pic:'9'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV61IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV62IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV76IsAuthorized_NovaVersao',fld:'vISAUTHORIZED_NOVAVERSAO',pic:'',hsh:true},{av:'AV70IsAuthorized_DocNome',fld:'vISAUTHORIZED_DOCNOME',pic:'',hsh:true},{av:'AV65IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true}]");
         setEventMetadata("'ADDDYNAMICFILTERS2'",",oparms:[{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtDocTipoNome_Visible',ctrl:'DOCTIPONOME',prop:'Visible'},{av:'edtDocNome_Visible',ctrl:'DOCNOME',prop:'Visible'},{av:'edtDocVersao_Visible',ctrl:'DOCVERSAO',prop:'Visible'},{av:'edtDocInsDataHora_Visible',ctrl:'DOCINSDATAHORA',prop:'Visible'},{av:'chkDocContrato.Visible',ctrl:'DOCCONTRATO',prop:'Visible'},{av:'chkDocAssinado.Visible',ctrl:'DOCASSINADO',prop:'Visible'},{av:'AV57GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV58GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV59GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV61IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV62IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV76IsAuthorized_NovaVersao',fld:'vISAUTHORIZED_NOVAVERSAO',pic:'',hsh:true},{av:'AV65IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'","{handler:'E205C2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV20DocVersao1',fld:'vDOCVERSAO1',pic:'ZZZ9'},{av:'AV21DocTipoSigla1',fld:'vDOCTIPOSIGLA1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV25DocVersao2',fld:'vDOCVERSAO2',pic:'ZZZ9'},{av:'AV26DocTipoSigla2',fld:'vDOCTIPOSIGLA2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV30DocVersao3',fld:'vDOCVERSAO3',pic:'ZZZ9'},{av:'AV31DocTipoSigla3',fld:'vDOCTIPOSIGLA3',pic:''},{av:'AV66DocOrigem',fld:'vDOCORIGEM',pic:'',hsh:true},{av:'AV67DocOrigemID',fld:'vDOCORIGEMID',pic:'',hsh:true},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV80Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV68DocOrigem_Filtro',fld:'vDOCORIGEM_FILTRO',pic:''},{av:'AV69DocOrigemID_Filtro',fld:'vDOCORIGEMID_FILTRO',pic:''},{av:'AV46TFDocTipoNome',fld:'vTFDOCTIPONOME',pic:'@!'},{av:'AV47TFDocTipoNome_Sel',fld:'vTFDOCTIPONOME_SEL',pic:'@!'},{av:'AV44TFDocNome',fld:'vTFDOCNOME',pic:'@!'},{av:'AV45TFDocNome_Sel',fld:'vTFDOCNOME_SEL',pic:'@!'},{av:'AV74TFDocVersao',fld:'vTFDOCVERSAO',pic:'ZZZ9'},{av:'AV75TFDocVersao_To',fld:'vTFDOCVERSAO_TO',pic:'ZZZ9'},{av:'AV48TFDocInsDataHora',fld:'vTFDOCINSDATAHORA',pic:'99/99/9999 99:99:99.999'},{av:'AV49TFDocInsDataHora_To',fld:'vTFDOCINSDATAHORA_TO',pic:'99/99/9999 99:99:99.999'},{av:'AV72TFDocContrato_Sel',fld:'vTFDOCCONTRATO_SEL',pic:'9'},{av:'AV73TFDocAssinado_Sel',fld:'vTFDOCASSINADO_SEL',pic:'9'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV61IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV62IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV76IsAuthorized_NovaVersao',fld:'vISAUTHORIZED_NOVAVERSAO',pic:'',hsh:true},{av:'AV70IsAuthorized_DocNome',fld:'vISAUTHORIZED_DOCNOME',pic:'',hsh:true},{av:'AV65IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'",",oparms:[{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV25DocVersao2',fld:'vDOCVERSAO2',pic:'ZZZ9'},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV30DocVersao3',fld:'vDOCVERSAO3',pic:'ZZZ9'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV20DocVersao1',fld:'vDOCVERSAO1',pic:'ZZZ9'},{av:'AV21DocTipoSigla1',fld:'vDOCTIPOSIGLA1',pic:''},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV26DocTipoSigla2',fld:'vDOCTIPOSIGLA2',pic:''},{av:'AV31DocTipoSigla3',fld:'vDOCTIPOSIGLA3',pic:''},{av:'edtavDocversao2_Visible',ctrl:'vDOCVERSAO2',prop:'Visible'},{av:'edtavDoctiposigla2_Visible',ctrl:'vDOCTIPOSIGLA2',prop:'Visible'},{av:'edtavDocversao3_Visible',ctrl:'vDOCVERSAO3',prop:'Visible'},{av:'edtavDoctiposigla3_Visible',ctrl:'vDOCTIPOSIGLA3',prop:'Visible'},{av:'edtavDocversao1_Visible',ctrl:'vDOCVERSAO1',prop:'Visible'},{av:'edtavDoctiposigla1_Visible',ctrl:'vDOCTIPOSIGLA1',prop:'Visible'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtDocTipoNome_Visible',ctrl:'DOCTIPONOME',prop:'Visible'},{av:'edtDocNome_Visible',ctrl:'DOCNOME',prop:'Visible'},{av:'edtDocVersao_Visible',ctrl:'DOCVERSAO',prop:'Visible'},{av:'edtDocInsDataHora_Visible',ctrl:'DOCINSDATAHORA',prop:'Visible'},{av:'chkDocContrato.Visible',ctrl:'DOCCONTRATO',prop:'Visible'},{av:'chkDocAssinado.Visible',ctrl:'DOCASSINADO',prop:'Visible'},{av:'AV57GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV58GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV59GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV61IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV62IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV76IsAuthorized_NovaVersao',fld:'vISAUTHORIZED_NOVAVERSAO',pic:'',hsh:true},{av:'AV65IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK","{handler:'E265C2',iparms:[{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK",",oparms:[{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'edtavDocversao2_Visible',ctrl:'vDOCVERSAO2',prop:'Visible'},{av:'edtavDoctiposigla2_Visible',ctrl:'vDOCTIPOSIGLA2',prop:'Visible'}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'","{handler:'E215C2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV20DocVersao1',fld:'vDOCVERSAO1',pic:'ZZZ9'},{av:'AV21DocTipoSigla1',fld:'vDOCTIPOSIGLA1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV25DocVersao2',fld:'vDOCVERSAO2',pic:'ZZZ9'},{av:'AV26DocTipoSigla2',fld:'vDOCTIPOSIGLA2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV30DocVersao3',fld:'vDOCVERSAO3',pic:'ZZZ9'},{av:'AV31DocTipoSigla3',fld:'vDOCTIPOSIGLA3',pic:''},{av:'AV66DocOrigem',fld:'vDOCORIGEM',pic:'',hsh:true},{av:'AV67DocOrigemID',fld:'vDOCORIGEMID',pic:'',hsh:true},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV80Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV68DocOrigem_Filtro',fld:'vDOCORIGEM_FILTRO',pic:''},{av:'AV69DocOrigemID_Filtro',fld:'vDOCORIGEMID_FILTRO',pic:''},{av:'AV46TFDocTipoNome',fld:'vTFDOCTIPONOME',pic:'@!'},{av:'AV47TFDocTipoNome_Sel',fld:'vTFDOCTIPONOME_SEL',pic:'@!'},{av:'AV44TFDocNome',fld:'vTFDOCNOME',pic:'@!'},{av:'AV45TFDocNome_Sel',fld:'vTFDOCNOME_SEL',pic:'@!'},{av:'AV74TFDocVersao',fld:'vTFDOCVERSAO',pic:'ZZZ9'},{av:'AV75TFDocVersao_To',fld:'vTFDOCVERSAO_TO',pic:'ZZZ9'},{av:'AV48TFDocInsDataHora',fld:'vTFDOCINSDATAHORA',pic:'99/99/9999 99:99:99.999'},{av:'AV49TFDocInsDataHora_To',fld:'vTFDOCINSDATAHORA_TO',pic:'99/99/9999 99:99:99.999'},{av:'AV72TFDocContrato_Sel',fld:'vTFDOCCONTRATO_SEL',pic:'9'},{av:'AV73TFDocAssinado_Sel',fld:'vTFDOCASSINADO_SEL',pic:'9'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV61IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV62IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV76IsAuthorized_NovaVersao',fld:'vISAUTHORIZED_NOVAVERSAO',pic:'',hsh:true},{av:'AV70IsAuthorized_DocNome',fld:'vISAUTHORIZED_DOCNOME',pic:'',hsh:true},{av:'AV65IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'",",oparms:[{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV25DocVersao2',fld:'vDOCVERSAO2',pic:'ZZZ9'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV30DocVersao3',fld:'vDOCVERSAO3',pic:'ZZZ9'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV20DocVersao1',fld:'vDOCVERSAO1',pic:'ZZZ9'},{av:'AV21DocTipoSigla1',fld:'vDOCTIPOSIGLA1',pic:''},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV26DocTipoSigla2',fld:'vDOCTIPOSIGLA2',pic:''},{av:'AV31DocTipoSigla3',fld:'vDOCTIPOSIGLA3',pic:''},{av:'edtavDocversao2_Visible',ctrl:'vDOCVERSAO2',prop:'Visible'},{av:'edtavDoctiposigla2_Visible',ctrl:'vDOCTIPOSIGLA2',prop:'Visible'},{av:'edtavDocversao3_Visible',ctrl:'vDOCVERSAO3',prop:'Visible'},{av:'edtavDoctiposigla3_Visible',ctrl:'vDOCTIPOSIGLA3',prop:'Visible'},{av:'edtavDocversao1_Visible',ctrl:'vDOCVERSAO1',prop:'Visible'},{av:'edtavDoctiposigla1_Visible',ctrl:'vDOCTIPOSIGLA1',prop:'Visible'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtDocTipoNome_Visible',ctrl:'DOCTIPONOME',prop:'Visible'},{av:'edtDocNome_Visible',ctrl:'DOCNOME',prop:'Visible'},{av:'edtDocVersao_Visible',ctrl:'DOCVERSAO',prop:'Visible'},{av:'edtDocInsDataHora_Visible',ctrl:'DOCINSDATAHORA',prop:'Visible'},{av:'chkDocContrato.Visible',ctrl:'DOCCONTRATO',prop:'Visible'},{av:'chkDocAssinado.Visible',ctrl:'DOCASSINADO',prop:'Visible'},{av:'AV57GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV58GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV59GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV61IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV62IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV76IsAuthorized_NovaVersao',fld:'vISAUTHORIZED_NOVAVERSAO',pic:'',hsh:true},{av:'AV65IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK","{handler:'E275C2',iparms:[{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK",",oparms:[{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'edtavDocversao3_Visible',ctrl:'vDOCVERSAO3',prop:'Visible'},{av:'edtavDoctiposigla3_Visible',ctrl:'vDOCTIPOSIGLA3',prop:'Visible'}]}");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","{handler:'E115C2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV20DocVersao1',fld:'vDOCVERSAO1',pic:'ZZZ9'},{av:'AV21DocTipoSigla1',fld:'vDOCTIPOSIGLA1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV25DocVersao2',fld:'vDOCVERSAO2',pic:'ZZZ9'},{av:'AV26DocTipoSigla2',fld:'vDOCTIPOSIGLA2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV30DocVersao3',fld:'vDOCVERSAO3',pic:'ZZZ9'},{av:'AV31DocTipoSigla3',fld:'vDOCTIPOSIGLA3',pic:''},{av:'AV66DocOrigem',fld:'vDOCORIGEM',pic:'',hsh:true},{av:'AV67DocOrigemID',fld:'vDOCORIGEMID',pic:'',hsh:true},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV80Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV68DocOrigem_Filtro',fld:'vDOCORIGEM_FILTRO',pic:''},{av:'AV69DocOrigemID_Filtro',fld:'vDOCORIGEMID_FILTRO',pic:''},{av:'AV46TFDocTipoNome',fld:'vTFDOCTIPONOME',pic:'@!'},{av:'AV47TFDocTipoNome_Sel',fld:'vTFDOCTIPONOME_SEL',pic:'@!'},{av:'AV44TFDocNome',fld:'vTFDOCNOME',pic:'@!'},{av:'AV45TFDocNome_Sel',fld:'vTFDOCNOME_SEL',pic:'@!'},{av:'AV74TFDocVersao',fld:'vTFDOCVERSAO',pic:'ZZZ9'},{av:'AV75TFDocVersao_To',fld:'vTFDOCVERSAO_TO',pic:'ZZZ9'},{av:'AV48TFDocInsDataHora',fld:'vTFDOCINSDATAHORA',pic:'99/99/9999 99:99:99.999'},{av:'AV49TFDocInsDataHora_To',fld:'vTFDOCINSDATAHORA_TO',pic:'99/99/9999 99:99:99.999'},{av:'AV72TFDocContrato_Sel',fld:'vTFDOCCONTRATO_SEL',pic:'9'},{av:'AV73TFDocAssinado_Sel',fld:'vTFDOCASSINADO_SEL',pic:'9'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV61IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV62IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV76IsAuthorized_NovaVersao',fld:'vISAUTHORIZED_NOVAVERSAO',pic:'',hsh:true},{av:'AV70IsAuthorized_DocNome',fld:'vISAUTHORIZED_DOCNOME',pic:'',hsh:true},{av:'AV65IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'Ddo_managefilters_Activeeventkey',ctrl:'DDO_MANAGEFILTERS',prop:'ActiveEventKey'},{av:'AV50DDO_DocInsDataHoraAuxDate',fld:'vDDO_DOCINSDATAHORAAUXDATE',pic:''},{av:'AV51DDO_DocInsDataHoraAuxDateTo',fld:'vDDO_DOCINSDATAHORAAUXDATETO',pic:''}]");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",",oparms:[{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV68DocOrigem_Filtro',fld:'vDOCORIGEM_FILTRO',pic:''},{av:'AV69DocOrigemID_Filtro',fld:'vDOCORIGEMID_FILTRO',pic:''},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV46TFDocTipoNome',fld:'vTFDOCTIPONOME',pic:'@!'},{av:'AV47TFDocTipoNome_Sel',fld:'vTFDOCTIPONOME_SEL',pic:'@!'},{av:'AV44TFDocNome',fld:'vTFDOCNOME',pic:'@!'},{av:'AV45TFDocNome_Sel',fld:'vTFDOCNOME_SEL',pic:'@!'},{av:'AV74TFDocVersao',fld:'vTFDOCVERSAO',pic:'ZZZ9'},{av:'AV75TFDocVersao_To',fld:'vTFDOCVERSAO_TO',pic:'ZZZ9'},{av:'AV48TFDocInsDataHora',fld:'vTFDOCINSDATAHORA',pic:'99/99/9999 99:99:99.999'},{av:'AV49TFDocInsDataHora_To',fld:'vTFDOCINSDATAHORA_TO',pic:'99/99/9999 99:99:99.999'},{av:'AV72TFDocContrato_Sel',fld:'vTFDOCCONTRATO_SEL',pic:'9'},{av:'AV73TFDocAssinado_Sel',fld:'vTFDOCASSINADO_SEL',pic:'9'},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV20DocVersao1',fld:'vDOCVERSAO1',pic:'ZZZ9'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'AV50DDO_DocInsDataHoraAuxDate',fld:'vDDO_DOCINSDATAHORAAUXDATE',pic:''},{av:'AV51DDO_DocInsDataHoraAuxDateTo',fld:'vDDO_DOCINSDATAHORAAUXDATETO',pic:''},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'AV21DocTipoSigla1',fld:'vDOCTIPOSIGLA1',pic:''},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV25DocVersao2',fld:'vDOCVERSAO2',pic:'ZZZ9'},{av:'AV26DocTipoSigla2',fld:'vDOCTIPOSIGLA2',pic:''},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV30DocVersao3',fld:'vDOCVERSAO3',pic:'ZZZ9'},{av:'AV31DocTipoSigla3',fld:'vDOCTIPOSIGLA3',pic:''},{av:'edtavDocversao1_Visible',ctrl:'vDOCVERSAO1',prop:'Visible'},{av:'edtavDoctiposigla1_Visible',ctrl:'vDOCTIPOSIGLA1',prop:'Visible'},{av:'edtavDocversao2_Visible',ctrl:'vDOCVERSAO2',prop:'Visible'},{av:'edtavDoctiposigla2_Visible',ctrl:'vDOCTIPOSIGLA2',prop:'Visible'},{av:'edtavDocversao3_Visible',ctrl:'vDOCVERSAO3',prop:'Visible'},{av:'edtavDoctiposigla3_Visible',ctrl:'vDOCTIPOSIGLA3',prop:'Visible'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtDocTipoNome_Visible',ctrl:'DOCTIPONOME',prop:'Visible'},{av:'edtDocNome_Visible',ctrl:'DOCNOME',prop:'Visible'},{av:'edtDocVersao_Visible',ctrl:'DOCVERSAO',prop:'Visible'},{av:'edtDocInsDataHora_Visible',ctrl:'DOCINSDATAHORA',prop:'Visible'},{av:'chkDocContrato.Visible',ctrl:'DOCCONTRATO',prop:'Visible'},{av:'chkDocAssinado.Visible',ctrl:'DOCASSINADO',prop:'Visible'},{av:'AV57GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV58GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV59GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV61IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV62IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV76IsAuthorized_NovaVersao',fld:'vISAUTHORIZED_NOVAVERSAO',pic:'',hsh:true},{av:'AV65IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VGRIDACTIONS.CLICK","{handler:'E315C2',iparms:[{av:'cmbavGridactions'},{av:'AV60GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9'},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV20DocVersao1',fld:'vDOCVERSAO1',pic:'ZZZ9'},{av:'AV21DocTipoSigla1',fld:'vDOCTIPOSIGLA1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV25DocVersao2',fld:'vDOCVERSAO2',pic:'ZZZ9'},{av:'AV26DocTipoSigla2',fld:'vDOCTIPOSIGLA2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV30DocVersao3',fld:'vDOCVERSAO3',pic:'ZZZ9'},{av:'AV31DocTipoSigla3',fld:'vDOCTIPOSIGLA3',pic:''},{av:'AV66DocOrigem',fld:'vDOCORIGEM',pic:'',hsh:true},{av:'AV67DocOrigemID',fld:'vDOCORIGEMID',pic:'',hsh:true},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV80Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV68DocOrigem_Filtro',fld:'vDOCORIGEM_FILTRO',pic:''},{av:'AV69DocOrigemID_Filtro',fld:'vDOCORIGEMID_FILTRO',pic:''},{av:'AV46TFDocTipoNome',fld:'vTFDOCTIPONOME',pic:'@!'},{av:'AV47TFDocTipoNome_Sel',fld:'vTFDOCTIPONOME_SEL',pic:'@!'},{av:'AV44TFDocNome',fld:'vTFDOCNOME',pic:'@!'},{av:'AV45TFDocNome_Sel',fld:'vTFDOCNOME_SEL',pic:'@!'},{av:'AV74TFDocVersao',fld:'vTFDOCVERSAO',pic:'ZZZ9'},{av:'AV75TFDocVersao_To',fld:'vTFDOCVERSAO_TO',pic:'ZZZ9'},{av:'AV48TFDocInsDataHora',fld:'vTFDOCINSDATAHORA',pic:'99/99/9999 99:99:99.999'},{av:'AV49TFDocInsDataHora_To',fld:'vTFDOCINSDATAHORA_TO',pic:'99/99/9999 99:99:99.999'},{av:'AV72TFDocContrato_Sel',fld:'vTFDOCCONTRATO_SEL',pic:'9'},{av:'AV73TFDocAssinado_Sel',fld:'vTFDOCASSINADO_SEL',pic:'9'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV61IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV62IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV76IsAuthorized_NovaVersao',fld:'vISAUTHORIZED_NOVAVERSAO',pic:'',hsh:true},{av:'AV70IsAuthorized_DocNome',fld:'vISAUTHORIZED_DOCNOME',pic:'',hsh:true},{av:'AV65IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'A289DocID',fld:'DOCID',pic:'',hsh:true}]");
         setEventMetadata("VGRIDACTIONS.CLICK",",oparms:[{av:'cmbavGridactions'},{av:'AV60GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtDocTipoNome_Visible',ctrl:'DOCTIPONOME',prop:'Visible'},{av:'edtDocNome_Visible',ctrl:'DOCNOME',prop:'Visible'},{av:'edtDocVersao_Visible',ctrl:'DOCVERSAO',prop:'Visible'},{av:'edtDocInsDataHora_Visible',ctrl:'DOCINSDATAHORA',prop:'Visible'},{av:'chkDocContrato.Visible',ctrl:'DOCCONTRATO',prop:'Visible'},{av:'chkDocAssinado.Visible',ctrl:'DOCASSINADO',prop:'Visible'},{av:'AV57GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV58GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV59GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV61IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV62IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV76IsAuthorized_NovaVersao',fld:'vISAUTHORIZED_NOVAVERSAO',pic:'',hsh:true},{av:'AV65IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("DVELOP_CONFIRMPANEL_NOVAVERSAO.CLOSE","{handler:'E185C2',iparms:[{av:'Dvelop_confirmpanel_novaversao_Result',ctrl:'DVELOP_CONFIRMPANEL_NOVAVERSAO',prop:'Result'},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV20DocVersao1',fld:'vDOCVERSAO1',pic:'ZZZ9'},{av:'AV21DocTipoSigla1',fld:'vDOCTIPOSIGLA1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV25DocVersao2',fld:'vDOCVERSAO2',pic:'ZZZ9'},{av:'AV26DocTipoSigla2',fld:'vDOCTIPOSIGLA2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV30DocVersao3',fld:'vDOCVERSAO3',pic:'ZZZ9'},{av:'AV31DocTipoSigla3',fld:'vDOCTIPOSIGLA3',pic:''},{av:'AV66DocOrigem',fld:'vDOCORIGEM',pic:'',hsh:true},{av:'AV67DocOrigemID',fld:'vDOCORIGEMID',pic:'',hsh:true},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV80Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV68DocOrigem_Filtro',fld:'vDOCORIGEM_FILTRO',pic:''},{av:'AV69DocOrigemID_Filtro',fld:'vDOCORIGEMID_FILTRO',pic:''},{av:'AV46TFDocTipoNome',fld:'vTFDOCTIPONOME',pic:'@!'},{av:'AV47TFDocTipoNome_Sel',fld:'vTFDOCTIPONOME_SEL',pic:'@!'},{av:'AV44TFDocNome',fld:'vTFDOCNOME',pic:'@!'},{av:'AV45TFDocNome_Sel',fld:'vTFDOCNOME_SEL',pic:'@!'},{av:'AV74TFDocVersao',fld:'vTFDOCVERSAO',pic:'ZZZ9'},{av:'AV75TFDocVersao_To',fld:'vTFDOCVERSAO_TO',pic:'ZZZ9'},{av:'AV48TFDocInsDataHora',fld:'vTFDOCINSDATAHORA',pic:'99/99/9999 99:99:99.999'},{av:'AV49TFDocInsDataHora_To',fld:'vTFDOCINSDATAHORA_TO',pic:'99/99/9999 99:99:99.999'},{av:'AV72TFDocContrato_Sel',fld:'vTFDOCCONTRATO_SEL',pic:'9'},{av:'AV73TFDocAssinado_Sel',fld:'vTFDOCASSINADO_SEL',pic:'9'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV61IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV62IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV76IsAuthorized_NovaVersao',fld:'vISAUTHORIZED_NOVAVERSAO',pic:'',hsh:true},{av:'AV70IsAuthorized_DocNome',fld:'vISAUTHORIZED_DOCNOME',pic:'',hsh:true},{av:'AV65IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'A289DocID',fld:'DOCID',pic:'',hsh:true},{av:'AV77sdtDocumento',fld:'vSDTDOCUMENTO',pic:''},{av:'A146DocTipoID',fld:'DOCTIPOID',pic:'ZZZ,ZZZ,ZZ9',hsh:true}]");
         setEventMetadata("DVELOP_CONFIRMPANEL_NOVAVERSAO.CLOSE",",oparms:[{av:'AV77sdtDocumento',fld:'vSDTDOCUMENTO',pic:''},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtDocTipoNome_Visible',ctrl:'DOCTIPONOME',prop:'Visible'},{av:'edtDocNome_Visible',ctrl:'DOCNOME',prop:'Visible'},{av:'edtDocVersao_Visible',ctrl:'DOCVERSAO',prop:'Visible'},{av:'edtDocInsDataHora_Visible',ctrl:'DOCINSDATAHORA',prop:'Visible'},{av:'chkDocContrato.Visible',ctrl:'DOCCONTRATO',prop:'Visible'},{av:'chkDocAssinado.Visible',ctrl:'DOCASSINADO',prop:'Visible'},{av:'AV57GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV58GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV59GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV61IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV62IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV76IsAuthorized_NovaVersao',fld:'vISAUTHORIZED_NOVAVERSAO',pic:'',hsh:true},{av:'AV65IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("'DOINSERT'","{handler:'E225C2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV20DocVersao1',fld:'vDOCVERSAO1',pic:'ZZZ9'},{av:'AV21DocTipoSigla1',fld:'vDOCTIPOSIGLA1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV25DocVersao2',fld:'vDOCVERSAO2',pic:'ZZZ9'},{av:'AV26DocTipoSigla2',fld:'vDOCTIPOSIGLA2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV30DocVersao3',fld:'vDOCVERSAO3',pic:'ZZZ9'},{av:'AV31DocTipoSigla3',fld:'vDOCTIPOSIGLA3',pic:''},{av:'AV66DocOrigem',fld:'vDOCORIGEM',pic:'',hsh:true},{av:'AV67DocOrigemID',fld:'vDOCORIGEMID',pic:'',hsh:true},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV80Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV68DocOrigem_Filtro',fld:'vDOCORIGEM_FILTRO',pic:''},{av:'AV69DocOrigemID_Filtro',fld:'vDOCORIGEMID_FILTRO',pic:''},{av:'AV46TFDocTipoNome',fld:'vTFDOCTIPONOME',pic:'@!'},{av:'AV47TFDocTipoNome_Sel',fld:'vTFDOCTIPONOME_SEL',pic:'@!'},{av:'AV44TFDocNome',fld:'vTFDOCNOME',pic:'@!'},{av:'AV45TFDocNome_Sel',fld:'vTFDOCNOME_SEL',pic:'@!'},{av:'AV74TFDocVersao',fld:'vTFDOCVERSAO',pic:'ZZZ9'},{av:'AV75TFDocVersao_To',fld:'vTFDOCVERSAO_TO',pic:'ZZZ9'},{av:'AV48TFDocInsDataHora',fld:'vTFDOCINSDATAHORA',pic:'99/99/9999 99:99:99.999'},{av:'AV49TFDocInsDataHora_To',fld:'vTFDOCINSDATAHORA_TO',pic:'99/99/9999 99:99:99.999'},{av:'AV72TFDocContrato_Sel',fld:'vTFDOCCONTRATO_SEL',pic:'9'},{av:'AV73TFDocAssinado_Sel',fld:'vTFDOCASSINADO_SEL',pic:'9'},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV61IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV62IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV76IsAuthorized_NovaVersao',fld:'vISAUTHORIZED_NOVAVERSAO',pic:'',hsh:true},{av:'AV70IsAuthorized_DocNome',fld:'vISAUTHORIZED_DOCNOME',pic:'',hsh:true},{av:'AV65IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'A289DocID',fld:'DOCID',pic:'',hsh:true}]");
         setEventMetadata("'DOINSERT'",",oparms:[{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtDocTipoNome_Visible',ctrl:'DOCTIPONOME',prop:'Visible'},{av:'edtDocNome_Visible',ctrl:'DOCNOME',prop:'Visible'},{av:'edtDocVersao_Visible',ctrl:'DOCVERSAO',prop:'Visible'},{av:'edtDocInsDataHora_Visible',ctrl:'DOCINSDATAHORA',prop:'Visible'},{av:'chkDocContrato.Visible',ctrl:'DOCCONTRATO',prop:'Visible'},{av:'chkDocAssinado.Visible',ctrl:'DOCASSINADO',prop:'Visible'},{av:'AV57GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV58GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV59GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV61IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV62IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV76IsAuthorized_NovaVersao',fld:'vISAUTHORIZED_NOVAVERSAO',pic:'',hsh:true},{av:'AV65IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED","{handler:'E145C2',iparms:[{av:'Ddo_agexport_Activeeventkey',ctrl:'DDO_AGEXPORT',prop:'ActiveEventKey'}]");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED",",oparms:[{av:'Innewwindow1_Target',ctrl:'INNEWWINDOW1',prop:'Target'},{av:'Innewwindow1_Height',ctrl:'INNEWWINDOW1',prop:'Height'},{av:'Innewwindow1_Width',ctrl:'INNEWWINDOW1',prop:'Width'}]}");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT","{handler:'E155C2',iparms:[]");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT",",oparms:[{ctrl:'WWPAUX_WC'}]}");
         setEventMetadata("VDETAILWEBCOMPONENT.CLICK","{handler:'E325C2',iparms:[{av:'A289DocID',fld:'DOCID',pic:'',hsh:true},{av:'A326DocVersaoIDPai',fld:'DOCVERSAOIDPAI',pic:'',hsh:true}]");
         setEventMetadata("VDETAILWEBCOMPONENT.CLICK",",oparms:[{ctrl:'GRID_DWC'}]}");
         setEventMetadata("VALID_DOCTIPOID","{handler:'Valid_Doctipoid',iparms:[]");
         setEventMetadata("VALID_DOCTIPOID",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Docversaoidpai',iparms:[]");
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
         wcpOAV66DocOrigem = "";
         wcpOAV67DocOrigemID = "";
         Gridpaginationbar_Selectedpage = "";
         Ddo_grid_Activeeventkey = "";
         Ddo_grid_Selectedvalue_get = "";
         Ddo_grid_Filteredtextto_get = "";
         Ddo_grid_Filteredtext_get = "";
         Ddo_grid_Selectedcolumn = "";
         Ddo_gridcolumnsselector_Columnsselectorvalues = "";
         Ddo_managefilters_Activeeventkey = "";
         Dvelop_confirmpanel_novaversao_Result = "";
         Ddo_agexport_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV17FilterFullText = "";
         AV18DynamicFiltersSelector1 = "";
         AV21DocTipoSigla1 = "";
         AV23DynamicFiltersSelector2 = "";
         AV26DocTipoSigla2 = "";
         AV28DynamicFiltersSelector3 = "";
         AV31DocTipoSigla3 = "";
         AV38ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV80Pgmname = "";
         AV68DocOrigem_Filtro = "";
         AV69DocOrigemID_Filtro = "";
         AV46TFDocTipoNome = "";
         AV47TFDocTipoNome_Sel = "";
         AV44TFDocNome = "";
         AV45TFDocNome_Sel = "";
         AV48TFDocInsDataHora = (DateTime)(DateTime.MinValue);
         AV49TFDocInsDataHora_To = (DateTime)(DateTime.MinValue);
         AV11GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV41ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV59GridAppliedFilters = "";
         AV63AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV53DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV50DDO_DocInsDataHoraAuxDate = DateTime.MinValue;
         AV51DDO_DocInsDataHoraAuxDateTo = DateTime.MinValue;
         AV77sdtDocumento = new GeneXus.Programs.core.SdtsdtDocumento(context);
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
         ucDvpanel_tableoportunidade = new GXUserControl();
         WebComp_Wcnegociopjgeneral_Component = "";
         OldWcnegociopjgeneral = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtncancel_Jsonclick = "";
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
         WebComp_Grid_dwc_Component = "";
         OldGrid_dwc = "";
         ucDdo_agexport = new GXUserControl();
         ucDdc_subscriptions = new GXUserControl();
         lblJsdynamicfilters_Jsonclick = "";
         ucDdo_grid = new GXUserControl();
         ucInnewwindow1 = new GXUserControl();
         ucDdo_gridcolumnsselector = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         WebComp_Wwpaux_wc_Component = "";
         OldWwpaux_wc = "";
         AV52DDO_DocInsDataHoraAuxDateText = "";
         ucTfdocinsdatahora_rangepicker = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV71DetailWebComponent = "";
         A289DocID = Guid.Empty;
         A290DocOrigem = "";
         A291DocOrigemID = "";
         A148DocTipoNome = "";
         A305DocNome = "";
         A294DocInsDataHora = (DateTime)(DateTime.MinValue);
         A326DocVersaoIDPai = Guid.Empty;
         GXDecQS = "";
         scmdbuf = "";
         lV83Core_documentowwds_3_filterfulltext = "";
         lV87Core_documentowwds_7_doctiposigla1 = "";
         lV92Core_documentowwds_12_doctiposigla2 = "";
         lV97Core_documentowwds_17_doctiposigla3 = "";
         lV98Core_documentowwds_18_tfdoctiponome = "";
         lV100Core_documentowwds_20_tfdocnome = "";
         AV83Core_documentowwds_3_filterfulltext = "";
         AV84Core_documentowwds_4_dynamicfiltersselector1 = "";
         AV87Core_documentowwds_7_doctiposigla1 = "";
         AV89Core_documentowwds_9_dynamicfiltersselector2 = "";
         AV92Core_documentowwds_12_doctiposigla2 = "";
         AV94Core_documentowwds_14_dynamicfiltersselector3 = "";
         AV97Core_documentowwds_17_doctiposigla3 = "";
         AV99Core_documentowwds_19_tfdoctiponome_sel = "";
         AV98Core_documentowwds_18_tfdoctiponome = "";
         AV101Core_documentowwds_21_tfdocnome_sel = "";
         AV100Core_documentowwds_20_tfdocnome = "";
         AV104Core_documentowwds_24_tfdocinsdatahora = (DateTime)(DateTime.MinValue);
         AV105Core_documentowwds_25_tfdocinsdatahora_to = (DateTime)(DateTime.MinValue);
         A147DocTipoSigla = "";
         H005C2_A640DocAtivo = new bool[] {false} ;
         H005C2_n640DocAtivo = new bool[] {false} ;
         H005C2_A147DocTipoSigla = new string[] {""} ;
         H005C2_A326DocVersaoIDPai = new Guid[] {Guid.Empty} ;
         H005C2_n326DocVersaoIDPai = new bool[] {false} ;
         H005C2_A146DocTipoID = new int[1] ;
         H005C2_A481DocAssinado = new bool[] {false} ;
         H005C2_A480DocContrato = new bool[] {false} ;
         H005C2_A294DocInsDataHora = new DateTime[] {DateTime.MinValue} ;
         H005C2_A325DocVersao = new short[1] ;
         H005C2_A305DocNome = new string[] {""} ;
         H005C2_A148DocTipoNome = new string[] {""} ;
         H005C2_A291DocOrigemID = new string[] {""} ;
         H005C2_A290DocOrigem = new string[] {""} ;
         H005C2_A289DocID = new Guid[] {Guid.Empty} ;
         AV81Core_documentowwds_1_docorigem_filtro = "";
         AV82Core_documentowwds_2_docorigemid_filtro = "";
         H005C3_AGRID_nRecordCount = new long[1] ;
         AV8HTTPRequest = new GxHttpRequest( context);
         imgAdddynamicfilters1_Jsonclick = "";
         imgRemovedynamicfilters1_Jsonclick = "";
         imgAdddynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters3_Jsonclick = "";
         AV64AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV54GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV55GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV40Session = context.GetSession();
         AV36ColumnsSelectorXML = "";
         GridRow = new GXWebRow();
         AV42ManageFiltersXml = "";
         AV37UserCustomValue = "";
         AV39ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV79webSessionParm = "";
         AV78webSession = context.GetSession();
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV10TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV12GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char5 = "";
         GXt_char3 = "";
         AV13GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV34ExcelFilename = "";
         AV35ErrorMessage = "";
         H005C4_A345NegID = new Guid[] {Guid.Empty} ;
         H005C4_A362NegAssunto = new string[] {""} ;
         H005C4_A356NegCodigo = new long[1] ;
         A345NegID = Guid.Empty;
         A362NegAssunto = "";
         ucDvelop_confirmpanel_novaversao = new GXUserControl();
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
         GXCCtl = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.documentoww__default(),
            new Object[][] {
                new Object[] {
               H005C2_A640DocAtivo, H005C2_n640DocAtivo, H005C2_A147DocTipoSigla, H005C2_A326DocVersaoIDPai, H005C2_n326DocVersaoIDPai, H005C2_A146DocTipoID, H005C2_A481DocAssinado, H005C2_A480DocContrato, H005C2_A294DocInsDataHora, H005C2_A325DocVersao,
               H005C2_A305DocNome, H005C2_A148DocTipoNome, H005C2_A291DocOrigemID, H005C2_A290DocOrigem, H005C2_A289DocID
               }
               , new Object[] {
               H005C3_AGRID_nRecordCount
               }
               , new Object[] {
               H005C4_A345NegID, H005C4_A362NegAssunto, H005C4_A356NegCodigo
               }
            }
         );
         WebComp_Wcnegociopjgeneral = new GeneXus.Http.GXNullWebComponent();
         WebComp_Grid_dwc = new GeneXus.Http.GXNullWebComponent();
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         AV80Pgmname = "core.DocumentoWW";
         /* GeneXus formulas. */
         AV80Pgmname = "core.DocumentoWW";
         edtavDetailwebcomponent_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV19DynamicFiltersOperator1 ;
      private short AV20DocVersao1 ;
      private short AV24DynamicFiltersOperator2 ;
      private short AV25DocVersao2 ;
      private short AV29DynamicFiltersOperator3 ;
      private short AV30DocVersao3 ;
      private short AV43ManageFiltersExecutionStep ;
      private short AV74TFDocVersao ;
      private short AV75TFDocVersao_To ;
      private short AV72TFDocContrato_Sel ;
      private short AV73TFDocAssinado_Sel ;
      private short AV14OrderedBy ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV60GridActions ;
      private short A325DocVersao ;
      private short nCmpId ;
      private short nDonePA ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short AV85Core_documentowwds_5_dynamicfiltersoperator1 ;
      private short AV86Core_documentowwds_6_docversao1 ;
      private short AV90Core_documentowwds_10_dynamicfiltersoperator2 ;
      private short AV91Core_documentowwds_11_docversao2 ;
      private short AV95Core_documentowwds_15_dynamicfiltersoperator3 ;
      private short AV96Core_documentowwds_16_docversao3 ;
      private short AV102Core_documentowwds_22_tfdocversao ;
      private short AV103Core_documentowwds_23_tfdocversao_to ;
      private short AV106Core_documentowwds_26_tfdoccontrato_sel ;
      private short AV107Core_documentowwds_27_tfdocassinado_sel ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_138 ;
      private int nGXsfl_138_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int edtavDocorigem_filtro_Enabled ;
      private int edtavDocorigemid_filtro_Enabled ;
      private int bttBtninsert_Visible ;
      private int bttBtnsubscriptions_Visible ;
      private int edtavDocorigem_Visible ;
      private int edtavDocorigemid_Visible ;
      private int A146DocTipoID ;
      private int subGrid_Islastpage ;
      private int edtavDetailwebcomponent_Enabled ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtDocTipoNome_Visible ;
      private int edtDocNome_Visible ;
      private int edtDocVersao_Visible ;
      private int edtDocInsDataHora_Visible ;
      private int AV56PageToGo ;
      private int imgAdddynamicfilters1_Visible ;
      private int imgRemovedynamicfilters1_Visible ;
      private int imgAdddynamicfilters2_Visible ;
      private int imgRemovedynamicfilters2_Visible ;
      private int edtavDocversao1_Visible ;
      private int edtavDoctiposigla1_Visible ;
      private int edtavDocversao2_Visible ;
      private int edtavDoctiposigla2_Visible ;
      private int edtavDocversao3_Visible ;
      private int edtavDoctiposigla3_Visible ;
      private int AV108GXV1 ;
      private int edtavDocversao3_Enabled ;
      private int edtavDoctiposigla3_Enabled ;
      private int edtavDocversao2_Enabled ;
      private int edtavDoctiposigla2_Enabled ;
      private int edtavDocversao1_Enabled ;
      private int edtavDoctiposigla1_Enabled ;
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
      private long AV57GridCurrentPage ;
      private long AV58GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private long A356NegCodigo ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_gridcolumnsselector_Columnsselectorvalues ;
      private string Ddo_managefilters_Activeeventkey ;
      private string Dvelop_confirmpanel_novaversao_Result ;
      private string Ddo_agexport_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_138_idx="0001" ;
      private string AV80Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string Dvpanel_tableoportunidade_Width ;
      private string Dvpanel_tableoportunidade_Cls ;
      private string Dvpanel_tableoportunidade_Title ;
      private string Dvpanel_tableoportunidade_Iconposition ;
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
      private string Ddo_grid_Datalistfixedvalues ;
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
      private string Dvelop_confirmpanel_novaversao_Title ;
      private string Dvelop_confirmpanel_novaversao_Confirmationtext ;
      private string Dvelop_confirmpanel_novaversao_Yesbuttoncaption ;
      private string Dvelop_confirmpanel_novaversao_Nobuttoncaption ;
      private string Dvelop_confirmpanel_novaversao_Cancelbuttoncaption ;
      private string Dvelop_confirmpanel_novaversao_Yesbuttonposition ;
      private string Dvelop_confirmpanel_novaversao_Confirmtype ;
      private string Grid_empowerer_Gridinternalname ;
      private string Grid_empowerer_Fixedcolumns ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string divDvpanel_tableoportunidade_cell_Internalname ;
      private string divDvpanel_tableoportunidade_cell_Class ;
      private string Dvpanel_tableoportunidade_Internalname ;
      private string divTableoportunidade_Internalname ;
      private string WebComp_Wcnegociopjgeneral_Component ;
      private string OldWcnegociopjgeneral ;
      private string edtavDocorigem_filtro_Internalname ;
      private string TempTags ;
      private string edtavDocorigem_filtro_Jsonclick ;
      private string edtavDocorigemid_filtro_Internalname ;
      private string edtavDocorigemid_filtro_Jsonclick ;
      private string divTableheader_Internalname ;
      private string divTableheadercontent_Internalname ;
      private string divTableactions_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtncancel_Internalname ;
      private string bttBtncancel_Jsonclick ;
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
      private string divCell_grid_dwc_Internalname ;
      private string divCell_grid_dwc_Class ;
      private string WebComp_Grid_dwc_Component ;
      private string OldGrid_dwc ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Ddo_agexport_Internalname ;
      private string Ddc_subscriptions_Internalname ;
      private string lblJsdynamicfilters_Internalname ;
      private string lblJsdynamicfilters_Caption ;
      private string lblJsdynamicfilters_Jsonclick ;
      private string Ddo_grid_Internalname ;
      private string Innewwindow1_Internalname ;
      private string Ddo_gridcolumnsselector_Internalname ;
      private string edtavDocorigem_Internalname ;
      private string edtavDocorigem_Jsonclick ;
      private string edtavDocorigemid_Internalname ;
      private string edtavDocorigemid_Jsonclick ;
      private string Grid_empowerer_Internalname ;
      private string divDiv_wwpauxwc_Internalname ;
      private string WebComp_Wwpaux_wc_Component ;
      private string OldWwpaux_wc ;
      private string divDdo_docinsdatahoraauxdates_Internalname ;
      private string edtavDdo_docinsdatahoraauxdatetext_Internalname ;
      private string edtavDdo_docinsdatahoraauxdatetext_Jsonclick ;
      private string Tfdocinsdatahora_rangepicker_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV71DetailWebComponent ;
      private string edtavDetailwebcomponent_Internalname ;
      private string cmbavGridactions_Internalname ;
      private string edtDocID_Internalname ;
      private string edtDocOrigem_Internalname ;
      private string edtDocOrigemID_Internalname ;
      private string edtDocTipoNome_Internalname ;
      private string edtDocNome_Internalname ;
      private string edtDocVersao_Internalname ;
      private string edtDocInsDataHora_Internalname ;
      private string chkDocContrato_Internalname ;
      private string chkDocAssinado_Internalname ;
      private string edtDocTipoID_Internalname ;
      private string edtDocVersaoIDPai_Internalname ;
      private string GXDecQS ;
      private string cmbavDynamicfiltersoperator1_Internalname ;
      private string cmbavDynamicfiltersoperator2_Internalname ;
      private string cmbavDynamicfiltersoperator3_Internalname ;
      private string scmdbuf ;
      private string edtavFilterfulltext_Internalname ;
      private string edtavDocversao1_Internalname ;
      private string edtavDoctiposigla1_Internalname ;
      private string edtavDocversao2_Internalname ;
      private string edtavDoctiposigla2_Internalname ;
      private string edtavDocversao3_Internalname ;
      private string edtavDoctiposigla3_Internalname ;
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
      private string edtDocNome_Link ;
      private string GXt_char5 ;
      private string GXt_char3 ;
      private string tblTabledvelop_confirmpanel_novaversao_Internalname ;
      private string Dvelop_confirmpanel_novaversao_Internalname ;
      private string tblTablemergeddynamicfilters3_Internalname ;
      private string cmbavDynamicfiltersoperator3_Jsonclick ;
      private string cellFilter_docversao3_cell_Internalname ;
      private string edtavDocversao3_Jsonclick ;
      private string cellFilter_doctiposigla3_cell_Internalname ;
      private string edtavDoctiposigla3_Jsonclick ;
      private string cellDynamicfilters_removefilter3_cell_Internalname ;
      private string imgRemovedynamicfilters3_gximage ;
      private string sImgUrl ;
      private string tblTablemergeddynamicfilters2_Internalname ;
      private string cmbavDynamicfiltersoperator2_Jsonclick ;
      private string cellFilter_docversao2_cell_Internalname ;
      private string edtavDocversao2_Jsonclick ;
      private string cellFilter_doctiposigla2_cell_Internalname ;
      private string edtavDoctiposigla2_Jsonclick ;
      private string cellDynamicfilters_addfilter2_cell_Internalname ;
      private string imgAdddynamicfilters2_gximage ;
      private string cellDynamicfilters_removefilter2_cell_Internalname ;
      private string imgRemovedynamicfilters2_gximage ;
      private string tblTablemergeddynamicfilters1_Internalname ;
      private string cmbavDynamicfiltersoperator1_Jsonclick ;
      private string cellFilter_docversao1_cell_Internalname ;
      private string edtavDocversao1_Jsonclick ;
      private string cellFilter_doctiposigla1_cell_Internalname ;
      private string edtavDoctiposigla1_Jsonclick ;
      private string cellDynamicfilters_addfilter1_cell_Internalname ;
      private string imgAdddynamicfilters1_gximage ;
      private string cellDynamicfilters_removefilter1_cell_Internalname ;
      private string imgRemovedynamicfilters1_gximage ;
      private string tblTablerightheader_Internalname ;
      private string Ddo_managefilters_Caption ;
      private string Ddo_managefilters_Internalname ;
      private string tblTablefilters_Internalname ;
      private string edtavFilterfulltext_Jsonclick ;
      private string sGXsfl_138_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavDetailwebcomponent_Jsonclick ;
      private string GXCCtl ;
      private string cmbavGridactions_Jsonclick ;
      private string edtDocID_Jsonclick ;
      private string edtDocOrigem_Jsonclick ;
      private string edtDocOrigemID_Jsonclick ;
      private string edtDocTipoNome_Jsonclick ;
      private string edtDocNome_Jsonclick ;
      private string edtDocVersao_Jsonclick ;
      private string edtDocInsDataHora_Jsonclick ;
      private string edtDocTipoID_Jsonclick ;
      private string edtDocVersaoIDPai_Jsonclick ;
      private string subGrid_Header ;
      private DateTime AV48TFDocInsDataHora ;
      private DateTime AV49TFDocInsDataHora_To ;
      private DateTime A294DocInsDataHora ;
      private DateTime AV104Core_documentowwds_24_tfdocinsdatahora ;
      private DateTime AV105Core_documentowwds_25_tfdocinsdatahora_to ;
      private DateTime AV50DDO_DocInsDataHoraAuxDate ;
      private DateTime AV51DDO_DocInsDataHoraAuxDateTo ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV22DynamicFiltersEnabled2 ;
      private bool AV27DynamicFiltersEnabled3 ;
      private bool AV15OrderedDsc ;
      private bool AV33DynamicFiltersIgnoreFirst ;
      private bool AV32DynamicFiltersRemoving ;
      private bool AV61IsAuthorized_Update ;
      private bool AV62IsAuthorized_Delete ;
      private bool AV76IsAuthorized_NovaVersao ;
      private bool AV70IsAuthorized_DocNome ;
      private bool AV65IsAuthorized_Insert ;
      private bool Dvpanel_tableoportunidade_Autowidth ;
      private bool Dvpanel_tableoportunidade_Autoheight ;
      private bool Dvpanel_tableoportunidade_Collapsible ;
      private bool Dvpanel_tableoportunidade_Collapsed ;
      private bool Dvpanel_tableoportunidade_Showcollapseicon ;
      private bool Dvpanel_tableoportunidade_Autoscroll ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool Grid_empowerer_Hascolumnsselector ;
      private bool wbLoad ;
      private bool bGXsfl_138_Refreshing=false ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool A480DocContrato ;
      private bool A481DocAssinado ;
      private bool n326DocVersaoIDPai ;
      private bool gxdyncontrolsrefreshing ;
      private bool AV88Core_documentowwds_8_dynamicfiltersenabled2 ;
      private bool AV93Core_documentowwds_13_dynamicfiltersenabled3 ;
      private bool A640DocAtivo ;
      private bool n640DocAtivo ;
      private bool returnInSub ;
      private bool bDynCreated_Wcnegociopjgeneral ;
      private bool gx_refresh_fired ;
      private bool bDynCreated_Wwpaux_wc ;
      private bool bDynCreated_Grid_dwc ;
      private bool GXt_boolean1 ;
      private string AV36ColumnsSelectorXML ;
      private string AV42ManageFiltersXml ;
      private string AV37UserCustomValue ;
      private string AV66DocOrigem ;
      private string AV67DocOrigemID ;
      private string wcpOAV66DocOrigem ;
      private string wcpOAV67DocOrigemID ;
      private string AV17FilterFullText ;
      private string AV18DynamicFiltersSelector1 ;
      private string AV21DocTipoSigla1 ;
      private string AV23DynamicFiltersSelector2 ;
      private string AV26DocTipoSigla2 ;
      private string AV28DynamicFiltersSelector3 ;
      private string AV31DocTipoSigla3 ;
      private string AV68DocOrigem_Filtro ;
      private string AV69DocOrigemID_Filtro ;
      private string AV46TFDocTipoNome ;
      private string AV47TFDocTipoNome_Sel ;
      private string AV44TFDocNome ;
      private string AV45TFDocNome_Sel ;
      private string AV59GridAppliedFilters ;
      private string AV52DDO_DocInsDataHoraAuxDateText ;
      private string A290DocOrigem ;
      private string A291DocOrigemID ;
      private string A148DocTipoNome ;
      private string A305DocNome ;
      private string lV83Core_documentowwds_3_filterfulltext ;
      private string lV87Core_documentowwds_7_doctiposigla1 ;
      private string lV92Core_documentowwds_12_doctiposigla2 ;
      private string lV97Core_documentowwds_17_doctiposigla3 ;
      private string lV98Core_documentowwds_18_tfdoctiponome ;
      private string lV100Core_documentowwds_20_tfdocnome ;
      private string AV83Core_documentowwds_3_filterfulltext ;
      private string AV84Core_documentowwds_4_dynamicfiltersselector1 ;
      private string AV87Core_documentowwds_7_doctiposigla1 ;
      private string AV89Core_documentowwds_9_dynamicfiltersselector2 ;
      private string AV92Core_documentowwds_12_doctiposigla2 ;
      private string AV94Core_documentowwds_14_dynamicfiltersselector3 ;
      private string AV97Core_documentowwds_17_doctiposigla3 ;
      private string AV99Core_documentowwds_19_tfdoctiponome_sel ;
      private string AV98Core_documentowwds_18_tfdoctiponome ;
      private string AV101Core_documentowwds_21_tfdocnome_sel ;
      private string AV100Core_documentowwds_20_tfdocnome ;
      private string A147DocTipoSigla ;
      private string AV81Core_documentowwds_1_docorigem_filtro ;
      private string AV82Core_documentowwds_2_docorigemid_filtro ;
      private string AV79webSessionParm ;
      private string AV34ExcelFilename ;
      private string AV35ErrorMessage ;
      private string A362NegAssunto ;
      private Guid A289DocID ;
      private Guid A326DocVersaoIDPai ;
      private Guid A345NegID ;
      private IGxSession AV40Session ;
      private GXWebComponent WebComp_Wcnegociopjgeneral ;
      private GXWebComponent WebComp_Grid_dwc ;
      private GXWebComponent WebComp_Wwpaux_wc ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDvpanel_tableoportunidade ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_agexport ;
      private GXUserControl ucDdc_subscriptions ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucInnewwindow1 ;
      private GXUserControl ucDdo_gridcolumnsselector ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucTfdocinsdatahora_rangepicker ;
      private GXUserControl ucDvelop_confirmpanel_novaversao ;
      private GXUserControl ucDdo_managefilters ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavDynamicfiltersselector1 ;
      private GXCombobox cmbavDynamicfiltersoperator1 ;
      private GXCombobox cmbavDynamicfiltersselector2 ;
      private GXCombobox cmbavDynamicfiltersoperator2 ;
      private GXCombobox cmbavDynamicfiltersselector3 ;
      private GXCombobox cmbavDynamicfiltersoperator3 ;
      private GXCombobox cmbavGridactions ;
      private GXCheckbox chkDocContrato ;
      private GXCheckbox chkDocAssinado ;
      private IDataStoreProvider pr_default ;
      private bool[] H005C2_A640DocAtivo ;
      private bool[] H005C2_n640DocAtivo ;
      private string[] H005C2_A147DocTipoSigla ;
      private Guid[] H005C2_A326DocVersaoIDPai ;
      private bool[] H005C2_n326DocVersaoIDPai ;
      private int[] H005C2_A146DocTipoID ;
      private bool[] H005C2_A481DocAssinado ;
      private bool[] H005C2_A480DocContrato ;
      private DateTime[] H005C2_A294DocInsDataHora ;
      private short[] H005C2_A325DocVersao ;
      private string[] H005C2_A305DocNome ;
      private string[] H005C2_A148DocTipoNome ;
      private string[] H005C2_A291DocOrigemID ;
      private string[] H005C2_A290DocOrigem ;
      private Guid[] H005C2_A289DocID ;
      private long[] H005C3_AGRID_nRecordCount ;
      private Guid[] H005C4_A345NegID ;
      private string[] H005C4_A362NegAssunto ;
      private long[] H005C4_A356NegCodigo ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV8HTTPRequest ;
      private IGxSession AV78webSession ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV41ManageFiltersData ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV63AGExportData ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV55GAMErrors ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV10TrnContextAtt ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV12GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV13GridStateDynamicFilter ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV38ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV39ColumnsSelectorAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item AV64AGExportDataItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV53DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV54GAMSession ;
      private GeneXus.Programs.core.SdtsdtDocumento AV77sdtDocumento ;
   }

   public class documentoww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H005C2( IGxContext context ,
                                             string AV83Core_documentowwds_3_filterfulltext ,
                                             string AV84Core_documentowwds_4_dynamicfiltersselector1 ,
                                             short AV85Core_documentowwds_5_dynamicfiltersoperator1 ,
                                             short AV86Core_documentowwds_6_docversao1 ,
                                             string AV87Core_documentowwds_7_doctiposigla1 ,
                                             bool AV88Core_documentowwds_8_dynamicfiltersenabled2 ,
                                             string AV89Core_documentowwds_9_dynamicfiltersselector2 ,
                                             short AV90Core_documentowwds_10_dynamicfiltersoperator2 ,
                                             short AV91Core_documentowwds_11_docversao2 ,
                                             string AV92Core_documentowwds_12_doctiposigla2 ,
                                             bool AV93Core_documentowwds_13_dynamicfiltersenabled3 ,
                                             string AV94Core_documentowwds_14_dynamicfiltersselector3 ,
                                             short AV95Core_documentowwds_15_dynamicfiltersoperator3 ,
                                             short AV96Core_documentowwds_16_docversao3 ,
                                             string AV97Core_documentowwds_17_doctiposigla3 ,
                                             string AV99Core_documentowwds_19_tfdoctiponome_sel ,
                                             string AV98Core_documentowwds_18_tfdoctiponome ,
                                             string AV101Core_documentowwds_21_tfdocnome_sel ,
                                             string AV100Core_documentowwds_20_tfdocnome ,
                                             short AV102Core_documentowwds_22_tfdocversao ,
                                             short AV103Core_documentowwds_23_tfdocversao_to ,
                                             DateTime AV104Core_documentowwds_24_tfdocinsdatahora ,
                                             DateTime AV105Core_documentowwds_25_tfdocinsdatahora_to ,
                                             short AV106Core_documentowwds_26_tfdoccontrato_sel ,
                                             short AV107Core_documentowwds_27_tfdocassinado_sel ,
                                             string A148DocTipoNome ,
                                             string A305DocNome ,
                                             short A325DocVersao ,
                                             string A147DocTipoSigla ,
                                             DateTime A294DocInsDataHora ,
                                             bool A480DocContrato ,
                                             bool A481DocAssinado ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc ,
                                             string A290DocOrigem ,
                                             string AV66DocOrigem ,
                                             string A291DocOrigemID ,
                                             string AV67DocOrigemID ,
                                             bool A640DocAtivo )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[31];
         Object[] GXv_Object7 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.DocAtivo, T2.DocTipoSigla, T1.DocVersaoIDPai, T1.DocTipoID, T1.DocAssinado, T1.DocContrato, T1.DocInsDataHora, T1.DocVersao, T1.DocNome, T2.DocTipoNome, T1.DocOrigemID, T1.DocOrigem, T1.DocID";
         sFromString = " FROM (tb_documento T1 INNER JOIN tb_documentotipo T2 ON T2.DocTipoID = T1.DocTipoID)";
         sOrderString = "";
         AddWhere(sWhereString, "(T1.DocOrigem = ( :AV66DocOrigem))");
         AddWhere(sWhereString, "(T1.DocOrigemID = ( :AV67DocOrigemID))");
         AddWhere(sWhereString, "(T1.DocAtivo = TRUE)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Core_documentowwds_3_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T2.DocTipoNome like '%' || :lV83Core_documentowwds_3_filterfulltext) or ( T1.DocNome like '%' || :lV83Core_documentowwds_3_filterfulltext) or ( SUBSTR(TO_CHAR(T1.DocVersao,'9999'), 2) like '%' || :lV83Core_documentowwds_3_filterfulltext))");
         }
         else
         {
            GXv_int6[2] = 1;
            GXv_int6[3] = 1;
            GXv_int6[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV84Core_documentowwds_4_dynamicfiltersselector1, "DOCVERSAO") == 0 ) && ( AV85Core_documentowwds_5_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV86Core_documentowwds_6_docversao1) ) )
         {
            AddWhere(sWhereString, "(T1.DocVersao >= :AV86Core_documentowwds_6_docversao1)");
         }
         else
         {
            GXv_int6[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV84Core_documentowwds_4_dynamicfiltersselector1, "DOCVERSAO") == 0 ) && ( AV85Core_documentowwds_5_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV86Core_documentowwds_6_docversao1) ) )
         {
            AddWhere(sWhereString, "(T1.DocVersao = :AV86Core_documentowwds_6_docversao1)");
         }
         else
         {
            GXv_int6[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV84Core_documentowwds_4_dynamicfiltersselector1, "DOCVERSAO") == 0 ) && ( AV85Core_documentowwds_5_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV86Core_documentowwds_6_docversao1) ) )
         {
            AddWhere(sWhereString, "(T1.DocVersao <= :AV86Core_documentowwds_6_docversao1)");
         }
         else
         {
            GXv_int6[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV84Core_documentowwds_4_dynamicfiltersselector1, "DOCTIPOSIGLA") == 0 ) && ( AV85Core_documentowwds_5_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Core_documentowwds_7_doctiposigla1)) ) )
         {
            AddWhere(sWhereString, "(T2.DocTipoSigla like :lV87Core_documentowwds_7_doctiposigla1)");
         }
         else
         {
            GXv_int6[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV84Core_documentowwds_4_dynamicfiltersselector1, "DOCTIPOSIGLA") == 0 ) && ( AV85Core_documentowwds_5_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Core_documentowwds_7_doctiposigla1)) ) )
         {
            AddWhere(sWhereString, "(T2.DocTipoSigla like '%' || :lV87Core_documentowwds_7_doctiposigla1)");
         }
         else
         {
            GXv_int6[9] = 1;
         }
         if ( AV88Core_documentowwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV89Core_documentowwds_9_dynamicfiltersselector2, "DOCVERSAO") == 0 ) && ( AV90Core_documentowwds_10_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV91Core_documentowwds_11_docversao2) ) )
         {
            AddWhere(sWhereString, "(T1.DocVersao >= :AV91Core_documentowwds_11_docversao2)");
         }
         else
         {
            GXv_int6[10] = 1;
         }
         if ( AV88Core_documentowwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV89Core_documentowwds_9_dynamicfiltersselector2, "DOCVERSAO") == 0 ) && ( AV90Core_documentowwds_10_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV91Core_documentowwds_11_docversao2) ) )
         {
            AddWhere(sWhereString, "(T1.DocVersao = :AV91Core_documentowwds_11_docversao2)");
         }
         else
         {
            GXv_int6[11] = 1;
         }
         if ( AV88Core_documentowwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV89Core_documentowwds_9_dynamicfiltersselector2, "DOCVERSAO") == 0 ) && ( AV90Core_documentowwds_10_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV91Core_documentowwds_11_docversao2) ) )
         {
            AddWhere(sWhereString, "(T1.DocVersao <= :AV91Core_documentowwds_11_docversao2)");
         }
         else
         {
            GXv_int6[12] = 1;
         }
         if ( AV88Core_documentowwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV89Core_documentowwds_9_dynamicfiltersselector2, "DOCTIPOSIGLA") == 0 ) && ( AV90Core_documentowwds_10_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Core_documentowwds_12_doctiposigla2)) ) )
         {
            AddWhere(sWhereString, "(T2.DocTipoSigla like :lV92Core_documentowwds_12_doctiposigla2)");
         }
         else
         {
            GXv_int6[13] = 1;
         }
         if ( AV88Core_documentowwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV89Core_documentowwds_9_dynamicfiltersselector2, "DOCTIPOSIGLA") == 0 ) && ( AV90Core_documentowwds_10_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Core_documentowwds_12_doctiposigla2)) ) )
         {
            AddWhere(sWhereString, "(T2.DocTipoSigla like '%' || :lV92Core_documentowwds_12_doctiposigla2)");
         }
         else
         {
            GXv_int6[14] = 1;
         }
         if ( AV93Core_documentowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV94Core_documentowwds_14_dynamicfiltersselector3, "DOCVERSAO") == 0 ) && ( AV95Core_documentowwds_15_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV96Core_documentowwds_16_docversao3) ) )
         {
            AddWhere(sWhereString, "(T1.DocVersao >= :AV96Core_documentowwds_16_docversao3)");
         }
         else
         {
            GXv_int6[15] = 1;
         }
         if ( AV93Core_documentowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV94Core_documentowwds_14_dynamicfiltersselector3, "DOCVERSAO") == 0 ) && ( AV95Core_documentowwds_15_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV96Core_documentowwds_16_docversao3) ) )
         {
            AddWhere(sWhereString, "(T1.DocVersao = :AV96Core_documentowwds_16_docversao3)");
         }
         else
         {
            GXv_int6[16] = 1;
         }
         if ( AV93Core_documentowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV94Core_documentowwds_14_dynamicfiltersselector3, "DOCVERSAO") == 0 ) && ( AV95Core_documentowwds_15_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV96Core_documentowwds_16_docversao3) ) )
         {
            AddWhere(sWhereString, "(T1.DocVersao <= :AV96Core_documentowwds_16_docversao3)");
         }
         else
         {
            GXv_int6[17] = 1;
         }
         if ( AV93Core_documentowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV94Core_documentowwds_14_dynamicfiltersselector3, "DOCTIPOSIGLA") == 0 ) && ( AV95Core_documentowwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Core_documentowwds_17_doctiposigla3)) ) )
         {
            AddWhere(sWhereString, "(T2.DocTipoSigla like :lV97Core_documentowwds_17_doctiposigla3)");
         }
         else
         {
            GXv_int6[18] = 1;
         }
         if ( AV93Core_documentowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV94Core_documentowwds_14_dynamicfiltersselector3, "DOCTIPOSIGLA") == 0 ) && ( AV95Core_documentowwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Core_documentowwds_17_doctiposigla3)) ) )
         {
            AddWhere(sWhereString, "(T2.DocTipoSigla like '%' || :lV97Core_documentowwds_17_doctiposigla3)");
         }
         else
         {
            GXv_int6[19] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV99Core_documentowwds_19_tfdoctiponome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Core_documentowwds_18_tfdoctiponome)) ) )
         {
            AddWhere(sWhereString, "(T2.DocTipoNome like :lV98Core_documentowwds_18_tfdoctiponome)");
         }
         else
         {
            GXv_int6[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Core_documentowwds_19_tfdoctiponome_sel)) && ! ( StringUtil.StrCmp(AV99Core_documentowwds_19_tfdoctiponome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.DocTipoNome = ( :AV99Core_documentowwds_19_tfdoctiponome_sel))");
         }
         else
         {
            GXv_int6[21] = 1;
         }
         if ( StringUtil.StrCmp(AV99Core_documentowwds_19_tfdoctiponome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.DocTipoNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV101Core_documentowwds_21_tfdocnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Core_documentowwds_20_tfdocnome)) ) )
         {
            AddWhere(sWhereString, "(T1.DocNome like :lV100Core_documentowwds_20_tfdocnome)");
         }
         else
         {
            GXv_int6[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Core_documentowwds_21_tfdocnome_sel)) && ! ( StringUtil.StrCmp(AV101Core_documentowwds_21_tfdocnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.DocNome = ( :AV101Core_documentowwds_21_tfdocnome_sel))");
         }
         else
         {
            GXv_int6[23] = 1;
         }
         if ( StringUtil.StrCmp(AV101Core_documentowwds_21_tfdocnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.DocNome))=0))");
         }
         if ( ! (0==AV102Core_documentowwds_22_tfdocversao) )
         {
            AddWhere(sWhereString, "(T1.DocVersao >= :AV102Core_documentowwds_22_tfdocversao)");
         }
         else
         {
            GXv_int6[24] = 1;
         }
         if ( ! (0==AV103Core_documentowwds_23_tfdocversao_to) )
         {
            AddWhere(sWhereString, "(T1.DocVersao <= :AV103Core_documentowwds_23_tfdocversao_to)");
         }
         else
         {
            GXv_int6[25] = 1;
         }
         if ( ! (DateTime.MinValue==AV104Core_documentowwds_24_tfdocinsdatahora) )
         {
            AddWhere(sWhereString, "(T1.DocInsDataHora >= :AV104Core_documentowwds_24_tfdocinsdatahora)");
         }
         else
         {
            GXv_int6[26] = 1;
         }
         if ( ! (DateTime.MinValue==AV105Core_documentowwds_25_tfdocinsdatahora_to) )
         {
            AddWhere(sWhereString, "(T1.DocInsDataHora <= :AV105Core_documentowwds_25_tfdocinsdatahora_to)");
         }
         else
         {
            GXv_int6[27] = 1;
         }
         if ( AV106Core_documentowwds_26_tfdoccontrato_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.DocContrato = TRUE)");
         }
         if ( AV106Core_documentowwds_26_tfdoccontrato_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.DocContrato = FALSE)");
         }
         if ( AV107Core_documentowwds_27_tfdocassinado_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.DocAssinado = TRUE)");
         }
         if ( AV107Core_documentowwds_27_tfdocassinado_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.DocAssinado = FALSE)");
         }
         if ( AV14OrderedBy == 1 )
         {
            sOrderString += " ORDER BY T1.DocOrigem, T1.DocOrigemID, T1.DocInsDataHora DESC, T1.DocID";
         }
         else if ( ( AV14OrderedBy == 2 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T2.DocTipoNome, T1.DocID";
         }
         else if ( ( AV14OrderedBy == 2 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T2.DocTipoNome DESC, T1.DocID";
         }
         else if ( ( AV14OrderedBy == 3 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.DocNome, T1.DocID";
         }
         else if ( ( AV14OrderedBy == 3 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.DocNome DESC, T1.DocID";
         }
         else if ( ( AV14OrderedBy == 4 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.DocVersao, T1.DocID";
         }
         else if ( ( AV14OrderedBy == 4 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.DocVersao DESC, T1.DocID";
         }
         else if ( ( AV14OrderedBy == 5 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.DocInsDataHora, T1.DocID";
         }
         else if ( ( AV14OrderedBy == 5 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.DocInsDataHora DESC, T1.DocID";
         }
         else if ( ( AV14OrderedBy == 6 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.DocContrato, T1.DocID";
         }
         else if ( ( AV14OrderedBy == 6 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.DocContrato DESC, T1.DocID";
         }
         else if ( ( AV14OrderedBy == 7 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.DocAssinado, T1.DocID";
         }
         else if ( ( AV14OrderedBy == 7 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.DocAssinado DESC, T1.DocID";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.DocID";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      protected Object[] conditional_H005C3( IGxContext context ,
                                             string AV83Core_documentowwds_3_filterfulltext ,
                                             string AV84Core_documentowwds_4_dynamicfiltersselector1 ,
                                             short AV85Core_documentowwds_5_dynamicfiltersoperator1 ,
                                             short AV86Core_documentowwds_6_docversao1 ,
                                             string AV87Core_documentowwds_7_doctiposigla1 ,
                                             bool AV88Core_documentowwds_8_dynamicfiltersenabled2 ,
                                             string AV89Core_documentowwds_9_dynamicfiltersselector2 ,
                                             short AV90Core_documentowwds_10_dynamicfiltersoperator2 ,
                                             short AV91Core_documentowwds_11_docversao2 ,
                                             string AV92Core_documentowwds_12_doctiposigla2 ,
                                             bool AV93Core_documentowwds_13_dynamicfiltersenabled3 ,
                                             string AV94Core_documentowwds_14_dynamicfiltersselector3 ,
                                             short AV95Core_documentowwds_15_dynamicfiltersoperator3 ,
                                             short AV96Core_documentowwds_16_docversao3 ,
                                             string AV97Core_documentowwds_17_doctiposigla3 ,
                                             string AV99Core_documentowwds_19_tfdoctiponome_sel ,
                                             string AV98Core_documentowwds_18_tfdoctiponome ,
                                             string AV101Core_documentowwds_21_tfdocnome_sel ,
                                             string AV100Core_documentowwds_20_tfdocnome ,
                                             short AV102Core_documentowwds_22_tfdocversao ,
                                             short AV103Core_documentowwds_23_tfdocversao_to ,
                                             DateTime AV104Core_documentowwds_24_tfdocinsdatahora ,
                                             DateTime AV105Core_documentowwds_25_tfdocinsdatahora_to ,
                                             short AV106Core_documentowwds_26_tfdoccontrato_sel ,
                                             short AV107Core_documentowwds_27_tfdocassinado_sel ,
                                             string A148DocTipoNome ,
                                             string A305DocNome ,
                                             short A325DocVersao ,
                                             string A147DocTipoSigla ,
                                             DateTime A294DocInsDataHora ,
                                             bool A480DocContrato ,
                                             bool A481DocAssinado ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc ,
                                             string A290DocOrigem ,
                                             string AV66DocOrigem ,
                                             string A291DocOrigemID ,
                                             string AV67DocOrigemID ,
                                             bool A640DocAtivo )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[28];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM (tb_documento T1 INNER JOIN tb_documentotipo T2 ON T2.DocTipoID = T1.DocTipoID)";
         AddWhere(sWhereString, "(T1.DocOrigem = ( :AV66DocOrigem))");
         AddWhere(sWhereString, "(T1.DocOrigemID = ( :AV67DocOrigemID))");
         AddWhere(sWhereString, "(T1.DocAtivo = TRUE)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Core_documentowwds_3_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T2.DocTipoNome like '%' || :lV83Core_documentowwds_3_filterfulltext) or ( T1.DocNome like '%' || :lV83Core_documentowwds_3_filterfulltext) or ( SUBSTR(TO_CHAR(T1.DocVersao,'9999'), 2) like '%' || :lV83Core_documentowwds_3_filterfulltext))");
         }
         else
         {
            GXv_int8[2] = 1;
            GXv_int8[3] = 1;
            GXv_int8[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV84Core_documentowwds_4_dynamicfiltersselector1, "DOCVERSAO") == 0 ) && ( AV85Core_documentowwds_5_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV86Core_documentowwds_6_docversao1) ) )
         {
            AddWhere(sWhereString, "(T1.DocVersao >= :AV86Core_documentowwds_6_docversao1)");
         }
         else
         {
            GXv_int8[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV84Core_documentowwds_4_dynamicfiltersselector1, "DOCVERSAO") == 0 ) && ( AV85Core_documentowwds_5_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV86Core_documentowwds_6_docversao1) ) )
         {
            AddWhere(sWhereString, "(T1.DocVersao = :AV86Core_documentowwds_6_docversao1)");
         }
         else
         {
            GXv_int8[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV84Core_documentowwds_4_dynamicfiltersselector1, "DOCVERSAO") == 0 ) && ( AV85Core_documentowwds_5_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV86Core_documentowwds_6_docversao1) ) )
         {
            AddWhere(sWhereString, "(T1.DocVersao <= :AV86Core_documentowwds_6_docversao1)");
         }
         else
         {
            GXv_int8[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV84Core_documentowwds_4_dynamicfiltersselector1, "DOCTIPOSIGLA") == 0 ) && ( AV85Core_documentowwds_5_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Core_documentowwds_7_doctiposigla1)) ) )
         {
            AddWhere(sWhereString, "(T2.DocTipoSigla like :lV87Core_documentowwds_7_doctiposigla1)");
         }
         else
         {
            GXv_int8[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV84Core_documentowwds_4_dynamicfiltersselector1, "DOCTIPOSIGLA") == 0 ) && ( AV85Core_documentowwds_5_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Core_documentowwds_7_doctiposigla1)) ) )
         {
            AddWhere(sWhereString, "(T2.DocTipoSigla like '%' || :lV87Core_documentowwds_7_doctiposigla1)");
         }
         else
         {
            GXv_int8[9] = 1;
         }
         if ( AV88Core_documentowwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV89Core_documentowwds_9_dynamicfiltersselector2, "DOCVERSAO") == 0 ) && ( AV90Core_documentowwds_10_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV91Core_documentowwds_11_docversao2) ) )
         {
            AddWhere(sWhereString, "(T1.DocVersao >= :AV91Core_documentowwds_11_docversao2)");
         }
         else
         {
            GXv_int8[10] = 1;
         }
         if ( AV88Core_documentowwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV89Core_documentowwds_9_dynamicfiltersselector2, "DOCVERSAO") == 0 ) && ( AV90Core_documentowwds_10_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV91Core_documentowwds_11_docversao2) ) )
         {
            AddWhere(sWhereString, "(T1.DocVersao = :AV91Core_documentowwds_11_docversao2)");
         }
         else
         {
            GXv_int8[11] = 1;
         }
         if ( AV88Core_documentowwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV89Core_documentowwds_9_dynamicfiltersselector2, "DOCVERSAO") == 0 ) && ( AV90Core_documentowwds_10_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV91Core_documentowwds_11_docversao2) ) )
         {
            AddWhere(sWhereString, "(T1.DocVersao <= :AV91Core_documentowwds_11_docversao2)");
         }
         else
         {
            GXv_int8[12] = 1;
         }
         if ( AV88Core_documentowwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV89Core_documentowwds_9_dynamicfiltersselector2, "DOCTIPOSIGLA") == 0 ) && ( AV90Core_documentowwds_10_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Core_documentowwds_12_doctiposigla2)) ) )
         {
            AddWhere(sWhereString, "(T2.DocTipoSigla like :lV92Core_documentowwds_12_doctiposigla2)");
         }
         else
         {
            GXv_int8[13] = 1;
         }
         if ( AV88Core_documentowwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV89Core_documentowwds_9_dynamicfiltersselector2, "DOCTIPOSIGLA") == 0 ) && ( AV90Core_documentowwds_10_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Core_documentowwds_12_doctiposigla2)) ) )
         {
            AddWhere(sWhereString, "(T2.DocTipoSigla like '%' || :lV92Core_documentowwds_12_doctiposigla2)");
         }
         else
         {
            GXv_int8[14] = 1;
         }
         if ( AV93Core_documentowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV94Core_documentowwds_14_dynamicfiltersselector3, "DOCVERSAO") == 0 ) && ( AV95Core_documentowwds_15_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV96Core_documentowwds_16_docversao3) ) )
         {
            AddWhere(sWhereString, "(T1.DocVersao >= :AV96Core_documentowwds_16_docversao3)");
         }
         else
         {
            GXv_int8[15] = 1;
         }
         if ( AV93Core_documentowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV94Core_documentowwds_14_dynamicfiltersselector3, "DOCVERSAO") == 0 ) && ( AV95Core_documentowwds_15_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV96Core_documentowwds_16_docversao3) ) )
         {
            AddWhere(sWhereString, "(T1.DocVersao = :AV96Core_documentowwds_16_docversao3)");
         }
         else
         {
            GXv_int8[16] = 1;
         }
         if ( AV93Core_documentowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV94Core_documentowwds_14_dynamicfiltersselector3, "DOCVERSAO") == 0 ) && ( AV95Core_documentowwds_15_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV96Core_documentowwds_16_docversao3) ) )
         {
            AddWhere(sWhereString, "(T1.DocVersao <= :AV96Core_documentowwds_16_docversao3)");
         }
         else
         {
            GXv_int8[17] = 1;
         }
         if ( AV93Core_documentowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV94Core_documentowwds_14_dynamicfiltersselector3, "DOCTIPOSIGLA") == 0 ) && ( AV95Core_documentowwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Core_documentowwds_17_doctiposigla3)) ) )
         {
            AddWhere(sWhereString, "(T2.DocTipoSigla like :lV97Core_documentowwds_17_doctiposigla3)");
         }
         else
         {
            GXv_int8[18] = 1;
         }
         if ( AV93Core_documentowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV94Core_documentowwds_14_dynamicfiltersselector3, "DOCTIPOSIGLA") == 0 ) && ( AV95Core_documentowwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Core_documentowwds_17_doctiposigla3)) ) )
         {
            AddWhere(sWhereString, "(T2.DocTipoSigla like '%' || :lV97Core_documentowwds_17_doctiposigla3)");
         }
         else
         {
            GXv_int8[19] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV99Core_documentowwds_19_tfdoctiponome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Core_documentowwds_18_tfdoctiponome)) ) )
         {
            AddWhere(sWhereString, "(T2.DocTipoNome like :lV98Core_documentowwds_18_tfdoctiponome)");
         }
         else
         {
            GXv_int8[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Core_documentowwds_19_tfdoctiponome_sel)) && ! ( StringUtil.StrCmp(AV99Core_documentowwds_19_tfdoctiponome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.DocTipoNome = ( :AV99Core_documentowwds_19_tfdoctiponome_sel))");
         }
         else
         {
            GXv_int8[21] = 1;
         }
         if ( StringUtil.StrCmp(AV99Core_documentowwds_19_tfdoctiponome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.DocTipoNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV101Core_documentowwds_21_tfdocnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Core_documentowwds_20_tfdocnome)) ) )
         {
            AddWhere(sWhereString, "(T1.DocNome like :lV100Core_documentowwds_20_tfdocnome)");
         }
         else
         {
            GXv_int8[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Core_documentowwds_21_tfdocnome_sel)) && ! ( StringUtil.StrCmp(AV101Core_documentowwds_21_tfdocnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.DocNome = ( :AV101Core_documentowwds_21_tfdocnome_sel))");
         }
         else
         {
            GXv_int8[23] = 1;
         }
         if ( StringUtil.StrCmp(AV101Core_documentowwds_21_tfdocnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.DocNome))=0))");
         }
         if ( ! (0==AV102Core_documentowwds_22_tfdocversao) )
         {
            AddWhere(sWhereString, "(T1.DocVersao >= :AV102Core_documentowwds_22_tfdocversao)");
         }
         else
         {
            GXv_int8[24] = 1;
         }
         if ( ! (0==AV103Core_documentowwds_23_tfdocversao_to) )
         {
            AddWhere(sWhereString, "(T1.DocVersao <= :AV103Core_documentowwds_23_tfdocversao_to)");
         }
         else
         {
            GXv_int8[25] = 1;
         }
         if ( ! (DateTime.MinValue==AV104Core_documentowwds_24_tfdocinsdatahora) )
         {
            AddWhere(sWhereString, "(T1.DocInsDataHora >= :AV104Core_documentowwds_24_tfdocinsdatahora)");
         }
         else
         {
            GXv_int8[26] = 1;
         }
         if ( ! (DateTime.MinValue==AV105Core_documentowwds_25_tfdocinsdatahora_to) )
         {
            AddWhere(sWhereString, "(T1.DocInsDataHora <= :AV105Core_documentowwds_25_tfdocinsdatahora_to)");
         }
         else
         {
            GXv_int8[27] = 1;
         }
         if ( AV106Core_documentowwds_26_tfdoccontrato_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.DocContrato = TRUE)");
         }
         if ( AV106Core_documentowwds_26_tfdoccontrato_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.DocContrato = FALSE)");
         }
         if ( AV107Core_documentowwds_27_tfdocassinado_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.DocAssinado = TRUE)");
         }
         if ( AV107Core_documentowwds_27_tfdocassinado_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.DocAssinado = FALSE)");
         }
         scmdbuf += sWhereString;
         if ( AV14OrderedBy == 1 )
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
         else if ( true )
         {
            scmdbuf += "";
         }
         GXv_Object9[0] = scmdbuf;
         GXv_Object9[1] = GXv_int8;
         return GXv_Object9 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H005C2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (short)dynConstraints[19] , (short)dynConstraints[20] , (DateTime)dynConstraints[21] , (DateTime)dynConstraints[22] , (short)dynConstraints[23] , (short)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (short)dynConstraints[27] , (string)dynConstraints[28] , (DateTime)dynConstraints[29] , (bool)dynConstraints[30] , (bool)dynConstraints[31] , (short)dynConstraints[32] , (bool)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (bool)dynConstraints[38] );
               case 1 :
                     return conditional_H005C3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (short)dynConstraints[19] , (short)dynConstraints[20] , (DateTime)dynConstraints[21] , (DateTime)dynConstraints[22] , (short)dynConstraints[23] , (short)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (short)dynConstraints[27] , (string)dynConstraints[28] , (DateTime)dynConstraints[29] , (bool)dynConstraints[30] , (bool)dynConstraints[31] , (short)dynConstraints[32] , (bool)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (bool)dynConstraints[38] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH005C4;
          prmH005C4 = new Object[] {
          new ParDef("AV67DocOrigemID",GXType.VarChar,50,0)
          };
          Object[] prmH005C2;
          prmH005C2 = new Object[] {
          new ParDef("AV66DocOrigem",GXType.VarChar,30,0) ,
          new ParDef("AV67DocOrigemID",GXType.VarChar,50,0) ,
          new ParDef("lV83Core_documentowwds_3_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV83Core_documentowwds_3_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV83Core_documentowwds_3_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV86Core_documentowwds_6_docversao1",GXType.Int16,4,0) ,
          new ParDef("AV86Core_documentowwds_6_docversao1",GXType.Int16,4,0) ,
          new ParDef("AV86Core_documentowwds_6_docversao1",GXType.Int16,4,0) ,
          new ParDef("lV87Core_documentowwds_7_doctiposigla1",GXType.VarChar,20,0) ,
          new ParDef("lV87Core_documentowwds_7_doctiposigla1",GXType.VarChar,20,0) ,
          new ParDef("AV91Core_documentowwds_11_docversao2",GXType.Int16,4,0) ,
          new ParDef("AV91Core_documentowwds_11_docversao2",GXType.Int16,4,0) ,
          new ParDef("AV91Core_documentowwds_11_docversao2",GXType.Int16,4,0) ,
          new ParDef("lV92Core_documentowwds_12_doctiposigla2",GXType.VarChar,20,0) ,
          new ParDef("lV92Core_documentowwds_12_doctiposigla2",GXType.VarChar,20,0) ,
          new ParDef("AV96Core_documentowwds_16_docversao3",GXType.Int16,4,0) ,
          new ParDef("AV96Core_documentowwds_16_docversao3",GXType.Int16,4,0) ,
          new ParDef("AV96Core_documentowwds_16_docversao3",GXType.Int16,4,0) ,
          new ParDef("lV97Core_documentowwds_17_doctiposigla3",GXType.VarChar,20,0) ,
          new ParDef("lV97Core_documentowwds_17_doctiposigla3",GXType.VarChar,20,0) ,
          new ParDef("lV98Core_documentowwds_18_tfdoctiponome",GXType.VarChar,80,0) ,
          new ParDef("AV99Core_documentowwds_19_tfdoctiponome_sel",GXType.VarChar,80,0) ,
          new ParDef("lV100Core_documentowwds_20_tfdocnome",GXType.VarChar,80,0) ,
          new ParDef("AV101Core_documentowwds_21_tfdocnome_sel",GXType.VarChar,80,0) ,
          new ParDef("AV102Core_documentowwds_22_tfdocversao",GXType.Int16,4,0) ,
          new ParDef("AV103Core_documentowwds_23_tfdocversao_to",GXType.Int16,4,0) ,
          new ParDef("AV104Core_documentowwds_24_tfdocinsdatahora",GXType.DateTime2,10,12) ,
          new ParDef("AV105Core_documentowwds_25_tfdocinsdatahora_to",GXType.DateTime2,10,12) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH005C3;
          prmH005C3 = new Object[] {
          new ParDef("AV66DocOrigem",GXType.VarChar,30,0) ,
          new ParDef("AV67DocOrigemID",GXType.VarChar,50,0) ,
          new ParDef("lV83Core_documentowwds_3_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV83Core_documentowwds_3_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV83Core_documentowwds_3_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV86Core_documentowwds_6_docversao1",GXType.Int16,4,0) ,
          new ParDef("AV86Core_documentowwds_6_docversao1",GXType.Int16,4,0) ,
          new ParDef("AV86Core_documentowwds_6_docversao1",GXType.Int16,4,0) ,
          new ParDef("lV87Core_documentowwds_7_doctiposigla1",GXType.VarChar,20,0) ,
          new ParDef("lV87Core_documentowwds_7_doctiposigla1",GXType.VarChar,20,0) ,
          new ParDef("AV91Core_documentowwds_11_docversao2",GXType.Int16,4,0) ,
          new ParDef("AV91Core_documentowwds_11_docversao2",GXType.Int16,4,0) ,
          new ParDef("AV91Core_documentowwds_11_docversao2",GXType.Int16,4,0) ,
          new ParDef("lV92Core_documentowwds_12_doctiposigla2",GXType.VarChar,20,0) ,
          new ParDef("lV92Core_documentowwds_12_doctiposigla2",GXType.VarChar,20,0) ,
          new ParDef("AV96Core_documentowwds_16_docversao3",GXType.Int16,4,0) ,
          new ParDef("AV96Core_documentowwds_16_docversao3",GXType.Int16,4,0) ,
          new ParDef("AV96Core_documentowwds_16_docversao3",GXType.Int16,4,0) ,
          new ParDef("lV97Core_documentowwds_17_doctiposigla3",GXType.VarChar,20,0) ,
          new ParDef("lV97Core_documentowwds_17_doctiposigla3",GXType.VarChar,20,0) ,
          new ParDef("lV98Core_documentowwds_18_tfdoctiponome",GXType.VarChar,80,0) ,
          new ParDef("AV99Core_documentowwds_19_tfdoctiponome_sel",GXType.VarChar,80,0) ,
          new ParDef("lV100Core_documentowwds_20_tfdocnome",GXType.VarChar,80,0) ,
          new ParDef("AV101Core_documentowwds_21_tfdocnome_sel",GXType.VarChar,80,0) ,
          new ParDef("AV102Core_documentowwds_22_tfdocversao",GXType.Int16,4,0) ,
          new ParDef("AV103Core_documentowwds_23_tfdocversao_to",GXType.Int16,4,0) ,
          new ParDef("AV104Core_documentowwds_24_tfdocinsdatahora",GXType.DateTime2,10,12) ,
          new ParDef("AV105Core_documentowwds_25_tfdocinsdatahora_to",GXType.DateTime2,10,12)
          };
          def= new CursorDef[] {
              new CursorDef("H005C2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005C2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H005C3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005C3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H005C4", "SELECT NegID, NegAssunto, NegCodigo FROM tb_negociopj WHERE NegID = CASE WHEN (:AV67DocOrigemID ~ ('[a-fA-F0-9]{8}-[a-fA-F0-9]{4}-[a-fA-F0-9]{4}-[a-fA-F0-9]{4}-[a-fA-F0-9]{12}')) THEN RTRIM(:AV67DocOrigemID) ELSE '00000000-0000-0000-0000-000000000000' END ORDER BY NegID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005C4,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((Guid[]) buf[3])[0] = rslt.getGuid(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((int[]) buf[5])[0] = rslt.getInt(4);
                ((bool[]) buf[6])[0] = rslt.getBool(5);
                ((bool[]) buf[7])[0] = rslt.getBool(6);
                ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(7, true);
                ((short[]) buf[9])[0] = rslt.getShort(8);
                ((string[]) buf[10])[0] = rslt.getVarchar(9);
                ((string[]) buf[11])[0] = rslt.getVarchar(10);
                ((string[]) buf[12])[0] = rslt.getVarchar(11);
                ((string[]) buf[13])[0] = rslt.getVarchar(12);
                ((Guid[]) buf[14])[0] = rslt.getGuid(13);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                return;
       }
    }

 }

}
