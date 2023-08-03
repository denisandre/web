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
   public class wcdocumentoarquivo : GXWebComponent
   {
      public wcdocumentoarquivo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            context.SetDefaultTheme("WorkWithPlusDS", true);
         }
      }

      public wcdocumentoarquivo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_InDocID ,
                           Guid aP1_InDocVersaoIDPai )
      {
         this.AV69InDocID = aP0_InDocID;
         this.AV70InDocVersaoIDPai = aP1_InDocVersaoIDPai;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      public override void SetPrefix( string sPPrefix )
      {
         sPrefix = sPPrefix;
      }

      protected override void createObjects( )
      {
         cmbavGridactions = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "InDocID");
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "dyncomponent") == 0 )
               {
                  setAjaxEventMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  nDynComponent = 1;
                  sCompPrefix = GetPar( "sCompPrefix");
                  sSFPrefix = GetPar( "sSFPrefix");
                  AV69InDocID = StringUtil.StrToGuid( GetPar( "InDocID"));
                  AssignAttri(sPrefix, false, "AV69InDocID", AV69InDocID.ToString());
                  AV70InDocVersaoIDPai = StringUtil.StrToGuid( GetPar( "InDocVersaoIDPai"));
                  AssignAttri(sPrefix, false, "AV70InDocVersaoIDPai", AV70InDocVersaoIDPai.ToString());
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(Guid)AV69InDocID,(Guid)AV70InDocVersaoIDPai});
                  componentstart();
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
                  componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
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
                  gxfirstwebparm = GetFirstPar( "InDocID");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "InDocID");
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
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.IsLocalStorageSupported( ) )
            {
               context.PushCurrentUrl();
            }
         }
      }

      protected void gxnrGrid_newrow_invoke( )
      {
         nRC_GXsfl_36 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_36"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_36_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_36_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_36_idx = GetPar( "sGXsfl_36_idx");
         sPrefix = GetPar( "sPrefix");
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
         AV18FilterFullText = GetPar( "FilterFullText");
         AV69InDocID = StringUtil.StrToGuid( GetPar( "InDocID"));
         AV70InDocVersaoIDPai = StringUtil.StrToGuid( GetPar( "InDocVersaoIDPai"));
         AV40ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV41TFDocArqConteudoNome = GetPar( "TFDocArqConteudoNome");
         AV42TFDocArqConteudoNome_Sel = GetPar( "TFDocArqConteudoNome_Sel");
         AV43TFDocArqConteudoExtensao = GetPar( "TFDocArqConteudoExtensao");
         AV44TFDocArqConteudoExtensao_Sel = GetPar( "TFDocArqConteudoExtensao_Sel");
         AV45TFDocArqInsDataHora = context.localUtil.ParseDTimeParm( GetPar( "TFDocArqInsDataHora"));
         AV46TFDocArqInsDataHora_To = context.localUtil.ParseDTimeParm( GetPar( "TFDocArqInsDataHora_To"));
         AV50TFDocArqObservacao = GetPar( "TFDocArqObservacao");
         AV51TFDocArqObservacao_Sel = GetPar( "TFDocArqObservacao_Sel");
         AV71Pgmname = GetPar( "Pgmname");
         AV15OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV16OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV18FilterFullText, AV69InDocID, AV70InDocVersaoIDPai, AV40ManageFiltersExecutionStep, AV41TFDocArqConteudoNome, AV42TFDocArqConteudoNome_Sel, AV43TFDocArqConteudoExtensao, AV44TFDocArqConteudoExtensao_Sel, AV45TFDocArqInsDataHora, AV46TFDocArqInsDataHora_To, AV50TFDocArqObservacao, AV51TFDocArqObservacao_Sel, AV71Pgmname, AV15OrderedBy, AV16OrderedDsc, sPrefix) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid_refresh_invoke */
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
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               ValidateSpaRequest();
            }
            PA5M2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV71Pgmname = "core.wcDocumentoArquivo";
               WS5M2( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  if ( nDynComponent == 0 )
                  {
                     throw new System.Net.WebException("WebComponent is not allowed to run") ;
                  }
               }
            }
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

      protected void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
            context.WriteHtmlText( "<title>") ;
            context.SendWebValue( " Arquivo do Documento") ;
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
         }
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
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
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
         if ( StringUtil.Len( sPrefix) == 0 )
         {
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
            bodyStyle = "";
            if ( nGXWrapped == 0 )
            {
               bodyStyle += "-moz-opacity:0;opacity:0;";
            }
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "core.wcdocumentoarquivo.aspx"+UrlEncode(AV69InDocID.ToString()) + "," + UrlEncode(AV70InDocVersaoIDPai.ToString());
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("core.wcdocumentoarquivo.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
            AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal Form", true);
         }
         else
         {
            bool toggleHtmlOutput = isOutputEnabled( );
            if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableOutput();
               }
            }
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gxwebcomponent-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            if ( toggleHtmlOutput )
            {
               if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableOutput();
                  }
               }
            }
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV71Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV71Pgmname, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vFILTERFULLTEXT", AV18FilterFullText);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_36", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_36), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vMANAGEFILTERSDATA", AV38ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vMANAGEFILTERSDATA", AV38ManageFiltersData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vAGEXPORTDATA", AV60AGExportData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vAGEXPORTDATA", AV60AGExportData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDDO_TITLESETTINGSICONS", AV52DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDDO_TITLESETTINGSICONS", AV52DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vDDO_DOCARQINSDATAHORAAUXDATE", context.localUtil.DToC( AV47DDO_DocArqInsDataHoraAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDDO_DOCARQINSDATAHORAAUXDATETO", context.localUtil.DToC( AV48DDO_DocArqInsDataHoraAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV69InDocID", wcpOAV69InDocID.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV70InDocVersaoIDPai", wcpOAV70InDocVersaoIDPai.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV40ManageFiltersExecutionStep), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFDOCARQCONTEUDONOME", AV41TFDocArqConteudoNome);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFDOCARQCONTEUDONOME_SEL", AV42TFDocArqConteudoNome_Sel);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFDOCARQCONTEUDOEXTENSAO", AV43TFDocArqConteudoExtensao);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFDOCARQCONTEUDOEXTENSAO_SEL", AV44TFDocArqConteudoExtensao_Sel);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFDOCARQINSDATAHORA", context.localUtil.TToC( AV45TFDocArqInsDataHora, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFDOCARQINSDATAHORA_TO", context.localUtil.TToC( AV46TFDocArqInsDataHora_To, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFDOCARQOBSERVACAO", AV50TFDocArqObservacao);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFDOCARQOBSERVACAO_SEL", AV51TFDocArqObservacao_Sel);
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV71Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV71Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vORDEREDDSC", AV16OrderedDsc);
         GxWebStd.gx_hidden_field( context, sPrefix+"vINDOCID", AV69InDocID.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"vINDOCVERSAOIDPAI", AV70InDocVersaoIDPai.ToString());
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vGRIDSTATE", AV12GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vGRIDSTATE", AV12GridState);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Icontype", StringUtil.RTrim( Ddo_managefilters_Icontype));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Icon", StringUtil.RTrim( Ddo_managefilters_Icon));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Tooltip", StringUtil.RTrim( Ddo_managefilters_Tooltip));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Cls", StringUtil.RTrim( Ddo_managefilters_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_AGEXPORT_Icontype", StringUtil.RTrim( Ddo_agexport_Icontype));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_AGEXPORT_Icon", StringUtil.RTrim( Ddo_agexport_Icon));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_AGEXPORT_Caption", StringUtil.RTrim( Ddo_agexport_Caption));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_AGEXPORT_Cls", StringUtil.RTrim( Ddo_agexport_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_AGEXPORT_Titlecontrolidtoreplace", StringUtil.RTrim( Ddo_agexport_Titlecontrolidtoreplace));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDC_SUBSCRIPTIONS_Icontype", StringUtil.RTrim( Ddc_subscriptions_Icontype));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDC_SUBSCRIPTIONS_Icon", StringUtil.RTrim( Ddc_subscriptions_Icon));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDC_SUBSCRIPTIONS_Caption", StringUtil.RTrim( Ddc_subscriptions_Caption));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDC_SUBSCRIPTIONS_Tooltip", StringUtil.RTrim( Ddc_subscriptions_Tooltip));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDC_SUBSCRIPTIONS_Cls", StringUtil.RTrim( Ddc_subscriptions_Cls));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDC_SUBSCRIPTIONS_Titlecontrolidtoreplace", StringUtil.RTrim( Ddc_subscriptions_Titlecontrolidtoreplace));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Caption", StringUtil.RTrim( Ddo_grid_Caption));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtext_set", StringUtil.RTrim( Ddo_grid_Filteredtext_set));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtextto_set", StringUtil.RTrim( Ddo_grid_Filteredtextto_set));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_set", StringUtil.RTrim( Ddo_grid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Gridinternalname", StringUtil.RTrim( Ddo_grid_Gridinternalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Columnids", StringUtil.RTrim( Ddo_grid_Columnids));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Columnssortvalues", StringUtil.RTrim( Ddo_grid_Columnssortvalues));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Includesortasc", StringUtil.RTrim( Ddo_grid_Includesortasc));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Sortedstatus", StringUtil.RTrim( Ddo_grid_Sortedstatus));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Includefilter", StringUtil.RTrim( Ddo_grid_Includefilter));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filtertype", StringUtil.RTrim( Ddo_grid_Filtertype));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filterisrange", StringUtil.RTrim( Ddo_grid_Filterisrange));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Includedatalist", StringUtil.RTrim( Ddo_grid_Includedatalist));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Datalisttype", StringUtil.RTrim( Ddo_grid_Datalisttype));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Datalistproc", StringUtil.RTrim( Ddo_grid_Datalistproc));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Fixedcolumns", StringUtil.RTrim( Grid_empowerer_Fixedcolumns));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_AGEXPORT_Activeeventkey", StringUtil.RTrim( Ddo_agexport_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_AGEXPORT_Activeeventkey", StringUtil.RTrim( Ddo_agexport_Activeeventkey));
      }

      protected void RenderHtmlCloseForm5M2( )
      {
         SendCloseFormHiddens( ) ;
         if ( ( StringUtil.Len( sPrefix) != 0 ) && ( context.isAjaxRequest( ) || context.isSpaRequest( ) ) )
         {
            componentjscripts();
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GX_FocusControl", GX_FocusControl);
         define_styles( ) ;
         SendSecurityToken(sPrefix);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            SendAjaxEncryptionKey();
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
            context.WriteHtmlTextNl( "</body>") ;
            context.WriteHtmlTextNl( "</html>") ;
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
         }
         else
         {
            SendWebComponentState();
            context.WriteHtmlText( "</div>") ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
      }

      public override string GetPgmname( )
      {
         return "core.wcDocumentoArquivo" ;
      }

      public override string GetPgmdesc( )
      {
         return " Arquivo do Documento" ;
      }

      protected void WB5M0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               RenderHtmlHeaders( ) ;
            }
            RenderHtmlOpenForm( ) ;
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "core.wcdocumentoarquivo.aspx");
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 17,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ColumnsSelector";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnagexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(36), 2, 0)+","+"null"+");", "Exportar", bttBtnagexport_Jsonclick, 0, "Exportar", "", StyleString, ClassString, 1, 0, "standard", "'"+sPrefix+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\wcDocumentoArquivo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnsubscriptions_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(36), 2, 0)+","+"null"+");", "", bttBtnsubscriptions_Jsonclick, 0, "Assinaturas", "", StyleString, ClassString, bttBtnsubscriptions_Visible, 0, "standard", "'"+sPrefix+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\wcDocumentoArquivo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            wb_table1_21_5M2( true) ;
         }
         else
         {
            wb_table1_21_5M2( false) ;
         }
         return  ;
      }

      protected void wb_table1_21_5M2e( bool wbgen )
      {
         if ( wbgen )
         {
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
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, sPrefix, "false");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell HasGridEmpowerer", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl36( ) ;
         }
         if ( wbEnd == 36 )
         {
            wbEnd = 0;
            nRC_GXsfl_36 = (int)(nGXsfl_36_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               GridContainer.AddObjectProperty("GRID_nEOF", GRID_nEOF);
               GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Grid", GridContainer, subGrid_Internalname);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData", GridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData"+"V", GridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
               }
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
            ucDdo_agexport.SetProperty("DropDownOptionsData", AV60AGExportData);
            ucDdo_agexport.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_agexport_Internalname, sPrefix+"DDO_AGEXPORTContainer");
            /* User Defined Control */
            ucDdc_subscriptions.SetProperty("IconType", Ddc_subscriptions_Icontype);
            ucDdc_subscriptions.SetProperty("Icon", Ddc_subscriptions_Icon);
            ucDdc_subscriptions.SetProperty("Caption", Ddc_subscriptions_Caption);
            ucDdc_subscriptions.SetProperty("Tooltip", Ddc_subscriptions_Tooltip);
            ucDdc_subscriptions.SetProperty("Cls", Ddc_subscriptions_Cls);
            ucDdc_subscriptions.Render(context, "dvelop.gxbootstrap.ddcomponent", Ddc_subscriptions_Internalname, sPrefix+"DDC_SUBSCRIPTIONSContainer");
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
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV52DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, sPrefix+"DDO_GRIDContainer");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.SetProperty("FixedColumns", Grid_empowerer_Fixedcolumns);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, sPrefix+"GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDiv_wwpauxwc_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, sPrefix+"W0053"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+sPrefix+"gxHTMLWrpW0053"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( bGXsfl_36_Refreshing )
               {
                  if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                  {
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0053"+"");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'" + sPrefix + "',false,'" + sGXsfl_36_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_docarqinsdatahoraauxdatetext_Internalname, AV49DDO_DocArqInsDataHoraAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV49DDO_DocArqInsDataHoraAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,55);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_docarqinsdatahoraauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\wcDocumentoArquivo.htm");
            /* User Defined Control */
            ucTfdocarqinsdatahora_rangepicker.SetProperty("Start Date", AV47DDO_DocArqInsDataHoraAuxDate);
            ucTfdocarqinsdatahora_rangepicker.SetProperty("End Date", AV48DDO_DocArqInsDataHoraAuxDateTo);
            ucTfdocarqinsdatahora_rangepicker.Render(context, "wwp.daterangepicker", Tfdocarqinsdatahora_rangepicker_Internalname, sPrefix+"TFDOCARQINSDATAHORA_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 36 )
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
                  GridContainer.AddObjectProperty("GRID_nEOF", GRID_nEOF);
                  GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Grid", GridContainer, subGrid_Internalname);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData", GridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData"+"V", GridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START5M2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( StringUtil.Len( sPrefix) != 0 )
         {
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.isSpaRequest( ) )
            {
               if ( context.ExposeMetadata( ) )
               {
                  Form.Meta.addItem("generator", "GeneXus .NET 18_0_4-173650", 0) ;
               }
               Form.Meta.addItem("description", " Arquivo do Documento", 0) ;
            }
            context.wjLoc = "";
            context.nUserReturn = 0;
            context.wbHandled = 0;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               sXEvt = cgiGet( "_EventName");
               if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
               {
               }
            }
         }
         wbErr = false;
         if ( ( StringUtil.Len( sPrefix) == 0 ) || ( nDraw == 1 ) )
         {
            if ( nDoneStart == 0 )
            {
               STRUP5M0( ) ;
            }
         }
      }

      protected void WS5M2( )
      {
         START5M2( ) ;
         EVT5M2( ) ;
      }

      protected void EVT5M2( )
      {
         sXEvt = cgiGet( "_EventName");
         if ( ( ( ( StringUtil.Len( sPrefix) == 0 ) ) || ( StringUtil.StringSearch( sXEvt, sPrefix, 1) > 0 ) ) && ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               if ( context.wbHandled == 0 )
               {
                  if ( StringUtil.Len( sPrefix) == 0 )
                  {
                     sEvt = cgiGet( "_EventName");
                     EvtGridId = cgiGet( "_EventGridId");
                     EvtRowId = cgiGet( "_EventRowId");
                  }
                  if ( StringUtil.Len( sEvt) > 0 )
                  {
                     sEvtType = StringUtil.Left( sEvt, 1);
                     sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP5M0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_MANAGEFILTERS.ONOPTIONCLICKED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP5M0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E115M2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_AGEXPORT.ONOPTIONCLICKED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP5M0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E125M2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDC_SUBSCRIPTIONS.ONLOADCOMPONENT") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP5M0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E135M2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP5M0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E145M2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP5M0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = cmbavGridactions_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP5M0( ) ;
                              }
                              AV72Core_wcdocumentoarquivods_1_filterfulltext = AV18FilterFullText;
                              AV73Core_wcdocumentoarquivods_2_tfdocarqconteudonome = AV41TFDocArqConteudoNome;
                              AV74Core_wcdocumentoarquivods_3_tfdocarqconteudonome_sel = AV42TFDocArqConteudoNome_Sel;
                              AV75Core_wcdocumentoarquivods_4_tfdocarqconteudoextensao = AV43TFDocArqConteudoExtensao;
                              AV76Core_wcdocumentoarquivods_5_tfdocarqconteudoextensao_sel = AV44TFDocArqConteudoExtensao_Sel;
                              AV77Core_wcdocumentoarquivods_6_tfdocarqinsdatahora = AV45TFDocArqInsDataHora;
                              AV78Core_wcdocumentoarquivods_7_tfdocarqinsdatahora_to = AV46TFDocArqInsDataHora_To;
                              AV79Core_wcdocumentoarquivods_8_tfdocarqobservacao = AV50TFDocArqObservacao;
                              AV80Core_wcdocumentoarquivods_9_tfdocarqobservacao_sel = AV51TFDocArqObservacao_Sel;
                              sEvt = cgiGet( sPrefix+"GRIDPAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgrid_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgrid_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgrid_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgrid_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "VGRIDACTIONS.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "VGRIDACTIONS.CLICK") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP5M0( ) ;
                              }
                              nGXsfl_36_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_36_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_36_idx), 4, 0), 4, "0");
                              SubsflControlProps_362( ) ;
                              cmbavGridactions.Name = cmbavGridactions_Internalname;
                              cmbavGridactions.CurrentValue = cgiGet( cmbavGridactions_Internalname);
                              AV57GridActions = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavGridactions_Internalname), "."), 18, MidpointRounding.ToEven));
                              AssignAttri(sPrefix, false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV57GridActions), 4, 0));
                              A289DocID = StringUtil.StrToGuid( cgiGet( edtDocID_Internalname));
                              A307DocArqSeq = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtDocArqSeq_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A322DocArqConteudoNome = cgiGet( edtDocArqConteudoNome_Internalname);
                              A323DocArqConteudoExtensao = cgiGet( edtDocArqConteudoExtensao_Internalname);
                              A325DocVersao = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtDocVersao_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A310DocArqInsDataHora = context.localUtil.CToT( cgiGet( edtDocArqInsDataHora_Internalname), 0);
                              A324DocArqObservacao = cgiGet( edtDocArqObservacao_Internalname);
                              n324DocArqObservacao = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = cmbavGridactions_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E155M2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = cmbavGridactions_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Refresh */
                                          E165M2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = cmbavGridactions_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E175M2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VGRIDACTIONS.CLICK") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = cmbavGridactions_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E185M2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          if ( ! wbErr )
                                          {
                                             Rfr0gs = false;
                                             /* Set Refresh If Filterfulltext Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vFILTERFULLTEXT"), AV18FilterFullText) != 0 )
                                             {
                                                Rfr0gs = true;
                                             }
                                             if ( ! Rfr0gs )
                                             {
                                             }
                                             dynload_actions( ) ;
                                          }
                                       }
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                                    {
                                       STRUP5M0( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = cmbavGridactions_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                       }
                                    }
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
                        if ( nCmpId == 53 )
                        {
                           OldWwpaux_wc = cgiGet( sPrefix+"W0053");
                           if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                           {
                              WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                              WebComp_Wwpaux_wc.ComponentInit();
                              WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                              WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                           }
                           if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                           {
                              WebComp_Wwpaux_wc.componentprocess(sPrefix+"W0053", "", sEvt);
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

      protected void WE5M2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm5M2( ) ;
            }
         }
      }

      protected void PA5M2( )
      {
         if ( nDonePA == 0 )
         {
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               initialize_properties( ) ;
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            if ( StringUtil.Len( sPrefix) == 0 )
            {
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "core.wcdocumentoarquivo.aspx")), "core.wcdocumentoarquivo.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "core.wcdocumentoarquivo.aspx")))) ;
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
            }
            if ( ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               if ( StringUtil.Len( sPrefix) == 0 )
               {
                  if ( nGotPars == 0 )
                  {
                     entryPointCalled = false;
                     gxfirstwebparm = GetFirstPar( "InDocID");
                     toggleJsOutput = isJsOutputEnabled( );
                     if ( context.isSpaRequest( ) )
                     {
                        disableJsOutput();
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
            }
            toggleJsOutput = isJsOutputEnabled( );
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableJsOutput();
               }
            }
            init_web_controls( ) ;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( toggleJsOutput )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableJsOutput();
                  }
               }
            }
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = edtavFilterfulltext_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
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
         SubsflControlProps_362( ) ;
         while ( nGXsfl_36_idx <= nRC_GXsfl_36 )
         {
            sendrow_362( ) ;
            nGXsfl_36_idx = ((subGrid_Islastpage==1)&&(nGXsfl_36_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_36_idx+1);
            sGXsfl_36_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_36_idx), 4, 0), 4, "0");
            SubsflControlProps_362( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       string AV18FilterFullText ,
                                       Guid AV69InDocID ,
                                       Guid AV70InDocVersaoIDPai ,
                                       short AV40ManageFiltersExecutionStep ,
                                       string AV41TFDocArqConteudoNome ,
                                       string AV42TFDocArqConteudoNome_Sel ,
                                       string AV43TFDocArqConteudoExtensao ,
                                       string AV44TFDocArqConteudoExtensao_Sel ,
                                       DateTime AV45TFDocArqInsDataHora ,
                                       DateTime AV46TFDocArqInsDataHora_To ,
                                       string AV50TFDocArqObservacao ,
                                       string AV51TFDocArqObservacao_Sel ,
                                       string AV71Pgmname ,
                                       short AV15OrderedBy ,
                                       bool AV16OrderedDsc ,
                                       string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF5M2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_DOCID", GetSecureSignedToken( sPrefix, A289DocID, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"DOCID", A289DocID.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_DOCARQSEQ", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(A307DocArqSeq), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"DOCARQSEQ", StringUtil.LTrim( StringUtil.NToC( (decimal)(A307DocArqSeq), 4, 0, ".", "")));
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
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF5M2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV71Pgmname = "core.wcDocumentoArquivo";
      }

      protected void RF5M2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 36;
         /* Execute user event: Refresh */
         E165M2 ();
         nGXsfl_36_idx = 1;
         sGXsfl_36_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_36_idx), 4, 0), 4, "0");
         SubsflControlProps_362( ) ;
         bGXsfl_36_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", sPrefix);
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "WorkWith");
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
            SubsflControlProps_362( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV72Core_wcdocumentoarquivods_1_filterfulltext ,
                                                 AV74Core_wcdocumentoarquivods_3_tfdocarqconteudonome_sel ,
                                                 AV73Core_wcdocumentoarquivods_2_tfdocarqconteudonome ,
                                                 AV76Core_wcdocumentoarquivods_5_tfdocarqconteudoextensao_sel ,
                                                 AV75Core_wcdocumentoarquivods_4_tfdocarqconteudoextensao ,
                                                 AV77Core_wcdocumentoarquivods_6_tfdocarqinsdatahora ,
                                                 AV78Core_wcdocumentoarquivods_7_tfdocarqinsdatahora_to ,
                                                 AV80Core_wcdocumentoarquivods_9_tfdocarqobservacao_sel ,
                                                 AV79Core_wcdocumentoarquivods_8_tfdocarqobservacao ,
                                                 A322DocArqConteudoNome ,
                                                 A323DocArqConteudoExtensao ,
                                                 A325DocVersao ,
                                                 A324DocArqObservacao ,
                                                 A310DocArqInsDataHora ,
                                                 AV15OrderedBy ,
                                                 AV16OrderedDsc ,
                                                 A289DocID ,
                                                 AV70InDocVersaoIDPai ,
                                                 A326DocVersaoIDPai ,
                                                 AV69InDocID } ,
                                                 new int[]{
                                                 TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                                 }
            });
            lV72Core_wcdocumentoarquivods_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Core_wcdocumentoarquivods_1_filterfulltext), "%", "");
            lV72Core_wcdocumentoarquivods_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Core_wcdocumentoarquivods_1_filterfulltext), "%", "");
            lV72Core_wcdocumentoarquivods_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Core_wcdocumentoarquivods_1_filterfulltext), "%", "");
            lV72Core_wcdocumentoarquivods_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Core_wcdocumentoarquivods_1_filterfulltext), "%", "");
            lV73Core_wcdocumentoarquivods_2_tfdocarqconteudonome = StringUtil.Concat( StringUtil.RTrim( AV73Core_wcdocumentoarquivods_2_tfdocarqconteudonome), "%", "");
            lV75Core_wcdocumentoarquivods_4_tfdocarqconteudoextensao = StringUtil.Concat( StringUtil.RTrim( AV75Core_wcdocumentoarquivods_4_tfdocarqconteudoextensao), "%", "");
            lV79Core_wcdocumentoarquivods_8_tfdocarqobservacao = StringUtil.Concat( StringUtil.RTrim( AV79Core_wcdocumentoarquivods_8_tfdocarqobservacao), "%", "");
            /* Using cursor H005M2 */
            pr_default.execute(0, new Object[] {AV70InDocVersaoIDPai, AV70InDocVersaoIDPai, AV70InDocVersaoIDPai, AV69InDocID, AV70InDocVersaoIDPai, lV72Core_wcdocumentoarquivods_1_filterfulltext, lV72Core_wcdocumentoarquivods_1_filterfulltext, lV72Core_wcdocumentoarquivods_1_filterfulltext, lV72Core_wcdocumentoarquivods_1_filterfulltext, lV73Core_wcdocumentoarquivods_2_tfdocarqconteudonome, AV74Core_wcdocumentoarquivods_3_tfdocarqconteudonome_sel, lV75Core_wcdocumentoarquivods_4_tfdocarqconteudoextensao, AV76Core_wcdocumentoarquivods_5_tfdocarqconteudoextensao_sel, AV77Core_wcdocumentoarquivods_6_tfdocarqinsdatahora, AV78Core_wcdocumentoarquivods_7_tfdocarqinsdatahora_to, lV79Core_wcdocumentoarquivods_8_tfdocarqobservacao, AV80Core_wcdocumentoarquivods_9_tfdocarqobservacao_sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_36_idx = 1;
            sGXsfl_36_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_36_idx), 4, 0), 4, "0");
            SubsflControlProps_362( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A326DocVersaoIDPai = H005M2_A326DocVersaoIDPai[0];
               n326DocVersaoIDPai = H005M2_n326DocVersaoIDPai[0];
               A308DocArqInsData = H005M2_A308DocArqInsData[0];
               A324DocArqObservacao = H005M2_A324DocArqObservacao[0];
               n324DocArqObservacao = H005M2_n324DocArqObservacao[0];
               A310DocArqInsDataHora = H005M2_A310DocArqInsDataHora[0];
               A325DocVersao = H005M2_A325DocVersao[0];
               A323DocArqConteudoExtensao = H005M2_A323DocArqConteudoExtensao[0];
               A322DocArqConteudoNome = H005M2_A322DocArqConteudoNome[0];
               A307DocArqSeq = H005M2_A307DocArqSeq[0];
               A289DocID = H005M2_A289DocID[0];
               A326DocVersaoIDPai = H005M2_A326DocVersaoIDPai[0];
               n326DocVersaoIDPai = H005M2_n326DocVersaoIDPai[0];
               A325DocVersao = H005M2_A325DocVersao[0];
               E175M2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 36;
            WB5M0( ) ;
         }
         bGXsfl_36_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes5M2( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV71Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV71Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_DOCID"+"_"+sGXsfl_36_idx, GetSecureSignedToken( sPrefix+sGXsfl_36_idx, A289DocID, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_DOCARQSEQ"+"_"+sGXsfl_36_idx, GetSecureSignedToken( sPrefix+sGXsfl_36_idx, context.localUtil.Format( (decimal)(A307DocArqSeq), "ZZZ9"), context));
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
         AV72Core_wcdocumentoarquivods_1_filterfulltext = AV18FilterFullText;
         AV73Core_wcdocumentoarquivods_2_tfdocarqconteudonome = AV41TFDocArqConteudoNome;
         AV74Core_wcdocumentoarquivods_3_tfdocarqconteudonome_sel = AV42TFDocArqConteudoNome_Sel;
         AV75Core_wcdocumentoarquivods_4_tfdocarqconteudoextensao = AV43TFDocArqConteudoExtensao;
         AV76Core_wcdocumentoarquivods_5_tfdocarqconteudoextensao_sel = AV44TFDocArqConteudoExtensao_Sel;
         AV77Core_wcdocumentoarquivods_6_tfdocarqinsdatahora = AV45TFDocArqInsDataHora;
         AV78Core_wcdocumentoarquivods_7_tfdocarqinsdatahora_to = AV46TFDocArqInsDataHora_To;
         AV79Core_wcdocumentoarquivods_8_tfdocarqobservacao = AV50TFDocArqObservacao;
         AV80Core_wcdocumentoarquivods_9_tfdocarqobservacao_sel = AV51TFDocArqObservacao_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV72Core_wcdocumentoarquivods_1_filterfulltext ,
                                              AV74Core_wcdocumentoarquivods_3_tfdocarqconteudonome_sel ,
                                              AV73Core_wcdocumentoarquivods_2_tfdocarqconteudonome ,
                                              AV76Core_wcdocumentoarquivods_5_tfdocarqconteudoextensao_sel ,
                                              AV75Core_wcdocumentoarquivods_4_tfdocarqconteudoextensao ,
                                              AV77Core_wcdocumentoarquivods_6_tfdocarqinsdatahora ,
                                              AV78Core_wcdocumentoarquivods_7_tfdocarqinsdatahora_to ,
                                              AV80Core_wcdocumentoarquivods_9_tfdocarqobservacao_sel ,
                                              AV79Core_wcdocumentoarquivods_8_tfdocarqobservacao ,
                                              A322DocArqConteudoNome ,
                                              A323DocArqConteudoExtensao ,
                                              A325DocVersao ,
                                              A324DocArqObservacao ,
                                              A310DocArqInsDataHora ,
                                              AV15OrderedBy ,
                                              AV16OrderedDsc ,
                                              A289DocID ,
                                              AV70InDocVersaoIDPai ,
                                              A326DocVersaoIDPai ,
                                              AV69InDocID } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV72Core_wcdocumentoarquivods_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Core_wcdocumentoarquivods_1_filterfulltext), "%", "");
         lV72Core_wcdocumentoarquivods_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Core_wcdocumentoarquivods_1_filterfulltext), "%", "");
         lV72Core_wcdocumentoarquivods_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Core_wcdocumentoarquivods_1_filterfulltext), "%", "");
         lV72Core_wcdocumentoarquivods_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Core_wcdocumentoarquivods_1_filterfulltext), "%", "");
         lV73Core_wcdocumentoarquivods_2_tfdocarqconteudonome = StringUtil.Concat( StringUtil.RTrim( AV73Core_wcdocumentoarquivods_2_tfdocarqconteudonome), "%", "");
         lV75Core_wcdocumentoarquivods_4_tfdocarqconteudoextensao = StringUtil.Concat( StringUtil.RTrim( AV75Core_wcdocumentoarquivods_4_tfdocarqconteudoextensao), "%", "");
         lV79Core_wcdocumentoarquivods_8_tfdocarqobservacao = StringUtil.Concat( StringUtil.RTrim( AV79Core_wcdocumentoarquivods_8_tfdocarqobservacao), "%", "");
         /* Using cursor H005M3 */
         pr_default.execute(1, new Object[] {AV70InDocVersaoIDPai, AV70InDocVersaoIDPai, AV70InDocVersaoIDPai, AV69InDocID, AV70InDocVersaoIDPai, lV72Core_wcdocumentoarquivods_1_filterfulltext, lV72Core_wcdocumentoarquivods_1_filterfulltext, lV72Core_wcdocumentoarquivods_1_filterfulltext, lV72Core_wcdocumentoarquivods_1_filterfulltext, lV73Core_wcdocumentoarquivods_2_tfdocarqconteudonome, AV74Core_wcdocumentoarquivods_3_tfdocarqconteudonome_sel, lV75Core_wcdocumentoarquivods_4_tfdocarqconteudoextensao, AV76Core_wcdocumentoarquivods_5_tfdocarqconteudoextensao_sel, AV77Core_wcdocumentoarquivods_6_tfdocarqinsdatahora, AV78Core_wcdocumentoarquivods_7_tfdocarqinsdatahora_to, lV79Core_wcdocumentoarquivods_8_tfdocarqobservacao, AV80Core_wcdocumentoarquivods_9_tfdocarqobservacao_sel});
         GRID_nRecordCount = H005M3_AGRID_nRecordCount[0];
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
         AV72Core_wcdocumentoarquivods_1_filterfulltext = AV18FilterFullText;
         AV73Core_wcdocumentoarquivods_2_tfdocarqconteudonome = AV41TFDocArqConteudoNome;
         AV74Core_wcdocumentoarquivods_3_tfdocarqconteudonome_sel = AV42TFDocArqConteudoNome_Sel;
         AV75Core_wcdocumentoarquivods_4_tfdocarqconteudoextensao = AV43TFDocArqConteudoExtensao;
         AV76Core_wcdocumentoarquivods_5_tfdocarqconteudoextensao_sel = AV44TFDocArqConteudoExtensao_Sel;
         AV77Core_wcdocumentoarquivods_6_tfdocarqinsdatahora = AV45TFDocArqInsDataHora;
         AV78Core_wcdocumentoarquivods_7_tfdocarqinsdatahora_to = AV46TFDocArqInsDataHora_To;
         AV79Core_wcdocumentoarquivods_8_tfdocarqobservacao = AV50TFDocArqObservacao;
         AV80Core_wcdocumentoarquivods_9_tfdocarqobservacao_sel = AV51TFDocArqObservacao_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV18FilterFullText, AV69InDocID, AV70InDocVersaoIDPai, AV40ManageFiltersExecutionStep, AV41TFDocArqConteudoNome, AV42TFDocArqConteudoNome_Sel, AV43TFDocArqConteudoExtensao, AV44TFDocArqConteudoExtensao_Sel, AV45TFDocArqInsDataHora, AV46TFDocArqInsDataHora_To, AV50TFDocArqObservacao, AV51TFDocArqObservacao_Sel, AV71Pgmname, AV15OrderedBy, AV16OrderedDsc, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV72Core_wcdocumentoarquivods_1_filterfulltext = AV18FilterFullText;
         AV73Core_wcdocumentoarquivods_2_tfdocarqconteudonome = AV41TFDocArqConteudoNome;
         AV74Core_wcdocumentoarquivods_3_tfdocarqconteudonome_sel = AV42TFDocArqConteudoNome_Sel;
         AV75Core_wcdocumentoarquivods_4_tfdocarqconteudoextensao = AV43TFDocArqConteudoExtensao;
         AV76Core_wcdocumentoarquivods_5_tfdocarqconteudoextensao_sel = AV44TFDocArqConteudoExtensao_Sel;
         AV77Core_wcdocumentoarquivods_6_tfdocarqinsdatahora = AV45TFDocArqInsDataHora;
         AV78Core_wcdocumentoarquivods_7_tfdocarqinsdatahora_to = AV46TFDocArqInsDataHora_To;
         AV79Core_wcdocumentoarquivods_8_tfdocarqobservacao = AV50TFDocArqObservacao;
         AV80Core_wcdocumentoarquivods_9_tfdocarqobservacao_sel = AV51TFDocArqObservacao_Sel;
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ( GRID_nRecordCount >= subGrid_fnc_Recordsperpage( ) ) && ( GRID_nEOF == 0 ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV18FilterFullText, AV69InDocID, AV70InDocVersaoIDPai, AV40ManageFiltersExecutionStep, AV41TFDocArqConteudoNome, AV42TFDocArqConteudoNome_Sel, AV43TFDocArqConteudoExtensao, AV44TFDocArqConteudoExtensao_Sel, AV45TFDocArqInsDataHora, AV46TFDocArqInsDataHora_To, AV50TFDocArqObservacao, AV51TFDocArqObservacao_Sel, AV71Pgmname, AV15OrderedBy, AV16OrderedDsc, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV72Core_wcdocumentoarquivods_1_filterfulltext = AV18FilterFullText;
         AV73Core_wcdocumentoarquivods_2_tfdocarqconteudonome = AV41TFDocArqConteudoNome;
         AV74Core_wcdocumentoarquivods_3_tfdocarqconteudonome_sel = AV42TFDocArqConteudoNome_Sel;
         AV75Core_wcdocumentoarquivods_4_tfdocarqconteudoextensao = AV43TFDocArqConteudoExtensao;
         AV76Core_wcdocumentoarquivods_5_tfdocarqconteudoextensao_sel = AV44TFDocArqConteudoExtensao_Sel;
         AV77Core_wcdocumentoarquivods_6_tfdocarqinsdatahora = AV45TFDocArqInsDataHora;
         AV78Core_wcdocumentoarquivods_7_tfdocarqinsdatahora_to = AV46TFDocArqInsDataHora_To;
         AV79Core_wcdocumentoarquivods_8_tfdocarqobservacao = AV50TFDocArqObservacao;
         AV80Core_wcdocumentoarquivods_9_tfdocarqobservacao_sel = AV51TFDocArqObservacao_Sel;
         if ( GRID_nFirstRecordOnPage >= subGrid_fnc_Recordsperpage( ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage-subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV18FilterFullText, AV69InDocID, AV70InDocVersaoIDPai, AV40ManageFiltersExecutionStep, AV41TFDocArqConteudoNome, AV42TFDocArqConteudoNome_Sel, AV43TFDocArqConteudoExtensao, AV44TFDocArqConteudoExtensao_Sel, AV45TFDocArqInsDataHora, AV46TFDocArqInsDataHora_To, AV50TFDocArqObservacao, AV51TFDocArqObservacao_Sel, AV71Pgmname, AV15OrderedBy, AV16OrderedDsc, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV72Core_wcdocumentoarquivods_1_filterfulltext = AV18FilterFullText;
         AV73Core_wcdocumentoarquivods_2_tfdocarqconteudonome = AV41TFDocArqConteudoNome;
         AV74Core_wcdocumentoarquivods_3_tfdocarqconteudonome_sel = AV42TFDocArqConteudoNome_Sel;
         AV75Core_wcdocumentoarquivods_4_tfdocarqconteudoextensao = AV43TFDocArqConteudoExtensao;
         AV76Core_wcdocumentoarquivods_5_tfdocarqconteudoextensao_sel = AV44TFDocArqConteudoExtensao_Sel;
         AV77Core_wcdocumentoarquivods_6_tfdocarqinsdatahora = AV45TFDocArqInsDataHora;
         AV78Core_wcdocumentoarquivods_7_tfdocarqinsdatahora_to = AV46TFDocArqInsDataHora_To;
         AV79Core_wcdocumentoarquivods_8_tfdocarqobservacao = AV50TFDocArqObservacao;
         AV80Core_wcdocumentoarquivods_9_tfdocarqobservacao_sel = AV51TFDocArqObservacao_Sel;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV18FilterFullText, AV69InDocID, AV70InDocVersaoIDPai, AV40ManageFiltersExecutionStep, AV41TFDocArqConteudoNome, AV42TFDocArqConteudoNome_Sel, AV43TFDocArqConteudoExtensao, AV44TFDocArqConteudoExtensao_Sel, AV45TFDocArqInsDataHora, AV46TFDocArqInsDataHora_To, AV50TFDocArqObservacao, AV51TFDocArqObservacao_Sel, AV71Pgmname, AV15OrderedBy, AV16OrderedDsc, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV72Core_wcdocumentoarquivods_1_filterfulltext = AV18FilterFullText;
         AV73Core_wcdocumentoarquivods_2_tfdocarqconteudonome = AV41TFDocArqConteudoNome;
         AV74Core_wcdocumentoarquivods_3_tfdocarqconteudonome_sel = AV42TFDocArqConteudoNome_Sel;
         AV75Core_wcdocumentoarquivods_4_tfdocarqconteudoextensao = AV43TFDocArqConteudoExtensao;
         AV76Core_wcdocumentoarquivods_5_tfdocarqconteudoextensao_sel = AV44TFDocArqConteudoExtensao_Sel;
         AV77Core_wcdocumentoarquivods_6_tfdocarqinsdatahora = AV45TFDocArqInsDataHora;
         AV78Core_wcdocumentoarquivods_7_tfdocarqinsdatahora_to = AV46TFDocArqInsDataHora_To;
         AV79Core_wcdocumentoarquivods_8_tfdocarqobservacao = AV50TFDocArqObservacao;
         AV80Core_wcdocumentoarquivods_9_tfdocarqobservacao_sel = AV51TFDocArqObservacao_Sel;
         if ( nPageNo > 0 )
         {
            GRID_nFirstRecordOnPage = (long)(subGrid_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV18FilterFullText, AV69InDocID, AV70InDocVersaoIDPai, AV40ManageFiltersExecutionStep, AV41TFDocArqConteudoNome, AV42TFDocArqConteudoNome_Sel, AV43TFDocArqConteudoExtensao, AV44TFDocArqConteudoExtensao_Sel, AV45TFDocArqInsDataHora, AV46TFDocArqInsDataHora_To, AV50TFDocArqObservacao, AV51TFDocArqObservacao_Sel, AV71Pgmname, AV15OrderedBy, AV16OrderedDsc, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV71Pgmname = "core.wcDocumentoArquivo";
         fix_multi_value_controls( ) ;
      }

      protected void STRUP5M0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E155M2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vMANAGEFILTERSDATA"), AV38ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vAGEXPORTDATA"), AV60AGExportData);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vDDO_TITLESETTINGSICONS"), AV52DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_36 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_36"), ",", "."), 18, MidpointRounding.ToEven));
            AV47DDO_DocArqInsDataHoraAuxDate = context.localUtil.CToD( cgiGet( sPrefix+"vDDO_DOCARQINSDATAHORAAUXDATE"), 0);
            AV48DDO_DocArqInsDataHoraAuxDateTo = context.localUtil.CToD( cgiGet( sPrefix+"vDDO_DOCARQINSDATAHORAAUXDATETO"), 0);
            wcpOAV69InDocID = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOAV69InDocID"));
            wcpOAV70InDocVersaoIDPai = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOAV70InDocVersaoIDPai"));
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nFirstRecordOnPage"), ",", "."), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nEOF"), ",", "."), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Ddo_managefilters_Icontype = cgiGet( sPrefix+"DDO_MANAGEFILTERS_Icontype");
            Ddo_managefilters_Icon = cgiGet( sPrefix+"DDO_MANAGEFILTERS_Icon");
            Ddo_managefilters_Tooltip = cgiGet( sPrefix+"DDO_MANAGEFILTERS_Tooltip");
            Ddo_managefilters_Cls = cgiGet( sPrefix+"DDO_MANAGEFILTERS_Cls");
            Ddo_agexport_Icontype = cgiGet( sPrefix+"DDO_AGEXPORT_Icontype");
            Ddo_agexport_Icon = cgiGet( sPrefix+"DDO_AGEXPORT_Icon");
            Ddo_agexport_Caption = cgiGet( sPrefix+"DDO_AGEXPORT_Caption");
            Ddo_agexport_Cls = cgiGet( sPrefix+"DDO_AGEXPORT_Cls");
            Ddo_agexport_Titlecontrolidtoreplace = cgiGet( sPrefix+"DDO_AGEXPORT_Titlecontrolidtoreplace");
            Ddc_subscriptions_Icontype = cgiGet( sPrefix+"DDC_SUBSCRIPTIONS_Icontype");
            Ddc_subscriptions_Icon = cgiGet( sPrefix+"DDC_SUBSCRIPTIONS_Icon");
            Ddc_subscriptions_Caption = cgiGet( sPrefix+"DDC_SUBSCRIPTIONS_Caption");
            Ddc_subscriptions_Tooltip = cgiGet( sPrefix+"DDC_SUBSCRIPTIONS_Tooltip");
            Ddc_subscriptions_Cls = cgiGet( sPrefix+"DDC_SUBSCRIPTIONS_Cls");
            Ddc_subscriptions_Titlecontrolidtoreplace = cgiGet( sPrefix+"DDC_SUBSCRIPTIONS_Titlecontrolidtoreplace");
            Ddo_grid_Caption = cgiGet( sPrefix+"DDO_GRID_Caption");
            Ddo_grid_Filteredtext_set = cgiGet( sPrefix+"DDO_GRID_Filteredtext_set");
            Ddo_grid_Filteredtextto_set = cgiGet( sPrefix+"DDO_GRID_Filteredtextto_set");
            Ddo_grid_Selectedvalue_set = cgiGet( sPrefix+"DDO_GRID_Selectedvalue_set");
            Ddo_grid_Gridinternalname = cgiGet( sPrefix+"DDO_GRID_Gridinternalname");
            Ddo_grid_Columnids = cgiGet( sPrefix+"DDO_GRID_Columnids");
            Ddo_grid_Columnssortvalues = cgiGet( sPrefix+"DDO_GRID_Columnssortvalues");
            Ddo_grid_Includesortasc = cgiGet( sPrefix+"DDO_GRID_Includesortasc");
            Ddo_grid_Sortedstatus = cgiGet( sPrefix+"DDO_GRID_Sortedstatus");
            Ddo_grid_Includefilter = cgiGet( sPrefix+"DDO_GRID_Includefilter");
            Ddo_grid_Filtertype = cgiGet( sPrefix+"DDO_GRID_Filtertype");
            Ddo_grid_Filterisrange = cgiGet( sPrefix+"DDO_GRID_Filterisrange");
            Ddo_grid_Includedatalist = cgiGet( sPrefix+"DDO_GRID_Includedatalist");
            Ddo_grid_Datalisttype = cgiGet( sPrefix+"DDO_GRID_Datalisttype");
            Ddo_grid_Datalistproc = cgiGet( sPrefix+"DDO_GRID_Datalistproc");
            Grid_empowerer_Gridinternalname = cgiGet( sPrefix+"GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( sPrefix+"GRID_EMPOWERER_Hastitlesettings"));
            Grid_empowerer_Fixedcolumns = cgiGet( sPrefix+"GRID_EMPOWERER_Fixedcolumns");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Ddo_grid_Activeeventkey = cgiGet( sPrefix+"DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( sPrefix+"DDO_GRID_Selectedvalue_get");
            Ddo_grid_Selectedcolumn = cgiGet( sPrefix+"DDO_GRID_Selectedcolumn");
            Ddo_grid_Filteredtext_get = cgiGet( sPrefix+"DDO_GRID_Filteredtext_get");
            Ddo_grid_Filteredtextto_get = cgiGet( sPrefix+"DDO_GRID_Filteredtextto_get");
            Ddo_managefilters_Activeeventkey = cgiGet( sPrefix+"DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Ddo_agexport_Activeeventkey = cgiGet( sPrefix+"DDO_AGEXPORT_Activeeventkey");
            /* Read variables values. */
            AV18FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri(sPrefix, false, "AV18FilterFullText", AV18FilterFullText);
            AV49DDO_DocArqInsDataHoraAuxDateText = cgiGet( edtavDdo_docarqinsdatahoraauxdatetext_Internalname);
            AssignAttri(sPrefix, false, "AV49DDO_DocArqInsDataHoraAuxDateText", AV49DDO_DocArqInsDataHoraAuxDateText);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vFILTERFULLTEXT"), AV18FilterFullText) != 0 )
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
         E155M2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E155M2( )
      {
         /* Start Routine */
         returnInSub = false;
         new prcdebugtofile(context ).execute(  AV71Pgmname,  StringUtil.Format( "Event Start - &InDocID: %1 e &InDocVersaoIDPai: %2", AV69InDocID.ToString(), AV70InDocVersaoIDPai.ToString(), "", "", "", "", "", "", "")) ;
         this.executeUsercontrolMethod(sPrefix, false, "TFDOCARQINSDATAHORA_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_docarqinsdatahoraauxdatetext_Internalname});
         subGrid_Rows = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, sPrefix, false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         /* Execute user subroutine: 'LOADSAVEDFILTERS' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         Ddo_agexport_Titlecontrolidtoreplace = bttBtnagexport_Internalname;
         ucDdo_agexport.SendProperty(context, sPrefix, false, Ddo_agexport_Internalname, "TitleControlIdToReplace", Ddo_agexport_Titlecontrolidtoreplace);
         AV60AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV61AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV61AGExportDataItem.gxTpr_Title = "Excel";
         AV61AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "da69a816-fd11-445b-8aaf-1a2f7f1acc93", "", context.GetTheme( ))));
         AV61AGExportDataItem.gxTpr_Eventkey = "Export";
         AV61AGExportDataItem.gxTpr_Isdivider = false;
         AV60AGExportData.Add(AV61AGExportDataItem, 0);
         Ddc_subscriptions_Titlecontrolidtoreplace = bttBtnsubscriptions_Internalname;
         ucDdc_subscriptions.SendProperty(context, sPrefix, false, Ddc_subscriptions_Internalname, "TitleControlIdToReplace", Ddc_subscriptions_Titlecontrolidtoreplace);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( AV15OrderedBy < 1 )
         {
            AV15OrderedBy = 1;
            AssignAttri(sPrefix, false, "AV15OrderedBy", StringUtil.LTrimStr( (decimal)(AV15OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S142 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV52DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV52DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
      }

      protected void E165M2( )
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
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( AV40ManageFiltersExecutionStep == 1 )
         {
            AV40ManageFiltersExecutionStep = 2;
            AssignAttri(sPrefix, false, "AV40ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV40ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV40ManageFiltersExecutionStep == 2 )
         {
            AV40ManageFiltersExecutionStep = 0;
            AssignAttri(sPrefix, false, "AV40ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV40ManageFiltersExecutionStep), 1, 0));
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV72Core_wcdocumentoarquivods_1_filterfulltext = AV18FilterFullText;
         AV73Core_wcdocumentoarquivods_2_tfdocarqconteudonome = AV41TFDocArqConteudoNome;
         AV74Core_wcdocumentoarquivods_3_tfdocarqconteudonome_sel = AV42TFDocArqConteudoNome_Sel;
         AV75Core_wcdocumentoarquivods_4_tfdocarqconteudoextensao = AV43TFDocArqConteudoExtensao;
         AV76Core_wcdocumentoarquivods_5_tfdocarqconteudoextensao_sel = AV44TFDocArqConteudoExtensao_Sel;
         AV77Core_wcdocumentoarquivods_6_tfdocarqinsdatahora = AV45TFDocArqInsDataHora;
         AV78Core_wcdocumentoarquivods_7_tfdocarqinsdatahora_to = AV46TFDocArqInsDataHora_To;
         AV79Core_wcdocumentoarquivods_8_tfdocarqobservacao = AV50TFDocArqObservacao;
         AV80Core_wcdocumentoarquivods_9_tfdocarqobservacao_sel = AV51TFDocArqObservacao_Sel;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV38ManageFiltersData", AV38ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV12GridState", AV12GridState);
      }

      protected void E145M2( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV15OrderedBy = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV15OrderedBy", StringUtil.LTrimStr( (decimal)(AV15OrderedBy), 4, 0));
            AV16OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri(sPrefix, false, "AV16OrderedDsc", AV16OrderedDsc);
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S142 ();
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
               AV41TFDocArqConteudoNome = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV41TFDocArqConteudoNome", AV41TFDocArqConteudoNome);
               AV42TFDocArqConteudoNome_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV42TFDocArqConteudoNome_Sel", AV42TFDocArqConteudoNome_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "DocArqConteudoExtensao") == 0 )
            {
               AV43TFDocArqConteudoExtensao = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV43TFDocArqConteudoExtensao", AV43TFDocArqConteudoExtensao);
               AV44TFDocArqConteudoExtensao_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV44TFDocArqConteudoExtensao_Sel", AV44TFDocArqConteudoExtensao_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "DocArqInsDataHora") == 0 )
            {
               AV45TFDocArqInsDataHora = context.localUtil.CToT( Ddo_grid_Filteredtext_get, 2);
               AssignAttri(sPrefix, false, "AV45TFDocArqInsDataHora", context.localUtil.TToC( AV45TFDocArqInsDataHora, 10, 12, 0, 3, "/", ":", " "));
               AV46TFDocArqInsDataHora_To = context.localUtil.CToT( Ddo_grid_Filteredtextto_get, 2);
               AssignAttri(sPrefix, false, "AV46TFDocArqInsDataHora_To", context.localUtil.TToC( AV46TFDocArqInsDataHora_To, 10, 12, 0, 3, "/", ":", " "));
               if ( ! (DateTime.MinValue==AV46TFDocArqInsDataHora_To) )
               {
                  AV46TFDocArqInsDataHora_To = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( AV46TFDocArqInsDataHora_To)), (short)(DateTimeUtil.Month( AV46TFDocArqInsDataHora_To)), (short)(DateTimeUtil.Day( AV46TFDocArqInsDataHora_To)), 23, 59, 59);
                  AssignAttri(sPrefix, false, "AV46TFDocArqInsDataHora_To", context.localUtil.TToC( AV46TFDocArqInsDataHora_To, 10, 12, 0, 3, "/", ":", " "));
               }
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "DocArqObservacao") == 0 )
            {
               AV50TFDocArqObservacao = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV50TFDocArqObservacao", AV50TFDocArqObservacao);
               AV51TFDocArqObservacao_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV51TFDocArqObservacao_Sel", AV51TFDocArqObservacao_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E175M2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         cmbavGridactions.removeAllItems();
         cmbavGridactions.addItem("0", ";fa fa-bars", 0);
         cmbavGridactions.addItem("1", StringUtil.Format( "%1;%2", "Download", "fas fa-download", "", "", "", "", "", "", ""), 0);
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 36;
         }
         sendrow_362( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_36_Refreshing )
         {
            DoAjaxLoad(36, GridRow);
         }
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV57GridActions), 4, 0));
      }

      protected void E115M2( )
      {
         /* Ddo_managefilters_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Clean#>") == 0 )
         {
            /* Execute user subroutine: 'CLEANFILTERS' */
            S172 ();
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
            S162 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
               }
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wwpbaseobjects.savefilteras.aspx"+UrlEncode(StringUtil.RTrim("core.wcDocumentoArquivoFilters")) + "," + UrlEncode(StringUtil.RTrim(AV71Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV40ManageFiltersExecutionStep = 2;
            AssignAttri(sPrefix, false, "AV40ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV40ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefreshCmp(sPrefix);
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
               }
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wwpbaseobjects.managefilters.aspx"+UrlEncode(StringUtil.RTrim("core.wcDocumentoArquivoFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV40ManageFiltersExecutionStep = 2;
            AssignAttri(sPrefix, false, "AV40ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV40ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefreshCmp(sPrefix);
         }
         else
         {
            GXt_char2 = AV39ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "core.wcDocumentoArquivoFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char2) ;
            AV39ManageFiltersXml = GXt_char2;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV39ManageFiltersXml)) )
            {
               GX_msglist.addItem("O filtro selecionado não existe mais.");
            }
            else
            {
               /* Execute user subroutine: 'CLEANFILTERS' */
               S172 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV71Pgmname+"GridState",  AV39ManageFiltersXml) ;
               AV12GridState.FromXml(AV39ManageFiltersXml, null, "", "");
               AV15OrderedBy = AV12GridState.gxTpr_Orderedby;
               AssignAttri(sPrefix, false, "AV15OrderedBy", StringUtil.LTrimStr( (decimal)(AV15OrderedBy), 4, 0));
               AV16OrderedDsc = AV12GridState.gxTpr_Ordereddsc;
               AssignAttri(sPrefix, false, "AV16OrderedDsc", AV16OrderedDsc);
               /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
               S142 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
               S182 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               subgrid_firstpage( ) ;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV12GridState", AV12GridState);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV38ManageFiltersData", AV38ManageFiltersData);
      }

      protected void E185M2( )
      {
         /* Gridactions_Click Routine */
         returnInSub = false;
         if ( AV57GridActions == 1 )
         {
            /* Execute user subroutine: 'DO DOWNLOAD' */
            S192 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         AV57GridActions = 0;
         AssignAttri(sPrefix, false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV57GridActions), 4, 0));
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV57GridActions), 4, 0));
         AssignProp(sPrefix, false, cmbavGridactions_Internalname, "Values", cmbavGridactions.ToJavascriptSource(), true);
      }

      protected void E125M2( )
      {
         /* Ddo_agexport_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_agexport_Activeeventkey, "Export") == 0 )
         {
            /* Execute user subroutine: 'DOEXPORT' */
            S202 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
      }

      protected void E135M2( )
      {
         /* Ddc_subscriptions_Onloadcomponent Routine */
         returnInSub = false;
         /* Object Property */
         if ( StringUtil.Len( sPrefix) == 0 )
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
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)sPrefix+"W0053",(string)"",(string)"DocumentoArquivo",(short)1,(string)"",(string)""});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0053"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void S142( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV15OrderedBy), 4, 0))+":"+(AV16OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S152( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         if ( ! ( new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_hassubscriptionstodisplay(context).executeUdp(  "DocumentoArquivo",  1) ) )
         {
            bttBtnsubscriptions_Visible = 0;
            AssignProp(sPrefix, false, bttBtnsubscriptions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnsubscriptions_Visible), 5, 0), true);
         }
      }

      protected void S112( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = AV38ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "core.wcDocumentoArquivoFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3) ;
         AV38ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3;
      }

      protected void S172( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV18FilterFullText = "";
         AssignAttri(sPrefix, false, "AV18FilterFullText", AV18FilterFullText);
         AV41TFDocArqConteudoNome = "";
         AssignAttri(sPrefix, false, "AV41TFDocArqConteudoNome", AV41TFDocArqConteudoNome);
         AV42TFDocArqConteudoNome_Sel = "";
         AssignAttri(sPrefix, false, "AV42TFDocArqConteudoNome_Sel", AV42TFDocArqConteudoNome_Sel);
         AV43TFDocArqConteudoExtensao = "";
         AssignAttri(sPrefix, false, "AV43TFDocArqConteudoExtensao", AV43TFDocArqConteudoExtensao);
         AV44TFDocArqConteudoExtensao_Sel = "";
         AssignAttri(sPrefix, false, "AV44TFDocArqConteudoExtensao_Sel", AV44TFDocArqConteudoExtensao_Sel);
         AV45TFDocArqInsDataHora = (DateTime)(DateTime.MinValue);
         AssignAttri(sPrefix, false, "AV45TFDocArqInsDataHora", context.localUtil.TToC( AV45TFDocArqInsDataHora, 10, 12, 0, 3, "/", ":", " "));
         AV46TFDocArqInsDataHora_To = (DateTime)(DateTime.MinValue);
         AssignAttri(sPrefix, false, "AV46TFDocArqInsDataHora_To", context.localUtil.TToC( AV46TFDocArqInsDataHora_To, 10, 12, 0, 3, "/", ":", " "));
         AV50TFDocArqObservacao = "";
         AssignAttri(sPrefix, false, "AV50TFDocArqObservacao", AV50TFDocArqObservacao);
         AV51TFDocArqObservacao_Sel = "";
         AssignAttri(sPrefix, false, "AV51TFDocArqObservacao_Sel", AV51TFDocArqObservacao_Sel);
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S192( )
      {
         /* 'DO DOWNLOAD' Routine */
         returnInSub = false;
         GXt_char2 = AV65Url;
         new GeneXus.Programs.core.prcarquivodownload(context ).execute(  A289DocID,  A307DocArqSeq, out  GXt_char2) ;
         AV65Url = GXt_char2;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Url)) )
         {
            this.executeExternalObjectMethod(sPrefix, false, "gx.extensions.web.window", "open", new Object[] {(string)AV65Url}, false);
         }
      }

      protected void S132( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV37Session.Get(AV71Pgmname+"GridState"), "") == 0 )
         {
            AV12GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV71Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV12GridState.FromXml(AV37Session.Get(AV71Pgmname+"GridState"), null, "", "");
         }
         AV15OrderedBy = AV12GridState.gxTpr_Orderedby;
         AssignAttri(sPrefix, false, "AV15OrderedBy", StringUtil.LTrimStr( (decimal)(AV15OrderedBy), 4, 0));
         AV16OrderedDsc = AV12GridState.gxTpr_Ordereddsc;
         AssignAttri(sPrefix, false, "AV16OrderedDsc", AV16OrderedDsc);
         /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
         S182 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV12GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV12GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV12GridState.gxTpr_Currentpage) ;
      }

      protected void S182( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV81GXV1 = 1;
         while ( AV81GXV1 <= AV12GridState.gxTpr_Filtervalues.Count )
         {
            AV13GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV12GridState.gxTpr_Filtervalues.Item(AV81GXV1));
            if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV18FilterFullText = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV18FilterFullText", AV18FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFDOCARQCONTEUDONOME") == 0 )
            {
               AV41TFDocArqConteudoNome = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV41TFDocArqConteudoNome", AV41TFDocArqConteudoNome);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFDOCARQCONTEUDONOME_SEL") == 0 )
            {
               AV42TFDocArqConteudoNome_Sel = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV42TFDocArqConteudoNome_Sel", AV42TFDocArqConteudoNome_Sel);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFDOCARQCONTEUDOEXTENSAO") == 0 )
            {
               AV43TFDocArqConteudoExtensao = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV43TFDocArqConteudoExtensao", AV43TFDocArqConteudoExtensao);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFDOCARQCONTEUDOEXTENSAO_SEL") == 0 )
            {
               AV44TFDocArqConteudoExtensao_Sel = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV44TFDocArqConteudoExtensao_Sel", AV44TFDocArqConteudoExtensao_Sel);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFDOCARQINSDATAHORA") == 0 )
            {
               AV45TFDocArqInsDataHora = context.localUtil.CToT( AV13GridStateFilterValue.gxTpr_Value, 2);
               AssignAttri(sPrefix, false, "AV45TFDocArqInsDataHora", context.localUtil.TToC( AV45TFDocArqInsDataHora, 10, 12, 0, 3, "/", ":", " "));
               AV46TFDocArqInsDataHora_To = context.localUtil.CToT( AV13GridStateFilterValue.gxTpr_Valueto, 2);
               AssignAttri(sPrefix, false, "AV46TFDocArqInsDataHora_To", context.localUtil.TToC( AV46TFDocArqInsDataHora_To, 10, 12, 0, 3, "/", ":", " "));
               AV47DDO_DocArqInsDataHoraAuxDate = DateTimeUtil.ResetTime(AV45TFDocArqInsDataHora);
               AssignAttri(sPrefix, false, "AV47DDO_DocArqInsDataHoraAuxDate", context.localUtil.Format(AV47DDO_DocArqInsDataHoraAuxDate, "99/99/9999"));
               AV48DDO_DocArqInsDataHoraAuxDateTo = DateTimeUtil.ResetTime(AV46TFDocArqInsDataHora_To);
               AssignAttri(sPrefix, false, "AV48DDO_DocArqInsDataHoraAuxDateTo", context.localUtil.Format(AV48DDO_DocArqInsDataHoraAuxDateTo, "99/99/9999"));
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFDOCARQOBSERVACAO") == 0 )
            {
               AV50TFDocArqObservacao = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV50TFDocArqObservacao", AV50TFDocArqObservacao);
            }
            else if ( StringUtil.StrCmp(AV13GridStateFilterValue.gxTpr_Name, "TFDOCARQOBSERVACAO_SEL") == 0 )
            {
               AV51TFDocArqObservacao_Sel = AV13GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV51TFDocArqObservacao_Sel", AV51TFDocArqObservacao_Sel);
            }
            AV81GXV1 = (int)(AV81GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV42TFDocArqConteudoNome_Sel)),  AV42TFDocArqConteudoNome_Sel, out  GXt_char2) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV44TFDocArqConteudoExtensao_Sel)),  AV44TFDocArqConteudoExtensao_Sel, out  GXt_char4) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV51TFDocArqObservacao_Sel)),  AV51TFDocArqObservacao_Sel, out  GXt_char5) ;
         Ddo_grid_Selectedvalue_set = GXt_char2+"|"+GXt_char4+"||"+GXt_char5;
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV41TFDocArqConteudoNome)),  AV41TFDocArqConteudoNome, out  GXt_char5) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV43TFDocArqConteudoExtensao)),  AV43TFDocArqConteudoExtensao, out  GXt_char4) ;
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV50TFDocArqObservacao)),  AV50TFDocArqObservacao, out  GXt_char2) ;
         Ddo_grid_Filteredtext_set = GXt_char5+"|"+GXt_char4+"|"+((DateTime.MinValue==AV45TFDocArqInsDataHora) ? "" : context.localUtil.DToC( AV47DDO_DocArqInsDataHoraAuxDate, 2, "/"))+"|"+GXt_char2;
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "||"+((DateTime.MinValue==AV46TFDocArqInsDataHora_To) ? "" : context.localUtil.DToC( AV48DDO_DocArqInsDataHoraAuxDateTo, 2, "/"))+"|";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S162( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV12GridState.FromXml(AV37Session.Get(AV71Pgmname+"GridState"), null, "", "");
         AV12GridState.gxTpr_Orderedby = AV15OrderedBy;
         AV12GridState.gxTpr_Ordereddsc = AV16OrderedDsc;
         AV12GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "FILTERFULLTEXT",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV18FilterFullText)),  0,  AV18FilterFullText,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV12GridState,  "TFDOCARQCONTEUDONOME",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV41TFDocArqConteudoNome)),  0,  AV41TFDocArqConteudoNome,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV42TFDocArqConteudoNome_Sel)),  AV42TFDocArqConteudoNome_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV12GridState,  "TFDOCARQCONTEUDOEXTENSAO",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV43TFDocArqConteudoExtensao)),  0,  AV43TFDocArqConteudoExtensao,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV44TFDocArqConteudoExtensao_Sel)),  AV44TFDocArqConteudoExtensao_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV12GridState,  "TFDOCARQINSDATAHORA",  "",  !((DateTime.MinValue==AV45TFDocArqInsDataHora)&&(DateTime.MinValue==AV46TFDocArqInsDataHora_To)),  0,  StringUtil.Trim( context.localUtil.TToC( AV45TFDocArqInsDataHora, 10, 12, 0, 3, "/", ":", " ")),  StringUtil.Trim( context.localUtil.TToC( AV46TFDocArqInsDataHora_To, 10, 12, 0, 3, "/", ":", " "))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV12GridState,  "TFDOCARQOBSERVACAO",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV50TFDocArqObservacao)),  0,  AV50TFDocArqObservacao,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV51TFDocArqObservacao_Sel)),  AV51TFDocArqObservacao_Sel,  "") ;
         if ( ! (Guid.Empty==AV69InDocID) )
         {
            AV13GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
            AV13GridStateFilterValue.gxTpr_Name = "PARM_&INDOCID";
            AV13GridStateFilterValue.gxTpr_Value = AV69InDocID.ToString();
            AV12GridState.gxTpr_Filtervalues.Add(AV13GridStateFilterValue, 0);
         }
         if ( ! (Guid.Empty==AV70InDocVersaoIDPai) )
         {
            AV13GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
            AV13GridStateFilterValue.gxTpr_Name = "PARM_&INDOCVERSAOIDPAI";
            AV13GridStateFilterValue.gxTpr_Value = AV70InDocVersaoIDPai.ToString();
            AV12GridState.gxTpr_Filtervalues.Add(AV13GridStateFilterValue, 0);
         }
         AV12GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV12GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV71Pgmname+"GridState",  AV12GridState.ToXml(false, true, "", "")) ;
      }

      protected void S122( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV10TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV10TrnContext.gxTpr_Callerobject = AV71Pgmname;
         AV10TrnContext.gxTpr_Callerondelete = true;
         AV10TrnContext.gxTpr_Callerurl = AV9HTTPRequest.ScriptName+"?"+AV9HTTPRequest.QueryString;
         AV10TrnContext.gxTpr_Transactionname = "core.DocumentoArquivo";
         AV37Session.Set("TrnContext", AV10TrnContext.ToXml(false, true, "", ""));
      }

      protected void S202( )
      {
         /* 'DOEXPORT' Routine */
         returnInSub = false;
         new GeneXus.Programs.core.wcdocumentoarquivoexport(context ).execute( out  AV35ExcelFilename, out  AV36ErrorMessage) ;
         if ( StringUtil.StrCmp(AV35ExcelFilename, "") != 0 )
         {
            CallWebObject(formatLink(AV35ExcelFilename) );
            context.wjLocDisableFrm = 0;
         }
         else
         {
            GX_msglist.addItem(AV36ErrorMessage);
         }
      }

      protected void wb_table1_21_5M2( bool wbgen )
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
            ucDdo_managefilters.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_managefilters_Internalname, sPrefix+"DDO_MANAGEFILTERSContainer");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            wb_table2_26_5M2( true) ;
         }
         else
         {
            wb_table2_26_5M2( false) ;
         }
         return  ;
      }

      protected void wb_table2_26_5M2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_21_5M2e( true) ;
         }
         else
         {
            wb_table1_21_5M2e( false) ;
         }
      }

      protected void wb_table2_26_5M2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'" + sPrefix + "',false,'" + sGXsfl_36_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV18FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV18FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "Pesquisar", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_core\\wcDocumentoArquivo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_26_5M2e( true) ;
         }
         else
         {
            wb_table2_26_5M2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV69InDocID = (Guid)getParm(obj,0);
         AssignAttri(sPrefix, false, "AV69InDocID", AV69InDocID.ToString());
         AV70InDocVersaoIDPai = (Guid)getParm(obj,1);
         AssignAttri(sPrefix, false, "AV70InDocVersaoIDPai", AV70InDocVersaoIDPai.ToString());
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
         PA5M2( ) ;
         WS5M2( ) ;
         WE5M2( ) ;
         this.cleanup();
         context.SetWrapped(false);
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      protected override EncryptionType GetEncryptionType( )
      {
         return EncryptionType.SESSION ;
      }

      public override void componentbind( Object[] obj )
      {
         if ( IsUrlCreated( ) )
         {
            return  ;
         }
         sCtrlAV69InDocID = (string)((string)getParm(obj,0));
         sCtrlAV70InDocVersaoIDPai = (string)((string)getParm(obj,1));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA5M2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "core\\wcdocumentoarquivo", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA5M2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV69InDocID = (Guid)getParm(obj,2);
            AssignAttri(sPrefix, false, "AV69InDocID", AV69InDocID.ToString());
            AV70InDocVersaoIDPai = (Guid)getParm(obj,3);
            AssignAttri(sPrefix, false, "AV70InDocVersaoIDPai", AV70InDocVersaoIDPai.ToString());
         }
         wcpOAV69InDocID = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOAV69InDocID"));
         wcpOAV70InDocVersaoIDPai = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOAV70InDocVersaoIDPai"));
         if ( ! GetJustCreated( ) && ( ( AV69InDocID != wcpOAV69InDocID ) || ( AV70InDocVersaoIDPai != wcpOAV70InDocVersaoIDPai ) ) )
         {
            setjustcreated();
         }
         wcpOAV69InDocID = AV69InDocID;
         wcpOAV70InDocVersaoIDPai = AV70InDocVersaoIDPai;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV69InDocID = cgiGet( sPrefix+"AV69InDocID_CTRL");
         if ( StringUtil.Len( sCtrlAV69InDocID) > 0 )
         {
            AV69InDocID = StringUtil.StrToGuid( cgiGet( sCtrlAV69InDocID));
            AssignAttri(sPrefix, false, "AV69InDocID", AV69InDocID.ToString());
         }
         else
         {
            AV69InDocID = StringUtil.StrToGuid( cgiGet( sPrefix+"AV69InDocID_PARM"));
         }
         sCtrlAV70InDocVersaoIDPai = cgiGet( sPrefix+"AV70InDocVersaoIDPai_CTRL");
         if ( StringUtil.Len( sCtrlAV70InDocVersaoIDPai) > 0 )
         {
            AV70InDocVersaoIDPai = StringUtil.StrToGuid( cgiGet( sCtrlAV70InDocVersaoIDPai));
            AssignAttri(sPrefix, false, "AV70InDocVersaoIDPai", AV70InDocVersaoIDPai.ToString());
         }
         else
         {
            AV70InDocVersaoIDPai = StringUtil.StrToGuid( cgiGet( sPrefix+"AV70InDocVersaoIDPai_PARM"));
         }
      }

      public override void componentprocess( string sPPrefix ,
                                             string sPSFPrefix ,
                                             string sCompEvt )
      {
         sCompPrefix = sPPrefix;
         sSFPrefix = sPSFPrefix;
         sPrefix = sCompPrefix + sSFPrefix;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         INITWEB( ) ;
         nDraw = 0;
         PA5M2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS5M2( ) ;
         if ( isFullAjaxMode( ) )
         {
            componentdraw();
         }
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override void componentstart( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
      }

      protected void WCStart( )
      {
         nDraw = 1;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WS5M2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV69InDocID_PARM", AV69InDocID.ToString());
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV69InDocID)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV69InDocID_CTRL", StringUtil.RTrim( sCtrlAV69InDocID));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV70InDocVersaoIDPai_PARM", AV70InDocVersaoIDPai.ToString());
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV70InDocVersaoIDPai)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV70InDocVersaoIDPai_CTRL", StringUtil.RTrim( sCtrlAV70InDocVersaoIDPai));
         }
      }

      public override void componentdraw( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WCParametersSet( ) ;
         WE5M2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override string getstring( string sGXControl )
      {
         string sCtrlName;
         if ( StringUtil.StrCmp(StringUtil.Substring( sGXControl, 1, 1), "&") == 0 )
         {
            sCtrlName = StringUtil.Substring( sGXControl, 2, StringUtil.Len( sGXControl)-1);
         }
         else
         {
            sCtrlName = sGXControl;
         }
         return cgiGet( sPrefix+"v"+StringUtil.Upper( sCtrlName)) ;
      }

      public override void componentjscripts( )
      {
         include_jscripts( ) ;
         if ( ! ( WebComp_Wwpaux_wc == null ) )
         {
            WebComp_Wwpaux_wc.componentjscripts();
         }
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
      }

      protected void define_styles( )
      {
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2023828155425", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         CloseStyles();
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("core/wcdocumentoarquivo.js", "?2023828155426", false, true);
         context.AddJavascriptSource("web-extension/gx-web-extensions.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
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

      protected void SubsflControlProps_362( )
      {
         cmbavGridactions_Internalname = sPrefix+"vGRIDACTIONS_"+sGXsfl_36_idx;
         edtDocID_Internalname = sPrefix+"DOCID_"+sGXsfl_36_idx;
         edtDocArqSeq_Internalname = sPrefix+"DOCARQSEQ_"+sGXsfl_36_idx;
         edtDocArqConteudoNome_Internalname = sPrefix+"DOCARQCONTEUDONOME_"+sGXsfl_36_idx;
         edtDocArqConteudoExtensao_Internalname = sPrefix+"DOCARQCONTEUDOEXTENSAO_"+sGXsfl_36_idx;
         edtDocVersao_Internalname = sPrefix+"DOCVERSAO_"+sGXsfl_36_idx;
         edtDocArqInsDataHora_Internalname = sPrefix+"DOCARQINSDATAHORA_"+sGXsfl_36_idx;
         edtDocArqObservacao_Internalname = sPrefix+"DOCARQOBSERVACAO_"+sGXsfl_36_idx;
      }

      protected void SubsflControlProps_fel_362( )
      {
         cmbavGridactions_Internalname = sPrefix+"vGRIDACTIONS_"+sGXsfl_36_fel_idx;
         edtDocID_Internalname = sPrefix+"DOCID_"+sGXsfl_36_fel_idx;
         edtDocArqSeq_Internalname = sPrefix+"DOCARQSEQ_"+sGXsfl_36_fel_idx;
         edtDocArqConteudoNome_Internalname = sPrefix+"DOCARQCONTEUDONOME_"+sGXsfl_36_fel_idx;
         edtDocArqConteudoExtensao_Internalname = sPrefix+"DOCARQCONTEUDOEXTENSAO_"+sGXsfl_36_fel_idx;
         edtDocVersao_Internalname = sPrefix+"DOCVERSAO_"+sGXsfl_36_fel_idx;
         edtDocArqInsDataHora_Internalname = sPrefix+"DOCARQINSDATAHORA_"+sGXsfl_36_fel_idx;
         edtDocArqObservacao_Internalname = sPrefix+"DOCARQOBSERVACAO_"+sGXsfl_36_fel_idx;
      }

      protected void sendrow_362( )
      {
         SubsflControlProps_362( ) ;
         WB5M0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_36_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_36_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " class=\""+"WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_36_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = " " + ((cmbavGridactions.Enabled!=0)&&(cmbavGridactions.Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 37,'"+sPrefix+"',false,'"+sGXsfl_36_idx+"',36)\"" : " ");
            if ( ( cmbavGridactions.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vGRIDACTIONS_" + sGXsfl_36_idx;
               cmbavGridactions.Name = GXCCtl;
               cmbavGridactions.WebTags = "";
               if ( cmbavGridactions.ItemCount > 0 )
               {
                  AV57GridActions = (short)(Math.Round(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV57GridActions), 4, 0))), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV57GridActions), 4, 0));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavGridactions,(string)cmbavGridactions_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV57GridActions), 4, 0)),(short)1,(string)cmbavGridactions_Jsonclick,(short)5,"'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EVGRIDACTIONS.CLICK."+sGXsfl_36_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"ConvertToDDO",(string)"WWActionGroupColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((cmbavGridactions.Enabled!=0)&&(cmbavGridactions.Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,37);\"" : " "),(string)"",(bool)true,(short)0});
            cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV57GridActions), 4, 0));
            AssignProp(sPrefix, false, cmbavGridactions_Internalname, "Values", (string)(cmbavGridactions.ToJavascriptSource()), !bGXsfl_36_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDocID_Internalname,A289DocID.ToString(),A289DocID.ToString(),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDocID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)36,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDocArqSeq_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A307DocArqSeq), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A307DocArqSeq), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDocArqSeq_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)36,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDocArqConteudoNome_Internalname,(string)A322DocArqConteudoNome,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDocArqConteudoNome_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)2000,(short)0,(short)0,(short)36,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDocArqConteudoExtensao_Internalname,(string)A323DocArqConteudoExtensao,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDocArqConteudoExtensao_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)36,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDocVersao_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A325DocVersao), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A325DocVersao), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDocVersao_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)36,(short)0,(short)-1,(short)0,(bool)true,(string)"core\\Versao",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDocArqInsDataHora_Internalname,context.localUtil.TToC( A310DocArqInsDataHora, 10, 12, 0, 3, "/", ":", " "),context.localUtil.Format( A310DocArqInsDataHora, "99/99/9999 99:99:99.999"),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDocArqInsDataHora_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)24,(short)0,(short)0,(short)36,(short)0,(short)-1,(short)0,(bool)true,(string)"core\\DataHoraSegundoMS",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDocArqObservacao_Internalname,(string)A324DocArqObservacao,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDocArqObservacao_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)2000,(short)0,(short)0,(short)36,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes5M2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_36_idx = ((subGrid_Islastpage==1)&&(nGXsfl_36_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_36_idx+1);
            sGXsfl_36_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_36_idx), 4, 0), 4, "0");
            SubsflControlProps_362( ) ;
         }
         /* End function sendrow_362 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "vGRIDACTIONS_" + sGXsfl_36_idx;
         cmbavGridactions.Name = GXCCtl;
         cmbavGridactions.WebTags = "";
         if ( cmbavGridactions.ItemCount > 0 )
         {
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl36( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"DivS\" data-gxgridid=\"36\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid_Internalname, subGrid_Internalname, "", "WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
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
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"ConvertToDDO"+"\" "+" style=\""+""+""+"\" "+">") ;
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
            context.SendWebValue( "Versão") ;
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
            GridContainer.AddObjectProperty("Class", "WorkWith");
            GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("CmpContext", sPrefix);
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV57GridActions), 4, 0, ".", ""))));
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A325DocVersao), 4, 0, ".", ""))));
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
         bttBtnagexport_Internalname = sPrefix+"BTNAGEXPORT";
         bttBtnsubscriptions_Internalname = sPrefix+"BTNSUBSCRIPTIONS";
         divTableactions_Internalname = sPrefix+"TABLEACTIONS";
         Ddo_managefilters_Internalname = sPrefix+"DDO_MANAGEFILTERS";
         edtavFilterfulltext_Internalname = sPrefix+"vFILTERFULLTEXT";
         tblTablefilters_Internalname = sPrefix+"TABLEFILTERS";
         tblTablerightheader_Internalname = sPrefix+"TABLERIGHTHEADER";
         divTableheadercontent_Internalname = sPrefix+"TABLEHEADERCONTENT";
         divTableheader_Internalname = sPrefix+"TABLEHEADER";
         cmbavGridactions_Internalname = sPrefix+"vGRIDACTIONS";
         edtDocID_Internalname = sPrefix+"DOCID";
         edtDocArqSeq_Internalname = sPrefix+"DOCARQSEQ";
         edtDocArqConteudoNome_Internalname = sPrefix+"DOCARQCONTEUDONOME";
         edtDocArqConteudoExtensao_Internalname = sPrefix+"DOCARQCONTEUDOEXTENSAO";
         edtDocVersao_Internalname = sPrefix+"DOCVERSAO";
         edtDocArqInsDataHora_Internalname = sPrefix+"DOCARQINSDATAHORA";
         edtDocArqObservacao_Internalname = sPrefix+"DOCARQOBSERVACAO";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         Ddo_agexport_Internalname = sPrefix+"DDO_AGEXPORT";
         Ddc_subscriptions_Internalname = sPrefix+"DDC_SUBSCRIPTIONS";
         Ddo_grid_Internalname = sPrefix+"DDO_GRID";
         Grid_empowerer_Internalname = sPrefix+"GRID_EMPOWERER";
         divDiv_wwpauxwc_Internalname = sPrefix+"DIV_WWPAUXWC";
         edtavDdo_docarqinsdatahoraauxdatetext_Internalname = sPrefix+"vDDO_DOCARQINSDATAHORAAUXDATETEXT";
         Tfdocarqinsdatahora_rangepicker_Internalname = sPrefix+"TFDOCARQINSDATAHORA_RANGEPICKER";
         divDdo_docarqinsdatahoraauxdates_Internalname = sPrefix+"DDO_DOCARQINSDATAHORAAUXDATES";
         divHtml_bottomauxiliarcontrols_Internalname = sPrefix+"HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subGrid_Internalname = sPrefix+"GRID";
      }

      public override void initialize_properties( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.SetDefaultTheme("WorkWithPlusDS", true);
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         init_default_properties( ) ;
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         subGrid_Header = "";
         edtDocArqObservacao_Jsonclick = "";
         edtDocArqInsDataHora_Jsonclick = "";
         edtDocVersao_Jsonclick = "";
         edtDocArqConteudoExtensao_Jsonclick = "";
         edtDocArqConteudoNome_Jsonclick = "";
         edtDocArqSeq_Jsonclick = "";
         edtDocID_Jsonclick = "";
         cmbavGridactions_Jsonclick = "";
         cmbavGridactions.Visible = -1;
         cmbavGridactions.Enabled = 1;
         subGrid_Class = "WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         subGrid_Sortable = 0;
         edtavDdo_docarqinsdatahoraauxdatetext_Jsonclick = "";
         bttBtnsubscriptions_Visible = 1;
         Grid_empowerer_Fixedcolumns = "L;;;;;;;";
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_grid_Datalistproc = "core.wcDocumentoArquivoGetFilterData";
         Ddo_grid_Datalisttype = "Dynamic|Dynamic||Dynamic";
         Ddo_grid_Includedatalist = "T|T||T";
         Ddo_grid_Filterisrange = "||P|";
         Ddo_grid_Filtertype = "Character|Character|Date|Character";
         Ddo_grid_Includefilter = "T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "2|3|4|5";
         Ddo_grid_Columnids = "3:DocArqConteudoNome|4:DocArqConteudoExtensao|6:DocArqInsDataHora|7:DocArqObservacao";
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
         Ddo_managefilters_Cls = "ManageFilters";
         Ddo_managefilters_Tooltip = "WWP_ManageFiltersTooltip";
         Ddo_managefilters_Icon = "fas fa-filter";
         Ddo_managefilters_Icontype = "FontIcon";
         subGrid_Rows = 0;
         context.GX_msglist.DisplayMode = 1;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'sPrefix'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV18FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV41TFDocArqConteudoNome',fld:'vTFDOCARQCONTEUDONOME',pic:''},{av:'AV42TFDocArqConteudoNome_Sel',fld:'vTFDOCARQCONTEUDONOME_SEL',pic:''},{av:'AV43TFDocArqConteudoExtensao',fld:'vTFDOCARQCONTEUDOEXTENSAO',pic:''},{av:'AV44TFDocArqConteudoExtensao_Sel',fld:'vTFDOCARQCONTEUDOEXTENSAO_SEL',pic:''},{av:'AV45TFDocArqInsDataHora',fld:'vTFDOCARQINSDATAHORA',pic:'99/99/9999 99:99:99.999'},{av:'AV46TFDocArqInsDataHora_To',fld:'vTFDOCARQINSDATAHORA_TO',pic:'99/99/9999 99:99:99.999'},{av:'AV50TFDocArqObservacao',fld:'vTFDOCARQOBSERVACAO',pic:''},{av:'AV51TFDocArqObservacao_Sel',fld:'vTFDOCARQOBSERVACAO_SEL',pic:''},{av:'AV15OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV16OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV69InDocID',fld:'vINDOCID',pic:''},{av:'AV70InDocVersaoIDPai',fld:'vINDOCVERSAOIDPAI',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV71Pgmname',fld:'vPGMNAME',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV38ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV12GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","{handler:'E145M2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV18FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV69InDocID',fld:'vINDOCID',pic:''},{av:'AV70InDocVersaoIDPai',fld:'vINDOCVERSAOIDPAI',pic:''},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV41TFDocArqConteudoNome',fld:'vTFDOCARQCONTEUDONOME',pic:''},{av:'AV42TFDocArqConteudoNome_Sel',fld:'vTFDOCARQCONTEUDONOME_SEL',pic:''},{av:'AV43TFDocArqConteudoExtensao',fld:'vTFDOCARQCONTEUDOEXTENSAO',pic:''},{av:'AV44TFDocArqConteudoExtensao_Sel',fld:'vTFDOCARQCONTEUDOEXTENSAO_SEL',pic:''},{av:'AV45TFDocArqInsDataHora',fld:'vTFDOCARQINSDATAHORA',pic:'99/99/9999 99:99:99.999'},{av:'AV46TFDocArqInsDataHora_To',fld:'vTFDOCARQINSDATAHORA_TO',pic:'99/99/9999 99:99:99.999'},{av:'AV50TFDocArqObservacao',fld:'vTFDOCARQOBSERVACAO',pic:''},{av:'AV51TFDocArqObservacao_Sel',fld:'vTFDOCARQOBSERVACAO_SEL',pic:''},{av:'AV71Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV15OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV16OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'sPrefix'},{av:'Ddo_grid_Activeeventkey',ctrl:'DDO_GRID',prop:'ActiveEventKey'},{av:'Ddo_grid_Selectedvalue_get',ctrl:'DDO_GRID',prop:'SelectedValue_get'},{av:'Ddo_grid_Selectedcolumn',ctrl:'DDO_GRID',prop:'SelectedColumn'},{av:'Ddo_grid_Filteredtext_get',ctrl:'DDO_GRID',prop:'FilteredText_get'},{av:'Ddo_grid_Filteredtextto_get',ctrl:'DDO_GRID',prop:'FilteredTextTo_get'}]");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",",oparms:[{av:'AV15OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV16OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV41TFDocArqConteudoNome',fld:'vTFDOCARQCONTEUDONOME',pic:''},{av:'AV42TFDocArqConteudoNome_Sel',fld:'vTFDOCARQCONTEUDONOME_SEL',pic:''},{av:'AV43TFDocArqConteudoExtensao',fld:'vTFDOCARQCONTEUDOEXTENSAO',pic:''},{av:'AV44TFDocArqConteudoExtensao_Sel',fld:'vTFDOCARQCONTEUDOEXTENSAO_SEL',pic:''},{av:'AV45TFDocArqInsDataHora',fld:'vTFDOCARQINSDATAHORA',pic:'99/99/9999 99:99:99.999'},{av:'AV46TFDocArqInsDataHora_To',fld:'vTFDOCARQINSDATAHORA_TO',pic:'99/99/9999 99:99:99.999'},{av:'AV50TFDocArqObservacao',fld:'vTFDOCARQOBSERVACAO',pic:''},{av:'AV51TFDocArqObservacao_Sel',fld:'vTFDOCARQOBSERVACAO_SEL',pic:''},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E175M2',iparms:[]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'cmbavGridactions'},{av:'AV57GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9'}]}");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","{handler:'E115M2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV18FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV69InDocID',fld:'vINDOCID',pic:''},{av:'AV70InDocVersaoIDPai',fld:'vINDOCVERSAOIDPAI',pic:''},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV41TFDocArqConteudoNome',fld:'vTFDOCARQCONTEUDONOME',pic:''},{av:'AV42TFDocArqConteudoNome_Sel',fld:'vTFDOCARQCONTEUDONOME_SEL',pic:''},{av:'AV43TFDocArqConteudoExtensao',fld:'vTFDOCARQCONTEUDOEXTENSAO',pic:''},{av:'AV44TFDocArqConteudoExtensao_Sel',fld:'vTFDOCARQCONTEUDOEXTENSAO_SEL',pic:''},{av:'AV45TFDocArqInsDataHora',fld:'vTFDOCARQINSDATAHORA',pic:'99/99/9999 99:99:99.999'},{av:'AV46TFDocArqInsDataHora_To',fld:'vTFDOCARQINSDATAHORA_TO',pic:'99/99/9999 99:99:99.999'},{av:'AV50TFDocArqObservacao',fld:'vTFDOCARQOBSERVACAO',pic:''},{av:'AV51TFDocArqObservacao_Sel',fld:'vTFDOCARQOBSERVACAO_SEL',pic:''},{av:'AV71Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV15OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV16OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'sPrefix'},{av:'Ddo_managefilters_Activeeventkey',ctrl:'DDO_MANAGEFILTERS',prop:'ActiveEventKey'},{av:'AV12GridState',fld:'vGRIDSTATE',pic:''},{av:'AV47DDO_DocArqInsDataHoraAuxDate',fld:'vDDO_DOCARQINSDATAHORAAUXDATE',pic:''},{av:'AV48DDO_DocArqInsDataHoraAuxDateTo',fld:'vDDO_DOCARQINSDATAHORAAUXDATETO',pic:''}]");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",",oparms:[{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV12GridState',fld:'vGRIDSTATE',pic:''},{av:'AV15OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV16OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV18FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV41TFDocArqConteudoNome',fld:'vTFDOCARQCONTEUDONOME',pic:''},{av:'AV42TFDocArqConteudoNome_Sel',fld:'vTFDOCARQCONTEUDONOME_SEL',pic:''},{av:'AV43TFDocArqConteudoExtensao',fld:'vTFDOCARQCONTEUDOEXTENSAO',pic:''},{av:'AV44TFDocArqConteudoExtensao_Sel',fld:'vTFDOCARQCONTEUDOEXTENSAO_SEL',pic:''},{av:'AV45TFDocArqInsDataHora',fld:'vTFDOCARQINSDATAHORA',pic:'99/99/9999 99:99:99.999'},{av:'AV46TFDocArqInsDataHora_To',fld:'vTFDOCARQINSDATAHORA_TO',pic:'99/99/9999 99:99:99.999'},{av:'AV50TFDocArqObservacao',fld:'vTFDOCARQOBSERVACAO',pic:''},{av:'AV51TFDocArqObservacao_Sel',fld:'vTFDOCARQOBSERVACAO_SEL',pic:''},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'AV47DDO_DocArqInsDataHoraAuxDate',fld:'vDDO_DOCARQINSDATAHORAAUXDATE',pic:''},{av:'AV48DDO_DocArqInsDataHoraAuxDateTo',fld:'vDDO_DOCARQINSDATAHORAAUXDATETO',pic:''},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV38ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VGRIDACTIONS.CLICK","{handler:'E185M2',iparms:[{av:'cmbavGridactions'},{av:'AV57GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9'},{av:'A289DocID',fld:'DOCID',pic:'',hsh:true},{av:'A307DocArqSeq',fld:'DOCARQSEQ',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("VGRIDACTIONS.CLICK",",oparms:[{av:'cmbavGridactions'},{av:'AV57GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9'}]}");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED","{handler:'E125M2',iparms:[{av:'Ddo_agexport_Activeeventkey',ctrl:'DDO_AGEXPORT',prop:'ActiveEventKey'}]");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED",",oparms:[]}");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT","{handler:'E135M2',iparms:[]");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT",",oparms:[{ctrl:'WWPAUX_WC'}]}");
         setEventMetadata("GRID_FIRSTPAGE","{handler:'subgrid_firstpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'sPrefix'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV18FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV41TFDocArqConteudoNome',fld:'vTFDOCARQCONTEUDONOME',pic:''},{av:'AV42TFDocArqConteudoNome_Sel',fld:'vTFDOCARQCONTEUDONOME_SEL',pic:''},{av:'AV43TFDocArqConteudoExtensao',fld:'vTFDOCARQCONTEUDOEXTENSAO',pic:''},{av:'AV44TFDocArqConteudoExtensao_Sel',fld:'vTFDOCARQCONTEUDOEXTENSAO_SEL',pic:''},{av:'AV45TFDocArqInsDataHora',fld:'vTFDOCARQINSDATAHORA',pic:'99/99/9999 99:99:99.999'},{av:'AV46TFDocArqInsDataHora_To',fld:'vTFDOCARQINSDATAHORA_TO',pic:'99/99/9999 99:99:99.999'},{av:'AV50TFDocArqObservacao',fld:'vTFDOCARQOBSERVACAO',pic:''},{av:'AV51TFDocArqObservacao_Sel',fld:'vTFDOCARQOBSERVACAO_SEL',pic:''},{av:'AV71Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV15OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV16OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV69InDocID',fld:'vINDOCID',pic:''},{av:'AV70InDocVersaoIDPai',fld:'vINDOCVERSAOIDPAI',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]");
         setEventMetadata("GRID_FIRSTPAGE",",oparms:[{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV38ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV12GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRID_PREVPAGE","{handler:'subgrid_previouspage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'sPrefix'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV18FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV41TFDocArqConteudoNome',fld:'vTFDOCARQCONTEUDONOME',pic:''},{av:'AV42TFDocArqConteudoNome_Sel',fld:'vTFDOCARQCONTEUDONOME_SEL',pic:''},{av:'AV43TFDocArqConteudoExtensao',fld:'vTFDOCARQCONTEUDOEXTENSAO',pic:''},{av:'AV44TFDocArqConteudoExtensao_Sel',fld:'vTFDOCARQCONTEUDOEXTENSAO_SEL',pic:''},{av:'AV45TFDocArqInsDataHora',fld:'vTFDOCARQINSDATAHORA',pic:'99/99/9999 99:99:99.999'},{av:'AV46TFDocArqInsDataHora_To',fld:'vTFDOCARQINSDATAHORA_TO',pic:'99/99/9999 99:99:99.999'},{av:'AV50TFDocArqObservacao',fld:'vTFDOCARQOBSERVACAO',pic:''},{av:'AV51TFDocArqObservacao_Sel',fld:'vTFDOCARQOBSERVACAO_SEL',pic:''},{av:'AV71Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV15OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV16OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV69InDocID',fld:'vINDOCID',pic:''},{av:'AV70InDocVersaoIDPai',fld:'vINDOCVERSAOIDPAI',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]");
         setEventMetadata("GRID_PREVPAGE",",oparms:[{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV38ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV12GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRID_NEXTPAGE","{handler:'subgrid_nextpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'sPrefix'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV18FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV41TFDocArqConteudoNome',fld:'vTFDOCARQCONTEUDONOME',pic:''},{av:'AV42TFDocArqConteudoNome_Sel',fld:'vTFDOCARQCONTEUDONOME_SEL',pic:''},{av:'AV43TFDocArqConteudoExtensao',fld:'vTFDOCARQCONTEUDOEXTENSAO',pic:''},{av:'AV44TFDocArqConteudoExtensao_Sel',fld:'vTFDOCARQCONTEUDOEXTENSAO_SEL',pic:''},{av:'AV45TFDocArqInsDataHora',fld:'vTFDOCARQINSDATAHORA',pic:'99/99/9999 99:99:99.999'},{av:'AV46TFDocArqInsDataHora_To',fld:'vTFDOCARQINSDATAHORA_TO',pic:'99/99/9999 99:99:99.999'},{av:'AV50TFDocArqObservacao',fld:'vTFDOCARQOBSERVACAO',pic:''},{av:'AV51TFDocArqObservacao_Sel',fld:'vTFDOCARQOBSERVACAO_SEL',pic:''},{av:'AV71Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV15OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV16OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV69InDocID',fld:'vINDOCID',pic:''},{av:'AV70InDocVersaoIDPai',fld:'vINDOCVERSAOIDPAI',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]");
         setEventMetadata("GRID_NEXTPAGE",",oparms:[{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV38ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV12GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRID_LASTPAGE","{handler:'subgrid_lastpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'sPrefix'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV18FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV41TFDocArqConteudoNome',fld:'vTFDOCARQCONTEUDONOME',pic:''},{av:'AV42TFDocArqConteudoNome_Sel',fld:'vTFDOCARQCONTEUDONOME_SEL',pic:''},{av:'AV43TFDocArqConteudoExtensao',fld:'vTFDOCARQCONTEUDOEXTENSAO',pic:''},{av:'AV44TFDocArqConteudoExtensao_Sel',fld:'vTFDOCARQCONTEUDOEXTENSAO_SEL',pic:''},{av:'AV45TFDocArqInsDataHora',fld:'vTFDOCARQINSDATAHORA',pic:'99/99/9999 99:99:99.999'},{av:'AV46TFDocArqInsDataHora_To',fld:'vTFDOCARQINSDATAHORA_TO',pic:'99/99/9999 99:99:99.999'},{av:'AV50TFDocArqObservacao',fld:'vTFDOCARQOBSERVACAO',pic:''},{av:'AV51TFDocArqObservacao_Sel',fld:'vTFDOCARQOBSERVACAO_SEL',pic:''},{av:'AV71Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV15OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV16OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV69InDocID',fld:'vINDOCID',pic:''},{av:'AV70InDocVersaoIDPai',fld:'vINDOCVERSAOIDPAI',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]");
         setEventMetadata("GRID_LASTPAGE",",oparms:[{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV38ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV12GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("VALID_DOCID","{handler:'Valid_Docid',iparms:[]");
         setEventMetadata("VALID_DOCID",",oparms:[]}");
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
         wcpOAV69InDocID = Guid.Empty;
         wcpOAV70InDocVersaoIDPai = Guid.Empty;
         Ddo_grid_Activeeventkey = "";
         Ddo_grid_Selectedvalue_get = "";
         Ddo_grid_Selectedcolumn = "";
         Ddo_grid_Filteredtext_get = "";
         Ddo_grid_Filteredtextto_get = "";
         Ddo_managefilters_Activeeventkey = "";
         Ddo_agexport_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV18FilterFullText = "";
         AV41TFDocArqConteudoNome = "";
         AV42TFDocArqConteudoNome_Sel = "";
         AV43TFDocArqConteudoExtensao = "";
         AV44TFDocArqConteudoExtensao_Sel = "";
         AV45TFDocArqInsDataHora = (DateTime)(DateTime.MinValue);
         AV46TFDocArqInsDataHora_To = (DateTime)(DateTime.MinValue);
         AV50TFDocArqObservacao = "";
         AV51TFDocArqObservacao_Sel = "";
         AV71Pgmname = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV38ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV60AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV52DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV47DDO_DocArqInsDataHoraAuxDate = DateTime.MinValue;
         AV48DDO_DocArqInsDataHoraAuxDateTo = DateTime.MinValue;
         AV12GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         Ddo_agexport_Caption = "";
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Filteredtextto_set = "";
         Ddo_grid_Selectedvalue_set = "";
         Ddo_grid_Sortedstatus = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtnagexport_Jsonclick = "";
         bttBtnsubscriptions_Jsonclick = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucDdo_agexport = new GXUserControl();
         ucDdc_subscriptions = new GXUserControl();
         ucDdo_grid = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         WebComp_Wwpaux_wc_Component = "";
         OldWwpaux_wc = "";
         AV49DDO_DocArqInsDataHoraAuxDateText = "";
         ucTfdocarqinsdatahora_rangepicker = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV72Core_wcdocumentoarquivods_1_filterfulltext = "";
         AV73Core_wcdocumentoarquivods_2_tfdocarqconteudonome = "";
         AV74Core_wcdocumentoarquivods_3_tfdocarqconteudonome_sel = "";
         AV75Core_wcdocumentoarquivods_4_tfdocarqconteudoextensao = "";
         AV76Core_wcdocumentoarquivods_5_tfdocarqconteudoextensao_sel = "";
         AV77Core_wcdocumentoarquivods_6_tfdocarqinsdatahora = (DateTime)(DateTime.MinValue);
         AV78Core_wcdocumentoarquivods_7_tfdocarqinsdatahora_to = (DateTime)(DateTime.MinValue);
         AV79Core_wcdocumentoarquivods_8_tfdocarqobservacao = "";
         AV80Core_wcdocumentoarquivods_9_tfdocarqobservacao_sel = "";
         A289DocID = Guid.Empty;
         A322DocArqConteudoNome = "";
         A323DocArqConteudoExtensao = "";
         A310DocArqInsDataHora = (DateTime)(DateTime.MinValue);
         A324DocArqObservacao = "";
         GXDecQS = "";
         scmdbuf = "";
         lV72Core_wcdocumentoarquivods_1_filterfulltext = "";
         lV73Core_wcdocumentoarquivods_2_tfdocarqconteudonome = "";
         lV75Core_wcdocumentoarquivods_4_tfdocarqconteudoextensao = "";
         lV79Core_wcdocumentoarquivods_8_tfdocarqobservacao = "";
         A326DocVersaoIDPai = Guid.Empty;
         H005M2_A326DocVersaoIDPai = new Guid[] {Guid.Empty} ;
         H005M2_n326DocVersaoIDPai = new bool[] {false} ;
         H005M2_A308DocArqInsData = new DateTime[] {DateTime.MinValue} ;
         H005M2_A324DocArqObservacao = new string[] {""} ;
         H005M2_n324DocArqObservacao = new bool[] {false} ;
         H005M2_A310DocArqInsDataHora = new DateTime[] {DateTime.MinValue} ;
         H005M2_A325DocVersao = new short[1] ;
         H005M2_A323DocArqConteudoExtensao = new string[] {""} ;
         H005M2_A322DocArqConteudoNome = new string[] {""} ;
         H005M2_A307DocArqSeq = new short[1] ;
         H005M2_A289DocID = new Guid[] {Guid.Empty} ;
         A308DocArqInsData = DateTime.MinValue;
         H005M3_AGRID_nRecordCount = new long[1] ;
         AV61AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GridRow = new GXWebRow();
         AV39ManageFiltersXml = "";
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV65Url = "";
         AV37Session = context.GetSession();
         AV13GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char5 = "";
         GXt_char4 = "";
         GXt_char2 = "";
         AV10TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV9HTTPRequest = new GxHttpRequest( context);
         AV35ExcelFilename = "";
         AV36ErrorMessage = "";
         ucDdo_managefilters = new GXUserControl();
         Ddo_managefilters_Caption = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV69InDocID = "";
         sCtrlAV70InDocVersaoIDPai = "";
         subGrid_Linesclass = "";
         GXCCtl = "";
         ROClassString = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.wcdocumentoarquivo__default(),
            new Object[][] {
                new Object[] {
               H005M2_A326DocVersaoIDPai, H005M2_n326DocVersaoIDPai, H005M2_A308DocArqInsData, H005M2_A324DocArqObservacao, H005M2_n324DocArqObservacao, H005M2_A310DocArqInsDataHora, H005M2_A325DocVersao, H005M2_A323DocArqConteudoExtensao, H005M2_A322DocArqConteudoNome, H005M2_A307DocArqSeq,
               H005M2_A289DocID
               }
               , new Object[] {
               H005M3_AGRID_nRecordCount
               }
            }
         );
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         AV71Pgmname = "core.wcDocumentoArquivo";
         /* GeneXus formulas. */
         AV71Pgmname = "core.wcDocumentoArquivo";
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV40ManageFiltersExecutionStep ;
      private short AV15OrderedBy ;
      private short initialized ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short AV57GridActions ;
      private short A307DocArqSeq ;
      private short A325DocVersao ;
      private short nCmpId ;
      private short nDonePA ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int subGrid_Rows ;
      private int nRC_GXsfl_36 ;
      private int nGXsfl_36_idx=1 ;
      private int bttBtnsubscriptions_Visible ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int AV81GXV1 ;
      private int edtavFilterfulltext_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_managefilters_Activeeventkey ;
      private string Ddo_agexport_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_36_idx="0001" ;
      private string AV71Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
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
      private string Ddo_grid_Caption ;
      private string Ddo_grid_Filteredtext_set ;
      private string Ddo_grid_Filteredtextto_set ;
      private string Ddo_grid_Selectedvalue_set ;
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
      private string bttBtnsubscriptions_Internalname ;
      private string bttBtnsubscriptions_Jsonclick ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Ddo_agexport_Internalname ;
      private string Ddc_subscriptions_Internalname ;
      private string Ddo_grid_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string divDiv_wwpauxwc_Internalname ;
      private string WebComp_Wwpaux_wc_Component ;
      private string OldWwpaux_wc ;
      private string divDdo_docarqinsdatahoraauxdates_Internalname ;
      private string edtavDdo_docarqinsdatahoraauxdatetext_Internalname ;
      private string edtavDdo_docarqinsdatahoraauxdatetext_Jsonclick ;
      private string Tfdocarqinsdatahora_rangepicker_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string cmbavGridactions_Internalname ;
      private string edtDocID_Internalname ;
      private string edtDocArqSeq_Internalname ;
      private string edtDocArqConteudoNome_Internalname ;
      private string edtDocArqConteudoExtensao_Internalname ;
      private string edtDocVersao_Internalname ;
      private string edtDocArqInsDataHora_Internalname ;
      private string edtDocArqObservacao_Internalname ;
      private string GXDecQS ;
      private string edtavFilterfulltext_Internalname ;
      private string scmdbuf ;
      private string GXt_char5 ;
      private string GXt_char4 ;
      private string GXt_char2 ;
      private string tblTablerightheader_Internalname ;
      private string Ddo_managefilters_Caption ;
      private string Ddo_managefilters_Internalname ;
      private string tblTablefilters_Internalname ;
      private string edtavFilterfulltext_Jsonclick ;
      private string sCtrlAV69InDocID ;
      private string sCtrlAV70InDocVersaoIDPai ;
      private string sGXsfl_36_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string GXCCtl ;
      private string cmbavGridactions_Jsonclick ;
      private string ROClassString ;
      private string edtDocID_Jsonclick ;
      private string edtDocArqSeq_Jsonclick ;
      private string edtDocArqConteudoNome_Jsonclick ;
      private string edtDocArqConteudoExtensao_Jsonclick ;
      private string edtDocVersao_Jsonclick ;
      private string edtDocArqInsDataHora_Jsonclick ;
      private string edtDocArqObservacao_Jsonclick ;
      private string subGrid_Header ;
      private DateTime AV45TFDocArqInsDataHora ;
      private DateTime AV46TFDocArqInsDataHora_To ;
      private DateTime AV77Core_wcdocumentoarquivods_6_tfdocarqinsdatahora ;
      private DateTime AV78Core_wcdocumentoarquivods_7_tfdocarqinsdatahora_to ;
      private DateTime A310DocArqInsDataHora ;
      private DateTime AV47DDO_DocArqInsDataHoraAuxDate ;
      private DateTime AV48DDO_DocArqInsDataHoraAuxDateTo ;
      private DateTime A308DocArqInsData ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV16OrderedDsc ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool wbLoad ;
      private bool bGXsfl_36_Refreshing=false ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n324DocArqObservacao ;
      private bool gxdyncontrolsrefreshing ;
      private bool n326DocVersaoIDPai ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool bDynCreated_Wwpaux_wc ;
      private string AV39ManageFiltersXml ;
      private string AV18FilterFullText ;
      private string AV41TFDocArqConteudoNome ;
      private string AV42TFDocArqConteudoNome_Sel ;
      private string AV43TFDocArqConteudoExtensao ;
      private string AV44TFDocArqConteudoExtensao_Sel ;
      private string AV50TFDocArqObservacao ;
      private string AV51TFDocArqObservacao_Sel ;
      private string AV49DDO_DocArqInsDataHoraAuxDateText ;
      private string AV72Core_wcdocumentoarquivods_1_filterfulltext ;
      private string AV73Core_wcdocumentoarquivods_2_tfdocarqconteudonome ;
      private string AV74Core_wcdocumentoarquivods_3_tfdocarqconteudonome_sel ;
      private string AV75Core_wcdocumentoarquivods_4_tfdocarqconteudoextensao ;
      private string AV76Core_wcdocumentoarquivods_5_tfdocarqconteudoextensao_sel ;
      private string AV79Core_wcdocumentoarquivods_8_tfdocarqobservacao ;
      private string AV80Core_wcdocumentoarquivods_9_tfdocarqobservacao_sel ;
      private string A322DocArqConteudoNome ;
      private string A323DocArqConteudoExtensao ;
      private string A324DocArqObservacao ;
      private string lV72Core_wcdocumentoarquivods_1_filterfulltext ;
      private string lV73Core_wcdocumentoarquivods_2_tfdocarqconteudonome ;
      private string lV75Core_wcdocumentoarquivods_4_tfdocarqconteudoextensao ;
      private string lV79Core_wcdocumentoarquivods_8_tfdocarqobservacao ;
      private string AV65Url ;
      private string AV35ExcelFilename ;
      private string AV36ErrorMessage ;
      private Guid AV69InDocID ;
      private Guid AV70InDocVersaoIDPai ;
      private Guid wcpOAV69InDocID ;
      private Guid wcpOAV70InDocVersaoIDPai ;
      private Guid A289DocID ;
      private Guid A326DocVersaoIDPai ;
      private IGxSession AV37Session ;
      private GXWebComponent WebComp_Wwpaux_wc ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDdo_agexport ;
      private GXUserControl ucDdc_subscriptions ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucTfdocarqinsdatahora_rangepicker ;
      private GXUserControl ucDdo_managefilters ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavGridactions ;
      private IDataStoreProvider pr_default ;
      private Guid[] H005M2_A326DocVersaoIDPai ;
      private bool[] H005M2_n326DocVersaoIDPai ;
      private DateTime[] H005M2_A308DocArqInsData ;
      private string[] H005M2_A324DocArqObservacao ;
      private bool[] H005M2_n324DocArqObservacao ;
      private DateTime[] H005M2_A310DocArqInsDataHora ;
      private short[] H005M2_A325DocVersao ;
      private string[] H005M2_A323DocArqConteudoExtensao ;
      private string[] H005M2_A322DocArqConteudoNome ;
      private short[] H005M2_A307DocArqSeq ;
      private Guid[] H005M2_A289DocID ;
      private long[] H005M3_AGRID_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV9HTTPRequest ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV38ManageFiltersData ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV60AGExportData ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item3 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV10TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV12GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV13GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item AV61AGExportDataItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV52DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
   }

   public class wcdocumentoarquivo__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H005M2( IGxContext context ,
                                             string AV72Core_wcdocumentoarquivods_1_filterfulltext ,
                                             string AV74Core_wcdocumentoarquivods_3_tfdocarqconteudonome_sel ,
                                             string AV73Core_wcdocumentoarquivods_2_tfdocarqconteudonome ,
                                             string AV76Core_wcdocumentoarquivods_5_tfdocarqconteudoextensao_sel ,
                                             string AV75Core_wcdocumentoarquivods_4_tfdocarqconteudoextensao ,
                                             DateTime AV77Core_wcdocumentoarquivods_6_tfdocarqinsdatahora ,
                                             DateTime AV78Core_wcdocumentoarquivods_7_tfdocarqinsdatahora_to ,
                                             string AV80Core_wcdocumentoarquivods_9_tfdocarqobservacao_sel ,
                                             string AV79Core_wcdocumentoarquivods_8_tfdocarqobservacao ,
                                             string A322DocArqConteudoNome ,
                                             string A323DocArqConteudoExtensao ,
                                             short A325DocVersao ,
                                             string A324DocArqObservacao ,
                                             DateTime A310DocArqInsDataHora ,
                                             short AV15OrderedBy ,
                                             bool AV16OrderedDsc ,
                                             Guid A289DocID ,
                                             Guid AV70InDocVersaoIDPai ,
                                             Guid A326DocVersaoIDPai ,
                                             Guid AV69InDocID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[20];
         Object[] GXv_Object7 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T2.DocVersaoIDPai, T1.DocArqInsData, T1.DocArqObservacao, T1.DocArqInsDataHora, T2.DocVersao, T1.DocArqConteudoExtensao, T1.DocArqConteudoNome, T1.DocArqSeq, T1.DocID";
         sFromString = " FROM (tb_documento_arquivo T1 INNER JOIN tb_documento T2 ON T2.DocID = T1.DocID)";
         sOrderString = "";
         AddWhere(sWhereString, "(( ( ( T1.DocID = :AV70InDocVersaoIDPai or T2.DocVersaoIDPai = :AV70InDocVersaoIDPai) and Not (:AV70InDocVersaoIDPai = '00000000-0000-0000-0000-000000000000')) or ( T1.DocID = :AV69InDocID and (:AV70InDocVersaoIDPai = '00000000-0000-0000-0000-000000000000'))))");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Core_wcdocumentoarquivods_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.DocArqConteudoNome like '%' || :lV72Core_wcdocumentoarquivods_1_filterfulltext) or ( T1.DocArqConteudoExtensao like '%' || :lV72Core_wcdocumentoarquivods_1_filterfulltext) or ( SUBSTR(TO_CHAR(T2.DocVersao,'9999'), 2) like '%' || :lV72Core_wcdocumentoarquivods_1_filterfulltext) or ( T1.DocArqObservacao like '%' || :lV72Core_wcdocumentoarquivods_1_filterfulltext))");
         }
         else
         {
            GXv_int6[5] = 1;
            GXv_int6[6] = 1;
            GXv_int6[7] = 1;
            GXv_int6[8] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Core_wcdocumentoarquivods_3_tfdocarqconteudonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Core_wcdocumentoarquivods_2_tfdocarqconteudonome)) ) )
         {
            AddWhere(sWhereString, "(T1.DocArqConteudoNome like :lV73Core_wcdocumentoarquivods_2_tfdocarqconteudonome)");
         }
         else
         {
            GXv_int6[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Core_wcdocumentoarquivods_3_tfdocarqconteudonome_sel)) && ! ( StringUtil.StrCmp(AV74Core_wcdocumentoarquivods_3_tfdocarqconteudonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.DocArqConteudoNome = ( :AV74Core_wcdocumentoarquivods_3_tfdocarqconteudonome_sel))");
         }
         else
         {
            GXv_int6[10] = 1;
         }
         if ( StringUtil.StrCmp(AV74Core_wcdocumentoarquivods_3_tfdocarqconteudonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.DocArqConteudoNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Core_wcdocumentoarquivods_5_tfdocarqconteudoextensao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Core_wcdocumentoarquivods_4_tfdocarqconteudoextensao)) ) )
         {
            AddWhere(sWhereString, "(T1.DocArqConteudoExtensao like :lV75Core_wcdocumentoarquivods_4_tfdocarqconteudoextensao)");
         }
         else
         {
            GXv_int6[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Core_wcdocumentoarquivods_5_tfdocarqconteudoextensao_sel)) && ! ( StringUtil.StrCmp(AV76Core_wcdocumentoarquivods_5_tfdocarqconteudoextensao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.DocArqConteudoExtensao = ( :AV76Core_wcdocumentoarquivods_5_tfdocarqconteudoextensao_sel))");
         }
         else
         {
            GXv_int6[12] = 1;
         }
         if ( StringUtil.StrCmp(AV76Core_wcdocumentoarquivods_5_tfdocarqconteudoextensao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.DocArqConteudoExtensao))=0))");
         }
         if ( ! (DateTime.MinValue==AV77Core_wcdocumentoarquivods_6_tfdocarqinsdatahora) )
         {
            AddWhere(sWhereString, "(T1.DocArqInsDataHora >= :AV77Core_wcdocumentoarquivods_6_tfdocarqinsdatahora)");
         }
         else
         {
            GXv_int6[13] = 1;
         }
         if ( ! (DateTime.MinValue==AV78Core_wcdocumentoarquivods_7_tfdocarqinsdatahora_to) )
         {
            AddWhere(sWhereString, "(T1.DocArqInsDataHora <= :AV78Core_wcdocumentoarquivods_7_tfdocarqinsdatahora_to)");
         }
         else
         {
            GXv_int6[14] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Core_wcdocumentoarquivods_9_tfdocarqobservacao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Core_wcdocumentoarquivods_8_tfdocarqobservacao)) ) )
         {
            AddWhere(sWhereString, "(T1.DocArqObservacao like :lV79Core_wcdocumentoarquivods_8_tfdocarqobservacao)");
         }
         else
         {
            GXv_int6[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Core_wcdocumentoarquivods_9_tfdocarqobservacao_sel)) && ! ( StringUtil.StrCmp(AV80Core_wcdocumentoarquivods_9_tfdocarqobservacao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.DocArqObservacao = ( :AV80Core_wcdocumentoarquivods_9_tfdocarqobservacao_sel))");
         }
         else
         {
            GXv_int6[16] = 1;
         }
         if ( StringUtil.StrCmp(AV80Core_wcdocumentoarquivods_9_tfdocarqobservacao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.DocArqObservacao IS NULL or (char_length(trim(trailing ' ' from T1.DocArqObservacao))=0))");
         }
         if ( AV15OrderedBy == 1 )
         {
            sOrderString += " ORDER BY T1.DocArqInsData, T1.DocID, T1.DocArqSeq";
         }
         else if ( ( AV15OrderedBy == 2 ) && ! AV16OrderedDsc )
         {
            sOrderString += " ORDER BY T1.DocArqConteudoNome, T1.DocID, T1.DocArqSeq";
         }
         else if ( ( AV15OrderedBy == 2 ) && ( AV16OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.DocArqConteudoNome DESC, T1.DocID, T1.DocArqSeq";
         }
         else if ( ( AV15OrderedBy == 3 ) && ! AV16OrderedDsc )
         {
            sOrderString += " ORDER BY T1.DocArqConteudoExtensao, T1.DocID, T1.DocArqSeq";
         }
         else if ( ( AV15OrderedBy == 3 ) && ( AV16OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.DocArqConteudoExtensao DESC, T1.DocID, T1.DocArqSeq";
         }
         else if ( ( AV15OrderedBy == 4 ) && ! AV16OrderedDsc )
         {
            sOrderString += " ORDER BY T1.DocArqInsDataHora, T1.DocID, T1.DocArqSeq";
         }
         else if ( ( AV15OrderedBy == 4 ) && ( AV16OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.DocArqInsDataHora DESC, T1.DocID, T1.DocArqSeq";
         }
         else if ( ( AV15OrderedBy == 5 ) && ! AV16OrderedDsc )
         {
            sOrderString += " ORDER BY T1.DocArqObservacao, T1.DocID, T1.DocArqSeq";
         }
         else if ( ( AV15OrderedBy == 5 ) && ( AV16OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.DocArqObservacao DESC, T1.DocID, T1.DocArqSeq";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.DocID, T1.DocArqSeq";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      protected Object[] conditional_H005M3( IGxContext context ,
                                             string AV72Core_wcdocumentoarquivods_1_filterfulltext ,
                                             string AV74Core_wcdocumentoarquivods_3_tfdocarqconteudonome_sel ,
                                             string AV73Core_wcdocumentoarquivods_2_tfdocarqconteudonome ,
                                             string AV76Core_wcdocumentoarquivods_5_tfdocarqconteudoextensao_sel ,
                                             string AV75Core_wcdocumentoarquivods_4_tfdocarqconteudoextensao ,
                                             DateTime AV77Core_wcdocumentoarquivods_6_tfdocarqinsdatahora ,
                                             DateTime AV78Core_wcdocumentoarquivods_7_tfdocarqinsdatahora_to ,
                                             string AV80Core_wcdocumentoarquivods_9_tfdocarqobservacao_sel ,
                                             string AV79Core_wcdocumentoarquivods_8_tfdocarqobservacao ,
                                             string A322DocArqConteudoNome ,
                                             string A323DocArqConteudoExtensao ,
                                             short A325DocVersao ,
                                             string A324DocArqObservacao ,
                                             DateTime A310DocArqInsDataHora ,
                                             short AV15OrderedBy ,
                                             bool AV16OrderedDsc ,
                                             Guid A289DocID ,
                                             Guid AV70InDocVersaoIDPai ,
                                             Guid A326DocVersaoIDPai ,
                                             Guid AV69InDocID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[17];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM (tb_documento_arquivo T1 INNER JOIN tb_documento T2 ON T2.DocID = T1.DocID)";
         AddWhere(sWhereString, "(( ( ( T1.DocID = :AV70InDocVersaoIDPai or T2.DocVersaoIDPai = :AV70InDocVersaoIDPai) and Not (:AV70InDocVersaoIDPai = '00000000-0000-0000-0000-000000000000')) or ( T1.DocID = :AV69InDocID and (:AV70InDocVersaoIDPai = '00000000-0000-0000-0000-000000000000'))))");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Core_wcdocumentoarquivods_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.DocArqConteudoNome like '%' || :lV72Core_wcdocumentoarquivods_1_filterfulltext) or ( T1.DocArqConteudoExtensao like '%' || :lV72Core_wcdocumentoarquivods_1_filterfulltext) or ( SUBSTR(TO_CHAR(T2.DocVersao,'9999'), 2) like '%' || :lV72Core_wcdocumentoarquivods_1_filterfulltext) or ( T1.DocArqObservacao like '%' || :lV72Core_wcdocumentoarquivods_1_filterfulltext))");
         }
         else
         {
            GXv_int8[5] = 1;
            GXv_int8[6] = 1;
            GXv_int8[7] = 1;
            GXv_int8[8] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Core_wcdocumentoarquivods_3_tfdocarqconteudonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Core_wcdocumentoarquivods_2_tfdocarqconteudonome)) ) )
         {
            AddWhere(sWhereString, "(T1.DocArqConteudoNome like :lV73Core_wcdocumentoarquivods_2_tfdocarqconteudonome)");
         }
         else
         {
            GXv_int8[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Core_wcdocumentoarquivods_3_tfdocarqconteudonome_sel)) && ! ( StringUtil.StrCmp(AV74Core_wcdocumentoarquivods_3_tfdocarqconteudonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.DocArqConteudoNome = ( :AV74Core_wcdocumentoarquivods_3_tfdocarqconteudonome_sel))");
         }
         else
         {
            GXv_int8[10] = 1;
         }
         if ( StringUtil.StrCmp(AV74Core_wcdocumentoarquivods_3_tfdocarqconteudonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.DocArqConteudoNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Core_wcdocumentoarquivods_5_tfdocarqconteudoextensao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Core_wcdocumentoarquivods_4_tfdocarqconteudoextensao)) ) )
         {
            AddWhere(sWhereString, "(T1.DocArqConteudoExtensao like :lV75Core_wcdocumentoarquivods_4_tfdocarqconteudoextensao)");
         }
         else
         {
            GXv_int8[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Core_wcdocumentoarquivods_5_tfdocarqconteudoextensao_sel)) && ! ( StringUtil.StrCmp(AV76Core_wcdocumentoarquivods_5_tfdocarqconteudoextensao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.DocArqConteudoExtensao = ( :AV76Core_wcdocumentoarquivods_5_tfdocarqconteudoextensao_sel))");
         }
         else
         {
            GXv_int8[12] = 1;
         }
         if ( StringUtil.StrCmp(AV76Core_wcdocumentoarquivods_5_tfdocarqconteudoextensao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.DocArqConteudoExtensao))=0))");
         }
         if ( ! (DateTime.MinValue==AV77Core_wcdocumentoarquivods_6_tfdocarqinsdatahora) )
         {
            AddWhere(sWhereString, "(T1.DocArqInsDataHora >= :AV77Core_wcdocumentoarquivods_6_tfdocarqinsdatahora)");
         }
         else
         {
            GXv_int8[13] = 1;
         }
         if ( ! (DateTime.MinValue==AV78Core_wcdocumentoarquivods_7_tfdocarqinsdatahora_to) )
         {
            AddWhere(sWhereString, "(T1.DocArqInsDataHora <= :AV78Core_wcdocumentoarquivods_7_tfdocarqinsdatahora_to)");
         }
         else
         {
            GXv_int8[14] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Core_wcdocumentoarquivods_9_tfdocarqobservacao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Core_wcdocumentoarquivods_8_tfdocarqobservacao)) ) )
         {
            AddWhere(sWhereString, "(T1.DocArqObservacao like :lV79Core_wcdocumentoarquivods_8_tfdocarqobservacao)");
         }
         else
         {
            GXv_int8[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Core_wcdocumentoarquivods_9_tfdocarqobservacao_sel)) && ! ( StringUtil.StrCmp(AV80Core_wcdocumentoarquivods_9_tfdocarqobservacao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.DocArqObservacao = ( :AV80Core_wcdocumentoarquivods_9_tfdocarqobservacao_sel))");
         }
         else
         {
            GXv_int8[16] = 1;
         }
         if ( StringUtil.StrCmp(AV80Core_wcdocumentoarquivods_9_tfdocarqobservacao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.DocArqObservacao IS NULL or (char_length(trim(trailing ' ' from T1.DocArqObservacao))=0))");
         }
         scmdbuf += sWhereString;
         if ( AV15OrderedBy == 1 )
         {
            scmdbuf += "";
         }
         else if ( ( AV15OrderedBy == 2 ) && ! AV16OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV15OrderedBy == 2 ) && ( AV16OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV15OrderedBy == 3 ) && ! AV16OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV15OrderedBy == 3 ) && ( AV16OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV15OrderedBy == 4 ) && ! AV16OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV15OrderedBy == 4 ) && ( AV16OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV15OrderedBy == 5 ) && ! AV16OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV15OrderedBy == 5 ) && ( AV16OrderedDsc ) )
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
                     return conditional_H005M2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (DateTime)dynConstraints[13] , (short)dynConstraints[14] , (bool)dynConstraints[15] , (Guid)dynConstraints[16] , (Guid)dynConstraints[17] , (Guid)dynConstraints[18] , (Guid)dynConstraints[19] );
               case 1 :
                     return conditional_H005M3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (DateTime)dynConstraints[13] , (short)dynConstraints[14] , (bool)dynConstraints[15] , (Guid)dynConstraints[16] , (Guid)dynConstraints[17] , (Guid)dynConstraints[18] , (Guid)dynConstraints[19] );
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
          Object[] prmH005M2;
          prmH005M2 = new Object[] {
          new ParDef("AV70InDocVersaoIDPai",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV70InDocVersaoIDPai",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV70InDocVersaoIDPai",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV69InDocID",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV70InDocVersaoIDPai",GXType.UniqueIdentifier,36,0) ,
          new ParDef("lV72Core_wcdocumentoarquivods_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Core_wcdocumentoarquivods_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Core_wcdocumentoarquivods_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Core_wcdocumentoarquivods_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV73Core_wcdocumentoarquivods_2_tfdocarqconteudonome",GXType.VarChar,2000,0) ,
          new ParDef("AV74Core_wcdocumentoarquivods_3_tfdocarqconteudonome_sel",GXType.VarChar,2000,0) ,
          new ParDef("lV75Core_wcdocumentoarquivods_4_tfdocarqconteudoextensao",GXType.VarChar,20,0) ,
          new ParDef("AV76Core_wcdocumentoarquivods_5_tfdocarqconteudoextensao_sel",GXType.VarChar,20,0) ,
          new ParDef("AV77Core_wcdocumentoarquivods_6_tfdocarqinsdatahora",GXType.DateTime2,10,12) ,
          new ParDef("AV78Core_wcdocumentoarquivods_7_tfdocarqinsdatahora_to",GXType.DateTime2,10,12) ,
          new ParDef("lV79Core_wcdocumentoarquivods_8_tfdocarqobservacao",GXType.VarChar,2000,0) ,
          new ParDef("AV80Core_wcdocumentoarquivods_9_tfdocarqobservacao_sel",GXType.VarChar,2000,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH005M3;
          prmH005M3 = new Object[] {
          new ParDef("AV70InDocVersaoIDPai",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV70InDocVersaoIDPai",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV70InDocVersaoIDPai",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV69InDocID",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV70InDocVersaoIDPai",GXType.UniqueIdentifier,36,0) ,
          new ParDef("lV72Core_wcdocumentoarquivods_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Core_wcdocumentoarquivods_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Core_wcdocumentoarquivods_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Core_wcdocumentoarquivods_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV73Core_wcdocumentoarquivods_2_tfdocarqconteudonome",GXType.VarChar,2000,0) ,
          new ParDef("AV74Core_wcdocumentoarquivods_3_tfdocarqconteudonome_sel",GXType.VarChar,2000,0) ,
          new ParDef("lV75Core_wcdocumentoarquivods_4_tfdocarqconteudoextensao",GXType.VarChar,20,0) ,
          new ParDef("AV76Core_wcdocumentoarquivods_5_tfdocarqconteudoextensao_sel",GXType.VarChar,20,0) ,
          new ParDef("AV77Core_wcdocumentoarquivods_6_tfdocarqinsdatahora",GXType.DateTime2,10,12) ,
          new ParDef("AV78Core_wcdocumentoarquivods_7_tfdocarqinsdatahora_to",GXType.DateTime2,10,12) ,
          new ParDef("lV79Core_wcdocumentoarquivods_8_tfdocarqobservacao",GXType.VarChar,2000,0) ,
          new ParDef("AV80Core_wcdocumentoarquivods_9_tfdocarqobservacao_sel",GXType.VarChar,2000,0)
          };
          def= new CursorDef[] {
              new CursorDef("H005M2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005M2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H005M3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005M3,1, GxCacheFrequency.OFF ,true,false )
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
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(4, true);
                ((short[]) buf[6])[0] = rslt.getShort(5);
                ((string[]) buf[7])[0] = rslt.getVarchar(6);
                ((string[]) buf[8])[0] = rslt.getVarchar(7);
                ((short[]) buf[9])[0] = rslt.getShort(8);
                ((Guid[]) buf[10])[0] = rslt.getGuid(9);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
