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
namespace GeneXus.Programs.wwpbaseobjects.notifications.common {
   public class wwp_changenotificationstatus : GXProcedure
   {
      public wwp_changenotificationstatus( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_changenotificationstatus( IGxContext context )
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
         wwp_changenotificationstatus objwwp_changenotificationstatus;
         objwwp_changenotificationstatus = new wwp_changenotificationstatus();
         objwwp_changenotificationstatus.context.SetSubmitInitialConfig(context);
         objwwp_changenotificationstatus.initialize();
         Submit( executePrivateCatch,objwwp_changenotificationstatus);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((wwp_changenotificationstatus)stateInfo).executePrivate();
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
         this.cleanup();
      }

      public void gxep_setnotificationreadunreadbyid( ref long aP0_WWPNotificationId )
      {
         this.AV8WWPNotificationId = aP0_WWPNotificationId;
         initialize();
         /* SetNotificationReadUnreadById Constructor */
         /* Using cursor P00392 */
         pr_default.execute(0, new Object[] {AV8WWPNotificationId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A64WWPNotificationId = P00392_A64WWPNotificationId[0];
            A124WWPNotificationIsRead = P00392_A124WWPNotificationIsRead[0];
            if ( A124WWPNotificationIsRead )
            {
               A124WWPNotificationIsRead = false;
            }
            else
            {
               A124WWPNotificationIsRead = true;
            }
            /* Using cursor P00393 */
            pr_default.execute(1, new Object[] {A124WWPNotificationIsRead, A64WWPNotificationId});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("WWP_Notification");
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         executePrivate();
         aP0_WWPNotificationId=this.AV8WWPNotificationId;
         this.cleanup();
      }

      public void gxep_setnotificationreadbyid( ref long aP0_WWPNotificationId )
      {
         this.AV8WWPNotificationId = aP0_WWPNotificationId;
         initialize();
         /* SetNotificationReadById Constructor */
         /* Optimized UPDATE. */
         /* Using cursor P00394 */
         pr_default.execute(2, new Object[] {AV8WWPNotificationId});
         pr_default.close(2);
         pr_default.SmartCacheProvider.SetUpdated("WWP_Notification");
         /* End optimized UPDATE. */
         executePrivate();
         aP0_WWPNotificationId=this.AV8WWPNotificationId;
         this.cleanup();
      }

      public void gxep_setallnotificationsofloggeduserread( )
      {
         initialize();
         /* SetAllNotificationsOfLoggedUserRead Constructor */
         AV12Udparg1 = new GeneXus.Programs.wwpbaseobjects.wwp_getloggeduserid(context).executeUdp( );
         /* Optimized UPDATE. */
         /* Using cursor P00395 */
         pr_default.execute(3, new Object[] {AV12Udparg1});
         pr_default.close(3);
         pr_default.SmartCacheProvider.SetUpdated("WWP_Notification");
         /* End optimized UPDATE. */
         executePrivate();
         this.cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("wwpbaseobjects.notifications.common.wwp_changenotificationstatus",pr_default);
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
         P00392_A64WWPNotificationId = new long[1] ;
         P00392_A124WWPNotificationIsRead = new bool[] {false} ;
         AV12Udparg1 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_changenotificationstatus__default(),
            new Object[][] {
                new Object[] {
               P00392_A64WWPNotificationId, P00392_A124WWPNotificationIsRead
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV8WWPNotificationId ;
      private long A64WWPNotificationId ;
      private string scmdbuf ;
      private string AV12Udparg1 ;
      private bool A124WWPNotificationIsRead ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private long aP0_WWPNotificationId ;
      private IDataStoreProvider pr_default ;
      private long[] P00392_A64WWPNotificationId ;
      private bool[] P00392_A124WWPNotificationIsRead ;
   }

   public class wwp_changenotificationstatus__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new UpdateCursor(def[1])
         ,new UpdateCursor(def[2])
         ,new UpdateCursor(def[3])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00392;
          prmP00392 = new Object[] {
          new ParDef("AV8WWPNotificationId",GXType.Int64,10,0)
          };
          Object[] prmP00393;
          prmP00393 = new Object[] {
          new ParDef("WWPNotificationIsRead",GXType.Boolean,4,0) ,
          new ParDef("WWPNotificationId",GXType.Int64,10,0)
          };
          Object[] prmP00394;
          prmP00394 = new Object[] {
          new ParDef("AV8WWPNotificationId",GXType.Int64,10,0)
          };
          Object[] prmP00395;
          prmP00395 = new Object[] {
          new ParDef("AV12Udparg1",GXType.Char,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00392", "SELECT WWPNotificationId, WWPNotificationIsRead FROM WWP_Notification WHERE WWPNotificationId = :AV8WWPNotificationId ORDER BY WWPNotificationId  FOR UPDATE OF WWP_Notification",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00392,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00393", "SAVEPOINT gxupdate;UPDATE WWP_Notification SET WWPNotificationIsRead=:WWPNotificationIsRead  WHERE WWPNotificationId = :WWPNotificationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00393)
             ,new CursorDef("P00394", "UPDATE WWP_Notification SET WWPNotificationIsRead=TRUE  WHERE WWPNotificationId = :AV8WWPNotificationId", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00394)
             ,new CursorDef("P00395", "UPDATE WWP_Notification SET WWPNotificationIsRead=TRUE  WHERE WWPUserExtendedId = ( :AV12Udparg1)", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00395)
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
                return;
       }
    }

 }

}
