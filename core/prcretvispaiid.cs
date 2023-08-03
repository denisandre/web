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
namespace GeneXus.Programs.core {
   public class prcretvispaiid : GXProcedure
   {
      public prcretvispaiid( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prcretvispaiid( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_VisID ,
                           out Guid aP1_VisPaiID )
      {
         this.AV8VisID = aP0_VisID;
         this.AV9VisPaiID = Guid.Empty ;
         initialize();
         executePrivate();
         aP1_VisPaiID=this.AV9VisPaiID;
      }

      public Guid executeUdp( Guid aP0_VisID )
      {
         execute(aP0_VisID, out aP1_VisPaiID);
         return AV9VisPaiID ;
      }

      public void executeSubmit( Guid aP0_VisID ,
                                 out Guid aP1_VisPaiID )
      {
         prcretvispaiid objprcretvispaiid;
         objprcretvispaiid = new prcretvispaiid();
         objprcretvispaiid.AV8VisID = aP0_VisID;
         objprcretvispaiid.AV9VisPaiID = Guid.Empty ;
         objprcretvispaiid.context.SetSubmitInitialConfig(context);
         objprcretvispaiid.initialize();
         Submit( executePrivateCatch,objprcretvispaiid);
         aP1_VisPaiID=this.AV9VisPaiID;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((prcretvispaiid)stateInfo).executePrivate();
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
         AV9VisPaiID = Guid.Empty;
         if ( ! (Guid.Empty==AV8VisID) )
         {
            /* Using cursor P007O2 */
            pr_default.execute(0, new Object[] {AV8VisID});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A398VisID = P007O2_A398VisID[0];
               A419VisPaiID = P007O2_A419VisPaiID[0];
               n419VisPaiID = P007O2_n419VisPaiID[0];
               if ( (Guid.Empty==A419VisPaiID) || P007O2_n419VisPaiID[0] )
               {
                  AV9VisPaiID = A398VisID;
               }
               else
               {
                  AV9VisPaiID = A419VisPaiID;
               }
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
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
         AV9VisPaiID = Guid.Empty;
         scmdbuf = "";
         P007O2_A398VisID = new Guid[] {Guid.Empty} ;
         P007O2_A419VisPaiID = new Guid[] {Guid.Empty} ;
         P007O2_n419VisPaiID = new bool[] {false} ;
         A398VisID = Guid.Empty;
         A419VisPaiID = Guid.Empty;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.prcretvispaiid__default(),
            new Object[][] {
                new Object[] {
               P007O2_A398VisID, P007O2_A419VisPaiID, P007O2_n419VisPaiID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private string scmdbuf ;
      private bool n419VisPaiID ;
      private Guid AV8VisID ;
      private Guid AV9VisPaiID ;
      private Guid A398VisID ;
      private Guid A419VisPaiID ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] P007O2_A398VisID ;
      private Guid[] P007O2_A419VisPaiID ;
      private bool[] P007O2_n419VisPaiID ;
      private Guid aP1_VisPaiID ;
   }

   public class prcretvispaiid__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP007O2;
          prmP007O2 = new Object[] {
          new ParDef("AV8VisID",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007O2", "SELECT VisID, VisPaiID FROM tb_visita WHERE VisID = :AV8VisID ORDER BY VisID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007O2,1, GxCacheFrequency.OFF ,false,true )
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
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
       }
    }

 }

}
