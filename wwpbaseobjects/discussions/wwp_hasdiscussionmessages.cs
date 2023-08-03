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
   public class wwp_hasdiscussionmessages : GXProcedure
   {
      public wwp_hasdiscussionmessages( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_hasdiscussionmessages( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_WWPEntityName ,
                           string aP1_WWPDiscussionMessageEntityRecordId ,
                           out bool aP2_HasDiscussionMessages )
      {
         this.AV10WWPEntityName = aP0_WWPEntityName;
         this.AV9WWPDiscussionMessageEntityRecordId = aP1_WWPDiscussionMessageEntityRecordId;
         this.AV8HasDiscussionMessages = false ;
         initialize();
         executePrivate();
         aP2_HasDiscussionMessages=this.AV8HasDiscussionMessages;
      }

      public bool executeUdp( string aP0_WWPEntityName ,
                              string aP1_WWPDiscussionMessageEntityRecordId )
      {
         execute(aP0_WWPEntityName, aP1_WWPDiscussionMessageEntityRecordId, out aP2_HasDiscussionMessages);
         return AV8HasDiscussionMessages ;
      }

      public void executeSubmit( string aP0_WWPEntityName ,
                                 string aP1_WWPDiscussionMessageEntityRecordId ,
                                 out bool aP2_HasDiscussionMessages )
      {
         wwp_hasdiscussionmessages objwwp_hasdiscussionmessages;
         objwwp_hasdiscussionmessages = new wwp_hasdiscussionmessages();
         objwwp_hasdiscussionmessages.AV10WWPEntityName = aP0_WWPEntityName;
         objwwp_hasdiscussionmessages.AV9WWPDiscussionMessageEntityRecordId = aP1_WWPDiscussionMessageEntityRecordId;
         objwwp_hasdiscussionmessages.AV8HasDiscussionMessages = false ;
         objwwp_hasdiscussionmessages.context.SetSubmitInitialConfig(context);
         objwwp_hasdiscussionmessages.initialize();
         Submit( executePrivateCatch,objwwp_hasdiscussionmessages);
         aP2_HasDiscussionMessages=this.AV8HasDiscussionMessages;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((wwp_hasdiscussionmessages)stateInfo).executePrivate();
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
         AV8HasDiscussionMessages = false;
         AV12Udparg1 = new GeneXus.Programs.wwpbaseobjects.wwp_getentitybyname(context).executeUdp(  AV10WWPEntityName);
         /* Using cursor P003K2 */
         pr_default.execute(0, new Object[] {AV12Udparg1, AV9WWPDiscussionMessageEntityRecordId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A136WWPDiscussionMessageThreadId = P003K2_A136WWPDiscussionMessageThreadId[0];
            n136WWPDiscussionMessageThreadId = P003K2_n136WWPDiscussionMessageThreadId[0];
            A142WWPDiscussionMessageEntityReco = P003K2_A142WWPDiscussionMessageEntityReco[0];
            A62WWPEntityId = P003K2_A62WWPEntityId[0];
            A137WWPDiscussionMessageId = P003K2_A137WWPDiscussionMessageId[0];
            AV8HasDiscussionMessages = true;
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
         scmdbuf = "";
         P003K2_A136WWPDiscussionMessageThreadId = new long[1] ;
         P003K2_n136WWPDiscussionMessageThreadId = new bool[] {false} ;
         P003K2_A142WWPDiscussionMessageEntityReco = new string[] {""} ;
         P003K2_A62WWPEntityId = new long[1] ;
         P003K2_A137WWPDiscussionMessageId = new long[1] ;
         A142WWPDiscussionMessageEntityReco = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.discussions.wwp_hasdiscussionmessages__default(),
            new Object[][] {
                new Object[] {
               P003K2_A136WWPDiscussionMessageThreadId, P003K2_n136WWPDiscussionMessageThreadId, P003K2_A142WWPDiscussionMessageEntityReco, P003K2_A62WWPEntityId, P003K2_A137WWPDiscussionMessageId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV12Udparg1 ;
      private long A136WWPDiscussionMessageThreadId ;
      private long A62WWPEntityId ;
      private long A137WWPDiscussionMessageId ;
      private string scmdbuf ;
      private bool AV8HasDiscussionMessages ;
      private bool n136WWPDiscussionMessageThreadId ;
      private string AV10WWPEntityName ;
      private string AV9WWPDiscussionMessageEntityRecordId ;
      private string A142WWPDiscussionMessageEntityReco ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P003K2_A136WWPDiscussionMessageThreadId ;
      private bool[] P003K2_n136WWPDiscussionMessageThreadId ;
      private string[] P003K2_A142WWPDiscussionMessageEntityReco ;
      private long[] P003K2_A62WWPEntityId ;
      private long[] P003K2_A137WWPDiscussionMessageId ;
      private bool aP2_HasDiscussionMessages ;
   }

   public class wwp_hasdiscussionmessages__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP003K2;
          prmP003K2 = new Object[] {
          new ParDef("AV12Udparg1",GXType.Int64,10,0) ,
          new ParDef("AV9WWPDiscussionMessageEntityRecordId",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P003K2", "SELECT WWPDiscussionMessageThreadId, WWPDiscussionMessageEntityReco, WWPEntityId, WWPDiscussionMessageId FROM WWP_DiscussionMessage WHERE (WWPEntityId = :AV12Udparg1) AND (WWPDiscussionMessageThreadId IS NULL or (WWPDiscussionMessageThreadId = 0)) AND (WWPDiscussionMessageEntityReco = ( :AV9WWPDiscussionMessageEntityRecordId)) ORDER BY WWPEntityId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003K2,1, GxCacheFrequency.OFF ,false,true )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((long[]) buf[3])[0] = rslt.getLong(3);
                ((long[]) buf[4])[0] = rslt.getLong(4);
                return;
       }
    }

 }

}
