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
namespace GeneXus.Programs.wwpbaseobjects.discussions {
   public class wwp_subscribeloggedusertodiscussion : GXProcedure
   {
      public wwp_subscribeloggedusertodiscussion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_subscribeloggedusertodiscussion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_WWPNotificationDefinitionName ,
                           string aP1_WWPEntityName ,
                           string aP2_WWPSubscriptionEntityRecordId ,
                           string aP3_WWPSubscriptionEntityRecordDescription )
      {
         this.AV8WWPNotificationDefinitionName = aP0_WWPNotificationDefinitionName;
         this.AV12WWPEntityName = aP1_WWPEntityName;
         this.AV9WWPSubscriptionEntityRecordId = aP2_WWPSubscriptionEntityRecordId;
         this.AV11WWPSubscriptionEntityRecordDescription = aP3_WWPSubscriptionEntityRecordDescription;
         initialize();
         executePrivate();
      }

      public void executeSubmit( string aP0_WWPNotificationDefinitionName ,
                                 string aP1_WWPEntityName ,
                                 string aP2_WWPSubscriptionEntityRecordId ,
                                 string aP3_WWPSubscriptionEntityRecordDescription )
      {
         wwp_subscribeloggedusertodiscussion objwwp_subscribeloggedusertodiscussion;
         objwwp_subscribeloggedusertodiscussion = new wwp_subscribeloggedusertodiscussion();
         objwwp_subscribeloggedusertodiscussion.AV8WWPNotificationDefinitionName = aP0_WWPNotificationDefinitionName;
         objwwp_subscribeloggedusertodiscussion.AV12WWPEntityName = aP1_WWPEntityName;
         objwwp_subscribeloggedusertodiscussion.AV9WWPSubscriptionEntityRecordId = aP2_WWPSubscriptionEntityRecordId;
         objwwp_subscribeloggedusertodiscussion.AV11WWPSubscriptionEntityRecordDescription = aP3_WWPSubscriptionEntityRecordDescription;
         objwwp_subscribeloggedusertodiscussion.context.SetSubmitInitialConfig(context);
         objwwp_subscribeloggedusertodiscussion.initialize();
         Submit( executePrivateCatch,objwwp_subscribeloggedusertodiscussion);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((wwp_subscribeloggedusertodiscussion)stateInfo).executePrivate();
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
         AV13GXLvl1 = 0;
         AV14Udparg1 = new GeneXus.Programs.wwpbaseobjects.wwp_getentitybyname(context).executeUdp(  AV12WWPEntityName);
         /* Using cursor P003H2 */
         pr_default.execute(0, new Object[] {AV14Udparg1, AV8WWPNotificationDefinitionName});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A65WWPNotificationDefinitionId = P003H2_A65WWPNotificationDefinitionId[0];
            A62WWPEntityId = P003H2_A62WWPEntityId[0];
            A101WWPNotificationDefinitionName = P003H2_A101WWPNotificationDefinitionName[0];
            AV13GXLvl1 = 1;
            AV15GXLvl5 = 0;
            AV16Udparg2 = new GeneXus.Programs.wwpbaseobjects.wwp_getloggeduserid(context).executeUdp( );
            /* Optimized UPDATE. */
            /* Using cursor P003H3 */
            pr_default.execute(1, new Object[] {AV16Udparg2, A65WWPNotificationDefinitionId, AV9WWPSubscriptionEntityRecordId});
            if ( (pr_default.getStatus(1) != 101) )
            {
               AV15GXLvl5 = 1;
            }
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("WWP_Subscription");
            /* End optimized UPDATE. */
            if ( AV15GXLvl5 == 0 )
            {
               AV10WWPSubscription = new GeneXus.Programs.wwpbaseobjects.subscriptions.SdtWWP_Subscription(context);
               AV10WWPSubscription.gxTpr_Wwpnotificationdefinitionid = A65WWPNotificationDefinitionId;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_getloggeduserid(context ).execute( out  GXt_char1) ;
               AV10WWPSubscription.gxTpr_Wwpuserextendedid = GXt_char1;
               AV10WWPSubscription.gxTpr_Wwpsubscriptionentityrecordid = AV9WWPSubscriptionEntityRecordId;
               AV10WWPSubscription.gxTpr_Wwpsubscriptionentityrecorddescription = AV11WWPSubscriptionEntityRecordDescription;
               AV10WWPSubscription.gxTpr_Wwpsubscriptionsubscribed = true;
               AV10WWPSubscription.Save();
               if ( AV10WWPSubscription.Success() )
               {
                  context.CommitDataStores("wwpbaseobjects.discussions.wwp_subscribeloggedusertodiscussion",pr_default);
               }
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV13GXLvl1 == 0 )
         {
            new GeneXus.Programs.wwpbaseobjects.wwp_logger(context ).gxep_error(  AV17Pgmname,  StringUtil.Format( "WWP_NotificationDefinition not found: %1", AV8WWPNotificationDefinitionName, "", "", "", "", "", "", "", "")) ;
         }
         this.cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("wwpbaseobjects.discussions.wwp_subscribeloggedusertodiscussion",pr_default);
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
         P003H2_A65WWPNotificationDefinitionId = new long[1] ;
         P003H2_A62WWPEntityId = new long[1] ;
         P003H2_A101WWPNotificationDefinitionName = new string[] {""} ;
         A101WWPNotificationDefinitionName = "";
         AV16Udparg2 = "";
         AV10WWPSubscription = new GeneXus.Programs.wwpbaseobjects.subscriptions.SdtWWP_Subscription(context);
         GXt_char1 = "";
         AV17Pgmname = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.discussions.wwp_subscribeloggedusertodiscussion__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.discussions.wwp_subscribeloggedusertodiscussion__default(),
            new Object[][] {
                new Object[] {
               P003H2_A65WWPNotificationDefinitionId, P003H2_A62WWPEntityId, P003H2_A101WWPNotificationDefinitionName
               }
               , new Object[] {
               }
            }
         );
         AV17Pgmname = "WWPBaseObjects.Discussions.WWP_SubscribeLoggedUserToDiscussion";
         /* GeneXus formulas. */
         AV17Pgmname = "WWPBaseObjects.Discussions.WWP_SubscribeLoggedUserToDiscussion";
      }

      private short AV13GXLvl1 ;
      private short AV15GXLvl5 ;
      private long AV14Udparg1 ;
      private long A65WWPNotificationDefinitionId ;
      private long A62WWPEntityId ;
      private string scmdbuf ;
      private string AV16Udparg2 ;
      private string GXt_char1 ;
      private string AV17Pgmname ;
      private string AV8WWPNotificationDefinitionName ;
      private string AV12WWPEntityName ;
      private string AV9WWPSubscriptionEntityRecordId ;
      private string AV11WWPSubscriptionEntityRecordDescription ;
      private string A101WWPNotificationDefinitionName ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P003H2_A65WWPNotificationDefinitionId ;
      private long[] P003H2_A62WWPEntityId ;
      private string[] P003H2_A101WWPNotificationDefinitionName ;
      private IDataStoreProvider pr_gam ;
      private GeneXus.Programs.wwpbaseobjects.subscriptions.SdtWWP_Subscription AV10WWPSubscription ;
   }

   public class wwp_subscribeloggedusertodiscussion__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_subscribeloggedusertodiscussion__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
       ,new UpdateCursor(def[1])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmP003H2;
        prmP003H2 = new Object[] {
        new ParDef("AV14Udparg1",GXType.Int64,10,0) ,
        new ParDef("AV8WWPNotificationDefinitionName",GXType.VarChar,100,0)
        };
        Object[] prmP003H3;
        prmP003H3 = new Object[] {
        new ParDef("AV16Udparg2",GXType.Char,40,0) ,
        new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0) ,
        new ParDef("AV9WWPSubscriptionEntityRecordId",GXType.VarChar,2000,0)
        };
        def= new CursorDef[] {
            new CursorDef("P003H2", "SELECT WWPNotificationDefinitionId, WWPEntityId, WWPNotificationDefinitionName FROM WWP_NotificationDefinition WHERE (WWPEntityId = :AV14Udparg1) AND (WWPNotificationDefinitionName = ( :AV8WWPNotificationDefinitionName)) ORDER BY WWPEntityId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003H2,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("P003H3", "UPDATE WWP_Subscription SET WWPSubscriptionSubscribed=TRUE  WHERE (WWPUserExtendedId = ( :AV16Udparg2)) AND (WWPNotificationDefinitionId = :WWPNotificationDefinitionId) AND (WWPSubscriptionEntityRecordId = ( :AV9WWPSubscriptionEntityRecordId))", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP003H3)
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
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
     }
  }

}

}
