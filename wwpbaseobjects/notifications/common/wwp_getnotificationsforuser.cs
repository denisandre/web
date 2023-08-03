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
   public class wwp_getnotificationsforuser : GXProcedure
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

      public wwp_getnotificationsforuser( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_getnotificationsforuser( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem>( context, "WWP_SDTNotificationsDataItem", "agl_tresorygroup") ;
         initialize();
         executePrivate();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem> aP0_Gxm2rootcol )
      {
         wwp_getnotificationsforuser objwwp_getnotificationsforuser;
         objwwp_getnotificationsforuser = new wwp_getnotificationsforuser();
         objwwp_getnotificationsforuser.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem>( context, "WWP_SDTNotificationsDataItem", "agl_tresorygroup") ;
         objwwp_getnotificationsforuser.context.SetSubmitInitialConfig(context);
         objwwp_getnotificationsforuser.initialize();
         Submit( executePrivateCatch,objwwp_getnotificationsforuser);
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((wwp_getnotificationsforuser)stateInfo).executePrivate();
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
         AV9Udparg3 = new GeneXus.Programs.wwpbaseobjects.wwp_getloggeduserid(context).executeUdp( );
         /* Using cursor P000G2 */
         pr_default.execute(0, new Object[] {AV9Udparg3});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A124WWPNotificationIsRead = P000G2_A124WWPNotificationIsRead[0];
            A49WWPUserExtendedId = P000G2_A49WWPUserExtendedId[0];
            n49WWPUserExtendedId = P000G2_n49WWPUserExtendedId[0];
            A64WWPNotificationId = P000G2_A64WWPNotificationId[0];
            A118WWPNotificationIcon = P000G2_A118WWPNotificationIcon[0];
            A119WWPNotificationTitle = P000G2_A119WWPNotificationTitle[0];
            A120WWPNotificationShortDescriptio = P000G2_A120WWPNotificationShortDescriptio[0];
            A121WWPNotificationLink = P000G2_A121WWPNotificationLink[0];
            A66WWPNotificationCreated = P000G2_A66WWPNotificationCreated[0];
            Gxm1wwp_sdtnotificationsdata = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem(context);
            Gxm2rootcol.Add(Gxm1wwp_sdtnotificationsdata, 0);
            Gxm1wwp_sdtnotificationsdata.gxTpr_Notificationid = (int)(A64WWPNotificationId);
            Gxm1wwp_sdtnotificationsdata.gxTpr_Notificationiconclass = "NotificationFontIcon"+" "+A118WWPNotificationIcon;
            Gxm1wwp_sdtnotificationsdata.gxTpr_Notificationtitle = A119WWPNotificationTitle;
            Gxm1wwp_sdtnotificationsdata.gxTpr_Notificationdescription = A120WWPNotificationShortDescriptio;
            Gxm1wwp_sdtnotificationsdata.gxTpr_Notificationdatetime = A66WWPNotificationCreated;
            Gxm1wwp_sdtnotificationsdata.gxTpr_Notificationlink = A121WWPNotificationLink;
            pr_default.readNext(0);
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
         AV9Udparg3 = "";
         scmdbuf = "";
         P000G2_A124WWPNotificationIsRead = new bool[] {false} ;
         P000G2_A49WWPUserExtendedId = new string[] {""} ;
         P000G2_n49WWPUserExtendedId = new bool[] {false} ;
         P000G2_A64WWPNotificationId = new long[1] ;
         P000G2_A118WWPNotificationIcon = new string[] {""} ;
         P000G2_A119WWPNotificationTitle = new string[] {""} ;
         P000G2_A120WWPNotificationShortDescriptio = new string[] {""} ;
         P000G2_A121WWPNotificationLink = new string[] {""} ;
         P000G2_A66WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         A49WWPUserExtendedId = "";
         A118WWPNotificationIcon = "";
         A119WWPNotificationTitle = "";
         A120WWPNotificationShortDescriptio = "";
         A121WWPNotificationLink = "";
         A66WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         Gxm1wwp_sdtnotificationsdata = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_getnotificationsforuser__default(),
            new Object[][] {
                new Object[] {
               P000G2_A124WWPNotificationIsRead, P000G2_A49WWPUserExtendedId, P000G2_n49WWPUserExtendedId, P000G2_A64WWPNotificationId, P000G2_A118WWPNotificationIcon, P000G2_A119WWPNotificationTitle, P000G2_A120WWPNotificationShortDescriptio, P000G2_A121WWPNotificationLink, P000G2_A66WWPNotificationCreated
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long A64WWPNotificationId ;
      private string AV9Udparg3 ;
      private string scmdbuf ;
      private string A49WWPUserExtendedId ;
      private DateTime A66WWPNotificationCreated ;
      private bool A124WWPNotificationIsRead ;
      private bool n49WWPUserExtendedId ;
      private string A118WWPNotificationIcon ;
      private string A119WWPNotificationTitle ;
      private string A120WWPNotificationShortDescriptio ;
      private string A121WWPNotificationLink ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private bool[] P000G2_A124WWPNotificationIsRead ;
      private string[] P000G2_A49WWPUserExtendedId ;
      private bool[] P000G2_n49WWPUserExtendedId ;
      private long[] P000G2_A64WWPNotificationId ;
      private string[] P000G2_A118WWPNotificationIcon ;
      private string[] P000G2_A119WWPNotificationTitle ;
      private string[] P000G2_A120WWPNotificationShortDescriptio ;
      private string[] P000G2_A121WWPNotificationLink ;
      private DateTime[] P000G2_A66WWPNotificationCreated ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem> aP0_Gxm2rootcol ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem> Gxm2rootcol ;
      private GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem Gxm1wwp_sdtnotificationsdata ;
   }

   public class wwp_getnotificationsforuser__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP000G2;
          prmP000G2 = new Object[] {
          new ParDef("AV9Udparg3",GXType.Char,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000G2", "SELECT WWPNotificationIsRead, WWPUserExtendedId, WWPNotificationId, WWPNotificationIcon, WWPNotificationTitle, WWPNotificationShortDescriptio, WWPNotificationLink, WWPNotificationCreated FROM WWP_Notification WHERE (Not WWPNotificationIsRead) AND (WWPUserExtendedId = ( :AV9Udparg3)) ORDER BY WWPNotificationCreated DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000G2,100, GxCacheFrequency.OFF ,false,false )
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
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 40);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((long[]) buf[3])[0] = rslt.getLong(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(8, true);
                return;
       }
    }

 }

}
