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
   public class clientepjcontatogeneral : GXWebComponent
   {
      public clientepjcontatogeneral( )
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

      public clientepjcontatogeneral( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_CliID ,
                           Guid aP1_CpjID ,
                           short aP2_CpjConSeq )
      {
         this.A158CliID = aP0_CliID;
         this.A166CpjID = aP1_CpjID;
         this.A269CpjConSeq = aP2_CpjConSeq;
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
               gxfirstwebparm = GetFirstPar( "CliID");
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
                  A158CliID = StringUtil.StrToGuid( GetPar( "CliID"));
                  AssignAttri(sPrefix, false, "A158CliID", A158CliID.ToString());
                  A166CpjID = StringUtil.StrToGuid( GetPar( "CpjID"));
                  AssignAttri(sPrefix, false, "A166CpjID", A166CpjID.ToString());
                  A269CpjConSeq = (short)(Math.Round(NumberUtil.Val( GetPar( "CpjConSeq"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "A269CpjConSeq", StringUtil.LTrimStr( (decimal)(A269CpjConSeq), 4, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(Guid)A158CliID,(Guid)A166CpjID,(short)A269CpjConSeq});
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
                  gxfirstwebparm = GetFirstPar( "CliID");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "CliID");
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
            PA4T2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV15Pgmname = "core.ClientePJContatoGeneral";
               WS4T2( ) ;
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
            context.SendWebValue( "Cliente PJContato General") ;
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
            GXEncryptionTmp = "core.clientepjcontatogeneral.aspx"+UrlEncode(A158CliID.ToString()) + "," + UrlEncode(A166CpjID.ToString()) + "," + UrlEncode(StringUtil.LTrimStr(A269CpjConSeq,4,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("core.clientepjcontatogeneral.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_UPDATE", AV13IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV13IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_DELETE", AV14IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV14IsAuthorized_Delete, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"ClientePJContatoGeneral");
         forbiddenHiddens.Add("CpjConLIn", StringUtil.RTrim( context.localUtil.Format( A288CpjConLIn, "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("core\\clientepjcontatogeneral:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA158CliID", wcpOA158CliID.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA166CpjID", wcpOA166CpjID.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA269CpjConSeq", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOA269CpjConSeq), 4, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_UPDATE", AV13IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV13IsAuthorized_Update, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"CLIID", A158CliID.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"CPJID", A166CpjID.ToString());
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_DELETE", AV14IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV14IsAuthorized_Delete, context));
      }

      protected void RenderHtmlCloseForm4T2( )
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
         return "core.ClientePJContatoGeneral" ;
      }

      public override string GetPgmdesc( )
      {
         return "Cliente PJContato General" ;
      }

      protected void WB4T0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "core.clientepjcontatogeneral.aspx");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCpjConTipoID_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtCpjConTipoID_Internalname, "Tipo de Contato", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtCpjConTipoID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A270CpjConTipoID), 11, 0, ",", "")), StringUtil.LTrim( ((edtCpjConTipoID_Enabled!=0) ? context.localUtil.Format( (decimal)(A270CpjConTipoID), "ZZZ,ZZZ,ZZ9") : context.localUtil.Format( (decimal)(A270CpjConTipoID), "ZZZ,ZZZ,ZZ9"))), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCpjConTipoID_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCpjConTipoID_Enabled, 0, "text", "", 11, "chr", 1, "row", 11, 0, 0, 0, 0, -1, 0, true, "core\\ID", "end", false, "", "HLP_core\\ClientePJContatoGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCpjConNome_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtCpjConNome_Internalname, "Nome do Contato", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtCpjConNome_Internalname, A275CpjConNome, StringUtil.RTrim( context.localUtil.Format( A275CpjConNome, "@!")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCpjConNome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCpjConNome_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "core\\Nome", "start", true, "", "HLP_core\\ClientePJContatoGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCpjConCPFFormat_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtCpjConCPFFormat_Internalname, "CPF", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtCpjConCPFFormat_Internalname, A274CpjConCPFFormat, StringUtil.RTrim( context.localUtil.Format( A274CpjConCPFFormat, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCpjConCPFFormat_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCpjConCPFFormat_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, -1, true, "core\\CPFFormat", "start", true, "", "HLP_core\\ClientePJContatoGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCpjConNascimento_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtCpjConNascimento_Internalname, "Data de Nascimento", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            context.WriteHtmlText( "<div id=\""+edtCpjConNascimento_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtCpjConNascimento_Internalname, context.localUtil.Format(A282CpjConNascimento, "99/99/99"), context.localUtil.Format( A282CpjConNascimento, "99/99/99"), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCpjConNascimento_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCpjConNascimento_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "core\\Data", "end", false, "", "HLP_core\\ClientePJContatoGeneral.htm");
            GxWebStd.gx_bitmap( context, edtCpjConNascimento_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtCpjConNascimento_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_core\\ClientePJContatoGeneral.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCpjNomeSocial_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtCpjNomeSocial_Internalname, "Como deseja ser chamado", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtCpjNomeSocial_Internalname, A278CpjNomeSocial, StringUtil.RTrim( context.localUtil.Format( A278CpjNomeSocial, "@!")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCpjNomeSocial_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCpjNomeSocial_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "core\\Nome", "start", true, "", "HLP_core\\ClientePJContatoGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCpjConGenNome_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtCpjConGenNome_Internalname, "Gênero", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtCpjConGenNome_Internalname, A281CpjConGenNome, StringUtil.RTrim( context.localUtil.Format( A281CpjConGenNome, "@!")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCpjConGenNome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCpjConGenNome_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "core\\Nome", "start", true, "", "HLP_core\\ClientePJContatoGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCpjConCelNum_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtCpjConCelNum_Internalname, "Celular", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            if ( context.isSmartDevice( ) )
            {
               gxphoneLink = "tel:" + StringUtil.RTrim( A285CpjConCelNum);
            }
            GxWebStd.gx_single_line_edit( context, edtCpjConCelNum_Internalname, StringUtil.RTrim( A285CpjConCelNum), StringUtil.RTrim( context.localUtil.Format( A285CpjConCelNum, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtCpjConCelNum_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCpjConCelNum_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Phone", "start", true, "", "HLP_core\\ClientePJContatoGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCpjConWppNum_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtCpjConWppNum_Internalname, "WhatsApp", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            if ( context.isSmartDevice( ) )
            {
               gxphoneLink = "tel:" + StringUtil.RTrim( A286CpjConWppNum);
            }
            GxWebStd.gx_single_line_edit( context, edtCpjConWppNum_Internalname, StringUtil.RTrim( A286CpjConWppNum), StringUtil.RTrim( context.localUtil.Format( A286CpjConWppNum, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtCpjConWppNum_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCpjConWppNum_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Phone", "start", true, "", "HLP_core\\ClientePJContatoGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCpjConTelNum_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtCpjConTelNum_Internalname, "Telefone", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            if ( context.isSmartDevice( ) )
            {
               gxphoneLink = "tel:" + StringUtil.RTrim( A283CpjConTelNum);
            }
            GxWebStd.gx_single_line_edit( context, edtCpjConTelNum_Internalname, StringUtil.RTrim( A283CpjConTelNum), StringUtil.RTrim( context.localUtil.Format( A283CpjConTelNum, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtCpjConTelNum_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCpjConTelNum_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Phone", "start", true, "", "HLP_core\\ClientePJContatoGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCpjConTelRam_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtCpjConTelRam_Internalname, "Ramal", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtCpjConTelRam_Internalname, A284CpjConTelRam, StringUtil.RTrim( context.localUtil.Format( A284CpjConTelRam, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCpjConTelRam_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCpjConTelRam_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\ClientePJContatoGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCpjConEmail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtCpjConEmail_Internalname, "E-mail", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtCpjConEmail_Internalname, A287CpjConEmail, StringUtil.RTrim( context.localUtil.Format( A287CpjConEmail, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "mailto:"+A287CpjConEmail, "", "", "", edtCpjConEmail_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCpjConEmail_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "start", true, "", "HLP_core\\ClientePJContatoGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCpjConLIn_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtCpjConLIn_Internalname, "LinkedIn", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtCpjConLIn_Internalname, A288CpjConLIn, StringUtil.RTrim( context.localUtil.Format( A288CpjConLIn, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", edtCpjConLIn_Link, edtCpjConLIn_Linktarget, "", "", edtCpjConLIn_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCpjConLIn_Enabled, 0, "url", "", 80, "chr", 1, "row", 1000, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Url", "start", true, "", "HLP_core\\ClientePJContatoGeneral.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group CellMarginTop10", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnupdate_Internalname, "", "Alterar", bttBtnupdate_Jsonclick, 5, "Alterar", "", StyleString, ClassString, bttBtnupdate_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOUPDATE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\ClientePJContatoGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtndelete_Internalname, "", "Excluir", bttBtndelete_Jsonclick, 5, "Excluir", "", StyleString, ClassString, bttBtndelete_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DODELETE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\ClientePJContatoGeneral.htm");
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
            GxWebStd.gx_single_line_edit( context, edtCpjConSeq_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A269CpjConSeq), 4, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A269CpjConSeq), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCpjConSeq_Jsonclick, 0, "Attribute", "", "", "", "", edtCpjConSeq_Visible, 0, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_core\\ClientePJContatoGeneral.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtCpjConTipoSigla_Internalname, A271CpjConTipoSigla, StringUtil.RTrim( context.localUtil.Format( A271CpjConTipoSigla, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCpjConTipoSigla_Jsonclick, 0, "Attribute", "", "", "", "", edtCpjConTipoSigla_Visible, 0, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "core\\Sigla", "start", true, "", "HLP_core\\ClientePJContatoGeneral.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtCpjConCPF_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A273CpjConCPF), 11, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A273CpjConCPF), "ZZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCpjConCPF_Jsonclick, 0, "Attribute", "", "", "", "", edtCpjConCPF_Visible, 0, 0, "text", "1", 11, "chr", 1, "row", 11, 0, 0, 0, 0, -1, 0, true, "core\\CPF", "end", false, "", "HLP_core\\ClientePJContatoGeneral.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtCpjConNomePrim_Internalname, A276CpjConNomePrim, StringUtil.RTrim( context.localUtil.Format( A276CpjConNomePrim, "@!")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCpjConNomePrim_Jsonclick, 0, "Attribute", "", "", "", "", edtCpjConNomePrim_Visible, 0, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "core\\Nome", "start", true, "", "HLP_core\\ClientePJContatoGeneral.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtCpjConSobrenome_Internalname, A277CpjConSobrenome, StringUtil.RTrim( context.localUtil.Format( A277CpjConSobrenome, "@!")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCpjConSobrenome_Jsonclick, 0, "Attribute", "", "", "", "", edtCpjConSobrenome_Visible, 0, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "core\\Nome", "start", true, "", "HLP_core\\ClientePJContatoGeneral.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtCpjConUltEnd_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A328CpjConUltEnd), 4, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A328CpjConUltEnd), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCpjConUltEnd_Jsonclick, 0, "Attribute", "", "", "", "", edtCpjConUltEnd_Visible, 0, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_core\\ClientePJContatoGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START4T2( )
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
               Form.Meta.addItem("description", "Cliente PJContato General", 0) ;
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
               STRUP4T0( ) ;
            }
         }
      }

      protected void WS4T2( )
      {
         START4T2( ) ;
         EVT4T2( ) ;
      }

      protected void EVT4T2( )
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
                                 STRUP4T0( ) ;
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
                                 STRUP4T0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E114T2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4T0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E124T2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOUPDATE'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4T0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoUpdate' */
                                    E134T2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DODELETE'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4T0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoDelete' */
                                    E144T2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4T0( ) ;
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
                                 STRUP4T0( ) ;
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

      protected void WE4T2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm4T2( ) ;
            }
         }
      }

      protected void PA4T2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "core.clientepjcontatogeneral.aspx")), "core.clientepjcontatogeneral.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "core.clientepjcontatogeneral.aspx")))) ;
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
                     gxfirstwebparm = GetFirstPar( "CliID");
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
         RF4T2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV15Pgmname = "core.ClientePJContatoGeneral";
      }

      protected void RF4T2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H004T2 */
            pr_default.execute(0, new Object[] {A158CliID, A166CpjID, A269CpjConSeq});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A328CpjConUltEnd = H004T2_A328CpjConUltEnd[0];
               n328CpjConUltEnd = H004T2_n328CpjConUltEnd[0];
               AssignAttri(sPrefix, false, "A328CpjConUltEnd", StringUtil.LTrimStr( (decimal)(A328CpjConUltEnd), 4, 0));
               A277CpjConSobrenome = H004T2_A277CpjConSobrenome[0];
               AssignAttri(sPrefix, false, "A277CpjConSobrenome", A277CpjConSobrenome);
               A276CpjConNomePrim = H004T2_A276CpjConNomePrim[0];
               AssignAttri(sPrefix, false, "A276CpjConNomePrim", A276CpjConNomePrim);
               A273CpjConCPF = H004T2_A273CpjConCPF[0];
               AssignAttri(sPrefix, false, "A273CpjConCPF", StringUtil.LTrimStr( (decimal)(A273CpjConCPF), 11, 0));
               A271CpjConTipoSigla = H004T2_A271CpjConTipoSigla[0];
               AssignAttri(sPrefix, false, "A271CpjConTipoSigla", A271CpjConTipoSigla);
               A288CpjConLIn = H004T2_A288CpjConLIn[0];
               n288CpjConLIn = H004T2_n288CpjConLIn[0];
               AssignAttri(sPrefix, false, "A288CpjConLIn", A288CpjConLIn);
               A287CpjConEmail = H004T2_A287CpjConEmail[0];
               n287CpjConEmail = H004T2_n287CpjConEmail[0];
               AssignAttri(sPrefix, false, "A287CpjConEmail", A287CpjConEmail);
               A284CpjConTelRam = H004T2_A284CpjConTelRam[0];
               n284CpjConTelRam = H004T2_n284CpjConTelRam[0];
               AssignAttri(sPrefix, false, "A284CpjConTelRam", A284CpjConTelRam);
               A283CpjConTelNum = H004T2_A283CpjConTelNum[0];
               n283CpjConTelNum = H004T2_n283CpjConTelNum[0];
               AssignAttri(sPrefix, false, "A283CpjConTelNum", A283CpjConTelNum);
               A286CpjConWppNum = H004T2_A286CpjConWppNum[0];
               n286CpjConWppNum = H004T2_n286CpjConWppNum[0];
               AssignAttri(sPrefix, false, "A286CpjConWppNum", A286CpjConWppNum);
               A285CpjConCelNum = H004T2_A285CpjConCelNum[0];
               n285CpjConCelNum = H004T2_n285CpjConCelNum[0];
               AssignAttri(sPrefix, false, "A285CpjConCelNum", A285CpjConCelNum);
               A281CpjConGenNome = H004T2_A281CpjConGenNome[0];
               AssignAttri(sPrefix, false, "A281CpjConGenNome", A281CpjConGenNome);
               A278CpjNomeSocial = H004T2_A278CpjNomeSocial[0];
               AssignAttri(sPrefix, false, "A278CpjNomeSocial", A278CpjNomeSocial);
               A282CpjConNascimento = H004T2_A282CpjConNascimento[0];
               AssignAttri(sPrefix, false, "A282CpjConNascimento", context.localUtil.Format(A282CpjConNascimento, "99/99/99"));
               A274CpjConCPFFormat = H004T2_A274CpjConCPFFormat[0];
               AssignAttri(sPrefix, false, "A274CpjConCPFFormat", A274CpjConCPFFormat);
               A275CpjConNome = H004T2_A275CpjConNome[0];
               AssignAttri(sPrefix, false, "A275CpjConNome", A275CpjConNome);
               A270CpjConTipoID = H004T2_A270CpjConTipoID[0];
               AssignAttri(sPrefix, false, "A270CpjConTipoID", StringUtil.LTrimStr( (decimal)(A270CpjConTipoID), 9, 0));
               /* Execute user event: Load */
               E124T2 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            WB4T0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes4T2( )
      {
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_UPDATE", AV13IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV13IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_DELETE", AV14IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV14IsAuthorized_Delete, context));
      }

      protected void before_start_formulas( )
      {
         AV15Pgmname = "core.ClientePJContatoGeneral";
         fix_multi_value_controls( ) ;
      }

      protected void STRUP4T0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E114T2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOA158CliID = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOA158CliID"));
            wcpOA166CpjID = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOA166CpjID"));
            wcpOA269CpjConSeq = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA269CpjConSeq"), ",", "."), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            A270CpjConTipoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtCpjConTipoID_Internalname), ",", "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A270CpjConTipoID", StringUtil.LTrimStr( (decimal)(A270CpjConTipoID), 9, 0));
            A275CpjConNome = StringUtil.Upper( cgiGet( edtCpjConNome_Internalname));
            AssignAttri(sPrefix, false, "A275CpjConNome", A275CpjConNome);
            A274CpjConCPFFormat = cgiGet( edtCpjConCPFFormat_Internalname);
            AssignAttri(sPrefix, false, "A274CpjConCPFFormat", A274CpjConCPFFormat);
            A282CpjConNascimento = context.localUtil.CToD( cgiGet( edtCpjConNascimento_Internalname), 2);
            AssignAttri(sPrefix, false, "A282CpjConNascimento", context.localUtil.Format(A282CpjConNascimento, "99/99/99"));
            A278CpjNomeSocial = StringUtil.Upper( cgiGet( edtCpjNomeSocial_Internalname));
            AssignAttri(sPrefix, false, "A278CpjNomeSocial", A278CpjNomeSocial);
            A281CpjConGenNome = StringUtil.Upper( cgiGet( edtCpjConGenNome_Internalname));
            AssignAttri(sPrefix, false, "A281CpjConGenNome", A281CpjConGenNome);
            A285CpjConCelNum = cgiGet( edtCpjConCelNum_Internalname);
            n285CpjConCelNum = false;
            AssignAttri(sPrefix, false, "A285CpjConCelNum", A285CpjConCelNum);
            A286CpjConWppNum = cgiGet( edtCpjConWppNum_Internalname);
            n286CpjConWppNum = false;
            AssignAttri(sPrefix, false, "A286CpjConWppNum", A286CpjConWppNum);
            A283CpjConTelNum = cgiGet( edtCpjConTelNum_Internalname);
            n283CpjConTelNum = false;
            AssignAttri(sPrefix, false, "A283CpjConTelNum", A283CpjConTelNum);
            A284CpjConTelRam = cgiGet( edtCpjConTelRam_Internalname);
            n284CpjConTelRam = false;
            AssignAttri(sPrefix, false, "A284CpjConTelRam", A284CpjConTelRam);
            A287CpjConEmail = cgiGet( edtCpjConEmail_Internalname);
            n287CpjConEmail = false;
            AssignAttri(sPrefix, false, "A287CpjConEmail", A287CpjConEmail);
            A288CpjConLIn = cgiGet( edtCpjConLIn_Internalname);
            n288CpjConLIn = false;
            AssignAttri(sPrefix, false, "A288CpjConLIn", A288CpjConLIn);
            A271CpjConTipoSigla = cgiGet( edtCpjConTipoSigla_Internalname);
            AssignAttri(sPrefix, false, "A271CpjConTipoSigla", A271CpjConTipoSigla);
            A273CpjConCPF = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtCpjConCPF_Internalname), ",", "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A273CpjConCPF", StringUtil.LTrimStr( (decimal)(A273CpjConCPF), 11, 0));
            A276CpjConNomePrim = StringUtil.Upper( cgiGet( edtCpjConNomePrim_Internalname));
            AssignAttri(sPrefix, false, "A276CpjConNomePrim", A276CpjConNomePrim);
            A277CpjConSobrenome = StringUtil.Upper( cgiGet( edtCpjConSobrenome_Internalname));
            AssignAttri(sPrefix, false, "A277CpjConSobrenome", A277CpjConSobrenome);
            A328CpjConUltEnd = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtCpjConUltEnd_Internalname), ",", "."), 18, MidpointRounding.ToEven));
            n328CpjConUltEnd = false;
            AssignAttri(sPrefix, false, "A328CpjConUltEnd", StringUtil.LTrimStr( (decimal)(A328CpjConUltEnd), 4, 0));
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"ClientePJContatoGeneral");
            A288CpjConLIn = cgiGet( edtCpjConLIn_Internalname);
            n288CpjConLIn = false;
            AssignAttri(sPrefix, false, "A288CpjConLIn", A288CpjConLIn);
            forbiddenHiddens.Add("CpjConLIn", StringUtil.RTrim( context.localUtil.Format( A288CpjConLIn, "")));
            hsh = cgiGet( sPrefix+"hsh");
            if ( ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("core\\clientepjcontatogeneral:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
               GxWebError = 1;
               context.HttpContext.Response.StatusCode = 403;
               context.WriteHtmlText( "<title>403 Forbidden</title>") ;
               context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
               context.WriteHtmlText( "<p /><hr />") ;
               GXUtil.WriteLog("send_http_error_code " + 403.ToString());
               return  ;
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
         E114T2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E114T2( )
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

      protected void E124T2( )
      {
         /* Load Routine */
         returnInSub = false;
         edtCpjConLIn_Linktarget = "_blank";
         AssignProp(sPrefix, false, edtCpjConLIn_Internalname, "Linktarget", edtCpjConLIn_Linktarget, true);
         edtCpjConLIn_Link = A288CpjConLIn;
         AssignProp(sPrefix, false, edtCpjConLIn_Internalname, "Link", edtCpjConLIn_Link, true);
         edtCpjConSeq_Visible = 0;
         AssignProp(sPrefix, false, edtCpjConSeq_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCpjConSeq_Visible), 5, 0), true);
         edtCpjConTipoSigla_Visible = 0;
         AssignProp(sPrefix, false, edtCpjConTipoSigla_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCpjConTipoSigla_Visible), 5, 0), true);
         edtCpjConCPF_Visible = 0;
         AssignProp(sPrefix, false, edtCpjConCPF_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCpjConCPF_Visible), 5, 0), true);
         edtCpjConNomePrim_Visible = 0;
         AssignProp(sPrefix, false, edtCpjConNomePrim_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCpjConNomePrim_Visible), 5, 0), true);
         edtCpjConSobrenome_Visible = 0;
         AssignProp(sPrefix, false, edtCpjConSobrenome_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCpjConSobrenome_Visible), 5, 0), true);
         edtCpjConUltEnd_Visible = 0;
         AssignProp(sPrefix, false, edtCpjConUltEnd_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCpjConUltEnd_Visible), 5, 0), true);
         GXt_boolean1 = AV13IsAuthorized_Update;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "clientepjcontato_Update", out  GXt_boolean1) ;
         AV13IsAuthorized_Update = GXt_boolean1;
         AssignAttri(sPrefix, false, "AV13IsAuthorized_Update", AV13IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV13IsAuthorized_Update, context));
         if ( ! ( AV13IsAuthorized_Update ) )
         {
            bttBtnupdate_Visible = 0;
            AssignProp(sPrefix, false, bttBtnupdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnupdate_Visible), 5, 0), true);
         }
         GXt_boolean1 = AV14IsAuthorized_Delete;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "clientepjcontato_Delete", out  GXt_boolean1) ;
         AV14IsAuthorized_Delete = GXt_boolean1;
         AssignAttri(sPrefix, false, "AV14IsAuthorized_Delete", AV14IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV14IsAuthorized_Delete, context));
         if ( ! ( AV14IsAuthorized_Delete ) )
         {
            bttBtndelete_Visible = 0;
            AssignProp(sPrefix, false, bttBtndelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtndelete_Visible), 5, 0), true);
         }
      }

      protected void E134T2( )
      {
         /* 'DoUpdate' Routine */
         returnInSub = false;
         if ( AV13IsAuthorized_Update )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
               }
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "core.clientepjcontato.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(A158CliID.ToString()) + "," + UrlEncode(A166CpjID.ToString()) + "," + UrlEncode(StringUtil.LTrimStr(A269CpjConSeq,4,0));
            CallWebObject(formatLink("core.clientepjcontato.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem("A ação não encontra-se disponível");
            bttBtnupdate_Visible = 0;
            AssignProp(sPrefix, false, bttBtnupdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnupdate_Visible), 5, 0), true);
         }
         /*  Sending Event outputs  */
      }

      protected void E144T2( )
      {
         /* 'DoDelete' Routine */
         returnInSub = false;
         if ( AV14IsAuthorized_Delete )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
               }
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "core.clientepjcontato.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(A158CliID.ToString()) + "," + UrlEncode(A166CpjID.ToString()) + "," + UrlEncode(StringUtil.LTrimStr(A269CpjConSeq,4,0));
            CallWebObject(formatLink("core.clientepjcontato.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem("A ação não encontra-se disponível");
            bttBtndelete_Visible = 0;
            AssignProp(sPrefix, false, bttBtndelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtndelete_Visible), 5, 0), true);
         }
         /*  Sending Event outputs  */
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV8TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV8TrnContext.gxTpr_Callerobject = AV15Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = false;
         AV8TrnContext.gxTpr_Callerurl = AV11HTTPRequest.ScriptName+"?"+AV11HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "core.ClientePJContato";
         AV10Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A158CliID = (Guid)getParm(obj,0);
         AssignAttri(sPrefix, false, "A158CliID", A158CliID.ToString());
         A166CpjID = (Guid)getParm(obj,1);
         AssignAttri(sPrefix, false, "A166CpjID", A166CpjID.ToString());
         A269CpjConSeq = Convert.ToInt16(getParm(obj,2));
         AssignAttri(sPrefix, false, "A269CpjConSeq", StringUtil.LTrimStr( (decimal)(A269CpjConSeq), 4, 0));
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
         PA4T2( ) ;
         WS4T2( ) ;
         WE4T2( ) ;
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
         sCtrlA158CliID = (string)((string)getParm(obj,0));
         sCtrlA166CpjID = (string)((string)getParm(obj,1));
         sCtrlA269CpjConSeq = (string)((string)getParm(obj,2));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA4T2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "core\\clientepjcontatogeneral", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA4T2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            A158CliID = (Guid)getParm(obj,2);
            AssignAttri(sPrefix, false, "A158CliID", A158CliID.ToString());
            A166CpjID = (Guid)getParm(obj,3);
            AssignAttri(sPrefix, false, "A166CpjID", A166CpjID.ToString());
            A269CpjConSeq = Convert.ToInt16(getParm(obj,4));
            AssignAttri(sPrefix, false, "A269CpjConSeq", StringUtil.LTrimStr( (decimal)(A269CpjConSeq), 4, 0));
         }
         wcpOA158CliID = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOA158CliID"));
         wcpOA166CpjID = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOA166CpjID"));
         wcpOA269CpjConSeq = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA269CpjConSeq"), ",", "."), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( A158CliID != wcpOA158CliID ) || ( A166CpjID != wcpOA166CpjID ) || ( A269CpjConSeq != wcpOA269CpjConSeq ) ) )
         {
            setjustcreated();
         }
         wcpOA158CliID = A158CliID;
         wcpOA166CpjID = A166CpjID;
         wcpOA269CpjConSeq = A269CpjConSeq;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlA158CliID = cgiGet( sPrefix+"A158CliID_CTRL");
         if ( StringUtil.Len( sCtrlA158CliID) > 0 )
         {
            A158CliID = StringUtil.StrToGuid( cgiGet( sCtrlA158CliID));
            AssignAttri(sPrefix, false, "A158CliID", A158CliID.ToString());
         }
         else
         {
            A158CliID = StringUtil.StrToGuid( cgiGet( sPrefix+"A158CliID_PARM"));
         }
         sCtrlA166CpjID = cgiGet( sPrefix+"A166CpjID_CTRL");
         if ( StringUtil.Len( sCtrlA166CpjID) > 0 )
         {
            A166CpjID = StringUtil.StrToGuid( cgiGet( sCtrlA166CpjID));
            AssignAttri(sPrefix, false, "A166CpjID", A166CpjID.ToString());
         }
         else
         {
            A166CpjID = StringUtil.StrToGuid( cgiGet( sPrefix+"A166CpjID_PARM"));
         }
         sCtrlA269CpjConSeq = cgiGet( sPrefix+"A269CpjConSeq_CTRL");
         if ( StringUtil.Len( sCtrlA269CpjConSeq) > 0 )
         {
            A269CpjConSeq = (short)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlA269CpjConSeq), ",", "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A269CpjConSeq", StringUtil.LTrimStr( (decimal)(A269CpjConSeq), 4, 0));
         }
         else
         {
            A269CpjConSeq = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"A269CpjConSeq_PARM"), ",", "."), 18, MidpointRounding.ToEven));
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
         PA4T2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS4T2( ) ;
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
         WS4T2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"A158CliID_PARM", A158CliID.ToString());
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA158CliID)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A158CliID_CTRL", StringUtil.RTrim( sCtrlA158CliID));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"A166CpjID_PARM", A166CpjID.ToString());
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA166CpjID)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A166CpjID_CTRL", StringUtil.RTrim( sCtrlA166CpjID));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"A269CpjConSeq_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(A269CpjConSeq), 4, 0, ",", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA269CpjConSeq)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A269CpjConSeq_CTRL", StringUtil.RTrim( sCtrlA269CpjConSeq));
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
         WE4T2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202382814510", true, true);
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
         context.AddJavascriptSource("core/clientepjcontatogeneral.js", "?202382814511", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtCpjConTipoID_Internalname = sPrefix+"CPJCONTIPOID";
         edtCpjConNome_Internalname = sPrefix+"CPJCONNOME";
         edtCpjConCPFFormat_Internalname = sPrefix+"CPJCONCPFFORMAT";
         edtCpjConNascimento_Internalname = sPrefix+"CPJCONNASCIMENTO";
         edtCpjNomeSocial_Internalname = sPrefix+"CPJNOMESOCIAL";
         edtCpjConGenNome_Internalname = sPrefix+"CPJCONGENNOME";
         edtCpjConCelNum_Internalname = sPrefix+"CPJCONCELNUM";
         edtCpjConWppNum_Internalname = sPrefix+"CPJCONWPPNUM";
         edtCpjConTelNum_Internalname = sPrefix+"CPJCONTELNUM";
         edtCpjConTelRam_Internalname = sPrefix+"CPJCONTELRAM";
         edtCpjConEmail_Internalname = sPrefix+"CPJCONEMAIL";
         edtCpjConLIn_Internalname = sPrefix+"CPJCONLIN";
         divTransactiondetail_tableattributes_Internalname = sPrefix+"TRANSACTIONDETAIL_TABLEATTRIBUTES";
         bttBtnupdate_Internalname = sPrefix+"BTNUPDATE";
         bttBtndelete_Internalname = sPrefix+"BTNDELETE";
         divTable_Internalname = sPrefix+"TABLE";
         edtCpjConSeq_Internalname = sPrefix+"CPJCONSEQ";
         edtCpjConTipoSigla_Internalname = sPrefix+"CPJCONTIPOSIGLA";
         edtCpjConCPF_Internalname = sPrefix+"CPJCONCPF";
         edtCpjConNomePrim_Internalname = sPrefix+"CPJCONNOMEPRIM";
         edtCpjConSobrenome_Internalname = sPrefix+"CPJCONSOBRENOME";
         edtCpjConUltEnd_Internalname = sPrefix+"CPJCONULTEND";
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
         edtCpjConUltEnd_Jsonclick = "";
         edtCpjConUltEnd_Visible = 1;
         edtCpjConSobrenome_Jsonclick = "";
         edtCpjConSobrenome_Visible = 1;
         edtCpjConNomePrim_Jsonclick = "";
         edtCpjConNomePrim_Visible = 1;
         edtCpjConCPF_Jsonclick = "";
         edtCpjConCPF_Visible = 1;
         edtCpjConTipoSigla_Jsonclick = "";
         edtCpjConTipoSigla_Visible = 1;
         edtCpjConSeq_Jsonclick = "";
         edtCpjConSeq_Visible = 1;
         bttBtndelete_Visible = 1;
         bttBtnupdate_Visible = 1;
         edtCpjConLIn_Jsonclick = "";
         edtCpjConLIn_Linktarget = "";
         edtCpjConLIn_Link = "";
         edtCpjConLIn_Enabled = 0;
         edtCpjConEmail_Jsonclick = "";
         edtCpjConEmail_Enabled = 0;
         edtCpjConTelRam_Jsonclick = "";
         edtCpjConTelRam_Enabled = 0;
         edtCpjConTelNum_Jsonclick = "";
         edtCpjConTelNum_Enabled = 0;
         edtCpjConWppNum_Jsonclick = "";
         edtCpjConWppNum_Enabled = 0;
         edtCpjConCelNum_Jsonclick = "";
         edtCpjConCelNum_Enabled = 0;
         edtCpjConGenNome_Jsonclick = "";
         edtCpjConGenNome_Enabled = 0;
         edtCpjNomeSocial_Jsonclick = "";
         edtCpjNomeSocial_Enabled = 0;
         edtCpjConNascimento_Jsonclick = "";
         edtCpjConNascimento_Enabled = 0;
         edtCpjConCPFFormat_Jsonclick = "";
         edtCpjConCPFFormat_Enabled = 0;
         edtCpjConNome_Jsonclick = "";
         edtCpjConNome_Enabled = 0;
         edtCpjConTipoID_Jsonclick = "";
         edtCpjConTipoID_Enabled = 0;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A158CliID',fld:'CLIID',pic:''},{av:'A166CpjID',fld:'CPJID',pic:''},{av:'A269CpjConSeq',fld:'CPJCONSEQ',pic:'ZZZ9'},{av:'AV13IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV14IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'A288CpjConLIn',fld:'CPJCONLIN',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'DOUPDATE'","{handler:'E134T2',iparms:[{av:'AV13IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'A158CliID',fld:'CLIID',pic:''},{av:'A166CpjID',fld:'CPJID',pic:''},{av:'A269CpjConSeq',fld:'CPJCONSEQ',pic:'ZZZ9'}]");
         setEventMetadata("'DOUPDATE'",",oparms:[{ctrl:'BTNUPDATE',prop:'Visible'}]}");
         setEventMetadata("'DODELETE'","{handler:'E144T2',iparms:[{av:'AV14IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'A158CliID',fld:'CLIID',pic:''},{av:'A166CpjID',fld:'CPJID',pic:''},{av:'A269CpjConSeq',fld:'CPJCONSEQ',pic:'ZZZ9'}]");
         setEventMetadata("'DODELETE'",",oparms:[{ctrl:'BTNDELETE',prop:'Visible'}]}");
         setEventMetadata("VALID_CPJCONSEQ","{handler:'Valid_Cpjconseq',iparms:[]");
         setEventMetadata("VALID_CPJCONSEQ",",oparms:[]}");
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
         wcpOA158CliID = Guid.Empty;
         wcpOA166CpjID = Guid.Empty;
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV15Pgmname = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         forbiddenHiddens = new GXProperties();
         A288CpjConLIn = "";
         GX_FocusControl = "";
         A275CpjConNome = "";
         A274CpjConCPFFormat = "";
         A282CpjConNascimento = DateTime.MinValue;
         A278CpjNomeSocial = "";
         A281CpjConGenNome = "";
         gxphoneLink = "";
         A285CpjConCelNum = "";
         A286CpjConWppNum = "";
         A283CpjConTelNum = "";
         A284CpjConTelRam = "";
         A287CpjConEmail = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtnupdate_Jsonclick = "";
         bttBtndelete_Jsonclick = "";
         A271CpjConTipoSigla = "";
         A276CpjConNomePrim = "";
         A277CpjConSobrenome = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         scmdbuf = "";
         H004T2_A158CliID = new Guid[] {Guid.Empty} ;
         H004T2_A166CpjID = new Guid[] {Guid.Empty} ;
         H004T2_A269CpjConSeq = new short[1] ;
         H004T2_A328CpjConUltEnd = new short[1] ;
         H004T2_n328CpjConUltEnd = new bool[] {false} ;
         H004T2_A277CpjConSobrenome = new string[] {""} ;
         H004T2_A276CpjConNomePrim = new string[] {""} ;
         H004T2_A273CpjConCPF = new long[1] ;
         H004T2_A271CpjConTipoSigla = new string[] {""} ;
         H004T2_A288CpjConLIn = new string[] {""} ;
         H004T2_n288CpjConLIn = new bool[] {false} ;
         H004T2_A287CpjConEmail = new string[] {""} ;
         H004T2_n287CpjConEmail = new bool[] {false} ;
         H004T2_A284CpjConTelRam = new string[] {""} ;
         H004T2_n284CpjConTelRam = new bool[] {false} ;
         H004T2_A283CpjConTelNum = new string[] {""} ;
         H004T2_n283CpjConTelNum = new bool[] {false} ;
         H004T2_A286CpjConWppNum = new string[] {""} ;
         H004T2_n286CpjConWppNum = new bool[] {false} ;
         H004T2_A285CpjConCelNum = new string[] {""} ;
         H004T2_n285CpjConCelNum = new bool[] {false} ;
         H004T2_A281CpjConGenNome = new string[] {""} ;
         H004T2_A278CpjNomeSocial = new string[] {""} ;
         H004T2_A282CpjConNascimento = new DateTime[] {DateTime.MinValue} ;
         H004T2_A274CpjConCPFFormat = new string[] {""} ;
         H004T2_A275CpjConNome = new string[] {""} ;
         H004T2_A270CpjConTipoID = new int[1] ;
         hsh = "";
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV8TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV11HTTPRequest = new GxHttpRequest( context);
         AV10Session = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlA158CliID = "";
         sCtrlA166CpjID = "";
         sCtrlA269CpjConSeq = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.clientepjcontatogeneral__default(),
            new Object[][] {
                new Object[] {
               H004T2_A158CliID, H004T2_A166CpjID, H004T2_A269CpjConSeq, H004T2_A328CpjConUltEnd, H004T2_n328CpjConUltEnd, H004T2_A277CpjConSobrenome, H004T2_A276CpjConNomePrim, H004T2_A273CpjConCPF, H004T2_A271CpjConTipoSigla, H004T2_A288CpjConLIn,
               H004T2_n288CpjConLIn, H004T2_A287CpjConEmail, H004T2_n287CpjConEmail, H004T2_A284CpjConTelRam, H004T2_n284CpjConTelRam, H004T2_A283CpjConTelNum, H004T2_n283CpjConTelNum, H004T2_A286CpjConWppNum, H004T2_n286CpjConWppNum, H004T2_A285CpjConCelNum,
               H004T2_n285CpjConCelNum, H004T2_A281CpjConGenNome, H004T2_A278CpjNomeSocial, H004T2_A282CpjConNascimento, H004T2_A274CpjConCPFFormat, H004T2_A275CpjConNome, H004T2_A270CpjConTipoID
               }
            }
         );
         AV15Pgmname = "core.ClientePJContatoGeneral";
         /* GeneXus formulas. */
         AV15Pgmname = "core.ClientePJContatoGeneral";
      }

      private short A269CpjConSeq ;
      private short wcpOA269CpjConSeq ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short initialized ;
      private short wbEnd ;
      private short wbStart ;
      private short A328CpjConUltEnd ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int A270CpjConTipoID ;
      private int edtCpjConTipoID_Enabled ;
      private int edtCpjConNome_Enabled ;
      private int edtCpjConCPFFormat_Enabled ;
      private int edtCpjConNascimento_Enabled ;
      private int edtCpjNomeSocial_Enabled ;
      private int edtCpjConGenNome_Enabled ;
      private int edtCpjConCelNum_Enabled ;
      private int edtCpjConWppNum_Enabled ;
      private int edtCpjConTelNum_Enabled ;
      private int edtCpjConTelRam_Enabled ;
      private int edtCpjConEmail_Enabled ;
      private int edtCpjConLIn_Enabled ;
      private int bttBtnupdate_Visible ;
      private int bttBtndelete_Visible ;
      private int edtCpjConSeq_Visible ;
      private int edtCpjConTipoSigla_Visible ;
      private int edtCpjConCPF_Visible ;
      private int edtCpjConNomePrim_Visible ;
      private int edtCpjConSobrenome_Visible ;
      private int edtCpjConUltEnd_Visible ;
      private int idxLst ;
      private long A273CpjConCPF ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string AV15Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTable_Internalname ;
      private string divTransactiondetail_tableattributes_Internalname ;
      private string edtCpjConTipoID_Internalname ;
      private string edtCpjConTipoID_Jsonclick ;
      private string edtCpjConNome_Internalname ;
      private string edtCpjConNome_Jsonclick ;
      private string edtCpjConCPFFormat_Internalname ;
      private string edtCpjConCPFFormat_Jsonclick ;
      private string edtCpjConNascimento_Internalname ;
      private string edtCpjConNascimento_Jsonclick ;
      private string edtCpjNomeSocial_Internalname ;
      private string edtCpjNomeSocial_Jsonclick ;
      private string edtCpjConGenNome_Internalname ;
      private string edtCpjConGenNome_Jsonclick ;
      private string edtCpjConCelNum_Internalname ;
      private string gxphoneLink ;
      private string A285CpjConCelNum ;
      private string edtCpjConCelNum_Jsonclick ;
      private string edtCpjConWppNum_Internalname ;
      private string A286CpjConWppNum ;
      private string edtCpjConWppNum_Jsonclick ;
      private string edtCpjConTelNum_Internalname ;
      private string A283CpjConTelNum ;
      private string edtCpjConTelNum_Jsonclick ;
      private string edtCpjConTelRam_Internalname ;
      private string edtCpjConTelRam_Jsonclick ;
      private string edtCpjConEmail_Internalname ;
      private string edtCpjConEmail_Jsonclick ;
      private string edtCpjConLIn_Internalname ;
      private string edtCpjConLIn_Link ;
      private string edtCpjConLIn_Linktarget ;
      private string edtCpjConLIn_Jsonclick ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtnupdate_Internalname ;
      private string bttBtnupdate_Jsonclick ;
      private string bttBtndelete_Internalname ;
      private string bttBtndelete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtCpjConSeq_Internalname ;
      private string edtCpjConSeq_Jsonclick ;
      private string edtCpjConTipoSigla_Internalname ;
      private string edtCpjConTipoSigla_Jsonclick ;
      private string edtCpjConCPF_Internalname ;
      private string edtCpjConCPF_Jsonclick ;
      private string edtCpjConNomePrim_Internalname ;
      private string edtCpjConNomePrim_Jsonclick ;
      private string edtCpjConSobrenome_Internalname ;
      private string edtCpjConSobrenome_Jsonclick ;
      private string edtCpjConUltEnd_Internalname ;
      private string edtCpjConUltEnd_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string scmdbuf ;
      private string hsh ;
      private string sCtrlA158CliID ;
      private string sCtrlA166CpjID ;
      private string sCtrlA269CpjConSeq ;
      private DateTime A282CpjConNascimento ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV13IsAuthorized_Update ;
      private bool AV14IsAuthorized_Delete ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool n328CpjConUltEnd ;
      private bool n288CpjConLIn ;
      private bool n287CpjConEmail ;
      private bool n284CpjConTelRam ;
      private bool n283CpjConTelNum ;
      private bool n286CpjConWppNum ;
      private bool n285CpjConCelNum ;
      private bool returnInSub ;
      private bool GXt_boolean1 ;
      private string A288CpjConLIn ;
      private string A275CpjConNome ;
      private string A274CpjConCPFFormat ;
      private string A278CpjNomeSocial ;
      private string A281CpjConGenNome ;
      private string A284CpjConTelRam ;
      private string A287CpjConEmail ;
      private string A271CpjConTipoSigla ;
      private string A276CpjConNomePrim ;
      private string A277CpjConSobrenome ;
      private Guid A158CliID ;
      private Guid A166CpjID ;
      private Guid wcpOA158CliID ;
      private Guid wcpOA166CpjID ;
      private GXProperties forbiddenHiddens ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] H004T2_A158CliID ;
      private Guid[] H004T2_A166CpjID ;
      private short[] H004T2_A269CpjConSeq ;
      private short[] H004T2_A328CpjConUltEnd ;
      private bool[] H004T2_n328CpjConUltEnd ;
      private string[] H004T2_A277CpjConSobrenome ;
      private string[] H004T2_A276CpjConNomePrim ;
      private long[] H004T2_A273CpjConCPF ;
      private string[] H004T2_A271CpjConTipoSigla ;
      private string[] H004T2_A288CpjConLIn ;
      private bool[] H004T2_n288CpjConLIn ;
      private string[] H004T2_A287CpjConEmail ;
      private bool[] H004T2_n287CpjConEmail ;
      private string[] H004T2_A284CpjConTelRam ;
      private bool[] H004T2_n284CpjConTelRam ;
      private string[] H004T2_A283CpjConTelNum ;
      private bool[] H004T2_n283CpjConTelNum ;
      private string[] H004T2_A286CpjConWppNum ;
      private bool[] H004T2_n286CpjConWppNum ;
      private string[] H004T2_A285CpjConCelNum ;
      private bool[] H004T2_n285CpjConCelNum ;
      private string[] H004T2_A281CpjConGenNome ;
      private string[] H004T2_A278CpjNomeSocial ;
      private DateTime[] H004T2_A282CpjConNascimento ;
      private string[] H004T2_A274CpjConCPFFormat ;
      private string[] H004T2_A275CpjConNome ;
      private int[] H004T2_A270CpjConTipoID ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV11HTTPRequest ;
      private IGxSession AV10Session ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV8TrnContext ;
   }

   public class clientepjcontatogeneral__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH004T2;
          prmH004T2 = new Object[] {
          new ParDef("CliID",GXType.UniqueIdentifier,36,0) ,
          new ParDef("CpjID",GXType.UniqueIdentifier,36,0) ,
          new ParDef("CpjConSeq",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H004T2", "SELECT CliID, CpjID, CpjConSeq, CpjConUltEnd, CpjConSobrenome, CpjConNomePrim, CpjConCPF, CpjConTipoSigla, CpjConLIn, CpjConEmail, CpjConTelRam, CpjConTelNum, CpjConWppNum, CpjConCelNum, CpjConGenNome, CpjNomeSocial, CpjConNascimento, CpjConCPFFormat, CpjConNome, CpjConTipoID FROM tb_clientepj_contato WHERE CliID = :CliID and CpjID = :CpjID and CpjConSeq = :CpjConSeq ORDER BY CliID, CpjID, CpjConSeq ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004T2,1, GxCacheFrequency.OFF ,true,true )
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
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((long[]) buf[7])[0] = rslt.getLong(7);
                ((string[]) buf[8])[0] = rslt.getVarchar(8);
                ((string[]) buf[9])[0] = rslt.getVarchar(9);
                ((bool[]) buf[10])[0] = rslt.wasNull(9);
                ((string[]) buf[11])[0] = rslt.getVarchar(10);
                ((bool[]) buf[12])[0] = rslt.wasNull(10);
                ((string[]) buf[13])[0] = rslt.getVarchar(11);
                ((bool[]) buf[14])[0] = rslt.wasNull(11);
                ((string[]) buf[15])[0] = rslt.getString(12, 20);
                ((bool[]) buf[16])[0] = rslt.wasNull(12);
                ((string[]) buf[17])[0] = rslt.getString(13, 20);
                ((bool[]) buf[18])[0] = rslt.wasNull(13);
                ((string[]) buf[19])[0] = rslt.getString(14, 20);
                ((bool[]) buf[20])[0] = rslt.wasNull(14);
                ((string[]) buf[21])[0] = rslt.getVarchar(15);
                ((string[]) buf[22])[0] = rslt.getVarchar(16);
                ((DateTime[]) buf[23])[0] = rslt.getGXDate(17);
                ((string[]) buf[24])[0] = rslt.getVarchar(18);
                ((string[]) buf[25])[0] = rslt.getVarchar(19);
                ((int[]) buf[26])[0] = rslt.getInt(20);
                return;
       }
    }

 }

}
