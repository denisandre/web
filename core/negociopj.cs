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
   public class negociopj : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"NGPTPPPRDID") == 0 )
         {
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GXDLANGPTPPPRDID0Y42( ) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel15"+"_"+"NEGCODIGO") == 0 )
         {
            Gx_mode = GetPar( "Mode");
            AssignAttri("", false, "Gx_mode", Gx_mode);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX15ASANEGCODIGO0Y37( Gx_mode) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_70") == 0 )
         {
            A350NegCliID = StringUtil.StrToGuid( GetPar( "NegCliID"));
            AssignAttri("", false, "A350NegCliID", A350NegCliID.ToString());
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_70( A350NegCliID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_71") == 0 )
         {
            A350NegCliID = StringUtil.StrToGuid( GetPar( "NegCliID"));
            AssignAttri("", false, "A350NegCliID", A350NegCliID.ToString());
            A352NegCpjID = StringUtil.StrToGuid( GetPar( "NegCpjID"));
            AssignAttri("", false, "A352NegCpjID", A352NegCpjID.ToString());
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_71( A350NegCliID, A352NegCpjID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_73") == 0 )
         {
            A357NegPjtID = (int)(Math.Round(NumberUtil.Val( GetPar( "NegPjtID"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A357NegPjtID", StringUtil.LTrimStr( (decimal)(A357NegPjtID), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_73( A357NegPjtID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_72") == 0 )
         {
            A350NegCliID = StringUtil.StrToGuid( GetPar( "NegCliID"));
            AssignAttri("", false, "A350NegCliID", A350NegCliID.ToString());
            A352NegCpjID = StringUtil.StrToGuid( GetPar( "NegCpjID"));
            AssignAttri("", false, "A352NegCpjID", A352NegCpjID.ToString());
            A369NegCpjEndSeq = (short)(Math.Round(NumberUtil.Val( GetPar( "NegCpjEndSeq"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A369NegCpjEndSeq", StringUtil.LTrimStr( (decimal)(A369NegCpjEndSeq), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_72( A350NegCliID, A352NegCpjID, A369NegCpjEndSeq) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_77") == 0 )
         {
            A478NgpTppID = StringUtil.StrToGuid( GetPar( "NgpTppID"));
            A439NgpTppPrdID = StringUtil.StrToGuid( GetPar( "NgpTppPrdID"));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_77( A478NgpTppID, A439NgpTppPrdID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_76") == 0 )
         {
            A439NgpTppPrdID = StringUtil.StrToGuid( GetPar( "NgpTppPrdID"));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_76( A439NgpTppPrdID) ;
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridlevel_item") == 0 )
         {
            gxnrGridlevel_item_newrow_invoke( ) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "core.negociopj.aspx")), "core.negociopj.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "core.negociopj.aspx")))) ;
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
                  AV7NegID = StringUtil.StrToGuid( GetPar( "NegID"));
                  AssignAttri("", false, "AV7NegID", AV7NegID.ToString());
                  GxWebStd.gx_hidden_field( context, "gxhash_vNEGID", GetSecureSignedToken( "", AV7NegID, context));
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
            Form.Meta.addItem("description", "Oportunidade de Negócio", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtNegCliID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGridlevel_item_newrow_invoke( )
      {
         nRC_GXsfl_73 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_73"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_73_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_73_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_73_idx = GetPar( "sGXsfl_73_idx");
         Gx_BScreen = (short)(Math.Round(NumberUtil.Val( GetPar( "Gx_BScreen"), "."), 18, MidpointRounding.ToEven));
         A454NegUltItem = (int)(Math.Round(NumberUtil.Val( GetPar( "NegUltItem"), "."), 18, MidpointRounding.ToEven));
         n454NegUltItem = false;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridlevel_item_newrow( ) ;
         /* End function gxnrGridlevel_item_newrow_invoke */
      }

      public negociopj( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public negociopj( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           Guid aP1_NegID )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7NegID = aP1_NegID;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         dynNgpTppPrdID = new GXCombobox();
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
            return "negocio_Execute" ;
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNegCodigo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNegCodigo_Internalname, "Código da Negociação", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtNegCodigo_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A356NegCodigo), 12, 0, ",", "")), StringUtil.LTrim( ((edtNegCodigo_Enabled!=0) ? context.localUtil.Format( (decimal)(A356NegCodigo), "ZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A356NegCodigo), "ZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNegCodigo_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtNegCodigo_Enabled, 0, "text", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_core\\NegocioPJ.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittednegcliid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblocknegcliid_Internalname, "Cliente", "", "", lblTextblocknegcliid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_core\\NegocioPJ.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_negcliid.SetProperty("Caption", Combo_negcliid_Caption);
         ucCombo_negcliid.SetProperty("Cls", Combo_negcliid_Cls);
         ucCombo_negcliid.SetProperty("IncludeAddNewOption", Combo_negcliid_Includeaddnewoption);
         ucCombo_negcliid.SetProperty("EmptyItemText", Combo_negcliid_Emptyitemtext);
         ucCombo_negcliid.SetProperty("DropDownOptionsTitleSettingsIcons", AV17DDO_TitleSettingsIcons);
         ucCombo_negcliid.SetProperty("DropDownOptionsData", AV16NegCliID_Data);
         ucCombo_negcliid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_negcliid_Internalname, "COMBO_NEGCLIIDContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNegCliID_Internalname, "Cliente ID", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNegCliID_Internalname, A350NegCliID.ToString(), A350NegCliID.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNegCliID_Jsonclick, 0, "Attribute", "", "", "", "", edtNegCliID_Visible, edtNegCliID_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_core\\NegocioPJ.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL RequiredDataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittednegcpjid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblocknegcpjid_Internalname, "Unidade", "", "", lblTextblocknegcpjid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_core\\NegocioPJ.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_negcpjid.SetProperty("Caption", Combo_negcpjid_Caption);
         ucCombo_negcpjid.SetProperty("Cls", Combo_negcpjid_Cls);
         ucCombo_negcpjid.SetProperty("DataListProc", Combo_negcpjid_Datalistproc);
         ucCombo_negcpjid.SetProperty("IncludeAddNewOption", Combo_negcpjid_Includeaddnewoption);
         ucCombo_negcpjid.SetProperty("EmptyItemText", Combo_negcpjid_Emptyitemtext);
         ucCombo_negcpjid.SetProperty("DropDownOptionsTitleSettingsIcons", AV17DDO_TitleSettingsIcons);
         ucCombo_negcpjid.SetProperty("DropDownOptionsData", AV25NegCpjID_Data);
         ucCombo_negcpjid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_negcpjid_Internalname, "COMBO_NEGCPJIDContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNegCpjID_Internalname, "Unidade", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNegCpjID_Internalname, A352NegCpjID.ToString(), A352NegCpjID.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNegCpjID_Jsonclick, 0, "Attribute", "", "", "", "", edtNegCpjID_Visible, edtNegCpjID_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_core\\NegocioPJ.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittednegcpjendseq_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblocknegcpjendseq_Internalname, "Endereço", "", "", lblTextblocknegcpjendseq_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_core\\NegocioPJ.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_negcpjendseq.SetProperty("Caption", Combo_negcpjendseq_Caption);
         ucCombo_negcpjendseq.SetProperty("Cls", Combo_negcpjendseq_Cls);
         ucCombo_negcpjendseq.SetProperty("DataListProc", Combo_negcpjendseq_Datalistproc);
         ucCombo_negcpjendseq.SetProperty("IncludeAddNewOption", Combo_negcpjendseq_Includeaddnewoption);
         ucCombo_negcpjendseq.SetProperty("EmptyItemText", Combo_negcpjendseq_Emptyitemtext);
         ucCombo_negcpjendseq.SetProperty("DropDownOptionsTitleSettingsIcons", AV17DDO_TitleSettingsIcons);
         ucCombo_negcpjendseq.SetProperty("DropDownOptionsData", AV29NegCpjEndSeq_Data);
         ucCombo_negcpjendseq.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_negcpjendseq_Internalname, "COMBO_NEGCPJENDSEQContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNegCpjEndSeq_Internalname, "Sequência", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNegCpjEndSeq_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A369NegCpjEndSeq), 4, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A369NegCpjEndSeq), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNegCpjEndSeq_Jsonclick, 0, "Attribute", "", "", "", "", edtNegCpjEndSeq_Visible, edtNegCpjEndSeq_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_core\\NegocioPJ.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNegAssunto_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNegAssunto_Internalname, "Assunto", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNegAssunto_Internalname, A362NegAssunto, StringUtil.RTrim( context.localUtil.Format( A362NegAssunto, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNegAssunto_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtNegAssunto_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\NegocioPJ.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNegValorEstimado_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNegValorEstimado_Internalname, "Valor Estimado em Negócios", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtNegValorEstimado_Internalname, StringUtil.LTrim( StringUtil.NToC( A380NegValorEstimado, 23, 2, ",", "")), StringUtil.LTrim( ((edtNegValorEstimado_Enabled!=0) ? context.localUtil.Format( A380NegValorEstimado, "R$ Z,ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A380NegValorEstimado, "R$ Z,ZZZ,ZZZ,ZZZ,ZZ9.99"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNegValorEstimado_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtNegValorEstimado_Enabled, 0, "text", "", 23, "chr", 1, "row", 23, 0, 0, 0, 0, -1, 0, true, "core\\Monetario", "end", false, "", "HLP_core\\NegocioPJ.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* User Defined Control */
         ucNegdescricao.SetProperty("Width", Negdescricao_Width);
         ucNegdescricao.SetProperty("Height", Negdescricao_Height);
         ucNegdescricao.SetProperty("Attribute", NegDescricao);
         ucNegdescricao.SetProperty("Skin", Negdescricao_Skin);
         ucNegdescricao.SetProperty("Toolbar", Negdescricao_Toolbar);
         ucNegdescricao.SetProperty("ToolbarCanCollapse", Negdescricao_Toolbarcancollapse);
         ucNegdescricao.SetProperty("Color", Negdescricao_Color);
         ucNegdescricao.SetProperty("CaptionClass", Negdescricao_Captionclass);
         ucNegdescricao.SetProperty("CaptionStyle", Negdescricao_Captionstyle);
         ucNegdescricao.SetProperty("CaptionPosition", Negdescricao_Captionposition);
         ucNegdescricao.Render(context, "fckeditor", Negdescricao_Internalname, "NEGDESCRICAOContainer");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 CellMarginTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableleaflevel_item_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell", "start", "top", "", "", "div");
         gxdraw_Gridlevel_item( ) ;
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 85,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\NegocioPJ.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 87,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\NegocioPJ.htm");
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
         GxWebStd.gx_div_start( context, divSectionattribute_negcliid_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtavCombonegcliid_Internalname, AV41ComboNegCliID.ToString(), AV41ComboNegCliID.ToString(), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombonegcliid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombonegcliid_Visible, edtavCombonegcliid_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_core\\NegocioPJ.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_negcpjid_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtavCombonegcpjid_Internalname, AV42ComboNegCpjID.ToString(), AV42ComboNegCpjID.ToString(), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombonegcpjid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombonegcpjid_Visible, edtavCombonegcpjid_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_core\\NegocioPJ.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_negcpjendseq_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtavCombonegcpjendseq_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV44ComboNegCpjEndSeq), 4, 0, ",", "")), StringUtil.LTrim( ((edtavCombonegcpjendseq_Enabled!=0) ? context.localUtil.Format( (decimal)(AV44ComboNegCpjEndSeq), "ZZZ9") : context.localUtil.Format( (decimal)(AV44ComboNegCpjEndSeq), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombonegcpjendseq_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombonegcpjendseq_Visible, edtavCombonegcpjendseq_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_core\\NegocioPJ.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* User Defined Control */
         ucCombo_ngptppid.SetProperty("Caption", Combo_ngptppid_Caption);
         ucCombo_ngptppid.SetProperty("Cls", Combo_ngptppid_Cls);
         ucCombo_ngptppid.SetProperty("IsGridItem", Combo_ngptppid_Isgriditem);
         ucCombo_ngptppid.SetProperty("EmptyItemText", Combo_ngptppid_Emptyitemtext);
         ucCombo_ngptppid.SetProperty("DropDownOptionsTitleSettingsIcons", AV17DDO_TitleSettingsIcons);
         ucCombo_ngptppid.SetProperty("DropDownOptionsData", AV40NgpTppID_Data);
         ucCombo_ngptppid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_ngptppid_Internalname, "COMBO_NGPTPPIDContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
      }

      protected void gxdraw_Gridlevel_item( )
      {
         /*  Grid Control  */
         StartGridControl73( ) ;
         nGXsfl_73_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount42 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_42 = 1;
               ScanStart0Y42( ) ;
               while ( RcdFound42 != 0 )
               {
                  init_level_properties42( ) ;
                  getByPrimaryKey0Y42( ) ;
                  AddRow0Y42( ) ;
                  ScanNext0Y42( ) ;
               }
               ScanEnd0Y42( ) ;
               nBlankRcdCount42 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            B454NegUltItem = A454NegUltItem;
            n454NegUltItem = false;
            AssignAttri("", false, "A454NegUltItem", StringUtil.LTrimStr( (decimal)(A454NegUltItem), 8, 0));
            B448NegPgpTotal = A448NegPgpTotal;
            n448NegPgpTotal = false;
            AssignAttri("", false, "A448NegPgpTotal", StringUtil.LTrimStr( A448NegPgpTotal, 16, 2));
            B572NegDel = A572NegDel;
            AssignAttri("", false, "A572NegDel", A572NegDel);
            standaloneNotModal0Y42( ) ;
            standaloneModal0Y42( ) ;
            sMode42 = Gx_mode;
            while ( nGXsfl_73_idx < nRC_GXsfl_73 )
            {
               bGXsfl_73_Refreshing = true;
               ReadRow0Y42( ) ;
               edtNgpItem_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "NGPITEM_"+sGXsfl_73_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtNgpItem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNgpItem_Enabled), 5, 0), !bGXsfl_73_Refreshing);
               edtNgpTppID_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "NGPTPPID_"+sGXsfl_73_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtNgpTppID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNgpTppID_Enabled), 5, 0), !bGXsfl_73_Refreshing);
               dynNgpTppPrdID.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "NGPTPPPRDID_"+sGXsfl_73_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
               AssignProp("", false, dynNgpTppPrdID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynNgpTppPrdID.Enabled), 5, 0), !bGXsfl_73_Refreshing);
               edtNgpTpp1Preco_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "NGPTPP1PRECO_"+sGXsfl_73_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtNgpTpp1Preco_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNgpTpp1Preco_Enabled), 5, 0), !bGXsfl_73_Refreshing);
               edtNgpPreco_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "NGPPRECO_"+sGXsfl_73_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtNgpPreco_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNgpPreco_Enabled), 5, 0), !bGXsfl_73_Refreshing);
               edtNgpQtde_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "NGPQTDE_"+sGXsfl_73_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtNgpQtde_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNgpQtde_Enabled), 5, 0), !bGXsfl_73_Refreshing);
               edtNgpTotal_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "NGPTOTAL_"+sGXsfl_73_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtNgpTotal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNgpTotal_Enabled), 5, 0), !bGXsfl_73_Refreshing);
               if ( ( nRcdExists_42 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal0Y42( ) ;
               }
               SendRow0Y42( ) ;
               bGXsfl_73_Refreshing = false;
            }
            Gx_mode = sMode42;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A454NegUltItem = B454NegUltItem;
            n454NegUltItem = false;
            AssignAttri("", false, "A454NegUltItem", StringUtil.LTrimStr( (decimal)(A454NegUltItem), 8, 0));
            A448NegPgpTotal = B448NegPgpTotal;
            n448NegPgpTotal = false;
            AssignAttri("", false, "A448NegPgpTotal", StringUtil.LTrimStr( A448NegPgpTotal, 16, 2));
            A572NegDel = B572NegDel;
            AssignAttri("", false, "A572NegDel", A572NegDel);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount42 = 5;
            nRcdExists_42 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart0Y42( ) ;
               while ( RcdFound42 != 0 )
               {
                  sGXsfl_73_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_73_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_7342( ) ;
                  init_level_properties42( ) ;
                  standaloneNotModal0Y42( ) ;
                  getByPrimaryKey0Y42( ) ;
                  standaloneModal0Y42( ) ;
                  AddRow0Y42( ) ;
                  ScanNext0Y42( ) ;
               }
               ScanEnd0Y42( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode42 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_73_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_73_idx+1), 4, 0), 4, "0");
            SubsflControlProps_7342( ) ;
            InitAll0Y42( ) ;
            init_level_properties42( ) ;
            B454NegUltItem = A454NegUltItem;
            n454NegUltItem = false;
            AssignAttri("", false, "A454NegUltItem", StringUtil.LTrimStr( (decimal)(A454NegUltItem), 8, 0));
            B448NegPgpTotal = A448NegPgpTotal;
            n448NegPgpTotal = false;
            AssignAttri("", false, "A448NegPgpTotal", StringUtil.LTrimStr( A448NegPgpTotal, 16, 2));
            B572NegDel = A572NegDel;
            AssignAttri("", false, "A572NegDel", A572NegDel);
            nRcdExists_42 = 0;
            nIsMod_42 = 0;
            nRcdDeleted_42 = 0;
            nBlankRcdCount42 = (short)(nBlankRcdUsr42+nBlankRcdCount42);
            fRowAdded = 0;
            while ( nBlankRcdCount42 > 0 )
            {
               standaloneNotModal0Y42( ) ;
               standaloneModal0Y42( ) ;
               AddRow0Y42( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtNgpTppID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount42 = (short)(nBlankRcdCount42-1);
            }
            Gx_mode = sMode42;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A454NegUltItem = B454NegUltItem;
            n454NegUltItem = false;
            AssignAttri("", false, "A454NegUltItem", StringUtil.LTrimStr( (decimal)(A454NegUltItem), 8, 0));
            A448NegPgpTotal = B448NegPgpTotal;
            n448NegPgpTotal = false;
            AssignAttri("", false, "A448NegPgpTotal", StringUtil.LTrimStr( A448NegPgpTotal, 16, 2));
            A572NegDel = B572NegDel;
            AssignAttri("", false, "A572NegDel", A572NegDel);
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridlevel_itemContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridlevel_item", Gridlevel_itemContainer, subGridlevel_item_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_itemContainerData", Gridlevel_itemContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_itemContainerData"+"V", Gridlevel_itemContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridlevel_itemContainerData"+"V"+"\" value='"+Gridlevel_itemContainer.GridValuesHidden()+"'/>") ;
         }
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
         E110Y2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV17DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( "vNEGCLIID_DATA"), AV16NegCliID_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vNEGCPJID_DATA"), AV25NegCpjID_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vNEGCPJENDSEQ_DATA"), AV29NegCpjEndSeq_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vNGPTPPID_DATA"), AV40NgpTppID_Data);
               /* Read saved values. */
               Z345NegID = StringUtil.StrToGuid( cgiGet( "Z345NegID"));
               Z356NegCodigo = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z356NegCodigo"), ",", "."), 18, MidpointRounding.ToEven));
               Z348NegInsDataHora = context.localUtil.CToT( cgiGet( "Z348NegInsDataHora"), 0);
               Z346NegInsData = context.localUtil.CToD( cgiGet( "Z346NegInsData"), 0);
               Z347NegInsHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z347NegInsHora"), 0));
               Z349NegInsUsuID = cgiGet( "Z349NegInsUsuID");
               n349NegInsUsuID = (String.IsNullOrEmpty(StringUtil.RTrim( A349NegInsUsuID)) ? true : false);
               Z364NegInsUsuNome = cgiGet( "Z364NegInsUsuNome");
               n364NegInsUsuNome = (String.IsNullOrEmpty(StringUtil.RTrim( A364NegInsUsuNome)) ? true : false);
               Z385NegValorAtualizado = context.localUtil.CToN( cgiGet( "Z385NegValorAtualizado"), ",", ".");
               Z380NegValorEstimado = context.localUtil.CToN( cgiGet( "Z380NegValorEstimado"), ",", ".");
               Z573NegDelDataHora = context.localUtil.CToT( cgiGet( "Z573NegDelDataHora"), 0);
               n573NegDelDataHora = ((DateTime.MinValue==A573NegDelDataHora) ? true : false);
               Z574NegDelData = context.localUtil.CToT( cgiGet( "Z574NegDelData"), 0);
               n574NegDelData = ((DateTime.MinValue==A574NegDelData) ? true : false);
               Z575NegDelHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z575NegDelHora"), 0));
               n575NegDelHora = ((DateTime.MinValue==A575NegDelHora) ? true : false);
               Z576NegDelUsuId = cgiGet( "Z576NegDelUsuId");
               n576NegDelUsuId = (String.IsNullOrEmpty(StringUtil.RTrim( A576NegDelUsuId)) ? true : false);
               Z577NegDelUsuNome = cgiGet( "Z577NegDelUsuNome");
               n577NegDelUsuNome = (String.IsNullOrEmpty(StringUtil.RTrim( A577NegDelUsuNome)) ? true : false);
               Z360NegAgcID = cgiGet( "Z360NegAgcID");
               n360NegAgcID = (String.IsNullOrEmpty(StringUtil.RTrim( A360NegAgcID)) ? true : false);
               Z361NegAgcNome = cgiGet( "Z361NegAgcNome");
               n361NegAgcNome = (String.IsNullOrEmpty(StringUtil.RTrim( A361NegAgcNome)) ? true : false);
               Z362NegAssunto = cgiGet( "Z362NegAssunto");
               Z454NegUltItem = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z454NegUltItem"), ",", "."), 18, MidpointRounding.ToEven));
               n454NegUltItem = ((0==A454NegUltItem) ? true : false);
               Z572NegDel = StringUtil.StrToBool( cgiGet( "Z572NegDel"));
               Z350NegCliID = StringUtil.StrToGuid( cgiGet( "Z350NegCliID"));
               Z352NegCpjID = StringUtil.StrToGuid( cgiGet( "Z352NegCpjID"));
               Z369NegCpjEndSeq = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z369NegCpjEndSeq"), ",", "."), 18, MidpointRounding.ToEven));
               A348NegInsDataHora = context.localUtil.CToT( cgiGet( "Z348NegInsDataHora"), 0);
               A346NegInsData = context.localUtil.CToD( cgiGet( "Z346NegInsData"), 0);
               A347NegInsHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z347NegInsHora"), 0));
               A349NegInsUsuID = cgiGet( "Z349NegInsUsuID");
               n349NegInsUsuID = false;
               n349NegInsUsuID = (String.IsNullOrEmpty(StringUtil.RTrim( A349NegInsUsuID)) ? true : false);
               A364NegInsUsuNome = cgiGet( "Z364NegInsUsuNome");
               n364NegInsUsuNome = false;
               n364NegInsUsuNome = (String.IsNullOrEmpty(StringUtil.RTrim( A364NegInsUsuNome)) ? true : false);
               A385NegValorAtualizado = context.localUtil.CToN( cgiGet( "Z385NegValorAtualizado"), ",", ".");
               A573NegDelDataHora = context.localUtil.CToT( cgiGet( "Z573NegDelDataHora"), 0);
               n573NegDelDataHora = false;
               n573NegDelDataHora = ((DateTime.MinValue==A573NegDelDataHora) ? true : false);
               A574NegDelData = context.localUtil.CToT( cgiGet( "Z574NegDelData"), 0);
               n574NegDelData = false;
               n574NegDelData = ((DateTime.MinValue==A574NegDelData) ? true : false);
               A575NegDelHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z575NegDelHora"), 0));
               n575NegDelHora = false;
               n575NegDelHora = ((DateTime.MinValue==A575NegDelHora) ? true : false);
               A576NegDelUsuId = cgiGet( "Z576NegDelUsuId");
               n576NegDelUsuId = false;
               n576NegDelUsuId = (String.IsNullOrEmpty(StringUtil.RTrim( A576NegDelUsuId)) ? true : false);
               A577NegDelUsuNome = cgiGet( "Z577NegDelUsuNome");
               n577NegDelUsuNome = false;
               n577NegDelUsuNome = (String.IsNullOrEmpty(StringUtil.RTrim( A577NegDelUsuNome)) ? true : false);
               A360NegAgcID = cgiGet( "Z360NegAgcID");
               n360NegAgcID = false;
               n360NegAgcID = (String.IsNullOrEmpty(StringUtil.RTrim( A360NegAgcID)) ? true : false);
               A361NegAgcNome = cgiGet( "Z361NegAgcNome");
               n361NegAgcNome = false;
               n361NegAgcNome = (String.IsNullOrEmpty(StringUtil.RTrim( A361NegAgcNome)) ? true : false);
               A454NegUltItem = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z454NegUltItem"), ",", "."), 18, MidpointRounding.ToEven));
               n454NegUltItem = false;
               n454NegUltItem = ((0==A454NegUltItem) ? true : false);
               A572NegDel = StringUtil.StrToBool( cgiGet( "Z572NegDel"));
               O454NegUltItem = (int)(Math.Round(context.localUtil.CToN( cgiGet( "O454NegUltItem"), ",", "."), 18, MidpointRounding.ToEven));
               n454NegUltItem = ((0==A454NegUltItem) ? true : false);
               O448NegPgpTotal = context.localUtil.CToN( cgiGet( "O448NegPgpTotal"), ",", ".");
               O572NegDel = StringUtil.StrToBool( cgiGet( "O572NegDel"));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               nRC_GXsfl_73 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_73"), ",", "."), 18, MidpointRounding.ToEven));
               N350NegCliID = StringUtil.StrToGuid( cgiGet( "N350NegCliID"));
               N352NegCpjID = StringUtil.StrToGuid( cgiGet( "N352NegCpjID"));
               N369NegCpjEndSeq = (short)(Math.Round(context.localUtil.CToN( cgiGet( "N369NegCpjEndSeq"), ",", "."), 18, MidpointRounding.ToEven));
               A371NegCpjEndEndereco = cgiGet( "NEGCPJENDENDERECO");
               A374NegCpjEndBairro = cgiGet( "NEGCPJENDBAIRRO");
               A643NegCpjEndCepFormat = cgiGet( "NEGCPJENDCEPFORMAT");
               A376NegCpjEndMunNome = cgiGet( "NEGCPJENDMUNNOME");
               A378NegCpjEndUFSigla = cgiGet( "NEGCPJENDUFSIGLA");
               A372NegCpjEndNumero = cgiGet( "NEGCPJENDNUMERO");
               A373NegCpjEndComplem = cgiGet( "NEGCPJENDCOMPLEM");
               n373NegCpjEndComplem = false;
               A641NegCpjEndCompleto = cgiGet( "NEGCPJENDCOMPLETO");
               AV7NegID = StringUtil.StrToGuid( cgiGet( "vNEGID"));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ",", "."), 18, MidpointRounding.ToEven));
               A345NegID = StringUtil.StrToGuid( cgiGet( "NEGID"));
               AV13Insert_NegCliID = StringUtil.StrToGuid( cgiGet( "vINSERT_NEGCLIID"));
               AV14Insert_NegCpjID = StringUtil.StrToGuid( cgiGet( "vINSERT_NEGCPJID"));
               AV28Insert_NegCpjEndSeq = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_NEGCPJENDSEQ"), ",", "."), 18, MidpointRounding.ToEven));
               A348NegInsDataHora = context.localUtil.CToT( cgiGet( "NEGINSDATAHORA"), 0);
               A346NegInsData = context.localUtil.CToD( cgiGet( "NEGINSDATA"), 0);
               A347NegInsHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "NEGINSHORA"), 0));
               A349NegInsUsuID = cgiGet( "NEGINSUSUID");
               n349NegInsUsuID = (String.IsNullOrEmpty(StringUtil.RTrim( A349NegInsUsuID)) ? true : false);
               A364NegInsUsuNome = cgiGet( "NEGINSUSUNOME");
               n364NegInsUsuNome = (String.IsNullOrEmpty(StringUtil.RTrim( A364NegInsUsuNome)) ? true : false);
               A385NegValorAtualizado = context.localUtil.CToN( cgiGet( "NEGVALORATUALIZADO"), ",", ".");
               A448NegPgpTotal = context.localUtil.CToN( cgiGet( "NEGPGPTOTAL"), ",", ".");
               A572NegDel = StringUtil.StrToBool( cgiGet( "NEGDEL"));
               A573NegDelDataHora = context.localUtil.CToT( cgiGet( "NEGDELDATAHORA"), 0);
               n573NegDelDataHora = ((DateTime.MinValue==A573NegDelDataHora) ? true : false);
               A574NegDelData = context.localUtil.CToT( cgiGet( "NEGDELDATA"), 0);
               n574NegDelData = ((DateTime.MinValue==A574NegDelData) ? true : false);
               A575NegDelHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "NEGDELHORA"), 0));
               n575NegDelHora = ((DateTime.MinValue==A575NegDelHora) ? true : false);
               A576NegDelUsuId = cgiGet( "NEGDELUSUID");
               n576NegDelUsuId = (String.IsNullOrEmpty(StringUtil.RTrim( A576NegDelUsuId)) ? true : false);
               A577NegDelUsuNome = cgiGet( "NEGDELUSUNOME");
               n577NegDelUsuNome = (String.IsNullOrEmpty(StringUtil.RTrim( A577NegDelUsuNome)) ? true : false);
               ajax_req_read_hidden_sdt(cgiGet( "vAUDITINGOBJECT"), AV47AuditingObject);
               A360NegAgcID = cgiGet( "NEGAGCID");
               n360NegAgcID = (String.IsNullOrEmpty(StringUtil.RTrim( A360NegAgcID)) ? true : false);
               A361NegAgcNome = cgiGet( "NEGAGCNOME");
               n361NegAgcNome = (String.IsNullOrEmpty(StringUtil.RTrim( A361NegAgcNome)) ? true : false);
               A363NegDescricao = cgiGet( "NEGDESCRICAO");
               A454NegUltItem = (int)(Math.Round(context.localUtil.CToN( cgiGet( "NEGULTITEM"), ",", "."), 18, MidpointRounding.ToEven));
               n454NegUltItem = ((0==A454NegUltItem) ? true : false);
               A473NegCliMatricula = (long)(Math.Round(context.localUtil.CToN( cgiGet( "NEGCLIMATRICULA"), ",", "."), 18, MidpointRounding.ToEven));
               A351NegCliNomeFamiliar = cgiGet( "NEGCLINOMEFAMILIAR");
               A353NegCpjNomFan = cgiGet( "NEGCPJNOMFAN");
               A354NegCpjRazSocial = cgiGet( "NEGCPJRAZSOCIAL");
               A355NegCpjMatricula = (long)(Math.Round(context.localUtil.CToN( cgiGet( "NEGCPJMATRICULA"), ",", "."), 18, MidpointRounding.ToEven));
               A357NegPjtID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "NEGPJTID"), ",", "."), 18, MidpointRounding.ToEven));
               A370NegCpjEndNome = cgiGet( "NEGCPJENDNOME");
               A642NegCpjEndCep = (int)(Math.Round(context.localUtil.CToN( cgiGet( "NEGCPJENDCEP"), ",", "."), 18, MidpointRounding.ToEven));
               A375NegCpjEndMunID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "NEGCPJENDMUNID"), ",", "."), 18, MidpointRounding.ToEven));
               A377NegCpjEndUFID = (short)(Math.Round(context.localUtil.CToN( cgiGet( "NEGCPJENDUFID"), ",", "."), 18, MidpointRounding.ToEven));
               A379NegCpjEndUFNome = cgiGet( "NEGCPJENDUFNOME");
               A358NegPjtSigla = cgiGet( "NEGPJTSIGLA");
               A359NegPjtNome = cgiGet( "NEGPJTNOME");
               AV49Pgmname = cgiGet( "vPGMNAME");
               A457NgpInsDataHora = context.localUtil.CToT( cgiGet( "NGPINSDATAHORA"), 0);
               A455NgpInsData = context.localUtil.CToD( cgiGet( "NGPINSDATA"), 0);
               A456NgpInsHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "NGPINSHORA"), 0));
               A458NgpInsUsuID = cgiGet( "NGPINSUSUID");
               n458NgpInsUsuID = false;
               n458NgpInsUsuID = (String.IsNullOrEmpty(StringUtil.RTrim( A458NgpInsUsuID)) ? true : false);
               A459NgpInsUsuNome = cgiGet( "NGPINSUSUNOME");
               n459NgpInsUsuNome = false;
               n459NgpInsUsuNome = (String.IsNullOrEmpty(StringUtil.RTrim( A459NgpInsUsuNome)) ? true : false);
               A578NgpDel = StringUtil.StrToBool( cgiGet( "NGPDEL"));
               A579NgpDelDataHora = context.localUtil.CToT( cgiGet( "NGPDELDATAHORA"), 0);
               n579NgpDelDataHora = false;
               n579NgpDelDataHora = ((DateTime.MinValue==A579NgpDelDataHora) ? true : false);
               A580NgpDelData = context.localUtil.CToT( cgiGet( "NGPDELDATA"), 0);
               n580NgpDelData = false;
               n580NgpDelData = ((DateTime.MinValue==A580NgpDelData) ? true : false);
               A581NgpDelHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "NGPDELHORA"), 0));
               n581NgpDelHora = false;
               n581NgpDelHora = ((DateTime.MinValue==A581NgpDelHora) ? true : false);
               A582NgpDelUsuId = cgiGet( "NGPDELUSUID");
               n582NgpDelUsuId = false;
               n582NgpDelUsuId = (String.IsNullOrEmpty(StringUtil.RTrim( A582NgpDelUsuId)) ? true : false);
               A583NgpDelUsuNome = cgiGet( "NGPDELUSUNOME");
               n583NgpDelUsuNome = false;
               n583NgpDelUsuNome = (String.IsNullOrEmpty(StringUtil.RTrim( A583NgpDelUsuNome)) ? true : false);
               A453NgpObs = cgiGet( "NGPOBS");
               A440NgpTppPrdCodigo = cgiGet( "NGPTPPPRDCODIGO");
               A441NgpTppPrdNome = cgiGet( "NGPTPPPRDNOME");
               A443NgpTppPrdAtivo = StringUtil.StrToBool( cgiGet( "NGPTPPPRDATIVO"));
               A442NgpTppPrdTipoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "NGPTPPPRDTIPOID"), ",", "."), 18, MidpointRounding.ToEven));
               Combo_negcliid_Objectcall = cgiGet( "COMBO_NEGCLIID_Objectcall");
               Combo_negcliid_Class = cgiGet( "COMBO_NEGCLIID_Class");
               Combo_negcliid_Icontype = cgiGet( "COMBO_NEGCLIID_Icontype");
               Combo_negcliid_Icon = cgiGet( "COMBO_NEGCLIID_Icon");
               Combo_negcliid_Caption = cgiGet( "COMBO_NEGCLIID_Caption");
               Combo_negcliid_Tooltip = cgiGet( "COMBO_NEGCLIID_Tooltip");
               Combo_negcliid_Cls = cgiGet( "COMBO_NEGCLIID_Cls");
               Combo_negcliid_Selectedvalue_set = cgiGet( "COMBO_NEGCLIID_Selectedvalue_set");
               Combo_negcliid_Selectedvalue_get = cgiGet( "COMBO_NEGCLIID_Selectedvalue_get");
               Combo_negcliid_Selectedtext_set = cgiGet( "COMBO_NEGCLIID_Selectedtext_set");
               Combo_negcliid_Selectedtext_get = cgiGet( "COMBO_NEGCLIID_Selectedtext_get");
               Combo_negcliid_Gamoauthtoken = cgiGet( "COMBO_NEGCLIID_Gamoauthtoken");
               Combo_negcliid_Ddointernalname = cgiGet( "COMBO_NEGCLIID_Ddointernalname");
               Combo_negcliid_Titlecontrolalign = cgiGet( "COMBO_NEGCLIID_Titlecontrolalign");
               Combo_negcliid_Dropdownoptionstype = cgiGet( "COMBO_NEGCLIID_Dropdownoptionstype");
               Combo_negcliid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_NEGCLIID_Enabled"));
               Combo_negcliid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_NEGCLIID_Visible"));
               Combo_negcliid_Titlecontrolidtoreplace = cgiGet( "COMBO_NEGCLIID_Titlecontrolidtoreplace");
               Combo_negcliid_Datalisttype = cgiGet( "COMBO_NEGCLIID_Datalisttype");
               Combo_negcliid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_NEGCLIID_Allowmultipleselection"));
               Combo_negcliid_Datalistfixedvalues = cgiGet( "COMBO_NEGCLIID_Datalistfixedvalues");
               Combo_negcliid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_NEGCLIID_Isgriditem"));
               Combo_negcliid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_NEGCLIID_Hasdescription"));
               Combo_negcliid_Datalistproc = cgiGet( "COMBO_NEGCLIID_Datalistproc");
               Combo_negcliid_Datalistprocparametersprefix = cgiGet( "COMBO_NEGCLIID_Datalistprocparametersprefix");
               Combo_negcliid_Remoteservicesparameters = cgiGet( "COMBO_NEGCLIID_Remoteservicesparameters");
               Combo_negcliid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_NEGCLIID_Datalistupdateminimumcharacters"), ",", "."), 18, MidpointRounding.ToEven));
               Combo_negcliid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_NEGCLIID_Includeonlyselectedoption"));
               Combo_negcliid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_NEGCLIID_Includeselectalloption"));
               Combo_negcliid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_NEGCLIID_Emptyitem"));
               Combo_negcliid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_NEGCLIID_Includeaddnewoption"));
               Combo_negcliid_Htmltemplate = cgiGet( "COMBO_NEGCLIID_Htmltemplate");
               Combo_negcliid_Multiplevaluestype = cgiGet( "COMBO_NEGCLIID_Multiplevaluestype");
               Combo_negcliid_Loadingdata = cgiGet( "COMBO_NEGCLIID_Loadingdata");
               Combo_negcliid_Noresultsfound = cgiGet( "COMBO_NEGCLIID_Noresultsfound");
               Combo_negcliid_Emptyitemtext = cgiGet( "COMBO_NEGCLIID_Emptyitemtext");
               Combo_negcliid_Onlyselectedvalues = cgiGet( "COMBO_NEGCLIID_Onlyselectedvalues");
               Combo_negcliid_Selectalltext = cgiGet( "COMBO_NEGCLIID_Selectalltext");
               Combo_negcliid_Multiplevaluesseparator = cgiGet( "COMBO_NEGCLIID_Multiplevaluesseparator");
               Combo_negcliid_Addnewoptiontext = cgiGet( "COMBO_NEGCLIID_Addnewoptiontext");
               Combo_negcliid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_NEGCLIID_Gxcontroltype"), ",", "."), 18, MidpointRounding.ToEven));
               Combo_negcpjid_Objectcall = cgiGet( "COMBO_NEGCPJID_Objectcall");
               Combo_negcpjid_Class = cgiGet( "COMBO_NEGCPJID_Class");
               Combo_negcpjid_Icontype = cgiGet( "COMBO_NEGCPJID_Icontype");
               Combo_negcpjid_Icon = cgiGet( "COMBO_NEGCPJID_Icon");
               Combo_negcpjid_Caption = cgiGet( "COMBO_NEGCPJID_Caption");
               Combo_negcpjid_Tooltip = cgiGet( "COMBO_NEGCPJID_Tooltip");
               Combo_negcpjid_Cls = cgiGet( "COMBO_NEGCPJID_Cls");
               Combo_negcpjid_Selectedvalue_set = cgiGet( "COMBO_NEGCPJID_Selectedvalue_set");
               Combo_negcpjid_Selectedvalue_get = cgiGet( "COMBO_NEGCPJID_Selectedvalue_get");
               Combo_negcpjid_Selectedtext_set = cgiGet( "COMBO_NEGCPJID_Selectedtext_set");
               Combo_negcpjid_Selectedtext_get = cgiGet( "COMBO_NEGCPJID_Selectedtext_get");
               Combo_negcpjid_Gamoauthtoken = cgiGet( "COMBO_NEGCPJID_Gamoauthtoken");
               Combo_negcpjid_Ddointernalname = cgiGet( "COMBO_NEGCPJID_Ddointernalname");
               Combo_negcpjid_Titlecontrolalign = cgiGet( "COMBO_NEGCPJID_Titlecontrolalign");
               Combo_negcpjid_Dropdownoptionstype = cgiGet( "COMBO_NEGCPJID_Dropdownoptionstype");
               Combo_negcpjid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_NEGCPJID_Enabled"));
               Combo_negcpjid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_NEGCPJID_Visible"));
               Combo_negcpjid_Titlecontrolidtoreplace = cgiGet( "COMBO_NEGCPJID_Titlecontrolidtoreplace");
               Combo_negcpjid_Datalisttype = cgiGet( "COMBO_NEGCPJID_Datalisttype");
               Combo_negcpjid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_NEGCPJID_Allowmultipleselection"));
               Combo_negcpjid_Datalistfixedvalues = cgiGet( "COMBO_NEGCPJID_Datalistfixedvalues");
               Combo_negcpjid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_NEGCPJID_Isgriditem"));
               Combo_negcpjid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_NEGCPJID_Hasdescription"));
               Combo_negcpjid_Datalistproc = cgiGet( "COMBO_NEGCPJID_Datalistproc");
               Combo_negcpjid_Datalistprocparametersprefix = cgiGet( "COMBO_NEGCPJID_Datalistprocparametersprefix");
               Combo_negcpjid_Remoteservicesparameters = cgiGet( "COMBO_NEGCPJID_Remoteservicesparameters");
               Combo_negcpjid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_NEGCPJID_Datalistupdateminimumcharacters"), ",", "."), 18, MidpointRounding.ToEven));
               Combo_negcpjid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_NEGCPJID_Includeonlyselectedoption"));
               Combo_negcpjid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_NEGCPJID_Includeselectalloption"));
               Combo_negcpjid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_NEGCPJID_Emptyitem"));
               Combo_negcpjid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_NEGCPJID_Includeaddnewoption"));
               Combo_negcpjid_Htmltemplate = cgiGet( "COMBO_NEGCPJID_Htmltemplate");
               Combo_negcpjid_Multiplevaluestype = cgiGet( "COMBO_NEGCPJID_Multiplevaluestype");
               Combo_negcpjid_Loadingdata = cgiGet( "COMBO_NEGCPJID_Loadingdata");
               Combo_negcpjid_Noresultsfound = cgiGet( "COMBO_NEGCPJID_Noresultsfound");
               Combo_negcpjid_Emptyitemtext = cgiGet( "COMBO_NEGCPJID_Emptyitemtext");
               Combo_negcpjid_Onlyselectedvalues = cgiGet( "COMBO_NEGCPJID_Onlyselectedvalues");
               Combo_negcpjid_Selectalltext = cgiGet( "COMBO_NEGCPJID_Selectalltext");
               Combo_negcpjid_Multiplevaluesseparator = cgiGet( "COMBO_NEGCPJID_Multiplevaluesseparator");
               Combo_negcpjid_Addnewoptiontext = cgiGet( "COMBO_NEGCPJID_Addnewoptiontext");
               Combo_negcpjid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_NEGCPJID_Gxcontroltype"), ",", "."), 18, MidpointRounding.ToEven));
               Combo_negcpjendseq_Objectcall = cgiGet( "COMBO_NEGCPJENDSEQ_Objectcall");
               Combo_negcpjendseq_Class = cgiGet( "COMBO_NEGCPJENDSEQ_Class");
               Combo_negcpjendseq_Icontype = cgiGet( "COMBO_NEGCPJENDSEQ_Icontype");
               Combo_negcpjendseq_Icon = cgiGet( "COMBO_NEGCPJENDSEQ_Icon");
               Combo_negcpjendseq_Caption = cgiGet( "COMBO_NEGCPJENDSEQ_Caption");
               Combo_negcpjendseq_Tooltip = cgiGet( "COMBO_NEGCPJENDSEQ_Tooltip");
               Combo_negcpjendseq_Cls = cgiGet( "COMBO_NEGCPJENDSEQ_Cls");
               Combo_negcpjendseq_Selectedvalue_set = cgiGet( "COMBO_NEGCPJENDSEQ_Selectedvalue_set");
               Combo_negcpjendseq_Selectedvalue_get = cgiGet( "COMBO_NEGCPJENDSEQ_Selectedvalue_get");
               Combo_negcpjendseq_Selectedtext_set = cgiGet( "COMBO_NEGCPJENDSEQ_Selectedtext_set");
               Combo_negcpjendseq_Selectedtext_get = cgiGet( "COMBO_NEGCPJENDSEQ_Selectedtext_get");
               Combo_negcpjendseq_Gamoauthtoken = cgiGet( "COMBO_NEGCPJENDSEQ_Gamoauthtoken");
               Combo_negcpjendseq_Ddointernalname = cgiGet( "COMBO_NEGCPJENDSEQ_Ddointernalname");
               Combo_negcpjendseq_Titlecontrolalign = cgiGet( "COMBO_NEGCPJENDSEQ_Titlecontrolalign");
               Combo_negcpjendseq_Dropdownoptionstype = cgiGet( "COMBO_NEGCPJENDSEQ_Dropdownoptionstype");
               Combo_negcpjendseq_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_NEGCPJENDSEQ_Enabled"));
               Combo_negcpjendseq_Visible = StringUtil.StrToBool( cgiGet( "COMBO_NEGCPJENDSEQ_Visible"));
               Combo_negcpjendseq_Titlecontrolidtoreplace = cgiGet( "COMBO_NEGCPJENDSEQ_Titlecontrolidtoreplace");
               Combo_negcpjendseq_Datalisttype = cgiGet( "COMBO_NEGCPJENDSEQ_Datalisttype");
               Combo_negcpjendseq_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_NEGCPJENDSEQ_Allowmultipleselection"));
               Combo_negcpjendseq_Datalistfixedvalues = cgiGet( "COMBO_NEGCPJENDSEQ_Datalistfixedvalues");
               Combo_negcpjendseq_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_NEGCPJENDSEQ_Isgriditem"));
               Combo_negcpjendseq_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_NEGCPJENDSEQ_Hasdescription"));
               Combo_negcpjendseq_Datalistproc = cgiGet( "COMBO_NEGCPJENDSEQ_Datalistproc");
               Combo_negcpjendseq_Datalistprocparametersprefix = cgiGet( "COMBO_NEGCPJENDSEQ_Datalistprocparametersprefix");
               Combo_negcpjendseq_Remoteservicesparameters = cgiGet( "COMBO_NEGCPJENDSEQ_Remoteservicesparameters");
               Combo_negcpjendseq_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_NEGCPJENDSEQ_Datalistupdateminimumcharacters"), ",", "."), 18, MidpointRounding.ToEven));
               Combo_negcpjendseq_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_NEGCPJENDSEQ_Includeonlyselectedoption"));
               Combo_negcpjendseq_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_NEGCPJENDSEQ_Includeselectalloption"));
               Combo_negcpjendseq_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_NEGCPJENDSEQ_Emptyitem"));
               Combo_negcpjendseq_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_NEGCPJENDSEQ_Includeaddnewoption"));
               Combo_negcpjendseq_Htmltemplate = cgiGet( "COMBO_NEGCPJENDSEQ_Htmltemplate");
               Combo_negcpjendseq_Multiplevaluestype = cgiGet( "COMBO_NEGCPJENDSEQ_Multiplevaluestype");
               Combo_negcpjendseq_Loadingdata = cgiGet( "COMBO_NEGCPJENDSEQ_Loadingdata");
               Combo_negcpjendseq_Noresultsfound = cgiGet( "COMBO_NEGCPJENDSEQ_Noresultsfound");
               Combo_negcpjendseq_Emptyitemtext = cgiGet( "COMBO_NEGCPJENDSEQ_Emptyitemtext");
               Combo_negcpjendseq_Onlyselectedvalues = cgiGet( "COMBO_NEGCPJENDSEQ_Onlyselectedvalues");
               Combo_negcpjendseq_Selectalltext = cgiGet( "COMBO_NEGCPJENDSEQ_Selectalltext");
               Combo_negcpjendseq_Multiplevaluesseparator = cgiGet( "COMBO_NEGCPJENDSEQ_Multiplevaluesseparator");
               Combo_negcpjendseq_Addnewoptiontext = cgiGet( "COMBO_NEGCPJENDSEQ_Addnewoptiontext");
               Combo_negcpjendseq_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_NEGCPJENDSEQ_Gxcontroltype"), ",", "."), 18, MidpointRounding.ToEven));
               Negdescricao_Objectcall = cgiGet( "NEGDESCRICAO_Objectcall");
               Negdescricao_Class = cgiGet( "NEGDESCRICAO_Class");
               Negdescricao_Enabled = StringUtil.StrToBool( cgiGet( "NEGDESCRICAO_Enabled"));
               Negdescricao_Width = cgiGet( "NEGDESCRICAO_Width");
               Negdescricao_Height = cgiGet( "NEGDESCRICAO_Height");
               Negdescricao_Skin = cgiGet( "NEGDESCRICAO_Skin");
               Negdescricao_Toolbar = cgiGet( "NEGDESCRICAO_Toolbar");
               Negdescricao_Customtoolbar = cgiGet( "NEGDESCRICAO_Customtoolbar");
               Negdescricao_Customconfiguration = cgiGet( "NEGDESCRICAO_Customconfiguration");
               Negdescricao_Toolbarcancollapse = StringUtil.StrToBool( cgiGet( "NEGDESCRICAO_Toolbarcancollapse"));
               Negdescricao_Toolbarexpanded = StringUtil.StrToBool( cgiGet( "NEGDESCRICAO_Toolbarexpanded"));
               Negdescricao_Color = (int)(Math.Round(context.localUtil.CToN( cgiGet( "NEGDESCRICAO_Color"), ",", "."), 18, MidpointRounding.ToEven));
               Negdescricao_Buttonpressedid = cgiGet( "NEGDESCRICAO_Buttonpressedid");
               Negdescricao_Captionvalue = cgiGet( "NEGDESCRICAO_Captionvalue");
               Negdescricao_Captionclass = cgiGet( "NEGDESCRICAO_Captionclass");
               Negdescricao_Captionstyle = cgiGet( "NEGDESCRICAO_Captionstyle");
               Negdescricao_Captionposition = cgiGet( "NEGDESCRICAO_Captionposition");
               Negdescricao_Isabstractlayoutcontrol = StringUtil.StrToBool( cgiGet( "NEGDESCRICAO_Isabstractlayoutcontrol"));
               Negdescricao_Coltitle = cgiGet( "NEGDESCRICAO_Coltitle");
               Negdescricao_Coltitlefont = cgiGet( "NEGDESCRICAO_Coltitlefont");
               Negdescricao_Coltitlecolor = (int)(Math.Round(context.localUtil.CToN( cgiGet( "NEGDESCRICAO_Coltitlecolor"), ",", "."), 18, MidpointRounding.ToEven));
               Negdescricao_Usercontroliscolumn = StringUtil.StrToBool( cgiGet( "NEGDESCRICAO_Usercontroliscolumn"));
               Negdescricao_Visible = StringUtil.StrToBool( cgiGet( "NEGDESCRICAO_Visible"));
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
               Combo_ngptppid_Objectcall = cgiGet( "COMBO_NGPTPPID_Objectcall");
               Combo_ngptppid_Class = cgiGet( "COMBO_NGPTPPID_Class");
               Combo_ngptppid_Icontype = cgiGet( "COMBO_NGPTPPID_Icontype");
               Combo_ngptppid_Icon = cgiGet( "COMBO_NGPTPPID_Icon");
               Combo_ngptppid_Caption = cgiGet( "COMBO_NGPTPPID_Caption");
               Combo_ngptppid_Tooltip = cgiGet( "COMBO_NGPTPPID_Tooltip");
               Combo_ngptppid_Cls = cgiGet( "COMBO_NGPTPPID_Cls");
               Combo_ngptppid_Selectedvalue_set = cgiGet( "COMBO_NGPTPPID_Selectedvalue_set");
               Combo_ngptppid_Selectedvalue_get = cgiGet( "COMBO_NGPTPPID_Selectedvalue_get");
               Combo_ngptppid_Selectedtext_set = cgiGet( "COMBO_NGPTPPID_Selectedtext_set");
               Combo_ngptppid_Selectedtext_get = cgiGet( "COMBO_NGPTPPID_Selectedtext_get");
               Combo_ngptppid_Gamoauthtoken = cgiGet( "COMBO_NGPTPPID_Gamoauthtoken");
               Combo_ngptppid_Ddointernalname = cgiGet( "COMBO_NGPTPPID_Ddointernalname");
               Combo_ngptppid_Titlecontrolalign = cgiGet( "COMBO_NGPTPPID_Titlecontrolalign");
               Combo_ngptppid_Dropdownoptionstype = cgiGet( "COMBO_NGPTPPID_Dropdownoptionstype");
               Combo_ngptppid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_NGPTPPID_Enabled"));
               Combo_ngptppid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_NGPTPPID_Visible"));
               Combo_ngptppid_Titlecontrolidtoreplace = cgiGet( "COMBO_NGPTPPID_Titlecontrolidtoreplace");
               Combo_ngptppid_Datalisttype = cgiGet( "COMBO_NGPTPPID_Datalisttype");
               Combo_ngptppid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_NGPTPPID_Allowmultipleselection"));
               Combo_ngptppid_Datalistfixedvalues = cgiGet( "COMBO_NGPTPPID_Datalistfixedvalues");
               Combo_ngptppid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_NGPTPPID_Isgriditem"));
               Combo_ngptppid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_NGPTPPID_Hasdescription"));
               Combo_ngptppid_Datalistproc = cgiGet( "COMBO_NGPTPPID_Datalistproc");
               Combo_ngptppid_Datalistprocparametersprefix = cgiGet( "COMBO_NGPTPPID_Datalistprocparametersprefix");
               Combo_ngptppid_Remoteservicesparameters = cgiGet( "COMBO_NGPTPPID_Remoteservicesparameters");
               Combo_ngptppid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_NGPTPPID_Datalistupdateminimumcharacters"), ",", "."), 18, MidpointRounding.ToEven));
               Combo_ngptppid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_NGPTPPID_Includeonlyselectedoption"));
               Combo_ngptppid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_NGPTPPID_Includeselectalloption"));
               Combo_ngptppid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_NGPTPPID_Emptyitem"));
               Combo_ngptppid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_NGPTPPID_Includeaddnewoption"));
               Combo_ngptppid_Htmltemplate = cgiGet( "COMBO_NGPTPPID_Htmltemplate");
               Combo_ngptppid_Multiplevaluestype = cgiGet( "COMBO_NGPTPPID_Multiplevaluestype");
               Combo_ngptppid_Loadingdata = cgiGet( "COMBO_NGPTPPID_Loadingdata");
               Combo_ngptppid_Noresultsfound = cgiGet( "COMBO_NGPTPPID_Noresultsfound");
               Combo_ngptppid_Emptyitemtext = cgiGet( "COMBO_NGPTPPID_Emptyitemtext");
               Combo_ngptppid_Onlyselectedvalues = cgiGet( "COMBO_NGPTPPID_Onlyselectedvalues");
               Combo_ngptppid_Selectalltext = cgiGet( "COMBO_NGPTPPID_Selectalltext");
               Combo_ngptppid_Multiplevaluesseparator = cgiGet( "COMBO_NGPTPPID_Multiplevaluesseparator");
               Combo_ngptppid_Addnewoptiontext = cgiGet( "COMBO_NGPTPPID_Addnewoptiontext");
               Combo_ngptppid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_NGPTPPID_Gxcontroltype"), ",", "."), 18, MidpointRounding.ToEven));
               /* Read variables values. */
               A356NegCodigo = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtNegCodigo_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A356NegCodigo", StringUtil.LTrimStr( (decimal)(A356NegCodigo), 12, 0));
               if ( StringUtil.StrCmp(cgiGet( edtNegCliID_Internalname), "") == 0 )
               {
                  A350NegCliID = Guid.Empty;
                  AssignAttri("", false, "A350NegCliID", A350NegCliID.ToString());
               }
               else
               {
                  try
                  {
                     A350NegCliID = StringUtil.StrToGuid( cgiGet( edtNegCliID_Internalname));
                     AssignAttri("", false, "A350NegCliID", A350NegCliID.ToString());
                  }
                  catch ( Exception  )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "NEGCLIID");
                     AnyError = 1;
                     GX_FocusControl = edtNegCliID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     wbErr = true;
                  }
               }
               if ( StringUtil.StrCmp(cgiGet( edtNegCpjID_Internalname), "") == 0 )
               {
                  A352NegCpjID = Guid.Empty;
                  AssignAttri("", false, "A352NegCpjID", A352NegCpjID.ToString());
               }
               else
               {
                  try
                  {
                     A352NegCpjID = StringUtil.StrToGuid( cgiGet( edtNegCpjID_Internalname));
                     AssignAttri("", false, "A352NegCpjID", A352NegCpjID.ToString());
                  }
                  catch ( Exception  )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "NEGCPJID");
                     AnyError = 1;
                     GX_FocusControl = edtNegCpjID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     wbErr = true;
                  }
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtNegCpjEndSeq_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtNegCpjEndSeq_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "NEGCPJENDSEQ");
                  AnyError = 1;
                  GX_FocusControl = edtNegCpjEndSeq_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A369NegCpjEndSeq = 0;
                  AssignAttri("", false, "A369NegCpjEndSeq", StringUtil.LTrimStr( (decimal)(A369NegCpjEndSeq), 4, 0));
               }
               else
               {
                  A369NegCpjEndSeq = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtNegCpjEndSeq_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A369NegCpjEndSeq", StringUtil.LTrimStr( (decimal)(A369NegCpjEndSeq), 4, 0));
               }
               A362NegAssunto = StringUtil.Upper( cgiGet( edtNegAssunto_Internalname));
               AssignAttri("", false, "A362NegAssunto", A362NegAssunto);
               A380NegValorEstimado = context.localUtil.CToN( cgiGet( edtNegValorEstimado_Internalname), ",", ".");
               AssignAttri("", false, "A380NegValorEstimado", StringUtil.LTrimStr( A380NegValorEstimado, 16, 2));
               AV41ComboNegCliID = StringUtil.StrToGuid( cgiGet( edtavCombonegcliid_Internalname));
               AssignAttri("", false, "AV41ComboNegCliID", AV41ComboNegCliID.ToString());
               AV42ComboNegCpjID = StringUtil.StrToGuid( cgiGet( edtavCombonegcpjid_Internalname));
               AssignAttri("", false, "AV42ComboNegCpjID", AV42ComboNegCpjID.ToString());
               AV44ComboNegCpjEndSeq = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCombonegcpjendseq_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV44ComboNegCpjEndSeq", StringUtil.LTrimStr( (decimal)(AV44ComboNegCpjEndSeq), 4, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"NegocioPJ");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("NegAgcID", StringUtil.RTrim( context.localUtil.Format( A360NegAgcID, "")));
               forbiddenHiddens.Add("NegAgcNome", StringUtil.RTrim( context.localUtil.Format( A361NegAgcNome, "@!")));
               forbiddenHiddens.Add("NegDel", StringUtil.BoolToStr( A572NegDel));
               hsh = cgiGet( "hsh");
               if ( ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("core\\negociopj:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
                  GxWebError = 1;
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  AnyError = 1;
                  return  ;
               }
               /* Check if conditions changed and reset current page numbers */
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  A345NegID = StringUtil.StrToGuid( GetPar( "NegID"));
                  AssignAttri("", false, "A345NegID", A345NegID.ToString());
                  getEqualNoModal( ) ;
                  if ( ! (Guid.Empty==AV7NegID) )
                  {
                     A345NegID = AV7NegID;
                     AssignAttri("", false, "A345NegID", A345NegID.ToString());
                  }
                  else
                  {
                     if ( IsIns( )  && (Guid.Empty==A345NegID) && ( Gx_BScreen == 0 ) )
                     {
                        A345NegID = Guid.NewGuid( );
                        AssignAttri("", false, "A345NegID", A345NegID.ToString());
                     }
                  }
                  /* N/A Action t   37 */
                  /* Using cursor T000Y13 */
                  pr_default.execute(10, new Object[] {A345NegID});
                  if ( (pr_default.getStatus(10) != 101) )
                  {
                  }
                  else
                  {
                     A448NegPgpTotal = 0;
                     n448NegPgpTotal = false;
                     AssignAttri("", false, "A448NegPgpTotal", StringUtil.LTrimStr( A448NegPgpTotal, 16, 2));
                  }
                  pr_default.close(10);
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  disable_std_buttons( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  if ( IsDsp( ) )
                  {
                     sMode37 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     if ( ! (Guid.Empty==AV7NegID) )
                     {
                        A345NegID = AV7NegID;
                        AssignAttri("", false, "A345NegID", A345NegID.ToString());
                     }
                     else
                     {
                        if ( IsIns( )  && (Guid.Empty==A345NegID) && ( Gx_BScreen == 0 ) )
                        {
                           A345NegID = Guid.NewGuid( );
                           AssignAttri("", false, "A345NegID", A345NegID.ToString());
                        }
                     }
                     /* N/A Action t   37 */
                     /* Using cursor T000Y13 */
                     pr_default.execute(10, new Object[] {A345NegID});
                     if ( (pr_default.getStatus(10) != 101) )
                     {
                     }
                     else
                     {
                        A448NegPgpTotal = 0;
                        n448NegPgpTotal = false;
                        AssignAttri("", false, "A448NegPgpTotal", StringUtil.LTrimStr( A448NegPgpTotal, 16, 2));
                     }
                     pr_default.close(10);
                     Gx_mode = sMode37;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound37 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0Y0( ) ;
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
                        if ( StringUtil.StrCmp(sEvt, "COMBO_NEGCLIID.ONOPTIONCLICKED") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           E120Y2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "COMBO_NEGCPJID.ONOPTIONCLICKED") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           E130Y2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "COMBO_NEGCPJENDSEQ.ONOPTIONCLICKED") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           E140Y2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E110Y2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E150Y2 ();
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
                        sEvtType = StringUtil.Right( sEvt, 4);
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
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
            E150Y2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0Y37( ) ;
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
            DisableAttributes0Y37( ) ;
         }
         AssignProp("", false, edtavCombonegcliid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombonegcliid_Enabled), 5, 0), true);
         AssignProp("", false, edtavCombonegcpjid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombonegcpjid_Enabled), 5, 0), true);
         AssignProp("", false, edtavCombonegcpjendseq_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombonegcpjendseq_Enabled), 5, 0), true);
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

      protected void CONFIRM_0Y0( )
      {
         BeforeValidate0Y37( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0Y37( ) ;
            }
            else
            {
               CheckExtendedTable0Y37( ) ;
               CloseExtendedTableCursors0Y37( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode37 = Gx_mode;
            CONFIRM_0Y42( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode37;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               IsConfirmed = 1;
               AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
            }
            /* Restore parent mode. */
            Gx_mode = sMode37;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
      }

      protected void CONFIRM_0Y42( )
      {
         s454NegUltItem = O454NegUltItem;
         n454NegUltItem = false;
         AssignAttri("", false, "A454NegUltItem", StringUtil.LTrimStr( (decimal)(A454NegUltItem), 8, 0));
         s448NegPgpTotal = O448NegPgpTotal;
         n448NegPgpTotal = false;
         AssignAttri("", false, "A448NegPgpTotal", StringUtil.LTrimStr( A448NegPgpTotal, 16, 2));
         s380NegValorEstimado = O380NegValorEstimado;
         AssignAttri("", false, "A380NegValorEstimado", StringUtil.LTrimStr( A380NegValorEstimado, 16, 2));
         s385NegValorAtualizado = O385NegValorAtualizado;
         AssignAttri("", false, "A385NegValorAtualizado", StringUtil.LTrimStr( A385NegValorAtualizado, 16, 2));
         nGXsfl_73_idx = 0;
         while ( nGXsfl_73_idx < nRC_GXsfl_73 )
         {
            ReadRow0Y42( ) ;
            if ( ( nRcdExists_42 != 0 ) || ( nIsMod_42 != 0 ) )
            {
               GetKey0Y42( ) ;
               if ( ( nRcdExists_42 == 0 ) && ( nRcdDeleted_42 == 0 ) )
               {
                  if ( RcdFound42 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate0Y42( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0Y42( ) ;
                        CloseExtendedTableCursors0Y42( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                        O454NegUltItem = A454NegUltItem;
                        n454NegUltItem = false;
                        AssignAttri("", false, "A454NegUltItem", StringUtil.LTrimStr( (decimal)(A454NegUltItem), 8, 0));
                        O448NegPgpTotal = A448NegPgpTotal;
                        n448NegPgpTotal = false;
                        AssignAttri("", false, "A448NegPgpTotal", StringUtil.LTrimStr( A448NegPgpTotal, 16, 2));
                        O380NegValorEstimado = A380NegValorEstimado;
                        AssignAttri("", false, "A380NegValorEstimado", StringUtil.LTrimStr( A380NegValorEstimado, 16, 2));
                        O385NegValorAtualizado = A385NegValorAtualizado;
                        AssignAttri("", false, "A385NegValorAtualizado", StringUtil.LTrimStr( A385NegValorAtualizado, 16, 2));
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                     AnyError = 1;
                  }
               }
               else
               {
                  if ( RcdFound42 != 0 )
                  {
                     if ( nRcdDeleted_42 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey0Y42( ) ;
                        Load0Y42( ) ;
                        BeforeValidate0Y42( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0Y42( ) ;
                           O454NegUltItem = A454NegUltItem;
                           n454NegUltItem = false;
                           AssignAttri("", false, "A454NegUltItem", StringUtil.LTrimStr( (decimal)(A454NegUltItem), 8, 0));
                           O448NegPgpTotal = A448NegPgpTotal;
                           n448NegPgpTotal = false;
                           AssignAttri("", false, "A448NegPgpTotal", StringUtil.LTrimStr( A448NegPgpTotal, 16, 2));
                           O380NegValorEstimado = A380NegValorEstimado;
                           AssignAttri("", false, "A380NegValorEstimado", StringUtil.LTrimStr( A380NegValorEstimado, 16, 2));
                           O385NegValorAtualizado = A385NegValorAtualizado;
                           AssignAttri("", false, "A385NegValorAtualizado", StringUtil.LTrimStr( A385NegValorAtualizado, 16, 2));
                        }
                     }
                     else
                     {
                        if ( nIsMod_42 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate0Y42( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0Y42( ) ;
                              CloseExtendedTableCursors0Y42( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                              O454NegUltItem = A454NegUltItem;
                              n454NegUltItem = false;
                              AssignAttri("", false, "A454NegUltItem", StringUtil.LTrimStr( (decimal)(A454NegUltItem), 8, 0));
                              O448NegPgpTotal = A448NegPgpTotal;
                              n448NegPgpTotal = false;
                              AssignAttri("", false, "A448NegPgpTotal", StringUtil.LTrimStr( A448NegPgpTotal, 16, 2));
                              O380NegValorEstimado = A380NegValorEstimado;
                              AssignAttri("", false, "A380NegValorEstimado", StringUtil.LTrimStr( A380NegValorEstimado, 16, 2));
                              O385NegValorAtualizado = A385NegValorAtualizado;
                              AssignAttri("", false, "A385NegValorAtualizado", StringUtil.LTrimStr( A385NegValorAtualizado, 16, 2));
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_42 == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            ChangePostValue( edtNgpItem_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A435NgpItem), 10, 0, ",", ""))) ;
            ChangePostValue( edtNgpTppID_Internalname, A478NgpTppID.ToString()) ;
            ChangePostValue( dynNgpTppPrdID_Internalname, A439NgpTppPrdID.ToString()) ;
            ChangePostValue( edtNgpTpp1Preco_Internalname, StringUtil.LTrim( StringUtil.NToC( A444NgpTpp1Preco, 23, 2, ",", ""))) ;
            ChangePostValue( edtNgpPreco_Internalname, StringUtil.LTrim( StringUtil.NToC( A445NgpPreco, 23, 2, ",", ""))) ;
            ChangePostValue( edtNgpQtde_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A446NgpQtde), 8, 0, ",", ""))) ;
            ChangePostValue( edtNgpTotal_Internalname, StringUtil.LTrim( StringUtil.NToC( A447NgpTotal, 23, 2, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z435NgpItem_"+sGXsfl_73_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z435NgpItem), 8, 0, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z447NgpTotal_"+sGXsfl_73_idx, StringUtil.LTrim( StringUtil.NToC( Z447NgpTotal, 16, 2, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z446NgpQtde_"+sGXsfl_73_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z446NgpQtde), 8, 0, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z445NgpPreco_"+sGXsfl_73_idx, StringUtil.LTrim( StringUtil.NToC( Z445NgpPreco, 16, 2, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z457NgpInsDataHora_"+sGXsfl_73_idx, context.localUtil.TToC( Z457NgpInsDataHora, 10, 12, 0, 0, "/", ":", " ")) ;
            ChangePostValue( "ZT_"+"Z455NgpInsData_"+sGXsfl_73_idx, context.localUtil.DToC( Z455NgpInsData, 0, "/")) ;
            ChangePostValue( "ZT_"+"Z456NgpInsHora_"+sGXsfl_73_idx, context.localUtil.TToC( Z456NgpInsHora, 10, 8, 0, 0, "/", ":", " ")) ;
            ChangePostValue( "ZT_"+"Z458NgpInsUsuID_"+sGXsfl_73_idx, StringUtil.RTrim( Z458NgpInsUsuID)) ;
            ChangePostValue( "ZT_"+"Z459NgpInsUsuNome_"+sGXsfl_73_idx, Z459NgpInsUsuNome) ;
            ChangePostValue( "ZT_"+"Z579NgpDelDataHora_"+sGXsfl_73_idx, context.localUtil.TToC( Z579NgpDelDataHora, 10, 12, 0, 0, "/", ":", " ")) ;
            ChangePostValue( "ZT_"+"Z580NgpDelData_"+sGXsfl_73_idx, context.localUtil.TToC( Z580NgpDelData, 10, 8, 0, 0, "/", ":", " ")) ;
            ChangePostValue( "ZT_"+"Z581NgpDelHora_"+sGXsfl_73_idx, context.localUtil.TToC( Z581NgpDelHora, 10, 8, 0, 0, "/", ":", " ")) ;
            ChangePostValue( "ZT_"+"Z582NgpDelUsuId_"+sGXsfl_73_idx, StringUtil.RTrim( Z582NgpDelUsuId)) ;
            ChangePostValue( "ZT_"+"Z583NgpDelUsuNome_"+sGXsfl_73_idx, Z583NgpDelUsuNome) ;
            ChangePostValue( "ZT_"+"Z453NgpObs_"+sGXsfl_73_idx, Z453NgpObs) ;
            ChangePostValue( "ZT_"+"Z578NgpDel_"+sGXsfl_73_idx, StringUtil.BoolToStr( Z578NgpDel)) ;
            ChangePostValue( "ZT_"+"Z439NgpTppPrdID_"+sGXsfl_73_idx, Z439NgpTppPrdID.ToString()) ;
            ChangePostValue( "ZT_"+"Z478NgpTppID_"+sGXsfl_73_idx, Z478NgpTppID.ToString()) ;
            ChangePostValue( "T578NgpDel_"+sGXsfl_73_idx, StringUtil.BoolToStr( O578NgpDel)) ;
            ChangePostValue( "T447NgpTotal_"+sGXsfl_73_idx, StringUtil.LTrim( StringUtil.NToC( O447NgpTotal, 16, 2, ",", ""))) ;
            ChangePostValue( "nRcdDeleted_42_"+sGXsfl_73_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_42), 4, 0, ",", ""))) ;
            ChangePostValue( "nRcdExists_42_"+sGXsfl_73_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_42), 4, 0, ",", ""))) ;
            ChangePostValue( "nIsMod_42_"+sGXsfl_73_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_42), 4, 0, ",", ""))) ;
            if ( nIsMod_42 != 0 )
            {
               ChangePostValue( "NGPITEM_"+sGXsfl_73_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNgpItem_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "NGPTPPID_"+sGXsfl_73_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNgpTppID_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "NGPTPPPRDID_"+sGXsfl_73_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynNgpTppPrdID.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "NGPTPP1PRECO_"+sGXsfl_73_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNgpTpp1Preco_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "NGPPRECO_"+sGXsfl_73_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNgpPreco_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "NGPQTDE_"+sGXsfl_73_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNgpQtde_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "NGPTOTAL_"+sGXsfl_73_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNgpTotal_Enabled), 5, 0, ".", ""))) ;
            }
         }
         O454NegUltItem = s454NegUltItem;
         n454NegUltItem = false;
         AssignAttri("", false, "A454NegUltItem", StringUtil.LTrimStr( (decimal)(A454NegUltItem), 8, 0));
         O448NegPgpTotal = s448NegPgpTotal;
         n448NegPgpTotal = false;
         AssignAttri("", false, "A448NegPgpTotal", StringUtil.LTrimStr( A448NegPgpTotal, 16, 2));
         O380NegValorEstimado = s380NegValorEstimado;
         AssignAttri("", false, "A380NegValorEstimado", StringUtil.LTrimStr( A380NegValorEstimado, 16, 2));
         O385NegValorAtualizado = s385NegValorAtualizado;
         AssignAttri("", false, "A385NegValorAtualizado", StringUtil.LTrimStr( A385NegValorAtualizado, 16, 2));
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption0Y0( )
      {
      }

      protected void E110Y2( )
      {
         /* Start Routine */
         returnInSub = false;
         new prcdebugtofile(context ).execute(  AV49Pgmname,  StringUtil.Format( "Event Start - &Mode: %1 e &NegID: %2", Gx_mode, AV7NegID.ToString(), "", "", "", "", "", "", "")) ;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV17DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV17DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getstyleddvcombo(context ).execute(  "Title and subtitle", out  GXt_char2) ;
         Combo_ngptppid_Htmltemplate = GXt_char2;
         ucCombo_ngptppid.SendProperty(context, "", false, Combo_ngptppid_Internalname, "HTMLTemplate", Combo_ngptppid_Htmltemplate);
         Combo_ngptppid_Titlecontrolidtoreplace = edtNgpTppID_Internalname;
         ucCombo_ngptppid.SendProperty(context, "", false, Combo_ngptppid_Internalname, "TitleControlIdToReplace", Combo_ngptppid_Titlecontrolidtoreplace);
         AV23GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV24GAMErrors);
         Combo_negcpjendseq_Gamoauthtoken = AV23GAMSession.gxTpr_Token;
         ucCombo_negcpjendseq.SendProperty(context, "", false, Combo_negcpjendseq_Internalname, "GAMOAuthToken", Combo_negcpjendseq_Gamoauthtoken);
         edtNegCpjEndSeq_Visible = 0;
         AssignProp("", false, edtNegCpjEndSeq_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtNegCpjEndSeq_Visible), 5, 0), true);
         AV44ComboNegCpjEndSeq = 0;
         AssignAttri("", false, "AV44ComboNegCpjEndSeq", StringUtil.LTrimStr( (decimal)(AV44ComboNegCpjEndSeq), 4, 0));
         edtavCombonegcpjendseq_Visible = 0;
         AssignProp("", false, edtavCombonegcpjendseq_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombonegcpjendseq_Visible), 5, 0), true);
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getstyleddvcombo(context ).execute(  "Title and subtitle", out  GXt_char2) ;
         Combo_negcpjendseq_Htmltemplate = GXt_char2;
         ucCombo_negcpjendseq.SendProperty(context, "", false, Combo_negcpjendseq_Internalname, "HTMLTemplate", Combo_negcpjendseq_Htmltemplate);
         Combo_negcpjid_Gamoauthtoken = AV23GAMSession.gxTpr_Token;
         ucCombo_negcpjid.SendProperty(context, "", false, Combo_negcpjid_Internalname, "GAMOAuthToken", Combo_negcpjid_Gamoauthtoken);
         edtNegCpjID_Visible = 0;
         AssignProp("", false, edtNegCpjID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtNegCpjID_Visible), 5, 0), true);
         AV42ComboNegCpjID = Guid.Empty;
         AssignAttri("", false, "AV42ComboNegCpjID", AV42ComboNegCpjID.ToString());
         edtavCombonegcpjid_Visible = 0;
         AssignProp("", false, edtavCombonegcpjid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombonegcpjid_Visible), 5, 0), true);
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getstyleddvcombo(context ).execute(  "Title and subtitle", out  GXt_char2) ;
         Combo_negcpjid_Htmltemplate = GXt_char2;
         ucCombo_negcpjid.SendProperty(context, "", false, Combo_negcpjid_Internalname, "HTMLTemplate", Combo_negcpjid_Htmltemplate);
         edtNegCliID_Visible = 0;
         AssignProp("", false, edtNegCliID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtNegCliID_Visible), 5, 0), true);
         AV41ComboNegCliID = Guid.Empty;
         AssignAttri("", false, "AV41ComboNegCliID", AV41ComboNegCliID.ToString());
         edtavCombonegcliid_Visible = 0;
         AssignProp("", false, edtavCombonegcliid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombonegcliid_Visible), 5, 0), true);
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getstyleddvcombo(context ).execute(  "Title and subtitle", out  GXt_char2) ;
         Combo_negcliid_Htmltemplate = GXt_char2;
         ucCombo_negcliid.SendProperty(context, "", false, Combo_negcliid_Internalname, "HTMLTemplate", Combo_negcliid_Htmltemplate);
         /* Execute user subroutine: 'LOADCOMBONEGCLIID' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBONEGCPJID' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBONEGCPJENDSEQ' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBONGPTPPID' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV49Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV50GXV1 = 1;
            AssignAttri("", false, "AV50GXV1", StringUtil.LTrimStr( (decimal)(AV50GXV1), 8, 0));
            while ( AV50GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV15TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV50GXV1));
               if ( StringUtil.StrCmp(AV15TrnContextAtt.gxTpr_Attributename, "NegCliID") == 0 )
               {
                  AV13Insert_NegCliID = StringUtil.StrToGuid( AV15TrnContextAtt.gxTpr_Attributevalue);
                  AssignAttri("", false, "AV13Insert_NegCliID", AV13Insert_NegCliID.ToString());
                  if ( ! (Guid.Empty==AV13Insert_NegCliID) )
                  {
                     AV41ComboNegCliID = AV13Insert_NegCliID;
                     AssignAttri("", false, "AV41ComboNegCliID", AV41ComboNegCliID.ToString());
                     Combo_negcliid_Selectedvalue_set = StringUtil.Trim( AV41ComboNegCliID.ToString());
                     ucCombo_negcliid.SendProperty(context, "", false, Combo_negcliid_Internalname, "SelectedValue_set", Combo_negcliid_Selectedvalue_set);
                     Combo_negcliid_Enabled = false;
                     ucCombo_negcliid.SendProperty(context, "", false, Combo_negcliid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_negcliid_Enabled));
                  }
               }
               else if ( StringUtil.StrCmp(AV15TrnContextAtt.gxTpr_Attributename, "NegCpjID") == 0 )
               {
                  AV14Insert_NegCpjID = StringUtil.StrToGuid( AV15TrnContextAtt.gxTpr_Attributevalue);
                  AssignAttri("", false, "AV14Insert_NegCpjID", AV14Insert_NegCpjID.ToString());
                  if ( ! (Guid.Empty==AV14Insert_NegCpjID) )
                  {
                     AV42ComboNegCpjID = AV14Insert_NegCpjID;
                     AssignAttri("", false, "AV42ComboNegCpjID", AV42ComboNegCpjID.ToString());
                     Combo_negcpjid_Selectedvalue_set = StringUtil.Trim( AV42ComboNegCpjID.ToString());
                     ucCombo_negcpjid.SendProperty(context, "", false, Combo_negcpjid_Internalname, "SelectedValue_set", Combo_negcpjid_Selectedvalue_set);
                     GXt_char2 = AV20Combo_DataJson;
                     new GeneXus.Programs.core.negociopjloaddvcombo(context ).execute(  "NegCpjID",  "GET",  false,  AV7NegID,  A350NegCliID,  A352NegCpjID,  AV15TrnContextAtt.gxTpr_Attributevalue, out  AV18ComboSelectedValue, out  AV19ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV18ComboSelectedValue", AV18ComboSelectedValue);
                     AssignAttri("", false, "AV19ComboSelectedText", AV19ComboSelectedText);
                     AV20Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV20Combo_DataJson", AV20Combo_DataJson);
                     Combo_negcpjid_Selectedtext_set = AV19ComboSelectedText;
                     ucCombo_negcpjid.SendProperty(context, "", false, Combo_negcpjid_Internalname, "SelectedText_set", Combo_negcpjid_Selectedtext_set);
                     Combo_negcpjid_Enabled = false;
                     ucCombo_negcpjid.SendProperty(context, "", false, Combo_negcpjid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_negcpjid_Enabled));
                  }
               }
               else if ( StringUtil.StrCmp(AV15TrnContextAtt.gxTpr_Attributename, "NegCpjEndSeq") == 0 )
               {
                  AV28Insert_NegCpjEndSeq = (short)(Math.Round(NumberUtil.Val( AV15TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV28Insert_NegCpjEndSeq", StringUtil.LTrimStr( (decimal)(AV28Insert_NegCpjEndSeq), 4, 0));
                  if ( ! (0==AV28Insert_NegCpjEndSeq) )
                  {
                     AV44ComboNegCpjEndSeq = AV28Insert_NegCpjEndSeq;
                     AssignAttri("", false, "AV44ComboNegCpjEndSeq", StringUtil.LTrimStr( (decimal)(AV44ComboNegCpjEndSeq), 4, 0));
                     Combo_negcpjendseq_Selectedvalue_set = StringUtil.Trim( StringUtil.Str( (decimal)(AV44ComboNegCpjEndSeq), 4, 0));
                     ucCombo_negcpjendseq.SendProperty(context, "", false, Combo_negcpjendseq_Internalname, "SelectedValue_set", Combo_negcpjendseq_Selectedvalue_set);
                     GXt_char2 = AV20Combo_DataJson;
                     new GeneXus.Programs.core.negociopjloaddvcombo(context ).execute(  "NegCpjEndSeq",  "GET",  false,  AV7NegID,  A350NegCliID,  A352NegCpjID,  AV15TrnContextAtt.gxTpr_Attributevalue, out  AV18ComboSelectedValue, out  AV19ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV18ComboSelectedValue", AV18ComboSelectedValue);
                     AssignAttri("", false, "AV19ComboSelectedText", AV19ComboSelectedText);
                     AV20Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV20Combo_DataJson", AV20Combo_DataJson);
                     Combo_negcpjendseq_Selectedtext_set = AV19ComboSelectedText;
                     ucCombo_negcpjendseq.SendProperty(context, "", false, Combo_negcpjendseq_Internalname, "SelectedText_set", Combo_negcpjendseq_Selectedtext_set);
                     Combo_negcpjendseq_Enabled = false;
                     ucCombo_negcpjendseq.SendProperty(context, "", false, Combo_negcpjendseq_Internalname, "Enabled", StringUtil.BoolToStr( Combo_negcpjendseq_Enabled));
                  }
               }
               AV50GXV1 = (int)(AV50GXV1+1);
               AssignAttri("", false, "AV50GXV1", StringUtil.LTrimStr( (decimal)(AV50GXV1), 8, 0));
            }
         }
      }

      protected void E150Y2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.audittransaction(context ).execute(  AV47AuditingObject,  AV49Pgmname) ;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("core.negociopjww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void E140Y2( )
      {
         /* Combo_negcpjendseq_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Combo_negcpjendseq_Selectedvalue_get, "<#NEW#>") == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "core.clientepjendereco.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(A350NegCliID.ToString()) + "," + UrlEncode(A352NegCpjID.ToString()) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0));
            context.PopUp(formatLink("core.clientepjendereco.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
         }
         else if ( StringUtil.StrCmp(Combo_negcpjendseq_Selectedvalue_get, "<#POPUP_CLOSED#>") == 0 )
         {
            AV18ComboSelectedValue = AV12WebSession.Get("CPJENDSEQ");
            AssignAttri("", false, "AV18ComboSelectedValue", AV18ComboSelectedValue);
            AV12WebSession.Remove("CPJENDSEQ");
            Combo_negcpjendseq_Selectedvalue_set = AV18ComboSelectedValue;
            ucCombo_negcpjendseq.SendProperty(context, "", false, Combo_negcpjendseq_Internalname, "SelectedValue_set", Combo_negcpjendseq_Selectedvalue_set);
            AV44ComboNegCpjEndSeq = (short)(Math.Round(NumberUtil.Val( AV18ComboSelectedValue, "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV44ComboNegCpjEndSeq", StringUtil.LTrimStr( (decimal)(AV44ComboNegCpjEndSeq), 4, 0));
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18ComboSelectedValue)) )
            {
               Combo_negcpjendseq_Selectedtext_set = AV12WebSession.Get("CPJENDCOMPLETO");
               ucCombo_negcpjendseq.SendProperty(context, "", false, Combo_negcpjendseq_Internalname, "SelectedText_set", Combo_negcpjendseq_Selectedtext_set);
               AV12WebSession.Remove("CPJENDCOMPLETO");
            }
            else
            {
               Combo_negcpjendseq_Selectedtext_set = "  ";
               ucCombo_negcpjendseq.SendProperty(context, "", false, Combo_negcpjendseq_Internalname, "SelectedText_set", Combo_negcpjendseq_Selectedtext_set);
            }
         }
         else
         {
            AV44ComboNegCpjEndSeq = (short)(Math.Round(NumberUtil.Val( Combo_negcpjendseq_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV44ComboNegCpjEndSeq", StringUtil.LTrimStr( (decimal)(AV44ComboNegCpjEndSeq), 4, 0));
         }
         /*  Sending Event outputs  */
      }

      protected void E130Y2( )
      {
         /* Combo_negcpjid_Onoptionclicked Routine */
         returnInSub = false;
         AV45Cond_NegCpjID = A352NegCpjID;
         if ( StringUtil.StrCmp(Combo_negcpjid_Selectedvalue_get, "<#NEW#>") == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "core.clientepj.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(A350NegCliID.ToString()) + "," + UrlEncode(Guid.Empty.ToString());
            context.PopUp(formatLink("core.clientepj.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
         }
         else if ( StringUtil.StrCmp(Combo_negcpjid_Selectedvalue_get, "<#POPUP_CLOSED#>") == 0 )
         {
            AV18ComboSelectedValue = AV12WebSession.Get("CPJID");
            AssignAttri("", false, "AV18ComboSelectedValue", AV18ComboSelectedValue);
            AV12WebSession.Remove("CPJID");
            Combo_negcpjid_Selectedvalue_set = AV18ComboSelectedValue;
            ucCombo_negcpjid.SendProperty(context, "", false, Combo_negcpjid_Internalname, "SelectedValue_set", Combo_negcpjid_Selectedvalue_set);
            AV42ComboNegCpjID = StringUtil.StrToGuid( AV18ComboSelectedValue);
            AssignAttri("", false, "AV42ComboNegCpjID", AV42ComboNegCpjID.ToString());
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18ComboSelectedValue)) )
            {
               Combo_negcpjid_Selectedtext_set = AV12WebSession.Get("CPJNOMEFAN");
               ucCombo_negcpjid.SendProperty(context, "", false, Combo_negcpjid_Internalname, "SelectedText_set", Combo_negcpjid_Selectedtext_set);
               AV12WebSession.Remove("CPJNOMEFAN");
            }
            else
            {
               Combo_negcpjid_Selectedtext_set = " ";
               ucCombo_negcpjid.SendProperty(context, "", false, Combo_negcpjid_Internalname, "SelectedText_set", Combo_negcpjid_Selectedtext_set);
            }
         }
         else
         {
            AV42ComboNegCpjID = StringUtil.StrToGuid( Combo_negcpjid_Selectedvalue_get);
            AssignAttri("", false, "AV42ComboNegCpjID", AV42ComboNegCpjID.ToString());
         }
         if ( AV45Cond_NegCpjID != AV42ComboNegCpjID )
         {
            AV44ComboNegCpjEndSeq = 0;
            AssignAttri("", false, "AV44ComboNegCpjEndSeq", StringUtil.LTrimStr( (decimal)(AV44ComboNegCpjEndSeq), 4, 0));
            Combo_negcpjendseq_Selectedvalue_set = "";
            ucCombo_negcpjendseq.SendProperty(context, "", false, Combo_negcpjendseq_Internalname, "SelectedValue_set", Combo_negcpjendseq_Selectedvalue_set);
            Combo_negcpjendseq_Selectedtext_set = "";
            ucCombo_negcpjendseq.SendProperty(context, "", false, Combo_negcpjendseq_Internalname, "SelectedText_set", Combo_negcpjendseq_Selectedtext_set);
         }
         /*  Sending Event outputs  */
      }

      protected void E120Y2( )
      {
         /* Combo_negcliid_Onoptionclicked Routine */
         returnInSub = false;
         AV43Cond_NegCliID = A350NegCliID;
         if ( StringUtil.StrCmp(Combo_negcliid_Selectedvalue_get, "<#NEW#>") == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "core.cliente.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(Guid.Empty.ToString());
            context.PopUp(formatLink("core.cliente.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
         }
         else if ( StringUtil.StrCmp(Combo_negcliid_Selectedvalue_get, "<#POPUP_CLOSED#>") == 0 )
         {
            GXt_char2 = AV20Combo_DataJson;
            new GeneXus.Programs.core.negociopjloaddvcombo(context ).execute(  "NegCliID",  "NEW",  false,  AV7NegID,  A350NegCliID,  A352NegCpjID,  "", out  AV18ComboSelectedValue, out  AV19ComboSelectedText, out  GXt_char2) ;
            AssignAttri("", false, "AV18ComboSelectedValue", AV18ComboSelectedValue);
            AssignAttri("", false, "AV19ComboSelectedText", AV19ComboSelectedText);
            AV20Combo_DataJson = GXt_char2;
            AssignAttri("", false, "AV20Combo_DataJson", AV20Combo_DataJson);
            AV16NegCliID_Data.FromJSonString(AV20Combo_DataJson, null);
            AV18ComboSelectedValue = AV12WebSession.Get("CLIID");
            AssignAttri("", false, "AV18ComboSelectedValue", AV18ComboSelectedValue);
            AV12WebSession.Remove("CLIID");
            Combo_negcliid_Selectedvalue_set = AV18ComboSelectedValue;
            ucCombo_negcliid.SendProperty(context, "", false, Combo_negcliid_Internalname, "SelectedValue_set", Combo_negcliid_Selectedvalue_set);
            AV41ComboNegCliID = StringUtil.StrToGuid( AV18ComboSelectedValue);
            AssignAttri("", false, "AV41ComboNegCliID", AV41ComboNegCliID.ToString());
         }
         else
         {
            AV41ComboNegCliID = StringUtil.StrToGuid( Combo_negcliid_Selectedvalue_get);
            AssignAttri("", false, "AV41ComboNegCliID", AV41ComboNegCliID.ToString());
            GXt_char2 = AV20Combo_DataJson;
            new GeneXus.Programs.core.negociopjloaddvcombo(context ).execute(  "NegCliID",  "NEW",  false,  AV7NegID,  A350NegCliID,  A352NegCpjID,  "", out  AV18ComboSelectedValue, out  AV19ComboSelectedText, out  GXt_char2) ;
            AssignAttri("", false, "AV18ComboSelectedValue", AV18ComboSelectedValue);
            AssignAttri("", false, "AV19ComboSelectedText", AV19ComboSelectedText);
            AV20Combo_DataJson = GXt_char2;
            AssignAttri("", false, "AV20Combo_DataJson", AV20Combo_DataJson);
            AV16NegCliID_Data.FromJSonString(AV20Combo_DataJson, null);
         }
         if ( AV43Cond_NegCliID != AV41ComboNegCliID )
         {
            AV42ComboNegCpjID = Guid.Empty;
            AssignAttri("", false, "AV42ComboNegCpjID", AV42ComboNegCpjID.ToString());
            Combo_negcpjid_Selectedvalue_set = "";
            ucCombo_negcpjid.SendProperty(context, "", false, Combo_negcpjid_Internalname, "SelectedValue_set", Combo_negcpjid_Selectedvalue_set);
            Combo_negcpjid_Selectedtext_set = "";
            ucCombo_negcpjid.SendProperty(context, "", false, Combo_negcpjid_Internalname, "SelectedText_set", Combo_negcpjid_Selectedtext_set);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV16NegCliID_Data", AV16NegCliID_Data);
      }

      protected void S142( )
      {
         /* 'LOADCOMBONGPTPPID' Routine */
         returnInSub = false;
         GXt_char2 = AV20Combo_DataJson;
         new GeneXus.Programs.core.negociopjloaddvcombo(context ).execute(  "NgpTppID",  Gx_mode,  false,  AV7NegID,  A350NegCliID,  A352NegCpjID,  "", out  AV18ComboSelectedValue, out  AV19ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV18ComboSelectedValue", AV18ComboSelectedValue);
         AssignAttri("", false, "AV19ComboSelectedText", AV19ComboSelectedText);
         AV20Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV20Combo_DataJson", AV20Combo_DataJson);
         AV40NgpTppID_Data.FromJSonString(AV20Combo_DataJson, null);
      }

      protected void S132( )
      {
         /* 'LOADCOMBONEGCPJENDSEQ' Routine */
         returnInSub = false;
         GXt_boolean3 = false;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "clientepjendereco_Insert", out  GXt_boolean3) ;
         Combo_negcpjendseq_Includeaddnewoption = GXt_boolean3;
         ucCombo_negcpjendseq.SendProperty(context, "", false, Combo_negcpjendseq_Internalname, "IncludeAddNewOption", StringUtil.BoolToStr( Combo_negcpjendseq_Includeaddnewoption));
         Combo_negcpjendseq_Datalistprocparametersprefix = StringUtil.Format( " \"ComboName\": \"NegCpjEndSeq\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"NegID\": \"00000000-0000-0000-0000-000000000000\", \"Cond_NegCliID\": \"#%1#\", \"Cond_NegCpjID\": \"#%2#\"", edtNegCliID_Internalname, edtNegCpjID_Internalname, "", "", "", "", "", "", "");
         ucCombo_negcpjendseq.SendProperty(context, "", false, Combo_negcpjendseq_Internalname, "DataListProcParametersPrefix", Combo_negcpjendseq_Datalistprocparametersprefix);
         GXt_char2 = AV20Combo_DataJson;
         new GeneXus.Programs.core.negociopjloaddvcombo(context ).execute(  "NegCpjEndSeq",  Gx_mode,  false,  AV7NegID,  A350NegCliID,  A352NegCpjID,  "", out  AV18ComboSelectedValue, out  AV19ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV18ComboSelectedValue", AV18ComboSelectedValue);
         AssignAttri("", false, "AV19ComboSelectedText", AV19ComboSelectedText);
         AV20Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV20Combo_DataJson", AV20Combo_DataJson);
         Combo_negcpjendseq_Selectedvalue_set = AV18ComboSelectedValue;
         ucCombo_negcpjendseq.SendProperty(context, "", false, Combo_negcpjendseq_Internalname, "SelectedValue_set", Combo_negcpjendseq_Selectedvalue_set);
         Combo_negcpjendseq_Selectedtext_set = AV19ComboSelectedText;
         ucCombo_negcpjendseq.SendProperty(context, "", false, Combo_negcpjendseq_Internalname, "SelectedText_set", Combo_negcpjendseq_Selectedtext_set);
         AV44ComboNegCpjEndSeq = (short)(Math.Round(NumberUtil.Val( AV18ComboSelectedValue, "."), 18, MidpointRounding.ToEven));
         AssignAttri("", false, "AV44ComboNegCpjEndSeq", StringUtil.LTrimStr( (decimal)(AV44ComboNegCpjEndSeq), 4, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_negcpjendseq_Enabled = false;
            ucCombo_negcpjendseq.SendProperty(context, "", false, Combo_negcpjendseq_Internalname, "Enabled", StringUtil.BoolToStr( Combo_negcpjendseq_Enabled));
         }
      }

      protected void S122( )
      {
         /* 'LOADCOMBONEGCPJID' Routine */
         returnInSub = false;
         GXt_boolean3 = false;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "clientepj_Insert", out  GXt_boolean3) ;
         Combo_negcpjid_Includeaddnewoption = GXt_boolean3;
         ucCombo_negcpjid.SendProperty(context, "", false, Combo_negcpjid_Internalname, "IncludeAddNewOption", StringUtil.BoolToStr( Combo_negcpjid_Includeaddnewoption));
         Combo_negcpjid_Datalistprocparametersprefix = StringUtil.Format( " \"ComboName\": \"NegCpjID\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"NegID\": \"00000000-0000-0000-0000-000000000000\", \"Cond_NegCliID\": \"#%1#\", \"Cond_NegCpjID\": \"#%2#\"", edtNegCliID_Internalname, edtNegCpjID_Internalname, "", "", "", "", "", "", "");
         ucCombo_negcpjid.SendProperty(context, "", false, Combo_negcpjid_Internalname, "DataListProcParametersPrefix", Combo_negcpjid_Datalistprocparametersprefix);
         GXt_char2 = AV20Combo_DataJson;
         new GeneXus.Programs.core.negociopjloaddvcombo(context ).execute(  "NegCpjID",  Gx_mode,  false,  AV7NegID,  A350NegCliID,  A352NegCpjID,  "", out  AV18ComboSelectedValue, out  AV19ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV18ComboSelectedValue", AV18ComboSelectedValue);
         AssignAttri("", false, "AV19ComboSelectedText", AV19ComboSelectedText);
         AV20Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV20Combo_DataJson", AV20Combo_DataJson);
         Combo_negcpjid_Selectedvalue_set = AV18ComboSelectedValue;
         ucCombo_negcpjid.SendProperty(context, "", false, Combo_negcpjid_Internalname, "SelectedValue_set", Combo_negcpjid_Selectedvalue_set);
         Combo_negcpjid_Selectedtext_set = AV19ComboSelectedText;
         ucCombo_negcpjid.SendProperty(context, "", false, Combo_negcpjid_Internalname, "SelectedText_set", Combo_negcpjid_Selectedtext_set);
         AV42ComboNegCpjID = StringUtil.StrToGuid( AV18ComboSelectedValue);
         AssignAttri("", false, "AV42ComboNegCpjID", AV42ComboNegCpjID.ToString());
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_negcpjid_Enabled = false;
            ucCombo_negcpjid.SendProperty(context, "", false, Combo_negcpjid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_negcpjid_Enabled));
         }
      }

      protected void S112( )
      {
         /* 'LOADCOMBONEGCLIID' Routine */
         returnInSub = false;
         GXt_boolean3 = false;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "cliente_Insert", out  GXt_boolean3) ;
         Combo_negcliid_Includeaddnewoption = GXt_boolean3;
         ucCombo_negcliid.SendProperty(context, "", false, Combo_negcliid_Internalname, "IncludeAddNewOption", StringUtil.BoolToStr( Combo_negcliid_Includeaddnewoption));
         GXt_char2 = AV20Combo_DataJson;
         new GeneXus.Programs.core.negociopjloaddvcombo(context ).execute(  "NegCliID",  Gx_mode,  false,  AV7NegID,  A350NegCliID,  A352NegCpjID,  "", out  AV18ComboSelectedValue, out  AV19ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV18ComboSelectedValue", AV18ComboSelectedValue);
         AssignAttri("", false, "AV19ComboSelectedText", AV19ComboSelectedText);
         AV20Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV20Combo_DataJson", AV20Combo_DataJson);
         AV16NegCliID_Data.FromJSonString(AV20Combo_DataJson, null);
         Combo_negcliid_Selectedvalue_set = AV18ComboSelectedValue;
         ucCombo_negcliid.SendProperty(context, "", false, Combo_negcliid_Internalname, "SelectedValue_set", Combo_negcliid_Selectedvalue_set);
         AV41ComboNegCliID = StringUtil.StrToGuid( AV18ComboSelectedValue);
         AssignAttri("", false, "AV41ComboNegCliID", AV41ComboNegCliID.ToString());
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_negcliid_Enabled = false;
            ucCombo_negcliid.SendProperty(context, "", false, Combo_negcliid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_negcliid_Enabled));
         }
      }

      protected void ZM0Y37( short GX_JID )
      {
         if ( ( GX_JID == 68 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z356NegCodigo = T000Y7_A356NegCodigo[0];
               Z348NegInsDataHora = T000Y7_A348NegInsDataHora[0];
               Z346NegInsData = T000Y7_A346NegInsData[0];
               Z347NegInsHora = T000Y7_A347NegInsHora[0];
               Z349NegInsUsuID = T000Y7_A349NegInsUsuID[0];
               Z364NegInsUsuNome = T000Y7_A364NegInsUsuNome[0];
               Z385NegValorAtualizado = T000Y7_A385NegValorAtualizado[0];
               Z380NegValorEstimado = T000Y7_A380NegValorEstimado[0];
               Z573NegDelDataHora = T000Y7_A573NegDelDataHora[0];
               Z574NegDelData = T000Y7_A574NegDelData[0];
               Z575NegDelHora = T000Y7_A575NegDelHora[0];
               Z576NegDelUsuId = T000Y7_A576NegDelUsuId[0];
               Z577NegDelUsuNome = T000Y7_A577NegDelUsuNome[0];
               Z360NegAgcID = T000Y7_A360NegAgcID[0];
               Z361NegAgcNome = T000Y7_A361NegAgcNome[0];
               Z362NegAssunto = T000Y7_A362NegAssunto[0];
               Z454NegUltItem = T000Y7_A454NegUltItem[0];
               Z572NegDel = T000Y7_A572NegDel[0];
               Z350NegCliID = T000Y7_A350NegCliID[0];
               Z352NegCpjID = T000Y7_A352NegCpjID[0];
               Z369NegCpjEndSeq = T000Y7_A369NegCpjEndSeq[0];
            }
            else
            {
               Z356NegCodigo = A356NegCodigo;
               Z348NegInsDataHora = A348NegInsDataHora;
               Z346NegInsData = A346NegInsData;
               Z347NegInsHora = A347NegInsHora;
               Z349NegInsUsuID = A349NegInsUsuID;
               Z364NegInsUsuNome = A364NegInsUsuNome;
               Z385NegValorAtualizado = A385NegValorAtualizado;
               Z380NegValorEstimado = A380NegValorEstimado;
               Z573NegDelDataHora = A573NegDelDataHora;
               Z574NegDelData = A574NegDelData;
               Z575NegDelHora = A575NegDelHora;
               Z576NegDelUsuId = A576NegDelUsuId;
               Z577NegDelUsuNome = A577NegDelUsuNome;
               Z360NegAgcID = A360NegAgcID;
               Z361NegAgcNome = A361NegAgcNome;
               Z362NegAssunto = A362NegAssunto;
               Z454NegUltItem = A454NegUltItem;
               Z572NegDel = A572NegDel;
               Z350NegCliID = A350NegCliID;
               Z352NegCpjID = A352NegCpjID;
               Z369NegCpjEndSeq = A369NegCpjEndSeq;
            }
         }
         if ( GX_JID == -68 )
         {
            Z345NegID = A345NegID;
            Z356NegCodigo = A356NegCodigo;
            Z348NegInsDataHora = A348NegInsDataHora;
            Z346NegInsData = A346NegInsData;
            Z347NegInsHora = A347NegInsHora;
            Z349NegInsUsuID = A349NegInsUsuID;
            Z364NegInsUsuNome = A364NegInsUsuNome;
            Z385NegValorAtualizado = A385NegValorAtualizado;
            Z380NegValorEstimado = A380NegValorEstimado;
            Z573NegDelDataHora = A573NegDelDataHora;
            Z574NegDelData = A574NegDelData;
            Z575NegDelHora = A575NegDelHora;
            Z576NegDelUsuId = A576NegDelUsuId;
            Z577NegDelUsuNome = A577NegDelUsuNome;
            Z351NegCliNomeFamiliar = A351NegCliNomeFamiliar;
            Z353NegCpjNomFan = A353NegCpjNomFan;
            Z354NegCpjRazSocial = A354NegCpjRazSocial;
            Z359NegPjtNome = A359NegPjtNome;
            Z360NegAgcID = A360NegAgcID;
            Z361NegAgcNome = A361NegAgcNome;
            Z362NegAssunto = A362NegAssunto;
            Z363NegDescricao = A363NegDescricao;
            Z454NegUltItem = A454NegUltItem;
            Z572NegDel = A572NegDel;
            Z350NegCliID = A350NegCliID;
            Z352NegCpjID = A352NegCpjID;
            Z369NegCpjEndSeq = A369NegCpjEndSeq;
            Z448NegPgpTotal = A448NegPgpTotal;
            Z473NegCliMatricula = A473NegCliMatricula;
            Z355NegCpjMatricula = A355NegCpjMatricula;
            Z357NegPjtID = A357NegPjtID;
            Z358NegPjtSigla = A358NegPjtSigla;
            Z370NegCpjEndNome = A370NegCpjEndNome;
            Z371NegCpjEndEndereco = A371NegCpjEndEndereco;
            Z372NegCpjEndNumero = A372NegCpjEndNumero;
            Z373NegCpjEndComplem = A373NegCpjEndComplem;
            Z374NegCpjEndBairro = A374NegCpjEndBairro;
            Z642NegCpjEndCep = A642NegCpjEndCep;
            Z643NegCpjEndCepFormat = A643NegCpjEndCepFormat;
            Z375NegCpjEndMunID = A375NegCpjEndMunID;
            Z376NegCpjEndMunNome = A376NegCpjEndMunNome;
            Z377NegCpjEndUFID = A377NegCpjEndUFID;
            Z378NegCpjEndUFSigla = A378NegCpjEndUFSigla;
            Z379NegCpjEndUFNome = A379NegCpjEndUFNome;
         }
      }

      protected void standaloneNotModal( )
      {
         edtNegCodigo_Enabled = 0;
         AssignProp("", false, edtNegCodigo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNegCodigo_Enabled), 5, 0), true);
         edtNegValorEstimado_Enabled = 0;
         AssignProp("", false, edtNegValorEstimado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNegValorEstimado_Enabled), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         edtNegCodigo_Enabled = 0;
         AssignProp("", false, edtNegCodigo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNegCodigo_Enabled), 5, 0), true);
         edtNegValorEstimado_Enabled = 0;
         AssignProp("", false, edtNegValorEstimado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNegValorEstimado_Enabled), 5, 0), true);
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV13Insert_NegCliID) )
         {
            edtNegCliID_Enabled = 0;
            AssignProp("", false, edtNegCliID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNegCliID_Enabled), 5, 0), true);
         }
         else
         {
            edtNegCliID_Enabled = 1;
            AssignProp("", false, edtNegCliID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNegCliID_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV14Insert_NegCpjID) )
         {
            edtNegCpjID_Enabled = 0;
            AssignProp("", false, edtNegCpjID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNegCpjID_Enabled), 5, 0), true);
         }
         else
         {
            edtNegCpjID_Enabled = 1;
            AssignProp("", false, edtNegCpjID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNegCpjID_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV28Insert_NegCpjEndSeq) )
         {
            edtNegCpjEndSeq_Enabled = 0;
            AssignProp("", false, edtNegCpjEndSeq_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNegCpjEndSeq_Enabled), 5, 0), true);
         }
         else
         {
            edtNegCpjEndSeq_Enabled = 1;
            AssignProp("", false, edtNegCpjEndSeq_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNegCpjEndSeq_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV13Insert_NegCliID) )
         {
            A350NegCliID = AV13Insert_NegCliID;
            AssignAttri("", false, "A350NegCliID", A350NegCliID.ToString());
         }
         else
         {
            A350NegCliID = AV41ComboNegCliID;
            AssignAttri("", false, "A350NegCliID", A350NegCliID.ToString());
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV14Insert_NegCpjID) )
         {
            A352NegCpjID = AV14Insert_NegCpjID;
            AssignAttri("", false, "A352NegCpjID", A352NegCpjID.ToString());
         }
         else
         {
            A352NegCpjID = AV42ComboNegCpjID;
            AssignAttri("", false, "A352NegCpjID", A352NegCpjID.ToString());
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV28Insert_NegCpjEndSeq) )
         {
            A369NegCpjEndSeq = AV28Insert_NegCpjEndSeq;
            AssignAttri("", false, "A369NegCpjEndSeq", StringUtil.LTrimStr( (decimal)(A369NegCpjEndSeq), 4, 0));
         }
         else
         {
            A369NegCpjEndSeq = AV44ComboNegCpjEndSeq;
            AssignAttri("", false, "A369NegCpjEndSeq", StringUtil.LTrimStr( (decimal)(A369NegCpjEndSeq), 4, 0));
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
         if ( ! (Guid.Empty==AV7NegID) )
         {
            A345NegID = AV7NegID;
            AssignAttri("", false, "A345NegID", A345NegID.ToString());
         }
         else
         {
            if ( IsIns( )  && (Guid.Empty==A345NegID) && ( Gx_BScreen == 0 ) )
            {
               A345NegID = Guid.NewGuid( );
               AssignAttri("", false, "A345NegID", A345NegID.ToString());
            }
         }
         /* Using cursor T000Y13 */
         pr_default.execute(10, new Object[] {A345NegID});
         if ( (pr_default.getStatus(10) != 101) )
         {
            A448NegPgpTotal = T000Y13_A448NegPgpTotal[0];
            n448NegPgpTotal = T000Y13_n448NegPgpTotal[0];
         }
         else
         {
            A448NegPgpTotal = 0;
            n448NegPgpTotal = false;
            AssignAttri("", false, "A448NegPgpTotal", StringUtil.LTrimStr( A448NegPgpTotal, 16, 2));
         }
         O448NegPgpTotal = A448NegPgpTotal;
         n448NegPgpTotal = false;
         AssignAttri("", false, "A448NegPgpTotal", StringUtil.LTrimStr( A448NegPgpTotal, 16, 2));
         pr_default.close(10);
         A385NegValorAtualizado = A448NegPgpTotal;
         AssignAttri("", false, "A385NegValorAtualizado", StringUtil.LTrimStr( A385NegValorAtualizado, 16, 2));
         A380NegValorEstimado = A448NegPgpTotal;
         AssignAttri("", false, "A380NegValorEstimado", StringUtil.LTrimStr( A380NegValorEstimado, 16, 2));
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            AV49Pgmname = "core.NegocioPJ";
            AssignAttri("", false, "AV49Pgmname", AV49Pgmname);
            /* Using cursor T000Y8 */
            pr_default.execute(6, new Object[] {A350NegCliID});
            A473NegCliMatricula = T000Y8_A473NegCliMatricula[0];
            A351NegCliNomeFamiliar = T000Y8_A351NegCliNomeFamiliar[0];
            pr_default.close(6);
            /* Using cursor T000Y9 */
            pr_default.execute(7, new Object[] {A350NegCliID, A352NegCpjID});
            A353NegCpjNomFan = T000Y9_A353NegCpjNomFan[0];
            A354NegCpjRazSocial = T000Y9_A354NegCpjRazSocial[0];
            A355NegCpjMatricula = T000Y9_A355NegCpjMatricula[0];
            A357NegPjtID = T000Y9_A357NegPjtID[0];
            pr_default.close(7);
            /* Using cursor T000Y11 */
            pr_default.execute(9, new Object[] {A357NegPjtID});
            A358NegPjtSigla = T000Y11_A358NegPjtSigla[0];
            A359NegPjtNome = T000Y11_A359NegPjtNome[0];
            pr_default.close(9);
            /* Using cursor T000Y10 */
            pr_default.execute(8, new Object[] {A350NegCliID, A352NegCpjID, A369NegCpjEndSeq});
            A370NegCpjEndNome = T000Y10_A370NegCpjEndNome[0];
            A371NegCpjEndEndereco = T000Y10_A371NegCpjEndEndereco[0];
            A372NegCpjEndNumero = T000Y10_A372NegCpjEndNumero[0];
            A373NegCpjEndComplem = T000Y10_A373NegCpjEndComplem[0];
            n373NegCpjEndComplem = T000Y10_n373NegCpjEndComplem[0];
            A374NegCpjEndBairro = T000Y10_A374NegCpjEndBairro[0];
            A642NegCpjEndCep = T000Y10_A642NegCpjEndCep[0];
            A643NegCpjEndCepFormat = T000Y10_A643NegCpjEndCepFormat[0];
            A375NegCpjEndMunID = T000Y10_A375NegCpjEndMunID[0];
            A376NegCpjEndMunNome = T000Y10_A376NegCpjEndMunNome[0];
            A377NegCpjEndUFID = T000Y10_A377NegCpjEndUFID[0];
            A378NegCpjEndUFSigla = T000Y10_A378NegCpjEndUFSigla[0];
            A379NegCpjEndUFNome = T000Y10_A379NegCpjEndUFNome[0];
            pr_default.close(8);
            if ( String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A372NegCpjEndNumero))) && String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A373NegCpjEndComplem))) )
            {
               A641NegCpjEndCompleto = StringUtil.Trim( A371NegCpjEndEndereco) + " - " + StringUtil.Trim( A374NegCpjEndBairro) + " - " + StringUtil.Trim( A643NegCpjEndCepFormat) + " - " + StringUtil.Trim( A376NegCpjEndMunNome) + " - " + StringUtil.Trim( A378NegCpjEndUFSigla);
               AssignAttri("", false, "A641NegCpjEndCompleto", A641NegCpjEndCompleto);
            }
            else
            {
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A372NegCpjEndNumero))) && String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A373NegCpjEndComplem))) )
               {
                  A641NegCpjEndCompleto = StringUtil.Trim( A371NegCpjEndEndereco) + ", " + StringUtil.Trim( A372NegCpjEndNumero) + " - " + StringUtil.Trim( A374NegCpjEndBairro) + " - " + StringUtil.Trim( A643NegCpjEndCepFormat) + " - " + StringUtil.Trim( A376NegCpjEndMunNome) + " - " + StringUtil.Trim( A378NegCpjEndUFSigla);
                  AssignAttri("", false, "A641NegCpjEndCompleto", A641NegCpjEndCompleto);
               }
               else
               {
                  if ( String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A372NegCpjEndNumero))) && ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A373NegCpjEndComplem))) )
                  {
                     A641NegCpjEndCompleto = StringUtil.Trim( A371NegCpjEndEndereco) + ", " + StringUtil.Trim( A372NegCpjEndNumero) + " - " + StringUtil.Trim( A374NegCpjEndBairro) + " - " + StringUtil.Trim( A643NegCpjEndCepFormat) + " - " + StringUtil.Trim( A376NegCpjEndMunNome) + " - " + StringUtil.Trim( A378NegCpjEndUFSigla);
                     AssignAttri("", false, "A641NegCpjEndCompleto", A641NegCpjEndCompleto);
                  }
                  else
                  {
                     A641NegCpjEndCompleto = StringUtil.Trim( A371NegCpjEndEndereco) + ", " + StringUtil.Trim( A372NegCpjEndNumero) + " " + StringUtil.Trim( A373NegCpjEndComplem) + " - " + StringUtil.Trim( A374NegCpjEndBairro) + " - " + StringUtil.Trim( A643NegCpjEndCepFormat) + " - " + StringUtil.Trim( A376NegCpjEndMunNome) + " - " + StringUtil.Trim( A378NegCpjEndUFSigla);
                     AssignAttri("", false, "A641NegCpjEndCompleto", A641NegCpjEndCompleto);
                  }
               }
            }
         }
      }

      protected void Load0Y37( )
      {
         /* Using cursor T000Y15 */
         pr_default.execute(11, new Object[] {A345NegID});
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound37 = 1;
            A356NegCodigo = T000Y15_A356NegCodigo[0];
            AssignAttri("", false, "A356NegCodigo", StringUtil.LTrimStr( (decimal)(A356NegCodigo), 12, 0));
            A348NegInsDataHora = T000Y15_A348NegInsDataHora[0];
            A346NegInsData = T000Y15_A346NegInsData[0];
            A347NegInsHora = T000Y15_A347NegInsHora[0];
            A349NegInsUsuID = T000Y15_A349NegInsUsuID[0];
            n349NegInsUsuID = T000Y15_n349NegInsUsuID[0];
            A364NegInsUsuNome = T000Y15_A364NegInsUsuNome[0];
            n364NegInsUsuNome = T000Y15_n364NegInsUsuNome[0];
            A385NegValorAtualizado = T000Y15_A385NegValorAtualizado[0];
            A380NegValorEstimado = T000Y15_A380NegValorEstimado[0];
            AssignAttri("", false, "A380NegValorEstimado", StringUtil.LTrimStr( A380NegValorEstimado, 16, 2));
            A573NegDelDataHora = T000Y15_A573NegDelDataHora[0];
            n573NegDelDataHora = T000Y15_n573NegDelDataHora[0];
            A574NegDelData = T000Y15_A574NegDelData[0];
            n574NegDelData = T000Y15_n574NegDelData[0];
            A575NegDelHora = T000Y15_A575NegDelHora[0];
            n575NegDelHora = T000Y15_n575NegDelHora[0];
            A576NegDelUsuId = T000Y15_A576NegDelUsuId[0];
            n576NegDelUsuId = T000Y15_n576NegDelUsuId[0];
            A577NegDelUsuNome = T000Y15_A577NegDelUsuNome[0];
            n577NegDelUsuNome = T000Y15_n577NegDelUsuNome[0];
            A473NegCliMatricula = T000Y15_A473NegCliMatricula[0];
            A351NegCliNomeFamiliar = T000Y15_A351NegCliNomeFamiliar[0];
            A353NegCpjNomFan = T000Y15_A353NegCpjNomFan[0];
            A354NegCpjRazSocial = T000Y15_A354NegCpjRazSocial[0];
            A355NegCpjMatricula = T000Y15_A355NegCpjMatricula[0];
            A358NegPjtSigla = T000Y15_A358NegPjtSigla[0];
            A359NegPjtNome = T000Y15_A359NegPjtNome[0];
            A370NegCpjEndNome = T000Y15_A370NegCpjEndNome[0];
            A371NegCpjEndEndereco = T000Y15_A371NegCpjEndEndereco[0];
            A372NegCpjEndNumero = T000Y15_A372NegCpjEndNumero[0];
            A373NegCpjEndComplem = T000Y15_A373NegCpjEndComplem[0];
            n373NegCpjEndComplem = T000Y15_n373NegCpjEndComplem[0];
            A374NegCpjEndBairro = T000Y15_A374NegCpjEndBairro[0];
            A642NegCpjEndCep = T000Y15_A642NegCpjEndCep[0];
            A643NegCpjEndCepFormat = T000Y15_A643NegCpjEndCepFormat[0];
            A375NegCpjEndMunID = T000Y15_A375NegCpjEndMunID[0];
            A376NegCpjEndMunNome = T000Y15_A376NegCpjEndMunNome[0];
            A377NegCpjEndUFID = T000Y15_A377NegCpjEndUFID[0];
            A378NegCpjEndUFSigla = T000Y15_A378NegCpjEndUFSigla[0];
            A379NegCpjEndUFNome = T000Y15_A379NegCpjEndUFNome[0];
            A360NegAgcID = T000Y15_A360NegAgcID[0];
            n360NegAgcID = T000Y15_n360NegAgcID[0];
            A361NegAgcNome = T000Y15_A361NegAgcNome[0];
            n361NegAgcNome = T000Y15_n361NegAgcNome[0];
            A362NegAssunto = T000Y15_A362NegAssunto[0];
            AssignAttri("", false, "A362NegAssunto", A362NegAssunto);
            A363NegDescricao = T000Y15_A363NegDescricao[0];
            A454NegUltItem = T000Y15_A454NegUltItem[0];
            n454NegUltItem = T000Y15_n454NegUltItem[0];
            A572NegDel = T000Y15_A572NegDel[0];
            A350NegCliID = T000Y15_A350NegCliID[0];
            AssignAttri("", false, "A350NegCliID", A350NegCliID.ToString());
            A352NegCpjID = T000Y15_A352NegCpjID[0];
            AssignAttri("", false, "A352NegCpjID", A352NegCpjID.ToString());
            A369NegCpjEndSeq = T000Y15_A369NegCpjEndSeq[0];
            AssignAttri("", false, "A369NegCpjEndSeq", StringUtil.LTrimStr( (decimal)(A369NegCpjEndSeq), 4, 0));
            A357NegPjtID = T000Y15_A357NegPjtID[0];
            A448NegPgpTotal = T000Y15_A448NegPgpTotal[0];
            n448NegPgpTotal = T000Y15_n448NegPgpTotal[0];
            ZM0Y37( -68) ;
         }
         pr_default.close(11);
         OnLoadActions0Y37( ) ;
      }

      protected void OnLoadActions0Y37( )
      {
         O448NegPgpTotal = A448NegPgpTotal;
         n448NegPgpTotal = false;
         AssignAttri("", false, "A448NegPgpTotal", StringUtil.LTrimStr( A448NegPgpTotal, 16, 2));
         AV49Pgmname = "core.NegocioPJ";
         AssignAttri("", false, "AV49Pgmname", AV49Pgmname);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A372NegCpjEndNumero))) && String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A373NegCpjEndComplem))) )
         {
            A641NegCpjEndCompleto = StringUtil.Trim( A371NegCpjEndEndereco) + " - " + StringUtil.Trim( A374NegCpjEndBairro) + " - " + StringUtil.Trim( A643NegCpjEndCepFormat) + " - " + StringUtil.Trim( A376NegCpjEndMunNome) + " - " + StringUtil.Trim( A378NegCpjEndUFSigla);
            AssignAttri("", false, "A641NegCpjEndCompleto", A641NegCpjEndCompleto);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A372NegCpjEndNumero))) && String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A373NegCpjEndComplem))) )
            {
               A641NegCpjEndCompleto = StringUtil.Trim( A371NegCpjEndEndereco) + ", " + StringUtil.Trim( A372NegCpjEndNumero) + " - " + StringUtil.Trim( A374NegCpjEndBairro) + " - " + StringUtil.Trim( A643NegCpjEndCepFormat) + " - " + StringUtil.Trim( A376NegCpjEndMunNome) + " - " + StringUtil.Trim( A378NegCpjEndUFSigla);
               AssignAttri("", false, "A641NegCpjEndCompleto", A641NegCpjEndCompleto);
            }
            else
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A372NegCpjEndNumero))) && ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A373NegCpjEndComplem))) )
               {
                  A641NegCpjEndCompleto = StringUtil.Trim( A371NegCpjEndEndereco) + ", " + StringUtil.Trim( A372NegCpjEndNumero) + " - " + StringUtil.Trim( A374NegCpjEndBairro) + " - " + StringUtil.Trim( A643NegCpjEndCepFormat) + " - " + StringUtil.Trim( A376NegCpjEndMunNome) + " - " + StringUtil.Trim( A378NegCpjEndUFSigla);
                  AssignAttri("", false, "A641NegCpjEndCompleto", A641NegCpjEndCompleto);
               }
               else
               {
                  A641NegCpjEndCompleto = StringUtil.Trim( A371NegCpjEndEndereco) + ", " + StringUtil.Trim( A372NegCpjEndNumero) + " " + StringUtil.Trim( A373NegCpjEndComplem) + " - " + StringUtil.Trim( A374NegCpjEndBairro) + " - " + StringUtil.Trim( A643NegCpjEndCepFormat) + " - " + StringUtil.Trim( A376NegCpjEndMunNome) + " - " + StringUtil.Trim( A378NegCpjEndUFSigla);
                  AssignAttri("", false, "A641NegCpjEndCompleto", A641NegCpjEndCompleto);
               }
            }
         }
      }

      protected void CheckExtendedTable0Y37( )
      {
         nIsDirty_37 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         AV49Pgmname = "core.NegocioPJ";
         AssignAttri("", false, "AV49Pgmname", AV49Pgmname);
         /* Using cursor T000Y8 */
         pr_default.execute(6, new Object[] {A350NegCliID});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("Não existe 'Cliente PJ -> Negocio PJ'.", "ForeignKeyNotFound", 1, "NEGCLIID");
            AnyError = 1;
            GX_FocusControl = edtNegCliID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A473NegCliMatricula = T000Y8_A473NegCliMatricula[0];
         A351NegCliNomeFamiliar = T000Y8_A351NegCliNomeFamiliar[0];
         pr_default.close(6);
         /* Using cursor T000Y9 */
         pr_default.execute(7, new Object[] {A350NegCliID, A352NegCpjID});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem("Não existe 'Cliente PJ -> Negocio PJ'.", "ForeignKeyNotFound", 1, "NEGCPJID");
            AnyError = 1;
            GX_FocusControl = edtNegCliID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A353NegCpjNomFan = T000Y9_A353NegCpjNomFan[0];
         A354NegCpjRazSocial = T000Y9_A354NegCpjRazSocial[0];
         A355NegCpjMatricula = T000Y9_A355NegCpjMatricula[0];
         A357NegPjtID = T000Y9_A357NegPjtID[0];
         pr_default.close(7);
         /* Using cursor T000Y11 */
         pr_default.execute(9, new Object[] {A357NegPjtID});
         if ( (pr_default.getStatus(9) == 101) )
         {
            GX_msglist.addItem("Não existe ''.", "ForeignKeyNotFound", 1, "NEGPJTID");
            AnyError = 1;
         }
         A358NegPjtSigla = T000Y11_A358NegPjtSigla[0];
         A359NegPjtNome = T000Y11_A359NegPjtNome[0];
         pr_default.close(9);
         /* Using cursor T000Y10 */
         pr_default.execute(8, new Object[] {A350NegCliID, A352NegCpjID, A369NegCpjEndSeq});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("Não existe 'Cliente PJ -> Negocio PJ'.", "ForeignKeyNotFound", 1, "NEGCPJENDSEQ");
            AnyError = 1;
            GX_FocusControl = edtNegCliID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A370NegCpjEndNome = T000Y10_A370NegCpjEndNome[0];
         A371NegCpjEndEndereco = T000Y10_A371NegCpjEndEndereco[0];
         A372NegCpjEndNumero = T000Y10_A372NegCpjEndNumero[0];
         A373NegCpjEndComplem = T000Y10_A373NegCpjEndComplem[0];
         n373NegCpjEndComplem = T000Y10_n373NegCpjEndComplem[0];
         A374NegCpjEndBairro = T000Y10_A374NegCpjEndBairro[0];
         A642NegCpjEndCep = T000Y10_A642NegCpjEndCep[0];
         A643NegCpjEndCepFormat = T000Y10_A643NegCpjEndCepFormat[0];
         A375NegCpjEndMunID = T000Y10_A375NegCpjEndMunID[0];
         A376NegCpjEndMunNome = T000Y10_A376NegCpjEndMunNome[0];
         A377NegCpjEndUFID = T000Y10_A377NegCpjEndUFID[0];
         A378NegCpjEndUFSigla = T000Y10_A378NegCpjEndUFSigla[0];
         A379NegCpjEndUFNome = T000Y10_A379NegCpjEndUFNome[0];
         pr_default.close(8);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A372NegCpjEndNumero))) && String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A373NegCpjEndComplem))) )
         {
            nIsDirty_37 = 1;
            A641NegCpjEndCompleto = StringUtil.Trim( A371NegCpjEndEndereco) + " - " + StringUtil.Trim( A374NegCpjEndBairro) + " - " + StringUtil.Trim( A643NegCpjEndCepFormat) + " - " + StringUtil.Trim( A376NegCpjEndMunNome) + " - " + StringUtil.Trim( A378NegCpjEndUFSigla);
            AssignAttri("", false, "A641NegCpjEndCompleto", A641NegCpjEndCompleto);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A372NegCpjEndNumero))) && String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A373NegCpjEndComplem))) )
            {
               nIsDirty_37 = 1;
               A641NegCpjEndCompleto = StringUtil.Trim( A371NegCpjEndEndereco) + ", " + StringUtil.Trim( A372NegCpjEndNumero) + " - " + StringUtil.Trim( A374NegCpjEndBairro) + " - " + StringUtil.Trim( A643NegCpjEndCepFormat) + " - " + StringUtil.Trim( A376NegCpjEndMunNome) + " - " + StringUtil.Trim( A378NegCpjEndUFSigla);
               AssignAttri("", false, "A641NegCpjEndCompleto", A641NegCpjEndCompleto);
            }
            else
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A372NegCpjEndNumero))) && ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A373NegCpjEndComplem))) )
               {
                  nIsDirty_37 = 1;
                  A641NegCpjEndCompleto = StringUtil.Trim( A371NegCpjEndEndereco) + ", " + StringUtil.Trim( A372NegCpjEndNumero) + " - " + StringUtil.Trim( A374NegCpjEndBairro) + " - " + StringUtil.Trim( A643NegCpjEndCepFormat) + " - " + StringUtil.Trim( A376NegCpjEndMunNome) + " - " + StringUtil.Trim( A378NegCpjEndUFSigla);
                  AssignAttri("", false, "A641NegCpjEndCompleto", A641NegCpjEndCompleto);
               }
               else
               {
                  nIsDirty_37 = 1;
                  A641NegCpjEndCompleto = StringUtil.Trim( A371NegCpjEndEndereco) + ", " + StringUtil.Trim( A372NegCpjEndNumero) + " " + StringUtil.Trim( A373NegCpjEndComplem) + " - " + StringUtil.Trim( A374NegCpjEndBairro) + " - " + StringUtil.Trim( A643NegCpjEndCepFormat) + " - " + StringUtil.Trim( A376NegCpjEndMunNome) + " - " + StringUtil.Trim( A378NegCpjEndUFSigla);
                  AssignAttri("", false, "A641NegCpjEndCompleto", A641NegCpjEndCompleto);
               }
            }
         }
         if ( (Guid.Empty==A350NegCliID) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Cliente ID", "", "", "", "", "", "", "", ""), 1, "NEGCLIID");
            AnyError = 1;
            GX_FocusControl = edtNegCliID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( (Guid.Empty==A352NegCpjID) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "ID da Unidade", "", "", "", "", "", "", "", ""), 1, "NEGCPJID");
            AnyError = 1;
            GX_FocusControl = edtNegCpjID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( (0==A369NegCpjEndSeq) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Sequência do Endereço", "", "", "", "", "", "", "", ""), 1, "NEGCPJENDSEQ");
            AnyError = 1;
            GX_FocusControl = edtNegCpjEndSeq_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A362NegAssunto)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Assunto da Negociação", "", "", "", "", "", "", "", ""), 1, "NEGASSUNTO");
            AnyError = 1;
            GX_FocusControl = edtNegAssunto_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T000Y16 */
         pr_default.execute(12, new Object[] {A356NegCodigo, A345NegID});
         if ( (pr_default.getStatus(12) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Código da Negociação"}), 1, "NEGCODIGO");
            AnyError = 1;
            GX_FocusControl = edtNegCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(12);
      }

      protected void CloseExtendedTableCursors0Y37( )
      {
         pr_default.close(6);
         pr_default.close(7);
         pr_default.close(9);
         pr_default.close(8);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_70( Guid A350NegCliID )
      {
         /* Using cursor T000Y17 */
         pr_default.execute(13, new Object[] {A350NegCliID});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("Não existe 'Cliente PJ -> Negocio PJ'.", "ForeignKeyNotFound", 1, "NEGCLIID");
            AnyError = 1;
            GX_FocusControl = edtNegCliID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A473NegCliMatricula = T000Y17_A473NegCliMatricula[0];
         A351NegCliNomeFamiliar = T000Y17_A351NegCliNomeFamiliar[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A473NegCliMatricula), 12, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( A351NegCliNomeFamiliar)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(13) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(13);
      }

      protected void gxLoad_71( Guid A350NegCliID ,
                                Guid A352NegCpjID )
      {
         /* Using cursor T000Y18 */
         pr_default.execute(14, new Object[] {A350NegCliID, A352NegCpjID});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("Não existe 'Cliente PJ -> Negocio PJ'.", "ForeignKeyNotFound", 1, "NEGCPJID");
            AnyError = 1;
            GX_FocusControl = edtNegCliID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A353NegCpjNomFan = T000Y18_A353NegCpjNomFan[0];
         A354NegCpjRazSocial = T000Y18_A354NegCpjRazSocial[0];
         A355NegCpjMatricula = T000Y18_A355NegCpjMatricula[0];
         A357NegPjtID = T000Y18_A357NegPjtID[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A353NegCpjNomFan)+"\""+","+"\""+GXUtil.EncodeJSConstant( A354NegCpjRazSocial)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A355NegCpjMatricula), 12, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A357NegPjtID), 9, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(14) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(14);
      }

      protected void gxLoad_73( int A357NegPjtID )
      {
         /* Using cursor T000Y19 */
         pr_default.execute(15, new Object[] {A357NegPjtID});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("Não existe ''.", "ForeignKeyNotFound", 1, "NEGPJTID");
            AnyError = 1;
         }
         A358NegPjtSigla = T000Y19_A358NegPjtSigla[0];
         A359NegPjtNome = T000Y19_A359NegPjtNome[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A358NegPjtSigla)+"\""+","+"\""+GXUtil.EncodeJSConstant( A359NegPjtNome)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(15) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(15);
      }

      protected void gxLoad_72( Guid A350NegCliID ,
                                Guid A352NegCpjID ,
                                short A369NegCpjEndSeq )
      {
         /* Using cursor T000Y20 */
         pr_default.execute(16, new Object[] {A350NegCliID, A352NegCpjID, A369NegCpjEndSeq});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem("Não existe 'Cliente PJ -> Negocio PJ'.", "ForeignKeyNotFound", 1, "NEGCPJENDSEQ");
            AnyError = 1;
            GX_FocusControl = edtNegCliID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A370NegCpjEndNome = T000Y20_A370NegCpjEndNome[0];
         A371NegCpjEndEndereco = T000Y20_A371NegCpjEndEndereco[0];
         A372NegCpjEndNumero = T000Y20_A372NegCpjEndNumero[0];
         A373NegCpjEndComplem = T000Y20_A373NegCpjEndComplem[0];
         n373NegCpjEndComplem = T000Y20_n373NegCpjEndComplem[0];
         A374NegCpjEndBairro = T000Y20_A374NegCpjEndBairro[0];
         A642NegCpjEndCep = T000Y20_A642NegCpjEndCep[0];
         A643NegCpjEndCepFormat = T000Y20_A643NegCpjEndCepFormat[0];
         A375NegCpjEndMunID = T000Y20_A375NegCpjEndMunID[0];
         A376NegCpjEndMunNome = T000Y20_A376NegCpjEndMunNome[0];
         A377NegCpjEndUFID = T000Y20_A377NegCpjEndUFID[0];
         A378NegCpjEndUFSigla = T000Y20_A378NegCpjEndUFSigla[0];
         A379NegCpjEndUFNome = T000Y20_A379NegCpjEndUFNome[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A370NegCpjEndNome)+"\""+","+"\""+GXUtil.EncodeJSConstant( A371NegCpjEndEndereco)+"\""+","+"\""+GXUtil.EncodeJSConstant( A372NegCpjEndNumero)+"\""+","+"\""+GXUtil.EncodeJSConstant( A373NegCpjEndComplem)+"\""+","+"\""+GXUtil.EncodeJSConstant( A374NegCpjEndBairro)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A642NegCpjEndCep), 8, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( A643NegCpjEndCepFormat)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A375NegCpjEndMunID), 7, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( A376NegCpjEndMunNome)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A377NegCpjEndUFID), 2, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( A378NegCpjEndUFSigla)+"\""+","+"\""+GXUtil.EncodeJSConstant( A379NegCpjEndUFNome)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(16) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(16);
      }

      protected void GetKey0Y37( )
      {
         /* Using cursor T000Y21 */
         pr_default.execute(17, new Object[] {A345NegID});
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound37 = 1;
         }
         else
         {
            RcdFound37 = 0;
         }
         pr_default.close(17);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000Y7 */
         pr_default.execute(5, new Object[] {A345NegID});
         if ( (pr_default.getStatus(5) != 101) )
         {
            ZM0Y37( 68) ;
            RcdFound37 = 1;
            A345NegID = T000Y7_A345NegID[0];
            A356NegCodigo = T000Y7_A356NegCodigo[0];
            AssignAttri("", false, "A356NegCodigo", StringUtil.LTrimStr( (decimal)(A356NegCodigo), 12, 0));
            A348NegInsDataHora = T000Y7_A348NegInsDataHora[0];
            A346NegInsData = T000Y7_A346NegInsData[0];
            A347NegInsHora = T000Y7_A347NegInsHora[0];
            A349NegInsUsuID = T000Y7_A349NegInsUsuID[0];
            n349NegInsUsuID = T000Y7_n349NegInsUsuID[0];
            A364NegInsUsuNome = T000Y7_A364NegInsUsuNome[0];
            n364NegInsUsuNome = T000Y7_n364NegInsUsuNome[0];
            A385NegValorAtualizado = T000Y7_A385NegValorAtualizado[0];
            A380NegValorEstimado = T000Y7_A380NegValorEstimado[0];
            AssignAttri("", false, "A380NegValorEstimado", StringUtil.LTrimStr( A380NegValorEstimado, 16, 2));
            A573NegDelDataHora = T000Y7_A573NegDelDataHora[0];
            n573NegDelDataHora = T000Y7_n573NegDelDataHora[0];
            A574NegDelData = T000Y7_A574NegDelData[0];
            n574NegDelData = T000Y7_n574NegDelData[0];
            A575NegDelHora = T000Y7_A575NegDelHora[0];
            n575NegDelHora = T000Y7_n575NegDelHora[0];
            A576NegDelUsuId = T000Y7_A576NegDelUsuId[0];
            n576NegDelUsuId = T000Y7_n576NegDelUsuId[0];
            A577NegDelUsuNome = T000Y7_A577NegDelUsuNome[0];
            n577NegDelUsuNome = T000Y7_n577NegDelUsuNome[0];
            A360NegAgcID = T000Y7_A360NegAgcID[0];
            n360NegAgcID = T000Y7_n360NegAgcID[0];
            A361NegAgcNome = T000Y7_A361NegAgcNome[0];
            n361NegAgcNome = T000Y7_n361NegAgcNome[0];
            A362NegAssunto = T000Y7_A362NegAssunto[0];
            AssignAttri("", false, "A362NegAssunto", A362NegAssunto);
            A363NegDescricao = T000Y7_A363NegDescricao[0];
            A454NegUltItem = T000Y7_A454NegUltItem[0];
            n454NegUltItem = T000Y7_n454NegUltItem[0];
            A572NegDel = T000Y7_A572NegDel[0];
            A350NegCliID = T000Y7_A350NegCliID[0];
            AssignAttri("", false, "A350NegCliID", A350NegCliID.ToString());
            A352NegCpjID = T000Y7_A352NegCpjID[0];
            AssignAttri("", false, "A352NegCpjID", A352NegCpjID.ToString());
            A369NegCpjEndSeq = T000Y7_A369NegCpjEndSeq[0];
            AssignAttri("", false, "A369NegCpjEndSeq", StringUtil.LTrimStr( (decimal)(A369NegCpjEndSeq), 4, 0));
            O454NegUltItem = A454NegUltItem;
            n454NegUltItem = false;
            AssignAttri("", false, "A454NegUltItem", StringUtil.LTrimStr( (decimal)(A454NegUltItem), 8, 0));
            O572NegDel = A572NegDel;
            AssignAttri("", false, "A572NegDel", A572NegDel);
            Z345NegID = A345NegID;
            sMode37 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0Y37( ) ;
            if ( AnyError == 1 )
            {
               RcdFound37 = 0;
               InitializeNonKey0Y37( ) ;
            }
            Gx_mode = sMode37;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound37 = 0;
            InitializeNonKey0Y37( ) ;
            sMode37 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode37;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(5);
      }

      protected void getEqualNoModal( )
      {
         GetKey0Y37( ) ;
         if ( RcdFound37 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound37 = 0;
         /* Using cursor T000Y22 */
         pr_default.execute(18, new Object[] {A345NegID});
         if ( (pr_default.getStatus(18) != 101) )
         {
            while ( (pr_default.getStatus(18) != 101) && ( ( GuidUtil.Compare(T000Y22_A345NegID[0], A345NegID, 0) < 0 ) ) )
            {
               pr_default.readNext(18);
            }
            if ( (pr_default.getStatus(18) != 101) && ( ( GuidUtil.Compare(T000Y22_A345NegID[0], A345NegID, 0) > 0 ) ) )
            {
               A345NegID = T000Y22_A345NegID[0];
               RcdFound37 = 1;
            }
         }
         pr_default.close(18);
      }

      protected void move_previous( )
      {
         RcdFound37 = 0;
         /* Using cursor T000Y23 */
         pr_default.execute(19, new Object[] {A345NegID});
         if ( (pr_default.getStatus(19) != 101) )
         {
            while ( (pr_default.getStatus(19) != 101) && ( ( GuidUtil.Compare(T000Y23_A345NegID[0], A345NegID, 0) > 0 ) ) )
            {
               pr_default.readNext(19);
            }
            if ( (pr_default.getStatus(19) != 101) && ( ( GuidUtil.Compare(T000Y23_A345NegID[0], A345NegID, 0) < 0 ) ) )
            {
               A345NegID = T000Y23_A345NegID[0];
               RcdFound37 = 1;
            }
         }
         pr_default.close(19);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0Y37( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            A454NegUltItem = O454NegUltItem;
            n454NegUltItem = false;
            AssignAttri("", false, "A454NegUltItem", StringUtil.LTrimStr( (decimal)(A454NegUltItem), 8, 0));
            A448NegPgpTotal = O448NegPgpTotal;
            n448NegPgpTotal = false;
            AssignAttri("", false, "A448NegPgpTotal", StringUtil.LTrimStr( A448NegPgpTotal, 16, 2));
            A380NegValorEstimado = O380NegValorEstimado;
            AssignAttri("", false, "A380NegValorEstimado", StringUtil.LTrimStr( A380NegValorEstimado, 16, 2));
            A385NegValorAtualizado = O385NegValorAtualizado;
            AssignAttri("", false, "A385NegValorAtualizado", StringUtil.LTrimStr( A385NegValorAtualizado, 16, 2));
            GX_FocusControl = edtNegCliID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0Y37( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound37 == 1 )
            {
               if ( A345NegID != Z345NegID )
               {
                  A345NegID = Z345NegID;
                  AssignAttri("", false, "A345NegID", A345NegID.ToString());
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else if ( IsDlt( ) )
               {
                  A454NegUltItem = O454NegUltItem;
                  n454NegUltItem = false;
                  AssignAttri("", false, "A454NegUltItem", StringUtil.LTrimStr( (decimal)(A454NegUltItem), 8, 0));
                  A448NegPgpTotal = O448NegPgpTotal;
                  n448NegPgpTotal = false;
                  AssignAttri("", false, "A448NegPgpTotal", StringUtil.LTrimStr( A448NegPgpTotal, 16, 2));
                  A380NegValorEstimado = O380NegValorEstimado;
                  AssignAttri("", false, "A380NegValorEstimado", StringUtil.LTrimStr( A380NegValorEstimado, 16, 2));
                  A385NegValorAtualizado = O385NegValorAtualizado;
                  AssignAttri("", false, "A385NegValorAtualizado", StringUtil.LTrimStr( A385NegValorAtualizado, 16, 2));
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtNegCliID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  A454NegUltItem = O454NegUltItem;
                  n454NegUltItem = false;
                  AssignAttri("", false, "A454NegUltItem", StringUtil.LTrimStr( (decimal)(A454NegUltItem), 8, 0));
                  A448NegPgpTotal = O448NegPgpTotal;
                  n448NegPgpTotal = false;
                  AssignAttri("", false, "A448NegPgpTotal", StringUtil.LTrimStr( A448NegPgpTotal, 16, 2));
                  A380NegValorEstimado = O380NegValorEstimado;
                  AssignAttri("", false, "A380NegValorEstimado", StringUtil.LTrimStr( A380NegValorEstimado, 16, 2));
                  A385NegValorAtualizado = O385NegValorAtualizado;
                  AssignAttri("", false, "A385NegValorAtualizado", StringUtil.LTrimStr( A385NegValorAtualizado, 16, 2));
                  Update0Y37( ) ;
                  GX_FocusControl = edtNegCliID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A345NegID != Z345NegID )
               {
                  /* Insert record */
                  A454NegUltItem = O454NegUltItem;
                  n454NegUltItem = false;
                  AssignAttri("", false, "A454NegUltItem", StringUtil.LTrimStr( (decimal)(A454NegUltItem), 8, 0));
                  A448NegPgpTotal = O448NegPgpTotal;
                  n448NegPgpTotal = false;
                  AssignAttri("", false, "A448NegPgpTotal", StringUtil.LTrimStr( A448NegPgpTotal, 16, 2));
                  A380NegValorEstimado = O380NegValorEstimado;
                  AssignAttri("", false, "A380NegValorEstimado", StringUtil.LTrimStr( A380NegValorEstimado, 16, 2));
                  A385NegValorAtualizado = O385NegValorAtualizado;
                  AssignAttri("", false, "A385NegValorAtualizado", StringUtil.LTrimStr( A385NegValorAtualizado, 16, 2));
                  GX_FocusControl = edtNegCliID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0Y37( ) ;
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
                     A454NegUltItem = O454NegUltItem;
                     n454NegUltItem = false;
                     AssignAttri("", false, "A454NegUltItem", StringUtil.LTrimStr( (decimal)(A454NegUltItem), 8, 0));
                     A448NegPgpTotal = O448NegPgpTotal;
                     n448NegPgpTotal = false;
                     AssignAttri("", false, "A448NegPgpTotal", StringUtil.LTrimStr( A448NegPgpTotal, 16, 2));
                     A380NegValorEstimado = O380NegValorEstimado;
                     AssignAttri("", false, "A380NegValorEstimado", StringUtil.LTrimStr( A380NegValorEstimado, 16, 2));
                     A385NegValorAtualizado = O385NegValorAtualizado;
                     AssignAttri("", false, "A385NegValorAtualizado", StringUtil.LTrimStr( A385NegValorAtualizado, 16, 2));
                     GX_FocusControl = edtNegCliID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0Y37( ) ;
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
         if ( A345NegID != Z345NegID )
         {
            A345NegID = Z345NegID;
            AssignAttri("", false, "A345NegID", A345NegID.ToString());
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "");
            AnyError = 1;
         }
         else
         {
            A454NegUltItem = O454NegUltItem;
            n454NegUltItem = false;
            AssignAttri("", false, "A454NegUltItem", StringUtil.LTrimStr( (decimal)(A454NegUltItem), 8, 0));
            A448NegPgpTotal = O448NegPgpTotal;
            n448NegPgpTotal = false;
            AssignAttri("", false, "A448NegPgpTotal", StringUtil.LTrimStr( A448NegPgpTotal, 16, 2));
            A380NegValorEstimado = O380NegValorEstimado;
            AssignAttri("", false, "A380NegValorEstimado", StringUtil.LTrimStr( A380NegValorEstimado, 16, 2));
            A385NegValorAtualizado = O385NegValorAtualizado;
            AssignAttri("", false, "A385NegValorAtualizado", StringUtil.LTrimStr( A385NegValorAtualizado, 16, 2));
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtNegCliID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0Y37( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000Y6 */
            pr_default.execute(4, new Object[] {A345NegID});
            if ( (pr_default.getStatus(4) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_negociopj"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(4) == 101) || ( Z356NegCodigo != T000Y6_A356NegCodigo[0] ) || ( Z348NegInsDataHora != T000Y6_A348NegInsDataHora[0] ) || ( DateTimeUtil.ResetTime ( Z346NegInsData ) != DateTimeUtil.ResetTime ( T000Y6_A346NegInsData[0] ) ) || ( Z347NegInsHora != T000Y6_A347NegInsHora[0] ) || ( StringUtil.StrCmp(Z349NegInsUsuID, T000Y6_A349NegInsUsuID[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z364NegInsUsuNome, T000Y6_A364NegInsUsuNome[0]) != 0 ) || ( Z385NegValorAtualizado != T000Y6_A385NegValorAtualizado[0] ) || ( Z380NegValorEstimado != T000Y6_A380NegValorEstimado[0] ) || ( Z573NegDelDataHora != T000Y6_A573NegDelDataHora[0] ) || ( Z574NegDelData != T000Y6_A574NegDelData[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z575NegDelHora != T000Y6_A575NegDelHora[0] ) || ( StringUtil.StrCmp(Z576NegDelUsuId, T000Y6_A576NegDelUsuId[0]) != 0 ) || ( StringUtil.StrCmp(Z577NegDelUsuNome, T000Y6_A577NegDelUsuNome[0]) != 0 ) || ( StringUtil.StrCmp(Z360NegAgcID, T000Y6_A360NegAgcID[0]) != 0 ) || ( StringUtil.StrCmp(Z361NegAgcNome, T000Y6_A361NegAgcNome[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z362NegAssunto, T000Y6_A362NegAssunto[0]) != 0 ) || ( Z454NegUltItem != T000Y6_A454NegUltItem[0] ) || ( Z572NegDel != T000Y6_A572NegDel[0] ) || ( Z350NegCliID != T000Y6_A350NegCliID[0] ) || ( Z352NegCpjID != T000Y6_A352NegCpjID[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z369NegCpjEndSeq != T000Y6_A369NegCpjEndSeq[0] ) )
            {
               if ( Z356NegCodigo != T000Y6_A356NegCodigo[0] )
               {
                  GXUtil.WriteLog("core.negociopj:[seudo value changed for attri]"+"NegCodigo");
                  GXUtil.WriteLogRaw("Old: ",Z356NegCodigo);
                  GXUtil.WriteLogRaw("Current: ",T000Y6_A356NegCodigo[0]);
               }
               if ( Z348NegInsDataHora != T000Y6_A348NegInsDataHora[0] )
               {
                  GXUtil.WriteLog("core.negociopj:[seudo value changed for attri]"+"NegInsDataHora");
                  GXUtil.WriteLogRaw("Old: ",Z348NegInsDataHora);
                  GXUtil.WriteLogRaw("Current: ",T000Y6_A348NegInsDataHora[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z346NegInsData ) != DateTimeUtil.ResetTime ( T000Y6_A346NegInsData[0] ) )
               {
                  GXUtil.WriteLog("core.negociopj:[seudo value changed for attri]"+"NegInsData");
                  GXUtil.WriteLogRaw("Old: ",Z346NegInsData);
                  GXUtil.WriteLogRaw("Current: ",T000Y6_A346NegInsData[0]);
               }
               if ( Z347NegInsHora != T000Y6_A347NegInsHora[0] )
               {
                  GXUtil.WriteLog("core.negociopj:[seudo value changed for attri]"+"NegInsHora");
                  GXUtil.WriteLogRaw("Old: ",Z347NegInsHora);
                  GXUtil.WriteLogRaw("Current: ",T000Y6_A347NegInsHora[0]);
               }
               if ( StringUtil.StrCmp(Z349NegInsUsuID, T000Y6_A349NegInsUsuID[0]) != 0 )
               {
                  GXUtil.WriteLog("core.negociopj:[seudo value changed for attri]"+"NegInsUsuID");
                  GXUtil.WriteLogRaw("Old: ",Z349NegInsUsuID);
                  GXUtil.WriteLogRaw("Current: ",T000Y6_A349NegInsUsuID[0]);
               }
               if ( StringUtil.StrCmp(Z364NegInsUsuNome, T000Y6_A364NegInsUsuNome[0]) != 0 )
               {
                  GXUtil.WriteLog("core.negociopj:[seudo value changed for attri]"+"NegInsUsuNome");
                  GXUtil.WriteLogRaw("Old: ",Z364NegInsUsuNome);
                  GXUtil.WriteLogRaw("Current: ",T000Y6_A364NegInsUsuNome[0]);
               }
               if ( Z385NegValorAtualizado != T000Y6_A385NegValorAtualizado[0] )
               {
                  GXUtil.WriteLog("core.negociopj:[seudo value changed for attri]"+"NegValorAtualizado");
                  GXUtil.WriteLogRaw("Old: ",Z385NegValorAtualizado);
                  GXUtil.WriteLogRaw("Current: ",T000Y6_A385NegValorAtualizado[0]);
               }
               if ( Z380NegValorEstimado != T000Y6_A380NegValorEstimado[0] )
               {
                  GXUtil.WriteLog("core.negociopj:[seudo value changed for attri]"+"NegValorEstimado");
                  GXUtil.WriteLogRaw("Old: ",Z380NegValorEstimado);
                  GXUtil.WriteLogRaw("Current: ",T000Y6_A380NegValorEstimado[0]);
               }
               if ( Z573NegDelDataHora != T000Y6_A573NegDelDataHora[0] )
               {
                  GXUtil.WriteLog("core.negociopj:[seudo value changed for attri]"+"NegDelDataHora");
                  GXUtil.WriteLogRaw("Old: ",Z573NegDelDataHora);
                  GXUtil.WriteLogRaw("Current: ",T000Y6_A573NegDelDataHora[0]);
               }
               if ( Z574NegDelData != T000Y6_A574NegDelData[0] )
               {
                  GXUtil.WriteLog("core.negociopj:[seudo value changed for attri]"+"NegDelData");
                  GXUtil.WriteLogRaw("Old: ",Z574NegDelData);
                  GXUtil.WriteLogRaw("Current: ",T000Y6_A574NegDelData[0]);
               }
               if ( Z575NegDelHora != T000Y6_A575NegDelHora[0] )
               {
                  GXUtil.WriteLog("core.negociopj:[seudo value changed for attri]"+"NegDelHora");
                  GXUtil.WriteLogRaw("Old: ",Z575NegDelHora);
                  GXUtil.WriteLogRaw("Current: ",T000Y6_A575NegDelHora[0]);
               }
               if ( StringUtil.StrCmp(Z576NegDelUsuId, T000Y6_A576NegDelUsuId[0]) != 0 )
               {
                  GXUtil.WriteLog("core.negociopj:[seudo value changed for attri]"+"NegDelUsuId");
                  GXUtil.WriteLogRaw("Old: ",Z576NegDelUsuId);
                  GXUtil.WriteLogRaw("Current: ",T000Y6_A576NegDelUsuId[0]);
               }
               if ( StringUtil.StrCmp(Z577NegDelUsuNome, T000Y6_A577NegDelUsuNome[0]) != 0 )
               {
                  GXUtil.WriteLog("core.negociopj:[seudo value changed for attri]"+"NegDelUsuNome");
                  GXUtil.WriteLogRaw("Old: ",Z577NegDelUsuNome);
                  GXUtil.WriteLogRaw("Current: ",T000Y6_A577NegDelUsuNome[0]);
               }
               if ( StringUtil.StrCmp(Z360NegAgcID, T000Y6_A360NegAgcID[0]) != 0 )
               {
                  GXUtil.WriteLog("core.negociopj:[seudo value changed for attri]"+"NegAgcID");
                  GXUtil.WriteLogRaw("Old: ",Z360NegAgcID);
                  GXUtil.WriteLogRaw("Current: ",T000Y6_A360NegAgcID[0]);
               }
               if ( StringUtil.StrCmp(Z361NegAgcNome, T000Y6_A361NegAgcNome[0]) != 0 )
               {
                  GXUtil.WriteLog("core.negociopj:[seudo value changed for attri]"+"NegAgcNome");
                  GXUtil.WriteLogRaw("Old: ",Z361NegAgcNome);
                  GXUtil.WriteLogRaw("Current: ",T000Y6_A361NegAgcNome[0]);
               }
               if ( StringUtil.StrCmp(Z362NegAssunto, T000Y6_A362NegAssunto[0]) != 0 )
               {
                  GXUtil.WriteLog("core.negociopj:[seudo value changed for attri]"+"NegAssunto");
                  GXUtil.WriteLogRaw("Old: ",Z362NegAssunto);
                  GXUtil.WriteLogRaw("Current: ",T000Y6_A362NegAssunto[0]);
               }
               if ( Z454NegUltItem != T000Y6_A454NegUltItem[0] )
               {
                  GXUtil.WriteLog("core.negociopj:[seudo value changed for attri]"+"NegUltItem");
                  GXUtil.WriteLogRaw("Old: ",Z454NegUltItem);
                  GXUtil.WriteLogRaw("Current: ",T000Y6_A454NegUltItem[0]);
               }
               if ( Z572NegDel != T000Y6_A572NegDel[0] )
               {
                  GXUtil.WriteLog("core.negociopj:[seudo value changed for attri]"+"NegDel");
                  GXUtil.WriteLogRaw("Old: ",Z572NegDel);
                  GXUtil.WriteLogRaw("Current: ",T000Y6_A572NegDel[0]);
               }
               if ( Z350NegCliID != T000Y6_A350NegCliID[0] )
               {
                  GXUtil.WriteLog("core.negociopj:[seudo value changed for attri]"+"NegCliID");
                  GXUtil.WriteLogRaw("Old: ",Z350NegCliID);
                  GXUtil.WriteLogRaw("Current: ",T000Y6_A350NegCliID[0]);
               }
               if ( Z352NegCpjID != T000Y6_A352NegCpjID[0] )
               {
                  GXUtil.WriteLog("core.negociopj:[seudo value changed for attri]"+"NegCpjID");
                  GXUtil.WriteLogRaw("Old: ",Z352NegCpjID);
                  GXUtil.WriteLogRaw("Current: ",T000Y6_A352NegCpjID[0]);
               }
               if ( Z369NegCpjEndSeq != T000Y6_A369NegCpjEndSeq[0] )
               {
                  GXUtil.WriteLog("core.negociopj:[seudo value changed for attri]"+"NegCpjEndSeq");
                  GXUtil.WriteLogRaw("Old: ",Z369NegCpjEndSeq);
                  GXUtil.WriteLogRaw("Current: ",T000Y6_A369NegCpjEndSeq[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"tb_negociopj"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0Y37( )
      {
         if ( ! IsAuthorized("negocio_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0Y37( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0Y37( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0Y37( 0) ;
            CheckOptimisticConcurrency0Y37( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0Y37( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0Y37( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000Y24 */
                     pr_default.execute(20, new Object[] {A351NegCliNomeFamiliar, A353NegCpjNomFan, A354NegCpjRazSocial, A359NegPjtNome, A345NegID, A356NegCodigo, A348NegInsDataHora, A346NegInsData, A347NegInsHora, n349NegInsUsuID, A349NegInsUsuID, n364NegInsUsuNome, A364NegInsUsuNome, A385NegValorAtualizado, A380NegValorEstimado, n573NegDelDataHora, A573NegDelDataHora, n574NegDelData, A574NegDelData, n575NegDelHora, A575NegDelHora, n576NegDelUsuId, A576NegDelUsuId, n577NegDelUsuNome, A577NegDelUsuNome, n360NegAgcID, A360NegAgcID, n361NegAgcNome, A361NegAgcNome, A362NegAssunto, A363NegDescricao, n454NegUltItem, A454NegUltItem, A572NegDel, A350NegCliID, A352NegCpjID, A369NegCpjEndSeq});
                     pr_default.close(20);
                     pr_default.SmartCacheProvider.SetUpdated("tb_negociopj");
                     if ( (pr_default.getStatus(20) == 1) )
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
                           ProcessLevel0Y37( ) ;
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
               Load0Y37( ) ;
            }
            EndLevel0Y37( ) ;
         }
         CloseExtendedTableCursors0Y37( ) ;
      }

      protected void Update0Y37( )
      {
         if ( ! IsAuthorized("negocio_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0Y37( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0Y37( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0Y37( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0Y37( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0Y37( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000Y25 */
                     pr_default.execute(21, new Object[] {A351NegCliNomeFamiliar, A353NegCpjNomFan, A354NegCpjRazSocial, A359NegPjtNome, A356NegCodigo, A348NegInsDataHora, A346NegInsData, A347NegInsHora, n349NegInsUsuID, A349NegInsUsuID, n364NegInsUsuNome, A364NegInsUsuNome, A385NegValorAtualizado, A380NegValorEstimado, n573NegDelDataHora, A573NegDelDataHora, n574NegDelData, A574NegDelData, n575NegDelHora, A575NegDelHora, n576NegDelUsuId, A576NegDelUsuId, n577NegDelUsuNome, A577NegDelUsuNome, n360NegAgcID, A360NegAgcID, n361NegAgcNome, A361NegAgcNome, A362NegAssunto, A363NegDescricao, n454NegUltItem, A454NegUltItem, A572NegDel, A350NegCliID, A352NegCpjID, A369NegCpjEndSeq, A345NegID});
                     pr_default.close(21);
                     pr_default.SmartCacheProvider.SetUpdated("tb_negociopj");
                     if ( (pr_default.getStatus(21) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_negociopj"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0Y37( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0Y37( ) ;
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
            }
            EndLevel0Y37( ) ;
         }
         CloseExtendedTableCursors0Y37( ) ;
      }

      protected void DeferredUpdate0Y37( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("negocio_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0Y37( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0Y37( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0Y37( ) ;
            AfterConfirm0Y37( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0Y37( ) ;
               if ( AnyError == 0 )
               {
                  A454NegUltItem = O454NegUltItem;
                  n454NegUltItem = false;
                  AssignAttri("", false, "A454NegUltItem", StringUtil.LTrimStr( (decimal)(A454NegUltItem), 8, 0));
                  A448NegPgpTotal = O448NegPgpTotal;
                  n448NegPgpTotal = false;
                  AssignAttri("", false, "A448NegPgpTotal", StringUtil.LTrimStr( A448NegPgpTotal, 16, 2));
                  A380NegValorEstimado = O380NegValorEstimado;
                  AssignAttri("", false, "A380NegValorEstimado", StringUtil.LTrimStr( A380NegValorEstimado, 16, 2));
                  A385NegValorAtualizado = O385NegValorAtualizado;
                  AssignAttri("", false, "A385NegValorAtualizado", StringUtil.LTrimStr( A385NegValorAtualizado, 16, 2));
                  ScanStart0Y42( ) ;
                  while ( RcdFound42 != 0 )
                  {
                     getByPrimaryKey0Y42( ) ;
                     Delete0Y42( ) ;
                     ScanNext0Y42( ) ;
                     O454NegUltItem = A454NegUltItem;
                     n454NegUltItem = false;
                     AssignAttri("", false, "A454NegUltItem", StringUtil.LTrimStr( (decimal)(A454NegUltItem), 8, 0));
                     O448NegPgpTotal = A448NegPgpTotal;
                     n448NegPgpTotal = false;
                     AssignAttri("", false, "A448NegPgpTotal", StringUtil.LTrimStr( A448NegPgpTotal, 16, 2));
                     O380NegValorEstimado = A380NegValorEstimado;
                     AssignAttri("", false, "A380NegValorEstimado", StringUtil.LTrimStr( A380NegValorEstimado, 16, 2));
                     O385NegValorAtualizado = A385NegValorAtualizado;
                     AssignAttri("", false, "A385NegValorAtualizado", StringUtil.LTrimStr( A385NegValorAtualizado, 16, 2));
                  }
                  ScanEnd0Y42( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000Y26 */
                     pr_default.execute(22, new Object[] {A345NegID});
                     pr_default.close(22);
                     pr_default.SmartCacheProvider.SetUpdated("tb_negociopj");
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
         }
         sMode37 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0Y37( ) ;
         Gx_mode = sMode37;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0Y37( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV49Pgmname = "core.NegocioPJ";
            AssignAttri("", false, "AV49Pgmname", AV49Pgmname);
            /* Using cursor T000Y27 */
            pr_default.execute(23, new Object[] {A350NegCliID});
            A473NegCliMatricula = T000Y27_A473NegCliMatricula[0];
            A351NegCliNomeFamiliar = T000Y27_A351NegCliNomeFamiliar[0];
            pr_default.close(23);
            /* Using cursor T000Y28 */
            pr_default.execute(24, new Object[] {A350NegCliID, A352NegCpjID});
            A353NegCpjNomFan = T000Y28_A353NegCpjNomFan[0];
            A354NegCpjRazSocial = T000Y28_A354NegCpjRazSocial[0];
            A355NegCpjMatricula = T000Y28_A355NegCpjMatricula[0];
            A357NegPjtID = T000Y28_A357NegPjtID[0];
            pr_default.close(24);
            /* Using cursor T000Y29 */
            pr_default.execute(25, new Object[] {A357NegPjtID});
            A358NegPjtSigla = T000Y29_A358NegPjtSigla[0];
            A359NegPjtNome = T000Y29_A359NegPjtNome[0];
            pr_default.close(25);
            /* Using cursor T000Y30 */
            pr_default.execute(26, new Object[] {A350NegCliID, A352NegCpjID, A369NegCpjEndSeq});
            A370NegCpjEndNome = T000Y30_A370NegCpjEndNome[0];
            A371NegCpjEndEndereco = T000Y30_A371NegCpjEndEndereco[0];
            A372NegCpjEndNumero = T000Y30_A372NegCpjEndNumero[0];
            A373NegCpjEndComplem = T000Y30_A373NegCpjEndComplem[0];
            n373NegCpjEndComplem = T000Y30_n373NegCpjEndComplem[0];
            A374NegCpjEndBairro = T000Y30_A374NegCpjEndBairro[0];
            A642NegCpjEndCep = T000Y30_A642NegCpjEndCep[0];
            A643NegCpjEndCepFormat = T000Y30_A643NegCpjEndCepFormat[0];
            A375NegCpjEndMunID = T000Y30_A375NegCpjEndMunID[0];
            A376NegCpjEndMunNome = T000Y30_A376NegCpjEndMunNome[0];
            A377NegCpjEndUFID = T000Y30_A377NegCpjEndUFID[0];
            A378NegCpjEndUFSigla = T000Y30_A378NegCpjEndUFSigla[0];
            A379NegCpjEndUFNome = T000Y30_A379NegCpjEndUFNome[0];
            pr_default.close(26);
            if ( String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A372NegCpjEndNumero))) && String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A373NegCpjEndComplem))) )
            {
               A641NegCpjEndCompleto = StringUtil.Trim( A371NegCpjEndEndereco) + " - " + StringUtil.Trim( A374NegCpjEndBairro) + " - " + StringUtil.Trim( A643NegCpjEndCepFormat) + " - " + StringUtil.Trim( A376NegCpjEndMunNome) + " - " + StringUtil.Trim( A378NegCpjEndUFSigla);
               AssignAttri("", false, "A641NegCpjEndCompleto", A641NegCpjEndCompleto);
            }
            else
            {
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A372NegCpjEndNumero))) && String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A373NegCpjEndComplem))) )
               {
                  A641NegCpjEndCompleto = StringUtil.Trim( A371NegCpjEndEndereco) + ", " + StringUtil.Trim( A372NegCpjEndNumero) + " - " + StringUtil.Trim( A374NegCpjEndBairro) + " - " + StringUtil.Trim( A643NegCpjEndCepFormat) + " - " + StringUtil.Trim( A376NegCpjEndMunNome) + " - " + StringUtil.Trim( A378NegCpjEndUFSigla);
                  AssignAttri("", false, "A641NegCpjEndCompleto", A641NegCpjEndCompleto);
               }
               else
               {
                  if ( String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A372NegCpjEndNumero))) && ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A373NegCpjEndComplem))) )
                  {
                     A641NegCpjEndCompleto = StringUtil.Trim( A371NegCpjEndEndereco) + ", " + StringUtil.Trim( A372NegCpjEndNumero) + " - " + StringUtil.Trim( A374NegCpjEndBairro) + " - " + StringUtil.Trim( A643NegCpjEndCepFormat) + " - " + StringUtil.Trim( A376NegCpjEndMunNome) + " - " + StringUtil.Trim( A378NegCpjEndUFSigla);
                     AssignAttri("", false, "A641NegCpjEndCompleto", A641NegCpjEndCompleto);
                  }
                  else
                  {
                     A641NegCpjEndCompleto = StringUtil.Trim( A371NegCpjEndEndereco) + ", " + StringUtil.Trim( A372NegCpjEndNumero) + " " + StringUtil.Trim( A373NegCpjEndComplem) + " - " + StringUtil.Trim( A374NegCpjEndBairro) + " - " + StringUtil.Trim( A643NegCpjEndCepFormat) + " - " + StringUtil.Trim( A376NegCpjEndMunNome) + " - " + StringUtil.Trim( A378NegCpjEndUFSigla);
                     AssignAttri("", false, "A641NegCpjEndCompleto", A641NegCpjEndCompleto);
                  }
               }
            }
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000Y31 */
            pr_default.execute(27, new Object[] {A345NegID});
            if ( (pr_default.getStatus(27) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(27);
            /* Using cursor T000Y32 */
            pr_default.execute(28, new Object[] {A345NegID});
            if ( (pr_default.getStatus(28) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(28);
            /* Using cursor T000Y33 */
            pr_default.execute(29, new Object[] {A345NegID});
            if ( (pr_default.getStatus(29) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(29);
         }
      }

      protected void ProcessNestedLevel0Y42( )
      {
         s454NegUltItem = O454NegUltItem;
         n454NegUltItem = false;
         AssignAttri("", false, "A454NegUltItem", StringUtil.LTrimStr( (decimal)(A454NegUltItem), 8, 0));
         s448NegPgpTotal = O448NegPgpTotal;
         n448NegPgpTotal = false;
         AssignAttri("", false, "A448NegPgpTotal", StringUtil.LTrimStr( A448NegPgpTotal, 16, 2));
         s380NegValorEstimado = O380NegValorEstimado;
         AssignAttri("", false, "A380NegValorEstimado", StringUtil.LTrimStr( A380NegValorEstimado, 16, 2));
         s385NegValorAtualizado = O385NegValorAtualizado;
         AssignAttri("", false, "A385NegValorAtualizado", StringUtil.LTrimStr( A385NegValorAtualizado, 16, 2));
         nGXsfl_73_idx = 0;
         while ( nGXsfl_73_idx < nRC_GXsfl_73 )
         {
            ReadRow0Y42( ) ;
            if ( ( nRcdExists_42 != 0 ) || ( nIsMod_42 != 0 ) )
            {
               standaloneNotModal0Y42( ) ;
               GetKey0Y42( ) ;
               if ( ( nRcdExists_42 == 0 ) && ( nRcdDeleted_42 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert0Y42( ) ;
               }
               else
               {
                  if ( RcdFound42 != 0 )
                  {
                     if ( ( nRcdDeleted_42 != 0 ) && ( nRcdExists_42 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete0Y42( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_42 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update0Y42( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_42 == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
               O454NegUltItem = A454NegUltItem;
               n454NegUltItem = false;
               AssignAttri("", false, "A454NegUltItem", StringUtil.LTrimStr( (decimal)(A454NegUltItem), 8, 0));
               O448NegPgpTotal = A448NegPgpTotal;
               n448NegPgpTotal = false;
               AssignAttri("", false, "A448NegPgpTotal", StringUtil.LTrimStr( A448NegPgpTotal, 16, 2));
               O380NegValorEstimado = A380NegValorEstimado;
               AssignAttri("", false, "A380NegValorEstimado", StringUtil.LTrimStr( A380NegValorEstimado, 16, 2));
               O385NegValorAtualizado = A385NegValorAtualizado;
               AssignAttri("", false, "A385NegValorAtualizado", StringUtil.LTrimStr( A385NegValorAtualizado, 16, 2));
            }
            ChangePostValue( edtNgpItem_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A435NgpItem), 10, 0, ",", ""))) ;
            ChangePostValue( edtNgpTppID_Internalname, A478NgpTppID.ToString()) ;
            ChangePostValue( dynNgpTppPrdID_Internalname, A439NgpTppPrdID.ToString()) ;
            ChangePostValue( edtNgpTpp1Preco_Internalname, StringUtil.LTrim( StringUtil.NToC( A444NgpTpp1Preco, 23, 2, ",", ""))) ;
            ChangePostValue( edtNgpPreco_Internalname, StringUtil.LTrim( StringUtil.NToC( A445NgpPreco, 23, 2, ",", ""))) ;
            ChangePostValue( edtNgpQtde_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A446NgpQtde), 8, 0, ",", ""))) ;
            ChangePostValue( edtNgpTotal_Internalname, StringUtil.LTrim( StringUtil.NToC( A447NgpTotal, 23, 2, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z435NgpItem_"+sGXsfl_73_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z435NgpItem), 8, 0, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z447NgpTotal_"+sGXsfl_73_idx, StringUtil.LTrim( StringUtil.NToC( Z447NgpTotal, 16, 2, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z446NgpQtde_"+sGXsfl_73_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z446NgpQtde), 8, 0, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z445NgpPreco_"+sGXsfl_73_idx, StringUtil.LTrim( StringUtil.NToC( Z445NgpPreco, 16, 2, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z457NgpInsDataHora_"+sGXsfl_73_idx, context.localUtil.TToC( Z457NgpInsDataHora, 10, 12, 0, 0, "/", ":", " ")) ;
            ChangePostValue( "ZT_"+"Z455NgpInsData_"+sGXsfl_73_idx, context.localUtil.DToC( Z455NgpInsData, 0, "/")) ;
            ChangePostValue( "ZT_"+"Z456NgpInsHora_"+sGXsfl_73_idx, context.localUtil.TToC( Z456NgpInsHora, 10, 8, 0, 0, "/", ":", " ")) ;
            ChangePostValue( "ZT_"+"Z458NgpInsUsuID_"+sGXsfl_73_idx, StringUtil.RTrim( Z458NgpInsUsuID)) ;
            ChangePostValue( "ZT_"+"Z459NgpInsUsuNome_"+sGXsfl_73_idx, Z459NgpInsUsuNome) ;
            ChangePostValue( "ZT_"+"Z579NgpDelDataHora_"+sGXsfl_73_idx, context.localUtil.TToC( Z579NgpDelDataHora, 10, 12, 0, 0, "/", ":", " ")) ;
            ChangePostValue( "ZT_"+"Z580NgpDelData_"+sGXsfl_73_idx, context.localUtil.TToC( Z580NgpDelData, 10, 8, 0, 0, "/", ":", " ")) ;
            ChangePostValue( "ZT_"+"Z581NgpDelHora_"+sGXsfl_73_idx, context.localUtil.TToC( Z581NgpDelHora, 10, 8, 0, 0, "/", ":", " ")) ;
            ChangePostValue( "ZT_"+"Z582NgpDelUsuId_"+sGXsfl_73_idx, StringUtil.RTrim( Z582NgpDelUsuId)) ;
            ChangePostValue( "ZT_"+"Z583NgpDelUsuNome_"+sGXsfl_73_idx, Z583NgpDelUsuNome) ;
            ChangePostValue( "ZT_"+"Z453NgpObs_"+sGXsfl_73_idx, Z453NgpObs) ;
            ChangePostValue( "ZT_"+"Z578NgpDel_"+sGXsfl_73_idx, StringUtil.BoolToStr( Z578NgpDel)) ;
            ChangePostValue( "ZT_"+"Z439NgpTppPrdID_"+sGXsfl_73_idx, Z439NgpTppPrdID.ToString()) ;
            ChangePostValue( "ZT_"+"Z478NgpTppID_"+sGXsfl_73_idx, Z478NgpTppID.ToString()) ;
            ChangePostValue( "T578NgpDel_"+sGXsfl_73_idx, StringUtil.BoolToStr( O578NgpDel)) ;
            ChangePostValue( "T447NgpTotal_"+sGXsfl_73_idx, StringUtil.LTrim( StringUtil.NToC( O447NgpTotal, 16, 2, ",", ""))) ;
            ChangePostValue( "nRcdDeleted_42_"+sGXsfl_73_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_42), 4, 0, ",", ""))) ;
            ChangePostValue( "nRcdExists_42_"+sGXsfl_73_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_42), 4, 0, ",", ""))) ;
            ChangePostValue( "nIsMod_42_"+sGXsfl_73_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_42), 4, 0, ",", ""))) ;
            if ( nIsMod_42 != 0 )
            {
               ChangePostValue( "NGPITEM_"+sGXsfl_73_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNgpItem_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "NGPTPPID_"+sGXsfl_73_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNgpTppID_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "NGPTPPPRDID_"+sGXsfl_73_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynNgpTppPrdID.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "NGPTPP1PRECO_"+sGXsfl_73_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNgpTpp1Preco_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "NGPPRECO_"+sGXsfl_73_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNgpPreco_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "NGPQTDE_"+sGXsfl_73_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNgpQtde_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "NGPTOTAL_"+sGXsfl_73_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNgpTotal_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0Y42( ) ;
         if ( AnyError != 0 )
         {
            O454NegUltItem = s454NegUltItem;
            n454NegUltItem = false;
            AssignAttri("", false, "A454NegUltItem", StringUtil.LTrimStr( (decimal)(A454NegUltItem), 8, 0));
            O448NegPgpTotal = s448NegPgpTotal;
            n448NegPgpTotal = false;
            AssignAttri("", false, "A448NegPgpTotal", StringUtil.LTrimStr( A448NegPgpTotal, 16, 2));
            O380NegValorEstimado = s380NegValorEstimado;
            AssignAttri("", false, "A380NegValorEstimado", StringUtil.LTrimStr( A380NegValorEstimado, 16, 2));
            O385NegValorAtualizado = s385NegValorAtualizado;
            AssignAttri("", false, "A385NegValorAtualizado", StringUtil.LTrimStr( A385NegValorAtualizado, 16, 2));
         }
         nRcdExists_42 = 0;
         nIsMod_42 = 0;
         nRcdDeleted_42 = 0;
      }

      protected void ProcessLevel0Y37( )
      {
         /* Save parent mode. */
         sMode37 = Gx_mode;
         ProcessNestedLevel0Y42( ) ;
         if ( AnyError != 0 )
         {
            O454NegUltItem = s454NegUltItem;
            n454NegUltItem = false;
            AssignAttri("", false, "A454NegUltItem", StringUtil.LTrimStr( (decimal)(A454NegUltItem), 8, 0));
            O448NegPgpTotal = s448NegPgpTotal;
            n448NegPgpTotal = false;
            AssignAttri("", false, "A448NegPgpTotal", StringUtil.LTrimStr( A448NegPgpTotal, 16, 2));
            O380NegValorEstimado = s380NegValorEstimado;
            AssignAttri("", false, "A380NegValorEstimado", StringUtil.LTrimStr( A380NegValorEstimado, 16, 2));
            O385NegValorAtualizado = s385NegValorAtualizado;
            AssignAttri("", false, "A385NegValorAtualizado", StringUtil.LTrimStr( A385NegValorAtualizado, 16, 2));
         }
         /* Restore parent mode. */
         Gx_mode = sMode37;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
         /* Using cursor T000Y34 */
         pr_default.execute(30, new Object[] {n454NegUltItem, A454NegUltItem, A380NegValorEstimado, A385NegValorAtualizado, A345NegID});
         pr_default.close(30);
         pr_default.SmartCacheProvider.SetUpdated("tb_negociopj");
      }

      protected void EndLevel0Y37( )
      {
         pr_default.close(4);
         if ( AnyError == 0 )
         {
            BeforeComplete0Y37( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("core.negociopj",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0Y0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("core.negociopj",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0Y37( )
      {
         /* Scan By routine */
         /* Using cursor T000Y35 */
         pr_default.execute(31);
         RcdFound37 = 0;
         if ( (pr_default.getStatus(31) != 101) )
         {
            RcdFound37 = 1;
            A345NegID = T000Y35_A345NegID[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0Y37( )
      {
         /* Scan next routine */
         pr_default.readNext(31);
         RcdFound37 = 0;
         if ( (pr_default.getStatus(31) != 101) )
         {
            RcdFound37 = 1;
            A345NegID = T000Y35_A345NegID[0];
         }
      }

      protected void ScanEnd0Y37( )
      {
         pr_default.close(31);
      }

      protected void AfterConfirm0Y37( )
      {
         /* After Confirm Rules */
         if ( IsIns( )  )
         {
            GXt_int4 = (int)(A356NegCodigo);
            new GeneXus.Programs.core.serializar(context ).execute(  "NegCodigo",  1, out  GXt_int4) ;
            A356NegCodigo = GXt_int4;
            AssignAttri("", false, "A356NegCodigo", StringUtil.LTrimStr( (decimal)(A356NegCodigo), 12, 0));
         }
      }

      protected void BeforeInsert0Y37( )
      {
         /* Before Insert Rules */
         A348NegInsDataHora = DateTimeUtil.NowMS( context);
         AssignAttri("", false, "A348NegInsDataHora", context.localUtil.TToC( A348NegInsDataHora, 10, 12, 0, 3, "/", ":", " "));
         A349NegInsUsuID = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getid();
         n349NegInsUsuID = false;
         AssignAttri("", false, "A349NegInsUsuID", A349NegInsUsuID);
         A364NegInsUsuNome = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
         n364NegInsUsuNome = false;
         AssignAttri("", false, "A364NegInsUsuNome", A364NegInsUsuNome);
         A385NegValorAtualizado = A380NegValorEstimado;
         AssignAttri("", false, "A385NegValorAtualizado", StringUtil.LTrimStr( A385NegValorAtualizado, 16, 2));
         A346NegInsData = DateTimeUtil.ResetTime( A348NegInsDataHora);
         AssignAttri("", false, "A346NegInsData", context.localUtil.Format(A346NegInsData, "99/99/99"));
         A347NegInsHora = DateTimeUtil.ResetDate( DateTimeUtil.ResetMilliseconds(A348NegInsDataHora));
         AssignAttri("", false, "A347NegInsHora", context.localUtil.TToC( A347NegInsHora, 0, 5, 0, 3, "/", ":", " "));
      }

      protected void BeforeUpdate0Y37( )
      {
         /* Before Update Rules */
         new GeneXus.Programs.core.loadauditnegociopj(context ).execute(  "Y", ref  AV47AuditingObject,  A345NegID,  Gx_mode) ;
         if ( A572NegDel && ( O572NegDel != A572NegDel ) )
         {
            A573NegDelDataHora = DateTimeUtil.NowMS( context);
            n573NegDelDataHora = false;
            AssignAttri("", false, "A573NegDelDataHora", context.localUtil.TToC( A573NegDelDataHora, 10, 12, 0, 3, "/", ":", " "));
         }
         if ( A572NegDel && ( O572NegDel != A572NegDel ) )
         {
            A576NegDelUsuId = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getid();
            n576NegDelUsuId = false;
            AssignAttri("", false, "A576NegDelUsuId", A576NegDelUsuId);
         }
         if ( A572NegDel && ( O572NegDel != A572NegDel ) )
         {
            A577NegDelUsuNome = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
            n577NegDelUsuNome = false;
            AssignAttri("", false, "A577NegDelUsuNome", A577NegDelUsuNome);
         }
         if ( A572NegDel && ( O572NegDel != A572NegDel ) )
         {
            A574NegDelData = DateTimeUtil.ResetTime( DateTimeUtil.ResetTime( A573NegDelDataHora) ) ;
            n574NegDelData = false;
            AssignAttri("", false, "A574NegDelData", context.localUtil.TToC( A574NegDelData, 10, 5, 0, 3, "/", ":", " "));
         }
         if ( A572NegDel && ( O572NegDel != A572NegDel ) )
         {
            A575NegDelHora = DateTimeUtil.ResetDate( DateTimeUtil.ResetMilliseconds(A573NegDelDataHora));
            n575NegDelHora = false;
            AssignAttri("", false, "A575NegDelHora", context.localUtil.TToC( A575NegDelHora, 0, 5, 0, 3, "/", ":", " "));
         }
      }

      protected void BeforeDelete0Y37( )
      {
         /* Before Delete Rules */
         new GeneXus.Programs.core.loadauditnegociopj(context ).execute(  "Y", ref  AV47AuditingObject,  A345NegID,  Gx_mode) ;
      }

      protected void BeforeComplete0Y37( )
      {
         /* Before Complete Rules */
         if ( IsIns( )  )
         {
            new GeneXus.Programs.core.loadauditnegociopj(context ).execute(  "N", ref  AV47AuditingObject,  A345NegID,  Gx_mode) ;
         }
         if ( IsUpd( )  )
         {
            new GeneXus.Programs.core.loadauditnegociopj(context ).execute(  "N", ref  AV47AuditingObject,  A345NegID,  Gx_mode) ;
         }
      }

      protected void BeforeValidate0Y37( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0Y37( )
      {
         edtNegCodigo_Enabled = 0;
         AssignProp("", false, edtNegCodigo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNegCodigo_Enabled), 5, 0), true);
         edtNegCliID_Enabled = 0;
         AssignProp("", false, edtNegCliID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNegCliID_Enabled), 5, 0), true);
         edtNegCpjID_Enabled = 0;
         AssignProp("", false, edtNegCpjID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNegCpjID_Enabled), 5, 0), true);
         edtNegCpjEndSeq_Enabled = 0;
         AssignProp("", false, edtNegCpjEndSeq_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNegCpjEndSeq_Enabled), 5, 0), true);
         edtNegAssunto_Enabled = 0;
         AssignProp("", false, edtNegAssunto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNegAssunto_Enabled), 5, 0), true);
         edtNegValorEstimado_Enabled = 0;
         AssignProp("", false, edtNegValorEstimado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNegValorEstimado_Enabled), 5, 0), true);
         edtavCombonegcliid_Enabled = 0;
         AssignProp("", false, edtavCombonegcliid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombonegcliid_Enabled), 5, 0), true);
         edtavCombonegcpjid_Enabled = 0;
         AssignProp("", false, edtavCombonegcpjid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombonegcpjid_Enabled), 5, 0), true);
         edtavCombonegcpjendseq_Enabled = 0;
         AssignProp("", false, edtavCombonegcpjendseq_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombonegcpjendseq_Enabled), 5, 0), true);
         Negdescricao_Enabled = Convert.ToBoolean( 0);
         AssignProp("", false, Negdescricao_Internalname, "Enabled", StringUtil.BoolToStr( Negdescricao_Enabled), true);
      }

      protected void ZM0Y42( short GX_JID )
      {
         if ( ( GX_JID == 75 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z447NgpTotal = T000Y3_A447NgpTotal[0];
               Z446NgpQtde = T000Y3_A446NgpQtde[0];
               Z445NgpPreco = T000Y3_A445NgpPreco[0];
               Z457NgpInsDataHora = T000Y3_A457NgpInsDataHora[0];
               Z455NgpInsData = T000Y3_A455NgpInsData[0];
               Z456NgpInsHora = T000Y3_A456NgpInsHora[0];
               Z458NgpInsUsuID = T000Y3_A458NgpInsUsuID[0];
               Z459NgpInsUsuNome = T000Y3_A459NgpInsUsuNome[0];
               Z579NgpDelDataHora = T000Y3_A579NgpDelDataHora[0];
               Z580NgpDelData = T000Y3_A580NgpDelData[0];
               Z581NgpDelHora = T000Y3_A581NgpDelHora[0];
               Z582NgpDelUsuId = T000Y3_A582NgpDelUsuId[0];
               Z583NgpDelUsuNome = T000Y3_A583NgpDelUsuNome[0];
               Z453NgpObs = T000Y3_A453NgpObs[0];
               Z578NgpDel = T000Y3_A578NgpDel[0];
               Z439NgpTppPrdID = T000Y3_A439NgpTppPrdID[0];
               Z478NgpTppID = T000Y3_A478NgpTppID[0];
            }
            else
            {
               Z447NgpTotal = A447NgpTotal;
               Z446NgpQtde = A446NgpQtde;
               Z445NgpPreco = A445NgpPreco;
               Z457NgpInsDataHora = A457NgpInsDataHora;
               Z455NgpInsData = A455NgpInsData;
               Z456NgpInsHora = A456NgpInsHora;
               Z458NgpInsUsuID = A458NgpInsUsuID;
               Z459NgpInsUsuNome = A459NgpInsUsuNome;
               Z579NgpDelDataHora = A579NgpDelDataHora;
               Z580NgpDelData = A580NgpDelData;
               Z581NgpDelHora = A581NgpDelHora;
               Z582NgpDelUsuId = A582NgpDelUsuId;
               Z583NgpDelUsuNome = A583NgpDelUsuNome;
               Z453NgpObs = A453NgpObs;
               Z578NgpDel = A578NgpDel;
               Z439NgpTppPrdID = A439NgpTppPrdID;
               Z478NgpTppID = A478NgpTppID;
            }
         }
         if ( GX_JID == -75 )
         {
            Z447NgpTotal = A447NgpTotal;
            Z345NegID = A345NegID;
            Z435NgpItem = A435NgpItem;
            Z446NgpQtde = A446NgpQtde;
            Z445NgpPreco = A445NgpPreco;
            Z457NgpInsDataHora = A457NgpInsDataHora;
            Z455NgpInsData = A455NgpInsData;
            Z456NgpInsHora = A456NgpInsHora;
            Z458NgpInsUsuID = A458NgpInsUsuID;
            Z459NgpInsUsuNome = A459NgpInsUsuNome;
            Z579NgpDelDataHora = A579NgpDelDataHora;
            Z580NgpDelData = A580NgpDelData;
            Z581NgpDelHora = A581NgpDelHora;
            Z582NgpDelUsuId = A582NgpDelUsuId;
            Z583NgpDelUsuNome = A583NgpDelUsuNome;
            Z453NgpObs = A453NgpObs;
            Z578NgpDel = A578NgpDel;
            Z439NgpTppPrdID = A439NgpTppPrdID;
            Z478NgpTppID = A478NgpTppID;
            Z440NgpTppPrdCodigo = A440NgpTppPrdCodigo;
            Z441NgpTppPrdNome = A441NgpTppPrdNome;
            Z443NgpTppPrdAtivo = A443NgpTppPrdAtivo;
            Z442NgpTppPrdTipoID = A442NgpTppPrdTipoID;
            Z444NgpTpp1Preco = A444NgpTpp1Preco;
         }
      }

      protected void standaloneNotModal0Y42( )
      {
         GXANGPTPPPRDID_html0Y42( ) ;
         edtNgpItem_Enabled = 0;
         AssignProp("", false, edtNgpItem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNgpItem_Enabled), 5, 0), !bGXsfl_73_Refreshing);
         edtNegValorEstimado_Enabled = 0;
         AssignProp("", false, edtNegValorEstimado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNegValorEstimado_Enabled), 5, 0), true);
         edtNegValorEstimado_Enabled = 0;
         AssignProp("", false, edtNegValorEstimado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNegValorEstimado_Enabled), 5, 0), true);
      }

      protected void standaloneModal0Y42( )
      {
         if ( IsIns( )  )
         {
            A454NegUltItem = (int)(O454NegUltItem+1);
            n454NegUltItem = false;
            AssignAttri("", false, "A454NegUltItem", StringUtil.LTrimStr( (decimal)(A454NegUltItem), 8, 0));
         }
         if ( IsIns( )  && (0==A446NgpQtde) && ( Gx_BScreen == 0 ) )
         {
            A446NgpQtde = 1;
         }
         if ( IsIns( )  && ( Gx_BScreen == 1 ) )
         {
            A435NgpItem = A454NegUltItem;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T000Y4 */
            pr_default.execute(2, new Object[] {A439NgpTppPrdID});
            A440NgpTppPrdCodigo = T000Y4_A440NgpTppPrdCodigo[0];
            A441NgpTppPrdNome = T000Y4_A441NgpTppPrdNome[0];
            A443NgpTppPrdAtivo = T000Y4_A443NgpTppPrdAtivo[0];
            A442NgpTppPrdTipoID = T000Y4_A442NgpTppPrdTipoID[0];
            pr_default.close(2);
         }
      }

      protected void Load0Y42( )
      {
         /* Using cursor T000Y36 */
         pr_default.execute(32, new Object[] {A345NegID, A435NgpItem});
         if ( (pr_default.getStatus(32) != 101) )
         {
            RcdFound42 = 1;
            A447NgpTotal = T000Y36_A447NgpTotal[0];
            A446NgpQtde = T000Y36_A446NgpQtde[0];
            A445NgpPreco = T000Y36_A445NgpPreco[0];
            A457NgpInsDataHora = T000Y36_A457NgpInsDataHora[0];
            A455NgpInsData = T000Y36_A455NgpInsData[0];
            A456NgpInsHora = T000Y36_A456NgpInsHora[0];
            A458NgpInsUsuID = T000Y36_A458NgpInsUsuID[0];
            n458NgpInsUsuID = T000Y36_n458NgpInsUsuID[0];
            A459NgpInsUsuNome = T000Y36_A459NgpInsUsuNome[0];
            n459NgpInsUsuNome = T000Y36_n459NgpInsUsuNome[0];
            A579NgpDelDataHora = T000Y36_A579NgpDelDataHora[0];
            n579NgpDelDataHora = T000Y36_n579NgpDelDataHora[0];
            A580NgpDelData = T000Y36_A580NgpDelData[0];
            n580NgpDelData = T000Y36_n580NgpDelData[0];
            A581NgpDelHora = T000Y36_A581NgpDelHora[0];
            n581NgpDelHora = T000Y36_n581NgpDelHora[0];
            A582NgpDelUsuId = T000Y36_A582NgpDelUsuId[0];
            n582NgpDelUsuId = T000Y36_n582NgpDelUsuId[0];
            A583NgpDelUsuNome = T000Y36_A583NgpDelUsuNome[0];
            n583NgpDelUsuNome = T000Y36_n583NgpDelUsuNome[0];
            A440NgpTppPrdCodigo = T000Y36_A440NgpTppPrdCodigo[0];
            A441NgpTppPrdNome = T000Y36_A441NgpTppPrdNome[0];
            A443NgpTppPrdAtivo = T000Y36_A443NgpTppPrdAtivo[0];
            A444NgpTpp1Preco = T000Y36_A444NgpTpp1Preco[0];
            A453NgpObs = T000Y36_A453NgpObs[0];
            A578NgpDel = T000Y36_A578NgpDel[0];
            A439NgpTppPrdID = T000Y36_A439NgpTppPrdID[0];
            A478NgpTppID = T000Y36_A478NgpTppID[0];
            A442NgpTppPrdTipoID = T000Y36_A442NgpTppPrdTipoID[0];
            ZM0Y42( -75) ;
         }
         pr_default.close(32);
         OnLoadActions0Y42( ) ;
      }

      protected void OnLoadActions0Y42( )
      {
         if ( IsIns( )  && (Convert.ToDecimal(0)==A445NgpPreco) && ( Gx_BScreen == 0 ) )
         {
            A445NgpPreco = A444NgpTpp1Preco;
         }
         A447NgpTotal = NumberUtil.Round( (A445NgpPreco*A446NgpQtde), 2);
         if ( IsIns( )  )
         {
            A448NegPgpTotal = (decimal)(O448NegPgpTotal+A447NgpTotal);
            n448NegPgpTotal = false;
            AssignAttri("", false, "A448NegPgpTotal", StringUtil.LTrimStr( A448NegPgpTotal, 16, 2));
         }
         else
         {
            if ( IsUpd( )  )
            {
               A448NegPgpTotal = (decimal)(O448NegPgpTotal+A447NgpTotal-O447NgpTotal);
               n448NegPgpTotal = false;
               AssignAttri("", false, "A448NegPgpTotal", StringUtil.LTrimStr( A448NegPgpTotal, 16, 2));
            }
            else
            {
               if ( IsDlt( )  )
               {
                  A448NegPgpTotal = (decimal)(O448NegPgpTotal-O447NgpTotal);
                  n448NegPgpTotal = false;
                  AssignAttri("", false, "A448NegPgpTotal", StringUtil.LTrimStr( A448NegPgpTotal, 16, 2));
               }
            }
         }
         A380NegValorEstimado = A448NegPgpTotal;
         AssignAttri("", false, "A380NegValorEstimado", StringUtil.LTrimStr( A380NegValorEstimado, 16, 2));
         A385NegValorAtualizado = A448NegPgpTotal;
         AssignAttri("", false, "A385NegValorAtualizado", StringUtil.LTrimStr( A385NegValorAtualizado, 16, 2));
      }

      protected void CheckExtendedTable0Y42( )
      {
         nIsDirty_42 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal0Y42( ) ;
         /* Using cursor T000Y5 */
         pr_default.execute(3, new Object[] {A478NgpTppID, A439NgpTppPrdID});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GXCCtl = "NGPTPPPRDID_" + sGXsfl_73_idx;
            GX_msglist.addItem("Não existe 'Produto da Tabela de Preço'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtNgpTppID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A444NgpTpp1Preco = T000Y5_A444NgpTpp1Preco[0];
         pr_default.close(3);
         if ( IsIns( )  && (Convert.ToDecimal(0)==A445NgpPreco) && ( Gx_BScreen == 0 ) )
         {
            nIsDirty_42 = 1;
            A445NgpPreco = A444NgpTpp1Preco;
         }
         if ( (Guid.Empty==A478NgpTppID) )
         {
            GXCCtl = "NGPTPPID_" + sGXsfl_73_idx;
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Tabela de Preço ID", "", "", "", "", "", "", "", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtNgpTppID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T000Y4 */
         pr_default.execute(2, new Object[] {A439NgpTppPrdID});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GXCCtl = "NGPTPPPRDID_" + sGXsfl_73_idx;
            GX_msglist.addItem("Não existe 'Produto da Tabela de Preço'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = dynNgpTppPrdID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A440NgpTppPrdCodigo = T000Y4_A440NgpTppPrdCodigo[0];
         A441NgpTppPrdNome = T000Y4_A441NgpTppPrdNome[0];
         A443NgpTppPrdAtivo = T000Y4_A443NgpTppPrdAtivo[0];
         A442NgpTppPrdTipoID = T000Y4_A442NgpTppPrdTipoID[0];
         pr_default.close(2);
         if ( (Guid.Empty==A439NgpTppPrdID) )
         {
            GXCCtl = "NGPTPPPRDID_" + sGXsfl_73_idx;
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "ID do Produto", "", "", "", "", "", "", "", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = dynNgpTppPrdID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         nIsDirty_42 = 1;
         A447NgpTotal = NumberUtil.Round( (A445NgpPreco*A446NgpQtde), 2);
         if ( (Convert.ToDecimal(0)==A445NgpPreco) )
         {
            GXCCtl = "NGPPRECO_" + sGXsfl_73_idx;
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Preço", "", "", "", "", "", "", "", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtNgpPreco_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( (0==A446NgpQtde) )
         {
            GXCCtl = "NGPQTDE_" + sGXsfl_73_idx;
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Quantidade", "", "", "", "", "", "", "", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtNgpQtde_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( IsIns( )  )
         {
            nIsDirty_42 = 1;
            A448NegPgpTotal = (decimal)(O448NegPgpTotal+A447NgpTotal);
            n448NegPgpTotal = false;
            AssignAttri("", false, "A448NegPgpTotal", StringUtil.LTrimStr( A448NegPgpTotal, 16, 2));
         }
         else
         {
            if ( IsUpd( )  )
            {
               nIsDirty_42 = 1;
               A448NegPgpTotal = (decimal)(O448NegPgpTotal+A447NgpTotal-O447NgpTotal);
               n448NegPgpTotal = false;
               AssignAttri("", false, "A448NegPgpTotal", StringUtil.LTrimStr( A448NegPgpTotal, 16, 2));
            }
            else
            {
               if ( IsDlt( )  )
               {
                  nIsDirty_42 = 1;
                  A448NegPgpTotal = (decimal)(O448NegPgpTotal-O447NgpTotal);
                  n448NegPgpTotal = false;
                  AssignAttri("", false, "A448NegPgpTotal", StringUtil.LTrimStr( A448NegPgpTotal, 16, 2));
               }
            }
         }
         nIsDirty_42 = 1;
         A380NegValorEstimado = A448NegPgpTotal;
         AssignAttri("", false, "A380NegValorEstimado", StringUtil.LTrimStr( A380NegValorEstimado, 16, 2));
         nIsDirty_42 = 1;
         A385NegValorAtualizado = A448NegPgpTotal;
         AssignAttri("", false, "A385NegValorAtualizado", StringUtil.LTrimStr( A385NegValorAtualizado, 16, 2));
      }

      protected void CloseExtendedTableCursors0Y42( )
      {
         pr_default.close(3);
         pr_default.close(2);
      }

      protected void enableDisable0Y42( )
      {
      }

      protected void gxLoad_77( Guid A478NgpTppID ,
                                Guid A439NgpTppPrdID )
      {
         /* Using cursor T000Y37 */
         pr_default.execute(33, new Object[] {A478NgpTppID, A439NgpTppPrdID});
         if ( (pr_default.getStatus(33) == 101) )
         {
            GXCCtl = "NGPTPPPRDID_" + sGXsfl_73_idx;
            GX_msglist.addItem("Não existe 'Produto da Tabela de Preço'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtNgpTppID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A444NgpTpp1Preco = T000Y37_A444NgpTpp1Preco[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A444NgpTpp1Preco, 16, 2, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(33) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(33);
      }

      protected void gxLoad_76( Guid A439NgpTppPrdID )
      {
         /* Using cursor T000Y38 */
         pr_default.execute(34, new Object[] {A439NgpTppPrdID});
         if ( (pr_default.getStatus(34) == 101) )
         {
            GXCCtl = "NGPTPPPRDID_" + sGXsfl_73_idx;
            GX_msglist.addItem("Não existe 'Produto da Tabela de Preço'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = dynNgpTppPrdID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A440NgpTppPrdCodigo = T000Y38_A440NgpTppPrdCodigo[0];
         A441NgpTppPrdNome = T000Y38_A441NgpTppPrdNome[0];
         A443NgpTppPrdAtivo = T000Y38_A443NgpTppPrdAtivo[0];
         A442NgpTppPrdTipoID = T000Y38_A442NgpTppPrdTipoID[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A440NgpTppPrdCodigo)+"\""+","+"\""+GXUtil.EncodeJSConstant( A441NgpTppPrdNome)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.BoolToStr( A443NgpTppPrdAtivo))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A442NgpTppPrdTipoID), 9, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(34) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(34);
      }

      protected void GetKey0Y42( )
      {
         /* Using cursor T000Y39 */
         pr_default.execute(35, new Object[] {A345NegID, A435NgpItem});
         if ( (pr_default.getStatus(35) != 101) )
         {
            RcdFound42 = 1;
         }
         else
         {
            RcdFound42 = 0;
         }
         pr_default.close(35);
      }

      protected void getByPrimaryKey0Y42( )
      {
         /* Using cursor T000Y3 */
         pr_default.execute(1, new Object[] {A345NegID, A435NgpItem});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0Y42( 75) ;
            RcdFound42 = 1;
            InitializeNonKey0Y42( ) ;
            A447NgpTotal = T000Y3_A447NgpTotal[0];
            A435NgpItem = T000Y3_A435NgpItem[0];
            A446NgpQtde = T000Y3_A446NgpQtde[0];
            A445NgpPreco = T000Y3_A445NgpPreco[0];
            A457NgpInsDataHora = T000Y3_A457NgpInsDataHora[0];
            A455NgpInsData = T000Y3_A455NgpInsData[0];
            A456NgpInsHora = T000Y3_A456NgpInsHora[0];
            A458NgpInsUsuID = T000Y3_A458NgpInsUsuID[0];
            n458NgpInsUsuID = T000Y3_n458NgpInsUsuID[0];
            A459NgpInsUsuNome = T000Y3_A459NgpInsUsuNome[0];
            n459NgpInsUsuNome = T000Y3_n459NgpInsUsuNome[0];
            A579NgpDelDataHora = T000Y3_A579NgpDelDataHora[0];
            n579NgpDelDataHora = T000Y3_n579NgpDelDataHora[0];
            A580NgpDelData = T000Y3_A580NgpDelData[0];
            n580NgpDelData = T000Y3_n580NgpDelData[0];
            A581NgpDelHora = T000Y3_A581NgpDelHora[0];
            n581NgpDelHora = T000Y3_n581NgpDelHora[0];
            A582NgpDelUsuId = T000Y3_A582NgpDelUsuId[0];
            n582NgpDelUsuId = T000Y3_n582NgpDelUsuId[0];
            A583NgpDelUsuNome = T000Y3_A583NgpDelUsuNome[0];
            n583NgpDelUsuNome = T000Y3_n583NgpDelUsuNome[0];
            A453NgpObs = T000Y3_A453NgpObs[0];
            A578NgpDel = T000Y3_A578NgpDel[0];
            A439NgpTppPrdID = T000Y3_A439NgpTppPrdID[0];
            A478NgpTppID = T000Y3_A478NgpTppID[0];
            O578NgpDel = A578NgpDel;
            AssignAttri("", false, "A578NgpDel", A578NgpDel);
            O447NgpTotal = A447NgpTotal;
            Z345NegID = A345NegID;
            Z435NgpItem = A435NgpItem;
            sMode42 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0Y42( ) ;
            Gx_mode = sMode42;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound42 = 0;
            InitializeNonKey0Y42( ) ;
            sMode42 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal0Y42( ) ;
            Gx_mode = sMode42;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0Y42( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0Y42( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000Y2 */
            pr_default.execute(0, new Object[] {A345NegID, A435NgpItem});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_negociopj_item"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z447NgpTotal != T000Y2_A447NgpTotal[0] ) || ( Z446NgpQtde != T000Y2_A446NgpQtde[0] ) || ( Z445NgpPreco != T000Y2_A445NgpPreco[0] ) || ( Z457NgpInsDataHora != T000Y2_A457NgpInsDataHora[0] ) || ( DateTimeUtil.ResetTime ( Z455NgpInsData ) != DateTimeUtil.ResetTime ( T000Y2_A455NgpInsData[0] ) ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z456NgpInsHora != T000Y2_A456NgpInsHora[0] ) || ( StringUtil.StrCmp(Z458NgpInsUsuID, T000Y2_A458NgpInsUsuID[0]) != 0 ) || ( StringUtil.StrCmp(Z459NgpInsUsuNome, T000Y2_A459NgpInsUsuNome[0]) != 0 ) || ( Z579NgpDelDataHora != T000Y2_A579NgpDelDataHora[0] ) || ( Z580NgpDelData != T000Y2_A580NgpDelData[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z581NgpDelHora != T000Y2_A581NgpDelHora[0] ) || ( StringUtil.StrCmp(Z582NgpDelUsuId, T000Y2_A582NgpDelUsuId[0]) != 0 ) || ( StringUtil.StrCmp(Z583NgpDelUsuNome, T000Y2_A583NgpDelUsuNome[0]) != 0 ) || ( StringUtil.StrCmp(Z453NgpObs, T000Y2_A453NgpObs[0]) != 0 ) || ( Z578NgpDel != T000Y2_A578NgpDel[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z439NgpTppPrdID != T000Y2_A439NgpTppPrdID[0] ) || ( Z478NgpTppID != T000Y2_A478NgpTppID[0] ) )
            {
               if ( Z447NgpTotal != T000Y2_A447NgpTotal[0] )
               {
                  GXUtil.WriteLog("core.negociopj:[seudo value changed for attri]"+"NgpTotal");
                  GXUtil.WriteLogRaw("Old: ",Z447NgpTotal);
                  GXUtil.WriteLogRaw("Current: ",T000Y2_A447NgpTotal[0]);
               }
               if ( Z446NgpQtde != T000Y2_A446NgpQtde[0] )
               {
                  GXUtil.WriteLog("core.negociopj:[seudo value changed for attri]"+"NgpQtde");
                  GXUtil.WriteLogRaw("Old: ",Z446NgpQtde);
                  GXUtil.WriteLogRaw("Current: ",T000Y2_A446NgpQtde[0]);
               }
               if ( Z445NgpPreco != T000Y2_A445NgpPreco[0] )
               {
                  GXUtil.WriteLog("core.negociopj:[seudo value changed for attri]"+"NgpPreco");
                  GXUtil.WriteLogRaw("Old: ",Z445NgpPreco);
                  GXUtil.WriteLogRaw("Current: ",T000Y2_A445NgpPreco[0]);
               }
               if ( Z457NgpInsDataHora != T000Y2_A457NgpInsDataHora[0] )
               {
                  GXUtil.WriteLog("core.negociopj:[seudo value changed for attri]"+"NgpInsDataHora");
                  GXUtil.WriteLogRaw("Old: ",Z457NgpInsDataHora);
                  GXUtil.WriteLogRaw("Current: ",T000Y2_A457NgpInsDataHora[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z455NgpInsData ) != DateTimeUtil.ResetTime ( T000Y2_A455NgpInsData[0] ) )
               {
                  GXUtil.WriteLog("core.negociopj:[seudo value changed for attri]"+"NgpInsData");
                  GXUtil.WriteLogRaw("Old: ",Z455NgpInsData);
                  GXUtil.WriteLogRaw("Current: ",T000Y2_A455NgpInsData[0]);
               }
               if ( Z456NgpInsHora != T000Y2_A456NgpInsHora[0] )
               {
                  GXUtil.WriteLog("core.negociopj:[seudo value changed for attri]"+"NgpInsHora");
                  GXUtil.WriteLogRaw("Old: ",Z456NgpInsHora);
                  GXUtil.WriteLogRaw("Current: ",T000Y2_A456NgpInsHora[0]);
               }
               if ( StringUtil.StrCmp(Z458NgpInsUsuID, T000Y2_A458NgpInsUsuID[0]) != 0 )
               {
                  GXUtil.WriteLog("core.negociopj:[seudo value changed for attri]"+"NgpInsUsuID");
                  GXUtil.WriteLogRaw("Old: ",Z458NgpInsUsuID);
                  GXUtil.WriteLogRaw("Current: ",T000Y2_A458NgpInsUsuID[0]);
               }
               if ( StringUtil.StrCmp(Z459NgpInsUsuNome, T000Y2_A459NgpInsUsuNome[0]) != 0 )
               {
                  GXUtil.WriteLog("core.negociopj:[seudo value changed for attri]"+"NgpInsUsuNome");
                  GXUtil.WriteLogRaw("Old: ",Z459NgpInsUsuNome);
                  GXUtil.WriteLogRaw("Current: ",T000Y2_A459NgpInsUsuNome[0]);
               }
               if ( Z579NgpDelDataHora != T000Y2_A579NgpDelDataHora[0] )
               {
                  GXUtil.WriteLog("core.negociopj:[seudo value changed for attri]"+"NgpDelDataHora");
                  GXUtil.WriteLogRaw("Old: ",Z579NgpDelDataHora);
                  GXUtil.WriteLogRaw("Current: ",T000Y2_A579NgpDelDataHora[0]);
               }
               if ( Z580NgpDelData != T000Y2_A580NgpDelData[0] )
               {
                  GXUtil.WriteLog("core.negociopj:[seudo value changed for attri]"+"NgpDelData");
                  GXUtil.WriteLogRaw("Old: ",Z580NgpDelData);
                  GXUtil.WriteLogRaw("Current: ",T000Y2_A580NgpDelData[0]);
               }
               if ( Z581NgpDelHora != T000Y2_A581NgpDelHora[0] )
               {
                  GXUtil.WriteLog("core.negociopj:[seudo value changed for attri]"+"NgpDelHora");
                  GXUtil.WriteLogRaw("Old: ",Z581NgpDelHora);
                  GXUtil.WriteLogRaw("Current: ",T000Y2_A581NgpDelHora[0]);
               }
               if ( StringUtil.StrCmp(Z582NgpDelUsuId, T000Y2_A582NgpDelUsuId[0]) != 0 )
               {
                  GXUtil.WriteLog("core.negociopj:[seudo value changed for attri]"+"NgpDelUsuId");
                  GXUtil.WriteLogRaw("Old: ",Z582NgpDelUsuId);
                  GXUtil.WriteLogRaw("Current: ",T000Y2_A582NgpDelUsuId[0]);
               }
               if ( StringUtil.StrCmp(Z583NgpDelUsuNome, T000Y2_A583NgpDelUsuNome[0]) != 0 )
               {
                  GXUtil.WriteLog("core.negociopj:[seudo value changed for attri]"+"NgpDelUsuNome");
                  GXUtil.WriteLogRaw("Old: ",Z583NgpDelUsuNome);
                  GXUtil.WriteLogRaw("Current: ",T000Y2_A583NgpDelUsuNome[0]);
               }
               if ( StringUtil.StrCmp(Z453NgpObs, T000Y2_A453NgpObs[0]) != 0 )
               {
                  GXUtil.WriteLog("core.negociopj:[seudo value changed for attri]"+"NgpObs");
                  GXUtil.WriteLogRaw("Old: ",Z453NgpObs);
                  GXUtil.WriteLogRaw("Current: ",T000Y2_A453NgpObs[0]);
               }
               if ( Z578NgpDel != T000Y2_A578NgpDel[0] )
               {
                  GXUtil.WriteLog("core.negociopj:[seudo value changed for attri]"+"NgpDel");
                  GXUtil.WriteLogRaw("Old: ",Z578NgpDel);
                  GXUtil.WriteLogRaw("Current: ",T000Y2_A578NgpDel[0]);
               }
               if ( Z439NgpTppPrdID != T000Y2_A439NgpTppPrdID[0] )
               {
                  GXUtil.WriteLog("core.negociopj:[seudo value changed for attri]"+"NgpTppPrdID");
                  GXUtil.WriteLogRaw("Old: ",Z439NgpTppPrdID);
                  GXUtil.WriteLogRaw("Current: ",T000Y2_A439NgpTppPrdID[0]);
               }
               if ( Z478NgpTppID != T000Y2_A478NgpTppID[0] )
               {
                  GXUtil.WriteLog("core.negociopj:[seudo value changed for attri]"+"NgpTppID");
                  GXUtil.WriteLogRaw("Old: ",Z478NgpTppID);
                  GXUtil.WriteLogRaw("Current: ",T000Y2_A478NgpTppID[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"tb_negociopj_item"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0Y42( )
      {
         if ( ! IsAuthorized("negocio_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0Y42( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0Y42( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0Y42( 0) ;
            CheckOptimisticConcurrency0Y42( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0Y42( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0Y42( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000Y40 */
                     pr_default.execute(36, new Object[] {A447NgpTotal, A345NegID, A435NgpItem, A446NgpQtde, A445NgpPreco, A457NgpInsDataHora, A455NgpInsData, A456NgpInsHora, n458NgpInsUsuID, A458NgpInsUsuID, n459NgpInsUsuNome, A459NgpInsUsuNome, n579NgpDelDataHora, A579NgpDelDataHora, n580NgpDelData, A580NgpDelData, n581NgpDelHora, A581NgpDelHora, n582NgpDelUsuId, A582NgpDelUsuId, n583NgpDelUsuNome, A583NgpDelUsuNome, A453NgpObs, A578NgpDel, A439NgpTppPrdID, A478NgpTppID});
                     pr_default.close(36);
                     pr_default.SmartCacheProvider.SetUpdated("tb_negociopj_item");
                     if ( (pr_default.getStatus(36) == 1) )
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
               Load0Y42( ) ;
            }
            EndLevel0Y42( ) ;
         }
         CloseExtendedTableCursors0Y42( ) ;
      }

      protected void Update0Y42( )
      {
         if ( ! IsAuthorized("negocio_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0Y42( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0Y42( ) ;
         }
         if ( ( nIsMod_42 != 0 ) || ( nIsDirty_42 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency0Y42( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm0Y42( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate0Y42( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T000Y41 */
                        pr_default.execute(37, new Object[] {A447NgpTotal, A446NgpQtde, A445NgpPreco, A457NgpInsDataHora, A455NgpInsData, A456NgpInsHora, n458NgpInsUsuID, A458NgpInsUsuID, n459NgpInsUsuNome, A459NgpInsUsuNome, n579NgpDelDataHora, A579NgpDelDataHora, n580NgpDelData, A580NgpDelData, n581NgpDelHora, A581NgpDelHora, n582NgpDelUsuId, A582NgpDelUsuId, n583NgpDelUsuNome, A583NgpDelUsuNome, A453NgpObs, A578NgpDel, A439NgpTppPrdID, A478NgpTppID, A345NegID, A435NgpItem});
                        pr_default.close(37);
                        pr_default.SmartCacheProvider.SetUpdated("tb_negociopj_item");
                        if ( (pr_default.getStatus(37) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_negociopj_item"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate0Y42( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey0Y42( ) ;
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
               EndLevel0Y42( ) ;
            }
         }
         CloseExtendedTableCursors0Y42( ) ;
      }

      protected void DeferredUpdate0Y42( )
      {
      }

      protected void Delete0Y42( )
      {
         if ( ! IsAuthorized("negocio_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0Y42( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0Y42( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0Y42( ) ;
            AfterConfirm0Y42( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0Y42( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000Y42 */
                  pr_default.execute(38, new Object[] {A345NegID, A435NgpItem});
                  pr_default.close(38);
                  pr_default.SmartCacheProvider.SetUpdated("tb_negociopj_item");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode42 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0Y42( ) ;
         Gx_mode = sMode42;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0Y42( )
      {
         standaloneModal0Y42( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000Y43 */
            pr_default.execute(39, new Object[] {A439NgpTppPrdID});
            A440NgpTppPrdCodigo = T000Y43_A440NgpTppPrdCodigo[0];
            A441NgpTppPrdNome = T000Y43_A441NgpTppPrdNome[0];
            A443NgpTppPrdAtivo = T000Y43_A443NgpTppPrdAtivo[0];
            A442NgpTppPrdTipoID = T000Y43_A442NgpTppPrdTipoID[0];
            pr_default.close(39);
            /* Using cursor T000Y44 */
            pr_default.execute(40, new Object[] {A478NgpTppID, A439NgpTppPrdID});
            A444NgpTpp1Preco = T000Y44_A444NgpTpp1Preco[0];
            pr_default.close(40);
            if ( IsIns( )  )
            {
               A448NegPgpTotal = (decimal)(O448NegPgpTotal+A447NgpTotal);
               n448NegPgpTotal = false;
               AssignAttri("", false, "A448NegPgpTotal", StringUtil.LTrimStr( A448NegPgpTotal, 16, 2));
            }
            else
            {
               if ( IsUpd( )  )
               {
                  A448NegPgpTotal = (decimal)(O448NegPgpTotal+A447NgpTotal-O447NgpTotal);
                  n448NegPgpTotal = false;
                  AssignAttri("", false, "A448NegPgpTotal", StringUtil.LTrimStr( A448NegPgpTotal, 16, 2));
               }
               else
               {
                  if ( IsDlt( )  )
                  {
                     A448NegPgpTotal = (decimal)(O448NegPgpTotal-O447NgpTotal);
                     n448NegPgpTotal = false;
                     AssignAttri("", false, "A448NegPgpTotal", StringUtil.LTrimStr( A448NegPgpTotal, 16, 2));
                  }
               }
            }
            A380NegValorEstimado = A448NegPgpTotal;
            AssignAttri("", false, "A380NegValorEstimado", StringUtil.LTrimStr( A380NegValorEstimado, 16, 2));
            A385NegValorAtualizado = A448NegPgpTotal;
            AssignAttri("", false, "A385NegValorAtualizado", StringUtil.LTrimStr( A385NegValorAtualizado, 16, 2));
         }
      }

      protected void EndLevel0Y42( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0Y42( )
      {
         /* Scan By routine */
         /* Using cursor T000Y45 */
         pr_default.execute(41, new Object[] {A345NegID});
         RcdFound42 = 0;
         if ( (pr_default.getStatus(41) != 101) )
         {
            RcdFound42 = 1;
            A435NgpItem = T000Y45_A435NgpItem[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0Y42( )
      {
         /* Scan next routine */
         pr_default.readNext(41);
         RcdFound42 = 0;
         if ( (pr_default.getStatus(41) != 101) )
         {
            RcdFound42 = 1;
            A435NgpItem = T000Y45_A435NgpItem[0];
         }
      }

      protected void ScanEnd0Y42( )
      {
         pr_default.close(41);
      }

      protected void AfterConfirm0Y42( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0Y42( )
      {
         /* Before Insert Rules */
         A457NgpInsDataHora = DateTimeUtil.NowMS( context);
         AssignAttri("", false, "A457NgpInsDataHora", context.localUtil.TToC( A457NgpInsDataHora, 10, 12, 0, 3, "/", ":", " "));
         A458NgpInsUsuID = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getid();
         n458NgpInsUsuID = false;
         AssignAttri("", false, "A458NgpInsUsuID", A458NgpInsUsuID);
         A459NgpInsUsuNome = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
         n459NgpInsUsuNome = false;
         AssignAttri("", false, "A459NgpInsUsuNome", A459NgpInsUsuNome);
         A455NgpInsData = DateTimeUtil.ResetTime( A457NgpInsDataHora);
         AssignAttri("", false, "A455NgpInsData", context.localUtil.Format(A455NgpInsData, "99/99/99"));
         A456NgpInsHora = DateTimeUtil.ResetDate( DateTimeUtil.ResetMilliseconds(A457NgpInsDataHora));
         AssignAttri("", false, "A456NgpInsHora", context.localUtil.TToC( A456NgpInsHora, 0, 5, 0, 3, "/", ":", " "));
      }

      protected void BeforeUpdate0Y42( )
      {
         /* Before Update Rules */
         if ( A578NgpDel && ( O578NgpDel != A578NgpDel ) )
         {
            A579NgpDelDataHora = DateTimeUtil.NowMS( context);
            n579NgpDelDataHora = false;
            AssignAttri("", false, "A579NgpDelDataHora", context.localUtil.TToC( A579NgpDelDataHora, 10, 12, 0, 3, "/", ":", " "));
         }
         if ( A578NgpDel && ( O578NgpDel != A578NgpDel ) )
         {
            A582NgpDelUsuId = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getid();
            n582NgpDelUsuId = false;
            AssignAttri("", false, "A582NgpDelUsuId", A582NgpDelUsuId);
         }
         if ( A578NgpDel && ( O578NgpDel != A578NgpDel ) )
         {
            A583NgpDelUsuNome = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
            n583NgpDelUsuNome = false;
            AssignAttri("", false, "A583NgpDelUsuNome", A583NgpDelUsuNome);
         }
         if ( A578NgpDel && ( O578NgpDel != A578NgpDel ) )
         {
            A580NgpDelData = DateTimeUtil.ResetTime( DateTimeUtil.ResetTime( A579NgpDelDataHora) ) ;
            n580NgpDelData = false;
            AssignAttri("", false, "A580NgpDelData", context.localUtil.TToC( A580NgpDelData, 10, 5, 0, 3, "/", ":", " "));
         }
         if ( A578NgpDel && ( O578NgpDel != A578NgpDel ) )
         {
            A581NgpDelHora = DateTimeUtil.ResetDate( DateTimeUtil.ResetMilliseconds(A579NgpDelDataHora));
            n581NgpDelHora = false;
            AssignAttri("", false, "A581NgpDelHora", context.localUtil.TToC( A581NgpDelHora, 0, 5, 0, 3, "/", ":", " "));
         }
      }

      protected void BeforeDelete0Y42( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0Y42( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0Y42( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0Y42( )
      {
         edtNgpItem_Enabled = 0;
         AssignProp("", false, edtNgpItem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNgpItem_Enabled), 5, 0), !bGXsfl_73_Refreshing);
         edtNgpTppID_Enabled = 0;
         AssignProp("", false, edtNgpTppID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNgpTppID_Enabled), 5, 0), !bGXsfl_73_Refreshing);
         dynNgpTppPrdID.Enabled = 0;
         AssignProp("", false, dynNgpTppPrdID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynNgpTppPrdID.Enabled), 5, 0), !bGXsfl_73_Refreshing);
         edtNgpTpp1Preco_Enabled = 0;
         AssignProp("", false, edtNgpTpp1Preco_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNgpTpp1Preco_Enabled), 5, 0), !bGXsfl_73_Refreshing);
         edtNgpPreco_Enabled = 0;
         AssignProp("", false, edtNgpPreco_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNgpPreco_Enabled), 5, 0), !bGXsfl_73_Refreshing);
         edtNgpQtde_Enabled = 0;
         AssignProp("", false, edtNgpQtde_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNgpQtde_Enabled), 5, 0), !bGXsfl_73_Refreshing);
         edtNgpTotal_Enabled = 0;
         AssignProp("", false, edtNgpTotal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNgpTotal_Enabled), 5, 0), !bGXsfl_73_Refreshing);
      }

      protected void send_integrity_lvl_hashes0Y42( )
      {
      }

      protected void send_integrity_lvl_hashes0Y37( )
      {
      }

      protected void SubsflControlProps_7342( )
      {
         edtNgpItem_Internalname = "NGPITEM_"+sGXsfl_73_idx;
         edtNgpTppID_Internalname = "NGPTPPID_"+sGXsfl_73_idx;
         dynNgpTppPrdID_Internalname = "NGPTPPPRDID_"+sGXsfl_73_idx;
         edtNgpTpp1Preco_Internalname = "NGPTPP1PRECO_"+sGXsfl_73_idx;
         edtNgpPreco_Internalname = "NGPPRECO_"+sGXsfl_73_idx;
         edtNgpQtde_Internalname = "NGPQTDE_"+sGXsfl_73_idx;
         edtNgpTotal_Internalname = "NGPTOTAL_"+sGXsfl_73_idx;
      }

      protected void SubsflControlProps_fel_7342( )
      {
         edtNgpItem_Internalname = "NGPITEM_"+sGXsfl_73_fel_idx;
         edtNgpTppID_Internalname = "NGPTPPID_"+sGXsfl_73_fel_idx;
         dynNgpTppPrdID_Internalname = "NGPTPPPRDID_"+sGXsfl_73_fel_idx;
         edtNgpTpp1Preco_Internalname = "NGPTPP1PRECO_"+sGXsfl_73_fel_idx;
         edtNgpPreco_Internalname = "NGPPRECO_"+sGXsfl_73_fel_idx;
         edtNgpQtde_Internalname = "NGPQTDE_"+sGXsfl_73_fel_idx;
         edtNgpTotal_Internalname = "NGPTOTAL_"+sGXsfl_73_fel_idx;
      }

      protected void AddRow0Y42( )
      {
         nGXsfl_73_idx = (int)(nGXsfl_73_idx+1);
         sGXsfl_73_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_73_idx), 4, 0), 4, "0");
         SubsflControlProps_7342( ) ;
         SendRow0Y42( ) ;
      }

      protected void SendRow0Y42( )
      {
         Gridlevel_itemRow = GXWebRow.GetNew(context);
         if ( subGridlevel_item_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridlevel_item_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridlevel_item_Class, "") != 0 )
            {
               subGridlevel_item_Linesclass = subGridlevel_item_Class+"Odd";
            }
         }
         else if ( subGridlevel_item_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridlevel_item_Backstyle = 0;
            subGridlevel_item_Backcolor = subGridlevel_item_Allbackcolor;
            if ( StringUtil.StrCmp(subGridlevel_item_Class, "") != 0 )
            {
               subGridlevel_item_Linesclass = subGridlevel_item_Class+"Uniform";
            }
         }
         else if ( subGridlevel_item_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridlevel_item_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridlevel_item_Class, "") != 0 )
            {
               subGridlevel_item_Linesclass = subGridlevel_item_Class+"Odd";
            }
            subGridlevel_item_Backcolor = (int)(0x0);
         }
         else if ( subGridlevel_item_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridlevel_item_Backstyle = 1;
            if ( ((int)((nGXsfl_73_idx) % (2))) == 0 )
            {
               subGridlevel_item_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_item_Class, "") != 0 )
               {
                  subGridlevel_item_Linesclass = subGridlevel_item_Class+"Even";
               }
            }
            else
            {
               subGridlevel_item_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_item_Class, "") != 0 )
               {
                  subGridlevel_item_Linesclass = subGridlevel_item_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridlevel_itemRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNgpItem_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A435NgpItem), 10, 0, ",", "")),StringUtil.LTrim( ((edtNgpItem_Enabled!=0) ? context.localUtil.Format( (decimal)(A435NgpItem), "ZZ,ZZZ,ZZ9") : context.localUtil.Format( (decimal)(A435NgpItem), "ZZ,ZZZ,ZZ9"))),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNgpItem_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn hidden-xs",(string)"",(short)-1,(int)edtNgpItem_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)73,(short)0,(short)-1,(short)0,(bool)true,(string)"core\\Seq",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_42_" + sGXsfl_73_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 75,'',false,'" + sGXsfl_73_idx + "',73)\"";
         ROClassString = "Attribute";
         Gridlevel_itemRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNgpTppID_Internalname,A478NgpTppID.ToString(),A478NgpTppID.ToString(),TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,75);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNgpTppID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtNgpTppID_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)73,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
         GXANGPTPPPRDID_html0Y42( ) ;
         /* Subfile cell */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_42_" + sGXsfl_73_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_73_idx + "',73)\"";
         if ( ( dynNgpTppPrdID.ItemCount == 0 ) && isAjaxCallMode( ) )
         {
            GXCCtl = "NGPTPPPRDID_" + sGXsfl_73_idx;
            dynNgpTppPrdID.Name = GXCCtl;
            dynNgpTppPrdID.WebTags = "";
         }
         /* ComboBox */
         Gridlevel_itemRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)dynNgpTppPrdID,(string)dynNgpTppPrdID_Internalname,A439NgpTppPrdID.ToString(),(short)1,(string)dynNgpTppPrdID_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"guid",(string)"",(short)-1,dynNgpTppPrdID.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"TrnColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,76);\"",(string)"",(bool)true,(short)0});
         dynNgpTppPrdID.CurrentValue = A439NgpTppPrdID.ToString();
         AssignProp("", false, dynNgpTppPrdID_Internalname, "Values", (string)(dynNgpTppPrdID.ToJavascriptSource()), !bGXsfl_73_Refreshing);
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridlevel_itemRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNgpTpp1Preco_Internalname,StringUtil.LTrim( StringUtil.NToC( A444NgpTpp1Preco, 23, 2, ",", "")),StringUtil.LTrim( ((edtNgpTpp1Preco_Enabled!=0) ? context.localUtil.Format( A444NgpTpp1Preco, "R$ Z,ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A444NgpTpp1Preco, "R$ Z,ZZZ,ZZZ,ZZZ,ZZ9.99"))),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNgpTpp1Preco_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtNgpTpp1Preco_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)23,(short)0,(short)0,(short)73,(short)0,(short)-1,(short)0,(bool)true,(string)"core\\Monetario",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_42_" + sGXsfl_73_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 78,'',false,'" + sGXsfl_73_idx + "',73)\"";
         ROClassString = "Attribute";
         Gridlevel_itemRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNgpPreco_Internalname,StringUtil.LTrim( StringUtil.NToC( A445NgpPreco, 23, 2, ",", "")),StringUtil.LTrim( ((edtNgpPreco_Enabled!=0) ? context.localUtil.Format( A445NgpPreco, "R$ Z,ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A445NgpPreco, "R$ Z,ZZZ,ZZZ,ZZZ,ZZ9.99"))),TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,78);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNgpPreco_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtNgpPreco_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)23,(short)0,(short)0,(short)73,(short)0,(short)-1,(short)0,(bool)true,(string)"core\\Monetario",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_42_" + sGXsfl_73_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 79,'',false,'" + sGXsfl_73_idx + "',73)\"";
         ROClassString = "Attribute";
         Gridlevel_itemRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNgpQtde_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A446NgpQtde), 8, 0, ",", "")),StringUtil.LTrim( ((edtNgpQtde_Enabled!=0) ? context.localUtil.Format( (decimal)(A446NgpQtde), "ZZZZZZZ9") : context.localUtil.Format( (decimal)(A446NgpQtde), "ZZZZZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,79);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNgpQtde_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtNgpQtde_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)73,(short)0,(short)-1,(short)0,(bool)true,(string)"core\\Quantidade",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridlevel_itemRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtNgpTotal_Internalname,StringUtil.LTrim( StringUtil.NToC( A447NgpTotal, 23, 2, ",", "")),StringUtil.LTrim( ((edtNgpTotal_Enabled!=0) ? context.localUtil.Format( A447NgpTotal, "R$ Z,ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A447NgpTotal, "R$ Z,ZZZ,ZZZ,ZZZ,ZZ9.99"))),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtNgpTotal_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtNgpTotal_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)23,(short)0,(short)0,(short)73,(short)0,(short)-1,(short)0,(bool)true,(string)"core\\Monetario",(string)"end",(bool)false,(string)""});
         ajax_sending_grid_row(Gridlevel_itemRow);
         send_integrity_lvl_hashes0Y42( ) ;
         GXCCtl = "Z435NgpItem_" + sGXsfl_73_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z435NgpItem), 8, 0, ",", "")));
         GXCCtl = "Z447NgpTotal_" + sGXsfl_73_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( Z447NgpTotal, 16, 2, ",", "")));
         GXCCtl = "Z446NgpQtde_" + sGXsfl_73_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z446NgpQtde), 8, 0, ",", "")));
         GXCCtl = "Z445NgpPreco_" + sGXsfl_73_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( Z445NgpPreco, 16, 2, ",", "")));
         GXCCtl = "Z457NgpInsDataHora_" + sGXsfl_73_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, context.localUtil.TToC( Z457NgpInsDataHora, 10, 12, 0, 0, "/", ":", " "));
         GXCCtl = "Z455NgpInsData_" + sGXsfl_73_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, context.localUtil.DToC( Z455NgpInsData, 0, "/"));
         GXCCtl = "Z456NgpInsHora_" + sGXsfl_73_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, context.localUtil.TToC( Z456NgpInsHora, 10, 8, 0, 0, "/", ":", " "));
         GXCCtl = "Z458NgpInsUsuID_" + sGXsfl_73_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z458NgpInsUsuID));
         GXCCtl = "Z459NgpInsUsuNome_" + sGXsfl_73_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z459NgpInsUsuNome);
         GXCCtl = "Z579NgpDelDataHora_" + sGXsfl_73_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, context.localUtil.TToC( Z579NgpDelDataHora, 10, 12, 0, 0, "/", ":", " "));
         GXCCtl = "Z580NgpDelData_" + sGXsfl_73_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, context.localUtil.TToC( Z580NgpDelData, 10, 8, 0, 0, "/", ":", " "));
         GXCCtl = "Z581NgpDelHora_" + sGXsfl_73_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, context.localUtil.TToC( Z581NgpDelHora, 10, 8, 0, 0, "/", ":", " "));
         GXCCtl = "Z582NgpDelUsuId_" + sGXsfl_73_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z582NgpDelUsuId));
         GXCCtl = "Z583NgpDelUsuNome_" + sGXsfl_73_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z583NgpDelUsuNome);
         GXCCtl = "Z453NgpObs_" + sGXsfl_73_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z453NgpObs);
         GXCCtl = "Z578NgpDel_" + sGXsfl_73_idx;
         GxWebStd.gx_boolean_hidden_field( context, GXCCtl, Z578NgpDel);
         GXCCtl = "Z439NgpTppPrdID_" + sGXsfl_73_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z439NgpTppPrdID.ToString());
         GXCCtl = "Z478NgpTppID_" + sGXsfl_73_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z478NgpTppID.ToString());
         GXCCtl = "O578NgpDel_" + sGXsfl_73_idx;
         GxWebStd.gx_boolean_hidden_field( context, GXCCtl, O578NgpDel);
         GXCCtl = "O447NgpTotal_" + sGXsfl_73_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( O447NgpTotal, 16, 2, ",", "")));
         GXCCtl = "NGPINSDATAHORA_" + sGXsfl_73_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, context.localUtil.TToC( A457NgpInsDataHora, 10, 12, 0, 0, "/", ":", " "));
         GXCCtl = "NGPDELDATAHORA_" + sGXsfl_73_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, context.localUtil.TToC( A579NgpDelDataHora, 10, 12, 0, 0, "/", ":", " "));
         GXCCtl = "nRcdDeleted_42_" + sGXsfl_73_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_42), 4, 0, ",", "")));
         GXCCtl = "nRcdExists_42_" + sGXsfl_73_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_42), 4, 0, ",", "")));
         GXCCtl = "nIsMod_42_" + sGXsfl_73_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_42), 4, 0, ",", "")));
         GXCCtl = "vAUDITINGOBJECT_" + sGXsfl_73_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV47AuditingObject);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV47AuditingObject);
         }
         GXCCtl = "vPGMNAME_" + sGXsfl_73_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( AV49Pgmname));
         GXCCtl = "vMODE_" + sGXsfl_73_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_73_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV11TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV11TrnContext);
         }
         GXCCtl = "vNEGID_" + sGXsfl_73_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, AV7NegID.ToString());
         GXCCtl = "NEGID_" + sGXsfl_73_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, A345NegID.ToString());
         GxWebStd.gx_hidden_field( context, "NGPITEM_"+sGXsfl_73_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNgpItem_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "NGPTPPID_"+sGXsfl_73_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNgpTppID_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "NGPTPPPRDID_"+sGXsfl_73_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynNgpTppPrdID.Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "NGPTPP1PRECO_"+sGXsfl_73_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNgpTpp1Preco_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "NGPPRECO_"+sGXsfl_73_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNgpPreco_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "NGPQTDE_"+sGXsfl_73_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNgpQtde_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "NGPTOTAL_"+sGXsfl_73_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNgpTotal_Enabled), 5, 0, ".", "")));
         ajax_sending_grid_row(null);
         Gridlevel_itemContainer.AddRow(Gridlevel_itemRow);
      }

      protected void ReadRow0Y42( )
      {
         nGXsfl_73_idx = (int)(nGXsfl_73_idx+1);
         sGXsfl_73_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_73_idx), 4, 0), 4, "0");
         SubsflControlProps_7342( ) ;
         edtNgpItem_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "NGPITEM_"+sGXsfl_73_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
         edtNgpTppID_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "NGPTPPID_"+sGXsfl_73_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
         dynNgpTppPrdID.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "NGPTPPPRDID_"+sGXsfl_73_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
         edtNgpTpp1Preco_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "NGPTPP1PRECO_"+sGXsfl_73_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
         edtNgpPreco_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "NGPPRECO_"+sGXsfl_73_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
         edtNgpQtde_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "NGPQTDE_"+sGXsfl_73_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
         edtNgpTotal_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "NGPTOTAL_"+sGXsfl_73_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
         A435NgpItem = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtNgpItem_Internalname), ",", "."), 18, MidpointRounding.ToEven));
         if ( StringUtil.StrCmp(cgiGet( edtNgpTppID_Internalname), "") == 0 )
         {
            A478NgpTppID = Guid.Empty;
         }
         else
         {
            try
            {
               A478NgpTppID = StringUtil.StrToGuid( cgiGet( edtNgpTppID_Internalname));
            }
            catch ( Exception  )
            {
               GXCCtl = "NGPTPPID_" + sGXsfl_73_idx;
               GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, GXCCtl);
               AnyError = 1;
               GX_FocusControl = edtNgpTppID_Internalname;
               wbErr = true;
            }
         }
         dynNgpTppPrdID.Name = dynNgpTppPrdID_Internalname;
         dynNgpTppPrdID.CurrentValue = cgiGet( dynNgpTppPrdID_Internalname);
         A439NgpTppPrdID = StringUtil.StrToGuid( cgiGet( dynNgpTppPrdID_Internalname));
         A444NgpTpp1Preco = context.localUtil.CToN( cgiGet( edtNgpTpp1Preco_Internalname), ",", ".");
         if ( ( ( context.localUtil.CToN( cgiGet( edtNgpPreco_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtNgpPreco_Internalname), ",", ".") > 9999999999999.99m ) ) )
         {
            GXCCtl = "NGPPRECO_" + sGXsfl_73_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtNgpPreco_Internalname;
            wbErr = true;
            A445NgpPreco = 0;
         }
         else
         {
            A445NgpPreco = context.localUtil.CToN( cgiGet( edtNgpPreco_Internalname), ",", ".");
         }
         if ( ( ( context.localUtil.CToN( cgiGet( edtNgpQtde_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtNgpQtde_Internalname), ",", ".") > Convert.ToDecimal( 99999999 )) ) )
         {
            GXCCtl = "NGPQTDE_" + sGXsfl_73_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtNgpQtde_Internalname;
            wbErr = true;
            A446NgpQtde = 0;
         }
         else
         {
            A446NgpQtde = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtNgpQtde_Internalname), ",", "."), 18, MidpointRounding.ToEven));
         }
         A447NgpTotal = context.localUtil.CToN( cgiGet( edtNgpTotal_Internalname), ",", ".");
         GXCCtl = "Z435NgpItem_" + sGXsfl_73_idx;
         Z435NgpItem = (int)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."), 18, MidpointRounding.ToEven));
         GXCCtl = "Z447NgpTotal_" + sGXsfl_73_idx;
         Z447NgpTotal = context.localUtil.CToN( cgiGet( GXCCtl), ",", ".");
         GXCCtl = "Z446NgpQtde_" + sGXsfl_73_idx;
         Z446NgpQtde = (int)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."), 18, MidpointRounding.ToEven));
         GXCCtl = "Z445NgpPreco_" + sGXsfl_73_idx;
         Z445NgpPreco = context.localUtil.CToN( cgiGet( GXCCtl), ",", ".");
         GXCCtl = "Z457NgpInsDataHora_" + sGXsfl_73_idx;
         Z457NgpInsDataHora = context.localUtil.CToT( cgiGet( GXCCtl), 0);
         GXCCtl = "Z455NgpInsData_" + sGXsfl_73_idx;
         Z455NgpInsData = context.localUtil.CToD( cgiGet( GXCCtl), 0);
         GXCCtl = "Z456NgpInsHora_" + sGXsfl_73_idx;
         Z456NgpInsHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( GXCCtl), 0));
         GXCCtl = "Z458NgpInsUsuID_" + sGXsfl_73_idx;
         Z458NgpInsUsuID = cgiGet( GXCCtl);
         n458NgpInsUsuID = (String.IsNullOrEmpty(StringUtil.RTrim( A458NgpInsUsuID)) ? true : false);
         GXCCtl = "Z459NgpInsUsuNome_" + sGXsfl_73_idx;
         Z459NgpInsUsuNome = cgiGet( GXCCtl);
         n459NgpInsUsuNome = (String.IsNullOrEmpty(StringUtil.RTrim( A459NgpInsUsuNome)) ? true : false);
         GXCCtl = "Z579NgpDelDataHora_" + sGXsfl_73_idx;
         Z579NgpDelDataHora = context.localUtil.CToT( cgiGet( GXCCtl), 0);
         n579NgpDelDataHora = ((DateTime.MinValue==A579NgpDelDataHora) ? true : false);
         GXCCtl = "Z580NgpDelData_" + sGXsfl_73_idx;
         Z580NgpDelData = context.localUtil.CToT( cgiGet( GXCCtl), 0);
         n580NgpDelData = ((DateTime.MinValue==A580NgpDelData) ? true : false);
         GXCCtl = "Z581NgpDelHora_" + sGXsfl_73_idx;
         Z581NgpDelHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( GXCCtl), 0));
         n581NgpDelHora = ((DateTime.MinValue==A581NgpDelHora) ? true : false);
         GXCCtl = "Z582NgpDelUsuId_" + sGXsfl_73_idx;
         Z582NgpDelUsuId = cgiGet( GXCCtl);
         n582NgpDelUsuId = (String.IsNullOrEmpty(StringUtil.RTrim( A582NgpDelUsuId)) ? true : false);
         GXCCtl = "Z583NgpDelUsuNome_" + sGXsfl_73_idx;
         Z583NgpDelUsuNome = cgiGet( GXCCtl);
         n583NgpDelUsuNome = (String.IsNullOrEmpty(StringUtil.RTrim( A583NgpDelUsuNome)) ? true : false);
         GXCCtl = "Z453NgpObs_" + sGXsfl_73_idx;
         Z453NgpObs = cgiGet( GXCCtl);
         GXCCtl = "Z578NgpDel_" + sGXsfl_73_idx;
         Z578NgpDel = StringUtil.StrToBool( cgiGet( GXCCtl));
         GXCCtl = "Z439NgpTppPrdID_" + sGXsfl_73_idx;
         Z439NgpTppPrdID = StringUtil.StrToGuid( cgiGet( GXCCtl));
         GXCCtl = "Z478NgpTppID_" + sGXsfl_73_idx;
         Z478NgpTppID = StringUtil.StrToGuid( cgiGet( GXCCtl));
         GXCCtl = "Z457NgpInsDataHora_" + sGXsfl_73_idx;
         A457NgpInsDataHora = context.localUtil.CToT( cgiGet( GXCCtl), 0);
         GXCCtl = "Z455NgpInsData_" + sGXsfl_73_idx;
         A455NgpInsData = context.localUtil.CToD( cgiGet( GXCCtl), 0);
         GXCCtl = "Z456NgpInsHora_" + sGXsfl_73_idx;
         A456NgpInsHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( GXCCtl), 0));
         GXCCtl = "Z458NgpInsUsuID_" + sGXsfl_73_idx;
         A458NgpInsUsuID = cgiGet( GXCCtl);
         n458NgpInsUsuID = false;
         n458NgpInsUsuID = (String.IsNullOrEmpty(StringUtil.RTrim( A458NgpInsUsuID)) ? true : false);
         GXCCtl = "Z459NgpInsUsuNome_" + sGXsfl_73_idx;
         A459NgpInsUsuNome = cgiGet( GXCCtl);
         n459NgpInsUsuNome = false;
         n459NgpInsUsuNome = (String.IsNullOrEmpty(StringUtil.RTrim( A459NgpInsUsuNome)) ? true : false);
         GXCCtl = "Z579NgpDelDataHora_" + sGXsfl_73_idx;
         A579NgpDelDataHora = context.localUtil.CToT( cgiGet( GXCCtl), 0);
         n579NgpDelDataHora = false;
         n579NgpDelDataHora = ((DateTime.MinValue==A579NgpDelDataHora) ? true : false);
         GXCCtl = "Z580NgpDelData_" + sGXsfl_73_idx;
         A580NgpDelData = context.localUtil.CToT( cgiGet( GXCCtl), 0);
         n580NgpDelData = false;
         n580NgpDelData = ((DateTime.MinValue==A580NgpDelData) ? true : false);
         GXCCtl = "Z581NgpDelHora_" + sGXsfl_73_idx;
         A581NgpDelHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( GXCCtl), 0));
         n581NgpDelHora = false;
         n581NgpDelHora = ((DateTime.MinValue==A581NgpDelHora) ? true : false);
         GXCCtl = "Z582NgpDelUsuId_" + sGXsfl_73_idx;
         A582NgpDelUsuId = cgiGet( GXCCtl);
         n582NgpDelUsuId = false;
         n582NgpDelUsuId = (String.IsNullOrEmpty(StringUtil.RTrim( A582NgpDelUsuId)) ? true : false);
         GXCCtl = "Z583NgpDelUsuNome_" + sGXsfl_73_idx;
         A583NgpDelUsuNome = cgiGet( GXCCtl);
         n583NgpDelUsuNome = false;
         n583NgpDelUsuNome = (String.IsNullOrEmpty(StringUtil.RTrim( A583NgpDelUsuNome)) ? true : false);
         GXCCtl = "Z453NgpObs_" + sGXsfl_73_idx;
         A453NgpObs = cgiGet( GXCCtl);
         GXCCtl = "Z578NgpDel_" + sGXsfl_73_idx;
         A578NgpDel = StringUtil.StrToBool( cgiGet( GXCCtl));
         GXCCtl = "O578NgpDel_" + sGXsfl_73_idx;
         O578NgpDel = StringUtil.StrToBool( cgiGet( GXCCtl));
         GXCCtl = "O447NgpTotal_" + sGXsfl_73_idx;
         O447NgpTotal = context.localUtil.CToN( cgiGet( GXCCtl), ",", ".");
         GXCCtl = "NGPINSDATAHORA_" + sGXsfl_73_idx;
         A457NgpInsDataHora = context.localUtil.CToT( cgiGet( GXCCtl), 0);
         GXCCtl = "NGPDELDATAHORA_" + sGXsfl_73_idx;
         A579NgpDelDataHora = context.localUtil.CToT( cgiGet( GXCCtl), 0);
         n579NgpDelDataHora = ((DateTime.MinValue==A579NgpDelDataHora) ? true : false);
         GXCCtl = "nRcdDeleted_42_" + sGXsfl_73_idx;
         nRcdDeleted_42 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_42_" + sGXsfl_73_idx;
         nRcdExists_42 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_42_" + sGXsfl_73_idx;
         nIsMod_42 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."), 18, MidpointRounding.ToEven));
      }

      protected void assign_properties_default( )
      {
         defedtNgpItem_Enabled = edtNgpItem_Enabled;
      }

      protected void ConfirmValues0Y0( )
      {
         nGXsfl_73_idx = 0;
         sGXsfl_73_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_73_idx), 4, 0), 4, "0");
         SubsflControlProps_7342( ) ;
         while ( nGXsfl_73_idx < nRC_GXsfl_73 )
         {
            nGXsfl_73_idx = (int)(nGXsfl_73_idx+1);
            sGXsfl_73_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_73_idx), 4, 0), 4, "0");
            SubsflControlProps_7342( ) ;
            ChangePostValue( "Z435NgpItem_"+sGXsfl_73_idx, cgiGet( "ZT_"+"Z435NgpItem_"+sGXsfl_73_idx)) ;
            DeletePostValue( "ZT_"+"Z435NgpItem_"+sGXsfl_73_idx) ;
            ChangePostValue( "Z447NgpTotal_"+sGXsfl_73_idx, cgiGet( "ZT_"+"Z447NgpTotal_"+sGXsfl_73_idx)) ;
            DeletePostValue( "ZT_"+"Z447NgpTotal_"+sGXsfl_73_idx) ;
            ChangePostValue( "Z446NgpQtde_"+sGXsfl_73_idx, cgiGet( "ZT_"+"Z446NgpQtde_"+sGXsfl_73_idx)) ;
            DeletePostValue( "ZT_"+"Z446NgpQtde_"+sGXsfl_73_idx) ;
            ChangePostValue( "Z445NgpPreco_"+sGXsfl_73_idx, cgiGet( "ZT_"+"Z445NgpPreco_"+sGXsfl_73_idx)) ;
            DeletePostValue( "ZT_"+"Z445NgpPreco_"+sGXsfl_73_idx) ;
            ChangePostValue( "Z457NgpInsDataHora_"+sGXsfl_73_idx, cgiGet( "ZT_"+"Z457NgpInsDataHora_"+sGXsfl_73_idx)) ;
            DeletePostValue( "ZT_"+"Z457NgpInsDataHora_"+sGXsfl_73_idx) ;
            ChangePostValue( "Z455NgpInsData_"+sGXsfl_73_idx, cgiGet( "ZT_"+"Z455NgpInsData_"+sGXsfl_73_idx)) ;
            DeletePostValue( "ZT_"+"Z455NgpInsData_"+sGXsfl_73_idx) ;
            ChangePostValue( "Z456NgpInsHora_"+sGXsfl_73_idx, cgiGet( "ZT_"+"Z456NgpInsHora_"+sGXsfl_73_idx)) ;
            DeletePostValue( "ZT_"+"Z456NgpInsHora_"+sGXsfl_73_idx) ;
            ChangePostValue( "Z458NgpInsUsuID_"+sGXsfl_73_idx, cgiGet( "ZT_"+"Z458NgpInsUsuID_"+sGXsfl_73_idx)) ;
            DeletePostValue( "ZT_"+"Z458NgpInsUsuID_"+sGXsfl_73_idx) ;
            ChangePostValue( "Z459NgpInsUsuNome_"+sGXsfl_73_idx, cgiGet( "ZT_"+"Z459NgpInsUsuNome_"+sGXsfl_73_idx)) ;
            DeletePostValue( "ZT_"+"Z459NgpInsUsuNome_"+sGXsfl_73_idx) ;
            ChangePostValue( "Z579NgpDelDataHora_"+sGXsfl_73_idx, cgiGet( "ZT_"+"Z579NgpDelDataHora_"+sGXsfl_73_idx)) ;
            DeletePostValue( "ZT_"+"Z579NgpDelDataHora_"+sGXsfl_73_idx) ;
            ChangePostValue( "Z580NgpDelData_"+sGXsfl_73_idx, cgiGet( "ZT_"+"Z580NgpDelData_"+sGXsfl_73_idx)) ;
            DeletePostValue( "ZT_"+"Z580NgpDelData_"+sGXsfl_73_idx) ;
            ChangePostValue( "Z581NgpDelHora_"+sGXsfl_73_idx, cgiGet( "ZT_"+"Z581NgpDelHora_"+sGXsfl_73_idx)) ;
            DeletePostValue( "ZT_"+"Z581NgpDelHora_"+sGXsfl_73_idx) ;
            ChangePostValue( "Z582NgpDelUsuId_"+sGXsfl_73_idx, cgiGet( "ZT_"+"Z582NgpDelUsuId_"+sGXsfl_73_idx)) ;
            DeletePostValue( "ZT_"+"Z582NgpDelUsuId_"+sGXsfl_73_idx) ;
            ChangePostValue( "Z583NgpDelUsuNome_"+sGXsfl_73_idx, cgiGet( "ZT_"+"Z583NgpDelUsuNome_"+sGXsfl_73_idx)) ;
            DeletePostValue( "ZT_"+"Z583NgpDelUsuNome_"+sGXsfl_73_idx) ;
            ChangePostValue( "Z453NgpObs_"+sGXsfl_73_idx, cgiGet( "ZT_"+"Z453NgpObs_"+sGXsfl_73_idx)) ;
            DeletePostValue( "ZT_"+"Z453NgpObs_"+sGXsfl_73_idx) ;
            ChangePostValue( "Z578NgpDel_"+sGXsfl_73_idx, cgiGet( "ZT_"+"Z578NgpDel_"+sGXsfl_73_idx)) ;
            DeletePostValue( "ZT_"+"Z578NgpDel_"+sGXsfl_73_idx) ;
            ChangePostValue( "Z439NgpTppPrdID_"+sGXsfl_73_idx, cgiGet( "ZT_"+"Z439NgpTppPrdID_"+sGXsfl_73_idx)) ;
            DeletePostValue( "ZT_"+"Z439NgpTppPrdID_"+sGXsfl_73_idx) ;
            ChangePostValue( "Z478NgpTppID_"+sGXsfl_73_idx, cgiGet( "ZT_"+"Z478NgpTppID_"+sGXsfl_73_idx)) ;
            DeletePostValue( "ZT_"+"Z478NgpTppID_"+sGXsfl_73_idx) ;
         }
         ChangePostValue( "O578NgpDel", cgiGet( "T578NgpDel")) ;
         DeletePostValue( "T578NgpDel") ;
         ChangePostValue( "O447NgpTotal", cgiGet( "T447NgpTotal")) ;
         DeletePostValue( "T447NgpTotal") ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("CKEditor/ckeditor/ckeditor.js", "", false, true);
         context.AddJavascriptSource("CKEditor/CKEditorRender.js", "", false, true);
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
         GXEncryptionTmp = "core.negociopj.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV7NegID.ToString());
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("core.negociopj.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"NegocioPJ");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("NegAgcID", StringUtil.RTrim( context.localUtil.Format( A360NegAgcID, "")));
         forbiddenHiddens.Add("NegAgcNome", StringUtil.RTrim( context.localUtil.Format( A361NegAgcNome, "@!")));
         forbiddenHiddens.Add("NegDel", StringUtil.BoolToStr( A572NegDel));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("core\\negociopj:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z345NegID", Z345NegID.ToString());
         GxWebStd.gx_hidden_field( context, "Z356NegCodigo", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z356NegCodigo), 12, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z348NegInsDataHora", context.localUtil.TToC( Z348NegInsDataHora, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z346NegInsData", context.localUtil.DToC( Z346NegInsData, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z347NegInsHora", context.localUtil.TToC( Z347NegInsHora, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z349NegInsUsuID", StringUtil.RTrim( Z349NegInsUsuID));
         GxWebStd.gx_hidden_field( context, "Z364NegInsUsuNome", Z364NegInsUsuNome);
         GxWebStd.gx_hidden_field( context, "Z385NegValorAtualizado", StringUtil.LTrim( StringUtil.NToC( Z385NegValorAtualizado, 16, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z380NegValorEstimado", StringUtil.LTrim( StringUtil.NToC( Z380NegValorEstimado, 16, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z573NegDelDataHora", context.localUtil.TToC( Z573NegDelDataHora, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z574NegDelData", context.localUtil.TToC( Z574NegDelData, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z575NegDelHora", context.localUtil.TToC( Z575NegDelHora, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z576NegDelUsuId", StringUtil.RTrim( Z576NegDelUsuId));
         GxWebStd.gx_hidden_field( context, "Z577NegDelUsuNome", Z577NegDelUsuNome);
         GxWebStd.gx_hidden_field( context, "Z360NegAgcID", StringUtil.RTrim( Z360NegAgcID));
         GxWebStd.gx_hidden_field( context, "Z361NegAgcNome", Z361NegAgcNome);
         GxWebStd.gx_hidden_field( context, "Z362NegAssunto", Z362NegAssunto);
         GxWebStd.gx_hidden_field( context, "Z454NegUltItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z454NegUltItem), 8, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "Z572NegDel", Z572NegDel);
         GxWebStd.gx_hidden_field( context, "Z350NegCliID", Z350NegCliID.ToString());
         GxWebStd.gx_hidden_field( context, "Z352NegCpjID", Z352NegCpjID.ToString());
         GxWebStd.gx_hidden_field( context, "Z369NegCpjEndSeq", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z369NegCpjEndSeq), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "O454NegUltItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(O454NegUltItem), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "O448NegPgpTotal", StringUtil.LTrim( StringUtil.NToC( O448NegPgpTotal, 16, 2, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "O572NegDel", O572NegDel);
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_73", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_73_idx), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N350NegCliID", A350NegCliID.ToString());
         GxWebStd.gx_hidden_field( context, "N352NegCpjID", A352NegCpjID.ToString());
         GxWebStd.gx_hidden_field( context, "N369NegCpjEndSeq", StringUtil.LTrim( StringUtil.NToC( (decimal)(A369NegCpjEndSeq), 4, 0, ",", "")));
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vNEGCLIID_DATA", AV16NegCliID_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vNEGCLIID_DATA", AV16NegCliID_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vNEGCPJID_DATA", AV25NegCpjID_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vNEGCPJID_DATA", AV25NegCpjID_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vNEGCPJENDSEQ_DATA", AV29NegCpjEndSeq_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vNEGCPJENDSEQ_DATA", AV29NegCpjEndSeq_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vNGPTPPID_DATA", AV40NgpTppID_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vNGPTPPID_DATA", AV40NgpTppID_Data);
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
         GxWebStd.gx_hidden_field( context, "NEGCPJENDENDERECO", A371NegCpjEndEndereco);
         GxWebStd.gx_hidden_field( context, "NEGCPJENDBAIRRO", A374NegCpjEndBairro);
         GxWebStd.gx_hidden_field( context, "NEGCPJENDCEPFORMAT", A643NegCpjEndCepFormat);
         GxWebStd.gx_hidden_field( context, "NEGCPJENDMUNNOME", A376NegCpjEndMunNome);
         GxWebStd.gx_hidden_field( context, "NEGCPJENDUFSIGLA", A378NegCpjEndUFSigla);
         GxWebStd.gx_hidden_field( context, "NEGCPJENDNUMERO", A372NegCpjEndNumero);
         GxWebStd.gx_hidden_field( context, "NEGCPJENDCOMPLEM", A373NegCpjEndComplem);
         GxWebStd.gx_hidden_field( context, "NEGCPJENDCOMPLETO", A641NegCpjEndCompleto);
         GxWebStd.gx_hidden_field( context, "vNEGID", AV7NegID.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vNEGID", GetSecureSignedToken( "", AV7NegID, context));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "NEGID", A345NegID.ToString());
         GxWebStd.gx_hidden_field( context, "vINSERT_NEGCLIID", AV13Insert_NegCliID.ToString());
         GxWebStd.gx_hidden_field( context, "vINSERT_NEGCPJID", AV14Insert_NegCpjID.ToString());
         GxWebStd.gx_hidden_field( context, "vINSERT_NEGCPJENDSEQ", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV28Insert_NegCpjEndSeq), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "NEGINSDATAHORA", context.localUtil.TToC( A348NegInsDataHora, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "NEGINSDATA", context.localUtil.DToC( A346NegInsData, 0, "/"));
         GxWebStd.gx_hidden_field( context, "NEGINSHORA", context.localUtil.TToC( A347NegInsHora, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "NEGINSUSUID", StringUtil.RTrim( A349NegInsUsuID));
         GxWebStd.gx_hidden_field( context, "NEGINSUSUNOME", A364NegInsUsuNome);
         GxWebStd.gx_hidden_field( context, "NEGVALORATUALIZADO", StringUtil.LTrim( StringUtil.NToC( A385NegValorAtualizado, 16, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "NEGPGPTOTAL", StringUtil.LTrim( StringUtil.NToC( A448NegPgpTotal, 16, 2, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "NEGDEL", A572NegDel);
         GxWebStd.gx_hidden_field( context, "NEGDELDATAHORA", context.localUtil.TToC( A573NegDelDataHora, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "NEGDELDATA", context.localUtil.TToC( A574NegDelData, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "NEGDELHORA", context.localUtil.TToC( A575NegDelHora, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "NEGDELUSUID", StringUtil.RTrim( A576NegDelUsuId));
         GxWebStd.gx_hidden_field( context, "NEGDELUSUNOME", A577NegDelUsuNome);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAUDITINGOBJECT", AV47AuditingObject);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAUDITINGOBJECT", AV47AuditingObject);
         }
         GxWebStd.gx_hidden_field( context, "NEGAGCID", StringUtil.RTrim( A360NegAgcID));
         GxWebStd.gx_hidden_field( context, "NEGAGCNOME", A361NegAgcNome);
         GxWebStd.gx_hidden_field( context, "NEGDESCRICAO", A363NegDescricao);
         GxWebStd.gx_hidden_field( context, "NEGULTITEM", StringUtil.LTrim( StringUtil.NToC( (decimal)(A454NegUltItem), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "NEGCLIMATRICULA", StringUtil.LTrim( StringUtil.NToC( (decimal)(A473NegCliMatricula), 12, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "NEGCLINOMEFAMILIAR", A351NegCliNomeFamiliar);
         GxWebStd.gx_hidden_field( context, "NEGCPJNOMFAN", A353NegCpjNomFan);
         GxWebStd.gx_hidden_field( context, "NEGCPJRAZSOCIAL", A354NegCpjRazSocial);
         GxWebStd.gx_hidden_field( context, "NEGCPJMATRICULA", StringUtil.LTrim( StringUtil.NToC( (decimal)(A355NegCpjMatricula), 12, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "NEGPJTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A357NegPjtID), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "NEGCPJENDNOME", A370NegCpjEndNome);
         GxWebStd.gx_hidden_field( context, "NEGCPJENDCEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(A642NegCpjEndCep), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "NEGCPJENDMUNID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A375NegCpjEndMunID), 7, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "NEGCPJENDUFID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A377NegCpjEndUFID), 2, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "NEGCPJENDUFNOME", A379NegCpjEndUFNome);
         GxWebStd.gx_hidden_field( context, "NEGPJTSIGLA", A358NegPjtSigla);
         GxWebStd.gx_hidden_field( context, "NEGPJTNOME", A359NegPjtNome);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV49Pgmname));
         GxWebStd.gx_hidden_field( context, "NGPINSDATAHORA", context.localUtil.TToC( A457NgpInsDataHora, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "NGPINSDATA", context.localUtil.DToC( A455NgpInsData, 0, "/"));
         GxWebStd.gx_hidden_field( context, "NGPINSHORA", context.localUtil.TToC( A456NgpInsHora, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "NGPINSUSUID", StringUtil.RTrim( A458NgpInsUsuID));
         GxWebStd.gx_hidden_field( context, "NGPINSUSUNOME", A459NgpInsUsuNome);
         GxWebStd.gx_boolean_hidden_field( context, "NGPDEL", A578NgpDel);
         GxWebStd.gx_hidden_field( context, "NGPDELDATAHORA", context.localUtil.TToC( A579NgpDelDataHora, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "NGPDELDATA", context.localUtil.TToC( A580NgpDelData, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "NGPDELHORA", context.localUtil.TToC( A581NgpDelHora, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "NGPDELUSUID", StringUtil.RTrim( A582NgpDelUsuId));
         GxWebStd.gx_hidden_field( context, "NGPDELUSUNOME", A583NgpDelUsuNome);
         GxWebStd.gx_hidden_field( context, "NGPOBS", A453NgpObs);
         GxWebStd.gx_hidden_field( context, "NGPTPPPRDCODIGO", A440NgpTppPrdCodigo);
         GxWebStd.gx_hidden_field( context, "NGPTPPPRDNOME", A441NgpTppPrdNome);
         GxWebStd.gx_boolean_hidden_field( context, "NGPTPPPRDATIVO", A443NgpTppPrdAtivo);
         GxWebStd.gx_hidden_field( context, "NGPTPPPRDTIPOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A442NgpTppPrdTipoID), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "COMBO_NEGCLIID_Objectcall", StringUtil.RTrim( Combo_negcliid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_NEGCLIID_Cls", StringUtil.RTrim( Combo_negcliid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_NEGCLIID_Selectedvalue_set", StringUtil.RTrim( Combo_negcliid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_NEGCLIID_Enabled", StringUtil.BoolToStr( Combo_negcliid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_NEGCLIID_Includeaddnewoption", StringUtil.BoolToStr( Combo_negcliid_Includeaddnewoption));
         GxWebStd.gx_hidden_field( context, "COMBO_NEGCLIID_Htmltemplate", StringUtil.RTrim( Combo_negcliid_Htmltemplate));
         GxWebStd.gx_hidden_field( context, "COMBO_NEGCLIID_Emptyitemtext", StringUtil.RTrim( Combo_negcliid_Emptyitemtext));
         GxWebStd.gx_hidden_field( context, "COMBO_NEGCPJID_Objectcall", StringUtil.RTrim( Combo_negcpjid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_NEGCPJID_Cls", StringUtil.RTrim( Combo_negcpjid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_NEGCPJID_Selectedvalue_set", StringUtil.RTrim( Combo_negcpjid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_NEGCPJID_Selectedtext_set", StringUtil.RTrim( Combo_negcpjid_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_NEGCPJID_Gamoauthtoken", StringUtil.RTrim( Combo_negcpjid_Gamoauthtoken));
         GxWebStd.gx_hidden_field( context, "COMBO_NEGCPJID_Enabled", StringUtil.BoolToStr( Combo_negcpjid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_NEGCPJID_Datalistproc", StringUtil.RTrim( Combo_negcpjid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_NEGCPJID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_negcpjid_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_NEGCPJID_Includeaddnewoption", StringUtil.BoolToStr( Combo_negcpjid_Includeaddnewoption));
         GxWebStd.gx_hidden_field( context, "COMBO_NEGCPJID_Htmltemplate", StringUtil.RTrim( Combo_negcpjid_Htmltemplate));
         GxWebStd.gx_hidden_field( context, "COMBO_NEGCPJID_Emptyitemtext", StringUtil.RTrim( Combo_negcpjid_Emptyitemtext));
         GxWebStd.gx_hidden_field( context, "COMBO_NEGCPJENDSEQ_Objectcall", StringUtil.RTrim( Combo_negcpjendseq_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_NEGCPJENDSEQ_Cls", StringUtil.RTrim( Combo_negcpjendseq_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_NEGCPJENDSEQ_Selectedvalue_set", StringUtil.RTrim( Combo_negcpjendseq_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_NEGCPJENDSEQ_Selectedtext_set", StringUtil.RTrim( Combo_negcpjendseq_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_NEGCPJENDSEQ_Gamoauthtoken", StringUtil.RTrim( Combo_negcpjendseq_Gamoauthtoken));
         GxWebStd.gx_hidden_field( context, "COMBO_NEGCPJENDSEQ_Enabled", StringUtil.BoolToStr( Combo_negcpjendseq_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_NEGCPJENDSEQ_Datalistproc", StringUtil.RTrim( Combo_negcpjendseq_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_NEGCPJENDSEQ_Datalistprocparametersprefix", StringUtil.RTrim( Combo_negcpjendseq_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_NEGCPJENDSEQ_Includeaddnewoption", StringUtil.BoolToStr( Combo_negcpjendseq_Includeaddnewoption));
         GxWebStd.gx_hidden_field( context, "COMBO_NEGCPJENDSEQ_Htmltemplate", StringUtil.RTrim( Combo_negcpjendseq_Htmltemplate));
         GxWebStd.gx_hidden_field( context, "COMBO_NEGCPJENDSEQ_Emptyitemtext", StringUtil.RTrim( Combo_negcpjendseq_Emptyitemtext));
         GxWebStd.gx_hidden_field( context, "NEGDESCRICAO_Objectcall", StringUtil.RTrim( Negdescricao_Objectcall));
         GxWebStd.gx_hidden_field( context, "NEGDESCRICAO_Enabled", StringUtil.BoolToStr( Negdescricao_Enabled));
         GxWebStd.gx_hidden_field( context, "NEGDESCRICAO_Width", StringUtil.RTrim( Negdescricao_Width));
         GxWebStd.gx_hidden_field( context, "NEGDESCRICAO_Height", StringUtil.RTrim( Negdescricao_Height));
         GxWebStd.gx_hidden_field( context, "NEGDESCRICAO_Skin", StringUtil.RTrim( Negdescricao_Skin));
         GxWebStd.gx_hidden_field( context, "NEGDESCRICAO_Toolbar", StringUtil.RTrim( Negdescricao_Toolbar));
         GxWebStd.gx_hidden_field( context, "NEGDESCRICAO_Toolbarcancollapse", StringUtil.BoolToStr( Negdescricao_Toolbarcancollapse));
         GxWebStd.gx_hidden_field( context, "NEGDESCRICAO_Color", StringUtil.LTrim( StringUtil.NToC( (decimal)(Negdescricao_Color), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "NEGDESCRICAO_Captionclass", StringUtil.RTrim( Negdescricao_Captionclass));
         GxWebStd.gx_hidden_field( context, "NEGDESCRICAO_Captionstyle", StringUtil.RTrim( Negdescricao_Captionstyle));
         GxWebStd.gx_hidden_field( context, "NEGDESCRICAO_Captionposition", StringUtil.RTrim( Negdescricao_Captionposition));
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
         GxWebStd.gx_hidden_field( context, "COMBO_NGPTPPID_Objectcall", StringUtil.RTrim( Combo_ngptppid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_NGPTPPID_Cls", StringUtil.RTrim( Combo_ngptppid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_NGPTPPID_Enabled", StringUtil.BoolToStr( Combo_ngptppid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_NGPTPPID_Titlecontrolidtoreplace", StringUtil.RTrim( Combo_ngptppid_Titlecontrolidtoreplace));
         GxWebStd.gx_hidden_field( context, "COMBO_NGPTPPID_Isgriditem", StringUtil.BoolToStr( Combo_ngptppid_Isgriditem));
         GxWebStd.gx_hidden_field( context, "COMBO_NGPTPPID_Htmltemplate", StringUtil.RTrim( Combo_ngptppid_Htmltemplate));
         GxWebStd.gx_hidden_field( context, "COMBO_NGPTPPID_Emptyitemtext", StringUtil.RTrim( Combo_ngptppid_Emptyitemtext));
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
         GXEncryptionTmp = "core.negociopj.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV7NegID.ToString());
         return formatLink("core.negociopj.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "core.NegocioPJ" ;
      }

      public override string GetPgmdesc( )
      {
         return "Oportunidade de Negócio" ;
      }

      protected void InitializeNonKey0Y37( )
      {
         A350NegCliID = Guid.Empty;
         AssignAttri("", false, "A350NegCliID", A350NegCliID.ToString());
         A352NegCpjID = Guid.Empty;
         AssignAttri("", false, "A352NegCpjID", A352NegCpjID.ToString());
         A369NegCpjEndSeq = 0;
         AssignAttri("", false, "A369NegCpjEndSeq", StringUtil.LTrimStr( (decimal)(A369NegCpjEndSeq), 4, 0));
         AV47AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
         A356NegCodigo = 0;
         AssignAttri("", false, "A356NegCodigo", StringUtil.LTrimStr( (decimal)(A356NegCodigo), 12, 0));
         A348NegInsDataHora = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A348NegInsDataHora", context.localUtil.TToC( A348NegInsDataHora, 10, 12, 0, 3, "/", ":", " "));
         A346NegInsData = DateTime.MinValue;
         AssignAttri("", false, "A346NegInsData", context.localUtil.Format(A346NegInsData, "99/99/99"));
         A347NegInsHora = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A347NegInsHora", context.localUtil.TToC( A347NegInsHora, 0, 5, 0, 3, "/", ":", " "));
         A349NegInsUsuID = "";
         n349NegInsUsuID = false;
         AssignAttri("", false, "A349NegInsUsuID", A349NegInsUsuID);
         A364NegInsUsuNome = "";
         n364NegInsUsuNome = false;
         AssignAttri("", false, "A364NegInsUsuNome", A364NegInsUsuNome);
         A385NegValorAtualizado = 0;
         AssignAttri("", false, "A385NegValorAtualizado", StringUtil.LTrimStr( A385NegValorAtualizado, 16, 2));
         A380NegValorEstimado = 0;
         AssignAttri("", false, "A380NegValorEstimado", StringUtil.LTrimStr( A380NegValorEstimado, 16, 2));
         A573NegDelDataHora = (DateTime)(DateTime.MinValue);
         n573NegDelDataHora = false;
         AssignAttri("", false, "A573NegDelDataHora", context.localUtil.TToC( A573NegDelDataHora, 10, 12, 0, 3, "/", ":", " "));
         A574NegDelData = (DateTime)(DateTime.MinValue);
         n574NegDelData = false;
         AssignAttri("", false, "A574NegDelData", context.localUtil.TToC( A574NegDelData, 10, 5, 0, 3, "/", ":", " "));
         A575NegDelHora = (DateTime)(DateTime.MinValue);
         n575NegDelHora = false;
         AssignAttri("", false, "A575NegDelHora", context.localUtil.TToC( A575NegDelHora, 0, 5, 0, 3, "/", ":", " "));
         A576NegDelUsuId = "";
         n576NegDelUsuId = false;
         AssignAttri("", false, "A576NegDelUsuId", A576NegDelUsuId);
         A577NegDelUsuNome = "";
         n577NegDelUsuNome = false;
         AssignAttri("", false, "A577NegDelUsuNome", A577NegDelUsuNome);
         A473NegCliMatricula = 0;
         AssignAttri("", false, "A473NegCliMatricula", StringUtil.LTrimStr( (decimal)(A473NegCliMatricula), 12, 0));
         A351NegCliNomeFamiliar = "";
         AssignAttri("", false, "A351NegCliNomeFamiliar", A351NegCliNomeFamiliar);
         A353NegCpjNomFan = "";
         AssignAttri("", false, "A353NegCpjNomFan", A353NegCpjNomFan);
         A354NegCpjRazSocial = "";
         AssignAttri("", false, "A354NegCpjRazSocial", A354NegCpjRazSocial);
         A355NegCpjMatricula = 0;
         AssignAttri("", false, "A355NegCpjMatricula", StringUtil.LTrimStr( (decimal)(A355NegCpjMatricula), 12, 0));
         A357NegPjtID = 0;
         AssignAttri("", false, "A357NegPjtID", StringUtil.LTrimStr( (decimal)(A357NegPjtID), 9, 0));
         A358NegPjtSigla = "";
         AssignAttri("", false, "A358NegPjtSigla", A358NegPjtSigla);
         A359NegPjtNome = "";
         AssignAttri("", false, "A359NegPjtNome", A359NegPjtNome);
         A370NegCpjEndNome = "";
         AssignAttri("", false, "A370NegCpjEndNome", A370NegCpjEndNome);
         A371NegCpjEndEndereco = "";
         AssignAttri("", false, "A371NegCpjEndEndereco", A371NegCpjEndEndereco);
         A372NegCpjEndNumero = "";
         AssignAttri("", false, "A372NegCpjEndNumero", A372NegCpjEndNumero);
         A373NegCpjEndComplem = "";
         n373NegCpjEndComplem = false;
         AssignAttri("", false, "A373NegCpjEndComplem", A373NegCpjEndComplem);
         A374NegCpjEndBairro = "";
         AssignAttri("", false, "A374NegCpjEndBairro", A374NegCpjEndBairro);
         A642NegCpjEndCep = 0;
         AssignAttri("", false, "A642NegCpjEndCep", StringUtil.LTrimStr( (decimal)(A642NegCpjEndCep), 8, 0));
         A643NegCpjEndCepFormat = "";
         AssignAttri("", false, "A643NegCpjEndCepFormat", A643NegCpjEndCepFormat);
         A375NegCpjEndMunID = 0;
         AssignAttri("", false, "A375NegCpjEndMunID", StringUtil.LTrimStr( (decimal)(A375NegCpjEndMunID), 7, 0));
         A376NegCpjEndMunNome = "";
         AssignAttri("", false, "A376NegCpjEndMunNome", A376NegCpjEndMunNome);
         A377NegCpjEndUFID = 0;
         AssignAttri("", false, "A377NegCpjEndUFID", StringUtil.LTrimStr( (decimal)(A377NegCpjEndUFID), 2, 0));
         A378NegCpjEndUFSigla = "";
         AssignAttri("", false, "A378NegCpjEndUFSigla", A378NegCpjEndUFSigla);
         A379NegCpjEndUFNome = "";
         AssignAttri("", false, "A379NegCpjEndUFNome", A379NegCpjEndUFNome);
         A641NegCpjEndCompleto = "";
         AssignAttri("", false, "A641NegCpjEndCompleto", A641NegCpjEndCompleto);
         A360NegAgcID = "";
         n360NegAgcID = false;
         AssignAttri("", false, "A360NegAgcID", A360NegAgcID);
         A361NegAgcNome = "";
         n361NegAgcNome = false;
         AssignAttri("", false, "A361NegAgcNome", A361NegAgcNome);
         A362NegAssunto = "";
         AssignAttri("", false, "A362NegAssunto", A362NegAssunto);
         A363NegDescricao = "";
         AssignAttri("", false, "A363NegDescricao", A363NegDescricao);
         A448NegPgpTotal = 0;
         n448NegPgpTotal = false;
         AssignAttri("", false, "A448NegPgpTotal", StringUtil.LTrimStr( A448NegPgpTotal, 16, 2));
         A454NegUltItem = 0;
         n454NegUltItem = false;
         AssignAttri("", false, "A454NegUltItem", StringUtil.LTrimStr( (decimal)(A454NegUltItem), 8, 0));
         A572NegDel = false;
         AssignAttri("", false, "A572NegDel", A572NegDel);
         O454NegUltItem = A454NegUltItem;
         n454NegUltItem = false;
         AssignAttri("", false, "A454NegUltItem", StringUtil.LTrimStr( (decimal)(A454NegUltItem), 8, 0));
         O448NegPgpTotal = A448NegPgpTotal;
         n448NegPgpTotal = false;
         AssignAttri("", false, "A448NegPgpTotal", StringUtil.LTrimStr( A448NegPgpTotal, 16, 2));
         O572NegDel = A572NegDel;
         AssignAttri("", false, "A572NegDel", A572NegDel);
         Z356NegCodigo = 0;
         Z348NegInsDataHora = (DateTime)(DateTime.MinValue);
         Z346NegInsData = DateTime.MinValue;
         Z347NegInsHora = (DateTime)(DateTime.MinValue);
         Z349NegInsUsuID = "";
         Z364NegInsUsuNome = "";
         Z385NegValorAtualizado = 0;
         Z380NegValorEstimado = 0;
         Z573NegDelDataHora = (DateTime)(DateTime.MinValue);
         Z574NegDelData = (DateTime)(DateTime.MinValue);
         Z575NegDelHora = (DateTime)(DateTime.MinValue);
         Z576NegDelUsuId = "";
         Z577NegDelUsuNome = "";
         Z360NegAgcID = "";
         Z361NegAgcNome = "";
         Z362NegAssunto = "";
         Z454NegUltItem = 0;
         Z572NegDel = false;
         Z350NegCliID = Guid.Empty;
         Z352NegCpjID = Guid.Empty;
         Z369NegCpjEndSeq = 0;
      }

      protected void InitAll0Y37( )
      {
         A345NegID = Guid.NewGuid( );
         AssignAttri("", false, "A345NegID", A345NegID.ToString());
         InitializeNonKey0Y37( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey0Y42( )
      {
         A457NgpInsDataHora = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A457NgpInsDataHora", context.localUtil.TToC( A457NgpInsDataHora, 10, 12, 0, 3, "/", ":", " "));
         A455NgpInsData = DateTime.MinValue;
         AssignAttri("", false, "A455NgpInsData", context.localUtil.Format(A455NgpInsData, "99/99/99"));
         A456NgpInsHora = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A456NgpInsHora", context.localUtil.TToC( A456NgpInsHora, 0, 5, 0, 3, "/", ":", " "));
         A458NgpInsUsuID = "";
         n458NgpInsUsuID = false;
         AssignAttri("", false, "A458NgpInsUsuID", A458NgpInsUsuID);
         A459NgpInsUsuNome = "";
         n459NgpInsUsuNome = false;
         AssignAttri("", false, "A459NgpInsUsuNome", A459NgpInsUsuNome);
         A579NgpDelDataHora = (DateTime)(DateTime.MinValue);
         n579NgpDelDataHora = false;
         AssignAttri("", false, "A579NgpDelDataHora", context.localUtil.TToC( A579NgpDelDataHora, 10, 12, 0, 3, "/", ":", " "));
         A580NgpDelData = (DateTime)(DateTime.MinValue);
         n580NgpDelData = false;
         AssignAttri("", false, "A580NgpDelData", context.localUtil.TToC( A580NgpDelData, 10, 5, 0, 3, "/", ":", " "));
         A581NgpDelHora = (DateTime)(DateTime.MinValue);
         n581NgpDelHora = false;
         AssignAttri("", false, "A581NgpDelHora", context.localUtil.TToC( A581NgpDelHora, 0, 5, 0, 3, "/", ":", " "));
         A582NgpDelUsuId = "";
         n582NgpDelUsuId = false;
         AssignAttri("", false, "A582NgpDelUsuId", A582NgpDelUsuId);
         A583NgpDelUsuNome = "";
         n583NgpDelUsuNome = false;
         AssignAttri("", false, "A583NgpDelUsuNome", A583NgpDelUsuNome);
         A447NgpTotal = 0;
         A478NgpTppID = Guid.Empty;
         A439NgpTppPrdID = Guid.Empty;
         A440NgpTppPrdCodigo = "";
         AssignAttri("", false, "A440NgpTppPrdCodigo", A440NgpTppPrdCodigo);
         A441NgpTppPrdNome = "";
         AssignAttri("", false, "A441NgpTppPrdNome", A441NgpTppPrdNome);
         A442NgpTppPrdTipoID = 0;
         AssignAttri("", false, "A442NgpTppPrdTipoID", StringUtil.LTrimStr( (decimal)(A442NgpTppPrdTipoID), 9, 0));
         A443NgpTppPrdAtivo = false;
         AssignAttri("", false, "A443NgpTppPrdAtivo", A443NgpTppPrdAtivo);
         A444NgpTpp1Preco = 0;
         A453NgpObs = "";
         AssignAttri("", false, "A453NgpObs", A453NgpObs);
         A578NgpDel = false;
         AssignAttri("", false, "A578NgpDel", A578NgpDel);
         A446NgpQtde = 1;
         A445NgpPreco = 0;
         O578NgpDel = A578NgpDel;
         AssignAttri("", false, "A578NgpDel", A578NgpDel);
         O447NgpTotal = A447NgpTotal;
         Z447NgpTotal = 0;
         Z446NgpQtde = 0;
         Z445NgpPreco = 0;
         Z457NgpInsDataHora = (DateTime)(DateTime.MinValue);
         Z455NgpInsData = DateTime.MinValue;
         Z456NgpInsHora = (DateTime)(DateTime.MinValue);
         Z458NgpInsUsuID = "";
         Z459NgpInsUsuNome = "";
         Z579NgpDelDataHora = (DateTime)(DateTime.MinValue);
         Z580NgpDelData = (DateTime)(DateTime.MinValue);
         Z581NgpDelHora = (DateTime)(DateTime.MinValue);
         Z582NgpDelUsuId = "";
         Z583NgpDelUsuNome = "";
         Z453NgpObs = "";
         Z578NgpDel = false;
         Z439NgpTppPrdID = Guid.Empty;
         Z478NgpTppID = Guid.Empty;
      }

      protected void InitAll0Y42( )
      {
         A435NgpItem = 0;
         InitializeNonKey0Y42( ) ;
      }

      protected void StandaloneModalInsert0Y42( )
      {
         A454NegUltItem = i454NegUltItem;
         n454NegUltItem = false;
         AssignAttri("", false, "A454NegUltItem", StringUtil.LTrimStr( (decimal)(A454NegUltItem), 8, 0));
         A446NgpQtde = i446NgpQtde;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2023821395285", true, true);
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
         context.AddJavascriptSource("core/negociopj.js", "?2023821395287", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("CKEditor/ckeditor/ckeditor.js", "", false, true);
         context.AddJavascriptSource("CKEditor/CKEditorRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_level_properties42( )
      {
         edtNgpItem_Enabled = defedtNgpItem_Enabled;
         AssignProp("", false, edtNgpItem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNgpItem_Enabled), 5, 0), !bGXsfl_73_Refreshing);
      }

      protected void StartGridControl73( )
      {
         Gridlevel_itemContainer.AddObjectProperty("GridName", "Gridlevel_item");
         Gridlevel_itemContainer.AddObjectProperty("Header", subGridlevel_item_Header);
         Gridlevel_itemContainer.AddObjectProperty("Class", "WorkWith");
         Gridlevel_itemContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridlevel_itemContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridlevel_itemContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_item_Backcolorstyle), 1, 0, ".", "")));
         Gridlevel_itemContainer.AddObjectProperty("CmpContext", "");
         Gridlevel_itemContainer.AddObjectProperty("InMasterPage", "false");
         Gridlevel_itemColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_itemColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A435NgpItem), 10, 0, ".", ""))));
         Gridlevel_itemColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNgpItem_Enabled), 5, 0, ".", "")));
         Gridlevel_itemContainer.AddColumnProperties(Gridlevel_itemColumn);
         Gridlevel_itemColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_itemColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A478NgpTppID.ToString()));
         Gridlevel_itemColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNgpTppID_Enabled), 5, 0, ".", "")));
         Gridlevel_itemContainer.AddColumnProperties(Gridlevel_itemColumn);
         Gridlevel_itemColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_itemColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A439NgpTppPrdID.ToString()));
         Gridlevel_itemColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(dynNgpTppPrdID.Enabled), 5, 0, ".", "")));
         Gridlevel_itemContainer.AddColumnProperties(Gridlevel_itemColumn);
         Gridlevel_itemColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_itemColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A444NgpTpp1Preco, 23, 2, ".", ""))));
         Gridlevel_itemColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNgpTpp1Preco_Enabled), 5, 0, ".", "")));
         Gridlevel_itemContainer.AddColumnProperties(Gridlevel_itemColumn);
         Gridlevel_itemColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_itemColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A445NgpPreco, 23, 2, ".", ""))));
         Gridlevel_itemColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNgpPreco_Enabled), 5, 0, ".", "")));
         Gridlevel_itemContainer.AddColumnProperties(Gridlevel_itemColumn);
         Gridlevel_itemColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_itemColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A446NgpQtde), 8, 0, ".", ""))));
         Gridlevel_itemColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNgpQtde_Enabled), 5, 0, ".", "")));
         Gridlevel_itemContainer.AddColumnProperties(Gridlevel_itemColumn);
         Gridlevel_itemColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_itemColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A447NgpTotal, 23, 2, ".", ""))));
         Gridlevel_itemColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtNgpTotal_Enabled), 5, 0, ".", "")));
         Gridlevel_itemContainer.AddColumnProperties(Gridlevel_itemColumn);
         Gridlevel_itemContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_item_Selectedindex), 4, 0, ".", "")));
         Gridlevel_itemContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_item_Allowselection), 1, 0, ".", "")));
         Gridlevel_itemContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_item_Selectioncolor), 9, 0, ".", "")));
         Gridlevel_itemContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_item_Allowhovering), 1, 0, ".", "")));
         Gridlevel_itemContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_item_Hoveringcolor), 9, 0, ".", "")));
         Gridlevel_itemContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_item_Allowcollapsing), 1, 0, ".", "")));
         Gridlevel_itemContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_item_Collapsed), 1, 0, ".", "")));
      }

      protected void init_default_properties( )
      {
         edtNegCodigo_Internalname = "NEGCODIGO";
         lblTextblocknegcliid_Internalname = "TEXTBLOCKNEGCLIID";
         Combo_negcliid_Internalname = "COMBO_NEGCLIID";
         edtNegCliID_Internalname = "NEGCLIID";
         divTablesplittednegcliid_Internalname = "TABLESPLITTEDNEGCLIID";
         lblTextblocknegcpjid_Internalname = "TEXTBLOCKNEGCPJID";
         Combo_negcpjid_Internalname = "COMBO_NEGCPJID";
         edtNegCpjID_Internalname = "NEGCPJID";
         divTablesplittednegcpjid_Internalname = "TABLESPLITTEDNEGCPJID";
         lblTextblocknegcpjendseq_Internalname = "TEXTBLOCKNEGCPJENDSEQ";
         Combo_negcpjendseq_Internalname = "COMBO_NEGCPJENDSEQ";
         edtNegCpjEndSeq_Internalname = "NEGCPJENDSEQ";
         divTablesplittednegcpjendseq_Internalname = "TABLESPLITTEDNEGCPJENDSEQ";
         edtNegAssunto_Internalname = "NEGASSUNTO";
         edtNegValorEstimado_Internalname = "NEGVALORESTIMADO";
         Negdescricao_Internalname = "NEGDESCRICAO";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         edtNgpItem_Internalname = "NGPITEM";
         edtNgpTppID_Internalname = "NGPTPPID";
         dynNgpTppPrdID_Internalname = "NGPTPPPRDID";
         edtNgpTpp1Preco_Internalname = "NGPTPP1PRECO";
         edtNgpPreco_Internalname = "NGPPRECO";
         edtNgpQtde_Internalname = "NGPQTDE";
         edtNgpTotal_Internalname = "NGPTOTAL";
         divTableleaflevel_item_Internalname = "TABLELEAFLEVEL_ITEM";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         divTablemain_Internalname = "TABLEMAIN";
         edtavCombonegcliid_Internalname = "vCOMBONEGCLIID";
         divSectionattribute_negcliid_Internalname = "SECTIONATTRIBUTE_NEGCLIID";
         edtavCombonegcpjid_Internalname = "vCOMBONEGCPJID";
         divSectionattribute_negcpjid_Internalname = "SECTIONATTRIBUTE_NEGCPJID";
         edtavCombonegcpjendseq_Internalname = "vCOMBONEGCPJENDSEQ";
         divSectionattribute_negcpjendseq_Internalname = "SECTIONATTRIBUTE_NEGCPJENDSEQ";
         Combo_ngptppid_Internalname = "COMBO_NGPTPPID";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subGridlevel_item_Internalname = "GRIDLEVEL_ITEM";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridlevel_item_Allowcollapsing = 0;
         subGridlevel_item_Allowselection = 0;
         subGridlevel_item_Header = "";
         Combo_ngptppid_Enabled = Convert.ToBoolean( -1);
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Oportunidade de Negócio";
         edtNgpTotal_Jsonclick = "";
         edtNgpQtde_Jsonclick = "";
         edtNgpPreco_Jsonclick = "";
         edtNgpTpp1Preco_Jsonclick = "";
         dynNgpTppPrdID_Jsonclick = "";
         edtNgpTppID_Jsonclick = "";
         edtNgpItem_Jsonclick = "";
         subGridlevel_item_Class = "WorkWith";
         subGridlevel_item_Backcolorstyle = 0;
         Combo_negcpjid_Datalistprocparametersprefix = "";
         Combo_negcpjendseq_Datalistprocparametersprefix = "";
         Combo_negcliid_Htmltemplate = "";
         Combo_negcpjid_Htmltemplate = "";
         Combo_negcpjendseq_Htmltemplate = "";
         Combo_ngptppid_Titlecontrolidtoreplace = "";
         Combo_ngptppid_Htmltemplate = "";
         edtNgpTotal_Enabled = 0;
         edtNgpQtde_Enabled = 1;
         edtNgpPreco_Enabled = 1;
         edtNgpTpp1Preco_Enabled = 0;
         dynNgpTppPrdID.Enabled = 1;
         edtNgpTppID_Enabled = 1;
         edtNgpItem_Enabled = 0;
         Combo_ngptppid_Emptyitemtext = " ";
         Combo_ngptppid_Isgriditem = Convert.ToBoolean( -1);
         Combo_ngptppid_Cls = "ExtendedCombo ExtendedComboTitleAndSubtitle";
         Combo_ngptppid_Caption = "";
         edtavCombonegcpjendseq_Jsonclick = "";
         edtavCombonegcpjendseq_Enabled = 0;
         edtavCombonegcpjendseq_Visible = 1;
         edtavCombonegcpjid_Jsonclick = "";
         edtavCombonegcpjid_Enabled = 0;
         edtavCombonegcpjid_Visible = 1;
         edtavCombonegcliid_Jsonclick = "";
         edtavCombonegcliid_Enabled = 0;
         edtavCombonegcliid_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         Negdescricao_Captionposition = "None";
         Negdescricao_Captionstyle = "";
         Negdescricao_Captionclass = "col-sm-3 AttributeLabel";
         Negdescricao_Color = (int)(0xD3D3D3);
         Negdescricao_Toolbarcancollapse = Convert.ToBoolean( -1);
         Negdescricao_Toolbar = "Default";
         Negdescricao_Skin = "silver";
         Negdescricao_Height = "400";
         Negdescricao_Width = "100%";
         Negdescricao_Enabled = Convert.ToBoolean( 1);
         edtNegValorEstimado_Jsonclick = "";
         edtNegValorEstimado_Enabled = 0;
         edtNegAssunto_Jsonclick = "";
         edtNegAssunto_Enabled = 1;
         edtNegCpjEndSeq_Jsonclick = "";
         edtNegCpjEndSeq_Enabled = 1;
         edtNegCpjEndSeq_Visible = 1;
         Combo_negcpjendseq_Emptyitemtext = "";
         Combo_negcpjendseq_Includeaddnewoption = Convert.ToBoolean( -1);
         Combo_negcpjendseq_Datalistproc = "core.NegocioPJLoadDVCombo";
         Combo_negcpjendseq_Cls = "ExtendedCombo AttributeFL ExtendedComboTitleAndSubtitle";
         Combo_negcpjendseq_Caption = "";
         Combo_negcpjendseq_Enabled = Convert.ToBoolean( -1);
         edtNegCpjID_Jsonclick = "";
         edtNegCpjID_Enabled = 1;
         edtNegCpjID_Visible = 1;
         Combo_negcpjid_Emptyitemtext = "";
         Combo_negcpjid_Includeaddnewoption = Convert.ToBoolean( -1);
         Combo_negcpjid_Datalistproc = "core.NegocioPJLoadDVCombo";
         Combo_negcpjid_Cls = "ExtendedCombo AttributeFL ExtendedComboTitleAndSubtitle";
         Combo_negcpjid_Caption = "";
         Combo_negcpjid_Enabled = Convert.ToBoolean( -1);
         edtNegCliID_Jsonclick = "";
         edtNegCliID_Enabled = 1;
         edtNegCliID_Visible = 1;
         Combo_negcliid_Emptyitemtext = "";
         Combo_negcliid_Includeaddnewoption = Convert.ToBoolean( -1);
         Combo_negcliid_Cls = "ExtendedCombo AttributeFL ExtendedComboTitleAndSubtitle";
         Combo_negcliid_Caption = "";
         Combo_negcliid_Enabled = Convert.ToBoolean( -1);
         edtNegCodigo_Jsonclick = "";
         edtNegCodigo_Enabled = 0;
         Dvpanel_tableattributes_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Iconposition = "Right";
         Dvpanel_tableattributes_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Title = "Informe os dados abaixo:";
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

      protected void GXDLANGPTPPPRDID0Y42( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLANGPTPPPRDID_data0Y42( ) ;
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

      protected void GXANGPTPPPRDID_html0Y42( )
      {
         Guid gxdynajaxvalue;
         GXDLANGPTPPPRDID_data0Y42( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynNgpTppPrdID.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = StringUtil.StrToGuid( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)));
            dynNgpTppPrdID.addItem(gxdynajaxvalue.ToString(), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLANGPTPPPRDID_data0Y42( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(Guid.Empty.ToString());
         gxdynajaxctrldescr.Add("");
         /* Using cursor T000Y46 */
         pr_default.execute(42, new Object[] {Gx_mode});
         while ( (pr_default.getStatus(42) != 101) )
         {
            gxdynajaxctrlcodr.Add(T000Y46_A220PrdID[0].ToString());
            gxdynajaxctrldescr.Add(T000Y46_A222PrdNome[0]);
            pr_default.readNext(42);
         }
         pr_default.close(42);
      }

      protected void GX15ASANEGCODIGO0Y37( string Gx_mode )
      {
         if ( IsIns( )  )
         {
            GXt_int4 = (int)(A356NegCodigo);
            new GeneXus.Programs.core.serializar(context ).execute(  "NegCodigo",  1, out  GXt_int4) ;
            A356NegCodigo = GXt_int4;
            AssignAttri("", false, "A356NegCodigo", StringUtil.LTrimStr( (decimal)(A356NegCodigo), 12, 0));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A356NegCodigo), 12, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_37_0Y37( GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV47AuditingObject ,
                                 Guid A345NegID ,
                                 string Gx_mode )
      {
         new GeneXus.Programs.core.loadauditnegociopj(context ).execute(  "Y", ref  AV47AuditingObject,  A345NegID,  Gx_mode) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.EncodeString( AV47AuditingObject.ToXml(false, true, "", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_38_0Y37( GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV47AuditingObject ,
                                 Guid A345NegID ,
                                 string Gx_mode )
      {
         new GeneXus.Programs.core.loadauditnegociopj(context ).execute(  "Y", ref  AV47AuditingObject,  A345NegID,  Gx_mode) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.EncodeString( AV47AuditingObject.ToXml(false, true, "", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_39_0Y37( string Gx_mode ,
                                 GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV47AuditingObject ,
                                 Guid A345NegID )
      {
         if ( IsIns( )  )
         {
            new GeneXus.Programs.core.loadauditnegociopj(context ).execute(  "N", ref  AV47AuditingObject,  A345NegID,  Gx_mode) ;
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.EncodeString( AV47AuditingObject.ToXml(false, true, "", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_40_0Y37( string Gx_mode ,
                                 GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV47AuditingObject ,
                                 Guid A345NegID )
      {
         if ( IsUpd( )  )
         {
            new GeneXus.Programs.core.loadauditnegociopj(context ).execute(  "N", ref  AV47AuditingObject,  A345NegID,  Gx_mode) ;
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.EncodeString( AV47AuditingObject.ToXml(false, true, "", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void gxnrGridlevel_item_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_7342( ) ;
         while ( nGXsfl_73_idx <= nRC_GXsfl_73 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal0Y42( ) ;
            standaloneModal0Y42( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow0Y42( ) ;
            nGXsfl_73_idx = (int)(nGXsfl_73_idx+1);
            sGXsfl_73_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_73_idx), 4, 0), 4, "0");
            SubsflControlProps_7342( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridlevel_itemContainer)) ;
         /* End function gxnrGridlevel_item_newrow */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "NGPTPPPRDID_" + sGXsfl_73_idx;
         dynNgpTppPrdID.Name = GXCCtl;
         dynNgpTppPrdID.WebTags = "";
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

      public void Valid_Negcodigo( )
      {
         A439NgpTppPrdID = StringUtil.StrToGuid( dynNgpTppPrdID.CurrentValue);
         /* Using cursor T000Y47 */
         pr_default.execute(43, new Object[] {A356NegCodigo, A345NegID});
         if ( (pr_default.getStatus(43) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Código da Negociação"}), 1, "NEGCODIGO");
            AnyError = 1;
            GX_FocusControl = edtNegCodigo_Internalname;
         }
         pr_default.close(43);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Negcliid( )
      {
         A439NgpTppPrdID = StringUtil.StrToGuid( dynNgpTppPrdID.CurrentValue);
         /* Using cursor T000Y27 */
         pr_default.execute(23, new Object[] {A350NegCliID});
         if ( (pr_default.getStatus(23) == 101) )
         {
            GX_msglist.addItem("Não existe 'Cliente PJ -> Negocio PJ'.", "ForeignKeyNotFound", 1, "NEGCLIID");
            AnyError = 1;
            GX_FocusControl = edtNegCliID_Internalname;
         }
         A473NegCliMatricula = T000Y27_A473NegCliMatricula[0];
         A351NegCliNomeFamiliar = T000Y27_A351NegCliNomeFamiliar[0];
         pr_default.close(23);
         if ( (Guid.Empty==A350NegCliID) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Cliente ID", "", "", "", "", "", "", "", ""), 1, "NEGCLIID");
            AnyError = 1;
            GX_FocusControl = edtNegCliID_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A473NegCliMatricula", StringUtil.LTrim( StringUtil.NToC( (decimal)(A473NegCliMatricula), 12, 0, ".", "")));
         AssignAttri("", false, "A351NegCliNomeFamiliar", A351NegCliNomeFamiliar);
      }

      public void Valid_Negcpjid( )
      {
         A439NgpTppPrdID = StringUtil.StrToGuid( dynNgpTppPrdID.CurrentValue);
         /* Using cursor T000Y28 */
         pr_default.execute(24, new Object[] {A350NegCliID, A352NegCpjID});
         if ( (pr_default.getStatus(24) == 101) )
         {
            GX_msglist.addItem("Não existe 'Cliente PJ -> Negocio PJ'.", "ForeignKeyNotFound", 1, "NEGCPJID");
            AnyError = 1;
            GX_FocusControl = edtNegCliID_Internalname;
         }
         A353NegCpjNomFan = T000Y28_A353NegCpjNomFan[0];
         A354NegCpjRazSocial = T000Y28_A354NegCpjRazSocial[0];
         A355NegCpjMatricula = T000Y28_A355NegCpjMatricula[0];
         A357NegPjtID = T000Y28_A357NegPjtID[0];
         pr_default.close(24);
         /* Using cursor T000Y29 */
         pr_default.execute(25, new Object[] {A357NegPjtID});
         if ( (pr_default.getStatus(25) == 101) )
         {
            GX_msglist.addItem("Não existe ''.", "ForeignKeyNotFound", 1, "NEGPJTID");
            AnyError = 1;
         }
         A358NegPjtSigla = T000Y29_A358NegPjtSigla[0];
         A359NegPjtNome = T000Y29_A359NegPjtNome[0];
         pr_default.close(25);
         if ( (Guid.Empty==A352NegCpjID) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "ID da Unidade", "", "", "", "", "", "", "", ""), 1, "NEGCPJID");
            AnyError = 1;
            GX_FocusControl = edtNegCpjID_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A353NegCpjNomFan", A353NegCpjNomFan);
         AssignAttri("", false, "A354NegCpjRazSocial", A354NegCpjRazSocial);
         AssignAttri("", false, "A355NegCpjMatricula", StringUtil.LTrim( StringUtil.NToC( (decimal)(A355NegCpjMatricula), 12, 0, ".", "")));
         AssignAttri("", false, "A357NegPjtID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A357NegPjtID), 9, 0, ".", "")));
         AssignAttri("", false, "A358NegPjtSigla", A358NegPjtSigla);
         AssignAttri("", false, "A359NegPjtNome", A359NegPjtNome);
      }

      public void Valid_Negcpjendseq( )
      {
         n373NegCpjEndComplem = false;
         A439NgpTppPrdID = StringUtil.StrToGuid( dynNgpTppPrdID.CurrentValue);
         /* Using cursor T000Y30 */
         pr_default.execute(26, new Object[] {A350NegCliID, A352NegCpjID, A369NegCpjEndSeq});
         if ( (pr_default.getStatus(26) == 101) )
         {
            GX_msglist.addItem("Não existe 'Cliente PJ -> Negocio PJ'.", "ForeignKeyNotFound", 1, "NEGCPJENDSEQ");
            AnyError = 1;
            GX_FocusControl = edtNegCliID_Internalname;
         }
         A370NegCpjEndNome = T000Y30_A370NegCpjEndNome[0];
         A371NegCpjEndEndereco = T000Y30_A371NegCpjEndEndereco[0];
         A372NegCpjEndNumero = T000Y30_A372NegCpjEndNumero[0];
         A373NegCpjEndComplem = T000Y30_A373NegCpjEndComplem[0];
         n373NegCpjEndComplem = T000Y30_n373NegCpjEndComplem[0];
         A374NegCpjEndBairro = T000Y30_A374NegCpjEndBairro[0];
         A642NegCpjEndCep = T000Y30_A642NegCpjEndCep[0];
         A643NegCpjEndCepFormat = T000Y30_A643NegCpjEndCepFormat[0];
         A375NegCpjEndMunID = T000Y30_A375NegCpjEndMunID[0];
         A376NegCpjEndMunNome = T000Y30_A376NegCpjEndMunNome[0];
         A377NegCpjEndUFID = T000Y30_A377NegCpjEndUFID[0];
         A378NegCpjEndUFSigla = T000Y30_A378NegCpjEndUFSigla[0];
         A379NegCpjEndUFNome = T000Y30_A379NegCpjEndUFNome[0];
         pr_default.close(26);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A372NegCpjEndNumero))) && String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A373NegCpjEndComplem))) )
         {
            A641NegCpjEndCompleto = StringUtil.Trim( A371NegCpjEndEndereco) + " - " + StringUtil.Trim( A374NegCpjEndBairro) + " - " + StringUtil.Trim( A643NegCpjEndCepFormat) + " - " + StringUtil.Trim( A376NegCpjEndMunNome) + " - " + StringUtil.Trim( A378NegCpjEndUFSigla);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A372NegCpjEndNumero))) && String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A373NegCpjEndComplem))) )
            {
               A641NegCpjEndCompleto = StringUtil.Trim( A371NegCpjEndEndereco) + ", " + StringUtil.Trim( A372NegCpjEndNumero) + " - " + StringUtil.Trim( A374NegCpjEndBairro) + " - " + StringUtil.Trim( A643NegCpjEndCepFormat) + " - " + StringUtil.Trim( A376NegCpjEndMunNome) + " - " + StringUtil.Trim( A378NegCpjEndUFSigla);
            }
            else
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A372NegCpjEndNumero))) && ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A373NegCpjEndComplem))) )
               {
                  A641NegCpjEndCompleto = StringUtil.Trim( A371NegCpjEndEndereco) + ", " + StringUtil.Trim( A372NegCpjEndNumero) + " - " + StringUtil.Trim( A374NegCpjEndBairro) + " - " + StringUtil.Trim( A643NegCpjEndCepFormat) + " - " + StringUtil.Trim( A376NegCpjEndMunNome) + " - " + StringUtil.Trim( A378NegCpjEndUFSigla);
               }
               else
               {
                  A641NegCpjEndCompleto = StringUtil.Trim( A371NegCpjEndEndereco) + ", " + StringUtil.Trim( A372NegCpjEndNumero) + " " + StringUtil.Trim( A373NegCpjEndComplem) + " - " + StringUtil.Trim( A374NegCpjEndBairro) + " - " + StringUtil.Trim( A643NegCpjEndCepFormat) + " - " + StringUtil.Trim( A376NegCpjEndMunNome) + " - " + StringUtil.Trim( A378NegCpjEndUFSigla);
               }
            }
         }
         if ( (0==A369NegCpjEndSeq) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Sequência do Endereço", "", "", "", "", "", "", "", ""), 1, "NEGCPJENDSEQ");
            AnyError = 1;
            GX_FocusControl = edtNegCpjEndSeq_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A370NegCpjEndNome", A370NegCpjEndNome);
         AssignAttri("", false, "A371NegCpjEndEndereco", A371NegCpjEndEndereco);
         AssignAttri("", false, "A372NegCpjEndNumero", A372NegCpjEndNumero);
         AssignAttri("", false, "A373NegCpjEndComplem", A373NegCpjEndComplem);
         AssignAttri("", false, "A374NegCpjEndBairro", A374NegCpjEndBairro);
         AssignAttri("", false, "A642NegCpjEndCep", StringUtil.LTrim( StringUtil.NToC( (decimal)(A642NegCpjEndCep), 8, 0, ".", "")));
         AssignAttri("", false, "A643NegCpjEndCepFormat", A643NegCpjEndCepFormat);
         AssignAttri("", false, "A375NegCpjEndMunID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A375NegCpjEndMunID), 7, 0, ".", "")));
         AssignAttri("", false, "A376NegCpjEndMunNome", A376NegCpjEndMunNome);
         AssignAttri("", false, "A377NegCpjEndUFID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A377NegCpjEndUFID), 2, 0, ".", "")));
         AssignAttri("", false, "A378NegCpjEndUFSigla", A378NegCpjEndUFSigla);
         AssignAttri("", false, "A379NegCpjEndUFNome", A379NegCpjEndUFNome);
         AssignAttri("", false, "A641NegCpjEndCompleto", A641NegCpjEndCompleto);
      }

      public void Valid_Ngptppprdid( )
      {
         A439NgpTppPrdID = StringUtil.StrToGuid( dynNgpTppPrdID.CurrentValue);
         /* Using cursor T000Y48 */
         pr_default.execute(44, new Object[] {A439NgpTppPrdID});
         if ( (pr_default.getStatus(44) == 101) )
         {
            GX_msglist.addItem("Não existe 'Produto da Tabela de Preço'.", "ForeignKeyNotFound", 1, "NGPTPPPRDID");
            AnyError = 1;
            GX_FocusControl = dynNgpTppPrdID_Internalname;
         }
         A440NgpTppPrdCodigo = T000Y48_A440NgpTppPrdCodigo[0];
         A441NgpTppPrdNome = T000Y48_A441NgpTppPrdNome[0];
         A443NgpTppPrdAtivo = T000Y48_A443NgpTppPrdAtivo[0];
         A442NgpTppPrdTipoID = T000Y48_A442NgpTppPrdTipoID[0];
         pr_default.close(44);
         /* Using cursor T000Y49 */
         pr_default.execute(45, new Object[] {A478NgpTppID, A439NgpTppPrdID});
         if ( (pr_default.getStatus(45) == 101) )
         {
            GX_msglist.addItem("Não existe 'Produto da Tabela de Preço'.", "ForeignKeyNotFound", 1, "NGPTPPPRDID");
            AnyError = 1;
            GX_FocusControl = edtNgpTppID_Internalname;
         }
         A444NgpTpp1Preco = T000Y49_A444NgpTpp1Preco[0];
         pr_default.close(45);
         if ( IsIns( )  && (Convert.ToDecimal(0)==A445NgpPreco) && ( Gx_BScreen == 0 ) )
         {
            A445NgpPreco = A444NgpTpp1Preco;
         }
         if ( (Guid.Empty==A439NgpTppPrdID) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "ID do Produto", "", "", "", "", "", "", "", ""), 1, "NGPTPPPRDID");
            AnyError = 1;
            GX_FocusControl = dynNgpTppPrdID_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A440NgpTppPrdCodigo", A440NgpTppPrdCodigo);
         AssignAttri("", false, "A441NgpTppPrdNome", A441NgpTppPrdNome);
         AssignAttri("", false, "A443NgpTppPrdAtivo", A443NgpTppPrdAtivo);
         AssignAttri("", false, "A442NgpTppPrdTipoID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A442NgpTppPrdTipoID), 9, 0, ".", "")));
         AssignAttri("", false, "A444NgpTpp1Preco", StringUtil.LTrim( StringUtil.NToC( A444NgpTpp1Preco, 16, 2, ".", "")));
         AssignAttri("", false, "A445NgpPreco", StringUtil.LTrim( StringUtil.NToC( A445NgpPreco, 16, 2, ".", "")));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7NegID',fld:'vNEGID',pic:'',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7NegID',fld:'vNEGID',pic:'',hsh:true},{av:'A360NegAgcID',fld:'NEGAGCID',pic:''},{av:'A361NegAgcNome',fld:'NEGAGCNOME',pic:'@!'},{av:'A572NegDel',fld:'NEGDEL',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E150Y2',iparms:[{av:'AV47AuditingObject',fld:'vAUDITINGOBJECT',pic:''},{av:'AV49Pgmname',fld:'vPGMNAME',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("COMBO_NEGCPJENDSEQ.ONOPTIONCLICKED","{handler:'E140Y2',iparms:[{av:'Combo_negcpjendseq_Selectedvalue_get',ctrl:'COMBO_NEGCPJENDSEQ',prop:'SelectedValue_get'},{av:'A350NegCliID',fld:'NEGCLIID',pic:''},{av:'A352NegCpjID',fld:'NEGCPJID',pic:''},{av:'A369NegCpjEndSeq',fld:'NEGCPJENDSEQ',pic:'ZZZ9'}]");
         setEventMetadata("COMBO_NEGCPJENDSEQ.ONOPTIONCLICKED",",oparms:[{av:'AV18ComboSelectedValue',fld:'vCOMBOSELECTEDVALUE',pic:''},{av:'Combo_negcpjendseq_Selectedvalue_set',ctrl:'COMBO_NEGCPJENDSEQ',prop:'SelectedValue_set'},{av:'Combo_negcpjendseq_Selectedtext_set',ctrl:'COMBO_NEGCPJENDSEQ',prop:'SelectedText_set'},{av:'AV44ComboNegCpjEndSeq',fld:'vCOMBONEGCPJENDSEQ',pic:'ZZZ9'}]}");
         setEventMetadata("COMBO_NEGCPJID.ONOPTIONCLICKED","{handler:'E130Y2',iparms:[{av:'A352NegCpjID',fld:'NEGCPJID',pic:''},{av:'Combo_negcpjid_Selectedvalue_get',ctrl:'COMBO_NEGCPJID',prop:'SelectedValue_get'},{av:'A350NegCliID',fld:'NEGCLIID',pic:''},{av:'AV42ComboNegCpjID',fld:'vCOMBONEGCPJID',pic:''}]");
         setEventMetadata("COMBO_NEGCPJID.ONOPTIONCLICKED",",oparms:[{av:'AV18ComboSelectedValue',fld:'vCOMBOSELECTEDVALUE',pic:''},{av:'Combo_negcpjid_Selectedvalue_set',ctrl:'COMBO_NEGCPJID',prop:'SelectedValue_set'},{av:'Combo_negcpjid_Selectedtext_set',ctrl:'COMBO_NEGCPJID',prop:'SelectedText_set'},{av:'AV42ComboNegCpjID',fld:'vCOMBONEGCPJID',pic:''},{av:'AV44ComboNegCpjEndSeq',fld:'vCOMBONEGCPJENDSEQ',pic:'ZZZ9'},{av:'Combo_negcpjendseq_Selectedvalue_set',ctrl:'COMBO_NEGCPJENDSEQ',prop:'SelectedValue_set'},{av:'Combo_negcpjendseq_Selectedtext_set',ctrl:'COMBO_NEGCPJENDSEQ',prop:'SelectedText_set'}]}");
         setEventMetadata("COMBO_NEGCLIID.ONOPTIONCLICKED","{handler:'E120Y2',iparms:[{av:'A350NegCliID',fld:'NEGCLIID',pic:''},{av:'Combo_negcliid_Selectedvalue_get',ctrl:'COMBO_NEGCLIID',prop:'SelectedValue_get'},{av:'AV7NegID',fld:'vNEGID',pic:'',hsh:true},{av:'A352NegCpjID',fld:'NEGCPJID',pic:''},{av:'AV41ComboNegCliID',fld:'vCOMBONEGCLIID',pic:''}]");
         setEventMetadata("COMBO_NEGCLIID.ONOPTIONCLICKED",",oparms:[{av:'Combo_negcliid_Selectedvalue_set',ctrl:'COMBO_NEGCLIID',prop:'SelectedValue_set'},{av:'AV20Combo_DataJson',fld:'vCOMBO_DATAJSON',pic:''},{av:'AV19ComboSelectedText',fld:'vCOMBOSELECTEDTEXT',pic:''},{av:'AV18ComboSelectedValue',fld:'vCOMBOSELECTEDVALUE',pic:''},{av:'AV16NegCliID_Data',fld:'vNEGCLIID_DATA',pic:''},{av:'AV41ComboNegCliID',fld:'vCOMBONEGCLIID',pic:''},{av:'AV42ComboNegCpjID',fld:'vCOMBONEGCPJID',pic:''},{av:'Combo_negcpjid_Selectedvalue_set',ctrl:'COMBO_NEGCPJID',prop:'SelectedValue_set'},{av:'Combo_negcpjid_Selectedtext_set',ctrl:'COMBO_NEGCPJID',prop:'SelectedText_set'}]}");
         setEventMetadata("VALID_NEGCODIGO","{handler:'Valid_Negcodigo',iparms:[{av:'A356NegCodigo',fld:'NEGCODIGO',pic:'ZZZZZZZZZZZ9'},{av:'A345NegID',fld:'NEGID',pic:''},{av:'dynNgpTppPrdID'},{av:'A439NgpTppPrdID',fld:'NGPTPPPRDID',pic:''}]");
         setEventMetadata("VALID_NEGCODIGO",",oparms:[]}");
         setEventMetadata("VALID_NEGCLIID","{handler:'Valid_Negcliid',iparms:[{av:'A350NegCliID',fld:'NEGCLIID',pic:''},{av:'dynNgpTppPrdID'},{av:'A439NgpTppPrdID',fld:'NGPTPPPRDID',pic:''},{av:'A473NegCliMatricula',fld:'NEGCLIMATRICULA',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'A351NegCliNomeFamiliar',fld:'NEGCLINOMEFAMILIAR',pic:'@!'}]");
         setEventMetadata("VALID_NEGCLIID",",oparms:[{av:'A473NegCliMatricula',fld:'NEGCLIMATRICULA',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'A351NegCliNomeFamiliar',fld:'NEGCLINOMEFAMILIAR',pic:'@!'}]}");
         setEventMetadata("VALID_NEGCPJID","{handler:'Valid_Negcpjid',iparms:[{av:'A350NegCliID',fld:'NEGCLIID',pic:''},{av:'A352NegCpjID',fld:'NEGCPJID',pic:''},{av:'A357NegPjtID',fld:'NEGPJTID',pic:'ZZZ,ZZZ,ZZ9'},{av:'dynNgpTppPrdID'},{av:'A439NgpTppPrdID',fld:'NGPTPPPRDID',pic:''},{av:'A353NegCpjNomFan',fld:'NEGCPJNOMFAN',pic:'@!'},{av:'A354NegCpjRazSocial',fld:'NEGCPJRAZSOCIAL',pic:'@!'},{av:'A355NegCpjMatricula',fld:'NEGCPJMATRICULA',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'A358NegPjtSigla',fld:'NEGPJTSIGLA',pic:''},{av:'A359NegPjtNome',fld:'NEGPJTNOME',pic:'@!'}]");
         setEventMetadata("VALID_NEGCPJID",",oparms:[{av:'A353NegCpjNomFan',fld:'NEGCPJNOMFAN',pic:'@!'},{av:'A354NegCpjRazSocial',fld:'NEGCPJRAZSOCIAL',pic:'@!'},{av:'A355NegCpjMatricula',fld:'NEGCPJMATRICULA',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'A357NegPjtID',fld:'NEGPJTID',pic:'ZZZ,ZZZ,ZZ9'},{av:'A358NegPjtSigla',fld:'NEGPJTSIGLA',pic:''},{av:'A359NegPjtNome',fld:'NEGPJTNOME',pic:'@!'}]}");
         setEventMetadata("VALID_NEGCPJENDSEQ","{handler:'Valid_Negcpjendseq',iparms:[{av:'A350NegCliID',fld:'NEGCLIID',pic:''},{av:'A352NegCpjID',fld:'NEGCPJID',pic:''},{av:'A369NegCpjEndSeq',fld:'NEGCPJENDSEQ',pic:'ZZZ9'},{av:'A371NegCpjEndEndereco',fld:'NEGCPJENDENDERECO',pic:''},{av:'A374NegCpjEndBairro',fld:'NEGCPJENDBAIRRO',pic:''},{av:'A643NegCpjEndCepFormat',fld:'NEGCPJENDCEPFORMAT',pic:''},{av:'A376NegCpjEndMunNome',fld:'NEGCPJENDMUNNOME',pic:'@!'},{av:'A378NegCpjEndUFSigla',fld:'NEGCPJENDUFSIGLA',pic:''},{av:'A372NegCpjEndNumero',fld:'NEGCPJENDNUMERO',pic:''},{av:'A373NegCpjEndComplem',fld:'NEGCPJENDCOMPLEM',pic:''},{av:'dynNgpTppPrdID'},{av:'A439NgpTppPrdID',fld:'NGPTPPPRDID',pic:''},{av:'A370NegCpjEndNome',fld:'NEGCPJENDNOME',pic:'@!'},{av:'A642NegCpjEndCep',fld:'NEGCPJENDCEP',pic:'ZZZZZZZ9'},{av:'A375NegCpjEndMunID',fld:'NEGCPJENDMUNID',pic:'ZZZZZZ9'},{av:'A377NegCpjEndUFID',fld:'NEGCPJENDUFID',pic:'Z9'},{av:'A379NegCpjEndUFNome',fld:'NEGCPJENDUFNOME',pic:'@!'},{av:'A641NegCpjEndCompleto',fld:'NEGCPJENDCOMPLETO',pic:''}]");
         setEventMetadata("VALID_NEGCPJENDSEQ",",oparms:[{av:'A370NegCpjEndNome',fld:'NEGCPJENDNOME',pic:'@!'},{av:'A371NegCpjEndEndereco',fld:'NEGCPJENDENDERECO',pic:''},{av:'A372NegCpjEndNumero',fld:'NEGCPJENDNUMERO',pic:''},{av:'A373NegCpjEndComplem',fld:'NEGCPJENDCOMPLEM',pic:''},{av:'A374NegCpjEndBairro',fld:'NEGCPJENDBAIRRO',pic:''},{av:'A642NegCpjEndCep',fld:'NEGCPJENDCEP',pic:'ZZZZZZZ9'},{av:'A643NegCpjEndCepFormat',fld:'NEGCPJENDCEPFORMAT',pic:''},{av:'A375NegCpjEndMunID',fld:'NEGCPJENDMUNID',pic:'ZZZZZZ9'},{av:'A376NegCpjEndMunNome',fld:'NEGCPJENDMUNNOME',pic:'@!'},{av:'A377NegCpjEndUFID',fld:'NEGCPJENDUFID',pic:'Z9'},{av:'A378NegCpjEndUFSigla',fld:'NEGCPJENDUFSIGLA',pic:''},{av:'A379NegCpjEndUFNome',fld:'NEGCPJENDUFNOME',pic:'@!'},{av:'A641NegCpjEndCompleto',fld:'NEGCPJENDCOMPLETO',pic:''}]}");
         setEventMetadata("VALID_NEGASSUNTO","{handler:'Valid_Negassunto',iparms:[]");
         setEventMetadata("VALID_NEGASSUNTO",",oparms:[]}");
         setEventMetadata("VALID_NEGVALORESTIMADO","{handler:'Valid_Negvalorestimado',iparms:[]");
         setEventMetadata("VALID_NEGVALORESTIMADO",",oparms:[]}");
         setEventMetadata("VALIDV_COMBONEGCLIID","{handler:'Validv_Combonegcliid',iparms:[]");
         setEventMetadata("VALIDV_COMBONEGCLIID",",oparms:[]}");
         setEventMetadata("VALIDV_COMBONEGCPJID","{handler:'Validv_Combonegcpjid',iparms:[]");
         setEventMetadata("VALIDV_COMBONEGCPJID",",oparms:[]}");
         setEventMetadata("VALIDV_COMBONEGCPJENDSEQ","{handler:'Validv_Combonegcpjendseq',iparms:[]");
         setEventMetadata("VALIDV_COMBONEGCPJENDSEQ",",oparms:[]}");
         setEventMetadata("VALID_NGPITEM","{handler:'Valid_Ngpitem',iparms:[]");
         setEventMetadata("VALID_NGPITEM",",oparms:[]}");
         setEventMetadata("VALID_NGPTPPID","{handler:'Valid_Ngptppid',iparms:[]");
         setEventMetadata("VALID_NGPTPPID",",oparms:[]}");
         setEventMetadata("VALID_NGPTPPPRDID","{handler:'Valid_Ngptppprdid',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'A478NgpTppID',fld:'NGPTPPID',pic:''},{av:'A444NgpTpp1Preco',fld:'NGPTPP1PRECO',pic:'R$ Z,ZZZ,ZZZ,ZZZ,ZZ9.99'},{av:'Gx_BScreen',fld:'vGXBSCREEN',pic:'9'},{av:'dynNgpTppPrdID'},{av:'A439NgpTppPrdID',fld:'NGPTPPPRDID',pic:''},{av:'A440NgpTppPrdCodigo',fld:'NGPTPPPRDCODIGO',pic:''},{av:'A441NgpTppPrdNome',fld:'NGPTPPPRDNOME',pic:'@!'},{av:'A443NgpTppPrdAtivo',fld:'NGPTPPPRDATIVO',pic:''},{av:'A442NgpTppPrdTipoID',fld:'NGPTPPPRDTIPOID',pic:'ZZZ,ZZZ,ZZ9'},{av:'A445NgpPreco',fld:'NGPPRECO',pic:'R$ Z,ZZZ,ZZZ,ZZZ,ZZ9.99'}]");
         setEventMetadata("VALID_NGPTPPPRDID",",oparms:[{av:'A440NgpTppPrdCodigo',fld:'NGPTPPPRDCODIGO',pic:''},{av:'A441NgpTppPrdNome',fld:'NGPTPPPRDNOME',pic:'@!'},{av:'A443NgpTppPrdAtivo',fld:'NGPTPPPRDATIVO',pic:''},{av:'A442NgpTppPrdTipoID',fld:'NGPTPPPRDTIPOID',pic:'ZZZ,ZZZ,ZZ9'},{av:'A444NgpTpp1Preco',fld:'NGPTPP1PRECO',pic:'R$ Z,ZZZ,ZZZ,ZZZ,ZZ9.99'},{av:'A445NgpPreco',fld:'NGPPRECO',pic:'R$ Z,ZZZ,ZZZ,ZZZ,ZZ9.99'}]}");
         setEventMetadata("VALID_NGPTPP1PRECO","{handler:'Valid_Ngptpp1preco',iparms:[]");
         setEventMetadata("VALID_NGPTPP1PRECO",",oparms:[]}");
         setEventMetadata("VALID_NGPPRECO","{handler:'Valid_Ngppreco',iparms:[]");
         setEventMetadata("VALID_NGPPRECO",",oparms:[]}");
         setEventMetadata("VALID_NGPQTDE","{handler:'Valid_Ngpqtde',iparms:[]");
         setEventMetadata("VALID_NGPQTDE",",oparms:[]}");
         setEventMetadata("VALID_NGPTOTAL","{handler:'Valid_Ngptotal',iparms:[]");
         setEventMetadata("VALID_NGPTOTAL",",oparms:[]}");
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
         pr_default.close(44);
         pr_default.close(39);
         pr_default.close(45);
         pr_default.close(40);
         pr_default.close(5);
         pr_default.close(23);
         pr_default.close(24);
         pr_default.close(26);
         pr_default.close(25);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         wcpOAV7NegID = Guid.Empty;
         Z345NegID = Guid.Empty;
         Z348NegInsDataHora = (DateTime)(DateTime.MinValue);
         Z346NegInsData = DateTime.MinValue;
         Z347NegInsHora = (DateTime)(DateTime.MinValue);
         Z349NegInsUsuID = "";
         Z364NegInsUsuNome = "";
         Z573NegDelDataHora = (DateTime)(DateTime.MinValue);
         Z574NegDelData = (DateTime)(DateTime.MinValue);
         Z575NegDelHora = (DateTime)(DateTime.MinValue);
         Z576NegDelUsuId = "";
         Z577NegDelUsuNome = "";
         Z360NegAgcID = "";
         Z361NegAgcNome = "";
         Z362NegAssunto = "";
         Z350NegCliID = Guid.Empty;
         Z352NegCpjID = Guid.Empty;
         N350NegCliID = Guid.Empty;
         N352NegCpjID = Guid.Empty;
         Combo_negcpjendseq_Selectedvalue_get = "";
         Combo_negcpjid_Selectedvalue_get = "";
         Combo_negcliid_Selectedvalue_get = "";
         Z457NgpInsDataHora = (DateTime)(DateTime.MinValue);
         Z455NgpInsData = DateTime.MinValue;
         Z456NgpInsHora = (DateTime)(DateTime.MinValue);
         Z458NgpInsUsuID = "";
         Z459NgpInsUsuNome = "";
         Z579NgpDelDataHora = (DateTime)(DateTime.MinValue);
         Z580NgpDelData = (DateTime)(DateTime.MinValue);
         Z581NgpDelHora = (DateTime)(DateTime.MinValue);
         Z582NgpDelUsuId = "";
         Z583NgpDelUsuNome = "";
         Z453NgpObs = "";
         Z439NgpTppPrdID = Guid.Empty;
         Z478NgpTppID = Guid.Empty;
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A350NegCliID = Guid.Empty;
         A352NegCpjID = Guid.Empty;
         A478NgpTppID = Guid.Empty;
         A439NgpTppPrdID = Guid.Empty;
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         lblTextblocknegcliid_Jsonclick = "";
         ucCombo_negcliid = new GXUserControl();
         AV17DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV16NegCliID_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         TempTags = "";
         lblTextblocknegcpjid_Jsonclick = "";
         ucCombo_negcpjid = new GXUserControl();
         AV25NegCpjID_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         lblTextblocknegcpjendseq_Jsonclick = "";
         ucCombo_negcpjendseq = new GXUserControl();
         AV29NegCpjEndSeq_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A362NegAssunto = "";
         ucNegdescricao = new GXUserControl();
         NegDescricao = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         AV41ComboNegCliID = Guid.Empty;
         AV42ComboNegCpjID = Guid.Empty;
         ucCombo_ngptppid = new GXUserControl();
         AV40NgpTppID_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         Gridlevel_itemContainer = new GXWebGrid( context);
         sMode42 = "";
         sStyleString = "";
         A349NegInsUsuID = "";
         A364NegInsUsuNome = "";
         A573NegDelDataHora = (DateTime)(DateTime.MinValue);
         A574NegDelData = (DateTime)(DateTime.MinValue);
         A575NegDelHora = (DateTime)(DateTime.MinValue);
         A576NegDelUsuId = "";
         A577NegDelUsuNome = "";
         A360NegAgcID = "";
         A361NegAgcNome = "";
         A348NegInsDataHora = (DateTime)(DateTime.MinValue);
         A346NegInsData = DateTime.MinValue;
         A347NegInsHora = (DateTime)(DateTime.MinValue);
         A371NegCpjEndEndereco = "";
         A374NegCpjEndBairro = "";
         A643NegCpjEndCepFormat = "";
         A376NegCpjEndMunNome = "";
         A378NegCpjEndUFSigla = "";
         A372NegCpjEndNumero = "";
         A373NegCpjEndComplem = "";
         A641NegCpjEndCompleto = "";
         A345NegID = Guid.Empty;
         AV13Insert_NegCliID = Guid.Empty;
         AV14Insert_NegCpjID = Guid.Empty;
         AV47AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
         A363NegDescricao = "";
         A351NegCliNomeFamiliar = "";
         A353NegCpjNomFan = "";
         A354NegCpjRazSocial = "";
         A370NegCpjEndNome = "";
         A379NegCpjEndUFNome = "";
         A358NegPjtSigla = "";
         A359NegPjtNome = "";
         AV49Pgmname = "";
         A457NgpInsDataHora = (DateTime)(DateTime.MinValue);
         A455NgpInsData = DateTime.MinValue;
         A456NgpInsHora = (DateTime)(DateTime.MinValue);
         A458NgpInsUsuID = "";
         A459NgpInsUsuNome = "";
         A579NgpDelDataHora = (DateTime)(DateTime.MinValue);
         A580NgpDelData = (DateTime)(DateTime.MinValue);
         A581NgpDelHora = (DateTime)(DateTime.MinValue);
         A582NgpDelUsuId = "";
         A583NgpDelUsuNome = "";
         A453NgpObs = "";
         A440NgpTppPrdCodigo = "";
         A441NgpTppPrdNome = "";
         Combo_negcliid_Objectcall = "";
         Combo_negcliid_Class = "";
         Combo_negcliid_Icontype = "";
         Combo_negcliid_Icon = "";
         Combo_negcliid_Tooltip = "";
         Combo_negcliid_Selectedvalue_set = "";
         Combo_negcliid_Selectedtext_set = "";
         Combo_negcliid_Selectedtext_get = "";
         Combo_negcliid_Gamoauthtoken = "";
         Combo_negcliid_Ddointernalname = "";
         Combo_negcliid_Titlecontrolalign = "";
         Combo_negcliid_Dropdownoptionstype = "";
         Combo_negcliid_Titlecontrolidtoreplace = "";
         Combo_negcliid_Datalisttype = "";
         Combo_negcliid_Datalistfixedvalues = "";
         Combo_negcliid_Datalistproc = "";
         Combo_negcliid_Datalistprocparametersprefix = "";
         Combo_negcliid_Remoteservicesparameters = "";
         Combo_negcliid_Multiplevaluestype = "";
         Combo_negcliid_Loadingdata = "";
         Combo_negcliid_Noresultsfound = "";
         Combo_negcliid_Onlyselectedvalues = "";
         Combo_negcliid_Selectalltext = "";
         Combo_negcliid_Multiplevaluesseparator = "";
         Combo_negcliid_Addnewoptiontext = "";
         Combo_negcpjid_Objectcall = "";
         Combo_negcpjid_Class = "";
         Combo_negcpjid_Icontype = "";
         Combo_negcpjid_Icon = "";
         Combo_negcpjid_Tooltip = "";
         Combo_negcpjid_Selectedvalue_set = "";
         Combo_negcpjid_Selectedtext_set = "";
         Combo_negcpjid_Selectedtext_get = "";
         Combo_negcpjid_Gamoauthtoken = "";
         Combo_negcpjid_Ddointernalname = "";
         Combo_negcpjid_Titlecontrolalign = "";
         Combo_negcpjid_Dropdownoptionstype = "";
         Combo_negcpjid_Titlecontrolidtoreplace = "";
         Combo_negcpjid_Datalisttype = "";
         Combo_negcpjid_Datalistfixedvalues = "";
         Combo_negcpjid_Remoteservicesparameters = "";
         Combo_negcpjid_Multiplevaluestype = "";
         Combo_negcpjid_Loadingdata = "";
         Combo_negcpjid_Noresultsfound = "";
         Combo_negcpjid_Onlyselectedvalues = "";
         Combo_negcpjid_Selectalltext = "";
         Combo_negcpjid_Multiplevaluesseparator = "";
         Combo_negcpjid_Addnewoptiontext = "";
         Combo_negcpjendseq_Objectcall = "";
         Combo_negcpjendseq_Class = "";
         Combo_negcpjendseq_Icontype = "";
         Combo_negcpjendseq_Icon = "";
         Combo_negcpjendseq_Tooltip = "";
         Combo_negcpjendseq_Selectedvalue_set = "";
         Combo_negcpjendseq_Selectedtext_set = "";
         Combo_negcpjendseq_Selectedtext_get = "";
         Combo_negcpjendseq_Gamoauthtoken = "";
         Combo_negcpjendseq_Ddointernalname = "";
         Combo_negcpjendseq_Titlecontrolalign = "";
         Combo_negcpjendseq_Dropdownoptionstype = "";
         Combo_negcpjendseq_Titlecontrolidtoreplace = "";
         Combo_negcpjendseq_Datalisttype = "";
         Combo_negcpjendseq_Datalistfixedvalues = "";
         Combo_negcpjendseq_Remoteservicesparameters = "";
         Combo_negcpjendseq_Multiplevaluestype = "";
         Combo_negcpjendseq_Loadingdata = "";
         Combo_negcpjendseq_Noresultsfound = "";
         Combo_negcpjendseq_Onlyselectedvalues = "";
         Combo_negcpjendseq_Selectalltext = "";
         Combo_negcpjendseq_Multiplevaluesseparator = "";
         Combo_negcpjendseq_Addnewoptiontext = "";
         Negdescricao_Objectcall = "";
         Negdescricao_Class = "";
         Negdescricao_Customtoolbar = "";
         Negdescricao_Customconfiguration = "";
         Negdescricao_Buttonpressedid = "";
         Negdescricao_Captionvalue = "";
         Negdescricao_Coltitle = "";
         Negdescricao_Coltitlefont = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Combo_ngptppid_Objectcall = "";
         Combo_ngptppid_Class = "";
         Combo_ngptppid_Icontype = "";
         Combo_ngptppid_Icon = "";
         Combo_ngptppid_Tooltip = "";
         Combo_ngptppid_Selectedvalue_set = "";
         Combo_ngptppid_Selectedvalue_get = "";
         Combo_ngptppid_Selectedtext_set = "";
         Combo_ngptppid_Selectedtext_get = "";
         Combo_ngptppid_Gamoauthtoken = "";
         Combo_ngptppid_Ddointernalname = "";
         Combo_ngptppid_Titlecontrolalign = "";
         Combo_ngptppid_Dropdownoptionstype = "";
         Combo_ngptppid_Datalisttype = "";
         Combo_ngptppid_Datalistfixedvalues = "";
         Combo_ngptppid_Datalistproc = "";
         Combo_ngptppid_Datalistprocparametersprefix = "";
         Combo_ngptppid_Remoteservicesparameters = "";
         Combo_ngptppid_Multiplevaluestype = "";
         Combo_ngptppid_Loadingdata = "";
         Combo_ngptppid_Noresultsfound = "";
         Combo_ngptppid_Onlyselectedvalues = "";
         Combo_ngptppid_Selectalltext = "";
         Combo_ngptppid_Multiplevaluesseparator = "";
         Combo_ngptppid_Addnewoptiontext = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         T000Y13_A448NegPgpTotal = new decimal[1] ;
         T000Y13_n448NegPgpTotal = new bool[] {false} ;
         sMode37 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV23GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV24GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV15TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV20Combo_DataJson = "";
         AV18ComboSelectedValue = "";
         AV19ComboSelectedText = "";
         GXEncryptionTmp = "";
         AV45Cond_NegCpjID = Guid.Empty;
         AV43Cond_NegCliID = Guid.Empty;
         GXt_char2 = "";
         Z351NegCliNomeFamiliar = "";
         Z353NegCpjNomFan = "";
         Z354NegCpjRazSocial = "";
         Z359NegPjtNome = "";
         Z363NegDescricao = "";
         Z358NegPjtSigla = "";
         Z370NegCpjEndNome = "";
         Z371NegCpjEndEndereco = "";
         Z372NegCpjEndNumero = "";
         Z373NegCpjEndComplem = "";
         Z374NegCpjEndBairro = "";
         Z643NegCpjEndCepFormat = "";
         Z376NegCpjEndMunNome = "";
         Z378NegCpjEndUFSigla = "";
         Z379NegCpjEndUFNome = "";
         T000Y8_A473NegCliMatricula = new long[1] ;
         T000Y8_A351NegCliNomeFamiliar = new string[] {""} ;
         T000Y9_A353NegCpjNomFan = new string[] {""} ;
         T000Y9_A354NegCpjRazSocial = new string[] {""} ;
         T000Y9_A355NegCpjMatricula = new long[1] ;
         T000Y9_A357NegPjtID = new int[1] ;
         T000Y11_A358NegPjtSigla = new string[] {""} ;
         T000Y11_A359NegPjtNome = new string[] {""} ;
         T000Y10_A370NegCpjEndNome = new string[] {""} ;
         T000Y10_A371NegCpjEndEndereco = new string[] {""} ;
         T000Y10_A372NegCpjEndNumero = new string[] {""} ;
         T000Y10_A373NegCpjEndComplem = new string[] {""} ;
         T000Y10_n373NegCpjEndComplem = new bool[] {false} ;
         T000Y10_A374NegCpjEndBairro = new string[] {""} ;
         T000Y10_A642NegCpjEndCep = new int[1] ;
         T000Y10_A643NegCpjEndCepFormat = new string[] {""} ;
         T000Y10_A375NegCpjEndMunID = new int[1] ;
         T000Y10_A376NegCpjEndMunNome = new string[] {""} ;
         T000Y10_A377NegCpjEndUFID = new short[1] ;
         T000Y10_A378NegCpjEndUFSigla = new string[] {""} ;
         T000Y10_A379NegCpjEndUFNome = new string[] {""} ;
         T000Y15_A345NegID = new Guid[] {Guid.Empty} ;
         T000Y15_A356NegCodigo = new long[1] ;
         T000Y15_A348NegInsDataHora = new DateTime[] {DateTime.MinValue} ;
         T000Y15_A346NegInsData = new DateTime[] {DateTime.MinValue} ;
         T000Y15_A347NegInsHora = new DateTime[] {DateTime.MinValue} ;
         T000Y15_A349NegInsUsuID = new string[] {""} ;
         T000Y15_n349NegInsUsuID = new bool[] {false} ;
         T000Y15_A364NegInsUsuNome = new string[] {""} ;
         T000Y15_n364NegInsUsuNome = new bool[] {false} ;
         T000Y15_A385NegValorAtualizado = new decimal[1] ;
         T000Y15_A380NegValorEstimado = new decimal[1] ;
         T000Y15_A573NegDelDataHora = new DateTime[] {DateTime.MinValue} ;
         T000Y15_n573NegDelDataHora = new bool[] {false} ;
         T000Y15_A574NegDelData = new DateTime[] {DateTime.MinValue} ;
         T000Y15_n574NegDelData = new bool[] {false} ;
         T000Y15_A575NegDelHora = new DateTime[] {DateTime.MinValue} ;
         T000Y15_n575NegDelHora = new bool[] {false} ;
         T000Y15_A576NegDelUsuId = new string[] {""} ;
         T000Y15_n576NegDelUsuId = new bool[] {false} ;
         T000Y15_A577NegDelUsuNome = new string[] {""} ;
         T000Y15_n577NegDelUsuNome = new bool[] {false} ;
         T000Y15_A473NegCliMatricula = new long[1] ;
         T000Y15_A351NegCliNomeFamiliar = new string[] {""} ;
         T000Y15_A353NegCpjNomFan = new string[] {""} ;
         T000Y15_A354NegCpjRazSocial = new string[] {""} ;
         T000Y15_A355NegCpjMatricula = new long[1] ;
         T000Y15_A358NegPjtSigla = new string[] {""} ;
         T000Y15_A359NegPjtNome = new string[] {""} ;
         T000Y15_A370NegCpjEndNome = new string[] {""} ;
         T000Y15_A371NegCpjEndEndereco = new string[] {""} ;
         T000Y15_A372NegCpjEndNumero = new string[] {""} ;
         T000Y15_A373NegCpjEndComplem = new string[] {""} ;
         T000Y15_n373NegCpjEndComplem = new bool[] {false} ;
         T000Y15_A374NegCpjEndBairro = new string[] {""} ;
         T000Y15_A642NegCpjEndCep = new int[1] ;
         T000Y15_A643NegCpjEndCepFormat = new string[] {""} ;
         T000Y15_A375NegCpjEndMunID = new int[1] ;
         T000Y15_A376NegCpjEndMunNome = new string[] {""} ;
         T000Y15_A377NegCpjEndUFID = new short[1] ;
         T000Y15_A378NegCpjEndUFSigla = new string[] {""} ;
         T000Y15_A379NegCpjEndUFNome = new string[] {""} ;
         T000Y15_A360NegAgcID = new string[] {""} ;
         T000Y15_n360NegAgcID = new bool[] {false} ;
         T000Y15_A361NegAgcNome = new string[] {""} ;
         T000Y15_n361NegAgcNome = new bool[] {false} ;
         T000Y15_A362NegAssunto = new string[] {""} ;
         T000Y15_A363NegDescricao = new string[] {""} ;
         T000Y15_A454NegUltItem = new int[1] ;
         T000Y15_n454NegUltItem = new bool[] {false} ;
         T000Y15_A572NegDel = new bool[] {false} ;
         T000Y15_A350NegCliID = new Guid[] {Guid.Empty} ;
         T000Y15_A352NegCpjID = new Guid[] {Guid.Empty} ;
         T000Y15_A369NegCpjEndSeq = new short[1] ;
         T000Y15_A357NegPjtID = new int[1] ;
         T000Y15_A448NegPgpTotal = new decimal[1] ;
         T000Y15_n448NegPgpTotal = new bool[] {false} ;
         T000Y16_A356NegCodigo = new long[1] ;
         T000Y17_A473NegCliMatricula = new long[1] ;
         T000Y17_A351NegCliNomeFamiliar = new string[] {""} ;
         T000Y18_A353NegCpjNomFan = new string[] {""} ;
         T000Y18_A354NegCpjRazSocial = new string[] {""} ;
         T000Y18_A355NegCpjMatricula = new long[1] ;
         T000Y18_A357NegPjtID = new int[1] ;
         T000Y19_A358NegPjtSigla = new string[] {""} ;
         T000Y19_A359NegPjtNome = new string[] {""} ;
         T000Y20_A370NegCpjEndNome = new string[] {""} ;
         T000Y20_A371NegCpjEndEndereco = new string[] {""} ;
         T000Y20_A372NegCpjEndNumero = new string[] {""} ;
         T000Y20_A373NegCpjEndComplem = new string[] {""} ;
         T000Y20_n373NegCpjEndComplem = new bool[] {false} ;
         T000Y20_A374NegCpjEndBairro = new string[] {""} ;
         T000Y20_A642NegCpjEndCep = new int[1] ;
         T000Y20_A643NegCpjEndCepFormat = new string[] {""} ;
         T000Y20_A375NegCpjEndMunID = new int[1] ;
         T000Y20_A376NegCpjEndMunNome = new string[] {""} ;
         T000Y20_A377NegCpjEndUFID = new short[1] ;
         T000Y20_A378NegCpjEndUFSigla = new string[] {""} ;
         T000Y20_A379NegCpjEndUFNome = new string[] {""} ;
         T000Y21_A345NegID = new Guid[] {Guid.Empty} ;
         T000Y7_A345NegID = new Guid[] {Guid.Empty} ;
         T000Y7_A356NegCodigo = new long[1] ;
         T000Y7_A348NegInsDataHora = new DateTime[] {DateTime.MinValue} ;
         T000Y7_A346NegInsData = new DateTime[] {DateTime.MinValue} ;
         T000Y7_A347NegInsHora = new DateTime[] {DateTime.MinValue} ;
         T000Y7_A349NegInsUsuID = new string[] {""} ;
         T000Y7_n349NegInsUsuID = new bool[] {false} ;
         T000Y7_A364NegInsUsuNome = new string[] {""} ;
         T000Y7_n364NegInsUsuNome = new bool[] {false} ;
         T000Y7_A385NegValorAtualizado = new decimal[1] ;
         T000Y7_A380NegValorEstimado = new decimal[1] ;
         T000Y7_A573NegDelDataHora = new DateTime[] {DateTime.MinValue} ;
         T000Y7_n573NegDelDataHora = new bool[] {false} ;
         T000Y7_A574NegDelData = new DateTime[] {DateTime.MinValue} ;
         T000Y7_n574NegDelData = new bool[] {false} ;
         T000Y7_A575NegDelHora = new DateTime[] {DateTime.MinValue} ;
         T000Y7_n575NegDelHora = new bool[] {false} ;
         T000Y7_A576NegDelUsuId = new string[] {""} ;
         T000Y7_n576NegDelUsuId = new bool[] {false} ;
         T000Y7_A577NegDelUsuNome = new string[] {""} ;
         T000Y7_n577NegDelUsuNome = new bool[] {false} ;
         T000Y7_A360NegAgcID = new string[] {""} ;
         T000Y7_n360NegAgcID = new bool[] {false} ;
         T000Y7_A361NegAgcNome = new string[] {""} ;
         T000Y7_n361NegAgcNome = new bool[] {false} ;
         T000Y7_A362NegAssunto = new string[] {""} ;
         T000Y7_A363NegDescricao = new string[] {""} ;
         T000Y7_A454NegUltItem = new int[1] ;
         T000Y7_n454NegUltItem = new bool[] {false} ;
         T000Y7_A572NegDel = new bool[] {false} ;
         T000Y7_A350NegCliID = new Guid[] {Guid.Empty} ;
         T000Y7_A352NegCpjID = new Guid[] {Guid.Empty} ;
         T000Y7_A369NegCpjEndSeq = new short[1] ;
         T000Y7_A351NegCliNomeFamiliar = new string[] {""} ;
         T000Y7_A353NegCpjNomFan = new string[] {""} ;
         T000Y7_A354NegCpjRazSocial = new string[] {""} ;
         T000Y7_A359NegPjtNome = new string[] {""} ;
         T000Y22_A345NegID = new Guid[] {Guid.Empty} ;
         T000Y23_A345NegID = new Guid[] {Guid.Empty} ;
         T000Y6_A345NegID = new Guid[] {Guid.Empty} ;
         T000Y6_A356NegCodigo = new long[1] ;
         T000Y6_A348NegInsDataHora = new DateTime[] {DateTime.MinValue} ;
         T000Y6_A346NegInsData = new DateTime[] {DateTime.MinValue} ;
         T000Y6_A347NegInsHora = new DateTime[] {DateTime.MinValue} ;
         T000Y6_A349NegInsUsuID = new string[] {""} ;
         T000Y6_n349NegInsUsuID = new bool[] {false} ;
         T000Y6_A364NegInsUsuNome = new string[] {""} ;
         T000Y6_n364NegInsUsuNome = new bool[] {false} ;
         T000Y6_A385NegValorAtualizado = new decimal[1] ;
         T000Y6_A380NegValorEstimado = new decimal[1] ;
         T000Y6_A573NegDelDataHora = new DateTime[] {DateTime.MinValue} ;
         T000Y6_n573NegDelDataHora = new bool[] {false} ;
         T000Y6_A574NegDelData = new DateTime[] {DateTime.MinValue} ;
         T000Y6_n574NegDelData = new bool[] {false} ;
         T000Y6_A575NegDelHora = new DateTime[] {DateTime.MinValue} ;
         T000Y6_n575NegDelHora = new bool[] {false} ;
         T000Y6_A576NegDelUsuId = new string[] {""} ;
         T000Y6_n576NegDelUsuId = new bool[] {false} ;
         T000Y6_A577NegDelUsuNome = new string[] {""} ;
         T000Y6_n577NegDelUsuNome = new bool[] {false} ;
         T000Y6_A360NegAgcID = new string[] {""} ;
         T000Y6_n360NegAgcID = new bool[] {false} ;
         T000Y6_A361NegAgcNome = new string[] {""} ;
         T000Y6_n361NegAgcNome = new bool[] {false} ;
         T000Y6_A362NegAssunto = new string[] {""} ;
         T000Y6_A363NegDescricao = new string[] {""} ;
         T000Y6_A454NegUltItem = new int[1] ;
         T000Y6_n454NegUltItem = new bool[] {false} ;
         T000Y6_A572NegDel = new bool[] {false} ;
         T000Y6_A350NegCliID = new Guid[] {Guid.Empty} ;
         T000Y6_A352NegCpjID = new Guid[] {Guid.Empty} ;
         T000Y6_A369NegCpjEndSeq = new short[1] ;
         T000Y6_A351NegCliNomeFamiliar = new string[] {""} ;
         T000Y6_A353NegCpjNomFan = new string[] {""} ;
         T000Y6_A354NegCpjRazSocial = new string[] {""} ;
         T000Y6_A359NegPjtNome = new string[] {""} ;
         T000Y27_A473NegCliMatricula = new long[1] ;
         T000Y27_A351NegCliNomeFamiliar = new string[] {""} ;
         T000Y28_A353NegCpjNomFan = new string[] {""} ;
         T000Y28_A354NegCpjRazSocial = new string[] {""} ;
         T000Y28_A355NegCpjMatricula = new long[1] ;
         T000Y28_A357NegPjtID = new int[1] ;
         T000Y29_A358NegPjtSigla = new string[] {""} ;
         T000Y29_A359NegPjtNome = new string[] {""} ;
         T000Y30_A370NegCpjEndNome = new string[] {""} ;
         T000Y30_A371NegCpjEndEndereco = new string[] {""} ;
         T000Y30_A372NegCpjEndNumero = new string[] {""} ;
         T000Y30_A373NegCpjEndComplem = new string[] {""} ;
         T000Y30_n373NegCpjEndComplem = new bool[] {false} ;
         T000Y30_A374NegCpjEndBairro = new string[] {""} ;
         T000Y30_A642NegCpjEndCep = new int[1] ;
         T000Y30_A643NegCpjEndCepFormat = new string[] {""} ;
         T000Y30_A375NegCpjEndMunID = new int[1] ;
         T000Y30_A376NegCpjEndMunNome = new string[] {""} ;
         T000Y30_A377NegCpjEndUFID = new short[1] ;
         T000Y30_A378NegCpjEndUFSigla = new string[] {""} ;
         T000Y30_A379NegCpjEndUFNome = new string[] {""} ;
         T000Y31_A398VisID = new Guid[] {Guid.Empty} ;
         T000Y32_A345NegID = new Guid[] {Guid.Empty} ;
         T000Y32_A626NefChave = new string[] {""} ;
         T000Y33_A345NegID = new Guid[] {Guid.Empty} ;
         T000Y33_A387NgfSeq = new int[1] ;
         T000Y35_A345NegID = new Guid[] {Guid.Empty} ;
         Z440NgpTppPrdCodigo = "";
         Z441NgpTppPrdNome = "";
         T000Y4_A440NgpTppPrdCodigo = new string[] {""} ;
         T000Y4_A441NgpTppPrdNome = new string[] {""} ;
         T000Y4_A443NgpTppPrdAtivo = new bool[] {false} ;
         T000Y4_A442NgpTppPrdTipoID = new int[1] ;
         T000Y36_A447NgpTotal = new decimal[1] ;
         T000Y36_A345NegID = new Guid[] {Guid.Empty} ;
         T000Y36_A435NgpItem = new int[1] ;
         T000Y36_A446NgpQtde = new int[1] ;
         T000Y36_A445NgpPreco = new decimal[1] ;
         T000Y36_A457NgpInsDataHora = new DateTime[] {DateTime.MinValue} ;
         T000Y36_A455NgpInsData = new DateTime[] {DateTime.MinValue} ;
         T000Y36_A456NgpInsHora = new DateTime[] {DateTime.MinValue} ;
         T000Y36_A458NgpInsUsuID = new string[] {""} ;
         T000Y36_n458NgpInsUsuID = new bool[] {false} ;
         T000Y36_A459NgpInsUsuNome = new string[] {""} ;
         T000Y36_n459NgpInsUsuNome = new bool[] {false} ;
         T000Y36_A579NgpDelDataHora = new DateTime[] {DateTime.MinValue} ;
         T000Y36_n579NgpDelDataHora = new bool[] {false} ;
         T000Y36_A580NgpDelData = new DateTime[] {DateTime.MinValue} ;
         T000Y36_n580NgpDelData = new bool[] {false} ;
         T000Y36_A581NgpDelHora = new DateTime[] {DateTime.MinValue} ;
         T000Y36_n581NgpDelHora = new bool[] {false} ;
         T000Y36_A582NgpDelUsuId = new string[] {""} ;
         T000Y36_n582NgpDelUsuId = new bool[] {false} ;
         T000Y36_A583NgpDelUsuNome = new string[] {""} ;
         T000Y36_n583NgpDelUsuNome = new bool[] {false} ;
         T000Y36_A440NgpTppPrdCodigo = new string[] {""} ;
         T000Y36_A441NgpTppPrdNome = new string[] {""} ;
         T000Y36_A443NgpTppPrdAtivo = new bool[] {false} ;
         T000Y36_A444NgpTpp1Preco = new decimal[1] ;
         T000Y36_A453NgpObs = new string[] {""} ;
         T000Y36_A578NgpDel = new bool[] {false} ;
         T000Y36_A439NgpTppPrdID = new Guid[] {Guid.Empty} ;
         T000Y36_A478NgpTppID = new Guid[] {Guid.Empty} ;
         T000Y36_A442NgpTppPrdTipoID = new int[1] ;
         T000Y5_A444NgpTpp1Preco = new decimal[1] ;
         GXCCtl = "";
         T000Y37_A444NgpTpp1Preco = new decimal[1] ;
         T000Y38_A440NgpTppPrdCodigo = new string[] {""} ;
         T000Y38_A441NgpTppPrdNome = new string[] {""} ;
         T000Y38_A443NgpTppPrdAtivo = new bool[] {false} ;
         T000Y38_A442NgpTppPrdTipoID = new int[1] ;
         T000Y39_A345NegID = new Guid[] {Guid.Empty} ;
         T000Y39_A435NgpItem = new int[1] ;
         T000Y3_A447NgpTotal = new decimal[1] ;
         T000Y3_A345NegID = new Guid[] {Guid.Empty} ;
         T000Y3_A435NgpItem = new int[1] ;
         T000Y3_A446NgpQtde = new int[1] ;
         T000Y3_A445NgpPreco = new decimal[1] ;
         T000Y3_A457NgpInsDataHora = new DateTime[] {DateTime.MinValue} ;
         T000Y3_A455NgpInsData = new DateTime[] {DateTime.MinValue} ;
         T000Y3_A456NgpInsHora = new DateTime[] {DateTime.MinValue} ;
         T000Y3_A458NgpInsUsuID = new string[] {""} ;
         T000Y3_n458NgpInsUsuID = new bool[] {false} ;
         T000Y3_A459NgpInsUsuNome = new string[] {""} ;
         T000Y3_n459NgpInsUsuNome = new bool[] {false} ;
         T000Y3_A579NgpDelDataHora = new DateTime[] {DateTime.MinValue} ;
         T000Y3_n579NgpDelDataHora = new bool[] {false} ;
         T000Y3_A580NgpDelData = new DateTime[] {DateTime.MinValue} ;
         T000Y3_n580NgpDelData = new bool[] {false} ;
         T000Y3_A581NgpDelHora = new DateTime[] {DateTime.MinValue} ;
         T000Y3_n581NgpDelHora = new bool[] {false} ;
         T000Y3_A582NgpDelUsuId = new string[] {""} ;
         T000Y3_n582NgpDelUsuId = new bool[] {false} ;
         T000Y3_A583NgpDelUsuNome = new string[] {""} ;
         T000Y3_n583NgpDelUsuNome = new bool[] {false} ;
         T000Y3_A453NgpObs = new string[] {""} ;
         T000Y3_A578NgpDel = new bool[] {false} ;
         T000Y3_A439NgpTppPrdID = new Guid[] {Guid.Empty} ;
         T000Y3_A478NgpTppID = new Guid[] {Guid.Empty} ;
         T000Y2_A447NgpTotal = new decimal[1] ;
         T000Y2_A345NegID = new Guid[] {Guid.Empty} ;
         T000Y2_A435NgpItem = new int[1] ;
         T000Y2_A446NgpQtde = new int[1] ;
         T000Y2_A445NgpPreco = new decimal[1] ;
         T000Y2_A457NgpInsDataHora = new DateTime[] {DateTime.MinValue} ;
         T000Y2_A455NgpInsData = new DateTime[] {DateTime.MinValue} ;
         T000Y2_A456NgpInsHora = new DateTime[] {DateTime.MinValue} ;
         T000Y2_A458NgpInsUsuID = new string[] {""} ;
         T000Y2_n458NgpInsUsuID = new bool[] {false} ;
         T000Y2_A459NgpInsUsuNome = new string[] {""} ;
         T000Y2_n459NgpInsUsuNome = new bool[] {false} ;
         T000Y2_A579NgpDelDataHora = new DateTime[] {DateTime.MinValue} ;
         T000Y2_n579NgpDelDataHora = new bool[] {false} ;
         T000Y2_A580NgpDelData = new DateTime[] {DateTime.MinValue} ;
         T000Y2_n580NgpDelData = new bool[] {false} ;
         T000Y2_A581NgpDelHora = new DateTime[] {DateTime.MinValue} ;
         T000Y2_n581NgpDelHora = new bool[] {false} ;
         T000Y2_A582NgpDelUsuId = new string[] {""} ;
         T000Y2_n582NgpDelUsuId = new bool[] {false} ;
         T000Y2_A583NgpDelUsuNome = new string[] {""} ;
         T000Y2_n583NgpDelUsuNome = new bool[] {false} ;
         T000Y2_A453NgpObs = new string[] {""} ;
         T000Y2_A578NgpDel = new bool[] {false} ;
         T000Y2_A439NgpTppPrdID = new Guid[] {Guid.Empty} ;
         T000Y2_A478NgpTppID = new Guid[] {Guid.Empty} ;
         T000Y43_A440NgpTppPrdCodigo = new string[] {""} ;
         T000Y43_A441NgpTppPrdNome = new string[] {""} ;
         T000Y43_A443NgpTppPrdAtivo = new bool[] {false} ;
         T000Y43_A442NgpTppPrdTipoID = new int[1] ;
         T000Y44_A444NgpTpp1Preco = new decimal[1] ;
         T000Y45_A345NegID = new Guid[] {Guid.Empty} ;
         T000Y45_A435NgpItem = new int[1] ;
         Gridlevel_itemRow = new GXWebRow();
         subGridlevel_item_Linesclass = "";
         ROClassString = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         Gridlevel_itemColumn = new GXWebColumn();
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         T000Y46_A220PrdID = new Guid[] {Guid.Empty} ;
         T000Y46_A222PrdNome = new string[] {""} ;
         T000Y46_A231PrdAtivo = new bool[] {false} ;
         T000Y46_A620PrdDel = new bool[] {false} ;
         T000Y47_A356NegCodigo = new long[1] ;
         Z641NegCpjEndCompleto = "";
         T000Y48_A440NgpTppPrdCodigo = new string[] {""} ;
         T000Y48_A441NgpTppPrdNome = new string[] {""} ;
         T000Y48_A443NgpTppPrdAtivo = new bool[] {false} ;
         T000Y48_A442NgpTppPrdTipoID = new int[1] ;
         T000Y49_A444NgpTpp1Preco = new decimal[1] ;
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.core.negociopj__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.negociopj__default(),
            new Object[][] {
                new Object[] {
               T000Y2_A447NgpTotal, T000Y2_A345NegID, T000Y2_A435NgpItem, T000Y2_A446NgpQtde, T000Y2_A445NgpPreco, T000Y2_A457NgpInsDataHora, T000Y2_A455NgpInsData, T000Y2_A456NgpInsHora, T000Y2_A458NgpInsUsuID, T000Y2_n458NgpInsUsuID,
               T000Y2_A459NgpInsUsuNome, T000Y2_n459NgpInsUsuNome, T000Y2_A579NgpDelDataHora, T000Y2_n579NgpDelDataHora, T000Y2_A580NgpDelData, T000Y2_n580NgpDelData, T000Y2_A581NgpDelHora, T000Y2_n581NgpDelHora, T000Y2_A582NgpDelUsuId, T000Y2_n582NgpDelUsuId,
               T000Y2_A583NgpDelUsuNome, T000Y2_n583NgpDelUsuNome, T000Y2_A453NgpObs, T000Y2_A578NgpDel, T000Y2_A439NgpTppPrdID, T000Y2_A478NgpTppID
               }
               , new Object[] {
               T000Y3_A447NgpTotal, T000Y3_A345NegID, T000Y3_A435NgpItem, T000Y3_A446NgpQtde, T000Y3_A445NgpPreco, T000Y3_A457NgpInsDataHora, T000Y3_A455NgpInsData, T000Y3_A456NgpInsHora, T000Y3_A458NgpInsUsuID, T000Y3_n458NgpInsUsuID,
               T000Y3_A459NgpInsUsuNome, T000Y3_n459NgpInsUsuNome, T000Y3_A579NgpDelDataHora, T000Y3_n579NgpDelDataHora, T000Y3_A580NgpDelData, T000Y3_n580NgpDelData, T000Y3_A581NgpDelHora, T000Y3_n581NgpDelHora, T000Y3_A582NgpDelUsuId, T000Y3_n582NgpDelUsuId,
               T000Y3_A583NgpDelUsuNome, T000Y3_n583NgpDelUsuNome, T000Y3_A453NgpObs, T000Y3_A578NgpDel, T000Y3_A439NgpTppPrdID, T000Y3_A478NgpTppID
               }
               , new Object[] {
               T000Y4_A440NgpTppPrdCodigo, T000Y4_A441NgpTppPrdNome, T000Y4_A443NgpTppPrdAtivo, T000Y4_A442NgpTppPrdTipoID
               }
               , new Object[] {
               T000Y5_A444NgpTpp1Preco
               }
               , new Object[] {
               T000Y6_A345NegID, T000Y6_A356NegCodigo, T000Y6_A348NegInsDataHora, T000Y6_A346NegInsData, T000Y6_A347NegInsHora, T000Y6_A349NegInsUsuID, T000Y6_n349NegInsUsuID, T000Y6_A364NegInsUsuNome, T000Y6_n364NegInsUsuNome, T000Y6_A385NegValorAtualizado,
               T000Y6_A380NegValorEstimado, T000Y6_A573NegDelDataHora, T000Y6_n573NegDelDataHora, T000Y6_A574NegDelData, T000Y6_n574NegDelData, T000Y6_A575NegDelHora, T000Y6_n575NegDelHora, T000Y6_A576NegDelUsuId, T000Y6_n576NegDelUsuId, T000Y6_A577NegDelUsuNome,
               T000Y6_n577NegDelUsuNome, T000Y6_A360NegAgcID, T000Y6_n360NegAgcID, T000Y6_A361NegAgcNome, T000Y6_n361NegAgcNome, T000Y6_A362NegAssunto, T000Y6_A363NegDescricao, T000Y6_A454NegUltItem, T000Y6_n454NegUltItem, T000Y6_A572NegDel,
               T000Y6_A350NegCliID, T000Y6_A352NegCpjID, T000Y6_A369NegCpjEndSeq, T000Y6_A351NegCliNomeFamiliar, T000Y6_A353NegCpjNomFan, T000Y6_A354NegCpjRazSocial, T000Y6_A359NegPjtNome
               }
               , new Object[] {
               T000Y7_A345NegID, T000Y7_A356NegCodigo, T000Y7_A348NegInsDataHora, T000Y7_A346NegInsData, T000Y7_A347NegInsHora, T000Y7_A349NegInsUsuID, T000Y7_n349NegInsUsuID, T000Y7_A364NegInsUsuNome, T000Y7_n364NegInsUsuNome, T000Y7_A385NegValorAtualizado,
               T000Y7_A380NegValorEstimado, T000Y7_A573NegDelDataHora, T000Y7_n573NegDelDataHora, T000Y7_A574NegDelData, T000Y7_n574NegDelData, T000Y7_A575NegDelHora, T000Y7_n575NegDelHora, T000Y7_A576NegDelUsuId, T000Y7_n576NegDelUsuId, T000Y7_A577NegDelUsuNome,
               T000Y7_n577NegDelUsuNome, T000Y7_A360NegAgcID, T000Y7_n360NegAgcID, T000Y7_A361NegAgcNome, T000Y7_n361NegAgcNome, T000Y7_A362NegAssunto, T000Y7_A363NegDescricao, T000Y7_A454NegUltItem, T000Y7_n454NegUltItem, T000Y7_A572NegDel,
               T000Y7_A350NegCliID, T000Y7_A352NegCpjID, T000Y7_A369NegCpjEndSeq, T000Y7_A351NegCliNomeFamiliar, T000Y7_A353NegCpjNomFan, T000Y7_A354NegCpjRazSocial, T000Y7_A359NegPjtNome
               }
               , new Object[] {
               T000Y8_A473NegCliMatricula, T000Y8_A351NegCliNomeFamiliar
               }
               , new Object[] {
               T000Y9_A353NegCpjNomFan, T000Y9_A354NegCpjRazSocial, T000Y9_A355NegCpjMatricula, T000Y9_A357NegPjtID
               }
               , new Object[] {
               T000Y10_A370NegCpjEndNome, T000Y10_A371NegCpjEndEndereco, T000Y10_A372NegCpjEndNumero, T000Y10_A373NegCpjEndComplem, T000Y10_n373NegCpjEndComplem, T000Y10_A374NegCpjEndBairro, T000Y10_A642NegCpjEndCep, T000Y10_A643NegCpjEndCepFormat, T000Y10_A375NegCpjEndMunID, T000Y10_A376NegCpjEndMunNome,
               T000Y10_A377NegCpjEndUFID, T000Y10_A378NegCpjEndUFSigla, T000Y10_A379NegCpjEndUFNome
               }
               , new Object[] {
               T000Y11_A358NegPjtSigla, T000Y11_A359NegPjtNome
               }
               , new Object[] {
               T000Y13_A448NegPgpTotal, T000Y13_n448NegPgpTotal
               }
               , new Object[] {
               T000Y15_A345NegID, T000Y15_A356NegCodigo, T000Y15_A348NegInsDataHora, T000Y15_A346NegInsData, T000Y15_A347NegInsHora, T000Y15_A349NegInsUsuID, T000Y15_n349NegInsUsuID, T000Y15_A364NegInsUsuNome, T000Y15_n364NegInsUsuNome, T000Y15_A385NegValorAtualizado,
               T000Y15_A380NegValorEstimado, T000Y15_A573NegDelDataHora, T000Y15_n573NegDelDataHora, T000Y15_A574NegDelData, T000Y15_n574NegDelData, T000Y15_A575NegDelHora, T000Y15_n575NegDelHora, T000Y15_A576NegDelUsuId, T000Y15_n576NegDelUsuId, T000Y15_A577NegDelUsuNome,
               T000Y15_n577NegDelUsuNome, T000Y15_A473NegCliMatricula, T000Y15_A351NegCliNomeFamiliar, T000Y15_A353NegCpjNomFan, T000Y15_A354NegCpjRazSocial, T000Y15_A355NegCpjMatricula, T000Y15_A358NegPjtSigla, T000Y15_A359NegPjtNome, T000Y15_A370NegCpjEndNome, T000Y15_A371NegCpjEndEndereco,
               T000Y15_A372NegCpjEndNumero, T000Y15_A373NegCpjEndComplem, T000Y15_n373NegCpjEndComplem, T000Y15_A374NegCpjEndBairro, T000Y15_A642NegCpjEndCep, T000Y15_A643NegCpjEndCepFormat, T000Y15_A375NegCpjEndMunID, T000Y15_A376NegCpjEndMunNome, T000Y15_A377NegCpjEndUFID, T000Y15_A378NegCpjEndUFSigla,
               T000Y15_A379NegCpjEndUFNome, T000Y15_A360NegAgcID, T000Y15_n360NegAgcID, T000Y15_A361NegAgcNome, T000Y15_n361NegAgcNome, T000Y15_A362NegAssunto, T000Y15_A363NegDescricao, T000Y15_A454NegUltItem, T000Y15_n454NegUltItem, T000Y15_A572NegDel,
               T000Y15_A350NegCliID, T000Y15_A352NegCpjID, T000Y15_A369NegCpjEndSeq, T000Y15_A357NegPjtID, T000Y15_A448NegPgpTotal, T000Y15_n448NegPgpTotal
               }
               , new Object[] {
               T000Y16_A356NegCodigo
               }
               , new Object[] {
               T000Y17_A473NegCliMatricula, T000Y17_A351NegCliNomeFamiliar
               }
               , new Object[] {
               T000Y18_A353NegCpjNomFan, T000Y18_A354NegCpjRazSocial, T000Y18_A355NegCpjMatricula, T000Y18_A357NegPjtID
               }
               , new Object[] {
               T000Y19_A358NegPjtSigla, T000Y19_A359NegPjtNome
               }
               , new Object[] {
               T000Y20_A370NegCpjEndNome, T000Y20_A371NegCpjEndEndereco, T000Y20_A372NegCpjEndNumero, T000Y20_A373NegCpjEndComplem, T000Y20_n373NegCpjEndComplem, T000Y20_A374NegCpjEndBairro, T000Y20_A642NegCpjEndCep, T000Y20_A643NegCpjEndCepFormat, T000Y20_A375NegCpjEndMunID, T000Y20_A376NegCpjEndMunNome,
               T000Y20_A377NegCpjEndUFID, T000Y20_A378NegCpjEndUFSigla, T000Y20_A379NegCpjEndUFNome
               }
               , new Object[] {
               T000Y21_A345NegID
               }
               , new Object[] {
               T000Y22_A345NegID
               }
               , new Object[] {
               T000Y23_A345NegID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000Y27_A473NegCliMatricula, T000Y27_A351NegCliNomeFamiliar
               }
               , new Object[] {
               T000Y28_A353NegCpjNomFan, T000Y28_A354NegCpjRazSocial, T000Y28_A355NegCpjMatricula, T000Y28_A357NegPjtID
               }
               , new Object[] {
               T000Y29_A358NegPjtSigla, T000Y29_A359NegPjtNome
               }
               , new Object[] {
               T000Y30_A370NegCpjEndNome, T000Y30_A371NegCpjEndEndereco, T000Y30_A372NegCpjEndNumero, T000Y30_A373NegCpjEndComplem, T000Y30_n373NegCpjEndComplem, T000Y30_A374NegCpjEndBairro, T000Y30_A642NegCpjEndCep, T000Y30_A643NegCpjEndCepFormat, T000Y30_A375NegCpjEndMunID, T000Y30_A376NegCpjEndMunNome,
               T000Y30_A377NegCpjEndUFID, T000Y30_A378NegCpjEndUFSigla, T000Y30_A379NegCpjEndUFNome
               }
               , new Object[] {
               T000Y31_A398VisID
               }
               , new Object[] {
               T000Y32_A345NegID, T000Y32_A626NefChave
               }
               , new Object[] {
               T000Y33_A345NegID, T000Y33_A387NgfSeq
               }
               , new Object[] {
               }
               , new Object[] {
               T000Y35_A345NegID
               }
               , new Object[] {
               T000Y36_A447NgpTotal, T000Y36_A345NegID, T000Y36_A435NgpItem, T000Y36_A446NgpQtde, T000Y36_A445NgpPreco, T000Y36_A457NgpInsDataHora, T000Y36_A455NgpInsData, T000Y36_A456NgpInsHora, T000Y36_A458NgpInsUsuID, T000Y36_n458NgpInsUsuID,
               T000Y36_A459NgpInsUsuNome, T000Y36_n459NgpInsUsuNome, T000Y36_A579NgpDelDataHora, T000Y36_n579NgpDelDataHora, T000Y36_A580NgpDelData, T000Y36_n580NgpDelData, T000Y36_A581NgpDelHora, T000Y36_n581NgpDelHora, T000Y36_A582NgpDelUsuId, T000Y36_n582NgpDelUsuId,
               T000Y36_A583NgpDelUsuNome, T000Y36_n583NgpDelUsuNome, T000Y36_A440NgpTppPrdCodigo, T000Y36_A441NgpTppPrdNome, T000Y36_A443NgpTppPrdAtivo, T000Y36_A444NgpTpp1Preco, T000Y36_A453NgpObs, T000Y36_A578NgpDel, T000Y36_A439NgpTppPrdID, T000Y36_A478NgpTppID,
               T000Y36_A442NgpTppPrdTipoID
               }
               , new Object[] {
               T000Y37_A444NgpTpp1Preco
               }
               , new Object[] {
               T000Y38_A440NgpTppPrdCodigo, T000Y38_A441NgpTppPrdNome, T000Y38_A443NgpTppPrdAtivo, T000Y38_A442NgpTppPrdTipoID
               }
               , new Object[] {
               T000Y39_A345NegID, T000Y39_A435NgpItem
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000Y43_A440NgpTppPrdCodigo, T000Y43_A441NgpTppPrdNome, T000Y43_A443NgpTppPrdAtivo, T000Y43_A442NgpTppPrdTipoID
               }
               , new Object[] {
               T000Y44_A444NgpTpp1Preco
               }
               , new Object[] {
               T000Y45_A345NegID, T000Y45_A435NgpItem
               }
               , new Object[] {
               T000Y46_A220PrdID, T000Y46_A222PrdNome, T000Y46_A231PrdAtivo, T000Y46_A620PrdDel
               }
               , new Object[] {
               T000Y47_A356NegCodigo
               }
               , new Object[] {
               T000Y48_A440NgpTppPrdCodigo, T000Y48_A441NgpTppPrdNome, T000Y48_A443NgpTppPrdAtivo, T000Y48_A442NgpTppPrdTipoID
               }
               , new Object[] {
               T000Y49_A444NgpTpp1Preco
               }
            }
         );
         Z446NgpQtde = 1;
         A446NgpQtde = 1;
         i446NgpQtde = 1;
         Z345NegID = Guid.NewGuid( );
         A345NegID = Guid.NewGuid( );
         AV49Pgmname = "core.NegocioPJ";
         Z445NgpPreco = 0;
         A445NgpPreco = 0;
      }

      private short Z369NegCpjEndSeq ;
      private short N369NegCpjEndSeq ;
      private short nRcdDeleted_42 ;
      private short nRcdExists_42 ;
      private short nIsMod_42 ;
      private short GxWebError ;
      private short A369NegCpjEndSeq ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short initialized ;
      private short AV44ComboNegCpjEndSeq ;
      private short nBlankRcdCount42 ;
      private short RcdFound42 ;
      private short nBlankRcdUsr42 ;
      private short AV28Insert_NegCpjEndSeq ;
      private short A377NegCpjEndUFID ;
      private short RcdFound37 ;
      private short gxcookieaux ;
      private short GX_JID ;
      private short Z377NegCpjEndUFID ;
      private short nIsDirty_37 ;
      private short nIsDirty_42 ;
      private short subGridlevel_item_Backcolorstyle ;
      private short subGridlevel_item_Backstyle ;
      private short gxajaxcallmode ;
      private short subGridlevel_item_Allowselection ;
      private short subGridlevel_item_Allowhovering ;
      private short subGridlevel_item_Allowcollapsing ;
      private short subGridlevel_item_Collapsed ;
      private int Z454NegUltItem ;
      private int O454NegUltItem ;
      private int nRC_GXsfl_73 ;
      private int nGXsfl_73_idx=1 ;
      private int Z435NgpItem ;
      private int Z446NgpQtde ;
      private int A357NegPjtID ;
      private int trnEnded ;
      private int A454NegUltItem ;
      private int edtNegCodigo_Enabled ;
      private int edtNegCliID_Visible ;
      private int edtNegCliID_Enabled ;
      private int edtNegCpjID_Visible ;
      private int edtNegCpjID_Enabled ;
      private int edtNegCpjEndSeq_Visible ;
      private int edtNegCpjEndSeq_Enabled ;
      private int edtNegAssunto_Enabled ;
      private int edtNegValorEstimado_Enabled ;
      private int Negdescricao_Color ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int edtavCombonegcliid_Visible ;
      private int edtavCombonegcliid_Enabled ;
      private int edtavCombonegcpjid_Visible ;
      private int edtavCombonegcpjid_Enabled ;
      private int edtavCombonegcpjendseq_Enabled ;
      private int edtavCombonegcpjendseq_Visible ;
      private int B454NegUltItem ;
      private int edtNgpItem_Enabled ;
      private int edtNgpTppID_Enabled ;
      private int edtNgpTpp1Preco_Enabled ;
      private int edtNgpPreco_Enabled ;
      private int edtNgpQtde_Enabled ;
      private int edtNgpTotal_Enabled ;
      private int fRowAdded ;
      private int A642NegCpjEndCep ;
      private int A375NegCpjEndMunID ;
      private int A442NgpTppPrdTipoID ;
      private int Combo_negcliid_Datalistupdateminimumcharacters ;
      private int Combo_negcliid_Gxcontroltype ;
      private int Combo_negcpjid_Datalistupdateminimumcharacters ;
      private int Combo_negcpjid_Gxcontroltype ;
      private int Combo_negcpjendseq_Datalistupdateminimumcharacters ;
      private int Combo_negcpjendseq_Gxcontroltype ;
      private int Negdescricao_Coltitlecolor ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int Combo_ngptppid_Datalistupdateminimumcharacters ;
      private int Combo_ngptppid_Gxcontroltype ;
      private int s454NegUltItem ;
      private int A435NgpItem ;
      private int A446NgpQtde ;
      private int AV50GXV1 ;
      private int Z357NegPjtID ;
      private int Z642NegCpjEndCep ;
      private int Z375NegCpjEndMunID ;
      private int Z442NgpTppPrdTipoID ;
      private int subGridlevel_item_Backcolor ;
      private int subGridlevel_item_Allbackcolor ;
      private int defedtNgpItem_Enabled ;
      private int i454NegUltItem ;
      private int i446NgpQtde ;
      private int idxLst ;
      private int subGridlevel_item_Selectedindex ;
      private int subGridlevel_item_Selectioncolor ;
      private int subGridlevel_item_Hoveringcolor ;
      private int gxdynajaxindex ;
      private int GXt_int4 ;
      private long Z356NegCodigo ;
      private long A356NegCodigo ;
      private long A473NegCliMatricula ;
      private long A355NegCpjMatricula ;
      private long GRIDLEVEL_ITEM_nFirstRecordOnPage ;
      private long Z473NegCliMatricula ;
      private long Z355NegCpjMatricula ;
      private decimal Z385NegValorAtualizado ;
      private decimal Z380NegValorEstimado ;
      private decimal O448NegPgpTotal ;
      private decimal Z447NgpTotal ;
      private decimal Z445NgpPreco ;
      private decimal O447NgpTotal ;
      private decimal A380NegValorEstimado ;
      private decimal B448NegPgpTotal ;
      private decimal A448NegPgpTotal ;
      private decimal A385NegValorAtualizado ;
      private decimal s448NegPgpTotal ;
      private decimal s380NegValorEstimado ;
      private decimal O380NegValorEstimado ;
      private decimal s385NegValorAtualizado ;
      private decimal O385NegValorAtualizado ;
      private decimal A444NgpTpp1Preco ;
      private decimal A445NgpPreco ;
      private decimal A447NgpTotal ;
      private decimal T447NgpTotal ;
      private decimal Z448NegPgpTotal ;
      private decimal Z444NgpTpp1Preco ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z349NegInsUsuID ;
      private string Z576NegDelUsuId ;
      private string Z360NegAgcID ;
      private string Combo_negcpjendseq_Selectedvalue_get ;
      private string Combo_negcpjid_Selectedvalue_get ;
      private string Combo_negcliid_Selectedvalue_get ;
      private string Z458NgpInsUsuID ;
      private string Z582NgpDelUsuId ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string GXDecQS ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtNegCliID_Internalname ;
      private string sGXsfl_73_idx="0001" ;
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
      private string edtNegCodigo_Internalname ;
      private string edtNegCodigo_Jsonclick ;
      private string divTablesplittednegcliid_Internalname ;
      private string lblTextblocknegcliid_Internalname ;
      private string lblTextblocknegcliid_Jsonclick ;
      private string Combo_negcliid_Caption ;
      private string Combo_negcliid_Cls ;
      private string Combo_negcliid_Emptyitemtext ;
      private string Combo_negcliid_Internalname ;
      private string TempTags ;
      private string edtNegCliID_Jsonclick ;
      private string divTablesplittednegcpjid_Internalname ;
      private string lblTextblocknegcpjid_Internalname ;
      private string lblTextblocknegcpjid_Jsonclick ;
      private string Combo_negcpjid_Caption ;
      private string Combo_negcpjid_Cls ;
      private string Combo_negcpjid_Datalistproc ;
      private string Combo_negcpjid_Emptyitemtext ;
      private string Combo_negcpjid_Internalname ;
      private string edtNegCpjID_Internalname ;
      private string edtNegCpjID_Jsonclick ;
      private string divTablesplittednegcpjendseq_Internalname ;
      private string lblTextblocknegcpjendseq_Internalname ;
      private string lblTextblocknegcpjendseq_Jsonclick ;
      private string Combo_negcpjendseq_Caption ;
      private string Combo_negcpjendseq_Cls ;
      private string Combo_negcpjendseq_Datalistproc ;
      private string Combo_negcpjendseq_Emptyitemtext ;
      private string Combo_negcpjendseq_Internalname ;
      private string edtNegCpjEndSeq_Internalname ;
      private string edtNegCpjEndSeq_Jsonclick ;
      private string edtNegAssunto_Internalname ;
      private string edtNegAssunto_Jsonclick ;
      private string edtNegValorEstimado_Internalname ;
      private string edtNegValorEstimado_Jsonclick ;
      private string Negdescricao_Width ;
      private string Negdescricao_Height ;
      private string Negdescricao_Skin ;
      private string Negdescricao_Toolbar ;
      private string Negdescricao_Captionclass ;
      private string Negdescricao_Captionstyle ;
      private string Negdescricao_Captionposition ;
      private string Negdescricao_Internalname ;
      private string divTableleaflevel_item_Internalname ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_negcliid_Internalname ;
      private string edtavCombonegcliid_Internalname ;
      private string edtavCombonegcliid_Jsonclick ;
      private string divSectionattribute_negcpjid_Internalname ;
      private string edtavCombonegcpjid_Internalname ;
      private string edtavCombonegcpjid_Jsonclick ;
      private string divSectionattribute_negcpjendseq_Internalname ;
      private string edtavCombonegcpjendseq_Internalname ;
      private string edtavCombonegcpjendseq_Jsonclick ;
      private string Combo_ngptppid_Caption ;
      private string Combo_ngptppid_Cls ;
      private string Combo_ngptppid_Emptyitemtext ;
      private string Combo_ngptppid_Internalname ;
      private string sMode42 ;
      private string edtNgpItem_Internalname ;
      private string edtNgpTppID_Internalname ;
      private string dynNgpTppPrdID_Internalname ;
      private string edtNgpTpp1Preco_Internalname ;
      private string edtNgpPreco_Internalname ;
      private string edtNgpQtde_Internalname ;
      private string edtNgpTotal_Internalname ;
      private string sStyleString ;
      private string subGridlevel_item_Internalname ;
      private string A349NegInsUsuID ;
      private string A576NegDelUsuId ;
      private string A360NegAgcID ;
      private string AV49Pgmname ;
      private string A458NgpInsUsuID ;
      private string A582NgpDelUsuId ;
      private string Combo_negcliid_Objectcall ;
      private string Combo_negcliid_Class ;
      private string Combo_negcliid_Icontype ;
      private string Combo_negcliid_Icon ;
      private string Combo_negcliid_Tooltip ;
      private string Combo_negcliid_Selectedvalue_set ;
      private string Combo_negcliid_Selectedtext_set ;
      private string Combo_negcliid_Selectedtext_get ;
      private string Combo_negcliid_Gamoauthtoken ;
      private string Combo_negcliid_Ddointernalname ;
      private string Combo_negcliid_Titlecontrolalign ;
      private string Combo_negcliid_Dropdownoptionstype ;
      private string Combo_negcliid_Titlecontrolidtoreplace ;
      private string Combo_negcliid_Datalisttype ;
      private string Combo_negcliid_Datalistfixedvalues ;
      private string Combo_negcliid_Datalistproc ;
      private string Combo_negcliid_Datalistprocparametersprefix ;
      private string Combo_negcliid_Remoteservicesparameters ;
      private string Combo_negcliid_Htmltemplate ;
      private string Combo_negcliid_Multiplevaluestype ;
      private string Combo_negcliid_Loadingdata ;
      private string Combo_negcliid_Noresultsfound ;
      private string Combo_negcliid_Onlyselectedvalues ;
      private string Combo_negcliid_Selectalltext ;
      private string Combo_negcliid_Multiplevaluesseparator ;
      private string Combo_negcliid_Addnewoptiontext ;
      private string Combo_negcpjid_Objectcall ;
      private string Combo_negcpjid_Class ;
      private string Combo_negcpjid_Icontype ;
      private string Combo_negcpjid_Icon ;
      private string Combo_negcpjid_Tooltip ;
      private string Combo_negcpjid_Selectedvalue_set ;
      private string Combo_negcpjid_Selectedtext_set ;
      private string Combo_negcpjid_Selectedtext_get ;
      private string Combo_negcpjid_Gamoauthtoken ;
      private string Combo_negcpjid_Ddointernalname ;
      private string Combo_negcpjid_Titlecontrolalign ;
      private string Combo_negcpjid_Dropdownoptionstype ;
      private string Combo_negcpjid_Titlecontrolidtoreplace ;
      private string Combo_negcpjid_Datalisttype ;
      private string Combo_negcpjid_Datalistfixedvalues ;
      private string Combo_negcpjid_Datalistprocparametersprefix ;
      private string Combo_negcpjid_Remoteservicesparameters ;
      private string Combo_negcpjid_Htmltemplate ;
      private string Combo_negcpjid_Multiplevaluestype ;
      private string Combo_negcpjid_Loadingdata ;
      private string Combo_negcpjid_Noresultsfound ;
      private string Combo_negcpjid_Onlyselectedvalues ;
      private string Combo_negcpjid_Selectalltext ;
      private string Combo_negcpjid_Multiplevaluesseparator ;
      private string Combo_negcpjid_Addnewoptiontext ;
      private string Combo_negcpjendseq_Objectcall ;
      private string Combo_negcpjendseq_Class ;
      private string Combo_negcpjendseq_Icontype ;
      private string Combo_negcpjendseq_Icon ;
      private string Combo_negcpjendseq_Tooltip ;
      private string Combo_negcpjendseq_Selectedvalue_set ;
      private string Combo_negcpjendseq_Selectedtext_set ;
      private string Combo_negcpjendseq_Selectedtext_get ;
      private string Combo_negcpjendseq_Gamoauthtoken ;
      private string Combo_negcpjendseq_Ddointernalname ;
      private string Combo_negcpjendseq_Titlecontrolalign ;
      private string Combo_negcpjendseq_Dropdownoptionstype ;
      private string Combo_negcpjendseq_Titlecontrolidtoreplace ;
      private string Combo_negcpjendseq_Datalisttype ;
      private string Combo_negcpjendseq_Datalistfixedvalues ;
      private string Combo_negcpjendseq_Datalistprocparametersprefix ;
      private string Combo_negcpjendseq_Remoteservicesparameters ;
      private string Combo_negcpjendseq_Htmltemplate ;
      private string Combo_negcpjendseq_Multiplevaluestype ;
      private string Combo_negcpjendseq_Loadingdata ;
      private string Combo_negcpjendseq_Noresultsfound ;
      private string Combo_negcpjendseq_Onlyselectedvalues ;
      private string Combo_negcpjendseq_Selectalltext ;
      private string Combo_negcpjendseq_Multiplevaluesseparator ;
      private string Combo_negcpjendseq_Addnewoptiontext ;
      private string Negdescricao_Objectcall ;
      private string Negdescricao_Class ;
      private string Negdescricao_Customtoolbar ;
      private string Negdescricao_Customconfiguration ;
      private string Negdescricao_Buttonpressedid ;
      private string Negdescricao_Captionvalue ;
      private string Negdescricao_Coltitle ;
      private string Negdescricao_Coltitlefont ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Combo_ngptppid_Objectcall ;
      private string Combo_ngptppid_Class ;
      private string Combo_ngptppid_Icontype ;
      private string Combo_ngptppid_Icon ;
      private string Combo_ngptppid_Tooltip ;
      private string Combo_ngptppid_Selectedvalue_set ;
      private string Combo_ngptppid_Selectedvalue_get ;
      private string Combo_ngptppid_Selectedtext_set ;
      private string Combo_ngptppid_Selectedtext_get ;
      private string Combo_ngptppid_Gamoauthtoken ;
      private string Combo_ngptppid_Ddointernalname ;
      private string Combo_ngptppid_Titlecontrolalign ;
      private string Combo_ngptppid_Dropdownoptionstype ;
      private string Combo_ngptppid_Titlecontrolidtoreplace ;
      private string Combo_ngptppid_Datalisttype ;
      private string Combo_ngptppid_Datalistfixedvalues ;
      private string Combo_ngptppid_Datalistproc ;
      private string Combo_ngptppid_Datalistprocparametersprefix ;
      private string Combo_ngptppid_Remoteservicesparameters ;
      private string Combo_ngptppid_Htmltemplate ;
      private string Combo_ngptppid_Multiplevaluestype ;
      private string Combo_ngptppid_Loadingdata ;
      private string Combo_ngptppid_Noresultsfound ;
      private string Combo_ngptppid_Onlyselectedvalues ;
      private string Combo_ngptppid_Selectalltext ;
      private string Combo_ngptppid_Multiplevaluesseparator ;
      private string Combo_ngptppid_Addnewoptiontext ;
      private string hsh ;
      private string sMode37 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXEncryptionTmp ;
      private string GXt_char2 ;
      private string GXCCtl ;
      private string sGXsfl_73_fel_idx="0001" ;
      private string subGridlevel_item_Class ;
      private string subGridlevel_item_Linesclass ;
      private string ROClassString ;
      private string edtNgpItem_Jsonclick ;
      private string edtNgpTppID_Jsonclick ;
      private string dynNgpTppPrdID_Jsonclick ;
      private string edtNgpTpp1Preco_Jsonclick ;
      private string edtNgpPreco_Jsonclick ;
      private string edtNgpQtde_Jsonclick ;
      private string edtNgpTotal_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string subGridlevel_item_Header ;
      private string gxwrpcisep ;
      private DateTime Z348NegInsDataHora ;
      private DateTime Z347NegInsHora ;
      private DateTime Z573NegDelDataHora ;
      private DateTime Z574NegDelData ;
      private DateTime Z575NegDelHora ;
      private DateTime Z457NgpInsDataHora ;
      private DateTime Z456NgpInsHora ;
      private DateTime Z579NgpDelDataHora ;
      private DateTime Z580NgpDelData ;
      private DateTime Z581NgpDelHora ;
      private DateTime A573NegDelDataHora ;
      private DateTime A574NegDelData ;
      private DateTime A575NegDelHora ;
      private DateTime A348NegInsDataHora ;
      private DateTime A347NegInsHora ;
      private DateTime A457NgpInsDataHora ;
      private DateTime A456NgpInsHora ;
      private DateTime A579NgpDelDataHora ;
      private DateTime A580NgpDelData ;
      private DateTime A581NgpDelHora ;
      private DateTime Z346NegInsData ;
      private DateTime Z455NgpInsData ;
      private DateTime A346NegInsData ;
      private DateTime A455NgpInsData ;
      private bool Z572NegDel ;
      private bool O572NegDel ;
      private bool Z578NgpDel ;
      private bool O578NgpDel ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n454NegUltItem ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool Combo_negcliid_Includeaddnewoption ;
      private bool Combo_negcpjid_Includeaddnewoption ;
      private bool Combo_negcpjendseq_Includeaddnewoption ;
      private bool Negdescricao_Toolbarcancollapse ;
      private bool Combo_ngptppid_Isgriditem ;
      private bool n448NegPgpTotal ;
      private bool B572NegDel ;
      private bool A572NegDel ;
      private bool bGXsfl_73_Refreshing=false ;
      private bool n349NegInsUsuID ;
      private bool n364NegInsUsuNome ;
      private bool n573NegDelDataHora ;
      private bool n574NegDelData ;
      private bool n575NegDelHora ;
      private bool n576NegDelUsuId ;
      private bool n577NegDelUsuNome ;
      private bool n360NegAgcID ;
      private bool n361NegAgcNome ;
      private bool n373NegCpjEndComplem ;
      private bool n458NgpInsUsuID ;
      private bool n459NgpInsUsuNome ;
      private bool A578NgpDel ;
      private bool n579NgpDelDataHora ;
      private bool n580NgpDelData ;
      private bool n581NgpDelHora ;
      private bool n582NgpDelUsuId ;
      private bool n583NgpDelUsuNome ;
      private bool A443NgpTppPrdAtivo ;
      private bool Combo_negcliid_Enabled ;
      private bool Combo_negcliid_Visible ;
      private bool Combo_negcliid_Allowmultipleselection ;
      private bool Combo_negcliid_Isgriditem ;
      private bool Combo_negcliid_Hasdescription ;
      private bool Combo_negcliid_Includeonlyselectedoption ;
      private bool Combo_negcliid_Includeselectalloption ;
      private bool Combo_negcliid_Emptyitem ;
      private bool Combo_negcpjid_Enabled ;
      private bool Combo_negcpjid_Visible ;
      private bool Combo_negcpjid_Allowmultipleselection ;
      private bool Combo_negcpjid_Isgriditem ;
      private bool Combo_negcpjid_Hasdescription ;
      private bool Combo_negcpjid_Includeonlyselectedoption ;
      private bool Combo_negcpjid_Includeselectalloption ;
      private bool Combo_negcpjid_Emptyitem ;
      private bool Combo_negcpjendseq_Enabled ;
      private bool Combo_negcpjendseq_Visible ;
      private bool Combo_negcpjendseq_Allowmultipleselection ;
      private bool Combo_negcpjendseq_Isgriditem ;
      private bool Combo_negcpjendseq_Hasdescription ;
      private bool Combo_negcpjendseq_Includeonlyselectedoption ;
      private bool Combo_negcpjendseq_Includeselectalloption ;
      private bool Combo_negcpjendseq_Emptyitem ;
      private bool Negdescricao_Enabled ;
      private bool Negdescricao_Toolbarexpanded ;
      private bool Negdescricao_Isabstractlayoutcontrol ;
      private bool Negdescricao_Usercontroliscolumn ;
      private bool Negdescricao_Visible ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool Combo_ngptppid_Enabled ;
      private bool Combo_ngptppid_Visible ;
      private bool Combo_ngptppid_Allowmultipleselection ;
      private bool Combo_ngptppid_Hasdescription ;
      private bool Combo_ngptppid_Includeonlyselectedoption ;
      private bool Combo_ngptppid_Includeselectalloption ;
      private bool Combo_ngptppid_Emptyitem ;
      private bool Combo_ngptppid_Includeaddnewoption ;
      private bool T578NgpDel ;
      private bool returnInSub ;
      private bool GXt_boolean3 ;
      private bool Gx_longc ;
      private bool Z443NgpTppPrdAtivo ;
      private bool gxdyncontrolsrefreshing ;
      private string NegDescricao ;
      private string A363NegDescricao ;
      private string AV20Combo_DataJson ;
      private string Z363NegDescricao ;
      private string Z364NegInsUsuNome ;
      private string Z577NegDelUsuNome ;
      private string Z361NegAgcNome ;
      private string Z362NegAssunto ;
      private string Z459NgpInsUsuNome ;
      private string Z583NgpDelUsuNome ;
      private string Z453NgpObs ;
      private string A362NegAssunto ;
      private string A364NegInsUsuNome ;
      private string A577NegDelUsuNome ;
      private string A361NegAgcNome ;
      private string A371NegCpjEndEndereco ;
      private string A374NegCpjEndBairro ;
      private string A643NegCpjEndCepFormat ;
      private string A376NegCpjEndMunNome ;
      private string A378NegCpjEndUFSigla ;
      private string A372NegCpjEndNumero ;
      private string A373NegCpjEndComplem ;
      private string A641NegCpjEndCompleto ;
      private string A351NegCliNomeFamiliar ;
      private string A353NegCpjNomFan ;
      private string A354NegCpjRazSocial ;
      private string A370NegCpjEndNome ;
      private string A379NegCpjEndUFNome ;
      private string A358NegPjtSigla ;
      private string A359NegPjtNome ;
      private string A459NgpInsUsuNome ;
      private string A583NgpDelUsuNome ;
      private string A453NgpObs ;
      private string A440NgpTppPrdCodigo ;
      private string A441NgpTppPrdNome ;
      private string AV18ComboSelectedValue ;
      private string AV19ComboSelectedText ;
      private string Z351NegCliNomeFamiliar ;
      private string Z353NegCpjNomFan ;
      private string Z354NegCpjRazSocial ;
      private string Z359NegPjtNome ;
      private string Z358NegPjtSigla ;
      private string Z370NegCpjEndNome ;
      private string Z371NegCpjEndEndereco ;
      private string Z372NegCpjEndNumero ;
      private string Z373NegCpjEndComplem ;
      private string Z374NegCpjEndBairro ;
      private string Z643NegCpjEndCepFormat ;
      private string Z376NegCpjEndMunNome ;
      private string Z378NegCpjEndUFSigla ;
      private string Z379NegCpjEndUFNome ;
      private string Z440NgpTppPrdCodigo ;
      private string Z441NgpTppPrdNome ;
      private string Z641NegCpjEndCompleto ;
      private Guid wcpOAV7NegID ;
      private Guid Z345NegID ;
      private Guid Z350NegCliID ;
      private Guid Z352NegCpjID ;
      private Guid N350NegCliID ;
      private Guid N352NegCpjID ;
      private Guid Z439NgpTppPrdID ;
      private Guid Z478NgpTppID ;
      private Guid A350NegCliID ;
      private Guid A352NegCpjID ;
      private Guid A478NgpTppID ;
      private Guid A439NgpTppPrdID ;
      private Guid AV7NegID ;
      private Guid AV41ComboNegCliID ;
      private Guid AV42ComboNegCpjID ;
      private Guid A345NegID ;
      private Guid AV13Insert_NegCliID ;
      private Guid AV14Insert_NegCpjID ;
      private Guid AV45Cond_NegCpjID ;
      private Guid AV43Cond_NegCliID ;
      private IGxSession AV12WebSession ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridlevel_itemContainer ;
      private GXWebRow Gridlevel_itemRow ;
      private GXWebColumn Gridlevel_itemColumn ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucCombo_negcliid ;
      private GXUserControl ucCombo_negcpjid ;
      private GXUserControl ucCombo_negcpjendseq ;
      private GXUserControl ucNegdescricao ;
      private GXUserControl ucCombo_ngptppid ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynNgpTppPrdID ;
      private IDataStoreProvider pr_default ;
      private decimal[] T000Y13_A448NegPgpTotal ;
      private bool[] T000Y13_n448NegPgpTotal ;
      private long[] T000Y8_A473NegCliMatricula ;
      private string[] T000Y8_A351NegCliNomeFamiliar ;
      private string[] T000Y9_A353NegCpjNomFan ;
      private string[] T000Y9_A354NegCpjRazSocial ;
      private long[] T000Y9_A355NegCpjMatricula ;
      private int[] T000Y9_A357NegPjtID ;
      private string[] T000Y11_A358NegPjtSigla ;
      private string[] T000Y11_A359NegPjtNome ;
      private string[] T000Y10_A370NegCpjEndNome ;
      private string[] T000Y10_A371NegCpjEndEndereco ;
      private string[] T000Y10_A372NegCpjEndNumero ;
      private string[] T000Y10_A373NegCpjEndComplem ;
      private bool[] T000Y10_n373NegCpjEndComplem ;
      private string[] T000Y10_A374NegCpjEndBairro ;
      private int[] T000Y10_A642NegCpjEndCep ;
      private string[] T000Y10_A643NegCpjEndCepFormat ;
      private int[] T000Y10_A375NegCpjEndMunID ;
      private string[] T000Y10_A376NegCpjEndMunNome ;
      private short[] T000Y10_A377NegCpjEndUFID ;
      private string[] T000Y10_A378NegCpjEndUFSigla ;
      private string[] T000Y10_A379NegCpjEndUFNome ;
      private Guid[] T000Y15_A345NegID ;
      private long[] T000Y15_A356NegCodigo ;
      private DateTime[] T000Y15_A348NegInsDataHora ;
      private DateTime[] T000Y15_A346NegInsData ;
      private DateTime[] T000Y15_A347NegInsHora ;
      private string[] T000Y15_A349NegInsUsuID ;
      private bool[] T000Y15_n349NegInsUsuID ;
      private string[] T000Y15_A364NegInsUsuNome ;
      private bool[] T000Y15_n364NegInsUsuNome ;
      private decimal[] T000Y15_A385NegValorAtualizado ;
      private decimal[] T000Y15_A380NegValorEstimado ;
      private DateTime[] T000Y15_A573NegDelDataHora ;
      private bool[] T000Y15_n573NegDelDataHora ;
      private DateTime[] T000Y15_A574NegDelData ;
      private bool[] T000Y15_n574NegDelData ;
      private DateTime[] T000Y15_A575NegDelHora ;
      private bool[] T000Y15_n575NegDelHora ;
      private string[] T000Y15_A576NegDelUsuId ;
      private bool[] T000Y15_n576NegDelUsuId ;
      private string[] T000Y15_A577NegDelUsuNome ;
      private bool[] T000Y15_n577NegDelUsuNome ;
      private long[] T000Y15_A473NegCliMatricula ;
      private string[] T000Y15_A351NegCliNomeFamiliar ;
      private string[] T000Y15_A353NegCpjNomFan ;
      private string[] T000Y15_A354NegCpjRazSocial ;
      private long[] T000Y15_A355NegCpjMatricula ;
      private string[] T000Y15_A358NegPjtSigla ;
      private string[] T000Y15_A359NegPjtNome ;
      private string[] T000Y15_A370NegCpjEndNome ;
      private string[] T000Y15_A371NegCpjEndEndereco ;
      private string[] T000Y15_A372NegCpjEndNumero ;
      private string[] T000Y15_A373NegCpjEndComplem ;
      private bool[] T000Y15_n373NegCpjEndComplem ;
      private string[] T000Y15_A374NegCpjEndBairro ;
      private int[] T000Y15_A642NegCpjEndCep ;
      private string[] T000Y15_A643NegCpjEndCepFormat ;
      private int[] T000Y15_A375NegCpjEndMunID ;
      private string[] T000Y15_A376NegCpjEndMunNome ;
      private short[] T000Y15_A377NegCpjEndUFID ;
      private string[] T000Y15_A378NegCpjEndUFSigla ;
      private string[] T000Y15_A379NegCpjEndUFNome ;
      private string[] T000Y15_A360NegAgcID ;
      private bool[] T000Y15_n360NegAgcID ;
      private string[] T000Y15_A361NegAgcNome ;
      private bool[] T000Y15_n361NegAgcNome ;
      private string[] T000Y15_A362NegAssunto ;
      private string[] T000Y15_A363NegDescricao ;
      private int[] T000Y15_A454NegUltItem ;
      private bool[] T000Y15_n454NegUltItem ;
      private bool[] T000Y15_A572NegDel ;
      private Guid[] T000Y15_A350NegCliID ;
      private Guid[] T000Y15_A352NegCpjID ;
      private short[] T000Y15_A369NegCpjEndSeq ;
      private int[] T000Y15_A357NegPjtID ;
      private decimal[] T000Y15_A448NegPgpTotal ;
      private bool[] T000Y15_n448NegPgpTotal ;
      private long[] T000Y16_A356NegCodigo ;
      private long[] T000Y17_A473NegCliMatricula ;
      private string[] T000Y17_A351NegCliNomeFamiliar ;
      private string[] T000Y18_A353NegCpjNomFan ;
      private string[] T000Y18_A354NegCpjRazSocial ;
      private long[] T000Y18_A355NegCpjMatricula ;
      private int[] T000Y18_A357NegPjtID ;
      private string[] T000Y19_A358NegPjtSigla ;
      private string[] T000Y19_A359NegPjtNome ;
      private string[] T000Y20_A370NegCpjEndNome ;
      private string[] T000Y20_A371NegCpjEndEndereco ;
      private string[] T000Y20_A372NegCpjEndNumero ;
      private string[] T000Y20_A373NegCpjEndComplem ;
      private bool[] T000Y20_n373NegCpjEndComplem ;
      private string[] T000Y20_A374NegCpjEndBairro ;
      private int[] T000Y20_A642NegCpjEndCep ;
      private string[] T000Y20_A643NegCpjEndCepFormat ;
      private int[] T000Y20_A375NegCpjEndMunID ;
      private string[] T000Y20_A376NegCpjEndMunNome ;
      private short[] T000Y20_A377NegCpjEndUFID ;
      private string[] T000Y20_A378NegCpjEndUFSigla ;
      private string[] T000Y20_A379NegCpjEndUFNome ;
      private Guid[] T000Y21_A345NegID ;
      private Guid[] T000Y7_A345NegID ;
      private long[] T000Y7_A356NegCodigo ;
      private DateTime[] T000Y7_A348NegInsDataHora ;
      private DateTime[] T000Y7_A346NegInsData ;
      private DateTime[] T000Y7_A347NegInsHora ;
      private string[] T000Y7_A349NegInsUsuID ;
      private bool[] T000Y7_n349NegInsUsuID ;
      private string[] T000Y7_A364NegInsUsuNome ;
      private bool[] T000Y7_n364NegInsUsuNome ;
      private decimal[] T000Y7_A385NegValorAtualizado ;
      private decimal[] T000Y7_A380NegValorEstimado ;
      private DateTime[] T000Y7_A573NegDelDataHora ;
      private bool[] T000Y7_n573NegDelDataHora ;
      private DateTime[] T000Y7_A574NegDelData ;
      private bool[] T000Y7_n574NegDelData ;
      private DateTime[] T000Y7_A575NegDelHora ;
      private bool[] T000Y7_n575NegDelHora ;
      private string[] T000Y7_A576NegDelUsuId ;
      private bool[] T000Y7_n576NegDelUsuId ;
      private string[] T000Y7_A577NegDelUsuNome ;
      private bool[] T000Y7_n577NegDelUsuNome ;
      private string[] T000Y7_A360NegAgcID ;
      private bool[] T000Y7_n360NegAgcID ;
      private string[] T000Y7_A361NegAgcNome ;
      private bool[] T000Y7_n361NegAgcNome ;
      private string[] T000Y7_A362NegAssunto ;
      private string[] T000Y7_A363NegDescricao ;
      private int[] T000Y7_A454NegUltItem ;
      private bool[] T000Y7_n454NegUltItem ;
      private bool[] T000Y7_A572NegDel ;
      private Guid[] T000Y7_A350NegCliID ;
      private Guid[] T000Y7_A352NegCpjID ;
      private short[] T000Y7_A369NegCpjEndSeq ;
      private string[] T000Y7_A351NegCliNomeFamiliar ;
      private string[] T000Y7_A353NegCpjNomFan ;
      private string[] T000Y7_A354NegCpjRazSocial ;
      private string[] T000Y7_A359NegPjtNome ;
      private Guid[] T000Y22_A345NegID ;
      private Guid[] T000Y23_A345NegID ;
      private Guid[] T000Y6_A345NegID ;
      private long[] T000Y6_A356NegCodigo ;
      private DateTime[] T000Y6_A348NegInsDataHora ;
      private DateTime[] T000Y6_A346NegInsData ;
      private DateTime[] T000Y6_A347NegInsHora ;
      private string[] T000Y6_A349NegInsUsuID ;
      private bool[] T000Y6_n349NegInsUsuID ;
      private string[] T000Y6_A364NegInsUsuNome ;
      private bool[] T000Y6_n364NegInsUsuNome ;
      private decimal[] T000Y6_A385NegValorAtualizado ;
      private decimal[] T000Y6_A380NegValorEstimado ;
      private DateTime[] T000Y6_A573NegDelDataHora ;
      private bool[] T000Y6_n573NegDelDataHora ;
      private DateTime[] T000Y6_A574NegDelData ;
      private bool[] T000Y6_n574NegDelData ;
      private DateTime[] T000Y6_A575NegDelHora ;
      private bool[] T000Y6_n575NegDelHora ;
      private string[] T000Y6_A576NegDelUsuId ;
      private bool[] T000Y6_n576NegDelUsuId ;
      private string[] T000Y6_A577NegDelUsuNome ;
      private bool[] T000Y6_n577NegDelUsuNome ;
      private string[] T000Y6_A360NegAgcID ;
      private bool[] T000Y6_n360NegAgcID ;
      private string[] T000Y6_A361NegAgcNome ;
      private bool[] T000Y6_n361NegAgcNome ;
      private string[] T000Y6_A362NegAssunto ;
      private string[] T000Y6_A363NegDescricao ;
      private int[] T000Y6_A454NegUltItem ;
      private bool[] T000Y6_n454NegUltItem ;
      private bool[] T000Y6_A572NegDel ;
      private Guid[] T000Y6_A350NegCliID ;
      private Guid[] T000Y6_A352NegCpjID ;
      private short[] T000Y6_A369NegCpjEndSeq ;
      private string[] T000Y6_A351NegCliNomeFamiliar ;
      private string[] T000Y6_A353NegCpjNomFan ;
      private string[] T000Y6_A354NegCpjRazSocial ;
      private string[] T000Y6_A359NegPjtNome ;
      private long[] T000Y27_A473NegCliMatricula ;
      private string[] T000Y27_A351NegCliNomeFamiliar ;
      private string[] T000Y28_A353NegCpjNomFan ;
      private string[] T000Y28_A354NegCpjRazSocial ;
      private long[] T000Y28_A355NegCpjMatricula ;
      private int[] T000Y28_A357NegPjtID ;
      private string[] T000Y29_A358NegPjtSigla ;
      private string[] T000Y29_A359NegPjtNome ;
      private string[] T000Y30_A370NegCpjEndNome ;
      private string[] T000Y30_A371NegCpjEndEndereco ;
      private string[] T000Y30_A372NegCpjEndNumero ;
      private string[] T000Y30_A373NegCpjEndComplem ;
      private bool[] T000Y30_n373NegCpjEndComplem ;
      private string[] T000Y30_A374NegCpjEndBairro ;
      private int[] T000Y30_A642NegCpjEndCep ;
      private string[] T000Y30_A643NegCpjEndCepFormat ;
      private int[] T000Y30_A375NegCpjEndMunID ;
      private string[] T000Y30_A376NegCpjEndMunNome ;
      private short[] T000Y30_A377NegCpjEndUFID ;
      private string[] T000Y30_A378NegCpjEndUFSigla ;
      private string[] T000Y30_A379NegCpjEndUFNome ;
      private Guid[] T000Y31_A398VisID ;
      private Guid[] T000Y32_A345NegID ;
      private string[] T000Y32_A626NefChave ;
      private Guid[] T000Y33_A345NegID ;
      private int[] T000Y33_A387NgfSeq ;
      private Guid[] T000Y35_A345NegID ;
      private string[] T000Y4_A440NgpTppPrdCodigo ;
      private string[] T000Y4_A441NgpTppPrdNome ;
      private bool[] T000Y4_A443NgpTppPrdAtivo ;
      private int[] T000Y4_A442NgpTppPrdTipoID ;
      private decimal[] T000Y36_A447NgpTotal ;
      private Guid[] T000Y36_A345NegID ;
      private int[] T000Y36_A435NgpItem ;
      private int[] T000Y36_A446NgpQtde ;
      private decimal[] T000Y36_A445NgpPreco ;
      private DateTime[] T000Y36_A457NgpInsDataHora ;
      private DateTime[] T000Y36_A455NgpInsData ;
      private DateTime[] T000Y36_A456NgpInsHora ;
      private string[] T000Y36_A458NgpInsUsuID ;
      private bool[] T000Y36_n458NgpInsUsuID ;
      private string[] T000Y36_A459NgpInsUsuNome ;
      private bool[] T000Y36_n459NgpInsUsuNome ;
      private DateTime[] T000Y36_A579NgpDelDataHora ;
      private bool[] T000Y36_n579NgpDelDataHora ;
      private DateTime[] T000Y36_A580NgpDelData ;
      private bool[] T000Y36_n580NgpDelData ;
      private DateTime[] T000Y36_A581NgpDelHora ;
      private bool[] T000Y36_n581NgpDelHora ;
      private string[] T000Y36_A582NgpDelUsuId ;
      private bool[] T000Y36_n582NgpDelUsuId ;
      private string[] T000Y36_A583NgpDelUsuNome ;
      private bool[] T000Y36_n583NgpDelUsuNome ;
      private string[] T000Y36_A440NgpTppPrdCodigo ;
      private string[] T000Y36_A441NgpTppPrdNome ;
      private bool[] T000Y36_A443NgpTppPrdAtivo ;
      private decimal[] T000Y36_A444NgpTpp1Preco ;
      private string[] T000Y36_A453NgpObs ;
      private bool[] T000Y36_A578NgpDel ;
      private Guid[] T000Y36_A439NgpTppPrdID ;
      private Guid[] T000Y36_A478NgpTppID ;
      private int[] T000Y36_A442NgpTppPrdTipoID ;
      private decimal[] T000Y5_A444NgpTpp1Preco ;
      private decimal[] T000Y37_A444NgpTpp1Preco ;
      private string[] T000Y38_A440NgpTppPrdCodigo ;
      private string[] T000Y38_A441NgpTppPrdNome ;
      private bool[] T000Y38_A443NgpTppPrdAtivo ;
      private int[] T000Y38_A442NgpTppPrdTipoID ;
      private Guid[] T000Y39_A345NegID ;
      private int[] T000Y39_A435NgpItem ;
      private decimal[] T000Y3_A447NgpTotal ;
      private Guid[] T000Y3_A345NegID ;
      private int[] T000Y3_A435NgpItem ;
      private int[] T000Y3_A446NgpQtde ;
      private decimal[] T000Y3_A445NgpPreco ;
      private DateTime[] T000Y3_A457NgpInsDataHora ;
      private DateTime[] T000Y3_A455NgpInsData ;
      private DateTime[] T000Y3_A456NgpInsHora ;
      private string[] T000Y3_A458NgpInsUsuID ;
      private bool[] T000Y3_n458NgpInsUsuID ;
      private string[] T000Y3_A459NgpInsUsuNome ;
      private bool[] T000Y3_n459NgpInsUsuNome ;
      private DateTime[] T000Y3_A579NgpDelDataHora ;
      private bool[] T000Y3_n579NgpDelDataHora ;
      private DateTime[] T000Y3_A580NgpDelData ;
      private bool[] T000Y3_n580NgpDelData ;
      private DateTime[] T000Y3_A581NgpDelHora ;
      private bool[] T000Y3_n581NgpDelHora ;
      private string[] T000Y3_A582NgpDelUsuId ;
      private bool[] T000Y3_n582NgpDelUsuId ;
      private string[] T000Y3_A583NgpDelUsuNome ;
      private bool[] T000Y3_n583NgpDelUsuNome ;
      private string[] T000Y3_A453NgpObs ;
      private bool[] T000Y3_A578NgpDel ;
      private Guid[] T000Y3_A439NgpTppPrdID ;
      private Guid[] T000Y3_A478NgpTppID ;
      private decimal[] T000Y2_A447NgpTotal ;
      private Guid[] T000Y2_A345NegID ;
      private int[] T000Y2_A435NgpItem ;
      private int[] T000Y2_A446NgpQtde ;
      private decimal[] T000Y2_A445NgpPreco ;
      private DateTime[] T000Y2_A457NgpInsDataHora ;
      private DateTime[] T000Y2_A455NgpInsData ;
      private DateTime[] T000Y2_A456NgpInsHora ;
      private string[] T000Y2_A458NgpInsUsuID ;
      private bool[] T000Y2_n458NgpInsUsuID ;
      private string[] T000Y2_A459NgpInsUsuNome ;
      private bool[] T000Y2_n459NgpInsUsuNome ;
      private DateTime[] T000Y2_A579NgpDelDataHora ;
      private bool[] T000Y2_n579NgpDelDataHora ;
      private DateTime[] T000Y2_A580NgpDelData ;
      private bool[] T000Y2_n580NgpDelData ;
      private DateTime[] T000Y2_A581NgpDelHora ;
      private bool[] T000Y2_n581NgpDelHora ;
      private string[] T000Y2_A582NgpDelUsuId ;
      private bool[] T000Y2_n582NgpDelUsuId ;
      private string[] T000Y2_A583NgpDelUsuNome ;
      private bool[] T000Y2_n583NgpDelUsuNome ;
      private string[] T000Y2_A453NgpObs ;
      private bool[] T000Y2_A578NgpDel ;
      private Guid[] T000Y2_A439NgpTppPrdID ;
      private Guid[] T000Y2_A478NgpTppID ;
      private string[] T000Y43_A440NgpTppPrdCodigo ;
      private string[] T000Y43_A441NgpTppPrdNome ;
      private bool[] T000Y43_A443NgpTppPrdAtivo ;
      private int[] T000Y43_A442NgpTppPrdTipoID ;
      private decimal[] T000Y44_A444NgpTpp1Preco ;
      private Guid[] T000Y45_A345NegID ;
      private int[] T000Y45_A435NgpItem ;
      private Guid[] T000Y46_A220PrdID ;
      private string[] T000Y46_A222PrdNome ;
      private bool[] T000Y46_A231PrdAtivo ;
      private bool[] T000Y46_A620PrdDel ;
      private long[] T000Y47_A356NegCodigo ;
      private string[] T000Y48_A440NgpTppPrdCodigo ;
      private string[] T000Y48_A441NgpTppPrdNome ;
      private bool[] T000Y48_A443NgpTppPrdAtivo ;
      private int[] T000Y48_A442NgpTppPrdTipoID ;
      private decimal[] T000Y49_A444NgpTpp1Preco ;
      private IDataStoreProvider pr_gam ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV24GAMErrors ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV16NegCliID_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV25NegCpjID_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV29NegCpjEndSeq_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV40NgpTppID_Data ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV17DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV23GAMSession ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV15TrnContextAtt ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV47AuditingObject ;
   }

   public class negociopj__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class negociopj__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new ForEachCursor(def[18])
       ,new ForEachCursor(def[19])
       ,new UpdateCursor(def[20])
       ,new UpdateCursor(def[21])
       ,new UpdateCursor(def[22])
       ,new ForEachCursor(def[23])
       ,new ForEachCursor(def[24])
       ,new ForEachCursor(def[25])
       ,new ForEachCursor(def[26])
       ,new ForEachCursor(def[27])
       ,new ForEachCursor(def[28])
       ,new ForEachCursor(def[29])
       ,new UpdateCursor(def[30])
       ,new ForEachCursor(def[31])
       ,new ForEachCursor(def[32])
       ,new ForEachCursor(def[33])
       ,new ForEachCursor(def[34])
       ,new ForEachCursor(def[35])
       ,new UpdateCursor(def[36])
       ,new UpdateCursor(def[37])
       ,new UpdateCursor(def[38])
       ,new ForEachCursor(def[39])
       ,new ForEachCursor(def[40])
       ,new ForEachCursor(def[41])
       ,new ForEachCursor(def[42])
       ,new ForEachCursor(def[43])
       ,new ForEachCursor(def[44])
       ,new ForEachCursor(def[45])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT000Y13;
        prmT000Y13 = new Object[] {
        new ParDef("NegID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Y15;
        prmT000Y15 = new Object[] {
        new ParDef("NegID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Y8;
        prmT000Y8 = new Object[] {
        new ParDef("NegCliID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Y9;
        prmT000Y9 = new Object[] {
        new ParDef("NegCliID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NegCpjID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Y11;
        prmT000Y11 = new Object[] {
        new ParDef("NegPjtID",GXType.Int32,9,0)
        };
        Object[] prmT000Y10;
        prmT000Y10 = new Object[] {
        new ParDef("NegCliID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NegCpjID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NegCpjEndSeq",GXType.Int16,4,0)
        };
        Object[] prmT000Y16;
        prmT000Y16 = new Object[] {
        new ParDef("NegCodigo",GXType.Int64,12,0) ,
        new ParDef("NegID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Y17;
        prmT000Y17 = new Object[] {
        new ParDef("NegCliID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Y18;
        prmT000Y18 = new Object[] {
        new ParDef("NegCliID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NegCpjID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Y19;
        prmT000Y19 = new Object[] {
        new ParDef("NegPjtID",GXType.Int32,9,0)
        };
        Object[] prmT000Y20;
        prmT000Y20 = new Object[] {
        new ParDef("NegCliID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NegCpjID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NegCpjEndSeq",GXType.Int16,4,0)
        };
        Object[] prmT000Y21;
        prmT000Y21 = new Object[] {
        new ParDef("NegID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Y7;
        prmT000Y7 = new Object[] {
        new ParDef("NegID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Y22;
        prmT000Y22 = new Object[] {
        new ParDef("NegID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Y23;
        prmT000Y23 = new Object[] {
        new ParDef("NegID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Y6;
        prmT000Y6 = new Object[] {
        new ParDef("NegID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Y24;
        prmT000Y24 = new Object[] {
        new ParDef("NegCliNomeFamiliar",GXType.VarChar,80,0) ,
        new ParDef("NegCpjNomFan",GXType.VarChar,80,0) ,
        new ParDef("NegCpjRazSocial",GXType.VarChar,80,0) ,
        new ParDef("NegPjtNome",GXType.VarChar,80,0) ,
        new ParDef("NegID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NegCodigo",GXType.Int64,12,0) ,
        new ParDef("NegInsDataHora",GXType.DateTime2,10,12) ,
        new ParDef("NegInsData",GXType.Date,8,0) ,
        new ParDef("NegInsHora",GXType.DateTime,0,5) ,
        new ParDef("NegInsUsuID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("NegInsUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("NegValorAtualizado",GXType.Number,16,2) ,
        new ParDef("NegValorEstimado",GXType.Number,16,2) ,
        new ParDef("NegDelDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("NegDelData",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("NegDelHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("NegDelUsuId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("NegDelUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("NegAgcID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("NegAgcNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("NegAssunto",GXType.VarChar,80,0) ,
        new ParDef("NegDescricao",GXType.LongVarChar,2097152,0) ,
        new ParDef("NegUltItem",GXType.Int32,8,0){Nullable=true} ,
        new ParDef("NegDel",GXType.Boolean,4,0) ,
        new ParDef("NegCliID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NegCpjID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NegCpjEndSeq",GXType.Int16,4,0)
        };
        Object[] prmT000Y25;
        prmT000Y25 = new Object[] {
        new ParDef("NegCliNomeFamiliar",GXType.VarChar,80,0) ,
        new ParDef("NegCpjNomFan",GXType.VarChar,80,0) ,
        new ParDef("NegCpjRazSocial",GXType.VarChar,80,0) ,
        new ParDef("NegPjtNome",GXType.VarChar,80,0) ,
        new ParDef("NegCodigo",GXType.Int64,12,0) ,
        new ParDef("NegInsDataHora",GXType.DateTime2,10,12) ,
        new ParDef("NegInsData",GXType.Date,8,0) ,
        new ParDef("NegInsHora",GXType.DateTime,0,5) ,
        new ParDef("NegInsUsuID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("NegInsUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("NegValorAtualizado",GXType.Number,16,2) ,
        new ParDef("NegValorEstimado",GXType.Number,16,2) ,
        new ParDef("NegDelDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("NegDelData",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("NegDelHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("NegDelUsuId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("NegDelUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("NegAgcID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("NegAgcNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("NegAssunto",GXType.VarChar,80,0) ,
        new ParDef("NegDescricao",GXType.LongVarChar,2097152,0) ,
        new ParDef("NegUltItem",GXType.Int32,8,0){Nullable=true} ,
        new ParDef("NegDel",GXType.Boolean,4,0) ,
        new ParDef("NegCliID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NegCpjID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NegCpjEndSeq",GXType.Int16,4,0) ,
        new ParDef("NegID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Y26;
        prmT000Y26 = new Object[] {
        new ParDef("NegID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Y31;
        prmT000Y31 = new Object[] {
        new ParDef("NegID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Y32;
        prmT000Y32 = new Object[] {
        new ParDef("NegID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Y33;
        prmT000Y33 = new Object[] {
        new ParDef("NegID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Y34;
        prmT000Y34 = new Object[] {
        new ParDef("NegUltItem",GXType.Int32,8,0){Nullable=true} ,
        new ParDef("NegValorEstimado",GXType.Number,16,2) ,
        new ParDef("NegValorAtualizado",GXType.Number,16,2) ,
        new ParDef("NegID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Y35;
        prmT000Y35 = new Object[] {
        };
        Object[] prmT000Y36;
        prmT000Y36 = new Object[] {
        new ParDef("NegID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NgpItem",GXType.Int32,8,0)
        };
        Object[] prmT000Y5;
        prmT000Y5 = new Object[] {
        new ParDef("NgpTppID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NgpTppPrdID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Y4;
        prmT000Y4 = new Object[] {
        new ParDef("NgpTppPrdID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Y37;
        prmT000Y37 = new Object[] {
        new ParDef("NgpTppID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NgpTppPrdID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Y38;
        prmT000Y38 = new Object[] {
        new ParDef("NgpTppPrdID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Y39;
        prmT000Y39 = new Object[] {
        new ParDef("NegID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NgpItem",GXType.Int32,8,0)
        };
        Object[] prmT000Y3;
        prmT000Y3 = new Object[] {
        new ParDef("NegID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NgpItem",GXType.Int32,8,0)
        };
        Object[] prmT000Y2;
        prmT000Y2 = new Object[] {
        new ParDef("NegID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NgpItem",GXType.Int32,8,0)
        };
        Object[] prmT000Y40;
        prmT000Y40 = new Object[] {
        new ParDef("NgpTotal",GXType.Number,16,2) ,
        new ParDef("NegID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NgpItem",GXType.Int32,8,0) ,
        new ParDef("NgpQtde",GXType.Int32,8,0) ,
        new ParDef("NgpPreco",GXType.Number,16,2) ,
        new ParDef("NgpInsDataHora",GXType.DateTime2,10,12) ,
        new ParDef("NgpInsData",GXType.Date,8,0) ,
        new ParDef("NgpInsHora",GXType.DateTime,0,5) ,
        new ParDef("NgpInsUsuID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("NgpInsUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("NgpDelDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("NgpDelData",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("NgpDelHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("NgpDelUsuId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("NgpDelUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("NgpObs",GXType.VarChar,1000,0) ,
        new ParDef("NgpDel",GXType.Boolean,4,0) ,
        new ParDef("NgpTppPrdID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NgpTppID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Y41;
        prmT000Y41 = new Object[] {
        new ParDef("NgpTotal",GXType.Number,16,2) ,
        new ParDef("NgpQtde",GXType.Int32,8,0) ,
        new ParDef("NgpPreco",GXType.Number,16,2) ,
        new ParDef("NgpInsDataHora",GXType.DateTime2,10,12) ,
        new ParDef("NgpInsData",GXType.Date,8,0) ,
        new ParDef("NgpInsHora",GXType.DateTime,0,5) ,
        new ParDef("NgpInsUsuID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("NgpInsUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("NgpDelDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("NgpDelData",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("NgpDelHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("NgpDelUsuId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("NgpDelUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("NgpObs",GXType.VarChar,1000,0) ,
        new ParDef("NgpDel",GXType.Boolean,4,0) ,
        new ParDef("NgpTppPrdID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NgpTppID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NegID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NgpItem",GXType.Int32,8,0)
        };
        Object[] prmT000Y42;
        prmT000Y42 = new Object[] {
        new ParDef("NegID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NgpItem",GXType.Int32,8,0)
        };
        Object[] prmT000Y43;
        prmT000Y43 = new Object[] {
        new ParDef("NgpTppPrdID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Y44;
        prmT000Y44 = new Object[] {
        new ParDef("NgpTppID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NgpTppPrdID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Y45;
        prmT000Y45 = new Object[] {
        new ParDef("NegID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Y46;
        prmT000Y46 = new Object[] {
        new ParDef("Gx_mode",GXType.Char,3,0)
        };
        Object[] prmT000Y47;
        prmT000Y47 = new Object[] {
        new ParDef("NegCodigo",GXType.Int64,12,0) ,
        new ParDef("NegID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Y27;
        prmT000Y27 = new Object[] {
        new ParDef("NegCliID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Y28;
        prmT000Y28 = new Object[] {
        new ParDef("NegCliID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NegCpjID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Y29;
        prmT000Y29 = new Object[] {
        new ParDef("NegPjtID",GXType.Int32,9,0)
        };
        Object[] prmT000Y30;
        prmT000Y30 = new Object[] {
        new ParDef("NegCliID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NegCpjID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NegCpjEndSeq",GXType.Int16,4,0)
        };
        Object[] prmT000Y48;
        prmT000Y48 = new Object[] {
        new ParDef("NgpTppPrdID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000Y49;
        prmT000Y49 = new Object[] {
        new ParDef("NgpTppID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NgpTppPrdID",GXType.UniqueIdentifier,36,0)
        };
        def= new CursorDef[] {
            new CursorDef("T000Y2", "SELECT NgpTotal, NegID, NgpItem, NgpQtde, NgpPreco, NgpInsDataHora, NgpInsData, NgpInsHora, NgpInsUsuID, NgpInsUsuNome, NgpDelDataHora, NgpDelData, NgpDelHora, NgpDelUsuId, NgpDelUsuNome, NgpObs, NgpDel, NgpTppPrdID, NgpTppID FROM tb_negociopj_item WHERE NegID = :NegID AND NgpItem = :NgpItem  FOR UPDATE OF tb_negociopj_item NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Y3", "SELECT NgpTotal, NegID, NgpItem, NgpQtde, NgpPreco, NgpInsDataHora, NgpInsData, NgpInsHora, NgpInsUsuID, NgpInsUsuNome, NgpDelDataHora, NgpDelData, NgpDelHora, NgpDelUsuId, NgpDelUsuNome, NgpObs, NgpDel, NgpTppPrdID, NgpTppID FROM tb_negociopj_item WHERE NegID = :NegID AND NgpItem = :NgpItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Y4", "SELECT PrdCodigo AS NgpTppPrdCodigo, PrdNome AS NgpTppPrdNome, PrdAtivo AS NgpTppPrdAtivo, PrdTipoID AS NgpTppPrdTipoID FROM tb_produto WHERE PrdID = :NgpTppPrdID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Y5", "SELECT Tpp1Preco AS NgpTpp1Preco FROM tb_tabeladepreco_produto WHERE TppID = :NgpTppID AND PrdID = :NgpTppPrdID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Y6", "SELECT NegID, NegCodigo, NegInsDataHora, NegInsData, NegInsHora, NegInsUsuID, NegInsUsuNome, NegValorAtualizado, NegValorEstimado, NegDelDataHora, NegDelData, NegDelHora, NegDelUsuId, NegDelUsuNome, NegAgcID, NegAgcNome, NegAssunto, NegDescricao, NegUltItem, NegDel, NegCliID, NegCpjID, NegCpjEndSeq, NegCliNomeFamiliar, NegCpjNomFan, NegCpjRazSocial, NegPjtNome FROM tb_negociopj WHERE NegID = :NegID  FOR UPDATE OF tb_negociopj NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Y7", "SELECT NegID, NegCodigo, NegInsDataHora, NegInsData, NegInsHora, NegInsUsuID, NegInsUsuNome, NegValorAtualizado, NegValorEstimado, NegDelDataHora, NegDelData, NegDelHora, NegDelUsuId, NegDelUsuNome, NegAgcID, NegAgcNome, NegAssunto, NegDescricao, NegUltItem, NegDel, NegCliID, NegCpjID, NegCpjEndSeq, NegCliNomeFamiliar, NegCpjNomFan, NegCpjRazSocial, NegPjtNome FROM tb_negociopj WHERE NegID = :NegID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Y8", "SELECT CliMatricula AS NegCliMatricula, CliNomeFamiliar AS NegCliNomeFamiliar FROM tb_cliente WHERE CliID = :NegCliID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Y9", "SELECT CpjNomeFan AS NegCpjNomFan, CpjRazaoSoc AS NegCpjRazSocial, CpjMatricula AS NegCpjMatricula, CpjTipoId AS NegPjtID FROM tb_clientepj WHERE CliID = :NegCliID AND CpjID = :NegCpjID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Y10", "SELECT CpjEndNome AS NegCpjEndNome, CpjEndEndereco AS NegCpjEndEndereco, CpjEndNumero AS NegCpjEndNumero, CpjEndComplem AS NegCpjEndComplem, CpjEndBairro AS NegCpjEndBairro, CpjEndCep AS NegCpjEndCep, CpjEndCepFormat AS NegCpjEndCepFormat, CpjEndMunID AS NegCpjEndMunID, CpjEndMunNome AS NegCpjEndMunNome, CpjEndUFId AS NegCpjEndUFID, CpjEndUFSigla AS NegCpjEndUFSigla, CpjEndUFNome AS NegCpjEndUFNome FROM tb_clientepj_endereco WHERE CliID = :NegCliID AND CpjID = :NegCpjID AND CpjEndSeq = :NegCpjEndSeq ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y10,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Y11", "SELECT PjtSigla AS NegPjtSigla, PjtNome AS NegPjtNome FROM tb_clientepjtipo WHERE PjtID = :NegPjtID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Y13", "SELECT COALESCE( T1.NegPgpTotal, 0) AS NegPgpTotal FROM (SELECT SUM(NgpTotal) AS NegPgpTotal, NegID FROM tb_negociopj_item GROUP BY NegID ) T1 WHERE T1.NegID = :NegID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y13,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Y15", "SELECT TM1.NegID, TM1.NegCodigo, TM1.NegInsDataHora, TM1.NegInsData, TM1.NegInsHora, TM1.NegInsUsuID, TM1.NegInsUsuNome, TM1.NegValorAtualizado, TM1.NegValorEstimado, TM1.NegDelDataHora, TM1.NegDelData, TM1.NegDelHora, TM1.NegDelUsuId, TM1.NegDelUsuNome, T3.CliMatricula AS NegCliMatricula, TM1.NegCliNomeFamiliar AS NegCliNomeFamiliar, TM1.NegCpjNomFan AS NegCpjNomFan, TM1.NegCpjRazSocial AS NegCpjRazSocial, T4.CpjMatricula AS NegCpjMatricula, T5.PjtSigla AS NegPjtSigla, TM1.NegPjtNome AS NegPjtNome, T6.CpjEndNome AS NegCpjEndNome, T6.CpjEndEndereco AS NegCpjEndEndereco, T6.CpjEndNumero AS NegCpjEndNumero, T6.CpjEndComplem AS NegCpjEndComplem, T6.CpjEndBairro AS NegCpjEndBairro, T6.CpjEndCep AS NegCpjEndCep, T6.CpjEndCepFormat AS NegCpjEndCepFormat, T6.CpjEndMunID AS NegCpjEndMunID, T6.CpjEndMunNome AS NegCpjEndMunNome, T6.CpjEndUFId AS NegCpjEndUFID, T6.CpjEndUFSigla AS NegCpjEndUFSigla, T6.CpjEndUFNome AS NegCpjEndUFNome, TM1.NegAgcID, TM1.NegAgcNome, TM1.NegAssunto, TM1.NegDescricao, TM1.NegUltItem, TM1.NegDel, TM1.NegCliID AS NegCliID, TM1.NegCpjID AS NegCpjID, TM1.NegCpjEndSeq AS NegCpjEndSeq, T4.CpjTipoId AS NegPjtID, COALESCE( T2.NegPgpTotal, 0) AS NegPgpTotal FROM (((((tb_negociopj TM1 LEFT JOIN LATERAL (SELECT SUM(NgpTotal) AS NegPgpTotal, NegID FROM tb_negociopj_item WHERE TM1.NegID = NegID GROUP BY NegID ) T2 ON T2.NegID = TM1.NegID) INNER JOIN tb_cliente T3 ON T3.CliID = TM1.NegCliID) INNER JOIN tb_clientepj T4 ON T4.CliID = TM1.NegCliID AND T4.CpjID = TM1.NegCpjID) INNER JOIN tb_clientepjtipo T5 ON T5.PjtID = T4.CpjTipoId) INNER JOIN tb_clientepj_endereco T6 ON T6.CliID = TM1.NegCliID AND T6.CpjID = TM1.NegCpjID AND T6.CpjEndSeq = TM1.NegCpjEndSeq) WHERE TM1.NegID = :NegID ORDER BY TM1.NegID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y15,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Y16", "SELECT NegCodigo FROM tb_negociopj WHERE (NegCodigo = :NegCodigo) AND (Not ( NegID = :NegID)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y16,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Y17", "SELECT CliMatricula AS NegCliMatricula, CliNomeFamiliar AS NegCliNomeFamiliar FROM tb_cliente WHERE CliID = :NegCliID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y17,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Y18", "SELECT CpjNomeFan AS NegCpjNomFan, CpjRazaoSoc AS NegCpjRazSocial, CpjMatricula AS NegCpjMatricula, CpjTipoId AS NegPjtID FROM tb_clientepj WHERE CliID = :NegCliID AND CpjID = :NegCpjID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y18,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Y19", "SELECT PjtSigla AS NegPjtSigla, PjtNome AS NegPjtNome FROM tb_clientepjtipo WHERE PjtID = :NegPjtID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y19,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Y20", "SELECT CpjEndNome AS NegCpjEndNome, CpjEndEndereco AS NegCpjEndEndereco, CpjEndNumero AS NegCpjEndNumero, CpjEndComplem AS NegCpjEndComplem, CpjEndBairro AS NegCpjEndBairro, CpjEndCep AS NegCpjEndCep, CpjEndCepFormat AS NegCpjEndCepFormat, CpjEndMunID AS NegCpjEndMunID, CpjEndMunNome AS NegCpjEndMunNome, CpjEndUFId AS NegCpjEndUFID, CpjEndUFSigla AS NegCpjEndUFSigla, CpjEndUFNome AS NegCpjEndUFNome FROM tb_clientepj_endereco WHERE CliID = :NegCliID AND CpjID = :NegCpjID AND CpjEndSeq = :NegCpjEndSeq ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y20,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Y21", "SELECT NegID FROM tb_negociopj WHERE NegID = :NegID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y21,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Y22", "SELECT NegID FROM tb_negociopj WHERE ( NegID > :NegID) ORDER BY NegID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y22,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000Y23", "SELECT NegID FROM tb_negociopj WHERE ( NegID < :NegID) ORDER BY NegID DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y23,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000Y24", "SAVEPOINT gxupdate;INSERT INTO tb_negociopj(NegCliNomeFamiliar, NegCpjNomFan, NegCpjRazSocial, NegPjtNome, NegID, NegCodigo, NegInsDataHora, NegInsData, NegInsHora, NegInsUsuID, NegInsUsuNome, NegValorAtualizado, NegValorEstimado, NegDelDataHora, NegDelData, NegDelHora, NegDelUsuId, NegDelUsuNome, NegAgcID, NegAgcNome, NegAssunto, NegDescricao, NegUltItem, NegDel, NegCliID, NegCpjID, NegCpjEndSeq, NegUltFase, NegUltIteID, NegUltIteNome, NegUltNgfSeq, NegUltIteOrdem) VALUES(:NegCliNomeFamiliar, :NegCpjNomFan, :NegCpjRazSocial, :NegPjtNome, :NegID, :NegCodigo, :NegInsDataHora, :NegInsData, :NegInsHora, :NegInsUsuID, :NegInsUsuNome, :NegValorAtualizado, :NegValorEstimado, :NegDelDataHora, :NegDelData, :NegDelHora, :NegDelUsuId, :NegDelUsuNome, :NegAgcID, :NegAgcNome, :NegAssunto, :NegDescricao, :NegUltItem, :NegDel, :NegCliID, :NegCpjID, :NegCpjEndSeq, 0, '00000000-0000-0000-0000-000000000000', '', 0, 0);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000Y24)
           ,new CursorDef("T000Y25", "SAVEPOINT gxupdate;UPDATE tb_negociopj SET NegCliNomeFamiliar=:NegCliNomeFamiliar, NegCpjNomFan=:NegCpjNomFan, NegCpjRazSocial=:NegCpjRazSocial, NegPjtNome=:NegPjtNome, NegCodigo=:NegCodigo, NegInsDataHora=:NegInsDataHora, NegInsData=:NegInsData, NegInsHora=:NegInsHora, NegInsUsuID=:NegInsUsuID, NegInsUsuNome=:NegInsUsuNome, NegValorAtualizado=:NegValorAtualizado, NegValorEstimado=:NegValorEstimado, NegDelDataHora=:NegDelDataHora, NegDelData=:NegDelData, NegDelHora=:NegDelHora, NegDelUsuId=:NegDelUsuId, NegDelUsuNome=:NegDelUsuNome, NegAgcID=:NegAgcID, NegAgcNome=:NegAgcNome, NegAssunto=:NegAssunto, NegDescricao=:NegDescricao, NegUltItem=:NegUltItem, NegDel=:NegDel, NegCliID=:NegCliID, NegCpjID=:NegCpjID, NegCpjEndSeq=:NegCpjEndSeq  WHERE NegID = :NegID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000Y25)
           ,new CursorDef("T000Y26", "SAVEPOINT gxupdate;DELETE FROM tb_negociopj  WHERE NegID = :NegID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000Y26)
           ,new CursorDef("T000Y27", "SELECT CliMatricula AS NegCliMatricula, CliNomeFamiliar AS NegCliNomeFamiliar FROM tb_cliente WHERE CliID = :NegCliID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y27,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Y28", "SELECT CpjNomeFan AS NegCpjNomFan, CpjRazaoSoc AS NegCpjRazSocial, CpjMatricula AS NegCpjMatricula, CpjTipoId AS NegPjtID FROM tb_clientepj WHERE CliID = :NegCliID AND CpjID = :NegCpjID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y28,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Y29", "SELECT PjtSigla AS NegPjtSigla, PjtNome AS NegPjtNome FROM tb_clientepjtipo WHERE PjtID = :NegPjtID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y29,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Y30", "SELECT CpjEndNome AS NegCpjEndNome, CpjEndEndereco AS NegCpjEndEndereco, CpjEndNumero AS NegCpjEndNumero, CpjEndComplem AS NegCpjEndComplem, CpjEndBairro AS NegCpjEndBairro, CpjEndCep AS NegCpjEndCep, CpjEndCepFormat AS NegCpjEndCepFormat, CpjEndMunID AS NegCpjEndMunID, CpjEndMunNome AS NegCpjEndMunNome, CpjEndUFId AS NegCpjEndUFID, CpjEndUFSigla AS NegCpjEndUFSigla, CpjEndUFNome AS NegCpjEndUFNome FROM tb_clientepj_endereco WHERE CliID = :NegCliID AND CpjID = :NegCpjID AND CpjEndSeq = :NegCpjEndSeq ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y30,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Y31", "SELECT VisID FROM tb_visita WHERE VisNegID = :NegID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y31,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000Y32", "SELECT NegID, NefChave FROM tb_negociopj_fluxo WHERE NegID = :NegID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y32,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000Y33", "SELECT NegID, NgfSeq FROM tb_negociopj_fase WHERE NegID = :NegID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y33,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000Y34", "SAVEPOINT gxupdate;UPDATE tb_negociopj SET NegUltItem=:NegUltItem, NegValorEstimado=:NegValorEstimado, NegValorAtualizado=:NegValorAtualizado  WHERE NegID = :NegID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000Y34)
           ,new CursorDef("T000Y35", "SELECT NegID FROM tb_negociopj ORDER BY NegID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y35,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Y36", "SELECT T1.NgpTotal, T1.NegID, T1.NgpItem, T1.NgpQtde, T1.NgpPreco, T1.NgpInsDataHora, T1.NgpInsData, T1.NgpInsHora, T1.NgpInsUsuID, T1.NgpInsUsuNome, T1.NgpDelDataHora, T1.NgpDelData, T1.NgpDelHora, T1.NgpDelUsuId, T1.NgpDelUsuNome, T2.PrdCodigo AS NgpTppPrdCodigo, T2.PrdNome AS NgpTppPrdNome, T2.PrdAtivo AS NgpTppPrdAtivo, T3.Tpp1Preco AS NgpTpp1Preco, T1.NgpObs, T1.NgpDel, T1.NgpTppPrdID AS NgpTppPrdID, T1.NgpTppID AS NgpTppID, T2.PrdTipoID AS NgpTppPrdTipoID FROM ((tb_negociopj_item T1 INNER JOIN tb_produto T2 ON T2.PrdID = T1.NgpTppPrdID) INNER JOIN tb_tabeladepreco_produto T3 ON T3.TppID = T1.NgpTppID AND T3.PrdID = T1.NgpTppPrdID) WHERE T1.NegID = :NegID and T1.NgpItem = :NgpItem ORDER BY T1.NegID, T1.NgpItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y36,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Y37", "SELECT Tpp1Preco AS NgpTpp1Preco FROM tb_tabeladepreco_produto WHERE TppID = :NgpTppID AND PrdID = :NgpTppPrdID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y37,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Y38", "SELECT PrdCodigo AS NgpTppPrdCodigo, PrdNome AS NgpTppPrdNome, PrdAtivo AS NgpTppPrdAtivo, PrdTipoID AS NgpTppPrdTipoID FROM tb_produto WHERE PrdID = :NgpTppPrdID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y38,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Y39", "SELECT NegID, NgpItem FROM tb_negociopj_item WHERE NegID = :NegID AND NgpItem = :NgpItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y39,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Y40", "SAVEPOINT gxupdate;INSERT INTO tb_negociopj_item(NgpTotal, NegID, NgpItem, NgpQtde, NgpPreco, NgpInsDataHora, NgpInsData, NgpInsHora, NgpInsUsuID, NgpInsUsuNome, NgpDelDataHora, NgpDelData, NgpDelHora, NgpDelUsuId, NgpDelUsuNome, NgpObs, NgpDel, NgpTppPrdID, NgpTppID) VALUES(:NgpTotal, :NegID, :NgpItem, :NgpQtde, :NgpPreco, :NgpInsDataHora, :NgpInsData, :NgpInsHora, :NgpInsUsuID, :NgpInsUsuNome, :NgpDelDataHora, :NgpDelData, :NgpDelHora, :NgpDelUsuId, :NgpDelUsuNome, :NgpObs, :NgpDel, :NgpTppPrdID, :NgpTppID);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000Y40)
           ,new CursorDef("T000Y41", "SAVEPOINT gxupdate;UPDATE tb_negociopj_item SET NgpTotal=:NgpTotal, NgpQtde=:NgpQtde, NgpPreco=:NgpPreco, NgpInsDataHora=:NgpInsDataHora, NgpInsData=:NgpInsData, NgpInsHora=:NgpInsHora, NgpInsUsuID=:NgpInsUsuID, NgpInsUsuNome=:NgpInsUsuNome, NgpDelDataHora=:NgpDelDataHora, NgpDelData=:NgpDelData, NgpDelHora=:NgpDelHora, NgpDelUsuId=:NgpDelUsuId, NgpDelUsuNome=:NgpDelUsuNome, NgpObs=:NgpObs, NgpDel=:NgpDel, NgpTppPrdID=:NgpTppPrdID, NgpTppID=:NgpTppID  WHERE NegID = :NegID AND NgpItem = :NgpItem;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000Y41)
           ,new CursorDef("T000Y42", "SAVEPOINT gxupdate;DELETE FROM tb_negociopj_item  WHERE NegID = :NegID AND NgpItem = :NgpItem;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000Y42)
           ,new CursorDef("T000Y43", "SELECT PrdCodigo AS NgpTppPrdCodigo, PrdNome AS NgpTppPrdNome, PrdAtivo AS NgpTppPrdAtivo, PrdTipoID AS NgpTppPrdTipoID FROM tb_produto WHERE PrdID = :NgpTppPrdID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y43,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Y44", "SELECT Tpp1Preco AS NgpTpp1Preco FROM tb_tabeladepreco_produto WHERE TppID = :NgpTppID AND PrdID = :NgpTppPrdID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y44,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Y45", "SELECT NegID, NgpItem FROM tb_negociopj_item WHERE NegID = :NegID ORDER BY NegID, NgpItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y45,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Y46", "SELECT PrdID, PrdNome, PrdAtivo, PrdDel FROM tb_produto WHERE ( :Gx_mode = ( 'INS') and PrdAtivo and Not PrdDel) or :Gx_mode <> ( 'INS') ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y46,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Y47", "SELECT NegCodigo FROM tb_negociopj WHERE (NegCodigo = :NegCodigo) AND (Not ( NegID = :NegID)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y47,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Y48", "SELECT PrdCodigo AS NgpTppPrdCodigo, PrdNome AS NgpTppPrdNome, PrdAtivo AS NgpTppPrdAtivo, PrdTipoID AS NgpTppPrdTipoID FROM tb_produto WHERE PrdID = :NgpTppPrdID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y48,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Y49", "SELECT Tpp1Preco AS NgpTpp1Preco FROM tb_tabeladepreco_produto WHERE TppID = :NgpTppID AND PrdID = :NgpTppPrdID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Y49,1, GxCacheFrequency.OFF ,true,false )
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
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6, true);
              ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
              ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(8);
              ((string[]) buf[8])[0] = rslt.getString(9, 40);
              ((bool[]) buf[9])[0] = rslt.wasNull(9);
              ((string[]) buf[10])[0] = rslt.getVarchar(10);
              ((bool[]) buf[11])[0] = rslt.wasNull(10);
              ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(11, true);
              ((bool[]) buf[13])[0] = rslt.wasNull(11);
              ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(12);
              ((bool[]) buf[15])[0] = rslt.wasNull(12);
              ((DateTime[]) buf[16])[0] = rslt.getGXDateTime(13);
              ((bool[]) buf[17])[0] = rslt.wasNull(13);
              ((string[]) buf[18])[0] = rslt.getString(14, 40);
              ((bool[]) buf[19])[0] = rslt.wasNull(14);
              ((string[]) buf[20])[0] = rslt.getVarchar(15);
              ((bool[]) buf[21])[0] = rslt.wasNull(15);
              ((string[]) buf[22])[0] = rslt.getVarchar(16);
              ((bool[]) buf[23])[0] = rslt.getBool(17);
              ((Guid[]) buf[24])[0] = rslt.getGuid(18);
              ((Guid[]) buf[25])[0] = rslt.getGuid(19);
              return;
           case 1 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6, true);
              ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
              ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(8);
              ((string[]) buf[8])[0] = rslt.getString(9, 40);
              ((bool[]) buf[9])[0] = rslt.wasNull(9);
              ((string[]) buf[10])[0] = rslt.getVarchar(10);
              ((bool[]) buf[11])[0] = rslt.wasNull(10);
              ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(11, true);
              ((bool[]) buf[13])[0] = rslt.wasNull(11);
              ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(12);
              ((bool[]) buf[15])[0] = rslt.wasNull(12);
              ((DateTime[]) buf[16])[0] = rslt.getGXDateTime(13);
              ((bool[]) buf[17])[0] = rslt.wasNull(13);
              ((string[]) buf[18])[0] = rslt.getString(14, 40);
              ((bool[]) buf[19])[0] = rslt.wasNull(14);
              ((string[]) buf[20])[0] = rslt.getVarchar(15);
              ((bool[]) buf[21])[0] = rslt.wasNull(15);
              ((string[]) buf[22])[0] = rslt.getVarchar(16);
              ((bool[]) buf[23])[0] = rslt.getBool(17);
              ((Guid[]) buf[24])[0] = rslt.getGuid(18);
              ((Guid[]) buf[25])[0] = rslt.getGuid(19);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              return;
           case 3 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              return;
           case 4 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3, true);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 40);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              ((string[]) buf[7])[0] = rslt.getVarchar(7);
              ((bool[]) buf[8])[0] = rslt.wasNull(7);
              ((decimal[]) buf[9])[0] = rslt.getDecimal(8);
              ((decimal[]) buf[10])[0] = rslt.getDecimal(9);
              ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(10, true);
              ((bool[]) buf[12])[0] = rslt.wasNull(10);
              ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(11);
              ((bool[]) buf[14])[0] = rslt.wasNull(11);
              ((DateTime[]) buf[15])[0] = rslt.getGXDateTime(12);
              ((bool[]) buf[16])[0] = rslt.wasNull(12);
              ((string[]) buf[17])[0] = rslt.getString(13, 40);
              ((bool[]) buf[18])[0] = rslt.wasNull(13);
              ((string[]) buf[19])[0] = rslt.getVarchar(14);
              ((bool[]) buf[20])[0] = rslt.wasNull(14);
              ((string[]) buf[21])[0] = rslt.getString(15, 40);
              ((bool[]) buf[22])[0] = rslt.wasNull(15);
              ((string[]) buf[23])[0] = rslt.getVarchar(16);
              ((bool[]) buf[24])[0] = rslt.wasNull(16);
              ((string[]) buf[25])[0] = rslt.getVarchar(17);
              ((string[]) buf[26])[0] = rslt.getLongVarchar(18);
              ((int[]) buf[27])[0] = rslt.getInt(19);
              ((bool[]) buf[28])[0] = rslt.wasNull(19);
              ((bool[]) buf[29])[0] = rslt.getBool(20);
              ((Guid[]) buf[30])[0] = rslt.getGuid(21);
              ((Guid[]) buf[31])[0] = rslt.getGuid(22);
              ((short[]) buf[32])[0] = rslt.getShort(23);
              ((string[]) buf[33])[0] = rslt.getVarchar(24);
              ((string[]) buf[34])[0] = rslt.getVarchar(25);
              ((string[]) buf[35])[0] = rslt.getVarchar(26);
              ((string[]) buf[36])[0] = rslt.getVarchar(27);
              return;
           case 5 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3, true);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 40);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              ((string[]) buf[7])[0] = rslt.getVarchar(7);
              ((bool[]) buf[8])[0] = rslt.wasNull(7);
              ((decimal[]) buf[9])[0] = rslt.getDecimal(8);
              ((decimal[]) buf[10])[0] = rslt.getDecimal(9);
              ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(10, true);
              ((bool[]) buf[12])[0] = rslt.wasNull(10);
              ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(11);
              ((bool[]) buf[14])[0] = rslt.wasNull(11);
              ((DateTime[]) buf[15])[0] = rslt.getGXDateTime(12);
              ((bool[]) buf[16])[0] = rslt.wasNull(12);
              ((string[]) buf[17])[0] = rslt.getString(13, 40);
              ((bool[]) buf[18])[0] = rslt.wasNull(13);
              ((string[]) buf[19])[0] = rslt.getVarchar(14);
              ((bool[]) buf[20])[0] = rslt.wasNull(14);
              ((string[]) buf[21])[0] = rslt.getString(15, 40);
              ((bool[]) buf[22])[0] = rslt.wasNull(15);
              ((string[]) buf[23])[0] = rslt.getVarchar(16);
              ((bool[]) buf[24])[0] = rslt.wasNull(16);
              ((string[]) buf[25])[0] = rslt.getVarchar(17);
              ((string[]) buf[26])[0] = rslt.getLongVarchar(18);
              ((int[]) buf[27])[0] = rslt.getInt(19);
              ((bool[]) buf[28])[0] = rslt.wasNull(19);
              ((bool[]) buf[29])[0] = rslt.getBool(20);
              ((Guid[]) buf[30])[0] = rslt.getGuid(21);
              ((Guid[]) buf[31])[0] = rslt.getGuid(22);
              ((short[]) buf[32])[0] = rslt.getShort(23);
              ((string[]) buf[33])[0] = rslt.getVarchar(24);
              ((string[]) buf[34])[0] = rslt.getVarchar(25);
              ((string[]) buf[35])[0] = rslt.getVarchar(26);
              ((string[]) buf[36])[0] = rslt.getVarchar(27);
              return;
           case 6 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((string[]) buf[5])[0] = rslt.getVarchar(5);
              ((int[]) buf[6])[0] = rslt.getInt(6);
              ((string[]) buf[7])[0] = rslt.getVarchar(7);
              ((int[]) buf[8])[0] = rslt.getInt(8);
              ((string[]) buf[9])[0] = rslt.getVarchar(9);
              ((short[]) buf[10])[0] = rslt.getShort(10);
              ((string[]) buf[11])[0] = rslt.getVarchar(11);
              ((string[]) buf[12])[0] = rslt.getVarchar(12);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 10 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              return;
           case 11 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3, true);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 40);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              ((string[]) buf[7])[0] = rslt.getVarchar(7);
              ((bool[]) buf[8])[0] = rslt.wasNull(7);
              ((decimal[]) buf[9])[0] = rslt.getDecimal(8);
              ((decimal[]) buf[10])[0] = rslt.getDecimal(9);
              ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(10, true);
              ((bool[]) buf[12])[0] = rslt.wasNull(10);
              ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(11);
              ((bool[]) buf[14])[0] = rslt.wasNull(11);
              ((DateTime[]) buf[15])[0] = rslt.getGXDateTime(12);
              ((bool[]) buf[16])[0] = rslt.wasNull(12);
              ((string[]) buf[17])[0] = rslt.getString(13, 40);
              ((bool[]) buf[18])[0] = rslt.wasNull(13);
              ((string[]) buf[19])[0] = rslt.getVarchar(14);
              ((bool[]) buf[20])[0] = rslt.wasNull(14);
              ((long[]) buf[21])[0] = rslt.getLong(15);
              ((string[]) buf[22])[0] = rslt.getVarchar(16);
              ((string[]) buf[23])[0] = rslt.getVarchar(17);
              ((string[]) buf[24])[0] = rslt.getVarchar(18);
              ((long[]) buf[25])[0] = rslt.getLong(19);
              ((string[]) buf[26])[0] = rslt.getVarchar(20);
              ((string[]) buf[27])[0] = rslt.getVarchar(21);
              ((string[]) buf[28])[0] = rslt.getVarchar(22);
              ((string[]) buf[29])[0] = rslt.getVarchar(23);
              ((string[]) buf[30])[0] = rslt.getVarchar(24);
              ((string[]) buf[31])[0] = rslt.getVarchar(25);
              ((bool[]) buf[32])[0] = rslt.wasNull(25);
              ((string[]) buf[33])[0] = rslt.getVarchar(26);
              ((int[]) buf[34])[0] = rslt.getInt(27);
              ((string[]) buf[35])[0] = rslt.getVarchar(28);
              ((int[]) buf[36])[0] = rslt.getInt(29);
              ((string[]) buf[37])[0] = rslt.getVarchar(30);
              ((short[]) buf[38])[0] = rslt.getShort(31);
              ((string[]) buf[39])[0] = rslt.getVarchar(32);
              ((string[]) buf[40])[0] = rslt.getVarchar(33);
              ((string[]) buf[41])[0] = rslt.getString(34, 40);
              ((bool[]) buf[42])[0] = rslt.wasNull(34);
              ((string[]) buf[43])[0] = rslt.getVarchar(35);
              ((bool[]) buf[44])[0] = rslt.wasNull(35);
              ((string[]) buf[45])[0] = rslt.getVarchar(36);
              ((string[]) buf[46])[0] = rslt.getLongVarchar(37);
              ((int[]) buf[47])[0] = rslt.getInt(38);
              ((bool[]) buf[48])[0] = rslt.wasNull(38);
              ((bool[]) buf[49])[0] = rslt.getBool(39);
              ((Guid[]) buf[50])[0] = rslt.getGuid(40);
              ((Guid[]) buf[51])[0] = rslt.getGuid(41);
              ((short[]) buf[52])[0] = rslt.getShort(42);
              ((int[]) buf[53])[0] = rslt.getInt(43);
              ((decimal[]) buf[54])[0] = rslt.getDecimal(44);
              ((bool[]) buf[55])[0] = rslt.wasNull(44);
              return;
           case 12 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 13 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 16 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((string[]) buf[5])[0] = rslt.getVarchar(5);
              ((int[]) buf[6])[0] = rslt.getInt(6);
              ((string[]) buf[7])[0] = rslt.getVarchar(7);
              ((int[]) buf[8])[0] = rslt.getInt(8);
              ((string[]) buf[9])[0] = rslt.getVarchar(9);
              ((short[]) buf[10])[0] = rslt.getShort(10);
              ((string[]) buf[11])[0] = rslt.getVarchar(11);
              ((string[]) buf[12])[0] = rslt.getVarchar(12);
              return;
           case 17 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 18 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 19 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 23 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 24 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              return;
           case 25 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 26 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((string[]) buf[5])[0] = rslt.getVarchar(5);
              ((int[]) buf[6])[0] = rslt.getInt(6);
              ((string[]) buf[7])[0] = rslt.getVarchar(7);
              ((int[]) buf[8])[0] = rslt.getInt(8);
              ((string[]) buf[9])[0] = rslt.getVarchar(9);
              ((short[]) buf[10])[0] = rslt.getShort(10);
              ((string[]) buf[11])[0] = rslt.getVarchar(11);
              ((string[]) buf[12])[0] = rslt.getVarchar(12);
              return;
           case 27 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 28 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 29 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 31 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 32 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6, true);
              ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
              ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(8);
              ((string[]) buf[8])[0] = rslt.getString(9, 40);
              ((bool[]) buf[9])[0] = rslt.wasNull(9);
              ((string[]) buf[10])[0] = rslt.getVarchar(10);
              ((bool[]) buf[11])[0] = rslt.wasNull(10);
              ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(11, true);
              ((bool[]) buf[13])[0] = rslt.wasNull(11);
              ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(12);
              ((bool[]) buf[15])[0] = rslt.wasNull(12);
              ((DateTime[]) buf[16])[0] = rslt.getGXDateTime(13);
              ((bool[]) buf[17])[0] = rslt.wasNull(13);
              ((string[]) buf[18])[0] = rslt.getString(14, 40);
              ((bool[]) buf[19])[0] = rslt.wasNull(14);
              ((string[]) buf[20])[0] = rslt.getVarchar(15);
              ((bool[]) buf[21])[0] = rslt.wasNull(15);
              ((string[]) buf[22])[0] = rslt.getVarchar(16);
              ((string[]) buf[23])[0] = rslt.getVarchar(17);
              ((bool[]) buf[24])[0] = rslt.getBool(18);
              ((decimal[]) buf[25])[0] = rslt.getDecimal(19);
              ((string[]) buf[26])[0] = rslt.getVarchar(20);
              ((bool[]) buf[27])[0] = rslt.getBool(21);
              ((Guid[]) buf[28])[0] = rslt.getGuid(22);
              ((Guid[]) buf[29])[0] = rslt.getGuid(23);
              ((int[]) buf[30])[0] = rslt.getInt(24);
              return;
           case 33 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              return;
           case 34 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              return;
           case 35 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 39 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              return;
           case 40 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              return;
           case 41 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 42 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              ((bool[]) buf[3])[0] = rslt.getBool(4);
              return;
           case 43 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 44 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              return;
           case 45 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              return;
     }
  }

}

}
