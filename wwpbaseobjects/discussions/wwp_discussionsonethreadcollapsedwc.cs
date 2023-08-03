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
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs.wwpbaseobjects.discussions {
   public class wwp_discussionsonethreadcollapsedwc : GXWebComponent
   {
      public wwp_discussionsonethreadcollapsedwc( )
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

      public wwp_discussionsonethreadcollapsedwc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref long aP0_WWPDiscussionMessageThreadId )
      {
         this.AV11WWPDiscussionMessageThreadId = aP0_WWPDiscussionMessageThreadId;
         executePrivate();
         aP0_WWPDiscussionMessageThreadId=this.AV11WWPDiscussionMessageThreadId;
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
               gxfirstwebparm = GetFirstPar( "WWPDiscussionMessageThreadId");
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
                  AV11WWPDiscussionMessageThreadId = (long)(Math.Round(NumberUtil.Val( GetPar( "WWPDiscussionMessageThreadId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV11WWPDiscussionMessageThreadId", StringUtil.LTrimStr( (decimal)(AV11WWPDiscussionMessageThreadId), 10, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(long)AV11WWPDiscussionMessageThreadId});
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
                  gxfirstwebparm = GetFirstPar( "WWPDiscussionMessageThreadId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "WWPDiscussionMessageThreadId");
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
            PA2N2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               edtavHiddenanswers_Enabled = 0;
               AssignProp(sPrefix, false, edtavHiddenanswers_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavHiddenanswers_Enabled), 5, 0), true);
               edtavHiddenanswerslaston_Enabled = 0;
               AssignProp(sPrefix, false, edtavHiddenanswerslaston_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavHiddenanswerslaston_Enabled), 5, 0), true);
               /* Using cursor H002N3 */
               pr_default.execute(0, new Object[] {AV11WWPDiscussionMessageThreadId});
               if ( (pr_default.getStatus(0) != 101) )
               {
                  A40000GXC1 = H002N3_A40000GXC1[0];
                  n40000GXC1 = H002N3_n40000GXC1[0];
               }
               else
               {
                  A40000GXC1 = 0;
                  n40000GXC1 = false;
                  AssignAttri(sPrefix, false, "A40000GXC1", StringUtil.LTrimStr( (decimal)(A40000GXC1), 9, 0));
               }
               pr_default.close(0);
               WS2N2( ) ;
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
            context.SendWebValue( "Discussions of one thread collapsed") ;
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
               GXEncryptionTmp = "wwpbaseobjects.discussions.wwp_discussionsonethreadcollapsedwc.aspx"+UrlEncode(StringUtil.LTrimStr(AV11WWPDiscussionMessageThreadId,10,0));
               context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.discussions.wwp_discussionsonethreadcollapsedwc.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV11WWPDiscussionMessageThreadId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV11WWPDiscussionMessageThreadId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPDISCUSSIONMESSAGETHREADID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11WWPDiscussionMessageThreadId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPDISCUSSIONMESSAGEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A137WWPDiscussionMessageId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPDISCUSSIONMESSAGETHREADID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A136WWPDiscussionMessageThreadId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"WWPDISCUSSIONMESSAGEDATE", context.localUtil.TToC( A140WWPDiscussionMessageDate, 10, 8, 0, 0, "/", ":", " "));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vNOTIFICATIONINFO", AV13NotificationInfo);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vNOTIFICATIONINFO", AV13NotificationInfo);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GXC1", StringUtil.LTrim( StringUtil.NToC( (decimal)(A40000GXC1), 9, 0, ",", "")));
      }

      protected void RenderHtmlCloseForm2N2( )
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
         return "WWPBaseObjects.Discussions.WWP_DiscussionsOneThreadCollapsedWC" ;
      }

      public override string GetPgmdesc( )
      {
         return "Discussions of one thread collapsed" ;
      }

      protected void WB2N0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wwpbaseobjects.discussions.wwp_discussionsonethreadcollapsedwc.aspx");
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
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMain", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divHiddenanswerscell_Internalname, 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            wb_table1_12_2N2( true) ;
         }
         else
         {
            wb_table1_12_2N2( false) ;
         }
         return  ;
      }

      protected void wb_table1_12_2N2e( bool wbgen )
      {
         if ( wbgen )
         {
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
         }
         wbLoad = true;
      }

      protected void START2N2( )
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
               Form.Meta.addItem("description", "Discussions of one thread collapsed", 0) ;
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
               STRUP2N0( ) ;
            }
         }
      }

      protected void WS2N2( )
      {
         START2N2( ) ;
         EVT2N2( ) ;
      }

      protected void EVT2N2( )
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
                                 STRUP2N0( ) ;
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
                                 STRUP2N0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E112N2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ONMESSAGE_GX1") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2N0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Onmessage_gx1 */
                                    E122N2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2N0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E132N2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2N0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E142N2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2N0( ) ;
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
                                 STRUP2N0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavHiddenanswers_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ONMESSAGE_GX1") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2N0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Onmessage_gx1 */
                                    E122N2 ();
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

      protected void WE2N2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm2N2( ) ;
            }
         }
      }

      protected void PA2N2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wwpbaseobjects.discussions.wwp_discussionsonethreadcollapsedwc.aspx")), "wwpbaseobjects.discussions.wwp_discussionsonethreadcollapsedwc.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wwpbaseobjects.discussions.wwp_discussionsonethreadcollapsedwc.aspx")))) ;
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
                     gxfirstwebparm = GetFirstPar( "WWPDiscussionMessageThreadId");
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
               GX_FocusControl = edtavHiddenanswers_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
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
         RF2N2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavHiddenanswers_Enabled = 0;
         AssignProp(sPrefix, false, edtavHiddenanswers_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavHiddenanswers_Enabled), 5, 0), true);
         edtavHiddenanswerslaston_Enabled = 0;
         AssignProp(sPrefix, false, edtavHiddenanswerslaston_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavHiddenanswerslaston_Enabled), 5, 0), true);
      }

      protected void RF2N2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E132N2 ();
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E142N2 ();
            WB2N0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes2N2( )
      {
      }

      protected void before_start_formulas( )
      {
         edtavHiddenanswers_Enabled = 0;
         AssignProp(sPrefix, false, edtavHiddenanswers_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavHiddenanswers_Enabled), 5, 0), true);
         edtavHiddenanswerslaston_Enabled = 0;
         AssignProp(sPrefix, false, edtavHiddenanswerslaston_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavHiddenanswerslaston_Enabled), 5, 0), true);
         /* Using cursor H002N5 */
         pr_default.execute(1, new Object[] {AV11WWPDiscussionMessageThreadId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            A40000GXC1 = H002N5_A40000GXC1[0];
            n40000GXC1 = H002N5_n40000GXC1[0];
         }
         else
         {
            A40000GXC1 = 0;
            n40000GXC1 = false;
            AssignAttri(sPrefix, false, "A40000GXC1", StringUtil.LTrimStr( (decimal)(A40000GXC1), 9, 0));
         }
         pr_default.close(1);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2N0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E112N2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vNOTIFICATIONINFO"), AV13NotificationInfo);
            /* Read saved values. */
            wcpOAV11WWPDiscussionMessageThreadId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV11WWPDiscussionMessageThreadId"), ",", "."), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            AV7HiddenAnswers = cgiGet( edtavHiddenanswers_Internalname);
            AssignAttri(sPrefix, false, "AV7HiddenAnswers", AV7HiddenAnswers);
            AV8HiddenAnswersLastOn = cgiGet( edtavHiddenanswerslaston_Internalname);
            AssignAttri(sPrefix, false, "AV8HiddenAnswersLastOn", AV8HiddenAnswersLastOn);
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
         E112N2 ();
         if (returnInSub) return;
      }

      protected void E112N2( )
      {
         /* Start Routine */
         returnInSub = false;
      }

      protected void E122N2( )
      {
         /* Onmessage_gx1 Routine */
         returnInSub = false;
         if ( StringUtil.StartsWith( AV13NotificationInfo.gxTpr_Id, "WebNotification#") )
         {
            context.DoAjaxRefreshCmp(sPrefix);
         }
      }

      protected void E132N2( )
      {
         /* Refresh Routine */
         returnInSub = false;
         /* Using cursor H002N7 */
         pr_default.execute(2, new Object[] {AV11WWPDiscussionMessageThreadId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            A40000GXC1 = H002N7_A40000GXC1[0];
            n40000GXC1 = H002N7_n40000GXC1[0];
         }
         else
         {
            A40000GXC1 = 0;
            n40000GXC1 = false;
            AssignAttri(sPrefix, false, "A40000GXC1", StringUtil.LTrimStr( (decimal)(A40000GXC1), 9, 0));
         }
         pr_default.close(2);
         AV10HiddenAnswersCount = (short)(A40000GXC1);
         /* Using cursor H002N8 */
         pr_default.execute(3, new Object[] {AV11WWPDiscussionMessageThreadId});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A136WWPDiscussionMessageThreadId = H002N8_A136WWPDiscussionMessageThreadId[0];
            n136WWPDiscussionMessageThreadId = H002N8_n136WWPDiscussionMessageThreadId[0];
            A140WWPDiscussionMessageDate = H002N8_A140WWPDiscussionMessageDate[0];
            A137WWPDiscussionMessageId = H002N8_A137WWPDiscussionMessageId[0];
            AV9HiddenAnswersLastOnDate = A140WWPDiscussionMessageDate;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(3);
         }
         pr_default.close(3);
         if ( AV10HiddenAnswersCount > 0 )
         {
            AV8HiddenAnswersLastOn = StringUtil.Format( "Last on %1", context.localUtil.Format( AV9HiddenAnswersLastOnDate, "99/99/99 99:99"), "", "", "", "", "", "", "", "");
            AssignAttri(sPrefix, false, "AV8HiddenAnswersLastOn", AV8HiddenAnswersLastOn);
            if ( AV10HiddenAnswersCount == 1 )
            {
               AV7HiddenAnswers = "1 answer";
               AssignAttri(sPrefix, false, "AV7HiddenAnswers", AV7HiddenAnswers);
            }
            else
            {
               AV7HiddenAnswers = StringUtil.Format( "%1 answers", StringUtil.Trim( StringUtil.Str( (decimal)(AV10HiddenAnswersCount), 4, 0)), "", "", "", "", "", "", "", "");
               AssignAttri(sPrefix, false, "AV7HiddenAnswers", AV7HiddenAnswers);
            }
            edtavHiddenanswers_Class = "AttributeDiscussionTag";
            AssignProp(sPrefix, false, edtavHiddenanswers_Internalname, "Class", edtavHiddenanswers_Class, true);
         }
         else
         {
            edtavHiddenanswerslaston_Visible = 0;
            AssignProp(sPrefix, false, edtavHiddenanswerslaston_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavHiddenanswerslaston_Visible), 5, 0), true);
            AV7HiddenAnswers = "No answers";
            AssignAttri(sPrefix, false, "AV7HiddenAnswers", AV7HiddenAnswers);
            edtavHiddenanswers_Class = "AttributeDiscussionTagGray";
            AssignProp(sPrefix, false, edtavHiddenanswers_Internalname, "Class", edtavHiddenanswers_Class, true);
         }
         /*  Sending Event outputs  */
      }

      protected void nextLoad( )
      {
      }

      protected void E142N2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table1_12_2N2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedhiddenanswers_Internalname, tblTablemergedhiddenanswers_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavHiddenanswers_Internalname, "Hidden Answers", "gx-form-item AttributeDiscussionTagLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavHiddenanswers_Internalname, AV7HiddenAnswers, StringUtil.RTrim( context.localUtil.Format( AV7HiddenAnswers, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,16);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavHiddenanswers_Jsonclick, 0, edtavHiddenanswers_Class, "", "", "", "", 1, edtavHiddenanswers_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WWPBaseObjects\\Discussions\\WWP_DiscussionsOneThreadCollapsedWC.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavHiddenanswerslaston_Internalname, "Hidden Answers Last On", "gx-form-item AttributeDiscussionDateLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'" + sPrefix + "',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavHiddenanswerslaston_Internalname, AV8HiddenAnswersLastOn, StringUtil.RTrim( context.localUtil.Format( AV8HiddenAnswersLastOn, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,19);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavHiddenanswerslaston_Jsonclick, 0, "AttributeDiscussionDate", "", "", "", "", edtavHiddenanswerslaston_Visible, edtavHiddenanswerslaston_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WWPBaseObjects\\Discussions\\WWP_DiscussionsOneThreadCollapsedWC.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_12_2N2e( true) ;
         }
         else
         {
            wb_table1_12_2N2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV11WWPDiscussionMessageThreadId = Convert.ToInt64(getParm(obj,0));
         AssignAttri(sPrefix, false, "AV11WWPDiscussionMessageThreadId", StringUtil.LTrimStr( (decimal)(AV11WWPDiscussionMessageThreadId), 10, 0));
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
         PA2N2( ) ;
         WS2N2( ) ;
         WE2N2( ) ;
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
         sCtrlAV11WWPDiscussionMessageThreadId = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA2N2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wwpbaseobjects\\discussions\\wwp_discussionsonethreadcollapsedwc", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA2N2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV11WWPDiscussionMessageThreadId = Convert.ToInt64(getParm(obj,2));
            AssignAttri(sPrefix, false, "AV11WWPDiscussionMessageThreadId", StringUtil.LTrimStr( (decimal)(AV11WWPDiscussionMessageThreadId), 10, 0));
         }
         wcpOAV11WWPDiscussionMessageThreadId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV11WWPDiscussionMessageThreadId"), ",", "."), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( AV11WWPDiscussionMessageThreadId != wcpOAV11WWPDiscussionMessageThreadId ) ) )
         {
            setjustcreated();
         }
         wcpOAV11WWPDiscussionMessageThreadId = AV11WWPDiscussionMessageThreadId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV11WWPDiscussionMessageThreadId = cgiGet( sPrefix+"AV11WWPDiscussionMessageThreadId_CTRL");
         if ( StringUtil.Len( sCtrlAV11WWPDiscussionMessageThreadId) > 0 )
         {
            AV11WWPDiscussionMessageThreadId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV11WWPDiscussionMessageThreadId), ",", "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV11WWPDiscussionMessageThreadId", StringUtil.LTrimStr( (decimal)(AV11WWPDiscussionMessageThreadId), 10, 0));
         }
         else
         {
            AV11WWPDiscussionMessageThreadId = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV11WWPDiscussionMessageThreadId_PARM"), ",", "."), 18, MidpointRounding.ToEven));
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
         PA2N2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS2N2( ) ;
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
         WS2N2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV11WWPDiscussionMessageThreadId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11WWPDiscussionMessageThreadId), 10, 0, ",", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV11WWPDiscussionMessageThreadId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV11WWPDiscussionMessageThreadId_CTRL", StringUtil.RTrim( sCtrlAV11WWPDiscussionMessageThreadId));
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
         WE2N2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2023828115413", true, true);
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
            context.AddJavascriptSource("wwpbaseobjects/discussions/wwp_discussionsonethreadcollapsedwc.js", "?2023828115414", false, true);
         }
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtavHiddenanswers_Internalname = sPrefix+"vHIDDENANSWERS";
         edtavHiddenanswerslaston_Internalname = sPrefix+"vHIDDENANSWERSLASTON";
         tblTablemergedhiddenanswers_Internalname = sPrefix+"TABLEMERGEDHIDDENANSWERS";
         divHiddenanswerscell_Internalname = sPrefix+"HIDDENANSWERSCELL";
         divTablecontent_Internalname = sPrefix+"TABLECONTENT";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
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
         edtavHiddenanswerslaston_Jsonclick = "";
         edtavHiddenanswerslaston_Enabled = 1;
         edtavHiddenanswers_Jsonclick = "";
         edtavHiddenanswers_Enabled = 1;
         edtavHiddenanswerslaston_Visible = 1;
         edtavHiddenanswers_Class = "AttributeDiscussionTag";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV11WWPDiscussionMessageThreadId',fld:'vWWPDISCUSSIONMESSAGETHREADID',pic:'ZZZZZZZZZ9'},{av:'A137WWPDiscussionMessageId',fld:'WWPDISCUSSIONMESSAGEID',pic:'ZZZZZZZZZ9'},{av:'A136WWPDiscussionMessageThreadId',fld:'WWPDISCUSSIONMESSAGETHREADID',pic:'ZZZZZZZZZ9'},{av:'A140WWPDiscussionMessageDate',fld:'WWPDISCUSSIONMESSAGEDATE',pic:'99/99/99 99:99'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'A40000GXC1',fld:'GXC1',pic:'999999999'},{av:'AV8HiddenAnswersLastOn',fld:'vHIDDENANSWERSLASTON',pic:''},{av:'edtavHiddenanswerslaston_Visible',ctrl:'vHIDDENANSWERSLASTON',prop:'Visible'},{av:'AV7HiddenAnswers',fld:'vHIDDENANSWERS',pic:''},{av:'edtavHiddenanswers_Class',ctrl:'vHIDDENANSWERS',prop:'Class'}]}");
         setEventMetadata("ONMESSAGE_GX1","{handler:'E122N2',iparms:[{av:'AV13NotificationInfo',fld:'vNOTIFICATIONINFO',pic:''}]");
         setEventMetadata("ONMESSAGE_GX1",",oparms:[]}");
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
         scmdbuf = "";
         H002N3_A40000GXC1 = new int[1] ;
         H002N3_n40000GXC1 = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         A140WWPDiscussionMessageDate = (DateTime)(DateTime.MinValue);
         AV13NotificationInfo = new GeneXus.Core.genexus.server.SdtNotificationInfo(context);
         GX_FocusControl = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         H002N5_A40000GXC1 = new int[1] ;
         H002N5_n40000GXC1 = new bool[] {false} ;
         AV7HiddenAnswers = "";
         AV8HiddenAnswersLastOn = "";
         H002N7_A40000GXC1 = new int[1] ;
         H002N7_n40000GXC1 = new bool[] {false} ;
         H002N8_A136WWPDiscussionMessageThreadId = new long[1] ;
         H002N8_n136WWPDiscussionMessageThreadId = new bool[] {false} ;
         H002N8_A140WWPDiscussionMessageDate = new DateTime[] {DateTime.MinValue} ;
         H002N8_A137WWPDiscussionMessageId = new long[1] ;
         AV9HiddenAnswersLastOnDate = (DateTime)(DateTime.MinValue);
         sStyleString = "";
         TempTags = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV11WWPDiscussionMessageThreadId = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.discussions.wwp_discussionsonethreadcollapsedwc__default(),
            new Object[][] {
                new Object[] {
               H002N3_A40000GXC1, H002N3_n40000GXC1
               }
               , new Object[] {
               H002N5_A40000GXC1, H002N5_n40000GXC1
               }
               , new Object[] {
               H002N7_A40000GXC1, H002N7_n40000GXC1
               }
               , new Object[] {
               H002N8_A136WWPDiscussionMessageThreadId, H002N8_n136WWPDiscussionMessageThreadId, H002N8_A140WWPDiscussionMessageDate, H002N8_A137WWPDiscussionMessageId
               }
            }
         );
         /* GeneXus formulas. */
         edtavHiddenanswers_Enabled = 0;
         edtavHiddenanswerslaston_Enabled = 0;
      }

      private short nRcdExists_3 ;
      private short nIsMod_3 ;
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
      private short AV10HiddenAnswersCount ;
      private int edtavHiddenanswers_Enabled ;
      private int edtavHiddenanswerslaston_Enabled ;
      private int A40000GXC1 ;
      private int edtavHiddenanswerslaston_Visible ;
      private int idxLst ;
      private long AV11WWPDiscussionMessageThreadId ;
      private long wcpOAV11WWPDiscussionMessageThreadId ;
      private long A137WWPDiscussionMessageId ;
      private long A136WWPDiscussionMessageThreadId ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string edtavHiddenanswers_Internalname ;
      private string edtavHiddenanswerslaston_Internalname ;
      private string scmdbuf ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string divTablecontent_Internalname ;
      private string divHiddenanswerscell_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string edtavHiddenanswers_Class ;
      private string sStyleString ;
      private string tblTablemergedhiddenanswers_Internalname ;
      private string TempTags ;
      private string edtavHiddenanswers_Jsonclick ;
      private string edtavHiddenanswerslaston_Jsonclick ;
      private string sCtrlAV11WWPDiscussionMessageThreadId ;
      private DateTime A140WWPDiscussionMessageDate ;
      private DateTime AV9HiddenAnswersLastOnDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n40000GXC1 ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool n136WWPDiscussionMessageThreadId ;
      private string AV7HiddenAnswers ;
      private string AV8HiddenAnswersLastOn ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private long aP0_WWPDiscussionMessageThreadId ;
      private IDataStoreProvider pr_default ;
      private int[] H002N3_A40000GXC1 ;
      private bool[] H002N3_n40000GXC1 ;
      private int[] H002N5_A40000GXC1 ;
      private bool[] H002N5_n40000GXC1 ;
      private int[] H002N7_A40000GXC1 ;
      private bool[] H002N7_n40000GXC1 ;
      private long[] H002N8_A136WWPDiscussionMessageThreadId ;
      private bool[] H002N8_n136WWPDiscussionMessageThreadId ;
      private DateTime[] H002N8_A140WWPDiscussionMessageDate ;
      private long[] H002N8_A137WWPDiscussionMessageId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GeneXus.Core.genexus.server.SdtNotificationInfo AV13NotificationInfo ;
   }

   public class wwp_discussionsonethreadcollapsedwc__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH002N3;
          prmH002N3 = new Object[] {
          new ParDef("AV11WWPDiscussionMessageThreadId",GXType.Int64,10,0)
          };
          Object[] prmH002N5;
          prmH002N5 = new Object[] {
          new ParDef("AV11WWPDiscussionMessageThreadId",GXType.Int64,10,0)
          };
          Object[] prmH002N7;
          prmH002N7 = new Object[] {
          new ParDef("AV11WWPDiscussionMessageThreadId",GXType.Int64,10,0)
          };
          Object[] prmH002N8;
          prmH002N8 = new Object[] {
          new ParDef("AV11WWPDiscussionMessageThreadId",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("H002N3", "SELECT COALESCE( T1.GXC1, 0) AS GXC1 FROM (SELECT COUNT(*) AS GXC1 FROM WWP_DiscussionMessage WHERE WWPDiscussionMessageThreadId = :AV11WWPDiscussionMessageThreadId ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002N3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002N5", "SELECT COALESCE( T1.GXC1, 0) AS GXC1 FROM (SELECT COUNT(*) AS GXC1 FROM WWP_DiscussionMessage WHERE WWPDiscussionMessageThreadId = :AV11WWPDiscussionMessageThreadId ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002N5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002N7", "SELECT COALESCE( T1.GXC1, 0) AS GXC1 FROM (SELECT COUNT(*) AS GXC1 FROM WWP_DiscussionMessage WHERE WWPDiscussionMessageThreadId = :AV11WWPDiscussionMessageThreadId ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002N7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002N8", "SELECT WWPDiscussionMessageThreadId, WWPDiscussionMessageDate, WWPDiscussionMessageId FROM WWP_DiscussionMessage WHERE WWPDiscussionMessageThreadId = :AV11WWPDiscussionMessageThreadId ORDER BY WWPDiscussionMessageId DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002N8,1, GxCacheFrequency.OFF ,false,true )
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 3 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(2);
                ((long[]) buf[3])[0] = rslt.getLong(3);
                return;
       }
    }

 }

}
