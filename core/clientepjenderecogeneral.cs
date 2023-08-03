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
   public class clientepjenderecogeneral : GXWebComponent
   {
      public clientepjenderecogeneral( )
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

      public clientepjenderecogeneral( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_CliID ,
                           Guid aP1_CpjID ,
                           short aP2_CpjEndSeq )
      {
         this.A158CliID = aP0_CliID;
         this.A166CpjID = aP1_CpjID;
         this.A248CpjEndSeq = aP2_CpjEndSeq;
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
                  A248CpjEndSeq = (short)(Math.Round(NumberUtil.Val( GetPar( "CpjEndSeq"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "A248CpjEndSeq", StringUtil.LTrimStr( (decimal)(A248CpjEndSeq), 4, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(Guid)A158CliID,(Guid)A166CpjID,(short)A248CpjEndSeq});
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
            PA412( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV14Pgmname = "core.ClientePJEnderecoGeneral";
               WS412( ) ;
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
            context.SendWebValue( "Cliente PJEndereco General") ;
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
            GXEncryptionTmp = "core.clientepjenderecogeneral.aspx"+UrlEncode(A158CliID.ToString()) + "," + UrlEncode(A166CpjID.ToString()) + "," + UrlEncode(StringUtil.LTrimStr(A248CpjEndSeq,4,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("core.clientepjenderecogeneral.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_UPDATE", AV12IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV12IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_DELETE", AV13IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV13IsAuthorized_Delete, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA158CliID", wcpOA158CliID.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA166CpjID", wcpOA166CpjID.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA248CpjEndSeq", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOA248CpjEndSeq), 4, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_UPDATE", AV12IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV12IsAuthorized_Update, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"CLIID", A158CliID.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"CPJID", A166CpjID.ToString());
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_DELETE", AV13IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV13IsAuthorized_Delete, context));
      }

      protected void RenderHtmlCloseForm412( )
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
         return "core.ClientePJEnderecoGeneral" ;
      }

      public override string GetPgmdesc( )
      {
         return "Cliente PJEndereco General" ;
      }

      protected void WB410( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "core.clientepjenderecogeneral.aspx");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCpjEndNome_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtCpjEndNome_Internalname, "Descri��o", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtCpjEndNome_Internalname, A249CpjEndNome, StringUtil.RTrim( context.localUtil.Format( A249CpjEndNome, "@!")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCpjEndNome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCpjEndNome_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "core\\Nome", "start", true, "", "HLP_core\\ClientePJEnderecoGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCpjEndCepFormat_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtCpjEndCepFormat_Internalname, "CEP", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtCpjEndCepFormat_Internalname, A251CpjEndCepFormat, StringUtil.RTrim( context.localUtil.Format( A251CpjEndCepFormat, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCpjEndCepFormat_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCpjEndCepFormat_Enabled, 0, "text", "", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, -1, true, "core\\CEPFormatado", "start", true, "", "HLP_core\\ClientePJEnderecoGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCpjEndEndereco_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtCpjEndEndereco_Internalname, "Endere�o", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtCpjEndEndereco_Internalname, A252CpjEndEndereco, StringUtil.RTrim( context.localUtil.Format( A252CpjEndEndereco, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCpjEndEndereco_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCpjEndEndereco_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\ClientePJEnderecoGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCpjEndNumero_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtCpjEndNumero_Internalname, "N�mero", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtCpjEndNumero_Internalname, A253CpjEndNumero, StringUtil.RTrim( context.localUtil.Format( A253CpjEndNumero, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCpjEndNumero_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCpjEndNumero_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\ClientePJEnderecoGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCpjEndComplem_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtCpjEndComplem_Internalname, "Complemento", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtCpjEndComplem_Internalname, A254CpjEndComplem, StringUtil.RTrim( context.localUtil.Format( A254CpjEndComplem, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCpjEndComplem_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCpjEndComplem_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\ClientePJEnderecoGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCpjEndBairro_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtCpjEndBairro_Internalname, "Bairro", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtCpjEndBairro_Internalname, A255CpjEndBairro, StringUtil.RTrim( context.localUtil.Format( A255CpjEndBairro, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCpjEndBairro_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCpjEndBairro_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\ClientePJEnderecoGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-8 col-sm-9 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCpjEndMunNome_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtCpjEndMunNome_Internalname, "Munic�pio", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtCpjEndMunNome_Internalname, A257CpjEndMunNome, StringUtil.RTrim( context.localUtil.Format( A257CpjEndMunNome, "@!")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCpjEndMunNome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCpjEndMunNome_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "core\\Nome", "start", true, "", "HLP_core\\ClientePJEnderecoGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-4 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCpjEndUFSigla_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtCpjEndUFSigla_Internalname, "UF", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtCpjEndUFSigla_Internalname, A259CpjEndUFSigla, StringUtil.RTrim( context.localUtil.Format( A259CpjEndUFSigla, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCpjEndUFSigla_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCpjEndUFSigla_Enabled, 0, "text", "", 2, "chr", 1, "row", 2, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\ClientePJEnderecoGeneral.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnupdate_Internalname, "", "Alterar", bttBtnupdate_Jsonclick, 5, "Alterar", "", StyleString, ClassString, bttBtnupdate_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOUPDATE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\ClientePJEnderecoGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtndelete_Internalname, "", "Excluir", bttBtndelete_Jsonclick, 5, "Excluir", "", StyleString, ClassString, bttBtndelete_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DODELETE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\ClientePJEnderecoGeneral.htm");
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
            GxWebStd.gx_single_line_edit( context, edtCpjEndSeq_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A248CpjEndSeq), 4, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A248CpjEndSeq), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCpjEndSeq_Jsonclick, 0, "Attribute", "", "", "", "", edtCpjEndSeq_Visible, 0, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_core\\ClientePJEnderecoGeneral.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtCpjEndCep_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A250CpjEndCep), 8, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A250CpjEndCep), "ZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCpjEndCep_Jsonclick, 0, "Attribute", "", "", "", "", edtCpjEndCep_Visible, 0, 0, "text", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "core\\CEP", "end", false, "", "HLP_core\\ClientePJEnderecoGeneral.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtCpjEndMunID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A256CpjEndMunID), 7, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A256CpjEndMunID), "ZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCpjEndMunID_Jsonclick, 0, "Attribute", "", "", "", "", edtCpjEndMunID_Visible, 0, 0, "text", "1", 7, "chr", 1, "row", 7, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_core\\ClientePJEnderecoGeneral.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtCpjEndUFId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A258CpjEndUFId), 2, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A258CpjEndUFId), "Z9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCpjEndUFId_Jsonclick, 0, "Attribute", "", "", "", "", edtCpjEndUFId_Visible, 0, 0, "text", "1", 2, "chr", 1, "row", 2, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_core\\ClientePJEnderecoGeneral.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtCpjEndUFNome_Internalname, A260CpjEndUFNome, StringUtil.RTrim( context.localUtil.Format( A260CpjEndUFNome, "@!")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCpjEndUFNome_Jsonclick, 0, "Attribute", "", "", "", "", edtCpjEndUFNome_Visible, 0, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "core\\Nome", "start", true, "", "HLP_core\\ClientePJEnderecoGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START412( )
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
               Form.Meta.addItem("description", "Cliente PJEndereco General", 0) ;
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
               STRUP410( ) ;
            }
         }
      }

      protected void WS412( )
      {
         START412( ) ;
         EVT412( ) ;
      }

      protected void EVT412( )
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
                                 STRUP410( ) ;
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
                                 STRUP410( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E11412 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP410( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E12412 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOUPDATE'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP410( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoUpdate' */
                                    E13412 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DODELETE'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP410( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoDelete' */
                                    E14412 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP410( ) ;
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
                                 STRUP410( ) ;
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

      protected void WE412( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm412( ) ;
            }
         }
      }

      protected void PA412( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "core.clientepjenderecogeneral.aspx")), "core.clientepjenderecogeneral.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "core.clientepjenderecogeneral.aspx")))) ;
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
         RF412( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV14Pgmname = "core.ClientePJEnderecoGeneral";
      }

      protected void RF412( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H00412 */
            pr_default.execute(0, new Object[] {A158CliID, A166CpjID, A248CpjEndSeq});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A260CpjEndUFNome = H00412_A260CpjEndUFNome[0];
               AssignAttri(sPrefix, false, "A260CpjEndUFNome", A260CpjEndUFNome);
               A258CpjEndUFId = H00412_A258CpjEndUFId[0];
               AssignAttri(sPrefix, false, "A258CpjEndUFId", StringUtil.LTrimStr( (decimal)(A258CpjEndUFId), 2, 0));
               A256CpjEndMunID = H00412_A256CpjEndMunID[0];
               AssignAttri(sPrefix, false, "A256CpjEndMunID", StringUtil.LTrimStr( (decimal)(A256CpjEndMunID), 7, 0));
               A250CpjEndCep = H00412_A250CpjEndCep[0];
               AssignAttri(sPrefix, false, "A250CpjEndCep", StringUtil.LTrimStr( (decimal)(A250CpjEndCep), 8, 0));
               A259CpjEndUFSigla = H00412_A259CpjEndUFSigla[0];
               AssignAttri(sPrefix, false, "A259CpjEndUFSigla", A259CpjEndUFSigla);
               A257CpjEndMunNome = H00412_A257CpjEndMunNome[0];
               AssignAttri(sPrefix, false, "A257CpjEndMunNome", A257CpjEndMunNome);
               A255CpjEndBairro = H00412_A255CpjEndBairro[0];
               AssignAttri(sPrefix, false, "A255CpjEndBairro", A255CpjEndBairro);
               A254CpjEndComplem = H00412_A254CpjEndComplem[0];
               n254CpjEndComplem = H00412_n254CpjEndComplem[0];
               AssignAttri(sPrefix, false, "A254CpjEndComplem", A254CpjEndComplem);
               A253CpjEndNumero = H00412_A253CpjEndNumero[0];
               AssignAttri(sPrefix, false, "A253CpjEndNumero", A253CpjEndNumero);
               A252CpjEndEndereco = H00412_A252CpjEndEndereco[0];
               AssignAttri(sPrefix, false, "A252CpjEndEndereco", A252CpjEndEndereco);
               A251CpjEndCepFormat = H00412_A251CpjEndCepFormat[0];
               AssignAttri(sPrefix, false, "A251CpjEndCepFormat", A251CpjEndCepFormat);
               A249CpjEndNome = H00412_A249CpjEndNome[0];
               AssignAttri(sPrefix, false, "A249CpjEndNome", A249CpjEndNome);
               /* Execute user event: Load */
               E12412 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            WB410( ) ;
         }
      }

      protected void send_integrity_lvl_hashes412( )
      {
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_UPDATE", AV12IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV12IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_DELETE", AV13IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV13IsAuthorized_Delete, context));
      }

      protected void before_start_formulas( )
      {
         AV14Pgmname = "core.ClientePJEnderecoGeneral";
         fix_multi_value_controls( ) ;
      }

      protected void STRUP410( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11412 ();
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
            wcpOA248CpjEndSeq = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA248CpjEndSeq"), ",", "."), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            A249CpjEndNome = StringUtil.Upper( cgiGet( edtCpjEndNome_Internalname));
            AssignAttri(sPrefix, false, "A249CpjEndNome", A249CpjEndNome);
            A251CpjEndCepFormat = cgiGet( edtCpjEndCepFormat_Internalname);
            AssignAttri(sPrefix, false, "A251CpjEndCepFormat", A251CpjEndCepFormat);
            A252CpjEndEndereco = cgiGet( edtCpjEndEndereco_Internalname);
            AssignAttri(sPrefix, false, "A252CpjEndEndereco", A252CpjEndEndereco);
            A253CpjEndNumero = cgiGet( edtCpjEndNumero_Internalname);
            AssignAttri(sPrefix, false, "A253CpjEndNumero", A253CpjEndNumero);
            A254CpjEndComplem = cgiGet( edtCpjEndComplem_Internalname);
            n254CpjEndComplem = false;
            AssignAttri(sPrefix, false, "A254CpjEndComplem", A254CpjEndComplem);
            A255CpjEndBairro = cgiGet( edtCpjEndBairro_Internalname);
            AssignAttri(sPrefix, false, "A255CpjEndBairro", A255CpjEndBairro);
            A257CpjEndMunNome = StringUtil.Upper( cgiGet( edtCpjEndMunNome_Internalname));
            AssignAttri(sPrefix, false, "A257CpjEndMunNome", A257CpjEndMunNome);
            A259CpjEndUFSigla = cgiGet( edtCpjEndUFSigla_Internalname);
            AssignAttri(sPrefix, false, "A259CpjEndUFSigla", A259CpjEndUFSigla);
            A250CpjEndCep = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtCpjEndCep_Internalname), ",", "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A250CpjEndCep", StringUtil.LTrimStr( (decimal)(A250CpjEndCep), 8, 0));
            A256CpjEndMunID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtCpjEndMunID_Internalname), ",", "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A256CpjEndMunID", StringUtil.LTrimStr( (decimal)(A256CpjEndMunID), 7, 0));
            A258CpjEndUFId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtCpjEndUFId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A258CpjEndUFId", StringUtil.LTrimStr( (decimal)(A258CpjEndUFId), 2, 0));
            A260CpjEndUFNome = StringUtil.Upper( cgiGet( edtCpjEndUFNome_Internalname));
            AssignAttri(sPrefix, false, "A260CpjEndUFNome", A260CpjEndUFNome);
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
         E11412 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E11412( )
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

      protected void E12412( )
      {
         /* Load Routine */
         returnInSub = false;
         edtCpjEndSeq_Visible = 0;
         AssignProp(sPrefix, false, edtCpjEndSeq_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCpjEndSeq_Visible), 5, 0), true);
         edtCpjEndCep_Visible = 0;
         AssignProp(sPrefix, false, edtCpjEndCep_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCpjEndCep_Visible), 5, 0), true);
         edtCpjEndMunID_Visible = 0;
         AssignProp(sPrefix, false, edtCpjEndMunID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCpjEndMunID_Visible), 5, 0), true);
         edtCpjEndUFId_Visible = 0;
         AssignProp(sPrefix, false, edtCpjEndUFId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCpjEndUFId_Visible), 5, 0), true);
         edtCpjEndUFNome_Visible = 0;
         AssignProp(sPrefix, false, edtCpjEndUFNome_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCpjEndUFNome_Visible), 5, 0), true);
         GXt_boolean1 = AV12IsAuthorized_Update;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "clientepjendereco_Update", out  GXt_boolean1) ;
         AV12IsAuthorized_Update = GXt_boolean1;
         AssignAttri(sPrefix, false, "AV12IsAuthorized_Update", AV12IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV12IsAuthorized_Update, context));
         if ( ! ( AV12IsAuthorized_Update ) )
         {
            bttBtnupdate_Visible = 0;
            AssignProp(sPrefix, false, bttBtnupdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnupdate_Visible), 5, 0), true);
         }
         GXt_boolean1 = AV13IsAuthorized_Delete;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "clientepjendereco_Delete", out  GXt_boolean1) ;
         AV13IsAuthorized_Delete = GXt_boolean1;
         AssignAttri(sPrefix, false, "AV13IsAuthorized_Delete", AV13IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV13IsAuthorized_Delete, context));
         if ( ! ( AV13IsAuthorized_Delete ) )
         {
            bttBtndelete_Visible = 0;
            AssignProp(sPrefix, false, bttBtndelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtndelete_Visible), 5, 0), true);
         }
      }

      protected void E13412( )
      {
         /* 'DoUpdate' Routine */
         returnInSub = false;
         if ( AV12IsAuthorized_Update )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
               }
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "core.clientepjendereco.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(A158CliID.ToString()) + "," + UrlEncode(A166CpjID.ToString()) + "," + UrlEncode(StringUtil.LTrimStr(A248CpjEndSeq,4,0));
            CallWebObject(formatLink("core.clientepjendereco.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem("A a��o n�o encontra-se dispon�vel");
            bttBtnupdate_Visible = 0;
            AssignProp(sPrefix, false, bttBtnupdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnupdate_Visible), 5, 0), true);
         }
         /*  Sending Event outputs  */
      }

      protected void E14412( )
      {
         /* 'DoDelete' Routine */
         returnInSub = false;
         if ( AV13IsAuthorized_Delete )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
               }
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "core.clientepjendereco.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(A158CliID.ToString()) + "," + UrlEncode(A166CpjID.ToString()) + "," + UrlEncode(StringUtil.LTrimStr(A248CpjEndSeq,4,0));
            CallWebObject(formatLink("core.clientepjendereco.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem("A a��o n�o encontra-se dispon�vel");
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
         AV8TrnContext.gxTpr_Callerobject = AV14Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = false;
         AV8TrnContext.gxTpr_Callerurl = AV11HTTPRequest.ScriptName+"?"+AV11HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "core.ClientePJEndereco";
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
         A248CpjEndSeq = Convert.ToInt16(getParm(obj,2));
         AssignAttri(sPrefix, false, "A248CpjEndSeq", StringUtil.LTrimStr( (decimal)(A248CpjEndSeq), 4, 0));
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
         PA412( ) ;
         WS412( ) ;
         WE412( ) ;
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
         sCtrlA248CpjEndSeq = (string)((string)getParm(obj,2));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA412( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "core\\clientepjenderecogeneral", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA412( ) ;
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
            A248CpjEndSeq = Convert.ToInt16(getParm(obj,4));
            AssignAttri(sPrefix, false, "A248CpjEndSeq", StringUtil.LTrimStr( (decimal)(A248CpjEndSeq), 4, 0));
         }
         wcpOA158CliID = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOA158CliID"));
         wcpOA166CpjID = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOA166CpjID"));
         wcpOA248CpjEndSeq = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA248CpjEndSeq"), ",", "."), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( A158CliID != wcpOA158CliID ) || ( A166CpjID != wcpOA166CpjID ) || ( A248CpjEndSeq != wcpOA248CpjEndSeq ) ) )
         {
            setjustcreated();
         }
         wcpOA158CliID = A158CliID;
         wcpOA166CpjID = A166CpjID;
         wcpOA248CpjEndSeq = A248CpjEndSeq;
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
         sCtrlA248CpjEndSeq = cgiGet( sPrefix+"A248CpjEndSeq_CTRL");
         if ( StringUtil.Len( sCtrlA248CpjEndSeq) > 0 )
         {
            A248CpjEndSeq = (short)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlA248CpjEndSeq), ",", "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A248CpjEndSeq", StringUtil.LTrimStr( (decimal)(A248CpjEndSeq), 4, 0));
         }
         else
         {
            A248CpjEndSeq = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"A248CpjEndSeq_PARM"), ",", "."), 18, MidpointRounding.ToEven));
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
         PA412( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS412( ) ;
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
         WS412( ) ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"A248CpjEndSeq_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(A248CpjEndSeq), 4, 0, ",", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA248CpjEndSeq)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A248CpjEndSeq_CTRL", StringUtil.RTrim( sCtrlA248CpjEndSeq));
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
         WE412( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2023828142276", true, true);
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
         context.AddJavascriptSource("core/clientepjenderecogeneral.js", "?2023828142276", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtCpjEndNome_Internalname = sPrefix+"CPJENDNOME";
         edtCpjEndCepFormat_Internalname = sPrefix+"CPJENDCEPFORMAT";
         edtCpjEndEndereco_Internalname = sPrefix+"CPJENDENDERECO";
         edtCpjEndNumero_Internalname = sPrefix+"CPJENDNUMERO";
         edtCpjEndComplem_Internalname = sPrefix+"CPJENDCOMPLEM";
         edtCpjEndBairro_Internalname = sPrefix+"CPJENDBAIRRO";
         edtCpjEndMunNome_Internalname = sPrefix+"CPJENDMUNNOME";
         edtCpjEndUFSigla_Internalname = sPrefix+"CPJENDUFSIGLA";
         divTransactiondetail_tableattributes_Internalname = sPrefix+"TRANSACTIONDETAIL_TABLEATTRIBUTES";
         bttBtnupdate_Internalname = sPrefix+"BTNUPDATE";
         bttBtndelete_Internalname = sPrefix+"BTNDELETE";
         divTable_Internalname = sPrefix+"TABLE";
         edtCpjEndSeq_Internalname = sPrefix+"CPJENDSEQ";
         edtCpjEndCep_Internalname = sPrefix+"CPJENDCEP";
         edtCpjEndMunID_Internalname = sPrefix+"CPJENDMUNID";
         edtCpjEndUFId_Internalname = sPrefix+"CPJENDUFID";
         edtCpjEndUFNome_Internalname = sPrefix+"CPJENDUFNOME";
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
         edtCpjEndUFNome_Jsonclick = "";
         edtCpjEndUFNome_Visible = 1;
         edtCpjEndUFId_Jsonclick = "";
         edtCpjEndUFId_Visible = 1;
         edtCpjEndMunID_Jsonclick = "";
         edtCpjEndMunID_Visible = 1;
         edtCpjEndCep_Jsonclick = "";
         edtCpjEndCep_Visible = 1;
         edtCpjEndSeq_Jsonclick = "";
         edtCpjEndSeq_Visible = 1;
         bttBtndelete_Visible = 1;
         bttBtnupdate_Visible = 1;
         edtCpjEndUFSigla_Jsonclick = "";
         edtCpjEndUFSigla_Enabled = 0;
         edtCpjEndMunNome_Jsonclick = "";
         edtCpjEndMunNome_Enabled = 0;
         edtCpjEndBairro_Jsonclick = "";
         edtCpjEndBairro_Enabled = 0;
         edtCpjEndComplem_Jsonclick = "";
         edtCpjEndComplem_Enabled = 0;
         edtCpjEndNumero_Jsonclick = "";
         edtCpjEndNumero_Enabled = 0;
         edtCpjEndEndereco_Jsonclick = "";
         edtCpjEndEndereco_Enabled = 0;
         edtCpjEndCepFormat_Jsonclick = "";
         edtCpjEndCepFormat_Enabled = 0;
         edtCpjEndNome_Jsonclick = "";
         edtCpjEndNome_Enabled = 0;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A158CliID',fld:'CLIID',pic:''},{av:'A166CpjID',fld:'CPJID',pic:''},{av:'A248CpjEndSeq',fld:'CPJENDSEQ',pic:'ZZZ9'},{av:'AV12IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV13IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'DOUPDATE'","{handler:'E13412',iparms:[{av:'AV12IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'A158CliID',fld:'CLIID',pic:''},{av:'A166CpjID',fld:'CPJID',pic:''},{av:'A248CpjEndSeq',fld:'CPJENDSEQ',pic:'ZZZ9'}]");
         setEventMetadata("'DOUPDATE'",",oparms:[{ctrl:'BTNUPDATE',prop:'Visible'}]}");
         setEventMetadata("'DODELETE'","{handler:'E14412',iparms:[{av:'AV13IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'A158CliID',fld:'CLIID',pic:''},{av:'A166CpjID',fld:'CPJID',pic:''},{av:'A248CpjEndSeq',fld:'CPJENDSEQ',pic:'ZZZ9'}]");
         setEventMetadata("'DODELETE'",",oparms:[{ctrl:'BTNDELETE',prop:'Visible'}]}");
         setEventMetadata("VALID_CPJENDSEQ","{handler:'Valid_Cpjendseq',iparms:[]");
         setEventMetadata("VALID_CPJENDSEQ",",oparms:[]}");
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
         AV14Pgmname = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         GX_FocusControl = "";
         A249CpjEndNome = "";
         A251CpjEndCepFormat = "";
         A252CpjEndEndereco = "";
         A253CpjEndNumero = "";
         A254CpjEndComplem = "";
         A255CpjEndBairro = "";
         A257CpjEndMunNome = "";
         A259CpjEndUFSigla = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtnupdate_Jsonclick = "";
         bttBtndelete_Jsonclick = "";
         A260CpjEndUFNome = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         scmdbuf = "";
         H00412_A158CliID = new Guid[] {Guid.Empty} ;
         H00412_A166CpjID = new Guid[] {Guid.Empty} ;
         H00412_A248CpjEndSeq = new short[1] ;
         H00412_A260CpjEndUFNome = new string[] {""} ;
         H00412_A258CpjEndUFId = new short[1] ;
         H00412_A256CpjEndMunID = new int[1] ;
         H00412_A250CpjEndCep = new int[1] ;
         H00412_A259CpjEndUFSigla = new string[] {""} ;
         H00412_A257CpjEndMunNome = new string[] {""} ;
         H00412_A255CpjEndBairro = new string[] {""} ;
         H00412_A254CpjEndComplem = new string[] {""} ;
         H00412_n254CpjEndComplem = new bool[] {false} ;
         H00412_A253CpjEndNumero = new string[] {""} ;
         H00412_A252CpjEndEndereco = new string[] {""} ;
         H00412_A251CpjEndCepFormat = new string[] {""} ;
         H00412_A249CpjEndNome = new string[] {""} ;
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV8TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV11HTTPRequest = new GxHttpRequest( context);
         AV10Session = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlA158CliID = "";
         sCtrlA166CpjID = "";
         sCtrlA248CpjEndSeq = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.clientepjenderecogeneral__default(),
            new Object[][] {
                new Object[] {
               H00412_A158CliID, H00412_A166CpjID, H00412_A248CpjEndSeq, H00412_A260CpjEndUFNome, H00412_A258CpjEndUFId, H00412_A256CpjEndMunID, H00412_A250CpjEndCep, H00412_A259CpjEndUFSigla, H00412_A257CpjEndMunNome, H00412_A255CpjEndBairro,
               H00412_A254CpjEndComplem, H00412_n254CpjEndComplem, H00412_A253CpjEndNumero, H00412_A252CpjEndEndereco, H00412_A251CpjEndCepFormat, H00412_A249CpjEndNome
               }
            }
         );
         AV14Pgmname = "core.ClientePJEnderecoGeneral";
         /* GeneXus formulas. */
         AV14Pgmname = "core.ClientePJEnderecoGeneral";
      }

      private short A248CpjEndSeq ;
      private short wcpOA248CpjEndSeq ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short initialized ;
      private short wbEnd ;
      private short wbStart ;
      private short A258CpjEndUFId ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int edtCpjEndNome_Enabled ;
      private int edtCpjEndCepFormat_Enabled ;
      private int edtCpjEndEndereco_Enabled ;
      private int edtCpjEndNumero_Enabled ;
      private int edtCpjEndComplem_Enabled ;
      private int edtCpjEndBairro_Enabled ;
      private int edtCpjEndMunNome_Enabled ;
      private int edtCpjEndUFSigla_Enabled ;
      private int bttBtnupdate_Visible ;
      private int bttBtndelete_Visible ;
      private int edtCpjEndSeq_Visible ;
      private int A250CpjEndCep ;
      private int edtCpjEndCep_Visible ;
      private int A256CpjEndMunID ;
      private int edtCpjEndMunID_Visible ;
      private int edtCpjEndUFId_Visible ;
      private int edtCpjEndUFNome_Visible ;
      private int idxLst ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string AV14Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTable_Internalname ;
      private string divTransactiondetail_tableattributes_Internalname ;
      private string edtCpjEndNome_Internalname ;
      private string edtCpjEndNome_Jsonclick ;
      private string edtCpjEndCepFormat_Internalname ;
      private string edtCpjEndCepFormat_Jsonclick ;
      private string edtCpjEndEndereco_Internalname ;
      private string edtCpjEndEndereco_Jsonclick ;
      private string edtCpjEndNumero_Internalname ;
      private string edtCpjEndNumero_Jsonclick ;
      private string edtCpjEndComplem_Internalname ;
      private string edtCpjEndComplem_Jsonclick ;
      private string edtCpjEndBairro_Internalname ;
      private string edtCpjEndBairro_Jsonclick ;
      private string edtCpjEndMunNome_Internalname ;
      private string edtCpjEndMunNome_Jsonclick ;
      private string edtCpjEndUFSigla_Internalname ;
      private string edtCpjEndUFSigla_Jsonclick ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtnupdate_Internalname ;
      private string bttBtnupdate_Jsonclick ;
      private string bttBtndelete_Internalname ;
      private string bttBtndelete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtCpjEndSeq_Internalname ;
      private string edtCpjEndSeq_Jsonclick ;
      private string edtCpjEndCep_Internalname ;
      private string edtCpjEndCep_Jsonclick ;
      private string edtCpjEndMunID_Internalname ;
      private string edtCpjEndMunID_Jsonclick ;
      private string edtCpjEndUFId_Internalname ;
      private string edtCpjEndUFId_Jsonclick ;
      private string edtCpjEndUFNome_Internalname ;
      private string edtCpjEndUFNome_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string scmdbuf ;
      private string sCtrlA158CliID ;
      private string sCtrlA166CpjID ;
      private string sCtrlA248CpjEndSeq ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV12IsAuthorized_Update ;
      private bool AV13IsAuthorized_Delete ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool n254CpjEndComplem ;
      private bool returnInSub ;
      private bool GXt_boolean1 ;
      private string A249CpjEndNome ;
      private string A251CpjEndCepFormat ;
      private string A252CpjEndEndereco ;
      private string A253CpjEndNumero ;
      private string A254CpjEndComplem ;
      private string A255CpjEndBairro ;
      private string A257CpjEndMunNome ;
      private string A259CpjEndUFSigla ;
      private string A260CpjEndUFNome ;
      private Guid A158CliID ;
      private Guid A166CpjID ;
      private Guid wcpOA158CliID ;
      private Guid wcpOA166CpjID ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] H00412_A158CliID ;
      private Guid[] H00412_A166CpjID ;
      private short[] H00412_A248CpjEndSeq ;
      private string[] H00412_A260CpjEndUFNome ;
      private short[] H00412_A258CpjEndUFId ;
      private int[] H00412_A256CpjEndMunID ;
      private int[] H00412_A250CpjEndCep ;
      private string[] H00412_A259CpjEndUFSigla ;
      private string[] H00412_A257CpjEndMunNome ;
      private string[] H00412_A255CpjEndBairro ;
      private string[] H00412_A254CpjEndComplem ;
      private bool[] H00412_n254CpjEndComplem ;
      private string[] H00412_A253CpjEndNumero ;
      private string[] H00412_A252CpjEndEndereco ;
      private string[] H00412_A251CpjEndCepFormat ;
      private string[] H00412_A249CpjEndNome ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV11HTTPRequest ;
      private IGxSession AV10Session ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV8TrnContext ;
   }

   public class clientepjenderecogeneral__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH00412;
          prmH00412 = new Object[] {
          new ParDef("CliID",GXType.UniqueIdentifier,36,0) ,
          new ParDef("CpjID",GXType.UniqueIdentifier,36,0) ,
          new ParDef("CpjEndSeq",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00412", "SELECT CliID, CpjID, CpjEndSeq, CpjEndUFNome, CpjEndUFId, CpjEndMunID, CpjEndCep, CpjEndUFSigla, CpjEndMunNome, CpjEndBairro, CpjEndComplem, CpjEndNumero, CpjEndEndereco, CpjEndCepFormat, CpjEndNome FROM tb_clientepj_endereco WHERE CliID = :CliID and CpjID = :CpjID and CpjEndSeq = :CpjEndSeq ORDER BY CliID, CpjID, CpjEndSeq ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00412,1, GxCacheFrequency.OFF ,true,true )
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
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((string[]) buf[10])[0] = rslt.getVarchar(11);
                ((bool[]) buf[11])[0] = rslt.wasNull(11);
                ((string[]) buf[12])[0] = rslt.getVarchar(12);
                ((string[]) buf[13])[0] = rslt.getVarchar(13);
                ((string[]) buf[14])[0] = rslt.getVarchar(14);
                ((string[]) buf[15])[0] = rslt.getVarchar(15);
                return;
       }
    }

 }

}
