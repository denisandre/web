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
   public class visitageneral : GXWebComponent
   {
      public visitageneral( )
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

      public visitageneral( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_VisID )
      {
         this.A398VisID = aP0_VisID;
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
         cmbVisSituacao = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "VisID");
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
                  A398VisID = StringUtil.StrToGuid( GetPar( "VisID"));
                  AssignAttri(sPrefix, false, "A398VisID", A398VisID.ToString());
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(Guid)A398VisID});
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
                  gxfirstwebparm = GetFirstPar( "VisID");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "VisID");
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
            PA572( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV18Pgmname = "core.VisitaGeneral";
               WS572( ) ;
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
            context.SendWebValue( "Visita General") ;
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
            GXEncryptionTmp = "core.visitageneral.aspx"+UrlEncode(A398VisID.ToString());
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("core.visitageneral.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_VISPAIID", GetSecureSignedToken( sPrefix, A419VisPaiID, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"VISNEGID", A418VisNegID.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_VISNEGID", GetSecureSignedToken( sPrefix, A418VisNegID, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"VISNGFSEQ", StringUtil.LTrim( StringUtil.NToC( (decimal)(A422VisNgfSeq), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_VISNGFSEQ", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(A422VisNgfSeq), "ZZ,ZZZ,ZZ9"), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_DELETE", AV13IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV13IsAuthorized_Delete, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"VisitaGeneral");
         forbiddenHiddens.Add("VisLink", StringUtil.RTrim( context.localUtil.Format( A417VisLink, "")));
         forbiddenHiddens.Add("VisPaiID", A419VisPaiID.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("core\\visitageneral:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"VISDESCRICAO", A410VisDescricao);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA398VisID", wcpOA398VisID.ToString());
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_UPDATE", AV12IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV12IsAuthorized_Update, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"VISID", A398VisID.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"VISNEGID", A418VisNegID.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_VISNEGID", GetSecureSignedToken( sPrefix, A418VisNegID, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"VISNGFSEQ", StringUtil.LTrim( StringUtil.NToC( (decimal)(A422VisNgfSeq), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_VISNGFSEQ", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(A422VisNgfSeq), "ZZ,ZZZ,ZZ9"), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_DELETE", AV13IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV13IsAuthorized_Delete, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"VISDESCRICAO_Enabled", StringUtil.BoolToStr( Visdescricao_Enabled));
         GxWebStd.gx_hidden_field( context, sPrefix+"VISDESCRICAO_Width", StringUtil.RTrim( Visdescricao_Width));
         GxWebStd.gx_hidden_field( context, sPrefix+"VISDESCRICAO_Height", StringUtil.RTrim( Visdescricao_Height));
         GxWebStd.gx_hidden_field( context, sPrefix+"VISDESCRICAO_Skin", StringUtil.RTrim( Visdescricao_Skin));
         GxWebStd.gx_hidden_field( context, sPrefix+"VISDESCRICAO_Toolbar", StringUtil.RTrim( Visdescricao_Toolbar));
         GxWebStd.gx_hidden_field( context, sPrefix+"VISDESCRICAO_Color", StringUtil.LTrim( StringUtil.NToC( (decimal)(Visdescricao_Color), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"VISDESCRICAO_Captionclass", StringUtil.RTrim( Visdescricao_Captionclass));
         GxWebStd.gx_hidden_field( context, sPrefix+"VISDESCRICAO_Captionstyle", StringUtil.RTrim( Visdescricao_Captionstyle));
         GxWebStd.gx_hidden_field( context, sPrefix+"VISDESCRICAO_Captionposition", StringUtil.RTrim( Visdescricao_Captionposition));
      }

      protected void RenderHtmlCloseForm572( )
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
         return "core.VisitaGeneral" ;
      }

      public override string GetPgmdesc( )
      {
         return "Visita General" ;
      }

      protected void WB570( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "core.visitageneral.aspx");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtVisNegCodigo_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtVisNegCodigo_Internalname, "Negociação", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtVisNegCodigo_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A466VisNegCodigo), 12, 0, ",", "")), StringUtil.LTrim( ((edtVisNegCodigo_Enabled!=0) ? context.localUtil.Format( (decimal)(A466VisNegCodigo), "ZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A466VisNegCodigo), "ZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVisNegCodigo_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtVisNegCodigo_Enabled, 0, "text", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_core\\VisitaGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtVisNegAssunto_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtVisNegAssunto_Internalname, "Assunto da Negociação", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtVisNegAssunto_Internalname, A467VisNegAssunto, StringUtil.RTrim( context.localUtil.Format( A467VisNegAssunto, "@!")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", edtVisNegAssunto_Link, "", "", "", edtVisNegAssunto_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtVisNegAssunto_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\VisitaGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtVisNegCliNomeFamiliar_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtVisNegCliNomeFamiliar_Internalname, "Cliente", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtVisNegCliNomeFamiliar_Internalname, A469VisNegCliNomeFamiliar, StringUtil.RTrim( context.localUtil.Format( A469VisNegCliNomeFamiliar, "@!")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVisNegCliNomeFamiliar_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtVisNegCliNomeFamiliar_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "core\\Nome", "start", true, "", "HLP_core\\VisitaGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtVisNegCpjNomFan_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtVisNegCpjNomFan_Internalname, "Unidade", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtVisNegCpjNomFan_Internalname, A470VisNegCpjNomFan, StringUtil.RTrim( context.localUtil.Format( A470VisNegCpjNomFan, "@!")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVisNegCpjNomFan_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtVisNegCpjNomFan_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "core\\Nome", "start", true, "", "HLP_core\\VisitaGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtVisNegValor_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtVisNegValor_Internalname, "Valor em Negócios", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtVisNegValor_Internalname, StringUtil.LTrim( StringUtil.NToC( A468VisNegValor, 23, 2, ",", "")), StringUtil.LTrim( ((edtVisNegValor_Enabled!=0) ? context.localUtil.Format( A468VisNegValor, "R$ Z,ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A468VisNegValor, "R$ Z,ZZZ,ZZZ,ZZZ,ZZ9.99"))), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVisNegValor_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtVisNegValor_Enabled, 0, "text", "", 23, "chr", 1, "row", 23, 0, 0, 0, 0, -1, 0, true, "core\\Monetario", "end", false, "", "HLP_core\\VisitaGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtVisNgfIteNome_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtVisNgfIteNome_Internalname, "Fase", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtVisNgfIteNome_Internalname, A424VisNgfIteNome, StringUtil.RTrim( context.localUtil.Format( A424VisNgfIteNome, "@!")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVisNgfIteNome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtVisNgfIteNome_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "core\\Nome", "start", true, "", "HLP_core\\VisitaGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTransactiondetail_txtesp01_Internalname, "&nbsp;", "", "", lblTransactiondetail_txtesp01_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_core\\VisitaGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpTransactiondetail_tablegroupvisitaorigem_Internalname, "Visita origem", 1, 0, "px", 0, "px", grpTransactiondetail_tablegroupvisitaorigem_Class, "", "HLP_core\\VisitaGeneral.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTransactiondetail_tablevisitaorigem_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtVisPaiAssunto_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtVisPaiAssunto_Internalname, "Visita Origem", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtVisPaiAssunto_Internalname, A465VisPaiAssunto, StringUtil.RTrim( context.localUtil.Format( A465VisPaiAssunto, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVisPaiAssunto_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtVisPaiAssunto_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\VisitaGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtVisPaiDataHora_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtVisPaiDataHora_Internalname, "Agendada/Realizada em", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            context.WriteHtmlText( "<div id=\""+edtVisPaiDataHora_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtVisPaiDataHora_Internalname, context.localUtil.TToC( A462VisPaiDataHora, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A462VisPaiDataHora, "99/99/9999 99:99"), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVisPaiDataHora_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtVisPaiDataHora_Enabled, 0, "text", "", 16, "chr", 1, "row", 16, 0, 0, 0, 0, -1, 0, true, "core\\DataHora", "end", false, "", "HLP_core\\VisitaGeneral.htm");
            GxWebStd.gx_bitmap( context, edtVisPaiDataHora_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtVisPaiDataHora_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_core\\VisitaGeneral.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</fieldset>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtVisTipoNome_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtVisTipoNome_Internalname, "Tipo da Visita", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtVisTipoNome_Internalname, A416VisTipoNome, StringUtil.RTrim( context.localUtil.Format( A416VisTipoNome, "@!")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVisTipoNome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtVisTipoNome_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "core\\Nome", "start", true, "", "HLP_core\\VisitaGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpUnnamedgroup1_Internalname, "Início", 1, 0, "px", 0, "px", "Group", "", "HLP_core\\VisitaGeneral.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTransactiondetail_txtdatahorainicio_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtVisData_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtVisData_Internalname, "Data", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            context.WriteHtmlText( "<div id=\""+edtVisData_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtVisData_Internalname, context.localUtil.Format(A404VisData, "99/99/99"), context.localUtil.Format( A404VisData, "99/99/99"), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVisData_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtVisData_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "core\\Data", "end", false, "", "HLP_core\\VisitaGeneral.htm");
            GxWebStd.gx_bitmap( context, edtVisData_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtVisData_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_core\\VisitaGeneral.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtVisHora_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtVisHora_Internalname, "Hora", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            context.WriteHtmlText( "<div id=\""+edtVisHora_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtVisHora_Internalname, context.localUtil.TToC( A405VisHora, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A405VisHora, "99:99"), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVisHora_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtVisHora_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 0, -1, 0, true, "core\\HoraMinuto", "end", false, "", "HLP_core\\VisitaGeneral.htm");
            GxWebStd.gx_bitmap( context, edtVisHora_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtVisHora_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_core\\VisitaGeneral.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</fieldset>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Control Group */
            GxWebStd.gx_group_start( context, grpUnnamedgroup2_Internalname, "Término", 1, 0, "px", 0, "px", "Group", "", "HLP_core\\VisitaGeneral.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTransactiondetail_txtdatahoratermino_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtVisDataFim_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtVisDataFim_Internalname, "Data", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            context.WriteHtmlText( "<div id=\""+edtVisDataFim_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtVisDataFim_Internalname, context.localUtil.Format(A475VisDataFim, "99/99/99"), context.localUtil.Format( A475VisDataFim, "99/99/99"), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVisDataFim_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtVisDataFim_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "core\\Data", "end", false, "", "HLP_core\\VisitaGeneral.htm");
            GxWebStd.gx_bitmap( context, edtVisDataFim_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtVisDataFim_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_core\\VisitaGeneral.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtVisHoraFim_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtVisHoraFim_Internalname, "Hora", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            context.WriteHtmlText( "<div id=\""+edtVisHoraFim_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtVisHoraFim_Internalname, context.localUtil.TToC( A476VisHoraFim, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A476VisHoraFim, "99:99"), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVisHoraFim_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtVisHoraFim_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 0, -1, 0, true, "core\\HoraMinuto", "end", false, "", "HLP_core\\VisitaGeneral.htm");
            GxWebStd.gx_bitmap( context, edtVisHoraFim_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtVisHoraFim_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_core\\VisitaGeneral.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</fieldset>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtVisAssunto_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtVisAssunto_Internalname, "Assunto da Visita", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtVisAssunto_Internalname, A409VisAssunto, StringUtil.RTrim( context.localUtil.Format( A409VisAssunto, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVisAssunto_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtVisAssunto_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\VisitaGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbVisSituacao_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbVisSituacao_Internalname, "Situação", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbVisSituacao, cmbVisSituacao_Internalname, StringUtil.RTrim( A472VisSituacao), 1, cmbVisSituacao_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbVisSituacao.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", "", "", true, 0, "HLP_core\\VisitaGeneral.htm");
            cmbVisSituacao.CurrentValue = StringUtil.RTrim( A472VisSituacao);
            AssignProp(sPrefix, false, cmbVisSituacao_Internalname, "Values", (string)(cmbVisSituacao.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtVisLink_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtVisLink_Internalname, "Link Externo (Ms Teams, Google Meet, Zoom, etc.)", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtVisLink_Internalname, A417VisLink, StringUtil.RTrim( context.localUtil.Format( A417VisLink, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", edtVisLink_Link, edtVisLink_Linktarget, "", "", edtVisLink_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtVisLink_Enabled, 0, "url", "", 80, "chr", 1, "row", 1000, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Url", "start", true, "", "HLP_core\\VisitaGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* User Defined Control */
            ucVisdescricao.SetProperty("Width", Visdescricao_Width);
            ucVisdescricao.SetProperty("Height", Visdescricao_Height);
            ucVisdescricao.SetProperty("Attribute", VisDescricao);
            ucVisdescricao.SetProperty("Skin", Visdescricao_Skin);
            ucVisdescricao.SetProperty("Toolbar", Visdescricao_Toolbar);
            ucVisdescricao.SetProperty("Color", Visdescricao_Color);
            ucVisdescricao.SetProperty("CaptionClass", Visdescricao_Captionclass);
            ucVisdescricao.SetProperty("CaptionStyle", Visdescricao_Captionstyle);
            ucVisdescricao.SetProperty("CaptionPosition", Visdescricao_Captionposition);
            ucVisdescricao.Render(context, "fckeditor", Visdescricao_Internalname, sPrefix+"VISDESCRICAOContainer");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 102,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnupdate_Internalname, "", "Alterar", bttBtnupdate_Jsonclick, 5, "Alterar", "", StyleString, ClassString, bttBtnupdate_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOUPDATE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\VisitaGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtndelete_Internalname, "", "Excluir", bttBtndelete_Jsonclick, 5, "Excluir", "", StyleString, ClassString, bttBtndelete_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DODELETE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\VisitaGeneral.htm");
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
            context.WriteHtmlText( "<div id=\""+edtVisDataHoraFim_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtVisDataHoraFim_Internalname, context.localUtil.TToC( A477VisDataHoraFim, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A477VisDataHoraFim, "99/99/9999 99:99"), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVisDataHoraFim_Jsonclick, 0, "Attribute", "", "", "", "", edtVisDataHoraFim_Visible, 0, 0, "text", "", 16, "chr", 1, "row", 16, 0, 0, 0, 0, -1, 0, true, "core\\DataHora", "end", false, "", "HLP_core\\VisitaGeneral.htm");
            GxWebStd.gx_bitmap( context, edtVisDataHoraFim_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtVisDataHoraFim_Visible==0)||(0==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_core\\VisitaGeneral.htm");
            context.WriteHtmlTextNl( "</div>") ;
            /* Single line edit */
            context.WriteHtmlText( "<div id=\""+edtVisDataHora_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtVisDataHora_Internalname, context.localUtil.TToC( A406VisDataHora, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A406VisDataHora, "99/99/9999 99:99"), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVisDataHora_Jsonclick, 0, "Attribute", "", "", "", "", edtVisDataHora_Visible, 0, 0, "text", "", 16, "chr", 1, "row", 16, 0, 0, 0, 0, -1, 0, true, "core\\DataHora", "end", false, "", "HLP_core\\VisitaGeneral.htm");
            GxWebStd.gx_bitmap( context, edtVisDataHora_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtVisDataHora_Visible==0)||(0==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_core\\VisitaGeneral.htm");
            context.WriteHtmlTextNl( "</div>") ;
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtVisPaiID_Internalname, A419VisPaiID.ToString(), A419VisPaiID.ToString(), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVisPaiID_Jsonclick, 0, "Attribute", "", "", "", "", edtVisPaiID_Visible, 0, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_core\\VisitaGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START572( )
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
               Form.Meta.addItem("description", "Visita General", 0) ;
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
               STRUP570( ) ;
            }
         }
      }

      protected void WS572( )
      {
         START572( ) ;
         EVT572( ) ;
      }

      protected void EVT572( )
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
                                 STRUP570( ) ;
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
                                 STRUP570( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E11572 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP570( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E12572 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOUPDATE'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP570( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoUpdate' */
                                    E13572 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DODELETE'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP570( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoDelete' */
                                    E14572 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP570( ) ;
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
                                 STRUP570( ) ;
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

      protected void WE572( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm572( ) ;
            }
         }
      }

      protected void PA572( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "core.visitageneral.aspx")), "core.visitageneral.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "core.visitageneral.aspx")))) ;
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
                     gxfirstwebparm = GetFirstPar( "VisID");
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
         if ( cmbVisSituacao.ItemCount > 0 )
         {
            A472VisSituacao = cmbVisSituacao.getValidValue(A472VisSituacao);
            AssignAttri(sPrefix, false, "A472VisSituacao", A472VisSituacao);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbVisSituacao.CurrentValue = StringUtil.RTrim( A472VisSituacao);
            AssignProp(sPrefix, false, cmbVisSituacao_Internalname, "Values", cmbVisSituacao.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF572( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV18Pgmname = "core.VisitaGeneral";
      }

      protected void RF572( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H00572 */
            pr_default.execute(0, new Object[] {A398VisID});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A414VisTipoID = H00572_A414VisTipoID[0];
               A418VisNegID = H00572_A418VisNegID[0];
               n418VisNegID = H00572_n418VisNegID[0];
               A422VisNgfSeq = H00572_A422VisNgfSeq[0];
               n422VisNgfSeq = H00572_n422VisNgfSeq[0];
               A419VisPaiID = H00572_A419VisPaiID[0];
               n419VisPaiID = H00572_n419VisPaiID[0];
               AssignAttri(sPrefix, false, "A419VisPaiID", A419VisPaiID.ToString());
               GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_VISPAIID", GetSecureSignedToken( sPrefix, A419VisPaiID, context));
               A406VisDataHora = H00572_A406VisDataHora[0];
               AssignAttri(sPrefix, false, "A406VisDataHora", context.localUtil.TToC( A406VisDataHora, 10, 5, 0, 3, "/", ":", " "));
               A477VisDataHoraFim = H00572_A477VisDataHoraFim[0];
               n477VisDataHoraFim = H00572_n477VisDataHoraFim[0];
               AssignAttri(sPrefix, false, "A477VisDataHoraFim", context.localUtil.TToC( A477VisDataHoraFim, 10, 5, 0, 3, "/", ":", " "));
               A410VisDescricao = H00572_A410VisDescricao[0];
               n410VisDescricao = H00572_n410VisDescricao[0];
               A417VisLink = H00572_A417VisLink[0];
               n417VisLink = H00572_n417VisLink[0];
               AssignAttri(sPrefix, false, "A417VisLink", A417VisLink);
               A472VisSituacao = H00572_A472VisSituacao[0];
               AssignAttri(sPrefix, false, "A472VisSituacao", A472VisSituacao);
               A409VisAssunto = H00572_A409VisAssunto[0];
               AssignAttri(sPrefix, false, "A409VisAssunto", A409VisAssunto);
               A476VisHoraFim = H00572_A476VisHoraFim[0];
               n476VisHoraFim = H00572_n476VisHoraFim[0];
               AssignAttri(sPrefix, false, "A476VisHoraFim", context.localUtil.TToC( A476VisHoraFim, 0, 5, 0, 3, "/", ":", " "));
               A475VisDataFim = H00572_A475VisDataFim[0];
               n475VisDataFim = H00572_n475VisDataFim[0];
               AssignAttri(sPrefix, false, "A475VisDataFim", context.localUtil.Format(A475VisDataFim, "99/99/99"));
               A405VisHora = H00572_A405VisHora[0];
               AssignAttri(sPrefix, false, "A405VisHora", context.localUtil.TToC( A405VisHora, 0, 5, 0, 3, "/", ":", " "));
               A404VisData = H00572_A404VisData[0];
               AssignAttri(sPrefix, false, "A404VisData", context.localUtil.Format(A404VisData, "99/99/99"));
               A416VisTipoNome = H00572_A416VisTipoNome[0];
               AssignAttri(sPrefix, false, "A416VisTipoNome", A416VisTipoNome);
               A462VisPaiDataHora = H00572_A462VisPaiDataHora[0];
               AssignAttri(sPrefix, false, "A462VisPaiDataHora", context.localUtil.TToC( A462VisPaiDataHora, 10, 5, 0, 3, "/", ":", " "));
               A465VisPaiAssunto = H00572_A465VisPaiAssunto[0];
               AssignAttri(sPrefix, false, "A465VisPaiAssunto", A465VisPaiAssunto);
               A424VisNgfIteNome = H00572_A424VisNgfIteNome[0];
               n424VisNgfIteNome = H00572_n424VisNgfIteNome[0];
               AssignAttri(sPrefix, false, "A424VisNgfIteNome", A424VisNgfIteNome);
               A468VisNegValor = H00572_A468VisNegValor[0];
               AssignAttri(sPrefix, false, "A468VisNegValor", StringUtil.LTrimStr( A468VisNegValor, 16, 2));
               A470VisNegCpjNomFan = H00572_A470VisNegCpjNomFan[0];
               n470VisNegCpjNomFan = H00572_n470VisNegCpjNomFan[0];
               AssignAttri(sPrefix, false, "A470VisNegCpjNomFan", A470VisNegCpjNomFan);
               A469VisNegCliNomeFamiliar = H00572_A469VisNegCliNomeFamiliar[0];
               n469VisNegCliNomeFamiliar = H00572_n469VisNegCliNomeFamiliar[0];
               AssignAttri(sPrefix, false, "A469VisNegCliNomeFamiliar", A469VisNegCliNomeFamiliar);
               A467VisNegAssunto = H00572_A467VisNegAssunto[0];
               AssignAttri(sPrefix, false, "A467VisNegAssunto", A467VisNegAssunto);
               A466VisNegCodigo = H00572_A466VisNegCodigo[0];
               AssignAttri(sPrefix, false, "A466VisNegCodigo", StringUtil.LTrimStr( (decimal)(A466VisNegCodigo), 12, 0));
               A416VisTipoNome = H00572_A416VisTipoNome[0];
               AssignAttri(sPrefix, false, "A416VisTipoNome", A416VisTipoNome);
               A468VisNegValor = H00572_A468VisNegValor[0];
               AssignAttri(sPrefix, false, "A468VisNegValor", StringUtil.LTrimStr( A468VisNegValor, 16, 2));
               A470VisNegCpjNomFan = H00572_A470VisNegCpjNomFan[0];
               n470VisNegCpjNomFan = H00572_n470VisNegCpjNomFan[0];
               AssignAttri(sPrefix, false, "A470VisNegCpjNomFan", A470VisNegCpjNomFan);
               A469VisNegCliNomeFamiliar = H00572_A469VisNegCliNomeFamiliar[0];
               n469VisNegCliNomeFamiliar = H00572_n469VisNegCliNomeFamiliar[0];
               AssignAttri(sPrefix, false, "A469VisNegCliNomeFamiliar", A469VisNegCliNomeFamiliar);
               A467VisNegAssunto = H00572_A467VisNegAssunto[0];
               AssignAttri(sPrefix, false, "A467VisNegAssunto", A467VisNegAssunto);
               A466VisNegCodigo = H00572_A466VisNegCodigo[0];
               AssignAttri(sPrefix, false, "A466VisNegCodigo", StringUtil.LTrimStr( (decimal)(A466VisNegCodigo), 12, 0));
               A424VisNgfIteNome = H00572_A424VisNgfIteNome[0];
               n424VisNgfIteNome = H00572_n424VisNgfIteNome[0];
               AssignAttri(sPrefix, false, "A424VisNgfIteNome", A424VisNgfIteNome);
               A462VisPaiDataHora = H00572_A462VisPaiDataHora[0];
               AssignAttri(sPrefix, false, "A462VisPaiDataHora", context.localUtil.TToC( A462VisPaiDataHora, 10, 5, 0, 3, "/", ":", " "));
               A465VisPaiAssunto = H00572_A465VisPaiAssunto[0];
               AssignAttri(sPrefix, false, "A465VisPaiAssunto", A465VisPaiAssunto);
               /* Execute user event: Load */
               E12572 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            WB570( ) ;
         }
      }

      protected void send_integrity_lvl_hashes572( )
      {
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_UPDATE", AV12IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV12IsAuthorized_Update, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_VISPAIID", GetSecureSignedToken( sPrefix, A419VisPaiID, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"VISNEGID", A418VisNegID.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_VISNEGID", GetSecureSignedToken( sPrefix, A418VisNegID, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"VISNGFSEQ", StringUtil.LTrim( StringUtil.NToC( (decimal)(A422VisNgfSeq), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_VISNGFSEQ", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(A422VisNgfSeq), "ZZ,ZZZ,ZZ9"), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_DELETE", AV13IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV13IsAuthorized_Delete, context));
      }

      protected void before_start_formulas( )
      {
         AV18Pgmname = "core.VisitaGeneral";
         fix_multi_value_controls( ) ;
      }

      protected void STRUP570( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11572 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            A410VisDescricao = cgiGet( sPrefix+"VISDESCRICAO");
            wcpOA398VisID = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOA398VisID"));
            Visdescricao_Enabled = StringUtil.StrToBool( cgiGet( sPrefix+"VISDESCRICAO_Enabled"));
            Visdescricao_Width = cgiGet( sPrefix+"VISDESCRICAO_Width");
            Visdescricao_Height = cgiGet( sPrefix+"VISDESCRICAO_Height");
            Visdescricao_Skin = cgiGet( sPrefix+"VISDESCRICAO_Skin");
            Visdescricao_Toolbar = cgiGet( sPrefix+"VISDESCRICAO_Toolbar");
            Visdescricao_Color = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"VISDESCRICAO_Color"), ",", "."), 18, MidpointRounding.ToEven));
            Visdescricao_Captionclass = cgiGet( sPrefix+"VISDESCRICAO_Captionclass");
            Visdescricao_Captionstyle = cgiGet( sPrefix+"VISDESCRICAO_Captionstyle");
            Visdescricao_Captionposition = cgiGet( sPrefix+"VISDESCRICAO_Captionposition");
            /* Read variables values. */
            A466VisNegCodigo = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtVisNegCodigo_Internalname), ",", "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A466VisNegCodigo", StringUtil.LTrimStr( (decimal)(A466VisNegCodigo), 12, 0));
            A467VisNegAssunto = StringUtil.Upper( cgiGet( edtVisNegAssunto_Internalname));
            AssignAttri(sPrefix, false, "A467VisNegAssunto", A467VisNegAssunto);
            A469VisNegCliNomeFamiliar = StringUtil.Upper( cgiGet( edtVisNegCliNomeFamiliar_Internalname));
            n469VisNegCliNomeFamiliar = false;
            AssignAttri(sPrefix, false, "A469VisNegCliNomeFamiliar", A469VisNegCliNomeFamiliar);
            A470VisNegCpjNomFan = StringUtil.Upper( cgiGet( edtVisNegCpjNomFan_Internalname));
            n470VisNegCpjNomFan = false;
            AssignAttri(sPrefix, false, "A470VisNegCpjNomFan", A470VisNegCpjNomFan);
            A468VisNegValor = context.localUtil.CToN( cgiGet( edtVisNegValor_Internalname), ",", ".");
            AssignAttri(sPrefix, false, "A468VisNegValor", StringUtil.LTrimStr( A468VisNegValor, 16, 2));
            A424VisNgfIteNome = StringUtil.Upper( cgiGet( edtVisNgfIteNome_Internalname));
            n424VisNgfIteNome = false;
            AssignAttri(sPrefix, false, "A424VisNgfIteNome", A424VisNgfIteNome);
            A465VisPaiAssunto = cgiGet( edtVisPaiAssunto_Internalname);
            AssignAttri(sPrefix, false, "A465VisPaiAssunto", A465VisPaiAssunto);
            A462VisPaiDataHora = context.localUtil.CToT( cgiGet( edtVisPaiDataHora_Internalname));
            AssignAttri(sPrefix, false, "A462VisPaiDataHora", context.localUtil.TToC( A462VisPaiDataHora, 10, 5, 0, 3, "/", ":", " "));
            A416VisTipoNome = StringUtil.Upper( cgiGet( edtVisTipoNome_Internalname));
            AssignAttri(sPrefix, false, "A416VisTipoNome", A416VisTipoNome);
            A404VisData = context.localUtil.CToD( cgiGet( edtVisData_Internalname), 2);
            AssignAttri(sPrefix, false, "A404VisData", context.localUtil.Format(A404VisData, "99/99/99"));
            A405VisHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtVisHora_Internalname)));
            AssignAttri(sPrefix, false, "A405VisHora", context.localUtil.TToC( A405VisHora, 0, 5, 0, 3, "/", ":", " "));
            A475VisDataFim = context.localUtil.CToD( cgiGet( edtVisDataFim_Internalname), 2);
            n475VisDataFim = false;
            AssignAttri(sPrefix, false, "A475VisDataFim", context.localUtil.Format(A475VisDataFim, "99/99/99"));
            A476VisHoraFim = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtVisHoraFim_Internalname)));
            n476VisHoraFim = false;
            AssignAttri(sPrefix, false, "A476VisHoraFim", context.localUtil.TToC( A476VisHoraFim, 0, 5, 0, 3, "/", ":", " "));
            A409VisAssunto = cgiGet( edtVisAssunto_Internalname);
            AssignAttri(sPrefix, false, "A409VisAssunto", A409VisAssunto);
            cmbVisSituacao.CurrentValue = cgiGet( cmbVisSituacao_Internalname);
            A472VisSituacao = cgiGet( cmbVisSituacao_Internalname);
            AssignAttri(sPrefix, false, "A472VisSituacao", A472VisSituacao);
            A417VisLink = cgiGet( edtVisLink_Internalname);
            n417VisLink = false;
            AssignAttri(sPrefix, false, "A417VisLink", A417VisLink);
            A477VisDataHoraFim = context.localUtil.CToT( cgiGet( edtVisDataHoraFim_Internalname));
            n477VisDataHoraFim = false;
            AssignAttri(sPrefix, false, "A477VisDataHoraFim", context.localUtil.TToC( A477VisDataHoraFim, 10, 5, 0, 3, "/", ":", " "));
            A406VisDataHora = context.localUtil.CToT( cgiGet( edtVisDataHora_Internalname));
            AssignAttri(sPrefix, false, "A406VisDataHora", context.localUtil.TToC( A406VisDataHora, 10, 5, 0, 3, "/", ":", " "));
            A419VisPaiID = StringUtil.StrToGuid( cgiGet( edtVisPaiID_Internalname));
            n419VisPaiID = false;
            AssignAttri(sPrefix, false, "A419VisPaiID", A419VisPaiID.ToString());
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_VISPAIID", GetSecureSignedToken( sPrefix, A419VisPaiID, context));
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"VisitaGeneral");
            A417VisLink = cgiGet( edtVisLink_Internalname);
            n417VisLink = false;
            AssignAttri(sPrefix, false, "A417VisLink", A417VisLink);
            forbiddenHiddens.Add("VisLink", StringUtil.RTrim( context.localUtil.Format( A417VisLink, "")));
            A419VisPaiID = StringUtil.StrToGuid( cgiGet( edtVisPaiID_Internalname));
            n419VisPaiID = false;
            AssignAttri(sPrefix, false, "A419VisPaiID", A419VisPaiID.ToString());
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_VISPAIID", GetSecureSignedToken( sPrefix, A419VisPaiID, context));
            forbiddenHiddens.Add("VisPaiID", A419VisPaiID.ToString());
            hsh = cgiGet( sPrefix+"hsh");
            if ( ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("core\\visitageneral:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
         E11572 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E11572( )
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

      protected void E12572( )
      {
         /* Load Routine */
         returnInSub = false;
         GXt_boolean1 = AV14TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "negociopjview_Execute", out  GXt_boolean1) ;
         AV14TempBoolean = GXt_boolean1;
         if ( AV14TempBoolean )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
               }
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "core.negociopjview.aspx"+UrlEncode(A418VisNegID.ToString()) + "," + UrlEncode(StringUtil.RTrim(""));
            edtVisNegAssunto_Link = formatLink("core.negociopjview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            AssignProp(sPrefix, false, edtVisNegAssunto_Internalname, "Link", edtVisNegAssunto_Link, true);
         }
         edtVisLink_Linktarget = "_blank";
         AssignProp(sPrefix, false, edtVisLink_Internalname, "Linktarget", edtVisLink_Linktarget, true);
         edtVisLink_Link = A417VisLink;
         AssignProp(sPrefix, false, edtVisLink_Internalname, "Link", edtVisLink_Link, true);
         edtVisDataHoraFim_Visible = 0;
         AssignProp(sPrefix, false, edtVisDataHoraFim_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtVisDataHoraFim_Visible), 5, 0), true);
         edtVisDataHora_Visible = 0;
         AssignProp(sPrefix, false, edtVisDataHora_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtVisDataHora_Visible), 5, 0), true);
         edtVisPaiID_Visible = 0;
         AssignProp(sPrefix, false, edtVisPaiID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtVisPaiID_Visible), 5, 0), true);
         GXt_boolean1 = AV12IsAuthorized_Update;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "visita_Update", out  GXt_boolean1) ;
         AV12IsAuthorized_Update = GXt_boolean1;
         AssignAttri(sPrefix, false, "AV12IsAuthorized_Update", AV12IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV12IsAuthorized_Update, context));
         if ( ! ( AV12IsAuthorized_Update ) )
         {
            bttBtnupdate_Visible = 0;
            AssignProp(sPrefix, false, bttBtnupdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnupdate_Visible), 5, 0), true);
         }
         GXt_boolean1 = AV13IsAuthorized_Delete;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "visita_Delete", out  GXt_boolean1) ;
         AV13IsAuthorized_Delete = GXt_boolean1;
         AssignAttri(sPrefix, false, "AV13IsAuthorized_Delete", AV13IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV13IsAuthorized_Delete, context));
         if ( ! ( AV13IsAuthorized_Delete ) )
         {
            bttBtndelete_Visible = 0;
            AssignProp(sPrefix, false, bttBtndelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtndelete_Visible), 5, 0), true);
         }
         if ( ! ( ! (Guid.Empty==AV15VisPaiID) ) )
         {
            grpTransactiondetail_tablegroupvisitaorigem_Class = "Invisible";
            AssignProp(sPrefix, false, grpTransactiondetail_tablegroupvisitaorigem_Internalname, "Class", grpTransactiondetail_tablegroupvisitaorigem_Class, true);
         }
         else
         {
            grpTransactiondetail_tablegroupvisitaorigem_Class = "Group";
            AssignProp(sPrefix, false, grpTransactiondetail_tablegroupvisitaorigem_Internalname, "Class", grpTransactiondetail_tablegroupvisitaorigem_Class, true);
         }
      }

      protected void E13572( )
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
            GXEncryptionTmp = "core.visita.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(A398VisID.ToString()) + "," + UrlEncode(Guid.Empty.ToString()) + "," + UrlEncode(A418VisNegID.ToString()) + "," + UrlEncode(StringUtil.LTrimStr(A422VisNgfSeq,8,0));
            CallWebObject(formatLink("core.visita.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
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

      protected void E14572( )
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
            GXEncryptionTmp = "core.visita.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(A398VisID.ToString()) + "," + UrlEncode(Guid.Empty.ToString()) + "," + UrlEncode(A418VisNegID.ToString()) + "," + UrlEncode(StringUtil.LTrimStr(A422VisNgfSeq,8,0));
            CallWebObject(formatLink("core.visita.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
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
         AV8TrnContext.gxTpr_Callerobject = AV18Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = false;
         AV8TrnContext.gxTpr_Callerurl = AV11HTTPRequest.ScriptName+"?"+AV11HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "core.Visita";
         AV10Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A398VisID = (Guid)getParm(obj,0);
         AssignAttri(sPrefix, false, "A398VisID", A398VisID.ToString());
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
         PA572( ) ;
         WS572( ) ;
         WE572( ) ;
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
         sCtrlA398VisID = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA572( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "core\\visitageneral", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA572( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            A398VisID = (Guid)getParm(obj,2);
            AssignAttri(sPrefix, false, "A398VisID", A398VisID.ToString());
         }
         wcpOA398VisID = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOA398VisID"));
         if ( ! GetJustCreated( ) && ( ( A398VisID != wcpOA398VisID ) ) )
         {
            setjustcreated();
         }
         wcpOA398VisID = A398VisID;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlA398VisID = cgiGet( sPrefix+"A398VisID_CTRL");
         if ( StringUtil.Len( sCtrlA398VisID) > 0 )
         {
            A398VisID = StringUtil.StrToGuid( cgiGet( sCtrlA398VisID));
            AssignAttri(sPrefix, false, "A398VisID", A398VisID.ToString());
         }
         else
         {
            A398VisID = StringUtil.StrToGuid( cgiGet( sPrefix+"A398VisID_PARM"));
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
         PA572( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS572( ) ;
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
         WS572( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"A398VisID_PARM", A398VisID.ToString());
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA398VisID)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A398VisID_CTRL", StringUtil.RTrim( sCtrlA398VisID));
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
         WE572( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202382816442", true, true);
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
         context.AddJavascriptSource("core/visitageneral.js", "?202382816443", false, true);
         context.AddJavascriptSource("CKEditor/ckeditor/ckeditor.js", "", false, true);
         context.AddJavascriptSource("CKEditor/CKEditorRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbVisSituacao.Name = "VISSITUACAO";
         cmbVisSituacao.WebTags = "";
         cmbVisSituacao.addItem("", " ", 0);
         cmbVisSituacao.addItem("PEN", "Pendente", 0);
         cmbVisSituacao.addItem("REA", "Realizada", 0);
         cmbVisSituacao.addItem("REM", "Remarcada", 0);
         cmbVisSituacao.addItem("CAN", "Cancelada", 0);
         if ( cmbVisSituacao.ItemCount > 0 )
         {
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtVisNegCodigo_Internalname = sPrefix+"VISNEGCODIGO";
         edtVisNegAssunto_Internalname = sPrefix+"VISNEGASSUNTO";
         edtVisNegCliNomeFamiliar_Internalname = sPrefix+"VISNEGCLINOMEFAMILIAR";
         edtVisNegCpjNomFan_Internalname = sPrefix+"VISNEGCPJNOMFAN";
         edtVisNegValor_Internalname = sPrefix+"VISNEGVALOR";
         edtVisNgfIteNome_Internalname = sPrefix+"VISNGFITENOME";
         lblTransactiondetail_txtesp01_Internalname = sPrefix+"TRANSACTIONDETAIL_TXTESP01";
         edtVisPaiAssunto_Internalname = sPrefix+"VISPAIASSUNTO";
         edtVisPaiDataHora_Internalname = sPrefix+"VISPAIDATAHORA";
         divTransactiondetail_tablevisitaorigem_Internalname = sPrefix+"TRANSACTIONDETAIL_TABLEVISITAORIGEM";
         grpTransactiondetail_tablegroupvisitaorigem_Internalname = sPrefix+"TRANSACTIONDETAIL_TABLEGROUPVISITAORIGEM";
         edtVisTipoNome_Internalname = sPrefix+"VISTIPONOME";
         edtVisData_Internalname = sPrefix+"VISDATA";
         edtVisHora_Internalname = sPrefix+"VISHORA";
         divTransactiondetail_txtdatahorainicio_Internalname = sPrefix+"TRANSACTIONDETAIL_TXTDATAHORAINICIO";
         grpUnnamedgroup1_Internalname = sPrefix+"UNNAMEDGROUP1";
         edtVisDataFim_Internalname = sPrefix+"VISDATAFIM";
         edtVisHoraFim_Internalname = sPrefix+"VISHORAFIM";
         divTransactiondetail_txtdatahoratermino_Internalname = sPrefix+"TRANSACTIONDETAIL_TXTDATAHORATERMINO";
         grpUnnamedgroup2_Internalname = sPrefix+"UNNAMEDGROUP2";
         edtVisAssunto_Internalname = sPrefix+"VISASSUNTO";
         cmbVisSituacao_Internalname = sPrefix+"VISSITUACAO";
         edtVisLink_Internalname = sPrefix+"VISLINK";
         Visdescricao_Internalname = sPrefix+"VISDESCRICAO";
         divTransactiondetail_tableattributes_Internalname = sPrefix+"TRANSACTIONDETAIL_TABLEATTRIBUTES";
         bttBtnupdate_Internalname = sPrefix+"BTNUPDATE";
         bttBtndelete_Internalname = sPrefix+"BTNDELETE";
         divTable_Internalname = sPrefix+"TABLE";
         edtVisDataHoraFim_Internalname = sPrefix+"VISDATAHORAFIM";
         edtVisDataHora_Internalname = sPrefix+"VISDATAHORA";
         edtVisPaiID_Internalname = sPrefix+"VISPAIID";
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
         edtVisPaiID_Jsonclick = "";
         edtVisPaiID_Visible = 1;
         edtVisDataHora_Jsonclick = "";
         edtVisDataHora_Visible = 1;
         edtVisDataHoraFim_Jsonclick = "";
         edtVisDataHoraFim_Visible = 1;
         bttBtndelete_Visible = 1;
         bttBtnupdate_Visible = 1;
         Visdescricao_Enabled = Convert.ToBoolean( 0);
         edtVisLink_Jsonclick = "";
         edtVisLink_Linktarget = "";
         edtVisLink_Link = "";
         edtVisLink_Enabled = 0;
         cmbVisSituacao_Jsonclick = "";
         cmbVisSituacao.Enabled = 0;
         edtVisAssunto_Jsonclick = "";
         edtVisAssunto_Enabled = 0;
         edtVisHoraFim_Jsonclick = "";
         edtVisHoraFim_Enabled = 0;
         edtVisDataFim_Jsonclick = "";
         edtVisDataFim_Enabled = 0;
         edtVisHora_Jsonclick = "";
         edtVisHora_Enabled = 0;
         edtVisData_Jsonclick = "";
         edtVisData_Enabled = 0;
         edtVisTipoNome_Jsonclick = "";
         edtVisTipoNome_Enabled = 0;
         edtVisPaiDataHora_Jsonclick = "";
         edtVisPaiDataHora_Enabled = 0;
         edtVisPaiAssunto_Jsonclick = "";
         edtVisPaiAssunto_Enabled = 0;
         grpTransactiondetail_tablegroupvisitaorigem_Class = "Group";
         edtVisNgfIteNome_Jsonclick = "";
         edtVisNgfIteNome_Enabled = 0;
         edtVisNegValor_Jsonclick = "";
         edtVisNegValor_Enabled = 0;
         edtVisNegCpjNomFan_Jsonclick = "";
         edtVisNegCpjNomFan_Enabled = 0;
         edtVisNegCliNomeFamiliar_Jsonclick = "";
         edtVisNegCliNomeFamiliar_Enabled = 0;
         edtVisNegAssunto_Jsonclick = "";
         edtVisNegAssunto_Link = "";
         edtVisNegAssunto_Enabled = 0;
         edtVisNegCodigo_Jsonclick = "";
         edtVisNegCodigo_Enabled = 0;
         Visdescricao_Captionposition = "None";
         Visdescricao_Captionstyle = "";
         Visdescricao_Captionclass = "col-sm-3 AttributeLabel";
         Visdescricao_Color = (int)(0xD3D3D3);
         Visdescricao_Toolbar = "Default";
         Visdescricao_Skin = "silver";
         Visdescricao_Height = "350";
         Visdescricao_Width = "100%";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A398VisID',fld:'VISID',pic:''},{av:'AV12IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV13IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'A419VisPaiID',fld:'VISPAIID',pic:'',hsh:true},{av:'A418VisNegID',fld:'VISNEGID',pic:'',hsh:true},{av:'A422VisNgfSeq',fld:'VISNGFSEQ',pic:'ZZ,ZZZ,ZZ9',hsh:true},{av:'A417VisLink',fld:'VISLINK',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'DOUPDATE'","{handler:'E13572',iparms:[{av:'AV12IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'A398VisID',fld:'VISID',pic:''},{av:'A419VisPaiID',fld:'VISPAIID',pic:'',hsh:true},{av:'A418VisNegID',fld:'VISNEGID',pic:'',hsh:true},{av:'A422VisNgfSeq',fld:'VISNGFSEQ',pic:'ZZ,ZZZ,ZZ9',hsh:true}]");
         setEventMetadata("'DOUPDATE'",",oparms:[{ctrl:'BTNUPDATE',prop:'Visible'}]}");
         setEventMetadata("'DODELETE'","{handler:'E14572',iparms:[{av:'AV13IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'A398VisID',fld:'VISID',pic:''},{av:'A419VisPaiID',fld:'VISPAIID',pic:'',hsh:true},{av:'A418VisNegID',fld:'VISNEGID',pic:'',hsh:true},{av:'A422VisNgfSeq',fld:'VISNGFSEQ',pic:'ZZ,ZZZ,ZZ9',hsh:true}]");
         setEventMetadata("'DODELETE'",",oparms:[{ctrl:'BTNDELETE',prop:'Visible'}]}");
         setEventMetadata("VALID_VISPAIID","{handler:'Valid_Vispaiid',iparms:[]");
         setEventMetadata("VALID_VISPAIID",",oparms:[]}");
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
         wcpOA398VisID = Guid.Empty;
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV18Pgmname = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         A419VisPaiID = Guid.Empty;
         A418VisNegID = Guid.Empty;
         forbiddenHiddens = new GXProperties();
         A417VisLink = "";
         A410VisDescricao = "";
         GX_FocusControl = "";
         A467VisNegAssunto = "";
         A469VisNegCliNomeFamiliar = "";
         A470VisNegCpjNomFan = "";
         A424VisNgfIteNome = "";
         lblTransactiondetail_txtesp01_Jsonclick = "";
         A465VisPaiAssunto = "";
         A462VisPaiDataHora = (DateTime)(DateTime.MinValue);
         A416VisTipoNome = "";
         A404VisData = DateTime.MinValue;
         A405VisHora = (DateTime)(DateTime.MinValue);
         A475VisDataFim = DateTime.MinValue;
         A476VisHoraFim = (DateTime)(DateTime.MinValue);
         A409VisAssunto = "";
         A472VisSituacao = "";
         ucVisdescricao = new GXUserControl();
         VisDescricao = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtnupdate_Jsonclick = "";
         bttBtndelete_Jsonclick = "";
         A477VisDataHoraFim = (DateTime)(DateTime.MinValue);
         A406VisDataHora = (DateTime)(DateTime.MinValue);
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         scmdbuf = "";
         H00572_A414VisTipoID = new int[1] ;
         H00572_A398VisID = new Guid[] {Guid.Empty} ;
         H00572_A418VisNegID = new Guid[] {Guid.Empty} ;
         H00572_n418VisNegID = new bool[] {false} ;
         H00572_A422VisNgfSeq = new int[1] ;
         H00572_n422VisNgfSeq = new bool[] {false} ;
         H00572_A419VisPaiID = new Guid[] {Guid.Empty} ;
         H00572_n419VisPaiID = new bool[] {false} ;
         H00572_A406VisDataHora = new DateTime[] {DateTime.MinValue} ;
         H00572_A477VisDataHoraFim = new DateTime[] {DateTime.MinValue} ;
         H00572_n477VisDataHoraFim = new bool[] {false} ;
         H00572_A410VisDescricao = new string[] {""} ;
         H00572_n410VisDescricao = new bool[] {false} ;
         H00572_A417VisLink = new string[] {""} ;
         H00572_n417VisLink = new bool[] {false} ;
         H00572_A472VisSituacao = new string[] {""} ;
         H00572_A409VisAssunto = new string[] {""} ;
         H00572_A476VisHoraFim = new DateTime[] {DateTime.MinValue} ;
         H00572_n476VisHoraFim = new bool[] {false} ;
         H00572_A475VisDataFim = new DateTime[] {DateTime.MinValue} ;
         H00572_n475VisDataFim = new bool[] {false} ;
         H00572_A405VisHora = new DateTime[] {DateTime.MinValue} ;
         H00572_A404VisData = new DateTime[] {DateTime.MinValue} ;
         H00572_A416VisTipoNome = new string[] {""} ;
         H00572_A462VisPaiDataHora = new DateTime[] {DateTime.MinValue} ;
         H00572_A465VisPaiAssunto = new string[] {""} ;
         H00572_A424VisNgfIteNome = new string[] {""} ;
         H00572_n424VisNgfIteNome = new bool[] {false} ;
         H00572_A468VisNegValor = new decimal[1] ;
         H00572_A470VisNegCpjNomFan = new string[] {""} ;
         H00572_n470VisNegCpjNomFan = new bool[] {false} ;
         H00572_A469VisNegCliNomeFamiliar = new string[] {""} ;
         H00572_n469VisNegCliNomeFamiliar = new bool[] {false} ;
         H00572_A467VisNegAssunto = new string[] {""} ;
         H00572_A466VisNegCodigo = new long[1] ;
         hsh = "";
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV15VisPaiID = Guid.Empty;
         AV8TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV11HTTPRequest = new GxHttpRequest( context);
         AV10Session = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlA398VisID = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.visitageneral__default(),
            new Object[][] {
                new Object[] {
               H00572_A414VisTipoID, H00572_A398VisID, H00572_A418VisNegID, H00572_n418VisNegID, H00572_A422VisNgfSeq, H00572_n422VisNgfSeq, H00572_A419VisPaiID, H00572_n419VisPaiID, H00572_A406VisDataHora, H00572_A477VisDataHoraFim,
               H00572_n477VisDataHoraFim, H00572_A410VisDescricao, H00572_n410VisDescricao, H00572_A417VisLink, H00572_n417VisLink, H00572_A472VisSituacao, H00572_A409VisAssunto, H00572_A476VisHoraFim, H00572_n476VisHoraFim, H00572_A475VisDataFim,
               H00572_n475VisDataFim, H00572_A405VisHora, H00572_A404VisData, H00572_A416VisTipoNome, H00572_A462VisPaiDataHora, H00572_A465VisPaiAssunto, H00572_A424VisNgfIteNome, H00572_n424VisNgfIteNome, H00572_A468VisNegValor, H00572_A470VisNegCpjNomFan,
               H00572_n470VisNegCpjNomFan, H00572_A469VisNegCliNomeFamiliar, H00572_n469VisNegCliNomeFamiliar, H00572_A467VisNegAssunto, H00572_A466VisNegCodigo
               }
            }
         );
         AV18Pgmname = "core.VisitaGeneral";
         /* GeneXus formulas. */
         AV18Pgmname = "core.VisitaGeneral";
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
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int A422VisNgfSeq ;
      private int Visdescricao_Color ;
      private int edtVisNegCodigo_Enabled ;
      private int edtVisNegAssunto_Enabled ;
      private int edtVisNegCliNomeFamiliar_Enabled ;
      private int edtVisNegCpjNomFan_Enabled ;
      private int edtVisNegValor_Enabled ;
      private int edtVisNgfIteNome_Enabled ;
      private int edtVisPaiAssunto_Enabled ;
      private int edtVisPaiDataHora_Enabled ;
      private int edtVisTipoNome_Enabled ;
      private int edtVisData_Enabled ;
      private int edtVisHora_Enabled ;
      private int edtVisDataFim_Enabled ;
      private int edtVisHoraFim_Enabled ;
      private int edtVisAssunto_Enabled ;
      private int edtVisLink_Enabled ;
      private int bttBtnupdate_Visible ;
      private int bttBtndelete_Visible ;
      private int edtVisDataHoraFim_Visible ;
      private int edtVisDataHora_Visible ;
      private int edtVisPaiID_Visible ;
      private int A414VisTipoID ;
      private int idxLst ;
      private long A466VisNegCodigo ;
      private decimal A468VisNegValor ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string AV18Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string Visdescricao_Width ;
      private string Visdescricao_Height ;
      private string Visdescricao_Skin ;
      private string Visdescricao_Toolbar ;
      private string Visdescricao_Captionclass ;
      private string Visdescricao_Captionstyle ;
      private string Visdescricao_Captionposition ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTable_Internalname ;
      private string divTransactiondetail_tableattributes_Internalname ;
      private string edtVisNegCodigo_Internalname ;
      private string edtVisNegCodigo_Jsonclick ;
      private string edtVisNegAssunto_Internalname ;
      private string edtVisNegAssunto_Link ;
      private string edtVisNegAssunto_Jsonclick ;
      private string edtVisNegCliNomeFamiliar_Internalname ;
      private string edtVisNegCliNomeFamiliar_Jsonclick ;
      private string edtVisNegCpjNomFan_Internalname ;
      private string edtVisNegCpjNomFan_Jsonclick ;
      private string edtVisNegValor_Internalname ;
      private string edtVisNegValor_Jsonclick ;
      private string edtVisNgfIteNome_Internalname ;
      private string edtVisNgfIteNome_Jsonclick ;
      private string lblTransactiondetail_txtesp01_Internalname ;
      private string lblTransactiondetail_txtesp01_Jsonclick ;
      private string grpTransactiondetail_tablegroupvisitaorigem_Internalname ;
      private string grpTransactiondetail_tablegroupvisitaorigem_Class ;
      private string divTransactiondetail_tablevisitaorigem_Internalname ;
      private string edtVisPaiAssunto_Internalname ;
      private string edtVisPaiAssunto_Jsonclick ;
      private string edtVisPaiDataHora_Internalname ;
      private string edtVisPaiDataHora_Jsonclick ;
      private string edtVisTipoNome_Internalname ;
      private string edtVisTipoNome_Jsonclick ;
      private string grpUnnamedgroup1_Internalname ;
      private string divTransactiondetail_txtdatahorainicio_Internalname ;
      private string edtVisData_Internalname ;
      private string edtVisData_Jsonclick ;
      private string edtVisHora_Internalname ;
      private string edtVisHora_Jsonclick ;
      private string grpUnnamedgroup2_Internalname ;
      private string divTransactiondetail_txtdatahoratermino_Internalname ;
      private string edtVisDataFim_Internalname ;
      private string edtVisDataFim_Jsonclick ;
      private string edtVisHoraFim_Internalname ;
      private string edtVisHoraFim_Jsonclick ;
      private string edtVisAssunto_Internalname ;
      private string edtVisAssunto_Jsonclick ;
      private string cmbVisSituacao_Internalname ;
      private string cmbVisSituacao_Jsonclick ;
      private string edtVisLink_Internalname ;
      private string edtVisLink_Link ;
      private string edtVisLink_Linktarget ;
      private string edtVisLink_Jsonclick ;
      private string Visdescricao_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtnupdate_Internalname ;
      private string bttBtnupdate_Jsonclick ;
      private string bttBtndelete_Internalname ;
      private string bttBtndelete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtVisDataHoraFim_Internalname ;
      private string edtVisDataHoraFim_Jsonclick ;
      private string edtVisDataHora_Internalname ;
      private string edtVisDataHora_Jsonclick ;
      private string edtVisPaiID_Internalname ;
      private string edtVisPaiID_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string scmdbuf ;
      private string hsh ;
      private string sCtrlA398VisID ;
      private DateTime A462VisPaiDataHora ;
      private DateTime A405VisHora ;
      private DateTime A476VisHoraFim ;
      private DateTime A477VisDataHoraFim ;
      private DateTime A406VisDataHora ;
      private DateTime A404VisData ;
      private DateTime A475VisDataFim ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV12IsAuthorized_Update ;
      private bool AV13IsAuthorized_Delete ;
      private bool Visdescricao_Enabled ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool n418VisNegID ;
      private bool n422VisNgfSeq ;
      private bool n419VisPaiID ;
      private bool n477VisDataHoraFim ;
      private bool n410VisDescricao ;
      private bool n417VisLink ;
      private bool n476VisHoraFim ;
      private bool n475VisDataFim ;
      private bool n424VisNgfIteNome ;
      private bool n470VisNegCpjNomFan ;
      private bool n469VisNegCliNomeFamiliar ;
      private bool returnInSub ;
      private bool AV14TempBoolean ;
      private bool GXt_boolean1 ;
      private string A410VisDescricao ;
      private string VisDescricao ;
      private string A417VisLink ;
      private string A467VisNegAssunto ;
      private string A469VisNegCliNomeFamiliar ;
      private string A470VisNegCpjNomFan ;
      private string A424VisNgfIteNome ;
      private string A465VisPaiAssunto ;
      private string A416VisTipoNome ;
      private string A409VisAssunto ;
      private string A472VisSituacao ;
      private Guid A398VisID ;
      private Guid wcpOA398VisID ;
      private Guid A419VisPaiID ;
      private Guid A418VisNegID ;
      private Guid AV15VisPaiID ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucVisdescricao ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbVisSituacao ;
      private IDataStoreProvider pr_default ;
      private int[] H00572_A414VisTipoID ;
      private Guid[] H00572_A398VisID ;
      private Guid[] H00572_A418VisNegID ;
      private bool[] H00572_n418VisNegID ;
      private int[] H00572_A422VisNgfSeq ;
      private bool[] H00572_n422VisNgfSeq ;
      private Guid[] H00572_A419VisPaiID ;
      private bool[] H00572_n419VisPaiID ;
      private DateTime[] H00572_A406VisDataHora ;
      private DateTime[] H00572_A477VisDataHoraFim ;
      private bool[] H00572_n477VisDataHoraFim ;
      private string[] H00572_A410VisDescricao ;
      private bool[] H00572_n410VisDescricao ;
      private string[] H00572_A417VisLink ;
      private bool[] H00572_n417VisLink ;
      private string[] H00572_A472VisSituacao ;
      private string[] H00572_A409VisAssunto ;
      private DateTime[] H00572_A476VisHoraFim ;
      private bool[] H00572_n476VisHoraFim ;
      private DateTime[] H00572_A475VisDataFim ;
      private bool[] H00572_n475VisDataFim ;
      private DateTime[] H00572_A405VisHora ;
      private DateTime[] H00572_A404VisData ;
      private string[] H00572_A416VisTipoNome ;
      private DateTime[] H00572_A462VisPaiDataHora ;
      private string[] H00572_A465VisPaiAssunto ;
      private string[] H00572_A424VisNgfIteNome ;
      private bool[] H00572_n424VisNgfIteNome ;
      private decimal[] H00572_A468VisNegValor ;
      private string[] H00572_A470VisNegCpjNomFan ;
      private bool[] H00572_n470VisNegCpjNomFan ;
      private string[] H00572_A469VisNegCliNomeFamiliar ;
      private bool[] H00572_n469VisNegCliNomeFamiliar ;
      private string[] H00572_A467VisNegAssunto ;
      private long[] H00572_A466VisNegCodigo ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV11HTTPRequest ;
      private IGxSession AV10Session ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV8TrnContext ;
   }

   public class visitageneral__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH00572;
          prmH00572 = new Object[] {
          new ParDef("VisID",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00572", "SELECT T1.VisTipoID AS VisTipoID, T1.VisID, T1.VisNegID AS VisNegID, T1.VisNgfSeq AS VisNgfSeq, T1.VisPaiID AS VisPaiID, T1.VisDataHora, T1.VisDataHoraFim, T1.VisDescricao, T1.VisLink, T1.VisSituacao, T1.VisAssunto, T1.VisHoraFim, T1.VisDataFim, T1.VisHora, T1.VisData, T2.VitNome AS VisTipoNome, T5.VisDataHora AS VisPaiDataHora, T5.VisAssunto AS VisPaiAssunto, T4.NgfIteNome AS VisNgfIteNome, T3.NegValorAtualizado AS VisNegValor, T3.NegCpjNomFan AS VisNegCpjNomFan, T3.NegCliNomeFamiliar AS VisNegCliNomeFamiliar, T3.NegAssunto AS VisNegAssunto, T3.NegCodigo AS VisNegCodigo FROM ((((tb_visita T1 INNER JOIN tb_visitatipo T2 ON T2.VitID = T1.VisTipoID) LEFT JOIN tb_negociopj T3 ON T3.NegID = T1.VisNegID) LEFT JOIN tb_negociopj_fase T4 ON T4.NegID = T1.VisNegID AND T4.NgfSeq = T1.VisNgfSeq) LEFT JOIN tb_visita T5 ON T5.VisID = T1.VisPaiID) WHERE T1.VisID = :VisID ORDER BY T1.VisID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00572,1, GxCacheFrequency.OFF ,true,true )
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
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((int[]) buf[4])[0] = rslt.getInt(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((Guid[]) buf[6])[0] = rslt.getGuid(5);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(6);
                ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(7);
                ((bool[]) buf[10])[0] = rslt.wasNull(7);
                ((string[]) buf[11])[0] = rslt.getLongVarchar(8);
                ((bool[]) buf[12])[0] = rslt.wasNull(8);
                ((string[]) buf[13])[0] = rslt.getVarchar(9);
                ((bool[]) buf[14])[0] = rslt.wasNull(9);
                ((string[]) buf[15])[0] = rslt.getVarchar(10);
                ((string[]) buf[16])[0] = rslt.getVarchar(11);
                ((DateTime[]) buf[17])[0] = rslt.getGXDateTime(12);
                ((bool[]) buf[18])[0] = rslt.wasNull(12);
                ((DateTime[]) buf[19])[0] = rslt.getGXDate(13);
                ((bool[]) buf[20])[0] = rslt.wasNull(13);
                ((DateTime[]) buf[21])[0] = rslt.getGXDateTime(14);
                ((DateTime[]) buf[22])[0] = rslt.getGXDate(15);
                ((string[]) buf[23])[0] = rslt.getVarchar(16);
                ((DateTime[]) buf[24])[0] = rslt.getGXDateTime(17);
                ((string[]) buf[25])[0] = rslt.getVarchar(18);
                ((string[]) buf[26])[0] = rslt.getVarchar(19);
                ((bool[]) buf[27])[0] = rslt.wasNull(19);
                ((decimal[]) buf[28])[0] = rslt.getDecimal(20);
                ((string[]) buf[29])[0] = rslt.getVarchar(21);
                ((bool[]) buf[30])[0] = rslt.wasNull(21);
                ((string[]) buf[31])[0] = rslt.getVarchar(22);
                ((bool[]) buf[32])[0] = rslt.wasNull(22);
                ((string[]) buf[33])[0] = rslt.getVarchar(23);
                ((long[]) buf[34])[0] = rslt.getLong(24);
                return;
       }
    }

 }

}
