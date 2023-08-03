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
   public class tbibge_ufloadredundancy : GXProcedure
   {
      public tbibge_ufloadredundancy( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", false);
      }

      public tbibge_ufloadredundancy( IGxContext context )
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
         tbibge_ufloadredundancy objtbibge_ufloadredundancy;
         objtbibge_ufloadredundancy = new tbibge_ufloadredundancy();
         objtbibge_ufloadredundancy.context.SetSubmitInitialConfig(context);
         objtbibge_ufloadredundancy.initialize();
         Submit( executePrivateCatch,objtbibge_ufloadredundancy);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((tbibge_ufloadredundancy)stateInfo).executePrivate();
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
         /* Using cursor TBIBGE_UFL2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A8UFRegID = TBIBGE_UFL2_A8UFRegID[0];
            A10UFRegNome = TBIBGE_UFL2_A10UFRegNome[0];
            A10UFRegNome = TBIBGE_UFL2_A10UFRegNome[0];
            A9UFRegSigla = TBIBGE_UFL2_A9UFRegSigla[0];
            A9UFRegSigla = TBIBGE_UFL2_A9UFRegSigla[0];
            A4UFID = TBIBGE_UFL2_A4UFID[0];
            A11UFRegSiglaNome = TBIBGE_UFL2_A11UFRegSiglaNome[0];
            n11UFRegSiglaNome = TBIBGE_UFL2_n11UFRegSiglaNome[0];
            A6UFNome = TBIBGE_UFL2_A6UFNome[0];
            A5UFSigla = TBIBGE_UFL2_A5UFSigla[0];
            A12UFSiglaNome = TBIBGE_UFL2_A12UFSiglaNome[0];
            O10UFRegNome = A10UFRegNome;
            O9UFRegSigla = A9UFRegSigla;
            A10UFRegNome = TBIBGE_UFL2_A10UFRegNome[0];
            A9UFRegSigla = TBIBGE_UFL2_A9UFRegSigla[0];
            O10UFRegNome = A10UFRegNome;
            O9UFRegSigla = A9UFRegSigla;
            A10UFRegNome = O10UFRegNome;
            A9UFRegSigla = O9UFRegSigla;
            O10UFRegNome = A10UFRegNome;
            O9UFRegSigla = A9UFRegSigla;
            A11UFRegSiglaNome = StringUtil.Trim( A9UFRegSigla) + " - " + StringUtil.Trim( A10UFRegNome);
            n11UFRegSiglaNome = false;
            A12UFSiglaNome = StringUtil.Trim( A5UFSigla) + " - " + StringUtil.Trim( A6UFNome);
            /* Using cursor TBIBGE_UFL3 */
            pr_default.execute(1, new Object[] {A10UFRegNome, A9UFRegSigla, n11UFRegSiglaNome, A11UFRegSiglaNome, A12UFSiglaNome, A4UFID});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("tbibge_uf");
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
         TBIBGE_UFL2_A8UFRegID = new int[1] ;
         TBIBGE_UFL2_A10UFRegNome = new string[] {""} ;
         TBIBGE_UFL2_A9UFRegSigla = new string[] {""} ;
         TBIBGE_UFL2_A4UFID = new int[1] ;
         TBIBGE_UFL2_A11UFRegSiglaNome = new string[] {""} ;
         TBIBGE_UFL2_n11UFRegSiglaNome = new bool[] {false} ;
         TBIBGE_UFL2_A6UFNome = new string[] {""} ;
         TBIBGE_UFL2_A5UFSigla = new string[] {""} ;
         TBIBGE_UFL2_A12UFSiglaNome = new string[] {""} ;
         A10UFRegNome = "";
         A9UFRegSigla = "";
         A11UFRegSiglaNome = "";
         A6UFNome = "";
         A5UFSigla = "";
         A12UFSiglaNome = "";
         O10UFRegNome = "";
         O9UFRegSigla = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tbibge_ufloadredundancy__default(),
            new Object[][] {
                new Object[] {
               TBIBGE_UFL2_A8UFRegID, TBIBGE_UFL2_A10UFRegNome, TBIBGE_UFL2_A10UFRegNome, TBIBGE_UFL2_A9UFRegSigla, TBIBGE_UFL2_A9UFRegSigla, TBIBGE_UFL2_A4UFID, TBIBGE_UFL2_A11UFRegSiglaNome, TBIBGE_UFL2_n11UFRegSiglaNome, TBIBGE_UFL2_A6UFNome, TBIBGE_UFL2_A5UFSigla,
               TBIBGE_UFL2_A12UFSiglaNome
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int A8UFRegID ;
      private int A4UFID ;
      private string scmdbuf ;
      private bool n11UFRegSiglaNome ;
      private string A10UFRegNome ;
      private string A9UFRegSigla ;
      private string A11UFRegSiglaNome ;
      private string A6UFNome ;
      private string A5UFSigla ;
      private string A12UFSiglaNome ;
      private string O10UFRegNome ;
      private string O9UFRegSigla ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] TBIBGE_UFL2_A8UFRegID ;
      private string[] TBIBGE_UFL2_A10UFRegNome ;
      private string[] TBIBGE_UFL2_A9UFRegSigla ;
      private int[] TBIBGE_UFL2_A4UFID ;
      private string[] TBIBGE_UFL2_A11UFRegSiglaNome ;
      private bool[] TBIBGE_UFL2_n11UFRegSiglaNome ;
      private string[] TBIBGE_UFL2_A6UFNome ;
      private string[] TBIBGE_UFL2_A5UFSigla ;
      private string[] TBIBGE_UFL2_A12UFSiglaNome ;
   }

   public class tbibge_ufloadredundancy__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmTBIBGE_UFL2;
          prmTBIBGE_UFL2 = new Object[] {
          };
          Object[] prmTBIBGE_UFL3;
          prmTBIBGE_UFL3 = new Object[] {
          new ParDef("UFRegNome",GXType.VarChar,50,0) ,
          new ParDef("UFRegSigla",GXType.VarChar,10,0) ,
          new ParDef("UFRegSiglaNome",GXType.VarChar,70,0){Nullable=true} ,
          new ParDef("UFSiglaNome",GXType.VarChar,70,0) ,
          new ParDef("UFID",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("TBIBGE_UFL2", "SELECT T1.UFRegID AS UFRegID, T1.UFRegNome AS UFRegNome, T2.RegiaoNome AS UFRegNome, T1.UFRegSigla AS UFRegSigla, T2.RegiaoSigla AS UFRegSigla, T1.UFID, T1.UFRegSiglaNome AS UFRegSiglaNome, T1.UFNome, T1.UFSigla, T1.UFSiglaNome FROM (tbibge_uf T1 INNER JOIN tbibge_regiao T2 ON T2.RegiaoID = T1.UFRegID) ORDER BY T1.UFID  FOR UPDATE OF T1, T1",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmTBIBGE_UFL2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("TBIBGE_UFL3", "UPDATE tbibge_uf SET UFRegNome=:UFRegNome, UFRegSigla=:UFRegSigla, UFRegSiglaNome=:UFRegSiglaNome, UFSiglaNome=:UFSiglaNome  WHERE UFID = :UFID", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmTBIBGE_UFL3)
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
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((string[]) buf[8])[0] = rslt.getVarchar(8);
                ((string[]) buf[9])[0] = rslt.getVarchar(9);
                ((string[]) buf[10])[0] = rslt.getVarchar(10);
                return;
       }
    }

 }

}
