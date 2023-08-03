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
namespace GeneXus.Programs.wwpbaseobjects.notifications.web {
   public class wwp_setwebnotificationreceived : GXProcedure
   {
      public wwp_setwebnotificationreceived( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_setwebnotificationreceived( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_WebNotificationId )
      {
         this.AV8WebNotificationId = aP0_WebNotificationId;
         initialize();
         executePrivate();
      }

      public void executeSubmit( long aP0_WebNotificationId )
      {
         wwp_setwebnotificationreceived objwwp_setwebnotificationreceived;
         objwwp_setwebnotificationreceived = new wwp_setwebnotificationreceived();
         objwwp_setwebnotificationreceived.AV8WebNotificationId = aP0_WebNotificationId;
         objwwp_setwebnotificationreceived.context.SetSubmitInitialConfig(context);
         objwwp_setwebnotificationreceived.initialize();
         Submit( executePrivateCatch,objwwp_setwebnotificationreceived);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((wwp_setwebnotificationreceived)stateInfo).executePrivate();
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
         n99WWPWebNotificationReceived = false;
         /* Optimized UPDATE. */
         /* Using cursor P00322 */
         pr_default.execute(0, new Object[] {AV8WebNotificationId});
         pr_default.close(0);
         pr_default.SmartCacheProvider.SetUpdated("WWP_WebNotification");
         /* End optimized UPDATE. */
         context.CommitDataStores("wwpbaseobjects.notifications.web.wwp_setwebnotificationreceived",pr_default);
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
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.web.wwp_setwebnotificationreceived__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.web.wwp_setwebnotificationreceived__default(),
            new Object[][] {
                new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV8WebNotificationId ;
      private bool n99WWPWebNotificationReceived ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_setwebnotificationreceived__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_setwebnotificationreceived__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new UpdateCursor(def[0])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmP00322;
        prmP00322 = new Object[] {
        new ParDef("AV8WebNotificationId",GXType.Int64,10,0)
        };
        def= new CursorDef[] {
            new CursorDef("P00322", "UPDATE WWP_WebNotification SET WWPWebNotificationReceived=TRUE  WHERE WWPWebNotificationId = :AV8WebNotificationId", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00322)
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
