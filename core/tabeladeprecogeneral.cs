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
   public class tabeladeprecogeneral : GXWebComponent
   {
      public tabeladeprecogeneral( )
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

      public tabeladeprecogeneral( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_TppID )
      {
         this.A235TppID = aP0_TppID;
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
               gxfirstwebparm = GetFirstPar( "TppID");
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
                  A235TppID = StringUtil.StrToGuid( GetPar( "TppID"));
                  AssignAttri(sPrefix, false, "A235TppID", A235TppID.ToString());
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(Guid)A235TppID});
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
                  gxfirstwebparm = GetFirstPar( "TppID");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "TppID");
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
            PA3K2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV14Pgmname = "core.TabelaDePrecoGeneral";
               WS3K2( ) ;
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
            context.SendWebValue( "Tabela De Preco General") ;
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
            GXEncryptionTmp = "core.tabeladeprecogeneral.aspx"+UrlEncode(A235TppID.ToString());
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("core.tabeladeprecogeneral.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA235TppID", wcpOA235TppID.ToString());
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_UPDATE", AV12IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV12IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_DELETE", AV13IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV13IsAuthorized_Delete, context));
      }

      protected void RenderHtmlCloseForm3K2( )
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
         return "core.TabelaDePrecoGeneral" ;
      }

      public override string GetPgmdesc( )
      {
         return "Tabela De Preco General" ;
      }

      protected void WB3K0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "core.tabeladeprecogeneral.aspx");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTppCodigo_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtTppCodigo_Internalname, "Código", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtTppCodigo_Internalname, A236TppCodigo, StringUtil.RTrim( context.localUtil.Format( A236TppCodigo, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTppCodigo_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtTppCodigo_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "core\\TabelaDePrecoCodigo", "start", true, "", "HLP_core\\TabelaDePrecoGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTppNome_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtTppNome_Internalname, "Descrição", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtTppNome_Internalname, A237TppNome, StringUtil.RTrim( context.localUtil.Format( A237TppNome, "@!")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTppNome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtTppNome_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "core\\Nome", "start", true, "", "HLP_core\\TabelaDePrecoGeneral.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnupdate_Internalname, "", "Alterar", bttBtnupdate_Jsonclick, 5, "Alterar", "", StyleString, ClassString, bttBtnupdate_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOUPDATE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\TabelaDePrecoGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtndelete_Internalname, "", "Excluir", bttBtndelete_Jsonclick, 5, "Excluir", "", StyleString, ClassString, bttBtndelete_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DODELETE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\TabelaDePrecoGeneral.htm");
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
            GxWebStd.gx_single_line_edit( context, edtTppID_Internalname, A235TppID.ToString(), A235TppID.ToString(), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTppID_Jsonclick, 0, "Attribute", "", "", "", "", edtTppID_Visible, 0, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_core\\TabelaDePrecoGeneral.htm");
            /* Single line edit */
            context.WriteHtmlText( "<div id=\""+edtTppInsData_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtTppInsData_Internalname, context.localUtil.Format(A238TppInsData, "99/99/99"), context.localUtil.Format( A238TppInsData, "99/99/99"), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTppInsData_Jsonclick, 0, "Attribute", "", "", "", "", edtTppInsData_Visible, 0, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "core\\Data", "end", false, "", "HLP_core\\TabelaDePrecoGeneral.htm");
            GxWebStd.gx_bitmap( context, edtTppInsData_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtTppInsData_Visible==0)||(0==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_core\\TabelaDePrecoGeneral.htm");
            context.WriteHtmlTextNl( "</div>") ;
            /* Single line edit */
            context.WriteHtmlText( "<div id=\""+edtTppInsHora_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtTppInsHora_Internalname, context.localUtil.TToC( A239TppInsHora, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A239TppInsHora, "99:99"), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTppInsHora_Jsonclick, 0, "Attribute", "", "", "", "", edtTppInsHora_Visible, 0, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 0, -1, 0, true, "core\\HoraMinuto", "end", false, "", "HLP_core\\TabelaDePrecoGeneral.htm");
            GxWebStd.gx_bitmap( context, edtTppInsHora_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtTppInsHora_Visible==0)||(0==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_core\\TabelaDePrecoGeneral.htm");
            context.WriteHtmlTextNl( "</div>") ;
            /* Single line edit */
            context.WriteHtmlText( "<div id=\""+edtTppInsDataHora_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtTppInsDataHora_Internalname, context.localUtil.TToC( A240TppInsDataHora, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A240TppInsDataHora, "99/99/9999 99:99:99"), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTppInsDataHora_Jsonclick, 0, "Attribute", "", "", "", "", edtTppInsDataHora_Visible, 0, 0, "text", "", 19, "chr", 1, "row", 19, 0, 0, 0, 0, -1, 0, true, "core\\DataHoraSegundo", "end", false, "", "HLP_core\\TabelaDePrecoGeneral.htm");
            GxWebStd.gx_bitmap( context, edtTppInsDataHora_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtTppInsDataHora_Visible==0)||(0==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_core\\TabelaDePrecoGeneral.htm");
            context.WriteHtmlTextNl( "</div>") ;
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtTppInsUsuID_Internalname, StringUtil.RTrim( A241TppInsUsuID), StringUtil.RTrim( context.localUtil.Format( A241TppInsUsuID, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTppInsUsuID_Jsonclick, 0, "Attribute", "", "", "", "", edtTppInsUsuID_Visible, 0, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMGUID", "start", true, "", "HLP_core\\TabelaDePrecoGeneral.htm");
            /* Single line edit */
            context.WriteHtmlText( "<div id=\""+edtTppUpdData_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtTppUpdData_Internalname, context.localUtil.Format(A242TppUpdData, "99/99/99"), context.localUtil.Format( A242TppUpdData, "99/99/99"), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTppUpdData_Jsonclick, 0, "Attribute", "", "", "", "", edtTppUpdData_Visible, 0, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "core\\Data", "end", false, "", "HLP_core\\TabelaDePrecoGeneral.htm");
            GxWebStd.gx_bitmap( context, edtTppUpdData_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtTppUpdData_Visible==0)||(0==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_core\\TabelaDePrecoGeneral.htm");
            context.WriteHtmlTextNl( "</div>") ;
            /* Single line edit */
            context.WriteHtmlText( "<div id=\""+edtTppUpdHora_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtTppUpdHora_Internalname, context.localUtil.TToC( A243TppUpdHora, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A243TppUpdHora, "99/99/9999 99:99"), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTppUpdHora_Jsonclick, 0, "Attribute", "", "", "", "", edtTppUpdHora_Visible, 0, 0, "text", "", 16, "chr", 1, "row", 16, 0, 0, 0, 0, -1, 0, true, "core\\DataHora", "end", false, "", "HLP_core\\TabelaDePrecoGeneral.htm");
            GxWebStd.gx_bitmap( context, edtTppUpdHora_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtTppUpdHora_Visible==0)||(0==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_core\\TabelaDePrecoGeneral.htm");
            context.WriteHtmlTextNl( "</div>") ;
            /* Single line edit */
            context.WriteHtmlText( "<div id=\""+edtTppUpdDataHora_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtTppUpdDataHora_Internalname, context.localUtil.TToC( A244TppUpdDataHora, 10, 12, 0, 3, "/", ":", " "), context.localUtil.Format( A244TppUpdDataHora, "99/99/9999 99:99:99.999"), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTppUpdDataHora_Jsonclick, 0, "Attribute", "", "", "", "", edtTppUpdDataHora_Visible, 0, 0, "text", "", 24, "chr", 1, "row", 24, 0, 0, 0, 0, -1, 0, true, "core\\DataHoraSegundoMS", "end", false, "", "HLP_core\\TabelaDePrecoGeneral.htm");
            GxWebStd.gx_bitmap( context, edtTppUpdDataHora_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtTppUpdDataHora_Visible==0)||(0==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_core\\TabelaDePrecoGeneral.htm");
            context.WriteHtmlTextNl( "</div>") ;
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtTppUpdUsuID_Internalname, StringUtil.RTrim( A245TppUpdUsuID), StringUtil.RTrim( context.localUtil.Format( A245TppUpdUsuID, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTppUpdUsuID_Jsonclick, 0, "Attribute", "", "", "", "", edtTppUpdUsuID_Visible, 0, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMGUID", "start", true, "", "HLP_core\\TabelaDePrecoGeneral.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtTppAtivo_Internalname, StringUtil.BoolToStr( A246TppAtivo), StringUtil.BoolToStr( A246TppAtivo), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTppAtivo_Jsonclick, 0, "Attribute", "", "", "", "", edtTppAtivo_Visible, 0, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 0, 0, 0, true, "core\\Ativo", "end", false, "", "HLP_core\\TabelaDePrecoGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START3K2( )
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
               Form.Meta.addItem("description", "Tabela De Preco General", 0) ;
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
               STRUP3K0( ) ;
            }
         }
      }

      protected void WS3K2( )
      {
         START3K2( ) ;
         EVT3K2( ) ;
      }

      protected void EVT3K2( )
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
                                 STRUP3K0( ) ;
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
                                 STRUP3K0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E113K2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3K0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E123K2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOUPDATE'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3K0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoUpdate' */
                                    E133K2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DODELETE'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3K0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoDelete' */
                                    E143K2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3K0( ) ;
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
                                 STRUP3K0( ) ;
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

      protected void WE3K2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm3K2( ) ;
            }
         }
      }

      protected void PA3K2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "core.tabeladeprecogeneral.aspx")), "core.tabeladeprecogeneral.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "core.tabeladeprecogeneral.aspx")))) ;
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
                     gxfirstwebparm = GetFirstPar( "TppID");
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
         RF3K2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV14Pgmname = "core.TabelaDePrecoGeneral";
      }

      protected void RF3K2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H003K2 */
            pr_default.execute(0, new Object[] {A235TppID});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A246TppAtivo = H003K2_A246TppAtivo[0];
               n246TppAtivo = H003K2_n246TppAtivo[0];
               AssignAttri(sPrefix, false, "A246TppAtivo", A246TppAtivo);
               A245TppUpdUsuID = H003K2_A245TppUpdUsuID[0];
               n245TppUpdUsuID = H003K2_n245TppUpdUsuID[0];
               AssignAttri(sPrefix, false, "A245TppUpdUsuID", A245TppUpdUsuID);
               A244TppUpdDataHora = H003K2_A244TppUpdDataHora[0];
               n244TppUpdDataHora = H003K2_n244TppUpdDataHora[0];
               AssignAttri(sPrefix, false, "A244TppUpdDataHora", context.localUtil.TToC( A244TppUpdDataHora, 10, 12, 0, 3, "/", ":", " "));
               A243TppUpdHora = H003K2_A243TppUpdHora[0];
               n243TppUpdHora = H003K2_n243TppUpdHora[0];
               AssignAttri(sPrefix, false, "A243TppUpdHora", context.localUtil.TToC( A243TppUpdHora, 10, 5, 0, 3, "/", ":", " "));
               A242TppUpdData = H003K2_A242TppUpdData[0];
               n242TppUpdData = H003K2_n242TppUpdData[0];
               AssignAttri(sPrefix, false, "A242TppUpdData", context.localUtil.Format(A242TppUpdData, "99/99/99"));
               A241TppInsUsuID = H003K2_A241TppInsUsuID[0];
               n241TppInsUsuID = H003K2_n241TppInsUsuID[0];
               AssignAttri(sPrefix, false, "A241TppInsUsuID", A241TppInsUsuID);
               A240TppInsDataHora = H003K2_A240TppInsDataHora[0];
               AssignAttri(sPrefix, false, "A240TppInsDataHora", context.localUtil.TToC( A240TppInsDataHora, 10, 8, 0, 3, "/", ":", " "));
               A239TppInsHora = H003K2_A239TppInsHora[0];
               AssignAttri(sPrefix, false, "A239TppInsHora", context.localUtil.TToC( A239TppInsHora, 0, 5, 0, 3, "/", ":", " "));
               A238TppInsData = H003K2_A238TppInsData[0];
               AssignAttri(sPrefix, false, "A238TppInsData", context.localUtil.Format(A238TppInsData, "99/99/99"));
               A237TppNome = H003K2_A237TppNome[0];
               AssignAttri(sPrefix, false, "A237TppNome", A237TppNome);
               A236TppCodigo = H003K2_A236TppCodigo[0];
               AssignAttri(sPrefix, false, "A236TppCodigo", A236TppCodigo);
               /* Execute user event: Load */
               E123K2 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            WB3K0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes3K2( )
      {
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_UPDATE", AV12IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV12IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISAUTHORIZED_DELETE", AV13IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV13IsAuthorized_Delete, context));
      }

      protected void before_start_formulas( )
      {
         AV14Pgmname = "core.TabelaDePrecoGeneral";
         fix_multi_value_controls( ) ;
      }

      protected void STRUP3K0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E113K2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOA235TppID = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOA235TppID"));
            /* Read variables values. */
            A236TppCodigo = cgiGet( edtTppCodigo_Internalname);
            AssignAttri(sPrefix, false, "A236TppCodigo", A236TppCodigo);
            A237TppNome = StringUtil.Upper( cgiGet( edtTppNome_Internalname));
            AssignAttri(sPrefix, false, "A237TppNome", A237TppNome);
            A238TppInsData = context.localUtil.CToD( cgiGet( edtTppInsData_Internalname), 2);
            AssignAttri(sPrefix, false, "A238TppInsData", context.localUtil.Format(A238TppInsData, "99/99/99"));
            A239TppInsHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtTppInsHora_Internalname)));
            AssignAttri(sPrefix, false, "A239TppInsHora", context.localUtil.TToC( A239TppInsHora, 0, 5, 0, 3, "/", ":", " "));
            A240TppInsDataHora = context.localUtil.CToT( cgiGet( edtTppInsDataHora_Internalname));
            AssignAttri(sPrefix, false, "A240TppInsDataHora", context.localUtil.TToC( A240TppInsDataHora, 10, 8, 0, 3, "/", ":", " "));
            A241TppInsUsuID = cgiGet( edtTppInsUsuID_Internalname);
            n241TppInsUsuID = false;
            AssignAttri(sPrefix, false, "A241TppInsUsuID", A241TppInsUsuID);
            A242TppUpdData = context.localUtil.CToD( cgiGet( edtTppUpdData_Internalname), 2);
            n242TppUpdData = false;
            AssignAttri(sPrefix, false, "A242TppUpdData", context.localUtil.Format(A242TppUpdData, "99/99/99"));
            A243TppUpdHora = context.localUtil.CToT( cgiGet( edtTppUpdHora_Internalname));
            n243TppUpdHora = false;
            AssignAttri(sPrefix, false, "A243TppUpdHora", context.localUtil.TToC( A243TppUpdHora, 10, 5, 0, 3, "/", ":", " "));
            A244TppUpdDataHora = context.localUtil.CToT( cgiGet( edtTppUpdDataHora_Internalname));
            n244TppUpdDataHora = false;
            AssignAttri(sPrefix, false, "A244TppUpdDataHora", context.localUtil.TToC( A244TppUpdDataHora, 10, 12, 0, 3, "/", ":", " "));
            A245TppUpdUsuID = cgiGet( edtTppUpdUsuID_Internalname);
            n245TppUpdUsuID = false;
            AssignAttri(sPrefix, false, "A245TppUpdUsuID", A245TppUpdUsuID);
            A246TppAtivo = StringUtil.StrToBool( cgiGet( edtTppAtivo_Internalname));
            n246TppAtivo = false;
            AssignAttri(sPrefix, false, "A246TppAtivo", A246TppAtivo);
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
         E113K2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E113K2( )
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

      protected void E123K2( )
      {
         /* Load Routine */
         returnInSub = false;
         edtTppID_Visible = 0;
         AssignProp(sPrefix, false, edtTppID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTppID_Visible), 5, 0), true);
         edtTppInsData_Visible = 0;
         AssignProp(sPrefix, false, edtTppInsData_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTppInsData_Visible), 5, 0), true);
         edtTppInsHora_Visible = 0;
         AssignProp(sPrefix, false, edtTppInsHora_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTppInsHora_Visible), 5, 0), true);
         edtTppInsDataHora_Visible = 0;
         AssignProp(sPrefix, false, edtTppInsDataHora_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTppInsDataHora_Visible), 5, 0), true);
         edtTppInsUsuID_Visible = 0;
         AssignProp(sPrefix, false, edtTppInsUsuID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTppInsUsuID_Visible), 5, 0), true);
         edtTppUpdData_Visible = 0;
         AssignProp(sPrefix, false, edtTppUpdData_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTppUpdData_Visible), 5, 0), true);
         edtTppUpdHora_Visible = 0;
         AssignProp(sPrefix, false, edtTppUpdHora_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTppUpdHora_Visible), 5, 0), true);
         edtTppUpdDataHora_Visible = 0;
         AssignProp(sPrefix, false, edtTppUpdDataHora_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTppUpdDataHora_Visible), 5, 0), true);
         edtTppUpdUsuID_Visible = 0;
         AssignProp(sPrefix, false, edtTppUpdUsuID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTppUpdUsuID_Visible), 5, 0), true);
         edtTppAtivo_Visible = 0;
         AssignProp(sPrefix, false, edtTppAtivo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTppAtivo_Visible), 5, 0), true);
         GXt_boolean1 = AV12IsAuthorized_Update;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "tabeladepreco_Update", out  GXt_boolean1) ;
         AV12IsAuthorized_Update = GXt_boolean1;
         AssignAttri(sPrefix, false, "AV12IsAuthorized_Update", AV12IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( sPrefix, AV12IsAuthorized_Update, context));
         if ( ! ( AV12IsAuthorized_Update ) )
         {
            bttBtnupdate_Visible = 0;
            AssignProp(sPrefix, false, bttBtnupdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnupdate_Visible), 5, 0), true);
         }
         GXt_boolean1 = AV13IsAuthorized_Delete;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "tabeladepreco_Delete", out  GXt_boolean1) ;
         AV13IsAuthorized_Delete = GXt_boolean1;
         AssignAttri(sPrefix, false, "AV13IsAuthorized_Delete", AV13IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( sPrefix, AV13IsAuthorized_Delete, context));
         if ( ! ( AV13IsAuthorized_Delete ) )
         {
            bttBtndelete_Visible = 0;
            AssignProp(sPrefix, false, bttBtndelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtndelete_Visible), 5, 0), true);
         }
      }

      protected void E133K2( )
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
            GXEncryptionTmp = "core.tabeladepreco.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(A235TppID.ToString());
            CallWebObject(formatLink("core.tabeladepreco.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
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

      protected void E143K2( )
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
            GXEncryptionTmp = "core.tabeladepreco.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(A235TppID.ToString());
            CallWebObject(formatLink("core.tabeladepreco.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
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
         AV8TrnContext.gxTpr_Callerobject = AV14Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = false;
         AV8TrnContext.gxTpr_Callerurl = AV11HTTPRequest.ScriptName+"?"+AV11HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "core.TabelaDePreco";
         AV10Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A235TppID = (Guid)getParm(obj,0);
         AssignAttri(sPrefix, false, "A235TppID", A235TppID.ToString());
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
         PA3K2( ) ;
         WS3K2( ) ;
         WE3K2( ) ;
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
         sCtrlA235TppID = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA3K2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "core\\tabeladeprecogeneral", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA3K2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            A235TppID = (Guid)getParm(obj,2);
            AssignAttri(sPrefix, false, "A235TppID", A235TppID.ToString());
         }
         wcpOA235TppID = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOA235TppID"));
         if ( ! GetJustCreated( ) && ( ( A235TppID != wcpOA235TppID ) ) )
         {
            setjustcreated();
         }
         wcpOA235TppID = A235TppID;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlA235TppID = cgiGet( sPrefix+"A235TppID_CTRL");
         if ( StringUtil.Len( sCtrlA235TppID) > 0 )
         {
            A235TppID = StringUtil.StrToGuid( cgiGet( sCtrlA235TppID));
            AssignAttri(sPrefix, false, "A235TppID", A235TppID.ToString());
         }
         else
         {
            A235TppID = StringUtil.StrToGuid( cgiGet( sPrefix+"A235TppID_PARM"));
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
         PA3K2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS3K2( ) ;
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
         WS3K2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"A235TppID_PARM", A235TppID.ToString());
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA235TppID)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A235TppID_CTRL", StringUtil.RTrim( sCtrlA235TppID));
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
         WE3K2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2023828133352", true, true);
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
         context.AddJavascriptSource("core/tabeladeprecogeneral.js", "?2023828133353", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtTppCodigo_Internalname = sPrefix+"TPPCODIGO";
         edtTppNome_Internalname = sPrefix+"TPPNOME";
         divTransactiondetail_tableattributes_Internalname = sPrefix+"TRANSACTIONDETAIL_TABLEATTRIBUTES";
         bttBtnupdate_Internalname = sPrefix+"BTNUPDATE";
         bttBtndelete_Internalname = sPrefix+"BTNDELETE";
         divTable_Internalname = sPrefix+"TABLE";
         edtTppID_Internalname = sPrefix+"TPPID";
         edtTppInsData_Internalname = sPrefix+"TPPINSDATA";
         edtTppInsHora_Internalname = sPrefix+"TPPINSHORA";
         edtTppInsDataHora_Internalname = sPrefix+"TPPINSDATAHORA";
         edtTppInsUsuID_Internalname = sPrefix+"TPPINSUSUID";
         edtTppUpdData_Internalname = sPrefix+"TPPUPDDATA";
         edtTppUpdHora_Internalname = sPrefix+"TPPUPDHORA";
         edtTppUpdDataHora_Internalname = sPrefix+"TPPUPDDATAHORA";
         edtTppUpdUsuID_Internalname = sPrefix+"TPPUPDUSUID";
         edtTppAtivo_Internalname = sPrefix+"TPPATIVO";
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
         edtTppAtivo_Jsonclick = "";
         edtTppAtivo_Visible = 1;
         edtTppUpdUsuID_Jsonclick = "";
         edtTppUpdUsuID_Visible = 1;
         edtTppUpdDataHora_Jsonclick = "";
         edtTppUpdDataHora_Visible = 1;
         edtTppUpdHora_Jsonclick = "";
         edtTppUpdHora_Visible = 1;
         edtTppUpdData_Jsonclick = "";
         edtTppUpdData_Visible = 1;
         edtTppInsUsuID_Jsonclick = "";
         edtTppInsUsuID_Visible = 1;
         edtTppInsDataHora_Jsonclick = "";
         edtTppInsDataHora_Visible = 1;
         edtTppInsHora_Jsonclick = "";
         edtTppInsHora_Visible = 1;
         edtTppInsData_Jsonclick = "";
         edtTppInsData_Visible = 1;
         edtTppID_Jsonclick = "";
         edtTppID_Visible = 1;
         bttBtndelete_Visible = 1;
         bttBtnupdate_Visible = 1;
         edtTppNome_Jsonclick = "";
         edtTppNome_Enabled = 0;
         edtTppCodigo_Jsonclick = "";
         edtTppCodigo_Enabled = 0;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A235TppID',fld:'TPPID',pic:''},{av:'AV12IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV13IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'DOUPDATE'","{handler:'E133K2',iparms:[{av:'AV12IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'A235TppID',fld:'TPPID',pic:''}]");
         setEventMetadata("'DOUPDATE'",",oparms:[{ctrl:'BTNUPDATE',prop:'Visible'}]}");
         setEventMetadata("'DODELETE'","{handler:'E143K2',iparms:[{av:'AV13IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'A235TppID',fld:'TPPID',pic:''}]");
         setEventMetadata("'DODELETE'",",oparms:[{ctrl:'BTNDELETE',prop:'Visible'}]}");
         setEventMetadata("VALID_TPPID","{handler:'Valid_Tppid',iparms:[]");
         setEventMetadata("VALID_TPPID",",oparms:[]}");
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
         wcpOA235TppID = Guid.Empty;
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
         A236TppCodigo = "";
         A237TppNome = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtnupdate_Jsonclick = "";
         bttBtndelete_Jsonclick = "";
         A238TppInsData = DateTime.MinValue;
         A239TppInsHora = (DateTime)(DateTime.MinValue);
         A240TppInsDataHora = (DateTime)(DateTime.MinValue);
         A241TppInsUsuID = "";
         A242TppUpdData = DateTime.MinValue;
         A243TppUpdHora = (DateTime)(DateTime.MinValue);
         A244TppUpdDataHora = (DateTime)(DateTime.MinValue);
         A245TppUpdUsuID = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         scmdbuf = "";
         H003K2_A235TppID = new Guid[] {Guid.Empty} ;
         H003K2_A246TppAtivo = new bool[] {false} ;
         H003K2_n246TppAtivo = new bool[] {false} ;
         H003K2_A245TppUpdUsuID = new string[] {""} ;
         H003K2_n245TppUpdUsuID = new bool[] {false} ;
         H003K2_A244TppUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         H003K2_n244TppUpdDataHora = new bool[] {false} ;
         H003K2_A243TppUpdHora = new DateTime[] {DateTime.MinValue} ;
         H003K2_n243TppUpdHora = new bool[] {false} ;
         H003K2_A242TppUpdData = new DateTime[] {DateTime.MinValue} ;
         H003K2_n242TppUpdData = new bool[] {false} ;
         H003K2_A241TppInsUsuID = new string[] {""} ;
         H003K2_n241TppInsUsuID = new bool[] {false} ;
         H003K2_A240TppInsDataHora = new DateTime[] {DateTime.MinValue} ;
         H003K2_A239TppInsHora = new DateTime[] {DateTime.MinValue} ;
         H003K2_A238TppInsData = new DateTime[] {DateTime.MinValue} ;
         H003K2_A237TppNome = new string[] {""} ;
         H003K2_A236TppCodigo = new string[] {""} ;
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV8TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV11HTTPRequest = new GxHttpRequest( context);
         AV10Session = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlA235TppID = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.tabeladeprecogeneral__default(),
            new Object[][] {
                new Object[] {
               H003K2_A235TppID, H003K2_A246TppAtivo, H003K2_n246TppAtivo, H003K2_A245TppUpdUsuID, H003K2_n245TppUpdUsuID, H003K2_A244TppUpdDataHora, H003K2_n244TppUpdDataHora, H003K2_A243TppUpdHora, H003K2_n243TppUpdHora, H003K2_A242TppUpdData,
               H003K2_n242TppUpdData, H003K2_A241TppInsUsuID, H003K2_n241TppInsUsuID, H003K2_A240TppInsDataHora, H003K2_A239TppInsHora, H003K2_A238TppInsData, H003K2_A237TppNome, H003K2_A236TppCodigo
               }
            }
         );
         AV14Pgmname = "core.TabelaDePrecoGeneral";
         /* GeneXus formulas. */
         AV14Pgmname = "core.TabelaDePrecoGeneral";
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
      private int edtTppCodigo_Enabled ;
      private int edtTppNome_Enabled ;
      private int bttBtnupdate_Visible ;
      private int bttBtndelete_Visible ;
      private int edtTppID_Visible ;
      private int edtTppInsData_Visible ;
      private int edtTppInsHora_Visible ;
      private int edtTppInsDataHora_Visible ;
      private int edtTppInsUsuID_Visible ;
      private int edtTppUpdData_Visible ;
      private int edtTppUpdHora_Visible ;
      private int edtTppUpdDataHora_Visible ;
      private int edtTppUpdUsuID_Visible ;
      private int edtTppAtivo_Visible ;
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
      private string edtTppCodigo_Internalname ;
      private string edtTppCodigo_Jsonclick ;
      private string edtTppNome_Internalname ;
      private string edtTppNome_Jsonclick ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtnupdate_Internalname ;
      private string bttBtnupdate_Jsonclick ;
      private string bttBtndelete_Internalname ;
      private string bttBtndelete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtTppID_Internalname ;
      private string edtTppID_Jsonclick ;
      private string edtTppInsData_Internalname ;
      private string edtTppInsData_Jsonclick ;
      private string edtTppInsHora_Internalname ;
      private string edtTppInsHora_Jsonclick ;
      private string edtTppInsDataHora_Internalname ;
      private string edtTppInsDataHora_Jsonclick ;
      private string edtTppInsUsuID_Internalname ;
      private string A241TppInsUsuID ;
      private string edtTppInsUsuID_Jsonclick ;
      private string edtTppUpdData_Internalname ;
      private string edtTppUpdData_Jsonclick ;
      private string edtTppUpdHora_Internalname ;
      private string edtTppUpdHora_Jsonclick ;
      private string edtTppUpdDataHora_Internalname ;
      private string edtTppUpdDataHora_Jsonclick ;
      private string edtTppUpdUsuID_Internalname ;
      private string A245TppUpdUsuID ;
      private string edtTppUpdUsuID_Jsonclick ;
      private string edtTppAtivo_Internalname ;
      private string edtTppAtivo_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string scmdbuf ;
      private string sCtrlA235TppID ;
      private DateTime A239TppInsHora ;
      private DateTime A240TppInsDataHora ;
      private DateTime A243TppUpdHora ;
      private DateTime A244TppUpdDataHora ;
      private DateTime A238TppInsData ;
      private DateTime A242TppUpdData ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV12IsAuthorized_Update ;
      private bool AV13IsAuthorized_Delete ;
      private bool wbLoad ;
      private bool A246TppAtivo ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool n246TppAtivo ;
      private bool n245TppUpdUsuID ;
      private bool n244TppUpdDataHora ;
      private bool n243TppUpdHora ;
      private bool n242TppUpdData ;
      private bool n241TppInsUsuID ;
      private bool returnInSub ;
      private bool GXt_boolean1 ;
      private string A236TppCodigo ;
      private string A237TppNome ;
      private Guid A235TppID ;
      private Guid wcpOA235TppID ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] H003K2_A235TppID ;
      private bool[] H003K2_A246TppAtivo ;
      private bool[] H003K2_n246TppAtivo ;
      private string[] H003K2_A245TppUpdUsuID ;
      private bool[] H003K2_n245TppUpdUsuID ;
      private DateTime[] H003K2_A244TppUpdDataHora ;
      private bool[] H003K2_n244TppUpdDataHora ;
      private DateTime[] H003K2_A243TppUpdHora ;
      private bool[] H003K2_n243TppUpdHora ;
      private DateTime[] H003K2_A242TppUpdData ;
      private bool[] H003K2_n242TppUpdData ;
      private string[] H003K2_A241TppInsUsuID ;
      private bool[] H003K2_n241TppInsUsuID ;
      private DateTime[] H003K2_A240TppInsDataHora ;
      private DateTime[] H003K2_A239TppInsHora ;
      private DateTime[] H003K2_A238TppInsData ;
      private string[] H003K2_A237TppNome ;
      private string[] H003K2_A236TppCodigo ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV11HTTPRequest ;
      private IGxSession AV10Session ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV8TrnContext ;
   }

   public class tabeladeprecogeneral__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH003K2;
          prmH003K2 = new Object[] {
          new ParDef("TppID",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("H003K2", "SELECT TppID, TppAtivo, TppUpdUsuID, TppUpdDataHora, TppUpdHora, TppUpdData, TppInsUsuID, TppInsDataHora, TppInsHora, TppInsData, TppNome, TppCodigo FROM tb_tabeladepreco WHERE TppID = :TppID ORDER BY TppID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003K2,1, GxCacheFrequency.OFF ,true,true )
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
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 40);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(4, true);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getString(7, 40);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(8);
                ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(9);
                ((DateTime[]) buf[15])[0] = rslt.getGXDate(10);
                ((string[]) buf[16])[0] = rslt.getVarchar(11);
                ((string[]) buf[17])[0] = rslt.getVarchar(12);
                return;
       }
    }

 }

}
