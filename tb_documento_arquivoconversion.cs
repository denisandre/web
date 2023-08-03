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
   public class tb_documento_arquivoconversion : GXProcedure
   {
      public tb_documento_arquivoconversion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", false);
      }

      public tb_documento_arquivoconversion( IGxContext context )
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
         tb_documento_arquivoconversion objtb_documento_arquivoconversion;
         objtb_documento_arquivoconversion = new tb_documento_arquivoconversion();
         objtb_documento_arquivoconversion.context.SetSubmitInitialConfig(context);
         objtb_documento_arquivoconversion.initialize();
         Submit( executePrivateCatch,objtb_documento_arquivoconversion);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((tb_documento_arquivoconversion)stateInfo).executePrivate();
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
            A509DocArqDelUsuNome = TB_DOCUMEN2_A509DocArqDelUsuNome[0];
            n509DocArqDelUsuNome = TB_DOCUMEN2_n509DocArqDelUsuNome[0];
            A324DocArqObservacao = TB_DOCUMEN2_A324DocArqObservacao[0];
            n324DocArqObservacao = TB_DOCUMEN2_n324DocArqObservacao[0];
            A320DocArqDelUsuID = TB_DOCUMEN2_A320DocArqDelUsuID[0];
            n320DocArqDelUsuID = TB_DOCUMEN2_n320DocArqDelUsuID[0];
            A319DocArqDelDataHora = TB_DOCUMEN2_A319DocArqDelDataHora[0];
            n319DocArqDelDataHora = TB_DOCUMEN2_n319DocArqDelDataHora[0];
            A316DocArqDel = TB_DOCUMEN2_A316DocArqDel[0];
            A315DocArqUsuID = TB_DOCUMEN2_A315DocArqUsuID[0];
            n315DocArqUsuID = TB_DOCUMEN2_n315DocArqUsuID[0];
            A314DocArqUpdDataHora = TB_DOCUMEN2_A314DocArqUpdDataHora[0];
            n314DocArqUpdDataHora = TB_DOCUMEN2_n314DocArqUpdDataHora[0];
            A313DocArqUpdHora = TB_DOCUMEN2_A313DocArqUpdHora[0];
            n313DocArqUpdHora = TB_DOCUMEN2_n313DocArqUpdHora[0];
            A312DocArqUpdData = TB_DOCUMEN2_A312DocArqUpdData[0];
            n312DocArqUpdData = TB_DOCUMEN2_n312DocArqUpdData[0];
            A311DocArqInsUsuID = TB_DOCUMEN2_A311DocArqInsUsuID[0];
            n311DocArqInsUsuID = TB_DOCUMEN2_n311DocArqInsUsuID[0];
            A310DocArqInsDataHora = TB_DOCUMEN2_A310DocArqInsDataHora[0];
            A309DocArqInsHora = TB_DOCUMEN2_A309DocArqInsHora[0];
            A308DocArqInsData = TB_DOCUMEN2_A308DocArqInsData[0];
            A307DocArqSeq = TB_DOCUMEN2_A307DocArqSeq[0];
            A289DocID = TB_DOCUMEN2_A289DocID[0];
            A323DocArqConteudoExtensao = TB_DOCUMEN2_A323DocArqConteudoExtensao[0];
            A322DocArqConteudoNome = TB_DOCUMEN2_A322DocArqConteudoNome[0];
            A317DocArqDelData = TB_DOCUMEN2_A317DocArqDelData[0];
            n317DocArqDelData = TB_DOCUMEN2_n317DocArqDelData[0];
            A321DocArqConteudo = TB_DOCUMEN2_A321DocArqConteudo[0];
            A40000GXC1 = ( A317DocArqDelData);
            /*
               INSERT RECORD ON TABLE GXA0034

            */
            AV2DocID = A289DocID;
            AV3DocArqSeq = A307DocArqSeq;
            AV4DocArqInsData = A308DocArqInsData;
            AV5DocArqInsHora = A309DocArqInsHora;
            AV6DocArqInsDataHora = A310DocArqInsDataHora;
            if ( TB_DOCUMEN2_n311DocArqInsUsuID[0] )
            {
               AV7DocArqInsUsuID = "";
               nV7DocArqInsUsuID = false;
               nV7DocArqInsUsuID = true;
            }
            else
            {
               AV7DocArqInsUsuID = A311DocArqInsUsuID;
               nV7DocArqInsUsuID = false;
            }
            if ( TB_DOCUMEN2_n312DocArqUpdData[0] )
            {
               AV8DocArqUpdData = DateTime.MinValue;
               nV8DocArqUpdData = false;
               nV8DocArqUpdData = true;
            }
            else
            {
               AV8DocArqUpdData = A312DocArqUpdData;
               nV8DocArqUpdData = false;
            }
            if ( TB_DOCUMEN2_n313DocArqUpdHora[0] )
            {
               AV9DocArqUpdHora = (DateTime)(DateTime.MinValue);
               nV9DocArqUpdHora = false;
               nV9DocArqUpdHora = true;
            }
            else
            {
               AV9DocArqUpdHora = A313DocArqUpdHora;
               nV9DocArqUpdHora = false;
            }
            if ( TB_DOCUMEN2_n314DocArqUpdDataHora[0] )
            {
               AV10DocArqUpdDataHora = (DateTime)(DateTime.MinValue);
               nV10DocArqUpdDataHora = false;
               nV10DocArqUpdDataHora = true;
            }
            else
            {
               AV10DocArqUpdDataHora = A314DocArqUpdDataHora;
               nV10DocArqUpdDataHora = false;
            }
            if ( TB_DOCUMEN2_n315DocArqUsuID[0] )
            {
               AV11DocArqUsuID = "";
               nV11DocArqUsuID = false;
               nV11DocArqUsuID = true;
            }
            else
            {
               AV11DocArqUsuID = A315DocArqUsuID;
               nV11DocArqUsuID = false;
            }
            AV12DocArqDel = A316DocArqDel;
            if ( TB_DOCUMEN2_n317DocArqDelData[0] )
            {
               AV13DocArqDelData = (DateTime)(DateTime.MinValue);
               nV13DocArqDelData = false;
               nV13DocArqDelData = true;
            }
            else
            {
               AV13DocArqDelData = A40000GXC1;
               nV13DocArqDelData = false;
            }
            if ( TB_DOCUMEN2_n319DocArqDelDataHora[0] )
            {
               AV14DocArqDelDataHora = (DateTime)(DateTime.MinValue);
               nV14DocArqDelDataHora = false;
               nV14DocArqDelDataHora = true;
            }
            else
            {
               AV14DocArqDelDataHora = A319DocArqDelDataHora;
               nV14DocArqDelDataHora = false;
            }
            if ( TB_DOCUMEN2_n320DocArqDelUsuID[0] )
            {
               AV15DocArqDelUsuID = "";
               nV15DocArqDelUsuID = false;
               nV15DocArqDelUsuID = true;
            }
            else
            {
               AV15DocArqDelUsuID = A320DocArqDelUsuID;
               nV15DocArqDelUsuID = false;
            }
            AV16DocArqConteudo = A321DocArqConteudo;
            AV17DocArqConteudoNome = A322DocArqConteudoNome;
            AV18DocArqConteudoExtensao = A323DocArqConteudoExtensao;
            if ( TB_DOCUMEN2_n324DocArqObservacao[0] )
            {
               AV19DocArqObservacao = "";
               nV19DocArqObservacao = false;
               nV19DocArqObservacao = true;
            }
            else
            {
               AV19DocArqObservacao = A324DocArqObservacao;
               nV19DocArqObservacao = false;
            }
            if ( TB_DOCUMEN2_n509DocArqDelUsuNome[0] )
            {
               AV20DocArqDelUsuNome = "";
               nV20DocArqDelUsuNome = false;
               nV20DocArqDelUsuNome = true;
            }
            else
            {
               AV20DocArqDelUsuNome = A509DocArqDelUsuNome;
               nV20DocArqDelUsuNome = false;
            }
            AV21DocArqDelHora = (DateTime)(DateTime.MinValue);
            nV21DocArqDelHora = false;
            nV21DocArqDelHora = true;
            /* Using cursor TB_DOCUMEN3 */
            pr_default.execute(1, new Object[] {AV2DocID, AV3DocArqSeq, AV4DocArqInsData, AV5DocArqInsHora, AV6DocArqInsDataHora, nV7DocArqInsUsuID, AV7DocArqInsUsuID, nV8DocArqUpdData, AV8DocArqUpdData, nV9DocArqUpdHora, AV9DocArqUpdHora, nV10DocArqUpdDataHora, AV10DocArqUpdDataHora, nV11DocArqUsuID, AV11DocArqUsuID, AV12DocArqDel, nV13DocArqDelData, AV13DocArqDelData, nV14DocArqDelDataHora, AV14DocArqDelDataHora, nV15DocArqDelUsuID, AV15DocArqDelUsuID, AV16DocArqConteudo, AV17DocArqConteudoNome, AV18DocArqConteudoExtensao, nV19DocArqObservacao, AV19DocArqObservacao, nV20DocArqDelUsuNome, AV20DocArqDelUsuNome, nV21DocArqDelHora, AV21DocArqDelHora});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("GXA0034");
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
         TB_DOCUMEN2_A509DocArqDelUsuNome = new string[] {""} ;
         TB_DOCUMEN2_n509DocArqDelUsuNome = new bool[] {false} ;
         TB_DOCUMEN2_A324DocArqObservacao = new string[] {""} ;
         TB_DOCUMEN2_n324DocArqObservacao = new bool[] {false} ;
         TB_DOCUMEN2_A320DocArqDelUsuID = new string[] {""} ;
         TB_DOCUMEN2_n320DocArqDelUsuID = new bool[] {false} ;
         TB_DOCUMEN2_A319DocArqDelDataHora = new DateTime[] {DateTime.MinValue} ;
         TB_DOCUMEN2_n319DocArqDelDataHora = new bool[] {false} ;
         TB_DOCUMEN2_A316DocArqDel = new bool[] {false} ;
         TB_DOCUMEN2_A315DocArqUsuID = new string[] {""} ;
         TB_DOCUMEN2_n315DocArqUsuID = new bool[] {false} ;
         TB_DOCUMEN2_A314DocArqUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         TB_DOCUMEN2_n314DocArqUpdDataHora = new bool[] {false} ;
         TB_DOCUMEN2_A313DocArqUpdHora = new DateTime[] {DateTime.MinValue} ;
         TB_DOCUMEN2_n313DocArqUpdHora = new bool[] {false} ;
         TB_DOCUMEN2_A312DocArqUpdData = new DateTime[] {DateTime.MinValue} ;
         TB_DOCUMEN2_n312DocArqUpdData = new bool[] {false} ;
         TB_DOCUMEN2_A311DocArqInsUsuID = new string[] {""} ;
         TB_DOCUMEN2_n311DocArqInsUsuID = new bool[] {false} ;
         TB_DOCUMEN2_A310DocArqInsDataHora = new DateTime[] {DateTime.MinValue} ;
         TB_DOCUMEN2_A309DocArqInsHora = new DateTime[] {DateTime.MinValue} ;
         TB_DOCUMEN2_A308DocArqInsData = new DateTime[] {DateTime.MinValue} ;
         TB_DOCUMEN2_A307DocArqSeq = new short[1] ;
         TB_DOCUMEN2_A289DocID = new Guid[] {Guid.Empty} ;
         TB_DOCUMEN2_A323DocArqConteudoExtensao = new string[] {""} ;
         TB_DOCUMEN2_A322DocArqConteudoNome = new string[] {""} ;
         TB_DOCUMEN2_A317DocArqDelData = new DateTime[] {DateTime.MinValue} ;
         TB_DOCUMEN2_n317DocArqDelData = new bool[] {false} ;
         TB_DOCUMEN2_A321DocArqConteudo = new string[] {""} ;
         A509DocArqDelUsuNome = "";
         A324DocArqObservacao = "";
         A320DocArqDelUsuID = "";
         A319DocArqDelDataHora = (DateTime)(DateTime.MinValue);
         A315DocArqUsuID = "";
         A314DocArqUpdDataHora = (DateTime)(DateTime.MinValue);
         A313DocArqUpdHora = (DateTime)(DateTime.MinValue);
         A312DocArqUpdData = DateTime.MinValue;
         A311DocArqInsUsuID = "";
         A310DocArqInsDataHora = (DateTime)(DateTime.MinValue);
         A309DocArqInsHora = (DateTime)(DateTime.MinValue);
         A308DocArqInsData = DateTime.MinValue;
         A289DocID = Guid.Empty;
         A323DocArqConteudoExtensao = "";
         A322DocArqConteudoNome = "";
         A317DocArqDelData = DateTime.MinValue;
         A321DocArqConteudo = "";
         A40000GXC1 = (DateTime)(DateTime.MinValue);
         AV2DocID = Guid.Empty;
         AV4DocArqInsData = DateTime.MinValue;
         AV5DocArqInsHora = (DateTime)(DateTime.MinValue);
         AV6DocArqInsDataHora = (DateTime)(DateTime.MinValue);
         AV7DocArqInsUsuID = "";
         AV8DocArqUpdData = DateTime.MinValue;
         AV9DocArqUpdHora = (DateTime)(DateTime.MinValue);
         AV10DocArqUpdDataHora = (DateTime)(DateTime.MinValue);
         AV11DocArqUsuID = "";
         AV13DocArqDelData = (DateTime)(DateTime.MinValue);
         AV14DocArqDelDataHora = (DateTime)(DateTime.MinValue);
         AV15DocArqDelUsuID = "";
         AV16DocArqConteudo = "";
         AV17DocArqConteudoNome = "";
         AV18DocArqConteudoExtensao = "";
         AV19DocArqObservacao = "";
         AV20DocArqDelUsuNome = "";
         AV21DocArqDelHora = (DateTime)(DateTime.MinValue);
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tb_documento_arquivoconversion__default(),
            new Object[][] {
                new Object[] {
               TB_DOCUMEN2_A509DocArqDelUsuNome, TB_DOCUMEN2_n509DocArqDelUsuNome, TB_DOCUMEN2_A324DocArqObservacao, TB_DOCUMEN2_n324DocArqObservacao, TB_DOCUMEN2_A320DocArqDelUsuID, TB_DOCUMEN2_n320DocArqDelUsuID, TB_DOCUMEN2_A319DocArqDelDataHora, TB_DOCUMEN2_n319DocArqDelDataHora, TB_DOCUMEN2_A316DocArqDel, TB_DOCUMEN2_A315DocArqUsuID,
               TB_DOCUMEN2_n315DocArqUsuID, TB_DOCUMEN2_A314DocArqUpdDataHora, TB_DOCUMEN2_n314DocArqUpdDataHora, TB_DOCUMEN2_A313DocArqUpdHora, TB_DOCUMEN2_n313DocArqUpdHora, TB_DOCUMEN2_A312DocArqUpdData, TB_DOCUMEN2_n312DocArqUpdData, TB_DOCUMEN2_A311DocArqInsUsuID, TB_DOCUMEN2_n311DocArqInsUsuID, TB_DOCUMEN2_A310DocArqInsDataHora,
               TB_DOCUMEN2_A309DocArqInsHora, TB_DOCUMEN2_A308DocArqInsData, TB_DOCUMEN2_A307DocArqSeq, TB_DOCUMEN2_A289DocID, TB_DOCUMEN2_A323DocArqConteudoExtensao, TB_DOCUMEN2_A322DocArqConteudoNome, TB_DOCUMEN2_A317DocArqDelData, TB_DOCUMEN2_n317DocArqDelData, TB_DOCUMEN2_A321DocArqConteudo
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A307DocArqSeq ;
      private short AV3DocArqSeq ;
      private int GIGXA0034 ;
      private string scmdbuf ;
      private string A320DocArqDelUsuID ;
      private string A315DocArqUsuID ;
      private string A311DocArqInsUsuID ;
      private string AV7DocArqInsUsuID ;
      private string AV11DocArqUsuID ;
      private string AV15DocArqDelUsuID ;
      private string Gx_emsg ;
      private DateTime A319DocArqDelDataHora ;
      private DateTime A314DocArqUpdDataHora ;
      private DateTime A313DocArqUpdHora ;
      private DateTime A310DocArqInsDataHora ;
      private DateTime A309DocArqInsHora ;
      private DateTime A40000GXC1 ;
      private DateTime AV5DocArqInsHora ;
      private DateTime AV6DocArqInsDataHora ;
      private DateTime AV9DocArqUpdHora ;
      private DateTime AV10DocArqUpdDataHora ;
      private DateTime AV13DocArqDelData ;
      private DateTime AV14DocArqDelDataHora ;
      private DateTime AV21DocArqDelHora ;
      private DateTime A312DocArqUpdData ;
      private DateTime A308DocArqInsData ;
      private DateTime A317DocArqDelData ;
      private DateTime AV4DocArqInsData ;
      private DateTime AV8DocArqUpdData ;
      private bool n509DocArqDelUsuNome ;
      private bool n324DocArqObservacao ;
      private bool n320DocArqDelUsuID ;
      private bool n319DocArqDelDataHora ;
      private bool A316DocArqDel ;
      private bool n315DocArqUsuID ;
      private bool n314DocArqUpdDataHora ;
      private bool n313DocArqUpdHora ;
      private bool n312DocArqUpdData ;
      private bool n311DocArqInsUsuID ;
      private bool n317DocArqDelData ;
      private bool nV7DocArqInsUsuID ;
      private bool nV8DocArqUpdData ;
      private bool nV9DocArqUpdHora ;
      private bool nV10DocArqUpdDataHora ;
      private bool nV11DocArqUsuID ;
      private bool AV12DocArqDel ;
      private bool nV13DocArqDelData ;
      private bool nV14DocArqDelDataHora ;
      private bool nV15DocArqDelUsuID ;
      private bool nV19DocArqObservacao ;
      private bool nV20DocArqDelUsuNome ;
      private bool nV21DocArqDelHora ;
      private string A509DocArqDelUsuNome ;
      private string A324DocArqObservacao ;
      private string A323DocArqConteudoExtensao ;
      private string A322DocArqConteudoNome ;
      private string AV17DocArqConteudoNome ;
      private string AV18DocArqConteudoExtensao ;
      private string AV19DocArqObservacao ;
      private string AV20DocArqDelUsuNome ;
      private Guid A289DocID ;
      private Guid AV2DocID ;
      private string A321DocArqConteudo ;
      private string AV16DocArqConteudo ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] TB_DOCUMEN2_A509DocArqDelUsuNome ;
      private bool[] TB_DOCUMEN2_n509DocArqDelUsuNome ;
      private string[] TB_DOCUMEN2_A324DocArqObservacao ;
      private bool[] TB_DOCUMEN2_n324DocArqObservacao ;
      private string[] TB_DOCUMEN2_A320DocArqDelUsuID ;
      private bool[] TB_DOCUMEN2_n320DocArqDelUsuID ;
      private DateTime[] TB_DOCUMEN2_A319DocArqDelDataHora ;
      private bool[] TB_DOCUMEN2_n319DocArqDelDataHora ;
      private bool[] TB_DOCUMEN2_A316DocArqDel ;
      private string[] TB_DOCUMEN2_A315DocArqUsuID ;
      private bool[] TB_DOCUMEN2_n315DocArqUsuID ;
      private DateTime[] TB_DOCUMEN2_A314DocArqUpdDataHora ;
      private bool[] TB_DOCUMEN2_n314DocArqUpdDataHora ;
      private DateTime[] TB_DOCUMEN2_A313DocArqUpdHora ;
      private bool[] TB_DOCUMEN2_n313DocArqUpdHora ;
      private DateTime[] TB_DOCUMEN2_A312DocArqUpdData ;
      private bool[] TB_DOCUMEN2_n312DocArqUpdData ;
      private string[] TB_DOCUMEN2_A311DocArqInsUsuID ;
      private bool[] TB_DOCUMEN2_n311DocArqInsUsuID ;
      private DateTime[] TB_DOCUMEN2_A310DocArqInsDataHora ;
      private DateTime[] TB_DOCUMEN2_A309DocArqInsHora ;
      private DateTime[] TB_DOCUMEN2_A308DocArqInsData ;
      private short[] TB_DOCUMEN2_A307DocArqSeq ;
      private Guid[] TB_DOCUMEN2_A289DocID ;
      private string[] TB_DOCUMEN2_A323DocArqConteudoExtensao ;
      private string[] TB_DOCUMEN2_A322DocArqConteudoNome ;
      private DateTime[] TB_DOCUMEN2_A317DocArqDelData ;
      private bool[] TB_DOCUMEN2_n317DocArqDelData ;
      private string[] TB_DOCUMEN2_A321DocArqConteudo ;
   }

   public class tb_documento_arquivoconversion__default : DataStoreHelperBase, IDataStoreHelper
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
          new ParDef("AV3DocArqSeq",GXType.Int16,4,0) ,
          new ParDef("AV4DocArqInsData",GXType.Date,8,0) ,
          new ParDef("AV5DocArqInsHora",GXType.DateTime,0,5) ,
          new ParDef("AV6DocArqInsDataHora",GXType.DateTime2,10,12) ,
          new ParDef("AV7DocArqInsUsuID",GXType.Char,40,0){Nullable=true} ,
          new ParDef("AV8DocArqUpdData",GXType.Date,8,0){Nullable=true} ,
          new ParDef("AV9DocArqUpdHora",GXType.DateTime,0,5){Nullable=true} ,
          new ParDef("AV10DocArqUpdDataHora",GXType.DateTime2,10,12){Nullable=true} ,
          new ParDef("AV11DocArqUsuID",GXType.Char,40,0){Nullable=true} ,
          new ParDef("AV12DocArqDel",GXType.Boolean,4,0) ,
          new ParDef("AV13DocArqDelData",GXType.DateTime,10,5){Nullable=true} ,
          new ParDef("AV14DocArqDelDataHora",GXType.DateTime2,10,12){Nullable=true} ,
          new ParDef("AV15DocArqDelUsuID",GXType.Char,40,0){Nullable=true} ,
          new ParDef("AV16DocArqConteudo",GXType.Byte,1024,0){InDB=true} ,
          new ParDef("AV17DocArqConteudoNome",GXType.VarChar,2000,0) ,
          new ParDef("AV18DocArqConteudoExtensao",GXType.VarChar,20,0) ,
          new ParDef("AV19DocArqObservacao",GXType.VarChar,2000,0){Nullable=true} ,
          new ParDef("AV20DocArqDelUsuNome",GXType.VarChar,80,0){Nullable=true} ,
          new ParDef("AV21DocArqDelHora",GXType.DateTime,0,5){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("TB_DOCUMEN2", "SELECT DocArqDelUsuNome, DocArqObservacao, DocArqDelUsuID, DocArqDelDataHora, DocArqDel, DocArqUsuID, DocArqUpdDataHora, DocArqUpdHora, DocArqUpdData, DocArqInsUsuID, DocArqInsDataHora, DocArqInsHora, DocArqInsData, DocArqSeq, DocID, DocArqConteudoExtensao, DocArqConteudoNome, DocArqDelData, DocArqConteudo FROM tb_documento_arquivo ORDER BY DocID, DocArqSeq ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmTB_DOCUMEN2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("TB_DOCUMEN3", "INSERT INTO GXA0034(DocID, DocArqSeq, DocArqInsData, DocArqInsHora, DocArqInsDataHora, DocArqInsUsuID, DocArqUpdData, DocArqUpdHora, DocArqUpdDataHora, DocArqUsuID, DocArqDel, DocArqDelData, DocArqDelDataHora, DocArqDelUsuID, DocArqConteudo, DocArqConteudoNome, DocArqConteudoExtensao, DocArqObservacao, DocArqDelUsuNome, DocArqDelHora) VALUES(:AV2DocID, :AV3DocArqSeq, :AV4DocArqInsData, :AV5DocArqInsHora, :AV6DocArqInsDataHora, :AV7DocArqInsUsuID, :AV8DocArqUpdData, :AV9DocArqUpdHora, :AV10DocArqUpdDataHora, :AV11DocArqUsuID, :AV12DocArqDel, :AV13DocArqDelData, :AV14DocArqDelDataHora, :AV15DocArqDelUsuID, :AV16DocArqConteudo, :AV17DocArqConteudoNome, :AV18DocArqConteudoExtensao, :AV19DocArqObservacao, :AV20DocArqDelUsuNome, :AV21DocArqDelHora)", GxErrorMask.GX_NOMASK,prmTB_DOCUMEN3)
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getString(3, 40);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((bool[]) buf[8])[0] = rslt.getBool(5);
                ((string[]) buf[9])[0] = rslt.getString(6, 40);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(7, true);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((DateTime[]) buf[15])[0] = rslt.getGXDate(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getString(10, 40);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((DateTime[]) buf[19])[0] = rslt.getGXDateTime(11, true);
                ((DateTime[]) buf[20])[0] = rslt.getGXDateTime(12);
                ((DateTime[]) buf[21])[0] = rslt.getGXDate(13);
                ((short[]) buf[22])[0] = rslt.getShort(14);
                ((Guid[]) buf[23])[0] = rslt.getGuid(15);
                ((string[]) buf[24])[0] = rslt.getVarchar(16);
                ((string[]) buf[25])[0] = rslt.getVarchar(17);
                ((DateTime[]) buf[26])[0] = rslt.getGXDate(18);
                ((bool[]) buf[27])[0] = rslt.wasNull(18);
                ((string[]) buf[28])[0] = rslt.getBLOBFile(19, rslt.getVarchar(16), rslt.getVarchar(17));
                return;
       }
    }

 }

}
