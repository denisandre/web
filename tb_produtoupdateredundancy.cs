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
   public class tb_produtoupdateredundancy : GXProcedure
   {
      public tb_produtoupdateredundancy( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", false);
      }

      public tb_produtoupdateredundancy( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref Guid aP0_PrdID )
      {
         this.A220PrdID = aP0_PrdID;
         initialize();
         executePrivate();
         aP0_PrdID=this.A220PrdID;
      }

      public Guid executeUdp( )
      {
         execute(ref aP0_PrdID);
         return A220PrdID ;
      }

      public void executeSubmit( ref Guid aP0_PrdID )
      {
         tb_produtoupdateredundancy objtb_produtoupdateredundancy;
         objtb_produtoupdateredundancy = new tb_produtoupdateredundancy();
         objtb_produtoupdateredundancy.A220PrdID = aP0_PrdID;
         objtb_produtoupdateredundancy.context.SetSubmitInitialConfig(context);
         objtb_produtoupdateredundancy.initialize();
         Submit( executePrivateCatch,objtb_produtoupdateredundancy);
         aP0_PrdID=this.A220PrdID;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((tb_produtoupdateredundancy)stateInfo).executePrivate();
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
         /* Using cursor TB_PRODUTO2 */
         pr_default.execute(0, new Object[] {A220PrdID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A221PrdCodigo = TB_PRODUTO2_A221PrdCodigo[0];
            A222PrdNome = TB_PRODUTO2_A222PrdNome[0];
            A232PrdTipoID = TB_PRODUTO2_A232PrdTipoID[0];
            AV2GXV221 = A221PrdCodigo;
            AV3GXV222 = A222PrdNome;
            AV4GXV232 = A232PrdTipoID;
            /* Optimized UPDATE. */
            /* Using cursor TB_PRODUTO3 */
            pr_default.execute(1, new Object[] {AV4GXV232, AV3GXV222, AV2GXV221, A220PrdID});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("tb_tabeladepreco_produto");
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
         TB_PRODUTO2_A220PrdID = new Guid[] {Guid.Empty} ;
         TB_PRODUTO2_A221PrdCodigo = new string[] {""} ;
         TB_PRODUTO2_A222PrdNome = new string[] {""} ;
         TB_PRODUTO2_A232PrdTipoID = new int[1] ;
         A221PrdCodigo = "";
         A222PrdNome = "";
         AV2GXV221 = "";
         AV3GXV222 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tb_produtoupdateredundancy__default(),
            new Object[][] {
                new Object[] {
               TB_PRODUTO2_A220PrdID, TB_PRODUTO2_A221PrdCodigo, TB_PRODUTO2_A222PrdNome, TB_PRODUTO2_A232PrdTipoID
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int A232PrdTipoID ;
      private int AV4GXV232 ;
      private string scmdbuf ;
      private string A221PrdCodigo ;
      private string A222PrdNome ;
      private string AV2GXV221 ;
      private string AV3GXV222 ;
      private Guid A220PrdID ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private Guid aP0_PrdID ;
      private IDataStoreProvider pr_default ;
      private Guid[] TB_PRODUTO2_A220PrdID ;
      private string[] TB_PRODUTO2_A221PrdCodigo ;
      private string[] TB_PRODUTO2_A222PrdNome ;
      private int[] TB_PRODUTO2_A232PrdTipoID ;
   }

   public class tb_produtoupdateredundancy__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmTB_PRODUTO2;
          prmTB_PRODUTO2 = new Object[] {
          new ParDef("PrdID",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmTB_PRODUTO3;
          prmTB_PRODUTO3 = new Object[] {
          new ParDef("PrdTipoID",GXType.Int32,9,0) ,
          new ParDef("PrdNome",GXType.VarChar,80,0) ,
          new ParDef("PrdCodigo",GXType.VarChar,30,0) ,
          new ParDef("PrdID",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("TB_PRODUTO2", "SELECT PrdID, PrdCodigo, PrdNome, PrdTipoID FROM tb_produto WHERE PrdID = :PrdID ORDER BY PrdID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmTB_PRODUTO2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("TB_PRODUTO3", "UPDATE tb_tabeladepreco_produto SET PrdTipoID=:PrdTipoID, PrdNome=:PrdNome, PrdCodigo=:PrdCodigo  WHERE PrdID = :PrdID", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmTB_PRODUTO3)
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
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                return;
       }
    }

 }

}
