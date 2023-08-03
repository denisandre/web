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
   public class tbibge_mesorregiaoloadredundancy : GXProcedure
   {
      public tbibge_mesorregiaoloadredundancy( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", false);
      }

      public tbibge_mesorregiaoloadredundancy( IGxContext context )
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
         tbibge_mesorregiaoloadredundancy objtbibge_mesorregiaoloadredundancy;
         objtbibge_mesorregiaoloadredundancy = new tbibge_mesorregiaoloadredundancy();
         objtbibge_mesorregiaoloadredundancy.context.SetSubmitInitialConfig(context);
         objtbibge_mesorregiaoloadredundancy.initialize();
         Submit( executePrivateCatch,objtbibge_mesorregiaoloadredundancy);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((tbibge_mesorregiaoloadredundancy)stateInfo).executePrivate();
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
         /* Using cursor TBIBGE_MES2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A15MesorregiaoUFID = TBIBGE_MES2_A15MesorregiaoUFID[0];
            A21MesorregiaoUFRegNome = TBIBGE_MES2_A21MesorregiaoUFRegNome[0];
            n21MesorregiaoUFRegNome = TBIBGE_MES2_n21MesorregiaoUFRegNome[0];
            A21MesorregiaoUFRegNome = TBIBGE_MES2_A21MesorregiaoUFRegNome[0];
            n21MesorregiaoUFRegNome = TBIBGE_MES2_n21MesorregiaoUFRegNome[0];
            A20MesorregiaoUFRegSigla = TBIBGE_MES2_A20MesorregiaoUFRegSigla[0];
            n20MesorregiaoUFRegSigla = TBIBGE_MES2_n20MesorregiaoUFRegSigla[0];
            A20MesorregiaoUFRegSigla = TBIBGE_MES2_A20MesorregiaoUFRegSigla[0];
            n20MesorregiaoUFRegSigla = TBIBGE_MES2_n20MesorregiaoUFRegSigla[0];
            A19MesorregiaoUFRegID = TBIBGE_MES2_A19MesorregiaoUFRegID[0];
            A19MesorregiaoUFRegID = TBIBGE_MES2_A19MesorregiaoUFRegID[0];
            A17MesorregiaoUFNome = TBIBGE_MES2_A17MesorregiaoUFNome[0];
            A17MesorregiaoUFNome = TBIBGE_MES2_A17MesorregiaoUFNome[0];
            A16MesorregiaoUFSigla = TBIBGE_MES2_A16MesorregiaoUFSigla[0];
            A16MesorregiaoUFSigla = TBIBGE_MES2_A16MesorregiaoUFSigla[0];
            A18MesorregiaoUFSiglaNome = TBIBGE_MES2_A18MesorregiaoUFSiglaNome[0];
            n18MesorregiaoUFSiglaNome = TBIBGE_MES2_n18MesorregiaoUFSiglaNome[0];
            A22MesorregiaoUFRegSiglaNome = TBIBGE_MES2_A22MesorregiaoUFRegSiglaNome[0];
            n22MesorregiaoUFRegSiglaNome = TBIBGE_MES2_n22MesorregiaoUFRegSiglaNome[0];
            A13MesorregiaoID = TBIBGE_MES2_A13MesorregiaoID[0];
            O21MesorregiaoUFRegNome = A21MesorregiaoUFRegNome;
            n21MesorregiaoUFRegNome = false;
            O20MesorregiaoUFRegSigla = A20MesorregiaoUFRegSigla;
            n20MesorregiaoUFRegSigla = false;
            O19MesorregiaoUFRegID = A19MesorregiaoUFRegID;
            O17MesorregiaoUFNome = A17MesorregiaoUFNome;
            O16MesorregiaoUFSigla = A16MesorregiaoUFSigla;
            A19MesorregiaoUFRegID = TBIBGE_MES2_A19MesorregiaoUFRegID[0];
            A17MesorregiaoUFNome = TBIBGE_MES2_A17MesorregiaoUFNome[0];
            A16MesorregiaoUFSigla = TBIBGE_MES2_A16MesorregiaoUFSigla[0];
            O19MesorregiaoUFRegID = A19MesorregiaoUFRegID;
            O17MesorregiaoUFNome = A17MesorregiaoUFNome;
            O16MesorregiaoUFSigla = A16MesorregiaoUFSigla;
            A21MesorregiaoUFRegNome = TBIBGE_MES2_A21MesorregiaoUFRegNome[0];
            n21MesorregiaoUFRegNome = TBIBGE_MES2_n21MesorregiaoUFRegNome[0];
            A20MesorregiaoUFRegSigla = TBIBGE_MES2_A20MesorregiaoUFRegSigla[0];
            n20MesorregiaoUFRegSigla = TBIBGE_MES2_n20MesorregiaoUFRegSigla[0];
            O21MesorregiaoUFRegNome = A21MesorregiaoUFRegNome;
            n21MesorregiaoUFRegNome = false;
            O20MesorregiaoUFRegSigla = A20MesorregiaoUFRegSigla;
            n20MesorregiaoUFRegSigla = false;
            A21MesorregiaoUFRegNome = O21MesorregiaoUFRegNome;
            n21MesorregiaoUFRegNome = false;
            A20MesorregiaoUFRegSigla = O20MesorregiaoUFRegSigla;
            n20MesorregiaoUFRegSigla = false;
            A19MesorregiaoUFRegID = O19MesorregiaoUFRegID;
            A17MesorregiaoUFNome = O17MesorregiaoUFNome;
            A16MesorregiaoUFSigla = O16MesorregiaoUFSigla;
            O21MesorregiaoUFRegNome = A21MesorregiaoUFRegNome;
            n21MesorregiaoUFRegNome = false;
            O20MesorregiaoUFRegSigla = A20MesorregiaoUFRegSigla;
            n20MesorregiaoUFRegSigla = false;
            O19MesorregiaoUFRegID = A19MesorregiaoUFRegID;
            O17MesorregiaoUFNome = A17MesorregiaoUFNome;
            O16MesorregiaoUFSigla = A16MesorregiaoUFSigla;
            A18MesorregiaoUFSiglaNome = StringUtil.Trim( A16MesorregiaoUFSigla) + " - " + StringUtil.Trim( A17MesorregiaoUFNome);
            n18MesorregiaoUFSiglaNome = false;
            A22MesorregiaoUFRegSiglaNome = StringUtil.Trim( A20MesorregiaoUFRegSigla) + " - " + StringUtil.Trim( A21MesorregiaoUFRegNome);
            n22MesorregiaoUFRegSiglaNome = false;
            /* Using cursor TBIBGE_MES3 */
            pr_default.execute(1, new Object[] {n21MesorregiaoUFRegNome, A21MesorregiaoUFRegNome, n20MesorregiaoUFRegSigla, A20MesorregiaoUFRegSigla, A19MesorregiaoUFRegID, A17MesorregiaoUFNome, A16MesorregiaoUFSigla, n18MesorregiaoUFSiglaNome, A18MesorregiaoUFSiglaNome, n22MesorregiaoUFRegSiglaNome, A22MesorregiaoUFRegSiglaNome, A13MesorregiaoID});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("tbibge_mesorregiao");
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
         TBIBGE_MES2_A15MesorregiaoUFID = new int[1] ;
         TBIBGE_MES2_A21MesorregiaoUFRegNome = new string[] {""} ;
         TBIBGE_MES2_n21MesorregiaoUFRegNome = new bool[] {false} ;
         TBIBGE_MES2_A20MesorregiaoUFRegSigla = new string[] {""} ;
         TBIBGE_MES2_n20MesorregiaoUFRegSigla = new bool[] {false} ;
         TBIBGE_MES2_A19MesorregiaoUFRegID = new int[1] ;
         TBIBGE_MES2_A17MesorregiaoUFNome = new string[] {""} ;
         TBIBGE_MES2_A16MesorregiaoUFSigla = new string[] {""} ;
         TBIBGE_MES2_A18MesorregiaoUFSiglaNome = new string[] {""} ;
         TBIBGE_MES2_n18MesorregiaoUFSiglaNome = new bool[] {false} ;
         TBIBGE_MES2_A22MesorregiaoUFRegSiglaNome = new string[] {""} ;
         TBIBGE_MES2_n22MesorregiaoUFRegSiglaNome = new bool[] {false} ;
         TBIBGE_MES2_A13MesorregiaoID = new int[1] ;
         A21MesorregiaoUFRegNome = "";
         A20MesorregiaoUFRegSigla = "";
         A17MesorregiaoUFNome = "";
         A16MesorregiaoUFSigla = "";
         A18MesorregiaoUFSiglaNome = "";
         A22MesorregiaoUFRegSiglaNome = "";
         O21MesorregiaoUFRegNome = "";
         O20MesorregiaoUFRegSigla = "";
         O17MesorregiaoUFNome = "";
         O16MesorregiaoUFSigla = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tbibge_mesorregiaoloadredundancy__default(),
            new Object[][] {
                new Object[] {
               TBIBGE_MES2_A15MesorregiaoUFID, TBIBGE_MES2_A21MesorregiaoUFRegNome, TBIBGE_MES2_n21MesorregiaoUFRegNome, TBIBGE_MES2_A21MesorregiaoUFRegNome, TBIBGE_MES2_n21MesorregiaoUFRegNome, TBIBGE_MES2_A20MesorregiaoUFRegSigla, TBIBGE_MES2_n20MesorregiaoUFRegSigla, TBIBGE_MES2_A20MesorregiaoUFRegSigla, TBIBGE_MES2_n20MesorregiaoUFRegSigla, TBIBGE_MES2_A19MesorregiaoUFRegID,
               TBIBGE_MES2_A19MesorregiaoUFRegID, TBIBGE_MES2_A17MesorregiaoUFNome, TBIBGE_MES2_A17MesorregiaoUFNome, TBIBGE_MES2_A16MesorregiaoUFSigla, TBIBGE_MES2_A16MesorregiaoUFSigla, TBIBGE_MES2_A18MesorregiaoUFSiglaNome, TBIBGE_MES2_n18MesorregiaoUFSiglaNome, TBIBGE_MES2_A22MesorregiaoUFRegSiglaNome, TBIBGE_MES2_n22MesorregiaoUFRegSiglaNome, TBIBGE_MES2_A13MesorregiaoID
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int A15MesorregiaoUFID ;
      private int A19MesorregiaoUFRegID ;
      private int A13MesorregiaoID ;
      private int O19MesorregiaoUFRegID ;
      private string scmdbuf ;
      private bool n21MesorregiaoUFRegNome ;
      private bool n20MesorregiaoUFRegSigla ;
      private bool n18MesorregiaoUFSiglaNome ;
      private bool n22MesorregiaoUFRegSiglaNome ;
      private string A21MesorregiaoUFRegNome ;
      private string A20MesorregiaoUFRegSigla ;
      private string A17MesorregiaoUFNome ;
      private string A16MesorregiaoUFSigla ;
      private string A18MesorregiaoUFSiglaNome ;
      private string A22MesorregiaoUFRegSiglaNome ;
      private string O21MesorregiaoUFRegNome ;
      private string O20MesorregiaoUFRegSigla ;
      private string O17MesorregiaoUFNome ;
      private string O16MesorregiaoUFSigla ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] TBIBGE_MES2_A15MesorregiaoUFID ;
      private string[] TBIBGE_MES2_A21MesorregiaoUFRegNome ;
      private bool[] TBIBGE_MES2_n21MesorregiaoUFRegNome ;
      private string[] TBIBGE_MES2_A20MesorregiaoUFRegSigla ;
      private bool[] TBIBGE_MES2_n20MesorregiaoUFRegSigla ;
      private int[] TBIBGE_MES2_A19MesorregiaoUFRegID ;
      private string[] TBIBGE_MES2_A17MesorregiaoUFNome ;
      private string[] TBIBGE_MES2_A16MesorregiaoUFSigla ;
      private string[] TBIBGE_MES2_A18MesorregiaoUFSiglaNome ;
      private bool[] TBIBGE_MES2_n18MesorregiaoUFSiglaNome ;
      private string[] TBIBGE_MES2_A22MesorregiaoUFRegSiglaNome ;
      private bool[] TBIBGE_MES2_n22MesorregiaoUFRegSiglaNome ;
      private int[] TBIBGE_MES2_A13MesorregiaoID ;
   }

   public class tbibge_mesorregiaoloadredundancy__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmTBIBGE_MES2;
          prmTBIBGE_MES2 = new Object[] {
          };
          Object[] prmTBIBGE_MES3;
          prmTBIBGE_MES3 = new Object[] {
          new ParDef("MesorregiaoUFRegNome",GXType.VarChar,50,0){Nullable=true} ,
          new ParDef("MesorregiaoUFRegSigla",GXType.VarChar,10,0){Nullable=true} ,
          new ParDef("MesorregiaoUFRegID",GXType.Int32,9,0) ,
          new ParDef("MesorregiaoUFNome",GXType.VarChar,50,0) ,
          new ParDef("MesorregiaoUFSigla",GXType.VarChar,2,0) ,
          new ParDef("MesorregiaoUFSiglaNome",GXType.VarChar,70,0){Nullable=true} ,
          new ParDef("MesorregiaoUFRegSiglaNome",GXType.VarChar,70,0){Nullable=true} ,
          new ParDef("MesorregiaoID",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("TBIBGE_MES2", "SELECT T1.MesorregiaoUFID AS MesorregiaoUFID, T1.MesorregiaoUFRegNome AS MesorregiaoUFRegNome, T3.RegiaoNome AS MesorregiaoUFRegNome, T1.MesorregiaoUFRegSigla AS MesorregiaoUFRegSigla, T3.RegiaoSigla AS MesorregiaoUFRegSigla, T1.MesorregiaoUFRegID AS MesorregiaoUFRegID, T2.UFRegID AS MesorregiaoUFRegID, T1.MesorregiaoUFNome AS MesorregiaoUFNome, T2.UFNome AS MesorregiaoUFNome, T1.MesorregiaoUFSigla AS MesorregiaoUFSigla, T2.UFSigla AS MesorregiaoUFSigla, T1.MesorregiaoUFSiglaNome AS MesorregiaoUFSiglaNome, T1.MesorregiaoUFRegSiglaNome AS MesorregiaoUFRegSiglaNome, T1.MesorregiaoID FROM ((tbibge_mesorregiao T1 INNER JOIN tbibge_uf T2 ON T2.UFID = T1.MesorregiaoUFID) INNER JOIN tbibge_regiao T3 ON T3.RegiaoID = T1.MesorregiaoUFRegID) ORDER BY T1.MesorregiaoID  FOR UPDATE OF T1, T1, T1",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmTBIBGE_MES2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("TBIBGE_MES3", "UPDATE tbibge_mesorregiao SET MesorregiaoUFRegNome=:MesorregiaoUFRegNome, MesorregiaoUFRegSigla=:MesorregiaoUFRegSigla, MesorregiaoUFRegID=:MesorregiaoUFRegID, MesorregiaoUFNome=:MesorregiaoUFNome, MesorregiaoUFSigla=:MesorregiaoUFSigla, MesorregiaoUFSiglaNome=:MesorregiaoUFSiglaNome, MesorregiaoUFRegSiglaNome=:MesorregiaoUFRegSiglaNome  WHERE MesorregiaoID = :MesorregiaoID", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmTBIBGE_MES3)
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((int[]) buf[9])[0] = rslt.getInt(6);
                ((int[]) buf[10])[0] = rslt.getInt(7);
                ((string[]) buf[11])[0] = rslt.getVarchar(8);
                ((string[]) buf[12])[0] = rslt.getVarchar(9);
                ((string[]) buf[13])[0] = rslt.getVarchar(10);
                ((string[]) buf[14])[0] = rslt.getVarchar(11);
                ((string[]) buf[15])[0] = rslt.getVarchar(12);
                ((bool[]) buf[16])[0] = rslt.wasNull(12);
                ((string[]) buf[17])[0] = rslt.getVarchar(13);
                ((bool[]) buf[18])[0] = rslt.wasNull(13);
                ((int[]) buf[19])[0] = rslt.getInt(14);
                return;
       }
    }

 }

}
