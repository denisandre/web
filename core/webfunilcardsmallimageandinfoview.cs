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
   public class webfunilcardsmallimageandinfoview : GXWebComponent
   {
      public webfunilcardsmallimageandinfoview( )
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

      public webfunilcardsmallimageandinfoview( IGxContext context )
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
         edtavDescricao_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, edtavDescricao_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDescricao_Visible), 5, 0), !bGXsfl_6_Refreshing);
         edtIteID_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, edtIteID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtIteID_Visible), 5, 0), !bGXsfl_6_Refreshing);
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
         AV17DynamicFiltersSelector1 = GetPar( "DynamicFiltersSelector1");
         AV18DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator1"), "."), 18, MidpointRounding.ToEven));
         AV19IteNome1 = GetPar( "IteNome1");
         AV20DynamicFiltersEnabled2 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled2"));
         AV21DynamicFiltersSelector2 = GetPar( "DynamicFiltersSelector2");
         AV22DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator2"), "."), 18, MidpointRounding.ToEven));
         AV23IteNome2 = GetPar( "IteNome2");
         AV24DynamicFiltersEnabled3 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled3"));
         AV25DynamicFiltersSelector3 = GetPar( "DynamicFiltersSelector3");
         AV26DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator3"), "."), 18, MidpointRounding.ToEven));
         AV27IteNome3 = GetPar( "IteNome3");
         AV37TFIteNome = GetPar( "TFIteNome");
         AV38TFIteNome_Sel = GetPar( "TFIteNome_Sel");
         edtavDescricao_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, edtavDescricao_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDescricao_Visible), 5, 0), !bGXsfl_6_Refreshing);
         edtIteID_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, edtIteID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtIteID_Visible), 5, 0), !bGXsfl_6_Refreshing);
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV16FilterFullText, AV17DynamicFiltersSelector1, AV18DynamicFiltersOperator1, AV19IteNome1, AV20DynamicFiltersEnabled2, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23IteNome2, AV24DynamicFiltersEnabled3, AV25DynamicFiltersSelector3, AV26DynamicFiltersOperator3, AV27IteNome3, AV37TFIteNome, AV38TFIteNome_Sel, sPrefix) ;
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
            PA502( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               WS502( ) ;
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
         context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true);
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("core.webfunilcardsmallimageandinfoview.aspx") +"\">") ;
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_6", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_6), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vFILTERFULLTEXT", AV16FilterFullText);
         GxWebStd.gx_hidden_field( context, sPrefix+"vDYNAMICFILTERSSELECTOR1", AV17DynamicFiltersSelector1);
         GxWebStd.gx_hidden_field( context, sPrefix+"vDYNAMICFILTERSOPERATOR1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18DynamicFiltersOperator1), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vITENOME1", AV19IteNome1);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vDYNAMICFILTERSENABLED2", AV20DynamicFiltersEnabled2);
         GxWebStd.gx_hidden_field( context, sPrefix+"vDYNAMICFILTERSSELECTOR2", AV21DynamicFiltersSelector2);
         GxWebStd.gx_hidden_field( context, sPrefix+"vDYNAMICFILTERSOPERATOR2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22DynamicFiltersOperator2), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vITENOME2", AV23IteNome2);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vDYNAMICFILTERSENABLED3", AV24DynamicFiltersEnabled3);
         GxWebStd.gx_hidden_field( context, sPrefix+"vDYNAMICFILTERSSELECTOR3", AV25DynamicFiltersSelector3);
         GxWebStd.gx_hidden_field( context, sPrefix+"vDYNAMICFILTERSOPERATOR3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26DynamicFiltersOperator3), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vITENOME3", AV27IteNome3);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFITENOME", AV37TFIteNome);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFITENOME_SEL", AV38TFIteNome_Sel);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vGRIDSTATE", AV11GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vGRIDSTATE", AV11GridState);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"ITEQTDEOPORTUNIDADES", StringUtil.LTrim( StringUtil.NToC( (decimal)(A432IteQtdeOportunidades), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDESCRICAO_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDescricao_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"ITEID_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtIteID_Visible), 5, 0, ".", "")));
      }

      protected void RenderHtmlCloseForm502( )
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
            if ( ! ( WebComp_Wcwcfuniloportunidades == null ) )
            {
               WebComp_Wcwcfuniloportunidades.componentjscripts();
            }
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
         return "core.webfunilCardSmallImageAndInfoView" ;
      }

      public override string GetPgmdesc( )
      {
         return "webfunil Card Small Image And Info View" ;
      }

      protected void WB500( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "core.webfunilcardsmallimageandinfoview.aspx");
               context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true);
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", sPrefix, "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 PaginationWithLinksCell", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetIsFreestyle(true);
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
            ucInnewwindow1.Render(context, "innewwindow", Innewwindow1_Internalname, sPrefix+"INNEWWINDOW1Container");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDiv_selectlistview_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, sPrefix+"W0046"+"", StringUtil.RTrim( WebComp_Selectlistview_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+sPrefix+"gxHTMLWrpW0046"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( bGXsfl_6_Refreshing )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldSelectlistview_wc), StringUtil.Lower( WebComp_Selectlistview_wc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0046"+"");
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
               GxWebStd.gx_hidden_field( context, sPrefix+"W0048"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+sPrefix+"gxHTMLWrpW0048"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( bGXsfl_6_Refreshing )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0048"+"");
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

      protected void START502( )
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
               Form.Meta.addItem("description", "webfunil Card Small Image And Info View", 0) ;
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
               STRUP500( ) ;
            }
         }
      }

      protected void WS502( )
      {
         START502( ) ;
         EVT502( ) ;
      }

      protected void EVT502( )
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
                                 STRUP500( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "GLOBALEVENTS.LISTVIEW_REFRESHVIEW") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP500( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E11502 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP500( ) ;
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
                                 STRUP500( ) ;
                              }
                              AV57Core_webfunilds_1_filterfulltext = AV16FilterFullText;
                              AV58Core_webfunilds_2_dynamicfiltersselector1 = AV17DynamicFiltersSelector1;
                              AV59Core_webfunilds_3_dynamicfiltersoperator1 = AV18DynamicFiltersOperator1;
                              AV60Core_webfunilds_4_itenome1 = AV19IteNome1;
                              AV61Core_webfunilds_5_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
                              AV62Core_webfunilds_6_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
                              AV63Core_webfunilds_7_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
                              AV64Core_webfunilds_8_itenome2 = AV23IteNome2;
                              AV65Core_webfunilds_9_dynamicfiltersenabled3 = AV24DynamicFiltersEnabled3;
                              AV66Core_webfunilds_10_dynamicfiltersselector3 = AV25DynamicFiltersSelector3;
                              AV67Core_webfunilds_11_dynamicfiltersoperator3 = AV26DynamicFiltersOperator3;
                              AV68Core_webfunilds_12_itenome3 = AV27IteNome3;
                              AV69Core_webfunilds_13_tfitenome = AV37TFIteNome;
                              AV70Core_webfunilds_14_tfitenome_sel = AV38TFIteNome_Sel;
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
                                 STRUP500( ) ;
                              }
                              nGXsfl_6_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_6_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_6_idx), 4, 0), 4, "0");
                              SubsflControlProps_62( ) ;
                              A383IteNome = StringUtil.Upper( cgiGet( edtIteNome_Internalname));
                              A431IteTotalOportunidades = context.localUtil.CToN( cgiGet( edtIteTotalOportunidades_Internalname), ",", ".");
                              AV30Descricao = cgiGet( edtavDescricao_Internalname);
                              AssignAttri(sPrefix, false, edtavDescricao_Internalname, AV30Descricao);
                              A381IteID = StringUtil.StrToGuid( cgiGet( edtIteID_Internalname));
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
                                          E12502 ();
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
                                          E13502 ();
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
                                          E14502 ();
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
                                       STRUP500( ) ;
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
                        if ( nCmpId == 46 )
                        {
                           OldSelectlistview_wc = cgiGet( sPrefix+"W0046");
                           if ( ( StringUtil.Len( OldSelectlistview_wc) == 0 ) || ( StringUtil.StrCmp(OldSelectlistview_wc, WebComp_Selectlistview_wc_Component) != 0 ) )
                           {
                              WebComp_Selectlistview_wc = getWebComponent(GetType(), "GeneXus.Programs", OldSelectlistview_wc, new Object[] {context} );
                              WebComp_Selectlistview_wc.ComponentInit();
                              WebComp_Selectlistview_wc.Name = "OldSelectlistview_wc";
                              WebComp_Selectlistview_wc_Component = OldSelectlistview_wc;
                           }
                           WebComp_Selectlistview_wc.componentprocess(sPrefix+"W0046", "", sEvt);
                           WebComp_Selectlistview_wc_Component = OldSelectlistview_wc;
                        }
                        else if ( nCmpId == 48 )
                        {
                           OldWwpaux_wc = cgiGet( sPrefix+"W0048");
                           if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                           {
                              WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                              WebComp_Wwpaux_wc.ComponentInit();
                              WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                              WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                           }
                           WebComp_Wwpaux_wc.componentprocess(sPrefix+"W0048", "", sEvt);
                           WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                        }
                        else if ( nCmpId == 30 )
                        {
                           sEvtType = StringUtil.Left( sEvt, 4);
                           sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           sCmpCtrl = "W0030" + sEvtType;
                           OldWcwcfuniloportunidades = cgiGet( sPrefix+sCmpCtrl);
                           if ( ( StringUtil.Len( OldWcwcfuniloportunidades) == 0 ) || ( StringUtil.StrCmp(OldWcwcfuniloportunidades, WebComp_GX_Process_Component) != 0 ) )
                           {
                              WebComp_GX_Process = getWebComponent(GetType(), "GeneXus.Programs", OldWcwcfuniloportunidades, new Object[] {context} );
                              WebComp_GX_Process.ComponentInit();
                              WebComp_GX_Process.Name = "OldWcwcfuniloportunidades";
                              WebComp_GX_Process_Component = OldWcwcfuniloportunidades;
                           }
                           if ( StringUtil.Len( WebComp_GX_Process_Component) != 0 )
                           {
                              WebComp_GX_Process.componentprocess(sPrefix+"W0030", sEvtType, sEvt);
                           }
                           nGXsfl_6_webc_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                           WebCompHandler = "Wcwcfuniloportunidades";
                           WebComp_GX_Process_Component = OldWcwcfuniloportunidades;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE502( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm502( ) ;
            }
         }
      }

      protected void PA502( )
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
                                       string AV16FilterFullText ,
                                       string AV17DynamicFiltersSelector1 ,
                                       short AV18DynamicFiltersOperator1 ,
                                       string AV19IteNome1 ,
                                       bool AV20DynamicFiltersEnabled2 ,
                                       string AV21DynamicFiltersSelector2 ,
                                       short AV22DynamicFiltersOperator2 ,
                                       string AV23IteNome2 ,
                                       bool AV24DynamicFiltersEnabled3 ,
                                       string AV25DynamicFiltersSelector3 ,
                                       short AV26DynamicFiltersOperator3 ,
                                       string AV27IteNome3 ,
                                       string AV37TFIteNome ,
                                       string AV38TFIteNome_Sel ,
                                       string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF502( ) ;
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
         RF502( ) ;
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
         AV57Core_webfunilds_1_filterfulltext = AV16FilterFullText;
         AV58Core_webfunilds_2_dynamicfiltersselector1 = AV17DynamicFiltersSelector1;
         AV59Core_webfunilds_3_dynamicfiltersoperator1 = AV18DynamicFiltersOperator1;
         AV60Core_webfunilds_4_itenome1 = AV19IteNome1;
         AV61Core_webfunilds_5_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV62Core_webfunilds_6_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV63Core_webfunilds_7_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV64Core_webfunilds_8_itenome2 = AV23IteNome2;
         AV65Core_webfunilds_9_dynamicfiltersenabled3 = AV24DynamicFiltersEnabled3;
         AV66Core_webfunilds_10_dynamicfiltersselector3 = AV25DynamicFiltersSelector3;
         AV67Core_webfunilds_11_dynamicfiltersoperator3 = AV26DynamicFiltersOperator3;
         AV68Core_webfunilds_12_itenome3 = AV27IteNome3;
         AV69Core_webfunilds_13_tfitenome = AV37TFIteNome;
         AV70Core_webfunilds_14_tfitenome_sel = AV38TFIteNome_Sel;
         GRID_nRecordCount = 0;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV58Core_webfunilds_2_dynamicfiltersselector1 ,
                                              AV59Core_webfunilds_3_dynamicfiltersoperator1 ,
                                              AV60Core_webfunilds_4_itenome1 ,
                                              AV61Core_webfunilds_5_dynamicfiltersenabled2 ,
                                              AV62Core_webfunilds_6_dynamicfiltersselector2 ,
                                              AV63Core_webfunilds_7_dynamicfiltersoperator2 ,
                                              AV64Core_webfunilds_8_itenome2 ,
                                              AV65Core_webfunilds_9_dynamicfiltersenabled3 ,
                                              AV66Core_webfunilds_10_dynamicfiltersselector3 ,
                                              AV67Core_webfunilds_11_dynamicfiltersoperator3 ,
                                              AV68Core_webfunilds_12_itenome3 ,
                                              AV70Core_webfunilds_14_tfitenome_sel ,
                                              AV69Core_webfunilds_13_tfitenome ,
                                              A383IteNome ,
                                              AV15OrderedDsc ,
                                              AV57Core_webfunilds_1_filterfulltext ,
                                              A431IteTotalOportunidades ,
                                              A432IteQtdeOportunidades ,
                                              A381IteID ,
                                              A420NegUltIteID } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.INT
                                              }
         });
         lV60Core_webfunilds_4_itenome1 = StringUtil.Concat( StringUtil.RTrim( AV60Core_webfunilds_4_itenome1), "%", "");
         lV60Core_webfunilds_4_itenome1 = StringUtil.Concat( StringUtil.RTrim( AV60Core_webfunilds_4_itenome1), "%", "");
         lV64Core_webfunilds_8_itenome2 = StringUtil.Concat( StringUtil.RTrim( AV64Core_webfunilds_8_itenome2), "%", "");
         lV64Core_webfunilds_8_itenome2 = StringUtil.Concat( StringUtil.RTrim( AV64Core_webfunilds_8_itenome2), "%", "");
         lV68Core_webfunilds_12_itenome3 = StringUtil.Concat( StringUtil.RTrim( AV68Core_webfunilds_12_itenome3), "%", "");
         lV68Core_webfunilds_12_itenome3 = StringUtil.Concat( StringUtil.RTrim( AV68Core_webfunilds_12_itenome3), "%", "");
         lV69Core_webfunilds_13_tfitenome = StringUtil.Concat( StringUtil.RTrim( AV69Core_webfunilds_13_tfitenome), "%", "");
         /* Using cursor H00502 */
         pr_default.execute(0, new Object[] {lV60Core_webfunilds_4_itenome1, lV60Core_webfunilds_4_itenome1, lV64Core_webfunilds_8_itenome2, lV64Core_webfunilds_8_itenome2, lV68Core_webfunilds_12_itenome3, lV68Core_webfunilds_12_itenome3, lV69Core_webfunilds_13_tfitenome, AV70Core_webfunilds_14_tfitenome_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A382IteOrdem = H00502_A382IteOrdem[0];
            A383IteNome = H00502_A383IteNome[0];
            A381IteID = H00502_A381IteID[0];
            A431IteTotalOportunidades = GetIteTotalOportunidades0( A381IteID);
            A432IteQtdeOportunidades = GetIteQtdeOportunidades0( A381IteID);
            AssignAttri(sPrefix, false, "A432IteQtdeOportunidades", StringUtil.LTrimStr( (decimal)(A432IteQtdeOportunidades), 8, 0));
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV57Core_webfunilds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Lower( A383IteNome) , StringUtil.PadR( "%" + StringUtil.Lower( AV57Core_webfunilds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A431IteTotalOportunidades, 16, 2) , StringUtil.PadR( "%" + AV57Core_webfunilds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A432IteQtdeOportunidades), 8, 0) , StringUtil.PadR( "%" + AV57Core_webfunilds_1_filterfulltext , 254 , "%"),  ' ' ) ) ) )
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

      protected void RF502( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 6;
         /* Execute user event: Refresh */
         E13502 ();
         nGXsfl_6_idx = 1;
         sGXsfl_6_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_6_idx), 4, 0), 4, "0");
         SubsflControlProps_62( ) ;
         bGXsfl_6_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", sPrefix);
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
         GridContainer.AddObjectProperty("Class", "FreeStyleGrid");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_GX_Process_Component) != 0 )
               {
                  WebComp_GX_Process.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wcwcfuniloportunidades_Component) != 0 )
               {
                  WebComp_Wcwcfuniloportunidades.componentstart();
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
                                                 AV58Core_webfunilds_2_dynamicfiltersselector1 ,
                                                 AV59Core_webfunilds_3_dynamicfiltersoperator1 ,
                                                 AV60Core_webfunilds_4_itenome1 ,
                                                 AV61Core_webfunilds_5_dynamicfiltersenabled2 ,
                                                 AV62Core_webfunilds_6_dynamicfiltersselector2 ,
                                                 AV63Core_webfunilds_7_dynamicfiltersoperator2 ,
                                                 AV64Core_webfunilds_8_itenome2 ,
                                                 AV65Core_webfunilds_9_dynamicfiltersenabled3 ,
                                                 AV66Core_webfunilds_10_dynamicfiltersselector3 ,
                                                 AV67Core_webfunilds_11_dynamicfiltersoperator3 ,
                                                 AV68Core_webfunilds_12_itenome3 ,
                                                 AV70Core_webfunilds_14_tfitenome_sel ,
                                                 AV69Core_webfunilds_13_tfitenome ,
                                                 A383IteNome ,
                                                 AV15OrderedDsc ,
                                                 AV57Core_webfunilds_1_filterfulltext ,
                                                 A431IteTotalOportunidades ,
                                                 A432IteQtdeOportunidades ,
                                                 A381IteID ,
                                                 A420NegUltIteID } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.INT
                                                 }
            });
            lV60Core_webfunilds_4_itenome1 = StringUtil.Concat( StringUtil.RTrim( AV60Core_webfunilds_4_itenome1), "%", "");
            lV60Core_webfunilds_4_itenome1 = StringUtil.Concat( StringUtil.RTrim( AV60Core_webfunilds_4_itenome1), "%", "");
            lV64Core_webfunilds_8_itenome2 = StringUtil.Concat( StringUtil.RTrim( AV64Core_webfunilds_8_itenome2), "%", "");
            lV64Core_webfunilds_8_itenome2 = StringUtil.Concat( StringUtil.RTrim( AV64Core_webfunilds_8_itenome2), "%", "");
            lV68Core_webfunilds_12_itenome3 = StringUtil.Concat( StringUtil.RTrim( AV68Core_webfunilds_12_itenome3), "%", "");
            lV68Core_webfunilds_12_itenome3 = StringUtil.Concat( StringUtil.RTrim( AV68Core_webfunilds_12_itenome3), "%", "");
            lV69Core_webfunilds_13_tfitenome = StringUtil.Concat( StringUtil.RTrim( AV69Core_webfunilds_13_tfitenome), "%", "");
            /* Using cursor H00503 */
            pr_default.execute(1, new Object[] {lV60Core_webfunilds_4_itenome1, lV60Core_webfunilds_4_itenome1, lV64Core_webfunilds_8_itenome2, lV64Core_webfunilds_8_itenome2, lV68Core_webfunilds_12_itenome3, lV68Core_webfunilds_12_itenome3, lV69Core_webfunilds_13_tfitenome, AV70Core_webfunilds_14_tfitenome_sel});
            nGXsfl_6_idx = 1;
            sGXsfl_6_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_6_idx), 4, 0), 4, "0");
            SubsflControlProps_62( ) ;
            GRID_nEOF = 0;
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            while ( ( (pr_default.getStatus(1) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A382IteOrdem = H00503_A382IteOrdem[0];
               A383IteNome = H00503_A383IteNome[0];
               A381IteID = H00503_A381IteID[0];
               A431IteTotalOportunidades = GetIteTotalOportunidades0( A381IteID);
               A432IteQtdeOportunidades = GetIteQtdeOportunidades0( A381IteID);
               AssignAttri(sPrefix, false, "A432IteQtdeOportunidades", StringUtil.LTrimStr( (decimal)(A432IteQtdeOportunidades), 8, 0));
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV57Core_webfunilds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Lower( A383IteNome) , StringUtil.PadR( "%" + StringUtil.Lower( AV57Core_webfunilds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A431IteTotalOportunidades, 16, 2) , StringUtil.PadR( "%" + AV57Core_webfunilds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A432IteQtdeOportunidades), 8, 0) , StringUtil.PadR( "%" + AV57Core_webfunilds_1_filterfulltext , 254 , "%"),  ' ' ) ) ) )
               {
                  E14502 ();
               }
               pr_default.readNext(1);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(1) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(1);
            wbEnd = 6;
            WB500( ) ;
         }
         bGXsfl_6_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes502( )
      {
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
            return subGrid_Rows*6 ;
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
         AV57Core_webfunilds_1_filterfulltext = AV16FilterFullText;
         AV58Core_webfunilds_2_dynamicfiltersselector1 = AV17DynamicFiltersSelector1;
         AV59Core_webfunilds_3_dynamicfiltersoperator1 = AV18DynamicFiltersOperator1;
         AV60Core_webfunilds_4_itenome1 = AV19IteNome1;
         AV61Core_webfunilds_5_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV62Core_webfunilds_6_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV63Core_webfunilds_7_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV64Core_webfunilds_8_itenome2 = AV23IteNome2;
         AV65Core_webfunilds_9_dynamicfiltersenabled3 = AV24DynamicFiltersEnabled3;
         AV66Core_webfunilds_10_dynamicfiltersselector3 = AV25DynamicFiltersSelector3;
         AV67Core_webfunilds_11_dynamicfiltersoperator3 = AV26DynamicFiltersOperator3;
         AV68Core_webfunilds_12_itenome3 = AV27IteNome3;
         AV69Core_webfunilds_13_tfitenome = AV37TFIteNome;
         AV70Core_webfunilds_14_tfitenome_sel = AV38TFIteNome_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV16FilterFullText, AV17DynamicFiltersSelector1, AV18DynamicFiltersOperator1, AV19IteNome1, AV20DynamicFiltersEnabled2, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23IteNome2, AV24DynamicFiltersEnabled3, AV25DynamicFiltersSelector3, AV26DynamicFiltersOperator3, AV27IteNome3, AV37TFIteNome, AV38TFIteNome_Sel, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV57Core_webfunilds_1_filterfulltext = AV16FilterFullText;
         AV58Core_webfunilds_2_dynamicfiltersselector1 = AV17DynamicFiltersSelector1;
         AV59Core_webfunilds_3_dynamicfiltersoperator1 = AV18DynamicFiltersOperator1;
         AV60Core_webfunilds_4_itenome1 = AV19IteNome1;
         AV61Core_webfunilds_5_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV62Core_webfunilds_6_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV63Core_webfunilds_7_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV64Core_webfunilds_8_itenome2 = AV23IteNome2;
         AV65Core_webfunilds_9_dynamicfiltersenabled3 = AV24DynamicFiltersEnabled3;
         AV66Core_webfunilds_10_dynamicfiltersselector3 = AV25DynamicFiltersSelector3;
         AV67Core_webfunilds_11_dynamicfiltersoperator3 = AV26DynamicFiltersOperator3;
         AV68Core_webfunilds_12_itenome3 = AV27IteNome3;
         AV69Core_webfunilds_13_tfitenome = AV37TFIteNome;
         AV70Core_webfunilds_14_tfitenome_sel = AV38TFIteNome_Sel;
         if ( GRID_nEOF == 0 )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV16FilterFullText, AV17DynamicFiltersSelector1, AV18DynamicFiltersOperator1, AV19IteNome1, AV20DynamicFiltersEnabled2, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23IteNome2, AV24DynamicFiltersEnabled3, AV25DynamicFiltersSelector3, AV26DynamicFiltersOperator3, AV27IteNome3, AV37TFIteNome, AV38TFIteNome_Sel, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV57Core_webfunilds_1_filterfulltext = AV16FilterFullText;
         AV58Core_webfunilds_2_dynamicfiltersselector1 = AV17DynamicFiltersSelector1;
         AV59Core_webfunilds_3_dynamicfiltersoperator1 = AV18DynamicFiltersOperator1;
         AV60Core_webfunilds_4_itenome1 = AV19IteNome1;
         AV61Core_webfunilds_5_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV62Core_webfunilds_6_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV63Core_webfunilds_7_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV64Core_webfunilds_8_itenome2 = AV23IteNome2;
         AV65Core_webfunilds_9_dynamicfiltersenabled3 = AV24DynamicFiltersEnabled3;
         AV66Core_webfunilds_10_dynamicfiltersselector3 = AV25DynamicFiltersSelector3;
         AV67Core_webfunilds_11_dynamicfiltersoperator3 = AV26DynamicFiltersOperator3;
         AV68Core_webfunilds_12_itenome3 = AV27IteNome3;
         AV69Core_webfunilds_13_tfitenome = AV37TFIteNome;
         AV70Core_webfunilds_14_tfitenome_sel = AV38TFIteNome_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV16FilterFullText, AV17DynamicFiltersSelector1, AV18DynamicFiltersOperator1, AV19IteNome1, AV20DynamicFiltersEnabled2, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23IteNome2, AV24DynamicFiltersEnabled3, AV25DynamicFiltersSelector3, AV26DynamicFiltersOperator3, AV27IteNome3, AV37TFIteNome, AV38TFIteNome_Sel, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV57Core_webfunilds_1_filterfulltext = AV16FilterFullText;
         AV58Core_webfunilds_2_dynamicfiltersselector1 = AV17DynamicFiltersSelector1;
         AV59Core_webfunilds_3_dynamicfiltersoperator1 = AV18DynamicFiltersOperator1;
         AV60Core_webfunilds_4_itenome1 = AV19IteNome1;
         AV61Core_webfunilds_5_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV62Core_webfunilds_6_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV63Core_webfunilds_7_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV64Core_webfunilds_8_itenome2 = AV23IteNome2;
         AV65Core_webfunilds_9_dynamicfiltersenabled3 = AV24DynamicFiltersEnabled3;
         AV66Core_webfunilds_10_dynamicfiltersselector3 = AV25DynamicFiltersSelector3;
         AV67Core_webfunilds_11_dynamicfiltersoperator3 = AV26DynamicFiltersOperator3;
         AV68Core_webfunilds_12_itenome3 = AV27IteNome3;
         AV69Core_webfunilds_13_tfitenome = AV37TFIteNome;
         AV70Core_webfunilds_14_tfitenome_sel = AV38TFIteNome_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV16FilterFullText, AV17DynamicFiltersSelector1, AV18DynamicFiltersOperator1, AV19IteNome1, AV20DynamicFiltersEnabled2, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23IteNome2, AV24DynamicFiltersEnabled3, AV25DynamicFiltersSelector3, AV26DynamicFiltersOperator3, AV27IteNome3, AV37TFIteNome, AV38TFIteNome_Sel, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV57Core_webfunilds_1_filterfulltext = AV16FilterFullText;
         AV58Core_webfunilds_2_dynamicfiltersselector1 = AV17DynamicFiltersSelector1;
         AV59Core_webfunilds_3_dynamicfiltersoperator1 = AV18DynamicFiltersOperator1;
         AV60Core_webfunilds_4_itenome1 = AV19IteNome1;
         AV61Core_webfunilds_5_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV62Core_webfunilds_6_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV63Core_webfunilds_7_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV64Core_webfunilds_8_itenome2 = AV23IteNome2;
         AV65Core_webfunilds_9_dynamicfiltersenabled3 = AV24DynamicFiltersEnabled3;
         AV66Core_webfunilds_10_dynamicfiltersselector3 = AV25DynamicFiltersSelector3;
         AV67Core_webfunilds_11_dynamicfiltersoperator3 = AV26DynamicFiltersOperator3;
         AV68Core_webfunilds_12_itenome3 = AV27IteNome3;
         AV69Core_webfunilds_13_tfitenome = AV37TFIteNome;
         AV70Core_webfunilds_14_tfitenome_sel = AV38TFIteNome_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV16FilterFullText, AV17DynamicFiltersSelector1, AV18DynamicFiltersOperator1, AV19IteNome1, AV20DynamicFiltersEnabled2, AV21DynamicFiltersSelector2, AV22DynamicFiltersOperator2, AV23IteNome2, AV24DynamicFiltersEnabled3, AV25DynamicFiltersSelector3, AV26DynamicFiltersOperator3, AV27IteNome3, AV37TFIteNome, AV38TFIteNome_Sel, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP500( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E12502 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_6 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_6"), ",", "."), 18, MidpointRounding.ToEven));
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nFirstRecordOnPage"), ",", "."), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nEOF"), ",", "."), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
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
         E12502 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E12502( )
      {
         /* Start Routine */
         returnInSub = false;
         divCard_tablecontent_Height = 157;
         AssignProp(sPrefix, false, divCard_tablecontent_Internalname, "Height", StringUtil.LTrimStr( (decimal)(divCard_tablecontent_Height), 9, 0), !bGXsfl_6_Refreshing);
         edtavDescricao_Visible = 0;
         AssignProp(sPrefix, false, edtavDescricao_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDescricao_Visible), 5, 0), !bGXsfl_6_Refreshing);
         edtIteID_Visible = 0;
         AssignProp(sPrefix, false, edtIteID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtIteID_Visible), 5, 0), !bGXsfl_6_Refreshing);
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         AV45GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV46GAMErrors);
         Form.Caption = "Funil de Vendas";
         AssignProp(sPrefix, false, "FORM", "Caption", Form.Caption, true);
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV44DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV44DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
      }

      protected void E13502( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         AV57Core_webfunilds_1_filterfulltext = AV16FilterFullText;
         AV58Core_webfunilds_2_dynamicfiltersselector1 = AV17DynamicFiltersSelector1;
         AV59Core_webfunilds_3_dynamicfiltersoperator1 = AV18DynamicFiltersOperator1;
         AV60Core_webfunilds_4_itenome1 = AV19IteNome1;
         AV61Core_webfunilds_5_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV62Core_webfunilds_6_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV63Core_webfunilds_7_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV64Core_webfunilds_8_itenome2 = AV23IteNome2;
         AV65Core_webfunilds_9_dynamicfiltersenabled3 = AV24DynamicFiltersEnabled3;
         AV66Core_webfunilds_10_dynamicfiltersselector3 = AV25DynamicFiltersSelector3;
         AV67Core_webfunilds_11_dynamicfiltersoperator3 = AV26DynamicFiltersOperator3;
         AV68Core_webfunilds_12_itenome3 = AV27IteNome3;
         AV69Core_webfunilds_13_tfitenome = AV37TFIteNome;
         AV70Core_webfunilds_14_tfitenome_sel = AV38TFIteNome_Sel;
      }

      protected void E11502( )
      {
         /* General\GlobalEvents_Listview_refreshview Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CLEANFILTERS' */
         S122 ();
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

      private void E14502( )
      {
         if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
         {
            /* Grid_Load Routine */
            returnInSub = false;
            /* Object Property */
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               bDynCreated_Wcwcfuniloportunidades = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcwcfuniloportunidades_Component), StringUtil.Lower( "core.wcFunilOportunidades")) != 0 )
            {
               WebComp_Wcwcfuniloportunidades = getWebComponent(GetType(), "GeneXus.Programs", "core.wcfuniloportunidades", new Object[] {context} );
               WebComp_Wcwcfuniloportunidades.ComponentInit();
               WebComp_Wcwcfuniloportunidades.Name = "core.wcFunilOportunidades";
               WebComp_Wcwcfuniloportunidades_Component = "core.wcFunilOportunidades";
            }
            if ( StringUtil.Len( WebComp_Wcwcfuniloportunidades_Component) != 0 )
            {
               WebComp_Wcwcfuniloportunidades.setjustcreated();
               WebComp_Wcwcfuniloportunidades.componentprepare(new Object[] {(string)sPrefix+"W0030",(string)sGXsfl_6_idx,(Guid)A381IteID});
               WebComp_Wcwcfuniloportunidades.componentbind(new Object[] {(string)""});
            }
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
         /*  Sending Event outputs  */
      }

      protected void S132( )
      {
         /* 'RESETDYNFILTERS' Routine */
         returnInSub = false;
         AV20DynamicFiltersEnabled2 = false;
         AssignAttri(sPrefix, false, "AV20DynamicFiltersEnabled2", AV20DynamicFiltersEnabled2);
         AV21DynamicFiltersSelector2 = "ITENOME";
         AssignAttri(sPrefix, false, "AV21DynamicFiltersSelector2", AV21DynamicFiltersSelector2);
         AV22DynamicFiltersOperator2 = 0;
         AssignAttri(sPrefix, false, "AV22DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
         AV23IteNome2 = "";
         AssignAttri(sPrefix, false, "AV23IteNome2", AV23IteNome2);
         AV24DynamicFiltersEnabled3 = false;
         AssignAttri(sPrefix, false, "AV24DynamicFiltersEnabled3", AV24DynamicFiltersEnabled3);
         AV25DynamicFiltersSelector3 = "ITENOME";
         AssignAttri(sPrefix, false, "AV25DynamicFiltersSelector3", AV25DynamicFiltersSelector3);
         AV26DynamicFiltersOperator3 = 0;
         AssignAttri(sPrefix, false, "AV26DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV26DynamicFiltersOperator3), 4, 0));
         AV27IteNome3 = "";
         AssignAttri(sPrefix, false, "AV27IteNome3", AV27IteNome3);
      }

      protected void S122( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV16FilterFullText = "";
         AssignAttri(sPrefix, false, "AV16FilterFullText", AV16FilterFullText);
         AV37TFIteNome = "";
         AssignAttri(sPrefix, false, "AV37TFIteNome", AV37TFIteNome);
         AV38TFIteNome_Sel = "";
         AssignAttri(sPrefix, false, "AV38TFIteNome_Sel", AV38TFIteNome_Sel);
         AV17DynamicFiltersSelector1 = "ITENOME";
         AssignAttri(sPrefix, false, "AV17DynamicFiltersSelector1", AV17DynamicFiltersSelector1);
         AV18DynamicFiltersOperator1 = 0;
         AssignAttri(sPrefix, false, "AV18DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV18DynamicFiltersOperator1), 4, 0));
         AV19IteNome1 = "";
         AssignAttri(sPrefix, false, "AV19IteNome1", AV19IteNome1);
         /* Execute user subroutine: 'RESETDYNFILTERS' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV11GridState.gxTpr_Dynamicfilters.Clear();
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S142 ();
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
         if ( StringUtil.StrCmp(AV33Session.Get("core.webfunil"+"GridState"), "") == 0 )
         {
            AV11GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "core.webfunil"+"GridState"), null, "", "");
         }
         else
         {
            AV11GridState.FromXml(AV33Session.Get("core.webfunil"+"GridState"), null, "", "");
         }
         AV15OrderedDsc = AV11GridState.gxTpr_Ordereddsc;
         AssignAttri(sPrefix, false, "AV15OrderedDsc", AV15OrderedDsc);
         /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S142 ();
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

      protected void S152( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV71GXV1 = 1;
         while ( AV71GXV1 <= AV11GridState.gxTpr_Filtervalues.Count )
         {
            AV12GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV11GridState.gxTpr_Filtervalues.Item(AV71GXV1));
            if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV16FilterFullText = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV16FilterFullText", AV16FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFITENOME") == 0 )
            {
               AV37TFIteNome = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV37TFIteNome", AV37TFIteNome);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFITENOME_SEL") == 0 )
            {
               AV38TFIteNome_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV38TFIteNome_Sel", AV38TFIteNome_Sel);
            }
            AV71GXV1 = (int)(AV71GXV1+1);
         }
      }

      protected void S142( )
      {
         /* 'LOADDYNFILTERSSTATE' Routine */
         returnInSub = false;
         if ( AV11GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV13GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV11GridState.gxTpr_Dynamicfilters.Item(1));
            AV17DynamicFiltersSelector1 = AV13GridStateDynamicFilter.gxTpr_Selected;
            AssignAttri(sPrefix, false, "AV17DynamicFiltersSelector1", AV17DynamicFiltersSelector1);
            if ( StringUtil.StrCmp(AV17DynamicFiltersSelector1, "ITENOME") == 0 )
            {
               AV18DynamicFiltersOperator1 = AV13GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri(sPrefix, false, "AV18DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV18DynamicFiltersOperator1), 4, 0));
               AV19IteNome1 = AV13GridStateDynamicFilter.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV19IteNome1", AV19IteNome1);
            }
            if ( AV11GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV20DynamicFiltersEnabled2 = true;
               AssignAttri(sPrefix, false, "AV20DynamicFiltersEnabled2", AV20DynamicFiltersEnabled2);
               AV13GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV11GridState.gxTpr_Dynamicfilters.Item(2));
               AV21DynamicFiltersSelector2 = AV13GridStateDynamicFilter.gxTpr_Selected;
               AssignAttri(sPrefix, false, "AV21DynamicFiltersSelector2", AV21DynamicFiltersSelector2);
               if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "ITENOME") == 0 )
               {
                  AV22DynamicFiltersOperator2 = AV13GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri(sPrefix, false, "AV22DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV22DynamicFiltersOperator2), 4, 0));
                  AV23IteNome2 = AV13GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri(sPrefix, false, "AV23IteNome2", AV23IteNome2);
               }
               if ( AV11GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV24DynamicFiltersEnabled3 = true;
                  AssignAttri(sPrefix, false, "AV24DynamicFiltersEnabled3", AV24DynamicFiltersEnabled3);
                  AV13GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV11GridState.gxTpr_Dynamicfilters.Item(3));
                  AV25DynamicFiltersSelector3 = AV13GridStateDynamicFilter.gxTpr_Selected;
                  AssignAttri(sPrefix, false, "AV25DynamicFiltersSelector3", AV25DynamicFiltersSelector3);
                  if ( StringUtil.StrCmp(AV25DynamicFiltersSelector3, "ITENOME") == 0 )
                  {
                     AV26DynamicFiltersOperator3 = AV13GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri(sPrefix, false, "AV26DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV26DynamicFiltersOperator3), 4, 0));
                     AV27IteNome3 = AV13GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri(sPrefix, false, "AV27IteNome3", AV27IteNome3);
                  }
               }
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
         PA502( ) ;
         WS502( ) ;
         WE502( ) ;
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
         PA502( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "core\\webfunilcardsmallimageandinfoview", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA502( ) ;
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
         PA502( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS502( ) ;
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
         WS502( ) ;
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
         WE502( ) ;
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
         if ( ! ( WebComp_GX_Process == null ) )
         {
            WebComp_GX_Process.componentjscripts();
         }
         if ( ! ( WebComp_Wcwcfuniloportunidades == null ) )
         {
            WebComp_Wcwcfuniloportunidades.componentjscripts();
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

      public override void componentthemes( )
      {
         define_styles( ) ;
      }

      protected void define_styles( )
      {
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         if ( ! ( WebComp_Wcwcfuniloportunidades == null ) )
         {
            if ( StringUtil.Len( WebComp_Wcwcfuniloportunidades_Component) != 0 )
            {
               WebComp_Wcwcfuniloportunidades.componentthemes();
            }
         }
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2023828145851", true, true);
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
         context.AddJavascriptSource("core/webfunilcardsmallimageandinfoview.js", "?2023828145853", false, true);
         context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_62( )
      {
         edtIteNome_Internalname = sPrefix+"ITENOME_"+sGXsfl_6_idx;
         edtIteTotalOportunidades_Internalname = sPrefix+"ITETOTALOPORTUNIDADES_"+sGXsfl_6_idx;
         edtavDescricao_Internalname = sPrefix+"vDESCRICAO_"+sGXsfl_6_idx;
         edtIteID_Internalname = sPrefix+"ITEID_"+sGXsfl_6_idx;
      }

      protected void SubsflControlProps_fel_62( )
      {
         edtIteNome_Internalname = sPrefix+"ITENOME_"+sGXsfl_6_fel_idx;
         edtIteTotalOportunidades_Internalname = sPrefix+"ITETOTALOPORTUNIDADES_"+sGXsfl_6_fel_idx;
         edtavDescricao_Internalname = sPrefix+"vDESCRICAO_"+sGXsfl_6_fel_idx;
         edtIteID_Internalname = sPrefix+"ITEID_"+sGXsfl_6_fel_idx;
      }

      protected void sendrow_62( )
      {
         SubsflControlProps_62( ) ;
         WB500( ) ;
         if ( ( subGrid_Rows * 6 == 0 ) || ( nGXsfl_6_idx <= subGrid_fnc_Recordsperpage( ) * 6 ) )
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
               subGrid_Backcolor = (int)(0xFFFFFF);
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
                  subGrid_Backcolor = (int)(0xFFFFFF);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Odd";
                  }
               }
            }
            /* Start of Columns property logic. */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr"+" class=\""+subGrid_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_6_idx+"\">") ;
            }
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divMainlayout_Internalname+"_"+sGXsfl_6_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"CellMarginTop",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divCard_tablemain_Internalname+"_"+sGXsfl_6_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"SimpleCardTable_LarguraFixa",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divCard_tablecontent_Internalname+"_"+sGXsfl_6_idx,(short)1,(short)0,(string)"px",(int)divCard_tablecontent_Height,(string)"px",(string)"Table",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Table start */
            GridRow.AddColumnProperties("table", -1, isAjaxCallMode( ), new Object[] {(string)tblCard_tabletopinfo_Internalname+"_"+sGXsfl_6_idx,(short)1,(string)"Table",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(short)2,(string)"",(string)"",(string)"",(string)"px",(string)"px",(string)""});
            GridRow.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
            GridRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divCard_tabletitle_Internalname+"_"+sGXsfl_6_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Table",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Attribute/Variable Label */
            GridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtIteNome_Internalname,(string)"Descrição",(string)"col-sm-3 SimpleCardAttributeTitleLabel",(short)0,(bool)true,(string)""});
            /* Single line edit */
            ROClassString = "SimpleCardAttributeTitle";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtIteNome_Internalname,(string)A383IteNome,StringUtil.RTrim( context.localUtil.Format( A383IteNome, "@!")),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtIteNome_Jsonclick,(short)0,(string)"SimpleCardAttributeTitle",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(short)0,(short)0,(string)"text",(string)"",(short)80,(string)"chr",(short)1,(string)"row",(short)80,(short)0,(short)0,(short)6,(short)0,(short)-1,(short)-1,(bool)true,(string)"core\\Nome",(string)"start",(bool)true,(string)""});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Attribute/Variable Label */
            GridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtIteTotalOportunidades_Internalname,(string)"Total em Oportunidades",(string)"col-sm-3 SimpleCardAttributeSubtitleLabel",(short)0,(bool)true,(string)""});
            /* Single line edit */
            ROClassString = "SimpleCardAttributeSubtitle";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtIteTotalOportunidades_Internalname,StringUtil.LTrim( StringUtil.NToC( A431IteTotalOportunidades, 23, 2, ",", "")),StringUtil.LTrim( context.localUtil.Format( A431IteTotalOportunidades, "R$ Z,ZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtIteTotalOportunidades_Jsonclick,(short)0,(string)"SimpleCardAttributeSubtitle",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(short)0,(short)0,(string)"text",(string)"",(short)23,(string)"chr",(short)1,(string)"row",(short)23,(short)0,(short)0,(short)6,(short)0,(short)-1,(short)0,(bool)true,(string)"core\\Monetario",(string)"end",(bool)false,(string)""});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            if ( GridContainer.GetWrapped() == 1 )
            {
               GridContainer.CloseTag("cell");
            }
            if ( GridContainer.GetWrapped() == 1 )
            {
               GridContainer.CloseTag("row");
            }
            if ( GridContainer.GetWrapped() == 1 )
            {
               GridContainer.CloseTag("table");
            }
            /* End of table */
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* WebComponent */
            GxWebStd.gx_hidden_field( context, sPrefix+"W0030"+sGXsfl_6_idx, StringUtil.RTrim( WebComp_Wcwcfuniloportunidades_Component));
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gxwebcomponent"+" gxwebcomponent-loading");
            context.WriteHtmlText( " id=\""+sPrefix+"gxHTMLWrpW0030"+sGXsfl_6_idx+"\""+"") ;
            context.WriteHtmlText( ">") ;
            if ( bGXsfl_6_Refreshing )
            {
               if ( StringUtil.Len( WebComp_Wcwcfuniloportunidades_Component) != 0 )
               {
                  if ( ! context.isAjaxRequest( ) || ( StringUtil.StringSearch( sPrefix+"W0030"+sGXsfl_6_idx, cgiGet( "_EventName"), 1) != 0 ) )
                  {
                     if ( 1 != 0 )
                     {
                        if ( StringUtil.Len( WebComp_Wcwcfuniloportunidades_Component) != 0 )
                        {
                           WebComp_Wcwcfuniloportunidades.componentstart();
                        }
                     }
                  }
                  if ( ! context.isAjaxRequest( ) || ( StringUtil.StrCmp(StringUtil.Lower( OldWcwcfuniloportunidades), StringUtil.Lower( WebComp_Wcwcfuniloportunidades_Component)) != 0 ) )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp(sPrefix+"gxHTMLWrpW0030"+sGXsfl_6_idx);
                  }
                  WebComp_Wcwcfuniloportunidades.componentdraw();
                  if ( ! context.isAjaxRequest( ) || ( StringUtil.StrCmp(StringUtil.Lower( OldWcwcfuniloportunidades), StringUtil.Lower( WebComp_Wcwcfuniloportunidades_Component)) != 0 ) )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
            }
            context.WriteHtmlText( "</div>") ;
            WebComp_Wcwcfuniloportunidades_Component = "";
            WebComp_Wcwcfuniloportunidades.componentjscripts();
            GridRow.AddColumnProperties("webcomp", -1, isAjaxCallMode( ), new Object[] {(string)"Wcwcfuniloportunidades"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 Invisible",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Table start */
            GridRow.AddColumnProperties("table", -1, isAjaxCallMode( ), new Object[] {(string)tblUnnamedtablecontentfscardsmallimageandinfoview_Internalname+"_"+sGXsfl_6_idx,(short)1,(string)"Table",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(short)2,(string)"",(string)"",(string)"",(string)"px",(string)"px",(string)""});
            GridRow.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
            GridRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            /* Attribute/Variable Label */
            GridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavDescricao_Internalname,(string)"Descricao",(string)"gx-form-item AttributeLabel",(short)0,(bool)true,(string)"width: 25%;"});
            /* Multiple line edit */
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GridRow.AddColumnProperties("html_textarea", 1, isAjaxCallMode( ), new Object[] {(string)edtavDescricao_Internalname,(string)AV30Descricao,(string)"",(string)"",(short)0,(int)edtavDescricao_Visible,(short)0,(short)0,(short)80,(string)"chr",(short)10,(string)"row",(short)0,(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"2097152",(short)-1,(short)0,(string)"",(string)"",(short)-1,(bool)true,(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(short)0,(string)""});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            if ( GridContainer.GetWrapped() == 1 )
            {
               GridContainer.CloseTag("cell");
            }
            sendrow_6230( ) ;
         }
      }

      protected void sendrow_6230( )
      {
         GridRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* Div Control */
         GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         GridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtIteID_Internalname,(string)"Iteracao ID",(string)"gx-form-item AttributeLabel",(short)0,(bool)true,(string)"width: 25%;"});
         /* Single line edit */
         ROClassString = "Attribute";
         GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtIteID_Internalname,A381IteID.ToString(),A381IteID.ToString(),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtIteID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(int)edtIteID_Visible,(short)0,(short)0,(string)"text",(string)"",(short)36,(string)"chr",(short)1,(string)"row",(short)36,(short)0,(short)0,(short)6,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
         GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         if ( GridContainer.GetWrapped() == 1 )
         {
            GridContainer.CloseTag("cell");
         }
         if ( GridContainer.GetWrapped() == 1 )
         {
            GridContainer.CloseTag("row");
         }
         if ( GridContainer.GetWrapped() == 1 )
         {
            GridContainer.CloseTag("table");
         }
         /* End of table */
         GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         send_integrity_lvl_hashes502( ) ;
         /* End of Columns property logic. */
         GridContainer.AddRow(GridRow);
         nGXsfl_6_idx = ((subGrid_Islastpage==1)&&(nGXsfl_6_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_6_idx+1);
         sGXsfl_6_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_6_idx), 4, 0), 4, "0");
         SubsflControlProps_62( ) ;
         /* End function sendrow_62 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl6( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"DivS\" data-gxgridid=\"6\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid_Internalname, subGrid_Internalname, "", "FreeStyleGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
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
            GridContainer.SetIsFreestyle(true);
            GridContainer.SetWrapped(nGXWrapped);
            GridContainer.AddObjectProperty("GridName", "Grid");
            GridContainer.AddObjectProperty("Header", subGrid_Header);
            GridContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
            GridContainer.AddObjectProperty("Class", "FreeStyleGrid");
            GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("CmpContext", sPrefix);
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A383IteNome));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A431IteTotalOportunidades, 23, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV30Descricao));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDescricao_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A381IteID.ToString()));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtIteID_Visible), 5, 0, ".", "")));
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
         edtIteNome_Internalname = sPrefix+"ITENOME";
         edtIteTotalOportunidades_Internalname = sPrefix+"ITETOTALOPORTUNIDADES";
         divCard_tabletitle_Internalname = sPrefix+"CARD_TABLETITLE";
         tblCard_tabletopinfo_Internalname = sPrefix+"CARD_TABLETOPINFO";
         divCard_tablecontent_Internalname = sPrefix+"CARD_TABLECONTENT";
         divCard_tablemain_Internalname = sPrefix+"CARD_TABLEMAIN";
         edtavDescricao_Internalname = sPrefix+"vDESCRICAO";
         edtIteID_Internalname = sPrefix+"ITEID";
         tblUnnamedtablecontentfscardsmallimageandinfoview_Internalname = sPrefix+"UNNAMEDTABLECONTENTFSCARDSMALLIMAGEANDINFOVIEW";
         divMainlayout_Internalname = sPrefix+"MAINLAYOUT";
         Innewwindow1_Internalname = sPrefix+"INNEWWINDOW1";
         divDiv_selectlistview_Internalname = sPrefix+"DIV_SELECTLISTVIEW";
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
         edtIteID_Jsonclick = "";
         edtIteTotalOportunidades_Jsonclick = "";
         edtIteNome_Jsonclick = "";
         divCard_tablecontent_Height = 0;
         subGrid_Class = "FreeStyleGrid";
         subGrid_Backcolorstyle = 0;
         Form.Caption = "webfunil Card Small Image And Info View";
         edtIteID_Visible = 1;
         edtavDescricao_Visible = 1;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'edtavDescricao_Visible',ctrl:'vDESCRICAO',prop:'Visible'},{av:'edtIteID_Visible',ctrl:'ITEID',prop:'Visible'},{av:'sPrefix'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV17DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'AV18DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV19IteNome1',fld:'vITENOME1',pic:'@!'},{av:'AV20DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV21DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'AV22DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV23IteNome2',fld:'vITENOME2',pic:'@!'},{av:'AV24DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV25DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'AV26DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV27IteNome3',fld:'vITENOME3',pic:'@!'},{av:'AV37TFIteNome',fld:'vTFITENOME',pic:'@!'},{av:'AV38TFIteNome_Sel',fld:'vTFITENOME_SEL',pic:'@!'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("GLOBALEVENTS.LISTVIEW_REFRESHVIEW","{handler:'E11502',iparms:[{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]");
         setEventMetadata("GLOBALEVENTS.LISTVIEW_REFRESHVIEW",",oparms:[{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV37TFIteNome',fld:'vTFITENOME',pic:'@!'},{av:'AV38TFIteNome_Sel',fld:'vTFITENOME_SEL',pic:'@!'},{av:'AV17DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'AV18DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV19IteNome1',fld:'vITENOME1',pic:'@!'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV20DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV21DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'AV22DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV23IteNome2',fld:'vITENOME2',pic:'@!'},{av:'AV24DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV25DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'AV26DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV27IteNome3',fld:'vITENOME3',pic:'@!'},{av:'edtavDescricao_Visible',ctrl:'vDESCRICAO',prop:'Visible'},{av:'edtIteID_Visible',ctrl:'ITEID',prop:'Visible'},{av:'sPrefix'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E14502',iparms:[{av:'A381IteID',fld:'ITEID',pic:''}]");
         setEventMetadata("GRID.LOAD",",oparms:[{ctrl:'WCWCFUNILOPORTUNIDADES'}]}");
         setEventMetadata("GRID_FIRSTPAGE","{handler:'subgrid_firstpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'edtavDescricao_Visible',ctrl:'vDESCRICAO',prop:'Visible'},{av:'edtIteID_Visible',ctrl:'ITEID',prop:'Visible'},{av:'sPrefix'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV17DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'AV18DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV19IteNome1',fld:'vITENOME1',pic:'@!'},{av:'AV20DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV21DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'AV22DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV23IteNome2',fld:'vITENOME2',pic:'@!'},{av:'AV24DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV25DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'AV26DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV27IteNome3',fld:'vITENOME3',pic:'@!'},{av:'AV37TFIteNome',fld:'vTFITENOME',pic:'@!'},{av:'AV38TFIteNome_Sel',fld:'vTFITENOME_SEL',pic:'@!'}]");
         setEventMetadata("GRID_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID_PREVPAGE","{handler:'subgrid_previouspage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'edtavDescricao_Visible',ctrl:'vDESCRICAO',prop:'Visible'},{av:'edtIteID_Visible',ctrl:'ITEID',prop:'Visible'},{av:'sPrefix'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV17DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'AV18DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV19IteNome1',fld:'vITENOME1',pic:'@!'},{av:'AV20DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV21DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'AV22DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV23IteNome2',fld:'vITENOME2',pic:'@!'},{av:'AV24DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV25DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'AV26DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV27IteNome3',fld:'vITENOME3',pic:'@!'},{av:'AV37TFIteNome',fld:'vTFITENOME',pic:'@!'},{av:'AV38TFIteNome_Sel',fld:'vTFITENOME_SEL',pic:'@!'}]");
         setEventMetadata("GRID_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID_NEXTPAGE","{handler:'subgrid_nextpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'edtavDescricao_Visible',ctrl:'vDESCRICAO',prop:'Visible'},{av:'edtIteID_Visible',ctrl:'ITEID',prop:'Visible'},{av:'sPrefix'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV17DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'AV18DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV19IteNome1',fld:'vITENOME1',pic:'@!'},{av:'AV20DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV21DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'AV22DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV23IteNome2',fld:'vITENOME2',pic:'@!'},{av:'AV24DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV25DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'AV26DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV27IteNome3',fld:'vITENOME3',pic:'@!'},{av:'AV37TFIteNome',fld:'vTFITENOME',pic:'@!'},{av:'AV38TFIteNome_Sel',fld:'vTFITENOME_SEL',pic:'@!'}]");
         setEventMetadata("GRID_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID_LASTPAGE","{handler:'subgrid_lastpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'edtavDescricao_Visible',ctrl:'vDESCRICAO',prop:'Visible'},{av:'edtIteID_Visible',ctrl:'ITEID',prop:'Visible'},{av:'sPrefix'},{av:'AV16FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV17DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'AV18DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV19IteNome1',fld:'vITENOME1',pic:'@!'},{av:'AV20DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV21DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'AV22DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV23IteNome2',fld:'vITENOME2',pic:'@!'},{av:'AV24DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV25DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'AV26DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV27IteNome3',fld:'vITENOME3',pic:'@!'},{av:'AV37TFIteNome',fld:'vTFITENOME',pic:'@!'},{av:'AV38TFIteNome_Sel',fld:'vTFITENOME_SEL',pic:'@!'}]");
         setEventMetadata("GRID_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALID_ITENOME","{handler:'Valid_Itenome',iparms:[]");
         setEventMetadata("VALID_ITENOME",",oparms:[]}");
         setEventMetadata("VALID_ITETOTALOPORTUNIDADES","{handler:'Valid_Itetotaloportunidades',iparms:[]");
         setEventMetadata("VALID_ITETOTALOPORTUNIDADES",",oparms:[]}");
         setEventMetadata("VALID_ITEID","{handler:'Valid_Iteid',iparms:[]");
         setEventMetadata("VALID_ITEID",",oparms:[]}");
         return  ;
      }

      protected int GetIteQtdeOportunidades0( Guid E381IteID )
      {
         Gx_cnt = 0;
         /* Using cursor H00504 */
         pr_default.execute(2, new Object[] {E381IteID});
         if ( (pr_default.getStatus(2) != 101) )
         {
            Gx_cnt = H00504_Gx_cnt[0];
         }
         pr_default.close(2);
         return Gx_cnt ;
      }

      protected decimal GetIteTotalOportunidades0( Guid E381IteID )
      {
         X385NegValorAtualizado = 0;
         /* Using cursor H00505 */
         pr_default.execute(3, new Object[] {E381IteID});
         if ( (pr_default.getStatus(3) != 101) )
         {
            X385NegValorAtualizado = H00505_A385NegValorAtualizado[0];
         }
         pr_default.close(3);
         return X385NegValorAtualizado ;
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
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV16FilterFullText = "";
         AV17DynamicFiltersSelector1 = "";
         AV19IteNome1 = "";
         AV21DynamicFiltersSelector2 = "";
         AV23IteNome2 = "";
         AV25DynamicFiltersSelector3 = "";
         AV27IteNome3 = "";
         AV37TFIteNome = "";
         AV38TFIteNome_Sel = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV11GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         GX_FocusControl = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucInnewwindow1 = new GXUserControl();
         WebComp_Selectlistview_wc_Component = "";
         OldSelectlistview_wc = "";
         WebComp_Wwpaux_wc_Component = "";
         OldWwpaux_wc = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV57Core_webfunilds_1_filterfulltext = "";
         AV58Core_webfunilds_2_dynamicfiltersselector1 = "";
         AV60Core_webfunilds_4_itenome1 = "";
         AV62Core_webfunilds_6_dynamicfiltersselector2 = "";
         AV64Core_webfunilds_8_itenome2 = "";
         AV66Core_webfunilds_10_dynamicfiltersselector3 = "";
         AV68Core_webfunilds_12_itenome3 = "";
         AV69Core_webfunilds_13_tfitenome = "";
         AV70Core_webfunilds_14_tfitenome_sel = "";
         A383IteNome = "";
         AV30Descricao = "";
         A381IteID = Guid.Empty;
         OldWcwcfuniloportunidades = "";
         sCmpCtrl = "";
         WebComp_GX_Process_Component = "";
         scmdbuf = "";
         lV60Core_webfunilds_4_itenome1 = "";
         lV64Core_webfunilds_8_itenome2 = "";
         lV68Core_webfunilds_12_itenome3 = "";
         lV69Core_webfunilds_13_tfitenome = "";
         A420NegUltIteID = Guid.Empty;
         H00502_A382IteOrdem = new int[1] ;
         H00502_A383IteNome = new string[] {""} ;
         H00502_A381IteID = new Guid[] {Guid.Empty} ;
         WebComp_Wcwcfuniloportunidades_Component = "";
         H00503_A382IteOrdem = new int[1] ;
         H00503_A383IteNome = new string[] {""} ;
         H00503_A381IteID = new Guid[] {Guid.Empty} ;
         AV45GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV46GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV44DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GridRow = new GXWebRow();
         AV33Session = context.GetSession();
         AV12GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV13GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         ClassString = "";
         StyleString = "";
         subGrid_Header = "";
         GridColumn = new GXWebColumn();
         E381IteID = Guid.Empty;
         H00504_Gx_cnt = new int[1] ;
         H00505_A385NegValorAtualizado = new decimal[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.webfunilcardsmallimageandinfoview__default(),
            new Object[][] {
                new Object[] {
               H00502_A382IteOrdem, H00502_A383IteNome, H00502_A381IteID
               }
               , new Object[] {
               H00503_A382IteOrdem, H00503_A383IteNome, H00503_A381IteID
               }
               , new Object[] {
               H00504_Gx_cnt
               }
               , new Object[] {
               H00505_A385NegValorAtualizado
               }
            }
         );
         WebComp_GX_Process = new GeneXus.Http.GXNullWebComponent();
         WebComp_Wcwcfuniloportunidades = new GeneXus.Http.GXNullWebComponent();
         WebComp_Selectlistview_wc = new GeneXus.Http.GXNullWebComponent();
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV18DynamicFiltersOperator1 ;
      private short AV22DynamicFiltersOperator2 ;
      private short AV26DynamicFiltersOperator3 ;
      private short initialized ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short AV59Core_webfunilds_3_dynamicfiltersoperator1 ;
      private short AV63Core_webfunilds_7_dynamicfiltersoperator2 ;
      private short AV67Core_webfunilds_11_dynamicfiltersoperator3 ;
      private short nCmpId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid_Backcolorstyle ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int edtavDescricao_Visible ;
      private int edtIteID_Visible ;
      private int nRC_GXsfl_6 ;
      private int subGrid_Rows ;
      private int nGXsfl_6_idx=1 ;
      private int A432IteQtdeOportunidades ;
      private int nGXsfl_6_webc_idx=0 ;
      private int subGrid_Islastpage ;
      private int A382IteOrdem ;
      private int divCard_tablecontent_Height ;
      private int AV71GXV1 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private int Gx_cnt ;
      private long GRID_nFirstRecordOnPage ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private decimal A431IteTotalOportunidades ;
      private decimal X385NegValorAtualizado ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_6_idx="0001" ;
      private string edtavDescricao_Internalname ;
      private string edtIteID_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Innewwindow1_Internalname ;
      private string divDiv_selectlistview_Internalname ;
      private string WebComp_Selectlistview_wc_Component ;
      private string OldSelectlistview_wc ;
      private string divDiv_wwpauxwc_Internalname ;
      private string WebComp_Wwpaux_wc_Component ;
      private string OldWwpaux_wc ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtIteNome_Internalname ;
      private string edtIteTotalOportunidades_Internalname ;
      private string OldWcwcfuniloportunidades ;
      private string sCmpCtrl ;
      private string WebComp_GX_Process_Component ;
      private string WebCompHandler="" ;
      private string scmdbuf ;
      private string WebComp_Wcwcfuniloportunidades_Component ;
      private string divCard_tablecontent_Internalname ;
      private string sGXsfl_6_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string divMainlayout_Internalname ;
      private string divCard_tablemain_Internalname ;
      private string tblCard_tabletopinfo_Internalname ;
      private string divCard_tabletitle_Internalname ;
      private string ROClassString ;
      private string edtIteNome_Jsonclick ;
      private string edtIteTotalOportunidades_Jsonclick ;
      private string tblUnnamedtablecontentfscardsmallimageandinfoview_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string edtIteID_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool bGXsfl_6_Refreshing=false ;
      private bool AV20DynamicFiltersEnabled2 ;
      private bool AV24DynamicFiltersEnabled3 ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool AV61Core_webfunilds_5_dynamicfiltersenabled2 ;
      private bool AV65Core_webfunilds_9_dynamicfiltersenabled3 ;
      private bool AV15OrderedDsc ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool bDynCreated_Wcwcfuniloportunidades ;
      private string AV30Descricao ;
      private string AV16FilterFullText ;
      private string AV17DynamicFiltersSelector1 ;
      private string AV19IteNome1 ;
      private string AV21DynamicFiltersSelector2 ;
      private string AV23IteNome2 ;
      private string AV25DynamicFiltersSelector3 ;
      private string AV27IteNome3 ;
      private string AV37TFIteNome ;
      private string AV38TFIteNome_Sel ;
      private string AV57Core_webfunilds_1_filterfulltext ;
      private string AV58Core_webfunilds_2_dynamicfiltersselector1 ;
      private string AV60Core_webfunilds_4_itenome1 ;
      private string AV62Core_webfunilds_6_dynamicfiltersselector2 ;
      private string AV64Core_webfunilds_8_itenome2 ;
      private string AV66Core_webfunilds_10_dynamicfiltersselector3 ;
      private string AV68Core_webfunilds_12_itenome3 ;
      private string AV69Core_webfunilds_13_tfitenome ;
      private string AV70Core_webfunilds_14_tfitenome_sel ;
      private string A383IteNome ;
      private string lV60Core_webfunilds_4_itenome1 ;
      private string lV64Core_webfunilds_8_itenome2 ;
      private string lV68Core_webfunilds_12_itenome3 ;
      private string lV69Core_webfunilds_13_tfitenome ;
      private Guid A381IteID ;
      private Guid A420NegUltIteID ;
      private Guid E381IteID ;
      private IGxSession AV33Session ;
      private GXWebComponent WebComp_Wcwcfuniloportunidades ;
      private GXWebComponent WebComp_Selectlistview_wc ;
      private GXWebComponent WebComp_Wwpaux_wc ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucInnewwindow1 ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXWebComponent WebComp_GX_Process ;
      private IDataStoreProvider pr_default ;
      private int[] H00502_A382IteOrdem ;
      private string[] H00502_A383IteNome ;
      private Guid[] H00502_A381IteID ;
      private int[] H00503_A382IteOrdem ;
      private string[] H00503_A383IteNome ;
      private Guid[] H00503_A381IteID ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private int[] H00504_Gx_cnt ;
      private decimal[] H00505_A385NegValorAtualizado ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV46GAMErrors ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV12GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV13GridStateDynamicFilter ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV44DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV45GAMSession ;
   }

   public class webfunilcardsmallimageandinfoview__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00502( IGxContext context ,
                                             string AV58Core_webfunilds_2_dynamicfiltersselector1 ,
                                             short AV59Core_webfunilds_3_dynamicfiltersoperator1 ,
                                             string AV60Core_webfunilds_4_itenome1 ,
                                             bool AV61Core_webfunilds_5_dynamicfiltersenabled2 ,
                                             string AV62Core_webfunilds_6_dynamicfiltersselector2 ,
                                             short AV63Core_webfunilds_7_dynamicfiltersoperator2 ,
                                             string AV64Core_webfunilds_8_itenome2 ,
                                             bool AV65Core_webfunilds_9_dynamicfiltersenabled3 ,
                                             string AV66Core_webfunilds_10_dynamicfiltersselector3 ,
                                             short AV67Core_webfunilds_11_dynamicfiltersoperator3 ,
                                             string AV68Core_webfunilds_12_itenome3 ,
                                             string AV70Core_webfunilds_14_tfitenome_sel ,
                                             string AV69Core_webfunilds_13_tfitenome ,
                                             string A383IteNome ,
                                             bool AV15OrderedDsc ,
                                             string AV57Core_webfunilds_1_filterfulltext ,
                                             decimal A431IteTotalOportunidades ,
                                             int A432IteQtdeOportunidades ,
                                             Guid A381IteID ,
                                             Guid A420NegUltIteID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[8];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT IteOrdem, IteNome, IteID FROM tb_Iteracao";
         if ( ( StringUtil.StrCmp(AV58Core_webfunilds_2_dynamicfiltersselector1, "ITENOME") == 0 ) && ( AV59Core_webfunilds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Core_webfunilds_4_itenome1)) ) )
         {
            AddWhere(sWhereString, "(IteNome like :lV60Core_webfunilds_4_itenome1)");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Core_webfunilds_2_dynamicfiltersselector1, "ITENOME") == 0 ) && ( AV59Core_webfunilds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Core_webfunilds_4_itenome1)) ) )
         {
            AddWhere(sWhereString, "(IteNome like '%' || :lV60Core_webfunilds_4_itenome1)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( AV61Core_webfunilds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Core_webfunilds_6_dynamicfiltersselector2, "ITENOME") == 0 ) && ( AV63Core_webfunilds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Core_webfunilds_8_itenome2)) ) )
         {
            AddWhere(sWhereString, "(IteNome like :lV64Core_webfunilds_8_itenome2)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( AV61Core_webfunilds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Core_webfunilds_6_dynamicfiltersselector2, "ITENOME") == 0 ) && ( AV63Core_webfunilds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Core_webfunilds_8_itenome2)) ) )
         {
            AddWhere(sWhereString, "(IteNome like '%' || :lV64Core_webfunilds_8_itenome2)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( AV65Core_webfunilds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV66Core_webfunilds_10_dynamicfiltersselector3, "ITENOME") == 0 ) && ( AV67Core_webfunilds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Core_webfunilds_12_itenome3)) ) )
         {
            AddWhere(sWhereString, "(IteNome like :lV68Core_webfunilds_12_itenome3)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( AV65Core_webfunilds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV66Core_webfunilds_10_dynamicfiltersselector3, "ITENOME") == 0 ) && ( AV67Core_webfunilds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Core_webfunilds_12_itenome3)) ) )
         {
            AddWhere(sWhereString, "(IteNome like '%' || :lV68Core_webfunilds_12_itenome3)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Core_webfunilds_14_tfitenome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Core_webfunilds_13_tfitenome)) ) )
         {
            AddWhere(sWhereString, "(IteNome like :lV69Core_webfunilds_13_tfitenome)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Core_webfunilds_14_tfitenome_sel)) && ! ( StringUtil.StrCmp(AV70Core_webfunilds_14_tfitenome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(IteNome = ( :AV70Core_webfunilds_14_tfitenome_sel))");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( StringUtil.StrCmp(AV70Core_webfunilds_14_tfitenome_sel, "<#Empty#>") == 0 )
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
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_H00503( IGxContext context ,
                                             string AV58Core_webfunilds_2_dynamicfiltersselector1 ,
                                             short AV59Core_webfunilds_3_dynamicfiltersoperator1 ,
                                             string AV60Core_webfunilds_4_itenome1 ,
                                             bool AV61Core_webfunilds_5_dynamicfiltersenabled2 ,
                                             string AV62Core_webfunilds_6_dynamicfiltersselector2 ,
                                             short AV63Core_webfunilds_7_dynamicfiltersoperator2 ,
                                             string AV64Core_webfunilds_8_itenome2 ,
                                             bool AV65Core_webfunilds_9_dynamicfiltersenabled3 ,
                                             string AV66Core_webfunilds_10_dynamicfiltersselector3 ,
                                             short AV67Core_webfunilds_11_dynamicfiltersoperator3 ,
                                             string AV68Core_webfunilds_12_itenome3 ,
                                             string AV70Core_webfunilds_14_tfitenome_sel ,
                                             string AV69Core_webfunilds_13_tfitenome ,
                                             string A383IteNome ,
                                             bool AV15OrderedDsc ,
                                             string AV57Core_webfunilds_1_filterfulltext ,
                                             decimal A431IteTotalOportunidades ,
                                             int A432IteQtdeOportunidades ,
                                             Guid A381IteID ,
                                             Guid A420NegUltIteID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[8];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT IteOrdem, IteNome, IteID FROM tb_Iteracao";
         if ( ( StringUtil.StrCmp(AV58Core_webfunilds_2_dynamicfiltersselector1, "ITENOME") == 0 ) && ( AV59Core_webfunilds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Core_webfunilds_4_itenome1)) ) )
         {
            AddWhere(sWhereString, "(IteNome like :lV60Core_webfunilds_4_itenome1)");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Core_webfunilds_2_dynamicfiltersselector1, "ITENOME") == 0 ) && ( AV59Core_webfunilds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Core_webfunilds_4_itenome1)) ) )
         {
            AddWhere(sWhereString, "(IteNome like '%' || :lV60Core_webfunilds_4_itenome1)");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( AV61Core_webfunilds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Core_webfunilds_6_dynamicfiltersselector2, "ITENOME") == 0 ) && ( AV63Core_webfunilds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Core_webfunilds_8_itenome2)) ) )
         {
            AddWhere(sWhereString, "(IteNome like :lV64Core_webfunilds_8_itenome2)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( AV61Core_webfunilds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Core_webfunilds_6_dynamicfiltersselector2, "ITENOME") == 0 ) && ( AV63Core_webfunilds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Core_webfunilds_8_itenome2)) ) )
         {
            AddWhere(sWhereString, "(IteNome like '%' || :lV64Core_webfunilds_8_itenome2)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( AV65Core_webfunilds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV66Core_webfunilds_10_dynamicfiltersselector3, "ITENOME") == 0 ) && ( AV67Core_webfunilds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Core_webfunilds_12_itenome3)) ) )
         {
            AddWhere(sWhereString, "(IteNome like :lV68Core_webfunilds_12_itenome3)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( AV65Core_webfunilds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV66Core_webfunilds_10_dynamicfiltersselector3, "ITENOME") == 0 ) && ( AV67Core_webfunilds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Core_webfunilds_12_itenome3)) ) )
         {
            AddWhere(sWhereString, "(IteNome like '%' || :lV68Core_webfunilds_12_itenome3)");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Core_webfunilds_14_tfitenome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Core_webfunilds_13_tfitenome)) ) )
         {
            AddWhere(sWhereString, "(IteNome like :lV69Core_webfunilds_13_tfitenome)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Core_webfunilds_14_tfitenome_sel)) && ! ( StringUtil.StrCmp(AV70Core_webfunilds_14_tfitenome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(IteNome = ( :AV70Core_webfunilds_14_tfitenome_sel))");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( StringUtil.StrCmp(AV70Core_webfunilds_14_tfitenome_sel, "<#Empty#>") == 0 )
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
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H00502(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (string)dynConstraints[2] , (bool)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (bool)dynConstraints[14] , (string)dynConstraints[15] , (decimal)dynConstraints[16] , (int)dynConstraints[17] , (Guid)dynConstraints[18] , (Guid)dynConstraints[19] );
               case 1 :
                     return conditional_H00503(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (string)dynConstraints[2] , (bool)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (bool)dynConstraints[14] , (string)dynConstraints[15] , (decimal)dynConstraints[16] , (int)dynConstraints[17] , (Guid)dynConstraints[18] , (Guid)dynConstraints[19] );
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
          Object[] prmH00504;
          prmH00504 = new Object[] {
          new ParDef("IteID",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmH00505;
          prmH00505 = new Object[] {
          new ParDef("IteID",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmH00502;
          prmH00502 = new Object[] {
          new ParDef("lV60Core_webfunilds_4_itenome1",GXType.VarChar,80,0) ,
          new ParDef("lV60Core_webfunilds_4_itenome1",GXType.VarChar,80,0) ,
          new ParDef("lV64Core_webfunilds_8_itenome2",GXType.VarChar,80,0) ,
          new ParDef("lV64Core_webfunilds_8_itenome2",GXType.VarChar,80,0) ,
          new ParDef("lV68Core_webfunilds_12_itenome3",GXType.VarChar,80,0) ,
          new ParDef("lV68Core_webfunilds_12_itenome3",GXType.VarChar,80,0) ,
          new ParDef("lV69Core_webfunilds_13_tfitenome",GXType.VarChar,80,0) ,
          new ParDef("AV70Core_webfunilds_14_tfitenome_sel",GXType.VarChar,80,0)
          };
          Object[] prmH00503;
          prmH00503 = new Object[] {
          new ParDef("lV60Core_webfunilds_4_itenome1",GXType.VarChar,80,0) ,
          new ParDef("lV60Core_webfunilds_4_itenome1",GXType.VarChar,80,0) ,
          new ParDef("lV64Core_webfunilds_8_itenome2",GXType.VarChar,80,0) ,
          new ParDef("lV64Core_webfunilds_8_itenome2",GXType.VarChar,80,0) ,
          new ParDef("lV68Core_webfunilds_12_itenome3",GXType.VarChar,80,0) ,
          new ParDef("lV68Core_webfunilds_12_itenome3",GXType.VarChar,80,0) ,
          new ParDef("lV69Core_webfunilds_13_tfitenome",GXType.VarChar,80,0) ,
          new ParDef("AV70Core_webfunilds_14_tfitenome_sel",GXType.VarChar,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00502", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00502,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00503", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00503,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00504", "SELECT COUNT(*) FROM tb_negociopj WHERE NegUltIteID = :IteID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00504,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H00505", "SELECT SUM(NegValorAtualizado) FROM tb_negociopj WHERE NegUltIteID = :IteID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00505,1, GxCacheFrequency.OFF ,true,true )
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
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 3 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                return;
       }
    }

 }

}
