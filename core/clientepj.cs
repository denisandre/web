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
   public class clientepj : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vCPJTIPOIDFILTRO") == 0 )
         {
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GXDLVvCPJTIPOIDFILTRO0P25( ) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel21"+"_"+"CPJCNPJ") == 0 )
         {
            A188CpjCNPJFormat = GetPar( "CpjCNPJFormat");
            AssignAttri("", false, "A188CpjCNPJFormat", A188CpjCNPJFormat);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX21ASACPJCNPJ0P25( A188CpjCNPJFormat) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel24"+"_"+"CPJMATRICULA") == 0 )
         {
            Gx_mode = GetPar( "Mode");
            AssignAttri("", false, "Gx_mode", Gx_mode);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX24ASACPJMATRICULA0P25( Gx_mode) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_56") == 0 )
         {
            A158CliID = StringUtil.StrToGuid( GetPar( "CliID"));
            AssignAttri("", false, "A158CliID", A158CliID.ToString());
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_56( A158CliID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_58") == 0 )
         {
            A158CliID = StringUtil.StrToGuid( GetPar( "CliID"));
            AssignAttri("", false, "A158CliID", A158CliID.ToString());
            A181CpjHolID = StringUtil.StrToGuid( GetPar( "CpjHolID"));
            n181CpjHolID = false;
            AssignAttri("", false, "A181CpjHolID", A181CpjHolID.ToString());
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_58( A158CliID, A181CpjHolID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_59") == 0 )
         {
            A158CliID = StringUtil.StrToGuid( GetPar( "CliID"));
            AssignAttri("", false, "A158CliID", A158CliID.ToString());
            A169CpjPaiID = StringUtil.StrToGuid( GetPar( "CpjPaiID"));
            n169CpjPaiID = false;
            AssignAttri("", false, "A169CpjPaiID", A169CpjPaiID.ToString());
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_59( A158CliID, A169CpjPaiID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_60") == 0 )
         {
            A184CpjPaiTipoID = (int)(Math.Round(NumberUtil.Val( GetPar( "CpjPaiTipoID"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A184CpjPaiTipoID", StringUtil.LTrimStr( (decimal)(A184CpjPaiTipoID), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_60( A184CpjPaiTipoID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_57") == 0 )
         {
            A365CpjTipoId = (int)(Math.Round(NumberUtil.Val( GetPar( "CpjTipoId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A365CpjTipoId", StringUtil.LTrimStr( (decimal)(A365CpjTipoId), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_57( A365CpjTipoId) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "core.clientepj.aspx")), "core.clientepj.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "core.clientepj.aspx")))) ;
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
            Form.Meta.addItem("description", "Cliente PJ", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtCpjTipoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public clientepj( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public clientepj( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           Guid aP1_CliID ,
                           Guid aP2_CpjID )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7CliID = aP1_CliID;
         this.AV8CpjID = aP2_CpjID;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         dynavCpjtipoidfiltro = new GXCombobox();
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
            return "clientepj_Execute" ;
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
         if ( dynavCpjtipoidfiltro.ItemCount > 0 )
         {
            AV36CpjTipoIdFiltro = (int)(Math.Round(NumberUtil.Val( dynavCpjtipoidfiltro.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV36CpjTipoIdFiltro), 9, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV36CpjTipoIdFiltro", StringUtil.LTrimStr( (decimal)(AV36CpjTipoIdFiltro), 9, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavCpjtipoidfiltro.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV36CpjTipoIdFiltro), 11, 0));
            AssignProp("", false, dynavCpjtipoidfiltro_Internalname, "Values", dynavCpjtipoidfiltro.ToJavascriptSource(), true);
         }
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCliNomeFamiliar_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCliNomeFamiliar_Internalname, "Nome", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCliNomeFamiliar_Internalname, A160CliNomeFamiliar, StringUtil.RTrim( context.localUtil.Format( A160CliNomeFamiliar, "@!")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliNomeFamiliar_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCliNomeFamiliar_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "core\\Nome", "start", true, "", "HLP_core\\ClientePJ.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCliMatricula_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCliMatricula_Internalname, "Matrícula", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCliMatricula_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A159CliMatricula), 15, 0, ",", "")), StringUtil.LTrim( ((edtCliMatricula_Enabled!=0) ? context.localUtil.Format( (decimal)(A159CliMatricula), "ZZZ,ZZZ,ZZZ,ZZ9") : context.localUtil.Format( (decimal)(A159CliMatricula), "ZZZ,ZZZ,ZZZ,ZZ9"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliMatricula_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCliMatricula_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 0, -1, 0, true, "core\\Matricula", "end", false, "", "HLP_core\\ClientePJ.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedcpjtipoid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockcpjtipoid_Internalname, "Tipo", "", "", lblTextblockcpjtipoid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_core\\ClientePJ.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_cpjtipoid.SetProperty("Caption", Combo_cpjtipoid_Caption);
         ucCombo_cpjtipoid.SetProperty("Cls", Combo_cpjtipoid_Cls);
         ucCombo_cpjtipoid.SetProperty("EmptyItemText", Combo_cpjtipoid_Emptyitemtext);
         ucCombo_cpjtipoid.SetProperty("DropDownOptionsTitleSettingsIcons", AV17DDO_TitleSettingsIcons);
         ucCombo_cpjtipoid.SetProperty("DropDownOptionsData", AV24CpjTipoId_Data);
         ucCombo_cpjtipoid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_cpjtipoid_Internalname, "COMBO_CPJTIPOIDContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCpjTipoId_Internalname, "Tipo", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCpjTipoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A365CpjTipoId), 11, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A365CpjTipoId), "ZZZ,ZZZ,ZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,42);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCpjTipoId_Jsonclick, 0, "Attribute", "", "", "", "", edtCpjTipoId_Visible, edtCpjTipoId_Enabled, 1, "text", "", 11, "chr", 1, "row", 11, 0, 0, 0, 0, -1, 0, true, "core\\ID", "end", false, "", "HLP_core\\ClientePJ.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divCombo_cpjpaiid_cell_Internalname, 1, 0, "px", 0, "px", divCombo_cpjpaiid_cell_Class, "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedcpjpaiid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockcpjpaiid_Internalname, lblTextblockcpjpaiid_Caption, "", "", lblTextblockcpjpaiid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_core\\ClientePJ.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_cpjpaiid.SetProperty("Caption", Combo_cpjpaiid_Caption);
         ucCombo_cpjpaiid.SetProperty("Cls", Combo_cpjpaiid_Cls);
         ucCombo_cpjpaiid.SetProperty("DataListProc", Combo_cpjpaiid_Datalistproc);
         ucCombo_cpjpaiid.SetProperty("EmptyItemText", Combo_cpjpaiid_Emptyitemtext);
         ucCombo_cpjpaiid.SetProperty("DropDownOptionsTitleSettingsIcons", AV17DDO_TitleSettingsIcons);
         ucCombo_cpjpaiid.SetProperty("DropDownOptionsData", AV29CpjPaiID_Data);
         ucCombo_cpjpaiid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_cpjpaiid_Internalname, "COMBO_CPJPAIIDContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCpjPaiID_Internalname, "Cliente Pai", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCpjPaiID_Internalname, A169CpjPaiID.ToString(), A169CpjPaiID.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,52);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCpjPaiID_Jsonclick, 0, "Attribute", "", "", "", "", edtCpjPaiID_Visible, edtCpjPaiID_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_core\\ClientePJ.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCpjNomeFan_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCpjNomeFan_Internalname, "Nome Fantasia", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCpjNomeFan_Internalname, A170CpjNomeFan, StringUtil.RTrim( context.localUtil.Format( A170CpjNomeFan, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,57);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCpjNomeFan_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCpjNomeFan_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "core\\Nome", "start", true, "", "HLP_core\\ClientePJ.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCpjRazaoSoc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCpjRazaoSoc_Internalname, "Razão Social", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCpjRazaoSoc_Internalname, A171CpjRazaoSoc, StringUtil.RTrim( context.localUtil.Format( A171CpjRazaoSoc, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,61);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCpjRazaoSoc_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCpjRazaoSoc_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "core\\Nome", "start", true, "", "HLP_core\\ClientePJ.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCpjMatricula_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCpjMatricula_Internalname, "Matrícula", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCpjMatricula_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A176CpjMatricula), 15, 0, ",", "")), StringUtil.LTrim( ((edtCpjMatricula_Enabled!=0) ? context.localUtil.Format( (decimal)(A176CpjMatricula), "ZZZ,ZZZ,ZZZ,ZZ9") : context.localUtil.Format( (decimal)(A176CpjMatricula), "ZZZ,ZZZ,ZZZ,ZZ9"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCpjMatricula_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCpjMatricula_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 0, -1, 0, true, "core\\Matricula", "end", false, "", "HLP_core\\ClientePJ.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCpjCNPJFormat_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCpjCNPJFormat_Internalname, "CNPJ", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCpjCNPJFormat_Internalname, A188CpjCNPJFormat, StringUtil.RTrim( context.localUtil.Format( A188CpjCNPJFormat, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCpjCNPJFormat_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCpjCNPJFormat_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, -1, true, "core\\CNPJFormatado", "start", true, "", "HLP_core\\ClientePJ.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCpjIE_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCpjIE_Internalname, "Inscrição Estadual", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCpjIE_Internalname, A189CpjIE, StringUtil.RTrim( context.localUtil.Format( A189CpjIE, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCpjIE_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCpjIE_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "core\\InscricaoEstadual", "start", true, "", "HLP_core\\ClientePJ.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCpjCapitalSoc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCpjCapitalSoc_Internalname, "Capital Social", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCpjCapitalSoc_Internalname, StringUtil.LTrim( StringUtil.NToC( A190CpjCapitalSoc, 23, 2, ",", "")), StringUtil.LTrim( ((edtCpjCapitalSoc_Enabled!=0) ? context.localUtil.Format( A190CpjCapitalSoc, "R$ Z,ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A190CpjCapitalSoc, "R$ Z,ZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,78);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCpjCapitalSoc_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCpjCapitalSoc_Enabled, 0, "text", "", 23, "chr", 1, "row", 23, 0, 0, 0, 0, -1, 0, true, "core\\Monetario", "end", false, "", "HLP_core\\ClientePJ.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCpjTelNum_Internalname, StringUtil.RTrim( A261CpjTelNum), StringUtil.RTrim( context.localUtil.Format( A261CpjTelNum, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,83);\"", "'"+""+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtCpjTelNum_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCpjTelNum_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Phone", "start", true, "", "HLP_core\\ClientePJ.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 87,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCpjTelRam_Internalname, A262CpjTelRam, StringUtil.RTrim( context.localUtil.Format( A262CpjTelRam, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,87);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCpjTelRam_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCpjTelRam_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\ClientePJ.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCpjCelNum_Internalname, StringUtil.RTrim( A263CpjCelNum), StringUtil.RTrim( context.localUtil.Format( A263CpjCelNum, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,91);\"", "'"+""+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtCpjCelNum_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCpjCelNum_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Phone", "start", true, "", "HLP_core\\ClientePJ.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 95,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCpjWppNum_Internalname, StringUtil.RTrim( A264CpjWppNum), StringUtil.RTrim( context.localUtil.Format( A264CpjWppNum, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,95);\"", "'"+""+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtCpjWppNum_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCpjWppNum_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Phone", "start", true, "", "HLP_core\\ClientePJ.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 100,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCpjWebsite_Internalname, A265CpjWebsite, StringUtil.RTrim( context.localUtil.Format( A265CpjWebsite, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,100);\"", "'"+""+"'"+",false,"+"'"+""+"'", A265CpjWebsite, "_blank", "", "", edtCpjWebsite_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCpjWebsite_Enabled, 0, "url", "", 80, "chr", 1, "row", 1000, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Url", "start", true, "", "HLP_core\\ClientePJ.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCpjEmail_Internalname, A266CpjEmail, StringUtil.RTrim( context.localUtil.Format( A266CpjEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,104);\"", "'"+""+"'"+",false,"+"'"+""+"'", "mailto:"+A266CpjEmail, "", "", "", edtCpjEmail_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCpjEmail_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "start", true, "", "HLP_core\\ClientePJ.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 109,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\ClientePJ.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 111,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\ClientePJ.htm");
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
         GxWebStd.gx_div_start( context, divSectionattribute_cpjtipoid_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtavCombocpjtipoid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25ComboCpjTipoId), 11, 0, ",", "")), StringUtil.LTrim( ((edtavCombocpjtipoid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV25ComboCpjTipoId), "ZZZ,ZZZ,ZZ9") : context.localUtil.Format( (decimal)(AV25ComboCpjTipoId), "ZZZ,ZZZ,ZZ9"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombocpjtipoid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombocpjtipoid_Visible, edtavCombocpjtipoid_Enabled, 0, "text", "", 11, "chr", 1, "row", 11, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_core\\ClientePJ.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_cpjpaiid_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtavCombocpjpaiid_Internalname, AV30ComboCpjPaiID.ToString(), AV30ComboCpjPaiID.ToString(), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombocpjpaiid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombocpjpaiid_Visible, edtavCombocpjpaiid_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_core\\ClientePJ.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 119,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCpjID_Internalname, A166CpjID.ToString(), A166CpjID.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,119);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCpjID_Jsonclick, 0, "Attribute", "", "", "", "", edtCpjID_Visible, edtCpjID_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_core\\ClientePJ.htm");
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, dynavCpjtipoidfiltro, dynavCpjtipoidfiltro_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV36CpjTipoIdFiltro), 11, 0)), 1, dynavCpjtipoidfiltro_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", dynavCpjtipoidfiltro.Visible, dynavCpjtipoidfiltro.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", "", "", true, 0, "HLP_core\\ClientePJ.htm");
         dynavCpjtipoidfiltro.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV36CpjTipoIdFiltro), 11, 0));
         AssignProp("", false, dynavCpjtipoidfiltro_Internalname, "Values", (string)(dynavCpjtipoidfiltro.ToJavascriptSource()), true);
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCpjTipoSigla_Internalname, A366CpjTipoSigla, StringUtil.RTrim( context.localUtil.Format( A366CpjTipoSigla, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCpjTipoSigla_Jsonclick, 0, "Attribute", "", "", "", "", edtCpjTipoSigla_Visible, edtCpjTipoSigla_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "core\\Sigla", "start", true, "", "HLP_core\\ClientePJ.htm");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCpjTipoNome_Internalname, A367CpjTipoNome, StringUtil.RTrim( context.localUtil.Format( A367CpjTipoNome, "@!")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCpjTipoNome_Jsonclick, 0, "Attribute", "", "", "", "", edtCpjTipoNome_Visible, edtCpjTipoNome_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "core\\Nome", "start", true, "", "HLP_core\\ClientePJ.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 123,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliID_Internalname, A158CliID.ToString(), A158CliID.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,123);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliID_Jsonclick, 0, "Attribute", "", "", "", "", edtCliID_Visible, edtCliID_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_core\\ClientePJ.htm");
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
         E110P2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV17DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( "vCPJTIPOID_DATA"), AV24CpjTipoId_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vCPJPAIID_DATA"), AV29CpjPaiID_Data);
               /* Read saved values. */
               Z158CliID = StringUtil.StrToGuid( cgiGet( "Z158CliID"));
               Z166CpjID = StringUtil.StrToGuid( cgiGet( "Z166CpjID"));
               Z187CpjCNPJ = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z187CpjCNPJ"), ",", "."), 18, MidpointRounding.ToEven));
               Z189CpjIE = cgiGet( "Z189CpjIE");
               Z176CpjMatricula = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z176CpjMatricula"), ",", "."), 18, MidpointRounding.ToEven));
               Z200CpjInsDataHora = context.localUtil.CToT( cgiGet( "Z200CpjInsDataHora"), 0);
               Z198CpjInsData = context.localUtil.CToD( cgiGet( "Z198CpjInsData"), 0);
               Z199CpjInsHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z199CpjInsHora"), 0));
               Z543CpjDelDataHora = context.localUtil.CToT( cgiGet( "Z543CpjDelDataHora"), 0);
               n543CpjDelDataHora = ((DateTime.MinValue==A543CpjDelDataHora) ? true : false);
               Z544CpjDelData = context.localUtil.CToT( cgiGet( "Z544CpjDelData"), 0);
               n544CpjDelData = ((DateTime.MinValue==A544CpjDelData) ? true : false);
               Z545CpjDelHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z545CpjDelHora"), 0));
               n545CpjDelHora = ((DateTime.MinValue==A545CpjDelHora) ? true : false);
               Z546CpjDelUsuId = cgiGet( "Z546CpjDelUsuId");
               n546CpjDelUsuId = (String.IsNullOrEmpty(StringUtil.RTrim( A546CpjDelUsuId)) ? true : false);
               Z547CpjDelUsuNome = cgiGet( "Z547CpjDelUsuNome");
               n547CpjDelUsuNome = (String.IsNullOrEmpty(StringUtil.RTrim( A547CpjDelUsuNome)) ? true : false);
               Z170CpjNomeFan = cgiGet( "Z170CpjNomeFan");
               Z171CpjRazaoSoc = cgiGet( "Z171CpjRazaoSoc");
               Z188CpjCNPJFormat = cgiGet( "Z188CpjCNPJFormat");
               Z190CpjCapitalSoc = context.localUtil.CToN( cgiGet( "Z190CpjCapitalSoc"), ",", ".");
               Z201CpjInsUserID = cgiGet( "Z201CpjInsUserID");
               n201CpjInsUserID = (String.IsNullOrEmpty(StringUtil.RTrim( A201CpjInsUserID)) ? true : false);
               Z202CpjUpdData = context.localUtil.CToD( cgiGet( "Z202CpjUpdData"), 0);
               n202CpjUpdData = ((DateTime.MinValue==A202CpjUpdData) ? true : false);
               Z203CpjUpdHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z203CpjUpdHora"), 0));
               n203CpjUpdHora = ((DateTime.MinValue==A203CpjUpdHora) ? true : false);
               Z204CpjUpdDataHora = context.localUtil.CToT( cgiGet( "Z204CpjUpdDataHora"), 0);
               n204CpjUpdDataHora = ((DateTime.MinValue==A204CpjUpdDataHora) ? true : false);
               Z205CpjUpdUserID = cgiGet( "Z205CpjUpdUserID");
               n205CpjUpdUserID = (String.IsNullOrEmpty(StringUtil.RTrim( A205CpjUpdUserID)) ? true : false);
               Z206CpjVersao = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z206CpjVersao"), ",", "."), 18, MidpointRounding.ToEven));
               Z207CpjAtivo = StringUtil.StrToBool( cgiGet( "Z207CpjAtivo"));
               Z261CpjTelNum = cgiGet( "Z261CpjTelNum");
               n261CpjTelNum = (String.IsNullOrEmpty(StringUtil.RTrim( A261CpjTelNum)) ? true : false);
               Z262CpjTelRam = cgiGet( "Z262CpjTelRam");
               n262CpjTelRam = (String.IsNullOrEmpty(StringUtil.RTrim( A262CpjTelRam)) ? true : false);
               Z263CpjCelNum = cgiGet( "Z263CpjCelNum");
               n263CpjCelNum = (String.IsNullOrEmpty(StringUtil.RTrim( A263CpjCelNum)) ? true : false);
               Z264CpjWppNum = cgiGet( "Z264CpjWppNum");
               n264CpjWppNum = (String.IsNullOrEmpty(StringUtil.RTrim( A264CpjWppNum)) ? true : false);
               Z265CpjWebsite = cgiGet( "Z265CpjWebsite");
               n265CpjWebsite = (String.IsNullOrEmpty(StringUtil.RTrim( A265CpjWebsite)) ? true : false);
               Z266CpjEmail = cgiGet( "Z266CpjEmail");
               n266CpjEmail = (String.IsNullOrEmpty(StringUtil.RTrim( A266CpjEmail)) ? true : false);
               Z542CpjDel = StringUtil.StrToBool( cgiGet( "Z542CpjDel"));
               Z365CpjTipoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z365CpjTipoId"), ",", "."), 18, MidpointRounding.ToEven));
               Z181CpjHolID = StringUtil.StrToGuid( cgiGet( "Z181CpjHolID"));
               n181CpjHolID = ((Guid.Empty==A181CpjHolID) ? true : false);
               Z169CpjPaiID = StringUtil.StrToGuid( cgiGet( "Z169CpjPaiID"));
               n169CpjPaiID = ((Guid.Empty==A169CpjPaiID) ? true : false);
               A187CpjCNPJ = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z187CpjCNPJ"), ",", "."), 18, MidpointRounding.ToEven));
               A200CpjInsDataHora = context.localUtil.CToT( cgiGet( "Z200CpjInsDataHora"), 0);
               A198CpjInsData = context.localUtil.CToD( cgiGet( "Z198CpjInsData"), 0);
               A199CpjInsHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z199CpjInsHora"), 0));
               A543CpjDelDataHora = context.localUtil.CToT( cgiGet( "Z543CpjDelDataHora"), 0);
               n543CpjDelDataHora = false;
               n543CpjDelDataHora = ((DateTime.MinValue==A543CpjDelDataHora) ? true : false);
               A544CpjDelData = context.localUtil.CToT( cgiGet( "Z544CpjDelData"), 0);
               n544CpjDelData = false;
               n544CpjDelData = ((DateTime.MinValue==A544CpjDelData) ? true : false);
               A545CpjDelHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z545CpjDelHora"), 0));
               n545CpjDelHora = false;
               n545CpjDelHora = ((DateTime.MinValue==A545CpjDelHora) ? true : false);
               A546CpjDelUsuId = cgiGet( "Z546CpjDelUsuId");
               n546CpjDelUsuId = false;
               n546CpjDelUsuId = (String.IsNullOrEmpty(StringUtil.RTrim( A546CpjDelUsuId)) ? true : false);
               A547CpjDelUsuNome = cgiGet( "Z547CpjDelUsuNome");
               n547CpjDelUsuNome = false;
               n547CpjDelUsuNome = (String.IsNullOrEmpty(StringUtil.RTrim( A547CpjDelUsuNome)) ? true : false);
               A201CpjInsUserID = cgiGet( "Z201CpjInsUserID");
               n201CpjInsUserID = false;
               n201CpjInsUserID = (String.IsNullOrEmpty(StringUtil.RTrim( A201CpjInsUserID)) ? true : false);
               A202CpjUpdData = context.localUtil.CToD( cgiGet( "Z202CpjUpdData"), 0);
               n202CpjUpdData = false;
               n202CpjUpdData = ((DateTime.MinValue==A202CpjUpdData) ? true : false);
               A203CpjUpdHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z203CpjUpdHora"), 0));
               n203CpjUpdHora = false;
               n203CpjUpdHora = ((DateTime.MinValue==A203CpjUpdHora) ? true : false);
               A204CpjUpdDataHora = context.localUtil.CToT( cgiGet( "Z204CpjUpdDataHora"), 0);
               n204CpjUpdDataHora = false;
               n204CpjUpdDataHora = ((DateTime.MinValue==A204CpjUpdDataHora) ? true : false);
               A205CpjUpdUserID = cgiGet( "Z205CpjUpdUserID");
               n205CpjUpdUserID = false;
               n205CpjUpdUserID = (String.IsNullOrEmpty(StringUtil.RTrim( A205CpjUpdUserID)) ? true : false);
               A206CpjVersao = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z206CpjVersao"), ",", "."), 18, MidpointRounding.ToEven));
               A207CpjAtivo = StringUtil.StrToBool( cgiGet( "Z207CpjAtivo"));
               A542CpjDel = StringUtil.StrToBool( cgiGet( "Z542CpjDel"));
               A181CpjHolID = StringUtil.StrToGuid( cgiGet( "Z181CpjHolID"));
               n181CpjHolID = false;
               n181CpjHolID = ((Guid.Empty==A181CpjHolID) ? true : false);
               O542CpjDel = StringUtil.StrToBool( cgiGet( "O542CpjDel"));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N181CpjHolID = StringUtil.StrToGuid( cgiGet( "N181CpjHolID"));
               n181CpjHolID = ((Guid.Empty==A181CpjHolID) ? true : false);
               N169CpjPaiID = StringUtil.StrToGuid( cgiGet( "N169CpjPaiID"));
               n169CpjPaiID = ((Guid.Empty==A169CpjPaiID) ? true : false);
               N365CpjTipoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N365CpjTipoId"), ",", "."), 18, MidpointRounding.ToEven));
               AV38Cond_CpjTipoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vCOND_CPJTIPOID"), ",", "."), 18, MidpointRounding.ToEven));
               AV7CliID = StringUtil.StrToGuid( cgiGet( "vCLIID"));
               AV8CpjID = StringUtil.StrToGuid( cgiGet( "vCPJID"));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ",", "."), 18, MidpointRounding.ToEven));
               AV28Insert_CpjHolID = StringUtil.StrToGuid( cgiGet( "vINSERT_CPJHOLID"));
               A181CpjHolID = StringUtil.StrToGuid( cgiGet( "CPJHOLID"));
               n181CpjHolID = ((Guid.Empty==A181CpjHolID) ? true : false);
               AV27Insert_CpjPaiID = StringUtil.StrToGuid( cgiGet( "vINSERT_CPJPAIID"));
               AV14Insert_CpjTipoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_CPJTIPOID"), ",", "."), 18, MidpointRounding.ToEven));
               A187CpjCNPJ = (long)(Math.Round(context.localUtil.CToN( cgiGet( "CPJCNPJ"), ",", "."), 18, MidpointRounding.ToEven));
               A200CpjInsDataHora = context.localUtil.CToT( cgiGet( "CPJINSDATAHORA"), 0);
               A198CpjInsData = context.localUtil.CToD( cgiGet( "CPJINSDATA"), 0);
               A199CpjInsHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "CPJINSHORA"), 0));
               A542CpjDel = StringUtil.StrToBool( cgiGet( "CPJDEL"));
               A543CpjDelDataHora = context.localUtil.CToT( cgiGet( "CPJDELDATAHORA"), 0);
               n543CpjDelDataHora = ((DateTime.MinValue==A543CpjDelDataHora) ? true : false);
               A544CpjDelData = context.localUtil.CToT( cgiGet( "CPJDELDATA"), 0);
               n544CpjDelData = ((DateTime.MinValue==A544CpjDelData) ? true : false);
               A545CpjDelHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "CPJDELHORA"), 0));
               n545CpjDelHora = ((DateTime.MinValue==A545CpjDelHora) ? true : false);
               A546CpjDelUsuId = cgiGet( "CPJDELUSUID");
               n546CpjDelUsuId = (String.IsNullOrEmpty(StringUtil.RTrim( A546CpjDelUsuId)) ? true : false);
               A547CpjDelUsuNome = cgiGet( "CPJDELUSUNOME");
               n547CpjDelUsuNome = (String.IsNullOrEmpty(StringUtil.RTrim( A547CpjDelUsuNome)) ? true : false);
               A207CpjAtivo = StringUtil.StrToBool( cgiGet( "CPJATIVO"));
               A206CpjVersao = (short)(Math.Round(context.localUtil.CToN( cgiGet( "CPJVERSAO"), ",", "."), 18, MidpointRounding.ToEven));
               A201CpjInsUserID = cgiGet( "CPJINSUSERID");
               n201CpjInsUserID = (String.IsNullOrEmpty(StringUtil.RTrim( A201CpjInsUserID)) ? true : false);
               ajax_req_read_hidden_sdt(cgiGet( "vAUDITINGOBJECT"), AV39AuditingObject);
               A202CpjUpdData = context.localUtil.CToD( cgiGet( "CPJUPDDATA"), 0);
               n202CpjUpdData = ((DateTime.MinValue==A202CpjUpdData) ? true : false);
               A203CpjUpdHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "CPJUPDHORA"), 0));
               n203CpjUpdHora = ((DateTime.MinValue==A203CpjUpdHora) ? true : false);
               A204CpjUpdDataHora = context.localUtil.CToT( cgiGet( "CPJUPDDATAHORA"), 0);
               n204CpjUpdDataHora = ((DateTime.MinValue==A204CpjUpdDataHora) ? true : false);
               A205CpjUpdUserID = cgiGet( "CPJUPDUSERID");
               n205CpjUpdUserID = (String.IsNullOrEmpty(StringUtil.RTrim( A205CpjUpdUserID)) ? true : false);
               A182CpjHolNomeFan = cgiGet( "CPJHOLNOMEFAN");
               A183CpjHolRazaoSoc = cgiGet( "CPJHOLRAZAOSOC");
               A191CpjHolMatricula = (long)(Math.Round(context.localUtil.CToN( cgiGet( "CPJHOLMATRICULA"), ",", "."), 18, MidpointRounding.ToEven));
               A192CpjHolCNPJ = (long)(Math.Round(context.localUtil.CToN( cgiGet( "CPJHOLCNPJ"), ",", "."), 18, MidpointRounding.ToEven));
               A193CpjHolCNPJFormat = cgiGet( "CPJHOLCNPJFORMAT");
               A172CpjPaiNomeFan = cgiGet( "CPJPAINOMEFAN");
               A173CpjPaiRazaoSoc = cgiGet( "CPJPAIRAZAOSOC");
               A175CpjPaiMatricula = (long)(Math.Round(context.localUtil.CToN( cgiGet( "CPJPAIMATRICULA"), ",", "."), 18, MidpointRounding.ToEven));
               A194CpjPaiCNPJ = (long)(Math.Round(context.localUtil.CToN( cgiGet( "CPJPAICNPJ"), ",", "."), 18, MidpointRounding.ToEven));
               A195CpjPaiCNPJFormat = cgiGet( "CPJPAICNPJFORMAT");
               A184CpjPaiTipoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CPJPAITIPOID"), ",", "."), 18, MidpointRounding.ToEven));
               A185CpjPaiTipoSigla = cgiGet( "CPJPAITIPOSIGLA");
               A186CpjPaiTipoNome = cgiGet( "CPJPAITIPONOME");
               AV41Pgmname = cgiGet( "vPGMNAME");
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
               Combo_cpjtipoid_Objectcall = cgiGet( "COMBO_CPJTIPOID_Objectcall");
               Combo_cpjtipoid_Class = cgiGet( "COMBO_CPJTIPOID_Class");
               Combo_cpjtipoid_Icontype = cgiGet( "COMBO_CPJTIPOID_Icontype");
               Combo_cpjtipoid_Icon = cgiGet( "COMBO_CPJTIPOID_Icon");
               Combo_cpjtipoid_Caption = cgiGet( "COMBO_CPJTIPOID_Caption");
               Combo_cpjtipoid_Tooltip = cgiGet( "COMBO_CPJTIPOID_Tooltip");
               Combo_cpjtipoid_Cls = cgiGet( "COMBO_CPJTIPOID_Cls");
               Combo_cpjtipoid_Selectedvalue_set = cgiGet( "COMBO_CPJTIPOID_Selectedvalue_set");
               Combo_cpjtipoid_Selectedvalue_get = cgiGet( "COMBO_CPJTIPOID_Selectedvalue_get");
               Combo_cpjtipoid_Selectedtext_set = cgiGet( "COMBO_CPJTIPOID_Selectedtext_set");
               Combo_cpjtipoid_Selectedtext_get = cgiGet( "COMBO_CPJTIPOID_Selectedtext_get");
               Combo_cpjtipoid_Gamoauthtoken = cgiGet( "COMBO_CPJTIPOID_Gamoauthtoken");
               Combo_cpjtipoid_Ddointernalname = cgiGet( "COMBO_CPJTIPOID_Ddointernalname");
               Combo_cpjtipoid_Titlecontrolalign = cgiGet( "COMBO_CPJTIPOID_Titlecontrolalign");
               Combo_cpjtipoid_Dropdownoptionstype = cgiGet( "COMBO_CPJTIPOID_Dropdownoptionstype");
               Combo_cpjtipoid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_CPJTIPOID_Enabled"));
               Combo_cpjtipoid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_CPJTIPOID_Visible"));
               Combo_cpjtipoid_Titlecontrolidtoreplace = cgiGet( "COMBO_CPJTIPOID_Titlecontrolidtoreplace");
               Combo_cpjtipoid_Datalisttype = cgiGet( "COMBO_CPJTIPOID_Datalisttype");
               Combo_cpjtipoid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_CPJTIPOID_Allowmultipleselection"));
               Combo_cpjtipoid_Datalistfixedvalues = cgiGet( "COMBO_CPJTIPOID_Datalistfixedvalues");
               Combo_cpjtipoid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_CPJTIPOID_Isgriditem"));
               Combo_cpjtipoid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_CPJTIPOID_Hasdescription"));
               Combo_cpjtipoid_Datalistproc = cgiGet( "COMBO_CPJTIPOID_Datalistproc");
               Combo_cpjtipoid_Datalistprocparametersprefix = cgiGet( "COMBO_CPJTIPOID_Datalistprocparametersprefix");
               Combo_cpjtipoid_Remoteservicesparameters = cgiGet( "COMBO_CPJTIPOID_Remoteservicesparameters");
               Combo_cpjtipoid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_CPJTIPOID_Datalistupdateminimumcharacters"), ",", "."), 18, MidpointRounding.ToEven));
               Combo_cpjtipoid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_CPJTIPOID_Includeonlyselectedoption"));
               Combo_cpjtipoid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_CPJTIPOID_Includeselectalloption"));
               Combo_cpjtipoid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_CPJTIPOID_Emptyitem"));
               Combo_cpjtipoid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_CPJTIPOID_Includeaddnewoption"));
               Combo_cpjtipoid_Htmltemplate = cgiGet( "COMBO_CPJTIPOID_Htmltemplate");
               Combo_cpjtipoid_Multiplevaluestype = cgiGet( "COMBO_CPJTIPOID_Multiplevaluestype");
               Combo_cpjtipoid_Loadingdata = cgiGet( "COMBO_CPJTIPOID_Loadingdata");
               Combo_cpjtipoid_Noresultsfound = cgiGet( "COMBO_CPJTIPOID_Noresultsfound");
               Combo_cpjtipoid_Emptyitemtext = cgiGet( "COMBO_CPJTIPOID_Emptyitemtext");
               Combo_cpjtipoid_Onlyselectedvalues = cgiGet( "COMBO_CPJTIPOID_Onlyselectedvalues");
               Combo_cpjtipoid_Selectalltext = cgiGet( "COMBO_CPJTIPOID_Selectalltext");
               Combo_cpjtipoid_Multiplevaluesseparator = cgiGet( "COMBO_CPJTIPOID_Multiplevaluesseparator");
               Combo_cpjtipoid_Addnewoptiontext = cgiGet( "COMBO_CPJTIPOID_Addnewoptiontext");
               Combo_cpjtipoid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_CPJTIPOID_Gxcontroltype"), ",", "."), 18, MidpointRounding.ToEven));
               Combo_cpjpaiid_Objectcall = cgiGet( "COMBO_CPJPAIID_Objectcall");
               Combo_cpjpaiid_Class = cgiGet( "COMBO_CPJPAIID_Class");
               Combo_cpjpaiid_Icontype = cgiGet( "COMBO_CPJPAIID_Icontype");
               Combo_cpjpaiid_Icon = cgiGet( "COMBO_CPJPAIID_Icon");
               Combo_cpjpaiid_Caption = cgiGet( "COMBO_CPJPAIID_Caption");
               Combo_cpjpaiid_Tooltip = cgiGet( "COMBO_CPJPAIID_Tooltip");
               Combo_cpjpaiid_Cls = cgiGet( "COMBO_CPJPAIID_Cls");
               Combo_cpjpaiid_Selectedvalue_set = cgiGet( "COMBO_CPJPAIID_Selectedvalue_set");
               Combo_cpjpaiid_Selectedvalue_get = cgiGet( "COMBO_CPJPAIID_Selectedvalue_get");
               Combo_cpjpaiid_Selectedtext_set = cgiGet( "COMBO_CPJPAIID_Selectedtext_set");
               Combo_cpjpaiid_Selectedtext_get = cgiGet( "COMBO_CPJPAIID_Selectedtext_get");
               Combo_cpjpaiid_Gamoauthtoken = cgiGet( "COMBO_CPJPAIID_Gamoauthtoken");
               Combo_cpjpaiid_Ddointernalname = cgiGet( "COMBO_CPJPAIID_Ddointernalname");
               Combo_cpjpaiid_Titlecontrolalign = cgiGet( "COMBO_CPJPAIID_Titlecontrolalign");
               Combo_cpjpaiid_Dropdownoptionstype = cgiGet( "COMBO_CPJPAIID_Dropdownoptionstype");
               Combo_cpjpaiid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_CPJPAIID_Enabled"));
               Combo_cpjpaiid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_CPJPAIID_Visible"));
               Combo_cpjpaiid_Titlecontrolidtoreplace = cgiGet( "COMBO_CPJPAIID_Titlecontrolidtoreplace");
               Combo_cpjpaiid_Datalisttype = cgiGet( "COMBO_CPJPAIID_Datalisttype");
               Combo_cpjpaiid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_CPJPAIID_Allowmultipleselection"));
               Combo_cpjpaiid_Datalistfixedvalues = cgiGet( "COMBO_CPJPAIID_Datalistfixedvalues");
               Combo_cpjpaiid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_CPJPAIID_Isgriditem"));
               Combo_cpjpaiid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_CPJPAIID_Hasdescription"));
               Combo_cpjpaiid_Datalistproc = cgiGet( "COMBO_CPJPAIID_Datalistproc");
               Combo_cpjpaiid_Datalistprocparametersprefix = cgiGet( "COMBO_CPJPAIID_Datalistprocparametersprefix");
               Combo_cpjpaiid_Remoteservicesparameters = cgiGet( "COMBO_CPJPAIID_Remoteservicesparameters");
               Combo_cpjpaiid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_CPJPAIID_Datalistupdateminimumcharacters"), ",", "."), 18, MidpointRounding.ToEven));
               Combo_cpjpaiid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_CPJPAIID_Includeonlyselectedoption"));
               Combo_cpjpaiid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_CPJPAIID_Includeselectalloption"));
               Combo_cpjpaiid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_CPJPAIID_Emptyitem"));
               Combo_cpjpaiid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_CPJPAIID_Includeaddnewoption"));
               Combo_cpjpaiid_Htmltemplate = cgiGet( "COMBO_CPJPAIID_Htmltemplate");
               Combo_cpjpaiid_Multiplevaluestype = cgiGet( "COMBO_CPJPAIID_Multiplevaluestype");
               Combo_cpjpaiid_Loadingdata = cgiGet( "COMBO_CPJPAIID_Loadingdata");
               Combo_cpjpaiid_Noresultsfound = cgiGet( "COMBO_CPJPAIID_Noresultsfound");
               Combo_cpjpaiid_Emptyitemtext = cgiGet( "COMBO_CPJPAIID_Emptyitemtext");
               Combo_cpjpaiid_Onlyselectedvalues = cgiGet( "COMBO_CPJPAIID_Onlyselectedvalues");
               Combo_cpjpaiid_Selectalltext = cgiGet( "COMBO_CPJPAIID_Selectalltext");
               Combo_cpjpaiid_Multiplevaluesseparator = cgiGet( "COMBO_CPJPAIID_Multiplevaluesseparator");
               Combo_cpjpaiid_Addnewoptiontext = cgiGet( "COMBO_CPJPAIID_Addnewoptiontext");
               Combo_cpjpaiid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_CPJPAIID_Gxcontroltype"), ",", "."), 18, MidpointRounding.ToEven));
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
               if ( ( ( context.localUtil.CToN( cgiGet( edtCpjTipoId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCpjTipoId_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CPJTIPOID");
                  AnyError = 1;
                  GX_FocusControl = edtCpjTipoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A365CpjTipoId = 0;
                  AssignAttri("", false, "A365CpjTipoId", StringUtil.LTrimStr( (decimal)(A365CpjTipoId), 9, 0));
               }
               else
               {
                  A365CpjTipoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtCpjTipoId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A365CpjTipoId", StringUtil.LTrimStr( (decimal)(A365CpjTipoId), 9, 0));
               }
               if ( StringUtil.StrCmp(cgiGet( edtCpjPaiID_Internalname), "") == 0 )
               {
                  A169CpjPaiID = Guid.Empty;
                  n169CpjPaiID = false;
                  AssignAttri("", false, "A169CpjPaiID", A169CpjPaiID.ToString());
               }
               else
               {
                  try
                  {
                     A169CpjPaiID = StringUtil.StrToGuid( cgiGet( edtCpjPaiID_Internalname));
                     n169CpjPaiID = false;
                     AssignAttri("", false, "A169CpjPaiID", A169CpjPaiID.ToString());
                  }
                  catch ( Exception  )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "CPJPAIID");
                     AnyError = 1;
                     GX_FocusControl = edtCpjPaiID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     wbErr = true;
                  }
               }
               n169CpjPaiID = ((Guid.Empty==A169CpjPaiID) ? true : false);
               A170CpjNomeFan = StringUtil.Upper( cgiGet( edtCpjNomeFan_Internalname));
               AssignAttri("", false, "A170CpjNomeFan", A170CpjNomeFan);
               A171CpjRazaoSoc = StringUtil.Upper( cgiGet( edtCpjRazaoSoc_Internalname));
               AssignAttri("", false, "A171CpjRazaoSoc", A171CpjRazaoSoc);
               A176CpjMatricula = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtCpjMatricula_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A176CpjMatricula", StringUtil.LTrimStr( (decimal)(A176CpjMatricula), 12, 0));
               A188CpjCNPJFormat = cgiGet( edtCpjCNPJFormat_Internalname);
               AssignAttri("", false, "A188CpjCNPJFormat", A188CpjCNPJFormat);
               A189CpjIE = StringUtil.Upper( cgiGet( edtCpjIE_Internalname));
               AssignAttri("", false, "A189CpjIE", A189CpjIE);
               if ( ( ( context.localUtil.CToN( cgiGet( edtCpjCapitalSoc_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCpjCapitalSoc_Internalname), ",", ".") > 9999999999999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CPJCAPITALSOC");
                  AnyError = 1;
                  GX_FocusControl = edtCpjCapitalSoc_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A190CpjCapitalSoc = 0;
                  AssignAttri("", false, "A190CpjCapitalSoc", StringUtil.LTrimStr( A190CpjCapitalSoc, 16, 2));
               }
               else
               {
                  A190CpjCapitalSoc = context.localUtil.CToN( cgiGet( edtCpjCapitalSoc_Internalname), ",", ".");
                  AssignAttri("", false, "A190CpjCapitalSoc", StringUtil.LTrimStr( A190CpjCapitalSoc, 16, 2));
               }
               A261CpjTelNum = cgiGet( edtCpjTelNum_Internalname);
               n261CpjTelNum = false;
               AssignAttri("", false, "A261CpjTelNum", A261CpjTelNum);
               n261CpjTelNum = (String.IsNullOrEmpty(StringUtil.RTrim( A261CpjTelNum)) ? true : false);
               A262CpjTelRam = cgiGet( edtCpjTelRam_Internalname);
               n262CpjTelRam = false;
               AssignAttri("", false, "A262CpjTelRam", A262CpjTelRam);
               n262CpjTelRam = (String.IsNullOrEmpty(StringUtil.RTrim( A262CpjTelRam)) ? true : false);
               A263CpjCelNum = cgiGet( edtCpjCelNum_Internalname);
               n263CpjCelNum = false;
               AssignAttri("", false, "A263CpjCelNum", A263CpjCelNum);
               n263CpjCelNum = (String.IsNullOrEmpty(StringUtil.RTrim( A263CpjCelNum)) ? true : false);
               A264CpjWppNum = cgiGet( edtCpjWppNum_Internalname);
               n264CpjWppNum = false;
               AssignAttri("", false, "A264CpjWppNum", A264CpjWppNum);
               n264CpjWppNum = (String.IsNullOrEmpty(StringUtil.RTrim( A264CpjWppNum)) ? true : false);
               A265CpjWebsite = cgiGet( edtCpjWebsite_Internalname);
               n265CpjWebsite = false;
               AssignAttri("", false, "A265CpjWebsite", A265CpjWebsite);
               n265CpjWebsite = (String.IsNullOrEmpty(StringUtil.RTrim( A265CpjWebsite)) ? true : false);
               A266CpjEmail = cgiGet( edtCpjEmail_Internalname);
               n266CpjEmail = false;
               AssignAttri("", false, "A266CpjEmail", A266CpjEmail);
               n266CpjEmail = (String.IsNullOrEmpty(StringUtil.RTrim( A266CpjEmail)) ? true : false);
               AV25ComboCpjTipoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavCombocpjtipoid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV25ComboCpjTipoId", StringUtil.LTrimStr( (decimal)(AV25ComboCpjTipoId), 9, 0));
               AV30ComboCpjPaiID = StringUtil.StrToGuid( cgiGet( edtavCombocpjpaiid_Internalname));
               AssignAttri("", false, "AV30ComboCpjPaiID", AV30ComboCpjPaiID.ToString());
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
               dynavCpjtipoidfiltro.CurrentValue = cgiGet( dynavCpjtipoidfiltro_Internalname);
               AV36CpjTipoIdFiltro = (int)(Math.Round(NumberUtil.Val( cgiGet( dynavCpjtipoidfiltro_Internalname), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV36CpjTipoIdFiltro", StringUtil.LTrimStr( (decimal)(AV36CpjTipoIdFiltro), 9, 0));
               A366CpjTipoSigla = cgiGet( edtCpjTipoSigla_Internalname);
               AssignAttri("", false, "A366CpjTipoSigla", A366CpjTipoSigla);
               A367CpjTipoNome = StringUtil.Upper( cgiGet( edtCpjTipoNome_Internalname));
               AssignAttri("", false, "A367CpjTipoNome", A367CpjTipoNome);
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
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"ClientePJ");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("Pgmname", StringUtil.RTrim( context.localUtil.Format( AV41Pgmname, "")));
               forbiddenHiddens.Add("CpjUpdData", context.localUtil.Format(A202CpjUpdData, "99/99/99"));
               forbiddenHiddens.Add("CpjUpdHora", context.localUtil.Format( A203CpjUpdHora, "99:99"));
               forbiddenHiddens.Add("CpjUpdDataHora", context.localUtil.Format( A204CpjUpdDataHora, "99/99/9999 99:99:99.999"));
               forbiddenHiddens.Add("CpjUpdUserID", StringUtil.RTrim( context.localUtil.Format( A205CpjUpdUserID, "")));
               forbiddenHiddens.Add("CpjVersao", context.localUtil.Format( (decimal)(A206CpjVersao), "ZZZ9"));
               forbiddenHiddens.Add("CpjAtivo", StringUtil.BoolToStr( A207CpjAtivo));
               forbiddenHiddens.Add("CpjDel", StringUtil.BoolToStr( A542CpjDel));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A158CliID != Z158CliID ) || ( A166CpjID != Z166CpjID ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("core\\clientepj:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  getEqualNoModal( ) ;
                  if ( ! (Guid.Empty==AV8CpjID) )
                  {
                     A166CpjID = AV8CpjID;
                     AssignAttri("", false, "A166CpjID", A166CpjID.ToString());
                  }
                  else
                  {
                     if ( IsIns( )  && (Guid.Empty==A166CpjID) && ( Gx_BScreen == 0 ) )
                     {
                        A166CpjID = Guid.NewGuid( );
                        AssignAttri("", false, "A166CpjID", A166CpjID.ToString());
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
                     sMode25 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     if ( ! (Guid.Empty==AV8CpjID) )
                     {
                        A166CpjID = AV8CpjID;
                        AssignAttri("", false, "A166CpjID", A166CpjID.ToString());
                     }
                     else
                     {
                        if ( IsIns( )  && (Guid.Empty==A166CpjID) && ( Gx_BScreen == 0 ) )
                        {
                           A166CpjID = Guid.NewGuid( );
                           AssignAttri("", false, "A166CpjID", A166CpjID.ToString());
                        }
                     }
                     Gx_mode = sMode25;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound25 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0P0( ) ;
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
                        if ( StringUtil.StrCmp(sEvt, "COMBO_CPJPAIID.ONOPTIONCLICKED") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           E120P2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E110P2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E130P2 ();
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
            E130P2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0P25( ) ;
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
            DisableAttributes0P25( ) ;
         }
         AssignProp("", false, edtavCombocpjtipoid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombocpjtipoid_Enabled), 5, 0), true);
         AssignProp("", false, edtavCombocpjpaiid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombocpjpaiid_Enabled), 5, 0), true);
         AssignProp("", false, dynavCpjtipoidfiltro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynavCpjtipoidfiltro.Enabled), 5, 0), true);
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

      protected void CONFIRM_0P0( )
      {
         BeforeValidate0P25( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0P25( ) ;
            }
            else
            {
               CheckExtendedTable0P25( ) ;
               CloseExtendedTableCursors0P25( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption0P0( )
      {
      }

      protected void E110P2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         AV13WebSession.Remove("CLIID");
         AV13WebSession.Remove("CPJID");
         this.executeExternalObjectMethod("", false, "WWPActions", "Mask_Apply", new Object[] {(string)edtCpjCNPJFormat_Internalname,"00.000.000/0000-00",(bool)false,(bool)false}, false);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV17DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV17DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         AV22GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV23GAMErrors);
         Combo_cpjpaiid_Gamoauthtoken = AV22GAMSession.gxTpr_Token;
         ucCombo_cpjpaiid.SendProperty(context, "", false, Combo_cpjpaiid_Internalname, "GAMOAuthToken", Combo_cpjpaiid_Gamoauthtoken);
         edtCpjPaiID_Visible = 0;
         AssignProp("", false, edtCpjPaiID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCpjPaiID_Visible), 5, 0), true);
         AV30ComboCpjPaiID = Guid.Empty;
         AssignAttri("", false, "AV30ComboCpjPaiID", AV30ComboCpjPaiID.ToString());
         edtavCombocpjpaiid_Visible = 0;
         AssignProp("", false, edtavCombocpjpaiid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombocpjpaiid_Visible), 5, 0), true);
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getstyleddvcombo(context ).execute(  "Title and subtitle", out  GXt_char2) ;
         Combo_cpjpaiid_Htmltemplate = GXt_char2;
         ucCombo_cpjpaiid.SendProperty(context, "", false, Combo_cpjpaiid_Internalname, "HTMLTemplate", Combo_cpjpaiid_Htmltemplate);
         edtCpjTipoId_Visible = 0;
         AssignProp("", false, edtCpjTipoId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCpjTipoId_Visible), 5, 0), true);
         AV25ComboCpjTipoId = 0;
         AssignAttri("", false, "AV25ComboCpjTipoId", StringUtil.LTrimStr( (decimal)(AV25ComboCpjTipoId), 9, 0));
         edtavCombocpjtipoid_Visible = 0;
         AssignProp("", false, edtavCombocpjtipoid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombocpjtipoid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOCPJTIPOID' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBOCPJPAIID' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV12TrnContext.FromXml(AV13WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV12TrnContext.gxTpr_Transactionname, AV41Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV42GXV1 = 1;
            AssignAttri("", false, "AV42GXV1", StringUtil.LTrimStr( (decimal)(AV42GXV1), 8, 0));
            while ( AV42GXV1 <= AV12TrnContext.gxTpr_Attributes.Count )
            {
               AV15TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV12TrnContext.gxTpr_Attributes.Item(AV42GXV1));
               if ( StringUtil.StrCmp(AV15TrnContextAtt.gxTpr_Attributename, "CpjHolID") == 0 )
               {
                  AV28Insert_CpjHolID = StringUtil.StrToGuid( AV15TrnContextAtt.gxTpr_Attributevalue);
                  AssignAttri("", false, "AV28Insert_CpjHolID", AV28Insert_CpjHolID.ToString());
               }
               else if ( StringUtil.StrCmp(AV15TrnContextAtt.gxTpr_Attributename, "CpjPaiID") == 0 )
               {
                  AV27Insert_CpjPaiID = StringUtil.StrToGuid( AV15TrnContextAtt.gxTpr_Attributevalue);
                  AssignAttri("", false, "AV27Insert_CpjPaiID", AV27Insert_CpjPaiID.ToString());
                  if ( ! (Guid.Empty==AV27Insert_CpjPaiID) )
                  {
                     AV30ComboCpjPaiID = AV27Insert_CpjPaiID;
                     AssignAttri("", false, "AV30ComboCpjPaiID", AV30ComboCpjPaiID.ToString());
                     Combo_cpjpaiid_Selectedvalue_set = StringUtil.Trim( AV30ComboCpjPaiID.ToString());
                     ucCombo_cpjpaiid.SendProperty(context, "", false, Combo_cpjpaiid_Internalname, "SelectedValue_set", Combo_cpjpaiid_Selectedvalue_set);
                     GXt_char2 = AV20Combo_DataJson;
                     new GeneXus.Programs.core.clientepjloaddvcombo(context ).execute(  "CpjPaiID",  "GET",  false,  AV7CliID,  AV8CpjID,  A365CpjTipoId,  A158CliID,  AV15TrnContextAtt.gxTpr_Attributevalue, out  AV18ComboSelectedValue, out  AV19ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV18ComboSelectedValue", AV18ComboSelectedValue);
                     AssignAttri("", false, "AV19ComboSelectedText", AV19ComboSelectedText);
                     AV20Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV20Combo_DataJson", AV20Combo_DataJson);
                     Combo_cpjpaiid_Selectedtext_set = AV19ComboSelectedText;
                     ucCombo_cpjpaiid.SendProperty(context, "", false, Combo_cpjpaiid_Internalname, "SelectedText_set", Combo_cpjpaiid_Selectedtext_set);
                     Combo_cpjpaiid_Enabled = false;
                     ucCombo_cpjpaiid.SendProperty(context, "", false, Combo_cpjpaiid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_cpjpaiid_Enabled));
                  }
               }
               else if ( StringUtil.StrCmp(AV15TrnContextAtt.gxTpr_Attributename, "CpjTipoId") == 0 )
               {
                  AV14Insert_CpjTipoId = (int)(Math.Round(NumberUtil.Val( AV15TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV14Insert_CpjTipoId", StringUtil.LTrimStr( (decimal)(AV14Insert_CpjTipoId), 9, 0));
                  if ( ! (0==AV14Insert_CpjTipoId) )
                  {
                     AV25ComboCpjTipoId = AV14Insert_CpjTipoId;
                     AssignAttri("", false, "AV25ComboCpjTipoId", StringUtil.LTrimStr( (decimal)(AV25ComboCpjTipoId), 9, 0));
                     Combo_cpjtipoid_Selectedvalue_set = StringUtil.Trim( StringUtil.Str( (decimal)(AV25ComboCpjTipoId), 9, 0));
                     ucCombo_cpjtipoid.SendProperty(context, "", false, Combo_cpjtipoid_Internalname, "SelectedValue_set", Combo_cpjtipoid_Selectedvalue_set);
                     Combo_cpjtipoid_Enabled = false;
                     ucCombo_cpjtipoid.SendProperty(context, "", false, Combo_cpjtipoid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_cpjtipoid_Enabled));
                  }
               }
               AV42GXV1 = (int)(AV42GXV1+1);
               AssignAttri("", false, "AV42GXV1", StringUtil.LTrimStr( (decimal)(AV42GXV1), 8, 0));
            }
         }
         edtCpjID_Visible = 0;
         AssignProp("", false, edtCpjID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCpjID_Visible), 5, 0), true);
         dynavCpjtipoidfiltro.Visible = 0;
         AssignProp("", false, dynavCpjtipoidfiltro_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(dynavCpjtipoidfiltro.Visible), 5, 0), true);
         edtCpjTipoSigla_Visible = 0;
         AssignProp("", false, edtCpjTipoSigla_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCpjTipoSigla_Visible), 5, 0), true);
         edtCpjTipoNome_Visible = 0;
         AssignProp("", false, edtCpjTipoNome_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCpjTipoNome_Visible), 5, 0), true);
         edtCliID_Visible = 0;
         AssignProp("", false, edtCliID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCliID_Visible), 5, 0), true);
      }

      protected void E130P2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.audittransaction(context ).execute(  AV39AuditingObject,  AV41Pgmname) ;
         AV13WebSession.Set("CLIID", StringUtil.Trim( A158CliID.ToString()));
         AV13WebSession.Set("CPJID", StringUtil.Trim( A166CpjID.ToString()));
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
         /*  Sending Event outputs  */
      }

      protected void E120P2( )
      {
         /* Combo_cpjpaiid_Onoptionclicked Routine */
         returnInSub = false;
         AV30ComboCpjPaiID = StringUtil.StrToGuid( Combo_cpjpaiid_Selectedvalue_get);
         AssignAttri("", false, "AV30ComboCpjPaiID", AV30ComboCpjPaiID.ToString());
         /*  Sending Event outputs  */
      }

      protected void S132( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         Combo_cpjpaiid_Visible = false;
         ucCombo_cpjpaiid.SendProperty(context, "", false, Combo_cpjpaiid_Internalname, "Visible", StringUtil.BoolToStr( Combo_cpjpaiid_Visible));
         divCombo_cpjpaiid_cell_Class = "Invisible";
         AssignProp("", false, divCombo_cpjpaiid_cell_Internalname, "Class", divCombo_cpjpaiid_cell_Class, true);
      }

      protected void S122( )
      {
         /* 'LOADCOMBOCPJPAIID' Routine */
         returnInSub = false;
         Combo_cpjpaiid_Datalistprocparametersprefix = StringUtil.Format( " \"ComboName\": \"CpjPaiID\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"CliID\": \"00000000-0000-0000-0000-000000000000\", \"CpjID\": \"00000000-0000-0000-0000-000000000000\", \"Cond_CpjTipoId\": \"#%1#\", \"Cond_CliID\": \"#%2#\"", edtCpjTipoId_Internalname, edtCliID_Internalname, "", "", "", "", "", "", "");
         ucCombo_cpjpaiid.SendProperty(context, "", false, Combo_cpjpaiid_Internalname, "DataListProcParametersPrefix", Combo_cpjpaiid_Datalistprocparametersprefix);
         GXt_char2 = AV20Combo_DataJson;
         new GeneXus.Programs.core.clientepjloaddvcombo(context ).execute(  "CpjPaiID",  Gx_mode,  false,  AV7CliID,  AV8CpjID,  A365CpjTipoId,  A158CliID,  "", out  AV18ComboSelectedValue, out  AV19ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV18ComboSelectedValue", AV18ComboSelectedValue);
         AssignAttri("", false, "AV19ComboSelectedText", AV19ComboSelectedText);
         AV20Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV20Combo_DataJson", AV20Combo_DataJson);
         Combo_cpjpaiid_Selectedvalue_set = AV18ComboSelectedValue;
         ucCombo_cpjpaiid.SendProperty(context, "", false, Combo_cpjpaiid_Internalname, "SelectedValue_set", Combo_cpjpaiid_Selectedvalue_set);
         Combo_cpjpaiid_Selectedtext_set = AV19ComboSelectedText;
         ucCombo_cpjpaiid.SendProperty(context, "", false, Combo_cpjpaiid_Internalname, "SelectedText_set", Combo_cpjpaiid_Selectedtext_set);
         AV30ComboCpjPaiID = StringUtil.StrToGuid( AV18ComboSelectedValue);
         AssignAttri("", false, "AV30ComboCpjPaiID", AV30ComboCpjPaiID.ToString());
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_cpjpaiid_Enabled = false;
            ucCombo_cpjpaiid.SendProperty(context, "", false, Combo_cpjpaiid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_cpjpaiid_Enabled));
         }
      }

      protected void S112( )
      {
         /* 'LOADCOMBOCPJTIPOID' Routine */
         returnInSub = false;
         GXt_char2 = AV20Combo_DataJson;
         new GeneXus.Programs.core.clientepjloaddvcombo(context ).execute(  "CpjTipoId",  Gx_mode,  false,  AV7CliID,  AV8CpjID,  A365CpjTipoId,  A158CliID,  "", out  AV18ComboSelectedValue, out  AV19ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV18ComboSelectedValue", AV18ComboSelectedValue);
         AssignAttri("", false, "AV19ComboSelectedText", AV19ComboSelectedText);
         AV20Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV20Combo_DataJson", AV20Combo_DataJson);
         AV24CpjTipoId_Data.FromJSonString(AV20Combo_DataJson, null);
         Combo_cpjtipoid_Selectedvalue_set = AV18ComboSelectedValue;
         ucCombo_cpjtipoid.SendProperty(context, "", false, Combo_cpjtipoid_Internalname, "SelectedValue_set", Combo_cpjtipoid_Selectedvalue_set);
         AV25ComboCpjTipoId = (int)(Math.Round(NumberUtil.Val( AV18ComboSelectedValue, "."), 18, MidpointRounding.ToEven));
         AssignAttri("", false, "AV25ComboCpjTipoId", StringUtil.LTrimStr( (decimal)(AV25ComboCpjTipoId), 9, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_cpjtipoid_Enabled = false;
            ucCombo_cpjtipoid.SendProperty(context, "", false, Combo_cpjtipoid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_cpjtipoid_Enabled));
         }
      }

      protected void ZM0P25( short GX_JID )
      {
         if ( ( GX_JID == 55 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z187CpjCNPJ = T000P3_A187CpjCNPJ[0];
               Z189CpjIE = T000P3_A189CpjIE[0];
               Z176CpjMatricula = T000P3_A176CpjMatricula[0];
               Z200CpjInsDataHora = T000P3_A200CpjInsDataHora[0];
               Z198CpjInsData = T000P3_A198CpjInsData[0];
               Z199CpjInsHora = T000P3_A199CpjInsHora[0];
               Z543CpjDelDataHora = T000P3_A543CpjDelDataHora[0];
               Z544CpjDelData = T000P3_A544CpjDelData[0];
               Z545CpjDelHora = T000P3_A545CpjDelHora[0];
               Z546CpjDelUsuId = T000P3_A546CpjDelUsuId[0];
               Z547CpjDelUsuNome = T000P3_A547CpjDelUsuNome[0];
               Z170CpjNomeFan = T000P3_A170CpjNomeFan[0];
               Z171CpjRazaoSoc = T000P3_A171CpjRazaoSoc[0];
               Z188CpjCNPJFormat = T000P3_A188CpjCNPJFormat[0];
               Z190CpjCapitalSoc = T000P3_A190CpjCapitalSoc[0];
               Z201CpjInsUserID = T000P3_A201CpjInsUserID[0];
               Z202CpjUpdData = T000P3_A202CpjUpdData[0];
               Z203CpjUpdHora = T000P3_A203CpjUpdHora[0];
               Z204CpjUpdDataHora = T000P3_A204CpjUpdDataHora[0];
               Z205CpjUpdUserID = T000P3_A205CpjUpdUserID[0];
               Z206CpjVersao = T000P3_A206CpjVersao[0];
               Z207CpjAtivo = T000P3_A207CpjAtivo[0];
               Z261CpjTelNum = T000P3_A261CpjTelNum[0];
               Z262CpjTelRam = T000P3_A262CpjTelRam[0];
               Z263CpjCelNum = T000P3_A263CpjCelNum[0];
               Z264CpjWppNum = T000P3_A264CpjWppNum[0];
               Z265CpjWebsite = T000P3_A265CpjWebsite[0];
               Z266CpjEmail = T000P3_A266CpjEmail[0];
               Z542CpjDel = T000P3_A542CpjDel[0];
               Z365CpjTipoId = T000P3_A365CpjTipoId[0];
               Z181CpjHolID = T000P3_A181CpjHolID[0];
               Z169CpjPaiID = T000P3_A169CpjPaiID[0];
            }
            else
            {
               Z187CpjCNPJ = A187CpjCNPJ;
               Z189CpjIE = A189CpjIE;
               Z176CpjMatricula = A176CpjMatricula;
               Z200CpjInsDataHora = A200CpjInsDataHora;
               Z198CpjInsData = A198CpjInsData;
               Z199CpjInsHora = A199CpjInsHora;
               Z543CpjDelDataHora = A543CpjDelDataHora;
               Z544CpjDelData = A544CpjDelData;
               Z545CpjDelHora = A545CpjDelHora;
               Z546CpjDelUsuId = A546CpjDelUsuId;
               Z547CpjDelUsuNome = A547CpjDelUsuNome;
               Z170CpjNomeFan = A170CpjNomeFan;
               Z171CpjRazaoSoc = A171CpjRazaoSoc;
               Z188CpjCNPJFormat = A188CpjCNPJFormat;
               Z190CpjCapitalSoc = A190CpjCapitalSoc;
               Z201CpjInsUserID = A201CpjInsUserID;
               Z202CpjUpdData = A202CpjUpdData;
               Z203CpjUpdHora = A203CpjUpdHora;
               Z204CpjUpdDataHora = A204CpjUpdDataHora;
               Z205CpjUpdUserID = A205CpjUpdUserID;
               Z206CpjVersao = A206CpjVersao;
               Z207CpjAtivo = A207CpjAtivo;
               Z261CpjTelNum = A261CpjTelNum;
               Z262CpjTelRam = A262CpjTelRam;
               Z263CpjCelNum = A263CpjCelNum;
               Z264CpjWppNum = A264CpjWppNum;
               Z265CpjWebsite = A265CpjWebsite;
               Z266CpjEmail = A266CpjEmail;
               Z542CpjDel = A542CpjDel;
               Z365CpjTipoId = A365CpjTipoId;
               Z181CpjHolID = A181CpjHolID;
               Z169CpjPaiID = A169CpjPaiID;
            }
         }
         if ( GX_JID == -55 )
         {
            Z166CpjID = A166CpjID;
            Z187CpjCNPJ = A187CpjCNPJ;
            Z189CpjIE = A189CpjIE;
            Z176CpjMatricula = A176CpjMatricula;
            Z200CpjInsDataHora = A200CpjInsDataHora;
            Z198CpjInsData = A198CpjInsData;
            Z199CpjInsHora = A199CpjInsHora;
            Z543CpjDelDataHora = A543CpjDelDataHora;
            Z544CpjDelData = A544CpjDelData;
            Z545CpjDelHora = A545CpjDelHora;
            Z546CpjDelUsuId = A546CpjDelUsuId;
            Z547CpjDelUsuNome = A547CpjDelUsuNome;
            Z170CpjNomeFan = A170CpjNomeFan;
            Z171CpjRazaoSoc = A171CpjRazaoSoc;
            Z188CpjCNPJFormat = A188CpjCNPJFormat;
            Z190CpjCapitalSoc = A190CpjCapitalSoc;
            Z201CpjInsUserID = A201CpjInsUserID;
            Z202CpjUpdData = A202CpjUpdData;
            Z203CpjUpdHora = A203CpjUpdHora;
            Z204CpjUpdDataHora = A204CpjUpdDataHora;
            Z205CpjUpdUserID = A205CpjUpdUserID;
            Z206CpjVersao = A206CpjVersao;
            Z207CpjAtivo = A207CpjAtivo;
            Z261CpjTelNum = A261CpjTelNum;
            Z262CpjTelRam = A262CpjTelRam;
            Z263CpjCelNum = A263CpjCelNum;
            Z264CpjWppNum = A264CpjWppNum;
            Z265CpjWebsite = A265CpjWebsite;
            Z266CpjEmail = A266CpjEmail;
            Z542CpjDel = A542CpjDel;
            Z158CliID = A158CliID;
            Z365CpjTipoId = A365CpjTipoId;
            Z181CpjHolID = A181CpjHolID;
            Z169CpjPaiID = A169CpjPaiID;
            Z159CliMatricula = A159CliMatricula;
            Z160CliNomeFamiliar = A160CliNomeFamiliar;
            Z182CpjHolNomeFan = A182CpjHolNomeFan;
            Z183CpjHolRazaoSoc = A183CpjHolRazaoSoc;
            Z191CpjHolMatricula = A191CpjHolMatricula;
            Z192CpjHolCNPJ = A192CpjHolCNPJ;
            Z193CpjHolCNPJFormat = A193CpjHolCNPJFormat;
            Z172CpjPaiNomeFan = A172CpjPaiNomeFan;
            Z173CpjPaiRazaoSoc = A173CpjPaiRazaoSoc;
            Z175CpjPaiMatricula = A175CpjPaiMatricula;
            Z194CpjPaiCNPJ = A194CpjPaiCNPJ;
            Z195CpjPaiCNPJFormat = A195CpjPaiCNPJFormat;
            Z184CpjPaiTipoID = A184CpjPaiTipoID;
            Z185CpjPaiTipoSigla = A185CpjPaiTipoSigla;
            Z186CpjPaiTipoNome = A186CpjPaiTipoNome;
            Z366CpjTipoSigla = A366CpjTipoSigla;
            Z367CpjTipoNome = A367CpjTipoNome;
         }
      }

      protected void standaloneNotModal( )
      {
         GXVvCPJTIPOIDFILTRO_html0P25( ) ;
         edtCpjMatricula_Enabled = 0;
         AssignProp("", false, edtCpjMatricula_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjMatricula_Enabled), 5, 0), true);
         AV41Pgmname = "core.ClientePJ";
         AssignAttri("", false, "AV41Pgmname", AV41Pgmname);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         edtCpjMatricula_Enabled = 0;
         AssignProp("", false, edtCpjMatricula_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjMatricula_Enabled), 5, 0), true);
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
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV27Insert_CpjPaiID) )
         {
            edtCpjPaiID_Enabled = 0;
            AssignProp("", false, edtCpjPaiID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjPaiID_Enabled), 5, 0), true);
         }
         else
         {
            edtCpjPaiID_Enabled = 1;
            AssignProp("", false, edtCpjPaiID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjPaiID_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV14Insert_CpjTipoId) )
         {
            edtCpjTipoId_Enabled = 0;
            AssignProp("", false, edtCpjTipoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjTipoId_Enabled), 5, 0), true);
         }
         else
         {
            edtCpjTipoId_Enabled = 1;
            AssignProp("", false, edtCpjTipoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjTipoId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV28Insert_CpjHolID) )
         {
            A181CpjHolID = AV28Insert_CpjHolID;
            n181CpjHolID = false;
            AssignAttri("", false, "A181CpjHolID", A181CpjHolID.ToString());
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV14Insert_CpjTipoId) )
         {
            A365CpjTipoId = AV14Insert_CpjTipoId;
            AssignAttri("", false, "A365CpjTipoId", StringUtil.LTrimStr( (decimal)(A365CpjTipoId), 9, 0));
         }
         else
         {
            A365CpjTipoId = AV25ComboCpjTipoId;
            AssignAttri("", false, "A365CpjTipoId", StringUtil.LTrimStr( (decimal)(A365CpjTipoId), 9, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV27Insert_CpjPaiID) )
         {
            A169CpjPaiID = AV27Insert_CpjPaiID;
            n169CpjPaiID = false;
            AssignAttri("", false, "A169CpjPaiID", A169CpjPaiID.ToString());
         }
         else
         {
            if ( (Guid.Empty==AV30ComboCpjPaiID) )
            {
               A169CpjPaiID = Guid.Empty;
               n169CpjPaiID = false;
               AssignAttri("", false, "A169CpjPaiID", A169CpjPaiID.ToString());
               n169CpjPaiID = true;
               AssignAttri("", false, "A169CpjPaiID", A169CpjPaiID.ToString());
            }
            else
            {
               if ( ! (Guid.Empty==AV30ComboCpjPaiID) )
               {
                  A169CpjPaiID = AV30ComboCpjPaiID;
                  n169CpjPaiID = false;
                  AssignAttri("", false, "A169CpjPaiID", A169CpjPaiID.ToString());
               }
            }
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
         if ( ! (Guid.Empty==AV8CpjID) )
         {
            A166CpjID = AV8CpjID;
            AssignAttri("", false, "A166CpjID", A166CpjID.ToString());
         }
         else
         {
            if ( IsIns( )  && (Guid.Empty==A166CpjID) && ( Gx_BScreen == 0 ) )
            {
               A166CpjID = Guid.NewGuid( );
               AssignAttri("", false, "A166CpjID", A166CpjID.ToString());
            }
         }
         if ( IsIns( )  && (false==A207CpjAtivo) && ( Gx_BScreen == 0 ) )
         {
            A207CpjAtivo = true;
            AssignAttri("", false, "A207CpjAtivo", A207CpjAtivo);
         }
         if ( IsIns( )  && (0==A206CpjVersao) && ( Gx_BScreen == 0 ) )
         {
            A206CpjVersao = 1;
            AssignAttri("", false, "A206CpjVersao", StringUtil.LTrimStr( (decimal)(A206CpjVersao), 4, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T000P4 */
            pr_default.execute(2, new Object[] {A158CliID});
            A159CliMatricula = T000P4_A159CliMatricula[0];
            AssignAttri("", false, "A159CliMatricula", StringUtil.LTrimStr( (decimal)(A159CliMatricula), 12, 0));
            A160CliNomeFamiliar = T000P4_A160CliNomeFamiliar[0];
            AssignAttri("", false, "A160CliNomeFamiliar", A160CliNomeFamiliar);
            pr_default.close(2);
            /* Using cursor T000P6 */
            pr_default.execute(4, new Object[] {A158CliID, n181CpjHolID, A181CpjHolID});
            A182CpjHolNomeFan = T000P6_A182CpjHolNomeFan[0];
            A183CpjHolRazaoSoc = T000P6_A183CpjHolRazaoSoc[0];
            A191CpjHolMatricula = T000P6_A191CpjHolMatricula[0];
            A192CpjHolCNPJ = T000P6_A192CpjHolCNPJ[0];
            A193CpjHolCNPJFormat = T000P6_A193CpjHolCNPJFormat[0];
            pr_default.close(4);
            /* Using cursor T000P5 */
            pr_default.execute(3, new Object[] {A365CpjTipoId});
            A366CpjTipoSigla = T000P5_A366CpjTipoSigla[0];
            AssignAttri("", false, "A366CpjTipoSigla", A366CpjTipoSigla);
            A367CpjTipoNome = T000P5_A367CpjTipoNome[0];
            AssignAttri("", false, "A367CpjTipoNome", A367CpjTipoNome);
            pr_default.close(3);
            Combo_cpjpaiid_Visible = (bool)((A365CpjTipoId>1));
            ucCombo_cpjpaiid.SendProperty(context, "", false, Combo_cpjpaiid_Internalname, "Visible", StringUtil.BoolToStr( Combo_cpjpaiid_Visible));
            if ( ! ( ( A365CpjTipoId > 1 ) ) )
            {
               divCombo_cpjpaiid_cell_Class = "Invisible";
               AssignProp("", false, divCombo_cpjpaiid_cell_Internalname, "Class", divCombo_cpjpaiid_cell_Class, true);
            }
            else
            {
               if ( ( A365CpjTipoId > 1 ) && ! ( ( A365CpjTipoId > 2 ) ) )
               {
                  divCombo_cpjpaiid_cell_Class = "col-xs-12 DataContentCellFL ExtendedComboCell";
                  AssignProp("", false, divCombo_cpjpaiid_cell_Internalname, "Class", divCombo_cpjpaiid_cell_Class, true);
               }
               else
               {
                  if ( ( A365CpjTipoId > 1 ) && ( ( A365CpjTipoId > 2 ) ) )
                  {
                     divCombo_cpjpaiid_cell_Class = "col-xs-12 DataContentCellFL RequiredDataContentCellFL ExtendedComboCell";
                     AssignProp("", false, divCombo_cpjpaiid_cell_Internalname, "Class", divCombo_cpjpaiid_cell_Class, true);
                  }
               }
            }
            AV36CpjTipoIdFiltro = (int)((A365CpjTipoId-1));
            AssignAttri("", false, "AV36CpjTipoIdFiltro", StringUtil.LTrimStr( (decimal)(AV36CpjTipoIdFiltro), 9, 0));
            if ( A365CpjTipoId == 2 )
            {
               lblTextblockcpjpaiid_Caption = "Holding (opcional)";
               AssignProp("", false, lblTextblockcpjpaiid_Internalname, "Caption", lblTextblockcpjpaiid_Caption, true);
            }
            else
            {
               if ( A365CpjTipoId == 3 )
               {
                  lblTextblockcpjpaiid_Caption = "Empresa";
                  AssignProp("", false, lblTextblockcpjpaiid_Internalname, "Caption", lblTextblockcpjpaiid_Caption, true);
               }
            }
            /* Using cursor T000P7 */
            pr_default.execute(5, new Object[] {A158CliID, n169CpjPaiID, A169CpjPaiID});
            A172CpjPaiNomeFan = T000P7_A172CpjPaiNomeFan[0];
            A173CpjPaiRazaoSoc = T000P7_A173CpjPaiRazaoSoc[0];
            A175CpjPaiMatricula = T000P7_A175CpjPaiMatricula[0];
            A194CpjPaiCNPJ = T000P7_A194CpjPaiCNPJ[0];
            A195CpjPaiCNPJFormat = T000P7_A195CpjPaiCNPJFormat[0];
            A184CpjPaiTipoID = T000P7_A184CpjPaiTipoID[0];
            pr_default.close(5);
            /* Using cursor T000P8 */
            pr_default.execute(6, new Object[] {A184CpjPaiTipoID});
            A185CpjPaiTipoSigla = T000P8_A185CpjPaiTipoSigla[0];
            A186CpjPaiTipoNome = T000P8_A186CpjPaiTipoNome[0];
            pr_default.close(6);
         }
      }

      protected void Load0P25( )
      {
         /* Using cursor T000P9 */
         pr_default.execute(7, new Object[] {A158CliID, A166CpjID});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound25 = 1;
            A187CpjCNPJ = T000P9_A187CpjCNPJ[0];
            A189CpjIE = T000P9_A189CpjIE[0];
            AssignAttri("", false, "A189CpjIE", A189CpjIE);
            A176CpjMatricula = T000P9_A176CpjMatricula[0];
            AssignAttri("", false, "A176CpjMatricula", StringUtil.LTrimStr( (decimal)(A176CpjMatricula), 12, 0));
            A200CpjInsDataHora = T000P9_A200CpjInsDataHora[0];
            A198CpjInsData = T000P9_A198CpjInsData[0];
            A199CpjInsHora = T000P9_A199CpjInsHora[0];
            A543CpjDelDataHora = T000P9_A543CpjDelDataHora[0];
            n543CpjDelDataHora = T000P9_n543CpjDelDataHora[0];
            A544CpjDelData = T000P9_A544CpjDelData[0];
            n544CpjDelData = T000P9_n544CpjDelData[0];
            A545CpjDelHora = T000P9_A545CpjDelHora[0];
            n545CpjDelHora = T000P9_n545CpjDelHora[0];
            A546CpjDelUsuId = T000P9_A546CpjDelUsuId[0];
            n546CpjDelUsuId = T000P9_n546CpjDelUsuId[0];
            A547CpjDelUsuNome = T000P9_A547CpjDelUsuNome[0];
            n547CpjDelUsuNome = T000P9_n547CpjDelUsuNome[0];
            A159CliMatricula = T000P9_A159CliMatricula[0];
            AssignAttri("", false, "A159CliMatricula", StringUtil.LTrimStr( (decimal)(A159CliMatricula), 12, 0));
            A160CliNomeFamiliar = T000P9_A160CliNomeFamiliar[0];
            AssignAttri("", false, "A160CliNomeFamiliar", A160CliNomeFamiliar);
            A182CpjHolNomeFan = T000P9_A182CpjHolNomeFan[0];
            A183CpjHolRazaoSoc = T000P9_A183CpjHolRazaoSoc[0];
            A191CpjHolMatricula = T000P9_A191CpjHolMatricula[0];
            A192CpjHolCNPJ = T000P9_A192CpjHolCNPJ[0];
            A193CpjHolCNPJFormat = T000P9_A193CpjHolCNPJFormat[0];
            A172CpjPaiNomeFan = T000P9_A172CpjPaiNomeFan[0];
            A173CpjPaiRazaoSoc = T000P9_A173CpjPaiRazaoSoc[0];
            A175CpjPaiMatricula = T000P9_A175CpjPaiMatricula[0];
            A194CpjPaiCNPJ = T000P9_A194CpjPaiCNPJ[0];
            A195CpjPaiCNPJFormat = T000P9_A195CpjPaiCNPJFormat[0];
            A185CpjPaiTipoSigla = T000P9_A185CpjPaiTipoSigla[0];
            A186CpjPaiTipoNome = T000P9_A186CpjPaiTipoNome[0];
            A366CpjTipoSigla = T000P9_A366CpjTipoSigla[0];
            AssignAttri("", false, "A366CpjTipoSigla", A366CpjTipoSigla);
            A367CpjTipoNome = T000P9_A367CpjTipoNome[0];
            AssignAttri("", false, "A367CpjTipoNome", A367CpjTipoNome);
            A170CpjNomeFan = T000P9_A170CpjNomeFan[0];
            AssignAttri("", false, "A170CpjNomeFan", A170CpjNomeFan);
            A171CpjRazaoSoc = T000P9_A171CpjRazaoSoc[0];
            AssignAttri("", false, "A171CpjRazaoSoc", A171CpjRazaoSoc);
            A188CpjCNPJFormat = T000P9_A188CpjCNPJFormat[0];
            AssignAttri("", false, "A188CpjCNPJFormat", A188CpjCNPJFormat);
            A190CpjCapitalSoc = T000P9_A190CpjCapitalSoc[0];
            AssignAttri("", false, "A190CpjCapitalSoc", StringUtil.LTrimStr( A190CpjCapitalSoc, 16, 2));
            A201CpjInsUserID = T000P9_A201CpjInsUserID[0];
            n201CpjInsUserID = T000P9_n201CpjInsUserID[0];
            A202CpjUpdData = T000P9_A202CpjUpdData[0];
            n202CpjUpdData = T000P9_n202CpjUpdData[0];
            A203CpjUpdHora = T000P9_A203CpjUpdHora[0];
            n203CpjUpdHora = T000P9_n203CpjUpdHora[0];
            A204CpjUpdDataHora = T000P9_A204CpjUpdDataHora[0];
            n204CpjUpdDataHora = T000P9_n204CpjUpdDataHora[0];
            A205CpjUpdUserID = T000P9_A205CpjUpdUserID[0];
            n205CpjUpdUserID = T000P9_n205CpjUpdUserID[0];
            A206CpjVersao = T000P9_A206CpjVersao[0];
            A207CpjAtivo = T000P9_A207CpjAtivo[0];
            A261CpjTelNum = T000P9_A261CpjTelNum[0];
            n261CpjTelNum = T000P9_n261CpjTelNum[0];
            AssignAttri("", false, "A261CpjTelNum", A261CpjTelNum);
            A262CpjTelRam = T000P9_A262CpjTelRam[0];
            n262CpjTelRam = T000P9_n262CpjTelRam[0];
            AssignAttri("", false, "A262CpjTelRam", A262CpjTelRam);
            A263CpjCelNum = T000P9_A263CpjCelNum[0];
            n263CpjCelNum = T000P9_n263CpjCelNum[0];
            AssignAttri("", false, "A263CpjCelNum", A263CpjCelNum);
            A264CpjWppNum = T000P9_A264CpjWppNum[0];
            n264CpjWppNum = T000P9_n264CpjWppNum[0];
            AssignAttri("", false, "A264CpjWppNum", A264CpjWppNum);
            A265CpjWebsite = T000P9_A265CpjWebsite[0];
            n265CpjWebsite = T000P9_n265CpjWebsite[0];
            AssignAttri("", false, "A265CpjWebsite", A265CpjWebsite);
            A266CpjEmail = T000P9_A266CpjEmail[0];
            n266CpjEmail = T000P9_n266CpjEmail[0];
            AssignAttri("", false, "A266CpjEmail", A266CpjEmail);
            A542CpjDel = T000P9_A542CpjDel[0];
            A365CpjTipoId = T000P9_A365CpjTipoId[0];
            AssignAttri("", false, "A365CpjTipoId", StringUtil.LTrimStr( (decimal)(A365CpjTipoId), 9, 0));
            A181CpjHolID = T000P9_A181CpjHolID[0];
            n181CpjHolID = T000P9_n181CpjHolID[0];
            A169CpjPaiID = T000P9_A169CpjPaiID[0];
            n169CpjPaiID = T000P9_n169CpjPaiID[0];
            AssignAttri("", false, "A169CpjPaiID", A169CpjPaiID.ToString());
            A184CpjPaiTipoID = T000P9_A184CpjPaiTipoID[0];
            ZM0P25( -55) ;
         }
         pr_default.close(7);
         OnLoadActions0P25( ) ;
      }

      protected void OnLoadActions0P25( )
      {
         Combo_cpjpaiid_Visible = (bool)((A365CpjTipoId>1));
         ucCombo_cpjpaiid.SendProperty(context, "", false, Combo_cpjpaiid_Internalname, "Visible", StringUtil.BoolToStr( Combo_cpjpaiid_Visible));
         if ( ! ( ( A365CpjTipoId > 1 ) ) )
         {
            divCombo_cpjpaiid_cell_Class = "Invisible";
            AssignProp("", false, divCombo_cpjpaiid_cell_Internalname, "Class", divCombo_cpjpaiid_cell_Class, true);
         }
         else
         {
            if ( ( A365CpjTipoId > 1 ) && ! ( ( A365CpjTipoId > 2 ) ) )
            {
               divCombo_cpjpaiid_cell_Class = "col-xs-12 DataContentCellFL ExtendedComboCell";
               AssignProp("", false, divCombo_cpjpaiid_cell_Internalname, "Class", divCombo_cpjpaiid_cell_Class, true);
            }
            else
            {
               if ( ( A365CpjTipoId > 1 ) && ( ( A365CpjTipoId > 2 ) ) )
               {
                  divCombo_cpjpaiid_cell_Class = "col-xs-12 DataContentCellFL RequiredDataContentCellFL ExtendedComboCell";
                  AssignProp("", false, divCombo_cpjpaiid_cell_Internalname, "Class", divCombo_cpjpaiid_cell_Class, true);
               }
            }
         }
         AV36CpjTipoIdFiltro = (int)((A365CpjTipoId-1));
         AssignAttri("", false, "AV36CpjTipoIdFiltro", StringUtil.LTrimStr( (decimal)(AV36CpjTipoIdFiltro), 9, 0));
         if ( A365CpjTipoId == 2 )
         {
            lblTextblockcpjpaiid_Caption = "Holding (opcional)";
            AssignProp("", false, lblTextblockcpjpaiid_Internalname, "Caption", lblTextblockcpjpaiid_Caption, true);
         }
         else
         {
            if ( A365CpjTipoId == 3 )
            {
               lblTextblockcpjpaiid_Caption = "Empresa";
               AssignProp("", false, lblTextblockcpjpaiid_Internalname, "Caption", lblTextblockcpjpaiid_Caption, true);
            }
         }
         GXt_char2 = "";
         new prclimpanumero(context ).execute(  A188CpjCNPJFormat,  "", out  GXt_char2) ;
         A187CpjCNPJ = (long)(Math.Round(NumberUtil.Val( GXt_char2, "."), 18, MidpointRounding.ToEven));
         AssignAttri("", false, "A187CpjCNPJ", StringUtil.LTrimStr( (decimal)(A187CpjCNPJ), 14, 0));
         if ( StringUtil.StrCmp(StringUtil.Upper( StringUtil.Trim( A189CpjIE)), "ISENTA") == 0 )
         {
            A189CpjIE = "ISENTO";
            AssignAttri("", false, "A189CpjIE", A189CpjIE);
         }
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A170CpjNomeFan)) && ( Gx_BScreen == 0 ) )
         {
            A170CpjNomeFan = A160CliNomeFamiliar;
            AssignAttri("", false, "A170CpjNomeFan", A170CpjNomeFan);
         }
      }

      protected void CheckExtendedTable0P25( )
      {
         nIsDirty_25 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T000P4 */
         pr_default.execute(2, new Object[] {A158CliID});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("Não existe ''.", "ForeignKeyNotFound", 1, "CLIID");
            AnyError = 1;
            GX_FocusControl = edtCliID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A159CliMatricula = T000P4_A159CliMatricula[0];
         AssignAttri("", false, "A159CliMatricula", StringUtil.LTrimStr( (decimal)(A159CliMatricula), 12, 0));
         A160CliNomeFamiliar = T000P4_A160CliNomeFamiliar[0];
         AssignAttri("", false, "A160CliNomeFamiliar", A160CliNomeFamiliar);
         pr_default.close(2);
         /* Using cursor T000P6 */
         pr_default.execute(4, new Object[] {A158CliID, n181CpjHolID, A181CpjHolID});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (Guid.Empty==A158CliID) || (Guid.Empty==A181CpjHolID) ) )
            {
               GX_msglist.addItem("Não existe 'Cliente PJ -> Cliente PJ Ancestral'.", "ForeignKeyNotFound", 1, "CPJHOLID");
               AnyError = 1;
               GX_FocusControl = edtCliID_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A182CpjHolNomeFan = T000P6_A182CpjHolNomeFan[0];
         A183CpjHolRazaoSoc = T000P6_A183CpjHolRazaoSoc[0];
         A191CpjHolMatricula = T000P6_A191CpjHolMatricula[0];
         A192CpjHolCNPJ = T000P6_A192CpjHolCNPJ[0];
         A193CpjHolCNPJFormat = T000P6_A193CpjHolCNPJFormat[0];
         pr_default.close(4);
         /* Using cursor T000P7 */
         pr_default.execute(5, new Object[] {A158CliID, n169CpjPaiID, A169CpjPaiID});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( (Guid.Empty==A158CliID) || (Guid.Empty==A169CpjPaiID) ) )
            {
               GX_msglist.addItem("Não existe 'ClientePJ -> Cliente PJ Pai'.", "ForeignKeyNotFound", 1, "CPJPAIID");
               AnyError = 1;
               GX_FocusControl = edtCliID_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A172CpjPaiNomeFan = T000P7_A172CpjPaiNomeFan[0];
         A173CpjPaiRazaoSoc = T000P7_A173CpjPaiRazaoSoc[0];
         A175CpjPaiMatricula = T000P7_A175CpjPaiMatricula[0];
         A194CpjPaiCNPJ = T000P7_A194CpjPaiCNPJ[0];
         A195CpjPaiCNPJFormat = T000P7_A195CpjPaiCNPJFormat[0];
         A184CpjPaiTipoID = T000P7_A184CpjPaiTipoID[0];
         pr_default.close(5);
         /* Using cursor T000P8 */
         pr_default.execute(6, new Object[] {A184CpjPaiTipoID});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( (0==A184CpjPaiTipoID) ) )
            {
               GX_msglist.addItem("Não existe ''.", "ForeignKeyNotFound", 1, "CPJPAITIPOID");
               AnyError = 1;
            }
         }
         A185CpjPaiTipoSigla = T000P8_A185CpjPaiTipoSigla[0];
         A186CpjPaiTipoNome = T000P8_A186CpjPaiTipoNome[0];
         pr_default.close(6);
         if ( ( ( A365CpjTipoId > 2 ) ) && (Guid.Empty==A169CpjPaiID) )
         {
            GX_msglist.addItem("Preenchimento obrigatório", 1, "CPJTIPOID");
            AnyError = 1;
            GX_FocusControl = edtCpjTipoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T000P5 */
         pr_default.execute(3, new Object[] {A365CpjTipoId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("Não existe 'Cliente PJ -> Cliente PJ Tipo'.", "ForeignKeyNotFound", 1, "CPJTIPOID");
            AnyError = 1;
            GX_FocusControl = edtCpjTipoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A366CpjTipoSigla = T000P5_A366CpjTipoSigla[0];
         AssignAttri("", false, "A366CpjTipoSigla", A366CpjTipoSigla);
         A367CpjTipoNome = T000P5_A367CpjTipoNome[0];
         AssignAttri("", false, "A367CpjTipoNome", A367CpjTipoNome);
         pr_default.close(3);
         Combo_cpjpaiid_Visible = (bool)((A365CpjTipoId>1));
         ucCombo_cpjpaiid.SendProperty(context, "", false, Combo_cpjpaiid_Internalname, "Visible", StringUtil.BoolToStr( Combo_cpjpaiid_Visible));
         if ( ! ( ( A365CpjTipoId > 1 ) ) )
         {
            divCombo_cpjpaiid_cell_Class = "Invisible";
            AssignProp("", false, divCombo_cpjpaiid_cell_Internalname, "Class", divCombo_cpjpaiid_cell_Class, true);
         }
         else
         {
            if ( ( A365CpjTipoId > 1 ) && ! ( ( A365CpjTipoId > 2 ) ) )
            {
               divCombo_cpjpaiid_cell_Class = "col-xs-12 DataContentCellFL ExtendedComboCell";
               AssignProp("", false, divCombo_cpjpaiid_cell_Internalname, "Class", divCombo_cpjpaiid_cell_Class, true);
            }
            else
            {
               if ( ( A365CpjTipoId > 1 ) && ( ( A365CpjTipoId > 2 ) ) )
               {
                  divCombo_cpjpaiid_cell_Class = "col-xs-12 DataContentCellFL RequiredDataContentCellFL ExtendedComboCell";
                  AssignProp("", false, divCombo_cpjpaiid_cell_Internalname, "Class", divCombo_cpjpaiid_cell_Class, true);
               }
            }
         }
         AV36CpjTipoIdFiltro = (int)((A365CpjTipoId-1));
         AssignAttri("", false, "AV36CpjTipoIdFiltro", StringUtil.LTrimStr( (decimal)(AV36CpjTipoIdFiltro), 9, 0));
         if ( A365CpjTipoId == 2 )
         {
            lblTextblockcpjpaiid_Caption = "Holding (opcional)";
            AssignProp("", false, lblTextblockcpjpaiid_Internalname, "Caption", lblTextblockcpjpaiid_Caption, true);
         }
         else
         {
            if ( A365CpjTipoId == 3 )
            {
               lblTextblockcpjpaiid_Caption = "Empresa";
               AssignProp("", false, lblTextblockcpjpaiid_Internalname, "Caption", lblTextblockcpjpaiid_Caption, true);
            }
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A171CpjRazaoSoc)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Razão Social", "", "", "", "", "", "", "", ""), 1, "CPJRAZAOSOC");
            AnyError = 1;
            GX_FocusControl = edtCpjRazaoSoc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         nIsDirty_25 = 1;
         GXt_char2 = "";
         new prclimpanumero(context ).execute(  A188CpjCNPJFormat,  "", out  GXt_char2) ;
         A187CpjCNPJ = (long)(Math.Round(NumberUtil.Val( GXt_char2, "."), 18, MidpointRounding.ToEven));
         AssignAttri("", false, "A187CpjCNPJ", StringUtil.LTrimStr( (decimal)(A187CpjCNPJ), 14, 0));
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A188CpjCNPJFormat)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "CNPJ Formatado", "", "", "", "", "", "", "", ""), 1, "CPJCNPJFORMAT");
            AnyError = 1;
            GX_FocusControl = edtCpjCNPJFormat_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! new prcvalidarcnpj(context).executeUdp(  A188CpjCNPJFormat) )
         {
            GX_msglist.addItem("CNPJ inválido", 1, "CPJCNPJFORMAT");
            AnyError = 1;
            GX_FocusControl = edtCpjCNPJFormat_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( StringUtil.Trim( A189CpjIE)), "ISENTA") == 0 )
         {
            nIsDirty_25 = 1;
            A189CpjIE = "ISENTO";
            AssignAttri("", false, "A189CpjIE", A189CpjIE);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A189CpjIE)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Inscrição Estadual", "", "", "", "", "", "", "", ""), 1, "CPJIE");
            AnyError = 1;
            GX_FocusControl = edtCpjIE_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( (Convert.ToDecimal(0)==A190CpjCapitalSoc) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Capital Social", "", "", "", "", "", "", "", ""), 1, "CPJCAPITALSOC");
            AnyError = 1;
            GX_FocusControl = edtCpjCapitalSoc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( GxRegex.IsMatch(A265CpjWebsite,"^((?:[a-zA-Z]+:(//)?)?((?:(?:[a-zA-Z]([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*)(?:\\.(?:([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*))*)|(?:(\\d{1,3}\\.){3}\\d{1,3}))(?::\\d+)?(?:/([a-zA-Z0-9$\\-_@.&+!*\"'(),=;: ]|%[0-9a-fA-F]{2})+)*/?(?:[#?](?:[a-zA-Z0-9$\\-_@.&+!*\"'(),=;: /]|%[0-9a-fA-F]{2})*)?)?\\s*$") || String.IsNullOrEmpty(StringUtil.RTrim( A265CpjWebsite)) ) )
         {
            GX_msglist.addItem("O valor de Website não coincide com o padrão especificado", "OutOfRange", 1, "CPJWEBSITE");
            AnyError = 1;
            GX_FocusControl = edtCpjWebsite_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( GxRegex.IsMatch(A266CpjEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") || String.IsNullOrEmpty(StringUtil.RTrim( A266CpjEmail)) ) )
         {
            GX_msglist.addItem("O valor de E-mail não coincide com o padrão especificado", "OutOfRange", 1, "CPJEMAIL");
            AnyError = 1;
            GX_FocusControl = edtCpjEmail_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A170CpjNomeFan)) && ( Gx_BScreen == 0 ) )
         {
            nIsDirty_25 = 1;
            A170CpjNomeFan = A160CliNomeFamiliar;
            AssignAttri("", false, "A170CpjNomeFan", A170CpjNomeFan);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A170CpjNomeFan)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Nome Fantasia", "", "", "", "", "", "", "", ""), 1, "CPJNOMEFAN");
            AnyError = 1;
            GX_FocusControl = edtCpjNomeFan_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0P25( )
      {
         pr_default.close(2);
         pr_default.close(4);
         pr_default.close(5);
         pr_default.close(6);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_56( Guid A158CliID )
      {
         /* Using cursor T000P10 */
         pr_default.execute(8, new Object[] {A158CliID});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("Não existe ''.", "ForeignKeyNotFound", 1, "CLIID");
            AnyError = 1;
            GX_FocusControl = edtCliID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A159CliMatricula = T000P10_A159CliMatricula[0];
         AssignAttri("", false, "A159CliMatricula", StringUtil.LTrimStr( (decimal)(A159CliMatricula), 12, 0));
         A160CliNomeFamiliar = T000P10_A160CliNomeFamiliar[0];
         AssignAttri("", false, "A160CliNomeFamiliar", A160CliNomeFamiliar);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A159CliMatricula), 12, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( A160CliNomeFamiliar)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void gxLoad_58( Guid A158CliID ,
                                Guid A181CpjHolID )
      {
         /* Using cursor T000P11 */
         pr_default.execute(9, new Object[] {A158CliID, n181CpjHolID, A181CpjHolID});
         if ( (pr_default.getStatus(9) == 101) )
         {
            if ( ! ( (Guid.Empty==A158CliID) || (Guid.Empty==A181CpjHolID) ) )
            {
               GX_msglist.addItem("Não existe 'Cliente PJ -> Cliente PJ Ancestral'.", "ForeignKeyNotFound", 1, "CPJHOLID");
               AnyError = 1;
               GX_FocusControl = edtCliID_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A182CpjHolNomeFan = T000P11_A182CpjHolNomeFan[0];
         A183CpjHolRazaoSoc = T000P11_A183CpjHolRazaoSoc[0];
         A191CpjHolMatricula = T000P11_A191CpjHolMatricula[0];
         A192CpjHolCNPJ = T000P11_A192CpjHolCNPJ[0];
         A193CpjHolCNPJFormat = T000P11_A193CpjHolCNPJFormat[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A182CpjHolNomeFan)+"\""+","+"\""+GXUtil.EncodeJSConstant( A183CpjHolRazaoSoc)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A191CpjHolMatricula), 12, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A192CpjHolCNPJ), 14, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( A193CpjHolCNPJFormat)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(9) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(9);
      }

      protected void gxLoad_59( Guid A158CliID ,
                                Guid A169CpjPaiID )
      {
         /* Using cursor T000P12 */
         pr_default.execute(10, new Object[] {A158CliID, n169CpjPaiID, A169CpjPaiID});
         if ( (pr_default.getStatus(10) == 101) )
         {
            if ( ! ( (Guid.Empty==A158CliID) || (Guid.Empty==A169CpjPaiID) ) )
            {
               GX_msglist.addItem("Não existe 'ClientePJ -> Cliente PJ Pai'.", "ForeignKeyNotFound", 1, "CPJPAIID");
               AnyError = 1;
               GX_FocusControl = edtCliID_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A172CpjPaiNomeFan = T000P12_A172CpjPaiNomeFan[0];
         A173CpjPaiRazaoSoc = T000P12_A173CpjPaiRazaoSoc[0];
         A175CpjPaiMatricula = T000P12_A175CpjPaiMatricula[0];
         A194CpjPaiCNPJ = T000P12_A194CpjPaiCNPJ[0];
         A195CpjPaiCNPJFormat = T000P12_A195CpjPaiCNPJFormat[0];
         A184CpjPaiTipoID = T000P12_A184CpjPaiTipoID[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A172CpjPaiNomeFan)+"\""+","+"\""+GXUtil.EncodeJSConstant( A173CpjPaiRazaoSoc)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A175CpjPaiMatricula), 12, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A194CpjPaiCNPJ), 14, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( A195CpjPaiCNPJFormat)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A184CpjPaiTipoID), 9, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(10) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(10);
      }

      protected void gxLoad_60( int A184CpjPaiTipoID )
      {
         /* Using cursor T000P13 */
         pr_default.execute(11, new Object[] {A184CpjPaiTipoID});
         if ( (pr_default.getStatus(11) == 101) )
         {
            if ( ! ( (0==A184CpjPaiTipoID) ) )
            {
               GX_msglist.addItem("Não existe ''.", "ForeignKeyNotFound", 1, "CPJPAITIPOID");
               AnyError = 1;
            }
         }
         A185CpjPaiTipoSigla = T000P13_A185CpjPaiTipoSigla[0];
         A186CpjPaiTipoNome = T000P13_A186CpjPaiTipoNome[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A185CpjPaiTipoSigla)+"\""+","+"\""+GXUtil.EncodeJSConstant( A186CpjPaiTipoNome)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(11) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(11);
      }

      protected void gxLoad_57( int A365CpjTipoId )
      {
         /* Using cursor T000P14 */
         pr_default.execute(12, new Object[] {A365CpjTipoId});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem("Não existe 'Cliente PJ -> Cliente PJ Tipo'.", "ForeignKeyNotFound", 1, "CPJTIPOID");
            AnyError = 1;
            GX_FocusControl = edtCpjTipoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A366CpjTipoSigla = T000P14_A366CpjTipoSigla[0];
         AssignAttri("", false, "A366CpjTipoSigla", A366CpjTipoSigla);
         A367CpjTipoNome = T000P14_A367CpjTipoNome[0];
         AssignAttri("", false, "A367CpjTipoNome", A367CpjTipoNome);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A366CpjTipoSigla)+"\""+","+"\""+GXUtil.EncodeJSConstant( A367CpjTipoNome)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(12) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(12);
      }

      protected void GetKey0P25( )
      {
         /* Using cursor T000P15 */
         pr_default.execute(13, new Object[] {A158CliID, A166CpjID});
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound25 = 1;
         }
         else
         {
            RcdFound25 = 0;
         }
         pr_default.close(13);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000P3 */
         pr_default.execute(1, new Object[] {A158CliID, A166CpjID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0P25( 55) ;
            RcdFound25 = 1;
            A166CpjID = T000P3_A166CpjID[0];
            AssignAttri("", false, "A166CpjID", A166CpjID.ToString());
            A187CpjCNPJ = T000P3_A187CpjCNPJ[0];
            A189CpjIE = T000P3_A189CpjIE[0];
            AssignAttri("", false, "A189CpjIE", A189CpjIE);
            A176CpjMatricula = T000P3_A176CpjMatricula[0];
            AssignAttri("", false, "A176CpjMatricula", StringUtil.LTrimStr( (decimal)(A176CpjMatricula), 12, 0));
            A200CpjInsDataHora = T000P3_A200CpjInsDataHora[0];
            A198CpjInsData = T000P3_A198CpjInsData[0];
            A199CpjInsHora = T000P3_A199CpjInsHora[0];
            A543CpjDelDataHora = T000P3_A543CpjDelDataHora[0];
            n543CpjDelDataHora = T000P3_n543CpjDelDataHora[0];
            A544CpjDelData = T000P3_A544CpjDelData[0];
            n544CpjDelData = T000P3_n544CpjDelData[0];
            A545CpjDelHora = T000P3_A545CpjDelHora[0];
            n545CpjDelHora = T000P3_n545CpjDelHora[0];
            A546CpjDelUsuId = T000P3_A546CpjDelUsuId[0];
            n546CpjDelUsuId = T000P3_n546CpjDelUsuId[0];
            A547CpjDelUsuNome = T000P3_A547CpjDelUsuNome[0];
            n547CpjDelUsuNome = T000P3_n547CpjDelUsuNome[0];
            A170CpjNomeFan = T000P3_A170CpjNomeFan[0];
            AssignAttri("", false, "A170CpjNomeFan", A170CpjNomeFan);
            A171CpjRazaoSoc = T000P3_A171CpjRazaoSoc[0];
            AssignAttri("", false, "A171CpjRazaoSoc", A171CpjRazaoSoc);
            A188CpjCNPJFormat = T000P3_A188CpjCNPJFormat[0];
            AssignAttri("", false, "A188CpjCNPJFormat", A188CpjCNPJFormat);
            A190CpjCapitalSoc = T000P3_A190CpjCapitalSoc[0];
            AssignAttri("", false, "A190CpjCapitalSoc", StringUtil.LTrimStr( A190CpjCapitalSoc, 16, 2));
            A201CpjInsUserID = T000P3_A201CpjInsUserID[0];
            n201CpjInsUserID = T000P3_n201CpjInsUserID[0];
            A202CpjUpdData = T000P3_A202CpjUpdData[0];
            n202CpjUpdData = T000P3_n202CpjUpdData[0];
            A203CpjUpdHora = T000P3_A203CpjUpdHora[0];
            n203CpjUpdHora = T000P3_n203CpjUpdHora[0];
            A204CpjUpdDataHora = T000P3_A204CpjUpdDataHora[0];
            n204CpjUpdDataHora = T000P3_n204CpjUpdDataHora[0];
            A205CpjUpdUserID = T000P3_A205CpjUpdUserID[0];
            n205CpjUpdUserID = T000P3_n205CpjUpdUserID[0];
            A206CpjVersao = T000P3_A206CpjVersao[0];
            A207CpjAtivo = T000P3_A207CpjAtivo[0];
            A261CpjTelNum = T000P3_A261CpjTelNum[0];
            n261CpjTelNum = T000P3_n261CpjTelNum[0];
            AssignAttri("", false, "A261CpjTelNum", A261CpjTelNum);
            A262CpjTelRam = T000P3_A262CpjTelRam[0];
            n262CpjTelRam = T000P3_n262CpjTelRam[0];
            AssignAttri("", false, "A262CpjTelRam", A262CpjTelRam);
            A263CpjCelNum = T000P3_A263CpjCelNum[0];
            n263CpjCelNum = T000P3_n263CpjCelNum[0];
            AssignAttri("", false, "A263CpjCelNum", A263CpjCelNum);
            A264CpjWppNum = T000P3_A264CpjWppNum[0];
            n264CpjWppNum = T000P3_n264CpjWppNum[0];
            AssignAttri("", false, "A264CpjWppNum", A264CpjWppNum);
            A265CpjWebsite = T000P3_A265CpjWebsite[0];
            n265CpjWebsite = T000P3_n265CpjWebsite[0];
            AssignAttri("", false, "A265CpjWebsite", A265CpjWebsite);
            A266CpjEmail = T000P3_A266CpjEmail[0];
            n266CpjEmail = T000P3_n266CpjEmail[0];
            AssignAttri("", false, "A266CpjEmail", A266CpjEmail);
            A542CpjDel = T000P3_A542CpjDel[0];
            A158CliID = T000P3_A158CliID[0];
            AssignAttri("", false, "A158CliID", A158CliID.ToString());
            A365CpjTipoId = T000P3_A365CpjTipoId[0];
            AssignAttri("", false, "A365CpjTipoId", StringUtil.LTrimStr( (decimal)(A365CpjTipoId), 9, 0));
            A181CpjHolID = T000P3_A181CpjHolID[0];
            n181CpjHolID = T000P3_n181CpjHolID[0];
            A169CpjPaiID = T000P3_A169CpjPaiID[0];
            n169CpjPaiID = T000P3_n169CpjPaiID[0];
            AssignAttri("", false, "A169CpjPaiID", A169CpjPaiID.ToString());
            O542CpjDel = A542CpjDel;
            AssignAttri("", false, "A542CpjDel", A542CpjDel);
            Z158CliID = A158CliID;
            Z166CpjID = A166CpjID;
            sMode25 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0P25( ) ;
            if ( AnyError == 1 )
            {
               RcdFound25 = 0;
               InitializeNonKey0P25( ) ;
            }
            Gx_mode = sMode25;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound25 = 0;
            InitializeNonKey0P25( ) ;
            sMode25 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode25;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0P25( ) ;
         if ( RcdFound25 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound25 = 0;
         /* Using cursor T000P16 */
         pr_default.execute(14, new Object[] {A158CliID, A166CpjID});
         if ( (pr_default.getStatus(14) != 101) )
         {
            while ( (pr_default.getStatus(14) != 101) && ( ( GuidUtil.Compare(T000P16_A158CliID[0], A158CliID, 0) < 0 ) || ( T000P16_A158CliID[0] == A158CliID ) && ( GuidUtil.Compare(T000P16_A166CpjID[0], A166CpjID, 0) < 0 ) ) )
            {
               pr_default.readNext(14);
            }
            if ( (pr_default.getStatus(14) != 101) && ( ( GuidUtil.Compare(T000P16_A158CliID[0], A158CliID, 0) > 0 ) || ( T000P16_A158CliID[0] == A158CliID ) && ( GuidUtil.Compare(T000P16_A166CpjID[0], A166CpjID, 0) > 0 ) ) )
            {
               A158CliID = T000P16_A158CliID[0];
               AssignAttri("", false, "A158CliID", A158CliID.ToString());
               A166CpjID = T000P16_A166CpjID[0];
               AssignAttri("", false, "A166CpjID", A166CpjID.ToString());
               RcdFound25 = 1;
            }
         }
         pr_default.close(14);
      }

      protected void move_previous( )
      {
         RcdFound25 = 0;
         /* Using cursor T000P17 */
         pr_default.execute(15, new Object[] {A158CliID, A166CpjID});
         if ( (pr_default.getStatus(15) != 101) )
         {
            while ( (pr_default.getStatus(15) != 101) && ( ( GuidUtil.Compare(T000P17_A158CliID[0], A158CliID, 0) > 0 ) || ( T000P17_A158CliID[0] == A158CliID ) && ( GuidUtil.Compare(T000P17_A166CpjID[0], A166CpjID, 0) > 0 ) ) )
            {
               pr_default.readNext(15);
            }
            if ( (pr_default.getStatus(15) != 101) && ( ( GuidUtil.Compare(T000P17_A158CliID[0], A158CliID, 0) < 0 ) || ( T000P17_A158CliID[0] == A158CliID ) && ( GuidUtil.Compare(T000P17_A166CpjID[0], A166CpjID, 0) < 0 ) ) )
            {
               A158CliID = T000P17_A158CliID[0];
               AssignAttri("", false, "A158CliID", A158CliID.ToString());
               A166CpjID = T000P17_A166CpjID[0];
               AssignAttri("", false, "A166CpjID", A166CpjID.ToString());
               RcdFound25 = 1;
            }
         }
         pr_default.close(15);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0P25( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtCpjTipoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0P25( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound25 == 1 )
            {
               if ( ( A158CliID != Z158CliID ) || ( A166CpjID != Z166CpjID ) )
               {
                  A158CliID = Z158CliID;
                  AssignAttri("", false, "A158CliID", A158CliID.ToString());
                  A166CpjID = Z166CpjID;
                  AssignAttri("", false, "A166CpjID", A166CpjID.ToString());
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CLIID");
                  AnyError = 1;
                  GX_FocusControl = edtCliID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtCpjTipoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0P25( ) ;
                  GX_FocusControl = edtCpjTipoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( A158CliID != Z158CliID ) || ( A166CpjID != Z166CpjID ) )
               {
                  /* Insert record */
                  GX_FocusControl = edtCpjTipoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0P25( ) ;
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
                     GX_FocusControl = edtCpjTipoId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0P25( ) ;
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
         if ( ( A158CliID != Z158CliID ) || ( A166CpjID != Z166CpjID ) )
         {
            A158CliID = Z158CliID;
            AssignAttri("", false, "A158CliID", A158CliID.ToString());
            A166CpjID = Z166CpjID;
            AssignAttri("", false, "A166CpjID", A166CpjID.ToString());
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CLIID");
            AnyError = 1;
            GX_FocusControl = edtCliID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtCpjTipoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0P25( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000P2 */
            pr_default.execute(0, new Object[] {A158CliID, A166CpjID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_clientepj"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z187CpjCNPJ != T000P2_A187CpjCNPJ[0] ) || ( StringUtil.StrCmp(Z189CpjIE, T000P2_A189CpjIE[0]) != 0 ) || ( Z176CpjMatricula != T000P2_A176CpjMatricula[0] ) || ( Z200CpjInsDataHora != T000P2_A200CpjInsDataHora[0] ) || ( DateTimeUtil.ResetTime ( Z198CpjInsData ) != DateTimeUtil.ResetTime ( T000P2_A198CpjInsData[0] ) ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z199CpjInsHora != T000P2_A199CpjInsHora[0] ) || ( Z543CpjDelDataHora != T000P2_A543CpjDelDataHora[0] ) || ( Z544CpjDelData != T000P2_A544CpjDelData[0] ) || ( Z545CpjDelHora != T000P2_A545CpjDelHora[0] ) || ( StringUtil.StrCmp(Z546CpjDelUsuId, T000P2_A546CpjDelUsuId[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z547CpjDelUsuNome, T000P2_A547CpjDelUsuNome[0]) != 0 ) || ( StringUtil.StrCmp(Z170CpjNomeFan, T000P2_A170CpjNomeFan[0]) != 0 ) || ( StringUtil.StrCmp(Z171CpjRazaoSoc, T000P2_A171CpjRazaoSoc[0]) != 0 ) || ( StringUtil.StrCmp(Z188CpjCNPJFormat, T000P2_A188CpjCNPJFormat[0]) != 0 ) || ( Z190CpjCapitalSoc != T000P2_A190CpjCapitalSoc[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z201CpjInsUserID, T000P2_A201CpjInsUserID[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z202CpjUpdData ) != DateTimeUtil.ResetTime ( T000P2_A202CpjUpdData[0] ) ) || ( Z203CpjUpdHora != T000P2_A203CpjUpdHora[0] ) || ( Z204CpjUpdDataHora != T000P2_A204CpjUpdDataHora[0] ) || ( StringUtil.StrCmp(Z205CpjUpdUserID, T000P2_A205CpjUpdUserID[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z206CpjVersao != T000P2_A206CpjVersao[0] ) || ( Z207CpjAtivo != T000P2_A207CpjAtivo[0] ) || ( StringUtil.StrCmp(Z261CpjTelNum, T000P2_A261CpjTelNum[0]) != 0 ) || ( StringUtil.StrCmp(Z262CpjTelRam, T000P2_A262CpjTelRam[0]) != 0 ) || ( StringUtil.StrCmp(Z263CpjCelNum, T000P2_A263CpjCelNum[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z264CpjWppNum, T000P2_A264CpjWppNum[0]) != 0 ) || ( StringUtil.StrCmp(Z265CpjWebsite, T000P2_A265CpjWebsite[0]) != 0 ) || ( StringUtil.StrCmp(Z266CpjEmail, T000P2_A266CpjEmail[0]) != 0 ) || ( Z542CpjDel != T000P2_A542CpjDel[0] ) || ( Z365CpjTipoId != T000P2_A365CpjTipoId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z181CpjHolID != T000P2_A181CpjHolID[0] ) || ( Z169CpjPaiID != T000P2_A169CpjPaiID[0] ) )
            {
               if ( Z187CpjCNPJ != T000P2_A187CpjCNPJ[0] )
               {
                  GXUtil.WriteLog("core.clientepj:[seudo value changed for attri]"+"CpjCNPJ");
                  GXUtil.WriteLogRaw("Old: ",Z187CpjCNPJ);
                  GXUtil.WriteLogRaw("Current: ",T000P2_A187CpjCNPJ[0]);
               }
               if ( StringUtil.StrCmp(Z189CpjIE, T000P2_A189CpjIE[0]) != 0 )
               {
                  GXUtil.WriteLog("core.clientepj:[seudo value changed for attri]"+"CpjIE");
                  GXUtil.WriteLogRaw("Old: ",Z189CpjIE);
                  GXUtil.WriteLogRaw("Current: ",T000P2_A189CpjIE[0]);
               }
               if ( Z176CpjMatricula != T000P2_A176CpjMatricula[0] )
               {
                  GXUtil.WriteLog("core.clientepj:[seudo value changed for attri]"+"CpjMatricula");
                  GXUtil.WriteLogRaw("Old: ",Z176CpjMatricula);
                  GXUtil.WriteLogRaw("Current: ",T000P2_A176CpjMatricula[0]);
               }
               if ( Z200CpjInsDataHora != T000P2_A200CpjInsDataHora[0] )
               {
                  GXUtil.WriteLog("core.clientepj:[seudo value changed for attri]"+"CpjInsDataHora");
                  GXUtil.WriteLogRaw("Old: ",Z200CpjInsDataHora);
                  GXUtil.WriteLogRaw("Current: ",T000P2_A200CpjInsDataHora[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z198CpjInsData ) != DateTimeUtil.ResetTime ( T000P2_A198CpjInsData[0] ) )
               {
                  GXUtil.WriteLog("core.clientepj:[seudo value changed for attri]"+"CpjInsData");
                  GXUtil.WriteLogRaw("Old: ",Z198CpjInsData);
                  GXUtil.WriteLogRaw("Current: ",T000P2_A198CpjInsData[0]);
               }
               if ( Z199CpjInsHora != T000P2_A199CpjInsHora[0] )
               {
                  GXUtil.WriteLog("core.clientepj:[seudo value changed for attri]"+"CpjInsHora");
                  GXUtil.WriteLogRaw("Old: ",Z199CpjInsHora);
                  GXUtil.WriteLogRaw("Current: ",T000P2_A199CpjInsHora[0]);
               }
               if ( Z543CpjDelDataHora != T000P2_A543CpjDelDataHora[0] )
               {
                  GXUtil.WriteLog("core.clientepj:[seudo value changed for attri]"+"CpjDelDataHora");
                  GXUtil.WriteLogRaw("Old: ",Z543CpjDelDataHora);
                  GXUtil.WriteLogRaw("Current: ",T000P2_A543CpjDelDataHora[0]);
               }
               if ( Z544CpjDelData != T000P2_A544CpjDelData[0] )
               {
                  GXUtil.WriteLog("core.clientepj:[seudo value changed for attri]"+"CpjDelData");
                  GXUtil.WriteLogRaw("Old: ",Z544CpjDelData);
                  GXUtil.WriteLogRaw("Current: ",T000P2_A544CpjDelData[0]);
               }
               if ( Z545CpjDelHora != T000P2_A545CpjDelHora[0] )
               {
                  GXUtil.WriteLog("core.clientepj:[seudo value changed for attri]"+"CpjDelHora");
                  GXUtil.WriteLogRaw("Old: ",Z545CpjDelHora);
                  GXUtil.WriteLogRaw("Current: ",T000P2_A545CpjDelHora[0]);
               }
               if ( StringUtil.StrCmp(Z546CpjDelUsuId, T000P2_A546CpjDelUsuId[0]) != 0 )
               {
                  GXUtil.WriteLog("core.clientepj:[seudo value changed for attri]"+"CpjDelUsuId");
                  GXUtil.WriteLogRaw("Old: ",Z546CpjDelUsuId);
                  GXUtil.WriteLogRaw("Current: ",T000P2_A546CpjDelUsuId[0]);
               }
               if ( StringUtil.StrCmp(Z547CpjDelUsuNome, T000P2_A547CpjDelUsuNome[0]) != 0 )
               {
                  GXUtil.WriteLog("core.clientepj:[seudo value changed for attri]"+"CpjDelUsuNome");
                  GXUtil.WriteLogRaw("Old: ",Z547CpjDelUsuNome);
                  GXUtil.WriteLogRaw("Current: ",T000P2_A547CpjDelUsuNome[0]);
               }
               if ( StringUtil.StrCmp(Z170CpjNomeFan, T000P2_A170CpjNomeFan[0]) != 0 )
               {
                  GXUtil.WriteLog("core.clientepj:[seudo value changed for attri]"+"CpjNomeFan");
                  GXUtil.WriteLogRaw("Old: ",Z170CpjNomeFan);
                  GXUtil.WriteLogRaw("Current: ",T000P2_A170CpjNomeFan[0]);
               }
               if ( StringUtil.StrCmp(Z171CpjRazaoSoc, T000P2_A171CpjRazaoSoc[0]) != 0 )
               {
                  GXUtil.WriteLog("core.clientepj:[seudo value changed for attri]"+"CpjRazaoSoc");
                  GXUtil.WriteLogRaw("Old: ",Z171CpjRazaoSoc);
                  GXUtil.WriteLogRaw("Current: ",T000P2_A171CpjRazaoSoc[0]);
               }
               if ( StringUtil.StrCmp(Z188CpjCNPJFormat, T000P2_A188CpjCNPJFormat[0]) != 0 )
               {
                  GXUtil.WriteLog("core.clientepj:[seudo value changed for attri]"+"CpjCNPJFormat");
                  GXUtil.WriteLogRaw("Old: ",Z188CpjCNPJFormat);
                  GXUtil.WriteLogRaw("Current: ",T000P2_A188CpjCNPJFormat[0]);
               }
               if ( Z190CpjCapitalSoc != T000P2_A190CpjCapitalSoc[0] )
               {
                  GXUtil.WriteLog("core.clientepj:[seudo value changed for attri]"+"CpjCapitalSoc");
                  GXUtil.WriteLogRaw("Old: ",Z190CpjCapitalSoc);
                  GXUtil.WriteLogRaw("Current: ",T000P2_A190CpjCapitalSoc[0]);
               }
               if ( StringUtil.StrCmp(Z201CpjInsUserID, T000P2_A201CpjInsUserID[0]) != 0 )
               {
                  GXUtil.WriteLog("core.clientepj:[seudo value changed for attri]"+"CpjInsUserID");
                  GXUtil.WriteLogRaw("Old: ",Z201CpjInsUserID);
                  GXUtil.WriteLogRaw("Current: ",T000P2_A201CpjInsUserID[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z202CpjUpdData ) != DateTimeUtil.ResetTime ( T000P2_A202CpjUpdData[0] ) )
               {
                  GXUtil.WriteLog("core.clientepj:[seudo value changed for attri]"+"CpjUpdData");
                  GXUtil.WriteLogRaw("Old: ",Z202CpjUpdData);
                  GXUtil.WriteLogRaw("Current: ",T000P2_A202CpjUpdData[0]);
               }
               if ( Z203CpjUpdHora != T000P2_A203CpjUpdHora[0] )
               {
                  GXUtil.WriteLog("core.clientepj:[seudo value changed for attri]"+"CpjUpdHora");
                  GXUtil.WriteLogRaw("Old: ",Z203CpjUpdHora);
                  GXUtil.WriteLogRaw("Current: ",T000P2_A203CpjUpdHora[0]);
               }
               if ( Z204CpjUpdDataHora != T000P2_A204CpjUpdDataHora[0] )
               {
                  GXUtil.WriteLog("core.clientepj:[seudo value changed for attri]"+"CpjUpdDataHora");
                  GXUtil.WriteLogRaw("Old: ",Z204CpjUpdDataHora);
                  GXUtil.WriteLogRaw("Current: ",T000P2_A204CpjUpdDataHora[0]);
               }
               if ( StringUtil.StrCmp(Z205CpjUpdUserID, T000P2_A205CpjUpdUserID[0]) != 0 )
               {
                  GXUtil.WriteLog("core.clientepj:[seudo value changed for attri]"+"CpjUpdUserID");
                  GXUtil.WriteLogRaw("Old: ",Z205CpjUpdUserID);
                  GXUtil.WriteLogRaw("Current: ",T000P2_A205CpjUpdUserID[0]);
               }
               if ( Z206CpjVersao != T000P2_A206CpjVersao[0] )
               {
                  GXUtil.WriteLog("core.clientepj:[seudo value changed for attri]"+"CpjVersao");
                  GXUtil.WriteLogRaw("Old: ",Z206CpjVersao);
                  GXUtil.WriteLogRaw("Current: ",T000P2_A206CpjVersao[0]);
               }
               if ( Z207CpjAtivo != T000P2_A207CpjAtivo[0] )
               {
                  GXUtil.WriteLog("core.clientepj:[seudo value changed for attri]"+"CpjAtivo");
                  GXUtil.WriteLogRaw("Old: ",Z207CpjAtivo);
                  GXUtil.WriteLogRaw("Current: ",T000P2_A207CpjAtivo[0]);
               }
               if ( StringUtil.StrCmp(Z261CpjTelNum, T000P2_A261CpjTelNum[0]) != 0 )
               {
                  GXUtil.WriteLog("core.clientepj:[seudo value changed for attri]"+"CpjTelNum");
                  GXUtil.WriteLogRaw("Old: ",Z261CpjTelNum);
                  GXUtil.WriteLogRaw("Current: ",T000P2_A261CpjTelNum[0]);
               }
               if ( StringUtil.StrCmp(Z262CpjTelRam, T000P2_A262CpjTelRam[0]) != 0 )
               {
                  GXUtil.WriteLog("core.clientepj:[seudo value changed for attri]"+"CpjTelRam");
                  GXUtil.WriteLogRaw("Old: ",Z262CpjTelRam);
                  GXUtil.WriteLogRaw("Current: ",T000P2_A262CpjTelRam[0]);
               }
               if ( StringUtil.StrCmp(Z263CpjCelNum, T000P2_A263CpjCelNum[0]) != 0 )
               {
                  GXUtil.WriteLog("core.clientepj:[seudo value changed for attri]"+"CpjCelNum");
                  GXUtil.WriteLogRaw("Old: ",Z263CpjCelNum);
                  GXUtil.WriteLogRaw("Current: ",T000P2_A263CpjCelNum[0]);
               }
               if ( StringUtil.StrCmp(Z264CpjWppNum, T000P2_A264CpjWppNum[0]) != 0 )
               {
                  GXUtil.WriteLog("core.clientepj:[seudo value changed for attri]"+"CpjWppNum");
                  GXUtil.WriteLogRaw("Old: ",Z264CpjWppNum);
                  GXUtil.WriteLogRaw("Current: ",T000P2_A264CpjWppNum[0]);
               }
               if ( StringUtil.StrCmp(Z265CpjWebsite, T000P2_A265CpjWebsite[0]) != 0 )
               {
                  GXUtil.WriteLog("core.clientepj:[seudo value changed for attri]"+"CpjWebsite");
                  GXUtil.WriteLogRaw("Old: ",Z265CpjWebsite);
                  GXUtil.WriteLogRaw("Current: ",T000P2_A265CpjWebsite[0]);
               }
               if ( StringUtil.StrCmp(Z266CpjEmail, T000P2_A266CpjEmail[0]) != 0 )
               {
                  GXUtil.WriteLog("core.clientepj:[seudo value changed for attri]"+"CpjEmail");
                  GXUtil.WriteLogRaw("Old: ",Z266CpjEmail);
                  GXUtil.WriteLogRaw("Current: ",T000P2_A266CpjEmail[0]);
               }
               if ( Z542CpjDel != T000P2_A542CpjDel[0] )
               {
                  GXUtil.WriteLog("core.clientepj:[seudo value changed for attri]"+"CpjDel");
                  GXUtil.WriteLogRaw("Old: ",Z542CpjDel);
                  GXUtil.WriteLogRaw("Current: ",T000P2_A542CpjDel[0]);
               }
               if ( Z365CpjTipoId != T000P2_A365CpjTipoId[0] )
               {
                  GXUtil.WriteLog("core.clientepj:[seudo value changed for attri]"+"CpjTipoId");
                  GXUtil.WriteLogRaw("Old: ",Z365CpjTipoId);
                  GXUtil.WriteLogRaw("Current: ",T000P2_A365CpjTipoId[0]);
               }
               if ( Z181CpjHolID != T000P2_A181CpjHolID[0] )
               {
                  GXUtil.WriteLog("core.clientepj:[seudo value changed for attri]"+"CpjHolID");
                  GXUtil.WriteLogRaw("Old: ",Z181CpjHolID);
                  GXUtil.WriteLogRaw("Current: ",T000P2_A181CpjHolID[0]);
               }
               if ( Z169CpjPaiID != T000P2_A169CpjPaiID[0] )
               {
                  GXUtil.WriteLog("core.clientepj:[seudo value changed for attri]"+"CpjPaiID");
                  GXUtil.WriteLogRaw("Old: ",Z169CpjPaiID);
                  GXUtil.WriteLogRaw("Current: ",T000P2_A169CpjPaiID[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"tb_clientepj"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0P25( )
      {
         if ( ! IsAuthorized("clientepj_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0P25( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0P25( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0P25( 0) ;
            CheckOptimisticConcurrency0P25( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0P25( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0P25( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000P18 */
                     pr_default.execute(16, new Object[] {A166CpjID, A187CpjCNPJ, A189CpjIE, A176CpjMatricula, A200CpjInsDataHora, A198CpjInsData, A199CpjInsHora, n543CpjDelDataHora, A543CpjDelDataHora, n544CpjDelData, A544CpjDelData, n545CpjDelHora, A545CpjDelHora, n546CpjDelUsuId, A546CpjDelUsuId, n547CpjDelUsuNome, A547CpjDelUsuNome, A170CpjNomeFan, A171CpjRazaoSoc, A188CpjCNPJFormat, A190CpjCapitalSoc, n201CpjInsUserID, A201CpjInsUserID, n202CpjUpdData, A202CpjUpdData, n203CpjUpdHora, A203CpjUpdHora, n204CpjUpdDataHora, A204CpjUpdDataHora, n205CpjUpdUserID, A205CpjUpdUserID, A206CpjVersao, A207CpjAtivo, n261CpjTelNum, A261CpjTelNum, n262CpjTelRam, A262CpjTelRam, n263CpjCelNum, A263CpjCelNum, n264CpjWppNum, A264CpjWppNum, n265CpjWebsite, A265CpjWebsite, n266CpjEmail, A266CpjEmail, A542CpjDel, A158CliID, A365CpjTipoId, n181CpjHolID, A181CpjHolID, n169CpjPaiID, A169CpjPaiID});
                     pr_default.close(16);
                     pr_default.SmartCacheProvider.SetUpdated("tb_clientepj");
                     if ( (pr_default.getStatus(16) == 1) )
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
                           ResetCaption0P0( ) ;
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
               Load0P25( ) ;
            }
            EndLevel0P25( ) ;
         }
         CloseExtendedTableCursors0P25( ) ;
      }

      protected void Update0P25( )
      {
         if ( ! IsAuthorized("clientepj_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0P25( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0P25( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0P25( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0P25( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0P25( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000P19 */
                     pr_default.execute(17, new Object[] {A187CpjCNPJ, A189CpjIE, A176CpjMatricula, A200CpjInsDataHora, A198CpjInsData, A199CpjInsHora, n543CpjDelDataHora, A543CpjDelDataHora, n544CpjDelData, A544CpjDelData, n545CpjDelHora, A545CpjDelHora, n546CpjDelUsuId, A546CpjDelUsuId, n547CpjDelUsuNome, A547CpjDelUsuNome, A170CpjNomeFan, A171CpjRazaoSoc, A188CpjCNPJFormat, A190CpjCapitalSoc, n201CpjInsUserID, A201CpjInsUserID, n202CpjUpdData, A202CpjUpdData, n203CpjUpdHora, A203CpjUpdHora, n204CpjUpdDataHora, A204CpjUpdDataHora, n205CpjUpdUserID, A205CpjUpdUserID, A206CpjVersao, A207CpjAtivo, n261CpjTelNum, A261CpjTelNum, n262CpjTelRam, A262CpjTelRam, n263CpjCelNum, A263CpjCelNum, n264CpjWppNum, A264CpjWppNum, n265CpjWebsite, A265CpjWebsite, n266CpjEmail, A266CpjEmail, A542CpjDel, A365CpjTipoId, n181CpjHolID, A181CpjHolID, n169CpjPaiID, A169CpjPaiID, A158CliID, A166CpjID});
                     pr_default.close(17);
                     pr_default.SmartCacheProvider.SetUpdated("tb_clientepj");
                     if ( (pr_default.getStatus(17) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_clientepj"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0P25( ) ;
                     if ( AnyError == 0 )
                     {
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
            EndLevel0P25( ) ;
         }
         CloseExtendedTableCursors0P25( ) ;
      }

      protected void DeferredUpdate0P25( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("clientepj_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0P25( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0P25( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0P25( ) ;
            AfterConfirm0P25( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0P25( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000P20 */
                  pr_default.execute(18, new Object[] {A158CliID, A166CpjID});
                  pr_default.close(18);
                  pr_default.SmartCacheProvider.SetUpdated("tb_clientepj");
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
         sMode25 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0P25( ) ;
         Gx_mode = sMode25;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0P25( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000P21 */
            pr_default.execute(19, new Object[] {A158CliID});
            A159CliMatricula = T000P21_A159CliMatricula[0];
            AssignAttri("", false, "A159CliMatricula", StringUtil.LTrimStr( (decimal)(A159CliMatricula), 12, 0));
            A160CliNomeFamiliar = T000P21_A160CliNomeFamiliar[0];
            AssignAttri("", false, "A160CliNomeFamiliar", A160CliNomeFamiliar);
            pr_default.close(19);
            /* Using cursor T000P22 */
            pr_default.execute(20, new Object[] {A158CliID, n169CpjPaiID, A169CpjPaiID});
            A172CpjPaiNomeFan = T000P22_A172CpjPaiNomeFan[0];
            A173CpjPaiRazaoSoc = T000P22_A173CpjPaiRazaoSoc[0];
            A175CpjPaiMatricula = T000P22_A175CpjPaiMatricula[0];
            A194CpjPaiCNPJ = T000P22_A194CpjPaiCNPJ[0];
            A195CpjPaiCNPJFormat = T000P22_A195CpjPaiCNPJFormat[0];
            A184CpjPaiTipoID = T000P22_A184CpjPaiTipoID[0];
            pr_default.close(20);
            /* Using cursor T000P23 */
            pr_default.execute(21, new Object[] {A184CpjPaiTipoID});
            A185CpjPaiTipoSigla = T000P23_A185CpjPaiTipoSigla[0];
            A186CpjPaiTipoNome = T000P23_A186CpjPaiTipoNome[0];
            pr_default.close(21);
            /* Using cursor T000P24 */
            pr_default.execute(22, new Object[] {A365CpjTipoId});
            A366CpjTipoSigla = T000P24_A366CpjTipoSigla[0];
            AssignAttri("", false, "A366CpjTipoSigla", A366CpjTipoSigla);
            A367CpjTipoNome = T000P24_A367CpjTipoNome[0];
            AssignAttri("", false, "A367CpjTipoNome", A367CpjTipoNome);
            pr_default.close(22);
            Combo_cpjpaiid_Visible = (bool)((A365CpjTipoId>1));
            ucCombo_cpjpaiid.SendProperty(context, "", false, Combo_cpjpaiid_Internalname, "Visible", StringUtil.BoolToStr( Combo_cpjpaiid_Visible));
            if ( ! ( ( A365CpjTipoId > 1 ) ) )
            {
               divCombo_cpjpaiid_cell_Class = "Invisible";
               AssignProp("", false, divCombo_cpjpaiid_cell_Internalname, "Class", divCombo_cpjpaiid_cell_Class, true);
            }
            else
            {
               if ( ( A365CpjTipoId > 1 ) && ! ( ( A365CpjTipoId > 2 ) ) )
               {
                  divCombo_cpjpaiid_cell_Class = "col-xs-12 DataContentCellFL ExtendedComboCell";
                  AssignProp("", false, divCombo_cpjpaiid_cell_Internalname, "Class", divCombo_cpjpaiid_cell_Class, true);
               }
               else
               {
                  if ( ( A365CpjTipoId > 1 ) && ( ( A365CpjTipoId > 2 ) ) )
                  {
                     divCombo_cpjpaiid_cell_Class = "col-xs-12 DataContentCellFL RequiredDataContentCellFL ExtendedComboCell";
                     AssignProp("", false, divCombo_cpjpaiid_cell_Internalname, "Class", divCombo_cpjpaiid_cell_Class, true);
                  }
               }
            }
            AV36CpjTipoIdFiltro = (int)((A365CpjTipoId-1));
            AssignAttri("", false, "AV36CpjTipoIdFiltro", StringUtil.LTrimStr( (decimal)(AV36CpjTipoIdFiltro), 9, 0));
            if ( A365CpjTipoId == 2 )
            {
               lblTextblockcpjpaiid_Caption = "Holding (opcional)";
               AssignProp("", false, lblTextblockcpjpaiid_Internalname, "Caption", lblTextblockcpjpaiid_Caption, true);
            }
            else
            {
               if ( A365CpjTipoId == 3 )
               {
                  lblTextblockcpjpaiid_Caption = "Empresa";
                  AssignProp("", false, lblTextblockcpjpaiid_Internalname, "Caption", lblTextblockcpjpaiid_Caption, true);
               }
            }
            /* Using cursor T000P25 */
            pr_default.execute(23, new Object[] {A158CliID, n181CpjHolID, A181CpjHolID});
            A182CpjHolNomeFan = T000P25_A182CpjHolNomeFan[0];
            A183CpjHolRazaoSoc = T000P25_A183CpjHolRazaoSoc[0];
            A191CpjHolMatricula = T000P25_A191CpjHolMatricula[0];
            A192CpjHolCNPJ = T000P25_A192CpjHolCNPJ[0];
            A193CpjHolCNPJFormat = T000P25_A193CpjHolCNPJFormat[0];
            pr_default.close(23);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000P26 */
            pr_default.execute(24, new Object[] {A158CliID, A166CpjID});
            if ( (pr_default.getStatus(24) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(24);
            /* Using cursor T000P27 */
            pr_default.execute(25, new Object[] {A158CliID, A166CpjID});
            if ( (pr_default.getStatus(25) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(25);
            /* Using cursor T000P28 */
            pr_default.execute(26, new Object[] {A158CliID, A166CpjID});
            if ( (pr_default.getStatus(26) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Oportunidade de Negócio"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(26);
            /* Using cursor T000P29 */
            pr_default.execute(27, new Object[] {A158CliID, A166CpjID});
            if ( (pr_default.getStatus(27) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(27);
            /* Using cursor T000P30 */
            pr_default.execute(28, new Object[] {A158CliID, A166CpjID});
            if ( (pr_default.getStatus(28) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(28);
         }
      }

      protected void EndLevel0P25( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0P25( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("core.clientepj",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0P0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("core.clientepj",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0P25( )
      {
         /* Scan By routine */
         /* Using cursor T000P31 */
         pr_default.execute(29);
         RcdFound25 = 0;
         if ( (pr_default.getStatus(29) != 101) )
         {
            RcdFound25 = 1;
            A158CliID = T000P31_A158CliID[0];
            AssignAttri("", false, "A158CliID", A158CliID.ToString());
            A166CpjID = T000P31_A166CpjID[0];
            AssignAttri("", false, "A166CpjID", A166CpjID.ToString());
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0P25( )
      {
         /* Scan next routine */
         pr_default.readNext(29);
         RcdFound25 = 0;
         if ( (pr_default.getStatus(29) != 101) )
         {
            RcdFound25 = 1;
            A158CliID = T000P31_A158CliID[0];
            AssignAttri("", false, "A158CliID", A158CliID.ToString());
            A166CpjID = T000P31_A166CpjID[0];
            AssignAttri("", false, "A166CpjID", A166CpjID.ToString());
         }
      }

      protected void ScanEnd0P25( )
      {
         pr_default.close(29);
      }

      protected void AfterConfirm0P25( )
      {
         /* After Confirm Rules */
         if ( IsIns( )  )
         {
            GXt_int3 = (int)(A176CpjMatricula);
            new GeneXus.Programs.core.serializar(context ).execute(  "CpjMatricula",  1, out  GXt_int3) ;
            A176CpjMatricula = GXt_int3;
            AssignAttri("", false, "A176CpjMatricula", StringUtil.LTrimStr( (decimal)(A176CpjMatricula), 12, 0));
         }
      }

      protected void BeforeInsert0P25( )
      {
         /* Before Insert Rules */
         A200CpjInsDataHora = DateTimeUtil.NowMS( context);
         AssignAttri("", false, "A200CpjInsDataHora", context.localUtil.TToC( A200CpjInsDataHora, 10, 12, 0, 3, "/", ":", " "));
         AV37GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).get();
         A201CpjInsUserID = AV37GAMUser.gxTpr_Guid;
         n201CpjInsUserID = false;
         AssignAttri("", false, "A201CpjInsUserID", A201CpjInsUserID);
         A198CpjInsData = DateTimeUtil.ResetTime( A200CpjInsDataHora);
         AssignAttri("", false, "A198CpjInsData", context.localUtil.Format(A198CpjInsData, "99/99/99"));
         A199CpjInsHora = DateTimeUtil.ResetDate( DateTimeUtil.ResetMilliseconds(A200CpjInsDataHora));
         AssignAttri("", false, "A199CpjInsHora", context.localUtil.TToC( A199CpjInsHora, 0, 5, 0, 3, "/", ":", " "));
      }

      protected void BeforeUpdate0P25( )
      {
         /* Before Update Rules */
         new GeneXus.Programs.core.loadauditclientepj(context ).execute(  "Y", ref  AV39AuditingObject,  A158CliID,  A166CpjID,  Gx_mode) ;
         if ( A542CpjDel && ( O542CpjDel != A542CpjDel ) )
         {
            A543CpjDelDataHora = DateTimeUtil.NowMS( context);
            n543CpjDelDataHora = false;
            AssignAttri("", false, "A543CpjDelDataHora", context.localUtil.TToC( A543CpjDelDataHora, 10, 12, 0, 3, "/", ":", " "));
         }
         if ( A542CpjDel && ( O542CpjDel != A542CpjDel ) )
         {
            A546CpjDelUsuId = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getid();
            n546CpjDelUsuId = false;
            AssignAttri("", false, "A546CpjDelUsuId", A546CpjDelUsuId);
         }
         if ( A542CpjDel && ( O542CpjDel != A542CpjDel ) )
         {
            A547CpjDelUsuNome = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
            n547CpjDelUsuNome = false;
            AssignAttri("", false, "A547CpjDelUsuNome", A547CpjDelUsuNome);
         }
         if ( A542CpjDel && ( O542CpjDel != A542CpjDel ) )
         {
            A544CpjDelData = DateTimeUtil.ResetTime( DateTimeUtil.ResetTime( A543CpjDelDataHora) ) ;
            n544CpjDelData = false;
            AssignAttri("", false, "A544CpjDelData", context.localUtil.TToC( A544CpjDelData, 10, 5, 0, 3, "/", ":", " "));
         }
         if ( A542CpjDel && ( O542CpjDel != A542CpjDel ) )
         {
            A545CpjDelHora = DateTimeUtil.ResetDate( DateTimeUtil.ResetMilliseconds(A543CpjDelDataHora));
            n545CpjDelHora = false;
            AssignAttri("", false, "A545CpjDelHora", context.localUtil.TToC( A545CpjDelHora, 0, 5, 0, 3, "/", ":", " "));
         }
      }

      protected void BeforeDelete0P25( )
      {
         /* Before Delete Rules */
         new GeneXus.Programs.core.loadauditclientepj(context ).execute(  "Y", ref  AV39AuditingObject,  A158CliID,  A166CpjID,  Gx_mode) ;
      }

      protected void BeforeComplete0P25( )
      {
         /* Before Complete Rules */
         if ( IsIns( )  )
         {
            new GeneXus.Programs.core.loadauditclientepj(context ).execute(  "N", ref  AV39AuditingObject,  A158CliID,  A166CpjID,  Gx_mode) ;
         }
         if ( IsUpd( )  )
         {
            new GeneXus.Programs.core.loadauditclientepj(context ).execute(  "N", ref  AV39AuditingObject,  A158CliID,  A166CpjID,  Gx_mode) ;
         }
      }

      protected void BeforeValidate0P25( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0P25( )
      {
         edtCliNomeFamiliar_Enabled = 0;
         AssignProp("", false, edtCliNomeFamiliar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliNomeFamiliar_Enabled), 5, 0), true);
         edtCliMatricula_Enabled = 0;
         AssignProp("", false, edtCliMatricula_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliMatricula_Enabled), 5, 0), true);
         edtCpjTipoId_Enabled = 0;
         AssignProp("", false, edtCpjTipoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjTipoId_Enabled), 5, 0), true);
         edtCpjPaiID_Enabled = 0;
         AssignProp("", false, edtCpjPaiID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjPaiID_Enabled), 5, 0), true);
         edtCpjNomeFan_Enabled = 0;
         AssignProp("", false, edtCpjNomeFan_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjNomeFan_Enabled), 5, 0), true);
         edtCpjRazaoSoc_Enabled = 0;
         AssignProp("", false, edtCpjRazaoSoc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjRazaoSoc_Enabled), 5, 0), true);
         edtCpjMatricula_Enabled = 0;
         AssignProp("", false, edtCpjMatricula_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjMatricula_Enabled), 5, 0), true);
         edtCpjCNPJFormat_Enabled = 0;
         AssignProp("", false, edtCpjCNPJFormat_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjCNPJFormat_Enabled), 5, 0), true);
         edtCpjIE_Enabled = 0;
         AssignProp("", false, edtCpjIE_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjIE_Enabled), 5, 0), true);
         edtCpjCapitalSoc_Enabled = 0;
         AssignProp("", false, edtCpjCapitalSoc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjCapitalSoc_Enabled), 5, 0), true);
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
         edtavCombocpjtipoid_Enabled = 0;
         AssignProp("", false, edtavCombocpjtipoid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombocpjtipoid_Enabled), 5, 0), true);
         edtavCombocpjpaiid_Enabled = 0;
         AssignProp("", false, edtavCombocpjpaiid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombocpjpaiid_Enabled), 5, 0), true);
         edtCpjID_Enabled = 0;
         AssignProp("", false, edtCpjID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjID_Enabled), 5, 0), true);
         dynavCpjtipoidfiltro.Enabled = 0;
         AssignProp("", false, dynavCpjtipoidfiltro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynavCpjtipoidfiltro.Enabled), 5, 0), true);
         edtCpjTipoSigla_Enabled = 0;
         AssignProp("", false, edtCpjTipoSigla_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjTipoSigla_Enabled), 5, 0), true);
         edtCpjTipoNome_Enabled = 0;
         AssignProp("", false, edtCpjTipoNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCpjTipoNome_Enabled), 5, 0), true);
         edtCliID_Enabled = 0;
         AssignProp("", false, edtCliID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliID_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0P25( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0P0( )
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
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
         GXEncryptionTmp = "core.clientepj.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV7CliID.ToString()) + "," + UrlEncode(AV8CpjID.ToString());
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("core.clientepj.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"ClientePJ");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("Pgmname", StringUtil.RTrim( context.localUtil.Format( AV41Pgmname, "")));
         forbiddenHiddens.Add("CpjUpdData", context.localUtil.Format(A202CpjUpdData, "99/99/99"));
         forbiddenHiddens.Add("CpjUpdHora", context.localUtil.Format( A203CpjUpdHora, "99:99"));
         forbiddenHiddens.Add("CpjUpdDataHora", context.localUtil.Format( A204CpjUpdDataHora, "99/99/9999 99:99:99.999"));
         forbiddenHiddens.Add("CpjUpdUserID", StringUtil.RTrim( context.localUtil.Format( A205CpjUpdUserID, "")));
         forbiddenHiddens.Add("CpjVersao", context.localUtil.Format( (decimal)(A206CpjVersao), "ZZZ9"));
         forbiddenHiddens.Add("CpjAtivo", StringUtil.BoolToStr( A207CpjAtivo));
         forbiddenHiddens.Add("CpjDel", StringUtil.BoolToStr( A542CpjDel));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("core\\clientepj:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z158CliID", Z158CliID.ToString());
         GxWebStd.gx_hidden_field( context, "Z166CpjID", Z166CpjID.ToString());
         GxWebStd.gx_hidden_field( context, "Z187CpjCNPJ", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z187CpjCNPJ), 14, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z189CpjIE", Z189CpjIE);
         GxWebStd.gx_hidden_field( context, "Z176CpjMatricula", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z176CpjMatricula), 12, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z200CpjInsDataHora", context.localUtil.TToC( Z200CpjInsDataHora, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z198CpjInsData", context.localUtil.DToC( Z198CpjInsData, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z199CpjInsHora", context.localUtil.TToC( Z199CpjInsHora, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z543CpjDelDataHora", context.localUtil.TToC( Z543CpjDelDataHora, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z544CpjDelData", context.localUtil.TToC( Z544CpjDelData, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z545CpjDelHora", context.localUtil.TToC( Z545CpjDelHora, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z546CpjDelUsuId", StringUtil.RTrim( Z546CpjDelUsuId));
         GxWebStd.gx_hidden_field( context, "Z547CpjDelUsuNome", Z547CpjDelUsuNome);
         GxWebStd.gx_hidden_field( context, "Z170CpjNomeFan", Z170CpjNomeFan);
         GxWebStd.gx_hidden_field( context, "Z171CpjRazaoSoc", Z171CpjRazaoSoc);
         GxWebStd.gx_hidden_field( context, "Z188CpjCNPJFormat", Z188CpjCNPJFormat);
         GxWebStd.gx_hidden_field( context, "Z190CpjCapitalSoc", StringUtil.LTrim( StringUtil.NToC( Z190CpjCapitalSoc, 16, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z201CpjInsUserID", StringUtil.RTrim( Z201CpjInsUserID));
         GxWebStd.gx_hidden_field( context, "Z202CpjUpdData", context.localUtil.DToC( Z202CpjUpdData, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z203CpjUpdHora", context.localUtil.TToC( Z203CpjUpdHora, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z204CpjUpdDataHora", context.localUtil.TToC( Z204CpjUpdDataHora, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z205CpjUpdUserID", StringUtil.RTrim( Z205CpjUpdUserID));
         GxWebStd.gx_hidden_field( context, "Z206CpjVersao", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z206CpjVersao), 4, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "Z207CpjAtivo", Z207CpjAtivo);
         GxWebStd.gx_hidden_field( context, "Z261CpjTelNum", StringUtil.RTrim( Z261CpjTelNum));
         GxWebStd.gx_hidden_field( context, "Z262CpjTelRam", Z262CpjTelRam);
         GxWebStd.gx_hidden_field( context, "Z263CpjCelNum", StringUtil.RTrim( Z263CpjCelNum));
         GxWebStd.gx_hidden_field( context, "Z264CpjWppNum", StringUtil.RTrim( Z264CpjWppNum));
         GxWebStd.gx_hidden_field( context, "Z265CpjWebsite", Z265CpjWebsite);
         GxWebStd.gx_hidden_field( context, "Z266CpjEmail", Z266CpjEmail);
         GxWebStd.gx_boolean_hidden_field( context, "Z542CpjDel", Z542CpjDel);
         GxWebStd.gx_hidden_field( context, "Z365CpjTipoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z365CpjTipoId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z181CpjHolID", Z181CpjHolID.ToString());
         GxWebStd.gx_hidden_field( context, "Z169CpjPaiID", Z169CpjPaiID.ToString());
         GxWebStd.gx_boolean_hidden_field( context, "O542CpjDel", O542CpjDel);
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N181CpjHolID", A181CpjHolID.ToString());
         GxWebStd.gx_hidden_field( context, "N169CpjPaiID", A169CpjPaiID.ToString());
         GxWebStd.gx_hidden_field( context, "N365CpjTipoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A365CpjTipoId), 9, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV17DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV17DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCPJTIPOID_DATA", AV24CpjTipoId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCPJTIPOID_DATA", AV24CpjTipoId_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCPJPAIID_DATA", AV29CpjPaiID_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCPJPAIID_DATA", AV29CpjPaiID_Data);
         }
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vCOND_CPJTIPOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV38Cond_CpjTipoId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vCLIID", AV7CliID.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vCLIID", GetSecureSignedToken( "", AV7CliID, context));
         GxWebStd.gx_hidden_field( context, "vCPJID", AV8CpjID.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vCPJID", GetSecureSignedToken( "", AV8CpjID, context));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_CPJHOLID", AV28Insert_CpjHolID.ToString());
         GxWebStd.gx_hidden_field( context, "CPJHOLID", A181CpjHolID.ToString());
         GxWebStd.gx_hidden_field( context, "vINSERT_CPJPAIID", AV27Insert_CpjPaiID.ToString());
         GxWebStd.gx_hidden_field( context, "vINSERT_CPJTIPOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14Insert_CpjTipoId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "CPJCNPJ", StringUtil.LTrim( StringUtil.NToC( (decimal)(A187CpjCNPJ), 14, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "CPJINSDATAHORA", context.localUtil.TToC( A200CpjInsDataHora, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "CPJINSDATA", context.localUtil.DToC( A198CpjInsData, 0, "/"));
         GxWebStd.gx_hidden_field( context, "CPJINSHORA", context.localUtil.TToC( A199CpjInsHora, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_boolean_hidden_field( context, "CPJDEL", A542CpjDel);
         GxWebStd.gx_hidden_field( context, "CPJDELDATAHORA", context.localUtil.TToC( A543CpjDelDataHora, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "CPJDELDATA", context.localUtil.TToC( A544CpjDelData, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "CPJDELHORA", context.localUtil.TToC( A545CpjDelHora, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "CPJDELUSUID", StringUtil.RTrim( A546CpjDelUsuId));
         GxWebStd.gx_hidden_field( context, "CPJDELUSUNOME", A547CpjDelUsuNome);
         GxWebStd.gx_boolean_hidden_field( context, "CPJATIVO", A207CpjAtivo);
         GxWebStd.gx_hidden_field( context, "CPJVERSAO", StringUtil.LTrim( StringUtil.NToC( (decimal)(A206CpjVersao), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "CPJINSUSERID", StringUtil.RTrim( A201CpjInsUserID));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAUDITINGOBJECT", AV39AuditingObject);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAUDITINGOBJECT", AV39AuditingObject);
         }
         GxWebStd.gx_hidden_field( context, "CPJUPDDATA", context.localUtil.DToC( A202CpjUpdData, 0, "/"));
         GxWebStd.gx_hidden_field( context, "CPJUPDHORA", context.localUtil.TToC( A203CpjUpdHora, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "CPJUPDDATAHORA", context.localUtil.TToC( A204CpjUpdDataHora, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "CPJUPDUSERID", StringUtil.RTrim( A205CpjUpdUserID));
         GxWebStd.gx_hidden_field( context, "CPJHOLNOMEFAN", A182CpjHolNomeFan);
         GxWebStd.gx_hidden_field( context, "CPJHOLRAZAOSOC", A183CpjHolRazaoSoc);
         GxWebStd.gx_hidden_field( context, "CPJHOLMATRICULA", StringUtil.LTrim( StringUtil.NToC( (decimal)(A191CpjHolMatricula), 12, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "CPJHOLCNPJ", StringUtil.LTrim( StringUtil.NToC( (decimal)(A192CpjHolCNPJ), 14, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "CPJHOLCNPJFORMAT", A193CpjHolCNPJFormat);
         GxWebStd.gx_hidden_field( context, "CPJPAINOMEFAN", A172CpjPaiNomeFan);
         GxWebStd.gx_hidden_field( context, "CPJPAIRAZAOSOC", A173CpjPaiRazaoSoc);
         GxWebStd.gx_hidden_field( context, "CPJPAIMATRICULA", StringUtil.LTrim( StringUtil.NToC( (decimal)(A175CpjPaiMatricula), 12, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "CPJPAICNPJ", StringUtil.LTrim( StringUtil.NToC( (decimal)(A194CpjPaiCNPJ), 14, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "CPJPAICNPJFORMAT", A195CpjPaiCNPJFormat);
         GxWebStd.gx_hidden_field( context, "CPJPAITIPOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A184CpjPaiTipoID), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "CPJPAITIPOSIGLA", A185CpjPaiTipoSigla);
         GxWebStd.gx_hidden_field( context, "CPJPAITIPONOME", A186CpjPaiTipoNome);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV41Pgmname));
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
         GxWebStd.gx_hidden_field( context, "COMBO_CPJTIPOID_Objectcall", StringUtil.RTrim( Combo_cpjtipoid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_CPJTIPOID_Cls", StringUtil.RTrim( Combo_cpjtipoid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_CPJTIPOID_Selectedvalue_set", StringUtil.RTrim( Combo_cpjtipoid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_CPJTIPOID_Enabled", StringUtil.BoolToStr( Combo_cpjtipoid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_CPJTIPOID_Emptyitemtext", StringUtil.RTrim( Combo_cpjtipoid_Emptyitemtext));
         GxWebStd.gx_hidden_field( context, "COMBO_CPJPAIID_Objectcall", StringUtil.RTrim( Combo_cpjpaiid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_CPJPAIID_Cls", StringUtil.RTrim( Combo_cpjpaiid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_CPJPAIID_Selectedvalue_set", StringUtil.RTrim( Combo_cpjpaiid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_CPJPAIID_Selectedtext_set", StringUtil.RTrim( Combo_cpjpaiid_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_CPJPAIID_Gamoauthtoken", StringUtil.RTrim( Combo_cpjpaiid_Gamoauthtoken));
         GxWebStd.gx_hidden_field( context, "COMBO_CPJPAIID_Enabled", StringUtil.BoolToStr( Combo_cpjpaiid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_CPJPAIID_Visible", StringUtil.BoolToStr( Combo_cpjpaiid_Visible));
         GxWebStd.gx_hidden_field( context, "COMBO_CPJPAIID_Datalistproc", StringUtil.RTrim( Combo_cpjpaiid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_CPJPAIID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_cpjpaiid_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_CPJPAIID_Htmltemplate", StringUtil.RTrim( Combo_cpjpaiid_Htmltemplate));
         GxWebStd.gx_hidden_field( context, "COMBO_CPJPAIID_Emptyitemtext", StringUtil.RTrim( Combo_cpjpaiid_Emptyitemtext));
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
         GXEncryptionTmp = "core.clientepj.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV7CliID.ToString()) + "," + UrlEncode(AV8CpjID.ToString());
         return formatLink("core.clientepj.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "core.ClientePJ" ;
      }

      public override string GetPgmdesc( )
      {
         return "Cliente PJ" ;
      }

      protected void InitializeNonKey0P25( )
      {
         A181CpjHolID = Guid.Empty;
         n181CpjHolID = false;
         AssignAttri("", false, "A181CpjHolID", A181CpjHolID.ToString());
         A169CpjPaiID = Guid.Empty;
         n169CpjPaiID = false;
         AssignAttri("", false, "A169CpjPaiID", A169CpjPaiID.ToString());
         n169CpjPaiID = ((Guid.Empty==A169CpjPaiID) ? true : false);
         A365CpjTipoId = 0;
         AssignAttri("", false, "A365CpjTipoId", StringUtil.LTrimStr( (decimal)(A365CpjTipoId), 9, 0));
         AV39AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
         A187CpjCNPJ = 0;
         AssignAttri("", false, "A187CpjCNPJ", StringUtil.LTrimStr( (decimal)(A187CpjCNPJ), 14, 0));
         A189CpjIE = "";
         AssignAttri("", false, "A189CpjIE", A189CpjIE);
         A176CpjMatricula = 0;
         AssignAttri("", false, "A176CpjMatricula", StringUtil.LTrimStr( (decimal)(A176CpjMatricula), 12, 0));
         A200CpjInsDataHora = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A200CpjInsDataHora", context.localUtil.TToC( A200CpjInsDataHora, 10, 12, 0, 3, "/", ":", " "));
         A198CpjInsData = DateTime.MinValue;
         AssignAttri("", false, "A198CpjInsData", context.localUtil.Format(A198CpjInsData, "99/99/99"));
         A199CpjInsHora = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A199CpjInsHora", context.localUtil.TToC( A199CpjInsHora, 0, 5, 0, 3, "/", ":", " "));
         AV37GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         A543CpjDelDataHora = (DateTime)(DateTime.MinValue);
         n543CpjDelDataHora = false;
         AssignAttri("", false, "A543CpjDelDataHora", context.localUtil.TToC( A543CpjDelDataHora, 10, 12, 0, 3, "/", ":", " "));
         A544CpjDelData = (DateTime)(DateTime.MinValue);
         n544CpjDelData = false;
         AssignAttri("", false, "A544CpjDelData", context.localUtil.TToC( A544CpjDelData, 10, 5, 0, 3, "/", ":", " "));
         A545CpjDelHora = (DateTime)(DateTime.MinValue);
         n545CpjDelHora = false;
         AssignAttri("", false, "A545CpjDelHora", context.localUtil.TToC( A545CpjDelHora, 0, 5, 0, 3, "/", ":", " "));
         A546CpjDelUsuId = "";
         n546CpjDelUsuId = false;
         AssignAttri("", false, "A546CpjDelUsuId", A546CpjDelUsuId);
         A547CpjDelUsuNome = "";
         n547CpjDelUsuNome = false;
         AssignAttri("", false, "A547CpjDelUsuNome", A547CpjDelUsuNome);
         A159CliMatricula = 0;
         AssignAttri("", false, "A159CliMatricula", StringUtil.LTrimStr( (decimal)(A159CliMatricula), 12, 0));
         A160CliNomeFamiliar = "";
         AssignAttri("", false, "A160CliNomeFamiliar", A160CliNomeFamiliar);
         A182CpjHolNomeFan = "";
         AssignAttri("", false, "A182CpjHolNomeFan", A182CpjHolNomeFan);
         A183CpjHolRazaoSoc = "";
         AssignAttri("", false, "A183CpjHolRazaoSoc", A183CpjHolRazaoSoc);
         A191CpjHolMatricula = 0;
         AssignAttri("", false, "A191CpjHolMatricula", StringUtil.LTrimStr( (decimal)(A191CpjHolMatricula), 12, 0));
         A192CpjHolCNPJ = 0;
         AssignAttri("", false, "A192CpjHolCNPJ", StringUtil.LTrimStr( (decimal)(A192CpjHolCNPJ), 14, 0));
         A193CpjHolCNPJFormat = "";
         AssignAttri("", false, "A193CpjHolCNPJFormat", A193CpjHolCNPJFormat);
         A172CpjPaiNomeFan = "";
         AssignAttri("", false, "A172CpjPaiNomeFan", A172CpjPaiNomeFan);
         A173CpjPaiRazaoSoc = "";
         AssignAttri("", false, "A173CpjPaiRazaoSoc", A173CpjPaiRazaoSoc);
         A175CpjPaiMatricula = 0;
         AssignAttri("", false, "A175CpjPaiMatricula", StringUtil.LTrimStr( (decimal)(A175CpjPaiMatricula), 12, 0));
         A194CpjPaiCNPJ = 0;
         AssignAttri("", false, "A194CpjPaiCNPJ", StringUtil.LTrimStr( (decimal)(A194CpjPaiCNPJ), 14, 0));
         A195CpjPaiCNPJFormat = "";
         AssignAttri("", false, "A195CpjPaiCNPJFormat", A195CpjPaiCNPJFormat);
         A184CpjPaiTipoID = 0;
         AssignAttri("", false, "A184CpjPaiTipoID", StringUtil.LTrimStr( (decimal)(A184CpjPaiTipoID), 9, 0));
         A185CpjPaiTipoSigla = "";
         AssignAttri("", false, "A185CpjPaiTipoSigla", A185CpjPaiTipoSigla);
         A186CpjPaiTipoNome = "";
         AssignAttri("", false, "A186CpjPaiTipoNome", A186CpjPaiTipoNome);
         A366CpjTipoSigla = "";
         AssignAttri("", false, "A366CpjTipoSigla", A366CpjTipoSigla);
         A367CpjTipoNome = "";
         AssignAttri("", false, "A367CpjTipoNome", A367CpjTipoNome);
         A171CpjRazaoSoc = "";
         AssignAttri("", false, "A171CpjRazaoSoc", A171CpjRazaoSoc);
         A188CpjCNPJFormat = "";
         AssignAttri("", false, "A188CpjCNPJFormat", A188CpjCNPJFormat);
         A190CpjCapitalSoc = 0;
         AssignAttri("", false, "A190CpjCapitalSoc", StringUtil.LTrimStr( A190CpjCapitalSoc, 16, 2));
         A201CpjInsUserID = "";
         n201CpjInsUserID = false;
         AssignAttri("", false, "A201CpjInsUserID", A201CpjInsUserID);
         A202CpjUpdData = DateTime.MinValue;
         n202CpjUpdData = false;
         AssignAttri("", false, "A202CpjUpdData", context.localUtil.Format(A202CpjUpdData, "99/99/99"));
         A203CpjUpdHora = (DateTime)(DateTime.MinValue);
         n203CpjUpdHora = false;
         AssignAttri("", false, "A203CpjUpdHora", context.localUtil.TToC( A203CpjUpdHora, 0, 5, 0, 3, "/", ":", " "));
         A204CpjUpdDataHora = (DateTime)(DateTime.MinValue);
         n204CpjUpdDataHora = false;
         AssignAttri("", false, "A204CpjUpdDataHora", context.localUtil.TToC( A204CpjUpdDataHora, 10, 12, 0, 3, "/", ":", " "));
         A205CpjUpdUserID = "";
         n205CpjUpdUserID = false;
         AssignAttri("", false, "A205CpjUpdUserID", A205CpjUpdUserID);
         A261CpjTelNum = "";
         n261CpjTelNum = false;
         AssignAttri("", false, "A261CpjTelNum", A261CpjTelNum);
         n261CpjTelNum = (String.IsNullOrEmpty(StringUtil.RTrim( A261CpjTelNum)) ? true : false);
         A262CpjTelRam = "";
         n262CpjTelRam = false;
         AssignAttri("", false, "A262CpjTelRam", A262CpjTelRam);
         n262CpjTelRam = (String.IsNullOrEmpty(StringUtil.RTrim( A262CpjTelRam)) ? true : false);
         A263CpjCelNum = "";
         n263CpjCelNum = false;
         AssignAttri("", false, "A263CpjCelNum", A263CpjCelNum);
         n263CpjCelNum = (String.IsNullOrEmpty(StringUtil.RTrim( A263CpjCelNum)) ? true : false);
         A264CpjWppNum = "";
         n264CpjWppNum = false;
         AssignAttri("", false, "A264CpjWppNum", A264CpjWppNum);
         n264CpjWppNum = (String.IsNullOrEmpty(StringUtil.RTrim( A264CpjWppNum)) ? true : false);
         A265CpjWebsite = "";
         n265CpjWebsite = false;
         AssignAttri("", false, "A265CpjWebsite", A265CpjWebsite);
         n265CpjWebsite = (String.IsNullOrEmpty(StringUtil.RTrim( A265CpjWebsite)) ? true : false);
         A266CpjEmail = "";
         n266CpjEmail = false;
         AssignAttri("", false, "A266CpjEmail", A266CpjEmail);
         n266CpjEmail = (String.IsNullOrEmpty(StringUtil.RTrim( A266CpjEmail)) ? true : false);
         A542CpjDel = false;
         AssignAttri("", false, "A542CpjDel", A542CpjDel);
         A170CpjNomeFan = "";
         AssignAttri("", false, "A170CpjNomeFan", A170CpjNomeFan);
         A206CpjVersao = 1;
         AssignAttri("", false, "A206CpjVersao", StringUtil.LTrimStr( (decimal)(A206CpjVersao), 4, 0));
         A207CpjAtivo = true;
         AssignAttri("", false, "A207CpjAtivo", A207CpjAtivo);
         O542CpjDel = A542CpjDel;
         AssignAttri("", false, "A542CpjDel", A542CpjDel);
         Z187CpjCNPJ = 0;
         Z189CpjIE = "";
         Z176CpjMatricula = 0;
         Z200CpjInsDataHora = (DateTime)(DateTime.MinValue);
         Z198CpjInsData = DateTime.MinValue;
         Z199CpjInsHora = (DateTime)(DateTime.MinValue);
         Z543CpjDelDataHora = (DateTime)(DateTime.MinValue);
         Z544CpjDelData = (DateTime)(DateTime.MinValue);
         Z545CpjDelHora = (DateTime)(DateTime.MinValue);
         Z546CpjDelUsuId = "";
         Z547CpjDelUsuNome = "";
         Z170CpjNomeFan = "";
         Z171CpjRazaoSoc = "";
         Z188CpjCNPJFormat = "";
         Z190CpjCapitalSoc = 0;
         Z201CpjInsUserID = "";
         Z202CpjUpdData = DateTime.MinValue;
         Z203CpjUpdHora = (DateTime)(DateTime.MinValue);
         Z204CpjUpdDataHora = (DateTime)(DateTime.MinValue);
         Z205CpjUpdUserID = "";
         Z206CpjVersao = 0;
         Z207CpjAtivo = false;
         Z261CpjTelNum = "";
         Z262CpjTelRam = "";
         Z263CpjCelNum = "";
         Z264CpjWppNum = "";
         Z265CpjWebsite = "";
         Z266CpjEmail = "";
         Z542CpjDel = false;
         Z365CpjTipoId = 0;
         Z181CpjHolID = Guid.Empty;
         Z169CpjPaiID = Guid.Empty;
      }

      protected void InitAll0P25( )
      {
         A158CliID = Guid.Empty;
         AssignAttri("", false, "A158CliID", A158CliID.ToString());
         A166CpjID = Guid.NewGuid( );
         AssignAttri("", false, "A166CpjID", A166CpjID.ToString());
         InitializeNonKey0P25( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A207CpjAtivo = i207CpjAtivo;
         AssignAttri("", false, "A207CpjAtivo", A207CpjAtivo);
         A206CpjVersao = i206CpjVersao;
         AssignAttri("", false, "A206CpjVersao", StringUtil.LTrimStr( (decimal)(A206CpjVersao), 4, 0));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202382814951", true, true);
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
         context.AddJavascriptSource("gxdec.js", "?"+context.GetBuildNumber( 211160), false, true);
         context.AddJavascriptSource("core/clientepj.js", "?202382814954", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtCliNomeFamiliar_Internalname = "CLINOMEFAMILIAR";
         edtCliMatricula_Internalname = "CLIMATRICULA";
         divTablecliente_Internalname = "TABLECLIENTE";
         Dvpanel_tablecliente_Internalname = "DVPANEL_TABLECLIENTE";
         lblTextblockcpjtipoid_Internalname = "TEXTBLOCKCPJTIPOID";
         Combo_cpjtipoid_Internalname = "COMBO_CPJTIPOID";
         edtCpjTipoId_Internalname = "CPJTIPOID";
         divTablesplittedcpjtipoid_Internalname = "TABLESPLITTEDCPJTIPOID";
         lblTextblockcpjpaiid_Internalname = "TEXTBLOCKCPJPAIID";
         Combo_cpjpaiid_Internalname = "COMBO_CPJPAIID";
         edtCpjPaiID_Internalname = "CPJPAIID";
         divTablesplittedcpjpaiid_Internalname = "TABLESPLITTEDCPJPAIID";
         divCombo_cpjpaiid_cell_Internalname = "COMBO_CPJPAIID_CELL";
         edtCpjNomeFan_Internalname = "CPJNOMEFAN";
         edtCpjRazaoSoc_Internalname = "CPJRAZAOSOC";
         edtCpjMatricula_Internalname = "CPJMATRICULA";
         edtCpjCNPJFormat_Internalname = "CPJCNPJFORMAT";
         edtCpjIE_Internalname = "CPJIE";
         edtCpjCapitalSoc_Internalname = "CPJCAPITALSOC";
         edtCpjTelNum_Internalname = "CPJTELNUM";
         edtCpjTelRam_Internalname = "CPJTELRAM";
         edtCpjCelNum_Internalname = "CPJCELNUM";
         edtCpjWppNum_Internalname = "CPJWPPNUM";
         edtCpjWebsite_Internalname = "CPJWEBSITE";
         edtCpjEmail_Internalname = "CPJEMAIL";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         divTablemain_Internalname = "TABLEMAIN";
         edtavCombocpjtipoid_Internalname = "vCOMBOCPJTIPOID";
         divSectionattribute_cpjtipoid_Internalname = "SECTIONATTRIBUTE_CPJTIPOID";
         edtavCombocpjpaiid_Internalname = "vCOMBOCPJPAIID";
         divSectionattribute_cpjpaiid_Internalname = "SECTIONATTRIBUTE_CPJPAIID";
         edtCpjID_Internalname = "CPJID";
         dynavCpjtipoidfiltro_Internalname = "vCPJTIPOIDFILTRO";
         edtCpjTipoSigla_Internalname = "CPJTIPOSIGLA";
         edtCpjTipoNome_Internalname = "CPJTIPONOME";
         edtCliID_Internalname = "CLIID";
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
         Form.Caption = "Cliente PJ";
         Combo_cpjpaiid_Datalistprocparametersprefix = "";
         Combo_cpjpaiid_Visible = Convert.ToBoolean( -1);
         Combo_cpjpaiid_Htmltemplate = "";
         edtCliID_Jsonclick = "";
         edtCliID_Enabled = 1;
         edtCliID_Visible = 1;
         edtCpjTipoNome_Jsonclick = "";
         edtCpjTipoNome_Enabled = 0;
         edtCpjTipoNome_Visible = 1;
         edtCpjTipoSigla_Jsonclick = "";
         edtCpjTipoSigla_Enabled = 0;
         edtCpjTipoSigla_Visible = 1;
         dynavCpjtipoidfiltro_Jsonclick = "";
         dynavCpjtipoidfiltro.Visible = 1;
         dynavCpjtipoidfiltro.Enabled = 0;
         edtCpjID_Jsonclick = "";
         edtCpjID_Enabled = 1;
         edtCpjID_Visible = 1;
         edtavCombocpjpaiid_Jsonclick = "";
         edtavCombocpjpaiid_Enabled = 0;
         edtavCombocpjpaiid_Visible = 1;
         edtavCombocpjtipoid_Jsonclick = "";
         edtavCombocpjtipoid_Enabled = 0;
         edtavCombocpjtipoid_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtCpjEmail_Jsonclick = "";
         edtCpjEmail_Enabled = 1;
         edtCpjWebsite_Jsonclick = "";
         edtCpjWebsite_Enabled = 1;
         edtCpjWppNum_Jsonclick = "";
         edtCpjWppNum_Enabled = 1;
         edtCpjCelNum_Jsonclick = "";
         edtCpjCelNum_Enabled = 1;
         edtCpjTelRam_Jsonclick = "";
         edtCpjTelRam_Enabled = 1;
         edtCpjTelNum_Jsonclick = "";
         edtCpjTelNum_Enabled = 1;
         edtCpjCapitalSoc_Jsonclick = "";
         edtCpjCapitalSoc_Enabled = 1;
         edtCpjIE_Jsonclick = "";
         edtCpjIE_Enabled = 1;
         edtCpjCNPJFormat_Jsonclick = "";
         edtCpjCNPJFormat_Enabled = 1;
         edtCpjMatricula_Jsonclick = "";
         edtCpjMatricula_Enabled = 0;
         edtCpjRazaoSoc_Jsonclick = "";
         edtCpjRazaoSoc_Enabled = 1;
         edtCpjNomeFan_Jsonclick = "";
         edtCpjNomeFan_Enabled = 1;
         edtCpjPaiID_Jsonclick = "";
         edtCpjPaiID_Enabled = 1;
         edtCpjPaiID_Visible = 1;
         Combo_cpjpaiid_Emptyitemtext = "";
         Combo_cpjpaiid_Datalistproc = "core.ClientePJLoadDVCombo";
         Combo_cpjpaiid_Cls = "ExtendedCombo AttributeFL ExtendedComboTitleAndSubtitle";
         Combo_cpjpaiid_Caption = "";
         Combo_cpjpaiid_Enabled = Convert.ToBoolean( -1);
         lblTextblockcpjpaiid_Caption = "Cliente Pai";
         divCombo_cpjpaiid_cell_Class = "col-xs-12";
         edtCpjTipoId_Jsonclick = "";
         edtCpjTipoId_Enabled = 1;
         edtCpjTipoId_Visible = 1;
         Combo_cpjtipoid_Emptyitemtext = "";
         Combo_cpjtipoid_Cls = "ExtendedCombo AttributeFL";
         Combo_cpjtipoid_Caption = "";
         Combo_cpjtipoid_Enabled = Convert.ToBoolean( -1);
         Dvpanel_tableattributes_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Iconposition = "Right";
         Dvpanel_tableattributes_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Title = "Informe os dados abaixo";
         Dvpanel_tableattributes_Cls = "PanelCard_IconAndTitle Panel_BaseColor";
         Dvpanel_tableattributes_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tableattributes_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Width = "100%";
         edtCliMatricula_Jsonclick = "";
         edtCliMatricula_Enabled = 0;
         edtCliNomeFamiliar_Jsonclick = "";
         edtCliNomeFamiliar_Enabled = 0;
         Dvpanel_tablecliente_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tablecliente_Iconposition = "Right";
         Dvpanel_tablecliente_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tablecliente_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tablecliente_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_tablecliente_Title = "Cliente";
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

      protected void GXDLVvCPJTIPOIDFILTRO0P25( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvCPJTIPOIDFILTRO_data0P25( ) ;
         gxdynajaxindex = 1;
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            AddString( gxwrpcisep+"{\"c\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)))+"\",\"d\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)))+"\"}") ;
            gxdynajaxindex = (int)(gxdynajaxindex+1);
            gxwrpcisep = ",";
         }
         AddString( "]") ;
         if ( gxdynajaxctrlcodr.Count == 0 )
         {
            AddString( ",101") ;
         }
         AddString( "]") ;
      }

      protected void GXVvCPJTIPOIDFILTRO_html0P25( )
      {
         int gxdynajaxvalue;
         GXDLVvCPJTIPOIDFILTRO_data0P25( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavCpjtipoidfiltro.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (int)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynavCpjtipoidfiltro.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 9, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLVvCPJTIPOIDFILTRO_data0P25( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("(Nenhum)");
         /* Using cursor T000P32 */
         pr_default.execute(30);
         while ( (pr_default.getStatus(30) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(T000P32_A155PjtID[0]), 9, 0, ".", "")));
            gxdynajaxctrldescr.Add(T000P32_A157PjtNome[0]);
            pr_default.readNext(30);
         }
         pr_default.close(30);
      }

      protected void GX21ASACPJCNPJ0P25( string A188CpjCNPJFormat )
      {
         GXt_char2 = "";
         new prclimpanumero(context ).execute(  A188CpjCNPJFormat,  "", out  GXt_char2) ;
         A187CpjCNPJ = (long)(Math.Round(NumberUtil.Val( GXt_char2, "."), 18, MidpointRounding.ToEven));
         AssignAttri("", false, "A187CpjCNPJ", StringUtil.LTrimStr( (decimal)(A187CpjCNPJ), 14, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A187CpjCNPJ), 14, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void GX24ASACPJMATRICULA0P25( string Gx_mode )
      {
         if ( IsIns( )  )
         {
            GXt_int3 = (int)(A176CpjMatricula);
            new GeneXus.Programs.core.serializar(context ).execute(  "CpjMatricula",  1, out  GXt_int3) ;
            A176CpjMatricula = GXt_int3;
            AssignAttri("", false, "A176CpjMatricula", StringUtil.LTrimStr( (decimal)(A176CpjMatricula), 12, 0));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A176CpjMatricula), 12, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_50_0P25( GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV39AuditingObject ,
                                 Guid A158CliID ,
                                 Guid A166CpjID ,
                                 string Gx_mode )
      {
         new GeneXus.Programs.core.loadauditclientepj(context ).execute(  "Y", ref  AV39AuditingObject,  A158CliID,  A166CpjID,  Gx_mode) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.EncodeString( AV39AuditingObject.ToXml(false, true, "", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_51_0P25( GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV39AuditingObject ,
                                 Guid A158CliID ,
                                 Guid A166CpjID ,
                                 string Gx_mode )
      {
         new GeneXus.Programs.core.loadauditclientepj(context ).execute(  "Y", ref  AV39AuditingObject,  A158CliID,  A166CpjID,  Gx_mode) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.EncodeString( AV39AuditingObject.ToXml(false, true, "", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_52_0P25( string Gx_mode ,
                                 GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV39AuditingObject ,
                                 Guid A158CliID ,
                                 Guid A166CpjID )
      {
         if ( IsIns( )  )
         {
            new GeneXus.Programs.core.loadauditclientepj(context ).execute(  "N", ref  AV39AuditingObject,  A158CliID,  A166CpjID,  Gx_mode) ;
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.EncodeString( AV39AuditingObject.ToXml(false, true, "", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_53_0P25( string Gx_mode ,
                                 GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV39AuditingObject ,
                                 Guid A158CliID ,
                                 Guid A166CpjID )
      {
         if ( IsUpd( )  )
         {
            new GeneXus.Programs.core.loadauditclientepj(context ).execute(  "N", ref  AV39AuditingObject,  A158CliID,  A166CpjID,  Gx_mode) ;
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.EncodeString( AV39AuditingObject.ToXml(false, true, "", "")))+"\"") ;
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
         dynavCpjtipoidfiltro.Name = "vCPJTIPOIDFILTRO";
         dynavCpjtipoidfiltro.WebTags = "";
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
         AV36CpjTipoIdFiltro = (int)(Math.Round(NumberUtil.Val( dynavCpjtipoidfiltro.CurrentValue, "."), 18, MidpointRounding.ToEven));
         /* Using cursor T000P33 */
         pr_default.execute(31, new Object[] {A158CliID});
         if ( (pr_default.getStatus(31) == 101) )
         {
            GX_msglist.addItem("Não existe ''.", "ForeignKeyNotFound", 1, "CLIID");
            AnyError = 1;
            GX_FocusControl = edtCliID_Internalname;
         }
         A159CliMatricula = T000P33_A159CliMatricula[0];
         A160CliNomeFamiliar = T000P33_A160CliNomeFamiliar[0];
         pr_default.close(31);
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A170CpjNomeFan)) && ( Gx_BScreen == 0 ) )
         {
            A170CpjNomeFan = A160CliNomeFamiliar;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A159CliMatricula", StringUtil.LTrim( StringUtil.NToC( (decimal)(A159CliMatricula), 12, 0, ".", "")));
         AssignAttri("", false, "A160CliNomeFamiliar", A160CliNomeFamiliar);
         AssignAttri("", false, "A170CpjNomeFan", A170CpjNomeFan);
      }

      public void Valid_Cpjtipoid( )
      {
         AV36CpjTipoIdFiltro = (int)(Math.Round(NumberUtil.Val( dynavCpjtipoidfiltro.CurrentValue, "."), 18, MidpointRounding.ToEven));
         /* Using cursor T000P34 */
         pr_default.execute(32, new Object[] {A365CpjTipoId});
         if ( (pr_default.getStatus(32) == 101) )
         {
            GX_msglist.addItem("Não existe 'Cliente PJ -> Cliente PJ Tipo'.", "ForeignKeyNotFound", 1, "CPJTIPOID");
            AnyError = 1;
            GX_FocusControl = edtCpjTipoId_Internalname;
         }
         A366CpjTipoSigla = T000P34_A366CpjTipoSigla[0];
         A367CpjTipoNome = T000P34_A367CpjTipoNome[0];
         pr_default.close(32);
         Combo_cpjpaiid_Visible = (bool)((A365CpjTipoId>1));
         if ( ! ( ( A365CpjTipoId > 1 ) ) )
         {
            divCombo_cpjpaiid_cell_Class = "Invisible";
         }
         else
         {
            if ( ( A365CpjTipoId > 1 ) && ! ( ( A365CpjTipoId > 2 ) ) )
            {
               divCombo_cpjpaiid_cell_Class = "col-xs-12 DataContentCellFL ExtendedComboCell";
            }
            else
            {
               if ( ( A365CpjTipoId > 1 ) && ( ( A365CpjTipoId > 2 ) ) )
               {
                  divCombo_cpjpaiid_cell_Class = "col-xs-12 DataContentCellFL RequiredDataContentCellFL ExtendedComboCell";
               }
            }
         }
         AV36CpjTipoIdFiltro = (int)((A365CpjTipoId-1));
         if ( A365CpjTipoId == 2 )
         {
            lblTextblockcpjpaiid_Caption = "Holding (opcional)";
         }
         else
         {
            if ( A365CpjTipoId == 3 )
            {
               lblTextblockcpjpaiid_Caption = "Empresa";
            }
         }
         dynload_actions( ) ;
         if ( dynavCpjtipoidfiltro.ItemCount > 0 )
         {
            AV36CpjTipoIdFiltro = (int)(Math.Round(NumberUtil.Val( dynavCpjtipoidfiltro.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV36CpjTipoIdFiltro), 9, 0))), "."), 18, MidpointRounding.ToEven));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavCpjtipoidfiltro.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV36CpjTipoIdFiltro), 11, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A366CpjTipoSigla", A366CpjTipoSigla);
         AssignAttri("", false, "A367CpjTipoNome", A367CpjTipoNome);
         ucCombo_cpjpaiid.SendProperty(context, "", false, Combo_cpjpaiid_Internalname, "Visible", StringUtil.BoolToStr( Combo_cpjpaiid_Visible));
         AssignProp("", false, divCombo_cpjpaiid_cell_Internalname, "Class", divCombo_cpjpaiid_cell_Class, true);
         AssignAttri("", false, "AV36CpjTipoIdFiltro", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV36CpjTipoIdFiltro), 9, 0, ".", "")));
         dynavCpjtipoidfiltro.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV36CpjTipoIdFiltro), 11, 0));
         AssignProp("", false, dynavCpjtipoidfiltro_Internalname, "Values", dynavCpjtipoidfiltro.ToJavascriptSource(), true);
         AssignProp("", false, lblTextblockcpjpaiid_Internalname, "Caption", lblTextblockcpjpaiid_Caption, true);
      }

      public void Valid_Cpjpaiid( )
      {
         n169CpjPaiID = false;
         AV36CpjTipoIdFiltro = (int)(Math.Round(NumberUtil.Val( dynavCpjtipoidfiltro.CurrentValue, "."), 18, MidpointRounding.ToEven));
         /* Using cursor T000P35 */
         pr_default.execute(33, new Object[] {A158CliID, n169CpjPaiID, A169CpjPaiID});
         if ( (pr_default.getStatus(33) == 101) )
         {
            if ( ! ( (Guid.Empty==A158CliID) || (Guid.Empty==A169CpjPaiID) ) )
            {
               GX_msglist.addItem("Não existe 'ClientePJ -> Cliente PJ Pai'.", "ForeignKeyNotFound", 1, "CPJPAIID");
               AnyError = 1;
               GX_FocusControl = edtCliID_Internalname;
            }
         }
         A172CpjPaiNomeFan = T000P35_A172CpjPaiNomeFan[0];
         A173CpjPaiRazaoSoc = T000P35_A173CpjPaiRazaoSoc[0];
         A175CpjPaiMatricula = T000P35_A175CpjPaiMatricula[0];
         A194CpjPaiCNPJ = T000P35_A194CpjPaiCNPJ[0];
         A195CpjPaiCNPJFormat = T000P35_A195CpjPaiCNPJFormat[0];
         A184CpjPaiTipoID = T000P35_A184CpjPaiTipoID[0];
         pr_default.close(33);
         /* Using cursor T000P36 */
         pr_default.execute(34, new Object[] {A184CpjPaiTipoID});
         if ( (pr_default.getStatus(34) == 101) )
         {
            if ( ! ( (0==A184CpjPaiTipoID) ) )
            {
               GX_msglist.addItem("Não existe ''.", "ForeignKeyNotFound", 1, "CPJPAITIPOID");
               AnyError = 1;
            }
         }
         A185CpjPaiTipoSigla = T000P36_A185CpjPaiTipoSigla[0];
         A186CpjPaiTipoNome = T000P36_A186CpjPaiTipoNome[0];
         pr_default.close(34);
         if ( ( ( A365CpjTipoId > 2 ) ) && (Guid.Empty==A169CpjPaiID) )
         {
            GX_msglist.addItem("Preenchimento obrigatório", 1, "CPJPAIID");
            AnyError = 1;
            GX_FocusControl = edtCpjPaiID_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A172CpjPaiNomeFan", A172CpjPaiNomeFan);
         AssignAttri("", false, "A173CpjPaiRazaoSoc", A173CpjPaiRazaoSoc);
         AssignAttri("", false, "A175CpjPaiMatricula", StringUtil.LTrim( StringUtil.NToC( (decimal)(A175CpjPaiMatricula), 12, 0, ".", "")));
         AssignAttri("", false, "A194CpjPaiCNPJ", StringUtil.LTrim( StringUtil.NToC( (decimal)(A194CpjPaiCNPJ), 14, 0, ".", "")));
         AssignAttri("", false, "A195CpjPaiCNPJFormat", A195CpjPaiCNPJFormat);
         AssignAttri("", false, "A184CpjPaiTipoID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A184CpjPaiTipoID), 9, 0, ".", "")));
         AssignAttri("", false, "A185CpjPaiTipoSigla", A185CpjPaiTipoSigla);
         AssignAttri("", false, "A186CpjPaiTipoNome", A186CpjPaiTipoNome);
      }

      public void Valid_Cpjcnpjformat( )
      {
         AV36CpjTipoIdFiltro = (int)(Math.Round(NumberUtil.Val( dynavCpjtipoidfiltro.CurrentValue, "."), 18, MidpointRounding.ToEven));
         GXt_char2 = "";
         new prclimpanumero(context ).execute(  A188CpjCNPJFormat,  "", out  GXt_char2) ;
         A187CpjCNPJ = (long)(Math.Round(NumberUtil.Val( GXt_char2, "."), 18, MidpointRounding.ToEven));
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A188CpjCNPJFormat)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "CNPJ Formatado", "", "", "", "", "", "", "", ""), 1, "CPJCNPJFORMAT");
            AnyError = 1;
            GX_FocusControl = edtCpjCNPJFormat_Internalname;
         }
         if ( ! new prcvalidarcnpj(context).executeUdp(  A188CpjCNPJFormat) )
         {
            GX_msglist.addItem("CNPJ inválido", 1, "CPJCNPJFORMAT");
            AnyError = 1;
            GX_FocusControl = edtCpjCNPJFormat_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A187CpjCNPJ", StringUtil.LTrim( StringUtil.NToC( (decimal)(A187CpjCNPJ), 14, 0, ".", "")));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7CliID',fld:'vCLIID',pic:'',hsh:true},{av:'AV8CpjID',fld:'vCPJID',pic:'',hsh:true},{av:'dynavCpjtipoidfiltro'},{av:'AV36CpjTipoIdFiltro',fld:'vCPJTIPOIDFILTRO',pic:'ZZZ,ZZZ,ZZ9'}]");
         setEventMetadata("ENTER",",oparms:[{av:'dynavCpjtipoidfiltro'},{av:'AV36CpjTipoIdFiltro',fld:'vCPJTIPOIDFILTRO',pic:'ZZZ,ZZZ,ZZ9'}]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7CliID',fld:'vCLIID',pic:'',hsh:true},{av:'AV8CpjID',fld:'vCPJID',pic:'',hsh:true},{av:'AV41Pgmname',fld:'vPGMNAME',pic:''},{av:'A202CpjUpdData',fld:'CPJUPDDATA',pic:''},{av:'A203CpjUpdHora',fld:'CPJUPDHORA',pic:'99:99'},{av:'A204CpjUpdDataHora',fld:'CPJUPDDATAHORA',pic:'99/99/9999 99:99:99.999'},{av:'A205CpjUpdUserID',fld:'CPJUPDUSERID',pic:''},{av:'A206CpjVersao',fld:'CPJVERSAO',pic:'ZZZ9'},{av:'A207CpjAtivo',fld:'CPJATIVO',pic:''},{av:'A542CpjDel',fld:'CPJDEL',pic:''},{av:'dynavCpjtipoidfiltro'},{av:'AV36CpjTipoIdFiltro',fld:'vCPJTIPOIDFILTRO',pic:'ZZZ,ZZZ,ZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'dynavCpjtipoidfiltro'},{av:'AV36CpjTipoIdFiltro',fld:'vCPJTIPOIDFILTRO',pic:'ZZZ,ZZZ,ZZ9'}]}");
         setEventMetadata("AFTER TRN","{handler:'E130P2',iparms:[{av:'AV39AuditingObject',fld:'vAUDITINGOBJECT',pic:''},{av:'AV41Pgmname',fld:'vPGMNAME',pic:''},{av:'A158CliID',fld:'CLIID',pic:''},{av:'A166CpjID',fld:'CPJID',pic:''},{av:'dynavCpjtipoidfiltro'},{av:'AV36CpjTipoIdFiltro',fld:'vCPJTIPOIDFILTRO',pic:'ZZZ,ZZZ,ZZ9'}]");
         setEventMetadata("AFTER TRN",",oparms:[{av:'dynavCpjtipoidfiltro'},{av:'AV36CpjTipoIdFiltro',fld:'vCPJTIPOIDFILTRO',pic:'ZZZ,ZZZ,ZZ9'}]}");
         setEventMetadata("COMBO_CPJPAIID.ONOPTIONCLICKED","{handler:'E120P2',iparms:[{av:'Combo_cpjpaiid_Selectedvalue_get',ctrl:'COMBO_CPJPAIID',prop:'SelectedValue_get'},{av:'dynavCpjtipoidfiltro'},{av:'AV36CpjTipoIdFiltro',fld:'vCPJTIPOIDFILTRO',pic:'ZZZ,ZZZ,ZZ9'}]");
         setEventMetadata("COMBO_CPJPAIID.ONOPTIONCLICKED",",oparms:[{av:'AV30ComboCpjPaiID',fld:'vCOMBOCPJPAIID',pic:''},{av:'dynavCpjtipoidfiltro'},{av:'AV36CpjTipoIdFiltro',fld:'vCPJTIPOIDFILTRO',pic:'ZZZ,ZZZ,ZZ9'}]}");
         setEventMetadata("VALID_CLINOMEFAMILIAR","{handler:'Valid_Clinomefamiliar',iparms:[{av:'dynavCpjtipoidfiltro'},{av:'AV36CpjTipoIdFiltro',fld:'vCPJTIPOIDFILTRO',pic:'ZZZ,ZZZ,ZZ9'}]");
         setEventMetadata("VALID_CLINOMEFAMILIAR",",oparms:[{av:'dynavCpjtipoidfiltro'},{av:'AV36CpjTipoIdFiltro',fld:'vCPJTIPOIDFILTRO',pic:'ZZZ,ZZZ,ZZ9'}]}");
         setEventMetadata("VALID_CPJTIPOID","{handler:'Valid_Cpjtipoid',iparms:[{av:'A365CpjTipoId',fld:'CPJTIPOID',pic:'ZZZ,ZZZ,ZZ9'},{av:'A366CpjTipoSigla',fld:'CPJTIPOSIGLA',pic:''},{av:'A367CpjTipoNome',fld:'CPJTIPONOME',pic:'@!'},{av:'dynavCpjtipoidfiltro'},{av:'AV36CpjTipoIdFiltro',fld:'vCPJTIPOIDFILTRO',pic:'ZZZ,ZZZ,ZZ9'}]");
         setEventMetadata("VALID_CPJTIPOID",",oparms:[{av:'A366CpjTipoSigla',fld:'CPJTIPOSIGLA',pic:''},{av:'A367CpjTipoNome',fld:'CPJTIPONOME',pic:'@!'},{av:'Combo_cpjpaiid_Visible',ctrl:'COMBO_CPJPAIID',prop:'Visible'},{av:'divCombo_cpjpaiid_cell_Class',ctrl:'COMBO_CPJPAIID_CELL',prop:'Class'},{av:'lblTextblockcpjpaiid_Caption',ctrl:'TEXTBLOCKCPJPAIID',prop:'Caption'},{av:'dynavCpjtipoidfiltro'},{av:'AV36CpjTipoIdFiltro',fld:'vCPJTIPOIDFILTRO',pic:'ZZZ,ZZZ,ZZ9'}]}");
         setEventMetadata("VALID_CPJPAIID","{handler:'Valid_Cpjpaiid',iparms:[{av:'A158CliID',fld:'CLIID',pic:''},{av:'A169CpjPaiID',fld:'CPJPAIID',pic:''},{av:'A184CpjPaiTipoID',fld:'CPJPAITIPOID',pic:'ZZZ,ZZZ,ZZ9'},{av:'A365CpjTipoId',fld:'CPJTIPOID',pic:'ZZZ,ZZZ,ZZ9'},{av:'A172CpjPaiNomeFan',fld:'CPJPAINOMEFAN',pic:'@!'},{av:'A173CpjPaiRazaoSoc',fld:'CPJPAIRAZAOSOC',pic:'@!'},{av:'A175CpjPaiMatricula',fld:'CPJPAIMATRICULA',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'A194CpjPaiCNPJ',fld:'CPJPAICNPJ',pic:'ZZZZZZZZZZZZZ9'},{av:'A195CpjPaiCNPJFormat',fld:'CPJPAICNPJFORMAT',pic:''},{av:'A185CpjPaiTipoSigla',fld:'CPJPAITIPOSIGLA',pic:''},{av:'A186CpjPaiTipoNome',fld:'CPJPAITIPONOME',pic:'@!'},{av:'dynavCpjtipoidfiltro'},{av:'AV36CpjTipoIdFiltro',fld:'vCPJTIPOIDFILTRO',pic:'ZZZ,ZZZ,ZZ9'}]");
         setEventMetadata("VALID_CPJPAIID",",oparms:[{av:'A172CpjPaiNomeFan',fld:'CPJPAINOMEFAN',pic:'@!'},{av:'A173CpjPaiRazaoSoc',fld:'CPJPAIRAZAOSOC',pic:'@!'},{av:'A175CpjPaiMatricula',fld:'CPJPAIMATRICULA',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'A194CpjPaiCNPJ',fld:'CPJPAICNPJ',pic:'ZZZZZZZZZZZZZ9'},{av:'A195CpjPaiCNPJFormat',fld:'CPJPAICNPJFORMAT',pic:''},{av:'A184CpjPaiTipoID',fld:'CPJPAITIPOID',pic:'ZZZ,ZZZ,ZZ9'},{av:'A185CpjPaiTipoSigla',fld:'CPJPAITIPOSIGLA',pic:''},{av:'A186CpjPaiTipoNome',fld:'CPJPAITIPONOME',pic:'@!'},{av:'dynavCpjtipoidfiltro'},{av:'AV36CpjTipoIdFiltro',fld:'vCPJTIPOIDFILTRO',pic:'ZZZ,ZZZ,ZZ9'}]}");
         setEventMetadata("VALID_CPJNOMEFAN","{handler:'Valid_Cpjnomefan',iparms:[{av:'dynavCpjtipoidfiltro'},{av:'AV36CpjTipoIdFiltro',fld:'vCPJTIPOIDFILTRO',pic:'ZZZ,ZZZ,ZZ9'}]");
         setEventMetadata("VALID_CPJNOMEFAN",",oparms:[{av:'dynavCpjtipoidfiltro'},{av:'AV36CpjTipoIdFiltro',fld:'vCPJTIPOIDFILTRO',pic:'ZZZ,ZZZ,ZZ9'}]}");
         setEventMetadata("VALID_CPJRAZAOSOC","{handler:'Valid_Cpjrazaosoc',iparms:[{av:'dynavCpjtipoidfiltro'},{av:'AV36CpjTipoIdFiltro',fld:'vCPJTIPOIDFILTRO',pic:'ZZZ,ZZZ,ZZ9'}]");
         setEventMetadata("VALID_CPJRAZAOSOC",",oparms:[{av:'dynavCpjtipoidfiltro'},{av:'AV36CpjTipoIdFiltro',fld:'vCPJTIPOIDFILTRO',pic:'ZZZ,ZZZ,ZZ9'}]}");
         setEventMetadata("VALID_CPJCNPJFORMAT","{handler:'Valid_Cpjcnpjformat',iparms:[{av:'A188CpjCNPJFormat',fld:'CPJCNPJFORMAT',pic:''},{av:'A187CpjCNPJ',fld:'CPJCNPJ',pic:'ZZZZZZZZZZZZZ9'},{av:'dynavCpjtipoidfiltro'},{av:'AV36CpjTipoIdFiltro',fld:'vCPJTIPOIDFILTRO',pic:'ZZZ,ZZZ,ZZ9'}]");
         setEventMetadata("VALID_CPJCNPJFORMAT",",oparms:[{av:'A187CpjCNPJ',fld:'CPJCNPJ',pic:'ZZZZZZZZZZZZZ9'},{av:'dynavCpjtipoidfiltro'},{av:'AV36CpjTipoIdFiltro',fld:'vCPJTIPOIDFILTRO',pic:'ZZZ,ZZZ,ZZ9'}]}");
         setEventMetadata("VALID_CPJIE","{handler:'Valid_Cpjie',iparms:[{av:'dynavCpjtipoidfiltro'},{av:'AV36CpjTipoIdFiltro',fld:'vCPJTIPOIDFILTRO',pic:'ZZZ,ZZZ,ZZ9'}]");
         setEventMetadata("VALID_CPJIE",",oparms:[{av:'dynavCpjtipoidfiltro'},{av:'AV36CpjTipoIdFiltro',fld:'vCPJTIPOIDFILTRO',pic:'ZZZ,ZZZ,ZZ9'}]}");
         setEventMetadata("VALID_CPJCAPITALSOC","{handler:'Valid_Cpjcapitalsoc',iparms:[{av:'dynavCpjtipoidfiltro'},{av:'AV36CpjTipoIdFiltro',fld:'vCPJTIPOIDFILTRO',pic:'ZZZ,ZZZ,ZZ9'}]");
         setEventMetadata("VALID_CPJCAPITALSOC",",oparms:[{av:'dynavCpjtipoidfiltro'},{av:'AV36CpjTipoIdFiltro',fld:'vCPJTIPOIDFILTRO',pic:'ZZZ,ZZZ,ZZ9'}]}");
         setEventMetadata("VALID_CPJWEBSITE","{handler:'Valid_Cpjwebsite',iparms:[{av:'dynavCpjtipoidfiltro'},{av:'AV36CpjTipoIdFiltro',fld:'vCPJTIPOIDFILTRO',pic:'ZZZ,ZZZ,ZZ9'}]");
         setEventMetadata("VALID_CPJWEBSITE",",oparms:[{av:'dynavCpjtipoidfiltro'},{av:'AV36CpjTipoIdFiltro',fld:'vCPJTIPOIDFILTRO',pic:'ZZZ,ZZZ,ZZ9'}]}");
         setEventMetadata("VALID_CPJEMAIL","{handler:'Valid_Cpjemail',iparms:[{av:'dynavCpjtipoidfiltro'},{av:'AV36CpjTipoIdFiltro',fld:'vCPJTIPOIDFILTRO',pic:'ZZZ,ZZZ,ZZ9'}]");
         setEventMetadata("VALID_CPJEMAIL",",oparms:[{av:'dynavCpjtipoidfiltro'},{av:'AV36CpjTipoIdFiltro',fld:'vCPJTIPOIDFILTRO',pic:'ZZZ,ZZZ,ZZ9'}]}");
         setEventMetadata("VALIDV_COMBOCPJTIPOID","{handler:'Validv_Combocpjtipoid',iparms:[{av:'dynavCpjtipoidfiltro'},{av:'AV36CpjTipoIdFiltro',fld:'vCPJTIPOIDFILTRO',pic:'ZZZ,ZZZ,ZZ9'}]");
         setEventMetadata("VALIDV_COMBOCPJTIPOID",",oparms:[{av:'dynavCpjtipoidfiltro'},{av:'AV36CpjTipoIdFiltro',fld:'vCPJTIPOIDFILTRO',pic:'ZZZ,ZZZ,ZZ9'}]}");
         setEventMetadata("VALIDV_COMBOCPJPAIID","{handler:'Validv_Combocpjpaiid',iparms:[{av:'dynavCpjtipoidfiltro'},{av:'AV36CpjTipoIdFiltro',fld:'vCPJTIPOIDFILTRO',pic:'ZZZ,ZZZ,ZZ9'}]");
         setEventMetadata("VALIDV_COMBOCPJPAIID",",oparms:[{av:'dynavCpjtipoidfiltro'},{av:'AV36CpjTipoIdFiltro',fld:'vCPJTIPOIDFILTRO',pic:'ZZZ,ZZZ,ZZ9'}]}");
         setEventMetadata("VALID_CPJID","{handler:'Valid_Cpjid',iparms:[{av:'dynavCpjtipoidfiltro'},{av:'AV36CpjTipoIdFiltro',fld:'vCPJTIPOIDFILTRO',pic:'ZZZ,ZZZ,ZZ9'}]");
         setEventMetadata("VALID_CPJID",",oparms:[{av:'dynavCpjtipoidfiltro'},{av:'AV36CpjTipoIdFiltro',fld:'vCPJTIPOIDFILTRO',pic:'ZZZ,ZZZ,ZZ9'}]}");
         setEventMetadata("VALID_CLIID","{handler:'Valid_Cliid',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'A158CliID',fld:'CLIID',pic:''},{av:'A160CliNomeFamiliar',fld:'CLINOMEFAMILIAR',pic:'@!'},{av:'Gx_BScreen',fld:'vGXBSCREEN',pic:'9'},{av:'A159CliMatricula',fld:'CLIMATRICULA',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'A170CpjNomeFan',fld:'CPJNOMEFAN',pic:'@!'},{av:'dynavCpjtipoidfiltro'},{av:'AV36CpjTipoIdFiltro',fld:'vCPJTIPOIDFILTRO',pic:'ZZZ,ZZZ,ZZ9'}]");
         setEventMetadata("VALID_CLIID",",oparms:[{av:'A159CliMatricula',fld:'CLIMATRICULA',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'A160CliNomeFamiliar',fld:'CLINOMEFAMILIAR',pic:'@!'},{av:'A170CpjNomeFan',fld:'CPJNOMEFAN',pic:'@!'},{av:'dynavCpjtipoidfiltro'},{av:'AV36CpjTipoIdFiltro',fld:'vCPJTIPOIDFILTRO',pic:'ZZZ,ZZZ,ZZ9'}]}");
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
         pr_default.close(31);
         pr_default.close(19);
         pr_default.close(32);
         pr_default.close(22);
         pr_default.close(23);
         pr_default.close(33);
         pr_default.close(20);
         pr_default.close(34);
         pr_default.close(21);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         wcpOAV7CliID = Guid.Empty;
         wcpOAV8CpjID = Guid.Empty;
         Z158CliID = Guid.Empty;
         Z166CpjID = Guid.Empty;
         Z189CpjIE = "";
         Z200CpjInsDataHora = (DateTime)(DateTime.MinValue);
         Z198CpjInsData = DateTime.MinValue;
         Z199CpjInsHora = (DateTime)(DateTime.MinValue);
         Z543CpjDelDataHora = (DateTime)(DateTime.MinValue);
         Z544CpjDelData = (DateTime)(DateTime.MinValue);
         Z545CpjDelHora = (DateTime)(DateTime.MinValue);
         Z546CpjDelUsuId = "";
         Z547CpjDelUsuNome = "";
         Z170CpjNomeFan = "";
         Z171CpjRazaoSoc = "";
         Z188CpjCNPJFormat = "";
         Z201CpjInsUserID = "";
         Z202CpjUpdData = DateTime.MinValue;
         Z203CpjUpdHora = (DateTime)(DateTime.MinValue);
         Z204CpjUpdDataHora = (DateTime)(DateTime.MinValue);
         Z205CpjUpdUserID = "";
         Z261CpjTelNum = "";
         Z262CpjTelRam = "";
         Z263CpjCelNum = "";
         Z264CpjWppNum = "";
         Z265CpjWebsite = "";
         Z266CpjEmail = "";
         Z181CpjHolID = Guid.Empty;
         Z169CpjPaiID = Guid.Empty;
         N181CpjHolID = Guid.Empty;
         N169CpjPaiID = Guid.Empty;
         Combo_cpjpaiid_Selectedvalue_get = "";
         Combo_cpjtipoid_Selectedvalue_get = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A188CpjCNPJFormat = "";
         A158CliID = Guid.Empty;
         A181CpjHolID = Guid.Empty;
         A169CpjPaiID = Guid.Empty;
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
         ucDvpanel_tableattributes = new GXUserControl();
         lblTextblockcpjtipoid_Jsonclick = "";
         ucCombo_cpjtipoid = new GXUserControl();
         AV17DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV24CpjTipoId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         TempTags = "";
         lblTextblockcpjpaiid_Jsonclick = "";
         ucCombo_cpjpaiid = new GXUserControl();
         AV29CpjPaiID_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A170CpjNomeFan = "";
         A171CpjRazaoSoc = "";
         A189CpjIE = "";
         gxphoneLink = "";
         A261CpjTelNum = "";
         A262CpjTelRam = "";
         A263CpjCelNum = "";
         A264CpjWppNum = "";
         A265CpjWebsite = "";
         A266CpjEmail = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         AV30ComboCpjPaiID = Guid.Empty;
         A166CpjID = Guid.Empty;
         A366CpjTipoSigla = "";
         A367CpjTipoNome = "";
         A543CpjDelDataHora = (DateTime)(DateTime.MinValue);
         A544CpjDelData = (DateTime)(DateTime.MinValue);
         A545CpjDelHora = (DateTime)(DateTime.MinValue);
         A546CpjDelUsuId = "";
         A547CpjDelUsuNome = "";
         A201CpjInsUserID = "";
         A202CpjUpdData = DateTime.MinValue;
         A203CpjUpdHora = (DateTime)(DateTime.MinValue);
         A204CpjUpdDataHora = (DateTime)(DateTime.MinValue);
         A205CpjUpdUserID = "";
         A200CpjInsDataHora = (DateTime)(DateTime.MinValue);
         A198CpjInsData = DateTime.MinValue;
         A199CpjInsHora = (DateTime)(DateTime.MinValue);
         AV28Insert_CpjHolID = Guid.Empty;
         AV27Insert_CpjPaiID = Guid.Empty;
         AV39AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
         A182CpjHolNomeFan = "";
         A183CpjHolRazaoSoc = "";
         A193CpjHolCNPJFormat = "";
         A172CpjPaiNomeFan = "";
         A173CpjPaiRazaoSoc = "";
         A195CpjPaiCNPJFormat = "";
         A185CpjPaiTipoSigla = "";
         A186CpjPaiTipoNome = "";
         AV41Pgmname = "";
         Dvpanel_tablecliente_Objectcall = "";
         Dvpanel_tablecliente_Class = "";
         Dvpanel_tablecliente_Height = "";
         Combo_cpjtipoid_Objectcall = "";
         Combo_cpjtipoid_Class = "";
         Combo_cpjtipoid_Icontype = "";
         Combo_cpjtipoid_Icon = "";
         Combo_cpjtipoid_Tooltip = "";
         Combo_cpjtipoid_Selectedvalue_set = "";
         Combo_cpjtipoid_Selectedtext_set = "";
         Combo_cpjtipoid_Selectedtext_get = "";
         Combo_cpjtipoid_Gamoauthtoken = "";
         Combo_cpjtipoid_Ddointernalname = "";
         Combo_cpjtipoid_Titlecontrolalign = "";
         Combo_cpjtipoid_Dropdownoptionstype = "";
         Combo_cpjtipoid_Titlecontrolidtoreplace = "";
         Combo_cpjtipoid_Datalisttype = "";
         Combo_cpjtipoid_Datalistfixedvalues = "";
         Combo_cpjtipoid_Datalistproc = "";
         Combo_cpjtipoid_Datalistprocparametersprefix = "";
         Combo_cpjtipoid_Remoteservicesparameters = "";
         Combo_cpjtipoid_Htmltemplate = "";
         Combo_cpjtipoid_Multiplevaluestype = "";
         Combo_cpjtipoid_Loadingdata = "";
         Combo_cpjtipoid_Noresultsfound = "";
         Combo_cpjtipoid_Onlyselectedvalues = "";
         Combo_cpjtipoid_Selectalltext = "";
         Combo_cpjtipoid_Multiplevaluesseparator = "";
         Combo_cpjtipoid_Addnewoptiontext = "";
         Combo_cpjpaiid_Objectcall = "";
         Combo_cpjpaiid_Class = "";
         Combo_cpjpaiid_Icontype = "";
         Combo_cpjpaiid_Icon = "";
         Combo_cpjpaiid_Tooltip = "";
         Combo_cpjpaiid_Selectedvalue_set = "";
         Combo_cpjpaiid_Selectedtext_set = "";
         Combo_cpjpaiid_Selectedtext_get = "";
         Combo_cpjpaiid_Gamoauthtoken = "";
         Combo_cpjpaiid_Ddointernalname = "";
         Combo_cpjpaiid_Titlecontrolalign = "";
         Combo_cpjpaiid_Dropdownoptionstype = "";
         Combo_cpjpaiid_Titlecontrolidtoreplace = "";
         Combo_cpjpaiid_Datalisttype = "";
         Combo_cpjpaiid_Datalistfixedvalues = "";
         Combo_cpjpaiid_Remoteservicesparameters = "";
         Combo_cpjpaiid_Multiplevaluestype = "";
         Combo_cpjpaiid_Loadingdata = "";
         Combo_cpjpaiid_Noresultsfound = "";
         Combo_cpjpaiid_Onlyselectedvalues = "";
         Combo_cpjpaiid_Selectalltext = "";
         Combo_cpjpaiid_Multiplevaluesseparator = "";
         Combo_cpjpaiid_Addnewoptiontext = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode25 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV13WebSession = context.GetSession();
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV22GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV23GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV12TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV15TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV20Combo_DataJson = "";
         AV18ComboSelectedValue = "";
         AV19ComboSelectedText = "";
         Z160CliNomeFamiliar = "";
         Z182CpjHolNomeFan = "";
         Z183CpjHolRazaoSoc = "";
         Z193CpjHolCNPJFormat = "";
         Z172CpjPaiNomeFan = "";
         Z173CpjPaiRazaoSoc = "";
         Z195CpjPaiCNPJFormat = "";
         Z185CpjPaiTipoSigla = "";
         Z186CpjPaiTipoNome = "";
         Z366CpjTipoSigla = "";
         Z367CpjTipoNome = "";
         T000P4_A159CliMatricula = new long[1] ;
         T000P4_A160CliNomeFamiliar = new string[] {""} ;
         T000P6_A182CpjHolNomeFan = new string[] {""} ;
         T000P6_A183CpjHolRazaoSoc = new string[] {""} ;
         T000P6_A191CpjHolMatricula = new long[1] ;
         T000P6_A192CpjHolCNPJ = new long[1] ;
         T000P6_A193CpjHolCNPJFormat = new string[] {""} ;
         T000P5_A366CpjTipoSigla = new string[] {""} ;
         T000P5_A367CpjTipoNome = new string[] {""} ;
         T000P7_A172CpjPaiNomeFan = new string[] {""} ;
         T000P7_A173CpjPaiRazaoSoc = new string[] {""} ;
         T000P7_A175CpjPaiMatricula = new long[1] ;
         T000P7_A194CpjPaiCNPJ = new long[1] ;
         T000P7_A195CpjPaiCNPJFormat = new string[] {""} ;
         T000P7_A184CpjPaiTipoID = new int[1] ;
         T000P8_A185CpjPaiTipoSigla = new string[] {""} ;
         T000P8_A186CpjPaiTipoNome = new string[] {""} ;
         T000P9_A166CpjID = new Guid[] {Guid.Empty} ;
         T000P9_A187CpjCNPJ = new long[1] ;
         T000P9_A189CpjIE = new string[] {""} ;
         T000P9_A176CpjMatricula = new long[1] ;
         T000P9_A200CpjInsDataHora = new DateTime[] {DateTime.MinValue} ;
         T000P9_A198CpjInsData = new DateTime[] {DateTime.MinValue} ;
         T000P9_A199CpjInsHora = new DateTime[] {DateTime.MinValue} ;
         T000P9_A543CpjDelDataHora = new DateTime[] {DateTime.MinValue} ;
         T000P9_n543CpjDelDataHora = new bool[] {false} ;
         T000P9_A544CpjDelData = new DateTime[] {DateTime.MinValue} ;
         T000P9_n544CpjDelData = new bool[] {false} ;
         T000P9_A545CpjDelHora = new DateTime[] {DateTime.MinValue} ;
         T000P9_n545CpjDelHora = new bool[] {false} ;
         T000P9_A546CpjDelUsuId = new string[] {""} ;
         T000P9_n546CpjDelUsuId = new bool[] {false} ;
         T000P9_A547CpjDelUsuNome = new string[] {""} ;
         T000P9_n547CpjDelUsuNome = new bool[] {false} ;
         T000P9_A159CliMatricula = new long[1] ;
         T000P9_A160CliNomeFamiliar = new string[] {""} ;
         T000P9_A182CpjHolNomeFan = new string[] {""} ;
         T000P9_A183CpjHolRazaoSoc = new string[] {""} ;
         T000P9_A191CpjHolMatricula = new long[1] ;
         T000P9_A192CpjHolCNPJ = new long[1] ;
         T000P9_A193CpjHolCNPJFormat = new string[] {""} ;
         T000P9_A172CpjPaiNomeFan = new string[] {""} ;
         T000P9_A173CpjPaiRazaoSoc = new string[] {""} ;
         T000P9_A175CpjPaiMatricula = new long[1] ;
         T000P9_A194CpjPaiCNPJ = new long[1] ;
         T000P9_A195CpjPaiCNPJFormat = new string[] {""} ;
         T000P9_A185CpjPaiTipoSigla = new string[] {""} ;
         T000P9_A186CpjPaiTipoNome = new string[] {""} ;
         T000P9_A366CpjTipoSigla = new string[] {""} ;
         T000P9_A367CpjTipoNome = new string[] {""} ;
         T000P9_A170CpjNomeFan = new string[] {""} ;
         T000P9_A171CpjRazaoSoc = new string[] {""} ;
         T000P9_A188CpjCNPJFormat = new string[] {""} ;
         T000P9_A190CpjCapitalSoc = new decimal[1] ;
         T000P9_A201CpjInsUserID = new string[] {""} ;
         T000P9_n201CpjInsUserID = new bool[] {false} ;
         T000P9_A202CpjUpdData = new DateTime[] {DateTime.MinValue} ;
         T000P9_n202CpjUpdData = new bool[] {false} ;
         T000P9_A203CpjUpdHora = new DateTime[] {DateTime.MinValue} ;
         T000P9_n203CpjUpdHora = new bool[] {false} ;
         T000P9_A204CpjUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         T000P9_n204CpjUpdDataHora = new bool[] {false} ;
         T000P9_A205CpjUpdUserID = new string[] {""} ;
         T000P9_n205CpjUpdUserID = new bool[] {false} ;
         T000P9_A206CpjVersao = new short[1] ;
         T000P9_A207CpjAtivo = new bool[] {false} ;
         T000P9_A261CpjTelNum = new string[] {""} ;
         T000P9_n261CpjTelNum = new bool[] {false} ;
         T000P9_A262CpjTelRam = new string[] {""} ;
         T000P9_n262CpjTelRam = new bool[] {false} ;
         T000P9_A263CpjCelNum = new string[] {""} ;
         T000P9_n263CpjCelNum = new bool[] {false} ;
         T000P9_A264CpjWppNum = new string[] {""} ;
         T000P9_n264CpjWppNum = new bool[] {false} ;
         T000P9_A265CpjWebsite = new string[] {""} ;
         T000P9_n265CpjWebsite = new bool[] {false} ;
         T000P9_A266CpjEmail = new string[] {""} ;
         T000P9_n266CpjEmail = new bool[] {false} ;
         T000P9_A542CpjDel = new bool[] {false} ;
         T000P9_A158CliID = new Guid[] {Guid.Empty} ;
         T000P9_A365CpjTipoId = new int[1] ;
         T000P9_A181CpjHolID = new Guid[] {Guid.Empty} ;
         T000P9_n181CpjHolID = new bool[] {false} ;
         T000P9_A169CpjPaiID = new Guid[] {Guid.Empty} ;
         T000P9_n169CpjPaiID = new bool[] {false} ;
         T000P9_A184CpjPaiTipoID = new int[1] ;
         T000P10_A159CliMatricula = new long[1] ;
         T000P10_A160CliNomeFamiliar = new string[] {""} ;
         T000P11_A182CpjHolNomeFan = new string[] {""} ;
         T000P11_A183CpjHolRazaoSoc = new string[] {""} ;
         T000P11_A191CpjHolMatricula = new long[1] ;
         T000P11_A192CpjHolCNPJ = new long[1] ;
         T000P11_A193CpjHolCNPJFormat = new string[] {""} ;
         T000P12_A172CpjPaiNomeFan = new string[] {""} ;
         T000P12_A173CpjPaiRazaoSoc = new string[] {""} ;
         T000P12_A175CpjPaiMatricula = new long[1] ;
         T000P12_A194CpjPaiCNPJ = new long[1] ;
         T000P12_A195CpjPaiCNPJFormat = new string[] {""} ;
         T000P12_A184CpjPaiTipoID = new int[1] ;
         T000P13_A185CpjPaiTipoSigla = new string[] {""} ;
         T000P13_A186CpjPaiTipoNome = new string[] {""} ;
         T000P14_A366CpjTipoSigla = new string[] {""} ;
         T000P14_A367CpjTipoNome = new string[] {""} ;
         T000P15_A158CliID = new Guid[] {Guid.Empty} ;
         T000P15_A166CpjID = new Guid[] {Guid.Empty} ;
         T000P3_A166CpjID = new Guid[] {Guid.Empty} ;
         T000P3_A187CpjCNPJ = new long[1] ;
         T000P3_A189CpjIE = new string[] {""} ;
         T000P3_A176CpjMatricula = new long[1] ;
         T000P3_A200CpjInsDataHora = new DateTime[] {DateTime.MinValue} ;
         T000P3_A198CpjInsData = new DateTime[] {DateTime.MinValue} ;
         T000P3_A199CpjInsHora = new DateTime[] {DateTime.MinValue} ;
         T000P3_A543CpjDelDataHora = new DateTime[] {DateTime.MinValue} ;
         T000P3_n543CpjDelDataHora = new bool[] {false} ;
         T000P3_A544CpjDelData = new DateTime[] {DateTime.MinValue} ;
         T000P3_n544CpjDelData = new bool[] {false} ;
         T000P3_A545CpjDelHora = new DateTime[] {DateTime.MinValue} ;
         T000P3_n545CpjDelHora = new bool[] {false} ;
         T000P3_A546CpjDelUsuId = new string[] {""} ;
         T000P3_n546CpjDelUsuId = new bool[] {false} ;
         T000P3_A547CpjDelUsuNome = new string[] {""} ;
         T000P3_n547CpjDelUsuNome = new bool[] {false} ;
         T000P3_A170CpjNomeFan = new string[] {""} ;
         T000P3_A171CpjRazaoSoc = new string[] {""} ;
         T000P3_A188CpjCNPJFormat = new string[] {""} ;
         T000P3_A190CpjCapitalSoc = new decimal[1] ;
         T000P3_A201CpjInsUserID = new string[] {""} ;
         T000P3_n201CpjInsUserID = new bool[] {false} ;
         T000P3_A202CpjUpdData = new DateTime[] {DateTime.MinValue} ;
         T000P3_n202CpjUpdData = new bool[] {false} ;
         T000P3_A203CpjUpdHora = new DateTime[] {DateTime.MinValue} ;
         T000P3_n203CpjUpdHora = new bool[] {false} ;
         T000P3_A204CpjUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         T000P3_n204CpjUpdDataHora = new bool[] {false} ;
         T000P3_A205CpjUpdUserID = new string[] {""} ;
         T000P3_n205CpjUpdUserID = new bool[] {false} ;
         T000P3_A206CpjVersao = new short[1] ;
         T000P3_A207CpjAtivo = new bool[] {false} ;
         T000P3_A261CpjTelNum = new string[] {""} ;
         T000P3_n261CpjTelNum = new bool[] {false} ;
         T000P3_A262CpjTelRam = new string[] {""} ;
         T000P3_n262CpjTelRam = new bool[] {false} ;
         T000P3_A263CpjCelNum = new string[] {""} ;
         T000P3_n263CpjCelNum = new bool[] {false} ;
         T000P3_A264CpjWppNum = new string[] {""} ;
         T000P3_n264CpjWppNum = new bool[] {false} ;
         T000P3_A265CpjWebsite = new string[] {""} ;
         T000P3_n265CpjWebsite = new bool[] {false} ;
         T000P3_A266CpjEmail = new string[] {""} ;
         T000P3_n266CpjEmail = new bool[] {false} ;
         T000P3_A542CpjDel = new bool[] {false} ;
         T000P3_A158CliID = new Guid[] {Guid.Empty} ;
         T000P3_A365CpjTipoId = new int[1] ;
         T000P3_A181CpjHolID = new Guid[] {Guid.Empty} ;
         T000P3_n181CpjHolID = new bool[] {false} ;
         T000P3_A169CpjPaiID = new Guid[] {Guid.Empty} ;
         T000P3_n169CpjPaiID = new bool[] {false} ;
         T000P16_A158CliID = new Guid[] {Guid.Empty} ;
         T000P16_A166CpjID = new Guid[] {Guid.Empty} ;
         T000P17_A158CliID = new Guid[] {Guid.Empty} ;
         T000P17_A166CpjID = new Guid[] {Guid.Empty} ;
         T000P2_A166CpjID = new Guid[] {Guid.Empty} ;
         T000P2_A187CpjCNPJ = new long[1] ;
         T000P2_A189CpjIE = new string[] {""} ;
         T000P2_A176CpjMatricula = new long[1] ;
         T000P2_A200CpjInsDataHora = new DateTime[] {DateTime.MinValue} ;
         T000P2_A198CpjInsData = new DateTime[] {DateTime.MinValue} ;
         T000P2_A199CpjInsHora = new DateTime[] {DateTime.MinValue} ;
         T000P2_A543CpjDelDataHora = new DateTime[] {DateTime.MinValue} ;
         T000P2_n543CpjDelDataHora = new bool[] {false} ;
         T000P2_A544CpjDelData = new DateTime[] {DateTime.MinValue} ;
         T000P2_n544CpjDelData = new bool[] {false} ;
         T000P2_A545CpjDelHora = new DateTime[] {DateTime.MinValue} ;
         T000P2_n545CpjDelHora = new bool[] {false} ;
         T000P2_A546CpjDelUsuId = new string[] {""} ;
         T000P2_n546CpjDelUsuId = new bool[] {false} ;
         T000P2_A547CpjDelUsuNome = new string[] {""} ;
         T000P2_n547CpjDelUsuNome = new bool[] {false} ;
         T000P2_A170CpjNomeFan = new string[] {""} ;
         T000P2_A171CpjRazaoSoc = new string[] {""} ;
         T000P2_A188CpjCNPJFormat = new string[] {""} ;
         T000P2_A190CpjCapitalSoc = new decimal[1] ;
         T000P2_A201CpjInsUserID = new string[] {""} ;
         T000P2_n201CpjInsUserID = new bool[] {false} ;
         T000P2_A202CpjUpdData = new DateTime[] {DateTime.MinValue} ;
         T000P2_n202CpjUpdData = new bool[] {false} ;
         T000P2_A203CpjUpdHora = new DateTime[] {DateTime.MinValue} ;
         T000P2_n203CpjUpdHora = new bool[] {false} ;
         T000P2_A204CpjUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         T000P2_n204CpjUpdDataHora = new bool[] {false} ;
         T000P2_A205CpjUpdUserID = new string[] {""} ;
         T000P2_n205CpjUpdUserID = new bool[] {false} ;
         T000P2_A206CpjVersao = new short[1] ;
         T000P2_A207CpjAtivo = new bool[] {false} ;
         T000P2_A261CpjTelNum = new string[] {""} ;
         T000P2_n261CpjTelNum = new bool[] {false} ;
         T000P2_A262CpjTelRam = new string[] {""} ;
         T000P2_n262CpjTelRam = new bool[] {false} ;
         T000P2_A263CpjCelNum = new string[] {""} ;
         T000P2_n263CpjCelNum = new bool[] {false} ;
         T000P2_A264CpjWppNum = new string[] {""} ;
         T000P2_n264CpjWppNum = new bool[] {false} ;
         T000P2_A265CpjWebsite = new string[] {""} ;
         T000P2_n265CpjWebsite = new bool[] {false} ;
         T000P2_A266CpjEmail = new string[] {""} ;
         T000P2_n266CpjEmail = new bool[] {false} ;
         T000P2_A542CpjDel = new bool[] {false} ;
         T000P2_A158CliID = new Guid[] {Guid.Empty} ;
         T000P2_A365CpjTipoId = new int[1] ;
         T000P2_A181CpjHolID = new Guid[] {Guid.Empty} ;
         T000P2_n181CpjHolID = new bool[] {false} ;
         T000P2_A169CpjPaiID = new Guid[] {Guid.Empty} ;
         T000P2_n169CpjPaiID = new bool[] {false} ;
         T000P21_A159CliMatricula = new long[1] ;
         T000P21_A160CliNomeFamiliar = new string[] {""} ;
         T000P22_A172CpjPaiNomeFan = new string[] {""} ;
         T000P22_A173CpjPaiRazaoSoc = new string[] {""} ;
         T000P22_A175CpjPaiMatricula = new long[1] ;
         T000P22_A194CpjPaiCNPJ = new long[1] ;
         T000P22_A195CpjPaiCNPJFormat = new string[] {""} ;
         T000P22_A184CpjPaiTipoID = new int[1] ;
         T000P23_A185CpjPaiTipoSigla = new string[] {""} ;
         T000P23_A186CpjPaiTipoNome = new string[] {""} ;
         T000P24_A366CpjTipoSigla = new string[] {""} ;
         T000P24_A367CpjTipoNome = new string[] {""} ;
         T000P25_A182CpjHolNomeFan = new string[] {""} ;
         T000P25_A183CpjHolRazaoSoc = new string[] {""} ;
         T000P25_A191CpjHolMatricula = new long[1] ;
         T000P25_A192CpjHolCNPJ = new long[1] ;
         T000P25_A193CpjHolCNPJFormat = new string[] {""} ;
         T000P26_A158CliID = new Guid[] {Guid.Empty} ;
         T000P26_A169CpjPaiID = new Guid[] {Guid.Empty} ;
         T000P26_n169CpjPaiID = new bool[] {false} ;
         T000P27_A158CliID = new Guid[] {Guid.Empty} ;
         T000P27_A181CpjHolID = new Guid[] {Guid.Empty} ;
         T000P27_n181CpjHolID = new bool[] {false} ;
         T000P28_A345NegID = new Guid[] {Guid.Empty} ;
         T000P29_A158CliID = new Guid[] {Guid.Empty} ;
         T000P29_A166CpjID = new Guid[] {Guid.Empty} ;
         T000P29_A269CpjConSeq = new short[1] ;
         T000P30_A158CliID = new Guid[] {Guid.Empty} ;
         T000P30_A166CpjID = new Guid[] {Guid.Empty} ;
         T000P30_A248CpjEndSeq = new short[1] ;
         T000P31_A158CliID = new Guid[] {Guid.Empty} ;
         T000P31_A166CpjID = new Guid[] {Guid.Empty} ;
         AV37GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         T000P32_A155PjtID = new int[1] ;
         T000P32_A157PjtNome = new string[] {""} ;
         T000P33_A159CliMatricula = new long[1] ;
         T000P33_A160CliNomeFamiliar = new string[] {""} ;
         T000P34_A366CpjTipoSigla = new string[] {""} ;
         T000P34_A367CpjTipoNome = new string[] {""} ;
         T000P35_A172CpjPaiNomeFan = new string[] {""} ;
         T000P35_A173CpjPaiRazaoSoc = new string[] {""} ;
         T000P35_A175CpjPaiMatricula = new long[1] ;
         T000P35_A194CpjPaiCNPJ = new long[1] ;
         T000P35_A195CpjPaiCNPJFormat = new string[] {""} ;
         T000P35_A184CpjPaiTipoID = new int[1] ;
         T000P36_A185CpjPaiTipoSigla = new string[] {""} ;
         T000P36_A186CpjPaiTipoNome = new string[] {""} ;
         GXt_char2 = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.core.clientepj__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.clientepj__default(),
            new Object[][] {
                new Object[] {
               T000P2_A166CpjID, T000P2_A187CpjCNPJ, T000P2_A189CpjIE, T000P2_A176CpjMatricula, T000P2_A200CpjInsDataHora, T000P2_A198CpjInsData, T000P2_A199CpjInsHora, T000P2_A543CpjDelDataHora, T000P2_n543CpjDelDataHora, T000P2_A544CpjDelData,
               T000P2_n544CpjDelData, T000P2_A545CpjDelHora, T000P2_n545CpjDelHora, T000P2_A546CpjDelUsuId, T000P2_n546CpjDelUsuId, T000P2_A547CpjDelUsuNome, T000P2_n547CpjDelUsuNome, T000P2_A170CpjNomeFan, T000P2_A171CpjRazaoSoc, T000P2_A188CpjCNPJFormat,
               T000P2_A190CpjCapitalSoc, T000P2_A201CpjInsUserID, T000P2_n201CpjInsUserID, T000P2_A202CpjUpdData, T000P2_n202CpjUpdData, T000P2_A203CpjUpdHora, T000P2_n203CpjUpdHora, T000P2_A204CpjUpdDataHora, T000P2_n204CpjUpdDataHora, T000P2_A205CpjUpdUserID,
               T000P2_n205CpjUpdUserID, T000P2_A206CpjVersao, T000P2_A207CpjAtivo, T000P2_A261CpjTelNum, T000P2_n261CpjTelNum, T000P2_A262CpjTelRam, T000P2_n262CpjTelRam, T000P2_A263CpjCelNum, T000P2_n263CpjCelNum, T000P2_A264CpjWppNum,
               T000P2_n264CpjWppNum, T000P2_A265CpjWebsite, T000P2_n265CpjWebsite, T000P2_A266CpjEmail, T000P2_n266CpjEmail, T000P2_A542CpjDel, T000P2_A158CliID, T000P2_A365CpjTipoId, T000P2_A181CpjHolID, T000P2_n181CpjHolID,
               T000P2_A169CpjPaiID, T000P2_n169CpjPaiID
               }
               , new Object[] {
               T000P3_A166CpjID, T000P3_A187CpjCNPJ, T000P3_A189CpjIE, T000P3_A176CpjMatricula, T000P3_A200CpjInsDataHora, T000P3_A198CpjInsData, T000P3_A199CpjInsHora, T000P3_A543CpjDelDataHora, T000P3_n543CpjDelDataHora, T000P3_A544CpjDelData,
               T000P3_n544CpjDelData, T000P3_A545CpjDelHora, T000P3_n545CpjDelHora, T000P3_A546CpjDelUsuId, T000P3_n546CpjDelUsuId, T000P3_A547CpjDelUsuNome, T000P3_n547CpjDelUsuNome, T000P3_A170CpjNomeFan, T000P3_A171CpjRazaoSoc, T000P3_A188CpjCNPJFormat,
               T000P3_A190CpjCapitalSoc, T000P3_A201CpjInsUserID, T000P3_n201CpjInsUserID, T000P3_A202CpjUpdData, T000P3_n202CpjUpdData, T000P3_A203CpjUpdHora, T000P3_n203CpjUpdHora, T000P3_A204CpjUpdDataHora, T000P3_n204CpjUpdDataHora, T000P3_A205CpjUpdUserID,
               T000P3_n205CpjUpdUserID, T000P3_A206CpjVersao, T000P3_A207CpjAtivo, T000P3_A261CpjTelNum, T000P3_n261CpjTelNum, T000P3_A262CpjTelRam, T000P3_n262CpjTelRam, T000P3_A263CpjCelNum, T000P3_n263CpjCelNum, T000P3_A264CpjWppNum,
               T000P3_n264CpjWppNum, T000P3_A265CpjWebsite, T000P3_n265CpjWebsite, T000P3_A266CpjEmail, T000P3_n266CpjEmail, T000P3_A542CpjDel, T000P3_A158CliID, T000P3_A365CpjTipoId, T000P3_A181CpjHolID, T000P3_n181CpjHolID,
               T000P3_A169CpjPaiID, T000P3_n169CpjPaiID
               }
               , new Object[] {
               T000P4_A159CliMatricula, T000P4_A160CliNomeFamiliar
               }
               , new Object[] {
               T000P5_A366CpjTipoSigla, T000P5_A367CpjTipoNome
               }
               , new Object[] {
               T000P6_A182CpjHolNomeFan, T000P6_A183CpjHolRazaoSoc, T000P6_A191CpjHolMatricula, T000P6_A192CpjHolCNPJ, T000P6_A193CpjHolCNPJFormat
               }
               , new Object[] {
               T000P7_A172CpjPaiNomeFan, T000P7_A173CpjPaiRazaoSoc, T000P7_A175CpjPaiMatricula, T000P7_A194CpjPaiCNPJ, T000P7_A195CpjPaiCNPJFormat, T000P7_A184CpjPaiTipoID
               }
               , new Object[] {
               T000P8_A185CpjPaiTipoSigla, T000P8_A186CpjPaiTipoNome
               }
               , new Object[] {
               T000P9_A166CpjID, T000P9_A187CpjCNPJ, T000P9_A189CpjIE, T000P9_A176CpjMatricula, T000P9_A200CpjInsDataHora, T000P9_A198CpjInsData, T000P9_A199CpjInsHora, T000P9_A543CpjDelDataHora, T000P9_n543CpjDelDataHora, T000P9_A544CpjDelData,
               T000P9_n544CpjDelData, T000P9_A545CpjDelHora, T000P9_n545CpjDelHora, T000P9_A546CpjDelUsuId, T000P9_n546CpjDelUsuId, T000P9_A547CpjDelUsuNome, T000P9_n547CpjDelUsuNome, T000P9_A159CliMatricula, T000P9_A160CliNomeFamiliar, T000P9_A182CpjHolNomeFan,
               T000P9_A183CpjHolRazaoSoc, T000P9_A191CpjHolMatricula, T000P9_A192CpjHolCNPJ, T000P9_A193CpjHolCNPJFormat, T000P9_A172CpjPaiNomeFan, T000P9_A173CpjPaiRazaoSoc, T000P9_A175CpjPaiMatricula, T000P9_A194CpjPaiCNPJ, T000P9_A195CpjPaiCNPJFormat, T000P9_A185CpjPaiTipoSigla,
               T000P9_A186CpjPaiTipoNome, T000P9_A366CpjTipoSigla, T000P9_A367CpjTipoNome, T000P9_A170CpjNomeFan, T000P9_A171CpjRazaoSoc, T000P9_A188CpjCNPJFormat, T000P9_A190CpjCapitalSoc, T000P9_A201CpjInsUserID, T000P9_n201CpjInsUserID, T000P9_A202CpjUpdData,
               T000P9_n202CpjUpdData, T000P9_A203CpjUpdHora, T000P9_n203CpjUpdHora, T000P9_A204CpjUpdDataHora, T000P9_n204CpjUpdDataHora, T000P9_A205CpjUpdUserID, T000P9_n205CpjUpdUserID, T000P9_A206CpjVersao, T000P9_A207CpjAtivo, T000P9_A261CpjTelNum,
               T000P9_n261CpjTelNum, T000P9_A262CpjTelRam, T000P9_n262CpjTelRam, T000P9_A263CpjCelNum, T000P9_n263CpjCelNum, T000P9_A264CpjWppNum, T000P9_n264CpjWppNum, T000P9_A265CpjWebsite, T000P9_n265CpjWebsite, T000P9_A266CpjEmail,
               T000P9_n266CpjEmail, T000P9_A542CpjDel, T000P9_A158CliID, T000P9_A365CpjTipoId, T000P9_A181CpjHolID, T000P9_n181CpjHolID, T000P9_A169CpjPaiID, T000P9_n169CpjPaiID, T000P9_A184CpjPaiTipoID
               }
               , new Object[] {
               T000P10_A159CliMatricula, T000P10_A160CliNomeFamiliar
               }
               , new Object[] {
               T000P11_A182CpjHolNomeFan, T000P11_A183CpjHolRazaoSoc, T000P11_A191CpjHolMatricula, T000P11_A192CpjHolCNPJ, T000P11_A193CpjHolCNPJFormat
               }
               , new Object[] {
               T000P12_A172CpjPaiNomeFan, T000P12_A173CpjPaiRazaoSoc, T000P12_A175CpjPaiMatricula, T000P12_A194CpjPaiCNPJ, T000P12_A195CpjPaiCNPJFormat, T000P12_A184CpjPaiTipoID
               }
               , new Object[] {
               T000P13_A185CpjPaiTipoSigla, T000P13_A186CpjPaiTipoNome
               }
               , new Object[] {
               T000P14_A366CpjTipoSigla, T000P14_A367CpjTipoNome
               }
               , new Object[] {
               T000P15_A158CliID, T000P15_A166CpjID
               }
               , new Object[] {
               T000P16_A158CliID, T000P16_A166CpjID
               }
               , new Object[] {
               T000P17_A158CliID, T000P17_A166CpjID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000P21_A159CliMatricula, T000P21_A160CliNomeFamiliar
               }
               , new Object[] {
               T000P22_A172CpjPaiNomeFan, T000P22_A173CpjPaiRazaoSoc, T000P22_A175CpjPaiMatricula, T000P22_A194CpjPaiCNPJ, T000P22_A195CpjPaiCNPJFormat, T000P22_A184CpjPaiTipoID
               }
               , new Object[] {
               T000P23_A185CpjPaiTipoSigla, T000P23_A186CpjPaiTipoNome
               }
               , new Object[] {
               T000P24_A366CpjTipoSigla, T000P24_A367CpjTipoNome
               }
               , new Object[] {
               T000P25_A182CpjHolNomeFan, T000P25_A183CpjHolRazaoSoc, T000P25_A191CpjHolMatricula, T000P25_A192CpjHolCNPJ, T000P25_A193CpjHolCNPJFormat
               }
               , new Object[] {
               T000P26_A158CliID, T000P26_A169CpjPaiID
               }
               , new Object[] {
               T000P27_A158CliID, T000P27_A181CpjHolID
               }
               , new Object[] {
               T000P28_A345NegID
               }
               , new Object[] {
               T000P29_A158CliID, T000P29_A166CpjID, T000P29_A269CpjConSeq
               }
               , new Object[] {
               T000P30_A158CliID, T000P30_A166CpjID, T000P30_A248CpjEndSeq
               }
               , new Object[] {
               T000P31_A158CliID, T000P31_A166CpjID
               }
               , new Object[] {
               T000P32_A155PjtID, T000P32_A157PjtNome
               }
               , new Object[] {
               T000P33_A159CliMatricula, T000P33_A160CliNomeFamiliar
               }
               , new Object[] {
               T000P34_A366CpjTipoSigla, T000P34_A367CpjTipoNome
               }
               , new Object[] {
               T000P35_A172CpjPaiNomeFan, T000P35_A173CpjPaiRazaoSoc, T000P35_A175CpjPaiMatricula, T000P35_A194CpjPaiCNPJ, T000P35_A195CpjPaiCNPJFormat, T000P35_A184CpjPaiTipoID
               }
               , new Object[] {
               T000P36_A185CpjPaiTipoSigla, T000P36_A186CpjPaiTipoNome
               }
            }
         );
         Z207CpjAtivo = true;
         A207CpjAtivo = true;
         i207CpjAtivo = true;
         Z206CpjVersao = 1;
         A206CpjVersao = 1;
         i206CpjVersao = 1;
         Z166CpjID = Guid.NewGuid( );
         A166CpjID = Guid.NewGuid( );
         AV41Pgmname = "core.ClientePJ";
         Z170CpjNomeFan = "";
         A170CpjNomeFan = "";
      }

      private short Z206CpjVersao ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A206CpjVersao ;
      private short Gx_BScreen ;
      private short RcdFound25 ;
      private short GX_JID ;
      private short nIsDirty_25 ;
      private short gxajaxcallmode ;
      private short i206CpjVersao ;
      private int Z365CpjTipoId ;
      private int N365CpjTipoId ;
      private int A184CpjPaiTipoID ;
      private int A365CpjTipoId ;
      private int trnEnded ;
      private int AV36CpjTipoIdFiltro ;
      private int edtCliNomeFamiliar_Enabled ;
      private int edtCliMatricula_Enabled ;
      private int edtCpjTipoId_Visible ;
      private int edtCpjTipoId_Enabled ;
      private int edtCpjPaiID_Visible ;
      private int edtCpjPaiID_Enabled ;
      private int edtCpjNomeFan_Enabled ;
      private int edtCpjRazaoSoc_Enabled ;
      private int edtCpjMatricula_Enabled ;
      private int edtCpjCNPJFormat_Enabled ;
      private int edtCpjIE_Enabled ;
      private int edtCpjCapitalSoc_Enabled ;
      private int edtCpjTelNum_Enabled ;
      private int edtCpjTelRam_Enabled ;
      private int edtCpjCelNum_Enabled ;
      private int edtCpjWppNum_Enabled ;
      private int edtCpjWebsite_Enabled ;
      private int edtCpjEmail_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int AV25ComboCpjTipoId ;
      private int edtavCombocpjtipoid_Enabled ;
      private int edtavCombocpjtipoid_Visible ;
      private int edtavCombocpjpaiid_Visible ;
      private int edtavCombocpjpaiid_Enabled ;
      private int edtCpjID_Visible ;
      private int edtCpjID_Enabled ;
      private int edtCpjTipoSigla_Visible ;
      private int edtCpjTipoSigla_Enabled ;
      private int edtCpjTipoNome_Visible ;
      private int edtCpjTipoNome_Enabled ;
      private int edtCliID_Visible ;
      private int edtCliID_Enabled ;
      private int AV38Cond_CpjTipoId ;
      private int AV14Insert_CpjTipoId ;
      private int Dvpanel_tablecliente_Gxcontroltype ;
      private int Combo_cpjtipoid_Datalistupdateminimumcharacters ;
      private int Combo_cpjtipoid_Gxcontroltype ;
      private int Combo_cpjpaiid_Datalistupdateminimumcharacters ;
      private int Combo_cpjpaiid_Gxcontroltype ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int AV42GXV1 ;
      private int Z184CpjPaiTipoID ;
      private int idxLst ;
      private int gxdynajaxindex ;
      private int GXt_int3 ;
      private int ZV36CpjTipoIdFiltro ;
      private long Z187CpjCNPJ ;
      private long Z176CpjMatricula ;
      private long A159CliMatricula ;
      private long A176CpjMatricula ;
      private long A187CpjCNPJ ;
      private long A191CpjHolMatricula ;
      private long A192CpjHolCNPJ ;
      private long A175CpjPaiMatricula ;
      private long A194CpjPaiCNPJ ;
      private long Z159CliMatricula ;
      private long Z191CpjHolMatricula ;
      private long Z192CpjHolCNPJ ;
      private long Z175CpjPaiMatricula ;
      private long Z194CpjPaiCNPJ ;
      private decimal Z190CpjCapitalSoc ;
      private decimal A190CpjCapitalSoc ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z546CpjDelUsuId ;
      private string Z201CpjInsUserID ;
      private string Z205CpjUpdUserID ;
      private string Z261CpjTelNum ;
      private string Z263CpjCelNum ;
      private string Z264CpjWppNum ;
      private string Combo_cpjpaiid_Selectedvalue_get ;
      private string Combo_cpjtipoid_Selectedvalue_get ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string GXDecQS ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtCpjTipoId_Internalname ;
      private string dynavCpjtipoidfiltro_Internalname ;
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
      private string Dvpanel_tableattributes_Width ;
      private string Dvpanel_tableattributes_Cls ;
      private string Dvpanel_tableattributes_Title ;
      private string Dvpanel_tableattributes_Iconposition ;
      private string Dvpanel_tableattributes_Internalname ;
      private string divTableattributes_Internalname ;
      private string divTablesplittedcpjtipoid_Internalname ;
      private string lblTextblockcpjtipoid_Internalname ;
      private string lblTextblockcpjtipoid_Jsonclick ;
      private string Combo_cpjtipoid_Caption ;
      private string Combo_cpjtipoid_Cls ;
      private string Combo_cpjtipoid_Emptyitemtext ;
      private string Combo_cpjtipoid_Internalname ;
      private string TempTags ;
      private string edtCpjTipoId_Jsonclick ;
      private string divCombo_cpjpaiid_cell_Internalname ;
      private string divCombo_cpjpaiid_cell_Class ;
      private string divTablesplittedcpjpaiid_Internalname ;
      private string lblTextblockcpjpaiid_Internalname ;
      private string lblTextblockcpjpaiid_Caption ;
      private string lblTextblockcpjpaiid_Jsonclick ;
      private string Combo_cpjpaiid_Caption ;
      private string Combo_cpjpaiid_Cls ;
      private string Combo_cpjpaiid_Datalistproc ;
      private string Combo_cpjpaiid_Emptyitemtext ;
      private string Combo_cpjpaiid_Internalname ;
      private string edtCpjPaiID_Internalname ;
      private string edtCpjPaiID_Jsonclick ;
      private string edtCpjNomeFan_Internalname ;
      private string edtCpjNomeFan_Jsonclick ;
      private string edtCpjRazaoSoc_Internalname ;
      private string edtCpjRazaoSoc_Jsonclick ;
      private string edtCpjMatricula_Internalname ;
      private string edtCpjMatricula_Jsonclick ;
      private string edtCpjCNPJFormat_Internalname ;
      private string edtCpjCNPJFormat_Jsonclick ;
      private string edtCpjIE_Internalname ;
      private string edtCpjIE_Jsonclick ;
      private string edtCpjCapitalSoc_Internalname ;
      private string edtCpjCapitalSoc_Jsonclick ;
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
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_cpjtipoid_Internalname ;
      private string edtavCombocpjtipoid_Internalname ;
      private string edtavCombocpjtipoid_Jsonclick ;
      private string divSectionattribute_cpjpaiid_Internalname ;
      private string edtavCombocpjpaiid_Internalname ;
      private string edtavCombocpjpaiid_Jsonclick ;
      private string edtCpjID_Internalname ;
      private string edtCpjID_Jsonclick ;
      private string dynavCpjtipoidfiltro_Jsonclick ;
      private string edtCpjTipoSigla_Internalname ;
      private string edtCpjTipoSigla_Jsonclick ;
      private string edtCpjTipoNome_Internalname ;
      private string edtCpjTipoNome_Jsonclick ;
      private string edtCliID_Internalname ;
      private string edtCliID_Jsonclick ;
      private string A546CpjDelUsuId ;
      private string A201CpjInsUserID ;
      private string A205CpjUpdUserID ;
      private string AV41Pgmname ;
      private string Dvpanel_tablecliente_Objectcall ;
      private string Dvpanel_tablecliente_Class ;
      private string Dvpanel_tablecliente_Height ;
      private string Combo_cpjtipoid_Objectcall ;
      private string Combo_cpjtipoid_Class ;
      private string Combo_cpjtipoid_Icontype ;
      private string Combo_cpjtipoid_Icon ;
      private string Combo_cpjtipoid_Tooltip ;
      private string Combo_cpjtipoid_Selectedvalue_set ;
      private string Combo_cpjtipoid_Selectedtext_set ;
      private string Combo_cpjtipoid_Selectedtext_get ;
      private string Combo_cpjtipoid_Gamoauthtoken ;
      private string Combo_cpjtipoid_Ddointernalname ;
      private string Combo_cpjtipoid_Titlecontrolalign ;
      private string Combo_cpjtipoid_Dropdownoptionstype ;
      private string Combo_cpjtipoid_Titlecontrolidtoreplace ;
      private string Combo_cpjtipoid_Datalisttype ;
      private string Combo_cpjtipoid_Datalistfixedvalues ;
      private string Combo_cpjtipoid_Datalistproc ;
      private string Combo_cpjtipoid_Datalistprocparametersprefix ;
      private string Combo_cpjtipoid_Remoteservicesparameters ;
      private string Combo_cpjtipoid_Htmltemplate ;
      private string Combo_cpjtipoid_Multiplevaluestype ;
      private string Combo_cpjtipoid_Loadingdata ;
      private string Combo_cpjtipoid_Noresultsfound ;
      private string Combo_cpjtipoid_Onlyselectedvalues ;
      private string Combo_cpjtipoid_Selectalltext ;
      private string Combo_cpjtipoid_Multiplevaluesseparator ;
      private string Combo_cpjtipoid_Addnewoptiontext ;
      private string Combo_cpjpaiid_Objectcall ;
      private string Combo_cpjpaiid_Class ;
      private string Combo_cpjpaiid_Icontype ;
      private string Combo_cpjpaiid_Icon ;
      private string Combo_cpjpaiid_Tooltip ;
      private string Combo_cpjpaiid_Selectedvalue_set ;
      private string Combo_cpjpaiid_Selectedtext_set ;
      private string Combo_cpjpaiid_Selectedtext_get ;
      private string Combo_cpjpaiid_Gamoauthtoken ;
      private string Combo_cpjpaiid_Ddointernalname ;
      private string Combo_cpjpaiid_Titlecontrolalign ;
      private string Combo_cpjpaiid_Dropdownoptionstype ;
      private string Combo_cpjpaiid_Titlecontrolidtoreplace ;
      private string Combo_cpjpaiid_Datalisttype ;
      private string Combo_cpjpaiid_Datalistfixedvalues ;
      private string Combo_cpjpaiid_Datalistprocparametersprefix ;
      private string Combo_cpjpaiid_Remoteservicesparameters ;
      private string Combo_cpjpaiid_Htmltemplate ;
      private string Combo_cpjpaiid_Multiplevaluestype ;
      private string Combo_cpjpaiid_Loadingdata ;
      private string Combo_cpjpaiid_Noresultsfound ;
      private string Combo_cpjpaiid_Onlyselectedvalues ;
      private string Combo_cpjpaiid_Selectalltext ;
      private string Combo_cpjpaiid_Multiplevaluesseparator ;
      private string Combo_cpjpaiid_Addnewoptiontext ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string hsh ;
      private string sMode25 ;
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
      private string gxwrpcisep ;
      private string GXt_char2 ;
      private DateTime Z200CpjInsDataHora ;
      private DateTime Z199CpjInsHora ;
      private DateTime Z543CpjDelDataHora ;
      private DateTime Z544CpjDelData ;
      private DateTime Z545CpjDelHora ;
      private DateTime Z203CpjUpdHora ;
      private DateTime Z204CpjUpdDataHora ;
      private DateTime A543CpjDelDataHora ;
      private DateTime A544CpjDelData ;
      private DateTime A545CpjDelHora ;
      private DateTime A203CpjUpdHora ;
      private DateTime A204CpjUpdDataHora ;
      private DateTime A200CpjInsDataHora ;
      private DateTime A199CpjInsHora ;
      private DateTime Z198CpjInsData ;
      private DateTime Z202CpjUpdData ;
      private DateTime A202CpjUpdData ;
      private DateTime A198CpjInsData ;
      private bool Z207CpjAtivo ;
      private bool Z542CpjDel ;
      private bool O542CpjDel ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n181CpjHolID ;
      private bool n169CpjPaiID ;
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
      private bool n543CpjDelDataHora ;
      private bool n544CpjDelData ;
      private bool n545CpjDelHora ;
      private bool n546CpjDelUsuId ;
      private bool n547CpjDelUsuNome ;
      private bool n201CpjInsUserID ;
      private bool n202CpjUpdData ;
      private bool n203CpjUpdHora ;
      private bool n204CpjUpdDataHora ;
      private bool n205CpjUpdUserID ;
      private bool n261CpjTelNum ;
      private bool n262CpjTelRam ;
      private bool n263CpjCelNum ;
      private bool n264CpjWppNum ;
      private bool n265CpjWebsite ;
      private bool n266CpjEmail ;
      private bool A207CpjAtivo ;
      private bool A542CpjDel ;
      private bool Dvpanel_tablecliente_Enabled ;
      private bool Dvpanel_tablecliente_Showheader ;
      private bool Dvpanel_tablecliente_Visible ;
      private bool Combo_cpjtipoid_Enabled ;
      private bool Combo_cpjtipoid_Visible ;
      private bool Combo_cpjtipoid_Allowmultipleselection ;
      private bool Combo_cpjtipoid_Isgriditem ;
      private bool Combo_cpjtipoid_Hasdescription ;
      private bool Combo_cpjtipoid_Includeonlyselectedoption ;
      private bool Combo_cpjtipoid_Includeselectalloption ;
      private bool Combo_cpjtipoid_Emptyitem ;
      private bool Combo_cpjtipoid_Includeaddnewoption ;
      private bool Combo_cpjpaiid_Enabled ;
      private bool Combo_cpjpaiid_Visible ;
      private bool Combo_cpjpaiid_Allowmultipleselection ;
      private bool Combo_cpjpaiid_Isgriditem ;
      private bool Combo_cpjpaiid_Hasdescription ;
      private bool Combo_cpjpaiid_Includeonlyselectedoption ;
      private bool Combo_cpjpaiid_Includeselectalloption ;
      private bool Combo_cpjpaiid_Emptyitem ;
      private bool Combo_cpjpaiid_Includeaddnewoption ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private bool i207CpjAtivo ;
      private bool gxdyncontrolsrefreshing ;
      private string AV20Combo_DataJson ;
      private string Z189CpjIE ;
      private string Z547CpjDelUsuNome ;
      private string Z170CpjNomeFan ;
      private string Z171CpjRazaoSoc ;
      private string Z188CpjCNPJFormat ;
      private string Z262CpjTelRam ;
      private string Z265CpjWebsite ;
      private string Z266CpjEmail ;
      private string A188CpjCNPJFormat ;
      private string A160CliNomeFamiliar ;
      private string A170CpjNomeFan ;
      private string A171CpjRazaoSoc ;
      private string A189CpjIE ;
      private string A262CpjTelRam ;
      private string A265CpjWebsite ;
      private string A266CpjEmail ;
      private string A366CpjTipoSigla ;
      private string A367CpjTipoNome ;
      private string A547CpjDelUsuNome ;
      private string A182CpjHolNomeFan ;
      private string A183CpjHolRazaoSoc ;
      private string A193CpjHolCNPJFormat ;
      private string A172CpjPaiNomeFan ;
      private string A173CpjPaiRazaoSoc ;
      private string A195CpjPaiCNPJFormat ;
      private string A185CpjPaiTipoSigla ;
      private string A186CpjPaiTipoNome ;
      private string AV18ComboSelectedValue ;
      private string AV19ComboSelectedText ;
      private string Z160CliNomeFamiliar ;
      private string Z182CpjHolNomeFan ;
      private string Z183CpjHolRazaoSoc ;
      private string Z193CpjHolCNPJFormat ;
      private string Z172CpjPaiNomeFan ;
      private string Z173CpjPaiRazaoSoc ;
      private string Z195CpjPaiCNPJFormat ;
      private string Z185CpjPaiTipoSigla ;
      private string Z186CpjPaiTipoNome ;
      private string Z366CpjTipoSigla ;
      private string Z367CpjTipoNome ;
      private Guid wcpOAV7CliID ;
      private Guid wcpOAV8CpjID ;
      private Guid Z158CliID ;
      private Guid Z166CpjID ;
      private Guid Z181CpjHolID ;
      private Guid Z169CpjPaiID ;
      private Guid N181CpjHolID ;
      private Guid N169CpjPaiID ;
      private Guid A158CliID ;
      private Guid A181CpjHolID ;
      private Guid A169CpjPaiID ;
      private Guid AV7CliID ;
      private Guid AV8CpjID ;
      private Guid AV30ComboCpjPaiID ;
      private Guid A166CpjID ;
      private Guid AV28Insert_CpjHolID ;
      private Guid AV27Insert_CpjPaiID ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tablecliente ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucCombo_cpjtipoid ;
      private GXUserControl ucCombo_cpjpaiid ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynavCpjtipoidfiltro ;
      private IDataStoreProvider pr_default ;
      private long[] T000P4_A159CliMatricula ;
      private string[] T000P4_A160CliNomeFamiliar ;
      private string[] T000P6_A182CpjHolNomeFan ;
      private string[] T000P6_A183CpjHolRazaoSoc ;
      private long[] T000P6_A191CpjHolMatricula ;
      private long[] T000P6_A192CpjHolCNPJ ;
      private string[] T000P6_A193CpjHolCNPJFormat ;
      private string[] T000P5_A366CpjTipoSigla ;
      private string[] T000P5_A367CpjTipoNome ;
      private string[] T000P7_A172CpjPaiNomeFan ;
      private string[] T000P7_A173CpjPaiRazaoSoc ;
      private long[] T000P7_A175CpjPaiMatricula ;
      private long[] T000P7_A194CpjPaiCNPJ ;
      private string[] T000P7_A195CpjPaiCNPJFormat ;
      private int[] T000P7_A184CpjPaiTipoID ;
      private string[] T000P8_A185CpjPaiTipoSigla ;
      private string[] T000P8_A186CpjPaiTipoNome ;
      private Guid[] T000P9_A166CpjID ;
      private long[] T000P9_A187CpjCNPJ ;
      private string[] T000P9_A189CpjIE ;
      private long[] T000P9_A176CpjMatricula ;
      private DateTime[] T000P9_A200CpjInsDataHora ;
      private DateTime[] T000P9_A198CpjInsData ;
      private DateTime[] T000P9_A199CpjInsHora ;
      private DateTime[] T000P9_A543CpjDelDataHora ;
      private bool[] T000P9_n543CpjDelDataHora ;
      private DateTime[] T000P9_A544CpjDelData ;
      private bool[] T000P9_n544CpjDelData ;
      private DateTime[] T000P9_A545CpjDelHora ;
      private bool[] T000P9_n545CpjDelHora ;
      private string[] T000P9_A546CpjDelUsuId ;
      private bool[] T000P9_n546CpjDelUsuId ;
      private string[] T000P9_A547CpjDelUsuNome ;
      private bool[] T000P9_n547CpjDelUsuNome ;
      private long[] T000P9_A159CliMatricula ;
      private string[] T000P9_A160CliNomeFamiliar ;
      private string[] T000P9_A182CpjHolNomeFan ;
      private string[] T000P9_A183CpjHolRazaoSoc ;
      private long[] T000P9_A191CpjHolMatricula ;
      private long[] T000P9_A192CpjHolCNPJ ;
      private string[] T000P9_A193CpjHolCNPJFormat ;
      private string[] T000P9_A172CpjPaiNomeFan ;
      private string[] T000P9_A173CpjPaiRazaoSoc ;
      private long[] T000P9_A175CpjPaiMatricula ;
      private long[] T000P9_A194CpjPaiCNPJ ;
      private string[] T000P9_A195CpjPaiCNPJFormat ;
      private string[] T000P9_A185CpjPaiTipoSigla ;
      private string[] T000P9_A186CpjPaiTipoNome ;
      private string[] T000P9_A366CpjTipoSigla ;
      private string[] T000P9_A367CpjTipoNome ;
      private string[] T000P9_A170CpjNomeFan ;
      private string[] T000P9_A171CpjRazaoSoc ;
      private string[] T000P9_A188CpjCNPJFormat ;
      private decimal[] T000P9_A190CpjCapitalSoc ;
      private string[] T000P9_A201CpjInsUserID ;
      private bool[] T000P9_n201CpjInsUserID ;
      private DateTime[] T000P9_A202CpjUpdData ;
      private bool[] T000P9_n202CpjUpdData ;
      private DateTime[] T000P9_A203CpjUpdHora ;
      private bool[] T000P9_n203CpjUpdHora ;
      private DateTime[] T000P9_A204CpjUpdDataHora ;
      private bool[] T000P9_n204CpjUpdDataHora ;
      private string[] T000P9_A205CpjUpdUserID ;
      private bool[] T000P9_n205CpjUpdUserID ;
      private short[] T000P9_A206CpjVersao ;
      private bool[] T000P9_A207CpjAtivo ;
      private string[] T000P9_A261CpjTelNum ;
      private bool[] T000P9_n261CpjTelNum ;
      private string[] T000P9_A262CpjTelRam ;
      private bool[] T000P9_n262CpjTelRam ;
      private string[] T000P9_A263CpjCelNum ;
      private bool[] T000P9_n263CpjCelNum ;
      private string[] T000P9_A264CpjWppNum ;
      private bool[] T000P9_n264CpjWppNum ;
      private string[] T000P9_A265CpjWebsite ;
      private bool[] T000P9_n265CpjWebsite ;
      private string[] T000P9_A266CpjEmail ;
      private bool[] T000P9_n266CpjEmail ;
      private bool[] T000P9_A542CpjDel ;
      private Guid[] T000P9_A158CliID ;
      private int[] T000P9_A365CpjTipoId ;
      private Guid[] T000P9_A181CpjHolID ;
      private bool[] T000P9_n181CpjHolID ;
      private Guid[] T000P9_A169CpjPaiID ;
      private bool[] T000P9_n169CpjPaiID ;
      private int[] T000P9_A184CpjPaiTipoID ;
      private long[] T000P10_A159CliMatricula ;
      private string[] T000P10_A160CliNomeFamiliar ;
      private string[] T000P11_A182CpjHolNomeFan ;
      private string[] T000P11_A183CpjHolRazaoSoc ;
      private long[] T000P11_A191CpjHolMatricula ;
      private long[] T000P11_A192CpjHolCNPJ ;
      private string[] T000P11_A193CpjHolCNPJFormat ;
      private string[] T000P12_A172CpjPaiNomeFan ;
      private string[] T000P12_A173CpjPaiRazaoSoc ;
      private long[] T000P12_A175CpjPaiMatricula ;
      private long[] T000P12_A194CpjPaiCNPJ ;
      private string[] T000P12_A195CpjPaiCNPJFormat ;
      private int[] T000P12_A184CpjPaiTipoID ;
      private string[] T000P13_A185CpjPaiTipoSigla ;
      private string[] T000P13_A186CpjPaiTipoNome ;
      private string[] T000P14_A366CpjTipoSigla ;
      private string[] T000P14_A367CpjTipoNome ;
      private Guid[] T000P15_A158CliID ;
      private Guid[] T000P15_A166CpjID ;
      private Guid[] T000P3_A166CpjID ;
      private long[] T000P3_A187CpjCNPJ ;
      private string[] T000P3_A189CpjIE ;
      private long[] T000P3_A176CpjMatricula ;
      private DateTime[] T000P3_A200CpjInsDataHora ;
      private DateTime[] T000P3_A198CpjInsData ;
      private DateTime[] T000P3_A199CpjInsHora ;
      private DateTime[] T000P3_A543CpjDelDataHora ;
      private bool[] T000P3_n543CpjDelDataHora ;
      private DateTime[] T000P3_A544CpjDelData ;
      private bool[] T000P3_n544CpjDelData ;
      private DateTime[] T000P3_A545CpjDelHora ;
      private bool[] T000P3_n545CpjDelHora ;
      private string[] T000P3_A546CpjDelUsuId ;
      private bool[] T000P3_n546CpjDelUsuId ;
      private string[] T000P3_A547CpjDelUsuNome ;
      private bool[] T000P3_n547CpjDelUsuNome ;
      private string[] T000P3_A170CpjNomeFan ;
      private string[] T000P3_A171CpjRazaoSoc ;
      private string[] T000P3_A188CpjCNPJFormat ;
      private decimal[] T000P3_A190CpjCapitalSoc ;
      private string[] T000P3_A201CpjInsUserID ;
      private bool[] T000P3_n201CpjInsUserID ;
      private DateTime[] T000P3_A202CpjUpdData ;
      private bool[] T000P3_n202CpjUpdData ;
      private DateTime[] T000P3_A203CpjUpdHora ;
      private bool[] T000P3_n203CpjUpdHora ;
      private DateTime[] T000P3_A204CpjUpdDataHora ;
      private bool[] T000P3_n204CpjUpdDataHora ;
      private string[] T000P3_A205CpjUpdUserID ;
      private bool[] T000P3_n205CpjUpdUserID ;
      private short[] T000P3_A206CpjVersao ;
      private bool[] T000P3_A207CpjAtivo ;
      private string[] T000P3_A261CpjTelNum ;
      private bool[] T000P3_n261CpjTelNum ;
      private string[] T000P3_A262CpjTelRam ;
      private bool[] T000P3_n262CpjTelRam ;
      private string[] T000P3_A263CpjCelNum ;
      private bool[] T000P3_n263CpjCelNum ;
      private string[] T000P3_A264CpjWppNum ;
      private bool[] T000P3_n264CpjWppNum ;
      private string[] T000P3_A265CpjWebsite ;
      private bool[] T000P3_n265CpjWebsite ;
      private string[] T000P3_A266CpjEmail ;
      private bool[] T000P3_n266CpjEmail ;
      private bool[] T000P3_A542CpjDel ;
      private Guid[] T000P3_A158CliID ;
      private int[] T000P3_A365CpjTipoId ;
      private Guid[] T000P3_A181CpjHolID ;
      private bool[] T000P3_n181CpjHolID ;
      private Guid[] T000P3_A169CpjPaiID ;
      private bool[] T000P3_n169CpjPaiID ;
      private Guid[] T000P16_A158CliID ;
      private Guid[] T000P16_A166CpjID ;
      private Guid[] T000P17_A158CliID ;
      private Guid[] T000P17_A166CpjID ;
      private Guid[] T000P2_A166CpjID ;
      private long[] T000P2_A187CpjCNPJ ;
      private string[] T000P2_A189CpjIE ;
      private long[] T000P2_A176CpjMatricula ;
      private DateTime[] T000P2_A200CpjInsDataHora ;
      private DateTime[] T000P2_A198CpjInsData ;
      private DateTime[] T000P2_A199CpjInsHora ;
      private DateTime[] T000P2_A543CpjDelDataHora ;
      private bool[] T000P2_n543CpjDelDataHora ;
      private DateTime[] T000P2_A544CpjDelData ;
      private bool[] T000P2_n544CpjDelData ;
      private DateTime[] T000P2_A545CpjDelHora ;
      private bool[] T000P2_n545CpjDelHora ;
      private string[] T000P2_A546CpjDelUsuId ;
      private bool[] T000P2_n546CpjDelUsuId ;
      private string[] T000P2_A547CpjDelUsuNome ;
      private bool[] T000P2_n547CpjDelUsuNome ;
      private string[] T000P2_A170CpjNomeFan ;
      private string[] T000P2_A171CpjRazaoSoc ;
      private string[] T000P2_A188CpjCNPJFormat ;
      private decimal[] T000P2_A190CpjCapitalSoc ;
      private string[] T000P2_A201CpjInsUserID ;
      private bool[] T000P2_n201CpjInsUserID ;
      private DateTime[] T000P2_A202CpjUpdData ;
      private bool[] T000P2_n202CpjUpdData ;
      private DateTime[] T000P2_A203CpjUpdHora ;
      private bool[] T000P2_n203CpjUpdHora ;
      private DateTime[] T000P2_A204CpjUpdDataHora ;
      private bool[] T000P2_n204CpjUpdDataHora ;
      private string[] T000P2_A205CpjUpdUserID ;
      private bool[] T000P2_n205CpjUpdUserID ;
      private short[] T000P2_A206CpjVersao ;
      private bool[] T000P2_A207CpjAtivo ;
      private string[] T000P2_A261CpjTelNum ;
      private bool[] T000P2_n261CpjTelNum ;
      private string[] T000P2_A262CpjTelRam ;
      private bool[] T000P2_n262CpjTelRam ;
      private string[] T000P2_A263CpjCelNum ;
      private bool[] T000P2_n263CpjCelNum ;
      private string[] T000P2_A264CpjWppNum ;
      private bool[] T000P2_n264CpjWppNum ;
      private string[] T000P2_A265CpjWebsite ;
      private bool[] T000P2_n265CpjWebsite ;
      private string[] T000P2_A266CpjEmail ;
      private bool[] T000P2_n266CpjEmail ;
      private bool[] T000P2_A542CpjDel ;
      private Guid[] T000P2_A158CliID ;
      private int[] T000P2_A365CpjTipoId ;
      private Guid[] T000P2_A181CpjHolID ;
      private bool[] T000P2_n181CpjHolID ;
      private Guid[] T000P2_A169CpjPaiID ;
      private bool[] T000P2_n169CpjPaiID ;
      private long[] T000P21_A159CliMatricula ;
      private string[] T000P21_A160CliNomeFamiliar ;
      private string[] T000P22_A172CpjPaiNomeFan ;
      private string[] T000P22_A173CpjPaiRazaoSoc ;
      private long[] T000P22_A175CpjPaiMatricula ;
      private long[] T000P22_A194CpjPaiCNPJ ;
      private string[] T000P22_A195CpjPaiCNPJFormat ;
      private int[] T000P22_A184CpjPaiTipoID ;
      private string[] T000P23_A185CpjPaiTipoSigla ;
      private string[] T000P23_A186CpjPaiTipoNome ;
      private string[] T000P24_A366CpjTipoSigla ;
      private string[] T000P24_A367CpjTipoNome ;
      private string[] T000P25_A182CpjHolNomeFan ;
      private string[] T000P25_A183CpjHolRazaoSoc ;
      private long[] T000P25_A191CpjHolMatricula ;
      private long[] T000P25_A192CpjHolCNPJ ;
      private string[] T000P25_A193CpjHolCNPJFormat ;
      private Guid[] T000P26_A158CliID ;
      private Guid[] T000P26_A169CpjPaiID ;
      private bool[] T000P26_n169CpjPaiID ;
      private Guid[] T000P27_A158CliID ;
      private Guid[] T000P27_A181CpjHolID ;
      private bool[] T000P27_n181CpjHolID ;
      private Guid[] T000P28_A345NegID ;
      private Guid[] T000P29_A158CliID ;
      private Guid[] T000P29_A166CpjID ;
      private short[] T000P29_A269CpjConSeq ;
      private Guid[] T000P30_A158CliID ;
      private Guid[] T000P30_A166CpjID ;
      private short[] T000P30_A248CpjEndSeq ;
      private Guid[] T000P31_A158CliID ;
      private Guid[] T000P31_A166CpjID ;
      private int[] T000P32_A155PjtID ;
      private string[] T000P32_A157PjtNome ;
      private long[] T000P33_A159CliMatricula ;
      private string[] T000P33_A160CliNomeFamiliar ;
      private string[] T000P34_A366CpjTipoSigla ;
      private string[] T000P34_A367CpjTipoNome ;
      private string[] T000P35_A172CpjPaiNomeFan ;
      private string[] T000P35_A173CpjPaiRazaoSoc ;
      private long[] T000P35_A175CpjPaiMatricula ;
      private long[] T000P35_A194CpjPaiCNPJ ;
      private string[] T000P35_A195CpjPaiCNPJFormat ;
      private int[] T000P35_A184CpjPaiTipoID ;
      private string[] T000P36_A185CpjPaiTipoSigla ;
      private string[] T000P36_A186CpjPaiTipoNome ;
      private IDataStoreProvider pr_gam ;
      private IGxSession AV13WebSession ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV24CpjTipoId_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV29CpjPaiID_Data ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV23GAMErrors ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV12TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV15TrnContextAtt ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV17DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV22GAMSession ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV37GAMUser ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV39AuditingObject ;
   }

   public class clientepj__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class clientepj__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[13])
       ,new ForEachCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new UpdateCursor(def[16])
       ,new UpdateCursor(def[17])
       ,new UpdateCursor(def[18])
       ,new ForEachCursor(def[19])
       ,new ForEachCursor(def[20])
       ,new ForEachCursor(def[21])
       ,new ForEachCursor(def[22])
       ,new ForEachCursor(def[23])
       ,new ForEachCursor(def[24])
       ,new ForEachCursor(def[25])
       ,new ForEachCursor(def[26])
       ,new ForEachCursor(def[27])
       ,new ForEachCursor(def[28])
       ,new ForEachCursor(def[29])
       ,new ForEachCursor(def[30])
       ,new ForEachCursor(def[31])
       ,new ForEachCursor(def[32])
       ,new ForEachCursor(def[33])
       ,new ForEachCursor(def[34])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT000P9;
        prmT000P9 = new Object[] {
        new ParDef("CliID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("CpjID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000P4;
        prmT000P4 = new Object[] {
        new ParDef("CliID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000P6;
        prmT000P6 = new Object[] {
        new ParDef("CliID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("CpjHolID",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmT000P7;
        prmT000P7 = new Object[] {
        new ParDef("CliID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("CpjPaiID",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmT000P8;
        prmT000P8 = new Object[] {
        new ParDef("CpjPaiTipoID",GXType.Int32,9,0)
        };
        Object[] prmT000P5;
        prmT000P5 = new Object[] {
        new ParDef("CpjTipoId",GXType.Int32,9,0)
        };
        Object[] prmT000P10;
        prmT000P10 = new Object[] {
        new ParDef("CliID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000P11;
        prmT000P11 = new Object[] {
        new ParDef("CliID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("CpjHolID",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmT000P12;
        prmT000P12 = new Object[] {
        new ParDef("CliID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("CpjPaiID",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmT000P13;
        prmT000P13 = new Object[] {
        new ParDef("CpjPaiTipoID",GXType.Int32,9,0)
        };
        Object[] prmT000P14;
        prmT000P14 = new Object[] {
        new ParDef("CpjTipoId",GXType.Int32,9,0)
        };
        Object[] prmT000P15;
        prmT000P15 = new Object[] {
        new ParDef("CliID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("CpjID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000P3;
        prmT000P3 = new Object[] {
        new ParDef("CliID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("CpjID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000P16;
        prmT000P16 = new Object[] {
        new ParDef("CliID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("CpjID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000P17;
        prmT000P17 = new Object[] {
        new ParDef("CliID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("CpjID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000P2;
        prmT000P2 = new Object[] {
        new ParDef("CliID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("CpjID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000P18;
        prmT000P18 = new Object[] {
        new ParDef("CpjID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("CpjCNPJ",GXType.Int64,14,0) ,
        new ParDef("CpjIE",GXType.VarChar,20,0) ,
        new ParDef("CpjMatricula",GXType.Int64,12,0) ,
        new ParDef("CpjInsDataHora",GXType.DateTime2,10,12) ,
        new ParDef("CpjInsData",GXType.Date,8,0) ,
        new ParDef("CpjInsHora",GXType.DateTime,0,5) ,
        new ParDef("CpjDelDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("CpjDelData",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("CpjDelHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("CpjDelUsuId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("CpjDelUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("CpjNomeFan",GXType.VarChar,80,0) ,
        new ParDef("CpjRazaoSoc",GXType.VarChar,80,0) ,
        new ParDef("CpjCNPJFormat",GXType.VarChar,18,0) ,
        new ParDef("CpjCapitalSoc",GXType.Number,16,2) ,
        new ParDef("CpjInsUserID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("CpjUpdData",GXType.Date,8,0){Nullable=true} ,
        new ParDef("CpjUpdHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("CpjUpdDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("CpjUpdUserID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("CpjVersao",GXType.Int16,4,0) ,
        new ParDef("CpjAtivo",GXType.Boolean,4,0) ,
        new ParDef("CpjTelNum",GXType.Char,20,0){Nullable=true} ,
        new ParDef("CpjTelRam",GXType.VarChar,10,0){Nullable=true} ,
        new ParDef("CpjCelNum",GXType.Char,20,0){Nullable=true} ,
        new ParDef("CpjWppNum",GXType.Char,20,0){Nullable=true} ,
        new ParDef("CpjWebsite",GXType.VarChar,1000,0){Nullable=true} ,
        new ParDef("CpjEmail",GXType.VarChar,100,0){Nullable=true} ,
        new ParDef("CpjDel",GXType.Boolean,4,0) ,
        new ParDef("CliID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("CpjTipoId",GXType.Int32,9,0) ,
        new ParDef("CpjHolID",GXType.UniqueIdentifier,36,0){Nullable=true} ,
        new ParDef("CpjPaiID",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmT000P19;
        prmT000P19 = new Object[] {
        new ParDef("CpjCNPJ",GXType.Int64,14,0) ,
        new ParDef("CpjIE",GXType.VarChar,20,0) ,
        new ParDef("CpjMatricula",GXType.Int64,12,0) ,
        new ParDef("CpjInsDataHora",GXType.DateTime2,10,12) ,
        new ParDef("CpjInsData",GXType.Date,8,0) ,
        new ParDef("CpjInsHora",GXType.DateTime,0,5) ,
        new ParDef("CpjDelDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("CpjDelData",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("CpjDelHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("CpjDelUsuId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("CpjDelUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("CpjNomeFan",GXType.VarChar,80,0) ,
        new ParDef("CpjRazaoSoc",GXType.VarChar,80,0) ,
        new ParDef("CpjCNPJFormat",GXType.VarChar,18,0) ,
        new ParDef("CpjCapitalSoc",GXType.Number,16,2) ,
        new ParDef("CpjInsUserID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("CpjUpdData",GXType.Date,8,0){Nullable=true} ,
        new ParDef("CpjUpdHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("CpjUpdDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("CpjUpdUserID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("CpjVersao",GXType.Int16,4,0) ,
        new ParDef("CpjAtivo",GXType.Boolean,4,0) ,
        new ParDef("CpjTelNum",GXType.Char,20,0){Nullable=true} ,
        new ParDef("CpjTelRam",GXType.VarChar,10,0){Nullable=true} ,
        new ParDef("CpjCelNum",GXType.Char,20,0){Nullable=true} ,
        new ParDef("CpjWppNum",GXType.Char,20,0){Nullable=true} ,
        new ParDef("CpjWebsite",GXType.VarChar,1000,0){Nullable=true} ,
        new ParDef("CpjEmail",GXType.VarChar,100,0){Nullable=true} ,
        new ParDef("CpjDel",GXType.Boolean,4,0) ,
        new ParDef("CpjTipoId",GXType.Int32,9,0) ,
        new ParDef("CpjHolID",GXType.UniqueIdentifier,36,0){Nullable=true} ,
        new ParDef("CpjPaiID",GXType.UniqueIdentifier,36,0){Nullable=true} ,
        new ParDef("CliID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("CpjID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000P20;
        prmT000P20 = new Object[] {
        new ParDef("CliID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("CpjID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000P21;
        prmT000P21 = new Object[] {
        new ParDef("CliID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000P22;
        prmT000P22 = new Object[] {
        new ParDef("CliID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("CpjPaiID",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmT000P23;
        prmT000P23 = new Object[] {
        new ParDef("CpjPaiTipoID",GXType.Int32,9,0)
        };
        Object[] prmT000P24;
        prmT000P24 = new Object[] {
        new ParDef("CpjTipoId",GXType.Int32,9,0)
        };
        Object[] prmT000P25;
        prmT000P25 = new Object[] {
        new ParDef("CliID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("CpjHolID",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmT000P26;
        prmT000P26 = new Object[] {
        new ParDef("CliID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("CpjID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000P27;
        prmT000P27 = new Object[] {
        new ParDef("CliID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("CpjID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000P28;
        prmT000P28 = new Object[] {
        new ParDef("CliID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("CpjID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000P29;
        prmT000P29 = new Object[] {
        new ParDef("CliID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("CpjID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000P30;
        prmT000P30 = new Object[] {
        new ParDef("CliID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("CpjID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000P31;
        prmT000P31 = new Object[] {
        };
        Object[] prmT000P32;
        prmT000P32 = new Object[] {
        };
        Object[] prmT000P33;
        prmT000P33 = new Object[] {
        new ParDef("CliID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000P34;
        prmT000P34 = new Object[] {
        new ParDef("CpjTipoId",GXType.Int32,9,0)
        };
        Object[] prmT000P35;
        prmT000P35 = new Object[] {
        new ParDef("CliID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("CpjPaiID",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmT000P36;
        prmT000P36 = new Object[] {
        new ParDef("CpjPaiTipoID",GXType.Int32,9,0)
        };
        def= new CursorDef[] {
            new CursorDef("T000P2", "SELECT CpjID, CpjCNPJ, CpjIE, CpjMatricula, CpjInsDataHora, CpjInsData, CpjInsHora, CpjDelDataHora, CpjDelData, CpjDelHora, CpjDelUsuId, CpjDelUsuNome, CpjNomeFan, CpjRazaoSoc, CpjCNPJFormat, CpjCapitalSoc, CpjInsUserID, CpjUpdData, CpjUpdHora, CpjUpdDataHora, CpjUpdUserID, CpjVersao, CpjAtivo, CpjTelNum, CpjTelRam, CpjCelNum, CpjWppNum, CpjWebsite, CpjEmail, CpjDel, CliID, CpjTipoId, CpjHolID, CpjPaiID FROM tb_clientepj WHERE CliID = :CliID AND CpjID = :CpjID  FOR UPDATE OF tb_clientepj NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000P2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000P3", "SELECT CpjID, CpjCNPJ, CpjIE, CpjMatricula, CpjInsDataHora, CpjInsData, CpjInsHora, CpjDelDataHora, CpjDelData, CpjDelHora, CpjDelUsuId, CpjDelUsuNome, CpjNomeFan, CpjRazaoSoc, CpjCNPJFormat, CpjCapitalSoc, CpjInsUserID, CpjUpdData, CpjUpdHora, CpjUpdDataHora, CpjUpdUserID, CpjVersao, CpjAtivo, CpjTelNum, CpjTelRam, CpjCelNum, CpjWppNum, CpjWebsite, CpjEmail, CpjDel, CliID, CpjTipoId, CpjHolID, CpjPaiID FROM tb_clientepj WHERE CliID = :CliID AND CpjID = :CpjID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000P3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000P4", "SELECT CliMatricula, CliNomeFamiliar FROM tb_cliente WHERE CliID = :CliID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000P4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000P5", "SELECT PjtSigla AS CpjTipoSigla, PjtNome AS CpjTipoNome FROM tb_clientepjtipo WHERE PjtID = :CpjTipoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000P5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000P6", "SELECT CpjNomeFan AS CpjHolNomeFan, CpjRazaoSoc AS CpjHolRazaoSoc, CpjMatricula AS CpjHolMatricula, CpjCNPJ AS CpjHolCNPJ, CpjCNPJFormat AS CpjHolCNPJFormat FROM tb_clientepj WHERE CliID = :CliID AND CpjID = :CpjHolID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000P6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000P7", "SELECT CpjNomeFan AS CpjPaiNomeFan, CpjRazaoSoc AS CpjPaiRazaoSoc, CpjMatricula AS CpjPaiMatricula, CpjCNPJ AS CpjPaiCNPJ, CpjCNPJFormat AS CpjPaiCNPJFormat, CpjTipoId AS CpjPaiTipoID FROM tb_clientepj WHERE CliID = :CliID AND CpjID = :CpjPaiID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000P7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000P8", "SELECT PjtSigla AS CpjPaiTipoSigla, PjtNome AS CpjPaiTipoNome FROM tb_clientepjtipo WHERE PjtID = :CpjPaiTipoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000P8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000P9", "SELECT TM1.CpjID, TM1.CpjCNPJ, TM1.CpjIE, TM1.CpjMatricula, TM1.CpjInsDataHora, TM1.CpjInsData, TM1.CpjInsHora, TM1.CpjDelDataHora, TM1.CpjDelData, TM1.CpjDelHora, TM1.CpjDelUsuId, TM1.CpjDelUsuNome, T2.CliMatricula, T2.CliNomeFamiliar, T3.CpjNomeFan AS CpjHolNomeFan, T3.CpjRazaoSoc AS CpjHolRazaoSoc, T3.CpjMatricula AS CpjHolMatricula, T3.CpjCNPJ AS CpjHolCNPJ, T3.CpjCNPJFormat AS CpjHolCNPJFormat, T4.CpjNomeFan AS CpjPaiNomeFan, T4.CpjRazaoSoc AS CpjPaiRazaoSoc, T4.CpjMatricula AS CpjPaiMatricula, T4.CpjCNPJ AS CpjPaiCNPJ, T4.CpjCNPJFormat AS CpjPaiCNPJFormat, T5.PjtSigla AS CpjPaiTipoSigla, T5.PjtNome AS CpjPaiTipoNome, T6.PjtSigla AS CpjTipoSigla, T6.PjtNome AS CpjTipoNome, TM1.CpjNomeFan, TM1.CpjRazaoSoc, TM1.CpjCNPJFormat, TM1.CpjCapitalSoc, TM1.CpjInsUserID, TM1.CpjUpdData, TM1.CpjUpdHora, TM1.CpjUpdDataHora, TM1.CpjUpdUserID, TM1.CpjVersao, TM1.CpjAtivo, TM1.CpjTelNum, TM1.CpjTelRam, TM1.CpjCelNum, TM1.CpjWppNum, TM1.CpjWebsite, TM1.CpjEmail, TM1.CpjDel, TM1.CliID, TM1.CpjTipoId AS CpjTipoId, TM1.CpjHolID AS CpjHolID, TM1.CpjPaiID AS CpjPaiID, T4.CpjTipoId AS CpjPaiTipoID FROM (((((tb_clientepj TM1 INNER JOIN tb_cliente T2 ON T2.CliID = TM1.CliID) LEFT JOIN tb_clientepj T3 ON T3.CliID = TM1.CliID AND T3.CpjID = TM1.CpjHolID) LEFT JOIN tb_clientepj T4 ON T4.CliID = TM1.CliID AND T4.CpjID = TM1.CpjPaiID) LEFT JOIN tb_clientepjtipo T5 ON T5.PjtID = T4.CpjTipoId) INNER JOIN tb_clientepjtipo T6 ON T6.PjtID = TM1.CpjTipoId) WHERE TM1.CliID = :CliID and TM1.CpjID = :CpjID ORDER BY TM1.CliID, TM1.CpjID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000P9,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000P10", "SELECT CliMatricula, CliNomeFamiliar FROM tb_cliente WHERE CliID = :CliID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000P10,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000P11", "SELECT CpjNomeFan AS CpjHolNomeFan, CpjRazaoSoc AS CpjHolRazaoSoc, CpjMatricula AS CpjHolMatricula, CpjCNPJ AS CpjHolCNPJ, CpjCNPJFormat AS CpjHolCNPJFormat FROM tb_clientepj WHERE CliID = :CliID AND CpjID = :CpjHolID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000P11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000P12", "SELECT CpjNomeFan AS CpjPaiNomeFan, CpjRazaoSoc AS CpjPaiRazaoSoc, CpjMatricula AS CpjPaiMatricula, CpjCNPJ AS CpjPaiCNPJ, CpjCNPJFormat AS CpjPaiCNPJFormat, CpjTipoId AS CpjPaiTipoID FROM tb_clientepj WHERE CliID = :CliID AND CpjID = :CpjPaiID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000P12,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000P13", "SELECT PjtSigla AS CpjPaiTipoSigla, PjtNome AS CpjPaiTipoNome FROM tb_clientepjtipo WHERE PjtID = :CpjPaiTipoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000P13,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000P14", "SELECT PjtSigla AS CpjTipoSigla, PjtNome AS CpjTipoNome FROM tb_clientepjtipo WHERE PjtID = :CpjTipoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000P14,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000P15", "SELECT CliID, CpjID FROM tb_clientepj WHERE CliID = :CliID AND CpjID = :CpjID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000P15,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000P16", "SELECT CliID, CpjID FROM tb_clientepj WHERE ( CliID > :CliID or CliID = :CliID and CpjID > :CpjID) ORDER BY CliID, CpjID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000P16,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000P17", "SELECT CliID, CpjID FROM tb_clientepj WHERE ( CliID < :CliID or CliID = :CliID and CpjID < :CpjID) ORDER BY CliID DESC, CpjID DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000P17,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000P18", "SAVEPOINT gxupdate;INSERT INTO tb_clientepj(CpjID, CpjCNPJ, CpjIE, CpjMatricula, CpjInsDataHora, CpjInsData, CpjInsHora, CpjDelDataHora, CpjDelData, CpjDelHora, CpjDelUsuId, CpjDelUsuNome, CpjNomeFan, CpjRazaoSoc, CpjCNPJFormat, CpjCapitalSoc, CpjInsUserID, CpjUpdData, CpjUpdHora, CpjUpdDataHora, CpjUpdUserID, CpjVersao, CpjAtivo, CpjTelNum, CpjTelRam, CpjCelNum, CpjWppNum, CpjWebsite, CpjEmail, CpjDel, CliID, CpjTipoId, CpjHolID, CpjPaiID, CpjUltEndSeq, CpjUltConSeq) VALUES(:CpjID, :CpjCNPJ, :CpjIE, :CpjMatricula, :CpjInsDataHora, :CpjInsData, :CpjInsHora, :CpjDelDataHora, :CpjDelData, :CpjDelHora, :CpjDelUsuId, :CpjDelUsuNome, :CpjNomeFan, :CpjRazaoSoc, :CpjCNPJFormat, :CpjCapitalSoc, :CpjInsUserID, :CpjUpdData, :CpjUpdHora, :CpjUpdDataHora, :CpjUpdUserID, :CpjVersao, :CpjAtivo, :CpjTelNum, :CpjTelRam, :CpjCelNum, :CpjWppNum, :CpjWebsite, :CpjEmail, :CpjDel, :CliID, :CpjTipoId, :CpjHolID, :CpjPaiID, 0, 0);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000P18)
           ,new CursorDef("T000P19", "SAVEPOINT gxupdate;UPDATE tb_clientepj SET CpjCNPJ=:CpjCNPJ, CpjIE=:CpjIE, CpjMatricula=:CpjMatricula, CpjInsDataHora=:CpjInsDataHora, CpjInsData=:CpjInsData, CpjInsHora=:CpjInsHora, CpjDelDataHora=:CpjDelDataHora, CpjDelData=:CpjDelData, CpjDelHora=:CpjDelHora, CpjDelUsuId=:CpjDelUsuId, CpjDelUsuNome=:CpjDelUsuNome, CpjNomeFan=:CpjNomeFan, CpjRazaoSoc=:CpjRazaoSoc, CpjCNPJFormat=:CpjCNPJFormat, CpjCapitalSoc=:CpjCapitalSoc, CpjInsUserID=:CpjInsUserID, CpjUpdData=:CpjUpdData, CpjUpdHora=:CpjUpdHora, CpjUpdDataHora=:CpjUpdDataHora, CpjUpdUserID=:CpjUpdUserID, CpjVersao=:CpjVersao, CpjAtivo=:CpjAtivo, CpjTelNum=:CpjTelNum, CpjTelRam=:CpjTelRam, CpjCelNum=:CpjCelNum, CpjWppNum=:CpjWppNum, CpjWebsite=:CpjWebsite, CpjEmail=:CpjEmail, CpjDel=:CpjDel, CpjTipoId=:CpjTipoId, CpjHolID=:CpjHolID, CpjPaiID=:CpjPaiID  WHERE CliID = :CliID AND CpjID = :CpjID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000P19)
           ,new CursorDef("T000P20", "SAVEPOINT gxupdate;DELETE FROM tb_clientepj  WHERE CliID = :CliID AND CpjID = :CpjID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000P20)
           ,new CursorDef("T000P21", "SELECT CliMatricula, CliNomeFamiliar FROM tb_cliente WHERE CliID = :CliID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000P21,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000P22", "SELECT CpjNomeFan AS CpjPaiNomeFan, CpjRazaoSoc AS CpjPaiRazaoSoc, CpjMatricula AS CpjPaiMatricula, CpjCNPJ AS CpjPaiCNPJ, CpjCNPJFormat AS CpjPaiCNPJFormat, CpjTipoId AS CpjPaiTipoID FROM tb_clientepj WHERE CliID = :CliID AND CpjID = :CpjPaiID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000P22,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000P23", "SELECT PjtSigla AS CpjPaiTipoSigla, PjtNome AS CpjPaiTipoNome FROM tb_clientepjtipo WHERE PjtID = :CpjPaiTipoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000P23,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000P24", "SELECT PjtSigla AS CpjTipoSigla, PjtNome AS CpjTipoNome FROM tb_clientepjtipo WHERE PjtID = :CpjTipoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000P24,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000P25", "SELECT CpjNomeFan AS CpjHolNomeFan, CpjRazaoSoc AS CpjHolRazaoSoc, CpjMatricula AS CpjHolMatricula, CpjCNPJ AS CpjHolCNPJ, CpjCNPJFormat AS CpjHolCNPJFormat FROM tb_clientepj WHERE CliID = :CliID AND CpjID = :CpjHolID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000P25,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000P26", "SELECT CliID, CpjID AS CpjPaiID FROM tb_clientepj WHERE CliID = :CliID AND CpjPaiID = :CpjID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000P26,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000P27", "SELECT CliID, CpjID AS CpjHolID FROM tb_clientepj WHERE CliID = :CliID AND CpjHolID = :CpjID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000P27,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000P28", "SELECT NegID FROM tb_negociopj WHERE NegCliID = :CliID AND NegCpjID = :CpjID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000P28,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000P29", "SELECT CliID, CpjID, CpjConSeq FROM tb_clientepj_contato WHERE CliID = :CliID AND CpjID = :CpjID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000P29,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000P30", "SELECT CliID, CpjID, CpjEndSeq FROM tb_clientepj_endereco WHERE CliID = :CliID AND CpjID = :CpjID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000P30,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000P31", "SELECT CliID, CpjID FROM tb_clientepj ORDER BY CliID, CpjID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000P31,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000P32", "SELECT PjtID, PjtNome FROM tb_clientepjtipo ORDER BY PjtNome ",true, GxErrorMask.GX_NOMASK, false, this,prmT000P32,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000P33", "SELECT CliMatricula, CliNomeFamiliar FROM tb_cliente WHERE CliID = :CliID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000P33,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000P34", "SELECT PjtSigla AS CpjTipoSigla, PjtNome AS CpjTipoNome FROM tb_clientepjtipo WHERE PjtID = :CpjTipoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000P34,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000P35", "SELECT CpjNomeFan AS CpjPaiNomeFan, CpjRazaoSoc AS CpjPaiRazaoSoc, CpjMatricula AS CpjPaiMatricula, CpjCNPJ AS CpjPaiCNPJ, CpjCNPJFormat AS CpjPaiCNPJFormat, CpjTipoId AS CpjPaiTipoID FROM tb_clientepj WHERE CliID = :CliID AND CpjID = :CpjPaiID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000P35,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000P36", "SELECT PjtSigla AS CpjPaiTipoSigla, PjtNome AS CpjPaiTipoNome FROM tb_clientepjtipo WHERE PjtID = :CpjPaiTipoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000P36,1, GxCacheFrequency.OFF ,true,false )
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
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5, true);
              ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
              ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(7);
              ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(8, true);
              ((bool[]) buf[8])[0] = rslt.wasNull(8);
              ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(9);
              ((bool[]) buf[10])[0] = rslt.wasNull(9);
              ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(10);
              ((bool[]) buf[12])[0] = rslt.wasNull(10);
              ((string[]) buf[13])[0] = rslt.getString(11, 40);
              ((bool[]) buf[14])[0] = rslt.wasNull(11);
              ((string[]) buf[15])[0] = rslt.getVarchar(12);
              ((bool[]) buf[16])[0] = rslt.wasNull(12);
              ((string[]) buf[17])[0] = rslt.getVarchar(13);
              ((string[]) buf[18])[0] = rslt.getVarchar(14);
              ((string[]) buf[19])[0] = rslt.getVarchar(15);
              ((decimal[]) buf[20])[0] = rslt.getDecimal(16);
              ((string[]) buf[21])[0] = rslt.getString(17, 40);
              ((bool[]) buf[22])[0] = rslt.wasNull(17);
              ((DateTime[]) buf[23])[0] = rslt.getGXDate(18);
              ((bool[]) buf[24])[0] = rslt.wasNull(18);
              ((DateTime[]) buf[25])[0] = rslt.getGXDateTime(19);
              ((bool[]) buf[26])[0] = rslt.wasNull(19);
              ((DateTime[]) buf[27])[0] = rslt.getGXDateTime(20, true);
              ((bool[]) buf[28])[0] = rslt.wasNull(20);
              ((string[]) buf[29])[0] = rslt.getString(21, 40);
              ((bool[]) buf[30])[0] = rslt.wasNull(21);
              ((short[]) buf[31])[0] = rslt.getShort(22);
              ((bool[]) buf[32])[0] = rslt.getBool(23);
              ((string[]) buf[33])[0] = rslt.getString(24, 20);
              ((bool[]) buf[34])[0] = rslt.wasNull(24);
              ((string[]) buf[35])[0] = rslt.getVarchar(25);
              ((bool[]) buf[36])[0] = rslt.wasNull(25);
              ((string[]) buf[37])[0] = rslt.getString(26, 20);
              ((bool[]) buf[38])[0] = rslt.wasNull(26);
              ((string[]) buf[39])[0] = rslt.getString(27, 20);
              ((bool[]) buf[40])[0] = rslt.wasNull(27);
              ((string[]) buf[41])[0] = rslt.getVarchar(28);
              ((bool[]) buf[42])[0] = rslt.wasNull(28);
              ((string[]) buf[43])[0] = rslt.getVarchar(29);
              ((bool[]) buf[44])[0] = rslt.wasNull(29);
              ((bool[]) buf[45])[0] = rslt.getBool(30);
              ((Guid[]) buf[46])[0] = rslt.getGuid(31);
              ((int[]) buf[47])[0] = rslt.getInt(32);
              ((Guid[]) buf[48])[0] = rslt.getGuid(33);
              ((bool[]) buf[49])[0] = rslt.wasNull(33);
              ((Guid[]) buf[50])[0] = rslt.getGuid(34);
              ((bool[]) buf[51])[0] = rslt.wasNull(34);
              return;
           case 1 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5, true);
              ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
              ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(7);
              ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(8, true);
              ((bool[]) buf[8])[0] = rslt.wasNull(8);
              ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(9);
              ((bool[]) buf[10])[0] = rslt.wasNull(9);
              ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(10);
              ((bool[]) buf[12])[0] = rslt.wasNull(10);
              ((string[]) buf[13])[0] = rslt.getString(11, 40);
              ((bool[]) buf[14])[0] = rslt.wasNull(11);
              ((string[]) buf[15])[0] = rslt.getVarchar(12);
              ((bool[]) buf[16])[0] = rslt.wasNull(12);
              ((string[]) buf[17])[0] = rslt.getVarchar(13);
              ((string[]) buf[18])[0] = rslt.getVarchar(14);
              ((string[]) buf[19])[0] = rslt.getVarchar(15);
              ((decimal[]) buf[20])[0] = rslt.getDecimal(16);
              ((string[]) buf[21])[0] = rslt.getString(17, 40);
              ((bool[]) buf[22])[0] = rslt.wasNull(17);
              ((DateTime[]) buf[23])[0] = rslt.getGXDate(18);
              ((bool[]) buf[24])[0] = rslt.wasNull(18);
              ((DateTime[]) buf[25])[0] = rslt.getGXDateTime(19);
              ((bool[]) buf[26])[0] = rslt.wasNull(19);
              ((DateTime[]) buf[27])[0] = rslt.getGXDateTime(20, true);
              ((bool[]) buf[28])[0] = rslt.wasNull(20);
              ((string[]) buf[29])[0] = rslt.getString(21, 40);
              ((bool[]) buf[30])[0] = rslt.wasNull(21);
              ((short[]) buf[31])[0] = rslt.getShort(22);
              ((bool[]) buf[32])[0] = rslt.getBool(23);
              ((string[]) buf[33])[0] = rslt.getString(24, 20);
              ((bool[]) buf[34])[0] = rslt.wasNull(24);
              ((string[]) buf[35])[0] = rslt.getVarchar(25);
              ((bool[]) buf[36])[0] = rslt.wasNull(25);
              ((string[]) buf[37])[0] = rslt.getString(26, 20);
              ((bool[]) buf[38])[0] = rslt.wasNull(26);
              ((string[]) buf[39])[0] = rslt.getString(27, 20);
              ((bool[]) buf[40])[0] = rslt.wasNull(27);
              ((string[]) buf[41])[0] = rslt.getVarchar(28);
              ((bool[]) buf[42])[0] = rslt.wasNull(28);
              ((string[]) buf[43])[0] = rslt.getVarchar(29);
              ((bool[]) buf[44])[0] = rslt.wasNull(29);
              ((bool[]) buf[45])[0] = rslt.getBool(30);
              ((Guid[]) buf[46])[0] = rslt.getGuid(31);
              ((int[]) buf[47])[0] = rslt.getInt(32);
              ((Guid[]) buf[48])[0] = rslt.getGuid(33);
              ((bool[]) buf[49])[0] = rslt.wasNull(33);
              ((Guid[]) buf[50])[0] = rslt.getGuid(34);
              ((bool[]) buf[51])[0] = rslt.wasNull(34);
              return;
           case 2 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((int[]) buf[5])[0] = rslt.getInt(6);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 7 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5, true);
              ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
              ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(7);
              ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(8, true);
              ((bool[]) buf[8])[0] = rslt.wasNull(8);
              ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(9);
              ((bool[]) buf[10])[0] = rslt.wasNull(9);
              ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(10);
              ((bool[]) buf[12])[0] = rslt.wasNull(10);
              ((string[]) buf[13])[0] = rslt.getString(11, 40);
              ((bool[]) buf[14])[0] = rslt.wasNull(11);
              ((string[]) buf[15])[0] = rslt.getVarchar(12);
              ((bool[]) buf[16])[0] = rslt.wasNull(12);
              ((long[]) buf[17])[0] = rslt.getLong(13);
              ((string[]) buf[18])[0] = rslt.getVarchar(14);
              ((string[]) buf[19])[0] = rslt.getVarchar(15);
              ((string[]) buf[20])[0] = rslt.getVarchar(16);
              ((long[]) buf[21])[0] = rslt.getLong(17);
              ((long[]) buf[22])[0] = rslt.getLong(18);
              ((string[]) buf[23])[0] = rslt.getVarchar(19);
              ((string[]) buf[24])[0] = rslt.getVarchar(20);
              ((string[]) buf[25])[0] = rslt.getVarchar(21);
              ((long[]) buf[26])[0] = rslt.getLong(22);
              ((long[]) buf[27])[0] = rslt.getLong(23);
              ((string[]) buf[28])[0] = rslt.getVarchar(24);
              ((string[]) buf[29])[0] = rslt.getVarchar(25);
              ((string[]) buf[30])[0] = rslt.getVarchar(26);
              ((string[]) buf[31])[0] = rslt.getVarchar(27);
              ((string[]) buf[32])[0] = rslt.getVarchar(28);
              ((string[]) buf[33])[0] = rslt.getVarchar(29);
              ((string[]) buf[34])[0] = rslt.getVarchar(30);
              ((string[]) buf[35])[0] = rslt.getVarchar(31);
              ((decimal[]) buf[36])[0] = rslt.getDecimal(32);
              ((string[]) buf[37])[0] = rslt.getString(33, 40);
              ((bool[]) buf[38])[0] = rslt.wasNull(33);
              ((DateTime[]) buf[39])[0] = rslt.getGXDate(34);
              ((bool[]) buf[40])[0] = rslt.wasNull(34);
              ((DateTime[]) buf[41])[0] = rslt.getGXDateTime(35);
              ((bool[]) buf[42])[0] = rslt.wasNull(35);
              ((DateTime[]) buf[43])[0] = rslt.getGXDateTime(36, true);
              ((bool[]) buf[44])[0] = rslt.wasNull(36);
              ((string[]) buf[45])[0] = rslt.getString(37, 40);
              ((bool[]) buf[46])[0] = rslt.wasNull(37);
              ((short[]) buf[47])[0] = rslt.getShort(38);
              ((bool[]) buf[48])[0] = rslt.getBool(39);
              ((string[]) buf[49])[0] = rslt.getString(40, 20);
              ((bool[]) buf[50])[0] = rslt.wasNull(40);
              ((string[]) buf[51])[0] = rslt.getVarchar(41);
              ((bool[]) buf[52])[0] = rslt.wasNull(41);
              ((string[]) buf[53])[0] = rslt.getString(42, 20);
              ((bool[]) buf[54])[0] = rslt.wasNull(42);
              ((string[]) buf[55])[0] = rslt.getString(43, 20);
              ((bool[]) buf[56])[0] = rslt.wasNull(43);
              ((string[]) buf[57])[0] = rslt.getVarchar(44);
              ((bool[]) buf[58])[0] = rslt.wasNull(44);
              ((string[]) buf[59])[0] = rslt.getVarchar(45);
              ((bool[]) buf[60])[0] = rslt.wasNull(45);
              ((bool[]) buf[61])[0] = rslt.getBool(46);
              ((Guid[]) buf[62])[0] = rslt.getGuid(47);
              ((int[]) buf[63])[0] = rslt.getInt(48);
              ((Guid[]) buf[64])[0] = rslt.getGuid(49);
              ((bool[]) buf[65])[0] = rslt.wasNull(49);
              ((Guid[]) buf[66])[0] = rslt.getGuid(50);
              ((bool[]) buf[67])[0] = rslt.wasNull(50);
              ((int[]) buf[68])[0] = rslt.getInt(51);
              return;
           case 8 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((int[]) buf[5])[0] = rslt.getInt(6);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 13 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              return;
           case 14 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              return;
           case 15 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              return;
           case 19 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 20 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((int[]) buf[5])[0] = rslt.getInt(6);
              return;
           case 21 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 22 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 23 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              return;
           case 24 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              return;
           case 25 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              return;
           case 26 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 27 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              return;
           case 28 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              return;
           case 29 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              return;
     }
     getresults30( cursor, rslt, buf) ;
  }

  public void getresults30( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
  {
     switch ( cursor )
     {
           case 30 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 31 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 32 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 33 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((int[]) buf[5])[0] = rslt.getInt(6);
              return;
           case 34 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
     }
  }

}

}
