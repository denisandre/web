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
   public class wwp_hassubscriptionstodisplay : GXProcedure
   {
      public wwp_hassubscriptionstodisplay( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_hassubscriptionstodisplay( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_WWPEntityName ,
                           short aP1_WWPNotificationAppliesTo ,
                           out bool aP2_HasSubscriptions )
      {
         this.AV11WWPEntityName = aP0_WWPEntityName;
         this.AV10WWPNotificationAppliesTo = aP1_WWPNotificationAppliesTo;
         this.AV9HasSubscriptions = false ;
         initialize();
         executePrivate();
         aP2_HasSubscriptions=this.AV9HasSubscriptions;
      }

      public bool executeUdp( string aP0_WWPEntityName ,
                              short aP1_WWPNotificationAppliesTo )
      {
         execute(aP0_WWPEntityName, aP1_WWPNotificationAppliesTo, out aP2_HasSubscriptions);
         return AV9HasSubscriptions ;
      }

      public void executeSubmit( string aP0_WWPEntityName ,
                                 short aP1_WWPNotificationAppliesTo ,
                                 out bool aP2_HasSubscriptions )
      {
         wwp_hassubscriptionstodisplay objwwp_hassubscriptionstodisplay;
         objwwp_hassubscriptionstodisplay = new wwp_hassubscriptionstodisplay();
         objwwp_hassubscriptionstodisplay.AV11WWPEntityName = aP0_WWPEntityName;
         objwwp_hassubscriptionstodisplay.AV10WWPNotificationAppliesTo = aP1_WWPNotificationAppliesTo;
         objwwp_hassubscriptionstodisplay.AV9HasSubscriptions = false ;
         objwwp_hassubscriptionstodisplay.context.SetSubmitInitialConfig(context);
         objwwp_hassubscriptionstodisplay.initialize();
         Submit( executePrivateCatch,objwwp_hassubscriptionstodisplay);
         aP2_HasSubscriptions=this.AV9HasSubscriptions;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((wwp_hassubscriptionstodisplay)stateInfo).executePrivate();
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
         GXt_int1 = AV8WWPEntityId;
         new GeneXus.Programs.wwpbaseobjects.wwp_getentitybyname(context ).execute(  AV11WWPEntityName, out  GXt_int1) ;
         AV8WWPEntityId = GXt_int1;
         AV9HasSubscriptions = false;
         /* Using cursor P003D2 */
         pr_default.execute(0, new Object[] {AV8WWPEntityId, AV10WWPNotificationAppliesTo});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A62WWPEntityId = P003D2_A62WWPEntityId[0];
            A72WWPNotificationDefinitionAppli = P003D2_A72WWPNotificationDefinitionAppli[0];
            A73WWPNotificationDefinitionAllow = P003D2_A73WWPNotificationDefinitionAllow[0];
            A109WWPNotificationDefinitionSecFu = P003D2_A109WWPNotificationDefinitionSecFu[0];
            A65WWPNotificationDefinitionId = P003D2_A65WWPNotificationDefinitionId[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( A109WWPNotificationDefinitionSecFu)) )
            {
               A110WWPNotificationDefinitionIsAut = true;
            }
            else
            {
               GXt_boolean2 = A110WWPNotificationDefinitionIsAut;
               new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  A109WWPNotificationDefinitionSecFu, out  GXt_boolean2) ;
               A110WWPNotificationDefinitionIsAut = GXt_boolean2;
            }
            if ( A110WWPNotificationDefinitionIsAut )
            {
               AV9HasSubscriptions = true;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
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
         P003D2_A62WWPEntityId = new long[1] ;
         P003D2_A72WWPNotificationDefinitionAppli = new short[1] ;
         P003D2_A73WWPNotificationDefinitionAllow = new bool[] {false} ;
         P003D2_A109WWPNotificationDefinitionSecFu = new string[] {""} ;
         P003D2_A65WWPNotificationDefinitionId = new long[1] ;
         A109WWPNotificationDefinitionSecFu = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_hassubscriptionstodisplay__default(),
            new Object[][] {
                new Object[] {
               P003D2_A62WWPEntityId, P003D2_A72WWPNotificationDefinitionAppli, P003D2_A73WWPNotificationDefinitionAllow, P003D2_A109WWPNotificationDefinitionSecFu, P003D2_A65WWPNotificationDefinitionId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV10WWPNotificationAppliesTo ;
      private short A72WWPNotificationDefinitionAppli ;
      private long AV8WWPEntityId ;
      private long GXt_int1 ;
      private long A62WWPEntityId ;
      private long A65WWPNotificationDefinitionId ;
      private string scmdbuf ;
      private bool AV9HasSubscriptions ;
      private bool A73WWPNotificationDefinitionAllow ;
      private bool A110WWPNotificationDefinitionIsAut ;
      private bool GXt_boolean2 ;
      private string AV11WWPEntityName ;
      private string A109WWPNotificationDefinitionSecFu ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P003D2_A62WWPEntityId ;
      private short[] P003D2_A72WWPNotificationDefinitionAppli ;
      private bool[] P003D2_A73WWPNotificationDefinitionAllow ;
      private string[] P003D2_A109WWPNotificationDefinitionSecFu ;
      private long[] P003D2_A65WWPNotificationDefinitionId ;
      private bool aP2_HasSubscriptions ;
   }

   public class wwp_hassubscriptionstodisplay__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP003D2;
          prmP003D2 = new Object[] {
          new ParDef("AV8WWPEntityId",GXType.Int64,10,0) ,
          new ParDef("AV10WWPNotificationAppliesTo",GXType.Int16,1,0)
          };
          def= new CursorDef[] {
              new CursorDef("P003D2", "SELECT WWPEntityId, WWPNotificationDefinitionAppli, WWPNotificationDefinitionAllow, WWPNotificationDefinitionSecFu, WWPNotificationDefinitionId FROM WWP_NotificationDefinition WHERE (WWPEntityId = :AV8WWPEntityId) AND (WWPNotificationDefinitionAllow = TRUE) AND (WWPNotificationDefinitionAppli = :AV10WWPNotificationAppliesTo) ORDER BY WWPEntityId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003D2,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                return;
       }
    }

 }

}
