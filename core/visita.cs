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
   public class visita : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxJX_Action51") == 0 )
         {
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            XC_51_1440( ) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel13"+"_"+"VISPAIID") == 0 )
         {
            AV13Insert_VisPaiID = StringUtil.StrToGuid( GetPar( "Insert_VisPaiID"));
            AssignAttri("", false, "AV13Insert_VisPaiID", AV13Insert_VisPaiID.ToString());
            AV40VisPaiID = StringUtil.StrToGuid( GetPar( "VisPaiID"));
            AssignAttri("", false, "AV40VisPaiID", AV40VisPaiID.ToString());
            GxWebStd.gx_hidden_field( context, "gxhash_vVISPAIID", GetSecureSignedToken( "", AV40VisPaiID, context));
            Gx_BScreen = (short)(Math.Round(NumberUtil.Val( GetPar( "Gx_BScreen"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX13ASAVISPAIID1440( AV13Insert_VisPaiID, AV40VisPaiID, Gx_BScreen) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_57") == 0 )
         {
            A419VisPaiID = StringUtil.StrToGuid( GetPar( "VisPaiID"));
            n419VisPaiID = false;
            AssignAttri("", false, "A419VisPaiID", A419VisPaiID.ToString());
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_57( A419VisPaiID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_54") == 0 )
         {
            A414VisTipoID = (int)(Math.Round(NumberUtil.Val( GetPar( "VisTipoID"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A414VisTipoID", StringUtil.LTrimStr( (decimal)(A414VisTipoID), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_54( A414VisTipoID) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "core.visita.aspx")), "core.visita.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "core.visita.aspx")))) ;
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
                  AV7VisID = StringUtil.StrToGuid( GetPar( "VisID"));
                  AssignAttri("", false, "AV7VisID", AV7VisID.ToString());
                  GxWebStd.gx_hidden_field( context, "gxhash_vVISID", GetSecureSignedToken( "", AV7VisID, context));
                  AV40VisPaiID = StringUtil.StrToGuid( GetPar( "VisPaiID"));
                  AssignAttri("", false, "AV40VisPaiID", AV40VisPaiID.ToString());
                  GxWebStd.gx_hidden_field( context, "gxhash_vVISPAIID", GetSecureSignedToken( "", AV40VisPaiID, context));
                  A418VisNegID = StringUtil.StrToGuid( GetPar( "VisNegID"));
                  n418VisNegID = false;
                  AssignAttri("", false, "A418VisNegID", A418VisNegID.ToString());
                  A422VisNgfSeq = (int)(Math.Round(NumberUtil.Val( GetPar( "VisNgfSeq"), "."), 18, MidpointRounding.ToEven));
                  n422VisNgfSeq = false;
                  AssignAttri("", false, "A422VisNgfSeq", StringUtil.LTrimStr( (decimal)(A422VisNgfSeq), 8, 0));
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
            Form.Meta.addItem("description", "Visita", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtVisTipoID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public visita( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public visita( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           Guid aP1_VisID ,
                           Guid aP2_VisPaiID ,
                           Guid aP3_NegID ,
                           int aP4_NgfSeq )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7VisID = aP1_VisID;
         this.AV40VisPaiID = aP2_VisPaiID;
         this.A418VisNegID = aP3_NegID;
         this.A422VisNgfSeq = aP4_NgfSeq;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbVisSituacao = new GXCombobox();
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
            return "visita_Execute" ;
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
         if ( cmbVisSituacao.ItemCount > 0 )
         {
            A472VisSituacao = cmbVisSituacao.getValidValue(A472VisSituacao);
            AssignAttri("", false, "A472VisSituacao", A472VisSituacao);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbVisSituacao.CurrentValue = StringUtil.RTrim( A472VisSituacao);
            AssignProp("", false, cmbVisSituacao_Internalname, "Values", cmbVisSituacao.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtVisNegCodigo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtVisNegCodigo_Internalname, "Negociação", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtVisNegCodigo_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A466VisNegCodigo), 12, 0, ",", "")), StringUtil.LTrim( ((edtVisNegCodigo_Enabled!=0) ? context.localUtil.Format( (decimal)(A466VisNegCodigo), "ZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A466VisNegCodigo), "ZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVisNegCodigo_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtVisNegCodigo_Enabled, 0, "text", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_core\\Visita.htm");
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
         GxWebStd.gx_single_line_edit( context, edtVisNegAssunto_Internalname, A467VisNegAssunto, StringUtil.RTrim( context.localUtil.Format( A467VisNegAssunto, "@!")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVisNegAssunto_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtVisNegAssunto_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\Visita.htm");
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
         GxWebStd.gx_single_line_edit( context, edtVisNegCliNomeFamiliar_Internalname, A469VisNegCliNomeFamiliar, StringUtil.RTrim( context.localUtil.Format( A469VisNegCliNomeFamiliar, "@!")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVisNegCliNomeFamiliar_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtVisNegCliNomeFamiliar_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "core\\Nome", "start", true, "", "HLP_core\\Visita.htm");
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
         GxWebStd.gx_single_line_edit( context, edtVisNegCpjNomFan_Internalname, A470VisNegCpjNomFan, StringUtil.RTrim( context.localUtil.Format( A470VisNegCpjNomFan, "@!")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVisNegCpjNomFan_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtVisNegCpjNomFan_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "core\\Nome", "start", true, "", "HLP_core\\Visita.htm");
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
         GxWebStd.gx_single_line_edit( context, edtVisNegValor_Internalname, StringUtil.LTrim( StringUtil.NToC( A468VisNegValor, 23, 2, ",", "")), StringUtil.LTrim( ((edtVisNegValor_Enabled!=0) ? context.localUtil.Format( A468VisNegValor, "R$ Z,ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A468VisNegValor, "R$ Z,ZZZ,ZZZ,ZZZ,ZZ9.99"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVisNegValor_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtVisNegValor_Enabled, 0, "text", "", 23, "chr", 1, "row", 23, 0, 0, 0, 0, -1, 0, true, "core\\Monetario", "end", false, "", "HLP_core\\Visita.htm");
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
         GxWebStd.gx_single_line_edit( context, edtVisNgfIteNome_Internalname, A424VisNgfIteNome, StringUtil.RTrim( context.localUtil.Format( A424VisNgfIteNome, "@!")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVisNgfIteNome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtVisNgfIteNome_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "core\\Nome", "start", true, "", "HLP_core\\Visita.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTxtesp01_Internalname, "&nbsp;", "", "", lblTxtesp01_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_core\\Visita.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Control Group */
         GxWebStd.gx_group_start( context, grpTablegroupvisitaorigem_Internalname, "Visita origem", 1, 0, "px", 0, "px", grpTablegroupvisitaorigem_Class, "", "HLP_core\\Visita.htm");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablevisitaorigem_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
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
         GxWebStd.gx_single_line_edit( context, edtVisPaiAssunto_Internalname, A465VisPaiAssunto, StringUtil.RTrim( context.localUtil.Format( A465VisPaiAssunto, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVisPaiAssunto_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtVisPaiAssunto_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\Visita.htm");
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
         GxWebStd.gx_single_line_edit( context, edtVisPaiDataHora_Internalname, context.localUtil.TToC( A462VisPaiDataHora, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A462VisPaiDataHora, "99/99/9999 99:99"), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVisPaiDataHora_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtVisPaiDataHora_Enabled, 0, "text", "", 16, "chr", 1, "row", 16, 0, 0, 0, 0, -1, 0, true, "core\\DataHora", "end", false, "", "HLP_core\\Visita.htm");
         GxWebStd.gx_bitmap( context, edtVisPaiDataHora_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtVisPaiDataHora_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_core\\Visita.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedvistipoid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockvistipoid_Internalname, "Tipo da Visita", "", "", lblTextblockvistipoid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_core\\Visita.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_vistipoid.SetProperty("Caption", Combo_vistipoid_Caption);
         ucCombo_vistipoid.SetProperty("Cls", Combo_vistipoid_Cls);
         ucCombo_vistipoid.SetProperty("IncludeAddNewOption", Combo_vistipoid_Includeaddnewoption);
         ucCombo_vistipoid.SetProperty("EmptyItemText", Combo_vistipoid_Emptyitemtext);
         ucCombo_vistipoid.SetProperty("DropDownOptionsData", AV26VisTipoID_Data);
         ucCombo_vistipoid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_vistipoid_Internalname, "COMBO_VISTIPOIDContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtVisTipoID_Internalname, "ID do Tipo da Visita", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVisTipoID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A414VisTipoID), 11, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A414VisTipoID), "ZZZ,ZZZ,ZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,71);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVisTipoID_Jsonclick, 0, "Attribute", "", "", "", "", edtVisTipoID_Visible, edtVisTipoID_Enabled, 1, "text", "", 11, "chr", 1, "row", 11, 0, 0, 0, 0, -1, 0, true, "core\\ID_Autonum", "end", false, "", "HLP_core\\Visita.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
         /* Control Group */
         GxWebStd.gx_group_start( context, grpUnnamedgroup1_Internalname, "Início", 1, 0, "px", 0, "px", "Group", "", "HLP_core\\Visita.htm");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTxtdatahorainicio_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtVisData_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtVisData_Internalname, "Data", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtVisData_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtVisData_Internalname, context.localUtil.Format(A404VisData, "99/99/99"), context.localUtil.Format( A404VisData, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVisData_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtVisData_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "core\\Data", "end", false, "", "HLP_core\\Visita.htm");
         GxWebStd.gx_bitmap( context, edtVisData_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtVisData_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_core\\Visita.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtVisHora_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtVisHora_Internalname, "Hora", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtVisHora_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtVisHora_Internalname, context.localUtil.TToC( A405VisHora, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A405VisHora, "99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,83);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVisHora_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtVisHora_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 0, -1, 0, true, "core\\HoraMinuto", "end", false, "", "HLP_core\\Visita.htm");
         GxWebStd.gx_bitmap( context, edtVisHora_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtVisHora_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_core\\Visita.htm");
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
         GxWebStd.gx_group_start( context, grpUnnamedgroup2_Internalname, "Término", 1, 0, "px", 0, "px", "Group", "", "HLP_core\\Visita.htm");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTxtdatahoratermino_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtVisDataFim_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtVisDataFim_Internalname, "Data", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtVisDataFim_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtVisDataFim_Internalname, context.localUtil.Format(A475VisDataFim, "99/99/99"), context.localUtil.Format( A475VisDataFim, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onblur(this,91);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVisDataFim_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtVisDataFim_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "core\\Data", "end", false, "", "HLP_core\\Visita.htm");
         GxWebStd.gx_bitmap( context, edtVisDataFim_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtVisDataFim_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_core\\Visita.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtVisHoraFim_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtVisHoraFim_Internalname, "Hora", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 95,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtVisHoraFim_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtVisHoraFim_Internalname, context.localUtil.TToC( A476VisHoraFim, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A476VisHoraFim, "99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,95);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVisHoraFim_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtVisHoraFim_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 0, -1, 0, true, "core\\HoraMinuto", "end", false, "", "HLP_core\\Visita.htm");
         GxWebStd.gx_bitmap( context, edtVisHoraFim_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtVisHoraFim_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_core\\Visita.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtVisAssunto_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtVisAssunto_Internalname, "Assunto da Visita", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 100,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVisAssunto_Internalname, A409VisAssunto, StringUtil.RTrim( context.localUtil.Format( A409VisAssunto, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,100);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVisAssunto_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtVisAssunto_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\Visita.htm");
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
         GxWebStd.gx_combobox_ctrl1( context, cmbVisSituacao, cmbVisSituacao_Internalname, StringUtil.RTrim( A472VisSituacao), 1, cmbVisSituacao_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbVisSituacao.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", "", "", true, 0, "HLP_core\\Visita.htm");
         cmbVisSituacao.CurrentValue = StringUtil.RTrim( A472VisSituacao);
         AssignProp("", false, cmbVisSituacao_Internalname, "Values", (string)(cmbVisSituacao.ToJavascriptSource()), true);
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 108,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVisLink_Internalname, A417VisLink, StringUtil.RTrim( context.localUtil.Format( A417VisLink, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,108);\"", "'"+""+"'"+",false,"+"'"+""+"'", A417VisLink, "_blank", "", "", edtVisLink_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtVisLink_Enabled, 0, "url", "", 80, "chr", 1, "row", 1000, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Url", "start", true, "", "HLP_core\\Visita.htm");
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
         ucVisdescricao.Render(context, "fckeditor", Visdescricao_Internalname, "VISDESCRICAOContainer");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 116,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\Visita.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 118,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\Visita.htm");
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
         GxWebStd.gx_div_start( context, divSectionattribute_vistipoid_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtavCombovistipoid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV27ComboVisTipoID), 11, 0, ",", "")), StringUtil.LTrim( ((edtavCombovistipoid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV27ComboVisTipoID), "ZZZ,ZZZ,ZZ9") : context.localUtil.Format( (decimal)(AV27ComboVisTipoID), "ZZZ,ZZZ,ZZ9"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombovistipoid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombovistipoid_Visible, edtavCombovistipoid_Enabled, 0, "text", "", 11, "chr", 1, "row", 11, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_core\\Visita.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtavVispaiid_Internalname, AV40VisPaiID.ToString(), AV40VisPaiID.ToString(), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavVispaiid_Jsonclick, 0, "Attribute", "", "", "", "", edtavVispaiid_Visible, edtavVispaiid_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_core\\Visita.htm");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtavVisnegid_Internalname, AV41VisNegID.ToString(), AV41VisNegID.ToString(), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavVisnegid_Jsonclick, 0, "Attribute", "", "", "", "", edtavVisnegid_Visible, edtavVisnegid_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_core\\Visita.htm");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtavVisngfseq_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV42VisNgfSeq), 10, 0, ",", "")), StringUtil.LTrim( ((edtavVisngfseq_Enabled!=0) ? context.localUtil.Format( (decimal)(AV42VisNgfSeq), "ZZ,ZZZ,ZZ9") : context.localUtil.Format( (decimal)(AV42VisNgfSeq), "ZZ,ZZZ,ZZ9"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavVisngfseq_Jsonclick, 0, "Attribute", "", "", "", "", edtavVisngfseq_Visible, edtavVisngfseq_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_core\\Visita.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 127,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtVisDataHoraFim_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtVisDataHoraFim_Internalname, context.localUtil.TToC( A477VisDataHoraFim, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A477VisDataHoraFim, "99/99/9999 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,127);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVisDataHoraFim_Jsonclick, 0, "Attribute", "", "", "", "", edtVisDataHoraFim_Visible, edtVisDataHoraFim_Enabled, 0, "text", "", 16, "chr", 1, "row", 16, 0, 0, 0, 0, -1, 0, true, "core\\DataHora", "end", false, "", "HLP_core\\Visita.htm");
         GxWebStd.gx_bitmap( context, edtVisDataHoraFim_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtVisDataHoraFim_Visible==0)||(edtVisDataHoraFim_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_core\\Visita.htm");
         context.WriteHtmlTextNl( "</div>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 128,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtVisDataHora_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtVisDataHora_Internalname, context.localUtil.TToC( A406VisDataHora, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A406VisDataHora, "99/99/9999 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,128);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVisDataHora_Jsonclick, 0, "Attribute", "", "", "", "", edtVisDataHora_Visible, edtVisDataHora_Enabled, 0, "text", "", 16, "chr", 1, "row", 16, 0, 0, 0, 0, -1, 0, true, "core\\DataHora", "end", false, "", "HLP_core\\Visita.htm");
         GxWebStd.gx_bitmap( context, edtVisDataHora_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtVisDataHora_Visible==0)||(edtVisDataHora_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_core\\Visita.htm");
         context.WriteHtmlTextNl( "</div>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 129,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVisPaiID_Internalname, A419VisPaiID.ToString(), A419VisPaiID.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,129);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVisPaiID_Jsonclick, 0, "Attribute", "", "", "", "", edtVisPaiID_Visible, edtVisPaiID_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_core\\Visita.htm");
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
         E11142 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vVISTIPOID_DATA"), AV26VisTipoID_Data);
               /* Read saved values. */
               Z398VisID = StringUtil.StrToGuid( cgiGet( "Z398VisID"));
               Z401VisInsDataHora = context.localUtil.CToT( cgiGet( "Z401VisInsDataHora"), 0);
               Z399VisInsData = context.localUtil.CToD( cgiGet( "Z399VisInsData"), 0);
               Z400VisInsHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z400VisInsHora"), 0));
               Z402VisInsUsuID = cgiGet( "Z402VisInsUsuID");
               n402VisInsUsuID = (String.IsNullOrEmpty(StringUtil.RTrim( A402VisInsUsuID)) ? true : false);
               Z403VisInsUsuNome = cgiGet( "Z403VisInsUsuNome");
               n403VisInsUsuNome = (String.IsNullOrEmpty(StringUtil.RTrim( A403VisInsUsuNome)) ? true : false);
               Z490VisDelDataHora = context.localUtil.CToT( cgiGet( "Z490VisDelDataHora"), 0);
               n490VisDelDataHora = ((DateTime.MinValue==A490VisDelDataHora) ? true : false);
               Z488VisDelData = context.localUtil.CToT( cgiGet( "Z488VisDelData"), 0);
               n488VisDelData = ((DateTime.MinValue==A488VisDelData) ? true : false);
               Z489VisDelHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z489VisDelHora"), 0));
               n489VisDelHora = ((DateTime.MinValue==A489VisDelHora) ? true : false);
               Z491VisDelUsuID = cgiGet( "Z491VisDelUsuID");
               n491VisDelUsuID = (String.IsNullOrEmpty(StringUtil.RTrim( A491VisDelUsuID)) ? true : false);
               Z492VisDelUsuNome = cgiGet( "Z492VisDelUsuNome");
               n492VisDelUsuNome = (String.IsNullOrEmpty(StringUtil.RTrim( A492VisDelUsuNome)) ? true : false);
               Z482VisUpdData = context.localUtil.CToD( cgiGet( "Z482VisUpdData"), 0);
               n482VisUpdData = ((DateTime.MinValue==A482VisUpdData) ? true : false);
               Z483VisUpdHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z483VisUpdHora"), 0));
               n483VisUpdHora = ((DateTime.MinValue==A483VisUpdHora) ? true : false);
               Z484VisUpdDataHora = context.localUtil.CToT( cgiGet( "Z484VisUpdDataHora"), 0);
               n484VisUpdDataHora = ((DateTime.MinValue==A484VisUpdDataHora) ? true : false);
               Z485VisUpdUsuID = cgiGet( "Z485VisUpdUsuID");
               n485VisUpdUsuID = (String.IsNullOrEmpty(StringUtil.RTrim( A485VisUpdUsuID)) ? true : false);
               Z486VisUpdUsuNome = cgiGet( "Z486VisUpdUsuNome");
               n486VisUpdUsuNome = (String.IsNullOrEmpty(StringUtil.RTrim( A486VisUpdUsuNome)) ? true : false);
               Z404VisData = context.localUtil.CToD( cgiGet( "Z404VisData"), 0);
               Z405VisHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z405VisHora"), 0));
               Z406VisDataHora = context.localUtil.CToT( cgiGet( "Z406VisDataHora"), 0);
               Z475VisDataFim = context.localUtil.CToD( cgiGet( "Z475VisDataFim"), 0);
               n475VisDataFim = ((DateTime.MinValue==A475VisDataFim) ? true : false);
               Z476VisHoraFim = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z476VisHoraFim"), 0));
               n476VisHoraFim = ((DateTime.MinValue==A476VisHoraFim) ? true : false);
               Z477VisDataHoraFim = context.localUtil.CToT( cgiGet( "Z477VisDataHoraFim"), 0);
               n477VisDataHoraFim = ((DateTime.MinValue==A477VisDataHoraFim) ? true : false);
               Z409VisAssunto = cgiGet( "Z409VisAssunto");
               Z417VisLink = cgiGet( "Z417VisLink");
               n417VisLink = (String.IsNullOrEmpty(StringUtil.RTrim( A417VisLink)) ? true : false);
               Z472VisSituacao = cgiGet( "Z472VisSituacao");
               Z487VisDel = StringUtil.StrToBool( cgiGet( "Z487VisDel"));
               Z414VisTipoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z414VisTipoID"), ",", "."), 18, MidpointRounding.ToEven));
               Z419VisPaiID = StringUtil.StrToGuid( cgiGet( "Z419VisPaiID"));
               n419VisPaiID = ((Guid.Empty==A419VisPaiID) ? true : false);
               A401VisInsDataHora = context.localUtil.CToT( cgiGet( "Z401VisInsDataHora"), 0);
               A399VisInsData = context.localUtil.CToD( cgiGet( "Z399VisInsData"), 0);
               A400VisInsHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z400VisInsHora"), 0));
               A402VisInsUsuID = cgiGet( "Z402VisInsUsuID");
               n402VisInsUsuID = false;
               n402VisInsUsuID = (String.IsNullOrEmpty(StringUtil.RTrim( A402VisInsUsuID)) ? true : false);
               A403VisInsUsuNome = cgiGet( "Z403VisInsUsuNome");
               n403VisInsUsuNome = false;
               n403VisInsUsuNome = (String.IsNullOrEmpty(StringUtil.RTrim( A403VisInsUsuNome)) ? true : false);
               A490VisDelDataHora = context.localUtil.CToT( cgiGet( "Z490VisDelDataHora"), 0);
               n490VisDelDataHora = false;
               n490VisDelDataHora = ((DateTime.MinValue==A490VisDelDataHora) ? true : false);
               A488VisDelData = context.localUtil.CToT( cgiGet( "Z488VisDelData"), 0);
               n488VisDelData = false;
               n488VisDelData = ((DateTime.MinValue==A488VisDelData) ? true : false);
               A489VisDelHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z489VisDelHora"), 0));
               n489VisDelHora = false;
               n489VisDelHora = ((DateTime.MinValue==A489VisDelHora) ? true : false);
               A491VisDelUsuID = cgiGet( "Z491VisDelUsuID");
               n491VisDelUsuID = false;
               n491VisDelUsuID = (String.IsNullOrEmpty(StringUtil.RTrim( A491VisDelUsuID)) ? true : false);
               A492VisDelUsuNome = cgiGet( "Z492VisDelUsuNome");
               n492VisDelUsuNome = false;
               n492VisDelUsuNome = (String.IsNullOrEmpty(StringUtil.RTrim( A492VisDelUsuNome)) ? true : false);
               A482VisUpdData = context.localUtil.CToD( cgiGet( "Z482VisUpdData"), 0);
               n482VisUpdData = false;
               n482VisUpdData = ((DateTime.MinValue==A482VisUpdData) ? true : false);
               A483VisUpdHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z483VisUpdHora"), 0));
               n483VisUpdHora = false;
               n483VisUpdHora = ((DateTime.MinValue==A483VisUpdHora) ? true : false);
               A484VisUpdDataHora = context.localUtil.CToT( cgiGet( "Z484VisUpdDataHora"), 0);
               n484VisUpdDataHora = false;
               n484VisUpdDataHora = ((DateTime.MinValue==A484VisUpdDataHora) ? true : false);
               A485VisUpdUsuID = cgiGet( "Z485VisUpdUsuID");
               n485VisUpdUsuID = false;
               n485VisUpdUsuID = (String.IsNullOrEmpty(StringUtil.RTrim( A485VisUpdUsuID)) ? true : false);
               A486VisUpdUsuNome = cgiGet( "Z486VisUpdUsuNome");
               n486VisUpdUsuNome = false;
               n486VisUpdUsuNome = (String.IsNullOrEmpty(StringUtil.RTrim( A486VisUpdUsuNome)) ? true : false);
               A487VisDel = StringUtil.StrToBool( cgiGet( "Z487VisDel"));
               O487VisDel = StringUtil.StrToBool( cgiGet( "O487VisDel"));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N419VisPaiID = StringUtil.StrToGuid( cgiGet( "N419VisPaiID"));
               n419VisPaiID = ((Guid.Empty==A419VisPaiID) ? true : false);
               N414VisTipoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N414VisTipoID"), ",", "."), 18, MidpointRounding.ToEven));
               N418VisNegID = StringUtil.StrToGuid( cgiGet( "N418VisNegID"));
               n418VisNegID = ((Guid.Empty==A418VisNegID) ? true : false);
               N422VisNgfSeq = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N422VisNgfSeq"), ",", "."), 18, MidpointRounding.ToEven));
               n422VisNgfSeq = ((0==A422VisNgfSeq) ? true : false);
               AV7VisID = StringUtil.StrToGuid( cgiGet( "vVISID"));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ",", "."), 18, MidpointRounding.ToEven));
               A398VisID = StringUtil.StrToGuid( cgiGet( "VISID"));
               AV13Insert_VisPaiID = StringUtil.StrToGuid( cgiGet( "vINSERT_VISPAIID"));
               AV14Insert_VisTipoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_VISTIPOID"), ",", "."), 18, MidpointRounding.ToEven));
               AV15Insert_VisNegID = StringUtil.StrToGuid( cgiGet( "vINSERT_VISNEGID"));
               A418VisNegID = StringUtil.StrToGuid( cgiGet( "VISNEGID"));
               n418VisNegID = ((Guid.Empty==A418VisNegID) ? true : false);
               AV16Insert_VisNgfSeq = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_VISNGFSEQ"), ",", "."), 18, MidpointRounding.ToEven));
               A422VisNgfSeq = (int)(Math.Round(context.localUtil.CToN( cgiGet( "VISNGFSEQ"), ",", "."), 18, MidpointRounding.ToEven));
               n422VisNgfSeq = ((0==A422VisNgfSeq) ? true : false);
               A401VisInsDataHora = context.localUtil.CToT( cgiGet( "VISINSDATAHORA"), 0);
               A399VisInsData = context.localUtil.CToD( cgiGet( "VISINSDATA"), 0);
               A400VisInsHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "VISINSHORA"), 0));
               A402VisInsUsuID = cgiGet( "VISINSUSUID");
               n402VisInsUsuID = (String.IsNullOrEmpty(StringUtil.RTrim( A402VisInsUsuID)) ? true : false);
               A403VisInsUsuNome = cgiGet( "VISINSUSUNOME");
               n403VisInsUsuNome = (String.IsNullOrEmpty(StringUtil.RTrim( A403VisInsUsuNome)) ? true : false);
               A487VisDel = StringUtil.StrToBool( cgiGet( "VISDEL"));
               A490VisDelDataHora = context.localUtil.CToT( cgiGet( "VISDELDATAHORA"), 0);
               n490VisDelDataHora = ((DateTime.MinValue==A490VisDelDataHora) ? true : false);
               A488VisDelData = context.localUtil.CToT( cgiGet( "VISDELDATA"), 0);
               n488VisDelData = ((DateTime.MinValue==A488VisDelData) ? true : false);
               A489VisDelHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "VISDELHORA"), 0));
               n489VisDelHora = ((DateTime.MinValue==A489VisDelHora) ? true : false);
               A491VisDelUsuID = cgiGet( "VISDELUSUID");
               n491VisDelUsuID = (String.IsNullOrEmpty(StringUtil.RTrim( A491VisDelUsuID)) ? true : false);
               A492VisDelUsuNome = cgiGet( "VISDELUSUNOME");
               n492VisDelUsuNome = (String.IsNullOrEmpty(StringUtil.RTrim( A492VisDelUsuNome)) ? true : false);
               ajax_req_read_hidden_sdt(cgiGet( "vAUDITINGOBJECT"), AV43AuditingObject);
               ajax_req_read_hidden_sdt(cgiGet( "vMESSAGES"), AV44Messages);
               A482VisUpdData = context.localUtil.CToD( cgiGet( "VISUPDDATA"), 0);
               n482VisUpdData = ((DateTime.MinValue==A482VisUpdData) ? true : false);
               A483VisUpdHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "VISUPDHORA"), 0));
               n483VisUpdHora = ((DateTime.MinValue==A483VisUpdHora) ? true : false);
               A484VisUpdDataHora = context.localUtil.CToT( cgiGet( "VISUPDDATAHORA"), 0);
               n484VisUpdDataHora = ((DateTime.MinValue==A484VisUpdDataHora) ? true : false);
               A485VisUpdUsuID = cgiGet( "VISUPDUSUID");
               n485VisUpdUsuID = (String.IsNullOrEmpty(StringUtil.RTrim( A485VisUpdUsuID)) ? true : false);
               A486VisUpdUsuNome = cgiGet( "VISUPDUSUNOME");
               n486VisUpdUsuNome = (String.IsNullOrEmpty(StringUtil.RTrim( A486VisUpdUsuNome)) ? true : false);
               A410VisDescricao = cgiGet( "VISDESCRICAO");
               n410VisDescricao = false;
               n410VisDescricao = (String.IsNullOrEmpty(StringUtil.RTrim( A410VisDescricao)) ? true : false);
               A415VisTipoSigla = cgiGet( "VISTIPOSIGLA");
               A416VisTipoNome = cgiGet( "VISTIPONOME");
               A407VisNegCliID = StringUtil.StrToGuid( cgiGet( "VISNEGCLIID"));
               A408VisNegCpjID = StringUtil.StrToGuid( cgiGet( "VISNEGCPJID"));
               A423VisNgfIteID = StringUtil.StrToGuid( cgiGet( "VISNGFITEID"));
               A460VisPaiData = context.localUtil.CToD( cgiGet( "VISPAIDATA"), 0);
               A461VisPaiHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "VISPAIHORA"), 0));
               A471VisNegCpjRazSocial = cgiGet( "VISNEGCPJRAZSOCIAL");
               AV46Pgmname = cgiGet( "vPGMNAME");
               Combo_vistipoid_Objectcall = cgiGet( "COMBO_VISTIPOID_Objectcall");
               Combo_vistipoid_Class = cgiGet( "COMBO_VISTIPOID_Class");
               Combo_vistipoid_Icontype = cgiGet( "COMBO_VISTIPOID_Icontype");
               Combo_vistipoid_Icon = cgiGet( "COMBO_VISTIPOID_Icon");
               Combo_vistipoid_Caption = cgiGet( "COMBO_VISTIPOID_Caption");
               Combo_vistipoid_Tooltip = cgiGet( "COMBO_VISTIPOID_Tooltip");
               Combo_vistipoid_Cls = cgiGet( "COMBO_VISTIPOID_Cls");
               Combo_vistipoid_Selectedvalue_set = cgiGet( "COMBO_VISTIPOID_Selectedvalue_set");
               Combo_vistipoid_Selectedvalue_get = cgiGet( "COMBO_VISTIPOID_Selectedvalue_get");
               Combo_vistipoid_Selectedtext_set = cgiGet( "COMBO_VISTIPOID_Selectedtext_set");
               Combo_vistipoid_Selectedtext_get = cgiGet( "COMBO_VISTIPOID_Selectedtext_get");
               Combo_vistipoid_Gamoauthtoken = cgiGet( "COMBO_VISTIPOID_Gamoauthtoken");
               Combo_vistipoid_Ddointernalname = cgiGet( "COMBO_VISTIPOID_Ddointernalname");
               Combo_vistipoid_Titlecontrolalign = cgiGet( "COMBO_VISTIPOID_Titlecontrolalign");
               Combo_vistipoid_Dropdownoptionstype = cgiGet( "COMBO_VISTIPOID_Dropdownoptionstype");
               Combo_vistipoid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_VISTIPOID_Enabled"));
               Combo_vistipoid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_VISTIPOID_Visible"));
               Combo_vistipoid_Titlecontrolidtoreplace = cgiGet( "COMBO_VISTIPOID_Titlecontrolidtoreplace");
               Combo_vistipoid_Datalisttype = cgiGet( "COMBO_VISTIPOID_Datalisttype");
               Combo_vistipoid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_VISTIPOID_Allowmultipleselection"));
               Combo_vistipoid_Datalistfixedvalues = cgiGet( "COMBO_VISTIPOID_Datalistfixedvalues");
               Combo_vistipoid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_VISTIPOID_Isgriditem"));
               Combo_vistipoid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_VISTIPOID_Hasdescription"));
               Combo_vistipoid_Datalistproc = cgiGet( "COMBO_VISTIPOID_Datalistproc");
               Combo_vistipoid_Datalistprocparametersprefix = cgiGet( "COMBO_VISTIPOID_Datalistprocparametersprefix");
               Combo_vistipoid_Remoteservicesparameters = cgiGet( "COMBO_VISTIPOID_Remoteservicesparameters");
               Combo_vistipoid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_VISTIPOID_Datalistupdateminimumcharacters"), ",", "."), 18, MidpointRounding.ToEven));
               Combo_vistipoid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_VISTIPOID_Includeonlyselectedoption"));
               Combo_vistipoid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_VISTIPOID_Includeselectalloption"));
               Combo_vistipoid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_VISTIPOID_Emptyitem"));
               Combo_vistipoid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_VISTIPOID_Includeaddnewoption"));
               Combo_vistipoid_Htmltemplate = cgiGet( "COMBO_VISTIPOID_Htmltemplate");
               Combo_vistipoid_Multiplevaluestype = cgiGet( "COMBO_VISTIPOID_Multiplevaluestype");
               Combo_vistipoid_Loadingdata = cgiGet( "COMBO_VISTIPOID_Loadingdata");
               Combo_vistipoid_Noresultsfound = cgiGet( "COMBO_VISTIPOID_Noresultsfound");
               Combo_vistipoid_Emptyitemtext = cgiGet( "COMBO_VISTIPOID_Emptyitemtext");
               Combo_vistipoid_Onlyselectedvalues = cgiGet( "COMBO_VISTIPOID_Onlyselectedvalues");
               Combo_vistipoid_Selectalltext = cgiGet( "COMBO_VISTIPOID_Selectalltext");
               Combo_vistipoid_Multiplevaluesseparator = cgiGet( "COMBO_VISTIPOID_Multiplevaluesseparator");
               Combo_vistipoid_Addnewoptiontext = cgiGet( "COMBO_VISTIPOID_Addnewoptiontext");
               Combo_vistipoid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_VISTIPOID_Gxcontroltype"), ",", "."), 18, MidpointRounding.ToEven));
               Visdescricao_Objectcall = cgiGet( "VISDESCRICAO_Objectcall");
               Visdescricao_Class = cgiGet( "VISDESCRICAO_Class");
               Visdescricao_Enabled = StringUtil.StrToBool( cgiGet( "VISDESCRICAO_Enabled"));
               Visdescricao_Width = cgiGet( "VISDESCRICAO_Width");
               Visdescricao_Height = cgiGet( "VISDESCRICAO_Height");
               Visdescricao_Skin = cgiGet( "VISDESCRICAO_Skin");
               Visdescricao_Toolbar = cgiGet( "VISDESCRICAO_Toolbar");
               Visdescricao_Customtoolbar = cgiGet( "VISDESCRICAO_Customtoolbar");
               Visdescricao_Customconfiguration = cgiGet( "VISDESCRICAO_Customconfiguration");
               Visdescricao_Toolbarcancollapse = StringUtil.StrToBool( cgiGet( "VISDESCRICAO_Toolbarcancollapse"));
               Visdescricao_Toolbarexpanded = StringUtil.StrToBool( cgiGet( "VISDESCRICAO_Toolbarexpanded"));
               Visdescricao_Color = (int)(Math.Round(context.localUtil.CToN( cgiGet( "VISDESCRICAO_Color"), ",", "."), 18, MidpointRounding.ToEven));
               Visdescricao_Buttonpressedid = cgiGet( "VISDESCRICAO_Buttonpressedid");
               Visdescricao_Captionvalue = cgiGet( "VISDESCRICAO_Captionvalue");
               Visdescricao_Captionclass = cgiGet( "VISDESCRICAO_Captionclass");
               Visdescricao_Captionstyle = cgiGet( "VISDESCRICAO_Captionstyle");
               Visdescricao_Captionposition = cgiGet( "VISDESCRICAO_Captionposition");
               Visdescricao_Isabstractlayoutcontrol = StringUtil.StrToBool( cgiGet( "VISDESCRICAO_Isabstractlayoutcontrol"));
               Visdescricao_Coltitle = cgiGet( "VISDESCRICAO_Coltitle");
               Visdescricao_Coltitlefont = cgiGet( "VISDESCRICAO_Coltitlefont");
               Visdescricao_Coltitlecolor = (int)(Math.Round(context.localUtil.CToN( cgiGet( "VISDESCRICAO_Coltitlecolor"), ",", "."), 18, MidpointRounding.ToEven));
               Visdescricao_Usercontroliscolumn = StringUtil.StrToBool( cgiGet( "VISDESCRICAO_Usercontroliscolumn"));
               Visdescricao_Visible = StringUtil.StrToBool( cgiGet( "VISDESCRICAO_Visible"));
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
               A466VisNegCodigo = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtVisNegCodigo_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A466VisNegCodigo", StringUtil.LTrimStr( (decimal)(A466VisNegCodigo), 12, 0));
               A467VisNegAssunto = StringUtil.Upper( cgiGet( edtVisNegAssunto_Internalname));
               AssignAttri("", false, "A467VisNegAssunto", A467VisNegAssunto);
               A469VisNegCliNomeFamiliar = StringUtil.Upper( cgiGet( edtVisNegCliNomeFamiliar_Internalname));
               AssignAttri("", false, "A469VisNegCliNomeFamiliar", A469VisNegCliNomeFamiliar);
               A470VisNegCpjNomFan = StringUtil.Upper( cgiGet( edtVisNegCpjNomFan_Internalname));
               AssignAttri("", false, "A470VisNegCpjNomFan", A470VisNegCpjNomFan);
               A468VisNegValor = context.localUtil.CToN( cgiGet( edtVisNegValor_Internalname), ",", ".");
               AssignAttri("", false, "A468VisNegValor", StringUtil.LTrimStr( A468VisNegValor, 16, 2));
               A424VisNgfIteNome = StringUtil.Upper( cgiGet( edtVisNgfIteNome_Internalname));
               AssignAttri("", false, "A424VisNgfIteNome", A424VisNgfIteNome);
               A465VisPaiAssunto = cgiGet( edtVisPaiAssunto_Internalname);
               AssignAttri("", false, "A465VisPaiAssunto", A465VisPaiAssunto);
               A462VisPaiDataHora = context.localUtil.CToT( cgiGet( edtVisPaiDataHora_Internalname));
               AssignAttri("", false, "A462VisPaiDataHora", context.localUtil.TToC( A462VisPaiDataHora, 10, 5, 0, 3, "/", ":", " "));
               if ( ( ( context.localUtil.CToN( cgiGet( edtVisTipoID_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtVisTipoID_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "VISTIPOID");
                  AnyError = 1;
                  GX_FocusControl = edtVisTipoID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A414VisTipoID = 0;
                  AssignAttri("", false, "A414VisTipoID", StringUtil.LTrimStr( (decimal)(A414VisTipoID), 9, 0));
               }
               else
               {
                  A414VisTipoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtVisTipoID_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A414VisTipoID", StringUtil.LTrimStr( (decimal)(A414VisTipoID), 9, 0));
               }
               if ( context.localUtil.VCDate( cgiGet( edtVisData_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Data"}), 1, "VISDATA");
                  AnyError = 1;
                  GX_FocusControl = edtVisData_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A404VisData = DateTime.MinValue;
                  AssignAttri("", false, "A404VisData", context.localUtil.Format(A404VisData, "99/99/99"));
               }
               else
               {
                  A404VisData = context.localUtil.CToD( cgiGet( edtVisData_Internalname), 2);
                  AssignAttri("", false, "A404VisData", context.localUtil.Format(A404VisData, "99/99/99"));
               }
               if ( context.localUtil.VCDate( cgiGet( edtVisHora_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badtime", new   object[]  {"Hora"}), 1, "VISHORA");
                  AnyError = 1;
                  GX_FocusControl = edtVisHora_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A405VisHora = (DateTime)(DateTime.MinValue);
                  AssignAttri("", false, "A405VisHora", context.localUtil.TToC( A405VisHora, 0, 5, 0, 3, "/", ":", " "));
               }
               else
               {
                  A405VisHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtVisHora_Internalname)));
                  AssignAttri("", false, "A405VisHora", context.localUtil.TToC( A405VisHora, 0, 5, 0, 3, "/", ":", " "));
               }
               if ( context.localUtil.VCDate( cgiGet( edtVisDataFim_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Data"}), 1, "VISDATAFIM");
                  AnyError = 1;
                  GX_FocusControl = edtVisDataFim_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A475VisDataFim = DateTime.MinValue;
                  n475VisDataFim = false;
                  AssignAttri("", false, "A475VisDataFim", context.localUtil.Format(A475VisDataFim, "99/99/99"));
               }
               else
               {
                  A475VisDataFim = context.localUtil.CToD( cgiGet( edtVisDataFim_Internalname), 2);
                  n475VisDataFim = false;
                  AssignAttri("", false, "A475VisDataFim", context.localUtil.Format(A475VisDataFim, "99/99/99"));
               }
               n475VisDataFim = ((DateTime.MinValue==A475VisDataFim) ? true : false);
               if ( context.localUtil.VCDate( cgiGet( edtVisHoraFim_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badtime", new   object[]  {"Hora"}), 1, "VISHORAFIM");
                  AnyError = 1;
                  GX_FocusControl = edtVisHoraFim_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A476VisHoraFim = (DateTime)(DateTime.MinValue);
                  n476VisHoraFim = false;
                  AssignAttri("", false, "A476VisHoraFim", context.localUtil.TToC( A476VisHoraFim, 0, 5, 0, 3, "/", ":", " "));
               }
               else
               {
                  A476VisHoraFim = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtVisHoraFim_Internalname)));
                  n476VisHoraFim = false;
                  AssignAttri("", false, "A476VisHoraFim", context.localUtil.TToC( A476VisHoraFim, 0, 5, 0, 3, "/", ":", " "));
               }
               n476VisHoraFim = ((DateTime.MinValue==A476VisHoraFim) ? true : false);
               A409VisAssunto = cgiGet( edtVisAssunto_Internalname);
               AssignAttri("", false, "A409VisAssunto", A409VisAssunto);
               cmbVisSituacao.CurrentValue = cgiGet( cmbVisSituacao_Internalname);
               A472VisSituacao = cgiGet( cmbVisSituacao_Internalname);
               AssignAttri("", false, "A472VisSituacao", A472VisSituacao);
               A417VisLink = cgiGet( edtVisLink_Internalname);
               n417VisLink = false;
               AssignAttri("", false, "A417VisLink", A417VisLink);
               n417VisLink = (String.IsNullOrEmpty(StringUtil.RTrim( A417VisLink)) ? true : false);
               AV27ComboVisTipoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavCombovistipoid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV27ComboVisTipoID", StringUtil.LTrimStr( (decimal)(AV27ComboVisTipoID), 9, 0));
               AV40VisPaiID = StringUtil.StrToGuid( cgiGet( edtavVispaiid_Internalname));
               AssignAttri("", false, "AV40VisPaiID", AV40VisPaiID.ToString());
               GxWebStd.gx_hidden_field( context, "gxhash_vVISPAIID", GetSecureSignedToken( "", AV40VisPaiID, context));
               AV41VisNegID = StringUtil.StrToGuid( cgiGet( edtavVisnegid_Internalname));
               AV42VisNgfSeq = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavVisngfseq_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               if ( context.localUtil.VCDateTime( cgiGet( edtVisDataHoraFim_Internalname), 2, 0) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Data/Hora"}), 1, "VISDATAHORAFIM");
                  AnyError = 1;
                  GX_FocusControl = edtVisDataHoraFim_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A477VisDataHoraFim = (DateTime)(DateTime.MinValue);
                  n477VisDataHoraFim = false;
                  AssignAttri("", false, "A477VisDataHoraFim", context.localUtil.TToC( A477VisDataHoraFim, 10, 5, 0, 3, "/", ":", " "));
               }
               else
               {
                  A477VisDataHoraFim = context.localUtil.CToT( cgiGet( edtVisDataHoraFim_Internalname));
                  n477VisDataHoraFim = false;
                  AssignAttri("", false, "A477VisDataHoraFim", context.localUtil.TToC( A477VisDataHoraFim, 10, 5, 0, 3, "/", ":", " "));
               }
               n477VisDataHoraFim = ((DateTime.MinValue==A477VisDataHoraFim) ? true : false);
               if ( context.localUtil.VCDateTime( cgiGet( edtVisDataHora_Internalname), 2, 0) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Data/Hora"}), 1, "VISDATAHORA");
                  AnyError = 1;
                  GX_FocusControl = edtVisDataHora_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A406VisDataHora = (DateTime)(DateTime.MinValue);
                  AssignAttri("", false, "A406VisDataHora", context.localUtil.TToC( A406VisDataHora, 10, 5, 0, 3, "/", ":", " "));
               }
               else
               {
                  A406VisDataHora = context.localUtil.CToT( cgiGet( edtVisDataHora_Internalname));
                  AssignAttri("", false, "A406VisDataHora", context.localUtil.TToC( A406VisDataHora, 10, 5, 0, 3, "/", ":", " "));
               }
               if ( StringUtil.StrCmp(cgiGet( edtVisPaiID_Internalname), "") == 0 )
               {
                  A419VisPaiID = Guid.Empty;
                  n419VisPaiID = false;
                  AssignAttri("", false, "A419VisPaiID", A419VisPaiID.ToString());
               }
               else
               {
                  try
                  {
                     A419VisPaiID = StringUtil.StrToGuid( cgiGet( edtVisPaiID_Internalname));
                     n419VisPaiID = false;
                     AssignAttri("", false, "A419VisPaiID", A419VisPaiID.ToString());
                  }
                  catch ( Exception  )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "VISPAIID");
                     AnyError = 1;
                     GX_FocusControl = edtVisPaiID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     wbErr = true;
                  }
               }
               n419VisPaiID = ((Guid.Empty==A419VisPaiID) ? true : false);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Visita");
               A472VisSituacao = cgiGet( cmbVisSituacao_Internalname);
               AssignAttri("", false, "A472VisSituacao", A472VisSituacao);
               forbiddenHiddens.Add("VisSituacao", StringUtil.RTrim( context.localUtil.Format( A472VisSituacao, "")));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("Pgmname", StringUtil.RTrim( context.localUtil.Format( AV46Pgmname, "")));
               forbiddenHiddens.Add("VisUpdData", context.localUtil.Format(A482VisUpdData, "99/99/99"));
               forbiddenHiddens.Add("VisUpdHora", context.localUtil.Format( A483VisUpdHora, "99:99"));
               forbiddenHiddens.Add("VisUpdDataHora", context.localUtil.Format( A484VisUpdDataHora, "99/99/9999 99:99:99.999"));
               forbiddenHiddens.Add("VisUpdUsuID", StringUtil.RTrim( context.localUtil.Format( A485VisUpdUsuID, "")));
               forbiddenHiddens.Add("VisUpdUsuNome", StringUtil.RTrim( context.localUtil.Format( A486VisUpdUsuNome, "@!")));
               forbiddenHiddens.Add("VisDel", StringUtil.BoolToStr( A487VisDel));
               hsh = cgiGet( "hsh");
               if ( ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("core\\visita:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A398VisID = StringUtil.StrToGuid( GetPar( "VisID"));
                  AssignAttri("", false, "A398VisID", A398VisID.ToString());
                  getEqualNoModal( ) ;
                  if ( ! (Guid.Empty==AV7VisID) )
                  {
                     A398VisID = AV7VisID;
                     AssignAttri("", false, "A398VisID", A398VisID.ToString());
                  }
                  else
                  {
                     if ( IsIns( )  && (Guid.Empty==A398VisID) && ( Gx_BScreen == 0 ) )
                     {
                        A398VisID = Guid.NewGuid( );
                        AssignAttri("", false, "A398VisID", A398VisID.ToString());
                     }
                  }
                  /* N/A Action t   40 */
                  /* Using cursor T00145 */
                  pr_default.execute(3, new Object[] {n418VisNegID, A418VisNegID});
                  pr_default.close(3);
                  /* Using cursor T00148 */
                  pr_default.execute(6, new Object[] {A407VisNegCliID});
                  pr_default.close(6);
                  /* Using cursor T00149 */
                  pr_default.execute(7, new Object[] {A407VisNegCliID, A408VisNegCpjID});
                  pr_default.close(7);
                  /* Using cursor T00146 */
                  pr_default.execute(4, new Object[] {n418VisNegID, A418VisNegID, n422VisNgfSeq, A422VisNgfSeq});
                  pr_default.close(4);
                  /* Using cursor T001410 */
                  pr_default.execute(8, new Object[] {A423VisNgfIteID});
                  pr_default.close(8);
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  disable_std_buttons( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  if ( IsDsp( ) )
                  {
                     sMode40 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     if ( ! (Guid.Empty==AV7VisID) )
                     {
                        A398VisID = AV7VisID;
                        AssignAttri("", false, "A398VisID", A398VisID.ToString());
                     }
                     else
                     {
                        if ( IsIns( )  && (Guid.Empty==A398VisID) && ( Gx_BScreen == 0 ) )
                        {
                           A398VisID = Guid.NewGuid( );
                           AssignAttri("", false, "A398VisID", A398VisID.ToString());
                        }
                     }
                     /* N/A Action t   40 */
                     /* Using cursor T00145 */
                     pr_default.execute(3, new Object[] {n418VisNegID, A418VisNegID});
                     pr_default.close(3);
                     /* Using cursor T00148 */
                     pr_default.execute(6, new Object[] {A407VisNegCliID});
                     pr_default.close(6);
                     /* Using cursor T00149 */
                     pr_default.execute(7, new Object[] {A407VisNegCliID, A408VisNegCpjID});
                     pr_default.close(7);
                     /* Using cursor T00146 */
                     pr_default.execute(4, new Object[] {n418VisNegID, A418VisNegID, n422VisNgfSeq, A422VisNgfSeq});
                     pr_default.close(4);
                     /* Using cursor T001410 */
                     pr_default.execute(8, new Object[] {A423VisNgfIteID});
                     pr_default.close(8);
                     Gx_mode = sMode40;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound40 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_140( ) ;
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
                        if ( StringUtil.StrCmp(sEvt, "COMBO_VISTIPOID.ONOPTIONCLICKED") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           E12142 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E11142 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E13142 ();
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
            E13142 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll1440( ) ;
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
            DisableAttributes1440( ) ;
         }
         AssignProp("", false, edtavCombovistipoid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombovistipoid_Enabled), 5, 0), true);
         AssignProp("", false, edtavVispaiid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavVispaiid_Enabled), 5, 0), true);
         AssignProp("", false, edtavVisnegid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavVisnegid_Enabled), 5, 0), true);
         AssignProp("", false, edtavVisngfseq_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavVisngfseq_Enabled), 5, 0), true);
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

      protected void CONFIRM_140( )
      {
         BeforeValidate1440( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1440( ) ;
            }
            else
            {
               CheckExtendedTable1440( ) ;
               CloseExtendedTableCursors1440( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption140( )
      {
      }

      protected void E11142( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         edtVisTipoID_Visible = 0;
         AssignProp("", false, edtVisTipoID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtVisTipoID_Visible), 5, 0), true);
         AV27ComboVisTipoID = 0;
         AssignAttri("", false, "AV27ComboVisTipoID", StringUtil.LTrimStr( (decimal)(AV27ComboVisTipoID), 9, 0));
         edtavCombovistipoid_Visible = 0;
         AssignProp("", false, edtavCombovistipoid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombovistipoid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOVISTIPOID' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV46Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV47GXV1 = 1;
            AssignAttri("", false, "AV47GXV1", StringUtil.LTrimStr( (decimal)(AV47GXV1), 8, 0));
            while ( AV47GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV17TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV47GXV1));
               if ( StringUtil.StrCmp(AV17TrnContextAtt.gxTpr_Attributename, "VisPaiID") == 0 )
               {
                  AV13Insert_VisPaiID = StringUtil.StrToGuid( AV17TrnContextAtt.gxTpr_Attributevalue);
                  AssignAttri("", false, "AV13Insert_VisPaiID", AV13Insert_VisPaiID.ToString());
               }
               else if ( StringUtil.StrCmp(AV17TrnContextAtt.gxTpr_Attributename, "VisTipoID") == 0 )
               {
                  AV14Insert_VisTipoID = (int)(Math.Round(NumberUtil.Val( AV17TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV14Insert_VisTipoID", StringUtil.LTrimStr( (decimal)(AV14Insert_VisTipoID), 9, 0));
                  if ( ! (0==AV14Insert_VisTipoID) )
                  {
                     AV27ComboVisTipoID = AV14Insert_VisTipoID;
                     AssignAttri("", false, "AV27ComboVisTipoID", StringUtil.LTrimStr( (decimal)(AV27ComboVisTipoID), 9, 0));
                     Combo_vistipoid_Selectedvalue_set = StringUtil.Trim( StringUtil.Str( (decimal)(AV27ComboVisTipoID), 9, 0));
                     ucCombo_vistipoid.SendProperty(context, "", false, Combo_vistipoid_Internalname, "SelectedValue_set", Combo_vistipoid_Selectedvalue_set);
                     Combo_vistipoid_Enabled = false;
                     ucCombo_vistipoid.SendProperty(context, "", false, Combo_vistipoid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_vistipoid_Enabled));
                  }
               }
               else if ( StringUtil.StrCmp(AV17TrnContextAtt.gxTpr_Attributename, "VisNegID") == 0 )
               {
                  AV15Insert_VisNegID = StringUtil.StrToGuid( AV17TrnContextAtt.gxTpr_Attributevalue);
                  AssignAttri("", false, "AV15Insert_VisNegID", AV15Insert_VisNegID.ToString());
               }
               else if ( StringUtil.StrCmp(AV17TrnContextAtt.gxTpr_Attributename, "VisNgfSeq") == 0 )
               {
                  AV16Insert_VisNgfSeq = (int)(Math.Round(NumberUtil.Val( AV17TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV16Insert_VisNgfSeq", StringUtil.LTrimStr( (decimal)(AV16Insert_VisNgfSeq), 8, 0));
               }
               AV47GXV1 = (int)(AV47GXV1+1);
               AssignAttri("", false, "AV47GXV1", StringUtil.LTrimStr( (decimal)(AV47GXV1), 8, 0));
            }
         }
         edtavVispaiid_Visible = 0;
         AssignProp("", false, edtavVispaiid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavVispaiid_Visible), 5, 0), true);
         edtavVisnegid_Visible = 0;
         AssignProp("", false, edtavVisnegid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavVisnegid_Visible), 5, 0), true);
         edtavVisngfseq_Visible = 0;
         AssignProp("", false, edtavVisngfseq_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavVisngfseq_Visible), 5, 0), true);
         edtVisDataHoraFim_Visible = 0;
         AssignProp("", false, edtVisDataHoraFim_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtVisDataHoraFim_Visible), 5, 0), true);
         edtVisDataHora_Visible = 0;
         AssignProp("", false, edtVisDataHora_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtVisDataHora_Visible), 5, 0), true);
         edtVisPaiID_Visible = 0;
         AssignProp("", false, edtVisPaiID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtVisPaiID_Visible), 5, 0), true);
      }

      protected void E13142( )
      {
         /* After Trn Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.audittransaction(context ).execute(  AV43AuditingObject,  AV46Pgmname) ;
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void S122( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         grpTablegroupvisitaorigem_Class = "Invisible";
         AssignProp("", false, grpTablegroupvisitaorigem_Internalname, "Class", grpTablegroupvisitaorigem_Class, true);
      }

      protected void E12142( )
      {
         /* Combo_vistipoid_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Combo_vistipoid_Selectedvalue_get, "<#NEW#>") == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "core.visitatipo.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0));
            context.PopUp(formatLink("core.visitatipo.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
         }
         else if ( StringUtil.StrCmp(Combo_vistipoid_Selectedvalue_get, "<#POPUP_CLOSED#>") == 0 )
         {
            GXt_objcol_SdtDVB_SDTComboData_Item1 = AV26VisTipoID_Data;
            new GeneXus.Programs.core.visitaloaddvcombo(context ).execute(  "VisTipoID",  "NEW",  AV7VisID, out  AV20ComboSelectedValue, out  GXt_objcol_SdtDVB_SDTComboData_Item1) ;
            AV26VisTipoID_Data = GXt_objcol_SdtDVB_SDTComboData_Item1;
            AV20ComboSelectedValue = AV12WebSession.Get("VITID");
            AV12WebSession.Remove("VITID");
            Combo_vistipoid_Selectedvalue_set = AV20ComboSelectedValue;
            ucCombo_vistipoid.SendProperty(context, "", false, Combo_vistipoid_Internalname, "SelectedValue_set", Combo_vistipoid_Selectedvalue_set);
            AV27ComboVisTipoID = (int)(Math.Round(NumberUtil.Val( AV20ComboSelectedValue, "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV27ComboVisTipoID", StringUtil.LTrimStr( (decimal)(AV27ComboVisTipoID), 9, 0));
         }
         else
         {
            AV27ComboVisTipoID = (int)(Math.Round(NumberUtil.Val( Combo_vistipoid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV27ComboVisTipoID", StringUtil.LTrimStr( (decimal)(AV27ComboVisTipoID), 9, 0));
            GXt_objcol_SdtDVB_SDTComboData_Item1 = AV26VisTipoID_Data;
            new GeneXus.Programs.core.visitaloaddvcombo(context ).execute(  "VisTipoID",  "NEW",  AV7VisID, out  AV20ComboSelectedValue, out  GXt_objcol_SdtDVB_SDTComboData_Item1) ;
            AV26VisTipoID_Data = GXt_objcol_SdtDVB_SDTComboData_Item1;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV26VisTipoID_Data", AV26VisTipoID_Data);
      }

      protected void S112( )
      {
         /* 'LOADCOMBOVISTIPOID' Routine */
         returnInSub = false;
         GXt_boolean2 = false;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "visitatipo_Insert", out  GXt_boolean2) ;
         Combo_vistipoid_Includeaddnewoption = GXt_boolean2;
         ucCombo_vistipoid.SendProperty(context, "", false, Combo_vistipoid_Internalname, "IncludeAddNewOption", StringUtil.BoolToStr( Combo_vistipoid_Includeaddnewoption));
         GXt_objcol_SdtDVB_SDTComboData_Item1 = AV26VisTipoID_Data;
         new GeneXus.Programs.core.visitaloaddvcombo(context ).execute(  "VisTipoID",  Gx_mode,  AV7VisID, out  AV20ComboSelectedValue, out  GXt_objcol_SdtDVB_SDTComboData_Item1) ;
         AV26VisTipoID_Data = GXt_objcol_SdtDVB_SDTComboData_Item1;
         Combo_vistipoid_Selectedvalue_set = AV20ComboSelectedValue;
         ucCombo_vistipoid.SendProperty(context, "", false, Combo_vistipoid_Internalname, "SelectedValue_set", Combo_vistipoid_Selectedvalue_set);
         AV27ComboVisTipoID = (int)(Math.Round(NumberUtil.Val( AV20ComboSelectedValue, "."), 18, MidpointRounding.ToEven));
         AssignAttri("", false, "AV27ComboVisTipoID", StringUtil.LTrimStr( (decimal)(AV27ComboVisTipoID), 9, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_vistipoid_Enabled = false;
            ucCombo_vistipoid.SendProperty(context, "", false, Combo_vistipoid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_vistipoid_Enabled));
         }
      }

      protected void ZM1440( short GX_JID )
      {
         if ( ( GX_JID == 53 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z401VisInsDataHora = T00143_A401VisInsDataHora[0];
               Z399VisInsData = T00143_A399VisInsData[0];
               Z400VisInsHora = T00143_A400VisInsHora[0];
               Z402VisInsUsuID = T00143_A402VisInsUsuID[0];
               Z403VisInsUsuNome = T00143_A403VisInsUsuNome[0];
               Z490VisDelDataHora = T00143_A490VisDelDataHora[0];
               Z488VisDelData = T00143_A488VisDelData[0];
               Z489VisDelHora = T00143_A489VisDelHora[0];
               Z491VisDelUsuID = T00143_A491VisDelUsuID[0];
               Z492VisDelUsuNome = T00143_A492VisDelUsuNome[0];
               Z482VisUpdData = T00143_A482VisUpdData[0];
               Z483VisUpdHora = T00143_A483VisUpdHora[0];
               Z484VisUpdDataHora = T00143_A484VisUpdDataHora[0];
               Z485VisUpdUsuID = T00143_A485VisUpdUsuID[0];
               Z486VisUpdUsuNome = T00143_A486VisUpdUsuNome[0];
               Z404VisData = T00143_A404VisData[0];
               Z405VisHora = T00143_A405VisHora[0];
               Z406VisDataHora = T00143_A406VisDataHora[0];
               Z475VisDataFim = T00143_A475VisDataFim[0];
               Z476VisHoraFim = T00143_A476VisHoraFim[0];
               Z477VisDataHoraFim = T00143_A477VisDataHoraFim[0];
               Z409VisAssunto = T00143_A409VisAssunto[0];
               Z417VisLink = T00143_A417VisLink[0];
               Z472VisSituacao = T00143_A472VisSituacao[0];
               Z487VisDel = T00143_A487VisDel[0];
               Z414VisTipoID = T00143_A414VisTipoID[0];
               Z419VisPaiID = T00143_A419VisPaiID[0];
            }
            else
            {
               Z401VisInsDataHora = A401VisInsDataHora;
               Z399VisInsData = A399VisInsData;
               Z400VisInsHora = A400VisInsHora;
               Z402VisInsUsuID = A402VisInsUsuID;
               Z403VisInsUsuNome = A403VisInsUsuNome;
               Z490VisDelDataHora = A490VisDelDataHora;
               Z488VisDelData = A488VisDelData;
               Z489VisDelHora = A489VisDelHora;
               Z491VisDelUsuID = A491VisDelUsuID;
               Z492VisDelUsuNome = A492VisDelUsuNome;
               Z482VisUpdData = A482VisUpdData;
               Z483VisUpdHora = A483VisUpdHora;
               Z484VisUpdDataHora = A484VisUpdDataHora;
               Z485VisUpdUsuID = A485VisUpdUsuID;
               Z486VisUpdUsuNome = A486VisUpdUsuNome;
               Z404VisData = A404VisData;
               Z405VisHora = A405VisHora;
               Z406VisDataHora = A406VisDataHora;
               Z475VisDataFim = A475VisDataFim;
               Z476VisHoraFim = A476VisHoraFim;
               Z477VisDataHoraFim = A477VisDataHoraFim;
               Z409VisAssunto = A409VisAssunto;
               Z417VisLink = A417VisLink;
               Z472VisSituacao = A472VisSituacao;
               Z487VisDel = A487VisDel;
               Z414VisTipoID = A414VisTipoID;
               Z419VisPaiID = A419VisPaiID;
            }
         }
         if ( GX_JID == -53 )
         {
            Z418VisNegID = A418VisNegID;
            Z422VisNgfSeq = A422VisNgfSeq;
            Z398VisID = A398VisID;
            Z401VisInsDataHora = A401VisInsDataHora;
            Z399VisInsData = A399VisInsData;
            Z400VisInsHora = A400VisInsHora;
            Z402VisInsUsuID = A402VisInsUsuID;
            Z403VisInsUsuNome = A403VisInsUsuNome;
            Z490VisDelDataHora = A490VisDelDataHora;
            Z488VisDelData = A488VisDelData;
            Z489VisDelHora = A489VisDelHora;
            Z491VisDelUsuID = A491VisDelUsuID;
            Z492VisDelUsuNome = A492VisDelUsuNome;
            Z482VisUpdData = A482VisUpdData;
            Z483VisUpdHora = A483VisUpdHora;
            Z484VisUpdDataHora = A484VisUpdDataHora;
            Z485VisUpdUsuID = A485VisUpdUsuID;
            Z486VisUpdUsuNome = A486VisUpdUsuNome;
            Z404VisData = A404VisData;
            Z405VisHora = A405VisHora;
            Z406VisDataHora = A406VisDataHora;
            Z475VisDataFim = A475VisDataFim;
            Z476VisHoraFim = A476VisHoraFim;
            Z477VisDataHoraFim = A477VisDataHoraFim;
            Z409VisAssunto = A409VisAssunto;
            Z410VisDescricao = A410VisDescricao;
            Z417VisLink = A417VisLink;
            Z472VisSituacao = A472VisSituacao;
            Z487VisDel = A487VisDel;
            Z414VisTipoID = A414VisTipoID;
            Z419VisPaiID = A419VisPaiID;
            Z466VisNegCodigo = A466VisNegCodigo;
            Z467VisNegAssunto = A467VisNegAssunto;
            Z468VisNegValor = A468VisNegValor;
            Z407VisNegCliID = A407VisNegCliID;
            Z408VisNegCpjID = A408VisNegCpjID;
            Z469VisNegCliNomeFamiliar = A469VisNegCliNomeFamiliar;
            Z470VisNegCpjNomFan = A470VisNegCpjNomFan;
            Z471VisNegCpjRazSocial = A471VisNegCpjRazSocial;
            Z423VisNgfIteID = A423VisNgfIteID;
            Z424VisNgfIteNome = A424VisNgfIteNome;
            Z460VisPaiData = A460VisPaiData;
            Z461VisPaiHora = A461VisPaiHora;
            Z462VisPaiDataHora = A462VisPaiDataHora;
            Z465VisPaiAssunto = A465VisPaiAssunto;
            Z415VisTipoSigla = A415VisTipoSigla;
            Z416VisTipoNome = A416VisTipoNome;
         }
      }

      protected void standaloneNotModal( )
      {
         edtVisNegCodigo_Enabled = 0;
         AssignProp("", false, edtVisNegCodigo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVisNegCodigo_Enabled), 5, 0), true);
         edtVisNegAssunto_Enabled = 0;
         AssignProp("", false, edtVisNegAssunto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVisNegAssunto_Enabled), 5, 0), true);
         edtVisNegCliNomeFamiliar_Enabled = 0;
         AssignProp("", false, edtVisNegCliNomeFamiliar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVisNegCliNomeFamiliar_Enabled), 5, 0), true);
         edtVisNegCpjNomFan_Enabled = 0;
         AssignProp("", false, edtVisNegCpjNomFan_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVisNegCpjNomFan_Enabled), 5, 0), true);
         edtVisNgfIteNome_Enabled = 0;
         AssignProp("", false, edtVisNgfIteNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVisNgfIteNome_Enabled), 5, 0), true);
         cmbVisSituacao.Enabled = 0;
         AssignProp("", false, cmbVisSituacao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbVisSituacao.Enabled), 5, 0), true);
         edtVisPaiAssunto_Enabled = 0;
         AssignProp("", false, edtVisPaiAssunto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVisPaiAssunto_Enabled), 5, 0), true);
         AV46Pgmname = "core.Visita";
         AssignAttri("", false, "AV46Pgmname", AV46Pgmname);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         edtVisNegCodigo_Enabled = 0;
         AssignProp("", false, edtVisNegCodigo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVisNegCodigo_Enabled), 5, 0), true);
         edtVisNegAssunto_Enabled = 0;
         AssignProp("", false, edtVisNegAssunto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVisNegAssunto_Enabled), 5, 0), true);
         edtVisNegCliNomeFamiliar_Enabled = 0;
         AssignProp("", false, edtVisNegCliNomeFamiliar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVisNegCliNomeFamiliar_Enabled), 5, 0), true);
         edtVisNegCpjNomFan_Enabled = 0;
         AssignProp("", false, edtVisNegCpjNomFan_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVisNegCpjNomFan_Enabled), 5, 0), true);
         edtVisNgfIteNome_Enabled = 0;
         AssignProp("", false, edtVisNgfIteNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVisNgfIteNome_Enabled), 5, 0), true);
         cmbVisSituacao.Enabled = 0;
         AssignProp("", false, cmbVisSituacao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbVisSituacao.Enabled), 5, 0), true);
         edtVisPaiAssunto_Enabled = 0;
         AssignProp("", false, edtVisPaiAssunto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVisPaiAssunto_Enabled), 5, 0), true);
         if ( ! ( ! (Guid.Empty==AV40VisPaiID) ) )
         {
            grpTablegroupvisitaorigem_Class = "Invisible";
            AssignProp("", false, grpTablegroupvisitaorigem_Internalname, "Class", grpTablegroupvisitaorigem_Class, true);
         }
         else
         {
            if ( ! (Guid.Empty==AV40VisPaiID) )
            {
               grpTablegroupvisitaorigem_Class = "Group";
               AssignProp("", false, grpTablegroupvisitaorigem_Internalname, "Class", grpTablegroupvisitaorigem_Class, true);
            }
         }
         /* Using cursor T00145 */
         pr_default.execute(3, new Object[] {n418VisNegID, A418VisNegID});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (Guid.Empty==A418VisNegID) ) )
            {
               GX_msglist.addItem("Não existe 'Negociação da Visita'.", "ForeignKeyNotFound", 1, "VISNEGID");
               AnyError = 1;
            }
         }
         A466VisNegCodigo = T00145_A466VisNegCodigo[0];
         AssignAttri("", false, "A466VisNegCodigo", StringUtil.LTrimStr( (decimal)(A466VisNegCodigo), 12, 0));
         A467VisNegAssunto = T00145_A467VisNegAssunto[0];
         AssignAttri("", false, "A467VisNegAssunto", A467VisNegAssunto);
         A468VisNegValor = T00145_A468VisNegValor[0];
         AssignAttri("", false, "A468VisNegValor", StringUtil.LTrimStr( A468VisNegValor, 16, 2));
         A407VisNegCliID = T00145_A407VisNegCliID[0];
         A408VisNegCpjID = T00145_A408VisNegCpjID[0];
         pr_default.close(3);
         /* Using cursor T00148 */
         pr_default.execute(6, new Object[] {A407VisNegCliID});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( (Guid.Empty==A407VisNegCliID) ) )
            {
               GX_msglist.addItem("Não existe ''.", "ForeignKeyNotFound", 1, "VISNEGCLIID");
               AnyError = 1;
            }
         }
         A469VisNegCliNomeFamiliar = T00148_A469VisNegCliNomeFamiliar[0];
         AssignAttri("", false, "A469VisNegCliNomeFamiliar", A469VisNegCliNomeFamiliar);
         pr_default.close(6);
         /* Using cursor T00149 */
         pr_default.execute(7, new Object[] {A407VisNegCliID, A408VisNegCpjID});
         if ( (pr_default.getStatus(7) == 101) )
         {
            if ( ! ( (Guid.Empty==A407VisNegCliID) || (Guid.Empty==A408VisNegCpjID) ) )
            {
               GX_msglist.addItem("Não existe ''.", "ForeignKeyNotFound", 1, "VISNEGCPJID");
               AnyError = 1;
            }
         }
         A470VisNegCpjNomFan = T00149_A470VisNegCpjNomFan[0];
         AssignAttri("", false, "A470VisNegCpjNomFan", A470VisNegCpjNomFan);
         A471VisNegCpjRazSocial = T00149_A471VisNegCpjRazSocial[0];
         pr_default.close(7);
         /* Using cursor T00146 */
         pr_default.execute(4, new Object[] {n418VisNegID, A418VisNegID, n422VisNgfSeq, A422VisNgfSeq});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (Guid.Empty==A418VisNegID) || (0==A422VisNgfSeq) ) )
            {
               GX_msglist.addItem("Não existe 'Negociação da Visita'.", "ForeignKeyNotFound", 1, "VISNGFSEQ");
               AnyError = 1;
            }
         }
         A423VisNgfIteID = T00146_A423VisNgfIteID[0];
         pr_default.close(4);
         /* Using cursor T001410 */
         pr_default.execute(8, new Object[] {A423VisNgfIteID});
         if ( (pr_default.getStatus(8) == 101) )
         {
            if ( ! ( (Guid.Empty==A423VisNgfIteID) ) )
            {
               GX_msglist.addItem("Não existe ''.", "ForeignKeyNotFound", 1, "VISNGFITEID");
               AnyError = 1;
            }
         }
         A424VisNgfIteNome = T001410_A424VisNgfIteNome[0];
         AssignAttri("", false, "A424VisNgfIteNome", A424VisNgfIteNome);
         pr_default.close(8);
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV13Insert_VisPaiID) )
         {
            edtVisPaiID_Enabled = 0;
            AssignProp("", false, edtVisPaiID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVisPaiID_Enabled), 5, 0), true);
         }
         else
         {
            edtVisPaiID_Enabled = 1;
            AssignProp("", false, edtVisPaiID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVisPaiID_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV14Insert_VisTipoID) )
         {
            edtVisTipoID_Enabled = 0;
            AssignProp("", false, edtVisTipoID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVisTipoID_Enabled), 5, 0), true);
         }
         else
         {
            edtVisTipoID_Enabled = 1;
            AssignProp("", false, edtVisTipoID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVisTipoID_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV14Insert_VisTipoID) )
         {
            A414VisTipoID = AV14Insert_VisTipoID;
            AssignAttri("", false, "A414VisTipoID", StringUtil.LTrimStr( (decimal)(A414VisTipoID), 9, 0));
         }
         else
         {
            A414VisTipoID = AV27ComboVisTipoID;
            AssignAttri("", false, "A414VisTipoID", StringUtil.LTrimStr( (decimal)(A414VisTipoID), 9, 0));
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
         if ( ! (Guid.Empty==AV7VisID) )
         {
            A398VisID = AV7VisID;
            AssignAttri("", false, "A398VisID", A398VisID.ToString());
         }
         else
         {
            if ( IsIns( )  && (Guid.Empty==A398VisID) && ( Gx_BScreen == 0 ) )
            {
               A398VisID = Guid.NewGuid( );
               AssignAttri("", false, "A398VisID", A398VisID.ToString());
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV13Insert_VisPaiID) )
         {
            A419VisPaiID = AV13Insert_VisPaiID;
            n419VisPaiID = false;
            AssignAttri("", false, "A419VisPaiID", A419VisPaiID.ToString());
         }
         else
         {
            if ( IsIns( )  && (Guid.Empty==A419VisPaiID) && ( Gx_BScreen == 0 ) )
            {
               GXt_guid3 = A419VisPaiID;
               new GeneXus.Programs.core.prcretvispaiid(context ).execute(  AV40VisPaiID, out  GXt_guid3) ;
               A419VisPaiID = GXt_guid3;
               n419VisPaiID = false;
               AssignAttri("", false, "A419VisPaiID", A419VisPaiID.ToString());
            }
         }
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A472VisSituacao)) && ( Gx_BScreen == 0 ) )
         {
            A472VisSituacao = "PEN";
            AssignAttri("", false, "A472VisSituacao", A472VisSituacao);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T00144 */
            pr_default.execute(2, new Object[] {A414VisTipoID});
            A415VisTipoSigla = T00144_A415VisTipoSigla[0];
            A416VisTipoNome = T00144_A416VisTipoNome[0];
            pr_default.close(2);
            /* Using cursor T00147 */
            pr_default.execute(5, new Object[] {n419VisPaiID, A419VisPaiID});
            A460VisPaiData = T00147_A460VisPaiData[0];
            A461VisPaiHora = T00147_A461VisPaiHora[0];
            A462VisPaiDataHora = T00147_A462VisPaiDataHora[0];
            AssignAttri("", false, "A462VisPaiDataHora", context.localUtil.TToC( A462VisPaiDataHora, 10, 5, 0, 3, "/", ":", " "));
            A465VisPaiAssunto = T00147_A465VisPaiAssunto[0];
            AssignAttri("", false, "A465VisPaiAssunto", A465VisPaiAssunto);
            pr_default.close(5);
            if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV15Insert_VisNegID) )
            {
               A418VisNegID = AV15Insert_VisNegID;
               n418VisNegID = false;
               AssignAttri("", false, "A418VisNegID", A418VisNegID.ToString());
            }
            if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV16Insert_VisNgfSeq) )
            {
               A422VisNgfSeq = AV16Insert_VisNgfSeq;
               n422VisNgfSeq = false;
               AssignAttri("", false, "A422VisNgfSeq", StringUtil.LTrimStr( (decimal)(A422VisNgfSeq), 8, 0));
            }
         }
      }

      protected void Load1440( )
      {
         /* Using cursor T001411 */
         pr_default.execute(9, new Object[] {A398VisID, n418VisNegID, A418VisNegID, n422VisNgfSeq, A422VisNgfSeq});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound40 = 1;
            A401VisInsDataHora = T001411_A401VisInsDataHora[0];
            A399VisInsData = T001411_A399VisInsData[0];
            A400VisInsHora = T001411_A400VisInsHora[0];
            A402VisInsUsuID = T001411_A402VisInsUsuID[0];
            n402VisInsUsuID = T001411_n402VisInsUsuID[0];
            A403VisInsUsuNome = T001411_A403VisInsUsuNome[0];
            n403VisInsUsuNome = T001411_n403VisInsUsuNome[0];
            A490VisDelDataHora = T001411_A490VisDelDataHora[0];
            n490VisDelDataHora = T001411_n490VisDelDataHora[0];
            A488VisDelData = T001411_A488VisDelData[0];
            n488VisDelData = T001411_n488VisDelData[0];
            A489VisDelHora = T001411_A489VisDelHora[0];
            n489VisDelHora = T001411_n489VisDelHora[0];
            A491VisDelUsuID = T001411_A491VisDelUsuID[0];
            n491VisDelUsuID = T001411_n491VisDelUsuID[0];
            A492VisDelUsuNome = T001411_A492VisDelUsuNome[0];
            n492VisDelUsuNome = T001411_n492VisDelUsuNome[0];
            A460VisPaiData = T001411_A460VisPaiData[0];
            A461VisPaiHora = T001411_A461VisPaiHora[0];
            A462VisPaiDataHora = T001411_A462VisPaiDataHora[0];
            AssignAttri("", false, "A462VisPaiDataHora", context.localUtil.TToC( A462VisPaiDataHora, 10, 5, 0, 3, "/", ":", " "));
            A465VisPaiAssunto = T001411_A465VisPaiAssunto[0];
            AssignAttri("", false, "A465VisPaiAssunto", A465VisPaiAssunto);
            A482VisUpdData = T001411_A482VisUpdData[0];
            n482VisUpdData = T001411_n482VisUpdData[0];
            A483VisUpdHora = T001411_A483VisUpdHora[0];
            n483VisUpdHora = T001411_n483VisUpdHora[0];
            A484VisUpdDataHora = T001411_A484VisUpdDataHora[0];
            n484VisUpdDataHora = T001411_n484VisUpdDataHora[0];
            A485VisUpdUsuID = T001411_A485VisUpdUsuID[0];
            n485VisUpdUsuID = T001411_n485VisUpdUsuID[0];
            A486VisUpdUsuNome = T001411_A486VisUpdUsuNome[0];
            n486VisUpdUsuNome = T001411_n486VisUpdUsuNome[0];
            A404VisData = T001411_A404VisData[0];
            AssignAttri("", false, "A404VisData", context.localUtil.Format(A404VisData, "99/99/99"));
            A405VisHora = T001411_A405VisHora[0];
            AssignAttri("", false, "A405VisHora", context.localUtil.TToC( A405VisHora, 0, 5, 0, 3, "/", ":", " "));
            A406VisDataHora = T001411_A406VisDataHora[0];
            AssignAttri("", false, "A406VisDataHora", context.localUtil.TToC( A406VisDataHora, 10, 5, 0, 3, "/", ":", " "));
            A475VisDataFim = T001411_A475VisDataFim[0];
            n475VisDataFim = T001411_n475VisDataFim[0];
            AssignAttri("", false, "A475VisDataFim", context.localUtil.Format(A475VisDataFim, "99/99/99"));
            A476VisHoraFim = T001411_A476VisHoraFim[0];
            n476VisHoraFim = T001411_n476VisHoraFim[0];
            AssignAttri("", false, "A476VisHoraFim", context.localUtil.TToC( A476VisHoraFim, 0, 5, 0, 3, "/", ":", " "));
            A477VisDataHoraFim = T001411_A477VisDataHoraFim[0];
            n477VisDataHoraFim = T001411_n477VisDataHoraFim[0];
            AssignAttri("", false, "A477VisDataHoraFim", context.localUtil.TToC( A477VisDataHoraFim, 10, 5, 0, 3, "/", ":", " "));
            A415VisTipoSigla = T001411_A415VisTipoSigla[0];
            A416VisTipoNome = T001411_A416VisTipoNome[0];
            A466VisNegCodigo = T001411_A466VisNegCodigo[0];
            AssignAttri("", false, "A466VisNegCodigo", StringUtil.LTrimStr( (decimal)(A466VisNegCodigo), 12, 0));
            A467VisNegAssunto = T001411_A467VisNegAssunto[0];
            AssignAttri("", false, "A467VisNegAssunto", A467VisNegAssunto);
            A468VisNegValor = T001411_A468VisNegValor[0];
            AssignAttri("", false, "A468VisNegValor", StringUtil.LTrimStr( A468VisNegValor, 16, 2));
            A469VisNegCliNomeFamiliar = T001411_A469VisNegCliNomeFamiliar[0];
            AssignAttri("", false, "A469VisNegCliNomeFamiliar", A469VisNegCliNomeFamiliar);
            A470VisNegCpjNomFan = T001411_A470VisNegCpjNomFan[0];
            AssignAttri("", false, "A470VisNegCpjNomFan", A470VisNegCpjNomFan);
            A471VisNegCpjRazSocial = T001411_A471VisNegCpjRazSocial[0];
            A424VisNgfIteNome = T001411_A424VisNgfIteNome[0];
            AssignAttri("", false, "A424VisNgfIteNome", A424VisNgfIteNome);
            A409VisAssunto = T001411_A409VisAssunto[0];
            AssignAttri("", false, "A409VisAssunto", A409VisAssunto);
            A410VisDescricao = T001411_A410VisDescricao[0];
            n410VisDescricao = T001411_n410VisDescricao[0];
            A417VisLink = T001411_A417VisLink[0];
            n417VisLink = T001411_n417VisLink[0];
            AssignAttri("", false, "A417VisLink", A417VisLink);
            A472VisSituacao = T001411_A472VisSituacao[0];
            AssignAttri("", false, "A472VisSituacao", A472VisSituacao);
            A487VisDel = T001411_A487VisDel[0];
            A414VisTipoID = T001411_A414VisTipoID[0];
            AssignAttri("", false, "A414VisTipoID", StringUtil.LTrimStr( (decimal)(A414VisTipoID), 9, 0));
            A419VisPaiID = T001411_A419VisPaiID[0];
            n419VisPaiID = T001411_n419VisPaiID[0];
            AssignAttri("", false, "A419VisPaiID", A419VisPaiID.ToString());
            A407VisNegCliID = T001411_A407VisNegCliID[0];
            A408VisNegCpjID = T001411_A408VisNegCpjID[0];
            A423VisNgfIteID = T001411_A423VisNgfIteID[0];
            ZM1440( -53) ;
         }
         pr_default.close(9);
         OnLoadActions1440( ) ;
      }

      protected void OnLoadActions1440( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV15Insert_VisNegID) )
         {
            A418VisNegID = AV15Insert_VisNegID;
            n418VisNegID = false;
            AssignAttri("", false, "A418VisNegID", A418VisNegID.ToString());
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV16Insert_VisNgfSeq) )
         {
            A422VisNgfSeq = AV16Insert_VisNgfSeq;
            n422VisNgfSeq = false;
            AssignAttri("", false, "A422VisNgfSeq", StringUtil.LTrimStr( (decimal)(A422VisNgfSeq), 8, 0));
         }
         if ( true /* After */ )
         {
            A406VisDataHora = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( A404VisData)), (short)(DateTimeUtil.Month( A404VisData)), (short)(DateTimeUtil.Day( A404VisData)), (short)(DateTimeUtil.Hour( A405VisHora)), (short)(DateTimeUtil.Minute( A405VisHora)), 0);
            AssignAttri("", false, "A406VisDataHora", context.localUtil.TToC( A406VisDataHora, 10, 5, 0, 3, "/", ":", " "));
         }
         if ( IsIns( )  && (DateTime.MinValue==A475VisDataFim) && ( Gx_BScreen == 0 ) )
         {
            A475VisDataFim = DateTimeUtil.ResetTime( DateTimeUtil.TAdd( A406VisDataHora, 60*(30)));
            n475VisDataFim = false;
            AssignAttri("", false, "A475VisDataFim", context.localUtil.Format(A475VisDataFim, "99/99/99"));
         }
         if ( IsIns( )  && (DateTime.MinValue==A476VisHoraFim) && ( Gx_BScreen == 0 ) )
         {
            A476VisHoraFim = DateTimeUtil.ResetTime( DateTimeUtil.ResetTime( DateTimeUtil.TAdd( A406VisDataHora, 60*(30))) ) ;
            n476VisHoraFim = false;
            AssignAttri("", false, "A476VisHoraFim", context.localUtil.TToC( A476VisHoraFim, 0, 5, 0, 3, "/", ":", " "));
         }
         if ( true /* After */ )
         {
            A477VisDataHoraFim = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( A475VisDataFim)), (short)(DateTimeUtil.Month( A475VisDataFim)), (short)(DateTimeUtil.Day( A475VisDataFim)), (short)(DateTimeUtil.Hour( A476VisHoraFim)), (short)(DateTimeUtil.Minute( A476VisHoraFim)), 0);
            n477VisDataHoraFim = false;
            AssignAttri("", false, "A477VisDataHoraFim", context.localUtil.TToC( A477VisDataHoraFim, 10, 5, 0, 3, "/", ":", " "));
         }
      }

      protected void CheckExtendedTable1440( )
      {
         nIsDirty_40 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV15Insert_VisNegID) )
         {
            nIsDirty_40 = 1;
            A418VisNegID = AV15Insert_VisNegID;
            n418VisNegID = false;
            AssignAttri("", false, "A418VisNegID", A418VisNegID.ToString());
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV16Insert_VisNgfSeq) )
         {
            nIsDirty_40 = 1;
            A422VisNgfSeq = AV16Insert_VisNgfSeq;
            n422VisNgfSeq = false;
            AssignAttri("", false, "A422VisNgfSeq", StringUtil.LTrimStr( (decimal)(A422VisNgfSeq), 8, 0));
         }
         /* Using cursor T00147 */
         pr_default.execute(5, new Object[] {n419VisPaiID, A419VisPaiID});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( (Guid.Empty==A419VisPaiID) ) )
            {
               GX_msglist.addItem("Não existe 'Visita Origem'.", "ForeignKeyNotFound", 1, "VISPAIID");
               AnyError = 1;
               GX_FocusControl = edtVisPaiID_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A460VisPaiData = T00147_A460VisPaiData[0];
         A461VisPaiHora = T00147_A461VisPaiHora[0];
         A462VisPaiDataHora = T00147_A462VisPaiDataHora[0];
         AssignAttri("", false, "A462VisPaiDataHora", context.localUtil.TToC( A462VisPaiDataHora, 10, 5, 0, 3, "/", ":", " "));
         A465VisPaiAssunto = T00147_A465VisPaiAssunto[0];
         AssignAttri("", false, "A465VisPaiAssunto", A465VisPaiAssunto);
         pr_default.close(5);
         if ( (DateTime.MinValue==A404VisData) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Data da Visita", "", "", "", "", "", "", "", ""), 1, "VISDATA");
            AnyError = 1;
            GX_FocusControl = edtVisData_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( true /* After */ )
         {
            nIsDirty_40 = 1;
            A406VisDataHora = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( A404VisData)), (short)(DateTimeUtil.Month( A404VisData)), (short)(DateTimeUtil.Day( A404VisData)), (short)(DateTimeUtil.Hour( A405VisHora)), (short)(DateTimeUtil.Minute( A405VisHora)), 0);
            AssignAttri("", false, "A406VisDataHora", context.localUtil.TToC( A406VisDataHora, 10, 5, 0, 3, "/", ":", " "));
         }
         if ( A405VisHora == DateTime.MinValue )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Hora da Visita", "", "", "", "", "", "", "", ""), 1, "VISHORA");
            AnyError = 1;
            GX_FocusControl = edtVisHora_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00144 */
         pr_default.execute(2, new Object[] {A414VisTipoID});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("Não existe 'Tipo de Visita'.", "ForeignKeyNotFound", 1, "VISTIPOID");
            AnyError = 1;
            GX_FocusControl = edtVisTipoID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A415VisTipoSigla = T00144_A415VisTipoSigla[0];
         A416VisTipoNome = T00144_A416VisTipoNome[0];
         pr_default.close(2);
         if ( (0==A414VisTipoID) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "ID do Tipo da Visita", "", "", "", "", "", "", "", ""), 1, "VISTIPOID");
            AnyError = 1;
            GX_FocusControl = edtVisTipoID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A409VisAssunto)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Assunto da Visita", "", "", "", "", "", "", "", ""), 1, "VISASSUNTO");
            AnyError = 1;
            GX_FocusControl = edtVisAssunto_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( GxRegex.IsMatch(A417VisLink,"^((?:[a-zA-Z]+:(//)?)?((?:(?:[a-zA-Z]([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*)(?:\\.(?:([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*))*)|(?:(\\d{1,3}\\.){3}\\d{1,3}))(?::\\d+)?(?:/([a-zA-Z0-9$\\-_@.&+!*\"'(),=;: ]|%[0-9a-fA-F]{2})+)*/?(?:[#?](?:[a-zA-Z0-9$\\-_@.&+!*\"'(),=;: /]|%[0-9a-fA-F]{2})*)?)?\\s*$") || String.IsNullOrEmpty(StringUtil.RTrim( A417VisLink)) ) )
         {
            GX_msglist.addItem("O valor de Link da Visita (Virtual) não coincide com o padrão especificado", "OutOfRange", 1, "VISLINK");
            AnyError = 1;
            GX_FocusControl = edtVisLink_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( IsIns( )  && (DateTime.MinValue==A475VisDataFim) && ( Gx_BScreen == 0 ) )
         {
            nIsDirty_40 = 1;
            A475VisDataFim = DateTimeUtil.ResetTime( DateTimeUtil.TAdd( A406VisDataHora, 60*(30)));
            n475VisDataFim = false;
            AssignAttri("", false, "A475VisDataFim", context.localUtil.Format(A475VisDataFim, "99/99/99"));
         }
         if ( IsIns( )  && (DateTime.MinValue==A476VisHoraFim) && ( Gx_BScreen == 0 ) )
         {
            nIsDirty_40 = 1;
            A476VisHoraFim = DateTimeUtil.ResetTime( DateTimeUtil.ResetTime( DateTimeUtil.TAdd( A406VisDataHora, 60*(30))) ) ;
            n476VisHoraFim = false;
            AssignAttri("", false, "A476VisHoraFim", context.localUtil.TToC( A476VisHoraFim, 0, 5, 0, 3, "/", ":", " "));
         }
         if ( (DateTime.MinValue==A475VisDataFim) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Data de Término da Visita", "", "", "", "", "", "", "", ""), 1, "VISDATAFIM");
            AnyError = 1;
            GX_FocusControl = edtVisDataFim_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( true /* After */ )
         {
            nIsDirty_40 = 1;
            A477VisDataHoraFim = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( A475VisDataFim)), (short)(DateTimeUtil.Month( A475VisDataFim)), (short)(DateTimeUtil.Day( A475VisDataFim)), (short)(DateTimeUtil.Hour( A476VisHoraFim)), (short)(DateTimeUtil.Minute( A476VisHoraFim)), 0);
            n477VisDataHoraFim = false;
            AssignAttri("", false, "A477VisDataHoraFim", context.localUtil.TToC( A477VisDataHoraFim, 10, 5, 0, 3, "/", ":", " "));
         }
         if ( A476VisHoraFim == DateTime.MinValue )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Hora de Término da Hora", "", "", "", "", "", "", "", ""), 1, "VISHORAFIM");
            AnyError = 1;
            GX_FocusControl = edtVisHoraFim_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( true /* After */ && ( A477VisDataHoraFim < A406VisDataHora ) )
         {
            GX_msglist.addItem("A data e hora de término da visita não pode ser anterior à data e hora de início da visita", 1, "VISHORAFIM");
            AnyError = 1;
            GX_FocusControl = edtVisHoraFim_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors1440( )
      {
         pr_default.close(5);
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_57( Guid A419VisPaiID )
      {
         /* Using cursor T001412 */
         pr_default.execute(10, new Object[] {n419VisPaiID, A419VisPaiID});
         if ( (pr_default.getStatus(10) == 101) )
         {
            if ( ! ( (Guid.Empty==A419VisPaiID) ) )
            {
               GX_msglist.addItem("Não existe 'Visita Origem'.", "ForeignKeyNotFound", 1, "VISPAIID");
               AnyError = 1;
               GX_FocusControl = edtVisPaiID_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A460VisPaiData = T001412_A460VisPaiData[0];
         A461VisPaiHora = T001412_A461VisPaiHora[0];
         A462VisPaiDataHora = T001412_A462VisPaiDataHora[0];
         AssignAttri("", false, "A462VisPaiDataHora", context.localUtil.TToC( A462VisPaiDataHora, 10, 5, 0, 3, "/", ":", " "));
         A465VisPaiAssunto = T001412_A465VisPaiAssunto[0];
         AssignAttri("", false, "A465VisPaiAssunto", A465VisPaiAssunto);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( context.localUtil.Format(A460VisPaiData, "99/99/99"))+"\""+","+"\""+GXUtil.EncodeJSConstant( context.localUtil.TToC( A461VisPaiHora, 10, 8, 0, 3, "/", ":", " "))+"\""+","+"\""+GXUtil.EncodeJSConstant( context.localUtil.TToC( A462VisPaiDataHora, 10, 8, 0, 3, "/", ":", " "))+"\""+","+"\""+GXUtil.EncodeJSConstant( A465VisPaiAssunto)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(10) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(10);
      }

      protected void gxLoad_54( int A414VisTipoID )
      {
         /* Using cursor T001413 */
         pr_default.execute(11, new Object[] {A414VisTipoID});
         if ( (pr_default.getStatus(11) == 101) )
         {
            GX_msglist.addItem("Não existe 'Tipo de Visita'.", "ForeignKeyNotFound", 1, "VISTIPOID");
            AnyError = 1;
            GX_FocusControl = edtVisTipoID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A415VisTipoSigla = T001413_A415VisTipoSigla[0];
         A416VisTipoNome = T001413_A416VisTipoNome[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A415VisTipoSigla)+"\""+","+"\""+GXUtil.EncodeJSConstant( A416VisTipoNome)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(11) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(11);
      }

      protected void GetKey1440( )
      {
         /* Using cursor T001414 */
         pr_default.execute(12, new Object[] {A398VisID});
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound40 = 1;
         }
         else
         {
            RcdFound40 = 0;
         }
         pr_default.close(12);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00143 */
         pr_default.execute(1, new Object[] {A398VisID});
         if ( (pr_default.getStatus(1) != 101) && ( T00143_A418VisNegID[0] == A418VisNegID ) && ( T00143_A422VisNgfSeq[0] == A422VisNgfSeq ) )
         {
            ZM1440( 53) ;
            RcdFound40 = 1;
            A398VisID = T00143_A398VisID[0];
            A401VisInsDataHora = T00143_A401VisInsDataHora[0];
            A399VisInsData = T00143_A399VisInsData[0];
            A400VisInsHora = T00143_A400VisInsHora[0];
            A402VisInsUsuID = T00143_A402VisInsUsuID[0];
            n402VisInsUsuID = T00143_n402VisInsUsuID[0];
            A403VisInsUsuNome = T00143_A403VisInsUsuNome[0];
            n403VisInsUsuNome = T00143_n403VisInsUsuNome[0];
            A490VisDelDataHora = T00143_A490VisDelDataHora[0];
            n490VisDelDataHora = T00143_n490VisDelDataHora[0];
            A488VisDelData = T00143_A488VisDelData[0];
            n488VisDelData = T00143_n488VisDelData[0];
            A489VisDelHora = T00143_A489VisDelHora[0];
            n489VisDelHora = T00143_n489VisDelHora[0];
            A491VisDelUsuID = T00143_A491VisDelUsuID[0];
            n491VisDelUsuID = T00143_n491VisDelUsuID[0];
            A492VisDelUsuNome = T00143_A492VisDelUsuNome[0];
            n492VisDelUsuNome = T00143_n492VisDelUsuNome[0];
            A482VisUpdData = T00143_A482VisUpdData[0];
            n482VisUpdData = T00143_n482VisUpdData[0];
            A483VisUpdHora = T00143_A483VisUpdHora[0];
            n483VisUpdHora = T00143_n483VisUpdHora[0];
            A484VisUpdDataHora = T00143_A484VisUpdDataHora[0];
            n484VisUpdDataHora = T00143_n484VisUpdDataHora[0];
            A485VisUpdUsuID = T00143_A485VisUpdUsuID[0];
            n485VisUpdUsuID = T00143_n485VisUpdUsuID[0];
            A486VisUpdUsuNome = T00143_A486VisUpdUsuNome[0];
            n486VisUpdUsuNome = T00143_n486VisUpdUsuNome[0];
            A404VisData = T00143_A404VisData[0];
            AssignAttri("", false, "A404VisData", context.localUtil.Format(A404VisData, "99/99/99"));
            A405VisHora = T00143_A405VisHora[0];
            AssignAttri("", false, "A405VisHora", context.localUtil.TToC( A405VisHora, 0, 5, 0, 3, "/", ":", " "));
            A406VisDataHora = T00143_A406VisDataHora[0];
            AssignAttri("", false, "A406VisDataHora", context.localUtil.TToC( A406VisDataHora, 10, 5, 0, 3, "/", ":", " "));
            A475VisDataFim = T00143_A475VisDataFim[0];
            n475VisDataFim = T00143_n475VisDataFim[0];
            AssignAttri("", false, "A475VisDataFim", context.localUtil.Format(A475VisDataFim, "99/99/99"));
            A476VisHoraFim = T00143_A476VisHoraFim[0];
            n476VisHoraFim = T00143_n476VisHoraFim[0];
            AssignAttri("", false, "A476VisHoraFim", context.localUtil.TToC( A476VisHoraFim, 0, 5, 0, 3, "/", ":", " "));
            A477VisDataHoraFim = T00143_A477VisDataHoraFim[0];
            n477VisDataHoraFim = T00143_n477VisDataHoraFim[0];
            AssignAttri("", false, "A477VisDataHoraFim", context.localUtil.TToC( A477VisDataHoraFim, 10, 5, 0, 3, "/", ":", " "));
            A409VisAssunto = T00143_A409VisAssunto[0];
            AssignAttri("", false, "A409VisAssunto", A409VisAssunto);
            A410VisDescricao = T00143_A410VisDescricao[0];
            n410VisDescricao = T00143_n410VisDescricao[0];
            A417VisLink = T00143_A417VisLink[0];
            n417VisLink = T00143_n417VisLink[0];
            AssignAttri("", false, "A417VisLink", A417VisLink);
            A472VisSituacao = T00143_A472VisSituacao[0];
            AssignAttri("", false, "A472VisSituacao", A472VisSituacao);
            A487VisDel = T00143_A487VisDel[0];
            A414VisTipoID = T00143_A414VisTipoID[0];
            AssignAttri("", false, "A414VisTipoID", StringUtil.LTrimStr( (decimal)(A414VisTipoID), 9, 0));
            A419VisPaiID = T00143_A419VisPaiID[0];
            n419VisPaiID = T00143_n419VisPaiID[0];
            AssignAttri("", false, "A419VisPaiID", A419VisPaiID.ToString());
            O487VisDel = A487VisDel;
            AssignAttri("", false, "A487VisDel", A487VisDel);
            Z398VisID = A398VisID;
            sMode40 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load1440( ) ;
            if ( AnyError == 1 )
            {
               RcdFound40 = 0;
               InitializeNonKey1440( ) ;
            }
            Gx_mode = sMode40;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound40 = 0;
            InitializeNonKey1440( ) ;
            sMode40 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode40;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1440( ) ;
         if ( RcdFound40 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound40 = 0;
         /* Using cursor T001415 */
         pr_default.execute(13, new Object[] {A398VisID, n418VisNegID, A418VisNegID, n422VisNgfSeq, A422VisNgfSeq});
         if ( (pr_default.getStatus(13) != 101) )
         {
            while ( (pr_default.getStatus(13) != 101) && ( ( GuidUtil.Compare(T001415_A398VisID[0], A398VisID, 0) < 0 ) ) && ( T001415_A418VisNegID[0] == A418VisNegID ) && ( T001415_A422VisNgfSeq[0] == A422VisNgfSeq ) )
            {
               pr_default.readNext(13);
            }
            if ( (pr_default.getStatus(13) != 101) && ( ( GuidUtil.Compare(T001415_A398VisID[0], A398VisID, 0) > 0 ) ) && ( T001415_A418VisNegID[0] == A418VisNegID ) && ( T001415_A422VisNgfSeq[0] == A422VisNgfSeq ) )
            {
               A398VisID = T001415_A398VisID[0];
               RcdFound40 = 1;
            }
         }
         pr_default.close(13);
      }

      protected void move_previous( )
      {
         RcdFound40 = 0;
         /* Using cursor T001416 */
         pr_default.execute(14, new Object[] {A398VisID, n418VisNegID, A418VisNegID, n422VisNgfSeq, A422VisNgfSeq});
         if ( (pr_default.getStatus(14) != 101) )
         {
            while ( (pr_default.getStatus(14) != 101) && ( ( GuidUtil.Compare(T001416_A398VisID[0], A398VisID, 0) > 0 ) ) && ( T001416_A418VisNegID[0] == A418VisNegID ) && ( T001416_A422VisNgfSeq[0] == A422VisNgfSeq ) )
            {
               pr_default.readNext(14);
            }
            if ( (pr_default.getStatus(14) != 101) && ( ( GuidUtil.Compare(T001416_A398VisID[0], A398VisID, 0) < 0 ) ) && ( T001416_A418VisNegID[0] == A418VisNegID ) && ( T001416_A422VisNgfSeq[0] == A422VisNgfSeq ) )
            {
               A398VisID = T001416_A398VisID[0];
               RcdFound40 = 1;
            }
         }
         pr_default.close(14);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1440( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtVisTipoID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1440( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound40 == 1 )
            {
               if ( A398VisID != Z398VisID )
               {
                  A398VisID = Z398VisID;
                  AssignAttri("", false, "A398VisID", A398VisID.ToString());
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtVisTipoID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update1440( ) ;
                  GX_FocusControl = edtVisTipoID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A398VisID != Z398VisID )
               {
                  /* Insert record */
                  GX_FocusControl = edtVisTipoID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1440( ) ;
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
                     GX_FocusControl = edtVisTipoID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1440( ) ;
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
         if ( A398VisID != Z398VisID )
         {
            A398VisID = Z398VisID;
            AssignAttri("", false, "A398VisID", A398VisID.ToString());
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "");
            AnyError = 1;
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtVisTipoID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency1440( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00142 */
            pr_default.execute(0, new Object[] {A398VisID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_visita"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z401VisInsDataHora != T00142_A401VisInsDataHora[0] ) || ( DateTimeUtil.ResetTime ( Z399VisInsData ) != DateTimeUtil.ResetTime ( T00142_A399VisInsData[0] ) ) || ( Z400VisInsHora != T00142_A400VisInsHora[0] ) || ( StringUtil.StrCmp(Z402VisInsUsuID, T00142_A402VisInsUsuID[0]) != 0 ) || ( StringUtil.StrCmp(Z403VisInsUsuNome, T00142_A403VisInsUsuNome[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z490VisDelDataHora != T00142_A490VisDelDataHora[0] ) || ( Z488VisDelData != T00142_A488VisDelData[0] ) || ( Z489VisDelHora != T00142_A489VisDelHora[0] ) || ( StringUtil.StrCmp(Z491VisDelUsuID, T00142_A491VisDelUsuID[0]) != 0 ) || ( StringUtil.StrCmp(Z492VisDelUsuNome, T00142_A492VisDelUsuNome[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( DateTimeUtil.ResetTime ( Z482VisUpdData ) != DateTimeUtil.ResetTime ( T00142_A482VisUpdData[0] ) ) || ( Z483VisUpdHora != T00142_A483VisUpdHora[0] ) || ( Z484VisUpdDataHora != T00142_A484VisUpdDataHora[0] ) || ( StringUtil.StrCmp(Z485VisUpdUsuID, T00142_A485VisUpdUsuID[0]) != 0 ) || ( StringUtil.StrCmp(Z486VisUpdUsuNome, T00142_A486VisUpdUsuNome[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( DateTimeUtil.ResetTime ( Z404VisData ) != DateTimeUtil.ResetTime ( T00142_A404VisData[0] ) ) || ( Z405VisHora != T00142_A405VisHora[0] ) || ( Z406VisDataHora != T00142_A406VisDataHora[0] ) || ( DateTimeUtil.ResetTime ( Z475VisDataFim ) != DateTimeUtil.ResetTime ( T00142_A475VisDataFim[0] ) ) || ( Z476VisHoraFim != T00142_A476VisHoraFim[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z477VisDataHoraFim != T00142_A477VisDataHoraFim[0] ) || ( StringUtil.StrCmp(Z409VisAssunto, T00142_A409VisAssunto[0]) != 0 ) || ( StringUtil.StrCmp(Z417VisLink, T00142_A417VisLink[0]) != 0 ) || ( StringUtil.StrCmp(Z472VisSituacao, T00142_A472VisSituacao[0]) != 0 ) || ( Z487VisDel != T00142_A487VisDel[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z414VisTipoID != T00142_A414VisTipoID[0] ) || ( Z419VisPaiID != T00142_A419VisPaiID[0] ) )
            {
               if ( Z401VisInsDataHora != T00142_A401VisInsDataHora[0] )
               {
                  GXUtil.WriteLog("core.visita:[seudo value changed for attri]"+"VisInsDataHora");
                  GXUtil.WriteLogRaw("Old: ",Z401VisInsDataHora);
                  GXUtil.WriteLogRaw("Current: ",T00142_A401VisInsDataHora[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z399VisInsData ) != DateTimeUtil.ResetTime ( T00142_A399VisInsData[0] ) )
               {
                  GXUtil.WriteLog("core.visita:[seudo value changed for attri]"+"VisInsData");
                  GXUtil.WriteLogRaw("Old: ",Z399VisInsData);
                  GXUtil.WriteLogRaw("Current: ",T00142_A399VisInsData[0]);
               }
               if ( Z400VisInsHora != T00142_A400VisInsHora[0] )
               {
                  GXUtil.WriteLog("core.visita:[seudo value changed for attri]"+"VisInsHora");
                  GXUtil.WriteLogRaw("Old: ",Z400VisInsHora);
                  GXUtil.WriteLogRaw("Current: ",T00142_A400VisInsHora[0]);
               }
               if ( StringUtil.StrCmp(Z402VisInsUsuID, T00142_A402VisInsUsuID[0]) != 0 )
               {
                  GXUtil.WriteLog("core.visita:[seudo value changed for attri]"+"VisInsUsuID");
                  GXUtil.WriteLogRaw("Old: ",Z402VisInsUsuID);
                  GXUtil.WriteLogRaw("Current: ",T00142_A402VisInsUsuID[0]);
               }
               if ( StringUtil.StrCmp(Z403VisInsUsuNome, T00142_A403VisInsUsuNome[0]) != 0 )
               {
                  GXUtil.WriteLog("core.visita:[seudo value changed for attri]"+"VisInsUsuNome");
                  GXUtil.WriteLogRaw("Old: ",Z403VisInsUsuNome);
                  GXUtil.WriteLogRaw("Current: ",T00142_A403VisInsUsuNome[0]);
               }
               if ( Z490VisDelDataHora != T00142_A490VisDelDataHora[0] )
               {
                  GXUtil.WriteLog("core.visita:[seudo value changed for attri]"+"VisDelDataHora");
                  GXUtil.WriteLogRaw("Old: ",Z490VisDelDataHora);
                  GXUtil.WriteLogRaw("Current: ",T00142_A490VisDelDataHora[0]);
               }
               if ( Z488VisDelData != T00142_A488VisDelData[0] )
               {
                  GXUtil.WriteLog("core.visita:[seudo value changed for attri]"+"VisDelData");
                  GXUtil.WriteLogRaw("Old: ",Z488VisDelData);
                  GXUtil.WriteLogRaw("Current: ",T00142_A488VisDelData[0]);
               }
               if ( Z489VisDelHora != T00142_A489VisDelHora[0] )
               {
                  GXUtil.WriteLog("core.visita:[seudo value changed for attri]"+"VisDelHora");
                  GXUtil.WriteLogRaw("Old: ",Z489VisDelHora);
                  GXUtil.WriteLogRaw("Current: ",T00142_A489VisDelHora[0]);
               }
               if ( StringUtil.StrCmp(Z491VisDelUsuID, T00142_A491VisDelUsuID[0]) != 0 )
               {
                  GXUtil.WriteLog("core.visita:[seudo value changed for attri]"+"VisDelUsuID");
                  GXUtil.WriteLogRaw("Old: ",Z491VisDelUsuID);
                  GXUtil.WriteLogRaw("Current: ",T00142_A491VisDelUsuID[0]);
               }
               if ( StringUtil.StrCmp(Z492VisDelUsuNome, T00142_A492VisDelUsuNome[0]) != 0 )
               {
                  GXUtil.WriteLog("core.visita:[seudo value changed for attri]"+"VisDelUsuNome");
                  GXUtil.WriteLogRaw("Old: ",Z492VisDelUsuNome);
                  GXUtil.WriteLogRaw("Current: ",T00142_A492VisDelUsuNome[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z482VisUpdData ) != DateTimeUtil.ResetTime ( T00142_A482VisUpdData[0] ) )
               {
                  GXUtil.WriteLog("core.visita:[seudo value changed for attri]"+"VisUpdData");
                  GXUtil.WriteLogRaw("Old: ",Z482VisUpdData);
                  GXUtil.WriteLogRaw("Current: ",T00142_A482VisUpdData[0]);
               }
               if ( Z483VisUpdHora != T00142_A483VisUpdHora[0] )
               {
                  GXUtil.WriteLog("core.visita:[seudo value changed for attri]"+"VisUpdHora");
                  GXUtil.WriteLogRaw("Old: ",Z483VisUpdHora);
                  GXUtil.WriteLogRaw("Current: ",T00142_A483VisUpdHora[0]);
               }
               if ( Z484VisUpdDataHora != T00142_A484VisUpdDataHora[0] )
               {
                  GXUtil.WriteLog("core.visita:[seudo value changed for attri]"+"VisUpdDataHora");
                  GXUtil.WriteLogRaw("Old: ",Z484VisUpdDataHora);
                  GXUtil.WriteLogRaw("Current: ",T00142_A484VisUpdDataHora[0]);
               }
               if ( StringUtil.StrCmp(Z485VisUpdUsuID, T00142_A485VisUpdUsuID[0]) != 0 )
               {
                  GXUtil.WriteLog("core.visita:[seudo value changed for attri]"+"VisUpdUsuID");
                  GXUtil.WriteLogRaw("Old: ",Z485VisUpdUsuID);
                  GXUtil.WriteLogRaw("Current: ",T00142_A485VisUpdUsuID[0]);
               }
               if ( StringUtil.StrCmp(Z486VisUpdUsuNome, T00142_A486VisUpdUsuNome[0]) != 0 )
               {
                  GXUtil.WriteLog("core.visita:[seudo value changed for attri]"+"VisUpdUsuNome");
                  GXUtil.WriteLogRaw("Old: ",Z486VisUpdUsuNome);
                  GXUtil.WriteLogRaw("Current: ",T00142_A486VisUpdUsuNome[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z404VisData ) != DateTimeUtil.ResetTime ( T00142_A404VisData[0] ) )
               {
                  GXUtil.WriteLog("core.visita:[seudo value changed for attri]"+"VisData");
                  GXUtil.WriteLogRaw("Old: ",Z404VisData);
                  GXUtil.WriteLogRaw("Current: ",T00142_A404VisData[0]);
               }
               if ( Z405VisHora != T00142_A405VisHora[0] )
               {
                  GXUtil.WriteLog("core.visita:[seudo value changed for attri]"+"VisHora");
                  GXUtil.WriteLogRaw("Old: ",Z405VisHora);
                  GXUtil.WriteLogRaw("Current: ",T00142_A405VisHora[0]);
               }
               if ( Z406VisDataHora != T00142_A406VisDataHora[0] )
               {
                  GXUtil.WriteLog("core.visita:[seudo value changed for attri]"+"VisDataHora");
                  GXUtil.WriteLogRaw("Old: ",Z406VisDataHora);
                  GXUtil.WriteLogRaw("Current: ",T00142_A406VisDataHora[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z475VisDataFim ) != DateTimeUtil.ResetTime ( T00142_A475VisDataFim[0] ) )
               {
                  GXUtil.WriteLog("core.visita:[seudo value changed for attri]"+"VisDataFim");
                  GXUtil.WriteLogRaw("Old: ",Z475VisDataFim);
                  GXUtil.WriteLogRaw("Current: ",T00142_A475VisDataFim[0]);
               }
               if ( Z476VisHoraFim != T00142_A476VisHoraFim[0] )
               {
                  GXUtil.WriteLog("core.visita:[seudo value changed for attri]"+"VisHoraFim");
                  GXUtil.WriteLogRaw("Old: ",Z476VisHoraFim);
                  GXUtil.WriteLogRaw("Current: ",T00142_A476VisHoraFim[0]);
               }
               if ( Z477VisDataHoraFim != T00142_A477VisDataHoraFim[0] )
               {
                  GXUtil.WriteLog("core.visita:[seudo value changed for attri]"+"VisDataHoraFim");
                  GXUtil.WriteLogRaw("Old: ",Z477VisDataHoraFim);
                  GXUtil.WriteLogRaw("Current: ",T00142_A477VisDataHoraFim[0]);
               }
               if ( StringUtil.StrCmp(Z409VisAssunto, T00142_A409VisAssunto[0]) != 0 )
               {
                  GXUtil.WriteLog("core.visita:[seudo value changed for attri]"+"VisAssunto");
                  GXUtil.WriteLogRaw("Old: ",Z409VisAssunto);
                  GXUtil.WriteLogRaw("Current: ",T00142_A409VisAssunto[0]);
               }
               if ( StringUtil.StrCmp(Z417VisLink, T00142_A417VisLink[0]) != 0 )
               {
                  GXUtil.WriteLog("core.visita:[seudo value changed for attri]"+"VisLink");
                  GXUtil.WriteLogRaw("Old: ",Z417VisLink);
                  GXUtil.WriteLogRaw("Current: ",T00142_A417VisLink[0]);
               }
               if ( StringUtil.StrCmp(Z472VisSituacao, T00142_A472VisSituacao[0]) != 0 )
               {
                  GXUtil.WriteLog("core.visita:[seudo value changed for attri]"+"VisSituacao");
                  GXUtil.WriteLogRaw("Old: ",Z472VisSituacao);
                  GXUtil.WriteLogRaw("Current: ",T00142_A472VisSituacao[0]);
               }
               if ( Z487VisDel != T00142_A487VisDel[0] )
               {
                  GXUtil.WriteLog("core.visita:[seudo value changed for attri]"+"VisDel");
                  GXUtil.WriteLogRaw("Old: ",Z487VisDel);
                  GXUtil.WriteLogRaw("Current: ",T00142_A487VisDel[0]);
               }
               if ( Z414VisTipoID != T00142_A414VisTipoID[0] )
               {
                  GXUtil.WriteLog("core.visita:[seudo value changed for attri]"+"VisTipoID");
                  GXUtil.WriteLogRaw("Old: ",Z414VisTipoID);
                  GXUtil.WriteLogRaw("Current: ",T00142_A414VisTipoID[0]);
               }
               if ( Z419VisPaiID != T00142_A419VisPaiID[0] )
               {
                  GXUtil.WriteLog("core.visita:[seudo value changed for attri]"+"VisPaiID");
                  GXUtil.WriteLogRaw("Old: ",Z419VisPaiID);
                  GXUtil.WriteLogRaw("Current: ",T00142_A419VisPaiID[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"tb_visita"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1440( )
      {
         if ( ! IsAuthorized("visita_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1440( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1440( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1440( 0) ;
            CheckOptimisticConcurrency1440( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1440( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1440( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001417 */
                     pr_default.execute(15, new Object[] {n418VisNegID, A418VisNegID, n422VisNgfSeq, A422VisNgfSeq, A398VisID, A401VisInsDataHora, A399VisInsData, A400VisInsHora, n402VisInsUsuID, A402VisInsUsuID, n403VisInsUsuNome, A403VisInsUsuNome, n490VisDelDataHora, A490VisDelDataHora, n488VisDelData, A488VisDelData, n489VisDelHora, A489VisDelHora, n491VisDelUsuID, A491VisDelUsuID, n492VisDelUsuNome, A492VisDelUsuNome, n482VisUpdData, A482VisUpdData, n483VisUpdHora, A483VisUpdHora, n484VisUpdDataHora, A484VisUpdDataHora, n485VisUpdUsuID, A485VisUpdUsuID, n486VisUpdUsuNome, A486VisUpdUsuNome, A404VisData, A405VisHora, A406VisDataHora, n475VisDataFim, A475VisDataFim, n476VisHoraFim, A476VisHoraFim, n477VisDataHoraFim, A477VisDataHoraFim, A409VisAssunto, n410VisDescricao, A410VisDescricao, n417VisLink, A417VisLink, A472VisSituacao, A487VisDel, A414VisTipoID, n419VisPaiID, A419VisPaiID});
                     pr_default.close(15);
                     pr_default.SmartCacheProvider.SetUpdated("tb_visita");
                     if ( (pr_default.getStatus(15) == 1) )
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
               Load1440( ) ;
            }
            EndLevel1440( ) ;
         }
         CloseExtendedTableCursors1440( ) ;
      }

      protected void Update1440( )
      {
         if ( ! IsAuthorized("visita_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1440( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1440( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1440( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1440( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1440( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001418 */
                     pr_default.execute(16, new Object[] {n418VisNegID, A418VisNegID, n422VisNgfSeq, A422VisNgfSeq, A401VisInsDataHora, A399VisInsData, A400VisInsHora, n402VisInsUsuID, A402VisInsUsuID, n403VisInsUsuNome, A403VisInsUsuNome, n490VisDelDataHora, A490VisDelDataHora, n488VisDelData, A488VisDelData, n489VisDelHora, A489VisDelHora, n491VisDelUsuID, A491VisDelUsuID, n492VisDelUsuNome, A492VisDelUsuNome, n482VisUpdData, A482VisUpdData, n483VisUpdHora, A483VisUpdHora, n484VisUpdDataHora, A484VisUpdDataHora, n485VisUpdUsuID, A485VisUpdUsuID, n486VisUpdUsuNome, A486VisUpdUsuNome, A404VisData, A405VisHora, A406VisDataHora, n475VisDataFim, A475VisDataFim, n476VisHoraFim, A476VisHoraFim, n477VisDataHoraFim, A477VisDataHoraFim, A409VisAssunto, n410VisDescricao, A410VisDescricao, n417VisLink, A417VisLink, A472VisSituacao, A487VisDel, A414VisTipoID, n419VisPaiID, A419VisPaiID, A398VisID});
                     pr_default.close(16);
                     pr_default.SmartCacheProvider.SetUpdated("tb_visita");
                     if ( (pr_default.getStatus(16) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_visita"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1440( ) ;
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
            EndLevel1440( ) ;
         }
         CloseExtendedTableCursors1440( ) ;
      }

      protected void DeferredUpdate1440( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("visita_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1440( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1440( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1440( ) ;
            AfterConfirm1440( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1440( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001419 */
                  pr_default.execute(17, new Object[] {A398VisID});
                  pr_default.close(17);
                  pr_default.SmartCacheProvider.SetUpdated("tb_visita");
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
         sMode40 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1440( ) ;
         Gx_mode = sMode40;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1440( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T001420 */
            pr_default.execute(18, new Object[] {n419VisPaiID, A419VisPaiID});
            A460VisPaiData = T001420_A460VisPaiData[0];
            A461VisPaiHora = T001420_A461VisPaiHora[0];
            A462VisPaiDataHora = T001420_A462VisPaiDataHora[0];
            AssignAttri("", false, "A462VisPaiDataHora", context.localUtil.TToC( A462VisPaiDataHora, 10, 5, 0, 3, "/", ":", " "));
            A465VisPaiAssunto = T001420_A465VisPaiAssunto[0];
            AssignAttri("", false, "A465VisPaiAssunto", A465VisPaiAssunto);
            pr_default.close(18);
            /* Using cursor T001421 */
            pr_default.execute(19, new Object[] {A414VisTipoID});
            A415VisTipoSigla = T001421_A415VisTipoSigla[0];
            A416VisTipoNome = T001421_A416VisTipoNome[0];
            pr_default.close(19);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T001422 */
            pr_default.execute(20, new Object[] {A398VisID});
            if ( (pr_default.getStatus(20) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(20);
         }
      }

      protected void EndLevel1440( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1440( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("core.visita",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues140( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("core.visita",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1440( )
      {
         /* Scan By routine */
         /* Using cursor T001423 */
         pr_default.execute(21, new Object[] {n418VisNegID, A418VisNegID, n422VisNgfSeq, A422VisNgfSeq});
         RcdFound40 = 0;
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound40 = 1;
            A398VisID = T001423_A398VisID[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1440( )
      {
         /* Scan next routine */
         pr_default.readNext(21);
         RcdFound40 = 0;
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound40 = 1;
            A398VisID = T001423_A398VisID[0];
         }
      }

      protected void ScanEnd1440( )
      {
         pr_default.close(21);
      }

      protected void AfterConfirm1440( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1440( )
      {
         /* Before Insert Rules */
         A401VisInsDataHora = DateTimeUtil.NowMS( context);
         AssignAttri("", false, "A401VisInsDataHora", context.localUtil.TToC( A401VisInsDataHora, 10, 12, 0, 3, "/", ":", " "));
         A402VisInsUsuID = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getid();
         n402VisInsUsuID = false;
         AssignAttri("", false, "A402VisInsUsuID", A402VisInsUsuID);
         A403VisInsUsuNome = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
         n403VisInsUsuNome = false;
         AssignAttri("", false, "A403VisInsUsuNome", A403VisInsUsuNome);
         if ( ! (Guid.Empty==AV40VisPaiID) )
         {
            new GeneXus.Programs.core.prcvisitaremarcada(context ).execute(  AV40VisPaiID,  false,  new GeneXus.Programs.genexussecurity.SdtGAMUser(context).get(), out  AV44Messages) ;
         }
         if ( ! (Guid.Empty==AV40VisPaiID) && ( ((GeneXus.Utils.SdtMessages_Message)AV44Messages.Item(1)).gxTpr_Type == 1 ) )
         {
            GX_msglist.addItem(((GeneXus.Utils.SdtMessages_Message)AV44Messages.Item(1)).gxTpr_Description, 1, "");
            AnyError = 1;
         }
         A399VisInsData = DateTimeUtil.ResetTime( A401VisInsDataHora);
         AssignAttri("", false, "A399VisInsData", context.localUtil.Format(A399VisInsData, "99/99/99"));
         A400VisInsHora = DateTimeUtil.ResetDate( DateTimeUtil.ResetMilliseconds(A401VisInsDataHora));
         AssignAttri("", false, "A400VisInsHora", context.localUtil.TToC( A400VisInsHora, 0, 5, 0, 3, "/", ":", " "));
      }

      protected void BeforeUpdate1440( )
      {
         /* Before Update Rules */
         new GeneXus.Programs.core.loadauditvisita(context ).execute(  "Y", ref  AV43AuditingObject,  A398VisID,  Gx_mode) ;
         if ( A487VisDel && ( O487VisDel != A487VisDel ) )
         {
            A490VisDelDataHora = DateTimeUtil.NowMS( context);
            n490VisDelDataHora = false;
            AssignAttri("", false, "A490VisDelDataHora", context.localUtil.TToC( A490VisDelDataHora, 10, 12, 0, 3, "/", ":", " "));
         }
         if ( A487VisDel && ( O487VisDel != A487VisDel ) )
         {
            A491VisDelUsuID = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getid();
            n491VisDelUsuID = false;
            AssignAttri("", false, "A491VisDelUsuID", A491VisDelUsuID);
         }
         if ( A487VisDel && ( O487VisDel != A487VisDel ) )
         {
            A492VisDelUsuNome = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
            n492VisDelUsuNome = false;
            AssignAttri("", false, "A492VisDelUsuNome", A492VisDelUsuNome);
         }
         if ( A487VisDel && ( O487VisDel != A487VisDel ) )
         {
            A488VisDelData = DateTimeUtil.ResetTime( DateTimeUtil.ResetTime( A490VisDelDataHora) ) ;
            n488VisDelData = false;
            AssignAttri("", false, "A488VisDelData", context.localUtil.TToC( A488VisDelData, 10, 5, 0, 3, "/", ":", " "));
         }
         if ( A487VisDel && ( O487VisDel != A487VisDel ) )
         {
            A489VisDelHora = DateTimeUtil.ResetDate( DateTimeUtil.ResetMilliseconds(A490VisDelDataHora));
            n489VisDelHora = false;
            AssignAttri("", false, "A489VisDelHora", context.localUtil.TToC( A489VisDelHora, 0, 5, 0, 3, "/", ":", " "));
         }
      }

      protected void BeforeDelete1440( )
      {
         /* Before Delete Rules */
         new GeneXus.Programs.core.loadauditvisita(context ).execute(  "Y", ref  AV43AuditingObject,  A398VisID,  Gx_mode) ;
      }

      protected void BeforeComplete1440( )
      {
         /* Before Complete Rules */
         if ( IsIns( )  )
         {
            new GeneXus.Programs.core.loadauditvisita(context ).execute(  "N", ref  AV43AuditingObject,  A398VisID,  Gx_mode) ;
         }
         if ( IsUpd( )  )
         {
            new GeneXus.Programs.core.loadauditvisita(context ).execute(  "N", ref  AV43AuditingObject,  A398VisID,  Gx_mode) ;
         }
      }

      protected void BeforeValidate1440( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1440( )
      {
         edtVisNegCodigo_Enabled = 0;
         AssignProp("", false, edtVisNegCodigo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVisNegCodigo_Enabled), 5, 0), true);
         edtVisNegAssunto_Enabled = 0;
         AssignProp("", false, edtVisNegAssunto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVisNegAssunto_Enabled), 5, 0), true);
         edtVisNegCliNomeFamiliar_Enabled = 0;
         AssignProp("", false, edtVisNegCliNomeFamiliar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVisNegCliNomeFamiliar_Enabled), 5, 0), true);
         edtVisNegCpjNomFan_Enabled = 0;
         AssignProp("", false, edtVisNegCpjNomFan_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVisNegCpjNomFan_Enabled), 5, 0), true);
         edtVisNegValor_Enabled = 0;
         AssignProp("", false, edtVisNegValor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVisNegValor_Enabled), 5, 0), true);
         edtVisNgfIteNome_Enabled = 0;
         AssignProp("", false, edtVisNgfIteNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVisNgfIteNome_Enabled), 5, 0), true);
         edtVisPaiAssunto_Enabled = 0;
         AssignProp("", false, edtVisPaiAssunto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVisPaiAssunto_Enabled), 5, 0), true);
         edtVisPaiDataHora_Enabled = 0;
         AssignProp("", false, edtVisPaiDataHora_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVisPaiDataHora_Enabled), 5, 0), true);
         edtVisTipoID_Enabled = 0;
         AssignProp("", false, edtVisTipoID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVisTipoID_Enabled), 5, 0), true);
         edtVisData_Enabled = 0;
         AssignProp("", false, edtVisData_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVisData_Enabled), 5, 0), true);
         edtVisHora_Enabled = 0;
         AssignProp("", false, edtVisHora_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVisHora_Enabled), 5, 0), true);
         edtVisDataFim_Enabled = 0;
         AssignProp("", false, edtVisDataFim_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVisDataFim_Enabled), 5, 0), true);
         edtVisHoraFim_Enabled = 0;
         AssignProp("", false, edtVisHoraFim_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVisHoraFim_Enabled), 5, 0), true);
         edtVisAssunto_Enabled = 0;
         AssignProp("", false, edtVisAssunto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVisAssunto_Enabled), 5, 0), true);
         cmbVisSituacao.Enabled = 0;
         AssignProp("", false, cmbVisSituacao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbVisSituacao.Enabled), 5, 0), true);
         edtVisLink_Enabled = 0;
         AssignProp("", false, edtVisLink_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVisLink_Enabled), 5, 0), true);
         edtavCombovistipoid_Enabled = 0;
         AssignProp("", false, edtavCombovistipoid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombovistipoid_Enabled), 5, 0), true);
         edtavVispaiid_Enabled = 0;
         AssignProp("", false, edtavVispaiid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavVispaiid_Enabled), 5, 0), true);
         edtVisDataHoraFim_Enabled = 0;
         AssignProp("", false, edtVisDataHoraFim_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVisDataHoraFim_Enabled), 5, 0), true);
         edtVisDataHora_Enabled = 0;
         AssignProp("", false, edtVisDataHora_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVisDataHora_Enabled), 5, 0), true);
         edtVisPaiID_Enabled = 0;
         AssignProp("", false, edtVisPaiID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVisPaiID_Enabled), 5, 0), true);
         Visdescricao_Enabled = Convert.ToBoolean( 0);
         AssignProp("", false, Visdescricao_Internalname, "Enabled", StringUtil.BoolToStr( Visdescricao_Enabled), true);
      }

      protected void send_integrity_lvl_hashes1440( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_vVISPAIID", GetSecureSignedToken( "", AV40VisPaiID, context));
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues140( )
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("CKEditor/ckeditor/ckeditor.js", "", false, true);
         context.AddJavascriptSource("CKEditor/CKEditorRender.js", "", false, true);
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
         GXEncryptionTmp = "core.visita.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV7VisID.ToString()) + "," + UrlEncode(AV40VisPaiID.ToString()) + "," + UrlEncode(A418VisNegID.ToString()) + "," + UrlEncode(StringUtil.LTrimStr(A422VisNgfSeq,8,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("core.visita.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vVISPAIID", GetSecureSignedToken( "", AV40VisPaiID, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"Visita");
         forbiddenHiddens.Add("VisSituacao", StringUtil.RTrim( context.localUtil.Format( A472VisSituacao, "")));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("Pgmname", StringUtil.RTrim( context.localUtil.Format( AV46Pgmname, "")));
         forbiddenHiddens.Add("VisUpdData", context.localUtil.Format(A482VisUpdData, "99/99/99"));
         forbiddenHiddens.Add("VisUpdHora", context.localUtil.Format( A483VisUpdHora, "99:99"));
         forbiddenHiddens.Add("VisUpdDataHora", context.localUtil.Format( A484VisUpdDataHora, "99/99/9999 99:99:99.999"));
         forbiddenHiddens.Add("VisUpdUsuID", StringUtil.RTrim( context.localUtil.Format( A485VisUpdUsuID, "")));
         forbiddenHiddens.Add("VisUpdUsuNome", StringUtil.RTrim( context.localUtil.Format( A486VisUpdUsuNome, "@!")));
         forbiddenHiddens.Add("VisDel", StringUtil.BoolToStr( A487VisDel));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("core\\visita:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z398VisID", Z398VisID.ToString());
         GxWebStd.gx_hidden_field( context, "Z401VisInsDataHora", context.localUtil.TToC( Z401VisInsDataHora, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z399VisInsData", context.localUtil.DToC( Z399VisInsData, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z400VisInsHora", context.localUtil.TToC( Z400VisInsHora, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z402VisInsUsuID", StringUtil.RTrim( Z402VisInsUsuID));
         GxWebStd.gx_hidden_field( context, "Z403VisInsUsuNome", Z403VisInsUsuNome);
         GxWebStd.gx_hidden_field( context, "Z490VisDelDataHora", context.localUtil.TToC( Z490VisDelDataHora, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z488VisDelData", context.localUtil.TToC( Z488VisDelData, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z489VisDelHora", context.localUtil.TToC( Z489VisDelHora, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z491VisDelUsuID", StringUtil.RTrim( Z491VisDelUsuID));
         GxWebStd.gx_hidden_field( context, "Z492VisDelUsuNome", Z492VisDelUsuNome);
         GxWebStd.gx_hidden_field( context, "Z482VisUpdData", context.localUtil.DToC( Z482VisUpdData, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z483VisUpdHora", context.localUtil.TToC( Z483VisUpdHora, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z484VisUpdDataHora", context.localUtil.TToC( Z484VisUpdDataHora, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z485VisUpdUsuID", StringUtil.RTrim( Z485VisUpdUsuID));
         GxWebStd.gx_hidden_field( context, "Z486VisUpdUsuNome", Z486VisUpdUsuNome);
         GxWebStd.gx_hidden_field( context, "Z404VisData", context.localUtil.DToC( Z404VisData, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z405VisHora", context.localUtil.TToC( Z405VisHora, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z406VisDataHora", context.localUtil.TToC( Z406VisDataHora, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z475VisDataFim", context.localUtil.DToC( Z475VisDataFim, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z476VisHoraFim", context.localUtil.TToC( Z476VisHoraFim, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z477VisDataHoraFim", context.localUtil.TToC( Z477VisDataHoraFim, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z409VisAssunto", Z409VisAssunto);
         GxWebStd.gx_hidden_field( context, "Z417VisLink", Z417VisLink);
         GxWebStd.gx_hidden_field( context, "Z472VisSituacao", Z472VisSituacao);
         GxWebStd.gx_boolean_hidden_field( context, "Z487VisDel", Z487VisDel);
         GxWebStd.gx_hidden_field( context, "Z414VisTipoID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z414VisTipoID), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z419VisPaiID", Z419VisPaiID.ToString());
         GxWebStd.gx_boolean_hidden_field( context, "O487VisDel", O487VisDel);
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N419VisPaiID", A419VisPaiID.ToString());
         GxWebStd.gx_hidden_field( context, "N414VisTipoID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A414VisTipoID), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N418VisNegID", A418VisNegID.ToString());
         GxWebStd.gx_hidden_field( context, "N422VisNgfSeq", StringUtil.LTrim( StringUtil.NToC( (decimal)(A422VisNgfSeq), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vVISTIPOID_DATA", AV26VisTipoID_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vVISTIPOID_DATA", AV26VisTipoID_Data);
         }
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vVISID", AV7VisID.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vVISID", GetSecureSignedToken( "", AV7VisID, context));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "VISID", A398VisID.ToString());
         GxWebStd.gx_hidden_field( context, "vINSERT_VISPAIID", AV13Insert_VisPaiID.ToString());
         GxWebStd.gx_hidden_field( context, "vINSERT_VISTIPOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14Insert_VisTipoID), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_VISNEGID", AV15Insert_VisNegID.ToString());
         GxWebStd.gx_hidden_field( context, "VISNEGID", A418VisNegID.ToString());
         GxWebStd.gx_hidden_field( context, "vINSERT_VISNGFSEQ", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16Insert_VisNgfSeq), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "VISNGFSEQ", StringUtil.LTrim( StringUtil.NToC( (decimal)(A422VisNgfSeq), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "VISINSDATAHORA", context.localUtil.TToC( A401VisInsDataHora, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "VISINSDATA", context.localUtil.DToC( A399VisInsData, 0, "/"));
         GxWebStd.gx_hidden_field( context, "VISINSHORA", context.localUtil.TToC( A400VisInsHora, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "VISINSUSUID", StringUtil.RTrim( A402VisInsUsuID));
         GxWebStd.gx_hidden_field( context, "VISINSUSUNOME", A403VisInsUsuNome);
         GxWebStd.gx_boolean_hidden_field( context, "VISDEL", A487VisDel);
         GxWebStd.gx_hidden_field( context, "VISDELDATAHORA", context.localUtil.TToC( A490VisDelDataHora, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "VISDELDATA", context.localUtil.TToC( A488VisDelData, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "VISDELHORA", context.localUtil.TToC( A489VisDelHora, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "VISDELUSUID", StringUtil.RTrim( A491VisDelUsuID));
         GxWebStd.gx_hidden_field( context, "VISDELUSUNOME", A492VisDelUsuNome);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAUDITINGOBJECT", AV43AuditingObject);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAUDITINGOBJECT", AV43AuditingObject);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMESSAGES", AV44Messages);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMESSAGES", AV44Messages);
         }
         GxWebStd.gx_hidden_field( context, "VISUPDDATA", context.localUtil.DToC( A482VisUpdData, 0, "/"));
         GxWebStd.gx_hidden_field( context, "VISUPDHORA", context.localUtil.TToC( A483VisUpdHora, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "VISUPDDATAHORA", context.localUtil.TToC( A484VisUpdDataHora, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "VISUPDUSUID", StringUtil.RTrim( A485VisUpdUsuID));
         GxWebStd.gx_hidden_field( context, "VISUPDUSUNOME", A486VisUpdUsuNome);
         GxWebStd.gx_hidden_field( context, "VISDESCRICAO", A410VisDescricao);
         GxWebStd.gx_hidden_field( context, "VISTIPOSIGLA", A415VisTipoSigla);
         GxWebStd.gx_hidden_field( context, "VISTIPONOME", A416VisTipoNome);
         GxWebStd.gx_hidden_field( context, "VISNEGCLIID", A407VisNegCliID.ToString());
         GxWebStd.gx_hidden_field( context, "VISNEGCPJID", A408VisNegCpjID.ToString());
         GxWebStd.gx_hidden_field( context, "VISNGFITEID", A423VisNgfIteID.ToString());
         GxWebStd.gx_hidden_field( context, "VISPAIDATA", context.localUtil.DToC( A460VisPaiData, 0, "/"));
         GxWebStd.gx_hidden_field( context, "VISPAIHORA", context.localUtil.TToC( A461VisPaiHora, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "VISNEGCPJRAZSOCIAL", A471VisNegCpjRazSocial);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV46Pgmname));
         GxWebStd.gx_hidden_field( context, "COMBO_VISTIPOID_Objectcall", StringUtil.RTrim( Combo_vistipoid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_VISTIPOID_Cls", StringUtil.RTrim( Combo_vistipoid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_VISTIPOID_Selectedvalue_set", StringUtil.RTrim( Combo_vistipoid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_VISTIPOID_Enabled", StringUtil.BoolToStr( Combo_vistipoid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_VISTIPOID_Includeaddnewoption", StringUtil.BoolToStr( Combo_vistipoid_Includeaddnewoption));
         GxWebStd.gx_hidden_field( context, "COMBO_VISTIPOID_Emptyitemtext", StringUtil.RTrim( Combo_vistipoid_Emptyitemtext));
         GxWebStd.gx_hidden_field( context, "VISDESCRICAO_Objectcall", StringUtil.RTrim( Visdescricao_Objectcall));
         GxWebStd.gx_hidden_field( context, "VISDESCRICAO_Enabled", StringUtil.BoolToStr( Visdescricao_Enabled));
         GxWebStd.gx_hidden_field( context, "VISDESCRICAO_Width", StringUtil.RTrim( Visdescricao_Width));
         GxWebStd.gx_hidden_field( context, "VISDESCRICAO_Height", StringUtil.RTrim( Visdescricao_Height));
         GxWebStd.gx_hidden_field( context, "VISDESCRICAO_Skin", StringUtil.RTrim( Visdescricao_Skin));
         GxWebStd.gx_hidden_field( context, "VISDESCRICAO_Toolbar", StringUtil.RTrim( Visdescricao_Toolbar));
         GxWebStd.gx_hidden_field( context, "VISDESCRICAO_Color", StringUtil.LTrim( StringUtil.NToC( (decimal)(Visdescricao_Color), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "VISDESCRICAO_Captionclass", StringUtil.RTrim( Visdescricao_Captionclass));
         GxWebStd.gx_hidden_field( context, "VISDESCRICAO_Captionstyle", StringUtil.RTrim( Visdescricao_Captionstyle));
         GxWebStd.gx_hidden_field( context, "VISDESCRICAO_Captionposition", StringUtil.RTrim( Visdescricao_Captionposition));
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
         GXEncryptionTmp = "core.visita.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV7VisID.ToString()) + "," + UrlEncode(AV40VisPaiID.ToString()) + "," + UrlEncode(A418VisNegID.ToString()) + "," + UrlEncode(StringUtil.LTrimStr(A422VisNgfSeq,8,0));
         return formatLink("core.visita.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "core.Visita" ;
      }

      public override string GetPgmdesc( )
      {
         return "Visita" ;
      }

      protected void InitializeNonKey1440( )
      {
         A414VisTipoID = 0;
         AssignAttri("", false, "A414VisTipoID", StringUtil.LTrimStr( (decimal)(A414VisTipoID), 9, 0));
         AV43AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
         A401VisInsDataHora = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A401VisInsDataHora", context.localUtil.TToC( A401VisInsDataHora, 10, 12, 0, 3, "/", ":", " "));
         A399VisInsData = DateTime.MinValue;
         AssignAttri("", false, "A399VisInsData", context.localUtil.Format(A399VisInsData, "99/99/99"));
         A400VisInsHora = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A400VisInsHora", context.localUtil.TToC( A400VisInsHora, 0, 5, 0, 3, "/", ":", " "));
         A402VisInsUsuID = "";
         n402VisInsUsuID = false;
         AssignAttri("", false, "A402VisInsUsuID", A402VisInsUsuID);
         A403VisInsUsuNome = "";
         n403VisInsUsuNome = false;
         AssignAttri("", false, "A403VisInsUsuNome", A403VisInsUsuNome);
         AV44Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         A490VisDelDataHora = (DateTime)(DateTime.MinValue);
         n490VisDelDataHora = false;
         AssignAttri("", false, "A490VisDelDataHora", context.localUtil.TToC( A490VisDelDataHora, 10, 12, 0, 3, "/", ":", " "));
         A488VisDelData = (DateTime)(DateTime.MinValue);
         n488VisDelData = false;
         AssignAttri("", false, "A488VisDelData", context.localUtil.TToC( A488VisDelData, 10, 5, 0, 3, "/", ":", " "));
         A489VisDelHora = (DateTime)(DateTime.MinValue);
         n489VisDelHora = false;
         AssignAttri("", false, "A489VisDelHora", context.localUtil.TToC( A489VisDelHora, 0, 5, 0, 3, "/", ":", " "));
         A491VisDelUsuID = "";
         n491VisDelUsuID = false;
         AssignAttri("", false, "A491VisDelUsuID", A491VisDelUsuID);
         A492VisDelUsuNome = "";
         n492VisDelUsuNome = false;
         AssignAttri("", false, "A492VisDelUsuNome", A492VisDelUsuNome);
         A460VisPaiData = DateTime.MinValue;
         AssignAttri("", false, "A460VisPaiData", context.localUtil.Format(A460VisPaiData, "99/99/99"));
         A461VisPaiHora = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A461VisPaiHora", context.localUtil.TToC( A461VisPaiHora, 0, 5, 0, 3, "/", ":", " "));
         A462VisPaiDataHora = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A462VisPaiDataHora", context.localUtil.TToC( A462VisPaiDataHora, 10, 5, 0, 3, "/", ":", " "));
         A465VisPaiAssunto = "";
         AssignAttri("", false, "A465VisPaiAssunto", A465VisPaiAssunto);
         A482VisUpdData = DateTime.MinValue;
         n482VisUpdData = false;
         AssignAttri("", false, "A482VisUpdData", context.localUtil.Format(A482VisUpdData, "99/99/99"));
         A483VisUpdHora = (DateTime)(DateTime.MinValue);
         n483VisUpdHora = false;
         AssignAttri("", false, "A483VisUpdHora", context.localUtil.TToC( A483VisUpdHora, 0, 5, 0, 3, "/", ":", " "));
         A484VisUpdDataHora = (DateTime)(DateTime.MinValue);
         n484VisUpdDataHora = false;
         AssignAttri("", false, "A484VisUpdDataHora", context.localUtil.TToC( A484VisUpdDataHora, 10, 12, 0, 3, "/", ":", " "));
         A485VisUpdUsuID = "";
         n485VisUpdUsuID = false;
         AssignAttri("", false, "A485VisUpdUsuID", A485VisUpdUsuID);
         A486VisUpdUsuNome = "";
         n486VisUpdUsuNome = false;
         AssignAttri("", false, "A486VisUpdUsuNome", A486VisUpdUsuNome);
         A404VisData = DateTime.MinValue;
         AssignAttri("", false, "A404VisData", context.localUtil.Format(A404VisData, "99/99/99"));
         A405VisHora = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A405VisHora", context.localUtil.TToC( A405VisHora, 0, 5, 0, 3, "/", ":", " "));
         A406VisDataHora = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A406VisDataHora", context.localUtil.TToC( A406VisDataHora, 10, 5, 0, 3, "/", ":", " "));
         A477VisDataHoraFim = (DateTime)(DateTime.MinValue);
         n477VisDataHoraFim = false;
         AssignAttri("", false, "A477VisDataHoraFim", context.localUtil.TToC( A477VisDataHoraFim, 10, 5, 0, 3, "/", ":", " "));
         n477VisDataHoraFim = ((DateTime.MinValue==A477VisDataHoraFim) ? true : false);
         A415VisTipoSigla = "";
         AssignAttri("", false, "A415VisTipoSigla", A415VisTipoSigla);
         A416VisTipoNome = "";
         AssignAttri("", false, "A416VisTipoNome", A416VisTipoNome);
         A409VisAssunto = "";
         AssignAttri("", false, "A409VisAssunto", A409VisAssunto);
         A410VisDescricao = "";
         n410VisDescricao = false;
         AssignAttri("", false, "A410VisDescricao", A410VisDescricao);
         A417VisLink = "";
         n417VisLink = false;
         AssignAttri("", false, "A417VisLink", A417VisLink);
         n417VisLink = (String.IsNullOrEmpty(StringUtil.RTrim( A417VisLink)) ? true : false);
         A487VisDel = false;
         AssignAttri("", false, "A487VisDel", A487VisDel);
         A419VisPaiID = new GeneXus.Programs.core.prcretvispaiid(context).executeUdp(  AV40VisPaiID);
         n419VisPaiID = false;
         AssignAttri("", false, "A419VisPaiID", A419VisPaiID.ToString());
         A475VisDataFim = DateTimeUtil.ResetTime( DateTimeUtil.TAdd( A406VisDataHora, 60*(30)));
         n475VisDataFim = false;
         AssignAttri("", false, "A475VisDataFim", context.localUtil.Format(A475VisDataFim, "99/99/99"));
         A476VisHoraFim = DateTimeUtil.ResetTime( DateTimeUtil.ResetTime( DateTimeUtil.TAdd( A406VisDataHora, 60*(30))) ) ;
         n476VisHoraFim = false;
         AssignAttri("", false, "A476VisHoraFim", context.localUtil.TToC( A476VisHoraFim, 0, 5, 0, 3, "/", ":", " "));
         A472VisSituacao = "PEN";
         AssignAttri("", false, "A472VisSituacao", A472VisSituacao);
         O487VisDel = A487VisDel;
         AssignAttri("", false, "A487VisDel", A487VisDel);
         Z401VisInsDataHora = (DateTime)(DateTime.MinValue);
         Z399VisInsData = DateTime.MinValue;
         Z400VisInsHora = (DateTime)(DateTime.MinValue);
         Z402VisInsUsuID = "";
         Z403VisInsUsuNome = "";
         Z490VisDelDataHora = (DateTime)(DateTime.MinValue);
         Z488VisDelData = (DateTime)(DateTime.MinValue);
         Z489VisDelHora = (DateTime)(DateTime.MinValue);
         Z491VisDelUsuID = "";
         Z492VisDelUsuNome = "";
         Z482VisUpdData = DateTime.MinValue;
         Z483VisUpdHora = (DateTime)(DateTime.MinValue);
         Z484VisUpdDataHora = (DateTime)(DateTime.MinValue);
         Z485VisUpdUsuID = "";
         Z486VisUpdUsuNome = "";
         Z404VisData = DateTime.MinValue;
         Z405VisHora = (DateTime)(DateTime.MinValue);
         Z406VisDataHora = (DateTime)(DateTime.MinValue);
         Z475VisDataFim = DateTime.MinValue;
         Z476VisHoraFim = (DateTime)(DateTime.MinValue);
         Z477VisDataHoraFim = (DateTime)(DateTime.MinValue);
         Z409VisAssunto = "";
         Z417VisLink = "";
         Z472VisSituacao = "";
         Z487VisDel = false;
         Z414VisTipoID = 0;
         Z419VisPaiID = Guid.Empty;
      }

      protected void InitAll1440( )
      {
         A398VisID = Guid.NewGuid( );
         AssignAttri("", false, "A398VisID", A398VisID.ToString());
         InitializeNonKey1440( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A419VisPaiID = i419VisPaiID;
         n419VisPaiID = false;
         AssignAttri("", false, "A419VisPaiID", A419VisPaiID.ToString());
         A472VisSituacao = i472VisSituacao;
         AssignAttri("", false, "A472VisSituacao", A472VisSituacao);
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2023828155372", true, true);
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
         context.AddJavascriptSource("core/visita.js", "?2023828155376", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("CKEditor/ckeditor/ckeditor.js", "", false, true);
         context.AddJavascriptSource("CKEditor/CKEditorRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtVisNegCodigo_Internalname = "VISNEGCODIGO";
         edtVisNegAssunto_Internalname = "VISNEGASSUNTO";
         edtVisNegCliNomeFamiliar_Internalname = "VISNEGCLINOMEFAMILIAR";
         edtVisNegCpjNomFan_Internalname = "VISNEGCPJNOMFAN";
         edtVisNegValor_Internalname = "VISNEGVALOR";
         edtVisNgfIteNome_Internalname = "VISNGFITENOME";
         lblTxtesp01_Internalname = "TXTESP01";
         edtVisPaiAssunto_Internalname = "VISPAIASSUNTO";
         edtVisPaiDataHora_Internalname = "VISPAIDATAHORA";
         divTablevisitaorigem_Internalname = "TABLEVISITAORIGEM";
         grpTablegroupvisitaorigem_Internalname = "TABLEGROUPVISITAORIGEM";
         lblTextblockvistipoid_Internalname = "TEXTBLOCKVISTIPOID";
         Combo_vistipoid_Internalname = "COMBO_VISTIPOID";
         edtVisTipoID_Internalname = "VISTIPOID";
         divTablesplittedvistipoid_Internalname = "TABLESPLITTEDVISTIPOID";
         edtVisData_Internalname = "VISDATA";
         edtVisHora_Internalname = "VISHORA";
         divTxtdatahorainicio_Internalname = "TXTDATAHORAINICIO";
         grpUnnamedgroup1_Internalname = "UNNAMEDGROUP1";
         edtVisDataFim_Internalname = "VISDATAFIM";
         edtVisHoraFim_Internalname = "VISHORAFIM";
         divTxtdatahoratermino_Internalname = "TXTDATAHORATERMINO";
         grpUnnamedgroup2_Internalname = "UNNAMEDGROUP2";
         edtVisAssunto_Internalname = "VISASSUNTO";
         cmbVisSituacao_Internalname = "VISSITUACAO";
         edtVisLink_Internalname = "VISLINK";
         Visdescricao_Internalname = "VISDESCRICAO";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         divTablemain_Internalname = "TABLEMAIN";
         edtavCombovistipoid_Internalname = "vCOMBOVISTIPOID";
         divSectionattribute_vistipoid_Internalname = "SECTIONATTRIBUTE_VISTIPOID";
         edtavVispaiid_Internalname = "vVISPAIID";
         edtavVisnegid_Internalname = "vVISNEGID";
         edtavVisngfseq_Internalname = "vVISNGFSEQ";
         edtVisDataHoraFim_Internalname = "VISDATAHORAFIM";
         edtVisDataHora_Internalname = "VISDATAHORA";
         edtVisPaiID_Internalname = "VISPAIID";
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
         Form.Caption = "Visita";
         edtVisPaiID_Jsonclick = "";
         edtVisPaiID_Enabled = 1;
         edtVisPaiID_Visible = 1;
         edtVisDataHora_Jsonclick = "";
         edtVisDataHora_Enabled = 1;
         edtVisDataHora_Visible = 1;
         edtVisDataHoraFim_Jsonclick = "";
         edtVisDataHoraFim_Enabled = 1;
         edtVisDataHoraFim_Visible = 1;
         edtavVisngfseq_Jsonclick = "";
         edtavVisngfseq_Enabled = 0;
         edtavVisngfseq_Visible = 1;
         edtavVisnegid_Jsonclick = "";
         edtavVisnegid_Enabled = 0;
         edtavVisnegid_Visible = 1;
         edtavVispaiid_Jsonclick = "";
         edtavVispaiid_Enabled = 0;
         edtavVispaiid_Visible = 1;
         edtavCombovistipoid_Jsonclick = "";
         edtavCombovistipoid_Enabled = 0;
         edtavCombovistipoid_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         Visdescricao_Captionposition = "None";
         Visdescricao_Captionstyle = "";
         Visdescricao_Captionclass = "col-sm-3 AttributeLabel";
         Visdescricao_Color = (int)(0xD3D3D3);
         Visdescricao_Toolbar = "Default";
         Visdescricao_Skin = "silver";
         Visdescricao_Height = "350";
         Visdescricao_Width = "100%";
         Visdescricao_Enabled = Convert.ToBoolean( 1);
         edtVisLink_Jsonclick = "";
         edtVisLink_Enabled = 1;
         cmbVisSituacao_Jsonclick = "";
         cmbVisSituacao.Enabled = 0;
         edtVisAssunto_Jsonclick = "";
         edtVisAssunto_Enabled = 1;
         edtVisHoraFim_Jsonclick = "";
         edtVisHoraFim_Enabled = 1;
         edtVisDataFim_Jsonclick = "";
         edtVisDataFim_Enabled = 1;
         edtVisHora_Jsonclick = "";
         edtVisHora_Enabled = 1;
         edtVisData_Jsonclick = "";
         edtVisData_Enabled = 1;
         edtVisTipoID_Jsonclick = "";
         edtVisTipoID_Enabled = 1;
         edtVisTipoID_Visible = 1;
         Combo_vistipoid_Emptyitemtext = "";
         Combo_vistipoid_Includeaddnewoption = Convert.ToBoolean( -1);
         Combo_vistipoid_Cls = "ExtendedCombo AttributeFL";
         Combo_vistipoid_Enabled = Convert.ToBoolean( -1);
         edtVisPaiDataHora_Jsonclick = "";
         edtVisPaiDataHora_Enabled = 0;
         edtVisPaiAssunto_Jsonclick = "";
         edtVisPaiAssunto_Enabled = 0;
         grpTablegroupvisitaorigem_Class = "Group";
         edtVisNgfIteNome_Jsonclick = "";
         edtVisNgfIteNome_Enabled = 0;
         edtVisNegValor_Jsonclick = "";
         edtVisNegValor_Enabled = 0;
         edtVisNegCpjNomFan_Jsonclick = "";
         edtVisNegCpjNomFan_Enabled = 0;
         edtVisNegCliNomeFamiliar_Jsonclick = "";
         edtVisNegCliNomeFamiliar_Enabled = 0;
         edtVisNegAssunto_Jsonclick = "";
         edtVisNegAssunto_Enabled = 0;
         edtVisNegCodigo_Jsonclick = "";
         edtVisNegCodigo_Enabled = 0;
         Dvpanel_tableattributes_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Iconposition = "Right";
         Dvpanel_tableattributes_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Title = "Dados da Visita";
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

      protected void GX13ASAVISPAIID1440( Guid AV13Insert_VisPaiID ,
                                          Guid AV40VisPaiID ,
                                          short Gx_BScreen )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV13Insert_VisPaiID) )
         {
            A419VisPaiID = AV13Insert_VisPaiID;
            n419VisPaiID = false;
            AssignAttri("", false, "A419VisPaiID", A419VisPaiID.ToString());
         }
         else
         {
            if ( IsIns( )  && (Guid.Empty==A419VisPaiID) && ( Gx_BScreen == 0 ) )
            {
               GXt_guid3 = A419VisPaiID;
               new GeneXus.Programs.core.prcretvispaiid(context ).execute(  AV40VisPaiID, out  GXt_guid3) ;
               A419VisPaiID = GXt_guid3;
               n419VisPaiID = false;
               AssignAttri("", false, "A419VisPaiID", A419VisPaiID.ToString());
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A419VisPaiID.ToString())+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_46_1440( GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV43AuditingObject ,
                                 Guid A398VisID ,
                                 string Gx_mode )
      {
         new GeneXus.Programs.core.loadauditvisita(context ).execute(  "Y", ref  AV43AuditingObject,  A398VisID,  Gx_mode) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.EncodeString( AV43AuditingObject.ToXml(false, true, "", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_47_1440( GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV43AuditingObject ,
                                 Guid A398VisID ,
                                 string Gx_mode )
      {
         new GeneXus.Programs.core.loadauditvisita(context ).execute(  "Y", ref  AV43AuditingObject,  A398VisID,  Gx_mode) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.EncodeString( AV43AuditingObject.ToXml(false, true, "", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_48_1440( string Gx_mode ,
                                 GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV43AuditingObject ,
                                 Guid A398VisID )
      {
         if ( IsIns( )  )
         {
            new GeneXus.Programs.core.loadauditvisita(context ).execute(  "N", ref  AV43AuditingObject,  A398VisID,  Gx_mode) ;
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.EncodeString( AV43AuditingObject.ToXml(false, true, "", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_49_1440( string Gx_mode ,
                                 GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV43AuditingObject ,
                                 Guid A398VisID )
      {
         if ( IsUpd( )  )
         {
            new GeneXus.Programs.core.loadauditvisita(context ).execute(  "N", ref  AV43AuditingObject,  A398VisID,  Gx_mode) ;
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.EncodeString( AV43AuditingObject.ToXml(false, true, "", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_51_1440( )
      {
         if ( ! (Guid.Empty==AV40VisPaiID) )
         {
            new GeneXus.Programs.core.prcvisitaremarcada(context ).execute(  AV40VisPaiID,  false,  new GeneXus.Programs.genexussecurity.SdtGAMUser(context).get(), out  AV44Messages) ;
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
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
         cmbVisSituacao.Name = "VISSITUACAO";
         cmbVisSituacao.WebTags = "";
         cmbVisSituacao.addItem("", " ", 0);
         cmbVisSituacao.addItem("PEN", "Pendente", 0);
         cmbVisSituacao.addItem("REA", "Realizada", 0);
         cmbVisSituacao.addItem("REM", "Remarcada", 0);
         cmbVisSituacao.addItem("CAN", "Cancelada", 0);
         if ( cmbVisSituacao.ItemCount > 0 )
         {
            if ( IsIns( ) && String.IsNullOrEmpty(StringUtil.RTrim( A472VisSituacao)) )
            {
               A472VisSituacao = "PEN";
               AssignAttri("", false, "A472VisSituacao", A472VisSituacao);
            }
         }
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

      public void Valid_Vistipoid( )
      {
         /* Using cursor T001421 */
         pr_default.execute(19, new Object[] {A414VisTipoID});
         if ( (pr_default.getStatus(19) == 101) )
         {
            GX_msglist.addItem("Não existe 'Tipo de Visita'.", "ForeignKeyNotFound", 1, "VISTIPOID");
            AnyError = 1;
            GX_FocusControl = edtVisTipoID_Internalname;
         }
         A415VisTipoSigla = T001421_A415VisTipoSigla[0];
         A416VisTipoNome = T001421_A416VisTipoNome[0];
         pr_default.close(19);
         if ( (0==A414VisTipoID) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "ID do Tipo da Visita", "", "", "", "", "", "", "", ""), 1, "VISTIPOID");
            AnyError = 1;
            GX_FocusControl = edtVisTipoID_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A415VisTipoSigla", A415VisTipoSigla);
         AssignAttri("", false, "A416VisTipoNome", A416VisTipoNome);
      }

      public void Valid_Visdatahora( )
      {
         n475VisDataFim = false;
         n476VisHoraFim = false;
         n477VisDataHoraFim = false;
         if ( IsIns( )  && (DateTime.MinValue==A475VisDataFim) && ( Gx_BScreen == 0 ) )
         {
            A475VisDataFim = DateTimeUtil.ResetTime( DateTimeUtil.TAdd( A406VisDataHora, 60*(30)));
            n475VisDataFim = false;
         }
         if ( (DateTime.MinValue==A475VisDataFim) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Data de Término da Visita", "", "", "", "", "", "", "", ""), 1, "VISDATAHORA");
            AnyError = 1;
            GX_FocusControl = edtVisDataHora_Internalname;
         }
         if ( IsIns( )  && (DateTime.MinValue==A476VisHoraFim) && ( Gx_BScreen == 0 ) )
         {
            A476VisHoraFim = DateTimeUtil.ResetTime( DateTimeUtil.ResetTime( DateTimeUtil.TAdd( A406VisDataHora, 60*(30))) ) ;
            n476VisHoraFim = false;
         }
         if ( true /* After */ )
         {
            A477VisDataHoraFim = context.localUtil.YMDHMSToT( (short)(DateTimeUtil.Year( A475VisDataFim)), (short)(DateTimeUtil.Month( A475VisDataFim)), (short)(DateTimeUtil.Day( A475VisDataFim)), (short)(DateTimeUtil.Hour( A476VisHoraFim)), (short)(DateTimeUtil.Minute( A476VisHoraFim)), 0);
            n477VisDataHoraFim = false;
         }
         if ( A476VisHoraFim == DateTime.MinValue )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Hora de Término da Hora", "", "", "", "", "", "", "", ""), 1, "VISDATAHORA");
            AnyError = 1;
            GX_FocusControl = edtVisDataHora_Internalname;
         }
         if ( true /* After */ && ( A477VisDataHoraFim < A406VisDataHora ) )
         {
            GX_msglist.addItem("A data e hora de término da visita não pode ser anterior à data e hora de início da visita", 1, "VISDATAHORA");
            AnyError = 1;
            GX_FocusControl = edtVisDataHora_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A475VisDataFim", context.localUtil.Format(A475VisDataFim, "99/99/99"));
         AssignAttri("", false, "A476VisHoraFim", context.localUtil.TToC( A476VisHoraFim, 10, 8, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A477VisDataHoraFim", context.localUtil.TToC( A477VisDataHoraFim, 10, 8, 0, 3, "/", ":", " "));
      }

      public void Valid_Vispaiid( )
      {
         n419VisPaiID = false;
         /* Using cursor T001420 */
         pr_default.execute(18, new Object[] {n419VisPaiID, A419VisPaiID});
         if ( (pr_default.getStatus(18) == 101) )
         {
            if ( ! ( (Guid.Empty==A419VisPaiID) ) )
            {
               GX_msglist.addItem("Não existe 'Visita Origem'.", "ForeignKeyNotFound", 1, "VISPAIID");
               AnyError = 1;
               GX_FocusControl = edtVisPaiID_Internalname;
            }
         }
         A460VisPaiData = T001420_A460VisPaiData[0];
         A461VisPaiHora = T001420_A461VisPaiHora[0];
         A462VisPaiDataHora = T001420_A462VisPaiDataHora[0];
         A465VisPaiAssunto = T001420_A465VisPaiAssunto[0];
         pr_default.close(18);
         O487VisDel = A487VisDel;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A460VisPaiData", context.localUtil.Format(A460VisPaiData, "99/99/99"));
         AssignAttri("", false, "A461VisPaiHora", context.localUtil.TToC( A461VisPaiHora, 10, 8, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A462VisPaiDataHora", context.localUtil.TToC( A462VisPaiDataHora, 10, 8, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A465VisPaiAssunto", A465VisPaiAssunto);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7VisID',fld:'vVISID',pic:'',hsh:true},{av:'AV40VisPaiID',fld:'vVISPAIID',pic:'',hsh:true},{av:'A418VisNegID',fld:'VISNEGID',pic:''},{av:'A422VisNgfSeq',fld:'VISNGFSEQ',pic:'ZZ,ZZZ,ZZ9'}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7VisID',fld:'vVISID',pic:'',hsh:true},{av:'AV40VisPaiID',fld:'vVISPAIID',pic:'',hsh:true},{av:'cmbVisSituacao'},{av:'A472VisSituacao',fld:'VISSITUACAO',pic:''},{av:'AV46Pgmname',fld:'vPGMNAME',pic:''},{av:'A482VisUpdData',fld:'VISUPDDATA',pic:''},{av:'A483VisUpdHora',fld:'VISUPDHORA',pic:'99:99'},{av:'A484VisUpdDataHora',fld:'VISUPDDATAHORA',pic:'99/99/9999 99:99:99.999'},{av:'A485VisUpdUsuID',fld:'VISUPDUSUID',pic:''},{av:'A486VisUpdUsuNome',fld:'VISUPDUSUNOME',pic:'@!'},{av:'A487VisDel',fld:'VISDEL',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E13142',iparms:[{av:'AV43AuditingObject',fld:'vAUDITINGOBJECT',pic:''},{av:'AV46Pgmname',fld:'vPGMNAME',pic:''}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("COMBO_VISTIPOID.ONOPTIONCLICKED","{handler:'E12142',iparms:[{av:'Combo_vistipoid_Selectedvalue_get',ctrl:'COMBO_VISTIPOID',prop:'SelectedValue_get'},{av:'A414VisTipoID',fld:'VISTIPOID',pic:'ZZZ,ZZZ,ZZ9'},{av:'AV7VisID',fld:'vVISID',pic:'',hsh:true}]");
         setEventMetadata("COMBO_VISTIPOID.ONOPTIONCLICKED",",oparms:[{av:'Combo_vistipoid_Selectedvalue_set',ctrl:'COMBO_VISTIPOID',prop:'SelectedValue_set'},{av:'AV26VisTipoID_Data',fld:'vVISTIPOID_DATA',pic:''},{av:'AV27ComboVisTipoID',fld:'vCOMBOVISTIPOID',pic:'ZZZ,ZZZ,ZZ9'}]}");
         setEventMetadata("VALID_VISTIPOID","{handler:'Valid_Vistipoid',iparms:[{av:'A414VisTipoID',fld:'VISTIPOID',pic:'ZZZ,ZZZ,ZZ9'},{av:'A415VisTipoSigla',fld:'VISTIPOSIGLA',pic:''},{av:'A416VisTipoNome',fld:'VISTIPONOME',pic:'@!'}]");
         setEventMetadata("VALID_VISTIPOID",",oparms:[{av:'A415VisTipoSigla',fld:'VISTIPOSIGLA',pic:''},{av:'A416VisTipoNome',fld:'VISTIPONOME',pic:'@!'}]}");
         setEventMetadata("VALID_VISDATA","{handler:'Valid_Visdata',iparms:[]");
         setEventMetadata("VALID_VISDATA",",oparms:[]}");
         setEventMetadata("VALID_VISHORA","{handler:'Valid_Vishora',iparms:[]");
         setEventMetadata("VALID_VISHORA",",oparms:[]}");
         setEventMetadata("VALID_VISDATAFIM","{handler:'Valid_Visdatafim',iparms:[]");
         setEventMetadata("VALID_VISDATAFIM",",oparms:[]}");
         setEventMetadata("VALID_VISHORAFIM","{handler:'Valid_Vishorafim',iparms:[]");
         setEventMetadata("VALID_VISHORAFIM",",oparms:[]}");
         setEventMetadata("VALID_VISASSUNTO","{handler:'Valid_Visassunto',iparms:[]");
         setEventMetadata("VALID_VISASSUNTO",",oparms:[]}");
         setEventMetadata("VALID_VISLINK","{handler:'Valid_Vislink',iparms:[]");
         setEventMetadata("VALID_VISLINK",",oparms:[]}");
         setEventMetadata("VALIDV_COMBOVISTIPOID","{handler:'Validv_Combovistipoid',iparms:[]");
         setEventMetadata("VALIDV_COMBOVISTIPOID",",oparms:[]}");
         setEventMetadata("VALIDV_VISPAIID","{handler:'Validv_Vispaiid',iparms:[]");
         setEventMetadata("VALIDV_VISPAIID",",oparms:[]}");
         setEventMetadata("VALID_VISDATAHORA","{handler:'Valid_Visdatahora',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'A406VisDataHora',fld:'VISDATAHORA',pic:'99/99/9999 99:99'},{av:'Gx_BScreen',fld:'vGXBSCREEN',pic:'9'},{av:'A475VisDataFim',fld:'VISDATAFIM',pic:''},{av:'A476VisHoraFim',fld:'VISHORAFIM',pic:'99:99'},{av:'A477VisDataHoraFim',fld:'VISDATAHORAFIM',pic:'99/99/9999 99:99'}]");
         setEventMetadata("VALID_VISDATAHORA",",oparms:[{av:'A475VisDataFim',fld:'VISDATAFIM',pic:''},{av:'A476VisHoraFim',fld:'VISHORAFIM',pic:'99:99'},{av:'A477VisDataHoraFim',fld:'VISDATAHORAFIM',pic:'99/99/9999 99:99'}]}");
         setEventMetadata("VALID_VISPAIID","{handler:'Valid_Vispaiid',iparms:[{av:'A487VisDel',fld:'VISDEL',pic:''},{av:'A419VisPaiID',fld:'VISPAIID',pic:''},{av:'A460VisPaiData',fld:'VISPAIDATA',pic:''},{av:'A461VisPaiHora',fld:'VISPAIHORA',pic:'99:99'},{av:'A462VisPaiDataHora',fld:'VISPAIDATAHORA',pic:'99/99/9999 99:99'},{av:'A465VisPaiAssunto',fld:'VISPAIASSUNTO',pic:''}]");
         setEventMetadata("VALID_VISPAIID",",oparms:[{av:'A460VisPaiData',fld:'VISPAIDATA',pic:''},{av:'A461VisPaiHora',fld:'VISPAIHORA',pic:'99:99'},{av:'A462VisPaiDataHora',fld:'VISPAIDATAHORA',pic:'99/99/9999 99:99'},{av:'A465VisPaiAssunto',fld:'VISPAIASSUNTO',pic:''}]}");
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
         pr_default.close(19);
         pr_default.close(18);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         wcpOAV7VisID = Guid.Empty;
         wcpOAV40VisPaiID = Guid.Empty;
         wcpOA418VisNegID = Guid.Empty;
         Z398VisID = Guid.Empty;
         Z401VisInsDataHora = (DateTime)(DateTime.MinValue);
         Z399VisInsData = DateTime.MinValue;
         Z400VisInsHora = (DateTime)(DateTime.MinValue);
         Z402VisInsUsuID = "";
         Z403VisInsUsuNome = "";
         Z490VisDelDataHora = (DateTime)(DateTime.MinValue);
         Z488VisDelData = (DateTime)(DateTime.MinValue);
         Z489VisDelHora = (DateTime)(DateTime.MinValue);
         Z491VisDelUsuID = "";
         Z492VisDelUsuNome = "";
         Z482VisUpdData = DateTime.MinValue;
         Z483VisUpdHora = (DateTime)(DateTime.MinValue);
         Z484VisUpdDataHora = (DateTime)(DateTime.MinValue);
         Z485VisUpdUsuID = "";
         Z486VisUpdUsuNome = "";
         Z404VisData = DateTime.MinValue;
         Z405VisHora = (DateTime)(DateTime.MinValue);
         Z406VisDataHora = (DateTime)(DateTime.MinValue);
         Z475VisDataFim = DateTime.MinValue;
         Z476VisHoraFim = (DateTime)(DateTime.MinValue);
         Z477VisDataHoraFim = (DateTime)(DateTime.MinValue);
         Z409VisAssunto = "";
         Z417VisLink = "";
         Z472VisSituacao = "";
         Z419VisPaiID = Guid.Empty;
         N419VisPaiID = Guid.Empty;
         Combo_vistipoid_Selectedvalue_get = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV13Insert_VisPaiID = Guid.Empty;
         A419VisPaiID = Guid.Empty;
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A472VisSituacao = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         A467VisNegAssunto = "";
         A469VisNegCliNomeFamiliar = "";
         A470VisNegCpjNomFan = "";
         A424VisNgfIteNome = "";
         lblTxtesp01_Jsonclick = "";
         A465VisPaiAssunto = "";
         A462VisPaiDataHora = (DateTime)(DateTime.MinValue);
         lblTextblockvistipoid_Jsonclick = "";
         ucCombo_vistipoid = new GXUserControl();
         Combo_vistipoid_Caption = "";
         AV26VisTipoID_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         TempTags = "";
         A404VisData = DateTime.MinValue;
         A405VisHora = (DateTime)(DateTime.MinValue);
         A475VisDataFim = DateTime.MinValue;
         A476VisHoraFim = (DateTime)(DateTime.MinValue);
         A409VisAssunto = "";
         A417VisLink = "";
         ucVisdescricao = new GXUserControl();
         VisDescricao = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         AV41VisNegID = Guid.Empty;
         A477VisDataHoraFim = (DateTime)(DateTime.MinValue);
         A406VisDataHora = (DateTime)(DateTime.MinValue);
         A402VisInsUsuID = "";
         A403VisInsUsuNome = "";
         A490VisDelDataHora = (DateTime)(DateTime.MinValue);
         A488VisDelData = (DateTime)(DateTime.MinValue);
         A489VisDelHora = (DateTime)(DateTime.MinValue);
         A491VisDelUsuID = "";
         A492VisDelUsuNome = "";
         A482VisUpdData = DateTime.MinValue;
         A483VisUpdHora = (DateTime)(DateTime.MinValue);
         A484VisUpdDataHora = (DateTime)(DateTime.MinValue);
         A485VisUpdUsuID = "";
         A486VisUpdUsuNome = "";
         A401VisInsDataHora = (DateTime)(DateTime.MinValue);
         A399VisInsData = DateTime.MinValue;
         A400VisInsHora = (DateTime)(DateTime.MinValue);
         A398VisID = Guid.Empty;
         AV15Insert_VisNegID = Guid.Empty;
         AV43AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
         AV44Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         A410VisDescricao = "";
         A415VisTipoSigla = "";
         A416VisTipoNome = "";
         A407VisNegCliID = Guid.Empty;
         A408VisNegCpjID = Guid.Empty;
         A423VisNgfIteID = Guid.Empty;
         A460VisPaiData = DateTime.MinValue;
         A461VisPaiHora = (DateTime)(DateTime.MinValue);
         A471VisNegCpjRazSocial = "";
         AV46Pgmname = "";
         Combo_vistipoid_Objectcall = "";
         Combo_vistipoid_Class = "";
         Combo_vistipoid_Icontype = "";
         Combo_vistipoid_Icon = "";
         Combo_vistipoid_Tooltip = "";
         Combo_vistipoid_Selectedvalue_set = "";
         Combo_vistipoid_Selectedtext_set = "";
         Combo_vistipoid_Selectedtext_get = "";
         Combo_vistipoid_Gamoauthtoken = "";
         Combo_vistipoid_Ddointernalname = "";
         Combo_vistipoid_Titlecontrolalign = "";
         Combo_vistipoid_Dropdownoptionstype = "";
         Combo_vistipoid_Titlecontrolidtoreplace = "";
         Combo_vistipoid_Datalisttype = "";
         Combo_vistipoid_Datalistfixedvalues = "";
         Combo_vistipoid_Datalistproc = "";
         Combo_vistipoid_Datalistprocparametersprefix = "";
         Combo_vistipoid_Remoteservicesparameters = "";
         Combo_vistipoid_Htmltemplate = "";
         Combo_vistipoid_Multiplevaluestype = "";
         Combo_vistipoid_Loadingdata = "";
         Combo_vistipoid_Noresultsfound = "";
         Combo_vistipoid_Onlyselectedvalues = "";
         Combo_vistipoid_Selectalltext = "";
         Combo_vistipoid_Multiplevaluesseparator = "";
         Combo_vistipoid_Addnewoptiontext = "";
         Visdescricao_Objectcall = "";
         Visdescricao_Class = "";
         Visdescricao_Customtoolbar = "";
         Visdescricao_Customconfiguration = "";
         Visdescricao_Buttonpressedid = "";
         Visdescricao_Captionvalue = "";
         Visdescricao_Coltitle = "";
         Visdescricao_Coltitlefont = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         T00145_A466VisNegCodigo = new long[1] ;
         T00145_A467VisNegAssunto = new string[] {""} ;
         T00145_A468VisNegValor = new decimal[1] ;
         T00145_A407VisNegCliID = new Guid[] {Guid.Empty} ;
         T00145_A408VisNegCpjID = new Guid[] {Guid.Empty} ;
         T00148_A469VisNegCliNomeFamiliar = new string[] {""} ;
         T00149_A470VisNegCpjNomFan = new string[] {""} ;
         T00149_A471VisNegCpjRazSocial = new string[] {""} ;
         T00146_A423VisNgfIteID = new Guid[] {Guid.Empty} ;
         T001410_A424VisNgfIteNome = new string[] {""} ;
         sMode40 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV17TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         GXEncryptionTmp = "";
         AV20ComboSelectedValue = "";
         GXt_objcol_SdtDVB_SDTComboData_Item1 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         Z418VisNegID = Guid.Empty;
         Z410VisDescricao = "";
         Z467VisNegAssunto = "";
         Z407VisNegCliID = Guid.Empty;
         Z408VisNegCpjID = Guid.Empty;
         Z469VisNegCliNomeFamiliar = "";
         Z470VisNegCpjNomFan = "";
         Z471VisNegCpjRazSocial = "";
         Z423VisNgfIteID = Guid.Empty;
         Z424VisNgfIteNome = "";
         Z460VisPaiData = DateTime.MinValue;
         Z461VisPaiHora = (DateTime)(DateTime.MinValue);
         Z462VisPaiDataHora = (DateTime)(DateTime.MinValue);
         Z465VisPaiAssunto = "";
         Z415VisTipoSigla = "";
         Z416VisTipoNome = "";
         T00144_A415VisTipoSigla = new string[] {""} ;
         T00144_A416VisTipoNome = new string[] {""} ;
         T00147_A460VisPaiData = new DateTime[] {DateTime.MinValue} ;
         T00147_A461VisPaiHora = new DateTime[] {DateTime.MinValue} ;
         T00147_A462VisPaiDataHora = new DateTime[] {DateTime.MinValue} ;
         T00147_A465VisPaiAssunto = new string[] {""} ;
         T001411_A418VisNegID = new Guid[] {Guid.Empty} ;
         T001411_n418VisNegID = new bool[] {false} ;
         T001411_A422VisNgfSeq = new int[1] ;
         T001411_n422VisNgfSeq = new bool[] {false} ;
         T001411_A398VisID = new Guid[] {Guid.Empty} ;
         T001411_A401VisInsDataHora = new DateTime[] {DateTime.MinValue} ;
         T001411_A399VisInsData = new DateTime[] {DateTime.MinValue} ;
         T001411_A400VisInsHora = new DateTime[] {DateTime.MinValue} ;
         T001411_A402VisInsUsuID = new string[] {""} ;
         T001411_n402VisInsUsuID = new bool[] {false} ;
         T001411_A403VisInsUsuNome = new string[] {""} ;
         T001411_n403VisInsUsuNome = new bool[] {false} ;
         T001411_A490VisDelDataHora = new DateTime[] {DateTime.MinValue} ;
         T001411_n490VisDelDataHora = new bool[] {false} ;
         T001411_A488VisDelData = new DateTime[] {DateTime.MinValue} ;
         T001411_n488VisDelData = new bool[] {false} ;
         T001411_A489VisDelHora = new DateTime[] {DateTime.MinValue} ;
         T001411_n489VisDelHora = new bool[] {false} ;
         T001411_A491VisDelUsuID = new string[] {""} ;
         T001411_n491VisDelUsuID = new bool[] {false} ;
         T001411_A492VisDelUsuNome = new string[] {""} ;
         T001411_n492VisDelUsuNome = new bool[] {false} ;
         T001411_A460VisPaiData = new DateTime[] {DateTime.MinValue} ;
         T001411_A461VisPaiHora = new DateTime[] {DateTime.MinValue} ;
         T001411_A462VisPaiDataHora = new DateTime[] {DateTime.MinValue} ;
         T001411_A465VisPaiAssunto = new string[] {""} ;
         T001411_A482VisUpdData = new DateTime[] {DateTime.MinValue} ;
         T001411_n482VisUpdData = new bool[] {false} ;
         T001411_A483VisUpdHora = new DateTime[] {DateTime.MinValue} ;
         T001411_n483VisUpdHora = new bool[] {false} ;
         T001411_A484VisUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         T001411_n484VisUpdDataHora = new bool[] {false} ;
         T001411_A485VisUpdUsuID = new string[] {""} ;
         T001411_n485VisUpdUsuID = new bool[] {false} ;
         T001411_A486VisUpdUsuNome = new string[] {""} ;
         T001411_n486VisUpdUsuNome = new bool[] {false} ;
         T001411_A404VisData = new DateTime[] {DateTime.MinValue} ;
         T001411_A405VisHora = new DateTime[] {DateTime.MinValue} ;
         T001411_A406VisDataHora = new DateTime[] {DateTime.MinValue} ;
         T001411_A475VisDataFim = new DateTime[] {DateTime.MinValue} ;
         T001411_n475VisDataFim = new bool[] {false} ;
         T001411_A476VisHoraFim = new DateTime[] {DateTime.MinValue} ;
         T001411_n476VisHoraFim = new bool[] {false} ;
         T001411_A477VisDataHoraFim = new DateTime[] {DateTime.MinValue} ;
         T001411_n477VisDataHoraFim = new bool[] {false} ;
         T001411_A415VisTipoSigla = new string[] {""} ;
         T001411_A416VisTipoNome = new string[] {""} ;
         T001411_A466VisNegCodigo = new long[1] ;
         T001411_A467VisNegAssunto = new string[] {""} ;
         T001411_A468VisNegValor = new decimal[1] ;
         T001411_A469VisNegCliNomeFamiliar = new string[] {""} ;
         T001411_A470VisNegCpjNomFan = new string[] {""} ;
         T001411_A471VisNegCpjRazSocial = new string[] {""} ;
         T001411_A424VisNgfIteNome = new string[] {""} ;
         T001411_A409VisAssunto = new string[] {""} ;
         T001411_A410VisDescricao = new string[] {""} ;
         T001411_n410VisDescricao = new bool[] {false} ;
         T001411_A417VisLink = new string[] {""} ;
         T001411_n417VisLink = new bool[] {false} ;
         T001411_A472VisSituacao = new string[] {""} ;
         T001411_A487VisDel = new bool[] {false} ;
         T001411_A414VisTipoID = new int[1] ;
         T001411_A419VisPaiID = new Guid[] {Guid.Empty} ;
         T001411_n419VisPaiID = new bool[] {false} ;
         T001411_A407VisNegCliID = new Guid[] {Guid.Empty} ;
         T001411_A408VisNegCpjID = new Guid[] {Guid.Empty} ;
         T001411_A423VisNgfIteID = new Guid[] {Guid.Empty} ;
         T001412_A460VisPaiData = new DateTime[] {DateTime.MinValue} ;
         T001412_A461VisPaiHora = new DateTime[] {DateTime.MinValue} ;
         T001412_A462VisPaiDataHora = new DateTime[] {DateTime.MinValue} ;
         T001412_A465VisPaiAssunto = new string[] {""} ;
         T001413_A415VisTipoSigla = new string[] {""} ;
         T001413_A416VisTipoNome = new string[] {""} ;
         T001414_A398VisID = new Guid[] {Guid.Empty} ;
         T00143_A418VisNegID = new Guid[] {Guid.Empty} ;
         T00143_n418VisNegID = new bool[] {false} ;
         T00143_A422VisNgfSeq = new int[1] ;
         T00143_n422VisNgfSeq = new bool[] {false} ;
         T00143_A398VisID = new Guid[] {Guid.Empty} ;
         T00143_A401VisInsDataHora = new DateTime[] {DateTime.MinValue} ;
         T00143_A399VisInsData = new DateTime[] {DateTime.MinValue} ;
         T00143_A400VisInsHora = new DateTime[] {DateTime.MinValue} ;
         T00143_A402VisInsUsuID = new string[] {""} ;
         T00143_n402VisInsUsuID = new bool[] {false} ;
         T00143_A403VisInsUsuNome = new string[] {""} ;
         T00143_n403VisInsUsuNome = new bool[] {false} ;
         T00143_A490VisDelDataHora = new DateTime[] {DateTime.MinValue} ;
         T00143_n490VisDelDataHora = new bool[] {false} ;
         T00143_A488VisDelData = new DateTime[] {DateTime.MinValue} ;
         T00143_n488VisDelData = new bool[] {false} ;
         T00143_A489VisDelHora = new DateTime[] {DateTime.MinValue} ;
         T00143_n489VisDelHora = new bool[] {false} ;
         T00143_A491VisDelUsuID = new string[] {""} ;
         T00143_n491VisDelUsuID = new bool[] {false} ;
         T00143_A492VisDelUsuNome = new string[] {""} ;
         T00143_n492VisDelUsuNome = new bool[] {false} ;
         T00143_A482VisUpdData = new DateTime[] {DateTime.MinValue} ;
         T00143_n482VisUpdData = new bool[] {false} ;
         T00143_A483VisUpdHora = new DateTime[] {DateTime.MinValue} ;
         T00143_n483VisUpdHora = new bool[] {false} ;
         T00143_A484VisUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         T00143_n484VisUpdDataHora = new bool[] {false} ;
         T00143_A485VisUpdUsuID = new string[] {""} ;
         T00143_n485VisUpdUsuID = new bool[] {false} ;
         T00143_A486VisUpdUsuNome = new string[] {""} ;
         T00143_n486VisUpdUsuNome = new bool[] {false} ;
         T00143_A404VisData = new DateTime[] {DateTime.MinValue} ;
         T00143_A405VisHora = new DateTime[] {DateTime.MinValue} ;
         T00143_A406VisDataHora = new DateTime[] {DateTime.MinValue} ;
         T00143_A475VisDataFim = new DateTime[] {DateTime.MinValue} ;
         T00143_n475VisDataFim = new bool[] {false} ;
         T00143_A476VisHoraFim = new DateTime[] {DateTime.MinValue} ;
         T00143_n476VisHoraFim = new bool[] {false} ;
         T00143_A477VisDataHoraFim = new DateTime[] {DateTime.MinValue} ;
         T00143_n477VisDataHoraFim = new bool[] {false} ;
         T00143_A409VisAssunto = new string[] {""} ;
         T00143_A410VisDescricao = new string[] {""} ;
         T00143_n410VisDescricao = new bool[] {false} ;
         T00143_A417VisLink = new string[] {""} ;
         T00143_n417VisLink = new bool[] {false} ;
         T00143_A472VisSituacao = new string[] {""} ;
         T00143_A487VisDel = new bool[] {false} ;
         T00143_A414VisTipoID = new int[1] ;
         T00143_A419VisPaiID = new Guid[] {Guid.Empty} ;
         T00143_n419VisPaiID = new bool[] {false} ;
         T001415_A398VisID = new Guid[] {Guid.Empty} ;
         T001415_A418VisNegID = new Guid[] {Guid.Empty} ;
         T001415_n418VisNegID = new bool[] {false} ;
         T001415_A422VisNgfSeq = new int[1] ;
         T001415_n422VisNgfSeq = new bool[] {false} ;
         T001416_A398VisID = new Guid[] {Guid.Empty} ;
         T001416_A418VisNegID = new Guid[] {Guid.Empty} ;
         T001416_n418VisNegID = new bool[] {false} ;
         T001416_A422VisNgfSeq = new int[1] ;
         T001416_n422VisNgfSeq = new bool[] {false} ;
         T00142_A418VisNegID = new Guid[] {Guid.Empty} ;
         T00142_n418VisNegID = new bool[] {false} ;
         T00142_A422VisNgfSeq = new int[1] ;
         T00142_n422VisNgfSeq = new bool[] {false} ;
         T00142_A398VisID = new Guid[] {Guid.Empty} ;
         T00142_A401VisInsDataHora = new DateTime[] {DateTime.MinValue} ;
         T00142_A399VisInsData = new DateTime[] {DateTime.MinValue} ;
         T00142_A400VisInsHora = new DateTime[] {DateTime.MinValue} ;
         T00142_A402VisInsUsuID = new string[] {""} ;
         T00142_n402VisInsUsuID = new bool[] {false} ;
         T00142_A403VisInsUsuNome = new string[] {""} ;
         T00142_n403VisInsUsuNome = new bool[] {false} ;
         T00142_A490VisDelDataHora = new DateTime[] {DateTime.MinValue} ;
         T00142_n490VisDelDataHora = new bool[] {false} ;
         T00142_A488VisDelData = new DateTime[] {DateTime.MinValue} ;
         T00142_n488VisDelData = new bool[] {false} ;
         T00142_A489VisDelHora = new DateTime[] {DateTime.MinValue} ;
         T00142_n489VisDelHora = new bool[] {false} ;
         T00142_A491VisDelUsuID = new string[] {""} ;
         T00142_n491VisDelUsuID = new bool[] {false} ;
         T00142_A492VisDelUsuNome = new string[] {""} ;
         T00142_n492VisDelUsuNome = new bool[] {false} ;
         T00142_A482VisUpdData = new DateTime[] {DateTime.MinValue} ;
         T00142_n482VisUpdData = new bool[] {false} ;
         T00142_A483VisUpdHora = new DateTime[] {DateTime.MinValue} ;
         T00142_n483VisUpdHora = new bool[] {false} ;
         T00142_A484VisUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         T00142_n484VisUpdDataHora = new bool[] {false} ;
         T00142_A485VisUpdUsuID = new string[] {""} ;
         T00142_n485VisUpdUsuID = new bool[] {false} ;
         T00142_A486VisUpdUsuNome = new string[] {""} ;
         T00142_n486VisUpdUsuNome = new bool[] {false} ;
         T00142_A404VisData = new DateTime[] {DateTime.MinValue} ;
         T00142_A405VisHora = new DateTime[] {DateTime.MinValue} ;
         T00142_A406VisDataHora = new DateTime[] {DateTime.MinValue} ;
         T00142_A475VisDataFim = new DateTime[] {DateTime.MinValue} ;
         T00142_n475VisDataFim = new bool[] {false} ;
         T00142_A476VisHoraFim = new DateTime[] {DateTime.MinValue} ;
         T00142_n476VisHoraFim = new bool[] {false} ;
         T00142_A477VisDataHoraFim = new DateTime[] {DateTime.MinValue} ;
         T00142_n477VisDataHoraFim = new bool[] {false} ;
         T00142_A409VisAssunto = new string[] {""} ;
         T00142_A410VisDescricao = new string[] {""} ;
         T00142_n410VisDescricao = new bool[] {false} ;
         T00142_A417VisLink = new string[] {""} ;
         T00142_n417VisLink = new bool[] {false} ;
         T00142_A472VisSituacao = new string[] {""} ;
         T00142_A487VisDel = new bool[] {false} ;
         T00142_A414VisTipoID = new int[1] ;
         T00142_A419VisPaiID = new Guid[] {Guid.Empty} ;
         T00142_n419VisPaiID = new bool[] {false} ;
         T001420_A460VisPaiData = new DateTime[] {DateTime.MinValue} ;
         T001420_A461VisPaiHora = new DateTime[] {DateTime.MinValue} ;
         T001420_A462VisPaiDataHora = new DateTime[] {DateTime.MinValue} ;
         T001420_A465VisPaiAssunto = new string[] {""} ;
         T001421_A415VisTipoSigla = new string[] {""} ;
         T001421_A416VisTipoNome = new string[] {""} ;
         T001422_A419VisPaiID = new Guid[] {Guid.Empty} ;
         T001422_n419VisPaiID = new bool[] {false} ;
         T001423_A398VisID = new Guid[] {Guid.Empty} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i419VisPaiID = Guid.Empty;
         i472VisSituacao = "";
         GXt_guid3 = Guid.Empty;
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.core.visita__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.visita__default(),
            new Object[][] {
                new Object[] {
               T00142_A418VisNegID, T00142_n418VisNegID, T00142_A422VisNgfSeq, T00142_n422VisNgfSeq, T00142_A398VisID, T00142_A401VisInsDataHora, T00142_A399VisInsData, T00142_A400VisInsHora, T00142_A402VisInsUsuID, T00142_n402VisInsUsuID,
               T00142_A403VisInsUsuNome, T00142_n403VisInsUsuNome, T00142_A490VisDelDataHora, T00142_n490VisDelDataHora, T00142_A488VisDelData, T00142_n488VisDelData, T00142_A489VisDelHora, T00142_n489VisDelHora, T00142_A491VisDelUsuID, T00142_n491VisDelUsuID,
               T00142_A492VisDelUsuNome, T00142_n492VisDelUsuNome, T00142_A482VisUpdData, T00142_n482VisUpdData, T00142_A483VisUpdHora, T00142_n483VisUpdHora, T00142_A484VisUpdDataHora, T00142_n484VisUpdDataHora, T00142_A485VisUpdUsuID, T00142_n485VisUpdUsuID,
               T00142_A486VisUpdUsuNome, T00142_n486VisUpdUsuNome, T00142_A404VisData, T00142_A405VisHora, T00142_A406VisDataHora, T00142_A475VisDataFim, T00142_n475VisDataFim, T00142_A476VisHoraFim, T00142_n476VisHoraFim, T00142_A477VisDataHoraFim,
               T00142_n477VisDataHoraFim, T00142_A409VisAssunto, T00142_A410VisDescricao, T00142_n410VisDescricao, T00142_A417VisLink, T00142_n417VisLink, T00142_A472VisSituacao, T00142_A487VisDel, T00142_A414VisTipoID, T00142_A419VisPaiID,
               T00142_n419VisPaiID
               }
               , new Object[] {
               T00143_A418VisNegID, T00143_n418VisNegID, T00143_A422VisNgfSeq, T00143_n422VisNgfSeq, T00143_A398VisID, T00143_A401VisInsDataHora, T00143_A399VisInsData, T00143_A400VisInsHora, T00143_A402VisInsUsuID, T00143_n402VisInsUsuID,
               T00143_A403VisInsUsuNome, T00143_n403VisInsUsuNome, T00143_A490VisDelDataHora, T00143_n490VisDelDataHora, T00143_A488VisDelData, T00143_n488VisDelData, T00143_A489VisDelHora, T00143_n489VisDelHora, T00143_A491VisDelUsuID, T00143_n491VisDelUsuID,
               T00143_A492VisDelUsuNome, T00143_n492VisDelUsuNome, T00143_A482VisUpdData, T00143_n482VisUpdData, T00143_A483VisUpdHora, T00143_n483VisUpdHora, T00143_A484VisUpdDataHora, T00143_n484VisUpdDataHora, T00143_A485VisUpdUsuID, T00143_n485VisUpdUsuID,
               T00143_A486VisUpdUsuNome, T00143_n486VisUpdUsuNome, T00143_A404VisData, T00143_A405VisHora, T00143_A406VisDataHora, T00143_A475VisDataFim, T00143_n475VisDataFim, T00143_A476VisHoraFim, T00143_n476VisHoraFim, T00143_A477VisDataHoraFim,
               T00143_n477VisDataHoraFim, T00143_A409VisAssunto, T00143_A410VisDescricao, T00143_n410VisDescricao, T00143_A417VisLink, T00143_n417VisLink, T00143_A472VisSituacao, T00143_A487VisDel, T00143_A414VisTipoID, T00143_A419VisPaiID,
               T00143_n419VisPaiID
               }
               , new Object[] {
               T00144_A415VisTipoSigla, T00144_A416VisTipoNome
               }
               , new Object[] {
               T00145_A466VisNegCodigo, T00145_A467VisNegAssunto, T00145_A468VisNegValor, T00145_A407VisNegCliID, T00145_A408VisNegCpjID
               }
               , new Object[] {
               T00146_A423VisNgfIteID
               }
               , new Object[] {
               T00147_A460VisPaiData, T00147_A461VisPaiHora, T00147_A462VisPaiDataHora, T00147_A465VisPaiAssunto
               }
               , new Object[] {
               T00148_A469VisNegCliNomeFamiliar
               }
               , new Object[] {
               T00149_A470VisNegCpjNomFan, T00149_A471VisNegCpjRazSocial
               }
               , new Object[] {
               T001410_A424VisNgfIteNome
               }
               , new Object[] {
               T001411_A418VisNegID, T001411_n418VisNegID, T001411_A422VisNgfSeq, T001411_n422VisNgfSeq, T001411_A398VisID, T001411_A401VisInsDataHora, T001411_A399VisInsData, T001411_A400VisInsHora, T001411_A402VisInsUsuID, T001411_n402VisInsUsuID,
               T001411_A403VisInsUsuNome, T001411_n403VisInsUsuNome, T001411_A490VisDelDataHora, T001411_n490VisDelDataHora, T001411_A488VisDelData, T001411_n488VisDelData, T001411_A489VisDelHora, T001411_n489VisDelHora, T001411_A491VisDelUsuID, T001411_n491VisDelUsuID,
               T001411_A492VisDelUsuNome, T001411_n492VisDelUsuNome, T001411_A460VisPaiData, T001411_A461VisPaiHora, T001411_A462VisPaiDataHora, T001411_A465VisPaiAssunto, T001411_A482VisUpdData, T001411_n482VisUpdData, T001411_A483VisUpdHora, T001411_n483VisUpdHora,
               T001411_A484VisUpdDataHora, T001411_n484VisUpdDataHora, T001411_A485VisUpdUsuID, T001411_n485VisUpdUsuID, T001411_A486VisUpdUsuNome, T001411_n486VisUpdUsuNome, T001411_A404VisData, T001411_A405VisHora, T001411_A406VisDataHora, T001411_A475VisDataFim,
               T001411_n475VisDataFim, T001411_A476VisHoraFim, T001411_n476VisHoraFim, T001411_A477VisDataHoraFim, T001411_n477VisDataHoraFim, T001411_A415VisTipoSigla, T001411_A416VisTipoNome, T001411_A466VisNegCodigo, T001411_A467VisNegAssunto, T001411_A468VisNegValor,
               T001411_A469VisNegCliNomeFamiliar, T001411_A470VisNegCpjNomFan, T001411_A471VisNegCpjRazSocial, T001411_A424VisNgfIteNome, T001411_A409VisAssunto, T001411_A410VisDescricao, T001411_n410VisDescricao, T001411_A417VisLink, T001411_n417VisLink, T001411_A472VisSituacao,
               T001411_A487VisDel, T001411_A414VisTipoID, T001411_A419VisPaiID, T001411_n419VisPaiID, T001411_A407VisNegCliID, T001411_A408VisNegCpjID, T001411_A423VisNgfIteID
               }
               , new Object[] {
               T001412_A460VisPaiData, T001412_A461VisPaiHora, T001412_A462VisPaiDataHora, T001412_A465VisPaiAssunto
               }
               , new Object[] {
               T001413_A415VisTipoSigla, T001413_A416VisTipoNome
               }
               , new Object[] {
               T001414_A398VisID
               }
               , new Object[] {
               T001415_A398VisID, T001415_A418VisNegID, T001415_n418VisNegID, T001415_A422VisNgfSeq, T001415_n422VisNgfSeq
               }
               , new Object[] {
               T001416_A398VisID, T001416_A418VisNegID, T001416_n418VisNegID, T001416_A422VisNgfSeq, T001416_n422VisNgfSeq
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001420_A460VisPaiData, T001420_A461VisPaiHora, T001420_A462VisPaiDataHora, T001420_A465VisPaiAssunto
               }
               , new Object[] {
               T001421_A415VisTipoSigla, T001421_A416VisTipoNome
               }
               , new Object[] {
               T001422_A419VisPaiID
               }
               , new Object[] {
               T001423_A398VisID
               }
            }
         );
         N422VisNgfSeq = 0;
         n422VisNgfSeq = false;
         Z422VisNgfSeq = 0;
         n422VisNgfSeq = false;
         A422VisNgfSeq = 0;
         n422VisNgfSeq = false;
         N418VisNegID = Guid.Empty;
         n418VisNegID = false;
         Z418VisNegID = Guid.Empty;
         n418VisNegID = false;
         A418VisNegID = Guid.Empty;
         n418VisNegID = false;
         Z472VisSituacao = "PEN";
         A472VisSituacao = "PEN";
         i472VisSituacao = "PEN";
         Z398VisID = Guid.NewGuid( );
         A398VisID = Guid.NewGuid( );
         AV46Pgmname = "core.Visita";
         Z476VisHoraFim = (DateTime)(DateTime.MinValue);
         n476VisHoraFim = false;
         A476VisHoraFim = (DateTime)(DateTime.MinValue);
         n476VisHoraFim = false;
         Z475VisDataFim = DateTime.MinValue;
         n475VisDataFim = false;
         A475VisDataFim = DateTime.MinValue;
         n475VisDataFim = false;
         Z419VisPaiID = Guid.Empty;
         n419VisPaiID = false;
         N419VisPaiID = Guid.Empty;
         n419VisPaiID = false;
         i419VisPaiID = Guid.Empty;
         n419VisPaiID = false;
         A419VisPaiID = Guid.Empty;
         n419VisPaiID = false;
      }

      private short GxWebError ;
      private short Gx_BScreen ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short RcdFound40 ;
      private short gxcookieaux ;
      private short GX_JID ;
      private short nIsDirty_40 ;
      private short gxajaxcallmode ;
      private int wcpOA422VisNgfSeq ;
      private int Z414VisTipoID ;
      private int N414VisTipoID ;
      private int N422VisNgfSeq ;
      private int A414VisTipoID ;
      private int A422VisNgfSeq ;
      private int trnEnded ;
      private int edtVisNegCodigo_Enabled ;
      private int edtVisNegAssunto_Enabled ;
      private int edtVisNegCliNomeFamiliar_Enabled ;
      private int edtVisNegCpjNomFan_Enabled ;
      private int edtVisNegValor_Enabled ;
      private int edtVisNgfIteNome_Enabled ;
      private int edtVisPaiAssunto_Enabled ;
      private int edtVisPaiDataHora_Enabled ;
      private int edtVisTipoID_Visible ;
      private int edtVisTipoID_Enabled ;
      private int edtVisData_Enabled ;
      private int edtVisHora_Enabled ;
      private int edtVisDataFim_Enabled ;
      private int edtVisHoraFim_Enabled ;
      private int edtVisAssunto_Enabled ;
      private int edtVisLink_Enabled ;
      private int Visdescricao_Color ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int AV27ComboVisTipoID ;
      private int edtavCombovistipoid_Enabled ;
      private int edtavCombovistipoid_Visible ;
      private int edtavVispaiid_Visible ;
      private int edtavVispaiid_Enabled ;
      private int edtavVisnegid_Visible ;
      private int edtavVisnegid_Enabled ;
      private int AV42VisNgfSeq ;
      private int edtavVisngfseq_Enabled ;
      private int edtavVisngfseq_Visible ;
      private int edtVisDataHoraFim_Visible ;
      private int edtVisDataHoraFim_Enabled ;
      private int edtVisDataHora_Visible ;
      private int edtVisDataHora_Enabled ;
      private int edtVisPaiID_Visible ;
      private int edtVisPaiID_Enabled ;
      private int AV14Insert_VisTipoID ;
      private int AV16Insert_VisNgfSeq ;
      private int Combo_vistipoid_Datalistupdateminimumcharacters ;
      private int Combo_vistipoid_Gxcontroltype ;
      private int Visdescricao_Coltitlecolor ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int AV47GXV1 ;
      private int Z422VisNgfSeq ;
      private int idxLst ;
      private long A466VisNegCodigo ;
      private long Z466VisNegCodigo ;
      private decimal A468VisNegValor ;
      private decimal Z468VisNegValor ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z402VisInsUsuID ;
      private string Z491VisDelUsuID ;
      private string Z485VisUpdUsuID ;
      private string Combo_vistipoid_Selectedvalue_get ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtVisTipoID_Internalname ;
      private string cmbVisSituacao_Internalname ;
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
      private string edtVisNegCodigo_Internalname ;
      private string edtVisNegCodigo_Jsonclick ;
      private string edtVisNegAssunto_Internalname ;
      private string edtVisNegAssunto_Jsonclick ;
      private string edtVisNegCliNomeFamiliar_Internalname ;
      private string edtVisNegCliNomeFamiliar_Jsonclick ;
      private string edtVisNegCpjNomFan_Internalname ;
      private string edtVisNegCpjNomFan_Jsonclick ;
      private string edtVisNegValor_Internalname ;
      private string edtVisNegValor_Jsonclick ;
      private string edtVisNgfIteNome_Internalname ;
      private string edtVisNgfIteNome_Jsonclick ;
      private string lblTxtesp01_Internalname ;
      private string lblTxtesp01_Jsonclick ;
      private string grpTablegroupvisitaorigem_Internalname ;
      private string grpTablegroupvisitaorigem_Class ;
      private string divTablevisitaorigem_Internalname ;
      private string edtVisPaiAssunto_Internalname ;
      private string edtVisPaiAssunto_Jsonclick ;
      private string edtVisPaiDataHora_Internalname ;
      private string edtVisPaiDataHora_Jsonclick ;
      private string divTablesplittedvistipoid_Internalname ;
      private string lblTextblockvistipoid_Internalname ;
      private string lblTextblockvistipoid_Jsonclick ;
      private string Combo_vistipoid_Caption ;
      private string Combo_vistipoid_Cls ;
      private string Combo_vistipoid_Emptyitemtext ;
      private string Combo_vistipoid_Internalname ;
      private string TempTags ;
      private string edtVisTipoID_Jsonclick ;
      private string grpUnnamedgroup1_Internalname ;
      private string divTxtdatahorainicio_Internalname ;
      private string edtVisData_Internalname ;
      private string edtVisData_Jsonclick ;
      private string edtVisHora_Internalname ;
      private string edtVisHora_Jsonclick ;
      private string grpUnnamedgroup2_Internalname ;
      private string divTxtdatahoratermino_Internalname ;
      private string edtVisDataFim_Internalname ;
      private string edtVisDataFim_Jsonclick ;
      private string edtVisHoraFim_Internalname ;
      private string edtVisHoraFim_Jsonclick ;
      private string edtVisAssunto_Internalname ;
      private string edtVisAssunto_Jsonclick ;
      private string cmbVisSituacao_Jsonclick ;
      private string edtVisLink_Internalname ;
      private string edtVisLink_Jsonclick ;
      private string Visdescricao_Width ;
      private string Visdescricao_Height ;
      private string Visdescricao_Skin ;
      private string Visdescricao_Toolbar ;
      private string Visdescricao_Captionclass ;
      private string Visdescricao_Captionstyle ;
      private string Visdescricao_Captionposition ;
      private string Visdescricao_Internalname ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_vistipoid_Internalname ;
      private string edtavCombovistipoid_Internalname ;
      private string edtavCombovistipoid_Jsonclick ;
      private string edtavVispaiid_Internalname ;
      private string edtavVispaiid_Jsonclick ;
      private string edtavVisnegid_Internalname ;
      private string edtavVisnegid_Jsonclick ;
      private string edtavVisngfseq_Internalname ;
      private string edtavVisngfseq_Jsonclick ;
      private string edtVisDataHoraFim_Internalname ;
      private string edtVisDataHoraFim_Jsonclick ;
      private string edtVisDataHora_Internalname ;
      private string edtVisDataHora_Jsonclick ;
      private string edtVisPaiID_Internalname ;
      private string edtVisPaiID_Jsonclick ;
      private string A402VisInsUsuID ;
      private string A491VisDelUsuID ;
      private string A485VisUpdUsuID ;
      private string AV46Pgmname ;
      private string Combo_vistipoid_Objectcall ;
      private string Combo_vistipoid_Class ;
      private string Combo_vistipoid_Icontype ;
      private string Combo_vistipoid_Icon ;
      private string Combo_vistipoid_Tooltip ;
      private string Combo_vistipoid_Selectedvalue_set ;
      private string Combo_vistipoid_Selectedtext_set ;
      private string Combo_vistipoid_Selectedtext_get ;
      private string Combo_vistipoid_Gamoauthtoken ;
      private string Combo_vistipoid_Ddointernalname ;
      private string Combo_vistipoid_Titlecontrolalign ;
      private string Combo_vistipoid_Dropdownoptionstype ;
      private string Combo_vistipoid_Titlecontrolidtoreplace ;
      private string Combo_vistipoid_Datalisttype ;
      private string Combo_vistipoid_Datalistfixedvalues ;
      private string Combo_vistipoid_Datalistproc ;
      private string Combo_vistipoid_Datalistprocparametersprefix ;
      private string Combo_vistipoid_Remoteservicesparameters ;
      private string Combo_vistipoid_Htmltemplate ;
      private string Combo_vistipoid_Multiplevaluestype ;
      private string Combo_vistipoid_Loadingdata ;
      private string Combo_vistipoid_Noresultsfound ;
      private string Combo_vistipoid_Onlyselectedvalues ;
      private string Combo_vistipoid_Selectalltext ;
      private string Combo_vistipoid_Multiplevaluesseparator ;
      private string Combo_vistipoid_Addnewoptiontext ;
      private string Visdescricao_Objectcall ;
      private string Visdescricao_Class ;
      private string Visdescricao_Customtoolbar ;
      private string Visdescricao_Customconfiguration ;
      private string Visdescricao_Buttonpressedid ;
      private string Visdescricao_Captionvalue ;
      private string Visdescricao_Coltitle ;
      private string Visdescricao_Coltitlefont ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string hsh ;
      private string sMode40 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXEncryptionTmp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z401VisInsDataHora ;
      private DateTime Z400VisInsHora ;
      private DateTime Z490VisDelDataHora ;
      private DateTime Z488VisDelData ;
      private DateTime Z489VisDelHora ;
      private DateTime Z483VisUpdHora ;
      private DateTime Z484VisUpdDataHora ;
      private DateTime Z405VisHora ;
      private DateTime Z406VisDataHora ;
      private DateTime Z476VisHoraFim ;
      private DateTime Z477VisDataHoraFim ;
      private DateTime A462VisPaiDataHora ;
      private DateTime A405VisHora ;
      private DateTime A476VisHoraFim ;
      private DateTime A477VisDataHoraFim ;
      private DateTime A406VisDataHora ;
      private DateTime A490VisDelDataHora ;
      private DateTime A488VisDelData ;
      private DateTime A489VisDelHora ;
      private DateTime A483VisUpdHora ;
      private DateTime A484VisUpdDataHora ;
      private DateTime A401VisInsDataHora ;
      private DateTime A400VisInsHora ;
      private DateTime A461VisPaiHora ;
      private DateTime Z461VisPaiHora ;
      private DateTime Z462VisPaiDataHora ;
      private DateTime Z399VisInsData ;
      private DateTime Z482VisUpdData ;
      private DateTime Z404VisData ;
      private DateTime Z475VisDataFim ;
      private DateTime A404VisData ;
      private DateTime A475VisDataFim ;
      private DateTime A482VisUpdData ;
      private DateTime A399VisInsData ;
      private DateTime A460VisPaiData ;
      private DateTime Z460VisPaiData ;
      private bool Z487VisDel ;
      private bool O487VisDel ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n419VisPaiID ;
      private bool n418VisNegID ;
      private bool n422VisNgfSeq ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool Combo_vistipoid_Includeaddnewoption ;
      private bool n402VisInsUsuID ;
      private bool n403VisInsUsuNome ;
      private bool n490VisDelDataHora ;
      private bool n488VisDelData ;
      private bool n489VisDelHora ;
      private bool n491VisDelUsuID ;
      private bool n492VisDelUsuNome ;
      private bool n482VisUpdData ;
      private bool n483VisUpdHora ;
      private bool n484VisUpdDataHora ;
      private bool n485VisUpdUsuID ;
      private bool n486VisUpdUsuNome ;
      private bool n475VisDataFim ;
      private bool n476VisHoraFim ;
      private bool n477VisDataHoraFim ;
      private bool n417VisLink ;
      private bool A487VisDel ;
      private bool n410VisDescricao ;
      private bool Combo_vistipoid_Enabled ;
      private bool Combo_vistipoid_Visible ;
      private bool Combo_vistipoid_Allowmultipleselection ;
      private bool Combo_vistipoid_Isgriditem ;
      private bool Combo_vistipoid_Hasdescription ;
      private bool Combo_vistipoid_Includeonlyselectedoption ;
      private bool Combo_vistipoid_Includeselectalloption ;
      private bool Combo_vistipoid_Emptyitem ;
      private bool Visdescricao_Enabled ;
      private bool Visdescricao_Toolbarcancollapse ;
      private bool Visdescricao_Toolbarexpanded ;
      private bool Visdescricao_Isabstractlayoutcontrol ;
      private bool Visdescricao_Usercontroliscolumn ;
      private bool Visdescricao_Visible ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private bool GXt_boolean2 ;
      private bool Gx_longc ;
      private string VisDescricao ;
      private string A410VisDescricao ;
      private string Z410VisDescricao ;
      private string Z403VisInsUsuNome ;
      private string Z492VisDelUsuNome ;
      private string Z486VisUpdUsuNome ;
      private string Z409VisAssunto ;
      private string Z417VisLink ;
      private string Z472VisSituacao ;
      private string A472VisSituacao ;
      private string A467VisNegAssunto ;
      private string A469VisNegCliNomeFamiliar ;
      private string A470VisNegCpjNomFan ;
      private string A424VisNgfIteNome ;
      private string A465VisPaiAssunto ;
      private string A409VisAssunto ;
      private string A417VisLink ;
      private string A403VisInsUsuNome ;
      private string A492VisDelUsuNome ;
      private string A486VisUpdUsuNome ;
      private string A415VisTipoSigla ;
      private string A416VisTipoNome ;
      private string A471VisNegCpjRazSocial ;
      private string AV20ComboSelectedValue ;
      private string Z467VisNegAssunto ;
      private string Z469VisNegCliNomeFamiliar ;
      private string Z470VisNegCpjNomFan ;
      private string Z471VisNegCpjRazSocial ;
      private string Z424VisNgfIteNome ;
      private string Z465VisPaiAssunto ;
      private string Z415VisTipoSigla ;
      private string Z416VisTipoNome ;
      private string i472VisSituacao ;
      private Guid wcpOAV7VisID ;
      private Guid wcpOAV40VisPaiID ;
      private Guid wcpOA418VisNegID ;
      private Guid Z398VisID ;
      private Guid Z419VisPaiID ;
      private Guid N419VisPaiID ;
      private Guid N418VisNegID ;
      private Guid AV13Insert_VisPaiID ;
      private Guid AV40VisPaiID ;
      private Guid A419VisPaiID ;
      private Guid AV7VisID ;
      private Guid A418VisNegID ;
      private Guid AV41VisNegID ;
      private Guid A398VisID ;
      private Guid AV15Insert_VisNegID ;
      private Guid A407VisNegCliID ;
      private Guid A408VisNegCpjID ;
      private Guid A423VisNgfIteID ;
      private Guid Z418VisNegID ;
      private Guid Z407VisNegCliID ;
      private Guid Z408VisNegCpjID ;
      private Guid Z423VisNgfIteID ;
      private Guid i419VisPaiID ;
      private Guid GXt_guid3 ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucCombo_vistipoid ;
      private GXUserControl ucVisdescricao ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbVisSituacao ;
      private IDataStoreProvider pr_default ;
      private long[] T00145_A466VisNegCodigo ;
      private string[] T00145_A467VisNegAssunto ;
      private decimal[] T00145_A468VisNegValor ;
      private Guid[] T00145_A407VisNegCliID ;
      private Guid[] T00145_A408VisNegCpjID ;
      private string[] T00148_A469VisNegCliNomeFamiliar ;
      private string[] T00149_A470VisNegCpjNomFan ;
      private string[] T00149_A471VisNegCpjRazSocial ;
      private Guid[] T00146_A423VisNgfIteID ;
      private string[] T001410_A424VisNgfIteNome ;
      private string[] T00144_A415VisTipoSigla ;
      private string[] T00144_A416VisTipoNome ;
      private DateTime[] T00147_A460VisPaiData ;
      private DateTime[] T00147_A461VisPaiHora ;
      private DateTime[] T00147_A462VisPaiDataHora ;
      private string[] T00147_A465VisPaiAssunto ;
      private Guid[] T001411_A418VisNegID ;
      private bool[] T001411_n418VisNegID ;
      private int[] T001411_A422VisNgfSeq ;
      private bool[] T001411_n422VisNgfSeq ;
      private Guid[] T001411_A398VisID ;
      private DateTime[] T001411_A401VisInsDataHora ;
      private DateTime[] T001411_A399VisInsData ;
      private DateTime[] T001411_A400VisInsHora ;
      private string[] T001411_A402VisInsUsuID ;
      private bool[] T001411_n402VisInsUsuID ;
      private string[] T001411_A403VisInsUsuNome ;
      private bool[] T001411_n403VisInsUsuNome ;
      private DateTime[] T001411_A490VisDelDataHora ;
      private bool[] T001411_n490VisDelDataHora ;
      private DateTime[] T001411_A488VisDelData ;
      private bool[] T001411_n488VisDelData ;
      private DateTime[] T001411_A489VisDelHora ;
      private bool[] T001411_n489VisDelHora ;
      private string[] T001411_A491VisDelUsuID ;
      private bool[] T001411_n491VisDelUsuID ;
      private string[] T001411_A492VisDelUsuNome ;
      private bool[] T001411_n492VisDelUsuNome ;
      private DateTime[] T001411_A460VisPaiData ;
      private DateTime[] T001411_A461VisPaiHora ;
      private DateTime[] T001411_A462VisPaiDataHora ;
      private string[] T001411_A465VisPaiAssunto ;
      private DateTime[] T001411_A482VisUpdData ;
      private bool[] T001411_n482VisUpdData ;
      private DateTime[] T001411_A483VisUpdHora ;
      private bool[] T001411_n483VisUpdHora ;
      private DateTime[] T001411_A484VisUpdDataHora ;
      private bool[] T001411_n484VisUpdDataHora ;
      private string[] T001411_A485VisUpdUsuID ;
      private bool[] T001411_n485VisUpdUsuID ;
      private string[] T001411_A486VisUpdUsuNome ;
      private bool[] T001411_n486VisUpdUsuNome ;
      private DateTime[] T001411_A404VisData ;
      private DateTime[] T001411_A405VisHora ;
      private DateTime[] T001411_A406VisDataHora ;
      private DateTime[] T001411_A475VisDataFim ;
      private bool[] T001411_n475VisDataFim ;
      private DateTime[] T001411_A476VisHoraFim ;
      private bool[] T001411_n476VisHoraFim ;
      private DateTime[] T001411_A477VisDataHoraFim ;
      private bool[] T001411_n477VisDataHoraFim ;
      private string[] T001411_A415VisTipoSigla ;
      private string[] T001411_A416VisTipoNome ;
      private long[] T001411_A466VisNegCodigo ;
      private string[] T001411_A467VisNegAssunto ;
      private decimal[] T001411_A468VisNegValor ;
      private string[] T001411_A469VisNegCliNomeFamiliar ;
      private string[] T001411_A470VisNegCpjNomFan ;
      private string[] T001411_A471VisNegCpjRazSocial ;
      private string[] T001411_A424VisNgfIteNome ;
      private string[] T001411_A409VisAssunto ;
      private string[] T001411_A410VisDescricao ;
      private bool[] T001411_n410VisDescricao ;
      private string[] T001411_A417VisLink ;
      private bool[] T001411_n417VisLink ;
      private string[] T001411_A472VisSituacao ;
      private bool[] T001411_A487VisDel ;
      private int[] T001411_A414VisTipoID ;
      private Guid[] T001411_A419VisPaiID ;
      private bool[] T001411_n419VisPaiID ;
      private Guid[] T001411_A407VisNegCliID ;
      private Guid[] T001411_A408VisNegCpjID ;
      private Guid[] T001411_A423VisNgfIteID ;
      private DateTime[] T001412_A460VisPaiData ;
      private DateTime[] T001412_A461VisPaiHora ;
      private DateTime[] T001412_A462VisPaiDataHora ;
      private string[] T001412_A465VisPaiAssunto ;
      private string[] T001413_A415VisTipoSigla ;
      private string[] T001413_A416VisTipoNome ;
      private Guid[] T001414_A398VisID ;
      private Guid[] T00143_A418VisNegID ;
      private bool[] T00143_n418VisNegID ;
      private int[] T00143_A422VisNgfSeq ;
      private bool[] T00143_n422VisNgfSeq ;
      private Guid[] T00143_A398VisID ;
      private DateTime[] T00143_A401VisInsDataHora ;
      private DateTime[] T00143_A399VisInsData ;
      private DateTime[] T00143_A400VisInsHora ;
      private string[] T00143_A402VisInsUsuID ;
      private bool[] T00143_n402VisInsUsuID ;
      private string[] T00143_A403VisInsUsuNome ;
      private bool[] T00143_n403VisInsUsuNome ;
      private DateTime[] T00143_A490VisDelDataHora ;
      private bool[] T00143_n490VisDelDataHora ;
      private DateTime[] T00143_A488VisDelData ;
      private bool[] T00143_n488VisDelData ;
      private DateTime[] T00143_A489VisDelHora ;
      private bool[] T00143_n489VisDelHora ;
      private string[] T00143_A491VisDelUsuID ;
      private bool[] T00143_n491VisDelUsuID ;
      private string[] T00143_A492VisDelUsuNome ;
      private bool[] T00143_n492VisDelUsuNome ;
      private DateTime[] T00143_A482VisUpdData ;
      private bool[] T00143_n482VisUpdData ;
      private DateTime[] T00143_A483VisUpdHora ;
      private bool[] T00143_n483VisUpdHora ;
      private DateTime[] T00143_A484VisUpdDataHora ;
      private bool[] T00143_n484VisUpdDataHora ;
      private string[] T00143_A485VisUpdUsuID ;
      private bool[] T00143_n485VisUpdUsuID ;
      private string[] T00143_A486VisUpdUsuNome ;
      private bool[] T00143_n486VisUpdUsuNome ;
      private DateTime[] T00143_A404VisData ;
      private DateTime[] T00143_A405VisHora ;
      private DateTime[] T00143_A406VisDataHora ;
      private DateTime[] T00143_A475VisDataFim ;
      private bool[] T00143_n475VisDataFim ;
      private DateTime[] T00143_A476VisHoraFim ;
      private bool[] T00143_n476VisHoraFim ;
      private DateTime[] T00143_A477VisDataHoraFim ;
      private bool[] T00143_n477VisDataHoraFim ;
      private string[] T00143_A409VisAssunto ;
      private string[] T00143_A410VisDescricao ;
      private bool[] T00143_n410VisDescricao ;
      private string[] T00143_A417VisLink ;
      private bool[] T00143_n417VisLink ;
      private string[] T00143_A472VisSituacao ;
      private bool[] T00143_A487VisDel ;
      private int[] T00143_A414VisTipoID ;
      private Guid[] T00143_A419VisPaiID ;
      private bool[] T00143_n419VisPaiID ;
      private Guid[] T001415_A398VisID ;
      private Guid[] T001415_A418VisNegID ;
      private bool[] T001415_n418VisNegID ;
      private int[] T001415_A422VisNgfSeq ;
      private bool[] T001415_n422VisNgfSeq ;
      private Guid[] T001416_A398VisID ;
      private Guid[] T001416_A418VisNegID ;
      private bool[] T001416_n418VisNegID ;
      private int[] T001416_A422VisNgfSeq ;
      private bool[] T001416_n422VisNgfSeq ;
      private Guid[] T00142_A418VisNegID ;
      private bool[] T00142_n418VisNegID ;
      private int[] T00142_A422VisNgfSeq ;
      private bool[] T00142_n422VisNgfSeq ;
      private Guid[] T00142_A398VisID ;
      private DateTime[] T00142_A401VisInsDataHora ;
      private DateTime[] T00142_A399VisInsData ;
      private DateTime[] T00142_A400VisInsHora ;
      private string[] T00142_A402VisInsUsuID ;
      private bool[] T00142_n402VisInsUsuID ;
      private string[] T00142_A403VisInsUsuNome ;
      private bool[] T00142_n403VisInsUsuNome ;
      private DateTime[] T00142_A490VisDelDataHora ;
      private bool[] T00142_n490VisDelDataHora ;
      private DateTime[] T00142_A488VisDelData ;
      private bool[] T00142_n488VisDelData ;
      private DateTime[] T00142_A489VisDelHora ;
      private bool[] T00142_n489VisDelHora ;
      private string[] T00142_A491VisDelUsuID ;
      private bool[] T00142_n491VisDelUsuID ;
      private string[] T00142_A492VisDelUsuNome ;
      private bool[] T00142_n492VisDelUsuNome ;
      private DateTime[] T00142_A482VisUpdData ;
      private bool[] T00142_n482VisUpdData ;
      private DateTime[] T00142_A483VisUpdHora ;
      private bool[] T00142_n483VisUpdHora ;
      private DateTime[] T00142_A484VisUpdDataHora ;
      private bool[] T00142_n484VisUpdDataHora ;
      private string[] T00142_A485VisUpdUsuID ;
      private bool[] T00142_n485VisUpdUsuID ;
      private string[] T00142_A486VisUpdUsuNome ;
      private bool[] T00142_n486VisUpdUsuNome ;
      private DateTime[] T00142_A404VisData ;
      private DateTime[] T00142_A405VisHora ;
      private DateTime[] T00142_A406VisDataHora ;
      private DateTime[] T00142_A475VisDataFim ;
      private bool[] T00142_n475VisDataFim ;
      private DateTime[] T00142_A476VisHoraFim ;
      private bool[] T00142_n476VisHoraFim ;
      private DateTime[] T00142_A477VisDataHoraFim ;
      private bool[] T00142_n477VisDataHoraFim ;
      private string[] T00142_A409VisAssunto ;
      private string[] T00142_A410VisDescricao ;
      private bool[] T00142_n410VisDescricao ;
      private string[] T00142_A417VisLink ;
      private bool[] T00142_n417VisLink ;
      private string[] T00142_A472VisSituacao ;
      private bool[] T00142_A487VisDel ;
      private int[] T00142_A414VisTipoID ;
      private Guid[] T00142_A419VisPaiID ;
      private bool[] T00142_n419VisPaiID ;
      private DateTime[] T001420_A460VisPaiData ;
      private DateTime[] T001420_A461VisPaiHora ;
      private DateTime[] T001420_A462VisPaiDataHora ;
      private string[] T001420_A465VisPaiAssunto ;
      private string[] T001421_A415VisTipoSigla ;
      private string[] T001421_A416VisTipoNome ;
      private Guid[] T001422_A419VisPaiID ;
      private bool[] T001422_n419VisPaiID ;
      private Guid[] T001423_A398VisID ;
      private IDataStoreProvider pr_gam ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV26VisTipoID_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> GXt_objcol_SdtDVB_SDTComboData_Item1 ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV44Messages ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV17TrnContextAtt ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV43AuditingObject ;
   }

   public class visita__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class visita__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[15])
       ,new UpdateCursor(def[16])
       ,new UpdateCursor(def[17])
       ,new ForEachCursor(def[18])
       ,new ForEachCursor(def[19])
       ,new ForEachCursor(def[20])
       ,new ForEachCursor(def[21])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00145;
        prmT00145 = new Object[] {
        new ParDef("VisNegID",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmT00148;
        prmT00148 = new Object[] {
        new ParDef("VisNegCliID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT00149;
        prmT00149 = new Object[] {
        new ParDef("VisNegCliID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("VisNegCpjID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT00146;
        prmT00146 = new Object[] {
        new ParDef("VisNegID",GXType.UniqueIdentifier,36,0){Nullable=true} ,
        new ParDef("VisNgfSeq",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT001410;
        prmT001410 = new Object[] {
        new ParDef("VisNgfIteID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT001411;
        prmT001411 = new Object[] {
        new ParDef("VisID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("VisNegID",GXType.UniqueIdentifier,36,0){Nullable=true} ,
        new ParDef("VisNgfSeq",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT00147;
        prmT00147 = new Object[] {
        new ParDef("VisPaiID",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmT00144;
        prmT00144 = new Object[] {
        new ParDef("VisTipoID",GXType.Int32,9,0)
        };
        Object[] prmT001412;
        prmT001412 = new Object[] {
        new ParDef("VisPaiID",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmT001413;
        prmT001413 = new Object[] {
        new ParDef("VisTipoID",GXType.Int32,9,0)
        };
        Object[] prmT001414;
        prmT001414 = new Object[] {
        new ParDef("VisID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT00143;
        prmT00143 = new Object[] {
        new ParDef("VisID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT001415;
        prmT001415 = new Object[] {
        new ParDef("VisID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("VisNegID",GXType.UniqueIdentifier,36,0){Nullable=true} ,
        new ParDef("VisNgfSeq",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT001416;
        prmT001416 = new Object[] {
        new ParDef("VisID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("VisNegID",GXType.UniqueIdentifier,36,0){Nullable=true} ,
        new ParDef("VisNgfSeq",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT00142;
        prmT00142 = new Object[] {
        new ParDef("VisID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT001417;
        prmT001417 = new Object[] {
        new ParDef("VisNegID",GXType.UniqueIdentifier,36,0){Nullable=true} ,
        new ParDef("VisNgfSeq",GXType.Int32,8,0){Nullable=true} ,
        new ParDef("VisID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("VisInsDataHora",GXType.DateTime2,10,12) ,
        new ParDef("VisInsData",GXType.Date,8,0) ,
        new ParDef("VisInsHora",GXType.DateTime,0,5) ,
        new ParDef("VisInsUsuID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("VisInsUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("VisDelDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("VisDelData",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("VisDelHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("VisDelUsuID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("VisDelUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("VisUpdData",GXType.Date,8,0){Nullable=true} ,
        new ParDef("VisUpdHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("VisUpdDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("VisUpdUsuID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("VisUpdUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("VisData",GXType.Date,8,0) ,
        new ParDef("VisHora",GXType.DateTime,0,5) ,
        new ParDef("VisDataHora",GXType.DateTime,10,5) ,
        new ParDef("VisDataFim",GXType.Date,8,0){Nullable=true} ,
        new ParDef("VisHoraFim",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("VisDataHoraFim",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("VisAssunto",GXType.VarChar,80,0) ,
        new ParDef("VisDescricao",GXType.LongVarChar,2097152,0){Nullable=true} ,
        new ParDef("VisLink",GXType.VarChar,1000,0){Nullable=true} ,
        new ParDef("VisSituacao",GXType.VarChar,3,0) ,
        new ParDef("VisDel",GXType.Boolean,1,0) ,
        new ParDef("VisTipoID",GXType.Int32,9,0) ,
        new ParDef("VisPaiID",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmT001418;
        prmT001418 = new Object[] {
        new ParDef("VisNegID",GXType.UniqueIdentifier,36,0){Nullable=true} ,
        new ParDef("VisNgfSeq",GXType.Int32,8,0){Nullable=true} ,
        new ParDef("VisInsDataHora",GXType.DateTime2,10,12) ,
        new ParDef("VisInsData",GXType.Date,8,0) ,
        new ParDef("VisInsHora",GXType.DateTime,0,5) ,
        new ParDef("VisInsUsuID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("VisInsUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("VisDelDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("VisDelData",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("VisDelHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("VisDelUsuID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("VisDelUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("VisUpdData",GXType.Date,8,0){Nullable=true} ,
        new ParDef("VisUpdHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("VisUpdDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("VisUpdUsuID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("VisUpdUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("VisData",GXType.Date,8,0) ,
        new ParDef("VisHora",GXType.DateTime,0,5) ,
        new ParDef("VisDataHora",GXType.DateTime,10,5) ,
        new ParDef("VisDataFim",GXType.Date,8,0){Nullable=true} ,
        new ParDef("VisHoraFim",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("VisDataHoraFim",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("VisAssunto",GXType.VarChar,80,0) ,
        new ParDef("VisDescricao",GXType.LongVarChar,2097152,0){Nullable=true} ,
        new ParDef("VisLink",GXType.VarChar,1000,0){Nullable=true} ,
        new ParDef("VisSituacao",GXType.VarChar,3,0) ,
        new ParDef("VisDel",GXType.Boolean,1,0) ,
        new ParDef("VisTipoID",GXType.Int32,9,0) ,
        new ParDef("VisPaiID",GXType.UniqueIdentifier,36,0){Nullable=true} ,
        new ParDef("VisID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT001419;
        prmT001419 = new Object[] {
        new ParDef("VisID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT001422;
        prmT001422 = new Object[] {
        new ParDef("VisID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT001423;
        prmT001423 = new Object[] {
        new ParDef("VisNegID",GXType.UniqueIdentifier,36,0){Nullable=true} ,
        new ParDef("VisNgfSeq",GXType.Int32,8,0){Nullable=true}
        };
        Object[] prmT001421;
        prmT001421 = new Object[] {
        new ParDef("VisTipoID",GXType.Int32,9,0)
        };
        Object[] prmT001420;
        prmT001420 = new Object[] {
        new ParDef("VisPaiID",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        def= new CursorDef[] {
            new CursorDef("T00142", "SELECT VisNegID, VisNgfSeq, VisID, VisInsDataHora, VisInsData, VisInsHora, VisInsUsuID, VisInsUsuNome, VisDelDataHora, VisDelData, VisDelHora, VisDelUsuID, VisDelUsuNome, VisUpdData, VisUpdHora, VisUpdDataHora, VisUpdUsuID, VisUpdUsuNome, VisData, VisHora, VisDataHora, VisDataFim, VisHoraFim, VisDataHoraFim, VisAssunto, VisDescricao, VisLink, VisSituacao, VisDel, VisTipoID, VisPaiID FROM tb_visita WHERE VisID = :VisID  FOR UPDATE OF tb_visita NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT00142,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00143", "SELECT VisNegID, VisNgfSeq, VisID, VisInsDataHora, VisInsData, VisInsHora, VisInsUsuID, VisInsUsuNome, VisDelDataHora, VisDelData, VisDelHora, VisDelUsuID, VisDelUsuNome, VisUpdData, VisUpdHora, VisUpdDataHora, VisUpdUsuID, VisUpdUsuNome, VisData, VisHora, VisDataHora, VisDataFim, VisHoraFim, VisDataHoraFim, VisAssunto, VisDescricao, VisLink, VisSituacao, VisDel, VisTipoID, VisPaiID FROM tb_visita WHERE VisID = :VisID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00143,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00144", "SELECT VitSigla AS VisTipoSigla, VitNome AS VisTipoNome FROM tb_visitatipo WHERE VitID = :VisTipoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00144,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00145", "SELECT NegCodigo AS VisNegCodigo, NegAssunto AS VisNegAssunto, NegValorAtualizado AS VisNegValor, NegCliID AS VisNegCliID, NegCpjID AS VisNegCpjID FROM tb_negociopj WHERE NegID = :VisNegID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00145,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00146", "SELECT NgfIteID AS VisNgfIteID FROM tb_negociopj_fase WHERE NegID = :VisNegID AND NgfSeq = :VisNgfSeq ",true, GxErrorMask.GX_NOMASK, false, this,prmT00146,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00147", "SELECT VisData AS VisPaiData, VisHora AS VisPaiHora, VisDataHora AS VisPaiDataHora, VisAssunto AS VisPaiAssunto FROM tb_visita WHERE VisID = :VisPaiID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00147,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00148", "SELECT CliNomeFamiliar AS VisNegCliNomeFamiliar FROM tb_cliente WHERE CliID = :VisNegCliID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00148,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00149", "SELECT CpjNomeFan AS VisNegCpjNomFan, CpjRazaoSoc AS VisNegCpjRazSocial FROM tb_clientepj WHERE CliID = :VisNegCliID AND CpjID = :VisNegCpjID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00149,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001410", "SELECT IteNome AS VisNgfIteNome FROM tb_Iteracao WHERE IteID = :VisNgfIteID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001410,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001411", "SELECT TM1.VisNegID AS VisNegID, TM1.VisNgfSeq AS VisNgfSeq, TM1.VisID, TM1.VisInsDataHora, TM1.VisInsData, TM1.VisInsHora, TM1.VisInsUsuID, TM1.VisInsUsuNome, TM1.VisDelDataHora, TM1.VisDelData, TM1.VisDelHora, TM1.VisDelUsuID, TM1.VisDelUsuNome, T7.VisData AS VisPaiData, T7.VisHora AS VisPaiHora, T7.VisDataHora AS VisPaiDataHora, T7.VisAssunto AS VisPaiAssunto, TM1.VisUpdData, TM1.VisUpdHora, TM1.VisUpdDataHora, TM1.VisUpdUsuID, TM1.VisUpdUsuNome, TM1.VisData, TM1.VisHora, TM1.VisDataHora, TM1.VisDataFim, TM1.VisHoraFim, TM1.VisDataHoraFim, T8.VitSigla AS VisTipoSigla, T8.VitNome AS VisTipoNome, T2.NegCodigo AS VisNegCodigo, T2.NegAssunto AS VisNegAssunto, T2.NegValorAtualizado AS VisNegValor, T3.CliNomeFamiliar AS VisNegCliNomeFamiliar, T4.CpjNomeFan AS VisNegCpjNomFan, T4.CpjRazaoSoc AS VisNegCpjRazSocial, T6.IteNome AS VisNgfIteNome, TM1.VisAssunto, TM1.VisDescricao, TM1.VisLink, TM1.VisSituacao, TM1.VisDel, TM1.VisTipoID AS VisTipoID, TM1.VisPaiID AS VisPaiID, T2.NegCliID AS VisNegCliID, T2.NegCpjID AS VisNegCpjID, T5.NgfIteID AS VisNgfIteID FROM (((((((tb_visita TM1 LEFT JOIN tb_negociopj T2 ON T2.NegID = TM1.VisNegID) LEFT JOIN tb_cliente T3 ON T3.CliID = T2.NegCliID) LEFT JOIN tb_clientepj T4 ON T4.CliID = T2.NegCliID AND T4.CpjID = T2.NegCpjID) LEFT JOIN tb_negociopj_fase T5 ON T5.NegID = TM1.VisNegID AND T5.NgfSeq = TM1.VisNgfSeq) LEFT JOIN tb_Iteracao T6 ON T6.IteID = T5.NgfIteID) LEFT JOIN tb_visita T7 ON T7.VisID = TM1.VisPaiID) INNER JOIN tb_visitatipo T8 ON T8.VitID = TM1.VisTipoID) WHERE TM1.VisID = :VisID and TM1.VisNegID = :VisNegID and TM1.VisNgfSeq = :VisNgfSeq ORDER BY TM1.VisID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001411,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001412", "SELECT VisData AS VisPaiData, VisHora AS VisPaiHora, VisDataHora AS VisPaiDataHora, VisAssunto AS VisPaiAssunto FROM tb_visita WHERE VisID = :VisPaiID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001412,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001413", "SELECT VitSigla AS VisTipoSigla, VitNome AS VisTipoNome FROM tb_visitatipo WHERE VitID = :VisTipoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001413,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001414", "SELECT VisID FROM tb_visita WHERE VisID = :VisID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001414,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001415", "SELECT VisID, VisNegID, VisNgfSeq FROM tb_visita WHERE ( VisID > :VisID) and VisNegID = :VisNegID and VisNgfSeq = :VisNgfSeq ORDER BY VisID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001415,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001416", "SELECT VisID, VisNegID, VisNgfSeq FROM tb_visita WHERE ( VisID < :VisID) and VisNegID = :VisNegID and VisNgfSeq = :VisNgfSeq ORDER BY VisID DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT001416,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001417", "SAVEPOINT gxupdate;INSERT INTO tb_visita(VisNegID, VisNgfSeq, VisID, VisInsDataHora, VisInsData, VisInsHora, VisInsUsuID, VisInsUsuNome, VisDelDataHora, VisDelData, VisDelHora, VisDelUsuID, VisDelUsuNome, VisUpdData, VisUpdHora, VisUpdDataHora, VisUpdUsuID, VisUpdUsuNome, VisData, VisHora, VisDataHora, VisDataFim, VisHoraFim, VisDataHoraFim, VisAssunto, VisDescricao, VisLink, VisSituacao, VisDel, VisTipoID, VisPaiID) VALUES(:VisNegID, :VisNgfSeq, :VisID, :VisInsDataHora, :VisInsData, :VisInsHora, :VisInsUsuID, :VisInsUsuNome, :VisDelDataHora, :VisDelData, :VisDelHora, :VisDelUsuID, :VisDelUsuNome, :VisUpdData, :VisUpdHora, :VisUpdDataHora, :VisUpdUsuID, :VisUpdUsuNome, :VisData, :VisHora, :VisDataHora, :VisDataFim, :VisHoraFim, :VisDataHoraFim, :VisAssunto, :VisDescricao, :VisLink, :VisSituacao, :VisDel, :VisTipoID, :VisPaiID);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT001417)
           ,new CursorDef("T001418", "SAVEPOINT gxupdate;UPDATE tb_visita SET VisNegID=:VisNegID, VisNgfSeq=:VisNgfSeq, VisInsDataHora=:VisInsDataHora, VisInsData=:VisInsData, VisInsHora=:VisInsHora, VisInsUsuID=:VisInsUsuID, VisInsUsuNome=:VisInsUsuNome, VisDelDataHora=:VisDelDataHora, VisDelData=:VisDelData, VisDelHora=:VisDelHora, VisDelUsuID=:VisDelUsuID, VisDelUsuNome=:VisDelUsuNome, VisUpdData=:VisUpdData, VisUpdHora=:VisUpdHora, VisUpdDataHora=:VisUpdDataHora, VisUpdUsuID=:VisUpdUsuID, VisUpdUsuNome=:VisUpdUsuNome, VisData=:VisData, VisHora=:VisHora, VisDataHora=:VisDataHora, VisDataFim=:VisDataFim, VisHoraFim=:VisHoraFim, VisDataHoraFim=:VisDataHoraFim, VisAssunto=:VisAssunto, VisDescricao=:VisDescricao, VisLink=:VisLink, VisSituacao=:VisSituacao, VisDel=:VisDel, VisTipoID=:VisTipoID, VisPaiID=:VisPaiID  WHERE VisID = :VisID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001418)
           ,new CursorDef("T001419", "SAVEPOINT gxupdate;DELETE FROM tb_visita  WHERE VisID = :VisID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001419)
           ,new CursorDef("T001420", "SELECT VisData AS VisPaiData, VisHora AS VisPaiHora, VisDataHora AS VisPaiDataHora, VisAssunto AS VisPaiAssunto FROM tb_visita WHERE VisID = :VisPaiID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001420,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001421", "SELECT VitSigla AS VisTipoSigla, VitNome AS VisTipoNome FROM tb_visitatipo WHERE VitID = :VisTipoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001421,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001422", "SELECT VisID AS VisPaiID FROM tb_visita WHERE VisPaiID = :VisID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001422,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001423", "SELECT VisID FROM tb_visita WHERE VisNegID = :VisNegID and VisNgfSeq = :VisNgfSeq ORDER BY VisID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001423,100, GxCacheFrequency.OFF ,true,false )
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
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              ((int[]) buf[2])[0] = rslt.getInt(2);
              ((bool[]) buf[3])[0] = rslt.wasNull(2);
              ((Guid[]) buf[4])[0] = rslt.getGuid(3);
              ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(4, true);
              ((DateTime[]) buf[6])[0] = rslt.getGXDate(5);
              ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(6);
              ((string[]) buf[8])[0] = rslt.getString(7, 40);
              ((bool[]) buf[9])[0] = rslt.wasNull(7);
              ((string[]) buf[10])[0] = rslt.getVarchar(8);
              ((bool[]) buf[11])[0] = rslt.wasNull(8);
              ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(9, true);
              ((bool[]) buf[13])[0] = rslt.wasNull(9);
              ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(10);
              ((bool[]) buf[15])[0] = rslt.wasNull(10);
              ((DateTime[]) buf[16])[0] = rslt.getGXDateTime(11);
              ((bool[]) buf[17])[0] = rslt.wasNull(11);
              ((string[]) buf[18])[0] = rslt.getString(12, 40);
              ((bool[]) buf[19])[0] = rslt.wasNull(12);
              ((string[]) buf[20])[0] = rslt.getVarchar(13);
              ((bool[]) buf[21])[0] = rslt.wasNull(13);
              ((DateTime[]) buf[22])[0] = rslt.getGXDate(14);
              ((bool[]) buf[23])[0] = rslt.wasNull(14);
              ((DateTime[]) buf[24])[0] = rslt.getGXDateTime(15);
              ((bool[]) buf[25])[0] = rslt.wasNull(15);
              ((DateTime[]) buf[26])[0] = rslt.getGXDateTime(16, true);
              ((bool[]) buf[27])[0] = rslt.wasNull(16);
              ((string[]) buf[28])[0] = rslt.getString(17, 40);
              ((bool[]) buf[29])[0] = rslt.wasNull(17);
              ((string[]) buf[30])[0] = rslt.getVarchar(18);
              ((bool[]) buf[31])[0] = rslt.wasNull(18);
              ((DateTime[]) buf[32])[0] = rslt.getGXDate(19);
              ((DateTime[]) buf[33])[0] = rslt.getGXDateTime(20);
              ((DateTime[]) buf[34])[0] = rslt.getGXDateTime(21);
              ((DateTime[]) buf[35])[0] = rslt.getGXDate(22);
              ((bool[]) buf[36])[0] = rslt.wasNull(22);
              ((DateTime[]) buf[37])[0] = rslt.getGXDateTime(23);
              ((bool[]) buf[38])[0] = rslt.wasNull(23);
              ((DateTime[]) buf[39])[0] = rslt.getGXDateTime(24);
              ((bool[]) buf[40])[0] = rslt.wasNull(24);
              ((string[]) buf[41])[0] = rslt.getVarchar(25);
              ((string[]) buf[42])[0] = rslt.getLongVarchar(26);
              ((bool[]) buf[43])[0] = rslt.wasNull(26);
              ((string[]) buf[44])[0] = rslt.getVarchar(27);
              ((bool[]) buf[45])[0] = rslt.wasNull(27);
              ((string[]) buf[46])[0] = rslt.getVarchar(28);
              ((bool[]) buf[47])[0] = rslt.getBool(29);
              ((int[]) buf[48])[0] = rslt.getInt(30);
              ((Guid[]) buf[49])[0] = rslt.getGuid(31);
              ((bool[]) buf[50])[0] = rslt.wasNull(31);
              return;
           case 1 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              ((int[]) buf[2])[0] = rslt.getInt(2);
              ((bool[]) buf[3])[0] = rslt.wasNull(2);
              ((Guid[]) buf[4])[0] = rslt.getGuid(3);
              ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(4, true);
              ((DateTime[]) buf[6])[0] = rslt.getGXDate(5);
              ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(6);
              ((string[]) buf[8])[0] = rslt.getString(7, 40);
              ((bool[]) buf[9])[0] = rslt.wasNull(7);
              ((string[]) buf[10])[0] = rslt.getVarchar(8);
              ((bool[]) buf[11])[0] = rslt.wasNull(8);
              ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(9, true);
              ((bool[]) buf[13])[0] = rslt.wasNull(9);
              ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(10);
              ((bool[]) buf[15])[0] = rslt.wasNull(10);
              ((DateTime[]) buf[16])[0] = rslt.getGXDateTime(11);
              ((bool[]) buf[17])[0] = rslt.wasNull(11);
              ((string[]) buf[18])[0] = rslt.getString(12, 40);
              ((bool[]) buf[19])[0] = rslt.wasNull(12);
              ((string[]) buf[20])[0] = rslt.getVarchar(13);
              ((bool[]) buf[21])[0] = rslt.wasNull(13);
              ((DateTime[]) buf[22])[0] = rslt.getGXDate(14);
              ((bool[]) buf[23])[0] = rslt.wasNull(14);
              ((DateTime[]) buf[24])[0] = rslt.getGXDateTime(15);
              ((bool[]) buf[25])[0] = rslt.wasNull(15);
              ((DateTime[]) buf[26])[0] = rslt.getGXDateTime(16, true);
              ((bool[]) buf[27])[0] = rslt.wasNull(16);
              ((string[]) buf[28])[0] = rslt.getString(17, 40);
              ((bool[]) buf[29])[0] = rslt.wasNull(17);
              ((string[]) buf[30])[0] = rslt.getVarchar(18);
              ((bool[]) buf[31])[0] = rslt.wasNull(18);
              ((DateTime[]) buf[32])[0] = rslt.getGXDate(19);
              ((DateTime[]) buf[33])[0] = rslt.getGXDateTime(20);
              ((DateTime[]) buf[34])[0] = rslt.getGXDateTime(21);
              ((DateTime[]) buf[35])[0] = rslt.getGXDate(22);
              ((bool[]) buf[36])[0] = rslt.wasNull(22);
              ((DateTime[]) buf[37])[0] = rslt.getGXDateTime(23);
              ((bool[]) buf[38])[0] = rslt.wasNull(23);
              ((DateTime[]) buf[39])[0] = rslt.getGXDateTime(24);
              ((bool[]) buf[40])[0] = rslt.wasNull(24);
              ((string[]) buf[41])[0] = rslt.getVarchar(25);
              ((string[]) buf[42])[0] = rslt.getLongVarchar(26);
              ((bool[]) buf[43])[0] = rslt.wasNull(26);
              ((string[]) buf[44])[0] = rslt.getVarchar(27);
              ((bool[]) buf[45])[0] = rslt.wasNull(27);
              ((string[]) buf[46])[0] = rslt.getVarchar(28);
              ((bool[]) buf[47])[0] = rslt.getBool(29);
              ((int[]) buf[48])[0] = rslt.getInt(30);
              ((Guid[]) buf[49])[0] = rslt.getGuid(31);
              ((bool[]) buf[50])[0] = rslt.wasNull(31);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((Guid[]) buf[3])[0] = rslt.getGuid(4);
              ((Guid[]) buf[4])[0] = rslt.getGuid(5);
              return;
           case 4 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 5 :
              ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 9 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              ((int[]) buf[2])[0] = rslt.getInt(2);
              ((bool[]) buf[3])[0] = rslt.wasNull(2);
              ((Guid[]) buf[4])[0] = rslt.getGuid(3);
              ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(4, true);
              ((DateTime[]) buf[6])[0] = rslt.getGXDate(5);
              ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(6);
              ((string[]) buf[8])[0] = rslt.getString(7, 40);
              ((bool[]) buf[9])[0] = rslt.wasNull(7);
              ((string[]) buf[10])[0] = rslt.getVarchar(8);
              ((bool[]) buf[11])[0] = rslt.wasNull(8);
              ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(9, true);
              ((bool[]) buf[13])[0] = rslt.wasNull(9);
              ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(10);
              ((bool[]) buf[15])[0] = rslt.wasNull(10);
              ((DateTime[]) buf[16])[0] = rslt.getGXDateTime(11);
              ((bool[]) buf[17])[0] = rslt.wasNull(11);
              ((string[]) buf[18])[0] = rslt.getString(12, 40);
              ((bool[]) buf[19])[0] = rslt.wasNull(12);
              ((string[]) buf[20])[0] = rslt.getVarchar(13);
              ((bool[]) buf[21])[0] = rslt.wasNull(13);
              ((DateTime[]) buf[22])[0] = rslt.getGXDate(14);
              ((DateTime[]) buf[23])[0] = rslt.getGXDateTime(15);
              ((DateTime[]) buf[24])[0] = rslt.getGXDateTime(16);
              ((string[]) buf[25])[0] = rslt.getVarchar(17);
              ((DateTime[]) buf[26])[0] = rslt.getGXDate(18);
              ((bool[]) buf[27])[0] = rslt.wasNull(18);
              ((DateTime[]) buf[28])[0] = rslt.getGXDateTime(19);
              ((bool[]) buf[29])[0] = rslt.wasNull(19);
              ((DateTime[]) buf[30])[0] = rslt.getGXDateTime(20, true);
              ((bool[]) buf[31])[0] = rslt.wasNull(20);
              ((string[]) buf[32])[0] = rslt.getString(21, 40);
              ((bool[]) buf[33])[0] = rslt.wasNull(21);
              ((string[]) buf[34])[0] = rslt.getVarchar(22);
              ((bool[]) buf[35])[0] = rslt.wasNull(22);
              ((DateTime[]) buf[36])[0] = rslt.getGXDate(23);
              ((DateTime[]) buf[37])[0] = rslt.getGXDateTime(24);
              ((DateTime[]) buf[38])[0] = rslt.getGXDateTime(25);
              ((DateTime[]) buf[39])[0] = rslt.getGXDate(26);
              ((bool[]) buf[40])[0] = rslt.wasNull(26);
              ((DateTime[]) buf[41])[0] = rslt.getGXDateTime(27);
              ((bool[]) buf[42])[0] = rslt.wasNull(27);
              ((DateTime[]) buf[43])[0] = rslt.getGXDateTime(28);
              ((bool[]) buf[44])[0] = rslt.wasNull(28);
              ((string[]) buf[45])[0] = rslt.getVarchar(29);
              ((string[]) buf[46])[0] = rslt.getVarchar(30);
              ((long[]) buf[47])[0] = rslt.getLong(31);
              ((string[]) buf[48])[0] = rslt.getVarchar(32);
              ((decimal[]) buf[49])[0] = rslt.getDecimal(33);
              ((string[]) buf[50])[0] = rslt.getVarchar(34);
              ((string[]) buf[51])[0] = rslt.getVarchar(35);
              ((string[]) buf[52])[0] = rslt.getVarchar(36);
              ((string[]) buf[53])[0] = rslt.getVarchar(37);
              ((string[]) buf[54])[0] = rslt.getVarchar(38);
              ((string[]) buf[55])[0] = rslt.getLongVarchar(39);
              ((bool[]) buf[56])[0] = rslt.wasNull(39);
              ((string[]) buf[57])[0] = rslt.getVarchar(40);
              ((bool[]) buf[58])[0] = rslt.wasNull(40);
              ((string[]) buf[59])[0] = rslt.getVarchar(41);
              ((bool[]) buf[60])[0] = rslt.getBool(42);
              ((int[]) buf[61])[0] = rslt.getInt(43);
              ((Guid[]) buf[62])[0] = rslt.getGuid(44);
              ((bool[]) buf[63])[0] = rslt.wasNull(44);
              ((Guid[]) buf[64])[0] = rslt.getGuid(45);
              ((Guid[]) buf[65])[0] = rslt.getGuid(46);
              ((Guid[]) buf[66])[0] = rslt.getGuid(47);
              return;
           case 10 :
              ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 12 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 13 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((int[]) buf[3])[0] = rslt.getInt(3);
              ((bool[]) buf[4])[0] = rslt.wasNull(3);
              return;
           case 14 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((int[]) buf[3])[0] = rslt.getInt(3);
              ((bool[]) buf[4])[0] = rslt.wasNull(3);
              return;
           case 18 :
              ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              return;
           case 19 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 20 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 21 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
     }
  }

}

}
