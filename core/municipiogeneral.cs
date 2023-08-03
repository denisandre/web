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
   public class municipiogeneral : GXWebComponent
   {
      public municipiogeneral( )
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

      public municipiogeneral( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_MunicipioID )
      {
         this.A35MunicipioID = aP0_MunicipioID;
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
               gxfirstwebparm = GetFirstPar( "MunicipioID");
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
                  A35MunicipioID = (int)(Math.Round(NumberUtil.Val( GetPar( "MunicipioID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "A35MunicipioID", StringUtil.LTrimStr( (decimal)(A35MunicipioID), 9, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(int)A35MunicipioID});
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
                  gxfirstwebparm = GetFirstPar( "MunicipioID");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "MunicipioID");
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
            PA4N2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV13Pgmname = "core.municipioGeneral";
               WS4N2( ) ;
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
            context.SendWebValue( "municipio General") ;
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
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.CloseHtmlHeader();
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            FormProcess = ((nGXWrapped==0) ? " data-HasEnter=\"false\" data-Skiponenter=\"false\"" : "");
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
            if ( nGXWrapped != 1 )
            {
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               GXEncryptionTmp = "core.municipiogeneral.aspx"+UrlEncode(StringUtil.LTrimStr(A35MunicipioID,9,0));
               context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("core.municipiogeneral.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
               GxWebStd.gx_hidden_field( context, "_EventName", "");
               GxWebStd.gx_hidden_field( context, "_EventGridId", "");
               GxWebStd.gx_hidden_field( context, "_EventRowId", "");
               context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
               AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal Form", true);
            }
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
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA35MunicipioID", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOA35MunicipioID), 9, 0, ",", "")));
      }

      protected void RenderHtmlCloseForm4N2( )
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
            if ( nGXWrapped != 1 )
            {
               context.WriteHtmlTextNl( "</form>") ;
            }
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
            include_jscripts( ) ;
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
         return "core.municipioGeneral" ;
      }

      public override string GetPgmdesc( )
      {
         return "municipio General" ;
      }

      protected void WB4N0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "core.municipiogeneral.aspx");
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", sPrefix, "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTransactiondetail_tableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMunicipioID_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtMunicipioID_Internalname, "ID", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtMunicipioID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A35MunicipioID), 11, 0, ",", "")), StringUtil.LTrim( ((edtMunicipioID_Enabled!=0) ? context.localUtil.Format( (decimal)(A35MunicipioID), "ZZZ,ZZZ,ZZ9") : context.localUtil.Format( (decimal)(A35MunicipioID), "ZZZ,ZZZ,ZZ9"))), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMunicipioID_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtMunicipioID_Enabled, 0, "text", "", 11, "chr", 1, "row", 11, 0, 0, 0, 0, -1, 0, true, "core\\ID", "end", false, "", "HLP_core\\municipioGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMunicipioNome_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtMunicipioNome_Internalname, "Nome", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtMunicipioNome_Internalname, A36MunicipioNome, StringUtil.RTrim( context.localUtil.Format( A36MunicipioNome, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMunicipioNome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtMunicipioNome_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\municipioGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMunicipioMicroNome_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtMunicipioMicroNome_Internalname, "Microrregião", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtMunicipioMicroNome_Internalname, A38MunicipioMicroNome, StringUtil.RTrim( context.localUtil.Format( A38MunicipioMicroNome, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", edtMunicipioMicroNome_Link, "", "", "", edtMunicipioMicroNome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtMunicipioMicroNome_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\municipioGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMunicipioMicroMesoID_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtMunicipioMicroMesoID_Internalname, "Mesorregião", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtMunicipioMicroMesoID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A39MunicipioMicroMesoID), 11, 0, ",", "")), StringUtil.LTrim( ((edtMunicipioMicroMesoID_Enabled!=0) ? context.localUtil.Format( (decimal)(A39MunicipioMicroMesoID), "ZZZ,ZZZ,ZZ9") : context.localUtil.Format( (decimal)(A39MunicipioMicroMesoID), "ZZZ,ZZZ,ZZ9"))), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMunicipioMicroMesoID_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtMunicipioMicroMesoID_Enabled, 0, "text", "", 11, "chr", 1, "row", 11, 0, 0, 0, 0, -1, 0, true, "core\\ID", "end", false, "", "HLP_core\\municipioGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMunicipioMicroMesoUFID_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtMunicipioMicroMesoUFID_Internalname, "UF", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtMunicipioMicroMesoUFID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A41MunicipioMicroMesoUFID), 11, 0, ",", "")), StringUtil.LTrim( ((edtMunicipioMicroMesoUFID_Enabled!=0) ? context.localUtil.Format( (decimal)(A41MunicipioMicroMesoUFID), "ZZZ,ZZZ,ZZ9") : context.localUtil.Format( (decimal)(A41MunicipioMicroMesoUFID), "ZZZ,ZZZ,ZZ9"))), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMunicipioMicroMesoUFID_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtMunicipioMicroMesoUFID_Enabled, 0, "text", "", 11, "chr", 1, "row", 11, 0, 0, 0, 0, -1, 0, true, "core\\ID", "end", false, "", "HLP_core\\municipioGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMunicipioMicroMesoUFRegID_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtMunicipioMicroMesoUFRegID_Internalname, "Região", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtMunicipioMicroMesoUFRegID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A45MunicipioMicroMesoUFRegID), 11, 0, ",", "")), StringUtil.LTrim( ((edtMunicipioMicroMesoUFRegID_Enabled!=0) ? context.localUtil.Format( (decimal)(A45MunicipioMicroMesoUFRegID), "ZZZ,ZZZ,ZZ9") : context.localUtil.Format( (decimal)(A45MunicipioMicroMesoUFRegID), "ZZZ,ZZZ,ZZ9"))), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMunicipioMicroMesoUFRegID_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtMunicipioMicroMesoUFRegID_Enabled, 0, "text", "", 11, "chr", 1, "row", 11, 0, 0, 0, 0, -1, 0, true, "core\\ID", "end", false, "", "HLP_core\\municipioGeneral.htm");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, divHtml_bottomauxiliarcontrols_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtMunicipioMicroMesoNome_Internalname, A40MunicipioMicroMesoNome, StringUtil.RTrim( context.localUtil.Format( A40MunicipioMicroMesoNome, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMunicipioMicroMesoNome_Jsonclick, 0, "Attribute", "", "", "", "", edtMunicipioMicroMesoNome_Visible, 0, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\municipioGeneral.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtMunicipioMicroMesoUFSigla_Internalname, A42MunicipioMicroMesoUFSigla, StringUtil.RTrim( context.localUtil.Format( A42MunicipioMicroMesoUFSigla, "@!")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMunicipioMicroMesoUFSigla_Jsonclick, 0, "Attribute", "", "", "", "", edtMunicipioMicroMesoUFSigla_Visible, 0, 0, "text", "", 2, "chr", 1, "row", 2, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\municipioGeneral.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtMunicipioMicroMesoUFNome_Internalname, A43MunicipioMicroMesoUFNome, StringUtil.RTrim( context.localUtil.Format( A43MunicipioMicroMesoUFNome, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMunicipioMicroMesoUFNome_Jsonclick, 0, "Attribute", "", "", "", "", edtMunicipioMicroMesoUFNome_Visible, 0, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\municipioGeneral.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtMunicipioMicroMesoUFSiglaNome_Internalname, A44MunicipioMicroMesoUFSiglaNome, StringUtil.RTrim( context.localUtil.Format( A44MunicipioMicroMesoUFSiglaNome, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMunicipioMicroMesoUFSiglaNome_Jsonclick, 0, "Attribute", "", "", "", "", edtMunicipioMicroMesoUFSiglaNome_Visible, 0, 0, "text", "", 70, "chr", 1, "row", 70, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\municipioGeneral.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtMunicipioMicroMesoUFRegSigla_Internalname, A46MunicipioMicroMesoUFRegSigla, StringUtil.RTrim( context.localUtil.Format( A46MunicipioMicroMesoUFRegSigla, "@!")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMunicipioMicroMesoUFRegSigla_Jsonclick, 0, "Attribute", "", "", "", "", edtMunicipioMicroMesoUFRegSigla_Visible, 0, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\municipioGeneral.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtMunicipioMicroMesoUFRegNome_Internalname, A47MunicipioMicroMesoUFRegNome, StringUtil.RTrim( context.localUtil.Format( A47MunicipioMicroMesoUFRegNome, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMunicipioMicroMesoUFRegNome_Jsonclick, 0, "Attribute", "", "", "", "", edtMunicipioMicroMesoUFRegNome_Visible, 0, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\municipioGeneral.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtMunicipioMicroMesoUFRegSiglaNo_Internalname, A48MunicipioMicroMesoUFRegSiglaNo, StringUtil.RTrim( context.localUtil.Format( A48MunicipioMicroMesoUFRegSiglaNo, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMunicipioMicroMesoUFRegSiglaNo_Jsonclick, 0, "Attribute", "", "", "", "", edtMunicipioMicroMesoUFRegSiglaNo_Visible, 0, 0, "text", "", 70, "chr", 1, "row", 70, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\municipioGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START4N2( )
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
               Form.Meta.addItem("description", "municipio General", 0) ;
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
               STRUP4N0( ) ;
            }
         }
      }

      protected void WS4N2( )
      {
         START4N2( ) ;
         EVT4N2( ) ;
      }

      protected void EVT4N2( )
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
                                 STRUP4N0( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4N0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E114N2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4N0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E124N2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4N0( ) ;
                              }
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
                                 STRUP4N0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE4N2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm4N2( ) ;
            }
         }
      }

      protected void PA4N2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "core.municipiogeneral.aspx")), "core.municipiogeneral.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "core.municipiogeneral.aspx")))) ;
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
                     gxfirstwebparm = GetFirstPar( "MunicipioID");
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
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
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
         RF4N2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV13Pgmname = "core.municipioGeneral";
      }

      protected void RF4N2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H004N2 */
            pr_default.execute(0, new Object[] {A35MunicipioID});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A37MunicipioMicroID = H004N2_A37MunicipioMicroID[0];
               A48MunicipioMicroMesoUFRegSiglaNo = H004N2_A48MunicipioMicroMesoUFRegSiglaNo[0];
               n48MunicipioMicroMesoUFRegSiglaNo = H004N2_n48MunicipioMicroMesoUFRegSiglaNo[0];
               AssignAttri(sPrefix, false, "A48MunicipioMicroMesoUFRegSiglaNo", A48MunicipioMicroMesoUFRegSiglaNo);
               A47MunicipioMicroMesoUFRegNome = H004N2_A47MunicipioMicroMesoUFRegNome[0];
               n47MunicipioMicroMesoUFRegNome = H004N2_n47MunicipioMicroMesoUFRegNome[0];
               AssignAttri(sPrefix, false, "A47MunicipioMicroMesoUFRegNome", A47MunicipioMicroMesoUFRegNome);
               A46MunicipioMicroMesoUFRegSigla = H004N2_A46MunicipioMicroMesoUFRegSigla[0];
               n46MunicipioMicroMesoUFRegSigla = H004N2_n46MunicipioMicroMesoUFRegSigla[0];
               AssignAttri(sPrefix, false, "A46MunicipioMicroMesoUFRegSigla", A46MunicipioMicroMesoUFRegSigla);
               A44MunicipioMicroMesoUFSiglaNome = H004N2_A44MunicipioMicroMesoUFSiglaNome[0];
               n44MunicipioMicroMesoUFSiglaNome = H004N2_n44MunicipioMicroMesoUFSiglaNome[0];
               AssignAttri(sPrefix, false, "A44MunicipioMicroMesoUFSiglaNome", A44MunicipioMicroMesoUFSiglaNome);
               A43MunicipioMicroMesoUFNome = H004N2_A43MunicipioMicroMesoUFNome[0];
               n43MunicipioMicroMesoUFNome = H004N2_n43MunicipioMicroMesoUFNome[0];
               AssignAttri(sPrefix, false, "A43MunicipioMicroMesoUFNome", A43MunicipioMicroMesoUFNome);
               A42MunicipioMicroMesoUFSigla = H004N2_A42MunicipioMicroMesoUFSigla[0];
               n42MunicipioMicroMesoUFSigla = H004N2_n42MunicipioMicroMesoUFSigla[0];
               AssignAttri(sPrefix, false, "A42MunicipioMicroMesoUFSigla", A42MunicipioMicroMesoUFSigla);
               A40MunicipioMicroMesoNome = H004N2_A40MunicipioMicroMesoNome[0];
               n40MunicipioMicroMesoNome = H004N2_n40MunicipioMicroMesoNome[0];
               AssignAttri(sPrefix, false, "A40MunicipioMicroMesoNome", A40MunicipioMicroMesoNome);
               A45MunicipioMicroMesoUFRegID = H004N2_A45MunicipioMicroMesoUFRegID[0];
               n45MunicipioMicroMesoUFRegID = H004N2_n45MunicipioMicroMesoUFRegID[0];
               AssignAttri(sPrefix, false, "A45MunicipioMicroMesoUFRegID", StringUtil.LTrimStr( (decimal)(A45MunicipioMicroMesoUFRegID), 9, 0));
               A41MunicipioMicroMesoUFID = H004N2_A41MunicipioMicroMesoUFID[0];
               n41MunicipioMicroMesoUFID = H004N2_n41MunicipioMicroMesoUFID[0];
               AssignAttri(sPrefix, false, "A41MunicipioMicroMesoUFID", StringUtil.LTrimStr( (decimal)(A41MunicipioMicroMesoUFID), 9, 0));
               A39MunicipioMicroMesoID = H004N2_A39MunicipioMicroMesoID[0];
               AssignAttri(sPrefix, false, "A39MunicipioMicroMesoID", StringUtil.LTrimStr( (decimal)(A39MunicipioMicroMesoID), 9, 0));
               A38MunicipioMicroNome = H004N2_A38MunicipioMicroNome[0];
               AssignAttri(sPrefix, false, "A38MunicipioMicroNome", A38MunicipioMicroNome);
               A36MunicipioNome = H004N2_A36MunicipioNome[0];
               AssignAttri(sPrefix, false, "A36MunicipioNome", A36MunicipioNome);
               /* Execute user event: Load */
               E124N2 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            WB4N0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes4N2( )
      {
      }

      protected void before_start_formulas( )
      {
         AV13Pgmname = "core.municipioGeneral";
         fix_multi_value_controls( ) ;
      }

      protected void STRUP4N0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E114N2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOA35MunicipioID = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA35MunicipioID"), ",", "."), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            A36MunicipioNome = cgiGet( edtMunicipioNome_Internalname);
            AssignAttri(sPrefix, false, "A36MunicipioNome", A36MunicipioNome);
            A38MunicipioMicroNome = cgiGet( edtMunicipioMicroNome_Internalname);
            AssignAttri(sPrefix, false, "A38MunicipioMicroNome", A38MunicipioMicroNome);
            A39MunicipioMicroMesoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtMunicipioMicroMesoID_Internalname), ",", "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A39MunicipioMicroMesoID", StringUtil.LTrimStr( (decimal)(A39MunicipioMicroMesoID), 9, 0));
            A41MunicipioMicroMesoUFID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtMunicipioMicroMesoUFID_Internalname), ",", "."), 18, MidpointRounding.ToEven));
            n41MunicipioMicroMesoUFID = false;
            AssignAttri(sPrefix, false, "A41MunicipioMicroMesoUFID", StringUtil.LTrimStr( (decimal)(A41MunicipioMicroMesoUFID), 9, 0));
            A45MunicipioMicroMesoUFRegID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtMunicipioMicroMesoUFRegID_Internalname), ",", "."), 18, MidpointRounding.ToEven));
            n45MunicipioMicroMesoUFRegID = false;
            AssignAttri(sPrefix, false, "A45MunicipioMicroMesoUFRegID", StringUtil.LTrimStr( (decimal)(A45MunicipioMicroMesoUFRegID), 9, 0));
            A40MunicipioMicroMesoNome = cgiGet( edtMunicipioMicroMesoNome_Internalname);
            n40MunicipioMicroMesoNome = false;
            AssignAttri(sPrefix, false, "A40MunicipioMicroMesoNome", A40MunicipioMicroMesoNome);
            A42MunicipioMicroMesoUFSigla = StringUtil.Upper( cgiGet( edtMunicipioMicroMesoUFSigla_Internalname));
            n42MunicipioMicroMesoUFSigla = false;
            AssignAttri(sPrefix, false, "A42MunicipioMicroMesoUFSigla", A42MunicipioMicroMesoUFSigla);
            A43MunicipioMicroMesoUFNome = cgiGet( edtMunicipioMicroMesoUFNome_Internalname);
            n43MunicipioMicroMesoUFNome = false;
            AssignAttri(sPrefix, false, "A43MunicipioMicroMesoUFNome", A43MunicipioMicroMesoUFNome);
            A44MunicipioMicroMesoUFSiglaNome = cgiGet( edtMunicipioMicroMesoUFSiglaNome_Internalname);
            n44MunicipioMicroMesoUFSiglaNome = false;
            AssignAttri(sPrefix, false, "A44MunicipioMicroMesoUFSiglaNome", A44MunicipioMicroMesoUFSiglaNome);
            A46MunicipioMicroMesoUFRegSigla = StringUtil.Upper( cgiGet( edtMunicipioMicroMesoUFRegSigla_Internalname));
            n46MunicipioMicroMesoUFRegSigla = false;
            AssignAttri(sPrefix, false, "A46MunicipioMicroMesoUFRegSigla", A46MunicipioMicroMesoUFRegSigla);
            A47MunicipioMicroMesoUFRegNome = cgiGet( edtMunicipioMicroMesoUFRegNome_Internalname);
            n47MunicipioMicroMesoUFRegNome = false;
            AssignAttri(sPrefix, false, "A47MunicipioMicroMesoUFRegNome", A47MunicipioMicroMesoUFRegNome);
            A48MunicipioMicroMesoUFRegSiglaNo = cgiGet( edtMunicipioMicroMesoUFRegSiglaNo_Internalname);
            n48MunicipioMicroMesoUFRegSiglaNo = false;
            AssignAttri(sPrefix, false, "A48MunicipioMicroMesoUFRegSiglaNo", A48MunicipioMicroMesoUFRegSiglaNo);
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
         E114N2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E114N2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E124N2( )
      {
         /* Load Routine */
         returnInSub = false;
         GXt_boolean1 = AV12TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "microrregiaoview_Execute", out  GXt_boolean1) ;
         AV12TempBoolean = GXt_boolean1;
         if ( AV12TempBoolean )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
               }
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "core.microrregiaoview.aspx"+UrlEncode(StringUtil.LTrimStr(A37MunicipioMicroID,9,0)) + "," + UrlEncode(StringUtil.RTrim(""));
            edtMunicipioMicroNome_Link = formatLink("core.microrregiaoview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            AssignProp(sPrefix, false, edtMunicipioMicroNome_Internalname, "Link", edtMunicipioMicroNome_Link, true);
         }
         edtMunicipioMicroMesoNome_Visible = 0;
         AssignProp(sPrefix, false, edtMunicipioMicroMesoNome_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMunicipioMicroMesoNome_Visible), 5, 0), true);
         edtMunicipioMicroMesoUFSigla_Visible = 0;
         AssignProp(sPrefix, false, edtMunicipioMicroMesoUFSigla_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMunicipioMicroMesoUFSigla_Visible), 5, 0), true);
         edtMunicipioMicroMesoUFNome_Visible = 0;
         AssignProp(sPrefix, false, edtMunicipioMicroMesoUFNome_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMunicipioMicroMesoUFNome_Visible), 5, 0), true);
         edtMunicipioMicroMesoUFSiglaNome_Visible = 0;
         AssignProp(sPrefix, false, edtMunicipioMicroMesoUFSiglaNome_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMunicipioMicroMesoUFSiglaNome_Visible), 5, 0), true);
         edtMunicipioMicroMesoUFRegSigla_Visible = 0;
         AssignProp(sPrefix, false, edtMunicipioMicroMesoUFRegSigla_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMunicipioMicroMesoUFRegSigla_Visible), 5, 0), true);
         edtMunicipioMicroMesoUFRegNome_Visible = 0;
         AssignProp(sPrefix, false, edtMunicipioMicroMesoUFRegNome_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMunicipioMicroMesoUFRegNome_Visible), 5, 0), true);
         edtMunicipioMicroMesoUFRegSiglaNo_Visible = 0;
         AssignProp(sPrefix, false, edtMunicipioMicroMesoUFRegSiglaNo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMunicipioMicroMesoUFRegSiglaNo_Visible), 5, 0), true);
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV8TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV8TrnContext.gxTpr_Callerobject = AV13Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = false;
         AV8TrnContext.gxTpr_Callerurl = AV11HTTPRequest.ScriptName+"?"+AV11HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "core.municipio";
         AV10Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A35MunicipioID = Convert.ToInt32(getParm(obj,0));
         AssignAttri(sPrefix, false, "A35MunicipioID", StringUtil.LTrimStr( (decimal)(A35MunicipioID), 9, 0));
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
         PA4N2( ) ;
         WS4N2( ) ;
         WE4N2( ) ;
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
         sCtrlA35MunicipioID = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA4N2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "core\\municipiogeneral", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA4N2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            A35MunicipioID = Convert.ToInt32(getParm(obj,2));
            AssignAttri(sPrefix, false, "A35MunicipioID", StringUtil.LTrimStr( (decimal)(A35MunicipioID), 9, 0));
         }
         wcpOA35MunicipioID = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA35MunicipioID"), ",", "."), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( A35MunicipioID != wcpOA35MunicipioID ) ) )
         {
            setjustcreated();
         }
         wcpOA35MunicipioID = A35MunicipioID;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlA35MunicipioID = cgiGet( sPrefix+"A35MunicipioID_CTRL");
         if ( StringUtil.Len( sCtrlA35MunicipioID) > 0 )
         {
            A35MunicipioID = (int)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlA35MunicipioID), ",", "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A35MunicipioID", StringUtil.LTrimStr( (decimal)(A35MunicipioID), 9, 0));
         }
         else
         {
            A35MunicipioID = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"A35MunicipioID_PARM"), ",", "."), 18, MidpointRounding.ToEven));
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
         PA4N2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS4N2( ) ;
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
         WS4N2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"A35MunicipioID_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(A35MunicipioID), 9, 0, ",", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA35MunicipioID)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A35MunicipioID_CTRL", StringUtil.RTrim( sCtrlA35MunicipioID));
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
         WE4N2( ) ;
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
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
      }

      protected void define_styles( )
      {
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202382894432", true, true);
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
         if ( nGXWrapped != 1 )
         {
            context.AddJavascriptSource("core/municipiogeneral.js", "?202382894432", false, true);
         }
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtMunicipioID_Internalname = sPrefix+"MUNICIPIOID";
         edtMunicipioNome_Internalname = sPrefix+"MUNICIPIONOME";
         edtMunicipioMicroNome_Internalname = sPrefix+"MUNICIPIOMICRONOME";
         edtMunicipioMicroMesoID_Internalname = sPrefix+"MUNICIPIOMICROMESOID";
         edtMunicipioMicroMesoUFID_Internalname = sPrefix+"MUNICIPIOMICROMESOUFID";
         edtMunicipioMicroMesoUFRegID_Internalname = sPrefix+"MUNICIPIOMICROMESOUFREGID";
         divTransactiondetail_tableattributes_Internalname = sPrefix+"TRANSACTIONDETAIL_TABLEATTRIBUTES";
         divTable_Internalname = sPrefix+"TABLE";
         edtMunicipioMicroMesoNome_Internalname = sPrefix+"MUNICIPIOMICROMESONOME";
         edtMunicipioMicroMesoUFSigla_Internalname = sPrefix+"MUNICIPIOMICROMESOUFSIGLA";
         edtMunicipioMicroMesoUFNome_Internalname = sPrefix+"MUNICIPIOMICROMESOUFNOME";
         edtMunicipioMicroMesoUFSiglaNome_Internalname = sPrefix+"MUNICIPIOMICROMESOUFSIGLANOME";
         edtMunicipioMicroMesoUFRegSigla_Internalname = sPrefix+"MUNICIPIOMICROMESOUFREGSIGLA";
         edtMunicipioMicroMesoUFRegNome_Internalname = sPrefix+"MUNICIPIOMICROMESOUFREGNOME";
         edtMunicipioMicroMesoUFRegSiglaNo_Internalname = sPrefix+"MUNICIPIOMICROMESOUFREGSIGLANO";
         divHtml_bottomauxiliarcontrols_Internalname = sPrefix+"HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
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
         edtMunicipioMicroMesoUFRegSiglaNo_Jsonclick = "";
         edtMunicipioMicroMesoUFRegSiglaNo_Visible = 1;
         edtMunicipioMicroMesoUFRegNome_Jsonclick = "";
         edtMunicipioMicroMesoUFRegNome_Visible = 1;
         edtMunicipioMicroMesoUFRegSigla_Jsonclick = "";
         edtMunicipioMicroMesoUFRegSigla_Visible = 1;
         edtMunicipioMicroMesoUFSiglaNome_Jsonclick = "";
         edtMunicipioMicroMesoUFSiglaNome_Visible = 1;
         edtMunicipioMicroMesoUFNome_Jsonclick = "";
         edtMunicipioMicroMesoUFNome_Visible = 1;
         edtMunicipioMicroMesoUFSigla_Jsonclick = "";
         edtMunicipioMicroMesoUFSigla_Visible = 1;
         edtMunicipioMicroMesoNome_Jsonclick = "";
         edtMunicipioMicroMesoNome_Visible = 1;
         edtMunicipioMicroMesoUFRegID_Jsonclick = "";
         edtMunicipioMicroMesoUFRegID_Enabled = 0;
         edtMunicipioMicroMesoUFID_Jsonclick = "";
         edtMunicipioMicroMesoUFID_Enabled = 0;
         edtMunicipioMicroMesoID_Jsonclick = "";
         edtMunicipioMicroMesoID_Enabled = 0;
         edtMunicipioMicroNome_Jsonclick = "";
         edtMunicipioMicroNome_Link = "";
         edtMunicipioMicroNome_Enabled = 0;
         edtMunicipioNome_Jsonclick = "";
         edtMunicipioNome_Enabled = 0;
         edtMunicipioID_Jsonclick = "";
         edtMunicipioID_Enabled = 0;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A35MunicipioID',fld:'MUNICIPIOID',pic:'ZZZ,ZZZ,ZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("VALID_MUNICIPIOID","{handler:'Valid_Municipioid',iparms:[]");
         setEventMetadata("VALID_MUNICIPIOID",",oparms:[]}");
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
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV13Pgmname = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         GX_FocusControl = "";
         A36MunicipioNome = "";
         A38MunicipioMicroNome = "";
         A40MunicipioMicroMesoNome = "";
         A42MunicipioMicroMesoUFSigla = "";
         A43MunicipioMicroMesoUFNome = "";
         A44MunicipioMicroMesoUFSiglaNome = "";
         A46MunicipioMicroMesoUFRegSigla = "";
         A47MunicipioMicroMesoUFRegNome = "";
         A48MunicipioMicroMesoUFRegSiglaNo = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         scmdbuf = "";
         H004N2_A35MunicipioID = new int[1] ;
         H004N2_A37MunicipioMicroID = new int[1] ;
         H004N2_A48MunicipioMicroMesoUFRegSiglaNo = new string[] {""} ;
         H004N2_n48MunicipioMicroMesoUFRegSiglaNo = new bool[] {false} ;
         H004N2_A47MunicipioMicroMesoUFRegNome = new string[] {""} ;
         H004N2_n47MunicipioMicroMesoUFRegNome = new bool[] {false} ;
         H004N2_A46MunicipioMicroMesoUFRegSigla = new string[] {""} ;
         H004N2_n46MunicipioMicroMesoUFRegSigla = new bool[] {false} ;
         H004N2_A44MunicipioMicroMesoUFSiglaNome = new string[] {""} ;
         H004N2_n44MunicipioMicroMesoUFSiglaNome = new bool[] {false} ;
         H004N2_A43MunicipioMicroMesoUFNome = new string[] {""} ;
         H004N2_n43MunicipioMicroMesoUFNome = new bool[] {false} ;
         H004N2_A42MunicipioMicroMesoUFSigla = new string[] {""} ;
         H004N2_n42MunicipioMicroMesoUFSigla = new bool[] {false} ;
         H004N2_A40MunicipioMicroMesoNome = new string[] {""} ;
         H004N2_n40MunicipioMicroMesoNome = new bool[] {false} ;
         H004N2_A45MunicipioMicroMesoUFRegID = new int[1] ;
         H004N2_n45MunicipioMicroMesoUFRegID = new bool[] {false} ;
         H004N2_A41MunicipioMicroMesoUFID = new int[1] ;
         H004N2_n41MunicipioMicroMesoUFID = new bool[] {false} ;
         H004N2_A39MunicipioMicroMesoID = new int[1] ;
         H004N2_A38MunicipioMicroNome = new string[] {""} ;
         H004N2_A36MunicipioNome = new string[] {""} ;
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV8TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV11HTTPRequest = new GxHttpRequest( context);
         AV10Session = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlA35MunicipioID = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.municipiogeneral__default(),
            new Object[][] {
                new Object[] {
               H004N2_A35MunicipioID, H004N2_A37MunicipioMicroID, H004N2_A48MunicipioMicroMesoUFRegSiglaNo, H004N2_n48MunicipioMicroMesoUFRegSiglaNo, H004N2_A47MunicipioMicroMesoUFRegNome, H004N2_n47MunicipioMicroMesoUFRegNome, H004N2_A46MunicipioMicroMesoUFRegSigla, H004N2_n46MunicipioMicroMesoUFRegSigla, H004N2_A44MunicipioMicroMesoUFSiglaNome, H004N2_n44MunicipioMicroMesoUFSiglaNome,
               H004N2_A43MunicipioMicroMesoUFNome, H004N2_n43MunicipioMicroMesoUFNome, H004N2_A42MunicipioMicroMesoUFSigla, H004N2_n42MunicipioMicroMesoUFSigla, H004N2_A40MunicipioMicroMesoNome, H004N2_n40MunicipioMicroMesoNome, H004N2_A45MunicipioMicroMesoUFRegID, H004N2_n45MunicipioMicroMesoUFRegID, H004N2_A41MunicipioMicroMesoUFID, H004N2_n41MunicipioMicroMesoUFID,
               H004N2_A39MunicipioMicroMesoID, H004N2_A38MunicipioMicroNome, H004N2_A36MunicipioNome
               }
            }
         );
         AV13Pgmname = "core.municipioGeneral";
         /* GeneXus formulas. */
         AV13Pgmname = "core.municipioGeneral";
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short initialized ;
      private short nGXWrapped ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private int A35MunicipioID ;
      private int wcpOA35MunicipioID ;
      private int edtMunicipioID_Enabled ;
      private int edtMunicipioNome_Enabled ;
      private int edtMunicipioMicroNome_Enabled ;
      private int A39MunicipioMicroMesoID ;
      private int edtMunicipioMicroMesoID_Enabled ;
      private int A41MunicipioMicroMesoUFID ;
      private int edtMunicipioMicroMesoUFID_Enabled ;
      private int A45MunicipioMicroMesoUFRegID ;
      private int edtMunicipioMicroMesoUFRegID_Enabled ;
      private int edtMunicipioMicroMesoNome_Visible ;
      private int edtMunicipioMicroMesoUFSigla_Visible ;
      private int edtMunicipioMicroMesoUFNome_Visible ;
      private int edtMunicipioMicroMesoUFSiglaNome_Visible ;
      private int edtMunicipioMicroMesoUFRegSigla_Visible ;
      private int edtMunicipioMicroMesoUFRegNome_Visible ;
      private int edtMunicipioMicroMesoUFRegSiglaNo_Visible ;
      private int A37MunicipioMicroID ;
      private int idxLst ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string AV13Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTable_Internalname ;
      private string divTransactiondetail_tableattributes_Internalname ;
      private string edtMunicipioID_Internalname ;
      private string edtMunicipioID_Jsonclick ;
      private string edtMunicipioNome_Internalname ;
      private string edtMunicipioNome_Jsonclick ;
      private string edtMunicipioMicroNome_Internalname ;
      private string edtMunicipioMicroNome_Link ;
      private string edtMunicipioMicroNome_Jsonclick ;
      private string edtMunicipioMicroMesoID_Internalname ;
      private string edtMunicipioMicroMesoID_Jsonclick ;
      private string edtMunicipioMicroMesoUFID_Internalname ;
      private string edtMunicipioMicroMesoUFID_Jsonclick ;
      private string edtMunicipioMicroMesoUFRegID_Internalname ;
      private string edtMunicipioMicroMesoUFRegID_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtMunicipioMicroMesoNome_Internalname ;
      private string edtMunicipioMicroMesoNome_Jsonclick ;
      private string edtMunicipioMicroMesoUFSigla_Internalname ;
      private string edtMunicipioMicroMesoUFSigla_Jsonclick ;
      private string edtMunicipioMicroMesoUFNome_Internalname ;
      private string edtMunicipioMicroMesoUFNome_Jsonclick ;
      private string edtMunicipioMicroMesoUFSiglaNome_Internalname ;
      private string edtMunicipioMicroMesoUFSiglaNome_Jsonclick ;
      private string edtMunicipioMicroMesoUFRegSigla_Internalname ;
      private string edtMunicipioMicroMesoUFRegSigla_Jsonclick ;
      private string edtMunicipioMicroMesoUFRegNome_Internalname ;
      private string edtMunicipioMicroMesoUFRegNome_Jsonclick ;
      private string edtMunicipioMicroMesoUFRegSiglaNo_Internalname ;
      private string edtMunicipioMicroMesoUFRegSiglaNo_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string scmdbuf ;
      private string sCtrlA35MunicipioID ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool n48MunicipioMicroMesoUFRegSiglaNo ;
      private bool n47MunicipioMicroMesoUFRegNome ;
      private bool n46MunicipioMicroMesoUFRegSigla ;
      private bool n44MunicipioMicroMesoUFSiglaNome ;
      private bool n43MunicipioMicroMesoUFNome ;
      private bool n42MunicipioMicroMesoUFSigla ;
      private bool n40MunicipioMicroMesoNome ;
      private bool n45MunicipioMicroMesoUFRegID ;
      private bool n41MunicipioMicroMesoUFID ;
      private bool returnInSub ;
      private bool AV12TempBoolean ;
      private bool GXt_boolean1 ;
      private string A36MunicipioNome ;
      private string A38MunicipioMicroNome ;
      private string A40MunicipioMicroMesoNome ;
      private string A42MunicipioMicroMesoUFSigla ;
      private string A43MunicipioMicroMesoUFNome ;
      private string A44MunicipioMicroMesoUFSiglaNome ;
      private string A46MunicipioMicroMesoUFRegSigla ;
      private string A47MunicipioMicroMesoUFRegNome ;
      private string A48MunicipioMicroMesoUFRegSiglaNo ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] H004N2_A35MunicipioID ;
      private int[] H004N2_A37MunicipioMicroID ;
      private string[] H004N2_A48MunicipioMicroMesoUFRegSiglaNo ;
      private bool[] H004N2_n48MunicipioMicroMesoUFRegSiglaNo ;
      private string[] H004N2_A47MunicipioMicroMesoUFRegNome ;
      private bool[] H004N2_n47MunicipioMicroMesoUFRegNome ;
      private string[] H004N2_A46MunicipioMicroMesoUFRegSigla ;
      private bool[] H004N2_n46MunicipioMicroMesoUFRegSigla ;
      private string[] H004N2_A44MunicipioMicroMesoUFSiglaNome ;
      private bool[] H004N2_n44MunicipioMicroMesoUFSiglaNome ;
      private string[] H004N2_A43MunicipioMicroMesoUFNome ;
      private bool[] H004N2_n43MunicipioMicroMesoUFNome ;
      private string[] H004N2_A42MunicipioMicroMesoUFSigla ;
      private bool[] H004N2_n42MunicipioMicroMesoUFSigla ;
      private string[] H004N2_A40MunicipioMicroMesoNome ;
      private bool[] H004N2_n40MunicipioMicroMesoNome ;
      private int[] H004N2_A45MunicipioMicroMesoUFRegID ;
      private bool[] H004N2_n45MunicipioMicroMesoUFRegID ;
      private int[] H004N2_A41MunicipioMicroMesoUFID ;
      private bool[] H004N2_n41MunicipioMicroMesoUFID ;
      private int[] H004N2_A39MunicipioMicroMesoID ;
      private string[] H004N2_A38MunicipioMicroNome ;
      private string[] H004N2_A36MunicipioNome ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV11HTTPRequest ;
      private IGxSession AV10Session ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV8TrnContext ;
   }

   public class municipiogeneral__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH004N2;
          prmH004N2 = new Object[] {
          new ParDef("MunicipioID",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("H004N2", "SELECT MunicipioID, MunicipioMicroID, MunicipioMicroMesoUFRegSiglaNo, MunicipioMicroMesoUFRegNome, MunicipioMicroMesoUFRegSigla, MunicipioMicroMesoUFSiglaNome, MunicipioMicroMesoUFNome, MunicipioMicroMesoUFSigla, MunicipioMicroMesoNome, MunicipioMicroMesoUFRegID, MunicipioMicroMesoUFID, MunicipioMicroMesoID, MunicipioMicroNome, MunicipioNome FROM tbibge_municipio WHERE MunicipioID = :MunicipioID ORDER BY MunicipioID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004N2,1, GxCacheFrequency.OFF ,true,true )
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
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((string[]) buf[8])[0] = rslt.getVarchar(6);
                ((bool[]) buf[9])[0] = rslt.wasNull(6);
                ((string[]) buf[10])[0] = rslt.getVarchar(7);
                ((bool[]) buf[11])[0] = rslt.wasNull(7);
                ((string[]) buf[12])[0] = rslt.getVarchar(8);
                ((bool[]) buf[13])[0] = rslt.wasNull(8);
                ((string[]) buf[14])[0] = rslt.getVarchar(9);
                ((bool[]) buf[15])[0] = rslt.wasNull(9);
                ((int[]) buf[16])[0] = rslt.getInt(10);
                ((bool[]) buf[17])[0] = rslt.wasNull(10);
                ((int[]) buf[18])[0] = rslt.getInt(11);
                ((bool[]) buf[19])[0] = rslt.wasNull(11);
                ((int[]) buf[20])[0] = rslt.getInt(12);
                ((string[]) buf[21])[0] = rslt.getVarchar(13);
                ((string[]) buf[22])[0] = rslt.getVarchar(14);
                return;
       }
    }

 }

}
