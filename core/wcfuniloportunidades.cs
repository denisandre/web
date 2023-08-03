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
   public class wcfuniloportunidades : GXWebComponent
   {
      public wcfuniloportunidades( )
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

      public wcfuniloportunidades( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_NegUltIteID )
      {
         this.AV8NegUltIteID = aP0_NegUltIteID;
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
         chkavHasnda = new GXCheckbox();
         cmbavDesenvstatus = new GXCombobox();
         chkavHaskitbancocliente = new GXCheckbox();
         chkavHaskitgarantiacliente = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "NegUltIteID");
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
                  AV8NegUltIteID = StringUtil.StrToGuid( GetPar( "NegUltIteID"));
                  AssignAttri(sPrefix, false, "AV8NegUltIteID", AV8NegUltIteID.ToString());
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(Guid)AV8NegUltIteID});
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
                  gxfirstwebparm = GetFirstPar( "NegUltIteID");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "NegUltIteID");
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
         nRC_GXsfl_12 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_12"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_12_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_12_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_12_idx = GetPar( "sGXsfl_12_idx");
         sPrefix = GetPar( "sPrefix");
         edtNegID_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, edtNegID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtNegID_Visible), 5, 0), !bGXsfl_12_Refreshing);
         edtNegUltNgfSeq_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, edtNegUltNgfSeq_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtNegUltNgfSeq_Visible), 5, 0), !bGXsfl_12_Refreshing);
         edtNegUltIteOrdem_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, edtNegUltIteOrdem_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtNegUltIteOrdem_Visible), 5, 0), !bGXsfl_12_Refreshing);
         chkavHasnda.Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, chkavHasnda_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavHasnda.Visible), 5, 0), !bGXsfl_12_Refreshing);
         cmbavDesenvstatus.Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, cmbavDesenvstatus_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDesenvstatus.Visible), 5, 0), !bGXsfl_12_Refreshing);
         chkavHaskitbancocliente.Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, chkavHaskitbancocliente_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavHaskitbancocliente.Visible), 5, 0), !bGXsfl_12_Refreshing);
         chkavHaskitgarantiacliente.Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, chkavHaskitgarantiacliente_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavHaskitgarantiacliente.Visible), 5, 0), !bGXsfl_12_Refreshing);
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
         AV8NegUltIteID = StringUtil.StrToGuid( GetPar( "NegUltIteID"));
         AV33Pgmname = GetPar( "Pgmname");
         edtNegID_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, edtNegID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtNegID_Visible), 5, 0), !bGXsfl_12_Refreshing);
         edtNegUltNgfSeq_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, edtNegUltNgfSeq_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtNegUltNgfSeq_Visible), 5, 0), !bGXsfl_12_Refreshing);
         edtNegUltIteOrdem_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, edtNegUltIteOrdem_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtNegUltIteOrdem_Visible), 5, 0), !bGXsfl_12_Refreshing);
         chkavHasnda.Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, chkavHasnda_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavHasnda.Visible), 5, 0), !bGXsfl_12_Refreshing);
         cmbavDesenvstatus.Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, cmbavDesenvstatus_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDesenvstatus.Visible), 5, 0), !bGXsfl_12_Refreshing);
         chkavHaskitbancocliente.Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, chkavHaskitbancocliente_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavHaskitbancocliente.Visible), 5, 0), !bGXsfl_12_Refreshing);
         chkavHaskitgarantiacliente.Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, chkavHaskitgarantiacliente_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavHaskitgarantiacliente.Visible), 5, 0), !bGXsfl_12_Refreshing);
         AV30Core_wcfuniloportunidadesds_1_negultiteid = StringUtil.StrToGuid( GetPar( "Core_wcfuniloportunidadesds_1_negultiteid"));
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV8NegUltIteID, AV33Pgmname, AV30Core_wcfuniloportunidadesds_1_negultiteid, sPrefix) ;
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
            PA512( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV33Pgmname = "core.wcFunilOportunidades";
               /* Using cursor H00513 */
               pr_default.execute(0);
               if ( (pr_default.getStatus(0) != 101) )
               {
                  A40000GXC1 = H00513_A40000GXC1[0];
                  n40000GXC1 = H00513_n40000GXC1[0];
               }
               else
               {
                  A40000GXC1 = 0;
                  n40000GXC1 = false;
                  AssignAttri(sPrefix, false, "A40000GXC1", StringUtil.LTrimStr( (decimal)(A40000GXC1), 8, 0));
               }
               pr_default.close(0);
               /* Using cursor H00515 */
               pr_default.execute(1);
               if ( (pr_default.getStatus(1) != 101) )
               {
                  A40001GXC2 = H00515_A40001GXC2[0];
                  n40001GXC2 = H00515_n40001GXC2[0];
               }
               else
               {
                  A40001GXC2 = 0;
                  n40001GXC2 = false;
                  AssignAttri(sPrefix, false, "A40001GXC2", StringUtil.LTrimStr( (decimal)(A40001GXC2), 8, 0));
               }
               pr_default.close(1);
               WS512( ) ;
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
            context.SendWebValue( " Oportunidade de Negócio") ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
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
               GXEncryptionTmp = "core.wcfuniloportunidades.aspx"+UrlEncode(AV8NegUltIteID.ToString());
               context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("core.wcfuniloportunidades.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV33Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV33Pgmname, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_12", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_12), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vNEGULTITEID", AV8NegUltIteID.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV8NegUltIteID", wcpOAV8NegUltIteID.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV33Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV33Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vNEGID_SELECTED", AV21NegID_Selected.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"vCORE_WCFUNILOPORTUNIDADESDS_1_NEGULTITEID", AV30Core_wcfuniloportunidadesds_1_negultiteid.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_AVANCAR_Title", StringUtil.RTrim( Dvelop_confirmpanel_avancar_Title));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_AVANCAR_Confirmationtext", StringUtil.RTrim( Dvelop_confirmpanel_avancar_Confirmationtext));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_AVANCAR_Yesbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_avancar_Yesbuttoncaption));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_AVANCAR_Nobuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_avancar_Nobuttoncaption));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_AVANCAR_Cancelbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_avancar_Cancelbuttoncaption));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_AVANCAR_Yesbuttonposition", StringUtil.RTrim( Dvelop_confirmpanel_avancar_Yesbuttonposition));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_AVANCAR_Confirmtype", StringUtil.RTrim( Dvelop_confirmpanel_avancar_Confirmtype));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Class", StringUtil.RTrim( subGrid_Class));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Flexdirection", StringUtil.RTrim( subGrid_Flexdirection));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Flexwrap", StringUtil.RTrim( subGrid_Flexwrap));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Justifycontent", StringUtil.RTrim( subGrid_Justifycontent));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_AVANCAR_Result", StringUtil.RTrim( Dvelop_confirmpanel_avancar_Result));
         GxWebStd.gx_hidden_field( context, sPrefix+"NEGID_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNegID_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"NEGULTNGFSEQ_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNegUltNgfSeq_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"NEGULTITEORDEM_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNegUltIteOrdem_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vHASNDA_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkavHasnda.Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDESENVSTATUS_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbavDesenvstatus.Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vHASKITBANCOCLIENTE_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkavHaskitbancocliente.Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vHASKITGARANTIACLIENTE_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkavHaskitgarantiacliente.Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DVELOP_CONFIRMPANEL_AVANCAR_Result", StringUtil.RTrim( Dvelop_confirmpanel_avancar_Result));
      }

      protected void RenderHtmlCloseForm512( )
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
         return "core.wcFunilOportunidades" ;
      }

      public override string GetPgmdesc( )
      {
         return " Oportunidade de Negócio" ;
      }

      protected void WB510( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "core.wcfuniloportunidades.aspx");
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
            }
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, sPrefix, "false");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetIsFreestyle(true);
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl12( ) ;
         }
         if ( wbEnd == 12 )
         {
            wbEnd = 0;
            nRC_GXsfl_12 = (int)(nGXsfl_12_idx-1);
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
            GxWebStd.gx_single_line_edit( context, edtNegUltIteID_Internalname, A420NegUltIteID.ToString(), A420NegUltIteID.ToString(), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNegUltIteID_Jsonclick, 0, "Attribute", "", "", "", "", edtNegUltIteID_Visible, 0, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_core\\wcFunilOportunidades.htm");
            wb_table1_103_512( true) ;
         }
         else
         {
            wb_table1_103_512( false) ;
         }
         return  ;
      }

      protected void wb_table1_103_512e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 12 )
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

      protected void START512( )
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
               Form.Meta.addItem("description", " Oportunidade de Negócio", 0) ;
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
               STRUP510( ) ;
            }
         }
      }

      protected void WS512( )
      {
         START512( ) ;
         EVT512( ) ;
      }

      protected void EVT512( )
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
                                 STRUP510( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "DVELOP_CONFIRMPANEL_AVANCAR.CLOSE") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP510( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E11512 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP510( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = chkavHasnda_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP510( ) ;
                              }
                              AV30Core_wcfuniloportunidadesds_1_negultiteid = AV8NegUltIteID;
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 11), "'DOVISITAS'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 14), "'DODOCUMENTOS'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 11), "'DOANALISE'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "'DOVOLTAR'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 11), "'DOVISITAS'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 14), "'DODOCUMENTOS'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 11), "'DOANALISE'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "'DOVOLTAR'") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP510( ) ;
                              }
                              nGXsfl_12_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
                              SubsflControlProps_122( ) ;
                              A351NegCliNomeFamiliar = StringUtil.Upper( cgiGet( edtNegCliNomeFamiliar_Internalname));
                              A353NegCpjNomFan = StringUtil.Upper( cgiGet( edtNegCpjNomFan_Internalname));
                              A385NegValorAtualizado = context.localUtil.CToN( cgiGet( edtNegValorAtualizado_Internalname), ",", ".");
                              A362NegAssunto = StringUtil.Upper( cgiGet( edtNegAssunto_Internalname));
                              A345NegID = StringUtil.StrToGuid( cgiGet( edtNegID_Internalname));
                              A474NegUltNgfSeq = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtNegUltNgfSeq_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A479NegUltIteOrdem = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtNegUltIteOrdem_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              AV24HasNDA = StringUtil.StrToBool( cgiGet( chkavHasnda_Internalname));
                              AssignAttri(sPrefix, false, chkavHasnda_Internalname, AV24HasNDA);
                              cmbavDesenvstatus.Name = cmbavDesenvstatus_Internalname;
                              cmbavDesenvstatus.CurrentValue = cgiGet( cmbavDesenvstatus_Internalname);
                              AV25DesenvStatus = cgiGet( cmbavDesenvstatus_Internalname);
                              AssignAttri(sPrefix, false, cmbavDesenvstatus_Internalname, AV25DesenvStatus);
                              AV26HasKitBancoCliente = StringUtil.StrToBool( cgiGet( chkavHaskitbancocliente_Internalname));
                              AssignAttri(sPrefix, false, chkavHaskitbancocliente_Internalname, AV26HasKitBancoCliente);
                              AV27HasKitGarantiaCliente = StringUtil.StrToBool( cgiGet( chkavHaskitgarantiacliente_Internalname));
                              AssignAttri(sPrefix, false, chkavHaskitgarantiacliente_Internalname, AV27HasKitGarantiaCliente);
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
                                          GX_FocusControl = chkavHasnda_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E12512 ();
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
                                          GX_FocusControl = chkavHasnda_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Refresh */
                                          E13512 ();
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
                                          GX_FocusControl = chkavHasnda_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E14512 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'DOVISITAS'") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = chkavHasnda_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: 'DoVisitas' */
                                          E15512 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'DODOCUMENTOS'") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = chkavHasnda_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: 'DoDocumentos' */
                                          E16512 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'DOANALISE'") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = chkavHasnda_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: 'DoAnalise' */
                                          E17512 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'DOVOLTAR'") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = chkavHasnda_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: 'DoVoltar' */
                                          E18512 ();
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
                                       STRUP510( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = chkavHasnda_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
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
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE512( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm512( ) ;
            }
         }
      }

      protected void PA512( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "core.wcfuniloportunidades.aspx")), "core.wcfuniloportunidades.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "core.wcfuniloportunidades.aspx")))) ;
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
                     gxfirstwebparm = GetFirstPar( "NegUltIteID");
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

      protected void gxnrGrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_122( ) ;
         while ( nGXsfl_12_idx <= nRC_GXsfl_12 )
         {
            sendrow_122( ) ;
            nGXsfl_12_idx = ((subGrid_Islastpage==1)&&(nGXsfl_12_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_12_idx+1);
            sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
            SubsflControlProps_122( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       Guid AV8NegUltIteID ,
                                       string AV33Pgmname ,
                                       Guid AV30Core_wcfuniloportunidadesds_1_negultiteid ,
                                       string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF512( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_NEGID", GetSecureSignedToken( sPrefix, A345NegID, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"NEGID", A345NegID.ToString());
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_NEGULTNGFSEQ", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(A474NegUltNgfSeq), "ZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"NEGULTNGFSEQ", StringUtil.LTrim( StringUtil.NToC( (decimal)(A474NegUltNgfSeq), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_NEGULTITEORDEM", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(A479NegUltIteOrdem), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"NEGULTITEORDEM", StringUtil.LTrim( StringUtil.NToC( (decimal)(A479NegUltIteOrdem), 4, 0, ".", "")));
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
         RF512( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV33Pgmname = "core.wcFunilOportunidades";
      }

      protected void RF512( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 12;
         /* Execute user event: Refresh */
         E13512 ();
         nGXsfl_12_idx = 1;
         sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
         SubsflControlProps_122( ) ;
         bGXsfl_12_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", sPrefix);
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
         GridContainer.AddObjectProperty("Class", "FreeStyleGrid");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_122( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            /* Using cursor H00518 */
            pr_default.execute(2, new Object[] {AV30Core_wcfuniloportunidadesds_1_negultiteid, GXPagingFrom2, GXPagingTo2});
            nGXsfl_12_idx = 1;
            sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
            SubsflControlProps_122( ) ;
            while ( ( (pr_default.getStatus(2) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A348NegInsDataHora = H00518_A348NegInsDataHora[0];
               A420NegUltIteID = H00518_A420NegUltIteID[0];
               AssignAttri(sPrefix, false, "A420NegUltIteID", A420NegUltIteID.ToString());
               A479NegUltIteOrdem = H00518_A479NegUltIteOrdem[0];
               A474NegUltNgfSeq = H00518_A474NegUltNgfSeq[0];
               A345NegID = H00518_A345NegID[0];
               A362NegAssunto = H00518_A362NegAssunto[0];
               A385NegValorAtualizado = H00518_A385NegValorAtualizado[0];
               A353NegCpjNomFan = H00518_A353NegCpjNomFan[0];
               A351NegCliNomeFamiliar = H00518_A351NegCliNomeFamiliar[0];
               A40000GXC1 = H00518_A40000GXC1[0];
               n40000GXC1 = H00518_n40000GXC1[0];
               A40001GXC2 = H00518_A40001GXC2[0];
               n40001GXC2 = H00518_n40001GXC2[0];
               A40000GXC1 = H00518_A40000GXC1[0];
               n40000GXC1 = H00518_n40000GXC1[0];
               A40001GXC2 = H00518_A40001GXC2[0];
               n40001GXC2 = H00518_n40001GXC2[0];
               E14512 ();
               pr_default.readNext(2);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(2) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(2);
            wbEnd = 12;
            WB510( ) ;
         }
         bGXsfl_12_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes512( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV33Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV33Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_NEGID"+"_"+sGXsfl_12_idx, GetSecureSignedToken( sPrefix+sGXsfl_12_idx, A345NegID, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_NEGULTNGFSEQ"+"_"+sGXsfl_12_idx, GetSecureSignedToken( sPrefix+sGXsfl_12_idx, context.localUtil.Format( (decimal)(A474NegUltNgfSeq), "ZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_NEGULTITEORDEM"+"_"+sGXsfl_12_idx, GetSecureSignedToken( sPrefix+sGXsfl_12_idx, context.localUtil.Format( (decimal)(A479NegUltIteOrdem), "ZZZ9"), context));
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
         AV30Core_wcfuniloportunidadesds_1_negultiteid = AV8NegUltIteID;
         /* Using cursor H005111 */
         pr_default.execute(3, new Object[] {AV30Core_wcfuniloportunidadesds_1_negultiteid});
         GRID_nRecordCount = H005111_AGRID_nRecordCount[0];
         pr_default.close(3);
         return (int)(GRID_nRecordCount) ;
      }

      protected int subGrid_fnc_Recordsperpage( )
      {
         if ( subGrid_Rows > 0 )
         {
            return subGrid_Rows*1 ;
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
         AV30Core_wcfuniloportunidadesds_1_negultiteid = AV8NegUltIteID;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV8NegUltIteID, AV33Pgmname, AV30Core_wcfuniloportunidadesds_1_negultiteid, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV30Core_wcfuniloportunidadesds_1_negultiteid = AV8NegUltIteID;
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ( GRID_nRecordCount >= subGrid_fnc_Recordsperpage( ) ) && ( GRID_nEOF == 0 ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV8NegUltIteID, AV33Pgmname, AV30Core_wcfuniloportunidadesds_1_negultiteid, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV30Core_wcfuniloportunidadesds_1_negultiteid = AV8NegUltIteID;
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
            gxgrGrid_refresh( subGrid_Rows, AV8NegUltIteID, AV33Pgmname, AV30Core_wcfuniloportunidadesds_1_negultiteid, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV30Core_wcfuniloportunidadesds_1_negultiteid = AV8NegUltIteID;
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
            gxgrGrid_refresh( subGrid_Rows, AV8NegUltIteID, AV33Pgmname, AV30Core_wcfuniloportunidadesds_1_negultiteid, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV30Core_wcfuniloportunidadesds_1_negultiteid = AV8NegUltIteID;
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
            gxgrGrid_refresh( subGrid_Rows, AV8NegUltIteID, AV33Pgmname, AV30Core_wcfuniloportunidadesds_1_negultiteid, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV33Pgmname = "core.wcFunilOportunidades";
         /* Using cursor H005113 */
         pr_default.execute(4);
         if ( (pr_default.getStatus(4) != 101) )
         {
            A40000GXC1 = H005113_A40000GXC1[0];
            n40000GXC1 = H005113_n40000GXC1[0];
         }
         else
         {
            A40000GXC1 = 0;
            n40000GXC1 = false;
            AssignAttri(sPrefix, false, "A40000GXC1", StringUtil.LTrimStr( (decimal)(A40000GXC1), 8, 0));
         }
         pr_default.close(4);
         /* Using cursor H005115 */
         pr_default.execute(5);
         if ( (pr_default.getStatus(5) != 101) )
         {
            A40001GXC2 = H005115_A40001GXC2[0];
            n40001GXC2 = H005115_n40001GXC2[0];
         }
         else
         {
            A40001GXC2 = 0;
            n40001GXC2 = false;
            AssignAttri(sPrefix, false, "A40001GXC2", StringUtil.LTrimStr( (decimal)(A40001GXC2), 8, 0));
         }
         pr_default.close(5);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP510( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E12512 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_12 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_12"), ",", "."), 18, MidpointRounding.ToEven));
            AV8NegUltIteID = StringUtil.StrToGuid( cgiGet( sPrefix+"vNEGULTITEID"));
            wcpOAV8NegUltIteID = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOAV8NegUltIteID"));
            AV21NegID_Selected = StringUtil.StrToGuid( cgiGet( sPrefix+"vNEGID_SELECTED"));
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nFirstRecordOnPage"), ",", "."), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nEOF"), ",", "."), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Dvelop_confirmpanel_avancar_Title = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_AVANCAR_Title");
            Dvelop_confirmpanel_avancar_Confirmationtext = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_AVANCAR_Confirmationtext");
            Dvelop_confirmpanel_avancar_Yesbuttoncaption = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_AVANCAR_Yesbuttoncaption");
            Dvelop_confirmpanel_avancar_Nobuttoncaption = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_AVANCAR_Nobuttoncaption");
            Dvelop_confirmpanel_avancar_Cancelbuttoncaption = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_AVANCAR_Cancelbuttoncaption");
            Dvelop_confirmpanel_avancar_Yesbuttonposition = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_AVANCAR_Yesbuttonposition");
            Dvelop_confirmpanel_avancar_Confirmtype = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_AVANCAR_Confirmtype");
            subGrid_Class = cgiGet( sPrefix+"GRID_Class");
            subGrid_Flexdirection = cgiGet( sPrefix+"GRID_Flexdirection");
            subGrid_Flexwrap = cgiGet( sPrefix+"GRID_Flexwrap");
            subGrid_Justifycontent = cgiGet( sPrefix+"GRID_Justifycontent");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Dvelop_confirmpanel_avancar_Result = cgiGet( sPrefix+"DVELOP_CONFIRMPANEL_AVANCAR_Result");
            /* Read variables values. */
            A420NegUltIteID = StringUtil.StrToGuid( cgiGet( edtNegUltIteID_Internalname));
            AssignAttri(sPrefix, false, "A420NegUltIteID", A420NegUltIteID.ToString());
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
         E12512 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E12512( )
      {
         /* Start Routine */
         returnInSub = false;
         divCardnegociopj_tablecontent_Height = 157;
         AssignProp(sPrefix, false, divCardnegociopj_tablecontent_Internalname, "Height", StringUtil.LTrimStr( (decimal)(divCardnegociopj_tablecontent_Height), 9, 0), !bGXsfl_12_Refreshing);
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         edtNegID_Visible = 0;
         AssignProp(sPrefix, false, edtNegID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtNegID_Visible), 5, 0), !bGXsfl_12_Refreshing);
         edtNegUltNgfSeq_Visible = 0;
         AssignProp(sPrefix, false, edtNegUltNgfSeq_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtNegUltNgfSeq_Visible), 5, 0), !bGXsfl_12_Refreshing);
         edtNegUltIteOrdem_Visible = 0;
         AssignProp(sPrefix, false, edtNegUltIteOrdem_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtNegUltIteOrdem_Visible), 5, 0), !bGXsfl_12_Refreshing);
         chkavHasnda.Visible = 0;
         AssignProp(sPrefix, false, chkavHasnda_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavHasnda.Visible), 5, 0), !bGXsfl_12_Refreshing);
         cmbavDesenvstatus.Visible = 0;
         AssignProp(sPrefix, false, cmbavDesenvstatus_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDesenvstatus.Visible), 5, 0), !bGXsfl_12_Refreshing);
         chkavHaskitbancocliente.Visible = 0;
         AssignProp(sPrefix, false, chkavHaskitbancocliente_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavHaskitbancocliente.Visible), 5, 0), !bGXsfl_12_Refreshing);
         chkavHaskitgarantiacliente.Visible = 0;
         AssignProp(sPrefix, false, chkavHaskitgarantiacliente_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavHaskitgarantiacliente.Visible), 5, 0), !bGXsfl_12_Refreshing);
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         edtNegUltIteID_Visible = 0;
         AssignProp(sPrefix, false, edtNegUltIteID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtNegUltIteID_Visible), 5, 0), true);
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E13512( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV30Core_wcfuniloportunidadesds_1_negultiteid = AV8NegUltIteID;
      }

      private void E14512( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         GXt_boolean1 = AV24HasNDA;
         new GeneXus.Programs.core.prcnegociopj_temndaassinado(context ).execute(  "NEGOCIOPJ",  StringUtil.Trim( A345NegID.ToString()), out  GXt_boolean1) ;
         AV24HasNDA = GXt_boolean1;
         AssignAttri(sPrefix, false, chkavHasnda_Internalname, AV24HasNDA);
         GXt_boolean1 = AV26HasKitBancoCliente;
         new GeneXus.Programs.core.prcnegociopj_temkitbancocliente(context ).execute(  "NEGOCIOPJ",  StringUtil.Trim( A345NegID.ToString()), out  GXt_boolean1) ;
         AV26HasKitBancoCliente = GXt_boolean1;
         AssignAttri(sPrefix, false, chkavHaskitbancocliente_Internalname, AV26HasKitBancoCliente);
         GXt_boolean1 = AV27HasKitGarantiaCliente;
         new GeneXus.Programs.core.prcnegociopj_temkitgarantiacliente(context ).execute(  "NEGOCIOPJ",  StringUtil.Trim( A345NegID.ToString()), out  GXt_boolean1) ;
         AV27HasKitGarantiaCliente = GXt_boolean1;
         AssignAttri(sPrefix, false, chkavHaskitgarantiacliente_Internalname, AV27HasKitGarantiaCliente);
         GXt_boolean1 = AV29HasPropComerCliente;
         new GeneXus.Programs.core.prcnegociopj_tempropostacomercialcliente(context ).execute(  "NEGOCIOPJ",  StringUtil.Trim( A345NegID.ToString()), out  GXt_boolean1) ;
         AV29HasPropComerCliente = GXt_boolean1;
         if ( ( ( A479NegUltIteOrdem == 2 ) && AV26HasKitBancoCliente && AV27HasKitGarantiaCliente ) || ( ( A479NegUltIteOrdem == 3 ) ) || ( ( A479NegUltIteOrdem == 4 ) ) || ( ( A479NegUltIteOrdem == 5 ) ) )
         {
            lblAnalise_Visible = 1;
         }
         else
         {
            lblAnalise_Visible = 0;
         }
         GXt_boolean1 = AV28TempBoolean;
         new GeneXus.Programs.core.prcnegociopjfluxoverificarconfirmacao(context ).execute(  A345NegID,  "DOCANALISE", out  GXt_boolean1) ;
         GXt_boolean2 = AV28TempBoolean;
         new GeneXus.Programs.core.prcnegociopjfluxoverificarconfirmacao(context ).execute(  A345NegID,  "DOCREGISTRARENVIOCAF", out  GXt_boolean2) ;
         GXt_boolean3 = AV28TempBoolean;
         new GeneXus.Programs.core.prcnegociopjfluxoverificarconfirmacao(context ).execute(  A345NegID,  "DOCREGISTRARRETORNOCAF", out  GXt_boolean3) ;
         GXt_boolean4 = AV28TempBoolean;
         new GeneXus.Programs.core.prcnegociopjfluxoverificarconfirmacao(context ).execute(  A345NegID,  "DOCANALISECREDITO", out  GXt_boolean4) ;
         GXt_boolean5 = AV28TempBoolean;
         new GeneXus.Programs.core.prcnegociopjfluxoverificarconfirmacao(context ).execute(  A345NegID,  "PROPCONFECCIONAR", out  GXt_boolean5) ;
         GXt_boolean6 = AV28TempBoolean;
         new GeneXus.Programs.core.prcnegociopjfluxoverificarconfirmacao(context ).execute(  A345NegID,  "PROPREGENVIOCLIENTE", out  GXt_boolean6) ;
         GXt_boolean7 = AV28TempBoolean;
         new GeneXus.Programs.core.prcnegociopjfluxoverificarconfirmacao(context ).execute(  A345NegID,  "PROPREGRESPCLIENTE", out  GXt_boolean7) ;
         GXt_boolean8 = AV28TempBoolean;
         new GeneXus.Programs.core.prcnegociopjfluxoverificarconfirmacaoassinaturacontrato(context ).execute(  A345NegID, out  GXt_boolean8) ;
         GXt_boolean9 = AV28TempBoolean;
         new GeneXus.Programs.core.prcnegociopjfluxoverificarconfirmacaoencerramento(context ).execute(  A345NegID, out  GXt_boolean9) ;
         AV28TempBoolean = (bool)((A479NegUltIteOrdem<A40000GXC1)&&(((A479NegUltIteOrdem==1)&&(AV24HasNDA))||((A479NegUltIteOrdem==2)&&AV26HasKitBancoCliente&&AV27HasKitGarantiaCliente&&GXt_boolean1&&GXt_boolean2&&GXt_boolean3&&GXt_boolean4)||((A479NegUltIteOrdem==3)&&AV29HasPropComerCliente&&GXt_boolean5&&GXt_boolean6&&GXt_boolean7)||((A479NegUltIteOrdem==4)&&GXt_boolean8)||((A479NegUltIteOrdem==5)&&GXt_boolean9)||(A479NegUltIteOrdem>5)));
         if ( AV28TempBoolean )
         {
            lblAvancar_Visible = 1;
         }
         else
         {
            lblAvancar_Visible = 0;
         }
         if ( A479NegUltIteOrdem > A40001GXC2 )
         {
            lblVoltar_Visible = 1;
         }
         else
         {
            lblVoltar_Visible = 0;
         }
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 12;
         }
         sendrow_122( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_12_Refreshing )
         {
            DoAjaxLoad(12, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E15512( )
      {
         /* 'DoVisitas' Routine */
         returnInSub = false;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "core.visitaww.aspx"+UrlEncode(A345NegID.ToString()) + "," + UrlEncode(StringUtil.LTrimStr(A474NegUltNgfSeq,8,0));
         CallWebObject(formatLink("core.visitaww.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E16512( )
      {
         /* 'DoDocumentos' Routine */
         returnInSub = false;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "core.documentoww.aspx"+UrlEncode(StringUtil.RTrim("NEGOCIOPJ")) + "," + UrlEncode(StringUtil.RTrim(StringUtil.Trim( A345NegID.ToString())));
         CallWebObject(formatLink("core.documentoww.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
         context.wjLocDisableFrm = 1;
      }

      protected void E17512( )
      {
         /* 'DoAnalise' Routine */
         returnInSub = false;
         if ( A479NegUltIteOrdem == 2 )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
               }
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "core.documentacaoaprovadafluxo.aspx"+UrlEncode(StringUtil.RTrim("NEGOCIOPJ")) + "," + UrlEncode(StringUtil.RTrim(StringUtil.Trim( A345NegID.ToString())));
            CallWebObject(formatLink("core.documentacaoaprovadafluxo.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         else if ( A479NegUltIteOrdem == 3 )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
               }
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "propostaaprovadafluxo.aspx"+UrlEncode(StringUtil.RTrim("NEGOCIOPJ")) + "," + UrlEncode(StringUtil.RTrim(StringUtil.Trim( A345NegID.ToString())));
            CallWebObject(formatLink("propostaaprovadafluxo.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         else if ( A479NegUltIteOrdem == 4 )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
               }
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "assinaturacontratofluxo.aspx"+UrlEncode(StringUtil.RTrim("NEGOCIOPJ")) + "," + UrlEncode(StringUtil.RTrim(StringUtil.Trim( A345NegID.ToString())));
            CallWebObject(formatLink("assinaturacontratofluxo.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         else if ( A479NegUltIteOrdem == 5 )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
               }
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wpencerramentofluxo.aspx"+UrlEncode(StringUtil.RTrim("NEGOCIOPJ")) + "," + UrlEncode(StringUtil.RTrim(StringUtil.Trim( A345NegID.ToString())));
            CallWebObject(formatLink("wpencerramentofluxo.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
      }

      protected void E11512( )
      {
         /* Dvelop_confirmpanel_avancar_Close Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Dvelop_confirmpanel_avancar_Result, "Yes") == 0 )
         {
            /* Execute user subroutine: 'DO AVANCAR' */
            S152 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
      }

      protected void E18512( )
      {
         /* 'DoVoltar' Routine */
         returnInSub = false;
         new GeneXus.Programs.core.prcnegociopjretrocederfase(context ).execute(  A345NegID,  true, out  AV20Messages) ;
         AV23HasError = false;
         AV31GXV1 = 1;
         while ( AV31GXV1 <= AV20Messages.Count )
         {
            AV22Message = ((GeneXus.Utils.SdtMessages_Message)AV20Messages.Item(AV31GXV1));
            if ( AV22Message.gxTpr_Type == 1 )
            {
               AV23HasError = true;
               GX_msglist.addItem(AV22Message.gxTpr_Description);
               if (true) break;
            }
            AV31GXV1 = (int)(AV31GXV1+1);
         }
         if ( ! AV23HasError )
         {
            this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "RefreshGridParent", new Object[] {}, true);
         }
      }

      protected void S152( )
      {
         /* 'DO AVANCAR' Routine */
         returnInSub = false;
         new GeneXus.Programs.core.prcnegociopjproximafase(context ).execute(  AV21NegID_Selected,  true, out  AV20Messages) ;
         AV23HasError = false;
         AV32GXV2 = 1;
         while ( AV32GXV2 <= AV20Messages.Count )
         {
            AV22Message = ((GeneXus.Utils.SdtMessages_Message)AV20Messages.Item(AV32GXV2));
            if ( AV22Message.gxTpr_Type == 1 )
            {
               AV23HasError = true;
               GX_msglist.addItem(AV22Message.gxTpr_Description);
               if (true) break;
            }
            AV32GXV2 = (int)(AV32GXV2+1);
         }
         if ( ! AV23HasError )
         {
            this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "RefreshGridParent", new Object[] {}, true);
         }
      }

      protected void S132( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV14Session.Get(AV33Pgmname+"GridState"), "") == 0 )
         {
            AV12GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV33Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV12GridState.FromXml(AV14Session.Get(AV33Pgmname+"GridState"), null, "", "");
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV12GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV12GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV12GridState.gxTpr_Currentpage) ;
      }

      protected void S142( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV12GridState.FromXml(AV14Session.Get(AV33Pgmname+"GridState"), null, "", "");
         AV12GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV12GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV33Pgmname+"GridState",  AV12GridState.ToXml(false, true, "", "")) ;
      }

      protected void S122( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV10TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV10TrnContext.gxTpr_Callerobject = AV33Pgmname;
         AV10TrnContext.gxTpr_Callerondelete = true;
         AV10TrnContext.gxTpr_Callerurl = AV9HTTPRequest.ScriptName+"?"+AV9HTTPRequest.QueryString;
         AV10TrnContext.gxTpr_Transactionname = "core.NegocioPJ";
         AV11TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV11TrnContextAtt.gxTpr_Attributename = "NegUltIteID";
         AV11TrnContextAtt.gxTpr_Attributevalue = AV8NegUltIteID.ToString();
         AV10TrnContext.gxTpr_Attributes.Add(AV11TrnContextAtt, 0);
         AV14Session.Set("TrnContext", AV10TrnContext.ToXml(false, true, "", ""));
      }

      protected void S112( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         tblTable_can_Visible = (((StringUtil.StrCmp(AV25DesenvStatus, "CAN")==0)) ? 1 : 0);
         AssignProp(sPrefix, false, tblTable_can_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblTable_can_Visible), 5, 0), !bGXsfl_12_Refreshing);
         tblTable_nda_Visible = (((!(StringUtil.StrCmp(AV25DesenvStatus, "CAN")==0)&&AV24HasNDA)) ? 1 : 0);
         AssignProp(sPrefix, false, tblTable_nda_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblTable_nda_Visible), 5, 0), !bGXsfl_12_Refreshing);
      }

      protected void wb_table1_103_512( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTabledvelop_confirmpanel_avancar_Internalname, tblTabledvelop_confirmpanel_avancar_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucDvelop_confirmpanel_avancar.SetProperty("Title", Dvelop_confirmpanel_avancar_Title);
            ucDvelop_confirmpanel_avancar.SetProperty("ConfirmationText", Dvelop_confirmpanel_avancar_Confirmationtext);
            ucDvelop_confirmpanel_avancar.SetProperty("YesButtonCaption", Dvelop_confirmpanel_avancar_Yesbuttoncaption);
            ucDvelop_confirmpanel_avancar.SetProperty("NoButtonCaption", Dvelop_confirmpanel_avancar_Nobuttoncaption);
            ucDvelop_confirmpanel_avancar.SetProperty("CancelButtonCaption", Dvelop_confirmpanel_avancar_Cancelbuttoncaption);
            ucDvelop_confirmpanel_avancar.SetProperty("YesButtonPosition", Dvelop_confirmpanel_avancar_Yesbuttonposition);
            ucDvelop_confirmpanel_avancar.SetProperty("ConfirmType", Dvelop_confirmpanel_avancar_Confirmtype);
            ucDvelop_confirmpanel_avancar.Render(context, "dvelop.gxbootstrap.confirmpanel", Dvelop_confirmpanel_avancar_Internalname, sPrefix+"DVELOP_CONFIRMPANEL_AVANCARContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+sPrefix+"DVELOP_CONFIRMPANEL_AVANCARContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_103_512e( true) ;
         }
         else
         {
            wb_table1_103_512e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV8NegUltIteID = (Guid)getParm(obj,0);
         AssignAttri(sPrefix, false, "AV8NegUltIteID", AV8NegUltIteID.ToString());
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
         PA512( ) ;
         WS512( ) ;
         WE512( ) ;
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
         sCtrlAV8NegUltIteID = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA512( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "core\\wcfuniloportunidades", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA512( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV8NegUltIteID = (Guid)getParm(obj,2);
            AssignAttri(sPrefix, false, "AV8NegUltIteID", AV8NegUltIteID.ToString());
         }
         wcpOAV8NegUltIteID = StringUtil.StrToGuid( cgiGet( sPrefix+"wcpOAV8NegUltIteID"));
         if ( ! GetJustCreated( ) && ( ( AV8NegUltIteID != wcpOAV8NegUltIteID ) ) )
         {
            setjustcreated();
         }
         wcpOAV8NegUltIteID = AV8NegUltIteID;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV8NegUltIteID = cgiGet( sPrefix+"AV8NegUltIteID_CTRL");
         if ( StringUtil.Len( sCtrlAV8NegUltIteID) > 0 )
         {
            AV8NegUltIteID = StringUtil.StrToGuid( cgiGet( sCtrlAV8NegUltIteID));
            AssignAttri(sPrefix, false, "AV8NegUltIteID", AV8NegUltIteID.ToString());
         }
         else
         {
            AV8NegUltIteID = StringUtil.StrToGuid( cgiGet( sPrefix+"AV8NegUltIteID_PARM"));
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
         PA512( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS512( ) ;
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
         WS512( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV8NegUltIteID_PARM", AV8NegUltIteID.ToString());
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV8NegUltIteID)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV8NegUltIteID_CTRL", StringUtil.RTrim( sCtrlAV8NegUltIteID));
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
         WE512( ) ;
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
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2023822192543", true, true);
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
            context.AddJavascriptSource("core/wcfuniloportunidades.js", "?2023822192544", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         }
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_122( )
      {
         edtNegCliNomeFamiliar_Internalname = sPrefix+"NEGCLINOMEFAMILIAR_"+sGXsfl_12_idx;
         edtNegCpjNomFan_Internalname = sPrefix+"NEGCPJNOMFAN_"+sGXsfl_12_idx;
         edtNegValorAtualizado_Internalname = sPrefix+"NEGVALORATUALIZADO_"+sGXsfl_12_idx;
         edtNegAssunto_Internalname = sPrefix+"NEGASSUNTO_"+sGXsfl_12_idx;
         lblTag_can_Internalname = sPrefix+"TAG_CAN_"+sGXsfl_12_idx;
         lblTxtesp01_can_Internalname = sPrefix+"TXTESP01_CAN_"+sGXsfl_12_idx;
         lblTxtdescartado_Internalname = sPrefix+"TXTDESCARTADO_"+sGXsfl_12_idx;
         lblTag_nda_Internalname = sPrefix+"TAG_NDA_"+sGXsfl_12_idx;
         lblTxtesp02_nda_Internalname = sPrefix+"TXTESP02_NDA_"+sGXsfl_12_idx;
         lblTxt_nda_Internalname = sPrefix+"TXT_NDA_"+sGXsfl_12_idx;
         lblVisitas_Internalname = sPrefix+"VISITAS_"+sGXsfl_12_idx;
         lblDocumentos_Internalname = sPrefix+"DOCUMENTOS_"+sGXsfl_12_idx;
         lblAnalise_Internalname = sPrefix+"ANALISE_"+sGXsfl_12_idx;
         lblAvancar_Internalname = sPrefix+"AVANCAR_"+sGXsfl_12_idx;
         lblVoltar_Internalname = sPrefix+"VOLTAR_"+sGXsfl_12_idx;
         edtNegID_Internalname = sPrefix+"NEGID_"+sGXsfl_12_idx;
         edtNegUltNgfSeq_Internalname = sPrefix+"NEGULTNGFSEQ_"+sGXsfl_12_idx;
         edtNegUltIteOrdem_Internalname = sPrefix+"NEGULTITEORDEM_"+sGXsfl_12_idx;
         chkavHasnda_Internalname = sPrefix+"vHASNDA_"+sGXsfl_12_idx;
         cmbavDesenvstatus_Internalname = sPrefix+"vDESENVSTATUS_"+sGXsfl_12_idx;
         chkavHaskitbancocliente_Internalname = sPrefix+"vHASKITBANCOCLIENTE_"+sGXsfl_12_idx;
         chkavHaskitgarantiacliente_Internalname = sPrefix+"vHASKITGARANTIACLIENTE_"+sGXsfl_12_idx;
      }

      protected void SubsflControlProps_fel_122( )
      {
         edtNegCliNomeFamiliar_Internalname = sPrefix+"NEGCLINOMEFAMILIAR_"+sGXsfl_12_fel_idx;
         edtNegCpjNomFan_Internalname = sPrefix+"NEGCPJNOMFAN_"+sGXsfl_12_fel_idx;
         edtNegValorAtualizado_Internalname = sPrefix+"NEGVALORATUALIZADO_"+sGXsfl_12_fel_idx;
         edtNegAssunto_Internalname = sPrefix+"NEGASSUNTO_"+sGXsfl_12_fel_idx;
         lblTag_can_Internalname = sPrefix+"TAG_CAN_"+sGXsfl_12_fel_idx;
         lblTxtesp01_can_Internalname = sPrefix+"TXTESP01_CAN_"+sGXsfl_12_fel_idx;
         lblTxtdescartado_Internalname = sPrefix+"TXTDESCARTADO_"+sGXsfl_12_fel_idx;
         lblTag_nda_Internalname = sPrefix+"TAG_NDA_"+sGXsfl_12_fel_idx;
         lblTxtesp02_nda_Internalname = sPrefix+"TXTESP02_NDA_"+sGXsfl_12_fel_idx;
         lblTxt_nda_Internalname = sPrefix+"TXT_NDA_"+sGXsfl_12_fel_idx;
         lblVisitas_Internalname = sPrefix+"VISITAS_"+sGXsfl_12_fel_idx;
         lblDocumentos_Internalname = sPrefix+"DOCUMENTOS_"+sGXsfl_12_fel_idx;
         lblAnalise_Internalname = sPrefix+"ANALISE_"+sGXsfl_12_fel_idx;
         lblAvancar_Internalname = sPrefix+"AVANCAR_"+sGXsfl_12_fel_idx;
         lblVoltar_Internalname = sPrefix+"VOLTAR_"+sGXsfl_12_fel_idx;
         edtNegID_Internalname = sPrefix+"NEGID_"+sGXsfl_12_fel_idx;
         edtNegUltNgfSeq_Internalname = sPrefix+"NEGULTNGFSEQ_"+sGXsfl_12_fel_idx;
         edtNegUltIteOrdem_Internalname = sPrefix+"NEGULTITEORDEM_"+sGXsfl_12_fel_idx;
         chkavHasnda_Internalname = sPrefix+"vHASNDA_"+sGXsfl_12_fel_idx;
         cmbavDesenvstatus_Internalname = sPrefix+"vDESENVSTATUS_"+sGXsfl_12_fel_idx;
         chkavHaskitbancocliente_Internalname = sPrefix+"vHASKITBANCOCLIENTE_"+sGXsfl_12_fel_idx;
         chkavHaskitgarantiacliente_Internalname = sPrefix+"vHASKITGARANTIACLIENTE_"+sGXsfl_12_fel_idx;
      }

      protected void sendrow_122( )
      {
         SubsflControlProps_122( ) ;
         WB510( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_12_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               subGrid_Backcolor = (int)(0xFFFFFF);
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
            }
            /* Start of Columns property logic. */
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divMainlayout_Internalname+"_"+sGXsfl_12_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"CellMarginTop",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divCardnegociopj_tablecard_Internalname+"_"+sGXsfl_12_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"SimpleCardTable",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-9 col-sm-10",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divCardnegociopj_tablecontent_Internalname+"_"+sGXsfl_12_idx,(short)1,(short)0,(string)"px",(int)divCardnegociopj_tablecontent_Height,(string)"px",(string)"Table",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
            /* Table start */
            GridRow.AddColumnProperties("table", -1, isAjaxCallMode( ), new Object[] {(string)tblCardnegociopj_tabletopinfo_Internalname+"_"+sGXsfl_12_idx,(short)1,(string)"Table",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(short)2,(string)"",(string)"",(string)"",(string)"px",(string)"px",(string)""});
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
            GridRow.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
            GridRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divCardnegociopj_tabletitle_Internalname+"_"+sGXsfl_12_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Table",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
            /* Attribute/Variable Label */
            GridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtNegCliNomeFamiliar_Internalname,(string)"Nome Familiar",(string)"col-sm-3 SimpleCardAttributeTitleLabel",(short)0,(bool)true,(string)""});
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
            /* Single line edit */
            ROClassString = "SimpleCardAttributeTitle";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNegCliNomeFamiliar_Internalname,(string)A351NegCliNomeFamiliar,StringUtil.RTrim( context.localUtil.Format( A351NegCliNomeFamiliar, "@!")),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNegCliNomeFamiliar_Jsonclick,(short)0,(string)"SimpleCardAttributeTitle",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(short)0,(short)0,(string)"text",(string)"",(short)80,(string)"chr",(short)1,(string)"row",(short)80,(short)0,(short)0,(short)12,(short)0,(short)-1,(short)-1,(bool)true,(string)"core\\Nome",(string)"start",(bool)true,(string)""});
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
            /* Attribute/Variable Label */
            GridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtNegCpjNomFan_Internalname,(string)"Nome Fantasia",(string)"col-sm-3 SimpleCardAttributeSubtitleLabel",(short)0,(bool)true,(string)""});
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
            /* Single line edit */
            ROClassString = "SimpleCardAttributeSubtitle";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNegCpjNomFan_Internalname,(string)A353NegCpjNomFan,StringUtil.RTrim( context.localUtil.Format( A353NegCpjNomFan, "@!")),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNegCpjNomFan_Jsonclick,(short)0,(string)"SimpleCardAttributeSubtitle",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(short)0,(short)0,(string)"text",(string)"",(short)80,(string)"chr",(short)1,(string)"row",(short)80,(short)0,(short)0,(short)12,(short)0,(short)-1,(short)-1,(bool)true,(string)"core\\Nome",(string)"start",(bool)true,(string)""});
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
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
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 CellMarginLeft5",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
            /* Attribute/Variable Label */
            GridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtNegValorAtualizado_Internalname,(string)"Valor Atualizado em Negócios",(string)"col-sm-3 AttributeSecondaryLabel",(short)0,(bool)true,(string)""});
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
            /* Single line edit */
            ROClassString = "AttributeSecondary";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNegValorAtualizado_Internalname,StringUtil.LTrim( StringUtil.NToC( A385NegValorAtualizado, 23, 2, ",", "")),StringUtil.LTrim( context.localUtil.Format( A385NegValorAtualizado, "R$ Z,ZZZ,ZZZ,ZZZ,ZZ9.99")),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNegValorAtualizado_Jsonclick,(short)0,(string)"AttributeSecondary",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(short)0,(short)0,(string)"text",(string)"",(short)23,(string)"chr",(short)1,(string)"row",(short)23,(short)0,(short)0,(short)12,(short)0,(short)-1,(short)0,(bool)true,(string)"core\\Monetario",(string)"end",(bool)false,(string)""});
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 CellMarginLeft5",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
            /* Attribute/Variable Label */
            GridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtNegAssunto_Internalname,(string)"Assunto",(string)"col-sm-3 AttributeSecondaryLabel",(short)0,(bool)true,(string)""});
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
            /* Single line edit */
            ROClassString = "AttributeSecondary";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNegAssunto_Internalname,(string)A362NegAssunto,StringUtil.RTrim( context.localUtil.Format( A362NegAssunto, "@!")),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNegAssunto_Jsonclick,(short)0,(string)"AttributeSecondary",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(short)0,(short)0,(string)"text",(string)"",(short)80,(string)"chr",(short)1,(string)"row",(short)80,(short)0,(short)0,(short)12,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 CellMarginLeft5 CellMarginTop10",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridRow.AddRenderProperties(GridColumn);
            sendrow_12230( ) ;
         }
      }

      protected void sendrow_12230( )
      {
         /* Table start */
         GridRow.AddColumnProperties("table", -1, isAjaxCallMode( ), new Object[] {(string)tblTable_can_Internalname+"_"+sGXsfl_12_idx,(int)tblTable_can_Visible,(string)"Table",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(short)2,(string)"",(string)"",(string)"",(string)"px",(string)"px",(string)""});
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
         GridRow.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
         GridRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
         /* Text block */
         GridRow.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblTag_can_Internalname,(string)"<i class=\"ImageMenuIcon-left fas fa-xmark\"></i>",(string)"",(string)"",(string)lblTag_can_Jsonclick,(string)"'"+sPrefix+"'"+",false,"+"'"+"e19512_client"+"'",(string)"",(string)"TextBlock",(short)7,(string)"",(short)1,(short)1,(short)0,(short)1});
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
         if ( GridContainer.GetWrapped() == 1 )
         {
            GridContainer.CloseTag("cell");
         }
         GridRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
         /* Text block */
         GridRow.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblTxtesp01_can_Internalname,(string)"&nbsp;",(string)"",(string)"",(string)lblTxtesp01_can_Jsonclick,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"TextBlock",(short)0,(string)"",(short)1,(short)1,(short)0,(short)2});
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
         if ( GridContainer.GetWrapped() == 1 )
         {
            GridContainer.CloseTag("cell");
         }
         GridRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
         /* Text block */
         GridRow.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblTxtdescartado_Internalname,(string)"Descartado",(string)"",(string)"",(string)lblTxtdescartado_Jsonclick,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"TextBlock",(short)0,(string)"",(short)1,(short)1,(short)0,(short)0});
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
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
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
         GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
         /* Div Control */
         GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
         /* Div Control */
         GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 CellMarginLeft5 CellMarginTop10",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
         /* Table start */
         GridRow.AddColumnProperties("table", -1, isAjaxCallMode( ), new Object[] {(string)tblTable_nda_Internalname+"_"+sGXsfl_12_idx,(int)tblTable_nda_Visible,(string)"Table",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(short)2,(string)"",(string)"",(string)"",(string)"px",(string)"px",(string)""});
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
         GridRow.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
         GridRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
         /* Text block */
         GridRow.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblTag_nda_Internalname,(string)"<i class=\"ImageMenuIcon-left fas fa-file-signature\"></i>",(string)"",(string)"",(string)lblTag_nda_Jsonclick,(string)"'"+sPrefix+"'"+",false,"+"'"+"e20512_client"+"'",(string)"",(string)"TextBlock",(short)7,(string)"",(short)1,(short)1,(short)0,(short)1});
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
         if ( GridContainer.GetWrapped() == 1 )
         {
            GridContainer.CloseTag("cell");
         }
         GridRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
         /* Text block */
         GridRow.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblTxtesp02_nda_Internalname,(string)"&nbsp;",(string)"",(string)"",(string)lblTxtesp02_nda_Jsonclick,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"TextBlock",(short)0,(string)"",(short)1,(short)1,(short)0,(short)2});
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
         if ( GridContainer.GetWrapped() == 1 )
         {
            GridContainer.CloseTag("cell");
         }
         GridRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
         /* Text block */
         GridRow.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblTxt_nda_Internalname,(string)"NDA Assinado",(string)"",(string)"",(string)lblTxt_nda_Jsonclick,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"TextBlock",(short)0,(string)"",(short)1,(short)1,(short)0,(short)0});
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
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
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
         GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
         GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
         GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
         /* Div Control */
         GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-3 col-sm-2",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
         /* Div Control */
         GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divTablebuttons_Internalname+"_"+sGXsfl_12_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Flex",(string)"start",(string)"top",(string)" "+"data-gx-flex"+" ",(string)"flex-direction:column;flex-wrap:wrap;justify-content:flex-end;align-items:flex-end;align-content:flex-end;",(string)"div"});
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
         /* Div Control */
         GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"CellMarginBottom10",(string)"start",(string)"top",(string)"",(string)"flex-grow:1;",(string)"div"});
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
         /* Text block */
         GridRow.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblVisitas_Internalname,(string)"<i class=\"ImageMenuIcon-right far fa-calendar-plus\"></i>",(string)"",(string)"",(string)lblVisitas_Jsonclick,"'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOVISITAS\\'."+sGXsfl_12_idx+"'",(string)"",(string)"TextBlock",(short)5,(string)"Visitas",(short)1,(short)1,(short)0,(short)1});
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
         GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
         /* Div Control */
         GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"CellMarginBottom10",(string)"start",(string)"top",(string)"",(string)"flex-grow:1;",(string)"div"});
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
         /* Text block */
         GridRow.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblDocumentos_Internalname,(string)"<i class=\"ImageMenuIcon-right fas fa-file-arrow-up\"></i>",(string)"",(string)"",(string)lblDocumentos_Jsonclick,"'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DODOCUMENTOS\\'."+sGXsfl_12_idx+"'",(string)"",(string)"TextBlock",(short)5,(string)"Documentos",(short)1,(short)1,(short)0,(short)1});
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
         GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
         /* Div Control */
         GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"CellMarginBottom10",(string)"start",(string)"top",(string)"",(string)"flex-grow:1;",(string)"div"});
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
         /* Text block */
         GridRow.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblAnalise_Internalname,(string)"<i class=\"ImageMenuIcon-right fa-solid fa-check\"></i>",(string)"",(string)"",(string)lblAnalise_Jsonclick,"'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOANALISE\\'."+sGXsfl_12_idx+"'",(string)"",(string)"TextBlock",(short)5,(string)"",(int)lblAnalise_Visible,(short)1,(short)0,(short)1});
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
         GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
         /* Div Control */
         GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"CellMarginBottom10",(string)"start",(string)"top",(string)"",(string)"flex-grow:1;",(string)"div"});
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
         /* Text block */
         GridRow.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblAvancar_Internalname,(string)"<i class=\"ImageMenuIcon-right far fa-circle-right\"></i>",(string)"",(string)"",(string)lblAvancar_Jsonclick,(string)"'"+sPrefix+"'"+",false,"+"'"+"e21512_client"+"'",(string)"",(string)"TextBlock",(short)7,(string)"Avançar",(int)lblAvancar_Visible,(short)1,(short)0,(short)1});
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
         GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
         /* Div Control */
         GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"start",(string)"top",(string)"",(string)"flex-grow:1;",(string)"div"});
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
         /* Text block */
         GridRow.AddColumnProperties("label", 1, isAjaxCallMode( ), new Object[] {(string)lblVoltar_Internalname,(string)"<i class=\"ImageMenuIcon-right far fa-circle-left\"></i>",(string)"",(string)"",(string)lblVoltar_Jsonclick,"'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOVOLTAR\\'."+sGXsfl_12_idx+"'",(string)"",(string)"TextBlock",(short)5,(string)"Voltar",(int)lblVoltar_Visible,(short)1,(short)0,(short)1});
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
         GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
         GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
         GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
         GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
         GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
         GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
         GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
         sendrow_12260( ) ;
      }

      protected void sendrow_12260( )
      {
         /* Div Control */
         GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
         /* Div Control */
         GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 Invisible",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
         /* Table start */
         GridRow.AddColumnProperties("table", -1, isAjaxCallMode( ), new Object[] {(string)tblUnnamedtablecontentfsgrid_Internalname+"_"+sGXsfl_12_idx,(short)1,(string)"Table",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(short)2,(string)"",(string)"",(string)"",(string)"px",(string)"px",(string)""});
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
         GridRow.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
         GridRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
         /* Div Control */
         GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
         /* Attribute/Variable Label */
         GridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtNegID_Internalname,(string)"ID",(string)"gx-form-item AttributeLabel",(short)0,(bool)true,(string)"width: 25%;"});
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
         /* Single line edit */
         ROClassString = "Attribute";
         GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNegID_Internalname,A345NegID.ToString(),A345NegID.ToString(),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNegID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(int)edtNegID_Visible,(short)0,(short)0,(string)"text",(string)"",(short)36,(string)"chr",(short)1,(string)"row",(short)36,(short)0,(short)0,(short)12,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
         GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
         if ( GridContainer.GetWrapped() == 1 )
         {
            GridContainer.CloseTag("cell");
         }
         GridRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
         /* Div Control */
         GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
         /* Attribute/Variable Label */
         GridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtNegUltNgfSeq_Internalname,(string)"Última Fase",(string)"gx-form-item AttributeLabel",(short)0,(bool)true,(string)"width: 25%;"});
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
         /* Single line edit */
         ROClassString = "Attribute";
         GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNegUltNgfSeq_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A474NegUltNgfSeq), 8, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A474NegUltNgfSeq), "ZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNegUltNgfSeq_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(int)edtNegUltNgfSeq_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)8,(string)"chr",(short)1,(string)"row",(short)8,(short)0,(short)0,(short)12,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
         GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
         if ( GridContainer.GetWrapped() == 1 )
         {
            GridContainer.CloseTag("cell");
         }
         GridRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
         /* Div Control */
         GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
         /* Attribute/Variable Label */
         GridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtNegUltIteOrdem_Internalname,(string)"ÚltimaOrdem",(string)"gx-form-item AttributeLabel",(short)0,(bool)true,(string)"width: 25%;"});
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
         /* Single line edit */
         ROClassString = "Attribute";
         GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNegUltIteOrdem_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A479NegUltIteOrdem), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A479NegUltIteOrdem), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNegUltIteOrdem_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(int)edtNegUltIteOrdem_Visible,(short)0,(short)0,(string)"text",(string)"1",(short)4,(string)"chr",(short)1,(string)"row",(short)4,(short)0,(short)0,(short)12,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
         GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
         if ( GridContainer.GetWrapped() == 1 )
         {
            GridContainer.CloseTag("cell");
         }
         GridRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
         /* Div Control */
         GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
         /* Attribute/Variable Label */
         GridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)chkavHasnda_Internalname,(string)"Has NDA",(string)"gx-form-item AttributeLabel",(short)0,(bool)true,(string)"width: 25%;"});
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
         /* Check box */
         TempTags = " " + ((chkavHasnda.Enabled!=0)&&(chkavHasnda.Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 89,'"+sPrefix+"',false,'"+sGXsfl_12_idx+"',12)\"" : " ");
         ClassString = "Attribute";
         StyleString = "";
         GXCCtl = "vHASNDA_" + sGXsfl_12_idx;
         chkavHasnda.Name = GXCCtl;
         chkavHasnda.WebTags = "";
         chkavHasnda.Caption = "";
         AssignProp(sPrefix, false, chkavHasnda_Internalname, "TitleCaption", chkavHasnda.Caption, !bGXsfl_12_Refreshing);
         chkavHasnda.CheckedValue = "false";
         GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkavHasnda_Internalname,StringUtil.BoolToStr( AV24HasNDA),(string)"",(string)"Has NDA",chkavHasnda.Visible,(short)1,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",TempTags+" onclick="+"\"gx.fn.checkboxClick(89, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+((chkavHasnda.Enabled!=0)&&(chkavHasnda.Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,89);\"" : " ")});
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
         GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
         if ( GridContainer.GetWrapped() == 1 )
         {
            GridContainer.CloseTag("cell");
         }
         GridRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
         /* Div Control */
         GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
         /* Attribute/Variable Label */
         GridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)cmbavDesenvstatus_Internalname,(string)"Desenv Status",(string)"gx-form-item AttributeLabel",(short)0,(bool)true,(string)"width: 25%;"});
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
         TempTags = " " + ((cmbavDesenvstatus.Enabled!=0)&&(cmbavDesenvstatus.Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 92,'"+sPrefix+"',false,'"+sGXsfl_12_idx+"',12)\"" : " ");
         if ( ( cmbavDesenvstatus.ItemCount == 0 ) && isAjaxCallMode( ) )
         {
            GXCCtl = "vDESENVSTATUS_" + sGXsfl_12_idx;
            cmbavDesenvstatus.Name = GXCCtl;
            cmbavDesenvstatus.WebTags = "";
            cmbavDesenvstatus.addItem("PEN", "Pendente", 0);
            cmbavDesenvstatus.addItem("VRE", "Visita Reagendada", 0);
            cmbavDesenvstatus.addItem("CAN", "Descartado", 0);
            cmbavDesenvstatus.addItem("APR", "Aprovado (Prosseguiu p/ Documentação)", 0);
            if ( cmbavDesenvstatus.ItemCount > 0 )
            {
               AV25DesenvStatus = cmbavDesenvstatus.getValidValue(AV25DesenvStatus);
               AssignAttri(sPrefix, false, cmbavDesenvstatus_Internalname, AV25DesenvStatus);
            }
         }
         /* ComboBox */
         GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavDesenvstatus,(string)cmbavDesenvstatus_Internalname,StringUtil.RTrim( AV25DesenvStatus),(short)1,(string)cmbavDesenvstatus_Jsonclick,(short)0,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",cmbavDesenvstatus.Visible,(short)1,(short)0,(short)0,(short)0,(string)"em",(short)0,(string)"",(string)"",(string)"Attribute",(string)"",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((cmbavDesenvstatus.Enabled!=0)&&(cmbavDesenvstatus.Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,92);\"" : " "),(string)"",(bool)true,(short)0});
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
         cmbavDesenvstatus.CurrentValue = StringUtil.RTrim( AV25DesenvStatus);
         AssignProp(sPrefix, false, cmbavDesenvstatus_Internalname, "Values", (string)(cmbavDesenvstatus.ToJavascriptSource()), !bGXsfl_12_Refreshing);
         GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
         if ( GridContainer.GetWrapped() == 1 )
         {
            GridContainer.CloseTag("cell");
         }
         GridRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
         /* Div Control */
         GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
         /* Attribute/Variable Label */
         GridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)chkavHaskitbancocliente_Internalname,(string)"Has Kit Banco Cliente",(string)"gx-form-item AttributeLabel",(short)0,(bool)true,(string)"width: 25%;"});
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
         /* Check box */
         TempTags = " " + ((chkavHaskitbancocliente.Enabled!=0)&&(chkavHaskitbancocliente.Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 95,'"+sPrefix+"',false,'"+sGXsfl_12_idx+"',12)\"" : " ");
         ClassString = "Attribute";
         StyleString = "";
         GXCCtl = "vHASKITBANCOCLIENTE_" + sGXsfl_12_idx;
         chkavHaskitbancocliente.Name = GXCCtl;
         chkavHaskitbancocliente.WebTags = "";
         chkavHaskitbancocliente.Caption = "";
         AssignProp(sPrefix, false, chkavHaskitbancocliente_Internalname, "TitleCaption", chkavHaskitbancocliente.Caption, !bGXsfl_12_Refreshing);
         chkavHaskitbancocliente.CheckedValue = "false";
         GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkavHaskitbancocliente_Internalname,StringUtil.BoolToStr( AV26HasKitBancoCliente),(string)"",(string)"Has Kit Banco Cliente",chkavHaskitbancocliente.Visible,(short)1,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",TempTags+" onclick="+"\"gx.fn.checkboxClick(95, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+((chkavHaskitbancocliente.Enabled!=0)&&(chkavHaskitbancocliente.Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,95);\"" : " ")});
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
         GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
         if ( GridContainer.GetWrapped() == 1 )
         {
            GridContainer.CloseTag("cell");
         }
         GridRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
         /* Div Control */
         GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"start",(string)"top",(string)"",(string)"",(string)"div"});
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
         /* Attribute/Variable Label */
         GridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)chkavHaskitgarantiacliente_Internalname,(string)"Has Kit Garantia Cliente",(string)"gx-form-item AttributeLabel",(short)0,(bool)true,(string)"width: 25%;"});
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
         /* Check box */
         TempTags = " " + ((chkavHaskitgarantiacliente.Enabled!=0)&&(chkavHaskitgarantiacliente.Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 98,'"+sPrefix+"',false,'"+sGXsfl_12_idx+"',12)\"" : " ");
         ClassString = "Attribute";
         StyleString = "";
         GXCCtl = "vHASKITGARANTIACLIENTE_" + sGXsfl_12_idx;
         chkavHaskitgarantiacliente.Name = GXCCtl;
         chkavHaskitgarantiacliente.WebTags = "";
         chkavHaskitgarantiacliente.Caption = "";
         AssignProp(sPrefix, false, chkavHaskitgarantiacliente_Internalname, "TitleCaption", chkavHaskitgarantiacliente.Caption, !bGXsfl_12_Refreshing);
         chkavHaskitgarantiacliente.CheckedValue = "false";
         GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkavHaskitgarantiacliente_Internalname,StringUtil.BoolToStr( AV27HasKitGarantiaCliente),(string)"",(string)"Has Kit Garantia Cliente",chkavHaskitgarantiacliente.Visible,(short)1,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",TempTags+" onclick="+"\"gx.fn.checkboxClick(98, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+((chkavHaskitgarantiacliente.Enabled!=0)&&(chkavHaskitgarantiacliente.Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,98);\"" : " ")});
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
         GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
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
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
         GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
         GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"start",(string)"top",(string)"div"});
         GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridRow.AddRenderProperties(GridColumn);
         send_integrity_lvl_hashes512( ) ;
         /* End of Columns property logic. */
         GridContainer.AddRow(GridRow);
         nGXsfl_12_idx = ((subGrid_Islastpage==1)&&(nGXsfl_12_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_12_idx+1);
         sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
         SubsflControlProps_122( ) ;
         /* End function sendrow_122 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "vHASNDA_" + sGXsfl_12_idx;
         chkavHasnda.Name = GXCCtl;
         chkavHasnda.WebTags = "";
         chkavHasnda.Caption = "";
         AssignProp(sPrefix, false, chkavHasnda_Internalname, "TitleCaption", chkavHasnda.Caption, !bGXsfl_12_Refreshing);
         chkavHasnda.CheckedValue = "false";
         GXCCtl = "vDESENVSTATUS_" + sGXsfl_12_idx;
         cmbavDesenvstatus.Name = GXCCtl;
         cmbavDesenvstatus.WebTags = "";
         cmbavDesenvstatus.addItem("PEN", "Pendente", 0);
         cmbavDesenvstatus.addItem("VRE", "Visita Reagendada", 0);
         cmbavDesenvstatus.addItem("CAN", "Descartado", 0);
         cmbavDesenvstatus.addItem("APR", "Aprovado (Prosseguiu p/ Documentação)", 0);
         if ( cmbavDesenvstatus.ItemCount > 0 )
         {
         }
         GXCCtl = "vHASKITBANCOCLIENTE_" + sGXsfl_12_idx;
         chkavHaskitbancocliente.Name = GXCCtl;
         chkavHaskitbancocliente.WebTags = "";
         chkavHaskitbancocliente.Caption = "";
         AssignProp(sPrefix, false, chkavHaskitbancocliente_Internalname, "TitleCaption", chkavHaskitbancocliente.Caption, !bGXsfl_12_Refreshing);
         chkavHaskitbancocliente.CheckedValue = "false";
         GXCCtl = "vHASKITGARANTIACLIENTE_" + sGXsfl_12_idx;
         chkavHaskitgarantiacliente.Name = GXCCtl;
         chkavHaskitgarantiacliente.WebTags = "";
         chkavHaskitgarantiacliente.Caption = "";
         AssignProp(sPrefix, false, chkavHaskitgarantiacliente_Internalname, "TitleCaption", chkavHaskitgarantiacliente.Caption, !bGXsfl_12_Refreshing);
         chkavHaskitgarantiacliente.CheckedValue = "false";
         /* End function init_web_controls */
      }

      protected void StartGridControl12( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"DivS\" data-gxgridid=\"12\">") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A351NegCliNomeFamiliar));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A353NegCpjNomFan));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A385NegValorAtualizado, 23, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A362NegAssunto));
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
            GridColumn.AddObjectProperty("Value", lblTag_can_Caption);
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", lblTxtesp01_can_Caption);
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", lblTxtdescartado_Caption);
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
            GridColumn.AddObjectProperty("Value", lblTag_nda_Caption);
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", lblTxtesp01_can_Caption);
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", lblTxt_nda_Caption);
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", lblVisitas_Caption);
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", lblDocumentos_Caption);
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", lblAnalise_Caption);
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", lblAvancar_Caption);
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", lblVoltar_Caption);
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A345NegID.ToString()));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNegID_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A474NegUltNgfSeq), 8, 0, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNegUltNgfSeq_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A479NegUltIteOrdem), 4, 0, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNegUltIteOrdem_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( AV24HasNDA)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkavHasnda.Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV25DesenvStatus));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbavDesenvstatus.Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( AV26HasKitBancoCliente)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkavHaskitbancocliente.Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( AV27HasKitGarantiaCliente)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkavHaskitgarantiacliente.Visible), 5, 0, ".", "")));
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
         edtNegCliNomeFamiliar_Internalname = sPrefix+"NEGCLINOMEFAMILIAR";
         edtNegCpjNomFan_Internalname = sPrefix+"NEGCPJNOMFAN";
         divCardnegociopj_tabletitle_Internalname = sPrefix+"CARDNEGOCIOPJ_TABLETITLE";
         tblCardnegociopj_tabletopinfo_Internalname = sPrefix+"CARDNEGOCIOPJ_TABLETOPINFO";
         edtNegValorAtualizado_Internalname = sPrefix+"NEGVALORATUALIZADO";
         edtNegAssunto_Internalname = sPrefix+"NEGASSUNTO";
         lblTag_can_Internalname = sPrefix+"TAG_CAN";
         lblTxtesp01_can_Internalname = sPrefix+"TXTESP01_CAN";
         lblTxtdescartado_Internalname = sPrefix+"TXTDESCARTADO";
         tblTable_can_Internalname = sPrefix+"TABLE_CAN";
         lblTag_nda_Internalname = sPrefix+"TAG_NDA";
         lblTxtesp02_nda_Internalname = sPrefix+"TXTESP02_NDA";
         lblTxt_nda_Internalname = sPrefix+"TXT_NDA";
         tblTable_nda_Internalname = sPrefix+"TABLE_NDA";
         divCardnegociopj_tablecontent_Internalname = sPrefix+"CARDNEGOCIOPJ_TABLECONTENT";
         lblVisitas_Internalname = sPrefix+"VISITAS";
         lblDocumentos_Internalname = sPrefix+"DOCUMENTOS";
         lblAnalise_Internalname = sPrefix+"ANALISE";
         lblAvancar_Internalname = sPrefix+"AVANCAR";
         lblVoltar_Internalname = sPrefix+"VOLTAR";
         divTablebuttons_Internalname = sPrefix+"TABLEBUTTONS";
         divCardnegociopj_tablecard_Internalname = sPrefix+"CARDNEGOCIOPJ_TABLECARD";
         edtNegID_Internalname = sPrefix+"NEGID";
         edtNegUltNgfSeq_Internalname = sPrefix+"NEGULTNGFSEQ";
         edtNegUltIteOrdem_Internalname = sPrefix+"NEGULTITEORDEM";
         chkavHasnda_Internalname = sPrefix+"vHASNDA";
         cmbavDesenvstatus_Internalname = sPrefix+"vDESENVSTATUS";
         chkavHaskitbancocliente_Internalname = sPrefix+"vHASKITBANCOCLIENTE";
         chkavHaskitgarantiacliente_Internalname = sPrefix+"vHASKITGARANTIACLIENTE";
         tblUnnamedtablecontentfsgrid_Internalname = sPrefix+"UNNAMEDTABLECONTENTFSGRID";
         divMainlayout_Internalname = sPrefix+"MAINLAYOUT";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         edtNegUltIteID_Internalname = sPrefix+"NEGULTITEID";
         Dvelop_confirmpanel_avancar_Internalname = sPrefix+"DVELOP_CONFIRMPANEL_AVANCAR";
         tblTabledvelop_confirmpanel_avancar_Internalname = sPrefix+"TABLEDVELOP_CONFIRMPANEL_AVANCAR";
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
         lblVoltar_Caption = "<i class=\"ImageMenuIcon-right far fa-circle-left\"></i>";
         lblAvancar_Caption = "<i class=\"ImageMenuIcon-right far fa-circle-right\"></i>";
         lblAnalise_Caption = "<i class=\"ImageMenuIcon-right fa-solid fa-check\"></i>";
         lblDocumentos_Caption = "<i class=\"ImageMenuIcon-right fas fa-file-arrow-up\"></i>";
         lblVisitas_Caption = "<i class=\"ImageMenuIcon-right far fa-calendar-plus\"></i>";
         lblTxt_nda_Caption = "NDA Assinado";
         lblTag_nda_Caption = "<i class=\"ImageMenuIcon-left fas fa-file-signature\"></i>";
         lblTxtdescartado_Caption = "Descartado";
         lblTxtesp01_can_Caption = "&nbsp;";
         lblTag_can_Caption = "<i class=\"ImageMenuIcon-left fas fa-xmark\"></i>";
         chkavHaskitgarantiacliente.Caption = "Has Kit Garantia Cliente";
         chkavHaskitgarantiacliente.Enabled = 1;
         chkavHaskitbancocliente.Caption = "Has Kit Banco Cliente";
         chkavHaskitbancocliente.Enabled = 1;
         cmbavDesenvstatus_Jsonclick = "";
         cmbavDesenvstatus.Enabled = 1;
         chkavHasnda.Caption = "Has NDA";
         chkavHasnda.Enabled = 1;
         edtNegUltIteOrdem_Jsonclick = "";
         edtNegUltNgfSeq_Jsonclick = "";
         edtNegID_Jsonclick = "";
         lblVoltar_Visible = 1;
         lblAvancar_Visible = 1;
         lblAnalise_Visible = 1;
         edtNegAssunto_Jsonclick = "";
         edtNegValorAtualizado_Jsonclick = "";
         edtNegCpjNomFan_Jsonclick = "";
         edtNegCliNomeFamiliar_Jsonclick = "";
         divCardnegociopj_tablecontent_Height = 0;
         tblTable_nda_Visible = 1;
         tblTable_can_Visible = 1;
         subGrid_Backcolorstyle = 0;
         edtNegUltIteID_Jsonclick = "";
         edtNegUltIteID_Visible = 1;
         subGrid_Justifycontent = "center";
         subGrid_Flexwrap = "wrap";
         subGrid_Flexdirection = "column";
         subGrid_Class = "FreeStyleGrid";
         Dvelop_confirmpanel_avancar_Confirmtype = "1";
         Dvelop_confirmpanel_avancar_Yesbuttonposition = "left";
         Dvelop_confirmpanel_avancar_Cancelbuttoncaption = "WWP_ConfirmTextCancel";
         Dvelop_confirmpanel_avancar_Nobuttoncaption = "WWP_ConfirmTextNo";
         Dvelop_confirmpanel_avancar_Yesbuttoncaption = "WWP_ConfirmTextYes";
         Dvelop_confirmpanel_avancar_Confirmationtext = "Deseja mesmo avançar para a próxima fase?";
         Dvelop_confirmpanel_avancar_Title = "Avançar";
         chkavHaskitgarantiacliente.Visible = 1;
         chkavHaskitbancocliente.Visible = 1;
         cmbavDesenvstatus.Visible = 1;
         chkavHasnda.Visible = 1;
         edtNegUltIteOrdem_Visible = 1;
         edtNegUltNgfSeq_Visible = 1;
         edtNegID_Visible = 1;
         subGrid_Rows = 0;
         context.GX_msglist.DisplayMode = 1;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'edtNegID_Visible',ctrl:'NEGID',prop:'Visible'},{av:'edtNegUltNgfSeq_Visible',ctrl:'NEGULTNGFSEQ',prop:'Visible'},{av:'edtNegUltIteOrdem_Visible',ctrl:'NEGULTITEORDEM',prop:'Visible'},{av:'chkavHasnda.Visible',ctrl:'vHASNDA',prop:'Visible'},{av:'cmbavDesenvstatus'},{av:'chkavHaskitbancocliente.Visible',ctrl:'vHASKITBANCOCLIENTE',prop:'Visible'},{av:'chkavHaskitgarantiacliente.Visible',ctrl:'vHASKITGARANTIACLIENTE',prop:'Visible'},{av:'AV30Core_wcfuniloportunidadesds_1_negultiteid',fld:'vCORE_WCFUNILOPORTUNIDADESDS_1_NEGULTITEID',pic:''},{av:'sPrefix'},{av:'AV8NegUltIteID',fld:'vNEGULTITEID',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV33Pgmname',fld:'vPGMNAME',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("GRID.LOAD","{handler:'E14512',iparms:[{av:'A345NegID',fld:'NEGID',pic:'',hsh:true},{av:'A479NegUltIteOrdem',fld:'NEGULTITEORDEM',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'AV24HasNDA',fld:'vHASNDA',pic:''},{av:'AV26HasKitBancoCliente',fld:'vHASKITBANCOCLIENTE',pic:''},{av:'AV27HasKitGarantiaCliente',fld:'vHASKITGARANTIACLIENTE',pic:''},{av:'lblAnalise_Visible',ctrl:'ANALISE',prop:'Visible'},{av:'A40000GXC1',fld:'GXC1',pic:'99999999'},{av:'lblAvancar_Visible',ctrl:'AVANCAR',prop:'Visible'},{av:'lblVoltar_Visible',ctrl:'VOLTAR',prop:'Visible'}]}");
         setEventMetadata("'DOVISITAS'","{handler:'E15512',iparms:[{av:'A345NegID',fld:'NEGID',pic:'',hsh:true},{av:'A474NegUltNgfSeq',fld:'NEGULTNGFSEQ',pic:'ZZZZZZZ9',hsh:true}]");
         setEventMetadata("'DOVISITAS'",",oparms:[]}");
         setEventMetadata("'DODOCUMENTOS'","{handler:'E16512',iparms:[{av:'A345NegID',fld:'NEGID',pic:'',hsh:true}]");
         setEventMetadata("'DODOCUMENTOS'",",oparms:[]}");
         setEventMetadata("'DOANALISE'","{handler:'E17512',iparms:[{av:'A479NegUltIteOrdem',fld:'NEGULTITEORDEM',pic:'ZZZ9',hsh:true},{av:'A345NegID',fld:'NEGID',pic:'',hsh:true}]");
         setEventMetadata("'DOANALISE'",",oparms:[]}");
         setEventMetadata("'DOAVANCAR'","{handler:'E21512',iparms:[{av:'A345NegID',fld:'NEGID',pic:'',hsh:true}]");
         setEventMetadata("'DOAVANCAR'",",oparms:[{av:'AV21NegID_Selected',fld:'vNEGID_SELECTED',pic:''}]}");
         setEventMetadata("DVELOP_CONFIRMPANEL_AVANCAR.CLOSE","{handler:'E11512',iparms:[{av:'Dvelop_confirmpanel_avancar_Result',ctrl:'DVELOP_CONFIRMPANEL_AVANCAR',prop:'Result'},{av:'AV21NegID_Selected',fld:'vNEGID_SELECTED',pic:''}]");
         setEventMetadata("DVELOP_CONFIRMPANEL_AVANCAR.CLOSE",",oparms:[]}");
         setEventMetadata("'DOVOLTAR'","{handler:'E18512',iparms:[{av:'A345NegID',fld:'NEGID',pic:'',hsh:true}]");
         setEventMetadata("'DOVOLTAR'",",oparms:[]}");
         setEventMetadata("'DOTAG_NDA'","{handler:'E20512',iparms:[]");
         setEventMetadata("'DOTAG_NDA'",",oparms:[]}");
         setEventMetadata("'DOTAG_CAN'","{handler:'E19512',iparms:[]");
         setEventMetadata("'DOTAG_CAN'",",oparms:[]}");
         setEventMetadata("GRID_FIRSTPAGE","{handler:'subgrid_firstpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'edtNegID_Visible',ctrl:'NEGID',prop:'Visible'},{av:'edtNegUltNgfSeq_Visible',ctrl:'NEGULTNGFSEQ',prop:'Visible'},{av:'edtNegUltIteOrdem_Visible',ctrl:'NEGULTITEORDEM',prop:'Visible'},{av:'chkavHasnda.Visible',ctrl:'vHASNDA',prop:'Visible'},{av:'cmbavDesenvstatus'},{av:'chkavHaskitbancocliente.Visible',ctrl:'vHASKITBANCOCLIENTE',prop:'Visible'},{av:'chkavHaskitgarantiacliente.Visible',ctrl:'vHASKITGARANTIACLIENTE',prop:'Visible'},{av:'AV30Core_wcfuniloportunidadesds_1_negultiteid',fld:'vCORE_WCFUNILOPORTUNIDADESDS_1_NEGULTITEID',pic:''},{av:'sPrefix'},{av:'AV8NegUltIteID',fld:'vNEGULTITEID',pic:''},{av:'AV33Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]");
         setEventMetadata("GRID_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID_PREVPAGE","{handler:'subgrid_previouspage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'edtNegID_Visible',ctrl:'NEGID',prop:'Visible'},{av:'edtNegUltNgfSeq_Visible',ctrl:'NEGULTNGFSEQ',prop:'Visible'},{av:'edtNegUltIteOrdem_Visible',ctrl:'NEGULTITEORDEM',prop:'Visible'},{av:'chkavHasnda.Visible',ctrl:'vHASNDA',prop:'Visible'},{av:'cmbavDesenvstatus'},{av:'chkavHaskitbancocliente.Visible',ctrl:'vHASKITBANCOCLIENTE',prop:'Visible'},{av:'chkavHaskitgarantiacliente.Visible',ctrl:'vHASKITGARANTIACLIENTE',prop:'Visible'},{av:'AV30Core_wcfuniloportunidadesds_1_negultiteid',fld:'vCORE_WCFUNILOPORTUNIDADESDS_1_NEGULTITEID',pic:''},{av:'sPrefix'},{av:'AV8NegUltIteID',fld:'vNEGULTITEID',pic:''},{av:'AV33Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]");
         setEventMetadata("GRID_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID_NEXTPAGE","{handler:'subgrid_nextpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'edtNegID_Visible',ctrl:'NEGID',prop:'Visible'},{av:'edtNegUltNgfSeq_Visible',ctrl:'NEGULTNGFSEQ',prop:'Visible'},{av:'edtNegUltIteOrdem_Visible',ctrl:'NEGULTITEORDEM',prop:'Visible'},{av:'chkavHasnda.Visible',ctrl:'vHASNDA',prop:'Visible'},{av:'cmbavDesenvstatus'},{av:'chkavHaskitbancocliente.Visible',ctrl:'vHASKITBANCOCLIENTE',prop:'Visible'},{av:'chkavHaskitgarantiacliente.Visible',ctrl:'vHASKITGARANTIACLIENTE',prop:'Visible'},{av:'AV30Core_wcfuniloportunidadesds_1_negultiteid',fld:'vCORE_WCFUNILOPORTUNIDADESDS_1_NEGULTITEID',pic:''},{av:'sPrefix'},{av:'AV8NegUltIteID',fld:'vNEGULTITEID',pic:''},{av:'AV33Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]");
         setEventMetadata("GRID_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID_LASTPAGE","{handler:'subgrid_lastpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'edtNegID_Visible',ctrl:'NEGID',prop:'Visible'},{av:'edtNegUltNgfSeq_Visible',ctrl:'NEGULTNGFSEQ',prop:'Visible'},{av:'edtNegUltIteOrdem_Visible',ctrl:'NEGULTITEORDEM',prop:'Visible'},{av:'chkavHasnda.Visible',ctrl:'vHASNDA',prop:'Visible'},{av:'cmbavDesenvstatus'},{av:'chkavHaskitbancocliente.Visible',ctrl:'vHASKITBANCOCLIENTE',prop:'Visible'},{av:'chkavHaskitgarantiacliente.Visible',ctrl:'vHASKITGARANTIACLIENTE',prop:'Visible'},{av:'AV30Core_wcfuniloportunidadesds_1_negultiteid',fld:'vCORE_WCFUNILOPORTUNIDADESDS_1_NEGULTITEID',pic:''},{av:'sPrefix'},{av:'AV8NegUltIteID',fld:'vNEGULTITEID',pic:''},{av:'AV33Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]");
         setEventMetadata("GRID_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALIDV_DESENVSTATUS","{handler:'Validv_Desenvstatus',iparms:[]");
         setEventMetadata("VALIDV_DESENVSTATUS",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Haskitgarantiacliente',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
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
         wcpOAV8NegUltIteID = Guid.Empty;
         Dvelop_confirmpanel_avancar_Result = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV33Pgmname = "";
         AV30Core_wcfuniloportunidadesds_1_negultiteid = Guid.Empty;
         scmdbuf = "";
         H00513_A40000GXC1 = new int[1] ;
         H00513_n40000GXC1 = new bool[] {false} ;
         H00515_A40001GXC2 = new int[1] ;
         H00515_n40001GXC2 = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV21NegID_Selected = Guid.Empty;
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         A420NegUltIteID = Guid.Empty;
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A351NegCliNomeFamiliar = "";
         A353NegCpjNomFan = "";
         A362NegAssunto = "";
         A345NegID = Guid.Empty;
         AV25DesenvStatus = "";
         GXDecQS = "";
         H00518_A348NegInsDataHora = new DateTime[] {DateTime.MinValue} ;
         H00518_A420NegUltIteID = new Guid[] {Guid.Empty} ;
         H00518_A479NegUltIteOrdem = new short[1] ;
         H00518_A474NegUltNgfSeq = new int[1] ;
         H00518_A345NegID = new Guid[] {Guid.Empty} ;
         H00518_A362NegAssunto = new string[] {""} ;
         H00518_A385NegValorAtualizado = new decimal[1] ;
         H00518_A353NegCpjNomFan = new string[] {""} ;
         H00518_A351NegCliNomeFamiliar = new string[] {""} ;
         H00518_A40000GXC1 = new int[1] ;
         H00518_n40000GXC1 = new bool[] {false} ;
         H00518_A40001GXC2 = new int[1] ;
         H00518_n40001GXC2 = new bool[] {false} ;
         A348NegInsDataHora = (DateTime)(DateTime.MinValue);
         H005111_AGRID_nRecordCount = new long[1] ;
         H005113_A40000GXC1 = new int[1] ;
         H005113_n40000GXC1 = new bool[] {false} ;
         H005115_A40001GXC2 = new int[1] ;
         H005115_n40001GXC2 = new bool[] {false} ;
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GridRow = new GXWebRow();
         AV20Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV22Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV14Session = context.GetSession();
         AV12GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV10TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV9HTTPRequest = new GxHttpRequest( context);
         AV11TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         ucDvelop_confirmpanel_avancar = new GXUserControl();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV8NegUltIteID = "";
         subGrid_Linesclass = "";
         GridColumn = new GXWebColumn();
         ROClassString = "";
         lblTag_can_Jsonclick = "";
         lblTxtesp01_can_Jsonclick = "";
         lblTxtdescartado_Jsonclick = "";
         lblTag_nda_Jsonclick = "";
         lblTxtesp02_nda_Jsonclick = "";
         lblTxt_nda_Jsonclick = "";
         lblVisitas_Jsonclick = "";
         lblDocumentos_Jsonclick = "";
         lblAnalise_Jsonclick = "";
         lblAvancar_Jsonclick = "";
         lblVoltar_Jsonclick = "";
         TempTags = "";
         GXCCtl = "";
         subGrid_Header = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.wcfuniloportunidades__default(),
            new Object[][] {
                new Object[] {
               H00513_A40000GXC1, H00513_n40000GXC1
               }
               , new Object[] {
               H00515_A40001GXC2, H00515_n40001GXC2
               }
               , new Object[] {
               H00518_A348NegInsDataHora, H00518_A420NegUltIteID, H00518_A479NegUltIteOrdem, H00518_A474NegUltNgfSeq, H00518_A345NegID, H00518_A362NegAssunto, H00518_A385NegValorAtualizado, H00518_A353NegCpjNomFan, H00518_A351NegCliNomeFamiliar, H00518_A40000GXC1,
               H00518_n40000GXC1, H00518_A40001GXC2, H00518_n40001GXC2
               }
               , new Object[] {
               H005111_AGRID_nRecordCount
               }
               , new Object[] {
               H005113_A40000GXC1, H005113_n40000GXC1
               }
               , new Object[] {
               H005115_A40001GXC2, H005115_n40001GXC2
               }
            }
         );
         AV33Pgmname = "core.wcFunilOportunidades";
         /* GeneXus formulas. */
         AV33Pgmname = "core.wcFunilOportunidades";
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short initialized ;
      private short nGXWrapped ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short A479NegUltIteOrdem ;
      private short nDonePA ;
      private short subGrid_Backcolorstyle ;
      private short gxcookieaux ;
      private short subGrid_Backstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int edtNegID_Visible ;
      private int edtNegUltNgfSeq_Visible ;
      private int edtNegUltIteOrdem_Visible ;
      private int subGrid_Rows ;
      private int nRC_GXsfl_12 ;
      private int nGXsfl_12_idx=1 ;
      private int A40000GXC1 ;
      private int A40001GXC2 ;
      private int edtNegUltIteID_Visible ;
      private int A474NegUltNgfSeq ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int divCardnegociopj_tablecontent_Height ;
      private int lblAnalise_Visible ;
      private int lblAvancar_Visible ;
      private int lblVoltar_Visible ;
      private int AV31GXV1 ;
      private int AV32GXV2 ;
      private int tblTable_can_Visible ;
      private int tblTable_nda_Visible ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private decimal A385NegValorAtualizado ;
      private string Dvelop_confirmpanel_avancar_Result ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_12_idx="0001" ;
      private string edtNegID_Internalname ;
      private string edtNegUltNgfSeq_Internalname ;
      private string edtNegUltIteOrdem_Internalname ;
      private string chkavHasnda_Internalname ;
      private string cmbavDesenvstatus_Internalname ;
      private string chkavHaskitbancocliente_Internalname ;
      private string chkavHaskitgarantiacliente_Internalname ;
      private string AV33Pgmname ;
      private string scmdbuf ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string Dvelop_confirmpanel_avancar_Title ;
      private string Dvelop_confirmpanel_avancar_Confirmationtext ;
      private string Dvelop_confirmpanel_avancar_Yesbuttoncaption ;
      private string Dvelop_confirmpanel_avancar_Nobuttoncaption ;
      private string Dvelop_confirmpanel_avancar_Cancelbuttoncaption ;
      private string Dvelop_confirmpanel_avancar_Yesbuttonposition ;
      private string Dvelop_confirmpanel_avancar_Confirmtype ;
      private string subGrid_Class ;
      private string subGrid_Flexdirection ;
      private string subGrid_Flexwrap ;
      private string subGrid_Justifycontent ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtNegUltIteID_Internalname ;
      private string edtNegUltIteID_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtNegCliNomeFamiliar_Internalname ;
      private string edtNegCpjNomFan_Internalname ;
      private string edtNegValorAtualizado_Internalname ;
      private string edtNegAssunto_Internalname ;
      private string GXDecQS ;
      private string divCardnegociopj_tablecontent_Internalname ;
      private string tblTable_can_Internalname ;
      private string tblTable_nda_Internalname ;
      private string tblTabledvelop_confirmpanel_avancar_Internalname ;
      private string Dvelop_confirmpanel_avancar_Internalname ;
      private string sCtrlAV8NegUltIteID ;
      private string lblTag_can_Internalname ;
      private string lblTxtesp01_can_Internalname ;
      private string lblTxtdescartado_Internalname ;
      private string lblTag_nda_Internalname ;
      private string lblTxtesp02_nda_Internalname ;
      private string lblTxt_nda_Internalname ;
      private string lblVisitas_Internalname ;
      private string lblDocumentos_Internalname ;
      private string lblAnalise_Internalname ;
      private string lblAvancar_Internalname ;
      private string lblVoltar_Internalname ;
      private string sGXsfl_12_fel_idx="0001" ;
      private string subGrid_Linesclass ;
      private string divMainlayout_Internalname ;
      private string divCardnegociopj_tablecard_Internalname ;
      private string tblCardnegociopj_tabletopinfo_Internalname ;
      private string divCardnegociopj_tabletitle_Internalname ;
      private string ROClassString ;
      private string edtNegCliNomeFamiliar_Jsonclick ;
      private string edtNegCpjNomFan_Jsonclick ;
      private string edtNegValorAtualizado_Jsonclick ;
      private string edtNegAssunto_Jsonclick ;
      private string lblTag_can_Jsonclick ;
      private string lblTxtesp01_can_Jsonclick ;
      private string lblTxtdescartado_Jsonclick ;
      private string lblTag_nda_Jsonclick ;
      private string lblTxtesp02_nda_Jsonclick ;
      private string lblTxt_nda_Jsonclick ;
      private string divTablebuttons_Internalname ;
      private string lblVisitas_Jsonclick ;
      private string lblDocumentos_Jsonclick ;
      private string lblAnalise_Jsonclick ;
      private string lblAvancar_Jsonclick ;
      private string lblVoltar_Jsonclick ;
      private string tblUnnamedtablecontentfsgrid_Internalname ;
      private string edtNegID_Jsonclick ;
      private string edtNegUltNgfSeq_Jsonclick ;
      private string edtNegUltIteOrdem_Jsonclick ;
      private string TempTags ;
      private string GXCCtl ;
      private string cmbavDesenvstatus_Jsonclick ;
      private string subGrid_Header ;
      private string lblTag_can_Caption ;
      private string lblTxtesp01_can_Caption ;
      private string lblTxtdescartado_Caption ;
      private string lblTag_nda_Caption ;
      private string lblTxt_nda_Caption ;
      private string lblVisitas_Caption ;
      private string lblDocumentos_Caption ;
      private string lblAnalise_Caption ;
      private string lblAvancar_Caption ;
      private string lblVoltar_Caption ;
      private DateTime A348NegInsDataHora ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool bGXsfl_12_Refreshing=false ;
      private bool n40000GXC1 ;
      private bool n40001GXC2 ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool AV24HasNDA ;
      private bool AV26HasKitBancoCliente ;
      private bool AV27HasKitGarantiaCliente ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool AV29HasPropComerCliente ;
      private bool AV28TempBoolean ;
      private bool GXt_boolean1 ;
      private bool GXt_boolean2 ;
      private bool GXt_boolean3 ;
      private bool GXt_boolean4 ;
      private bool GXt_boolean5 ;
      private bool GXt_boolean6 ;
      private bool GXt_boolean7 ;
      private bool GXt_boolean8 ;
      private bool GXt_boolean9 ;
      private bool AV23HasError ;
      private string A351NegCliNomeFamiliar ;
      private string A353NegCpjNomFan ;
      private string A362NegAssunto ;
      private string AV25DesenvStatus ;
      private Guid AV8NegUltIteID ;
      private Guid wcpOAV8NegUltIteID ;
      private Guid AV30Core_wcfuniloportunidadesds_1_negultiteid ;
      private Guid AV21NegID_Selected ;
      private Guid A420NegUltIteID ;
      private Guid A345NegID ;
      private IGxSession AV14Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDvelop_confirmpanel_avancar ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkavHasnda ;
      private GXCombobox cmbavDesenvstatus ;
      private GXCheckbox chkavHaskitbancocliente ;
      private GXCheckbox chkavHaskitgarantiacliente ;
      private IDataStoreProvider pr_default ;
      private int[] H00513_A40000GXC1 ;
      private bool[] H00513_n40000GXC1 ;
      private int[] H00515_A40001GXC2 ;
      private bool[] H00515_n40001GXC2 ;
      private DateTime[] H00518_A348NegInsDataHora ;
      private Guid[] H00518_A420NegUltIteID ;
      private short[] H00518_A479NegUltIteOrdem ;
      private int[] H00518_A474NegUltNgfSeq ;
      private Guid[] H00518_A345NegID ;
      private string[] H00518_A362NegAssunto ;
      private decimal[] H00518_A385NegValorAtualizado ;
      private string[] H00518_A353NegCpjNomFan ;
      private string[] H00518_A351NegCliNomeFamiliar ;
      private int[] H00518_A40000GXC1 ;
      private bool[] H00518_n40000GXC1 ;
      private int[] H00518_A40001GXC2 ;
      private bool[] H00518_n40001GXC2 ;
      private long[] H005111_AGRID_nRecordCount ;
      private int[] H005113_A40000GXC1 ;
      private bool[] H005113_n40000GXC1 ;
      private int[] H005115_A40001GXC2 ;
      private bool[] H005115_n40001GXC2 ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV9HTTPRequest ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV20Messages ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV12GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV10TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV11TrnContextAtt ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Utils.SdtMessages_Message AV22Message ;
   }

   public class wcfuniloportunidades__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
         ,new ForEachCursor(def[5])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH00513;
          prmH00513 = new Object[] {
          };
          Object[] prmH00515;
          prmH00515 = new Object[] {
          };
          Object[] prmH00518;
          prmH00518 = new Object[] {
          new ParDef("AV30Core_wcfuniloportunidadesds_1_negultiteid",GXType.UniqueIdentifier,36,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH005111;
          prmH005111 = new Object[] {
          new ParDef("AV30Core_wcfuniloportunidadesds_1_negultiteid",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmH005113;
          prmH005113 = new Object[] {
          };
          Object[] prmH005115;
          prmH005115 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H00513", "SELECT COALESCE( T1.GXC1, 0) AS GXC1 FROM (SELECT MAX(IteOrdem) AS GXC1 FROM tb_Iteracao ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00513,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00515", "SELECT COALESCE( T1.GXC2, 0) AS GXC2 FROM (SELECT MIN(IteOrdem) AS GXC2 FROM tb_Iteracao ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00515,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00518", "SELECT T1.NegInsDataHora, T1.NegUltIteID, T1.NegUltIteOrdem, T1.NegUltNgfSeq, T1.NegID, T1.NegAssunto, T1.NegValorAtualizado, T1.NegCpjNomFan, T1.NegCliNomeFamiliar, COALESCE( T2.GXC1, 0) AS GXC1, COALESCE( T3.GXC2, 0) AS GXC2 FROM tb_negociopj T1,  (SELECT MAX(IteOrdem) AS GXC1 FROM tb_Iteracao ) T2,  (SELECT MIN(IteOrdem) AS GXC2 FROM tb_Iteracao ) T3 WHERE T1.NegUltIteID = :AV30Core_wcfuniloportunidadesds_1_negultiteid ORDER BY T1.NegUltIteID, T1.NegInsDataHora, T1.NegID  OFFSET :GXPagingFrom2 LIMIT CASE WHEN :GXPagingTo2 > 0 THEN :GXPagingTo2 ELSE 1e9 END",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00518,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H005111", "SELECT COUNT(*) FROM tb_negociopj T1,  (SELECT MAX(IteOrdem) AS GXC1 FROM tb_Iteracao ) T2,  (SELECT MIN(IteOrdem) AS GXC2 FROM tb_Iteracao ) T3 WHERE T1.NegUltIteID = :AV30Core_wcfuniloportunidadesds_1_negultiteid ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005111,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H005113", "SELECT COALESCE( T1.GXC1, 0) AS GXC1 FROM (SELECT MAX(IteOrdem) AS GXC1 FROM tb_Iteracao ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005113,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H005115", "SELECT COALESCE( T1.GXC2, 0) AS GXC2 FROM (SELECT MIN(IteOrdem) AS GXC2 FROM tb_Iteracao ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005115,1, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 2 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1, true);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((Guid[]) buf[4])[0] = rslt.getGuid(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((int[]) buf[9])[0] = rslt.getInt(10);
                ((bool[]) buf[10])[0] = rslt.wasNull(10);
                ((int[]) buf[11])[0] = rslt.getInt(11);
                ((bool[]) buf[12])[0] = rslt.wasNull(11);
                return;
             case 3 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
       }
    }

 }

}
