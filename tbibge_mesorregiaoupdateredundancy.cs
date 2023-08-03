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
   public class tbibge_mesorregiaoupdateredundancy : GXProcedure
   {
      public tbibge_mesorregiaoupdateredundancy( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", false);
      }

      public tbibge_mesorregiaoupdateredundancy( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref int aP0_MesorregiaoID )
      {
         this.A13MesorregiaoID = aP0_MesorregiaoID;
         initialize();
         executePrivate();
         aP0_MesorregiaoID=this.A13MesorregiaoID;
      }

      public int executeUdp( )
      {
         execute(ref aP0_MesorregiaoID);
         return A13MesorregiaoID ;
      }

      public void executeSubmit( ref int aP0_MesorregiaoID )
      {
         tbibge_mesorregiaoupdateredundancy objtbibge_mesorregiaoupdateredundancy;
         objtbibge_mesorregiaoupdateredundancy = new tbibge_mesorregiaoupdateredundancy();
         objtbibge_mesorregiaoupdateredundancy.A13MesorregiaoID = aP0_MesorregiaoID;
         objtbibge_mesorregiaoupdateredundancy.context.SetSubmitInitialConfig(context);
         objtbibge_mesorregiaoupdateredundancy.initialize();
         Submit( executePrivateCatch,objtbibge_mesorregiaoupdateredundancy);
         aP0_MesorregiaoID=this.A13MesorregiaoID;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((tbibge_mesorregiaoupdateredundancy)stateInfo).executePrivate();
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
         pr_default.execute(0, new Object[] {A13MesorregiaoID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A14MesorregiaoNome = TBIBGE_MES2_A14MesorregiaoNome[0];
            A15MesorregiaoUFID = TBIBGE_MES2_A15MesorregiaoUFID[0];
            A16MesorregiaoUFSigla = TBIBGE_MES2_A16MesorregiaoUFSigla[0];
            A17MesorregiaoUFNome = TBIBGE_MES2_A17MesorregiaoUFNome[0];
            A18MesorregiaoUFSiglaNome = TBIBGE_MES2_A18MesorregiaoUFSiglaNome[0];
            n18MesorregiaoUFSiglaNome = TBIBGE_MES2_n18MesorregiaoUFSiglaNome[0];
            A19MesorregiaoUFRegID = TBIBGE_MES2_A19MesorregiaoUFRegID[0];
            A20MesorregiaoUFRegSigla = TBIBGE_MES2_A20MesorregiaoUFRegSigla[0];
            n20MesorregiaoUFRegSigla = TBIBGE_MES2_n20MesorregiaoUFRegSigla[0];
            A21MesorregiaoUFRegNome = TBIBGE_MES2_A21MesorregiaoUFRegNome[0];
            n21MesorregiaoUFRegNome = TBIBGE_MES2_n21MesorregiaoUFRegNome[0];
            A22MesorregiaoUFRegSiglaNome = TBIBGE_MES2_A22MesorregiaoUFRegSiglaNome[0];
            n22MesorregiaoUFRegSiglaNome = TBIBGE_MES2_n22MesorregiaoUFRegSiglaNome[0];
            AV2GXV14 = A14MesorregiaoNome;
            AV3GXV15 = A15MesorregiaoUFID;
            AV4GXV16 = A16MesorregiaoUFSigla;
            AV5GXV17 = A17MesorregiaoUFNome;
            AV6GXV18 = A18MesorregiaoUFSiglaNome;
            AV7GXV19 = A19MesorregiaoUFRegID;
            AV8GXV20 = A20MesorregiaoUFRegSigla;
            AV9GXV21 = A21MesorregiaoUFRegNome;
            AV10GXV22 = A22MesorregiaoUFRegSiglaNome;
            AV11GXV26 = AV2GXV14;
            AV12GXV27 = AV3GXV15;
            AV13GXV28 = AV4GXV16;
            AV14GXV29 = AV5GXV17;
            AV15GXV30 = AV6GXV18;
            AV16GXV31 = AV7GXV19;
            AV17GXV32 = AV8GXV20;
            AV18GXV33 = AV9GXV21;
            AV19GXV34 = AV10GXV22;
            n34MicrorregiaoMesoUFRegSiglaNome = false;
            n33MicrorregiaoMesoUFRegNome = false;
            n32MicrorregiaoMesoUFRegSigla = false;
            n31MicrorregiaoMesoUFRegID = false;
            n30MicrorregiaoMesoUFSiglaNome = false;
            n29MicrorregiaoMesoUFNome = false;
            n28MicrorregiaoMesoUFSigla = false;
            /* Optimized UPDATE. */
            /* Using cursor TBIBGE_MES3 */
            pr_default.execute(1, new Object[] {n34MicrorregiaoMesoUFRegSiglaNome, AV19GXV34, n33MicrorregiaoMesoUFRegNome, AV18GXV33, n32MicrorregiaoMesoUFRegSigla, AV17GXV32, n31MicrorregiaoMesoUFRegID, AV16GXV31, n30MicrorregiaoMesoUFSiglaNome, AV15GXV30, n29MicrorregiaoMesoUFNome, AV14GXV29, n28MicrorregiaoMesoUFSigla, AV13GXV28, AV12GXV27, AV11GXV26, A13MesorregiaoID});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("tbibge_microrregiao");
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
         TBIBGE_MES2_A13MesorregiaoID = new int[1] ;
         TBIBGE_MES2_A14MesorregiaoNome = new string[] {""} ;
         TBIBGE_MES2_A15MesorregiaoUFID = new int[1] ;
         TBIBGE_MES2_A16MesorregiaoUFSigla = new string[] {""} ;
         TBIBGE_MES2_A17MesorregiaoUFNome = new string[] {""} ;
         TBIBGE_MES2_A18MesorregiaoUFSiglaNome = new string[] {""} ;
         TBIBGE_MES2_n18MesorregiaoUFSiglaNome = new bool[] {false} ;
         TBIBGE_MES2_A19MesorregiaoUFRegID = new int[1] ;
         TBIBGE_MES2_A20MesorregiaoUFRegSigla = new string[] {""} ;
         TBIBGE_MES2_n20MesorregiaoUFRegSigla = new bool[] {false} ;
         TBIBGE_MES2_A21MesorregiaoUFRegNome = new string[] {""} ;
         TBIBGE_MES2_n21MesorregiaoUFRegNome = new bool[] {false} ;
         TBIBGE_MES2_A22MesorregiaoUFRegSiglaNome = new string[] {""} ;
         TBIBGE_MES2_n22MesorregiaoUFRegSiglaNome = new bool[] {false} ;
         A14MesorregiaoNome = "";
         A16MesorregiaoUFSigla = "";
         A17MesorregiaoUFNome = "";
         A18MesorregiaoUFSiglaNome = "";
         A20MesorregiaoUFRegSigla = "";
         A21MesorregiaoUFRegNome = "";
         A22MesorregiaoUFRegSiglaNome = "";
         AV2GXV14 = "";
         AV4GXV16 = "";
         AV5GXV17 = "";
         AV6GXV18 = "";
         AV8GXV20 = "";
         AV9GXV21 = "";
         AV10GXV22 = "";
         AV11GXV26 = "";
         AV13GXV28 = "";
         AV14GXV29 = "";
         AV15GXV30 = "";
         AV17GXV32 = "";
         AV18GXV33 = "";
         AV19GXV34 = "";
         A34MicrorregiaoMesoUFRegSiglaNome = "";
         A33MicrorregiaoMesoUFRegNome = "";
         A32MicrorregiaoMesoUFRegSigla = "";
         A30MicrorregiaoMesoUFSiglaNome = "";
         A29MicrorregiaoMesoUFNome = "";
         A28MicrorregiaoMesoUFSigla = "";
         A26MicrorregiaoMesoNome = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tbibge_mesorregiaoupdateredundancy__default(),
            new Object[][] {
                new Object[] {
               TBIBGE_MES2_A13MesorregiaoID, TBIBGE_MES2_A14MesorregiaoNome, TBIBGE_MES2_A15MesorregiaoUFID, TBIBGE_MES2_A16MesorregiaoUFSigla, TBIBGE_MES2_A17MesorregiaoUFNome, TBIBGE_MES2_A18MesorregiaoUFSiglaNome, TBIBGE_MES2_n18MesorregiaoUFSiglaNome, TBIBGE_MES2_A19MesorregiaoUFRegID, TBIBGE_MES2_A20MesorregiaoUFRegSigla, TBIBGE_MES2_n20MesorregiaoUFRegSigla,
               TBIBGE_MES2_A21MesorregiaoUFRegNome, TBIBGE_MES2_n21MesorregiaoUFRegNome, TBIBGE_MES2_A22MesorregiaoUFRegSiglaNome, TBIBGE_MES2_n22MesorregiaoUFRegSiglaNome
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int A13MesorregiaoID ;
      private int A15MesorregiaoUFID ;
      private int A19MesorregiaoUFRegID ;
      private int AV3GXV15 ;
      private int AV7GXV19 ;
      private int AV12GXV27 ;
      private int AV16GXV31 ;
      private int A31MicrorregiaoMesoUFRegID ;
      private int A27MicrorregiaoMesoUFID ;
      private string scmdbuf ;
      private bool n18MesorregiaoUFSiglaNome ;
      private bool n20MesorregiaoUFRegSigla ;
      private bool n21MesorregiaoUFRegNome ;
      private bool n22MesorregiaoUFRegSiglaNome ;
      private bool n34MicrorregiaoMesoUFRegSiglaNome ;
      private bool n33MicrorregiaoMesoUFRegNome ;
      private bool n32MicrorregiaoMesoUFRegSigla ;
      private bool n31MicrorregiaoMesoUFRegID ;
      private bool n30MicrorregiaoMesoUFSiglaNome ;
      private bool n29MicrorregiaoMesoUFNome ;
      private bool n28MicrorregiaoMesoUFSigla ;
      private string A14MesorregiaoNome ;
      private string A16MesorregiaoUFSigla ;
      private string A17MesorregiaoUFNome ;
      private string A18MesorregiaoUFSiglaNome ;
      private string A20MesorregiaoUFRegSigla ;
      private string A21MesorregiaoUFRegNome ;
      private string A22MesorregiaoUFRegSiglaNome ;
      private string AV2GXV14 ;
      private string AV4GXV16 ;
      private string AV5GXV17 ;
      private string AV6GXV18 ;
      private string AV8GXV20 ;
      private string AV9GXV21 ;
      private string AV10GXV22 ;
      private string AV11GXV26 ;
      private string AV13GXV28 ;
      private string AV14GXV29 ;
      private string AV15GXV30 ;
      private string AV17GXV32 ;
      private string AV18GXV33 ;
      private string AV19GXV34 ;
      private string A34MicrorregiaoMesoUFRegSiglaNome ;
      private string A33MicrorregiaoMesoUFRegNome ;
      private string A32MicrorregiaoMesoUFRegSigla ;
      private string A30MicrorregiaoMesoUFSiglaNome ;
      private string A29MicrorregiaoMesoUFNome ;
      private string A28MicrorregiaoMesoUFSigla ;
      private string A26MicrorregiaoMesoNome ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private int aP0_MesorregiaoID ;
      private IDataStoreProvider pr_default ;
      private int[] TBIBGE_MES2_A13MesorregiaoID ;
      private string[] TBIBGE_MES2_A14MesorregiaoNome ;
      private int[] TBIBGE_MES2_A15MesorregiaoUFID ;
      private string[] TBIBGE_MES2_A16MesorregiaoUFSigla ;
      private string[] TBIBGE_MES2_A17MesorregiaoUFNome ;
      private string[] TBIBGE_MES2_A18MesorregiaoUFSiglaNome ;
      private bool[] TBIBGE_MES2_n18MesorregiaoUFSiglaNome ;
      private int[] TBIBGE_MES2_A19MesorregiaoUFRegID ;
      private string[] TBIBGE_MES2_A20MesorregiaoUFRegSigla ;
      private bool[] TBIBGE_MES2_n20MesorregiaoUFRegSigla ;
      private string[] TBIBGE_MES2_A21MesorregiaoUFRegNome ;
      private bool[] TBIBGE_MES2_n21MesorregiaoUFRegNome ;
      private string[] TBIBGE_MES2_A22MesorregiaoUFRegSiglaNome ;
      private bool[] TBIBGE_MES2_n22MesorregiaoUFRegSiglaNome ;
   }

   public class tbibge_mesorregiaoupdateredundancy__default : DataStoreHelperBase, IDataStoreHelper
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
          new ParDef("MesorregiaoID",GXType.Int32,9,0)
          };
          Object[] prmTBIBGE_MES3;
          prmTBIBGE_MES3 = new Object[] {
          new ParDef("MicrorregiaoMesoUFRegSiglaNome",GXType.VarChar,70,0){Nullable=true} ,
          new ParDef("MicrorregiaoMesoUFRegNome",GXType.VarChar,50,0){Nullable=true} ,
          new ParDef("MicrorregiaoMesoUFRegSigla",GXType.VarChar,10,0){Nullable=true} ,
          new ParDef("MicrorregiaoMesoUFRegID",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("MicrorregiaoMesoUFSiglaNome",GXType.VarChar,70,0){Nullable=true} ,
          new ParDef("MicrorregiaoMesoUFNome",GXType.VarChar,50,0){Nullable=true} ,
          new ParDef("MicrorregiaoMesoUFSigla",GXType.VarChar,2,0){Nullable=true} ,
          new ParDef("MicrorregiaoMesoUFID",GXType.Int32,9,0) ,
          new ParDef("MicrorregiaoMesoNome",GXType.VarChar,80,0) ,
          new ParDef("MesorregiaoID",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("TBIBGE_MES2", "SELECT MesorregiaoID, MesorregiaoNome, MesorregiaoUFID, MesorregiaoUFSigla, MesorregiaoUFNome, MesorregiaoUFSiglaNome, MesorregiaoUFRegID, MesorregiaoUFRegSigla, MesorregiaoUFRegNome, MesorregiaoUFRegSiglaNome FROM tbibge_mesorregiao WHERE MesorregiaoID = :MesorregiaoID ORDER BY MesorregiaoID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmTBIBGE_MES2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("TBIBGE_MES3", "UPDATE tbibge_microrregiao SET MicrorregiaoMesoUFRegSiglaNome=:MicrorregiaoMesoUFRegSiglaNome, MicrorregiaoMesoUFRegNome=:MicrorregiaoMesoUFRegNome, MicrorregiaoMesoUFRegSigla=:MicrorregiaoMesoUFRegSigla, MicrorregiaoMesoUFRegID=:MicrorregiaoMesoUFRegID, MicrorregiaoMesoUFSiglaNome=:MicrorregiaoMesoUFSiglaNome, MicrorregiaoMesoUFNome=:MicrorregiaoMesoUFNome, MicrorregiaoMesoUFSigla=:MicrorregiaoMesoUFSigla, MicrorregiaoMesoUFID=:MicrorregiaoMesoUFID, MicrorregiaoMesoNome=:MicrorregiaoMesoNome  WHERE MicrorregiaoMesoID = :MesorregiaoID", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmTBIBGE_MES3)
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
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((int[]) buf[7])[0] = rslt.getInt(7);
                ((string[]) buf[8])[0] = rslt.getVarchar(8);
                ((bool[]) buf[9])[0] = rslt.wasNull(8);
                ((string[]) buf[10])[0] = rslt.getVarchar(9);
                ((bool[]) buf[11])[0] = rslt.wasNull(9);
                ((string[]) buf[12])[0] = rslt.getVarchar(10);
                ((bool[]) buf[13])[0] = rslt.wasNull(10);
                return;
       }
    }

 }

}
