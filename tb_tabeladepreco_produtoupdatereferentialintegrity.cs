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
   public class tb_tabeladepreco_produtoupdatereferentialintegrity : GXProcedure
   {
      public tb_tabeladepreco_produtoupdatereferentialintegrity( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", false);
      }

      public tb_tabeladepreco_produtoupdatereferentialintegrity( IGxContext context )
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
         tb_tabeladepreco_produtoupdatereferentialintegrity objtb_tabeladepreco_produtoupdatereferentialintegrity;
         objtb_tabeladepreco_produtoupdatereferentialintegrity = new tb_tabeladepreco_produtoupdatereferentialintegrity();
         objtb_tabeladepreco_produtoupdatereferentialintegrity.context.SetSubmitInitialConfig(context);
         objtb_tabeladepreco_produtoupdatereferentialintegrity.initialize();
         Submit( executePrivateCatch,objtb_tabeladepreco_produtoupdatereferentialintegrity);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((tb_tabeladepreco_produtoupdatereferentialintegrity)stateInfo).executePrivate();
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
            A345NegID = TB_TABELAD2_A345NegID[0];
            A220PrdID = TB_TABELAD2_A220PrdID[0];
            A449NegTppID = TB_TABELAD2_A449NegTppID[0];
            n449NegTppID = TB_TABELAD2_n449NegTppID[0];
            A221PrdCodigo = TB_TABELAD2_A221PrdCodigo[0];
            A222PrdNome = TB_TABELAD2_A222PrdNome[0];
            A232PrdTipoID = TB_TABELAD2_A232PrdTipoID[0];
            A452NegTppAtivo = TB_TABELAD2_A452NegTppAtivo[0];
            n452NegTppAtivo = TB_TABELAD2_n452NegTppAtivo[0];
            A450NegTppCodigo = TB_TABELAD2_A450NegTppCodigo[0];
            A436NgpTppID = TB_TABELAD2_A436NgpTppID[0];
            A439NgpTppPrdID = TB_TABELAD2_A439NgpTppPrdID[0];
            A440NgpTppPrdCodigo = TB_TABELAD2_A440NgpTppPrdCodigo[0];
            A441NgpTppPrdNome = TB_TABELAD2_A441NgpTppPrdNome[0];
            A437NgpTppCodigo = TB_TABELAD2_A437NgpTppCodigo[0];
            A435NgpItem = TB_TABELAD2_A435NgpItem[0];
            A449NegTppID = TB_TABELAD2_A449NegTppID[0];
            n449NegTppID = TB_TABELAD2_n449NegTppID[0];
            A452NegTppAtivo = TB_TABELAD2_A452NegTppAtivo[0];
            n452NegTppAtivo = TB_TABELAD2_n452NegTppAtivo[0];
            A450NegTppCodigo = TB_TABELAD2_A450NegTppCodigo[0];
            /*
               INSERT RECORD ON TABLE tb_tabeladepreco_produto

            */
            W235TppID = A235TppID;
            W220PrdID = A220PrdID;
            W247Tpp1Preco = A247Tpp1Preco;
            W247Tpp1Preco = A247Tpp1Preco;
            W221PrdCodigo = A221PrdCodigo;
            W222PrdNome = A222PrdNome;
            W232PrdTipoID = A232PrdTipoID;
            W232PrdTipoID = A232PrdTipoID;
            A235TppID = A436NgpTppID;
            A220PrdID = A439NgpTppPrdID;
            if ( (Convert.ToDecimal(0)==A444NgpTpp1Preco) )
            {
               A247Tpp1Preco = 0;
            }
            else
            {
               A247Tpp1Preco = A444NgpTpp1Preco;
            }
            A221PrdCodigo = A440NgpTppPrdCodigo;
            A222PrdNome = A441NgpTppPrdNome;
            if ( (0==A442NgpTppPrdTipoID) )
            {
               A232PrdTipoID = 0;
            }
            else
            {
               A232PrdTipoID = A442NgpTppPrdTipoID;
            }
            /* Using cursor TB_TABELAD3 */
            pr_default.execute(1, new Object[] {A235TppID, A220PrdID});
            if ( (pr_default.getStatus(1) != 101) )
            {
               context.Gx_err = 1;
               Gx_emsg = (string)(GXResourceManager.GetMessage("GXM_noupdate"));
            }
            else
            {
               context.Gx_err = 0;
               Gx_emsg = "";
               /* Using cursor TB_TABELAD4 */
               pr_default.execute(2, new Object[] {A235TppID, A220PrdID, A247Tpp1Preco, A221PrdCodigo, A222PrdNome, A232PrdTipoID});
               pr_default.close(2);
               pr_default.SmartCacheProvider.SetUpdated("tb_tabeladepreco_produto");
            }
            A235TppID = W235TppID;
            A220PrdID = W220PrdID;
            A247Tpp1Preco = W247Tpp1Preco;
            A247Tpp1Preco = W247Tpp1Preco;
            A221PrdCodigo = W221PrdCodigo;
            A222PrdNome = W222PrdNome;
            A232PrdTipoID = W232PrdTipoID;
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
         TB_TABELAD2_A345NegID = new Guid[] {Guid.Empty} ;
         TB_TABELAD2_A220PrdID = new Guid[] {Guid.Empty} ;
         TB_TABELAD2_A449NegTppID = new Guid[] {Guid.Empty} ;
         TB_TABELAD2_n449NegTppID = new bool[] {false} ;
         TB_TABELAD2_A221PrdCodigo = new string[] {""} ;
         TB_TABELAD2_A222PrdNome = new string[] {""} ;
         TB_TABELAD2_A232PrdTipoID = new int[1] ;
         TB_TABELAD2_A452NegTppAtivo = new bool[] {false} ;
         TB_TABELAD2_n452NegTppAtivo = new bool[] {false} ;
         TB_TABELAD2_A450NegTppCodigo = new string[] {""} ;
         TB_TABELAD2_A436NgpTppID = new Guid[] {Guid.Empty} ;
         TB_TABELAD2_A439NgpTppPrdID = new Guid[] {Guid.Empty} ;
         TB_TABELAD2_A440NgpTppPrdCodigo = new string[] {""} ;
         TB_TABELAD2_A441NgpTppPrdNome = new string[] {""} ;
         TB_TABELAD2_A437NgpTppCodigo = new string[] {""} ;
         TB_TABELAD2_A435NgpItem = new int[1] ;
         A345NegID = Guid.Empty;
         A220PrdID = Guid.Empty;
         A449NegTppID = Guid.Empty;
         A221PrdCodigo = "";
         A222PrdNome = "";
         A450NegTppCodigo = "";
         A436NgpTppID = Guid.Empty;
         A439NgpTppPrdID = Guid.Empty;
         A440NgpTppPrdCodigo = "";
         A441NgpTppPrdNome = "";
         A437NgpTppCodigo = "";
         W235TppID = Guid.Empty;
         A235TppID = Guid.Empty;
         W220PrdID = Guid.Empty;
         W221PrdCodigo = "";
         W222PrdNome = "";
         TB_TABELAD3_A235TppID = new Guid[] {Guid.Empty} ;
         TB_TABELAD3_A220PrdID = new Guid[] {Guid.Empty} ;
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tb_tabeladepreco_produtoupdatereferentialintegrity__default(),
            new Object[][] {
                new Object[] {
               TB_TABELAD2_A345NegID, TB_TABELAD2_A220PrdID, TB_TABELAD2_A449NegTppID, TB_TABELAD2_n449NegTppID, TB_TABELAD2_A221PrdCodigo, TB_TABELAD2_A222PrdNome, TB_TABELAD2_A232PrdTipoID, TB_TABELAD2_A452NegTppAtivo, TB_TABELAD2_n452NegTppAtivo, TB_TABELAD2_A450NegTppCodigo,
               TB_TABELAD2_A436NgpTppID, TB_TABELAD2_A439NgpTppPrdID, TB_TABELAD2_A440NgpTppPrdCodigo, TB_TABELAD2_A441NgpTppPrdNome, TB_TABELAD2_A437NgpTppCodigo, TB_TABELAD2_A435NgpItem
               }
               , new Object[] {
               TB_TABELAD3_A235TppID, TB_TABELAD3_A220PrdID
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int A232PrdTipoID ;
      private int A435NgpItem ;
      private int GX_INS30 ;
      private int W232PrdTipoID ;
      private int A442NgpTppPrdTipoID ;
      private decimal W247Tpp1Preco ;
      private decimal A247Tpp1Preco ;
      private decimal A444NgpTpp1Preco ;
      private string scmdbuf ;
      private string Gx_emsg ;
      private bool n449NegTppID ;
      private bool A452NegTppAtivo ;
      private bool n452NegTppAtivo ;
      private string A221PrdCodigo ;
      private string A222PrdNome ;
      private string A450NegTppCodigo ;
      private string A440NgpTppPrdCodigo ;
      private string A441NgpTppPrdNome ;
      private string A437NgpTppCodigo ;
      private string W221PrdCodigo ;
      private string W222PrdNome ;
      private Guid A345NegID ;
      private Guid A220PrdID ;
      private Guid A449NegTppID ;
      private Guid A436NgpTppID ;
      private Guid A439NgpTppPrdID ;
      private Guid W235TppID ;
      private Guid A235TppID ;
      private Guid W220PrdID ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] TB_TABELAD2_A345NegID ;
      private Guid[] TB_TABELAD2_A220PrdID ;
      private Guid[] TB_TABELAD2_A449NegTppID ;
      private bool[] TB_TABELAD2_n449NegTppID ;
      private string[] TB_TABELAD2_A221PrdCodigo ;
      private string[] TB_TABELAD2_A222PrdNome ;
      private int[] TB_TABELAD2_A232PrdTipoID ;
      private bool[] TB_TABELAD2_A452NegTppAtivo ;
      private bool[] TB_TABELAD2_n452NegTppAtivo ;
      private string[] TB_TABELAD2_A450NegTppCodigo ;
      private Guid[] TB_TABELAD2_A436NgpTppID ;
      private Guid[] TB_TABELAD2_A439NgpTppPrdID ;
      private string[] TB_TABELAD2_A440NgpTppPrdCodigo ;
      private string[] TB_TABELAD2_A441NgpTppPrdNome ;
      private string[] TB_TABELAD2_A437NgpTppCodigo ;
      private int[] TB_TABELAD2_A435NgpItem ;
      private Guid[] TB_TABELAD3_A235TppID ;
      private Guid[] TB_TABELAD3_A220PrdID ;
   }

   public class tb_tabeladepreco_produtoupdatereferentialintegrity__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmTB_TABELAD2;
          prmTB_TABELAD2 = new Object[] {
          };
          Object[] prmTB_TABELAD3;
          prmTB_TABELAD3 = new Object[] {
          new ParDef("TppID",GXType.UniqueIdentifier,36,0) ,
          new ParDef("PrdID",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmTB_TABELAD4;
          prmTB_TABELAD4 = new Object[] {
          new ParDef("TppID",GXType.UniqueIdentifier,36,0) ,
          new ParDef("PrdID",GXType.UniqueIdentifier,36,0) ,
          new ParDef("Tpp1Preco",GXType.Number,16,2) ,
          new ParDef("PrdCodigo",GXType.VarChar,30,0) ,
          new ParDef("PrdNome",GXType.VarChar,80,0) ,
          new ParDef("PrdTipoID",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("TB_TABELAD2", "SELECT T1.NegID, T3.PrdID, T2.NegTppID, T3.PrdCodigo, T3.PrdNome, T3.PrdTipoID, T2.NegTppAtivo, T2.NegTppCodigo, T1.NgpTppID, T1.NgpTppPrdID, T1.NgpTppPrdCodigo, T1.NgpTppPrdNome, T1.NgpTppCodigo, T1.NgpItem FROM ((tb_negociopj_item T1 INNER JOIN tb_negociopj T2 ON T2.NegID = T1.NegID) INNER JOIN tb_produto T3 ON T3.PrdID = T1.NgpTppPrdID) ORDER BY T1.NegID, T1.NgpItem ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmTB_TABELAD2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("TB_TABELAD3", "SELECT TppID, PrdID FROM tb_tabeladepreco_produto WHERE TppID = :TppID AND PrdID = :PrdID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmTB_TABELAD3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("TB_TABELAD4", "INSERT INTO tb_tabeladepreco_produto(TppID, PrdID, Tpp1Preco, PrdCodigo, PrdNome, PrdTipoID) VALUES(:TppID, :PrdID, :Tpp1Preco, :PrdCodigo, :PrdNome, :PrdTipoID)", GxErrorMask.GX_NOMASK,prmTB_TABELAD4)
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
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((bool[]) buf[7])[0] = rslt.getBool(7);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((string[]) buf[9])[0] = rslt.getVarchar(8);
                ((Guid[]) buf[10])[0] = rslt.getGuid(9);
                ((Guid[]) buf[11])[0] = rslt.getGuid(10);
                ((string[]) buf[12])[0] = rslt.getVarchar(11);
                ((string[]) buf[13])[0] = rslt.getVarchar(12);
                ((string[]) buf[14])[0] = rslt.getVarchar(13);
                ((int[]) buf[15])[0] = rslt.getInt(14);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                return;
       }
    }

 }

}
