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
   public class tb_tabeladeprecoupdatereferentialintegrity : GXProcedure
   {
      public tb_tabeladeprecoupdatereferentialintegrity( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", false);
      }

      public tb_tabeladeprecoupdatereferentialintegrity( IGxContext context )
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
         tb_tabeladeprecoupdatereferentialintegrity objtb_tabeladeprecoupdatereferentialintegrity;
         objtb_tabeladeprecoupdatereferentialintegrity = new tb_tabeladeprecoupdatereferentialintegrity();
         objtb_tabeladeprecoupdatereferentialintegrity.context.SetSubmitInitialConfig(context);
         objtb_tabeladeprecoupdatereferentialintegrity.initialize();
         Submit( executePrivateCatch,objtb_tabeladeprecoupdatereferentialintegrity);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((tb_tabeladeprecoupdatereferentialintegrity)stateInfo).executePrivate();
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
            A450NegTppCodigo = TB_TABELAD2_A450NegTppCodigo[0];
            A452NegTppAtivo = TB_TABELAD2_A452NegTppAtivo[0];
            n452NegTppAtivo = TB_TABELAD2_n452NegTppAtivo[0];
            A221PrdCodigo = TB_TABELAD2_A221PrdCodigo[0];
            A436NgpTppID = TB_TABELAD2_A436NgpTppID[0];
            A437NgpTppCodigo = TB_TABELAD2_A437NgpTppCodigo[0];
            A451NegTppNome = TB_TABELAD2_A451NegTppNome[0];
            A440NgpTppPrdCodigo = TB_TABELAD2_A440NgpTppPrdCodigo[0];
            A439NgpTppPrdID = TB_TABELAD2_A439NgpTppPrdID[0];
            A435NgpItem = TB_TABELAD2_A435NgpItem[0];
            A449NegTppID = TB_TABELAD2_A449NegTppID[0];
            n449NegTppID = TB_TABELAD2_n449NegTppID[0];
            A450NegTppCodigo = TB_TABELAD2_A450NegTppCodigo[0];
            A452NegTppAtivo = TB_TABELAD2_A452NegTppAtivo[0];
            n452NegTppAtivo = TB_TABELAD2_n452NegTppAtivo[0];
            A451NegTppNome = TB_TABELAD2_A451NegTppNome[0];
            /*
               INSERT RECORD ON TABLE tb_tabeladepreco

            */
            W235TppID = A235TppID;
            W236TppCodigo = A236TppCodigo;
            W237TppNome = A237TppNome;
            W237TppNome = A237TppNome;
            W238TppInsData = A238TppInsData;
            W238TppInsData = A238TppInsData;
            W239TppInsHora = A239TppInsHora;
            W239TppInsHora = A239TppInsHora;
            W240TppInsDataHora = A240TppInsDataHora;
            W240TppInsDataHora = A240TppInsDataHora;
            W241TppInsUsuID = A241TppInsUsuID;
            n241TppInsUsuID = false;
            W241TppInsUsuID = A241TppInsUsuID;
            n241TppInsUsuID = false;
            W242TppUpdData = A242TppUpdData;
            n242TppUpdData = false;
            W242TppUpdData = A242TppUpdData;
            n242TppUpdData = false;
            W243TppUpdHora = A243TppUpdHora;
            n243TppUpdHora = false;
            W243TppUpdHora = A243TppUpdHora;
            n243TppUpdHora = false;
            W244TppUpdDataHora = A244TppUpdDataHora;
            n244TppUpdDataHora = false;
            W244TppUpdDataHora = A244TppUpdDataHora;
            n244TppUpdDataHora = false;
            W245TppUpdUsuID = A245TppUpdUsuID;
            n245TppUpdUsuID = false;
            W245TppUpdUsuID = A245TppUpdUsuID;
            n245TppUpdUsuID = false;
            W246TppAtivo = A246TppAtivo;
            n246TppAtivo = false;
            W246TppAtivo = A246TppAtivo;
            n246TppAtivo = false;
            W433TppInsUsuNome = A433TppInsUsuNome;
            n433TppInsUsuNome = false;
            W433TppInsUsuNome = A433TppInsUsuNome;
            n433TppInsUsuNome = false;
            W434TppUpdUsuNome = A434TppUpdUsuNome;
            n434TppUpdUsuNome = false;
            W434TppUpdUsuNome = A434TppUpdUsuNome;
            n434TppUpdUsuNome = false;
            A235TppID = A436NgpTppID;
            A236TppCodigo = A437NgpTppCodigo;
            if ( TB_TABELAD2_n451NegTppNome[0] )
            {
               A237TppNome = " ";
            }
            else
            {
               A237TppNome = A451NegTppNome;
            }
            if ( (DateTime.MinValue==A238TppInsData) )
            {
               A238TppInsData = context.localUtil.YMDToD( 1, 1, 1);
            }
            else
            {
            }
            if ( (DateTime.MinValue==A239TppInsHora) )
            {
               A239TppInsHora = DateTimeUtil.ResetDate(context.localUtil.YMDHMSToT( 1, 1, 1, 0, 0, 0));
            }
            else
            {
            }
            if ( (DateTime.MinValue==A240TppInsDataHora) )
            {
               A240TppInsDataHora = context.localUtil.YMDHMSToT( 1, 1, 1, 0, 0, 0);
            }
            else
            {
            }
            if ( String.IsNullOrEmpty(StringUtil.RTrim( A241TppInsUsuID)) )
            {
               A241TppInsUsuID = "";
               n241TppInsUsuID = false;
               n241TppInsUsuID = true;
            }
            else
            {
               n241TppInsUsuID = false;
            }
            if ( (DateTime.MinValue==A242TppUpdData) )
            {
               A242TppUpdData = DateTime.MinValue;
               n242TppUpdData = false;
               n242TppUpdData = true;
            }
            else
            {
               n242TppUpdData = false;
            }
            if ( (DateTime.MinValue==A243TppUpdHora) )
            {
               A243TppUpdHora = (DateTime)(DateTime.MinValue);
               n243TppUpdHora = false;
               n243TppUpdHora = true;
            }
            else
            {
               n243TppUpdHora = false;
            }
            if ( (DateTime.MinValue==A244TppUpdDataHora) )
            {
               A244TppUpdDataHora = (DateTime)(DateTime.MinValue);
               n244TppUpdDataHora = false;
               n244TppUpdDataHora = true;
            }
            else
            {
               n244TppUpdDataHora = false;
            }
            if ( String.IsNullOrEmpty(StringUtil.RTrim( A245TppUpdUsuID)) )
            {
               A245TppUpdUsuID = "";
               n245TppUpdUsuID = false;
               n245TppUpdUsuID = true;
            }
            else
            {
               n245TppUpdUsuID = false;
            }
            if ( (false==A438NgpTppAtivo) )
            {
               A246TppAtivo = false;
               n246TppAtivo = false;
               n246TppAtivo = true;
            }
            else
            {
               A246TppAtivo = A438NgpTppAtivo;
               n246TppAtivo = false;
            }
            if ( String.IsNullOrEmpty(StringUtil.RTrim( A433TppInsUsuNome)) )
            {
               A433TppInsUsuNome = "";
               n433TppInsUsuNome = false;
               n433TppInsUsuNome = true;
            }
            else
            {
               n433TppInsUsuNome = false;
            }
            if ( String.IsNullOrEmpty(StringUtil.RTrim( A434TppUpdUsuNome)) )
            {
               A434TppUpdUsuNome = "";
               n434TppUpdUsuNome = false;
               n434TppUpdUsuNome = true;
            }
            else
            {
               n434TppUpdUsuNome = false;
            }
            /* Using cursor TB_TABELAD3 */
            pr_default.execute(1, new Object[] {A235TppID});
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
               pr_default.execute(2, new Object[] {A235TppID, A236TppCodigo, A237TppNome, A238TppInsData, A239TppInsHora, A240TppInsDataHora, n241TppInsUsuID, A241TppInsUsuID, n242TppUpdData, A242TppUpdData, n243TppUpdHora, A243TppUpdHora, n244TppUpdDataHora, A244TppUpdDataHora, n245TppUpdUsuID, A245TppUpdUsuID, n246TppAtivo, A246TppAtivo, n433TppInsUsuNome, A433TppInsUsuNome, n434TppUpdUsuNome, A434TppUpdUsuNome});
               pr_default.close(2);
               pr_default.SmartCacheProvider.SetUpdated("tb_tabeladepreco");
            }
            A235TppID = W235TppID;
            A236TppCodigo = W236TppCodigo;
            A237TppNome = W237TppNome;
            A237TppNome = W237TppNome;
            A238TppInsData = W238TppInsData;
            A238TppInsData = W238TppInsData;
            A239TppInsHora = W239TppInsHora;
            A239TppInsHora = W239TppInsHora;
            A240TppInsDataHora = W240TppInsDataHora;
            A240TppInsDataHora = W240TppInsDataHora;
            A241TppInsUsuID = W241TppInsUsuID;
            n241TppInsUsuID = false;
            A241TppInsUsuID = W241TppInsUsuID;
            n241TppInsUsuID = false;
            A242TppUpdData = W242TppUpdData;
            n242TppUpdData = false;
            A242TppUpdData = W242TppUpdData;
            n242TppUpdData = false;
            A243TppUpdHora = W243TppUpdHora;
            n243TppUpdHora = false;
            A243TppUpdHora = W243TppUpdHora;
            n243TppUpdHora = false;
            A244TppUpdDataHora = W244TppUpdDataHora;
            n244TppUpdDataHora = false;
            A244TppUpdDataHora = W244TppUpdDataHora;
            n244TppUpdDataHora = false;
            A245TppUpdUsuID = W245TppUpdUsuID;
            n245TppUpdUsuID = false;
            A245TppUpdUsuID = W245TppUpdUsuID;
            n245TppUpdUsuID = false;
            A246TppAtivo = W246TppAtivo;
            n246TppAtivo = false;
            A246TppAtivo = W246TppAtivo;
            n246TppAtivo = false;
            A433TppInsUsuNome = W433TppInsUsuNome;
            n433TppInsUsuNome = false;
            A433TppInsUsuNome = W433TppInsUsuNome;
            n433TppInsUsuNome = false;
            A434TppUpdUsuNome = W434TppUpdUsuNome;
            n434TppUpdUsuNome = false;
            A434TppUpdUsuNome = W434TppUpdUsuNome;
            n434TppUpdUsuNome = false;
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
         TB_TABELAD2_A450NegTppCodigo = new string[] {""} ;
         TB_TABELAD2_A452NegTppAtivo = new bool[] {false} ;
         TB_TABELAD2_n452NegTppAtivo = new bool[] {false} ;
         TB_TABELAD2_A221PrdCodigo = new string[] {""} ;
         TB_TABELAD2_A436NgpTppID = new Guid[] {Guid.Empty} ;
         TB_TABELAD2_A437NgpTppCodigo = new string[] {""} ;
         TB_TABELAD2_A451NegTppNome = new string[] {""} ;
         TB_TABELAD2_A440NgpTppPrdCodigo = new string[] {""} ;
         TB_TABELAD2_A439NgpTppPrdID = new Guid[] {Guid.Empty} ;
         TB_TABELAD2_A435NgpItem = new int[1] ;
         A345NegID = Guid.Empty;
         A220PrdID = Guid.Empty;
         A449NegTppID = Guid.Empty;
         A450NegTppCodigo = "";
         A221PrdCodigo = "";
         A436NgpTppID = Guid.Empty;
         A437NgpTppCodigo = "";
         A451NegTppNome = "";
         A440NgpTppPrdCodigo = "";
         A439NgpTppPrdID = Guid.Empty;
         W235TppID = Guid.Empty;
         A235TppID = Guid.Empty;
         W236TppCodigo = "";
         A236TppCodigo = "";
         W237TppNome = "";
         A237TppNome = "";
         W238TppInsData = DateTime.MinValue;
         A238TppInsData = DateTime.MinValue;
         W239TppInsHora = (DateTime)(DateTime.MinValue);
         A239TppInsHora = (DateTime)(DateTime.MinValue);
         W240TppInsDataHora = (DateTime)(DateTime.MinValue);
         A240TppInsDataHora = (DateTime)(DateTime.MinValue);
         W241TppInsUsuID = "";
         A241TppInsUsuID = "";
         W242TppUpdData = DateTime.MinValue;
         A242TppUpdData = DateTime.MinValue;
         W243TppUpdHora = (DateTime)(DateTime.MinValue);
         A243TppUpdHora = (DateTime)(DateTime.MinValue);
         W244TppUpdDataHora = (DateTime)(DateTime.MinValue);
         A244TppUpdDataHora = (DateTime)(DateTime.MinValue);
         W245TppUpdUsuID = "";
         A245TppUpdUsuID = "";
         W433TppInsUsuNome = "";
         A433TppInsUsuNome = "";
         W434TppUpdUsuNome = "";
         A434TppUpdUsuNome = "";
         TB_TABELAD2_n451NegTppNome = new bool[] {false} ;
         TB_TABELAD3_A235TppID = new Guid[] {Guid.Empty} ;
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tb_tabeladeprecoupdatereferentialintegrity__default(),
            new Object[][] {
                new Object[] {
               TB_TABELAD2_A345NegID, TB_TABELAD2_A220PrdID, TB_TABELAD2_A449NegTppID, TB_TABELAD2_n449NegTppID, TB_TABELAD2_A450NegTppCodigo, TB_TABELAD2_A452NegTppAtivo, TB_TABELAD2_n452NegTppAtivo, TB_TABELAD2_A221PrdCodigo, TB_TABELAD2_A436NgpTppID, TB_TABELAD2_A437NgpTppCodigo,
               TB_TABELAD2_A451NegTppNome, TB_TABELAD2_A440NgpTppPrdCodigo, TB_TABELAD2_A439NgpTppPrdID, TB_TABELAD2_A435NgpItem
               }
               , new Object[] {
               TB_TABELAD3_A235TppID
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int A435NgpItem ;
      private int GX_INS29 ;
      private string scmdbuf ;
      private string W241TppInsUsuID ;
      private string A241TppInsUsuID ;
      private string W245TppUpdUsuID ;
      private string A245TppUpdUsuID ;
      private string Gx_emsg ;
      private DateTime W239TppInsHora ;
      private DateTime A239TppInsHora ;
      private DateTime W240TppInsDataHora ;
      private DateTime A240TppInsDataHora ;
      private DateTime W243TppUpdHora ;
      private DateTime A243TppUpdHora ;
      private DateTime W244TppUpdDataHora ;
      private DateTime A244TppUpdDataHora ;
      private DateTime W238TppInsData ;
      private DateTime A238TppInsData ;
      private DateTime W242TppUpdData ;
      private DateTime A242TppUpdData ;
      private bool n449NegTppID ;
      private bool A452NegTppAtivo ;
      private bool n452NegTppAtivo ;
      private bool n241TppInsUsuID ;
      private bool n242TppUpdData ;
      private bool n243TppUpdHora ;
      private bool n244TppUpdDataHora ;
      private bool n245TppUpdUsuID ;
      private bool W246TppAtivo ;
      private bool A246TppAtivo ;
      private bool n246TppAtivo ;
      private bool n433TppInsUsuNome ;
      private bool n434TppUpdUsuNome ;
      private bool A438NgpTppAtivo ;
      private string A450NegTppCodigo ;
      private string A221PrdCodigo ;
      private string A437NgpTppCodigo ;
      private string A451NegTppNome ;
      private string A440NgpTppPrdCodigo ;
      private string W236TppCodigo ;
      private string A236TppCodigo ;
      private string W237TppNome ;
      private string A237TppNome ;
      private string W433TppInsUsuNome ;
      private string A433TppInsUsuNome ;
      private string W434TppUpdUsuNome ;
      private string A434TppUpdUsuNome ;
      private Guid A345NegID ;
      private Guid A220PrdID ;
      private Guid A449NegTppID ;
      private Guid A436NgpTppID ;
      private Guid A439NgpTppPrdID ;
      private Guid W235TppID ;
      private Guid A235TppID ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] TB_TABELAD2_A345NegID ;
      private Guid[] TB_TABELAD2_A220PrdID ;
      private Guid[] TB_TABELAD2_A449NegTppID ;
      private bool[] TB_TABELAD2_n449NegTppID ;
      private string[] TB_TABELAD2_A450NegTppCodigo ;
      private bool[] TB_TABELAD2_A452NegTppAtivo ;
      private bool[] TB_TABELAD2_n452NegTppAtivo ;
      private string[] TB_TABELAD2_A221PrdCodigo ;
      private Guid[] TB_TABELAD2_A436NgpTppID ;
      private string[] TB_TABELAD2_A437NgpTppCodigo ;
      private string[] TB_TABELAD2_A451NegTppNome ;
      private string[] TB_TABELAD2_A440NgpTppPrdCodigo ;
      private Guid[] TB_TABELAD2_A439NgpTppPrdID ;
      private int[] TB_TABELAD2_A435NgpItem ;
      private bool[] TB_TABELAD2_n451NegTppNome ;
      private Guid[] TB_TABELAD3_A235TppID ;
   }

   public class tb_tabeladeprecoupdatereferentialintegrity__default : DataStoreHelperBase, IDataStoreHelper
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
          new ParDef("TppID",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmTB_TABELAD4;
          prmTB_TABELAD4 = new Object[] {
          new ParDef("TppID",GXType.UniqueIdentifier,36,0) ,
          new ParDef("TppCodigo",GXType.VarChar,20,0) ,
          new ParDef("TppNome",GXType.VarChar,80,0) ,
          new ParDef("TppInsData",GXType.Date,8,0) ,
          new ParDef("TppInsHora",GXType.DateTime,0,5) ,
          new ParDef("TppInsDataHora",GXType.DateTime,10,8) ,
          new ParDef("TppInsUsuID",GXType.Char,40,0){Nullable=true} ,
          new ParDef("TppUpdData",GXType.Date,8,0){Nullable=true} ,
          new ParDef("TppUpdHora",GXType.DateTime,10,5){Nullable=true} ,
          new ParDef("TppUpdDataHora",GXType.DateTime2,10,12){Nullable=true} ,
          new ParDef("TppUpdUsuID",GXType.Char,40,0){Nullable=true} ,
          new ParDef("TppAtivo",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("TppInsUsuNome",GXType.VarChar,80,0){Nullable=true} ,
          new ParDef("TppUpdUsuNome",GXType.VarChar,80,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("TB_TABELAD2", "SELECT T1.NegID, T3.PrdID, T2.NegTppID, T2.NegTppCodigo, T2.NegTppAtivo, T3.PrdCodigo, T1.NgpTppID, T1.NgpTppCodigo, T2.NegTppNome, T1.NgpTppPrdCodigo, T1.NgpTppPrdID, T1.NgpItem FROM ((tb_negociopj_item T1 INNER JOIN tb_negociopj T2 ON T2.NegID = T1.NegID) INNER JOIN tb_produto T3 ON T3.PrdID = T1.NgpTppPrdID) ORDER BY T1.NegID, T1.NgpItem ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmTB_TABELAD2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("TB_TABELAD3", "SELECT TppID FROM tb_tabeladepreco WHERE TppID = :TppID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmTB_TABELAD3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("TB_TABELAD4", "INSERT INTO tb_tabeladepreco(TppID, TppCodigo, TppNome, TppInsData, TppInsHora, TppInsDataHora, TppInsUsuID, TppUpdData, TppUpdHora, TppUpdDataHora, TppUpdUsuID, TppAtivo, TppInsUsuNome, TppUpdUsuNome) VALUES(:TppID, :TppCodigo, :TppNome, :TppInsData, :TppInsHora, :TppInsDataHora, :TppInsUsuID, :TppUpdData, :TppUpdHora, :TppUpdDataHora, :TppUpdUsuID, :TppAtivo, :TppInsUsuNome, :TppUpdUsuNome)", GxErrorMask.GX_NOMASK,prmTB_TABELAD4)
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
                ((bool[]) buf[5])[0] = rslt.getBool(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((string[]) buf[7])[0] = rslt.getVarchar(6);
                ((Guid[]) buf[8])[0] = rslt.getGuid(7);
                ((string[]) buf[9])[0] = rslt.getVarchar(8);
                ((string[]) buf[10])[0] = rslt.getVarchar(9);
                ((string[]) buf[11])[0] = rslt.getVarchar(10);
                ((Guid[]) buf[12])[0] = rslt.getGuid(11);
                ((int[]) buf[13])[0] = rslt.getInt(12);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                return;
       }
    }

 }

}
