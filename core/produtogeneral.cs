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
   public class produtogeneral : GXWebComponent
   {
      public produtogeneral( )
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

      public produtogeneral( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_PrdID )
      {
         this.A220PrdID = aP0_PrdID;
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
               gxfirstwebparm = GetFirstPar( "PrdID");
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
                  A220PrdID = StringUtil.StrToGuid( GetPar( "PrdID"));
                  AssignAttri(sPrefix, false, "A220PrdID", A220PrdID.ToString());
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(Guid)A220PrdID});
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
                  gxfirstwebparm = GetFirstPar( "PrdID");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "PrdID");
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
            PA3H2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV15Pgmname = "core.ProdutoGeneral";
               WS3H2( ) ;
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
            context.SendWebValue( "Produto General") ;
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
            GXEncryptionTmp = "core.produtogeneral.aspx"+UrlEncode(A220PrdID.ToString());
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("core.produtogeneral.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA220PrdID", wcpOA220PrdID.ToString());
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_UPDATE", AV12IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV12IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_DELETE", AV13IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV13IsAuthorized_Delete, context));
      }

      protected void RenderHtmlCloseForm3H2( )
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
         return "core.ProdutoGeneral" ;
      }

      public override string GetPgmdesc( )
      {
         return "Produto General" ;
      }

      protected void WB3H0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "core.produtogeneral.aspx");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPrdCodigo_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtPrdCodigo_Internalname, "Código", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtPrdCodigo_Internalname, A221PrdCodigo, StringUtil.RTrim( context.localUtil.Format( A221PrdCodigo, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrdCodigo_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPrdCodigo_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 0, -1, -1, true, "core\\ProdutoCodigo", "start", true, "", "HLP_core\\ProdutoGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPrdNome_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtPrdNome_Internalname, "Descrição", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtPrdNome_Internalname, A222PrdNome, StringUtil.RTrim( context.localUtil.Format( A222PrdNome, "@!")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrdNome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPrdNome_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "core\\Nome", "start", true, "", "HLP_core\\ProdutoGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPrdTipoNome_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtPrdTipoNome_Internalname, "Tipo do Produto ou Serviço", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtPrdTipoNome_Internalname, A234PrdTipoNome, StringUtil.RTrim( context.localUtil.Format( A234PrdTipoNome, "@!")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", edtPrdTipoNome_Link, "", "", "", edtPrdTipoNome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPrdTipoNome_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "core\\Nome", "start", true, "", "HLP_core\\ProdutoGeneral.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnupdate_Internalname, "", "Alterar", bttBtnupdate_Jsonclick, 5, "Alterar", "", StyleString, ClassString, bttBtnupdate_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOUPDATE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\ProdutoGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtndelete_Internalname, "", "Excluir", bttBtndelete_Jsonclick, 5, "Excluir", "", StyleString, ClassString, bttBtndelete_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DODELETE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\ProdutoGeneral.htm");
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
            GxWebStd.gx_single_line_edit( context, edtPrdID_Internalname, A220PrdID.ToString(), A220PrdID.ToString(), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrdID_Jsonclick, 0, "Attribute", "", "", "", "", edtPrdID_Visible, 0, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_core\\ProdutoGeneral.htm");
            /* Single line edit */
            context.WriteHtmlText( "<div id=\""+edtPrdInsData_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtPrdInsData_Internalname, context.localUtil.Format(A223PrdInsData, "99/99/99"), context.localUtil.Format( A223PrdInsData, "99/99/99"), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrdInsData_Jsonclick, 0, "Attribute", "", "", "", "", edtPrdInsData_Visible, 0, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "core\\Data", "end", false, "", "HLP_core\\ProdutoGeneral.htm");
            GxWebStd.gx_bitmap( context, edtPrdInsData_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtPrdInsData_Visible==0)||(0==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_core\\ProdutoGeneral.htm");
            context.WriteHtmlTextNl( "</div>") ;
            /* Single line edit */
            context.WriteHtmlText( "<div id=\""+edtPrdInsHora_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtPrdInsHora_Internalname, context.localUtil.TToC( A224PrdInsHora, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A224PrdInsHora, "99:99"), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrdInsHora_Jsonclick, 0, "Attribute", "", "", "", "", edtPrdInsHora_Visible, 0, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 0, -1, 0, true, "core\\HoraMinuto", "end", false, "", "HLP_core\\ProdutoGeneral.htm");
            GxWebStd.gx_bitmap( context, edtPrdInsHora_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtPrdInsHora_Visible==0)||(0==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_core\\ProdutoGeneral.htm");
            context.WriteHtmlTextNl( "</div>") ;
            /* Single line edit */
            context.WriteHtmlText( "<div id=\""+edtPrdInsDataHora_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtPrdInsDataHora_Internalname, context.localUtil.TToC( A225PrdInsDataHora, 10, 12, 0, 3, "/", ":", " "), context.localUtil.Format( A225PrdInsDataHora, "99/99/9999 99:99:99.999"), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrdInsDataHora_Jsonclick, 0, "Attribute", "", "", "", "", edtPrdInsDataHora_Visible, 0, 0, "text", "", 24, "chr", 1, "row", 24, 0, 0, 0, 0, -1, 0, true, "core\\DataHoraSegundoMS", "end", false, "", "HLP_core\\ProdutoGeneral.htm");
            GxWebStd.gx_bitmap( context, edtPrdInsDataHora_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtPrdInsDataHora_Visible==0)||(0==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_core\\ProdutoGeneral.htm");
            context.WriteHtmlTextNl( "</div>") ;
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtPrdInsUsuID_Internalname, StringUtil.RTrim( A226PrdInsUsuID), StringUtil.RTrim( context.localUtil.Format( A226PrdInsUsuID, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrdInsUsuID_Jsonclick, 0, "Attribute", "", "", "", "", edtPrdInsUsuID_Visible, 0, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMGUID", "start", true, "", "HLP_core\\ProdutoGeneral.htm");
            /* Single line edit */
            context.WriteHtmlText( "<div id=\""+edtPrdUpdData_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtPrdUpdData_Internalname, context.localUtil.Format(A227PrdUpdData, "99/99/99"), context.localUtil.Format( A227PrdUpdData, "99/99/99"), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrdUpdData_Jsonclick, 0, "Attribute", "", "", "", "", edtPrdUpdData_Visible, 0, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "core\\Data", "end", false, "", "HLP_core\\ProdutoGeneral.htm");
            GxWebStd.gx_bitmap( context, edtPrdUpdData_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtPrdUpdData_Visible==0)||(0==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_core\\ProdutoGeneral.htm");
            context.WriteHtmlTextNl( "</div>") ;
            /* Single line edit */
            context.WriteHtmlText( "<div id=\""+edtPrdUpdHora_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtPrdUpdHora_Internalname, context.localUtil.TToC( A228PrdUpdHora, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A228PrdUpdHora, "99:99"), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrdUpdHora_Jsonclick, 0, "Attribute", "", "", "", "", edtPrdUpdHora_Visible, 0, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 0, -1, 0, true, "core\\HoraMinuto", "end", false, "", "HLP_core\\ProdutoGeneral.htm");
            GxWebStd.gx_bitmap( context, edtPrdUpdHora_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtPrdUpdHora_Visible==0)||(0==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_core\\ProdutoGeneral.htm");
            context.WriteHtmlTextNl( "</div>") ;
            /* Single line edit */
            context.WriteHtmlText( "<div id=\""+edtPrdUpdDataHora_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtPrdUpdDataHora_Internalname, context.localUtil.TToC( A229PrdUpdDataHora, 10, 12, 0, 3, "/", ":", " "), context.localUtil.Format( A229PrdUpdDataHora, "99/99/9999 99:99:99.999"), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrdUpdDataHora_Jsonclick, 0, "Attribute", "", "", "", "", edtPrdUpdDataHora_Visible, 0, 0, "text", "", 24, "chr", 1, "row", 24, 0, 0, 0, 0, -1, 0, true, "core\\DataHoraSegundoMS", "end", false, "", "HLP_core\\ProdutoGeneral.htm");
            GxWebStd.gx_bitmap( context, edtPrdUpdDataHora_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtPrdUpdDataHora_Visible==0)||(0==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_core\\ProdutoGeneral.htm");
            context.WriteHtmlTextNl( "</div>") ;
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtPrdUpdUsuID_Internalname, StringUtil.RTrim( A230PrdUpdUsuID), StringUtil.RTrim( context.localUtil.Format( A230PrdUpdUsuID, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrdUpdUsuID_Jsonclick, 0, "Attribute", "", "", "", "", edtPrdUpdUsuID_Visible, 0, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMGUID", "start", true, "", "HLP_core\\ProdutoGeneral.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtPrdAtivo_Internalname, StringUtil.BoolToStr( A231PrdAtivo), StringUtil.BoolToStr( A231PrdAtivo), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrdAtivo_Jsonclick, 0, "Attribute", "", "", "", "", edtPrdAtivo_Visible, 0, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 0, 0, 0, true, "core\\Ativo", "end", false, "", "HLP_core\\ProdutoGeneral.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtPrdTipoSigla_Internalname, A233PrdTipoSigla, StringUtil.RTrim( context.localUtil.Format( A233PrdTipoSigla, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrdTipoSigla_Jsonclick, 0, "Attribute", "", "", "", "", edtPrdTipoSigla_Visible, 0, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "core\\Sigla", "start", true, "", "HLP_core\\ProdutoGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START3H2( )
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
               Form.Meta.addItem("description", "Produto General", 0) ;
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
               STRUP3H0( ) ;
            }
         }
      }

      protected void WS3H2( )
      {
         START3H2( ) ;
         EVT3H2( ) ;
      }

      protected void EVT3H2( )
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
                                 STRUP3H0( ) ;
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
                                 STRUP3H0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E113H2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3H0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E123H2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOUPDATE'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3H0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoUpdate' */
                                    E133H2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DODELETE'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3H0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoDelete' */
                                    E143H2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3H0( ) ;
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
                                 STRUP3H0( ) ;
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

      protected void WE3H2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm3H2( ) ;
            }
         }
      }

      protected void PA3H2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "core.produtogeneral.aspx")), "core.produtogeneral.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "core.produtogeneral.aspx")))) ;
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
                     gxfirstwebparm = GetFirstPar( "PrdID");
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
         RF3H2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV15Pgmname = "core.ProdutoGeneral";
      }

      protected void RF3H2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H003H2 */
            pr_default.execute(0, new Object[] {A220PrdID});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A232PrdTipoID = H003H2_A232PrdTipoID[0];
               A233PrdTipoSigla = H003H2_A233PrdTipoSigla[0];
               AssignAttri(sPrefix, false, "A233PrdTipoSigla", A233PrdTipoSigla);
               A231PrdAtivo = H003H2_A231PrdAtivo[0];
               AssignAttri(sPrefix, false, "A231PrdAtivo", A231PrdAtivo);
               A230PrdUpdUsuID = H003H2_A230PrdUpdUsuID[0];
               n230PrdUpdUsuID = H003H2_n230PrdUpdUsuID[0];
               AssignAttri(sPrefix, false, "A230PrdUpdUsuID", A230PrdUpdUsuID);
               A229PrdUpdDataHora = H003H2_A229PrdUpdDataHora[0];
               n229PrdUpdDataHora = H003H2_n229PrdUpdDataHora[0];
               AssignAttri(sPrefix, false, "A229PrdUpdDataHora", context.localUtil.TToC( A229PrdUpdDataHora, 10, 12, 0, 3, "/", ":", " "));
               A228PrdUpdHora = H003H2_A228PrdUpdHora[0];
               n228PrdUpdHora = H003H2_n228PrdUpdHora[0];
               AssignAttri(sPrefix, false, "A228PrdUpdHora", context.localUtil.TToC( A228PrdUpdHora, 0, 5, 0, 3, "/", ":", " "));
               A227PrdUpdData = H003H2_A227PrdUpdData[0];
               n227PrdUpdData = H003H2_n227PrdUpdData[0];
               AssignAttri(sPrefix, false, "A227PrdUpdData", context.localUtil.Format(A227PrdUpdData, "99/99/99"));
               A226PrdInsUsuID = H003H2_A226PrdInsUsuID[0];
               n226PrdInsUsuID = H003H2_n226PrdInsUsuID[0];
               AssignAttri(sPrefix, false, "A226PrdInsUsuID", A226PrdInsUsuID);
               A225PrdInsDataHora = H003H2_A225PrdInsDataHora[0];
               AssignAttri(sPrefix, false, "A225PrdInsDataHora", context.localUtil.TToC( A225PrdInsDataHora, 10, 12, 0, 3, "/", ":", " "));
               A224PrdInsHora = H003H2_A224PrdInsHora[0];
               AssignAttri(sPrefix, false, "A224PrdInsHora", context.localUtil.TToC( A224PrdInsHora, 0, 5, 0, 3, "/", ":", " "));
               A223PrdInsData = H003H2_A223PrdInsData[0];
               AssignAttri(sPrefix, false, "A223PrdInsData", context.localUtil.Format(A223PrdInsData, "99/99/99"));
               A234PrdTipoNome = H003H2_A234PrdTipoNome[0];
               AssignAttri(sPrefix, false, "A234PrdTipoNome", A234PrdTipoNome);
               A222PrdNome = H003H2_A222PrdNome[0];
               AssignAttri(sPrefix, false, "A222PrdNome", A222PrdNome);
               A221PrdCodigo = H003H2_A221PrdCodigo[0];
               AssignAttri(sPrefix, false, "A221PrdCodigo", A221PrdCodigo);
               A233PrdTipoSigla = H003H2_A233PrdTipoSigla[0];
               AssignAttri(sPrefix, false, "A233PrdTipoSigla", A233PrdTipoSigla);
               A234PrdTipoNome = H003H2_A234PrdTipoNome[0];
               AssignAttri(sPrefix, false, "A234PrdTipoNome", A234PrdTipoNome);
               /* Execute user event: Load */
               E123H2 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            WB3H0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes3H2( )
      {
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_UPDATE", AV12IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV12IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_DELETE", AV13IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV13IsAuthorized_Delete, context));
      }

      protected void before_start_formulas( )
      {
         AV15Pgmname = "core.ProdutoGeneral";
         fix_multi_value_controls( ) ;
      }

      protected void STRUP3H0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E113H2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOA220PrdID = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOA220PrdID"));
            /* Read variables values. */
            A221PrdCodigo = cgiGet( edtPrdCodigo_Internalname);
            AssignAttri(sPrefix, false, "A221PrdCodigo", A221PrdCodigo);
            A222PrdNome = StringUtil.Upper( cgiGet( edtPrdNome_Internalname));
            AssignAttri(sPrefix, false, "A222PrdNome", A222PrdNome);
            A234PrdTipoNome = StringUtil.Upper( cgiGet( edtPrdTipoNome_Internalname));
            AssignAttri(sPrefix, false, "A234PrdTipoNome", A234PrdTipoNome);
            A223PrdInsData = context.localUtil.CToD( cgiGet( edtPrdInsData_Internalname), 2);
            AssignAttri(sPrefix, false, "A223PrdInsData", context.localUtil.Format(A223PrdInsData, "99/99/99"));
            A224PrdInsHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtPrdInsHora_Internalname)));
            AssignAttri(sPrefix, false, "A224PrdInsHora", context.localUtil.TToC( A224PrdInsHora, 0, 5, 0, 3, "/", ":", " "));
            A225PrdInsDataHora = context.localUtil.CToT( cgiGet( edtPrdInsDataHora_Internalname));
            AssignAttri(sPrefix, false, "A225PrdInsDataHora", context.localUtil.TToC( A225PrdInsDataHora, 10, 12, 0, 3, "/", ":", " "));
            A226PrdInsUsuID = cgiGet( edtPrdInsUsuID_Internalname);
            n226PrdInsUsuID = false;
            AssignAttri(sPrefix, false, "A226PrdInsUsuID", A226PrdInsUsuID);
            A227PrdUpdData = context.localUtil.CToD( cgiGet( edtPrdUpdData_Internalname), 2);
            n227PrdUpdData = false;
            AssignAttri(sPrefix, false, "A227PrdUpdData", context.localUtil.Format(A227PrdUpdData, "99/99/99"));
            A228PrdUpdHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtPrdUpdHora_Internalname)));
            n228PrdUpdHora = false;
            AssignAttri(sPrefix, false, "A228PrdUpdHora", context.localUtil.TToC( A228PrdUpdHora, 0, 5, 0, 3, "/", ":", " "));
            A229PrdUpdDataHora = context.localUtil.CToT( cgiGet( edtPrdUpdDataHora_Internalname));
            n229PrdUpdDataHora = false;
            AssignAttri(sPrefix, false, "A229PrdUpdDataHora", context.localUtil.TToC( A229PrdUpdDataHora, 10, 12, 0, 3, "/", ":", " "));
            A230PrdUpdUsuID = cgiGet( edtPrdUpdUsuID_Internalname);
            n230PrdUpdUsuID = false;
            AssignAttri(sPrefix, false, "A230PrdUpdUsuID", A230PrdUpdUsuID);
            A231PrdAtivo = StringUtil.StrToBool( cgiGet( edtPrdAtivo_Internalname));
            AssignAttri(sPrefix, false, "A231PrdAtivo", A231PrdAtivo);
            A233PrdTipoSigla = cgiGet( edtPrdTipoSigla_Internalname);
            AssignAttri(sPrefix, false, "A233PrdTipoSigla", A233PrdTipoSigla);
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
         E113H2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E113H2( )
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

      protected void E123H2( )
      {
         /* Load Routine */
         returnInSub = false;
         GXt_boolean1 = AV14TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "produtotipoview_Execute", out  GXt_boolean1) ;
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
            GXEncryptionTmp = "core.produtotipoview.aspx"+UrlEncode(StringUtil.LTrimStr(A232PrdTipoID,9,0)) + "," + UrlEncode(StringUtil.RTrim(""));
            edtPrdTipoNome_Link = formatLink("core.produtotipoview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            AssignProp(sPrefix, false, edtPrdTipoNome_Internalname, "Link", edtPrdTipoNome_Link, true);
         }
         edtPrdID_Visible = 0;
         AssignProp(sPrefix, false, edtPrdID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPrdID_Visible), 5, 0), true);
         edtPrdInsData_Visible = 0;
         AssignProp(sPrefix, false, edtPrdInsData_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPrdInsData_Visible), 5, 0), true);
         edtPrdInsHora_Visible = 0;
         AssignProp(sPrefix, false, edtPrdInsHora_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPrdInsHora_Visible), 5, 0), true);
         edtPrdInsDataHora_Visible = 0;
         AssignProp(sPrefix, false, edtPrdInsDataHora_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPrdInsDataHora_Visible), 5, 0), true);
         edtPrdInsUsuID_Visible = 0;
         AssignProp(sPrefix, false, edtPrdInsUsuID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPrdInsUsuID_Visible), 5, 0), true);
         edtPrdUpdData_Visible = 0;
         AssignProp(sPrefix, false, edtPrdUpdData_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPrdUpdData_Visible), 5, 0), true);
         edtPrdUpdHora_Visible = 0;
         AssignProp(sPrefix, false, edtPrdUpdHora_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPrdUpdHora_Visible), 5, 0), true);
         edtPrdUpdDataHora_Visible = 0;
         AssignProp(sPrefix, false, edtPrdUpdDataHora_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPrdUpdDataHora_Visible), 5, 0), true);
         edtPrdUpdUsuID_Visible = 0;
         AssignProp(sPrefix, false, edtPrdUpdUsuID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPrdUpdUsuID_Visible), 5, 0), true);
         edtPrdAtivo_Visible = 0;
         AssignProp(sPrefix, false, edtPrdAtivo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPrdAtivo_Visible), 5, 0), true);
         edtPrdTipoSigla_Visible = 0;
         AssignProp(sPrefix, false, edtPrdTipoSigla_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPrdTipoSigla_Visible), 5, 0), true);
         GXt_boolean1 = AV12IsAuthorized_Update;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "produto_Update", out  GXt_boolean1) ;
         AV12IsAuthorized_Update = GXt_boolean1;
         AssignAttri(sPrefix, false, "AV12IsAuthorized_Update", AV12IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV12IsAuthorized_Update, context));
         if ( ! ( AV12IsAuthorized_Update ) )
         {
            bttBtnupdate_Visible = 0;
            AssignProp(sPrefix, false, bttBtnupdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnupdate_Visible), 5, 0), true);
         }
         GXt_boolean1 = AV13IsAuthorized_Delete;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "produto_Delete", out  GXt_boolean1) ;
         AV13IsAuthorized_Delete = GXt_boolean1;
         AssignAttri(sPrefix, false, "AV13IsAuthorized_Delete", AV13IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV13IsAuthorized_Delete, context));
         if ( ! ( AV13IsAuthorized_Delete ) )
         {
            bttBtndelete_Visible = 0;
            AssignProp(sPrefix, false, bttBtndelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtndelete_Visible), 5, 0), true);
         }
      }

      protected void E133H2( )
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
            GXEncryptionTmp = "core.produto.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(A220PrdID.ToString());
            CallWebObject(formatLink("core.produto.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
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

      protected void E143H2( )
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
            GXEncryptionTmp = "core.produto.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(A220PrdID.ToString());
            CallWebObject(formatLink("core.produto.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
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
         AV8TrnContext.gxTpr_Transactionname = "core.Produto";
         AV10Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A220PrdID = (Guid)getParm(obj,0);
         AssignAttri(sPrefix, false, "A220PrdID", A220PrdID.ToString());
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
         PA3H2( ) ;
         WS3H2( ) ;
         WE3H2( ) ;
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
         sCtrlA220PrdID = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA3H2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "core\\produtogeneral", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA3H2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            A220PrdID = (Guid)getParm(obj,2);
            AssignAttri(sPrefix, false, "A220PrdID", A220PrdID.ToString());
         }
         wcpOA220PrdID = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOA220PrdID"));
         if ( ! GetJustCreated( ) && ( ( A220PrdID != wcpOA220PrdID ) ) )
         {
            setjustcreated();
         }
         wcpOA220PrdID = A220PrdID;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlA220PrdID = cgiGet( sPrefix+"A220PrdID_CTRL");
         if ( StringUtil.Len( sCtrlA220PrdID) > 0 )
         {
            A220PrdID = StringUtil.StrToGuid( cgiGet( sCtrlA220PrdID));
            AssignAttri(sPrefix, false, "A220PrdID", A220PrdID.ToString());
         }
         else
         {
            A220PrdID = StringUtil.StrToGuid( cgiGet( sPrefix+"A220PrdID_PARM"));
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
         PA3H2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS3H2( ) ;
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
         WS3H2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"A220PrdID_PARM", A220PrdID.ToString());
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA220PrdID)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A220PrdID_CTRL", StringUtil.RTrim( sCtrlA220PrdID));
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
         WE3H2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202382813326", true, true);
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
         context.AddJavascriptSource("core/produtogeneral.js", "?202382813326", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtPrdCodigo_Internalname = sPrefix+"PRDCODIGO";
         edtPrdNome_Internalname = sPrefix+"PRDNOME";
         edtPrdTipoNome_Internalname = sPrefix+"PRDTIPONOME";
         divTransactiondetail_tableattributes_Internalname = sPrefix+"TRANSACTIONDETAIL_TABLEATTRIBUTES";
         bttBtnupdate_Internalname = sPrefix+"BTNUPDATE";
         bttBtndelete_Internalname = sPrefix+"BTNDELETE";
         divTable_Internalname = sPrefix+"TABLE";
         edtPrdID_Internalname = sPrefix+"PRDID";
         edtPrdInsData_Internalname = sPrefix+"PRDINSDATA";
         edtPrdInsHora_Internalname = sPrefix+"PRDINSHORA";
         edtPrdInsDataHora_Internalname = sPrefix+"PRDINSDATAHORA";
         edtPrdInsUsuID_Internalname = sPrefix+"PRDINSUSUID";
         edtPrdUpdData_Internalname = sPrefix+"PRDUPDDATA";
         edtPrdUpdHora_Internalname = sPrefix+"PRDUPDHORA";
         edtPrdUpdDataHora_Internalname = sPrefix+"PRDUPDDATAHORA";
         edtPrdUpdUsuID_Internalname = sPrefix+"PRDUPDUSUID";
         edtPrdAtivo_Internalname = sPrefix+"PRDATIVO";
         edtPrdTipoSigla_Internalname = sPrefix+"PRDTIPOSIGLA";
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
         edtPrdTipoSigla_Jsonclick = "";
         edtPrdTipoSigla_Visible = 1;
         edtPrdAtivo_Jsonclick = "";
         edtPrdAtivo_Visible = 1;
         edtPrdUpdUsuID_Jsonclick = "";
         edtPrdUpdUsuID_Visible = 1;
         edtPrdUpdDataHora_Jsonclick = "";
         edtPrdUpdDataHora_Visible = 1;
         edtPrdUpdHora_Jsonclick = "";
         edtPrdUpdHora_Visible = 1;
         edtPrdUpdData_Jsonclick = "";
         edtPrdUpdData_Visible = 1;
         edtPrdInsUsuID_Jsonclick = "";
         edtPrdInsUsuID_Visible = 1;
         edtPrdInsDataHora_Jsonclick = "";
         edtPrdInsDataHora_Visible = 1;
         edtPrdInsHora_Jsonclick = "";
         edtPrdInsHora_Visible = 1;
         edtPrdInsData_Jsonclick = "";
         edtPrdInsData_Visible = 1;
         edtPrdID_Jsonclick = "";
         edtPrdID_Visible = 1;
         bttBtndelete_Visible = 1;
         bttBtnupdate_Visible = 1;
         edtPrdTipoNome_Jsonclick = "";
         edtPrdTipoNome_Link = "";
         edtPrdTipoNome_Enabled = 0;
         edtPrdNome_Jsonclick = "";
         edtPrdNome_Enabled = 0;
         edtPrdCodigo_Jsonclick = "";
         edtPrdCodigo_Enabled = 0;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A220PrdID',fld:'PRDID',pic:''},{av:'AV12IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV13IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'DOUPDATE'","{handler:'E133H2',iparms:[{av:'AV12IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'A220PrdID',fld:'PRDID',pic:''}]");
         setEventMetadata("'DOUPDATE'",",oparms:[{ctrl:'BTNUPDATE',prop:'Visible'}]}");
         setEventMetadata("'DODELETE'","{handler:'E143H2',iparms:[{av:'AV13IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'A220PrdID',fld:'PRDID',pic:''}]");
         setEventMetadata("'DODELETE'",",oparms:[{ctrl:'BTNDELETE',prop:'Visible'}]}");
         setEventMetadata("VALID_PRDID","{handler:'Valid_Prdid',iparms:[]");
         setEventMetadata("VALID_PRDID",",oparms:[]}");
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
         wcpOA220PrdID = Guid.Empty;
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV15Pgmname = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         GX_FocusControl = "";
         A221PrdCodigo = "";
         A222PrdNome = "";
         A234PrdTipoNome = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtnupdate_Jsonclick = "";
         bttBtndelete_Jsonclick = "";
         A223PrdInsData = DateTime.MinValue;
         A224PrdInsHora = (DateTime)(DateTime.MinValue);
         A225PrdInsDataHora = (DateTime)(DateTime.MinValue);
         A226PrdInsUsuID = "";
         A227PrdUpdData = DateTime.MinValue;
         A228PrdUpdHora = (DateTime)(DateTime.MinValue);
         A229PrdUpdDataHora = (DateTime)(DateTime.MinValue);
         A230PrdUpdUsuID = "";
         A233PrdTipoSigla = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         scmdbuf = "";
         H003H2_A220PrdID = new Guid[] {Guid.Empty} ;
         H003H2_A232PrdTipoID = new int[1] ;
         H003H2_A233PrdTipoSigla = new string[] {""} ;
         H003H2_A231PrdAtivo = new bool[] {false} ;
         H003H2_A230PrdUpdUsuID = new string[] {""} ;
         H003H2_n230PrdUpdUsuID = new bool[] {false} ;
         H003H2_A229PrdUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         H003H2_n229PrdUpdDataHora = new bool[] {false} ;
         H003H2_A228PrdUpdHora = new DateTime[] {DateTime.MinValue} ;
         H003H2_n228PrdUpdHora = new bool[] {false} ;
         H003H2_A227PrdUpdData = new DateTime[] {DateTime.MinValue} ;
         H003H2_n227PrdUpdData = new bool[] {false} ;
         H003H2_A226PrdInsUsuID = new string[] {""} ;
         H003H2_n226PrdInsUsuID = new bool[] {false} ;
         H003H2_A225PrdInsDataHora = new DateTime[] {DateTime.MinValue} ;
         H003H2_A224PrdInsHora = new DateTime[] {DateTime.MinValue} ;
         H003H2_A223PrdInsData = new DateTime[] {DateTime.MinValue} ;
         H003H2_A234PrdTipoNome = new string[] {""} ;
         H003H2_A222PrdNome = new string[] {""} ;
         H003H2_A221PrdCodigo = new string[] {""} ;
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV8TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV11HTTPRequest = new GxHttpRequest( context);
         AV10Session = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlA220PrdID = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.produtogeneral__default(),
            new Object[][] {
                new Object[] {
               H003H2_A220PrdID, H003H2_A232PrdTipoID, H003H2_A233PrdTipoSigla, H003H2_A231PrdAtivo, H003H2_A230PrdUpdUsuID, H003H2_n230PrdUpdUsuID, H003H2_A229PrdUpdDataHora, H003H2_n229PrdUpdDataHora, H003H2_A228PrdUpdHora, H003H2_n228PrdUpdHora,
               H003H2_A227PrdUpdData, H003H2_n227PrdUpdData, H003H2_A226PrdInsUsuID, H003H2_n226PrdInsUsuID, H003H2_A225PrdInsDataHora, H003H2_A224PrdInsHora, H003H2_A223PrdInsData, H003H2_A234PrdTipoNome, H003H2_A222PrdNome, H003H2_A221PrdCodigo
               }
            }
         );
         AV15Pgmname = "core.ProdutoGeneral";
         /* GeneXus formulas. */
         AV15Pgmname = "core.ProdutoGeneral";
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
      private int edtPrdCodigo_Enabled ;
      private int edtPrdNome_Enabled ;
      private int edtPrdTipoNome_Enabled ;
      private int bttBtnupdate_Visible ;
      private int bttBtndelete_Visible ;
      private int edtPrdID_Visible ;
      private int edtPrdInsData_Visible ;
      private int edtPrdInsHora_Visible ;
      private int edtPrdInsDataHora_Visible ;
      private int edtPrdInsUsuID_Visible ;
      private int edtPrdUpdData_Visible ;
      private int edtPrdUpdHora_Visible ;
      private int edtPrdUpdDataHora_Visible ;
      private int edtPrdUpdUsuID_Visible ;
      private int edtPrdAtivo_Visible ;
      private int edtPrdTipoSigla_Visible ;
      private int A232PrdTipoID ;
      private int idxLst ;
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
      private string edtPrdCodigo_Internalname ;
      private string edtPrdCodigo_Jsonclick ;
      private string edtPrdNome_Internalname ;
      private string edtPrdNome_Jsonclick ;
      private string edtPrdTipoNome_Internalname ;
      private string edtPrdTipoNome_Link ;
      private string edtPrdTipoNome_Jsonclick ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtnupdate_Internalname ;
      private string bttBtnupdate_Jsonclick ;
      private string bttBtndelete_Internalname ;
      private string bttBtndelete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtPrdID_Internalname ;
      private string edtPrdID_Jsonclick ;
      private string edtPrdInsData_Internalname ;
      private string edtPrdInsData_Jsonclick ;
      private string edtPrdInsHora_Internalname ;
      private string edtPrdInsHora_Jsonclick ;
      private string edtPrdInsDataHora_Internalname ;
      private string edtPrdInsDataHora_Jsonclick ;
      private string edtPrdInsUsuID_Internalname ;
      private string A226PrdInsUsuID ;
      private string edtPrdInsUsuID_Jsonclick ;
      private string edtPrdUpdData_Internalname ;
      private string edtPrdUpdData_Jsonclick ;
      private string edtPrdUpdHora_Internalname ;
      private string edtPrdUpdHora_Jsonclick ;
      private string edtPrdUpdDataHora_Internalname ;
      private string edtPrdUpdDataHora_Jsonclick ;
      private string edtPrdUpdUsuID_Internalname ;
      private string A230PrdUpdUsuID ;
      private string edtPrdUpdUsuID_Jsonclick ;
      private string edtPrdAtivo_Internalname ;
      private string edtPrdAtivo_Jsonclick ;
      private string edtPrdTipoSigla_Internalname ;
      private string edtPrdTipoSigla_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string scmdbuf ;
      private string sCtrlA220PrdID ;
      private DateTime A224PrdInsHora ;
      private DateTime A225PrdInsDataHora ;
      private DateTime A228PrdUpdHora ;
      private DateTime A229PrdUpdDataHora ;
      private DateTime A223PrdInsData ;
      private DateTime A227PrdUpdData ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV12IsAuthorized_Update ;
      private bool AV13IsAuthorized_Delete ;
      private bool wbLoad ;
      private bool A231PrdAtivo ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool n230PrdUpdUsuID ;
      private bool n229PrdUpdDataHora ;
      private bool n228PrdUpdHora ;
      private bool n227PrdUpdData ;
      private bool n226PrdInsUsuID ;
      private bool returnInSub ;
      private bool AV14TempBoolean ;
      private bool GXt_boolean1 ;
      private string A221PrdCodigo ;
      private string A222PrdNome ;
      private string A234PrdTipoNome ;
      private string A233PrdTipoSigla ;
      private Guid A220PrdID ;
      private Guid wcpOA220PrdID ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] H003H2_A220PrdID ;
      private int[] H003H2_A232PrdTipoID ;
      private string[] H003H2_A233PrdTipoSigla ;
      private bool[] H003H2_A231PrdAtivo ;
      private string[] H003H2_A230PrdUpdUsuID ;
      private bool[] H003H2_n230PrdUpdUsuID ;
      private DateTime[] H003H2_A229PrdUpdDataHora ;
      private bool[] H003H2_n229PrdUpdDataHora ;
      private DateTime[] H003H2_A228PrdUpdHora ;
      private bool[] H003H2_n228PrdUpdHora ;
      private DateTime[] H003H2_A227PrdUpdData ;
      private bool[] H003H2_n227PrdUpdData ;
      private string[] H003H2_A226PrdInsUsuID ;
      private bool[] H003H2_n226PrdInsUsuID ;
      private DateTime[] H003H2_A225PrdInsDataHora ;
      private DateTime[] H003H2_A224PrdInsHora ;
      private DateTime[] H003H2_A223PrdInsData ;
      private string[] H003H2_A234PrdTipoNome ;
      private string[] H003H2_A222PrdNome ;
      private string[] H003H2_A221PrdCodigo ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV11HTTPRequest ;
      private IGxSession AV10Session ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV8TrnContext ;
   }

   public class produtogeneral__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH003H2;
          prmH003H2 = new Object[] {
          new ParDef("PrdID",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("H003H2", "SELECT T1.PrdID, T1.PrdTipoID AS PrdTipoID, T2.PrtSigla AS PrdTipoSigla, T1.PrdAtivo, T1.PrdUpdUsuID, T1.PrdUpdDataHora, T1.PrdUpdHora, T1.PrdUpdData, T1.PrdInsUsuID, T1.PrdInsDataHora, T1.PrdInsHora, T1.PrdInsData, T2.PrtNome AS PrdTipoNome, T1.PrdNome, T1.PrdCodigo FROM (tb_produto T1 INNER JOIN tb_produtotipo T2 ON T2.PrtID = T1.PrdTipoID) WHERE T1.PrdID = :PrdID ORDER BY T1.PrdID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003H2,1, GxCacheFrequency.OFF ,true,true )
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
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((bool[]) buf[3])[0] = rslt.getBool(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 40);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(6, true);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(7);
                ((bool[]) buf[9])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[10])[0] = rslt.getGXDate(8);
                ((bool[]) buf[11])[0] = rslt.wasNull(8);
                ((string[]) buf[12])[0] = rslt.getString(9, 40);
                ((bool[]) buf[13])[0] = rslt.wasNull(9);
                ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(10, true);
                ((DateTime[]) buf[15])[0] = rslt.getGXDateTime(11);
                ((DateTime[]) buf[16])[0] = rslt.getGXDate(12);
                ((string[]) buf[17])[0] = rslt.getVarchar(13);
                ((string[]) buf[18])[0] = rslt.getVarchar(14);
                ((string[]) buf[19])[0] = rslt.getVarchar(15);
                return;
       }
    }

 }

}
