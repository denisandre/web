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
   public class mesorregiaogeneral : GXWebComponent
   {
      public mesorregiaogeneral( )
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

      public mesorregiaogeneral( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_MesorregiaoID )
      {
         this.A13MesorregiaoID = aP0_MesorregiaoID;
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
               gxfirstwebparm = GetFirstPar( "MesorregiaoID");
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
                  A13MesorregiaoID = (int)(Math.Round(NumberUtil.Val( GetPar( "MesorregiaoID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "A13MesorregiaoID", StringUtil.LTrimStr( (decimal)(A13MesorregiaoID), 9, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(int)A13MesorregiaoID});
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
                  gxfirstwebparm = GetFirstPar( "MesorregiaoID");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "MesorregiaoID");
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
            PA4F2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV13Pgmname = "core.mesorregiaoGeneral";
               WS4F2( ) ;
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
            context.SendWebValue( "mesorregiao General") ;
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
               GXEncryptionTmp = "core.mesorregiaogeneral.aspx"+UrlEncode(StringUtil.LTrimStr(A13MesorregiaoID,9,0));
               context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("core.mesorregiaogeneral.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA13MesorregiaoID", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOA13MesorregiaoID), 9, 0, ",", "")));
      }

      protected void RenderHtmlCloseForm4F2( )
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
         return "core.mesorregiaoGeneral" ;
      }

      public override string GetPgmdesc( )
      {
         return "mesorregiao General" ;
      }

      protected void WB4F0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "core.mesorregiaogeneral.aspx");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMesorregiaoID_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtMesorregiaoID_Internalname, "ID", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtMesorregiaoID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A13MesorregiaoID), 11, 0, ",", "")), StringUtil.LTrim( ((edtMesorregiaoID_Enabled!=0) ? context.localUtil.Format( (decimal)(A13MesorregiaoID), "ZZZ,ZZZ,ZZ9") : context.localUtil.Format( (decimal)(A13MesorregiaoID), "ZZZ,ZZZ,ZZ9"))), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMesorregiaoID_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtMesorregiaoID_Enabled, 0, "text", "", 11, "chr", 1, "row", 11, 0, 0, 0, 0, -1, 0, true, "core\\ID", "end", false, "", "HLP_core\\mesorregiaoGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMesorregiaoNome_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtMesorregiaoNome_Internalname, "Nome", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtMesorregiaoNome_Internalname, A14MesorregiaoNome, StringUtil.RTrim( context.localUtil.Format( A14MesorregiaoNome, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMesorregiaoNome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtMesorregiaoNome_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\mesorregiaoGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMesorregiaoUFSigla_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtMesorregiaoUFSigla_Internalname, "Unidade Federativa (Estado)", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtMesorregiaoUFSigla_Internalname, A16MesorregiaoUFSigla, StringUtil.RTrim( context.localUtil.Format( A16MesorregiaoUFSigla, "@!")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", edtMesorregiaoUFSigla_Link, "", "", "", edtMesorregiaoUFSigla_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtMesorregiaoUFSigla_Enabled, 0, "text", "", 2, "chr", 1, "row", 2, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\mesorregiaoGeneral.htm");
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
            GxWebStd.gx_single_line_edit( context, edtMesorregiaoUFNome_Internalname, A17MesorregiaoUFNome, StringUtil.RTrim( context.localUtil.Format( A17MesorregiaoUFNome, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMesorregiaoUFNome_Jsonclick, 0, "Attribute", "", "", "", "", edtMesorregiaoUFNome_Visible, 0, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\mesorregiaoGeneral.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtMesorregiaoUFSiglaNome_Internalname, A18MesorregiaoUFSiglaNome, StringUtil.RTrim( context.localUtil.Format( A18MesorregiaoUFSiglaNome, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMesorregiaoUFSiglaNome_Jsonclick, 0, "Attribute", "", "", "", "", edtMesorregiaoUFSiglaNome_Visible, 0, 0, "text", "", 70, "chr", 1, "row", 70, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\mesorregiaoGeneral.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtMesorregiaoUFRegID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A19MesorregiaoUFRegID), 11, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A19MesorregiaoUFRegID), "ZZZ,ZZZ,ZZ9")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMesorregiaoUFRegID_Jsonclick, 0, "Attribute", "", "", "", "", edtMesorregiaoUFRegID_Visible, 0, 0, "text", "", 11, "chr", 1, "row", 11, 0, 0, 0, 0, -1, 0, true, "core\\ID", "end", false, "", "HLP_core\\mesorregiaoGeneral.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtMesorregiaoUFRegSigla_Internalname, A20MesorregiaoUFRegSigla, StringUtil.RTrim( context.localUtil.Format( A20MesorregiaoUFRegSigla, "@!")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMesorregiaoUFRegSigla_Jsonclick, 0, "Attribute", "", "", "", "", edtMesorregiaoUFRegSigla_Visible, 0, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\mesorregiaoGeneral.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtMesorregiaoUFRegNome_Internalname, A21MesorregiaoUFRegNome, StringUtil.RTrim( context.localUtil.Format( A21MesorregiaoUFRegNome, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMesorregiaoUFRegNome_Jsonclick, 0, "Attribute", "", "", "", "", edtMesorregiaoUFRegNome_Visible, 0, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\mesorregiaoGeneral.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtMesorregiaoUFRegSiglaNome_Internalname, A22MesorregiaoUFRegSiglaNome, StringUtil.RTrim( context.localUtil.Format( A22MesorregiaoUFRegSiglaNome, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMesorregiaoUFRegSiglaNome_Jsonclick, 0, "Attribute", "", "", "", "", edtMesorregiaoUFRegSiglaNome_Visible, 0, 0, "text", "", 70, "chr", 1, "row", 70, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\mesorregiaoGeneral.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START4F2( )
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
               Form.Meta.addItem("description", "mesorregiao General", 0) ;
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
               STRUP4F0( ) ;
            }
         }
      }

      protected void WS4F2( )
      {
         START4F2( ) ;
         EVT4F2( ) ;
      }

      protected void EVT4F2( )
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
                                 STRUP4F0( ) ;
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
                                 STRUP4F0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E114F2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4F0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E124F2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4F0( ) ;
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
                                 STRUP4F0( ) ;
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

      protected void WE4F2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm4F2( ) ;
            }
         }
      }

      protected void PA4F2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "core.mesorregiaogeneral.aspx")), "core.mesorregiaogeneral.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "core.mesorregiaogeneral.aspx")))) ;
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
                     gxfirstwebparm = GetFirstPar( "MesorregiaoID");
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
         RF4F2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV13Pgmname = "core.mesorregiaoGeneral";
      }

      protected void RF4F2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H004F2 */
            pr_default.execute(0, new Object[] {A13MesorregiaoID});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A15MesorregiaoUFID = H004F2_A15MesorregiaoUFID[0];
               A22MesorregiaoUFRegSiglaNome = H004F2_A22MesorregiaoUFRegSiglaNome[0];
               n22MesorregiaoUFRegSiglaNome = H004F2_n22MesorregiaoUFRegSiglaNome[0];
               AssignAttri(sPrefix, false, "A22MesorregiaoUFRegSiglaNome", A22MesorregiaoUFRegSiglaNome);
               A21MesorregiaoUFRegNome = H004F2_A21MesorregiaoUFRegNome[0];
               n21MesorregiaoUFRegNome = H004F2_n21MesorregiaoUFRegNome[0];
               AssignAttri(sPrefix, false, "A21MesorregiaoUFRegNome", A21MesorregiaoUFRegNome);
               A20MesorregiaoUFRegSigla = H004F2_A20MesorregiaoUFRegSigla[0];
               n20MesorregiaoUFRegSigla = H004F2_n20MesorregiaoUFRegSigla[0];
               AssignAttri(sPrefix, false, "A20MesorregiaoUFRegSigla", A20MesorregiaoUFRegSigla);
               A19MesorregiaoUFRegID = H004F2_A19MesorregiaoUFRegID[0];
               AssignAttri(sPrefix, false, "A19MesorregiaoUFRegID", StringUtil.LTrimStr( (decimal)(A19MesorregiaoUFRegID), 9, 0));
               A18MesorregiaoUFSiglaNome = H004F2_A18MesorregiaoUFSiglaNome[0];
               n18MesorregiaoUFSiglaNome = H004F2_n18MesorregiaoUFSiglaNome[0];
               AssignAttri(sPrefix, false, "A18MesorregiaoUFSiglaNome", A18MesorregiaoUFSiglaNome);
               A17MesorregiaoUFNome = H004F2_A17MesorregiaoUFNome[0];
               AssignAttri(sPrefix, false, "A17MesorregiaoUFNome", A17MesorregiaoUFNome);
               A16MesorregiaoUFSigla = H004F2_A16MesorregiaoUFSigla[0];
               AssignAttri(sPrefix, false, "A16MesorregiaoUFSigla", A16MesorregiaoUFSigla);
               A14MesorregiaoNome = H004F2_A14MesorregiaoNome[0];
               AssignAttri(sPrefix, false, "A14MesorregiaoNome", A14MesorregiaoNome);
               /* Execute user event: Load */
               E124F2 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            WB4F0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes4F2( )
      {
      }

      protected void before_start_formulas( )
      {
         AV13Pgmname = "core.mesorregiaoGeneral";
         fix_multi_value_controls( ) ;
      }

      protected void STRUP4F0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E114F2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOA13MesorregiaoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA13MesorregiaoID"), ",", "."), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            A14MesorregiaoNome = cgiGet( edtMesorregiaoNome_Internalname);
            AssignAttri(sPrefix, false, "A14MesorregiaoNome", A14MesorregiaoNome);
            A16MesorregiaoUFSigla = StringUtil.Upper( cgiGet( edtMesorregiaoUFSigla_Internalname));
            AssignAttri(sPrefix, false, "A16MesorregiaoUFSigla", A16MesorregiaoUFSigla);
            A17MesorregiaoUFNome = cgiGet( edtMesorregiaoUFNome_Internalname);
            AssignAttri(sPrefix, false, "A17MesorregiaoUFNome", A17MesorregiaoUFNome);
            A18MesorregiaoUFSiglaNome = cgiGet( edtMesorregiaoUFSiglaNome_Internalname);
            n18MesorregiaoUFSiglaNome = false;
            AssignAttri(sPrefix, false, "A18MesorregiaoUFSiglaNome", A18MesorregiaoUFSiglaNome);
            A19MesorregiaoUFRegID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtMesorregiaoUFRegID_Internalname), ",", "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A19MesorregiaoUFRegID", StringUtil.LTrimStr( (decimal)(A19MesorregiaoUFRegID), 9, 0));
            A20MesorregiaoUFRegSigla = StringUtil.Upper( cgiGet( edtMesorregiaoUFRegSigla_Internalname));
            n20MesorregiaoUFRegSigla = false;
            AssignAttri(sPrefix, false, "A20MesorregiaoUFRegSigla", A20MesorregiaoUFRegSigla);
            A21MesorregiaoUFRegNome = cgiGet( edtMesorregiaoUFRegNome_Internalname);
            n21MesorregiaoUFRegNome = false;
            AssignAttri(sPrefix, false, "A21MesorregiaoUFRegNome", A21MesorregiaoUFRegNome);
            A22MesorregiaoUFRegSiglaNome = cgiGet( edtMesorregiaoUFRegSiglaNome_Internalname);
            n22MesorregiaoUFRegSiglaNome = false;
            AssignAttri(sPrefix, false, "A22MesorregiaoUFRegSiglaNome", A22MesorregiaoUFRegSiglaNome);
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
         E114F2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E114F2( )
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

      protected void E124F2( )
      {
         /* Load Routine */
         returnInSub = false;
         GXt_boolean1 = AV12TempBoolean;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "ufview_Execute", out  GXt_boolean1) ;
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
            GXEncryptionTmp = "core.ufview.aspx"+UrlEncode(StringUtil.LTrimStr(A15MesorregiaoUFID,9,0)) + "," + UrlEncode(StringUtil.RTrim(""));
            edtMesorregiaoUFSigla_Link = formatLink("core.ufview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            AssignProp(sPrefix, false, edtMesorregiaoUFSigla_Internalname, "Link", edtMesorregiaoUFSigla_Link, true);
         }
         edtMesorregiaoUFNome_Visible = 0;
         AssignProp(sPrefix, false, edtMesorregiaoUFNome_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMesorregiaoUFNome_Visible), 5, 0), true);
         edtMesorregiaoUFSiglaNome_Visible = 0;
         AssignProp(sPrefix, false, edtMesorregiaoUFSiglaNome_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMesorregiaoUFSiglaNome_Visible), 5, 0), true);
         edtMesorregiaoUFRegID_Visible = 0;
         AssignProp(sPrefix, false, edtMesorregiaoUFRegID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMesorregiaoUFRegID_Visible), 5, 0), true);
         edtMesorregiaoUFRegSigla_Visible = 0;
         AssignProp(sPrefix, false, edtMesorregiaoUFRegSigla_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMesorregiaoUFRegSigla_Visible), 5, 0), true);
         edtMesorregiaoUFRegNome_Visible = 0;
         AssignProp(sPrefix, false, edtMesorregiaoUFRegNome_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMesorregiaoUFRegNome_Visible), 5, 0), true);
         edtMesorregiaoUFRegSiglaNome_Visible = 0;
         AssignProp(sPrefix, false, edtMesorregiaoUFRegSiglaNome_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMesorregiaoUFRegSiglaNome_Visible), 5, 0), true);
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV8TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV8TrnContext.gxTpr_Callerobject = AV13Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = false;
         AV8TrnContext.gxTpr_Callerurl = AV11HTTPRequest.ScriptName+"?"+AV11HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "core.mesorregiao";
         AV10Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A13MesorregiaoID = Convert.ToInt32(getParm(obj,0));
         AssignAttri(sPrefix, false, "A13MesorregiaoID", StringUtil.LTrimStr( (decimal)(A13MesorregiaoID), 9, 0));
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
         PA4F2( ) ;
         WS4F2( ) ;
         WE4F2( ) ;
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
         sCtrlA13MesorregiaoID = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA4F2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "core\\mesorregiaogeneral", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA4F2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            A13MesorregiaoID = Convert.ToInt32(getParm(obj,2));
            AssignAttri(sPrefix, false, "A13MesorregiaoID", StringUtil.LTrimStr( (decimal)(A13MesorregiaoID), 9, 0));
         }
         wcpOA13MesorregiaoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA13MesorregiaoID"), ",", "."), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( A13MesorregiaoID != wcpOA13MesorregiaoID ) ) )
         {
            setjustcreated();
         }
         wcpOA13MesorregiaoID = A13MesorregiaoID;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlA13MesorregiaoID = cgiGet( sPrefix+"A13MesorregiaoID_CTRL");
         if ( StringUtil.Len( sCtrlA13MesorregiaoID) > 0 )
         {
            A13MesorregiaoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlA13MesorregiaoID), ",", "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A13MesorregiaoID", StringUtil.LTrimStr( (decimal)(A13MesorregiaoID), 9, 0));
         }
         else
         {
            A13MesorregiaoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"A13MesorregiaoID_PARM"), ",", "."), 18, MidpointRounding.ToEven));
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
         PA4F2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS4F2( ) ;
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
         WS4F2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"A13MesorregiaoID_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(A13MesorregiaoID), 9, 0, ",", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA13MesorregiaoID)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A13MesorregiaoID_CTRL", StringUtil.RTrim( sCtrlA13MesorregiaoID));
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
         WE4F2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202382894035", true, true);
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
            context.AddJavascriptSource("core/mesorregiaogeneral.js", "?202382894036", false, true);
         }
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtMesorregiaoID_Internalname = sPrefix+"MESORREGIAOID";
         edtMesorregiaoNome_Internalname = sPrefix+"MESORREGIAONOME";
         edtMesorregiaoUFSigla_Internalname = sPrefix+"MESORREGIAOUFSIGLA";
         divTransactiondetail_tableattributes_Internalname = sPrefix+"TRANSACTIONDETAIL_TABLEATTRIBUTES";
         divTable_Internalname = sPrefix+"TABLE";
         edtMesorregiaoUFNome_Internalname = sPrefix+"MESORREGIAOUFNOME";
         edtMesorregiaoUFSiglaNome_Internalname = sPrefix+"MESORREGIAOUFSIGLANOME";
         edtMesorregiaoUFRegID_Internalname = sPrefix+"MESORREGIAOUFREGID";
         edtMesorregiaoUFRegSigla_Internalname = sPrefix+"MESORREGIAOUFREGSIGLA";
         edtMesorregiaoUFRegNome_Internalname = sPrefix+"MESORREGIAOUFREGNOME";
         edtMesorregiaoUFRegSiglaNome_Internalname = sPrefix+"MESORREGIAOUFREGSIGLANOME";
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
         edtMesorregiaoUFRegSiglaNome_Jsonclick = "";
         edtMesorregiaoUFRegSiglaNome_Visible = 1;
         edtMesorregiaoUFRegNome_Jsonclick = "";
         edtMesorregiaoUFRegNome_Visible = 1;
         edtMesorregiaoUFRegSigla_Jsonclick = "";
         edtMesorregiaoUFRegSigla_Visible = 1;
         edtMesorregiaoUFRegID_Jsonclick = "";
         edtMesorregiaoUFRegID_Visible = 1;
         edtMesorregiaoUFSiglaNome_Jsonclick = "";
         edtMesorregiaoUFSiglaNome_Visible = 1;
         edtMesorregiaoUFNome_Jsonclick = "";
         edtMesorregiaoUFNome_Visible = 1;
         edtMesorregiaoUFSigla_Jsonclick = "";
         edtMesorregiaoUFSigla_Link = "";
         edtMesorregiaoUFSigla_Enabled = 0;
         edtMesorregiaoNome_Jsonclick = "";
         edtMesorregiaoNome_Enabled = 0;
         edtMesorregiaoID_Jsonclick = "";
         edtMesorregiaoID_Enabled = 0;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A13MesorregiaoID',fld:'MESORREGIAOID',pic:'ZZZ,ZZZ,ZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("VALID_MESORREGIAOID","{handler:'Valid_Mesorregiaoid',iparms:[]");
         setEventMetadata("VALID_MESORREGIAOID",",oparms:[]}");
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
         A14MesorregiaoNome = "";
         A16MesorregiaoUFSigla = "";
         A17MesorregiaoUFNome = "";
         A18MesorregiaoUFSiglaNome = "";
         A20MesorregiaoUFRegSigla = "";
         A21MesorregiaoUFRegNome = "";
         A22MesorregiaoUFRegSiglaNome = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         scmdbuf = "";
         H004F2_A13MesorregiaoID = new int[1] ;
         H004F2_A15MesorregiaoUFID = new int[1] ;
         H004F2_A22MesorregiaoUFRegSiglaNome = new string[] {""} ;
         H004F2_n22MesorregiaoUFRegSiglaNome = new bool[] {false} ;
         H004F2_A21MesorregiaoUFRegNome = new string[] {""} ;
         H004F2_n21MesorregiaoUFRegNome = new bool[] {false} ;
         H004F2_A20MesorregiaoUFRegSigla = new string[] {""} ;
         H004F2_n20MesorregiaoUFRegSigla = new bool[] {false} ;
         H004F2_A19MesorregiaoUFRegID = new int[1] ;
         H004F2_A18MesorregiaoUFSiglaNome = new string[] {""} ;
         H004F2_n18MesorregiaoUFSiglaNome = new bool[] {false} ;
         H004F2_A17MesorregiaoUFNome = new string[] {""} ;
         H004F2_A16MesorregiaoUFSigla = new string[] {""} ;
         H004F2_A14MesorregiaoNome = new string[] {""} ;
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV8TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV11HTTPRequest = new GxHttpRequest( context);
         AV10Session = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlA13MesorregiaoID = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.mesorregiaogeneral__default(),
            new Object[][] {
                new Object[] {
               H004F2_A13MesorregiaoID, H004F2_A15MesorregiaoUFID, H004F2_A22MesorregiaoUFRegSiglaNome, H004F2_n22MesorregiaoUFRegSiglaNome, H004F2_A21MesorregiaoUFRegNome, H004F2_n21MesorregiaoUFRegNome, H004F2_A20MesorregiaoUFRegSigla, H004F2_n20MesorregiaoUFRegSigla, H004F2_A19MesorregiaoUFRegID, H004F2_A18MesorregiaoUFSiglaNome,
               H004F2_n18MesorregiaoUFSiglaNome, H004F2_A17MesorregiaoUFNome, H004F2_A16MesorregiaoUFSigla, H004F2_A14MesorregiaoNome
               }
            }
         );
         AV13Pgmname = "core.mesorregiaoGeneral";
         /* GeneXus formulas. */
         AV13Pgmname = "core.mesorregiaoGeneral";
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
      private int A13MesorregiaoID ;
      private int wcpOA13MesorregiaoID ;
      private int edtMesorregiaoID_Enabled ;
      private int edtMesorregiaoNome_Enabled ;
      private int edtMesorregiaoUFSigla_Enabled ;
      private int edtMesorregiaoUFNome_Visible ;
      private int edtMesorregiaoUFSiglaNome_Visible ;
      private int A19MesorregiaoUFRegID ;
      private int edtMesorregiaoUFRegID_Visible ;
      private int edtMesorregiaoUFRegSigla_Visible ;
      private int edtMesorregiaoUFRegNome_Visible ;
      private int edtMesorregiaoUFRegSiglaNome_Visible ;
      private int A15MesorregiaoUFID ;
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
      private string edtMesorregiaoID_Internalname ;
      private string edtMesorregiaoID_Jsonclick ;
      private string edtMesorregiaoNome_Internalname ;
      private string edtMesorregiaoNome_Jsonclick ;
      private string edtMesorregiaoUFSigla_Internalname ;
      private string edtMesorregiaoUFSigla_Link ;
      private string edtMesorregiaoUFSigla_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtMesorregiaoUFNome_Internalname ;
      private string edtMesorregiaoUFNome_Jsonclick ;
      private string edtMesorregiaoUFSiglaNome_Internalname ;
      private string edtMesorregiaoUFSiglaNome_Jsonclick ;
      private string edtMesorregiaoUFRegID_Internalname ;
      private string edtMesorregiaoUFRegID_Jsonclick ;
      private string edtMesorregiaoUFRegSigla_Internalname ;
      private string edtMesorregiaoUFRegSigla_Jsonclick ;
      private string edtMesorregiaoUFRegNome_Internalname ;
      private string edtMesorregiaoUFRegNome_Jsonclick ;
      private string edtMesorregiaoUFRegSiglaNome_Internalname ;
      private string edtMesorregiaoUFRegSiglaNome_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string scmdbuf ;
      private string sCtrlA13MesorregiaoID ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool n22MesorregiaoUFRegSiglaNome ;
      private bool n21MesorregiaoUFRegNome ;
      private bool n20MesorregiaoUFRegSigla ;
      private bool n18MesorregiaoUFSiglaNome ;
      private bool returnInSub ;
      private bool AV12TempBoolean ;
      private bool GXt_boolean1 ;
      private string A14MesorregiaoNome ;
      private string A16MesorregiaoUFSigla ;
      private string A17MesorregiaoUFNome ;
      private string A18MesorregiaoUFSiglaNome ;
      private string A20MesorregiaoUFRegSigla ;
      private string A21MesorregiaoUFRegNome ;
      private string A22MesorregiaoUFRegSiglaNome ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] H004F2_A13MesorregiaoID ;
      private int[] H004F2_A15MesorregiaoUFID ;
      private string[] H004F2_A22MesorregiaoUFRegSiglaNome ;
      private bool[] H004F2_n22MesorregiaoUFRegSiglaNome ;
      private string[] H004F2_A21MesorregiaoUFRegNome ;
      private bool[] H004F2_n21MesorregiaoUFRegNome ;
      private string[] H004F2_A20MesorregiaoUFRegSigla ;
      private bool[] H004F2_n20MesorregiaoUFRegSigla ;
      private int[] H004F2_A19MesorregiaoUFRegID ;
      private string[] H004F2_A18MesorregiaoUFSiglaNome ;
      private bool[] H004F2_n18MesorregiaoUFSiglaNome ;
      private string[] H004F2_A17MesorregiaoUFNome ;
      private string[] H004F2_A16MesorregiaoUFSigla ;
      private string[] H004F2_A14MesorregiaoNome ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV11HTTPRequest ;
      private IGxSession AV10Session ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV8TrnContext ;
   }

   public class mesorregiaogeneral__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH004F2;
          prmH004F2 = new Object[] {
          new ParDef("MesorregiaoID",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("H004F2", "SELECT MesorregiaoID, MesorregiaoUFID, MesorregiaoUFRegSiglaNome, MesorregiaoUFRegNome, MesorregiaoUFRegSigla, MesorregiaoUFRegID, MesorregiaoUFSiglaNome, MesorregiaoUFNome, MesorregiaoUFSigla, MesorregiaoNome FROM tbibge_mesorregiao WHERE MesorregiaoID = :MesorregiaoID ORDER BY MesorregiaoID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004F2,1, GxCacheFrequency.OFF ,true,true )
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
                ((string[]) buf[9])[0] = rslt.getVarchar(7);
                ((bool[]) buf[10])[0] = rslt.wasNull(7);
                ((string[]) buf[11])[0] = rslt.getVarchar(8);
                ((string[]) buf[12])[0] = rslt.getVarchar(9);
                ((string[]) buf[13])[0] = rslt.getVarchar(10);
                return;
       }
    }

 }

}
