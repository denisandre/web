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
   public class wwp_updatewebnotificationstatus : GXProcedure
   {
      public wwp_updatewebnotificationstatus( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_updatewebnotificationstatus( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_WebNotificationId ,
                           short aP1_WebNotificationStatus ,
                           string aP2_WebNotificationDetail )
      {
         this.AV9WebNotificationId = aP0_WebNotificationId;
         this.AV10WebNotificationStatus = aP1_WebNotificationStatus;
         this.AV11WebNotificationDetail = aP2_WebNotificationDetail;
         initialize();
         executePrivate();
      }

      public void executeSubmit( long aP0_WebNotificationId ,
                                 short aP1_WebNotificationStatus ,
                                 string aP2_WebNotificationDetail )
      {
         wwp_updatewebnotificationstatus objwwp_updatewebnotificationstatus;
         objwwp_updatewebnotificationstatus = new wwp_updatewebnotificationstatus();
         objwwp_updatewebnotificationstatus.AV9WebNotificationId = aP0_WebNotificationId;
         objwwp_updatewebnotificationstatus.AV10WebNotificationStatus = aP1_WebNotificationStatus;
         objwwp_updatewebnotificationstatus.AV11WebNotificationDetail = aP2_WebNotificationDetail;
         objwwp_updatewebnotificationstatus.context.SetSubmitInitialConfig(context);
         objwwp_updatewebnotificationstatus.initialize();
         Submit( executePrivateCatch,objwwp_updatewebnotificationstatus);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((wwp_updatewebnotificationstatus)stateInfo).executePrivate();
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
         AV8WebNotification.Load(AV9WebNotificationId);
         if ( AV8WebNotification.Fail() )
         {
            new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_error(  AV12Pgmname,  "Web notificaiton not found with id: "+StringUtil.Str( (decimal)(AV9WebNotificationId), 10, 0)) ;
            this.cleanup();
            if (true) return;
         }
         AV8WebNotification.gxTpr_Wwpwebnotificationprocessed = DateTimeUtil.ServerNowMs( context, pr_default);
         AV8WebNotification.gxTpr_Wwpwebnotificationstatus = AV10WebNotificationStatus;
         AV8WebNotification.gxTpr_Wwpwebnotificationdetail = AV11WebNotificationDetail;
         AV8WebNotification.Save();
         if ( AV8WebNotification.Fail() )
         {
            new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_error(  AV12Pgmname,  "Error updating web notification status with id: "+StringUtil.Str( (decimal)(AV9WebNotificationId), 10, 0)) ;
            this.cleanup();
            if (true) return;
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
         AV8WebNotification = new GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebNotification(context);
         AV12Pgmname = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.web.wwp_updatewebnotificationstatus__default(),
            new Object[][] {
            }
         );
         AV12Pgmname = "WWPBaseObjects.Notifications.Web.WWP_UpdateWebNotificationStatus";
         /* GeneXus formulas. */
         AV12Pgmname = "WWPBaseObjects.Notifications.Web.WWP_UpdateWebNotificationStatus";
      }

      private short AV10WebNotificationStatus ;
      private long AV9WebNotificationId ;
      private string AV12Pgmname ;
      private string AV11WebNotificationDetail ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebNotification AV8WebNotification ;
   }

   public class wwp_updatewebnotificationstatus__default : DataStoreHelperBase, IDataStoreHelper
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
