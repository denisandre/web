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
namespace GeneXus.Programs.wwpbaseobjects.subscriptions {
   public class wwp_checkuserisnotunsubscribed : GXProcedure
   {
      public wwp_checkuserisnotunsubscribed( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_checkuserisnotunsubscribed( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_WWPNotificationDefinitionId ,
                           ref long aP1_WWPSubscriptionId ,
                           ref bool aP2_IncludeNotification )
      {
         this.AV9WWPNotificationDefinitionId = aP0_WWPNotificationDefinitionId;
         this.AV10WWPSubscriptionId = aP1_WWPSubscriptionId;
         this.AV8IncludeNotification = aP2_IncludeNotification;
         initialize();
         executePrivate();
         aP1_WWPSubscriptionId=this.AV10WWPSubscriptionId;
         aP2_IncludeNotification=this.AV8IncludeNotification;
      }

      public bool executeUdp( long aP0_WWPNotificationDefinitionId ,
                              ref long aP1_WWPSubscriptionId )
      {
         execute(aP0_WWPNotificationDefinitionId, ref aP1_WWPSubscriptionId, ref aP2_IncludeNotification);
         return AV8IncludeNotification ;
      }

      public void executeSubmit( long aP0_WWPNotificationDefinitionId ,
                                 ref long aP1_WWPSubscriptionId ,
                                 ref bool aP2_IncludeNotification )
      {
         wwp_checkuserisnotunsubscribed objwwp_checkuserisnotunsubscribed;
         objwwp_checkuserisnotunsubscribed = new wwp_checkuserisnotunsubscribed();
         objwwp_checkuserisnotunsubscribed.AV9WWPNotificationDefinitionId = aP0_WWPNotificationDefinitionId;
         objwwp_checkuserisnotunsubscribed.AV10WWPSubscriptionId = aP1_WWPSubscriptionId;
         objwwp_checkuserisnotunsubscribed.AV8IncludeNotification = aP2_IncludeNotification;
         objwwp_checkuserisnotunsubscribed.context.SetSubmitInitialConfig(context);
         objwwp_checkuserisnotunsubscribed.initialize();
         Submit( executePrivateCatch,objwwp_checkuserisnotunsubscribed);
         aP1_WWPSubscriptionId=this.AV10WWPSubscriptionId;
         aP2_IncludeNotification=this.AV8IncludeNotification;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((wwp_checkuserisnotunsubscribed)stateInfo).executePrivate();
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
         AV12Udparg1 = new GeneXus.Programs.wwpbaseobjects.wwp_getloggeduserid(context).executeUdp( );
         /* Using cursor P002N2 */
         pr_default.execute(0, new Object[] {AV12Udparg1, AV9WWPNotificationDefinitionId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A69WWPSubscriptionSubscribed = P002N2_A69WWPSubscriptionSubscribed[0];
            A49WWPUserExtendedId = P002N2_A49WWPUserExtendedId[0];
            n49WWPUserExtendedId = P002N2_n49WWPUserExtendedId[0];
            A65WWPNotificationDefinitionId = P002N2_A65WWPNotificationDefinitionId[0];
            A67WWPSubscriptionId = P002N2_A67WWPSubscriptionId[0];
            AV8IncludeNotification = false;
            AV10WWPSubscriptionId = A67WWPSubscriptionId;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
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
         AV12Udparg1 = "";
         scmdbuf = "";
         P002N2_A69WWPSubscriptionSubscribed = new bool[] {false} ;
         P002N2_A49WWPUserExtendedId = new string[] {""} ;
         P002N2_n49WWPUserExtendedId = new bool[] {false} ;
         P002N2_A65WWPNotificationDefinitionId = new long[1] ;
         P002N2_A67WWPSubscriptionId = new long[1] ;
         A49WWPUserExtendedId = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_checkuserisnotunsubscribed__default(),
            new Object[][] {
                new Object[] {
               P002N2_A69WWPSubscriptionSubscribed, P002N2_A49WWPUserExtendedId, P002N2_n49WWPUserExtendedId, P002N2_A65WWPNotificationDefinitionId, P002N2_A67WWPSubscriptionId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV9WWPNotificationDefinitionId ;
      private long AV10WWPSubscriptionId ;
      private long A65WWPNotificationDefinitionId ;
      private long A67WWPSubscriptionId ;
      private string AV12Udparg1 ;
      private string scmdbuf ;
      private string A49WWPUserExtendedId ;
      private bool AV8IncludeNotification ;
      private bool A69WWPSubscriptionSubscribed ;
      private bool n49WWPUserExtendedId ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private long aP1_WWPSubscriptionId ;
      private bool aP2_IncludeNotification ;
      private IDataStoreProvider pr_default ;
      private bool[] P002N2_A69WWPSubscriptionSubscribed ;
      private string[] P002N2_A49WWPUserExtendedId ;
      private bool[] P002N2_n49WWPUserExtendedId ;
      private long[] P002N2_A65WWPNotificationDefinitionId ;
      private long[] P002N2_A67WWPSubscriptionId ;
   }

   public class wwp_checkuserisnotunsubscribed__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP002N2;
          prmP002N2 = new Object[] {
          new ParDef("AV12Udparg1",GXType.Char,40,0) ,
          new ParDef("AV9WWPNotificationDefinitionId",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P002N2", "SELECT WWPSubscriptionSubscribed, WWPUserExtendedId, WWPNotificationDefinitionId, WWPSubscriptionId FROM WWP_Subscription WHERE (WWPUserExtendedId = ( :AV12Udparg1)) AND (WWPNotificationDefinitionId = :AV9WWPNotificationDefinitionId) AND (WWPSubscriptionSubscribed = FALSE) ORDER BY WWPUserExtendedId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002N2,1, GxCacheFrequency.OFF ,false,true )
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
                ((long[]) buf[4])[0] = rslt.getLong(4);
                return;
       }
    }

 }

}
