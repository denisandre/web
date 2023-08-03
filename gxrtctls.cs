using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Reorg;
using System.Threading;
using GeneXus.Programs;
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
using System.Xml.Serialization;
namespace GeneXus.Programs {
   public class gxrtctls : GXProcedure
   {
      public gxrtctls( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", false);
      }

      public gxrtctls( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out short aP0_Status )
      {
         this.AV2Status = 0 ;
         initialize();
         executePrivate();
         aP0_Status=this.AV2Status;
      }

      public short executeUdp( )
      {
         execute(out aP0_Status);
         return AV2Status ;
      }

      public void executeSubmit( out short aP0_Status )
      {
         gxrtctls objgxrtctls;
         objgxrtctls = new gxrtctls();
         objgxrtctls.AV2Status = 0 ;
         objgxrtctls.context.SetSubmitInitialConfig(context);
         objgxrtctls.initialize();
         Submit( executePrivateCatch,objgxrtctls);
         aP0_Status=this.AV2Status;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((gxrtctls)stateInfo).executePrivate();
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
         AV2Status = 0;
         Console.WriteLine( "=== Starting run time controls" );
         Console.WriteLine( "Checking that table tb_Iteracao does NOT contain records." );
         AV3GXLvl4 = 0;
         /* Using cursor LTCTLS2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A381IteID = LTCTLS2_A381IteID[0];
            AV3GXLvl4 = 1;
            AV2Status = 1;
            Console.WriteLine( "Fail: Table tb_Iteracao has records." );
            Console.WriteLine( "Recovery: See recovery information for reorganization message rgz0019." );
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV3GXLvl4 == 0 )
         {
            Console.WriteLine( "Success: Table tb_Iteracao does NOT have records." );
         }
         Console.WriteLine( "====================" );
         Console.WriteLine( "=== End of run time controls" );
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
         LTCTLS2_A381IteID = new Guid[] {Guid.Empty} ;
         A381IteID = Guid.Empty;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gxrtctls__default(),
            new Object[][] {
                new Object[] {
               LTCTLS2_A381IteID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV2Status ;
      private short AV3GXLvl4 ;
      private string scmdbuf ;
      private Guid A381IteID ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] LTCTLS2_A381IteID ;
      private short aP0_Status ;
   }

   public class gxrtctls__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmLTCTLS2;
          prmLTCTLS2 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("LTCTLS2", "SELECT IteID FROM tb_Iteracao ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmLTCTLS2,1, GxCacheFrequency.OFF ,false,true )
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
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                return;
       }
    }

 }

}
