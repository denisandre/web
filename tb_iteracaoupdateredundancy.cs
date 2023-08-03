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
   public class tb_iteracaoupdateredundancy : GXProcedure
   {
      public tb_iteracaoupdateredundancy( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", false);
      }

      public tb_iteracaoupdateredundancy( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref Guid aP0_IteID )
      {
         this.A381IteID = aP0_IteID;
         initialize();
         executePrivate();
         aP0_IteID=this.A381IteID;
      }

      public Guid executeUdp( )
      {
         execute(ref aP0_IteID);
         return A381IteID ;
      }

      public void executeSubmit( ref Guid aP0_IteID )
      {
         tb_iteracaoupdateredundancy objtb_iteracaoupdateredundancy;
         objtb_iteracaoupdateredundancy = new tb_iteracaoupdateredundancy();
         objtb_iteracaoupdateredundancy.A381IteID = aP0_IteID;
         objtb_iteracaoupdateredundancy.context.SetSubmitInitialConfig(context);
         objtb_iteracaoupdateredundancy.initialize();
         Submit( executePrivateCatch,objtb_iteracaoupdateredundancy);
         aP0_IteID=this.A381IteID;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((tb_iteracaoupdateredundancy)stateInfo).executePrivate();
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
         /* Using cursor TB_ITERACA2 */
         pr_default.execute(0, new Object[] {A381IteID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A383IteNome = TB_ITERACA2_A383IteNome[0];
            AV2GXV383 = A383IteNome;
            AV3GXV397 = AV2GXV383;
            /* Optimized UPDATE. */
            /* Using cursor TB_ITERACA3 */
            pr_default.execute(1, new Object[] {AV3GXV397, A381IteID});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("tb_negociopj_fase");
            /* End optimized UPDATE. */
            /* Exiting from a For First loop. */
            if (true) break;
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
         TB_ITERACA2_A381IteID = new Guid[] {Guid.Empty} ;
         TB_ITERACA2_A383IteNome = new string[] {""} ;
         A383IteNome = "";
         AV2GXV383 = "";
         AV3GXV397 = "";
         A397NgfIteNome = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tb_iteracaoupdateredundancy__default(),
            new Object[][] {
                new Object[] {
               TB_ITERACA2_A381IteID, TB_ITERACA2_A383IteNome
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private string scmdbuf ;
      private string A383IteNome ;
      private string AV2GXV383 ;
      private string AV3GXV397 ;
      private string A397NgfIteNome ;
      private Guid A381IteID ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private Guid aP0_IteID ;
      private IDataStoreProvider pr_default ;
      private Guid[] TB_ITERACA2_A381IteID ;
      private string[] TB_ITERACA2_A383IteNome ;
   }

   public class tb_iteracaoupdateredundancy__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmTB_ITERACA2;
          prmTB_ITERACA2 = new Object[] {
          new ParDef("IteID",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmTB_ITERACA3;
          prmTB_ITERACA3 = new Object[] {
          new ParDef("NgfIteNome",GXType.VarChar,80,0) ,
          new ParDef("IteID",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("TB_ITERACA2", "SELECT IteID, IteNome FROM tb_Iteracao WHERE IteID = :IteID ORDER BY IteID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmTB_ITERACA2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("TB_ITERACA3", "UPDATE tb_negociopj_fase SET NgfIteNome=:NgfIteNome  WHERE NgfIteID = :IteID", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmTB_ITERACA3)
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
       }
    }

 }

}
