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
   public class microrregiaogeneral : GXWebComponent
   {
      public microrregiaogeneral( )
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

      public microrregiaogeneral( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_MicrorregiaoID )
      {
         this.A23MicrorregiaoID = aP0_MicrorregiaoID;
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
               gxfirstwebparm = GetFirstPar( "MicrorregiaoID");
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
                  A23MicrorregiaoID = (int)(Math.Round(NumberUtil.Val( GetPar( "MicrorregiaoID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "A23MicrorregiaoID", StringUtil.LTrimStr( (decimal)(A23MicrorregiaoID), 9, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(int)A23MicrorregiaoID});
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
                  gxfirstwebparm = GetFirstPar( "MicrorregiaoID");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "MicrorregiaoID");
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
            PA4J2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV13Pgmname = "core.microrregiaoGeneral";
               WS4J2( ) ;
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
            context.SendWebValue( "microrregiao General") ;
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
               GXEncryptionTmp = "core.microrregiaogeneral.aspx"+UrlEncode(StringUtil.LTrimStr(A23MicrorregiaoID,9,0));
               context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("core.microrregiaogeneral.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA23MicrorregiaoID", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOA23MicrorregiaoID), 9, 0, ",", "")));
      }

      protected void RenderHtmlCloseForm4J2( )
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
         return "core.microrregiaoGeneral" ;
      }

      public override string GetPgmdesc( )
      {
         return "microrregiao General" ;
      }

      protected void WB4J0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "core.microrregiaogeneral.aspx");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMicrorregiaoID_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtMicrorregiaoID_Internalname, "ID", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtMicrorregiaoID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A23MicrorregiaoID), 11, 0, ",", "")), StringUtil.LTrim( ((edtMicrorregiaoID_Enabled!=0) ? context.localUtil.Format( (decimal)(A23MicrorregiaoID), "ZZZ,ZZZ,ZZ9") : context.localUtil.Format( (decimal)(A23MicrorregiaoID), "ZZZ,ZZZ,ZZ9"))), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMicrorregiaoID_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtMicrorregiaoID_Enabled, 0, "text", "", 11, "chr", 1, "row", 11, 0, 0, 0, 0, -1, 0, true, "core\\ID", "end", false, "", "HLP_core\\microrregiaoGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMicrorregiaoNome_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtMicrorregiaoNome_Internalname, "Nome", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtMicrorregiaoNome_Internalname, A24MicrorregiaoNome, StringUtil.RTrim( context.localUtil.Format( A24MicrorregiaoNome, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMicrorregiaoNome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtMicrorregiaoNome_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\microrregiaoGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMicrorregiaoMesoNome_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtMicrorregiaoMesoNome_Internalname, "Mesorregião", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtMicrorregiaoMesoNome_Internalname, A26MicrorregiaoMesoNome, StringUtil.RTrim( context.localUtil.Format( A26MicrorregiaoMesoNome, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", edtMicrorregiaoMesoNome_Link, "", "", "", edtMicrorregiaoMesoNome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtMicrorregiaoMesoNome_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\microrregiaoGeneral.htm");
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
            GxWebStd.gx_single_line_edit( context, edtMicrorregiaoMesoUFID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A27MicrorregiaoMesoUFID), 11, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A27MicrorregiaoMesoUFID), "ZZZ,ZZZ,ZZ9")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMicrorregiaoMesoUFID_Jsonclick, 0, "Attribute", "", "", "", "", edtMicrorregiaoMesoUFID_Visible, 0, 0, "text", "", 11, "chr", 1, "row", 11, 0, 0, 0, 0, -1, 0, true, "core\\ID", "end", false, "", "HLP_core\\microrregiaoGeneral.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtMicrorregiaoMesoUFSigla_Internalname, A28MicrorregiaoMesoUFSigla, StringUtil.RTrim( context.localUtil.Format( A28MicrorregiaoMesoUFSigla, "@!")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMicrorregiaoMesoUFSigla_Jsonclick, 0, "Attribute", "", "", "", "", edtMicrorregiaoMesoUFSigla_Visible, 0, 0, "text", "", 2, "chr", 1, "row", 2, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\microrregiaoGeneral.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtMicrorregiaoMesoUFNome_Internalname, A29MicrorregiaoMesoUFNome, StringUtil.RTrim( context.localUtil.Format( A29MicrorregiaoMesoUFNome, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMicrorregiaoMesoUFNome_Jsonclick, 0, "Attribute", "", "", "", "", edtMicrorregiaoMesoUFNome_Visible, 0, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\microrregiaoGeneral.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtMicrorregiaoMesoUFSiglaNome_Internalname, A30MicrorregiaoMesoUFSiglaNome, StringUtil.RTrim( context.localUtil.Format( A30MicrorregiaoMesoUFSiglaNome, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMicrorregiaoMesoUFSiglaNome_Jsonclick, 0, "Attribute", "", "", "", "", edtMicrorregiaoMesoUFSiglaNome_Visible, 0, 0, "text", "", 70, "chr", 1, "row", 70, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\microrregiaoGeneral.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtMicrorregiaoMesoUFRegID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A31MicrorregiaoMesoUFRegID), 11, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A31MicrorregiaoMesoUFRegID), "ZZZ,ZZZ,ZZ9")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMicrorregiaoMesoUFRegID_Jsonclick, 0, "Attribute", "", "", "", "", edtMicrorregiaoMesoUFRegID_Visible, 0, 0, "text", "", 11, "chr", 1, "row", 11, 0, 0, 0, 0, -1, 0, true, "core\\ID", "end", false, "", "HLP_core\\microrregiaoGeneral.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtMicrorregiaoMesoUFRegSigla_Internalname, A32MicrorregiaoMesoUFRegSigla, StringUtil.RTrim( context.localUtil.Format( A32MicrorregiaoMesoUFRegSigla, "@!")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMicrorregiaoMesoUFRegSigla_Jsonclick, 0, "Attribute", "", "", "", "", edtMicrorregiaoMesoUFRegSigla_Visible, 0, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\microrregiaoGeneral.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtMicrorregiaoMesoUFRegNome_Internalname, A33MicrorregiaoMesoUFRegNome, StringUtil.RTrim( context.localUtil.Format( A33MicrorregiaoMesoUFRegNome, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMicrorregiaoMesoUFRegNome_Jsonclick, 0, "Attribute", "", "", "", "", edtMicrorregiaoMesoUFRegNome_Visible, 0, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\microrregiaoGeneral.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtMicrorregiaoMesoUFRegSiglaNome_Internalname, A34MicrorregiaoMesoUFRegSiglaNome, StringUtil.RTrim( context.localUtil.Format( A34MicrorregiaoMesoUFRegSiglaNome, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMicrorregiaoMesoUFRegSiglaNome_Jsonclick, 0, "Attribute", "", "", "", "", edtMicrorregiaoMesoUFRegSiglaNome_Visible, 0, 0, "text", "", 70, "chr", 1, "row", 70, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\microrregiaoGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START4J2( )
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
               Form.Meta.addItem("description", "microrregiao General", 0) ;
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
               STRUP4J0( ) ;
            }
         }
      }

      protected void WS4J2( )
      {
         START4J2( ) ;
         EVT4J2( ) ;
      }

      protected void EVT4J2( )
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
                                 STRUP4J0( ) ;
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
                                 STRUP4J0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E114J2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4J0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E124J2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4J0( ) ;
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
                                 STRUP4J0( ) ;
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

      protected void WE4J2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm4J2( ) ;
            }
         }
      }

      protected void PA4J2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "core.microrregiaogeneral.aspx")), "core.microrregiaogeneral.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "core.microrregiaogeneral.aspx")))) ;
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
                     gxfirstwebparm = GetFirstPar( "MicrorregiaoID");
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
         RF4J2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV13Pgmname = "core.microrregiaoGeneral";
      }

      protected void RF4J2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H004J2 */
            pr_default.execute(0, new Object[] {A23MicrorregiaoID});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A25MicrorregiaoMesoID = H004J2_A25MicrorregiaoMesoID[0];
               A34MicrorregiaoMesoUFRegSiglaNome = H004J2_A34MicrorregiaoMesoUFRegSiglaNome[0];
               n34MicrorregiaoMesoUFRegSiglaNome = H004J2_n34MicrorregiaoMesoUFRegSiglaNome[0];
               AssignAttri(sPrefix, false, "A34MicrorregiaoMesoUFRegSiglaNome", A34MicrorregiaoMesoUFRegSiglaNome);
               A33MicrorregiaoMesoUFRegNome = H004J2_A33MicrorregiaoMesoUFRegNome[0];
               n33MicrorregiaoMesoUFRegNome = H004J2_n33MicrorregiaoMesoUFRegNome[0];
               AssignAttri(sPrefix, false, "A33MicrorregiaoMesoUFRegNome", A33MicrorregiaoMesoUFRegNome);
               A32MicrorregiaoMesoUFRegSigla = H004J2_A32MicrorregiaoMesoUFRegSigla[0];
               n32MicrorregiaoMesoUFRegSigla = H004J2_n32MicrorregiaoMesoUFRegSigla[0];
               AssignAttri(sPrefix, false, "A32MicrorregiaoMesoUFRegSigla", A32MicrorregiaoMesoUFRegSigla);
               A31MicrorregiaoMesoUFRegID = H004J2_A31MicrorregiaoMesoUFRegID[0];
               n31MicrorregiaoMesoUFRegID = H004J2_n31MicrorregiaoMesoUFRegID[0];
               AssignAttri(sPrefix, false, "A31MicrorregiaoMesoUFRegID", StringUtil.LTrimStr( (decimal)(A31MicrorregiaoMesoUFRegID), 9, 0));
               A30MicrorregiaoMesoUFSiglaNome = H004J2_A30MicrorregiaoMesoUFSiglaNome[0];
               n30MicrorregiaoMesoUFSiglaNome = H004J2_n30MicrorregiaoMesoUFSiglaNome[0];
               AssignAttri(sPrefix, false, "A30MicrorregiaoMesoUFSiglaNome", A30MicrorregiaoMesoUFSiglaNome);
               A29MicrorregiaoMesoUFNome = H004J2_A29MicrorregiaoMesoUFNome[0];
               n29MicrorregiaoMesoUFNome = H004J2_n29MicrorregiaoMesoUFNome[0];
               AssignAttri(sPrefix, false, "A29MicrorregiaoMesoUFNome", A29MicrorregiaoMesoUFNome);
               A28MicrorregiaoMesoUFSigla = H004J2_A28MicrorregiaoMesoUFSigla[0];
               n28MicrorregiaoMesoUFSigla = H004J2_n28MicrorregiaoMesoUFSigla[0];
               AssignAttri(sPrefix, false, "A28MicrorregiaoMesoUFSigla", A28MicrorregiaoMesoUFSigla);
               A27MicrorregiaoMesoUFID = H004J2_A27MicrorregiaoMesoUFID[0];
               AssignAttri(sPrefix, false, "A27MicrorregiaoMesoUFID", StringUtil.LTrimStr( (decimal)(A27MicrorregiaoMesoUFID), 9, 0));
               A26MicrorregiaoMesoNome = H004J2_A26MicrorregiaoMesoNome[0];
               AssignAttri(sPrefix, false, "A26MicrorregiaoMesoNome", A26MicrorregiaoMesoNome);
               A24MicrorregiaoNome = H004J2_A24MicrorregiaoNome[0];
               AssignAttri(sPrefix, false, "A24MicrorregiaoNome", A24MicrorregiaoNome);
               /* Execute user event: Load */
               E124J2 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            WB4J0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes4J2( )
      {
      }

      protected void before_start_formulas( )
      {
         AV13Pgmname = "core.microrregiaoGeneral";
         fix_multi_value_controls( ) ;
      }

      protected void STRUP4J0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E114J2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOA23MicrorregiaoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA23MicrorregiaoID"), ",", "."), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            A24MicrorregiaoNome = cgiGet( edtMicrorregiaoNome_Internalname);
            AssignAttri(sPrefix, false, "A24MicrorregiaoNome", A24MicrorregiaoNome);
            A26MicrorregiaoMesoNome = cgiGet( edtMicrorregiaoMesoNome_Internalname);
            AssignAttri(sPrefix, false, "A26MicrorregiaoMesoNome", A26MicrorregiaoMesoNome);
            A27MicrorregiaoMesoUFID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtMicrorregiaoMesoUFID_Internalname), ",", "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A27MicrorregiaoMesoUFID", StringUtil.LTrimStr( (decimal)(A27MicrorregiaoMesoUFID), 9, 0));
            A28MicrorregiaoMesoUFSigla = StringUtil.Upper( cgiGet( edtMicrorregiaoMesoUFSigla_Internalname));
            n28MicrorregiaoMesoUFSigla = false;
            AssignAttri(sPrefix, false, "A28MicrorregiaoMesoUFSigla", A28MicrorregiaoMesoUFSigla);
            A29MicrorregiaoMesoUFNome = cgiGet( edtMicrorregiaoMesoUFNome_Internalname);
            n29MicrorregiaoMesoUFNome = false;
            AssignAttri(sPrefix, false, "A29MicrorregiaoMesoUFNome", A29MicrorregiaoMesoUFNome);
            A30MicrorregiaoMesoUFSiglaNome = cgiGet( edtMicrorregiaoMesoUFSiglaNome_Internalname);
            n30MicrorregiaoMesoUFSiglaNome = false;
            AssignAttri(sPrefix, false, "A30MicrorregiaoMesoUFSiglaNome", A30MicrorregiaoMesoUFSiglaNome);
            A31MicrorregiaoMesoUFRegID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtMicrorregiaoMesoUFRegID_Internalname), ",", "."), 18, MidpointRounding.ToEven));
            n31MicrorregiaoMesoUFRegID = false;
            AssignAttri(sPrefix, false, "A31MicrorregiaoMesoUFRegID", StringUtil.LTrimStr( (decimal)(A31MicrorregiaoMesoUFRegID), 9, 0));
            A32MicrorregiaoMesoUFRegSigla = StringUtil.Upper( cgiGet( edtMicrorregiaoMesoUFRegSigla_Internalname));
            n32MicrorregiaoMesoUFRegSigla = false;
            AssignAttri(sPrefix, false, "A32MicrorregiaoMesoUFRegSigla", A32MicrorregiaoMesoUFRegSigla);
            A33MicrorregiaoMesoUFRegNome = cgiGet( edtMicrorregiaoMesoUFRegNome_Internalname);
            n33MicrorregiaoMesoUFRegNome = false;
            AssignAttri(sPrefix, false, "A33MicrorregiaoMesoUFRegNome", A33MicrorregiaoMesoUFRegNome);
            A34MicrorregiaoMesoUFRegSiglaNome = cgiGet( edtMicrorregiaoMesoUFRegSiglaNome_Internalname);
            n34MicrorregiaoMesoUFRegSiglaNome = false;
            AssignAttri(sPrefix, false, "A34MicrorregiaoMesoUFRegSiglaNome", A34MicrorregiaoMesoUFRegSiglaNome);
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
         E114J2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E114J2( )
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

      protected void E124J2( )
      {
         /* Load Routine */
         returnInSub = false;
         GXt_boolean1 = AV12TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "mesorregiaoview_Execute", out  GXt_boolean1) ;
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
            GXEncryptionTmp = "core.mesorregiaoview.aspx"+UrlEncode(StringUtil.LTrimStr(A25MicrorregiaoMesoID,9,0)) + "," + UrlEncode(StringUtil.RTrim(""));
            edtMicrorregiaoMesoNome_Link = formatLink("core.mesorregiaoview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            AssignProp(sPrefix, false, edtMicrorregiaoMesoNome_Internalname, "Link", edtMicrorregiaoMesoNome_Link, true);
         }
         edtMicrorregiaoMesoUFID_Visible = 0;
         AssignProp(sPrefix, false, edtMicrorregiaoMesoUFID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMicrorregiaoMesoUFID_Visible), 5, 0), true);
         edtMicrorregiaoMesoUFSigla_Visible = 0;
         AssignProp(sPrefix, false, edtMicrorregiaoMesoUFSigla_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMicrorregiaoMesoUFSigla_Visible), 5, 0), true);
         edtMicrorregiaoMesoUFNome_Visible = 0;
         AssignProp(sPrefix, false, edtMicrorregiaoMesoUFNome_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMicrorregiaoMesoUFNome_Visible), 5, 0), true);
         edtMicrorregiaoMesoUFSiglaNome_Visible = 0;
         AssignProp(sPrefix, false, edtMicrorregiaoMesoUFSiglaNome_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMicrorregiaoMesoUFSiglaNome_Visible), 5, 0), true);
         edtMicrorregiaoMesoUFRegID_Visible = 0;
         AssignProp(sPrefix, false, edtMicrorregiaoMesoUFRegID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMicrorregiaoMesoUFRegID_Visible), 5, 0), true);
         edtMicrorregiaoMesoUFRegSigla_Visible = 0;
         AssignProp(sPrefix, false, edtMicrorregiaoMesoUFRegSigla_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMicrorregiaoMesoUFRegSigla_Visible), 5, 0), true);
         edtMicrorregiaoMesoUFRegNome_Visible = 0;
         AssignProp(sPrefix, false, edtMicrorregiaoMesoUFRegNome_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMicrorregiaoMesoUFRegNome_Visible), 5, 0), true);
         edtMicrorregiaoMesoUFRegSiglaNome_Visible = 0;
         AssignProp(sPrefix, false, edtMicrorregiaoMesoUFRegSiglaNome_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMicrorregiaoMesoUFRegSiglaNome_Visible), 5, 0), true);
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV8TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV8TrnContext.gxTpr_Callerobject = AV13Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = false;
         AV8TrnContext.gxTpr_Callerurl = AV11HTTPRequest.ScriptName+"?"+AV11HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "core.microrregiao";
         AV10Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A23MicrorregiaoID = Convert.ToInt32(getParm(obj,0));
         AssignAttri(sPrefix, false, "A23MicrorregiaoID", StringUtil.LTrimStr( (decimal)(A23MicrorregiaoID), 9, 0));
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
         PA4J2( ) ;
         WS4J2( ) ;
         WE4J2( ) ;
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
         sCtrlA23MicrorregiaoID = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA4J2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "core\\microrregiaogeneral", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA4J2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            A23MicrorregiaoID = Convert.ToInt32(getParm(obj,2));
            AssignAttri(sPrefix, false, "A23MicrorregiaoID", StringUtil.LTrimStr( (decimal)(A23MicrorregiaoID), 9, 0));
         }
         wcpOA23MicrorregiaoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA23MicrorregiaoID"), ",", "."), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( A23MicrorregiaoID != wcpOA23MicrorregiaoID ) ) )
         {
            setjustcreated();
         }
         wcpOA23MicrorregiaoID = A23MicrorregiaoID;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlA23MicrorregiaoID = cgiGet( sPrefix+"A23MicrorregiaoID_CTRL");
         if ( StringUtil.Len( sCtrlA23MicrorregiaoID) > 0 )
         {
            A23MicrorregiaoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlA23MicrorregiaoID), ",", "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A23MicrorregiaoID", StringUtil.LTrimStr( (decimal)(A23MicrorregiaoID), 9, 0));
         }
         else
         {
            A23MicrorregiaoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"A23MicrorregiaoID_PARM"), ",", "."), 18, MidpointRounding.ToEven));
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
         PA4J2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS4J2( ) ;
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
         WS4J2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"A23MicrorregiaoID_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(A23MicrorregiaoID), 9, 0, ",", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA23MicrorregiaoID)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A23MicrorregiaoID_CTRL", StringUtil.RTrim( sCtrlA23MicrorregiaoID));
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
         WE4J2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202382894056", true, true);
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
            context.AddJavascriptSource("core/microrregiaogeneral.js", "?202382894056", false, true);
         }
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtMicrorregiaoID_Internalname = sPrefix+"MICRORREGIAOID";
         edtMicrorregiaoNome_Internalname = sPrefix+"MICRORREGIAONOME";
         edtMicrorregiaoMesoNome_Internalname = sPrefix+"MICRORREGIAOMESONOME";
         divTransactiondetail_tableattributes_Internalname = sPrefix+"TRANSACTIONDETAIL_TABLEATTRIBUTES";
         divTable_Internalname = sPrefix+"TABLE";
         edtMicrorregiaoMesoUFID_Internalname = sPrefix+"MICRORREGIAOMESOUFID";
         edtMicrorregiaoMesoUFSigla_Internalname = sPrefix+"MICRORREGIAOMESOUFSIGLA";
         edtMicrorregiaoMesoUFNome_Internalname = sPrefix+"MICRORREGIAOMESOUFNOME";
         edtMicrorregiaoMesoUFSiglaNome_Internalname = sPrefix+"MICRORREGIAOMESOUFSIGLANOME";
         edtMicrorregiaoMesoUFRegID_Internalname = sPrefix+"MICRORREGIAOMESOUFREGID";
         edtMicrorregiaoMesoUFRegSigla_Internalname = sPrefix+"MICRORREGIAOMESOUFREGSIGLA";
         edtMicrorregiaoMesoUFRegNome_Internalname = sPrefix+"MICRORREGIAOMESOUFREGNOME";
         edtMicrorregiaoMesoUFRegSiglaNome_Internalname = sPrefix+"MICRORREGIAOMESOUFREGSIGLANOME";
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
         edtMicrorregiaoMesoUFRegSiglaNome_Jsonclick = "";
         edtMicrorregiaoMesoUFRegSiglaNome_Visible = 1;
         edtMicrorregiaoMesoUFRegNome_Jsonclick = "";
         edtMicrorregiaoMesoUFRegNome_Visible = 1;
         edtMicrorregiaoMesoUFRegSigla_Jsonclick = "";
         edtMicrorregiaoMesoUFRegSigla_Visible = 1;
         edtMicrorregiaoMesoUFRegID_Jsonclick = "";
         edtMicrorregiaoMesoUFRegID_Visible = 1;
         edtMicrorregiaoMesoUFSiglaNome_Jsonclick = "";
         edtMicrorregiaoMesoUFSiglaNome_Visible = 1;
         edtMicrorregiaoMesoUFNome_Jsonclick = "";
         edtMicrorregiaoMesoUFNome_Visible = 1;
         edtMicrorregiaoMesoUFSigla_Jsonclick = "";
         edtMicrorregiaoMesoUFSigla_Visible = 1;
         edtMicrorregiaoMesoUFID_Jsonclick = "";
         edtMicrorregiaoMesoUFID_Visible = 1;
         edtMicrorregiaoMesoNome_Jsonclick = "";
         edtMicrorregiaoMesoNome_Link = "";
         edtMicrorregiaoMesoNome_Enabled = 0;
         edtMicrorregiaoNome_Jsonclick = "";
         edtMicrorregiaoNome_Enabled = 0;
         edtMicrorregiaoID_Jsonclick = "";
         edtMicrorregiaoID_Enabled = 0;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A23MicrorregiaoID',fld:'MICRORREGIAOID',pic:'ZZZ,ZZZ,ZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("VALID_MICRORREGIAOID","{handler:'Valid_Microrregiaoid',iparms:[]");
         setEventMetadata("VALID_MICRORREGIAOID",",oparms:[]}");
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
         A24MicrorregiaoNome = "";
         A26MicrorregiaoMesoNome = "";
         A28MicrorregiaoMesoUFSigla = "";
         A29MicrorregiaoMesoUFNome = "";
         A30MicrorregiaoMesoUFSiglaNome = "";
         A32MicrorregiaoMesoUFRegSigla = "";
         A33MicrorregiaoMesoUFRegNome = "";
         A34MicrorregiaoMesoUFRegSiglaNome = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         scmdbuf = "";
         H004J2_A23MicrorregiaoID = new int[1] ;
         H004J2_A25MicrorregiaoMesoID = new int[1] ;
         H004J2_A34MicrorregiaoMesoUFRegSiglaNome = new string[] {""} ;
         H004J2_n34MicrorregiaoMesoUFRegSiglaNome = new bool[] {false} ;
         H004J2_A33MicrorregiaoMesoUFRegNome = new string[] {""} ;
         H004J2_n33MicrorregiaoMesoUFRegNome = new bool[] {false} ;
         H004J2_A32MicrorregiaoMesoUFRegSigla = new string[] {""} ;
         H004J2_n32MicrorregiaoMesoUFRegSigla = new bool[] {false} ;
         H004J2_A31MicrorregiaoMesoUFRegID = new int[1] ;
         H004J2_n31MicrorregiaoMesoUFRegID = new bool[] {false} ;
         H004J2_A30MicrorregiaoMesoUFSiglaNome = new string[] {""} ;
         H004J2_n30MicrorregiaoMesoUFSiglaNome = new bool[] {false} ;
         H004J2_A29MicrorregiaoMesoUFNome = new string[] {""} ;
         H004J2_n29MicrorregiaoMesoUFNome = new bool[] {false} ;
         H004J2_A28MicrorregiaoMesoUFSigla = new string[] {""} ;
         H004J2_n28MicrorregiaoMesoUFSigla = new bool[] {false} ;
         H004J2_A27MicrorregiaoMesoUFID = new int[1] ;
         H004J2_A26MicrorregiaoMesoNome = new string[] {""} ;
         H004J2_A24MicrorregiaoNome = new string[] {""} ;
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV8TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV11HTTPRequest = new GxHttpRequest( context);
         AV10Session = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlA23MicrorregiaoID = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.microrregiaogeneral__default(),
            new Object[][] {
                new Object[] {
               H004J2_A23MicrorregiaoID, H004J2_A25MicrorregiaoMesoID, H004J2_A34MicrorregiaoMesoUFRegSiglaNome, H004J2_n34MicrorregiaoMesoUFRegSiglaNome, H004J2_A33MicrorregiaoMesoUFRegNome, H004J2_n33MicrorregiaoMesoUFRegNome, H004J2_A32MicrorregiaoMesoUFRegSigla, H004J2_n32MicrorregiaoMesoUFRegSigla, H004J2_A31MicrorregiaoMesoUFRegID, H004J2_n31MicrorregiaoMesoUFRegID,
               H004J2_A30MicrorregiaoMesoUFSiglaNome, H004J2_n30MicrorregiaoMesoUFSiglaNome, H004J2_A29MicrorregiaoMesoUFNome, H004J2_n29MicrorregiaoMesoUFNome, H004J2_A28MicrorregiaoMesoUFSigla, H004J2_n28MicrorregiaoMesoUFSigla, H004J2_A27MicrorregiaoMesoUFID, H004J2_A26MicrorregiaoMesoNome, H004J2_A24MicrorregiaoNome
               }
            }
         );
         AV13Pgmname = "core.microrregiaoGeneral";
         /* GeneXus formulas. */
         AV13Pgmname = "core.microrregiaoGeneral";
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
      private int A23MicrorregiaoID ;
      private int wcpOA23MicrorregiaoID ;
      private int edtMicrorregiaoID_Enabled ;
      private int edtMicrorregiaoNome_Enabled ;
      private int edtMicrorregiaoMesoNome_Enabled ;
      private int A27MicrorregiaoMesoUFID ;
      private int edtMicrorregiaoMesoUFID_Visible ;
      private int edtMicrorregiaoMesoUFSigla_Visible ;
      private int edtMicrorregiaoMesoUFNome_Visible ;
      private int edtMicrorregiaoMesoUFSiglaNome_Visible ;
      private int A31MicrorregiaoMesoUFRegID ;
      private int edtMicrorregiaoMesoUFRegID_Visible ;
      private int edtMicrorregiaoMesoUFRegSigla_Visible ;
      private int edtMicrorregiaoMesoUFRegNome_Visible ;
      private int edtMicrorregiaoMesoUFRegSiglaNome_Visible ;
      private int A25MicrorregiaoMesoID ;
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
      private string edtMicrorregiaoID_Internalname ;
      private string edtMicrorregiaoID_Jsonclick ;
      private string edtMicrorregiaoNome_Internalname ;
      private string edtMicrorregiaoNome_Jsonclick ;
      private string edtMicrorregiaoMesoNome_Internalname ;
      private string edtMicrorregiaoMesoNome_Link ;
      private string edtMicrorregiaoMesoNome_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtMicrorregiaoMesoUFID_Internalname ;
      private string edtMicrorregiaoMesoUFID_Jsonclick ;
      private string edtMicrorregiaoMesoUFSigla_Internalname ;
      private string edtMicrorregiaoMesoUFSigla_Jsonclick ;
      private string edtMicrorregiaoMesoUFNome_Internalname ;
      private string edtMicrorregiaoMesoUFNome_Jsonclick ;
      private string edtMicrorregiaoMesoUFSiglaNome_Internalname ;
      private string edtMicrorregiaoMesoUFSiglaNome_Jsonclick ;
      private string edtMicrorregiaoMesoUFRegID_Internalname ;
      private string edtMicrorregiaoMesoUFRegID_Jsonclick ;
      private string edtMicrorregiaoMesoUFRegSigla_Internalname ;
      private string edtMicrorregiaoMesoUFRegSigla_Jsonclick ;
      private string edtMicrorregiaoMesoUFRegNome_Internalname ;
      private string edtMicrorregiaoMesoUFRegNome_Jsonclick ;
      private string edtMicrorregiaoMesoUFRegSiglaNome_Internalname ;
      private string edtMicrorregiaoMesoUFRegSiglaNome_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string scmdbuf ;
      private string sCtrlA23MicrorregiaoID ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool n34MicrorregiaoMesoUFRegSiglaNome ;
      private bool n33MicrorregiaoMesoUFRegNome ;
      private bool n32MicrorregiaoMesoUFRegSigla ;
      private bool n31MicrorregiaoMesoUFRegID ;
      private bool n30MicrorregiaoMesoUFSiglaNome ;
      private bool n29MicrorregiaoMesoUFNome ;
      private bool n28MicrorregiaoMesoUFSigla ;
      private bool returnInSub ;
      private bool AV12TempBoolean ;
      private bool GXt_boolean1 ;
      private string A24MicrorregiaoNome ;
      private string A26MicrorregiaoMesoNome ;
      private string A28MicrorregiaoMesoUFSigla ;
      private string A29MicrorregiaoMesoUFNome ;
      private string A30MicrorregiaoMesoUFSiglaNome ;
      private string A32MicrorregiaoMesoUFRegSigla ;
      private string A33MicrorregiaoMesoUFRegNome ;
      private string A34MicrorregiaoMesoUFRegSiglaNome ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] H004J2_A23MicrorregiaoID ;
      private int[] H004J2_A25MicrorregiaoMesoID ;
      private string[] H004J2_A34MicrorregiaoMesoUFRegSiglaNome ;
      private bool[] H004J2_n34MicrorregiaoMesoUFRegSiglaNome ;
      private string[] H004J2_A33MicrorregiaoMesoUFRegNome ;
      private bool[] H004J2_n33MicrorregiaoMesoUFRegNome ;
      private string[] H004J2_A32MicrorregiaoMesoUFRegSigla ;
      private bool[] H004J2_n32MicrorregiaoMesoUFRegSigla ;
      private int[] H004J2_A31MicrorregiaoMesoUFRegID ;
      private bool[] H004J2_n31MicrorregiaoMesoUFRegID ;
      private string[] H004J2_A30MicrorregiaoMesoUFSiglaNome ;
      private bool[] H004J2_n30MicrorregiaoMesoUFSiglaNome ;
      private string[] H004J2_A29MicrorregiaoMesoUFNome ;
      private bool[] H004J2_n29MicrorregiaoMesoUFNome ;
      private string[] H004J2_A28MicrorregiaoMesoUFSigla ;
      private bool[] H004J2_n28MicrorregiaoMesoUFSigla ;
      private int[] H004J2_A27MicrorregiaoMesoUFID ;
      private string[] H004J2_A26MicrorregiaoMesoNome ;
      private string[] H004J2_A24MicrorregiaoNome ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV11HTTPRequest ;
      private IGxSession AV10Session ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV8TrnContext ;
   }

   public class microrregiaogeneral__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH004J2;
          prmH004J2 = new Object[] {
          new ParDef("MicrorregiaoID",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("H004J2", "SELECT MicrorregiaoID, MicrorregiaoMesoID, MicrorregiaoMesoUFRegSiglaNome, MicrorregiaoMesoUFRegNome, MicrorregiaoMesoUFRegSigla, MicrorregiaoMesoUFRegID, MicrorregiaoMesoUFSiglaNome, MicrorregiaoMesoUFNome, MicrorregiaoMesoUFSigla, MicrorregiaoMesoUFID, MicrorregiaoMesoNome, MicrorregiaoNome FROM tbibge_microrregiao WHERE MicrorregiaoID = :MicrorregiaoID ORDER BY MicrorregiaoID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004J2,1, GxCacheFrequency.OFF ,true,true )
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
                ((int[]) buf[8])[0] = rslt.getInt(6);
                ((bool[]) buf[9])[0] = rslt.wasNull(6);
                ((string[]) buf[10])[0] = rslt.getVarchar(7);
                ((bool[]) buf[11])[0] = rslt.wasNull(7);
                ((string[]) buf[12])[0] = rslt.getVarchar(8);
                ((bool[]) buf[13])[0] = rslt.wasNull(8);
                ((string[]) buf[14])[0] = rslt.getVarchar(9);
                ((bool[]) buf[15])[0] = rslt.wasNull(9);
                ((int[]) buf[16])[0] = rslt.getInt(10);
                ((string[]) buf[17])[0] = rslt.getVarchar(11);
                ((string[]) buf[18])[0] = rslt.getVarchar(12);
                return;
       }
    }

 }

}
