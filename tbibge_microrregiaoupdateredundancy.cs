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
   public class tbibge_microrregiaoupdateredundancy : GXProcedure
   {
      public tbibge_microrregiaoupdateredundancy( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", false);
      }

      public tbibge_microrregiaoupdateredundancy( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref int aP0_MicrorregiaoID )
      {
         this.A23MicrorregiaoID = aP0_MicrorregiaoID;
         initialize();
         executePrivate();
         aP0_MicrorregiaoID=this.A23MicrorregiaoID;
      }

      public int executeUdp( )
      {
         execute(ref aP0_MicrorregiaoID);
         return A23MicrorregiaoID ;
      }

      public void executeSubmit( ref int aP0_MicrorregiaoID )
      {
         tbibge_microrregiaoupdateredundancy objtbibge_microrregiaoupdateredundancy;
         objtbibge_microrregiaoupdateredundancy = new tbibge_microrregiaoupdateredundancy();
         objtbibge_microrregiaoupdateredundancy.A23MicrorregiaoID = aP0_MicrorregiaoID;
         objtbibge_microrregiaoupdateredundancy.context.SetSubmitInitialConfig(context);
         objtbibge_microrregiaoupdateredundancy.initialize();
         Submit( executePrivateCatch,objtbibge_microrregiaoupdateredundancy);
         aP0_MicrorregiaoID=this.A23MicrorregiaoID;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((tbibge_microrregiaoupdateredundancy)stateInfo).executePrivate();
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
         /* Using cursor TBIBGE_MIC2 */
         pr_default.execute(0, new Object[] {A23MicrorregiaoID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A24MicrorregiaoNome = TBIBGE_MIC2_A24MicrorregiaoNome[0];
            A25MicrorregiaoMesoID = TBIBGE_MIC2_A25MicrorregiaoMesoID[0];
            A26MicrorregiaoMesoNome = TBIBGE_MIC2_A26MicrorregiaoMesoNome[0];
            A27MicrorregiaoMesoUFID = TBIBGE_MIC2_A27MicrorregiaoMesoUFID[0];
            A28MicrorregiaoMesoUFSigla = TBIBGE_MIC2_A28MicrorregiaoMesoUFSigla[0];
            n28MicrorregiaoMesoUFSigla = TBIBGE_MIC2_n28MicrorregiaoMesoUFSigla[0];
            A29MicrorregiaoMesoUFNome = TBIBGE_MIC2_A29MicrorregiaoMesoUFNome[0];
            n29MicrorregiaoMesoUFNome = TBIBGE_MIC2_n29MicrorregiaoMesoUFNome[0];
            A30MicrorregiaoMesoUFSiglaNome = TBIBGE_MIC2_A30MicrorregiaoMesoUFSiglaNome[0];
            n30MicrorregiaoMesoUFSiglaNome = TBIBGE_MIC2_n30MicrorregiaoMesoUFSiglaNome[0];
            A31MicrorregiaoMesoUFRegID = TBIBGE_MIC2_A31MicrorregiaoMesoUFRegID[0];
            n31MicrorregiaoMesoUFRegID = TBIBGE_MIC2_n31MicrorregiaoMesoUFRegID[0];
            A32MicrorregiaoMesoUFRegSigla = TBIBGE_MIC2_A32MicrorregiaoMesoUFRegSigla[0];
            n32MicrorregiaoMesoUFRegSigla = TBIBGE_MIC2_n32MicrorregiaoMesoUFRegSigla[0];
            A33MicrorregiaoMesoUFRegNome = TBIBGE_MIC2_A33MicrorregiaoMesoUFRegNome[0];
            n33MicrorregiaoMesoUFRegNome = TBIBGE_MIC2_n33MicrorregiaoMesoUFRegNome[0];
            A34MicrorregiaoMesoUFRegSiglaNome = TBIBGE_MIC2_A34MicrorregiaoMesoUFRegSiglaNome[0];
            n34MicrorregiaoMesoUFRegSiglaNome = TBIBGE_MIC2_n34MicrorregiaoMesoUFRegSiglaNome[0];
            AV2GXV24 = A24MicrorregiaoNome;
            AV3GXV25 = A25MicrorregiaoMesoID;
            AV4GXV26 = A26MicrorregiaoMesoNome;
            AV5GXV27 = A27MicrorregiaoMesoUFID;
            AV6GXV28 = A28MicrorregiaoMesoUFSigla;
            AV7GXV29 = A29MicrorregiaoMesoUFNome;
            AV8GXV30 = A30MicrorregiaoMesoUFSiglaNome;
            AV9GXV31 = A31MicrorregiaoMesoUFRegID;
            AV10GXV32 = A32MicrorregiaoMesoUFRegSigla;
            AV11GXV33 = A33MicrorregiaoMesoUFRegNome;
            AV12GXV34 = A34MicrorregiaoMesoUFRegSiglaNome;
            AV13GXV38 = AV2GXV24;
            AV14GXV39 = AV3GXV25;
            AV15GXV40 = AV4GXV26;
            AV16GXV41 = AV5GXV27;
            AV17GXV42 = AV6GXV28;
            AV18GXV43 = AV7GXV29;
            AV19GXV44 = AV8GXV30;
            AV20GXV45 = AV9GXV31;
            AV21GXV46 = AV10GXV32;
            AV22GXV47 = AV11GXV33;
            AV23GXV48 = AV12GXV34;
            n48MunicipioMicroMesoUFRegSiglaNo = false;
            n47MunicipioMicroMesoUFRegNome = false;
            n46MunicipioMicroMesoUFRegSigla = false;
            n45MunicipioMicroMesoUFRegID = false;
            n44MunicipioMicroMesoUFSiglaNome = false;
            n43MunicipioMicroMesoUFNome = false;
            n42MunicipioMicroMesoUFSigla = false;
            n41MunicipioMicroMesoUFID = false;
            n40MunicipioMicroMesoNome = false;
            /* Optimized UPDATE. */
            /* Using cursor TBIBGE_MIC3 */
            pr_default.execute(1, new Object[] {n48MunicipioMicroMesoUFRegSiglaNo, AV23GXV48, n47MunicipioMicroMesoUFRegNome, AV22GXV47, n46MunicipioMicroMesoUFRegSigla, AV21GXV46, n45MunicipioMicroMesoUFRegID, AV20GXV45, n44MunicipioMicroMesoUFSiglaNome, AV19GXV44, n43MunicipioMicroMesoUFNome, AV18GXV43, n42MunicipioMicroMesoUFSigla, AV17GXV42, n41MunicipioMicroMesoUFID, AV16GXV41, n40MunicipioMicroMesoNome, AV15GXV40, AV14GXV39, AV13GXV38, A23MicrorregiaoID});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("tbibge_municipio");
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
         TBIBGE_MIC2_A23MicrorregiaoID = new int[1] ;
         TBIBGE_MIC2_A24MicrorregiaoNome = new string[] {""} ;
         TBIBGE_MIC2_A25MicrorregiaoMesoID = new int[1] ;
         TBIBGE_MIC2_A26MicrorregiaoMesoNome = new string[] {""} ;
         TBIBGE_MIC2_A27MicrorregiaoMesoUFID = new int[1] ;
         TBIBGE_MIC2_A28MicrorregiaoMesoUFSigla = new string[] {""} ;
         TBIBGE_MIC2_n28MicrorregiaoMesoUFSigla = new bool[] {false} ;
         TBIBGE_MIC2_A29MicrorregiaoMesoUFNome = new string[] {""} ;
         TBIBGE_MIC2_n29MicrorregiaoMesoUFNome = new bool[] {false} ;
         TBIBGE_MIC2_A30MicrorregiaoMesoUFSiglaNome = new string[] {""} ;
         TBIBGE_MIC2_n30MicrorregiaoMesoUFSiglaNome = new bool[] {false} ;
         TBIBGE_MIC2_A31MicrorregiaoMesoUFRegID = new int[1] ;
         TBIBGE_MIC2_n31MicrorregiaoMesoUFRegID = new bool[] {false} ;
         TBIBGE_MIC2_A32MicrorregiaoMesoUFRegSigla = new string[] {""} ;
         TBIBGE_MIC2_n32MicrorregiaoMesoUFRegSigla = new bool[] {false} ;
         TBIBGE_MIC2_A33MicrorregiaoMesoUFRegNome = new string[] {""} ;
         TBIBGE_MIC2_n33MicrorregiaoMesoUFRegNome = new bool[] {false} ;
         TBIBGE_MIC2_A34MicrorregiaoMesoUFRegSiglaNome = new string[] {""} ;
         TBIBGE_MIC2_n34MicrorregiaoMesoUFRegSiglaNome = new bool[] {false} ;
         A24MicrorregiaoNome = "";
         A26MicrorregiaoMesoNome = "";
         A28MicrorregiaoMesoUFSigla = "";
         A29MicrorregiaoMesoUFNome = "";
         A30MicrorregiaoMesoUFSiglaNome = "";
         A32MicrorregiaoMesoUFRegSigla = "";
         A33MicrorregiaoMesoUFRegNome = "";
         A34MicrorregiaoMesoUFRegSiglaNome = "";
         AV2GXV24 = "";
         AV4GXV26 = "";
         AV6GXV28 = "";
         AV7GXV29 = "";
         AV8GXV30 = "";
         AV10GXV32 = "";
         AV11GXV33 = "";
         AV12GXV34 = "";
         AV13GXV38 = "";
         AV15GXV40 = "";
         AV17GXV42 = "";
         AV18GXV43 = "";
         AV19GXV44 = "";
         AV21GXV46 = "";
         AV22GXV47 = "";
         AV23GXV48 = "";
         A48MunicipioMicroMesoUFRegSiglaNo = "";
         A47MunicipioMicroMesoUFRegNome = "";
         A46MunicipioMicroMesoUFRegSigla = "";
         A44MunicipioMicroMesoUFSiglaNome = "";
         A43MunicipioMicroMesoUFNome = "";
         A42MunicipioMicroMesoUFSigla = "";
         A40MunicipioMicroMesoNome = "";
         A38MunicipioMicroNome = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tbibge_microrregiaoupdateredundancy__default(),
            new Object[][] {
                new Object[] {
               TBIBGE_MIC2_A23MicrorregiaoID, TBIBGE_MIC2_A24MicrorregiaoNome, TBIBGE_MIC2_A25MicrorregiaoMesoID, TBIBGE_MIC2_A26MicrorregiaoMesoNome, TBIBGE_MIC2_A27MicrorregiaoMesoUFID, TBIBGE_MIC2_A28MicrorregiaoMesoUFSigla, TBIBGE_MIC2_n28MicrorregiaoMesoUFSigla, TBIBGE_MIC2_A29MicrorregiaoMesoUFNome, TBIBGE_MIC2_n29MicrorregiaoMesoUFNome, TBIBGE_MIC2_A30MicrorregiaoMesoUFSiglaNome,
               TBIBGE_MIC2_n30MicrorregiaoMesoUFSiglaNome, TBIBGE_MIC2_A31MicrorregiaoMesoUFRegID, TBIBGE_MIC2_n31MicrorregiaoMesoUFRegID, TBIBGE_MIC2_A32MicrorregiaoMesoUFRegSigla, TBIBGE_MIC2_n32MicrorregiaoMesoUFRegSigla, TBIBGE_MIC2_A33MicrorregiaoMesoUFRegNome, TBIBGE_MIC2_n33MicrorregiaoMesoUFRegNome, TBIBGE_MIC2_A34MicrorregiaoMesoUFRegSiglaNome, TBIBGE_MIC2_n34MicrorregiaoMesoUFRegSiglaNome
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int A23MicrorregiaoID ;
      private int A25MicrorregiaoMesoID ;
      private int A27MicrorregiaoMesoUFID ;
      private int A31MicrorregiaoMesoUFRegID ;
      private int AV3GXV25 ;
      private int AV5GXV27 ;
      private int AV9GXV31 ;
      private int AV14GXV39 ;
      private int AV16GXV41 ;
      private int AV20GXV45 ;
      private int A45MunicipioMicroMesoUFRegID ;
      private int A41MunicipioMicroMesoUFID ;
      private int A39MunicipioMicroMesoID ;
      private string scmdbuf ;
      private bool n28MicrorregiaoMesoUFSigla ;
      private bool n29MicrorregiaoMesoUFNome ;
      private bool n30MicrorregiaoMesoUFSiglaNome ;
      private bool n31MicrorregiaoMesoUFRegID ;
      private bool n32MicrorregiaoMesoUFRegSigla ;
      private bool n33MicrorregiaoMesoUFRegNome ;
      private bool n34MicrorregiaoMesoUFRegSiglaNome ;
      private bool n48MunicipioMicroMesoUFRegSiglaNo ;
      private bool n47MunicipioMicroMesoUFRegNome ;
      private bool n46MunicipioMicroMesoUFRegSigla ;
      private bool n45MunicipioMicroMesoUFRegID ;
      private bool n44MunicipioMicroMesoUFSiglaNome ;
      private bool n43MunicipioMicroMesoUFNome ;
      private bool n42MunicipioMicroMesoUFSigla ;
      private bool n41MunicipioMicroMesoUFID ;
      private bool n40MunicipioMicroMesoNome ;
      private string A24MicrorregiaoNome ;
      private string A26MicrorregiaoMesoNome ;
      private string A28MicrorregiaoMesoUFSigla ;
      private string A29MicrorregiaoMesoUFNome ;
      private string A30MicrorregiaoMesoUFSiglaNome ;
      private string A32MicrorregiaoMesoUFRegSigla ;
      private string A33MicrorregiaoMesoUFRegNome ;
      private string A34MicrorregiaoMesoUFRegSiglaNome ;
      private string AV2GXV24 ;
      private string AV4GXV26 ;
      private string AV6GXV28 ;
      private string AV7GXV29 ;
      private string AV8GXV30 ;
      private string AV10GXV32 ;
      private string AV11GXV33 ;
      private string AV12GXV34 ;
      private string AV13GXV38 ;
      private string AV15GXV40 ;
      private string AV17GXV42 ;
      private string AV18GXV43 ;
      private string AV19GXV44 ;
      private string AV21GXV46 ;
      private string AV22GXV47 ;
      private string AV23GXV48 ;
      private string A48MunicipioMicroMesoUFRegSiglaNo ;
      private string A47MunicipioMicroMesoUFRegNome ;
      private string A46MunicipioMicroMesoUFRegSigla ;
      private string A44MunicipioMicroMesoUFSiglaNome ;
      private string A43MunicipioMicroMesoUFNome ;
      private string A42MunicipioMicroMesoUFSigla ;
      private string A40MunicipioMicroMesoNome ;
      private string A38MunicipioMicroNome ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private int aP0_MicrorregiaoID ;
      private IDataStoreProvider pr_default ;
      private int[] TBIBGE_MIC2_A23MicrorregiaoID ;
      private string[] TBIBGE_MIC2_A24MicrorregiaoNome ;
      private int[] TBIBGE_MIC2_A25MicrorregiaoMesoID ;
      private string[] TBIBGE_MIC2_A26MicrorregiaoMesoNome ;
      private int[] TBIBGE_MIC2_A27MicrorregiaoMesoUFID ;
      private string[] TBIBGE_MIC2_A28MicrorregiaoMesoUFSigla ;
      private bool[] TBIBGE_MIC2_n28MicrorregiaoMesoUFSigla ;
      private string[] TBIBGE_MIC2_A29MicrorregiaoMesoUFNome ;
      private bool[] TBIBGE_MIC2_n29MicrorregiaoMesoUFNome ;
      private string[] TBIBGE_MIC2_A30MicrorregiaoMesoUFSiglaNome ;
      private bool[] TBIBGE_MIC2_n30MicrorregiaoMesoUFSiglaNome ;
      private int[] TBIBGE_MIC2_A31MicrorregiaoMesoUFRegID ;
      private bool[] TBIBGE_MIC2_n31MicrorregiaoMesoUFRegID ;
      private string[] TBIBGE_MIC2_A32MicrorregiaoMesoUFRegSigla ;
      private bool[] TBIBGE_MIC2_n32MicrorregiaoMesoUFRegSigla ;
      private string[] TBIBGE_MIC2_A33MicrorregiaoMesoUFRegNome ;
      private bool[] TBIBGE_MIC2_n33MicrorregiaoMesoUFRegNome ;
      private string[] TBIBGE_MIC2_A34MicrorregiaoMesoUFRegSiglaNome ;
      private bool[] TBIBGE_MIC2_n34MicrorregiaoMesoUFRegSiglaNome ;
   }

   public class tbibge_microrregiaoupdateredundancy__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmTBIBGE_MIC2;
          prmTBIBGE_MIC2 = new Object[] {
          new ParDef("MicrorregiaoID",GXType.Int32,9,0)
          };
          Object[] prmTBIBGE_MIC3;
          prmTBIBGE_MIC3 = new Object[] {
          new ParDef("MunicipioMicroMesoUFRegSiglaNo",GXType.VarChar,70,0){Nullable=true} ,
          new ParDef("MunicipioMicroMesoUFRegNome",GXType.VarChar,50,0){Nullable=true} ,
          new ParDef("MunicipioMicroMesoUFRegSigla",GXType.VarChar,10,0){Nullable=true} ,
          new ParDef("MunicipioMicroMesoUFRegID",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("MunicipioMicroMesoUFSiglaNome",GXType.VarChar,70,0){Nullable=true} ,
          new ParDef("MunicipioMicroMesoUFNome",GXType.VarChar,50,0){Nullable=true} ,
          new ParDef("MunicipioMicroMesoUFSigla",GXType.VarChar,2,0){Nullable=true} ,
          new ParDef("MunicipioMicroMesoUFID",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("MunicipioMicroMesoNome",GXType.VarChar,80,0){Nullable=true} ,
          new ParDef("MunicipioMicroMesoID",GXType.Int32,9,0) ,
          new ParDef("MunicipioMicroNome",GXType.VarChar,80,0) ,
          new ParDef("MicrorregiaoID",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("TBIBGE_MIC2", "SELECT MicrorregiaoID, MicrorregiaoNome, MicrorregiaoMesoID, MicrorregiaoMesoNome, MicrorregiaoMesoUFID, MicrorregiaoMesoUFSigla, MicrorregiaoMesoUFNome, MicrorregiaoMesoUFSiglaNome, MicrorregiaoMesoUFRegID, MicrorregiaoMesoUFRegSigla, MicrorregiaoMesoUFRegNome, MicrorregiaoMesoUFRegSiglaNome FROM tbibge_microrregiao WHERE MicrorregiaoID = :MicrorregiaoID ORDER BY MicrorregiaoID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmTBIBGE_MIC2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("TBIBGE_MIC3", "UPDATE tbibge_municipio SET MunicipioMicroMesoUFRegSiglaNo=:MunicipioMicroMesoUFRegSiglaNo, MunicipioMicroMesoUFRegNome=:MunicipioMicroMesoUFRegNome, MunicipioMicroMesoUFRegSigla=:MunicipioMicroMesoUFRegSigla, MunicipioMicroMesoUFRegID=:MunicipioMicroMesoUFRegID, MunicipioMicroMesoUFSiglaNome=:MunicipioMicroMesoUFSiglaNome, MunicipioMicroMesoUFNome=:MunicipioMicroMesoUFNome, MunicipioMicroMesoUFSigla=:MunicipioMicroMesoUFSigla, MunicipioMicroMesoUFID=:MunicipioMicroMesoUFID, MunicipioMicroMesoNome=:MunicipioMicroMesoNome, MunicipioMicroMesoID=:MunicipioMicroMesoID, MunicipioMicroNome=:MunicipioMicroNome  WHERE MunicipioMicroID = :MicrorregiaoID", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmTBIBGE_MIC3)
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
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((string[]) buf[9])[0] = rslt.getVarchar(8);
                ((bool[]) buf[10])[0] = rslt.wasNull(8);
                ((int[]) buf[11])[0] = rslt.getInt(9);
                ((bool[]) buf[12])[0] = rslt.wasNull(9);
                ((string[]) buf[13])[0] = rslt.getVarchar(10);
                ((bool[]) buf[14])[0] = rslt.wasNull(10);
                ((string[]) buf[15])[0] = rslt.getVarchar(11);
                ((bool[]) buf[16])[0] = rslt.wasNull(11);
                ((string[]) buf[17])[0] = rslt.getVarchar(12);
                ((bool[]) buf[18])[0] = rslt.wasNull(12);
                return;
       }
    }

 }

}
