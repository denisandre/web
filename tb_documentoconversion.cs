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
   public class tb_documentoconversion : GXProcedure
   {
      public tb_documentoconversion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", false);
      }

      public tb_documentoconversion( IGxContext context )
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
         tb_documentoconversion objtb_documentoconversion;
         objtb_documentoconversion = new tb_documentoconversion();
         objtb_documentoconversion.context.SetSubmitInitialConfig(context);
         objtb_documentoconversion.initialize();
         Submit( executePrivateCatch,objtb_documentoconversion);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((tb_documentoconversion)stateInfo).executePrivate();
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
         /* Using cursor TB_DOCUMEN2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A481DocAssinado = TB_DOCUMEN2_A481DocAssinado[0];
            A480DocContrato = TB_DOCUMEN2_A480DocContrato[0];
            A326DocVersaoIDPai = TB_DOCUMEN2_A326DocVersaoIDPai[0];
            n326DocVersaoIDPai = TB_DOCUMEN2_n326DocVersaoIDPai[0];
            A325DocVersao = TB_DOCUMEN2_A325DocVersao[0];
            A306DocUltArqSeq = TB_DOCUMEN2_A306DocUltArqSeq[0];
            n306DocUltArqSeq = TB_DOCUMEN2_n306DocUltArqSeq[0];
            A146DocTipoID = TB_DOCUMEN2_A146DocTipoID[0];
            A305DocNome = TB_DOCUMEN2_A305DocNome[0];
            A304DocDelUsuID = TB_DOCUMEN2_A304DocDelUsuID[0];
            n304DocDelUsuID = TB_DOCUMEN2_n304DocDelUsuID[0];
            A303DocDelDataHora = TB_DOCUMEN2_A303DocDelDataHora[0];
            n303DocDelDataHora = TB_DOCUMEN2_n303DocDelDataHora[0];
            A302DocDelHora = TB_DOCUMEN2_A302DocDelHora[0];
            n302DocDelHora = TB_DOCUMEN2_n302DocDelHora[0];
            A300DocDel = TB_DOCUMEN2_A300DocDel[0];
            A299DocUpdUsuID = TB_DOCUMEN2_A299DocUpdUsuID[0];
            n299DocUpdUsuID = TB_DOCUMEN2_n299DocUpdUsuID[0];
            A298DocUpdDataHora = TB_DOCUMEN2_A298DocUpdDataHora[0];
            n298DocUpdDataHora = TB_DOCUMEN2_n298DocUpdDataHora[0];
            A297DocUpdHora = TB_DOCUMEN2_A297DocUpdHora[0];
            n297DocUpdHora = TB_DOCUMEN2_n297DocUpdHora[0];
            A296DocUpdData = TB_DOCUMEN2_A296DocUpdData[0];
            n296DocUpdData = TB_DOCUMEN2_n296DocUpdData[0];
            A295DocInsUsuID = TB_DOCUMEN2_A295DocInsUsuID[0];
            n295DocInsUsuID = TB_DOCUMEN2_n295DocInsUsuID[0];
            A294DocInsDataHora = TB_DOCUMEN2_A294DocInsDataHora[0];
            A293DocInsHora = TB_DOCUMEN2_A293DocInsHora[0];
            A292DocInsData = TB_DOCUMEN2_A292DocInsData[0];
            A291DocOrigemID = TB_DOCUMEN2_A291DocOrigemID[0];
            A290DocOrigem = TB_DOCUMEN2_A290DocOrigem[0];
            A289DocID = TB_DOCUMEN2_A289DocID[0];
            A301DocDelData = TB_DOCUMEN2_A301DocDelData[0];
            n301DocDelData = TB_DOCUMEN2_n301DocDelData[0];
            A40000GXC1 = ( A301DocDelData);
            /*
               INSERT RECORD ON TABLE GXA0033

            */
            AV2DocID = A289DocID;
            AV3DocOrigem = A290DocOrigem;
            AV4DocOrigemID = A291DocOrigemID;
            AV5DocInsData = A292DocInsData;
            AV6DocInsHora = A293DocInsHora;
            AV7DocInsDataHora = A294DocInsDataHora;
            if ( TB_DOCUMEN2_n295DocInsUsuID[0] )
            {
               AV8DocInsUsuID = "";
               nV8DocInsUsuID = false;
               nV8DocInsUsuID = true;
            }
            else
            {
               AV8DocInsUsuID = A295DocInsUsuID;
               nV8DocInsUsuID = false;
            }
            if ( TB_DOCUMEN2_n296DocUpdData[0] )
            {
               AV9DocUpdData = DateTime.MinValue;
               nV9DocUpdData = false;
               nV9DocUpdData = true;
            }
            else
            {
               AV9DocUpdData = A296DocUpdData;
               nV9DocUpdData = false;
            }
            if ( TB_DOCUMEN2_n297DocUpdHora[0] )
            {
               AV10DocUpdHora = (DateTime)(DateTime.MinValue);
               nV10DocUpdHora = false;
               nV10DocUpdHora = true;
            }
            else
            {
               AV10DocUpdHora = A297DocUpdHora;
               nV10DocUpdHora = false;
            }
            if ( TB_DOCUMEN2_n298DocUpdDataHora[0] )
            {
               AV11DocUpdDataHora = (DateTime)(DateTime.MinValue);
               nV11DocUpdDataHora = false;
               nV11DocUpdDataHora = true;
            }
            else
            {
               AV11DocUpdDataHora = A298DocUpdDataHora;
               nV11DocUpdDataHora = false;
            }
            if ( TB_DOCUMEN2_n299DocUpdUsuID[0] )
            {
               AV12DocUpdUsuID = "";
               nV12DocUpdUsuID = false;
               nV12DocUpdUsuID = true;
            }
            else
            {
               AV12DocUpdUsuID = A299DocUpdUsuID;
               nV12DocUpdUsuID = false;
            }
            AV13DocDel = A300DocDel;
            if ( TB_DOCUMEN2_n301DocDelData[0] )
            {
               AV14DocDelData = (DateTime)(DateTime.MinValue);
               nV14DocDelData = false;
               nV14DocDelData = true;
            }
            else
            {
               AV14DocDelData = A40000GXC1;
               nV14DocDelData = false;
            }
            if ( TB_DOCUMEN2_n302DocDelHora[0] )
            {
               AV15DocDelHora = (DateTime)(DateTime.MinValue);
               nV15DocDelHora = false;
               nV15DocDelHora = true;
            }
            else
            {
               AV15DocDelHora = DateTimeUtil.ResetDate(A302DocDelHora);
               nV15DocDelHora = false;
            }
            if ( TB_DOCUMEN2_n303DocDelDataHora[0] )
            {
               AV16DocDelDataHora = (DateTime)(DateTime.MinValue);
               nV16DocDelDataHora = false;
               nV16DocDelDataHora = true;
            }
            else
            {
               AV16DocDelDataHora = A303DocDelDataHora;
               nV16DocDelDataHora = false;
            }
            if ( TB_DOCUMEN2_n304DocDelUsuID[0] )
            {
               AV17DocDelUsuID = "";
               nV17DocDelUsuID = false;
               nV17DocDelUsuID = true;
            }
            else
            {
               AV17DocDelUsuID = A304DocDelUsuID;
               nV17DocDelUsuID = false;
            }
            AV18DocNome = A305DocNome;
            AV19DocTipoID = A146DocTipoID;
            if ( TB_DOCUMEN2_n306DocUltArqSeq[0] )
            {
               AV20DocUltArqSeq = 0;
               nV20DocUltArqSeq = false;
               nV20DocUltArqSeq = true;
            }
            else
            {
               AV20DocUltArqSeq = A306DocUltArqSeq;
               nV20DocUltArqSeq = false;
            }
            AV21DocVersao = A325DocVersao;
            if ( TB_DOCUMEN2_n326DocVersaoIDPai[0] )
            {
               AV22DocVersaoIDPai = Guid.Empty;
               nV22DocVersaoIDPai = false;
               nV22DocVersaoIDPai = true;
            }
            else
            {
               AV22DocVersaoIDPai = A326DocVersaoIDPai;
               nV22DocVersaoIDPai = false;
            }
            AV23DocContrato = A480DocContrato;
            AV24DocAssinado = A481DocAssinado;
            AV25DocDelUsuNome = "";
            nV25DocDelUsuNome = false;
            nV25DocDelUsuNome = true;
            /* Using cursor TB_DOCUMEN3 */
            pr_default.execute(1, new Object[] {AV2DocID, AV3DocOrigem, AV4DocOrigemID, AV5DocInsData, AV6DocInsHora, AV7DocInsDataHora, nV8DocInsUsuID, AV8DocInsUsuID, nV9DocUpdData, AV9DocUpdData, nV10DocUpdHora, AV10DocUpdHora, nV11DocUpdDataHora, AV11DocUpdDataHora, nV12DocUpdUsuID, AV12DocUpdUsuID, AV13DocDel, nV14DocDelData, AV14DocDelData, nV15DocDelHora, AV15DocDelHora, nV16DocDelDataHora, AV16DocDelDataHora, nV17DocDelUsuID, AV17DocDelUsuID, AV18DocNome, AV19DocTipoID, nV20DocUltArqSeq, AV20DocUltArqSeq, AV21DocVersao, nV22DocVersaoIDPai, AV22DocVersaoIDPai, AV23DocContrato, AV24DocAssinado, nV25DocDelUsuNome, AV25DocDelUsuNome});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("GXA0033");
            if ( (pr_default.getStatus(1) == 1) )
            {
               context.Gx_err = 1;
               Gx_emsg = (string)(GXResourceManager.GetMessage("GXM_noupdate"));
            }
            else
            {
               context.Gx_err = 0;
               Gx_emsg = "";
            }
            /* End Insert */
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
         TB_DOCUMEN2_A481DocAssinado = new bool[] {false} ;
         TB_DOCUMEN2_A480DocContrato = new bool[] {false} ;
         TB_DOCUMEN2_A326DocVersaoIDPai = new Guid[] {Guid.Empty} ;
         TB_DOCUMEN2_n326DocVersaoIDPai = new bool[] {false} ;
         TB_DOCUMEN2_A325DocVersao = new short[1] ;
         TB_DOCUMEN2_A306DocUltArqSeq = new short[1] ;
         TB_DOCUMEN2_n306DocUltArqSeq = new bool[] {false} ;
         TB_DOCUMEN2_A146DocTipoID = new int[1] ;
         TB_DOCUMEN2_A305DocNome = new string[] {""} ;
         TB_DOCUMEN2_A304DocDelUsuID = new string[] {""} ;
         TB_DOCUMEN2_n304DocDelUsuID = new bool[] {false} ;
         TB_DOCUMEN2_A303DocDelDataHora = new DateTime[] {DateTime.MinValue} ;
         TB_DOCUMEN2_n303DocDelDataHora = new bool[] {false} ;
         TB_DOCUMEN2_A302DocDelHora = new DateTime[] {DateTime.MinValue} ;
         TB_DOCUMEN2_n302DocDelHora = new bool[] {false} ;
         TB_DOCUMEN2_A300DocDel = new bool[] {false} ;
         TB_DOCUMEN2_A299DocUpdUsuID = new string[] {""} ;
         TB_DOCUMEN2_n299DocUpdUsuID = new bool[] {false} ;
         TB_DOCUMEN2_A298DocUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         TB_DOCUMEN2_n298DocUpdDataHora = new bool[] {false} ;
         TB_DOCUMEN2_A297DocUpdHora = new DateTime[] {DateTime.MinValue} ;
         TB_DOCUMEN2_n297DocUpdHora = new bool[] {false} ;
         TB_DOCUMEN2_A296DocUpdData = new DateTime[] {DateTime.MinValue} ;
         TB_DOCUMEN2_n296DocUpdData = new bool[] {false} ;
         TB_DOCUMEN2_A295DocInsUsuID = new string[] {""} ;
         TB_DOCUMEN2_n295DocInsUsuID = new bool[] {false} ;
         TB_DOCUMEN2_A294DocInsDataHora = new DateTime[] {DateTime.MinValue} ;
         TB_DOCUMEN2_A293DocInsHora = new DateTime[] {DateTime.MinValue} ;
         TB_DOCUMEN2_A292DocInsData = new DateTime[] {DateTime.MinValue} ;
         TB_DOCUMEN2_A291DocOrigemID = new string[] {""} ;
         TB_DOCUMEN2_A290DocOrigem = new string[] {""} ;
         TB_DOCUMEN2_A289DocID = new Guid[] {Guid.Empty} ;
         TB_DOCUMEN2_A301DocDelData = new DateTime[] {DateTime.MinValue} ;
         TB_DOCUMEN2_n301DocDelData = new bool[] {false} ;
         A326DocVersaoIDPai = Guid.Empty;
         A305DocNome = "";
         A304DocDelUsuID = "";
         A303DocDelDataHora = (DateTime)(DateTime.MinValue);
         A302DocDelHora = (DateTime)(DateTime.MinValue);
         A299DocUpdUsuID = "";
         A298DocUpdDataHora = (DateTime)(DateTime.MinValue);
         A297DocUpdHora = (DateTime)(DateTime.MinValue);
         A296DocUpdData = DateTime.MinValue;
         A295DocInsUsuID = "";
         A294DocInsDataHora = (DateTime)(DateTime.MinValue);
         A293DocInsHora = (DateTime)(DateTime.MinValue);
         A292DocInsData = DateTime.MinValue;
         A291DocOrigemID = "";
         A290DocOrigem = "";
         A289DocID = Guid.Empty;
         A301DocDelData = DateTime.MinValue;
         A40000GXC1 = (DateTime)(DateTime.MinValue);
         AV2DocID = Guid.Empty;
         AV3DocOrigem = "";
         AV4DocOrigemID = "";
         AV5DocInsData = DateTime.MinValue;
         AV6DocInsHora = (DateTime)(DateTime.MinValue);
         AV7DocInsDataHora = (DateTime)(DateTime.MinValue);
         AV8DocInsUsuID = "";
         AV9DocUpdData = DateTime.MinValue;
         AV10DocUpdHora = (DateTime)(DateTime.MinValue);
         AV11DocUpdDataHora = (DateTime)(DateTime.MinValue);
         AV12DocUpdUsuID = "";
         AV14DocDelData = (DateTime)(DateTime.MinValue);
         AV15DocDelHora = (DateTime)(DateTime.MinValue);
         AV16DocDelDataHora = (DateTime)(DateTime.MinValue);
         AV17DocDelUsuID = "";
         AV18DocNome = "";
         AV22DocVersaoIDPai = Guid.Empty;
         AV25DocDelUsuNome = "";
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tb_documentoconversion__default(),
            new Object[][] {
                new Object[] {
               TB_DOCUMEN2_A481DocAssinado, TB_DOCUMEN2_A480DocContrato, TB_DOCUMEN2_A326DocVersaoIDPai, TB_DOCUMEN2_n326DocVersaoIDPai, TB_DOCUMEN2_A325DocVersao, TB_DOCUMEN2_A306DocUltArqSeq, TB_DOCUMEN2_n306DocUltArqSeq, TB_DOCUMEN2_A146DocTipoID, TB_DOCUMEN2_A305DocNome, TB_DOCUMEN2_A304DocDelUsuID,
               TB_DOCUMEN2_n304DocDelUsuID, TB_DOCUMEN2_A303DocDelDataHora, TB_DOCUMEN2_n303DocDelDataHora, TB_DOCUMEN2_A302DocDelHora, TB_DOCUMEN2_n302DocDelHora, TB_DOCUMEN2_A300DocDel, TB_DOCUMEN2_A299DocUpdUsuID, TB_DOCUMEN2_n299DocUpdUsuID, TB_DOCUMEN2_A298DocUpdDataHora, TB_DOCUMEN2_n298DocUpdDataHora,
               TB_DOCUMEN2_A297DocUpdHora, TB_DOCUMEN2_n297DocUpdHora, TB_DOCUMEN2_A296DocUpdData, TB_DOCUMEN2_n296DocUpdData, TB_DOCUMEN2_A295DocInsUsuID, TB_DOCUMEN2_n295DocInsUsuID, TB_DOCUMEN2_A294DocInsDataHora, TB_DOCUMEN2_A293DocInsHora, TB_DOCUMEN2_A292DocInsData, TB_DOCUMEN2_A291DocOrigemID,
               TB_DOCUMEN2_A290DocOrigem, TB_DOCUMEN2_A289DocID, TB_DOCUMEN2_A301DocDelData, TB_DOCUMEN2_n301DocDelData
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A325DocVersao ;
      private short A306DocUltArqSeq ;
      private short AV20DocUltArqSeq ;
      private short AV21DocVersao ;
      private int A146DocTipoID ;
      private int GIGXA0033 ;
      private int AV19DocTipoID ;
      private string scmdbuf ;
      private string A304DocDelUsuID ;
      private string A299DocUpdUsuID ;
      private string A295DocInsUsuID ;
      private string AV8DocInsUsuID ;
      private string AV12DocUpdUsuID ;
      private string AV17DocDelUsuID ;
      private string Gx_emsg ;
      private DateTime A303DocDelDataHora ;
      private DateTime A302DocDelHora ;
      private DateTime A298DocUpdDataHora ;
      private DateTime A297DocUpdHora ;
      private DateTime A294DocInsDataHora ;
      private DateTime A293DocInsHora ;
      private DateTime A40000GXC1 ;
      private DateTime AV6DocInsHora ;
      private DateTime AV7DocInsDataHora ;
      private DateTime AV10DocUpdHora ;
      private DateTime AV11DocUpdDataHora ;
      private DateTime AV14DocDelData ;
      private DateTime AV15DocDelHora ;
      private DateTime AV16DocDelDataHora ;
      private DateTime A296DocUpdData ;
      private DateTime A292DocInsData ;
      private DateTime A301DocDelData ;
      private DateTime AV5DocInsData ;
      private DateTime AV9DocUpdData ;
      private bool A481DocAssinado ;
      private bool A480DocContrato ;
      private bool n326DocVersaoIDPai ;
      private bool n306DocUltArqSeq ;
      private bool n304DocDelUsuID ;
      private bool n303DocDelDataHora ;
      private bool n302DocDelHora ;
      private bool A300DocDel ;
      private bool n299DocUpdUsuID ;
      private bool n298DocUpdDataHora ;
      private bool n297DocUpdHora ;
      private bool n296DocUpdData ;
      private bool n295DocInsUsuID ;
      private bool n301DocDelData ;
      private bool nV8DocInsUsuID ;
      private bool nV9DocUpdData ;
      private bool nV10DocUpdHora ;
      private bool nV11DocUpdDataHora ;
      private bool nV12DocUpdUsuID ;
      private bool AV13DocDel ;
      private bool nV14DocDelData ;
      private bool nV15DocDelHora ;
      private bool nV16DocDelDataHora ;
      private bool nV17DocDelUsuID ;
      private bool nV20DocUltArqSeq ;
      private bool nV22DocVersaoIDPai ;
      private bool AV23DocContrato ;
      private bool AV24DocAssinado ;
      private bool nV25DocDelUsuNome ;
      private string A305DocNome ;
      private string A291DocOrigemID ;
      private string A290DocOrigem ;
      private string AV3DocOrigem ;
      private string AV4DocOrigemID ;
      private string AV18DocNome ;
      private string AV25DocDelUsuNome ;
      private Guid A326DocVersaoIDPai ;
      private Guid A289DocID ;
      private Guid AV2DocID ;
      private Guid AV22DocVersaoIDPai ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private bool[] TB_DOCUMEN2_A481DocAssinado ;
      private bool[] TB_DOCUMEN2_A480DocContrato ;
      private Guid[] TB_DOCUMEN2_A326DocVersaoIDPai ;
      private bool[] TB_DOCUMEN2_n326DocVersaoIDPai ;
      private short[] TB_DOCUMEN2_A325DocVersao ;
      private short[] TB_DOCUMEN2_A306DocUltArqSeq ;
      private bool[] TB_DOCUMEN2_n306DocUltArqSeq ;
      private int[] TB_DOCUMEN2_A146DocTipoID ;
      private string[] TB_DOCUMEN2_A305DocNome ;
      private string[] TB_DOCUMEN2_A304DocDelUsuID ;
      private bool[] TB_DOCUMEN2_n304DocDelUsuID ;
      private DateTime[] TB_DOCUMEN2_A303DocDelDataHora ;
      private bool[] TB_DOCUMEN2_n303DocDelDataHora ;
      private DateTime[] TB_DOCUMEN2_A302DocDelHora ;
      private bool[] TB_DOCUMEN2_n302DocDelHora ;
      private bool[] TB_DOCUMEN2_A300DocDel ;
      private string[] TB_DOCUMEN2_A299DocUpdUsuID ;
      private bool[] TB_DOCUMEN2_n299DocUpdUsuID ;
      private DateTime[] TB_DOCUMEN2_A298DocUpdDataHora ;
      private bool[] TB_DOCUMEN2_n298DocUpdDataHora ;
      private DateTime[] TB_DOCUMEN2_A297DocUpdHora ;
      private bool[] TB_DOCUMEN2_n297DocUpdHora ;
      private DateTime[] TB_DOCUMEN2_A296DocUpdData ;
      private bool[] TB_DOCUMEN2_n296DocUpdData ;
      private string[] TB_DOCUMEN2_A295DocInsUsuID ;
      private bool[] TB_DOCUMEN2_n295DocInsUsuID ;
      private DateTime[] TB_DOCUMEN2_A294DocInsDataHora ;
      private DateTime[] TB_DOCUMEN2_A293DocInsHora ;
      private DateTime[] TB_DOCUMEN2_A292DocInsData ;
      private string[] TB_DOCUMEN2_A291DocOrigemID ;
      private string[] TB_DOCUMEN2_A290DocOrigem ;
      private Guid[] TB_DOCUMEN2_A289DocID ;
      private DateTime[] TB_DOCUMEN2_A301DocDelData ;
      private bool[] TB_DOCUMEN2_n301DocDelData ;
   }

   public class tb_documentoconversion__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmTB_DOCUMEN2;
          prmTB_DOCUMEN2 = new Object[] {
          };
          Object[] prmTB_DOCUMEN3;
          prmTB_DOCUMEN3 = new Object[] {
          new ParDef("AV2DocID",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV3DocOrigem",GXType.VarChar,30,0) ,
          new ParDef("AV4DocOrigemID",GXType.VarChar,50,0) ,
          new ParDef("AV5DocInsData",GXType.Date,8,0) ,
          new ParDef("AV6DocInsHora",GXType.DateTime,0,5) ,
          new ParDef("AV7DocInsDataHora",GXType.DateTime2,10,12) ,
          new ParDef("AV8DocInsUsuID",GXType.Char,40,0){Nullable=true} ,
          new ParDef("AV9DocUpdData",GXType.Date,8,0){Nullable=true} ,
          new ParDef("AV10DocUpdHora",GXType.DateTime,0,5){Nullable=true} ,
          new ParDef("AV11DocUpdDataHora",GXType.DateTime2,10,12){Nullable=true} ,
          new ParDef("AV12DocUpdUsuID",GXType.Char,40,0){Nullable=true} ,
          new ParDef("AV13DocDel",GXType.Boolean,4,0) ,
          new ParDef("AV14DocDelData",GXType.DateTime,10,5){Nullable=true} ,
          new ParDef("AV15DocDelHora",GXType.DateTime,0,5){Nullable=true} ,
          new ParDef("AV16DocDelDataHora",GXType.DateTime2,10,12){Nullable=true} ,
          new ParDef("AV17DocDelUsuID",GXType.Char,40,0){Nullable=true} ,
          new ParDef("AV18DocNome",GXType.VarChar,80,0) ,
          new ParDef("AV19DocTipoID",GXType.Int32,9,0) ,
          new ParDef("AV20DocUltArqSeq",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("AV21DocVersao",GXType.Int16,4,0) ,
          new ParDef("AV22DocVersaoIDPai",GXType.UniqueIdentifier,36,0){Nullable=true} ,
          new ParDef("AV23DocContrato",GXType.Boolean,4,0) ,
          new ParDef("AV24DocAssinado",GXType.Boolean,4,0) ,
          new ParDef("AV25DocDelUsuNome",GXType.VarChar,80,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("TB_DOCUMEN2", "SELECT DocAssinado, DocContrato, DocVersaoIDPai, DocVersao, DocUltArqSeq, DocTipoID, DocNome, DocDelUsuID, DocDelDataHora, DocDelHora, DocDel, DocUpdUsuID, DocUpdDataHora, DocUpdHora, DocUpdData, DocInsUsuID, DocInsDataHora, DocInsHora, DocInsData, DocOrigemID, DocOrigem, DocID, DocDelData FROM tb_documento ORDER BY DocID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmTB_DOCUMEN2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("TB_DOCUMEN3", "INSERT INTO GXA0033(DocID, DocOrigem, DocOrigemID, DocInsData, DocInsHora, DocInsDataHora, DocInsUsuID, DocUpdData, DocUpdHora, DocUpdDataHora, DocUpdUsuID, DocDel, DocDelData, DocDelHora, DocDelDataHora, DocDelUsuID, DocNome, DocTipoID, DocUltArqSeq, DocVersao, DocVersaoIDPai, DocContrato, DocAssinado, DocDelUsuNome) VALUES(:AV2DocID, :AV3DocOrigem, :AV4DocOrigemID, :AV5DocInsData, :AV6DocInsHora, :AV7DocInsDataHora, :AV8DocInsUsuID, :AV9DocUpdData, :AV10DocUpdHora, :AV11DocUpdDataHora, :AV12DocUpdUsuID, :AV13DocDel, :AV14DocDelData, :AV15DocDelHora, :AV16DocDelDataHora, :AV17DocDelUsuID, :AV18DocNome, :AV19DocTipoID, :AV20DocUltArqSeq, :AV21DocVersao, :AV22DocVersaoIDPai, :AV23DocContrato, :AV24DocAssinado, :AV25DocDelUsuNome)", GxErrorMask.GX_NOMASK,prmTB_DOCUMEN3)
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
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((short[]) buf[4])[0] = rslt.getShort(4);
                ((short[]) buf[5])[0] = rslt.getShort(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((int[]) buf[7])[0] = rslt.getInt(6);
                ((string[]) buf[8])[0] = rslt.getVarchar(7);
                ((string[]) buf[9])[0] = rslt.getString(8, 40);
                ((bool[]) buf[10])[0] = rslt.wasNull(8);
                ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(9, true);
                ((bool[]) buf[12])[0] = rslt.wasNull(9);
                ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(10);
                ((bool[]) buf[14])[0] = rslt.wasNull(10);
                ((bool[]) buf[15])[0] = rslt.getBool(11);
                ((string[]) buf[16])[0] = rslt.getString(12, 40);
                ((bool[]) buf[17])[0] = rslt.wasNull(12);
                ((DateTime[]) buf[18])[0] = rslt.getGXDateTime(13, true);
                ((bool[]) buf[19])[0] = rslt.wasNull(13);
                ((DateTime[]) buf[20])[0] = rslt.getGXDateTime(14);
                ((bool[]) buf[21])[0] = rslt.wasNull(14);
                ((DateTime[]) buf[22])[0] = rslt.getGXDate(15);
                ((bool[]) buf[23])[0] = rslt.wasNull(15);
                ((string[]) buf[24])[0] = rslt.getString(16, 40);
                ((bool[]) buf[25])[0] = rslt.wasNull(16);
                ((DateTime[]) buf[26])[0] = rslt.getGXDateTime(17, true);
                ((DateTime[]) buf[27])[0] = rslt.getGXDateTime(18);
                ((DateTime[]) buf[28])[0] = rslt.getGXDate(19);
                ((string[]) buf[29])[0] = rslt.getVarchar(20);
                ((string[]) buf[30])[0] = rslt.getVarchar(21);
                ((Guid[]) buf[31])[0] = rslt.getGuid(22);
                ((DateTime[]) buf[32])[0] = rslt.getGXDate(23);
                ((bool[]) buf[33])[0] = rslt.wasNull(23);
                return;
       }
    }

 }

}
