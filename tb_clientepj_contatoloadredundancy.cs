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
   public class tb_clientepj_contatoloadredundancy : GXProcedure
   {
      public tb_clientepj_contatoloadredundancy( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", false);
      }

      public tb_clientepj_contatoloadredundancy( IGxContext context )
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
         tb_clientepj_contatoloadredundancy objtb_clientepj_contatoloadredundancy;
         objtb_clientepj_contatoloadredundancy = new tb_clientepj_contatoloadredundancy();
         objtb_clientepj_contatoloadredundancy.context.SetSubmitInitialConfig(context);
         objtb_clientepj_contatoloadredundancy.initialize();
         Submit( executePrivateCatch,objtb_clientepj_contatoloadredundancy);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((tb_clientepj_contatoloadredundancy)stateInfo).executePrivate();
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
         /* Using cursor TB_CLIENTE2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A270CpjConTipoID = TB_CLIENTE2_A270CpjConTipoID[0];
            A279CpjConGenID = TB_CLIENTE2_A279CpjConGenID[0];
            A281CpjConGenNome = TB_CLIENTE2_A281CpjConGenNome[0];
            A281CpjConGenNome = TB_CLIENTE2_A281CpjConGenNome[0];
            A280CpjConGenSigla = TB_CLIENTE2_A280CpjConGenSigla[0];
            A280CpjConGenSigla = TB_CLIENTE2_A280CpjConGenSigla[0];
            A272CpjConTipoNome = TB_CLIENTE2_A272CpjConTipoNome[0];
            A272CpjConTipoNome = TB_CLIENTE2_A272CpjConTipoNome[0];
            A271CpjConTipoSigla = TB_CLIENTE2_A271CpjConTipoSigla[0];
            A271CpjConTipoSigla = TB_CLIENTE2_A271CpjConTipoSigla[0];
            A158CliID = TB_CLIENTE2_A158CliID[0];
            A166CpjID = TB_CLIENTE2_A166CpjID[0];
            A269CpjConSeq = TB_CLIENTE2_A269CpjConSeq[0];
            O281CpjConGenNome = A281CpjConGenNome;
            O280CpjConGenSigla = A280CpjConGenSigla;
            O272CpjConTipoNome = A272CpjConTipoNome;
            O271CpjConTipoSigla = A271CpjConTipoSigla;
            A272CpjConTipoNome = TB_CLIENTE2_A272CpjConTipoNome[0];
            A271CpjConTipoSigla = TB_CLIENTE2_A271CpjConTipoSigla[0];
            O272CpjConTipoNome = A272CpjConTipoNome;
            O271CpjConTipoSigla = A271CpjConTipoSigla;
            A281CpjConGenNome = TB_CLIENTE2_A281CpjConGenNome[0];
            A280CpjConGenSigla = TB_CLIENTE2_A280CpjConGenSigla[0];
            O281CpjConGenNome = A281CpjConGenNome;
            O280CpjConGenSigla = A280CpjConGenSigla;
            A281CpjConGenNome = O281CpjConGenNome;
            A280CpjConGenSigla = O280CpjConGenSigla;
            A272CpjConTipoNome = O272CpjConTipoNome;
            A271CpjConTipoSigla = O271CpjConTipoSigla;
            O281CpjConGenNome = A281CpjConGenNome;
            O280CpjConGenSigla = A280CpjConGenSigla;
            O272CpjConTipoNome = A272CpjConTipoNome;
            O271CpjConTipoSigla = A271CpjConTipoSigla;
            /* Using cursor TB_CLIENTE3 */
            pr_default.execute(1, new Object[] {A281CpjConGenNome, A280CpjConGenSigla, A272CpjConTipoNome, A271CpjConTipoSigla, A158CliID, A166CpjID, A269CpjConSeq});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("tb_clientepj_contato");
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
         TB_CLIENTE2_A270CpjConTipoID = new int[1] ;
         TB_CLIENTE2_A279CpjConGenID = new int[1] ;
         TB_CLIENTE2_A281CpjConGenNome = new string[] {""} ;
         TB_CLIENTE2_A280CpjConGenSigla = new string[] {""} ;
         TB_CLIENTE2_A272CpjConTipoNome = new string[] {""} ;
         TB_CLIENTE2_A271CpjConTipoSigla = new string[] {""} ;
         TB_CLIENTE2_A158CliID = new Guid[] {Guid.Empty} ;
         TB_CLIENTE2_A166CpjID = new Guid[] {Guid.Empty} ;
         TB_CLIENTE2_A269CpjConSeq = new short[1] ;
         A281CpjConGenNome = "";
         A280CpjConGenSigla = "";
         A272CpjConTipoNome = "";
         A271CpjConTipoSigla = "";
         A158CliID = Guid.Empty;
         A166CpjID = Guid.Empty;
         O281CpjConGenNome = "";
         O280CpjConGenSigla = "";
         O272CpjConTipoNome = "";
         O271CpjConTipoSigla = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tb_clientepj_contatoloadredundancy__default(),
            new Object[][] {
                new Object[] {
               TB_CLIENTE2_A270CpjConTipoID, TB_CLIENTE2_A279CpjConGenID, TB_CLIENTE2_A281CpjConGenNome, TB_CLIENTE2_A281CpjConGenNome, TB_CLIENTE2_A280CpjConGenSigla, TB_CLIENTE2_A280CpjConGenSigla, TB_CLIENTE2_A272CpjConTipoNome, TB_CLIENTE2_A272CpjConTipoNome, TB_CLIENTE2_A271CpjConTipoSigla, TB_CLIENTE2_A271CpjConTipoSigla,
               TB_CLIENTE2_A158CliID, TB_CLIENTE2_A166CpjID, TB_CLIENTE2_A269CpjConSeq
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A269CpjConSeq ;
      private int A270CpjConTipoID ;
      private int A279CpjConGenID ;
      private string scmdbuf ;
      private string A281CpjConGenNome ;
      private string A280CpjConGenSigla ;
      private string A272CpjConTipoNome ;
      private string A271CpjConTipoSigla ;
      private string O281CpjConGenNome ;
      private string O280CpjConGenSigla ;
      private string O272CpjConTipoNome ;
      private string O271CpjConTipoSigla ;
      private Guid A158CliID ;
      private Guid A166CpjID ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] TB_CLIENTE2_A270CpjConTipoID ;
      private int[] TB_CLIENTE2_A279CpjConGenID ;
      private string[] TB_CLIENTE2_A281CpjConGenNome ;
      private string[] TB_CLIENTE2_A280CpjConGenSigla ;
      private string[] TB_CLIENTE2_A272CpjConTipoNome ;
      private string[] TB_CLIENTE2_A271CpjConTipoSigla ;
      private Guid[] TB_CLIENTE2_A158CliID ;
      private Guid[] TB_CLIENTE2_A166CpjID ;
      private short[] TB_CLIENTE2_A269CpjConSeq ;
   }

   public class tb_clientepj_contatoloadredundancy__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmTB_CLIENTE2;
          prmTB_CLIENTE2 = new Object[] {
          };
          Object[] prmTB_CLIENTE3;
          prmTB_CLIENTE3 = new Object[] {
          new ParDef("CpjConGenNome",GXType.VarChar,80,0) ,
          new ParDef("CpjConGenSigla",GXType.VarChar,20,0) ,
          new ParDef("CpjConTipoNome",GXType.VarChar,80,0) ,
          new ParDef("CpjConTipoSigla",GXType.VarChar,20,0) ,
          new ParDef("CliID",GXType.UniqueIdentifier,36,0) ,
          new ParDef("CpjID",GXType.UniqueIdentifier,36,0) ,
          new ParDef("CpjConSeq",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("TB_CLIENTE2", "SELECT T1.CpjConTipoID AS CpjConTipoID, T1.CpjConGenID AS CpjConGenID, T1.CpjConGenNome AS CpjConGenNome, T3.GenNome AS CpjConGenNome, T1.CpjConGenSigla AS CpjConGenSigla, T3.GenSigla AS CpjConGenSigla, T1.CpjConTipoNome AS CpjConTipoNome, T2.PjtNome AS CpjConTipoNome, T1.CpjConTipoSigla AS CpjConTipoSigla, T2.PjtSigla AS CpjConTipoSigla, T1.CliID, T1.CpjID, T1.CpjConSeq FROM ((tb_clientepj_contato T1 INNER JOIN tb_clientepjtipo T2 ON T2.PjtID = T1.CpjConTipoID) INNER JOIN tb_genero T3 ON T3.GenID = T1.CpjConGenID) ORDER BY T1.CliID, T1.CpjID, T1.CpjConSeq  FOR UPDATE OF T1, T1, T1",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmTB_CLIENTE2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("TB_CLIENTE3", "UPDATE tb_clientepj_contato SET CpjConGenNome=:CpjConGenNome, CpjConGenSigla=:CpjConGenSigla, CpjConTipoNome=:CpjConTipoNome, CpjConTipoSigla=:CpjConTipoSigla  WHERE CliID = :CliID AND CpjID = :CpjID AND CpjConSeq = :CpjConSeq", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmTB_CLIENTE3)
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
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((Guid[]) buf[10])[0] = rslt.getGuid(11);
                ((Guid[]) buf[11])[0] = rslt.getGuid(12);
                ((short[]) buf[12])[0] = rslt.getShort(13);
                return;
       }
    }

 }

}
