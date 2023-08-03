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
   public class wwp_isreceivedwebnotification : GXProcedure
   {
      public wwp_isreceivedwebnotification( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_isreceivedwebnotification( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_WebNotificationId ,
                           out bool aP1_IsRecived )
      {
         this.AV8WebNotificationId = aP0_WebNotificationId;
         this.AV9IsRecived = false ;
         initialize();
         executePrivate();
         aP1_IsRecived=this.AV9IsRecived;
      }

      public bool executeUdp( long aP0_WebNotificationId )
      {
         execute(aP0_WebNotificationId, out aP1_IsRecived);
         return AV9IsRecived ;
      }

      public void executeSubmit( long aP0_WebNotificationId ,
                                 out bool aP1_IsRecived )
      {
         wwp_isreceivedwebnotification objwwp_isreceivedwebnotification;
         objwwp_isreceivedwebnotification = new wwp_isreceivedwebnotification();
         objwwp_isreceivedwebnotification.AV8WebNotificationId = aP0_WebNotificationId;
         objwwp_isreceivedwebnotification.AV9IsRecived = false ;
         objwwp_isreceivedwebnotification.context.SetSubmitInitialConfig(context);
         objwwp_isreceivedwebnotification.initialize();
         Submit( executePrivateCatch,objwwp_isreceivedwebnotification);
         aP1_IsRecived=this.AV9IsRecived;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((wwp_isreceivedwebnotification)stateInfo).executePrivate();
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
         AV9IsRecived = false;
         /* Using cursor P00312 */
         pr_default.execute(0, new Object[] {AV8WebNotificationId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A89WWPWebNotificationId = P00312_A89WWPWebNotificationId[0];
            A99WWPWebNotificationReceived = P00312_A99WWPWebNotificationReceived[0];
            n99WWPWebNotificationReceived = P00312_n99WWPWebNotificationReceived[0];
            if ( A99WWPWebNotificationReceived )
            {
               AV9IsRecived = true;
            }
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
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
         scmdbuf = "";
         P00312_A89WWPWebNotificationId = new long[1] ;
         P00312_A99WWPWebNotificationReceived = new bool[] {false} ;
         P00312_n99WWPWebNotificationReceived = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.web.wwp_isreceivedwebnotification__default(),
            new Object[][] {
                new Object[] {
               P00312_A89WWPWebNotificationId, P00312_A99WWPWebNotificationReceived, P00312_n99WWPWebNotificationReceived
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV8WebNotificationId ;
      private long A89WWPWebNotificationId ;
      private string scmdbuf ;
      private bool AV9IsRecived ;
      private bool A99WWPWebNotificationReceived ;
      private bool n99WWPWebNotificationReceived ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00312_A89WWPWebNotificationId ;
      private bool[] P00312_A99WWPWebNotificationReceived ;
      private bool[] P00312_n99WWPWebNotificationReceived ;
      private bool aP1_IsRecived ;
   }

   public class wwp_isreceivedwebnotification__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00312;
          prmP00312 = new Object[] {
          new ParDef("AV8WebNotificationId",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00312", "SELECT WWPWebNotificationId, WWPWebNotificationReceived FROM WWP_WebNotification WHERE WWPWebNotificationId = :AV8WebNotificationId ORDER BY WWPWebNotificationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00312,1, GxCacheFrequency.OFF ,false,true )
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
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
       }
    }

 }

}
