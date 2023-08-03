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
   public class tb_negociopjloadredundancy : GXProcedure
   {
      public tb_negociopjloadredundancy( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", false);
      }

      public tb_negociopjloadredundancy( IGxContext context )
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
         tb_negociopjloadredundancy objtb_negociopjloadredundancy;
         objtb_negociopjloadredundancy = new tb_negociopjloadredundancy();
         objtb_negociopjloadredundancy.context.SetSubmitInitialConfig(context);
         objtb_negociopjloadredundancy.initialize();
         Submit( executePrivateCatch,objtb_negociopjloadredundancy);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((tb_negociopjloadredundancy)stateInfo).executePrivate();
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
         /* Using cursor TB_NEGOCIO9 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A350NegCliID = TB_NEGOCIO9_A350NegCliID[0];
            A352NegCpjID = TB_NEGOCIO9_A352NegCpjID[0];
            A357NegPjtID = TB_NEGOCIO9_A357NegPjtID[0];
            A345NegID = TB_NEGOCIO9_A345NegID[0];
            A359NegPjtNome = TB_NEGOCIO9_A359NegPjtNome[0];
            A359NegPjtNome = TB_NEGOCIO9_A359NegPjtNome[0];
            A354NegCpjRazSocial = TB_NEGOCIO9_A354NegCpjRazSocial[0];
            A354NegCpjRazSocial = TB_NEGOCIO9_A354NegCpjRazSocial[0];
            A353NegCpjNomFan = TB_NEGOCIO9_A353NegCpjNomFan[0];
            A353NegCpjNomFan = TB_NEGOCIO9_A353NegCpjNomFan[0];
            A351NegCliNomeFamiliar = TB_NEGOCIO9_A351NegCliNomeFamiliar[0];
            A351NegCliNomeFamiliar = TB_NEGOCIO9_A351NegCliNomeFamiliar[0];
            A420NegUltIteID = TB_NEGOCIO9_A420NegUltIteID[0];
            A421NegUltIteNome = TB_NEGOCIO9_A421NegUltIteNome[0];
            A474NegUltNgfSeq = TB_NEGOCIO9_A474NegUltNgfSeq[0];
            A479NegUltIteOrdem = TB_NEGOCIO9_A479NegUltIteOrdem[0];
            A40000GXC1 = TB_NEGOCIO9_A40000GXC1[0];
            n40000GXC1 = TB_NEGOCIO9_n40000GXC1[0];
            A40001GXC2 = TB_NEGOCIO9_A40001GXC2[0];
            n40001GXC2 = TB_NEGOCIO9_n40001GXC2[0];
            A40002GXC3 = TB_NEGOCIO9_A40002GXC3[0];
            n40002GXC3 = TB_NEGOCIO9_n40002GXC3[0];
            A40003GXC4 = TB_NEGOCIO9_A40003GXC4[0];
            n40003GXC4 = TB_NEGOCIO9_n40003GXC4[0];
            O359NegPjtNome = A359NegPjtNome;
            O354NegCpjRazSocial = A354NegCpjRazSocial;
            O353NegCpjNomFan = A353NegCpjNomFan;
            O351NegCliNomeFamiliar = A351NegCliNomeFamiliar;
            A351NegCliNomeFamiliar = TB_NEGOCIO9_A351NegCliNomeFamiliar[0];
            O351NegCliNomeFamiliar = A351NegCliNomeFamiliar;
            A357NegPjtID = TB_NEGOCIO9_A357NegPjtID[0];
            A354NegCpjRazSocial = TB_NEGOCIO9_A354NegCpjRazSocial[0];
            A353NegCpjNomFan = TB_NEGOCIO9_A353NegCpjNomFan[0];
            O354NegCpjRazSocial = A354NegCpjRazSocial;
            O353NegCpjNomFan = A353NegCpjNomFan;
            A359NegPjtNome = TB_NEGOCIO9_A359NegPjtNome[0];
            O359NegPjtNome = A359NegPjtNome;
            A40000GXC1 = TB_NEGOCIO9_A40000GXC1[0];
            n40000GXC1 = TB_NEGOCIO9_n40000GXC1[0];
            A40001GXC2 = TB_NEGOCIO9_A40001GXC2[0];
            n40001GXC2 = TB_NEGOCIO9_n40001GXC2[0];
            A40002GXC3 = TB_NEGOCIO9_A40002GXC3[0];
            n40002GXC3 = TB_NEGOCIO9_n40002GXC3[0];
            A40003GXC4 = TB_NEGOCIO9_A40003GXC4[0];
            n40003GXC4 = TB_NEGOCIO9_n40003GXC4[0];
            A359NegPjtNome = O359NegPjtNome;
            A354NegCpjRazSocial = O354NegCpjRazSocial;
            A353NegCpjNomFan = O353NegCpjNomFan;
            A351NegCliNomeFamiliar = O351NegCliNomeFamiliar;
            O359NegPjtNome = A359NegPjtNome;
            O354NegCpjRazSocial = A354NegCpjRazSocial;
            O353NegCpjNomFan = A353NegCpjNomFan;
            O351NegCliNomeFamiliar = A351NegCliNomeFamiliar;
            /* Using cursor TB_NEGOCIO10 */
            pr_default.execute(1, new Object[] {A345NegID});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A396NgfIteOrdem = TB_NEGOCIO10_A396NgfIteOrdem[0];
               A397NgfIteNome = TB_NEGOCIO10_A397NgfIteNome[0];
               A387NgfSeq = TB_NEGOCIO10_A387NgfSeq[0];
               A395NgfIteID = TB_NEGOCIO10_A395NgfIteID[0];
               A396NgfIteOrdem = TB_NEGOCIO10_A396NgfIteOrdem[0];
               O479NegUltIteOrdem = A479NegUltIteOrdem;
               O474NegUltNgfSeq = A474NegUltNgfSeq;
               O421NegUltIteNome = A421NegUltIteNome;
               O420NegUltIteID = A420NegUltIteID;
               pr_default.readNext(1);
            }
            pr_default.close(1);
            A420NegUltIteID = A40000GXC1;
            A421NegUltIteNome = A40001GXC2;
            A474NegUltNgfSeq = A40002GXC3;
            A479NegUltIteOrdem = (short)(A40003GXC4);
            /* Using cursor TB_NEGOCIO11 */
            pr_default.execute(2, new Object[] {A359NegPjtNome, A354NegCpjRazSocial, A353NegCpjNomFan, A351NegCliNomeFamiliar, A420NegUltIteID, A421NegUltIteNome, A474NegUltNgfSeq, A479NegUltIteOrdem, A345NegID});
            pr_default.close(2);
            pr_default.SmartCacheProvider.SetUpdated("tb_negociopj");
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
         TB_NEGOCIO9_A350NegCliID = new Guid[] {Guid.Empty} ;
         TB_NEGOCIO9_A352NegCpjID = new Guid[] {Guid.Empty} ;
         TB_NEGOCIO9_A357NegPjtID = new int[1] ;
         TB_NEGOCIO9_A345NegID = new Guid[] {Guid.Empty} ;
         TB_NEGOCIO9_A359NegPjtNome = new string[] {""} ;
         TB_NEGOCIO9_A354NegCpjRazSocial = new string[] {""} ;
         TB_NEGOCIO9_A353NegCpjNomFan = new string[] {""} ;
         TB_NEGOCIO9_A351NegCliNomeFamiliar = new string[] {""} ;
         TB_NEGOCIO9_A420NegUltIteID = new Guid[] {Guid.Empty} ;
         TB_NEGOCIO9_A421NegUltIteNome = new string[] {""} ;
         TB_NEGOCIO9_A474NegUltNgfSeq = new int[1] ;
         TB_NEGOCIO9_A479NegUltIteOrdem = new short[1] ;
         TB_NEGOCIO9_A40000GXC1 = new Guid[] {Guid.Empty} ;
         TB_NEGOCIO9_n40000GXC1 = new bool[] {false} ;
         TB_NEGOCIO9_A40001GXC2 = new string[] {""} ;
         TB_NEGOCIO9_n40001GXC2 = new bool[] {false} ;
         TB_NEGOCIO9_A40002GXC3 = new int[1] ;
         TB_NEGOCIO9_n40002GXC3 = new bool[] {false} ;
         TB_NEGOCIO9_A40003GXC4 = new int[1] ;
         TB_NEGOCIO9_n40003GXC4 = new bool[] {false} ;
         A350NegCliID = Guid.Empty;
         A352NegCpjID = Guid.Empty;
         A345NegID = Guid.Empty;
         A359NegPjtNome = "";
         A354NegCpjRazSocial = "";
         A353NegCpjNomFan = "";
         A351NegCliNomeFamiliar = "";
         A420NegUltIteID = Guid.Empty;
         A421NegUltIteNome = "";
         A40000GXC1 = Guid.Empty;
         A40001GXC2 = "";
         O359NegPjtNome = "";
         O354NegCpjRazSocial = "";
         O353NegCpjNomFan = "";
         O351NegCliNomeFamiliar = "";
         TB_NEGOCIO10_A345NegID = new Guid[] {Guid.Empty} ;
         TB_NEGOCIO10_A396NgfIteOrdem = new int[1] ;
         TB_NEGOCIO10_A397NgfIteNome = new string[] {""} ;
         TB_NEGOCIO10_A387NgfSeq = new int[1] ;
         TB_NEGOCIO10_A395NgfIteID = new Guid[] {Guid.Empty} ;
         A397NgfIteNome = "";
         A395NgfIteID = Guid.Empty;
         O421NegUltIteNome = "";
         O420NegUltIteID = Guid.Empty;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tb_negociopjloadredundancy__default(),
            new Object[][] {
                new Object[] {
               TB_NEGOCIO9_A350NegCliID, TB_NEGOCIO9_A352NegCpjID, TB_NEGOCIO9_A357NegPjtID, TB_NEGOCIO9_A345NegID, TB_NEGOCIO9_A359NegPjtNome, TB_NEGOCIO9_A359NegPjtNome, TB_NEGOCIO9_A354NegCpjRazSocial, TB_NEGOCIO9_A354NegCpjRazSocial, TB_NEGOCIO9_A353NegCpjNomFan, TB_NEGOCIO9_A353NegCpjNomFan,
               TB_NEGOCIO9_A351NegCliNomeFamiliar, TB_NEGOCIO9_A351NegCliNomeFamiliar, TB_NEGOCIO9_A420NegUltIteID, TB_NEGOCIO9_A421NegUltIteNome, TB_NEGOCIO9_A474NegUltNgfSeq, TB_NEGOCIO9_A479NegUltIteOrdem, TB_NEGOCIO9_A40000GXC1, TB_NEGOCIO9_n40000GXC1, TB_NEGOCIO9_A40001GXC2, TB_NEGOCIO9_n40001GXC2,
               TB_NEGOCIO9_A40002GXC3, TB_NEGOCIO9_n40002GXC3, TB_NEGOCIO9_A40003GXC4, TB_NEGOCIO9_n40003GXC4
               }
               , new Object[] {
               TB_NEGOCIO10_A345NegID, TB_NEGOCIO10_A396NgfIteOrdem, TB_NEGOCIO10_A397NgfIteNome, TB_NEGOCIO10_A387NgfSeq, TB_NEGOCIO10_A395NgfIteID
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A479NegUltIteOrdem ;
      private short O479NegUltIteOrdem ;
      private int A357NegPjtID ;
      private int A474NegUltNgfSeq ;
      private int A40002GXC3 ;
      private int A40003GXC4 ;
      private int A396NgfIteOrdem ;
      private int A387NgfSeq ;
      private int O474NegUltNgfSeq ;
      private string scmdbuf ;
      private bool n40000GXC1 ;
      private bool n40001GXC2 ;
      private bool n40002GXC3 ;
      private bool n40003GXC4 ;
      private string A359NegPjtNome ;
      private string A354NegCpjRazSocial ;
      private string A353NegCpjNomFan ;
      private string A351NegCliNomeFamiliar ;
      private string A421NegUltIteNome ;
      private string A40001GXC2 ;
      private string O359NegPjtNome ;
      private string O354NegCpjRazSocial ;
      private string O353NegCpjNomFan ;
      private string O351NegCliNomeFamiliar ;
      private string A397NgfIteNome ;
      private string O421NegUltIteNome ;
      private Guid A350NegCliID ;
      private Guid A352NegCpjID ;
      private Guid A345NegID ;
      private Guid A420NegUltIteID ;
      private Guid A40000GXC1 ;
      private Guid A395NgfIteID ;
      private Guid O420NegUltIteID ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] TB_NEGOCIO9_A350NegCliID ;
      private Guid[] TB_NEGOCIO9_A352NegCpjID ;
      private int[] TB_NEGOCIO9_A357NegPjtID ;
      private Guid[] TB_NEGOCIO9_A345NegID ;
      private string[] TB_NEGOCIO9_A359NegPjtNome ;
      private string[] TB_NEGOCIO9_A354NegCpjRazSocial ;
      private string[] TB_NEGOCIO9_A353NegCpjNomFan ;
      private string[] TB_NEGOCIO9_A351NegCliNomeFamiliar ;
      private Guid[] TB_NEGOCIO9_A420NegUltIteID ;
      private string[] TB_NEGOCIO9_A421NegUltIteNome ;
      private int[] TB_NEGOCIO9_A474NegUltNgfSeq ;
      private short[] TB_NEGOCIO9_A479NegUltIteOrdem ;
      private Guid[] TB_NEGOCIO9_A40000GXC1 ;
      private bool[] TB_NEGOCIO9_n40000GXC1 ;
      private string[] TB_NEGOCIO9_A40001GXC2 ;
      private bool[] TB_NEGOCIO9_n40001GXC2 ;
      private int[] TB_NEGOCIO9_A40002GXC3 ;
      private bool[] TB_NEGOCIO9_n40002GXC3 ;
      private int[] TB_NEGOCIO9_A40003GXC4 ;
      private bool[] TB_NEGOCIO9_n40003GXC4 ;
      private Guid[] TB_NEGOCIO10_A345NegID ;
      private int[] TB_NEGOCIO10_A396NgfIteOrdem ;
      private string[] TB_NEGOCIO10_A397NgfIteNome ;
      private int[] TB_NEGOCIO10_A387NgfSeq ;
      private Guid[] TB_NEGOCIO10_A395NgfIteID ;
   }

   public class tb_negociopjloadredundancy__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmTB_NEGOCIO9;
          prmTB_NEGOCIO9 = new Object[] {
          };
          string cmdBufferTB_NEGOCIO9;
          cmdBufferTB_NEGOCIO9=" SELECT T1.NegCliID AS NegCliID, T1.NegCpjID AS NegCpjID, T3.CpjTipoId AS NegPjtID, T1.NegID, T1.NegPjtNome AS NegPjtNome, T4.PjtNome AS NegPjtNome, T1.NegCpjRazSocial AS NegCpjRazSocial, T3.CpjRazaoSoc AS NegCpjRazSocial, T1.NegCpjNomFan AS NegCpjNomFan, T3.CpjNomeFan AS NegCpjNomFan, T1.NegCliNomeFamiliar AS NegCliNomeFamiliar, T2.CliNomeFamiliar AS NegCliNomeFamiliar, T1.NegUltIteID, T1.NegUltIteNome, T1.NegUltNgfSeq, T1.NegUltIteOrdem, COALESCE( T5.GXC1, '00000000-0000-0000-0000-000000000000') AS GXC1, COALESCE( T6.GXC2, '') AS GXC2, COALESCE( T7.GXC3, 0) AS GXC3, COALESCE( T8.GXC4, 0) AS GXC4 FROM (((((((tb_negociopj T1 INNER JOIN tb_cliente T2 ON T2.CliID = T1.NegCliID) INNER JOIN tb_clientepj T3 ON T3.CliID = T1.NegCliID AND T3.CpjID = T1.NegCpjID) INNER JOIN tb_clientepjtipo T4 ON T4.PjtID = T3.CpjTipoId) LEFT JOIN LATERAL (SELECT MIN(T9.NgfIteID) AS GXC1, T9.NegID FROM (tb_negociopj_fase T9 INNER JOIN (SELECT MAX(NgfSeq) AS GXC5, NegID FROM tb_negociopj_fase GROUP BY NegID ) T10 ON T10.NegID = T9.NegID) WHERE (T1.NegID = T9.NegID) AND (T9.NgfSeq = T10.GXC5) GROUP BY T9.NegID ) T5 ON T5.NegID = T1.NegID) LEFT JOIN LATERAL (SELECT MIN(T9.NgfIteNome) AS GXC2, T9.NegID FROM (tb_negociopj_fase T9 INNER JOIN (SELECT MAX(NgfSeq) AS GXC6, NegID FROM tb_negociopj_fase GROUP BY NegID ) T10 ON T10.NegID = T9.NegID) WHERE (T1.NegID = T9.NegID) AND (T9.NgfSeq = T10.GXC6) GROUP BY T9.NegID ) T6 ON T6.NegID = T1.NegID) LEFT JOIN LATERAL (SELECT MAX(NgfSeq) AS GXC3, NegID FROM tb_negociopj_fase WHERE T1.NegID = NegID GROUP BY NegID ) T7 ON T7.NegID = T1.NegID) LEFT JOIN LATERAL (SELECT MIN(T11.IteOrdem) AS GXC4, T9.NegID FROM ((tb_negociopj_fase T9 INNER JOIN (SELECT MAX(T12.NgfSeq) AS GXC3, T12.NegID FROM (tb_negociopj_fase T12 INNER JOIN tb_Iteracao T13 ON T13.IteID = T12.NgfIteID) "
          + " GROUP BY T12.NegID ) T10 ON T10.NegID = T9.NegID) INNER JOIN tb_Iteracao T11 ON T11.IteID = T9.NgfIteID) WHERE (T1.NegID = T9.NegID) AND (T9.NgfSeq = T10.GXC3) GROUP BY T9.NegID ) T8 ON T8.NegID = T1.NegID) ORDER BY T1.NegID  FOR UPDATE OF T1, T1, T1, T1, T1, T1, T1, T1" ;
          Object[] prmTB_NEGOCIO10;
          prmTB_NEGOCIO10 = new Object[] {
          new ParDef("NegID",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmTB_NEGOCIO11;
          prmTB_NEGOCIO11 = new Object[] {
          new ParDef("NegPjtNome",GXType.VarChar,80,0) ,
          new ParDef("NegCpjRazSocial",GXType.VarChar,80,0) ,
          new ParDef("NegCpjNomFan",GXType.VarChar,80,0) ,
          new ParDef("NegCliNomeFamiliar",GXType.VarChar,80,0) ,
          new ParDef("NegUltIteID",GXType.UniqueIdentifier,36,0) ,
          new ParDef("NegUltIteNome",GXType.VarChar,80,0) ,
          new ParDef("NegUltNgfSeq",GXType.Int32,8,0) ,
          new ParDef("NegUltIteOrdem",GXType.Int16,4,0) ,
          new ParDef("NegID",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("TB_NEGOCIO9", cmdBufferTB_NEGOCIO9,true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmTB_NEGOCIO9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("TB_NEGOCIO10", "SELECT T1.NegID, T2.IteOrdem AS NgfIteOrdem, T1.NgfIteNome AS NgfIteNome, T1.NgfSeq, T1.NgfIteID AS NgfIteID FROM (tb_negociopj_fase T1 INNER JOIN tb_Iteracao T2 ON T2.IteID = T1.NgfIteID) WHERE T1.NegID = :NegID ORDER BY T1.NegID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmTB_NEGOCIO10,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("TB_NEGOCIO11", "UPDATE tb_negociopj SET NegPjtNome=:NegPjtNome, NegCpjRazSocial=:NegCpjRazSocial, NegCpjNomFan=:NegCpjNomFan, NegCliNomeFamiliar=:NegCliNomeFamiliar, NegUltIteID=:NegUltIteID, NegUltIteNome=:NegUltIteNome, NegUltNgfSeq=:NegUltNgfSeq, NegUltIteOrdem=:NegUltIteOrdem  WHERE NegID = :NegID", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmTB_NEGOCIO11)
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
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((Guid[]) buf[3])[0] = rslt.getGuid(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((string[]) buf[10])[0] = rslt.getVarchar(11);
                ((string[]) buf[11])[0] = rslt.getVarchar(12);
                ((Guid[]) buf[12])[0] = rslt.getGuid(13);
                ((string[]) buf[13])[0] = rslt.getVarchar(14);
                ((int[]) buf[14])[0] = rslt.getInt(15);
                ((short[]) buf[15])[0] = rslt.getShort(16);
                ((Guid[]) buf[16])[0] = rslt.getGuid(17);
                ((bool[]) buf[17])[0] = rslt.wasNull(17);
                ((string[]) buf[18])[0] = rslt.getVarchar(18);
                ((bool[]) buf[19])[0] = rslt.wasNull(18);
                ((int[]) buf[20])[0] = rslt.getInt(19);
                ((bool[]) buf[21])[0] = rslt.wasNull(19);
                ((int[]) buf[22])[0] = rslt.getInt(20);
                ((bool[]) buf[23])[0] = rslt.wasNull(20);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((Guid[]) buf[4])[0] = rslt.getGuid(5);
                return;
       }
    }

 }

}
