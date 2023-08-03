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
   public class tbibge_microrregiaoloadredundancy : GXProcedure
   {
      public tbibge_microrregiaoloadredundancy( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", false);
      }

      public tbibge_microrregiaoloadredundancy( IGxContext context )
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
         tbibge_microrregiaoloadredundancy objtbibge_microrregiaoloadredundancy;
         objtbibge_microrregiaoloadredundancy = new tbibge_microrregiaoloadredundancy();
         objtbibge_microrregiaoloadredundancy.context.SetSubmitInitialConfig(context);
         objtbibge_microrregiaoloadredundancy.initialize();
         Submit( executePrivateCatch,objtbibge_microrregiaoloadredundancy);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((tbibge_microrregiaoloadredundancy)stateInfo).executePrivate();
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
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A25MicrorregiaoMesoID = TBIBGE_MIC2_A25MicrorregiaoMesoID[0];
            A33MicrorregiaoMesoUFRegNome = TBIBGE_MIC2_A33MicrorregiaoMesoUFRegNome[0];
            n33MicrorregiaoMesoUFRegNome = TBIBGE_MIC2_n33MicrorregiaoMesoUFRegNome[0];
            A33MicrorregiaoMesoUFRegNome = TBIBGE_MIC2_A33MicrorregiaoMesoUFRegNome[0];
            n33MicrorregiaoMesoUFRegNome = TBIBGE_MIC2_n33MicrorregiaoMesoUFRegNome[0];
            A32MicrorregiaoMesoUFRegSigla = TBIBGE_MIC2_A32MicrorregiaoMesoUFRegSigla[0];
            n32MicrorregiaoMesoUFRegSigla = TBIBGE_MIC2_n32MicrorregiaoMesoUFRegSigla[0];
            A32MicrorregiaoMesoUFRegSigla = TBIBGE_MIC2_A32MicrorregiaoMesoUFRegSigla[0];
            n32MicrorregiaoMesoUFRegSigla = TBIBGE_MIC2_n32MicrorregiaoMesoUFRegSigla[0];
            A31MicrorregiaoMesoUFRegID = TBIBGE_MIC2_A31MicrorregiaoMesoUFRegID[0];
            n31MicrorregiaoMesoUFRegID = TBIBGE_MIC2_n31MicrorregiaoMesoUFRegID[0];
            A31MicrorregiaoMesoUFRegID = TBIBGE_MIC2_A31MicrorregiaoMesoUFRegID[0];
            n31MicrorregiaoMesoUFRegID = TBIBGE_MIC2_n31MicrorregiaoMesoUFRegID[0];
            A29MicrorregiaoMesoUFNome = TBIBGE_MIC2_A29MicrorregiaoMesoUFNome[0];
            n29MicrorregiaoMesoUFNome = TBIBGE_MIC2_n29MicrorregiaoMesoUFNome[0];
            A29MicrorregiaoMesoUFNome = TBIBGE_MIC2_A29MicrorregiaoMesoUFNome[0];
            n29MicrorregiaoMesoUFNome = TBIBGE_MIC2_n29MicrorregiaoMesoUFNome[0];
            A28MicrorregiaoMesoUFSigla = TBIBGE_MIC2_A28MicrorregiaoMesoUFSigla[0];
            n28MicrorregiaoMesoUFSigla = TBIBGE_MIC2_n28MicrorregiaoMesoUFSigla[0];
            A28MicrorregiaoMesoUFSigla = TBIBGE_MIC2_A28MicrorregiaoMesoUFSigla[0];
            n28MicrorregiaoMesoUFSigla = TBIBGE_MIC2_n28MicrorregiaoMesoUFSigla[0];
            A27MicrorregiaoMesoUFID = TBIBGE_MIC2_A27MicrorregiaoMesoUFID[0];
            A27MicrorregiaoMesoUFID = TBIBGE_MIC2_A27MicrorregiaoMesoUFID[0];
            A26MicrorregiaoMesoNome = TBIBGE_MIC2_A26MicrorregiaoMesoNome[0];
            A26MicrorregiaoMesoNome = TBIBGE_MIC2_A26MicrorregiaoMesoNome[0];
            A30MicrorregiaoMesoUFSiglaNome = TBIBGE_MIC2_A30MicrorregiaoMesoUFSiglaNome[0];
            n30MicrorregiaoMesoUFSiglaNome = TBIBGE_MIC2_n30MicrorregiaoMesoUFSiglaNome[0];
            A34MicrorregiaoMesoUFRegSiglaNome = TBIBGE_MIC2_A34MicrorregiaoMesoUFRegSiglaNome[0];
            n34MicrorregiaoMesoUFRegSiglaNome = TBIBGE_MIC2_n34MicrorregiaoMesoUFRegSiglaNome[0];
            A23MicrorregiaoID = TBIBGE_MIC2_A23MicrorregiaoID[0];
            O33MicrorregiaoMesoUFRegNome = A33MicrorregiaoMesoUFRegNome;
            n33MicrorregiaoMesoUFRegNome = false;
            O32MicrorregiaoMesoUFRegSigla = A32MicrorregiaoMesoUFRegSigla;
            n32MicrorregiaoMesoUFRegSigla = false;
            O31MicrorregiaoMesoUFRegID = A31MicrorregiaoMesoUFRegID;
            n31MicrorregiaoMesoUFRegID = false;
            O29MicrorregiaoMesoUFNome = A29MicrorregiaoMesoUFNome;
            n29MicrorregiaoMesoUFNome = false;
            O28MicrorregiaoMesoUFSigla = A28MicrorregiaoMesoUFSigla;
            n28MicrorregiaoMesoUFSigla = false;
            O27MicrorregiaoMesoUFID = A27MicrorregiaoMesoUFID;
            O26MicrorregiaoMesoNome = A26MicrorregiaoMesoNome;
            A27MicrorregiaoMesoUFID = TBIBGE_MIC2_A27MicrorregiaoMesoUFID[0];
            A26MicrorregiaoMesoNome = TBIBGE_MIC2_A26MicrorregiaoMesoNome[0];
            O27MicrorregiaoMesoUFID = A27MicrorregiaoMesoUFID;
            O26MicrorregiaoMesoNome = A26MicrorregiaoMesoNome;
            A33MicrorregiaoMesoUFRegNome = TBIBGE_MIC2_A33MicrorregiaoMesoUFRegNome[0];
            n33MicrorregiaoMesoUFRegNome = TBIBGE_MIC2_n33MicrorregiaoMesoUFRegNome[0];
            A32MicrorregiaoMesoUFRegSigla = TBIBGE_MIC2_A32MicrorregiaoMesoUFRegSigla[0];
            n32MicrorregiaoMesoUFRegSigla = TBIBGE_MIC2_n32MicrorregiaoMesoUFRegSigla[0];
            O33MicrorregiaoMesoUFRegNome = A33MicrorregiaoMesoUFRegNome;
            n33MicrorregiaoMesoUFRegNome = false;
            O32MicrorregiaoMesoUFRegSigla = A32MicrorregiaoMesoUFRegSigla;
            n32MicrorregiaoMesoUFRegSigla = false;
            A31MicrorregiaoMesoUFRegID = TBIBGE_MIC2_A31MicrorregiaoMesoUFRegID[0];
            n31MicrorregiaoMesoUFRegID = TBIBGE_MIC2_n31MicrorregiaoMesoUFRegID[0];
            A29MicrorregiaoMesoUFNome = TBIBGE_MIC2_A29MicrorregiaoMesoUFNome[0];
            n29MicrorregiaoMesoUFNome = TBIBGE_MIC2_n29MicrorregiaoMesoUFNome[0];
            A28MicrorregiaoMesoUFSigla = TBIBGE_MIC2_A28MicrorregiaoMesoUFSigla[0];
            n28MicrorregiaoMesoUFSigla = TBIBGE_MIC2_n28MicrorregiaoMesoUFSigla[0];
            O31MicrorregiaoMesoUFRegID = A31MicrorregiaoMesoUFRegID;
            n31MicrorregiaoMesoUFRegID = false;
            O29MicrorregiaoMesoUFNome = A29MicrorregiaoMesoUFNome;
            n29MicrorregiaoMesoUFNome = false;
            O28MicrorregiaoMesoUFSigla = A28MicrorregiaoMesoUFSigla;
            n28MicrorregiaoMesoUFSigla = false;
            A33MicrorregiaoMesoUFRegNome = O33MicrorregiaoMesoUFRegNome;
            n33MicrorregiaoMesoUFRegNome = false;
            A32MicrorregiaoMesoUFRegSigla = O32MicrorregiaoMesoUFRegSigla;
            n32MicrorregiaoMesoUFRegSigla = false;
            A31MicrorregiaoMesoUFRegID = O31MicrorregiaoMesoUFRegID;
            n31MicrorregiaoMesoUFRegID = false;
            A29MicrorregiaoMesoUFNome = O29MicrorregiaoMesoUFNome;
            n29MicrorregiaoMesoUFNome = false;
            A28MicrorregiaoMesoUFSigla = O28MicrorregiaoMesoUFSigla;
            n28MicrorregiaoMesoUFSigla = false;
            A27MicrorregiaoMesoUFID = O27MicrorregiaoMesoUFID;
            A26MicrorregiaoMesoNome = O26MicrorregiaoMesoNome;
            O33MicrorregiaoMesoUFRegNome = A33MicrorregiaoMesoUFRegNome;
            n33MicrorregiaoMesoUFRegNome = false;
            O32MicrorregiaoMesoUFRegSigla = A32MicrorregiaoMesoUFRegSigla;
            n32MicrorregiaoMesoUFRegSigla = false;
            O31MicrorregiaoMesoUFRegID = A31MicrorregiaoMesoUFRegID;
            n31MicrorregiaoMesoUFRegID = false;
            O29MicrorregiaoMesoUFNome = A29MicrorregiaoMesoUFNome;
            n29MicrorregiaoMesoUFNome = false;
            O28MicrorregiaoMesoUFSigla = A28MicrorregiaoMesoUFSigla;
            n28MicrorregiaoMesoUFSigla = false;
            O27MicrorregiaoMesoUFID = A27MicrorregiaoMesoUFID;
            O26MicrorregiaoMesoNome = A26MicrorregiaoMesoNome;
            A30MicrorregiaoMesoUFSiglaNome = StringUtil.Trim( A28MicrorregiaoMesoUFSigla) + " - " + StringUtil.Trim( A29MicrorregiaoMesoUFNome);
            n30MicrorregiaoMesoUFSiglaNome = false;
            A34MicrorregiaoMesoUFRegSiglaNome = StringUtil.Trim( A32MicrorregiaoMesoUFRegSigla) + " - " + StringUtil.Trim( A33MicrorregiaoMesoUFRegNome);
            n34MicrorregiaoMesoUFRegSiglaNome = false;
            /* Using cursor TBIBGE_MIC3 */
            pr_default.execute(1, new Object[] {n33MicrorregiaoMesoUFRegNome, A33MicrorregiaoMesoUFRegNome, n32MicrorregiaoMesoUFRegSigla, A32MicrorregiaoMesoUFRegSigla, n31MicrorregiaoMesoUFRegID, A31MicrorregiaoMesoUFRegID, n29MicrorregiaoMesoUFNome, A29MicrorregiaoMesoUFNome, n28MicrorregiaoMesoUFSigla, A28MicrorregiaoMesoUFSigla, A27MicrorregiaoMesoUFID, A26MicrorregiaoMesoNome, n30MicrorregiaoMesoUFSiglaNome, A30MicrorregiaoMesoUFSiglaNome, n34MicrorregiaoMesoUFRegSiglaNome, A34MicrorregiaoMesoUFRegSiglaNome, A23MicrorregiaoID});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("tbibge_microrregiao");
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
         TBIBGE_MIC2_A25MicrorregiaoMesoID = new int[1] ;
         TBIBGE_MIC2_A33MicrorregiaoMesoUFRegNome = new string[] {""} ;
         TBIBGE_MIC2_n33MicrorregiaoMesoUFRegNome = new bool[] {false} ;
         TBIBGE_MIC2_A32MicrorregiaoMesoUFRegSigla = new string[] {""} ;
         TBIBGE_MIC2_n32MicrorregiaoMesoUFRegSigla = new bool[] {false} ;
         TBIBGE_MIC2_A31MicrorregiaoMesoUFRegID = new int[1] ;
         TBIBGE_MIC2_n31MicrorregiaoMesoUFRegID = new bool[] {false} ;
         TBIBGE_MIC2_A29MicrorregiaoMesoUFNome = new string[] {""} ;
         TBIBGE_MIC2_n29MicrorregiaoMesoUFNome = new bool[] {false} ;
         TBIBGE_MIC2_A28MicrorregiaoMesoUFSigla = new string[] {""} ;
         TBIBGE_MIC2_n28MicrorregiaoMesoUFSigla = new bool[] {false} ;
         TBIBGE_MIC2_A27MicrorregiaoMesoUFID = new int[1] ;
         TBIBGE_MIC2_A26MicrorregiaoMesoNome = new string[] {""} ;
         TBIBGE_MIC2_A30MicrorregiaoMesoUFSiglaNome = new string[] {""} ;
         TBIBGE_MIC2_n30MicrorregiaoMesoUFSiglaNome = new bool[] {false} ;
         TBIBGE_MIC2_A34MicrorregiaoMesoUFRegSiglaNome = new string[] {""} ;
         TBIBGE_MIC2_n34MicrorregiaoMesoUFRegSiglaNome = new bool[] {false} ;
         TBIBGE_MIC2_A23MicrorregiaoID = new int[1] ;
         A33MicrorregiaoMesoUFRegNome = "";
         A32MicrorregiaoMesoUFRegSigla = "";
         A29MicrorregiaoMesoUFNome = "";
         A28MicrorregiaoMesoUFSigla = "";
         A26MicrorregiaoMesoNome = "";
         A30MicrorregiaoMesoUFSiglaNome = "";
         A34MicrorregiaoMesoUFRegSiglaNome = "";
         O33MicrorregiaoMesoUFRegNome = "";
         O32MicrorregiaoMesoUFRegSigla = "";
         O29MicrorregiaoMesoUFNome = "";
         O28MicrorregiaoMesoUFSigla = "";
         O26MicrorregiaoMesoNome = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tbibge_microrregiaoloadredundancy__default(),
            new Object[][] {
                new Object[] {
               TBIBGE_MIC2_A25MicrorregiaoMesoID, TBIBGE_MIC2_A33MicrorregiaoMesoUFRegNome, TBIBGE_MIC2_n33MicrorregiaoMesoUFRegNome, TBIBGE_MIC2_A33MicrorregiaoMesoUFRegNome, TBIBGE_MIC2_n33MicrorregiaoMesoUFRegNome, TBIBGE_MIC2_A32MicrorregiaoMesoUFRegSigla, TBIBGE_MIC2_n32MicrorregiaoMesoUFRegSigla, TBIBGE_MIC2_A32MicrorregiaoMesoUFRegSigla, TBIBGE_MIC2_n32MicrorregiaoMesoUFRegSigla, TBIBGE_MIC2_A31MicrorregiaoMesoUFRegID,
               TBIBGE_MIC2_n31MicrorregiaoMesoUFRegID, TBIBGE_MIC2_A31MicrorregiaoMesoUFRegID, TBIBGE_MIC2_n31MicrorregiaoMesoUFRegID, TBIBGE_MIC2_A29MicrorregiaoMesoUFNome, TBIBGE_MIC2_n29MicrorregiaoMesoUFNome, TBIBGE_MIC2_A29MicrorregiaoMesoUFNome, TBIBGE_MIC2_n29MicrorregiaoMesoUFNome, TBIBGE_MIC2_A28MicrorregiaoMesoUFSigla, TBIBGE_MIC2_n28MicrorregiaoMesoUFSigla, TBIBGE_MIC2_A28MicrorregiaoMesoUFSigla,
               TBIBGE_MIC2_n28MicrorregiaoMesoUFSigla, TBIBGE_MIC2_A27MicrorregiaoMesoUFID, TBIBGE_MIC2_A27MicrorregiaoMesoUFID, TBIBGE_MIC2_A26MicrorregiaoMesoNome, TBIBGE_MIC2_A26MicrorregiaoMesoNome, TBIBGE_MIC2_A30MicrorregiaoMesoUFSiglaNome, TBIBGE_MIC2_n30MicrorregiaoMesoUFSiglaNome, TBIBGE_MIC2_A34MicrorregiaoMesoUFRegSiglaNome, TBIBGE_MIC2_n34MicrorregiaoMesoUFRegSiglaNome, TBIBGE_MIC2_A23MicrorregiaoID
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int A25MicrorregiaoMesoID ;
      private int A31MicrorregiaoMesoUFRegID ;
      private int A27MicrorregiaoMesoUFID ;
      private int A23MicrorregiaoID ;
      private int O31MicrorregiaoMesoUFRegID ;
      private int O27MicrorregiaoMesoUFID ;
      private string scmdbuf ;
      private bool n33MicrorregiaoMesoUFRegNome ;
      private bool n32MicrorregiaoMesoUFRegSigla ;
      private bool n31MicrorregiaoMesoUFRegID ;
      private bool n29MicrorregiaoMesoUFNome ;
      private bool n28MicrorregiaoMesoUFSigla ;
      private bool n30MicrorregiaoMesoUFSiglaNome ;
      private bool n34MicrorregiaoMesoUFRegSiglaNome ;
      private string A33MicrorregiaoMesoUFRegNome ;
      private string A32MicrorregiaoMesoUFRegSigla ;
      private string A29MicrorregiaoMesoUFNome ;
      private string A28MicrorregiaoMesoUFSigla ;
      private string A26MicrorregiaoMesoNome ;
      private string A30MicrorregiaoMesoUFSiglaNome ;
      private string A34MicrorregiaoMesoUFRegSiglaNome ;
      private string O33MicrorregiaoMesoUFRegNome ;
      private string O32MicrorregiaoMesoUFRegSigla ;
      private string O29MicrorregiaoMesoUFNome ;
      private string O28MicrorregiaoMesoUFSigla ;
      private string O26MicrorregiaoMesoNome ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] TBIBGE_MIC2_A25MicrorregiaoMesoID ;
      private string[] TBIBGE_MIC2_A33MicrorregiaoMesoUFRegNome ;
      private bool[] TBIBGE_MIC2_n33MicrorregiaoMesoUFRegNome ;
      private string[] TBIBGE_MIC2_A32MicrorregiaoMesoUFRegSigla ;
      private bool[] TBIBGE_MIC2_n32MicrorregiaoMesoUFRegSigla ;
      private int[] TBIBGE_MIC2_A31MicrorregiaoMesoUFRegID ;
      private bool[] TBIBGE_MIC2_n31MicrorregiaoMesoUFRegID ;
      private string[] TBIBGE_MIC2_A29MicrorregiaoMesoUFNome ;
      private bool[] TBIBGE_MIC2_n29MicrorregiaoMesoUFNome ;
      private string[] TBIBGE_MIC2_A28MicrorregiaoMesoUFSigla ;
      private bool[] TBIBGE_MIC2_n28MicrorregiaoMesoUFSigla ;
      private int[] TBIBGE_MIC2_A27MicrorregiaoMesoUFID ;
      private string[] TBIBGE_MIC2_A26MicrorregiaoMesoNome ;
      private string[] TBIBGE_MIC2_A30MicrorregiaoMesoUFSiglaNome ;
      private bool[] TBIBGE_MIC2_n30MicrorregiaoMesoUFSiglaNome ;
      private string[] TBIBGE_MIC2_A34MicrorregiaoMesoUFRegSiglaNome ;
      private bool[] TBIBGE_MIC2_n34MicrorregiaoMesoUFRegSiglaNome ;
      private int[] TBIBGE_MIC2_A23MicrorregiaoID ;
   }

   public class tbibge_microrregiaoloadredundancy__default : DataStoreHelperBase, IDataStoreHelper
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
          };
          Object[] prmTBIBGE_MIC3;
          prmTBIBGE_MIC3 = new Object[] {
          new ParDef("MicrorregiaoMesoUFRegNome",GXType.VarChar,50,0){Nullable=true} ,
          new ParDef("MicrorregiaoMesoUFRegSigla",GXType.VarChar,10,0){Nullable=true} ,
          new ParDef("MicrorregiaoMesoUFRegID",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("MicrorregiaoMesoUFNome",GXType.VarChar,50,0){Nullable=true} ,
          new ParDef("MicrorregiaoMesoUFSigla",GXType.VarChar,2,0){Nullable=true} ,
          new ParDef("MicrorregiaoMesoUFID",GXType.Int32,9,0) ,
          new ParDef("MicrorregiaoMesoNome",GXType.VarChar,80,0) ,
          new ParDef("MicrorregiaoMesoUFSiglaNome",GXType.VarChar,70,0){Nullable=true} ,
          new ParDef("MicrorregiaoMesoUFRegSiglaNome",GXType.VarChar,70,0){Nullable=true} ,
          new ParDef("MicrorregiaoID",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("TBIBGE_MIC2", "SELECT T1.MicrorregiaoMesoID AS MicrorregiaoMesoID, T1.MicrorregiaoMesoUFRegNome AS MicrorregiaoMesoUFRegNome, T3.RegiaoNome AS MicrorregiaoMesoUFRegNome, T1.MicrorregiaoMesoUFRegSigla AS MicrorregiaoMesoUFRegSigla, T3.RegiaoSigla AS MicrorregiaoMesoUFRegSigla, T1.MicrorregiaoMesoUFRegID AS MicrorregiaoMesoUFRegID, T4.UFRegID AS MicrorregiaoMesoUFRegID, T1.MicrorregiaoMesoUFNome AS MicrorregiaoMesoUFNome, T4.UFNome AS MicrorregiaoMesoUFNome, T1.MicrorregiaoMesoUFSigla AS MicrorregiaoMesoUFSigla, T4.UFSigla AS MicrorregiaoMesoUFSigla, T1.MicrorregiaoMesoUFID AS MicrorregiaoMesoUFID, T2.MesorregiaoUFID AS MicrorregiaoMesoUFID, T1.MicrorregiaoMesoNome AS MicrorregiaoMesoNome, T2.MesorregiaoNome AS MicrorregiaoMesoNome, T1.MicrorregiaoMesoUFSiglaNome AS MicrorregiaoMesoUFSiglaNome, T1.MicrorregiaoMesoUFRegSiglaNome AS MicrorregiaoMesoUFRegSiglaNome, T1.MicrorregiaoID FROM (((tbibge_microrregiao T1 INNER JOIN tbibge_mesorregiao T2 ON T2.MesorregiaoID = T1.MicrorregiaoMesoID) LEFT JOIN tbibge_regiao T3 ON T3.RegiaoID = T1.MicrorregiaoMesoUFRegID) INNER JOIN tbibge_uf T4 ON T4.UFID = T1.MicrorregiaoMesoUFID) ORDER BY T1.MicrorregiaoID  FOR UPDATE OF T1, T1, T1, T1",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmTBIBGE_MIC2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("TBIBGE_MIC3", "UPDATE tbibge_microrregiao SET MicrorregiaoMesoUFRegNome=:MicrorregiaoMesoUFRegNome, MicrorregiaoMesoUFRegSigla=:MicrorregiaoMesoUFRegSigla, MicrorregiaoMesoUFRegID=:MicrorregiaoMesoUFRegID, MicrorregiaoMesoUFNome=:MicrorregiaoMesoUFNome, MicrorregiaoMesoUFSigla=:MicrorregiaoMesoUFSigla, MicrorregiaoMesoUFID=:MicrorregiaoMesoUFID, MicrorregiaoMesoNome=:MicrorregiaoMesoNome, MicrorregiaoMesoUFSiglaNome=:MicrorregiaoMesoUFSiglaNome, MicrorregiaoMesoUFRegSiglaNome=:MicrorregiaoMesoUFRegSiglaNome  WHERE MicrorregiaoID = :MicrorregiaoID", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmTBIBGE_MIC3)
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
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((int[]) buf[11])[0] = rslt.getInt(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getVarchar(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((int[]) buf[21])[0] = rslt.getInt(12);
                ((int[]) buf[22])[0] = rslt.getInt(13);
                ((string[]) buf[23])[0] = rslt.getVarchar(14);
                ((string[]) buf[24])[0] = rslt.getVarchar(15);
                ((string[]) buf[25])[0] = rslt.getVarchar(16);
                ((bool[]) buf[26])[0] = rslt.wasNull(16);
                ((string[]) buf[27])[0] = rslt.getVarchar(17);
                ((bool[]) buf[28])[0] = rslt.wasNull(17);
                ((int[]) buf[29])[0] = rslt.getInt(18);
                return;
       }
    }

 }

}
