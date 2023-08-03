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
   public class webfunilgridviewiteracoes : GXWebComponent
   {
      public webfunilgridviewiteracoes( )
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

      public webfunilgridviewiteracoes( IGxContext context )
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

      public override void SetPrefix( string sPPrefix )
      {
         sPrefix = sPPrefix;
      }

      protected override void createObjects( )
      {
         chkIteAtivo = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
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
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix});
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
         nRC_GXsfl_6 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_6"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_6_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_6_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_6_idx = GetPar( "sGXsfl_6_idx");
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
         ajax_req_read_hidden_sdt(GetNextPar( ), AV35ColumnsSelector);
         AV17FilterFullText = GetPar( "FilterFullText");
         AV18DynamicFiltersSelector1 = GetPar( "DynamicFiltersSelector1");
         AV19DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator1"), "."), 18, MidpointRounding.ToEven));
         AV20IteNome1 = GetPar( "IteNome1");
         AV21DynamicFiltersEnabled2 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled2"));
         AV22DynamicFiltersSelector2 = GetPar( "DynamicFiltersSelector2");
         AV23DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator2"), "."), 18, MidpointRounding.ToEven));
         AV24IteNome2 = GetPar( "IteNome2");
         AV25DynamicFiltersEnabled3 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled3"));
         AV26DynamicFiltersSelector3 = GetPar( "DynamicFiltersSelector3");
         AV27DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator3"), "."), 18, MidpointRounding.ToEven));
         AV28IteNome3 = GetPar( "IteNome3");
         AV41TFIteNome = GetPar( "TFIteNome");
         AV42TFIteNome_Sel = GetPar( "TFIteNome_Sel");
         AV15OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV11GridState);
         AV30DynamicFiltersIgnoreFirst = StringUtil.StrToBool( GetPar( "DynamicFiltersIgnoreFirst"));
         AV29DynamicFiltersRemoving = StringUtil.StrToBool( GetPar( "DynamicFiltersRemoving"));
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV35ColumnsSelector, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20IteNome1, AV21DynamicFiltersEnabled2, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24IteNome2, AV25DynamicFiltersEnabled3, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28IteNome3, AV41TFIteNome, AV42TFIteNome_Sel, AV15OrderedDsc, AV11GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving, sPrefix) ;
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
            PA4Z2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               WS4Z2( ) ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("core.webfunilgridviewiteracoes.aspx") +"\">") ;
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
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vCOLUMNSSELECTOR", AV35ColumnsSelector);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vCOLUMNSSELECTOR", AV35ColumnsSelector);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCOLUMNSSELECTOR", GetSecureSignedToken( sPrefix, AV35ColumnsSelector, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vDYNAMICFILTERSIGNOREFIRST", AV30DynamicFiltersIgnoreFirst);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vDYNAMICFILTERSIGNOREFIRST", GetSecureSignedToken( sPrefix, AV30DynamicFiltersIgnoreFirst, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vDYNAMICFILTERSREMOVING", AV29DynamicFiltersRemoving);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vDYNAMICFILTERSREMOVING", GetSecureSignedToken( sPrefix, AV29DynamicFiltersRemoving, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_6", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_6), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDDO_TITLESETTINGSICONS", AV48DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDDO_TITLESETTINGSICONS", AV48DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vCOLUMNSSELECTOR", AV35ColumnsSelector);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vCOLUMNSSELECTOR", AV35ColumnsSelector);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCOLUMNSSELECTOR", GetSecureSignedToken( sPrefix, AV35ColumnsSelector, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vFILTERFULLTEXT", AV17FilterFullText);
         GxWebStd.gx_hidden_field( context, sPrefix+"vDYNAMICFILTERSSELECTOR1", AV18DynamicFiltersSelector1);
         GxWebStd.gx_hidden_field( context, sPrefix+"vDYNAMICFILTERSOPERATOR1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19DynamicFiltersOperator1), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vITENOME1", AV20IteNome1);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vDYNAMICFILTERSENABLED2", AV21DynamicFiltersEnabled2);
         GxWebStd.gx_hidden_field( context, sPrefix+"vDYNAMICFILTERSSELECTOR2", AV22DynamicFiltersSelector2);
         GxWebStd.gx_hidden_field( context, sPrefix+"vDYNAMICFILTERSOPERATOR2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV23DynamicFiltersOperator2), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vITENOME2", AV24IteNome2);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vDYNAMICFILTERSENABLED3", AV25DynamicFiltersEnabled3);
         GxWebStd.gx_hidden_field( context, sPrefix+"vDYNAMICFILTERSSELECTOR3", AV26DynamicFiltersSelector3);
         GxWebStd.gx_hidden_field( context, sPrefix+"vDYNAMICFILTERSOPERATOR3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV27DynamicFiltersOperator3), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vITENOME3", AV28IteNome3);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFITENOME", AV41TFIteNome);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFITENOME_SEL", AV42TFIteNome_Sel);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vORDEREDDSC", AV15OrderedDsc);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vGRIDSTATE", AV11GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vGRIDSTATE", AV11GridState);
         }
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vDYNAMICFILTERSIGNOREFIRST", AV30DynamicFiltersIgnoreFirst);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vDYNAMICFILTERSIGNOREFIRST", GetSecureSignedToken( sPrefix, AV30DynamicFiltersIgnoreFirst, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vDYNAMICFILTERSREMOVING", AV29DynamicFiltersRemoving);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vDYNAMICFILTERSREMOVING", GetSecureSignedToken( sPrefix, AV29DynamicFiltersRemoving, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Caption", StringUtil.RTrim( Ddo_grid_Caption));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtext_set", StringUtil.RTrim( Ddo_grid_Filteredtext_set));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_set", StringUtil.RTrim( Ddo_grid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Gamoauthtoken", StringUtil.RTrim( Ddo_grid_Gamoauthtoken));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Gridinternalname", StringUtil.RTrim( Ddo_grid_Gridinternalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Columnids", StringUtil.RTrim( Ddo_grid_Columnids));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Columnssortvalues", StringUtil.RTrim( Ddo_grid_Columnssortvalues));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Includesortasc", StringUtil.RTrim( Ddo_grid_Includesortasc));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Fixable", StringUtil.RTrim( Ddo_grid_Fixable));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Sortedstatus", StringUtil.RTrim( Ddo_grid_Sortedstatus));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Includefilter", StringUtil.RTrim( Ddo_grid_Includefilter));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filtertype", StringUtil.RTrim( Ddo_grid_Filtertype));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Includedatalist", StringUtil.RTrim( Ddo_grid_Includedatalist));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Datalisttype", StringUtil.RTrim( Ddo_grid_Datalisttype));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Datalistproc", StringUtil.RTrim( Ddo_grid_Datalistproc));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Hascolumnsselector", StringUtil.BoolToStr( Grid_empowerer_Hascolumnsselector));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
      }

      protected void RenderHtmlCloseForm4Z2( )
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
            if ( ! ( WebComp_Selectlistview_wc == null ) )
            {
               WebComp_Selectlistview_wc.componentjscripts();
            }
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
         return "core.webfunilGridViewIteracoes" ;
      }

      public override string GetPgmdesc( )
      {
         return "webfunil Grid View Iteracoes" ;
      }

      protected void WB4Z0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "core.webfunilgridviewiteracoes.aspx");
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
               context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", sPrefix, "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop SectionGrid GridNoBorderCell HasGridEmpowerer ListViewGrid", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl6( ) ;
         }
         if ( wbEnd == 6 )
         {
            wbEnd = 0;
            nRC_GXsfl_6 = (int)(nGXsfl_6_idx-1);
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
            ucDdo_grid.SetProperty("Fixable", Ddo_grid_Fixable);
            ucDdo_grid.SetProperty("IncludeFilter", Ddo_grid_Includefilter);
            ucDdo_grid.SetProperty("FilterType", Ddo_grid_Filtertype);
            ucDdo_grid.SetProperty("IncludeDataList", Ddo_grid_Includedatalist);
            ucDdo_grid.SetProperty("DataListType", Ddo_grid_Datalisttype);
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV48DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, sPrefix+"DDO_GRIDContainer");
            /* User Defined Control */
            ucInnewwindow1.Render(context, "innewwindow", Innewwindow1_Internalname, sPrefix+"INNEWWINDOW1Container");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDiv_selectlistview_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, sPrefix+"W0019"+"", StringUtil.RTrim( WebComp_Selectlistview_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+sPrefix+"gxHTMLWrpW0019"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( bGXsfl_6_Refreshing )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldSelectlistview_wc), StringUtil.Lower( WebComp_Selectlistview_wc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0019"+"");
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
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.SetProperty("HasColumnsSelector", Grid_empowerer_Hascolumnsselector);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, sPrefix+"GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDiv_wwpauxwc_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, sPrefix+"W0022"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+sPrefix+"gxHTMLWrpW0022"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( bGXsfl_6_Refreshing )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0022"+"");
                  }
                  WebComp_Wwpaux_wc.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
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
         if ( wbEnd == 6 )
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

      protected void START4Z2( )
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
               Form.Meta.addItem("description", "webfunil Grid View Iteracoes", 0) ;
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
               STRUP4Z0( ) ;
            }
         }
      }

      protected void WS4Z2( )
      {
         START4Z2( ) ;
         EVT4Z2( ) ;
      }

      protected void EVT4Z2( )
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
                                 STRUP4Z0( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4Z0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E114Z2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GLOBALEVENTS.LISTVIEW_REFRESHVIEW") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4Z0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E124Z2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4Z0( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4Z0( ) ;
                              }
                              AV61Core_webfunilds_1_filterfulltext = AV17FilterFullText;
                              AV62Core_webfunilds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
                              AV63Core_webfunilds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
                              AV64Core_webfunilds_4_itenome1 = AV20IteNome1;
                              AV65Core_webfunilds_5_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
                              AV66Core_webfunilds_6_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
                              AV67Core_webfunilds_7_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
                              AV68Core_webfunilds_8_itenome2 = AV24IteNome2;
                              AV69Core_webfunilds_9_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
                              AV70Core_webfunilds_10_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
                              AV71Core_webfunilds_11_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
                              AV72Core_webfunilds_12_itenome3 = AV28IteNome3;
                              AV73Core_webfunilds_13_tfitenome = AV41TFIteNome;
                              AV74Core_webfunilds_14_tfitenome_sel = AV42TFIteNome_Sel;
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4Z0( ) ;
                              }
                              nGXsfl_6_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_6_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_6_idx), 4, 0), 4, "0");
                              SubsflControlProps_62( ) ;
                              A381IteID = StringUtil.StrToGuid( cgiGet( edtIteID_Internalname));
                              A382IteOrdem = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtIteOrdem_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A383IteNome = StringUtil.Upper( cgiGet( edtIteNome_Internalname));
                              A384IteAtivo = StringUtil.StrToBool( cgiGet( chkIteAtivo_Internalname));
                              A432IteQtdeOportunidades = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtIteQtdeOportunidades_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A431IteTotalOportunidades = context.localUtil.CToN( cgiGet( edtIteTotalOportunidades_Internalname), ",", ".");
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
                                          /* Execute user event: Start */
                                          E134Z2 ();
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
                                          /* Execute user event: Refresh */
                                          E144Z2 ();
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
                                          E154Z2 ();
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
                                       STRUP4Z0( ) ;
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
                        if ( nCmpId == 19 )
                        {
                           OldSelectlistview_wc = cgiGet( sPrefix+"W0019");
                           if ( ( StringUtil.Len( OldSelectlistview_wc) == 0 ) || ( StringUtil.StrCmp(OldSelectlistview_wc, WebComp_Selectlistview_wc_Component) != 0 ) )
                           {
                              WebComp_Selectlistview_wc = getWebComponent(GetType(), "GeneXus.Programs", OldSelectlistview_wc, new Object[] {context} );
                              WebComp_Selectlistview_wc.ComponentInit();
                              WebComp_Selectlistview_wc.Name = "OldSelectlistview_wc";
                              WebComp_Selectlistview_wc_Component = OldSelectlistview_wc;
                           }
                           WebComp_Selectlistview_wc.componentprocess(sPrefix+"W0019", "", sEvt);
                           WebComp_Selectlistview_wc_Component = OldSelectlistview_wc;
                        }
                        else if ( nCmpId == 22 )
                        {
                           OldWwpaux_wc = cgiGet( sPrefix+"W0022");
                           if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                           {
                              WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                              WebComp_Wwpaux_wc.ComponentInit();
                              WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                              WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                           }
                           WebComp_Wwpaux_wc.componentprocess(sPrefix+"W0022", "", sEvt);
                           WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE4Z2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm4Z2( ) ;
            }
         }
      }

      protected void PA4Z2( )
      {
         if ( nDonePA == 0 )
         {
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               initialize_properties( ) ;
            }
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
               }
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
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
         SubsflControlProps_62( ) ;
         while ( nGXsfl_6_idx <= nRC_GXsfl_6 )
         {
            sendrow_62( ) ;
            nGXsfl_6_idx = ((subGrid_Islastpage==1)&&(nGXsfl_6_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_6_idx+1);
            sGXsfl_6_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_6_idx), 4, 0), 4, "0");
            SubsflControlProps_62( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV35ColumnsSelector ,
                                       string AV17FilterFullText ,
                                       string AV18DynamicFiltersSelector1 ,
                                       short AV19DynamicFiltersOperator1 ,
                                       string AV20IteNome1 ,
                                       bool AV21DynamicFiltersEnabled2 ,
                                       string AV22DynamicFiltersSelector2 ,
                                       short AV23DynamicFiltersOperator2 ,
                                       string AV24IteNome2 ,
                                       bool AV25DynamicFiltersEnabled3 ,
                                       string AV26DynamicFiltersSelector3 ,
                                       short AV27DynamicFiltersOperator3 ,
                                       string AV28IteNome3 ,
                                       string AV41TFIteNome ,
                                       string AV42TFIteNome_Sel ,
                                       bool AV15OrderedDsc ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ,
                                       bool AV30DynamicFiltersIgnoreFirst ,
                                       bool AV29DynamicFiltersRemoving ,
                                       string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF4Z2( ) ;
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
         RF4Z2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected int subGridclient_rec_count_fnc( )
      {
         AV61Core_webfunilds_1_filterfulltext = AV17FilterFullText;
         AV62Core_webfunilds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV63Core_webfunilds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV64Core_webfunilds_4_itenome1 = AV20IteNome1;
         AV65Core_webfunilds_5_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV66Core_webfunilds_6_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV67Core_webfunilds_7_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV68Core_webfunilds_8_itenome2 = AV24IteNome2;
         AV69Core_webfunilds_9_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV70Core_webfunilds_10_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV71Core_webfunilds_11_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV72Core_webfunilds_12_itenome3 = AV28IteNome3;
         AV73Core_webfunilds_13_tfitenome = AV41TFIteNome;
         AV74Core_webfunilds_14_tfitenome_sel = AV42TFIteNome_Sel;
         GRID_nRecordCount = 0;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV62Core_webfunilds_2_dynamicfiltersselector1 ,
                                              AV63Core_webfunilds_3_dynamicfiltersoperator1 ,
                                              AV64Core_webfunilds_4_itenome1 ,
                                              AV65Core_webfunilds_5_dynamicfiltersenabled2 ,
                                              AV66Core_webfunilds_6_dynamicfiltersselector2 ,
                                              AV67Core_webfunilds_7_dynamicfiltersoperator2 ,
                                              AV68Core_webfunilds_8_itenome2 ,
                                              AV69Core_webfunilds_9_dynamicfiltersenabled3 ,
                                              AV70Core_webfunilds_10_dynamicfiltersselector3 ,
                                              AV71Core_webfunilds_11_dynamicfiltersoperator3 ,
                                              AV72Core_webfunilds_12_itenome3 ,
                                              AV74Core_webfunilds_14_tfitenome_sel ,
                                              AV73Core_webfunilds_13_tfitenome ,
                                              A383IteNome ,
                                              AV15OrderedDsc ,
                                              AV61Core_webfunilds_1_filterfulltext ,
                                              A431IteTotalOportunidades ,
                                              A432IteQtdeOportunidades ,
                                              A381IteID ,
                                              A420NegUltIteID } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.INT
                                              }
         });
         lV64Core_webfunilds_4_itenome1 = StringUtil.Concat( StringUtil.RTrim( AV64Core_webfunilds_4_itenome1), "%", "");
         lV64Core_webfunilds_4_itenome1 = StringUtil.Concat( StringUtil.RTrim( AV64Core_webfunilds_4_itenome1), "%", "");
         lV68Core_webfunilds_8_itenome2 = StringUtil.Concat( StringUtil.RTrim( AV68Core_webfunilds_8_itenome2), "%", "");
         lV68Core_webfunilds_8_itenome2 = StringUtil.Concat( StringUtil.RTrim( AV68Core_webfunilds_8_itenome2), "%", "");
         lV72Core_webfunilds_12_itenome3 = StringUtil.Concat( StringUtil.RTrim( AV72Core_webfunilds_12_itenome3), "%", "");
         lV72Core_webfunilds_12_itenome3 = StringUtil.Concat( StringUtil.RTrim( AV72Core_webfunilds_12_itenome3), "%", "");
         lV73Core_webfunilds_13_tfitenome = StringUtil.Concat( StringUtil.RTrim( AV73Core_webfunilds_13_tfitenome), "%", "");
         /* Using cursor H004Z2 */
         pr_default.execute(0, new Object[] {lV64Core_webfunilds_4_itenome1, lV64Core_webfunilds_4_itenome1, lV68Core_webfunilds_8_itenome2, lV68Core_webfunilds_8_itenome2, lV72Core_webfunilds_12_itenome3, lV72Core_webfunilds_12_itenome3, lV73Core_webfunilds_13_tfitenome, AV74Core_webfunilds_14_tfitenome_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A384IteAtivo = H004Z2_A384IteAtivo[0];
            A383IteNome = H004Z2_A383IteNome[0];
            A382IteOrdem = H004Z2_A382IteOrdem[0];
            A381IteID = H004Z2_A381IteID[0];
            A432IteQtdeOportunidades = GetIteQtdeOportunidades0( A381IteID);
            A431IteTotalOportunidades = GetIteTotalOportunidades0( A381IteID);
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV61Core_webfunilds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Lower( A383IteNome) , StringUtil.PadR( "%" + StringUtil.Lower( AV61Core_webfunilds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A431IteTotalOportunidades, 16, 2) , StringUtil.PadR( "%" + AV61Core_webfunilds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A432IteQtdeOportunidades), 8, 0) , StringUtil.PadR( "%" + AV61Core_webfunilds_1_filterfulltext , 254 , "%"),  ' ' ) ) ) )
            {
               GRID_nRecordCount = (long)(GRID_nRecordCount+1);
            }
            pr_default.readNext(0);
         }
         GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         pr_default.close(0);
         return (int)(GRID_nRecordCount) ;
      }

      protected void RF4Z2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 6;
         /* Execute user event: Refresh */
         E144Z2 ();
         nGXsfl_6_idx = 1;
         sGXsfl_6_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_6_idx), 4, 0), 4, "0");
         SubsflControlProps_62( ) ;
         bGXsfl_6_Refreshing = true;
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
               WebComp_Selectlistview_wc.componentstart();
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               WebComp_Wwpaux_wc.componentstart();
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_62( ) ;
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 AV62Core_webfunilds_2_dynamicfiltersselector1 ,
                                                 AV63Core_webfunilds_3_dynamicfiltersoperator1 ,
                                                 AV64Core_webfunilds_4_itenome1 ,
                                                 AV65Core_webfunilds_5_dynamicfiltersenabled2 ,
                                                 AV66Core_webfunilds_6_dynamicfiltersselector2 ,
                                                 AV67Core_webfunilds_7_dynamicfiltersoperator2 ,
                                                 AV68Core_webfunilds_8_itenome2 ,
                                                 AV69Core_webfunilds_9_dynamicfiltersenabled3 ,
                                                 AV70Core_webfunilds_10_dynamicfiltersselector3 ,
                                                 AV71Core_webfunilds_11_dynamicfiltersoperator3 ,
                                                 AV72Core_webfunilds_12_itenome3 ,
                                                 AV74Core_webfunilds_14_tfitenome_sel ,
                                                 AV73Core_webfunilds_13_tfitenome ,
                                                 A383IteNome ,
                                                 AV15OrderedDsc ,
                                                 AV61Core_webfunilds_1_filterfulltext ,
                                                 A431IteTotalOportunidades ,
                                                 A432IteQtdeOportunidades ,
                                                 A381IteID ,
                                                 A420NegUltIteID } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.INT
                                                 }
            });
            lV64Core_webfunilds_4_itenome1 = StringUtil.Concat( StringUtil.RTrim( AV64Core_webfunilds_4_itenome1), "%", "");
            lV64Core_webfunilds_4_itenome1 = StringUtil.Concat( StringUtil.RTrim( AV64Core_webfunilds_4_itenome1), "%", "");
            lV68Core_webfunilds_8_itenome2 = StringUtil.Concat( StringUtil.RTrim( AV68Core_webfunilds_8_itenome2), "%", "");
            lV68Core_webfunilds_8_itenome2 = StringUtil.Concat( StringUtil.RTrim( AV68Core_webfunilds_8_itenome2), "%", "");
            lV72Core_webfunilds_12_itenome3 = StringUtil.Concat( StringUtil.RTrim( AV72Core_webfunilds_12_itenome3), "%", "");
            lV72Core_webfunilds_12_itenome3 = StringUtil.Concat( StringUtil.RTrim( AV72Core_webfunilds_12_itenome3), "%", "");
            lV73Core_webfunilds_13_tfitenome = StringUtil.Concat( StringUtil.RTrim( AV73Core_webfunilds_13_tfitenome), "%", "");
            /* Using cursor H004Z3 */
            pr_default.execute(1, new Object[] {lV64Core_webfunilds_4_itenome1, lV64Core_webfunilds_4_itenome1, lV68Core_webfunilds_8_itenome2, lV68Core_webfunilds_8_itenome2, lV72Core_webfunilds_12_itenome3, lV72Core_webfunilds_12_itenome3, lV73Core_webfunilds_13_tfitenome, AV74Core_webfunilds_14_tfitenome_sel});
            nGXsfl_6_idx = 1;
            sGXsfl_6_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_6_idx), 4, 0), 4, "0");
            SubsflControlProps_62( ) ;
            GRID_nEOF = 0;
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            while ( ( (pr_default.getStatus(1) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A384IteAtivo = H004Z3_A384IteAtivo[0];
               A383IteNome = H004Z3_A383IteNome[0];
               A382IteOrdem = H004Z3_A382IteOrdem[0];
               A381IteID = H004Z3_A381IteID[0];
               A432IteQtdeOportunidades = GetIteQtdeOportunidades0( A381IteID);
               A431IteTotalOportunidades = GetIteTotalOportunidades0( A381IteID);
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV61Core_webfunilds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Lower( A383IteNome) , StringUtil.PadR( "%" + StringUtil.Lower( AV61Core_webfunilds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A431IteTotalOportunidades, 16, 2) , StringUtil.PadR( "%" + AV61Core_webfunilds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A432IteQtdeOportunidades), 8, 0) , StringUtil.PadR( "%" + AV61Core_webfunilds_1_filterfulltext , 254 , "%"),  ' ' ) ) ) )
               {
                  E154Z2 ();
               }
               pr_default.readNext(1);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(1) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(1);
            wbEnd = 6;
            WB4Z0( ) ;
         }
         bGXsfl_6_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes4Z2( )
      {
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vCOLUMNSSELECTOR", AV35ColumnsSelector);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vCOLUMNSSELECTOR", AV35ColumnsSelector);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCOLUMNSSELECTOR", GetSecureSignedToken( sPrefix, AV35ColumnsSelector, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vDYNAMICFILTERSIGNOREFIRST", AV30DynamicFiltersIgnoreFirst);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vDYNAMICFILTERSIGNOREFIRST", GetSecureSignedToken( sPrefix, AV30DynamicFiltersIgnoreFirst, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vDYNAMICFILTERSREMOVING", AV29DynamicFiltersRemoving);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vDYNAMICFILTERSREMOVING", GetSecureSignedToken( sPrefix, AV29DynamicFiltersRemoving, context));
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
         return (int)(subGridclient_rec_count_fnc()) ;
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
         AV61Core_webfunilds_1_filterfulltext = AV17FilterFullText;
         AV62Core_webfunilds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV63Core_webfunilds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV64Core_webfunilds_4_itenome1 = AV20IteNome1;
         AV65Core_webfunilds_5_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV66Core_webfunilds_6_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV67Core_webfunilds_7_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV68Core_webfunilds_8_itenome2 = AV24IteNome2;
         AV69Core_webfunilds_9_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV70Core_webfunilds_10_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV71Core_webfunilds_11_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV72Core_webfunilds_12_itenome3 = AV28IteNome3;
         AV73Core_webfunilds_13_tfitenome = AV41TFIteNome;
         AV74Core_webfunilds_14_tfitenome_sel = AV42TFIteNome_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV35ColumnsSelector, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20IteNome1, AV21DynamicFiltersEnabled2, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24IteNome2, AV25DynamicFiltersEnabled3, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28IteNome3, AV41TFIteNome, AV42TFIteNome_Sel, AV15OrderedDsc, AV11GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV61Core_webfunilds_1_filterfulltext = AV17FilterFullText;
         AV62Core_webfunilds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV63Core_webfunilds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV64Core_webfunilds_4_itenome1 = AV20IteNome1;
         AV65Core_webfunilds_5_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV66Core_webfunilds_6_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV67Core_webfunilds_7_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV68Core_webfunilds_8_itenome2 = AV24IteNome2;
         AV69Core_webfunilds_9_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV70Core_webfunilds_10_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV71Core_webfunilds_11_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV72Core_webfunilds_12_itenome3 = AV28IteNome3;
         AV73Core_webfunilds_13_tfitenome = AV41TFIteNome;
         AV74Core_webfunilds_14_tfitenome_sel = AV42TFIteNome_Sel;
         if ( GRID_nEOF == 0 )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV35ColumnsSelector, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20IteNome1, AV21DynamicFiltersEnabled2, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24IteNome2, AV25DynamicFiltersEnabled3, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28IteNome3, AV41TFIteNome, AV42TFIteNome_Sel, AV15OrderedDsc, AV11GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV61Core_webfunilds_1_filterfulltext = AV17FilterFullText;
         AV62Core_webfunilds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV63Core_webfunilds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV64Core_webfunilds_4_itenome1 = AV20IteNome1;
         AV65Core_webfunilds_5_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV66Core_webfunilds_6_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV67Core_webfunilds_7_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV68Core_webfunilds_8_itenome2 = AV24IteNome2;
         AV69Core_webfunilds_9_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV70Core_webfunilds_10_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV71Core_webfunilds_11_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV72Core_webfunilds_12_itenome3 = AV28IteNome3;
         AV73Core_webfunilds_13_tfitenome = AV41TFIteNome;
         AV74Core_webfunilds_14_tfitenome_sel = AV42TFIteNome_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV35ColumnsSelector, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20IteNome1, AV21DynamicFiltersEnabled2, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24IteNome2, AV25DynamicFiltersEnabled3, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28IteNome3, AV41TFIteNome, AV42TFIteNome_Sel, AV15OrderedDsc, AV11GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV61Core_webfunilds_1_filterfulltext = AV17FilterFullText;
         AV62Core_webfunilds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV63Core_webfunilds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV64Core_webfunilds_4_itenome1 = AV20IteNome1;
         AV65Core_webfunilds_5_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV66Core_webfunilds_6_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV67Core_webfunilds_7_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV68Core_webfunilds_8_itenome2 = AV24IteNome2;
         AV69Core_webfunilds_9_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV70Core_webfunilds_10_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV71Core_webfunilds_11_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV72Core_webfunilds_12_itenome3 = AV28IteNome3;
         AV73Core_webfunilds_13_tfitenome = AV41TFIteNome;
         AV74Core_webfunilds_14_tfitenome_sel = AV42TFIteNome_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV35ColumnsSelector, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20IteNome1, AV21DynamicFiltersEnabled2, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24IteNome2, AV25DynamicFiltersEnabled3, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28IteNome3, AV41TFIteNome, AV42TFIteNome_Sel, AV15OrderedDsc, AV11GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV61Core_webfunilds_1_filterfulltext = AV17FilterFullText;
         AV62Core_webfunilds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV63Core_webfunilds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV64Core_webfunilds_4_itenome1 = AV20IteNome1;
         AV65Core_webfunilds_5_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV66Core_webfunilds_6_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV67Core_webfunilds_7_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV68Core_webfunilds_8_itenome2 = AV24IteNome2;
         AV69Core_webfunilds_9_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV70Core_webfunilds_10_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV71Core_webfunilds_11_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV72Core_webfunilds_12_itenome3 = AV28IteNome3;
         AV73Core_webfunilds_13_tfitenome = AV41TFIteNome;
         AV74Core_webfunilds_14_tfitenome_sel = AV42TFIteNome_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV35ColumnsSelector, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20IteNome1, AV21DynamicFiltersEnabled2, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24IteNome2, AV25DynamicFiltersEnabled3, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28IteNome3, AV41TFIteNome, AV42TFIteNome_Sel, AV15OrderedDsc, AV11GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP4Z0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E134Z2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vDDO_TITLESETTINGSICONS"), AV48DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_6 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_6"), ",", "."), 18, MidpointRounding.ToEven));
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nFirstRecordOnPage"), ",", "."), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nEOF"), ",", "."), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Ddo_grid_Caption = cgiGet( sPrefix+"DDO_GRID_Caption");
            Ddo_grid_Filteredtext_set = cgiGet( sPrefix+"DDO_GRID_Filteredtext_set");
            Ddo_grid_Selectedvalue_set = cgiGet( sPrefix+"DDO_GRID_Selectedvalue_set");
            Ddo_grid_Gamoauthtoken = cgiGet( sPrefix+"DDO_GRID_Gamoauthtoken");
            Ddo_grid_Gridinternalname = cgiGet( sPrefix+"DDO_GRID_Gridinternalname");
            Ddo_grid_Columnids = cgiGet( sPrefix+"DDO_GRID_Columnids");
            Ddo_grid_Columnssortvalues = cgiGet( sPrefix+"DDO_GRID_Columnssortvalues");
            Ddo_grid_Includesortasc = cgiGet( sPrefix+"DDO_GRID_Includesortasc");
            Ddo_grid_Fixable = cgiGet( sPrefix+"DDO_GRID_Fixable");
            Ddo_grid_Sortedstatus = cgiGet( sPrefix+"DDO_GRID_Sortedstatus");
            Ddo_grid_Includefilter = cgiGet( sPrefix+"DDO_GRID_Includefilter");
            Ddo_grid_Filtertype = cgiGet( sPrefix+"DDO_GRID_Filtertype");
            Ddo_grid_Includedatalist = cgiGet( sPrefix+"DDO_GRID_Includedatalist");
            Ddo_grid_Datalisttype = cgiGet( sPrefix+"DDO_GRID_Datalisttype");
            Ddo_grid_Datalistproc = cgiGet( sPrefix+"DDO_GRID_Datalistproc");
            Grid_empowerer_Gridinternalname = cgiGet( sPrefix+"GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( sPrefix+"GRID_EMPOWERER_Hastitlesettings"));
            Grid_empowerer_Hascolumnsselector = StringUtil.StrToBool( cgiGet( sPrefix+"GRID_EMPOWERER_Hascolumnsselector"));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Ddo_grid_Activeeventkey = cgiGet( sPrefix+"DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedcolumn = cgiGet( sPrefix+"DDO_GRID_Selectedcolumn");
            Ddo_grid_Filteredtext_get = cgiGet( sPrefix+"DDO_GRID_Filteredtext_get");
            Ddo_grid_Selectedvalue_get = cgiGet( sPrefix+"DDO_GRID_Selectedvalue_get");
            /* Read variables values. */
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E134Z2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E134Z2( )
      {
         /* Start Routine */
         returnInSub = false;
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, sPrefix, false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         AV49GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV50GAMErrors);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Ddo_grid_Gamoauthtoken = AV49GAMSession.gxTpr_Token;
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "GAMOAuthToken", Ddo_grid_Gamoauthtoken);
         Form.Caption = "Funil de Vendas";
         AssignProp(sPrefix, false, "FORM", "Caption", Form.Caption, true);
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV48DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV48DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
      }

      protected void E144Z2( )
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
         if ( StringUtil.StrCmp(AV37Session.Get("core.webfunilColumnsSelector"), "") != 0 )
         {
            AV33ColumnsSelectorXML = AV37Session.Get("core.webfunilColumnsSelector");
            AV35ColumnsSelector.FromXml(AV33ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S132 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         edtIteNome_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV35ColumnsSelector.gxTpr_Columns.Item(1)).gxTpr_Isvisible ? 1 : 0);
         AssignProp(sPrefix, false, edtIteNome_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtIteNome_Visible), 5, 0), !bGXsfl_6_Refreshing);
         edtIteQtdeOportunidades_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV35ColumnsSelector.gxTpr_Columns.Item(2)).gxTpr_Isvisible ? 1 : 0);
         AssignProp(sPrefix, false, edtIteQtdeOportunidades_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtIteQtdeOportunidades_Visible), 5, 0), !bGXsfl_6_Refreshing);
         edtIteTotalOportunidades_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV35ColumnsSelector.gxTpr_Columns.Item(3)).gxTpr_Isvisible ? 1 : 0);
         AssignProp(sPrefix, false, edtIteTotalOportunidades_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtIteTotalOportunidades_Visible), 5, 0), !bGXsfl_6_Refreshing);
         AV61Core_webfunilds_1_filterfulltext = AV17FilterFullText;
         AV62Core_webfunilds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV63Core_webfunilds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV64Core_webfunilds_4_itenome1 = AV20IteNome1;
         AV65Core_webfunilds_5_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV66Core_webfunilds_6_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV67Core_webfunilds_7_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV68Core_webfunilds_8_itenome2 = AV24IteNome2;
         AV69Core_webfunilds_9_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV70Core_webfunilds_10_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV71Core_webfunilds_11_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV72Core_webfunilds_12_itenome3 = AV28IteNome3;
         AV73Core_webfunilds_13_tfitenome = AV41TFIteNome;
         AV74Core_webfunilds_14_tfitenome_sel = AV42TFIteNome_Sel;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV35ColumnsSelector", AV35ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11GridState", AV11GridState);
      }

      protected void E124Z2( )
      {
         /* General\GlobalEvents_Listview_refreshview Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CLEANFILTERS' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11GridState", AV11GridState);
      }

      protected void E114Z2( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV15OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri(sPrefix, false, "AV15OrderedDsc", AV15OrderedDsc);
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S152 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            subgrid_firstpage( ) ;
         }
         else if ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#Filter#>") == 0 )
         {
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "IteNome") == 0 )
            {
               AV41TFIteNome = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV41TFIteNome", AV41TFIteNome);
               AV42TFIteNome_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV42TFIteNome_Sel", AV42TFIteNome_Sel);
            }
            subgrid_firstpage( ) ;
         }
         this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "ListView_UpdateListFilters", new Object[] {}, true);
         /*  Sending Event outputs  */
      }

      private void E154Z2( )
      {
         if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
         {
            /* Grid_Load Routine */
            returnInSub = false;
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 6;
            }
            sendrow_62( ) ;
         }
         GRID_nEOF = (short)(((GRID_nCurrentRecord<GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( )) ? 1 : 0));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_6_Refreshing )
         {
            DoAjaxLoad(6, GridRow);
         }
      }

      protected void S152( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = "-1:"+(AV15OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S132( )
      {
         /* 'INITIALIZECOLUMNSSELECTOR' Routine */
         returnInSub = false;
         AV35ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV35ColumnsSelector,  "IteNome",  "",  "Iteração",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV35ColumnsSelector,  "IteQtdeOportunidades",  "",  "Quantidade de Oportunidades",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV35ColumnsSelector,  "IteTotalOportunidades",  "",  "Total em Oportunidades",  true,  "") ;
         GXt_char2 = AV34UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "core.webfunilColumnsSelector", out  GXt_char2) ;
         AV34UserCustomValue = GXt_char2;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV34UserCustomValue)) ) )
         {
            AV36ColumnsSelectorAux.FromXml(AV34UserCustomValue, null, "", "");
            new GeneXus.Programs.wwpbaseobjects.wwp_columnselector_updatecolumns(context ).execute( ref  AV36ColumnsSelectorAux, ref  AV35ColumnsSelector) ;
         }
      }

      protected void S162( )
      {
         /* 'RESETDYNFILTERS' Routine */
         returnInSub = false;
         AV21DynamicFiltersEnabled2 = false;
         AssignAttri(sPrefix, false, "AV21DynamicFiltersEnabled2", AV21DynamicFiltersEnabled2);
         AV22DynamicFiltersSelector2 = "ITENOME";
         AssignAttri(sPrefix, false, "AV22DynamicFiltersSelector2", AV22DynamicFiltersSelector2);
         AV23DynamicFiltersOperator2 = 0;
         AssignAttri(sPrefix, false, "AV23DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         AV24IteNome2 = "";
         AssignAttri(sPrefix, false, "AV24IteNome2", AV24IteNome2);
         AV25DynamicFiltersEnabled3 = false;
         AssignAttri(sPrefix, false, "AV25DynamicFiltersEnabled3", AV25DynamicFiltersEnabled3);
         AV26DynamicFiltersSelector3 = "ITENOME";
         AssignAttri(sPrefix, false, "AV26DynamicFiltersSelector3", AV26DynamicFiltersSelector3);
         AV27DynamicFiltersOperator3 = 0;
         AssignAttri(sPrefix, false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AV28IteNome3 = "";
         AssignAttri(sPrefix, false, "AV28IteNome3", AV28IteNome3);
      }

      protected void S142( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV17FilterFullText = "";
         AssignAttri(sPrefix, false, "AV17FilterFullText", AV17FilterFullText);
         AV41TFIteNome = "";
         AssignAttri(sPrefix, false, "AV41TFIteNome", AV41TFIteNome);
         AV42TFIteNome_Sel = "";
         AssignAttri(sPrefix, false, "AV42TFIteNome_Sel", AV42TFIteNome_Sel);
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         AV18DynamicFiltersSelector1 = "ITENOME";
         AssignAttri(sPrefix, false, "AV18DynamicFiltersSelector1", AV18DynamicFiltersSelector1);
         AV19DynamicFiltersOperator1 = 0;
         AssignAttri(sPrefix, false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AV20IteNome1 = "";
         AssignAttri(sPrefix, false, "AV20IteNome1", AV20IteNome1);
         /* Execute user subroutine: 'RESETDYNFILTERS' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV11GridState.gxTpr_Dynamicfilters.Clear();
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S172 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S112( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV37Session.Get("core.webfunil"+"GridState"), "") == 0 )
         {
            AV11GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "core.webfunil"+"GridState"), null, "", "");
         }
         else
         {
            AV11GridState.FromXml(AV37Session.Get("core.webfunil"+"GridState"), null, "", "");
         }
         AV15OrderedDsc = AV11GridState.gxTpr_Ordereddsc;
         AssignAttri(sPrefix, false, "AV15OrderedDsc", AV15OrderedDsc);
         /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
         S152 ();
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
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S172 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV11GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV11GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV11GridState.gxTpr_Currentpage) ;
      }

      protected void S182( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV75GXV1 = 1;
         while ( AV75GXV1 <= AV11GridState.gxTpr_Filtervalues.Count )
         {
            AV12GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV11GridState.gxTpr_Filtervalues.Item(AV75GXV1));
            if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV17FilterFullText = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV17FilterFullText", AV17FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFITENOME") == 0 )
            {
               AV41TFIteNome = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV41TFIteNome", AV41TFIteNome);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFITENOME_SEL") == 0 )
            {
               AV42TFIteNome_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV42TFIteNome_Sel", AV42TFIteNome_Sel);
            }
            AV75GXV1 = (int)(AV75GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV42TFIteNome_Sel)),  AV42TFIteNome_Sel, out  GXt_char2) ;
         Ddo_grid_Selectedvalue_set = GXt_char2+"||";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV41TFIteNome)),  AV41TFIteNome, out  GXt_char2) ;
         Ddo_grid_Filteredtext_set = GXt_char2+"||";
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
      }

      protected void S172( )
      {
         /* 'LOADDYNFILTERSSTATE' Routine */
         returnInSub = false;
         if ( AV11GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV13GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV11GridState.gxTpr_Dynamicfilters.Item(1));
            AV18DynamicFiltersSelector1 = AV13GridStateDynamicFilter.gxTpr_Selected;
            AssignAttri(sPrefix, false, "AV18DynamicFiltersSelector1", AV18DynamicFiltersSelector1);
            if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "ITENOME") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV13GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri(sPrefix, false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
               AV20IteNome1 = AV13GridStateDynamicFilter.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV20IteNome1", AV20IteNome1);
            }
            if ( AV11GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV21DynamicFiltersEnabled2 = true;
               AssignAttri(sPrefix, false, "AV21DynamicFiltersEnabled2", AV21DynamicFiltersEnabled2);
               AV13GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV11GridState.gxTpr_Dynamicfilters.Item(2));
               AV22DynamicFiltersSelector2 = AV13GridStateDynamicFilter.gxTpr_Selected;
               AssignAttri(sPrefix, false, "AV22DynamicFiltersSelector2", AV22DynamicFiltersSelector2);
               if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "ITENOME") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV13GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri(sPrefix, false, "AV23DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
                  AV24IteNome2 = AV13GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri(sPrefix, false, "AV24IteNome2", AV24IteNome2);
               }
               if ( AV11GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV25DynamicFiltersEnabled3 = true;
                  AssignAttri(sPrefix, false, "AV25DynamicFiltersEnabled3", AV25DynamicFiltersEnabled3);
                  AV13GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV11GridState.gxTpr_Dynamicfilters.Item(3));
                  AV26DynamicFiltersSelector3 = AV13GridStateDynamicFilter.gxTpr_Selected;
                  AssignAttri(sPrefix, false, "AV26DynamicFiltersSelector3", AV26DynamicFiltersSelector3);
                  if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "ITENOME") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV13GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri(sPrefix, false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
                     AV28IteNome3 = AV13GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri(sPrefix, false, "AV28IteNome3", AV28IteNome3);
                  }
               }
            }
         }
      }

      protected void S122( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV11GridState.FromXml(AV37Session.Get("core.webfunil"+"GridState"), null, "", "");
         AV11GridState.gxTpr_Ordereddsc = AV15OrderedDsc;
         AV11GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "FILTERFULLTEXT",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV17FilterFullText)),  0,  AV17FilterFullText,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFITENOME",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV41TFIteNome)),  0,  AV41TFIteNome,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV42TFIteNome_Sel)),  AV42TFIteNome_Sel,  "") ;
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV11GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV11GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  "core.webfunil"+"GridState",  AV11GridState.ToXml(false, true, "", "")) ;
      }

      protected void S192( )
      {
         /* 'SAVEDYNFILTERSSTATE' Routine */
         returnInSub = false;
         AV11GridState.gxTpr_Dynamicfilters.Clear();
         if ( ! AV30DynamicFiltersIgnoreFirst )
         {
            AV13GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV13GridStateDynamicFilter.gxTpr_Selected = AV18DynamicFiltersSelector1;
            if ( ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "ITENOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV20IteNome1)) )
            {
               AV13GridStateDynamicFilter.gxTpr_Value = AV20IteNome1;
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
            if ( ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "ITENOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV24IteNome2)) )
            {
               AV13GridStateDynamicFilter.gxTpr_Value = AV24IteNome2;
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
            if ( ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "ITENOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV28IteNome3)) )
            {
               AV13GridStateDynamicFilter.gxTpr_Value = AV28IteNome3;
               AV13GridStateDynamicFilter.gxTpr_Operator = AV27DynamicFiltersOperator3;
            }
            if ( AV29DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV13GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV11GridState.gxTpr_Dynamicfilters.Add(AV13GridStateDynamicFilter, 0);
            }
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
         PA4Z2( ) ;
         WS4Z2( ) ;
         WE4Z2( ) ;
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
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA4Z2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "core\\webfunilgridviewiteracoes", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA4Z2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
         }
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
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
         PA4Z2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS4Z2( ) ;
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
         WS4Z2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
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
         WE4Z2( ) ;
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
         if ( ! ( WebComp_Selectlistview_wc == null ) )
         {
            WebComp_Selectlistview_wc.componentjscripts();
         }
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         if ( ! ( WebComp_Selectlistview_wc == null ) )
         {
            WebComp_Selectlistview_wc.componentthemes();
         }
         if ( ! ( WebComp_Wwpaux_wc == null ) )
         {
            WebComp_Wwpaux_wc.componentthemes();
         }
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2023828152094", true, true);
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
         context.AddJavascriptSource("core/webfunilgridviewiteracoes.js", "?2023828152097", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_62( )
      {
         edtIteID_Internalname = sPrefix+"ITEID_"+sGXsfl_6_idx;
         edtIteOrdem_Internalname = sPrefix+"ITEORDEM_"+sGXsfl_6_idx;
         edtIteNome_Internalname = sPrefix+"ITENOME_"+sGXsfl_6_idx;
         chkIteAtivo_Internalname = sPrefix+"ITEATIVO_"+sGXsfl_6_idx;
         edtIteQtdeOportunidades_Internalname = sPrefix+"ITEQTDEOPORTUNIDADES_"+sGXsfl_6_idx;
         edtIteTotalOportunidades_Internalname = sPrefix+"ITETOTALOPORTUNIDADES_"+sGXsfl_6_idx;
      }

      protected void SubsflControlProps_fel_62( )
      {
         edtIteID_Internalname = sPrefix+"ITEID_"+sGXsfl_6_fel_idx;
         edtIteOrdem_Internalname = sPrefix+"ITEORDEM_"+sGXsfl_6_fel_idx;
         edtIteNome_Internalname = sPrefix+"ITENOME_"+sGXsfl_6_fel_idx;
         chkIteAtivo_Internalname = sPrefix+"ITEATIVO_"+sGXsfl_6_fel_idx;
         edtIteQtdeOportunidades_Internalname = sPrefix+"ITEQTDEOPORTUNIDADES_"+sGXsfl_6_fel_idx;
         edtIteTotalOportunidades_Internalname = sPrefix+"ITETOTALOPORTUNIDADES_"+sGXsfl_6_fel_idx;
      }

      protected void sendrow_62( )
      {
         SubsflControlProps_62( ) ;
         WB4Z0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_6_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_6_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_6_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtIteID_Internalname,A381IteID.ToString(),A381IteID.ToString(),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtIteID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)6,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtIteOrdem_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A382IteOrdem), 8, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A382IteOrdem), "ZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtIteOrdem_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)6,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtIteNome_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtIteNome_Internalname,(string)A383IteNome,StringUtil.RTrim( context.localUtil.Format( A383IteNome, "@!")),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtIteNome_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtIteNome_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)6,(short)0,(short)-1,(short)-1,(bool)true,(string)"core\\Nome",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "ITEATIVO_" + sGXsfl_6_idx;
            chkIteAtivo.Name = GXCCtl;
            chkIteAtivo.WebTags = "";
            chkIteAtivo.Caption = "";
            AssignProp(sPrefix, false, chkIteAtivo_Internalname, "TitleCaption", chkIteAtivo.Caption, !bGXsfl_6_Refreshing);
            chkIteAtivo.CheckedValue = "false";
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkIteAtivo_Internalname,StringUtil.BoolToStr( A384IteAtivo),(string)"",(string)"",(short)0,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtIteQtdeOportunidades_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtIteQtdeOportunidades_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A432IteQtdeOportunidades), 8, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A432IteQtdeOportunidades), "ZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtIteQtdeOportunidades_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtIteQtdeOportunidades_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)6,(short)0,(short)-1,(short)0,(bool)true,(string)"core\\Quantidade",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtIteTotalOportunidades_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtIteTotalOportunidades_Internalname,StringUtil.LTrim( StringUtil.NToC( A431IteTotalOportunidades, 23, 2, ",", "")),StringUtil.LTrim( context.localUtil.Format( A431IteTotalOportunidades, "R$ Z,ZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtIteTotalOportunidades_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtIteTotalOportunidades_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)23,(short)0,(short)0,(short)6,(short)0,(short)-1,(short)0,(bool)true,(string)"core\\Monetario",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashes4Z2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_6_idx = ((subGrid_Islastpage==1)&&(nGXsfl_6_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_6_idx+1);
            sGXsfl_6_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_6_idx), 4, 0), 4, "0");
            SubsflControlProps_62( ) ;
         }
         /* End function sendrow_62 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "ITEATIVO_" + sGXsfl_6_idx;
         chkIteAtivo.Name = GXCCtl;
         chkIteAtivo.WebTags = "";
         chkIteAtivo.Caption = "";
         AssignProp(sPrefix, false, chkIteAtivo_Internalname, "TitleCaption", chkIteAtivo.Caption, !bGXsfl_6_Refreshing);
         chkIteAtivo.CheckedValue = "false";
         /* End function init_web_controls */
      }

      protected void StartGridControl6( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"DivS\" data-gxgridid=\"6\">") ;
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
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtIteNome_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Iteração") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtIteQtdeOportunidades_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Quantidade de Oportunidades") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtIteTotalOportunidades_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Total em Oportunidades") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A381IteID.ToString()));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A382IteOrdem), 8, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A383IteNome));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtIteNome_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( A384IteAtivo)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A432IteQtdeOportunidades), 8, 0, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtIteQtdeOportunidades_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A431IteTotalOportunidades, 23, 2, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtIteTotalOportunidades_Visible), 5, 0, ".", "")));
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
         edtIteID_Internalname = sPrefix+"ITEID";
         edtIteOrdem_Internalname = sPrefix+"ITEORDEM";
         edtIteNome_Internalname = sPrefix+"ITENOME";
         chkIteAtivo_Internalname = sPrefix+"ITEATIVO";
         edtIteQtdeOportunidades_Internalname = sPrefix+"ITEQTDEOPORTUNIDADES";
         edtIteTotalOportunidades_Internalname = sPrefix+"ITETOTALOPORTUNIDADES";
         Ddo_grid_Internalname = sPrefix+"DDO_GRID";
         Innewwindow1_Internalname = sPrefix+"INNEWWINDOW1";
         divDiv_selectlistview_Internalname = sPrefix+"DIV_SELECTLISTVIEW";
         Grid_empowerer_Internalname = sPrefix+"GRID_EMPOWERER";
         divDiv_wwpauxwc_Internalname = sPrefix+"DIV_WWPAUXWC";
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
         edtIteTotalOportunidades_Jsonclick = "";
         edtIteQtdeOportunidades_Jsonclick = "";
         chkIteAtivo.Caption = "";
         edtIteNome_Jsonclick = "";
         edtIteOrdem_Jsonclick = "";
         edtIteID_Jsonclick = "";
         subGrid_Class = "WorkWith";
         subGrid_Backcolorstyle = 0;
         edtIteTotalOportunidades_Visible = -1;
         edtIteQtdeOportunidades_Visible = -1;
         edtIteNome_Visible = -1;
         subGrid_Sortable = 0;
         Grid_empowerer_Hascolumnsselector = Convert.ToBoolean( -1);
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_grid_Datalistproc = "core.webfunilGetFilterData";
         Ddo_grid_Datalisttype = "Dynamic||";
         Ddo_grid_Includedatalist = "T||";
         Ddo_grid_Filtertype = "Character||";
         Ddo_grid_Includefilter = "T||";
         Ddo_grid_Fixable = "T";
         Ddo_grid_Includesortasc = "T||";
         Ddo_grid_Columnssortvalues = "-1||";
         Ddo_grid_Columnids = "2:IteNome|4:IteQtdeOportunidades|5:IteTotalOportunidades";
         Ddo_grid_Gridinternalname = "";
         Form.Caption = "webfunil Grid View Iteracoes";
         subGrid_Rows = 0;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'sPrefix'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV20IteNome1',fld:'vITENOME1',pic:'@!'},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV24IteNome2',fld:'vITENOME2',pic:'@!'},{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV28IteNome3',fld:'vITENOME3',pic:'@!'},{av:'AV41TFIteNome',fld:'vTFITENOME',pic:'@!'},{av:'AV42TFIteNome_Sel',fld:'vTFITENOME_SEL',pic:'@!'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:'',hsh:true},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',hsh:true},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:'',hsh:true},{av:'edtIteNome_Visible',ctrl:'ITENOME',prop:'Visible'},{av:'edtIteQtdeOportunidades_Visible',ctrl:'ITEQTDEOPORTUNIDADES',prop:'Visible'},{av:'edtIteTotalOportunidades_Visible',ctrl:'ITETOTALOPORTUNIDADES',prop:'Visible'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GLOBALEVENTS.LISTVIEW_REFRESHVIEW","{handler:'E124Z2',iparms:[{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV42TFIteNome_Sel',fld:'vTFITENOME_SEL',pic:'@!'},{av:'AV41TFIteNome',fld:'vTFITENOME',pic:'@!'}]");
         setEventMetadata("GLOBALEVENTS.LISTVIEW_REFRESHVIEW",",oparms:[{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV41TFIteNome',fld:'vTFITENOME',pic:'@!'},{av:'AV42TFIteNome_Sel',fld:'vTFITENOME_SEL',pic:'@!'},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV20IteNome1',fld:'vITENOME1',pic:'@!'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:'',hsh:true},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV24IteNome2',fld:'vITENOME2',pic:'@!'},{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV28IteNome3',fld:'vITENOME3',pic:'@!'},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',hsh:true},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',hsh:true},{av:'sPrefix'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","{handler:'E114Z2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:'',hsh:true},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV20IteNome1',fld:'vITENOME1',pic:'@!'},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV24IteNome2',fld:'vITENOME2',pic:'@!'},{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV28IteNome3',fld:'vITENOME3',pic:'@!'},{av:'AV41TFIteNome',fld:'vTFITENOME',pic:'@!'},{av:'AV42TFIteNome_Sel',fld:'vTFITENOME_SEL',pic:'@!'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',hsh:true},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',hsh:true},{av:'sPrefix'},{av:'Ddo_grid_Activeeventkey',ctrl:'DDO_GRID',prop:'ActiveEventKey'},{av:'Ddo_grid_Selectedcolumn',ctrl:'DDO_GRID',prop:'SelectedColumn'},{av:'Ddo_grid_Filteredtext_get',ctrl:'DDO_GRID',prop:'FilteredText_get'},{av:'Ddo_grid_Selectedvalue_get',ctrl:'DDO_GRID',prop:'SelectedValue_get'}]");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",",oparms:[{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV41TFIteNome',fld:'vTFITENOME',pic:'@!'},{av:'AV42TFIteNome_Sel',fld:'vTFITENOME_SEL',pic:'@!'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E154Z2',iparms:[]");
         setEventMetadata("GRID.LOAD",",oparms:[]}");
         setEventMetadata("GRID_FIRSTPAGE","{handler:'subgrid_firstpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'sPrefix'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:'',hsh:true},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV20IteNome1',fld:'vITENOME1',pic:'@!'},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV24IteNome2',fld:'vITENOME2',pic:'@!'},{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV28IteNome3',fld:'vITENOME3',pic:'@!'},{av:'AV41TFIteNome',fld:'vTFITENOME',pic:'@!'},{av:'AV42TFIteNome_Sel',fld:'vTFITENOME_SEL',pic:'@!'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',hsh:true},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',hsh:true}]");
         setEventMetadata("GRID_FIRSTPAGE",",oparms:[{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:'',hsh:true},{av:'edtIteNome_Visible',ctrl:'ITENOME',prop:'Visible'},{av:'edtIteQtdeOportunidades_Visible',ctrl:'ITEQTDEOPORTUNIDADES',prop:'Visible'},{av:'edtIteTotalOportunidades_Visible',ctrl:'ITETOTALOPORTUNIDADES',prop:'Visible'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRID_PREVPAGE","{handler:'subgrid_previouspage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'sPrefix'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:'',hsh:true},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV20IteNome1',fld:'vITENOME1',pic:'@!'},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV24IteNome2',fld:'vITENOME2',pic:'@!'},{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV28IteNome3',fld:'vITENOME3',pic:'@!'},{av:'AV41TFIteNome',fld:'vTFITENOME',pic:'@!'},{av:'AV42TFIteNome_Sel',fld:'vTFITENOME_SEL',pic:'@!'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',hsh:true},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',hsh:true}]");
         setEventMetadata("GRID_PREVPAGE",",oparms:[{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:'',hsh:true},{av:'edtIteNome_Visible',ctrl:'ITENOME',prop:'Visible'},{av:'edtIteQtdeOportunidades_Visible',ctrl:'ITEQTDEOPORTUNIDADES',prop:'Visible'},{av:'edtIteTotalOportunidades_Visible',ctrl:'ITETOTALOPORTUNIDADES',prop:'Visible'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRID_NEXTPAGE","{handler:'subgrid_nextpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'sPrefix'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:'',hsh:true},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV20IteNome1',fld:'vITENOME1',pic:'@!'},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV24IteNome2',fld:'vITENOME2',pic:'@!'},{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV28IteNome3',fld:'vITENOME3',pic:'@!'},{av:'AV41TFIteNome',fld:'vTFITENOME',pic:'@!'},{av:'AV42TFIteNome_Sel',fld:'vTFITENOME_SEL',pic:'@!'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',hsh:true},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',hsh:true}]");
         setEventMetadata("GRID_NEXTPAGE",",oparms:[{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:'',hsh:true},{av:'edtIteNome_Visible',ctrl:'ITENOME',prop:'Visible'},{av:'edtIteQtdeOportunidades_Visible',ctrl:'ITEQTDEOPORTUNIDADES',prop:'Visible'},{av:'edtIteTotalOportunidades_Visible',ctrl:'ITETOTALOPORTUNIDADES',prop:'Visible'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRID_LASTPAGE","{handler:'subgrid_lastpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'sPrefix'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:'',hsh:true},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV20IteNome1',fld:'vITENOME1',pic:'@!'},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV24IteNome2',fld:'vITENOME2',pic:'@!'},{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV28IteNome3',fld:'vITENOME3',pic:'@!'},{av:'AV41TFIteNome',fld:'vTFITENOME',pic:'@!'},{av:'AV42TFIteNome_Sel',fld:'vTFITENOME_SEL',pic:'@!'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:'',hsh:true},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:'',hsh:true}]");
         setEventMetadata("GRID_LASTPAGE",",oparms:[{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:'',hsh:true},{av:'edtIteNome_Visible',ctrl:'ITENOME',prop:'Visible'},{av:'edtIteQtdeOportunidades_Visible',ctrl:'ITEQTDEOPORTUNIDADES',prop:'Visible'},{av:'edtIteTotalOportunidades_Visible',ctrl:'ITETOTALOPORTUNIDADES',prop:'Visible'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("VALID_ITEID","{handler:'Valid_Iteid',iparms:[]");
         setEventMetadata("VALID_ITEID",",oparms:[]}");
         setEventMetadata("VALID_ITENOME","{handler:'Valid_Itenome',iparms:[]");
         setEventMetadata("VALID_ITENOME",",oparms:[]}");
         setEventMetadata("VALID_ITEQTDEOPORTUNIDADES","{handler:'Valid_Iteqtdeoportunidades',iparms:[]");
         setEventMetadata("VALID_ITEQTDEOPORTUNIDADES",",oparms:[]}");
         setEventMetadata("VALID_ITETOTALOPORTUNIDADES","{handler:'Valid_Itetotaloportunidades',iparms:[]");
         setEventMetadata("VALID_ITETOTALOPORTUNIDADES",",oparms:[]}");
         return  ;
      }

      protected decimal GetIteTotalOportunidades0( Guid E381IteID )
      {
         X385NegValorAtualizado = 0;
         /* Using cursor H004Z4 */
         pr_default.execute(2, new Object[] {E381IteID});
         if ( (pr_default.getStatus(2) != 101) )
         {
            X385NegValorAtualizado = H004Z4_A385NegValorAtualizado[0];
         }
         pr_default.close(2);
         return X385NegValorAtualizado ;
      }

      protected int GetIteQtdeOportunidades0( Guid E381IteID )
      {
         Gx_cnt = 0;
         /* Using cursor H004Z5 */
         pr_default.execute(3, new Object[] {E381IteID});
         if ( (pr_default.getStatus(3) != 101) )
         {
            Gx_cnt = H004Z5_Gx_cnt[0];
         }
         pr_default.close(3);
         return Gx_cnt ;
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
         Ddo_grid_Activeeventkey = "";
         Ddo_grid_Selectedcolumn = "";
         Ddo_grid_Filteredtext_get = "";
         Ddo_grid_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV35ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV17FilterFullText = "";
         AV18DynamicFiltersSelector1 = "";
         AV20IteNome1 = "";
         AV22DynamicFiltersSelector2 = "";
         AV24IteNome2 = "";
         AV26DynamicFiltersSelector3 = "";
         AV28IteNome3 = "";
         AV41TFIteNome = "";
         AV42TFIteNome_Sel = "";
         AV11GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV48DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Selectedvalue_set = "";
         Ddo_grid_Gamoauthtoken = "";
         Ddo_grid_Sortedstatus = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucDdo_grid = new GXUserControl();
         ucInnewwindow1 = new GXUserControl();
         WebComp_Selectlistview_wc_Component = "";
         OldSelectlistview_wc = "";
         ucGrid_empowerer = new GXUserControl();
         WebComp_Wwpaux_wc_Component = "";
         OldWwpaux_wc = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV61Core_webfunilds_1_filterfulltext = "";
         AV62Core_webfunilds_2_dynamicfiltersselector1 = "";
         AV64Core_webfunilds_4_itenome1 = "";
         AV66Core_webfunilds_6_dynamicfiltersselector2 = "";
         AV68Core_webfunilds_8_itenome2 = "";
         AV70Core_webfunilds_10_dynamicfiltersselector3 = "";
         AV72Core_webfunilds_12_itenome3 = "";
         AV73Core_webfunilds_13_tfitenome = "";
         AV74Core_webfunilds_14_tfitenome_sel = "";
         A381IteID = Guid.Empty;
         A383IteNome = "";
         scmdbuf = "";
         lV64Core_webfunilds_4_itenome1 = "";
         lV68Core_webfunilds_8_itenome2 = "";
         lV72Core_webfunilds_12_itenome3 = "";
         lV73Core_webfunilds_13_tfitenome = "";
         A420NegUltIteID = Guid.Empty;
         H004Z2_A384IteAtivo = new bool[] {false} ;
         H004Z2_A383IteNome = new string[] {""} ;
         H004Z2_A382IteOrdem = new int[1] ;
         H004Z2_A381IteID = new Guid[] {Guid.Empty} ;
         H004Z3_A384IteAtivo = new bool[] {false} ;
         H004Z3_A383IteNome = new string[] {""} ;
         H004Z3_A382IteOrdem = new int[1] ;
         H004Z3_A381IteID = new Guid[] {Guid.Empty} ;
         AV49GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV50GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV37Session = context.GetSession();
         AV33ColumnsSelectorXML = "";
         GridRow = new GXWebRow();
         AV34UserCustomValue = "";
         AV36ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV12GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char2 = "";
         AV13GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         ClassString = "";
         StyleString = "";
         GXCCtl = "";
         GridColumn = new GXWebColumn();
         E381IteID = Guid.Empty;
         H004Z4_A385NegValorAtualizado = new decimal[1] ;
         H004Z5_Gx_cnt = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.webfunilgridviewiteracoes__default(),
            new Object[][] {
                new Object[] {
               H004Z2_A384IteAtivo, H004Z2_A383IteNome, H004Z2_A382IteOrdem, H004Z2_A381IteID
               }
               , new Object[] {
               H004Z3_A384IteAtivo, H004Z3_A383IteNome, H004Z3_A382IteOrdem, H004Z3_A381IteID
               }
               , new Object[] {
               H004Z4_A385NegValorAtualizado
               }
               , new Object[] {
               H004Z5_Gx_cnt
               }
            }
         );
         WebComp_Selectlistview_wc = new GeneXus.Http.GXNullWebComponent();
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV19DynamicFiltersOperator1 ;
      private short AV23DynamicFiltersOperator2 ;
      private short AV27DynamicFiltersOperator3 ;
      private short initialized ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short AV63Core_webfunilds_3_dynamicfiltersoperator1 ;
      private short AV67Core_webfunilds_7_dynamicfiltersoperator2 ;
      private short AV71Core_webfunilds_11_dynamicfiltersoperator3 ;
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
      private int nRC_GXsfl_6 ;
      private int nGXsfl_6_idx=1 ;
      private int A382IteOrdem ;
      private int A432IteQtdeOportunidades ;
      private int subGrid_Islastpage ;
      private int edtIteNome_Visible ;
      private int edtIteQtdeOportunidades_Visible ;
      private int edtIteTotalOportunidades_Visible ;
      private int AV75GXV1 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private int Gx_cnt ;
      private long GRID_nFirstRecordOnPage ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private decimal A431IteTotalOportunidades ;
      private decimal X385NegValorAtualizado ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_6_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Ddo_grid_Caption ;
      private string Ddo_grid_Filteredtext_set ;
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
      private string Ddo_grid_Includedatalist ;
      private string Ddo_grid_Datalisttype ;
      private string Ddo_grid_Datalistproc ;
      private string Grid_empowerer_Gridinternalname ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Ddo_grid_Internalname ;
      private string Innewwindow1_Internalname ;
      private string divDiv_selectlistview_Internalname ;
      private string WebComp_Selectlistview_wc_Component ;
      private string OldSelectlistview_wc ;
      private string Grid_empowerer_Internalname ;
      private string divDiv_wwpauxwc_Internalname ;
      private string WebComp_Wwpaux_wc_Component ;
      private string OldWwpaux_wc ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtIteID_Internalname ;
      private string edtIteOrdem_Internalname ;
      private string edtIteNome_Internalname ;
      private string chkIteAtivo_Internalname ;
      private string edtIteQtdeOportunidades_Internalname ;
      private string edtIteTotalOportunidades_Internalname ;
      private string scmdbuf ;
      private string GXt_char2 ;
      private string sGXsfl_6_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtIteID_Jsonclick ;
      private string edtIteOrdem_Jsonclick ;
      private string edtIteNome_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string GXCCtl ;
      private string edtIteQtdeOportunidades_Jsonclick ;
      private string edtIteTotalOportunidades_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV21DynamicFiltersEnabled2 ;
      private bool AV25DynamicFiltersEnabled3 ;
      private bool AV15OrderedDsc ;
      private bool AV30DynamicFiltersIgnoreFirst ;
      private bool AV29DynamicFiltersRemoving ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool Grid_empowerer_Hascolumnsselector ;
      private bool wbLoad ;
      private bool bGXsfl_6_Refreshing=false ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool AV65Core_webfunilds_5_dynamicfiltersenabled2 ;
      private bool AV69Core_webfunilds_9_dynamicfiltersenabled3 ;
      private bool A384IteAtivo ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV33ColumnsSelectorXML ;
      private string AV34UserCustomValue ;
      private string AV17FilterFullText ;
      private string AV18DynamicFiltersSelector1 ;
      private string AV20IteNome1 ;
      private string AV22DynamicFiltersSelector2 ;
      private string AV24IteNome2 ;
      private string AV26DynamicFiltersSelector3 ;
      private string AV28IteNome3 ;
      private string AV41TFIteNome ;
      private string AV42TFIteNome_Sel ;
      private string AV61Core_webfunilds_1_filterfulltext ;
      private string AV62Core_webfunilds_2_dynamicfiltersselector1 ;
      private string AV64Core_webfunilds_4_itenome1 ;
      private string AV66Core_webfunilds_6_dynamicfiltersselector2 ;
      private string AV68Core_webfunilds_8_itenome2 ;
      private string AV70Core_webfunilds_10_dynamicfiltersselector3 ;
      private string AV72Core_webfunilds_12_itenome3 ;
      private string AV73Core_webfunilds_13_tfitenome ;
      private string AV74Core_webfunilds_14_tfitenome_sel ;
      private string A383IteNome ;
      private string lV64Core_webfunilds_4_itenome1 ;
      private string lV68Core_webfunilds_8_itenome2 ;
      private string lV72Core_webfunilds_12_itenome3 ;
      private string lV73Core_webfunilds_13_tfitenome ;
      private Guid A381IteID ;
      private Guid A420NegUltIteID ;
      private Guid E381IteID ;
      private IGxSession AV37Session ;
      private GXWebComponent WebComp_Selectlistview_wc ;
      private GXWebComponent WebComp_Wwpaux_wc ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucInnewwindow1 ;
      private GXUserControl ucGrid_empowerer ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkIteAtivo ;
      private IDataStoreProvider pr_default ;
      private bool[] H004Z2_A384IteAtivo ;
      private string[] H004Z2_A383IteNome ;
      private int[] H004Z2_A382IteOrdem ;
      private Guid[] H004Z2_A381IteID ;
      private bool[] H004Z3_A384IteAtivo ;
      private string[] H004Z3_A383IteNome ;
      private int[] H004Z3_A382IteOrdem ;
      private Guid[] H004Z3_A381IteID ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private decimal[] H004Z4_A385NegValorAtualizado ;
      private int[] H004Z5_Gx_cnt ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV50GAMErrors ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV12GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV13GridStateDynamicFilter ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV35ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV36ColumnsSelectorAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV48DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV49GAMSession ;
   }

   public class webfunilgridviewiteracoes__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H004Z2( IGxContext context ,
                                             string AV62Core_webfunilds_2_dynamicfiltersselector1 ,
                                             short AV63Core_webfunilds_3_dynamicfiltersoperator1 ,
                                             string AV64Core_webfunilds_4_itenome1 ,
                                             bool AV65Core_webfunilds_5_dynamicfiltersenabled2 ,
                                             string AV66Core_webfunilds_6_dynamicfiltersselector2 ,
                                             short AV67Core_webfunilds_7_dynamicfiltersoperator2 ,
                                             string AV68Core_webfunilds_8_itenome2 ,
                                             bool AV69Core_webfunilds_9_dynamicfiltersenabled3 ,
                                             string AV70Core_webfunilds_10_dynamicfiltersselector3 ,
                                             short AV71Core_webfunilds_11_dynamicfiltersoperator3 ,
                                             string AV72Core_webfunilds_12_itenome3 ,
                                             string AV74Core_webfunilds_14_tfitenome_sel ,
                                             string AV73Core_webfunilds_13_tfitenome ,
                                             string A383IteNome ,
                                             bool AV15OrderedDsc ,
                                             string AV61Core_webfunilds_1_filterfulltext ,
                                             decimal A431IteTotalOportunidades ,
                                             int A432IteQtdeOportunidades ,
                                             Guid A381IteID ,
                                             Guid A420NegUltIteID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[8];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT IteAtivo, IteNome, IteOrdem, IteID FROM tb_Iteracao";
         if ( ( StringUtil.StrCmp(AV62Core_webfunilds_2_dynamicfiltersselector1, "ITENOME") == 0 ) && ( AV63Core_webfunilds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Core_webfunilds_4_itenome1)) ) )
         {
            AddWhere(sWhereString, "(IteNome like :lV64Core_webfunilds_4_itenome1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV62Core_webfunilds_2_dynamicfiltersselector1, "ITENOME") == 0 ) && ( AV63Core_webfunilds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Core_webfunilds_4_itenome1)) ) )
         {
            AddWhere(sWhereString, "(IteNome like '%' || :lV64Core_webfunilds_4_itenome1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( AV65Core_webfunilds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV66Core_webfunilds_6_dynamicfiltersselector2, "ITENOME") == 0 ) && ( AV67Core_webfunilds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Core_webfunilds_8_itenome2)) ) )
         {
            AddWhere(sWhereString, "(IteNome like :lV68Core_webfunilds_8_itenome2)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( AV65Core_webfunilds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV66Core_webfunilds_6_dynamicfiltersselector2, "ITENOME") == 0 ) && ( AV67Core_webfunilds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Core_webfunilds_8_itenome2)) ) )
         {
            AddWhere(sWhereString, "(IteNome like '%' || :lV68Core_webfunilds_8_itenome2)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV69Core_webfunilds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV70Core_webfunilds_10_dynamicfiltersselector3, "ITENOME") == 0 ) && ( AV71Core_webfunilds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Core_webfunilds_12_itenome3)) ) )
         {
            AddWhere(sWhereString, "(IteNome like :lV72Core_webfunilds_12_itenome3)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV69Core_webfunilds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV70Core_webfunilds_10_dynamicfiltersselector3, "ITENOME") == 0 ) && ( AV71Core_webfunilds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Core_webfunilds_12_itenome3)) ) )
         {
            AddWhere(sWhereString, "(IteNome like '%' || :lV72Core_webfunilds_12_itenome3)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Core_webfunilds_14_tfitenome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Core_webfunilds_13_tfitenome)) ) )
         {
            AddWhere(sWhereString, "(IteNome like :lV73Core_webfunilds_13_tfitenome)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Core_webfunilds_14_tfitenome_sel)) && ! ( StringUtil.StrCmp(AV74Core_webfunilds_14_tfitenome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(IteNome = ( :AV74Core_webfunilds_14_tfitenome_sel))");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( StringUtil.StrCmp(AV74Core_webfunilds_14_tfitenome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from IteNome))=0))");
         }
         scmdbuf += sWhereString;
         if ( ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY IteOrdem";
         }
         else if ( AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY IteOrdem DESC";
         }
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_H004Z3( IGxContext context ,
                                             string AV62Core_webfunilds_2_dynamicfiltersselector1 ,
                                             short AV63Core_webfunilds_3_dynamicfiltersoperator1 ,
                                             string AV64Core_webfunilds_4_itenome1 ,
                                             bool AV65Core_webfunilds_5_dynamicfiltersenabled2 ,
                                             string AV66Core_webfunilds_6_dynamicfiltersselector2 ,
                                             short AV67Core_webfunilds_7_dynamicfiltersoperator2 ,
                                             string AV68Core_webfunilds_8_itenome2 ,
                                             bool AV69Core_webfunilds_9_dynamicfiltersenabled3 ,
                                             string AV70Core_webfunilds_10_dynamicfiltersselector3 ,
                                             short AV71Core_webfunilds_11_dynamicfiltersoperator3 ,
                                             string AV72Core_webfunilds_12_itenome3 ,
                                             string AV74Core_webfunilds_14_tfitenome_sel ,
                                             string AV73Core_webfunilds_13_tfitenome ,
                                             string A383IteNome ,
                                             bool AV15OrderedDsc ,
                                             string AV61Core_webfunilds_1_filterfulltext ,
                                             decimal A431IteTotalOportunidades ,
                                             int A432IteQtdeOportunidades ,
                                             Guid A381IteID ,
                                             Guid A420NegUltIteID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[8];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT IteAtivo, IteNome, IteOrdem, IteID FROM tb_Iteracao";
         if ( ( StringUtil.StrCmp(AV62Core_webfunilds_2_dynamicfiltersselector1, "ITENOME") == 0 ) && ( AV63Core_webfunilds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Core_webfunilds_4_itenome1)) ) )
         {
            AddWhere(sWhereString, "(IteNome like :lV64Core_webfunilds_4_itenome1)");
         }
         else
         {
            GXv_int5[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV62Core_webfunilds_2_dynamicfiltersselector1, "ITENOME") == 0 ) && ( AV63Core_webfunilds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Core_webfunilds_4_itenome1)) ) )
         {
            AddWhere(sWhereString, "(IteNome like '%' || :lV64Core_webfunilds_4_itenome1)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( AV65Core_webfunilds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV66Core_webfunilds_6_dynamicfiltersselector2, "ITENOME") == 0 ) && ( AV67Core_webfunilds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Core_webfunilds_8_itenome2)) ) )
         {
            AddWhere(sWhereString, "(IteNome like :lV68Core_webfunilds_8_itenome2)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( AV65Core_webfunilds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV66Core_webfunilds_6_dynamicfiltersselector2, "ITENOME") == 0 ) && ( AV67Core_webfunilds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Core_webfunilds_8_itenome2)) ) )
         {
            AddWhere(sWhereString, "(IteNome like '%' || :lV68Core_webfunilds_8_itenome2)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( AV69Core_webfunilds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV70Core_webfunilds_10_dynamicfiltersselector3, "ITENOME") == 0 ) && ( AV71Core_webfunilds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Core_webfunilds_12_itenome3)) ) )
         {
            AddWhere(sWhereString, "(IteNome like :lV72Core_webfunilds_12_itenome3)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( AV69Core_webfunilds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV70Core_webfunilds_10_dynamicfiltersselector3, "ITENOME") == 0 ) && ( AV71Core_webfunilds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Core_webfunilds_12_itenome3)) ) )
         {
            AddWhere(sWhereString, "(IteNome like '%' || :lV72Core_webfunilds_12_itenome3)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Core_webfunilds_14_tfitenome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Core_webfunilds_13_tfitenome)) ) )
         {
            AddWhere(sWhereString, "(IteNome like :lV73Core_webfunilds_13_tfitenome)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Core_webfunilds_14_tfitenome_sel)) && ! ( StringUtil.StrCmp(AV74Core_webfunilds_14_tfitenome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(IteNome = ( :AV74Core_webfunilds_14_tfitenome_sel))");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( StringUtil.StrCmp(AV74Core_webfunilds_14_tfitenome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from IteNome))=0))");
         }
         scmdbuf += sWhereString;
         if ( ! AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY IteOrdem";
         }
         else if ( AV15OrderedDsc )
         {
            scmdbuf += " ORDER BY IteOrdem DESC";
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
                     return conditional_H004Z2(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (string)dynConstraints[2] , (bool)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (bool)dynConstraints[14] , (string)dynConstraints[15] , (decimal)dynConstraints[16] , (int)dynConstraints[17] , (Guid)dynConstraints[18] , (Guid)dynConstraints[19] );
               case 1 :
                     return conditional_H004Z3(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (string)dynConstraints[2] , (bool)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (bool)dynConstraints[14] , (string)dynConstraints[15] , (decimal)dynConstraints[16] , (int)dynConstraints[17] , (Guid)dynConstraints[18] , (Guid)dynConstraints[19] );
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
         ,new ForEachCursor(def[3])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH004Z4;
          prmH004Z4 = new Object[] {
          new ParDef("IteID",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmH004Z5;
          prmH004Z5 = new Object[] {
          new ParDef("IteID",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmH004Z2;
          prmH004Z2 = new Object[] {
          new ParDef("lV64Core_webfunilds_4_itenome1",GXType.VarChar,80,0) ,
          new ParDef("lV64Core_webfunilds_4_itenome1",GXType.VarChar,80,0) ,
          new ParDef("lV68Core_webfunilds_8_itenome2",GXType.VarChar,80,0) ,
          new ParDef("lV68Core_webfunilds_8_itenome2",GXType.VarChar,80,0) ,
          new ParDef("lV72Core_webfunilds_12_itenome3",GXType.VarChar,80,0) ,
          new ParDef("lV72Core_webfunilds_12_itenome3",GXType.VarChar,80,0) ,
          new ParDef("lV73Core_webfunilds_13_tfitenome",GXType.VarChar,80,0) ,
          new ParDef("AV74Core_webfunilds_14_tfitenome_sel",GXType.VarChar,80,0)
          };
          Object[] prmH004Z3;
          prmH004Z3 = new Object[] {
          new ParDef("lV64Core_webfunilds_4_itenome1",GXType.VarChar,80,0) ,
          new ParDef("lV64Core_webfunilds_4_itenome1",GXType.VarChar,80,0) ,
          new ParDef("lV68Core_webfunilds_8_itenome2",GXType.VarChar,80,0) ,
          new ParDef("lV68Core_webfunilds_8_itenome2",GXType.VarChar,80,0) ,
          new ParDef("lV72Core_webfunilds_12_itenome3",GXType.VarChar,80,0) ,
          new ParDef("lV72Core_webfunilds_12_itenome3",GXType.VarChar,80,0) ,
          new ParDef("lV73Core_webfunilds_13_tfitenome",GXType.VarChar,80,0) ,
          new ParDef("AV74Core_webfunilds_14_tfitenome_sel",GXType.VarChar,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("H004Z2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004Z2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H004Z3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004Z3,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H004Z4", "SELECT SUM(NegValorAtualizado) FROM tb_negociopj WHERE NegUltIteID = :IteID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004Z4,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H004Z5", "SELECT COUNT(*) FROM tb_negociopj WHERE NegUltIteID = :IteID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004Z5,1, GxCacheFrequency.OFF ,true,true )
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
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                return;
             case 1 :
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                return;
             case 2 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
       }
    }

 }

}
