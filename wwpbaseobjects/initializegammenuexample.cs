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
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs.wwpbaseobjects {
   public class initializegammenuexample : GXProcedure
   {
      public initializegammenuexample( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public initializegammenuexample( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         initialize();
         executePrivate();
      }

      public void executeSubmit( )
      {
         initializegammenuexample objinitializegammenuexample;
         objinitializegammenuexample = new initializegammenuexample();
         objinitializegammenuexample.context.SetSubmitInitialConfig(context);
         objinitializegammenuexample.initialize();
         Submit( executePrivateCatch,objinitializegammenuexample);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((initializegammenuexample)stateInfo).executePrivate();
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
         AV23Link = "";
         AV12GAMApplication = new GeneXus.Programs.genexussecurity.SdtGAMApplication(context).get();
         AV24MenuItemName = "GAM_Repository";
         /* Execute user subroutine: 'CREATEMENU' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV27RepositoryAppMenuId = (int)(AV13GAMApplicationMenu.gxTpr_Id);
         AV9AppMenuId = AV27RepositoryAppMenuId;
         AV24MenuItemName = "Configuration";
         AV19GAMPermissionName = "gamrepositoryconfiguration_Execute";
         /* Execute user subroutine: 'CREATEMENUITEM' */
         S141 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV24MenuItemName = "Connections";
         AV19GAMPermissionName = "gamwwconnections_Execute";
         /* Execute user subroutine: 'CREATEMENUITEM' */
         S141 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV24MenuItemName = "Change Repository";
         AV19GAMPermissionName = "gamchangerepository_Execute";
         /* Execute user subroutine: 'CREATEMENUITEM' */
         S141 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV24MenuItemName = "GAM_OtherConfigurations";
         /* Execute user subroutine: 'CREATEMENU' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV25OtherConfigsAppMenuId = (int)(AV13GAMApplicationMenu.gxTpr_Id);
         AV9AppMenuId = AV13GAMApplicationMenu.gxTpr_Id;
         AV24MenuItemName = "Security Policies";
         AV19GAMPermissionName = "gamwwsecuritypolicy_Execute";
         /* Execute user subroutine: 'CREATEMENUITEM' */
         S141 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV24MenuItemName = "Authentication Types";
         AV19GAMPermissionName = "gamwwauthtypes_Execute";
         /* Execute user subroutine: 'CREATEMENUITEM' */
         S141 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV24MenuItemName = "Event Subscriptions";
         AV19GAMPermissionName = "gamwweventsubscriptions_Execute";
         /* Execute user subroutine: 'CREATEMENUITEM' */
         S141 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV24MenuItemName = "GAM_Security";
         /* Execute user subroutine: 'CREATEMENU' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV28SecurityMenuID = (int)(AV13GAMApplicationMenu.gxTpr_Id);
         AV9AppMenuId = AV13GAMApplicationMenu.gxTpr_Id;
         AV24MenuItemName = "Users";
         AV19GAMPermissionName = "gamwwusers_Execute";
         /* Execute user subroutine: 'CREATEMENUITEM' */
         S141 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV24MenuItemName = "Roles";
         AV19GAMPermissionName = "gamwwroles_Execute";
         /* Execute user subroutine: 'CREATEMENUITEM' */
         S141 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV24MenuItemName = "Applications";
         AV19GAMPermissionName = "gamwwapplications_Execute";
         /* Execute user subroutine: 'CREATEMENUITEM' */
         S141 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV24MenuItemName = "Repository";
         AV10AppSubMenuId = AV27RepositoryAppMenuId;
         /* Execute user subroutine: 'CREATEMENUSUBMENU' */
         S131 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV24MenuItemName = "Other Configurations";
         AV10AppSubMenuId = AV25OtherConfigsAppMenuId;
         /* Execute user subroutine: 'CREATEMENUSUBMENU' */
         S131 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV24MenuItemName = "MainMenu";
         /* Execute user subroutine: 'CREATEMENU' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV9AppMenuId = AV13GAMApplicationMenu.gxTpr_Id;
         AV24MenuItemName = "Home";
         AV19GAMPermissionName = "home_Execute";
         AV21IconClass = "menu-icon fa fa-home";
         /* Execute user subroutine: 'CREATEMENUITEM' */
         S141 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV24MenuItemName = "Security";
         AV10AppSubMenuId = AV28SecurityMenuID;
         AV21IconClass = "menu-icon fa fa-key";
         /* Execute user subroutine: 'CREATEMENUSUBMENU' */
         S131 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV12GAMApplication.load( AV12GAMApplication.gxTpr_Id);
         AV12GAMApplication.gxTpr_Mainmenuid = AV13GAMApplicationMenu.gxTpr_Id;
         AV12GAMApplication.save();
         context.CommitDataStores("wwpbaseobjects.initializegammenuexample",pr_default);
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'CREATEMENU' Routine */
         returnInSub = false;
         AV13GAMApplicationMenu = new GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu(context);
         AV13GAMApplicationMenu.gxTpr_Name = AV24MenuItemName;
         AV22IsOk = AV12GAMApplication.addmenu(AV13GAMApplicationMenu, out  AV18GAMErrorCollection);
         if ( AV22IsOk )
         {
            context.CommitDataStores("wwpbaseobjects.initializegammenuexample",pr_default);
         }
         else
         {
            /* Execute user subroutine: 'ERRORS' */
            S121 ();
            if (returnInSub) return;
         }
      }

      protected void S131( )
      {
         /* 'CREATEMENUSUBMENU' Routine */
         returnInSub = false;
         AV8GAMApplicationMenuOption = new GeneXus.Programs.genexussecurity.SdtGAMApplicationMenuOption(context);
         AV8GAMApplicationMenuOption.gxTpr_Name = AV24MenuItemName;
         AV8GAMApplicationMenuOption.gxTpr_Type = "M";
         AV8GAMApplicationMenuOption.gxTpr_Submenuid = AV10AppSubMenuId;
         AV20GAMProperty = new GeneXus.Programs.genexussecurity.SdtGAMProperty(context);
         AV20GAMProperty.gxTpr_Id = "IconClass";
         AV20GAMProperty.gxTpr_Value = AV21IconClass;
         AV8GAMApplicationMenuOption.gxTpr_Properties.Add(AV20GAMProperty, 0);
         AV20GAMProperty = new GeneXus.Programs.genexussecurity.SdtGAMProperty(context);
         AV20GAMProperty.gxTpr_Id = "Link";
         AV20GAMProperty.gxTpr_Value = AV23Link;
         AV8GAMApplicationMenuOption.gxTpr_Properties.Add(AV20GAMProperty, 0);
         AV12GAMApplication.addmenuoption( AV9AppMenuId,  AV8GAMApplicationMenuOption, out  AV18GAMErrorCollection);
         if ( AV22IsOk )
         {
            context.CommitDataStores("wwpbaseobjects.initializegammenuexample",pr_default);
         }
         else
         {
            /* Execute user subroutine: 'ERRORS' */
            S121 ();
            if (returnInSub) return;
         }
      }

      protected void S141( )
      {
         /* 'CREATEMENUITEM' Routine */
         returnInSub = false;
         AV8GAMApplicationMenuOption = new GeneXus.Programs.genexussecurity.SdtGAMApplicationMenuOption(context);
         AV8GAMApplicationMenuOption.gxTpr_Name = AV24MenuItemName;
         AV8GAMApplicationMenuOption.gxTpr_Type = "S";
         AV16GAMApplicationPermission = AV12GAMApplication.getpermissionbyname(AV19GAMPermissionName, out  AV18GAMErrorCollection);
         AV8GAMApplicationMenuOption.gxTpr_Permissionresourceguid = AV16GAMApplicationPermission.gxTpr_Guid;
         AV8GAMApplicationMenuOption.gxTpr_Resource = StringUtil.Trim( AV16GAMApplicationPermission.gxTpr_Resource);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21IconClass)) )
         {
            AV20GAMProperty = new GeneXus.Programs.genexussecurity.SdtGAMProperty(context);
            AV20GAMProperty.gxTpr_Id = "IconClass";
            AV20GAMProperty.gxTpr_Value = AV21IconClass;
            AV8GAMApplicationMenuOption.gxTpr_Properties.Add(AV20GAMProperty, 0);
            AV20GAMProperty = new GeneXus.Programs.genexussecurity.SdtGAMProperty(context);
            AV20GAMProperty.gxTpr_Id = "Link";
            AV20GAMProperty.gxTpr_Value = AV23Link;
            AV8GAMApplicationMenuOption.gxTpr_Properties.Add(AV20GAMProperty, 0);
         }
         AV22IsOk = AV12GAMApplication.addmenuoption(AV9AppMenuId, AV8GAMApplicationMenuOption, out  AV18GAMErrorCollection);
         if ( AV22IsOk )
         {
            context.CommitDataStores("wwpbaseobjects.initializegammenuexample",pr_default);
         }
         else
         {
            /* Execute user subroutine: 'ERRORS' */
            S121 ();
            if (returnInSub) return;
         }
      }

      protected void S121( )
      {
         /* 'ERRORS' Routine */
         returnInSub = false;
         AV29GXV1 = 1;
         while ( AV29GXV1 <= AV18GAMErrorCollection.Count )
         {
            AV11Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV18GAMErrorCollection.Item(AV29GXV1));
            GX_msglist.addItem(StringUtil.Format( "%1 (GAM%2)", AV11Error.gxTpr_Message, StringUtil.LTrimStr( (decimal)(AV11Error.gxTpr_Code), 12, 0), "", "", "", "", "", "", ""));
            AV29GXV1 = (int)(AV29GXV1+1);
         }
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
         AV23Link = "";
         AV12GAMApplication = new GeneXus.Programs.genexussecurity.SdtGAMApplication(context);
         AV24MenuItemName = "";
         AV13GAMApplicationMenu = new GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu(context);
         AV19GAMPermissionName = "";
         AV21IconClass = "";
         AV18GAMErrorCollection = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV8GAMApplicationMenuOption = new GeneXus.Programs.genexussecurity.SdtGAMApplicationMenuOption(context);
         AV20GAMProperty = new GeneXus.Programs.genexussecurity.SdtGAMProperty(context);
         AV16GAMApplicationPermission = new GeneXus.Programs.genexussecurity.SdtGAMApplicationPermission(context);
         AV11Error = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.initializegammenuexample__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.initializegammenuexample__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private int AV27RepositoryAppMenuId ;
      private int AV25OtherConfigsAppMenuId ;
      private int AV28SecurityMenuID ;
      private int AV29GXV1 ;
      private long AV9AppMenuId ;
      private long AV10AppSubMenuId ;
      private string AV19GAMPermissionName ;
      private bool returnInSub ;
      private bool AV22IsOk ;
      private string AV23Link ;
      private string AV24MenuItemName ;
      private string AV21IconClass ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private IDataStoreProvider pr_gam ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV18GAMErrorCollection ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplicationMenuOption AV8GAMApplicationMenuOption ;
      private GeneXus.Programs.genexussecurity.SdtGAMProperty AV20GAMProperty ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV11Error ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplication AV12GAMApplication ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplicationPermission AV16GAMApplicationPermission ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplicationMenu AV13GAMApplicationMenu ;
   }

   public class initializegammenuexample__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class initializegammenuexample__default : DataStoreHelperBase, IDataStoreHelper
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

}

}
