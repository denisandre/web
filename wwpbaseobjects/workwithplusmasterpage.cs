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
namespace GeneXus.Programs.wwpbaseobjects {
   public class workwithplusmasterpage : GXMasterPage
   {
      public workwithplusmasterpage( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public workwithplusmasterpage( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
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

      protected void INITWEB( )
      {
         initialize_properties( ) ;
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
            PA2R2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               WS2R2( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  WE2R2( ) ;
               }
            }
         }
         this.cleanup();
      }

      protected void RenderHtmlHeaders( )
      {
         if ( ! isFullAjaxMode( ) )
         {
            GXWebForm.AddResponsiveMetaHeaders((getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Meta);
            getDataAreaObject().RenderHtmlHeaders();
         }
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( ! isFullAjaxMode( ) )
         {
            getDataAreaObject().RenderHtmlOpenForm();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "vPROGRAMDESCRIPTION_MPAGE", AV20ProgramDescription);
         GxWebStd.gx_hidden_field( context, "gxhash_vPROGRAMDESCRIPTION_MPAGE", GetSecureSignedToken( "gxmpage_", StringUtil.RTrim( context.localUtil.Format( AV20ProgramDescription, "")), context));
         GxWebStd.gx_hidden_field( context, "vBREADCRUMB_MPAGE", AV48Breadcrumb);
         GxWebStd.gx_hidden_field( context, "gxhash_vBREADCRUMB_MPAGE", GetSecureSignedToken( "gxmpage_", StringUtil.RTrim( context.localUtil.Format( AV48Breadcrumb, "")), context));
         GxWebStd.gx_hidden_field( context, "vINDEXTOADDITEMS_MPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19IndexToAddItems), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vINDEXTOADDITEMS_MPAGE", GetSecureSignedToken( "gxmpage_", context.localUtil.Format( (decimal)(AV19IndexToAddItems), "ZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", true, "vDVELOP_MENU_MPAGE", AV33DVelop_Menu);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDVELOP_MENU_MPAGE", AV33DVelop_Menu);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", true, "vBOOKMARKSDATA_MPAGE", AV14BookmarksData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vBOOKMARKSDATA_MPAGE", AV14BookmarksData);
         }
         GxWebStd.gx_hidden_field( context, "vPROGRAMDESCRIPTION_MPAGE", AV20ProgramDescription);
         GxWebStd.gx_hidden_field( context, "gxhash_vPROGRAMDESCRIPTION_MPAGE", GetSecureSignedToken( "gxmpage_", StringUtil.RTrim( context.localUtil.Format( AV20ProgramDescription, "")), context));
         GxWebStd.gx_hidden_field( context, "vBREADCRUMB_MPAGE", AV48Breadcrumb);
         GxWebStd.gx_hidden_field( context, "gxhash_vBREADCRUMB_MPAGE", GetSecureSignedToken( "gxmpage_", StringUtil.RTrim( context.localUtil.Format( AV48Breadcrumb, "")), context));
         GxWebStd.gx_hidden_field( context, "vINDEXTOADDITEMS_MPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19IndexToAddItems), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vINDEXTOADDITEMS_MPAGE", GetSecureSignedToken( "gxmpage_", context.localUtil.Format( (decimal)(AV19IndexToAddItems), "ZZZ9"), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", true, "vNOTIFICATIONINFO_MPAGE", AV22NotificationInfo);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vNOTIFICATIONINFO_MPAGE", AV22NotificationInfo);
         }
         GxWebStd.gx_hidden_field( context, "WWPUSEREXTENDEDID_MPAGE", StringUtil.RTrim( A49WWPUserExtendedId));
         GxWebStd.gx_hidden_field( context, "vUDPARG1_MPAGE", StringUtil.RTrim( AV51Udparg1));
         GxWebStd.gx_boolean_hidden_field( context, "WWPNOTIFICATIONISREAD_MPAGE", A124WWPNotificationIsRead);
         GxWebStd.gx_hidden_field( context, "UCMENU_MPAGE_Cls", StringUtil.RTrim( Ucmenu_Cls));
         GxWebStd.gx_hidden_field( context, "UCMENU_MPAGE_Collapsedtitle", StringUtil.RTrim( Ucmenu_Collapsedtitle));
         GxWebStd.gx_hidden_field( context, "UCMENU_MPAGE_Moreoptionenabled", StringUtil.BoolToStr( Ucmenu_Moreoptionenabled));
         GxWebStd.gx_hidden_field( context, "UCMENU_MPAGE_Moreoptiontype", StringUtil.RTrim( Ucmenu_Moreoptiontype));
         GxWebStd.gx_hidden_field( context, "UCMENU_MPAGE_Moreoptioncaption", StringUtil.RTrim( Ucmenu_Moreoptioncaption));
         GxWebStd.gx_hidden_field( context, "UCMENU_MPAGE_Moreoptionicon", StringUtil.RTrim( Ucmenu_Moreoptionicon));
         GxWebStd.gx_hidden_field( context, "DDO_BOOKMARKS_MPAGE_Icontype", StringUtil.RTrim( Ddo_bookmarks_Icontype));
         GxWebStd.gx_hidden_field( context, "DDO_BOOKMARKS_MPAGE_Icon", StringUtil.RTrim( Ddo_bookmarks_Icon));
         GxWebStd.gx_hidden_field( context, "DDO_BOOKMARKS_MPAGE_Tooltip", StringUtil.RTrim( Ddo_bookmarks_Tooltip));
         GxWebStd.gx_hidden_field( context, "DDO_BOOKMARKS_MPAGE_Cls", StringUtil.RTrim( Ddo_bookmarks_Cls));
         GxWebStd.gx_hidden_field( context, "DDO_BOOKMARKS_MPAGE_Titlecontrolalign", StringUtil.RTrim( Ddo_bookmarks_Titlecontrolalign));
         GxWebStd.gx_hidden_field( context, "DDC_NOTIFICATIONSWC_MPAGE_Icontype", StringUtil.RTrim( Ddc_notificationswc_Icontype));
         GxWebStd.gx_hidden_field( context, "DDC_NOTIFICATIONSWC_MPAGE_Icon", StringUtil.RTrim( Ddc_notificationswc_Icon));
         GxWebStd.gx_hidden_field( context, "DDC_NOTIFICATIONSWC_MPAGE_Caption", StringUtil.RTrim( Ddc_notificationswc_Caption));
         GxWebStd.gx_hidden_field( context, "DDC_NOTIFICATIONSWC_MPAGE_Cls", StringUtil.RTrim( Ddc_notificationswc_Cls));
         GxWebStd.gx_hidden_field( context, "DDC_ADMINAG_MPAGE_Icontype", StringUtil.RTrim( Ddc_adminag_Icontype));
         GxWebStd.gx_hidden_field( context, "DDC_ADMINAG_MPAGE_Icon", StringUtil.RTrim( Ddc_adminag_Icon));
         GxWebStd.gx_hidden_field( context, "DDC_ADMINAG_MPAGE_Caption", StringUtil.RTrim( Ddc_adminag_Caption));
         GxWebStd.gx_hidden_field( context, "DDC_ADMINAG_MPAGE_Cls", StringUtil.RTrim( Ddc_adminag_Cls));
         GxWebStd.gx_hidden_field( context, "DDC_ADMINAG_MPAGE_Componentwidth", StringUtil.LTrim( StringUtil.NToC( (decimal)(Ddc_adminag_Componentwidth), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDC_RUNTIMEDESIGNSETTINGS_MPAGE_Icontype", StringUtil.RTrim( Ddc_runtimedesignsettings_Icontype));
         GxWebStd.gx_hidden_field( context, "DDC_RUNTIMEDESIGNSETTINGS_MPAGE_Icon", StringUtil.RTrim( Ddc_runtimedesignsettings_Icon));
         GxWebStd.gx_hidden_field( context, "DDC_RUNTIMEDESIGNSETTINGS_MPAGE_Tooltip", StringUtil.RTrim( Ddc_runtimedesignsettings_Tooltip));
         GxWebStd.gx_hidden_field( context, "DDC_RUNTIMEDESIGNSETTINGS_MPAGE_Cls", StringUtil.RTrim( Ddc_runtimedesignsettings_Cls));
         GxWebStd.gx_hidden_field( context, "DDC_RUNTIMEDESIGNSETTINGS_MPAGE_Componentwidth", StringUtil.LTrim( StringUtil.NToC( (decimal)(Ddc_runtimedesignsettings_Componentwidth), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "UCMESSAGE_MPAGE_Stoponerror", StringUtil.BoolToStr( Ucmessage_Stoponerror));
         GxWebStd.gx_hidden_field( context, "WWPUTILITIES_MPAGE_Enablefixobjectfitcover", StringUtil.BoolToStr( Wwputilities_Enablefixobjectfitcover));
         GxWebStd.gx_hidden_field( context, "WWPUTILITIES_MPAGE_Enablefloatinglabels", StringUtil.BoolToStr( Wwputilities_Enablefloatinglabels));
         GxWebStd.gx_hidden_field( context, "WWPUTILITIES_MPAGE_Empowertabs", StringUtil.BoolToStr( Wwputilities_Empowertabs));
         GxWebStd.gx_hidden_field( context, "WWPUTILITIES_MPAGE_Enableupdaterowselectionstatus", StringUtil.BoolToStr( Wwputilities_Enableupdaterowselectionstatus));
         GxWebStd.gx_hidden_field( context, "WWPUTILITIES_MPAGE_Enableconvertcombotobootstrapselect", StringUtil.BoolToStr( Wwputilities_Enableconvertcombotobootstrapselect));
         GxWebStd.gx_hidden_field( context, "WWPUTILITIES_MPAGE_Allowcolumnresizing", StringUtil.BoolToStr( Wwputilities_Allowcolumnresizing));
         GxWebStd.gx_hidden_field( context, "WWPUTILITIES_MPAGE_Allowcolumnreordering", StringUtil.BoolToStr( Wwputilities_Allowcolumnreordering));
         GxWebStd.gx_hidden_field( context, "WWPUTILITIES_MPAGE_Allowcolumndragging", StringUtil.BoolToStr( Wwputilities_Allowcolumndragging));
         GxWebStd.gx_hidden_field( context, "WWPUTILITIES_MPAGE_Allowcolumnsrestore", StringUtil.BoolToStr( Wwputilities_Allowcolumnsrestore));
         GxWebStd.gx_hidden_field( context, "WWPUTILITIES_MPAGE_Pagbarincludegoto", StringUtil.BoolToStr( Wwputilities_Pagbarincludegoto));
         GxWebStd.gx_hidden_field( context, "WWPUTILITIES_MPAGE_Comboloadtype", StringUtil.RTrim( Wwputilities_Comboloadtype));
         GxWebStd.gx_hidden_field( context, "BOOKMARK_MODAL_MPAGE_Width", StringUtil.RTrim( Bookmark_modal_Width));
         GxWebStd.gx_hidden_field( context, "BOOKMARK_MODAL_MPAGE_Title", StringUtil.RTrim( Bookmark_modal_Title));
         GxWebStd.gx_hidden_field( context, "BOOKMARK_MODAL_MPAGE_Confirmtype", StringUtil.RTrim( Bookmark_modal_Confirmtype));
         GxWebStd.gx_hidden_field( context, "BOOKMARK_MODAL_MPAGE_Bodytype", StringUtil.RTrim( Bookmark_modal_Bodytype));
         GxWebStd.gx_hidden_field( context, "DDO_BOOKMARKS_MPAGE_Activeeventkey", StringUtil.RTrim( Ddo_bookmarks_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "vHTTPREQUEST_MPAGE_Baseurl", StringUtil.RTrim( AV40Httprequest.BaseURL));
         GxWebStd.gx_hidden_field( context, "FORM_MPAGE_Caption", StringUtil.RTrim( (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Caption));
         GxWebStd.gx_hidden_field( context, "vNOTIFICATIONINFO_MPAGE_Message", AV22NotificationInfo.gxTpr_Message);
         GxWebStd.gx_hidden_field( context, "DDC_NOTIFICATIONSWC_MPAGE_Icon", StringUtil.RTrim( Ddc_notificationswc_Icon));
         GxWebStd.gx_hidden_field( context, "DDC_NOTIFICATIONSWC_MPAGE_Icon", StringUtil.RTrim( Ddc_notificationswc_Icon));
         GxWebStd.gx_hidden_field( context, "DDO_BOOKMARKS_MPAGE_Activeeventkey", StringUtil.RTrim( Ddo_bookmarks_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "FORM_MPAGE_Caption", StringUtil.RTrim( (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Caption));
      }

      protected void RenderHtmlCloseForm2R2( )
      {
         SendCloseFormHiddens( ) ;
         SendSecurityToken((string)(sPrefix));
         if ( ! isFullAjaxMode( ) )
         {
            getDataAreaObject().RenderHtmlCloseForm();
         }
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         if ( ! ( WebComp_Wwpaux_wc == null ) )
         {
            WebComp_Wwpaux_wc.componentjscripts();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 211160), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 211160), false, true);
         context.AddJavascriptSource("calendar-pt.js", "?"+context.GetBuildNumber( 211160), false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/slimmenu/jquery.slimmenu.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVHorizontalMenu/DVHorizontalMenuRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVMessage/pnotify.custom.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVMessage/DVMessageRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Tooltip/BootstrapTooltipRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Mask/jquery.mask.js", "", false, true);
         context.AddJavascriptSource("DVelop/WorkWithPlusUtilities/BootstrapSelect.js", "", false, true);
         context.AddJavascriptSource("DVelop/WorkWithPlusUtilities/WorkWithPlusUtilitiesRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DatePicker/DatePickerRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.AddJavascriptSource("wwpbaseobjects/workwithplusmasterpage.js", "?2023828212541", false, true);
         context.WriteHtmlTextNl( "</body>") ;
         context.WriteHtmlTextNl( "</html>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.WorkWithPlusMasterPage" ;
      }

      public override string GetPgmdesc( )
      {
         return "Master Page" ;
      }

      protected void WB2R0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            RenderHtmlHeaders( ) ;
            RenderHtmlOpenForm( ) ;
            if ( ! ShowMPWhenPopUp( ) && context.isPopUpObject( ) )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableOutput();
               }
               if ( context.isSpaRequest( ) )
               {
                  disableJsOutput();
               }
               /* Content placeholder */
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gx-content-placeholder");
               context.WriteHtmlText( ">") ;
               if ( ! isFullAjaxMode( ) )
               {
                  getDataAreaObject().RenderHtmlContent();
               }
               context.WriteHtmlText( "</div>") ;
               if ( context.isSpaRequest( ) )
               {
                  disableOutput();
               }
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
               wbLoad = true;
               return  ;
            }
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", divLayoutmaintable_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MasterHeaderCell navbar-fixed-top CellPaddingLeftRight0XS", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableheader_Internalname, 1, 0, "px", 0, "px", "TableHeader", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "hidden-xs", "start", "top", "", "", "div");
            /* Static images/pictures */
            ClassString = "ImageTop" + " " + ((StringUtil.StrCmp(imgHeader_gximage, "")==0) ? "GX_Image_core_TresoryLogo01_Class" : "GX_Image_"+imgHeader_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "9108a0d1-5515-426d-b4d1-6d0cf92defee", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgHeader_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" ", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WWPBaseObjects\\WorkWithPlusMasterPage.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "HorizontalMenuCell CellPaddingLeftRight0XS CellPaddingLeft30", "start", "top", "", "flex-grow:1;", "div");
            /* User Defined Control */
            ucUcmenu.SetProperty("Cls", Ucmenu_Cls);
            ucUcmenu.SetProperty("Menu", AV33DVelop_Menu);
            ucUcmenu.SetProperty("CollapsedTitle", Ucmenu_Collapsedtitle);
            ucUcmenu.SetProperty("MoreOptionEnabled", Ucmenu_Moreoptionenabled);
            ucUcmenu.SetProperty("MoreOptionType", Ucmenu_Moreoptiontype);
            ucUcmenu.SetProperty("MoreOptionCaption", Ucmenu_Moreoptioncaption);
            ucUcmenu.SetProperty("MoreOptionIcon", Ucmenu_Moreoptionicon);
            ucUcmenu.Render(context, "dvelop.dvhorizontalmenu", Ucmenu_Internalname, "UCMENU_MPAGEContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "CellHeaderBar hidden-xs", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableuserrole_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDdo_bookmarks.SetProperty("IconType", Ddo_bookmarks_Icontype);
            ucDdo_bookmarks.SetProperty("Icon", Ddo_bookmarks_Icon);
            ucDdo_bookmarks.SetProperty("Caption", Ddo_bookmarks_Caption);
            ucDdo_bookmarks.SetProperty("Cls", Ddo_bookmarks_Cls);
            ucDdo_bookmarks.SetProperty("DropDownOptionsData", AV14BookmarksData);
            ucDdo_bookmarks.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_bookmarks_Internalname, "DDO_BOOKMARKS_MPAGEContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDdc_notificationswc.SetProperty("IconType", Ddc_notificationswc_Icontype);
            ucDdc_notificationswc.SetProperty("Icon", Ddc_notificationswc_Icon);
            ucDdc_notificationswc.SetProperty("Caption", Ddc_notificationswc_Caption);
            ucDdc_notificationswc.SetProperty("Cls", Ddc_notificationswc_Cls);
            ucDdc_notificationswc.Render(context, "dvelop.gxbootstrap.ddcomponent", Ddc_notificationswc_Internalname, "DDC_NOTIFICATIONSWC_MPAGEContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "MasterTopIconsCell", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDdc_adminag.SetProperty("IconType", Ddc_adminag_Icontype);
            ucDdc_adminag.SetProperty("Icon", Ddc_adminag_Icon);
            ucDdc_adminag.SetProperty("Caption", Ddc_adminag_Caption);
            ucDdc_adminag.SetProperty("Cls", Ddc_adminag_Cls);
            ucDdc_adminag.SetProperty("ComponentWidth", Ddc_adminag_Componentwidth);
            ucDdc_adminag.Render(context, "dvelop.gxbootstrap.ddcomponent", Ddc_adminag_Internalname, "DDC_ADMINAG_MPAGEContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "MasterTopIconsCell", "start", "top", "", "flex-grow:1;", "div");
            /* User Defined Control */
            ucDdc_runtimedesignsettings.SetProperty("IconType", Ddc_runtimedesignsettings_Icontype);
            ucDdc_runtimedesignsettings.SetProperty("Icon", Ddc_runtimedesignsettings_Icon);
            ucDdc_runtimedesignsettings.SetProperty("Caption", Ddc_runtimedesignsettings_Caption);
            ucDdc_runtimedesignsettings.SetProperty("Tooltip", Ddc_runtimedesignsettings_Tooltip);
            ucDdc_runtimedesignsettings.SetProperty("Cls", Ddc_runtimedesignsettings_Cls);
            ucDdc_runtimedesignsettings.SetProperty("ComponentWidth", Ddc_runtimedesignsettings_Componentwidth);
            ucDdc_runtimedesignsettings.Render(context, "dvelop.gxbootstrap.ddcomponent", Ddc_runtimedesignsettings_Internalname, "DDC_RUNTIMEDESIGNSETTINGS_MPAGEContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellTableContentWithFooter", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellTitleMasterHorizontalMenu_HeaderFixed", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabletitle_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblocktitle_Internalname, lblTextblocktitle_Caption, "", "", lblTextblocktitle_Jsonclick, "'"+""+"'"+",true,"+"'"+"E_MPAGE."+"'", "", "TextBlockTitleMaster", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects\\WorkWithPlusMasterPage.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSubtitle_Internalname, lblSubtitle_Caption, "", "", lblSubtitle_Jsonclick, "'"+""+"'"+",true,"+"'"+"E_MPAGE."+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_WWPBaseObjects\\WorkWithPlusMasterPage.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellTableContentHorizontalMenu", "start", "top", "", "", "div");
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            /* Content placeholder */
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-content-placeholder");
            context.WriteHtmlText( ">") ;
            if ( ! isFullAjaxMode( ) )
            {
               getDataAreaObject().RenderHtmlContent();
            }
            context.WriteHtmlText( "</div>") ;
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MasterFooterCellHM", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablefooter_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "justify-content:center;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockfooter_Internalname, "© 2023 Todos os Direitos Reservados | TRESORY BANK INSTITUIÇÃO DE PAGAMENTOS S.A", "", "", lblTextblockfooter_Jsonclick, "'"+""+"'"+",true,"+"'"+"E_MPAGE."+"'", "", "FooterText", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects\\WorkWithPlusMasterPage.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucUcmessage.SetProperty("StopOnError", Ucmessage_Stoponerror);
            ucUcmessage.Render(context, "dvelop.dvmessage", Ucmessage_Internalname, "UCMESSAGE_MPAGEContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucUctooltip.Render(context, "dvelop.gxbootstrap.tooltip", Uctooltip_Internalname, "UCTOOLTIP_MPAGEContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucWwputilities.SetProperty("EnableFixObjectFitCover", Wwputilities_Enablefixobjectfitcover);
            ucWwputilities.SetProperty("EnableFloatingLabels", Wwputilities_Enablefloatinglabels);
            ucWwputilities.SetProperty("EmpowerTabs", Wwputilities_Empowertabs);
            ucWwputilities.SetProperty("EnableUpdateRowSelectionStatus", Wwputilities_Enableupdaterowselectionstatus);
            ucWwputilities.SetProperty("EnableConvertComboToBootstrapSelect", Wwputilities_Enableconvertcombotobootstrapselect);
            ucWwputilities.SetProperty("AllowColumnResizing", Wwputilities_Allowcolumnresizing);
            ucWwputilities.SetProperty("AllowColumnReordering", Wwputilities_Allowcolumnreordering);
            ucWwputilities.SetProperty("AllowColumnDragging", Wwputilities_Allowcolumndragging);
            ucWwputilities.SetProperty("AllowColumnsRestore", Wwputilities_Allowcolumnsrestore);
            ucWwputilities.SetProperty("PagBarIncludeGoTo", Wwputilities_Pagbarincludegoto);
            ucWwputilities.SetProperty("ComboLoadType", Wwputilities_Comboloadtype);
            ucWwputilities.Render(context, "wwp.workwithplusutilities_fal", Wwputilities_Internalname, "WWPUTILITIES_MPAGEContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucWwpdatepicker.Render(context, "wwp.datepicker", Wwpdatepicker_Internalname, "WWPDATEPICKER_MPAGEContainer");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',true,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavPickerdummyvariable_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavPickerdummyvariable_Internalname, context.localUtil.Format(AV47PickerDummyVariable, "99/99/99"), context.localUtil.Format( AV47PickerDummyVariable, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",true,"+"'"+"E_MPAGE."+"'", "", "", "", "", edtavPickerdummyvariable_Jsonclick, 0, "Invisible", "", "", "", "", 1, 1, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WWPBaseObjects\\WorkWithPlusMasterPage.htm");
            GxWebStd.gx_bitmap( context, edtavPickerdummyvariable_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(1==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WWPBaseObjects\\WorkWithPlusMasterPage.htm");
            context.WriteHtmlTextNl( "</div>") ;
            wb_table1_60_2R2( true) ;
         }
         else
         {
            wb_table1_60_2R2( false) ;
         }
         return  ;
      }

      protected void wb_table1_60_2R2e( bool wbgen )
      {
         if ( wbgen )
         {
            /* Div Control */
            GxWebStd.gx_div_start( context, divDiv_wwpauxwc_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "MPW0066"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpMPW0066"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpMPW0066"+"");
                  }
                  WebComp_Wwpaux_wc.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START2R2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP2R0( ) ;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            if ( getDataAreaObject().ExecuteStartEvent() != 0 )
            {
               setAjaxCallMode();
            }
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
      }

      protected void WS2R2( )
      {
         START2R2( ) ;
         EVT2R2( ) ;
      }

      protected void EVT2R2( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               sEvt = cgiGet( "_EventName");
               EvtGridId = cgiGet( "_EventGridId");
               EvtRowId = cgiGet( "_EventRowId");
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
                        if ( StringUtil.StrCmp(sEvt, "RFR_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "DDO_BOOKMARKS_MPAGE.ONOPTIONCLICKED_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           E112R2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "DDC_NOTIFICATIONSWC_MPAGE.ONLOADCOMPONENT_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           E122R2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "DDC_ADMINAG_MPAGE.ONLOADCOMPONENT_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           E132R2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "DDC_RUNTIMEDESIGNSETTINGS_MPAGE.ONLOADCOMPONENT_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           E142R2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "BOOKMARK_MODAL_MPAGE.CLOSE_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           E152R2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "BOOKMARK_MODAL_MPAGE.ONLOADCOMPONENT_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           E162R2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "START_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E172R2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ONMESSAGE_GX1_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Onmessage_gx1 */
                           E182R2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "REFRESH_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Refresh */
                           E192R2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "GLOBALEVENTS_MPAGE.MASTER_REFRESHHEADER_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           E202R2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LOAD_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Load */
                           E212R2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           if ( ! wbErr )
                           {
                              Rfr0gs = false;
                              if ( ! Rfr0gs )
                              {
                              }
                              dynload_actions( ) ;
                           }
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ONMESSAGE_GX1_MPAGE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Onmessage_gx1 */
                           E182R2 ();
                           dynload_actions( ) ;
                        }
                     }
                     else
                     {
                     }
                  }
                  else if ( StringUtil.StrCmp(sEvtType, "M") == 0 )
                  {
                     sEvtType = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-2));
                     sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-6));
                     nCmpId = (short)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                     if ( nCmpId == 66 )
                     {
                        OldWwpaux_wc = cgiGet( "MPW0066");
                        if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                        {
                           WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                           WebComp_Wwpaux_wc.ComponentInit();
                           WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                           WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                        }
                        if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                        {
                           WebComp_Wwpaux_wc.componentprocess("MPW0066", "", sEvt);
                        }
                        WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                     }
                  }
                  if ( context.wbHandled == 0 )
                  {
                     getDataAreaObject().DispatchEvents();
                  }
                  context.wbHandled = 1;
               }
            }
         }
      }

      protected void WE2R2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm2R2( ) ;
            }
         }
      }

      protected void PA2R2( )
      {
         if ( nDonePA == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
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
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = edtavPickerdummyvariable_Internalname;
               AssignAttri("", true, "GX_FocusControl", GX_FocusControl);
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
         RF2R2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF2R2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( ShowMPWhenPopUp( ) || ! context.isPopUpObject( ) )
         {
            /* Execute user event: Refresh */
            E192R2 ();
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
            {
               if ( 1 != 0 )
               {
                  if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                  {
                     WebComp_Wwpaux_wc.componentstart();
                  }
               }
            }
            gxdyncontrolsrefreshing = true;
            fix_multi_value_controls( ) ;
            gxdyncontrolsrefreshing = false;
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E212R2 ();
            WB2R0( ) ;
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
         }
      }

      protected void send_integrity_lvl_hashes2R2( )
      {
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2R0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E172R2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vDVELOP_MENU_MPAGE"), AV33DVelop_Menu);
            ajax_req_read_hidden_sdt(cgiGet( "vBOOKMARKSDATA_MPAGE"), AV14BookmarksData);
            ajax_req_read_hidden_sdt(cgiGet( "vNOTIFICATIONINFO_MPAGE"), AV22NotificationInfo);
            /* Read saved values. */
            Ucmenu_Cls = cgiGet( "UCMENU_MPAGE_Cls");
            Ucmenu_Collapsedtitle = cgiGet( "UCMENU_MPAGE_Collapsedtitle");
            Ucmenu_Moreoptionenabled = StringUtil.StrToBool( cgiGet( "UCMENU_MPAGE_Moreoptionenabled"));
            Ucmenu_Moreoptiontype = cgiGet( "UCMENU_MPAGE_Moreoptiontype");
            Ucmenu_Moreoptioncaption = cgiGet( "UCMENU_MPAGE_Moreoptioncaption");
            Ucmenu_Moreoptionicon = cgiGet( "UCMENU_MPAGE_Moreoptionicon");
            Ddo_bookmarks_Icontype = cgiGet( "DDO_BOOKMARKS_MPAGE_Icontype");
            Ddo_bookmarks_Icon = cgiGet( "DDO_BOOKMARKS_MPAGE_Icon");
            Ddo_bookmarks_Tooltip = cgiGet( "DDO_BOOKMARKS_MPAGE_Tooltip");
            Ddo_bookmarks_Cls = cgiGet( "DDO_BOOKMARKS_MPAGE_Cls");
            Ddo_bookmarks_Titlecontrolalign = cgiGet( "DDO_BOOKMARKS_MPAGE_Titlecontrolalign");
            Ddc_notificationswc_Icontype = cgiGet( "DDC_NOTIFICATIONSWC_MPAGE_Icontype");
            Ddc_notificationswc_Icon = cgiGet( "DDC_NOTIFICATIONSWC_MPAGE_Icon");
            Ddc_notificationswc_Caption = cgiGet( "DDC_NOTIFICATIONSWC_MPAGE_Caption");
            Ddc_notificationswc_Cls = cgiGet( "DDC_NOTIFICATIONSWC_MPAGE_Cls");
            Ddc_adminag_Icontype = cgiGet( "DDC_ADMINAG_MPAGE_Icontype");
            Ddc_adminag_Icon = cgiGet( "DDC_ADMINAG_MPAGE_Icon");
            Ddc_adminag_Caption = cgiGet( "DDC_ADMINAG_MPAGE_Caption");
            Ddc_adminag_Cls = cgiGet( "DDC_ADMINAG_MPAGE_Cls");
            Ddc_adminag_Componentwidth = (int)(Math.Round(context.localUtil.CToN( cgiGet( "DDC_ADMINAG_MPAGE_Componentwidth"), ",", "."), 18, MidpointRounding.ToEven));
            Ddc_runtimedesignsettings_Icontype = cgiGet( "DDC_RUNTIMEDESIGNSETTINGS_MPAGE_Icontype");
            Ddc_runtimedesignsettings_Icon = cgiGet( "DDC_RUNTIMEDESIGNSETTINGS_MPAGE_Icon");
            Ddc_runtimedesignsettings_Tooltip = cgiGet( "DDC_RUNTIMEDESIGNSETTINGS_MPAGE_Tooltip");
            Ddc_runtimedesignsettings_Cls = cgiGet( "DDC_RUNTIMEDESIGNSETTINGS_MPAGE_Cls");
            Ddc_runtimedesignsettings_Componentwidth = (int)(Math.Round(context.localUtil.CToN( cgiGet( "DDC_RUNTIMEDESIGNSETTINGS_MPAGE_Componentwidth"), ",", "."), 18, MidpointRounding.ToEven));
            Ucmessage_Stoponerror = StringUtil.StrToBool( cgiGet( "UCMESSAGE_MPAGE_Stoponerror"));
            Wwputilities_Enablefixobjectfitcover = StringUtil.StrToBool( cgiGet( "WWPUTILITIES_MPAGE_Enablefixobjectfitcover"));
            Wwputilities_Enablefloatinglabels = StringUtil.StrToBool( cgiGet( "WWPUTILITIES_MPAGE_Enablefloatinglabels"));
            Wwputilities_Empowertabs = StringUtil.StrToBool( cgiGet( "WWPUTILITIES_MPAGE_Empowertabs"));
            Wwputilities_Enableupdaterowselectionstatus = StringUtil.StrToBool( cgiGet( "WWPUTILITIES_MPAGE_Enableupdaterowselectionstatus"));
            Wwputilities_Enableconvertcombotobootstrapselect = StringUtil.StrToBool( cgiGet( "WWPUTILITIES_MPAGE_Enableconvertcombotobootstrapselect"));
            Wwputilities_Allowcolumnresizing = StringUtil.StrToBool( cgiGet( "WWPUTILITIES_MPAGE_Allowcolumnresizing"));
            Wwputilities_Allowcolumnreordering = StringUtil.StrToBool( cgiGet( "WWPUTILITIES_MPAGE_Allowcolumnreordering"));
            Wwputilities_Allowcolumndragging = StringUtil.StrToBool( cgiGet( "WWPUTILITIES_MPAGE_Allowcolumndragging"));
            Wwputilities_Allowcolumnsrestore = StringUtil.StrToBool( cgiGet( "WWPUTILITIES_MPAGE_Allowcolumnsrestore"));
            Wwputilities_Pagbarincludegoto = StringUtil.StrToBool( cgiGet( "WWPUTILITIES_MPAGE_Pagbarincludegoto"));
            Wwputilities_Comboloadtype = cgiGet( "WWPUTILITIES_MPAGE_Comboloadtype");
            Bookmark_modal_Width = cgiGet( "BOOKMARK_MODAL_MPAGE_Width");
            Bookmark_modal_Title = cgiGet( "BOOKMARK_MODAL_MPAGE_Title");
            Bookmark_modal_Confirmtype = cgiGet( "BOOKMARK_MODAL_MPAGE_Confirmtype");
            Bookmark_modal_Bodytype = cgiGet( "BOOKMARK_MODAL_MPAGE_Bodytype");
            Ddc_notificationswc_Icon = cgiGet( "DDC_NOTIFICATIONSWC_MPAGE_Icon");
            Ddo_bookmarks_Activeeventkey = cgiGet( "DDO_BOOKMARKS_MPAGE_Activeeventkey");
            (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Caption = cgiGet( "FORM_MPAGE_Caption");
            /* Read variables values. */
            if ( context.localUtil.VCDate( cgiGet( edtavPickerdummyvariable_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Picker Dummy Variable"}), 1, "vPICKERDUMMYVARIABLE_MPAGE");
               GX_FocusControl = edtavPickerdummyvariable_Internalname;
               AssignAttri("", true, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV47PickerDummyVariable = DateTime.MinValue;
               AssignAttri("", true, "AV47PickerDummyVariable", context.localUtil.Format(AV47PickerDummyVariable, "99/99/99"));
            }
            else
            {
               AV47PickerDummyVariable = context.localUtil.CToD( cgiGet( edtavPickerdummyvariable_Internalname), 2);
               AssignAttri("", true, "AV47PickerDummyVariable", context.localUtil.Format(AV47PickerDummyVariable, "99/99/99"));
            }
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
         E172R2 ();
         if (returnInSub) return;
      }

      protected void E172R2( )
      {
         /* Start Routine */
         returnInSub = false;
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Headerrawhtml = "<link rel=\"shortcut icon\" type=\"image/x-icon\" href=\""+context.convertURL( (string)(context.GetImagePath( "f624b55c-cc7b-46ab-a6d3-3382b6d0bd43", "", context.GetTheme( ))))+"\">";
         divLayoutmaintable_Class = "MainContainerWithFooter";
         AssignProp("", true, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         AV5GAMApplication = new GeneXus.Programs.genexussecurity.SdtGAMApplication(context).get();
         if ( AV5GAMApplication.gxTpr_Mainmenuid == 0 )
         {
            new GeneXus.Programs.wwpbaseobjects.initializegammenuexample(context ).execute( ) ;
            CallWebObject(formatLink("home.aspx") );
            context.wjLocDisableFrm = 1;
         }
         AV6GAMMenuAdditionalParameters.gxTpr_Loadproperties = true;
         AV7GAMMEnuOptionList = AV5GAMApplication.getusermainmenu(AV6GAMMenuAdditionalParameters, out  AV10GAMErrorCollection);
         GXt_objcol_SdtDVelop_Menu_Item1 = AV33DVelop_Menu;
         new GeneXus.Programs.wwpbaseobjects.loadmenu_gammenu(context ).execute(  AV7GAMMEnuOptionList.gxTpr_Nodes,  AV5GAMApplication.gxTpr_Mainmenuid,  0, out  GXt_objcol_SdtDVelop_Menu_Item1) ;
         AV33DVelop_Menu = GXt_objcol_SdtDVelop_Menu_Item1;
         AV14BookmarksData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV15BookmarksDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV15BookmarksDataItem.gxTpr_Title = "Bookmark Page";
         AV15BookmarksDataItem.gxTpr_Fonticon = "fas fa-star FontIconTopRightActions";
         AV15BookmarksDataItem.gxTpr_Eventkey = "Bookmark";
         AV15BookmarksDataItem.gxTpr_Isdivider = false;
         AV14BookmarksData.Add(AV15BookmarksDataItem, 0);
         AV12GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).get();
         AV34UserName = (String.IsNullOrEmpty(StringUtil.RTrim( AV12GAMUser.gxTpr_Firstname)) ? AV12GAMUser.gxTpr_Name : StringUtil.Trim( AV12GAMUser.gxTpr_Firstname)+" "+StringUtil.Trim( AV12GAMUser.gxTpr_Lastname));
         AV8GAMRoleCollection = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).getroles(out  AV10GAMErrorCollection);
         AV49GXV1 = 1;
         while ( AV49GXV1 <= AV8GAMRoleCollection.Count )
         {
            AV9GAMRole = ((GeneXus.Programs.genexussecurity.SdtGAMRole)AV8GAMRoleCollection.Item(AV49GXV1));
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35RolesDescriptions)) )
            {
               AV35RolesDescriptions += ", ";
               AssignAttri("", true, "AV35RolesDescriptions", AV35RolesDescriptions);
            }
            AV35RolesDescriptions += (String.IsNullOrEmpty(StringUtil.RTrim( AV9GAMRole.gxTpr_Description)) ? AV9GAMRole.gxTpr_Name : AV9GAMRole.gxTpr_Description);
            AssignAttri("", true, "AV35RolesDescriptions", AV35RolesDescriptions);
            AV49GXV1 = (int)(AV49GXV1+1);
         }
         Ddc_adminag_Caption = AV34UserName;
         ucDdc_adminag.SendProperty(context, "", true, Ddc_adminag_Internalname, "Caption", Ddc_adminag_Caption);
         Ddo_bookmarks_Tooltip = "Marcadores";
         ucDdo_bookmarks.SendProperty(context, "", true, Ddo_bookmarks_Internalname, "Tooltip", Ddo_bookmarks_Tooltip);
         Ddo_bookmarks_Titlecontrolalign = "Left";
         ucDdo_bookmarks.SendProperty(context, "", true, Ddo_bookmarks_Internalname, "TitleControlAlign", Ddo_bookmarks_Titlecontrolalign);
         if ( StringUtil.StrCmp(AV37WebSession.Get("ClientInformationSaved"), "Y") != 0 )
         {
            new GeneXus.Programs.wwpbaseobjects.notifications.web.wwp_registerwebclient(context ).execute(  new GeneXus.Core.genexus.client.SdtClientInformation(context).gxTpr_Id,  (short)(context.GetBrowserType( )),  context.GetBrowserVersion( ),  new GeneXus.Programs.wwpbaseobjects.wwp_getloggeduserid(context).executeUdp( )) ;
            AV37WebSession.Set("ClientInformationSaved", "Y");
         }
         /* Execute user subroutine: 'LOADNOTIFICATIONS' */
         S112 ();
         if (returnInSub) return;
         if ( StringUtil.StrCmp(AV40Httprequest.Method, "GET") == 0 )
         {
            GXt_SdtWWP_DesignSystemSettings2 = AV26WWP_DesignSystemSettings;
            new GeneXus.Programs.wwpbaseobjects.wwp_getdesignsystemsettings(context ).execute( out  GXt_SdtWWP_DesignSystemSettings2) ;
            AV26WWP_DesignSystemSettings = GXt_SdtWWP_DesignSystemSettings2;
            this.executeExternalObjectMethod("", true, "gx.core.ds", "setOption", new Object[] {(string)"base-color",AV26WWP_DesignSystemSettings.gxTpr_Basecolor}, false);
            this.executeExternalObjectMethod("", true, "gx.core.ds", "setOption", new Object[] {(string)"background-color",AV26WWP_DesignSystemSettings.gxTpr_Backgroundstyle}, false);
            this.executeExternalObjectMethod("", true, "gx.core.ds", "setOption", new Object[] {(string)"font-size",AV26WWP_DesignSystemSettings.gxTpr_Fontsize}, false);
            this.executeExternalObjectMethod("", true, "WWPActions", "EmpoweredGrids_Refresh", new Object[] {}, false);
         }
      }

      protected void E112R2( )
      {
         /* Ddo_bookmarks_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_bookmarks_Activeeventkey, "Bookmark") == 0 )
         {
            /* Execute user subroutine: 'DO BOOKMARK' */
            S122 ();
            if (returnInSub) return;
         }
         if ( StringUtil.StrCmp(Ddo_bookmarks_Activeeventkey, "AddBookmark") == 0 )
         {
            this.executeUsercontrolMethod("", true, "BOOKMARK_MODAL_MPAGEContainer", "Confirm", "", new Object[] {});
         }
         else if ( StringUtil.StrCmp(Ddo_bookmarks_Activeeventkey, "ManageBookmarks") == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wwpbaseobjects.managefilters.aspx"+UrlEncode(StringUtil.RTrim("AppBookmarks"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
         }
      }

      protected void E162R2( )
      {
         /* Bookmark_modal_Onloadcomponent Routine */
         returnInSub = false;
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wwpaux_wc = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wwpaux_wc_Component), StringUtil.Lower( "WWPBaseObjects.EditBookmark")) != 0 )
         {
            WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", "wwpbaseobjects.editbookmark", new Object[] {context} );
            WebComp_Wwpaux_wc.ComponentInit();
            WebComp_Wwpaux_wc.Name = "WWPBaseObjects.EditBookmark";
            WebComp_Wwpaux_wc_Component = "WWPBaseObjects.EditBookmark";
         }
         if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
         {
            WebComp_Wwpaux_wc.setjustcreated();
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"MPW0066",(string)"",AV40Httprequest.BaseURL+AV40Httprequest.ScriptName+(String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV40Httprequest.QueryString))) ? "" : "?"+AV40Httprequest.QueryString),(string)AV20ProgramDescription});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)""+""+""+""+""+""+""+""+""+"",(string)"",(string)""+""+""+"",(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpMPW0066"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void E152R2( )
      {
         /* Bookmark_modal_Close Routine */
         returnInSub = false;
         context.DoAjaxRefresh();
      }

      protected void E122R2( )
      {
         /* Ddc_notificationswc_Onloadcomponent Routine */
         returnInSub = false;
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wwpaux_wc = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wwpaux_wc_Component), StringUtil.Lower( "WWPBaseObjects.Notifications.Common.WWP_MasterPageNotificationsWC")) != 0 )
         {
            WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", "wwpbaseobjects.notifications.common.wwp_masterpagenotificationswc", new Object[] {context} );
            WebComp_Wwpaux_wc.ComponentInit();
            WebComp_Wwpaux_wc.Name = "WWPBaseObjects.Notifications.Common.WWP_MasterPageNotificationsWC";
            WebComp_Wwpaux_wc_Component = "WWPBaseObjects.Notifications.Common.WWP_MasterPageNotificationsWC";
         }
         if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
         {
            WebComp_Wwpaux_wc.setjustcreated();
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"MPW0066",(string)""});
            WebComp_Wwpaux_wc.componentbind(new Object[] {});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpMPW0066"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void E132R2( )
      {
         /* Ddc_adminag_Onloadcomponent Routine */
         returnInSub = false;
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wwpaux_wc = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wwpaux_wc_Component), StringUtil.Lower( "WWPBaseObjects.WWP_MasterPageTopActionsWC")) != 0 )
         {
            WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", "wwpbaseobjects.wwp_masterpagetopactionswc", new Object[] {context} );
            WebComp_Wwpaux_wc.ComponentInit();
            WebComp_Wwpaux_wc.Name = "WWPBaseObjects.WWP_MasterPageTopActionsWC";
            WebComp_Wwpaux_wc_Component = "WWPBaseObjects.WWP_MasterPageTopActionsWC";
         }
         if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
         {
            WebComp_Wwpaux_wc.setjustcreated();
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"MPW0066",(string)""});
            WebComp_Wwpaux_wc.componentbind(new Object[] {});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpMPW0066"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void E142R2( )
      {
         /* Ddc_runtimedesignsettings_Onloadcomponent Routine */
         returnInSub = false;
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wwpaux_wc = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wwpaux_wc_Component), StringUtil.Lower( "WWPBaseObjects.WWP_MasterPageRuntimeSettings")) != 0 )
         {
            WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", "wwpbaseobjects.wwp_masterpageruntimesettings", new Object[] {context} );
            WebComp_Wwpaux_wc.ComponentInit();
            WebComp_Wwpaux_wc.Name = "WWPBaseObjects.WWP_MasterPageRuntimeSettings";
            WebComp_Wwpaux_wc_Component = "WWPBaseObjects.WWP_MasterPageRuntimeSettings";
         }
         if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
         {
            WebComp_Wwpaux_wc.setjustcreated();
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"MPW0066",(string)""});
            WebComp_Wwpaux_wc.componentbind(new Object[] {});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpMPW0066"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void S122( )
      {
         /* 'DO BOOKMARK' Routine */
         returnInSub = false;
         this.executeUsercontrolMethod("", true, "BOOKMARK_MODAL_MPAGEContainer", "Confirm", "", new Object[] {});
      }

      protected void E182R2( )
      {
         /* Onmessage_gx1 Routine */
         returnInSub = false;
         if ( StringUtil.StartsWith( AV22NotificationInfo.gxTpr_Id, "WebNotification#") )
         {
            AV23WWP_WebNotification.FromJSonString(AV22NotificationInfo.gxTpr_Message, null);
            if ( ! new GeneXus.Programs.wwpbaseobjects.notifications.web.wwp_isreceivedwebnotification(context).executeUdp(  AV23WWP_WebNotification.gxTpr_Wwpwebnotificationid) )
            {
               new GeneXus.Programs.wwpbaseobjects.notifications.web.wwp_setwebnotificationreceived(context ).execute(  AV23WWP_WebNotification.gxTpr_Wwpwebnotificationid) ;
               AV24WWP_UserExtended.Load(new GeneXus.Programs.wwpbaseobjects.wwp_getloggeduserid(context).executeUdp( ));
               if ( AV24WWP_UserExtended.gxTpr_Wwpuserextendeddesktopnotif )
               {
                  if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
                  {
                     gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
                  }
                  GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
                  GXEncryptionTmp = "wwpbaseobjects.notifications.common.wwp_visualizenotification.aspx"+UrlEncode(StringUtil.LTrimStr(AV23WWP_WebNotification.gxTpr_Wwpnotificationid,10,0));
                  GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetdesktopnotificationmsg(context).executeUdp(  AV23WWP_WebNotification.gxTpr_Wwpwebnotificationtitle,  AV23WWP_WebNotification.gxTpr_Wwpwebnotificationtext,  AV23WWP_WebNotification.gxTpr_Wwpwebnotificationicon,  formatLink("wwpbaseobjects.notifications.common.wwp_visualizenotification.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)));
               }
            }
         }
         /* Execute user subroutine: 'LOADNOTIFICATIONS' */
         S112 ();
         if (returnInSub) return;
      }

      protected void E192R2( )
      {
         /* Refresh Routine */
         returnInSub = false;
         lblTextblocktitle_Caption = (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Caption;
         AssignProp("", true, lblTextblocktitle_Internalname, "Caption", lblTextblocktitle_Caption, true);
         GXt_boolean3 = false;
         new GeneXus.Programs.wwpbaseobjects.loadbreadcrumb(context ).execute(  AV33DVelop_Menu,  AV40Httprequest.ScriptName, ref  AV48Breadcrumb, ref  GXt_boolean3) ;
         AssignAttri("", true, "AV48Breadcrumb", AV48Breadcrumb);
         GxWebStd.gx_hidden_field( context, "gxhash_vBREADCRUMB_MPAGE", GetSecureSignedToken( "gxmpage_", StringUtil.RTrim( context.localUtil.Format( AV48Breadcrumb, "")), context));
         if ( String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV48Breadcrumb))) )
         {
            AV48Breadcrumb = AV37WebSession.Get("LastBreadcrumb");
            AssignAttri("", true, "AV48Breadcrumb", AV48Breadcrumb);
            GxWebStd.gx_hidden_field( context, "gxhash_vBREADCRUMB_MPAGE", GetSecureSignedToken( "gxmpage_", StringUtil.RTrim( context.localUtil.Format( AV48Breadcrumb, "")), context));
         }
         else
         {
            AV37WebSession.Set("LastBreadcrumb", AV48Breadcrumb);
         }
         lblSubtitle_Caption = (String.IsNullOrEmpty(StringUtil.RTrim( AV48Breadcrumb)) ? StringUtil.Format( "<span class=\"%2\">%1</span>", Contentholder.Pgmdesc, "BreadCrumb", "", "", "", "", "", "", "") : AV48Breadcrumb);
         AssignProp("", true, lblSubtitle_Internalname, "Caption", lblSubtitle_Caption, true);
         /* Execute user subroutine: 'LOADBOOKMARKS' */
         S132 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", true, "AV14BookmarksData", AV14BookmarksData);
      }

      protected void E202R2( )
      {
         /* General\GlobalEvents_Master_refreshheader Routine */
         returnInSub = false;
         context.DoAjaxRefresh();
      }

      protected void S112( )
      {
         /* 'LOADNOTIFICATIONS' Routine */
         returnInSub = false;
         AV25NotificationsCount = 0;
         AV51Udparg1 = new GeneXus.Programs.wwpbaseobjects.wwp_getloggeduserid(context).executeUdp( );
         /* Optimized group. */
         /* Using cursor H002R2 */
         pr_default.execute(0, new Object[] {AV51Udparg1});
         cV25NotificationsCount = H002R2_AV25NotificationsCount[0];
         pr_default.close(0);
         AV25NotificationsCount = (short)(AV25NotificationsCount+cV25NotificationsCount*1);
         /* End optimized group. */
         this.executeUsercontrolMethod("", true, "DDC_NOTIFICATIONSWC_MPAGEContainer", "Update", "", new Object[] {((AV25NotificationsCount>0) ? StringUtil.Trim( StringUtil.Str( (decimal)(AV25NotificationsCount), 4, 0)) : ""),(string)Ddc_notificationswc_Icon});
      }

      protected void S132( )
      {
         /* 'LOADBOOKMARKS' Routine */
         returnInSub = false;
         AV14BookmarksData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV15BookmarksDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV15BookmarksDataItem.gxTpr_Eventkey = "AddBookmark";
         AV15BookmarksDataItem.gxTpr_Isdivider = false;
         AV14BookmarksData.Add(AV15BookmarksDataItem, 0);
         AV20ProgramDescription = Contentholder.Pgmdesc;
         AssignAttri("", true, "AV20ProgramDescription", AV20ProgramDescription);
         GxWebStd.gx_hidden_field( context, "gxhash_vPROGRAMDESCRIPTION_MPAGE", GetSecureSignedToken( "gxmpage_", StringUtil.RTrim( context.localUtil.Format( AV20ProgramDescription, "")), context));
         AV16CurrentURL = AV40Httprequest.BaseURL + AV40Httprequest.ScriptName + (String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV40Httprequest.QueryString))) ? "" : "?"+AV40Httprequest.QueryString);
         AV17GridStateCollection.FromXml(new GeneXus.Programs.wwpbaseobjects.loadmanagefiltersstate(context).executeUdp(  "AppBookmarks"), null, "Items", "");
         AV13BookmarkFound = false;
         AV52GXV2 = 1;
         while ( AV52GXV2 <= AV17GridStateCollection.Count )
         {
            AV18GridStateCollectionItem = ((GeneXus.Programs.wwpbaseobjects.SdtGridStateCollection_Item)AV17GridStateCollection.Item(AV52GXV2));
            if ( StringUtil.StrCmp(AV18GridStateCollectionItem.gxTpr_Gridstatexml, AV16CurrentURL) == 0 )
            {
               AV20ProgramDescription = AV18GridStateCollectionItem.gxTpr_Title;
               AssignAttri("", true, "AV20ProgramDescription", AV20ProgramDescription);
               GxWebStd.gx_hidden_field( context, "gxhash_vPROGRAMDESCRIPTION_MPAGE", GetSecureSignedToken( "gxmpage_", StringUtil.RTrim( context.localUtil.Format( AV20ProgramDescription, "")), context));
               AV13BookmarkFound = true;
               if (true) break;
            }
            AV52GXV2 = (int)(AV52GXV2+1);
         }
         if ( AV13BookmarkFound )
         {
            this.executeUsercontrolMethod("", true, "DDO_BOOKMARKS_MPAGEContainer", "Update", "", new Object[] {(string)"",(string)"fas fa-star HorizontalBorderColorActionGroupOnlyIcon "+"FontColorIconBookmarkTitleAdded"});
            AV15BookmarksDataItem.gxTpr_Title = "Editar favorito para esta página";
            AV15BookmarksDataItem.gxTpr_Fonticon = "fas fa-star "+"FontColorIconBookmarkAdded";
         }
         else
         {
            this.executeUsercontrolMethod("", true, "DDO_BOOKMARKS_MPAGEContainer", "Update", "", new Object[] {(string)"",(string)"far fa-star HorizontalBorderColorActionGroupOnlyIcon "+"FontColorIconBookmarkTitle"});
            AV15BookmarksDataItem.gxTpr_Title = "Crie um favorito para esta página";
            AV15BookmarksDataItem.gxTpr_Fonticon = "far fa-star "+"FontColorIconBookmark";
         }
         if ( AV17GridStateCollection.Count > 0 )
         {
            AV15BookmarksDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
            AV15BookmarksDataItem.gxTpr_Isdivider = true;
            AV14BookmarksData.Add(AV15BookmarksDataItem, 0);
            AV53GXV3 = 1;
            while ( AV53GXV3 <= AV17GridStateCollection.Count )
            {
               AV18GridStateCollectionItem = ((GeneXus.Programs.wwpbaseobjects.SdtGridStateCollection_Item)AV17GridStateCollection.Item(AV53GXV3));
               AV15BookmarksDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
               AV15BookmarksDataItem.gxTpr_Title = AV18GridStateCollectionItem.gxTpr_Title;
               AV15BookmarksDataItem.gxTpr_Link = AV18GridStateCollectionItem.gxTpr_Gridstatexml;
               GXt_char4 = AV21FontIcon;
               new GeneXus.Programs.wwpbaseobjects.getbookmarkfonticon(context ).execute(  StringUtil.StringReplace( AV18GridStateCollectionItem.gxTpr_Gridstatexml, AV40Httprequest.BaseURL, ""),  AV33DVelop_Menu, out  GXt_char4) ;
               AV21FontIcon = GXt_char4;
               AV15BookmarksDataItem.gxTpr_Fonticon = ((StringUtil.StrCmp(AV21FontIcon, "")==0) ? "FontColorIconBookmark fas fa-link" : "FontColorIconBookmark"+" "+AV21FontIcon);
               AV15BookmarksDataItem.gxTpr_Isdivider = false;
               AV14BookmarksData.Add(AV15BookmarksDataItem, 0);
               AV19IndexToAddItems = (short)(AV19IndexToAddItems+1);
               AssignAttri("", true, "AV19IndexToAddItems", StringUtil.LTrimStr( (decimal)(AV19IndexToAddItems), 4, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vINDEXTOADDITEMS_MPAGE", GetSecureSignedToken( "gxmpage_", context.localUtil.Format( (decimal)(AV19IndexToAddItems), "ZZZ9"), context));
               AV53GXV3 = (int)(AV53GXV3+1);
            }
            AV15BookmarksDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
            AV15BookmarksDataItem.gxTpr_Isdivider = true;
            AV14BookmarksData.Add(AV15BookmarksDataItem, 0);
            AV15BookmarksDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
            AV15BookmarksDataItem.gxTpr_Title = "Bookmark manager";
            AV15BookmarksDataItem.gxTpr_Fonticon = "fas fa-cog "+"FontColorIconBookmark";
            AV15BookmarksDataItem.gxTpr_Eventkey = "ManageBookmarks";
            AV15BookmarksDataItem.gxTpr_Isdivider = false;
            AV14BookmarksData.Add(AV15BookmarksDataItem, 0);
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E212R2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table1_60_2R2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablebookmark_modal_Internalname, tblTablebookmark_modal_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucBookmark_modal.SetProperty("Width", Bookmark_modal_Width);
            ucBookmark_modal.SetProperty("Title", Bookmark_modal_Title);
            ucBookmark_modal.SetProperty("ConfirmType", Bookmark_modal_Confirmtype);
            ucBookmark_modal.SetProperty("BodyType", Bookmark_modal_Bodytype);
            ucBookmark_modal.Render(context, "dvelop.gxbootstrap.confirmpanel", Bookmark_modal_Internalname, "BOOKMARK_MODAL_MPAGEContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"BOOKMARK_MODAL_MPAGEContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_60_2R2e( true) ;
         }
         else
         {
            wb_table1_60_2R2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
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
         PA2R2( ) ;
         WS2R2( ) ;
         WE2R2( ) ;
         this.cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      public override void master_styles( )
      {
         define_styles( ) ;
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("DVelop/DVHorizontalMenu/DVHorizontalMenu.css", "");
         AddStyleSheetFile("DVelop/DVMessage/DVMessage.css", "");
         AddStyleSheetFile("DVelop/Bootstrap/Shared/fontawesome_vlatest/css/all.min.css", "");
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
         AddStyleSheetFile("DVelop/Shared/daterangepicker/daterangepicker.css", "");
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         if ( ! ( WebComp_Wwpaux_wc == null ) )
         {
            if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
            {
               WebComp_Wwpaux_wc.componentthemes();
            }
         }
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)(getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Jscriptsrc.Item(idxLst))), "?2023828213960", true, true);
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
         context.AddJavascriptSource("wwpbaseobjects/workwithplusmasterpage.js", "?2023828213962", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/slimmenu/jquery.slimmenu.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVHorizontalMenu/DVHorizontalMenuRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVMessage/pnotify.custom.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVMessage/DVMessageRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Tooltip/BootstrapTooltipRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Mask/jquery.mask.js", "", false, true);
         context.AddJavascriptSource("DVelop/WorkWithPlusUtilities/BootstrapSelect.js", "", false, true);
         context.AddJavascriptSource("DVelop/WorkWithPlusUtilities/WorkWithPlusUtilitiesRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DatePicker/DatePickerRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         imgHeader_Internalname = "HEADER_MPAGE";
         Ucmenu_Internalname = "UCMENU_MPAGE";
         Ddo_bookmarks_Internalname = "DDO_BOOKMARKS_MPAGE";
         Ddc_notificationswc_Internalname = "DDC_NOTIFICATIONSWC_MPAGE";
         Ddc_adminag_Internalname = "DDC_ADMINAG_MPAGE";
         Ddc_runtimedesignsettings_Internalname = "DDC_RUNTIMEDESIGNSETTINGS_MPAGE";
         divTableuserrole_Internalname = "TABLEUSERROLE_MPAGE";
         divTableheader_Internalname = "TABLEHEADER_MPAGE";
         lblTextblocktitle_Internalname = "TEXTBLOCKTITLE_MPAGE";
         lblSubtitle_Internalname = "SUBTITLE_MPAGE";
         divTabletitle_Internalname = "TABLETITLE_MPAGE";
         divTablecontent_Internalname = "TABLECONTENT_MPAGE";
         lblTextblockfooter_Internalname = "TEXTBLOCKFOOTER_MPAGE";
         divTablefooter_Internalname = "TABLEFOOTER_MPAGE";
         Ucmessage_Internalname = "UCMESSAGE_MPAGE";
         Uctooltip_Internalname = "UCTOOLTIP_MPAGE";
         Wwputilities_Internalname = "WWPUTILITIES_MPAGE";
         Wwpdatepicker_Internalname = "WWPDATEPICKER_MPAGE";
         divTablemain_Internalname = "TABLEMAIN_MPAGE";
         edtavPickerdummyvariable_Internalname = "vPICKERDUMMYVARIABLE_MPAGE";
         Bookmark_modal_Internalname = "BOOKMARK_MODAL_MPAGE";
         tblTablebookmark_modal_Internalname = "TABLEBOOKMARK_MODAL_MPAGE";
         divDiv_wwpauxwc_Internalname = "DIV_WWPAUXWC_MPAGE";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS_MPAGE";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE_MPAGE";
         (getDataAreaObject() == null ? Form : getDataAreaObject().GetForm()).Internalname = "FORM_MPAGE";
      }

      public override void initialize_properties( )
      {
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         edtavPickerdummyvariable_Jsonclick = "";
         lblSubtitle_Caption = "Developer Menu > Person";
         lblTextblocktitle_Caption = " Title";
         Ddc_runtimedesignsettings_Caption = "";
         divLayoutmaintable_Class = "Table";
         Bookmark_modal_Bodytype = "WebComponent";
         Bookmark_modal_Confirmtype = "";
         Bookmark_modal_Title = "Add/Edit Bookmark";
         Bookmark_modal_Width = "735";
         Wwputilities_Comboloadtype = "InfiniteScrolling";
         Wwputilities_Pagbarincludegoto = Convert.ToBoolean( -1);
         Wwputilities_Allowcolumnsrestore = Convert.ToBoolean( -1);
         Wwputilities_Allowcolumndragging = Convert.ToBoolean( -1);
         Wwputilities_Allowcolumnreordering = Convert.ToBoolean( -1);
         Wwputilities_Allowcolumnresizing = Convert.ToBoolean( -1);
         Wwputilities_Enableconvertcombotobootstrapselect = Convert.ToBoolean( -1);
         Wwputilities_Enableupdaterowselectionstatus = Convert.ToBoolean( -1);
         Wwputilities_Empowertabs = Convert.ToBoolean( -1);
         Wwputilities_Enablefloatinglabels = Convert.ToBoolean( -1);
         Wwputilities_Enablefixobjectfitcover = Convert.ToBoolean( -1);
         Ucmessage_Stoponerror = Convert.ToBoolean( -1);
         Ddc_runtimedesignsettings_Componentwidth = 240;
         Ddc_runtimedesignsettings_Cls = "HorizontalBorderColorActionGroupHeader";
         Ddc_runtimedesignsettings_Tooltip = "WWP_StyleCustomizations";
         Ddc_runtimedesignsettings_Icon = "fa fa-cog HorizontalBorderColorUserIcon HorizontalBorderColorActionGroupOnlyIcon";
         Ddc_runtimedesignsettings_Icontype = "FontIcon";
         Ddc_adminag_Componentwidth = 260;
         Ddc_adminag_Cls = "HorizontalBorderColorActionGroupHeader";
         Ddc_adminag_Caption = "Administrator";
         Ddc_adminag_Icon = "fas fa-user-circle HorizontalBorderColorUserIcon";
         Ddc_adminag_Icontype = "FontIcon";
         Ddc_notificationswc_Cls = "DropDownNotification HorizontalBorderColorActionGroupHeader";
         Ddc_notificationswc_Caption = "999";
         Ddc_notificationswc_Icon = "far fa-bell HorizontalBorderColorActionGroupOnlyIcon";
         Ddc_notificationswc_Icontype = "FontIcon";
         Ddo_bookmarks_Titlecontrolalign = "Automatic";
         Ddo_bookmarks_Cls = "HorizontalBorderColorActionGroupHeader";
         Ddo_bookmarks_Tooltip = "";
         Ddo_bookmarks_Icon = "far fa-star HorizontalBorderColorActionGroupOnlyIcon";
         Ddo_bookmarks_Icontype = "FontIcon";
         Ucmenu_Moreoptionicon = "fa fa-bars";
         Ucmenu_Moreoptioncaption = "WWP_More";
         Ucmenu_Moreoptiontype = "Slider";
         Ucmenu_Moreoptionenabled = Convert.ToBoolean( -1);
         Ucmenu_Collapsedtitle = "Tresory Bank";
         Ucmenu_Cls = "HorizontalBorderColor";
         Contentholder.setDataArea(getDataAreaObject());
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH_MPAGE","{handler:'Refresh',iparms:[{ctrl:'FORM_MPAGE',prop:'Caption'},{av:'AV33DVelop_Menu',fld:'vDVELOP_MENU_MPAGE',pic:''},{av:'AV40Httprequest.BaseURL',ctrl:'vHTTPREQUEST_MPAGE',prop:'Baseurl'},{av:'AV20ProgramDescription',fld:'vPROGRAMDESCRIPTION_MPAGE',pic:'',hsh:true},{av:'AV48Breadcrumb',fld:'vBREADCRUMB_MPAGE',pic:'',hsh:true},{av:'AV19IndexToAddItems',fld:'vINDEXTOADDITEMS_MPAGE',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("REFRESH_MPAGE",",oparms:[{av:'lblTextblocktitle_Caption',ctrl:'TEXTBLOCKTITLE_MPAGE',prop:'Caption'},{av:'AV48Breadcrumb',fld:'vBREADCRUMB_MPAGE',pic:'',hsh:true},{av:'lblSubtitle_Caption',ctrl:'SUBTITLE_MPAGE',prop:'Caption'},{av:'AV14BookmarksData',fld:'vBOOKMARKSDATA_MPAGE',pic:''},{av:'AV20ProgramDescription',fld:'vPROGRAMDESCRIPTION_MPAGE',pic:'',hsh:true},{av:'AV19IndexToAddItems',fld:'vINDEXTOADDITEMS_MPAGE',pic:'ZZZ9',hsh:true}]}");
         setEventMetadata("DDO_BOOKMARKS_MPAGE.ONOPTIONCLICKED_MPAGE","{handler:'E112R2',iparms:[{av:'Ddo_bookmarks_Activeeventkey',ctrl:'DDO_BOOKMARKS_MPAGE',prop:'ActiveEventKey'}]");
         setEventMetadata("DDO_BOOKMARKS_MPAGE.ONOPTIONCLICKED_MPAGE",",oparms:[]}");
         setEventMetadata("BOOKMARK_MODAL_MPAGE.ONLOADCOMPONENT_MPAGE","{handler:'E162R2',iparms:[{av:'AV40Httprequest.BaseURL',ctrl:'vHTTPREQUEST_MPAGE',prop:'Baseurl'},{av:'AV20ProgramDescription',fld:'vPROGRAMDESCRIPTION_MPAGE',pic:'',hsh:true}]");
         setEventMetadata("BOOKMARK_MODAL_MPAGE.ONLOADCOMPONENT_MPAGE",",oparms:[{ctrl:'WWPAUX_WC_MPAGE'}]}");
         setEventMetadata("BOOKMARK_MODAL_MPAGE.CLOSE_MPAGE","{handler:'E152R2',iparms:[]");
         setEventMetadata("BOOKMARK_MODAL_MPAGE.CLOSE_MPAGE",",oparms:[]}");
         setEventMetadata("DDC_NOTIFICATIONSWC_MPAGE.ONLOADCOMPONENT_MPAGE","{handler:'E122R2',iparms:[]");
         setEventMetadata("DDC_NOTIFICATIONSWC_MPAGE.ONLOADCOMPONENT_MPAGE",",oparms:[{ctrl:'WWPAUX_WC_MPAGE'}]}");
         setEventMetadata("DDC_ADMINAG_MPAGE.ONLOADCOMPONENT_MPAGE","{handler:'E132R2',iparms:[]");
         setEventMetadata("DDC_ADMINAG_MPAGE.ONLOADCOMPONENT_MPAGE",",oparms:[{ctrl:'WWPAUX_WC_MPAGE'}]}");
         setEventMetadata("DDC_RUNTIMEDESIGNSETTINGS_MPAGE.ONLOADCOMPONENT_MPAGE","{handler:'E142R2',iparms:[]");
         setEventMetadata("DDC_RUNTIMEDESIGNSETTINGS_MPAGE.ONLOADCOMPONENT_MPAGE",",oparms:[{ctrl:'WWPAUX_WC_MPAGE'}]}");
         setEventMetadata("GLOBALEVENTS_MPAGE.MASTER_REFRESHHEADER_MPAGE","{handler:'E202R2',iparms:[]");
         setEventMetadata("GLOBALEVENTS_MPAGE.MASTER_REFRESHHEADER_MPAGE",",oparms:[]}");
         setEventMetadata("ONMESSAGE_GX1_MPAGE","{handler:'E182R2',iparms:[{av:'AV22NotificationInfo',fld:'vNOTIFICATIONINFO_MPAGE',pic:''},{av:'A49WWPUserExtendedId',fld:'WWPUSEREXTENDEDID_MPAGE',pic:''},{av:'AV51Udparg1',fld:'vUDPARG1_MPAGE',pic:''},{av:'A124WWPNotificationIsRead',fld:'WWPNOTIFICATIONISREAD_MPAGE',pic:''},{av:'Ddc_notificationswc_Icon',ctrl:'DDC_NOTIFICATIONSWC_MPAGE',prop:'Icon'}]");
         setEventMetadata("ONMESSAGE_GX1_MPAGE",",oparms:[]}");
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
         Contentholder = new GXDataAreaControl();
         Ddo_bookmarks_Activeeventkey = "";
         AV40Httprequest = new GxHttpRequest( context);
         AV22NotificationInfo = new GeneXus.Core.genexus.server.SdtNotificationInfo(context);
         AV20ProgramDescription = "";
         AV48Breadcrumb = "";
         GXKey = "";
         AV33DVelop_Menu = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item>( context, "Item", "agl_tresorygroup");
         AV14BookmarksData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         A49WWPUserExtendedId = "";
         AV51Udparg1 = "";
         sPrefix = "";
         ClassString = "";
         imgHeader_gximage = "";
         StyleString = "";
         sImgUrl = "";
         ucUcmenu = new GXUserControl();
         ucDdo_bookmarks = new GXUserControl();
         Ddo_bookmarks_Caption = "";
         ucDdc_notificationswc = new GXUserControl();
         ucDdc_adminag = new GXUserControl();
         ucDdc_runtimedesignsettings = new GXUserControl();
         lblTextblocktitle_Jsonclick = "";
         lblSubtitle_Jsonclick = "";
         lblTextblockfooter_Jsonclick = "";
         ucUcmessage = new GXUserControl();
         ucUctooltip = new GXUserControl();
         ucWwputilities = new GXUserControl();
         ucWwpdatepicker = new GXUserControl();
         TempTags = "";
         AV47PickerDummyVariable = DateTime.MinValue;
         WebComp_Wwpaux_wc_Component = "";
         OldWwpaux_wc = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GX_FocusControl = "";
         AV5GAMApplication = new GeneXus.Programs.genexussecurity.SdtGAMApplication(context);
         AV6GAMMenuAdditionalParameters = new GeneXus.Programs.genexussecurity.SdtGAMMenuAdditionalParameters(context);
         AV7GAMMEnuOptionList = new GeneXus.Programs.genexussecurity.SdtGAMMenuOptionList(context);
         AV10GAMErrorCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         GXt_objcol_SdtDVelop_Menu_Item1 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item>( context, "Item", "agl_tresorygroup");
         AV15BookmarksDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV12GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV34UserName = "";
         AV8GAMRoleCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMRole>( context, "GeneXus.Programs.genexussecurity.SdtGAMRole", "GeneXus.Programs");
         AV9GAMRole = new GeneXus.Programs.genexussecurity.SdtGAMRole(context);
         AV35RolesDescriptions = "";
         AV37WebSession = context.GetSession();
         AV26WWP_DesignSystemSettings = new GeneXus.Programs.wwpbaseobjects.SdtWWP_DesignSystemSettings(context);
         GXt_SdtWWP_DesignSystemSettings2 = new GeneXus.Programs.wwpbaseobjects.SdtWWP_DesignSystemSettings(context);
         GXEncryptionTmp = "";
         AV23WWP_WebNotification = new GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebNotification(context);
         AV24WWP_UserExtended = new GeneXus.Programs.wwpbaseobjects.SdtWWP_UserExtended(context);
         scmdbuf = "";
         H002R2_AV25NotificationsCount = new short[1] ;
         AV16CurrentURL = "";
         AV17GridStateCollection = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtGridStateCollection_Item>( context, "Item", "");
         AV18GridStateCollectionItem = new GeneXus.Programs.wwpbaseobjects.SdtGridStateCollection_Item(context);
         AV21FontIcon = "";
         GXt_char4 = "";
         sStyleString = "";
         ucBookmark_modal = new GXUserControl();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sDynURL = "";
         Form = new GXWebForm();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.workwithplusmasterpage__default(),
            new Object[][] {
                new Object[] {
               H002R2_AV25NotificationsCount
               }
            }
         );
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
      }

      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short initialized ;
      private short GxWebError ;
      private short AV19IndexToAddItems ;
      private short wbEnd ;
      private short wbStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV25NotificationsCount ;
      private short cV25NotificationsCount ;
      private short nGotPars ;
      private short nGXWrapped ;
      private int Ddc_adminag_Componentwidth ;
      private int Ddc_runtimedesignsettings_Componentwidth ;
      private int AV49GXV1 ;
      private int AV52GXV2 ;
      private int AV53GXV3 ;
      private int idxLst ;
      private string Ddo_bookmarks_Activeeventkey ;
      private string Ddc_notificationswc_Icon ;
      private string GXKey ;
      private string A49WWPUserExtendedId ;
      private string AV51Udparg1 ;
      private string Ucmenu_Cls ;
      private string Ucmenu_Collapsedtitle ;
      private string Ucmenu_Moreoptiontype ;
      private string Ucmenu_Moreoptioncaption ;
      private string Ucmenu_Moreoptionicon ;
      private string Ddo_bookmarks_Icontype ;
      private string Ddo_bookmarks_Icon ;
      private string Ddo_bookmarks_Tooltip ;
      private string Ddo_bookmarks_Cls ;
      private string Ddo_bookmarks_Titlecontrolalign ;
      private string Ddc_notificationswc_Icontype ;
      private string Ddc_notificationswc_Caption ;
      private string Ddc_notificationswc_Cls ;
      private string Ddc_adminag_Icontype ;
      private string Ddc_adminag_Icon ;
      private string Ddc_adminag_Caption ;
      private string Ddc_adminag_Cls ;
      private string Ddc_runtimedesignsettings_Icontype ;
      private string Ddc_runtimedesignsettings_Icon ;
      private string Ddc_runtimedesignsettings_Tooltip ;
      private string Ddc_runtimedesignsettings_Cls ;
      private string Wwputilities_Comboloadtype ;
      private string Bookmark_modal_Width ;
      private string Bookmark_modal_Title ;
      private string Bookmark_modal_Confirmtype ;
      private string Bookmark_modal_Bodytype ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string divTableheader_Internalname ;
      private string ClassString ;
      private string imgHeader_gximage ;
      private string StyleString ;
      private string sImgUrl ;
      private string imgHeader_Internalname ;
      private string Ucmenu_Internalname ;
      private string divTableuserrole_Internalname ;
      private string Ddo_bookmarks_Caption ;
      private string Ddo_bookmarks_Internalname ;
      private string Ddc_notificationswc_Internalname ;
      private string Ddc_adminag_Internalname ;
      private string Ddc_runtimedesignsettings_Caption ;
      private string Ddc_runtimedesignsettings_Internalname ;
      private string divTablecontent_Internalname ;
      private string divTabletitle_Internalname ;
      private string lblTextblocktitle_Internalname ;
      private string lblTextblocktitle_Caption ;
      private string lblTextblocktitle_Jsonclick ;
      private string lblSubtitle_Internalname ;
      private string lblSubtitle_Caption ;
      private string lblSubtitle_Jsonclick ;
      private string divTablefooter_Internalname ;
      private string lblTextblockfooter_Internalname ;
      private string lblTextblockfooter_Jsonclick ;
      private string Ucmessage_Internalname ;
      private string Uctooltip_Internalname ;
      private string Wwputilities_Internalname ;
      private string Wwpdatepicker_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string TempTags ;
      private string edtavPickerdummyvariable_Internalname ;
      private string edtavPickerdummyvariable_Jsonclick ;
      private string divDiv_wwpauxwc_Internalname ;
      private string WebComp_Wwpaux_wc_Component ;
      private string OldWwpaux_wc ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GX_FocusControl ;
      private string GXEncryptionTmp ;
      private string scmdbuf ;
      private string GXt_char4 ;
      private string sStyleString ;
      private string tblTablebookmark_modal_Internalname ;
      private string Bookmark_modal_Internalname ;
      private string sDynURL ;
      private DateTime AV47PickerDummyVariable ;
      private bool A124WWPNotificationIsRead ;
      private bool Ucmenu_Moreoptionenabled ;
      private bool Ucmessage_Stoponerror ;
      private bool Wwputilities_Enablefixobjectfitcover ;
      private bool Wwputilities_Enablefloatinglabels ;
      private bool Wwputilities_Empowertabs ;
      private bool Wwputilities_Enableupdaterowselectionstatus ;
      private bool Wwputilities_Enableconvertcombotobootstrapselect ;
      private bool Wwputilities_Allowcolumnresizing ;
      private bool Wwputilities_Allowcolumnreordering ;
      private bool Wwputilities_Allowcolumndragging ;
      private bool Wwputilities_Allowcolumnsrestore ;
      private bool Wwputilities_Pagbarincludegoto ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool toggleJsOutput ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool bDynCreated_Wwpaux_wc ;
      private bool GXt_boolean3 ;
      private bool AV13BookmarkFound ;
      private string AV20ProgramDescription ;
      private string AV48Breadcrumb ;
      private string AV34UserName ;
      private string AV35RolesDescriptions ;
      private string AV16CurrentURL ;
      private string AV21FontIcon ;
      private IGxSession AV37WebSession ;
      private GXWebComponent WebComp_Wwpaux_wc ;
      private GXUserControl ucUcmenu ;
      private GXUserControl ucDdo_bookmarks ;
      private GXUserControl ucDdc_notificationswc ;
      private GXUserControl ucDdc_adminag ;
      private GXUserControl ucDdc_runtimedesignsettings ;
      private GXUserControl ucUcmessage ;
      private GXUserControl ucUctooltip ;
      private GXUserControl ucWwputilities ;
      private GXUserControl ucWwpdatepicker ;
      private GXUserControl ucBookmark_modal ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXDataAreaControl Contentholder ;
      private IDataStoreProvider pr_default ;
      private short[] H002R2_AV25NotificationsCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV40Httprequest ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV10GAMErrorCollection ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMRole> AV8GAMRoleCollection ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV14BookmarksData ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtGridStateCollection_Item> AV17GridStateCollection ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> AV33DVelop_Menu ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> GXt_objcol_SdtDVelop_Menu_Item1 ;
      private GXWebForm Form ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplication AV5GAMApplication ;
      private GeneXus.Programs.genexussecurity.SdtGAMMenuOptionList AV7GAMMEnuOptionList ;
      private GeneXus.Programs.genexussecurity.SdtGAMMenuAdditionalParameters AV6GAMMenuAdditionalParameters ;
      private GeneXus.Programs.genexussecurity.SdtGAMRole AV9GAMRole ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV12GAMUser ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item AV15BookmarksDataItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtGridStateCollection_Item AV18GridStateCollectionItem ;
      private GeneXus.Core.genexus.server.SdtNotificationInfo AV22NotificationInfo ;
      private GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebNotification AV23WWP_WebNotification ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWP_UserExtended AV24WWP_UserExtended ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWP_DesignSystemSettings AV26WWP_DesignSystemSettings ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWP_DesignSystemSettings GXt_SdtWWP_DesignSystemSettings2 ;
   }

   public class workwithplusmasterpage__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH002R2;
          prmH002R2 = new Object[] {
          new ParDef("AV51Udparg1",GXType.Char,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("H002R2", "SELECT COUNT(*) FROM WWP_Notification WHERE (WWPUserExtendedId = ( :AV51Udparg1)) AND (Not WWPNotificationIsRead) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002R2,1, GxCacheFrequency.OFF ,true,false )
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
                return;
       }
    }

 }

}
