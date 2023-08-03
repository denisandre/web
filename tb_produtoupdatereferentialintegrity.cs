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
   public class tb_produtoupdatereferentialintegrity : GXProcedure
   {
      public tb_produtoupdatereferentialintegrity( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", false);
      }

      public tb_produtoupdatereferentialintegrity( IGxContext context )
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
         tb_produtoupdatereferentialintegrity objtb_produtoupdatereferentialintegrity;
         objtb_produtoupdatereferentialintegrity = new tb_produtoupdatereferentialintegrity();
         objtb_produtoupdatereferentialintegrity.context.SetSubmitInitialConfig(context);
         objtb_produtoupdatereferentialintegrity.initialize();
         Submit( executePrivateCatch,objtb_produtoupdatereferentialintegrity);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((tb_produtoupdatereferentialintegrity)stateInfo).executePrivate();
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
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A230PrdUpdUsuID = TB_PRODUTO2_A230PrdUpdUsuID[0];
            n230PrdUpdUsuID = TB_PRODUTO2_n230PrdUpdUsuID[0];
            A229PrdUpdDataHora = TB_PRODUTO2_A229PrdUpdDataHora[0];
            n229PrdUpdDataHora = TB_PRODUTO2_n229PrdUpdDataHora[0];
            A228PrdUpdHora = TB_PRODUTO2_A228PrdUpdHora[0];
            n228PrdUpdHora = TB_PRODUTO2_n228PrdUpdHora[0];
            A227PrdUpdData = TB_PRODUTO2_A227PrdUpdData[0];
            n227PrdUpdData = TB_PRODUTO2_n227PrdUpdData[0];
            A226PrdInsUsuID = TB_PRODUTO2_A226PrdInsUsuID[0];
            n226PrdInsUsuID = TB_PRODUTO2_n226PrdInsUsuID[0];
            A232PrdTipoID = TB_PRODUTO2_A232PrdTipoID[0];
            A231PrdAtivo = TB_PRODUTO2_A231PrdAtivo[0];
            A225PrdInsDataHora = TB_PRODUTO2_A225PrdInsDataHora[0];
            A224PrdInsHora = TB_PRODUTO2_A224PrdInsHora[0];
            A223PrdInsData = TB_PRODUTO2_A223PrdInsData[0];
            A222PrdNome = TB_PRODUTO2_A222PrdNome[0];
            A221PrdCodigo = TB_PRODUTO2_A221PrdCodigo[0];
            A220PrdID = TB_PRODUTO2_A220PrdID[0];
            /*
               INSERT RECORD ON TABLE tb_produto

            */
            W220PrdID = A220PrdID;
            W221PrdCodigo = A221PrdCodigo;
            W222PrdNome = A222PrdNome;
            W223PrdInsData = A223PrdInsData;
            W224PrdInsHora = A224PrdInsHora;
            W225PrdInsDataHora = A225PrdInsDataHora;
            W226PrdInsUsuID = A226PrdInsUsuID;
            n226PrdInsUsuID = false;
            W226PrdInsUsuID = A226PrdInsUsuID;
            n226PrdInsUsuID = false;
            W227PrdUpdData = A227PrdUpdData;
            n227PrdUpdData = false;
            W227PrdUpdData = A227PrdUpdData;
            n227PrdUpdData = false;
            W228PrdUpdHora = A228PrdUpdHora;
            n228PrdUpdHora = false;
            W228PrdUpdHora = A228PrdUpdHora;
            n228PrdUpdHora = false;
            W229PrdUpdDataHora = A229PrdUpdDataHora;
            n229PrdUpdDataHora = false;
            W229PrdUpdDataHora = A229PrdUpdDataHora;
            n229PrdUpdDataHora = false;
            W230PrdUpdUsuID = A230PrdUpdUsuID;
            n230PrdUpdUsuID = false;
            W230PrdUpdUsuID = A230PrdUpdUsuID;
            n230PrdUpdUsuID = false;
            W231PrdAtivo = A231PrdAtivo;
            W232PrdTipoID = A232PrdTipoID;
            if ( TB_PRODUTO2_n226PrdInsUsuID[0] )
            {
               A226PrdInsUsuID = "";
               n226PrdInsUsuID = false;
               n226PrdInsUsuID = true;
            }
            else
            {
               n226PrdInsUsuID = false;
            }
            if ( TB_PRODUTO2_n227PrdUpdData[0] )
            {
               A227PrdUpdData = DateTime.MinValue;
               n227PrdUpdData = false;
               n227PrdUpdData = true;
            }
            else
            {
               n227PrdUpdData = false;
            }
            if ( TB_PRODUTO2_n228PrdUpdHora[0] )
            {
               A228PrdUpdHora = (DateTime)(DateTime.MinValue);
               n228PrdUpdHora = false;
               n228PrdUpdHora = true;
            }
            else
            {
               n228PrdUpdHora = false;
            }
            if ( TB_PRODUTO2_n229PrdUpdDataHora[0] )
            {
               A229PrdUpdDataHora = (DateTime)(DateTime.MinValue);
               n229PrdUpdDataHora = false;
               n229PrdUpdDataHora = true;
            }
            else
            {
               n229PrdUpdDataHora = false;
            }
            if ( TB_PRODUTO2_n230PrdUpdUsuID[0] )
            {
               A230PrdUpdUsuID = "";
               n230PrdUpdUsuID = false;
               n230PrdUpdUsuID = true;
            }
            else
            {
               n230PrdUpdUsuID = false;
            }
            /* Using cursor TB_PRODUTO3 */
            pr_default.execute(1, new Object[] {A220PrdID});
            if ( (pr_default.getStatus(1) != 101) )
            {
               context.Gx_err = 1;
               Gx_emsg = (string)(GXResourceManager.GetMessage("GXM_noupdate"));
            }
            else
            {
               context.Gx_err = 0;
               Gx_emsg = "";
               /* Using cursor TB_PRODUTO4 */
               pr_default.execute(2, new Object[] {A220PrdID, A221PrdCodigo, A222PrdNome, A223PrdInsData, A224PrdInsHora, A225PrdInsDataHora, n226PrdInsUsuID, A226PrdInsUsuID, n227PrdUpdData, A227PrdUpdData, n228PrdUpdHora, A228PrdUpdHora, n229PrdUpdDataHora, A229PrdUpdDataHora, n230PrdUpdUsuID, A230PrdUpdUsuID, A231PrdAtivo, A232PrdTipoID});
               pr_default.close(2);
               pr_default.SmartCacheProvider.SetUpdated("tb_produto");
            }
            A220PrdID = W220PrdID;
            A221PrdCodigo = W221PrdCodigo;
            A222PrdNome = W222PrdNome;
            A223PrdInsData = W223PrdInsData;
            A224PrdInsHora = W224PrdInsHora;
            A225PrdInsDataHora = W225PrdInsDataHora;
            A226PrdInsUsuID = W226PrdInsUsuID;
            n226PrdInsUsuID = false;
            A226PrdInsUsuID = W226PrdInsUsuID;
            n226PrdInsUsuID = false;
            A227PrdUpdData = W227PrdUpdData;
            n227PrdUpdData = false;
            A227PrdUpdData = W227PrdUpdData;
            n227PrdUpdData = false;
            A228PrdUpdHora = W228PrdUpdHora;
            n228PrdUpdHora = false;
            A228PrdUpdHora = W228PrdUpdHora;
            n228PrdUpdHora = false;
            A229PrdUpdDataHora = W229PrdUpdDataHora;
            n229PrdUpdDataHora = false;
            A229PrdUpdDataHora = W229PrdUpdDataHora;
            n229PrdUpdDataHora = false;
            A230PrdUpdUsuID = W230PrdUpdUsuID;
            n230PrdUpdUsuID = false;
            A230PrdUpdUsuID = W230PrdUpdUsuID;
            n230PrdUpdUsuID = false;
            A231PrdAtivo = W231PrdAtivo;
            A232PrdTipoID = W232PrdTipoID;
            /* End Insert */
            pr_default.close(1);
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
         TB_PRODUTO2_A230PrdUpdUsuID = new string[] {""} ;
         TB_PRODUTO2_n230PrdUpdUsuID = new bool[] {false} ;
         TB_PRODUTO2_A229PrdUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         TB_PRODUTO2_n229PrdUpdDataHora = new bool[] {false} ;
         TB_PRODUTO2_A228PrdUpdHora = new DateTime[] {DateTime.MinValue} ;
         TB_PRODUTO2_n228PrdUpdHora = new bool[] {false} ;
         TB_PRODUTO2_A227PrdUpdData = new DateTime[] {DateTime.MinValue} ;
         TB_PRODUTO2_n227PrdUpdData = new bool[] {false} ;
         TB_PRODUTO2_A226PrdInsUsuID = new string[] {""} ;
         TB_PRODUTO2_n226PrdInsUsuID = new bool[] {false} ;
         TB_PRODUTO2_A232PrdTipoID = new int[1] ;
         TB_PRODUTO2_A231PrdAtivo = new bool[] {false} ;
         TB_PRODUTO2_A225PrdInsDataHora = new DateTime[] {DateTime.MinValue} ;
         TB_PRODUTO2_A224PrdInsHora = new DateTime[] {DateTime.MinValue} ;
         TB_PRODUTO2_A223PrdInsData = new DateTime[] {DateTime.MinValue} ;
         TB_PRODUTO2_A222PrdNome = new string[] {""} ;
         TB_PRODUTO2_A221PrdCodigo = new string[] {""} ;
         TB_PRODUTO2_A220PrdID = new Guid[] {Guid.Empty} ;
         A230PrdUpdUsuID = "";
         A229PrdUpdDataHora = (DateTime)(DateTime.MinValue);
         A228PrdUpdHora = (DateTime)(DateTime.MinValue);
         A227PrdUpdData = DateTime.MinValue;
         A226PrdInsUsuID = "";
         A225PrdInsDataHora = (DateTime)(DateTime.MinValue);
         A224PrdInsHora = (DateTime)(DateTime.MinValue);
         A223PrdInsData = DateTime.MinValue;
         A222PrdNome = "";
         A221PrdCodigo = "";
         A220PrdID = Guid.Empty;
         W220PrdID = Guid.Empty;
         W221PrdCodigo = "";
         W222PrdNome = "";
         W223PrdInsData = DateTime.MinValue;
         W224PrdInsHora = (DateTime)(DateTime.MinValue);
         W225PrdInsDataHora = (DateTime)(DateTime.MinValue);
         W226PrdInsUsuID = "";
         W227PrdUpdData = DateTime.MinValue;
         W228PrdUpdHora = (DateTime)(DateTime.MinValue);
         W229PrdUpdDataHora = (DateTime)(DateTime.MinValue);
         W230PrdUpdUsuID = "";
         TB_PRODUTO3_A220PrdID = new Guid[] {Guid.Empty} ;
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tb_produtoupdatereferentialintegrity__default(),
            new Object[][] {
                new Object[] {
               TB_PRODUTO2_A230PrdUpdUsuID, TB_PRODUTO2_n230PrdUpdUsuID, TB_PRODUTO2_A229PrdUpdDataHora, TB_PRODUTO2_n229PrdUpdDataHora, TB_PRODUTO2_A228PrdUpdHora, TB_PRODUTO2_n228PrdUpdHora, TB_PRODUTO2_A227PrdUpdData, TB_PRODUTO2_n227PrdUpdData, TB_PRODUTO2_A226PrdInsUsuID, TB_PRODUTO2_n226PrdInsUsuID,
               TB_PRODUTO2_A232PrdTipoID, TB_PRODUTO2_A231PrdAtivo, TB_PRODUTO2_A225PrdInsDataHora, TB_PRODUTO2_A224PrdInsHora, TB_PRODUTO2_A223PrdInsData, TB_PRODUTO2_A222PrdNome, TB_PRODUTO2_A221PrdCodigo, TB_PRODUTO2_A220PrdID
               }
               , new Object[] {
               TB_PRODUTO3_A220PrdID
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int A232PrdTipoID ;
      private int GX_INS28 ;
      private int W232PrdTipoID ;
      private string scmdbuf ;
      private string A230PrdUpdUsuID ;
      private string A226PrdInsUsuID ;
      private string W226PrdInsUsuID ;
      private string W230PrdUpdUsuID ;
      private string Gx_emsg ;
      private DateTime A229PrdUpdDataHora ;
      private DateTime A228PrdUpdHora ;
      private DateTime A225PrdInsDataHora ;
      private DateTime A224PrdInsHora ;
      private DateTime W224PrdInsHora ;
      private DateTime W225PrdInsDataHora ;
      private DateTime W228PrdUpdHora ;
      private DateTime W229PrdUpdDataHora ;
      private DateTime A227PrdUpdData ;
      private DateTime A223PrdInsData ;
      private DateTime W223PrdInsData ;
      private DateTime W227PrdUpdData ;
      private bool n230PrdUpdUsuID ;
      private bool n229PrdUpdDataHora ;
      private bool n228PrdUpdHora ;
      private bool n227PrdUpdData ;
      private bool n226PrdInsUsuID ;
      private bool A231PrdAtivo ;
      private bool W231PrdAtivo ;
      private string A222PrdNome ;
      private string A221PrdCodigo ;
      private string W221PrdCodigo ;
      private string W222PrdNome ;
      private Guid A220PrdID ;
      private Guid W220PrdID ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] TB_PRODUTO2_A230PrdUpdUsuID ;
      private bool[] TB_PRODUTO2_n230PrdUpdUsuID ;
      private DateTime[] TB_PRODUTO2_A229PrdUpdDataHora ;
      private bool[] TB_PRODUTO2_n229PrdUpdDataHora ;
      private DateTime[] TB_PRODUTO2_A228PrdUpdHora ;
      private bool[] TB_PRODUTO2_n228PrdUpdHora ;
      private DateTime[] TB_PRODUTO2_A227PrdUpdData ;
      private bool[] TB_PRODUTO2_n227PrdUpdData ;
      private string[] TB_PRODUTO2_A226PrdInsUsuID ;
      private bool[] TB_PRODUTO2_n226PrdInsUsuID ;
      private int[] TB_PRODUTO2_A232PrdTipoID ;
      private bool[] TB_PRODUTO2_A231PrdAtivo ;
      private DateTime[] TB_PRODUTO2_A225PrdInsDataHora ;
      private DateTime[] TB_PRODUTO2_A224PrdInsHora ;
      private DateTime[] TB_PRODUTO2_A223PrdInsData ;
      private string[] TB_PRODUTO2_A222PrdNome ;
      private string[] TB_PRODUTO2_A221PrdCodigo ;
      private Guid[] TB_PRODUTO2_A220PrdID ;
      private Guid[] TB_PRODUTO3_A220PrdID ;
   }

   public class tb_produtoupdatereferentialintegrity__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new UpdateCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmTB_PRODUTO2;
          prmTB_PRODUTO2 = new Object[] {
          };
          Object[] prmTB_PRODUTO3;
          prmTB_PRODUTO3 = new Object[] {
          new ParDef("PrdID",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmTB_PRODUTO4;
          prmTB_PRODUTO4 = new Object[] {
          new ParDef("PrdID",GXType.UniqueIdentifier,36,0) ,
          new ParDef("PrdCodigo",GXType.VarChar,30,0) ,
          new ParDef("PrdNome",GXType.VarChar,80,0) ,
          new ParDef("PrdInsData",GXType.Date,8,0) ,
          new ParDef("PrdInsHora",GXType.DateTime,0,5) ,
          new ParDef("PrdInsDataHora",GXType.DateTime2,10,12) ,
          new ParDef("PrdInsUsuID",GXType.Char,40,0){Nullable=true} ,
          new ParDef("PrdUpdData",GXType.Date,8,0){Nullable=true} ,
          new ParDef("PrdUpdHora",GXType.DateTime,0,5){Nullable=true} ,
          new ParDef("PrdUpdDataHora",GXType.DateTime2,10,12){Nullable=true} ,
          new ParDef("PrdUpdUsuID",GXType.Char,40,0){Nullable=true} ,
          new ParDef("PrdAtivo",GXType.Boolean,4,0) ,
          new ParDef("PrdTipoID",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("TB_PRODUTO2", "SELECT PrdUpdUsuID, PrdUpdDataHora, PrdUpdHora, PrdUpdData, PrdInsUsuID, PrdTipoID, PrdAtivo, PrdInsDataHora, PrdInsHora, PrdInsData, PrdNome, PrdCodigo, PrdID FROM tb_produto ORDER BY PrdID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmTB_PRODUTO2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("TB_PRODUTO3", "SELECT PrdID FROM tb_produto WHERE PrdID = :PrdID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmTB_PRODUTO3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("TB_PRODUTO4", "INSERT INTO tb_produto(PrdID, PrdCodigo, PrdNome, PrdInsData, PrdInsHora, PrdInsDataHora, PrdInsUsuID, PrdUpdData, PrdUpdHora, PrdUpdDataHora, PrdUpdUsuID, PrdAtivo, PrdTipoID) VALUES(:PrdID, :PrdCodigo, :PrdNome, :PrdInsData, :PrdInsHora, :PrdInsDataHora, :PrdInsUsuID, :PrdUpdData, :PrdUpdHora, :PrdUpdDataHora, :PrdUpdUsuID, :PrdAtivo, :PrdTipoID)", GxErrorMask.GX_NOMASK,prmTB_PRODUTO4)
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
                ((string[]) buf[0])[0] = rslt.getString(1, 40);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(2, true);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getString(5, 40);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((int[]) buf[10])[0] = rslt.getInt(6);
                ((bool[]) buf[11])[0] = rslt.getBool(7);
                ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(8, true);
                ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(9);
                ((DateTime[]) buf[14])[0] = rslt.getGXDate(10);
                ((string[]) buf[15])[0] = rslt.getVarchar(11);
                ((string[]) buf[16])[0] = rslt.getVarchar(12);
                ((Guid[]) buf[17])[0] = rslt.getGuid(13);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                return;
       }
    }

 }

}
