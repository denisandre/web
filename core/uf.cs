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
   public class uf : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_13") == 0 )
         {
            A8UFRegID = (int)(Math.Round(NumberUtil.Val( GetPar( "UFRegID"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A8UFRegID", StringUtil.LTrimStr( (decimal)(A8UFRegID), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_13( A8UFRegID) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "core.uf.aspx")), "core.uf.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "core.uf.aspx")))) ;
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
                  AV7UFID = (int)(Math.Round(NumberUtil.Val( GetPar( "UFID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7UFID", StringUtil.LTrimStr( (decimal)(AV7UFID), 9, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vUFID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7UFID), "ZZZ,ZZZ,ZZ9"), context));
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
            Form.Meta.addItem("description", "Unidade Federativa (Estado)", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtUFID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public uf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public uf( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_UFID )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7UFID = aP1_UFID;
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
            return "uf_Execute" ;
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtUFID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUFID_Internalname, "UF", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUFID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A4UFID), 11, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A4UFID), "ZZZ,ZZZ,ZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUFID_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtUFID_Enabled, 1, "text", "", 11, "chr", 1, "row", 11, 0, 0, 0, 0, -1, 0, true, "core\\ID", "end", false, "", "HLP_core\\uf.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtUFSigla_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUFSigla_Internalname, "Sigla", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUFSigla_Internalname, A5UFSigla, StringUtil.RTrim( context.localUtil.Format( A5UFSigla, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUFSigla_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtUFSigla_Enabled, 0, "text", "", 2, "chr", 1, "row", 2, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\uf.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtUFNome_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUFNome_Internalname, "Nome", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUFNome_Internalname, A6UFNome, StringUtil.RTrim( context.localUtil.Format( A6UFNome, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUFNome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtUFNome_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\uf.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtUFSiglaNome_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUFSiglaNome_Internalname, "UF", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtUFSiglaNome_Internalname, A12UFSiglaNome, StringUtil.RTrim( context.localUtil.Format( A12UFSiglaNome, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUFSiglaNome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtUFSiglaNome_Enabled, 0, "text", "", 70, "chr", 1, "row", 70, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\uf.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedufregid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockufregid_Internalname, "Região", "", "", lblTextblockufregid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_core\\uf.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_ufregid.SetProperty("Caption", Combo_ufregid_Caption);
         ucCombo_ufregid.SetProperty("Cls", Combo_ufregid_Cls);
         ucCombo_ufregid.SetProperty("DataListProc", Combo_ufregid_Datalistproc);
         ucCombo_ufregid.SetProperty("DataListProcParametersPrefix", Combo_ufregid_Datalistprocparametersprefix);
         ucCombo_ufregid.SetProperty("EmptyItem", Combo_ufregid_Emptyitem);
         ucCombo_ufregid.SetProperty("DropDownOptionsTitleSettingsIcons", AV16DDO_TitleSettingsIcons);
         ucCombo_ufregid.SetProperty("DropDownOptionsData", AV15UFRegID_Data);
         ucCombo_ufregid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_ufregid_Internalname, "COMBO_UFREGIDContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUFRegID_Internalname, "Região", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUFRegID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A8UFRegID), 11, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A8UFRegID), "ZZZ,ZZZ,ZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUFRegID_Jsonclick, 0, "Attribute", "", "", "", "", edtUFRegID_Visible, edtUFRegID_Enabled, 1, "text", "", 11, "chr", 1, "row", 11, 0, 0, 0, 0, -1, 0, true, "core\\ID", "end", false, "", "HLP_core\\uf.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\uf.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\uf.htm");
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
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_ufregid_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtavComboufregid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20ComboUFRegID), 11, 0, ",", "")), StringUtil.LTrim( ((edtavComboufregid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV20ComboUFRegID), "ZZZ,ZZZ,ZZ9") : context.localUtil.Format( (decimal)(AV20ComboUFRegID), "ZZZ,ZZZ,ZZ9"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavComboufregid_Jsonclick, 0, "Attribute", "", "", "", "", edtavComboufregid_Visible, edtavComboufregid_Enabled, 0, "text", "", 11, "chr", 1, "row", 11, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_core\\uf.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtUFRegNome_Internalname, A10UFRegNome, StringUtil.RTrim( context.localUtil.Format( A10UFRegNome, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUFRegNome_Jsonclick, 0, "Attribute", "", "", "", "", edtUFRegNome_Visible, edtUFRegNome_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\uf.htm");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtUFRegSiglaNome_Internalname, A11UFRegSiglaNome, StringUtil.RTrim( context.localUtil.Format( A11UFRegSiglaNome, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUFRegSiglaNome_Jsonclick, 0, "Attribute", "", "", "", "", edtUFRegSiglaNome_Visible, edtUFRegSiglaNome_Enabled, 0, "text", "", 70, "chr", 1, "row", 70, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\uf.htm");
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
         E11022 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV16DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( "vUFREGID_DATA"), AV15UFRegID_Data);
               /* Read saved values. */
               Z4UFID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z4UFID"), ",", "."), 18, MidpointRounding.ToEven));
               Z12UFSiglaNome = cgiGet( "Z12UFSiglaNome");
               Z11UFRegSiglaNome = cgiGet( "Z11UFRegSiglaNome");
               n11UFRegSiglaNome = (String.IsNullOrEmpty(StringUtil.RTrim( A11UFRegSiglaNome)) ? true : false);
               Z5UFSigla = cgiGet( "Z5UFSigla");
               Z6UFNome = cgiGet( "Z6UFNome");
               Z8UFRegID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z8UFRegID"), ",", "."), 18, MidpointRounding.ToEven));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N8UFRegID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N8UFRegID"), ",", "."), 18, MidpointRounding.ToEven));
               A9UFRegSigla = cgiGet( "UFREGSIGLA");
               AV7UFID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vUFID"), ",", "."), 18, MidpointRounding.ToEven));
               AV13Insert_UFRegID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_UFREGID"), ",", "."), 18, MidpointRounding.ToEven));
               AV25Pgmname = cgiGet( "vPGMNAME");
               Combo_ufregid_Objectcall = cgiGet( "COMBO_UFREGID_Objectcall");
               Combo_ufregid_Class = cgiGet( "COMBO_UFREGID_Class");
               Combo_ufregid_Icontype = cgiGet( "COMBO_UFREGID_Icontype");
               Combo_ufregid_Icon = cgiGet( "COMBO_UFREGID_Icon");
               Combo_ufregid_Caption = cgiGet( "COMBO_UFREGID_Caption");
               Combo_ufregid_Tooltip = cgiGet( "COMBO_UFREGID_Tooltip");
               Combo_ufregid_Cls = cgiGet( "COMBO_UFREGID_Cls");
               Combo_ufregid_Selectedvalue_set = cgiGet( "COMBO_UFREGID_Selectedvalue_set");
               Combo_ufregid_Selectedvalue_get = cgiGet( "COMBO_UFREGID_Selectedvalue_get");
               Combo_ufregid_Selectedtext_set = cgiGet( "COMBO_UFREGID_Selectedtext_set");
               Combo_ufregid_Selectedtext_get = cgiGet( "COMBO_UFREGID_Selectedtext_get");
               Combo_ufregid_Gamoauthtoken = cgiGet( "COMBO_UFREGID_Gamoauthtoken");
               Combo_ufregid_Ddointernalname = cgiGet( "COMBO_UFREGID_Ddointernalname");
               Combo_ufregid_Titlecontrolalign = cgiGet( "COMBO_UFREGID_Titlecontrolalign");
               Combo_ufregid_Dropdownoptionstype = cgiGet( "COMBO_UFREGID_Dropdownoptionstype");
               Combo_ufregid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_UFREGID_Enabled"));
               Combo_ufregid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_UFREGID_Visible"));
               Combo_ufregid_Titlecontrolidtoreplace = cgiGet( "COMBO_UFREGID_Titlecontrolidtoreplace");
               Combo_ufregid_Datalisttype = cgiGet( "COMBO_UFREGID_Datalisttype");
               Combo_ufregid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_UFREGID_Allowmultipleselection"));
               Combo_ufregid_Datalistfixedvalues = cgiGet( "COMBO_UFREGID_Datalistfixedvalues");
               Combo_ufregid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_UFREGID_Isgriditem"));
               Combo_ufregid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_UFREGID_Hasdescription"));
               Combo_ufregid_Datalistproc = cgiGet( "COMBO_UFREGID_Datalistproc");
               Combo_ufregid_Datalistprocparametersprefix = cgiGet( "COMBO_UFREGID_Datalistprocparametersprefix");
               Combo_ufregid_Remoteservicesparameters = cgiGet( "COMBO_UFREGID_Remoteservicesparameters");
               Combo_ufregid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_UFREGID_Datalistupdateminimumcharacters"), ",", "."), 18, MidpointRounding.ToEven));
               Combo_ufregid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_UFREGID_Includeonlyselectedoption"));
               Combo_ufregid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_UFREGID_Includeselectalloption"));
               Combo_ufregid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_UFREGID_Emptyitem"));
               Combo_ufregid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_UFREGID_Includeaddnewoption"));
               Combo_ufregid_Htmltemplate = cgiGet( "COMBO_UFREGID_Htmltemplate");
               Combo_ufregid_Multiplevaluestype = cgiGet( "COMBO_UFREGID_Multiplevaluestype");
               Combo_ufregid_Loadingdata = cgiGet( "COMBO_UFREGID_Loadingdata");
               Combo_ufregid_Noresultsfound = cgiGet( "COMBO_UFREGID_Noresultsfound");
               Combo_ufregid_Emptyitemtext = cgiGet( "COMBO_UFREGID_Emptyitemtext");
               Combo_ufregid_Onlyselectedvalues = cgiGet( "COMBO_UFREGID_Onlyselectedvalues");
               Combo_ufregid_Selectalltext = cgiGet( "COMBO_UFREGID_Selectalltext");
               Combo_ufregid_Multiplevaluesseparator = cgiGet( "COMBO_UFREGID_Multiplevaluesseparator");
               Combo_ufregid_Addnewoptiontext = cgiGet( "COMBO_UFREGID_Addnewoptiontext");
               Combo_ufregid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_UFREGID_Gxcontroltype"), ",", "."), 18, MidpointRounding.ToEven));
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
               if ( ( ( context.localUtil.CToN( cgiGet( edtUFID_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtUFID_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "UFID");
                  AnyError = 1;
                  GX_FocusControl = edtUFID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A4UFID = 0;
                  AssignAttri("", false, "A4UFID", StringUtil.LTrimStr( (decimal)(A4UFID), 9, 0));
               }
               else
               {
                  A4UFID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtUFID_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A4UFID", StringUtil.LTrimStr( (decimal)(A4UFID), 9, 0));
               }
               A5UFSigla = StringUtil.Upper( cgiGet( edtUFSigla_Internalname));
               AssignAttri("", false, "A5UFSigla", A5UFSigla);
               A6UFNome = cgiGet( edtUFNome_Internalname);
               AssignAttri("", false, "A6UFNome", A6UFNome);
               A12UFSiglaNome = cgiGet( edtUFSiglaNome_Internalname);
               AssignAttri("", false, "A12UFSiglaNome", A12UFSiglaNome);
               if ( ( ( context.localUtil.CToN( cgiGet( edtUFRegID_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtUFRegID_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "UFREGID");
                  AnyError = 1;
                  GX_FocusControl = edtUFRegID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A8UFRegID = 0;
                  AssignAttri("", false, "A8UFRegID", StringUtil.LTrimStr( (decimal)(A8UFRegID), 9, 0));
               }
               else
               {
                  A8UFRegID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtUFRegID_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A8UFRegID", StringUtil.LTrimStr( (decimal)(A8UFRegID), 9, 0));
               }
               AV20ComboUFRegID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavComboufregid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV20ComboUFRegID", StringUtil.LTrimStr( (decimal)(AV20ComboUFRegID), 9, 0));
               A10UFRegNome = cgiGet( edtUFRegNome_Internalname);
               AssignAttri("", false, "A10UFRegNome", A10UFRegNome);
               A11UFRegSiglaNome = cgiGet( edtUFRegSiglaNome_Internalname);
               n11UFRegSiglaNome = false;
               AssignAttri("", false, "A11UFRegSiglaNome", A11UFRegSiglaNome);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"uf");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A4UFID != Z4UFID ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("core\\uf:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A4UFID = (int)(Math.Round(NumberUtil.Val( GetPar( "UFID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A4UFID", StringUtil.LTrimStr( (decimal)(A4UFID), 9, 0));
                  getEqualNoModal( ) ;
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  disable_std_buttons( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  if ( IsDsp( ) )
                  {
                     sMode2 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode2;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound2 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_020( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "UFID");
                        AnyError = 1;
                        GX_FocusControl = edtUFID_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
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
                           E11022 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12022 ();
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
            E12022 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll022( ) ;
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
         if ( IsDsp( ) || IsDlt( ) )
         {
            if ( IsDsp( ) )
            {
               bttBtntrn_enter_Visible = 0;
               AssignProp("", false, bttBtntrn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Visible), 5, 0), true);
            }
            DisableAttributes022( ) ;
         }
         AssignProp("", false, edtavComboufregid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboufregid_Enabled), 5, 0), true);
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

      protected void CONFIRM_020( )
      {
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls022( ) ;
            }
            else
            {
               CheckExtendedTable022( ) ;
               CloseExtendedTableCursors022( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption020( )
      {
      }

      protected void E11022( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV16DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV16DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         AV22GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV23GAMErrors);
         Combo_ufregid_Gamoauthtoken = AV22GAMSession.gxTpr_Token;
         ucCombo_ufregid.SendProperty(context, "", false, Combo_ufregid_Internalname, "GAMOAuthToken", Combo_ufregid_Gamoauthtoken);
         edtUFRegID_Visible = 0;
         AssignProp("", false, edtUFRegID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUFRegID_Visible), 5, 0), true);
         AV20ComboUFRegID = 0;
         AssignAttri("", false, "AV20ComboUFRegID", StringUtil.LTrimStr( (decimal)(AV20ComboUFRegID), 9, 0));
         edtavComboufregid_Visible = 0;
         AssignProp("", false, edtavComboufregid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavComboufregid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOUFREGID' */
         S112 ();
         if ( returnInSub )
         {
            pr_default.close(1);
            pr_default.close(2);
            returnInSub = true;
            if (true) return;
         }
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV25Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV26GXV1 = 1;
            AssignAttri("", false, "AV26GXV1", StringUtil.LTrimStr( (decimal)(AV26GXV1), 8, 0));
            while ( AV26GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV14TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV26GXV1));
               if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "UFRegID") == 0 )
               {
                  AV13Insert_UFRegID = (int)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV13Insert_UFRegID", StringUtil.LTrimStr( (decimal)(AV13Insert_UFRegID), 9, 0));
                  if ( ! (0==AV13Insert_UFRegID) )
                  {
                     AV20ComboUFRegID = AV13Insert_UFRegID;
                     AssignAttri("", false, "AV20ComboUFRegID", StringUtil.LTrimStr( (decimal)(AV20ComboUFRegID), 9, 0));
                     Combo_ufregid_Selectedvalue_set = StringUtil.Trim( StringUtil.Str( (decimal)(AV20ComboUFRegID), 9, 0));
                     ucCombo_ufregid.SendProperty(context, "", false, Combo_ufregid_Internalname, "SelectedValue_set", Combo_ufregid_Selectedvalue_set);
                     GXt_char2 = AV19Combo_DataJson;
                     new GeneXus.Programs.core.ufloaddvcombo(context ).execute(  "UFRegID",  "GET",  false,  AV7UFID,  AV14TrnContextAtt.gxTpr_Attributevalue, out  AV17ComboSelectedValue, out  AV18ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV17ComboSelectedValue", AV17ComboSelectedValue);
                     AssignAttri("", false, "AV18ComboSelectedText", AV18ComboSelectedText);
                     AV19Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV19Combo_DataJson", AV19Combo_DataJson);
                     Combo_ufregid_Selectedtext_set = AV18ComboSelectedText;
                     ucCombo_ufregid.SendProperty(context, "", false, Combo_ufregid_Internalname, "SelectedText_set", Combo_ufregid_Selectedtext_set);
                     Combo_ufregid_Enabled = false;
                     ucCombo_ufregid.SendProperty(context, "", false, Combo_ufregid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_ufregid_Enabled));
                  }
               }
               AV26GXV1 = (int)(AV26GXV1+1);
               AssignAttri("", false, "AV26GXV1", StringUtil.LTrimStr( (decimal)(AV26GXV1), 8, 0));
            }
         }
         edtUFRegNome_Visible = 0;
         AssignProp("", false, edtUFRegNome_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUFRegNome_Visible), 5, 0), true);
         edtUFRegSiglaNome_Visible = 0;
         AssignProp("", false, edtUFRegSiglaNome_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUFRegSiglaNome_Visible), 5, 0), true);
      }

      protected void E12022( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("core.ufww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         pr_default.close(1);
         pr_default.close(2);
         returnInSub = true;
         if (true) return;
      }

      protected void S112( )
      {
         /* 'LOADCOMBOUFREGID' Routine */
         returnInSub = false;
         GXt_char2 = AV19Combo_DataJson;
         new GeneXus.Programs.core.ufloaddvcombo(context ).execute(  "UFRegID",  Gx_mode,  false,  AV7UFID,  "", out  AV17ComboSelectedValue, out  AV18ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV17ComboSelectedValue", AV17ComboSelectedValue);
         AssignAttri("", false, "AV18ComboSelectedText", AV18ComboSelectedText);
         AV19Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV19Combo_DataJson", AV19Combo_DataJson);
         Combo_ufregid_Selectedvalue_set = AV17ComboSelectedValue;
         ucCombo_ufregid.SendProperty(context, "", false, Combo_ufregid_Internalname, "SelectedValue_set", Combo_ufregid_Selectedvalue_set);
         Combo_ufregid_Selectedtext_set = AV18ComboSelectedText;
         ucCombo_ufregid.SendProperty(context, "", false, Combo_ufregid_Internalname, "SelectedText_set", Combo_ufregid_Selectedtext_set);
         AV20ComboUFRegID = (int)(Math.Round(NumberUtil.Val( AV17ComboSelectedValue, "."), 18, MidpointRounding.ToEven));
         AssignAttri("", false, "AV20ComboUFRegID", StringUtil.LTrimStr( (decimal)(AV20ComboUFRegID), 9, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_ufregid_Enabled = false;
            ucCombo_ufregid.SendProperty(context, "", false, Combo_ufregid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_ufregid_Enabled));
         }
      }

      protected void ZM022( short GX_JID )
      {
         if ( ( GX_JID == 11 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z12UFSiglaNome = T00023_A12UFSiglaNome[0];
               Z11UFRegSiglaNome = T00023_A11UFRegSiglaNome[0];
               Z5UFSigla = T00023_A5UFSigla[0];
               Z6UFNome = T00023_A6UFNome[0];
               Z8UFRegID = T00023_A8UFRegID[0];
            }
            else
            {
               Z12UFSiglaNome = A12UFSiglaNome;
               Z11UFRegSiglaNome = A11UFRegSiglaNome;
               Z5UFSigla = A5UFSigla;
               Z6UFNome = A6UFNome;
               Z8UFRegID = A8UFRegID;
            }
         }
         if ( GX_JID == -11 )
         {
            Z12UFSiglaNome = A12UFSiglaNome;
            Z11UFRegSiglaNome = A11UFRegSiglaNome;
            Z4UFID = A4UFID;
            Z5UFSigla = A5UFSigla;
            Z6UFNome = A6UFNome;
            Z9UFRegSigla = A9UFRegSigla;
            Z10UFRegNome = A10UFRegNome;
            Z8UFRegID = A8UFRegID;
         }
      }

      protected void standaloneNotModal( )
      {
         AV25Pgmname = "core.uf";
         AssignAttri("", false, "AV25Pgmname", AV25Pgmname);
         if ( ! (0==AV7UFID) )
         {
            A4UFID = AV7UFID;
            AssignAttri("", false, "A4UFID", StringUtil.LTrimStr( (decimal)(A4UFID), 9, 0));
         }
         if ( ! (0==AV7UFID) )
         {
            edtUFID_Enabled = 0;
            AssignProp("", false, edtUFID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUFID_Enabled), 5, 0), true);
         }
         else
         {
            edtUFID_Enabled = 1;
            AssignProp("", false, edtUFID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUFID_Enabled), 5, 0), true);
         }
         if ( ! (0==AV7UFID) )
         {
            edtUFID_Enabled = 0;
            AssignProp("", false, edtUFID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUFID_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_UFRegID) )
         {
            edtUFRegID_Enabled = 0;
            AssignProp("", false, edtUFRegID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUFRegID_Enabled), 5, 0), true);
         }
         else
         {
            edtUFRegID_Enabled = 1;
            AssignProp("", false, edtUFRegID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUFRegID_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_UFRegID) )
         {
            A8UFRegID = AV13Insert_UFRegID;
            AssignAttri("", false, "A8UFRegID", StringUtil.LTrimStr( (decimal)(A8UFRegID), 9, 0));
         }
         else
         {
            A8UFRegID = AV20ComboUFRegID;
            AssignAttri("", false, "A8UFRegID", StringUtil.LTrimStr( (decimal)(A8UFRegID), 9, 0));
         }
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
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T00024 */
            pr_default.execute(2, new Object[] {A8UFRegID});
            A9UFRegSigla = T00024_A9UFRegSigla[0];
            A10UFRegNome = T00024_A10UFRegNome[0];
            AssignAttri("", false, "A10UFRegNome", A10UFRegNome);
            pr_default.close(2);
            A11UFRegSiglaNome = StringUtil.Trim( A9UFRegSigla) + " - " + StringUtil.Trim( A10UFRegNome);
            n11UFRegSiglaNome = false;
            AssignAttri("", false, "A11UFRegSiglaNome", A11UFRegSiglaNome);
         }
      }

      protected void Load022( )
      {
         /* Using cursor T00025 */
         pr_default.execute(3, new Object[] {A4UFID});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound2 = 1;
            A12UFSiglaNome = T00025_A12UFSiglaNome[0];
            AssignAttri("", false, "A12UFSiglaNome", A12UFSiglaNome);
            A11UFRegSiglaNome = T00025_A11UFRegSiglaNome[0];
            n11UFRegSiglaNome = T00025_n11UFRegSiglaNome[0];
            AssignAttri("", false, "A11UFRegSiglaNome", A11UFRegSiglaNome);
            A5UFSigla = T00025_A5UFSigla[0];
            AssignAttri("", false, "A5UFSigla", A5UFSigla);
            A6UFNome = T00025_A6UFNome[0];
            AssignAttri("", false, "A6UFNome", A6UFNome);
            A9UFRegSigla = T00025_A9UFRegSigla[0];
            A10UFRegNome = T00025_A10UFRegNome[0];
            AssignAttri("", false, "A10UFRegNome", A10UFRegNome);
            A8UFRegID = T00025_A8UFRegID[0];
            AssignAttri("", false, "A8UFRegID", StringUtil.LTrimStr( (decimal)(A8UFRegID), 9, 0));
            ZM022( -11) ;
         }
         pr_default.close(3);
         OnLoadActions022( ) ;
      }

      protected void OnLoadActions022( )
      {
         A12UFSiglaNome = StringUtil.Trim( A5UFSigla) + " - " + StringUtil.Trim( A6UFNome);
         AssignAttri("", false, "A12UFSiglaNome", A12UFSiglaNome);
         /* Using cursor T00024 */
         pr_default.execute(2, new Object[] {A8UFRegID});
         A9UFRegSigla = T00024_A9UFRegSigla[0];
         A10UFRegNome = T00024_A10UFRegNome[0];
         AssignAttri("", false, "A10UFRegNome", A10UFRegNome);
         pr_default.close(2);
         A11UFRegSiglaNome = StringUtil.Trim( A9UFRegSigla) + " - " + StringUtil.Trim( A10UFRegNome);
         n11UFRegSiglaNome = false;
         AssignAttri("", false, "A11UFRegSiglaNome", A11UFRegSiglaNome);
      }

      protected void CheckExtendedTable022( )
      {
         nIsDirty_2 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T00026 */
         pr_default.execute(4, new Object[] {A5UFSigla, A4UFID});
         if ( (pr_default.getStatus(4) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Sigla"}), 1, "UFSIGLA");
            AnyError = 1;
            GX_FocusControl = edtUFSigla_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(4);
         nIsDirty_2 = 1;
         A12UFSiglaNome = StringUtil.Trim( A5UFSigla) + " - " + StringUtil.Trim( A6UFNome);
         AssignAttri("", false, "A12UFSiglaNome", A12UFSiglaNome);
         /* Using cursor T00024 */
         pr_default.execute(2, new Object[] {A8UFRegID});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("Não existe 'Regiao -> UF'.", "ForeignKeyNotFound", 1, "UFREGID");
            AnyError = 1;
            GX_FocusControl = edtUFRegID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A9UFRegSigla = T00024_A9UFRegSigla[0];
         A10UFRegNome = T00024_A10UFRegNome[0];
         AssignAttri("", false, "A10UFRegNome", A10UFRegNome);
         pr_default.close(2);
         nIsDirty_2 = 1;
         A11UFRegSiglaNome = StringUtil.Trim( A9UFRegSigla) + " - " + StringUtil.Trim( A10UFRegNome);
         n11UFRegSiglaNome = false;
         AssignAttri("", false, "A11UFRegSiglaNome", A11UFRegSiglaNome);
      }

      protected void CloseExtendedTableCursors022( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_13( int A8UFRegID )
      {
         /* Using cursor T00027 */
         pr_default.execute(5, new Object[] {A8UFRegID});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("Não existe 'Regiao -> UF'.", "ForeignKeyNotFound", 1, "UFREGID");
            AnyError = 1;
            GX_FocusControl = edtUFRegID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A9UFRegSigla = T00027_A9UFRegSigla[0];
         A10UFRegNome = T00027_A10UFRegNome[0];
         AssignAttri("", false, "A10UFRegNome", A10UFRegNome);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A9UFRegSigla)+"\""+","+"\""+GXUtil.EncodeJSConstant( A10UFRegNome)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void GetKey022( )
      {
         /* Using cursor T00028 */
         pr_default.execute(6, new Object[] {A4UFID});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound2 = 1;
         }
         else
         {
            RcdFound2 = 0;
         }
         pr_default.close(6);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00023 */
         pr_default.execute(1, new Object[] {A4UFID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM022( 11) ;
            RcdFound2 = 1;
            A12UFSiglaNome = T00023_A12UFSiglaNome[0];
            AssignAttri("", false, "A12UFSiglaNome", A12UFSiglaNome);
            A4UFID = T00023_A4UFID[0];
            AssignAttri("", false, "A4UFID", StringUtil.LTrimStr( (decimal)(A4UFID), 9, 0));
            A5UFSigla = T00023_A5UFSigla[0];
            AssignAttri("", false, "A5UFSigla", A5UFSigla);
            A6UFNome = T00023_A6UFNome[0];
            AssignAttri("", false, "A6UFNome", A6UFNome);
            A8UFRegID = T00023_A8UFRegID[0];
            AssignAttri("", false, "A8UFRegID", StringUtil.LTrimStr( (decimal)(A8UFRegID), 9, 0));
            A11UFRegSiglaNome = T00023_A11UFRegSiglaNome[0];
            n11UFRegSiglaNome = T00023_n11UFRegSiglaNome[0];
            AssignAttri("", false, "A11UFRegSiglaNome", A11UFRegSiglaNome);
            Z4UFID = A4UFID;
            sMode2 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load022( ) ;
            if ( AnyError == 1 )
            {
               RcdFound2 = 0;
               InitializeNonKey022( ) ;
            }
            Gx_mode = sMode2;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound2 = 0;
            InitializeNonKey022( ) ;
            sMode2 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode2;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey022( ) ;
         if ( RcdFound2 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound2 = 0;
         /* Using cursor T00029 */
         pr_default.execute(7, new Object[] {A4UFID});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T00029_A4UFID[0] < A4UFID ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T00029_A4UFID[0] > A4UFID ) ) )
            {
               A4UFID = T00029_A4UFID[0];
               AssignAttri("", false, "A4UFID", StringUtil.LTrimStr( (decimal)(A4UFID), 9, 0));
               RcdFound2 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void move_previous( )
      {
         RcdFound2 = 0;
         /* Using cursor T000210 */
         pr_default.execute(8, new Object[] {A4UFID});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T000210_A4UFID[0] > A4UFID ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T000210_A4UFID[0] < A4UFID ) ) )
            {
               A4UFID = T000210_A4UFID[0];
               AssignAttri("", false, "A4UFID", StringUtil.LTrimStr( (decimal)(A4UFID), 9, 0));
               RcdFound2 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey022( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtUFID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert022( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound2 == 1 )
            {
               if ( A4UFID != Z4UFID )
               {
                  A4UFID = Z4UFID;
                  AssignAttri("", false, "A4UFID", StringUtil.LTrimStr( (decimal)(A4UFID), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "UFID");
                  AnyError = 1;
                  GX_FocusControl = edtUFID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtUFID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update022( ) ;
                  GX_FocusControl = edtUFID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A4UFID != Z4UFID )
               {
                  /* Insert record */
                  GX_FocusControl = edtUFID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert022( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "UFID");
                     AnyError = 1;
                     GX_FocusControl = edtUFID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtUFID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert022( ) ;
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
         if ( IsUpd( ) || IsDlt( ) )
         {
            if ( AnyError == 0 )
            {
               context.nUserReturn = 1;
            }
         }
      }

      protected void btn_delete( )
      {
         if ( A4UFID != Z4UFID )
         {
            A4UFID = Z4UFID;
            AssignAttri("", false, "A4UFID", StringUtil.LTrimStr( (decimal)(A4UFID), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "UFID");
            AnyError = 1;
            GX_FocusControl = edtUFID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtUFID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency022( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00022 */
            pr_default.execute(0, new Object[] {A4UFID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tbibge_uf"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z12UFSiglaNome, T00022_A12UFSiglaNome[0]) != 0 ) || ( StringUtil.StrCmp(Z11UFRegSiglaNome, T00022_A11UFRegSiglaNome[0]) != 0 ) || ( StringUtil.StrCmp(Z5UFSigla, T00022_A5UFSigla[0]) != 0 ) || ( StringUtil.StrCmp(Z6UFNome, T00022_A6UFNome[0]) != 0 ) || ( Z8UFRegID != T00022_A8UFRegID[0] ) )
            {
               if ( StringUtil.StrCmp(Z12UFSiglaNome, T00022_A12UFSiglaNome[0]) != 0 )
               {
                  GXUtil.WriteLog("core.uf:[seudo value changed for attri]"+"UFSiglaNome");
                  GXUtil.WriteLogRaw("Old: ",Z12UFSiglaNome);
                  GXUtil.WriteLogRaw("Current: ",T00022_A12UFSiglaNome[0]);
               }
               if ( StringUtil.StrCmp(Z11UFRegSiglaNome, T00022_A11UFRegSiglaNome[0]) != 0 )
               {
                  GXUtil.WriteLog("core.uf:[seudo value changed for attri]"+"UFRegSiglaNome");
                  GXUtil.WriteLogRaw("Old: ",Z11UFRegSiglaNome);
                  GXUtil.WriteLogRaw("Current: ",T00022_A11UFRegSiglaNome[0]);
               }
               if ( StringUtil.StrCmp(Z5UFSigla, T00022_A5UFSigla[0]) != 0 )
               {
                  GXUtil.WriteLog("core.uf:[seudo value changed for attri]"+"UFSigla");
                  GXUtil.WriteLogRaw("Old: ",Z5UFSigla);
                  GXUtil.WriteLogRaw("Current: ",T00022_A5UFSigla[0]);
               }
               if ( StringUtil.StrCmp(Z6UFNome, T00022_A6UFNome[0]) != 0 )
               {
                  GXUtil.WriteLog("core.uf:[seudo value changed for attri]"+"UFNome");
                  GXUtil.WriteLogRaw("Old: ",Z6UFNome);
                  GXUtil.WriteLogRaw("Current: ",T00022_A6UFNome[0]);
               }
               if ( Z8UFRegID != T00022_A8UFRegID[0] )
               {
                  GXUtil.WriteLog("core.uf:[seudo value changed for attri]"+"UFRegID");
                  GXUtil.WriteLogRaw("Old: ",Z8UFRegID);
                  GXUtil.WriteLogRaw("Current: ",T00022_A8UFRegID[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"tbibge_uf"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert022( )
      {
         if ( ! IsAuthorized("uf_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable022( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM022( 0) ;
            CheckOptimisticConcurrency022( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm022( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert022( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000211 */
                     pr_default.execute(9, new Object[] {A9UFRegSigla, A10UFRegNome, A12UFSiglaNome, n11UFRegSiglaNome, A11UFRegSiglaNome, A4UFID, A5UFSigla, A6UFNome, A8UFRegID});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("tbibge_uf");
                     if ( (pr_default.getStatus(9) == 1) )
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
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption020( ) ;
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
               Load022( ) ;
            }
            EndLevel022( ) ;
         }
         CloseExtendedTableCursors022( ) ;
      }

      protected void Update022( )
      {
         if ( ! IsAuthorized("uf_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable022( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency022( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm022( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate022( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000212 */
                     pr_default.execute(10, new Object[] {A9UFRegSigla, A10UFRegNome, A12UFSiglaNome, n11UFRegSiglaNome, A11UFRegSiglaNome, A5UFSigla, A6UFNome, A8UFRegID, A4UFID});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("tbibge_uf");
                     if ( (pr_default.getStatus(10) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tbibge_uf"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate022( ) ;
                     if ( AnyError == 0 )
                     {
                        /* API remote call */
                        new tbibge_ufupdateredundancy(context ).execute( ref  A4UFID) ;
                        AssignAttri("", false, "A4UFID", StringUtil.LTrimStr( (decimal)(A4UFID), 9, 0));
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           if ( IsUpd( ) || IsDlt( ) )
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
            EndLevel022( ) ;
         }
         CloseExtendedTableCursors022( ) ;
      }

      protected void DeferredUpdate022( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("uf_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency022( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls022( ) ;
            AfterConfirm022( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete022( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000213 */
                  pr_default.execute(11, new Object[] {A4UFID});
                  pr_default.close(11);
                  pr_default.SmartCacheProvider.SetUpdated("tbibge_uf");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        if ( IsUpd( ) || IsDlt( ) )
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
         sMode2 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel022( ) ;
         Gx_mode = sMode2;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls022( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000214 */
            pr_default.execute(12, new Object[] {A8UFRegID});
            A9UFRegSigla = T000214_A9UFRegSigla[0];
            A10UFRegNome = T000214_A10UFRegNome[0];
            AssignAttri("", false, "A10UFRegNome", A10UFRegNome);
            pr_default.close(12);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000215 */
            pr_default.execute(13, new Object[] {A4UFID});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"tbibge_mesorregiao"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
         }
      }

      protected void EndLevel022( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete022( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("core.uf",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues020( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("core.uf",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart022( )
      {
         /* Scan By routine */
         /* Using cursor T000216 */
         pr_default.execute(14);
         RcdFound2 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound2 = 1;
            A4UFID = T000216_A4UFID[0];
            AssignAttri("", false, "A4UFID", StringUtil.LTrimStr( (decimal)(A4UFID), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext022( )
      {
         /* Scan next routine */
         pr_default.readNext(14);
         RcdFound2 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound2 = 1;
            A4UFID = T000216_A4UFID[0];
            AssignAttri("", false, "A4UFID", StringUtil.LTrimStr( (decimal)(A4UFID), 9, 0));
         }
      }

      protected void ScanEnd022( )
      {
         pr_default.close(14);
      }

      protected void AfterConfirm022( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert022( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate022( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete022( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete022( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate022( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes022( )
      {
         edtUFID_Enabled = 0;
         AssignProp("", false, edtUFID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUFID_Enabled), 5, 0), true);
         edtUFSigla_Enabled = 0;
         AssignProp("", false, edtUFSigla_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUFSigla_Enabled), 5, 0), true);
         edtUFNome_Enabled = 0;
         AssignProp("", false, edtUFNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUFNome_Enabled), 5, 0), true);
         edtUFSiglaNome_Enabled = 0;
         AssignProp("", false, edtUFSiglaNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUFSiglaNome_Enabled), 5, 0), true);
         edtUFRegID_Enabled = 0;
         AssignProp("", false, edtUFRegID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUFRegID_Enabled), 5, 0), true);
         edtavComboufregid_Enabled = 0;
         AssignProp("", false, edtavComboufregid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboufregid_Enabled), 5, 0), true);
         edtUFRegNome_Enabled = 0;
         AssignProp("", false, edtUFRegNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUFRegNome_Enabled), 5, 0), true);
         edtUFRegSiglaNome_Enabled = 0;
         AssignProp("", false, edtUFRegSiglaNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUFRegSiglaNome_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes022( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues020( )
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
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
         GXEncryptionTmp = "core.uf.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7UFID,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("core.uf.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"uf");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("core\\uf:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z4UFID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z4UFID), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z12UFSiglaNome", Z12UFSiglaNome);
         GxWebStd.gx_hidden_field( context, "Z11UFRegSiglaNome", Z11UFRegSiglaNome);
         GxWebStd.gx_hidden_field( context, "Z5UFSigla", Z5UFSigla);
         GxWebStd.gx_hidden_field( context, "Z6UFNome", Z6UFNome);
         GxWebStd.gx_hidden_field( context, "Z8UFRegID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z8UFRegID), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N8UFRegID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A8UFRegID), 9, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV16DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV16DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vUFREGID_DATA", AV15UFRegID_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vUFREGID_DATA", AV15UFRegID_Data);
         }
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV11TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV11TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV11TrnContext, context));
         GxWebStd.gx_hidden_field( context, "UFREGSIGLA", A9UFRegSigla);
         GxWebStd.gx_hidden_field( context, "vUFID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7UFID), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUFID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7UFID), "ZZZ,ZZZ,ZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_UFREGID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13Insert_UFRegID), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV25Pgmname));
         GxWebStd.gx_hidden_field( context, "COMBO_UFREGID_Objectcall", StringUtil.RTrim( Combo_ufregid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_UFREGID_Cls", StringUtil.RTrim( Combo_ufregid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_UFREGID_Selectedvalue_set", StringUtil.RTrim( Combo_ufregid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_UFREGID_Selectedtext_set", StringUtil.RTrim( Combo_ufregid_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_UFREGID_Gamoauthtoken", StringUtil.RTrim( Combo_ufregid_Gamoauthtoken));
         GxWebStd.gx_hidden_field( context, "COMBO_UFREGID_Enabled", StringUtil.BoolToStr( Combo_ufregid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_UFREGID_Datalistproc", StringUtil.RTrim( Combo_ufregid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_UFREGID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_ufregid_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_UFREGID_Emptyitem", StringUtil.BoolToStr( Combo_ufregid_Emptyitem));
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
         GXEncryptionTmp = "core.uf.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7UFID,9,0));
         return formatLink("core.uf.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "core.uf" ;
      }

      public override string GetPgmdesc( )
      {
         return "Unidade Federativa (Estado)" ;
      }

      protected void InitializeNonKey022( )
      {
         A8UFRegID = 0;
         AssignAttri("", false, "A8UFRegID", StringUtil.LTrimStr( (decimal)(A8UFRegID), 9, 0));
         A12UFSiglaNome = "";
         AssignAttri("", false, "A12UFSiglaNome", A12UFSiglaNome);
         A5UFSigla = "";
         AssignAttri("", false, "A5UFSigla", A5UFSigla);
         A6UFNome = "";
         AssignAttri("", false, "A6UFNome", A6UFNome);
         A9UFRegSigla = "";
         AssignAttri("", false, "A9UFRegSigla", A9UFRegSigla);
         A10UFRegNome = "";
         AssignAttri("", false, "A10UFRegNome", A10UFRegNome);
         A11UFRegSiglaNome = "";
         n11UFRegSiglaNome = false;
         AssignAttri("", false, "A11UFRegSiglaNome", A11UFRegSiglaNome);
         n11UFRegSiglaNome = (String.IsNullOrEmpty(StringUtil.RTrim( A11UFRegSiglaNome)) ? true : false);
         Z12UFSiglaNome = "";
         Z11UFRegSiglaNome = "";
         Z5UFSigla = "";
         Z6UFNome = "";
         Z8UFRegID = 0;
      }

      protected void InitAll022( )
      {
         A4UFID = 0;
         AssignAttri("", false, "A4UFID", StringUtil.LTrimStr( (decimal)(A4UFID), 9, 0));
         InitializeNonKey022( ) ;
      }

      protected void StandaloneModalInsert( )
      {
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202382811122", true, true);
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
         context.AddJavascriptSource("core/uf.js", "?202382811124", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtUFID_Internalname = "UFID";
         edtUFSigla_Internalname = "UFSIGLA";
         edtUFNome_Internalname = "UFNOME";
         edtUFSiglaNome_Internalname = "UFSIGLANOME";
         lblTextblockufregid_Internalname = "TEXTBLOCKUFREGID";
         Combo_ufregid_Internalname = "COMBO_UFREGID";
         edtUFRegID_Internalname = "UFREGID";
         divTablesplittedufregid_Internalname = "TABLESPLITTEDUFREGID";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         divTablemain_Internalname = "TABLEMAIN";
         edtavComboufregid_Internalname = "vCOMBOUFREGID";
         divSectionattribute_ufregid_Internalname = "SECTIONATTRIBUTE_UFREGID";
         edtUFRegNome_Internalname = "UFREGNOME";
         edtUFRegSiglaNome_Internalname = "UFREGSIGLANOME";
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
         Form.Caption = "Unidade Federativa (Estado)";
         edtUFRegSiglaNome_Jsonclick = "";
         edtUFRegSiglaNome_Enabled = 0;
         edtUFRegSiglaNome_Visible = 1;
         edtUFRegNome_Jsonclick = "";
         edtUFRegNome_Enabled = 0;
         edtUFRegNome_Visible = 1;
         edtavComboufregid_Jsonclick = "";
         edtavComboufregid_Enabled = 0;
         edtavComboufregid_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtUFRegID_Jsonclick = "";
         edtUFRegID_Enabled = 1;
         edtUFRegID_Visible = 1;
         Combo_ufregid_Emptyitem = Convert.ToBoolean( 0);
         Combo_ufregid_Datalistprocparametersprefix = " \"ComboName\": \"UFRegID\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"UFID\": 0";
         Combo_ufregid_Datalistproc = "core.ufLoadDVCombo";
         Combo_ufregid_Cls = "ExtendedCombo AttributeFL";
         Combo_ufregid_Caption = "";
         Combo_ufregid_Enabled = Convert.ToBoolean( -1);
         edtUFSiglaNome_Jsonclick = "";
         edtUFSiglaNome_Enabled = 0;
         edtUFNome_Jsonclick = "";
         edtUFNome_Enabled = 1;
         edtUFSigla_Jsonclick = "";
         edtUFSigla_Enabled = 1;
         edtUFID_Jsonclick = "";
         edtUFID_Enabled = 1;
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

      public void Valid_Ufsigla( )
      {
         /* Using cursor T000217 */
         pr_default.execute(15, new Object[] {A5UFSigla, A4UFID});
         if ( (pr_default.getStatus(15) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Sigla"}), 1, "UFSIGLA");
            AnyError = 1;
            GX_FocusControl = edtUFSigla_Internalname;
         }
         pr_default.close(15);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Ufregid( )
      {
         n11UFRegSiglaNome = false;
         /* Using cursor T000214 */
         pr_default.execute(12, new Object[] {A8UFRegID});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem("Não existe 'Regiao -> UF'.", "ForeignKeyNotFound", 1, "UFREGID");
            AnyError = 1;
            GX_FocusControl = edtUFRegID_Internalname;
         }
         A9UFRegSigla = T000214_A9UFRegSigla[0];
         A10UFRegNome = T000214_A10UFRegNome[0];
         pr_default.close(12);
         A11UFRegSiglaNome = StringUtil.Trim( A9UFRegSigla) + " - " + StringUtil.Trim( A10UFRegNome);
         n11UFRegSiglaNome = false;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A9UFRegSigla", A9UFRegSigla);
         AssignAttri("", false, "A10UFRegNome", A10UFRegNome);
         AssignAttri("", false, "A11UFRegSiglaNome", A11UFRegSiglaNome);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7UFID',fld:'vUFID',pic:'ZZZ,ZZZ,ZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7UFID',fld:'vUFID',pic:'ZZZ,ZZZ,ZZ9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E12022',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_UFID","{handler:'Valid_Ufid',iparms:[]");
         setEventMetadata("VALID_UFID",",oparms:[]}");
         setEventMetadata("VALID_UFSIGLA","{handler:'Valid_Ufsigla',iparms:[{av:'A5UFSigla',fld:'UFSIGLA',pic:'@!'},{av:'A4UFID',fld:'UFID',pic:'ZZZ,ZZZ,ZZ9'}]");
         setEventMetadata("VALID_UFSIGLA",",oparms:[]}");
         setEventMetadata("VALID_UFNOME","{handler:'Valid_Ufnome',iparms:[]");
         setEventMetadata("VALID_UFNOME",",oparms:[]}");
         setEventMetadata("VALID_UFREGID","{handler:'Valid_Ufregid',iparms:[{av:'A8UFRegID',fld:'UFREGID',pic:'ZZZ,ZZZ,ZZ9'},{av:'A9UFRegSigla',fld:'UFREGSIGLA',pic:'@!'},{av:'A10UFRegNome',fld:'UFREGNOME',pic:''},{av:'A11UFRegSiglaNome',fld:'UFREGSIGLANOME',pic:''}]");
         setEventMetadata("VALID_UFREGID",",oparms:[{av:'A9UFRegSigla',fld:'UFREGSIGLA',pic:'@!'},{av:'A10UFRegNome',fld:'UFREGNOME',pic:''},{av:'A11UFRegSiglaNome',fld:'UFREGSIGLANOME',pic:''}]}");
         setEventMetadata("VALIDV_COMBOUFREGID","{handler:'Validv_Comboufregid',iparms:[]");
         setEventMetadata("VALIDV_COMBOUFREGID",",oparms:[]}");
         setEventMetadata("VALID_UFREGNOME","{handler:'Valid_Ufregnome',iparms:[]");
         setEventMetadata("VALID_UFREGNOME",",oparms:[]}");
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
         pr_default.close(12);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z12UFSiglaNome = "";
         Z11UFRegSiglaNome = "";
         Z5UFSigla = "";
         Z6UFNome = "";
         Combo_ufregid_Selectedvalue_get = "";
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
         A5UFSigla = "";
         A6UFNome = "";
         A12UFSiglaNome = "";
         lblTextblockufregid_Jsonclick = "";
         ucCombo_ufregid = new GXUserControl();
         AV16DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV15UFRegID_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         A10UFRegNome = "";
         A11UFRegSiglaNome = "";
         A9UFRegSigla = "";
         AV25Pgmname = "";
         Combo_ufregid_Objectcall = "";
         Combo_ufregid_Class = "";
         Combo_ufregid_Icontype = "";
         Combo_ufregid_Icon = "";
         Combo_ufregid_Tooltip = "";
         Combo_ufregid_Selectedvalue_set = "";
         Combo_ufregid_Selectedtext_set = "";
         Combo_ufregid_Selectedtext_get = "";
         Combo_ufregid_Gamoauthtoken = "";
         Combo_ufregid_Ddointernalname = "";
         Combo_ufregid_Titlecontrolalign = "";
         Combo_ufregid_Dropdownoptionstype = "";
         Combo_ufregid_Titlecontrolidtoreplace = "";
         Combo_ufregid_Datalisttype = "";
         Combo_ufregid_Datalistfixedvalues = "";
         Combo_ufregid_Remoteservicesparameters = "";
         Combo_ufregid_Htmltemplate = "";
         Combo_ufregid_Multiplevaluestype = "";
         Combo_ufregid_Loadingdata = "";
         Combo_ufregid_Noresultsfound = "";
         Combo_ufregid_Emptyitemtext = "";
         Combo_ufregid_Onlyselectedvalues = "";
         Combo_ufregid_Selectalltext = "";
         Combo_ufregid_Multiplevaluesseparator = "";
         Combo_ufregid_Addnewoptiontext = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode2 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV22GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV23GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV14TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV19Combo_DataJson = "";
         AV17ComboSelectedValue = "";
         AV18ComboSelectedText = "";
         GXt_char2 = "";
         Z9UFRegSigla = "";
         Z10UFRegNome = "";
         T00024_A9UFRegSigla = new string[] {""} ;
         T00024_A10UFRegNome = new string[] {""} ;
         T00025_A12UFSiglaNome = new string[] {""} ;
         T00025_A11UFRegSiglaNome = new string[] {""} ;
         T00025_n11UFRegSiglaNome = new bool[] {false} ;
         T00025_A4UFID = new int[1] ;
         T00025_A5UFSigla = new string[] {""} ;
         T00025_A6UFNome = new string[] {""} ;
         T00025_A9UFRegSigla = new string[] {""} ;
         T00025_A10UFRegNome = new string[] {""} ;
         T00025_A8UFRegID = new int[1] ;
         T00026_A5UFSigla = new string[] {""} ;
         T00027_A9UFRegSigla = new string[] {""} ;
         T00027_A10UFRegNome = new string[] {""} ;
         T00028_A4UFID = new int[1] ;
         T00023_A12UFSiglaNome = new string[] {""} ;
         T00023_A4UFID = new int[1] ;
         T00023_A5UFSigla = new string[] {""} ;
         T00023_A6UFNome = new string[] {""} ;
         T00023_A8UFRegID = new int[1] ;
         T00023_A9UFRegSigla = new string[] {""} ;
         T00023_A10UFRegNome = new string[] {""} ;
         T00023_A11UFRegSiglaNome = new string[] {""} ;
         T00023_n11UFRegSiglaNome = new bool[] {false} ;
         T00029_A4UFID = new int[1] ;
         T000210_A4UFID = new int[1] ;
         T00022_A12UFSiglaNome = new string[] {""} ;
         T00022_A4UFID = new int[1] ;
         T00022_A5UFSigla = new string[] {""} ;
         T00022_A6UFNome = new string[] {""} ;
         T00022_A8UFRegID = new int[1] ;
         T00022_A9UFRegSigla = new string[] {""} ;
         T00022_A10UFRegNome = new string[] {""} ;
         T00022_A11UFRegSiglaNome = new string[] {""} ;
         T00022_n11UFRegSiglaNome = new bool[] {false} ;
         T000214_A9UFRegSigla = new string[] {""} ;
         T000214_A10UFRegNome = new string[] {""} ;
         T000215_A13MesorregiaoID = new int[1] ;
         T000216_A4UFID = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         T000217_A5UFSigla = new string[] {""} ;
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.core.uf__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.uf__default(),
            new Object[][] {
                new Object[] {
               T00022_A12UFSiglaNome, T00022_A4UFID, T00022_A5UFSigla, T00022_A6UFNome, T00022_A8UFRegID, T00022_A9UFRegSigla, T00022_A10UFRegNome, T00022_A11UFRegSiglaNome, T00022_n11UFRegSiglaNome
               }
               , new Object[] {
               T00023_A12UFSiglaNome, T00023_A4UFID, T00023_A5UFSigla, T00023_A6UFNome, T00023_A8UFRegID, T00023_A9UFRegSigla, T00023_A10UFRegNome, T00023_A11UFRegSiglaNome, T00023_n11UFRegSiglaNome
               }
               , new Object[] {
               T00024_A9UFRegSigla, T00024_A10UFRegNome
               }
               , new Object[] {
               T00025_A12UFSiglaNome, T00025_A11UFRegSiglaNome, T00025_n11UFRegSiglaNome, T00025_A4UFID, T00025_A5UFSigla, T00025_A6UFNome, T00025_A9UFRegSigla, T00025_A10UFRegNome, T00025_A8UFRegID
               }
               , new Object[] {
               T00026_A5UFSigla
               }
               , new Object[] {
               T00027_A9UFRegSigla, T00027_A10UFRegNome
               }
               , new Object[] {
               T00028_A4UFID
               }
               , new Object[] {
               T00029_A4UFID
               }
               , new Object[] {
               T000210_A4UFID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000214_A9UFRegSigla, T000214_A10UFRegNome
               }
               , new Object[] {
               T000215_A13MesorregiaoID
               }
               , new Object[] {
               T000216_A4UFID
               }
               , new Object[] {
               T000217_A5UFSigla
               }
            }
         );
         AV25Pgmname = "core.uf";
      }

      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short RcdFound2 ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short nIsDirty_2 ;
      private short gxajaxcallmode ;
      private int wcpOAV7UFID ;
      private int Z4UFID ;
      private int Z8UFRegID ;
      private int N8UFRegID ;
      private int A8UFRegID ;
      private int AV7UFID ;
      private int trnEnded ;
      private int A4UFID ;
      private int edtUFID_Enabled ;
      private int edtUFSigla_Enabled ;
      private int edtUFNome_Enabled ;
      private int edtUFSiglaNome_Enabled ;
      private int edtUFRegID_Visible ;
      private int edtUFRegID_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int AV20ComboUFRegID ;
      private int edtavComboufregid_Enabled ;
      private int edtavComboufregid_Visible ;
      private int edtUFRegNome_Visible ;
      private int edtUFRegNome_Enabled ;
      private int edtUFRegSiglaNome_Visible ;
      private int edtUFRegSiglaNome_Enabled ;
      private int AV13Insert_UFRegID ;
      private int Combo_ufregid_Datalistupdateminimumcharacters ;
      private int Combo_ufregid_Gxcontroltype ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int AV26GXV1 ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Combo_ufregid_Selectedvalue_get ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtUFID_Internalname ;
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
      private string edtUFID_Jsonclick ;
      private string edtUFSigla_Internalname ;
      private string edtUFSigla_Jsonclick ;
      private string edtUFNome_Internalname ;
      private string edtUFNome_Jsonclick ;
      private string edtUFSiglaNome_Internalname ;
      private string edtUFSiglaNome_Jsonclick ;
      private string divTablesplittedufregid_Internalname ;
      private string lblTextblockufregid_Internalname ;
      private string lblTextblockufregid_Jsonclick ;
      private string Combo_ufregid_Caption ;
      private string Combo_ufregid_Cls ;
      private string Combo_ufregid_Datalistproc ;
      private string Combo_ufregid_Datalistprocparametersprefix ;
      private string Combo_ufregid_Internalname ;
      private string edtUFRegID_Internalname ;
      private string edtUFRegID_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_ufregid_Internalname ;
      private string edtavComboufregid_Internalname ;
      private string edtavComboufregid_Jsonclick ;
      private string edtUFRegNome_Internalname ;
      private string edtUFRegNome_Jsonclick ;
      private string edtUFRegSiglaNome_Internalname ;
      private string edtUFRegSiglaNome_Jsonclick ;
      private string AV25Pgmname ;
      private string Combo_ufregid_Objectcall ;
      private string Combo_ufregid_Class ;
      private string Combo_ufregid_Icontype ;
      private string Combo_ufregid_Icon ;
      private string Combo_ufregid_Tooltip ;
      private string Combo_ufregid_Selectedvalue_set ;
      private string Combo_ufregid_Selectedtext_set ;
      private string Combo_ufregid_Selectedtext_get ;
      private string Combo_ufregid_Gamoauthtoken ;
      private string Combo_ufregid_Ddointernalname ;
      private string Combo_ufregid_Titlecontrolalign ;
      private string Combo_ufregid_Dropdownoptionstype ;
      private string Combo_ufregid_Titlecontrolidtoreplace ;
      private string Combo_ufregid_Datalisttype ;
      private string Combo_ufregid_Datalistfixedvalues ;
      private string Combo_ufregid_Remoteservicesparameters ;
      private string Combo_ufregid_Htmltemplate ;
      private string Combo_ufregid_Multiplevaluestype ;
      private string Combo_ufregid_Loadingdata ;
      private string Combo_ufregid_Noresultsfound ;
      private string Combo_ufregid_Emptyitemtext ;
      private string Combo_ufregid_Onlyselectedvalues ;
      private string Combo_ufregid_Selectalltext ;
      private string Combo_ufregid_Multiplevaluesseparator ;
      private string Combo_ufregid_Addnewoptiontext ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string hsh ;
      private string sMode2 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXt_char2 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXEncryptionTmp ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool Combo_ufregid_Emptyitem ;
      private bool n11UFRegSiglaNome ;
      private bool Combo_ufregid_Enabled ;
      private bool Combo_ufregid_Visible ;
      private bool Combo_ufregid_Allowmultipleselection ;
      private bool Combo_ufregid_Isgriditem ;
      private bool Combo_ufregid_Hasdescription ;
      private bool Combo_ufregid_Includeonlyselectedoption ;
      private bool Combo_ufregid_Includeselectalloption ;
      private bool Combo_ufregid_Includeaddnewoption ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private string AV19Combo_DataJson ;
      private string Z12UFSiglaNome ;
      private string Z11UFRegSiglaNome ;
      private string Z5UFSigla ;
      private string Z6UFNome ;
      private string A5UFSigla ;
      private string A6UFNome ;
      private string A12UFSiglaNome ;
      private string A10UFRegNome ;
      private string A11UFRegSiglaNome ;
      private string A9UFRegSigla ;
      private string AV17ComboSelectedValue ;
      private string AV18ComboSelectedText ;
      private string Z9UFRegSigla ;
      private string Z10UFRegNome ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucCombo_ufregid ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T00024_A9UFRegSigla ;
      private string[] T00024_A10UFRegNome ;
      private string[] T00025_A12UFSiglaNome ;
      private string[] T00025_A11UFRegSiglaNome ;
      private bool[] T00025_n11UFRegSiglaNome ;
      private int[] T00025_A4UFID ;
      private string[] T00025_A5UFSigla ;
      private string[] T00025_A6UFNome ;
      private string[] T00025_A9UFRegSigla ;
      private string[] T00025_A10UFRegNome ;
      private int[] T00025_A8UFRegID ;
      private string[] T00026_A5UFSigla ;
      private string[] T00027_A9UFRegSigla ;
      private string[] T00027_A10UFRegNome ;
      private int[] T00028_A4UFID ;
      private string[] T00023_A12UFSiglaNome ;
      private int[] T00023_A4UFID ;
      private string[] T00023_A5UFSigla ;
      private string[] T00023_A6UFNome ;
      private int[] T00023_A8UFRegID ;
      private string[] T00023_A9UFRegSigla ;
      private string[] T00023_A10UFRegNome ;
      private string[] T00023_A11UFRegSiglaNome ;
      private bool[] T00023_n11UFRegSiglaNome ;
      private int[] T00029_A4UFID ;
      private int[] T000210_A4UFID ;
      private string[] T00022_A12UFSiglaNome ;
      private int[] T00022_A4UFID ;
      private string[] T00022_A5UFSigla ;
      private string[] T00022_A6UFNome ;
      private int[] T00022_A8UFRegID ;
      private string[] T00022_A9UFRegSigla ;
      private string[] T00022_A10UFRegNome ;
      private string[] T00022_A11UFRegSiglaNome ;
      private bool[] T00022_n11UFRegSiglaNome ;
      private string[] T000214_A9UFRegSigla ;
      private string[] T000214_A10UFRegNome ;
      private int[] T000215_A13MesorregiaoID ;
      private int[] T000216_A4UFID ;
      private string[] T000217_A5UFSigla ;
      private IDataStoreProvider pr_gam ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV15UFRegID_Data ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV23GAMErrors ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV14TrnContextAtt ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV16DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV22GAMSession ;
   }

   public class uf__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class uf__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[6])
       ,new ForEachCursor(def[7])
       ,new ForEachCursor(def[8])
       ,new UpdateCursor(def[9])
       ,new UpdateCursor(def[10])
       ,new UpdateCursor(def[11])
       ,new ForEachCursor(def[12])
       ,new ForEachCursor(def[13])
       ,new ForEachCursor(def[14])
       ,new ForEachCursor(def[15])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00025;
        prmT00025 = new Object[] {
        new ParDef("UFID",GXType.Int32,9,0)
        };
        Object[] prmT00026;
        prmT00026 = new Object[] {
        new ParDef("UFSigla",GXType.VarChar,2,0) ,
        new ParDef("UFID",GXType.Int32,9,0)
        };
        Object[] prmT00024;
        prmT00024 = new Object[] {
        new ParDef("UFRegID",GXType.Int32,9,0)
        };
        Object[] prmT00027;
        prmT00027 = new Object[] {
        new ParDef("UFRegID",GXType.Int32,9,0)
        };
        Object[] prmT00028;
        prmT00028 = new Object[] {
        new ParDef("UFID",GXType.Int32,9,0)
        };
        Object[] prmT00023;
        prmT00023 = new Object[] {
        new ParDef("UFID",GXType.Int32,9,0)
        };
        Object[] prmT00029;
        prmT00029 = new Object[] {
        new ParDef("UFID",GXType.Int32,9,0)
        };
        Object[] prmT000210;
        prmT000210 = new Object[] {
        new ParDef("UFID",GXType.Int32,9,0)
        };
        Object[] prmT00022;
        prmT00022 = new Object[] {
        new ParDef("UFID",GXType.Int32,9,0)
        };
        Object[] prmT000211;
        prmT000211 = new Object[] {
        new ParDef("UFRegSigla",GXType.VarChar,10,0) ,
        new ParDef("UFRegNome",GXType.VarChar,50,0) ,
        new ParDef("UFSiglaNome",GXType.VarChar,70,0) ,
        new ParDef("UFRegSiglaNome",GXType.VarChar,70,0){Nullable=true} ,
        new ParDef("UFID",GXType.Int32,9,0) ,
        new ParDef("UFSigla",GXType.VarChar,2,0) ,
        new ParDef("UFNome",GXType.VarChar,50,0) ,
        new ParDef("UFRegID",GXType.Int32,9,0)
        };
        Object[] prmT000212;
        prmT000212 = new Object[] {
        new ParDef("UFRegSigla",GXType.VarChar,10,0) ,
        new ParDef("UFRegNome",GXType.VarChar,50,0) ,
        new ParDef("UFSiglaNome",GXType.VarChar,70,0) ,
        new ParDef("UFRegSiglaNome",GXType.VarChar,70,0){Nullable=true} ,
        new ParDef("UFSigla",GXType.VarChar,2,0) ,
        new ParDef("UFNome",GXType.VarChar,50,0) ,
        new ParDef("UFRegID",GXType.Int32,9,0) ,
        new ParDef("UFID",GXType.Int32,9,0)
        };
        Object[] prmT000213;
        prmT000213 = new Object[] {
        new ParDef("UFID",GXType.Int32,9,0)
        };
        Object[] prmT000215;
        prmT000215 = new Object[] {
        new ParDef("UFID",GXType.Int32,9,0)
        };
        Object[] prmT000216;
        prmT000216 = new Object[] {
        };
        Object[] prmT000217;
        prmT000217 = new Object[] {
        new ParDef("UFSigla",GXType.VarChar,2,0) ,
        new ParDef("UFID",GXType.Int32,9,0)
        };
        Object[] prmT000214;
        prmT000214 = new Object[] {
        new ParDef("UFRegID",GXType.Int32,9,0)
        };
        def= new CursorDef[] {
            new CursorDef("T00022", "SELECT UFSiglaNome, UFID, UFSigla, UFNome, UFRegID, UFRegSigla, UFRegNome, UFRegSiglaNome FROM tbibge_uf WHERE UFID = :UFID  FOR UPDATE OF tbibge_uf NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT00022,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00023", "SELECT UFSiglaNome, UFID, UFSigla, UFNome, UFRegID, UFRegSigla, UFRegNome, UFRegSiglaNome FROM tbibge_uf WHERE UFID = :UFID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00023,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00024", "SELECT RegiaoSigla AS UFRegSigla, RegiaoNome AS UFRegNome FROM tbibge_regiao WHERE RegiaoID = :UFRegID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00024,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00025", "SELECT TM1.UFSiglaNome, TM1.UFRegSiglaNome AS UFRegSiglaNome, TM1.UFID, TM1.UFSigla, TM1.UFNome, TM1.UFRegSigla AS UFRegSigla, TM1.UFRegNome AS UFRegNome, TM1.UFRegID AS UFRegID FROM tbibge_uf TM1 WHERE TM1.UFID = :UFID ORDER BY TM1.UFID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00025,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00026", "SELECT UFSigla FROM tbibge_uf WHERE (UFSigla = :UFSigla) AND (Not ( UFID = :UFID)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT00026,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00027", "SELECT RegiaoSigla AS UFRegSigla, RegiaoNome AS UFRegNome FROM tbibge_regiao WHERE RegiaoID = :UFRegID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00027,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00028", "SELECT UFID FROM tbibge_uf WHERE UFID = :UFID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00028,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00029", "SELECT UFID FROM tbibge_uf WHERE ( UFID > :UFID) ORDER BY UFID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00029,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000210", "SELECT UFID FROM tbibge_uf WHERE ( UFID < :UFID) ORDER BY UFID DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000210,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000211", "SAVEPOINT gxupdate;INSERT INTO tbibge_uf(UFRegSigla, UFRegNome, UFSiglaNome, UFRegSiglaNome, UFID, UFSigla, UFNome, UFRegID) VALUES(:UFRegSigla, :UFRegNome, :UFSiglaNome, :UFRegSiglaNome, :UFID, :UFSigla, :UFNome, :UFRegID);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000211)
           ,new CursorDef("T000212", "SAVEPOINT gxupdate;UPDATE tbibge_uf SET UFRegSigla=:UFRegSigla, UFRegNome=:UFRegNome, UFSiglaNome=:UFSiglaNome, UFRegSiglaNome=:UFRegSiglaNome, UFSigla=:UFSigla, UFNome=:UFNome, UFRegID=:UFRegID  WHERE UFID = :UFID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000212)
           ,new CursorDef("T000213", "SAVEPOINT gxupdate;DELETE FROM tbibge_uf  WHERE UFID = :UFID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000213)
           ,new CursorDef("T000214", "SELECT RegiaoSigla AS UFRegSigla, RegiaoNome AS UFRegNome FROM tbibge_regiao WHERE RegiaoID = :UFRegID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000214,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000215", "SELECT MesorregiaoID FROM tbibge_mesorregiao WHERE MesorregiaoUFID = :UFID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000215,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000216", "SELECT UFID FROM tbibge_uf ORDER BY UFID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000216,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000217", "SELECT UFSigla FROM tbibge_uf WHERE (UFSigla = :UFSigla) AND (Not ( UFID = :UFID)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT000217,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((int[]) buf[4])[0] = rslt.getInt(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((bool[]) buf[8])[0] = rslt.wasNull(8);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((int[]) buf[4])[0] = rslt.getInt(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((bool[]) buf[8])[0] = rslt.wasNull(8);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((int[]) buf[3])[0] = rslt.getInt(3);
              ((string[]) buf[4])[0] = rslt.getVarchar(4);
              ((string[]) buf[5])[0] = rslt.getVarchar(5);
              ((string[]) buf[6])[0] = rslt.getVarchar(6);
              ((string[]) buf[7])[0] = rslt.getVarchar(7);
              ((int[]) buf[8])[0] = rslt.getInt(8);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 6 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 7 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 8 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 13 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 14 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
     }
  }

}

}
