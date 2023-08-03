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
   public class negociopjsemfaseprompt : GXDataArea
   {
      public negociopjsemfaseprompt( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public negociopjsemfaseprompt( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_NegID_WSKey )
      {
         this.AV48NegID_WSKey = aP0_NegID_WSKey;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         chkavSelected = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "NegID_WSKey");
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
               gxfirstwebparm = GetFirstPar( "NegID_WSKey");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "NegID_WSKey");
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
            if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               AV48NegID_WSKey = gxfirstwebparm;
               AssignAttri("", false, "AV48NegID_WSKey", AV48NegID_WSKey);
               GxWebStd.gx_hidden_field( context, "gxhash_vNEGID_WSKEY", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV48NegID_WSKey, "")), context));
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
         nRC_GXsfl_35 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_35"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_35_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_35_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_35_idx = GetPar( "sGXsfl_35_idx");
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
         AV14FilterFullText = GetPar( "FilterFullText");
         AV48NegID_WSKey = GetPar( "NegID_WSKey");
         AV58Pgmname = GetPar( "Pgmname");
         AV11OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV12OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         AV13NegUltFase_Vazio = (int)(Math.Round(NumberUtil.Val( GetPar( "NegUltFase_Vazio"), "."), 18, MidpointRounding.ToEven));
         AV17TFNegCodigo = (long)(Math.Round(NumberUtil.Val( GetPar( "TFNegCodigo"), "."), 18, MidpointRounding.ToEven));
         AV18TFNegCodigo_To = (long)(Math.Round(NumberUtil.Val( GetPar( "TFNegCodigo_To"), "."), 18, MidpointRounding.ToEven));
         AV19TFNegAssunto = GetPar( "TFNegAssunto");
         AV20TFNegAssunto_Sel = GetPar( "TFNegAssunto_Sel");
         AV21TFNegCliNomeFamiliar = GetPar( "TFNegCliNomeFamiliar");
         AV22TFNegCliNomeFamiliar_Sel = GetPar( "TFNegCliNomeFamiliar_Sel");
         AV23TFNegCpjNomFan = GetPar( "TFNegCpjNomFan");
         AV24TFNegCpjNomFan_Sel = GetPar( "TFNegCpjNomFan_Sel");
         AV25TFNegCpjMatricula = (long)(Math.Round(NumberUtil.Val( GetPar( "TFNegCpjMatricula"), "."), 18, MidpointRounding.ToEven));
         AV26TFNegCpjMatricula_To = (long)(Math.Round(NumberUtil.Val( GetPar( "TFNegCpjMatricula_To"), "."), 18, MidpointRounding.ToEven));
         AV27TFNegPjtNome = GetPar( "TFNegPjtNome");
         AV28TFNegPjtNome_Sel = GetPar( "TFNegPjtNome_Sel");
         AV29TFNegAgcNome = GetPar( "TFNegAgcNome");
         AV30TFNegAgcNome_Sel = GetPar( "TFNegAgcNome_Sel");
         AV31TFNegInsData = context.localUtil.ParseDateParm( GetPar( "TFNegInsData"));
         AV32TFNegInsData_To = context.localUtil.ParseDateParm( GetPar( "TFNegInsData_To"));
         AV53i = (long)(Math.Round(NumberUtil.Val( GetPar( "i"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV46NegIDCol);
         AV52NegIDToFind = StringUtil.StrToGuid( GetPar( "NegIDToFind"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV14FilterFullText, AV48NegID_WSKey, AV58Pgmname, AV11OrderedBy, AV12OrderedDsc, AV13NegUltFase_Vazio, AV17TFNegCodigo, AV18TFNegCodigo_To, AV19TFNegAssunto, AV20TFNegAssunto_Sel, AV21TFNegCliNomeFamiliar, AV22TFNegCliNomeFamiliar_Sel, AV23TFNegCpjNomFan, AV24TFNegCpjNomFan_Sel, AV25TFNegCpjMatricula, AV26TFNegCpjMatricula_To, AV27TFNegPjtNome, AV28TFNegPjtNome_Sel, AV29TFNegAgcNome, AV30TFNegAgcNome_Sel, AV31TFNegInsData, AV32TFNegInsData_To, AV53i, AV46NegIDCol, AV52NegIDToFind) ;
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
            return "negociopjprompt_Execute" ;
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
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("wwpbaseobjects.workwithplusmasterpageprompt", "GeneXus.Programs.wwpbaseobjects.workwithplusmasterpageprompt", new Object[] {context});
            MasterPageObj.setDataArea(this,true);
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
         PA522( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START522( ) ;
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
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
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
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
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
         context.WriteHtmlText( " "+"class=\"form-horizontal FormNoBackgroundColor\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormNoBackgroundColor\" data-gx-class=\"form-horizontal FormNoBackgroundColor\" novalidate action=\""+formatLink("core.negociopjsemfaseprompt.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV48NegID_WSKey))}, new string[] {"NegID_WSKey"}) +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal FormNoBackgroundColor", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "vNEGID_WSKEY", AV48NegID_WSKey);
         GxWebStd.gx_hidden_field( context, "gxhash_vNEGID_WSKEY", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV48NegID_WSKey, "")), context));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV58Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV58Pgmname, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vFILTERFULLTEXT", AV14FilterFullText);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_35", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_35), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV40GridCurrentPage), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV41GridPageCount), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV42GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV36DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV36DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, "vDDO_NEGINSDATAAUXDATE", context.localUtil.DToC( AV33DDO_NegInsDataAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_NEGINSDATAAUXDATETO", context.localUtil.DToC( AV34DDO_NegInsDataAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vNEGID_WSKEY", AV48NegID_WSKey);
         GxWebStd.gx_hidden_field( context, "gxhash_vNEGID_WSKEY", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV48NegID_WSKey, "")), context));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV58Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV58Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV12OrderedDsc);
         GxWebStd.gx_hidden_field( context, "vTFNEGCODIGO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17TFNegCodigo), 12, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFNEGCODIGO_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18TFNegCodigo_To), 12, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFNEGASSUNTO", AV19TFNegAssunto);
         GxWebStd.gx_hidden_field( context, "vTFNEGASSUNTO_SEL", AV20TFNegAssunto_Sel);
         GxWebStd.gx_hidden_field( context, "vTFNEGCLINOMEFAMILIAR", AV21TFNegCliNomeFamiliar);
         GxWebStd.gx_hidden_field( context, "vTFNEGCLINOMEFAMILIAR_SEL", AV22TFNegCliNomeFamiliar_Sel);
         GxWebStd.gx_hidden_field( context, "vTFNEGCPJNOMFAN", AV23TFNegCpjNomFan);
         GxWebStd.gx_hidden_field( context, "vTFNEGCPJNOMFAN_SEL", AV24TFNegCpjNomFan_Sel);
         GxWebStd.gx_hidden_field( context, "vTFNEGCPJMATRICULA", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25TFNegCpjMatricula), 12, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFNEGCPJMATRICULA_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26TFNegCpjMatricula_To), 12, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFNEGPJTNOME", AV27TFNegPjtNome);
         GxWebStd.gx_hidden_field( context, "vTFNEGPJTNOME_SEL", AV28TFNegPjtNome_Sel);
         GxWebStd.gx_hidden_field( context, "vTFNEGAGCNOME", AV29TFNegAgcNome);
         GxWebStd.gx_hidden_field( context, "vTFNEGAGCNOME_SEL", AV30TFNegAgcNome_Sel);
         GxWebStd.gx_hidden_field( context, "vTFNEGINSDATA", context.localUtil.DToC( AV31TFNegInsData, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFNEGINSDATA_TO", context.localUtil.DToC( AV32TFNegInsData_To, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vI", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV53i), 10, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vNEGIDCOL", AV46NegIDCol);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vNEGIDCOL", AV46NegIDCol);
         }
         GxWebStd.gx_hidden_field( context, "vNEGIDTOFIND", AV52NegIDToFind.ToString());
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
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
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Format", StringUtil.RTrim( Ddo_grid_Format));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_ENTER_Title", StringUtil.RTrim( Dvelop_confirmpanel_enter_Title));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_ENTER_Confirmationtext", StringUtil.RTrim( Dvelop_confirmpanel_enter_Confirmationtext));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_ENTER_Yesbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_enter_Yesbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_ENTER_Nobuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_enter_Nobuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_ENTER_Cancelbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_enter_Cancelbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_ENTER_Yesbuttonposition", StringUtil.RTrim( Dvelop_confirmpanel_enter_Yesbuttonposition));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_ENTER_Confirmtype", StringUtil.RTrim( Dvelop_confirmpanel_enter_Confirmtype));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_ENTER_Result", StringUtil.RTrim( Dvelop_confirmpanel_enter_Result));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
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
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal FormNoBackgroundColor" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE522( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT522( ) ;
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
         return formatLink("core.negociopjsemfaseprompt.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV48NegID_WSKey))}, new string[] {"NegID_WSKey"})  ;
      }

      public override string GetPgmname( )
      {
         return "core.NegocioPJSemFasePrompt" ;
      }

      public override string GetPgmdesc( )
      {
         return "Selecionar Oportunidades" ;
      }

      protected void WB520( )
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
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", divLayoutmaintable_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMainPrompt", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-xs hidden-sm hidden-md hidden-lg", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavNegultfase_vazio_Internalname, "Neg Ult Fase_Vazio", "col-sm-3 InvisibleLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 10,'',false,'" + sGXsfl_35_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavNegultfase_vazio_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13NegUltFase_Vazio), 8, 0, ",", "")), StringUtil.LTrim( ((edtavNegultfase_vazio_Enabled!=0) ? context.localUtil.Format( (decimal)(AV13NegUltFase_Vazio), "ZZZZZZZ9") : context.localUtil.Format( (decimal)(AV13NegUltFase_Vazio), "ZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,10);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavNegultfase_vazio_Jsonclick, 0, "Invisible", "", "", "", "", 1, edtavNegultfase_vazio_Enabled, 0, "text", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_core\\NegocioPJSemFasePrompt.htm");
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
            GxWebStd.gx_div_start( context, divTableheadercontent_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "CellMarginLeft15", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableactions_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroupColorFilledActions", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(35), 2, 0)+","+"null"+");", "Selecionar", bttBtnenter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\NegocioPJSemFasePrompt.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            wb_table1_23_522( true) ;
         }
         else
         {
            wb_table1_23_522( false) ;
         }
         return  ;
      }

      protected void wb_table1_23_522e( bool wbgen )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginLeft15 CellMarginBottom15 GridNoBorderCell HasGridEmpowerer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtablewithpaginationbar_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl35( ) ;
         }
         if ( wbEnd == 35 )
         {
            wbEnd = 0;
            nRC_GXsfl_35 = (int)(nGXsfl_35_idx-1);
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV40GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV41GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV42GridAppliedFilters);
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
            ucDdo_grid.SetProperty("Format", Ddo_grid_Format);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV36DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            wb_table2_63_522( true) ;
         }
         else
         {
            wb_table2_63_522( false) ;
         }
         return  ;
      }

      protected void wb_table2_63_522e( bool wbgen )
      {
         if ( wbgen )
         {
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_neginsdataauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 70,'',false,'" + sGXsfl_35_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_neginsdataauxdatetext_Internalname, AV35DDO_NegInsDataAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV35DDO_NegInsDataAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,70);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_neginsdataauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\NegocioPJSemFasePrompt.htm");
            /* User Defined Control */
            ucTfneginsdata_rangepicker.SetProperty("Start Date", AV33DDO_NegInsDataAuxDate);
            ucTfneginsdata_rangepicker.SetProperty("End Date", AV34DDO_NegInsDataAuxDateTo);
            ucTfneginsdata_rangepicker.Render(context, "wwp.daterangepicker", Tfneginsdata_rangepicker_Internalname, "TFNEGINSDATA_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 35 )
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

      protected void START522( )
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
            Form.Meta.addItem("description", "Selecionar Oportunidades", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP520( ) ;
      }

      protected void WS522( )
      {
         START522( ) ;
         EVT522( ) ;
      }

      protected void EVT522( )
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
                              E11522 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E12522 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E13522 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 Rfr0gs = false;
                                 /* Set Refresh If Filterfulltext Changed */
                                 if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV14FilterFullText) != 0 )
                                 {
                                    Rfr0gs = true;
                                 }
                                 if ( ! Rfr0gs )
                                 {
                                    /* Execute user event: Enter */
                                    E14522 ();
                                 }
                                 dynload_actions( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOCLEANFILTERS'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoCleanFilters' */
                              E15522 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 15), "VSELECTED.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 15), "VSELECTED.CLICK") == 0 ) )
                           {
                              nGXsfl_35_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_35_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_35_idx), 4, 0), 4, "0");
                              SubsflControlProps_352( ) ;
                              AV15Selected = StringUtil.StrToBool( cgiGet( chkavSelected_Internalname));
                              AssignAttri("", false, chkavSelected_Internalname, AV15Selected);
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
                                    E16522 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E17522 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E18522 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VSELECTED.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E19522 ();
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
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE522( )
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

      protected void PA522( )
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
               GX_FocusControl = edtavNegultfase_vazio_Internalname;
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
         SubsflControlProps_352( ) ;
         while ( nGXsfl_35_idx <= nRC_GXsfl_35 )
         {
            sendrow_352( ) ;
            nGXsfl_35_idx = ((subGrid_Islastpage==1)&&(nGXsfl_35_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_35_idx+1);
            sGXsfl_35_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_35_idx), 4, 0), 4, "0");
            SubsflControlProps_352( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       string AV14FilterFullText ,
                                       string AV48NegID_WSKey ,
                                       string AV58Pgmname ,
                                       short AV11OrderedBy ,
                                       bool AV12OrderedDsc ,
                                       int AV13NegUltFase_Vazio ,
                                       long AV17TFNegCodigo ,
                                       long AV18TFNegCodigo_To ,
                                       string AV19TFNegAssunto ,
                                       string AV20TFNegAssunto_Sel ,
                                       string AV21TFNegCliNomeFamiliar ,
                                       string AV22TFNegCliNomeFamiliar_Sel ,
                                       string AV23TFNegCpjNomFan ,
                                       string AV24TFNegCpjNomFan_Sel ,
                                       long AV25TFNegCpjMatricula ,
                                       long AV26TFNegCpjMatricula_To ,
                                       string AV27TFNegPjtNome ,
                                       string AV28TFNegPjtNome_Sel ,
                                       string AV29TFNegAgcNome ,
                                       string AV30TFNegAgcNome_Sel ,
                                       DateTime AV31TFNegInsData ,
                                       DateTime AV32TFNegInsData_To ,
                                       long AV53i ,
                                       GxSimpleCollection<Guid> AV46NegIDCol ,
                                       Guid AV52NegIDToFind )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF522( ) ;
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
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF522( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV58Pgmname = "core.NegocioPJSemFasePrompt";
      }

      protected void RF522( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 35;
         /* Execute user event: Refresh */
         E17522 ();
         nGXsfl_35_idx = 1;
         sGXsfl_35_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_35_idx), 4, 0), 4, "0");
         SubsflControlProps_352( ) ;
         bGXsfl_35_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", "");
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_352( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV14FilterFullText ,
                                                 AV17TFNegCodigo ,
                                                 AV18TFNegCodigo_To ,
                                                 AV20TFNegAssunto_Sel ,
                                                 AV19TFNegAssunto ,
                                                 AV22TFNegCliNomeFamiliar_Sel ,
                                                 AV21TFNegCliNomeFamiliar ,
                                                 AV24TFNegCpjNomFan_Sel ,
                                                 AV23TFNegCpjNomFan ,
                                                 AV25TFNegCpjMatricula ,
                                                 AV26TFNegCpjMatricula_To ,
                                                 AV28TFNegPjtNome_Sel ,
                                                 AV27TFNegPjtNome ,
                                                 AV30TFNegAgcNome_Sel ,
                                                 AV29TFNegAgcNome ,
                                                 AV31TFNegInsData ,
                                                 AV32TFNegInsData_To ,
                                                 A356NegCodigo ,
                                                 A362NegAssunto ,
                                                 A351NegCliNomeFamiliar ,
                                                 A353NegCpjNomFan ,
                                                 A355NegCpjMatricula ,
                                                 A359NegPjtNome ,
                                                 A361NegAgcNome ,
                                                 A346NegInsData ,
                                                 AV11OrderedBy ,
                                                 AV12OrderedDsc ,
                                                 A386NegUltFase } ,
                                                 new int[]{
                                                 TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DATE,
                                                 TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.INT
                                                 }
            });
            lV14FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV14FilterFullText), "%", "");
            lV14FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV14FilterFullText), "%", "");
            lV14FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV14FilterFullText), "%", "");
            lV14FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV14FilterFullText), "%", "");
            lV14FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV14FilterFullText), "%", "");
            lV14FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV14FilterFullText), "%", "");
            lV14FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV14FilterFullText), "%", "");
            lV19TFNegAssunto = StringUtil.Concat( StringUtil.RTrim( AV19TFNegAssunto), "%", "");
            lV21TFNegCliNomeFamiliar = StringUtil.Concat( StringUtil.RTrim( AV21TFNegCliNomeFamiliar), "%", "");
            lV23TFNegCpjNomFan = StringUtil.Concat( StringUtil.RTrim( AV23TFNegCpjNomFan), "%", "");
            lV27TFNegPjtNome = StringUtil.Concat( StringUtil.RTrim( AV27TFNegPjtNome), "%", "");
            lV29TFNegAgcNome = StringUtil.Concat( StringUtil.RTrim( AV29TFNegAgcNome), "%", "");
            /* Using cursor H00522 */
            pr_default.execute(0, new Object[] {lV14FilterFullText, lV14FilterFullText, lV14FilterFullText, lV14FilterFullText, lV14FilterFullText, lV14FilterFullText, lV14FilterFullText, AV17TFNegCodigo, AV18TFNegCodigo_To, lV19TFNegAssunto, AV20TFNegAssunto_Sel, lV21TFNegCliNomeFamiliar, AV22TFNegCliNomeFamiliar_Sel, lV23TFNegCpjNomFan, AV24TFNegCpjNomFan_Sel, AV25TFNegCpjMatricula, AV26TFNegCpjMatricula_To, lV27TFNegPjtNome, AV28TFNegPjtNome_Sel, lV29TFNegAgcNome, AV30TFNegAgcNome_Sel, AV31TFNegInsData, AV32TFNegInsData_To, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_35_idx = 1;
            sGXsfl_35_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_35_idx), 4, 0), 4, "0");
            SubsflControlProps_352( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A386NegUltFase = H00522_A386NegUltFase[0];
               A364NegInsUsuNome = H00522_A364NegInsUsuNome[0];
               n364NegInsUsuNome = H00522_n364NegInsUsuNome[0];
               A346NegInsData = H00522_A346NegInsData[0];
               A361NegAgcNome = H00522_A361NegAgcNome[0];
               n361NegAgcNome = H00522_n361NegAgcNome[0];
               A360NegAgcID = H00522_A360NegAgcID[0];
               n360NegAgcID = H00522_n360NegAgcID[0];
               A359NegPjtNome = H00522_A359NegPjtNome[0];
               A358NegPjtSigla = H00522_A358NegPjtSigla[0];
               A357NegPjtID = H00522_A357NegPjtID[0];
               A355NegCpjMatricula = H00522_A355NegCpjMatricula[0];
               A354NegCpjRazSocial = H00522_A354NegCpjRazSocial[0];
               A353NegCpjNomFan = H00522_A353NegCpjNomFan[0];
               A352NegCpjID = H00522_A352NegCpjID[0];
               A351NegCliNomeFamiliar = H00522_A351NegCliNomeFamiliar[0];
               A350NegCliID = H00522_A350NegCliID[0];
               A362NegAssunto = H00522_A362NegAssunto[0];
               A349NegInsUsuID = H00522_A349NegInsUsuID[0];
               n349NegInsUsuID = H00522_n349NegInsUsuID[0];
               A348NegInsDataHora = H00522_A348NegInsDataHora[0];
               A347NegInsHora = H00522_A347NegInsHora[0];
               A356NegCodigo = H00522_A356NegCodigo[0];
               A345NegID = H00522_A345NegID[0];
               A357NegPjtID = H00522_A357NegPjtID[0];
               A355NegCpjMatricula = H00522_A355NegCpjMatricula[0];
               A358NegPjtSigla = H00522_A358NegPjtSigla[0];
               E18522 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 35;
            WB520( ) ;
         }
         bGXsfl_35_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes522( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV58Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV58Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_NEGID"+"_"+sGXsfl_35_idx, GetSecureSignedToken( sGXsfl_35_idx, A345NegID, context));
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
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV14FilterFullText ,
                                              AV17TFNegCodigo ,
                                              AV18TFNegCodigo_To ,
                                              AV20TFNegAssunto_Sel ,
                                              AV19TFNegAssunto ,
                                              AV22TFNegCliNomeFamiliar_Sel ,
                                              AV21TFNegCliNomeFamiliar ,
                                              AV24TFNegCpjNomFan_Sel ,
                                              AV23TFNegCpjNomFan ,
                                              AV25TFNegCpjMatricula ,
                                              AV26TFNegCpjMatricula_To ,
                                              AV28TFNegPjtNome_Sel ,
                                              AV27TFNegPjtNome ,
                                              AV30TFNegAgcNome_Sel ,
                                              AV29TFNegAgcNome ,
                                              AV31TFNegInsData ,
                                              AV32TFNegInsData_To ,
                                              A356NegCodigo ,
                                              A362NegAssunto ,
                                              A351NegCliNomeFamiliar ,
                                              A353NegCpjNomFan ,
                                              A355NegCpjMatricula ,
                                              A359NegPjtNome ,
                                              A361NegAgcNome ,
                                              A346NegInsData ,
                                              AV11OrderedBy ,
                                              AV12OrderedDsc ,
                                              A386NegUltFase } ,
                                              new int[]{
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DATE,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.INT
                                              }
         });
         lV14FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV14FilterFullText), "%", "");
         lV14FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV14FilterFullText), "%", "");
         lV14FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV14FilterFullText), "%", "");
         lV14FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV14FilterFullText), "%", "");
         lV14FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV14FilterFullText), "%", "");
         lV14FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV14FilterFullText), "%", "");
         lV14FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV14FilterFullText), "%", "");
         lV19TFNegAssunto = StringUtil.Concat( StringUtil.RTrim( AV19TFNegAssunto), "%", "");
         lV21TFNegCliNomeFamiliar = StringUtil.Concat( StringUtil.RTrim( AV21TFNegCliNomeFamiliar), "%", "");
         lV23TFNegCpjNomFan = StringUtil.Concat( StringUtil.RTrim( AV23TFNegCpjNomFan), "%", "");
         lV27TFNegPjtNome = StringUtil.Concat( StringUtil.RTrim( AV27TFNegPjtNome), "%", "");
         lV29TFNegAgcNome = StringUtil.Concat( StringUtil.RTrim( AV29TFNegAgcNome), "%", "");
         /* Using cursor H00523 */
         pr_default.execute(1, new Object[] {lV14FilterFullText, lV14FilterFullText, lV14FilterFullText, lV14FilterFullText, lV14FilterFullText, lV14FilterFullText, lV14FilterFullText, AV17TFNegCodigo, AV18TFNegCodigo_To, lV19TFNegAssunto, AV20TFNegAssunto_Sel, lV21TFNegCliNomeFamiliar, AV22TFNegCliNomeFamiliar_Sel, lV23TFNegCpjNomFan, AV24TFNegCpjNomFan_Sel, AV25TFNegCpjMatricula, AV26TFNegCpjMatricula_To, lV27TFNegPjtNome, AV28TFNegPjtNome_Sel, lV29TFNegAgcNome, AV30TFNegAgcNome_Sel, AV31TFNegInsData, AV32TFNegInsData_To});
         GRID_nRecordCount = H00523_AGRID_nRecordCount[0];
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
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV14FilterFullText, AV48NegID_WSKey, AV58Pgmname, AV11OrderedBy, AV12OrderedDsc, AV13NegUltFase_Vazio, AV17TFNegCodigo, AV18TFNegCodigo_To, AV19TFNegAssunto, AV20TFNegAssunto_Sel, AV21TFNegCliNomeFamiliar, AV22TFNegCliNomeFamiliar_Sel, AV23TFNegCpjNomFan, AV24TFNegCpjNomFan_Sel, AV25TFNegCpjMatricula, AV26TFNegCpjMatricula_To, AV27TFNegPjtNome, AV28TFNegPjtNome_Sel, AV29TFNegAgcNome, AV30TFNegAgcNome_Sel, AV31TFNegInsData, AV32TFNegInsData_To, AV53i, AV46NegIDCol, AV52NegIDToFind) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
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
            gxgrGrid_refresh( subGrid_Rows, AV14FilterFullText, AV48NegID_WSKey, AV58Pgmname, AV11OrderedBy, AV12OrderedDsc, AV13NegUltFase_Vazio, AV17TFNegCodigo, AV18TFNegCodigo_To, AV19TFNegAssunto, AV20TFNegAssunto_Sel, AV21TFNegCliNomeFamiliar, AV22TFNegCliNomeFamiliar_Sel, AV23TFNegCpjNomFan, AV24TFNegCpjNomFan_Sel, AV25TFNegCpjMatricula, AV26TFNegCpjMatricula_To, AV27TFNegPjtNome, AV28TFNegPjtNome_Sel, AV29TFNegAgcNome, AV30TFNegAgcNome_Sel, AV31TFNegInsData, AV32TFNegInsData_To, AV53i, AV46NegIDCol, AV52NegIDToFind) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
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
            gxgrGrid_refresh( subGrid_Rows, AV14FilterFullText, AV48NegID_WSKey, AV58Pgmname, AV11OrderedBy, AV12OrderedDsc, AV13NegUltFase_Vazio, AV17TFNegCodigo, AV18TFNegCodigo_To, AV19TFNegAssunto, AV20TFNegAssunto_Sel, AV21TFNegCliNomeFamiliar, AV22TFNegCliNomeFamiliar_Sel, AV23TFNegCpjNomFan, AV24TFNegCpjNomFan_Sel, AV25TFNegCpjMatricula, AV26TFNegCpjMatricula_To, AV27TFNegPjtNome, AV28TFNegPjtNome_Sel, AV29TFNegAgcNome, AV30TFNegAgcNome_Sel, AV31TFNegInsData, AV32TFNegInsData_To, AV53i, AV46NegIDCol, AV52NegIDToFind) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
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
            gxgrGrid_refresh( subGrid_Rows, AV14FilterFullText, AV48NegID_WSKey, AV58Pgmname, AV11OrderedBy, AV12OrderedDsc, AV13NegUltFase_Vazio, AV17TFNegCodigo, AV18TFNegCodigo_To, AV19TFNegAssunto, AV20TFNegAssunto_Sel, AV21TFNegCliNomeFamiliar, AV22TFNegCliNomeFamiliar_Sel, AV23TFNegCpjNomFan, AV24TFNegCpjNomFan_Sel, AV25TFNegCpjMatricula, AV26TFNegCpjMatricula_To, AV27TFNegPjtNome, AV28TFNegPjtNome_Sel, AV29TFNegAgcNome, AV30TFNegAgcNome_Sel, AV31TFNegInsData, AV32TFNegInsData_To, AV53i, AV46NegIDCol, AV52NegIDToFind) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
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
            gxgrGrid_refresh( subGrid_Rows, AV14FilterFullText, AV48NegID_WSKey, AV58Pgmname, AV11OrderedBy, AV12OrderedDsc, AV13NegUltFase_Vazio, AV17TFNegCodigo, AV18TFNegCodigo_To, AV19TFNegAssunto, AV20TFNegAssunto_Sel, AV21TFNegCliNomeFamiliar, AV22TFNegCliNomeFamiliar_Sel, AV23TFNegCpjNomFan, AV24TFNegCpjNomFan_Sel, AV25TFNegCpjMatricula, AV26TFNegCpjMatricula_To, AV27TFNegPjtNome, AV28TFNegPjtNome_Sel, AV29TFNegAgcNome, AV30TFNegAgcNome_Sel, AV31TFNegInsData, AV32TFNegInsData_To, AV53i, AV46NegIDCol, AV52NegIDToFind) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV58Pgmname = "core.NegocioPJSemFasePrompt";
         fix_multi_value_controls( ) ;
      }

      protected void STRUP520( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E16522 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV36DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_35 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_35"), ",", "."), 18, MidpointRounding.ToEven));
            AV40GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ",", "."), 18, MidpointRounding.ToEven));
            AV41GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ",", "."), 18, MidpointRounding.ToEven));
            AV42GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            AV33DDO_NegInsDataAuxDate = context.localUtil.CToD( cgiGet( "vDDO_NEGINSDATAAUXDATE"), 0);
            AV34DDO_NegInsDataAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_NEGINSDATAAUXDATETO"), 0);
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), ",", "."), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nEOF"), ",", "."), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
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
            Ddo_grid_Format = cgiGet( "DDO_GRID_Format");
            Dvelop_confirmpanel_enter_Title = cgiGet( "DVELOP_CONFIRMPANEL_ENTER_Title");
            Dvelop_confirmpanel_enter_Confirmationtext = cgiGet( "DVELOP_CONFIRMPANEL_ENTER_Confirmationtext");
            Dvelop_confirmpanel_enter_Yesbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_ENTER_Yesbuttoncaption");
            Dvelop_confirmpanel_enter_Nobuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_ENTER_Nobuttoncaption");
            Dvelop_confirmpanel_enter_Cancelbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_ENTER_Cancelbuttoncaption");
            Dvelop_confirmpanel_enter_Yesbuttonposition = cgiGet( "DVELOP_CONFIRMPANEL_ENTER_Yesbuttonposition");
            Dvelop_confirmpanel_enter_Confirmtype = cgiGet( "DVELOP_CONFIRMPANEL_ENTER_Confirmtype");
            Grid_empowerer_Gridinternalname = cgiGet( "GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hastitlesettings"));
            Gridpaginationbar_Selectedpage = cgiGet( "GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), ",", "."), 18, MidpointRounding.ToEven));
            Ddo_grid_Activeeventkey = cgiGet( "DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( "DDO_GRID_Selectedvalue_get");
            Ddo_grid_Filteredtextto_get = cgiGet( "DDO_GRID_Filteredtextto_get");
            Ddo_grid_Filteredtext_get = cgiGet( "DDO_GRID_Filteredtext_get");
            Ddo_grid_Selectedcolumn = cgiGet( "DDO_GRID_Selectedcolumn");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavNegultfase_vazio_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavNegultfase_vazio_Internalname), ",", ".") > Convert.ToDecimal( 99999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vNEGULTFASE_VAZIO");
               GX_FocusControl = edtavNegultfase_vazio_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV13NegUltFase_Vazio = 0;
               AssignAttri("", false, "AV13NegUltFase_Vazio", StringUtil.LTrimStr( (decimal)(AV13NegUltFase_Vazio), 8, 0));
            }
            else
            {
               AV13NegUltFase_Vazio = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavNegultfase_vazio_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV13NegUltFase_Vazio", StringUtil.LTrimStr( (decimal)(AV13NegUltFase_Vazio), 8, 0));
            }
            AV14FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV14FilterFullText", AV14FilterFullText);
            AV35DDO_NegInsDataAuxDateText = cgiGet( edtavDdo_neginsdataauxdatetext_Internalname);
            AssignAttri("", false, "AV35DDO_NegInsDataAuxDateText", AV35DDO_NegInsDataAuxDateText);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV14FilterFullText) != 0 )
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
         E16522 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E16522( )
      {
         /* Start Routine */
         returnInSub = false;
         this.executeUsercontrolMethod("", false, "TFNEGINSDATA_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_neginsdataauxdatetext_Internalname});
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         AV37GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV38GAMErrors);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Ddo_grid_Gamoauthtoken = AV37GAMSession.gxTpr_Token;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GAMOAuthToken", Ddo_grid_Gamoauthtoken);
         Form.Caption = "Selecionar Oportunidades";
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         if ( AV11OrderedBy < 1 )
         {
            AV11OrderedBy = 1;
            AssignAttri("", false, "AV11OrderedBy", StringUtil.LTrimStr( (decimal)(AV11OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV36DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV36DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         if ( StringUtil.StrCmp(AV8HTTPRequest.Method, "GET") == 0 )
         {
            AV16Session.Set(AV48NegID_WSKey+"AUX", AV16Session.Get(AV48NegID_WSKey));
         }
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E17522( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV46NegIDCol.FromJSonString(AV16Session.Get(AV48NegID_WSKey+"AUX"), null);
         AV40GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV40GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV40GridCurrentPage), 10, 0));
         AV41GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV41GridPageCount", StringUtil.LTrimStr( (decimal)(AV41GridPageCount), 10, 0));
         GXt_char2 = AV42GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV58Pgmname, out  GXt_char2) ;
         AV42GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV42GridAppliedFilters", AV42GridAppliedFilters);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV46NegIDCol", AV46NegIDCol);
      }

      protected void E11522( )
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
            AV39PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV39PageToGo) ;
         }
      }

      protected void E12522( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E13522( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV11OrderedBy = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV11OrderedBy", StringUtil.LTrimStr( (decimal)(AV11OrderedBy), 4, 0));
            AV12OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri("", false, "AV12OrderedDsc", AV12OrderedDsc);
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S112 ();
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
               AV17TFNegCodigo = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV17TFNegCodigo", StringUtil.LTrimStr( (decimal)(AV17TFNegCodigo), 12, 0));
               AV18TFNegCodigo_To = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV18TFNegCodigo_To", StringUtil.LTrimStr( (decimal)(AV18TFNegCodigo_To), 12, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "NegAssunto") == 0 )
            {
               AV19TFNegAssunto = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV19TFNegAssunto", AV19TFNegAssunto);
               AV20TFNegAssunto_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV20TFNegAssunto_Sel", AV20TFNegAssunto_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "NegCliNomeFamiliar") == 0 )
            {
               AV21TFNegCliNomeFamiliar = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV21TFNegCliNomeFamiliar", AV21TFNegCliNomeFamiliar);
               AV22TFNegCliNomeFamiliar_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV22TFNegCliNomeFamiliar_Sel", AV22TFNegCliNomeFamiliar_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "NegCpjNomFan") == 0 )
            {
               AV23TFNegCpjNomFan = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV23TFNegCpjNomFan", AV23TFNegCpjNomFan);
               AV24TFNegCpjNomFan_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV24TFNegCpjNomFan_Sel", AV24TFNegCpjNomFan_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "NegCpjMatricula") == 0 )
            {
               AV25TFNegCpjMatricula = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV25TFNegCpjMatricula", StringUtil.LTrimStr( (decimal)(AV25TFNegCpjMatricula), 12, 0));
               AV26TFNegCpjMatricula_To = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV26TFNegCpjMatricula_To", StringUtil.LTrimStr( (decimal)(AV26TFNegCpjMatricula_To), 12, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "NegPjtNome") == 0 )
            {
               AV27TFNegPjtNome = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV27TFNegPjtNome", AV27TFNegPjtNome);
               AV28TFNegPjtNome_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV28TFNegPjtNome_Sel", AV28TFNegPjtNome_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "NegAgcNome") == 0 )
            {
               AV29TFNegAgcNome = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV29TFNegAgcNome", AV29TFNegAgcNome);
               AV30TFNegAgcNome_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV30TFNegAgcNome_Sel", AV30TFNegAgcNome_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "NegInsData") == 0 )
            {
               AV31TFNegInsData = context.localUtil.CToD( Ddo_grid_Filteredtext_get, 2);
               AssignAttri("", false, "AV31TFNegInsData", context.localUtil.Format(AV31TFNegInsData, "99/99/99"));
               AV32TFNegInsData_To = context.localUtil.CToD( Ddo_grid_Filteredtextto_get, 2);
               AssignAttri("", false, "AV32TFNegInsData_To", context.localUtil.Format(AV32TFNegInsData_To, "99/99/99"));
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E18522( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV15Selected = false;
         AssignAttri("", false, chkavSelected_Internalname, AV15Selected);
         AV52NegIDToFind = A345NegID;
         AssignAttri("", false, "AV52NegIDToFind", AV52NegIDToFind.ToString());
         /* Execute user subroutine: 'GETINDEXOFSELECTEDROW' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( AV53i > 0 )
         {
            AV15Selected = true;
            AssignAttri("", false, chkavSelected_Internalname, AV15Selected);
         }
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 35;
         }
         sendrow_352( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_35_Refreshing )
         {
            DoAjaxLoad(35, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E19522( )
      {
         /* Selected_Click Routine */
         returnInSub = false;
         if ( AV15Selected )
         {
            AV46NegIDCol.Add(A345NegID, 0);
         }
         else
         {
            AV52NegIDToFind = A345NegID;
            AssignAttri("", false, "AV52NegIDToFind", AV52NegIDToFind.ToString());
            /* Execute user subroutine: 'GETINDEXOFSELECTEDROW' */
            S132 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            AV46NegIDCol.RemoveItem((int)(AV53i));
         }
         AV16Session.Set(AV48NegID_WSKey+"AUX", AV46NegIDCol.ToJSonString(false));
         divLayoutmaintable_Class = "Table TableWithSelectableGrid"+((AV46NegIDCol.Count>0) ? " WWPMultiRowSelected" : "");
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV46NegIDCol", AV46NegIDCol);
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E14522 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E14522( )
      {
         /* Enter Routine */
         returnInSub = false;
         new GeneXus.Programs.core.prccommit(context ).execute( ) ;
         AV57HasErrores = false;
         AV46NegIDCol.FromJSonString(AV16Session.Get(AV48NegID_WSKey+"AUX"), null);
         AV59GXV1 = 1;
         while ( AV59GXV1 <= AV46NegIDCol.Count )
         {
            AV54ItemNegID = ((Guid)AV46NegIDCol.Item(AV59GXV1));
            new GeneXus.Programs.core.prcnegociopjproximafase(context ).execute(  AV54ItemNegID,  false, out  AV55Messages) ;
            AV60GXV2 = 1;
            while ( AV60GXV2 <= AV55Messages.Count )
            {
               AV56Message = ((GeneXus.Utils.SdtMessages_Message)AV55Messages.Item(AV60GXV2));
               if ( AV56Message.gxTpr_Type == 1 )
               {
                  new GeneXus.Programs.core.prcrollback(context ).execute( ) ;
                  AV57HasErrores = true;
                  GX_msglist.addItem(AV56Message.gxTpr_Description);
                  if (true) break;
               }
               AV60GXV2 = (int)(AV60GXV2+1);
            }
            AV59GXV1 = (int)(AV59GXV1+1);
         }
         new GeneXus.Programs.core.prccommit(context ).execute( ) ;
         if ( ! AV57HasErrores )
         {
            AV16Session.Set(AV48NegID_WSKey, AV16Session.Get(AV48NegID_WSKey+"AUX"));
            AV16Session.Remove(AV48NegID_WSKey+"AUX");
            context.setWebReturnParms(new Object[] {});
            context.setWebReturnParmsMetadata(new Object[] {});
            context.wjLocDisableFrm = 1;
            context.nUserReturn = 1;
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV46NegIDCol", AV46NegIDCol);
      }

      protected void E15522( )
      {
         /* 'DoCleanFilters' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CLEANFILTERS' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void S112( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV11OrderedBy), 4, 0))+":"+(AV12OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S132( )
      {
         /* 'GETINDEXOFSELECTEDROW' Routine */
         returnInSub = false;
         AV53i = 1;
         AssignAttri("", false, "AV53i", StringUtil.LTrimStr( (decimal)(AV53i), 10, 0));
         AV61GXV3 = 1;
         while ( AV61GXV3 <= AV46NegIDCol.Count )
         {
            AV47NegIDColItem = ((Guid)AV46NegIDCol.Item(AV61GXV3));
            if ( AV47NegIDColItem == AV52NegIDToFind )
            {
               if (true) break;
            }
            AV53i = (long)(AV53i+1);
            AssignAttri("", false, "AV53i", StringUtil.LTrimStr( (decimal)(AV53i), 10, 0));
            AV61GXV3 = (int)(AV61GXV3+1);
         }
         if ( AV53i > AV46NegIDCol.Count )
         {
            AV53i = 0;
            AssignAttri("", false, "AV53i", StringUtil.LTrimStr( (decimal)(AV53i), 10, 0));
         }
      }

      protected void S142( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV13NegUltFase_Vazio = 0;
         AssignAttri("", false, "AV13NegUltFase_Vazio", StringUtil.LTrimStr( (decimal)(AV13NegUltFase_Vazio), 8, 0));
         AV14FilterFullText = "";
         AssignAttri("", false, "AV14FilterFullText", AV14FilterFullText);
         AV17TFNegCodigo = 0;
         AssignAttri("", false, "AV17TFNegCodigo", StringUtil.LTrimStr( (decimal)(AV17TFNegCodigo), 12, 0));
         AV18TFNegCodigo_To = 0;
         AssignAttri("", false, "AV18TFNegCodigo_To", StringUtil.LTrimStr( (decimal)(AV18TFNegCodigo_To), 12, 0));
         AV19TFNegAssunto = "";
         AssignAttri("", false, "AV19TFNegAssunto", AV19TFNegAssunto);
         AV20TFNegAssunto_Sel = "";
         AssignAttri("", false, "AV20TFNegAssunto_Sel", AV20TFNegAssunto_Sel);
         AV21TFNegCliNomeFamiliar = "";
         AssignAttri("", false, "AV21TFNegCliNomeFamiliar", AV21TFNegCliNomeFamiliar);
         AV22TFNegCliNomeFamiliar_Sel = "";
         AssignAttri("", false, "AV22TFNegCliNomeFamiliar_Sel", AV22TFNegCliNomeFamiliar_Sel);
         AV23TFNegCpjNomFan = "";
         AssignAttri("", false, "AV23TFNegCpjNomFan", AV23TFNegCpjNomFan);
         AV24TFNegCpjNomFan_Sel = "";
         AssignAttri("", false, "AV24TFNegCpjNomFan_Sel", AV24TFNegCpjNomFan_Sel);
         AV25TFNegCpjMatricula = 0;
         AssignAttri("", false, "AV25TFNegCpjMatricula", StringUtil.LTrimStr( (decimal)(AV25TFNegCpjMatricula), 12, 0));
         AV26TFNegCpjMatricula_To = 0;
         AssignAttri("", false, "AV26TFNegCpjMatricula_To", StringUtil.LTrimStr( (decimal)(AV26TFNegCpjMatricula_To), 12, 0));
         AV27TFNegPjtNome = "";
         AssignAttri("", false, "AV27TFNegPjtNome", AV27TFNegPjtNome);
         AV28TFNegPjtNome_Sel = "";
         AssignAttri("", false, "AV28TFNegPjtNome_Sel", AV28TFNegPjtNome_Sel);
         AV29TFNegAgcNome = "";
         AssignAttri("", false, "AV29TFNegAgcNome", AV29TFNegAgcNome);
         AV30TFNegAgcNome_Sel = "";
         AssignAttri("", false, "AV30TFNegAgcNome_Sel", AV30TFNegAgcNome_Sel);
         AV31TFNegInsData = DateTime.MinValue;
         AssignAttri("", false, "AV31TFNegInsData", context.localUtil.Format(AV31TFNegInsData, "99/99/99"));
         AV32TFNegInsData_To = DateTime.MinValue;
         AssignAttri("", false, "AV32TFNegInsData_To", context.localUtil.Format(AV32TFNegInsData_To, "99/99/99"));
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S152( )
      {
         /* 'DO ACTION ENTER' Routine */
         returnInSub = false;
      }

      protected void S122( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV9GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV9GridState.gxTpr_Orderedby = AV11OrderedBy;
         AV9GridState.gxTpr_Ordereddsc = AV12OrderedDsc;
         AV9GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV9GridState,  "NEGULTFASE_VAZIO",  "",  !(0==AV13NegUltFase_Vazio),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV13NegUltFase_Vazio), 8, 0)),  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV9GridState,  "FILTERFULLTEXT",  "Filtro principal",  !String.IsNullOrEmpty(StringUtil.RTrim( AV14FilterFullText)),  0,  AV14FilterFullText,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV9GridState,  "TFNEGCODIGO",  "Negociação",  !((0==AV17TFNegCodigo)&&(0==AV18TFNegCodigo_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV17TFNegCodigo), 12, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV18TFNegCodigo_To), 12, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV9GridState,  "TFNEGASSUNTO",  "Assunto",  !String.IsNullOrEmpty(StringUtil.RTrim( AV19TFNegAssunto)),  0,  AV19TFNegAssunto,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV20TFNegAssunto_Sel)),  AV20TFNegAssunto_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV9GridState,  "TFNEGCLINOMEFAMILIAR",  "Cliente",  !String.IsNullOrEmpty(StringUtil.RTrim( AV21TFNegCliNomeFamiliar)),  0,  AV21TFNegCliNomeFamiliar,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV22TFNegCliNomeFamiliar_Sel)),  AV22TFNegCliNomeFamiliar_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV9GridState,  "TFNEGCPJNOMFAN",  "Unidade",  !String.IsNullOrEmpty(StringUtil.RTrim( AV23TFNegCpjNomFan)),  0,  AV23TFNegCpjNomFan,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV24TFNegCpjNomFan_Sel)),  AV24TFNegCpjNomFan_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV9GridState,  "TFNEGCPJMATRICULA",  "Matrícula",  !((0==AV25TFNegCpjMatricula)&&(0==AV26TFNegCpjMatricula_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV25TFNegCpjMatricula), 12, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV26TFNegCpjMatricula_To), 12, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV9GridState,  "TFNEGPJTNOME",  "Tipo",  !String.IsNullOrEmpty(StringUtil.RTrim( AV27TFNegPjtNome)),  0,  AV27TFNegPjtNome,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV28TFNegPjtNome_Sel)),  AV28TFNegPjtNome_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV9GridState,  "TFNEGAGCNOME",  "Agente Comercial",  !String.IsNullOrEmpty(StringUtil.RTrim( AV29TFNegAgcNome)),  0,  AV29TFNegAgcNome,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV30TFNegAgcNome_Sel)),  AV30TFNegAgcNome_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV9GridState,  "TFNEGINSDATA",  "Incluído em",  !((DateTime.MinValue==AV31TFNegInsData)&&(DateTime.MinValue==AV32TFNegInsData_To)),  0,  StringUtil.Trim( context.localUtil.DToC( AV31TFNegInsData, 2, "/")),  StringUtil.Trim( context.localUtil.DToC( AV32TFNegInsData_To, 2, "/"))) ;
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV58Pgmname+"GridState",  AV9GridState.ToXml(false, true, "", "")) ;
      }

      protected void wb_table2_63_522( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTabledvelop_confirmpanel_enter_Internalname, tblTabledvelop_confirmpanel_enter_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucDvelop_confirmpanel_enter.SetProperty("Title", Dvelop_confirmpanel_enter_Title);
            ucDvelop_confirmpanel_enter.SetProperty("ConfirmationText", Dvelop_confirmpanel_enter_Confirmationtext);
            ucDvelop_confirmpanel_enter.SetProperty("YesButtonCaption", Dvelop_confirmpanel_enter_Yesbuttoncaption);
            ucDvelop_confirmpanel_enter.SetProperty("NoButtonCaption", Dvelop_confirmpanel_enter_Nobuttoncaption);
            ucDvelop_confirmpanel_enter.SetProperty("CancelButtonCaption", Dvelop_confirmpanel_enter_Cancelbuttoncaption);
            ucDvelop_confirmpanel_enter.SetProperty("YesButtonPosition", Dvelop_confirmpanel_enter_Yesbuttonposition);
            ucDvelop_confirmpanel_enter.SetProperty("ConfirmType", Dvelop_confirmpanel_enter_Confirmtype);
            ucDvelop_confirmpanel_enter.Render(context, "dvelop.gxbootstrap.confirmpanel", Dvelop_confirmpanel_enter_Internalname, "DVELOP_CONFIRMPANEL_ENTERContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVELOP_CONFIRMPANEL_ENTERContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_63_522e( true) ;
         }
         else
         {
            wb_table2_63_522e( false) ;
         }
      }

      protected void wb_table1_23_522( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablerightheader_Internalname, tblTablerightheader_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='CellAlignTop CellPaddingTop10'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCleanfilters_Internalname, "<i class=\"fas fa-filter CleanFiltersIcon\"></i>", "", "", lblCleanfilters_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOCLEANFILTERS\\'."+"'", "", "TextBlock", 5, "Limpar filtros", 1, 1, 0, 1, "HLP_core\\NegocioPJSemFasePrompt.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFilterfulltext_Internalname, "Filter Full Text", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'" + sGXsfl_35_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV14FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV14FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Pesquisar", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_core\\NegocioPJSemFasePrompt.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_23_522e( true) ;
         }
         else
         {
            wb_table1_23_522e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV48NegID_WSKey = (string)getParm(obj,0);
         AssignAttri("", false, "AV48NegID_WSKey", AV48NegID_WSKey);
         GxWebStd.gx_hidden_field( context, "gxhash_vNEGID_WSKEY", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV48NegID_WSKey, "")), context));
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
         PA522( ) ;
         WS522( ) ;
         WE522( ) ;
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
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202382823117", true, true);
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
         context.AddJavascriptSource("core/negociopjsemfaseprompt.js", "?202382823119", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
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

      protected void SubsflControlProps_352( )
      {
         chkavSelected_Internalname = "vSELECTED_"+sGXsfl_35_idx;
         edtNegID_Internalname = "NEGID_"+sGXsfl_35_idx;
         edtNegCodigo_Internalname = "NEGCODIGO_"+sGXsfl_35_idx;
         edtNegInsHora_Internalname = "NEGINSHORA_"+sGXsfl_35_idx;
         edtNegInsDataHora_Internalname = "NEGINSDATAHORA_"+sGXsfl_35_idx;
         edtNegInsUsuID_Internalname = "NEGINSUSUID_"+sGXsfl_35_idx;
         edtNegAssunto_Internalname = "NEGASSUNTO_"+sGXsfl_35_idx;
         edtNegCliID_Internalname = "NEGCLIID_"+sGXsfl_35_idx;
         edtNegCliNomeFamiliar_Internalname = "NEGCLINOMEFAMILIAR_"+sGXsfl_35_idx;
         edtNegCpjID_Internalname = "NEGCPJID_"+sGXsfl_35_idx;
         edtNegCpjNomFan_Internalname = "NEGCPJNOMFAN_"+sGXsfl_35_idx;
         edtNegCpjRazSocial_Internalname = "NEGCPJRAZSOCIAL_"+sGXsfl_35_idx;
         edtNegCpjMatricula_Internalname = "NEGCPJMATRICULA_"+sGXsfl_35_idx;
         edtNegPjtID_Internalname = "NEGPJTID_"+sGXsfl_35_idx;
         edtNegPjtSigla_Internalname = "NEGPJTSIGLA_"+sGXsfl_35_idx;
         edtNegPjtNome_Internalname = "NEGPJTNOME_"+sGXsfl_35_idx;
         edtNegAgcID_Internalname = "NEGAGCID_"+sGXsfl_35_idx;
         edtNegAgcNome_Internalname = "NEGAGCNOME_"+sGXsfl_35_idx;
         edtNegInsData_Internalname = "NEGINSDATA_"+sGXsfl_35_idx;
         edtNegInsUsuNome_Internalname = "NEGINSUSUNOME_"+sGXsfl_35_idx;
      }

      protected void SubsflControlProps_fel_352( )
      {
         chkavSelected_Internalname = "vSELECTED_"+sGXsfl_35_fel_idx;
         edtNegID_Internalname = "NEGID_"+sGXsfl_35_fel_idx;
         edtNegCodigo_Internalname = "NEGCODIGO_"+sGXsfl_35_fel_idx;
         edtNegInsHora_Internalname = "NEGINSHORA_"+sGXsfl_35_fel_idx;
         edtNegInsDataHora_Internalname = "NEGINSDATAHORA_"+sGXsfl_35_fel_idx;
         edtNegInsUsuID_Internalname = "NEGINSUSUID_"+sGXsfl_35_fel_idx;
         edtNegAssunto_Internalname = "NEGASSUNTO_"+sGXsfl_35_fel_idx;
         edtNegCliID_Internalname = "NEGCLIID_"+sGXsfl_35_fel_idx;
         edtNegCliNomeFamiliar_Internalname = "NEGCLINOMEFAMILIAR_"+sGXsfl_35_fel_idx;
         edtNegCpjID_Internalname = "NEGCPJID_"+sGXsfl_35_fel_idx;
         edtNegCpjNomFan_Internalname = "NEGCPJNOMFAN_"+sGXsfl_35_fel_idx;
         edtNegCpjRazSocial_Internalname = "NEGCPJRAZSOCIAL_"+sGXsfl_35_fel_idx;
         edtNegCpjMatricula_Internalname = "NEGCPJMATRICULA_"+sGXsfl_35_fel_idx;
         edtNegPjtID_Internalname = "NEGPJTID_"+sGXsfl_35_fel_idx;
         edtNegPjtSigla_Internalname = "NEGPJTSIGLA_"+sGXsfl_35_fel_idx;
         edtNegPjtNome_Internalname = "NEGPJTNOME_"+sGXsfl_35_fel_idx;
         edtNegAgcID_Internalname = "NEGAGCID_"+sGXsfl_35_fel_idx;
         edtNegAgcNome_Internalname = "NEGAGCNOME_"+sGXsfl_35_fel_idx;
         edtNegInsData_Internalname = "NEGINSDATA_"+sGXsfl_35_fel_idx;
         edtNegInsUsuNome_Internalname = "NEGINSUSUNOME_"+sGXsfl_35_fel_idx;
      }

      protected void sendrow_352( )
      {
         SubsflControlProps_352( ) ;
         WB520( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_35_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_35_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_35_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Check box */
            TempTags = " " + ((chkavSelected.Enabled!=0)&&(chkavSelected.Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 36,'',false,'"+sGXsfl_35_idx+"',35)\"" : " ");
            ClassString = "AttributeCheckBox";
            StyleString = "";
            GXCCtl = "vSELECTED_" + sGXsfl_35_idx;
            chkavSelected.Name = GXCCtl;
            chkavSelected.WebTags = "";
            chkavSelected.Caption = "";
            AssignProp("", false, chkavSelected_Internalname, "TitleCaption", chkavSelected.Caption, !bGXsfl_35_Refreshing);
            chkavSelected.CheckedValue = "false";
            AV15Selected = StringUtil.StrToBool( StringUtil.BoolToStr( AV15Selected));
            AssignAttri("", false, chkavSelected_Internalname, AV15Selected);
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkavSelected_Internalname,StringUtil.BoolToStr( AV15Selected),(string)"",(string)"",(short)-1,(short)1,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",TempTags+((chkavSelected.Enabled!=0)&&(chkavSelected.Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,36);\"" : " ")});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNegID_Internalname,A345NegID.ToString(),A345NegID.ToString(),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNegID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)35,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNegCodigo_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A356NegCodigo), 12, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A356NegCodigo), "ZZZZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNegCodigo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)12,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNegInsHora_Internalname,context.localUtil.TToC( A347NegInsHora, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A347NegInsHora, "99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNegInsHora_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)5,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)0,(bool)true,(string)"core\\HoraMinuto",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNegInsDataHora_Internalname,context.localUtil.TToC( A348NegInsDataHora, 10, 12, 0, 3, "/", ":", " "),context.localUtil.Format( A348NegInsDataHora, "99/99/9999 99:99:99.999"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNegInsDataHora_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)24,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)0,(bool)true,(string)"core\\DataHoraSegundoMS",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNegInsUsuID_Internalname,StringUtil.RTrim( A349NegInsUsuID),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNegInsUsuID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXusSecurityCommon\\GAMGUID",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNegAssunto_Internalname,(string)A362NegAssunto,StringUtil.RTrim( context.localUtil.Format( A362NegAssunto, "@!")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNegAssunto_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNegCliID_Internalname,A350NegCliID.ToString(),A350NegCliID.ToString(),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNegCliID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)35,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNegCliNomeFamiliar_Internalname,(string)A351NegCliNomeFamiliar,StringUtil.RTrim( context.localUtil.Format( A351NegCliNomeFamiliar, "@!")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNegCliNomeFamiliar_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)-1,(bool)true,(string)"core\\Nome",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNegCpjID_Internalname,A352NegCpjID.ToString(),A352NegCpjID.ToString(),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNegCpjID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)35,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNegCpjNomFan_Internalname,(string)A353NegCpjNomFan,StringUtil.RTrim( context.localUtil.Format( A353NegCpjNomFan, "@!")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNegCpjNomFan_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)-1,(bool)true,(string)"core\\Nome",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNegCpjRazSocial_Internalname,(string)A354NegCpjRazSocial,StringUtil.RTrim( context.localUtil.Format( A354NegCpjRazSocial, "@!")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNegCpjRazSocial_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)-1,(bool)true,(string)"core\\Nome",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNegCpjMatricula_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A355NegCpjMatricula), 15, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A355NegCpjMatricula), "ZZZ,ZZZ,ZZZ,ZZ9")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNegCpjMatricula_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)15,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)0,(bool)true,(string)"core\\Matricula",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNegPjtID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A357NegPjtID), 11, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A357NegPjtID), "ZZZ,ZZZ,ZZ9")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNegPjtID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)11,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)0,(bool)true,(string)"core\\ID",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNegPjtSigla_Internalname,(string)A358NegPjtSigla,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNegPjtSigla_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)-1,(bool)true,(string)"core\\Sigla",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNegPjtNome_Internalname,(string)A359NegPjtNome,StringUtil.RTrim( context.localUtil.Format( A359NegPjtNome, "@!")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNegPjtNome_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)-1,(bool)true,(string)"core\\Nome",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNegAgcID_Internalname,StringUtil.RTrim( A360NegAgcID),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNegAgcID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXusSecurityCommon\\GAMGUID",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNegAgcNome_Internalname,(string)A361NegAgcNome,StringUtil.RTrim( context.localUtil.Format( A361NegAgcNome, "@!")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNegAgcNome_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)-1,(bool)true,(string)"core\\Nome",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNegInsData_Internalname,context.localUtil.Format(A346NegInsData, "99/99/99"),context.localUtil.Format( A346NegInsData, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNegInsData_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn hidden-xs",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)0,(bool)true,(string)"core\\Data",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNegInsUsuNome_Internalname,(string)A364NegInsUsuNome,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNegInsUsuNome_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes522( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_35_idx = ((subGrid_Islastpage==1)&&(nGXsfl_35_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_35_idx+1);
            sGXsfl_35_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_35_idx), 4, 0), 4, "0");
            SubsflControlProps_352( ) ;
         }
         /* End function sendrow_352 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "vSELECTED_" + sGXsfl_35_idx;
         chkavSelected.Name = GXCCtl;
         chkavSelected.WebTags = "";
         chkavSelected.Caption = "";
         AssignProp("", false, chkavSelected_Internalname, "TitleCaption", chkavSelected.Caption, !bGXsfl_35_Refreshing);
         chkavSelected.CheckedValue = "false";
         AV15Selected = StringUtil.StrToBool( StringUtil.BoolToStr( AV15Selected));
         AssignAttri("", false, chkavSelected_Internalname, AV15Selected);
         /* End function init_web_controls */
      }

      protected void StartGridControl35( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"35\">") ;
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
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"AttributeCheckBox"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "ID") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Negociação") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Incluído às") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Incluído em") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Incluído por") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Assunto") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Cliente ID") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Cliente") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Unidade") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Unidade") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Razão Social") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Matrícula") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Tipo") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Tipo") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Tipo") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Agente Comercial") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Agente Comercial") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Incluído em") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( AV15Selected)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A345NegID.ToString()));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A356NegCodigo), 12, 0, ".", ""))));
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
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A350NegCliID.ToString()));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A351NegCliNomeFamiliar));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A352NegCpjID.ToString()));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A353NegCpjNomFan));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A354NegCpjRazSocial));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A355NegCpjMatricula), 15, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A357NegPjtID), 11, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A358NegPjtSigla));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A359NegPjtNome));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A360NegAgcID)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A361NegAgcNome));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A346NegInsData, "99/99/99")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A364NegInsUsuNome));
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
         edtavNegultfase_vazio_Internalname = "vNEGULTFASE_VAZIO";
         bttBtnenter_Internalname = "BTNENTER";
         divTableactions_Internalname = "TABLEACTIONS";
         lblCleanfilters_Internalname = "CLEANFILTERS";
         edtavFilterfulltext_Internalname = "vFILTERFULLTEXT";
         tblTablerightheader_Internalname = "TABLERIGHTHEADER";
         divTableheadercontent_Internalname = "TABLEHEADERCONTENT";
         divTableheader_Internalname = "TABLEHEADER";
         chkavSelected_Internalname = "vSELECTED";
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
         edtNegInsData_Internalname = "NEGINSDATA";
         edtNegInsUsuNome_Internalname = "NEGINSUSUNOME";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         Ddo_grid_Internalname = "DDO_GRID";
         Dvelop_confirmpanel_enter_Internalname = "DVELOP_CONFIRMPANEL_ENTER";
         tblTabledvelop_confirmpanel_enter_Internalname = "TABLEDVELOP_CONFIRMPANEL_ENTER";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
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
         edtNegInsUsuNome_Jsonclick = "";
         edtNegInsData_Jsonclick = "";
         edtNegAgcNome_Jsonclick = "";
         edtNegAgcID_Jsonclick = "";
         edtNegPjtNome_Jsonclick = "";
         edtNegPjtSigla_Jsonclick = "";
         edtNegPjtID_Jsonclick = "";
         edtNegCpjMatricula_Jsonclick = "";
         edtNegCpjRazSocial_Jsonclick = "";
         edtNegCpjNomFan_Jsonclick = "";
         edtNegCpjID_Jsonclick = "";
         edtNegCliNomeFamiliar_Jsonclick = "";
         edtNegCliID_Jsonclick = "";
         edtNegAssunto_Jsonclick = "";
         edtNegInsUsuID_Jsonclick = "";
         edtNegInsDataHora_Jsonclick = "";
         edtNegInsHora_Jsonclick = "";
         edtNegCodigo_Jsonclick = "";
         edtNegID_Jsonclick = "";
         chkavSelected.Caption = "";
         chkavSelected.Visible = -1;
         chkavSelected.Enabled = 1;
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         subGrid_Sortable = 0;
         edtavDdo_neginsdataauxdatetext_Jsonclick = "";
         edtavNegultfase_vazio_Jsonclick = "";
         edtavNegultfase_vazio_Enabled = 1;
         divLayoutmaintable_Class = "Table";
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Dvelop_confirmpanel_enter_Confirmtype = "1";
         Dvelop_confirmpanel_enter_Yesbuttonposition = "left";
         Dvelop_confirmpanel_enter_Cancelbuttoncaption = "WWP_ConfirmTextCancel";
         Dvelop_confirmpanel_enter_Nobuttoncaption = "WWP_ConfirmTextNo";
         Dvelop_confirmpanel_enter_Yesbuttoncaption = "WWP_ConfirmTextYes";
         Dvelop_confirmpanel_enter_Confirmationtext = "Deseja mesmo incluir as oportunidades selecionadas?";
         Dvelop_confirmpanel_enter_Title = "Selecionar oportunidades";
         Ddo_grid_Format = "12.0||||12.0|||";
         Ddo_grid_Datalistproc = "core.NegocioPJSemFasePromptGetFilterData";
         Ddo_grid_Datalisttype = "|Dynamic|Dynamic|Dynamic||Dynamic|Dynamic|";
         Ddo_grid_Includedatalist = "|T|T|T||T|T|";
         Ddo_grid_Filterisrange = "T||||T|||P";
         Ddo_grid_Filtertype = "Numeric|Character|Character|Character|Numeric|Character|Character|Date";
         Ddo_grid_Includefilter = "T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "2|3|4|5|6|7|8|1";
         Ddo_grid_Columnids = "2:NegCodigo|6:NegAssunto|8:NegCliNomeFamiliar|10:NegCpjNomFan|12:NegCpjMatricula|15:NegPjtNome|17:NegAgcNome|18:NegInsData";
         Ddo_grid_Gridinternalname = "";
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
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Selecionar Oportunidades";
         subGrid_Rows = 0;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV53i',fld:'vI',pic:'ZZZZZZZZZ9'},{av:'AV46NegIDCol',fld:'vNEGIDCOL',pic:''},{av:'AV52NegIDToFind',fld:'vNEGIDTOFIND',pic:''},{av:'AV14FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV48NegID_WSKey',fld:'vNEGID_WSKEY',pic:'',hsh:true},{av:'AV58Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV11OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV12OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV13NegUltFase_Vazio',fld:'vNEGULTFASE_VAZIO',pic:'ZZZZZZZ9'},{av:'AV17TFNegCodigo',fld:'vTFNEGCODIGO',pic:'ZZZZZZZZZZZ9'},{av:'AV18TFNegCodigo_To',fld:'vTFNEGCODIGO_TO',pic:'ZZZZZZZZZZZ9'},{av:'AV19TFNegAssunto',fld:'vTFNEGASSUNTO',pic:'@!'},{av:'AV20TFNegAssunto_Sel',fld:'vTFNEGASSUNTO_SEL',pic:'@!'},{av:'AV21TFNegCliNomeFamiliar',fld:'vTFNEGCLINOMEFAMILIAR',pic:'@!'},{av:'AV22TFNegCliNomeFamiliar_Sel',fld:'vTFNEGCLINOMEFAMILIAR_SEL',pic:'@!'},{av:'AV23TFNegCpjNomFan',fld:'vTFNEGCPJNOMFAN',pic:'@!'},{av:'AV24TFNegCpjNomFan_Sel',fld:'vTFNEGCPJNOMFAN_SEL',pic:'@!'},{av:'AV25TFNegCpjMatricula',fld:'vTFNEGCPJMATRICULA',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV26TFNegCpjMatricula_To',fld:'vTFNEGCPJMATRICULA_TO',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV27TFNegPjtNome',fld:'vTFNEGPJTNOME',pic:'@!'},{av:'AV28TFNegPjtNome_Sel',fld:'vTFNEGPJTNOME_SEL',pic:'@!'},{av:'AV29TFNegAgcNome',fld:'vTFNEGAGCNOME',pic:'@!'},{av:'AV30TFNegAgcNome_Sel',fld:'vTFNEGAGCNOME_SEL',pic:'@!'},{av:'AV31TFNegInsData',fld:'vTFNEGINSDATA',pic:''},{av:'AV32TFNegInsData_To',fld:'vTFNEGINSDATA_TO',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV46NegIDCol',fld:'vNEGIDCOL',pic:''},{av:'AV40GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV41GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV42GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E11522',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV48NegID_WSKey',fld:'vNEGID_WSKEY',pic:'',hsh:true},{av:'AV58Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV11OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV12OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV13NegUltFase_Vazio',fld:'vNEGULTFASE_VAZIO',pic:'ZZZZZZZ9'},{av:'AV17TFNegCodigo',fld:'vTFNEGCODIGO',pic:'ZZZZZZZZZZZ9'},{av:'AV18TFNegCodigo_To',fld:'vTFNEGCODIGO_TO',pic:'ZZZZZZZZZZZ9'},{av:'AV19TFNegAssunto',fld:'vTFNEGASSUNTO',pic:'@!'},{av:'AV20TFNegAssunto_Sel',fld:'vTFNEGASSUNTO_SEL',pic:'@!'},{av:'AV21TFNegCliNomeFamiliar',fld:'vTFNEGCLINOMEFAMILIAR',pic:'@!'},{av:'AV22TFNegCliNomeFamiliar_Sel',fld:'vTFNEGCLINOMEFAMILIAR_SEL',pic:'@!'},{av:'AV23TFNegCpjNomFan',fld:'vTFNEGCPJNOMFAN',pic:'@!'},{av:'AV24TFNegCpjNomFan_Sel',fld:'vTFNEGCPJNOMFAN_SEL',pic:'@!'},{av:'AV25TFNegCpjMatricula',fld:'vTFNEGCPJMATRICULA',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV26TFNegCpjMatricula_To',fld:'vTFNEGCPJMATRICULA_TO',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV27TFNegPjtNome',fld:'vTFNEGPJTNOME',pic:'@!'},{av:'AV28TFNegPjtNome_Sel',fld:'vTFNEGPJTNOME_SEL',pic:'@!'},{av:'AV29TFNegAgcNome',fld:'vTFNEGAGCNOME',pic:'@!'},{av:'AV30TFNegAgcNome_Sel',fld:'vTFNEGAGCNOME_SEL',pic:'@!'},{av:'AV31TFNegInsData',fld:'vTFNEGINSDATA',pic:''},{av:'AV32TFNegInsData_To',fld:'vTFNEGINSDATA_TO',pic:''},{av:'AV53i',fld:'vI',pic:'ZZZZZZZZZ9'},{av:'AV46NegIDCol',fld:'vNEGIDCOL',pic:''},{av:'AV52NegIDToFind',fld:'vNEGIDTOFIND',pic:''},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E12522',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV48NegID_WSKey',fld:'vNEGID_WSKEY',pic:'',hsh:true},{av:'AV58Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV11OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV12OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV13NegUltFase_Vazio',fld:'vNEGULTFASE_VAZIO',pic:'ZZZZZZZ9'},{av:'AV17TFNegCodigo',fld:'vTFNEGCODIGO',pic:'ZZZZZZZZZZZ9'},{av:'AV18TFNegCodigo_To',fld:'vTFNEGCODIGO_TO',pic:'ZZZZZZZZZZZ9'},{av:'AV19TFNegAssunto',fld:'vTFNEGASSUNTO',pic:'@!'},{av:'AV20TFNegAssunto_Sel',fld:'vTFNEGASSUNTO_SEL',pic:'@!'},{av:'AV21TFNegCliNomeFamiliar',fld:'vTFNEGCLINOMEFAMILIAR',pic:'@!'},{av:'AV22TFNegCliNomeFamiliar_Sel',fld:'vTFNEGCLINOMEFAMILIAR_SEL',pic:'@!'},{av:'AV23TFNegCpjNomFan',fld:'vTFNEGCPJNOMFAN',pic:'@!'},{av:'AV24TFNegCpjNomFan_Sel',fld:'vTFNEGCPJNOMFAN_SEL',pic:'@!'},{av:'AV25TFNegCpjMatricula',fld:'vTFNEGCPJMATRICULA',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV26TFNegCpjMatricula_To',fld:'vTFNEGCPJMATRICULA_TO',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV27TFNegPjtNome',fld:'vTFNEGPJTNOME',pic:'@!'},{av:'AV28TFNegPjtNome_Sel',fld:'vTFNEGPJTNOME_SEL',pic:'@!'},{av:'AV29TFNegAgcNome',fld:'vTFNEGAGCNOME',pic:'@!'},{av:'AV30TFNegAgcNome_Sel',fld:'vTFNEGAGCNOME_SEL',pic:'@!'},{av:'AV31TFNegInsData',fld:'vTFNEGINSDATA',pic:''},{av:'AV32TFNegInsData_To',fld:'vTFNEGINSDATA_TO',pic:''},{av:'AV53i',fld:'vI',pic:'ZZZZZZZZZ9'},{av:'AV46NegIDCol',fld:'vNEGIDCOL',pic:''},{av:'AV52NegIDToFind',fld:'vNEGIDTOFIND',pic:''},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]}");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","{handler:'E13522',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV48NegID_WSKey',fld:'vNEGID_WSKEY',pic:'',hsh:true},{av:'AV58Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV11OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV12OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV13NegUltFase_Vazio',fld:'vNEGULTFASE_VAZIO',pic:'ZZZZZZZ9'},{av:'AV17TFNegCodigo',fld:'vTFNEGCODIGO',pic:'ZZZZZZZZZZZ9'},{av:'AV18TFNegCodigo_To',fld:'vTFNEGCODIGO_TO',pic:'ZZZZZZZZZZZ9'},{av:'AV19TFNegAssunto',fld:'vTFNEGASSUNTO',pic:'@!'},{av:'AV20TFNegAssunto_Sel',fld:'vTFNEGASSUNTO_SEL',pic:'@!'},{av:'AV21TFNegCliNomeFamiliar',fld:'vTFNEGCLINOMEFAMILIAR',pic:'@!'},{av:'AV22TFNegCliNomeFamiliar_Sel',fld:'vTFNEGCLINOMEFAMILIAR_SEL',pic:'@!'},{av:'AV23TFNegCpjNomFan',fld:'vTFNEGCPJNOMFAN',pic:'@!'},{av:'AV24TFNegCpjNomFan_Sel',fld:'vTFNEGCPJNOMFAN_SEL',pic:'@!'},{av:'AV25TFNegCpjMatricula',fld:'vTFNEGCPJMATRICULA',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV26TFNegCpjMatricula_To',fld:'vTFNEGCPJMATRICULA_TO',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV27TFNegPjtNome',fld:'vTFNEGPJTNOME',pic:'@!'},{av:'AV28TFNegPjtNome_Sel',fld:'vTFNEGPJTNOME_SEL',pic:'@!'},{av:'AV29TFNegAgcNome',fld:'vTFNEGAGCNOME',pic:'@!'},{av:'AV30TFNegAgcNome_Sel',fld:'vTFNEGAGCNOME_SEL',pic:'@!'},{av:'AV31TFNegInsData',fld:'vTFNEGINSDATA',pic:''},{av:'AV32TFNegInsData_To',fld:'vTFNEGINSDATA_TO',pic:''},{av:'AV53i',fld:'vI',pic:'ZZZZZZZZZ9'},{av:'AV46NegIDCol',fld:'vNEGIDCOL',pic:''},{av:'AV52NegIDToFind',fld:'vNEGIDTOFIND',pic:''},{av:'Ddo_grid_Activeeventkey',ctrl:'DDO_GRID',prop:'ActiveEventKey'},{av:'Ddo_grid_Selectedvalue_get',ctrl:'DDO_GRID',prop:'SelectedValue_get'},{av:'Ddo_grid_Filteredtextto_get',ctrl:'DDO_GRID',prop:'FilteredTextTo_get'},{av:'Ddo_grid_Filteredtext_get',ctrl:'DDO_GRID',prop:'FilteredText_get'},{av:'Ddo_grid_Selectedcolumn',ctrl:'DDO_GRID',prop:'SelectedColumn'}]");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",",oparms:[{av:'AV11OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV12OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV31TFNegInsData',fld:'vTFNEGINSDATA',pic:''},{av:'AV32TFNegInsData_To',fld:'vTFNEGINSDATA_TO',pic:''},{av:'AV29TFNegAgcNome',fld:'vTFNEGAGCNOME',pic:'@!'},{av:'AV30TFNegAgcNome_Sel',fld:'vTFNEGAGCNOME_SEL',pic:'@!'},{av:'AV27TFNegPjtNome',fld:'vTFNEGPJTNOME',pic:'@!'},{av:'AV28TFNegPjtNome_Sel',fld:'vTFNEGPJTNOME_SEL',pic:'@!'},{av:'AV25TFNegCpjMatricula',fld:'vTFNEGCPJMATRICULA',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV26TFNegCpjMatricula_To',fld:'vTFNEGCPJMATRICULA_TO',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV23TFNegCpjNomFan',fld:'vTFNEGCPJNOMFAN',pic:'@!'},{av:'AV24TFNegCpjNomFan_Sel',fld:'vTFNEGCPJNOMFAN_SEL',pic:'@!'},{av:'AV21TFNegCliNomeFamiliar',fld:'vTFNEGCLINOMEFAMILIAR',pic:'@!'},{av:'AV22TFNegCliNomeFamiliar_Sel',fld:'vTFNEGCLINOMEFAMILIAR_SEL',pic:'@!'},{av:'AV19TFNegAssunto',fld:'vTFNEGASSUNTO',pic:'@!'},{av:'AV20TFNegAssunto_Sel',fld:'vTFNEGASSUNTO_SEL',pic:'@!'},{av:'AV17TFNegCodigo',fld:'vTFNEGCODIGO',pic:'ZZZZZZZZZZZ9'},{av:'AV18TFNegCodigo_To',fld:'vTFNEGCODIGO_TO',pic:'ZZZZZZZZZZZ9'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E18522',iparms:[{av:'A345NegID',fld:'NEGID',pic:'',hsh:true},{av:'AV53i',fld:'vI',pic:'ZZZZZZZZZ9'},{av:'AV46NegIDCol',fld:'vNEGIDCOL',pic:''},{av:'AV52NegIDToFind',fld:'vNEGIDTOFIND',pic:''}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'AV15Selected',fld:'vSELECTED',pic:''},{av:'AV52NegIDToFind',fld:'vNEGIDTOFIND',pic:''},{av:'AV53i',fld:'vI',pic:'ZZZZZZZZZ9'}]}");
         setEventMetadata("VSELECTED.CLICK","{handler:'E19522',iparms:[{av:'AV15Selected',fld:'vSELECTED',pic:''},{av:'A345NegID',fld:'NEGID',pic:'',hsh:true},{av:'AV46NegIDCol',fld:'vNEGIDCOL',pic:''},{av:'AV53i',fld:'vI',pic:'ZZZZZZZZZ9'},{av:'AV48NegID_WSKey',fld:'vNEGID_WSKEY',pic:'',hsh:true},{av:'AV52NegIDToFind',fld:'vNEGIDTOFIND',pic:''}]");
         setEventMetadata("VSELECTED.CLICK",",oparms:[{av:'AV52NegIDToFind',fld:'vNEGIDTOFIND',pic:''},{av:'AV46NegIDCol',fld:'vNEGIDCOL',pic:''},{av:'divLayoutmaintable_Class',ctrl:'LAYOUTMAINTABLE',prop:'Class'},{av:'AV53i',fld:'vI',pic:'ZZZZZZZZZ9'}]}");
         setEventMetadata("ENTER","{handler:'E14522',iparms:[{av:'AV48NegID_WSKey',fld:'vNEGID_WSKEY',pic:'',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV46NegIDCol',fld:'vNEGIDCOL',pic:''}]}");
         setEventMetadata("'DOCLEANFILTERS'","{handler:'E15522',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV14FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV48NegID_WSKey',fld:'vNEGID_WSKEY',pic:'',hsh:true},{av:'AV58Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV11OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV12OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV13NegUltFase_Vazio',fld:'vNEGULTFASE_VAZIO',pic:'ZZZZZZZ9'},{av:'AV17TFNegCodigo',fld:'vTFNEGCODIGO',pic:'ZZZZZZZZZZZ9'},{av:'AV18TFNegCodigo_To',fld:'vTFNEGCODIGO_TO',pic:'ZZZZZZZZZZZ9'},{av:'AV19TFNegAssunto',fld:'vTFNEGASSUNTO',pic:'@!'},{av:'AV20TFNegAssunto_Sel',fld:'vTFNEGASSUNTO_SEL',pic:'@!'},{av:'AV21TFNegCliNomeFamiliar',fld:'vTFNEGCLINOMEFAMILIAR',pic:'@!'},{av:'AV22TFNegCliNomeFamiliar_Sel',fld:'vTFNEGCLINOMEFAMILIAR_SEL',pic:'@!'},{av:'AV23TFNegCpjNomFan',fld:'vTFNEGCPJNOMFAN',pic:'@!'},{av:'AV24TFNegCpjNomFan_Sel',fld:'vTFNEGCPJNOMFAN_SEL',pic:'@!'},{av:'AV25TFNegCpjMatricula',fld:'vTFNEGCPJMATRICULA',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV26TFNegCpjMatricula_To',fld:'vTFNEGCPJMATRICULA_TO',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV27TFNegPjtNome',fld:'vTFNEGPJTNOME',pic:'@!'},{av:'AV28TFNegPjtNome_Sel',fld:'vTFNEGPJTNOME_SEL',pic:'@!'},{av:'AV29TFNegAgcNome',fld:'vTFNEGAGCNOME',pic:'@!'},{av:'AV30TFNegAgcNome_Sel',fld:'vTFNEGAGCNOME_SEL',pic:'@!'},{av:'AV31TFNegInsData',fld:'vTFNEGINSDATA',pic:''},{av:'AV32TFNegInsData_To',fld:'vTFNEGINSDATA_TO',pic:''},{av:'AV53i',fld:'vI',pic:'ZZZZZZZZZ9'},{av:'AV46NegIDCol',fld:'vNEGIDCOL',pic:''},{av:'AV52NegIDToFind',fld:'vNEGIDTOFIND',pic:''}]");
         setEventMetadata("'DOCLEANFILTERS'",",oparms:[{av:'AV13NegUltFase_Vazio',fld:'vNEGULTFASE_VAZIO',pic:'ZZZZZZZ9'},{av:'AV14FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV17TFNegCodigo',fld:'vTFNEGCODIGO',pic:'ZZZZZZZZZZZ9'},{av:'AV18TFNegCodigo_To',fld:'vTFNEGCODIGO_TO',pic:'ZZZZZZZZZZZ9'},{av:'AV19TFNegAssunto',fld:'vTFNEGASSUNTO',pic:'@!'},{av:'AV20TFNegAssunto_Sel',fld:'vTFNEGASSUNTO_SEL',pic:'@!'},{av:'AV21TFNegCliNomeFamiliar',fld:'vTFNEGCLINOMEFAMILIAR',pic:'@!'},{av:'AV22TFNegCliNomeFamiliar_Sel',fld:'vTFNEGCLINOMEFAMILIAR_SEL',pic:'@!'},{av:'AV23TFNegCpjNomFan',fld:'vTFNEGCPJNOMFAN',pic:'@!'},{av:'AV24TFNegCpjNomFan_Sel',fld:'vTFNEGCPJNOMFAN_SEL',pic:'@!'},{av:'AV25TFNegCpjMatricula',fld:'vTFNEGCPJMATRICULA',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV26TFNegCpjMatricula_To',fld:'vTFNEGCPJMATRICULA_TO',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV27TFNegPjtNome',fld:'vTFNEGPJTNOME',pic:'@!'},{av:'AV28TFNegPjtNome_Sel',fld:'vTFNEGPJTNOME_SEL',pic:'@!'},{av:'AV29TFNegAgcNome',fld:'vTFNEGAGCNOME',pic:'@!'},{av:'AV30TFNegAgcNome_Sel',fld:'vTFNEGAGCNOME_SEL',pic:'@!'},{av:'AV31TFNegInsData',fld:'vTFNEGINSDATA',pic:''},{av:'AV32TFNegInsData_To',fld:'vTFNEGINSDATA_TO',pic:''},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'}]}");
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
         wcpOAV48NegID_WSKey = "";
         Gridpaginationbar_Selectedpage = "";
         Ddo_grid_Activeeventkey = "";
         Ddo_grid_Selectedvalue_get = "";
         Ddo_grid_Filteredtextto_get = "";
         Ddo_grid_Filteredtext_get = "";
         Ddo_grid_Selectedcolumn = "";
         Dvelop_confirmpanel_enter_Result = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV14FilterFullText = "";
         AV58Pgmname = "";
         AV19TFNegAssunto = "";
         AV20TFNegAssunto_Sel = "";
         AV21TFNegCliNomeFamiliar = "";
         AV22TFNegCliNomeFamiliar_Sel = "";
         AV23TFNegCpjNomFan = "";
         AV24TFNegCpjNomFan_Sel = "";
         AV27TFNegPjtNome = "";
         AV28TFNegPjtNome_Sel = "";
         AV29TFNegAgcNome = "";
         AV30TFNegAgcNome_Sel = "";
         AV31TFNegInsData = DateTime.MinValue;
         AV32TFNegInsData_To = DateTime.MinValue;
         AV46NegIDCol = new GxSimpleCollection<Guid>();
         AV52NegIDToFind = Guid.Empty;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV42GridAppliedFilters = "";
         AV36DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV33DDO_NegInsDataAuxDate = DateTime.MinValue;
         AV34DDO_NegInsDataAuxDateTo = DateTime.MinValue;
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
         bttBtnenter_Jsonclick = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridpaginationbar = new GXUserControl();
         ucDdo_grid = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         AV35DDO_NegInsDataAuxDateText = "";
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
         lV14FilterFullText = "";
         lV19TFNegAssunto = "";
         lV21TFNegCliNomeFamiliar = "";
         lV23TFNegCpjNomFan = "";
         lV27TFNegPjtNome = "";
         lV29TFNegAgcNome = "";
         H00522_A386NegUltFase = new int[1] ;
         H00522_A364NegInsUsuNome = new string[] {""} ;
         H00522_n364NegInsUsuNome = new bool[] {false} ;
         H00522_A346NegInsData = new DateTime[] {DateTime.MinValue} ;
         H00522_A361NegAgcNome = new string[] {""} ;
         H00522_n361NegAgcNome = new bool[] {false} ;
         H00522_A360NegAgcID = new string[] {""} ;
         H00522_n360NegAgcID = new bool[] {false} ;
         H00522_A359NegPjtNome = new string[] {""} ;
         H00522_A358NegPjtSigla = new string[] {""} ;
         H00522_A357NegPjtID = new int[1] ;
         H00522_A355NegCpjMatricula = new long[1] ;
         H00522_A354NegCpjRazSocial = new string[] {""} ;
         H00522_A353NegCpjNomFan = new string[] {""} ;
         H00522_A352NegCpjID = new Guid[] {Guid.Empty} ;
         H00522_A351NegCliNomeFamiliar = new string[] {""} ;
         H00522_A350NegCliID = new Guid[] {Guid.Empty} ;
         H00522_A362NegAssunto = new string[] {""} ;
         H00522_A349NegInsUsuID = new string[] {""} ;
         H00522_n349NegInsUsuID = new bool[] {false} ;
         H00522_A348NegInsDataHora = new DateTime[] {DateTime.MinValue} ;
         H00522_A347NegInsHora = new DateTime[] {DateTime.MinValue} ;
         H00522_A356NegCodigo = new long[1] ;
         H00522_A345NegID = new Guid[] {Guid.Empty} ;
         H00523_AGRID_nRecordCount = new long[1] ;
         AV37GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV38GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV8HTTPRequest = new GxHttpRequest( context);
         AV16Session = context.GetSession();
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_char2 = "";
         GridRow = new GXWebRow();
         AV54ItemNegID = Guid.Empty;
         AV55Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV56Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV47NegIDColItem = Guid.Empty;
         AV9GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         ucDvelop_confirmpanel_enter = new GXUserControl();
         lblCleanfilters_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         GXCCtl = "";
         ROClassString = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.negociopjsemfaseprompt__default(),
            new Object[][] {
                new Object[] {
               H00522_A386NegUltFase, H00522_A364NegInsUsuNome, H00522_n364NegInsUsuNome, H00522_A346NegInsData, H00522_A361NegAgcNome, H00522_n361NegAgcNome, H00522_A360NegAgcID, H00522_n360NegAgcID, H00522_A359NegPjtNome, H00522_A358NegPjtSigla,
               H00522_A357NegPjtID, H00522_A355NegCpjMatricula, H00522_A354NegCpjRazSocial, H00522_A353NegCpjNomFan, H00522_A352NegCpjID, H00522_A351NegCliNomeFamiliar, H00522_A350NegCliID, H00522_A362NegAssunto, H00522_A349NegInsUsuID, H00522_n349NegInsUsuID,
               H00522_A348NegInsDataHora, H00522_A347NegInsHora, H00522_A356NegCodigo, H00522_A345NegID
               }
               , new Object[] {
               H00523_AGRID_nRecordCount
               }
            }
         );
         AV58Pgmname = "core.NegocioPJSemFasePrompt";
         /* GeneXus formulas. */
         AV58Pgmname = "core.NegocioPJSemFasePrompt";
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV11OrderedBy ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
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
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_35 ;
      private int subGrid_Rows ;
      private int nGXsfl_35_idx=1 ;
      private int AV13NegUltFase_Vazio ;
      private int Gridpaginationbar_Pagestoshow ;
      private int edtavNegultfase_vazio_Enabled ;
      private int A357NegPjtID ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int A386NegUltFase ;
      private int AV39PageToGo ;
      private int AV59GXV1 ;
      private int AV60GXV2 ;
      private int AV61GXV3 ;
      private int edtavFilterfulltext_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV17TFNegCodigo ;
      private long AV18TFNegCodigo_To ;
      private long AV25TFNegCpjMatricula ;
      private long AV26TFNegCpjMatricula_To ;
      private long AV53i ;
      private long AV40GridCurrentPage ;
      private long AV41GridPageCount ;
      private long A356NegCodigo ;
      private long A355NegCpjMatricula ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Dvelop_confirmpanel_enter_Result ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_35_idx="0001" ;
      private string AV58Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
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
      private string Ddo_grid_Format ;
      private string Dvelop_confirmpanel_enter_Title ;
      private string Dvelop_confirmpanel_enter_Confirmationtext ;
      private string Dvelop_confirmpanel_enter_Yesbuttoncaption ;
      private string Dvelop_confirmpanel_enter_Nobuttoncaption ;
      private string Dvelop_confirmpanel_enter_Cancelbuttoncaption ;
      private string Dvelop_confirmpanel_enter_Yesbuttonposition ;
      private string Dvelop_confirmpanel_enter_Confirmtype ;
      private string Grid_empowerer_Gridinternalname ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string edtavNegultfase_vazio_Internalname ;
      private string TempTags ;
      private string edtavNegultfase_vazio_Jsonclick ;
      private string divTableheader_Internalname ;
      private string divTableheadercontent_Internalname ;
      private string divTableactions_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Jsonclick ;
      private string divGridtablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string Gridpaginationbar_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Ddo_grid_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string divDdo_neginsdataauxdates_Internalname ;
      private string edtavDdo_neginsdataauxdatetext_Internalname ;
      private string edtavDdo_neginsdataauxdatetext_Jsonclick ;
      private string Tfneginsdata_rangepicker_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string chkavSelected_Internalname ;
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
      private string edtNegInsData_Internalname ;
      private string edtNegInsUsuNome_Internalname ;
      private string scmdbuf ;
      private string edtavFilterfulltext_Internalname ;
      private string GXt_char2 ;
      private string tblTabledvelop_confirmpanel_enter_Internalname ;
      private string Dvelop_confirmpanel_enter_Internalname ;
      private string tblTablerightheader_Internalname ;
      private string lblCleanfilters_Internalname ;
      private string lblCleanfilters_Jsonclick ;
      private string edtavFilterfulltext_Jsonclick ;
      private string sGXsfl_35_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string GXCCtl ;
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
      private string edtNegInsData_Jsonclick ;
      private string edtNegInsUsuNome_Jsonclick ;
      private string subGrid_Header ;
      private DateTime A347NegInsHora ;
      private DateTime A348NegInsDataHora ;
      private DateTime AV31TFNegInsData ;
      private DateTime AV32TFNegInsData_To ;
      private DateTime AV33DDO_NegInsDataAuxDate ;
      private DateTime AV34DDO_NegInsDataAuxDateTo ;
      private DateTime A346NegInsData ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV12OrderedDsc ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool AV15Selected ;
      private bool n349NegInsUsuID ;
      private bool n360NegAgcID ;
      private bool n361NegAgcNome ;
      private bool n364NegInsUsuNome ;
      private bool bGXsfl_35_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool AV57HasErrores ;
      private string AV48NegID_WSKey ;
      private string wcpOAV48NegID_WSKey ;
      private string AV14FilterFullText ;
      private string AV19TFNegAssunto ;
      private string AV20TFNegAssunto_Sel ;
      private string AV21TFNegCliNomeFamiliar ;
      private string AV22TFNegCliNomeFamiliar_Sel ;
      private string AV23TFNegCpjNomFan ;
      private string AV24TFNegCpjNomFan_Sel ;
      private string AV27TFNegPjtNome ;
      private string AV28TFNegPjtNome_Sel ;
      private string AV29TFNegAgcNome ;
      private string AV30TFNegAgcNome_Sel ;
      private string AV42GridAppliedFilters ;
      private string AV35DDO_NegInsDataAuxDateText ;
      private string A362NegAssunto ;
      private string A351NegCliNomeFamiliar ;
      private string A353NegCpjNomFan ;
      private string A354NegCpjRazSocial ;
      private string A358NegPjtSigla ;
      private string A359NegPjtNome ;
      private string A361NegAgcNome ;
      private string A364NegInsUsuNome ;
      private string lV14FilterFullText ;
      private string lV19TFNegAssunto ;
      private string lV21TFNegCliNomeFamiliar ;
      private string lV23TFNegCpjNomFan ;
      private string lV27TFNegPjtNome ;
      private string lV29TFNegAgcNome ;
      private Guid AV52NegIDToFind ;
      private Guid A345NegID ;
      private Guid A350NegCliID ;
      private Guid A352NegCpjID ;
      private Guid AV54ItemNegID ;
      private Guid AV47NegIDColItem ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucTfneginsdata_rangepicker ;
      private GXUserControl ucDvelop_confirmpanel_enter ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkavSelected ;
      private IDataStoreProvider pr_default ;
      private int[] H00522_A386NegUltFase ;
      private string[] H00522_A364NegInsUsuNome ;
      private bool[] H00522_n364NegInsUsuNome ;
      private DateTime[] H00522_A346NegInsData ;
      private string[] H00522_A361NegAgcNome ;
      private bool[] H00522_n361NegAgcNome ;
      private string[] H00522_A360NegAgcID ;
      private bool[] H00522_n360NegAgcID ;
      private string[] H00522_A359NegPjtNome ;
      private string[] H00522_A358NegPjtSigla ;
      private int[] H00522_A357NegPjtID ;
      private long[] H00522_A355NegCpjMatricula ;
      private string[] H00522_A354NegCpjRazSocial ;
      private string[] H00522_A353NegCpjNomFan ;
      private Guid[] H00522_A352NegCpjID ;
      private string[] H00522_A351NegCliNomeFamiliar ;
      private Guid[] H00522_A350NegCliID ;
      private string[] H00522_A362NegAssunto ;
      private string[] H00522_A349NegInsUsuID ;
      private bool[] H00522_n349NegInsUsuID ;
      private DateTime[] H00522_A348NegInsDataHora ;
      private DateTime[] H00522_A347NegInsHora ;
      private long[] H00522_A356NegCodigo ;
      private Guid[] H00522_A345NegID ;
      private long[] H00523_AGRID_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV8HTTPRequest ;
      private IGxSession AV16Session ;
      private GxSimpleCollection<Guid> AV46NegIDCol ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV38GAMErrors ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV55Messages ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV9GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV36DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV37GAMSession ;
      private GeneXus.Utils.SdtMessages_Message AV56Message ;
   }

   public class negociopjsemfaseprompt__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00522( IGxContext context ,
                                             string AV14FilterFullText ,
                                             long AV17TFNegCodigo ,
                                             long AV18TFNegCodigo_To ,
                                             string AV20TFNegAssunto_Sel ,
                                             string AV19TFNegAssunto ,
                                             string AV22TFNegCliNomeFamiliar_Sel ,
                                             string AV21TFNegCliNomeFamiliar ,
                                             string AV24TFNegCpjNomFan_Sel ,
                                             string AV23TFNegCpjNomFan ,
                                             long AV25TFNegCpjMatricula ,
                                             long AV26TFNegCpjMatricula_To ,
                                             string AV28TFNegPjtNome_Sel ,
                                             string AV27TFNegPjtNome ,
                                             string AV30TFNegAgcNome_Sel ,
                                             string AV29TFNegAgcNome ,
                                             DateTime AV31TFNegInsData ,
                                             DateTime AV32TFNegInsData_To ,
                                             long A356NegCodigo ,
                                             string A362NegAssunto ,
                                             string A351NegCliNomeFamiliar ,
                                             string A353NegCpjNomFan ,
                                             long A355NegCpjMatricula ,
                                             string A359NegPjtNome ,
                                             string A361NegAgcNome ,
                                             DateTime A346NegInsData ,
                                             short AV11OrderedBy ,
                                             bool AV12OrderedDsc ,
                                             int A386NegUltFase )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[26];
         Object[] GXv_Object4 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.NegUltFase, T1.NegInsUsuNome, T1.NegInsData, T1.NegAgcNome, T1.NegAgcID, T1.NegPjtNome AS NegPjtNome, T3.PjtSigla AS NegPjtSigla, T2.CpjTipoId AS NegPjtID, T2.CpjMatricula AS NegCpjMatricula, T1.NegCpjRazSocial AS NegCpjRazSocial, T1.NegCpjNomFan AS NegCpjNomFan, T1.NegCpjID AS NegCpjID, T1.NegCliNomeFamiliar, T1.NegCliID AS NegCliID, T1.NegAssunto, T1.NegInsUsuID, T1.NegInsDataHora, T1.NegInsHora, T1.NegCodigo, T1.NegID";
         sFromString = " FROM ((tb_negociopj T1 INNER JOIN tb_clientepj T2 ON T2.CliID = T1.NegCliID AND T2.CpjID = T1.NegCpjID) INNER JOIN tb_clientepjtipo T3 ON T3.PjtID = T2.CpjTipoId)";
         sOrderString = "";
         AddWhere(sWhereString, "((T1.NegUltFase = 0) or T1.NegUltFase IS NULL)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14FilterFullText)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(T1.NegCodigo,'999999999999'), 2) like '%' || :lV14FilterFullText) or ( LOWER(T1.NegAssunto) like '%' || LOWER(:lV14FilterFullText)) or ( LOWER(T1.NegCliNomeFamiliar) like '%' || LOWER(:lV14FilterFullText)) or ( LOWER(T1.NegCpjNomFan) like '%' || LOWER(:lV14FilterFullText)) or ( SUBSTR(TO_CHAR(T2.CpjMatricula,'999999999999'), 2) like '%' || :lV14FilterFullText) or ( LOWER(T1.NegPjtNome) like '%' || LOWER(:lV14FilterFullText)) or ( LOWER(T1.NegAgcNome) like '%' || LOWER(:lV14FilterFullText)))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
            GXv_int3[4] = 1;
            GXv_int3[5] = 1;
            GXv_int3[6] = 1;
         }
         if ( ! (0==AV17TFNegCodigo) )
         {
            AddWhere(sWhereString, "(T1.NegCodigo >= :AV17TFNegCodigo)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( ! (0==AV18TFNegCodigo_To) )
         {
            AddWhere(sWhereString, "(T1.NegCodigo <= :AV18TFNegCodigo_To)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV20TFNegAssunto_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19TFNegAssunto)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto like :lV19TFNegAssunto)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20TFNegAssunto_Sel)) && ! ( StringUtil.StrCmp(AV20TFNegAssunto_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto = ( :AV20TFNegAssunto_Sel))");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( StringUtil.StrCmp(AV20TFNegAssunto_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.NegAssunto))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV22TFNegCliNomeFamiliar_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TFNegCliNomeFamiliar)) ) )
         {
            AddWhere(sWhereString, "(T1.NegCliNomeFamiliar like :lV21TFNegCliNomeFamiliar)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22TFNegCliNomeFamiliar_Sel)) && ! ( StringUtil.StrCmp(AV22TFNegCliNomeFamiliar_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegCliNomeFamiliar = ( :AV22TFNegCliNomeFamiliar_Sel))");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( StringUtil.StrCmp(AV22TFNegCliNomeFamiliar_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.NegCliNomeFamiliar))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV24TFNegCpjNomFan_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23TFNegCpjNomFan)) ) )
         {
            AddWhere(sWhereString, "(T1.NegCpjNomFan like :lV23TFNegCpjNomFan)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24TFNegCpjNomFan_Sel)) && ! ( StringUtil.StrCmp(AV24TFNegCpjNomFan_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegCpjNomFan = ( :AV24TFNegCpjNomFan_Sel))");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( StringUtil.StrCmp(AV24TFNegCpjNomFan_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.NegCpjNomFan))=0))");
         }
         if ( ! (0==AV25TFNegCpjMatricula) )
         {
            AddWhere(sWhereString, "(T2.CpjMatricula >= :AV25TFNegCpjMatricula)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( ! (0==AV26TFNegCpjMatricula_To) )
         {
            AddWhere(sWhereString, "(T2.CpjMatricula <= :AV26TFNegCpjMatricula_To)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV28TFNegPjtNome_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27TFNegPjtNome)) ) )
         {
            AddWhere(sWhereString, "(T1.NegPjtNome like :lV27TFNegPjtNome)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28TFNegPjtNome_Sel)) && ! ( StringUtil.StrCmp(AV28TFNegPjtNome_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegPjtNome = ( :AV28TFNegPjtNome_Sel))");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( StringUtil.StrCmp(AV28TFNegPjtNome_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.NegPjtNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV30TFNegAgcNome_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29TFNegAgcNome)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAgcNome like :lV29TFNegAgcNome)");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30TFNegAgcNome_Sel)) && ! ( StringUtil.StrCmp(AV30TFNegAgcNome_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegAgcNome = ( :AV30TFNegAgcNome_Sel))");
         }
         else
         {
            GXv_int3[20] = 1;
         }
         if ( StringUtil.StrCmp(AV30TFNegAgcNome_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.NegAgcNome IS NULL or (char_length(trim(trailing ' ' from T1.NegAgcNome))=0))");
         }
         if ( ! (DateTime.MinValue==AV31TFNegInsData) )
         {
            AddWhere(sWhereString, "(T1.NegInsData >= :AV31TFNegInsData)");
         }
         else
         {
            GXv_int3[21] = 1;
         }
         if ( ! (DateTime.MinValue==AV32TFNegInsData_To) )
         {
            AddWhere(sWhereString, "(T1.NegInsData <= :AV32TFNegInsData_To)");
         }
         else
         {
            GXv_int3[22] = 1;
         }
         if ( ( AV11OrderedBy == 1 ) && ! AV12OrderedDsc )
         {
            sOrderString += " ORDER BY T1.NegInsDataHora, T1.NegID";
         }
         else if ( ( AV11OrderedBy == 1 ) && ( AV12OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.NegInsDataHora DESC, T1.NegID";
         }
         else if ( ( AV11OrderedBy == 2 ) && ! AV12OrderedDsc )
         {
            sOrderString += " ORDER BY T1.NegCodigo";
         }
         else if ( ( AV11OrderedBy == 2 ) && ( AV12OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.NegCodigo DESC";
         }
         else if ( ( AV11OrderedBy == 3 ) && ! AV12OrderedDsc )
         {
            sOrderString += " ORDER BY T1.NegAssunto, T1.NegID";
         }
         else if ( ( AV11OrderedBy == 3 ) && ( AV12OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.NegAssunto DESC, T1.NegID";
         }
         else if ( ( AV11OrderedBy == 4 ) && ! AV12OrderedDsc )
         {
            sOrderString += " ORDER BY T1.NegCliNomeFamiliar, T1.NegID";
         }
         else if ( ( AV11OrderedBy == 4 ) && ( AV12OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.NegCliNomeFamiliar DESC, T1.NegID";
         }
         else if ( ( AV11OrderedBy == 5 ) && ! AV12OrderedDsc )
         {
            sOrderString += " ORDER BY T1.NegCpjNomFan, T1.NegID";
         }
         else if ( ( AV11OrderedBy == 5 ) && ( AV12OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.NegCpjNomFan DESC, T1.NegID";
         }
         else if ( ( AV11OrderedBy == 6 ) && ! AV12OrderedDsc )
         {
            sOrderString += " ORDER BY T2.CpjMatricula, T1.NegID";
         }
         else if ( ( AV11OrderedBy == 6 ) && ( AV12OrderedDsc ) )
         {
            sOrderString += " ORDER BY T2.CpjMatricula DESC, T1.NegID";
         }
         else if ( ( AV11OrderedBy == 7 ) && ! AV12OrderedDsc )
         {
            sOrderString += " ORDER BY T1.NegPjtNome, T1.NegID";
         }
         else if ( ( AV11OrderedBy == 7 ) && ( AV12OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.NegPjtNome DESC, T1.NegID";
         }
         else if ( ( AV11OrderedBy == 8 ) && ! AV12OrderedDsc )
         {
            sOrderString += " ORDER BY T1.NegAgcNome, T1.NegID";
         }
         else if ( ( AV11OrderedBy == 8 ) && ( AV12OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.NegAgcNome DESC, T1.NegID";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.NegID";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_H00523( IGxContext context ,
                                             string AV14FilterFullText ,
                                             long AV17TFNegCodigo ,
                                             long AV18TFNegCodigo_To ,
                                             string AV20TFNegAssunto_Sel ,
                                             string AV19TFNegAssunto ,
                                             string AV22TFNegCliNomeFamiliar_Sel ,
                                             string AV21TFNegCliNomeFamiliar ,
                                             string AV24TFNegCpjNomFan_Sel ,
                                             string AV23TFNegCpjNomFan ,
                                             long AV25TFNegCpjMatricula ,
                                             long AV26TFNegCpjMatricula_To ,
                                             string AV28TFNegPjtNome_Sel ,
                                             string AV27TFNegPjtNome ,
                                             string AV30TFNegAgcNome_Sel ,
                                             string AV29TFNegAgcNome ,
                                             DateTime AV31TFNegInsData ,
                                             DateTime AV32TFNegInsData_To ,
                                             long A356NegCodigo ,
                                             string A362NegAssunto ,
                                             string A351NegCliNomeFamiliar ,
                                             string A353NegCpjNomFan ,
                                             long A355NegCpjMatricula ,
                                             string A359NegPjtNome ,
                                             string A361NegAgcNome ,
                                             DateTime A346NegInsData ,
                                             short AV11OrderedBy ,
                                             bool AV12OrderedDsc ,
                                             int A386NegUltFase )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[23];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM ((tb_negociopj T1 INNER JOIN tb_clientepj T2 ON T2.CliID = T1.NegCliID AND T2.CpjID = T1.NegCpjID) INNER JOIN tb_clientepjtipo T3 ON T3.PjtID = T2.CpjTipoId)";
         AddWhere(sWhereString, "((T1.NegUltFase = 0) or T1.NegUltFase IS NULL)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14FilterFullText)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(T1.NegCodigo,'999999999999'), 2) like '%' || :lV14FilterFullText) or ( LOWER(T1.NegAssunto) like '%' || LOWER(:lV14FilterFullText)) or ( LOWER(T1.NegCliNomeFamiliar) like '%' || LOWER(:lV14FilterFullText)) or ( LOWER(T1.NegCpjNomFan) like '%' || LOWER(:lV14FilterFullText)) or ( SUBSTR(TO_CHAR(T2.CpjMatricula,'999999999999'), 2) like '%' || :lV14FilterFullText) or ( LOWER(T1.NegPjtNome) like '%' || LOWER(:lV14FilterFullText)) or ( LOWER(T1.NegAgcNome) like '%' || LOWER(:lV14FilterFullText)))");
         }
         else
         {
            GXv_int5[0] = 1;
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
            GXv_int5[3] = 1;
            GXv_int5[4] = 1;
            GXv_int5[5] = 1;
            GXv_int5[6] = 1;
         }
         if ( ! (0==AV17TFNegCodigo) )
         {
            AddWhere(sWhereString, "(T1.NegCodigo >= :AV17TFNegCodigo)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( ! (0==AV18TFNegCodigo_To) )
         {
            AddWhere(sWhereString, "(T1.NegCodigo <= :AV18TFNegCodigo_To)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV20TFNegAssunto_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19TFNegAssunto)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto like :lV19TFNegAssunto)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20TFNegAssunto_Sel)) && ! ( StringUtil.StrCmp(AV20TFNegAssunto_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegAssunto = ( :AV20TFNegAssunto_Sel))");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( StringUtil.StrCmp(AV20TFNegAssunto_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.NegAssunto))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV22TFNegCliNomeFamiliar_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TFNegCliNomeFamiliar)) ) )
         {
            AddWhere(sWhereString, "(T1.NegCliNomeFamiliar like :lV21TFNegCliNomeFamiliar)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22TFNegCliNomeFamiliar_Sel)) && ! ( StringUtil.StrCmp(AV22TFNegCliNomeFamiliar_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegCliNomeFamiliar = ( :AV22TFNegCliNomeFamiliar_Sel))");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( StringUtil.StrCmp(AV22TFNegCliNomeFamiliar_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.NegCliNomeFamiliar))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV24TFNegCpjNomFan_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23TFNegCpjNomFan)) ) )
         {
            AddWhere(sWhereString, "(T1.NegCpjNomFan like :lV23TFNegCpjNomFan)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24TFNegCpjNomFan_Sel)) && ! ( StringUtil.StrCmp(AV24TFNegCpjNomFan_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegCpjNomFan = ( :AV24TFNegCpjNomFan_Sel))");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( StringUtil.StrCmp(AV24TFNegCpjNomFan_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.NegCpjNomFan))=0))");
         }
         if ( ! (0==AV25TFNegCpjMatricula) )
         {
            AddWhere(sWhereString, "(T2.CpjMatricula >= :AV25TFNegCpjMatricula)");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( ! (0==AV26TFNegCpjMatricula_To) )
         {
            AddWhere(sWhereString, "(T2.CpjMatricula <= :AV26TFNegCpjMatricula_To)");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV28TFNegPjtNome_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27TFNegPjtNome)) ) )
         {
            AddWhere(sWhereString, "(T1.NegPjtNome like :lV27TFNegPjtNome)");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28TFNegPjtNome_Sel)) && ! ( StringUtil.StrCmp(AV28TFNegPjtNome_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegPjtNome = ( :AV28TFNegPjtNome_Sel))");
         }
         else
         {
            GXv_int5[18] = 1;
         }
         if ( StringUtil.StrCmp(AV28TFNegPjtNome_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.NegPjtNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV30TFNegAgcNome_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29TFNegAgcNome)) ) )
         {
            AddWhere(sWhereString, "(T1.NegAgcNome like :lV29TFNegAgcNome)");
         }
         else
         {
            GXv_int5[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30TFNegAgcNome_Sel)) && ! ( StringUtil.StrCmp(AV30TFNegAgcNome_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NegAgcNome = ( :AV30TFNegAgcNome_Sel))");
         }
         else
         {
            GXv_int5[20] = 1;
         }
         if ( StringUtil.StrCmp(AV30TFNegAgcNome_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.NegAgcNome IS NULL or (char_length(trim(trailing ' ' from T1.NegAgcNome))=0))");
         }
         if ( ! (DateTime.MinValue==AV31TFNegInsData) )
         {
            AddWhere(sWhereString, "(T1.NegInsData >= :AV31TFNegInsData)");
         }
         else
         {
            GXv_int5[21] = 1;
         }
         if ( ! (DateTime.MinValue==AV32TFNegInsData_To) )
         {
            AddWhere(sWhereString, "(T1.NegInsData <= :AV32TFNegInsData_To)");
         }
         else
         {
            GXv_int5[22] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV11OrderedBy == 1 ) && ! AV12OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV11OrderedBy == 1 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV11OrderedBy == 2 ) && ! AV12OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV11OrderedBy == 2 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV11OrderedBy == 3 ) && ! AV12OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV11OrderedBy == 3 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV11OrderedBy == 4 ) && ! AV12OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV11OrderedBy == 4 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV11OrderedBy == 5 ) && ! AV12OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV11OrderedBy == 5 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV11OrderedBy == 6 ) && ! AV12OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV11OrderedBy == 6 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV11OrderedBy == 7 ) && ! AV12OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV11OrderedBy == 7 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV11OrderedBy == 8 ) && ! AV12OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV11OrderedBy == 8 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( true )
         {
            scmdbuf += "";
         }
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H00522(context, (string)dynConstraints[0] , (long)dynConstraints[1] , (long)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (long)dynConstraints[9] , (long)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (DateTime)dynConstraints[15] , (DateTime)dynConstraints[16] , (long)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (long)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (DateTime)dynConstraints[24] , (short)dynConstraints[25] , (bool)dynConstraints[26] , (int)dynConstraints[27] );
               case 1 :
                     return conditional_H00523(context, (string)dynConstraints[0] , (long)dynConstraints[1] , (long)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (long)dynConstraints[9] , (long)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (DateTime)dynConstraints[15] , (DateTime)dynConstraints[16] , (long)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (long)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (DateTime)dynConstraints[24] , (short)dynConstraints[25] , (bool)dynConstraints[26] , (int)dynConstraints[27] );
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
          Object[] prmH00522;
          prmH00522 = new Object[] {
          new ParDef("lV14FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV14FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV14FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV14FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV14FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV14FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV14FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("AV17TFNegCodigo",GXType.Int64,12,0) ,
          new ParDef("AV18TFNegCodigo_To",GXType.Int64,12,0) ,
          new ParDef("lV19TFNegAssunto",GXType.VarChar,80,0) ,
          new ParDef("AV20TFNegAssunto_Sel",GXType.VarChar,80,0) ,
          new ParDef("lV21TFNegCliNomeFamiliar",GXType.VarChar,80,0) ,
          new ParDef("AV22TFNegCliNomeFamiliar_Sel",GXType.VarChar,80,0) ,
          new ParDef("lV23TFNegCpjNomFan",GXType.VarChar,80,0) ,
          new ParDef("AV24TFNegCpjNomFan_Sel",GXType.VarChar,80,0) ,
          new ParDef("AV25TFNegCpjMatricula",GXType.Int64,12,0) ,
          new ParDef("AV26TFNegCpjMatricula_To",GXType.Int64,12,0) ,
          new ParDef("lV27TFNegPjtNome",GXType.VarChar,80,0) ,
          new ParDef("AV28TFNegPjtNome_Sel",GXType.VarChar,80,0) ,
          new ParDef("lV29TFNegAgcNome",GXType.VarChar,80,0) ,
          new ParDef("AV30TFNegAgcNome_Sel",GXType.VarChar,80,0) ,
          new ParDef("AV31TFNegInsData",GXType.Date,8,0) ,
          new ParDef("AV32TFNegInsData_To",GXType.Date,8,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00523;
          prmH00523 = new Object[] {
          new ParDef("lV14FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV14FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV14FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV14FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV14FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV14FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV14FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("AV17TFNegCodigo",GXType.Int64,12,0) ,
          new ParDef("AV18TFNegCodigo_To",GXType.Int64,12,0) ,
          new ParDef("lV19TFNegAssunto",GXType.VarChar,80,0) ,
          new ParDef("AV20TFNegAssunto_Sel",GXType.VarChar,80,0) ,
          new ParDef("lV21TFNegCliNomeFamiliar",GXType.VarChar,80,0) ,
          new ParDef("AV22TFNegCliNomeFamiliar_Sel",GXType.VarChar,80,0) ,
          new ParDef("lV23TFNegCpjNomFan",GXType.VarChar,80,0) ,
          new ParDef("AV24TFNegCpjNomFan_Sel",GXType.VarChar,80,0) ,
          new ParDef("AV25TFNegCpjMatricula",GXType.Int64,12,0) ,
          new ParDef("AV26TFNegCpjMatricula_To",GXType.Int64,12,0) ,
          new ParDef("lV27TFNegPjtNome",GXType.VarChar,80,0) ,
          new ParDef("AV28TFNegPjtNome_Sel",GXType.VarChar,80,0) ,
          new ParDef("lV29TFNegAgcNome",GXType.VarChar,80,0) ,
          new ParDef("AV30TFNegAgcNome_Sel",GXType.VarChar,80,0) ,
          new ParDef("AV31TFNegInsData",GXType.Date,8,0) ,
          new ParDef("AV32TFNegInsData_To",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00522", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00522,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00523", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00523,1, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((string[]) buf[6])[0] = rslt.getString(5, 40);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((string[]) buf[8])[0] = rslt.getVarchar(6);
                ((string[]) buf[9])[0] = rslt.getVarchar(7);
                ((int[]) buf[10])[0] = rslt.getInt(8);
                ((long[]) buf[11])[0] = rslt.getLong(9);
                ((string[]) buf[12])[0] = rslt.getVarchar(10);
                ((string[]) buf[13])[0] = rslt.getVarchar(11);
                ((Guid[]) buf[14])[0] = rslt.getGuid(12);
                ((string[]) buf[15])[0] = rslt.getVarchar(13);
                ((Guid[]) buf[16])[0] = rslt.getGuid(14);
                ((string[]) buf[17])[0] = rslt.getVarchar(15);
                ((string[]) buf[18])[0] = rslt.getString(16, 40);
                ((bool[]) buf[19])[0] = rslt.wasNull(16);
                ((DateTime[]) buf[20])[0] = rslt.getGXDateTime(17, true);
                ((DateTime[]) buf[21])[0] = rslt.getGXDateTime(18);
                ((long[]) buf[22])[0] = rslt.getLong(19);
                ((Guid[]) buf[23])[0] = rslt.getGuid(20);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
