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
   public class tbibge_ufupdateredundancy : GXProcedure
   {
      public tbibge_ufupdateredundancy( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", false);
      }

      public tbibge_ufupdateredundancy( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref int aP0_UFID )
      {
         this.A4UFID = aP0_UFID;
         initialize();
         executePrivate();
         aP0_UFID=this.A4UFID;
      }

      public int executeUdp( )
      {
         execute(ref aP0_UFID);
         return A4UFID ;
      }

      public void executeSubmit( ref int aP0_UFID )
      {
         tbibge_ufupdateredundancy objtbibge_ufupdateredundancy;
         objtbibge_ufupdateredundancy = new tbibge_ufupdateredundancy();
         objtbibge_ufupdateredundancy.A4UFID = aP0_UFID;
         objtbibge_ufupdateredundancy.context.SetSubmitInitialConfig(context);
         objtbibge_ufupdateredundancy.initialize();
         Submit( executePrivateCatch,objtbibge_ufupdateredundancy);
         aP0_UFID=this.A4UFID;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((tbibge_ufupdateredundancy)stateInfo).executePrivate();
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
         /* Using cursor TBIBGE_UFU2 */
         pr_default.execute(0, new Object[] {A4UFID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A5UFSigla = TBIBGE_UFU2_A5UFSigla[0];
            A6UFNome = TBIBGE_UFU2_A6UFNome[0];
            A8UFRegID = TBIBGE_UFU2_A8UFRegID[0];
            A9UFRegSigla = TBIBGE_UFU2_A9UFRegSigla[0];
            A10UFRegNome = TBIBGE_UFU2_A10UFRegNome[0];
            A11UFRegSiglaNome = TBIBGE_UFU2_A11UFRegSiglaNome[0];
            n11UFRegSiglaNome = TBIBGE_UFU2_n11UFRegSiglaNome[0];
            A12UFSiglaNome = TBIBGE_UFU2_A12UFSiglaNome[0];
            AV2GXV5 = A5UFSigla;
            AV3GXV6 = A6UFNome;
            AV4GXV8 = A8UFRegID;
            AV5GXV9 = A9UFRegSigla;
            AV6GXV10 = A10UFRegNome;
            AV7GXV11 = A11UFRegSiglaNome;
            AV8GXV12 = A12UFSiglaNome;
            AV9GXV16 = AV2GXV5;
            AV10GXV17 = AV3GXV6;
            AV11GXV19 = AV4GXV8;
            AV12GXV20 = AV5GXV9;
            AV13GXV21 = AV6GXV10;
            AV14GXV22 = AV7GXV11;
            AV15GXV18 = AV8GXV12;
            n18MesorregiaoUFSiglaNome = false;
            n22MesorregiaoUFRegSiglaNome = false;
            n21MesorregiaoUFRegNome = false;
            n20MesorregiaoUFRegSigla = false;
            /* Optimized UPDATE. */
            /* Using cursor TBIBGE_UFU3 */
            pr_default.execute(1, new Object[] {n18MesorregiaoUFSiglaNome, AV15GXV18, n22MesorregiaoUFRegSiglaNome, AV14GXV22, n21MesorregiaoUFRegNome, AV13GXV21, n20MesorregiaoUFRegSigla, AV12GXV20, AV11GXV19, AV10GXV17, AV9GXV16, A4UFID});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("tbibge_mesorregiao");
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
         TBIBGE_UFU2_A4UFID = new int[1] ;
         TBIBGE_UFU2_A5UFSigla = new string[] {""} ;
         TBIBGE_UFU2_A6UFNome = new string[] {""} ;
         TBIBGE_UFU2_A8UFRegID = new int[1] ;
         TBIBGE_UFU2_A9UFRegSigla = new string[] {""} ;
         TBIBGE_UFU2_A10UFRegNome = new string[] {""} ;
         TBIBGE_UFU2_A11UFRegSiglaNome = new string[] {""} ;
         TBIBGE_UFU2_n11UFRegSiglaNome = new bool[] {false} ;
         TBIBGE_UFU2_A12UFSiglaNome = new string[] {""} ;
         A5UFSigla = "";
         A6UFNome = "";
         A9UFRegSigla = "";
         A10UFRegNome = "";
         A11UFRegSiglaNome = "";
         A12UFSiglaNome = "";
         AV2GXV5 = "";
         AV3GXV6 = "";
         AV5GXV9 = "";
         AV6GXV10 = "";
         AV7GXV11 = "";
         AV8GXV12 = "";
         AV9GXV16 = "";
         AV10GXV17 = "";
         AV12GXV20 = "";
         AV13GXV21 = "";
         AV14GXV22 = "";
         AV15GXV18 = "";
         A18MesorregiaoUFSiglaNome = "";
         A22MesorregiaoUFRegSiglaNome = "";
         A21MesorregiaoUFRegNome = "";
         A20MesorregiaoUFRegSigla = "";
         A17MesorregiaoUFNome = "";
         A16MesorregiaoUFSigla = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tbibge_ufupdateredundancy__default(),
            new Object[][] {
                new Object[] {
               TBIBGE_UFU2_A4UFID, TBIBGE_UFU2_A5UFSigla, TBIBGE_UFU2_A6UFNome, TBIBGE_UFU2_A8UFRegID, TBIBGE_UFU2_A9UFRegSigla, TBIBGE_UFU2_A10UFRegNome, TBIBGE_UFU2_A11UFRegSiglaNome, TBIBGE_UFU2_n11UFRegSiglaNome, TBIBGE_UFU2_A12UFSiglaNome
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int A4UFID ;
      private int A8UFRegID ;
      private int AV4GXV8 ;
      private int AV11GXV19 ;
      private int A19MesorregiaoUFRegID ;
      private string scmdbuf ;
      private bool n11UFRegSiglaNome ;
      private bool n18MesorregiaoUFSiglaNome ;
      private bool n22MesorregiaoUFRegSiglaNome ;
      private bool n21MesorregiaoUFRegNome ;
      private bool n20MesorregiaoUFRegSigla ;
      private string A5UFSigla ;
      private string A6UFNome ;
      private string A9UFRegSigla ;
      private string A10UFRegNome ;
      private string A11UFRegSiglaNome ;
      private string A12UFSiglaNome ;
      private string AV2GXV5 ;
      private string AV3GXV6 ;
      private string AV5GXV9 ;
      private string AV6GXV10 ;
      private string AV7GXV11 ;
      private string AV8GXV12 ;
      private string AV9GXV16 ;
      private string AV10GXV17 ;
      private string AV12GXV20 ;
      private string AV13GXV21 ;
      private string AV14GXV22 ;
      private string AV15GXV18 ;
      private string A18MesorregiaoUFSiglaNome ;
      private string A22MesorregiaoUFRegSiglaNome ;
      private string A21MesorregiaoUFRegNome ;
      private string A20MesorregiaoUFRegSigla ;
      private string A17MesorregiaoUFNome ;
      private string A16MesorregiaoUFSigla ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private int aP0_UFID ;
      private IDataStoreProvider pr_default ;
      private int[] TBIBGE_UFU2_A4UFID ;
      private string[] TBIBGE_UFU2_A5UFSigla ;
      private string[] TBIBGE_UFU2_A6UFNome ;
      private int[] TBIBGE_UFU2_A8UFRegID ;
      private string[] TBIBGE_UFU2_A9UFRegSigla ;
      private string[] TBIBGE_UFU2_A10UFRegNome ;
      private string[] TBIBGE_UFU2_A11UFRegSiglaNome ;
      private bool[] TBIBGE_UFU2_n11UFRegSiglaNome ;
      private string[] TBIBGE_UFU2_A12UFSiglaNome ;
   }

   public class tbibge_ufupdateredundancy__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmTBIBGE_UFU2;
          prmTBIBGE_UFU2 = new Object[] {
          new ParDef("UFID",GXType.Int32,9,0)
          };
          Object[] prmTBIBGE_UFU3;
          prmTBIBGE_UFU3 = new Object[] {
          new ParDef("MesorregiaoUFSiglaNome",GXType.VarChar,70,0){Nullable=true} ,
          new ParDef("MesorregiaoUFRegSiglaNome",GXType.VarChar,70,0){Nullable=true} ,
          new ParDef("MesorregiaoUFRegNome",GXType.VarChar,50,0){Nullable=true} ,
          new ParDef("MesorregiaoUFRegSigla",GXType.VarChar,10,0){Nullable=true} ,
          new ParDef("MesorregiaoUFRegID",GXType.Int32,9,0) ,
          new ParDef("MesorregiaoUFNome",GXType.VarChar,50,0) ,
          new ParDef("MesorregiaoUFSigla",GXType.VarChar,2,0) ,
          new ParDef("UFID",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("TBIBGE_UFU2", "SELECT UFID, UFSigla, UFNome, UFRegID, UFRegSigla, UFRegNome, UFRegSiglaNome, UFSiglaNome FROM tbibge_uf WHERE UFID = :UFID ORDER BY UFID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmTBIBGE_UFU2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("TBIBGE_UFU3", "UPDATE tbibge_mesorregiao SET MesorregiaoUFSiglaNome=:MesorregiaoUFSiglaNome, MesorregiaoUFRegSiglaNome=:MesorregiaoUFRegSiglaNome, MesorregiaoUFRegNome=:MesorregiaoUFRegNome, MesorregiaoUFRegSigla=:MesorregiaoUFRegSigla, MesorregiaoUFRegID=:MesorregiaoUFRegID, MesorregiaoUFNome=:MesorregiaoUFNome, MesorregiaoUFSigla=:MesorregiaoUFSigla  WHERE MesorregiaoUFID = :UFID", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmTBIBGE_UFU3)
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
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((string[]) buf[8])[0] = rslt.getVarchar(8);
                return;
       }
    }

 }

}
