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
   public class documentoarquivoww : GXDataArea
   {
      public documentoarquivoww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public documentoarquivoww( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_DocID )
      {
         this.AV119DocID = aP0_DocID;
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
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "DocID");
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
               gxfirstwebparm = GetFirstPar( "DocID");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "DocID");
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
         nRC_GXsfl_120 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_120"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_120_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_120_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_120_idx = GetPar( "sGXsfl_120_idx");
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
         AV20DocArqInsData1 = context.localUtil.ParseDateParm( GetPar( "DocArqInsData1"));
         AV25DocArqInsData2 = context.localUtil.ParseDateParm( GetPar( "DocArqInsData2"));
         AV30DocArqInsData3 = context.localUtil.ParseDateParm( GetPar( "DocArqInsData3"));
         AV119DocID = StringUtil.StrToGuid( GetPar( "DocID"));
         AV43ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV121Pgmname = GetPar( "Pgmname");
         AV120DocID_Filtro = StringUtil.StrToGuid( GetPar( "DocID_Filtro"));
         AV21DocArqInsData_To1 = context.localUtil.ParseDateParm( GetPar( "DocArqInsData_To1"));
         AV22DynamicFiltersEnabled2 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled2"));
         AV26DocArqInsData_To2 = context.localUtil.ParseDateParm( GetPar( "DocArqInsData_To2"));
         AV27DynamicFiltersEnabled3 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled3"));
         AV31DocArqInsData_To3 = context.localUtil.ParseDateParm( GetPar( "DocArqInsData_To3"));
         AV97TFDocArqConteudoNome = GetPar( "TFDocArqConteudoNome");
         AV98TFDocArqConteudoNome_Sel = GetPar( "TFDocArqConteudoNome_Sel");
         AV99TFDocArqConteudoExtensao = GetPar( "TFDocArqConteudoExtensao");
         AV100TFDocArqConteudoExtensao_Sel = GetPar( "TFDocArqConteudoExtensao_Sel");
         AV58TFDocArqInsDataHora = context.localUtil.ParseDTimeParm( GetPar( "TFDocArqInsDataHora"));
         AV59TFDocArqInsDataHora_To = context.localUtil.ParseDTimeParm( GetPar( "TFDocArqInsDataHora_To"));
         AV101TFDocArqObservacao = GetPar( "TFDocArqObservacao");
         AV102TFDocArqObservacao_Sel = GetPar( "TFDocArqObservacao_Sel");
         AV14OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV15OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV11GridState);
         AV33DynamicFiltersIgnoreFirst = StringUtil.StrToBool( GetPar( "DynamicFiltersIgnoreFirst"));
         AV32DynamicFiltersRemoving = StringUtil.StrToBool( GetPar( "DynamicFiltersRemoving"));
         AV111IsAuthorized_Update = StringUtil.StrToBool( GetPar( "IsAuthorized_Update"));
         AV112IsAuthorized_Delete = StringUtil.StrToBool( GetPar( "IsAuthorized_Delete"));
         Gx_date = context.localUtil.ParseDateParm( GetPar( "Gx_date"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV20DocArqInsData1, AV25DocArqInsData2, AV30DocArqInsData3, AV119DocID, AV43ManageFiltersExecutionStep, AV121Pgmname, AV120DocID_Filtro, AV21DocArqInsData_To1, AV22DynamicFiltersEnabled2, AV26DocArqInsData_To2, AV27DynamicFiltersEnabled3, AV31DocArqInsData_To3, AV97TFDocArqConteudoNome, AV98TFDocArqConteudoNome_Sel, AV99TFDocArqConteudoExtensao, AV100TFDocArqConteudoExtensao_Sel, AV58TFDocArqInsDataHora, AV59TFDocArqInsDataHora_To, AV101TFDocArqObservacao, AV102TFDocArqObservacao_Sel, AV14OrderedBy, AV15OrderedDsc, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV111IsAuthorized_Update, AV112IsAuthorized_Delete, Gx_date) ;
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
            return "documentoarquivoww_Execute" ;
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
         PA5K2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START5K2( ) ;
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
         GXEncryptionTmp = "core.documentoarquivoww.aspx"+UrlEncode(AV119DocID.ToString());
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("core.documentoarquivoww.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV121Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV121Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV111IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV111IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV112IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV112IsAuthorized_Delete, context));
         GxWebStd.gx_hidden_field( context, "vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vTODAY", GetSecureSignedToken( "", Gx_date, context));
         GxWebStd.gx_hidden_field( context, "gxhash_vDOCID", GetSecureSignedToken( "", AV119DocID, context));
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
         GxWebStd.gx_hidden_field( context, "GXH_vDOCARQINSDATA1", context.localUtil.Format(AV20DocArqInsData1, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "GXH_vDOCARQINSDATA2", context.localUtil.Format(AV25DocArqInsData2, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "GXH_vDOCARQINSDATA3", context.localUtil.Format(AV30DocArqInsData3, "99/99/99"));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_120", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_120), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV41ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV41ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV107GridCurrentPage), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV108GridPageCount), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV109GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAGEXPORTDATA", AV113AGExportData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAGEXPORTDATA", AV113AGExportData);
         }
         GxWebStd.gx_hidden_field( context, "vDOCARQINSDATA1", context.localUtil.DToC( AV20DocArqInsData1, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDOCARQINSDATA_TO1", context.localUtil.DToC( AV21DocArqInsData_To1, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDOCARQINSDATA2", context.localUtil.DToC( AV25DocArqInsData2, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDOCARQINSDATA_TO2", context.localUtil.DToC( AV26DocArqInsData_To2, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDOCARQINSDATA3", context.localUtil.DToC( AV30DocArqInsData3, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDOCARQINSDATA_TO3", context.localUtil.DToC( AV31DocArqInsData_To3, 0, "/"));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV103DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV103DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, "vDDO_DOCARQINSDATAHORAAUXDATE", context.localUtil.DToC( AV60DDO_DocArqInsDataHoraAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_DOCARQINSDATAHORAAUXDATETO", context.localUtil.DToC( AV61DDO_DocArqInsDataHoraAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV43ManageFiltersExecutionStep), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV121Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV121Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED2", AV22DynamicFiltersEnabled2);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED3", AV27DynamicFiltersEnabled3);
         GxWebStd.gx_hidden_field( context, "vTFDOCARQCONTEUDONOME", AV97TFDocArqConteudoNome);
         GxWebStd.gx_hidden_field( context, "vTFDOCARQCONTEUDONOME_SEL", AV98TFDocArqConteudoNome_Sel);
         GxWebStd.gx_hidden_field( context, "vTFDOCARQCONTEUDOEXTENSAO", AV99TFDocArqConteudoExtensao);
         GxWebStd.gx_hidden_field( context, "vTFDOCARQCONTEUDOEXTENSAO_SEL", AV100TFDocArqConteudoExtensao_Sel);
         GxWebStd.gx_hidden_field( context, "vTFDOCARQINSDATAHORA", context.localUtil.TToC( AV58TFDocArqInsDataHora, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vTFDOCARQINSDATAHORA_TO", context.localUtil.TToC( AV59TFDocArqInsDataHora_To, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vTFDOCARQOBSERVACAO", AV101TFDocArqObservacao);
         GxWebStd.gx_hidden_field( context, "vTFDOCARQOBSERVACAO_SEL", AV102TFDocArqObservacao_Sel);
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
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV111IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV111IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV112IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV112IsAuthorized_Delete, context));
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
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Sortedstatus", StringUtil.RTrim( Ddo_grid_Sortedstatus));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includefilter", StringUtil.RTrim( Ddo_grid_Includefilter));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filtertype", StringUtil.RTrim( Ddo_grid_Filtertype));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filterisrange", StringUtil.RTrim( Ddo_grid_Filterisrange));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includedatalist", StringUtil.RTrim( Ddo_grid_Includedatalist));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalisttype", StringUtil.RTrim( Ddo_grid_Datalisttype));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistproc", StringUtil.RTrim( Ddo_grid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Fixedcolumns", StringUtil.RTrim( Grid_empowerer_Fixedcolumns));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Activeeventkey", StringUtil.RTrim( Ddo_agexport_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
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
            WE5K2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT5K2( ) ;
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
         GXEncryptionTmp = "core.documentoarquivoww.aspx"+UrlEncode(AV119DocID.ToString());
         return formatLink("core.documentoarquivoww.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "core.DocumentoArquivoWW" ;
      }

      public override string GetPgmdesc( )
      {
         return " Arquivos do Documento" ;
      }

      protected void WB5K0( )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavDocid_filtro_Internalname, "Doc ID_Filtro", "col-sm-3 InvisibleLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 10,'',false,'" + sGXsfl_120_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDocid_filtro_Internalname, AV120DocID_Filtro.ToString(), AV120DocID_Filtro.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,10);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDocid_filtro_Jsonclick, 0, "Invisible", "", "", "", "", 1, edtavDocid_filtro_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_core\\DocumentoArquivoWW.htm");
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
            ClassString = "ColumnsSelector";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnagexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(120), 3, 0)+","+"null"+");", "Exportar", bttBtnagexport_Jsonclick, 0, "Exportar", "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\DocumentoArquivoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnsubscriptions_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(120), 3, 0)+","+"null"+");", "", bttBtnsubscriptions_Jsonclick, 0, "Assinaturas", "", StyleString, ClassString, bttBtnsubscriptions_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\DocumentoArquivoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            wb_table1_25_5K2( true) ;
         }
         else
         {
            wb_table1_25_5K2( false) ;
         }
         return  ;
      }

      protected void wb_table1_25_5K2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix1_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_core\\DocumentoArquivoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector1_Internalname, "Dynamic Filters Selector1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'" + sGXsfl_120_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector1, cmbavDynamicfiltersselector1_Internalname, StringUtil.RTrim( AV18DynamicFiltersSelector1), 1, cmbavDynamicfiltersselector1_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR1.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,45);\"", "", true, 0, "HLP_core\\DocumentoArquivoWW.htm");
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", (string)(cmbavDynamicfiltersselector1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle1_Internalname, "valor", "", "", lblDynamicfiltersmiddle1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_core\\DocumentoArquivoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            wb_table2_49_5K2( true) ;
         }
         else
         {
            wb_table2_49_5K2( false) ;
         }
         return  ;
      }

      protected void wb_table2_49_5K2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix2_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_core\\DocumentoArquivoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector2_Internalname, "Dynamic Filters Selector2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 70,'',false,'" + sGXsfl_120_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector2, cmbavDynamicfiltersselector2_Internalname, StringUtil.RTrim( AV23DynamicFiltersSelector2), 1, cmbavDynamicfiltersselector2_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR2.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,70);\"", "", true, 0, "HLP_core\\DocumentoArquivoWW.htm");
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV23DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", (string)(cmbavDynamicfiltersselector2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle2_Internalname, "valor", "", "", lblDynamicfiltersmiddle2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_core\\DocumentoArquivoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table3_74_5K2( true) ;
         }
         else
         {
            wb_table3_74_5K2( false) ;
         }
         return  ;
      }

      protected void wb_table3_74_5K2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix3_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_core\\DocumentoArquivoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector3_Internalname, "Dynamic Filters Selector3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 95,'',false,'" + sGXsfl_120_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector3, cmbavDynamicfiltersselector3_Internalname, StringUtil.RTrim( AV28DynamicFiltersSelector3), 1, cmbavDynamicfiltersselector3_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR3.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,95);\"", "", true, 0, "HLP_core\\DocumentoArquivoWW.htm");
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV28DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", (string)(cmbavDynamicfiltersselector3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle3_Internalname, "valor", "", "", lblDynamicfiltersmiddle3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_core\\DocumentoArquivoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table4_99_5K2( true) ;
         }
         else
         {
            wb_table4_99_5K2( false) ;
         }
         return  ;
      }

      protected void wb_table4_99_5K2e( bool wbgen )
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
            StartGridControl120( ) ;
         }
         if ( wbEnd == 120 )
         {
            wbEnd = 0;
            nRC_GXsfl_120 = (int)(nGXsfl_120_idx-1);
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV107GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV108GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV109GridAppliedFilters);
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
            ucDdo_agexport.SetProperty("DropDownOptionsData", AV113AGExportData);
            ucDdo_agexport.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_agexport_Internalname, "DDO_AGEXPORTContainer");
            /* User Defined Control */
            ucDdc_subscriptions.SetProperty("IconType", Ddc_subscriptions_Icontype);
            ucDdc_subscriptions.SetProperty("Icon", Ddc_subscriptions_Icon);
            ucDdc_subscriptions.SetProperty("Caption", Ddc_subscriptions_Caption);
            ucDdc_subscriptions.SetProperty("Tooltip", Ddc_subscriptions_Tooltip);
            ucDdc_subscriptions.SetProperty("Cls", Ddc_subscriptions_Cls);
            ucDdc_subscriptions.Render(context, "dvelop.gxbootstrap.ddcomponent", Ddc_subscriptions_Internalname, "DDC_SUBSCRIPTIONSContainer");
            /* User Defined Control */
            ucDocarqinsdata_rangepicker1.SetProperty("Start Date", AV20DocArqInsData1);
            ucDocarqinsdata_rangepicker1.SetProperty("End Date", AV21DocArqInsData_To1);
            ucDocarqinsdata_rangepicker1.Render(context, "wwp.daterangepicker", Docarqinsdata_rangepicker1_Internalname, "DOCARQINSDATA_RANGEPICKER1Container");
            /* User Defined Control */
            ucDocarqinsdata_rangepicker2.SetProperty("Start Date", AV25DocArqInsData2);
            ucDocarqinsdata_rangepicker2.SetProperty("End Date", AV26DocArqInsData_To2);
            ucDocarqinsdata_rangepicker2.Render(context, "wwp.daterangepicker", Docarqinsdata_rangepicker2_Internalname, "DOCARQINSDATA_RANGEPICKER2Container");
            /* User Defined Control */
            ucDocarqinsdata_rangepicker3.SetProperty("Start Date", AV30DocArqInsData3);
            ucDocarqinsdata_rangepicker3.SetProperty("End Date", AV31DocArqInsData_To3);
            ucDocarqinsdata_rangepicker3.Render(context, "wwp.daterangepicker", Docarqinsdata_rangepicker3_Internalname, "DOCARQINSDATA_RANGEPICKER3Container");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblJsdynamicfilters_Internalname, lblJsdynamicfilters_Caption, "", "", lblJsdynamicfilters_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_core\\DocumentoArquivoWW.htm");
            /* User Defined Control */
            ucDdo_grid.SetProperty("Caption", Ddo_grid_Caption);
            ucDdo_grid.SetProperty("ColumnIds", Ddo_grid_Columnids);
            ucDdo_grid.SetProperty("ColumnsSortValues", Ddo_grid_Columnssortvalues);
            ucDdo_grid.SetProperty("IncludeSortASC", Ddo_grid_Includesortasc);
            ucDdo_grid.SetProperty("IncludeFilter", Ddo_grid_Includefilter);
            ucDdo_grid.SetProperty("FilterType", Ddo_grid_Filtertype);
            ucDdo_grid.SetProperty("FilterIsRange", Ddo_grid_Filterisrange);
            ucDdo_grid.SetProperty("IncludeDataList", Ddo_grid_Includedatalist);
            ucDdo_grid.SetProperty("DataListType", Ddo_grid_Datalisttype);
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV103DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtavDocid_Internalname, AV119DocID.ToString(), AV119DocID.ToString(), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDocid_Jsonclick, 0, "Attribute", "", "", "", "", edtavDocid_Visible, 0, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_core\\DocumentoArquivoWW.htm");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.SetProperty("FixedColumns", Grid_empowerer_Fixedcolumns);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDiv_wwpauxwc_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0144"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0144"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( bGXsfl_120_Refreshing )
               {
                  if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                  {
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0144"+"");
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
            GxWebStd.gx_div_start( context, divDdo_docarqinsdatahoraauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 146,'',false,'" + sGXsfl_120_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_docarqinsdatahoraauxdatetext_Internalname, AV62DDO_DocArqInsDataHoraAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV62DDO_DocArqInsDataHoraAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,146);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_docarqinsdatahoraauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\DocumentoArquivoWW.htm");
            /* User Defined Control */
            ucTfdocarqinsdatahora_rangepicker.SetProperty("Start Date", AV60DDO_DocArqInsDataHoraAuxDate);
            ucTfdocarqinsdatahora_rangepicker.SetProperty("End Date", AV61DDO_DocArqInsDataHoraAuxDateTo);
            ucTfdocarqinsdatahora_rangepicker.Render(context, "wwp.daterangepicker", Tfdocarqinsdatahora_rangepicker_Internalname, "TFDOCARQINSDATAHORA_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 120 )
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

      protected void START5K2( )
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
            Form.Meta.addItem("description", " Arquivos do Documento", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP5K0( ) ;
      }

      protected void WS5K2( )
      {
         START5K2( ) ;
         EVT5K2( ) ;
      }

      protected void EVT5K2( )
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
                              E115K2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E125K2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E135K2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_AGEXPORT.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E145K2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDC_SUBSCRIPTIONS.ONLOADCOMPONENT") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E155K2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DOCARQINSDATA_RANGEPICKER1.DATERANGECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E165K2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DOCARQINSDATA_RANGEPICKER2.DATERANGECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E175K2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DOCARQINSDATA_RANGEPICKER3.DATERANGECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E185K2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E195K2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters1' */
                              E205K2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters2' */
                              E215K2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS3'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters3' */
                              E225K2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters1' */
                              E235K2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR1.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E245K2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSOPERATOR1.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E255K2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters2' */
                              E265K2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR2.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E275K2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSOPERATOR2.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E285K2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR3.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E295K2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSOPERATOR3.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E305K2 ();
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
                              nGXsfl_120_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_120_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_120_idx), 4, 0), 4, "0");
                              SubsflControlProps_1202( ) ;
                              cmbavGridactions.Name = cmbavGridactions_Internalname;
                              cmbavGridactions.CurrentValue = cgiGet( cmbavGridactions_Internalname);
                              AV110GridActions = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavGridactions_Internalname), "."), 18, MidpointRounding.ToEven));
                              AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV110GridActions), 4, 0));
                              A289DocID = StringUtil.StrToGuid( cgiGet( edtDocID_Internalname));
                              A307DocArqSeq = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtDocArqSeq_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A322DocArqConteudoNome = cgiGet( edtDocArqConteudoNome_Internalname);
                              A323DocArqConteudoExtensao = cgiGet( edtDocArqConteudoExtensao_Internalname);
                              A310DocArqInsDataHora = context.localUtil.CToT( cgiGet( edtDocArqInsDataHora_Internalname), 0);
                              A324DocArqObservacao = cgiGet( edtDocArqObservacao_Internalname);
                              n324DocArqObservacao = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E315K2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E325K2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E335K2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VGRIDACTIONS.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E345K2 ();
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
                                       /* Set Refresh If Docarqinsdata1 Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vDOCARQINSDATA1"), 0) != AV20DocArqInsData1 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Docarqinsdata2 Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vDOCARQINSDATA2"), 0) != AV25DocArqInsData2 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Docarqinsdata3 Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vDOCARQINSDATA3"), 0) != AV30DocArqInsData3 )
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
                        if ( nCmpId == 144 )
                        {
                           OldWwpaux_wc = cgiGet( "W0144");
                           if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                           {
                              WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                              WebComp_Wwpaux_wc.ComponentInit();
                              WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                              WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                           }
                           if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                           {
                              WebComp_Wwpaux_wc.componentprocess("W0144", "", sEvt);
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

      protected void WE5K2( )
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

      protected void PA5K2( )
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
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "core.documentoarquivoww.aspx")), "core.documentoarquivoww.aspx") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "core.documentoarquivoww.aspx")))) ;
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
                  gxfirstwebparm = GetFirstPar( "DocID");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV119DocID = StringUtil.StrToGuid( gxfirstwebparm);
                     AssignAttri("", false, "AV119DocID", AV119DocID.ToString());
                     GxWebStd.gx_hidden_field( context, "gxhash_vDOCID", GetSecureSignedToken( "", AV119DocID, context));
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
               GX_FocusControl = edtavDocid_filtro_Internalname;
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
         SubsflControlProps_1202( ) ;
         while ( nGXsfl_120_idx <= nRC_GXsfl_120 )
         {
            sendrow_1202( ) ;
            nGXsfl_120_idx = ((subGrid_Islastpage==1)&&(nGXsfl_120_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_120_idx+1);
            sGXsfl_120_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_120_idx), 4, 0), 4, "0");
            SubsflControlProps_1202( ) ;
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
                                       DateTime AV20DocArqInsData1 ,
                                       DateTime AV25DocArqInsData2 ,
                                       DateTime AV30DocArqInsData3 ,
                                       Guid AV119DocID ,
                                       short AV43ManageFiltersExecutionStep ,
                                       string AV121Pgmname ,
                                       Guid AV120DocID_Filtro ,
                                       DateTime AV21DocArqInsData_To1 ,
                                       bool AV22DynamicFiltersEnabled2 ,
                                       DateTime AV26DocArqInsData_To2 ,
                                       bool AV27DynamicFiltersEnabled3 ,
                                       DateTime AV31DocArqInsData_To3 ,
                                       string AV97TFDocArqConteudoNome ,
                                       string AV98TFDocArqConteudoNome_Sel ,
                                       string AV99TFDocArqConteudoExtensao ,
                                       string AV100TFDocArqConteudoExtensao_Sel ,
                                       DateTime AV58TFDocArqInsDataHora ,
                                       DateTime AV59TFDocArqInsDataHora_To ,
                                       string AV101TFDocArqObservacao ,
                                       string AV102TFDocArqObservacao_Sel ,
                                       short AV14OrderedBy ,
                                       bool AV15OrderedDsc ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ,
                                       bool AV33DynamicFiltersIgnoreFirst ,
                                       bool AV32DynamicFiltersRemoving ,
                                       bool AV111IsAuthorized_Update ,
                                       bool AV112IsAuthorized_Delete ,
                                       DateTime Gx_date )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF5K2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_DOCID", GetSecureSignedToken( "", A289DocID, context));
         GxWebStd.gx_hidden_field( context, "DOCID", A289DocID.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_DOCARQSEQ", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A307DocArqSeq), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "DOCARQSEQ", StringUtil.LTrim( StringUtil.NToC( (decimal)(A307DocArqSeq), 4, 0, ".", "")));
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
         RF5K2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
         AV121Pgmname = "core.DocumentoArquivoWW";
      }

      protected void RF5K2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 120;
         /* Execute user event: Refresh */
         E325K2 ();
         nGXsfl_120_idx = 1;
         sGXsfl_120_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_120_idx), 4, 0), 4, "0");
         SubsflControlProps_1202( ) ;
         bGXsfl_120_Refreshing = true;
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
            SubsflControlProps_1202( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV123Core_documentoarquivowwds_2_filterfulltext ,
                                                 AV124Core_documentoarquivowwds_3_dynamicfiltersselector1 ,
                                                 AV125Core_documentoarquivowwds_4_dynamicfiltersoperator1 ,
                                                 AV126Core_documentoarquivowwds_5_docarqinsdata1 ,
                                                 AV127Core_documentoarquivowwds_6_docarqinsdata_to1 ,
                                                 AV128Core_documentoarquivowwds_7_dynamicfiltersenabled2 ,
                                                 AV129Core_documentoarquivowwds_8_dynamicfiltersselector2 ,
                                                 AV130Core_documentoarquivowwds_9_dynamicfiltersoperator2 ,
                                                 AV131Core_documentoarquivowwds_10_docarqinsdata2 ,
                                                 AV132Core_documentoarquivowwds_11_docarqinsdata_to2 ,
                                                 AV133Core_documentoarquivowwds_12_dynamicfiltersenabled3 ,
                                                 AV134Core_documentoarquivowwds_13_dynamicfiltersselector3 ,
                                                 AV135Core_documentoarquivowwds_14_dynamicfiltersoperator3 ,
                                                 AV136Core_documentoarquivowwds_15_docarqinsdata3 ,
                                                 AV137Core_documentoarquivowwds_16_docarqinsdata_to3 ,
                                                 AV139Core_documentoarquivowwds_18_tfdocarqconteudonome_sel ,
                                                 AV138Core_documentoarquivowwds_17_tfdocarqconteudonome ,
                                                 AV141Core_documentoarquivowwds_20_tfdocarqconteudoextensao_sel ,
                                                 AV140Core_documentoarquivowwds_19_tfdocarqconteudoextensao ,
                                                 AV142Core_documentoarquivowwds_21_tfdocarqinsdatahora ,
                                                 AV143Core_documentoarquivowwds_22_tfdocarqinsdatahora_to ,
                                                 AV145Core_documentoarquivowwds_24_tfdocarqobservacao_sel ,
                                                 AV144Core_documentoarquivowwds_23_tfdocarqobservacao ,
                                                 A322DocArqConteudoNome ,
                                                 A323DocArqConteudoExtensao ,
                                                 A324DocArqObservacao ,
                                                 A308DocArqInsData ,
                                                 A310DocArqInsDataHora ,
                                                 AV14OrderedBy ,
                                                 AV15OrderedDsc ,
                                                 AV119DocID ,
                                                 A289DocID } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE,
                                                 TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV123Core_documentoarquivowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV123Core_documentoarquivowwds_2_filterfulltext), "%", "");
            lV123Core_documentoarquivowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV123Core_documentoarquivowwds_2_filterfulltext), "%", "");
            lV123Core_documentoarquivowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV123Core_documentoarquivowwds_2_filterfulltext), "%", "");
            lV138Core_documentoarquivowwds_17_tfdocarqconteudonome = StringUtil.Concat( StringUtil.RTrim( AV138Core_documentoarquivowwds_17_tfdocarqconteudonome), "%", "");
            lV140Core_documentoarquivowwds_19_tfdocarqconteudoextensao = StringUtil.Concat( StringUtil.RTrim( AV140Core_documentoarquivowwds_19_tfdocarqconteudoextensao), "%", "");
            lV144Core_documentoarquivowwds_23_tfdocarqobservacao = StringUtil.Concat( StringUtil.RTrim( AV144Core_documentoarquivowwds_23_tfdocarqobservacao), "%", "");
            /* Using cursor H005K2 */
            pr_default.execute(0, new Object[] {AV119DocID, lV123Core_documentoarquivowwds_2_filterfulltext, lV123Core_documentoarquivowwds_2_filterfulltext, lV123Core_documentoarquivowwds_2_filterfulltext, AV126Core_documentoarquivowwds_5_docarqinsdata1, AV126Core_documentoarquivowwds_5_docarqinsdata1, AV126Core_documentoarquivowwds_5_docarqinsdata1, AV126Core_documentoarquivowwds_5_docarqinsdata1, AV127Core_documentoarquivowwds_6_docarqinsdata_to1, AV131Core_documentoarquivowwds_10_docarqinsdata2, AV131Core_documentoarquivowwds_10_docarqinsdata2, AV131Core_documentoarquivowwds_10_docarqinsdata2, AV131Core_documentoarquivowwds_10_docarqinsdata2, AV132Core_documentoarquivowwds_11_docarqinsdata_to2, AV136Core_documentoarquivowwds_15_docarqinsdata3, AV136Core_documentoarquivowwds_15_docarqinsdata3, AV136Core_documentoarquivowwds_15_docarqinsdata3, AV136Core_documentoarquivowwds_15_docarqinsdata3, AV137Core_documentoarquivowwds_16_docarqinsdata_to3, lV138Core_documentoarquivowwds_17_tfdocarqconteudonome, AV139Core_documentoarquivowwds_18_tfdocarqconteudonome_sel, lV140Core_documentoarquivowwds_19_tfdocarqconteudoextensao, AV141Core_documentoarquivowwds_20_tfdocarqconteudoextensao_sel, AV142Core_documentoarquivowwds_21_tfdocarqinsdatahora, AV143Core_documentoarquivowwds_22_tfdocarqinsdatahora_to, lV144Core_documentoarquivowwds_23_tfdocarqobservacao, AV145Core_documentoarquivowwds_24_tfdocarqobservacao_sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_120_idx = 1;
            sGXsfl_120_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_120_idx), 4, 0), 4, "0");
            SubsflControlProps_1202( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A308DocArqInsData = H005K2_A308DocArqInsData[0];
               A324DocArqObservacao = H005K2_A324DocArqObservacao[0];
               n324DocArqObservacao = H005K2_n324DocArqObservacao[0];
               A310DocArqInsDataHora = H005K2_A310DocArqInsDataHora[0];
               A323DocArqConteudoExtensao = H005K2_A323DocArqConteudoExtensao[0];
               A322DocArqConteudoNome = H005K2_A322DocArqConteudoNome[0];
               A307DocArqSeq = H005K2_A307DocArqSeq[0];
               A289DocID = H005K2_A289DocID[0];
               E335K2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 120;
            WB5K0( ) ;
         }
         bGXsfl_120_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes5K2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV121Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV121Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV111IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV111IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV112IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV112IsAuthorized_Delete, context));
         GxWebStd.gx_hidden_field( context, "vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vTODAY", GetSecureSignedToken( "", Gx_date, context));
         GxWebStd.gx_hidden_field( context, "gxhash_DOCID"+"_"+sGXsfl_120_idx, GetSecureSignedToken( sGXsfl_120_idx, A289DocID, context));
         GxWebStd.gx_hidden_field( context, "gxhash_DOCARQSEQ"+"_"+sGXsfl_120_idx, GetSecureSignedToken( sGXsfl_120_idx, context.localUtil.Format( (decimal)(A307DocArqSeq), "ZZZ9"), context));
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
         AV122Core_documentoarquivowwds_1_docid_filtro = AV120DocID_Filtro;
         AV123Core_documentoarquivowwds_2_filterfulltext = AV17FilterFullText;
         AV124Core_documentoarquivowwds_3_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV125Core_documentoarquivowwds_4_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV126Core_documentoarquivowwds_5_docarqinsdata1 = AV20DocArqInsData1;
         AV127Core_documentoarquivowwds_6_docarqinsdata_to1 = AV21DocArqInsData_To1;
         AV128Core_documentoarquivowwds_7_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV129Core_documentoarquivowwds_8_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV130Core_documentoarquivowwds_9_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV131Core_documentoarquivowwds_10_docarqinsdata2 = AV25DocArqInsData2;
         AV132Core_documentoarquivowwds_11_docarqinsdata_to2 = AV26DocArqInsData_To2;
         AV133Core_documentoarquivowwds_12_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV134Core_documentoarquivowwds_13_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV135Core_documentoarquivowwds_14_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV136Core_documentoarquivowwds_15_docarqinsdata3 = AV30DocArqInsData3;
         AV137Core_documentoarquivowwds_16_docarqinsdata_to3 = AV31DocArqInsData_To3;
         AV138Core_documentoarquivowwds_17_tfdocarqconteudonome = AV97TFDocArqConteudoNome;
         AV139Core_documentoarquivowwds_18_tfdocarqconteudonome_sel = AV98TFDocArqConteudoNome_Sel;
         AV140Core_documentoarquivowwds_19_tfdocarqconteudoextensao = AV99TFDocArqConteudoExtensao;
         AV141Core_documentoarquivowwds_20_tfdocarqconteudoextensao_sel = AV100TFDocArqConteudoExtensao_Sel;
         AV142Core_documentoarquivowwds_21_tfdocarqinsdatahora = AV58TFDocArqInsDataHora;
         AV143Core_documentoarquivowwds_22_tfdocarqinsdatahora_to = AV59TFDocArqInsDataHora_To;
         AV144Core_documentoarquivowwds_23_tfdocarqobservacao = AV101TFDocArqObservacao;
         AV145Core_documentoarquivowwds_24_tfdocarqobservacao_sel = AV102TFDocArqObservacao_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV123Core_documentoarquivowwds_2_filterfulltext ,
                                              AV124Core_documentoarquivowwds_3_dynamicfiltersselector1 ,
                                              AV125Core_documentoarquivowwds_4_dynamicfiltersoperator1 ,
                                              AV126Core_documentoarquivowwds_5_docarqinsdata1 ,
                                              AV127Core_documentoarquivowwds_6_docarqinsdata_to1 ,
                                              AV128Core_documentoarquivowwds_7_dynamicfiltersenabled2 ,
                                              AV129Core_documentoarquivowwds_8_dynamicfiltersselector2 ,
                                              AV130Core_documentoarquivowwds_9_dynamicfiltersoperator2 ,
                                              AV131Core_documentoarquivowwds_10_docarqinsdata2 ,
                                              AV132Core_documentoarquivowwds_11_docarqinsdata_to2 ,
                                              AV133Core_documentoarquivowwds_12_dynamicfiltersenabled3 ,
                                              AV134Core_documentoarquivowwds_13_dynamicfiltersselector3 ,
                                              AV135Core_documentoarquivowwds_14_dynamicfiltersoperator3 ,
                                              AV136Core_documentoarquivowwds_15_docarqinsdata3 ,
                                              AV137Core_documentoarquivowwds_16_docarqinsdata_to3 ,
                                              AV139Core_documentoarquivowwds_18_tfdocarqconteudonome_sel ,
                                              AV138Core_documentoarquivowwds_17_tfdocarqconteudonome ,
                                              AV141Core_documentoarquivowwds_20_tfdocarqconteudoextensao_sel ,
                                              AV140Core_documentoarquivowwds_19_tfdocarqconteudoextensao ,
                                              AV142Core_documentoarquivowwds_21_tfdocarqinsdatahora ,
                                              AV143Core_documentoarquivowwds_22_tfdocarqinsdatahora_to ,
                                              AV145Core_documentoarquivowwds_24_tfdocarqobservacao_sel ,
                                              AV144Core_documentoarquivowwds_23_tfdocarqobservacao ,
                                              A322DocArqConteudoNome ,
                                              A323DocArqConteudoExtensao ,
                                              A324DocArqObservacao ,
                                              A308DocArqInsData ,
                                              A310DocArqInsDataHora ,
                                              AV14OrderedBy ,
                                              AV15OrderedDsc ,
                                              AV119DocID ,
                                              A289DocID } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV123Core_documentoarquivowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV123Core_documentoarquivowwds_2_filterfulltext), "%", "");
         lV123Core_documentoarquivowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV123Core_documentoarquivowwds_2_filterfulltext), "%", "");
         lV123Core_documentoarquivowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV123Core_documentoarquivowwds_2_filterfulltext), "%", "");
         lV138Core_documentoarquivowwds_17_tfdocarqconteudonome = StringUtil.Concat( StringUtil.RTrim( AV138Core_documentoarquivowwds_17_tfdocarqconteudonome), "%", "");
         lV140Core_documentoarquivowwds_19_tfdocarqconteudoextensao = StringUtil.Concat( StringUtil.RTrim( AV140Core_documentoarquivowwds_19_tfdocarqconteudoextensao), "%", "");
         lV144Core_documentoarquivowwds_23_tfdocarqobservacao = StringUtil.Concat( StringUtil.RTrim( AV144Core_documentoarquivowwds_23_tfdocarqobservacao), "%", "");
         /* Using cursor H005K3 */
         pr_default.execute(1, new Object[] {AV119DocID, lV123Core_documentoarquivowwds_2_filterfulltext, lV123Core_documentoarquivowwds_2_filterfulltext, lV123Core_documentoarquivowwds_2_filterfulltext, AV126Core_documentoarquivowwds_5_docarqinsdata1, AV126Core_documentoarquivowwds_5_docarqinsdata1, AV126Core_documentoarquivowwds_5_docarqinsdata1, AV126Core_documentoarquivowwds_5_docarqinsdata1, AV127Core_documentoarquivowwds_6_docarqinsdata_to1, AV131Core_documentoarquivowwds_10_docarqinsdata2, AV131Core_documentoarquivowwds_10_docarqinsdata2, AV131Core_documentoarquivowwds_10_docarqinsdata2, AV131Core_documentoarquivowwds_10_docarqinsdata2, AV132Core_documentoarquivowwds_11_docarqinsdata_to2, AV136Core_documentoarquivowwds_15_docarqinsdata3, AV136Core_documentoarquivowwds_15_docarqinsdata3, AV136Core_documentoarquivowwds_15_docarqinsdata3, AV136Core_documentoarquivowwds_15_docarqinsdata3, AV137Core_documentoarquivowwds_16_docarqinsdata_to3, lV138Core_documentoarquivowwds_17_tfdocarqconteudonome, AV139Core_documentoarquivowwds_18_tfdocarqconteudonome_sel, lV140Core_documentoarquivowwds_19_tfdocarqconteudoextensao, AV141Core_documentoarquivowwds_20_tfdocarqconteudoextensao_sel, AV142Core_documentoarquivowwds_21_tfdocarqinsdatahora, AV143Core_documentoarquivowwds_22_tfdocarqinsdatahora_to, lV144Core_documentoarquivowwds_23_tfdocarqobservacao, AV145Core_documentoarquivowwds_24_tfdocarqobservacao_sel});
         GRID_nRecordCount = H005K3_AGRID_nRecordCount[0];
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
         AV122Core_documentoarquivowwds_1_docid_filtro = AV120DocID_Filtro;
         AV123Core_documentoarquivowwds_2_filterfulltext = AV17FilterFullText;
         AV124Core_documentoarquivowwds_3_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV125Core_documentoarquivowwds_4_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV126Core_documentoarquivowwds_5_docarqinsdata1 = AV20DocArqInsData1;
         AV127Core_documentoarquivowwds_6_docarqinsdata_to1 = AV21DocArqInsData_To1;
         AV128Core_documentoarquivowwds_7_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV129Core_documentoarquivowwds_8_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV130Core_documentoarquivowwds_9_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV131Core_documentoarquivowwds_10_docarqinsdata2 = AV25DocArqInsData2;
         AV132Core_documentoarquivowwds_11_docarqinsdata_to2 = AV26DocArqInsData_To2;
         AV133Core_documentoarquivowwds_12_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV134Core_documentoarquivowwds_13_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV135Core_documentoarquivowwds_14_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV136Core_documentoarquivowwds_15_docarqinsdata3 = AV30DocArqInsData3;
         AV137Core_documentoarquivowwds_16_docarqinsdata_to3 = AV31DocArqInsData_To3;
         AV138Core_documentoarquivowwds_17_tfdocarqconteudonome = AV97TFDocArqConteudoNome;
         AV139Core_documentoarquivowwds_18_tfdocarqconteudonome_sel = AV98TFDocArqConteudoNome_Sel;
         AV140Core_documentoarquivowwds_19_tfdocarqconteudoextensao = AV99TFDocArqConteudoExtensao;
         AV141Core_documentoarquivowwds_20_tfdocarqconteudoextensao_sel = AV100TFDocArqConteudoExtensao_Sel;
         AV142Core_documentoarquivowwds_21_tfdocarqinsdatahora = AV58TFDocArqInsDataHora;
         AV143Core_documentoarquivowwds_22_tfdocarqinsdatahora_to = AV59TFDocArqInsDataHora_To;
         AV144Core_documentoarquivowwds_23_tfdocarqobservacao = AV101TFDocArqObservacao;
         AV145Core_documentoarquivowwds_24_tfdocarqobservacao_sel = AV102TFDocArqObservacao_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV20DocArqInsData1, AV25DocArqInsData2, AV30DocArqInsData3, AV119DocID, AV43ManageFiltersExecutionStep, AV121Pgmname, AV120DocID_Filtro, AV21DocArqInsData_To1, AV22DynamicFiltersEnabled2, AV26DocArqInsData_To2, AV27DynamicFiltersEnabled3, AV31DocArqInsData_To3, AV97TFDocArqConteudoNome, AV98TFDocArqConteudoNome_Sel, AV99TFDocArqConteudoExtensao, AV100TFDocArqConteudoExtensao_Sel, AV58TFDocArqInsDataHora, AV59TFDocArqInsDataHora_To, AV101TFDocArqObservacao, AV102TFDocArqObservacao_Sel, AV14OrderedBy, AV15OrderedDsc, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV111IsAuthorized_Update, AV112IsAuthorized_Delete, Gx_date) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV122Core_documentoarquivowwds_1_docid_filtro = AV120DocID_Filtro;
         AV123Core_documentoarquivowwds_2_filterfulltext = AV17FilterFullText;
         AV124Core_documentoarquivowwds_3_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV125Core_documentoarquivowwds_4_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV126Core_documentoarquivowwds_5_docarqinsdata1 = AV20DocArqInsData1;
         AV127Core_documentoarquivowwds_6_docarqinsdata_to1 = AV21DocArqInsData_To1;
         AV128Core_documentoarquivowwds_7_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV129Core_documentoarquivowwds_8_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV130Core_documentoarquivowwds_9_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV131Core_documentoarquivowwds_10_docarqinsdata2 = AV25DocArqInsData2;
         AV132Core_documentoarquivowwds_11_docarqinsdata_to2 = AV26DocArqInsData_To2;
         AV133Core_documentoarquivowwds_12_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV134Core_documentoarquivowwds_13_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV135Core_documentoarquivowwds_14_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV136Core_documentoarquivowwds_15_docarqinsdata3 = AV30DocArqInsData3;
         AV137Core_documentoarquivowwds_16_docarqinsdata_to3 = AV31DocArqInsData_To3;
         AV138Core_documentoarquivowwds_17_tfdocarqconteudonome = AV97TFDocArqConteudoNome;
         AV139Core_documentoarquivowwds_18_tfdocarqconteudonome_sel = AV98TFDocArqConteudoNome_Sel;
         AV140Core_documentoarquivowwds_19_tfdocarqconteudoextensao = AV99TFDocArqConteudoExtensao;
         AV141Core_documentoarquivowwds_20_tfdocarqconteudoextensao_sel = AV100TFDocArqConteudoExtensao_Sel;
         AV142Core_documentoarquivowwds_21_tfdocarqinsdatahora = AV58TFDocArqInsDataHora;
         AV143Core_documentoarquivowwds_22_tfdocarqinsdatahora_to = AV59TFDocArqInsDataHora_To;
         AV144Core_documentoarquivowwds_23_tfdocarqobservacao = AV101TFDocArqObservacao;
         AV145Core_documentoarquivowwds_24_tfdocarqobservacao_sel = AV102TFDocArqObservacao_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV20DocArqInsData1, AV25DocArqInsData2, AV30DocArqInsData3, AV119DocID, AV43ManageFiltersExecutionStep, AV121Pgmname, AV120DocID_Filtro, AV21DocArqInsData_To1, AV22DynamicFiltersEnabled2, AV26DocArqInsData_To2, AV27DynamicFiltersEnabled3, AV31DocArqInsData_To3, AV97TFDocArqConteudoNome, AV98TFDocArqConteudoNome_Sel, AV99TFDocArqConteudoExtensao, AV100TFDocArqConteudoExtensao_Sel, AV58TFDocArqInsDataHora, AV59TFDocArqInsDataHora_To, AV101TFDocArqObservacao, AV102TFDocArqObservacao_Sel, AV14OrderedBy, AV15OrderedDsc, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV111IsAuthorized_Update, AV112IsAuthorized_Delete, Gx_date) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV122Core_documentoarquivowwds_1_docid_filtro = AV120DocID_Filtro;
         AV123Core_documentoarquivowwds_2_filterfulltext = AV17FilterFullText;
         AV124Core_documentoarquivowwds_3_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV125Core_documentoarquivowwds_4_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV126Core_documentoarquivowwds_5_docarqinsdata1 = AV20DocArqInsData1;
         AV127Core_documentoarquivowwds_6_docarqinsdata_to1 = AV21DocArqInsData_To1;
         AV128Core_documentoarquivowwds_7_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV129Core_documentoarquivowwds_8_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV130Core_documentoarquivowwds_9_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV131Core_documentoarquivowwds_10_docarqinsdata2 = AV25DocArqInsData2;
         AV132Core_documentoarquivowwds_11_docarqinsdata_to2 = AV26DocArqInsData_To2;
         AV133Core_documentoarquivowwds_12_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV134Core_documentoarquivowwds_13_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV135Core_documentoarquivowwds_14_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV136Core_documentoarquivowwds_15_docarqinsdata3 = AV30DocArqInsData3;
         AV137Core_documentoarquivowwds_16_docarqinsdata_to3 = AV31DocArqInsData_To3;
         AV138Core_documentoarquivowwds_17_tfdocarqconteudonome = AV97TFDocArqConteudoNome;
         AV139Core_documentoarquivowwds_18_tfdocarqconteudonome_sel = AV98TFDocArqConteudoNome_Sel;
         AV140Core_documentoarquivowwds_19_tfdocarqconteudoextensao = AV99TFDocArqConteudoExtensao;
         AV141Core_documentoarquivowwds_20_tfdocarqconteudoextensao_sel = AV100TFDocArqConteudoExtensao_Sel;
         AV142Core_documentoarquivowwds_21_tfdocarqinsdatahora = AV58TFDocArqInsDataHora;
         AV143Core_documentoarquivowwds_22_tfdocarqinsdatahora_to = AV59TFDocArqInsDataHora_To;
         AV144Core_documentoarquivowwds_23_tfdocarqobservacao = AV101TFDocArqObservacao;
         AV145Core_documentoarquivowwds_24_tfdocarqobservacao_sel = AV102TFDocArqObservacao_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV20DocArqInsData1, AV25DocArqInsData2, AV30DocArqInsData3, AV119DocID, AV43ManageFiltersExecutionStep, AV121Pgmname, AV120DocID_Filtro, AV21DocArqInsData_To1, AV22DynamicFiltersEnabled2, AV26DocArqInsData_To2, AV27DynamicFiltersEnabled3, AV31DocArqInsData_To3, AV97TFDocArqConteudoNome, AV98TFDocArqConteudoNome_Sel, AV99TFDocArqConteudoExtensao, AV100TFDocArqConteudoExtensao_Sel, AV58TFDocArqInsDataHora, AV59TFDocArqInsDataHora_To, AV101TFDocArqObservacao, AV102TFDocArqObservacao_Sel, AV14OrderedBy, AV15OrderedDsc, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV111IsAuthorized_Update, AV112IsAuthorized_Delete, Gx_date) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV122Core_documentoarquivowwds_1_docid_filtro = AV120DocID_Filtro;
         AV123Core_documentoarquivowwds_2_filterfulltext = AV17FilterFullText;
         AV124Core_documentoarquivowwds_3_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV125Core_documentoarquivowwds_4_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV126Core_documentoarquivowwds_5_docarqinsdata1 = AV20DocArqInsData1;
         AV127Core_documentoarquivowwds_6_docarqinsdata_to1 = AV21DocArqInsData_To1;
         AV128Core_documentoarquivowwds_7_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV129Core_documentoarquivowwds_8_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV130Core_documentoarquivowwds_9_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV131Core_documentoarquivowwds_10_docarqinsdata2 = AV25DocArqInsData2;
         AV132Core_documentoarquivowwds_11_docarqinsdata_to2 = AV26DocArqInsData_To2;
         AV133Core_documentoarquivowwds_12_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV134Core_documentoarquivowwds_13_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV135Core_documentoarquivowwds_14_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV136Core_documentoarquivowwds_15_docarqinsdata3 = AV30DocArqInsData3;
         AV137Core_documentoarquivowwds_16_docarqinsdata_to3 = AV31DocArqInsData_To3;
         AV138Core_documentoarquivowwds_17_tfdocarqconteudonome = AV97TFDocArqConteudoNome;
         AV139Core_documentoarquivowwds_18_tfdocarqconteudonome_sel = AV98TFDocArqConteudoNome_Sel;
         AV140Core_documentoarquivowwds_19_tfdocarqconteudoextensao = AV99TFDocArqConteudoExtensao;
         AV141Core_documentoarquivowwds_20_tfdocarqconteudoextensao_sel = AV100TFDocArqConteudoExtensao_Sel;
         AV142Core_documentoarquivowwds_21_tfdocarqinsdatahora = AV58TFDocArqInsDataHora;
         AV143Core_documentoarquivowwds_22_tfdocarqinsdatahora_to = AV59TFDocArqInsDataHora_To;
         AV144Core_documentoarquivowwds_23_tfdocarqobservacao = AV101TFDocArqObservacao;
         AV145Core_documentoarquivowwds_24_tfdocarqobservacao_sel = AV102TFDocArqObservacao_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV20DocArqInsData1, AV25DocArqInsData2, AV30DocArqInsData3, AV119DocID, AV43ManageFiltersExecutionStep, AV121Pgmname, AV120DocID_Filtro, AV21DocArqInsData_To1, AV22DynamicFiltersEnabled2, AV26DocArqInsData_To2, AV27DynamicFiltersEnabled3, AV31DocArqInsData_To3, AV97TFDocArqConteudoNome, AV98TFDocArqConteudoNome_Sel, AV99TFDocArqConteudoExtensao, AV100TFDocArqConteudoExtensao_Sel, AV58TFDocArqInsDataHora, AV59TFDocArqInsDataHora_To, AV101TFDocArqObservacao, AV102TFDocArqObservacao_Sel, AV14OrderedBy, AV15OrderedDsc, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV111IsAuthorized_Update, AV112IsAuthorized_Delete, Gx_date) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV122Core_documentoarquivowwds_1_docid_filtro = AV120DocID_Filtro;
         AV123Core_documentoarquivowwds_2_filterfulltext = AV17FilterFullText;
         AV124Core_documentoarquivowwds_3_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV125Core_documentoarquivowwds_4_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV126Core_documentoarquivowwds_5_docarqinsdata1 = AV20DocArqInsData1;
         AV127Core_documentoarquivowwds_6_docarqinsdata_to1 = AV21DocArqInsData_To1;
         AV128Core_documentoarquivowwds_7_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV129Core_documentoarquivowwds_8_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV130Core_documentoarquivowwds_9_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV131Core_documentoarquivowwds_10_docarqinsdata2 = AV25DocArqInsData2;
         AV132Core_documentoarquivowwds_11_docarqinsdata_to2 = AV26DocArqInsData_To2;
         AV133Core_documentoarquivowwds_12_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV134Core_documentoarquivowwds_13_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV135Core_documentoarquivowwds_14_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV136Core_documentoarquivowwds_15_docarqinsdata3 = AV30DocArqInsData3;
         AV137Core_documentoarquivowwds_16_docarqinsdata_to3 = AV31DocArqInsData_To3;
         AV138Core_documentoarquivowwds_17_tfdocarqconteudonome = AV97TFDocArqConteudoNome;
         AV139Core_documentoarquivowwds_18_tfdocarqconteudonome_sel = AV98TFDocArqConteudoNome_Sel;
         AV140Core_documentoarquivowwds_19_tfdocarqconteudoextensao = AV99TFDocArqConteudoExtensao;
         AV141Core_documentoarquivowwds_20_tfdocarqconteudoextensao_sel = AV100TFDocArqConteudoExtensao_Sel;
         AV142Core_documentoarquivowwds_21_tfdocarqinsdatahora = AV58TFDocArqInsDataHora;
         AV143Core_documentoarquivowwds_22_tfdocarqinsdatahora_to = AV59TFDocArqInsDataHora_To;
         AV144Core_documentoarquivowwds_23_tfdocarqobservacao = AV101TFDocArqObservacao;
         AV145Core_documentoarquivowwds_24_tfdocarqobservacao_sel = AV102TFDocArqObservacao_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV20DocArqInsData1, AV25DocArqInsData2, AV30DocArqInsData3, AV119DocID, AV43ManageFiltersExecutionStep, AV121Pgmname, AV120DocID_Filtro, AV21DocArqInsData_To1, AV22DynamicFiltersEnabled2, AV26DocArqInsData_To2, AV27DynamicFiltersEnabled3, AV31DocArqInsData_To3, AV97TFDocArqConteudoNome, AV98TFDocArqConteudoNome_Sel, AV99TFDocArqConteudoExtensao, AV100TFDocArqConteudoExtensao_Sel, AV58TFDocArqInsDataHora, AV59TFDocArqInsDataHora_To, AV101TFDocArqObservacao, AV102TFDocArqObservacao_Sel, AV14OrderedBy, AV15OrderedDsc, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV111IsAuthorized_Update, AV112IsAuthorized_Delete, Gx_date) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         Gx_date = DateTimeUtil.Today( context);
         AV121Pgmname = "core.DocumentoArquivoWW";
         fix_multi_value_controls( ) ;
      }

      protected void STRUP5K0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E315K2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV41ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vAGEXPORTDATA"), AV113AGExportData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV103DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_120 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_120"), ",", "."), 18, MidpointRounding.ToEven));
            AV107GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ",", "."), 18, MidpointRounding.ToEven));
            AV108GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ",", "."), 18, MidpointRounding.ToEven));
            AV109GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            AV20DocArqInsData1 = context.localUtil.CToD( cgiGet( "vDOCARQINSDATA1"), 0);
            AV21DocArqInsData_To1 = context.localUtil.CToD( cgiGet( "vDOCARQINSDATA_TO1"), 0);
            AV25DocArqInsData2 = context.localUtil.CToD( cgiGet( "vDOCARQINSDATA2"), 0);
            AV26DocArqInsData_To2 = context.localUtil.CToD( cgiGet( "vDOCARQINSDATA_TO2"), 0);
            AV30DocArqInsData3 = context.localUtil.CToD( cgiGet( "vDOCARQINSDATA3"), 0);
            AV31DocArqInsData_To3 = context.localUtil.CToD( cgiGet( "vDOCARQINSDATA_TO3"), 0);
            AV60DDO_DocArqInsDataHoraAuxDate = context.localUtil.CToD( cgiGet( "vDDO_DOCARQINSDATAHORAAUXDATE"), 0);
            AV61DDO_DocArqInsDataHoraAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_DOCARQINSDATAHORAAUXDATETO"), 0);
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
            Ddo_grid_Sortedstatus = cgiGet( "DDO_GRID_Sortedstatus");
            Ddo_grid_Includefilter = cgiGet( "DDO_GRID_Includefilter");
            Ddo_grid_Filtertype = cgiGet( "DDO_GRID_Filtertype");
            Ddo_grid_Filterisrange = cgiGet( "DDO_GRID_Filterisrange");
            Ddo_grid_Includedatalist = cgiGet( "DDO_GRID_Includedatalist");
            Ddo_grid_Datalisttype = cgiGet( "DDO_GRID_Datalisttype");
            Ddo_grid_Datalistproc = cgiGet( "DDO_GRID_Datalistproc");
            Grid_empowerer_Gridinternalname = cgiGet( "GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hastitlesettings"));
            Grid_empowerer_Fixedcolumns = cgiGet( "GRID_EMPOWERER_Fixedcolumns");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Gridpaginationbar_Selectedpage = cgiGet( "GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), ",", "."), 18, MidpointRounding.ToEven));
            Ddo_grid_Activeeventkey = cgiGet( "DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( "DDO_GRID_Selectedvalue_get");
            Ddo_grid_Selectedcolumn = cgiGet( "DDO_GRID_Selectedcolumn");
            Ddo_grid_Filteredtext_get = cgiGet( "DDO_GRID_Filteredtext_get");
            Ddo_grid_Filteredtextto_get = cgiGet( "DDO_GRID_Filteredtextto_get");
            Ddo_managefilters_Activeeventkey = cgiGet( "DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Ddo_agexport_Activeeventkey = cgiGet( "DDO_AGEXPORT_Activeeventkey");
            /* Read variables values. */
            if ( StringUtil.StrCmp(cgiGet( edtavDocid_filtro_Internalname), "") == 0 )
            {
               AV120DocID_Filtro = Guid.Empty;
               AssignAttri("", false, "AV120DocID_Filtro", AV120DocID_Filtro.ToString());
            }
            else
            {
               try
               {
                  AV120DocID_Filtro = StringUtil.StrToGuid( cgiGet( edtavDocid_filtro_Internalname));
                  AssignAttri("", false, "AV120DocID_Filtro", AV120DocID_Filtro.ToString());
               }
               catch ( Exception  )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "vDOCID_FILTRO");
                  GX_FocusControl = edtavDocid_filtro_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
               }
            }
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
            AV116DocArqInsData_RangeText1 = cgiGet( edtavDocarqinsdata_rangetext1_Internalname);
            AssignAttri("", false, "AV116DocArqInsData_RangeText1", AV116DocArqInsData_RangeText1);
            cmbavDynamicfiltersselector2.Name = cmbavDynamicfiltersselector2_Internalname;
            cmbavDynamicfiltersselector2.CurrentValue = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AV23DynamicFiltersSelector2 = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AssignAttri("", false, "AV23DynamicFiltersSelector2", AV23DynamicFiltersSelector2);
            cmbavDynamicfiltersoperator2.Name = cmbavDynamicfiltersoperator2_Internalname;
            cmbavDynamicfiltersoperator2.CurrentValue = cgiGet( cmbavDynamicfiltersoperator2_Internalname);
            AV24DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator2_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV24DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
            AV117DocArqInsData_RangeText2 = cgiGet( edtavDocarqinsdata_rangetext2_Internalname);
            AssignAttri("", false, "AV117DocArqInsData_RangeText2", AV117DocArqInsData_RangeText2);
            cmbavDynamicfiltersselector3.Name = cmbavDynamicfiltersselector3_Internalname;
            cmbavDynamicfiltersselector3.CurrentValue = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AV28DynamicFiltersSelector3 = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AssignAttri("", false, "AV28DynamicFiltersSelector3", AV28DynamicFiltersSelector3);
            cmbavDynamicfiltersoperator3.Name = cmbavDynamicfiltersoperator3_Internalname;
            cmbavDynamicfiltersoperator3.CurrentValue = cgiGet( cmbavDynamicfiltersoperator3_Internalname);
            AV29DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator3_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV29DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
            AV118DocArqInsData_RangeText3 = cgiGet( edtavDocarqinsdata_rangetext3_Internalname);
            AssignAttri("", false, "AV118DocArqInsData_RangeText3", AV118DocArqInsData_RangeText3);
            AV62DDO_DocArqInsDataHoraAuxDateText = cgiGet( edtavDdo_docarqinsdatahoraauxdatetext_Internalname);
            AssignAttri("", false, "AV62DDO_DocArqInsDataHoraAuxDateText", AV62DDO_DocArqInsDataHoraAuxDateText);
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
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vDOCARQINSDATA1"), 2) ) != DateTimeUtil.ResetTime ( AV20DocArqInsData1 ) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vDOCARQINSDATA2"), 2) ) != DateTimeUtil.ResetTime ( AV25DocArqInsData2 ) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vDOCARQINSDATA3"), 2) ) != DateTimeUtil.ResetTime ( AV30DocArqInsData3 ) )
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
         E315K2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E315K2( )
      {
         /* Start Routine */
         returnInSub = false;
         this.executeUsercontrolMethod("", false, "TFDOCARQINSDATAHORA_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_docarqinsdatahoraauxdatetext_Internalname});
         edtavDocid_Visible = 0;
         AssignProp("", false, edtavDocid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDocid_Visible), 5, 0), true);
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
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
         this.executeUsercontrolMethod("", false, "DOCARQINSDATA_RANGEPICKER1Container", "Attach", "", new Object[] {(string)edtavDocarqinsdata_rangetext1_Internalname});
         AV18DynamicFiltersSelector1 = "DOCARQINSDATA";
         AssignAttri("", false, "AV18DynamicFiltersSelector1", AV18DynamicFiltersSelector1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         this.executeUsercontrolMethod("", false, "DOCARQINSDATA_RANGEPICKER2Container", "Attach", "", new Object[] {(string)edtavDocarqinsdata_rangetext2_Internalname});
         AV23DynamicFiltersSelector2 = "DOCARQINSDATA";
         AssignAttri("", false, "AV23DynamicFiltersSelector2", AV23DynamicFiltersSelector2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         this.executeUsercontrolMethod("", false, "DOCARQINSDATA_RANGEPICKER3Container", "Attach", "", new Object[] {(string)edtavDocarqinsdata_rangetext3_Internalname});
         AV28DynamicFiltersSelector3 = "DOCARQINSDATA";
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
         AV113AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV114AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV114AGExportDataItem.gxTpr_Title = "Excel";
         AV114AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "da69a816-fd11-445b-8aaf-1a2f7f1acc93", "", context.GetTheme( ))));
         AV114AGExportDataItem.gxTpr_Eventkey = "Export";
         AV114AGExportDataItem.gxTpr_Isdivider = false;
         AV113AGExportData.Add(AV114AGExportDataItem, 0);
         Ddc_subscriptions_Titlecontrolidtoreplace = bttBtnsubscriptions_Internalname;
         ucDdc_subscriptions.SendProperty(context, "", false, Ddc_subscriptions_Internalname, "TitleControlIdToReplace", Ddc_subscriptions_Titlecontrolidtoreplace);
         AV104GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV105GAMErrors);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Ddo_grid_Gamoauthtoken = AV104GAMSession.gxTpr_Token;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GAMOAuthToken", Ddo_grid_Gamoauthtoken);
         Form.Caption = " Arquivos do Documento";
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
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV103DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV103DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E325K2( )
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
         AV107GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV107GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV107GridCurrentPage), 10, 0));
         AV108GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV108GridPageCount", StringUtil.LTrimStr( (decimal)(AV108GridPageCount), 10, 0));
         GXt_char2 = AV109GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV121Pgmname, out  GXt_char2) ;
         AV109GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV109GridAppliedFilters", AV109GridAppliedFilters);
         AV122Core_documentoarquivowwds_1_docid_filtro = AV120DocID_Filtro;
         AV123Core_documentoarquivowwds_2_filterfulltext = AV17FilterFullText;
         AV124Core_documentoarquivowwds_3_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV125Core_documentoarquivowwds_4_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV126Core_documentoarquivowwds_5_docarqinsdata1 = AV20DocArqInsData1;
         AV127Core_documentoarquivowwds_6_docarqinsdata_to1 = AV21DocArqInsData_To1;
         AV128Core_documentoarquivowwds_7_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV129Core_documentoarquivowwds_8_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV130Core_documentoarquivowwds_9_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV131Core_documentoarquivowwds_10_docarqinsdata2 = AV25DocArqInsData2;
         AV132Core_documentoarquivowwds_11_docarqinsdata_to2 = AV26DocArqInsData_To2;
         AV133Core_documentoarquivowwds_12_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV134Core_documentoarquivowwds_13_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV135Core_documentoarquivowwds_14_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV136Core_documentoarquivowwds_15_docarqinsdata3 = AV30DocArqInsData3;
         AV137Core_documentoarquivowwds_16_docarqinsdata_to3 = AV31DocArqInsData_To3;
         AV138Core_documentoarquivowwds_17_tfdocarqconteudonome = AV97TFDocArqConteudoNome;
         AV139Core_documentoarquivowwds_18_tfdocarqconteudonome_sel = AV98TFDocArqConteudoNome_Sel;
         AV140Core_documentoarquivowwds_19_tfdocarqconteudoextensao = AV99TFDocArqConteudoExtensao;
         AV141Core_documentoarquivowwds_20_tfdocarqconteudoextensao_sel = AV100TFDocArqConteudoExtensao_Sel;
         AV142Core_documentoarquivowwds_21_tfdocarqinsdatahora = AV58TFDocArqInsDataHora;
         AV143Core_documentoarquivowwds_22_tfdocarqinsdatahora_to = AV59TFDocArqInsDataHora_To;
         AV144Core_documentoarquivowwds_23_tfdocarqobservacao = AV101TFDocArqObservacao;
         AV145Core_documentoarquivowwds_24_tfdocarqobservacao_sel = AV102TFDocArqObservacao_Sel;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E125K2( )
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
            AV106PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV106PageToGo) ;
         }
      }

      protected void E135K2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E195K2( )
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "DocArqConteudoNome") == 0 )
            {
               AV97TFDocArqConteudoNome = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV97TFDocArqConteudoNome", AV97TFDocArqConteudoNome);
               AV98TFDocArqConteudoNome_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV98TFDocArqConteudoNome_Sel", AV98TFDocArqConteudoNome_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "DocArqConteudoExtensao") == 0 )
            {
               AV99TFDocArqConteudoExtensao = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV99TFDocArqConteudoExtensao", AV99TFDocArqConteudoExtensao);
               AV100TFDocArqConteudoExtensao_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV100TFDocArqConteudoExtensao_Sel", AV100TFDocArqConteudoExtensao_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "DocArqInsDataHora") == 0 )
            {
               AV58TFDocArqInsDataHora = context.localUtil.CToT( Ddo_grid_Filteredtext_get, 2);
               AssignAttri("", false, "AV58TFDocArqInsDataHora", context.localUtil.TToC( AV58TFDocArqInsDataHora, 10, 12, 0, 3, "/", ":", " "));
               AV59TFDocArqInsDataHora_To = context.localUtil.CToT( Ddo_grid_Filteredtextto_get, 2);
               AssignAttri("", false, "AV59TFDocArqInsDataHora_To", context.localUtil.TToC( AV59TFDocArqInsDataHora_To, 10, 12, 0, 3, "/", ":", " "));
               if ( ! (DateTime.MinValue==AV59TFDocArqInsDataHora_To) )
               {
                  AV59TFDocArqInsDataHora_To = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( AV59TFDocArqInsDataHora_To)), (short)(DateTimeUtil.Month( AV59TFDocArqInsDataHora_To)), (short)(DateTimeUtil.Day( AV59TFDocArqInsDataHora_To)), 23, 59, 59);
                  AssignAttri("", false, "AV59TFDocArqInsDataHora_To", context.localUtil.TToC( AV59TFDocArqInsDataHora_To, 10, 12, 0, 3, "/", ":", " "));
               }
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "DocArqObservacao") == 0 )
            {
               AV101TFDocArqObservacao = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV101TFDocArqObservacao", AV101TFDocArqObservacao);
               AV102TFDocArqObservacao_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV102TFDocArqObservacao_Sel", AV102TFDocArqObservacao_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E335K2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         cmbavGridactions.removeAllItems();
         cmbavGridactions.addItem("0", ";fa fa-bars", 0);
         if ( AV111IsAuthorized_Update )
         {
            cmbavGridactions.addItem("1", StringUtil.Format( "%1;%2", "Alterar", "fa fa-pen", "", "", "", "", "", "", ""), 0);
         }
         if ( AV112IsAuthorized_Delete )
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
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 120;
         }
         sendrow_1202( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_120_Refreshing )
         {
            DoAjaxLoad(120, GridRow);
         }
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV110GridActions), 4, 0));
      }

      protected void E235K2( )
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

      protected void E205K2( )
      {
         /* 'RemoveDynamicFilters1' Routine */
         returnInSub = false;
         AV32DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV32DynamicFiltersRemoving", AV32DynamicFiltersRemoving);
         AV33DynamicFiltersIgnoreFirst = true;
         AssignAttri("", false, "AV33DynamicFiltersIgnoreFirst", AV33DynamicFiltersIgnoreFirst);
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S202 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'RESETDYNFILTERS' */
         S212 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S222 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV32DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV32DynamicFiltersRemoving", AV32DynamicFiltersRemoving);
         AV33DynamicFiltersIgnoreFirst = false;
         AssignAttri("", false, "AV33DynamicFiltersIgnoreFirst", AV33DynamicFiltersIgnoreFirst);
         gxgrGrid_refresh( subGrid_Rows, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV20DocArqInsData1, AV25DocArqInsData2, AV30DocArqInsData3, AV119DocID, AV43ManageFiltersExecutionStep, AV121Pgmname, AV120DocID_Filtro, AV21DocArqInsData_To1, AV22DynamicFiltersEnabled2, AV26DocArqInsData_To2, AV27DynamicFiltersEnabled3, AV31DocArqInsData_To3, AV97TFDocArqConteudoNome, AV98TFDocArqConteudoNome_Sel, AV99TFDocArqConteudoExtensao, AV100TFDocArqConteudoExtensao_Sel, AV58TFDocArqInsDataHora, AV59TFDocArqInsDataHora_To, AV101TFDocArqObservacao, AV102TFDocArqObservacao_Sel, AV14OrderedBy, AV15OrderedDsc, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV111IsAuthorized_Update, AV112IsAuthorized_Delete, Gx_date) ;
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
      }

      protected void E245K2( )
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

      protected void E165K2( )
      {
         /* Docarqinsdata_rangepicker1_Daterangechanged Routine */
         returnInSub = false;
         AssignAttri("", false, "AV20DocArqInsData1", context.localUtil.Format(AV20DocArqInsData1, "99/99/99"));
         AssignAttri("", false, "AV21DocArqInsData_To1", context.localUtil.Format(AV21DocArqInsData_To1, "99/99/99"));
         gxgrGrid_refresh( subGrid_Rows, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV20DocArqInsData1, AV25DocArqInsData2, AV30DocArqInsData3, AV119DocID, AV43ManageFiltersExecutionStep, AV121Pgmname, AV120DocID_Filtro, AV21DocArqInsData_To1, AV22DynamicFiltersEnabled2, AV26DocArqInsData_To2, AV27DynamicFiltersEnabled3, AV31DocArqInsData_To3, AV97TFDocArqConteudoNome, AV98TFDocArqConteudoNome_Sel, AV99TFDocArqConteudoExtensao, AV100TFDocArqConteudoExtensao_Sel, AV58TFDocArqInsDataHora, AV59TFDocArqInsDataHora_To, AV101TFDocArqObservacao, AV102TFDocArqObservacao_Sel, AV14OrderedBy, AV15OrderedDsc, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV111IsAuthorized_Update, AV112IsAuthorized_Delete, Gx_date) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E255K2( )
      {
         /* Dynamicfiltersoperator1_Click Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "DOCARQINSDATA") == 0 )
         {
            AV20DocArqInsData1 = DateTime.MinValue;
            AssignAttri("", false, "AV20DocArqInsData1", context.localUtil.Format(AV20DocArqInsData1, "99/99/99"));
            AV21DocArqInsData_To1 = DateTime.MinValue;
            AssignAttri("", false, "AV21DocArqInsData_To1", context.localUtil.Format(AV21DocArqInsData_To1, "99/99/99"));
            /* Execute user subroutine: 'UPDATEDOCARQINSDATA1OPERATORVALUES' */
            S232 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            gxgrGrid_refresh( subGrid_Rows, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV20DocArqInsData1, AV25DocArqInsData2, AV30DocArqInsData3, AV119DocID, AV43ManageFiltersExecutionStep, AV121Pgmname, AV120DocID_Filtro, AV21DocArqInsData_To1, AV22DynamicFiltersEnabled2, AV26DocArqInsData_To2, AV27DynamicFiltersEnabled3, AV31DocArqInsData_To3, AV97TFDocArqConteudoNome, AV98TFDocArqConteudoNome_Sel, AV99TFDocArqConteudoExtensao, AV100TFDocArqConteudoExtensao_Sel, AV58TFDocArqInsDataHora, AV59TFDocArqInsDataHora_To, AV101TFDocArqObservacao, AV102TFDocArqObservacao_Sel, AV14OrderedBy, AV15OrderedDsc, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV111IsAuthorized_Update, AV112IsAuthorized_Delete, Gx_date) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E265K2( )
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

      protected void E215K2( )
      {
         /* 'RemoveDynamicFilters2' Routine */
         returnInSub = false;
         AV32DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV32DynamicFiltersRemoving", AV32DynamicFiltersRemoving);
         AV22DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV22DynamicFiltersEnabled2", AV22DynamicFiltersEnabled2);
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S202 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'RESETDYNFILTERS' */
         S212 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S222 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV32DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV32DynamicFiltersRemoving", AV32DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV20DocArqInsData1, AV25DocArqInsData2, AV30DocArqInsData3, AV119DocID, AV43ManageFiltersExecutionStep, AV121Pgmname, AV120DocID_Filtro, AV21DocArqInsData_To1, AV22DynamicFiltersEnabled2, AV26DocArqInsData_To2, AV27DynamicFiltersEnabled3, AV31DocArqInsData_To3, AV97TFDocArqConteudoNome, AV98TFDocArqConteudoNome_Sel, AV99TFDocArqConteudoExtensao, AV100TFDocArqConteudoExtensao_Sel, AV58TFDocArqInsDataHora, AV59TFDocArqInsDataHora_To, AV101TFDocArqObservacao, AV102TFDocArqObservacao_Sel, AV14OrderedBy, AV15OrderedDsc, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV111IsAuthorized_Update, AV112IsAuthorized_Delete, Gx_date) ;
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
      }

      protected void E275K2( )
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

      protected void E175K2( )
      {
         /* Docarqinsdata_rangepicker2_Daterangechanged Routine */
         returnInSub = false;
         AssignAttri("", false, "AV25DocArqInsData2", context.localUtil.Format(AV25DocArqInsData2, "99/99/99"));
         AssignAttri("", false, "AV26DocArqInsData_To2", context.localUtil.Format(AV26DocArqInsData_To2, "99/99/99"));
         gxgrGrid_refresh( subGrid_Rows, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV20DocArqInsData1, AV25DocArqInsData2, AV30DocArqInsData3, AV119DocID, AV43ManageFiltersExecutionStep, AV121Pgmname, AV120DocID_Filtro, AV21DocArqInsData_To1, AV22DynamicFiltersEnabled2, AV26DocArqInsData_To2, AV27DynamicFiltersEnabled3, AV31DocArqInsData_To3, AV97TFDocArqConteudoNome, AV98TFDocArqConteudoNome_Sel, AV99TFDocArqConteudoExtensao, AV100TFDocArqConteudoExtensao_Sel, AV58TFDocArqInsDataHora, AV59TFDocArqInsDataHora_To, AV101TFDocArqObservacao, AV102TFDocArqObservacao_Sel, AV14OrderedBy, AV15OrderedDsc, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV111IsAuthorized_Update, AV112IsAuthorized_Delete, Gx_date) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E285K2( )
      {
         /* Dynamicfiltersoperator2_Click Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "DOCARQINSDATA") == 0 )
         {
            AV25DocArqInsData2 = DateTime.MinValue;
            AssignAttri("", false, "AV25DocArqInsData2", context.localUtil.Format(AV25DocArqInsData2, "99/99/99"));
            AV26DocArqInsData_To2 = DateTime.MinValue;
            AssignAttri("", false, "AV26DocArqInsData_To2", context.localUtil.Format(AV26DocArqInsData_To2, "99/99/99"));
            /* Execute user subroutine: 'UPDATEDOCARQINSDATA2OPERATORVALUES' */
            S242 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            gxgrGrid_refresh( subGrid_Rows, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV20DocArqInsData1, AV25DocArqInsData2, AV30DocArqInsData3, AV119DocID, AV43ManageFiltersExecutionStep, AV121Pgmname, AV120DocID_Filtro, AV21DocArqInsData_To1, AV22DynamicFiltersEnabled2, AV26DocArqInsData_To2, AV27DynamicFiltersEnabled3, AV31DocArqInsData_To3, AV97TFDocArqConteudoNome, AV98TFDocArqConteudoNome_Sel, AV99TFDocArqConteudoExtensao, AV100TFDocArqConteudoExtensao_Sel, AV58TFDocArqInsDataHora, AV59TFDocArqInsDataHora_To, AV101TFDocArqObservacao, AV102TFDocArqObservacao_Sel, AV14OrderedBy, AV15OrderedDsc, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV111IsAuthorized_Update, AV112IsAuthorized_Delete, Gx_date) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E225K2( )
      {
         /* 'RemoveDynamicFilters3' Routine */
         returnInSub = false;
         AV32DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV32DynamicFiltersRemoving", AV32DynamicFiltersRemoving);
         AV27DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV27DynamicFiltersEnabled3", AV27DynamicFiltersEnabled3);
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S202 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'RESETDYNFILTERS' */
         S212 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S222 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV32DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV32DynamicFiltersRemoving", AV32DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV20DocArqInsData1, AV25DocArqInsData2, AV30DocArqInsData3, AV119DocID, AV43ManageFiltersExecutionStep, AV121Pgmname, AV120DocID_Filtro, AV21DocArqInsData_To1, AV22DynamicFiltersEnabled2, AV26DocArqInsData_To2, AV27DynamicFiltersEnabled3, AV31DocArqInsData_To3, AV97TFDocArqConteudoNome, AV98TFDocArqConteudoNome_Sel, AV99TFDocArqConteudoExtensao, AV100TFDocArqConteudoExtensao_Sel, AV58TFDocArqInsDataHora, AV59TFDocArqInsDataHora_To, AV101TFDocArqObservacao, AV102TFDocArqObservacao_Sel, AV14OrderedBy, AV15OrderedDsc, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV111IsAuthorized_Update, AV112IsAuthorized_Delete, Gx_date) ;
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
      }

      protected void E295K2( )
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

      protected void E185K2( )
      {
         /* Docarqinsdata_rangepicker3_Daterangechanged Routine */
         returnInSub = false;
         AssignAttri("", false, "AV30DocArqInsData3", context.localUtil.Format(AV30DocArqInsData3, "99/99/99"));
         AssignAttri("", false, "AV31DocArqInsData_To3", context.localUtil.Format(AV31DocArqInsData_To3, "99/99/99"));
         gxgrGrid_refresh( subGrid_Rows, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV20DocArqInsData1, AV25DocArqInsData2, AV30DocArqInsData3, AV119DocID, AV43ManageFiltersExecutionStep, AV121Pgmname, AV120DocID_Filtro, AV21DocArqInsData_To1, AV22DynamicFiltersEnabled2, AV26DocArqInsData_To2, AV27DynamicFiltersEnabled3, AV31DocArqInsData_To3, AV97TFDocArqConteudoNome, AV98TFDocArqConteudoNome_Sel, AV99TFDocArqConteudoExtensao, AV100TFDocArqConteudoExtensao_Sel, AV58TFDocArqInsDataHora, AV59TFDocArqInsDataHora_To, AV101TFDocArqObservacao, AV102TFDocArqObservacao_Sel, AV14OrderedBy, AV15OrderedDsc, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV111IsAuthorized_Update, AV112IsAuthorized_Delete, Gx_date) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E305K2( )
      {
         /* Dynamicfiltersoperator3_Click Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "DOCARQINSDATA") == 0 )
         {
            AV30DocArqInsData3 = DateTime.MinValue;
            AssignAttri("", false, "AV30DocArqInsData3", context.localUtil.Format(AV30DocArqInsData3, "99/99/99"));
            AV31DocArqInsData_To3 = DateTime.MinValue;
            AssignAttri("", false, "AV31DocArqInsData_To3", context.localUtil.Format(AV31DocArqInsData_To3, "99/99/99"));
            /* Execute user subroutine: 'UPDATEDOCARQINSDATA3OPERATORVALUES' */
            S252 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            gxgrGrid_refresh( subGrid_Rows, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV23DynamicFiltersSelector2, AV24DynamicFiltersOperator2, AV28DynamicFiltersSelector3, AV29DynamicFiltersOperator3, AV20DocArqInsData1, AV25DocArqInsData2, AV30DocArqInsData3, AV119DocID, AV43ManageFiltersExecutionStep, AV121Pgmname, AV120DocID_Filtro, AV21DocArqInsData_To1, AV22DynamicFiltersEnabled2, AV26DocArqInsData_To2, AV27DynamicFiltersEnabled3, AV31DocArqInsData_To3, AV97TFDocArqConteudoNome, AV98TFDocArqConteudoNome_Sel, AV99TFDocArqConteudoExtensao, AV100TFDocArqConteudoExtensao_Sel, AV58TFDocArqInsDataHora, AV59TFDocArqInsDataHora_To, AV101TFDocArqObservacao, AV102TFDocArqObservacao_Sel, AV14OrderedBy, AV15OrderedDsc, AV11GridState, AV33DynamicFiltersIgnoreFirst, AV32DynamicFiltersRemoving, AV111IsAuthorized_Update, AV112IsAuthorized_Delete, Gx_date) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E115K2( )
      {
         /* Ddo_managefilters_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Clean#>") == 0 )
         {
            /* Execute user subroutine: 'CLEANFILTERS' */
            S262 ();
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
            GXEncryptionTmp = "wwpbaseobjects.savefilteras.aspx"+UrlEncode(StringUtil.RTrim("core.DocumentoArquivoWWFilters")) + "," + UrlEncode(StringUtil.RTrim(AV121Pgmname+"GridState"));
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
            GXEncryptionTmp = "wwpbaseobjects.managefilters.aspx"+UrlEncode(StringUtil.RTrim("core.DocumentoArquivoWWFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV43ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV43ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV43ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char2 = AV42ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "core.DocumentoArquivoWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char2) ;
            AV42ManageFiltersXml = GXt_char2;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV42ManageFiltersXml)) )
            {
               GX_msglist.addItem("O filtro selecionado não existe mais.");
            }
            else
            {
               /* Execute user subroutine: 'CLEANFILTERS' */
               S262 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV121Pgmname+"GridState",  AV42ManageFiltersXml) ;
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
               S272 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
               S222 ();
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
      }

      protected void E345K2( )
      {
         /* Gridactions_Click Routine */
         returnInSub = false;
         if ( AV110GridActions == 1 )
         {
            /* Execute user subroutine: 'DO UPDATE' */
            S282 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV110GridActions == 2 )
         {
            /* Execute user subroutine: 'DO DELETE' */
            S292 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         AV110GridActions = 0;
         AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV110GridActions), 4, 0));
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV110GridActions), 4, 0));
         AssignProp("", false, cmbavGridactions_Internalname, "Values", cmbavGridactions.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E145K2( )
      {
         /* Ddo_agexport_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_agexport_Activeeventkey, "Export") == 0 )
         {
            /* Execute user subroutine: 'DOEXPORT' */
            S302 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
      }

      protected void E155K2( )
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
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"W0144",(string)"",(string)"DocumentoArquivo",(short)1,(string)"",(string)""});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0144"+"");
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

      protected void S182( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         GXt_boolean3 = AV111IsAuthorized_Update;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "documento_Update", out  GXt_boolean3) ;
         AV111IsAuthorized_Update = GXt_boolean3;
         AssignAttri("", false, "AV111IsAuthorized_Update", AV111IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV111IsAuthorized_Update, context));
         GXt_boolean3 = AV112IsAuthorized_Delete;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "documento_Delete", out  GXt_boolean3) ;
         AV112IsAuthorized_Delete = GXt_boolean3;
         AssignAttri("", false, "AV112IsAuthorized_Delete", AV112IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV112IsAuthorized_Delete, context));
         if ( ! ( new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_hassubscriptionstodisplay(context).executeUdp(  "DocumentoArquivo",  1) ) )
         {
            bttBtnsubscriptions_Visible = 0;
            AssignProp("", false, bttBtnsubscriptions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnsubscriptions_Visible), 5, 0), true);
         }
      }

      protected void S122( )
      {
         /* 'ENABLEDYNAMICFILTERS1' Routine */
         returnInSub = false;
         tblTablemergeddynamicfiltersdocarqinsdata1_Visible = 0;
         AssignProp("", false, tblTablemergeddynamicfiltersdocarqinsdata1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblTablemergeddynamicfiltersdocarqinsdata1_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator1.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "DOCARQINSDATA") == 0 )
         {
            tblTablemergeddynamicfiltersdocarqinsdata1_Visible = 1;
            AssignProp("", false, tblTablemergeddynamicfiltersdocarqinsdata1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblTablemergeddynamicfiltersdocarqinsdata1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
            /* Execute user subroutine: 'UPDATEDOCARQINSDATA1OPERATORVALUES' */
            S232 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
      }

      protected void S232( )
      {
         /* 'UPDATEDOCARQINSDATA1OPERATORVALUES' Routine */
         returnInSub = false;
         cellDocarqinsdata_range_cell1_Class = "Invisible";
         AssignProp("", false, cellDocarqinsdata_range_cell1_Internalname, "Class", cellDocarqinsdata_range_cell1_Class, true);
         if ( AV19DynamicFiltersOperator1 == 0 )
         {
            AV20DocArqInsData1 = Gx_date;
            AssignAttri("", false, "AV20DocArqInsData1", context.localUtil.Format(AV20DocArqInsData1, "99/99/99"));
         }
         else if ( AV19DynamicFiltersOperator1 == 1 )
         {
            AV20DocArqInsData1 = Gx_date;
            AssignAttri("", false, "AV20DocArqInsData1", context.localUtil.Format(AV20DocArqInsData1, "99/99/99"));
         }
         else if ( AV19DynamicFiltersOperator1 == 2 )
         {
            AV20DocArqInsData1 = Gx_date;
            AssignAttri("", false, "AV20DocArqInsData1", context.localUtil.Format(AV20DocArqInsData1, "99/99/99"));
         }
         else if ( AV19DynamicFiltersOperator1 == 3 )
         {
            cellDocarqinsdata_range_cell1_Class = "";
            AssignProp("", false, cellDocarqinsdata_range_cell1_Internalname, "Class", cellDocarqinsdata_range_cell1_Class, true);
         }
      }

      protected void S132( )
      {
         /* 'ENABLEDYNAMICFILTERS2' Routine */
         returnInSub = false;
         tblTablemergeddynamicfiltersdocarqinsdata2_Visible = 0;
         AssignProp("", false, tblTablemergeddynamicfiltersdocarqinsdata2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblTablemergeddynamicfiltersdocarqinsdata2_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator2.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "DOCARQINSDATA") == 0 )
         {
            tblTablemergeddynamicfiltersdocarqinsdata2_Visible = 1;
            AssignProp("", false, tblTablemergeddynamicfiltersdocarqinsdata2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblTablemergeddynamicfiltersdocarqinsdata2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
            /* Execute user subroutine: 'UPDATEDOCARQINSDATA2OPERATORVALUES' */
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
         /* 'UPDATEDOCARQINSDATA2OPERATORVALUES' Routine */
         returnInSub = false;
         cellDocarqinsdata_range_cell2_Class = "Invisible";
         AssignProp("", false, cellDocarqinsdata_range_cell2_Internalname, "Class", cellDocarqinsdata_range_cell2_Class, true);
         if ( AV24DynamicFiltersOperator2 == 0 )
         {
            AV25DocArqInsData2 = Gx_date;
            AssignAttri("", false, "AV25DocArqInsData2", context.localUtil.Format(AV25DocArqInsData2, "99/99/99"));
         }
         else if ( AV24DynamicFiltersOperator2 == 1 )
         {
            AV25DocArqInsData2 = Gx_date;
            AssignAttri("", false, "AV25DocArqInsData2", context.localUtil.Format(AV25DocArqInsData2, "99/99/99"));
         }
         else if ( AV24DynamicFiltersOperator2 == 2 )
         {
            AV25DocArqInsData2 = Gx_date;
            AssignAttri("", false, "AV25DocArqInsData2", context.localUtil.Format(AV25DocArqInsData2, "99/99/99"));
         }
         else if ( AV24DynamicFiltersOperator2 == 3 )
         {
            cellDocarqinsdata_range_cell2_Class = "";
            AssignProp("", false, cellDocarqinsdata_range_cell2_Internalname, "Class", cellDocarqinsdata_range_cell2_Class, true);
         }
      }

      protected void S142( )
      {
         /* 'ENABLEDYNAMICFILTERS3' Routine */
         returnInSub = false;
         tblTablemergeddynamicfiltersdocarqinsdata3_Visible = 0;
         AssignProp("", false, tblTablemergeddynamicfiltersdocarqinsdata3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblTablemergeddynamicfiltersdocarqinsdata3_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator3.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "DOCARQINSDATA") == 0 )
         {
            tblTablemergeddynamicfiltersdocarqinsdata3_Visible = 1;
            AssignProp("", false, tblTablemergeddynamicfiltersdocarqinsdata3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblTablemergeddynamicfiltersdocarqinsdata3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
            /* Execute user subroutine: 'UPDATEDOCARQINSDATA3OPERATORVALUES' */
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
         /* 'UPDATEDOCARQINSDATA3OPERATORVALUES' Routine */
         returnInSub = false;
         cellDocarqinsdata_range_cell3_Class = "Invisible";
         AssignProp("", false, cellDocarqinsdata_range_cell3_Internalname, "Class", cellDocarqinsdata_range_cell3_Class, true);
         if ( AV29DynamicFiltersOperator3 == 0 )
         {
            AV30DocArqInsData3 = Gx_date;
            AssignAttri("", false, "AV30DocArqInsData3", context.localUtil.Format(AV30DocArqInsData3, "99/99/99"));
         }
         else if ( AV29DynamicFiltersOperator3 == 1 )
         {
            AV30DocArqInsData3 = Gx_date;
            AssignAttri("", false, "AV30DocArqInsData3", context.localUtil.Format(AV30DocArqInsData3, "99/99/99"));
         }
         else if ( AV29DynamicFiltersOperator3 == 2 )
         {
            AV30DocArqInsData3 = Gx_date;
            AssignAttri("", false, "AV30DocArqInsData3", context.localUtil.Format(AV30DocArqInsData3, "99/99/99"));
         }
         else if ( AV29DynamicFiltersOperator3 == 3 )
         {
            cellDocarqinsdata_range_cell3_Class = "";
            AssignProp("", false, cellDocarqinsdata_range_cell3_Internalname, "Class", cellDocarqinsdata_range_cell3_Class, true);
         }
      }

      protected void S212( )
      {
         /* 'RESETDYNFILTERS' Routine */
         returnInSub = false;
         AV22DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV22DynamicFiltersEnabled2", AV22DynamicFiltersEnabled2);
         AV23DynamicFiltersSelector2 = "DOCARQINSDATA";
         AssignAttri("", false, "AV23DynamicFiltersSelector2", AV23DynamicFiltersSelector2);
         AV24DynamicFiltersOperator2 = 0;
         AssignAttri("", false, "AV24DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         AV25DocArqInsData2 = DateTime.MinValue;
         AssignAttri("", false, "AV25DocArqInsData2", context.localUtil.Format(AV25DocArqInsData2, "99/99/99"));
         AV26DocArqInsData_To2 = DateTime.MinValue;
         AssignAttri("", false, "AV26DocArqInsData_To2", context.localUtil.Format(AV26DocArqInsData_To2, "99/99/99"));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV27DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV27DynamicFiltersEnabled3", AV27DynamicFiltersEnabled3);
         AV28DynamicFiltersSelector3 = "DOCARQINSDATA";
         AssignAttri("", false, "AV28DynamicFiltersSelector3", AV28DynamicFiltersSelector3);
         AV29DynamicFiltersOperator3 = 0;
         AssignAttri("", false, "AV29DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         AV30DocArqInsData3 = DateTime.MinValue;
         AssignAttri("", false, "AV30DocArqInsData3", context.localUtil.Format(AV30DocArqInsData3, "99/99/99"));
         AV31DocArqInsData_To3 = DateTime.MinValue;
         AssignAttri("", false, "AV31DocArqInsData_To3", context.localUtil.Format(AV31DocArqInsData_To3, "99/99/99"));
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
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "core.DocumentoArquivoWWFilters",  "WWPDynFilterHideAll_AL('%1', 3, 0)",  divTabledynamicfilters_Internalname,  true, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4) ;
         AV41ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4;
      }

      protected void S262( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV120DocID_Filtro = Guid.Empty;
         AssignAttri("", false, "AV120DocID_Filtro", AV120DocID_Filtro.ToString());
         AV17FilterFullText = "";
         AssignAttri("", false, "AV17FilterFullText", AV17FilterFullText);
         AV97TFDocArqConteudoNome = "";
         AssignAttri("", false, "AV97TFDocArqConteudoNome", AV97TFDocArqConteudoNome);
         AV98TFDocArqConteudoNome_Sel = "";
         AssignAttri("", false, "AV98TFDocArqConteudoNome_Sel", AV98TFDocArqConteudoNome_Sel);
         AV99TFDocArqConteudoExtensao = "";
         AssignAttri("", false, "AV99TFDocArqConteudoExtensao", AV99TFDocArqConteudoExtensao);
         AV100TFDocArqConteudoExtensao_Sel = "";
         AssignAttri("", false, "AV100TFDocArqConteudoExtensao_Sel", AV100TFDocArqConteudoExtensao_Sel);
         AV58TFDocArqInsDataHora = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "AV58TFDocArqInsDataHora", context.localUtil.TToC( AV58TFDocArqInsDataHora, 10, 12, 0, 3, "/", ":", " "));
         AV59TFDocArqInsDataHora_To = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "AV59TFDocArqInsDataHora_To", context.localUtil.TToC( AV59TFDocArqInsDataHora_To, 10, 12, 0, 3, "/", ":", " "));
         AV101TFDocArqObservacao = "";
         AssignAttri("", false, "AV101TFDocArqObservacao", AV101TFDocArqObservacao);
         AV102TFDocArqObservacao_Sel = "";
         AssignAttri("", false, "AV102TFDocArqObservacao_Sel", AV102TFDocArqObservacao_Sel);
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
         AV18DynamicFiltersSelector1 = "DOCARQINSDATA";
         AssignAttri("", false, "AV18DynamicFiltersSelector1", AV18DynamicFiltersSelector1);
         AV19DynamicFiltersOperator1 = 0;
         AssignAttri("", false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AV20DocArqInsData1 = DateTime.MinValue;
         AssignAttri("", false, "AV20DocArqInsData1", context.localUtil.Format(AV20DocArqInsData1, "99/99/99"));
         AV21DocArqInsData_To1 = DateTime.MinValue;
         AssignAttri("", false, "AV21DocArqInsData_To1", context.localUtil.Format(AV21DocArqInsData_To1, "99/99/99"));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'RESETDYNFILTERS' */
         S212 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV11GridState.gxTpr_Dynamicfilters.Clear();
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S222 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S282( )
      {
         /* 'DO UPDATE' Routine */
         returnInSub = false;
         if ( AV111IsAuthorized_Update )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "core.documentoarquivo.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(A289DocID.ToString()) + "," + UrlEncode(StringUtil.LTrimStr(A307DocArqSeq,4,0));
            CallWebObject(formatLink("core.documentoarquivo.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
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
         /* 'DO DELETE' Routine */
         returnInSub = false;
         if ( AV112IsAuthorized_Delete )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "core.documentoarquivo.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(A289DocID.ToString()) + "," + UrlEncode(StringUtil.LTrimStr(A307DocArqSeq,4,0));
            CallWebObject(formatLink("core.documentoarquivo.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem("A ação não encontra-se disponível");
            context.DoAjaxRefresh();
         }
      }

      protected void S162( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV40Session.Get(AV121Pgmname+"GridState"), "") == 0 )
         {
            AV11GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV121Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV11GridState.FromXml(AV40Session.Get(AV121Pgmname+"GridState"), null, "", "");
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
         S272 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S222 ();
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

      protected void S272( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV147GXV1 = 1;
         while ( AV147GXV1 <= AV11GridState.gxTpr_Filtervalues.Count )
         {
            AV12GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV11GridState.gxTpr_Filtervalues.Item(AV147GXV1));
            if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "DOCID_FILTRO") == 0 )
            {
               AV120DocID_Filtro = StringUtil.StrToGuid( AV12GridStateFilterValue.gxTpr_Value);
               AssignAttri("", false, "AV120DocID_Filtro", AV120DocID_Filtro.ToString());
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV17FilterFullText = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV17FilterFullText", AV17FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFDOCARQCONTEUDONOME") == 0 )
            {
               AV97TFDocArqConteudoNome = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV97TFDocArqConteudoNome", AV97TFDocArqConteudoNome);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFDOCARQCONTEUDONOME_SEL") == 0 )
            {
               AV98TFDocArqConteudoNome_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV98TFDocArqConteudoNome_Sel", AV98TFDocArqConteudoNome_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFDOCARQCONTEUDOEXTENSAO") == 0 )
            {
               AV99TFDocArqConteudoExtensao = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV99TFDocArqConteudoExtensao", AV99TFDocArqConteudoExtensao);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFDOCARQCONTEUDOEXTENSAO_SEL") == 0 )
            {
               AV100TFDocArqConteudoExtensao_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV100TFDocArqConteudoExtensao_Sel", AV100TFDocArqConteudoExtensao_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFDOCARQINSDATAHORA") == 0 )
            {
               AV58TFDocArqInsDataHora = context.localUtil.CToT( AV12GridStateFilterValue.gxTpr_Value, 2);
               AssignAttri("", false, "AV58TFDocArqInsDataHora", context.localUtil.TToC( AV58TFDocArqInsDataHora, 10, 12, 0, 3, "/", ":", " "));
               AV59TFDocArqInsDataHora_To = context.localUtil.CToT( AV12GridStateFilterValue.gxTpr_Valueto, 2);
               AssignAttri("", false, "AV59TFDocArqInsDataHora_To", context.localUtil.TToC( AV59TFDocArqInsDataHora_To, 10, 12, 0, 3, "/", ":", " "));
               AV60DDO_DocArqInsDataHoraAuxDate = DateTimeUtil.ResetTime(AV58TFDocArqInsDataHora);
               AssignAttri("", false, "AV60DDO_DocArqInsDataHoraAuxDate", context.localUtil.Format(AV60DDO_DocArqInsDataHoraAuxDate, "99/99/9999"));
               AV61DDO_DocArqInsDataHoraAuxDateTo = DateTimeUtil.ResetTime(AV59TFDocArqInsDataHora_To);
               AssignAttri("", false, "AV61DDO_DocArqInsDataHoraAuxDateTo", context.localUtil.Format(AV61DDO_DocArqInsDataHoraAuxDateTo, "99/99/9999"));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFDOCARQOBSERVACAO") == 0 )
            {
               AV101TFDocArqObservacao = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV101TFDocArqObservacao", AV101TFDocArqObservacao);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFDOCARQOBSERVACAO_SEL") == 0 )
            {
               AV102TFDocArqObservacao_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV102TFDocArqObservacao_Sel", AV102TFDocArqObservacao_Sel);
            }
            AV147GXV1 = (int)(AV147GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV98TFDocArqConteudoNome_Sel)),  AV98TFDocArqConteudoNome_Sel, out  GXt_char2) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV100TFDocArqConteudoExtensao_Sel)),  AV100TFDocArqConteudoExtensao_Sel, out  GXt_char5) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV102TFDocArqObservacao_Sel)),  AV102TFDocArqObservacao_Sel, out  GXt_char6) ;
         Ddo_grid_Selectedvalue_set = GXt_char2+"|"+GXt_char5+"||"+GXt_char6;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV97TFDocArqConteudoNome)),  AV97TFDocArqConteudoNome, out  GXt_char6) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV99TFDocArqConteudoExtensao)),  AV99TFDocArqConteudoExtensao, out  GXt_char5) ;
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV101TFDocArqObservacao)),  AV101TFDocArqObservacao, out  GXt_char2) ;
         Ddo_grid_Filteredtext_set = GXt_char6+"|"+GXt_char5+"|"+((DateTime.MinValue==AV58TFDocArqInsDataHora) ? "" : context.localUtil.DToC( AV60DDO_DocArqInsDataHoraAuxDate, 2, "/"))+"|"+GXt_char2;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "||"+((DateTime.MinValue==AV59TFDocArqInsDataHora_To) ? "" : context.localUtil.DToC( AV61DDO_DocArqInsDataHoraAuxDateTo, 2, "/"))+"|";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S222( )
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
            if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "DOCARQINSDATA") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV13GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
               AV20DocArqInsData1 = context.localUtil.CToD( AV13GridStateDynamicFilter.gxTpr_Value, 2);
               AssignAttri("", false, "AV20DocArqInsData1", context.localUtil.Format(AV20DocArqInsData1, "99/99/99"));
               AV21DocArqInsData_To1 = context.localUtil.CToD( AV13GridStateDynamicFilter.gxTpr_Valueto, 2);
               AssignAttri("", false, "AV21DocArqInsData_To1", context.localUtil.Format(AV21DocArqInsData_To1, "99/99/99"));
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
               if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "DOCARQINSDATA") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV13GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV24DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
                  AV25DocArqInsData2 = context.localUtil.CToD( AV13GridStateDynamicFilter.gxTpr_Value, 2);
                  AssignAttri("", false, "AV25DocArqInsData2", context.localUtil.Format(AV25DocArqInsData2, "99/99/99"));
                  AV26DocArqInsData_To2 = context.localUtil.CToD( AV13GridStateDynamicFilter.gxTpr_Valueto, 2);
                  AssignAttri("", false, "AV26DocArqInsData_To2", context.localUtil.Format(AV26DocArqInsData_To2, "99/99/99"));
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
                  if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "DOCARQINSDATA") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV13GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV29DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
                     AV30DocArqInsData3 = context.localUtil.CToD( AV13GridStateDynamicFilter.gxTpr_Value, 2);
                     AssignAttri("", false, "AV30DocArqInsData3", context.localUtil.Format(AV30DocArqInsData3, "99/99/99"));
                     AV31DocArqInsData_To3 = context.localUtil.CToD( AV13GridStateDynamicFilter.gxTpr_Valueto, 2);
                     AssignAttri("", false, "AV31DocArqInsData_To3", context.localUtil.Format(AV31DocArqInsData_To3, "99/99/99"));
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
         AV11GridState.FromXml(AV40Session.Get(AV121Pgmname+"GridState"), null, "", "");
         AV11GridState.gxTpr_Orderedby = AV14OrderedBy;
         AV11GridState.gxTpr_Ordereddsc = AV15OrderedDsc;
         AV11GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "DOCID_FILTRO",  "ID",  !(Guid.Empty==AV120DocID_Filtro),  0,  StringUtil.Trim( AV120DocID_Filtro.ToString()),  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "FILTERFULLTEXT",  "Filtro principal",  !String.IsNullOrEmpty(StringUtil.RTrim( AV17FilterFullText)),  0,  AV17FilterFullText,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFDOCARQCONTEUDONOME",  "Nome do Arquivo",  !String.IsNullOrEmpty(StringUtil.RTrim( AV97TFDocArqConteudoNome)),  0,  AV97TFDocArqConteudoNome,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV98TFDocArqConteudoNome_Sel)),  AV98TFDocArqConteudoNome_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFDOCARQCONTEUDOEXTENSAO",  "Extensão",  !String.IsNullOrEmpty(StringUtil.RTrim( AV99TFDocArqConteudoExtensao)),  0,  AV99TFDocArqConteudoExtensao,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV100TFDocArqConteudoExtensao_Sel)),  AV100TFDocArqConteudoExtensao_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFDOCARQINSDATAHORA",  "Incluído em",  !((DateTime.MinValue==AV58TFDocArqInsDataHora)&&(DateTime.MinValue==AV59TFDocArqInsDataHora_To)),  0,  StringUtil.Trim( context.localUtil.TToC( AV58TFDocArqInsDataHora, 10, 12, 0, 3, "/", ":", " ")),  StringUtil.Trim( context.localUtil.TToC( AV59TFDocArqInsDataHora_To, 10, 12, 0, 3, "/", ":", " "))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFDOCARQOBSERVACAO",  "Observações",  !String.IsNullOrEmpty(StringUtil.RTrim( AV101TFDocArqObservacao)),  0,  AV101TFDocArqObservacao,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV102TFDocArqObservacao_Sel)),  AV102TFDocArqObservacao_Sel,  "") ;
         if ( ! (Guid.Empty==AV119DocID) )
         {
            AV12GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
            AV12GridStateFilterValue.gxTpr_Name = "PARM_&DOCID";
            AV12GridStateFilterValue.gxTpr_Value = AV119DocID.ToString();
            AV11GridState.gxTpr_Filtervalues.Add(AV12GridStateFilterValue, 0);
         }
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S202 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV11GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV11GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV121Pgmname+"GridState",  AV11GridState.ToXml(false, true, "", "")) ;
      }

      protected void S202( )
      {
         /* 'SAVEDYNFILTERSSTATE' Routine */
         returnInSub = false;
         AV11GridState.gxTpr_Dynamicfilters.Clear();
         if ( ! AV33DynamicFiltersIgnoreFirst )
         {
            AV13GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV13GridStateDynamicFilter.gxTpr_Selected = AV18DynamicFiltersSelector1;
            if ( ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "DOCARQINSDATA") == 0 ) && ! ( (DateTime.MinValue==AV20DocArqInsData1) && (DateTime.MinValue==AV21DocArqInsData_To1) ) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = "Incluído em";
               AV13GridStateDynamicFilter.gxTpr_Value = context.localUtil.DToC( AV20DocArqInsData1, 2, "/");
               AV13GridStateDynamicFilter.gxTpr_Operator = AV19DynamicFiltersOperator1;
               AV13GridStateDynamicFilter.gxTpr_Valueto = context.localUtil.DToC( AV21DocArqInsData_To1, 2, "/");
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
            if ( ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "DOCARQINSDATA") == 0 ) && ! ( (DateTime.MinValue==AV25DocArqInsData2) && (DateTime.MinValue==AV26DocArqInsData_To2) ) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = "Incluído em";
               AV13GridStateDynamicFilter.gxTpr_Value = context.localUtil.DToC( AV25DocArqInsData2, 2, "/");
               AV13GridStateDynamicFilter.gxTpr_Operator = AV24DynamicFiltersOperator2;
               AV13GridStateDynamicFilter.gxTpr_Valueto = context.localUtil.DToC( AV26DocArqInsData_To2, 2, "/");
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
            if ( ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "DOCARQINSDATA") == 0 ) && ! ( (DateTime.MinValue==AV30DocArqInsData3) && (DateTime.MinValue==AV31DocArqInsData_To3) ) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = "Incluído em";
               AV13GridStateDynamicFilter.gxTpr_Value = context.localUtil.DToC( AV30DocArqInsData3, 2, "/");
               AV13GridStateDynamicFilter.gxTpr_Operator = AV29DynamicFiltersOperator3;
               AV13GridStateDynamicFilter.gxTpr_Valueto = context.localUtil.DToC( AV31DocArqInsData_To3, 2, "/");
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
         AV9TrnContext.gxTpr_Callerobject = AV121Pgmname;
         AV9TrnContext.gxTpr_Callerondelete = true;
         AV9TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString;
         AV9TrnContext.gxTpr_Transactionname = "core.DocumentoArquivo";
         AV40Session.Set("TrnContext", AV9TrnContext.ToXml(false, true, "", ""));
      }

      protected void S302( )
      {
         /* 'DOEXPORT' Routine */
         returnInSub = false;
         new GeneXus.Programs.core.documentoarquivowwexport(context ).execute( out  AV34ExcelFilename, out  AV35ErrorMessage) ;
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

      protected void wb_table4_99_5K2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 103,'',false,'" + sGXsfl_120_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator3, cmbavDynamicfiltersoperator3_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0)), 1, cmbavDynamicfiltersoperator3_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSOPERATOR3.CLICK."+"'", "int", "", cmbavDynamicfiltersoperator3.Visible, cmbavDynamicfiltersoperator3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,103);\"", "", true, 0, "HLP_core\\DocumentoArquivoWW.htm");
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", (string)(cmbavDynamicfiltersoperator3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_docarqinsdata3_cell_Internalname+"\"  class=''>") ;
            wb_table5_105_5K2( true) ;
         }
         else
         {
            wb_table5_105_5K2( false) ;
         }
         return  ;
      }

      protected void wb_table5_105_5K2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter3_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 111,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters3_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters3_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters3_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS3\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_core\\DocumentoArquivoWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_99_5K2e( true) ;
         }
         else
         {
            wb_table4_99_5K2e( false) ;
         }
      }

      protected void wb_table5_105_5K2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            if ( tblTablemergeddynamicfiltersdocarqinsdata3_Visible == 0 )
            {
               sStyleString += "display:none;";
            }
            GxWebStd.gx_table_start( context, tblTablemergeddynamicfiltersdocarqinsdata3_Internalname, tblTablemergeddynamicfiltersdocarqinsdata3_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td id=\""+cellDocarqinsdata_range_cell3_Internalname+"\"  class='"+cellDocarqinsdata_range_cell3_Class+"'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavDocarqinsdata_rangetext3_Internalname, "Doc Arq Ins Data_Range Text3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 109,'',false,'" + sGXsfl_120_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDocarqinsdata_rangetext3_Internalname, AV118DocArqInsData_RangeText3, StringUtil.RTrim( context.localUtil.Format( AV118DocArqInsData_RangeText3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,109);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDocarqinsdata_rangetext3_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavDocarqinsdata_rangetext3_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\DocumentoArquivoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table5_105_5K2e( true) ;
         }
         else
         {
            wb_table5_105_5K2e( false) ;
         }
      }

      protected void wb_table3_74_5K2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'" + sGXsfl_120_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator2, cmbavDynamicfiltersoperator2_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0)), 1, cmbavDynamicfiltersoperator2_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSOPERATOR2.CLICK."+"'", "int", "", cmbavDynamicfiltersoperator2.Visible, cmbavDynamicfiltersoperator2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,78);\"", "", true, 0, "HLP_core\\DocumentoArquivoWW.htm");
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", (string)(cmbavDynamicfiltersoperator2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_docarqinsdata2_cell_Internalname+"\"  class=''>") ;
            wb_table6_80_5K2( true) ;
         }
         else
         {
            wb_table6_80_5K2( false) ;
         }
         return  ;
      }

      protected void wb_table6_80_5K2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters2_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters2_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_core\\DocumentoArquivoWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters2_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters2_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_core\\DocumentoArquivoWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_74_5K2e( true) ;
         }
         else
         {
            wb_table3_74_5K2e( false) ;
         }
      }

      protected void wb_table6_80_5K2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            if ( tblTablemergeddynamicfiltersdocarqinsdata2_Visible == 0 )
            {
               sStyleString += "display:none;";
            }
            GxWebStd.gx_table_start( context, tblTablemergeddynamicfiltersdocarqinsdata2_Internalname, tblTablemergeddynamicfiltersdocarqinsdata2_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td id=\""+cellDocarqinsdata_range_cell2_Internalname+"\"  class='"+cellDocarqinsdata_range_cell2_Class+"'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavDocarqinsdata_rangetext2_Internalname, "Doc Arq Ins Data_Range Text2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'" + sGXsfl_120_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDocarqinsdata_rangetext2_Internalname, AV117DocArqInsData_RangeText2, StringUtil.RTrim( context.localUtil.Format( AV117DocArqInsData_RangeText2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,84);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDocarqinsdata_rangetext2_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavDocarqinsdata_rangetext2_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\DocumentoArquivoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table6_80_5K2e( true) ;
         }
         else
         {
            wb_table6_80_5K2e( false) ;
         }
      }

      protected void wb_table2_49_5K2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'" + sGXsfl_120_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator1, cmbavDynamicfiltersoperator1_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0)), 1, cmbavDynamicfiltersoperator1_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSOPERATOR1.CLICK."+"'", "int", "", cmbavDynamicfiltersoperator1.Visible, cmbavDynamicfiltersoperator1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"", "", true, 0, "HLP_core\\DocumentoArquivoWW.htm");
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", (string)(cmbavDynamicfiltersoperator1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_docarqinsdata1_cell_Internalname+"\"  class=''>") ;
            wb_table7_55_5K2( true) ;
         }
         else
         {
            wb_table7_55_5K2( false) ;
         }
         return  ;
      }

      protected void wb_table7_55_5K2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters1_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters1_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_core\\DocumentoArquivoWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters1_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters1_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_core\\DocumentoArquivoWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_49_5K2e( true) ;
         }
         else
         {
            wb_table2_49_5K2e( false) ;
         }
      }

      protected void wb_table7_55_5K2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            if ( tblTablemergeddynamicfiltersdocarqinsdata1_Visible == 0 )
            {
               sStyleString += "display:none;";
            }
            GxWebStd.gx_table_start( context, tblTablemergeddynamicfiltersdocarqinsdata1_Internalname, tblTablemergeddynamicfiltersdocarqinsdata1_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td id=\""+cellDocarqinsdata_range_cell1_Internalname+"\"  class='"+cellDocarqinsdata_range_cell1_Class+"'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavDocarqinsdata_rangetext1_Internalname, "Doc Arq Ins Data_Range Text1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'" + sGXsfl_120_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDocarqinsdata_rangetext1_Internalname, AV116DocArqInsData_RangeText1, StringUtil.RTrim( context.localUtil.Format( AV116DocArqInsData_RangeText1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDocarqinsdata_rangetext1_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavDocarqinsdata_rangetext1_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\DocumentoArquivoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table7_55_5K2e( true) ;
         }
         else
         {
            wb_table7_55_5K2e( false) ;
         }
      }

      protected void wb_table1_25_5K2( bool wbgen )
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
            wb_table8_30_5K2( true) ;
         }
         else
         {
            wb_table8_30_5K2( false) ;
         }
         return  ;
      }

      protected void wb_table8_30_5K2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_25_5K2e( true) ;
         }
         else
         {
            wb_table1_25_5K2e( false) ;
         }
      }

      protected void wb_table8_30_5K2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'" + sGXsfl_120_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV17FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV17FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Pesquisar", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_core\\DocumentoArquivoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table8_30_5K2e( true) ;
         }
         else
         {
            wb_table8_30_5K2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV119DocID = (Guid)getParm(obj,0);
         AssignAttri("", false, "AV119DocID", AV119DocID.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vDOCID", GetSecureSignedToken( "", AV119DocID, context));
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
         PA5K2( ) ;
         WS5K2( ) ;
         WE5K2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2023828232812", true, true);
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
         context.AddJavascriptSource("core/documentoarquivoww.js", "?2023828232814", false, true);
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

      protected void SubsflControlProps_1202( )
      {
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_120_idx;
         edtDocID_Internalname = "DOCID_"+sGXsfl_120_idx;
         edtDocArqSeq_Internalname = "DOCARQSEQ_"+sGXsfl_120_idx;
         edtDocArqConteudoNome_Internalname = "DOCARQCONTEUDONOME_"+sGXsfl_120_idx;
         edtDocArqConteudoExtensao_Internalname = "DOCARQCONTEUDOEXTENSAO_"+sGXsfl_120_idx;
         edtDocArqInsDataHora_Internalname = "DOCARQINSDATAHORA_"+sGXsfl_120_idx;
         edtDocArqObservacao_Internalname = "DOCARQOBSERVACAO_"+sGXsfl_120_idx;
      }

      protected void SubsflControlProps_fel_1202( )
      {
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_120_fel_idx;
         edtDocID_Internalname = "DOCID_"+sGXsfl_120_fel_idx;
         edtDocArqSeq_Internalname = "DOCARQSEQ_"+sGXsfl_120_fel_idx;
         edtDocArqConteudoNome_Internalname = "DOCARQCONTEUDONOME_"+sGXsfl_120_fel_idx;
         edtDocArqConteudoExtensao_Internalname = "DOCARQCONTEUDOEXTENSAO_"+sGXsfl_120_fel_idx;
         edtDocArqInsDataHora_Internalname = "DOCARQINSDATAHORA_"+sGXsfl_120_fel_idx;
         edtDocArqObservacao_Internalname = "DOCARQOBSERVACAO_"+sGXsfl_120_fel_idx;
      }

      protected void sendrow_1202( )
      {
         SubsflControlProps_1202( ) ;
         WB5K0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_120_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_120_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_120_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = " " + ((cmbavGridactions.Enabled!=0)&&(cmbavGridactions.Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 121,'',false,'"+sGXsfl_120_idx+"',120)\"" : " ");
            if ( ( cmbavGridactions.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vGRIDACTIONS_" + sGXsfl_120_idx;
               cmbavGridactions.Name = GXCCtl;
               cmbavGridactions.WebTags = "";
               if ( cmbavGridactions.ItemCount > 0 )
               {
                  AV110GridActions = (short)(Math.Round(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV110GridActions), 4, 0))), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV110GridActions), 4, 0));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavGridactions,(string)cmbavGridactions_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV110GridActions), 4, 0)),(short)1,(string)cmbavGridactions_Jsonclick,(short)5,"'"+""+"'"+",false,"+"'"+"EVGRIDACTIONS.CLICK."+sGXsfl_120_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)cmbavGridactions_Class,(string)"WWActionGroupColumn hidden-xs hidden-sm hidden-md hidden-lg",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((cmbavGridactions.Enabled!=0)&&(cmbavGridactions.Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,121);\"" : " "),(string)"",(bool)true,(short)0});
            cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV110GridActions), 4, 0));
            AssignProp("", false, cmbavGridactions_Internalname, "Values", (string)(cmbavGridactions.ToJavascriptSource()), !bGXsfl_120_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDocID_Internalname,A289DocID.ToString(),A289DocID.ToString(),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDocID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)120,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDocArqSeq_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A307DocArqSeq), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A307DocArqSeq), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDocArqSeq_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)120,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDocArqConteudoNome_Internalname,(string)A322DocArqConteudoNome,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDocArqConteudoNome_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)2000,(short)0,(short)0,(short)120,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDocArqConteudoExtensao_Internalname,(string)A323DocArqConteudoExtensao,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDocArqConteudoExtensao_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)120,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDocArqInsDataHora_Internalname,context.localUtil.TToC( A310DocArqInsDataHora, 10, 12, 0, 3, "/", ":", " "),context.localUtil.Format( A310DocArqInsDataHora, "99/99/9999 99:99:99.999"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDocArqInsDataHora_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)24,(short)0,(short)0,(short)120,(short)0,(short)-1,(short)0,(bool)true,(string)"core\\DataHoraSegundoMS",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDocArqObservacao_Internalname,(string)A324DocArqObservacao,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDocArqObservacao_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)2000,(short)0,(short)0,(short)120,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes5K2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_120_idx = ((subGrid_Islastpage==1)&&(nGXsfl_120_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_120_idx+1);
            sGXsfl_120_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_120_idx), 4, 0), 4, "0");
            SubsflControlProps_1202( ) ;
         }
         /* End function sendrow_1202 */
      }

      protected void init_web_controls( )
      {
         cmbavDynamicfiltersselector1.Name = "vDYNAMICFILTERSSELECTOR1";
         cmbavDynamicfiltersselector1.WebTags = "";
         cmbavDynamicfiltersselector1.addItem("DOCARQINSDATA", "Incluído em", 0);
         if ( cmbavDynamicfiltersselector1.ItemCount > 0 )
         {
            AV18DynamicFiltersSelector1 = cmbavDynamicfiltersselector1.getValidValue(AV18DynamicFiltersSelector1);
            AssignAttri("", false, "AV18DynamicFiltersSelector1", AV18DynamicFiltersSelector1);
         }
         cmbavDynamicfiltersoperator1.Name = "vDYNAMICFILTERSOPERATOR1";
         cmbavDynamicfiltersoperator1.WebTags = "";
         cmbavDynamicfiltersoperator1.addItem("0", "Passado", 0);
         cmbavDynamicfiltersoperator1.addItem("1", "Hoje", 0);
         cmbavDynamicfiltersoperator1.addItem("2", "No futuro", 0);
         cmbavDynamicfiltersoperator1.addItem("3", "Período", 0);
         if ( cmbavDynamicfiltersoperator1.ItemCount > 0 )
         {
            AV19DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         }
         cmbavDynamicfiltersselector2.Name = "vDYNAMICFILTERSSELECTOR2";
         cmbavDynamicfiltersselector2.WebTags = "";
         cmbavDynamicfiltersselector2.addItem("DOCARQINSDATA", "Incluído em", 0);
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
            AV23DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV23DynamicFiltersSelector2);
            AssignAttri("", false, "AV23DynamicFiltersSelector2", AV23DynamicFiltersSelector2);
         }
         cmbavDynamicfiltersoperator2.Name = "vDYNAMICFILTERSOPERATOR2";
         cmbavDynamicfiltersoperator2.WebTags = "";
         cmbavDynamicfiltersoperator2.addItem("0", "Passado", 0);
         cmbavDynamicfiltersoperator2.addItem("1", "Hoje", 0);
         cmbavDynamicfiltersoperator2.addItem("2", "No futuro", 0);
         cmbavDynamicfiltersoperator2.addItem("3", "Período", 0);
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV24DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV24DynamicFiltersOperator2), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV24DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV24DynamicFiltersOperator2), 4, 0));
         }
         cmbavDynamicfiltersselector3.Name = "vDYNAMICFILTERSSELECTOR3";
         cmbavDynamicfiltersselector3.WebTags = "";
         cmbavDynamicfiltersselector3.addItem("DOCARQINSDATA", "Incluído em", 0);
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV28DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV28DynamicFiltersSelector3);
            AssignAttri("", false, "AV28DynamicFiltersSelector3", AV28DynamicFiltersSelector3);
         }
         cmbavDynamicfiltersoperator3.Name = "vDYNAMICFILTERSOPERATOR3";
         cmbavDynamicfiltersoperator3.WebTags = "";
         cmbavDynamicfiltersoperator3.addItem("0", "Passado", 0);
         cmbavDynamicfiltersoperator3.addItem("1", "Hoje", 0);
         cmbavDynamicfiltersoperator3.addItem("2", "No futuro", 0);
         cmbavDynamicfiltersoperator3.addItem("3", "Período", 0);
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV29DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV29DynamicFiltersOperator3), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV29DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV29DynamicFiltersOperator3), 4, 0));
         }
         GXCCtl = "vGRIDACTIONS_" + sGXsfl_120_idx;
         cmbavGridactions.Name = GXCCtl;
         cmbavGridactions.WebTags = "";
         if ( cmbavGridactions.ItemCount > 0 )
         {
            AV110GridActions = (short)(Math.Round(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV110GridActions), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV110GridActions), 4, 0));
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl120( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"120\">") ;
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
            context.SendWebValue( "ID") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Sequência") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Nome do Arquivo") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Extensão") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Incluído em") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Observações") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV110GridActions), 4, 0, ".", ""))));
            GridColumn.AddObjectProperty("Class", StringUtil.RTrim( cmbavGridactions_Class));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A289DocID.ToString()));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A307DocArqSeq), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A322DocArqConteudoNome));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A323DocArqConteudoExtensao));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.TToC( A310DocArqInsDataHora, 10, 12, 0, 3, "/", ":", " ")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A324DocArqObservacao));
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
         edtavDocid_filtro_Internalname = "vDOCID_FILTRO";
         bttBtnagexport_Internalname = "BTNAGEXPORT";
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
         edtavDocarqinsdata_rangetext1_Internalname = "vDOCARQINSDATA_RANGETEXT1";
         cellDocarqinsdata_range_cell1_Internalname = "DOCARQINSDATA_RANGE_CELL1";
         tblTablemergeddynamicfiltersdocarqinsdata1_Internalname = "TABLEMERGEDDYNAMICFILTERSDOCARQINSDATA1";
         cellFilter_docarqinsdata1_cell_Internalname = "FILTER_DOCARQINSDATA1_CELL";
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
         edtavDocarqinsdata_rangetext2_Internalname = "vDOCARQINSDATA_RANGETEXT2";
         cellDocarqinsdata_range_cell2_Internalname = "DOCARQINSDATA_RANGE_CELL2";
         tblTablemergeddynamicfiltersdocarqinsdata2_Internalname = "TABLEMERGEDDYNAMICFILTERSDOCARQINSDATA2";
         cellFilter_docarqinsdata2_cell_Internalname = "FILTER_DOCARQINSDATA2_CELL";
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
         edtavDocarqinsdata_rangetext3_Internalname = "vDOCARQINSDATA_RANGETEXT3";
         cellDocarqinsdata_range_cell3_Internalname = "DOCARQINSDATA_RANGE_CELL3";
         tblTablemergeddynamicfiltersdocarqinsdata3_Internalname = "TABLEMERGEDDYNAMICFILTERSDOCARQINSDATA3";
         cellFilter_docarqinsdata3_cell_Internalname = "FILTER_DOCARQINSDATA3_CELL";
         imgRemovedynamicfilters3_Internalname = "REMOVEDYNAMICFILTERS3";
         cellDynamicfilters_removefilter3_cell_Internalname = "DYNAMICFILTERS_REMOVEFILTER3_CELL";
         tblTablemergeddynamicfilters3_Internalname = "TABLEMERGEDDYNAMICFILTERS3";
         divTabledynamicfiltersrow3_Internalname = "TABLEDYNAMICFILTERSROW3";
         divTabledynamicfilters_Internalname = "TABLEDYNAMICFILTERS";
         divAdvancedfilterscontainer_Internalname = "ADVANCEDFILTERSCONTAINER";
         divTableheader_Internalname = "TABLEHEADER";
         cmbavGridactions_Internalname = "vGRIDACTIONS";
         edtDocID_Internalname = "DOCID";
         edtDocArqSeq_Internalname = "DOCARQSEQ";
         edtDocArqConteudoNome_Internalname = "DOCARQCONTEUDONOME";
         edtDocArqConteudoExtensao_Internalname = "DOCARQCONTEUDOEXTENSAO";
         edtDocArqInsDataHora_Internalname = "DOCARQINSDATAHORA";
         edtDocArqObservacao_Internalname = "DOCARQOBSERVACAO";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         Ddo_agexport_Internalname = "DDO_AGEXPORT";
         Ddc_subscriptions_Internalname = "DDC_SUBSCRIPTIONS";
         Docarqinsdata_rangepicker1_Internalname = "DOCARQINSDATA_RANGEPICKER1";
         Docarqinsdata_rangepicker2_Internalname = "DOCARQINSDATA_RANGEPICKER2";
         Docarqinsdata_rangepicker3_Internalname = "DOCARQINSDATA_RANGEPICKER3";
         lblJsdynamicfilters_Internalname = "JSDYNAMICFILTERS";
         Ddo_grid_Internalname = "DDO_GRID";
         edtavDocid_Internalname = "vDOCID";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
         divDiv_wwpauxwc_Internalname = "DIV_WWPAUXWC";
         edtavDdo_docarqinsdatahoraauxdatetext_Internalname = "vDDO_DOCARQINSDATAHORAAUXDATETEXT";
         Tfdocarqinsdatahora_rangepicker_Internalname = "TFDOCARQINSDATAHORA_RANGEPICKER";
         divDdo_docarqinsdatahoraauxdates_Internalname = "DDO_DOCARQINSDATAHORAAUXDATES";
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
         edtDocArqObservacao_Jsonclick = "";
         edtDocArqInsDataHora_Jsonclick = "";
         edtDocArqConteudoExtensao_Jsonclick = "";
         edtDocArqConteudoNome_Jsonclick = "";
         edtDocArqSeq_Jsonclick = "";
         edtDocID_Jsonclick = "";
         cmbavGridactions_Jsonclick = "";
         cmbavGridactions.Visible = -1;
         cmbavGridactions.Enabled = 1;
         cmbavGridactions_Class = "ConvertToDDO";
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         edtavDocarqinsdata_rangetext1_Jsonclick = "";
         edtavDocarqinsdata_rangetext1_Enabled = 1;
         imgRemovedynamicfilters1_Visible = 1;
         imgAdddynamicfilters1_Visible = 1;
         cmbavDynamicfiltersoperator1_Jsonclick = "";
         cmbavDynamicfiltersoperator1.Enabled = 1;
         edtavDocarqinsdata_rangetext2_Jsonclick = "";
         edtavDocarqinsdata_rangetext2_Enabled = 1;
         imgRemovedynamicfilters2_Visible = 1;
         imgAdddynamicfilters2_Visible = 1;
         cmbavDynamicfiltersoperator2_Jsonclick = "";
         cmbavDynamicfiltersoperator2.Enabled = 1;
         edtavDocarqinsdata_rangetext3_Jsonclick = "";
         edtavDocarqinsdata_rangetext3_Enabled = 1;
         cmbavDynamicfiltersoperator3_Jsonclick = "";
         cmbavDynamicfiltersoperator3.Enabled = 1;
         cellDocarqinsdata_range_cell3_Class = "MergeDataCell";
         cmbavDynamicfiltersoperator3.Visible = 1;
         tblTablemergeddynamicfiltersdocarqinsdata3_Visible = 1;
         cellDocarqinsdata_range_cell2_Class = "MergeDataCell";
         cmbavDynamicfiltersoperator2.Visible = 1;
         tblTablemergeddynamicfiltersdocarqinsdata2_Visible = 1;
         cellDocarqinsdata_range_cell1_Class = "MergeDataCell";
         cmbavDynamicfiltersoperator1.Visible = 1;
         tblTablemergeddynamicfiltersdocarqinsdata1_Visible = 1;
         subGrid_Sortable = 0;
         edtavDdo_docarqinsdatahoraauxdatetext_Jsonclick = "";
         edtavDocid_Jsonclick = "";
         edtavDocid_Visible = 1;
         lblJsdynamicfilters_Caption = "JSDynamicFilters";
         cmbavDynamicfiltersselector3_Jsonclick = "";
         cmbavDynamicfiltersselector3.Enabled = 1;
         cmbavDynamicfiltersselector2_Jsonclick = "";
         cmbavDynamicfiltersselector2.Enabled = 1;
         cmbavDynamicfiltersselector1_Jsonclick = "";
         cmbavDynamicfiltersselector1.Enabled = 1;
         bttBtnsubscriptions_Visible = 1;
         edtavDocid_filtro_Jsonclick = "";
         edtavDocid_filtro_Enabled = 1;
         Grid_empowerer_Fixedcolumns = "L;;;;;;";
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_grid_Datalistproc = "core.DocumentoArquivoWWGetFilterData";
         Ddo_grid_Datalisttype = "Dynamic|Dynamic||Dynamic";
         Ddo_grid_Includedatalist = "T|T||T";
         Ddo_grid_Filterisrange = "||P|";
         Ddo_grid_Filtertype = "Character|Character|Date|Character";
         Ddo_grid_Includefilter = "T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "2|3|4|5";
         Ddo_grid_Columnids = "3:DocArqConteudoNome|4:DocArqConteudoExtensao|5:DocArqInsDataHora|6:DocArqObservacao";
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
         Form.Caption = " Arquivos do Documento";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV20DocArqInsData1',fld:'vDOCARQINSDATA1',pic:''},{av:'AV25DocArqInsData2',fld:'vDOCARQINSDATA2',pic:''},{av:'AV30DocArqInsData3',fld:'vDOCARQINSDATA3',pic:''},{av:'AV119DocID',fld:'vDOCID',pic:'',hsh:true},{av:'AV121Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV120DocID_Filtro',fld:'vDOCID_FILTRO',pic:''},{av:'AV21DocArqInsData_To1',fld:'vDOCARQINSDATA_TO1',pic:''},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV26DocArqInsData_To2',fld:'vDOCARQINSDATA_TO2',pic:''},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV31DocArqInsData_To3',fld:'vDOCARQINSDATA_TO3',pic:''},{av:'AV97TFDocArqConteudoNome',fld:'vTFDOCARQCONTEUDONOME',pic:''},{av:'AV98TFDocArqConteudoNome_Sel',fld:'vTFDOCARQCONTEUDONOME_SEL',pic:''},{av:'AV99TFDocArqConteudoExtensao',fld:'vTFDOCARQCONTEUDOEXTENSAO',pic:''},{av:'AV100TFDocArqConteudoExtensao_Sel',fld:'vTFDOCARQCONTEUDOEXTENSAO_SEL',pic:''},{av:'AV58TFDocArqInsDataHora',fld:'vTFDOCARQINSDATAHORA',pic:'99/99/9999 99:99:99.999'},{av:'AV59TFDocArqInsDataHora_To',fld:'vTFDOCARQINSDATAHORA_TO',pic:'99/99/9999 99:99:99.999'},{av:'AV101TFDocArqObservacao',fld:'vTFDOCARQOBSERVACAO',pic:''},{av:'AV102TFDocArqObservacao_Sel',fld:'vTFDOCARQOBSERVACAO_SEL',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV111IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV112IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV107GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV108GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV109GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV111IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV112IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E125K2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV20DocArqInsData1',fld:'vDOCARQINSDATA1',pic:''},{av:'AV25DocArqInsData2',fld:'vDOCARQINSDATA2',pic:''},{av:'AV30DocArqInsData3',fld:'vDOCARQINSDATA3',pic:''},{av:'AV119DocID',fld:'vDOCID',pic:'',hsh:true},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV121Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV120DocID_Filtro',fld:'vDOCID_FILTRO',pic:''},{av:'AV21DocArqInsData_To1',fld:'vDOCARQINSDATA_TO1',pic:''},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV26DocArqInsData_To2',fld:'vDOCARQINSDATA_TO2',pic:''},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV31DocArqInsData_To3',fld:'vDOCARQINSDATA_TO3',pic:''},{av:'AV97TFDocArqConteudoNome',fld:'vTFDOCARQCONTEUDONOME',pic:''},{av:'AV98TFDocArqConteudoNome_Sel',fld:'vTFDOCARQCONTEUDONOME_SEL',pic:''},{av:'AV99TFDocArqConteudoExtensao',fld:'vTFDOCARQCONTEUDOEXTENSAO',pic:''},{av:'AV100TFDocArqConteudoExtensao_Sel',fld:'vTFDOCARQCONTEUDOEXTENSAO_SEL',pic:''},{av:'AV58TFDocArqInsDataHora',fld:'vTFDOCARQINSDATAHORA',pic:'99/99/9999 99:99:99.999'},{av:'AV59TFDocArqInsDataHora_To',fld:'vTFDOCARQINSDATAHORA_TO',pic:'99/99/9999 99:99:99.999'},{av:'AV101TFDocArqObservacao',fld:'vTFDOCARQOBSERVACAO',pic:''},{av:'AV102TFDocArqObservacao_Sel',fld:'vTFDOCARQOBSERVACAO_SEL',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV111IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV112IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E135K2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV20DocArqInsData1',fld:'vDOCARQINSDATA1',pic:''},{av:'AV25DocArqInsData2',fld:'vDOCARQINSDATA2',pic:''},{av:'AV30DocArqInsData3',fld:'vDOCARQINSDATA3',pic:''},{av:'AV119DocID',fld:'vDOCID',pic:'',hsh:true},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV121Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV120DocID_Filtro',fld:'vDOCID_FILTRO',pic:''},{av:'AV21DocArqInsData_To1',fld:'vDOCARQINSDATA_TO1',pic:''},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV26DocArqInsData_To2',fld:'vDOCARQINSDATA_TO2',pic:''},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV31DocArqInsData_To3',fld:'vDOCARQINSDATA_TO3',pic:''},{av:'AV97TFDocArqConteudoNome',fld:'vTFDOCARQCONTEUDONOME',pic:''},{av:'AV98TFDocArqConteudoNome_Sel',fld:'vTFDOCARQCONTEUDONOME_SEL',pic:''},{av:'AV99TFDocArqConteudoExtensao',fld:'vTFDOCARQCONTEUDOEXTENSAO',pic:''},{av:'AV100TFDocArqConteudoExtensao_Sel',fld:'vTFDOCARQCONTEUDOEXTENSAO_SEL',pic:''},{av:'AV58TFDocArqInsDataHora',fld:'vTFDOCARQINSDATAHORA',pic:'99/99/9999 99:99:99.999'},{av:'AV59TFDocArqInsDataHora_To',fld:'vTFDOCARQINSDATAHORA_TO',pic:'99/99/9999 99:99:99.999'},{av:'AV101TFDocArqObservacao',fld:'vTFDOCARQOBSERVACAO',pic:''},{av:'AV102TFDocArqObservacao_Sel',fld:'vTFDOCARQOBSERVACAO_SEL',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV111IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV112IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]}");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","{handler:'E195K2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV20DocArqInsData1',fld:'vDOCARQINSDATA1',pic:''},{av:'AV25DocArqInsData2',fld:'vDOCARQINSDATA2',pic:''},{av:'AV30DocArqInsData3',fld:'vDOCARQINSDATA3',pic:''},{av:'AV119DocID',fld:'vDOCID',pic:'',hsh:true},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV121Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV120DocID_Filtro',fld:'vDOCID_FILTRO',pic:''},{av:'AV21DocArqInsData_To1',fld:'vDOCARQINSDATA_TO1',pic:''},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV26DocArqInsData_To2',fld:'vDOCARQINSDATA_TO2',pic:''},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV31DocArqInsData_To3',fld:'vDOCARQINSDATA_TO3',pic:''},{av:'AV97TFDocArqConteudoNome',fld:'vTFDOCARQCONTEUDONOME',pic:''},{av:'AV98TFDocArqConteudoNome_Sel',fld:'vTFDOCARQCONTEUDONOME_SEL',pic:''},{av:'AV99TFDocArqConteudoExtensao',fld:'vTFDOCARQCONTEUDOEXTENSAO',pic:''},{av:'AV100TFDocArqConteudoExtensao_Sel',fld:'vTFDOCARQCONTEUDOEXTENSAO_SEL',pic:''},{av:'AV58TFDocArqInsDataHora',fld:'vTFDOCARQINSDATAHORA',pic:'99/99/9999 99:99:99.999'},{av:'AV59TFDocArqInsDataHora_To',fld:'vTFDOCARQINSDATAHORA_TO',pic:'99/99/9999 99:99:99.999'},{av:'AV101TFDocArqObservacao',fld:'vTFDOCARQOBSERVACAO',pic:''},{av:'AV102TFDocArqObservacao_Sel',fld:'vTFDOCARQOBSERVACAO_SEL',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV111IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV112IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true},{av:'Ddo_grid_Activeeventkey',ctrl:'DDO_GRID',prop:'ActiveEventKey'},{av:'Ddo_grid_Selectedvalue_get',ctrl:'DDO_GRID',prop:'SelectedValue_get'},{av:'Ddo_grid_Selectedcolumn',ctrl:'DDO_GRID',prop:'SelectedColumn'},{av:'Ddo_grid_Filteredtext_get',ctrl:'DDO_GRID',prop:'FilteredText_get'},{av:'Ddo_grid_Filteredtextto_get',ctrl:'DDO_GRID',prop:'FilteredTextTo_get'}]");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",",oparms:[{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV97TFDocArqConteudoNome',fld:'vTFDOCARQCONTEUDONOME',pic:''},{av:'AV98TFDocArqConteudoNome_Sel',fld:'vTFDOCARQCONTEUDONOME_SEL',pic:''},{av:'AV99TFDocArqConteudoExtensao',fld:'vTFDOCARQCONTEUDOEXTENSAO',pic:''},{av:'AV100TFDocArqConteudoExtensao_Sel',fld:'vTFDOCARQCONTEUDOEXTENSAO_SEL',pic:''},{av:'AV58TFDocArqInsDataHora',fld:'vTFDOCARQINSDATAHORA',pic:'99/99/9999 99:99:99.999'},{av:'AV59TFDocArqInsDataHora_To',fld:'vTFDOCARQINSDATAHORA_TO',pic:'99/99/9999 99:99:99.999'},{av:'AV101TFDocArqObservacao',fld:'vTFDOCARQOBSERVACAO',pic:''},{av:'AV102TFDocArqObservacao_Sel',fld:'vTFDOCARQOBSERVACAO_SEL',pic:''},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E335K2',iparms:[{av:'AV111IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV112IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'cmbavGridactions'},{av:'AV110GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9'}]}");
         setEventMetadata("'ADDDYNAMICFILTERS1'","{handler:'E235K2',iparms:[]");
         setEventMetadata("'ADDDYNAMICFILTERS1'",",oparms:[{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'","{handler:'E205K2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV20DocArqInsData1',fld:'vDOCARQINSDATA1',pic:''},{av:'AV25DocArqInsData2',fld:'vDOCARQINSDATA2',pic:''},{av:'AV30DocArqInsData3',fld:'vDOCARQINSDATA3',pic:''},{av:'AV119DocID',fld:'vDOCID',pic:'',hsh:true},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV121Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV120DocID_Filtro',fld:'vDOCID_FILTRO',pic:''},{av:'AV21DocArqInsData_To1',fld:'vDOCARQINSDATA_TO1',pic:''},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV26DocArqInsData_To2',fld:'vDOCARQINSDATA_TO2',pic:''},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV31DocArqInsData_To3',fld:'vDOCARQINSDATA_TO3',pic:''},{av:'AV97TFDocArqConteudoNome',fld:'vTFDOCARQCONTEUDONOME',pic:''},{av:'AV98TFDocArqConteudoNome_Sel',fld:'vTFDOCARQCONTEUDONOME_SEL',pic:''},{av:'AV99TFDocArqConteudoExtensao',fld:'vTFDOCARQCONTEUDOEXTENSAO',pic:''},{av:'AV100TFDocArqConteudoExtensao_Sel',fld:'vTFDOCARQCONTEUDOEXTENSAO_SEL',pic:''},{av:'AV58TFDocArqInsDataHora',fld:'vTFDOCARQINSDATAHORA',pic:'99/99/9999 99:99:99.999'},{av:'AV59TFDocArqInsDataHora_To',fld:'vTFDOCARQINSDATAHORA_TO',pic:'99/99/9999 99:99:99.999'},{av:'AV101TFDocArqObservacao',fld:'vTFDOCARQOBSERVACAO',pic:''},{av:'AV102TFDocArqObservacao_Sel',fld:'vTFDOCARQOBSERVACAO_SEL',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV111IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV112IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'",",oparms:[{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV25DocArqInsData2',fld:'vDOCARQINSDATA2',pic:''},{av:'AV26DocArqInsData_To2',fld:'vDOCARQINSDATA_TO2',pic:''},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV30DocArqInsData3',fld:'vDOCARQINSDATA3',pic:''},{av:'AV31DocArqInsData_To3',fld:'vDOCARQINSDATA_TO3',pic:''},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV20DocArqInsData1',fld:'vDOCARQINSDATA1',pic:''},{av:'AV21DocArqInsData_To1',fld:'vDOCARQINSDATA_TO1',pic:''},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'tblTablemergeddynamicfiltersdocarqinsdata2_Visible',ctrl:'TABLEMERGEDDYNAMICFILTERSDOCARQINSDATA2',prop:'Visible'},{av:'tblTablemergeddynamicfiltersdocarqinsdata3_Visible',ctrl:'TABLEMERGEDDYNAMICFILTERSDOCARQINSDATA3',prop:'Visible'},{av:'tblTablemergeddynamicfiltersdocarqinsdata1_Visible',ctrl:'TABLEMERGEDDYNAMICFILTERSDOCARQINSDATA1',prop:'Visible'},{av:'cellDocarqinsdata_range_cell2_Class',ctrl:'DOCARQINSDATA_RANGE_CELL2',prop:'Class'},{av:'cellDocarqinsdata_range_cell3_Class',ctrl:'DOCARQINSDATA_RANGE_CELL3',prop:'Class'},{av:'cellDocarqinsdata_range_cell1_Class',ctrl:'DOCARQINSDATA_RANGE_CELL1',prop:'Class'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV107GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV108GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV109GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV111IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV112IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK","{handler:'E245K2',iparms:[{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK",",oparms:[{av:'tblTablemergeddynamicfiltersdocarqinsdata1_Visible',ctrl:'TABLEMERGEDDYNAMICFILTERSDOCARQINSDATA1',prop:'Visible'},{av:'cmbavDynamicfiltersoperator1'},{av:'cellDocarqinsdata_range_cell1_Class',ctrl:'DOCARQINSDATA_RANGE_CELL1',prop:'Class'},{av:'AV20DocArqInsData1',fld:'vDOCARQINSDATA1',pic:''}]}");
         setEventMetadata("DOCARQINSDATA_RANGEPICKER1.DATERANGECHANGED","{handler:'E165K2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV20DocArqInsData1',fld:'vDOCARQINSDATA1',pic:''},{av:'AV25DocArqInsData2',fld:'vDOCARQINSDATA2',pic:''},{av:'AV30DocArqInsData3',fld:'vDOCARQINSDATA3',pic:''},{av:'AV119DocID',fld:'vDOCID',pic:'',hsh:true},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV121Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV120DocID_Filtro',fld:'vDOCID_FILTRO',pic:''},{av:'AV21DocArqInsData_To1',fld:'vDOCARQINSDATA_TO1',pic:''},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV26DocArqInsData_To2',fld:'vDOCARQINSDATA_TO2',pic:''},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV31DocArqInsData_To3',fld:'vDOCARQINSDATA_TO3',pic:''},{av:'AV97TFDocArqConteudoNome',fld:'vTFDOCARQCONTEUDONOME',pic:''},{av:'AV98TFDocArqConteudoNome_Sel',fld:'vTFDOCARQCONTEUDONOME_SEL',pic:''},{av:'AV99TFDocArqConteudoExtensao',fld:'vTFDOCARQCONTEUDOEXTENSAO',pic:''},{av:'AV100TFDocArqConteudoExtensao_Sel',fld:'vTFDOCARQCONTEUDOEXTENSAO_SEL',pic:''},{av:'AV58TFDocArqInsDataHora',fld:'vTFDOCARQINSDATAHORA',pic:'99/99/9999 99:99:99.999'},{av:'AV59TFDocArqInsDataHora_To',fld:'vTFDOCARQINSDATAHORA_TO',pic:'99/99/9999 99:99:99.999'},{av:'AV101TFDocArqObservacao',fld:'vTFDOCARQOBSERVACAO',pic:''},{av:'AV102TFDocArqObservacao_Sel',fld:'vTFDOCARQOBSERVACAO_SEL',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV111IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV112IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true}]");
         setEventMetadata("DOCARQINSDATA_RANGEPICKER1.DATERANGECHANGED",",oparms:[{av:'AV20DocArqInsData1',fld:'vDOCARQINSDATA1',pic:''},{av:'AV21DocArqInsData_To1',fld:'vDOCARQINSDATA_TO1',pic:''},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV107GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV108GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV109GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV111IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV112IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSOPERATOR1.CLICK","{handler:'E255K2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV20DocArqInsData1',fld:'vDOCARQINSDATA1',pic:''},{av:'AV25DocArqInsData2',fld:'vDOCARQINSDATA2',pic:''},{av:'AV30DocArqInsData3',fld:'vDOCARQINSDATA3',pic:''},{av:'AV119DocID',fld:'vDOCID',pic:'',hsh:true},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV121Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV120DocID_Filtro',fld:'vDOCID_FILTRO',pic:''},{av:'AV21DocArqInsData_To1',fld:'vDOCARQINSDATA_TO1',pic:''},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV26DocArqInsData_To2',fld:'vDOCARQINSDATA_TO2',pic:''},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV31DocArqInsData_To3',fld:'vDOCARQINSDATA_TO3',pic:''},{av:'AV97TFDocArqConteudoNome',fld:'vTFDOCARQCONTEUDONOME',pic:''},{av:'AV98TFDocArqConteudoNome_Sel',fld:'vTFDOCARQCONTEUDONOME_SEL',pic:''},{av:'AV99TFDocArqConteudoExtensao',fld:'vTFDOCARQCONTEUDOEXTENSAO',pic:''},{av:'AV100TFDocArqConteudoExtensao_Sel',fld:'vTFDOCARQCONTEUDOEXTENSAO_SEL',pic:''},{av:'AV58TFDocArqInsDataHora',fld:'vTFDOCARQINSDATAHORA',pic:'99/99/9999 99:99:99.999'},{av:'AV59TFDocArqInsDataHora_To',fld:'vTFDOCARQINSDATAHORA_TO',pic:'99/99/9999 99:99:99.999'},{av:'AV101TFDocArqObservacao',fld:'vTFDOCARQOBSERVACAO',pic:''},{av:'AV102TFDocArqObservacao_Sel',fld:'vTFDOCARQOBSERVACAO_SEL',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV111IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV112IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true}]");
         setEventMetadata("VDYNAMICFILTERSOPERATOR1.CLICK",",oparms:[{av:'AV20DocArqInsData1',fld:'vDOCARQINSDATA1',pic:''},{av:'AV21DocArqInsData_To1',fld:'vDOCARQINSDATA_TO1',pic:''},{av:'cellDocarqinsdata_range_cell1_Class',ctrl:'DOCARQINSDATA_RANGE_CELL1',prop:'Class'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV107GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV108GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV109GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV111IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV112IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("'ADDDYNAMICFILTERS2'","{handler:'E265K2',iparms:[]");
         setEventMetadata("'ADDDYNAMICFILTERS2'",",oparms:[{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'","{handler:'E215K2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV20DocArqInsData1',fld:'vDOCARQINSDATA1',pic:''},{av:'AV25DocArqInsData2',fld:'vDOCARQINSDATA2',pic:''},{av:'AV30DocArqInsData3',fld:'vDOCARQINSDATA3',pic:''},{av:'AV119DocID',fld:'vDOCID',pic:'',hsh:true},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV121Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV120DocID_Filtro',fld:'vDOCID_FILTRO',pic:''},{av:'AV21DocArqInsData_To1',fld:'vDOCARQINSDATA_TO1',pic:''},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV26DocArqInsData_To2',fld:'vDOCARQINSDATA_TO2',pic:''},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV31DocArqInsData_To3',fld:'vDOCARQINSDATA_TO3',pic:''},{av:'AV97TFDocArqConteudoNome',fld:'vTFDOCARQCONTEUDONOME',pic:''},{av:'AV98TFDocArqConteudoNome_Sel',fld:'vTFDOCARQCONTEUDONOME_SEL',pic:''},{av:'AV99TFDocArqConteudoExtensao',fld:'vTFDOCARQCONTEUDOEXTENSAO',pic:''},{av:'AV100TFDocArqConteudoExtensao_Sel',fld:'vTFDOCARQCONTEUDOEXTENSAO_SEL',pic:''},{av:'AV58TFDocArqInsDataHora',fld:'vTFDOCARQINSDATAHORA',pic:'99/99/9999 99:99:99.999'},{av:'AV59TFDocArqInsDataHora_To',fld:'vTFDOCARQINSDATAHORA_TO',pic:'99/99/9999 99:99:99.999'},{av:'AV101TFDocArqObservacao',fld:'vTFDOCARQOBSERVACAO',pic:''},{av:'AV102TFDocArqObservacao_Sel',fld:'vTFDOCARQOBSERVACAO_SEL',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV111IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV112IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'",",oparms:[{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV25DocArqInsData2',fld:'vDOCARQINSDATA2',pic:''},{av:'AV26DocArqInsData_To2',fld:'vDOCARQINSDATA_TO2',pic:''},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV30DocArqInsData3',fld:'vDOCARQINSDATA3',pic:''},{av:'AV31DocArqInsData_To3',fld:'vDOCARQINSDATA_TO3',pic:''},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV20DocArqInsData1',fld:'vDOCARQINSDATA1',pic:''},{av:'AV21DocArqInsData_To1',fld:'vDOCARQINSDATA_TO1',pic:''},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'tblTablemergeddynamicfiltersdocarqinsdata2_Visible',ctrl:'TABLEMERGEDDYNAMICFILTERSDOCARQINSDATA2',prop:'Visible'},{av:'tblTablemergeddynamicfiltersdocarqinsdata3_Visible',ctrl:'TABLEMERGEDDYNAMICFILTERSDOCARQINSDATA3',prop:'Visible'},{av:'tblTablemergeddynamicfiltersdocarqinsdata1_Visible',ctrl:'TABLEMERGEDDYNAMICFILTERSDOCARQINSDATA1',prop:'Visible'},{av:'cellDocarqinsdata_range_cell2_Class',ctrl:'DOCARQINSDATA_RANGE_CELL2',prop:'Class'},{av:'cellDocarqinsdata_range_cell3_Class',ctrl:'DOCARQINSDATA_RANGE_CELL3',prop:'Class'},{av:'cellDocarqinsdata_range_cell1_Class',ctrl:'DOCARQINSDATA_RANGE_CELL1',prop:'Class'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV107GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV108GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV109GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV111IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV112IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK","{handler:'E275K2',iparms:[{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK",",oparms:[{av:'tblTablemergeddynamicfiltersdocarqinsdata2_Visible',ctrl:'TABLEMERGEDDYNAMICFILTERSDOCARQINSDATA2',prop:'Visible'},{av:'cmbavDynamicfiltersoperator2'},{av:'cellDocarqinsdata_range_cell2_Class',ctrl:'DOCARQINSDATA_RANGE_CELL2',prop:'Class'},{av:'AV25DocArqInsData2',fld:'vDOCARQINSDATA2',pic:''}]}");
         setEventMetadata("DOCARQINSDATA_RANGEPICKER2.DATERANGECHANGED","{handler:'E175K2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV20DocArqInsData1',fld:'vDOCARQINSDATA1',pic:''},{av:'AV25DocArqInsData2',fld:'vDOCARQINSDATA2',pic:''},{av:'AV30DocArqInsData3',fld:'vDOCARQINSDATA3',pic:''},{av:'AV119DocID',fld:'vDOCID',pic:'',hsh:true},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV121Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV120DocID_Filtro',fld:'vDOCID_FILTRO',pic:''},{av:'AV21DocArqInsData_To1',fld:'vDOCARQINSDATA_TO1',pic:''},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV26DocArqInsData_To2',fld:'vDOCARQINSDATA_TO2',pic:''},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV31DocArqInsData_To3',fld:'vDOCARQINSDATA_TO3',pic:''},{av:'AV97TFDocArqConteudoNome',fld:'vTFDOCARQCONTEUDONOME',pic:''},{av:'AV98TFDocArqConteudoNome_Sel',fld:'vTFDOCARQCONTEUDONOME_SEL',pic:''},{av:'AV99TFDocArqConteudoExtensao',fld:'vTFDOCARQCONTEUDOEXTENSAO',pic:''},{av:'AV100TFDocArqConteudoExtensao_Sel',fld:'vTFDOCARQCONTEUDOEXTENSAO_SEL',pic:''},{av:'AV58TFDocArqInsDataHora',fld:'vTFDOCARQINSDATAHORA',pic:'99/99/9999 99:99:99.999'},{av:'AV59TFDocArqInsDataHora_To',fld:'vTFDOCARQINSDATAHORA_TO',pic:'99/99/9999 99:99:99.999'},{av:'AV101TFDocArqObservacao',fld:'vTFDOCARQOBSERVACAO',pic:''},{av:'AV102TFDocArqObservacao_Sel',fld:'vTFDOCARQOBSERVACAO_SEL',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV111IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV112IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true}]");
         setEventMetadata("DOCARQINSDATA_RANGEPICKER2.DATERANGECHANGED",",oparms:[{av:'AV25DocArqInsData2',fld:'vDOCARQINSDATA2',pic:''},{av:'AV26DocArqInsData_To2',fld:'vDOCARQINSDATA_TO2',pic:''},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV107GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV108GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV109GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV111IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV112IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSOPERATOR2.CLICK","{handler:'E285K2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV20DocArqInsData1',fld:'vDOCARQINSDATA1',pic:''},{av:'AV25DocArqInsData2',fld:'vDOCARQINSDATA2',pic:''},{av:'AV30DocArqInsData3',fld:'vDOCARQINSDATA3',pic:''},{av:'AV119DocID',fld:'vDOCID',pic:'',hsh:true},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV121Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV120DocID_Filtro',fld:'vDOCID_FILTRO',pic:''},{av:'AV21DocArqInsData_To1',fld:'vDOCARQINSDATA_TO1',pic:''},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV26DocArqInsData_To2',fld:'vDOCARQINSDATA_TO2',pic:''},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV31DocArqInsData_To3',fld:'vDOCARQINSDATA_TO3',pic:''},{av:'AV97TFDocArqConteudoNome',fld:'vTFDOCARQCONTEUDONOME',pic:''},{av:'AV98TFDocArqConteudoNome_Sel',fld:'vTFDOCARQCONTEUDONOME_SEL',pic:''},{av:'AV99TFDocArqConteudoExtensao',fld:'vTFDOCARQCONTEUDOEXTENSAO',pic:''},{av:'AV100TFDocArqConteudoExtensao_Sel',fld:'vTFDOCARQCONTEUDOEXTENSAO_SEL',pic:''},{av:'AV58TFDocArqInsDataHora',fld:'vTFDOCARQINSDATAHORA',pic:'99/99/9999 99:99:99.999'},{av:'AV59TFDocArqInsDataHora_To',fld:'vTFDOCARQINSDATAHORA_TO',pic:'99/99/9999 99:99:99.999'},{av:'AV101TFDocArqObservacao',fld:'vTFDOCARQOBSERVACAO',pic:''},{av:'AV102TFDocArqObservacao_Sel',fld:'vTFDOCARQOBSERVACAO_SEL',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV111IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV112IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true}]");
         setEventMetadata("VDYNAMICFILTERSOPERATOR2.CLICK",",oparms:[{av:'AV25DocArqInsData2',fld:'vDOCARQINSDATA2',pic:''},{av:'AV26DocArqInsData_To2',fld:'vDOCARQINSDATA_TO2',pic:''},{av:'cellDocarqinsdata_range_cell2_Class',ctrl:'DOCARQINSDATA_RANGE_CELL2',prop:'Class'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV107GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV108GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV109GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV111IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV112IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'","{handler:'E225K2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV20DocArqInsData1',fld:'vDOCARQINSDATA1',pic:''},{av:'AV25DocArqInsData2',fld:'vDOCARQINSDATA2',pic:''},{av:'AV30DocArqInsData3',fld:'vDOCARQINSDATA3',pic:''},{av:'AV119DocID',fld:'vDOCID',pic:'',hsh:true},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV121Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV120DocID_Filtro',fld:'vDOCID_FILTRO',pic:''},{av:'AV21DocArqInsData_To1',fld:'vDOCARQINSDATA_TO1',pic:''},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV26DocArqInsData_To2',fld:'vDOCARQINSDATA_TO2',pic:''},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV31DocArqInsData_To3',fld:'vDOCARQINSDATA_TO3',pic:''},{av:'AV97TFDocArqConteudoNome',fld:'vTFDOCARQCONTEUDONOME',pic:''},{av:'AV98TFDocArqConteudoNome_Sel',fld:'vTFDOCARQCONTEUDONOME_SEL',pic:''},{av:'AV99TFDocArqConteudoExtensao',fld:'vTFDOCARQCONTEUDOEXTENSAO',pic:''},{av:'AV100TFDocArqConteudoExtensao_Sel',fld:'vTFDOCARQCONTEUDOEXTENSAO_SEL',pic:''},{av:'AV58TFDocArqInsDataHora',fld:'vTFDOCARQINSDATAHORA',pic:'99/99/9999 99:99:99.999'},{av:'AV59TFDocArqInsDataHora_To',fld:'vTFDOCARQINSDATAHORA_TO',pic:'99/99/9999 99:99:99.999'},{av:'AV101TFDocArqObservacao',fld:'vTFDOCARQOBSERVACAO',pic:''},{av:'AV102TFDocArqObservacao_Sel',fld:'vTFDOCARQOBSERVACAO_SEL',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV111IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV112IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'",",oparms:[{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV25DocArqInsData2',fld:'vDOCARQINSDATA2',pic:''},{av:'AV26DocArqInsData_To2',fld:'vDOCARQINSDATA_TO2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV30DocArqInsData3',fld:'vDOCARQINSDATA3',pic:''},{av:'AV31DocArqInsData_To3',fld:'vDOCARQINSDATA_TO3',pic:''},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV20DocArqInsData1',fld:'vDOCARQINSDATA1',pic:''},{av:'AV21DocArqInsData_To1',fld:'vDOCARQINSDATA_TO1',pic:''},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'tblTablemergeddynamicfiltersdocarqinsdata2_Visible',ctrl:'TABLEMERGEDDYNAMICFILTERSDOCARQINSDATA2',prop:'Visible'},{av:'tblTablemergeddynamicfiltersdocarqinsdata3_Visible',ctrl:'TABLEMERGEDDYNAMICFILTERSDOCARQINSDATA3',prop:'Visible'},{av:'tblTablemergeddynamicfiltersdocarqinsdata1_Visible',ctrl:'TABLEMERGEDDYNAMICFILTERSDOCARQINSDATA1',prop:'Visible'},{av:'cellDocarqinsdata_range_cell2_Class',ctrl:'DOCARQINSDATA_RANGE_CELL2',prop:'Class'},{av:'cellDocarqinsdata_range_cell3_Class',ctrl:'DOCARQINSDATA_RANGE_CELL3',prop:'Class'},{av:'cellDocarqinsdata_range_cell1_Class',ctrl:'DOCARQINSDATA_RANGE_CELL1',prop:'Class'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV107GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV108GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV109GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV111IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV112IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK","{handler:'E295K2',iparms:[{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK",",oparms:[{av:'tblTablemergeddynamicfiltersdocarqinsdata3_Visible',ctrl:'TABLEMERGEDDYNAMICFILTERSDOCARQINSDATA3',prop:'Visible'},{av:'cmbavDynamicfiltersoperator3'},{av:'cellDocarqinsdata_range_cell3_Class',ctrl:'DOCARQINSDATA_RANGE_CELL3',prop:'Class'},{av:'AV30DocArqInsData3',fld:'vDOCARQINSDATA3',pic:''}]}");
         setEventMetadata("DOCARQINSDATA_RANGEPICKER3.DATERANGECHANGED","{handler:'E185K2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV20DocArqInsData1',fld:'vDOCARQINSDATA1',pic:''},{av:'AV25DocArqInsData2',fld:'vDOCARQINSDATA2',pic:''},{av:'AV30DocArqInsData3',fld:'vDOCARQINSDATA3',pic:''},{av:'AV119DocID',fld:'vDOCID',pic:'',hsh:true},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV121Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV120DocID_Filtro',fld:'vDOCID_FILTRO',pic:''},{av:'AV21DocArqInsData_To1',fld:'vDOCARQINSDATA_TO1',pic:''},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV26DocArqInsData_To2',fld:'vDOCARQINSDATA_TO2',pic:''},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV31DocArqInsData_To3',fld:'vDOCARQINSDATA_TO3',pic:''},{av:'AV97TFDocArqConteudoNome',fld:'vTFDOCARQCONTEUDONOME',pic:''},{av:'AV98TFDocArqConteudoNome_Sel',fld:'vTFDOCARQCONTEUDONOME_SEL',pic:''},{av:'AV99TFDocArqConteudoExtensao',fld:'vTFDOCARQCONTEUDOEXTENSAO',pic:''},{av:'AV100TFDocArqConteudoExtensao_Sel',fld:'vTFDOCARQCONTEUDOEXTENSAO_SEL',pic:''},{av:'AV58TFDocArqInsDataHora',fld:'vTFDOCARQINSDATAHORA',pic:'99/99/9999 99:99:99.999'},{av:'AV59TFDocArqInsDataHora_To',fld:'vTFDOCARQINSDATAHORA_TO',pic:'99/99/9999 99:99:99.999'},{av:'AV101TFDocArqObservacao',fld:'vTFDOCARQOBSERVACAO',pic:''},{av:'AV102TFDocArqObservacao_Sel',fld:'vTFDOCARQOBSERVACAO_SEL',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV111IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV112IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true}]");
         setEventMetadata("DOCARQINSDATA_RANGEPICKER3.DATERANGECHANGED",",oparms:[{av:'AV30DocArqInsData3',fld:'vDOCARQINSDATA3',pic:''},{av:'AV31DocArqInsData_To3',fld:'vDOCARQINSDATA_TO3',pic:''},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV107GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV108GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV109GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV111IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV112IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSOPERATOR3.CLICK","{handler:'E305K2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV20DocArqInsData1',fld:'vDOCARQINSDATA1',pic:''},{av:'AV25DocArqInsData2',fld:'vDOCARQINSDATA2',pic:''},{av:'AV30DocArqInsData3',fld:'vDOCARQINSDATA3',pic:''},{av:'AV119DocID',fld:'vDOCID',pic:'',hsh:true},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV121Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV120DocID_Filtro',fld:'vDOCID_FILTRO',pic:''},{av:'AV21DocArqInsData_To1',fld:'vDOCARQINSDATA_TO1',pic:''},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV26DocArqInsData_To2',fld:'vDOCARQINSDATA_TO2',pic:''},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV31DocArqInsData_To3',fld:'vDOCARQINSDATA_TO3',pic:''},{av:'AV97TFDocArqConteudoNome',fld:'vTFDOCARQCONTEUDONOME',pic:''},{av:'AV98TFDocArqConteudoNome_Sel',fld:'vTFDOCARQCONTEUDONOME_SEL',pic:''},{av:'AV99TFDocArqConteudoExtensao',fld:'vTFDOCARQCONTEUDOEXTENSAO',pic:''},{av:'AV100TFDocArqConteudoExtensao_Sel',fld:'vTFDOCARQCONTEUDOEXTENSAO_SEL',pic:''},{av:'AV58TFDocArqInsDataHora',fld:'vTFDOCARQINSDATAHORA',pic:'99/99/9999 99:99:99.999'},{av:'AV59TFDocArqInsDataHora_To',fld:'vTFDOCARQINSDATAHORA_TO',pic:'99/99/9999 99:99:99.999'},{av:'AV101TFDocArqObservacao',fld:'vTFDOCARQOBSERVACAO',pic:''},{av:'AV102TFDocArqObservacao_Sel',fld:'vTFDOCARQOBSERVACAO_SEL',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV111IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV112IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true}]");
         setEventMetadata("VDYNAMICFILTERSOPERATOR3.CLICK",",oparms:[{av:'AV30DocArqInsData3',fld:'vDOCARQINSDATA3',pic:''},{av:'AV31DocArqInsData_To3',fld:'vDOCARQINSDATA_TO3',pic:''},{av:'cellDocarqinsdata_range_cell3_Class',ctrl:'DOCARQINSDATA_RANGE_CELL3',prop:'Class'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV107GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV108GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV109GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV111IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV112IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","{handler:'E115K2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV20DocArqInsData1',fld:'vDOCARQINSDATA1',pic:''},{av:'AV25DocArqInsData2',fld:'vDOCARQINSDATA2',pic:''},{av:'AV30DocArqInsData3',fld:'vDOCARQINSDATA3',pic:''},{av:'AV119DocID',fld:'vDOCID',pic:'',hsh:true},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV121Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV120DocID_Filtro',fld:'vDOCID_FILTRO',pic:''},{av:'AV21DocArqInsData_To1',fld:'vDOCARQINSDATA_TO1',pic:''},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV26DocArqInsData_To2',fld:'vDOCARQINSDATA_TO2',pic:''},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV31DocArqInsData_To3',fld:'vDOCARQINSDATA_TO3',pic:''},{av:'AV97TFDocArqConteudoNome',fld:'vTFDOCARQCONTEUDONOME',pic:''},{av:'AV98TFDocArqConteudoNome_Sel',fld:'vTFDOCARQCONTEUDONOME_SEL',pic:''},{av:'AV99TFDocArqConteudoExtensao',fld:'vTFDOCARQCONTEUDOEXTENSAO',pic:''},{av:'AV100TFDocArqConteudoExtensao_Sel',fld:'vTFDOCARQCONTEUDOEXTENSAO_SEL',pic:''},{av:'AV58TFDocArqInsDataHora',fld:'vTFDOCARQINSDATAHORA',pic:'99/99/9999 99:99:99.999'},{av:'AV59TFDocArqInsDataHora_To',fld:'vTFDOCARQINSDATAHORA_TO',pic:'99/99/9999 99:99:99.999'},{av:'AV101TFDocArqObservacao',fld:'vTFDOCARQOBSERVACAO',pic:''},{av:'AV102TFDocArqObservacao_Sel',fld:'vTFDOCARQOBSERVACAO_SEL',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV111IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV112IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true},{av:'Ddo_managefilters_Activeeventkey',ctrl:'DDO_MANAGEFILTERS',prop:'ActiveEventKey'},{av:'AV60DDO_DocArqInsDataHoraAuxDate',fld:'vDDO_DOCARQINSDATAHORAAUXDATE',pic:''},{av:'AV61DDO_DocArqInsDataHoraAuxDateTo',fld:'vDDO_DOCARQINSDATAHORAAUXDATETO',pic:''}]");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",",oparms:[{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV120DocID_Filtro',fld:'vDOCID_FILTRO',pic:''},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV97TFDocArqConteudoNome',fld:'vTFDOCARQCONTEUDONOME',pic:''},{av:'AV98TFDocArqConteudoNome_Sel',fld:'vTFDOCARQCONTEUDONOME_SEL',pic:''},{av:'AV99TFDocArqConteudoExtensao',fld:'vTFDOCARQCONTEUDOEXTENSAO',pic:''},{av:'AV100TFDocArqConteudoExtensao_Sel',fld:'vTFDOCARQCONTEUDOEXTENSAO_SEL',pic:''},{av:'AV58TFDocArqInsDataHora',fld:'vTFDOCARQINSDATAHORA',pic:'99/99/9999 99:99:99.999'},{av:'AV59TFDocArqInsDataHora_To',fld:'vTFDOCARQINSDATAHORA_TO',pic:'99/99/9999 99:99:99.999'},{av:'AV101TFDocArqObservacao',fld:'vTFDOCARQOBSERVACAO',pic:''},{av:'AV102TFDocArqObservacao_Sel',fld:'vTFDOCARQOBSERVACAO_SEL',pic:''},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV20DocArqInsData1',fld:'vDOCARQINSDATA1',pic:''},{av:'AV21DocArqInsData_To1',fld:'vDOCARQINSDATA_TO1',pic:''},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'AV60DDO_DocArqInsDataHoraAuxDate',fld:'vDDO_DOCARQINSDATAHORAAUXDATE',pic:''},{av:'AV61DDO_DocArqInsDataHoraAuxDateTo',fld:'vDDO_DOCARQINSDATAHORAAUXDATETO',pic:''},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV25DocArqInsData2',fld:'vDOCARQINSDATA2',pic:''},{av:'AV26DocArqInsData_To2',fld:'vDOCARQINSDATA_TO2',pic:''},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV30DocArqInsData3',fld:'vDOCARQINSDATA3',pic:''},{av:'AV31DocArqInsData_To3',fld:'vDOCARQINSDATA_TO3',pic:''},{av:'tblTablemergeddynamicfiltersdocarqinsdata1_Visible',ctrl:'TABLEMERGEDDYNAMICFILTERSDOCARQINSDATA1',prop:'Visible'},{av:'tblTablemergeddynamicfiltersdocarqinsdata2_Visible',ctrl:'TABLEMERGEDDYNAMICFILTERSDOCARQINSDATA2',prop:'Visible'},{av:'tblTablemergeddynamicfiltersdocarqinsdata3_Visible',ctrl:'TABLEMERGEDDYNAMICFILTERSDOCARQINSDATA3',prop:'Visible'},{av:'cellDocarqinsdata_range_cell1_Class',ctrl:'DOCARQINSDATA_RANGE_CELL1',prop:'Class'},{av:'cellDocarqinsdata_range_cell2_Class',ctrl:'DOCARQINSDATA_RANGE_CELL2',prop:'Class'},{av:'cellDocarqinsdata_range_cell3_Class',ctrl:'DOCARQINSDATA_RANGE_CELL3',prop:'Class'},{av:'AV107GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV108GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV109GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV111IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV112IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VGRIDACTIONS.CLICK","{handler:'E345K2',iparms:[{av:'cmbavGridactions'},{av:'AV110GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9'},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavDynamicfiltersselector2'},{av:'AV23DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV24DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavDynamicfiltersselector3'},{av:'AV28DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV29DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV20DocArqInsData1',fld:'vDOCARQINSDATA1',pic:''},{av:'AV25DocArqInsData2',fld:'vDOCARQINSDATA2',pic:''},{av:'AV30DocArqInsData3',fld:'vDOCARQINSDATA3',pic:''},{av:'AV119DocID',fld:'vDOCID',pic:'',hsh:true},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV121Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV120DocID_Filtro',fld:'vDOCID_FILTRO',pic:''},{av:'AV21DocArqInsData_To1',fld:'vDOCARQINSDATA_TO1',pic:''},{av:'AV22DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV26DocArqInsData_To2',fld:'vDOCARQINSDATA_TO2',pic:''},{av:'AV27DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV31DocArqInsData_To3',fld:'vDOCARQINSDATA_TO3',pic:''},{av:'AV97TFDocArqConteudoNome',fld:'vTFDOCARQCONTEUDONOME',pic:''},{av:'AV98TFDocArqConteudoNome_Sel',fld:'vTFDOCARQCONTEUDONOME_SEL',pic:''},{av:'AV99TFDocArqConteudoExtensao',fld:'vTFDOCARQCONTEUDOEXTENSAO',pic:''},{av:'AV100TFDocArqConteudoExtensao_Sel',fld:'vTFDOCARQCONTEUDOEXTENSAO_SEL',pic:''},{av:'AV58TFDocArqInsDataHora',fld:'vTFDOCARQINSDATAHORA',pic:'99/99/9999 99:99:99.999'},{av:'AV59TFDocArqInsDataHora_To',fld:'vTFDOCARQINSDATAHORA_TO',pic:'99/99/9999 99:99:99.999'},{av:'AV101TFDocArqObservacao',fld:'vTFDOCARQOBSERVACAO',pic:''},{av:'AV102TFDocArqObservacao_Sel',fld:'vTFDOCARQOBSERVACAO_SEL',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV33DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV32DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV111IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV112IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'Gx_date',fld:'vTODAY',pic:'',hsh:true},{av:'A289DocID',fld:'DOCID',pic:'',hsh:true},{av:'A307DocArqSeq',fld:'DOCARQSEQ',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("VGRIDACTIONS.CLICK",",oparms:[{av:'cmbavGridactions'},{av:'AV110GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV107GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV108GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV109GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV111IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV112IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED","{handler:'E145K2',iparms:[{av:'Ddo_agexport_Activeeventkey',ctrl:'DDO_AGEXPORT',prop:'ActiveEventKey'}]");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED",",oparms:[]}");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT","{handler:'E155K2',iparms:[]");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT",",oparms:[{ctrl:'WWPAUX_WC'}]}");
         setEventMetadata("VALIDV_DOCID_FILTRO","{handler:'Validv_Docid_filtro',iparms:[]");
         setEventMetadata("VALIDV_DOCID_FILTRO",",oparms:[]}");
         setEventMetadata("VALIDV_DOCID","{handler:'Validv_Docid',iparms:[]");
         setEventMetadata("VALIDV_DOCID",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Docarqobservacao',iparms:[]");
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
         wcpOAV119DocID = Guid.Empty;
         Gridpaginationbar_Selectedpage = "";
         Ddo_grid_Activeeventkey = "";
         Ddo_grid_Selectedvalue_get = "";
         Ddo_grid_Selectedcolumn = "";
         Ddo_grid_Filteredtext_get = "";
         Ddo_grid_Filteredtextto_get = "";
         Ddo_managefilters_Activeeventkey = "";
         Ddo_agexport_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV17FilterFullText = "";
         AV18DynamicFiltersSelector1 = "";
         AV23DynamicFiltersSelector2 = "";
         AV28DynamicFiltersSelector3 = "";
         AV20DocArqInsData1 = DateTime.MinValue;
         AV25DocArqInsData2 = DateTime.MinValue;
         AV30DocArqInsData3 = DateTime.MinValue;
         AV121Pgmname = "";
         AV120DocID_Filtro = Guid.Empty;
         AV21DocArqInsData_To1 = DateTime.MinValue;
         AV26DocArqInsData_To2 = DateTime.MinValue;
         AV31DocArqInsData_To3 = DateTime.MinValue;
         AV97TFDocArqConteudoNome = "";
         AV98TFDocArqConteudoNome_Sel = "";
         AV99TFDocArqConteudoExtensao = "";
         AV100TFDocArqConteudoExtensao_Sel = "";
         AV58TFDocArqInsDataHora = (DateTime)(DateTime.MinValue);
         AV59TFDocArqInsDataHora_To = (DateTime)(DateTime.MinValue);
         AV101TFDocArqObservacao = "";
         AV102TFDocArqObservacao_Sel = "";
         AV11GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         Gx_date = DateTime.MinValue;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV41ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV109GridAppliedFilters = "";
         AV113AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV103DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV60DDO_DocArqInsDataHoraAuxDate = DateTime.MinValue;
         AV61DDO_DocArqInsDataHoraAuxDateTo = DateTime.MinValue;
         Ddo_agexport_Caption = "";
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Filteredtextto_set = "";
         Ddo_grid_Selectedvalue_set = "";
         Ddo_grid_Gamoauthtoken = "";
         Ddo_grid_Sortedstatus = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtnagexport_Jsonclick = "";
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
         ucDocarqinsdata_rangepicker1 = new GXUserControl();
         ucDocarqinsdata_rangepicker2 = new GXUserControl();
         ucDocarqinsdata_rangepicker3 = new GXUserControl();
         lblJsdynamicfilters_Jsonclick = "";
         ucDdo_grid = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         WebComp_Wwpaux_wc_Component = "";
         OldWwpaux_wc = "";
         AV62DDO_DocArqInsDataHoraAuxDateText = "";
         ucTfdocarqinsdatahora_rangepicker = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A289DocID = Guid.Empty;
         A322DocArqConteudoNome = "";
         A323DocArqConteudoExtensao = "";
         A310DocArqInsDataHora = (DateTime)(DateTime.MinValue);
         A324DocArqObservacao = "";
         GXDecQS = "";
         scmdbuf = "";
         lV123Core_documentoarquivowwds_2_filterfulltext = "";
         lV138Core_documentoarquivowwds_17_tfdocarqconteudonome = "";
         lV140Core_documentoarquivowwds_19_tfdocarqconteudoextensao = "";
         lV144Core_documentoarquivowwds_23_tfdocarqobservacao = "";
         AV123Core_documentoarquivowwds_2_filterfulltext = "";
         AV124Core_documentoarquivowwds_3_dynamicfiltersselector1 = "";
         AV126Core_documentoarquivowwds_5_docarqinsdata1 = DateTime.MinValue;
         AV127Core_documentoarquivowwds_6_docarqinsdata_to1 = DateTime.MinValue;
         AV129Core_documentoarquivowwds_8_dynamicfiltersselector2 = "";
         AV131Core_documentoarquivowwds_10_docarqinsdata2 = DateTime.MinValue;
         AV132Core_documentoarquivowwds_11_docarqinsdata_to2 = DateTime.MinValue;
         AV134Core_documentoarquivowwds_13_dynamicfiltersselector3 = "";
         AV136Core_documentoarquivowwds_15_docarqinsdata3 = DateTime.MinValue;
         AV137Core_documentoarquivowwds_16_docarqinsdata_to3 = DateTime.MinValue;
         AV139Core_documentoarquivowwds_18_tfdocarqconteudonome_sel = "";
         AV138Core_documentoarquivowwds_17_tfdocarqconteudonome = "";
         AV141Core_documentoarquivowwds_20_tfdocarqconteudoextensao_sel = "";
         AV140Core_documentoarquivowwds_19_tfdocarqconteudoextensao = "";
         AV142Core_documentoarquivowwds_21_tfdocarqinsdatahora = (DateTime)(DateTime.MinValue);
         AV143Core_documentoarquivowwds_22_tfdocarqinsdatahora_to = (DateTime)(DateTime.MinValue);
         AV145Core_documentoarquivowwds_24_tfdocarqobservacao_sel = "";
         AV144Core_documentoarquivowwds_23_tfdocarqobservacao = "";
         A308DocArqInsData = DateTime.MinValue;
         H005K2_A308DocArqInsData = new DateTime[] {DateTime.MinValue} ;
         H005K2_A324DocArqObservacao = new string[] {""} ;
         H005K2_n324DocArqObservacao = new bool[] {false} ;
         H005K2_A310DocArqInsDataHora = new DateTime[] {DateTime.MinValue} ;
         H005K2_A323DocArqConteudoExtensao = new string[] {""} ;
         H005K2_A322DocArqConteudoNome = new string[] {""} ;
         H005K2_A307DocArqSeq = new short[1] ;
         H005K2_A289DocID = new Guid[] {Guid.Empty} ;
         AV122Core_documentoarquivowwds_1_docid_filtro = Guid.Empty;
         H005K3_AGRID_nRecordCount = new long[1] ;
         AV116DocArqInsData_RangeText1 = "";
         AV117DocArqInsData_RangeText2 = "";
         AV118DocArqInsData_RangeText3 = "";
         AV8HTTPRequest = new GxHttpRequest( context);
         imgAdddynamicfilters1_Jsonclick = "";
         imgRemovedynamicfilters1_Jsonclick = "";
         imgAdddynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters3_Jsonclick = "";
         AV114AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV104GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV105GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GridRow = new GXWebRow();
         AV42ManageFiltersXml = "";
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV40Session = context.GetSession();
         AV12GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char6 = "";
         GXt_char5 = "";
         GXt_char2 = "";
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
         GXCCtl = "";
         ROClassString = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.documentoarquivoww__default(),
            new Object[][] {
                new Object[] {
               H005K2_A308DocArqInsData, H005K2_A324DocArqObservacao, H005K2_n324DocArqObservacao, H005K2_A310DocArqInsDataHora, H005K2_A323DocArqConteudoExtensao, H005K2_A322DocArqConteudoNome, H005K2_A307DocArqSeq, H005K2_A289DocID
               }
               , new Object[] {
               H005K3_AGRID_nRecordCount
               }
            }
         );
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         Gx_date = DateTimeUtil.Today( context);
         AV121Pgmname = "core.DocumentoArquivoWW";
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
         AV121Pgmname = "core.DocumentoArquivoWW";
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
      private short AV110GridActions ;
      private short A307DocArqSeq ;
      private short nCmpId ;
      private short nDonePA ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short AV125Core_documentoarquivowwds_4_dynamicfiltersoperator1 ;
      private short AV130Core_documentoarquivowwds_9_dynamicfiltersoperator2 ;
      private short AV135Core_documentoarquivowwds_14_dynamicfiltersoperator3 ;
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
      private int nRC_GXsfl_120 ;
      private int nGXsfl_120_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int edtavDocid_filtro_Enabled ;
      private int bttBtnsubscriptions_Visible ;
      private int edtavDocid_Visible ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int AV106PageToGo ;
      private int imgAdddynamicfilters1_Visible ;
      private int imgRemovedynamicfilters1_Visible ;
      private int imgAdddynamicfilters2_Visible ;
      private int imgRemovedynamicfilters2_Visible ;
      private int tblTablemergeddynamicfiltersdocarqinsdata1_Visible ;
      private int tblTablemergeddynamicfiltersdocarqinsdata2_Visible ;
      private int tblTablemergeddynamicfiltersdocarqinsdata3_Visible ;
      private int AV147GXV1 ;
      private int edtavDocarqinsdata_rangetext3_Enabled ;
      private int edtavDocarqinsdata_rangetext2_Enabled ;
      private int edtavDocarqinsdata_rangetext1_Enabled ;
      private int edtavFilterfulltext_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV107GridCurrentPage ;
      private long AV108GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_managefilters_Activeeventkey ;
      private string Ddo_agexport_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_120_idx="0001" ;
      private string AV121Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
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
      private string Ddo_grid_Sortedstatus ;
      private string Ddo_grid_Includefilter ;
      private string Ddo_grid_Filtertype ;
      private string Ddo_grid_Filterisrange ;
      private string Ddo_grid_Includedatalist ;
      private string Ddo_grid_Datalisttype ;
      private string Ddo_grid_Datalistproc ;
      private string Grid_empowerer_Gridinternalname ;
      private string Grid_empowerer_Fixedcolumns ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string edtavDocid_filtro_Internalname ;
      private string TempTags ;
      private string edtavDocid_filtro_Jsonclick ;
      private string divTableheader_Internalname ;
      private string divTableheadercontent_Internalname ;
      private string divTableactions_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtnagexport_Internalname ;
      private string bttBtnagexport_Jsonclick ;
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
      private string Docarqinsdata_rangepicker1_Internalname ;
      private string Docarqinsdata_rangepicker2_Internalname ;
      private string Docarqinsdata_rangepicker3_Internalname ;
      private string lblJsdynamicfilters_Internalname ;
      private string lblJsdynamicfilters_Caption ;
      private string lblJsdynamicfilters_Jsonclick ;
      private string Ddo_grid_Internalname ;
      private string edtavDocid_Internalname ;
      private string edtavDocid_Jsonclick ;
      private string Grid_empowerer_Internalname ;
      private string divDiv_wwpauxwc_Internalname ;
      private string WebComp_Wwpaux_wc_Component ;
      private string OldWwpaux_wc ;
      private string divDdo_docarqinsdatahoraauxdates_Internalname ;
      private string edtavDdo_docarqinsdatahoraauxdatetext_Internalname ;
      private string edtavDdo_docarqinsdatahoraauxdatetext_Jsonclick ;
      private string Tfdocarqinsdatahora_rangepicker_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string cmbavGridactions_Internalname ;
      private string edtDocID_Internalname ;
      private string edtDocArqSeq_Internalname ;
      private string edtDocArqConteudoNome_Internalname ;
      private string edtDocArqConteudoExtensao_Internalname ;
      private string edtDocArqInsDataHora_Internalname ;
      private string edtDocArqObservacao_Internalname ;
      private string GXDecQS ;
      private string cmbavDynamicfiltersoperator1_Internalname ;
      private string cmbavDynamicfiltersoperator2_Internalname ;
      private string cmbavDynamicfiltersoperator3_Internalname ;
      private string scmdbuf ;
      private string edtavFilterfulltext_Internalname ;
      private string edtavDocarqinsdata_rangetext1_Internalname ;
      private string edtavDocarqinsdata_rangetext2_Internalname ;
      private string edtavDocarqinsdata_rangetext3_Internalname ;
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
      private string tblTablemergeddynamicfiltersdocarqinsdata1_Internalname ;
      private string cellDocarqinsdata_range_cell1_Class ;
      private string cellDocarqinsdata_range_cell1_Internalname ;
      private string tblTablemergeddynamicfiltersdocarqinsdata2_Internalname ;
      private string cellDocarqinsdata_range_cell2_Class ;
      private string cellDocarqinsdata_range_cell2_Internalname ;
      private string tblTablemergeddynamicfiltersdocarqinsdata3_Internalname ;
      private string cellDocarqinsdata_range_cell3_Class ;
      private string cellDocarqinsdata_range_cell3_Internalname ;
      private string GXt_char6 ;
      private string GXt_char5 ;
      private string GXt_char2 ;
      private string tblTablemergeddynamicfilters3_Internalname ;
      private string cmbavDynamicfiltersoperator3_Jsonclick ;
      private string cellFilter_docarqinsdata3_cell_Internalname ;
      private string cellDynamicfilters_removefilter3_cell_Internalname ;
      private string imgRemovedynamicfilters3_gximage ;
      private string sImgUrl ;
      private string edtavDocarqinsdata_rangetext3_Jsonclick ;
      private string tblTablemergeddynamicfilters2_Internalname ;
      private string cmbavDynamicfiltersoperator2_Jsonclick ;
      private string cellFilter_docarqinsdata2_cell_Internalname ;
      private string cellDynamicfilters_addfilter2_cell_Internalname ;
      private string imgAdddynamicfilters2_gximage ;
      private string cellDynamicfilters_removefilter2_cell_Internalname ;
      private string imgRemovedynamicfilters2_gximage ;
      private string edtavDocarqinsdata_rangetext2_Jsonclick ;
      private string tblTablemergeddynamicfilters1_Internalname ;
      private string cmbavDynamicfiltersoperator1_Jsonclick ;
      private string cellFilter_docarqinsdata1_cell_Internalname ;
      private string cellDynamicfilters_addfilter1_cell_Internalname ;
      private string imgAdddynamicfilters1_gximage ;
      private string cellDynamicfilters_removefilter1_cell_Internalname ;
      private string imgRemovedynamicfilters1_gximage ;
      private string edtavDocarqinsdata_rangetext1_Jsonclick ;
      private string tblTablerightheader_Internalname ;
      private string Ddo_managefilters_Caption ;
      private string Ddo_managefilters_Internalname ;
      private string tblTablefilters_Internalname ;
      private string edtavFilterfulltext_Jsonclick ;
      private string sGXsfl_120_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string GXCCtl ;
      private string cmbavGridactions_Jsonclick ;
      private string ROClassString ;
      private string edtDocID_Jsonclick ;
      private string edtDocArqSeq_Jsonclick ;
      private string edtDocArqConteudoNome_Jsonclick ;
      private string edtDocArqConteudoExtensao_Jsonclick ;
      private string edtDocArqInsDataHora_Jsonclick ;
      private string edtDocArqObservacao_Jsonclick ;
      private string subGrid_Header ;
      private DateTime AV58TFDocArqInsDataHora ;
      private DateTime AV59TFDocArqInsDataHora_To ;
      private DateTime A310DocArqInsDataHora ;
      private DateTime AV142Core_documentoarquivowwds_21_tfdocarqinsdatahora ;
      private DateTime AV143Core_documentoarquivowwds_22_tfdocarqinsdatahora_to ;
      private DateTime AV20DocArqInsData1 ;
      private DateTime AV25DocArqInsData2 ;
      private DateTime AV30DocArqInsData3 ;
      private DateTime AV21DocArqInsData_To1 ;
      private DateTime AV26DocArqInsData_To2 ;
      private DateTime AV31DocArqInsData_To3 ;
      private DateTime Gx_date ;
      private DateTime AV60DDO_DocArqInsDataHoraAuxDate ;
      private DateTime AV61DDO_DocArqInsDataHoraAuxDateTo ;
      private DateTime AV126Core_documentoarquivowwds_5_docarqinsdata1 ;
      private DateTime AV127Core_documentoarquivowwds_6_docarqinsdata_to1 ;
      private DateTime AV131Core_documentoarquivowwds_10_docarqinsdata2 ;
      private DateTime AV132Core_documentoarquivowwds_11_docarqinsdata_to2 ;
      private DateTime AV136Core_documentoarquivowwds_15_docarqinsdata3 ;
      private DateTime AV137Core_documentoarquivowwds_16_docarqinsdata_to3 ;
      private DateTime A308DocArqInsData ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV22DynamicFiltersEnabled2 ;
      private bool AV27DynamicFiltersEnabled3 ;
      private bool AV15OrderedDsc ;
      private bool AV33DynamicFiltersIgnoreFirst ;
      private bool AV32DynamicFiltersRemoving ;
      private bool AV111IsAuthorized_Update ;
      private bool AV112IsAuthorized_Delete ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool wbLoad ;
      private bool bGXsfl_120_Refreshing=false ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n324DocArqObservacao ;
      private bool gxdyncontrolsrefreshing ;
      private bool AV128Core_documentoarquivowwds_7_dynamicfiltersenabled2 ;
      private bool AV133Core_documentoarquivowwds_12_dynamicfiltersenabled3 ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool bDynCreated_Wwpaux_wc ;
      private bool GXt_boolean3 ;
      private string AV42ManageFiltersXml ;
      private string AV17FilterFullText ;
      private string AV18DynamicFiltersSelector1 ;
      private string AV23DynamicFiltersSelector2 ;
      private string AV28DynamicFiltersSelector3 ;
      private string AV97TFDocArqConteudoNome ;
      private string AV98TFDocArqConteudoNome_Sel ;
      private string AV99TFDocArqConteudoExtensao ;
      private string AV100TFDocArqConteudoExtensao_Sel ;
      private string AV101TFDocArqObservacao ;
      private string AV102TFDocArqObservacao_Sel ;
      private string AV109GridAppliedFilters ;
      private string AV62DDO_DocArqInsDataHoraAuxDateText ;
      private string A322DocArqConteudoNome ;
      private string A323DocArqConteudoExtensao ;
      private string A324DocArqObservacao ;
      private string lV123Core_documentoarquivowwds_2_filterfulltext ;
      private string lV138Core_documentoarquivowwds_17_tfdocarqconteudonome ;
      private string lV140Core_documentoarquivowwds_19_tfdocarqconteudoextensao ;
      private string lV144Core_documentoarquivowwds_23_tfdocarqobservacao ;
      private string AV123Core_documentoarquivowwds_2_filterfulltext ;
      private string AV124Core_documentoarquivowwds_3_dynamicfiltersselector1 ;
      private string AV129Core_documentoarquivowwds_8_dynamicfiltersselector2 ;
      private string AV134Core_documentoarquivowwds_13_dynamicfiltersselector3 ;
      private string AV139Core_documentoarquivowwds_18_tfdocarqconteudonome_sel ;
      private string AV138Core_documentoarquivowwds_17_tfdocarqconteudonome ;
      private string AV141Core_documentoarquivowwds_20_tfdocarqconteudoextensao_sel ;
      private string AV140Core_documentoarquivowwds_19_tfdocarqconteudoextensao ;
      private string AV145Core_documentoarquivowwds_24_tfdocarqobservacao_sel ;
      private string AV144Core_documentoarquivowwds_23_tfdocarqobservacao ;
      private string AV116DocArqInsData_RangeText1 ;
      private string AV117DocArqInsData_RangeText2 ;
      private string AV118DocArqInsData_RangeText3 ;
      private string AV34ExcelFilename ;
      private string AV35ErrorMessage ;
      private Guid AV119DocID ;
      private Guid wcpOAV119DocID ;
      private Guid AV120DocID_Filtro ;
      private Guid A289DocID ;
      private Guid AV122Core_documentoarquivowwds_1_docid_filtro ;
      private IGxSession AV40Session ;
      private GXWebComponent WebComp_Wwpaux_wc ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_agexport ;
      private GXUserControl ucDdc_subscriptions ;
      private GXUserControl ucDocarqinsdata_rangepicker1 ;
      private GXUserControl ucDocarqinsdata_rangepicker2 ;
      private GXUserControl ucDocarqinsdata_rangepicker3 ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucTfdocarqinsdatahora_rangepicker ;
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
      private IDataStoreProvider pr_default ;
      private DateTime[] H005K2_A308DocArqInsData ;
      private string[] H005K2_A324DocArqObservacao ;
      private bool[] H005K2_n324DocArqObservacao ;
      private DateTime[] H005K2_A310DocArqInsDataHora ;
      private string[] H005K2_A323DocArqConteudoExtensao ;
      private string[] H005K2_A322DocArqConteudoNome ;
      private short[] H005K2_A307DocArqSeq ;
      private Guid[] H005K2_A289DocID ;
      private long[] H005K3_AGRID_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV8HTTPRequest ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV41ManageFiltersData ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV113AGExportData ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV105GAMErrors ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item AV114AGExportDataItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV103DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV104GAMSession ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV12GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV13GridStateDynamicFilter ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
   }

   public class documentoarquivoww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H005K2( IGxContext context ,
                                             string AV123Core_documentoarquivowwds_2_filterfulltext ,
                                             string AV124Core_documentoarquivowwds_3_dynamicfiltersselector1 ,
                                             short AV125Core_documentoarquivowwds_4_dynamicfiltersoperator1 ,
                                             DateTime AV126Core_documentoarquivowwds_5_docarqinsdata1 ,
                                             DateTime AV127Core_documentoarquivowwds_6_docarqinsdata_to1 ,
                                             bool AV128Core_documentoarquivowwds_7_dynamicfiltersenabled2 ,
                                             string AV129Core_documentoarquivowwds_8_dynamicfiltersselector2 ,
                                             short AV130Core_documentoarquivowwds_9_dynamicfiltersoperator2 ,
                                             DateTime AV131Core_documentoarquivowwds_10_docarqinsdata2 ,
                                             DateTime AV132Core_documentoarquivowwds_11_docarqinsdata_to2 ,
                                             bool AV133Core_documentoarquivowwds_12_dynamicfiltersenabled3 ,
                                             string AV134Core_documentoarquivowwds_13_dynamicfiltersselector3 ,
                                             short AV135Core_documentoarquivowwds_14_dynamicfiltersoperator3 ,
                                             DateTime AV136Core_documentoarquivowwds_15_docarqinsdata3 ,
                                             DateTime AV137Core_documentoarquivowwds_16_docarqinsdata_to3 ,
                                             string AV139Core_documentoarquivowwds_18_tfdocarqconteudonome_sel ,
                                             string AV138Core_documentoarquivowwds_17_tfdocarqconteudonome ,
                                             string AV141Core_documentoarquivowwds_20_tfdocarqconteudoextensao_sel ,
                                             string AV140Core_documentoarquivowwds_19_tfdocarqconteudoextensao ,
                                             DateTime AV142Core_documentoarquivowwds_21_tfdocarqinsdatahora ,
                                             DateTime AV143Core_documentoarquivowwds_22_tfdocarqinsdatahora_to ,
                                             string AV145Core_documentoarquivowwds_24_tfdocarqobservacao_sel ,
                                             string AV144Core_documentoarquivowwds_23_tfdocarqobservacao ,
                                             string A322DocArqConteudoNome ,
                                             string A323DocArqConteudoExtensao ,
                                             string A324DocArqObservacao ,
                                             DateTime A308DocArqInsData ,
                                             DateTime A310DocArqInsDataHora ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc ,
                                             Guid AV119DocID ,
                                             Guid A289DocID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[30];
         Object[] GXv_Object8 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " DocArqInsData, DocArqObservacao, DocArqInsDataHora, DocArqConteudoExtensao, DocArqConteudoNome, DocArqSeq, DocID";
         sFromString = " FROM tb_documento_arquivo";
         sOrderString = "";
         AddWhere(sWhereString, "(DocID = :AV119DocID)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Core_documentoarquivowwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( DocArqConteudoNome like '%' || :lV123Core_documentoarquivowwds_2_filterfulltext) or ( DocArqConteudoExtensao like '%' || :lV123Core_documentoarquivowwds_2_filterfulltext) or ( DocArqObservacao like '%' || :lV123Core_documentoarquivowwds_2_filterfulltext))");
         }
         else
         {
            GXv_int7[1] = 1;
            GXv_int7[2] = 1;
            GXv_int7[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV124Core_documentoarquivowwds_3_dynamicfiltersselector1, "DOCARQINSDATA") == 0 ) && ( AV125Core_documentoarquivowwds_4_dynamicfiltersoperator1 == 0 ) && ( ! (DateTime.MinValue==AV126Core_documentoarquivowwds_5_docarqinsdata1) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData < :AV126Core_documentoarquivowwds_5_docarqinsdata1)");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV124Core_documentoarquivowwds_3_dynamicfiltersselector1, "DOCARQINSDATA") == 0 ) && ( AV125Core_documentoarquivowwds_4_dynamicfiltersoperator1 == 1 ) && ( ! (DateTime.MinValue==AV126Core_documentoarquivowwds_5_docarqinsdata1) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData = :AV126Core_documentoarquivowwds_5_docarqinsdata1)");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV124Core_documentoarquivowwds_3_dynamicfiltersselector1, "DOCARQINSDATA") == 0 ) && ( AV125Core_documentoarquivowwds_4_dynamicfiltersoperator1 == 2 ) && ( ! (DateTime.MinValue==AV126Core_documentoarquivowwds_5_docarqinsdata1) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData > :AV126Core_documentoarquivowwds_5_docarqinsdata1)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV124Core_documentoarquivowwds_3_dynamicfiltersselector1, "DOCARQINSDATA") == 0 ) && ( AV125Core_documentoarquivowwds_4_dynamicfiltersoperator1 == 3 ) && ( ! (DateTime.MinValue==AV126Core_documentoarquivowwds_5_docarqinsdata1) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData >= :AV126Core_documentoarquivowwds_5_docarqinsdata1)");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV124Core_documentoarquivowwds_3_dynamicfiltersselector1, "DOCARQINSDATA") == 0 ) && ( AV125Core_documentoarquivowwds_4_dynamicfiltersoperator1 == 3 ) && ( ! (DateTime.MinValue==AV127Core_documentoarquivowwds_6_docarqinsdata_to1) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData <= :AV127Core_documentoarquivowwds_6_docarqinsdata_to1)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( AV128Core_documentoarquivowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV129Core_documentoarquivowwds_8_dynamicfiltersselector2, "DOCARQINSDATA") == 0 ) && ( AV130Core_documentoarquivowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! (DateTime.MinValue==AV131Core_documentoarquivowwds_10_docarqinsdata2) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData < :AV131Core_documentoarquivowwds_10_docarqinsdata2)");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( AV128Core_documentoarquivowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV129Core_documentoarquivowwds_8_dynamicfiltersselector2, "DOCARQINSDATA") == 0 ) && ( AV130Core_documentoarquivowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! (DateTime.MinValue==AV131Core_documentoarquivowwds_10_docarqinsdata2) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData = :AV131Core_documentoarquivowwds_10_docarqinsdata2)");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( AV128Core_documentoarquivowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV129Core_documentoarquivowwds_8_dynamicfiltersselector2, "DOCARQINSDATA") == 0 ) && ( AV130Core_documentoarquivowwds_9_dynamicfiltersoperator2 == 2 ) && ( ! (DateTime.MinValue==AV131Core_documentoarquivowwds_10_docarqinsdata2) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData > :AV131Core_documentoarquivowwds_10_docarqinsdata2)");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( AV128Core_documentoarquivowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV129Core_documentoarquivowwds_8_dynamicfiltersselector2, "DOCARQINSDATA") == 0 ) && ( AV130Core_documentoarquivowwds_9_dynamicfiltersoperator2 == 3 ) && ( ! (DateTime.MinValue==AV131Core_documentoarquivowwds_10_docarqinsdata2) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData >= :AV131Core_documentoarquivowwds_10_docarqinsdata2)");
         }
         else
         {
            GXv_int7[12] = 1;
         }
         if ( AV128Core_documentoarquivowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV129Core_documentoarquivowwds_8_dynamicfiltersselector2, "DOCARQINSDATA") == 0 ) && ( AV130Core_documentoarquivowwds_9_dynamicfiltersoperator2 == 3 ) && ( ! (DateTime.MinValue==AV132Core_documentoarquivowwds_11_docarqinsdata_to2) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData <= :AV132Core_documentoarquivowwds_11_docarqinsdata_to2)");
         }
         else
         {
            GXv_int7[13] = 1;
         }
         if ( AV133Core_documentoarquivowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV134Core_documentoarquivowwds_13_dynamicfiltersselector3, "DOCARQINSDATA") == 0 ) && ( AV135Core_documentoarquivowwds_14_dynamicfiltersoperator3 == 0 ) && ( ! (DateTime.MinValue==AV136Core_documentoarquivowwds_15_docarqinsdata3) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData < :AV136Core_documentoarquivowwds_15_docarqinsdata3)");
         }
         else
         {
            GXv_int7[14] = 1;
         }
         if ( AV133Core_documentoarquivowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV134Core_documentoarquivowwds_13_dynamicfiltersselector3, "DOCARQINSDATA") == 0 ) && ( AV135Core_documentoarquivowwds_14_dynamicfiltersoperator3 == 1 ) && ( ! (DateTime.MinValue==AV136Core_documentoarquivowwds_15_docarqinsdata3) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData = :AV136Core_documentoarquivowwds_15_docarqinsdata3)");
         }
         else
         {
            GXv_int7[15] = 1;
         }
         if ( AV133Core_documentoarquivowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV134Core_documentoarquivowwds_13_dynamicfiltersselector3, "DOCARQINSDATA") == 0 ) && ( AV135Core_documentoarquivowwds_14_dynamicfiltersoperator3 == 2 ) && ( ! (DateTime.MinValue==AV136Core_documentoarquivowwds_15_docarqinsdata3) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData > :AV136Core_documentoarquivowwds_15_docarqinsdata3)");
         }
         else
         {
            GXv_int7[16] = 1;
         }
         if ( AV133Core_documentoarquivowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV134Core_documentoarquivowwds_13_dynamicfiltersselector3, "DOCARQINSDATA") == 0 ) && ( AV135Core_documentoarquivowwds_14_dynamicfiltersoperator3 == 3 ) && ( ! (DateTime.MinValue==AV136Core_documentoarquivowwds_15_docarqinsdata3) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData >= :AV136Core_documentoarquivowwds_15_docarqinsdata3)");
         }
         else
         {
            GXv_int7[17] = 1;
         }
         if ( AV133Core_documentoarquivowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV134Core_documentoarquivowwds_13_dynamicfiltersselector3, "DOCARQINSDATA") == 0 ) && ( AV135Core_documentoarquivowwds_14_dynamicfiltersoperator3 == 3 ) && ( ! (DateTime.MinValue==AV137Core_documentoarquivowwds_16_docarqinsdata_to3) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData <= :AV137Core_documentoarquivowwds_16_docarqinsdata_to3)");
         }
         else
         {
            GXv_int7[18] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV139Core_documentoarquivowwds_18_tfdocarqconteudonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV138Core_documentoarquivowwds_17_tfdocarqconteudonome)) ) )
         {
            AddWhere(sWhereString, "(DocArqConteudoNome like :lV138Core_documentoarquivowwds_17_tfdocarqconteudonome)");
         }
         else
         {
            GXv_int7[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV139Core_documentoarquivowwds_18_tfdocarqconteudonome_sel)) && ! ( StringUtil.StrCmp(AV139Core_documentoarquivowwds_18_tfdocarqconteudonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(DocArqConteudoNome = ( :AV139Core_documentoarquivowwds_18_tfdocarqconteudonome_sel))");
         }
         else
         {
            GXv_int7[20] = 1;
         }
         if ( StringUtil.StrCmp(AV139Core_documentoarquivowwds_18_tfdocarqconteudonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from DocArqConteudoNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV141Core_documentoarquivowwds_20_tfdocarqconteudoextensao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV140Core_documentoarquivowwds_19_tfdocarqconteudoextensao)) ) )
         {
            AddWhere(sWhereString, "(DocArqConteudoExtensao like :lV140Core_documentoarquivowwds_19_tfdocarqconteudoextensao)");
         }
         else
         {
            GXv_int7[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV141Core_documentoarquivowwds_20_tfdocarqconteudoextensao_sel)) && ! ( StringUtil.StrCmp(AV141Core_documentoarquivowwds_20_tfdocarqconteudoextensao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(DocArqConteudoExtensao = ( :AV141Core_documentoarquivowwds_20_tfdocarqconteudoextensao_sel))");
         }
         else
         {
            GXv_int7[22] = 1;
         }
         if ( StringUtil.StrCmp(AV141Core_documentoarquivowwds_20_tfdocarqconteudoextensao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from DocArqConteudoExtensao))=0))");
         }
         if ( ! (DateTime.MinValue==AV142Core_documentoarquivowwds_21_tfdocarqinsdatahora) )
         {
            AddWhere(sWhereString, "(DocArqInsDataHora >= :AV142Core_documentoarquivowwds_21_tfdocarqinsdatahora)");
         }
         else
         {
            GXv_int7[23] = 1;
         }
         if ( ! (DateTime.MinValue==AV143Core_documentoarquivowwds_22_tfdocarqinsdatahora_to) )
         {
            AddWhere(sWhereString, "(DocArqInsDataHora <= :AV143Core_documentoarquivowwds_22_tfdocarqinsdatahora_to)");
         }
         else
         {
            GXv_int7[24] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV145Core_documentoarquivowwds_24_tfdocarqobservacao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV144Core_documentoarquivowwds_23_tfdocarqobservacao)) ) )
         {
            AddWhere(sWhereString, "(DocArqObservacao like :lV144Core_documentoarquivowwds_23_tfdocarqobservacao)");
         }
         else
         {
            GXv_int7[25] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV145Core_documentoarquivowwds_24_tfdocarqobservacao_sel)) && ! ( StringUtil.StrCmp(AV145Core_documentoarquivowwds_24_tfdocarqobservacao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(DocArqObservacao = ( :AV145Core_documentoarquivowwds_24_tfdocarqobservacao_sel))");
         }
         else
         {
            GXv_int7[26] = 1;
         }
         if ( StringUtil.StrCmp(AV145Core_documentoarquivowwds_24_tfdocarqobservacao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(DocArqObservacao IS NULL or (char_length(trim(trailing ' ' from DocArqObservacao))=0))");
         }
         if ( AV14OrderedBy == 1 )
         {
            sOrderString += " ORDER BY DocArqInsData, DocID, DocArqSeq";
         }
         else if ( ( AV14OrderedBy == 2 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY DocArqConteudoNome, DocID, DocArqSeq";
         }
         else if ( ( AV14OrderedBy == 2 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY DocArqConteudoNome DESC, DocID, DocArqSeq";
         }
         else if ( ( AV14OrderedBy == 3 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY DocArqConteudoExtensao, DocID, DocArqSeq";
         }
         else if ( ( AV14OrderedBy == 3 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY DocArqConteudoExtensao DESC, DocID, DocArqSeq";
         }
         else if ( ( AV14OrderedBy == 4 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY DocArqInsDataHora, DocID, DocArqSeq";
         }
         else if ( ( AV14OrderedBy == 4 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY DocArqInsDataHora DESC, DocID, DocArqSeq";
         }
         else if ( ( AV14OrderedBy == 5 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY DocArqObservacao, DocID, DocArqSeq";
         }
         else if ( ( AV14OrderedBy == 5 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY DocArqObservacao DESC, DocID, DocArqSeq";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY DocID, DocArqSeq";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      protected Object[] conditional_H005K3( IGxContext context ,
                                             string AV123Core_documentoarquivowwds_2_filterfulltext ,
                                             string AV124Core_documentoarquivowwds_3_dynamicfiltersselector1 ,
                                             short AV125Core_documentoarquivowwds_4_dynamicfiltersoperator1 ,
                                             DateTime AV126Core_documentoarquivowwds_5_docarqinsdata1 ,
                                             DateTime AV127Core_documentoarquivowwds_6_docarqinsdata_to1 ,
                                             bool AV128Core_documentoarquivowwds_7_dynamicfiltersenabled2 ,
                                             string AV129Core_documentoarquivowwds_8_dynamicfiltersselector2 ,
                                             short AV130Core_documentoarquivowwds_9_dynamicfiltersoperator2 ,
                                             DateTime AV131Core_documentoarquivowwds_10_docarqinsdata2 ,
                                             DateTime AV132Core_documentoarquivowwds_11_docarqinsdata_to2 ,
                                             bool AV133Core_documentoarquivowwds_12_dynamicfiltersenabled3 ,
                                             string AV134Core_documentoarquivowwds_13_dynamicfiltersselector3 ,
                                             short AV135Core_documentoarquivowwds_14_dynamicfiltersoperator3 ,
                                             DateTime AV136Core_documentoarquivowwds_15_docarqinsdata3 ,
                                             DateTime AV137Core_documentoarquivowwds_16_docarqinsdata_to3 ,
                                             string AV139Core_documentoarquivowwds_18_tfdocarqconteudonome_sel ,
                                             string AV138Core_documentoarquivowwds_17_tfdocarqconteudonome ,
                                             string AV141Core_documentoarquivowwds_20_tfdocarqconteudoextensao_sel ,
                                             string AV140Core_documentoarquivowwds_19_tfdocarqconteudoextensao ,
                                             DateTime AV142Core_documentoarquivowwds_21_tfdocarqinsdatahora ,
                                             DateTime AV143Core_documentoarquivowwds_22_tfdocarqinsdatahora_to ,
                                             string AV145Core_documentoarquivowwds_24_tfdocarqobservacao_sel ,
                                             string AV144Core_documentoarquivowwds_23_tfdocarqobservacao ,
                                             string A322DocArqConteudoNome ,
                                             string A323DocArqConteudoExtensao ,
                                             string A324DocArqObservacao ,
                                             DateTime A308DocArqInsData ,
                                             DateTime A310DocArqInsDataHora ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc ,
                                             Guid AV119DocID ,
                                             Guid A289DocID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[27];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM tb_documento_arquivo";
         AddWhere(sWhereString, "(DocID = :AV119DocID)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Core_documentoarquivowwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( DocArqConteudoNome like '%' || :lV123Core_documentoarquivowwds_2_filterfulltext) or ( DocArqConteudoExtensao like '%' || :lV123Core_documentoarquivowwds_2_filterfulltext) or ( DocArqObservacao like '%' || :lV123Core_documentoarquivowwds_2_filterfulltext))");
         }
         else
         {
            GXv_int9[1] = 1;
            GXv_int9[2] = 1;
            GXv_int9[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV124Core_documentoarquivowwds_3_dynamicfiltersselector1, "DOCARQINSDATA") == 0 ) && ( AV125Core_documentoarquivowwds_4_dynamicfiltersoperator1 == 0 ) && ( ! (DateTime.MinValue==AV126Core_documentoarquivowwds_5_docarqinsdata1) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData < :AV126Core_documentoarquivowwds_5_docarqinsdata1)");
         }
         else
         {
            GXv_int9[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV124Core_documentoarquivowwds_3_dynamicfiltersselector1, "DOCARQINSDATA") == 0 ) && ( AV125Core_documentoarquivowwds_4_dynamicfiltersoperator1 == 1 ) && ( ! (DateTime.MinValue==AV126Core_documentoarquivowwds_5_docarqinsdata1) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData = :AV126Core_documentoarquivowwds_5_docarqinsdata1)");
         }
         else
         {
            GXv_int9[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV124Core_documentoarquivowwds_3_dynamicfiltersselector1, "DOCARQINSDATA") == 0 ) && ( AV125Core_documentoarquivowwds_4_dynamicfiltersoperator1 == 2 ) && ( ! (DateTime.MinValue==AV126Core_documentoarquivowwds_5_docarqinsdata1) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData > :AV126Core_documentoarquivowwds_5_docarqinsdata1)");
         }
         else
         {
            GXv_int9[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV124Core_documentoarquivowwds_3_dynamicfiltersselector1, "DOCARQINSDATA") == 0 ) && ( AV125Core_documentoarquivowwds_4_dynamicfiltersoperator1 == 3 ) && ( ! (DateTime.MinValue==AV126Core_documentoarquivowwds_5_docarqinsdata1) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData >= :AV126Core_documentoarquivowwds_5_docarqinsdata1)");
         }
         else
         {
            GXv_int9[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV124Core_documentoarquivowwds_3_dynamicfiltersselector1, "DOCARQINSDATA") == 0 ) && ( AV125Core_documentoarquivowwds_4_dynamicfiltersoperator1 == 3 ) && ( ! (DateTime.MinValue==AV127Core_documentoarquivowwds_6_docarqinsdata_to1) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData <= :AV127Core_documentoarquivowwds_6_docarqinsdata_to1)");
         }
         else
         {
            GXv_int9[8] = 1;
         }
         if ( AV128Core_documentoarquivowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV129Core_documentoarquivowwds_8_dynamicfiltersselector2, "DOCARQINSDATA") == 0 ) && ( AV130Core_documentoarquivowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! (DateTime.MinValue==AV131Core_documentoarquivowwds_10_docarqinsdata2) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData < :AV131Core_documentoarquivowwds_10_docarqinsdata2)");
         }
         else
         {
            GXv_int9[9] = 1;
         }
         if ( AV128Core_documentoarquivowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV129Core_documentoarquivowwds_8_dynamicfiltersselector2, "DOCARQINSDATA") == 0 ) && ( AV130Core_documentoarquivowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! (DateTime.MinValue==AV131Core_documentoarquivowwds_10_docarqinsdata2) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData = :AV131Core_documentoarquivowwds_10_docarqinsdata2)");
         }
         else
         {
            GXv_int9[10] = 1;
         }
         if ( AV128Core_documentoarquivowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV129Core_documentoarquivowwds_8_dynamicfiltersselector2, "DOCARQINSDATA") == 0 ) && ( AV130Core_documentoarquivowwds_9_dynamicfiltersoperator2 == 2 ) && ( ! (DateTime.MinValue==AV131Core_documentoarquivowwds_10_docarqinsdata2) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData > :AV131Core_documentoarquivowwds_10_docarqinsdata2)");
         }
         else
         {
            GXv_int9[11] = 1;
         }
         if ( AV128Core_documentoarquivowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV129Core_documentoarquivowwds_8_dynamicfiltersselector2, "DOCARQINSDATA") == 0 ) && ( AV130Core_documentoarquivowwds_9_dynamicfiltersoperator2 == 3 ) && ( ! (DateTime.MinValue==AV131Core_documentoarquivowwds_10_docarqinsdata2) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData >= :AV131Core_documentoarquivowwds_10_docarqinsdata2)");
         }
         else
         {
            GXv_int9[12] = 1;
         }
         if ( AV128Core_documentoarquivowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV129Core_documentoarquivowwds_8_dynamicfiltersselector2, "DOCARQINSDATA") == 0 ) && ( AV130Core_documentoarquivowwds_9_dynamicfiltersoperator2 == 3 ) && ( ! (DateTime.MinValue==AV132Core_documentoarquivowwds_11_docarqinsdata_to2) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData <= :AV132Core_documentoarquivowwds_11_docarqinsdata_to2)");
         }
         else
         {
            GXv_int9[13] = 1;
         }
         if ( AV133Core_documentoarquivowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV134Core_documentoarquivowwds_13_dynamicfiltersselector3, "DOCARQINSDATA") == 0 ) && ( AV135Core_documentoarquivowwds_14_dynamicfiltersoperator3 == 0 ) && ( ! (DateTime.MinValue==AV136Core_documentoarquivowwds_15_docarqinsdata3) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData < :AV136Core_documentoarquivowwds_15_docarqinsdata3)");
         }
         else
         {
            GXv_int9[14] = 1;
         }
         if ( AV133Core_documentoarquivowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV134Core_documentoarquivowwds_13_dynamicfiltersselector3, "DOCARQINSDATA") == 0 ) && ( AV135Core_documentoarquivowwds_14_dynamicfiltersoperator3 == 1 ) && ( ! (DateTime.MinValue==AV136Core_documentoarquivowwds_15_docarqinsdata3) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData = :AV136Core_documentoarquivowwds_15_docarqinsdata3)");
         }
         else
         {
            GXv_int9[15] = 1;
         }
         if ( AV133Core_documentoarquivowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV134Core_documentoarquivowwds_13_dynamicfiltersselector3, "DOCARQINSDATA") == 0 ) && ( AV135Core_documentoarquivowwds_14_dynamicfiltersoperator3 == 2 ) && ( ! (DateTime.MinValue==AV136Core_documentoarquivowwds_15_docarqinsdata3) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData > :AV136Core_documentoarquivowwds_15_docarqinsdata3)");
         }
         else
         {
            GXv_int9[16] = 1;
         }
         if ( AV133Core_documentoarquivowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV134Core_documentoarquivowwds_13_dynamicfiltersselector3, "DOCARQINSDATA") == 0 ) && ( AV135Core_documentoarquivowwds_14_dynamicfiltersoperator3 == 3 ) && ( ! (DateTime.MinValue==AV136Core_documentoarquivowwds_15_docarqinsdata3) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData >= :AV136Core_documentoarquivowwds_15_docarqinsdata3)");
         }
         else
         {
            GXv_int9[17] = 1;
         }
         if ( AV133Core_documentoarquivowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV134Core_documentoarquivowwds_13_dynamicfiltersselector3, "DOCARQINSDATA") == 0 ) && ( AV135Core_documentoarquivowwds_14_dynamicfiltersoperator3 == 3 ) && ( ! (DateTime.MinValue==AV137Core_documentoarquivowwds_16_docarqinsdata_to3) ) )
         {
            AddWhere(sWhereString, "(DocArqInsData <= :AV137Core_documentoarquivowwds_16_docarqinsdata_to3)");
         }
         else
         {
            GXv_int9[18] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV139Core_documentoarquivowwds_18_tfdocarqconteudonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV138Core_documentoarquivowwds_17_tfdocarqconteudonome)) ) )
         {
            AddWhere(sWhereString, "(DocArqConteudoNome like :lV138Core_documentoarquivowwds_17_tfdocarqconteudonome)");
         }
         else
         {
            GXv_int9[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV139Core_documentoarquivowwds_18_tfdocarqconteudonome_sel)) && ! ( StringUtil.StrCmp(AV139Core_documentoarquivowwds_18_tfdocarqconteudonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(DocArqConteudoNome = ( :AV139Core_documentoarquivowwds_18_tfdocarqconteudonome_sel))");
         }
         else
         {
            GXv_int9[20] = 1;
         }
         if ( StringUtil.StrCmp(AV139Core_documentoarquivowwds_18_tfdocarqconteudonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from DocArqConteudoNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV141Core_documentoarquivowwds_20_tfdocarqconteudoextensao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV140Core_documentoarquivowwds_19_tfdocarqconteudoextensao)) ) )
         {
            AddWhere(sWhereString, "(DocArqConteudoExtensao like :lV140Core_documentoarquivowwds_19_tfdocarqconteudoextensao)");
         }
         else
         {
            GXv_int9[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV141Core_documentoarquivowwds_20_tfdocarqconteudoextensao_sel)) && ! ( StringUtil.StrCmp(AV141Core_documentoarquivowwds_20_tfdocarqconteudoextensao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(DocArqConteudoExtensao = ( :AV141Core_documentoarquivowwds_20_tfdocarqconteudoextensao_sel))");
         }
         else
         {
            GXv_int9[22] = 1;
         }
         if ( StringUtil.StrCmp(AV141Core_documentoarquivowwds_20_tfdocarqconteudoextensao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from DocArqConteudoExtensao))=0))");
         }
         if ( ! (DateTime.MinValue==AV142Core_documentoarquivowwds_21_tfdocarqinsdatahora) )
         {
            AddWhere(sWhereString, "(DocArqInsDataHora >= :AV142Core_documentoarquivowwds_21_tfdocarqinsdatahora)");
         }
         else
         {
            GXv_int9[23] = 1;
         }
         if ( ! (DateTime.MinValue==AV143Core_documentoarquivowwds_22_tfdocarqinsdatahora_to) )
         {
            AddWhere(sWhereString, "(DocArqInsDataHora <= :AV143Core_documentoarquivowwds_22_tfdocarqinsdatahora_to)");
         }
         else
         {
            GXv_int9[24] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV145Core_documentoarquivowwds_24_tfdocarqobservacao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV144Core_documentoarquivowwds_23_tfdocarqobservacao)) ) )
         {
            AddWhere(sWhereString, "(DocArqObservacao like :lV144Core_documentoarquivowwds_23_tfdocarqobservacao)");
         }
         else
         {
            GXv_int9[25] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV145Core_documentoarquivowwds_24_tfdocarqobservacao_sel)) && ! ( StringUtil.StrCmp(AV145Core_documentoarquivowwds_24_tfdocarqobservacao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(DocArqObservacao = ( :AV145Core_documentoarquivowwds_24_tfdocarqobservacao_sel))");
         }
         else
         {
            GXv_int9[26] = 1;
         }
         if ( StringUtil.StrCmp(AV145Core_documentoarquivowwds_24_tfdocarqobservacao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(DocArqObservacao IS NULL or (char_length(trim(trailing ' ' from DocArqObservacao))=0))");
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
         else if ( true )
         {
            scmdbuf += "";
         }
         GXv_Object10[0] = scmdbuf;
         GXv_Object10[1] = GXv_int9;
         return GXv_Object10 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H005K2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (DateTime)dynConstraints[13] , (DateTime)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (DateTime)dynConstraints[19] , (DateTime)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (DateTime)dynConstraints[26] , (DateTime)dynConstraints[27] , (short)dynConstraints[28] , (bool)dynConstraints[29] , (Guid)dynConstraints[30] , (Guid)dynConstraints[31] );
               case 1 :
                     return conditional_H005K3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (DateTime)dynConstraints[13] , (DateTime)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (DateTime)dynConstraints[19] , (DateTime)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (DateTime)dynConstraints[26] , (DateTime)dynConstraints[27] , (short)dynConstraints[28] , (bool)dynConstraints[29] , (Guid)dynConstraints[30] , (Guid)dynConstraints[31] );
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
          Object[] prmH005K2;
          prmH005K2 = new Object[] {
          new ParDef("AV119DocID",GXType.UniqueIdentifier,36,0) ,
          new ParDef("lV123Core_documentoarquivowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV123Core_documentoarquivowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV123Core_documentoarquivowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV126Core_documentoarquivowwds_5_docarqinsdata1",GXType.Date,8,0) ,
          new ParDef("AV126Core_documentoarquivowwds_5_docarqinsdata1",GXType.Date,8,0) ,
          new ParDef("AV126Core_documentoarquivowwds_5_docarqinsdata1",GXType.Date,8,0) ,
          new ParDef("AV126Core_documentoarquivowwds_5_docarqinsdata1",GXType.Date,8,0) ,
          new ParDef("AV127Core_documentoarquivowwds_6_docarqinsdata_to1",GXType.Date,8,0) ,
          new ParDef("AV131Core_documentoarquivowwds_10_docarqinsdata2",GXType.Date,8,0) ,
          new ParDef("AV131Core_documentoarquivowwds_10_docarqinsdata2",GXType.Date,8,0) ,
          new ParDef("AV131Core_documentoarquivowwds_10_docarqinsdata2",GXType.Date,8,0) ,
          new ParDef("AV131Core_documentoarquivowwds_10_docarqinsdata2",GXType.Date,8,0) ,
          new ParDef("AV132Core_documentoarquivowwds_11_docarqinsdata_to2",GXType.Date,8,0) ,
          new ParDef("AV136Core_documentoarquivowwds_15_docarqinsdata3",GXType.Date,8,0) ,
          new ParDef("AV136Core_documentoarquivowwds_15_docarqinsdata3",GXType.Date,8,0) ,
          new ParDef("AV136Core_documentoarquivowwds_15_docarqinsdata3",GXType.Date,8,0) ,
          new ParDef("AV136Core_documentoarquivowwds_15_docarqinsdata3",GXType.Date,8,0) ,
          new ParDef("AV137Core_documentoarquivowwds_16_docarqinsdata_to3",GXType.Date,8,0) ,
          new ParDef("lV138Core_documentoarquivowwds_17_tfdocarqconteudonome",GXType.VarChar,2000,0) ,
          new ParDef("AV139Core_documentoarquivowwds_18_tfdocarqconteudonome_sel",GXType.VarChar,2000,0) ,
          new ParDef("lV140Core_documentoarquivowwds_19_tfdocarqconteudoextensao",GXType.VarChar,20,0) ,
          new ParDef("AV141Core_documentoarquivowwds_20_tfdocarqconteudoextensao_sel",GXType.VarChar,20,0) ,
          new ParDef("AV142Core_documentoarquivowwds_21_tfdocarqinsdatahora",GXType.DateTime2,10,12) ,
          new ParDef("AV143Core_documentoarquivowwds_22_tfdocarqinsdatahora_to",GXType.DateTime2,10,12) ,
          new ParDef("lV144Core_documentoarquivowwds_23_tfdocarqobservacao",GXType.VarChar,2000,0) ,
          new ParDef("AV145Core_documentoarquivowwds_24_tfdocarqobservacao_sel",GXType.VarChar,2000,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH005K3;
          prmH005K3 = new Object[] {
          new ParDef("AV119DocID",GXType.UniqueIdentifier,36,0) ,
          new ParDef("lV123Core_documentoarquivowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV123Core_documentoarquivowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV123Core_documentoarquivowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV126Core_documentoarquivowwds_5_docarqinsdata1",GXType.Date,8,0) ,
          new ParDef("AV126Core_documentoarquivowwds_5_docarqinsdata1",GXType.Date,8,0) ,
          new ParDef("AV126Core_documentoarquivowwds_5_docarqinsdata1",GXType.Date,8,0) ,
          new ParDef("AV126Core_documentoarquivowwds_5_docarqinsdata1",GXType.Date,8,0) ,
          new ParDef("AV127Core_documentoarquivowwds_6_docarqinsdata_to1",GXType.Date,8,0) ,
          new ParDef("AV131Core_documentoarquivowwds_10_docarqinsdata2",GXType.Date,8,0) ,
          new ParDef("AV131Core_documentoarquivowwds_10_docarqinsdata2",GXType.Date,8,0) ,
          new ParDef("AV131Core_documentoarquivowwds_10_docarqinsdata2",GXType.Date,8,0) ,
          new ParDef("AV131Core_documentoarquivowwds_10_docarqinsdata2",GXType.Date,8,0) ,
          new ParDef("AV132Core_documentoarquivowwds_11_docarqinsdata_to2",GXType.Date,8,0) ,
          new ParDef("AV136Core_documentoarquivowwds_15_docarqinsdata3",GXType.Date,8,0) ,
          new ParDef("AV136Core_documentoarquivowwds_15_docarqinsdata3",GXType.Date,8,0) ,
          new ParDef("AV136Core_documentoarquivowwds_15_docarqinsdata3",GXType.Date,8,0) ,
          new ParDef("AV136Core_documentoarquivowwds_15_docarqinsdata3",GXType.Date,8,0) ,
          new ParDef("AV137Core_documentoarquivowwds_16_docarqinsdata_to3",GXType.Date,8,0) ,
          new ParDef("lV138Core_documentoarquivowwds_17_tfdocarqconteudonome",GXType.VarChar,2000,0) ,
          new ParDef("AV139Core_documentoarquivowwds_18_tfdocarqconteudonome_sel",GXType.VarChar,2000,0) ,
          new ParDef("lV140Core_documentoarquivowwds_19_tfdocarqconteudoextensao",GXType.VarChar,20,0) ,
          new ParDef("AV141Core_documentoarquivowwds_20_tfdocarqconteudoextensao_sel",GXType.VarChar,20,0) ,
          new ParDef("AV142Core_documentoarquivowwds_21_tfdocarqinsdatahora",GXType.DateTime2,10,12) ,
          new ParDef("AV143Core_documentoarquivowwds_22_tfdocarqinsdatahora_to",GXType.DateTime2,10,12) ,
          new ParDef("lV144Core_documentoarquivowwds_23_tfdocarqobservacao",GXType.VarChar,2000,0) ,
          new ParDef("AV145Core_documentoarquivowwds_24_tfdocarqobservacao_sel",GXType.VarChar,2000,0)
          };
          def= new CursorDef[] {
              new CursorDef("H005K2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005K2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H005K3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005K3,1, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3, true);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((short[]) buf[6])[0] = rslt.getShort(6);
                ((Guid[]) buf[7])[0] = rslt.getGuid(7);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
