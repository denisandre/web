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
   public class negociopjgeneral : GXWebComponent
   {
      public negociopjgeneral( )
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

      public negociopjgeneral( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_NegID )
      {
         this.A345NegID = aP0_NegID;
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
               gxfirstwebparm = GetFirstPar( "NegID");
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
                  A345NegID = StringUtil.StrToGuid( GetPar( "NegID"));
                  AssignAttri(sPrefix, false, "A345NegID", A345NegID.ToString());
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(Guid)A345NegID});
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
                  gxfirstwebparm = GetFirstPar( "NegID");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "NegID");
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
            PA3Y2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV15Pgmname = "core.NegocioPJGeneral";
               WS3Y2( ) ;
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
            context.SendWebValue( "Negocio PJGeneral") ;
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
         context.AddJavascriptSource("CKEditor/ckeditor/ckeditor.js", "", false, true);
         context.AddJavascriptSource("CKEditor/CKEditorRender.js", "", false, true);
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
            GXEncryptionTmp = "core.negociopjgeneral.aspx"+UrlEncode(A345NegID.ToString());
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("core.negociopjgeneral.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"NEGDESCRICAO", A363NegDescricao);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA345NegID", wcpOA345NegID.ToString());
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_UPDATE", AV12IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV12IsAuthorized_Update, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"NEGID", A345NegID.ToString());
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_DELETE", AV13IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV13IsAuthorized_Delete, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"NEGCPJENDENDERECO", A371NegCpjEndEndereco);
         GxWebStd.gx_hidden_field( context, sPrefix+"NEGCPJENDBAIRRO", A374NegCpjEndBairro);
         GxWebStd.gx_hidden_field( context, sPrefix+"NEGCPJENDCEPFORMAT", A643NegCpjEndCepFormat);
         GxWebStd.gx_hidden_field( context, sPrefix+"NEGCPJENDMUNNOME", A376NegCpjEndMunNome);
         GxWebStd.gx_hidden_field( context, sPrefix+"NEGCPJENDUFSIGLA", A378NegCpjEndUFSigla);
         GxWebStd.gx_hidden_field( context, sPrefix+"NEGCPJENDNUMERO", A372NegCpjEndNumero);
         GxWebStd.gx_hidden_field( context, sPrefix+"NEGCPJENDCOMPLEM", A373NegCpjEndComplem);
         GxWebStd.gx_hidden_field( context, sPrefix+"NEGDESCRICAO_Enabled", StringUtil.BoolToStr( Negdescricao_Enabled));
         GxWebStd.gx_hidden_field( context, sPrefix+"NEGDESCRICAO_Width", StringUtil.RTrim( Negdescricao_Width));
         GxWebStd.gx_hidden_field( context, sPrefix+"NEGDESCRICAO_Height", StringUtil.RTrim( Negdescricao_Height));
         GxWebStd.gx_hidden_field( context, sPrefix+"NEGDESCRICAO_Skin", StringUtil.RTrim( Negdescricao_Skin));
         GxWebStd.gx_hidden_field( context, sPrefix+"NEGDESCRICAO_Toolbar", StringUtil.RTrim( Negdescricao_Toolbar));
         GxWebStd.gx_hidden_field( context, sPrefix+"NEGDESCRICAO_Toolbarcancollapse", StringUtil.BoolToStr( Negdescricao_Toolbarcancollapse));
         GxWebStd.gx_hidden_field( context, sPrefix+"NEGDESCRICAO_Color", StringUtil.LTrim( StringUtil.NToC( (decimal)(Negdescricao_Color), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"NEGDESCRICAO_Captionclass", StringUtil.RTrim( Negdescricao_Captionclass));
         GxWebStd.gx_hidden_field( context, sPrefix+"NEGDESCRICAO_Captionstyle", StringUtil.RTrim( Negdescricao_Captionstyle));
         GxWebStd.gx_hidden_field( context, sPrefix+"NEGDESCRICAO_Captionposition", StringUtil.RTrim( Negdescricao_Captionposition));
      }

      protected void RenderHtmlCloseForm3Y2( )
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
         return "core.NegocioPJGeneral" ;
      }

      public override string GetPgmdesc( )
      {
         return "Negocio PJGeneral" ;
      }

      protected void WB3Y0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "core.negociopjgeneral.aspx");
               context.AddJavascriptSource("CKEditor/ckeditor/ckeditor.js", "", false, true);
               context.AddJavascriptSource("CKEditor/CKEditorRender.js", "", false, true);
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNegCodigo_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtNegCodigo_Internalname, "Código da Negociação", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtNegCodigo_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A356NegCodigo), 12, 0, ",", "")), StringUtil.LTrim( ((edtNegCodigo_Enabled!=0) ? context.localUtil.Format( (decimal)(A356NegCodigo), "ZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A356NegCodigo), "ZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNegCodigo_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtNegCodigo_Enabled, 0, "text", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_core\\NegocioPJGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNegCliNomeFamiliar_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtNegCliNomeFamiliar_Internalname, "Cliente", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtNegCliNomeFamiliar_Internalname, A351NegCliNomeFamiliar, StringUtil.RTrim( context.localUtil.Format( A351NegCliNomeFamiliar, "@!")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNegCliNomeFamiliar_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtNegCliNomeFamiliar_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "core\\Nome", "start", true, "", "HLP_core\\NegocioPJGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNegCpjNomFan_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtNegCpjNomFan_Internalname, "Unidade", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtNegCpjNomFan_Internalname, A353NegCpjNomFan, StringUtil.RTrim( context.localUtil.Format( A353NegCpjNomFan, "@!")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNegCpjNomFan_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtNegCpjNomFan_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "core\\Nome", "start", true, "", "HLP_core\\NegocioPJGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNegCpjEndCompleto_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtNegCpjEndCompleto_Internalname, "Endereço", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            ClassString = "AttributeFL";
            StyleString = "";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtNegCpjEndCompleto_Internalname, A641NegCpjEndCompleto, "", "", 0, 1, edtNegCpjEndCompleto_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "1000", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_core\\NegocioPJGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNegAssunto_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtNegAssunto_Internalname, "Assunto", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtNegAssunto_Internalname, A362NegAssunto, StringUtil.RTrim( context.localUtil.Format( A362NegAssunto, "@!")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNegAssunto_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtNegAssunto_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\NegocioPJGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNegValorEstimado_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtNegValorEstimado_Internalname, "Valor Estimado em Negócios", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtNegValorEstimado_Internalname, StringUtil.LTrim( StringUtil.NToC( A380NegValorEstimado, 23, 2, ",", "")), StringUtil.LTrim( ((edtNegValorEstimado_Enabled!=0) ? context.localUtil.Format( A380NegValorEstimado, "R$ Z,ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A380NegValorEstimado, "R$ Z,ZZZ,ZZZ,ZZZ,ZZ9.99"))), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNegValorEstimado_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtNegValorEstimado_Enabled, 0, "text", "", 23, "chr", 1, "row", 23, 0, 0, 0, 0, -1, 0, true, "core\\Monetario", "end", false, "", "HLP_core\\NegocioPJGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* User Defined Control */
            ucNegdescricao.SetProperty("Width", Negdescricao_Width);
            ucNegdescricao.SetProperty("Height", Negdescricao_Height);
            ucNegdescricao.SetProperty("Attribute", NegDescricao);
            ucNegdescricao.SetProperty("Skin", Negdescricao_Skin);
            ucNegdescricao.SetProperty("Toolbar", Negdescricao_Toolbar);
            ucNegdescricao.SetProperty("ToolbarCanCollapse", Negdescricao_Toolbarcancollapse);
            ucNegdescricao.SetProperty("Color", Negdescricao_Color);
            ucNegdescricao.SetProperty("CaptionClass", Negdescricao_Captionclass);
            ucNegdescricao.SetProperty("CaptionStyle", Negdescricao_Captionstyle);
            ucNegdescricao.SetProperty("CaptionPosition", Negdescricao_Captionposition);
            ucNegdescricao.Render(context, "fckeditor", Negdescricao_Internalname, sPrefix+"NEGDESCRICAOContainer");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnupdate_Internalname, "", "Alterar", bttBtnupdate_Jsonclick, 5, "Alterar", "", StyleString, ClassString, bttBtnupdate_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOUPDATE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\NegocioPJGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtndelete_Internalname, "", "Excluir", bttBtndelete_Jsonclick, 5, "Excluir", "", StyleString, ClassString, bttBtndelete_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DODELETE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\NegocioPJGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START3Y2( )
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
               Form.Meta.addItem("description", "Negocio PJGeneral", 0) ;
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
               STRUP3Y0( ) ;
            }
         }
      }

      protected void WS3Y2( )
      {
         START3Y2( ) ;
         EVT3Y2( ) ;
      }

      protected void EVT3Y2( )
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
                                 STRUP3Y0( ) ;
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
                                 STRUP3Y0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E113Y2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3Y0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E123Y2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOUPDATE'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3Y0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoUpdate' */
                                    E133Y2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DODELETE'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3Y0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoDelete' */
                                    E143Y2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3Y0( ) ;
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
                                 STRUP3Y0( ) ;
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

      protected void WE3Y2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm3Y2( ) ;
            }
         }
      }

      protected void PA3Y2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "core.negociopjgeneral.aspx")), "core.negociopjgeneral.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "core.negociopjgeneral.aspx")))) ;
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
                     gxfirstwebparm = GetFirstPar( "NegID");
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
         RF3Y2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV15Pgmname = "core.NegocioPJGeneral";
      }

      protected void RF3Y2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H003Y2 */
            pr_default.execute(0, new Object[] {A345NegID});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A350NegCliID = H003Y2_A350NegCliID[0];
               A352NegCpjID = H003Y2_A352NegCpjID[0];
               A369NegCpjEndSeq = H003Y2_A369NegCpjEndSeq[0];
               A363NegDescricao = H003Y2_A363NegDescricao[0];
               A380NegValorEstimado = H003Y2_A380NegValorEstimado[0];
               AssignAttri(sPrefix, false, "A380NegValorEstimado", StringUtil.LTrimStr( A380NegValorEstimado, 16, 2));
               A362NegAssunto = H003Y2_A362NegAssunto[0];
               AssignAttri(sPrefix, false, "A362NegAssunto", A362NegAssunto);
               A353NegCpjNomFan = H003Y2_A353NegCpjNomFan[0];
               AssignAttri(sPrefix, false, "A353NegCpjNomFan", A353NegCpjNomFan);
               A351NegCliNomeFamiliar = H003Y2_A351NegCliNomeFamiliar[0];
               AssignAttri(sPrefix, false, "A351NegCliNomeFamiliar", A351NegCliNomeFamiliar);
               A356NegCodigo = H003Y2_A356NegCodigo[0];
               AssignAttri(sPrefix, false, "A356NegCodigo", StringUtil.LTrimStr( (decimal)(A356NegCodigo), 12, 0));
               A373NegCpjEndComplem = H003Y2_A373NegCpjEndComplem[0];
               n373NegCpjEndComplem = H003Y2_n373NegCpjEndComplem[0];
               A372NegCpjEndNumero = H003Y2_A372NegCpjEndNumero[0];
               A378NegCpjEndUFSigla = H003Y2_A378NegCpjEndUFSigla[0];
               A376NegCpjEndMunNome = H003Y2_A376NegCpjEndMunNome[0];
               A643NegCpjEndCepFormat = H003Y2_A643NegCpjEndCepFormat[0];
               A374NegCpjEndBairro = H003Y2_A374NegCpjEndBairro[0];
               A371NegCpjEndEndereco = H003Y2_A371NegCpjEndEndereco[0];
               A373NegCpjEndComplem = H003Y2_A373NegCpjEndComplem[0];
               n373NegCpjEndComplem = H003Y2_n373NegCpjEndComplem[0];
               A372NegCpjEndNumero = H003Y2_A372NegCpjEndNumero[0];
               A378NegCpjEndUFSigla = H003Y2_A378NegCpjEndUFSigla[0];
               A376NegCpjEndMunNome = H003Y2_A376NegCpjEndMunNome[0];
               A643NegCpjEndCepFormat = H003Y2_A643NegCpjEndCepFormat[0];
               A374NegCpjEndBairro = H003Y2_A374NegCpjEndBairro[0];
               A371NegCpjEndEndereco = H003Y2_A371NegCpjEndEndereco[0];
               if ( String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A372NegCpjEndNumero))) && String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A373NegCpjEndComplem))) )
               {
                  A641NegCpjEndCompleto = StringUtil.Trim( A371NegCpjEndEndereco) + " - " + StringUtil.Trim( A374NegCpjEndBairro) + " - " + StringUtil.Trim( A643NegCpjEndCepFormat) + " - " + StringUtil.Trim( A376NegCpjEndMunNome) + " - " + StringUtil.Trim( A378NegCpjEndUFSigla);
                  AssignAttri(sPrefix, false, "A641NegCpjEndCompleto", A641NegCpjEndCompleto);
               }
               else
               {
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A372NegCpjEndNumero))) && String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A373NegCpjEndComplem))) )
                  {
                     A641NegCpjEndCompleto = StringUtil.Trim( A371NegCpjEndEndereco) + ", " + StringUtil.Trim( A372NegCpjEndNumero) + " - " + StringUtil.Trim( A374NegCpjEndBairro) + " - " + StringUtil.Trim( A643NegCpjEndCepFormat) + " - " + StringUtil.Trim( A376NegCpjEndMunNome) + " - " + StringUtil.Trim( A378NegCpjEndUFSigla);
                     AssignAttri(sPrefix, false, "A641NegCpjEndCompleto", A641NegCpjEndCompleto);
                  }
                  else
                  {
                     if ( String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A372NegCpjEndNumero))) && ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A373NegCpjEndComplem))) )
                     {
                        A641NegCpjEndCompleto = StringUtil.Trim( A371NegCpjEndEndereco) + ", " + StringUtil.Trim( A372NegCpjEndNumero) + " - " + StringUtil.Trim( A374NegCpjEndBairro) + " - " + StringUtil.Trim( A643NegCpjEndCepFormat) + " - " + StringUtil.Trim( A376NegCpjEndMunNome) + " - " + StringUtil.Trim( A378NegCpjEndUFSigla);
                        AssignAttri(sPrefix, false, "A641NegCpjEndCompleto", A641NegCpjEndCompleto);
                     }
                     else
                     {
                        A641NegCpjEndCompleto = StringUtil.Trim( A371NegCpjEndEndereco) + ", " + StringUtil.Trim( A372NegCpjEndNumero) + " " + StringUtil.Trim( A373NegCpjEndComplem) + " - " + StringUtil.Trim( A374NegCpjEndBairro) + " - " + StringUtil.Trim( A643NegCpjEndCepFormat) + " - " + StringUtil.Trim( A376NegCpjEndMunNome) + " - " + StringUtil.Trim( A378NegCpjEndUFSigla);
                        AssignAttri(sPrefix, false, "A641NegCpjEndCompleto", A641NegCpjEndCompleto);
                     }
                  }
               }
               /* Execute user event: Load */
               E123Y2 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            WB3Y0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes3Y2( )
      {
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_UPDATE", AV12IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV12IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_DELETE", AV13IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV13IsAuthorized_Delete, context));
      }

      protected void before_start_formulas( )
      {
         AV15Pgmname = "core.NegocioPJGeneral";
         fix_multi_value_controls( ) ;
      }

      protected void STRUP3Y0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E113Y2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            A363NegDescricao = cgiGet( sPrefix+"NEGDESCRICAO");
            wcpOA345NegID = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOA345NegID"));
            Negdescricao_Enabled = StringUtil.StrToBool( cgiGet( sPrefix+"NEGDESCRICAO_Enabled"));
            Negdescricao_Width = cgiGet( sPrefix+"NEGDESCRICAO_Width");
            Negdescricao_Height = cgiGet( sPrefix+"NEGDESCRICAO_Height");
            Negdescricao_Skin = cgiGet( sPrefix+"NEGDESCRICAO_Skin");
            Negdescricao_Toolbar = cgiGet( sPrefix+"NEGDESCRICAO_Toolbar");
            Negdescricao_Toolbarcancollapse = StringUtil.StrToBool( cgiGet( sPrefix+"NEGDESCRICAO_Toolbarcancollapse"));
            Negdescricao_Color = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"NEGDESCRICAO_Color"), ",", "."), 18, MidpointRounding.ToEven));
            Negdescricao_Captionclass = cgiGet( sPrefix+"NEGDESCRICAO_Captionclass");
            Negdescricao_Captionstyle = cgiGet( sPrefix+"NEGDESCRICAO_Captionstyle");
            Negdescricao_Captionposition = cgiGet( sPrefix+"NEGDESCRICAO_Captionposition");
            /* Read variables values. */
            A356NegCodigo = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtNegCodigo_Internalname), ",", "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A356NegCodigo", StringUtil.LTrimStr( (decimal)(A356NegCodigo), 12, 0));
            A351NegCliNomeFamiliar = StringUtil.Upper( cgiGet( edtNegCliNomeFamiliar_Internalname));
            AssignAttri(sPrefix, false, "A351NegCliNomeFamiliar", A351NegCliNomeFamiliar);
            A353NegCpjNomFan = StringUtil.Upper( cgiGet( edtNegCpjNomFan_Internalname));
            AssignAttri(sPrefix, false, "A353NegCpjNomFan", A353NegCpjNomFan);
            A641NegCpjEndCompleto = cgiGet( edtNegCpjEndCompleto_Internalname);
            AssignAttri(sPrefix, false, "A641NegCpjEndCompleto", A641NegCpjEndCompleto);
            A362NegAssunto = StringUtil.Upper( cgiGet( edtNegAssunto_Internalname));
            AssignAttri(sPrefix, false, "A362NegAssunto", A362NegAssunto);
            A380NegValorEstimado = context.localUtil.CToN( cgiGet( edtNegValorEstimado_Internalname), ",", ".");
            AssignAttri(sPrefix, false, "A380NegValorEstimado", StringUtil.LTrimStr( A380NegValorEstimado, 16, 2));
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
         E113Y2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E113Y2( )
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

      protected void E123Y2( )
      {
         /* Load Routine */
         returnInSub = false;
         GXt_boolean1 = AV12IsAuthorized_Update;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "negocio_Update", out  GXt_boolean1) ;
         AV12IsAuthorized_Update = GXt_boolean1;
         AssignAttri(sPrefix, false, "AV12IsAuthorized_Update", AV12IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV12IsAuthorized_Update, context));
         if ( ! ( AV12IsAuthorized_Update ) )
         {
            bttBtnupdate_Visible = 0;
            AssignProp(sPrefix, false, bttBtnupdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnupdate_Visible), 5, 0), true);
         }
         GXt_boolean1 = AV13IsAuthorized_Delete;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "negocio_Delete", out  GXt_boolean1) ;
         AV13IsAuthorized_Delete = GXt_boolean1;
         AssignAttri(sPrefix, false, "AV13IsAuthorized_Delete", AV13IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV13IsAuthorized_Delete, context));
         if ( ! ( AV13IsAuthorized_Delete ) )
         {
            bttBtndelete_Visible = 0;
            AssignProp(sPrefix, false, bttBtndelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtndelete_Visible), 5, 0), true);
         }
      }

      protected void E133Y2( )
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
            GXEncryptionTmp = "core.negociopj.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(A345NegID.ToString());
            CallWebObject(formatLink("core.negociopj.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
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

      protected void E143Y2( )
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
            GXEncryptionTmp = "core.negociopj.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(A345NegID.ToString());
            CallWebObject(formatLink("core.negociopj.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
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
         AV8TrnContext.gxTpr_Transactionname = "core.NegocioPJ";
         AV10Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A345NegID = (Guid)getParm(obj,0);
         AssignAttri(sPrefix, false, "A345NegID", A345NegID.ToString());
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
         PA3Y2( ) ;
         WS3Y2( ) ;
         WE3Y2( ) ;
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
         sCtrlA345NegID = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA3Y2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "core\\negociopjgeneral", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA3Y2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            A345NegID = (Guid)getParm(obj,2);
            AssignAttri(sPrefix, false, "A345NegID", A345NegID.ToString());
         }
         wcpOA345NegID = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOA345NegID"));
         if ( ! GetJustCreated( ) && ( ( A345NegID != wcpOA345NegID ) ) )
         {
            setjustcreated();
         }
         wcpOA345NegID = A345NegID;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlA345NegID = cgiGet( sPrefix+"A345NegID_CTRL");
         if ( StringUtil.Len( sCtrlA345NegID) > 0 )
         {
            A345NegID = StringUtil.StrToGuid( cgiGet( sCtrlA345NegID));
            AssignAttri(sPrefix, false, "A345NegID", A345NegID.ToString());
         }
         else
         {
            A345NegID = StringUtil.StrToGuid( cgiGet( sPrefix+"A345NegID_PARM"));
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
         PA3Y2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS3Y2( ) ;
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
         WS3Y2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"A345NegID_PARM", A345NegID.ToString());
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA345NegID)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A345NegID_CTRL", StringUtil.RTrim( sCtrlA345NegID));
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
         WE3Y2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2023828142380", true, true);
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
         context.AddJavascriptSource("core/negociopjgeneral.js", "?2023828142380", false, true);
         context.AddJavascriptSource("CKEditor/ckeditor/ckeditor.js", "", false, true);
         context.AddJavascriptSource("CKEditor/CKEditorRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtNegCodigo_Internalname = sPrefix+"NEGCODIGO";
         edtNegCliNomeFamiliar_Internalname = sPrefix+"NEGCLINOMEFAMILIAR";
         edtNegCpjNomFan_Internalname = sPrefix+"NEGCPJNOMFAN";
         edtNegCpjEndCompleto_Internalname = sPrefix+"NEGCPJENDCOMPLETO";
         edtNegAssunto_Internalname = sPrefix+"NEGASSUNTO";
         edtNegValorEstimado_Internalname = sPrefix+"NEGVALORESTIMADO";
         Negdescricao_Internalname = sPrefix+"NEGDESCRICAO";
         divTransactiondetail_tableattributes_Internalname = sPrefix+"TRANSACTIONDETAIL_TABLEATTRIBUTES";
         bttBtnupdate_Internalname = sPrefix+"BTNUPDATE";
         bttBtndelete_Internalname = sPrefix+"BTNDELETE";
         divTable_Internalname = sPrefix+"TABLE";
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
         bttBtndelete_Visible = 1;
         bttBtnupdate_Visible = 1;
         Negdescricao_Enabled = Convert.ToBoolean( 0);
         edtNegValorEstimado_Jsonclick = "";
         edtNegValorEstimado_Enabled = 0;
         edtNegAssunto_Jsonclick = "";
         edtNegAssunto_Enabled = 0;
         edtNegCpjEndCompleto_Enabled = 0;
         edtNegCpjNomFan_Jsonclick = "";
         edtNegCpjNomFan_Enabled = 0;
         edtNegCliNomeFamiliar_Jsonclick = "";
         edtNegCliNomeFamiliar_Enabled = 0;
         edtNegCodigo_Jsonclick = "";
         edtNegCodigo_Enabled = 0;
         Negdescricao_Captionposition = "None";
         Negdescricao_Captionstyle = "";
         Negdescricao_Captionclass = "col-sm-3 AttributeLabel";
         Negdescricao_Color = (int)(0xD3D3D3);
         Negdescricao_Toolbarcancollapse = Convert.ToBoolean( -1);
         Negdescricao_Toolbar = "Default";
         Negdescricao_Skin = "silver";
         Negdescricao_Height = "400";
         Negdescricao_Width = "100%";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A345NegID',fld:'NEGID',pic:''},{av:'AV12IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV13IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'DOUPDATE'","{handler:'E133Y2',iparms:[{av:'AV12IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'A345NegID',fld:'NEGID',pic:''}]");
         setEventMetadata("'DOUPDATE'",",oparms:[{ctrl:'BTNUPDATE',prop:'Visible'}]}");
         setEventMetadata("'DODELETE'","{handler:'E143Y2',iparms:[{av:'AV13IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'A345NegID',fld:'NEGID',pic:''}]");
         setEventMetadata("'DODELETE'",",oparms:[{ctrl:'BTNDELETE',prop:'Visible'}]}");
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
         wcpOA345NegID = Guid.Empty;
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV15Pgmname = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         A363NegDescricao = "";
         A371NegCpjEndEndereco = "";
         A374NegCpjEndBairro = "";
         A643NegCpjEndCepFormat = "";
         A376NegCpjEndMunNome = "";
         A378NegCpjEndUFSigla = "";
         A372NegCpjEndNumero = "";
         A373NegCpjEndComplem = "";
         GX_FocusControl = "";
         A351NegCliNomeFamiliar = "";
         A353NegCpjNomFan = "";
         ClassString = "";
         StyleString = "";
         A641NegCpjEndCompleto = "";
         A362NegAssunto = "";
         ucNegdescricao = new GXUserControl();
         NegDescricao = "";
         TempTags = "";
         bttBtnupdate_Jsonclick = "";
         bttBtndelete_Jsonclick = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         scmdbuf = "";
         H003Y2_A350NegCliID = new Guid[] {Guid.Empty} ;
         H003Y2_A352NegCpjID = new Guid[] {Guid.Empty} ;
         H003Y2_A369NegCpjEndSeq = new short[1] ;
         H003Y2_A345NegID = new Guid[] {Guid.Empty} ;
         H003Y2_A363NegDescricao = new string[] {""} ;
         H003Y2_A380NegValorEstimado = new decimal[1] ;
         H003Y2_A362NegAssunto = new string[] {""} ;
         H003Y2_A353NegCpjNomFan = new string[] {""} ;
         H003Y2_A351NegCliNomeFamiliar = new string[] {""} ;
         H003Y2_A356NegCodigo = new long[1] ;
         H003Y2_A373NegCpjEndComplem = new string[] {""} ;
         H003Y2_n373NegCpjEndComplem = new bool[] {false} ;
         H003Y2_A372NegCpjEndNumero = new string[] {""} ;
         H003Y2_A378NegCpjEndUFSigla = new string[] {""} ;
         H003Y2_A376NegCpjEndMunNome = new string[] {""} ;
         H003Y2_A643NegCpjEndCepFormat = new string[] {""} ;
         H003Y2_A374NegCpjEndBairro = new string[] {""} ;
         H003Y2_A371NegCpjEndEndereco = new string[] {""} ;
         A350NegCliID = Guid.Empty;
         A352NegCpjID = Guid.Empty;
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV8TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV11HTTPRequest = new GxHttpRequest( context);
         AV10Session = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlA345NegID = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.negociopjgeneral__default(),
            new Object[][] {
                new Object[] {
               H003Y2_A350NegCliID, H003Y2_A352NegCpjID, H003Y2_A369NegCpjEndSeq, H003Y2_A345NegID, H003Y2_A363NegDescricao, H003Y2_A380NegValorEstimado, H003Y2_A362NegAssunto, H003Y2_A353NegCpjNomFan, H003Y2_A351NegCliNomeFamiliar, H003Y2_A356NegCodigo,
               H003Y2_A373NegCpjEndComplem, H003Y2_n373NegCpjEndComplem, H003Y2_A372NegCpjEndNumero, H003Y2_A378NegCpjEndUFSigla, H003Y2_A376NegCpjEndMunNome, H003Y2_A643NegCpjEndCepFormat, H003Y2_A374NegCpjEndBairro, H003Y2_A371NegCpjEndEndereco
               }
            }
         );
         AV15Pgmname = "core.NegocioPJGeneral";
         /* GeneXus formulas. */
         AV15Pgmname = "core.NegocioPJGeneral";
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short initialized ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short A369NegCpjEndSeq ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int Negdescricao_Color ;
      private int edtNegCodigo_Enabled ;
      private int edtNegCliNomeFamiliar_Enabled ;
      private int edtNegCpjNomFan_Enabled ;
      private int edtNegCpjEndCompleto_Enabled ;
      private int edtNegAssunto_Enabled ;
      private int edtNegValorEstimado_Enabled ;
      private int bttBtnupdate_Visible ;
      private int bttBtndelete_Visible ;
      private int idxLst ;
      private long A356NegCodigo ;
      private decimal A380NegValorEstimado ;
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
      private string Negdescricao_Width ;
      private string Negdescricao_Height ;
      private string Negdescricao_Skin ;
      private string Negdescricao_Toolbar ;
      private string Negdescricao_Captionclass ;
      private string Negdescricao_Captionstyle ;
      private string Negdescricao_Captionposition ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTable_Internalname ;
      private string divTransactiondetail_tableattributes_Internalname ;
      private string edtNegCodigo_Internalname ;
      private string edtNegCodigo_Jsonclick ;
      private string edtNegCliNomeFamiliar_Internalname ;
      private string edtNegCliNomeFamiliar_Jsonclick ;
      private string edtNegCpjNomFan_Internalname ;
      private string edtNegCpjNomFan_Jsonclick ;
      private string edtNegCpjEndCompleto_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string edtNegAssunto_Internalname ;
      private string edtNegAssunto_Jsonclick ;
      private string edtNegValorEstimado_Internalname ;
      private string edtNegValorEstimado_Jsonclick ;
      private string Negdescricao_Internalname ;
      private string TempTags ;
      private string bttBtnupdate_Internalname ;
      private string bttBtnupdate_Jsonclick ;
      private string bttBtndelete_Internalname ;
      private string bttBtndelete_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string scmdbuf ;
      private string sCtrlA345NegID ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV12IsAuthorized_Update ;
      private bool AV13IsAuthorized_Delete ;
      private bool Negdescricao_Enabled ;
      private bool Negdescricao_Toolbarcancollapse ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool n373NegCpjEndComplem ;
      private bool returnInSub ;
      private bool GXt_boolean1 ;
      private string A363NegDescricao ;
      private string NegDescricao ;
      private string A371NegCpjEndEndereco ;
      private string A374NegCpjEndBairro ;
      private string A643NegCpjEndCepFormat ;
      private string A376NegCpjEndMunNome ;
      private string A378NegCpjEndUFSigla ;
      private string A372NegCpjEndNumero ;
      private string A373NegCpjEndComplem ;
      private string A351NegCliNomeFamiliar ;
      private string A353NegCpjNomFan ;
      private string A641NegCpjEndCompleto ;
      private string A362NegAssunto ;
      private Guid A345NegID ;
      private Guid wcpOA345NegID ;
      private Guid A350NegCliID ;
      private Guid A352NegCpjID ;
      private GXUserControl ucNegdescricao ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] H003Y2_A350NegCliID ;
      private Guid[] H003Y2_A352NegCpjID ;
      private short[] H003Y2_A369NegCpjEndSeq ;
      private Guid[] H003Y2_A345NegID ;
      private string[] H003Y2_A363NegDescricao ;
      private decimal[] H003Y2_A380NegValorEstimado ;
      private string[] H003Y2_A362NegAssunto ;
      private string[] H003Y2_A353NegCpjNomFan ;
      private string[] H003Y2_A351NegCliNomeFamiliar ;
      private long[] H003Y2_A356NegCodigo ;
      private string[] H003Y2_A373NegCpjEndComplem ;
      private bool[] H003Y2_n373NegCpjEndComplem ;
      private string[] H003Y2_A372NegCpjEndNumero ;
      private string[] H003Y2_A378NegCpjEndUFSigla ;
      private string[] H003Y2_A376NegCpjEndMunNome ;
      private string[] H003Y2_A643NegCpjEndCepFormat ;
      private string[] H003Y2_A374NegCpjEndBairro ;
      private string[] H003Y2_A371NegCpjEndEndereco ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV11HTTPRequest ;
      private IGxSession AV10Session ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV8TrnContext ;
   }

   public class negociopjgeneral__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH003Y2;
          prmH003Y2 = new Object[] {
          new ParDef("NegID",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("H003Y2", "SELECT T1.NegCliID AS NegCliID, T1.NegCpjID AS NegCpjID, T1.NegCpjEndSeq AS NegCpjEndSeq, T1.NegID, T1.NegDescricao, T1.NegValorEstimado, T1.NegAssunto, T1.NegCpjNomFan, T1.NegCliNomeFamiliar, T1.NegCodigo, T2.CpjEndComplem AS NegCpjEndComplem, T2.CpjEndNumero AS NegCpjEndNumero, T2.CpjEndUFSigla AS NegCpjEndUFSigla, T2.CpjEndMunNome AS NegCpjEndMunNome, T2.CpjEndCepFormat AS NegCpjEndCepFormat, T2.CpjEndBairro AS NegCpjEndBairro, T2.CpjEndEndereco AS NegCpjEndEndereco FROM (tb_negociopj T1 INNER JOIN tb_clientepj_endereco T2 ON T2.CliID = T1.NegCliID AND T2.CpjID = T1.NegCpjID AND T2.CpjEndSeq = T1.NegCpjEndSeq) WHERE T1.NegID = :NegID ORDER BY T1.NegID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003Y2,1, GxCacheFrequency.OFF ,true,true )
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
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((long[]) buf[9])[0] = rslt.getLong(10);
                ((string[]) buf[10])[0] = rslt.getVarchar(11);
                ((bool[]) buf[11])[0] = rslt.wasNull(11);
                ((string[]) buf[12])[0] = rslt.getVarchar(12);
                ((string[]) buf[13])[0] = rslt.getVarchar(13);
                ((string[]) buf[14])[0] = rslt.getVarchar(14);
                ((string[]) buf[15])[0] = rslt.getVarchar(15);
                ((string[]) buf[16])[0] = rslt.getVarchar(16);
                ((string[]) buf[17])[0] = rslt.getVarchar(17);
                return;
       }
    }

 }

}
