using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs.wwpbaseobjects {
   public class loadmenu_gammenu : GXProcedure
   {
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

      public loadmenu_gammenu( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public loadmenu_gammenu( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMMenuOptionList> aP0_GAMMenu ,
                           long aP1_MenuId ,
                           long aP2_MinMenuId ,
                           out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> aP3_Gxm2rootcol )
      {
         this.AV5GAMMenu = aP0_GAMMenu;
         this.AV9MenuId = aP1_MenuId;
         this.AV12MinMenuId = aP2_MinMenuId;
         this.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item>( context, "Item", "agl_tresorygroup") ;
         initialize();
         executePrivate();
         aP3_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> executeUdp( GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMMenuOptionList> aP0_GAMMenu ,
                                                                                               long aP1_MenuId ,
                                                                                               long aP2_MinMenuId )
      {
         execute(aP0_GAMMenu, aP1_MenuId, aP2_MinMenuId, out aP3_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMMenuOptionList> aP0_GAMMenu ,
                                 long aP1_MenuId ,
                                 long aP2_MinMenuId ,
                                 out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> aP3_Gxm2rootcol )
      {
         loadmenu_gammenu objloadmenu_gammenu;
         objloadmenu_gammenu = new loadmenu_gammenu();
         objloadmenu_gammenu.AV5GAMMenu = aP0_GAMMenu;
         objloadmenu_gammenu.AV9MenuId = aP1_MenuId;
         objloadmenu_gammenu.AV12MinMenuId = aP2_MinMenuId;
         objloadmenu_gammenu.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item>( context, "Item", "agl_tresorygroup") ;
         objloadmenu_gammenu.context.SetSubmitInitialConfig(context);
         objloadmenu_gammenu.initialize();
         Submit( executePrivateCatch,objloadmenu_gammenu);
         aP3_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((loadmenu_gammenu)stateInfo).executePrivate();
         }
         catch ( Exception e )
         {
            GXUtil.SaveToEventLog( "Design", e);
            throw;
         }
      }

      void executePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8GAMApplication = new GeneXus.Programs.genexussecurity.SdtGAMApplication(context).get();
         AV13MinMenuIdAux = AV12MinMenuId;
         AV16GXV1 = 1;
         while ( AV16GXV1 <= AV5GAMMenu.Count )
         {
            AV6GAMMenuItem = ((GeneXus.Programs.genexussecurity.SdtGAMMenuOptionList)AV5GAMMenu.Item(AV16GXV1));
            Gxm1dvelop_menu = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
            Gxm2rootcol.Add(Gxm1dvelop_menu, 0);
            AV13MinMenuIdAux = (long)(AV13MinMenuIdAux+1);
            Gxm1dvelop_menu.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(AV13MinMenuIdAux), 10, 0));
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV6GAMMenuItem.gxTpr_Link))) && ( StringUtil.StringSearchRev( StringUtil.Trim( AV6GAMMenuItem.gxTpr_Link), ".aspx", -1) == 0 ) )
            {
               Gxm1dvelop_menu.gxTpr_Link = StringUtil.Format( "%1.aspx", StringUtil.Trim( AV6GAMMenuItem.gxTpr_Link), "", "", "", "", "", "", "", "");
            }
            else
            {
               Gxm1dvelop_menu.gxTpr_Link = StringUtil.Trim( AV6GAMMenuItem.gxTpr_Link);
            }
            if ( AV6GAMMenuItem.gxTpr_Properties.Count > 0 )
            {
               Gxm1dvelop_menu.gxTpr_Iconclass = ((GeneXus.Programs.genexussecurity.SdtGAMProperty)AV6GAMMenuItem.gxTpr_Properties.Item(1)).gxTpr_Value;
            }
            else
            {
               if ( ( AV9MenuId > 0 ) && ( AV6GAMMenuItem.gxTpr_Properties.Count == 0 ) )
               {
                  Gxm1dvelop_menu.gxTpr_Iconclass = "menu-icon fa fa-bullseye";
               }
               else
               {
                  Gxm1dvelop_menu.gxTpr_Iconclass = "";
               }
            }
            if ( AV6GAMMenuItem.gxTpr_Properties.Count > 0 )
            {
               Gxm1dvelop_menu.gxTpr_Linktarget = StringUtil.Trim( ((GeneXus.Programs.genexussecurity.SdtGAMProperty)AV6GAMMenuItem.gxTpr_Properties.Item(2)).gxTpr_Value);
            }
            else
            {
               Gxm1dvelop_menu.gxTpr_Linktarget = "";
            }
            Gxm1dvelop_menu.gxTpr_Caption = AV6GAMMenuItem.gxTpr_Name;
            GXt_objcol_SdtDVelop_Menu_Item1 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item>();
            new GeneXus.Programs.wwpbaseobjects.loadmenu_gammenu(context ).execute(  AV6GAMMenuItem.gxTpr_Nodes,  0,  AV13MinMenuIdAux*100, out  GXt_objcol_SdtDVelop_Menu_Item1) ;
            Gxm1dvelop_menu.gxTpr_Subitems = GXt_objcol_SdtDVelop_Menu_Item1;
            AV16GXV1 = (int)(AV16GXV1+1);
         }
         if ( AV9MenuId > 0 )
         {
            Gxm1dvelop_menu = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
            Gxm2rootcol.Add(Gxm1dvelop_menu, 0);
            AV13MinMenuIdAux = (long)(AV13MinMenuIdAux+1);
            Gxm1dvelop_menu.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(AV13MinMenuIdAux), 10, 0));
            Gxm1dvelop_menu.gxTpr_Tooltip = "";
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "gamwwappmenuoptions.aspx"+GXUtil.UrlEncode(StringUtil.LTrimStr(AV8GAMApplication.gxTpr_Id,12,0)) + "," + GXUtil.UrlEncode(StringUtil.LTrimStr(AV8GAMApplication.gxTpr_Mainmenuid,12,0));
            Gxm1dvelop_menu.gxTpr_Link = formatLink("gamwwappmenuoptions.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            Gxm1dvelop_menu.gxTpr_Linktarget = "";
            Gxm1dvelop_menu.gxTpr_Iconclass = "menu-icon fa fa-tasks";
            Gxm1dvelop_menu.gxTpr_Caption = "Edit Menu Options";
         }
         this.cleanup();
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         AV8GAMApplication = new GeneXus.Programs.genexussecurity.SdtGAMApplication(context);
         AV6GAMMenuItem = new GeneXus.Programs.genexussecurity.SdtGAMMenuOptionList(context);
         Gxm1dvelop_menu = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         GXt_objcol_SdtDVelop_Menu_Item1 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item>( context, "Item", "agl_tresorygroup");
         GXKey = "";
         GXEncryptionTmp = "";
         /* GeneXus formulas. */
      }

      private short gxcookieaux ;
      private int AV16GXV1 ;
      private long AV9MenuId ;
      private long AV12MinMenuId ;
      private long AV13MinMenuIdAux ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> aP3_Gxm2rootcol ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMMenuOptionList> AV5GAMMenu ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> Gxm2rootcol ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> GXt_objcol_SdtDVelop_Menu_Item1 ;
      private GeneXus.Programs.genexussecurity.SdtGAMMenuOptionList AV6GAMMenuItem ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplication AV8GAMApplication ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item Gxm1dvelop_menu ;
   }

}
