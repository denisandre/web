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
   public class clientepjendereco : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_36") == 0 )
         {
            A158CliID = StringUtil.StrToGuid( GetPar( "CliID"));
            AssignAttri("", false, "A158CliID", A158CliID.ToString());
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_36( A158CliID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_37") == 0 )
         {
            A158CliID = StringUtil.StrToGuid( GetPar( "CliID"));
            AssignAttri("", false, "A158CliID", A158CliID.ToString());
            A166CpjID = StringUtil.StrToGuid( GetPar( "CpjID"));
            AssignAttri("", false, "A166CpjID", A166CpjID.ToString());
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_37( A158CliID, A166CpjID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_38") == 0 )
         {
            A365CpjTipoId = (int)(Math.Round(NumberUtil.Val( GetPar( "CpjTipoId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A365CpjTipoId", StringUtil.LTrimStr( (decimal)(A365CpjTipoId), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_38( A365CpjTipoId) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "core.clientepjendereco.aspx")), "core.clientepjendereco.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "core.clientepjendereco.aspx")))) ;
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
                  AV7CliID = StringUtil.StrToGuid( GetPar( "CliID"));
                  AssignAttri("", false, "AV7CliID", AV7CliID.ToString());
                  GxWebStd.gx_hidden_field( context, "gxhash_vCLIID", GetSecureSignedToken( "", AV7CliID, context));
                  AV8CpjID = StringUtil.StrToGuid( GetPar( "CpjID"));
                  AssignAttri("", false, "AV8CpjID", AV8CpjID.ToString());
                  GxWebStd.gx_hidden_field( context, "gxhash_vCPJID", GetSecureSignedToken( "", AV8CpjID, context));
                  AV37CpjEndSeq = (short)(Math.Round(NumberUtil.Val( GetPar( "CpjEndSeq"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV37CpjEndSeq", StringUtil.LTrimStr( (decimal)(AV37CpjEndSeq), 4, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vCPJENDSEQ", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV37CpjEndSeq), "ZZZ9"), context));
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
            Form.Meta.addItem("description", "Endereço", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtCpjEndNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public clientepjendereco( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public clientepjendereco( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           Guid aP1_CliID ,
                           Guid aP2_CpjID ,
                           short aP3_CpjEndSeq )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7CliID = aP1_CliID;
         this.AV8CpjID = aP2_CpjID;
         this.AV37CpjEndSeq = aP3_CpjEndSeq;
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
            return "clientepjendereco_Execute" ;
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-md-9 CellMarginBottom20", "start", "top", "", "", "div");
         /* User Defined Control */
         ucDvpanel_tablecliente.SetProperty("Width", Dvpanel_tablecliente_Width);
         ucDvpanel_tablecliente.SetProperty("AutoWidth", Dvpanel_tablecliente_Autowidth);
         ucDvpanel_tablecliente.SetProperty("AutoHeight", Dvpanel_tablecliente_Autoheight);
         ucDvpanel_tablecliente.SetProperty("Cls", Dvpanel_tablecliente_Cls);
         ucDvpanel_tablecliente.SetProperty("Title", Dvpanel_tablecliente_Title);
         ucDvpanel_tablecliente.SetProperty("Collapsible", Dvpanel_tablecliente_Collapsible);
         ucDvpanel_tablecliente.SetProperty("Collapsed", Dvpanel_tablecliente_Collapsed);
         ucDvpanel_tablecliente.SetProperty("ShowCollapseIcon", Dvpanel_tablecliente_Showcollapseicon);
         ucDvpanel_tablecliente.SetProperty("IconPosition", Dvpanel_tablecliente_Iconposition);
         ucDvpanel_tablecliente.SetProperty("AutoScroll", Dvpanel_tablecliente_Autoscroll);
         ucDvpanel_tablecliente.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tablecliente_Internalname, "DVPANEL_TABLECLIENTEContainer");
         context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLECLIENTEContainer"+"TableCliente"+"\" style=\"display:none;\">") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablecliente_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCliNomeFamiliar_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCliNomeFamiliar_Internalname, "Cliente", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCliNomeFamiliar_Internalname, A160CliNomeFamiliar, StringUtil.RTrim( context.localUtil.Format( A160CliNomeFamiliar, "@!")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliNomeFamiliar_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCliNomeFamiliar_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "core\\Nome", "start", true, "", "HLP_core\\ClientePJEndereco.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCliMatricula_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCliMatricula_Internalname, "Matrícula", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCliMatricula_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A159CliMatricula), 15, 0, ",", "")), StringUtil.LTrim( ((edtCliMatricula_Enabled!=0) ? context.localUtil.Format( (decimal)(A159CliMatricula), "ZZZ,ZZZ,ZZZ,ZZ9") : context.localUtil.Format( (decimal)(A159CliMatricula), "ZZZ,ZZZ,ZZZ,ZZ9"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliMatricula_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCliMatricula_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 0, -1, 0, true, "core\\Matricula", "end", false, "", "HLP_core\\ClientePJEndereco.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-sm hidden-md hidden-lg", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTxtesp01_Internalname, "&nbsp;", "", "", lblTxtesp01_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_core\\ClientePJEndereco.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCpjNomeFan_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCpjNomeFan_Internalname, "Unidade", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCpjNomeFan_Internalname, A170CpjNomeFan, StringUtil.RTrim( context.localUtil.Format( A170CpjNomeFan, "@!")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCpjNomeFan_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCpjNomeFan_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "core\\Nome", "start", true, "", "HLP_core\\ClientePJEndereco.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCpjMatricula_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCpjMatricula_Internalname, "Matrícula", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCpjMatricula_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A176CpjMatricula), 15, 0, ",", "")), StringUtil.LTrim( ((edtCpjMatricula_Enabled!=0) ? context.localUtil.Format( (decimal)(A176CpjMatricula), "ZZZ,ZZZ,ZZZ,ZZ9") : context.localUtil.Format( (decimal)(A176CpjMatricula), "ZZZ,ZZZ,ZZZ,ZZ9"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCpjMatricula_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCpjMatricula_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 0, -1, 0, true, "core\\Matricula", "end", false, "", "HLP_core\\ClientePJEndereco.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCpjCNPJFormat_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCpjCNPJFormat_Internalname, "CNPJ", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCpjCNPJFormat_Internalname, A188CpjCNPJFormat, StringUtil.RTrim( context.localUtil.Format( A188CpjCNPJFormat, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCpjCNPJFormat_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCpjCNPJFormat_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, -1, true, "core\\CNPJFormatado", "start", true, "", "HLP_core\\ClientePJEndereco.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCpjIE_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCpjIE_Internalname, "Inscrição Estadual", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCpjIE_Internalname, A189CpjIE, StringUtil.RTrim( context.localUtil.Format( A189CpjIE, "@!")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCpjIE_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCpjIE_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "core\\InscricaoEstadual", "start", true, "", "HLP_core\\ClientePJEndereco.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCpjTelNum_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCpjTelNum_Internalname, "Telefone", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         if ( context.isSmartDevice( ) )
         {
            gxphoneLink = "tel:" + StringUtil.RTrim( A261CpjTelNum);
         }
         GxWebStd.gx_single_line_edit( context, edtCpjTelNum_Internalname, StringUtil.RTrim( A261CpjTelNum), StringUtil.RTrim( context.localUtil.Format( A261CpjTelNum, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtCpjTelNum_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCpjTelNum_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Phone", "start", true, "", "HLP_core\\ClientePJEndereco.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCpjTelRam_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCpjTelRam_Internalname, "Ramal", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCpjTelRam_Internalname, A262CpjTelRam, StringUtil.RTrim( context.localUtil.Format( A262CpjTelRam, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCpjTelRam_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCpjTelRam_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\ClientePJEndereco.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCpjCelNum_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCpjCelNum_Internalname, "Celular", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         if ( context.isSmartDevice( ) )
         {
            gxphoneLink = "tel:" + StringUtil.RTrim( A263CpjCelNum);
         }
         GxWebStd.gx_single_line_edit( context, edtCpjCelNum_Internalname, StringUtil.RTrim( A263CpjCelNum), StringUtil.RTrim( context.localUtil.Format( A263CpjCelNum, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtCpjCelNum_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCpjCelNum_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Phone", "start", true, "", "HLP_core\\ClientePJEndereco.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCpjWppNum_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCpjWppNum_Internalname, "WhatsApp", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         if ( context.isSmartDevice( ) )
         {
            gxphoneLink = "tel:" + StringUtil.RTrim( A264CpjWppNum);
         }
         GxWebStd.gx_single_line_edit( context, edtCpjWppNum_Internalname, StringUtil.RTrim( A264CpjWppNum), StringUtil.RTrim( context.localUtil.Format( A264CpjWppNum, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtCpjWppNum_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCpjWppNum_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Phone", "start", true, "", "HLP_core\\ClientePJEndereco.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCpjWebsite_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCpjWebsite_Internalname, "Website", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCpjWebsite_Internalname, A265CpjWebsite, StringUtil.RTrim( context.localUtil.Format( A265CpjWebsite, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", A265CpjWebsite, "_blank", "", "", edtCpjWebsite_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCpjWebsite_Enabled, 0, "url", "", 80, "chr", 1, "row", 1000, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Url", "start", true, "", "HLP_core\\ClientePJEndereco.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCpjEmail_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCpjEmail_Internalname, "E-mail", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCpjEmail_Internalname, A266CpjEmail, StringUtil.RTrim( context.localUtil.Format( A266CpjEmail, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "mailto:"+A266CpjEmail, "", "", "", edtCpjEmail_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCpjEmail_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "start", true, "", "HLP_core\\ClientePJEndereco.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-md-9", "start", "top", "", "", "div");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCpjEndNome_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCpjEndNome_Internalname, "Descrição", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCpjEndNome_Internalname, A249CpjEndNome, StringUtil.RTrim( context.localUtil.Format( A249CpjEndNome, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,82);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCpjEndNome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCpjEndNome_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "core\\Nome", "start", true, "", "HLP_core\\ClientePJEndereco.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6 col-sm-3 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCpjEndCepFormat_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCpjEndCepFormat_Internalname, "CEP", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCpjEndCepFormat_Internalname, A251CpjEndCepFormat, StringUtil.RTrim( context.localUtil.Format( A251CpjEndCepFormat, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,86);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCpjEndCepFormat_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCpjEndCepFormat_Enabled, 0, "text", "", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, -1, true, "core\\CEPFormatado", "start", true, "", "HLP_core\\ClientePJEndereco.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCpjEndEndereco_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCpjEndEndereco_Internalname, "Endereço", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCpjEndEndereco_Internalname, A252CpjEndEndereco, StringUtil.RTrim( context.localUtil.Format( A252CpjEndEndereco, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,91);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCpjEndEndereco_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCpjEndEndereco_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\ClientePJEndereco.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCpjEndNumero_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCpjEndNumero_Internalname, "Número", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCpjEndNumero_Internalname, A253CpjEndNumero, StringUtil.RTrim( context.localUtil.Format( A253CpjEndNumero, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,96);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCpjEndNumero_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCpjEndNumero_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\ClientePJEndereco.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 100,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCpjEndComplem_Internalname, A254CpjEndComplem, StringUtil.RTrim( context.localUtil.Format( A254CpjEndComplem, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,100);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCpjEndComplem_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCpjEndComplem_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\ClientePJEndereco.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCpjEndBairro_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCpjEndBairro_Internalname, "Bairro", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCpjEndBairro_Internalname, A255CpjEndBairro, StringUtil.RTrim( context.localUtil.Format( A255CpjEndBairro, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,104);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCpjEndBairro_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCpjEndBairro_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\ClientePJEndereco.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-8 col-sm-9 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCpjEndMunNome_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCpjEndMunNome_Internalname, "Município", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 109,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCpjEndMunNome_Internalname, A257CpjEndMunNome, StringUtil.RTrim( context.localUtil.Format( A257CpjEndMunNome, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,109);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCpjEndMunNome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCpjEndMunNome_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "core\\Nome", "start", true, "", "HLP_core\\ClientePJEndereco.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-4 col-sm-3 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCpjEndUFSigla_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCpjEndUFSigla_Internalname, "UF", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 113,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCpjEndUFSigla_Internalname, A259CpjEndUFSigla, StringUtil.RTrim( context.localUtil.Format( A259CpjEndUFSigla, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,113);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCpjEndUFSigla_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCpjEndUFSigla_Enabled, 0, "text", "", 2, "chr", 1, "row", 2, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\ClientePJEndereco.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 118,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\ClientePJEndereco.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 120,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\ClientePJEndereco.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 124,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCpjEndSeq_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A248CpjEndSeq), 4, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A248CpjEndSeq), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,124);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCpjEndSeq_Jsonclick, 0, "Attribute", "", "", "", "", edtCpjEndSeq_Visible, edtCpjEndSeq_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_core\\ClientePJEndereco.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 125,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCpjEndCep_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A250CpjEndCep), 8, 0, ",", "")), StringUtil.LTrim( ((edtCpjEndCep_Enabled!=0) ? context.localUtil.Format( (decimal)(A250CpjEndCep), "ZZZZZZZ9") : context.localUtil.Format( (decimal)(A250CpjEndCep), "ZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,125);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCpjEndCep_Jsonclick, 0, "Attribute", "", "", "", "", edtCpjEndCep_Visible, edtCpjEndCep_Enabled, 0, "text", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "core\\CEP", "end", false, "", "HLP_core\\ClientePJEndereco.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 126,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCpjEndMunID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A256CpjEndMunID), 7, 0, ",", "")), StringUtil.LTrim( ((edtCpjEndMunID_Enabled!=0) ? context.localUtil.Format( (decimal)(A256CpjEndMunID), "ZZZZZZ9") : context.localUtil.Format( (decimal)(A256CpjEndMunID), "ZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,126);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCpjEndMunID_Jsonclick, 0, "Attribute", "", "", "", "", edtCpjEndMunID_Visible, edtCpjEndMunID_Enabled, 0, "text", "1", 7, "chr", 1, "row", 7, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_core\\ClientePJEndereco.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 127,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCpjEndUFId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A258CpjEndUFId), 2, 0, ",", "")), StringUtil.LTrim( ((edtCpjEndUFId_Enabled!=0) ? context.localUtil.Format( (decimal)(A258CpjEndUFId), "Z9") : context.localUtil.Format( (decimal)(A258CpjEndUFId), "Z9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,127);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCpjEndUFId_Jsonclick, 0, "Attribute", "", "", "", "", edtCpjEndUFId_Visible, edtCpjEndUFId_Enabled, 0, "text", "1", 2, "chr", 1, "row", 2, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_core\\ClientePJEndereco.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 128,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCpjEndUFNome_Internalname, A260CpjEndUFNome, StringUtil.RTrim( context.localUtil.Format( A260CpjEndUFNome, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,128);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCpjEndUFNome_Jsonclick, 0, "Attribute", "", "", "", "", edtCpjEndUFNome_Visible, edtCpjEndUFNome_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "core\\Nome", "start", true, "", "HLP_core\\ClientePJEndereco.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 129,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliID_Internalname, A158CliID.ToString(), A158CliID.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,129);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliID_Jsonclick, 0, "Attribute", "", "", "", "", edtCliID_Visible, edtCliID_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_core\\ClientePJEndereco.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 130,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCpjID_Internalname, A166CpjID.ToString(), A166CpjID.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,130);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCpjID_Jsonclick, 0, "Attribute", "", "", "", "", edtCpjID_Visible, edtCpjID_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_core\\ClientePJEndereco.htm");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCpjTipoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A365CpjTipoId), 11, 0, ",", "")), StringUtil.LTrim( ((edtCpjTipoId_Enabled!=0) ? context.localUtil.Format( (decimal)(A365CpjTipoId), "ZZZ,ZZZ,ZZ9") : context.localUtil.Format( (decimal)(A365CpjTipoId), "ZZZ,ZZZ,ZZ9"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCpjTipoId_Jsonclick, 0, "Attribute", "", "", "", "", edtCpjTipoId_Visible, edtCpjTipoId_Enabled, 0, "text", "", 11, "chr", 1, "row", 11, 0, 0, 0, 0, -1, 0, true, "core\\ID", "end", false, "", "HLP_core\\ClientePJEndereco.htm");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCpjTipoSigla_Internalname, A366CpjTipoSigla, StringUtil.RTrim( context.localUtil.Format( A366CpjTipoSigla, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCpjTipoSigla_Jsonclick, 0, "Attribute", "", "", "", "", edtCpjTipoSigla_Visible, edtCpjTipoSigla_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "core\\Sigla", "start", true, "", "HLP_core\\ClientePJEndereco.htm");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCpjTipoNome_Internalname, A367CpjTipoNome, StringUtil.RTrim( context.localUtil.Format( A367CpjTipoNome, "@!")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCpjTipoNome_Jsonclick, 0, "Attribute", "", "", "", "", edtCpjTipoNome_Visible, edtCpjTipoNome_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "core\\Nome", "start", true, "", "HLP_core\\ClientePJEndereco.htm");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCpjRazaoSoc_Internalname, A171CpjRazaoSoc, StringUtil.RTrim( context.localUtil.Format( A171CpjRazaoSoc, "@!")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCpjRazaoSoc_Jsonclick, 0, "Attribute", "", "", "", "", edtCpjRazaoSoc_Visible, edtCpjRazaoSoc_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "core\\Nome", "start", true, "", "HLP_core\\ClientePJEndereco.htm");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCpjCNPJ_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A187CpjCNPJ), 14, 0, ",", "")), StringUtil.LTrim( ((edtCpjCNPJ_Enabled!=0) ? context.localUtil.Format( (decimal)(A187CpjCNPJ), "ZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A187CpjCNPJ), "ZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCpjCNPJ_Jsonclick, 0, "Attribute", "", "", "", "", edtCpjCNPJ_Visible, edtCpjCNPJ_Enabled, 0, "text", "1", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "core\\CNPJ", "end", false, "", "HLP_core\\ClientePJEndereco.htm");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCpjAtivo_Internalname, StringUtil.BoolToStr( A207CpjAtivo), StringUtil.BoolToStr( A207CpjAtivo), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCpjAtivo_Jsonclick, 0, "Attribute", "", "", "", "", edtCpjAtivo_Visible, edtCpjAtivo_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 0, 0, 0, true, "core\\Ativo", "end", false, "", "HLP_core\\ClientePJEndereco.htm");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCpjUltEndSeq_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A267CpjUltEndSeq), 4, 0, ",", "")), StringUtil.LTrim( ((edtCpjUltEndSeq_Enabled!=0) ? context.localUtil.Format( (decimal)(A267CpjUltEndSeq), "ZZZ9") : context.localUtil.Format( (decimal)(A267CpjUltEndSeq), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCpjUltEndSeq_Jsonclick, 0, "Attribute", "", "", "", "", edtCpjUltEndSeq_Visible, edtCpjUltEndSeq_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_core\\ClientePJEndereco.htm");
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
         E11112 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z158CliID = StringUtil.StrToGuid( cgiGet( "Z158CliID"));
               Z166CpjID = StringUtil.StrToGuid( cgiGet( "Z166CpjID"));
               Z248CpjEndSeq = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z248CpjEndSeq"), ",", "."), 18, MidpointRounding.ToEven));
               Z555CpjEndDelDataHora = context.localUtil.CToT( cgiGet( "Z555CpjEndDelDataHora"), 0);
               n555CpjEndDelDataHora = ((DateTime.MinValue==A555CpjEndDelDataHora) ? true : false);
               Z556CpjEndDelData = context.localUtil.CToT( cgiGet( "Z556CpjEndDelData"), 0);
               n556CpjEndDelData = ((DateTime.MinValue==A556CpjEndDelData) ? true : false);
               Z557CpjEndDelHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z557CpjEndDelHora"), 0));
               n557CpjEndDelHora = ((DateTime.MinValue==A557CpjEndDelHora) ? true : false);
               Z558CpjEndDelUsuId = cgiGet( "Z558CpjEndDelUsuId");
               n558CpjEndDelUsuId = (String.IsNullOrEmpty(StringUtil.RTrim( A558CpjEndDelUsuId)) ? true : false);
               Z559CpjEndDelUsuNome = cgiGet( "Z559CpjEndDelUsuNome");
               n559CpjEndDelUsuNome = (String.IsNullOrEmpty(StringUtil.RTrim( A559CpjEndDelUsuNome)) ? true : false);
               Z249CpjEndNome = cgiGet( "Z249CpjEndNome");
               Z250CpjEndCep = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z250CpjEndCep"), ",", "."), 18, MidpointRounding.ToEven));
               Z251CpjEndCepFormat = cgiGet( "Z251CpjEndCepFormat");
               Z252CpjEndEndereco = cgiGet( "Z252CpjEndEndereco");
               Z253CpjEndNumero = cgiGet( "Z253CpjEndNumero");
               Z254CpjEndComplem = cgiGet( "Z254CpjEndComplem");
               n254CpjEndComplem = (String.IsNullOrEmpty(StringUtil.RTrim( A254CpjEndComplem)) ? true : false);
               Z255CpjEndBairro = cgiGet( "Z255CpjEndBairro");
               Z256CpjEndMunID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z256CpjEndMunID"), ",", "."), 18, MidpointRounding.ToEven));
               Z257CpjEndMunNome = cgiGet( "Z257CpjEndMunNome");
               Z258CpjEndUFId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z258CpjEndUFId"), ",", "."), 18, MidpointRounding.ToEven));
               Z259CpjEndUFSigla = cgiGet( "Z259CpjEndUFSigla");
               Z260CpjEndUFNome = cgiGet( "Z260CpjEndUFNome");
               Z554CpjEndDel = StringUtil.StrToBool( cgiGet( "Z554CpjEndDel"));
               Z170CpjNomeFan = cgiGet( "Z170CpjNomeFan");
               Z171CpjRazaoSoc = cgiGet( "Z171CpjRazaoSoc");
               Z176CpjMatricula = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z176CpjMatricula"), ",", "."), 18, MidpointRounding.ToEven));
               Z187CpjCNPJ = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z187CpjCNPJ"), ",", "."), 18, MidpointRounding.ToEven));
               Z188CpjCNPJFormat = cgiGet( "Z188CpjCNPJFormat");
               Z189CpjIE = cgiGet( "Z189CpjIE");
               Z207CpjAtivo = StringUtil.StrToBool( cgiGet( "Z207CpjAtivo"));
               Z261CpjTelNum = cgiGet( "Z261CpjTelNum");
               Z262CpjTelRam = cgiGet( "Z262CpjTelRam");
               Z263CpjCelNum = cgiGet( "Z263CpjCelNum");
               Z264CpjWppNum = cgiGet( "Z264CpjWppNum");
               Z265CpjWebsite = cgiGet( "Z265CpjWebsite");
               Z266CpjEmail = cgiGet( "Z266CpjEmail");
               Z365CpjTipoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z365CpjTipoId"), ",", "."), 18, MidpointRounding.ToEven));
               A555CpjEndDelDataHora = context.localUtil.CToT( cgiGet( "Z555CpjEndDelDataHora"), 0);
               n555CpjEndDelDataHora = false;
               n555CpjEndDelDataHora = ((DateTime.MinValue==A555CpjEndDelDataHora) ? true : false);
               A556CpjEndDelData = context.localUtil.CToT( cgiGet( "Z556CpjEndDelData"), 0);
               n556CpjEndDelData = false;
               n556CpjEndDelData = ((DateTime.MinValue==A556CpjEndDelData) ? true : false);
               A557CpjEndDelHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z557CpjEndDelHora"), 0));
               n557CpjEndDelHora = false;
               n557CpjEndDelHora = ((DateTime.MinValue==A557CpjEndDelHora) ? true : false);
               A558CpjEndDelUsuId = cgiGet( "Z558CpjEndDelUsuId");
               n558CpjEndDelUsuId = false;
               n558CpjEndDelUsuId = (String.IsNullOrEmpty(StringUtil.RTrim( A558CpjEndDelUsuId)) ? true : false);
               A559CpjEndDelUsuNome = cgiGet( "Z559CpjEndDelUsuNome");
               n559CpjEndDelUsuNome = false;
               n559CpjEndDelUsuNome = (String.IsNullOrEmpty(StringUtil.RTrim( A559CpjEndDelUsuNome)) ? true : false);
               A554CpjEndDel = StringUtil.StrToBool( cgiGet( "Z554CpjEndDel"));
               O554CpjEndDel = StringUtil.StrToBool( cgiGet( "O554CpjEndDel"));
               O267CpjUltEndSeq = (short)(Math.Round(context.localUtil.CToN( cgiGet( "O267CpjUltEndSeq"), ",", "."), 18, MidpointRounding.ToEven));
               n267CpjUltEndSeq = ((0==A267CpjUltEndSeq) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               A368CpjEndCompleto = cgiGet( "CPJENDCOMPLETO");
               AV7CliID = StringUtil.StrToGuid( cgiGet( "vCLIID"));
               AV8CpjID = StringUtil.StrToGuid( cgiGet( "vCPJID"));
               AV37CpjEndSeq = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vCPJENDSEQ"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ",", "."), 18, MidpointRounding.ToEven));
               A554CpjEndDel = StringUtil.StrToBool( cgiGet( "CPJENDDEL"));
               A555CpjEndDelDataHora = context.localUtil.CToT( cgiGet( "CPJENDDELDATAHORA"), 0);
               n555CpjEndDelDataHora = ((DateTime.MinValue==A555CpjEndDelDataHora) ? true : false);
               A556CpjEndDelData = context.localUtil.CToT( cgiGet( "CPJENDDELDATA"), 0);
               n556CpjEndDelData = ((DateTime.MinValue==A556CpjEndDelData) ? true : false);
               A557CpjEndDelHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "CPJENDDELHORA"), 0));
               n557CpjEndDelHora = ((DateTime.MinValue==A557CpjEndDelHora) ? true : false);
               A558CpjEndDelUsuId = cgiGet( "CPJENDDELUSUID");
               n558CpjEndDelUsuId = (String.IsNullOrEmpty(StringUtil.RTrim( A558CpjEndDelUsuId)) ? true : false);
               A559CpjEndDelUsuNome = cgiGet( "CPJENDDELUSUNOME");
               n559CpjEndDelUsuNome = (String.IsNullOrEmpty(StringUtil.RTrim( A559CpjEndDelUsuNome)) ? true : false);
               ajax_req_read_hidden_sdt(cgiGet( "vAUDITINGOBJECT"), AV38AuditingObject);
               AV40Pgmname = cgiGet( "vPGMNAME");
               Dvpanel_tablecliente_Objectcall = cgiGet( "DVPANEL_TABLECLIENTE_Objectcall");
               Dvpanel_tablecliente_Class = cgiGet( "DVPANEL_TABLECLIENTE_Class");
               Dvpanel_tablecliente_Enabled = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECLIENTE_Enabled"));
               Dvpanel_tablecliente_Width = cgiGet( "DVPANEL_TABLECLIENTE_Width");
               Dvpanel_tablecliente_Height = cgiGet( "DVPANEL_TABLECLIENTE_Height");
               Dvpanel_tablecliente_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECLIENTE_Autowidth"));
               Dvpanel_tablecliente_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECLIENTE_Autoheight"));
               Dvpanel_tablecliente_Cls = cgiGet( "DVPANEL_TABLECLIENTE_Cls");
               Dvpanel_tablecliente_Showheader = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECLIENTE_Showheader"));
               Dvpanel_tablecliente_Title = cgiGet( "DVPANEL_TABLECLIENTE_Title");
               Dvpanel_tablecliente_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECLIENTE_Collapsible"));
               Dvpanel_tablecliente_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECLIENTE_Collapsed"));
               Dvpanel_tablecliente_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECLIENTE_Showcollapseicon"));
               Dvpanel_tablecliente_Iconposition = cgiGet( "DVPANEL_TABLECLIENTE_Iconposition");
               Dvpanel_tablecliente_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECLIENTE_Autoscroll"));
               Dvpanel_tablecliente_Visible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECLIENTE_Visible"));
               Dvpanel_tablecliente_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "DVPANEL_TABLECLIENTE_Gxcontroltype"), ",", "."), 18, MidpointRounding.ToEven));
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
               A160CliNomeFamiliar = StringUtil.Upper( cgiGet( edtCliNomeFamiliar_Internalname));
               AssignAttri("", false, "A160CliNomeFamiliar", A160CliNomeFamiliar);
               A159CliMatricula = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtCliMatricula_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A159CliMatricula", StringUtil.LTrimStr( (decimal)(A159CliMatricula), 12, 0));
               A170CpjNomeFan = StringUtil.Upper( cgiGet( edtCpjNomeFan_Internalname));
               AssignAttri("", false, "A170CpjNomeFan", A170CpjNomeFan);
               A176CpjMatricula = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtCpjMatricula_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A176CpjMatricula", StringUtil.LTrimStr( (decimal)(A176CpjMatricula), 12, 0));
               A188CpjCNPJFormat = cgiGet( edtCpjCNPJFormat_Internalname);
               AssignAttri("", false, "A188CpjCNPJFormat", A188CpjCNPJFormat);
               A189CpjIE = StringUtil.Upper( cgiGet( edtCpjIE_Internalname));
               AssignAttri("", false, "A189CpjIE", A189CpjIE);
               A261CpjTelNum = cgiGet( edtCpjTelNum_Internalname);
               n261CpjTelNum = false;
               AssignAttri("", false, "A261CpjTelNum", A261CpjTelNum);
               A262CpjTelRam = cgiGet( edtCpjTelRam_Internalname);
               n262CpjTelRam = false;
               AssignAttri("", false, "A262CpjTelRam", A262CpjTelRam);
               A263CpjCelNum = cgiGet( edtCpjCelNum_Internalname);
               n263CpjCelNum = false;
               AssignAttri("", false, "A263CpjCelNum", A263CpjCelNum);
               A264CpjWppNum = cgiGet( edtCpjWppNum_Internalname);
               n264CpjWppNum = false;
               AssignAttri("", false, "A264CpjWppNum", A264CpjWppNum);
               A265CpjWebsite = cgiGet( edtCpjWebsite_Internalname);
               n265CpjWebsite = false;
               AssignAttri("", false, "A265CpjWebsite", A265CpjWebsite);
               A266CpjEmail = cgiGet( edtCpjEmail_Internalname);
               n266CpjEmail = false;
               AssignAttri("", false, "A266CpjEmail", A266CpjEmail);
               A249CpjEndNome = StringUtil.Upper( cgiGet( edtCpjEndNome_Internalname));
               AssignAttri("", false, "A249CpjEndNome", A249CpjEndNome);
               A251CpjEndCepFormat = cgiGet( edtCpjEndCepFormat_Internalname);
               AssignAttri("", false, "A251CpjEndCepFormat", A251CpjEndCepFormat);
               A252CpjEndEndereco = cgiGet( edtCpjEndEndereco_Internalname);
               AssignAttri("", false, "A252CpjEndEndereco", A252CpjEndEndereco);
               A253CpjEndNumero = cgiGet( edtCpjEndNumero_Internalname);
               AssignAttri("", false, "A253CpjEndNumero", A253CpjEndNumero);
               A254CpjEndComplem = cgiGet( edtCpjEndComplem_Internalname);
               n254CpjEndComplem = false;
               AssignAttri("", false, "A254CpjEndComplem", A254CpjEndComplem);
               n254CpjEndComplem = (String.IsNullOrEmpty(StringUtil.RTrim( A254CpjEndComplem)) ? true : false);
               A255CpjEndBairro = cgiGet( edtCpjEndBairro_Internalname);
               AssignAttri("", false, "A255CpjEndBairro", A255CpjEndBairro);
               A257CpjEndMunNome = StringUtil.Upper( cgiGet( edtCpjEndMunNome_Internalname));
               AssignAttri("", false, "A257CpjEndMunNome", A257CpjEndMunNome);
               A259CpjEndUFSigla = cgiGet( edtCpjEndUFSigla_Internalname);
               AssignAttri("", false, "A259CpjEndUFSigla", A259CpjEndUFSigla);
               if ( ( ( context.localUtil.CToN( cgiGet( edtCpjEndSeq_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCpjEndSeq_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CPJENDSEQ");
                  AnyError = 1;
                  GX_FocusControl = edtCpjEndSeq_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A248CpjEndSeq = 0;
                  AssignAttri("", false, "A248CpjEndSeq", StringUtil.LTrimStr( (decimal)(A248CpjEndSeq), 4, 0));
               }
               else
               {
                  A248CpjEndSeq = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtCpjEndSeq_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A248CpjEndSeq", StringUtil.LTrimStr( (decimal)(A248CpjEndSeq), 4, 0));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtCpjEndCep_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCpjEndCep_Internalname), ",", ".") > Convert.ToDecimal( 99999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CPJENDCEP");
                  AnyError = 1;
                  GX_FocusControl = edtCpjEndCep_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A250CpjEndCep = 0;
                  AssignAttri("", false, "A250CpjEndCep", StringUtil.LTrimStr( (decimal)(A250CpjEndCep), 8, 0));
               }
               else
               {
                  A250CpjEndCep = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtCpjEndCep_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A250CpjEndCep", StringUtil.LTrimStr( (decimal)(A250CpjEndCep), 8, 0));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtCpjEndMunID_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCpjEndMunID_Internalname), ",", ".") > Convert.ToDecimal( 9999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CPJENDMUNID");
                  AnyError = 1;
                  GX_FocusControl = edtCpjEndMunID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A256CpjEndMunID = 0;
                  AssignAttri("", false, "A256CpjEndMunID", StringUtil.LTrimStr( (decimal)(A256CpjEndMunID), 7, 0));
               }
               else
               {
                  A256CpjEndMunID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtCpjEndMunID_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A256CpjEndMunID", StringUtil.LTrimStr( (decimal)(A256CpjEndMunID), 7, 0));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtCpjEndUFId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCpjEndUFId_Internalname), ",", ".") > Convert.ToDecimal( 99 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CPJENDUFID");
                  AnyError = 1;
                  GX_FocusControl = edtCpjEndUFId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A258CpjEndUFId = 0;
                  AssignAttri("", false, "A258CpjEndUFId", StringUtil.LTrimStr( (decimal)(A258CpjEndUFId), 2, 0));
               }
               else
               {
                  A258CpjEndUFId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtCpjEndUFId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A258CpjEndUFId", StringUtil.LTrimStr( (decimal)(A258CpjEndUFId), 2, 0));
               }
               A260CpjEndUFNome = StringUtil.Upper( cgiGet( edtCpjEndUFNome_Internalname));
               AssignAttri("", false, "A260CpjEndUFNome", A260CpjEndUFNome);
               if ( StringUtil.StrCmp(cgiGet( edtCliID_Internalname), "") == 0 )
               {
                  A158CliID = Guid.Empty;
                  AssignAttri("", false, "A158CliID", A158CliID.ToString());
               }
               else
               {
                  try
                  {
                     A158CliID = StringUtil.StrToGuid( cgiGet( edtCliID_Internalname));
                     AssignAttri("", false, "A158CliID", A158CliID.ToString());
                  }
                  catch ( Exception  )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "CLIID");
                     AnyError = 1;
                     GX_FocusControl = edtCliID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     wbErr = true;
                  }
               }
               if ( StringUtil.StrCmp(cgiGet( edtCpjID_Internalname), "") == 0 )
               {
                  A166CpjID = Guid.Empty;
                  AssignAttri("", false, "A166CpjID", A166CpjID.ToString());
               }
               else
               {
                  try
                  {
                     A166CpjID = StringUtil.StrToGuid( cgiGet( edtCpjID_Internalname));
                     AssignAttri("", false, "A166CpjID", A166CpjID.ToString());
                  }
                  catch ( Exception  )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "CPJID");
                     AnyError = 1;
                     GX_FocusControl = edtCpjID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     wbErr = true;
                  }
               }
               A365CpjTipoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtCpjTipoId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A365CpjTipoId", StringUtil.LTrimStr( (decimal)(A365CpjTipoId), 9, 0));
               A366CpjTipoSigla = cgiGet( edtCpjTipoSigla_Internalname);
               AssignAttri("", false, "A366CpjTipoSigla", A366CpjTipoSigla);
               A367CpjTipoNome = StringUtil.Upper( cgiGet( edtCpjTipoNome_Internalname));
               AssignAttri("", false, "A367CpjTipoNome", A367CpjTipoNome);
               A171CpjRazaoSoc = StringUtil.Upper( cgiGet( edtCpjRazaoSoc_Internalname));
               AssignAttri("", false, "A171CpjRazaoSoc", A171CpjRazaoSoc);
               A187CpjCNPJ = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtCpjCNPJ_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A187CpjCNPJ", StringUtil.LTrimStr( (decimal)(A187CpjCNPJ), 14, 0));
               A207CpjAtivo = StringUtil.StrToBool( cgiGet( edtCpjAtivo_Internalname));
               AssignAttri("", false, "A207CpjAtivo", A207CpjAtivo);
               A267CpjUltEndSeq = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtCpjUltEndSeq_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               n267CpjUltEndSeq = false;
               AssignAttri("", false, "A267CpjUltEndSeq", StringUtil.LTrimStr( (decimal)(A267CpjUltEndSeq), 4, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"ClientePJEndereco");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("Pgmname", StringUtil.RTrim( context.localUtil.Format( AV40Pgmname, "")));
               forbiddenHiddens.Add("CpjEndDel", StringUtil.BoolToStr( A554CpjEndDel));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A158CliID != Z158CliID ) || ( A166CpjID != Z166CpjID ) || ( A248CpjEndSeq != Z248CpjEndSeq ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("core\\clientepjendereco:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A158CliID = StringUtil.StrToGuid( GetPar( "CliID"));
                  AssignAttri("", false, "A158CliID", A158CliID.ToString());
                  A166CpjID = StringUtil.StrToGuid( GetPar( "CpjID"));
                  AssignAttri("", false, "A166CpjID", A166CpjID.ToString());
                  A248CpjEndSeq = (short)(Math.Round(NumberUtil.Val( GetPar( "CpjEndSeq"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A248CpjEndSeq", StringUtil.LTrimStr( (decimal)(A248CpjEndSeq), 4, 0));
                  getEqualNoModal( ) ;
                  if ( ! (0==AV37CpjEndSeq) )
                  {
                     A248CpjEndSeq = AV37CpjEndSeq;
                     AssignAttri("", false, "A248CpjEndSeq", StringUtil.LTrimStr( (decimal)(A248CpjEndSeq), 4, 0));
                  }
                  else
                  {
                     if ( IsIns( )  && ( Gx_BScreen == 1 ) )
                     {
                        A248CpjEndSeq = A267CpjUltEndSeq;
                        AssignAttri("", false, "A248CpjEndSeq", StringUtil.LTrimStr( (decimal)(A248CpjEndSeq), 4, 0));
                     }
                  }
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  disable_std_buttons( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  if ( IsDsp( ) )
                  {
                     sMode31 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     if ( ! (0==AV37CpjEndSeq) )
                     {
                        A248CpjEndSeq = AV37CpjEndSeq;
                        AssignAttri("", false, "A248CpjEndSeq", StringUtil.LTrimStr( (decimal)(A248CpjEndSeq), 4, 0));
                     }
                     else
                     {
                        if ( IsIns( )  && ( Gx_BScreen == 1 ) )
                        {
                           A248CpjEndSeq = A267CpjUltEndSeq;
                           AssignAttri("", false, "A248CpjEndSeq", StringUtil.LTrimStr( (decimal)(A248CpjEndSeq), 4, 0));
                        }
                     }
                     Gx_mode = sMode31;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound31 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_110( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "CLIID");
                        AnyError = 1;
                        GX_FocusControl = edtCliID_Internalname;
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
                           E11112 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12112 ();
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
            E12112 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll1131( ) ;
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
            DisableAttributes1131( ) ;
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

      protected void CONFIRM_110( )
      {
         BeforeValidate1131( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1131( ) ;
            }
            else
            {
               CheckExtendedTable1131( ) ;
               CloseExtendedTableCursors1131( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption110( )
      {
      }

      protected void E11112( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         AV13WebSession.Remove("CLIID");
         AV13WebSession.Remove("CPJID");
         AV13WebSession.Remove("CPJENDSEQ");
         AV13WebSession.Remove("CPJENDNOME");
         this.executeExternalObjectMethod("", false, "WWPActions", "Mask_ApplyMultipleMasks", new Object[] {(string)edtCpjEndCepFormat_Internalname,(string)"99999",(string)"99999-999",(string)"",(bool)false,(bool)false}, false);
         AV12TrnContext.FromXml(AV13WebSession.Get("TrnContext"), null, "", "");
         edtCpjEndSeq_Visible = 0;
         AssignProp("", false, edtCpjEndSeq_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCpjEndSeq_Visible), 5, 0), true);
         edtCpjEndCep_Visible = 0;
         AssignProp("", false, edtCpjEndCep_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCpjEndCep_Visible), 5, 0), true);
         edtCpjEndMunID_Visible = 0;
         AssignProp("", false, edtCpjEndMunID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCpjEndMunID_Visible), 5, 0), true);
         edtCpjEndUFId_Visible = 0;
         AssignProp("", false, edtCpjEndUFId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCpjEndUFId_Visible), 5, 0), true);
         edtCpjEndUFNome_Visible = 0;
         AssignProp("", false, edtCpjEndUFNome_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCpjEndUFNome_Visible), 5, 0), true);
         edtCliID_Visible = 0;
         AssignProp("", false, edtCliID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCliID_Visible), 5, 0), true);
         edtCpjID_Visible = 0;
         AssignProp("", false, edtCpjID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCpjID_Visible), 5, 0), true);
         edtCpjTipoId_Visible = 0;
         AssignProp("", false, edtCpjTipoId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCpjTipoId_Visible), 5, 0), true);
         edtCpjTipoSigla_Visible = 0;
         AssignProp("", false, edtCpjTipoSigla_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCpjTipoSigla_Visible), 5, 0), true);
         edtCpjTipoNome_Visible = 0;
         AssignProp("", false, edtCpjTipoNome_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCpjTipoNome_Visible), 5, 0), true);
         edtCpjRazaoSoc_Visible = 0;
         AssignProp("", false, edtCpjRazaoSoc_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCpjRazaoSoc_Visible), 5, 0), true);
         edtCpjCNPJ_Visible = 0;
         AssignProp("", false, edtCpjCNPJ_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCpjCNPJ_Visible), 5, 0), true);
         edtCpjAtivo_Visible = 0;
         AssignProp("", false, edtCpjAtivo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCpjAtivo_Visible), 5, 0), true);
         edtCpjUltEndSeq_Visible = 0;
         AssignProp("", false, edtCpjUltEndSeq_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCpjUltEndSeq_Visible), 5, 0), true);
      }

      protected void E12112( )
      {
         /* After Trn Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.audittransaction(context ).execute(  AV38AuditingObject,  AV40Pgmname) ;
         AV13WebSession.Set("CLIID", StringUtil.Trim( A158CliID.ToString()));
         AV13WebSession.Set("CPJID", StringUtil.Trim( A166CpjID.ToString()));
         AV13WebSession.Set("CPJENDSEQ", StringUtil.Trim( StringUtil.Str( (decimal)(A248CpjEndSeq), 4, 0)));
         AV13WebSession.Set("CPJENDNOME", A249CpjEndNome);
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
         /*  Sending Event outputs  */
      }

      protected void ZM1131( short GX_JID )
      {
         if ( ( GX_JID == 35 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z555CpjEndDelDataHora = T00113_A555CpjEndDelDataHora[0];
               Z556CpjEndDelData = T00113_A556CpjEndDelData[0];
               Z557CpjEndDelHora = T00113_A557CpjEndDelHora[0];
               Z558CpjEndDelUsuId = T00113_A558CpjEndDelUsuId[0];
               Z559CpjEndDelUsuNome = T00113_A559CpjEndDelUsuNome[0];
               Z249CpjEndNome = T00113_A249CpjEndNome[0];
               Z250CpjEndCep = T00113_A250CpjEndCep[0];
               Z251CpjEndCepFormat = T00113_A251CpjEndCepFormat[0];
               Z252CpjEndEndereco = T00113_A252CpjEndEndereco[0];
               Z253CpjEndNumero = T00113_A253CpjEndNumero[0];
               Z254CpjEndComplem = T00113_A254CpjEndComplem[0];
               Z255CpjEndBairro = T00113_A255CpjEndBairro[0];
               Z256CpjEndMunID = T00113_A256CpjEndMunID[0];
               Z257CpjEndMunNome = T00113_A257CpjEndMunNome[0];
               Z258CpjEndUFId = T00113_A258CpjEndUFId[0];
               Z259CpjEndUFSigla = T00113_A259CpjEndUFSigla[0];
               Z260CpjEndUFNome = T00113_A260CpjEndUFNome[0];
               Z554CpjEndDel = T00113_A554CpjEndDel[0];
            }
            else
            {
               Z555CpjEndDelDataHora = A555CpjEndDelDataHora;
               Z556CpjEndDelData = A556CpjEndDelData;
               Z557CpjEndDelHora = A557CpjEndDelHora;
               Z558CpjEndDelUsuId = A558CpjEndDelUsuId;
               Z559CpjEndDelUsuNome = A559CpjEndDelUsuNome;
               Z249CpjEndNome = A249CpjEndNome;
               Z250CpjEndCep = A250CpjEndCep;
               Z251CpjEndCepFormat = A251CpjEndCepFormat;
               Z252CpjEndEndereco = A252CpjEndEndereco;
               Z253CpjEndNumero = A253CpjEndNumero;
               Z254CpjEndComplem = A254CpjEndComplem;
               Z255CpjEndBairro = A255CpjEndBairro;
               Z256CpjEndMunID = A256CpjEndMunID;
               Z257CpjEndMunNome = A257CpjEndMunNome;
               Z258CpjEndUFId = A258CpjEndUFId;
               Z259CpjEndUFSigla = A259CpjEndUFSigla;
               Z260CpjEndUFNome = A260CpjEndUFNome;
               Z554CpjEndDel = A554CpjEndDel;
            }
         }
         if ( ( GX_JID == 37 ) || ( GX_JID == 0 ) )
         {
            Z170CpjNomeFan = T00116_A170CpjNomeFan[0];
            Z171CpjRazaoSoc = T00116_A171CpjRazaoSoc[0];
            Z176CpjMatricula = T00116_A176CpjMatricula[0];
            Z187CpjCNPJ = T00116_A187CpjCNPJ[0];
            Z188CpjCNPJFormat = T00116_A188CpjCNPJFormat[0];
            Z189CpjIE = T00116_A189CpjIE[0];
            Z207CpjAtivo = T00116_A207CpjAtivo[0];
            Z261CpjTelNum = T00116_A261CpjTelNum[0];
            Z262CpjTelRam = T00116_A262CpjTelRam[0];
            Z263CpjCelNum = T00116_A263CpjCelNum[0];
            Z264CpjWppNum = T00116_A264CpjWppNum[0];
            Z265CpjWebsite = T00116_A265CpjWebsite[0];
            Z266CpjEmail = T00116_A266CpjEmail[0];
            Z365CpjTipoId = T00116_A365CpjTipoId[0];
         }
         if ( GX_JID == -35 )
         {
            Z248CpjEndSeq = A248CpjEndSeq;
            Z555CpjEndDelDataHora = A555CpjEndDelDataHora;
            Z556CpjEndDelData = A556CpjEndDelData;
            Z557CpjEndDelHora = A557CpjEndDelHora;
            Z558CpjEndDelUsuId = A558CpjEndDelUsuId;
            Z559CpjEndDelUsuNome = A559CpjEndDelUsuNome;
            Z249CpjEndNome = A249CpjEndNome;
            Z250CpjEndCep = A250CpjEndCep;
            Z251CpjEndCepFormat = A251CpjEndCepFormat;
            Z252CpjEndEndereco = A252CpjEndEndereco;
            Z253CpjEndNumero = A253CpjEndNumero;
            Z254CpjEndComplem = A254CpjEndComplem;
            Z255CpjEndBairro = A255CpjEndBairro;
            Z256CpjEndMunID = A256CpjEndMunID;
            Z257CpjEndMunNome = A257CpjEndMunNome;
            Z258CpjEndUFId = A258CpjEndUFId;
            Z259CpjEndUFSigla = A259CpjEndUFSigla;
            Z260CpjEndUFNome = A260CpjEndUFNome;
            Z554CpjEndDel = A554CpjEndDel;
            Z158CliID = A158CliID;
            Z166CpjID = A166CpjID;
            Z159CliMatricula = A159CliMatricula;
            Z160CliNomeFamiliar = A160CliNomeFamiliar;
            Z267CpjUltEndSeq = A267CpjUltEndSeq;
            Z170CpjNomeFan = A170CpjNomeFan;
            Z171CpjRazaoSoc = A171CpjRazaoSoc;
            Z176CpjMatricula = A176CpjMatricula;
            Z187CpjCNPJ = A187CpjCNPJ;
            Z188CpjCNPJFormat = A188CpjCNPJFormat;
            Z189CpjIE = A189CpjIE;
            Z207CpjAtivo = A207CpjAtivo;
            Z261CpjTelNum = A261CpjTelNum;
            Z262CpjTelRam = A262CpjTelRam;
            Z263CpjCelNum = A263CpjCelNum;
            Z264CpjWppNum = A264CpjWppNum;
            Z265CpjWebsite = A265CpjWebsite;
            Z266CpjEmail = A266CpjEmail;
            Z365CpjTipoId = A365CpjTipoId;
            Z366CpjTipoSigla = A366CpjTipoSigla;
            Z367CpjTipoNome = A367CpjTipoNome;
         }
      }

      protected void standaloneNotModal( )
      {
         edtCliNomeFamiliar_Enabled = 0;
         AssignProp("", false, edtCliNomeFamiliar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliNomeFamiliar_Enabled), 5, 0), true);
         edtCliMatricula_Enabled = 0;
         AssignProp("", false, edtCliMatricula_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliMatricula_Enabled), 5, 0), true);
         edtCpjNomeFan_Enabled = 0;
         AssignProp("", false, edtCpjNomeFan_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjNomeFan_Enabled), 5, 0), true);
         edtCpjUltEndSeq_Enabled = 0;
         AssignProp("", false, edtCpjUltEndSeq_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjUltEndSeq_Enabled), 5, 0), true);
         AV40Pgmname = "core.ClientePJEndereco";
         AssignAttri("", false, "AV40Pgmname", AV40Pgmname);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         edtCliNomeFamiliar_Enabled = 0;
         AssignProp("", false, edtCliNomeFamiliar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliNomeFamiliar_Enabled), 5, 0), true);
         edtCliMatricula_Enabled = 0;
         AssignProp("", false, edtCliMatricula_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliMatricula_Enabled), 5, 0), true);
         edtCpjNomeFan_Enabled = 0;
         AssignProp("", false, edtCpjNomeFan_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjNomeFan_Enabled), 5, 0), true);
         edtCpjUltEndSeq_Enabled = 0;
         AssignProp("", false, edtCpjUltEndSeq_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjUltEndSeq_Enabled), 5, 0), true);
         if ( ! (Guid.Empty==AV7CliID) )
         {
            A158CliID = AV7CliID;
            AssignAttri("", false, "A158CliID", A158CliID.ToString());
         }
         if ( ! (Guid.Empty==AV7CliID) )
         {
            edtCliID_Enabled = 0;
            AssignProp("", false, edtCliID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliID_Enabled), 5, 0), true);
         }
         else
         {
            edtCliID_Enabled = 1;
            AssignProp("", false, edtCliID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliID_Enabled), 5, 0), true);
         }
         if ( ! (Guid.Empty==AV7CliID) )
         {
            edtCliID_Enabled = 0;
            AssignProp("", false, edtCliID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliID_Enabled), 5, 0), true);
         }
         if ( ! (Guid.Empty==AV8CpjID) )
         {
            A166CpjID = AV8CpjID;
            AssignAttri("", false, "A166CpjID", A166CpjID.ToString());
         }
         if ( ! (Guid.Empty==AV8CpjID) )
         {
            edtCpjID_Enabled = 0;
            AssignProp("", false, edtCpjID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjID_Enabled), 5, 0), true);
         }
         else
         {
            edtCpjID_Enabled = 1;
            AssignProp("", false, edtCpjID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjID_Enabled), 5, 0), true);
         }
         if ( ! (Guid.Empty==AV8CpjID) )
         {
            edtCpjID_Enabled = 0;
            AssignProp("", false, edtCpjID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjID_Enabled), 5, 0), true);
         }
         if ( ! (0==AV37CpjEndSeq) )
         {
            edtCpjEndSeq_Enabled = 0;
            AssignProp("", false, edtCpjEndSeq_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjEndSeq_Enabled), 5, 0), true);
         }
         else
         {
            edtCpjEndSeq_Enabled = 1;
            AssignProp("", false, edtCpjEndSeq_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjEndSeq_Enabled), 5, 0), true);
         }
         if ( ! (0==AV37CpjEndSeq) )
         {
            edtCpjEndSeq_Enabled = 0;
            AssignProp("", false, edtCpjEndSeq_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjEndSeq_Enabled), 5, 0), true);
         }
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
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T00114 */
            pr_default.execute(2, new Object[] {A158CliID});
            A159CliMatricula = T00114_A159CliMatricula[0];
            AssignAttri("", false, "A159CliMatricula", StringUtil.LTrimStr( (decimal)(A159CliMatricula), 12, 0));
            A160CliNomeFamiliar = T00114_A160CliNomeFamiliar[0];
            AssignAttri("", false, "A160CliNomeFamiliar", A160CliNomeFamiliar);
            pr_default.close(2);
            /* Using cursor T00116 */
            pr_default.execute(4, new Object[] {A158CliID, A166CpjID});
            ZM1131( 37) ;
            A267CpjUltEndSeq = T00116_A267CpjUltEndSeq[0];
            n267CpjUltEndSeq = T00116_n267CpjUltEndSeq[0];
            AssignAttri("", false, "A267CpjUltEndSeq", StringUtil.LTrimStr( (decimal)(A267CpjUltEndSeq), 4, 0));
            A170CpjNomeFan = T00116_A170CpjNomeFan[0];
            AssignAttri("", false, "A170CpjNomeFan", A170CpjNomeFan);
            A171CpjRazaoSoc = T00116_A171CpjRazaoSoc[0];
            AssignAttri("", false, "A171CpjRazaoSoc", A171CpjRazaoSoc);
            A176CpjMatricula = T00116_A176CpjMatricula[0];
            AssignAttri("", false, "A176CpjMatricula", StringUtil.LTrimStr( (decimal)(A176CpjMatricula), 12, 0));
            A187CpjCNPJ = T00116_A187CpjCNPJ[0];
            AssignAttri("", false, "A187CpjCNPJ", StringUtil.LTrimStr( (decimal)(A187CpjCNPJ), 14, 0));
            A188CpjCNPJFormat = T00116_A188CpjCNPJFormat[0];
            AssignAttri("", false, "A188CpjCNPJFormat", A188CpjCNPJFormat);
            A189CpjIE = T00116_A189CpjIE[0];
            AssignAttri("", false, "A189CpjIE", A189CpjIE);
            A207CpjAtivo = T00116_A207CpjAtivo[0];
            AssignAttri("", false, "A207CpjAtivo", A207CpjAtivo);
            A261CpjTelNum = T00116_A261CpjTelNum[0];
            n261CpjTelNum = T00116_n261CpjTelNum[0];
            AssignAttri("", false, "A261CpjTelNum", A261CpjTelNum);
            A262CpjTelRam = T00116_A262CpjTelRam[0];
            n262CpjTelRam = T00116_n262CpjTelRam[0];
            AssignAttri("", false, "A262CpjTelRam", A262CpjTelRam);
            A263CpjCelNum = T00116_A263CpjCelNum[0];
            n263CpjCelNum = T00116_n263CpjCelNum[0];
            AssignAttri("", false, "A263CpjCelNum", A263CpjCelNum);
            A264CpjWppNum = T00116_A264CpjWppNum[0];
            n264CpjWppNum = T00116_n264CpjWppNum[0];
            AssignAttri("", false, "A264CpjWppNum", A264CpjWppNum);
            A265CpjWebsite = T00116_A265CpjWebsite[0];
            n265CpjWebsite = T00116_n265CpjWebsite[0];
            AssignAttri("", false, "A265CpjWebsite", A265CpjWebsite);
            A266CpjEmail = T00116_A266CpjEmail[0];
            n266CpjEmail = T00116_n266CpjEmail[0];
            AssignAttri("", false, "A266CpjEmail", A266CpjEmail);
            A365CpjTipoId = T00116_A365CpjTipoId[0];
            AssignAttri("", false, "A365CpjTipoId", StringUtil.LTrimStr( (decimal)(A365CpjTipoId), 9, 0));
            O267CpjUltEndSeq = A267CpjUltEndSeq;
            n267CpjUltEndSeq = false;
            AssignAttri("", false, "A267CpjUltEndSeq", StringUtil.LTrimStr( (decimal)(A267CpjUltEndSeq), 4, 0));
            pr_default.close(4);
            /* Using cursor T00117 */
            pr_default.execute(5, new Object[] {A365CpjTipoId});
            A366CpjTipoSigla = T00117_A366CpjTipoSigla[0];
            AssignAttri("", false, "A366CpjTipoSigla", A366CpjTipoSigla);
            A367CpjTipoNome = T00117_A367CpjTipoNome[0];
            AssignAttri("", false, "A367CpjTipoNome", A367CpjTipoNome);
            pr_default.close(5);
         }
      }

      protected void Load1131( )
      {
         /* Using cursor T00118 */
         pr_default.execute(6, new Object[] {A158CliID, A166CpjID, A248CpjEndSeq});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound31 = 1;
            A267CpjUltEndSeq = T00118_A267CpjUltEndSeq[0];
            n267CpjUltEndSeq = T00118_n267CpjUltEndSeq[0];
            AssignAttri("", false, "A267CpjUltEndSeq", StringUtil.LTrimStr( (decimal)(A267CpjUltEndSeq), 4, 0));
            A555CpjEndDelDataHora = T00118_A555CpjEndDelDataHora[0];
            n555CpjEndDelDataHora = T00118_n555CpjEndDelDataHora[0];
            A556CpjEndDelData = T00118_A556CpjEndDelData[0];
            n556CpjEndDelData = T00118_n556CpjEndDelData[0];
            A557CpjEndDelHora = T00118_A557CpjEndDelHora[0];
            n557CpjEndDelHora = T00118_n557CpjEndDelHora[0];
            A558CpjEndDelUsuId = T00118_A558CpjEndDelUsuId[0];
            n558CpjEndDelUsuId = T00118_n558CpjEndDelUsuId[0];
            A559CpjEndDelUsuNome = T00118_A559CpjEndDelUsuNome[0];
            n559CpjEndDelUsuNome = T00118_n559CpjEndDelUsuNome[0];
            A159CliMatricula = T00118_A159CliMatricula[0];
            AssignAttri("", false, "A159CliMatricula", StringUtil.LTrimStr( (decimal)(A159CliMatricula), 12, 0));
            A160CliNomeFamiliar = T00118_A160CliNomeFamiliar[0];
            AssignAttri("", false, "A160CliNomeFamiliar", A160CliNomeFamiliar);
            A366CpjTipoSigla = T00118_A366CpjTipoSigla[0];
            AssignAttri("", false, "A366CpjTipoSigla", A366CpjTipoSigla);
            A367CpjTipoNome = T00118_A367CpjTipoNome[0];
            AssignAttri("", false, "A367CpjTipoNome", A367CpjTipoNome);
            A170CpjNomeFan = T00118_A170CpjNomeFan[0];
            AssignAttri("", false, "A170CpjNomeFan", A170CpjNomeFan);
            A171CpjRazaoSoc = T00118_A171CpjRazaoSoc[0];
            AssignAttri("", false, "A171CpjRazaoSoc", A171CpjRazaoSoc);
            A176CpjMatricula = T00118_A176CpjMatricula[0];
            AssignAttri("", false, "A176CpjMatricula", StringUtil.LTrimStr( (decimal)(A176CpjMatricula), 12, 0));
            A187CpjCNPJ = T00118_A187CpjCNPJ[0];
            AssignAttri("", false, "A187CpjCNPJ", StringUtil.LTrimStr( (decimal)(A187CpjCNPJ), 14, 0));
            A188CpjCNPJFormat = T00118_A188CpjCNPJFormat[0];
            AssignAttri("", false, "A188CpjCNPJFormat", A188CpjCNPJFormat);
            A189CpjIE = T00118_A189CpjIE[0];
            AssignAttri("", false, "A189CpjIE", A189CpjIE);
            A207CpjAtivo = T00118_A207CpjAtivo[0];
            AssignAttri("", false, "A207CpjAtivo", A207CpjAtivo);
            A261CpjTelNum = T00118_A261CpjTelNum[0];
            n261CpjTelNum = T00118_n261CpjTelNum[0];
            AssignAttri("", false, "A261CpjTelNum", A261CpjTelNum);
            A262CpjTelRam = T00118_A262CpjTelRam[0];
            n262CpjTelRam = T00118_n262CpjTelRam[0];
            AssignAttri("", false, "A262CpjTelRam", A262CpjTelRam);
            A263CpjCelNum = T00118_A263CpjCelNum[0];
            n263CpjCelNum = T00118_n263CpjCelNum[0];
            AssignAttri("", false, "A263CpjCelNum", A263CpjCelNum);
            A264CpjWppNum = T00118_A264CpjWppNum[0];
            n264CpjWppNum = T00118_n264CpjWppNum[0];
            AssignAttri("", false, "A264CpjWppNum", A264CpjWppNum);
            A265CpjWebsite = T00118_A265CpjWebsite[0];
            n265CpjWebsite = T00118_n265CpjWebsite[0];
            AssignAttri("", false, "A265CpjWebsite", A265CpjWebsite);
            A266CpjEmail = T00118_A266CpjEmail[0];
            n266CpjEmail = T00118_n266CpjEmail[0];
            AssignAttri("", false, "A266CpjEmail", A266CpjEmail);
            A249CpjEndNome = T00118_A249CpjEndNome[0];
            AssignAttri("", false, "A249CpjEndNome", A249CpjEndNome);
            A250CpjEndCep = T00118_A250CpjEndCep[0];
            AssignAttri("", false, "A250CpjEndCep", StringUtil.LTrimStr( (decimal)(A250CpjEndCep), 8, 0));
            A251CpjEndCepFormat = T00118_A251CpjEndCepFormat[0];
            AssignAttri("", false, "A251CpjEndCepFormat", A251CpjEndCepFormat);
            A252CpjEndEndereco = T00118_A252CpjEndEndereco[0];
            AssignAttri("", false, "A252CpjEndEndereco", A252CpjEndEndereco);
            A253CpjEndNumero = T00118_A253CpjEndNumero[0];
            AssignAttri("", false, "A253CpjEndNumero", A253CpjEndNumero);
            A254CpjEndComplem = T00118_A254CpjEndComplem[0];
            n254CpjEndComplem = T00118_n254CpjEndComplem[0];
            AssignAttri("", false, "A254CpjEndComplem", A254CpjEndComplem);
            A255CpjEndBairro = T00118_A255CpjEndBairro[0];
            AssignAttri("", false, "A255CpjEndBairro", A255CpjEndBairro);
            A256CpjEndMunID = T00118_A256CpjEndMunID[0];
            AssignAttri("", false, "A256CpjEndMunID", StringUtil.LTrimStr( (decimal)(A256CpjEndMunID), 7, 0));
            A257CpjEndMunNome = T00118_A257CpjEndMunNome[0];
            AssignAttri("", false, "A257CpjEndMunNome", A257CpjEndMunNome);
            A258CpjEndUFId = T00118_A258CpjEndUFId[0];
            AssignAttri("", false, "A258CpjEndUFId", StringUtil.LTrimStr( (decimal)(A258CpjEndUFId), 2, 0));
            A259CpjEndUFSigla = T00118_A259CpjEndUFSigla[0];
            AssignAttri("", false, "A259CpjEndUFSigla", A259CpjEndUFSigla);
            A260CpjEndUFNome = T00118_A260CpjEndUFNome[0];
            AssignAttri("", false, "A260CpjEndUFNome", A260CpjEndUFNome);
            A554CpjEndDel = T00118_A554CpjEndDel[0];
            A365CpjTipoId = T00118_A365CpjTipoId[0];
            AssignAttri("", false, "A365CpjTipoId", StringUtil.LTrimStr( (decimal)(A365CpjTipoId), 9, 0));
            ZM1131( -35) ;
         }
         pr_default.close(6);
         OnLoadActions1131( ) ;
      }

      protected void OnLoadActions1131( )
      {
         O267CpjUltEndSeq = A267CpjUltEndSeq;
         n267CpjUltEndSeq = false;
         AssignAttri("", false, "A267CpjUltEndSeq", StringUtil.LTrimStr( (decimal)(A267CpjUltEndSeq), 4, 0));
         if ( IsIns( )  )
         {
            A267CpjUltEndSeq = (short)(O267CpjUltEndSeq+1);
            n267CpjUltEndSeq = false;
            AssignAttri("", false, "A267CpjUltEndSeq", StringUtil.LTrimStr( (decimal)(A267CpjUltEndSeq), 4, 0));
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A253CpjEndNumero))) && String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A254CpjEndComplem))) )
         {
            A368CpjEndCompleto = StringUtil.Trim( A252CpjEndEndereco) + " - " + StringUtil.Trim( A255CpjEndBairro) + " - " + StringUtil.Trim( A251CpjEndCepFormat) + " - " + StringUtil.Trim( A257CpjEndMunNome) + " - " + StringUtil.Trim( A259CpjEndUFSigla);
            AssignAttri("", false, "A368CpjEndCompleto", A368CpjEndCompleto);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A253CpjEndNumero))) && String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A254CpjEndComplem))) )
            {
               A368CpjEndCompleto = StringUtil.Trim( A252CpjEndEndereco) + ", " + StringUtil.Trim( A253CpjEndNumero) + " - " + StringUtil.Trim( A255CpjEndBairro) + " - " + StringUtil.Trim( A251CpjEndCepFormat) + " - " + StringUtil.Trim( A257CpjEndMunNome) + " - " + StringUtil.Trim( A259CpjEndUFSigla);
               AssignAttri("", false, "A368CpjEndCompleto", A368CpjEndCompleto);
            }
            else
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A253CpjEndNumero))) && ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A254CpjEndComplem))) )
               {
                  A368CpjEndCompleto = StringUtil.Trim( A252CpjEndEndereco) + ", " + StringUtil.Trim( A253CpjEndNumero) + " - " + StringUtil.Trim( A255CpjEndBairro) + " - " + StringUtil.Trim( A251CpjEndCepFormat) + " - " + StringUtil.Trim( A257CpjEndMunNome) + " - " + StringUtil.Trim( A259CpjEndUFSigla);
                  AssignAttri("", false, "A368CpjEndCompleto", A368CpjEndCompleto);
               }
               else
               {
                  A368CpjEndCompleto = StringUtil.Trim( A252CpjEndEndereco) + ", " + StringUtil.Trim( A253CpjEndNumero) + " " + StringUtil.Trim( A254CpjEndComplem) + " - " + StringUtil.Trim( A255CpjEndBairro) + " - " + StringUtil.Trim( A251CpjEndCepFormat) + " - " + StringUtil.Trim( A257CpjEndMunNome) + " - " + StringUtil.Trim( A259CpjEndUFSigla);
                  AssignAttri("", false, "A368CpjEndCompleto", A368CpjEndCompleto);
               }
            }
         }
         if ( ! (0==AV37CpjEndSeq) )
         {
            A248CpjEndSeq = AV37CpjEndSeq;
            AssignAttri("", false, "A248CpjEndSeq", StringUtil.LTrimStr( (decimal)(A248CpjEndSeq), 4, 0));
         }
         else
         {
            if ( IsIns( )  && ( Gx_BScreen == 1 ) )
            {
               A248CpjEndSeq = A267CpjUltEndSeq;
               AssignAttri("", false, "A248CpjEndSeq", StringUtil.LTrimStr( (decimal)(A248CpjEndSeq), 4, 0));
            }
         }
      }

      protected void CheckExtendedTable1131( )
      {
         nIsDirty_31 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T00114 */
         pr_default.execute(2, new Object[] {A158CliID});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("Não existe ''.", "ForeignKeyNotFound", 1, "CLIID");
            AnyError = 1;
            GX_FocusControl = edtCliID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A159CliMatricula = T00114_A159CliMatricula[0];
         AssignAttri("", false, "A159CliMatricula", StringUtil.LTrimStr( (decimal)(A159CliMatricula), 12, 0));
         A160CliNomeFamiliar = T00114_A160CliNomeFamiliar[0];
         AssignAttri("", false, "A160CliNomeFamiliar", A160CliNomeFamiliar);
         pr_default.close(2);
         /* Using cursor T00116 */
         pr_default.execute(4, new Object[] {A158CliID, A166CpjID});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("Não existe ''.", "ForeignKeyNotFound", 1, "CPJID");
            AnyError = 1;
            GX_FocusControl = edtCliID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A267CpjUltEndSeq = T00116_A267CpjUltEndSeq[0];
         n267CpjUltEndSeq = T00116_n267CpjUltEndSeq[0];
         AssignAttri("", false, "A267CpjUltEndSeq", StringUtil.LTrimStr( (decimal)(A267CpjUltEndSeq), 4, 0));
         A170CpjNomeFan = T00116_A170CpjNomeFan[0];
         AssignAttri("", false, "A170CpjNomeFan", A170CpjNomeFan);
         A171CpjRazaoSoc = T00116_A171CpjRazaoSoc[0];
         AssignAttri("", false, "A171CpjRazaoSoc", A171CpjRazaoSoc);
         A176CpjMatricula = T00116_A176CpjMatricula[0];
         AssignAttri("", false, "A176CpjMatricula", StringUtil.LTrimStr( (decimal)(A176CpjMatricula), 12, 0));
         A187CpjCNPJ = T00116_A187CpjCNPJ[0];
         AssignAttri("", false, "A187CpjCNPJ", StringUtil.LTrimStr( (decimal)(A187CpjCNPJ), 14, 0));
         A188CpjCNPJFormat = T00116_A188CpjCNPJFormat[0];
         AssignAttri("", false, "A188CpjCNPJFormat", A188CpjCNPJFormat);
         A189CpjIE = T00116_A189CpjIE[0];
         AssignAttri("", false, "A189CpjIE", A189CpjIE);
         A207CpjAtivo = T00116_A207CpjAtivo[0];
         AssignAttri("", false, "A207CpjAtivo", A207CpjAtivo);
         A261CpjTelNum = T00116_A261CpjTelNum[0];
         n261CpjTelNum = T00116_n261CpjTelNum[0];
         AssignAttri("", false, "A261CpjTelNum", A261CpjTelNum);
         A262CpjTelRam = T00116_A262CpjTelRam[0];
         n262CpjTelRam = T00116_n262CpjTelRam[0];
         AssignAttri("", false, "A262CpjTelRam", A262CpjTelRam);
         A263CpjCelNum = T00116_A263CpjCelNum[0];
         n263CpjCelNum = T00116_n263CpjCelNum[0];
         AssignAttri("", false, "A263CpjCelNum", A263CpjCelNum);
         A264CpjWppNum = T00116_A264CpjWppNum[0];
         n264CpjWppNum = T00116_n264CpjWppNum[0];
         AssignAttri("", false, "A264CpjWppNum", A264CpjWppNum);
         A265CpjWebsite = T00116_A265CpjWebsite[0];
         n265CpjWebsite = T00116_n265CpjWebsite[0];
         AssignAttri("", false, "A265CpjWebsite", A265CpjWebsite);
         A266CpjEmail = T00116_A266CpjEmail[0];
         n266CpjEmail = T00116_n266CpjEmail[0];
         AssignAttri("", false, "A266CpjEmail", A266CpjEmail);
         A365CpjTipoId = T00116_A365CpjTipoId[0];
         AssignAttri("", false, "A365CpjTipoId", StringUtil.LTrimStr( (decimal)(A365CpjTipoId), 9, 0));
         nIsDirty_31 = 1;
         O267CpjUltEndSeq = A267CpjUltEndSeq;
         n267CpjUltEndSeq = false;
         AssignAttri("", false, "A267CpjUltEndSeq", StringUtil.LTrimStr( (decimal)(A267CpjUltEndSeq), 4, 0));
         pr_default.close(4);
         if ( IsIns( )  )
         {
            nIsDirty_31 = 1;
            A267CpjUltEndSeq = (short)(O267CpjUltEndSeq+1);
            n267CpjUltEndSeq = false;
            AssignAttri("", false, "A267CpjUltEndSeq", StringUtil.LTrimStr( (decimal)(A267CpjUltEndSeq), 4, 0));
         }
         /* Using cursor T00117 */
         pr_default.execute(5, new Object[] {A365CpjTipoId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("Não existe 'Cliente PJ -> Cliente PJ Tipo'.", "ForeignKeyNotFound", 1, "CPJTIPOID");
            AnyError = 1;
         }
         A366CpjTipoSigla = T00117_A366CpjTipoSigla[0];
         AssignAttri("", false, "A366CpjTipoSigla", A366CpjTipoSigla);
         A367CpjTipoNome = T00117_A367CpjTipoNome[0];
         AssignAttri("", false, "A367CpjTipoNome", A367CpjTipoNome);
         pr_default.close(5);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A249CpjEndNome)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Descrição do Endereço", "", "", "", "", "", "", "", ""), 1, "CPJENDNOME");
            AnyError = 1;
            GX_FocusControl = edtCpjEndNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A253CpjEndNumero))) && String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A254CpjEndComplem))) )
         {
            nIsDirty_31 = 1;
            A368CpjEndCompleto = StringUtil.Trim( A252CpjEndEndereco) + " - " + StringUtil.Trim( A255CpjEndBairro) + " - " + StringUtil.Trim( A251CpjEndCepFormat) + " - " + StringUtil.Trim( A257CpjEndMunNome) + " - " + StringUtil.Trim( A259CpjEndUFSigla);
            AssignAttri("", false, "A368CpjEndCompleto", A368CpjEndCompleto);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A253CpjEndNumero))) && String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A254CpjEndComplem))) )
            {
               nIsDirty_31 = 1;
               A368CpjEndCompleto = StringUtil.Trim( A252CpjEndEndereco) + ", " + StringUtil.Trim( A253CpjEndNumero) + " - " + StringUtil.Trim( A255CpjEndBairro) + " - " + StringUtil.Trim( A251CpjEndCepFormat) + " - " + StringUtil.Trim( A257CpjEndMunNome) + " - " + StringUtil.Trim( A259CpjEndUFSigla);
               AssignAttri("", false, "A368CpjEndCompleto", A368CpjEndCompleto);
            }
            else
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A253CpjEndNumero))) && ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A254CpjEndComplem))) )
               {
                  nIsDirty_31 = 1;
                  A368CpjEndCompleto = StringUtil.Trim( A252CpjEndEndereco) + ", " + StringUtil.Trim( A253CpjEndNumero) + " - " + StringUtil.Trim( A255CpjEndBairro) + " - " + StringUtil.Trim( A251CpjEndCepFormat) + " - " + StringUtil.Trim( A257CpjEndMunNome) + " - " + StringUtil.Trim( A259CpjEndUFSigla);
                  AssignAttri("", false, "A368CpjEndCompleto", A368CpjEndCompleto);
               }
               else
               {
                  nIsDirty_31 = 1;
                  A368CpjEndCompleto = StringUtil.Trim( A252CpjEndEndereco) + ", " + StringUtil.Trim( A253CpjEndNumero) + " " + StringUtil.Trim( A254CpjEndComplem) + " - " + StringUtil.Trim( A255CpjEndBairro) + " - " + StringUtil.Trim( A251CpjEndCepFormat) + " - " + StringUtil.Trim( A257CpjEndMunNome) + " - " + StringUtil.Trim( A259CpjEndUFSigla);
                  AssignAttri("", false, "A368CpjEndCompleto", A368CpjEndCompleto);
               }
            }
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A251CpjEndCepFormat)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "CEP Formatado", "", "", "", "", "", "", "", ""), 1, "CPJENDCEPFORMAT");
            AnyError = 1;
            GX_FocusControl = edtCpjEndCepFormat_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A252CpjEndEndereco)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Endereço", "", "", "", "", "", "", "", ""), 1, "CPJENDENDERECO");
            AnyError = 1;
            GX_FocusControl = edtCpjEndEndereco_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A253CpjEndNumero)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Número", "", "", "", "", "", "", "", ""), 1, "CPJENDNUMERO");
            AnyError = 1;
            GX_FocusControl = edtCpjEndNumero_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A255CpjEndBairro)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Bairro", "", "", "", "", "", "", "", ""), 1, "CPJENDBAIRRO");
            AnyError = 1;
            GX_FocusControl = edtCpjEndBairro_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A257CpjEndMunNome)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Nome do Município", "", "", "", "", "", "", "", ""), 1, "CPJENDMUNNOME");
            AnyError = 1;
            GX_FocusControl = edtCpjEndMunNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A259CpjEndUFSigla)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Sigla da UF", "", "", "", "", "", "", "", ""), 1, "CPJENDUFSIGLA");
            AnyError = 1;
            GX_FocusControl = edtCpjEndUFSigla_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! (0==AV37CpjEndSeq) )
         {
            nIsDirty_31 = 1;
            A248CpjEndSeq = AV37CpjEndSeq;
            AssignAttri("", false, "A248CpjEndSeq", StringUtil.LTrimStr( (decimal)(A248CpjEndSeq), 4, 0));
         }
         else
         {
            if ( IsIns( )  && ( Gx_BScreen == 1 ) )
            {
               nIsDirty_31 = 1;
               A248CpjEndSeq = A267CpjUltEndSeq;
               AssignAttri("", false, "A248CpjEndSeq", StringUtil.LTrimStr( (decimal)(A248CpjEndSeq), 4, 0));
            }
         }
      }

      protected void CloseExtendedTableCursors1131( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(5);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_36( Guid A158CliID )
      {
         /* Using cursor T00119 */
         pr_default.execute(7, new Object[] {A158CliID});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem("Não existe ''.", "ForeignKeyNotFound", 1, "CLIID");
            AnyError = 1;
            GX_FocusControl = edtCliID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A159CliMatricula = T00119_A159CliMatricula[0];
         AssignAttri("", false, "A159CliMatricula", StringUtil.LTrimStr( (decimal)(A159CliMatricula), 12, 0));
         A160CliNomeFamiliar = T00119_A160CliNomeFamiliar[0];
         AssignAttri("", false, "A160CliNomeFamiliar", A160CliNomeFamiliar);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A159CliMatricula), 12, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( A160CliNomeFamiliar)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void gxLoad_37( Guid A158CliID ,
                                Guid A166CpjID )
      {
         /* Using cursor T00116 */
         pr_default.execute(4, new Object[] {A158CliID, A166CpjID});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("Não existe ''.", "ForeignKeyNotFound", 1, "CPJID");
            AnyError = 1;
            GX_FocusControl = edtCliID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A267CpjUltEndSeq = T00116_A267CpjUltEndSeq[0];
         n267CpjUltEndSeq = T00116_n267CpjUltEndSeq[0];
         AssignAttri("", false, "A267CpjUltEndSeq", StringUtil.LTrimStr( (decimal)(A267CpjUltEndSeq), 4, 0));
         A170CpjNomeFan = T00116_A170CpjNomeFan[0];
         AssignAttri("", false, "A170CpjNomeFan", A170CpjNomeFan);
         A171CpjRazaoSoc = T00116_A171CpjRazaoSoc[0];
         AssignAttri("", false, "A171CpjRazaoSoc", A171CpjRazaoSoc);
         A176CpjMatricula = T00116_A176CpjMatricula[0];
         AssignAttri("", false, "A176CpjMatricula", StringUtil.LTrimStr( (decimal)(A176CpjMatricula), 12, 0));
         A187CpjCNPJ = T00116_A187CpjCNPJ[0];
         AssignAttri("", false, "A187CpjCNPJ", StringUtil.LTrimStr( (decimal)(A187CpjCNPJ), 14, 0));
         A188CpjCNPJFormat = T00116_A188CpjCNPJFormat[0];
         AssignAttri("", false, "A188CpjCNPJFormat", A188CpjCNPJFormat);
         A189CpjIE = T00116_A189CpjIE[0];
         AssignAttri("", false, "A189CpjIE", A189CpjIE);
         A207CpjAtivo = T00116_A207CpjAtivo[0];
         AssignAttri("", false, "A207CpjAtivo", A207CpjAtivo);
         A261CpjTelNum = T00116_A261CpjTelNum[0];
         n261CpjTelNum = T00116_n261CpjTelNum[0];
         AssignAttri("", false, "A261CpjTelNum", A261CpjTelNum);
         A262CpjTelRam = T00116_A262CpjTelRam[0];
         n262CpjTelRam = T00116_n262CpjTelRam[0];
         AssignAttri("", false, "A262CpjTelRam", A262CpjTelRam);
         A263CpjCelNum = T00116_A263CpjCelNum[0];
         n263CpjCelNum = T00116_n263CpjCelNum[0];
         AssignAttri("", false, "A263CpjCelNum", A263CpjCelNum);
         A264CpjWppNum = T00116_A264CpjWppNum[0];
         n264CpjWppNum = T00116_n264CpjWppNum[0];
         AssignAttri("", false, "A264CpjWppNum", A264CpjWppNum);
         A265CpjWebsite = T00116_A265CpjWebsite[0];
         n265CpjWebsite = T00116_n265CpjWebsite[0];
         AssignAttri("", false, "A265CpjWebsite", A265CpjWebsite);
         A266CpjEmail = T00116_A266CpjEmail[0];
         n266CpjEmail = T00116_n266CpjEmail[0];
         AssignAttri("", false, "A266CpjEmail", A266CpjEmail);
         A365CpjTipoId = T00116_A365CpjTipoId[0];
         AssignAttri("", false, "A365CpjTipoId", StringUtil.LTrimStr( (decimal)(A365CpjTipoId), 9, 0));
         O267CpjUltEndSeq = A267CpjUltEndSeq;
         n267CpjUltEndSeq = false;
         AssignAttri("", false, "A267CpjUltEndSeq", StringUtil.LTrimStr( (decimal)(A267CpjUltEndSeq), 4, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A267CpjUltEndSeq), 4, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( A170CpjNomeFan)+"\""+","+"\""+GXUtil.EncodeJSConstant( A171CpjRazaoSoc)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A176CpjMatricula), 12, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A187CpjCNPJ), 14, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( A188CpjCNPJFormat)+"\""+","+"\""+GXUtil.EncodeJSConstant( A189CpjIE)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.BoolToStr( A207CpjAtivo))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A261CpjTelNum))+"\""+","+"\""+GXUtil.EncodeJSConstant( A262CpjTelRam)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A263CpjCelNum))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A264CpjWppNum))+"\""+","+"\""+GXUtil.EncodeJSConstant( A265CpjWebsite)+"\""+","+"\""+GXUtil.EncodeJSConstant( A266CpjEmail)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A365CpjTipoId), 9, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void gxLoad_38( int A365CpjTipoId )
      {
         /* Using cursor T001110 */
         pr_default.execute(8, new Object[] {A365CpjTipoId});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("Não existe 'Cliente PJ -> Cliente PJ Tipo'.", "ForeignKeyNotFound", 1, "CPJTIPOID");
            AnyError = 1;
         }
         A366CpjTipoSigla = T001110_A366CpjTipoSigla[0];
         AssignAttri("", false, "A366CpjTipoSigla", A366CpjTipoSigla);
         A367CpjTipoNome = T001110_A367CpjTipoNome[0];
         AssignAttri("", false, "A367CpjTipoNome", A367CpjTipoNome);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A366CpjTipoSigla)+"\""+","+"\""+GXUtil.EncodeJSConstant( A367CpjTipoNome)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void GetKey1131( )
      {
         /* Using cursor T001111 */
         pr_default.execute(9, new Object[] {A158CliID, A166CpjID, A248CpjEndSeq});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound31 = 1;
         }
         else
         {
            RcdFound31 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00113 */
         pr_default.execute(1, new Object[] {A158CliID, A166CpjID, A248CpjEndSeq});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1131( 35) ;
            RcdFound31 = 1;
            A248CpjEndSeq = T00113_A248CpjEndSeq[0];
            AssignAttri("", false, "A248CpjEndSeq", StringUtil.LTrimStr( (decimal)(A248CpjEndSeq), 4, 0));
            A555CpjEndDelDataHora = T00113_A555CpjEndDelDataHora[0];
            n555CpjEndDelDataHora = T00113_n555CpjEndDelDataHora[0];
            A556CpjEndDelData = T00113_A556CpjEndDelData[0];
            n556CpjEndDelData = T00113_n556CpjEndDelData[0];
            A557CpjEndDelHora = T00113_A557CpjEndDelHora[0];
            n557CpjEndDelHora = T00113_n557CpjEndDelHora[0];
            A558CpjEndDelUsuId = T00113_A558CpjEndDelUsuId[0];
            n558CpjEndDelUsuId = T00113_n558CpjEndDelUsuId[0];
            A559CpjEndDelUsuNome = T00113_A559CpjEndDelUsuNome[0];
            n559CpjEndDelUsuNome = T00113_n559CpjEndDelUsuNome[0];
            A249CpjEndNome = T00113_A249CpjEndNome[0];
            AssignAttri("", false, "A249CpjEndNome", A249CpjEndNome);
            A250CpjEndCep = T00113_A250CpjEndCep[0];
            AssignAttri("", false, "A250CpjEndCep", StringUtil.LTrimStr( (decimal)(A250CpjEndCep), 8, 0));
            A251CpjEndCepFormat = T00113_A251CpjEndCepFormat[0];
            AssignAttri("", false, "A251CpjEndCepFormat", A251CpjEndCepFormat);
            A252CpjEndEndereco = T00113_A252CpjEndEndereco[0];
            AssignAttri("", false, "A252CpjEndEndereco", A252CpjEndEndereco);
            A253CpjEndNumero = T00113_A253CpjEndNumero[0];
            AssignAttri("", false, "A253CpjEndNumero", A253CpjEndNumero);
            A254CpjEndComplem = T00113_A254CpjEndComplem[0];
            n254CpjEndComplem = T00113_n254CpjEndComplem[0];
            AssignAttri("", false, "A254CpjEndComplem", A254CpjEndComplem);
            A255CpjEndBairro = T00113_A255CpjEndBairro[0];
            AssignAttri("", false, "A255CpjEndBairro", A255CpjEndBairro);
            A256CpjEndMunID = T00113_A256CpjEndMunID[0];
            AssignAttri("", false, "A256CpjEndMunID", StringUtil.LTrimStr( (decimal)(A256CpjEndMunID), 7, 0));
            A257CpjEndMunNome = T00113_A257CpjEndMunNome[0];
            AssignAttri("", false, "A257CpjEndMunNome", A257CpjEndMunNome);
            A258CpjEndUFId = T00113_A258CpjEndUFId[0];
            AssignAttri("", false, "A258CpjEndUFId", StringUtil.LTrimStr( (decimal)(A258CpjEndUFId), 2, 0));
            A259CpjEndUFSigla = T00113_A259CpjEndUFSigla[0];
            AssignAttri("", false, "A259CpjEndUFSigla", A259CpjEndUFSigla);
            A260CpjEndUFNome = T00113_A260CpjEndUFNome[0];
            AssignAttri("", false, "A260CpjEndUFNome", A260CpjEndUFNome);
            A554CpjEndDel = T00113_A554CpjEndDel[0];
            A158CliID = T00113_A158CliID[0];
            AssignAttri("", false, "A158CliID", A158CliID.ToString());
            A166CpjID = T00113_A166CpjID[0];
            AssignAttri("", false, "A166CpjID", A166CpjID.ToString());
            O554CpjEndDel = A554CpjEndDel;
            AssignAttri("", false, "A554CpjEndDel", A554CpjEndDel);
            Z158CliID = A158CliID;
            Z166CpjID = A166CpjID;
            Z248CpjEndSeq = A248CpjEndSeq;
            sMode31 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load1131( ) ;
            if ( AnyError == 1 )
            {
               RcdFound31 = 0;
               InitializeNonKey1131( ) ;
            }
            Gx_mode = sMode31;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound31 = 0;
            InitializeNonKey1131( ) ;
            sMode31 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode31;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1131( ) ;
         if ( RcdFound31 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound31 = 0;
         /* Using cursor T001112 */
         pr_default.execute(10, new Object[] {A158CliID, A166CpjID, A248CpjEndSeq});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( GuidUtil.Compare(T001112_A158CliID[0], A158CliID, 0) < 0 ) || ( T001112_A158CliID[0] == A158CliID ) && ( GuidUtil.Compare(T001112_A166CpjID[0], A166CpjID, 0) < 0 ) || ( T001112_A166CpjID[0] == A166CpjID ) && ( T001112_A158CliID[0] == A158CliID ) && ( T001112_A248CpjEndSeq[0] < A248CpjEndSeq ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( GuidUtil.Compare(T001112_A158CliID[0], A158CliID, 0) > 0 ) || ( T001112_A158CliID[0] == A158CliID ) && ( GuidUtil.Compare(T001112_A166CpjID[0], A166CpjID, 0) > 0 ) || ( T001112_A166CpjID[0] == A166CpjID ) && ( T001112_A158CliID[0] == A158CliID ) && ( T001112_A248CpjEndSeq[0] > A248CpjEndSeq ) ) )
            {
               A158CliID = T001112_A158CliID[0];
               AssignAttri("", false, "A158CliID", A158CliID.ToString());
               A166CpjID = T001112_A166CpjID[0];
               AssignAttri("", false, "A166CpjID", A166CpjID.ToString());
               A248CpjEndSeq = T001112_A248CpjEndSeq[0];
               AssignAttri("", false, "A248CpjEndSeq", StringUtil.LTrimStr( (decimal)(A248CpjEndSeq), 4, 0));
               RcdFound31 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void move_previous( )
      {
         RcdFound31 = 0;
         /* Using cursor T001113 */
         pr_default.execute(11, new Object[] {A158CliID, A166CpjID, A248CpjEndSeq});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( GuidUtil.Compare(T001113_A158CliID[0], A158CliID, 0) > 0 ) || ( T001113_A158CliID[0] == A158CliID ) && ( GuidUtil.Compare(T001113_A166CpjID[0], A166CpjID, 0) > 0 ) || ( T001113_A166CpjID[0] == A166CpjID ) && ( T001113_A158CliID[0] == A158CliID ) && ( T001113_A248CpjEndSeq[0] > A248CpjEndSeq ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( GuidUtil.Compare(T001113_A158CliID[0], A158CliID, 0) < 0 ) || ( T001113_A158CliID[0] == A158CliID ) && ( GuidUtil.Compare(T001113_A166CpjID[0], A166CpjID, 0) < 0 ) || ( T001113_A166CpjID[0] == A166CpjID ) && ( T001113_A158CliID[0] == A158CliID ) && ( T001113_A248CpjEndSeq[0] < A248CpjEndSeq ) ) )
            {
               A158CliID = T001113_A158CliID[0];
               AssignAttri("", false, "A158CliID", A158CliID.ToString());
               A166CpjID = T001113_A166CpjID[0];
               AssignAttri("", false, "A166CpjID", A166CpjID.ToString());
               A248CpjEndSeq = T001113_A248CpjEndSeq[0];
               AssignAttri("", false, "A248CpjEndSeq", StringUtil.LTrimStr( (decimal)(A248CpjEndSeq), 4, 0));
               RcdFound31 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1131( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtCpjEndNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1131( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound31 == 1 )
            {
               if ( ( A158CliID != Z158CliID ) || ( A166CpjID != Z166CpjID ) || ( A248CpjEndSeq != Z248CpjEndSeq ) )
               {
                  A158CliID = Z158CliID;
                  AssignAttri("", false, "A158CliID", A158CliID.ToString());
                  A166CpjID = Z166CpjID;
                  AssignAttri("", false, "A166CpjID", A166CpjID.ToString());
                  A248CpjEndSeq = Z248CpjEndSeq;
                  AssignAttri("", false, "A248CpjEndSeq", StringUtil.LTrimStr( (decimal)(A248CpjEndSeq), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CLIID");
                  AnyError = 1;
                  GX_FocusControl = edtCliID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtCpjEndNome_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update1131( ) ;
                  GX_FocusControl = edtCpjEndNome_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( A158CliID != Z158CliID ) || ( A166CpjID != Z166CpjID ) || ( A248CpjEndSeq != Z248CpjEndSeq ) )
               {
                  /* Insert record */
                  GX_FocusControl = edtCpjEndNome_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1131( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CLIID");
                     AnyError = 1;
                     GX_FocusControl = edtCliID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtCpjEndNome_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1131( ) ;
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
         if ( ( A158CliID != Z158CliID ) || ( A166CpjID != Z166CpjID ) || ( A248CpjEndSeq != Z248CpjEndSeq ) )
         {
            A158CliID = Z158CliID;
            AssignAttri("", false, "A158CliID", A158CliID.ToString());
            A166CpjID = Z166CpjID;
            AssignAttri("", false, "A166CpjID", A166CpjID.ToString());
            A248CpjEndSeq = Z248CpjEndSeq;
            AssignAttri("", false, "A248CpjEndSeq", StringUtil.LTrimStr( (decimal)(A248CpjEndSeq), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CLIID");
            AnyError = 1;
            GX_FocusControl = edtCliID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtCpjEndNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency1131( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00112 */
            pr_default.execute(0, new Object[] {A158CliID, A166CpjID, A248CpjEndSeq});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_clientepj_endereco"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z555CpjEndDelDataHora != T00112_A555CpjEndDelDataHora[0] ) || ( Z556CpjEndDelData != T00112_A556CpjEndDelData[0] ) || ( Z557CpjEndDelHora != T00112_A557CpjEndDelHora[0] ) || ( StringUtil.StrCmp(Z558CpjEndDelUsuId, T00112_A558CpjEndDelUsuId[0]) != 0 ) || ( StringUtil.StrCmp(Z559CpjEndDelUsuNome, T00112_A559CpjEndDelUsuNome[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z249CpjEndNome, T00112_A249CpjEndNome[0]) != 0 ) || ( Z250CpjEndCep != T00112_A250CpjEndCep[0] ) || ( StringUtil.StrCmp(Z251CpjEndCepFormat, T00112_A251CpjEndCepFormat[0]) != 0 ) || ( StringUtil.StrCmp(Z252CpjEndEndereco, T00112_A252CpjEndEndereco[0]) != 0 ) || ( StringUtil.StrCmp(Z253CpjEndNumero, T00112_A253CpjEndNumero[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z254CpjEndComplem, T00112_A254CpjEndComplem[0]) != 0 ) || ( StringUtil.StrCmp(Z255CpjEndBairro, T00112_A255CpjEndBairro[0]) != 0 ) || ( Z256CpjEndMunID != T00112_A256CpjEndMunID[0] ) || ( StringUtil.StrCmp(Z257CpjEndMunNome, T00112_A257CpjEndMunNome[0]) != 0 ) || ( Z258CpjEndUFId != T00112_A258CpjEndUFId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z259CpjEndUFSigla, T00112_A259CpjEndUFSigla[0]) != 0 ) || ( StringUtil.StrCmp(Z260CpjEndUFNome, T00112_A260CpjEndUFNome[0]) != 0 ) || ( Z554CpjEndDel != T00112_A554CpjEndDel[0] ) )
            {
               if ( Z555CpjEndDelDataHora != T00112_A555CpjEndDelDataHora[0] )
               {
                  GXUtil.WriteLog("core.clientepjendereco:[seudo value changed for attri]"+"CpjEndDelDataHora");
                  GXUtil.WriteLogRaw("Old: ",Z555CpjEndDelDataHora);
                  GXUtil.WriteLogRaw("Current: ",T00112_A555CpjEndDelDataHora[0]);
               }
               if ( Z556CpjEndDelData != T00112_A556CpjEndDelData[0] )
               {
                  GXUtil.WriteLog("core.clientepjendereco:[seudo value changed for attri]"+"CpjEndDelData");
                  GXUtil.WriteLogRaw("Old: ",Z556CpjEndDelData);
                  GXUtil.WriteLogRaw("Current: ",T00112_A556CpjEndDelData[0]);
               }
               if ( Z557CpjEndDelHora != T00112_A557CpjEndDelHora[0] )
               {
                  GXUtil.WriteLog("core.clientepjendereco:[seudo value changed for attri]"+"CpjEndDelHora");
                  GXUtil.WriteLogRaw("Old: ",Z557CpjEndDelHora);
                  GXUtil.WriteLogRaw("Current: ",T00112_A557CpjEndDelHora[0]);
               }
               if ( StringUtil.StrCmp(Z558CpjEndDelUsuId, T00112_A558CpjEndDelUsuId[0]) != 0 )
               {
                  GXUtil.WriteLog("core.clientepjendereco:[seudo value changed for attri]"+"CpjEndDelUsuId");
                  GXUtil.WriteLogRaw("Old: ",Z558CpjEndDelUsuId);
                  GXUtil.WriteLogRaw("Current: ",T00112_A558CpjEndDelUsuId[0]);
               }
               if ( StringUtil.StrCmp(Z559CpjEndDelUsuNome, T00112_A559CpjEndDelUsuNome[0]) != 0 )
               {
                  GXUtil.WriteLog("core.clientepjendereco:[seudo value changed for attri]"+"CpjEndDelUsuNome");
                  GXUtil.WriteLogRaw("Old: ",Z559CpjEndDelUsuNome);
                  GXUtil.WriteLogRaw("Current: ",T00112_A559CpjEndDelUsuNome[0]);
               }
               if ( StringUtil.StrCmp(Z249CpjEndNome, T00112_A249CpjEndNome[0]) != 0 )
               {
                  GXUtil.WriteLog("core.clientepjendereco:[seudo value changed for attri]"+"CpjEndNome");
                  GXUtil.WriteLogRaw("Old: ",Z249CpjEndNome);
                  GXUtil.WriteLogRaw("Current: ",T00112_A249CpjEndNome[0]);
               }
               if ( Z250CpjEndCep != T00112_A250CpjEndCep[0] )
               {
                  GXUtil.WriteLog("core.clientepjendereco:[seudo value changed for attri]"+"CpjEndCep");
                  GXUtil.WriteLogRaw("Old: ",Z250CpjEndCep);
                  GXUtil.WriteLogRaw("Current: ",T00112_A250CpjEndCep[0]);
               }
               if ( StringUtil.StrCmp(Z251CpjEndCepFormat, T00112_A251CpjEndCepFormat[0]) != 0 )
               {
                  GXUtil.WriteLog("core.clientepjendereco:[seudo value changed for attri]"+"CpjEndCepFormat");
                  GXUtil.WriteLogRaw("Old: ",Z251CpjEndCepFormat);
                  GXUtil.WriteLogRaw("Current: ",T00112_A251CpjEndCepFormat[0]);
               }
               if ( StringUtil.StrCmp(Z252CpjEndEndereco, T00112_A252CpjEndEndereco[0]) != 0 )
               {
                  GXUtil.WriteLog("core.clientepjendereco:[seudo value changed for attri]"+"CpjEndEndereco");
                  GXUtil.WriteLogRaw("Old: ",Z252CpjEndEndereco);
                  GXUtil.WriteLogRaw("Current: ",T00112_A252CpjEndEndereco[0]);
               }
               if ( StringUtil.StrCmp(Z253CpjEndNumero, T00112_A253CpjEndNumero[0]) != 0 )
               {
                  GXUtil.WriteLog("core.clientepjendereco:[seudo value changed for attri]"+"CpjEndNumero");
                  GXUtil.WriteLogRaw("Old: ",Z253CpjEndNumero);
                  GXUtil.WriteLogRaw("Current: ",T00112_A253CpjEndNumero[0]);
               }
               if ( StringUtil.StrCmp(Z254CpjEndComplem, T00112_A254CpjEndComplem[0]) != 0 )
               {
                  GXUtil.WriteLog("core.clientepjendereco:[seudo value changed for attri]"+"CpjEndComplem");
                  GXUtil.WriteLogRaw("Old: ",Z254CpjEndComplem);
                  GXUtil.WriteLogRaw("Current: ",T00112_A254CpjEndComplem[0]);
               }
               if ( StringUtil.StrCmp(Z255CpjEndBairro, T00112_A255CpjEndBairro[0]) != 0 )
               {
                  GXUtil.WriteLog("core.clientepjendereco:[seudo value changed for attri]"+"CpjEndBairro");
                  GXUtil.WriteLogRaw("Old: ",Z255CpjEndBairro);
                  GXUtil.WriteLogRaw("Current: ",T00112_A255CpjEndBairro[0]);
               }
               if ( Z256CpjEndMunID != T00112_A256CpjEndMunID[0] )
               {
                  GXUtil.WriteLog("core.clientepjendereco:[seudo value changed for attri]"+"CpjEndMunID");
                  GXUtil.WriteLogRaw("Old: ",Z256CpjEndMunID);
                  GXUtil.WriteLogRaw("Current: ",T00112_A256CpjEndMunID[0]);
               }
               if ( StringUtil.StrCmp(Z257CpjEndMunNome, T00112_A257CpjEndMunNome[0]) != 0 )
               {
                  GXUtil.WriteLog("core.clientepjendereco:[seudo value changed for attri]"+"CpjEndMunNome");
                  GXUtil.WriteLogRaw("Old: ",Z257CpjEndMunNome);
                  GXUtil.WriteLogRaw("Current: ",T00112_A257CpjEndMunNome[0]);
               }
               if ( Z258CpjEndUFId != T00112_A258CpjEndUFId[0] )
               {
                  GXUtil.WriteLog("core.clientepjendereco:[seudo value changed for attri]"+"CpjEndUFId");
                  GXUtil.WriteLogRaw("Old: ",Z258CpjEndUFId);
                  GXUtil.WriteLogRaw("Current: ",T00112_A258CpjEndUFId[0]);
               }
               if ( StringUtil.StrCmp(Z259CpjEndUFSigla, T00112_A259CpjEndUFSigla[0]) != 0 )
               {
                  GXUtil.WriteLog("core.clientepjendereco:[seudo value changed for attri]"+"CpjEndUFSigla");
                  GXUtil.WriteLogRaw("Old: ",Z259CpjEndUFSigla);
                  GXUtil.WriteLogRaw("Current: ",T00112_A259CpjEndUFSigla[0]);
               }
               if ( StringUtil.StrCmp(Z260CpjEndUFNome, T00112_A260CpjEndUFNome[0]) != 0 )
               {
                  GXUtil.WriteLog("core.clientepjendereco:[seudo value changed for attri]"+"CpjEndUFNome");
                  GXUtil.WriteLogRaw("Old: ",Z260CpjEndUFNome);
                  GXUtil.WriteLogRaw("Current: ",T00112_A260CpjEndUFNome[0]);
               }
               if ( Z554CpjEndDel != T00112_A554CpjEndDel[0] )
               {
                  GXUtil.WriteLog("core.clientepjendereco:[seudo value changed for attri]"+"CpjEndDel");
                  GXUtil.WriteLogRaw("Old: ",Z554CpjEndDel);
                  GXUtil.WriteLogRaw("Current: ",T00112_A554CpjEndDel[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"tb_clientepj_endereco"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
         /* Using cursor T001114 */
         pr_default.execute(12, new Object[] {A158CliID, A166CpjID});
         if ( (pr_default.getStatus(12) == 103) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_clientepj"}), "RecordIsLocked", 1, "");
            AnyError = 1;
            return  ;
         }
         if ( ! IsIns( ) )
         {
            Gx_longc = false;
            if ( false || ( StringUtil.StrCmp(Z170CpjNomeFan, T001114_A170CpjNomeFan[0]) != 0 ) || ( StringUtil.StrCmp(Z171CpjRazaoSoc, T001114_A171CpjRazaoSoc[0]) != 0 ) || ( Z176CpjMatricula != T001114_A176CpjMatricula[0] ) || ( Z187CpjCNPJ != T001114_A187CpjCNPJ[0] ) || ( StringUtil.StrCmp(Z188CpjCNPJFormat, T001114_A188CpjCNPJFormat[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z189CpjIE, T001114_A189CpjIE[0]) != 0 ) || ( Z207CpjAtivo != T001114_A207CpjAtivo[0] ) || ( StringUtil.StrCmp(Z261CpjTelNum, T001114_A261CpjTelNum[0]) != 0 ) || ( StringUtil.StrCmp(Z262CpjTelRam, T001114_A262CpjTelRam[0]) != 0 ) || ( StringUtil.StrCmp(Z263CpjCelNum, T001114_A263CpjCelNum[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z264CpjWppNum, T001114_A264CpjWppNum[0]) != 0 ) || ( StringUtil.StrCmp(Z265CpjWebsite, T001114_A265CpjWebsite[0]) != 0 ) || ( StringUtil.StrCmp(Z266CpjEmail, T001114_A266CpjEmail[0]) != 0 ) || ( Z365CpjTipoId != T001114_A365CpjTipoId[0] ) )
            {
               if ( StringUtil.StrCmp(Z170CpjNomeFan, T001114_A170CpjNomeFan[0]) != 0 )
               {
                  GXUtil.WriteLog("core.clientepjendereco:[seudo value changed for attri]"+"CpjNomeFan");
                  GXUtil.WriteLogRaw("Old: ",Z170CpjNomeFan);
                  GXUtil.WriteLogRaw("Current: ",T001114_A170CpjNomeFan[0]);
               }
               if ( StringUtil.StrCmp(Z171CpjRazaoSoc, T001114_A171CpjRazaoSoc[0]) != 0 )
               {
                  GXUtil.WriteLog("core.clientepjendereco:[seudo value changed for attri]"+"CpjRazaoSoc");
                  GXUtil.WriteLogRaw("Old: ",Z171CpjRazaoSoc);
                  GXUtil.WriteLogRaw("Current: ",T001114_A171CpjRazaoSoc[0]);
               }
               if ( Z176CpjMatricula != T001114_A176CpjMatricula[0] )
               {
                  GXUtil.WriteLog("core.clientepjendereco:[seudo value changed for attri]"+"CpjMatricula");
                  GXUtil.WriteLogRaw("Old: ",Z176CpjMatricula);
                  GXUtil.WriteLogRaw("Current: ",T001114_A176CpjMatricula[0]);
               }
               if ( Z187CpjCNPJ != T001114_A187CpjCNPJ[0] )
               {
                  GXUtil.WriteLog("core.clientepjendereco:[seudo value changed for attri]"+"CpjCNPJ");
                  GXUtil.WriteLogRaw("Old: ",Z187CpjCNPJ);
                  GXUtil.WriteLogRaw("Current: ",T001114_A187CpjCNPJ[0]);
               }
               if ( StringUtil.StrCmp(Z188CpjCNPJFormat, T001114_A188CpjCNPJFormat[0]) != 0 )
               {
                  GXUtil.WriteLog("core.clientepjendereco:[seudo value changed for attri]"+"CpjCNPJFormat");
                  GXUtil.WriteLogRaw("Old: ",Z188CpjCNPJFormat);
                  GXUtil.WriteLogRaw("Current: ",T001114_A188CpjCNPJFormat[0]);
               }
               if ( StringUtil.StrCmp(Z189CpjIE, T001114_A189CpjIE[0]) != 0 )
               {
                  GXUtil.WriteLog("core.clientepjendereco:[seudo value changed for attri]"+"CpjIE");
                  GXUtil.WriteLogRaw("Old: ",Z189CpjIE);
                  GXUtil.WriteLogRaw("Current: ",T001114_A189CpjIE[0]);
               }
               if ( Z207CpjAtivo != T001114_A207CpjAtivo[0] )
               {
                  GXUtil.WriteLog("core.clientepjendereco:[seudo value changed for attri]"+"CpjAtivo");
                  GXUtil.WriteLogRaw("Old: ",Z207CpjAtivo);
                  GXUtil.WriteLogRaw("Current: ",T001114_A207CpjAtivo[0]);
               }
               if ( StringUtil.StrCmp(Z261CpjTelNum, T001114_A261CpjTelNum[0]) != 0 )
               {
                  GXUtil.WriteLog("core.clientepjendereco:[seudo value changed for attri]"+"CpjTelNum");
                  GXUtil.WriteLogRaw("Old: ",Z261CpjTelNum);
                  GXUtil.WriteLogRaw("Current: ",T001114_A261CpjTelNum[0]);
               }
               if ( StringUtil.StrCmp(Z262CpjTelRam, T001114_A262CpjTelRam[0]) != 0 )
               {
                  GXUtil.WriteLog("core.clientepjendereco:[seudo value changed for attri]"+"CpjTelRam");
                  GXUtil.WriteLogRaw("Old: ",Z262CpjTelRam);
                  GXUtil.WriteLogRaw("Current: ",T001114_A262CpjTelRam[0]);
               }
               if ( StringUtil.StrCmp(Z263CpjCelNum, T001114_A263CpjCelNum[0]) != 0 )
               {
                  GXUtil.WriteLog("core.clientepjendereco:[seudo value changed for attri]"+"CpjCelNum");
                  GXUtil.WriteLogRaw("Old: ",Z263CpjCelNum);
                  GXUtil.WriteLogRaw("Current: ",T001114_A263CpjCelNum[0]);
               }
               if ( StringUtil.StrCmp(Z264CpjWppNum, T001114_A264CpjWppNum[0]) != 0 )
               {
                  GXUtil.WriteLog("core.clientepjendereco:[seudo value changed for attri]"+"CpjWppNum");
                  GXUtil.WriteLogRaw("Old: ",Z264CpjWppNum);
                  GXUtil.WriteLogRaw("Current: ",T001114_A264CpjWppNum[0]);
               }
               if ( StringUtil.StrCmp(Z265CpjWebsite, T001114_A265CpjWebsite[0]) != 0 )
               {
                  GXUtil.WriteLog("core.clientepjendereco:[seudo value changed for attri]"+"CpjWebsite");
                  GXUtil.WriteLogRaw("Old: ",Z265CpjWebsite);
                  GXUtil.WriteLogRaw("Current: ",T001114_A265CpjWebsite[0]);
               }
               if ( StringUtil.StrCmp(Z266CpjEmail, T001114_A266CpjEmail[0]) != 0 )
               {
                  GXUtil.WriteLog("core.clientepjendereco:[seudo value changed for attri]"+"CpjEmail");
                  GXUtil.WriteLogRaw("Old: ",Z266CpjEmail);
                  GXUtil.WriteLogRaw("Current: ",T001114_A266CpjEmail[0]);
               }
               if ( Z365CpjTipoId != T001114_A365CpjTipoId[0] )
               {
                  GXUtil.WriteLog("core.clientepjendereco:[seudo value changed for attri]"+"CpjTipoId");
                  GXUtil.WriteLogRaw("Old: ",Z365CpjTipoId);
                  GXUtil.WriteLogRaw("Current: ",T001114_A365CpjTipoId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"tb_clientepj"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1131( )
      {
         if ( ! IsAuthorized("clientepjendereco_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1131( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1131( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1131( 0) ;
            CheckOptimisticConcurrency1131( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1131( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1131( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001115 */
                     pr_default.execute(13, new Object[] {A248CpjEndSeq, n555CpjEndDelDataHora, A555CpjEndDelDataHora, n556CpjEndDelData, A556CpjEndDelData, n557CpjEndDelHora, A557CpjEndDelHora, n558CpjEndDelUsuId, A558CpjEndDelUsuId, n559CpjEndDelUsuNome, A559CpjEndDelUsuNome, A249CpjEndNome, A250CpjEndCep, A251CpjEndCepFormat, A252CpjEndEndereco, A253CpjEndNumero, n254CpjEndComplem, A254CpjEndComplem, A255CpjEndBairro, A256CpjEndMunID, A257CpjEndMunNome, A258CpjEndUFId, A259CpjEndUFSigla, A260CpjEndUFNome, A554CpjEndDel, A158CliID, A166CpjID});
                     pr_default.close(13);
                     pr_default.SmartCacheProvider.SetUpdated("tb_clientepj_endereco");
                     if ( (pr_default.getStatus(13) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        UpdateTablesN11131( ) ;
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption110( ) ;
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
               Load1131( ) ;
            }
            EndLevel1131( ) ;
         }
         CloseExtendedTableCursors1131( ) ;
      }

      protected void Update1131( )
      {
         if ( ! IsAuthorized("clientepjendereco_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1131( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1131( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1131( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1131( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1131( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001116 */
                     pr_default.execute(14, new Object[] {n555CpjEndDelDataHora, A555CpjEndDelDataHora, n556CpjEndDelData, A556CpjEndDelData, n557CpjEndDelHora, A557CpjEndDelHora, n558CpjEndDelUsuId, A558CpjEndDelUsuId, n559CpjEndDelUsuNome, A559CpjEndDelUsuNome, A249CpjEndNome, A250CpjEndCep, A251CpjEndCepFormat, A252CpjEndEndereco, A253CpjEndNumero, n254CpjEndComplem, A254CpjEndComplem, A255CpjEndBairro, A256CpjEndMunID, A257CpjEndMunNome, A258CpjEndUFId, A259CpjEndUFSigla, A260CpjEndUFNome, A554CpjEndDel, A158CliID, A166CpjID, A248CpjEndSeq});
                     pr_default.close(14);
                     pr_default.SmartCacheProvider.SetUpdated("tb_clientepj_endereco");
                     if ( (pr_default.getStatus(14) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_clientepj_endereco"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1131( ) ;
                     if ( AnyError == 0 )
                     {
                        UpdateTablesN11131( ) ;
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
            EndLevel1131( ) ;
         }
         CloseExtendedTableCursors1131( ) ;
      }

      protected void DeferredUpdate1131( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("clientepjendereco_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1131( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1131( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1131( ) ;
            AfterConfirm1131( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1131( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001117 */
                  pr_default.execute(15, new Object[] {A158CliID, A166CpjID, A248CpjEndSeq});
                  pr_default.close(15);
                  pr_default.SmartCacheProvider.SetUpdated("tb_clientepj_endereco");
                  if ( AnyError == 0 )
                  {
                     UpdateTablesN11131( ) ;
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
         sMode31 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1131( ) ;
         Gx_mode = sMode31;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1131( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T001118 */
            pr_default.execute(16, new Object[] {A158CliID});
            A159CliMatricula = T001118_A159CliMatricula[0];
            AssignAttri("", false, "A159CliMatricula", StringUtil.LTrimStr( (decimal)(A159CliMatricula), 12, 0));
            A160CliNomeFamiliar = T001118_A160CliNomeFamiliar[0];
            AssignAttri("", false, "A160CliNomeFamiliar", A160CliNomeFamiliar);
            pr_default.close(16);
            /* Using cursor T001119 */
            pr_default.execute(17, new Object[] {A158CliID, A166CpjID});
            Z170CpjNomeFan = T001119_A170CpjNomeFan[0];
            Z171CpjRazaoSoc = T001119_A171CpjRazaoSoc[0];
            Z176CpjMatricula = T001119_A176CpjMatricula[0];
            Z187CpjCNPJ = T001119_A187CpjCNPJ[0];
            Z188CpjCNPJFormat = T001119_A188CpjCNPJFormat[0];
            Z189CpjIE = T001119_A189CpjIE[0];
            Z207CpjAtivo = T001119_A207CpjAtivo[0];
            Z261CpjTelNum = T001119_A261CpjTelNum[0];
            Z262CpjTelRam = T001119_A262CpjTelRam[0];
            Z263CpjCelNum = T001119_A263CpjCelNum[0];
            Z264CpjWppNum = T001119_A264CpjWppNum[0];
            Z265CpjWebsite = T001119_A265CpjWebsite[0];
            Z266CpjEmail = T001119_A266CpjEmail[0];
            Z365CpjTipoId = T001119_A365CpjTipoId[0];
            A267CpjUltEndSeq = T001119_A267CpjUltEndSeq[0];
            n267CpjUltEndSeq = T001119_n267CpjUltEndSeq[0];
            AssignAttri("", false, "A267CpjUltEndSeq", StringUtil.LTrimStr( (decimal)(A267CpjUltEndSeq), 4, 0));
            A170CpjNomeFan = T001119_A170CpjNomeFan[0];
            AssignAttri("", false, "A170CpjNomeFan", A170CpjNomeFan);
            A171CpjRazaoSoc = T001119_A171CpjRazaoSoc[0];
            AssignAttri("", false, "A171CpjRazaoSoc", A171CpjRazaoSoc);
            A176CpjMatricula = T001119_A176CpjMatricula[0];
            AssignAttri("", false, "A176CpjMatricula", StringUtil.LTrimStr( (decimal)(A176CpjMatricula), 12, 0));
            A187CpjCNPJ = T001119_A187CpjCNPJ[0];
            AssignAttri("", false, "A187CpjCNPJ", StringUtil.LTrimStr( (decimal)(A187CpjCNPJ), 14, 0));
            A188CpjCNPJFormat = T001119_A188CpjCNPJFormat[0];
            AssignAttri("", false, "A188CpjCNPJFormat", A188CpjCNPJFormat);
            A189CpjIE = T001119_A189CpjIE[0];
            AssignAttri("", false, "A189CpjIE", A189CpjIE);
            A207CpjAtivo = T001119_A207CpjAtivo[0];
            AssignAttri("", false, "A207CpjAtivo", A207CpjAtivo);
            A261CpjTelNum = T001119_A261CpjTelNum[0];
            n261CpjTelNum = T001119_n261CpjTelNum[0];
            AssignAttri("", false, "A261CpjTelNum", A261CpjTelNum);
            A262CpjTelRam = T001119_A262CpjTelRam[0];
            n262CpjTelRam = T001119_n262CpjTelRam[0];
            AssignAttri("", false, "A262CpjTelRam", A262CpjTelRam);
            A263CpjCelNum = T001119_A263CpjCelNum[0];
            n263CpjCelNum = T001119_n263CpjCelNum[0];
            AssignAttri("", false, "A263CpjCelNum", A263CpjCelNum);
            A264CpjWppNum = T001119_A264CpjWppNum[0];
            n264CpjWppNum = T001119_n264CpjWppNum[0];
            AssignAttri("", false, "A264CpjWppNum", A264CpjWppNum);
            A265CpjWebsite = T001119_A265CpjWebsite[0];
            n265CpjWebsite = T001119_n265CpjWebsite[0];
            AssignAttri("", false, "A265CpjWebsite", A265CpjWebsite);
            A266CpjEmail = T001119_A266CpjEmail[0];
            n266CpjEmail = T001119_n266CpjEmail[0];
            AssignAttri("", false, "A266CpjEmail", A266CpjEmail);
            A365CpjTipoId = T001119_A365CpjTipoId[0];
            AssignAttri("", false, "A365CpjTipoId", StringUtil.LTrimStr( (decimal)(A365CpjTipoId), 9, 0));
            O267CpjUltEndSeq = A267CpjUltEndSeq;
            n267CpjUltEndSeq = false;
            AssignAttri("", false, "A267CpjUltEndSeq", StringUtil.LTrimStr( (decimal)(A267CpjUltEndSeq), 4, 0));
            pr_default.close(17);
            if ( IsIns( )  )
            {
               A267CpjUltEndSeq = (short)(O267CpjUltEndSeq+1);
               n267CpjUltEndSeq = false;
               AssignAttri("", false, "A267CpjUltEndSeq", StringUtil.LTrimStr( (decimal)(A267CpjUltEndSeq), 4, 0));
            }
            /* Using cursor T001120 */
            pr_default.execute(18, new Object[] {A365CpjTipoId});
            A366CpjTipoSigla = T001120_A366CpjTipoSigla[0];
            AssignAttri("", false, "A366CpjTipoSigla", A366CpjTipoSigla);
            A367CpjTipoNome = T001120_A367CpjTipoNome[0];
            AssignAttri("", false, "A367CpjTipoNome", A367CpjTipoNome);
            pr_default.close(18);
            if ( String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A253CpjEndNumero))) && String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A254CpjEndComplem))) )
            {
               A368CpjEndCompleto = StringUtil.Trim( A252CpjEndEndereco) + " - " + StringUtil.Trim( A255CpjEndBairro) + " - " + StringUtil.Trim( A251CpjEndCepFormat) + " - " + StringUtil.Trim( A257CpjEndMunNome) + " - " + StringUtil.Trim( A259CpjEndUFSigla);
               AssignAttri("", false, "A368CpjEndCompleto", A368CpjEndCompleto);
            }
            else
            {
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A253CpjEndNumero))) && String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A254CpjEndComplem))) )
               {
                  A368CpjEndCompleto = StringUtil.Trim( A252CpjEndEndereco) + ", " + StringUtil.Trim( A253CpjEndNumero) + " - " + StringUtil.Trim( A255CpjEndBairro) + " - " + StringUtil.Trim( A251CpjEndCepFormat) + " - " + StringUtil.Trim( A257CpjEndMunNome) + " - " + StringUtil.Trim( A259CpjEndUFSigla);
                  AssignAttri("", false, "A368CpjEndCompleto", A368CpjEndCompleto);
               }
               else
               {
                  if ( String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A253CpjEndNumero))) && ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A254CpjEndComplem))) )
                  {
                     A368CpjEndCompleto = StringUtil.Trim( A252CpjEndEndereco) + ", " + StringUtil.Trim( A253CpjEndNumero) + " - " + StringUtil.Trim( A255CpjEndBairro) + " - " + StringUtil.Trim( A251CpjEndCepFormat) + " - " + StringUtil.Trim( A257CpjEndMunNome) + " - " + StringUtil.Trim( A259CpjEndUFSigla);
                     AssignAttri("", false, "A368CpjEndCompleto", A368CpjEndCompleto);
                  }
                  else
                  {
                     A368CpjEndCompleto = StringUtil.Trim( A252CpjEndEndereco) + ", " + StringUtil.Trim( A253CpjEndNumero) + " " + StringUtil.Trim( A254CpjEndComplem) + " - " + StringUtil.Trim( A255CpjEndBairro) + " - " + StringUtil.Trim( A251CpjEndCepFormat) + " - " + StringUtil.Trim( A257CpjEndMunNome) + " - " + StringUtil.Trim( A259CpjEndUFSigla);
                     AssignAttri("", false, "A368CpjEndCompleto", A368CpjEndCompleto);
                  }
               }
            }
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T001121 */
            pr_default.execute(19, new Object[] {A158CliID, A166CpjID, A248CpjEndSeq});
            if ( (pr_default.getStatus(19) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Oportunidade de Negócio"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(19);
         }
      }

      protected void UpdateTablesN11131( )
      {
         /* Using cursor T001122 */
         pr_default.execute(20, new Object[] {n267CpjUltEndSeq, A267CpjUltEndSeq, A158CliID, A166CpjID});
         pr_default.close(20);
         pr_default.SmartCacheProvider.SetUpdated("tb_clientepj");
      }

      protected void EndLevel1131( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         pr_default.close(12);
         if ( AnyError == 0 )
         {
            BeforeComplete1131( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("core.clientepjendereco",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues110( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("core.clientepjendereco",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1131( )
      {
         /* Scan By routine */
         /* Using cursor T001123 */
         pr_default.execute(21);
         RcdFound31 = 0;
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound31 = 1;
            A158CliID = T001123_A158CliID[0];
            AssignAttri("", false, "A158CliID", A158CliID.ToString());
            A166CpjID = T001123_A166CpjID[0];
            AssignAttri("", false, "A166CpjID", A166CpjID.ToString());
            A248CpjEndSeq = T001123_A248CpjEndSeq[0];
            AssignAttri("", false, "A248CpjEndSeq", StringUtil.LTrimStr( (decimal)(A248CpjEndSeq), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1131( )
      {
         /* Scan next routine */
         pr_default.readNext(21);
         RcdFound31 = 0;
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound31 = 1;
            A158CliID = T001123_A158CliID[0];
            AssignAttri("", false, "A158CliID", A158CliID.ToString());
            A166CpjID = T001123_A166CpjID[0];
            AssignAttri("", false, "A166CpjID", A166CpjID.ToString());
            A248CpjEndSeq = T001123_A248CpjEndSeq[0];
            AssignAttri("", false, "A248CpjEndSeq", StringUtil.LTrimStr( (decimal)(A248CpjEndSeq), 4, 0));
         }
      }

      protected void ScanEnd1131( )
      {
         pr_default.close(21);
      }

      protected void AfterConfirm1131( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1131( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1131( )
      {
         /* Before Update Rules */
         new GeneXus.Programs.core.loadauditclientepjendereco(context ).execute(  "Y", ref  AV38AuditingObject,  A158CliID,  A166CpjID,  A248CpjEndSeq,  Gx_mode) ;
         if ( A554CpjEndDel && ( O554CpjEndDel != A554CpjEndDel ) )
         {
            A555CpjEndDelDataHora = DateTimeUtil.NowMS( context);
            n555CpjEndDelDataHora = false;
            AssignAttri("", false, "A555CpjEndDelDataHora", context.localUtil.TToC( A555CpjEndDelDataHora, 10, 12, 0, 3, "/", ":", " "));
         }
         if ( A554CpjEndDel && ( O554CpjEndDel != A554CpjEndDel ) )
         {
            A558CpjEndDelUsuId = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getid();
            n558CpjEndDelUsuId = false;
            AssignAttri("", false, "A558CpjEndDelUsuId", A558CpjEndDelUsuId);
         }
         if ( A554CpjEndDel && ( O554CpjEndDel != A554CpjEndDel ) )
         {
            A559CpjEndDelUsuNome = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
            n559CpjEndDelUsuNome = false;
            AssignAttri("", false, "A559CpjEndDelUsuNome", A559CpjEndDelUsuNome);
         }
         if ( A554CpjEndDel && ( O554CpjEndDel != A554CpjEndDel ) )
         {
            A556CpjEndDelData = DateTimeUtil.ResetTime( DateTimeUtil.ResetTime( A555CpjEndDelDataHora) ) ;
            n556CpjEndDelData = false;
            AssignAttri("", false, "A556CpjEndDelData", context.localUtil.TToC( A556CpjEndDelData, 10, 5, 0, 3, "/", ":", " "));
         }
         if ( A554CpjEndDel && ( O554CpjEndDel != A554CpjEndDel ) )
         {
            A557CpjEndDelHora = DateTimeUtil.ResetDate( DateTimeUtil.ResetMilliseconds(A555CpjEndDelDataHora));
            n557CpjEndDelHora = false;
            AssignAttri("", false, "A557CpjEndDelHora", context.localUtil.TToC( A557CpjEndDelHora, 0, 5, 0, 3, "/", ":", " "));
         }
      }

      protected void BeforeDelete1131( )
      {
         /* Before Delete Rules */
         new GeneXus.Programs.core.loadauditclientepjendereco(context ).execute(  "Y", ref  AV38AuditingObject,  A158CliID,  A166CpjID,  A248CpjEndSeq,  Gx_mode) ;
      }

      protected void BeforeComplete1131( )
      {
         /* Before Complete Rules */
         if ( IsIns( )  )
         {
            new GeneXus.Programs.core.loadauditclientepjendereco(context ).execute(  "N", ref  AV38AuditingObject,  A158CliID,  A166CpjID,  A248CpjEndSeq,  Gx_mode) ;
         }
         if ( IsUpd( )  )
         {
            new GeneXus.Programs.core.loadauditclientepjendereco(context ).execute(  "N", ref  AV38AuditingObject,  A158CliID,  A166CpjID,  A248CpjEndSeq,  Gx_mode) ;
         }
      }

      protected void BeforeValidate1131( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1131( )
      {
         edtCliNomeFamiliar_Enabled = 0;
         AssignProp("", false, edtCliNomeFamiliar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliNomeFamiliar_Enabled), 5, 0), true);
         edtCliMatricula_Enabled = 0;
         AssignProp("", false, edtCliMatricula_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliMatricula_Enabled), 5, 0), true);
         edtCpjNomeFan_Enabled = 0;
         AssignProp("", false, edtCpjNomeFan_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjNomeFan_Enabled), 5, 0), true);
         edtCpjMatricula_Enabled = 0;
         AssignProp("", false, edtCpjMatricula_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjMatricula_Enabled), 5, 0), true);
         edtCpjCNPJFormat_Enabled = 0;
         AssignProp("", false, edtCpjCNPJFormat_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjCNPJFormat_Enabled), 5, 0), true);
         edtCpjIE_Enabled = 0;
         AssignProp("", false, edtCpjIE_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjIE_Enabled), 5, 0), true);
         edtCpjTelNum_Enabled = 0;
         AssignProp("", false, edtCpjTelNum_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjTelNum_Enabled), 5, 0), true);
         edtCpjTelRam_Enabled = 0;
         AssignProp("", false, edtCpjTelRam_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjTelRam_Enabled), 5, 0), true);
         edtCpjCelNum_Enabled = 0;
         AssignProp("", false, edtCpjCelNum_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjCelNum_Enabled), 5, 0), true);
         edtCpjWppNum_Enabled = 0;
         AssignProp("", false, edtCpjWppNum_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjWppNum_Enabled), 5, 0), true);
         edtCpjWebsite_Enabled = 0;
         AssignProp("", false, edtCpjWebsite_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjWebsite_Enabled), 5, 0), true);
         edtCpjEmail_Enabled = 0;
         AssignProp("", false, edtCpjEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjEmail_Enabled), 5, 0), true);
         edtCpjEndNome_Enabled = 0;
         AssignProp("", false, edtCpjEndNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjEndNome_Enabled), 5, 0), true);
         edtCpjEndCepFormat_Enabled = 0;
         AssignProp("", false, edtCpjEndCepFormat_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjEndCepFormat_Enabled), 5, 0), true);
         edtCpjEndEndereco_Enabled = 0;
         AssignProp("", false, edtCpjEndEndereco_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjEndEndereco_Enabled), 5, 0), true);
         edtCpjEndNumero_Enabled = 0;
         AssignProp("", false, edtCpjEndNumero_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjEndNumero_Enabled), 5, 0), true);
         edtCpjEndComplem_Enabled = 0;
         AssignProp("", false, edtCpjEndComplem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjEndComplem_Enabled), 5, 0), true);
         edtCpjEndBairro_Enabled = 0;
         AssignProp("", false, edtCpjEndBairro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjEndBairro_Enabled), 5, 0), true);
         edtCpjEndMunNome_Enabled = 0;
         AssignProp("", false, edtCpjEndMunNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjEndMunNome_Enabled), 5, 0), true);
         edtCpjEndUFSigla_Enabled = 0;
         AssignProp("", false, edtCpjEndUFSigla_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjEndUFSigla_Enabled), 5, 0), true);
         edtCpjEndSeq_Enabled = 0;
         AssignProp("", false, edtCpjEndSeq_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjEndSeq_Enabled), 5, 0), true);
         edtCpjEndCep_Enabled = 0;
         AssignProp("", false, edtCpjEndCep_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjEndCep_Enabled), 5, 0), true);
         edtCpjEndMunID_Enabled = 0;
         AssignProp("", false, edtCpjEndMunID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjEndMunID_Enabled), 5, 0), true);
         edtCpjEndUFId_Enabled = 0;
         AssignProp("", false, edtCpjEndUFId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjEndUFId_Enabled), 5, 0), true);
         edtCpjEndUFNome_Enabled = 0;
         AssignProp("", false, edtCpjEndUFNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjEndUFNome_Enabled), 5, 0), true);
         edtCliID_Enabled = 0;
         AssignProp("", false, edtCliID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliID_Enabled), 5, 0), true);
         edtCpjID_Enabled = 0;
         AssignProp("", false, edtCpjID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjID_Enabled), 5, 0), true);
         edtCpjTipoId_Enabled = 0;
         AssignProp("", false, edtCpjTipoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjTipoId_Enabled), 5, 0), true);
         edtCpjTipoSigla_Enabled = 0;
         AssignProp("", false, edtCpjTipoSigla_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjTipoSigla_Enabled), 5, 0), true);
         edtCpjTipoNome_Enabled = 0;
         AssignProp("", false, edtCpjTipoNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjTipoNome_Enabled), 5, 0), true);
         edtCpjRazaoSoc_Enabled = 0;
         AssignProp("", false, edtCpjRazaoSoc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjRazaoSoc_Enabled), 5, 0), true);
         edtCpjCNPJ_Enabled = 0;
         AssignProp("", false, edtCpjCNPJ_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjCNPJ_Enabled), 5, 0), true);
         edtCpjAtivo_Enabled = 0;
         AssignProp("", false, edtCpjAtivo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjAtivo_Enabled), 5, 0), true);
         edtCpjUltEndSeq_Enabled = 0;
         AssignProp("", false, edtCpjUltEndSeq_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjUltEndSeq_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1131( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues110( )
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
         GXEncryptionTmp = "core.clientepjendereco.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV7CliID.ToString()) + "," + UrlEncode(AV8CpjID.ToString()) + "," + UrlEncode(StringUtil.LTrimStr(AV37CpjEndSeq,4,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("core.clientepjendereco.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"ClientePJEndereco");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("Pgmname", StringUtil.RTrim( context.localUtil.Format( AV40Pgmname, "")));
         forbiddenHiddens.Add("CpjEndDel", StringUtil.BoolToStr( A554CpjEndDel));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("core\\clientepjendereco:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z158CliID", Z158CliID.ToString());
         GxWebStd.gx_hidden_field( context, "Z166CpjID", Z166CpjID.ToString());
         GxWebStd.gx_hidden_field( context, "Z248CpjEndSeq", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z248CpjEndSeq), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z555CpjEndDelDataHora", context.localUtil.TToC( Z555CpjEndDelDataHora, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z556CpjEndDelData", context.localUtil.TToC( Z556CpjEndDelData, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z557CpjEndDelHora", context.localUtil.TToC( Z557CpjEndDelHora, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z558CpjEndDelUsuId", StringUtil.RTrim( Z558CpjEndDelUsuId));
         GxWebStd.gx_hidden_field( context, "Z559CpjEndDelUsuNome", Z559CpjEndDelUsuNome);
         GxWebStd.gx_hidden_field( context, "Z249CpjEndNome", Z249CpjEndNome);
         GxWebStd.gx_hidden_field( context, "Z250CpjEndCep", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z250CpjEndCep), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z251CpjEndCepFormat", Z251CpjEndCepFormat);
         GxWebStd.gx_hidden_field( context, "Z252CpjEndEndereco", Z252CpjEndEndereco);
         GxWebStd.gx_hidden_field( context, "Z253CpjEndNumero", Z253CpjEndNumero);
         GxWebStd.gx_hidden_field( context, "Z254CpjEndComplem", Z254CpjEndComplem);
         GxWebStd.gx_hidden_field( context, "Z255CpjEndBairro", Z255CpjEndBairro);
         GxWebStd.gx_hidden_field( context, "Z256CpjEndMunID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z256CpjEndMunID), 7, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z257CpjEndMunNome", Z257CpjEndMunNome);
         GxWebStd.gx_hidden_field( context, "Z258CpjEndUFId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z258CpjEndUFId), 2, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z259CpjEndUFSigla", Z259CpjEndUFSigla);
         GxWebStd.gx_hidden_field( context, "Z260CpjEndUFNome", Z260CpjEndUFNome);
         GxWebStd.gx_boolean_hidden_field( context, "Z554CpjEndDel", Z554CpjEndDel);
         GxWebStd.gx_hidden_field( context, "Z170CpjNomeFan", Z170CpjNomeFan);
         GxWebStd.gx_hidden_field( context, "Z171CpjRazaoSoc", Z171CpjRazaoSoc);
         GxWebStd.gx_hidden_field( context, "Z176CpjMatricula", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z176CpjMatricula), 12, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z187CpjCNPJ", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z187CpjCNPJ), 14, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z188CpjCNPJFormat", Z188CpjCNPJFormat);
         GxWebStd.gx_hidden_field( context, "Z189CpjIE", Z189CpjIE);
         GxWebStd.gx_boolean_hidden_field( context, "Z207CpjAtivo", Z207CpjAtivo);
         GxWebStd.gx_hidden_field( context, "Z261CpjTelNum", StringUtil.RTrim( Z261CpjTelNum));
         GxWebStd.gx_hidden_field( context, "Z262CpjTelRam", Z262CpjTelRam);
         GxWebStd.gx_hidden_field( context, "Z263CpjCelNum", StringUtil.RTrim( Z263CpjCelNum));
         GxWebStd.gx_hidden_field( context, "Z264CpjWppNum", StringUtil.RTrim( Z264CpjWppNum));
         GxWebStd.gx_hidden_field( context, "Z265CpjWebsite", Z265CpjWebsite);
         GxWebStd.gx_hidden_field( context, "Z266CpjEmail", Z266CpjEmail);
         GxWebStd.gx_hidden_field( context, "Z365CpjTipoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z365CpjTipoId), 9, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "O554CpjEndDel", O554CpjEndDel);
         GxWebStd.gx_hidden_field( context, "O267CpjUltEndSeq", StringUtil.LTrim( StringUtil.NToC( (decimal)(O267CpjUltEndSeq), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "CPJENDCOMPLETO", A368CpjEndCompleto);
         GxWebStd.gx_hidden_field( context, "vCLIID", AV7CliID.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vCLIID", GetSecureSignedToken( "", AV7CliID, context));
         GxWebStd.gx_hidden_field( context, "vCPJID", AV8CpjID.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vCPJID", GetSecureSignedToken( "", AV8CpjID, context));
         GxWebStd.gx_hidden_field( context, "vCPJENDSEQ", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV37CpjEndSeq), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCPJENDSEQ", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV37CpjEndSeq), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "CPJENDDEL", A554CpjEndDel);
         GxWebStd.gx_hidden_field( context, "CPJENDDELDATAHORA", context.localUtil.TToC( A555CpjEndDelDataHora, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "CPJENDDELDATA", context.localUtil.TToC( A556CpjEndDelData, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "CPJENDDELHORA", context.localUtil.TToC( A557CpjEndDelHora, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "CPJENDDELUSUID", StringUtil.RTrim( A558CpjEndDelUsuId));
         GxWebStd.gx_hidden_field( context, "CPJENDDELUSUNOME", A559CpjEndDelUsuNome);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAUDITINGOBJECT", AV38AuditingObject);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAUDITINGOBJECT", AV38AuditingObject);
         }
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV40Pgmname));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECLIENTE_Objectcall", StringUtil.RTrim( Dvpanel_tablecliente_Objectcall));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECLIENTE_Enabled", StringUtil.BoolToStr( Dvpanel_tablecliente_Enabled));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECLIENTE_Width", StringUtil.RTrim( Dvpanel_tablecliente_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECLIENTE_Autowidth", StringUtil.BoolToStr( Dvpanel_tablecliente_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECLIENTE_Autoheight", StringUtil.BoolToStr( Dvpanel_tablecliente_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECLIENTE_Cls", StringUtil.RTrim( Dvpanel_tablecliente_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECLIENTE_Title", StringUtil.RTrim( Dvpanel_tablecliente_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECLIENTE_Collapsible", StringUtil.BoolToStr( Dvpanel_tablecliente_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECLIENTE_Collapsed", StringUtil.BoolToStr( Dvpanel_tablecliente_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECLIENTE_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tablecliente_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECLIENTE_Iconposition", StringUtil.RTrim( Dvpanel_tablecliente_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECLIENTE_Autoscroll", StringUtil.BoolToStr( Dvpanel_tablecliente_Autoscroll));
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
         GXEncryptionTmp = "core.clientepjendereco.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV7CliID.ToString()) + "," + UrlEncode(AV8CpjID.ToString()) + "," + UrlEncode(StringUtil.LTrimStr(AV37CpjEndSeq,4,0));
         return formatLink("core.clientepjendereco.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "core.ClientePJEndereco" ;
      }

      public override string GetPgmdesc( )
      {
         return "Endereço" ;
      }

      protected void InitializeNonKey1131( )
      {
         AV38AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
         A267CpjUltEndSeq = 0;
         n267CpjUltEndSeq = false;
         AssignAttri("", false, "A267CpjUltEndSeq", StringUtil.LTrimStr( (decimal)(A267CpjUltEndSeq), 4, 0));
         n267CpjUltEndSeq = ((0==A267CpjUltEndSeq) ? true : false);
         A555CpjEndDelDataHora = (DateTime)(DateTime.MinValue);
         n555CpjEndDelDataHora = false;
         AssignAttri("", false, "A555CpjEndDelDataHora", context.localUtil.TToC( A555CpjEndDelDataHora, 10, 12, 0, 3, "/", ":", " "));
         A556CpjEndDelData = (DateTime)(DateTime.MinValue);
         n556CpjEndDelData = false;
         AssignAttri("", false, "A556CpjEndDelData", context.localUtil.TToC( A556CpjEndDelData, 10, 5, 0, 3, "/", ":", " "));
         A557CpjEndDelHora = (DateTime)(DateTime.MinValue);
         n557CpjEndDelHora = false;
         AssignAttri("", false, "A557CpjEndDelHora", context.localUtil.TToC( A557CpjEndDelHora, 0, 5, 0, 3, "/", ":", " "));
         A558CpjEndDelUsuId = "";
         n558CpjEndDelUsuId = false;
         AssignAttri("", false, "A558CpjEndDelUsuId", A558CpjEndDelUsuId);
         A559CpjEndDelUsuNome = "";
         n559CpjEndDelUsuNome = false;
         AssignAttri("", false, "A559CpjEndDelUsuNome", A559CpjEndDelUsuNome);
         A368CpjEndCompleto = "";
         AssignAttri("", false, "A368CpjEndCompleto", A368CpjEndCompleto);
         A159CliMatricula = 0;
         AssignAttri("", false, "A159CliMatricula", StringUtil.LTrimStr( (decimal)(A159CliMatricula), 12, 0));
         A160CliNomeFamiliar = "";
         AssignAttri("", false, "A160CliNomeFamiliar", A160CliNomeFamiliar);
         A365CpjTipoId = 0;
         AssignAttri("", false, "A365CpjTipoId", StringUtil.LTrimStr( (decimal)(A365CpjTipoId), 9, 0));
         A366CpjTipoSigla = "";
         AssignAttri("", false, "A366CpjTipoSigla", A366CpjTipoSigla);
         A367CpjTipoNome = "";
         AssignAttri("", false, "A367CpjTipoNome", A367CpjTipoNome);
         A170CpjNomeFan = "";
         AssignAttri("", false, "A170CpjNomeFan", A170CpjNomeFan);
         A171CpjRazaoSoc = "";
         AssignAttri("", false, "A171CpjRazaoSoc", A171CpjRazaoSoc);
         A176CpjMatricula = 0;
         AssignAttri("", false, "A176CpjMatricula", StringUtil.LTrimStr( (decimal)(A176CpjMatricula), 12, 0));
         A187CpjCNPJ = 0;
         AssignAttri("", false, "A187CpjCNPJ", StringUtil.LTrimStr( (decimal)(A187CpjCNPJ), 14, 0));
         A188CpjCNPJFormat = "";
         AssignAttri("", false, "A188CpjCNPJFormat", A188CpjCNPJFormat);
         A189CpjIE = "";
         AssignAttri("", false, "A189CpjIE", A189CpjIE);
         A207CpjAtivo = false;
         AssignAttri("", false, "A207CpjAtivo", A207CpjAtivo);
         A261CpjTelNum = "";
         n261CpjTelNum = false;
         AssignAttri("", false, "A261CpjTelNum", A261CpjTelNum);
         A262CpjTelRam = "";
         n262CpjTelRam = false;
         AssignAttri("", false, "A262CpjTelRam", A262CpjTelRam);
         A263CpjCelNum = "";
         n263CpjCelNum = false;
         AssignAttri("", false, "A263CpjCelNum", A263CpjCelNum);
         A264CpjWppNum = "";
         n264CpjWppNum = false;
         AssignAttri("", false, "A264CpjWppNum", A264CpjWppNum);
         A265CpjWebsite = "";
         n265CpjWebsite = false;
         AssignAttri("", false, "A265CpjWebsite", A265CpjWebsite);
         A266CpjEmail = "";
         n266CpjEmail = false;
         AssignAttri("", false, "A266CpjEmail", A266CpjEmail);
         A249CpjEndNome = "";
         AssignAttri("", false, "A249CpjEndNome", A249CpjEndNome);
         A250CpjEndCep = 0;
         AssignAttri("", false, "A250CpjEndCep", StringUtil.LTrimStr( (decimal)(A250CpjEndCep), 8, 0));
         A251CpjEndCepFormat = "";
         AssignAttri("", false, "A251CpjEndCepFormat", A251CpjEndCepFormat);
         A252CpjEndEndereco = "";
         AssignAttri("", false, "A252CpjEndEndereco", A252CpjEndEndereco);
         A253CpjEndNumero = "";
         AssignAttri("", false, "A253CpjEndNumero", A253CpjEndNumero);
         A254CpjEndComplem = "";
         n254CpjEndComplem = false;
         AssignAttri("", false, "A254CpjEndComplem", A254CpjEndComplem);
         n254CpjEndComplem = (String.IsNullOrEmpty(StringUtil.RTrim( A254CpjEndComplem)) ? true : false);
         A255CpjEndBairro = "";
         AssignAttri("", false, "A255CpjEndBairro", A255CpjEndBairro);
         A256CpjEndMunID = 0;
         AssignAttri("", false, "A256CpjEndMunID", StringUtil.LTrimStr( (decimal)(A256CpjEndMunID), 7, 0));
         A257CpjEndMunNome = "";
         AssignAttri("", false, "A257CpjEndMunNome", A257CpjEndMunNome);
         A258CpjEndUFId = 0;
         AssignAttri("", false, "A258CpjEndUFId", StringUtil.LTrimStr( (decimal)(A258CpjEndUFId), 2, 0));
         A259CpjEndUFSigla = "";
         AssignAttri("", false, "A259CpjEndUFSigla", A259CpjEndUFSigla);
         A260CpjEndUFNome = "";
         AssignAttri("", false, "A260CpjEndUFNome", A260CpjEndUFNome);
         A554CpjEndDel = false;
         AssignAttri("", false, "A554CpjEndDel", A554CpjEndDel);
         O554CpjEndDel = A554CpjEndDel;
         AssignAttri("", false, "A554CpjEndDel", A554CpjEndDel);
         O267CpjUltEndSeq = A267CpjUltEndSeq;
         n267CpjUltEndSeq = false;
         AssignAttri("", false, "A267CpjUltEndSeq", StringUtil.LTrimStr( (decimal)(A267CpjUltEndSeq), 4, 0));
         Z555CpjEndDelDataHora = (DateTime)(DateTime.MinValue);
         Z556CpjEndDelData = (DateTime)(DateTime.MinValue);
         Z557CpjEndDelHora = (DateTime)(DateTime.MinValue);
         Z558CpjEndDelUsuId = "";
         Z559CpjEndDelUsuNome = "";
         Z249CpjEndNome = "";
         Z250CpjEndCep = 0;
         Z251CpjEndCepFormat = "";
         Z252CpjEndEndereco = "";
         Z253CpjEndNumero = "";
         Z254CpjEndComplem = "";
         Z255CpjEndBairro = "";
         Z256CpjEndMunID = 0;
         Z257CpjEndMunNome = "";
         Z258CpjEndUFId = 0;
         Z259CpjEndUFSigla = "";
         Z260CpjEndUFNome = "";
         Z554CpjEndDel = false;
         Z170CpjNomeFan = "";
         Z171CpjRazaoSoc = "";
         Z176CpjMatricula = 0;
         Z187CpjCNPJ = 0;
         Z188CpjCNPJFormat = "";
         Z189CpjIE = "";
         Z207CpjAtivo = false;
         Z261CpjTelNum = "";
         Z262CpjTelRam = "";
         Z263CpjCelNum = "";
         Z264CpjWppNum = "";
         Z265CpjWebsite = "";
         Z266CpjEmail = "";
         Z365CpjTipoId = 0;
      }

      protected void InitAll1131( )
      {
         A158CliID = Guid.Empty;
         AssignAttri("", false, "A158CliID", A158CliID.ToString());
         A166CpjID = Guid.Empty;
         AssignAttri("", false, "A166CpjID", A166CpjID.ToString());
         A248CpjEndSeq = 0;
         AssignAttri("", false, "A248CpjEndSeq", StringUtil.LTrimStr( (decimal)(A248CpjEndSeq), 4, 0));
         InitializeNonKey1131( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2023828144146", true, true);
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
         context.AddJavascriptSource("core/clientepjendereco.js", "?2023828144148", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtCliNomeFamiliar_Internalname = "CLINOMEFAMILIAR";
         edtCliMatricula_Internalname = "CLIMATRICULA";
         lblTxtesp01_Internalname = "TXTESP01";
         edtCpjNomeFan_Internalname = "CPJNOMEFAN";
         edtCpjMatricula_Internalname = "CPJMATRICULA";
         edtCpjCNPJFormat_Internalname = "CPJCNPJFORMAT";
         edtCpjIE_Internalname = "CPJIE";
         edtCpjTelNum_Internalname = "CPJTELNUM";
         edtCpjTelRam_Internalname = "CPJTELRAM";
         edtCpjCelNum_Internalname = "CPJCELNUM";
         edtCpjWppNum_Internalname = "CPJWPPNUM";
         edtCpjWebsite_Internalname = "CPJWEBSITE";
         edtCpjEmail_Internalname = "CPJEMAIL";
         divTablecliente_Internalname = "TABLECLIENTE";
         Dvpanel_tablecliente_Internalname = "DVPANEL_TABLECLIENTE";
         edtCpjEndNome_Internalname = "CPJENDNOME";
         edtCpjEndCepFormat_Internalname = "CPJENDCEPFORMAT";
         edtCpjEndEndereco_Internalname = "CPJENDENDERECO";
         edtCpjEndNumero_Internalname = "CPJENDNUMERO";
         edtCpjEndComplem_Internalname = "CPJENDCOMPLEM";
         edtCpjEndBairro_Internalname = "CPJENDBAIRRO";
         edtCpjEndMunNome_Internalname = "CPJENDMUNNOME";
         edtCpjEndUFSigla_Internalname = "CPJENDUFSIGLA";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         divTablemain_Internalname = "TABLEMAIN";
         edtCpjEndSeq_Internalname = "CPJENDSEQ";
         edtCpjEndCep_Internalname = "CPJENDCEP";
         edtCpjEndMunID_Internalname = "CPJENDMUNID";
         edtCpjEndUFId_Internalname = "CPJENDUFID";
         edtCpjEndUFNome_Internalname = "CPJENDUFNOME";
         edtCliID_Internalname = "CLIID";
         edtCpjID_Internalname = "CPJID";
         edtCpjTipoId_Internalname = "CPJTIPOID";
         edtCpjTipoSigla_Internalname = "CPJTIPOSIGLA";
         edtCpjTipoNome_Internalname = "CPJTIPONOME";
         edtCpjRazaoSoc_Internalname = "CPJRAZAOSOC";
         edtCpjCNPJ_Internalname = "CPJCNPJ";
         edtCpjAtivo_Internalname = "CPJATIVO";
         edtCpjUltEndSeq_Internalname = "CPJULTENDSEQ";
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
         Form.Caption = "Endereço";
         edtCpjUltEndSeq_Jsonclick = "";
         edtCpjUltEndSeq_Enabled = 0;
         edtCpjUltEndSeq_Visible = 1;
         edtCpjAtivo_Jsonclick = "";
         edtCpjAtivo_Enabled = 0;
         edtCpjAtivo_Visible = 1;
         edtCpjCNPJ_Jsonclick = "";
         edtCpjCNPJ_Enabled = 0;
         edtCpjCNPJ_Visible = 1;
         edtCpjRazaoSoc_Jsonclick = "";
         edtCpjRazaoSoc_Enabled = 0;
         edtCpjRazaoSoc_Visible = 1;
         edtCpjTipoNome_Jsonclick = "";
         edtCpjTipoNome_Enabled = 0;
         edtCpjTipoNome_Visible = 1;
         edtCpjTipoSigla_Jsonclick = "";
         edtCpjTipoSigla_Enabled = 0;
         edtCpjTipoSigla_Visible = 1;
         edtCpjTipoId_Jsonclick = "";
         edtCpjTipoId_Enabled = 0;
         edtCpjTipoId_Visible = 1;
         edtCpjID_Jsonclick = "";
         edtCpjID_Enabled = 1;
         edtCpjID_Visible = 1;
         edtCliID_Jsonclick = "";
         edtCliID_Enabled = 1;
         edtCliID_Visible = 1;
         edtCpjEndUFNome_Jsonclick = "";
         edtCpjEndUFNome_Enabled = 1;
         edtCpjEndUFNome_Visible = 1;
         edtCpjEndUFId_Jsonclick = "";
         edtCpjEndUFId_Enabled = 1;
         edtCpjEndUFId_Visible = 1;
         edtCpjEndMunID_Jsonclick = "";
         edtCpjEndMunID_Enabled = 1;
         edtCpjEndMunID_Visible = 1;
         edtCpjEndCep_Jsonclick = "";
         edtCpjEndCep_Enabled = 1;
         edtCpjEndCep_Visible = 1;
         edtCpjEndSeq_Jsonclick = "";
         edtCpjEndSeq_Enabled = 1;
         edtCpjEndSeq_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtCpjEndUFSigla_Jsonclick = "";
         edtCpjEndUFSigla_Enabled = 1;
         edtCpjEndMunNome_Jsonclick = "";
         edtCpjEndMunNome_Enabled = 1;
         edtCpjEndBairro_Jsonclick = "";
         edtCpjEndBairro_Enabled = 1;
         edtCpjEndComplem_Jsonclick = "";
         edtCpjEndComplem_Enabled = 1;
         edtCpjEndNumero_Jsonclick = "";
         edtCpjEndNumero_Enabled = 1;
         edtCpjEndEndereco_Jsonclick = "";
         edtCpjEndEndereco_Enabled = 1;
         edtCpjEndCepFormat_Jsonclick = "";
         edtCpjEndCepFormat_Enabled = 1;
         edtCpjEndNome_Jsonclick = "";
         edtCpjEndNome_Enabled = 1;
         Dvpanel_tableattributes_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Iconposition = "Right";
         Dvpanel_tableattributes_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Title = "Informe o endereço abaixo";
         Dvpanel_tableattributes_Cls = "PanelCard_IconAndTitle Panel_BaseColor";
         Dvpanel_tableattributes_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tableattributes_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Width = "100%";
         edtCpjEmail_Jsonclick = "";
         edtCpjEmail_Enabled = 0;
         edtCpjWebsite_Jsonclick = "";
         edtCpjWebsite_Enabled = 0;
         edtCpjWppNum_Jsonclick = "";
         edtCpjWppNum_Enabled = 0;
         edtCpjCelNum_Jsonclick = "";
         edtCpjCelNum_Enabled = 0;
         edtCpjTelRam_Jsonclick = "";
         edtCpjTelRam_Enabled = 0;
         edtCpjTelNum_Jsonclick = "";
         edtCpjTelNum_Enabled = 0;
         edtCpjIE_Jsonclick = "";
         edtCpjIE_Enabled = 0;
         edtCpjCNPJFormat_Jsonclick = "";
         edtCpjCNPJFormat_Enabled = 0;
         edtCpjMatricula_Jsonclick = "";
         edtCpjMatricula_Enabled = 0;
         edtCpjNomeFan_Jsonclick = "";
         edtCpjNomeFan_Enabled = 0;
         edtCliMatricula_Jsonclick = "";
         edtCliMatricula_Enabled = 0;
         edtCliNomeFamiliar_Jsonclick = "";
         edtCliNomeFamiliar_Enabled = 0;
         Dvpanel_tablecliente_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tablecliente_Iconposition = "Right";
         Dvpanel_tablecliente_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tablecliente_Collapsed = Convert.ToBoolean( 1);
         Dvpanel_tablecliente_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_tablecliente_Title = "[!CLIENTE!]. Unidade [!UNIDADE!] ([!UNIDADE_TIPO!])";
         Dvpanel_tablecliente_Cls = "PanelCard_IconAndTitle Panel_BaseColor";
         Dvpanel_tablecliente_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tablecliente_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tablecliente_Width = "100%";
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

      protected void XC_31_1131( GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV38AuditingObject ,
                                 Guid A158CliID ,
                                 Guid A166CpjID ,
                                 short A248CpjEndSeq ,
                                 string Gx_mode )
      {
         new GeneXus.Programs.core.loadauditclientepjendereco(context ).execute(  "Y", ref  AV38AuditingObject,  A158CliID,  A166CpjID,  A248CpjEndSeq,  Gx_mode) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.EncodeString( AV38AuditingObject.ToXml(false, true, "", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_32_1131( GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV38AuditingObject ,
                                 Guid A158CliID ,
                                 Guid A166CpjID ,
                                 short A248CpjEndSeq ,
                                 string Gx_mode )
      {
         new GeneXus.Programs.core.loadauditclientepjendereco(context ).execute(  "Y", ref  AV38AuditingObject,  A158CliID,  A166CpjID,  A248CpjEndSeq,  Gx_mode) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.EncodeString( AV38AuditingObject.ToXml(false, true, "", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_33_1131( string Gx_mode ,
                                 GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV38AuditingObject ,
                                 Guid A158CliID ,
                                 Guid A166CpjID ,
                                 short A248CpjEndSeq )
      {
         if ( IsIns( )  )
         {
            new GeneXus.Programs.core.loadauditclientepjendereco(context ).execute(  "N", ref  AV38AuditingObject,  A158CliID,  A166CpjID,  A248CpjEndSeq,  Gx_mode) ;
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.EncodeString( AV38AuditingObject.ToXml(false, true, "", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_34_1131( string Gx_mode ,
                                 GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV38AuditingObject ,
                                 Guid A158CliID ,
                                 Guid A166CpjID ,
                                 short A248CpjEndSeq )
      {
         if ( IsUpd( )  )
         {
            new GeneXus.Programs.core.loadauditclientepjendereco(context ).execute(  "N", ref  AV38AuditingObject,  A158CliID,  A166CpjID,  A248CpjEndSeq,  Gx_mode) ;
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.EncodeString( AV38AuditingObject.ToXml(false, true, "", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
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

      public void Valid_Cliid( )
      {
         /* Using cursor T001118 */
         pr_default.execute(16, new Object[] {A158CliID});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem("Não existe ''.", "ForeignKeyNotFound", 1, "CLIID");
            AnyError = 1;
            GX_FocusControl = edtCliID_Internalname;
         }
         A159CliMatricula = T001118_A159CliMatricula[0];
         A160CliNomeFamiliar = T001118_A160CliNomeFamiliar[0];
         pr_default.close(16);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A159CliMatricula", StringUtil.LTrim( StringUtil.NToC( (decimal)(A159CliMatricula), 12, 0, ".", "")));
         AssignAttri("", false, "A160CliNomeFamiliar", A160CliNomeFamiliar);
      }

      public void Valid_Cpjid( )
      {
         n267CpjUltEndSeq = false;
         n261CpjTelNum = false;
         n262CpjTelRam = false;
         n263CpjCelNum = false;
         n264CpjWppNum = false;
         n265CpjWebsite = false;
         n266CpjEmail = false;
         /* Using cursor T001119 */
         pr_default.execute(17, new Object[] {A158CliID, A166CpjID});
         Z170CpjNomeFan = T001119_A170CpjNomeFan[0];
         Z171CpjRazaoSoc = T001119_A171CpjRazaoSoc[0];
         Z176CpjMatricula = T001119_A176CpjMatricula[0];
         Z187CpjCNPJ = T001119_A187CpjCNPJ[0];
         Z188CpjCNPJFormat = T001119_A188CpjCNPJFormat[0];
         Z189CpjIE = T001119_A189CpjIE[0];
         Z207CpjAtivo = T001119_A207CpjAtivo[0];
         Z261CpjTelNum = T001119_A261CpjTelNum[0];
         Z262CpjTelRam = T001119_A262CpjTelRam[0];
         Z263CpjCelNum = T001119_A263CpjCelNum[0];
         Z264CpjWppNum = T001119_A264CpjWppNum[0];
         Z265CpjWebsite = T001119_A265CpjWebsite[0];
         Z266CpjEmail = T001119_A266CpjEmail[0];
         Z365CpjTipoId = T001119_A365CpjTipoId[0];
         if ( (pr_default.getStatus(17) == 101) )
         {
            GX_msglist.addItem("Não existe ''.", "ForeignKeyNotFound", 1, "CPJID");
            AnyError = 1;
            GX_FocusControl = edtCliID_Internalname;
         }
         A267CpjUltEndSeq = T001119_A267CpjUltEndSeq[0];
         n267CpjUltEndSeq = T001119_n267CpjUltEndSeq[0];
         A170CpjNomeFan = T001119_A170CpjNomeFan[0];
         A171CpjRazaoSoc = T001119_A171CpjRazaoSoc[0];
         A176CpjMatricula = T001119_A176CpjMatricula[0];
         A187CpjCNPJ = T001119_A187CpjCNPJ[0];
         A188CpjCNPJFormat = T001119_A188CpjCNPJFormat[0];
         A189CpjIE = T001119_A189CpjIE[0];
         A207CpjAtivo = T001119_A207CpjAtivo[0];
         A261CpjTelNum = T001119_A261CpjTelNum[0];
         n261CpjTelNum = T001119_n261CpjTelNum[0];
         A262CpjTelRam = T001119_A262CpjTelRam[0];
         n262CpjTelRam = T001119_n262CpjTelRam[0];
         A263CpjCelNum = T001119_A263CpjCelNum[0];
         n263CpjCelNum = T001119_n263CpjCelNum[0];
         A264CpjWppNum = T001119_A264CpjWppNum[0];
         n264CpjWppNum = T001119_n264CpjWppNum[0];
         A265CpjWebsite = T001119_A265CpjWebsite[0];
         n265CpjWebsite = T001119_n265CpjWebsite[0];
         A266CpjEmail = T001119_A266CpjEmail[0];
         n266CpjEmail = T001119_n266CpjEmail[0];
         A365CpjTipoId = T001119_A365CpjTipoId[0];
         O267CpjUltEndSeq = A267CpjUltEndSeq;
         n267CpjUltEndSeq = false;
         pr_default.close(17);
         if ( IsIns( )  )
         {
            A267CpjUltEndSeq = (short)(O267CpjUltEndSeq+1);
            n267CpjUltEndSeq = false;
         }
         /* Using cursor T001120 */
         pr_default.execute(18, new Object[] {A365CpjTipoId});
         if ( (pr_default.getStatus(18) == 101) )
         {
            GX_msglist.addItem("Não existe 'Cliente PJ -> Cliente PJ Tipo'.", "ForeignKeyNotFound", 1, "CPJTIPOID");
            AnyError = 1;
         }
         A366CpjTipoSigla = T001120_A366CpjTipoSigla[0];
         A367CpjTipoNome = T001120_A367CpjTipoNome[0];
         pr_default.close(18);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "O267CpjUltEndSeq", StringUtil.LTrim( StringUtil.NToC( (decimal)(O267CpjUltEndSeq), 4, 0, ",", "")));
         AssignAttri("", false, "A267CpjUltEndSeq", StringUtil.LTrim( StringUtil.NToC( (decimal)(A267CpjUltEndSeq), 4, 0, ".", "")));
         AssignAttri("", false, "A170CpjNomeFan", A170CpjNomeFan);
         AssignAttri("", false, "A171CpjRazaoSoc", A171CpjRazaoSoc);
         AssignAttri("", false, "A176CpjMatricula", StringUtil.LTrim( StringUtil.NToC( (decimal)(A176CpjMatricula), 12, 0, ".", "")));
         AssignAttri("", false, "A187CpjCNPJ", StringUtil.LTrim( StringUtil.NToC( (decimal)(A187CpjCNPJ), 14, 0, ".", "")));
         AssignAttri("", false, "A188CpjCNPJFormat", A188CpjCNPJFormat);
         AssignAttri("", false, "A189CpjIE", A189CpjIE);
         AssignAttri("", false, "A207CpjAtivo", A207CpjAtivo);
         AssignAttri("", false, "A261CpjTelNum", StringUtil.RTrim( A261CpjTelNum));
         AssignAttri("", false, "A262CpjTelRam", A262CpjTelRam);
         AssignAttri("", false, "A263CpjCelNum", StringUtil.RTrim( A263CpjCelNum));
         AssignAttri("", false, "A264CpjWppNum", StringUtil.RTrim( A264CpjWppNum));
         AssignAttri("", false, "A265CpjWebsite", A265CpjWebsite);
         AssignAttri("", false, "A266CpjEmail", A266CpjEmail);
         AssignAttri("", false, "A365CpjTipoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A365CpjTipoId), 9, 0, ".", "")));
         AssignAttri("", false, "A248CpjEndSeq", StringUtil.LTrim( StringUtil.NToC( (decimal)(A248CpjEndSeq), 4, 0, ".", "")));
         AssignAttri("", false, "A366CpjTipoSigla", A366CpjTipoSigla);
         AssignAttri("", false, "A367CpjTipoNome", A367CpjTipoNome);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7CliID',fld:'vCLIID',pic:'',hsh:true},{av:'AV8CpjID',fld:'vCPJID',pic:'',hsh:true},{av:'AV37CpjEndSeq',fld:'vCPJENDSEQ',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7CliID',fld:'vCLIID',pic:'',hsh:true},{av:'AV8CpjID',fld:'vCPJID',pic:'',hsh:true},{av:'AV37CpjEndSeq',fld:'vCPJENDSEQ',pic:'ZZZ9',hsh:true},{av:'AV40Pgmname',fld:'vPGMNAME',pic:''},{av:'A554CpjEndDel',fld:'CPJENDDEL',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E12112',iparms:[{av:'AV38AuditingObject',fld:'vAUDITINGOBJECT',pic:''},{av:'AV40Pgmname',fld:'vPGMNAME',pic:''},{av:'A158CliID',fld:'CLIID',pic:''},{av:'A166CpjID',fld:'CPJID',pic:''},{av:'A248CpjEndSeq',fld:'CPJENDSEQ',pic:'ZZZ9'},{av:'A249CpjEndNome',fld:'CPJENDNOME',pic:'@!'}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_CLINOMEFAMILIAR","{handler:'Valid_Clinomefamiliar',iparms:[]");
         setEventMetadata("VALID_CLINOMEFAMILIAR",",oparms:[]}");
         setEventMetadata("VALID_CPJNOMEFAN","{handler:'Valid_Cpjnomefan',iparms:[]");
         setEventMetadata("VALID_CPJNOMEFAN",",oparms:[]}");
         setEventMetadata("VALID_CPJENDNOME","{handler:'Valid_Cpjendnome',iparms:[]");
         setEventMetadata("VALID_CPJENDNOME",",oparms:[]}");
         setEventMetadata("VALID_CPJENDCEPFORMAT","{handler:'Valid_Cpjendcepformat',iparms:[]");
         setEventMetadata("VALID_CPJENDCEPFORMAT",",oparms:[]}");
         setEventMetadata("VALID_CPJENDENDERECO","{handler:'Valid_Cpjendendereco',iparms:[]");
         setEventMetadata("VALID_CPJENDENDERECO",",oparms:[]}");
         setEventMetadata("VALID_CPJENDNUMERO","{handler:'Valid_Cpjendnumero',iparms:[]");
         setEventMetadata("VALID_CPJENDNUMERO",",oparms:[]}");
         setEventMetadata("VALID_CPJENDCOMPLEM","{handler:'Valid_Cpjendcomplem',iparms:[]");
         setEventMetadata("VALID_CPJENDCOMPLEM",",oparms:[]}");
         setEventMetadata("VALID_CPJENDBAIRRO","{handler:'Valid_Cpjendbairro',iparms:[]");
         setEventMetadata("VALID_CPJENDBAIRRO",",oparms:[]}");
         setEventMetadata("VALID_CPJENDMUNNOME","{handler:'Valid_Cpjendmunnome',iparms:[]");
         setEventMetadata("VALID_CPJENDMUNNOME",",oparms:[]}");
         setEventMetadata("VALID_CPJENDUFSIGLA","{handler:'Valid_Cpjendufsigla',iparms:[]");
         setEventMetadata("VALID_CPJENDUFSIGLA",",oparms:[]}");
         setEventMetadata("VALID_CPJENDSEQ","{handler:'Valid_Cpjendseq',iparms:[]");
         setEventMetadata("VALID_CPJENDSEQ",",oparms:[]}");
         setEventMetadata("VALID_CLIID","{handler:'Valid_Cliid',iparms:[{av:'A158CliID',fld:'CLIID',pic:''},{av:'A159CliMatricula',fld:'CLIMATRICULA',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'A160CliNomeFamiliar',fld:'CLINOMEFAMILIAR',pic:'@!'}]");
         setEventMetadata("VALID_CLIID",",oparms:[{av:'A159CliMatricula',fld:'CLIMATRICULA',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'A160CliNomeFamiliar',fld:'CLINOMEFAMILIAR',pic:'@!'}]}");
         setEventMetadata("VALID_CPJID","{handler:'Valid_Cpjid',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'O267CpjUltEndSeq'},{av:'A158CliID',fld:'CLIID',pic:''},{av:'A166CpjID',fld:'CPJID',pic:''},{av:'A267CpjUltEndSeq',fld:'CPJULTENDSEQ',pic:'ZZZ9'},{av:'AV37CpjEndSeq',fld:'vCPJENDSEQ',pic:'ZZZ9',hsh:true},{av:'Gx_BScreen',fld:'vGXBSCREEN',pic:'9'},{av:'A365CpjTipoId',fld:'CPJTIPOID',pic:'ZZZ,ZZZ,ZZ9'},{av:'A170CpjNomeFan',fld:'CPJNOMEFAN',pic:'@!'},{av:'A171CpjRazaoSoc',fld:'CPJRAZAOSOC',pic:'@!'},{av:'A176CpjMatricula',fld:'CPJMATRICULA',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'A187CpjCNPJ',fld:'CPJCNPJ',pic:'ZZZZZZZZZZZZZ9'},{av:'A188CpjCNPJFormat',fld:'CPJCNPJFORMAT',pic:''},{av:'A189CpjIE',fld:'CPJIE',pic:'@!'},{av:'A207CpjAtivo',fld:'CPJATIVO',pic:''},{av:'A261CpjTelNum',fld:'CPJTELNUM',pic:''},{av:'A262CpjTelRam',fld:'CPJTELRAM',pic:''},{av:'A263CpjCelNum',fld:'CPJCELNUM',pic:''},{av:'A264CpjWppNum',fld:'CPJWPPNUM',pic:''},{av:'A265CpjWebsite',fld:'CPJWEBSITE',pic:''},{av:'A266CpjEmail',fld:'CPJEMAIL',pic:''},{av:'A248CpjEndSeq',fld:'CPJENDSEQ',pic:'ZZZ9'},{av:'A366CpjTipoSigla',fld:'CPJTIPOSIGLA',pic:''},{av:'A367CpjTipoNome',fld:'CPJTIPONOME',pic:'@!'}]");
         setEventMetadata("VALID_CPJID",",oparms:[{av:'O267CpjUltEndSeq'},{av:'A267CpjUltEndSeq',fld:'CPJULTENDSEQ',pic:'ZZZ9'},{av:'A170CpjNomeFan',fld:'CPJNOMEFAN',pic:'@!'},{av:'A171CpjRazaoSoc',fld:'CPJRAZAOSOC',pic:'@!'},{av:'A176CpjMatricula',fld:'CPJMATRICULA',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'A187CpjCNPJ',fld:'CPJCNPJ',pic:'ZZZZZZZZZZZZZ9'},{av:'A188CpjCNPJFormat',fld:'CPJCNPJFORMAT',pic:''},{av:'A189CpjIE',fld:'CPJIE',pic:'@!'},{av:'A207CpjAtivo',fld:'CPJATIVO',pic:''},{av:'A261CpjTelNum',fld:'CPJTELNUM',pic:''},{av:'A262CpjTelRam',fld:'CPJTELRAM',pic:''},{av:'A263CpjCelNum',fld:'CPJCELNUM',pic:''},{av:'A264CpjWppNum',fld:'CPJWPPNUM',pic:''},{av:'A265CpjWebsite',fld:'CPJWEBSITE',pic:''},{av:'A266CpjEmail',fld:'CPJEMAIL',pic:''},{av:'A365CpjTipoId',fld:'CPJTIPOID',pic:'ZZZ,ZZZ,ZZ9'},{av:'A248CpjEndSeq',fld:'CPJENDSEQ',pic:'ZZZ9'},{av:'A366CpjTipoSigla',fld:'CPJTIPOSIGLA',pic:''},{av:'A367CpjTipoNome',fld:'CPJTIPONOME',pic:'@!'}]}");
         setEventMetadata("VALID_CPJTIPOID","{handler:'Valid_Cpjtipoid',iparms:[]");
         setEventMetadata("VALID_CPJTIPOID",",oparms:[]}");
         setEventMetadata("VALID_CPJTIPONOME","{handler:'Valid_Cpjtiponome',iparms:[]");
         setEventMetadata("VALID_CPJTIPONOME",",oparms:[]}");
         setEventMetadata("VALID_CPJULTENDSEQ","{handler:'Valid_Cpjultendseq',iparms:[]");
         setEventMetadata("VALID_CPJULTENDSEQ",",oparms:[]}");
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
         pr_default.close(16);
         pr_default.close(17);
         pr_default.close(18);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         wcpOAV7CliID = Guid.Empty;
         wcpOAV8CpjID = Guid.Empty;
         Z158CliID = Guid.Empty;
         Z166CpjID = Guid.Empty;
         Z555CpjEndDelDataHora = (DateTime)(DateTime.MinValue);
         Z556CpjEndDelData = (DateTime)(DateTime.MinValue);
         Z557CpjEndDelHora = (DateTime)(DateTime.MinValue);
         Z558CpjEndDelUsuId = "";
         Z559CpjEndDelUsuNome = "";
         Z249CpjEndNome = "";
         Z251CpjEndCepFormat = "";
         Z252CpjEndEndereco = "";
         Z253CpjEndNumero = "";
         Z254CpjEndComplem = "";
         Z255CpjEndBairro = "";
         Z257CpjEndMunNome = "";
         Z259CpjEndUFSigla = "";
         Z260CpjEndUFNome = "";
         Z170CpjNomeFan = "";
         Z171CpjRazaoSoc = "";
         Z188CpjCNPJFormat = "";
         Z189CpjIE = "";
         Z261CpjTelNum = "";
         Z262CpjTelRam = "";
         Z263CpjCelNum = "";
         Z264CpjWppNum = "";
         Z265CpjWebsite = "";
         Z266CpjEmail = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A158CliID = Guid.Empty;
         A166CpjID = Guid.Empty;
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tablecliente = new GXUserControl();
         A160CliNomeFamiliar = "";
         lblTxtesp01_Jsonclick = "";
         A170CpjNomeFan = "";
         A188CpjCNPJFormat = "";
         A189CpjIE = "";
         gxphoneLink = "";
         A261CpjTelNum = "";
         A262CpjTelRam = "";
         A263CpjCelNum = "";
         A264CpjWppNum = "";
         A265CpjWebsite = "";
         A266CpjEmail = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         A249CpjEndNome = "";
         A251CpjEndCepFormat = "";
         A252CpjEndEndereco = "";
         A253CpjEndNumero = "";
         A254CpjEndComplem = "";
         A255CpjEndBairro = "";
         A257CpjEndMunNome = "";
         A259CpjEndUFSigla = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         A260CpjEndUFNome = "";
         A366CpjTipoSigla = "";
         A367CpjTipoNome = "";
         A171CpjRazaoSoc = "";
         A555CpjEndDelDataHora = (DateTime)(DateTime.MinValue);
         A556CpjEndDelData = (DateTime)(DateTime.MinValue);
         A557CpjEndDelHora = (DateTime)(DateTime.MinValue);
         A558CpjEndDelUsuId = "";
         A559CpjEndDelUsuNome = "";
         A368CpjEndCompleto = "";
         AV38AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
         AV40Pgmname = "";
         Dvpanel_tablecliente_Objectcall = "";
         Dvpanel_tablecliente_Class = "";
         Dvpanel_tablecliente_Height = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode31 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV13WebSession = context.GetSession();
         AV12TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         Z160CliNomeFamiliar = "";
         Z366CpjTipoSigla = "";
         Z367CpjTipoNome = "";
         T00114_A159CliMatricula = new long[1] ;
         T00114_A160CliNomeFamiliar = new string[] {""} ;
         T00116_A267CpjUltEndSeq = new short[1] ;
         T00116_n267CpjUltEndSeq = new bool[] {false} ;
         T00116_A170CpjNomeFan = new string[] {""} ;
         T00116_A171CpjRazaoSoc = new string[] {""} ;
         T00116_A176CpjMatricula = new long[1] ;
         T00116_A187CpjCNPJ = new long[1] ;
         T00116_A188CpjCNPJFormat = new string[] {""} ;
         T00116_A189CpjIE = new string[] {""} ;
         T00116_A207CpjAtivo = new bool[] {false} ;
         T00116_A261CpjTelNum = new string[] {""} ;
         T00116_n261CpjTelNum = new bool[] {false} ;
         T00116_A262CpjTelRam = new string[] {""} ;
         T00116_n262CpjTelRam = new bool[] {false} ;
         T00116_A263CpjCelNum = new string[] {""} ;
         T00116_n263CpjCelNum = new bool[] {false} ;
         T00116_A264CpjWppNum = new string[] {""} ;
         T00116_n264CpjWppNum = new bool[] {false} ;
         T00116_A265CpjWebsite = new string[] {""} ;
         T00116_n265CpjWebsite = new bool[] {false} ;
         T00116_A266CpjEmail = new string[] {""} ;
         T00116_n266CpjEmail = new bool[] {false} ;
         T00116_A365CpjTipoId = new int[1] ;
         T00117_A366CpjTipoSigla = new string[] {""} ;
         T00117_A367CpjTipoNome = new string[] {""} ;
         T00118_A248CpjEndSeq = new short[1] ;
         T00118_A267CpjUltEndSeq = new short[1] ;
         T00118_n267CpjUltEndSeq = new bool[] {false} ;
         T00118_A555CpjEndDelDataHora = new DateTime[] {DateTime.MinValue} ;
         T00118_n555CpjEndDelDataHora = new bool[] {false} ;
         T00118_A556CpjEndDelData = new DateTime[] {DateTime.MinValue} ;
         T00118_n556CpjEndDelData = new bool[] {false} ;
         T00118_A557CpjEndDelHora = new DateTime[] {DateTime.MinValue} ;
         T00118_n557CpjEndDelHora = new bool[] {false} ;
         T00118_A558CpjEndDelUsuId = new string[] {""} ;
         T00118_n558CpjEndDelUsuId = new bool[] {false} ;
         T00118_A559CpjEndDelUsuNome = new string[] {""} ;
         T00118_n559CpjEndDelUsuNome = new bool[] {false} ;
         T00118_A159CliMatricula = new long[1] ;
         T00118_A160CliNomeFamiliar = new string[] {""} ;
         T00118_A366CpjTipoSigla = new string[] {""} ;
         T00118_A367CpjTipoNome = new string[] {""} ;
         T00118_A170CpjNomeFan = new string[] {""} ;
         T00118_A171CpjRazaoSoc = new string[] {""} ;
         T00118_A176CpjMatricula = new long[1] ;
         T00118_A187CpjCNPJ = new long[1] ;
         T00118_A188CpjCNPJFormat = new string[] {""} ;
         T00118_A189CpjIE = new string[] {""} ;
         T00118_A207CpjAtivo = new bool[] {false} ;
         T00118_A261CpjTelNum = new string[] {""} ;
         T00118_n261CpjTelNum = new bool[] {false} ;
         T00118_A262CpjTelRam = new string[] {""} ;
         T00118_n262CpjTelRam = new bool[] {false} ;
         T00118_A263CpjCelNum = new string[] {""} ;
         T00118_n263CpjCelNum = new bool[] {false} ;
         T00118_A264CpjWppNum = new string[] {""} ;
         T00118_n264CpjWppNum = new bool[] {false} ;
         T00118_A265CpjWebsite = new string[] {""} ;
         T00118_n265CpjWebsite = new bool[] {false} ;
         T00118_A266CpjEmail = new string[] {""} ;
         T00118_n266CpjEmail = new bool[] {false} ;
         T00118_A249CpjEndNome = new string[] {""} ;
         T00118_A250CpjEndCep = new int[1] ;
         T00118_A251CpjEndCepFormat = new string[] {""} ;
         T00118_A252CpjEndEndereco = new string[] {""} ;
         T00118_A253CpjEndNumero = new string[] {""} ;
         T00118_A254CpjEndComplem = new string[] {""} ;
         T00118_n254CpjEndComplem = new bool[] {false} ;
         T00118_A255CpjEndBairro = new string[] {""} ;
         T00118_A256CpjEndMunID = new int[1] ;
         T00118_A257CpjEndMunNome = new string[] {""} ;
         T00118_A258CpjEndUFId = new short[1] ;
         T00118_A259CpjEndUFSigla = new string[] {""} ;
         T00118_A260CpjEndUFNome = new string[] {""} ;
         T00118_A554CpjEndDel = new bool[] {false} ;
         T00118_A158CliID = new Guid[] {Guid.Empty} ;
         T00118_A166CpjID = new Guid[] {Guid.Empty} ;
         T00118_A365CpjTipoId = new int[1] ;
         T00119_A159CliMatricula = new long[1] ;
         T00119_A160CliNomeFamiliar = new string[] {""} ;
         T001110_A366CpjTipoSigla = new string[] {""} ;
         T001110_A367CpjTipoNome = new string[] {""} ;
         T001111_A158CliID = new Guid[] {Guid.Empty} ;
         T001111_A166CpjID = new Guid[] {Guid.Empty} ;
         T001111_A248CpjEndSeq = new short[1] ;
         T00113_A248CpjEndSeq = new short[1] ;
         T00113_A555CpjEndDelDataHora = new DateTime[] {DateTime.MinValue} ;
         T00113_n555CpjEndDelDataHora = new bool[] {false} ;
         T00113_A556CpjEndDelData = new DateTime[] {DateTime.MinValue} ;
         T00113_n556CpjEndDelData = new bool[] {false} ;
         T00113_A557CpjEndDelHora = new DateTime[] {DateTime.MinValue} ;
         T00113_n557CpjEndDelHora = new bool[] {false} ;
         T00113_A558CpjEndDelUsuId = new string[] {""} ;
         T00113_n558CpjEndDelUsuId = new bool[] {false} ;
         T00113_A559CpjEndDelUsuNome = new string[] {""} ;
         T00113_n559CpjEndDelUsuNome = new bool[] {false} ;
         T00113_A249CpjEndNome = new string[] {""} ;
         T00113_A250CpjEndCep = new int[1] ;
         T00113_A251CpjEndCepFormat = new string[] {""} ;
         T00113_A252CpjEndEndereco = new string[] {""} ;
         T00113_A253CpjEndNumero = new string[] {""} ;
         T00113_A254CpjEndComplem = new string[] {""} ;
         T00113_n254CpjEndComplem = new bool[] {false} ;
         T00113_A255CpjEndBairro = new string[] {""} ;
         T00113_A256CpjEndMunID = new int[1] ;
         T00113_A257CpjEndMunNome = new string[] {""} ;
         T00113_A258CpjEndUFId = new short[1] ;
         T00113_A259CpjEndUFSigla = new string[] {""} ;
         T00113_A260CpjEndUFNome = new string[] {""} ;
         T00113_A554CpjEndDel = new bool[] {false} ;
         T00113_A158CliID = new Guid[] {Guid.Empty} ;
         T00113_A166CpjID = new Guid[] {Guid.Empty} ;
         T001112_A158CliID = new Guid[] {Guid.Empty} ;
         T001112_A166CpjID = new Guid[] {Guid.Empty} ;
         T001112_A248CpjEndSeq = new short[1] ;
         T001113_A158CliID = new Guid[] {Guid.Empty} ;
         T001113_A166CpjID = new Guid[] {Guid.Empty} ;
         T001113_A248CpjEndSeq = new short[1] ;
         T00112_A248CpjEndSeq = new short[1] ;
         T00112_A555CpjEndDelDataHora = new DateTime[] {DateTime.MinValue} ;
         T00112_n555CpjEndDelDataHora = new bool[] {false} ;
         T00112_A556CpjEndDelData = new DateTime[] {DateTime.MinValue} ;
         T00112_n556CpjEndDelData = new bool[] {false} ;
         T00112_A557CpjEndDelHora = new DateTime[] {DateTime.MinValue} ;
         T00112_n557CpjEndDelHora = new bool[] {false} ;
         T00112_A558CpjEndDelUsuId = new string[] {""} ;
         T00112_n558CpjEndDelUsuId = new bool[] {false} ;
         T00112_A559CpjEndDelUsuNome = new string[] {""} ;
         T00112_n559CpjEndDelUsuNome = new bool[] {false} ;
         T00112_A249CpjEndNome = new string[] {""} ;
         T00112_A250CpjEndCep = new int[1] ;
         T00112_A251CpjEndCepFormat = new string[] {""} ;
         T00112_A252CpjEndEndereco = new string[] {""} ;
         T00112_A253CpjEndNumero = new string[] {""} ;
         T00112_A254CpjEndComplem = new string[] {""} ;
         T00112_n254CpjEndComplem = new bool[] {false} ;
         T00112_A255CpjEndBairro = new string[] {""} ;
         T00112_A256CpjEndMunID = new int[1] ;
         T00112_A257CpjEndMunNome = new string[] {""} ;
         T00112_A258CpjEndUFId = new short[1] ;
         T00112_A259CpjEndUFSigla = new string[] {""} ;
         T00112_A260CpjEndUFNome = new string[] {""} ;
         T00112_A554CpjEndDel = new bool[] {false} ;
         T00112_A158CliID = new Guid[] {Guid.Empty} ;
         T00112_A166CpjID = new Guid[] {Guid.Empty} ;
         T001114_A267CpjUltEndSeq = new short[1] ;
         T001114_n267CpjUltEndSeq = new bool[] {false} ;
         T001114_A170CpjNomeFan = new string[] {""} ;
         T001114_A171CpjRazaoSoc = new string[] {""} ;
         T001114_A176CpjMatricula = new long[1] ;
         T001114_A187CpjCNPJ = new long[1] ;
         T001114_A188CpjCNPJFormat = new string[] {""} ;
         T001114_A189CpjIE = new string[] {""} ;
         T001114_A207CpjAtivo = new bool[] {false} ;
         T001114_A261CpjTelNum = new string[] {""} ;
         T001114_n261CpjTelNum = new bool[] {false} ;
         T001114_A262CpjTelRam = new string[] {""} ;
         T001114_n262CpjTelRam = new bool[] {false} ;
         T001114_A263CpjCelNum = new string[] {""} ;
         T001114_n263CpjCelNum = new bool[] {false} ;
         T001114_A264CpjWppNum = new string[] {""} ;
         T001114_n264CpjWppNum = new bool[] {false} ;
         T001114_A265CpjWebsite = new string[] {""} ;
         T001114_n265CpjWebsite = new bool[] {false} ;
         T001114_A266CpjEmail = new string[] {""} ;
         T001114_n266CpjEmail = new bool[] {false} ;
         T001114_A365CpjTipoId = new int[1] ;
         T001118_A159CliMatricula = new long[1] ;
         T001118_A160CliNomeFamiliar = new string[] {""} ;
         T001119_A267CpjUltEndSeq = new short[1] ;
         T001119_n267CpjUltEndSeq = new bool[] {false} ;
         T001119_A170CpjNomeFan = new string[] {""} ;
         T001119_A171CpjRazaoSoc = new string[] {""} ;
         T001119_A176CpjMatricula = new long[1] ;
         T001119_A187CpjCNPJ = new long[1] ;
         T001119_A188CpjCNPJFormat = new string[] {""} ;
         T001119_A189CpjIE = new string[] {""} ;
         T001119_A207CpjAtivo = new bool[] {false} ;
         T001119_A261CpjTelNum = new string[] {""} ;
         T001119_n261CpjTelNum = new bool[] {false} ;
         T001119_A262CpjTelRam = new string[] {""} ;
         T001119_n262CpjTelRam = new bool[] {false} ;
         T001119_A263CpjCelNum = new string[] {""} ;
         T001119_n263CpjCelNum = new bool[] {false} ;
         T001119_A264CpjWppNum = new string[] {""} ;
         T001119_n264CpjWppNum = new bool[] {false} ;
         T001119_A265CpjWebsite = new string[] {""} ;
         T001119_n265CpjWebsite = new bool[] {false} ;
         T001119_A266CpjEmail = new string[] {""} ;
         T001119_n266CpjEmail = new bool[] {false} ;
         T001119_A365CpjTipoId = new int[1] ;
         T001120_A366CpjTipoSigla = new string[] {""} ;
         T001120_A367CpjTipoNome = new string[] {""} ;
         T001121_A345NegID = new Guid[] {Guid.Empty} ;
         T001123_A158CliID = new Guid[] {Guid.Empty} ;
         T001123_A166CpjID = new Guid[] {Guid.Empty} ;
         T001123_A248CpjEndSeq = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.core.clientepjendereco__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.clientepjendereco__default(),
            new Object[][] {
                new Object[] {
               T00112_A248CpjEndSeq, T00112_A555CpjEndDelDataHora, T00112_n555CpjEndDelDataHora, T00112_A556CpjEndDelData, T00112_n556CpjEndDelData, T00112_A557CpjEndDelHora, T00112_n557CpjEndDelHora, T00112_A558CpjEndDelUsuId, T00112_n558CpjEndDelUsuId, T00112_A559CpjEndDelUsuNome,
               T00112_n559CpjEndDelUsuNome, T00112_A249CpjEndNome, T00112_A250CpjEndCep, T00112_A251CpjEndCepFormat, T00112_A252CpjEndEndereco, T00112_A253CpjEndNumero, T00112_A254CpjEndComplem, T00112_n254CpjEndComplem, T00112_A255CpjEndBairro, T00112_A256CpjEndMunID,
               T00112_A257CpjEndMunNome, T00112_A258CpjEndUFId, T00112_A259CpjEndUFSigla, T00112_A260CpjEndUFNome, T00112_A554CpjEndDel, T00112_A158CliID, T00112_A166CpjID
               }
               , new Object[] {
               T00113_A248CpjEndSeq, T00113_A555CpjEndDelDataHora, T00113_n555CpjEndDelDataHora, T00113_A556CpjEndDelData, T00113_n556CpjEndDelData, T00113_A557CpjEndDelHora, T00113_n557CpjEndDelHora, T00113_A558CpjEndDelUsuId, T00113_n558CpjEndDelUsuId, T00113_A559CpjEndDelUsuNome,
               T00113_n559CpjEndDelUsuNome, T00113_A249CpjEndNome, T00113_A250CpjEndCep, T00113_A251CpjEndCepFormat, T00113_A252CpjEndEndereco, T00113_A253CpjEndNumero, T00113_A254CpjEndComplem, T00113_n254CpjEndComplem, T00113_A255CpjEndBairro, T00113_A256CpjEndMunID,
               T00113_A257CpjEndMunNome, T00113_A258CpjEndUFId, T00113_A259CpjEndUFSigla, T00113_A260CpjEndUFNome, T00113_A554CpjEndDel, T00113_A158CliID, T00113_A166CpjID
               }
               , new Object[] {
               T00114_A159CliMatricula, T00114_A160CliNomeFamiliar
               }
               , new Object[] {
               T00115_A267CpjUltEndSeq, T00115_n267CpjUltEndSeq, T00115_A170CpjNomeFan, T00115_A171CpjRazaoSoc, T00115_A176CpjMatricula, T00115_A187CpjCNPJ, T00115_A188CpjCNPJFormat, T00115_A189CpjIE, T00115_A207CpjAtivo, T00115_A261CpjTelNum,
               T00115_n261CpjTelNum, T00115_A262CpjTelRam, T00115_n262CpjTelRam, T00115_A263CpjCelNum, T00115_n263CpjCelNum, T00115_A264CpjWppNum, T00115_n264CpjWppNum, T00115_A265CpjWebsite, T00115_n265CpjWebsite, T00115_A266CpjEmail,
               T00115_n266CpjEmail, T00115_A365CpjTipoId
               }
               , new Object[] {
               T00116_A267CpjUltEndSeq, T00116_n267CpjUltEndSeq, T00116_A170CpjNomeFan, T00116_A171CpjRazaoSoc, T00116_A176CpjMatricula, T00116_A187CpjCNPJ, T00116_A188CpjCNPJFormat, T00116_A189CpjIE, T00116_A207CpjAtivo, T00116_A261CpjTelNum,
               T00116_n261CpjTelNum, T00116_A262CpjTelRam, T00116_n262CpjTelRam, T00116_A263CpjCelNum, T00116_n263CpjCelNum, T00116_A264CpjWppNum, T00116_n264CpjWppNum, T00116_A265CpjWebsite, T00116_n265CpjWebsite, T00116_A266CpjEmail,
               T00116_n266CpjEmail, T00116_A365CpjTipoId
               }
               , new Object[] {
               T00117_A366CpjTipoSigla, T00117_A367CpjTipoNome
               }
               , new Object[] {
               T00118_A248CpjEndSeq, T00118_A267CpjUltEndSeq, T00118_n267CpjUltEndSeq, T00118_A555CpjEndDelDataHora, T00118_n555CpjEndDelDataHora, T00118_A556CpjEndDelData, T00118_n556CpjEndDelData, T00118_A557CpjEndDelHora, T00118_n557CpjEndDelHora, T00118_A558CpjEndDelUsuId,
               T00118_n558CpjEndDelUsuId, T00118_A559CpjEndDelUsuNome, T00118_n559CpjEndDelUsuNome, T00118_A159CliMatricula, T00118_A160CliNomeFamiliar, T00118_A366CpjTipoSigla, T00118_A367CpjTipoNome, T00118_A170CpjNomeFan, T00118_A171CpjRazaoSoc, T00118_A176CpjMatricula,
               T00118_A187CpjCNPJ, T00118_A188CpjCNPJFormat, T00118_A189CpjIE, T00118_A207CpjAtivo, T00118_A261CpjTelNum, T00118_n261CpjTelNum, T00118_A262CpjTelRam, T00118_n262CpjTelRam, T00118_A263CpjCelNum, T00118_n263CpjCelNum,
               T00118_A264CpjWppNum, T00118_n264CpjWppNum, T00118_A265CpjWebsite, T00118_n265CpjWebsite, T00118_A266CpjEmail, T00118_n266CpjEmail, T00118_A249CpjEndNome, T00118_A250CpjEndCep, T00118_A251CpjEndCepFormat, T00118_A252CpjEndEndereco,
               T00118_A253CpjEndNumero, T00118_A254CpjEndComplem, T00118_n254CpjEndComplem, T00118_A255CpjEndBairro, T00118_A256CpjEndMunID, T00118_A257CpjEndMunNome, T00118_A258CpjEndUFId, T00118_A259CpjEndUFSigla, T00118_A260CpjEndUFNome, T00118_A554CpjEndDel,
               T00118_A158CliID, T00118_A166CpjID, T00118_A365CpjTipoId
               }
               , new Object[] {
               T00119_A159CliMatricula, T00119_A160CliNomeFamiliar
               }
               , new Object[] {
               T001110_A366CpjTipoSigla, T001110_A367CpjTipoNome
               }
               , new Object[] {
               T001111_A158CliID, T001111_A166CpjID, T001111_A248CpjEndSeq
               }
               , new Object[] {
               T001112_A158CliID, T001112_A166CpjID, T001112_A248CpjEndSeq
               }
               , new Object[] {
               T001113_A158CliID, T001113_A166CpjID, T001113_A248CpjEndSeq
               }
               , new Object[] {
               T001114_A267CpjUltEndSeq, T001114_n267CpjUltEndSeq, T001114_A170CpjNomeFan, T001114_A171CpjRazaoSoc, T001114_A176CpjMatricula, T001114_A187CpjCNPJ, T001114_A188CpjCNPJFormat, T001114_A189CpjIE, T001114_A207CpjAtivo, T001114_A261CpjTelNum,
               T001114_n261CpjTelNum, T001114_A262CpjTelRam, T001114_n262CpjTelRam, T001114_A263CpjCelNum, T001114_n263CpjCelNum, T001114_A264CpjWppNum, T001114_n264CpjWppNum, T001114_A265CpjWebsite, T001114_n265CpjWebsite, T001114_A266CpjEmail,
               T001114_n266CpjEmail, T001114_A365CpjTipoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001118_A159CliMatricula, T001118_A160CliNomeFamiliar
               }
               , new Object[] {
               T001119_A267CpjUltEndSeq, T001119_n267CpjUltEndSeq, T001119_A170CpjNomeFan, T001119_A171CpjRazaoSoc, T001119_A176CpjMatricula, T001119_A187CpjCNPJ, T001119_A188CpjCNPJFormat, T001119_A189CpjIE, T001119_A207CpjAtivo, T001119_A261CpjTelNum,
               T001119_n261CpjTelNum, T001119_A262CpjTelRam, T001119_n262CpjTelRam, T001119_A263CpjCelNum, T001119_n263CpjCelNum, T001119_A264CpjWppNum, T001119_n264CpjWppNum, T001119_A265CpjWebsite, T001119_n265CpjWebsite, T001119_A266CpjEmail,
               T001119_n266CpjEmail, T001119_A365CpjTipoId
               }
               , new Object[] {
               T001120_A366CpjTipoSigla, T001120_A367CpjTipoNome
               }
               , new Object[] {
               T001121_A345NegID
               }
               , new Object[] {
               }
               , new Object[] {
               T001123_A158CliID, T001123_A166CpjID, T001123_A248CpjEndSeq
               }
            }
         );
         AV40Pgmname = "core.ClientePJEndereco";
      }

      private short wcpOAV37CpjEndSeq ;
      private short Z248CpjEndSeq ;
      private short Z258CpjEndUFId ;
      private short O267CpjUltEndSeq ;
      private short GxWebError ;
      private short AV37CpjEndSeq ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A248CpjEndSeq ;
      private short A258CpjEndUFId ;
      private short A267CpjUltEndSeq ;
      private short Gx_BScreen ;
      private short RcdFound31 ;
      private short GX_JID ;
      private short Z267CpjUltEndSeq ;
      private short nIsDirty_31 ;
      private short gxajaxcallmode ;
      private short ZO267CpjUltEndSeq ;
      private int Z250CpjEndCep ;
      private int Z256CpjEndMunID ;
      private int Z365CpjTipoId ;
      private int A365CpjTipoId ;
      private int trnEnded ;
      private int edtCliNomeFamiliar_Enabled ;
      private int edtCliMatricula_Enabled ;
      private int edtCpjNomeFan_Enabled ;
      private int edtCpjMatricula_Enabled ;
      private int edtCpjCNPJFormat_Enabled ;
      private int edtCpjIE_Enabled ;
      private int edtCpjTelNum_Enabled ;
      private int edtCpjTelRam_Enabled ;
      private int edtCpjCelNum_Enabled ;
      private int edtCpjWppNum_Enabled ;
      private int edtCpjWebsite_Enabled ;
      private int edtCpjEmail_Enabled ;
      private int edtCpjEndNome_Enabled ;
      private int edtCpjEndCepFormat_Enabled ;
      private int edtCpjEndEndereco_Enabled ;
      private int edtCpjEndNumero_Enabled ;
      private int edtCpjEndComplem_Enabled ;
      private int edtCpjEndBairro_Enabled ;
      private int edtCpjEndMunNome_Enabled ;
      private int edtCpjEndUFSigla_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int edtCpjEndSeq_Visible ;
      private int edtCpjEndSeq_Enabled ;
      private int A250CpjEndCep ;
      private int edtCpjEndCep_Enabled ;
      private int edtCpjEndCep_Visible ;
      private int A256CpjEndMunID ;
      private int edtCpjEndMunID_Enabled ;
      private int edtCpjEndMunID_Visible ;
      private int edtCpjEndUFId_Enabled ;
      private int edtCpjEndUFId_Visible ;
      private int edtCpjEndUFNome_Visible ;
      private int edtCpjEndUFNome_Enabled ;
      private int edtCliID_Visible ;
      private int edtCliID_Enabled ;
      private int edtCpjID_Visible ;
      private int edtCpjID_Enabled ;
      private int edtCpjTipoId_Enabled ;
      private int edtCpjTipoId_Visible ;
      private int edtCpjTipoSigla_Visible ;
      private int edtCpjTipoSigla_Enabled ;
      private int edtCpjTipoNome_Visible ;
      private int edtCpjTipoNome_Enabled ;
      private int edtCpjRazaoSoc_Visible ;
      private int edtCpjRazaoSoc_Enabled ;
      private int edtCpjCNPJ_Enabled ;
      private int edtCpjCNPJ_Visible ;
      private int edtCpjAtivo_Visible ;
      private int edtCpjAtivo_Enabled ;
      private int edtCpjUltEndSeq_Enabled ;
      private int edtCpjUltEndSeq_Visible ;
      private int Dvpanel_tablecliente_Gxcontroltype ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int idxLst ;
      private long Z176CpjMatricula ;
      private long Z187CpjCNPJ ;
      private long A159CliMatricula ;
      private long A176CpjMatricula ;
      private long A187CpjCNPJ ;
      private long Z159CliMatricula ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z558CpjEndDelUsuId ;
      private string Z261CpjTelNum ;
      private string Z263CpjCelNum ;
      private string Z264CpjWppNum ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtCpjEndNome_Internalname ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string Dvpanel_tablecliente_Width ;
      private string Dvpanel_tablecliente_Cls ;
      private string Dvpanel_tablecliente_Title ;
      private string Dvpanel_tablecliente_Iconposition ;
      private string Dvpanel_tablecliente_Internalname ;
      private string divTablecliente_Internalname ;
      private string edtCliNomeFamiliar_Internalname ;
      private string edtCliNomeFamiliar_Jsonclick ;
      private string edtCliMatricula_Internalname ;
      private string edtCliMatricula_Jsonclick ;
      private string lblTxtesp01_Internalname ;
      private string lblTxtesp01_Jsonclick ;
      private string edtCpjNomeFan_Internalname ;
      private string edtCpjNomeFan_Jsonclick ;
      private string edtCpjMatricula_Internalname ;
      private string edtCpjMatricula_Jsonclick ;
      private string edtCpjCNPJFormat_Internalname ;
      private string edtCpjCNPJFormat_Jsonclick ;
      private string edtCpjIE_Internalname ;
      private string edtCpjIE_Jsonclick ;
      private string edtCpjTelNum_Internalname ;
      private string gxphoneLink ;
      private string A261CpjTelNum ;
      private string edtCpjTelNum_Jsonclick ;
      private string edtCpjTelRam_Internalname ;
      private string edtCpjTelRam_Jsonclick ;
      private string edtCpjCelNum_Internalname ;
      private string A263CpjCelNum ;
      private string edtCpjCelNum_Jsonclick ;
      private string edtCpjWppNum_Internalname ;
      private string A264CpjWppNum ;
      private string edtCpjWppNum_Jsonclick ;
      private string edtCpjWebsite_Internalname ;
      private string edtCpjWebsite_Jsonclick ;
      private string edtCpjEmail_Internalname ;
      private string edtCpjEmail_Jsonclick ;
      private string Dvpanel_tableattributes_Width ;
      private string Dvpanel_tableattributes_Cls ;
      private string Dvpanel_tableattributes_Title ;
      private string Dvpanel_tableattributes_Iconposition ;
      private string Dvpanel_tableattributes_Internalname ;
      private string divTableattributes_Internalname ;
      private string TempTags ;
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
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
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
      private string edtCliID_Internalname ;
      private string edtCliID_Jsonclick ;
      private string edtCpjID_Internalname ;
      private string edtCpjID_Jsonclick ;
      private string edtCpjTipoId_Internalname ;
      private string edtCpjTipoId_Jsonclick ;
      private string edtCpjTipoSigla_Internalname ;
      private string edtCpjTipoSigla_Jsonclick ;
      private string edtCpjTipoNome_Internalname ;
      private string edtCpjTipoNome_Jsonclick ;
      private string edtCpjRazaoSoc_Internalname ;
      private string edtCpjRazaoSoc_Jsonclick ;
      private string edtCpjCNPJ_Internalname ;
      private string edtCpjCNPJ_Jsonclick ;
      private string edtCpjAtivo_Internalname ;
      private string edtCpjAtivo_Jsonclick ;
      private string edtCpjUltEndSeq_Internalname ;
      private string edtCpjUltEndSeq_Jsonclick ;
      private string A558CpjEndDelUsuId ;
      private string AV40Pgmname ;
      private string Dvpanel_tablecliente_Objectcall ;
      private string Dvpanel_tablecliente_Class ;
      private string Dvpanel_tablecliente_Height ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string hsh ;
      private string sMode31 ;
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
      private DateTime Z555CpjEndDelDataHora ;
      private DateTime Z556CpjEndDelData ;
      private DateTime Z557CpjEndDelHora ;
      private DateTime A555CpjEndDelDataHora ;
      private DateTime A556CpjEndDelData ;
      private DateTime A557CpjEndDelHora ;
      private bool Z554CpjEndDel ;
      private bool Z207CpjAtivo ;
      private bool O554CpjEndDel ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Dvpanel_tablecliente_Autowidth ;
      private bool Dvpanel_tablecliente_Autoheight ;
      private bool Dvpanel_tablecliente_Collapsible ;
      private bool Dvpanel_tablecliente_Collapsed ;
      private bool Dvpanel_tablecliente_Showcollapseicon ;
      private bool Dvpanel_tablecliente_Autoscroll ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool A207CpjAtivo ;
      private bool n555CpjEndDelDataHora ;
      private bool n556CpjEndDelData ;
      private bool n557CpjEndDelHora ;
      private bool n558CpjEndDelUsuId ;
      private bool n559CpjEndDelUsuNome ;
      private bool n254CpjEndComplem ;
      private bool A554CpjEndDel ;
      private bool n267CpjUltEndSeq ;
      private bool Dvpanel_tablecliente_Enabled ;
      private bool Dvpanel_tablecliente_Showheader ;
      private bool Dvpanel_tablecliente_Visible ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool n261CpjTelNum ;
      private bool n262CpjTelRam ;
      private bool n263CpjCelNum ;
      private bool n264CpjWppNum ;
      private bool n265CpjWebsite ;
      private bool n266CpjEmail ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private string Z559CpjEndDelUsuNome ;
      private string Z249CpjEndNome ;
      private string Z251CpjEndCepFormat ;
      private string Z252CpjEndEndereco ;
      private string Z253CpjEndNumero ;
      private string Z254CpjEndComplem ;
      private string Z255CpjEndBairro ;
      private string Z257CpjEndMunNome ;
      private string Z259CpjEndUFSigla ;
      private string Z260CpjEndUFNome ;
      private string Z170CpjNomeFan ;
      private string Z171CpjRazaoSoc ;
      private string Z188CpjCNPJFormat ;
      private string Z189CpjIE ;
      private string Z262CpjTelRam ;
      private string Z265CpjWebsite ;
      private string Z266CpjEmail ;
      private string A160CliNomeFamiliar ;
      private string A170CpjNomeFan ;
      private string A188CpjCNPJFormat ;
      private string A189CpjIE ;
      private string A262CpjTelRam ;
      private string A265CpjWebsite ;
      private string A266CpjEmail ;
      private string A249CpjEndNome ;
      private string A251CpjEndCepFormat ;
      private string A252CpjEndEndereco ;
      private string A253CpjEndNumero ;
      private string A254CpjEndComplem ;
      private string A255CpjEndBairro ;
      private string A257CpjEndMunNome ;
      private string A259CpjEndUFSigla ;
      private string A260CpjEndUFNome ;
      private string A366CpjTipoSigla ;
      private string A367CpjTipoNome ;
      private string A171CpjRazaoSoc ;
      private string A559CpjEndDelUsuNome ;
      private string A368CpjEndCompleto ;
      private string Z160CliNomeFamiliar ;
      private string Z366CpjTipoSigla ;
      private string Z367CpjTipoNome ;
      private Guid wcpOAV7CliID ;
      private Guid wcpOAV8CpjID ;
      private Guid Z158CliID ;
      private Guid Z166CpjID ;
      private Guid A158CliID ;
      private Guid A166CpjID ;
      private Guid AV7CliID ;
      private Guid AV8CpjID ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tablecliente ;
      private GXUserControl ucDvpanel_tableattributes ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] T00114_A159CliMatricula ;
      private string[] T00114_A160CliNomeFamiliar ;
      private short[] T00116_A267CpjUltEndSeq ;
      private bool[] T00116_n267CpjUltEndSeq ;
      private string[] T00116_A170CpjNomeFan ;
      private string[] T00116_A171CpjRazaoSoc ;
      private long[] T00116_A176CpjMatricula ;
      private long[] T00116_A187CpjCNPJ ;
      private string[] T00116_A188CpjCNPJFormat ;
      private string[] T00116_A189CpjIE ;
      private bool[] T00116_A207CpjAtivo ;
      private string[] T00116_A261CpjTelNum ;
      private bool[] T00116_n261CpjTelNum ;
      private string[] T00116_A262CpjTelRam ;
      private bool[] T00116_n262CpjTelRam ;
      private string[] T00116_A263CpjCelNum ;
      private bool[] T00116_n263CpjCelNum ;
      private string[] T00116_A264CpjWppNum ;
      private bool[] T00116_n264CpjWppNum ;
      private string[] T00116_A265CpjWebsite ;
      private bool[] T00116_n265CpjWebsite ;
      private string[] T00116_A266CpjEmail ;
      private bool[] T00116_n266CpjEmail ;
      private int[] T00116_A365CpjTipoId ;
      private string[] T00117_A366CpjTipoSigla ;
      private string[] T00117_A367CpjTipoNome ;
      private short[] T00118_A248CpjEndSeq ;
      private short[] T00118_A267CpjUltEndSeq ;
      private bool[] T00118_n267CpjUltEndSeq ;
      private DateTime[] T00118_A555CpjEndDelDataHora ;
      private bool[] T00118_n555CpjEndDelDataHora ;
      private DateTime[] T00118_A556CpjEndDelData ;
      private bool[] T00118_n556CpjEndDelData ;
      private DateTime[] T00118_A557CpjEndDelHora ;
      private bool[] T00118_n557CpjEndDelHora ;
      private string[] T00118_A558CpjEndDelUsuId ;
      private bool[] T00118_n558CpjEndDelUsuId ;
      private string[] T00118_A559CpjEndDelUsuNome ;
      private bool[] T00118_n559CpjEndDelUsuNome ;
      private long[] T00118_A159CliMatricula ;
      private string[] T00118_A160CliNomeFamiliar ;
      private string[] T00118_A366CpjTipoSigla ;
      private string[] T00118_A367CpjTipoNome ;
      private string[] T00118_A170CpjNomeFan ;
      private string[] T00118_A171CpjRazaoSoc ;
      private long[] T00118_A176CpjMatricula ;
      private long[] T00118_A187CpjCNPJ ;
      private string[] T00118_A188CpjCNPJFormat ;
      private string[] T00118_A189CpjIE ;
      private bool[] T00118_A207CpjAtivo ;
      private string[] T00118_A261CpjTelNum ;
      private bool[] T00118_n261CpjTelNum ;
      private string[] T00118_A262CpjTelRam ;
      private bool[] T00118_n262CpjTelRam ;
      private string[] T00118_A263CpjCelNum ;
      private bool[] T00118_n263CpjCelNum ;
      private string[] T00118_A264CpjWppNum ;
      private bool[] T00118_n264CpjWppNum ;
      private string[] T00118_A265CpjWebsite ;
      private bool[] T00118_n265CpjWebsite ;
      private string[] T00118_A266CpjEmail ;
      private bool[] T00118_n266CpjEmail ;
      private string[] T00118_A249CpjEndNome ;
      private int[] T00118_A250CpjEndCep ;
      private string[] T00118_A251CpjEndCepFormat ;
      private string[] T00118_A252CpjEndEndereco ;
      private string[] T00118_A253CpjEndNumero ;
      private string[] T00118_A254CpjEndComplem ;
      private bool[] T00118_n254CpjEndComplem ;
      private string[] T00118_A255CpjEndBairro ;
      private int[] T00118_A256CpjEndMunID ;
      private string[] T00118_A257CpjEndMunNome ;
      private short[] T00118_A258CpjEndUFId ;
      private string[] T00118_A259CpjEndUFSigla ;
      private string[] T00118_A260CpjEndUFNome ;
      private bool[] T00118_A554CpjEndDel ;
      private Guid[] T00118_A158CliID ;
      private Guid[] T00118_A166CpjID ;
      private int[] T00118_A365CpjTipoId ;
      private long[] T00119_A159CliMatricula ;
      private string[] T00119_A160CliNomeFamiliar ;
      private string[] T001110_A366CpjTipoSigla ;
      private string[] T001110_A367CpjTipoNome ;
      private Guid[] T001111_A158CliID ;
      private Guid[] T001111_A166CpjID ;
      private short[] T001111_A248CpjEndSeq ;
      private short[] T00113_A248CpjEndSeq ;
      private DateTime[] T00113_A555CpjEndDelDataHora ;
      private bool[] T00113_n555CpjEndDelDataHora ;
      private DateTime[] T00113_A556CpjEndDelData ;
      private bool[] T00113_n556CpjEndDelData ;
      private DateTime[] T00113_A557CpjEndDelHora ;
      private bool[] T00113_n557CpjEndDelHora ;
      private string[] T00113_A558CpjEndDelUsuId ;
      private bool[] T00113_n558CpjEndDelUsuId ;
      private string[] T00113_A559CpjEndDelUsuNome ;
      private bool[] T00113_n559CpjEndDelUsuNome ;
      private string[] T00113_A249CpjEndNome ;
      private int[] T00113_A250CpjEndCep ;
      private string[] T00113_A251CpjEndCepFormat ;
      private string[] T00113_A252CpjEndEndereco ;
      private string[] T00113_A253CpjEndNumero ;
      private string[] T00113_A254CpjEndComplem ;
      private bool[] T00113_n254CpjEndComplem ;
      private string[] T00113_A255CpjEndBairro ;
      private int[] T00113_A256CpjEndMunID ;
      private string[] T00113_A257CpjEndMunNome ;
      private short[] T00113_A258CpjEndUFId ;
      private string[] T00113_A259CpjEndUFSigla ;
      private string[] T00113_A260CpjEndUFNome ;
      private bool[] T00113_A554CpjEndDel ;
      private Guid[] T00113_A158CliID ;
      private Guid[] T00113_A166CpjID ;
      private Guid[] T001112_A158CliID ;
      private Guid[] T001112_A166CpjID ;
      private short[] T001112_A248CpjEndSeq ;
      private Guid[] T001113_A158CliID ;
      private Guid[] T001113_A166CpjID ;
      private short[] T001113_A248CpjEndSeq ;
      private short[] T00112_A248CpjEndSeq ;
      private DateTime[] T00112_A555CpjEndDelDataHora ;
      private bool[] T00112_n555CpjEndDelDataHora ;
      private DateTime[] T00112_A556CpjEndDelData ;
      private bool[] T00112_n556CpjEndDelData ;
      private DateTime[] T00112_A557CpjEndDelHora ;
      private bool[] T00112_n557CpjEndDelHora ;
      private string[] T00112_A558CpjEndDelUsuId ;
      private bool[] T00112_n558CpjEndDelUsuId ;
      private string[] T00112_A559CpjEndDelUsuNome ;
      private bool[] T00112_n559CpjEndDelUsuNome ;
      private string[] T00112_A249CpjEndNome ;
      private int[] T00112_A250CpjEndCep ;
      private string[] T00112_A251CpjEndCepFormat ;
      private string[] T00112_A252CpjEndEndereco ;
      private string[] T00112_A253CpjEndNumero ;
      private string[] T00112_A254CpjEndComplem ;
      private bool[] T00112_n254CpjEndComplem ;
      private string[] T00112_A255CpjEndBairro ;
      private int[] T00112_A256CpjEndMunID ;
      private string[] T00112_A257CpjEndMunNome ;
      private short[] T00112_A258CpjEndUFId ;
      private string[] T00112_A259CpjEndUFSigla ;
      private string[] T00112_A260CpjEndUFNome ;
      private bool[] T00112_A554CpjEndDel ;
      private Guid[] T00112_A158CliID ;
      private Guid[] T00112_A166CpjID ;
      private short[] T001114_A267CpjUltEndSeq ;
      private bool[] T001114_n267CpjUltEndSeq ;
      private string[] T001114_A170CpjNomeFan ;
      private string[] T001114_A171CpjRazaoSoc ;
      private long[] T001114_A176CpjMatricula ;
      private long[] T001114_A187CpjCNPJ ;
      private string[] T001114_A188CpjCNPJFormat ;
      private string[] T001114_A189CpjIE ;
      private bool[] T001114_A207CpjAtivo ;
      private string[] T001114_A261CpjTelNum ;
      private bool[] T001114_n261CpjTelNum ;
      private string[] T001114_A262CpjTelRam ;
      private bool[] T001114_n262CpjTelRam ;
      private string[] T001114_A263CpjCelNum ;
      private bool[] T001114_n263CpjCelNum ;
      private string[] T001114_A264CpjWppNum ;
      private bool[] T001114_n264CpjWppNum ;
      private string[] T001114_A265CpjWebsite ;
      private bool[] T001114_n265CpjWebsite ;
      private string[] T001114_A266CpjEmail ;
      private bool[] T001114_n266CpjEmail ;
      private int[] T001114_A365CpjTipoId ;
      private long[] T001118_A159CliMatricula ;
      private string[] T001118_A160CliNomeFamiliar ;
      private short[] T001119_A267CpjUltEndSeq ;
      private bool[] T001119_n267CpjUltEndSeq ;
      private string[] T001119_A170CpjNomeFan ;
      private string[] T001119_A171CpjRazaoSoc ;
      private long[] T001119_A176CpjMatricula ;
      private long[] T001119_A187CpjCNPJ ;
      private string[] T001119_A188CpjCNPJFormat ;
      private string[] T001119_A189CpjIE ;
      private bool[] T001119_A207CpjAtivo ;
      private string[] T001119_A261CpjTelNum ;
      private bool[] T001119_n261CpjTelNum ;
      private string[] T001119_A262CpjTelRam ;
      private bool[] T001119_n262CpjTelRam ;
      private string[] T001119_A263CpjCelNum ;
      private bool[] T001119_n263CpjCelNum ;
      private string[] T001119_A264CpjWppNum ;
      private bool[] T001119_n264CpjWppNum ;
      private string[] T001119_A265CpjWebsite ;
      private bool[] T001119_n265CpjWebsite ;
      private string[] T001119_A266CpjEmail ;
      private bool[] T001119_n266CpjEmail ;
      private int[] T001119_A365CpjTipoId ;
      private string[] T001120_A366CpjTipoSigla ;
      private string[] T001120_A367CpjTipoNome ;
      private Guid[] T001121_A345NegID ;
      private Guid[] T001123_A158CliID ;
      private Guid[] T001123_A166CpjID ;
      private short[] T001123_A248CpjEndSeq ;
      private IDataStoreProvider pr_gam ;
      private short[] T00115_A267CpjUltEndSeq ;
      private string[] T00115_A170CpjNomeFan ;
      private string[] T00115_A171CpjRazaoSoc ;
      private long[] T00115_A176CpjMatricula ;
      private long[] T00115_A187CpjCNPJ ;
      private string[] T00115_A188CpjCNPJFormat ;
      private string[] T00115_A189CpjIE ;
      private bool[] T00115_A207CpjAtivo ;
      private string[] T00115_A261CpjTelNum ;
      private string[] T00115_A262CpjTelRam ;
      private string[] T00115_A263CpjCelNum ;
      private string[] T00115_A264CpjWppNum ;
      private string[] T00115_A265CpjWebsite ;
      private string[] T00115_A266CpjEmail ;
      private int[] T00115_A365CpjTipoId ;
      private bool[] T00115_n267CpjUltEndSeq ;
      private bool[] T00115_n261CpjTelNum ;
      private bool[] T00115_n262CpjTelRam ;
      private bool[] T00115_n263CpjCelNum ;
      private bool[] T00115_n264CpjWppNum ;
      private bool[] T00115_n265CpjWebsite ;
      private bool[] T00115_n266CpjEmail ;
      private IGxSession AV13WebSession ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV12TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV38AuditingObject ;
   }

   public class clientepjendereco__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class clientepjendereco__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[9])
       ,new ForEachCursor(def[10])
       ,new ForEachCursor(def[11])
       ,new ForEachCursor(def[12])
       ,new UpdateCursor(def[13])
       ,new UpdateCursor(def[14])
       ,new UpdateCursor(def[15])
       ,new ForEachCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new ForEachCursor(def[18])
       ,new ForEachCursor(def[19])
       ,new UpdateCursor(def[20])
       ,new ForEachCursor(def[21])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00115;
        prmT00115 = new Object[] {
        new ParDef("CliID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("CpjID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT00118;
        prmT00118 = new Object[] {
        new ParDef("CliID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("CpjID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("CpjEndSeq",GXType.Int16,4,0)
        };
        Object[] prmT00114;
        prmT00114 = new Object[] {
        new ParDef("CliID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT00117;
        prmT00117 = new Object[] {
        new ParDef("CpjTipoId",GXType.Int32,9,0)
        };
        Object[] prmT00119;
        prmT00119 = new Object[] {
        new ParDef("CliID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT00116;
        prmT00116 = new Object[] {
        new ParDef("CliID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("CpjID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT001110;
        prmT001110 = new Object[] {
        new ParDef("CpjTipoId",GXType.Int32,9,0)
        };
        Object[] prmT001111;
        prmT001111 = new Object[] {
        new ParDef("CliID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("CpjID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("CpjEndSeq",GXType.Int16,4,0)
        };
        Object[] prmT00113;
        prmT00113 = new Object[] {
        new ParDef("CliID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("CpjID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("CpjEndSeq",GXType.Int16,4,0)
        };
        Object[] prmT001112;
        prmT001112 = new Object[] {
        new ParDef("CliID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("CpjID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("CpjEndSeq",GXType.Int16,4,0)
        };
        Object[] prmT001113;
        prmT001113 = new Object[] {
        new ParDef("CliID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("CpjID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("CpjEndSeq",GXType.Int16,4,0)
        };
        Object[] prmT00112;
        prmT00112 = new Object[] {
        new ParDef("CliID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("CpjID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("CpjEndSeq",GXType.Int16,4,0)
        };
        Object[] prmT001114;
        prmT001114 = new Object[] {
        new ParDef("CliID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("CpjID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT001115;
        prmT001115 = new Object[] {
        new ParDef("CpjEndSeq",GXType.Int16,4,0) ,
        new ParDef("CpjEndDelDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("CpjEndDelData",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("CpjEndDelHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("CpjEndDelUsuId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("CpjEndDelUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("CpjEndNome",GXType.VarChar,80,0) ,
        new ParDef("CpjEndCep",GXType.Int32,8,0) ,
        new ParDef("CpjEndCepFormat",GXType.VarChar,9,0) ,
        new ParDef("CpjEndEndereco",GXType.VarChar,100,0) ,
        new ParDef("CpjEndNumero",GXType.VarChar,50,0) ,
        new ParDef("CpjEndComplem",GXType.VarChar,50,0){Nullable=true} ,
        new ParDef("CpjEndBairro",GXType.VarChar,100,0) ,
        new ParDef("CpjEndMunID",GXType.Int32,7,0) ,
        new ParDef("CpjEndMunNome",GXType.VarChar,80,0) ,
        new ParDef("CpjEndUFId",GXType.Int16,2,0) ,
        new ParDef("CpjEndUFSigla",GXType.VarChar,2,0) ,
        new ParDef("CpjEndUFNome",GXType.VarChar,80,0) ,
        new ParDef("CpjEndDel",GXType.Boolean,4,0) ,
        new ParDef("CliID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("CpjID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT001116;
        prmT001116 = new Object[] {
        new ParDef("CpjEndDelDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("CpjEndDelData",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("CpjEndDelHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("CpjEndDelUsuId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("CpjEndDelUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("CpjEndNome",GXType.VarChar,80,0) ,
        new ParDef("CpjEndCep",GXType.Int32,8,0) ,
        new ParDef("CpjEndCepFormat",GXType.VarChar,9,0) ,
        new ParDef("CpjEndEndereco",GXType.VarChar,100,0) ,
        new ParDef("CpjEndNumero",GXType.VarChar,50,0) ,
        new ParDef("CpjEndComplem",GXType.VarChar,50,0){Nullable=true} ,
        new ParDef("CpjEndBairro",GXType.VarChar,100,0) ,
        new ParDef("CpjEndMunID",GXType.Int32,7,0) ,
        new ParDef("CpjEndMunNome",GXType.VarChar,80,0) ,
        new ParDef("CpjEndUFId",GXType.Int16,2,0) ,
        new ParDef("CpjEndUFSigla",GXType.VarChar,2,0) ,
        new ParDef("CpjEndUFNome",GXType.VarChar,80,0) ,
        new ParDef("CpjEndDel",GXType.Boolean,4,0) ,
        new ParDef("CliID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("CpjID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("CpjEndSeq",GXType.Int16,4,0)
        };
        Object[] prmT001117;
        prmT001117 = new Object[] {
        new ParDef("CliID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("CpjID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("CpjEndSeq",GXType.Int16,4,0)
        };
        Object[] prmT001121;
        prmT001121 = new Object[] {
        new ParDef("CliID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("CpjID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("CpjEndSeq",GXType.Int16,4,0)
        };
        Object[] prmT001122;
        prmT001122 = new Object[] {
        new ParDef("CpjUltEndSeq",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("CliID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("CpjID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT001123;
        prmT001123 = new Object[] {
        };
        Object[] prmT001118;
        prmT001118 = new Object[] {
        new ParDef("CliID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT001119;
        prmT001119 = new Object[] {
        new ParDef("CliID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("CpjID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT001120;
        prmT001120 = new Object[] {
        new ParDef("CpjTipoId",GXType.Int32,9,0)
        };
        def= new CursorDef[] {
            new CursorDef("T00112", "SELECT CpjEndSeq, CpjEndDelDataHora, CpjEndDelData, CpjEndDelHora, CpjEndDelUsuId, CpjEndDelUsuNome, CpjEndNome, CpjEndCep, CpjEndCepFormat, CpjEndEndereco, CpjEndNumero, CpjEndComplem, CpjEndBairro, CpjEndMunID, CpjEndMunNome, CpjEndUFId, CpjEndUFSigla, CpjEndUFNome, CpjEndDel, CliID, CpjID FROM tb_clientepj_endereco WHERE CliID = :CliID AND CpjID = :CpjID AND CpjEndSeq = :CpjEndSeq  FOR UPDATE OF tb_clientepj_endereco NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT00112,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00113", "SELECT CpjEndSeq, CpjEndDelDataHora, CpjEndDelData, CpjEndDelHora, CpjEndDelUsuId, CpjEndDelUsuNome, CpjEndNome, CpjEndCep, CpjEndCepFormat, CpjEndEndereco, CpjEndNumero, CpjEndComplem, CpjEndBairro, CpjEndMunID, CpjEndMunNome, CpjEndUFId, CpjEndUFSigla, CpjEndUFNome, CpjEndDel, CliID, CpjID FROM tb_clientepj_endereco WHERE CliID = :CliID AND CpjID = :CpjID AND CpjEndSeq = :CpjEndSeq ",true, GxErrorMask.GX_NOMASK, false, this,prmT00113,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00114", "SELECT CliMatricula, CliNomeFamiliar FROM tb_cliente WHERE CliID = :CliID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00114,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00115", "SELECT CpjUltEndSeq, CpjNomeFan, CpjRazaoSoc, CpjMatricula, CpjCNPJ, CpjCNPJFormat, CpjIE, CpjAtivo, CpjTelNum, CpjTelRam, CpjCelNum, CpjWppNum, CpjWebsite, CpjEmail, CpjTipoId FROM tb_clientepj WHERE CliID = :CliID AND CpjID = :CpjID  FOR UPDATE OF tb_clientepj NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT00115,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00116", "SELECT CpjUltEndSeq, CpjNomeFan, CpjRazaoSoc, CpjMatricula, CpjCNPJ, CpjCNPJFormat, CpjIE, CpjAtivo, CpjTelNum, CpjTelRam, CpjCelNum, CpjWppNum, CpjWebsite, CpjEmail, CpjTipoId FROM tb_clientepj WHERE CliID = :CliID AND CpjID = :CpjID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00116,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00117", "SELECT PjtSigla AS CpjTipoSigla, PjtNome AS CpjTipoNome FROM tb_clientepjtipo WHERE PjtID = :CpjTipoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00117,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00118", "SELECT TM1.CpjEndSeq, T3.CpjUltEndSeq, TM1.CpjEndDelDataHora, TM1.CpjEndDelData, TM1.CpjEndDelHora, TM1.CpjEndDelUsuId, TM1.CpjEndDelUsuNome, T2.CliMatricula, T2.CliNomeFamiliar, T4.PjtSigla AS CpjTipoSigla, T4.PjtNome AS CpjTipoNome, T3.CpjNomeFan, T3.CpjRazaoSoc, T3.CpjMatricula, T3.CpjCNPJ, T3.CpjCNPJFormat, T3.CpjIE, T3.CpjAtivo, T3.CpjTelNum, T3.CpjTelRam, T3.CpjCelNum, T3.CpjWppNum, T3.CpjWebsite, T3.CpjEmail, TM1.CpjEndNome, TM1.CpjEndCep, TM1.CpjEndCepFormat, TM1.CpjEndEndereco, TM1.CpjEndNumero, TM1.CpjEndComplem, TM1.CpjEndBairro, TM1.CpjEndMunID, TM1.CpjEndMunNome, TM1.CpjEndUFId, TM1.CpjEndUFSigla, TM1.CpjEndUFNome, TM1.CpjEndDel, TM1.CliID, TM1.CpjID, T3.CpjTipoId AS CpjTipoId FROM (((tb_clientepj_endereco TM1 INNER JOIN tb_cliente T2 ON T2.CliID = TM1.CliID) INNER JOIN tb_clientepj T3 ON T3.CliID = TM1.CliID AND T3.CpjID = TM1.CpjID) INNER JOIN tb_clientepjtipo T4 ON T4.PjtID = T3.CpjTipoId) WHERE TM1.CliID = :CliID and TM1.CpjID = :CpjID and TM1.CpjEndSeq = :CpjEndSeq ORDER BY TM1.CliID, TM1.CpjID, TM1.CpjEndSeq ",true, GxErrorMask.GX_NOMASK, false, this,prmT00118,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00119", "SELECT CliMatricula, CliNomeFamiliar FROM tb_cliente WHERE CliID = :CliID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00119,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001110", "SELECT PjtSigla AS CpjTipoSigla, PjtNome AS CpjTipoNome FROM tb_clientepjtipo WHERE PjtID = :CpjTipoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001110,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001111", "SELECT CliID, CpjID, CpjEndSeq FROM tb_clientepj_endereco WHERE CliID = :CliID AND CpjID = :CpjID AND CpjEndSeq = :CpjEndSeq ",true, GxErrorMask.GX_NOMASK, false, this,prmT001111,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001112", "SELECT CliID, CpjID, CpjEndSeq FROM tb_clientepj_endereco WHERE ( CliID > :CliID or CliID = :CliID and CpjID > :CpjID or CpjID = :CpjID and CliID = :CliID and CpjEndSeq > :CpjEndSeq) ORDER BY CliID, CpjID, CpjEndSeq ",true, GxErrorMask.GX_NOMASK, false, this,prmT001112,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001113", "SELECT CliID, CpjID, CpjEndSeq FROM tb_clientepj_endereco WHERE ( CliID < :CliID or CliID = :CliID and CpjID < :CpjID or CpjID = :CpjID and CliID = :CliID and CpjEndSeq < :CpjEndSeq) ORDER BY CliID DESC, CpjID DESC, CpjEndSeq DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT001113,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001114", "SELECT CpjUltEndSeq, CpjNomeFan, CpjRazaoSoc, CpjMatricula, CpjCNPJ, CpjCNPJFormat, CpjIE, CpjAtivo, CpjTelNum, CpjTelRam, CpjCelNum, CpjWppNum, CpjWebsite, CpjEmail, CpjTipoId FROM tb_clientepj WHERE CliID = :CliID AND CpjID = :CpjID  FOR UPDATE OF tb_clientepj NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT001114,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001115", "SAVEPOINT gxupdate;INSERT INTO tb_clientepj_endereco(CpjEndSeq, CpjEndDelDataHora, CpjEndDelData, CpjEndDelHora, CpjEndDelUsuId, CpjEndDelUsuNome, CpjEndNome, CpjEndCep, CpjEndCepFormat, CpjEndEndereco, CpjEndNumero, CpjEndComplem, CpjEndBairro, CpjEndMunID, CpjEndMunNome, CpjEndUFId, CpjEndUFSigla, CpjEndUFNome, CpjEndDel, CliID, CpjID) VALUES(:CpjEndSeq, :CpjEndDelDataHora, :CpjEndDelData, :CpjEndDelHora, :CpjEndDelUsuId, :CpjEndDelUsuNome, :CpjEndNome, :CpjEndCep, :CpjEndCepFormat, :CpjEndEndereco, :CpjEndNumero, :CpjEndComplem, :CpjEndBairro, :CpjEndMunID, :CpjEndMunNome, :CpjEndUFId, :CpjEndUFSigla, :CpjEndUFNome, :CpjEndDel, :CliID, :CpjID);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT001115)
           ,new CursorDef("T001116", "SAVEPOINT gxupdate;UPDATE tb_clientepj_endereco SET CpjEndDelDataHora=:CpjEndDelDataHora, CpjEndDelData=:CpjEndDelData, CpjEndDelHora=:CpjEndDelHora, CpjEndDelUsuId=:CpjEndDelUsuId, CpjEndDelUsuNome=:CpjEndDelUsuNome, CpjEndNome=:CpjEndNome, CpjEndCep=:CpjEndCep, CpjEndCepFormat=:CpjEndCepFormat, CpjEndEndereco=:CpjEndEndereco, CpjEndNumero=:CpjEndNumero, CpjEndComplem=:CpjEndComplem, CpjEndBairro=:CpjEndBairro, CpjEndMunID=:CpjEndMunID, CpjEndMunNome=:CpjEndMunNome, CpjEndUFId=:CpjEndUFId, CpjEndUFSigla=:CpjEndUFSigla, CpjEndUFNome=:CpjEndUFNome, CpjEndDel=:CpjEndDel  WHERE CliID = :CliID AND CpjID = :CpjID AND CpjEndSeq = :CpjEndSeq;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001116)
           ,new CursorDef("T001117", "SAVEPOINT gxupdate;DELETE FROM tb_clientepj_endereco  WHERE CliID = :CliID AND CpjID = :CpjID AND CpjEndSeq = :CpjEndSeq;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001117)
           ,new CursorDef("T001118", "SELECT CliMatricula, CliNomeFamiliar FROM tb_cliente WHERE CliID = :CliID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001118,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001119", "SELECT CpjUltEndSeq, CpjNomeFan, CpjRazaoSoc, CpjMatricula, CpjCNPJ, CpjCNPJFormat, CpjIE, CpjAtivo, CpjTelNum, CpjTelRam, CpjCelNum, CpjWppNum, CpjWebsite, CpjEmail, CpjTipoId FROM tb_clientepj WHERE CliID = :CliID AND CpjID = :CpjID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001119,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001120", "SELECT PjtSigla AS CpjTipoSigla, PjtNome AS CpjTipoNome FROM tb_clientepjtipo WHERE PjtID = :CpjTipoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001120,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001121", "SELECT NegID FROM tb_negociopj WHERE NegCliID = :CliID AND NegCpjID = :CpjID AND NegCpjEndSeq = :CpjEndSeq ",true, GxErrorMask.GX_NOMASK, false, this,prmT001121,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001122", "SAVEPOINT gxupdate;UPDATE tb_clientepj SET CpjUltEndSeq=:CpjUltEndSeq  WHERE CliID = :CliID AND CpjID = :CpjID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001122)
           ,new CursorDef("T001123", "SELECT CliID, CpjID, CpjEndSeq FROM tb_clientepj_endereco ORDER BY CliID, CpjID, CpjEndSeq ",true, GxErrorMask.GX_NOMASK, false, this,prmT001123,100, GxCacheFrequency.OFF ,true,false )
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
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2, true);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
              ((bool[]) buf[4])[0] = rslt.wasNull(3);
              ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(4);
              ((bool[]) buf[6])[0] = rslt.wasNull(4);
              ((string[]) buf[7])[0] = rslt.getString(5, 40);
              ((bool[]) buf[8])[0] = rslt.wasNull(5);
              ((string[]) buf[9])[0] = rslt.getVarchar(6);
              ((bool[]) buf[10])[0] = rslt.wasNull(6);
              ((string[]) buf[11])[0] = rslt.getVarchar(7);
              ((int[]) buf[12])[0] = rslt.getInt(8);
              ((string[]) buf[13])[0] = rslt.getVarchar(9);
              ((string[]) buf[14])[0] = rslt.getVarchar(10);
              ((string[]) buf[15])[0] = rslt.getVarchar(11);
              ((string[]) buf[16])[0] = rslt.getVarchar(12);
              ((bool[]) buf[17])[0] = rslt.wasNull(12);
              ((string[]) buf[18])[0] = rslt.getVarchar(13);
              ((int[]) buf[19])[0] = rslt.getInt(14);
              ((string[]) buf[20])[0] = rslt.getVarchar(15);
              ((short[]) buf[21])[0] = rslt.getShort(16);
              ((string[]) buf[22])[0] = rslt.getVarchar(17);
              ((string[]) buf[23])[0] = rslt.getVarchar(18);
              ((bool[]) buf[24])[0] = rslt.getBool(19);
              ((Guid[]) buf[25])[0] = rslt.getGuid(20);
              ((Guid[]) buf[26])[0] = rslt.getGuid(21);
              return;
           case 1 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2, true);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
              ((bool[]) buf[4])[0] = rslt.wasNull(3);
              ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(4);
              ((bool[]) buf[6])[0] = rslt.wasNull(4);
              ((string[]) buf[7])[0] = rslt.getString(5, 40);
              ((bool[]) buf[8])[0] = rslt.wasNull(5);
              ((string[]) buf[9])[0] = rslt.getVarchar(6);
              ((bool[]) buf[10])[0] = rslt.wasNull(6);
              ((string[]) buf[11])[0] = rslt.getVarchar(7);
              ((int[]) buf[12])[0] = rslt.getInt(8);
              ((string[]) buf[13])[0] = rslt.getVarchar(9);
              ((string[]) buf[14])[0] = rslt.getVarchar(10);
              ((string[]) buf[15])[0] = rslt.getVarchar(11);
              ((string[]) buf[16])[0] = rslt.getVarchar(12);
              ((bool[]) buf[17])[0] = rslt.wasNull(12);
              ((string[]) buf[18])[0] = rslt.getVarchar(13);
              ((int[]) buf[19])[0] = rslt.getInt(14);
              ((string[]) buf[20])[0] = rslt.getVarchar(15);
              ((short[]) buf[21])[0] = rslt.getShort(16);
              ((string[]) buf[22])[0] = rslt.getVarchar(17);
              ((string[]) buf[23])[0] = rslt.getVarchar(18);
              ((bool[]) buf[24])[0] = rslt.getBool(19);
              ((Guid[]) buf[25])[0] = rslt.getGuid(20);
              ((Guid[]) buf[26])[0] = rslt.getGuid(21);
              return;
           case 2 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 3 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              ((string[]) buf[2])[0] = rslt.getVarchar(2);
              ((string[]) buf[3])[0] = rslt.getVarchar(3);
              ((long[]) buf[4])[0] = rslt.getLong(4);
              ((long[]) buf[5])[0] = rslt.getLong(5);
              ((string[]) buf[6])[0] = rslt.getVarchar(6);
              ((string[]) buf[7])[0] = rslt.getVarchar(7);
              ((bool[]) buf[8])[0] = rslt.getBool(8);
              ((string[]) buf[9])[0] = rslt.getString(9, 20);
              ((bool[]) buf[10])[0] = rslt.wasNull(9);
              ((string[]) buf[11])[0] = rslt.getVarchar(10);
              ((bool[]) buf[12])[0] = rslt.wasNull(10);
              ((string[]) buf[13])[0] = rslt.getString(11, 20);
              ((bool[]) buf[14])[0] = rslt.wasNull(11);
              ((string[]) buf[15])[0] = rslt.getString(12, 20);
              ((bool[]) buf[16])[0] = rslt.wasNull(12);
              ((string[]) buf[17])[0] = rslt.getVarchar(13);
              ((bool[]) buf[18])[0] = rslt.wasNull(13);
              ((string[]) buf[19])[0] = rslt.getVarchar(14);
              ((bool[]) buf[20])[0] = rslt.wasNull(14);
              ((int[]) buf[21])[0] = rslt.getInt(15);
              return;
           case 4 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              ((string[]) buf[2])[0] = rslt.getVarchar(2);
              ((string[]) buf[3])[0] = rslt.getVarchar(3);
              ((long[]) buf[4])[0] = rslt.getLong(4);
              ((long[]) buf[5])[0] = rslt.getLong(5);
              ((string[]) buf[6])[0] = rslt.getVarchar(6);
              ((string[]) buf[7])[0] = rslt.getVarchar(7);
              ((bool[]) buf[8])[0] = rslt.getBool(8);
              ((string[]) buf[9])[0] = rslt.getString(9, 20);
              ((bool[]) buf[10])[0] = rslt.wasNull(9);
              ((string[]) buf[11])[0] = rslt.getVarchar(10);
              ((bool[]) buf[12])[0] = rslt.wasNull(10);
              ((string[]) buf[13])[0] = rslt.getString(11, 20);
              ((bool[]) buf[14])[0] = rslt.wasNull(11);
              ((string[]) buf[15])[0] = rslt.getString(12, 20);
              ((bool[]) buf[16])[0] = rslt.wasNull(12);
              ((string[]) buf[17])[0] = rslt.getVarchar(13);
              ((bool[]) buf[18])[0] = rslt.wasNull(13);
              ((string[]) buf[19])[0] = rslt.getVarchar(14);
              ((bool[]) buf[20])[0] = rslt.wasNull(14);
              ((int[]) buf[21])[0] = rslt.getInt(15);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 6 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3, true);
              ((bool[]) buf[4])[0] = rslt.wasNull(3);
              ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(4);
              ((bool[]) buf[6])[0] = rslt.wasNull(4);
              ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(5);
              ((bool[]) buf[8])[0] = rslt.wasNull(5);
              ((string[]) buf[9])[0] = rslt.getString(6, 40);
              ((bool[]) buf[10])[0] = rslt.wasNull(6);
              ((string[]) buf[11])[0] = rslt.getVarchar(7);
              ((bool[]) buf[12])[0] = rslt.wasNull(7);
              ((long[]) buf[13])[0] = rslt.getLong(8);
              ((string[]) buf[14])[0] = rslt.getVarchar(9);
              ((string[]) buf[15])[0] = rslt.getVarchar(10);
              ((string[]) buf[16])[0] = rslt.getVarchar(11);
              ((string[]) buf[17])[0] = rslt.getVarchar(12);
              ((string[]) buf[18])[0] = rslt.getVarchar(13);
              ((long[]) buf[19])[0] = rslt.getLong(14);
              ((long[]) buf[20])[0] = rslt.getLong(15);
              ((string[]) buf[21])[0] = rslt.getVarchar(16);
              ((string[]) buf[22])[0] = rslt.getVarchar(17);
              ((bool[]) buf[23])[0] = rslt.getBool(18);
              ((string[]) buf[24])[0] = rslt.getString(19, 20);
              ((bool[]) buf[25])[0] = rslt.wasNull(19);
              ((string[]) buf[26])[0] = rslt.getVarchar(20);
              ((bool[]) buf[27])[0] = rslt.wasNull(20);
              ((string[]) buf[28])[0] = rslt.getString(21, 20);
              ((bool[]) buf[29])[0] = rslt.wasNull(21);
              ((string[]) buf[30])[0] = rslt.getString(22, 20);
              ((bool[]) buf[31])[0] = rslt.wasNull(22);
              ((string[]) buf[32])[0] = rslt.getVarchar(23);
              ((bool[]) buf[33])[0] = rslt.wasNull(23);
              ((string[]) buf[34])[0] = rslt.getVarchar(24);
              ((bool[]) buf[35])[0] = rslt.wasNull(24);
              ((string[]) buf[36])[0] = rslt.getVarchar(25);
              ((int[]) buf[37])[0] = rslt.getInt(26);
              ((string[]) buf[38])[0] = rslt.getVarchar(27);
              ((string[]) buf[39])[0] = rslt.getVarchar(28);
              ((string[]) buf[40])[0] = rslt.getVarchar(29);
              ((string[]) buf[41])[0] = rslt.getVarchar(30);
              ((bool[]) buf[42])[0] = rslt.wasNull(30);
              ((string[]) buf[43])[0] = rslt.getVarchar(31);
              ((int[]) buf[44])[0] = rslt.getInt(32);
              ((string[]) buf[45])[0] = rslt.getVarchar(33);
              ((short[]) buf[46])[0] = rslt.getShort(34);
              ((string[]) buf[47])[0] = rslt.getVarchar(35);
              ((string[]) buf[48])[0] = rslt.getVarchar(36);
              ((bool[]) buf[49])[0] = rslt.getBool(37);
              ((Guid[]) buf[50])[0] = rslt.getGuid(38);
              ((Guid[]) buf[51])[0] = rslt.getGuid(39);
              ((int[]) buf[52])[0] = rslt.getInt(40);
              return;
           case 7 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 9 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              return;
           case 10 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              return;
           case 11 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              return;
           case 12 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              ((string[]) buf[2])[0] = rslt.getVarchar(2);
              ((string[]) buf[3])[0] = rslt.getVarchar(3);
              ((long[]) buf[4])[0] = rslt.getLong(4);
              ((long[]) buf[5])[0] = rslt.getLong(5);
              ((string[]) buf[6])[0] = rslt.getVarchar(6);
              ((string[]) buf[7])[0] = rslt.getVarchar(7);
              ((bool[]) buf[8])[0] = rslt.getBool(8);
              ((string[]) buf[9])[0] = rslt.getString(9, 20);
              ((bool[]) buf[10])[0] = rslt.wasNull(9);
              ((string[]) buf[11])[0] = rslt.getVarchar(10);
              ((bool[]) buf[12])[0] = rslt.wasNull(10);
              ((string[]) buf[13])[0] = rslt.getString(11, 20);
              ((bool[]) buf[14])[0] = rslt.wasNull(11);
              ((string[]) buf[15])[0] = rslt.getString(12, 20);
              ((bool[]) buf[16])[0] = rslt.wasNull(12);
              ((string[]) buf[17])[0] = rslt.getVarchar(13);
              ((bool[]) buf[18])[0] = rslt.wasNull(13);
              ((string[]) buf[19])[0] = rslt.getVarchar(14);
              ((bool[]) buf[20])[0] = rslt.wasNull(14);
              ((int[]) buf[21])[0] = rslt.getInt(15);
              return;
           case 16 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 17 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              ((string[]) buf[2])[0] = rslt.getVarchar(2);
              ((string[]) buf[3])[0] = rslt.getVarchar(3);
              ((long[]) buf[4])[0] = rslt.getLong(4);
              ((long[]) buf[5])[0] = rslt.getLong(5);
              ((string[]) buf[6])[0] = rslt.getVarchar(6);
              ((string[]) buf[7])[0] = rslt.getVarchar(7);
              ((bool[]) buf[8])[0] = rslt.getBool(8);
              ((string[]) buf[9])[0] = rslt.getString(9, 20);
              ((bool[]) buf[10])[0] = rslt.wasNull(9);
              ((string[]) buf[11])[0] = rslt.getVarchar(10);
              ((bool[]) buf[12])[0] = rslt.wasNull(10);
              ((string[]) buf[13])[0] = rslt.getString(11, 20);
              ((bool[]) buf[14])[0] = rslt.wasNull(11);
              ((string[]) buf[15])[0] = rslt.getString(12, 20);
              ((bool[]) buf[16])[0] = rslt.wasNull(12);
              ((string[]) buf[17])[0] = rslt.getVarchar(13);
              ((bool[]) buf[18])[0] = rslt.wasNull(13);
              ((string[]) buf[19])[0] = rslt.getVarchar(14);
              ((bool[]) buf[20])[0] = rslt.wasNull(14);
              ((int[]) buf[21])[0] = rslt.getInt(15);
              return;
           case 18 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 19 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 21 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              return;
     }
  }

}

}
