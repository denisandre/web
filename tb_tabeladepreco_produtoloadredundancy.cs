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
   public class tb_tabeladepreco_produtoloadredundancy : GXProcedure
   {
      public tb_tabeladepreco_produtoloadredundancy( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", false);
      }

      public tb_tabeladepreco_produtoloadredundancy( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         initialize();
         executePrivate();
      }

      public void executeSubmit( )
      {
         tb_tabeladepreco_produtoloadredundancy objtb_tabeladepreco_produtoloadredundancy;
         objtb_tabeladepreco_produtoloadredundancy = new tb_tabeladepreco_produtoloadredundancy();
         objtb_tabeladepreco_produtoloadredundancy.context.SetSubmitInitialConfig(context);
         objtb_tabeladepreco_produtoloadredundancy.initialize();
         Submit( executePrivateCatch,objtb_tabeladepreco_produtoloadredundancy);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((tb_tabeladepreco_produtoloadredundancy)stateInfo).executePrivate();
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
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A232PrdTipoID = TB_TABELAD2_A232PrdTipoID[0];
            A232PrdTipoID = TB_TABELAD2_A232PrdTipoID[0];
            A222PrdNome = TB_TABELAD2_A222PrdNome[0];
            A222PrdNome = TB_TABELAD2_A222PrdNome[0];
            A221PrdCodigo = TB_TABELAD2_A221PrdCodigo[0];
            A221PrdCodigo = TB_TABELAD2_A221PrdCodigo[0];
            A220PrdID = TB_TABELAD2_A220PrdID[0];
            A235TppID = TB_TABELAD2_A235TppID[0];
            O232PrdTipoID = A232PrdTipoID;
            O222PrdNome = A222PrdNome;
            O221PrdCodigo = A221PrdCodigo;
            A232PrdTipoID = TB_TABELAD2_A232PrdTipoID[0];
            A222PrdNome = TB_TABELAD2_A222PrdNome[0];
            A221PrdCodigo = TB_TABELAD2_A221PrdCodigo[0];
            O232PrdTipoID = A232PrdTipoID;
            O222PrdNome = A222PrdNome;
            O221PrdCodigo = A221PrdCodigo;
            A232PrdTipoID = O232PrdTipoID;
            A222PrdNome = O222PrdNome;
            A221PrdCodigo = O221PrdCodigo;
            O232PrdTipoID = A232PrdTipoID;
            O222PrdNome = A222PrdNome;
            O221PrdCodigo = A221PrdCodigo;
            /* Using cursor TB_TABELAD3 */
            pr_default.execute(1, new Object[] {A232PrdTipoID, A222PrdNome, A221PrdCodigo, A235TppID, A220PrdID});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("tb_tabeladepreco_produto");
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
         TB_TABELAD2_A232PrdTipoID = new int[1] ;
         TB_TABELAD2_A222PrdNome = new string[] {""} ;
         TB_TABELAD2_A221PrdCodigo = new string[] {""} ;
         TB_TABELAD2_A220PrdID = new Guid[] {Guid.Empty} ;
         TB_TABELAD2_A235TppID = new Guid[] {Guid.Empty} ;
         A222PrdNome = "";
         A221PrdCodigo = "";
         A220PrdID = Guid.Empty;
         A235TppID = Guid.Empty;
         O222PrdNome = "";
         O221PrdCodigo = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tb_tabeladepreco_produtoloadredundancy__default(),
            new Object[][] {
                new Object[] {
               TB_TABELAD2_A232PrdTipoID, TB_TABELAD2_A232PrdTipoID, TB_TABELAD2_A222PrdNome, TB_TABELAD2_A222PrdNome, TB_TABELAD2_A221PrdCodigo, TB_TABELAD2_A221PrdCodigo, TB_TABELAD2_A220PrdID, TB_TABELAD2_A235TppID
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int A232PrdTipoID ;
      private int O232PrdTipoID ;
      private string scmdbuf ;
      private string A222PrdNome ;
      private string A221PrdCodigo ;
      private string O222PrdNome ;
      private string O221PrdCodigo ;
      private Guid A220PrdID ;
      private Guid A235TppID ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] TB_TABELAD2_A232PrdTipoID ;
      private string[] TB_TABELAD2_A222PrdNome ;
      private string[] TB_TABELAD2_A221PrdCodigo ;
      private Guid[] TB_TABELAD2_A220PrdID ;
      private Guid[] TB_TABELAD2_A235TppID ;
   }

   public class tb_tabeladepreco_produtoloadredundancy__default : DataStoreHelperBase, IDataStoreHelper
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
          };
          Object[] prmTB_TABELAD3;
          prmTB_TABELAD3 = new Object[] {
          new ParDef("PrdTipoID",GXType.Int32,9,0) ,
          new ParDef("PrdNome",GXType.VarChar,80,0) ,
          new ParDef("PrdCodigo",GXType.VarChar,30,0) ,
          new ParDef("TppID",GXType.UniqueIdentifier,36,0) ,
          new ParDef("PrdID",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("TB_TABELAD2", "SELECT T1.PrdTipoID, T2.PrdTipoID, T1.PrdNome, T2.PrdNome, T1.PrdCodigo, T2.PrdCodigo, T1.PrdID, T1.TppID FROM (tb_tabeladepreco_produto T1 INNER JOIN tb_produto T2 ON T2.PrdID = T1.PrdID) ORDER BY T1.TppID, T1.PrdID  FOR UPDATE OF T1, T1",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmTB_TABELAD2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("TB_TABELAD3", "UPDATE tb_tabeladepreco_produto SET PrdTipoID=:PrdTipoID, PrdNome=:PrdNome, PrdCodigo=:PrdCodigo  WHERE TppID = :TppID AND PrdID = :PrdID", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmTB_TABELAD3)
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((Guid[]) buf[6])[0] = rslt.getGuid(7);
                ((Guid[]) buf[7])[0] = rslt.getGuid(8);
                return;
       }
    }

 }

}
