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
   public class wwp_getentitybyname : GXProcedure
   {
      public wwp_getentitybyname( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_getentitybyname( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_WWPEntityName ,
                           out long aP1_WWPEntityId )
      {
         this.AV8WWPEntityName = aP0_WWPEntityName;
         this.AV9WWPEntityId = 0 ;
         initialize();
         executePrivate();
         aP1_WWPEntityId=this.AV9WWPEntityId;
      }

      public long executeUdp( string aP0_WWPEntityName )
      {
         execute(aP0_WWPEntityName, out aP1_WWPEntityId);
         return AV9WWPEntityId ;
      }

      public void executeSubmit( string aP0_WWPEntityName ,
                                 out long aP1_WWPEntityId )
      {
         wwp_getentitybyname objwwp_getentitybyname;
         objwwp_getentitybyname = new wwp_getentitybyname();
         objwwp_getentitybyname.AV8WWPEntityName = aP0_WWPEntityName;
         objwwp_getentitybyname.AV9WWPEntityId = 0 ;
         objwwp_getentitybyname.context.SetSubmitInitialConfig(context);
         objwwp_getentitybyname.initialize();
         Submit( executePrivateCatch,objwwp_getentitybyname);
         aP1_WWPEntityId=this.AV9WWPEntityId;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((wwp_getentitybyname)stateInfo).executePrivate();
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
         AV11GXLvl1 = 0;
         /* Using cursor P002I2 */
         pr_default.execute(0, new Object[] {AV8WWPEntityName});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A63WWPEntityName = P002I2_A63WWPEntityName[0];
            A62WWPEntityId = P002I2_A62WWPEntityId[0];
            AV11GXLvl1 = 1;
            AV9WWPEntityId = A62WWPEntityId;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV11GXLvl1 == 0 )
         {
            AV10WWP_Entity = new GeneXus.Programs.wwpbaseobjects.SdtWWP_Entity(context);
            AV10WWP_Entity.gxTpr_Wwpentityname = AV8WWPEntityName;
            AV10WWP_Entity.Save();
            if ( AV10WWP_Entity.Success() )
            {
               AV9WWPEntityId = AV10WWP_Entity.gxTpr_Wwpentityid;
            }
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
         scmdbuf = "";
         P002I2_A63WWPEntityName = new string[] {""} ;
         P002I2_A62WWPEntityId = new long[1] ;
         A63WWPEntityName = "";
         AV10WWP_Entity = new GeneXus.Programs.wwpbaseobjects.SdtWWP_Entity(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.wwp_getentitybyname__default(),
            new Object[][] {
                new Object[] {
               P002I2_A63WWPEntityName, P002I2_A62WWPEntityId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV11GXLvl1 ;
      private long AV9WWPEntityId ;
      private long A62WWPEntityId ;
      private string scmdbuf ;
      private string AV8WWPEntityName ;
      private string A63WWPEntityName ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P002I2_A63WWPEntityName ;
      private long[] P002I2_A62WWPEntityId ;
      private long aP1_WWPEntityId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWP_Entity AV10WWP_Entity ;
   }

   public class wwp_getentitybyname__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP002I2;
          prmP002I2 = new Object[] {
          new ParDef("AV8WWPEntityName",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P002I2", "SELECT WWPEntityName, WWPEntityId FROM WWP_Entity WHERE WWPEntityName = ( :AV8WWPEntityName) ORDER BY WWPEntityId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002I2,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                return;
       }
    }

 }

}
