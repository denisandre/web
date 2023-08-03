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
   public class tb_negociopjconversion : GXProcedure
   {
      public tb_negociopjconversion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", false);
      }

      public tb_negociopjconversion( IGxContext context )
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
         tb_negociopjconversion objtb_negociopjconversion;
         objtb_negociopjconversion = new tb_negociopjconversion();
         objtb_negociopjconversion.context.SetSubmitInitialConfig(context);
         objtb_negociopjconversion.initialize();
         Submit( executePrivateCatch,objtb_negociopjconversion);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((tb_negociopjconversion)stateInfo).executePrivate();
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
         /* Using cursor TB_NEGOCIO2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A421NegUltIteNome = TB_NEGOCIO2_A421NegUltIteNome[0];
            n421NegUltIteNome = TB_NEGOCIO2_n421NegUltIteNome[0];
            A420NegUltIteID = TB_NEGOCIO2_A420NegUltIteID[0];
            n420NegUltIteID = TB_NEGOCIO2_n420NegUltIteID[0];
            A386NegUltFase = TB_NEGOCIO2_A386NegUltFase[0];
            A385NegValorAtualizado = TB_NEGOCIO2_A385NegValorAtualizado[0];
            A380NegValorEstimado = TB_NEGOCIO2_A380NegValorEstimado[0];
            A369NegCpjEndSeq = TB_NEGOCIO2_A369NegCpjEndSeq[0];
            A364NegInsUsuNome = TB_NEGOCIO2_A364NegInsUsuNome[0];
            n364NegInsUsuNome = TB_NEGOCIO2_n364NegInsUsuNome[0];
            A363NegDescricao = TB_NEGOCIO2_A363NegDescricao[0];
            A362NegAssunto = TB_NEGOCIO2_A362NegAssunto[0];
            A361NegAgcNome = TB_NEGOCIO2_A361NegAgcNome[0];
            n361NegAgcNome = TB_NEGOCIO2_n361NegAgcNome[0];
            A360NegAgcID = TB_NEGOCIO2_A360NegAgcID[0];
            n360NegAgcID = TB_NEGOCIO2_n360NegAgcID[0];
            A356NegCodigo = TB_NEGOCIO2_A356NegCodigo[0];
            A352NegCpjID = TB_NEGOCIO2_A352NegCpjID[0];
            A350NegCliID = TB_NEGOCIO2_A350NegCliID[0];
            A349NegInsUsuID = TB_NEGOCIO2_A349NegInsUsuID[0];
            n349NegInsUsuID = TB_NEGOCIO2_n349NegInsUsuID[0];
            A348NegInsDataHora = TB_NEGOCIO2_A348NegInsDataHora[0];
            A347NegInsHora = TB_NEGOCIO2_A347NegInsHora[0];
            A346NegInsData = TB_NEGOCIO2_A346NegInsData[0];
            A345NegID = TB_NEGOCIO2_A345NegID[0];
            /*
               INSERT RECORD ON TABLE GXA0037

            */
            AV2NegID = A345NegID;
            AV3NegInsData = A346NegInsData;
            AV4NegInsHora = A347NegInsHora;
            AV5NegInsDataHora = A348NegInsDataHora;
            if ( TB_NEGOCIO2_n349NegInsUsuID[0] )
            {
               AV6NegInsUsuID = "";
               nV6NegInsUsuID = false;
               nV6NegInsUsuID = true;
            }
            else
            {
               AV6NegInsUsuID = A349NegInsUsuID;
               nV6NegInsUsuID = false;
            }
            AV7NegCliID = A350NegCliID;
            AV8NegCpjID = A352NegCpjID;
            AV9NegCodigo = A356NegCodigo;
            if ( TB_NEGOCIO2_n360NegAgcID[0] )
            {
               AV10NegAgcID = "";
               nV10NegAgcID = false;
               nV10NegAgcID = true;
            }
            else
            {
               AV10NegAgcID = A360NegAgcID;
               nV10NegAgcID = false;
            }
            if ( TB_NEGOCIO2_n361NegAgcNome[0] )
            {
               AV11NegAgcNome = "";
               nV11NegAgcNome = false;
               nV11NegAgcNome = true;
            }
            else
            {
               AV11NegAgcNome = A361NegAgcNome;
               nV11NegAgcNome = false;
            }
            AV12NegAssunto = A362NegAssunto;
            AV13NegDescricao = A363NegDescricao;
            if ( TB_NEGOCIO2_n364NegInsUsuNome[0] )
            {
               AV14NegInsUsuNome = "";
               nV14NegInsUsuNome = false;
               nV14NegInsUsuNome = true;
            }
            else
            {
               AV14NegInsUsuNome = A364NegInsUsuNome;
               nV14NegInsUsuNome = false;
            }
            AV15NegCpjEndSeq = A369NegCpjEndSeq;
            AV16NegValorEstimado = A380NegValorEstimado;
            AV17NegValorAtualizado = A385NegValorAtualizado;
            AV18NegUltFase = A386NegUltFase;
            if ( TB_NEGOCIO2_n420NegUltIteID[0] )
            {
               AV19NegUltIteID = Guid.Empty;
            }
            else
            {
               AV19NegUltIteID = A420NegUltIteID;
            }
            if ( TB_NEGOCIO2_n421NegUltIteNome[0] )
            {
               AV20NegUltIteNome = " ";
            }
            else
            {
               AV20NegUltIteNome = A421NegUltIteNome;
            }
            /* Using cursor TB_NEGOCIO3 */
            pr_default.execute(1, new Object[] {AV2NegID, AV3NegInsData, AV4NegInsHora, AV5NegInsDataHora, nV6NegInsUsuID, AV6NegInsUsuID, AV7NegCliID, AV8NegCpjID, AV9NegCodigo, nV10NegAgcID, AV10NegAgcID, nV11NegAgcNome, AV11NegAgcNome, AV12NegAssunto, AV13NegDescricao, nV14NegInsUsuNome, AV14NegInsUsuNome, AV15NegCpjEndSeq, AV16NegValorEstimado, AV17NegValorAtualizado, AV18NegUltFase, AV19NegUltIteID, AV20NegUltIteNome});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("GXA0037");
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
         TB_NEGOCIO2_A421NegUltIteNome = new string[] {""} ;
         TB_NEGOCIO2_n421NegUltIteNome = new bool[] {false} ;
         TB_NEGOCIO2_A420NegUltIteID = new Guid[] {Guid.Empty} ;
         TB_NEGOCIO2_n420NegUltIteID = new bool[] {false} ;
         TB_NEGOCIO2_A386NegUltFase = new int[1] ;
         TB_NEGOCIO2_A385NegValorAtualizado = new decimal[1] ;
         TB_NEGOCIO2_A380NegValorEstimado = new decimal[1] ;
         TB_NEGOCIO2_A369NegCpjEndSeq = new short[1] ;
         TB_NEGOCIO2_A364NegInsUsuNome = new string[] {""} ;
         TB_NEGOCIO2_n364NegInsUsuNome = new bool[] {false} ;
         TB_NEGOCIO2_A363NegDescricao = new string[] {""} ;
         TB_NEGOCIO2_A362NegAssunto = new string[] {""} ;
         TB_NEGOCIO2_A361NegAgcNome = new string[] {""} ;
         TB_NEGOCIO2_n361NegAgcNome = new bool[] {false} ;
         TB_NEGOCIO2_A360NegAgcID = new string[] {""} ;
         TB_NEGOCIO2_n360NegAgcID = new bool[] {false} ;
         TB_NEGOCIO2_A356NegCodigo = new long[1] ;
         TB_NEGOCIO2_A352NegCpjID = new Guid[] {Guid.Empty} ;
         TB_NEGOCIO2_A350NegCliID = new Guid[] {Guid.Empty} ;
         TB_NEGOCIO2_A349NegInsUsuID = new string[] {""} ;
         TB_NEGOCIO2_n349NegInsUsuID = new bool[] {false} ;
         TB_NEGOCIO2_A348NegInsDataHora = new DateTime[] {DateTime.MinValue} ;
         TB_NEGOCIO2_A347NegInsHora = new DateTime[] {DateTime.MinValue} ;
         TB_NEGOCIO2_A346NegInsData = new DateTime[] {DateTime.MinValue} ;
         TB_NEGOCIO2_A345NegID = new Guid[] {Guid.Empty} ;
         A421NegUltIteNome = "";
         A420NegUltIteID = Guid.Empty;
         A364NegInsUsuNome = "";
         A363NegDescricao = "";
         A362NegAssunto = "";
         A361NegAgcNome = "";
         A360NegAgcID = "";
         A352NegCpjID = Guid.Empty;
         A350NegCliID = Guid.Empty;
         A349NegInsUsuID = "";
         A348NegInsDataHora = (DateTime)(DateTime.MinValue);
         A347NegInsHora = (DateTime)(DateTime.MinValue);
         A346NegInsData = DateTime.MinValue;
         A345NegID = Guid.Empty;
         AV2NegID = Guid.Empty;
         AV3NegInsData = DateTime.MinValue;
         AV4NegInsHora = (DateTime)(DateTime.MinValue);
         AV5NegInsDataHora = (DateTime)(DateTime.MinValue);
         AV6NegInsUsuID = "";
         AV7NegCliID = Guid.Empty;
         AV8NegCpjID = Guid.Empty;
         AV10NegAgcID = "";
         AV11NegAgcNome = "";
         AV12NegAssunto = "";
         AV13NegDescricao = "";
         AV14NegInsUsuNome = "";
         AV19NegUltIteID = Guid.Empty;
         AV20NegUltIteNome = "";
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tb_negociopjconversion__default(),
            new Object[][] {
                new Object[] {
               TB_NEGOCIO2_A421NegUltIteNome, TB_NEGOCIO2_n421NegUltIteNome, TB_NEGOCIO2_A420NegUltIteID, TB_NEGOCIO2_n420NegUltIteID, TB_NEGOCIO2_A386NegUltFase, TB_NEGOCIO2_A385NegValorAtualizado, TB_NEGOCIO2_A380NegValorEstimado, TB_NEGOCIO2_A369NegCpjEndSeq, TB_NEGOCIO2_A364NegInsUsuNome, TB_NEGOCIO2_n364NegInsUsuNome,
               TB_NEGOCIO2_A363NegDescricao, TB_NEGOCIO2_A362NegAssunto, TB_NEGOCIO2_A361NegAgcNome, TB_NEGOCIO2_n361NegAgcNome, TB_NEGOCIO2_A360NegAgcID, TB_NEGOCIO2_n360NegAgcID, TB_NEGOCIO2_A356NegCodigo, TB_NEGOCIO2_A352NegCpjID, TB_NEGOCIO2_A350NegCliID, TB_NEGOCIO2_A349NegInsUsuID,
               TB_NEGOCIO2_n349NegInsUsuID, TB_NEGOCIO2_A348NegInsDataHora, TB_NEGOCIO2_A347NegInsHora, TB_NEGOCIO2_A346NegInsData, TB_NEGOCIO2_A345NegID
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A369NegCpjEndSeq ;
      private short AV15NegCpjEndSeq ;
      private int A386NegUltFase ;
      private int GIGXA0037 ;
      private int AV18NegUltFase ;
      private long A356NegCodigo ;
      private long AV9NegCodigo ;
      private decimal A385NegValorAtualizado ;
      private decimal A380NegValorEstimado ;
      private decimal AV16NegValorEstimado ;
      private decimal AV17NegValorAtualizado ;
      private string scmdbuf ;
      private string A360NegAgcID ;
      private string A349NegInsUsuID ;
      private string AV6NegInsUsuID ;
      private string AV10NegAgcID ;
      private string Gx_emsg ;
      private DateTime A348NegInsDataHora ;
      private DateTime A347NegInsHora ;
      private DateTime AV4NegInsHora ;
      private DateTime AV5NegInsDataHora ;
      private DateTime A346NegInsData ;
      private DateTime AV3NegInsData ;
      private bool n421NegUltIteNome ;
      private bool n420NegUltIteID ;
      private bool n364NegInsUsuNome ;
      private bool n361NegAgcNome ;
      private bool n360NegAgcID ;
      private bool n349NegInsUsuID ;
      private bool nV6NegInsUsuID ;
      private bool nV10NegAgcID ;
      private bool nV11NegAgcNome ;
      private bool nV14NegInsUsuNome ;
      private string A363NegDescricao ;
      private string AV13NegDescricao ;
      private string A421NegUltIteNome ;
      private string A364NegInsUsuNome ;
      private string A362NegAssunto ;
      private string A361NegAgcNome ;
      private string AV11NegAgcNome ;
      private string AV12NegAssunto ;
      private string AV14NegInsUsuNome ;
      private string AV20NegUltIteNome ;
      private Guid A420NegUltIteID ;
      private Guid A352NegCpjID ;
      private Guid A350NegCliID ;
      private Guid A345NegID ;
      private Guid AV2NegID ;
      private Guid AV7NegCliID ;
      private Guid AV8NegCpjID ;
      private Guid AV19NegUltIteID ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] TB_NEGOCIO2_A421NegUltIteNome ;
      private bool[] TB_NEGOCIO2_n421NegUltIteNome ;
      private Guid[] TB_NEGOCIO2_A420NegUltIteID ;
      private bool[] TB_NEGOCIO2_n420NegUltIteID ;
      private int[] TB_NEGOCIO2_A386NegUltFase ;
      private decimal[] TB_NEGOCIO2_A385NegValorAtualizado ;
      private decimal[] TB_NEGOCIO2_A380NegValorEstimado ;
      private short[] TB_NEGOCIO2_A369NegCpjEndSeq ;
      private string[] TB_NEGOCIO2_A364NegInsUsuNome ;
      private bool[] TB_NEGOCIO2_n364NegInsUsuNome ;
      private string[] TB_NEGOCIO2_A363NegDescricao ;
      private string[] TB_NEGOCIO2_A362NegAssunto ;
      private string[] TB_NEGOCIO2_A361NegAgcNome ;
      private bool[] TB_NEGOCIO2_n361NegAgcNome ;
      private string[] TB_NEGOCIO2_A360NegAgcID ;
      private bool[] TB_NEGOCIO2_n360NegAgcID ;
      private long[] TB_NEGOCIO2_A356NegCodigo ;
      private Guid[] TB_NEGOCIO2_A352NegCpjID ;
      private Guid[] TB_NEGOCIO2_A350NegCliID ;
      private string[] TB_NEGOCIO2_A349NegInsUsuID ;
      private bool[] TB_NEGOCIO2_n349NegInsUsuID ;
      private DateTime[] TB_NEGOCIO2_A348NegInsDataHora ;
      private DateTime[] TB_NEGOCIO2_A347NegInsHora ;
      private DateTime[] TB_NEGOCIO2_A346NegInsData ;
      private Guid[] TB_NEGOCIO2_A345NegID ;
   }

   public class tb_negociopjconversion__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmTB_NEGOCIO2;
          prmTB_NEGOCIO2 = new Object[] {
          };
          Object[] prmTB_NEGOCIO3;
          prmTB_NEGOCIO3 = new Object[] {
          new ParDef("AV2NegID",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV3NegInsData",GXType.Date,8,0) ,
          new ParDef("AV4NegInsHora",GXType.DateTime,0,5) ,
          new ParDef("AV5NegInsDataHora",GXType.DateTime2,10,12) ,
          new ParDef("AV6NegInsUsuID",GXType.Char,40,0){Nullable=true} ,
          new ParDef("AV7NegCliID",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV8NegCpjID",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV9NegCodigo",GXType.Int64,12,0) ,
          new ParDef("AV10NegAgcID",GXType.Char,40,0){Nullable=true} ,
          new ParDef("AV11NegAgcNome",GXType.VarChar,80,0){Nullable=true} ,
          new ParDef("AV12NegAssunto",GXType.VarChar,80,0) ,
          new ParDef("AV13NegDescricao",GXType.LongVarChar,2097152,0) ,
          new ParDef("AV14NegInsUsuNome",GXType.VarChar,80,0){Nullable=true} ,
          new ParDef("AV15NegCpjEndSeq",GXType.Int16,4,0) ,
          new ParDef("AV16NegValorEstimado",GXType.Number,16,2) ,
          new ParDef("AV17NegValorAtualizado",GXType.Number,16,2) ,
          new ParDef("AV18NegUltFase",GXType.Int32,8,0) ,
          new ParDef("AV19NegUltIteID",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV20NegUltIteNome",GXType.VarChar,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("TB_NEGOCIO2", "SELECT NegUltIteNome, NegUltIteID, NegUltFase, NegValorAtualizado, NegValorEstimado, NegCpjEndSeq, NegInsUsuNome, NegDescricao, NegAssunto, NegAgcNome, NegAgcID, NegCodigo, NegCpjID, NegCliID, NegInsUsuID, NegInsDataHora, NegInsHora, NegInsData, NegID FROM tb_negociopj ORDER BY NegID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmTB_NEGOCIO2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("TB_NEGOCIO3", "INSERT INTO GXA0037(NegID, NegInsData, NegInsHora, NegInsDataHora, NegInsUsuID, NegCliID, NegCpjID, NegCodigo, NegAgcID, NegAgcNome, NegAssunto, NegDescricao, NegInsUsuNome, NegCpjEndSeq, NegValorEstimado, NegValorAtualizado, NegUltFase, NegUltIteID, NegUltIteNome) VALUES(:AV2NegID, :AV3NegInsData, :AV4NegInsHora, :AV5NegInsDataHora, :AV6NegInsUsuID, :AV7NegCliID, :AV8NegCpjID, :AV9NegCodigo, :AV10NegAgcID, :AV11NegAgcNome, :AV12NegAssunto, :AV13NegDescricao, :AV14NegInsUsuNome, :AV15NegCpjEndSeq, :AV16NegValorEstimado, :AV17NegValorAtualizado, :AV18NegUltFase, :AV19NegUltIteID, :AV20NegUltIteNome)", GxErrorMask.GX_NOMASK,prmTB_NEGOCIO3)
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
                ((Guid[]) buf[2])[0] = rslt.getGuid(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(4);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(5);
                ((short[]) buf[7])[0] = rslt.getShort(6);
                ((string[]) buf[8])[0] = rslt.getVarchar(7);
                ((bool[]) buf[9])[0] = rslt.wasNull(7);
                ((string[]) buf[10])[0] = rslt.getLongVarchar(8);
                ((string[]) buf[11])[0] = rslt.getVarchar(9);
                ((string[]) buf[12])[0] = rslt.getVarchar(10);
                ((bool[]) buf[13])[0] = rslt.wasNull(10);
                ((string[]) buf[14])[0] = rslt.getString(11, 40);
                ((bool[]) buf[15])[0] = rslt.wasNull(11);
                ((long[]) buf[16])[0] = rslt.getLong(12);
                ((Guid[]) buf[17])[0] = rslt.getGuid(13);
                ((Guid[]) buf[18])[0] = rslt.getGuid(14);
                ((string[]) buf[19])[0] = rslt.getString(15, 40);
                ((bool[]) buf[20])[0] = rslt.wasNull(15);
                ((DateTime[]) buf[21])[0] = rslt.getGXDateTime(16, true);
                ((DateTime[]) buf[22])[0] = rslt.getGXDateTime(17);
                ((DateTime[]) buf[23])[0] = rslt.getGXDate(18);
                ((Guid[]) buf[24])[0] = rslt.getGuid(19);
                return;
       }
    }

 }

}
