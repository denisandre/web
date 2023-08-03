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
   public class visitaww : GXDataArea
   {
      public visitaww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public visitaww( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_VisNegID ,
                           int aP1_VisNgfSeq )
      {
         this.AV129VisNegID = aP0_VisNegID;
         this.AV130VisNgfSeq = aP1_VisNgfSeq;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavDynamicfiltersoperatorvissituacao = new GXCombobox();
         cmbavVissituacao = new GXCombobox();
         cmbavGridactions = new GXCombobox();
         cmbVisSituacao = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "VisNegID");
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
               gxfirstwebparm = GetFirstPar( "VisNegID");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "VisNegID");
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
         nRC_GXsfl_81 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_81"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_81_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_81_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_81_idx = GetPar( "sGXsfl_81_idx");
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
         cmbavDynamicfiltersoperatorvissituacao.FromJSonString( GetNextPar( ));
         AV163DynamicFiltersOperatorVisSituacao = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperatorVisSituacao"), "."), 18, MidpointRounding.ToEven));
         cmbavVissituacao.FromJSonString( GetNextPar( ));
         AV164VisSituacao = GetPar( "VisSituacao");
         AV129VisNegID = StringUtil.StrToGuid( GetPar( "VisNegID"));
         AV130VisNgfSeq = (int)(Math.Round(NumberUtil.Val( GetPar( "VisNgfSeq"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV41ColumnsSelector);
         AV173Pgmname = GetPar( "Pgmname");
         AV143VisNegID_Filtro = StringUtil.StrToGuid( GetPar( "VisNegID_Filtro"));
         AV144VisNgfSeq_Filtro = (int)(Math.Round(NumberUtil.Val( GetPar( "VisNgfSeq_Filtro"), "."), 18, MidpointRounding.ToEven));
         AV165VisDel_Filtro = StringUtil.StrToBool( GetPar( "VisDel_Filtro"));
         AV57TFVisInsDataHora = context.localUtil.ParseDTimeParm( GetPar( "TFVisInsDataHora"));
         AV58TFVisInsDataHora_To = context.localUtil.ParseDTimeParm( GetPar( "TFVisInsDataHora_To"));
         AV64TFVisInsUsuNome = GetPar( "TFVisInsUsuNome");
         AV65TFVisInsUsuNome_Sel = GetPar( "TFVisInsUsuNome_Sel");
         AV66TFVisData = context.localUtil.ParseDateParm( GetPar( "TFVisData"));
         AV67TFVisData_To = context.localUtil.ParseDateParm( GetPar( "TFVisData_To"));
         AV71TFVisHora = DateTimeUtil.ResetDate(context.localUtil.ParseDTimeParm( GetPar( "TFVisHora")));
         AV72TFVisHora_To = DateTimeUtil.ResetDate(context.localUtil.ParseDTimeParm( GetPar( "TFVisHora_To")));
         AV76TFVisDataHora = context.localUtil.ParseDTimeParm( GetPar( "TFVisDataHora"));
         AV77TFVisDataHora_To = context.localUtil.ParseDTimeParm( GetPar( "TFVisDataHora_To"));
         AV146TFVisDataFim = context.localUtil.ParseDateParm( GetPar( "TFVisDataFim"));
         AV147TFVisDataFim_To = context.localUtil.ParseDateParm( GetPar( "TFVisDataFim_To"));
         AV151TFVisHoraFim = DateTimeUtil.ResetDate(context.localUtil.ParseDTimeParm( GetPar( "TFVisHoraFim")));
         AV152TFVisHoraFim_To = DateTimeUtil.ResetDate(context.localUtil.ParseDTimeParm( GetPar( "TFVisHoraFim_To")));
         AV156TFVisDataHoraFim = context.localUtil.ParseDTimeParm( GetPar( "TFVisDataHoraFim"));
         AV157TFVisDataHoraFim_To = context.localUtil.ParseDTimeParm( GetPar( "TFVisDataHoraFim_To"));
         AV85TFVisTipoNome = GetPar( "TFVisTipoNome");
         AV86TFVisTipoNome_Sel = GetPar( "TFVisTipoNome_Sel");
         AV91TFVisAssunto = GetPar( "TFVisAssunto");
         AV92TFVisAssunto_Sel = GetPar( "TFVisAssunto_Sel");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV142TFVisSituacao_Sels);
         AV93TFVisLink = GetPar( "TFVisLink");
         AV94TFVisLink_Sel = GetPar( "TFVisLink_Sel");
         AV14OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV15OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         AV103IsAuthorized_Update = StringUtil.StrToBool( GetPar( "IsAuthorized_Update"));
         AV104IsAuthorized_Delete = StringUtil.StrToBool( GetPar( "IsAuthorized_Delete"));
         AV128IsAuthorized_RemarcarVisita = StringUtil.StrToBool( GetPar( "IsAuthorized_RemarcarVisita"));
         AV108IsAuthorized_Insert = StringUtil.StrToBool( GetPar( "IsAuthorized_Insert"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV163DynamicFiltersOperatorVisSituacao, AV164VisSituacao, AV129VisNegID, AV130VisNgfSeq, AV41ColumnsSelector, AV173Pgmname, AV143VisNegID_Filtro, AV144VisNgfSeq_Filtro, AV165VisDel_Filtro, AV57TFVisInsDataHora, AV58TFVisInsDataHora_To, AV64TFVisInsUsuNome, AV65TFVisInsUsuNome_Sel, AV66TFVisData, AV67TFVisData_To, AV71TFVisHora, AV72TFVisHora_To, AV76TFVisDataHora, AV77TFVisDataHora_To, AV146TFVisDataFim, AV147TFVisDataFim_To, AV151TFVisHoraFim, AV152TFVisHoraFim_To, AV156TFVisDataHoraFim, AV157TFVisDataHoraFim_To, AV85TFVisTipoNome, AV86TFVisTipoNome_Sel, AV91TFVisAssunto, AV92TFVisAssunto_Sel, AV142TFVisSituacao_Sels, AV93TFVisLink, AV94TFVisLink_Sel, AV14OrderedBy, AV15OrderedDsc, AV103IsAuthorized_Update, AV104IsAuthorized_Delete, AV128IsAuthorized_RemarcarVisita, AV108IsAuthorized_Insert) ;
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
            return "visitaww_Execute" ;
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
         PA562( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START562( ) ;
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
         context.AddJavascriptSource("DVelop/GridTitlesCategories/GridTitlesCategoriesRender.js", "", false, true);
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
         GXEncryptionTmp = "core.visitaww.aspx"+UrlEncode(AV129VisNegID.ToString()) + "," + UrlEncode(StringUtil.LTrimStr(AV130VisNgfSeq,8,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("core.visitaww.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV173Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV173Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV103IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV103IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV104IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV104IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_REMARCARVISITA", AV128IsAuthorized_RemarcarVisita);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_REMARCARVISITA", GetSecureSignedToken( "", AV128IsAuthorized_RemarcarVisita, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV108IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV108IsAuthorized_Insert, context));
         GxWebStd.gx_hidden_field( context, "gxhash_vVISNEGID", GetSecureSignedToken( "", AV129VisNegID, context));
         GxWebStd.gx_hidden_field( context, "gxhash_vVISNGFSEQ", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV130VisNgfSeq), "ZZ,ZZZ,ZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATORVISSITUACAO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV163DynamicFiltersOperatorVisSituacao), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vVISSITUACAO", AV164VisSituacao);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_81", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_81), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV99GridCurrentPage), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV100GridPageCount), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV101GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAGEXPORTDATA", AV106AGExportData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAGEXPORTDATA", AV106AGExportData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV95DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV95DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCOLUMNSSELECTOR", AV41ColumnsSelector);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCOLUMNSSELECTOR", AV41ColumnsSelector);
         }
         GxWebStd.gx_hidden_field( context, "vDDO_VISINSDATAHORAAUXDATE", context.localUtil.DToC( AV59DDO_VisInsDataHoraAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_VISINSDATAHORAAUXDATETO", context.localUtil.DToC( AV60DDO_VisInsDataHoraAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_VISDATAAUXDATE", context.localUtil.DToC( AV68DDO_VisDataAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_VISDATAAUXDATETO", context.localUtil.DToC( AV69DDO_VisDataAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_VISHORAAUXDATE", context.localUtil.DToC( AV73DDO_VisHoraAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_VISHORAAUXDATETO", context.localUtil.DToC( AV74DDO_VisHoraAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_VISDATAHORAAUXDATE", context.localUtil.DToC( AV78DDO_VisDataHoraAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_VISDATAHORAAUXDATETO", context.localUtil.DToC( AV79DDO_VisDataHoraAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_VISDATAFIMAUXDATE", context.localUtil.DToC( AV148DDO_VisDataFimAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_VISDATAFIMAUXDATETO", context.localUtil.DToC( AV149DDO_VisDataFimAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_VISHORAFIMAUXDATE", context.localUtil.DToC( AV153DDO_VisHoraFimAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_VISHORAFIMAUXDATETO", context.localUtil.DToC( AV154DDO_VisHoraFimAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_VISDATAHORAFIMAUXDATE", context.localUtil.DToC( AV158DDO_VisDataHoraFimAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_VISDATAHORAFIMAUXDATETO", context.localUtil.DToC( AV159DDO_VisDataHoraFimAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV173Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV173Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTFVISINSDATAHORA", context.localUtil.TToC( AV57TFVisInsDataHora, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vTFVISINSDATAHORA_TO", context.localUtil.TToC( AV58TFVisInsDataHora_To, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vTFVISINSUSUNOME", AV64TFVisInsUsuNome);
         GxWebStd.gx_hidden_field( context, "vTFVISINSUSUNOME_SEL", AV65TFVisInsUsuNome_Sel);
         GxWebStd.gx_hidden_field( context, "vTFVISDATA", context.localUtil.DToC( AV66TFVisData, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFVISDATA_TO", context.localUtil.DToC( AV67TFVisData_To, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFVISHORA", context.localUtil.TToC( AV71TFVisHora, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vTFVISHORA_TO", context.localUtil.TToC( AV72TFVisHora_To, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vTFVISDATAHORA", context.localUtil.TToC( AV76TFVisDataHora, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vTFVISDATAHORA_TO", context.localUtil.TToC( AV77TFVisDataHora_To, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vTFVISDATAFIM", context.localUtil.DToC( AV146TFVisDataFim, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFVISDATAFIM_TO", context.localUtil.DToC( AV147TFVisDataFim_To, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFVISHORAFIM", context.localUtil.TToC( AV151TFVisHoraFim, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vTFVISHORAFIM_TO", context.localUtil.TToC( AV152TFVisHoraFim_To, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vTFVISDATAHORAFIM", context.localUtil.TToC( AV156TFVisDataHoraFim, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vTFVISDATAHORAFIM_TO", context.localUtil.TToC( AV157TFVisDataHoraFim_To, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vTFVISTIPONOME", AV85TFVisTipoNome);
         GxWebStd.gx_hidden_field( context, "vTFVISTIPONOME_SEL", AV86TFVisTipoNome_Sel);
         GxWebStd.gx_hidden_field( context, "vTFVISASSUNTO", AV91TFVisAssunto);
         GxWebStd.gx_hidden_field( context, "vTFVISASSUNTO_SEL", AV92TFVisAssunto_Sel);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTFVISSITUACAO_SELS", AV142TFVisSituacao_Sels);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTFVISSITUACAO_SELS", AV142TFVisSituacao_Sels);
         }
         GxWebStd.gx_hidden_field( context, "vTFVISLINK", AV93TFVisLink);
         GxWebStd.gx_hidden_field( context, "vTFVISLINK_SEL", AV94TFVisLink_Sel);
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV15OrderedDsc);
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV103IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV103IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV104IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV104IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_REMARCARVISITA", AV128IsAuthorized_RemarcarVisita);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_REMARCARVISITA", GetSecureSignedToken( "", AV128IsAuthorized_RemarcarVisita, context));
         GxWebStd.gx_hidden_field( context, "vVISID_SELECTED", AV166VisID_Selected.ToString());
         GxWebStd.gx_hidden_field( context, "vVISNEGID_SELECTED", AV167VisNegID_Selected.ToString());
         GxWebStd.gx_hidden_field( context, "vVISNGFSEQ_SELECTED", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV168VisNgfSeq_Selected), 8, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV108IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV108IsAuthorized_Insert, context));
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
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Allowmultipleselection", StringUtil.RTrim( Ddo_grid_Allowmultipleselection));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistfixedvalues", StringUtil.RTrim( Ddo_grid_Datalistfixedvalues));
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
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_DELETE_Title", StringUtil.RTrim( Dvelop_confirmpanel_delete_Title));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_DELETE_Confirmationtext", StringUtil.RTrim( Dvelop_confirmpanel_delete_Confirmationtext));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_DELETE_Yesbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_delete_Yesbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_DELETE_Nobuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_delete_Nobuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_DELETE_Cancelbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_delete_Cancelbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_DELETE_Yesbuttonposition", StringUtil.RTrim( Dvelop_confirmpanel_delete_Yesbuttonposition));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_DELETE_Confirmtype", StringUtil.RTrim( Dvelop_confirmpanel_delete_Confirmtype));
         GxWebStd.gx_hidden_field( context, "GRID_TITLESCATEGORIES_Gridinternalname", StringUtil.RTrim( Grid_titlescategories_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID_TITLESCATEGORIES_Gridtitlescategories", StringUtil.RTrim( Grid_titlescategories_Gridtitlescategories));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hascategories", StringUtil.BoolToStr( Grid_empowerer_Hascategories));
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
         if ( ! ( WebComp_Wcnegociopjgeneral == null ) )
         {
            WebComp_Wcnegociopjgeneral.componentjscripts();
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
            WE562( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT562( ) ;
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
         GXEncryptionTmp = "core.visitaww.aspx"+UrlEncode(AV129VisNegID.ToString()) + "," + UrlEncode(StringUtil.LTrimStr(AV130VisNgfSeq,8,0));
         return formatLink("core.visitaww.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "core.VisitaWW" ;
      }

      public override string GetPgmdesc( )
      {
         return "Visitas do Cliente" ;
      }

      protected void WB560( )
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
            GxWebStd.gx_label_element( context, edtavVisnegid_filtro_Internalname, "Vis Neg ID_Filtro", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 10,'',false,'" + sGXsfl_81_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavVisnegid_filtro_Internalname, AV143VisNegID_Filtro.ToString(), AV143VisNegID_Filtro.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,10);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavVisnegid_filtro_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavVisnegid_filtro_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_core\\VisitaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-xs hidden-sm hidden-md hidden-lg Invisible", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavVisngfseq_filtro_Internalname, "Vis Ngf Seq_Filtro", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'" + sGXsfl_81_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavVisngfseq_filtro_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV144VisNgfSeq_Filtro), 10, 0, ",", "")), StringUtil.LTrim( ((edtavVisngfseq_filtro_Enabled!=0) ? context.localUtil.Format( (decimal)(AV144VisNgfSeq_Filtro), "ZZ,ZZZ,ZZ9") : context.localUtil.Format( (decimal)(AV144VisNgfSeq_Filtro), "ZZ,ZZZ,ZZ9"))), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,14);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavVisngfseq_filtro_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavVisngfseq_filtro_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_core\\VisitaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-xs hidden-sm hidden-md hidden-lg Invisible", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavVisdel_filtro_Internalname, "Vis Del_Filtro", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'" + sGXsfl_81_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavVisdel_filtro_Internalname, StringUtil.BoolToStr( AV165VisDel_Filtro), StringUtil.BoolToStr( AV165VisDel_Filtro), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,18);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavVisdel_filtro_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavVisdel_filtro_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 0, 0, 0, true, "", "end", false, "", "HLP_core\\VisitaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginBottom20", "start", "top", "", "", "div");
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
               GxWebStd.gx_hidden_field( context, "W0026"+"", StringUtil.RTrim( WebComp_Wcnegociopjgeneral_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0026"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( bGXsfl_81_Refreshing )
               {
                  if ( StringUtil.Len( WebComp_Wcnegociopjgeneral_Component) != 0 )
                  {
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWcnegociopjgeneral), StringUtil.Lower( WebComp_Wcnegociopjgeneral_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0026"+"");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
            ClassString = "BtnDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(81), 2, 0)+","+"null"+");", "Voltar", bttBtncancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\VisitaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(81), 2, 0)+","+"null"+");", "Incluir", bttBtninsert_Jsonclick, 5, "Incluir", "", StyleString, ClassString, bttBtninsert_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\VisitaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
            ClassString = "ColumnsSelector";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnagexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(81), 2, 0)+","+"null"+");", "Exportar", bttBtnagexport_Jsonclick, 0, "Exportar", "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\VisitaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
            ClassString = "hidden-xs";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtneditcolumns_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(81), 2, 0)+","+"null"+");", "Selecionar colunas", bttBtneditcolumns_Jsonclick, 0, "Selecionar colunas", "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\VisitaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnsubscriptions_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(81), 2, 0)+","+"null"+");", "", bttBtnsubscriptions_Jsonclick, 0, "Assinaturas", "", StyleString, ClassString, bttBtnsubscriptions_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\VisitaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            wb_table1_47_562( true) ;
         }
         else
         {
            wb_table1_47_562( false) ;
         }
         return  ;
      }

      protected void wb_table1_47_562e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "start", "top", ""+" data-gx-for=\""+edtavNegultitenome_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavNegultitenome_Internalname, "Fase Atual", "gx-form-item AttributeFLLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'',false,'" + sGXsfl_81_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavNegultitenome_Internalname, AV161NegUltIteNome, StringUtil.RTrim( context.localUtil.Format( AV161NegUltIteNome, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,72);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavNegultitenome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavNegultitenome_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\VisitaWW.htm");
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
            StartGridControl81( ) ;
         }
         if ( wbEnd == 81 )
         {
            wbEnd = 0;
            nRC_GXsfl_81 = (int)(nGXsfl_81_idx-1);
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV99GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV100GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV101GridAppliedFilters);
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
            ucDdo_agexport.SetProperty("DropDownOptionsData", AV106AGExportData);
            ucDdo_agexport.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_agexport_Internalname, "DDO_AGEXPORTContainer");
            /* User Defined Control */
            ucDdc_subscriptions.SetProperty("IconType", Ddc_subscriptions_Icontype);
            ucDdc_subscriptions.SetProperty("Icon", Ddc_subscriptions_Icon);
            ucDdc_subscriptions.SetProperty("Caption", Ddc_subscriptions_Caption);
            ucDdc_subscriptions.SetProperty("Tooltip", Ddc_subscriptions_Tooltip);
            ucDdc_subscriptions.SetProperty("Cls", Ddc_subscriptions_Cls);
            ucDdc_subscriptions.Render(context, "dvelop.gxbootstrap.ddcomponent", Ddc_subscriptions_Internalname, "DDC_SUBSCRIPTIONSContainer");
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
            ucDdo_grid.SetProperty("AllowMultipleSelection", Ddo_grid_Allowmultipleselection);
            ucDdo_grid.SetProperty("DataListFixedValues", Ddo_grid_Datalistfixedvalues);
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV95DDO_TitleSettingsIcons);
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
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsTitleSettingsIcons", AV95DDO_TitleSettingsIcons);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsData", AV41ColumnsSelector);
            ucDdo_gridcolumnsselector.Render(context, "dvelop.gxbootstrap.ddogridcolumnsselector", Ddo_gridcolumnsselector_Internalname, "DDO_GRIDCOLUMNSSELECTORContainer");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 110,'',false,'" + sGXsfl_81_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavNegultngfseq_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV162NegUltNgfSeq), 8, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV162NegUltNgfSeq), "ZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,110);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavNegultngfseq_Jsonclick, 0, "Attribute", "", "", "", "", edtavNegultngfseq_Visible, 1, 0, "text", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_core\\VisitaWW.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtavVisnegid_Internalname, AV129VisNegID.ToString(), AV129VisNegID.ToString(), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavVisnegid_Jsonclick, 0, "Attribute", "", "", "", "", edtavVisnegid_Visible, 0, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_core\\VisitaWW.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtavVisngfseq_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV130VisNgfSeq), 10, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(AV130VisNgfSeq), "ZZ,ZZZ,ZZ9")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavVisngfseq_Jsonclick, 0, "Attribute", "", "", "", "", edtavVisngfseq_Visible, 0, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_core\\VisitaWW.htm");
            wb_table2_113_562( true) ;
         }
         else
         {
            wb_table2_113_562( false) ;
         }
         return  ;
      }

      protected void wb_table2_113_562e( bool wbgen )
      {
         if ( wbgen )
         {
            /* User Defined Control */
            ucGrid_titlescategories.SetProperty("GridTitlesCategories", Grid_titlescategories_Gridtitlescategories);
            ucGrid_titlescategories.Render(context, "dvelop.gridtitlescategories", Grid_titlescategories_Internalname, "GRID_TITLESCATEGORIESContainer");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasCategories", Grid_empowerer_Hascategories);
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.SetProperty("HasColumnsSelector", Grid_empowerer_Hascolumnsselector);
            ucGrid_empowerer.SetProperty("FixedColumns", Grid_empowerer_Fixedcolumns);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
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
               if ( bGXsfl_81_Refreshing )
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
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_visinsdatahoraauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 123,'',false,'" + sGXsfl_81_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_visinsdatahoraauxdatetext_Internalname, AV61DDO_VisInsDataHoraAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV61DDO_VisInsDataHoraAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,123);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_visinsdatahoraauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\VisitaWW.htm");
            /* User Defined Control */
            ucTfvisinsdatahora_rangepicker.SetProperty("Start Date", AV59DDO_VisInsDataHoraAuxDate);
            ucTfvisinsdatahora_rangepicker.SetProperty("End Date", AV60DDO_VisInsDataHoraAuxDateTo);
            ucTfvisinsdatahora_rangepicker.Render(context, "wwp.daterangepicker", Tfvisinsdatahora_rangepicker_Internalname, "TFVISINSDATAHORA_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_visdataauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 126,'',false,'" + sGXsfl_81_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_visdataauxdatetext_Internalname, AV70DDO_VisDataAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV70DDO_VisDataAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,126);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_visdataauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\VisitaWW.htm");
            /* User Defined Control */
            ucTfvisdata_rangepicker.SetProperty("Start Date", AV68DDO_VisDataAuxDate);
            ucTfvisdata_rangepicker.SetProperty("End Date", AV69DDO_VisDataAuxDateTo);
            ucTfvisdata_rangepicker.Render(context, "wwp.daterangepicker", Tfvisdata_rangepicker_Internalname, "TFVISDATA_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_vishoraauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 129,'',false,'" + sGXsfl_81_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_vishoraauxdatetext_Internalname, AV75DDO_VisHoraAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV75DDO_VisHoraAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,129);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_vishoraauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\VisitaWW.htm");
            /* User Defined Control */
            ucTfvishora_rangepicker.SetProperty("Start Date", AV73DDO_VisHoraAuxDate);
            ucTfvishora_rangepicker.SetProperty("End Date", AV74DDO_VisHoraAuxDateTo);
            ucTfvishora_rangepicker.Render(context, "wwp.daterangepicker", Tfvishora_rangepicker_Internalname, "TFVISHORA_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_visdatahoraauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 132,'',false,'" + sGXsfl_81_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_visdatahoraauxdatetext_Internalname, AV80DDO_VisDataHoraAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV80DDO_VisDataHoraAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,132);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_visdatahoraauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\VisitaWW.htm");
            /* User Defined Control */
            ucTfvisdatahora_rangepicker.SetProperty("Start Date", AV78DDO_VisDataHoraAuxDate);
            ucTfvisdatahora_rangepicker.SetProperty("End Date", AV79DDO_VisDataHoraAuxDateTo);
            ucTfvisdatahora_rangepicker.Render(context, "wwp.daterangepicker", Tfvisdatahora_rangepicker_Internalname, "TFVISDATAHORA_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_visdatafimauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 135,'',false,'" + sGXsfl_81_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_visdatafimauxdatetext_Internalname, AV150DDO_VisDataFimAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV150DDO_VisDataFimAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,135);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_visdatafimauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\VisitaWW.htm");
            /* User Defined Control */
            ucTfvisdatafim_rangepicker.SetProperty("Start Date", AV148DDO_VisDataFimAuxDate);
            ucTfvisdatafim_rangepicker.SetProperty("End Date", AV149DDO_VisDataFimAuxDateTo);
            ucTfvisdatafim_rangepicker.Render(context, "wwp.daterangepicker", Tfvisdatafim_rangepicker_Internalname, "TFVISDATAFIM_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_vishorafimauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 138,'',false,'" + sGXsfl_81_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_vishorafimauxdatetext_Internalname, AV155DDO_VisHoraFimAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV155DDO_VisHoraFimAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,138);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_vishorafimauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\VisitaWW.htm");
            /* User Defined Control */
            ucTfvishorafim_rangepicker.SetProperty("Start Date", AV153DDO_VisHoraFimAuxDate);
            ucTfvishorafim_rangepicker.SetProperty("End Date", AV154DDO_VisHoraFimAuxDateTo);
            ucTfvishorafim_rangepicker.Render(context, "wwp.daterangepicker", Tfvishorafim_rangepicker_Internalname, "TFVISHORAFIM_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_visdatahorafimauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 141,'',false,'" + sGXsfl_81_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_visdatahorafimauxdatetext_Internalname, AV160DDO_VisDataHoraFimAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV160DDO_VisDataHoraFimAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,141);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_visdatahorafimauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\VisitaWW.htm");
            /* User Defined Control */
            ucTfvisdatahorafim_rangepicker.SetProperty("Start Date", AV158DDO_VisDataHoraFimAuxDate);
            ucTfvisdatahorafim_rangepicker.SetProperty("End Date", AV159DDO_VisDataHoraFimAuxDateTo);
            ucTfvisdatahorafim_rangepicker.Render(context, "wwp.daterangepicker", Tfvisdatahorafim_rangepicker_Internalname, "TFVISDATAHORAFIM_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 81 )
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

      protected void START562( )
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
            Form.Meta.addItem("description", "Visitas do Cliente", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP560( ) ;
      }

      protected void WS562( )
      {
         START562( ) ;
         EVT562( ) ;
      }

      protected void EVT562( )
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
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E11562 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E12562 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_AGEXPORT.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E13562 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDC_SUBSCRIPTIONS.ONLOADCOMPONENT") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E14562 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E15562 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E16562 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DVELOP_CONFIRMPANEL_DELETE.CLOSE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E17562 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E18562 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "VGRIDACTIONS.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "VGRIDACTIONS.CLICK") == 0 ) )
                           {
                              nGXsfl_81_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_81_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_81_idx), 4, 0), 4, "0");
                              SubsflControlProps_812( ) ;
                              cmbavGridactions.Name = cmbavGridactions_Internalname;
                              cmbavGridactions.CurrentValue = cgiGet( cmbavGridactions_Internalname);
                              AV102GridActions = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavGridactions_Internalname), "."), 18, MidpointRounding.ToEven));
                              AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV102GridActions), 4, 0));
                              A401VisInsDataHora = context.localUtil.CToT( cgiGet( edtVisInsDataHora_Internalname), 0);
                              A403VisInsUsuNome = StringUtil.Upper( cgiGet( edtVisInsUsuNome_Internalname));
                              n403VisInsUsuNome = false;
                              A404VisData = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtVisData_Internalname), 0));
                              A405VisHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtVisHora_Internalname), 0));
                              A406VisDataHora = context.localUtil.CToT( cgiGet( edtVisDataHora_Internalname), 0);
                              A475VisDataFim = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtVisDataFim_Internalname), 0));
                              n475VisDataFim = false;
                              A476VisHoraFim = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtVisHoraFim_Internalname), 0));
                              n476VisHoraFim = false;
                              A477VisDataHoraFim = context.localUtil.CToT( cgiGet( edtVisDataHoraFim_Internalname), 0);
                              n477VisDataHoraFim = false;
                              A416VisTipoNome = StringUtil.Upper( cgiGet( edtVisTipoNome_Internalname));
                              A409VisAssunto = cgiGet( edtVisAssunto_Internalname);
                              cmbVisSituacao.Name = cmbVisSituacao_Internalname;
                              cmbVisSituacao.CurrentValue = cgiGet( cmbVisSituacao_Internalname);
                              A472VisSituacao = cgiGet( cmbVisSituacao_Internalname);
                              A417VisLink = cgiGet( edtVisLink_Internalname);
                              n417VisLink = false;
                              A398VisID = StringUtil.StrToGuid( cgiGet( edtVisID_Internalname));
                              A419VisPaiID = StringUtil.StrToGuid( cgiGet( edtVisPaiID_Internalname));
                              n419VisPaiID = false;
                              A418VisNegID = StringUtil.StrToGuid( cgiGet( edtVisNegID_Internalname));
                              n418VisNegID = false;
                              A422VisNgfSeq = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtVisNgfSeq_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n422VisNgfSeq = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E19562 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E20562 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E21562 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VGRIDACTIONS.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E22562 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Dynamicfiltersoperatorvissituacao Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATORVISSITUACAO"), ",", ".") != Convert.ToDecimal( AV163DynamicFiltersOperatorVisSituacao )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Vissituacao Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vVISSITUACAO"), AV164VisSituacao) != 0 )
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
                        if ( nCmpId == 26 )
                        {
                           OldWcnegociopjgeneral = cgiGet( "W0026");
                           if ( ( StringUtil.Len( OldWcnegociopjgeneral) == 0 ) || ( StringUtil.StrCmp(OldWcnegociopjgeneral, WebComp_Wcnegociopjgeneral_Component) != 0 ) )
                           {
                              WebComp_Wcnegociopjgeneral = getWebComponent(GetType(), "GeneXus.Programs", OldWcnegociopjgeneral, new Object[] {context} );
                              WebComp_Wcnegociopjgeneral.ComponentInit();
                              WebComp_Wcnegociopjgeneral.Name = "OldWcnegociopjgeneral";
                              WebComp_Wcnegociopjgeneral_Component = OldWcnegociopjgeneral;
                           }
                           if ( StringUtil.Len( WebComp_Wcnegociopjgeneral_Component) != 0 )
                           {
                              WebComp_Wcnegociopjgeneral.componentprocess("W0026", "", sEvt);
                           }
                           WebComp_Wcnegociopjgeneral_Component = OldWcnegociopjgeneral;
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

      protected void WE562( )
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

      protected void PA562( )
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
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "core.visitaww.aspx")), "core.visitaww.aspx") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "core.visitaww.aspx")))) ;
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
                  gxfirstwebparm = GetFirstPar( "VisNegID");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV129VisNegID = StringUtil.StrToGuid( gxfirstwebparm);
                     AssignAttri("", false, "AV129VisNegID", AV129VisNegID.ToString());
                     GxWebStd.gx_hidden_field( context, "gxhash_vVISNEGID", GetSecureSignedToken( "", AV129VisNegID, context));
                     if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
                     {
                        AV130VisNgfSeq = (int)(Math.Round(NumberUtil.Val( GetPar( "VisNgfSeq"), "."), 18, MidpointRounding.ToEven));
                        AssignAttri("", false, "AV130VisNgfSeq", StringUtil.LTrimStr( (decimal)(AV130VisNgfSeq), 8, 0));
                        GxWebStd.gx_hidden_field( context, "gxhash_vVISNGFSEQ", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV130VisNgfSeq), "ZZ,ZZZ,ZZ9"), context));
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
               GX_FocusControl = edtavVisnegid_filtro_Internalname;
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
         SubsflControlProps_812( ) ;
         while ( nGXsfl_81_idx <= nRC_GXsfl_81 )
         {
            sendrow_812( ) ;
            nGXsfl_81_idx = ((subGrid_Islastpage==1)&&(nGXsfl_81_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_81_idx+1);
            sGXsfl_81_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_81_idx), 4, 0), 4, "0");
            SubsflControlProps_812( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV163DynamicFiltersOperatorVisSituacao ,
                                       string AV164VisSituacao ,
                                       Guid AV129VisNegID ,
                                       int AV130VisNgfSeq ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV41ColumnsSelector ,
                                       string AV173Pgmname ,
                                       Guid AV143VisNegID_Filtro ,
                                       int AV144VisNgfSeq_Filtro ,
                                       bool AV165VisDel_Filtro ,
                                       DateTime AV57TFVisInsDataHora ,
                                       DateTime AV58TFVisInsDataHora_To ,
                                       string AV64TFVisInsUsuNome ,
                                       string AV65TFVisInsUsuNome_Sel ,
                                       DateTime AV66TFVisData ,
                                       DateTime AV67TFVisData_To ,
                                       DateTime AV71TFVisHora ,
                                       DateTime AV72TFVisHora_To ,
                                       DateTime AV76TFVisDataHora ,
                                       DateTime AV77TFVisDataHora_To ,
                                       DateTime AV146TFVisDataFim ,
                                       DateTime AV147TFVisDataFim_To ,
                                       DateTime AV151TFVisHoraFim ,
                                       DateTime AV152TFVisHoraFim_To ,
                                       DateTime AV156TFVisDataHoraFim ,
                                       DateTime AV157TFVisDataHoraFim_To ,
                                       string AV85TFVisTipoNome ,
                                       string AV86TFVisTipoNome_Sel ,
                                       string AV91TFVisAssunto ,
                                       string AV92TFVisAssunto_Sel ,
                                       GxSimpleCollection<string> AV142TFVisSituacao_Sels ,
                                       string AV93TFVisLink ,
                                       string AV94TFVisLink_Sel ,
                                       short AV14OrderedBy ,
                                       bool AV15OrderedDsc ,
                                       bool AV103IsAuthorized_Update ,
                                       bool AV104IsAuthorized_Delete ,
                                       bool AV128IsAuthorized_RemarcarVisita ,
                                       bool AV108IsAuthorized_Insert )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF562( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_VISID", GetSecureSignedToken( "", A398VisID, context));
         GxWebStd.gx_hidden_field( context, "VISID", A398VisID.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_VISPAIID", GetSecureSignedToken( "", A419VisPaiID, context));
         GxWebStd.gx_hidden_field( context, "VISPAIID", A419VisPaiID.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_VISNEGID", GetSecureSignedToken( "", A418VisNegID, context));
         GxWebStd.gx_hidden_field( context, "VISNEGID", A418VisNegID.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_VISNGFSEQ", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A422VisNgfSeq), "ZZ,ZZZ,ZZ9"), context));
         GxWebStd.gx_hidden_field( context, "VISNGFSEQ", StringUtil.LTrim( StringUtil.NToC( (decimal)(A422VisNgfSeq), 8, 0, ".", "")));
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
         if ( cmbavDynamicfiltersoperatorvissituacao.ItemCount > 0 )
         {
            AV163DynamicFiltersOperatorVisSituacao = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperatorvissituacao.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV163DynamicFiltersOperatorVisSituacao), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV163DynamicFiltersOperatorVisSituacao", StringUtil.LTrimStr( (decimal)(AV163DynamicFiltersOperatorVisSituacao), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperatorvissituacao.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV163DynamicFiltersOperatorVisSituacao), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperatorvissituacao_Internalname, "Values", cmbavDynamicfiltersoperatorvissituacao.ToJavascriptSource(), true);
         }
         if ( cmbavVissituacao.ItemCount > 0 )
         {
            AV164VisSituacao = cmbavVissituacao.getValidValue(AV164VisSituacao);
            AssignAttri("", false, "AV164VisSituacao", AV164VisSituacao);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavVissituacao.CurrentValue = StringUtil.RTrim( AV164VisSituacao);
            AssignProp("", false, cmbavVissituacao_Internalname, "Values", cmbavVissituacao.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF562( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV173Pgmname = "core.VisitaWW";
         edtavNegultitenome_Enabled = 0;
         AssignProp("", false, edtavNegultitenome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNegultitenome_Enabled), 5, 0), true);
      }

      protected void RF562( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 81;
         /* Execute user event: Refresh */
         E20562 ();
         nGXsfl_81_idx = 1;
         sGXsfl_81_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_81_idx), 4, 0), 4, "0");
         SubsflControlProps_812( ) ;
         bGXsfl_81_Refreshing = true;
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
            SubsflControlProps_812( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 A472VisSituacao ,
                                                 AV199Core_visitawwds_26_tfvissituacao_sels ,
                                                 AV178Core_visitawwds_5_dynamicfiltersoperatorvissituacao ,
                                                 AV177Core_visitawwds_4_vissituacao ,
                                                 AV179Core_visitawwds_6_tfvisinsdatahora ,
                                                 AV180Core_visitawwds_7_tfvisinsdatahora_to ,
                                                 AV182Core_visitawwds_9_tfvisinsusunome_sel ,
                                                 AV181Core_visitawwds_8_tfvisinsusunome ,
                                                 AV183Core_visitawwds_10_tfvisdata ,
                                                 AV184Core_visitawwds_11_tfvisdata_to ,
                                                 AV185Core_visitawwds_12_tfvishora ,
                                                 AV186Core_visitawwds_13_tfvishora_to ,
                                                 AV187Core_visitawwds_14_tfvisdatahora ,
                                                 AV188Core_visitawwds_15_tfvisdatahora_to ,
                                                 AV189Core_visitawwds_16_tfvisdatafim ,
                                                 AV190Core_visitawwds_17_tfvisdatafim_to ,
                                                 AV191Core_visitawwds_18_tfvishorafim ,
                                                 AV192Core_visitawwds_19_tfvishorafim_to ,
                                                 AV193Core_visitawwds_20_tfvisdatahorafim ,
                                                 AV194Core_visitawwds_21_tfvisdatahorafim_to ,
                                                 AV196Core_visitawwds_23_tfvistiponome_sel ,
                                                 AV195Core_visitawwds_22_tfvistiponome ,
                                                 AV198Core_visitawwds_25_tfvisassunto_sel ,
                                                 AV197Core_visitawwds_24_tfvisassunto ,
                                                 AV199Core_visitawwds_26_tfvissituacao_sels.Count ,
                                                 AV201Core_visitawwds_28_tfvislink_sel ,
                                                 AV200Core_visitawwds_27_tfvislink ,
                                                 A401VisInsDataHora ,
                                                 A403VisInsUsuNome ,
                                                 A404VisData ,
                                                 A405VisHora ,
                                                 A406VisDataHora ,
                                                 A475VisDataFim ,
                                                 A476VisHoraFim ,
                                                 A477VisDataHoraFim ,
                                                 A416VisTipoNome ,
                                                 A409VisAssunto ,
                                                 A417VisLink ,
                                                 AV14OrderedBy ,
                                                 AV15OrderedDsc ,
                                                 A487VisDel ,
                                                 A418VisNegID ,
                                                 AV129VisNegID ,
                                                 A422VisNgfSeq ,
                                                 AV130VisNgfSeq } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE,
                                                 TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE,
                                                 TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN,
                                                 TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT
                                                 }
            });
            lV181Core_visitawwds_8_tfvisinsusunome = StringUtil.Concat( StringUtil.RTrim( AV181Core_visitawwds_8_tfvisinsusunome), "%", "");
            lV195Core_visitawwds_22_tfvistiponome = StringUtil.Concat( StringUtil.RTrim( AV195Core_visitawwds_22_tfvistiponome), "%", "");
            lV197Core_visitawwds_24_tfvisassunto = StringUtil.Concat( StringUtil.RTrim( AV197Core_visitawwds_24_tfvisassunto), "%", "");
            lV200Core_visitawwds_27_tfvislink = StringUtil.Concat( StringUtil.RTrim( AV200Core_visitawwds_27_tfvislink), "%", "");
            /* Using cursor H00562 */
            pr_default.execute(0, new Object[] {AV129VisNegID, AV130VisNgfSeq, AV177Core_visitawwds_4_vissituacao, AV177Core_visitawwds_4_vissituacao, AV179Core_visitawwds_6_tfvisinsdatahora, AV180Core_visitawwds_7_tfvisinsdatahora_to, lV181Core_visitawwds_8_tfvisinsusunome, AV182Core_visitawwds_9_tfvisinsusunome_sel, AV183Core_visitawwds_10_tfvisdata, AV184Core_visitawwds_11_tfvisdata_to, AV185Core_visitawwds_12_tfvishora, AV186Core_visitawwds_13_tfvishora_to, AV187Core_visitawwds_14_tfvisdatahora, AV188Core_visitawwds_15_tfvisdatahora_to, AV189Core_visitawwds_16_tfvisdatafim, AV190Core_visitawwds_17_tfvisdatafim_to, AV191Core_visitawwds_18_tfvishorafim, AV192Core_visitawwds_19_tfvishorafim_to, AV193Core_visitawwds_20_tfvisdatahorafim, AV194Core_visitawwds_21_tfvisdatahorafim_to, lV195Core_visitawwds_22_tfvistiponome, AV196Core_visitawwds_23_tfvistiponome_sel, lV197Core_visitawwds_24_tfvisassunto, AV198Core_visitawwds_25_tfvisassunto_sel, lV200Core_visitawwds_27_tfvislink, AV201Core_visitawwds_28_tfvislink_sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_81_idx = 1;
            sGXsfl_81_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_81_idx), 4, 0), 4, "0");
            SubsflControlProps_812( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A414VisTipoID = H00562_A414VisTipoID[0];
               A487VisDel = H00562_A487VisDel[0];
               A422VisNgfSeq = H00562_A422VisNgfSeq[0];
               n422VisNgfSeq = H00562_n422VisNgfSeq[0];
               A418VisNegID = H00562_A418VisNegID[0];
               n418VisNegID = H00562_n418VisNegID[0];
               A419VisPaiID = H00562_A419VisPaiID[0];
               n419VisPaiID = H00562_n419VisPaiID[0];
               A398VisID = H00562_A398VisID[0];
               A417VisLink = H00562_A417VisLink[0];
               n417VisLink = H00562_n417VisLink[0];
               A472VisSituacao = H00562_A472VisSituacao[0];
               A409VisAssunto = H00562_A409VisAssunto[0];
               A416VisTipoNome = H00562_A416VisTipoNome[0];
               A477VisDataHoraFim = H00562_A477VisDataHoraFim[0];
               n477VisDataHoraFim = H00562_n477VisDataHoraFim[0];
               A476VisHoraFim = H00562_A476VisHoraFim[0];
               n476VisHoraFim = H00562_n476VisHoraFim[0];
               A475VisDataFim = H00562_A475VisDataFim[0];
               n475VisDataFim = H00562_n475VisDataFim[0];
               A406VisDataHora = H00562_A406VisDataHora[0];
               A405VisHora = H00562_A405VisHora[0];
               A404VisData = H00562_A404VisData[0];
               A403VisInsUsuNome = H00562_A403VisInsUsuNome[0];
               n403VisInsUsuNome = H00562_n403VisInsUsuNome[0];
               A401VisInsDataHora = H00562_A401VisInsDataHora[0];
               A416VisTipoNome = H00562_A416VisTipoNome[0];
               E21562 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 81;
            WB560( ) ;
         }
         bGXsfl_81_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes562( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV173Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV173Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV103IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV103IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV104IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV104IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_REMARCARVISITA", AV128IsAuthorized_RemarcarVisita);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_REMARCARVISITA", GetSecureSignedToken( "", AV128IsAuthorized_RemarcarVisita, context));
         GxWebStd.gx_hidden_field( context, "gxhash_VISID"+"_"+sGXsfl_81_idx, GetSecureSignedToken( sGXsfl_81_idx, A398VisID, context));
         GxWebStd.gx_hidden_field( context, "gxhash_VISPAIID"+"_"+sGXsfl_81_idx, GetSecureSignedToken( sGXsfl_81_idx, A419VisPaiID, context));
         GxWebStd.gx_hidden_field( context, "gxhash_VISNEGID"+"_"+sGXsfl_81_idx, GetSecureSignedToken( sGXsfl_81_idx, A418VisNegID, context));
         GxWebStd.gx_hidden_field( context, "gxhash_VISNGFSEQ"+"_"+sGXsfl_81_idx, GetSecureSignedToken( sGXsfl_81_idx, context.localUtil.Format( (decimal)(A422VisNgfSeq), "ZZ,ZZZ,ZZ9"), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV108IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV108IsAuthorized_Insert, context));
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
         AV174Core_visitawwds_1_visnegid_filtro = AV143VisNegID_Filtro;
         AV175Core_visitawwds_2_visngfseq_filtro = AV144VisNgfSeq_Filtro;
         AV176Core_visitawwds_3_visdel_filtro = AV165VisDel_Filtro;
         AV177Core_visitawwds_4_vissituacao = AV164VisSituacao;
         AV178Core_visitawwds_5_dynamicfiltersoperatorvissituacao = AV163DynamicFiltersOperatorVisSituacao;
         AV179Core_visitawwds_6_tfvisinsdatahora = AV57TFVisInsDataHora;
         AV180Core_visitawwds_7_tfvisinsdatahora_to = AV58TFVisInsDataHora_To;
         AV181Core_visitawwds_8_tfvisinsusunome = AV64TFVisInsUsuNome;
         AV182Core_visitawwds_9_tfvisinsusunome_sel = AV65TFVisInsUsuNome_Sel;
         AV183Core_visitawwds_10_tfvisdata = AV66TFVisData;
         AV184Core_visitawwds_11_tfvisdata_to = AV67TFVisData_To;
         AV185Core_visitawwds_12_tfvishora = AV71TFVisHora;
         AV186Core_visitawwds_13_tfvishora_to = AV72TFVisHora_To;
         AV187Core_visitawwds_14_tfvisdatahora = AV76TFVisDataHora;
         AV188Core_visitawwds_15_tfvisdatahora_to = AV77TFVisDataHora_To;
         AV189Core_visitawwds_16_tfvisdatafim = AV146TFVisDataFim;
         AV190Core_visitawwds_17_tfvisdatafim_to = AV147TFVisDataFim_To;
         AV191Core_visitawwds_18_tfvishorafim = AV151TFVisHoraFim;
         AV192Core_visitawwds_19_tfvishorafim_to = AV152TFVisHoraFim_To;
         AV193Core_visitawwds_20_tfvisdatahorafim = AV156TFVisDataHoraFim;
         AV194Core_visitawwds_21_tfvisdatahorafim_to = AV157TFVisDataHoraFim_To;
         AV195Core_visitawwds_22_tfvistiponome = AV85TFVisTipoNome;
         AV196Core_visitawwds_23_tfvistiponome_sel = AV86TFVisTipoNome_Sel;
         AV197Core_visitawwds_24_tfvisassunto = AV91TFVisAssunto;
         AV198Core_visitawwds_25_tfvisassunto_sel = AV92TFVisAssunto_Sel;
         AV199Core_visitawwds_26_tfvissituacao_sels = AV142TFVisSituacao_Sels;
         AV200Core_visitawwds_27_tfvislink = AV93TFVisLink;
         AV201Core_visitawwds_28_tfvislink_sel = AV94TFVisLink_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A472VisSituacao ,
                                              AV199Core_visitawwds_26_tfvissituacao_sels ,
                                              AV178Core_visitawwds_5_dynamicfiltersoperatorvissituacao ,
                                              AV177Core_visitawwds_4_vissituacao ,
                                              AV179Core_visitawwds_6_tfvisinsdatahora ,
                                              AV180Core_visitawwds_7_tfvisinsdatahora_to ,
                                              AV182Core_visitawwds_9_tfvisinsusunome_sel ,
                                              AV181Core_visitawwds_8_tfvisinsusunome ,
                                              AV183Core_visitawwds_10_tfvisdata ,
                                              AV184Core_visitawwds_11_tfvisdata_to ,
                                              AV185Core_visitawwds_12_tfvishora ,
                                              AV186Core_visitawwds_13_tfvishora_to ,
                                              AV187Core_visitawwds_14_tfvisdatahora ,
                                              AV188Core_visitawwds_15_tfvisdatahora_to ,
                                              AV189Core_visitawwds_16_tfvisdatafim ,
                                              AV190Core_visitawwds_17_tfvisdatafim_to ,
                                              AV191Core_visitawwds_18_tfvishorafim ,
                                              AV192Core_visitawwds_19_tfvishorafim_to ,
                                              AV193Core_visitawwds_20_tfvisdatahorafim ,
                                              AV194Core_visitawwds_21_tfvisdatahorafim_to ,
                                              AV196Core_visitawwds_23_tfvistiponome_sel ,
                                              AV195Core_visitawwds_22_tfvistiponome ,
                                              AV198Core_visitawwds_25_tfvisassunto_sel ,
                                              AV197Core_visitawwds_24_tfvisassunto ,
                                              AV199Core_visitawwds_26_tfvissituacao_sels.Count ,
                                              AV201Core_visitawwds_28_tfvislink_sel ,
                                              AV200Core_visitawwds_27_tfvislink ,
                                              A401VisInsDataHora ,
                                              A403VisInsUsuNome ,
                                              A404VisData ,
                                              A405VisHora ,
                                              A406VisDataHora ,
                                              A475VisDataFim ,
                                              A476VisHoraFim ,
                                              A477VisDataHoraFim ,
                                              A416VisTipoNome ,
                                              A409VisAssunto ,
                                              A417VisLink ,
                                              AV14OrderedBy ,
                                              AV15OrderedDsc ,
                                              A487VisDel ,
                                              A418VisNegID ,
                                              AV129VisNegID ,
                                              A422VisNgfSeq ,
                                              AV130VisNgfSeq } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT
                                              }
         });
         lV181Core_visitawwds_8_tfvisinsusunome = StringUtil.Concat( StringUtil.RTrim( AV181Core_visitawwds_8_tfvisinsusunome), "%", "");
         lV195Core_visitawwds_22_tfvistiponome = StringUtil.Concat( StringUtil.RTrim( AV195Core_visitawwds_22_tfvistiponome), "%", "");
         lV197Core_visitawwds_24_tfvisassunto = StringUtil.Concat( StringUtil.RTrim( AV197Core_visitawwds_24_tfvisassunto), "%", "");
         lV200Core_visitawwds_27_tfvislink = StringUtil.Concat( StringUtil.RTrim( AV200Core_visitawwds_27_tfvislink), "%", "");
         /* Using cursor H00563 */
         pr_default.execute(1, new Object[] {AV129VisNegID, AV130VisNgfSeq, AV177Core_visitawwds_4_vissituacao, AV177Core_visitawwds_4_vissituacao, AV179Core_visitawwds_6_tfvisinsdatahora, AV180Core_visitawwds_7_tfvisinsdatahora_to, lV181Core_visitawwds_8_tfvisinsusunome, AV182Core_visitawwds_9_tfvisinsusunome_sel, AV183Core_visitawwds_10_tfvisdata, AV184Core_visitawwds_11_tfvisdata_to, AV185Core_visitawwds_12_tfvishora, AV186Core_visitawwds_13_tfvishora_to, AV187Core_visitawwds_14_tfvisdatahora, AV188Core_visitawwds_15_tfvisdatahora_to, AV189Core_visitawwds_16_tfvisdatafim, AV190Core_visitawwds_17_tfvisdatafim_to, AV191Core_visitawwds_18_tfvishorafim, AV192Core_visitawwds_19_tfvishorafim_to, AV193Core_visitawwds_20_tfvisdatahorafim, AV194Core_visitawwds_21_tfvisdatahorafim_to, lV195Core_visitawwds_22_tfvistiponome, AV196Core_visitawwds_23_tfvistiponome_sel, lV197Core_visitawwds_24_tfvisassunto, AV198Core_visitawwds_25_tfvisassunto_sel, lV200Core_visitawwds_27_tfvislink, AV201Core_visitawwds_28_tfvislink_sel});
         GRID_nRecordCount = H00563_AGRID_nRecordCount[0];
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
         AV174Core_visitawwds_1_visnegid_filtro = AV143VisNegID_Filtro;
         AV175Core_visitawwds_2_visngfseq_filtro = AV144VisNgfSeq_Filtro;
         AV176Core_visitawwds_3_visdel_filtro = AV165VisDel_Filtro;
         AV177Core_visitawwds_4_vissituacao = AV164VisSituacao;
         AV178Core_visitawwds_5_dynamicfiltersoperatorvissituacao = AV163DynamicFiltersOperatorVisSituacao;
         AV179Core_visitawwds_6_tfvisinsdatahora = AV57TFVisInsDataHora;
         AV180Core_visitawwds_7_tfvisinsdatahora_to = AV58TFVisInsDataHora_To;
         AV181Core_visitawwds_8_tfvisinsusunome = AV64TFVisInsUsuNome;
         AV182Core_visitawwds_9_tfvisinsusunome_sel = AV65TFVisInsUsuNome_Sel;
         AV183Core_visitawwds_10_tfvisdata = AV66TFVisData;
         AV184Core_visitawwds_11_tfvisdata_to = AV67TFVisData_To;
         AV185Core_visitawwds_12_tfvishora = AV71TFVisHora;
         AV186Core_visitawwds_13_tfvishora_to = AV72TFVisHora_To;
         AV187Core_visitawwds_14_tfvisdatahora = AV76TFVisDataHora;
         AV188Core_visitawwds_15_tfvisdatahora_to = AV77TFVisDataHora_To;
         AV189Core_visitawwds_16_tfvisdatafim = AV146TFVisDataFim;
         AV190Core_visitawwds_17_tfvisdatafim_to = AV147TFVisDataFim_To;
         AV191Core_visitawwds_18_tfvishorafim = AV151TFVisHoraFim;
         AV192Core_visitawwds_19_tfvishorafim_to = AV152TFVisHoraFim_To;
         AV193Core_visitawwds_20_tfvisdatahorafim = AV156TFVisDataHoraFim;
         AV194Core_visitawwds_21_tfvisdatahorafim_to = AV157TFVisDataHoraFim_To;
         AV195Core_visitawwds_22_tfvistiponome = AV85TFVisTipoNome;
         AV196Core_visitawwds_23_tfvistiponome_sel = AV86TFVisTipoNome_Sel;
         AV197Core_visitawwds_24_tfvisassunto = AV91TFVisAssunto;
         AV198Core_visitawwds_25_tfvisassunto_sel = AV92TFVisAssunto_Sel;
         AV199Core_visitawwds_26_tfvissituacao_sels = AV142TFVisSituacao_Sels;
         AV200Core_visitawwds_27_tfvislink = AV93TFVisLink;
         AV201Core_visitawwds_28_tfvislink_sel = AV94TFVisLink_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV163DynamicFiltersOperatorVisSituacao, AV164VisSituacao, AV129VisNegID, AV130VisNgfSeq, AV41ColumnsSelector, AV173Pgmname, AV143VisNegID_Filtro, AV144VisNgfSeq_Filtro, AV165VisDel_Filtro, AV57TFVisInsDataHora, AV58TFVisInsDataHora_To, AV64TFVisInsUsuNome, AV65TFVisInsUsuNome_Sel, AV66TFVisData, AV67TFVisData_To, AV71TFVisHora, AV72TFVisHora_To, AV76TFVisDataHora, AV77TFVisDataHora_To, AV146TFVisDataFim, AV147TFVisDataFim_To, AV151TFVisHoraFim, AV152TFVisHoraFim_To, AV156TFVisDataHoraFim, AV157TFVisDataHoraFim_To, AV85TFVisTipoNome, AV86TFVisTipoNome_Sel, AV91TFVisAssunto, AV92TFVisAssunto_Sel, AV142TFVisSituacao_Sels, AV93TFVisLink, AV94TFVisLink_Sel, AV14OrderedBy, AV15OrderedDsc, AV103IsAuthorized_Update, AV104IsAuthorized_Delete, AV128IsAuthorized_RemarcarVisita, AV108IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV174Core_visitawwds_1_visnegid_filtro = AV143VisNegID_Filtro;
         AV175Core_visitawwds_2_visngfseq_filtro = AV144VisNgfSeq_Filtro;
         AV176Core_visitawwds_3_visdel_filtro = AV165VisDel_Filtro;
         AV177Core_visitawwds_4_vissituacao = AV164VisSituacao;
         AV178Core_visitawwds_5_dynamicfiltersoperatorvissituacao = AV163DynamicFiltersOperatorVisSituacao;
         AV179Core_visitawwds_6_tfvisinsdatahora = AV57TFVisInsDataHora;
         AV180Core_visitawwds_7_tfvisinsdatahora_to = AV58TFVisInsDataHora_To;
         AV181Core_visitawwds_8_tfvisinsusunome = AV64TFVisInsUsuNome;
         AV182Core_visitawwds_9_tfvisinsusunome_sel = AV65TFVisInsUsuNome_Sel;
         AV183Core_visitawwds_10_tfvisdata = AV66TFVisData;
         AV184Core_visitawwds_11_tfvisdata_to = AV67TFVisData_To;
         AV185Core_visitawwds_12_tfvishora = AV71TFVisHora;
         AV186Core_visitawwds_13_tfvishora_to = AV72TFVisHora_To;
         AV187Core_visitawwds_14_tfvisdatahora = AV76TFVisDataHora;
         AV188Core_visitawwds_15_tfvisdatahora_to = AV77TFVisDataHora_To;
         AV189Core_visitawwds_16_tfvisdatafim = AV146TFVisDataFim;
         AV190Core_visitawwds_17_tfvisdatafim_to = AV147TFVisDataFim_To;
         AV191Core_visitawwds_18_tfvishorafim = AV151TFVisHoraFim;
         AV192Core_visitawwds_19_tfvishorafim_to = AV152TFVisHoraFim_To;
         AV193Core_visitawwds_20_tfvisdatahorafim = AV156TFVisDataHoraFim;
         AV194Core_visitawwds_21_tfvisdatahorafim_to = AV157TFVisDataHoraFim_To;
         AV195Core_visitawwds_22_tfvistiponome = AV85TFVisTipoNome;
         AV196Core_visitawwds_23_tfvistiponome_sel = AV86TFVisTipoNome_Sel;
         AV197Core_visitawwds_24_tfvisassunto = AV91TFVisAssunto;
         AV198Core_visitawwds_25_tfvisassunto_sel = AV92TFVisAssunto_Sel;
         AV199Core_visitawwds_26_tfvissituacao_sels = AV142TFVisSituacao_Sels;
         AV200Core_visitawwds_27_tfvislink = AV93TFVisLink;
         AV201Core_visitawwds_28_tfvislink_sel = AV94TFVisLink_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV163DynamicFiltersOperatorVisSituacao, AV164VisSituacao, AV129VisNegID, AV130VisNgfSeq, AV41ColumnsSelector, AV173Pgmname, AV143VisNegID_Filtro, AV144VisNgfSeq_Filtro, AV165VisDel_Filtro, AV57TFVisInsDataHora, AV58TFVisInsDataHora_To, AV64TFVisInsUsuNome, AV65TFVisInsUsuNome_Sel, AV66TFVisData, AV67TFVisData_To, AV71TFVisHora, AV72TFVisHora_To, AV76TFVisDataHora, AV77TFVisDataHora_To, AV146TFVisDataFim, AV147TFVisDataFim_To, AV151TFVisHoraFim, AV152TFVisHoraFim_To, AV156TFVisDataHoraFim, AV157TFVisDataHoraFim_To, AV85TFVisTipoNome, AV86TFVisTipoNome_Sel, AV91TFVisAssunto, AV92TFVisAssunto_Sel, AV142TFVisSituacao_Sels, AV93TFVisLink, AV94TFVisLink_Sel, AV14OrderedBy, AV15OrderedDsc, AV103IsAuthorized_Update, AV104IsAuthorized_Delete, AV128IsAuthorized_RemarcarVisita, AV108IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV174Core_visitawwds_1_visnegid_filtro = AV143VisNegID_Filtro;
         AV175Core_visitawwds_2_visngfseq_filtro = AV144VisNgfSeq_Filtro;
         AV176Core_visitawwds_3_visdel_filtro = AV165VisDel_Filtro;
         AV177Core_visitawwds_4_vissituacao = AV164VisSituacao;
         AV178Core_visitawwds_5_dynamicfiltersoperatorvissituacao = AV163DynamicFiltersOperatorVisSituacao;
         AV179Core_visitawwds_6_tfvisinsdatahora = AV57TFVisInsDataHora;
         AV180Core_visitawwds_7_tfvisinsdatahora_to = AV58TFVisInsDataHora_To;
         AV181Core_visitawwds_8_tfvisinsusunome = AV64TFVisInsUsuNome;
         AV182Core_visitawwds_9_tfvisinsusunome_sel = AV65TFVisInsUsuNome_Sel;
         AV183Core_visitawwds_10_tfvisdata = AV66TFVisData;
         AV184Core_visitawwds_11_tfvisdata_to = AV67TFVisData_To;
         AV185Core_visitawwds_12_tfvishora = AV71TFVisHora;
         AV186Core_visitawwds_13_tfvishora_to = AV72TFVisHora_To;
         AV187Core_visitawwds_14_tfvisdatahora = AV76TFVisDataHora;
         AV188Core_visitawwds_15_tfvisdatahora_to = AV77TFVisDataHora_To;
         AV189Core_visitawwds_16_tfvisdatafim = AV146TFVisDataFim;
         AV190Core_visitawwds_17_tfvisdatafim_to = AV147TFVisDataFim_To;
         AV191Core_visitawwds_18_tfvishorafim = AV151TFVisHoraFim;
         AV192Core_visitawwds_19_tfvishorafim_to = AV152TFVisHoraFim_To;
         AV193Core_visitawwds_20_tfvisdatahorafim = AV156TFVisDataHoraFim;
         AV194Core_visitawwds_21_tfvisdatahorafim_to = AV157TFVisDataHoraFim_To;
         AV195Core_visitawwds_22_tfvistiponome = AV85TFVisTipoNome;
         AV196Core_visitawwds_23_tfvistiponome_sel = AV86TFVisTipoNome_Sel;
         AV197Core_visitawwds_24_tfvisassunto = AV91TFVisAssunto;
         AV198Core_visitawwds_25_tfvisassunto_sel = AV92TFVisAssunto_Sel;
         AV199Core_visitawwds_26_tfvissituacao_sels = AV142TFVisSituacao_Sels;
         AV200Core_visitawwds_27_tfvislink = AV93TFVisLink;
         AV201Core_visitawwds_28_tfvislink_sel = AV94TFVisLink_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV163DynamicFiltersOperatorVisSituacao, AV164VisSituacao, AV129VisNegID, AV130VisNgfSeq, AV41ColumnsSelector, AV173Pgmname, AV143VisNegID_Filtro, AV144VisNgfSeq_Filtro, AV165VisDel_Filtro, AV57TFVisInsDataHora, AV58TFVisInsDataHora_To, AV64TFVisInsUsuNome, AV65TFVisInsUsuNome_Sel, AV66TFVisData, AV67TFVisData_To, AV71TFVisHora, AV72TFVisHora_To, AV76TFVisDataHora, AV77TFVisDataHora_To, AV146TFVisDataFim, AV147TFVisDataFim_To, AV151TFVisHoraFim, AV152TFVisHoraFim_To, AV156TFVisDataHoraFim, AV157TFVisDataHoraFim_To, AV85TFVisTipoNome, AV86TFVisTipoNome_Sel, AV91TFVisAssunto, AV92TFVisAssunto_Sel, AV142TFVisSituacao_Sels, AV93TFVisLink, AV94TFVisLink_Sel, AV14OrderedBy, AV15OrderedDsc, AV103IsAuthorized_Update, AV104IsAuthorized_Delete, AV128IsAuthorized_RemarcarVisita, AV108IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV174Core_visitawwds_1_visnegid_filtro = AV143VisNegID_Filtro;
         AV175Core_visitawwds_2_visngfseq_filtro = AV144VisNgfSeq_Filtro;
         AV176Core_visitawwds_3_visdel_filtro = AV165VisDel_Filtro;
         AV177Core_visitawwds_4_vissituacao = AV164VisSituacao;
         AV178Core_visitawwds_5_dynamicfiltersoperatorvissituacao = AV163DynamicFiltersOperatorVisSituacao;
         AV179Core_visitawwds_6_tfvisinsdatahora = AV57TFVisInsDataHora;
         AV180Core_visitawwds_7_tfvisinsdatahora_to = AV58TFVisInsDataHora_To;
         AV181Core_visitawwds_8_tfvisinsusunome = AV64TFVisInsUsuNome;
         AV182Core_visitawwds_9_tfvisinsusunome_sel = AV65TFVisInsUsuNome_Sel;
         AV183Core_visitawwds_10_tfvisdata = AV66TFVisData;
         AV184Core_visitawwds_11_tfvisdata_to = AV67TFVisData_To;
         AV185Core_visitawwds_12_tfvishora = AV71TFVisHora;
         AV186Core_visitawwds_13_tfvishora_to = AV72TFVisHora_To;
         AV187Core_visitawwds_14_tfvisdatahora = AV76TFVisDataHora;
         AV188Core_visitawwds_15_tfvisdatahora_to = AV77TFVisDataHora_To;
         AV189Core_visitawwds_16_tfvisdatafim = AV146TFVisDataFim;
         AV190Core_visitawwds_17_tfvisdatafim_to = AV147TFVisDataFim_To;
         AV191Core_visitawwds_18_tfvishorafim = AV151TFVisHoraFim;
         AV192Core_visitawwds_19_tfvishorafim_to = AV152TFVisHoraFim_To;
         AV193Core_visitawwds_20_tfvisdatahorafim = AV156TFVisDataHoraFim;
         AV194Core_visitawwds_21_tfvisdatahorafim_to = AV157TFVisDataHoraFim_To;
         AV195Core_visitawwds_22_tfvistiponome = AV85TFVisTipoNome;
         AV196Core_visitawwds_23_tfvistiponome_sel = AV86TFVisTipoNome_Sel;
         AV197Core_visitawwds_24_tfvisassunto = AV91TFVisAssunto;
         AV198Core_visitawwds_25_tfvisassunto_sel = AV92TFVisAssunto_Sel;
         AV199Core_visitawwds_26_tfvissituacao_sels = AV142TFVisSituacao_Sels;
         AV200Core_visitawwds_27_tfvislink = AV93TFVisLink;
         AV201Core_visitawwds_28_tfvislink_sel = AV94TFVisLink_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV163DynamicFiltersOperatorVisSituacao, AV164VisSituacao, AV129VisNegID, AV130VisNgfSeq, AV41ColumnsSelector, AV173Pgmname, AV143VisNegID_Filtro, AV144VisNgfSeq_Filtro, AV165VisDel_Filtro, AV57TFVisInsDataHora, AV58TFVisInsDataHora_To, AV64TFVisInsUsuNome, AV65TFVisInsUsuNome_Sel, AV66TFVisData, AV67TFVisData_To, AV71TFVisHora, AV72TFVisHora_To, AV76TFVisDataHora, AV77TFVisDataHora_To, AV146TFVisDataFim, AV147TFVisDataFim_To, AV151TFVisHoraFim, AV152TFVisHoraFim_To, AV156TFVisDataHoraFim, AV157TFVisDataHoraFim_To, AV85TFVisTipoNome, AV86TFVisTipoNome_Sel, AV91TFVisAssunto, AV92TFVisAssunto_Sel, AV142TFVisSituacao_Sels, AV93TFVisLink, AV94TFVisLink_Sel, AV14OrderedBy, AV15OrderedDsc, AV103IsAuthorized_Update, AV104IsAuthorized_Delete, AV128IsAuthorized_RemarcarVisita, AV108IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV174Core_visitawwds_1_visnegid_filtro = AV143VisNegID_Filtro;
         AV175Core_visitawwds_2_visngfseq_filtro = AV144VisNgfSeq_Filtro;
         AV176Core_visitawwds_3_visdel_filtro = AV165VisDel_Filtro;
         AV177Core_visitawwds_4_vissituacao = AV164VisSituacao;
         AV178Core_visitawwds_5_dynamicfiltersoperatorvissituacao = AV163DynamicFiltersOperatorVisSituacao;
         AV179Core_visitawwds_6_tfvisinsdatahora = AV57TFVisInsDataHora;
         AV180Core_visitawwds_7_tfvisinsdatahora_to = AV58TFVisInsDataHora_To;
         AV181Core_visitawwds_8_tfvisinsusunome = AV64TFVisInsUsuNome;
         AV182Core_visitawwds_9_tfvisinsusunome_sel = AV65TFVisInsUsuNome_Sel;
         AV183Core_visitawwds_10_tfvisdata = AV66TFVisData;
         AV184Core_visitawwds_11_tfvisdata_to = AV67TFVisData_To;
         AV185Core_visitawwds_12_tfvishora = AV71TFVisHora;
         AV186Core_visitawwds_13_tfvishora_to = AV72TFVisHora_To;
         AV187Core_visitawwds_14_tfvisdatahora = AV76TFVisDataHora;
         AV188Core_visitawwds_15_tfvisdatahora_to = AV77TFVisDataHora_To;
         AV189Core_visitawwds_16_tfvisdatafim = AV146TFVisDataFim;
         AV190Core_visitawwds_17_tfvisdatafim_to = AV147TFVisDataFim_To;
         AV191Core_visitawwds_18_tfvishorafim = AV151TFVisHoraFim;
         AV192Core_visitawwds_19_tfvishorafim_to = AV152TFVisHoraFim_To;
         AV193Core_visitawwds_20_tfvisdatahorafim = AV156TFVisDataHoraFim;
         AV194Core_visitawwds_21_tfvisdatahorafim_to = AV157TFVisDataHoraFim_To;
         AV195Core_visitawwds_22_tfvistiponome = AV85TFVisTipoNome;
         AV196Core_visitawwds_23_tfvistiponome_sel = AV86TFVisTipoNome_Sel;
         AV197Core_visitawwds_24_tfvisassunto = AV91TFVisAssunto;
         AV198Core_visitawwds_25_tfvisassunto_sel = AV92TFVisAssunto_Sel;
         AV199Core_visitawwds_26_tfvissituacao_sels = AV142TFVisSituacao_Sels;
         AV200Core_visitawwds_27_tfvislink = AV93TFVisLink;
         AV201Core_visitawwds_28_tfvislink_sel = AV94TFVisLink_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV163DynamicFiltersOperatorVisSituacao, AV164VisSituacao, AV129VisNegID, AV130VisNgfSeq, AV41ColumnsSelector, AV173Pgmname, AV143VisNegID_Filtro, AV144VisNgfSeq_Filtro, AV165VisDel_Filtro, AV57TFVisInsDataHora, AV58TFVisInsDataHora_To, AV64TFVisInsUsuNome, AV65TFVisInsUsuNome_Sel, AV66TFVisData, AV67TFVisData_To, AV71TFVisHora, AV72TFVisHora_To, AV76TFVisDataHora, AV77TFVisDataHora_To, AV146TFVisDataFim, AV147TFVisDataFim_To, AV151TFVisHoraFim, AV152TFVisHoraFim_To, AV156TFVisDataHoraFim, AV157TFVisDataHoraFim_To, AV85TFVisTipoNome, AV86TFVisTipoNome_Sel, AV91TFVisAssunto, AV92TFVisAssunto_Sel, AV142TFVisSituacao_Sels, AV93TFVisLink, AV94TFVisLink_Sel, AV14OrderedBy, AV15OrderedDsc, AV103IsAuthorized_Update, AV104IsAuthorized_Delete, AV128IsAuthorized_RemarcarVisita, AV108IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV173Pgmname = "core.VisitaWW";
         edtavNegultitenome_Enabled = 0;
         AssignProp("", false, edtavNegultitenome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNegultitenome_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP560( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E19562 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vAGEXPORTDATA"), AV106AGExportData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV95DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vCOLUMNSSELECTOR"), AV41ColumnsSelector);
            /* Read saved values. */
            nRC_GXsfl_81 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_81"), ",", "."), 18, MidpointRounding.ToEven));
            AV99GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ",", "."), 18, MidpointRounding.ToEven));
            AV100GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ",", "."), 18, MidpointRounding.ToEven));
            AV101GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            AV59DDO_VisInsDataHoraAuxDate = context.localUtil.CToD( cgiGet( "vDDO_VISINSDATAHORAAUXDATE"), 0);
            AV60DDO_VisInsDataHoraAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_VISINSDATAHORAAUXDATETO"), 0);
            AV68DDO_VisDataAuxDate = context.localUtil.CToD( cgiGet( "vDDO_VISDATAAUXDATE"), 0);
            AV69DDO_VisDataAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_VISDATAAUXDATETO"), 0);
            AV73DDO_VisHoraAuxDate = context.localUtil.CToD( cgiGet( "vDDO_VISHORAAUXDATE"), 0);
            AV74DDO_VisHoraAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_VISHORAAUXDATETO"), 0);
            AV78DDO_VisDataHoraAuxDate = context.localUtil.CToD( cgiGet( "vDDO_VISDATAHORAAUXDATE"), 0);
            AV79DDO_VisDataHoraAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_VISDATAHORAAUXDATETO"), 0);
            AV148DDO_VisDataFimAuxDate = context.localUtil.CToD( cgiGet( "vDDO_VISDATAFIMAUXDATE"), 0);
            AV149DDO_VisDataFimAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_VISDATAFIMAUXDATETO"), 0);
            AV153DDO_VisHoraFimAuxDate = context.localUtil.CToD( cgiGet( "vDDO_VISHORAFIMAUXDATE"), 0);
            AV154DDO_VisHoraFimAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_VISHORAFIMAUXDATETO"), 0);
            AV158DDO_VisDataHoraFimAuxDate = context.localUtil.CToD( cgiGet( "vDDO_VISDATAHORAFIMAUXDATE"), 0);
            AV159DDO_VisDataHoraFimAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_VISDATAHORAFIMAUXDATETO"), 0);
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
            Ddo_grid_Allowmultipleselection = cgiGet( "DDO_GRID_Allowmultipleselection");
            Ddo_grid_Datalistfixedvalues = cgiGet( "DDO_GRID_Datalistfixedvalues");
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
            Dvelop_confirmpanel_delete_Title = cgiGet( "DVELOP_CONFIRMPANEL_DELETE_Title");
            Dvelop_confirmpanel_delete_Confirmationtext = cgiGet( "DVELOP_CONFIRMPANEL_DELETE_Confirmationtext");
            Dvelop_confirmpanel_delete_Yesbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_DELETE_Yesbuttoncaption");
            Dvelop_confirmpanel_delete_Nobuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_DELETE_Nobuttoncaption");
            Dvelop_confirmpanel_delete_Cancelbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_DELETE_Cancelbuttoncaption");
            Dvelop_confirmpanel_delete_Yesbuttonposition = cgiGet( "DVELOP_CONFIRMPANEL_DELETE_Yesbuttonposition");
            Dvelop_confirmpanel_delete_Confirmtype = cgiGet( "DVELOP_CONFIRMPANEL_DELETE_Confirmtype");
            Grid_titlescategories_Gridinternalname = cgiGet( "GRID_TITLESCATEGORIES_Gridinternalname");
            Grid_titlescategories_Gridtitlescategories = cgiGet( "GRID_TITLESCATEGORIES_Gridtitlescategories");
            Grid_empowerer_Gridinternalname = cgiGet( "GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hascategories = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hascategories"));
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
            Dvelop_confirmpanel_delete_Result = cgiGet( "DVELOP_CONFIRMPANEL_DELETE_Result");
            Ddo_agexport_Activeeventkey = cgiGet( "DDO_AGEXPORT_Activeeventkey");
            /* Read variables values. */
            if ( StringUtil.StrCmp(cgiGet( edtavVisnegid_filtro_Internalname), "") == 0 )
            {
               AV143VisNegID_Filtro = Guid.Empty;
               AssignAttri("", false, "AV143VisNegID_Filtro", AV143VisNegID_Filtro.ToString());
            }
            else
            {
               try
               {
                  AV143VisNegID_Filtro = StringUtil.StrToGuid( cgiGet( edtavVisnegid_filtro_Internalname));
                  AssignAttri("", false, "AV143VisNegID_Filtro", AV143VisNegID_Filtro.ToString());
               }
               catch ( Exception  )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "vVISNEGID_FILTRO");
                  GX_FocusControl = edtavVisnegid_filtro_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
               }
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavVisngfseq_filtro_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavVisngfseq_filtro_Internalname), ",", ".") > Convert.ToDecimal( 99999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vVISNGFSEQ_FILTRO");
               GX_FocusControl = edtavVisngfseq_filtro_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV144VisNgfSeq_Filtro = 0;
               AssignAttri("", false, "AV144VisNgfSeq_Filtro", StringUtil.LTrimStr( (decimal)(AV144VisNgfSeq_Filtro), 8, 0));
            }
            else
            {
               AV144VisNgfSeq_Filtro = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavVisngfseq_filtro_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV144VisNgfSeq_Filtro", StringUtil.LTrimStr( (decimal)(AV144VisNgfSeq_Filtro), 8, 0));
            }
            AV165VisDel_Filtro = StringUtil.StrToBool( cgiGet( edtavVisdel_filtro_Internalname));
            AssignAttri("", false, "AV165VisDel_Filtro", AV165VisDel_Filtro);
            cmbavDynamicfiltersoperatorvissituacao.Name = cmbavDynamicfiltersoperatorvissituacao_Internalname;
            cmbavDynamicfiltersoperatorvissituacao.CurrentValue = cgiGet( cmbavDynamicfiltersoperatorvissituacao_Internalname);
            AV163DynamicFiltersOperatorVisSituacao = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperatorvissituacao_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV163DynamicFiltersOperatorVisSituacao", StringUtil.LTrimStr( (decimal)(AV163DynamicFiltersOperatorVisSituacao), 4, 0));
            cmbavVissituacao.Name = cmbavVissituacao_Internalname;
            cmbavVissituacao.CurrentValue = cgiGet( cmbavVissituacao_Internalname);
            AV164VisSituacao = cgiGet( cmbavVissituacao_Internalname);
            AssignAttri("", false, "AV164VisSituacao", AV164VisSituacao);
            AV161NegUltIteNome = StringUtil.Upper( cgiGet( edtavNegultitenome_Internalname));
            AssignAttri("", false, "AV161NegUltIteNome", AV161NegUltIteNome);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavNegultngfseq_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavNegultngfseq_Internalname), ",", ".") > Convert.ToDecimal( 99999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vNEGULTNGFSEQ");
               GX_FocusControl = edtavNegultngfseq_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV162NegUltNgfSeq = 0;
               AssignAttri("", false, "AV162NegUltNgfSeq", StringUtil.LTrimStr( (decimal)(AV162NegUltNgfSeq), 8, 0));
            }
            else
            {
               AV162NegUltNgfSeq = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavNegultngfseq_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV162NegUltNgfSeq", StringUtil.LTrimStr( (decimal)(AV162NegUltNgfSeq), 8, 0));
            }
            AV61DDO_VisInsDataHoraAuxDateText = cgiGet( edtavDdo_visinsdatahoraauxdatetext_Internalname);
            AssignAttri("", false, "AV61DDO_VisInsDataHoraAuxDateText", AV61DDO_VisInsDataHoraAuxDateText);
            AV70DDO_VisDataAuxDateText = cgiGet( edtavDdo_visdataauxdatetext_Internalname);
            AssignAttri("", false, "AV70DDO_VisDataAuxDateText", AV70DDO_VisDataAuxDateText);
            AV75DDO_VisHoraAuxDateText = cgiGet( edtavDdo_vishoraauxdatetext_Internalname);
            AssignAttri("", false, "AV75DDO_VisHoraAuxDateText", AV75DDO_VisHoraAuxDateText);
            AV80DDO_VisDataHoraAuxDateText = cgiGet( edtavDdo_visdatahoraauxdatetext_Internalname);
            AssignAttri("", false, "AV80DDO_VisDataHoraAuxDateText", AV80DDO_VisDataHoraAuxDateText);
            AV150DDO_VisDataFimAuxDateText = cgiGet( edtavDdo_visdatafimauxdatetext_Internalname);
            AssignAttri("", false, "AV150DDO_VisDataFimAuxDateText", AV150DDO_VisDataFimAuxDateText);
            AV155DDO_VisHoraFimAuxDateText = cgiGet( edtavDdo_vishorafimauxdatetext_Internalname);
            AssignAttri("", false, "AV155DDO_VisHoraFimAuxDateText", AV155DDO_VisHoraFimAuxDateText);
            AV160DDO_VisDataHoraFimAuxDateText = cgiGet( edtavDdo_visdatahorafimauxdatetext_Internalname);
            AssignAttri("", false, "AV160DDO_VisDataHoraFimAuxDateText", AV160DDO_VisDataHoraFimAuxDateText);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATORVISSITUACAO"), ",", ".") != Convert.ToDecimal( AV163DynamicFiltersOperatorVisSituacao )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vVISSITUACAO"), AV164VisSituacao) != 0 )
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
         E19562 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E19562( )
      {
         /* Start Routine */
         returnInSub = false;
         this.executeUsercontrolMethod("", false, "TFVISDATAHORAFIM_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_visdatahorafimauxdatetext_Internalname});
         this.executeUsercontrolMethod("", false, "TFVISHORAFIM_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_vishorafimauxdatetext_Internalname});
         this.executeUsercontrolMethod("", false, "TFVISDATAFIM_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_visdatafimauxdatetext_Internalname});
         this.executeUsercontrolMethod("", false, "TFVISDATAHORA_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_visdatahoraauxdatetext_Internalname});
         this.executeUsercontrolMethod("", false, "TFVISHORA_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_vishoraauxdatetext_Internalname});
         this.executeUsercontrolMethod("", false, "TFVISDATA_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_visdataauxdatetext_Internalname});
         this.executeUsercontrolMethod("", false, "TFVISINSDATAHORA_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_visinsdatahoraauxdatetext_Internalname});
         edtavNegultngfseq_Visible = 0;
         AssignProp("", false, edtavNegultngfseq_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavNegultngfseq_Visible), 5, 0), true);
         edtavVisnegid_Visible = 0;
         AssignProp("", false, edtavVisnegid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavVisnegid_Visible), 5, 0), true);
         edtavVisngfseq_Visible = 0;
         AssignProp("", false, edtavVisngfseq_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavVisngfseq_Visible), 5, 0), true);
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         Ddo_gridcolumnsselector_Gridinternalname = subGrid_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "GridInternalName", Ddo_gridcolumnsselector_Gridinternalname);
         Grid_titlescategories_Gridinternalname = subGrid_Internalname;
         ucGrid_titlescategories.SendProperty(context, "", false, Grid_titlescategories_Internalname, "GridInternalName", Grid_titlescategories_Gridinternalname);
         Ddo_agexport_Titlecontrolidtoreplace = bttBtnagexport_Internalname;
         ucDdo_agexport.SendProperty(context, "", false, Ddo_agexport_Internalname, "TitleControlIdToReplace", Ddo_agexport_Titlecontrolidtoreplace);
         AV106AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV107AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV107AGExportDataItem.gxTpr_Title = "Excel";
         AV107AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "da69a816-fd11-445b-8aaf-1a2f7f1acc93", "", context.GetTheme( ))));
         AV107AGExportDataItem.gxTpr_Eventkey = "Export";
         AV107AGExportDataItem.gxTpr_Isdivider = false;
         AV106AGExportData.Add(AV107AGExportDataItem, 0);
         AV107AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV107AGExportDataItem.gxTpr_Title = "PDF";
         AV107AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "776fb79c-a0a1-4302-b5e5-d773dbe1a297", "", context.GetTheme( ))));
         AV107AGExportDataItem.gxTpr_Eventkey = "ExportReport";
         AV107AGExportDataItem.gxTpr_Isdivider = false;
         AV106AGExportData.Add(AV107AGExportDataItem, 0);
         Ddc_subscriptions_Titlecontrolidtoreplace = bttBtnsubscriptions_Internalname;
         ucDdc_subscriptions.SendProperty(context, "", false, Ddc_subscriptions_Internalname, "TitleControlIdToReplace", Ddc_subscriptions_Titlecontrolidtoreplace);
         AV164VisSituacao = "";
         AssignAttri("", false, "AV164VisSituacao", AV164VisSituacao);
         AV96GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV97GAMErrors);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Ddo_grid_Gamoauthtoken = AV96GAMSession.gxTpr_Token;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GAMOAuthToken", Ddo_grid_Gamoauthtoken);
         Form.Caption = "Visitas do Cliente";
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S122 ();
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
            S132 ();
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
            WebComp_Wcnegociopjgeneral.componentprepare(new Object[] {(string)"W0026",(string)"",(Guid)AV129VisNegID});
            WebComp_Wcnegociopjgeneral.componentbind(new Object[] {(string)"vVISNEGID"});
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV95DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV95DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = bttBtneditcolumns_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "TitleControlIdToReplace", Ddo_gridcolumnsselector_Titlecontrolidtoreplace);
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
         if ( StringUtil.StrCmp(AV8HTTPRequest.Method, "GET") == 0 )
         {
            AV163DynamicFiltersOperatorVisSituacao = 1;
            AssignAttri("", false, "AV163DynamicFiltersOperatorVisSituacao", StringUtil.LTrimStr( (decimal)(AV163DynamicFiltersOperatorVisSituacao), 4, 0));
            AV164VisSituacao = "REM";
            AssignAttri("", false, "AV164VisSituacao", AV164VisSituacao);
         }
         AV162NegUltNgfSeq = 0;
         AssignAttri("", false, "AV162NegUltNgfSeq", StringUtil.LTrimStr( (decimal)(AV162NegUltNgfSeq), 8, 0));
         AV161NegUltIteNome = "";
         AssignAttri("", false, "AV161NegUltIteNome", AV161NegUltIteNome);
         /* Using cursor H00564 */
         pr_default.execute(2, new Object[] {AV129VisNegID});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A345NegID = H00564_A345NegID[0];
            A362NegAssunto = H00564_A362NegAssunto[0];
            A356NegCodigo = H00564_A356NegCodigo[0];
            A421NegUltIteNome = H00564_A421NegUltIteNome[0];
            Dvpanel_tableoportunidade_Title = StringUtil.StringReplace( StringUtil.StringReplace( Dvpanel_tableoportunidade_Title, "[!VISNEGCODIGO!]", StringUtil.Trim( StringUtil.Str( (decimal)(A356NegCodigo), 12, 0))), "[!VISNEGASSUNTO!]", StringUtil.Trim( A362NegAssunto));
            ucDvpanel_tableoportunidade.SendProperty(context, "", false, Dvpanel_tableoportunidade_Internalname, "Title", Dvpanel_tableoportunidade_Title);
            AV161NegUltIteNome = StringUtil.Trim( A421NegUltIteNome);
            AssignAttri("", false, "AV161NegUltIteNome", AV161NegUltIteNome);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(2);
      }

      protected void E20562( )
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
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( StringUtil.StrCmp(AV43Session.Get("core.VisitaWWColumnsSelector"), "") != 0 )
         {
            AV39ColumnsSelectorXML = AV43Session.Get("core.VisitaWWColumnsSelector");
            AV41ColumnsSelector.FromXml(AV39ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S162 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         edtVisInsDataHora_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV41ColumnsSelector.gxTpr_Columns.Item(1)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtVisInsDataHora_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtVisInsDataHora_Visible), 5, 0), !bGXsfl_81_Refreshing);
         edtVisInsUsuNome_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV41ColumnsSelector.gxTpr_Columns.Item(2)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtVisInsUsuNome_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtVisInsUsuNome_Visible), 5, 0), !bGXsfl_81_Refreshing);
         edtVisData_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV41ColumnsSelector.gxTpr_Columns.Item(3)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtVisData_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtVisData_Visible), 5, 0), !bGXsfl_81_Refreshing);
         edtVisHora_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV41ColumnsSelector.gxTpr_Columns.Item(4)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtVisHora_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtVisHora_Visible), 5, 0), !bGXsfl_81_Refreshing);
         edtVisDataHora_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV41ColumnsSelector.gxTpr_Columns.Item(5)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtVisDataHora_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtVisDataHora_Visible), 5, 0), !bGXsfl_81_Refreshing);
         edtVisDataFim_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV41ColumnsSelector.gxTpr_Columns.Item(6)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtVisDataFim_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtVisDataFim_Visible), 5, 0), !bGXsfl_81_Refreshing);
         edtVisHoraFim_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV41ColumnsSelector.gxTpr_Columns.Item(7)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtVisHoraFim_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtVisHoraFim_Visible), 5, 0), !bGXsfl_81_Refreshing);
         edtVisDataHoraFim_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV41ColumnsSelector.gxTpr_Columns.Item(8)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtVisDataHoraFim_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtVisDataHoraFim_Visible), 5, 0), !bGXsfl_81_Refreshing);
         edtVisTipoNome_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV41ColumnsSelector.gxTpr_Columns.Item(9)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtVisTipoNome_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtVisTipoNome_Visible), 5, 0), !bGXsfl_81_Refreshing);
         edtVisAssunto_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV41ColumnsSelector.gxTpr_Columns.Item(10)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtVisAssunto_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtVisAssunto_Visible), 5, 0), !bGXsfl_81_Refreshing);
         cmbVisSituacao.Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV41ColumnsSelector.gxTpr_Columns.Item(11)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, cmbVisSituacao_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbVisSituacao.Visible), 5, 0), !bGXsfl_81_Refreshing);
         edtVisLink_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV41ColumnsSelector.gxTpr_Columns.Item(12)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtVisLink_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtVisLink_Visible), 5, 0), !bGXsfl_81_Refreshing);
         AV99GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV99GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV99GridCurrentPage), 10, 0));
         AV100GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV100GridPageCount", StringUtil.LTrimStr( (decimal)(AV100GridPageCount), 10, 0));
         GXt_char2 = AV101GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV173Pgmname, out  GXt_char2) ;
         AV101GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV101GridAppliedFilters", AV101GridAppliedFilters);
         AV174Core_visitawwds_1_visnegid_filtro = AV143VisNegID_Filtro;
         AV175Core_visitawwds_2_visngfseq_filtro = AV144VisNgfSeq_Filtro;
         AV176Core_visitawwds_3_visdel_filtro = AV165VisDel_Filtro;
         AV177Core_visitawwds_4_vissituacao = AV164VisSituacao;
         AV178Core_visitawwds_5_dynamicfiltersoperatorvissituacao = AV163DynamicFiltersOperatorVisSituacao;
         AV179Core_visitawwds_6_tfvisinsdatahora = AV57TFVisInsDataHora;
         AV180Core_visitawwds_7_tfvisinsdatahora_to = AV58TFVisInsDataHora_To;
         AV181Core_visitawwds_8_tfvisinsusunome = AV64TFVisInsUsuNome;
         AV182Core_visitawwds_9_tfvisinsusunome_sel = AV65TFVisInsUsuNome_Sel;
         AV183Core_visitawwds_10_tfvisdata = AV66TFVisData;
         AV184Core_visitawwds_11_tfvisdata_to = AV67TFVisData_To;
         AV185Core_visitawwds_12_tfvishora = AV71TFVisHora;
         AV186Core_visitawwds_13_tfvishora_to = AV72TFVisHora_To;
         AV187Core_visitawwds_14_tfvisdatahora = AV76TFVisDataHora;
         AV188Core_visitawwds_15_tfvisdatahora_to = AV77TFVisDataHora_To;
         AV189Core_visitawwds_16_tfvisdatafim = AV146TFVisDataFim;
         AV190Core_visitawwds_17_tfvisdatafim_to = AV147TFVisDataFim_To;
         AV191Core_visitawwds_18_tfvishorafim = AV151TFVisHoraFim;
         AV192Core_visitawwds_19_tfvishorafim_to = AV152TFVisHoraFim_To;
         AV193Core_visitawwds_20_tfvisdatahorafim = AV156TFVisDataHoraFim;
         AV194Core_visitawwds_21_tfvisdatahorafim_to = AV157TFVisDataHoraFim_To;
         AV195Core_visitawwds_22_tfvistiponome = AV85TFVisTipoNome;
         AV196Core_visitawwds_23_tfvistiponome_sel = AV86TFVisTipoNome_Sel;
         AV197Core_visitawwds_24_tfvisassunto = AV91TFVisAssunto;
         AV198Core_visitawwds_25_tfvisassunto_sel = AV92TFVisAssunto_Sel;
         AV199Core_visitawwds_26_tfvissituacao_sels = AV142TFVisSituacao_Sels;
         AV200Core_visitawwds_27_tfvislink = AV93TFVisLink;
         AV201Core_visitawwds_28_tfvislink_sel = AV94TFVisLink_Sel;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ColumnsSelector", AV41ColumnsSelector);
      }

      protected void E11562( )
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
            AV98PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV98PageToGo) ;
         }
      }

      protected void E12562( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E15562( )
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
            S132 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            subgrid_firstpage( ) ;
         }
         else if ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#Filter#>") == 0 )
         {
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "VisInsDataHora") == 0 )
            {
               AV57TFVisInsDataHora = context.localUtil.CToT( Ddo_grid_Filteredtext_get, 2);
               AssignAttri("", false, "AV57TFVisInsDataHora", context.localUtil.TToC( AV57TFVisInsDataHora, 10, 12, 0, 3, "/", ":", " "));
               AV58TFVisInsDataHora_To = context.localUtil.CToT( Ddo_grid_Filteredtextto_get, 2);
               AssignAttri("", false, "AV58TFVisInsDataHora_To", context.localUtil.TToC( AV58TFVisInsDataHora_To, 10, 12, 0, 3, "/", ":", " "));
               if ( ! (DateTime.MinValue==AV58TFVisInsDataHora_To) )
               {
                  AV58TFVisInsDataHora_To = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( AV58TFVisInsDataHora_To)), (short)(DateTimeUtil.Month( AV58TFVisInsDataHora_To)), (short)(DateTimeUtil.Day( AV58TFVisInsDataHora_To)), 23, 59, 59);
                  AssignAttri("", false, "AV58TFVisInsDataHora_To", context.localUtil.TToC( AV58TFVisInsDataHora_To, 10, 12, 0, 3, "/", ":", " "));
               }
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "VisInsUsuNome") == 0 )
            {
               AV64TFVisInsUsuNome = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV64TFVisInsUsuNome", AV64TFVisInsUsuNome);
               AV65TFVisInsUsuNome_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV65TFVisInsUsuNome_Sel", AV65TFVisInsUsuNome_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "VisData") == 0 )
            {
               AV66TFVisData = context.localUtil.CToD( Ddo_grid_Filteredtext_get, 2);
               AssignAttri("", false, "AV66TFVisData", context.localUtil.Format(AV66TFVisData, "99/99/99"));
               AV67TFVisData_To = context.localUtil.CToD( Ddo_grid_Filteredtextto_get, 2);
               AssignAttri("", false, "AV67TFVisData_To", context.localUtil.Format(AV67TFVisData_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "VisHora") == 0 )
            {
               AV71TFVisHora = DateTimeUtil.ResetDate(context.localUtil.CToT( Ddo_grid_Filteredtext_get, 2));
               AssignAttri("", false, "AV71TFVisHora", context.localUtil.TToC( AV71TFVisHora, 0, 5, 0, 3, "/", ":", " "));
               AV72TFVisHora_To = DateTimeUtil.ResetDate(context.localUtil.CToT( Ddo_grid_Filteredtextto_get, 2));
               AssignAttri("", false, "AV72TFVisHora_To", context.localUtil.TToC( AV72TFVisHora_To, 0, 5, 0, 3, "/", ":", " "));
               if ( ! (DateTime.MinValue==AV72TFVisHora_To) )
               {
                  AV72TFVisHora_To = DateTimeUtil.ResetDate(context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( AV72TFVisHora_To)), (short)(DateTimeUtil.Month( AV72TFVisHora_To)), (short)(DateTimeUtil.Day( AV72TFVisHora_To)), 23, 59, 59));
                  AssignAttri("", false, "AV72TFVisHora_To", context.localUtil.TToC( AV72TFVisHora_To, 0, 5, 0, 3, "/", ":", " "));
               }
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "VisDataHora") == 0 )
            {
               AV76TFVisDataHora = context.localUtil.CToT( Ddo_grid_Filteredtext_get, 2);
               AssignAttri("", false, "AV76TFVisDataHora", context.localUtil.TToC( AV76TFVisDataHora, 10, 5, 0, 3, "/", ":", " "));
               AV77TFVisDataHora_To = context.localUtil.CToT( Ddo_grid_Filteredtextto_get, 2);
               AssignAttri("", false, "AV77TFVisDataHora_To", context.localUtil.TToC( AV77TFVisDataHora_To, 10, 5, 0, 3, "/", ":", " "));
               if ( ! (DateTime.MinValue==AV77TFVisDataHora_To) )
               {
                  AV77TFVisDataHora_To = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( AV77TFVisDataHora_To)), (short)(DateTimeUtil.Month( AV77TFVisDataHora_To)), (short)(DateTimeUtil.Day( AV77TFVisDataHora_To)), 23, 59, 59);
                  AssignAttri("", false, "AV77TFVisDataHora_To", context.localUtil.TToC( AV77TFVisDataHora_To, 10, 5, 0, 3, "/", ":", " "));
               }
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "VisDataFim") == 0 )
            {
               AV146TFVisDataFim = context.localUtil.CToD( Ddo_grid_Filteredtext_get, 2);
               AssignAttri("", false, "AV146TFVisDataFim", context.localUtil.Format(AV146TFVisDataFim, "99/99/99"));
               AV147TFVisDataFim_To = context.localUtil.CToD( Ddo_grid_Filteredtextto_get, 2);
               AssignAttri("", false, "AV147TFVisDataFim_To", context.localUtil.Format(AV147TFVisDataFim_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "VisHoraFim") == 0 )
            {
               AV151TFVisHoraFim = DateTimeUtil.ResetDate(context.localUtil.CToT( Ddo_grid_Filteredtext_get, 2));
               AssignAttri("", false, "AV151TFVisHoraFim", context.localUtil.TToC( AV151TFVisHoraFim, 0, 5, 0, 3, "/", ":", " "));
               AV152TFVisHoraFim_To = DateTimeUtil.ResetDate(context.localUtil.CToT( Ddo_grid_Filteredtextto_get, 2));
               AssignAttri("", false, "AV152TFVisHoraFim_To", context.localUtil.TToC( AV152TFVisHoraFim_To, 0, 5, 0, 3, "/", ":", " "));
               if ( ! (DateTime.MinValue==AV152TFVisHoraFim_To) )
               {
                  AV152TFVisHoraFim_To = DateTimeUtil.ResetDate(context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( AV152TFVisHoraFim_To)), (short)(DateTimeUtil.Month( AV152TFVisHoraFim_To)), (short)(DateTimeUtil.Day( AV152TFVisHoraFim_To)), 23, 59, 59));
                  AssignAttri("", false, "AV152TFVisHoraFim_To", context.localUtil.TToC( AV152TFVisHoraFim_To, 0, 5, 0, 3, "/", ":", " "));
               }
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "VisDataHoraFim") == 0 )
            {
               AV156TFVisDataHoraFim = context.localUtil.CToT( Ddo_grid_Filteredtext_get, 2);
               AssignAttri("", false, "AV156TFVisDataHoraFim", context.localUtil.TToC( AV156TFVisDataHoraFim, 10, 5, 0, 3, "/", ":", " "));
               AV157TFVisDataHoraFim_To = context.localUtil.CToT( Ddo_grid_Filteredtextto_get, 2);
               AssignAttri("", false, "AV157TFVisDataHoraFim_To", context.localUtil.TToC( AV157TFVisDataHoraFim_To, 10, 5, 0, 3, "/", ":", " "));
               if ( ! (DateTime.MinValue==AV157TFVisDataHoraFim_To) )
               {
                  AV157TFVisDataHoraFim_To = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( AV157TFVisDataHoraFim_To)), (short)(DateTimeUtil.Month( AV157TFVisDataHoraFim_To)), (short)(DateTimeUtil.Day( AV157TFVisDataHoraFim_To)), 23, 59, 59);
                  AssignAttri("", false, "AV157TFVisDataHoraFim_To", context.localUtil.TToC( AV157TFVisDataHoraFim_To, 10, 5, 0, 3, "/", ":", " "));
               }
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "VisTipoNome") == 0 )
            {
               AV85TFVisTipoNome = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV85TFVisTipoNome", AV85TFVisTipoNome);
               AV86TFVisTipoNome_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV86TFVisTipoNome_Sel", AV86TFVisTipoNome_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "VisAssunto") == 0 )
            {
               AV91TFVisAssunto = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV91TFVisAssunto", AV91TFVisAssunto);
               AV92TFVisAssunto_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV92TFVisAssunto_Sel", AV92TFVisAssunto_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "VisSituacao") == 0 )
            {
               AV141TFVisSituacao_SelsJson = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV141TFVisSituacao_SelsJson", AV141TFVisSituacao_SelsJson);
               AV142TFVisSituacao_Sels.FromJSonString(AV141TFVisSituacao_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "VisLink") == 0 )
            {
               AV93TFVisLink = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV93TFVisLink", AV93TFVisLink);
               AV94TFVisLink_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV94TFVisLink_Sel", AV94TFVisLink_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV142TFVisSituacao_Sels", AV142TFVisSituacao_Sels);
      }

      private void E21562( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         cmbavGridactions.removeAllItems();
         cmbavGridactions.addItem("0", ";fa fa-bars", 0);
         if ( AV103IsAuthorized_Update )
         {
            if ( A406VisDataHora > DateTimeUtil.Now( context) )
            {
               cmbavGridactions.addItem("1", StringUtil.Format( "%1;%2", "Alterar", "fa fa-pen", "", "", "", "", "", "", ""), 0);
            }
         }
         if ( AV104IsAuthorized_Delete )
         {
            if ( A406VisDataHora > DateTimeUtil.Now( context) )
            {
               cmbavGridactions.addItem("2", StringUtil.Format( "%1;%2", "Excluir", "fa fa-times", "", "", "", "", "", "", ""), 0);
            }
         }
         if ( AV128IsAuthorized_RemarcarVisita )
         {
            if ( StringUtil.StrCmp(A472VisSituacao, "PEN") == 0 )
            {
               cmbavGridactions.addItem("3", StringUtil.Format( "%1;%2", "Remarcar Visita", "far fa-calendar-plus", "", "", "", "", "", "", ""), 0);
            }
         }
         if ( cmbavGridactions.ItemCount == 1 )
         {
            cmbavGridactions_Class = "Invisible";
         }
         else
         {
            cmbavGridactions_Class = "ConvertToDDO";
         }
         edtVisLink_Linktarget = "_blank";
         edtVisLink_Link = A417VisLink;
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 81;
         }
         sendrow_812( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_81_Refreshing )
         {
            DoAjaxLoad(81, GridRow);
         }
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV102GridActions), 4, 0));
      }

      protected void E16562( )
      {
         /* Ddo_gridcolumnsselector_Oncolumnschanged Routine */
         returnInSub = false;
         AV39ColumnsSelectorXML = Ddo_gridcolumnsselector_Columnsselectorvalues;
         AV41ColumnsSelector.FromJSonString(AV39ColumnsSelectorXML, null);
         new GeneXus.Programs.wwpbaseobjects.savecolumnsselectorstate(context ).execute(  "core.VisitaWWColumnsSelector",  (String.IsNullOrEmpty(StringUtil.RTrim( AV39ColumnsSelectorXML)) ? "" : AV41ColumnsSelector.ToXml(false, true, "", ""))) ;
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ColumnsSelector", AV41ColumnsSelector);
      }

      protected void E22562( )
      {
         /* Gridactions_Click Routine */
         returnInSub = false;
         if ( AV102GridActions == 1 )
         {
            /* Execute user subroutine: 'DO UPDATE' */
            S172 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV102GridActions == 2 )
         {
            /* Execute user subroutine: 'DO DELETE' */
            S182 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV102GridActions == 3 )
         {
            /* Execute user subroutine: 'DO REMARCARVISITA' */
            S192 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         AV102GridActions = 0;
         AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV102GridActions), 4, 0));
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV102GridActions), 4, 0));
         AssignProp("", false, cmbavGridactions_Internalname, "Values", cmbavGridactions.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ColumnsSelector", AV41ColumnsSelector);
      }

      protected void E17562( )
      {
         /* Dvelop_confirmpanel_delete_Close Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Dvelop_confirmpanel_delete_Result, "Yes") == 0 )
         {
            /* Execute user subroutine: 'DO ACTION DELETE' */
            S202 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ColumnsSelector", AV41ColumnsSelector);
      }

      protected void E18562( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         if ( AV108IsAuthorized_Insert )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "core.visita.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(Guid.Empty.ToString()) + "," + UrlEncode(Guid.Empty.ToString()) + "," + UrlEncode(AV129VisNegID.ToString()) + "," + UrlEncode(StringUtil.LTrimStr(AV130VisNgfSeq,8,0));
            CallWebObject(formatLink("core.visita.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem("A ação não encontra-se disponível");
            context.DoAjaxRefresh();
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ColumnsSelector", AV41ColumnsSelector);
      }

      protected void E13562( )
      {
         /* Ddo_agexport_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_agexport_Activeeventkey, "Export") == 0 )
         {
            /* Execute user subroutine: 'DOEXPORT' */
            S212 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(Ddo_agexport_Activeeventkey, "ExportReport") == 0 )
         {
            /* Execute user subroutine: 'DOEXPORTREPORT' */
            S222 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /*  Sending Event outputs  */
      }

      protected void E14562( )
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
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"W0121",(string)"",(string)"Visita",(short)1,(string)"",(string)""});
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

      protected void S132( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV14OrderedBy), 4, 0))+":"+(AV15OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S162( )
      {
         /* 'INITIALIZECOLUMNSSELECTOR' Routine */
         returnInSub = false;
         AV41ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV41ColumnsSelector,  "VisInsDataHora",  "",  "Incluído em",  false,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV41ColumnsSelector,  "VisInsUsuNome",  "",  "Incluído por",  false,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV41ColumnsSelector,  "VisData",  "Início",  "Data",  false,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV41ColumnsSelector,  "VisHora",  "Início",  "Hora",  false,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV41ColumnsSelector,  "VisDataHora",  "Início",  "Data/Hora",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV41ColumnsSelector,  "VisDataFim",  "Término",  "Data",  false,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV41ColumnsSelector,  "VisHoraFim",  "Término",  "Hora",  false,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV41ColumnsSelector,  "VisDataHoraFim",  "Término",  "Data/Hora",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV41ColumnsSelector,  "VisTipoNome",  "",  "Tipo",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV41ColumnsSelector,  "VisAssunto",  "",  "Assunto",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV41ColumnsSelector,  "VisSituacao",  "",  "Situação",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV41ColumnsSelector,  "VisLink",  "",  "Link de Acesso",  true,  "") ;
         GXt_char2 = AV40UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "core.VisitaWWColumnsSelector", out  GXt_char2) ;
         AV40UserCustomValue = GXt_char2;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV40UserCustomValue)) ) )
         {
            AV42ColumnsSelectorAux.FromXml(AV40UserCustomValue, null, "", "");
            new GeneXus.Programs.wwpbaseobjects.wwp_columnselector_updatecolumns(context ).execute( ref  AV42ColumnsSelectorAux, ref  AV41ColumnsSelector) ;
         }
      }

      protected void S142( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         GXt_boolean3 = AV103IsAuthorized_Update;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "visita_Update", out  GXt_boolean3) ;
         AV103IsAuthorized_Update = GXt_boolean3;
         AssignAttri("", false, "AV103IsAuthorized_Update", AV103IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV103IsAuthorized_Update, context));
         GXt_boolean3 = AV104IsAuthorized_Delete;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "visita_Delete", out  GXt_boolean3) ;
         AV104IsAuthorized_Delete = GXt_boolean3;
         AssignAttri("", false, "AV104IsAuthorized_Delete", AV104IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV104IsAuthorized_Delete, context));
         GXt_boolean3 = AV128IsAuthorized_RemarcarVisita;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "visita_Execute", out  GXt_boolean3) ;
         AV128IsAuthorized_RemarcarVisita = GXt_boolean3;
         AssignAttri("", false, "AV128IsAuthorized_RemarcarVisita", AV128IsAuthorized_RemarcarVisita);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_REMARCARVISITA", GetSecureSignedToken( "", AV128IsAuthorized_RemarcarVisita, context));
         GXt_boolean3 = AV108IsAuthorized_Insert;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "visita_Insert", out  GXt_boolean3) ;
         AV108IsAuthorized_Insert = GXt_boolean3;
         AssignAttri("", false, "AV108IsAuthorized_Insert", AV108IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV108IsAuthorized_Insert, context));
         if ( ! ( AV108IsAuthorized_Insert ) )
         {
            bttBtninsert_Visible = 0;
            AssignProp("", false, bttBtninsert_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtninsert_Visible), 5, 0), true);
         }
         if ( ! ( new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_hassubscriptionstodisplay(context).executeUdp(  "Visita",  1) ) )
         {
            bttBtnsubscriptions_Visible = 0;
            AssignProp("", false, bttBtnsubscriptions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnsubscriptions_Visible), 5, 0), true);
         }
      }

      protected void S172( )
      {
         /* 'DO UPDATE' Routine */
         returnInSub = false;
         if ( AV103IsAuthorized_Update )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "core.visita.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(A398VisID.ToString()) + "," + UrlEncode(Guid.Empty.ToString()) + "," + UrlEncode(A418VisNegID.ToString()) + "," + UrlEncode(StringUtil.LTrimStr(A422VisNgfSeq,8,0));
            CallWebObject(formatLink("core.visita.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem("A ação não encontra-se disponível");
            context.DoAjaxRefresh();
         }
      }

      protected void S182( )
      {
         /* 'DO DELETE' Routine */
         returnInSub = false;
         if ( AV104IsAuthorized_Delete )
         {
            AV166VisID_Selected = A398VisID;
            AssignAttri("", false, "AV166VisID_Selected", AV166VisID_Selected.ToString());
            AV167VisNegID_Selected = A418VisNegID;
            AssignAttri("", false, "AV167VisNegID_Selected", AV167VisNegID_Selected.ToString());
            AV168VisNgfSeq_Selected = A422VisNgfSeq;
            AssignAttri("", false, "AV168VisNgfSeq_Selected", StringUtil.LTrimStr( (decimal)(AV168VisNgfSeq_Selected), 8, 0));
            this.executeUsercontrolMethod("", false, "DVELOP_CONFIRMPANEL_DELETEContainer", "Confirm", "", new Object[] {});
         }
         else
         {
            GX_msglist.addItem("A ação não encontra-se disponível");
            context.DoAjaxRefresh();
         }
      }

      protected void S202( )
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
            GXEncryptionTmp = "core.visita.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(AV166VisID_Selected.ToString()) + "," + UrlEncode(Guid.Empty.ToString()) + "," + UrlEncode(AV167VisNegID_Selected.ToString()) + "," + UrlEncode(StringUtil.LTrimStr(AV168VisNgfSeq_Selected,8,0));
            CallWebObject(formatLink("core.visita.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         AV169sdtVisita = new GeneXus.Programs.core.SdtsdtVisita(context);
         AV169sdtVisita.gxTpr_Visid = AV166VisID_Selected;
         new GeneXus.Programs.core.prcvisitaobterdadosindividual(context ).execute( ref  AV169sdtVisita) ;
         AV169sdtVisita.gxTpr_Visdel = true;
         new GeneXus.Programs.core.prcvisitamanterdados(context ).execute(  AV169sdtVisita,  true, out  AV170Messages) ;
         AV202GXV1 = 1;
         while ( AV202GXV1 <= AV170Messages.Count )
         {
            AV171Message = ((GeneXus.Utils.SdtMessages_Message)AV170Messages.Item(AV202GXV1));
            GX_msglist.addItem(AV171Message.gxTpr_Description);
            AV202GXV1 = (int)(AV202GXV1+1);
         }
         gxgrGrid_refresh( subGrid_Rows, AV163DynamicFiltersOperatorVisSituacao, AV164VisSituacao, AV129VisNegID, AV130VisNgfSeq, AV41ColumnsSelector, AV173Pgmname, AV143VisNegID_Filtro, AV144VisNgfSeq_Filtro, AV165VisDel_Filtro, AV57TFVisInsDataHora, AV58TFVisInsDataHora_To, AV64TFVisInsUsuNome, AV65TFVisInsUsuNome_Sel, AV66TFVisData, AV67TFVisData_To, AV71TFVisHora, AV72TFVisHora_To, AV76TFVisDataHora, AV77TFVisDataHora_To, AV146TFVisDataFim, AV147TFVisDataFim_To, AV151TFVisHoraFim, AV152TFVisHoraFim_To, AV156TFVisDataHoraFim, AV157TFVisDataHoraFim_To, AV85TFVisTipoNome, AV86TFVisTipoNome_Sel, AV91TFVisAssunto, AV92TFVisAssunto_Sel, AV142TFVisSituacao_Sels, AV93TFVisLink, AV94TFVisLink_Sel, AV14OrderedBy, AV15OrderedDsc, AV103IsAuthorized_Update, AV104IsAuthorized_Delete, AV128IsAuthorized_RemarcarVisita, AV108IsAuthorized_Insert) ;
      }

      protected void S192( )
      {
         /* 'DO REMARCARVISITA' Routine */
         returnInSub = false;
         if ( AV128IsAuthorized_RemarcarVisita )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "core.visita.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(Guid.Empty.ToString()) + "," + UrlEncode((((Guid.Empty==A419VisPaiID)||(Guid.Empty==A419VisPaiID)) ? A398VisID : A419VisPaiID).ToString()) + "," + UrlEncode(A418VisNegID.ToString()) + "," + UrlEncode(StringUtil.LTrimStr(A422VisNgfSeq,8,0));
            CallWebObject(formatLink("core.visita.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem("A ação não encontra-se disponível");
            context.DoAjaxRefresh();
         }
      }

      protected void S122( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV43Session.Get(AV173Pgmname+"GridState"), "") == 0 )
         {
            AV11GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV173Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV11GridState.FromXml(AV43Session.Get(AV173Pgmname+"GridState"), null, "", "");
         }
         AV14OrderedBy = AV11GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV14OrderedBy", StringUtil.LTrimStr( (decimal)(AV14OrderedBy), 4, 0));
         AV15OrderedDsc = AV11GridState.gxTpr_Ordereddsc;
         AssignAttri("", false, "AV15OrderedDsc", AV15OrderedDsc);
         /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV203GXV2 = 1;
         while ( AV203GXV2 <= AV11GridState.gxTpr_Filtervalues.Count )
         {
            AV12GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV11GridState.gxTpr_Filtervalues.Item(AV203GXV2));
            if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "VISNEGID_FILTRO") == 0 )
            {
               AV143VisNegID_Filtro = StringUtil.StrToGuid( AV12GridStateFilterValue.gxTpr_Value);
               AssignAttri("", false, "AV143VisNegID_Filtro", AV143VisNegID_Filtro.ToString());
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "VISNGFSEQ_FILTRO") == 0 )
            {
               AV144VisNgfSeq_Filtro = (int)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV144VisNgfSeq_Filtro", StringUtil.LTrimStr( (decimal)(AV144VisNgfSeq_Filtro), 8, 0));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "VISDEL_FILTRO") == 0 )
            {
               AV165VisDel_Filtro = BooleanUtil.Val( AV12GridStateFilterValue.gxTpr_Value);
               AssignAttri("", false, "AV165VisDel_Filtro", AV165VisDel_Filtro);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "VISSITUACAO") == 0 )
            {
               AV164VisSituacao = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV164VisSituacao", AV164VisSituacao);
               AV163DynamicFiltersOperatorVisSituacao = AV12GridStateFilterValue.gxTpr_Operator;
               AssignAttri("", false, "AV163DynamicFiltersOperatorVisSituacao", StringUtil.LTrimStr( (decimal)(AV163DynamicFiltersOperatorVisSituacao), 4, 0));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFVISINSDATAHORA") == 0 )
            {
               AV57TFVisInsDataHora = context.localUtil.CToT( AV12GridStateFilterValue.gxTpr_Value, 2);
               AssignAttri("", false, "AV57TFVisInsDataHora", context.localUtil.TToC( AV57TFVisInsDataHora, 10, 12, 0, 3, "/", ":", " "));
               AV58TFVisInsDataHora_To = context.localUtil.CToT( AV12GridStateFilterValue.gxTpr_Valueto, 2);
               AssignAttri("", false, "AV58TFVisInsDataHora_To", context.localUtil.TToC( AV58TFVisInsDataHora_To, 10, 12, 0, 3, "/", ":", " "));
               AV59DDO_VisInsDataHoraAuxDate = DateTimeUtil.ResetTime(AV57TFVisInsDataHora);
               AssignAttri("", false, "AV59DDO_VisInsDataHoraAuxDate", context.localUtil.Format(AV59DDO_VisInsDataHoraAuxDate, "99/99/9999"));
               AV60DDO_VisInsDataHoraAuxDateTo = DateTimeUtil.ResetTime(AV58TFVisInsDataHora_To);
               AssignAttri("", false, "AV60DDO_VisInsDataHoraAuxDateTo", context.localUtil.Format(AV60DDO_VisInsDataHoraAuxDateTo, "99/99/9999"));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFVISINSUSUNOME") == 0 )
            {
               AV64TFVisInsUsuNome = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV64TFVisInsUsuNome", AV64TFVisInsUsuNome);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFVISINSUSUNOME_SEL") == 0 )
            {
               AV65TFVisInsUsuNome_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV65TFVisInsUsuNome_Sel", AV65TFVisInsUsuNome_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFVISDATA") == 0 )
            {
               AV66TFVisData = context.localUtil.CToD( AV12GridStateFilterValue.gxTpr_Value, 2);
               AssignAttri("", false, "AV66TFVisData", context.localUtil.Format(AV66TFVisData, "99/99/99"));
               AV67TFVisData_To = context.localUtil.CToD( AV12GridStateFilterValue.gxTpr_Valueto, 2);
               AssignAttri("", false, "AV67TFVisData_To", context.localUtil.Format(AV67TFVisData_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFVISHORA") == 0 )
            {
               AV71TFVisHora = DateTimeUtil.ResetDate(context.localUtil.CToT( AV12GridStateFilterValue.gxTpr_Value, 2));
               AssignAttri("", false, "AV71TFVisHora", context.localUtil.TToC( AV71TFVisHora, 0, 5, 0, 3, "/", ":", " "));
               AV72TFVisHora_To = DateTimeUtil.ResetDate(context.localUtil.CToT( AV12GridStateFilterValue.gxTpr_Valueto, 2));
               AssignAttri("", false, "AV72TFVisHora_To", context.localUtil.TToC( AV72TFVisHora_To, 0, 5, 0, 3, "/", ":", " "));
               AV73DDO_VisHoraAuxDate = DateTimeUtil.ResetTime(AV71TFVisHora);
               AssignAttri("", false, "AV73DDO_VisHoraAuxDate", context.localUtil.Format(AV73DDO_VisHoraAuxDate, "99/99/99"));
               AV74DDO_VisHoraAuxDateTo = DateTimeUtil.ResetTime(AV72TFVisHora_To);
               AssignAttri("", false, "AV74DDO_VisHoraAuxDateTo", context.localUtil.Format(AV74DDO_VisHoraAuxDateTo, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFVISDATAHORA") == 0 )
            {
               AV76TFVisDataHora = context.localUtil.CToT( AV12GridStateFilterValue.gxTpr_Value, 2);
               AssignAttri("", false, "AV76TFVisDataHora", context.localUtil.TToC( AV76TFVisDataHora, 10, 5, 0, 3, "/", ":", " "));
               AV77TFVisDataHora_To = context.localUtil.CToT( AV12GridStateFilterValue.gxTpr_Valueto, 2);
               AssignAttri("", false, "AV77TFVisDataHora_To", context.localUtil.TToC( AV77TFVisDataHora_To, 10, 5, 0, 3, "/", ":", " "));
               AV78DDO_VisDataHoraAuxDate = DateTimeUtil.ResetTime(AV76TFVisDataHora);
               AssignAttri("", false, "AV78DDO_VisDataHoraAuxDate", context.localUtil.Format(AV78DDO_VisDataHoraAuxDate, "99/99/9999"));
               AV79DDO_VisDataHoraAuxDateTo = DateTimeUtil.ResetTime(AV77TFVisDataHora_To);
               AssignAttri("", false, "AV79DDO_VisDataHoraAuxDateTo", context.localUtil.Format(AV79DDO_VisDataHoraAuxDateTo, "99/99/9999"));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFVISDATAFIM") == 0 )
            {
               AV146TFVisDataFim = context.localUtil.CToD( AV12GridStateFilterValue.gxTpr_Value, 2);
               AssignAttri("", false, "AV146TFVisDataFim", context.localUtil.Format(AV146TFVisDataFim, "99/99/99"));
               AV147TFVisDataFim_To = context.localUtil.CToD( AV12GridStateFilterValue.gxTpr_Valueto, 2);
               AssignAttri("", false, "AV147TFVisDataFim_To", context.localUtil.Format(AV147TFVisDataFim_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFVISHORAFIM") == 0 )
            {
               AV151TFVisHoraFim = DateTimeUtil.ResetDate(context.localUtil.CToT( AV12GridStateFilterValue.gxTpr_Value, 2));
               AssignAttri("", false, "AV151TFVisHoraFim", context.localUtil.TToC( AV151TFVisHoraFim, 0, 5, 0, 3, "/", ":", " "));
               AV152TFVisHoraFim_To = DateTimeUtil.ResetDate(context.localUtil.CToT( AV12GridStateFilterValue.gxTpr_Valueto, 2));
               AssignAttri("", false, "AV152TFVisHoraFim_To", context.localUtil.TToC( AV152TFVisHoraFim_To, 0, 5, 0, 3, "/", ":", " "));
               AV153DDO_VisHoraFimAuxDate = DateTimeUtil.ResetTime(AV151TFVisHoraFim);
               AssignAttri("", false, "AV153DDO_VisHoraFimAuxDate", context.localUtil.Format(AV153DDO_VisHoraFimAuxDate, "99/99/99"));
               AV154DDO_VisHoraFimAuxDateTo = DateTimeUtil.ResetTime(AV152TFVisHoraFim_To);
               AssignAttri("", false, "AV154DDO_VisHoraFimAuxDateTo", context.localUtil.Format(AV154DDO_VisHoraFimAuxDateTo, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFVISDATAHORAFIM") == 0 )
            {
               AV156TFVisDataHoraFim = context.localUtil.CToT( AV12GridStateFilterValue.gxTpr_Value, 2);
               AssignAttri("", false, "AV156TFVisDataHoraFim", context.localUtil.TToC( AV156TFVisDataHoraFim, 10, 5, 0, 3, "/", ":", " "));
               AV157TFVisDataHoraFim_To = context.localUtil.CToT( AV12GridStateFilterValue.gxTpr_Valueto, 2);
               AssignAttri("", false, "AV157TFVisDataHoraFim_To", context.localUtil.TToC( AV157TFVisDataHoraFim_To, 10, 5, 0, 3, "/", ":", " "));
               AV158DDO_VisDataHoraFimAuxDate = DateTimeUtil.ResetTime(AV156TFVisDataHoraFim);
               AssignAttri("", false, "AV158DDO_VisDataHoraFimAuxDate", context.localUtil.Format(AV158DDO_VisDataHoraFimAuxDate, "99/99/9999"));
               AV159DDO_VisDataHoraFimAuxDateTo = DateTimeUtil.ResetTime(AV157TFVisDataHoraFim_To);
               AssignAttri("", false, "AV159DDO_VisDataHoraFimAuxDateTo", context.localUtil.Format(AV159DDO_VisDataHoraFimAuxDateTo, "99/99/9999"));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFVISTIPONOME") == 0 )
            {
               AV85TFVisTipoNome = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV85TFVisTipoNome", AV85TFVisTipoNome);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFVISTIPONOME_SEL") == 0 )
            {
               AV86TFVisTipoNome_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV86TFVisTipoNome_Sel", AV86TFVisTipoNome_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFVISASSUNTO") == 0 )
            {
               AV91TFVisAssunto = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV91TFVisAssunto", AV91TFVisAssunto);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFVISASSUNTO_SEL") == 0 )
            {
               AV92TFVisAssunto_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV92TFVisAssunto_Sel", AV92TFVisAssunto_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFVISSITUACAO_SEL") == 0 )
            {
               AV141TFVisSituacao_SelsJson = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV141TFVisSituacao_SelsJson", AV141TFVisSituacao_SelsJson);
               AV142TFVisSituacao_Sels.FromJSonString(AV141TFVisSituacao_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFVISLINK") == 0 )
            {
               AV93TFVisLink = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV93TFVisLink", AV93TFVisLink);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFVISLINK_SEL") == 0 )
            {
               AV94TFVisLink_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV94TFVisLink_Sel", AV94TFVisLink_Sel);
            }
            AV203GXV2 = (int)(AV203GXV2+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV65TFVisInsUsuNome_Sel)),  AV65TFVisInsUsuNome_Sel, out  GXt_char2) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV86TFVisTipoNome_Sel)),  AV86TFVisTipoNome_Sel, out  GXt_char4) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV92TFVisAssunto_Sel)),  AV92TFVisAssunto_Sel, out  GXt_char5) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  (AV142TFVisSituacao_Sels.Count==0),  AV141TFVisSituacao_SelsJson, out  GXt_char6) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV94TFVisLink_Sel)),  AV94TFVisLink_Sel, out  GXt_char7) ;
         Ddo_grid_Selectedvalue_set = "|"+GXt_char2+"|||||||"+GXt_char4+"|"+GXt_char5+"|"+GXt_char6+"|"+GXt_char7;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV64TFVisInsUsuNome)),  AV64TFVisInsUsuNome, out  GXt_char7) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV85TFVisTipoNome)),  AV85TFVisTipoNome, out  GXt_char6) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV91TFVisAssunto)),  AV91TFVisAssunto, out  GXt_char5) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV93TFVisLink)),  AV93TFVisLink, out  GXt_char4) ;
         Ddo_grid_Filteredtext_set = ((DateTime.MinValue==AV57TFVisInsDataHora) ? "" : context.localUtil.DToC( AV59DDO_VisInsDataHoraAuxDate, 2, "/"))+"|"+GXt_char7+"|"+((DateTime.MinValue==AV66TFVisData) ? "" : context.localUtil.DToC( AV66TFVisData, 2, "/"))+"|"+((DateTime.MinValue==AV71TFVisHora) ? "" : context.localUtil.DToC( AV73DDO_VisHoraAuxDate, 2, "/"))+"|"+((DateTime.MinValue==AV76TFVisDataHora) ? "" : context.localUtil.DToC( AV78DDO_VisDataHoraAuxDate, 2, "/"))+"|"+((DateTime.MinValue==AV146TFVisDataFim) ? "" : context.localUtil.DToC( AV146TFVisDataFim, 2, "/"))+"|"+((DateTime.MinValue==AV151TFVisHoraFim) ? "" : context.localUtil.DToC( AV153DDO_VisHoraFimAuxDate, 2, "/"))+"|"+((DateTime.MinValue==AV156TFVisDataHoraFim) ? "" : context.localUtil.DToC( AV158DDO_VisDataHoraFimAuxDate, 2, "/"))+"|"+GXt_char6+"|"+GXt_char5+"||"+GXt_char4;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = ((DateTime.MinValue==AV58TFVisInsDataHora_To) ? "" : context.localUtil.DToC( AV60DDO_VisInsDataHoraAuxDateTo, 2, "/"))+"||"+((DateTime.MinValue==AV67TFVisData_To) ? "" : context.localUtil.DToC( AV67TFVisData_To, 2, "/"))+"|"+((DateTime.MinValue==AV72TFVisHora_To) ? "" : context.localUtil.DToC( AV74DDO_VisHoraAuxDateTo, 2, "/"))+"|"+((DateTime.MinValue==AV77TFVisDataHora_To) ? "" : context.localUtil.DToC( AV79DDO_VisDataHoraAuxDateTo, 2, "/"))+"|"+((DateTime.MinValue==AV147TFVisDataFim_To) ? "" : context.localUtil.DToC( AV147TFVisDataFim_To, 2, "/"))+"|"+((DateTime.MinValue==AV152TFVisHoraFim_To) ? "" : context.localUtil.DToC( AV154DDO_VisHoraFimAuxDateTo, 2, "/"))+"|"+((DateTime.MinValue==AV157TFVisDataHoraFim_To) ? "" : context.localUtil.DToC( AV159DDO_VisDataHoraFimAuxDateTo, 2, "/"))+"||||";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV11GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV11GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV11GridState.gxTpr_Currentpage) ;
      }

      protected void S152( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV11GridState.FromXml(AV43Session.Get(AV173Pgmname+"GridState"), null, "", "");
         AV11GridState.gxTpr_Orderedby = AV14OrderedBy;
         AV11GridState.gxTpr_Ordereddsc = AV15OrderedDsc;
         AV11GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "VISNEGID_FILTRO",  "da Negociação",  !(Guid.Empty==AV143VisNegID_Filtro),  0,  StringUtil.Trim( AV143VisNegID_Filtro.ToString()),  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "VISNGFSEQ_FILTRO",  "da Negociação",  !(0==AV144VisNgfSeq_Filtro),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV144VisNgfSeq_Filtro), 8, 0)),  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "VISDEL_FILTRO",  "Excluído",  !(false==AV165VisDel_Filtro),  0,  StringUtil.Trim( StringUtil.BoolToStr( AV165VisDel_Filtro)),  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "VISSITUACAO",  "Situação",  !String.IsNullOrEmpty(StringUtil.RTrim( AV164VisSituacao)),  AV163DynamicFiltersOperatorVisSituacao,  AV164VisSituacao,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFVISINSDATAHORA",  "Incluído em",  !((DateTime.MinValue==AV57TFVisInsDataHora)&&(DateTime.MinValue==AV58TFVisInsDataHora_To)),  0,  StringUtil.Trim( context.localUtil.TToC( AV57TFVisInsDataHora, 10, 12, 0, 3, "/", ":", " ")),  StringUtil.Trim( context.localUtil.TToC( AV58TFVisInsDataHora_To, 10, 12, 0, 3, "/", ":", " "))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFVISINSUSUNOME",  "Incluído por",  !String.IsNullOrEmpty(StringUtil.RTrim( AV64TFVisInsUsuNome)),  0,  AV64TFVisInsUsuNome,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV65TFVisInsUsuNome_Sel)),  AV65TFVisInsUsuNome_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFVISDATA",  "Data",  !((DateTime.MinValue==AV66TFVisData)&&(DateTime.MinValue==AV67TFVisData_To)),  0,  StringUtil.Trim( context.localUtil.DToC( AV66TFVisData, 2, "/")),  StringUtil.Trim( context.localUtil.DToC( AV67TFVisData_To, 2, "/"))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFVISHORA",  "Hora",  !((DateTime.MinValue==AV71TFVisHora)&&(DateTime.MinValue==AV72TFVisHora_To)),  0,  StringUtil.Trim( context.localUtil.TToC( AV71TFVisHora, 0, 5, 0, 3, "/", ":", " ")),  StringUtil.Trim( context.localUtil.TToC( AV72TFVisHora_To, 0, 5, 0, 3, "/", ":", " "))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFVISDATAHORA",  "Data/Hora",  !((DateTime.MinValue==AV76TFVisDataHora)&&(DateTime.MinValue==AV77TFVisDataHora_To)),  0,  StringUtil.Trim( context.localUtil.TToC( AV76TFVisDataHora, 10, 5, 0, 3, "/", ":", " ")),  StringUtil.Trim( context.localUtil.TToC( AV77TFVisDataHora_To, 10, 5, 0, 3, "/", ":", " "))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFVISDATAFIM",  "Data",  !((DateTime.MinValue==AV146TFVisDataFim)&&(DateTime.MinValue==AV147TFVisDataFim_To)),  0,  StringUtil.Trim( context.localUtil.DToC( AV146TFVisDataFim, 2, "/")),  StringUtil.Trim( context.localUtil.DToC( AV147TFVisDataFim_To, 2, "/"))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFVISHORAFIM",  "Hora",  !((DateTime.MinValue==AV151TFVisHoraFim)&&(DateTime.MinValue==AV152TFVisHoraFim_To)),  0,  StringUtil.Trim( context.localUtil.TToC( AV151TFVisHoraFim, 0, 5, 0, 3, "/", ":", " ")),  StringUtil.Trim( context.localUtil.TToC( AV152TFVisHoraFim_To, 0, 5, 0, 3, "/", ":", " "))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFVISDATAHORAFIM",  "Data/Hora",  !((DateTime.MinValue==AV156TFVisDataHoraFim)&&(DateTime.MinValue==AV157TFVisDataHoraFim_To)),  0,  StringUtil.Trim( context.localUtil.TToC( AV156TFVisDataHoraFim, 10, 5, 0, 3, "/", ":", " ")),  StringUtil.Trim( context.localUtil.TToC( AV157TFVisDataHoraFim_To, 10, 5, 0, 3, "/", ":", " "))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFVISTIPONOME",  "Tipo",  !String.IsNullOrEmpty(StringUtil.RTrim( AV85TFVisTipoNome)),  0,  AV85TFVisTipoNome,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV86TFVisTipoNome_Sel)),  AV86TFVisTipoNome_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFVISASSUNTO",  "Assunto",  !String.IsNullOrEmpty(StringUtil.RTrim( AV91TFVisAssunto)),  0,  AV91TFVisAssunto,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV92TFVisAssunto_Sel)),  AV92TFVisAssunto_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFVISSITUACAO_SEL",  "Situação",  !(AV142TFVisSituacao_Sels.Count==0),  0,  AV142TFVisSituacao_Sels.ToJSonString(false),  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFVISLINK",  "Link de Acesso",  !String.IsNullOrEmpty(StringUtil.RTrim( AV93TFVisLink)),  0,  AV93TFVisLink,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV94TFVisLink_Sel)),  AV94TFVisLink_Sel,  "") ;
         if ( ! (Guid.Empty==AV129VisNegID) )
         {
            AV12GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
            AV12GridStateFilterValue.gxTpr_Name = "PARM_&VISNEGID";
            AV12GridStateFilterValue.gxTpr_Value = AV129VisNegID.ToString();
            AV11GridState.gxTpr_Filtervalues.Add(AV12GridStateFilterValue, 0);
         }
         if ( ! (0==AV130VisNgfSeq) )
         {
            AV12GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
            AV12GridStateFilterValue.gxTpr_Name = "PARM_&VISNGFSEQ";
            AV12GridStateFilterValue.gxTpr_Value = StringUtil.Str( (decimal)(AV130VisNgfSeq), 8, 0);
            AV11GridState.gxTpr_Filtervalues.Add(AV12GridStateFilterValue, 0);
         }
         AV11GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV11GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV173Pgmname+"GridState",  AV11GridState.ToXml(false, true, "", "")) ;
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV9TrnContext.gxTpr_Callerobject = AV173Pgmname;
         AV9TrnContext.gxTpr_Callerondelete = true;
         AV9TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString;
         AV9TrnContext.gxTpr_Transactionname = "core.Visita";
         AV43Session.Set("TrnContext", AV9TrnContext.ToXml(false, true, "", ""));
      }

      protected void S212( )
      {
         /* 'DOEXPORT' Routine */
         returnInSub = false;
         new GeneXus.Programs.core.visitawwexport(context ).execute( out  AV37ExcelFilename, out  AV38ErrorMessage) ;
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

      protected void S222( )
      {
         /* 'DOEXPORTREPORT' Routine */
         returnInSub = false;
         Innewwindow1_Target = formatLink("core.visitawwexportreport.aspx") ;
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Target", Innewwindow1_Target);
         Innewwindow1_Height = "600";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Height", Innewwindow1_Height);
         Innewwindow1_Width = "800";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Width", Innewwindow1_Width);
         this.executeUsercontrolMethod("", false, "INNEWWINDOW1Container", "OpenWindow", "", new Object[] {});
      }

      protected void wb_table2_113_562( bool wbgen )
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
            wb_table2_113_562e( true) ;
         }
         else
         {
            wb_table2_113_562e( false) ;
         }
      }

      protected void wb_table1_47_562( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablerightheader_Internalname, tblTablerightheader_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabledynamicfilters_Internalname, 1, 0, "px", 0, "px", "TableDynamicFiltersFlex", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DynRowVisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabledynamicfiltersrowvissituacao_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefixvissituacao_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefixvissituacao_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_core\\VisitaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersfixedfiltercaptionvissituacao_Internalname, "Situação", "", "", lblDynamicfiltersfixedfiltercaptionvissituacao_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFixedFilterDescription", 0, "", 1, 1, 0, 0, "HLP_core\\VisitaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddlevissituacao_Internalname, "valor", "", "", lblDynamicfiltersmiddlevissituacao_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_core\\VisitaWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            wb_table3_61_562( true) ;
         }
         else
         {
            wb_table3_61_562( false) ;
         }
         return  ;
      }

      protected void wb_table3_61_562e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_47_562e( true) ;
         }
         else
         {
            wb_table1_47_562e( false) ;
         }
      }

      protected void wb_table3_61_562( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergeddynamicfiltersvissituacao_Internalname, tblTablemergeddynamicfiltersvissituacao_Internalname, "", "Table", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersoperatorvissituacao_Internalname, "Dynamic Filters Operator Vis Situacao", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'',false,'" + sGXsfl_81_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperatorvissituacao, cmbavDynamicfiltersoperatorvissituacao_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV163DynamicFiltersOperatorVisSituacao), 4, 0)), 1, cmbavDynamicfiltersoperatorvissituacao_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavDynamicfiltersoperatorvissituacao.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,65);\"", "", true, 0, "HLP_core\\VisitaWW.htm");
            cmbavDynamicfiltersoperatorvissituacao.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV163DynamicFiltersOperatorVisSituacao), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperatorvissituacao_Internalname, "Values", (string)(cmbavDynamicfiltersoperatorvissituacao.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavVissituacao_Internalname, "Vis Situacao", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'" + sGXsfl_81_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavVissituacao, cmbavVissituacao_Internalname, StringUtil.RTrim( AV164VisSituacao), 1, cmbavVissituacao_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbavVissituacao.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,68);\"", "", true, 0, "HLP_core\\VisitaWW.htm");
            cmbavVissituacao.CurrentValue = StringUtil.RTrim( AV164VisSituacao);
            AssignProp("", false, cmbavVissituacao_Internalname, "Values", (string)(cmbavVissituacao.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_61_562e( true) ;
         }
         else
         {
            wb_table3_61_562e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV129VisNegID = (Guid)getParm(obj,0);
         AssignAttri("", false, "AV129VisNegID", AV129VisNegID.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vVISNEGID", GetSecureSignedToken( "", AV129VisNegID, context));
         AV130VisNgfSeq = Convert.ToInt32(getParm(obj,1));
         AssignAttri("", false, "AV130VisNgfSeq", StringUtil.LTrimStr( (decimal)(AV130VisNgfSeq), 8, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vVISNGFSEQ", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV130VisNgfSeq), "ZZ,ZZZ,ZZ9"), context));
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
         PA562( ) ;
         WS562( ) ;
         WE562( ) ;
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
         AddStyleSheetFile("DVelop/Shared/daterangepicker/daterangepicker.css", "");
         AddStyleSheetFile("DVelop/Shared/daterangepicker/daterangepicker.css", "");
         AddStyleSheetFile("DVelop/Shared/daterangepicker/daterangepicker.css", "");
         AddStyleSheetFile("DVelop/Shared/daterangepicker/daterangepicker.css", "");
         AddStyleSheetFile("DVelop/Shared/daterangepicker/daterangepicker.css", "");
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2023828233167", true, true);
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
         context.AddJavascriptSource("core/visitaww.js", "?2023828233170", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
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
         context.AddJavascriptSource("DVelop/GridTitlesCategories/GridTitlesCategoriesRender.js", "", false, true);
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
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_812( )
      {
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_81_idx;
         edtVisInsDataHora_Internalname = "VISINSDATAHORA_"+sGXsfl_81_idx;
         edtVisInsUsuNome_Internalname = "VISINSUSUNOME_"+sGXsfl_81_idx;
         edtVisData_Internalname = "VISDATA_"+sGXsfl_81_idx;
         edtVisHora_Internalname = "VISHORA_"+sGXsfl_81_idx;
         edtVisDataHora_Internalname = "VISDATAHORA_"+sGXsfl_81_idx;
         edtVisDataFim_Internalname = "VISDATAFIM_"+sGXsfl_81_idx;
         edtVisHoraFim_Internalname = "VISHORAFIM_"+sGXsfl_81_idx;
         edtVisDataHoraFim_Internalname = "VISDATAHORAFIM_"+sGXsfl_81_idx;
         edtVisTipoNome_Internalname = "VISTIPONOME_"+sGXsfl_81_idx;
         edtVisAssunto_Internalname = "VISASSUNTO_"+sGXsfl_81_idx;
         cmbVisSituacao_Internalname = "VISSITUACAO_"+sGXsfl_81_idx;
         edtVisLink_Internalname = "VISLINK_"+sGXsfl_81_idx;
         edtVisID_Internalname = "VISID_"+sGXsfl_81_idx;
         edtVisPaiID_Internalname = "VISPAIID_"+sGXsfl_81_idx;
         edtVisNegID_Internalname = "VISNEGID_"+sGXsfl_81_idx;
         edtVisNgfSeq_Internalname = "VISNGFSEQ_"+sGXsfl_81_idx;
      }

      protected void SubsflControlProps_fel_812( )
      {
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_81_fel_idx;
         edtVisInsDataHora_Internalname = "VISINSDATAHORA_"+sGXsfl_81_fel_idx;
         edtVisInsUsuNome_Internalname = "VISINSUSUNOME_"+sGXsfl_81_fel_idx;
         edtVisData_Internalname = "VISDATA_"+sGXsfl_81_fel_idx;
         edtVisHora_Internalname = "VISHORA_"+sGXsfl_81_fel_idx;
         edtVisDataHora_Internalname = "VISDATAHORA_"+sGXsfl_81_fel_idx;
         edtVisDataFim_Internalname = "VISDATAFIM_"+sGXsfl_81_fel_idx;
         edtVisHoraFim_Internalname = "VISHORAFIM_"+sGXsfl_81_fel_idx;
         edtVisDataHoraFim_Internalname = "VISDATAHORAFIM_"+sGXsfl_81_fel_idx;
         edtVisTipoNome_Internalname = "VISTIPONOME_"+sGXsfl_81_fel_idx;
         edtVisAssunto_Internalname = "VISASSUNTO_"+sGXsfl_81_fel_idx;
         cmbVisSituacao_Internalname = "VISSITUACAO_"+sGXsfl_81_fel_idx;
         edtVisLink_Internalname = "VISLINK_"+sGXsfl_81_fel_idx;
         edtVisID_Internalname = "VISID_"+sGXsfl_81_fel_idx;
         edtVisPaiID_Internalname = "VISPAIID_"+sGXsfl_81_fel_idx;
         edtVisNegID_Internalname = "VISNEGID_"+sGXsfl_81_fel_idx;
         edtVisNgfSeq_Internalname = "VISNGFSEQ_"+sGXsfl_81_fel_idx;
      }

      protected void sendrow_812( )
      {
         SubsflControlProps_812( ) ;
         WB560( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_81_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_81_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_81_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = " " + ((cmbavGridactions.Enabled!=0)&&(cmbavGridactions.Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 82,'',false,'"+sGXsfl_81_idx+"',81)\"" : " ");
            if ( ( cmbavGridactions.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vGRIDACTIONS_" + sGXsfl_81_idx;
               cmbavGridactions.Name = GXCCtl;
               cmbavGridactions.WebTags = "";
               if ( cmbavGridactions.ItemCount > 0 )
               {
                  AV102GridActions = (short)(Math.Round(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV102GridActions), 4, 0))), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV102GridActions), 4, 0));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavGridactions,(string)cmbavGridactions_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV102GridActions), 4, 0)),(short)1,(string)cmbavGridactions_Jsonclick,(short)5,"'"+""+"'"+",false,"+"'"+"EVGRIDACTIONS.CLICK."+sGXsfl_81_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)cmbavGridactions_Class,(string)"WWActionGroupColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((cmbavGridactions.Enabled!=0)&&(cmbavGridactions.Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,82);\"" : " "),(string)"",(bool)true,(short)0});
            cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV102GridActions), 4, 0));
            AssignProp("", false, cmbavGridactions_Internalname, "Values", (string)(cmbavGridactions.ToJavascriptSource()), !bGXsfl_81_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtVisInsDataHora_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtVisInsDataHora_Internalname,context.localUtil.TToC( A401VisInsDataHora, 10, 12, 0, 3, "/", ":", " "),context.localUtil.Format( A401VisInsDataHora, "99/99/9999 99:99:99.999"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtVisInsDataHora_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtVisInsDataHora_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)24,(short)0,(short)0,(short)81,(short)0,(short)-1,(short)0,(bool)true,(string)"core\\DataHoraSegundoMS",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtVisInsUsuNome_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtVisInsUsuNome_Internalname,(string)A403VisInsUsuNome,StringUtil.RTrim( context.localUtil.Format( A403VisInsUsuNome, "@!")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtVisInsUsuNome_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtVisInsUsuNome_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)81,(short)0,(short)-1,(short)-1,(bool)true,(string)"core\\Nome",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtVisData_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtVisData_Internalname,context.localUtil.Format(A404VisData, "99/99/99"),context.localUtil.Format( A404VisData, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtVisData_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtVisData_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)81,(short)0,(short)-1,(short)0,(bool)true,(string)"core\\Data",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtVisHora_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtVisHora_Internalname,context.localUtil.TToC( A405VisHora, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A405VisHora, "99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtVisHora_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtVisHora_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)5,(short)0,(short)0,(short)81,(short)0,(short)-1,(short)0,(bool)true,(string)"core\\HoraMinuto",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtVisDataHora_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtVisDataHora_Internalname,context.localUtil.TToC( A406VisDataHora, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A406VisDataHora, "99/99/9999 99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtVisDataHora_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtVisDataHora_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)16,(short)0,(short)0,(short)81,(short)0,(short)-1,(short)0,(bool)true,(string)"core\\DataHora",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtVisDataFim_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtVisDataFim_Internalname,context.localUtil.Format(A475VisDataFim, "99/99/99"),context.localUtil.Format( A475VisDataFim, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtVisDataFim_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtVisDataFim_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)81,(short)0,(short)-1,(short)0,(bool)true,(string)"core\\Data",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtVisHoraFim_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtVisHoraFim_Internalname,context.localUtil.TToC( A476VisHoraFim, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A476VisHoraFim, "99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtVisHoraFim_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtVisHoraFim_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)5,(short)0,(short)0,(short)81,(short)0,(short)-1,(short)0,(bool)true,(string)"core\\HoraMinuto",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtVisDataHoraFim_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtVisDataHoraFim_Internalname,context.localUtil.TToC( A477VisDataHoraFim, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A477VisDataHoraFim, "99/99/9999 99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtVisDataHoraFim_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtVisDataHoraFim_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)16,(short)0,(short)0,(short)81,(short)0,(short)-1,(short)0,(bool)true,(string)"core\\DataHora",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtVisTipoNome_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtVisTipoNome_Internalname,(string)A416VisTipoNome,StringUtil.RTrim( context.localUtil.Format( A416VisTipoNome, "@!")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtVisTipoNome_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtVisTipoNome_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)81,(short)0,(short)-1,(short)-1,(bool)true,(string)"core\\Nome",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtVisAssunto_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtVisAssunto_Internalname,(string)A409VisAssunto,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtVisAssunto_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtVisAssunto_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)81,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((cmbVisSituacao.Visible==0) ? "display:none;" : "")+"\">") ;
            }
            if ( ( cmbVisSituacao.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "VISSITUACAO_" + sGXsfl_81_idx;
               cmbVisSituacao.Name = GXCCtl;
               cmbVisSituacao.WebTags = "";
               cmbVisSituacao.addItem("", " ", 0);
               cmbVisSituacao.addItem("PEN", "Pendente", 0);
               cmbVisSituacao.addItem("REA", "Realizada", 0);
               cmbVisSituacao.addItem("REM", "Remarcada", 0);
               cmbVisSituacao.addItem("CAN", "Cancelada", 0);
               if ( cmbVisSituacao.ItemCount > 0 )
               {
                  A472VisSituacao = cmbVisSituacao.getValidValue(A472VisSituacao);
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbVisSituacao,(string)cmbVisSituacao_Internalname,StringUtil.RTrim( A472VisSituacao),(short)1,(string)cmbVisSituacao_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",cmbVisSituacao.Visible,(short)0,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",(string)"",(string)"",(bool)true,(short)0});
            cmbVisSituacao.CurrentValue = StringUtil.RTrim( A472VisSituacao);
            AssignProp("", false, cmbVisSituacao_Internalname, "Values", (string)(cmbVisSituacao.ToJavascriptSource()), !bGXsfl_81_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtVisLink_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtVisLink_Internalname,(string)A417VisLink,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtVisLink_Link,(string)edtVisLink_Linktarget,(string)"",(string)"",(string)edtVisLink_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtVisLink_Visible,(short)0,(short)0,(string)"url",(string)"",(short)570,(string)"px",(short)17,(string)"px",(short)1000,(short)0,(short)0,(short)81,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Url",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtVisID_Internalname,A398VisID.ToString(),A398VisID.ToString(),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtVisID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)81,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtVisPaiID_Internalname,A419VisPaiID.ToString(),A419VisPaiID.ToString(),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtVisPaiID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)81,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtVisNegID_Internalname,A418VisNegID.ToString(),A418VisNegID.ToString(),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtVisNegID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)81,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtVisNgfSeq_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A422VisNgfSeq), 10, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A422VisNgfSeq), "ZZ,ZZZ,ZZ9")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtVisNgfSeq_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)81,(short)0,(short)-1,(short)0,(bool)true,(string)"core\\Seq",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashes562( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_81_idx = ((subGrid_Islastpage==1)&&(nGXsfl_81_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_81_idx+1);
            sGXsfl_81_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_81_idx), 4, 0), 4, "0");
            SubsflControlProps_812( ) ;
         }
         /* End function sendrow_812 */
      }

      protected void init_web_controls( )
      {
         cmbavDynamicfiltersoperatorvissituacao.Name = "vDYNAMICFILTERSOPERATORVISSITUACAO";
         cmbavDynamicfiltersoperatorvissituacao.WebTags = "";
         cmbavDynamicfiltersoperatorvissituacao.addItem("0", "Igual", 0);
         cmbavDynamicfiltersoperatorvissituacao.addItem("1", "Diferente", 0);
         if ( cmbavDynamicfiltersoperatorvissituacao.ItemCount > 0 )
         {
            AV163DynamicFiltersOperatorVisSituacao = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperatorvissituacao.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV163DynamicFiltersOperatorVisSituacao), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV163DynamicFiltersOperatorVisSituacao", StringUtil.LTrimStr( (decimal)(AV163DynamicFiltersOperatorVisSituacao), 4, 0));
         }
         cmbavVissituacao.Name = "vVISSITUACAO";
         cmbavVissituacao.WebTags = "";
         cmbavVissituacao.addItem("", "Todos", 0);
         cmbavVissituacao.addItem("PEN", "Pendente", 0);
         cmbavVissituacao.addItem("REA", "Realizada", 0);
         cmbavVissituacao.addItem("REM", "Remarcada", 0);
         cmbavVissituacao.addItem("CAN", "Cancelada", 0);
         if ( cmbavVissituacao.ItemCount > 0 )
         {
            AV164VisSituacao = cmbavVissituacao.getValidValue(AV164VisSituacao);
            AssignAttri("", false, "AV164VisSituacao", AV164VisSituacao);
         }
         GXCCtl = "vGRIDACTIONS_" + sGXsfl_81_idx;
         cmbavGridactions.Name = GXCCtl;
         cmbavGridactions.WebTags = "";
         if ( cmbavGridactions.ItemCount > 0 )
         {
            AV102GridActions = (short)(Math.Round(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV102GridActions), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV102GridActions), 4, 0));
         }
         GXCCtl = "VISSITUACAO_" + sGXsfl_81_idx;
         cmbVisSituacao.Name = GXCCtl;
         cmbVisSituacao.WebTags = "";
         cmbVisSituacao.addItem("", " ", 0);
         cmbVisSituacao.addItem("PEN", "Pendente", 0);
         cmbVisSituacao.addItem("REA", "Realizada", 0);
         cmbVisSituacao.addItem("REM", "Remarcada", 0);
         cmbVisSituacao.addItem("CAN", "Cancelada", 0);
         if ( cmbVisSituacao.ItemCount > 0 )
         {
            A472VisSituacao = cmbVisSituacao.getValidValue(A472VisSituacao);
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl81( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"81\">") ;
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
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtVisInsDataHora_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Incluído em") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtVisInsUsuNome_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Incluído por") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtVisData_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Data") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtVisHora_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Hora") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtVisDataHora_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Data/Hora") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtVisDataFim_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Data") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtVisHoraFim_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Hora") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtVisDataHoraFim_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Data/Hora") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtVisTipoNome_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Tipo") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtVisAssunto_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Assunto") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((cmbVisSituacao.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Situação") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" width="+StringUtil.LTrimStr( (decimal)(570), 4, 0)+"px"+" class=\""+"Attribute"+"\" "+" style=\""+((edtVisLink_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Link de Acesso") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV102GridActions), 4, 0, ".", ""))));
            GridColumn.AddObjectProperty("Class", StringUtil.RTrim( cmbavGridactions_Class));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A401VisInsDataHora, 10, 12, 0, 3, "/", ":", " ")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtVisInsDataHora_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A403VisInsUsuNome));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtVisInsUsuNome_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A404VisData, "99/99/99")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtVisData_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A405VisHora, 10, 8, 0, 3, "/", ":", " ")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtVisHora_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A406VisDataHora, 10, 8, 0, 3, "/", ":", " ")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtVisDataHora_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A475VisDataFim, "99/99/99")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtVisDataFim_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A476VisHoraFim, 10, 8, 0, 3, "/", ":", " ")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtVisHoraFim_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A477VisDataHoraFim, 10, 8, 0, 3, "/", ":", " ")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtVisDataHoraFim_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A416VisTipoNome));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtVisTipoNome_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A409VisAssunto));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtVisAssunto_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A472VisSituacao));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbVisSituacao.Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A417VisLink));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtVisLink_Link));
            GridColumn.AddObjectProperty("Linktarget", StringUtil.RTrim( edtVisLink_Linktarget));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtVisLink_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A398VisID.ToString()));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A419VisPaiID.ToString()));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A418VisNegID.ToString()));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A422VisNgfSeq), 10, 0, ".", ""))));
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
         edtavVisnegid_filtro_Internalname = "vVISNEGID_FILTRO";
         edtavVisngfseq_filtro_Internalname = "vVISNGFSEQ_FILTRO";
         edtavVisdel_filtro_Internalname = "vVISDEL_FILTRO";
         divTableoportunidade_Internalname = "TABLEOPORTUNIDADE";
         Dvpanel_tableoportunidade_Internalname = "DVPANEL_TABLEOPORTUNIDADE";
         bttBtncancel_Internalname = "BTNCANCEL";
         bttBtninsert_Internalname = "BTNINSERT";
         bttBtnagexport_Internalname = "BTNAGEXPORT";
         bttBtneditcolumns_Internalname = "BTNEDITCOLUMNS";
         bttBtnsubscriptions_Internalname = "BTNSUBSCRIPTIONS";
         divTableactions_Internalname = "TABLEACTIONS";
         lblDynamicfiltersprefixvissituacao_Internalname = "DYNAMICFILTERSPREFIXVISSITUACAO";
         lblDynamicfiltersfixedfiltercaptionvissituacao_Internalname = "DYNAMICFILTERSFIXEDFILTERCAPTIONVISSITUACAO";
         lblDynamicfiltersmiddlevissituacao_Internalname = "DYNAMICFILTERSMIDDLEVISSITUACAO";
         cmbavDynamicfiltersoperatorvissituacao_Internalname = "vDYNAMICFILTERSOPERATORVISSITUACAO";
         cmbavVissituacao_Internalname = "vVISSITUACAO";
         tblTablemergeddynamicfiltersvissituacao_Internalname = "TABLEMERGEDDYNAMICFILTERSVISSITUACAO";
         divTabledynamicfiltersrowvissituacao_Internalname = "TABLEDYNAMICFILTERSROWVISSITUACAO";
         divTabledynamicfilters_Internalname = "TABLEDYNAMICFILTERS";
         tblTablerightheader_Internalname = "TABLERIGHTHEADER";
         edtavNegultitenome_Internalname = "vNEGULTITENOME";
         divTableheadercontent_Internalname = "TABLEHEADERCONTENT";
         divTableheader_Internalname = "TABLEHEADER";
         cmbavGridactions_Internalname = "vGRIDACTIONS";
         edtVisInsDataHora_Internalname = "VISINSDATAHORA";
         edtVisInsUsuNome_Internalname = "VISINSUSUNOME";
         edtVisData_Internalname = "VISDATA";
         edtVisHora_Internalname = "VISHORA";
         edtVisDataHora_Internalname = "VISDATAHORA";
         edtVisDataFim_Internalname = "VISDATAFIM";
         edtVisHoraFim_Internalname = "VISHORAFIM";
         edtVisDataHoraFim_Internalname = "VISDATAHORAFIM";
         edtVisTipoNome_Internalname = "VISTIPONOME";
         edtVisAssunto_Internalname = "VISASSUNTO";
         cmbVisSituacao_Internalname = "VISSITUACAO";
         edtVisLink_Internalname = "VISLINK";
         edtVisID_Internalname = "VISID";
         edtVisPaiID_Internalname = "VISPAIID";
         edtVisNegID_Internalname = "VISNEGID";
         edtVisNgfSeq_Internalname = "VISNGFSEQ";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         Ddo_agexport_Internalname = "DDO_AGEXPORT";
         Ddc_subscriptions_Internalname = "DDC_SUBSCRIPTIONS";
         Ddo_grid_Internalname = "DDO_GRID";
         Innewwindow1_Internalname = "INNEWWINDOW1";
         Ddo_gridcolumnsselector_Internalname = "DDO_GRIDCOLUMNSSELECTOR";
         edtavNegultngfseq_Internalname = "vNEGULTNGFSEQ";
         edtavVisnegid_Internalname = "vVISNEGID";
         edtavVisngfseq_Internalname = "vVISNGFSEQ";
         Dvelop_confirmpanel_delete_Internalname = "DVELOP_CONFIRMPANEL_DELETE";
         tblTabledvelop_confirmpanel_delete_Internalname = "TABLEDVELOP_CONFIRMPANEL_DELETE";
         Grid_titlescategories_Internalname = "GRID_TITLESCATEGORIES";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
         divDiv_wwpauxwc_Internalname = "DIV_WWPAUXWC";
         edtavDdo_visinsdatahoraauxdatetext_Internalname = "vDDO_VISINSDATAHORAAUXDATETEXT";
         Tfvisinsdatahora_rangepicker_Internalname = "TFVISINSDATAHORA_RANGEPICKER";
         divDdo_visinsdatahoraauxdates_Internalname = "DDO_VISINSDATAHORAAUXDATES";
         edtavDdo_visdataauxdatetext_Internalname = "vDDO_VISDATAAUXDATETEXT";
         Tfvisdata_rangepicker_Internalname = "TFVISDATA_RANGEPICKER";
         divDdo_visdataauxdates_Internalname = "DDO_VISDATAAUXDATES";
         edtavDdo_vishoraauxdatetext_Internalname = "vDDO_VISHORAAUXDATETEXT";
         Tfvishora_rangepicker_Internalname = "TFVISHORA_RANGEPICKER";
         divDdo_vishoraauxdates_Internalname = "DDO_VISHORAAUXDATES";
         edtavDdo_visdatahoraauxdatetext_Internalname = "vDDO_VISDATAHORAAUXDATETEXT";
         Tfvisdatahora_rangepicker_Internalname = "TFVISDATAHORA_RANGEPICKER";
         divDdo_visdatahoraauxdates_Internalname = "DDO_VISDATAHORAAUXDATES";
         edtavDdo_visdatafimauxdatetext_Internalname = "vDDO_VISDATAFIMAUXDATETEXT";
         Tfvisdatafim_rangepicker_Internalname = "TFVISDATAFIM_RANGEPICKER";
         divDdo_visdatafimauxdates_Internalname = "DDO_VISDATAFIMAUXDATES";
         edtavDdo_vishorafimauxdatetext_Internalname = "vDDO_VISHORAFIMAUXDATETEXT";
         Tfvishorafim_rangepicker_Internalname = "TFVISHORAFIM_RANGEPICKER";
         divDdo_vishorafimauxdates_Internalname = "DDO_VISHORAFIMAUXDATES";
         edtavDdo_visdatahorafimauxdatetext_Internalname = "vDDO_VISDATAHORAFIMAUXDATETEXT";
         Tfvisdatahorafim_rangepicker_Internalname = "TFVISDATAHORAFIM_RANGEPICKER";
         divDdo_visdatahorafimauxdates_Internalname = "DDO_VISDATAHORAFIMAUXDATES";
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
         edtVisNgfSeq_Jsonclick = "";
         edtVisNegID_Jsonclick = "";
         edtVisPaiID_Jsonclick = "";
         edtVisID_Jsonclick = "";
         edtVisLink_Jsonclick = "";
         edtVisLink_Linktarget = "";
         edtVisLink_Link = "";
         cmbVisSituacao_Jsonclick = "";
         edtVisAssunto_Jsonclick = "";
         edtVisTipoNome_Jsonclick = "";
         edtVisDataHoraFim_Jsonclick = "";
         edtVisHoraFim_Jsonclick = "";
         edtVisDataFim_Jsonclick = "";
         edtVisDataHora_Jsonclick = "";
         edtVisHora_Jsonclick = "";
         edtVisData_Jsonclick = "";
         edtVisInsUsuNome_Jsonclick = "";
         edtVisInsDataHora_Jsonclick = "";
         cmbavGridactions_Jsonclick = "";
         cmbavGridactions.Visible = -1;
         cmbavGridactions.Enabled = 1;
         cmbavGridactions_Class = "ConvertToDDO";
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         cmbavVissituacao_Jsonclick = "";
         cmbavVissituacao.Enabled = 1;
         cmbavDynamicfiltersoperatorvissituacao_Jsonclick = "";
         cmbavDynamicfiltersoperatorvissituacao.Enabled = 1;
         edtVisLink_Visible = -1;
         cmbVisSituacao.Visible = -1;
         edtVisAssunto_Visible = -1;
         edtVisTipoNome_Visible = -1;
         edtVisDataHoraFim_Visible = -1;
         edtVisHoraFim_Visible = -1;
         edtVisDataFim_Visible = -1;
         edtVisDataHora_Visible = -1;
         edtVisHora_Visible = -1;
         edtVisData_Visible = -1;
         edtVisInsUsuNome_Visible = -1;
         edtVisInsDataHora_Visible = -1;
         subGrid_Sortable = 0;
         edtavDdo_visdatahorafimauxdatetext_Jsonclick = "";
         edtavDdo_vishorafimauxdatetext_Jsonclick = "";
         edtavDdo_visdatafimauxdatetext_Jsonclick = "";
         edtavDdo_visdatahoraauxdatetext_Jsonclick = "";
         edtavDdo_vishoraauxdatetext_Jsonclick = "";
         edtavDdo_visdataauxdatetext_Jsonclick = "";
         edtavDdo_visinsdatahoraauxdatetext_Jsonclick = "";
         edtavVisngfseq_Jsonclick = "";
         edtavVisngfseq_Visible = 1;
         edtavVisnegid_Jsonclick = "";
         edtavVisnegid_Visible = 1;
         edtavNegultngfseq_Jsonclick = "";
         edtavNegultngfseq_Visible = 1;
         edtavNegultitenome_Jsonclick = "";
         edtavNegultitenome_Enabled = 1;
         bttBtnsubscriptions_Visible = 1;
         bttBtninsert_Visible = 1;
         edtavVisdel_filtro_Jsonclick = "";
         edtavVisdel_filtro_Enabled = 1;
         edtavVisngfseq_filtro_Jsonclick = "";
         edtavVisngfseq_filtro_Enabled = 1;
         edtavVisnegid_filtro_Jsonclick = "";
         edtavVisnegid_filtro_Enabled = 1;
         Grid_empowerer_Fixedcolumns = "L;;;;;;;;;;;;;;;;";
         Grid_empowerer_Hascolumnsselector = Convert.ToBoolean( -1);
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Grid_empowerer_Hascategories = Convert.ToBoolean( -1);
         Grid_titlescategories_Gridtitlescategories = ";;;Início;Início;Início;Término;Término;Término;;;;;;;;";
         Dvelop_confirmpanel_delete_Confirmtype = "1";
         Dvelop_confirmpanel_delete_Yesbuttonposition = "left";
         Dvelop_confirmpanel_delete_Cancelbuttoncaption = "WWP_ConfirmTextCancel";
         Dvelop_confirmpanel_delete_Nobuttoncaption = "WWP_ConfirmTextNo";
         Dvelop_confirmpanel_delete_Yesbuttoncaption = "WWP_ConfirmTextYes";
         Dvelop_confirmpanel_delete_Confirmationtext = "Deseja realmente EXCLUIR a VISITA?";
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
         Ddo_grid_Datalistproc = "core.VisitaWWGetFilterData";
         Ddo_grid_Datalistfixedvalues = "||||||||||PEN:Pendente,REA:Realizada,REM:Remarcada,CAN:Cancelada|";
         Ddo_grid_Allowmultipleselection = "||||||||||T|";
         Ddo_grid_Datalisttype = "|Dynamic|||||||Dynamic|Dynamic|FixedValues|Dynamic";
         Ddo_grid_Includedatalist = "|T|||||||T|T|T|T";
         Ddo_grid_Filterisrange = "P||P|P|P|P|P|P||||";
         Ddo_grid_Filtertype = "Date|Character|Date|Date|Date|Date|Date|Date|Character|Character||Character";
         Ddo_grid_Includefilter = "T|T|T|T|T|T|T|T|T|T||T";
         Ddo_grid_Fixable = "T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "2|3|4|5|6|7|8|9|10|11|12|13";
         Ddo_grid_Columnids = "1:VisInsDataHora|2:VisInsUsuNome|3:VisData|4:VisHora|5:VisDataHora|6:VisDataFim|7:VisHoraFim|8:VisDataHoraFim|9:VisTipoNome|10:VisAssunto|11:VisSituacao|12:VisLink";
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
         Dvpanel_tableoportunidade_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableoportunidade_Iconposition = "Right";
         Dvpanel_tableoportunidade_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableoportunidade_Collapsed = Convert.ToBoolean( 1);
         Dvpanel_tableoportunidade_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_tableoportunidade_Title = "Negociação [!VISNEGCODIGO!]: [!VISNEGASSUNTO!]";
         Dvpanel_tableoportunidade_Cls = "PanelCard_IconAndTitle Panel_BaseColor";
         Dvpanel_tableoportunidade_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tableoportunidade_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tableoportunidade_Width = "100%";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Visitas do Cliente";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV41ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersoperatorvissituacao'},{av:'AV163DynamicFiltersOperatorVisSituacao',fld:'vDYNAMICFILTERSOPERATORVISSITUACAO',pic:'ZZZ9'},{av:'cmbavVissituacao'},{av:'AV164VisSituacao',fld:'vVISSITUACAO',pic:''},{av:'AV129VisNegID',fld:'vVISNEGID',pic:'',hsh:true},{av:'AV130VisNgfSeq',fld:'vVISNGFSEQ',pic:'ZZ,ZZZ,ZZ9',hsh:true},{av:'AV173Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV143VisNegID_Filtro',fld:'vVISNEGID_FILTRO',pic:''},{av:'AV144VisNgfSeq_Filtro',fld:'vVISNGFSEQ_FILTRO',pic:'ZZ,ZZZ,ZZ9'},{av:'AV165VisDel_Filtro',fld:'vVISDEL_FILTRO',pic:''},{av:'AV57TFVisInsDataHora',fld:'vTFVISINSDATAHORA',pic:'99/99/9999 99:99:99.999'},{av:'AV58TFVisInsDataHora_To',fld:'vTFVISINSDATAHORA_TO',pic:'99/99/9999 99:99:99.999'},{av:'AV64TFVisInsUsuNome',fld:'vTFVISINSUSUNOME',pic:'@!'},{av:'AV65TFVisInsUsuNome_Sel',fld:'vTFVISINSUSUNOME_SEL',pic:'@!'},{av:'AV66TFVisData',fld:'vTFVISDATA',pic:''},{av:'AV67TFVisData_To',fld:'vTFVISDATA_TO',pic:''},{av:'AV71TFVisHora',fld:'vTFVISHORA',pic:'99:99'},{av:'AV72TFVisHora_To',fld:'vTFVISHORA_TO',pic:'99:99'},{av:'AV76TFVisDataHora',fld:'vTFVISDATAHORA',pic:'99/99/9999 99:99'},{av:'AV77TFVisDataHora_To',fld:'vTFVISDATAHORA_TO',pic:'99/99/9999 99:99'},{av:'AV146TFVisDataFim',fld:'vTFVISDATAFIM',pic:''},{av:'AV147TFVisDataFim_To',fld:'vTFVISDATAFIM_TO',pic:''},{av:'AV151TFVisHoraFim',fld:'vTFVISHORAFIM',pic:'99:99'},{av:'AV152TFVisHoraFim_To',fld:'vTFVISHORAFIM_TO',pic:'99:99'},{av:'AV156TFVisDataHoraFim',fld:'vTFVISDATAHORAFIM',pic:'99/99/9999 99:99'},{av:'AV157TFVisDataHoraFim_To',fld:'vTFVISDATAHORAFIM_TO',pic:'99/99/9999 99:99'},{av:'AV85TFVisTipoNome',fld:'vTFVISTIPONOME',pic:'@!'},{av:'AV86TFVisTipoNome_Sel',fld:'vTFVISTIPONOME_SEL',pic:'@!'},{av:'AV91TFVisAssunto',fld:'vTFVISASSUNTO',pic:''},{av:'AV92TFVisAssunto_Sel',fld:'vTFVISASSUNTO_SEL',pic:''},{av:'AV142TFVisSituacao_Sels',fld:'vTFVISSITUACAO_SELS',pic:''},{av:'AV93TFVisLink',fld:'vTFVISLINK',pic:''},{av:'AV94TFVisLink_Sel',fld:'vTFVISLINK_SEL',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV103IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV104IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV128IsAuthorized_RemarcarVisita',fld:'vISAUTHORIZED_REMARCARVISITA',pic:'',hsh:true},{av:'AV108IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV41ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtVisInsDataHora_Visible',ctrl:'VISINSDATAHORA',prop:'Visible'},{av:'edtVisInsUsuNome_Visible',ctrl:'VISINSUSUNOME',prop:'Visible'},{av:'edtVisData_Visible',ctrl:'VISDATA',prop:'Visible'},{av:'edtVisHora_Visible',ctrl:'VISHORA',prop:'Visible'},{av:'edtVisDataHora_Visible',ctrl:'VISDATAHORA',prop:'Visible'},{av:'edtVisDataFim_Visible',ctrl:'VISDATAFIM',prop:'Visible'},{av:'edtVisHoraFim_Visible',ctrl:'VISHORAFIM',prop:'Visible'},{av:'edtVisDataHoraFim_Visible',ctrl:'VISDATAHORAFIM',prop:'Visible'},{av:'edtVisTipoNome_Visible',ctrl:'VISTIPONOME',prop:'Visible'},{av:'edtVisAssunto_Visible',ctrl:'VISASSUNTO',prop:'Visible'},{av:'cmbVisSituacao'},{av:'edtVisLink_Visible',ctrl:'VISLINK',prop:'Visible'},{av:'AV99GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV100GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV101GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV103IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV104IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV128IsAuthorized_RemarcarVisita',fld:'vISAUTHORIZED_REMARCARVISITA',pic:'',hsh:true},{av:'AV108IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E11562',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersoperatorvissituacao'},{av:'AV163DynamicFiltersOperatorVisSituacao',fld:'vDYNAMICFILTERSOPERATORVISSITUACAO',pic:'ZZZ9'},{av:'cmbavVissituacao'},{av:'AV164VisSituacao',fld:'vVISSITUACAO',pic:''},{av:'AV129VisNegID',fld:'vVISNEGID',pic:'',hsh:true},{av:'AV130VisNgfSeq',fld:'vVISNGFSEQ',pic:'ZZ,ZZZ,ZZ9',hsh:true},{av:'AV41ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV173Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV143VisNegID_Filtro',fld:'vVISNEGID_FILTRO',pic:''},{av:'AV144VisNgfSeq_Filtro',fld:'vVISNGFSEQ_FILTRO',pic:'ZZ,ZZZ,ZZ9'},{av:'AV165VisDel_Filtro',fld:'vVISDEL_FILTRO',pic:''},{av:'AV57TFVisInsDataHora',fld:'vTFVISINSDATAHORA',pic:'99/99/9999 99:99:99.999'},{av:'AV58TFVisInsDataHora_To',fld:'vTFVISINSDATAHORA_TO',pic:'99/99/9999 99:99:99.999'},{av:'AV64TFVisInsUsuNome',fld:'vTFVISINSUSUNOME',pic:'@!'},{av:'AV65TFVisInsUsuNome_Sel',fld:'vTFVISINSUSUNOME_SEL',pic:'@!'},{av:'AV66TFVisData',fld:'vTFVISDATA',pic:''},{av:'AV67TFVisData_To',fld:'vTFVISDATA_TO',pic:''},{av:'AV71TFVisHora',fld:'vTFVISHORA',pic:'99:99'},{av:'AV72TFVisHora_To',fld:'vTFVISHORA_TO',pic:'99:99'},{av:'AV76TFVisDataHora',fld:'vTFVISDATAHORA',pic:'99/99/9999 99:99'},{av:'AV77TFVisDataHora_To',fld:'vTFVISDATAHORA_TO',pic:'99/99/9999 99:99'},{av:'AV146TFVisDataFim',fld:'vTFVISDATAFIM',pic:''},{av:'AV147TFVisDataFim_To',fld:'vTFVISDATAFIM_TO',pic:''},{av:'AV151TFVisHoraFim',fld:'vTFVISHORAFIM',pic:'99:99'},{av:'AV152TFVisHoraFim_To',fld:'vTFVISHORAFIM_TO',pic:'99:99'},{av:'AV156TFVisDataHoraFim',fld:'vTFVISDATAHORAFIM',pic:'99/99/9999 99:99'},{av:'AV157TFVisDataHoraFim_To',fld:'vTFVISDATAHORAFIM_TO',pic:'99/99/9999 99:99'},{av:'AV85TFVisTipoNome',fld:'vTFVISTIPONOME',pic:'@!'},{av:'AV86TFVisTipoNome_Sel',fld:'vTFVISTIPONOME_SEL',pic:'@!'},{av:'AV91TFVisAssunto',fld:'vTFVISASSUNTO',pic:''},{av:'AV92TFVisAssunto_Sel',fld:'vTFVISASSUNTO_SEL',pic:''},{av:'AV142TFVisSituacao_Sels',fld:'vTFVISSITUACAO_SELS',pic:''},{av:'AV93TFVisLink',fld:'vTFVISLINK',pic:''},{av:'AV94TFVisLink_Sel',fld:'vTFVISLINK_SEL',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV103IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV104IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV128IsAuthorized_RemarcarVisita',fld:'vISAUTHORIZED_REMARCARVISITA',pic:'',hsh:true},{av:'AV108IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E12562',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersoperatorvissituacao'},{av:'AV163DynamicFiltersOperatorVisSituacao',fld:'vDYNAMICFILTERSOPERATORVISSITUACAO',pic:'ZZZ9'},{av:'cmbavVissituacao'},{av:'AV164VisSituacao',fld:'vVISSITUACAO',pic:''},{av:'AV129VisNegID',fld:'vVISNEGID',pic:'',hsh:true},{av:'AV130VisNgfSeq',fld:'vVISNGFSEQ',pic:'ZZ,ZZZ,ZZ9',hsh:true},{av:'AV41ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV173Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV143VisNegID_Filtro',fld:'vVISNEGID_FILTRO',pic:''},{av:'AV144VisNgfSeq_Filtro',fld:'vVISNGFSEQ_FILTRO',pic:'ZZ,ZZZ,ZZ9'},{av:'AV165VisDel_Filtro',fld:'vVISDEL_FILTRO',pic:''},{av:'AV57TFVisInsDataHora',fld:'vTFVISINSDATAHORA',pic:'99/99/9999 99:99:99.999'},{av:'AV58TFVisInsDataHora_To',fld:'vTFVISINSDATAHORA_TO',pic:'99/99/9999 99:99:99.999'},{av:'AV64TFVisInsUsuNome',fld:'vTFVISINSUSUNOME',pic:'@!'},{av:'AV65TFVisInsUsuNome_Sel',fld:'vTFVISINSUSUNOME_SEL',pic:'@!'},{av:'AV66TFVisData',fld:'vTFVISDATA',pic:''},{av:'AV67TFVisData_To',fld:'vTFVISDATA_TO',pic:''},{av:'AV71TFVisHora',fld:'vTFVISHORA',pic:'99:99'},{av:'AV72TFVisHora_To',fld:'vTFVISHORA_TO',pic:'99:99'},{av:'AV76TFVisDataHora',fld:'vTFVISDATAHORA',pic:'99/99/9999 99:99'},{av:'AV77TFVisDataHora_To',fld:'vTFVISDATAHORA_TO',pic:'99/99/9999 99:99'},{av:'AV146TFVisDataFim',fld:'vTFVISDATAFIM',pic:''},{av:'AV147TFVisDataFim_To',fld:'vTFVISDATAFIM_TO',pic:''},{av:'AV151TFVisHoraFim',fld:'vTFVISHORAFIM',pic:'99:99'},{av:'AV152TFVisHoraFim_To',fld:'vTFVISHORAFIM_TO',pic:'99:99'},{av:'AV156TFVisDataHoraFim',fld:'vTFVISDATAHORAFIM',pic:'99/99/9999 99:99'},{av:'AV157TFVisDataHoraFim_To',fld:'vTFVISDATAHORAFIM_TO',pic:'99/99/9999 99:99'},{av:'AV85TFVisTipoNome',fld:'vTFVISTIPONOME',pic:'@!'},{av:'AV86TFVisTipoNome_Sel',fld:'vTFVISTIPONOME_SEL',pic:'@!'},{av:'AV91TFVisAssunto',fld:'vTFVISASSUNTO',pic:''},{av:'AV92TFVisAssunto_Sel',fld:'vTFVISASSUNTO_SEL',pic:''},{av:'AV142TFVisSituacao_Sels',fld:'vTFVISSITUACAO_SELS',pic:''},{av:'AV93TFVisLink',fld:'vTFVISLINK',pic:''},{av:'AV94TFVisLink_Sel',fld:'vTFVISLINK_SEL',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV103IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV104IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV128IsAuthorized_RemarcarVisita',fld:'vISAUTHORIZED_REMARCARVISITA',pic:'',hsh:true},{av:'AV108IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]}");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","{handler:'E15562',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersoperatorvissituacao'},{av:'AV163DynamicFiltersOperatorVisSituacao',fld:'vDYNAMICFILTERSOPERATORVISSITUACAO',pic:'ZZZ9'},{av:'cmbavVissituacao'},{av:'AV164VisSituacao',fld:'vVISSITUACAO',pic:''},{av:'AV129VisNegID',fld:'vVISNEGID',pic:'',hsh:true},{av:'AV130VisNgfSeq',fld:'vVISNGFSEQ',pic:'ZZ,ZZZ,ZZ9',hsh:true},{av:'AV41ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV173Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV143VisNegID_Filtro',fld:'vVISNEGID_FILTRO',pic:''},{av:'AV144VisNgfSeq_Filtro',fld:'vVISNGFSEQ_FILTRO',pic:'ZZ,ZZZ,ZZ9'},{av:'AV165VisDel_Filtro',fld:'vVISDEL_FILTRO',pic:''},{av:'AV57TFVisInsDataHora',fld:'vTFVISINSDATAHORA',pic:'99/99/9999 99:99:99.999'},{av:'AV58TFVisInsDataHora_To',fld:'vTFVISINSDATAHORA_TO',pic:'99/99/9999 99:99:99.999'},{av:'AV64TFVisInsUsuNome',fld:'vTFVISINSUSUNOME',pic:'@!'},{av:'AV65TFVisInsUsuNome_Sel',fld:'vTFVISINSUSUNOME_SEL',pic:'@!'},{av:'AV66TFVisData',fld:'vTFVISDATA',pic:''},{av:'AV67TFVisData_To',fld:'vTFVISDATA_TO',pic:''},{av:'AV71TFVisHora',fld:'vTFVISHORA',pic:'99:99'},{av:'AV72TFVisHora_To',fld:'vTFVISHORA_TO',pic:'99:99'},{av:'AV76TFVisDataHora',fld:'vTFVISDATAHORA',pic:'99/99/9999 99:99'},{av:'AV77TFVisDataHora_To',fld:'vTFVISDATAHORA_TO',pic:'99/99/9999 99:99'},{av:'AV146TFVisDataFim',fld:'vTFVISDATAFIM',pic:''},{av:'AV147TFVisDataFim_To',fld:'vTFVISDATAFIM_TO',pic:''},{av:'AV151TFVisHoraFim',fld:'vTFVISHORAFIM',pic:'99:99'},{av:'AV152TFVisHoraFim_To',fld:'vTFVISHORAFIM_TO',pic:'99:99'},{av:'AV156TFVisDataHoraFim',fld:'vTFVISDATAHORAFIM',pic:'99/99/9999 99:99'},{av:'AV157TFVisDataHoraFim_To',fld:'vTFVISDATAHORAFIM_TO',pic:'99/99/9999 99:99'},{av:'AV85TFVisTipoNome',fld:'vTFVISTIPONOME',pic:'@!'},{av:'AV86TFVisTipoNome_Sel',fld:'vTFVISTIPONOME_SEL',pic:'@!'},{av:'AV91TFVisAssunto',fld:'vTFVISASSUNTO',pic:''},{av:'AV92TFVisAssunto_Sel',fld:'vTFVISASSUNTO_SEL',pic:''},{av:'AV142TFVisSituacao_Sels',fld:'vTFVISSITUACAO_SELS',pic:''},{av:'AV93TFVisLink',fld:'vTFVISLINK',pic:''},{av:'AV94TFVisLink_Sel',fld:'vTFVISLINK_SEL',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV103IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV104IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV128IsAuthorized_RemarcarVisita',fld:'vISAUTHORIZED_REMARCARVISITA',pic:'',hsh:true},{av:'AV108IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'Ddo_grid_Activeeventkey',ctrl:'DDO_GRID',prop:'ActiveEventKey'},{av:'Ddo_grid_Selectedvalue_get',ctrl:'DDO_GRID',prop:'SelectedValue_get'},{av:'Ddo_grid_Filteredtextto_get',ctrl:'DDO_GRID',prop:'FilteredTextTo_get'},{av:'Ddo_grid_Filteredtext_get',ctrl:'DDO_GRID',prop:'FilteredText_get'},{av:'Ddo_grid_Selectedcolumn',ctrl:'DDO_GRID',prop:'SelectedColumn'}]");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",",oparms:[{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV93TFVisLink',fld:'vTFVISLINK',pic:''},{av:'AV94TFVisLink_Sel',fld:'vTFVISLINK_SEL',pic:''},{av:'AV141TFVisSituacao_SelsJson',fld:'vTFVISSITUACAO_SELSJSON',pic:''},{av:'AV142TFVisSituacao_Sels',fld:'vTFVISSITUACAO_SELS',pic:''},{av:'AV91TFVisAssunto',fld:'vTFVISASSUNTO',pic:''},{av:'AV92TFVisAssunto_Sel',fld:'vTFVISASSUNTO_SEL',pic:''},{av:'AV85TFVisTipoNome',fld:'vTFVISTIPONOME',pic:'@!'},{av:'AV86TFVisTipoNome_Sel',fld:'vTFVISTIPONOME_SEL',pic:'@!'},{av:'AV156TFVisDataHoraFim',fld:'vTFVISDATAHORAFIM',pic:'99/99/9999 99:99'},{av:'AV157TFVisDataHoraFim_To',fld:'vTFVISDATAHORAFIM_TO',pic:'99/99/9999 99:99'},{av:'AV151TFVisHoraFim',fld:'vTFVISHORAFIM',pic:'99:99'},{av:'AV152TFVisHoraFim_To',fld:'vTFVISHORAFIM_TO',pic:'99:99'},{av:'AV146TFVisDataFim',fld:'vTFVISDATAFIM',pic:''},{av:'AV147TFVisDataFim_To',fld:'vTFVISDATAFIM_TO',pic:''},{av:'AV76TFVisDataHora',fld:'vTFVISDATAHORA',pic:'99/99/9999 99:99'},{av:'AV77TFVisDataHora_To',fld:'vTFVISDATAHORA_TO',pic:'99/99/9999 99:99'},{av:'AV71TFVisHora',fld:'vTFVISHORA',pic:'99:99'},{av:'AV72TFVisHora_To',fld:'vTFVISHORA_TO',pic:'99:99'},{av:'AV66TFVisData',fld:'vTFVISDATA',pic:''},{av:'AV67TFVisData_To',fld:'vTFVISDATA_TO',pic:''},{av:'AV64TFVisInsUsuNome',fld:'vTFVISINSUSUNOME',pic:'@!'},{av:'AV65TFVisInsUsuNome_Sel',fld:'vTFVISINSUSUNOME_SEL',pic:'@!'},{av:'AV57TFVisInsDataHora',fld:'vTFVISINSDATAHORA',pic:'99/99/9999 99:99:99.999'},{av:'AV58TFVisInsDataHora_To',fld:'vTFVISINSDATAHORA_TO',pic:'99/99/9999 99:99:99.999'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E21562',iparms:[{av:'AV103IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'A406VisDataHora',fld:'VISDATAHORA',pic:'99/99/9999 99:99'},{av:'AV104IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV128IsAuthorized_RemarcarVisita',fld:'vISAUTHORIZED_REMARCARVISITA',pic:'',hsh:true},{av:'cmbVisSituacao'},{av:'A472VisSituacao',fld:'VISSITUACAO',pic:''},{av:'A417VisLink',fld:'VISLINK',pic:''}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'cmbavGridactions'},{av:'AV102GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9'},{av:'edtVisLink_Linktarget',ctrl:'VISLINK',prop:'Linktarget'},{av:'edtVisLink_Link',ctrl:'VISLINK',prop:'Link'}]}");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED","{handler:'E16562',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersoperatorvissituacao'},{av:'AV163DynamicFiltersOperatorVisSituacao',fld:'vDYNAMICFILTERSOPERATORVISSITUACAO',pic:'ZZZ9'},{av:'cmbavVissituacao'},{av:'AV164VisSituacao',fld:'vVISSITUACAO',pic:''},{av:'AV129VisNegID',fld:'vVISNEGID',pic:'',hsh:true},{av:'AV130VisNgfSeq',fld:'vVISNGFSEQ',pic:'ZZ,ZZZ,ZZ9',hsh:true},{av:'AV41ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV173Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV143VisNegID_Filtro',fld:'vVISNEGID_FILTRO',pic:''},{av:'AV144VisNgfSeq_Filtro',fld:'vVISNGFSEQ_FILTRO',pic:'ZZ,ZZZ,ZZ9'},{av:'AV165VisDel_Filtro',fld:'vVISDEL_FILTRO',pic:''},{av:'AV57TFVisInsDataHora',fld:'vTFVISINSDATAHORA',pic:'99/99/9999 99:99:99.999'},{av:'AV58TFVisInsDataHora_To',fld:'vTFVISINSDATAHORA_TO',pic:'99/99/9999 99:99:99.999'},{av:'AV64TFVisInsUsuNome',fld:'vTFVISINSUSUNOME',pic:'@!'},{av:'AV65TFVisInsUsuNome_Sel',fld:'vTFVISINSUSUNOME_SEL',pic:'@!'},{av:'AV66TFVisData',fld:'vTFVISDATA',pic:''},{av:'AV67TFVisData_To',fld:'vTFVISDATA_TO',pic:''},{av:'AV71TFVisHora',fld:'vTFVISHORA',pic:'99:99'},{av:'AV72TFVisHora_To',fld:'vTFVISHORA_TO',pic:'99:99'},{av:'AV76TFVisDataHora',fld:'vTFVISDATAHORA',pic:'99/99/9999 99:99'},{av:'AV77TFVisDataHora_To',fld:'vTFVISDATAHORA_TO',pic:'99/99/9999 99:99'},{av:'AV146TFVisDataFim',fld:'vTFVISDATAFIM',pic:''},{av:'AV147TFVisDataFim_To',fld:'vTFVISDATAFIM_TO',pic:''},{av:'AV151TFVisHoraFim',fld:'vTFVISHORAFIM',pic:'99:99'},{av:'AV152TFVisHoraFim_To',fld:'vTFVISHORAFIM_TO',pic:'99:99'},{av:'AV156TFVisDataHoraFim',fld:'vTFVISDATAHORAFIM',pic:'99/99/9999 99:99'},{av:'AV157TFVisDataHoraFim_To',fld:'vTFVISDATAHORAFIM_TO',pic:'99/99/9999 99:99'},{av:'AV85TFVisTipoNome',fld:'vTFVISTIPONOME',pic:'@!'},{av:'AV86TFVisTipoNome_Sel',fld:'vTFVISTIPONOME_SEL',pic:'@!'},{av:'AV91TFVisAssunto',fld:'vTFVISASSUNTO',pic:''},{av:'AV92TFVisAssunto_Sel',fld:'vTFVISASSUNTO_SEL',pic:''},{av:'AV142TFVisSituacao_Sels',fld:'vTFVISSITUACAO_SELS',pic:''},{av:'AV93TFVisLink',fld:'vTFVISLINK',pic:''},{av:'AV94TFVisLink_Sel',fld:'vTFVISLINK_SEL',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV103IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV104IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV128IsAuthorized_RemarcarVisita',fld:'vISAUTHORIZED_REMARCARVISITA',pic:'',hsh:true},{av:'AV108IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'Ddo_gridcolumnsselector_Columnsselectorvalues',ctrl:'DDO_GRIDCOLUMNSSELECTOR',prop:'ColumnsSelectorValues'}]");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED",",oparms:[{av:'AV41ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtVisInsDataHora_Visible',ctrl:'VISINSDATAHORA',prop:'Visible'},{av:'edtVisInsUsuNome_Visible',ctrl:'VISINSUSUNOME',prop:'Visible'},{av:'edtVisData_Visible',ctrl:'VISDATA',prop:'Visible'},{av:'edtVisHora_Visible',ctrl:'VISHORA',prop:'Visible'},{av:'edtVisDataHora_Visible',ctrl:'VISDATAHORA',prop:'Visible'},{av:'edtVisDataFim_Visible',ctrl:'VISDATAFIM',prop:'Visible'},{av:'edtVisHoraFim_Visible',ctrl:'VISHORAFIM',prop:'Visible'},{av:'edtVisDataHoraFim_Visible',ctrl:'VISDATAHORAFIM',prop:'Visible'},{av:'edtVisTipoNome_Visible',ctrl:'VISTIPONOME',prop:'Visible'},{av:'edtVisAssunto_Visible',ctrl:'VISASSUNTO',prop:'Visible'},{av:'cmbVisSituacao'},{av:'edtVisLink_Visible',ctrl:'VISLINK',prop:'Visible'},{av:'AV99GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV100GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV101GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV103IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV104IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV128IsAuthorized_RemarcarVisita',fld:'vISAUTHORIZED_REMARCARVISITA',pic:'',hsh:true},{av:'AV108IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'}]}");
         setEventMetadata("VGRIDACTIONS.CLICK","{handler:'E22562',iparms:[{av:'cmbavGridactions'},{av:'AV102GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9'},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersoperatorvissituacao'},{av:'AV163DynamicFiltersOperatorVisSituacao',fld:'vDYNAMICFILTERSOPERATORVISSITUACAO',pic:'ZZZ9'},{av:'cmbavVissituacao'},{av:'AV164VisSituacao',fld:'vVISSITUACAO',pic:''},{av:'AV129VisNegID',fld:'vVISNEGID',pic:'',hsh:true},{av:'AV130VisNgfSeq',fld:'vVISNGFSEQ',pic:'ZZ,ZZZ,ZZ9',hsh:true},{av:'AV41ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV173Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV143VisNegID_Filtro',fld:'vVISNEGID_FILTRO',pic:''},{av:'AV144VisNgfSeq_Filtro',fld:'vVISNGFSEQ_FILTRO',pic:'ZZ,ZZZ,ZZ9'},{av:'AV165VisDel_Filtro',fld:'vVISDEL_FILTRO',pic:''},{av:'AV57TFVisInsDataHora',fld:'vTFVISINSDATAHORA',pic:'99/99/9999 99:99:99.999'},{av:'AV58TFVisInsDataHora_To',fld:'vTFVISINSDATAHORA_TO',pic:'99/99/9999 99:99:99.999'},{av:'AV64TFVisInsUsuNome',fld:'vTFVISINSUSUNOME',pic:'@!'},{av:'AV65TFVisInsUsuNome_Sel',fld:'vTFVISINSUSUNOME_SEL',pic:'@!'},{av:'AV66TFVisData',fld:'vTFVISDATA',pic:''},{av:'AV67TFVisData_To',fld:'vTFVISDATA_TO',pic:''},{av:'AV71TFVisHora',fld:'vTFVISHORA',pic:'99:99'},{av:'AV72TFVisHora_To',fld:'vTFVISHORA_TO',pic:'99:99'},{av:'AV76TFVisDataHora',fld:'vTFVISDATAHORA',pic:'99/99/9999 99:99'},{av:'AV77TFVisDataHora_To',fld:'vTFVISDATAHORA_TO',pic:'99/99/9999 99:99'},{av:'AV146TFVisDataFim',fld:'vTFVISDATAFIM',pic:''},{av:'AV147TFVisDataFim_To',fld:'vTFVISDATAFIM_TO',pic:''},{av:'AV151TFVisHoraFim',fld:'vTFVISHORAFIM',pic:'99:99'},{av:'AV152TFVisHoraFim_To',fld:'vTFVISHORAFIM_TO',pic:'99:99'},{av:'AV156TFVisDataHoraFim',fld:'vTFVISDATAHORAFIM',pic:'99/99/9999 99:99'},{av:'AV157TFVisDataHoraFim_To',fld:'vTFVISDATAHORAFIM_TO',pic:'99/99/9999 99:99'},{av:'AV85TFVisTipoNome',fld:'vTFVISTIPONOME',pic:'@!'},{av:'AV86TFVisTipoNome_Sel',fld:'vTFVISTIPONOME_SEL',pic:'@!'},{av:'AV91TFVisAssunto',fld:'vTFVISASSUNTO',pic:''},{av:'AV92TFVisAssunto_Sel',fld:'vTFVISASSUNTO_SEL',pic:''},{av:'AV142TFVisSituacao_Sels',fld:'vTFVISSITUACAO_SELS',pic:''},{av:'AV93TFVisLink',fld:'vTFVISLINK',pic:''},{av:'AV94TFVisLink_Sel',fld:'vTFVISLINK_SEL',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV103IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV104IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV128IsAuthorized_RemarcarVisita',fld:'vISAUTHORIZED_REMARCARVISITA',pic:'',hsh:true},{av:'AV108IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'A398VisID',fld:'VISID',pic:'',hsh:true},{av:'A419VisPaiID',fld:'VISPAIID',pic:'',hsh:true},{av:'A418VisNegID',fld:'VISNEGID',pic:'',hsh:true},{av:'A422VisNgfSeq',fld:'VISNGFSEQ',pic:'ZZ,ZZZ,ZZ9',hsh:true}]");
         setEventMetadata("VGRIDACTIONS.CLICK",",oparms:[{av:'cmbavGridactions'},{av:'AV102GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9'},{av:'AV166VisID_Selected',fld:'vVISID_SELECTED',pic:''},{av:'AV167VisNegID_Selected',fld:'vVISNEGID_SELECTED',pic:''},{av:'AV168VisNgfSeq_Selected',fld:'vVISNGFSEQ_SELECTED',pic:'ZZ,ZZZ,ZZ9'},{av:'AV41ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtVisInsDataHora_Visible',ctrl:'VISINSDATAHORA',prop:'Visible'},{av:'edtVisInsUsuNome_Visible',ctrl:'VISINSUSUNOME',prop:'Visible'},{av:'edtVisData_Visible',ctrl:'VISDATA',prop:'Visible'},{av:'edtVisHora_Visible',ctrl:'VISHORA',prop:'Visible'},{av:'edtVisDataHora_Visible',ctrl:'VISDATAHORA',prop:'Visible'},{av:'edtVisDataFim_Visible',ctrl:'VISDATAFIM',prop:'Visible'},{av:'edtVisHoraFim_Visible',ctrl:'VISHORAFIM',prop:'Visible'},{av:'edtVisDataHoraFim_Visible',ctrl:'VISDATAHORAFIM',prop:'Visible'},{av:'edtVisTipoNome_Visible',ctrl:'VISTIPONOME',prop:'Visible'},{av:'edtVisAssunto_Visible',ctrl:'VISASSUNTO',prop:'Visible'},{av:'cmbVisSituacao'},{av:'edtVisLink_Visible',ctrl:'VISLINK',prop:'Visible'},{av:'AV99GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV100GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV101GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV103IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV104IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV128IsAuthorized_RemarcarVisita',fld:'vISAUTHORIZED_REMARCARVISITA',pic:'',hsh:true},{av:'AV108IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'}]}");
         setEventMetadata("DVELOP_CONFIRMPANEL_DELETE.CLOSE","{handler:'E17562',iparms:[{av:'Dvelop_confirmpanel_delete_Result',ctrl:'DVELOP_CONFIRMPANEL_DELETE',prop:'Result'},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersoperatorvissituacao'},{av:'AV163DynamicFiltersOperatorVisSituacao',fld:'vDYNAMICFILTERSOPERATORVISSITUACAO',pic:'ZZZ9'},{av:'cmbavVissituacao'},{av:'AV164VisSituacao',fld:'vVISSITUACAO',pic:''},{av:'AV129VisNegID',fld:'vVISNEGID',pic:'',hsh:true},{av:'AV130VisNgfSeq',fld:'vVISNGFSEQ',pic:'ZZ,ZZZ,ZZ9',hsh:true},{av:'AV41ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV173Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV143VisNegID_Filtro',fld:'vVISNEGID_FILTRO',pic:''},{av:'AV144VisNgfSeq_Filtro',fld:'vVISNGFSEQ_FILTRO',pic:'ZZ,ZZZ,ZZ9'},{av:'AV165VisDel_Filtro',fld:'vVISDEL_FILTRO',pic:''},{av:'AV57TFVisInsDataHora',fld:'vTFVISINSDATAHORA',pic:'99/99/9999 99:99:99.999'},{av:'AV58TFVisInsDataHora_To',fld:'vTFVISINSDATAHORA_TO',pic:'99/99/9999 99:99:99.999'},{av:'AV64TFVisInsUsuNome',fld:'vTFVISINSUSUNOME',pic:'@!'},{av:'AV65TFVisInsUsuNome_Sel',fld:'vTFVISINSUSUNOME_SEL',pic:'@!'},{av:'AV66TFVisData',fld:'vTFVISDATA',pic:''},{av:'AV67TFVisData_To',fld:'vTFVISDATA_TO',pic:''},{av:'AV71TFVisHora',fld:'vTFVISHORA',pic:'99:99'},{av:'AV72TFVisHora_To',fld:'vTFVISHORA_TO',pic:'99:99'},{av:'AV76TFVisDataHora',fld:'vTFVISDATAHORA',pic:'99/99/9999 99:99'},{av:'AV77TFVisDataHora_To',fld:'vTFVISDATAHORA_TO',pic:'99/99/9999 99:99'},{av:'AV146TFVisDataFim',fld:'vTFVISDATAFIM',pic:''},{av:'AV147TFVisDataFim_To',fld:'vTFVISDATAFIM_TO',pic:''},{av:'AV151TFVisHoraFim',fld:'vTFVISHORAFIM',pic:'99:99'},{av:'AV152TFVisHoraFim_To',fld:'vTFVISHORAFIM_TO',pic:'99:99'},{av:'AV156TFVisDataHoraFim',fld:'vTFVISDATAHORAFIM',pic:'99/99/9999 99:99'},{av:'AV157TFVisDataHoraFim_To',fld:'vTFVISDATAHORAFIM_TO',pic:'99/99/9999 99:99'},{av:'AV85TFVisTipoNome',fld:'vTFVISTIPONOME',pic:'@!'},{av:'AV86TFVisTipoNome_Sel',fld:'vTFVISTIPONOME_SEL',pic:'@!'},{av:'AV91TFVisAssunto',fld:'vTFVISASSUNTO',pic:''},{av:'AV92TFVisAssunto_Sel',fld:'vTFVISASSUNTO_SEL',pic:''},{av:'AV142TFVisSituacao_Sels',fld:'vTFVISSITUACAO_SELS',pic:''},{av:'AV93TFVisLink',fld:'vTFVISLINK',pic:''},{av:'AV94TFVisLink_Sel',fld:'vTFVISLINK_SEL',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV103IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV104IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV128IsAuthorized_RemarcarVisita',fld:'vISAUTHORIZED_REMARCARVISITA',pic:'',hsh:true},{av:'AV108IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'AV166VisID_Selected',fld:'vVISID_SELECTED',pic:''},{av:'A419VisPaiID',fld:'VISPAIID',pic:'',hsh:true},{av:'AV167VisNegID_Selected',fld:'vVISNEGID_SELECTED',pic:''},{av:'AV168VisNgfSeq_Selected',fld:'vVISNGFSEQ_SELECTED',pic:'ZZ,ZZZ,ZZ9'}]");
         setEventMetadata("DVELOP_CONFIRMPANEL_DELETE.CLOSE",",oparms:[{av:'AV41ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtVisInsDataHora_Visible',ctrl:'VISINSDATAHORA',prop:'Visible'},{av:'edtVisInsUsuNome_Visible',ctrl:'VISINSUSUNOME',prop:'Visible'},{av:'edtVisData_Visible',ctrl:'VISDATA',prop:'Visible'},{av:'edtVisHora_Visible',ctrl:'VISHORA',prop:'Visible'},{av:'edtVisDataHora_Visible',ctrl:'VISDATAHORA',prop:'Visible'},{av:'edtVisDataFim_Visible',ctrl:'VISDATAFIM',prop:'Visible'},{av:'edtVisHoraFim_Visible',ctrl:'VISHORAFIM',prop:'Visible'},{av:'edtVisDataHoraFim_Visible',ctrl:'VISDATAHORAFIM',prop:'Visible'},{av:'edtVisTipoNome_Visible',ctrl:'VISTIPONOME',prop:'Visible'},{av:'edtVisAssunto_Visible',ctrl:'VISASSUNTO',prop:'Visible'},{av:'cmbVisSituacao'},{av:'edtVisLink_Visible',ctrl:'VISLINK',prop:'Visible'},{av:'AV99GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV100GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV101GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV103IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV104IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV128IsAuthorized_RemarcarVisita',fld:'vISAUTHORIZED_REMARCARVISITA',pic:'',hsh:true},{av:'AV108IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'}]}");
         setEventMetadata("'DOINSERT'","{handler:'E18562',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavDynamicfiltersoperatorvissituacao'},{av:'AV163DynamicFiltersOperatorVisSituacao',fld:'vDYNAMICFILTERSOPERATORVISSITUACAO',pic:'ZZZ9'},{av:'cmbavVissituacao'},{av:'AV164VisSituacao',fld:'vVISSITUACAO',pic:''},{av:'AV129VisNegID',fld:'vVISNEGID',pic:'',hsh:true},{av:'AV130VisNgfSeq',fld:'vVISNGFSEQ',pic:'ZZ,ZZZ,ZZ9',hsh:true},{av:'AV41ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV173Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV143VisNegID_Filtro',fld:'vVISNEGID_FILTRO',pic:''},{av:'AV144VisNgfSeq_Filtro',fld:'vVISNGFSEQ_FILTRO',pic:'ZZ,ZZZ,ZZ9'},{av:'AV165VisDel_Filtro',fld:'vVISDEL_FILTRO',pic:''},{av:'AV57TFVisInsDataHora',fld:'vTFVISINSDATAHORA',pic:'99/99/9999 99:99:99.999'},{av:'AV58TFVisInsDataHora_To',fld:'vTFVISINSDATAHORA_TO',pic:'99/99/9999 99:99:99.999'},{av:'AV64TFVisInsUsuNome',fld:'vTFVISINSUSUNOME',pic:'@!'},{av:'AV65TFVisInsUsuNome_Sel',fld:'vTFVISINSUSUNOME_SEL',pic:'@!'},{av:'AV66TFVisData',fld:'vTFVISDATA',pic:''},{av:'AV67TFVisData_To',fld:'vTFVISDATA_TO',pic:''},{av:'AV71TFVisHora',fld:'vTFVISHORA',pic:'99:99'},{av:'AV72TFVisHora_To',fld:'vTFVISHORA_TO',pic:'99:99'},{av:'AV76TFVisDataHora',fld:'vTFVISDATAHORA',pic:'99/99/9999 99:99'},{av:'AV77TFVisDataHora_To',fld:'vTFVISDATAHORA_TO',pic:'99/99/9999 99:99'},{av:'AV146TFVisDataFim',fld:'vTFVISDATAFIM',pic:''},{av:'AV147TFVisDataFim_To',fld:'vTFVISDATAFIM_TO',pic:''},{av:'AV151TFVisHoraFim',fld:'vTFVISHORAFIM',pic:'99:99'},{av:'AV152TFVisHoraFim_To',fld:'vTFVISHORAFIM_TO',pic:'99:99'},{av:'AV156TFVisDataHoraFim',fld:'vTFVISDATAHORAFIM',pic:'99/99/9999 99:99'},{av:'AV157TFVisDataHoraFim_To',fld:'vTFVISDATAHORAFIM_TO',pic:'99/99/9999 99:99'},{av:'AV85TFVisTipoNome',fld:'vTFVISTIPONOME',pic:'@!'},{av:'AV86TFVisTipoNome_Sel',fld:'vTFVISTIPONOME_SEL',pic:'@!'},{av:'AV91TFVisAssunto',fld:'vTFVISASSUNTO',pic:''},{av:'AV92TFVisAssunto_Sel',fld:'vTFVISASSUNTO_SEL',pic:''},{av:'AV142TFVisSituacao_Sels',fld:'vTFVISSITUACAO_SELS',pic:''},{av:'AV93TFVisLink',fld:'vTFVISLINK',pic:''},{av:'AV94TFVisLink_Sel',fld:'vTFVISLINK_SEL',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV103IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV104IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV128IsAuthorized_RemarcarVisita',fld:'vISAUTHORIZED_REMARCARVISITA',pic:'',hsh:true},{av:'AV108IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'A398VisID',fld:'VISID',pic:'',hsh:true},{av:'A419VisPaiID',fld:'VISPAIID',pic:'',hsh:true}]");
         setEventMetadata("'DOINSERT'",",oparms:[{av:'AV41ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtVisInsDataHora_Visible',ctrl:'VISINSDATAHORA',prop:'Visible'},{av:'edtVisInsUsuNome_Visible',ctrl:'VISINSUSUNOME',prop:'Visible'},{av:'edtVisData_Visible',ctrl:'VISDATA',prop:'Visible'},{av:'edtVisHora_Visible',ctrl:'VISHORA',prop:'Visible'},{av:'edtVisDataHora_Visible',ctrl:'VISDATAHORA',prop:'Visible'},{av:'edtVisDataFim_Visible',ctrl:'VISDATAFIM',prop:'Visible'},{av:'edtVisHoraFim_Visible',ctrl:'VISHORAFIM',prop:'Visible'},{av:'edtVisDataHoraFim_Visible',ctrl:'VISDATAHORAFIM',prop:'Visible'},{av:'edtVisTipoNome_Visible',ctrl:'VISTIPONOME',prop:'Visible'},{av:'edtVisAssunto_Visible',ctrl:'VISASSUNTO',prop:'Visible'},{av:'cmbVisSituacao'},{av:'edtVisLink_Visible',ctrl:'VISLINK',prop:'Visible'},{av:'AV99GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV100GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV101GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV103IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV104IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV128IsAuthorized_RemarcarVisita',fld:'vISAUTHORIZED_REMARCARVISITA',pic:'',hsh:true},{av:'AV108IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'}]}");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED","{handler:'E13562',iparms:[{av:'Ddo_agexport_Activeeventkey',ctrl:'DDO_AGEXPORT',prop:'ActiveEventKey'}]");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED",",oparms:[{av:'Innewwindow1_Target',ctrl:'INNEWWINDOW1',prop:'Target'},{av:'Innewwindow1_Height',ctrl:'INNEWWINDOW1',prop:'Height'},{av:'Innewwindow1_Width',ctrl:'INNEWWINDOW1',prop:'Width'}]}");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT","{handler:'E14562',iparms:[]");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT",",oparms:[{ctrl:'WWPAUX_WC'}]}");
         setEventMetadata("VALIDV_VISNEGID_FILTRO","{handler:'Validv_Visnegid_filtro',iparms:[]");
         setEventMetadata("VALIDV_VISNEGID_FILTRO",",oparms:[]}");
         setEventMetadata("VALIDV_VISSITUACAO","{handler:'Validv_Vissituacao',iparms:[]");
         setEventMetadata("VALIDV_VISSITUACAO",",oparms:[]}");
         setEventMetadata("VALIDV_VISNEGID","{handler:'Validv_Visnegid',iparms:[]");
         setEventMetadata("VALIDV_VISNEGID",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Visngfseq',iparms:[]");
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
         wcpOAV129VisNegID = Guid.Empty;
         Gridpaginationbar_Selectedpage = "";
         Ddo_grid_Activeeventkey = "";
         Ddo_grid_Selectedvalue_get = "";
         Ddo_grid_Filteredtextto_get = "";
         Ddo_grid_Filteredtext_get = "";
         Ddo_grid_Selectedcolumn = "";
         Ddo_gridcolumnsselector_Columnsselectorvalues = "";
         Dvelop_confirmpanel_delete_Result = "";
         Ddo_agexport_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV164VisSituacao = "PEN";
         AV41ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV173Pgmname = "";
         AV143VisNegID_Filtro = Guid.Empty;
         AV57TFVisInsDataHora = (DateTime)(DateTime.MinValue);
         AV58TFVisInsDataHora_To = (DateTime)(DateTime.MinValue);
         AV64TFVisInsUsuNome = "";
         AV65TFVisInsUsuNome_Sel = "";
         AV66TFVisData = DateTime.MinValue;
         AV67TFVisData_To = DateTime.MinValue;
         AV71TFVisHora = (DateTime)(DateTime.MinValue);
         AV72TFVisHora_To = (DateTime)(DateTime.MinValue);
         AV76TFVisDataHora = (DateTime)(DateTime.MinValue);
         AV77TFVisDataHora_To = (DateTime)(DateTime.MinValue);
         AV146TFVisDataFim = DateTime.MinValue;
         AV147TFVisDataFim_To = DateTime.MinValue;
         AV151TFVisHoraFim = (DateTime)(DateTime.MinValue);
         AV152TFVisHoraFim_To = (DateTime)(DateTime.MinValue);
         AV156TFVisDataHoraFim = (DateTime)(DateTime.MinValue);
         AV157TFVisDataHoraFim_To = (DateTime)(DateTime.MinValue);
         AV85TFVisTipoNome = "";
         AV86TFVisTipoNome_Sel = "";
         AV91TFVisAssunto = "";
         AV92TFVisAssunto_Sel = "";
         AV142TFVisSituacao_Sels = new GxSimpleCollection<string>();
         AV93TFVisLink = "";
         AV94TFVisLink_Sel = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV101GridAppliedFilters = "";
         AV106AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV95DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV59DDO_VisInsDataHoraAuxDate = DateTime.MinValue;
         AV60DDO_VisInsDataHoraAuxDateTo = DateTime.MinValue;
         AV68DDO_VisDataAuxDate = DateTime.MinValue;
         AV69DDO_VisDataAuxDateTo = DateTime.MinValue;
         AV73DDO_VisHoraAuxDate = DateTime.MinValue;
         AV74DDO_VisHoraAuxDateTo = DateTime.MinValue;
         AV78DDO_VisDataHoraAuxDate = DateTime.MinValue;
         AV79DDO_VisDataHoraAuxDateTo = DateTime.MinValue;
         AV148DDO_VisDataFimAuxDate = DateTime.MinValue;
         AV149DDO_VisDataFimAuxDateTo = DateTime.MinValue;
         AV153DDO_VisHoraFimAuxDate = DateTime.MinValue;
         AV154DDO_VisHoraFimAuxDateTo = DateTime.MinValue;
         AV158DDO_VisDataHoraFimAuxDate = DateTime.MinValue;
         AV159DDO_VisDataHoraFimAuxDateTo = DateTime.MinValue;
         AV166VisID_Selected = Guid.Empty;
         AV167VisNegID_Selected = Guid.Empty;
         Ddo_agexport_Caption = "";
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Filteredtextto_set = "";
         Ddo_grid_Selectedvalue_set = "";
         Ddo_grid_Gamoauthtoken = "";
         Ddo_grid_Sortedstatus = "";
         Ddo_gridcolumnsselector_Gridinternalname = "";
         Grid_titlescategories_Gridinternalname = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         TempTags = "";
         ucDvpanel_tableoportunidade = new GXUserControl();
         WebComp_Wcnegociopjgeneral_Component = "";
         OldWcnegociopjgeneral = "";
         ClassString = "";
         StyleString = "";
         bttBtncancel_Jsonclick = "";
         bttBtninsert_Jsonclick = "";
         bttBtnagexport_Jsonclick = "";
         bttBtneditcolumns_Jsonclick = "";
         bttBtnsubscriptions_Jsonclick = "";
         AV161NegUltIteNome = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridpaginationbar = new GXUserControl();
         ucDdo_agexport = new GXUserControl();
         ucDdc_subscriptions = new GXUserControl();
         ucDdo_grid = new GXUserControl();
         ucInnewwindow1 = new GXUserControl();
         ucDdo_gridcolumnsselector = new GXUserControl();
         ucGrid_titlescategories = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         WebComp_Wwpaux_wc_Component = "";
         OldWwpaux_wc = "";
         AV61DDO_VisInsDataHoraAuxDateText = "";
         ucTfvisinsdatahora_rangepicker = new GXUserControl();
         AV70DDO_VisDataAuxDateText = "";
         ucTfvisdata_rangepicker = new GXUserControl();
         AV75DDO_VisHoraAuxDateText = "";
         ucTfvishora_rangepicker = new GXUserControl();
         AV80DDO_VisDataHoraAuxDateText = "";
         ucTfvisdatahora_rangepicker = new GXUserControl();
         AV150DDO_VisDataFimAuxDateText = "";
         ucTfvisdatafim_rangepicker = new GXUserControl();
         AV155DDO_VisHoraFimAuxDateText = "";
         ucTfvishorafim_rangepicker = new GXUserControl();
         AV160DDO_VisDataHoraFimAuxDateText = "";
         ucTfvisdatahorafim_rangepicker = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A401VisInsDataHora = (DateTime)(DateTime.MinValue);
         A403VisInsUsuNome = "";
         A404VisData = DateTime.MinValue;
         A405VisHora = (DateTime)(DateTime.MinValue);
         A406VisDataHora = (DateTime)(DateTime.MinValue);
         A475VisDataFim = DateTime.MinValue;
         A476VisHoraFim = (DateTime)(DateTime.MinValue);
         A477VisDataHoraFim = (DateTime)(DateTime.MinValue);
         A416VisTipoNome = "";
         A409VisAssunto = "";
         A472VisSituacao = "";
         A417VisLink = "";
         A398VisID = Guid.Empty;
         A419VisPaiID = Guid.Empty;
         A418VisNegID = Guid.Empty;
         GXDecQS = "";
         AV199Core_visitawwds_26_tfvissituacao_sels = new GxSimpleCollection<string>();
         scmdbuf = "";
         lV181Core_visitawwds_8_tfvisinsusunome = "";
         lV195Core_visitawwds_22_tfvistiponome = "";
         lV197Core_visitawwds_24_tfvisassunto = "";
         lV200Core_visitawwds_27_tfvislink = "";
         AV177Core_visitawwds_4_vissituacao = "";
         AV179Core_visitawwds_6_tfvisinsdatahora = (DateTime)(DateTime.MinValue);
         AV180Core_visitawwds_7_tfvisinsdatahora_to = (DateTime)(DateTime.MinValue);
         AV182Core_visitawwds_9_tfvisinsusunome_sel = "";
         AV181Core_visitawwds_8_tfvisinsusunome = "";
         AV183Core_visitawwds_10_tfvisdata = DateTime.MinValue;
         AV184Core_visitawwds_11_tfvisdata_to = DateTime.MinValue;
         AV185Core_visitawwds_12_tfvishora = (DateTime)(DateTime.MinValue);
         AV186Core_visitawwds_13_tfvishora_to = (DateTime)(DateTime.MinValue);
         AV187Core_visitawwds_14_tfvisdatahora = (DateTime)(DateTime.MinValue);
         AV188Core_visitawwds_15_tfvisdatahora_to = (DateTime)(DateTime.MinValue);
         AV189Core_visitawwds_16_tfvisdatafim = DateTime.MinValue;
         AV190Core_visitawwds_17_tfvisdatafim_to = DateTime.MinValue;
         AV191Core_visitawwds_18_tfvishorafim = (DateTime)(DateTime.MinValue);
         AV192Core_visitawwds_19_tfvishorafim_to = (DateTime)(DateTime.MinValue);
         AV193Core_visitawwds_20_tfvisdatahorafim = (DateTime)(DateTime.MinValue);
         AV194Core_visitawwds_21_tfvisdatahorafim_to = (DateTime)(DateTime.MinValue);
         AV196Core_visitawwds_23_tfvistiponome_sel = "";
         AV195Core_visitawwds_22_tfvistiponome = "";
         AV198Core_visitawwds_25_tfvisassunto_sel = "";
         AV197Core_visitawwds_24_tfvisassunto = "";
         AV201Core_visitawwds_28_tfvislink_sel = "";
         AV200Core_visitawwds_27_tfvislink = "";
         H00562_A414VisTipoID = new int[1] ;
         H00562_A487VisDel = new bool[] {false} ;
         H00562_A422VisNgfSeq = new int[1] ;
         H00562_n422VisNgfSeq = new bool[] {false} ;
         H00562_A418VisNegID = new Guid[] {Guid.Empty} ;
         H00562_n418VisNegID = new bool[] {false} ;
         H00562_A419VisPaiID = new Guid[] {Guid.Empty} ;
         H00562_n419VisPaiID = new bool[] {false} ;
         H00562_A398VisID = new Guid[] {Guid.Empty} ;
         H00562_A417VisLink = new string[] {""} ;
         H00562_n417VisLink = new bool[] {false} ;
         H00562_A472VisSituacao = new string[] {""} ;
         H00562_A409VisAssunto = new string[] {""} ;
         H00562_A416VisTipoNome = new string[] {""} ;
         H00562_A477VisDataHoraFim = new DateTime[] {DateTime.MinValue} ;
         H00562_n477VisDataHoraFim = new bool[] {false} ;
         H00562_A476VisHoraFim = new DateTime[] {DateTime.MinValue} ;
         H00562_n476VisHoraFim = new bool[] {false} ;
         H00562_A475VisDataFim = new DateTime[] {DateTime.MinValue} ;
         H00562_n475VisDataFim = new bool[] {false} ;
         H00562_A406VisDataHora = new DateTime[] {DateTime.MinValue} ;
         H00562_A405VisHora = new DateTime[] {DateTime.MinValue} ;
         H00562_A404VisData = new DateTime[] {DateTime.MinValue} ;
         H00562_A403VisInsUsuNome = new string[] {""} ;
         H00562_n403VisInsUsuNome = new bool[] {false} ;
         H00562_A401VisInsDataHora = new DateTime[] {DateTime.MinValue} ;
         AV174Core_visitawwds_1_visnegid_filtro = Guid.Empty;
         H00563_AGRID_nRecordCount = new long[1] ;
         AV107AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV96GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV97GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV8HTTPRequest = new GxHttpRequest( context);
         H00564_A345NegID = new Guid[] {Guid.Empty} ;
         H00564_A362NegAssunto = new string[] {""} ;
         H00564_A356NegCodigo = new long[1] ;
         H00564_A421NegUltIteNome = new string[] {""} ;
         A345NegID = Guid.Empty;
         A362NegAssunto = "";
         A421NegUltIteNome = "";
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV43Session = context.GetSession();
         AV39ColumnsSelectorXML = "";
         AV141TFVisSituacao_SelsJson = "";
         GridRow = new GXWebRow();
         AV40UserCustomValue = "";
         AV42ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV169sdtVisita = new GeneXus.Programs.core.SdtsdtVisita(context);
         AV170Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV171Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV11GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV12GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char2 = "";
         GXt_char7 = "";
         GXt_char6 = "";
         GXt_char5 = "";
         GXt_char4 = "";
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV37ExcelFilename = "";
         AV38ErrorMessage = "";
         ucDvelop_confirmpanel_delete = new GXUserControl();
         lblDynamicfiltersprefixvissituacao_Jsonclick = "";
         lblDynamicfiltersfixedfiltercaptionvissituacao_Jsonclick = "";
         lblDynamicfiltersmiddlevissituacao_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         GXCCtl = "";
         ROClassString = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.visitaww__default(),
            new Object[][] {
                new Object[] {
               H00562_A414VisTipoID, H00562_A487VisDel, H00562_A422VisNgfSeq, H00562_n422VisNgfSeq, H00562_A418VisNegID, H00562_n418VisNegID, H00562_A419VisPaiID, H00562_n419VisPaiID, H00562_A398VisID, H00562_A417VisLink,
               H00562_n417VisLink, H00562_A472VisSituacao, H00562_A409VisAssunto, H00562_A416VisTipoNome, H00562_A477VisDataHoraFim, H00562_n477VisDataHoraFim, H00562_A476VisHoraFim, H00562_n476VisHoraFim, H00562_A475VisDataFim, H00562_n475VisDataFim,
               H00562_A406VisDataHora, H00562_A405VisHora, H00562_A404VisData, H00562_A403VisInsUsuNome, H00562_n403VisInsUsuNome, H00562_A401VisInsDataHora
               }
               , new Object[] {
               H00563_AGRID_nRecordCount
               }
               , new Object[] {
               H00564_A345NegID, H00564_A362NegAssunto, H00564_A356NegCodigo, H00564_A421NegUltIteNome
               }
            }
         );
         WebComp_Wcnegociopjgeneral = new GeneXus.Http.GXNullWebComponent();
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         AV173Pgmname = "core.VisitaWW";
         /* GeneXus formulas. */
         AV173Pgmname = "core.VisitaWW";
         edtavNegultitenome_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV163DynamicFiltersOperatorVisSituacao ;
      private short AV14OrderedBy ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV102GridActions ;
      private short nCmpId ;
      private short nDonePA ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short AV178Core_visitawwds_5_dynamicfiltersoperatorvissituacao ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int AV130VisNgfSeq ;
      private int wcpOAV130VisNgfSeq ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_81 ;
      private int nGXsfl_81_idx=1 ;
      private int AV144VisNgfSeq_Filtro ;
      private int AV168VisNgfSeq_Selected ;
      private int Gridpaginationbar_Pagestoshow ;
      private int edtavVisnegid_filtro_Enabled ;
      private int edtavVisngfseq_filtro_Enabled ;
      private int edtavVisdel_filtro_Enabled ;
      private int bttBtninsert_Visible ;
      private int bttBtnsubscriptions_Visible ;
      private int edtavNegultitenome_Enabled ;
      private int AV162NegUltNgfSeq ;
      private int edtavNegultngfseq_Visible ;
      private int edtavVisnegid_Visible ;
      private int edtavVisngfseq_Visible ;
      private int A422VisNgfSeq ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int AV199Core_visitawwds_26_tfvissituacao_sels_Count ;
      private int A414VisTipoID ;
      private int AV175Core_visitawwds_2_visngfseq_filtro ;
      private int edtVisInsDataHora_Visible ;
      private int edtVisInsUsuNome_Visible ;
      private int edtVisData_Visible ;
      private int edtVisHora_Visible ;
      private int edtVisDataHora_Visible ;
      private int edtVisDataFim_Visible ;
      private int edtVisHoraFim_Visible ;
      private int edtVisDataHoraFim_Visible ;
      private int edtVisTipoNome_Visible ;
      private int edtVisAssunto_Visible ;
      private int edtVisLink_Visible ;
      private int AV98PageToGo ;
      private int AV202GXV1 ;
      private int AV203GXV2 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV99GridCurrentPage ;
      private long AV100GridPageCount ;
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
      private string Dvelop_confirmpanel_delete_Result ;
      private string Ddo_agexport_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_81_idx="0001" ;
      private string AV173Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string Dvpanel_tableoportunidade_Width ;
      private string Dvpanel_tableoportunidade_Cls ;
      private string Dvpanel_tableoportunidade_Title ;
      private string Dvpanel_tableoportunidade_Iconposition ;
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
      private string Ddo_grid_Allowmultipleselection ;
      private string Ddo_grid_Datalistfixedvalues ;
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
      private string Dvelop_confirmpanel_delete_Title ;
      private string Dvelop_confirmpanel_delete_Confirmationtext ;
      private string Dvelop_confirmpanel_delete_Yesbuttoncaption ;
      private string Dvelop_confirmpanel_delete_Nobuttoncaption ;
      private string Dvelop_confirmpanel_delete_Cancelbuttoncaption ;
      private string Dvelop_confirmpanel_delete_Yesbuttonposition ;
      private string Dvelop_confirmpanel_delete_Confirmtype ;
      private string Grid_titlescategories_Gridinternalname ;
      private string Grid_titlescategories_Gridtitlescategories ;
      private string Grid_empowerer_Gridinternalname ;
      private string Grid_empowerer_Fixedcolumns ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string edtavVisnegid_filtro_Internalname ;
      private string TempTags ;
      private string edtavVisnegid_filtro_Jsonclick ;
      private string edtavVisngfseq_filtro_Internalname ;
      private string edtavVisngfseq_filtro_Jsonclick ;
      private string edtavVisdel_filtro_Internalname ;
      private string edtavVisdel_filtro_Jsonclick ;
      private string Dvpanel_tableoportunidade_Internalname ;
      private string divTableoportunidade_Internalname ;
      private string WebComp_Wcnegociopjgeneral_Component ;
      private string OldWcnegociopjgeneral ;
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
      private string edtavNegultitenome_Internalname ;
      private string edtavNegultitenome_Jsonclick ;
      private string divGridtablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string Gridpaginationbar_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Ddo_agexport_Internalname ;
      private string Ddc_subscriptions_Internalname ;
      private string Ddo_grid_Internalname ;
      private string Innewwindow1_Internalname ;
      private string Ddo_gridcolumnsselector_Internalname ;
      private string edtavNegultngfseq_Internalname ;
      private string edtavNegultngfseq_Jsonclick ;
      private string edtavVisnegid_Internalname ;
      private string edtavVisnegid_Jsonclick ;
      private string edtavVisngfseq_Internalname ;
      private string edtavVisngfseq_Jsonclick ;
      private string Grid_titlescategories_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string divDiv_wwpauxwc_Internalname ;
      private string WebComp_Wwpaux_wc_Component ;
      private string OldWwpaux_wc ;
      private string divDdo_visinsdatahoraauxdates_Internalname ;
      private string edtavDdo_visinsdatahoraauxdatetext_Internalname ;
      private string edtavDdo_visinsdatahoraauxdatetext_Jsonclick ;
      private string Tfvisinsdatahora_rangepicker_Internalname ;
      private string divDdo_visdataauxdates_Internalname ;
      private string edtavDdo_visdataauxdatetext_Internalname ;
      private string edtavDdo_visdataauxdatetext_Jsonclick ;
      private string Tfvisdata_rangepicker_Internalname ;
      private string divDdo_vishoraauxdates_Internalname ;
      private string edtavDdo_vishoraauxdatetext_Internalname ;
      private string edtavDdo_vishoraauxdatetext_Jsonclick ;
      private string Tfvishora_rangepicker_Internalname ;
      private string divDdo_visdatahoraauxdates_Internalname ;
      private string edtavDdo_visdatahoraauxdatetext_Internalname ;
      private string edtavDdo_visdatahoraauxdatetext_Jsonclick ;
      private string Tfvisdatahora_rangepicker_Internalname ;
      private string divDdo_visdatafimauxdates_Internalname ;
      private string edtavDdo_visdatafimauxdatetext_Internalname ;
      private string edtavDdo_visdatafimauxdatetext_Jsonclick ;
      private string Tfvisdatafim_rangepicker_Internalname ;
      private string divDdo_vishorafimauxdates_Internalname ;
      private string edtavDdo_vishorafimauxdatetext_Internalname ;
      private string edtavDdo_vishorafimauxdatetext_Jsonclick ;
      private string Tfvishorafim_rangepicker_Internalname ;
      private string divDdo_visdatahorafimauxdates_Internalname ;
      private string edtavDdo_visdatahorafimauxdatetext_Internalname ;
      private string edtavDdo_visdatahorafimauxdatetext_Jsonclick ;
      private string Tfvisdatahorafim_rangepicker_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string cmbavGridactions_Internalname ;
      private string edtVisInsDataHora_Internalname ;
      private string edtVisInsUsuNome_Internalname ;
      private string edtVisData_Internalname ;
      private string edtVisHora_Internalname ;
      private string edtVisDataHora_Internalname ;
      private string edtVisDataFim_Internalname ;
      private string edtVisHoraFim_Internalname ;
      private string edtVisDataHoraFim_Internalname ;
      private string edtVisTipoNome_Internalname ;
      private string edtVisAssunto_Internalname ;
      private string cmbVisSituacao_Internalname ;
      private string edtVisLink_Internalname ;
      private string edtVisID_Internalname ;
      private string edtVisPaiID_Internalname ;
      private string edtVisNegID_Internalname ;
      private string edtVisNgfSeq_Internalname ;
      private string GXDecQS ;
      private string cmbavDynamicfiltersoperatorvissituacao_Internalname ;
      private string cmbavVissituacao_Internalname ;
      private string scmdbuf ;
      private string cmbavGridactions_Class ;
      private string edtVisLink_Linktarget ;
      private string edtVisLink_Link ;
      private string GXt_char2 ;
      private string GXt_char7 ;
      private string GXt_char6 ;
      private string GXt_char5 ;
      private string GXt_char4 ;
      private string tblTabledvelop_confirmpanel_delete_Internalname ;
      private string Dvelop_confirmpanel_delete_Internalname ;
      private string tblTablerightheader_Internalname ;
      private string divTabledynamicfilters_Internalname ;
      private string divTabledynamicfiltersrowvissituacao_Internalname ;
      private string lblDynamicfiltersprefixvissituacao_Internalname ;
      private string lblDynamicfiltersprefixvissituacao_Jsonclick ;
      private string lblDynamicfiltersfixedfiltercaptionvissituacao_Internalname ;
      private string lblDynamicfiltersfixedfiltercaptionvissituacao_Jsonclick ;
      private string lblDynamicfiltersmiddlevissituacao_Internalname ;
      private string lblDynamicfiltersmiddlevissituacao_Jsonclick ;
      private string tblTablemergeddynamicfiltersvissituacao_Internalname ;
      private string cmbavDynamicfiltersoperatorvissituacao_Jsonclick ;
      private string cmbavVissituacao_Jsonclick ;
      private string sGXsfl_81_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string GXCCtl ;
      private string cmbavGridactions_Jsonclick ;
      private string ROClassString ;
      private string edtVisInsDataHora_Jsonclick ;
      private string edtVisInsUsuNome_Jsonclick ;
      private string edtVisData_Jsonclick ;
      private string edtVisHora_Jsonclick ;
      private string edtVisDataHora_Jsonclick ;
      private string edtVisDataFim_Jsonclick ;
      private string edtVisHoraFim_Jsonclick ;
      private string edtVisDataHoraFim_Jsonclick ;
      private string edtVisTipoNome_Jsonclick ;
      private string edtVisAssunto_Jsonclick ;
      private string cmbVisSituacao_Jsonclick ;
      private string edtVisLink_Jsonclick ;
      private string edtVisID_Jsonclick ;
      private string edtVisPaiID_Jsonclick ;
      private string edtVisNegID_Jsonclick ;
      private string edtVisNgfSeq_Jsonclick ;
      private string subGrid_Header ;
      private DateTime AV57TFVisInsDataHora ;
      private DateTime AV58TFVisInsDataHora_To ;
      private DateTime AV71TFVisHora ;
      private DateTime AV72TFVisHora_To ;
      private DateTime AV76TFVisDataHora ;
      private DateTime AV77TFVisDataHora_To ;
      private DateTime AV151TFVisHoraFim ;
      private DateTime AV152TFVisHoraFim_To ;
      private DateTime AV156TFVisDataHoraFim ;
      private DateTime AV157TFVisDataHoraFim_To ;
      private DateTime A401VisInsDataHora ;
      private DateTime A405VisHora ;
      private DateTime A406VisDataHora ;
      private DateTime A476VisHoraFim ;
      private DateTime A477VisDataHoraFim ;
      private DateTime AV179Core_visitawwds_6_tfvisinsdatahora ;
      private DateTime AV180Core_visitawwds_7_tfvisinsdatahora_to ;
      private DateTime AV185Core_visitawwds_12_tfvishora ;
      private DateTime AV186Core_visitawwds_13_tfvishora_to ;
      private DateTime AV187Core_visitawwds_14_tfvisdatahora ;
      private DateTime AV188Core_visitawwds_15_tfvisdatahora_to ;
      private DateTime AV191Core_visitawwds_18_tfvishorafim ;
      private DateTime AV192Core_visitawwds_19_tfvishorafim_to ;
      private DateTime AV193Core_visitawwds_20_tfvisdatahorafim ;
      private DateTime AV194Core_visitawwds_21_tfvisdatahorafim_to ;
      private DateTime AV66TFVisData ;
      private DateTime AV67TFVisData_To ;
      private DateTime AV146TFVisDataFim ;
      private DateTime AV147TFVisDataFim_To ;
      private DateTime AV59DDO_VisInsDataHoraAuxDate ;
      private DateTime AV60DDO_VisInsDataHoraAuxDateTo ;
      private DateTime AV68DDO_VisDataAuxDate ;
      private DateTime AV69DDO_VisDataAuxDateTo ;
      private DateTime AV73DDO_VisHoraAuxDate ;
      private DateTime AV74DDO_VisHoraAuxDateTo ;
      private DateTime AV78DDO_VisDataHoraAuxDate ;
      private DateTime AV79DDO_VisDataHoraAuxDateTo ;
      private DateTime AV148DDO_VisDataFimAuxDate ;
      private DateTime AV149DDO_VisDataFimAuxDateTo ;
      private DateTime AV153DDO_VisHoraFimAuxDate ;
      private DateTime AV154DDO_VisHoraFimAuxDateTo ;
      private DateTime AV158DDO_VisDataHoraFimAuxDate ;
      private DateTime AV159DDO_VisDataHoraFimAuxDateTo ;
      private DateTime A404VisData ;
      private DateTime A475VisDataFim ;
      private DateTime AV183Core_visitawwds_10_tfvisdata ;
      private DateTime AV184Core_visitawwds_11_tfvisdata_to ;
      private DateTime AV189Core_visitawwds_16_tfvisdatafim ;
      private DateTime AV190Core_visitawwds_17_tfvisdatafim_to ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV165VisDel_Filtro ;
      private bool AV15OrderedDsc ;
      private bool AV103IsAuthorized_Update ;
      private bool AV104IsAuthorized_Delete ;
      private bool AV128IsAuthorized_RemarcarVisita ;
      private bool AV108IsAuthorized_Insert ;
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
      private bool Grid_empowerer_Hascategories ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool Grid_empowerer_Hascolumnsselector ;
      private bool wbLoad ;
      private bool bGXsfl_81_Refreshing=false ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n403VisInsUsuNome ;
      private bool n475VisDataFim ;
      private bool n476VisHoraFim ;
      private bool n477VisDataHoraFim ;
      private bool n417VisLink ;
      private bool n419VisPaiID ;
      private bool n418VisNegID ;
      private bool n422VisNgfSeq ;
      private bool gxdyncontrolsrefreshing ;
      private bool A487VisDel ;
      private bool AV176Core_visitawwds_3_visdel_filtro ;
      private bool returnInSub ;
      private bool bDynCreated_Wcnegociopjgeneral ;
      private bool gx_refresh_fired ;
      private bool bDynCreated_Wwpaux_wc ;
      private bool GXt_boolean3 ;
      private string AV39ColumnsSelectorXML ;
      private string AV141TFVisSituacao_SelsJson ;
      private string AV40UserCustomValue ;
      private string AV164VisSituacao ;
      private string AV64TFVisInsUsuNome ;
      private string AV65TFVisInsUsuNome_Sel ;
      private string AV85TFVisTipoNome ;
      private string AV86TFVisTipoNome_Sel ;
      private string AV91TFVisAssunto ;
      private string AV92TFVisAssunto_Sel ;
      private string AV93TFVisLink ;
      private string AV94TFVisLink_Sel ;
      private string AV101GridAppliedFilters ;
      private string AV161NegUltIteNome ;
      private string AV61DDO_VisInsDataHoraAuxDateText ;
      private string AV70DDO_VisDataAuxDateText ;
      private string AV75DDO_VisHoraAuxDateText ;
      private string AV80DDO_VisDataHoraAuxDateText ;
      private string AV150DDO_VisDataFimAuxDateText ;
      private string AV155DDO_VisHoraFimAuxDateText ;
      private string AV160DDO_VisDataHoraFimAuxDateText ;
      private string A403VisInsUsuNome ;
      private string A416VisTipoNome ;
      private string A409VisAssunto ;
      private string A472VisSituacao ;
      private string A417VisLink ;
      private string lV181Core_visitawwds_8_tfvisinsusunome ;
      private string lV195Core_visitawwds_22_tfvistiponome ;
      private string lV197Core_visitawwds_24_tfvisassunto ;
      private string lV200Core_visitawwds_27_tfvislink ;
      private string AV177Core_visitawwds_4_vissituacao ;
      private string AV182Core_visitawwds_9_tfvisinsusunome_sel ;
      private string AV181Core_visitawwds_8_tfvisinsusunome ;
      private string AV196Core_visitawwds_23_tfvistiponome_sel ;
      private string AV195Core_visitawwds_22_tfvistiponome ;
      private string AV198Core_visitawwds_25_tfvisassunto_sel ;
      private string AV197Core_visitawwds_24_tfvisassunto ;
      private string AV201Core_visitawwds_28_tfvislink_sel ;
      private string AV200Core_visitawwds_27_tfvislink ;
      private string A362NegAssunto ;
      private string A421NegUltIteNome ;
      private string AV37ExcelFilename ;
      private string AV38ErrorMessage ;
      private Guid AV129VisNegID ;
      private Guid wcpOAV129VisNegID ;
      private Guid AV143VisNegID_Filtro ;
      private Guid AV166VisID_Selected ;
      private Guid AV167VisNegID_Selected ;
      private Guid A398VisID ;
      private Guid A419VisPaiID ;
      private Guid A418VisNegID ;
      private Guid AV174Core_visitawwds_1_visnegid_filtro ;
      private Guid A345NegID ;
      private IGxSession AV43Session ;
      private GXWebComponent WebComp_Wcnegociopjgeneral ;
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
      private GXUserControl ucGrid_titlescategories ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucTfvisinsdatahora_rangepicker ;
      private GXUserControl ucTfvisdata_rangepicker ;
      private GXUserControl ucTfvishora_rangepicker ;
      private GXUserControl ucTfvisdatahora_rangepicker ;
      private GXUserControl ucTfvisdatafim_rangepicker ;
      private GXUserControl ucTfvishorafim_rangepicker ;
      private GXUserControl ucTfvisdatahorafim_rangepicker ;
      private GXUserControl ucDvelop_confirmpanel_delete ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavDynamicfiltersoperatorvissituacao ;
      private GXCombobox cmbavVissituacao ;
      private GXCombobox cmbavGridactions ;
      private GXCombobox cmbVisSituacao ;
      private IDataStoreProvider pr_default ;
      private int[] H00562_A414VisTipoID ;
      private bool[] H00562_A487VisDel ;
      private int[] H00562_A422VisNgfSeq ;
      private bool[] H00562_n422VisNgfSeq ;
      private Guid[] H00562_A418VisNegID ;
      private bool[] H00562_n418VisNegID ;
      private Guid[] H00562_A419VisPaiID ;
      private bool[] H00562_n419VisPaiID ;
      private Guid[] H00562_A398VisID ;
      private string[] H00562_A417VisLink ;
      private bool[] H00562_n417VisLink ;
      private string[] H00562_A472VisSituacao ;
      private string[] H00562_A409VisAssunto ;
      private string[] H00562_A416VisTipoNome ;
      private DateTime[] H00562_A477VisDataHoraFim ;
      private bool[] H00562_n477VisDataHoraFim ;
      private DateTime[] H00562_A476VisHoraFim ;
      private bool[] H00562_n476VisHoraFim ;
      private DateTime[] H00562_A475VisDataFim ;
      private bool[] H00562_n475VisDataFim ;
      private DateTime[] H00562_A406VisDataHora ;
      private DateTime[] H00562_A405VisHora ;
      private DateTime[] H00562_A404VisData ;
      private string[] H00562_A403VisInsUsuNome ;
      private bool[] H00562_n403VisInsUsuNome ;
      private DateTime[] H00562_A401VisInsDataHora ;
      private long[] H00563_AGRID_nRecordCount ;
      private Guid[] H00564_A345NegID ;
      private string[] H00564_A362NegAssunto ;
      private long[] H00564_A356NegCodigo ;
      private string[] H00564_A421NegUltIteNome ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV8HTTPRequest ;
      private GxSimpleCollection<string> AV142TFVisSituacao_Sels ;
      private GxSimpleCollection<string> AV199Core_visitawwds_26_tfvissituacao_sels ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV106AGExportData ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV97GAMErrors ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV170Messages ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV12GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV41ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV42ColumnsSelectorAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item AV107AGExportDataItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV95DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV96GAMSession ;
      private GeneXus.Programs.core.SdtsdtVisita AV169sdtVisita ;
      private GeneXus.Utils.SdtMessages_Message AV171Message ;
   }

   public class visitaww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00562( IGxContext context ,
                                             string A472VisSituacao ,
                                             GxSimpleCollection<string> AV199Core_visitawwds_26_tfvissituacao_sels ,
                                             short AV178Core_visitawwds_5_dynamicfiltersoperatorvissituacao ,
                                             string AV177Core_visitawwds_4_vissituacao ,
                                             DateTime AV179Core_visitawwds_6_tfvisinsdatahora ,
                                             DateTime AV180Core_visitawwds_7_tfvisinsdatahora_to ,
                                             string AV182Core_visitawwds_9_tfvisinsusunome_sel ,
                                             string AV181Core_visitawwds_8_tfvisinsusunome ,
                                             DateTime AV183Core_visitawwds_10_tfvisdata ,
                                             DateTime AV184Core_visitawwds_11_tfvisdata_to ,
                                             DateTime AV185Core_visitawwds_12_tfvishora ,
                                             DateTime AV186Core_visitawwds_13_tfvishora_to ,
                                             DateTime AV187Core_visitawwds_14_tfvisdatahora ,
                                             DateTime AV188Core_visitawwds_15_tfvisdatahora_to ,
                                             DateTime AV189Core_visitawwds_16_tfvisdatafim ,
                                             DateTime AV190Core_visitawwds_17_tfvisdatafim_to ,
                                             DateTime AV191Core_visitawwds_18_tfvishorafim ,
                                             DateTime AV192Core_visitawwds_19_tfvishorafim_to ,
                                             DateTime AV193Core_visitawwds_20_tfvisdatahorafim ,
                                             DateTime AV194Core_visitawwds_21_tfvisdatahorafim_to ,
                                             string AV196Core_visitawwds_23_tfvistiponome_sel ,
                                             string AV195Core_visitawwds_22_tfvistiponome ,
                                             string AV198Core_visitawwds_25_tfvisassunto_sel ,
                                             string AV197Core_visitawwds_24_tfvisassunto ,
                                             int AV199Core_visitawwds_26_tfvissituacao_sels_Count ,
                                             string AV201Core_visitawwds_28_tfvislink_sel ,
                                             string AV200Core_visitawwds_27_tfvislink ,
                                             DateTime A401VisInsDataHora ,
                                             string A403VisInsUsuNome ,
                                             DateTime A404VisData ,
                                             DateTime A405VisHora ,
                                             DateTime A406VisDataHora ,
                                             DateTime A475VisDataFim ,
                                             DateTime A476VisHoraFim ,
                                             DateTime A477VisDataHoraFim ,
                                             string A416VisTipoNome ,
                                             string A409VisAssunto ,
                                             string A417VisLink ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc ,
                                             bool A487VisDel ,
                                             Guid A418VisNegID ,
                                             Guid AV129VisNegID ,
                                             int A422VisNgfSeq ,
                                             int AV130VisNgfSeq )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[29];
         Object[] GXv_Object9 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.VisTipoID AS VisTipoID, T1.VisDel, T1.VisNgfSeq, T1.VisNegID, T1.VisPaiID, T1.VisID, T1.VisLink, T1.VisSituacao, T1.VisAssunto, T2.VitNome AS VisTipoNome, T1.VisDataHoraFim, T1.VisHoraFim, T1.VisDataFim, T1.VisDataHora, T1.VisHora, T1.VisData, T1.VisInsUsuNome, T1.VisInsDataHora";
         sFromString = " FROM (tb_visita T1 INNER JOIN tb_visitatipo T2 ON T2.VitID = T1.VisTipoID)";
         sOrderString = "";
         AddWhere(sWhereString, "(Not T1.VisDel)");
         AddWhere(sWhereString, "(T1.VisNegID = :AV129VisNegID)");
         AddWhere(sWhereString, "(T1.VisNgfSeq = :AV130VisNgfSeq)");
         if ( ( AV178Core_visitawwds_5_dynamicfiltersoperatorvissituacao == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV177Core_visitawwds_4_vissituacao)) ) )
         {
            AddWhere(sWhereString, "(T1.VisSituacao = ( :AV177Core_visitawwds_4_vissituacao))");
         }
         else
         {
            GXv_int8[2] = 1;
         }
         if ( ( AV178Core_visitawwds_5_dynamicfiltersoperatorvissituacao == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV177Core_visitawwds_4_vissituacao)) ) )
         {
            AddWhere(sWhereString, "(T1.VisSituacao <> ( :AV177Core_visitawwds_4_vissituacao))");
         }
         else
         {
            GXv_int8[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV179Core_visitawwds_6_tfvisinsdatahora) )
         {
            AddWhere(sWhereString, "(T1.VisInsDataHora >= :AV179Core_visitawwds_6_tfvisinsdatahora)");
         }
         else
         {
            GXv_int8[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV180Core_visitawwds_7_tfvisinsdatahora_to) )
         {
            AddWhere(sWhereString, "(T1.VisInsDataHora <= :AV180Core_visitawwds_7_tfvisinsdatahora_to)");
         }
         else
         {
            GXv_int8[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV182Core_visitawwds_9_tfvisinsusunome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV181Core_visitawwds_8_tfvisinsusunome)) ) )
         {
            AddWhere(sWhereString, "(T1.VisInsUsuNome like :lV181Core_visitawwds_8_tfvisinsusunome)");
         }
         else
         {
            GXv_int8[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV182Core_visitawwds_9_tfvisinsusunome_sel)) && ! ( StringUtil.StrCmp(AV182Core_visitawwds_9_tfvisinsusunome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.VisInsUsuNome = ( :AV182Core_visitawwds_9_tfvisinsusunome_sel))");
         }
         else
         {
            GXv_int8[7] = 1;
         }
         if ( StringUtil.StrCmp(AV182Core_visitawwds_9_tfvisinsusunome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.VisInsUsuNome IS NULL or (char_length(trim(trailing ' ' from T1.VisInsUsuNome))=0))");
         }
         if ( ! (DateTime.MinValue==AV183Core_visitawwds_10_tfvisdata) )
         {
            AddWhere(sWhereString, "(T1.VisData >= :AV183Core_visitawwds_10_tfvisdata)");
         }
         else
         {
            GXv_int8[8] = 1;
         }
         if ( ! (DateTime.MinValue==AV184Core_visitawwds_11_tfvisdata_to) )
         {
            AddWhere(sWhereString, "(T1.VisData <= :AV184Core_visitawwds_11_tfvisdata_to)");
         }
         else
         {
            GXv_int8[9] = 1;
         }
         if ( ! (DateTime.MinValue==AV185Core_visitawwds_12_tfvishora) )
         {
            AddWhere(sWhereString, "(T1.VisHora >= :AV185Core_visitawwds_12_tfvishora)");
         }
         else
         {
            GXv_int8[10] = 1;
         }
         if ( ! (DateTime.MinValue==AV186Core_visitawwds_13_tfvishora_to) )
         {
            AddWhere(sWhereString, "(T1.VisHora <= :AV186Core_visitawwds_13_tfvishora_to)");
         }
         else
         {
            GXv_int8[11] = 1;
         }
         if ( ! (DateTime.MinValue==AV187Core_visitawwds_14_tfvisdatahora) )
         {
            AddWhere(sWhereString, "(T1.VisDataHora >= :AV187Core_visitawwds_14_tfvisdatahora)");
         }
         else
         {
            GXv_int8[12] = 1;
         }
         if ( ! (DateTime.MinValue==AV188Core_visitawwds_15_tfvisdatahora_to) )
         {
            AddWhere(sWhereString, "(T1.VisDataHora <= :AV188Core_visitawwds_15_tfvisdatahora_to)");
         }
         else
         {
            GXv_int8[13] = 1;
         }
         if ( ! (DateTime.MinValue==AV189Core_visitawwds_16_tfvisdatafim) )
         {
            AddWhere(sWhereString, "(T1.VisDataFim >= :AV189Core_visitawwds_16_tfvisdatafim)");
         }
         else
         {
            GXv_int8[14] = 1;
         }
         if ( ! (DateTime.MinValue==AV190Core_visitawwds_17_tfvisdatafim_to) )
         {
            AddWhere(sWhereString, "(T1.VisDataFim <= :AV190Core_visitawwds_17_tfvisdatafim_to)");
         }
         else
         {
            GXv_int8[15] = 1;
         }
         if ( ! (DateTime.MinValue==AV191Core_visitawwds_18_tfvishorafim) )
         {
            AddWhere(sWhereString, "(T1.VisHoraFim >= :AV191Core_visitawwds_18_tfvishorafim)");
         }
         else
         {
            GXv_int8[16] = 1;
         }
         if ( ! (DateTime.MinValue==AV192Core_visitawwds_19_tfvishorafim_to) )
         {
            AddWhere(sWhereString, "(T1.VisHoraFim <= :AV192Core_visitawwds_19_tfvishorafim_to)");
         }
         else
         {
            GXv_int8[17] = 1;
         }
         if ( ! (DateTime.MinValue==AV193Core_visitawwds_20_tfvisdatahorafim) )
         {
            AddWhere(sWhereString, "(T1.VisDataHoraFim >= :AV193Core_visitawwds_20_tfvisdatahorafim)");
         }
         else
         {
            GXv_int8[18] = 1;
         }
         if ( ! (DateTime.MinValue==AV194Core_visitawwds_21_tfvisdatahorafim_to) )
         {
            AddWhere(sWhereString, "(T1.VisDataHoraFim <= :AV194Core_visitawwds_21_tfvisdatahorafim_to)");
         }
         else
         {
            GXv_int8[19] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV196Core_visitawwds_23_tfvistiponome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV195Core_visitawwds_22_tfvistiponome)) ) )
         {
            AddWhere(sWhereString, "(T2.VitNome like :lV195Core_visitawwds_22_tfvistiponome)");
         }
         else
         {
            GXv_int8[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV196Core_visitawwds_23_tfvistiponome_sel)) && ! ( StringUtil.StrCmp(AV196Core_visitawwds_23_tfvistiponome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.VitNome = ( :AV196Core_visitawwds_23_tfvistiponome_sel))");
         }
         else
         {
            GXv_int8[21] = 1;
         }
         if ( StringUtil.StrCmp(AV196Core_visitawwds_23_tfvistiponome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.VitNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV198Core_visitawwds_25_tfvisassunto_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV197Core_visitawwds_24_tfvisassunto)) ) )
         {
            AddWhere(sWhereString, "(T1.VisAssunto like :lV197Core_visitawwds_24_tfvisassunto)");
         }
         else
         {
            GXv_int8[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV198Core_visitawwds_25_tfvisassunto_sel)) && ! ( StringUtil.StrCmp(AV198Core_visitawwds_25_tfvisassunto_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.VisAssunto = ( :AV198Core_visitawwds_25_tfvisassunto_sel))");
         }
         else
         {
            GXv_int8[23] = 1;
         }
         if ( StringUtil.StrCmp(AV198Core_visitawwds_25_tfvisassunto_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.VisAssunto))=0))");
         }
         if ( AV199Core_visitawwds_26_tfvissituacao_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV199Core_visitawwds_26_tfvissituacao_sels, "T1.VisSituacao IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV201Core_visitawwds_28_tfvislink_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV200Core_visitawwds_27_tfvislink)) ) )
         {
            AddWhere(sWhereString, "(T1.VisLink like :lV200Core_visitawwds_27_tfvislink)");
         }
         else
         {
            GXv_int8[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV201Core_visitawwds_28_tfvislink_sel)) && ! ( StringUtil.StrCmp(AV201Core_visitawwds_28_tfvislink_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.VisLink = ( :AV201Core_visitawwds_28_tfvislink_sel))");
         }
         else
         {
            GXv_int8[25] = 1;
         }
         if ( StringUtil.StrCmp(AV201Core_visitawwds_28_tfvislink_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.VisLink IS NULL or (char_length(trim(trailing ' ' from T1.VisLink))=0))");
         }
         if ( AV14OrderedBy == 1 )
         {
            sOrderString += " ORDER BY T1.VisNegID, T1.VisDataHora, T1.VisID";
         }
         else if ( ( AV14OrderedBy == 2 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.VisInsDataHora, T1.VisID";
         }
         else if ( ( AV14OrderedBy == 2 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.VisInsDataHora DESC, T1.VisID";
         }
         else if ( ( AV14OrderedBy == 3 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.VisInsUsuNome, T1.VisID";
         }
         else if ( ( AV14OrderedBy == 3 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.VisInsUsuNome DESC, T1.VisID";
         }
         else if ( ( AV14OrderedBy == 4 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.VisData, T1.VisID";
         }
         else if ( ( AV14OrderedBy == 4 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.VisData DESC, T1.VisID";
         }
         else if ( ( AV14OrderedBy == 5 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.VisHora, T1.VisID";
         }
         else if ( ( AV14OrderedBy == 5 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.VisHora DESC, T1.VisID";
         }
         else if ( ( AV14OrderedBy == 6 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.VisDataHora, T1.VisID";
         }
         else if ( ( AV14OrderedBy == 6 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.VisDataHora DESC, T1.VisID";
         }
         else if ( ( AV14OrderedBy == 7 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.VisDataFim, T1.VisID";
         }
         else if ( ( AV14OrderedBy == 7 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.VisDataFim DESC, T1.VisID";
         }
         else if ( ( AV14OrderedBy == 8 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.VisHoraFim, T1.VisID";
         }
         else if ( ( AV14OrderedBy == 8 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.VisHoraFim DESC, T1.VisID";
         }
         else if ( ( AV14OrderedBy == 9 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.VisDataHoraFim, T1.VisID";
         }
         else if ( ( AV14OrderedBy == 9 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.VisDataHoraFim DESC, T1.VisID";
         }
         else if ( ( AV14OrderedBy == 10 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T2.VitNome, T1.VisID";
         }
         else if ( ( AV14OrderedBy == 10 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T2.VitNome DESC, T1.VisID";
         }
         else if ( ( AV14OrderedBy == 11 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.VisAssunto, T1.VisID";
         }
         else if ( ( AV14OrderedBy == 11 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.VisAssunto DESC, T1.VisID";
         }
         else if ( ( AV14OrderedBy == 12 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.VisSituacao, T1.VisID";
         }
         else if ( ( AV14OrderedBy == 12 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.VisSituacao DESC, T1.VisID";
         }
         else if ( ( AV14OrderedBy == 13 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.VisLink, T1.VisID";
         }
         else if ( ( AV14OrderedBy == 13 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.VisLink DESC, T1.VisID";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.VisID";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object9[0] = scmdbuf;
         GXv_Object9[1] = GXv_int8;
         return GXv_Object9 ;
      }

      protected Object[] conditional_H00563( IGxContext context ,
                                             string A472VisSituacao ,
                                             GxSimpleCollection<string> AV199Core_visitawwds_26_tfvissituacao_sels ,
                                             short AV178Core_visitawwds_5_dynamicfiltersoperatorvissituacao ,
                                             string AV177Core_visitawwds_4_vissituacao ,
                                             DateTime AV179Core_visitawwds_6_tfvisinsdatahora ,
                                             DateTime AV180Core_visitawwds_7_tfvisinsdatahora_to ,
                                             string AV182Core_visitawwds_9_tfvisinsusunome_sel ,
                                             string AV181Core_visitawwds_8_tfvisinsusunome ,
                                             DateTime AV183Core_visitawwds_10_tfvisdata ,
                                             DateTime AV184Core_visitawwds_11_tfvisdata_to ,
                                             DateTime AV185Core_visitawwds_12_tfvishora ,
                                             DateTime AV186Core_visitawwds_13_tfvishora_to ,
                                             DateTime AV187Core_visitawwds_14_tfvisdatahora ,
                                             DateTime AV188Core_visitawwds_15_tfvisdatahora_to ,
                                             DateTime AV189Core_visitawwds_16_tfvisdatafim ,
                                             DateTime AV190Core_visitawwds_17_tfvisdatafim_to ,
                                             DateTime AV191Core_visitawwds_18_tfvishorafim ,
                                             DateTime AV192Core_visitawwds_19_tfvishorafim_to ,
                                             DateTime AV193Core_visitawwds_20_tfvisdatahorafim ,
                                             DateTime AV194Core_visitawwds_21_tfvisdatahorafim_to ,
                                             string AV196Core_visitawwds_23_tfvistiponome_sel ,
                                             string AV195Core_visitawwds_22_tfvistiponome ,
                                             string AV198Core_visitawwds_25_tfvisassunto_sel ,
                                             string AV197Core_visitawwds_24_tfvisassunto ,
                                             int AV199Core_visitawwds_26_tfvissituacao_sels_Count ,
                                             string AV201Core_visitawwds_28_tfvislink_sel ,
                                             string AV200Core_visitawwds_27_tfvislink ,
                                             DateTime A401VisInsDataHora ,
                                             string A403VisInsUsuNome ,
                                             DateTime A404VisData ,
                                             DateTime A405VisHora ,
                                             DateTime A406VisDataHora ,
                                             DateTime A475VisDataFim ,
                                             DateTime A476VisHoraFim ,
                                             DateTime A477VisDataHoraFim ,
                                             string A416VisTipoNome ,
                                             string A409VisAssunto ,
                                             string A417VisLink ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc ,
                                             bool A487VisDel ,
                                             Guid A418VisNegID ,
                                             Guid AV129VisNegID ,
                                             int A422VisNgfSeq ,
                                             int AV130VisNgfSeq )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int10 = new short[26];
         Object[] GXv_Object11 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM (tb_visita T1 INNER JOIN tb_visitatipo T2 ON T2.VitID = T1.VisTipoID)";
         AddWhere(sWhereString, "(Not T1.VisDel)");
         AddWhere(sWhereString, "(T1.VisNegID = :AV129VisNegID)");
         AddWhere(sWhereString, "(T1.VisNgfSeq = :AV130VisNgfSeq)");
         if ( ( AV178Core_visitawwds_5_dynamicfiltersoperatorvissituacao == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV177Core_visitawwds_4_vissituacao)) ) )
         {
            AddWhere(sWhereString, "(T1.VisSituacao = ( :AV177Core_visitawwds_4_vissituacao))");
         }
         else
         {
            GXv_int10[2] = 1;
         }
         if ( ( AV178Core_visitawwds_5_dynamicfiltersoperatorvissituacao == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV177Core_visitawwds_4_vissituacao)) ) )
         {
            AddWhere(sWhereString, "(T1.VisSituacao <> ( :AV177Core_visitawwds_4_vissituacao))");
         }
         else
         {
            GXv_int10[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV179Core_visitawwds_6_tfvisinsdatahora) )
         {
            AddWhere(sWhereString, "(T1.VisInsDataHora >= :AV179Core_visitawwds_6_tfvisinsdatahora)");
         }
         else
         {
            GXv_int10[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV180Core_visitawwds_7_tfvisinsdatahora_to) )
         {
            AddWhere(sWhereString, "(T1.VisInsDataHora <= :AV180Core_visitawwds_7_tfvisinsdatahora_to)");
         }
         else
         {
            GXv_int10[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV182Core_visitawwds_9_tfvisinsusunome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV181Core_visitawwds_8_tfvisinsusunome)) ) )
         {
            AddWhere(sWhereString, "(T1.VisInsUsuNome like :lV181Core_visitawwds_8_tfvisinsusunome)");
         }
         else
         {
            GXv_int10[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV182Core_visitawwds_9_tfvisinsusunome_sel)) && ! ( StringUtil.StrCmp(AV182Core_visitawwds_9_tfvisinsusunome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.VisInsUsuNome = ( :AV182Core_visitawwds_9_tfvisinsusunome_sel))");
         }
         else
         {
            GXv_int10[7] = 1;
         }
         if ( StringUtil.StrCmp(AV182Core_visitawwds_9_tfvisinsusunome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.VisInsUsuNome IS NULL or (char_length(trim(trailing ' ' from T1.VisInsUsuNome))=0))");
         }
         if ( ! (DateTime.MinValue==AV183Core_visitawwds_10_tfvisdata) )
         {
            AddWhere(sWhereString, "(T1.VisData >= :AV183Core_visitawwds_10_tfvisdata)");
         }
         else
         {
            GXv_int10[8] = 1;
         }
         if ( ! (DateTime.MinValue==AV184Core_visitawwds_11_tfvisdata_to) )
         {
            AddWhere(sWhereString, "(T1.VisData <= :AV184Core_visitawwds_11_tfvisdata_to)");
         }
         else
         {
            GXv_int10[9] = 1;
         }
         if ( ! (DateTime.MinValue==AV185Core_visitawwds_12_tfvishora) )
         {
            AddWhere(sWhereString, "(T1.VisHora >= :AV185Core_visitawwds_12_tfvishora)");
         }
         else
         {
            GXv_int10[10] = 1;
         }
         if ( ! (DateTime.MinValue==AV186Core_visitawwds_13_tfvishora_to) )
         {
            AddWhere(sWhereString, "(T1.VisHora <= :AV186Core_visitawwds_13_tfvishora_to)");
         }
         else
         {
            GXv_int10[11] = 1;
         }
         if ( ! (DateTime.MinValue==AV187Core_visitawwds_14_tfvisdatahora) )
         {
            AddWhere(sWhereString, "(T1.VisDataHora >= :AV187Core_visitawwds_14_tfvisdatahora)");
         }
         else
         {
            GXv_int10[12] = 1;
         }
         if ( ! (DateTime.MinValue==AV188Core_visitawwds_15_tfvisdatahora_to) )
         {
            AddWhere(sWhereString, "(T1.VisDataHora <= :AV188Core_visitawwds_15_tfvisdatahora_to)");
         }
         else
         {
            GXv_int10[13] = 1;
         }
         if ( ! (DateTime.MinValue==AV189Core_visitawwds_16_tfvisdatafim) )
         {
            AddWhere(sWhereString, "(T1.VisDataFim >= :AV189Core_visitawwds_16_tfvisdatafim)");
         }
         else
         {
            GXv_int10[14] = 1;
         }
         if ( ! (DateTime.MinValue==AV190Core_visitawwds_17_tfvisdatafim_to) )
         {
            AddWhere(sWhereString, "(T1.VisDataFim <= :AV190Core_visitawwds_17_tfvisdatafim_to)");
         }
         else
         {
            GXv_int10[15] = 1;
         }
         if ( ! (DateTime.MinValue==AV191Core_visitawwds_18_tfvishorafim) )
         {
            AddWhere(sWhereString, "(T1.VisHoraFim >= :AV191Core_visitawwds_18_tfvishorafim)");
         }
         else
         {
            GXv_int10[16] = 1;
         }
         if ( ! (DateTime.MinValue==AV192Core_visitawwds_19_tfvishorafim_to) )
         {
            AddWhere(sWhereString, "(T1.VisHoraFim <= :AV192Core_visitawwds_19_tfvishorafim_to)");
         }
         else
         {
            GXv_int10[17] = 1;
         }
         if ( ! (DateTime.MinValue==AV193Core_visitawwds_20_tfvisdatahorafim) )
         {
            AddWhere(sWhereString, "(T1.VisDataHoraFim >= :AV193Core_visitawwds_20_tfvisdatahorafim)");
         }
         else
         {
            GXv_int10[18] = 1;
         }
         if ( ! (DateTime.MinValue==AV194Core_visitawwds_21_tfvisdatahorafim_to) )
         {
            AddWhere(sWhereString, "(T1.VisDataHoraFim <= :AV194Core_visitawwds_21_tfvisdatahorafim_to)");
         }
         else
         {
            GXv_int10[19] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV196Core_visitawwds_23_tfvistiponome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV195Core_visitawwds_22_tfvistiponome)) ) )
         {
            AddWhere(sWhereString, "(T2.VitNome like :lV195Core_visitawwds_22_tfvistiponome)");
         }
         else
         {
            GXv_int10[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV196Core_visitawwds_23_tfvistiponome_sel)) && ! ( StringUtil.StrCmp(AV196Core_visitawwds_23_tfvistiponome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.VitNome = ( :AV196Core_visitawwds_23_tfvistiponome_sel))");
         }
         else
         {
            GXv_int10[21] = 1;
         }
         if ( StringUtil.StrCmp(AV196Core_visitawwds_23_tfvistiponome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.VitNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV198Core_visitawwds_25_tfvisassunto_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV197Core_visitawwds_24_tfvisassunto)) ) )
         {
            AddWhere(sWhereString, "(T1.VisAssunto like :lV197Core_visitawwds_24_tfvisassunto)");
         }
         else
         {
            GXv_int10[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV198Core_visitawwds_25_tfvisassunto_sel)) && ! ( StringUtil.StrCmp(AV198Core_visitawwds_25_tfvisassunto_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.VisAssunto = ( :AV198Core_visitawwds_25_tfvisassunto_sel))");
         }
         else
         {
            GXv_int10[23] = 1;
         }
         if ( StringUtil.StrCmp(AV198Core_visitawwds_25_tfvisassunto_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.VisAssunto))=0))");
         }
         if ( AV199Core_visitawwds_26_tfvissituacao_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV199Core_visitawwds_26_tfvissituacao_sels, "T1.VisSituacao IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV201Core_visitawwds_28_tfvislink_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV200Core_visitawwds_27_tfvislink)) ) )
         {
            AddWhere(sWhereString, "(T1.VisLink like :lV200Core_visitawwds_27_tfvislink)");
         }
         else
         {
            GXv_int10[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV201Core_visitawwds_28_tfvislink_sel)) && ! ( StringUtil.StrCmp(AV201Core_visitawwds_28_tfvislink_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.VisLink = ( :AV201Core_visitawwds_28_tfvislink_sel))");
         }
         else
         {
            GXv_int10[25] = 1;
         }
         if ( StringUtil.StrCmp(AV201Core_visitawwds_28_tfvislink_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.VisLink IS NULL or (char_length(trim(trailing ' ' from T1.VisLink))=0))");
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
         else if ( ( AV14OrderedBy == 11 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 11 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 12 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 12 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 13 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 13 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( true )
         {
            scmdbuf += "";
         }
         GXv_Object11[0] = scmdbuf;
         GXv_Object11[1] = GXv_int10;
         return GXv_Object11 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H00562(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (DateTime)dynConstraints[11] , (DateTime)dynConstraints[12] , (DateTime)dynConstraints[13] , (DateTime)dynConstraints[14] , (DateTime)dynConstraints[15] , (DateTime)dynConstraints[16] , (DateTime)dynConstraints[17] , (DateTime)dynConstraints[18] , (DateTime)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (int)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (DateTime)dynConstraints[27] , (string)dynConstraints[28] , (DateTime)dynConstraints[29] , (DateTime)dynConstraints[30] , (DateTime)dynConstraints[31] , (DateTime)dynConstraints[32] , (DateTime)dynConstraints[33] , (DateTime)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (short)dynConstraints[38] , (bool)dynConstraints[39] , (bool)dynConstraints[40] , (Guid)dynConstraints[41] , (Guid)dynConstraints[42] , (int)dynConstraints[43] , (int)dynConstraints[44] );
               case 1 :
                     return conditional_H00563(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (DateTime)dynConstraints[11] , (DateTime)dynConstraints[12] , (DateTime)dynConstraints[13] , (DateTime)dynConstraints[14] , (DateTime)dynConstraints[15] , (DateTime)dynConstraints[16] , (DateTime)dynConstraints[17] , (DateTime)dynConstraints[18] , (DateTime)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (int)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (DateTime)dynConstraints[27] , (string)dynConstraints[28] , (DateTime)dynConstraints[29] , (DateTime)dynConstraints[30] , (DateTime)dynConstraints[31] , (DateTime)dynConstraints[32] , (DateTime)dynConstraints[33] , (DateTime)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (short)dynConstraints[38] , (bool)dynConstraints[39] , (bool)dynConstraints[40] , (Guid)dynConstraints[41] , (Guid)dynConstraints[42] , (int)dynConstraints[43] , (int)dynConstraints[44] );
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
          Object[] prmH00564;
          prmH00564 = new Object[] {
          new ParDef("AV129VisNegID",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmH00562;
          prmH00562 = new Object[] {
          new ParDef("AV129VisNegID",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV130VisNgfSeq",GXType.Int32,8,0) ,
          new ParDef("AV177Core_visitawwds_4_vissituacao",GXType.VarChar,3,0) ,
          new ParDef("AV177Core_visitawwds_4_vissituacao",GXType.VarChar,3,0) ,
          new ParDef("AV179Core_visitawwds_6_tfvisinsdatahora",GXType.DateTime2,10,12) ,
          new ParDef("AV180Core_visitawwds_7_tfvisinsdatahora_to",GXType.DateTime2,10,12) ,
          new ParDef("lV181Core_visitawwds_8_tfvisinsusunome",GXType.VarChar,80,0) ,
          new ParDef("AV182Core_visitawwds_9_tfvisinsusunome_sel",GXType.VarChar,80,0) ,
          new ParDef("AV183Core_visitawwds_10_tfvisdata",GXType.Date,8,0) ,
          new ParDef("AV184Core_visitawwds_11_tfvisdata_to",GXType.Date,8,0) ,
          new ParDef("AV185Core_visitawwds_12_tfvishora",GXType.DateTime,0,5) ,
          new ParDef("AV186Core_visitawwds_13_tfvishora_to",GXType.DateTime,0,5) ,
          new ParDef("AV187Core_visitawwds_14_tfvisdatahora",GXType.DateTime,10,5) ,
          new ParDef("AV188Core_visitawwds_15_tfvisdatahora_to",GXType.DateTime,10,5) ,
          new ParDef("AV189Core_visitawwds_16_tfvisdatafim",GXType.Date,8,0) ,
          new ParDef("AV190Core_visitawwds_17_tfvisdatafim_to",GXType.Date,8,0) ,
          new ParDef("AV191Core_visitawwds_18_tfvishorafim",GXType.DateTime,0,5) ,
          new ParDef("AV192Core_visitawwds_19_tfvishorafim_to",GXType.DateTime,0,5) ,
          new ParDef("AV193Core_visitawwds_20_tfvisdatahorafim",GXType.DateTime,10,5) ,
          new ParDef("AV194Core_visitawwds_21_tfvisdatahorafim_to",GXType.DateTime,10,5) ,
          new ParDef("lV195Core_visitawwds_22_tfvistiponome",GXType.VarChar,80,0) ,
          new ParDef("AV196Core_visitawwds_23_tfvistiponome_sel",GXType.VarChar,80,0) ,
          new ParDef("lV197Core_visitawwds_24_tfvisassunto",GXType.VarChar,80,0) ,
          new ParDef("AV198Core_visitawwds_25_tfvisassunto_sel",GXType.VarChar,80,0) ,
          new ParDef("lV200Core_visitawwds_27_tfvislink",GXType.VarChar,1000,0) ,
          new ParDef("AV201Core_visitawwds_28_tfvislink_sel",GXType.VarChar,1000,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00563;
          prmH00563 = new Object[] {
          new ParDef("AV129VisNegID",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV130VisNgfSeq",GXType.Int32,8,0) ,
          new ParDef("AV177Core_visitawwds_4_vissituacao",GXType.VarChar,3,0) ,
          new ParDef("AV177Core_visitawwds_4_vissituacao",GXType.VarChar,3,0) ,
          new ParDef("AV179Core_visitawwds_6_tfvisinsdatahora",GXType.DateTime2,10,12) ,
          new ParDef("AV180Core_visitawwds_7_tfvisinsdatahora_to",GXType.DateTime2,10,12) ,
          new ParDef("lV181Core_visitawwds_8_tfvisinsusunome",GXType.VarChar,80,0) ,
          new ParDef("AV182Core_visitawwds_9_tfvisinsusunome_sel",GXType.VarChar,80,0) ,
          new ParDef("AV183Core_visitawwds_10_tfvisdata",GXType.Date,8,0) ,
          new ParDef("AV184Core_visitawwds_11_tfvisdata_to",GXType.Date,8,0) ,
          new ParDef("AV185Core_visitawwds_12_tfvishora",GXType.DateTime,0,5) ,
          new ParDef("AV186Core_visitawwds_13_tfvishora_to",GXType.DateTime,0,5) ,
          new ParDef("AV187Core_visitawwds_14_tfvisdatahora",GXType.DateTime,10,5) ,
          new ParDef("AV188Core_visitawwds_15_tfvisdatahora_to",GXType.DateTime,10,5) ,
          new ParDef("AV189Core_visitawwds_16_tfvisdatafim",GXType.Date,8,0) ,
          new ParDef("AV190Core_visitawwds_17_tfvisdatafim_to",GXType.Date,8,0) ,
          new ParDef("AV191Core_visitawwds_18_tfvishorafim",GXType.DateTime,0,5) ,
          new ParDef("AV192Core_visitawwds_19_tfvishorafim_to",GXType.DateTime,0,5) ,
          new ParDef("AV193Core_visitawwds_20_tfvisdatahorafim",GXType.DateTime,10,5) ,
          new ParDef("AV194Core_visitawwds_21_tfvisdatahorafim_to",GXType.DateTime,10,5) ,
          new ParDef("lV195Core_visitawwds_22_tfvistiponome",GXType.VarChar,80,0) ,
          new ParDef("AV196Core_visitawwds_23_tfvistiponome_sel",GXType.VarChar,80,0) ,
          new ParDef("lV197Core_visitawwds_24_tfvisassunto",GXType.VarChar,80,0) ,
          new ParDef("AV198Core_visitawwds_25_tfvisassunto_sel",GXType.VarChar,80,0) ,
          new ParDef("lV200Core_visitawwds_27_tfvislink",GXType.VarChar,1000,0) ,
          new ParDef("AV201Core_visitawwds_28_tfvislink_sel",GXType.VarChar,1000,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00562", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00562,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00563", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00563,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00564", "SELECT NegID, NegAssunto, NegCodigo, NegUltIteNome FROM tb_negociopj WHERE NegID = :AV129VisNegID ORDER BY NegID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00564,1, GxCacheFrequency.OFF ,true,true )
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
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((Guid[]) buf[4])[0] = rslt.getGuid(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((Guid[]) buf[6])[0] = rslt.getGuid(5);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((Guid[]) buf[8])[0] = rslt.getGuid(6);
                ((string[]) buf[9])[0] = rslt.getVarchar(7);
                ((bool[]) buf[10])[0] = rslt.wasNull(7);
                ((string[]) buf[11])[0] = rslt.getVarchar(8);
                ((string[]) buf[12])[0] = rslt.getVarchar(9);
                ((string[]) buf[13])[0] = rslt.getVarchar(10);
                ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(11);
                ((bool[]) buf[15])[0] = rslt.wasNull(11);
                ((DateTime[]) buf[16])[0] = rslt.getGXDateTime(12);
                ((bool[]) buf[17])[0] = rslt.wasNull(12);
                ((DateTime[]) buf[18])[0] = rslt.getGXDate(13);
                ((bool[]) buf[19])[0] = rslt.wasNull(13);
                ((DateTime[]) buf[20])[0] = rslt.getGXDateTime(14);
                ((DateTime[]) buf[21])[0] = rslt.getGXDateTime(15);
                ((DateTime[]) buf[22])[0] = rslt.getGXDate(16);
                ((string[]) buf[23])[0] = rslt.getVarchar(17);
                ((bool[]) buf[24])[0] = rslt.wasNull(17);
                ((DateTime[]) buf[25])[0] = rslt.getGXDateTime(18, true);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                return;
       }
    }

 }

}
