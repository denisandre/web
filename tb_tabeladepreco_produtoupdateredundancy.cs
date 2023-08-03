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
   public class tb_tabeladepreco_produtoupdateredundancy : GXProcedure
   {
      public tb_tabeladepreco_produtoupdateredundancy( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", false);
      }

      public tb_tabeladepreco_produtoupdateredundancy( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref Guid aP0_TppID ,
                           ref Guid aP1_PrdID )
      {
         this.A235TppID = aP0_TppID;
         this.A220PrdID = aP1_PrdID;
         initialize();
         executePrivate();
         aP0_TppID=this.A235TppID;
         aP1_PrdID=this.A220PrdID;
      }

      public Guid executeUdp( ref Guid aP0_TppID )
      {
         execute(ref aP0_TppID, ref aP1_PrdID);
         return A220PrdID ;
      }

      public void executeSubmit( ref Guid aP0_TppID ,
                                 ref Guid aP1_PrdID )
      {
         tb_tabeladepreco_produtoupdateredundancy objtb_tabeladepreco_produtoupdateredundancy;
         objtb_tabeladepreco_produtoupdateredundancy = new tb_tabeladepreco_produtoupdateredundancy();
         objtb_tabeladepreco_produtoupdateredundancy.A235TppID = aP0_TppID;
         objtb_tabeladepreco_produtoupdateredundancy.A220PrdID = aP1_PrdID;
         objtb_tabeladepreco_produtoupdateredundancy.context.SetSubmitInitialConfig(context);
         objtb_tabeladepreco_produtoupdateredundancy.initialize();
         Submit( executePrivateCatch,objtb_tabeladepreco_produtoupdateredundancy);
         aP0_TppID=this.A235TppID;
         aP1_PrdID=this.A220PrdID;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((tb_tabeladepreco_produtoupdateredundancy)stateInfo).executePrivate();
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
         /* Using cursor TB_TABELAD2 */
         pr_default.execute(0, new Object[] {A235TppID, A220PrdID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A221PrdCodigo = TB_TABELAD2_A221PrdCodigo[0];
            A222PrdNome = TB_TABELAD2_A222PrdNome[0];
            AV2GXV221 = A221PrdCodigo;
            AV3GXV222 = A222PrdNome;
            AV4GXV440 = AV2GXV221;
            AV5GXV441 = AV3GXV222;
            n441NgpTppPrdNome = false;
            n440NgpTppPrdCodigo = false;
            /* Optimized UPDATE. */
            /* Using cursor TB_TABELAD3 */
            pr_default.execute(1, new Object[] {n441NgpTppPrdNome, AV5GXV441, n440NgpTppPrdCodigo, AV4GXV440, A235TppID, A220PrdID});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("tb_negociopj_item");
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
         TB_TABELAD2_A235TppID = new Guid[] {Guid.Empty} ;
         TB_TABELAD2_A220PrdID = new Guid[] {Guid.Empty} ;
         TB_TABELAD2_A221PrdCodigo = new string[] {""} ;
         TB_TABELAD2_A222PrdNome = new string[] {""} ;
         A221PrdCodigo = "";
         A222PrdNome = "";
         AV2GXV221 = "";
         AV3GXV222 = "";
         AV4GXV440 = "";
         AV5GXV441 = "";
         A441NgpTppPrdNome = "";
         A440NgpTppPrdCodigo = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tb_tabeladepreco_produtoupdateredundancy__default(),
            new Object[][] {
                new Object[] {
               TB_TABELAD2_A235TppID, TB_TABELAD2_A220PrdID, TB_TABELAD2_A221PrdCodigo, TB_TABELAD2_A222PrdNome
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private string scmdbuf ;
      private bool n441NgpTppPrdNome ;
      private bool n440NgpTppPrdCodigo ;
      private string A221PrdCodigo ;
      private string A222PrdNome ;
      private string AV2GXV221 ;
      private string AV3GXV222 ;
      private string AV4GXV440 ;
      private string AV5GXV441 ;
      private string A441NgpTppPrdNome ;
      private string A440NgpTppPrdCodigo ;
      private Guid A235TppID ;
      private Guid A220PrdID ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private Guid aP0_TppID ;
      private Guid aP1_PrdID ;
      private IDataStoreProvider pr_default ;
      private Guid[] TB_TABELAD2_A235TppID ;
      private Guid[] TB_TABELAD2_A220PrdID ;
      private string[] TB_TABELAD2_A221PrdCodigo ;
      private string[] TB_TABELAD2_A222PrdNome ;
   }

   public class tb_tabeladepreco_produtoupdateredundancy__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmTB_TABELAD2;
          prmTB_TABELAD2 = new Object[] {
          new ParDef("TppID",GXType.UniqueIdentifier,36,0) ,
          new ParDef("PrdID",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmTB_TABELAD3;
          prmTB_TABELAD3 = new Object[] {
          new ParDef("NgpTppPrdNome",GXType.VarChar,80,0){Nullable=true} ,
          new ParDef("NgpTppPrdCodigo",GXType.VarChar,30,0){Nullable=true} ,
          new ParDef("TppID",GXType.UniqueIdentifier,36,0) ,
          new ParDef("PrdID",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("TB_TABELAD2", "SELECT TppID, PrdID, PrdCodigo, PrdNome FROM tb_tabeladepreco_produto WHERE TppID = :TppID and PrdID = :PrdID ORDER BY TppID, PrdID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmTB_TABELAD2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("TB_TABELAD3", "UPDATE tb_negociopj_item SET NgpTppPrdNome=:NgpTppPrdNome, NgpTppPrdCodigo=:NgpTppPrdCodigo  WHERE NgpTppID = :TppID and NgpTppPrdID = :PrdID", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmTB_TABELAD3)
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
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                return;
       }
    }

 }

}
