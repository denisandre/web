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
   public class tbibge_regiaoupdateredundancy : GXProcedure
   {
      public tbibge_regiaoupdateredundancy( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", false);
      }

      public tbibge_regiaoupdateredundancy( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref int aP0_RegiaoID )
      {
         this.A1RegiaoID = aP0_RegiaoID;
         initialize();
         executePrivate();
         aP0_RegiaoID=this.A1RegiaoID;
      }

      public int executeUdp( )
      {
         execute(ref aP0_RegiaoID);
         return A1RegiaoID ;
      }

      public void executeSubmit( ref int aP0_RegiaoID )
      {
         tbibge_regiaoupdateredundancy objtbibge_regiaoupdateredundancy;
         objtbibge_regiaoupdateredundancy = new tbibge_regiaoupdateredundancy();
         objtbibge_regiaoupdateredundancy.A1RegiaoID = aP0_RegiaoID;
         objtbibge_regiaoupdateredundancy.context.SetSubmitInitialConfig(context);
         objtbibge_regiaoupdateredundancy.initialize();
         Submit( executePrivateCatch,objtbibge_regiaoupdateredundancy);
         aP0_RegiaoID=this.A1RegiaoID;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((tbibge_regiaoupdateredundancy)stateInfo).executePrivate();
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
         /* Using cursor TBIBGE_REG2 */
         pr_default.execute(0, new Object[] {A1RegiaoID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A2RegiaoSigla = TBIBGE_REG2_A2RegiaoSigla[0];
            A3RegiaoNome = TBIBGE_REG2_A3RegiaoNome[0];
            A7RegiaoSiglaNome = TBIBGE_REG2_A7RegiaoSiglaNome[0];
            AV2GXV2 = A2RegiaoSigla;
            AV3GXV3 = A3RegiaoNome;
            AV4GXV7 = A7RegiaoSiglaNome;
            AV5GXV9 = AV2GXV2;
            AV6GXV10 = AV3GXV3;
            AV7GXV11 = AV4GXV7;
            n11UFRegSiglaNome = false;
            /* Optimized UPDATE. */
            /* Using cursor TBIBGE_REG3 */
            pr_default.execute(1, new Object[] {n11UFRegSiglaNome, AV7GXV11, AV6GXV10, AV5GXV9, A1RegiaoID});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("tbibge_uf");
            /* End optimized UPDATE. */
            /* Exiting from a For First loop. */
            if (true) break;
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
         TBIBGE_REG2_A1RegiaoID = new int[1] ;
         TBIBGE_REG2_A2RegiaoSigla = new string[] {""} ;
         TBIBGE_REG2_A3RegiaoNome = new string[] {""} ;
         TBIBGE_REG2_A7RegiaoSiglaNome = new string[] {""} ;
         A2RegiaoSigla = "";
         A3RegiaoNome = "";
         A7RegiaoSiglaNome = "";
         AV2GXV2 = "";
         AV3GXV3 = "";
         AV4GXV7 = "";
         AV5GXV9 = "";
         AV6GXV10 = "";
         AV7GXV11 = "";
         A11UFRegSiglaNome = "";
         A10UFRegNome = "";
         A9UFRegSigla = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tbibge_regiaoupdateredundancy__default(),
            new Object[][] {
                new Object[] {
               TBIBGE_REG2_A1RegiaoID, TBIBGE_REG2_A2RegiaoSigla, TBIBGE_REG2_A3RegiaoNome, TBIBGE_REG2_A7RegiaoSiglaNome
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int A1RegiaoID ;
      private string scmdbuf ;
      private bool n11UFRegSiglaNome ;
      private string A2RegiaoSigla ;
      private string A3RegiaoNome ;
      private string A7RegiaoSiglaNome ;
      private string AV2GXV2 ;
      private string AV3GXV3 ;
      private string AV4GXV7 ;
      private string AV5GXV9 ;
      private string AV6GXV10 ;
      private string AV7GXV11 ;
      private string A11UFRegSiglaNome ;
      private string A10UFRegNome ;
      private string A9UFRegSigla ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private int aP0_RegiaoID ;
      private IDataStoreProvider pr_default ;
      private int[] TBIBGE_REG2_A1RegiaoID ;
      private string[] TBIBGE_REG2_A2RegiaoSigla ;
      private string[] TBIBGE_REG2_A3RegiaoNome ;
      private string[] TBIBGE_REG2_A7RegiaoSiglaNome ;
   }

   public class tbibge_regiaoupdateredundancy__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmTBIBGE_REG2;
          prmTBIBGE_REG2 = new Object[] {
          new ParDef("RegiaoID",GXType.Int32,9,0)
          };
          Object[] prmTBIBGE_REG3;
          prmTBIBGE_REG3 = new Object[] {
          new ParDef("UFRegSiglaNome",GXType.VarChar,70,0){Nullable=true} ,
          new ParDef("UFRegNome",GXType.VarChar,50,0) ,
          new ParDef("UFRegSigla",GXType.VarChar,10,0) ,
          new ParDef("RegiaoID",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("TBIBGE_REG2", "SELECT RegiaoID, RegiaoSigla, RegiaoNome, RegiaoSiglaNome FROM tbibge_regiao WHERE RegiaoID = :RegiaoID ORDER BY RegiaoID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmTBIBGE_REG2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("TBIBGE_REG3", "UPDATE tbibge_uf SET UFRegSiglaNome=:UFRegSiglaNome, UFRegNome=:UFRegNome, UFRegSigla=:UFRegSigla  WHERE UFRegID = :RegiaoID", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmTBIBGE_REG3)
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
                return;
       }
    }

 }

}
