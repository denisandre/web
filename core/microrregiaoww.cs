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
   public class microrregiaoww : GXDataArea
   {
      public microrregiaoww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public microrregiaoww( IGxContext context )
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
         nRC_GXsfl_41 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_41"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_41_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_41_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_41_idx = GetPar( "sGXsfl_41_idx");
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
         AV16FilterFullText = GetPar( "FilterFullText");
         AV26ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV21ColumnsSelector);
         AV49Pgmname = GetPar( "Pgmname");
         AV27TFMicrorregiaoID = (int)(Math.Round(NumberUtil.Val( GetPar( "TFMicrorregiaoID"), "."), 18, MidpointRounding.ToEven));
         AV28TFMicrorregiaoID_To = (int)(Math.Round(NumberUtil.Val( GetPar( "TFMicrorregiaoID_To"), "."), 18, MidpointRounding.ToEven));
         AV29TFMicrorregiaoNome = GetPar( "TFMicrorregiaoNome");
         AV30TFMicrorregiaoNome_Sel = GetPar( "TFMicrorregiaoNome_Sel");
         AV31TFMicrorregiaoMesoNome = GetPar( "TFMicrorregiaoMesoNome");
         AV32TFMicrorregiaoMesoNome_Sel = GetPar( "TFMicrorregiaoMesoNome_Sel");
         AV33TFMicrorregiaoMesoUFSigla = GetPar( "TFMicrorregiaoMesoUFSigla");
         AV34TFMicrorregiaoMesoUFSigla_Sel = GetPar( "TFMicrorregiaoMesoUFSigla_Sel");
         AV35TFMicrorregiaoMesoUFRegNome = GetPar( "TFMicrorregiaoMesoUFRegNome");
         AV36TFMicrorregiaoMesoUFRegNome_Sel = GetPar( "TFMicrorregiaoMesoUFRegNome_Sel");
         AV13OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV14OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         AV48IsAuthorized_MicrorregiaoNome = StringUtil.StrToBool( GetPar( "IsAuthorized_MicrorregiaoNome"));
         AV44IsAuthorized_MicrorregiaoMesoNome = StringUtil.StrToBool( GetPar( "IsAuthorized_MicrorregiaoMesoNome"));
         AV45IsAuthorized_MicrorregiaoMesoUFSigla = StringUtil.StrToBool( GetPar( "IsAuthorized_MicrorregiaoMesoUFSigla"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV16FilterFullText, AV26ManageFiltersExecutionStep, AV21ColumnsSelector, AV49Pgmname, AV27TFMicrorregiaoID, AV28TFMicrorregiaoID_To, AV29TFMicrorregiaoNome, AV30TFMicrorregiaoNome_Sel, AV31TFMicrorregiaoMesoNome, AV32TFMicrorregiaoMesoNome_Sel, AV33TFMicrorregiaoMesoUFSigla, AV34TFMicrorregiaoMesoUFSigla_Sel, AV35TFMicrorregiaoMesoUFRegNome, AV36TFMicrorregiaoMesoUFRegNome_Sel, AV13OrderedBy, AV14OrderedDsc, AV48IsAuthorized_MicrorregiaoNome, AV44IsAuthorized_MicrorregiaoMesoNome, AV45IsAuthorized_MicrorregiaoMesoUFSigla) ;
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
            return "microrregiaoww_Execute" ;
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
         PA4I2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START4I2( ) ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("core.microrregiaoww.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV49Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV49Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_MICRORREGIAONOME", AV48IsAuthorized_MicrorregiaoNome);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_MICRORREGIAONOME", GetSecureSignedToken( "", AV48IsAuthorized_MicrorregiaoNome, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_MICRORREGIAOMESONOME", AV44IsAuthorized_MicrorregiaoMesoNome);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_MICRORREGIAOMESONOME", GetSecureSignedToken( "", AV44IsAuthorized_MicrorregiaoMesoNome, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_MICRORREGIAOMESOUFSIGLA", AV45IsAuthorized_MicrorregiaoMesoUFSigla);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_MICRORREGIAOMESOUFSIGLA", GetSecureSignedToken( "", AV45IsAuthorized_MicrorregiaoMesoUFSigla, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vFILTERFULLTEXT", AV16FilterFullText);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_41", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_41), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV24ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV24ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV41GridCurrentPage), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV42GridPageCount), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV43GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAGEXPORTDATA", AV46AGExportData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAGEXPORTDATA", AV46AGExportData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV37DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV37DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCOLUMNSSELECTOR", AV21ColumnsSelector);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCOLUMNSSELECTOR", AV21ColumnsSelector);
         }
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26ManageFiltersExecutionStep), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV49Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV49Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTFMICRORREGIAOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV27TFMicrorregiaoID), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFMICRORREGIAOID_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV28TFMicrorregiaoID_To), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFMICRORREGIAONOME", AV29TFMicrorregiaoNome);
         GxWebStd.gx_hidden_field( context, "vTFMICRORREGIAONOME_SEL", AV30TFMicrorregiaoNome_Sel);
         GxWebStd.gx_hidden_field( context, "vTFMICRORREGIAOMESONOME", AV31TFMicrorregiaoMesoNome);
         GxWebStd.gx_hidden_field( context, "vTFMICRORREGIAOMESONOME_SEL", AV32TFMicrorregiaoMesoNome_Sel);
         GxWebStd.gx_hidden_field( context, "vTFMICRORREGIAOMESOUFSIGLA", AV33TFMicrorregiaoMesoUFSigla);
         GxWebStd.gx_hidden_field( context, "vTFMICRORREGIAOMESOUFSIGLA_SEL", AV34TFMicrorregiaoMesoUFSigla_Sel);
         GxWebStd.gx_hidden_field( context, "vTFMICRORREGIAOMESOUFREGNOME", AV35TFMicrorregiaoMesoUFRegNome);
         GxWebStd.gx_hidden_field( context, "vTFMICRORREGIAOMESOUFREGNOME_SEL", AV36TFMicrorregiaoMesoUFRegNome_Sel);
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV14OrderedDsc);
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_MICRORREGIAONOME", AV48IsAuthorized_MicrorregiaoNome);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_MICRORREGIAONOME", GetSecureSignedToken( "", AV48IsAuthorized_MicrorregiaoNome, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_MICRORREGIAOMESONOME", AV44IsAuthorized_MicrorregiaoMesoNome);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_MICRORREGIAOMESONOME", GetSecureSignedToken( "", AV44IsAuthorized_MicrorregiaoMesoNome, context));
         GxWebStd.gx_hidden_field( context, "MICRORREGIAOMESOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A25MicrorregiaoMesoID), 9, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_MICRORREGIAOMESOUFSIGLA", AV45IsAuthorized_MicrorregiaoMesoUFSigla);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_MICRORREGIAOMESOUFSIGLA", GetSecureSignedToken( "", AV45IsAuthorized_MicrorregiaoMesoUFSigla, context));
         GxWebStd.gx_hidden_field( context, "MICRORREGIAOMESOUFID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A27MicrorregiaoMesoUFID), 9, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV11GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV11GridState);
         }
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
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues", StringUtil.RTrim( Ddo_gridcolumnsselector_Columnsselectorvalues));
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
            WE4I2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT4I2( ) ;
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
         return formatLink("core.microrregiaoww.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "core.microrregiaoWW" ;
      }

      public override string GetPgmdesc( )
      {
         return " Microrregião" ;
      }

      protected void WB4I0( )
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
            GxWebStd.gx_button_ctrl( context, bttBtnagexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(41), 2, 0)+","+"null"+");", "Exportar", bttBtnagexport_Jsonclick, 0, "Exportar", "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\microrregiaoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'',0)\"";
            ClassString = "hidden-xs";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtneditcolumns_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(41), 2, 0)+","+"null"+");", "Selecionar colunas", bttBtneditcolumns_Jsonclick, 0, "Selecionar colunas", "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\microrregiaoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnsubscriptions_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(41), 2, 0)+","+"null"+");", "", bttBtnsubscriptions_Jsonclick, 0, "Assinaturas", "", StyleString, ClassString, bttBtnsubscriptions_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\microrregiaoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            wb_table1_23_4I2( true) ;
         }
         else
         {
            wb_table1_23_4I2( false) ;
         }
         return  ;
      }

      protected void wb_table1_23_4I2e( bool wbgen )
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
            StartGridControl41( ) ;
         }
         if ( wbEnd == 41 )
         {
            wbEnd = 0;
            nRC_GXsfl_41 = (int)(nGXsfl_41_idx-1);
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV41GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV42GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV43GridAppliedFilters);
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
            ucDdo_agexport.SetProperty("DropDownOptionsData", AV46AGExportData);
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
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("Format", Ddo_grid_Format);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV37DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucDdo_gridcolumnsselector.SetProperty("IconType", Ddo_gridcolumnsselector_Icontype);
            ucDdo_gridcolumnsselector.SetProperty("Icon", Ddo_gridcolumnsselector_Icon);
            ucDdo_gridcolumnsselector.SetProperty("Caption", Ddo_gridcolumnsselector_Caption);
            ucDdo_gridcolumnsselector.SetProperty("Tooltip", Ddo_gridcolumnsselector_Tooltip);
            ucDdo_gridcolumnsselector.SetProperty("Cls", Ddo_gridcolumnsselector_Cls);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsType", Ddo_gridcolumnsselector_Dropdownoptionstype);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsTitleSettingsIcons", AV37DDO_TitleSettingsIcons);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsData", AV21ColumnsSelector);
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
               GxWebStd.gx_hidden_field( context, "W0059"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0059"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( bGXsfl_41_Refreshing )
               {
                  if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                  {
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0059"+"");
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
         if ( wbEnd == 41 )
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

      protected void START4I2( )
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
            Form.Meta.addItem("description", " Microrregião", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP4I0( ) ;
      }

      protected void WS4I2( )
      {
         START4I2( ) ;
         EVT4I2( ) ;
      }

      protected void EVT4I2( )
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
                              E114I2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E124I2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E134I2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_AGEXPORT.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E144I2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDC_SUBSCRIPTIONS.ONLOADCOMPONENT") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E154I2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E164I2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E174I2 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              nGXsfl_41_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_41_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_41_idx), 4, 0), 4, "0");
                              SubsflControlProps_412( ) ;
                              A23MicrorregiaoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtMicrorregiaoID_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A24MicrorregiaoNome = cgiGet( edtMicrorregiaoNome_Internalname);
                              A26MicrorregiaoMesoNome = cgiGet( edtMicrorregiaoMesoNome_Internalname);
                              A28MicrorregiaoMesoUFSigla = StringUtil.Upper( cgiGet( edtMicrorregiaoMesoUFSigla_Internalname));
                              n28MicrorregiaoMesoUFSigla = false;
                              A33MicrorregiaoMesoUFRegNome = cgiGet( edtMicrorregiaoMesoUFRegNome_Internalname);
                              n33MicrorregiaoMesoUFRegNome = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E184I2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E194I2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E204I2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Filterfulltext Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV16FilterFullText) != 0 )
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
                        if ( nCmpId == 59 )
                        {
                           OldWwpaux_wc = cgiGet( "W0059");
                           if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                           {
                              WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                              WebComp_Wwpaux_wc.ComponentInit();
                              WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                              WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                           }
                           if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                           {
                              WebComp_Wwpaux_wc.componentprocess("W0059", "", sEvt);
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

      protected void WE4I2( )
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

      protected void PA4I2( )
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
         SubsflControlProps_412( ) ;
         while ( nGXsfl_41_idx <= nRC_GXsfl_41 )
         {
            sendrow_412( ) ;
            nGXsfl_41_idx = ((subGrid_Islastpage==1)&&(nGXsfl_41_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_41_idx+1);
            sGXsfl_41_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_41_idx), 4, 0), 4, "0");
            SubsflControlProps_412( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       string AV16FilterFullText ,
                                       short AV26ManageFiltersExecutionStep ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV21ColumnsSelector ,
                                       string AV49Pgmname ,
                                       int AV27TFMicrorregiaoID ,
                                       int AV28TFMicrorregiaoID_To ,
                                       string AV29TFMicrorregiaoNome ,
                                       string AV30TFMicrorregiaoNome_Sel ,
                                       string AV31TFMicrorregiaoMesoNome ,
                                       string AV32TFMicrorregiaoMesoNome_Sel ,
                                       string AV33TFMicrorregiaoMesoUFSigla ,
                                       string AV34TFMicrorregiaoMesoUFSigla_Sel ,
                                       string AV35TFMicrorregiaoMesoUFRegNome ,
                                       string AV36TFMicrorregiaoMesoUFRegNome_Sel ,
                                       short AV13OrderedBy ,
                                       bool AV14OrderedDsc ,
                                       bool AV48IsAuthorized_MicrorregiaoNome ,
                                       bool AV44IsAuthorized_MicrorregiaoMesoNome ,
                                       bool AV45IsAuthorized_MicrorregiaoMesoUFSigla )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF4I2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
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
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF4I2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV49Pgmname = "core.microrregiaoWW";
      }

      protected void RF4I2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 41;
         /* Execute user event: Refresh */
         E194I2 ();
         nGXsfl_41_idx = 1;
         sGXsfl_41_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_41_idx), 4, 0), 4, "0");
         SubsflControlProps_412( ) ;
         bGXsfl_41_Refreshing = true;
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
            SubsflControlProps_412( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV50Core_microrregiaowwds_1_filterfulltext ,
                                                 AV51Core_microrregiaowwds_2_tfmicrorregiaoid ,
                                                 AV52Core_microrregiaowwds_3_tfmicrorregiaoid_to ,
                                                 AV54Core_microrregiaowwds_5_tfmicrorregiaonome_sel ,
                                                 AV53Core_microrregiaowwds_4_tfmicrorregiaonome ,
                                                 AV56Core_microrregiaowwds_7_tfmicrorregiaomesonome_sel ,
                                                 AV55Core_microrregiaowwds_6_tfmicrorregiaomesonome ,
                                                 AV58Core_microrregiaowwds_9_tfmicrorregiaomesoufsigla_sel ,
                                                 AV57Core_microrregiaowwds_8_tfmicrorregiaomesoufsigla ,
                                                 AV60Core_microrregiaowwds_11_tfmicrorregiaomesoufregnome_sel ,
                                                 AV59Core_microrregiaowwds_10_tfmicrorregiaomesoufregnome ,
                                                 A23MicrorregiaoID ,
                                                 A24MicrorregiaoNome ,
                                                 A26MicrorregiaoMesoNome ,
                                                 A28MicrorregiaoMesoUFSigla ,
                                                 A33MicrorregiaoMesoUFRegNome ,
                                                 AV13OrderedBy ,
                                                 AV14OrderedDsc } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV50Core_microrregiaowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Core_microrregiaowwds_1_filterfulltext), "%", "");
            lV50Core_microrregiaowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Core_microrregiaowwds_1_filterfulltext), "%", "");
            lV50Core_microrregiaowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Core_microrregiaowwds_1_filterfulltext), "%", "");
            lV50Core_microrregiaowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Core_microrregiaowwds_1_filterfulltext), "%", "");
            lV50Core_microrregiaowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Core_microrregiaowwds_1_filterfulltext), "%", "");
            lV53Core_microrregiaowwds_4_tfmicrorregiaonome = StringUtil.Concat( StringUtil.RTrim( AV53Core_microrregiaowwds_4_tfmicrorregiaonome), "%", "");
            lV55Core_microrregiaowwds_6_tfmicrorregiaomesonome = StringUtil.Concat( StringUtil.RTrim( AV55Core_microrregiaowwds_6_tfmicrorregiaomesonome), "%", "");
            lV57Core_microrregiaowwds_8_tfmicrorregiaomesoufsigla = StringUtil.Concat( StringUtil.RTrim( AV57Core_microrregiaowwds_8_tfmicrorregiaomesoufsigla), "%", "");
            lV59Core_microrregiaowwds_10_tfmicrorregiaomesoufregnome = StringUtil.Concat( StringUtil.RTrim( AV59Core_microrregiaowwds_10_tfmicrorregiaomesoufregnome), "%", "");
            /* Using cursor H004I2 */
            pr_default.execute(0, new Object[] {lV50Core_microrregiaowwds_1_filterfulltext, lV50Core_microrregiaowwds_1_filterfulltext, lV50Core_microrregiaowwds_1_filterfulltext, lV50Core_microrregiaowwds_1_filterfulltext, lV50Core_microrregiaowwds_1_filterfulltext, AV51Core_microrregiaowwds_2_tfmicrorregiaoid, AV52Core_microrregiaowwds_3_tfmicrorregiaoid_to, lV53Core_microrregiaowwds_4_tfmicrorregiaonome, AV54Core_microrregiaowwds_5_tfmicrorregiaonome_sel, lV55Core_microrregiaowwds_6_tfmicrorregiaomesonome, AV56Core_microrregiaowwds_7_tfmicrorregiaomesonome_sel, lV57Core_microrregiaowwds_8_tfmicrorregiaomesoufsigla, AV58Core_microrregiaowwds_9_tfmicrorregiaomesoufsigla_sel, lV59Core_microrregiaowwds_10_tfmicrorregiaomesoufregnome, AV60Core_microrregiaowwds_11_tfmicrorregiaomesoufregnome_sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_41_idx = 1;
            sGXsfl_41_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_41_idx), 4, 0), 4, "0");
            SubsflControlProps_412( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A25MicrorregiaoMesoID = H004I2_A25MicrorregiaoMesoID[0];
               A27MicrorregiaoMesoUFID = H004I2_A27MicrorregiaoMesoUFID[0];
               A33MicrorregiaoMesoUFRegNome = H004I2_A33MicrorregiaoMesoUFRegNome[0];
               n33MicrorregiaoMesoUFRegNome = H004I2_n33MicrorregiaoMesoUFRegNome[0];
               A28MicrorregiaoMesoUFSigla = H004I2_A28MicrorregiaoMesoUFSigla[0];
               n28MicrorregiaoMesoUFSigla = H004I2_n28MicrorregiaoMesoUFSigla[0];
               A26MicrorregiaoMesoNome = H004I2_A26MicrorregiaoMesoNome[0];
               A24MicrorregiaoNome = H004I2_A24MicrorregiaoNome[0];
               A23MicrorregiaoID = H004I2_A23MicrorregiaoID[0];
               E204I2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 41;
            WB4I0( ) ;
         }
         bGXsfl_41_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes4I2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV49Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV49Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_MICRORREGIAONOME", AV48IsAuthorized_MicrorregiaoNome);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_MICRORREGIAONOME", GetSecureSignedToken( "", AV48IsAuthorized_MicrorregiaoNome, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_MICRORREGIAOMESONOME", AV44IsAuthorized_MicrorregiaoMesoNome);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_MICRORREGIAOMESONOME", GetSecureSignedToken( "", AV44IsAuthorized_MicrorregiaoMesoNome, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_MICRORREGIAOMESOUFSIGLA", AV45IsAuthorized_MicrorregiaoMesoUFSigla);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_MICRORREGIAOMESOUFSIGLA", GetSecureSignedToken( "", AV45IsAuthorized_MicrorregiaoMesoUFSigla, context));
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
         AV50Core_microrregiaowwds_1_filterfulltext = AV16FilterFullText;
         AV51Core_microrregiaowwds_2_tfmicrorregiaoid = AV27TFMicrorregiaoID;
         AV52Core_microrregiaowwds_3_tfmicrorregiaoid_to = AV28TFMicrorregiaoID_To;
         AV53Core_microrregiaowwds_4_tfmicrorregiaonome = AV29TFMicrorregiaoNome;
         AV54Core_microrregiaowwds_5_tfmicrorregiaonome_sel = AV30TFMicrorregiaoNome_Sel;
         AV55Core_microrregiaowwds_6_tfmicrorregiaomesonome = AV31TFMicrorregiaoMesoNome;
         AV56Core_microrregiaowwds_7_tfmicrorregiaomesonome_sel = AV32TFMicrorregiaoMesoNome_Sel;
         AV57Core_microrregiaowwds_8_tfmicrorregiaomesoufsigla = AV33TFMicrorregiaoMesoUFSigla;
         AV58Core_microrregiaowwds_9_tfmicrorregiaomesoufsigla_sel = AV34TFMicrorregiaoMesoUFSigla_Sel;
         AV59Core_microrregiaowwds_10_tfmicrorregiaomesoufregnome = AV35TFMicrorregiaoMesoUFRegNome;
         AV60Core_microrregiaowwds_11_tfmicrorregiaomesoufregnome_sel = AV36TFMicrorregiaoMesoUFRegNome_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV50Core_microrregiaowwds_1_filterfulltext ,
                                              AV51Core_microrregiaowwds_2_tfmicrorregiaoid ,
                                              AV52Core_microrregiaowwds_3_tfmicrorregiaoid_to ,
                                              AV54Core_microrregiaowwds_5_tfmicrorregiaonome_sel ,
                                              AV53Core_microrregiaowwds_4_tfmicrorregiaonome ,
                                              AV56Core_microrregiaowwds_7_tfmicrorregiaomesonome_sel ,
                                              AV55Core_microrregiaowwds_6_tfmicrorregiaomesonome ,
                                              AV58Core_microrregiaowwds_9_tfmicrorregiaomesoufsigla_sel ,
                                              AV57Core_microrregiaowwds_8_tfmicrorregiaomesoufsigla ,
                                              AV60Core_microrregiaowwds_11_tfmicrorregiaomesoufregnome_sel ,
                                              AV59Core_microrregiaowwds_10_tfmicrorregiaomesoufregnome ,
                                              A23MicrorregiaoID ,
                                              A24MicrorregiaoNome ,
                                              A26MicrorregiaoMesoNome ,
                                              A28MicrorregiaoMesoUFSigla ,
                                              A33MicrorregiaoMesoUFRegNome ,
                                              AV13OrderedBy ,
                                              AV14OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV50Core_microrregiaowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Core_microrregiaowwds_1_filterfulltext), "%", "");
         lV50Core_microrregiaowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Core_microrregiaowwds_1_filterfulltext), "%", "");
         lV50Core_microrregiaowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Core_microrregiaowwds_1_filterfulltext), "%", "");
         lV50Core_microrregiaowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Core_microrregiaowwds_1_filterfulltext), "%", "");
         lV50Core_microrregiaowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Core_microrregiaowwds_1_filterfulltext), "%", "");
         lV53Core_microrregiaowwds_4_tfmicrorregiaonome = StringUtil.Concat( StringUtil.RTrim( AV53Core_microrregiaowwds_4_tfmicrorregiaonome), "%", "");
         lV55Core_microrregiaowwds_6_tfmicrorregiaomesonome = StringUtil.Concat( StringUtil.RTrim( AV55Core_microrregiaowwds_6_tfmicrorregiaomesonome), "%", "");
         lV57Core_microrregiaowwds_8_tfmicrorregiaomesoufsigla = StringUtil.Concat( StringUtil.RTrim( AV57Core_microrregiaowwds_8_tfmicrorregiaomesoufsigla), "%", "");
         lV59Core_microrregiaowwds_10_tfmicrorregiaomesoufregnome = StringUtil.Concat( StringUtil.RTrim( AV59Core_microrregiaowwds_10_tfmicrorregiaomesoufregnome), "%", "");
         /* Using cursor H004I3 */
         pr_default.execute(1, new Object[] {lV50Core_microrregiaowwds_1_filterfulltext, lV50Core_microrregiaowwds_1_filterfulltext, lV50Core_microrregiaowwds_1_filterfulltext, lV50Core_microrregiaowwds_1_filterfulltext, lV50Core_microrregiaowwds_1_filterfulltext, AV51Core_microrregiaowwds_2_tfmicrorregiaoid, AV52Core_microrregiaowwds_3_tfmicrorregiaoid_to, lV53Core_microrregiaowwds_4_tfmicrorregiaonome, AV54Core_microrregiaowwds_5_tfmicrorregiaonome_sel, lV55Core_microrregiaowwds_6_tfmicrorregiaomesonome, AV56Core_microrregiaowwds_7_tfmicrorregiaomesonome_sel, lV57Core_microrregiaowwds_8_tfmicrorregiaomesoufsigla, AV58Core_microrregiaowwds_9_tfmicrorregiaomesoufsigla_sel, lV59Core_microrregiaowwds_10_tfmicrorregiaomesoufregnome, AV60Core_microrregiaowwds_11_tfmicrorregiaomesoufregnome_sel});
         GRID_nRecordCount = H004I3_AGRID_nRecordCount[0];
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
         AV50Core_microrregiaowwds_1_filterfulltext = AV16FilterFullText;
         AV51Core_microrregiaowwds_2_tfmicrorregiaoid = AV27TFMicrorregiaoID;
         AV52Core_microrregiaowwds_3_tfmicrorregiaoid_to = AV28TFMicrorregiaoID_To;
         AV53Core_microrregiaowwds_4_tfmicrorregiaonome = AV29TFMicrorregiaoNome;
         AV54Core_microrregiaowwds_5_tfmicrorregiaonome_sel = AV30TFMicrorregiaoNome_Sel;
         AV55Core_microrregiaowwds_6_tfmicrorregiaomesonome = AV31TFMicrorregiaoMesoNome;
         AV56Core_microrregiaowwds_7_tfmicrorregiaomesonome_sel = AV32TFMicrorregiaoMesoNome_Sel;
         AV57Core_microrregiaowwds_8_tfmicrorregiaomesoufsigla = AV33TFMicrorregiaoMesoUFSigla;
         AV58Core_microrregiaowwds_9_tfmicrorregiaomesoufsigla_sel = AV34TFMicrorregiaoMesoUFSigla_Sel;
         AV59Core_microrregiaowwds_10_tfmicrorregiaomesoufregnome = AV35TFMicrorregiaoMesoUFRegNome;
         AV60Core_microrregiaowwds_11_tfmicrorregiaomesoufregnome_sel = AV36TFMicrorregiaoMesoUFRegNome_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV16FilterFullText, AV26ManageFiltersExecutionStep, AV21ColumnsSelector, AV49Pgmname, AV27TFMicrorregiaoID, AV28TFMicrorregiaoID_To, AV29TFMicrorregiaoNome, AV30TFMicrorregiaoNome_Sel, AV31TFMicrorregiaoMesoNome, AV32TFMicrorregiaoMesoNome_Sel, AV33TFMicrorregiaoMesoUFSigla, AV34TFMicrorregiaoMesoUFSigla_Sel, AV35TFMicrorregiaoMesoUFRegNome, AV36TFMicrorregiaoMesoUFRegNome_Sel, AV13OrderedBy, AV14OrderedDsc, AV48IsAuthorized_MicrorregiaoNome, AV44IsAuthorized_MicrorregiaoMesoNome, AV45IsAuthorized_MicrorregiaoMesoUFSigla) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV50Core_microrregiaowwds_1_filterfulltext = AV16FilterFullText;
         AV51Core_microrregiaowwds_2_tfmicrorregiaoid = AV27TFMicrorregiaoID;
         AV52Core_microrregiaowwds_3_tfmicrorregiaoid_to = AV28TFMicrorregiaoID_To;
         AV53Core_microrregiaowwds_4_tfmicrorregiaonome = AV29TFMicrorregiaoNome;
         AV54Core_microrregiaowwds_5_tfmicrorregiaonome_sel = AV30TFMicrorregiaoNome_Sel;
         AV55Core_microrregiaowwds_6_tfmicrorregiaomesonome = AV31TFMicrorregiaoMesoNome;
         AV56Core_microrregiaowwds_7_tfmicrorregiaomesonome_sel = AV32TFMicrorregiaoMesoNome_Sel;
         AV57Core_microrregiaowwds_8_tfmicrorregiaomesoufsigla = AV33TFMicrorregiaoMesoUFSigla;
         AV58Core_microrregiaowwds_9_tfmicrorregiaomesoufsigla_sel = AV34TFMicrorregiaoMesoUFSigla_Sel;
         AV59Core_microrregiaowwds_10_tfmicrorregiaomesoufregnome = AV35TFMicrorregiaoMesoUFRegNome;
         AV60Core_microrregiaowwds_11_tfmicrorregiaomesoufregnome_sel = AV36TFMicrorregiaoMesoUFRegNome_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV16FilterFullText, AV26ManageFiltersExecutionStep, AV21ColumnsSelector, AV49Pgmname, AV27TFMicrorregiaoID, AV28TFMicrorregiaoID_To, AV29TFMicrorregiaoNome, AV30TFMicrorregiaoNome_Sel, AV31TFMicrorregiaoMesoNome, AV32TFMicrorregiaoMesoNome_Sel, AV33TFMicrorregiaoMesoUFSigla, AV34TFMicrorregiaoMesoUFSigla_Sel, AV35TFMicrorregiaoMesoUFRegNome, AV36TFMicrorregiaoMesoUFRegNome_Sel, AV13OrderedBy, AV14OrderedDsc, AV48IsAuthorized_MicrorregiaoNome, AV44IsAuthorized_MicrorregiaoMesoNome, AV45IsAuthorized_MicrorregiaoMesoUFSigla) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV50Core_microrregiaowwds_1_filterfulltext = AV16FilterFullText;
         AV51Core_microrregiaowwds_2_tfmicrorregiaoid = AV27TFMicrorregiaoID;
         AV52Core_microrregiaowwds_3_tfmicrorregiaoid_to = AV28TFMicrorregiaoID_To;
         AV53Core_microrregiaowwds_4_tfmicrorregiaonome = AV29TFMicrorregiaoNome;
         AV54Core_microrregiaowwds_5_tfmicrorregiaonome_sel = AV30TFMicrorregiaoNome_Sel;
         AV55Core_microrregiaowwds_6_tfmicrorregiaomesonome = AV31TFMicrorregiaoMesoNome;
         AV56Core_microrregiaowwds_7_tfmicrorregiaomesonome_sel = AV32TFMicrorregiaoMesoNome_Sel;
         AV57Core_microrregiaowwds_8_tfmicrorregiaomesoufsigla = AV33TFMicrorregiaoMesoUFSigla;
         AV58Core_microrregiaowwds_9_tfmicrorregiaomesoufsigla_sel = AV34TFMicrorregiaoMesoUFSigla_Sel;
         AV59Core_microrregiaowwds_10_tfmicrorregiaomesoufregnome = AV35TFMicrorregiaoMesoUFRegNome;
         AV60Core_microrregiaowwds_11_tfmicrorregiaomesoufregnome_sel = AV36TFMicrorregiaoMesoUFRegNome_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV16FilterFullText, AV26ManageFiltersExecutionStep, AV21ColumnsSelector, AV49Pgmname, AV27TFMicrorregiaoID, AV28TFMicrorregiaoID_To, AV29TFMicrorregiaoNome, AV30TFMicrorregiaoNome_Sel, AV31TFMicrorregiaoMesoNome, AV32TFMicrorregiaoMesoNome_Sel, AV33TFMicrorregiaoMesoUFSigla, AV34TFMicrorregiaoMesoUFSigla_Sel, AV35TFMicrorregiaoMesoUFRegNome, AV36TFMicrorregiaoMesoUFRegNome_Sel, AV13OrderedBy, AV14OrderedDsc, AV48IsAuthorized_MicrorregiaoNome, AV44IsAuthorized_MicrorregiaoMesoNome, AV45IsAuthorized_MicrorregiaoMesoUFSigla) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV50Core_microrregiaowwds_1_filterfulltext = AV16FilterFullText;
         AV51Core_microrregiaowwds_2_tfmicrorregiaoid = AV27TFMicrorregiaoID;
         AV52Core_microrregiaowwds_3_tfmicrorregiaoid_to = AV28TFMicrorregiaoID_To;
         AV53Core_microrregiaowwds_4_tfmicrorregiaonome = AV29TFMicrorregiaoNome;
         AV54Core_microrregiaowwds_5_tfmicrorregiaonome_sel = AV30TFMicrorregiaoNome_Sel;
         AV55Core_microrregiaowwds_6_tfmicrorregiaomesonome = AV31TFMicrorregiaoMesoNome;
         AV56Core_microrregiaowwds_7_tfmicrorregiaomesonome_sel = AV32TFMicrorregiaoMesoNome_Sel;
         AV57Core_microrregiaowwds_8_tfmicrorregiaomesoufsigla = AV33TFMicrorregiaoMesoUFSigla;
         AV58Core_microrregiaowwds_9_tfmicrorregiaomesoufsigla_sel = AV34TFMicrorregiaoMesoUFSigla_Sel;
         AV59Core_microrregiaowwds_10_tfmicrorregiaomesoufregnome = AV35TFMicrorregiaoMesoUFRegNome;
         AV60Core_microrregiaowwds_11_tfmicrorregiaomesoufregnome_sel = AV36TFMicrorregiaoMesoUFRegNome_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV16FilterFullText, AV26ManageFiltersExecutionStep, AV21ColumnsSelector, AV49Pgmname, AV27TFMicrorregiaoID, AV28TFMicrorregiaoID_To, AV29TFMicrorregiaoNome, AV30TFMicrorregiaoNome_Sel, AV31TFMicrorregiaoMesoNome, AV32TFMicrorregiaoMesoNome_Sel, AV33TFMicrorregiaoMesoUFSigla, AV34TFMicrorregiaoMesoUFSigla_Sel, AV35TFMicrorregiaoMesoUFRegNome, AV36TFMicrorregiaoMesoUFRegNome_Sel, AV13OrderedBy, AV14OrderedDsc, AV48IsAuthorized_MicrorregiaoNome, AV44IsAuthorized_MicrorregiaoMesoNome, AV45IsAuthorized_MicrorregiaoMesoUFSigla) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV50Core_microrregiaowwds_1_filterfulltext = AV16FilterFullText;
         AV51Core_microrregiaowwds_2_tfmicrorregiaoid = AV27TFMicrorregiaoID;
         AV52Core_microrregiaowwds_3_tfmicrorregiaoid_to = AV28TFMicrorregiaoID_To;
         AV53Core_microrregiaowwds_4_tfmicrorregiaonome = AV29TFMicrorregiaoNome;
         AV54Core_microrregiaowwds_5_tfmicrorregiaonome_sel = AV30TFMicrorregiaoNome_Sel;
         AV55Core_microrregiaowwds_6_tfmicrorregiaomesonome = AV31TFMicrorregiaoMesoNome;
         AV56Core_microrregiaowwds_7_tfmicrorregiaomesonome_sel = AV32TFMicrorregiaoMesoNome_Sel;
         AV57Core_microrregiaowwds_8_tfmicrorregiaomesoufsigla = AV33TFMicrorregiaoMesoUFSigla;
         AV58Core_microrregiaowwds_9_tfmicrorregiaomesoufsigla_sel = AV34TFMicrorregiaoMesoUFSigla_Sel;
         AV59Core_microrregiaowwds_10_tfmicrorregiaomesoufregnome = AV35TFMicrorregiaoMesoUFRegNome;
         AV60Core_microrregiaowwds_11_tfmicrorregiaomesoufregnome_sel = AV36TFMicrorregiaoMesoUFRegNome_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV16FilterFullText, AV26ManageFiltersExecutionStep, AV21ColumnsSelector, AV49Pgmname, AV27TFMicrorregiaoID, AV28TFMicrorregiaoID_To, AV29TFMicrorregiaoNome, AV30TFMicrorregiaoNome_Sel, AV31TFMicrorregiaoMesoNome, AV32TFMicrorregiaoMesoNome_Sel, AV33TFMicrorregiaoMesoUFSigla, AV34TFMicrorregiaoMesoUFSigla_Sel, AV35TFMicrorregiaoMesoUFRegNome, AV36TFMicrorregiaoMesoUFRegNome_Sel, AV13OrderedBy, AV14OrderedDsc, AV48IsAuthorized_MicrorregiaoNome, AV44IsAuthorized_MicrorregiaoMesoNome, AV45IsAuthorized_MicrorregiaoMesoUFSigla) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV49Pgmname = "core.microrregiaoWW";
         fix_multi_value_controls( ) ;
      }

      protected void STRUP4I0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E184I2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV24ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vAGEXPORTDATA"), AV46AGExportData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV37DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vCOLUMNSSELECTOR"), AV21ColumnsSelector);
            /* Read saved values. */
            nRC_GXsfl_41 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_41"), ",", "."), 18, MidpointRounding.ToEven));
            AV41GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ",", "."), 18, MidpointRounding.ToEven));
            AV42GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ",", "."), 18, MidpointRounding.ToEven));
            AV43GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
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
            Ddo_grid_Selectedcolumn = cgiGet( "DDO_GRID_Selectedcolumn");
            Ddo_grid_Filteredtext_get = cgiGet( "DDO_GRID_Filteredtext_get");
            Ddo_grid_Filteredtextto_get = cgiGet( "DDO_GRID_Filteredtextto_get");
            Ddo_gridcolumnsselector_Columnsselectorvalues = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues");
            Ddo_managefilters_Activeeventkey = cgiGet( "DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Ddo_agexport_Activeeventkey = cgiGet( "DDO_AGEXPORT_Activeeventkey");
            /* Read variables values. */
            AV16FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV16FilterFullText", AV16FilterFullText);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV16FilterFullText) != 0 )
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
         E184I2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E184I2( )
      {
         /* Start Routine */
         returnInSub = false;
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
         Ddo_agexport_Titlecontrolidtoreplace = bttBtnagexport_Internalname;
         ucDdo_agexport.SendProperty(context, "", false, Ddo_agexport_Internalname, "TitleControlIdToReplace", Ddo_agexport_Titlecontrolidtoreplace);
         AV46AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV47AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV47AGExportDataItem.gxTpr_Title = "Excel";
         AV47AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "da69a816-fd11-445b-8aaf-1a2f7f1acc93", "", context.GetTheme( ))));
         AV47AGExportDataItem.gxTpr_Eventkey = "Export";
         AV47AGExportDataItem.gxTpr_Isdivider = false;
         AV46AGExportData.Add(AV47AGExportDataItem, 0);
         Ddc_subscriptions_Titlecontrolidtoreplace = bttBtnsubscriptions_Internalname;
         ucDdc_subscriptions.SendProperty(context, "", false, Ddc_subscriptions_Internalname, "TitleControlIdToReplace", Ddc_subscriptions_Titlecontrolidtoreplace);
         GXt_boolean1 = AV48IsAuthorized_MicrorregiaoNome;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "microrregiaoview_Execute", out  GXt_boolean1) ;
         AV48IsAuthorized_MicrorregiaoNome = GXt_boolean1;
         AssignAttri("", false, "AV48IsAuthorized_MicrorregiaoNome", AV48IsAuthorized_MicrorregiaoNome);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_MICRORREGIAONOME", GetSecureSignedToken( "", AV48IsAuthorized_MicrorregiaoNome, context));
         GXt_boolean1 = AV44IsAuthorized_MicrorregiaoMesoNome;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "mesorregiaoview_Execute", out  GXt_boolean1) ;
         AV44IsAuthorized_MicrorregiaoMesoNome = GXt_boolean1;
         AssignAttri("", false, "AV44IsAuthorized_MicrorregiaoMesoNome", AV44IsAuthorized_MicrorregiaoMesoNome);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_MICRORREGIAOMESONOME", GetSecureSignedToken( "", AV44IsAuthorized_MicrorregiaoMesoNome, context));
         GXt_boolean1 = AV45IsAuthorized_MicrorregiaoMesoUFSigla;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "ufview_Execute", out  GXt_boolean1) ;
         AV45IsAuthorized_MicrorregiaoMesoUFSigla = GXt_boolean1;
         AssignAttri("", false, "AV45IsAuthorized_MicrorregiaoMesoUFSigla", AV45IsAuthorized_MicrorregiaoMesoUFSigla);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_MICRORREGIAOMESOUFSIGLA", GetSecureSignedToken( "", AV45IsAuthorized_MicrorregiaoMesoUFSigla, context));
         AV38GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV39GAMErrors);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Ddo_grid_Gamoauthtoken = AV38GAMSession.gxTpr_Token;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GAMOAuthToken", Ddo_grid_Gamoauthtoken);
         Form.Caption = " Microrregião";
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
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
         if ( AV13OrderedBy < 1 )
         {
            AV13OrderedBy = 1;
            AssignAttri("", false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S142 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = AV37DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2) ;
         AV37DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2;
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = bttBtneditcolumns_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "TitleControlIdToReplace", Ddo_gridcolumnsselector_Titlecontrolidtoreplace);
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E194I2( )
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
         if ( AV26ManageFiltersExecutionStep == 1 )
         {
            AV26ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV26ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV26ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV26ManageFiltersExecutionStep == 2 )
         {
            AV26ManageFiltersExecutionStep = 0;
            AssignAttri("", false, "AV26ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV26ManageFiltersExecutionStep), 1, 0));
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
         if ( StringUtil.StrCmp(AV23Session.Get("core.microrregiaoWWColumnsSelector"), "") != 0 )
         {
            AV19ColumnsSelectorXML = AV23Session.Get("core.microrregiaoWWColumnsSelector");
            AV21ColumnsSelector.FromXml(AV19ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S172 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         edtMicrorregiaoID_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV21ColumnsSelector.gxTpr_Columns.Item(1)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtMicrorregiaoID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMicrorregiaoID_Visible), 5, 0), !bGXsfl_41_Refreshing);
         edtMicrorregiaoNome_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV21ColumnsSelector.gxTpr_Columns.Item(2)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtMicrorregiaoNome_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMicrorregiaoNome_Visible), 5, 0), !bGXsfl_41_Refreshing);
         edtMicrorregiaoMesoNome_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV21ColumnsSelector.gxTpr_Columns.Item(3)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtMicrorregiaoMesoNome_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMicrorregiaoMesoNome_Visible), 5, 0), !bGXsfl_41_Refreshing);
         edtMicrorregiaoMesoUFSigla_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV21ColumnsSelector.gxTpr_Columns.Item(4)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtMicrorregiaoMesoUFSigla_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMicrorregiaoMesoUFSigla_Visible), 5, 0), !bGXsfl_41_Refreshing);
         edtMicrorregiaoMesoUFRegNome_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV21ColumnsSelector.gxTpr_Columns.Item(5)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtMicrorregiaoMesoUFRegNome_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMicrorregiaoMesoUFRegNome_Visible), 5, 0), !bGXsfl_41_Refreshing);
         AV41GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV41GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV41GridCurrentPage), 10, 0));
         AV42GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV42GridPageCount", StringUtil.LTrimStr( (decimal)(AV42GridPageCount), 10, 0));
         GXt_char3 = AV43GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV49Pgmname, out  GXt_char3) ;
         AV43GridAppliedFilters = GXt_char3;
         AssignAttri("", false, "AV43GridAppliedFilters", AV43GridAppliedFilters);
         AV50Core_microrregiaowwds_1_filterfulltext = AV16FilterFullText;
         AV51Core_microrregiaowwds_2_tfmicrorregiaoid = AV27TFMicrorregiaoID;
         AV52Core_microrregiaowwds_3_tfmicrorregiaoid_to = AV28TFMicrorregiaoID_To;
         AV53Core_microrregiaowwds_4_tfmicrorregiaonome = AV29TFMicrorregiaoNome;
         AV54Core_microrregiaowwds_5_tfmicrorregiaonome_sel = AV30TFMicrorregiaoNome_Sel;
         AV55Core_microrregiaowwds_6_tfmicrorregiaomesonome = AV31TFMicrorregiaoMesoNome;
         AV56Core_microrregiaowwds_7_tfmicrorregiaomesonome_sel = AV32TFMicrorregiaoMesoNome_Sel;
         AV57Core_microrregiaowwds_8_tfmicrorregiaomesoufsigla = AV33TFMicrorregiaoMesoUFSigla;
         AV58Core_microrregiaowwds_9_tfmicrorregiaomesoufsigla_sel = AV34TFMicrorregiaoMesoUFSigla_Sel;
         AV59Core_microrregiaowwds_10_tfmicrorregiaomesoufregnome = AV35TFMicrorregiaoMesoUFRegNome;
         AV60Core_microrregiaowwds_11_tfmicrorregiaomesoufregnome_sel = AV36TFMicrorregiaoMesoUFRegNome_Sel;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21ColumnsSelector", AV21ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24ManageFiltersData", AV24ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E124I2( )
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
            AV40PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV40PageToGo) ;
         }
      }

      protected void E134I2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E164I2( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV13OrderedBy = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
            AV14OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri("", false, "AV14OrderedDsc", AV14OrderedDsc);
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "MicrorregiaoID") == 0 )
            {
               AV27TFMicrorregiaoID = (int)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV27TFMicrorregiaoID", StringUtil.LTrimStr( (decimal)(AV27TFMicrorregiaoID), 9, 0));
               AV28TFMicrorregiaoID_To = (int)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV28TFMicrorregiaoID_To", StringUtil.LTrimStr( (decimal)(AV28TFMicrorregiaoID_To), 9, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "MicrorregiaoNome") == 0 )
            {
               AV29TFMicrorregiaoNome = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV29TFMicrorregiaoNome", AV29TFMicrorregiaoNome);
               AV30TFMicrorregiaoNome_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV30TFMicrorregiaoNome_Sel", AV30TFMicrorregiaoNome_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "MicrorregiaoMesoNome") == 0 )
            {
               AV31TFMicrorregiaoMesoNome = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV31TFMicrorregiaoMesoNome", AV31TFMicrorregiaoMesoNome);
               AV32TFMicrorregiaoMesoNome_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV32TFMicrorregiaoMesoNome_Sel", AV32TFMicrorregiaoMesoNome_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "MicrorregiaoMesoUFSigla") == 0 )
            {
               AV33TFMicrorregiaoMesoUFSigla = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV33TFMicrorregiaoMesoUFSigla", AV33TFMicrorregiaoMesoUFSigla);
               AV34TFMicrorregiaoMesoUFSigla_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV34TFMicrorregiaoMesoUFSigla_Sel", AV34TFMicrorregiaoMesoUFSigla_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "MicrorregiaoMesoUFRegNome") == 0 )
            {
               AV35TFMicrorregiaoMesoUFRegNome = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV35TFMicrorregiaoMesoUFRegNome", AV35TFMicrorregiaoMesoUFRegNome);
               AV36TFMicrorregiaoMesoUFRegNome_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV36TFMicrorregiaoMesoUFRegNome_Sel", AV36TFMicrorregiaoMesoUFRegNome_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E204I2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         if ( AV48IsAuthorized_MicrorregiaoNome )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "core.microrregiaoview.aspx"+UrlEncode(StringUtil.LTrimStr(A23MicrorregiaoID,9,0)) + "," + UrlEncode(StringUtil.RTrim(""));
            edtMicrorregiaoNome_Link = formatLink("core.microrregiaoview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         }
         if ( AV44IsAuthorized_MicrorregiaoMesoNome )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "core.mesorregiaoview.aspx"+UrlEncode(StringUtil.LTrimStr(A25MicrorregiaoMesoID,9,0)) + "," + UrlEncode(StringUtil.RTrim(""));
            edtMicrorregiaoMesoNome_Link = formatLink("core.mesorregiaoview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         }
         if ( AV45IsAuthorized_MicrorregiaoMesoUFSigla )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "core.ufview.aspx"+UrlEncode(StringUtil.LTrimStr(A27MicrorregiaoMesoUFID,9,0)) + "," + UrlEncode(StringUtil.RTrim(""));
            edtMicrorregiaoMesoUFSigla_Link = formatLink("core.ufview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         }
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 41;
         }
         sendrow_412( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_41_Refreshing )
         {
            DoAjaxLoad(41, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E174I2( )
      {
         /* Ddo_gridcolumnsselector_Oncolumnschanged Routine */
         returnInSub = false;
         AV19ColumnsSelectorXML = Ddo_gridcolumnsselector_Columnsselectorvalues;
         AV21ColumnsSelector.FromJSonString(AV19ColumnsSelectorXML, null);
         new GeneXus.Programs.wwpbaseobjects.savecolumnsselectorstate(context ).execute(  "core.microrregiaoWWColumnsSelector",  (String.IsNullOrEmpty(StringUtil.RTrim( AV19ColumnsSelectorXML)) ? "" : AV21ColumnsSelector.ToXml(false, true, "", ""))) ;
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21ColumnsSelector", AV21ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24ManageFiltersData", AV24ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E114I2( )
      {
         /* Ddo_managefilters_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Clean#>") == 0 )
         {
            /* Execute user subroutine: 'CLEANFILTERS' */
            S182 ();
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
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wwpbaseobjects.savefilteras.aspx"+UrlEncode(StringUtil.RTrim("core.microrregiaoWWFilters")) + "," + UrlEncode(StringUtil.RTrim(AV49Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV26ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV26ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV26ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wwpbaseobjects.managefilters.aspx"+UrlEncode(StringUtil.RTrim("core.microrregiaoWWFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV26ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV26ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV26ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char3 = AV25ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "core.microrregiaoWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char3) ;
            AV25ManageFiltersXml = GXt_char3;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV25ManageFiltersXml)) )
            {
               GX_msglist.addItem("O filtro selecionado não existe mais.");
            }
            else
            {
               /* Execute user subroutine: 'CLEANFILTERS' */
               S182 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV49Pgmname+"GridState",  AV25ManageFiltersXml) ;
               AV11GridState.FromXml(AV25ManageFiltersXml, null, "", "");
               AV13OrderedBy = AV11GridState.gxTpr_Orderedby;
               AssignAttri("", false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
               AV14OrderedDsc = AV11GridState.gxTpr_Ordereddsc;
               AssignAttri("", false, "AV14OrderedDsc", AV14OrderedDsc);
               /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
               S142 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
               S192 ();
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21ColumnsSelector", AV21ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24ManageFiltersData", AV24ManageFiltersData);
      }

      protected void E144I2( )
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
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E154I2( )
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
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"W0059",(string)"",(string)"microrregiao",(short)1,(string)"",(string)""});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0059"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void S142( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV13OrderedBy), 4, 0))+":"+(AV14OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S172( )
      {
         /* 'INITIALIZECOLUMNSSELECTOR' Routine */
         returnInSub = false;
         AV21ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV21ColumnsSelector,  "MicrorregiaoID",  "",  "ID",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV21ColumnsSelector,  "MicrorregiaoNome",  "",  "Nome",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV21ColumnsSelector,  "MicrorregiaoMesoNome",  "",  "Mesoregião",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV21ColumnsSelector,  "MicrorregiaoMesoUFSigla",  "",  "UF",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV21ColumnsSelector,  "MicrorregiaoMesoUFRegNome",  "",  "Região",  true,  "") ;
         GXt_char3 = AV20UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "core.microrregiaoWWColumnsSelector", out  GXt_char3) ;
         AV20UserCustomValue = GXt_char3;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV20UserCustomValue)) ) )
         {
            AV22ColumnsSelectorAux.FromXml(AV20UserCustomValue, null, "", "");
            new GeneXus.Programs.wwpbaseobjects.wwp_columnselector_updatecolumns(context ).execute( ref  AV22ColumnsSelectorAux, ref  AV21ColumnsSelector) ;
         }
      }

      protected void S152( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         if ( ! ( new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_hassubscriptionstodisplay(context).executeUdp(  "microrregiao",  1) ) )
         {
            bttBtnsubscriptions_Visible = 0;
            AssignProp("", false, bttBtnsubscriptions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnsubscriptions_Visible), 5, 0), true);
         }
      }

      protected void S112( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = AV24ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "core.microrregiaoWWFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4) ;
         AV24ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4;
      }

      protected void S182( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV16FilterFullText = "";
         AssignAttri("", false, "AV16FilterFullText", AV16FilterFullText);
         AV27TFMicrorregiaoID = 0;
         AssignAttri("", false, "AV27TFMicrorregiaoID", StringUtil.LTrimStr( (decimal)(AV27TFMicrorregiaoID), 9, 0));
         AV28TFMicrorregiaoID_To = 0;
         AssignAttri("", false, "AV28TFMicrorregiaoID_To", StringUtil.LTrimStr( (decimal)(AV28TFMicrorregiaoID_To), 9, 0));
         AV29TFMicrorregiaoNome = "";
         AssignAttri("", false, "AV29TFMicrorregiaoNome", AV29TFMicrorregiaoNome);
         AV30TFMicrorregiaoNome_Sel = "";
         AssignAttri("", false, "AV30TFMicrorregiaoNome_Sel", AV30TFMicrorregiaoNome_Sel);
         AV31TFMicrorregiaoMesoNome = "";
         AssignAttri("", false, "AV31TFMicrorregiaoMesoNome", AV31TFMicrorregiaoMesoNome);
         AV32TFMicrorregiaoMesoNome_Sel = "";
         AssignAttri("", false, "AV32TFMicrorregiaoMesoNome_Sel", AV32TFMicrorregiaoMesoNome_Sel);
         AV33TFMicrorregiaoMesoUFSigla = "";
         AssignAttri("", false, "AV33TFMicrorregiaoMesoUFSigla", AV33TFMicrorregiaoMesoUFSigla);
         AV34TFMicrorregiaoMesoUFSigla_Sel = "";
         AssignAttri("", false, "AV34TFMicrorregiaoMesoUFSigla_Sel", AV34TFMicrorregiaoMesoUFSigla_Sel);
         AV35TFMicrorregiaoMesoUFRegNome = "";
         AssignAttri("", false, "AV35TFMicrorregiaoMesoUFRegNome", AV35TFMicrorregiaoMesoUFRegNome);
         AV36TFMicrorregiaoMesoUFRegNome_Sel = "";
         AssignAttri("", false, "AV36TFMicrorregiaoMesoUFRegNome_Sel", AV36TFMicrorregiaoMesoUFRegNome_Sel);
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S132( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV23Session.Get(AV49Pgmname+"GridState"), "") == 0 )
         {
            AV11GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV49Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV11GridState.FromXml(AV23Session.Get(AV49Pgmname+"GridState"), null, "", "");
         }
         AV13OrderedBy = AV11GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV13OrderedBy", StringUtil.LTrimStr( (decimal)(AV13OrderedBy), 4, 0));
         AV14OrderedDsc = AV11GridState.gxTpr_Ordereddsc;
         AssignAttri("", false, "AV14OrderedDsc", AV14OrderedDsc);
         /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
         S192 ();
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

      protected void S192( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV61GXV1 = 1;
         while ( AV61GXV1 <= AV11GridState.gxTpr_Filtervalues.Count )
         {
            AV12GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV11GridState.gxTpr_Filtervalues.Item(AV61GXV1));
            if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV16FilterFullText = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV16FilterFullText", AV16FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFMICRORREGIAOID") == 0 )
            {
               AV27TFMicrorregiaoID = (int)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV27TFMicrorregiaoID", StringUtil.LTrimStr( (decimal)(AV27TFMicrorregiaoID), 9, 0));
               AV28TFMicrorregiaoID_To = (int)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV28TFMicrorregiaoID_To", StringUtil.LTrimStr( (decimal)(AV28TFMicrorregiaoID_To), 9, 0));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFMICRORREGIAONOME") == 0 )
            {
               AV29TFMicrorregiaoNome = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV29TFMicrorregiaoNome", AV29TFMicrorregiaoNome);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFMICRORREGIAONOME_SEL") == 0 )
            {
               AV30TFMicrorregiaoNome_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV30TFMicrorregiaoNome_Sel", AV30TFMicrorregiaoNome_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFMICRORREGIAOMESONOME") == 0 )
            {
               AV31TFMicrorregiaoMesoNome = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV31TFMicrorregiaoMesoNome", AV31TFMicrorregiaoMesoNome);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFMICRORREGIAOMESONOME_SEL") == 0 )
            {
               AV32TFMicrorregiaoMesoNome_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV32TFMicrorregiaoMesoNome_Sel", AV32TFMicrorregiaoMesoNome_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFMICRORREGIAOMESOUFSIGLA") == 0 )
            {
               AV33TFMicrorregiaoMesoUFSigla = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV33TFMicrorregiaoMesoUFSigla", AV33TFMicrorregiaoMesoUFSigla);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFMICRORREGIAOMESOUFSIGLA_SEL") == 0 )
            {
               AV34TFMicrorregiaoMesoUFSigla_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV34TFMicrorregiaoMesoUFSigla_Sel", AV34TFMicrorregiaoMesoUFSigla_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFMICRORREGIAOMESOUFREGNOME") == 0 )
            {
               AV35TFMicrorregiaoMesoUFRegNome = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV35TFMicrorregiaoMesoUFRegNome", AV35TFMicrorregiaoMesoUFRegNome);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFMICRORREGIAOMESOUFREGNOME_SEL") == 0 )
            {
               AV36TFMicrorregiaoMesoUFRegNome_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV36TFMicrorregiaoMesoUFRegNome_Sel", AV36TFMicrorregiaoMesoUFRegNome_Sel);
            }
            AV61GXV1 = (int)(AV61GXV1+1);
         }
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV30TFMicrorregiaoNome_Sel)),  AV30TFMicrorregiaoNome_Sel, out  GXt_char3) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV32TFMicrorregiaoMesoNome_Sel)),  AV32TFMicrorregiaoMesoNome_Sel, out  GXt_char5) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV34TFMicrorregiaoMesoUFSigla_Sel)),  AV34TFMicrorregiaoMesoUFSigla_Sel, out  GXt_char6) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV36TFMicrorregiaoMesoUFRegNome_Sel)),  AV36TFMicrorregiaoMesoUFRegNome_Sel, out  GXt_char7) ;
         Ddo_grid_Selectedvalue_set = "|"+GXt_char3+"|"+GXt_char5+"|"+GXt_char6+"|"+GXt_char7;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV29TFMicrorregiaoNome)),  AV29TFMicrorregiaoNome, out  GXt_char7) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV31TFMicrorregiaoMesoNome)),  AV31TFMicrorregiaoMesoNome, out  GXt_char6) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV33TFMicrorregiaoMesoUFSigla)),  AV33TFMicrorregiaoMesoUFSigla, out  GXt_char5) ;
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV35TFMicrorregiaoMesoUFRegNome)),  AV35TFMicrorregiaoMesoUFRegNome, out  GXt_char3) ;
         Ddo_grid_Filteredtext_set = ((0==AV27TFMicrorregiaoID) ? "" : StringUtil.Str( (decimal)(AV27TFMicrorregiaoID), 9, 0))+"|"+GXt_char7+"|"+GXt_char6+"|"+GXt_char5+"|"+GXt_char3;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = ((0==AV28TFMicrorregiaoID_To) ? "" : StringUtil.Str( (decimal)(AV28TFMicrorregiaoID_To), 9, 0))+"||||";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S162( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV11GridState.FromXml(AV23Session.Get(AV49Pgmname+"GridState"), null, "", "");
         AV11GridState.gxTpr_Orderedby = AV13OrderedBy;
         AV11GridState.gxTpr_Ordereddsc = AV14OrderedDsc;
         AV11GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "FILTERFULLTEXT",  "Filtro principal",  !String.IsNullOrEmpty(StringUtil.RTrim( AV16FilterFullText)),  0,  AV16FilterFullText,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFMICRORREGIAOID",  "ID",  !((0==AV27TFMicrorregiaoID)&&(0==AV28TFMicrorregiaoID_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV27TFMicrorregiaoID), 9, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV28TFMicrorregiaoID_To), 9, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFMICRORREGIAONOME",  "Nome",  !String.IsNullOrEmpty(StringUtil.RTrim( AV29TFMicrorregiaoNome)),  0,  AV29TFMicrorregiaoNome,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV30TFMicrorregiaoNome_Sel)),  AV30TFMicrorregiaoNome_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFMICRORREGIAOMESONOME",  "Mesoregião",  !String.IsNullOrEmpty(StringUtil.RTrim( AV31TFMicrorregiaoMesoNome)),  0,  AV31TFMicrorregiaoMesoNome,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV32TFMicrorregiaoMesoNome_Sel)),  AV32TFMicrorregiaoMesoNome_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFMICRORREGIAOMESOUFSIGLA",  "UF",  !String.IsNullOrEmpty(StringUtil.RTrim( AV33TFMicrorregiaoMesoUFSigla)),  0,  AV33TFMicrorregiaoMesoUFSigla,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV34TFMicrorregiaoMesoUFSigla_Sel)),  AV34TFMicrorregiaoMesoUFSigla_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFMICRORREGIAOMESOUFREGNOME",  "Região",  !String.IsNullOrEmpty(StringUtil.RTrim( AV35TFMicrorregiaoMesoUFRegNome)),  0,  AV35TFMicrorregiaoMesoUFRegNome,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV36TFMicrorregiaoMesoUFRegNome_Sel)),  AV36TFMicrorregiaoMesoUFRegNome_Sel,  "") ;
         AV11GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV11GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV49Pgmname+"GridState",  AV11GridState.ToXml(false, true, "", "")) ;
      }

      protected void S122( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV9TrnContext.gxTpr_Callerobject = AV49Pgmname;
         AV9TrnContext.gxTpr_Callerondelete = true;
         AV9TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString;
         AV9TrnContext.gxTpr_Transactionname = "core.microrregiao";
         AV23Session.Set("TrnContext", AV9TrnContext.ToXml(false, true, "", ""));
      }

      protected void S202( )
      {
         /* 'DOEXPORT' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         new GeneXus.Programs.core.microrregiaowwexport(context ).execute( out  AV17ExcelFilename, out  AV18ErrorMessage) ;
         if ( StringUtil.StrCmp(AV17ExcelFilename, "") != 0 )
         {
            CallWebObject(formatLink(AV17ExcelFilename) );
            context.wjLocDisableFrm = 0;
         }
         else
         {
            GX_msglist.addItem(AV18ErrorMessage);
         }
      }

      protected void wb_table1_23_4I2( bool wbgen )
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
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV24ManageFiltersData);
            ucDdo_managefilters.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_managefilters_Internalname, "DDO_MANAGEFILTERSContainer");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            wb_table2_28_4I2( true) ;
         }
         else
         {
            wb_table2_28_4I2( false) ;
         }
         return  ;
      }

      protected void wb_table2_28_4I2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_23_4I2e( true) ;
         }
         else
         {
            wb_table1_23_4I2e( false) ;
         }
      }

      protected void wb_table2_28_4I2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'" + sGXsfl_41_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV16FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV16FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Pesquisar", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_core\\microrregiaoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_28_4I2e( true) ;
         }
         else
         {
            wb_table2_28_4I2e( false) ;
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
         PA4I2( ) ;
         WS4I2( ) ;
         WE4I2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202382822484", true, true);
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
         context.AddJavascriptSource("core/microrregiaoww.js", "?202382822485", false, true);
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_412( )
      {
         edtMicrorregiaoID_Internalname = "MICRORREGIAOID_"+sGXsfl_41_idx;
         edtMicrorregiaoNome_Internalname = "MICRORREGIAONOME_"+sGXsfl_41_idx;
         edtMicrorregiaoMesoNome_Internalname = "MICRORREGIAOMESONOME_"+sGXsfl_41_idx;
         edtMicrorregiaoMesoUFSigla_Internalname = "MICRORREGIAOMESOUFSIGLA_"+sGXsfl_41_idx;
         edtMicrorregiaoMesoUFRegNome_Internalname = "MICRORREGIAOMESOUFREGNOME_"+sGXsfl_41_idx;
      }

      protected void SubsflControlProps_fel_412( )
      {
         edtMicrorregiaoID_Internalname = "MICRORREGIAOID_"+sGXsfl_41_fel_idx;
         edtMicrorregiaoNome_Internalname = "MICRORREGIAONOME_"+sGXsfl_41_fel_idx;
         edtMicrorregiaoMesoNome_Internalname = "MICRORREGIAOMESONOME_"+sGXsfl_41_fel_idx;
         edtMicrorregiaoMesoUFSigla_Internalname = "MICRORREGIAOMESOUFSIGLA_"+sGXsfl_41_fel_idx;
         edtMicrorregiaoMesoUFRegNome_Internalname = "MICRORREGIAOMESOUFREGNOME_"+sGXsfl_41_fel_idx;
      }

      protected void sendrow_412( )
      {
         SubsflControlProps_412( ) ;
         WB4I0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_41_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_41_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_41_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtMicrorregiaoID_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMicrorregiaoID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A23MicrorregiaoID), 11, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A23MicrorregiaoID), "ZZZ,ZZZ,ZZ9")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMicrorregiaoID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtMicrorregiaoID_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)11,(short)0,(short)0,(short)41,(short)0,(short)-1,(short)0,(bool)true,(string)"core\\ID",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtMicrorregiaoNome_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMicrorregiaoNome_Internalname,(string)A24MicrorregiaoNome,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtMicrorregiaoNome_Link,(string)"",(string)"",(string)"",(string)edtMicrorregiaoNome_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtMicrorregiaoNome_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)41,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtMicrorregiaoMesoNome_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMicrorregiaoMesoNome_Internalname,(string)A26MicrorregiaoMesoNome,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtMicrorregiaoMesoNome_Link,(string)"",(string)"",(string)"",(string)edtMicrorregiaoMesoNome_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtMicrorregiaoMesoNome_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)41,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtMicrorregiaoMesoUFSigla_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMicrorregiaoMesoUFSigla_Internalname,(string)A28MicrorregiaoMesoUFSigla,StringUtil.RTrim( context.localUtil.Format( A28MicrorregiaoMesoUFSigla, "@!")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtMicrorregiaoMesoUFSigla_Link,(string)"",(string)"",(string)"",(string)edtMicrorregiaoMesoUFSigla_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtMicrorregiaoMesoUFSigla_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)2,(short)0,(short)0,(short)41,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtMicrorregiaoMesoUFRegNome_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMicrorregiaoMesoUFRegNome_Internalname,(string)A33MicrorregiaoMesoUFRegNome,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMicrorregiaoMesoUFRegNome_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtMicrorregiaoMesoUFRegNome_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)50,(short)0,(short)0,(short)41,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes4I2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_41_idx = ((subGrid_Islastpage==1)&&(nGXsfl_41_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_41_idx+1);
            sGXsfl_41_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_41_idx), 4, 0), 4, "0");
            SubsflControlProps_412( ) ;
         }
         /* End function sendrow_412 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl41( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"41\">") ;
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
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtMicrorregiaoID_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "ID") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtMicrorregiaoNome_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Nome") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtMicrorregiaoMesoNome_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Mesoregião") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtMicrorregiaoMesoUFSigla_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "UF") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtMicrorregiaoMesoUFRegNome_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Região") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A23MicrorregiaoID), 11, 0, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMicrorregiaoID_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A24MicrorregiaoNome));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtMicrorregiaoNome_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMicrorregiaoNome_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A26MicrorregiaoMesoNome));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtMicrorregiaoMesoNome_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMicrorregiaoMesoNome_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A28MicrorregiaoMesoUFSigla));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtMicrorregiaoMesoUFSigla_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMicrorregiaoMesoUFSigla_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A33MicrorregiaoMesoUFRegNome));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMicrorregiaoMesoUFRegNome_Visible), 5, 0, ".", "")));
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
         divTableheader_Internalname = "TABLEHEADER";
         edtMicrorregiaoID_Internalname = "MICRORREGIAOID";
         edtMicrorregiaoNome_Internalname = "MICRORREGIAONOME";
         edtMicrorregiaoMesoNome_Internalname = "MICRORREGIAOMESONOME";
         edtMicrorregiaoMesoUFSigla_Internalname = "MICRORREGIAOMESOUFSIGLA";
         edtMicrorregiaoMesoUFRegNome_Internalname = "MICRORREGIAOMESOUFREGNOME";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         Ddo_agexport_Internalname = "DDO_AGEXPORT";
         Ddc_subscriptions_Internalname = "DDC_SUBSCRIPTIONS";
         Ddo_grid_Internalname = "DDO_GRID";
         Ddo_gridcolumnsselector_Internalname = "DDO_GRIDCOLUMNSSELECTOR";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
         divDiv_wwpauxwc_Internalname = "DIV_WWPAUXWC";
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
         edtMicrorregiaoMesoUFRegNome_Jsonclick = "";
         edtMicrorregiaoMesoUFSigla_Jsonclick = "";
         edtMicrorregiaoMesoUFSigla_Link = "";
         edtMicrorregiaoMesoNome_Jsonclick = "";
         edtMicrorregiaoMesoNome_Link = "";
         edtMicrorregiaoNome_Jsonclick = "";
         edtMicrorregiaoNome_Link = "";
         edtMicrorregiaoID_Jsonclick = "";
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         edtMicrorregiaoMesoUFRegNome_Visible = -1;
         edtMicrorregiaoMesoUFSigla_Visible = -1;
         edtMicrorregiaoMesoNome_Visible = -1;
         edtMicrorregiaoNome_Visible = -1;
         edtMicrorregiaoID_Visible = -1;
         subGrid_Sortable = 0;
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
         Ddo_grid_Format = "9.0||||";
         Ddo_grid_Datalistproc = "core.microrregiaoWWGetFilterData";
         Ddo_grid_Datalisttype = "|Dynamic|Dynamic|Dynamic|Dynamic";
         Ddo_grid_Includedatalist = "|T|T|T|T";
         Ddo_grid_Filterisrange = "T||||";
         Ddo_grid_Filtertype = "Numeric|Character|Character|Character|Character";
         Ddo_grid_Includefilter = "T";
         Ddo_grid_Fixable = "T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "2|1|3|4|5";
         Ddo_grid_Columnids = "0:MicrorregiaoID|1:MicrorregiaoNome|2:MicrorregiaoMesoNome|3:MicrorregiaoMesoUFSigla|4:MicrorregiaoMesoUFRegNome";
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
         Form.Caption = " Microrregião";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV49Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV27TFMicrorregiaoID',fld:'vTFMICRORREGIAOID',pic:'ZZZ,ZZZ,ZZ9'},{av:'AV28TFMicrorregiaoID_To',fld:'vTFMICRORREGIAOID_TO',pic:'ZZZ,ZZZ,ZZ9'},{av:'AV29TFMicrorregiaoNome',fld:'vTFMICRORREGIAONOME',pic:''},{av:'AV30TFMicrorregiaoNome_Sel',fld:'vTFMICRORREGIAONOME_SEL',pic:''},{av:'AV31TFMicrorregiaoMesoNome',fld:'vTFMICRORREGIAOMESONOME',pic:''},{av:'AV32TFMicrorregiaoMesoNome_Sel',fld:'vTFMICRORREGIAOMESONOME_SEL',pic:''},{av:'AV33TFMicrorregiaoMesoUFSigla',fld:'vTFMICRORREGIAOMESOUFSIGLA',pic:'@!'},{av:'AV34TFMicrorregiaoMesoUFSigla_Sel',fld:'vTFMICRORREGIAOMESOUFSIGLA_SEL',pic:'@!'},{av:'AV35TFMicrorregiaoMesoUFRegNome',fld:'vTFMICRORREGIAOMESOUFREGNOME',pic:''},{av:'AV36TFMicrorregiaoMesoUFRegNome_Sel',fld:'vTFMICRORREGIAOMESOUFREGNOME_SEL',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV48IsAuthorized_MicrorregiaoNome',fld:'vISAUTHORIZED_MICRORREGIAONOME',pic:'',hsh:true},{av:'AV44IsAuthorized_MicrorregiaoMesoNome',fld:'vISAUTHORIZED_MICRORREGIAOMESONOME',pic:'',hsh:true},{av:'AV45IsAuthorized_MicrorregiaoMesoUFSigla',fld:'vISAUTHORIZED_MICRORREGIAOMESOUFSIGLA',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtMicrorregiaoID_Visible',ctrl:'MICRORREGIAOID',prop:'Visible'},{av:'edtMicrorregiaoNome_Visible',ctrl:'MICRORREGIAONOME',prop:'Visible'},{av:'edtMicrorregiaoMesoNome_Visible',ctrl:'MICRORREGIAOMESONOME',prop:'Visible'},{av:'edtMicrorregiaoMesoUFSigla_Visible',ctrl:'MICRORREGIAOMESOUFSIGLA',prop:'Visible'},{av:'edtMicrorregiaoMesoUFRegNome_Visible',ctrl:'MICRORREGIAOMESOUFREGNOME',prop:'Visible'},{av:'AV41GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV42GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV43GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV24ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E124I2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV49Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV27TFMicrorregiaoID',fld:'vTFMICRORREGIAOID',pic:'ZZZ,ZZZ,ZZ9'},{av:'AV28TFMicrorregiaoID_To',fld:'vTFMICRORREGIAOID_TO',pic:'ZZZ,ZZZ,ZZ9'},{av:'AV29TFMicrorregiaoNome',fld:'vTFMICRORREGIAONOME',pic:''},{av:'AV30TFMicrorregiaoNome_Sel',fld:'vTFMICRORREGIAONOME_SEL',pic:''},{av:'AV31TFMicrorregiaoMesoNome',fld:'vTFMICRORREGIAOMESONOME',pic:''},{av:'AV32TFMicrorregiaoMesoNome_Sel',fld:'vTFMICRORREGIAOMESONOME_SEL',pic:''},{av:'AV33TFMicrorregiaoMesoUFSigla',fld:'vTFMICRORREGIAOMESOUFSIGLA',pic:'@!'},{av:'AV34TFMicrorregiaoMesoUFSigla_Sel',fld:'vTFMICRORREGIAOMESOUFSIGLA_SEL',pic:'@!'},{av:'AV35TFMicrorregiaoMesoUFRegNome',fld:'vTFMICRORREGIAOMESOUFREGNOME',pic:''},{av:'AV36TFMicrorregiaoMesoUFRegNome_Sel',fld:'vTFMICRORREGIAOMESOUFREGNOME_SEL',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV48IsAuthorized_MicrorregiaoNome',fld:'vISAUTHORIZED_MICRORREGIAONOME',pic:'',hsh:true},{av:'AV44IsAuthorized_MicrorregiaoMesoNome',fld:'vISAUTHORIZED_MICRORREGIAOMESONOME',pic:'',hsh:true},{av:'AV45IsAuthorized_MicrorregiaoMesoUFSigla',fld:'vISAUTHORIZED_MICRORREGIAOMESOUFSIGLA',pic:'',hsh:true},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E134I2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV49Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV27TFMicrorregiaoID',fld:'vTFMICRORREGIAOID',pic:'ZZZ,ZZZ,ZZ9'},{av:'AV28TFMicrorregiaoID_To',fld:'vTFMICRORREGIAOID_TO',pic:'ZZZ,ZZZ,ZZ9'},{av:'AV29TFMicrorregiaoNome',fld:'vTFMICRORREGIAONOME',pic:''},{av:'AV30TFMicrorregiaoNome_Sel',fld:'vTFMICRORREGIAONOME_SEL',pic:''},{av:'AV31TFMicrorregiaoMesoNome',fld:'vTFMICRORREGIAOMESONOME',pic:''},{av:'AV32TFMicrorregiaoMesoNome_Sel',fld:'vTFMICRORREGIAOMESONOME_SEL',pic:''},{av:'AV33TFMicrorregiaoMesoUFSigla',fld:'vTFMICRORREGIAOMESOUFSIGLA',pic:'@!'},{av:'AV34TFMicrorregiaoMesoUFSigla_Sel',fld:'vTFMICRORREGIAOMESOUFSIGLA_SEL',pic:'@!'},{av:'AV35TFMicrorregiaoMesoUFRegNome',fld:'vTFMICRORREGIAOMESOUFREGNOME',pic:''},{av:'AV36TFMicrorregiaoMesoUFRegNome_Sel',fld:'vTFMICRORREGIAOMESOUFREGNOME_SEL',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV48IsAuthorized_MicrorregiaoNome',fld:'vISAUTHORIZED_MICRORREGIAONOME',pic:'',hsh:true},{av:'AV44IsAuthorized_MicrorregiaoMesoNome',fld:'vISAUTHORIZED_MICRORREGIAOMESONOME',pic:'',hsh:true},{av:'AV45IsAuthorized_MicrorregiaoMesoUFSigla',fld:'vISAUTHORIZED_MICRORREGIAOMESOUFSIGLA',pic:'',hsh:true},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]}");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","{handler:'E164I2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV49Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV27TFMicrorregiaoID',fld:'vTFMICRORREGIAOID',pic:'ZZZ,ZZZ,ZZ9'},{av:'AV28TFMicrorregiaoID_To',fld:'vTFMICRORREGIAOID_TO',pic:'ZZZ,ZZZ,ZZ9'},{av:'AV29TFMicrorregiaoNome',fld:'vTFMICRORREGIAONOME',pic:''},{av:'AV30TFMicrorregiaoNome_Sel',fld:'vTFMICRORREGIAONOME_SEL',pic:''},{av:'AV31TFMicrorregiaoMesoNome',fld:'vTFMICRORREGIAOMESONOME',pic:''},{av:'AV32TFMicrorregiaoMesoNome_Sel',fld:'vTFMICRORREGIAOMESONOME_SEL',pic:''},{av:'AV33TFMicrorregiaoMesoUFSigla',fld:'vTFMICRORREGIAOMESOUFSIGLA',pic:'@!'},{av:'AV34TFMicrorregiaoMesoUFSigla_Sel',fld:'vTFMICRORREGIAOMESOUFSIGLA_SEL',pic:'@!'},{av:'AV35TFMicrorregiaoMesoUFRegNome',fld:'vTFMICRORREGIAOMESOUFREGNOME',pic:''},{av:'AV36TFMicrorregiaoMesoUFRegNome_Sel',fld:'vTFMICRORREGIAOMESOUFREGNOME_SEL',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV48IsAuthorized_MicrorregiaoNome',fld:'vISAUTHORIZED_MICRORREGIAONOME',pic:'',hsh:true},{av:'AV44IsAuthorized_MicrorregiaoMesoNome',fld:'vISAUTHORIZED_MICRORREGIAOMESONOME',pic:'',hsh:true},{av:'AV45IsAuthorized_MicrorregiaoMesoUFSigla',fld:'vISAUTHORIZED_MICRORREGIAOMESOUFSIGLA',pic:'',hsh:true},{av:'Ddo_grid_Activeeventkey',ctrl:'DDO_GRID',prop:'ActiveEventKey'},{av:'Ddo_grid_Selectedvalue_get',ctrl:'DDO_GRID',prop:'SelectedValue_get'},{av:'Ddo_grid_Selectedcolumn',ctrl:'DDO_GRID',prop:'SelectedColumn'},{av:'Ddo_grid_Filteredtext_get',ctrl:'DDO_GRID',prop:'FilteredText_get'},{av:'Ddo_grid_Filteredtextto_get',ctrl:'DDO_GRID',prop:'FilteredTextTo_get'}]");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",",oparms:[{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV27TFMicrorregiaoID',fld:'vTFMICRORREGIAOID',pic:'ZZZ,ZZZ,ZZ9'},{av:'AV28TFMicrorregiaoID_To',fld:'vTFMICRORREGIAOID_TO',pic:'ZZZ,ZZZ,ZZ9'},{av:'AV29TFMicrorregiaoNome',fld:'vTFMICRORREGIAONOME',pic:''},{av:'AV30TFMicrorregiaoNome_Sel',fld:'vTFMICRORREGIAONOME_SEL',pic:''},{av:'AV31TFMicrorregiaoMesoNome',fld:'vTFMICRORREGIAOMESONOME',pic:''},{av:'AV32TFMicrorregiaoMesoNome_Sel',fld:'vTFMICRORREGIAOMESONOME_SEL',pic:''},{av:'AV33TFMicrorregiaoMesoUFSigla',fld:'vTFMICRORREGIAOMESOUFSIGLA',pic:'@!'},{av:'AV34TFMicrorregiaoMesoUFSigla_Sel',fld:'vTFMICRORREGIAOMESOUFSIGLA_SEL',pic:'@!'},{av:'AV35TFMicrorregiaoMesoUFRegNome',fld:'vTFMICRORREGIAOMESOUFREGNOME',pic:''},{av:'AV36TFMicrorregiaoMesoUFRegNome_Sel',fld:'vTFMICRORREGIAOMESOUFREGNOME_SEL',pic:''},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E204I2',iparms:[{av:'AV48IsAuthorized_MicrorregiaoNome',fld:'vISAUTHORIZED_MICRORREGIAONOME',pic:'',hsh:true},{av:'A23MicrorregiaoID',fld:'MICRORREGIAOID',pic:'ZZZ,ZZZ,ZZ9'},{av:'AV44IsAuthorized_MicrorregiaoMesoNome',fld:'vISAUTHORIZED_MICRORREGIAOMESONOME',pic:'',hsh:true},{av:'A25MicrorregiaoMesoID',fld:'MICRORREGIAOMESOID',pic:'ZZZ,ZZZ,ZZ9'},{av:'AV45IsAuthorized_MicrorregiaoMesoUFSigla',fld:'vISAUTHORIZED_MICRORREGIAOMESOUFSIGLA',pic:'',hsh:true},{av:'A27MicrorregiaoMesoUFID',fld:'MICRORREGIAOMESOUFID',pic:'ZZZ,ZZZ,ZZ9'}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'edtMicrorregiaoNome_Link',ctrl:'MICRORREGIAONOME',prop:'Link'},{av:'edtMicrorregiaoMesoNome_Link',ctrl:'MICRORREGIAOMESONOME',prop:'Link'},{av:'edtMicrorregiaoMesoUFSigla_Link',ctrl:'MICRORREGIAOMESOUFSIGLA',prop:'Link'}]}");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED","{handler:'E174I2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV49Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV27TFMicrorregiaoID',fld:'vTFMICRORREGIAOID',pic:'ZZZ,ZZZ,ZZ9'},{av:'AV28TFMicrorregiaoID_To',fld:'vTFMICRORREGIAOID_TO',pic:'ZZZ,ZZZ,ZZ9'},{av:'AV29TFMicrorregiaoNome',fld:'vTFMICRORREGIAONOME',pic:''},{av:'AV30TFMicrorregiaoNome_Sel',fld:'vTFMICRORREGIAONOME_SEL',pic:''},{av:'AV31TFMicrorregiaoMesoNome',fld:'vTFMICRORREGIAOMESONOME',pic:''},{av:'AV32TFMicrorregiaoMesoNome_Sel',fld:'vTFMICRORREGIAOMESONOME_SEL',pic:''},{av:'AV33TFMicrorregiaoMesoUFSigla',fld:'vTFMICRORREGIAOMESOUFSIGLA',pic:'@!'},{av:'AV34TFMicrorregiaoMesoUFSigla_Sel',fld:'vTFMICRORREGIAOMESOUFSIGLA_SEL',pic:'@!'},{av:'AV35TFMicrorregiaoMesoUFRegNome',fld:'vTFMICRORREGIAOMESOUFREGNOME',pic:''},{av:'AV36TFMicrorregiaoMesoUFRegNome_Sel',fld:'vTFMICRORREGIAOMESOUFREGNOME_SEL',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV48IsAuthorized_MicrorregiaoNome',fld:'vISAUTHORIZED_MICRORREGIAONOME',pic:'',hsh:true},{av:'AV44IsAuthorized_MicrorregiaoMesoNome',fld:'vISAUTHORIZED_MICRORREGIAOMESONOME',pic:'',hsh:true},{av:'AV45IsAuthorized_MicrorregiaoMesoUFSigla',fld:'vISAUTHORIZED_MICRORREGIAOMESOUFSIGLA',pic:'',hsh:true},{av:'Ddo_gridcolumnsselector_Columnsselectorvalues',ctrl:'DDO_GRIDCOLUMNSSELECTOR',prop:'ColumnsSelectorValues'}]");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED",",oparms:[{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'edtMicrorregiaoID_Visible',ctrl:'MICRORREGIAOID',prop:'Visible'},{av:'edtMicrorregiaoNome_Visible',ctrl:'MICRORREGIAONOME',prop:'Visible'},{av:'edtMicrorregiaoMesoNome_Visible',ctrl:'MICRORREGIAOMESONOME',prop:'Visible'},{av:'edtMicrorregiaoMesoUFSigla_Visible',ctrl:'MICRORREGIAOMESOUFSIGLA',prop:'Visible'},{av:'edtMicrorregiaoMesoUFRegNome_Visible',ctrl:'MICRORREGIAOMESOUFREGNOME',prop:'Visible'},{av:'AV41GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV42GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV43GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV24ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","{handler:'E114I2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV49Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV27TFMicrorregiaoID',fld:'vTFMICRORREGIAOID',pic:'ZZZ,ZZZ,ZZ9'},{av:'AV28TFMicrorregiaoID_To',fld:'vTFMICRORREGIAOID_TO',pic:'ZZZ,ZZZ,ZZ9'},{av:'AV29TFMicrorregiaoNome',fld:'vTFMICRORREGIAONOME',pic:''},{av:'AV30TFMicrorregiaoNome_Sel',fld:'vTFMICRORREGIAONOME_SEL',pic:''},{av:'AV31TFMicrorregiaoMesoNome',fld:'vTFMICRORREGIAOMESONOME',pic:''},{av:'AV32TFMicrorregiaoMesoNome_Sel',fld:'vTFMICRORREGIAOMESONOME_SEL',pic:''},{av:'AV33TFMicrorregiaoMesoUFSigla',fld:'vTFMICRORREGIAOMESOUFSIGLA',pic:'@!'},{av:'AV34TFMicrorregiaoMesoUFSigla_Sel',fld:'vTFMICRORREGIAOMESOUFSIGLA_SEL',pic:'@!'},{av:'AV35TFMicrorregiaoMesoUFRegNome',fld:'vTFMICRORREGIAOMESOUFREGNOME',pic:''},{av:'AV36TFMicrorregiaoMesoUFRegNome_Sel',fld:'vTFMICRORREGIAOMESOUFREGNOME_SEL',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV48IsAuthorized_MicrorregiaoNome',fld:'vISAUTHORIZED_MICRORREGIAONOME',pic:'',hsh:true},{av:'AV44IsAuthorized_MicrorregiaoMesoNome',fld:'vISAUTHORIZED_MICRORREGIAOMESONOME',pic:'',hsh:true},{av:'AV45IsAuthorized_MicrorregiaoMesoUFSigla',fld:'vISAUTHORIZED_MICRORREGIAOMESOUFSIGLA',pic:'',hsh:true},{av:'Ddo_managefilters_Activeeventkey',ctrl:'DDO_MANAGEFILTERS',prop:'ActiveEventKey'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",",oparms:[{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV27TFMicrorregiaoID',fld:'vTFMICRORREGIAOID',pic:'ZZZ,ZZZ,ZZ9'},{av:'AV28TFMicrorregiaoID_To',fld:'vTFMICRORREGIAOID_TO',pic:'ZZZ,ZZZ,ZZ9'},{av:'AV29TFMicrorregiaoNome',fld:'vTFMICRORREGIAONOME',pic:''},{av:'AV30TFMicrorregiaoNome_Sel',fld:'vTFMICRORREGIAONOME_SEL',pic:''},{av:'AV31TFMicrorregiaoMesoNome',fld:'vTFMICRORREGIAOMESONOME',pic:''},{av:'AV32TFMicrorregiaoMesoNome_Sel',fld:'vTFMICRORREGIAOMESONOME_SEL',pic:''},{av:'AV33TFMicrorregiaoMesoUFSigla',fld:'vTFMICRORREGIAOMESOUFSIGLA',pic:'@!'},{av:'AV34TFMicrorregiaoMesoUFSigla_Sel',fld:'vTFMICRORREGIAOMESOUFSIGLA_SEL',pic:'@!'},{av:'AV35TFMicrorregiaoMesoUFRegNome',fld:'vTFMICRORREGIAOMESOUFREGNOME',pic:''},{av:'AV36TFMicrorregiaoMesoUFRegNome_Sel',fld:'vTFMICRORREGIAOMESOUFREGNOME_SEL',pic:''},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtMicrorregiaoID_Visible',ctrl:'MICRORREGIAOID',prop:'Visible'},{av:'edtMicrorregiaoNome_Visible',ctrl:'MICRORREGIAONOME',prop:'Visible'},{av:'edtMicrorregiaoMesoNome_Visible',ctrl:'MICRORREGIAOMESONOME',prop:'Visible'},{av:'edtMicrorregiaoMesoUFSigla_Visible',ctrl:'MICRORREGIAOMESOUFSIGLA',prop:'Visible'},{av:'edtMicrorregiaoMesoUFRegNome_Visible',ctrl:'MICRORREGIAOMESOUFREGNOME',prop:'Visible'},{av:'AV41GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV42GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV43GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV24ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED","{handler:'E144I2',iparms:[{av:'Ddo_agexport_Activeeventkey',ctrl:'DDO_AGEXPORT',prop:'ActiveEventKey'},{av:'AV49Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30TFMicrorregiaoNome_Sel',fld:'vTFMICRORREGIAONOME_SEL',pic:''},{av:'AV32TFMicrorregiaoMesoNome_Sel',fld:'vTFMICRORREGIAOMESONOME_SEL',pic:''},{av:'AV34TFMicrorregiaoMesoUFSigla_Sel',fld:'vTFMICRORREGIAOMESOUFSIGLA_SEL',pic:'@!'},{av:'AV36TFMicrorregiaoMesoUFRegNome_Sel',fld:'vTFMICRORREGIAOMESOUFREGNOME_SEL',pic:''},{av:'AV27TFMicrorregiaoID',fld:'vTFMICRORREGIAOID',pic:'ZZZ,ZZZ,ZZ9'},{av:'AV29TFMicrorregiaoNome',fld:'vTFMICRORREGIAONOME',pic:''},{av:'AV31TFMicrorregiaoMesoNome',fld:'vTFMICRORREGIAOMESONOME',pic:''},{av:'AV33TFMicrorregiaoMesoUFSigla',fld:'vTFMICRORREGIAOMESOUFSIGLA',pic:'@!'},{av:'AV35TFMicrorregiaoMesoUFRegNome',fld:'vTFMICRORREGIAOMESOUFREGNOME',pic:''},{av:'AV28TFMicrorregiaoID_To',fld:'vTFMICRORREGIAOID_TO',pic:'ZZZ,ZZZ,ZZ9'}]");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED",",oparms:[{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV13OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV26ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV21ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV49Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV27TFMicrorregiaoID',fld:'vTFMICRORREGIAOID',pic:'ZZZ,ZZZ,ZZ9'},{av:'AV28TFMicrorregiaoID_To',fld:'vTFMICRORREGIAOID_TO',pic:'ZZZ,ZZZ,ZZ9'},{av:'AV29TFMicrorregiaoNome',fld:'vTFMICRORREGIAONOME',pic:''},{av:'AV30TFMicrorregiaoNome_Sel',fld:'vTFMICRORREGIAONOME_SEL',pic:''},{av:'AV31TFMicrorregiaoMesoNome',fld:'vTFMICRORREGIAOMESONOME',pic:''},{av:'AV32TFMicrorregiaoMesoNome_Sel',fld:'vTFMICRORREGIAOMESONOME_SEL',pic:''},{av:'AV33TFMicrorregiaoMesoUFSigla',fld:'vTFMICRORREGIAOMESOUFSIGLA',pic:'@!'},{av:'AV34TFMicrorregiaoMesoUFSigla_Sel',fld:'vTFMICRORREGIAOMESOUFSIGLA_SEL',pic:'@!'},{av:'AV35TFMicrorregiaoMesoUFRegNome',fld:'vTFMICRORREGIAOMESOUFREGNOME',pic:''},{av:'AV36TFMicrorregiaoMesoUFRegNome_Sel',fld:'vTFMICRORREGIAOMESOUFREGNOME_SEL',pic:''},{av:'AV48IsAuthorized_MicrorregiaoNome',fld:'vISAUTHORIZED_MICRORREGIAONOME',pic:'',hsh:true},{av:'AV44IsAuthorized_MicrorregiaoMesoNome',fld:'vISAUTHORIZED_MICRORREGIAOMESONOME',pic:'',hsh:true},{av:'AV45IsAuthorized_MicrorregiaoMesoUFSigla',fld:'vISAUTHORIZED_MICRORREGIAOMESOUFSIGLA',pic:'',hsh:true},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'}]}");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT","{handler:'E154I2',iparms:[]");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT",",oparms:[{ctrl:'WWPAUX_WC'}]}");
         setEventMetadata("NULL","{handler:'Valid_Microrregiaomesoufregnome',iparms:[]");
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
         Ddo_grid_Selectedcolumn = "";
         Ddo_grid_Filteredtext_get = "";
         Ddo_grid_Filteredtextto_get = "";
         Ddo_gridcolumnsselector_Columnsselectorvalues = "";
         Ddo_managefilters_Activeeventkey = "";
         Ddo_agexport_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV16FilterFullText = "";
         AV21ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV49Pgmname = "";
         AV29TFMicrorregiaoNome = "";
         AV30TFMicrorregiaoNome_Sel = "";
         AV31TFMicrorregiaoMesoNome = "";
         AV32TFMicrorregiaoMesoNome_Sel = "";
         AV33TFMicrorregiaoMesoUFSigla = "";
         AV34TFMicrorregiaoMesoUFSigla_Sel = "";
         AV35TFMicrorregiaoMesoUFRegNome = "";
         AV36TFMicrorregiaoMesoUFRegNome_Sel = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV24ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV43GridAppliedFilters = "";
         AV46AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV37DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV11GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
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
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridpaginationbar = new GXUserControl();
         ucDdo_agexport = new GXUserControl();
         ucDdc_subscriptions = new GXUserControl();
         ucDdo_grid = new GXUserControl();
         ucDdo_gridcolumnsselector = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         WebComp_Wwpaux_wc_Component = "";
         OldWwpaux_wc = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A24MicrorregiaoNome = "";
         A26MicrorregiaoMesoNome = "";
         A28MicrorregiaoMesoUFSigla = "";
         A33MicrorregiaoMesoUFRegNome = "";
         scmdbuf = "";
         lV50Core_microrregiaowwds_1_filterfulltext = "";
         lV53Core_microrregiaowwds_4_tfmicrorregiaonome = "";
         lV55Core_microrregiaowwds_6_tfmicrorregiaomesonome = "";
         lV57Core_microrregiaowwds_8_tfmicrorregiaomesoufsigla = "";
         lV59Core_microrregiaowwds_10_tfmicrorregiaomesoufregnome = "";
         AV50Core_microrregiaowwds_1_filterfulltext = "";
         AV54Core_microrregiaowwds_5_tfmicrorregiaonome_sel = "";
         AV53Core_microrregiaowwds_4_tfmicrorregiaonome = "";
         AV56Core_microrregiaowwds_7_tfmicrorregiaomesonome_sel = "";
         AV55Core_microrregiaowwds_6_tfmicrorregiaomesonome = "";
         AV58Core_microrregiaowwds_9_tfmicrorregiaomesoufsigla_sel = "";
         AV57Core_microrregiaowwds_8_tfmicrorregiaomesoufsigla = "";
         AV60Core_microrregiaowwds_11_tfmicrorregiaomesoufregnome_sel = "";
         AV59Core_microrregiaowwds_10_tfmicrorregiaomesoufregnome = "";
         H004I2_A25MicrorregiaoMesoID = new int[1] ;
         H004I2_A27MicrorregiaoMesoUFID = new int[1] ;
         H004I2_A33MicrorregiaoMesoUFRegNome = new string[] {""} ;
         H004I2_n33MicrorregiaoMesoUFRegNome = new bool[] {false} ;
         H004I2_A28MicrorregiaoMesoUFSigla = new string[] {""} ;
         H004I2_n28MicrorregiaoMesoUFSigla = new bool[] {false} ;
         H004I2_A26MicrorregiaoMesoNome = new string[] {""} ;
         H004I2_A24MicrorregiaoNome = new string[] {""} ;
         H004I2_A23MicrorregiaoID = new int[1] ;
         H004I3_AGRID_nRecordCount = new long[1] ;
         AV8HTTPRequest = new GxHttpRequest( context);
         AV47AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV38GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV39GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV23Session = context.GetSession();
         AV19ColumnsSelectorXML = "";
         GXEncryptionTmp = "";
         GridRow = new GXWebRow();
         AV25ManageFiltersXml = "";
         AV20UserCustomValue = "";
         AV22ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV12GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char7 = "";
         GXt_char6 = "";
         GXt_char5 = "";
         GXt_char3 = "";
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV17ExcelFilename = "";
         AV18ErrorMessage = "";
         ucDdo_managefilters = new GXUserControl();
         Ddo_managefilters_Caption = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.microrregiaoww__default(),
            new Object[][] {
                new Object[] {
               H004I2_A25MicrorregiaoMesoID, H004I2_A27MicrorregiaoMesoUFID, H004I2_A33MicrorregiaoMesoUFRegNome, H004I2_n33MicrorregiaoMesoUFRegNome, H004I2_A28MicrorregiaoMesoUFSigla, H004I2_n28MicrorregiaoMesoUFSigla, H004I2_A26MicrorregiaoMesoNome, H004I2_A24MicrorregiaoNome, H004I2_A23MicrorregiaoID
               }
               , new Object[] {
               H004I3_AGRID_nRecordCount
               }
            }
         );
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         AV49Pgmname = "core.microrregiaoWW";
         /* GeneXus formulas. */
         AV49Pgmname = "core.microrregiaoWW";
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV26ManageFiltersExecutionStep ;
      private short AV13OrderedBy ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_41 ;
      private int nGXsfl_41_idx=1 ;
      private int AV27TFMicrorregiaoID ;
      private int AV28TFMicrorregiaoID_To ;
      private int A25MicrorregiaoMesoID ;
      private int A27MicrorregiaoMesoUFID ;
      private int Gridpaginationbar_Pagestoshow ;
      private int bttBtnsubscriptions_Visible ;
      private int A23MicrorregiaoID ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int AV51Core_microrregiaowwds_2_tfmicrorregiaoid ;
      private int AV52Core_microrregiaowwds_3_tfmicrorregiaoid_to ;
      private int edtMicrorregiaoID_Visible ;
      private int edtMicrorregiaoNome_Visible ;
      private int edtMicrorregiaoMesoNome_Visible ;
      private int edtMicrorregiaoMesoUFSigla_Visible ;
      private int edtMicrorregiaoMesoUFRegNome_Visible ;
      private int AV40PageToGo ;
      private int AV61GXV1 ;
      private int edtavFilterfulltext_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV41GridCurrentPage ;
      private long AV42GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_gridcolumnsselector_Columnsselectorvalues ;
      private string Ddo_managefilters_Activeeventkey ;
      private string Ddo_agexport_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_41_idx="0001" ;
      private string AV49Pgmname ;
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
      private string divGridtablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string Gridpaginationbar_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Ddo_agexport_Internalname ;
      private string Ddc_subscriptions_Internalname ;
      private string Ddo_grid_Internalname ;
      private string Ddo_gridcolumnsselector_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string divDiv_wwpauxwc_Internalname ;
      private string WebComp_Wwpaux_wc_Component ;
      private string OldWwpaux_wc ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtMicrorregiaoID_Internalname ;
      private string edtMicrorregiaoNome_Internalname ;
      private string edtMicrorregiaoMesoNome_Internalname ;
      private string edtMicrorregiaoMesoUFSigla_Internalname ;
      private string edtMicrorregiaoMesoUFRegNome_Internalname ;
      private string edtavFilterfulltext_Internalname ;
      private string scmdbuf ;
      private string edtMicrorregiaoNome_Link ;
      private string GXEncryptionTmp ;
      private string edtMicrorregiaoMesoNome_Link ;
      private string edtMicrorregiaoMesoUFSigla_Link ;
      private string GXt_char7 ;
      private string GXt_char6 ;
      private string GXt_char5 ;
      private string GXt_char3 ;
      private string tblTablerightheader_Internalname ;
      private string Ddo_managefilters_Caption ;
      private string Ddo_managefilters_Internalname ;
      private string tblTablefilters_Internalname ;
      private string edtavFilterfulltext_Jsonclick ;
      private string sGXsfl_41_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtMicrorregiaoID_Jsonclick ;
      private string edtMicrorregiaoNome_Jsonclick ;
      private string edtMicrorregiaoMesoNome_Jsonclick ;
      private string edtMicrorregiaoMesoUFSigla_Jsonclick ;
      private string edtMicrorregiaoMesoUFRegNome_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV14OrderedDsc ;
      private bool AV48IsAuthorized_MicrorregiaoNome ;
      private bool AV44IsAuthorized_MicrorregiaoMesoNome ;
      private bool AV45IsAuthorized_MicrorregiaoMesoUFSigla ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool Grid_empowerer_Hascolumnsselector ;
      private bool wbLoad ;
      private bool bGXsfl_41_Refreshing=false ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n28MicrorregiaoMesoUFSigla ;
      private bool n33MicrorregiaoMesoUFRegNome ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool GXt_boolean1 ;
      private bool gx_refresh_fired ;
      private bool bDynCreated_Wwpaux_wc ;
      private string AV19ColumnsSelectorXML ;
      private string AV25ManageFiltersXml ;
      private string AV20UserCustomValue ;
      private string AV16FilterFullText ;
      private string AV29TFMicrorregiaoNome ;
      private string AV30TFMicrorregiaoNome_Sel ;
      private string AV31TFMicrorregiaoMesoNome ;
      private string AV32TFMicrorregiaoMesoNome_Sel ;
      private string AV33TFMicrorregiaoMesoUFSigla ;
      private string AV34TFMicrorregiaoMesoUFSigla_Sel ;
      private string AV35TFMicrorregiaoMesoUFRegNome ;
      private string AV36TFMicrorregiaoMesoUFRegNome_Sel ;
      private string AV43GridAppliedFilters ;
      private string A24MicrorregiaoNome ;
      private string A26MicrorregiaoMesoNome ;
      private string A28MicrorregiaoMesoUFSigla ;
      private string A33MicrorregiaoMesoUFRegNome ;
      private string lV50Core_microrregiaowwds_1_filterfulltext ;
      private string lV53Core_microrregiaowwds_4_tfmicrorregiaonome ;
      private string lV55Core_microrregiaowwds_6_tfmicrorregiaomesonome ;
      private string lV57Core_microrregiaowwds_8_tfmicrorregiaomesoufsigla ;
      private string lV59Core_microrregiaowwds_10_tfmicrorregiaomesoufregnome ;
      private string AV50Core_microrregiaowwds_1_filterfulltext ;
      private string AV54Core_microrregiaowwds_5_tfmicrorregiaonome_sel ;
      private string AV53Core_microrregiaowwds_4_tfmicrorregiaonome ;
      private string AV56Core_microrregiaowwds_7_tfmicrorregiaomesonome_sel ;
      private string AV55Core_microrregiaowwds_6_tfmicrorregiaomesonome ;
      private string AV58Core_microrregiaowwds_9_tfmicrorregiaomesoufsigla_sel ;
      private string AV57Core_microrregiaowwds_8_tfmicrorregiaomesoufsigla ;
      private string AV60Core_microrregiaowwds_11_tfmicrorregiaomesoufregnome_sel ;
      private string AV59Core_microrregiaowwds_10_tfmicrorregiaomesoufregnome ;
      private string AV17ExcelFilename ;
      private string AV18ErrorMessage ;
      private IGxSession AV23Session ;
      private GXWebComponent WebComp_Wwpaux_wc ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_agexport ;
      private GXUserControl ucDdc_subscriptions ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucDdo_gridcolumnsselector ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucDdo_managefilters ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] H004I2_A25MicrorregiaoMesoID ;
      private int[] H004I2_A27MicrorregiaoMesoUFID ;
      private string[] H004I2_A33MicrorregiaoMesoUFRegNome ;
      private bool[] H004I2_n33MicrorregiaoMesoUFRegNome ;
      private string[] H004I2_A28MicrorregiaoMesoUFSigla ;
      private bool[] H004I2_n28MicrorregiaoMesoUFSigla ;
      private string[] H004I2_A26MicrorregiaoMesoNome ;
      private string[] H004I2_A24MicrorregiaoNome ;
      private int[] H004I2_A23MicrorregiaoID ;
      private long[] H004I3_AGRID_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV8HTTPRequest ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV24ManageFiltersData ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV46AGExportData ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV39GAMErrors ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV12GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV21ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV22ColumnsSelectorAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item AV47AGExportDataItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV37DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV38GAMSession ;
   }

   public class microrregiaoww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H004I2( IGxContext context ,
                                             string AV50Core_microrregiaowwds_1_filterfulltext ,
                                             int AV51Core_microrregiaowwds_2_tfmicrorregiaoid ,
                                             int AV52Core_microrregiaowwds_3_tfmicrorregiaoid_to ,
                                             string AV54Core_microrregiaowwds_5_tfmicrorregiaonome_sel ,
                                             string AV53Core_microrregiaowwds_4_tfmicrorregiaonome ,
                                             string AV56Core_microrregiaowwds_7_tfmicrorregiaomesonome_sel ,
                                             string AV55Core_microrregiaowwds_6_tfmicrorregiaomesonome ,
                                             string AV58Core_microrregiaowwds_9_tfmicrorregiaomesoufsigla_sel ,
                                             string AV57Core_microrregiaowwds_8_tfmicrorregiaomesoufsigla ,
                                             string AV60Core_microrregiaowwds_11_tfmicrorregiaomesoufregnome_sel ,
                                             string AV59Core_microrregiaowwds_10_tfmicrorregiaomesoufregnome ,
                                             int A23MicrorregiaoID ,
                                             string A24MicrorregiaoNome ,
                                             string A26MicrorregiaoMesoNome ,
                                             string A28MicrorregiaoMesoUFSigla ,
                                             string A33MicrorregiaoMesoUFRegNome ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[18];
         Object[] GXv_Object9 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " MicrorregiaoMesoID, MicrorregiaoMesoUFID, MicrorregiaoMesoUFRegNome, MicrorregiaoMesoUFSigla, MicrorregiaoMesoNome, MicrorregiaoNome, MicrorregiaoID";
         sFromString = " FROM tbibge_microrregiao";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Core_microrregiaowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(MicrorregiaoID,'999999999'), 2) like '%' || :lV50Core_microrregiaowwds_1_filterfulltext) or ( MicrorregiaoNome like '%' || :lV50Core_microrregiaowwds_1_filterfulltext) or ( MicrorregiaoMesoNome like '%' || :lV50Core_microrregiaowwds_1_filterfulltext) or ( MicrorregiaoMesoUFSigla like '%' || :lV50Core_microrregiaowwds_1_filterfulltext) or ( MicrorregiaoMesoUFRegNome like '%' || :lV50Core_microrregiaowwds_1_filterfulltext))");
         }
         else
         {
            GXv_int8[0] = 1;
            GXv_int8[1] = 1;
            GXv_int8[2] = 1;
            GXv_int8[3] = 1;
            GXv_int8[4] = 1;
         }
         if ( ! (0==AV51Core_microrregiaowwds_2_tfmicrorregiaoid) )
         {
            AddWhere(sWhereString, "(MicrorregiaoID >= :AV51Core_microrregiaowwds_2_tfmicrorregiaoid)");
         }
         else
         {
            GXv_int8[5] = 1;
         }
         if ( ! (0==AV52Core_microrregiaowwds_3_tfmicrorregiaoid_to) )
         {
            AddWhere(sWhereString, "(MicrorregiaoID <= :AV52Core_microrregiaowwds_3_tfmicrorregiaoid_to)");
         }
         else
         {
            GXv_int8[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Core_microrregiaowwds_5_tfmicrorregiaonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Core_microrregiaowwds_4_tfmicrorregiaonome)) ) )
         {
            AddWhere(sWhereString, "(MicrorregiaoNome like :lV53Core_microrregiaowwds_4_tfmicrorregiaonome)");
         }
         else
         {
            GXv_int8[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Core_microrregiaowwds_5_tfmicrorregiaonome_sel)) && ! ( StringUtil.StrCmp(AV54Core_microrregiaowwds_5_tfmicrorregiaonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(MicrorregiaoNome = ( :AV54Core_microrregiaowwds_5_tfmicrorregiaonome_sel))");
         }
         else
         {
            GXv_int8[8] = 1;
         }
         if ( StringUtil.StrCmp(AV54Core_microrregiaowwds_5_tfmicrorregiaonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from MicrorregiaoNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Core_microrregiaowwds_7_tfmicrorregiaomesonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Core_microrregiaowwds_6_tfmicrorregiaomesonome)) ) )
         {
            AddWhere(sWhereString, "(MicrorregiaoMesoNome like :lV55Core_microrregiaowwds_6_tfmicrorregiaomesonome)");
         }
         else
         {
            GXv_int8[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Core_microrregiaowwds_7_tfmicrorregiaomesonome_sel)) && ! ( StringUtil.StrCmp(AV56Core_microrregiaowwds_7_tfmicrorregiaomesonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(MicrorregiaoMesoNome = ( :AV56Core_microrregiaowwds_7_tfmicrorregiaomesonome_sel))");
         }
         else
         {
            GXv_int8[10] = 1;
         }
         if ( StringUtil.StrCmp(AV56Core_microrregiaowwds_7_tfmicrorregiaomesonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from MicrorregiaoMesoNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Core_microrregiaowwds_9_tfmicrorregiaomesoufsigla_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Core_microrregiaowwds_8_tfmicrorregiaomesoufsigla)) ) )
         {
            AddWhere(sWhereString, "(MicrorregiaoMesoUFSigla like :lV57Core_microrregiaowwds_8_tfmicrorregiaomesoufsigla)");
         }
         else
         {
            GXv_int8[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Core_microrregiaowwds_9_tfmicrorregiaomesoufsigla_sel)) && ! ( StringUtil.StrCmp(AV58Core_microrregiaowwds_9_tfmicrorregiaomesoufsigla_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(MicrorregiaoMesoUFSigla = ( :AV58Core_microrregiaowwds_9_tfmicrorregiaomesoufsigla_sel))");
         }
         else
         {
            GXv_int8[12] = 1;
         }
         if ( StringUtil.StrCmp(AV58Core_microrregiaowwds_9_tfmicrorregiaomesoufsigla_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from MicrorregiaoMesoUFSigla))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Core_microrregiaowwds_11_tfmicrorregiaomesoufregnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Core_microrregiaowwds_10_tfmicrorregiaomesoufregnome)) ) )
         {
            AddWhere(sWhereString, "(MicrorregiaoMesoUFRegNome like :lV59Core_microrregiaowwds_10_tfmicrorregiaomesoufregnome)");
         }
         else
         {
            GXv_int8[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Core_microrregiaowwds_11_tfmicrorregiaomesoufregnome_sel)) && ! ( StringUtil.StrCmp(AV60Core_microrregiaowwds_11_tfmicrorregiaomesoufregnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(MicrorregiaoMesoUFRegNome = ( :AV60Core_microrregiaowwds_11_tfmicrorregiaomesoufregnome_sel))");
         }
         else
         {
            GXv_int8[14] = 1;
         }
         if ( StringUtil.StrCmp(AV60Core_microrregiaowwds_11_tfmicrorregiaomesoufregnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from MicrorregiaoMesoUFRegNome))=0))");
         }
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY MicrorregiaoNome, MicrorregiaoID";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY MicrorregiaoNome DESC, MicrorregiaoID";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY MicrorregiaoID";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY MicrorregiaoID DESC";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY MicrorregiaoMesoNome, MicrorregiaoID";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY MicrorregiaoMesoNome DESC, MicrorregiaoID";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY MicrorregiaoMesoUFSigla, MicrorregiaoID";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY MicrorregiaoMesoUFSigla DESC, MicrorregiaoID";
         }
         else if ( ( AV13OrderedBy == 5 ) && ! AV14OrderedDsc )
         {
            sOrderString += " ORDER BY MicrorregiaoMesoUFRegNome, MicrorregiaoID";
         }
         else if ( ( AV13OrderedBy == 5 ) && ( AV14OrderedDsc ) )
         {
            sOrderString += " ORDER BY MicrorregiaoMesoUFRegNome DESC, MicrorregiaoID";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY MicrorregiaoID";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object9[0] = scmdbuf;
         GXv_Object9[1] = GXv_int8;
         return GXv_Object9 ;
      }

      protected Object[] conditional_H004I3( IGxContext context ,
                                             string AV50Core_microrregiaowwds_1_filterfulltext ,
                                             int AV51Core_microrregiaowwds_2_tfmicrorregiaoid ,
                                             int AV52Core_microrregiaowwds_3_tfmicrorregiaoid_to ,
                                             string AV54Core_microrregiaowwds_5_tfmicrorregiaonome_sel ,
                                             string AV53Core_microrregiaowwds_4_tfmicrorregiaonome ,
                                             string AV56Core_microrregiaowwds_7_tfmicrorregiaomesonome_sel ,
                                             string AV55Core_microrregiaowwds_6_tfmicrorregiaomesonome ,
                                             string AV58Core_microrregiaowwds_9_tfmicrorregiaomesoufsigla_sel ,
                                             string AV57Core_microrregiaowwds_8_tfmicrorregiaomesoufsigla ,
                                             string AV60Core_microrregiaowwds_11_tfmicrorregiaomesoufregnome_sel ,
                                             string AV59Core_microrregiaowwds_10_tfmicrorregiaomesoufregnome ,
                                             int A23MicrorregiaoID ,
                                             string A24MicrorregiaoNome ,
                                             string A26MicrorregiaoMesoNome ,
                                             string A28MicrorregiaoMesoUFSigla ,
                                             string A33MicrorregiaoMesoUFRegNome ,
                                             short AV13OrderedBy ,
                                             bool AV14OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int10 = new short[15];
         Object[] GXv_Object11 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM tbibge_microrregiao";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Core_microrregiaowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(MicrorregiaoID,'999999999'), 2) like '%' || :lV50Core_microrregiaowwds_1_filterfulltext) or ( MicrorregiaoNome like '%' || :lV50Core_microrregiaowwds_1_filterfulltext) or ( MicrorregiaoMesoNome like '%' || :lV50Core_microrregiaowwds_1_filterfulltext) or ( MicrorregiaoMesoUFSigla like '%' || :lV50Core_microrregiaowwds_1_filterfulltext) or ( MicrorregiaoMesoUFRegNome like '%' || :lV50Core_microrregiaowwds_1_filterfulltext))");
         }
         else
         {
            GXv_int10[0] = 1;
            GXv_int10[1] = 1;
            GXv_int10[2] = 1;
            GXv_int10[3] = 1;
            GXv_int10[4] = 1;
         }
         if ( ! (0==AV51Core_microrregiaowwds_2_tfmicrorregiaoid) )
         {
            AddWhere(sWhereString, "(MicrorregiaoID >= :AV51Core_microrregiaowwds_2_tfmicrorregiaoid)");
         }
         else
         {
            GXv_int10[5] = 1;
         }
         if ( ! (0==AV52Core_microrregiaowwds_3_tfmicrorregiaoid_to) )
         {
            AddWhere(sWhereString, "(MicrorregiaoID <= :AV52Core_microrregiaowwds_3_tfmicrorregiaoid_to)");
         }
         else
         {
            GXv_int10[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Core_microrregiaowwds_5_tfmicrorregiaonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Core_microrregiaowwds_4_tfmicrorregiaonome)) ) )
         {
            AddWhere(sWhereString, "(MicrorregiaoNome like :lV53Core_microrregiaowwds_4_tfmicrorregiaonome)");
         }
         else
         {
            GXv_int10[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Core_microrregiaowwds_5_tfmicrorregiaonome_sel)) && ! ( StringUtil.StrCmp(AV54Core_microrregiaowwds_5_tfmicrorregiaonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(MicrorregiaoNome = ( :AV54Core_microrregiaowwds_5_tfmicrorregiaonome_sel))");
         }
         else
         {
            GXv_int10[8] = 1;
         }
         if ( StringUtil.StrCmp(AV54Core_microrregiaowwds_5_tfmicrorregiaonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from MicrorregiaoNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Core_microrregiaowwds_7_tfmicrorregiaomesonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Core_microrregiaowwds_6_tfmicrorregiaomesonome)) ) )
         {
            AddWhere(sWhereString, "(MicrorregiaoMesoNome like :lV55Core_microrregiaowwds_6_tfmicrorregiaomesonome)");
         }
         else
         {
            GXv_int10[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Core_microrregiaowwds_7_tfmicrorregiaomesonome_sel)) && ! ( StringUtil.StrCmp(AV56Core_microrregiaowwds_7_tfmicrorregiaomesonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(MicrorregiaoMesoNome = ( :AV56Core_microrregiaowwds_7_tfmicrorregiaomesonome_sel))");
         }
         else
         {
            GXv_int10[10] = 1;
         }
         if ( StringUtil.StrCmp(AV56Core_microrregiaowwds_7_tfmicrorregiaomesonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from MicrorregiaoMesoNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Core_microrregiaowwds_9_tfmicrorregiaomesoufsigla_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Core_microrregiaowwds_8_tfmicrorregiaomesoufsigla)) ) )
         {
            AddWhere(sWhereString, "(MicrorregiaoMesoUFSigla like :lV57Core_microrregiaowwds_8_tfmicrorregiaomesoufsigla)");
         }
         else
         {
            GXv_int10[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Core_microrregiaowwds_9_tfmicrorregiaomesoufsigla_sel)) && ! ( StringUtil.StrCmp(AV58Core_microrregiaowwds_9_tfmicrorregiaomesoufsigla_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(MicrorregiaoMesoUFSigla = ( :AV58Core_microrregiaowwds_9_tfmicrorregiaomesoufsigla_sel))");
         }
         else
         {
            GXv_int10[12] = 1;
         }
         if ( StringUtil.StrCmp(AV58Core_microrregiaowwds_9_tfmicrorregiaomesoufsigla_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from MicrorregiaoMesoUFSigla))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Core_microrregiaowwds_11_tfmicrorregiaomesoufregnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Core_microrregiaowwds_10_tfmicrorregiaomesoufregnome)) ) )
         {
            AddWhere(sWhereString, "(MicrorregiaoMesoUFRegNome like :lV59Core_microrregiaowwds_10_tfmicrorregiaomesoufregnome)");
         }
         else
         {
            GXv_int10[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Core_microrregiaowwds_11_tfmicrorregiaomesoufregnome_sel)) && ! ( StringUtil.StrCmp(AV60Core_microrregiaowwds_11_tfmicrorregiaomesoufregnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(MicrorregiaoMesoUFRegNome = ( :AV60Core_microrregiaowwds_11_tfmicrorregiaomesoufregnome_sel))");
         }
         else
         {
            GXv_int10[14] = 1;
         }
         if ( StringUtil.StrCmp(AV60Core_microrregiaowwds_11_tfmicrorregiaomesoufregnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from MicrorregiaoMesoUFRegNome))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV13OrderedBy == 1 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 1 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 2 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 2 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 3 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 3 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 4 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 4 ) && ( AV14OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 5 ) && ! AV14OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV13OrderedBy == 5 ) && ( AV14OrderedDsc ) )
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
                     return conditional_H004I2(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (short)dynConstraints[16] , (bool)dynConstraints[17] );
               case 1 :
                     return conditional_H004I3(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (short)dynConstraints[16] , (bool)dynConstraints[17] );
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
          Object[] prmH004I2;
          prmH004I2 = new Object[] {
          new ParDef("lV50Core_microrregiaowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Core_microrregiaowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Core_microrregiaowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Core_microrregiaowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Core_microrregiaowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV51Core_microrregiaowwds_2_tfmicrorregiaoid",GXType.Int32,9,0) ,
          new ParDef("AV52Core_microrregiaowwds_3_tfmicrorregiaoid_to",GXType.Int32,9,0) ,
          new ParDef("lV53Core_microrregiaowwds_4_tfmicrorregiaonome",GXType.VarChar,80,0) ,
          new ParDef("AV54Core_microrregiaowwds_5_tfmicrorregiaonome_sel",GXType.VarChar,80,0) ,
          new ParDef("lV55Core_microrregiaowwds_6_tfmicrorregiaomesonome",GXType.VarChar,80,0) ,
          new ParDef("AV56Core_microrregiaowwds_7_tfmicrorregiaomesonome_sel",GXType.VarChar,80,0) ,
          new ParDef("lV57Core_microrregiaowwds_8_tfmicrorregiaomesoufsigla",GXType.VarChar,2,0) ,
          new ParDef("AV58Core_microrregiaowwds_9_tfmicrorregiaomesoufsigla_sel",GXType.VarChar,2,0) ,
          new ParDef("lV59Core_microrregiaowwds_10_tfmicrorregiaomesoufregnome",GXType.VarChar,50,0) ,
          new ParDef("AV60Core_microrregiaowwds_11_tfmicrorregiaomesoufregnome_sel",GXType.VarChar,50,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH004I3;
          prmH004I3 = new Object[] {
          new ParDef("lV50Core_microrregiaowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Core_microrregiaowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Core_microrregiaowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Core_microrregiaowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Core_microrregiaowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV51Core_microrregiaowwds_2_tfmicrorregiaoid",GXType.Int32,9,0) ,
          new ParDef("AV52Core_microrregiaowwds_3_tfmicrorregiaoid_to",GXType.Int32,9,0) ,
          new ParDef("lV53Core_microrregiaowwds_4_tfmicrorregiaonome",GXType.VarChar,80,0) ,
          new ParDef("AV54Core_microrregiaowwds_5_tfmicrorregiaonome_sel",GXType.VarChar,80,0) ,
          new ParDef("lV55Core_microrregiaowwds_6_tfmicrorregiaomesonome",GXType.VarChar,80,0) ,
          new ParDef("AV56Core_microrregiaowwds_7_tfmicrorregiaomesonome_sel",GXType.VarChar,80,0) ,
          new ParDef("lV57Core_microrregiaowwds_8_tfmicrorregiaomesoufsigla",GXType.VarChar,2,0) ,
          new ParDef("AV58Core_microrregiaowwds_9_tfmicrorregiaomesoufsigla_sel",GXType.VarChar,2,0) ,
          new ParDef("lV59Core_microrregiaowwds_10_tfmicrorregiaomesoufregnome",GXType.VarChar,50,0) ,
          new ParDef("AV60Core_microrregiaowwds_11_tfmicrorregiaomesoufregnome_sel",GXType.VarChar,50,0)
          };
          def= new CursorDef[] {
              new CursorDef("H004I2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004I2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H004I3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004I3,1, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((string[]) buf[6])[0] = rslt.getVarchar(5);
                ((string[]) buf[7])[0] = rslt.getVarchar(6);
                ((int[]) buf[8])[0] = rslt.getInt(7);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
