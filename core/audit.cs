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
namespace GeneXus.Programs.core {
   public class audit : GXDataArea
   {
      protected void INITENV( )
      {
         if ( GxWebError != 0 )
         {
            return  ;
         }
      }

      protected void INITTRN( )
      {
         initialize_properties( ) ;
         entryPointCalled = false;
         gxfirstwebparm = GetFirstPar( "Mode");
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
         {
            setAjaxEventMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetFirstPar( "Mode");
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
         {
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetFirstPar( "Mode");
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "core.audit.aspx")), "core.audit.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "core.audit.aspx")))) ;
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
         if ( ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "Mode");
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               Gx_mode = gxfirstwebparm;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV7AuditID = StringUtil.StrToGuid( GetPar( "AuditID"));
                  AssignAttri("", false, "AV7AuditID", AV7AuditID.ToString());
                  GxWebStd.gx_hidden_field( context, "gxhash_vAUDITID", GetSecureSignedToken( "", AV7AuditID, context));
               }
            }
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_web_controls( ) ;
         if ( toggleJsOutput )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET 18_0_4-173650", 0) ;
            }
            Form.Meta.addItem("description", "Auditoria dos Dados", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtAuditDate_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public audit( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public audit( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           Guid aP1_AuditID )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7AuditID = aP1_AuditID;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
      }

      protected override bool IntegratedSecurityEnabled
      {
         get {
            return true ;
         }

      }

      protected override GAMSecurityLevel IntegratedSecurityLevel
      {
         get {
            return GAMSecurityLevel.SecurityHigh ;
         }

      }

      protected override string ExecutePermissionPrefix
      {
         get {
            return "audit_Execute" ;
         }

      }

      public override void webExecute( )
      {
         if ( initialized == 0 )
         {
            createObjects();
            initialize();
         }
         INITENV( ) ;
         INITTRN( ) ;
         if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("wwpbaseobjects.workwithplusmasterpage", "GeneXus.Programs.wwpbaseobjects.workwithplusmasterpage", new Object[] {context});
            MasterPageObj.setDataArea(this,false);
            ValidateSpaRequest();
            MasterPageObj.webExecute();
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

      protected void fix_multi_value_controls( )
      {
      }

      protected void Draw( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! GxWebStd.gx_redirect( context) )
         {
            disable_std_buttons( ) ;
            enableDisable( ) ;
            set_caption( ) ;
            /* Form start */
            DrawControls( ) ;
            fix_multi_value_controls( ) ;
         }
         /* Execute Exit event if defined. */
      }

      protected void DrawControls( )
      {
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMainTransaction", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         ClassString = "ErrorViewer";
         StyleString = "";
         GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "CellMarginTop10", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-lg-9", "start", "top", "", "", "div");
         /* User Defined Control */
         ucDvpanel_tableattributes.SetProperty("Width", Dvpanel_tableattributes_Width);
         ucDvpanel_tableattributes.SetProperty("AutoWidth", Dvpanel_tableattributes_Autowidth);
         ucDvpanel_tableattributes.SetProperty("AutoHeight", Dvpanel_tableattributes_Autoheight);
         ucDvpanel_tableattributes.SetProperty("Cls", Dvpanel_tableattributes_Cls);
         ucDvpanel_tableattributes.SetProperty("Title", Dvpanel_tableattributes_Title);
         ucDvpanel_tableattributes.SetProperty("Collapsible", Dvpanel_tableattributes_Collapsible);
         ucDvpanel_tableattributes.SetProperty("Collapsed", Dvpanel_tableattributes_Collapsed);
         ucDvpanel_tableattributes.SetProperty("ShowCollapseIcon", Dvpanel_tableattributes_Showcollapseicon);
         ucDvpanel_tableattributes.SetProperty("IconPosition", Dvpanel_tableattributes_Iconposition);
         ucDvpanel_tableattributes.SetProperty("AutoScroll", Dvpanel_tableattributes_Autoscroll);
         ucDvpanel_tableattributes.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tableattributes_Internalname, "DVPANEL_TABLEATTRIBUTESContainer");
         context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLEATTRIBUTESContainer"+"TableAttributes"+"\" style=\"display:none;\">") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAuditDate_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAuditDate_Internalname, "Data", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtAuditDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtAuditDate_Internalname, context.localUtil.Format(A494AuditDate, "99/99/99"), context.localUtil.Format( A494AuditDate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAuditDate_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtAuditDate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "core\\Data", "end", false, "", "HLP_core\\Audit.htm");
         GxWebStd.gx_bitmap( context, edtAuditDate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtAuditDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_core\\Audit.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAuditTime_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAuditTime_Internalname, "Hora", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtAuditTime_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtAuditTime_Internalname, context.localUtil.TToC( A495AuditTime, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A495AuditTime, "99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAuditTime_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtAuditTime_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 0, -1, 0, true, "core\\HoraMinuto", "end", false, "", "HLP_core\\Audit.htm");
         GxWebStd.gx_bitmap( context, edtAuditTime_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtAuditTime_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_core\\Audit.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAuditTableName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAuditTableName_Internalname, "Tabela", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAuditTableName_Internalname, A497AuditTableName, StringUtil.RTrim( context.localUtil.Format( A497AuditTableName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAuditTableName_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtAuditTableName_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\Audit.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAuditAction_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAuditAction_Internalname, "Ação", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAuditAction_Internalname, A502AuditAction, StringUtil.RTrim( context.localUtil.Format( A502AuditAction, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAuditAction_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtAuditAction_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\Audit.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAuditShortDescription_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAuditShortDescription_Internalname, "Descrição", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         ClassString = "AttributeFL";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtAuditShortDescription_Internalname, A499AuditShortDescription, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,40);\"", 0, 1, edtAuditShortDescription_Enabled, 0, 80, "chr", 5, "row", 0, StyleString, ClassString, "", "", "400", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_core\\Audit.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAuditDescription_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAuditDescription_Internalname, "Detalhes", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         ClassString = "AttributeFL";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtAuditDescription_Internalname, A498AuditDescription, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", 0, 1, edtAuditDescription_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_core\\Audit.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAuditGAMUserName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAuditGAMUserName_Internalname, "Usuário", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAuditGAMUserName_Internalname, A501AuditGAMUserName, StringUtil.RTrim( context.localUtil.Format( A501AuditGAMUserName, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAuditGAMUserName_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtAuditGAMUserName_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "core\\Nome", "start", true, "", "HLP_core\\Audit.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</div>") ;
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\Audit.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\Audit.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Excluir", bttBtntrn_delete_Jsonclick, 5, "Excluir", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\Audit.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAuditGAMUserID_Internalname, StringUtil.RTrim( A500AuditGAMUserID), StringUtil.RTrim( context.localUtil.Format( A500AuditGAMUserID, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,62);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAuditGAMUserID_Jsonclick, 0, "Attribute", "", "", "", "", edtAuditGAMUserID_Visible, edtAuditGAMUserID_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMGUID", "start", true, "", "HLP_core\\Audit.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
      }

      protected void UserMain( )
      {
         standaloneStartup( ) ;
      }

      protected void UserMainFullajax( )
      {
         INITENV( ) ;
         INITTRN( ) ;
         UserMain( ) ;
         Draw( ) ;
         SendCloseFormHiddens( ) ;
      }

      protected void standaloneStartup( )
      {
         standaloneStartupServer( ) ;
         disable_std_buttons( ) ;
         enableDisable( ) ;
         Process( ) ;
      }

      protected void standaloneStartupServer( )
      {
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11182 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z493AuditID = StringUtil.StrToGuid( cgiGet( "Z493AuditID"));
               Z496AuditDateTime = context.localUtil.CToT( cgiGet( "Z496AuditDateTime"), 0);
               Z494AuditDate = context.localUtil.CToD( cgiGet( "Z494AuditDate"), 0);
               Z495AuditTime = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z495AuditTime"), 0));
               Z500AuditGAMUserID = cgiGet( "Z500AuditGAMUserID");
               Z501AuditGAMUserName = cgiGet( "Z501AuditGAMUserName");
               Z497AuditTableName = cgiGet( "Z497AuditTableName");
               Z499AuditShortDescription = cgiGet( "Z499AuditShortDescription");
               Z502AuditAction = cgiGet( "Z502AuditAction");
               A496AuditDateTime = context.localUtil.CToT( cgiGet( "Z496AuditDateTime"), 0);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               AV7AuditID = StringUtil.StrToGuid( cgiGet( "vAUDITID"));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ",", "."), 18, MidpointRounding.ToEven));
               A493AuditID = StringUtil.StrToGuid( cgiGet( "AUDITID"));
               A496AuditDateTime = context.localUtil.CToT( cgiGet( "AUDITDATETIME"), 0);
               Dvpanel_tableattributes_Objectcall = cgiGet( "DVPANEL_TABLEATTRIBUTES_Objectcall");
               Dvpanel_tableattributes_Class = cgiGet( "DVPANEL_TABLEATTRIBUTES_Class");
               Dvpanel_tableattributes_Enabled = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Enabled"));
               Dvpanel_tableattributes_Width = cgiGet( "DVPANEL_TABLEATTRIBUTES_Width");
               Dvpanel_tableattributes_Height = cgiGet( "DVPANEL_TABLEATTRIBUTES_Height");
               Dvpanel_tableattributes_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autowidth"));
               Dvpanel_tableattributes_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autoheight"));
               Dvpanel_tableattributes_Cls = cgiGet( "DVPANEL_TABLEATTRIBUTES_Cls");
               Dvpanel_tableattributes_Showheader = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Showheader"));
               Dvpanel_tableattributes_Title = cgiGet( "DVPANEL_TABLEATTRIBUTES_Title");
               Dvpanel_tableattributes_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Collapsible"));
               Dvpanel_tableattributes_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Collapsed"));
               Dvpanel_tableattributes_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Showcollapseicon"));
               Dvpanel_tableattributes_Iconposition = cgiGet( "DVPANEL_TABLEATTRIBUTES_Iconposition");
               Dvpanel_tableattributes_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autoscroll"));
               Dvpanel_tableattributes_Visible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Visible"));
               Dvpanel_tableattributes_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "DVPANEL_TABLEATTRIBUTES_Gxcontroltype"), ",", "."), 18, MidpointRounding.ToEven));
               /* Read variables values. */
               if ( context.localUtil.VCDate( cgiGet( edtAuditDate_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Data"}), 1, "AUDITDATE");
                  AnyError = 1;
                  GX_FocusControl = edtAuditDate_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A494AuditDate = DateTime.MinValue;
                  AssignAttri("", false, "A494AuditDate", context.localUtil.Format(A494AuditDate, "99/99/99"));
               }
               else
               {
                  A494AuditDate = context.localUtil.CToD( cgiGet( edtAuditDate_Internalname), 2);
                  AssignAttri("", false, "A494AuditDate", context.localUtil.Format(A494AuditDate, "99/99/99"));
               }
               if ( context.localUtil.VCDate( cgiGet( edtAuditTime_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badtime", new   object[]  {"Hora"}), 1, "AUDITTIME");
                  AnyError = 1;
                  GX_FocusControl = edtAuditTime_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A495AuditTime = (DateTime)(DateTime.MinValue);
                  AssignAttri("", false, "A495AuditTime", context.localUtil.TToC( A495AuditTime, 0, 5, 0, 3, "/", ":", " "));
               }
               else
               {
                  A495AuditTime = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtAuditTime_Internalname)));
                  AssignAttri("", false, "A495AuditTime", context.localUtil.TToC( A495AuditTime, 0, 5, 0, 3, "/", ":", " "));
               }
               A497AuditTableName = cgiGet( edtAuditTableName_Internalname);
               AssignAttri("", false, "A497AuditTableName", A497AuditTableName);
               A502AuditAction = cgiGet( edtAuditAction_Internalname);
               AssignAttri("", false, "A502AuditAction", A502AuditAction);
               A499AuditShortDescription = cgiGet( edtAuditShortDescription_Internalname);
               AssignAttri("", false, "A499AuditShortDescription", A499AuditShortDescription);
               A498AuditDescription = cgiGet( edtAuditDescription_Internalname);
               AssignAttri("", false, "A498AuditDescription", A498AuditDescription);
               A501AuditGAMUserName = StringUtil.Upper( cgiGet( edtAuditGAMUserName_Internalname));
               AssignAttri("", false, "A501AuditGAMUserName", A501AuditGAMUserName);
               A500AuditGAMUserID = cgiGet( edtAuditGAMUserID_Internalname);
               AssignAttri("", false, "A500AuditGAMUserID", A500AuditGAMUserID);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Audit");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("core\\audit:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
                  GxWebError = 1;
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  AnyError = 1;
                  return  ;
               }
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  A493AuditID = StringUtil.StrToGuid( GetPar( "AuditID"));
                  AssignAttri("", false, "A493AuditID", A493AuditID.ToString());
                  getEqualNoModal( ) ;
                  if ( ! (Guid.Empty==AV7AuditID) )
                  {
                     A493AuditID = AV7AuditID;
                     AssignAttri("", false, "A493AuditID", A493AuditID.ToString());
                  }
                  else
                  {
                     if ( IsIns( )  && (Guid.Empty==A493AuditID) && ( Gx_BScreen == 0 ) )
                     {
                        A493AuditID = Guid.NewGuid( );
                        AssignAttri("", false, "A493AuditID", A493AuditID.ToString());
                     }
                  }
                  /* N/A Action t   43 */
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  disable_std_buttons( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  if ( IsDsp( ) )
                  {
                     sMode43 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     if ( ! (Guid.Empty==AV7AuditID) )
                     {
                        A493AuditID = AV7AuditID;
                        AssignAttri("", false, "A493AuditID", A493AuditID.ToString());
                     }
                     else
                     {
                        if ( IsIns( )  && (Guid.Empty==A493AuditID) && ( Gx_BScreen == 0 ) )
                        {
                           A493AuditID = Guid.NewGuid( );
                           AssignAttri("", false, "A493AuditID", A493AuditID.ToString());
                        }
                     }
                     /* N/A Action t   43 */
                     Gx_mode = sMode43;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound43 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_180( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
         }
      }

      protected void Process( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read Transaction buttons. */
            sEvt = cgiGet( "_EventName");
            EvtGridId = cgiGet( "_EventGridId");
            EvtRowId = cgiGet( "_EventRowId");
            if ( StringUtil.Len( sEvt) > 0 )
            {
               sEvtType = StringUtil.Left( sEvt, 1);
               sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
               if ( StringUtil.StrCmp(sEvtType, "M") != 0 )
               {
                  if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                  {
                     sEvtType = StringUtil.Right( sEvt, 1);
                     if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                     {
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                        if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E11182 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12182 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           if ( ! IsDsp( ) )
                           {
                              btn_enter( ) ;
                           }
                           /* No code required for Cancel button. It is implemented as the Reset button. */
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

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            /* Execute user event: After Trn */
            E12182 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll1843( ) ;
               standaloneNotModal( ) ;
               standaloneModal( ) ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      protected void disable_std_buttons( )
      {
         bttBtntrn_delete_Visible = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
         if ( IsDsp( ) || IsDlt( ) )
         {
            bttBtntrn_delete_Visible = 0;
            AssignProp("", false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
            if ( IsDsp( ) )
            {
               bttBtntrn_enter_Visible = 0;
               AssignProp("", false, bttBtntrn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Visible), 5, 0), true);
            }
            DisableAttributes1843( ) ;
         }
      }

      protected void set_caption( )
      {
         if ( ( IsConfirmed == 1 ) && ( AnyError == 0 ) )
         {
            if ( IsDlt( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_confdelete", ""), 0, "", true);
            }
            else
            {
               GX_msglist.addItem(context.GetMessage( "GXM_mustconfirm", ""), 0, "", true);
            }
         }
      }

      protected void CONFIRM_180( )
      {
         BeforeValidate1843( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1843( ) ;
            }
            else
            {
               CheckExtendedTable1843( ) ;
               CloseExtendedTableCursors1843( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption180( )
      {
      }

      protected void E11182( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV12TrnContext.FromXml(AV13WebSession.Get("TrnContext"), null, "", "");
         edtAuditGAMUserID_Visible = 0;
         AssignProp("", false, edtAuditGAMUserID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtAuditGAMUserID_Visible), 5, 0), true);
      }

      protected void E12182( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV12TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("core.auditww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM1843( short GX_JID )
      {
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z496AuditDateTime = T00183_A496AuditDateTime[0];
               Z494AuditDate = T00183_A494AuditDate[0];
               Z495AuditTime = T00183_A495AuditTime[0];
               Z500AuditGAMUserID = T00183_A500AuditGAMUserID[0];
               Z501AuditGAMUserName = T00183_A501AuditGAMUserName[0];
               Z497AuditTableName = T00183_A497AuditTableName[0];
               Z499AuditShortDescription = T00183_A499AuditShortDescription[0];
               Z502AuditAction = T00183_A502AuditAction[0];
            }
            else
            {
               Z496AuditDateTime = A496AuditDateTime;
               Z494AuditDate = A494AuditDate;
               Z495AuditTime = A495AuditTime;
               Z500AuditGAMUserID = A500AuditGAMUserID;
               Z501AuditGAMUserName = A501AuditGAMUserName;
               Z497AuditTableName = A497AuditTableName;
               Z499AuditShortDescription = A499AuditShortDescription;
               Z502AuditAction = A502AuditAction;
            }
         }
         if ( GX_JID == -8 )
         {
            Z493AuditID = A493AuditID;
            Z496AuditDateTime = A496AuditDateTime;
            Z494AuditDate = A494AuditDate;
            Z495AuditTime = A495AuditTime;
            Z500AuditGAMUserID = A500AuditGAMUserID;
            Z501AuditGAMUserName = A501AuditGAMUserName;
            Z497AuditTableName = A497AuditTableName;
            Z498AuditDescription = A498AuditDescription;
            Z499AuditShortDescription = A499AuditShortDescription;
            Z502AuditAction = A502AuditAction;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
      }

      protected void standaloneModal( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtntrn_enter_Enabled = 0;
            AssignProp("", false, bttBtntrn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtntrn_enter_Enabled = 1;
            AssignProp("", false, bttBtntrn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Enabled), 5, 0), true);
         }
         if ( ! (Guid.Empty==AV7AuditID) )
         {
            A493AuditID = AV7AuditID;
            AssignAttri("", false, "A493AuditID", A493AuditID.ToString());
         }
         else
         {
            if ( IsIns( )  && (Guid.Empty==A493AuditID) && ( Gx_BScreen == 0 ) )
            {
               A493AuditID = Guid.NewGuid( );
               AssignAttri("", false, "A493AuditID", A493AuditID.ToString());
            }
         }
      }

      protected void Load1843( )
      {
         /* Using cursor T00184 */
         pr_default.execute(2, new Object[] {A493AuditID});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound43 = 1;
            A496AuditDateTime = T00184_A496AuditDateTime[0];
            A494AuditDate = T00184_A494AuditDate[0];
            AssignAttri("", false, "A494AuditDate", context.localUtil.Format(A494AuditDate, "99/99/99"));
            A495AuditTime = T00184_A495AuditTime[0];
            AssignAttri("", false, "A495AuditTime", context.localUtil.TToC( A495AuditTime, 0, 5, 0, 3, "/", ":", " "));
            A500AuditGAMUserID = T00184_A500AuditGAMUserID[0];
            AssignAttri("", false, "A500AuditGAMUserID", A500AuditGAMUserID);
            A501AuditGAMUserName = T00184_A501AuditGAMUserName[0];
            AssignAttri("", false, "A501AuditGAMUserName", A501AuditGAMUserName);
            A497AuditTableName = T00184_A497AuditTableName[0];
            AssignAttri("", false, "A497AuditTableName", A497AuditTableName);
            A498AuditDescription = T00184_A498AuditDescription[0];
            AssignAttri("", false, "A498AuditDescription", A498AuditDescription);
            A499AuditShortDescription = T00184_A499AuditShortDescription[0];
            AssignAttri("", false, "A499AuditShortDescription", A499AuditShortDescription);
            A502AuditAction = T00184_A502AuditAction[0];
            AssignAttri("", false, "A502AuditAction", A502AuditAction);
            ZM1843( -8) ;
         }
         pr_default.close(2);
         OnLoadActions1843( ) ;
      }

      protected void OnLoadActions1843( )
      {
      }

      protected void CheckExtendedTable1843( )
      {
         nIsDirty_43 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors1843( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1843( )
      {
         /* Using cursor T00185 */
         pr_default.execute(3, new Object[] {A493AuditID});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound43 = 1;
         }
         else
         {
            RcdFound43 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00183 */
         pr_default.execute(1, new Object[] {A493AuditID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1843( 8) ;
            RcdFound43 = 1;
            A493AuditID = T00183_A493AuditID[0];
            A496AuditDateTime = T00183_A496AuditDateTime[0];
            A494AuditDate = T00183_A494AuditDate[0];
            AssignAttri("", false, "A494AuditDate", context.localUtil.Format(A494AuditDate, "99/99/99"));
            A495AuditTime = T00183_A495AuditTime[0];
            AssignAttri("", false, "A495AuditTime", context.localUtil.TToC( A495AuditTime, 0, 5, 0, 3, "/", ":", " "));
            A500AuditGAMUserID = T00183_A500AuditGAMUserID[0];
            AssignAttri("", false, "A500AuditGAMUserID", A500AuditGAMUserID);
            A501AuditGAMUserName = T00183_A501AuditGAMUserName[0];
            AssignAttri("", false, "A501AuditGAMUserName", A501AuditGAMUserName);
            A497AuditTableName = T00183_A497AuditTableName[0];
            AssignAttri("", false, "A497AuditTableName", A497AuditTableName);
            A498AuditDescription = T00183_A498AuditDescription[0];
            AssignAttri("", false, "A498AuditDescription", A498AuditDescription);
            A499AuditShortDescription = T00183_A499AuditShortDescription[0];
            AssignAttri("", false, "A499AuditShortDescription", A499AuditShortDescription);
            A502AuditAction = T00183_A502AuditAction[0];
            AssignAttri("", false, "A502AuditAction", A502AuditAction);
            Z493AuditID = A493AuditID;
            sMode43 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load1843( ) ;
            if ( AnyError == 1 )
            {
               RcdFound43 = 0;
               InitializeNonKey1843( ) ;
            }
            Gx_mode = sMode43;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound43 = 0;
            InitializeNonKey1843( ) ;
            sMode43 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode43;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1843( ) ;
         if ( RcdFound43 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound43 = 0;
         /* Using cursor T00186 */
         pr_default.execute(4, new Object[] {A493AuditID});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( GuidUtil.Compare(T00186_A493AuditID[0], A493AuditID, 0) < 0 ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( GuidUtil.Compare(T00186_A493AuditID[0], A493AuditID, 0) > 0 ) ) )
            {
               A493AuditID = T00186_A493AuditID[0];
               RcdFound43 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound43 = 0;
         /* Using cursor T00187 */
         pr_default.execute(5, new Object[] {A493AuditID});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( GuidUtil.Compare(T00187_A493AuditID[0], A493AuditID, 0) > 0 ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( GuidUtil.Compare(T00187_A493AuditID[0], A493AuditID, 0) < 0 ) ) )
            {
               A493AuditID = T00187_A493AuditID[0];
               RcdFound43 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1843( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtAuditDate_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1843( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound43 == 1 )
            {
               if ( A493AuditID != Z493AuditID )
               {
                  A493AuditID = Z493AuditID;
                  AssignAttri("", false, "A493AuditID", A493AuditID.ToString());
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtAuditDate_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update1843( ) ;
                  GX_FocusControl = edtAuditDate_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A493AuditID != Z493AuditID )
               {
                  /* Insert record */
                  GX_FocusControl = edtAuditDate_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1843( ) ;
                  if ( AnyError == 1 )
                  {
                     GX_FocusControl = "";
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                     AnyError = 1;
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtAuditDate_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1843( ) ;
                     if ( AnyError == 1 )
                     {
                        GX_FocusControl = "";
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
         if ( IsIns( ) || IsUpd( ) || IsDlt( ) )
         {
            if ( AnyError == 0 )
            {
               context.nUserReturn = 1;
            }
         }
      }

      protected void btn_delete( )
      {
         if ( A493AuditID != Z493AuditID )
         {
            A493AuditID = Z493AuditID;
            AssignAttri("", false, "A493AuditID", A493AuditID.ToString());
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "");
            AnyError = 1;
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtAuditDate_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency1843( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00182 */
            pr_default.execute(0, new Object[] {A493AuditID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_audit"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z496AuditDateTime != T00182_A496AuditDateTime[0] ) || ( DateTimeUtil.ResetTime ( Z494AuditDate ) != DateTimeUtil.ResetTime ( T00182_A494AuditDate[0] ) ) || ( Z495AuditTime != T00182_A495AuditTime[0] ) || ( StringUtil.StrCmp(Z500AuditGAMUserID, T00182_A500AuditGAMUserID[0]) != 0 ) || ( StringUtil.StrCmp(Z501AuditGAMUserName, T00182_A501AuditGAMUserName[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z497AuditTableName, T00182_A497AuditTableName[0]) != 0 ) || ( StringUtil.StrCmp(Z499AuditShortDescription, T00182_A499AuditShortDescription[0]) != 0 ) || ( StringUtil.StrCmp(Z502AuditAction, T00182_A502AuditAction[0]) != 0 ) )
            {
               if ( Z496AuditDateTime != T00182_A496AuditDateTime[0] )
               {
                  GXUtil.WriteLog("core.audit:[seudo value changed for attri]"+"AuditDateTime");
                  GXUtil.WriteLogRaw("Old: ",Z496AuditDateTime);
                  GXUtil.WriteLogRaw("Current: ",T00182_A496AuditDateTime[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z494AuditDate ) != DateTimeUtil.ResetTime ( T00182_A494AuditDate[0] ) )
               {
                  GXUtil.WriteLog("core.audit:[seudo value changed for attri]"+"AuditDate");
                  GXUtil.WriteLogRaw("Old: ",Z494AuditDate);
                  GXUtil.WriteLogRaw("Current: ",T00182_A494AuditDate[0]);
               }
               if ( Z495AuditTime != T00182_A495AuditTime[0] )
               {
                  GXUtil.WriteLog("core.audit:[seudo value changed for attri]"+"AuditTime");
                  GXUtil.WriteLogRaw("Old: ",Z495AuditTime);
                  GXUtil.WriteLogRaw("Current: ",T00182_A495AuditTime[0]);
               }
               if ( StringUtil.StrCmp(Z500AuditGAMUserID, T00182_A500AuditGAMUserID[0]) != 0 )
               {
                  GXUtil.WriteLog("core.audit:[seudo value changed for attri]"+"AuditGAMUserID");
                  GXUtil.WriteLogRaw("Old: ",Z500AuditGAMUserID);
                  GXUtil.WriteLogRaw("Current: ",T00182_A500AuditGAMUserID[0]);
               }
               if ( StringUtil.StrCmp(Z501AuditGAMUserName, T00182_A501AuditGAMUserName[0]) != 0 )
               {
                  GXUtil.WriteLog("core.audit:[seudo value changed for attri]"+"AuditGAMUserName");
                  GXUtil.WriteLogRaw("Old: ",Z501AuditGAMUserName);
                  GXUtil.WriteLogRaw("Current: ",T00182_A501AuditGAMUserName[0]);
               }
               if ( StringUtil.StrCmp(Z497AuditTableName, T00182_A497AuditTableName[0]) != 0 )
               {
                  GXUtil.WriteLog("core.audit:[seudo value changed for attri]"+"AuditTableName");
                  GXUtil.WriteLogRaw("Old: ",Z497AuditTableName);
                  GXUtil.WriteLogRaw("Current: ",T00182_A497AuditTableName[0]);
               }
               if ( StringUtil.StrCmp(Z499AuditShortDescription, T00182_A499AuditShortDescription[0]) != 0 )
               {
                  GXUtil.WriteLog("core.audit:[seudo value changed for attri]"+"AuditShortDescription");
                  GXUtil.WriteLogRaw("Old: ",Z499AuditShortDescription);
                  GXUtil.WriteLogRaw("Current: ",T00182_A499AuditShortDescription[0]);
               }
               if ( StringUtil.StrCmp(Z502AuditAction, T00182_A502AuditAction[0]) != 0 )
               {
                  GXUtil.WriteLog("core.audit:[seudo value changed for attri]"+"AuditAction");
                  GXUtil.WriteLogRaw("Old: ",Z502AuditAction);
                  GXUtil.WriteLogRaw("Current: ",T00182_A502AuditAction[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"tb_audit"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1843( )
      {
         if ( ! IsAuthorized("audit_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1843( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1843( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1843( 0) ;
            CheckOptimisticConcurrency1843( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1843( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1843( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00188 */
                     pr_default.execute(6, new Object[] {A493AuditID, A496AuditDateTime, A494AuditDate, A495AuditTime, A500AuditGAMUserID, A501AuditGAMUserName, A497AuditTableName, A498AuditDescription, A499AuditShortDescription, A502AuditAction});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("tb_audit");
                     if ( (pr_default.getStatus(6) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           if ( IsIns( ) || IsUpd( ) || IsDlt( ) )
                           {
                              if ( AnyError == 0 )
                              {
                                 context.nUserReturn = 1;
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load1843( ) ;
            }
            EndLevel1843( ) ;
         }
         CloseExtendedTableCursors1843( ) ;
      }

      protected void Update1843( )
      {
         if ( ! IsAuthorized("audit_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1843( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1843( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1843( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1843( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1843( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00189 */
                     pr_default.execute(7, new Object[] {A496AuditDateTime, A494AuditDate, A495AuditTime, A500AuditGAMUserID, A501AuditGAMUserName, A497AuditTableName, A498AuditDescription, A499AuditShortDescription, A502AuditAction, A493AuditID});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("tb_audit");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_audit"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1843( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           if ( IsIns( ) || IsUpd( ) || IsDlt( ) )
                           {
                              if ( AnyError == 0 )
                              {
                                 context.nUserReturn = 1;
                              }
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel1843( ) ;
         }
         CloseExtendedTableCursors1843( ) ;
      }

      protected void DeferredUpdate1843( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("audit_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1843( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1843( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1843( ) ;
            AfterConfirm1843( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1843( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001810 */
                  pr_default.execute(8, new Object[] {A493AuditID});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("tb_audit");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        if ( IsIns( ) || IsUpd( ) || IsDlt( ) )
                        {
                           if ( AnyError == 0 )
                           {
                              context.nUserReturn = 1;
                           }
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode43 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1843( ) ;
         Gx_mode = sMode43;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1843( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1843( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1843( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("core.audit",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues180( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("core.audit",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1843( )
      {
         /* Scan By routine */
         /* Using cursor T001811 */
         pr_default.execute(9);
         RcdFound43 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound43 = 1;
            A493AuditID = T001811_A493AuditID[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1843( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound43 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound43 = 1;
            A493AuditID = T001811_A493AuditID[0];
         }
      }

      protected void ScanEnd1843( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm1843( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1843( )
      {
         /* Before Insert Rules */
         A496AuditDateTime = DateTimeUtil.NowMS( context);
         AssignAttri("", false, "A496AuditDateTime", context.localUtil.TToC( A496AuditDateTime, 10, 12, 0, 3, "/", ":", " "));
         A500AuditGAMUserID = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getid();
         AssignAttri("", false, "A500AuditGAMUserID", A500AuditGAMUserID);
         A501AuditGAMUserName = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
         AssignAttri("", false, "A501AuditGAMUserName", A501AuditGAMUserName);
         A494AuditDate = DateTimeUtil.ResetTime( A496AuditDateTime);
         AssignAttri("", false, "A494AuditDate", context.localUtil.Format(A494AuditDate, "99/99/99"));
         A495AuditTime = DateTimeUtil.ResetDate( DateTimeUtil.ResetMilliseconds(A496AuditDateTime));
         AssignAttri("", false, "A495AuditTime", context.localUtil.TToC( A495AuditTime, 0, 5, 0, 3, "/", ":", " "));
      }

      protected void BeforeUpdate1843( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1843( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1843( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1843( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1843( )
      {
         edtAuditDate_Enabled = 0;
         AssignProp("", false, edtAuditDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAuditDate_Enabled), 5, 0), true);
         edtAuditTime_Enabled = 0;
         AssignProp("", false, edtAuditTime_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAuditTime_Enabled), 5, 0), true);
         edtAuditTableName_Enabled = 0;
         AssignProp("", false, edtAuditTableName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAuditTableName_Enabled), 5, 0), true);
         edtAuditAction_Enabled = 0;
         AssignProp("", false, edtAuditAction_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAuditAction_Enabled), 5, 0), true);
         edtAuditShortDescription_Enabled = 0;
         AssignProp("", false, edtAuditShortDescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAuditShortDescription_Enabled), 5, 0), true);
         edtAuditDescription_Enabled = 0;
         AssignProp("", false, edtAuditDescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAuditDescription_Enabled), 5, 0), true);
         edtAuditGAMUserName_Enabled = 0;
         AssignProp("", false, edtAuditGAMUserName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAuditGAMUserName_Enabled), 5, 0), true);
         edtAuditGAMUserID_Enabled = 0;
         AssignProp("", false, edtAuditGAMUserID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAuditGAMUserID_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1843( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues180( )
      {
      }

      public override void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      public override void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( Form.Caption) ;
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
         MasterPageObj.master_styles();
         CloseStyles();
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         if ( StringUtil.StrCmp(context.GetLanguageProperty( "rtl"), "true") == 0 )
         {
            context.WriteHtmlText( " dir=\"rtl\" ") ;
         }
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         bodyStyle += "-moz-opacity:0;opacity:0;";
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "core.audit.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV7AuditID.ToString());
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("core.audit.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"Audit");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("core\\audit:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z493AuditID", Z493AuditID.ToString());
         GxWebStd.gx_hidden_field( context, "Z496AuditDateTime", context.localUtil.TToC( Z496AuditDateTime, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z494AuditDate", context.localUtil.DToC( Z494AuditDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z495AuditTime", context.localUtil.TToC( Z495AuditTime, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z500AuditGAMUserID", StringUtil.RTrim( Z500AuditGAMUserID));
         GxWebStd.gx_hidden_field( context, "Z501AuditGAMUserName", Z501AuditGAMUserName);
         GxWebStd.gx_hidden_field( context, "Z497AuditTableName", Z497AuditTableName);
         GxWebStd.gx_hidden_field( context, "Z499AuditShortDescription", Z499AuditShortDescription);
         GxWebStd.gx_hidden_field( context, "Z502AuditAction", Z502AuditAction);
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV12TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV12TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV12TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vAUDITID", AV7AuditID.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vAUDITID", GetSecureSignedToken( "", AV7AuditID, context));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "AUDITID", A493AuditID.ToString());
         GxWebStd.gx_hidden_field( context, "AUDITDATETIME", context.localUtil.TToC( A496AuditDateTime, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Objectcall", StringUtil.RTrim( Dvpanel_tableattributes_Objectcall));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Enabled", StringUtil.BoolToStr( Dvpanel_tableattributes_Enabled));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Width", StringUtil.RTrim( Dvpanel_tableattributes_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Autowidth", StringUtil.BoolToStr( Dvpanel_tableattributes_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Autoheight", StringUtil.BoolToStr( Dvpanel_tableattributes_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Cls", StringUtil.RTrim( Dvpanel_tableattributes_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Title", StringUtil.RTrim( Dvpanel_tableattributes_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Collapsible", StringUtil.BoolToStr( Dvpanel_tableattributes_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Collapsed", StringUtil.BoolToStr( Dvpanel_tableattributes_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tableattributes_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Iconposition", StringUtil.RTrim( Dvpanel_tableattributes_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Autoscroll", StringUtil.BoolToStr( Dvpanel_tableattributes_Autoscroll));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken(sPrefix);
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
      }

      public override short ExecuteStartEvent( )
      {
         standaloneStartup( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         return gxajaxcallmode ;
      }

      public override void RenderHtmlContent( )
      {
         context.WriteHtmlText( "<div") ;
         GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
         context.WriteHtmlText( ">") ;
         Draw( ) ;
         context.WriteHtmlText( "</div>") ;
      }

      public override void DispatchEvents( )
      {
         Process( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return true ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "core.audit.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV7AuditID.ToString());
         return formatLink("core.audit.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "core.Audit" ;
      }

      public override string GetPgmdesc( )
      {
         return "Auditoria dos Dados" ;
      }

      protected void InitializeNonKey1843( )
      {
         A496AuditDateTime = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A496AuditDateTime", context.localUtil.TToC( A496AuditDateTime, 10, 12, 0, 3, "/", ":", " "));
         A494AuditDate = DateTime.MinValue;
         AssignAttri("", false, "A494AuditDate", context.localUtil.Format(A494AuditDate, "99/99/99"));
         A495AuditTime = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A495AuditTime", context.localUtil.TToC( A495AuditTime, 0, 5, 0, 3, "/", ":", " "));
         A500AuditGAMUserID = "";
         AssignAttri("", false, "A500AuditGAMUserID", A500AuditGAMUserID);
         A501AuditGAMUserName = "";
         AssignAttri("", false, "A501AuditGAMUserName", A501AuditGAMUserName);
         A497AuditTableName = "";
         AssignAttri("", false, "A497AuditTableName", A497AuditTableName);
         A498AuditDescription = "";
         AssignAttri("", false, "A498AuditDescription", A498AuditDescription);
         A499AuditShortDescription = "";
         AssignAttri("", false, "A499AuditShortDescription", A499AuditShortDescription);
         A502AuditAction = "";
         AssignAttri("", false, "A502AuditAction", A502AuditAction);
         Z496AuditDateTime = (DateTime)(DateTime.MinValue);
         Z494AuditDate = DateTime.MinValue;
         Z495AuditTime = (DateTime)(DateTime.MinValue);
         Z500AuditGAMUserID = "";
         Z501AuditGAMUserName = "";
         Z497AuditTableName = "";
         Z499AuditShortDescription = "";
         Z502AuditAction = "";
      }

      protected void InitAll1843( )
      {
         A493AuditID = Guid.NewGuid( );
         AssignAttri("", false, "A493AuditID", A493AuditID.ToString());
         InitializeNonKey1843( ) ;
      }

      protected void StandaloneModalInsert( )
      {
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202382816118", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("messages.por.js", "?"+GetCacheInvalidationToken( ), false, true);
         context.AddJavascriptSource("core/audit.js", "?2023828161110", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtAuditDate_Internalname = "AUDITDATE";
         edtAuditTime_Internalname = "AUDITTIME";
         edtAuditTableName_Internalname = "AUDITTABLENAME";
         edtAuditAction_Internalname = "AUDITACTION";
         edtAuditShortDescription_Internalname = "AUDITSHORTDESCRIPTION";
         edtAuditDescription_Internalname = "AUDITDESCRIPTION";
         edtAuditGAMUserName_Internalname = "AUDITGAMUSERNAME";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtAuditGAMUserID_Internalname = "AUDITGAMUSERID";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Auditoria dos Dados";
         edtAuditGAMUserID_Jsonclick = "";
         edtAuditGAMUserID_Enabled = 1;
         edtAuditGAMUserID_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtAuditGAMUserName_Jsonclick = "";
         edtAuditGAMUserName_Enabled = 1;
         edtAuditDescription_Enabled = 1;
         edtAuditShortDescription_Enabled = 1;
         edtAuditAction_Jsonclick = "";
         edtAuditAction_Enabled = 1;
         edtAuditTableName_Jsonclick = "";
         edtAuditTableName_Enabled = 1;
         edtAuditTime_Jsonclick = "";
         edtAuditTime_Enabled = 1;
         edtAuditDate_Jsonclick = "";
         edtAuditDate_Enabled = 1;
         Dvpanel_tableattributes_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Iconposition = "Right";
         Dvpanel_tableattributes_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Title = "Informações Gerais";
         Dvpanel_tableattributes_Cls = "PanelCard_IconAndTitle Panel_BaseColor";
         Dvpanel_tableattributes_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tableattributes_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Width = "100%";
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7AuditID',fld:'vAUDITID',pic:'',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV12TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7AuditID',fld:'vAUDITID',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E12182',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV12TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
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
         pr_default.close(1);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         wcpOAV7AuditID = Guid.Empty;
         Z493AuditID = Guid.Empty;
         Z496AuditDateTime = (DateTime)(DateTime.MinValue);
         Z494AuditDate = DateTime.MinValue;
         Z495AuditTime = (DateTime)(DateTime.MinValue);
         Z500AuditGAMUserID = "";
         Z501AuditGAMUserName = "";
         Z497AuditTableName = "";
         Z499AuditShortDescription = "";
         Z502AuditAction = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         A494AuditDate = DateTime.MinValue;
         A495AuditTime = (DateTime)(DateTime.MinValue);
         A497AuditTableName = "";
         A502AuditAction = "";
         A499AuditShortDescription = "";
         A498AuditDescription = "";
         A501AuditGAMUserName = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         A500AuditGAMUserID = "";
         A496AuditDateTime = (DateTime)(DateTime.MinValue);
         A493AuditID = Guid.Empty;
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode43 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV12TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV13WebSession = context.GetSession();
         Z498AuditDescription = "";
         T00184_A493AuditID = new Guid[] {Guid.Empty} ;
         T00184_A496AuditDateTime = new DateTime[] {DateTime.MinValue} ;
         T00184_A494AuditDate = new DateTime[] {DateTime.MinValue} ;
         T00184_A495AuditTime = new DateTime[] {DateTime.MinValue} ;
         T00184_A500AuditGAMUserID = new string[] {""} ;
         T00184_A501AuditGAMUserName = new string[] {""} ;
         T00184_A497AuditTableName = new string[] {""} ;
         T00184_A498AuditDescription = new string[] {""} ;
         T00184_A499AuditShortDescription = new string[] {""} ;
         T00184_A502AuditAction = new string[] {""} ;
         T00185_A493AuditID = new Guid[] {Guid.Empty} ;
         T00183_A493AuditID = new Guid[] {Guid.Empty} ;
         T00183_A496AuditDateTime = new DateTime[] {DateTime.MinValue} ;
         T00183_A494AuditDate = new DateTime[] {DateTime.MinValue} ;
         T00183_A495AuditTime = new DateTime[] {DateTime.MinValue} ;
         T00183_A500AuditGAMUserID = new string[] {""} ;
         T00183_A501AuditGAMUserName = new string[] {""} ;
         T00183_A497AuditTableName = new string[] {""} ;
         T00183_A498AuditDescription = new string[] {""} ;
         T00183_A499AuditShortDescription = new string[] {""} ;
         T00183_A502AuditAction = new string[] {""} ;
         T00186_A493AuditID = new Guid[] {Guid.Empty} ;
         T00187_A493AuditID = new Guid[] {Guid.Empty} ;
         T00182_A493AuditID = new Guid[] {Guid.Empty} ;
         T00182_A496AuditDateTime = new DateTime[] {DateTime.MinValue} ;
         T00182_A494AuditDate = new DateTime[] {DateTime.MinValue} ;
         T00182_A495AuditTime = new DateTime[] {DateTime.MinValue} ;
         T00182_A500AuditGAMUserID = new string[] {""} ;
         T00182_A501AuditGAMUserName = new string[] {""} ;
         T00182_A497AuditTableName = new string[] {""} ;
         T00182_A498AuditDescription = new string[] {""} ;
         T00182_A499AuditShortDescription = new string[] {""} ;
         T00182_A502AuditAction = new string[] {""} ;
         T001811_A493AuditID = new Guid[] {Guid.Empty} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.core.audit__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.audit__default(),
            new Object[][] {
                new Object[] {
               T00182_A493AuditID, T00182_A496AuditDateTime, T00182_A494AuditDate, T00182_A495AuditTime, T00182_A500AuditGAMUserID, T00182_A501AuditGAMUserName, T00182_A497AuditTableName, T00182_A498AuditDescription, T00182_A499AuditShortDescription, T00182_A502AuditAction
               }
               , new Object[] {
               T00183_A493AuditID, T00183_A496AuditDateTime, T00183_A494AuditDate, T00183_A495AuditTime, T00183_A500AuditGAMUserID, T00183_A501AuditGAMUserName, T00183_A497AuditTableName, T00183_A498AuditDescription, T00183_A499AuditShortDescription, T00183_A502AuditAction
               }
               , new Object[] {
               T00184_A493AuditID, T00184_A496AuditDateTime, T00184_A494AuditDate, T00184_A495AuditTime, T00184_A500AuditGAMUserID, T00184_A501AuditGAMUserName, T00184_A497AuditTableName, T00184_A498AuditDescription, T00184_A499AuditShortDescription, T00184_A502AuditAction
               }
               , new Object[] {
               T00185_A493AuditID
               }
               , new Object[] {
               T00186_A493AuditID
               }
               , new Object[] {
               T00187_A493AuditID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001811_A493AuditID
               }
            }
         );
         Z493AuditID = Guid.NewGuid( );
         A493AuditID = Guid.NewGuid( );
      }

      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short Gx_BScreen ;
      private short RcdFound43 ;
      private short GX_JID ;
      private short nIsDirty_43 ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int edtAuditDate_Enabled ;
      private int edtAuditTime_Enabled ;
      private int edtAuditTableName_Enabled ;
      private int edtAuditAction_Enabled ;
      private int edtAuditShortDescription_Enabled ;
      private int edtAuditDescription_Enabled ;
      private int edtAuditGAMUserName_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtAuditGAMUserID_Visible ;
      private int edtAuditGAMUserID_Enabled ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z500AuditGAMUserID ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtAuditDate_Internalname ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string Dvpanel_tableattributes_Width ;
      private string Dvpanel_tableattributes_Cls ;
      private string Dvpanel_tableattributes_Title ;
      private string Dvpanel_tableattributes_Iconposition ;
      private string Dvpanel_tableattributes_Internalname ;
      private string divTableattributes_Internalname ;
      private string TempTags ;
      private string edtAuditDate_Jsonclick ;
      private string edtAuditTime_Internalname ;
      private string edtAuditTime_Jsonclick ;
      private string edtAuditTableName_Internalname ;
      private string edtAuditTableName_Jsonclick ;
      private string edtAuditAction_Internalname ;
      private string edtAuditAction_Jsonclick ;
      private string edtAuditShortDescription_Internalname ;
      private string edtAuditDescription_Internalname ;
      private string edtAuditGAMUserName_Internalname ;
      private string edtAuditGAMUserName_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtAuditGAMUserID_Internalname ;
      private string A500AuditGAMUserID ;
      private string edtAuditGAMUserID_Jsonclick ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string hsh ;
      private string sMode43 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXEncryptionTmp ;
      private DateTime Z496AuditDateTime ;
      private DateTime Z495AuditTime ;
      private DateTime A495AuditTime ;
      private DateTime A496AuditDateTime ;
      private DateTime Z494AuditDate ;
      private DateTime A494AuditDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private string A498AuditDescription ;
      private string Z498AuditDescription ;
      private string Z501AuditGAMUserName ;
      private string Z497AuditTableName ;
      private string Z499AuditShortDescription ;
      private string Z502AuditAction ;
      private string A497AuditTableName ;
      private string A502AuditAction ;
      private string A499AuditShortDescription ;
      private string A501AuditGAMUserName ;
      private Guid wcpOAV7AuditID ;
      private Guid Z493AuditID ;
      private Guid AV7AuditID ;
      private Guid A493AuditID ;
      private IGxSession AV13WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] T00184_A493AuditID ;
      private DateTime[] T00184_A496AuditDateTime ;
      private DateTime[] T00184_A494AuditDate ;
      private DateTime[] T00184_A495AuditTime ;
      private string[] T00184_A500AuditGAMUserID ;
      private string[] T00184_A501AuditGAMUserName ;
      private string[] T00184_A497AuditTableName ;
      private string[] T00184_A498AuditDescription ;
      private string[] T00184_A499AuditShortDescription ;
      private string[] T00184_A502AuditAction ;
      private Guid[] T00185_A493AuditID ;
      private Guid[] T00183_A493AuditID ;
      private DateTime[] T00183_A496AuditDateTime ;
      private DateTime[] T00183_A494AuditDate ;
      private DateTime[] T00183_A495AuditTime ;
      private string[] T00183_A500AuditGAMUserID ;
      private string[] T00183_A501AuditGAMUserName ;
      private string[] T00183_A497AuditTableName ;
      private string[] T00183_A498AuditDescription ;
      private string[] T00183_A499AuditShortDescription ;
      private string[] T00183_A502AuditAction ;
      private Guid[] T00186_A493AuditID ;
      private Guid[] T00187_A493AuditID ;
      private Guid[] T00182_A493AuditID ;
      private DateTime[] T00182_A496AuditDateTime ;
      private DateTime[] T00182_A494AuditDate ;
      private DateTime[] T00182_A495AuditTime ;
      private string[] T00182_A500AuditGAMUserID ;
      private string[] T00182_A501AuditGAMUserName ;
      private string[] T00182_A497AuditTableName ;
      private string[] T00182_A498AuditDescription ;
      private string[] T00182_A499AuditShortDescription ;
      private string[] T00182_A502AuditAction ;
      private Guid[] T001811_A493AuditID ;
      private IDataStoreProvider pr_gam ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV12TrnContext ;
   }

   public class audit__gam : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "GAM";
    }

 }

 public class audit__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[6])
       ,new UpdateCursor(def[7])
       ,new UpdateCursor(def[8])
       ,new ForEachCursor(def[9])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00184;
        prmT00184 = new Object[] {
        new ParDef("AuditID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT00185;
        prmT00185 = new Object[] {
        new ParDef("AuditID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT00183;
        prmT00183 = new Object[] {
        new ParDef("AuditID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT00186;
        prmT00186 = new Object[] {
        new ParDef("AuditID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT00187;
        prmT00187 = new Object[] {
        new ParDef("AuditID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT00182;
        prmT00182 = new Object[] {
        new ParDef("AuditID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT00188;
        prmT00188 = new Object[] {
        new ParDef("AuditID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("AuditDateTime",GXType.DateTime2,10,12) ,
        new ParDef("AuditDate",GXType.Date,8,0) ,
        new ParDef("AuditTime",GXType.DateTime,0,5) ,
        new ParDef("AuditGAMUserID",GXType.Char,40,0) ,
        new ParDef("AuditGAMUserName",GXType.VarChar,80,0) ,
        new ParDef("AuditTableName",GXType.VarChar,80,0) ,
        new ParDef("AuditDescription",GXType.LongVarChar,2097152,0) ,
        new ParDef("AuditShortDescription",GXType.VarChar,400,0) ,
        new ParDef("AuditAction",GXType.VarChar,40,0)
        };
        Object[] prmT00189;
        prmT00189 = new Object[] {
        new ParDef("AuditDateTime",GXType.DateTime2,10,12) ,
        new ParDef("AuditDate",GXType.Date,8,0) ,
        new ParDef("AuditTime",GXType.DateTime,0,5) ,
        new ParDef("AuditGAMUserID",GXType.Char,40,0) ,
        new ParDef("AuditGAMUserName",GXType.VarChar,80,0) ,
        new ParDef("AuditTableName",GXType.VarChar,80,0) ,
        new ParDef("AuditDescription",GXType.LongVarChar,2097152,0) ,
        new ParDef("AuditShortDescription",GXType.VarChar,400,0) ,
        new ParDef("AuditAction",GXType.VarChar,40,0) ,
        new ParDef("AuditID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT001810;
        prmT001810 = new Object[] {
        new ParDef("AuditID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT001811;
        prmT001811 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T00182", "SELECT AuditID, AuditDateTime, AuditDate, AuditTime, AuditGAMUserID, AuditGAMUserName, AuditTableName, AuditDescription, AuditShortDescription, AuditAction FROM tb_audit WHERE AuditID = :AuditID  FOR UPDATE OF tb_audit NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT00182,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00183", "SELECT AuditID, AuditDateTime, AuditDate, AuditTime, AuditGAMUserID, AuditGAMUserName, AuditTableName, AuditDescription, AuditShortDescription, AuditAction FROM tb_audit WHERE AuditID = :AuditID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00183,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00184", "SELECT TM1.AuditID, TM1.AuditDateTime, TM1.AuditDate, TM1.AuditTime, TM1.AuditGAMUserID, TM1.AuditGAMUserName, TM1.AuditTableName, TM1.AuditDescription, TM1.AuditShortDescription, TM1.AuditAction FROM tb_audit TM1 WHERE TM1.AuditID = :AuditID ORDER BY TM1.AuditID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00184,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00185", "SELECT AuditID FROM tb_audit WHERE AuditID = :AuditID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00185,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00186", "SELECT AuditID FROM tb_audit WHERE ( AuditID > :AuditID) ORDER BY AuditID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00186,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00187", "SELECT AuditID FROM tb_audit WHERE ( AuditID < :AuditID) ORDER BY AuditID DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT00187,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00188", "SAVEPOINT gxupdate;INSERT INTO tb_audit(AuditID, AuditDateTime, AuditDate, AuditTime, AuditGAMUserID, AuditGAMUserName, AuditTableName, AuditDescription, AuditShortDescription, AuditAction) VALUES(:AuditID, :AuditDateTime, :AuditDate, :AuditTime, :AuditGAMUserID, :AuditGAMUserName, :AuditTableName, :AuditDescription, :AuditShortDescription, :AuditAction);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT00188)
           ,new CursorDef("T00189", "SAVEPOINT gxupdate;UPDATE tb_audit SET AuditDateTime=:AuditDateTime, AuditDate=:AuditDate, AuditTime=:AuditTime, AuditGAMUserID=:AuditGAMUserID, AuditGAMUserName=:AuditGAMUserName, AuditTableName=:AuditTableName, AuditDescription=:AuditDescription, AuditShortDescription=:AuditShortDescription, AuditAction=:AuditAction  WHERE AuditID = :AuditID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT00189)
           ,new CursorDef("T001810", "SAVEPOINT gxupdate;DELETE FROM tb_audit  WHERE AuditID = :AuditID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001810)
           ,new CursorDef("T001811", "SELECT AuditID FROM tb_audit ORDER BY AuditID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001811,100, GxCacheFrequency.OFF ,true,false )
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
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2, true);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 40);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getLongVarchar(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              return;
           case 1 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2, true);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 40);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getLongVarchar(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              return;
           case 2 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2, true);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 40);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getLongVarchar(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              return;
           case 3 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 4 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 5 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 9 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
     }
  }

}

}
