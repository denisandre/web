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
   public class tb_tabeladeprecoupdateredundancy : GXProcedure
   {
      public tb_tabeladeprecoupdateredundancy( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", false);
      }

      public tb_tabeladeprecoupdateredundancy( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref Guid aP0_TppID )
      {
         this.A235TppID = aP0_TppID;
         initialize();
         executePrivate();
         aP0_TppID=this.A235TppID;
      }

      public Guid executeUdp( )
      {
         execute(ref aP0_TppID);
         return A235TppID ;
      }

      public void executeSubmit( ref Guid aP0_TppID )
      {
         tb_tabeladeprecoupdateredundancy objtb_tabeladeprecoupdateredundancy;
         objtb_tabeladeprecoupdateredundancy = new tb_tabeladeprecoupdateredundancy();
         objtb_tabeladeprecoupdateredundancy.A235TppID = aP0_TppID;
         objtb_tabeladeprecoupdateredundancy.context.SetSubmitInitialConfig(context);
         objtb_tabeladeprecoupdateredundancy.initialize();
         Submit( executePrivateCatch,objtb_tabeladeprecoupdateredundancy);
         aP0_TppID=this.A235TppID;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((tb_tabeladeprecoupdateredundancy)stateInfo).executePrivate();
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
         /* Using cursor TB_TABELAD2 */
         pr_default.execute(0, new Object[] {A235TppID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A236TppCodigo = TB_TABELAD2_A236TppCodigo[0];
            A237TppNome = TB_TABELAD2_A237TppNome[0];
            A246TppAtivo = TB_TABELAD2_A246TppAtivo[0];
            n246TppAtivo = TB_TABELAD2_n246TppAtivo[0];
            AV2GXV236 = A236TppCodigo;
            AV3GXV237 = A237TppNome;
            AV4GXV246 = A246TppAtivo;
            AV5GXV450 = AV2GXV236;
            AV6GXV451 = AV3GXV237;
            AV7GXV452 = AV4GXV246;
            n452NegTppAtivo = false;
            /* Optimized UPDATE. */
            /* Using cursor TB_TABELAD3 */
            pr_default.execute(1, new Object[] {n452NegTppAtivo, AV7GXV452, AV6GXV451, AV5GXV450, A235TppID});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("tb_negociopj");
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
         TB_TABELAD2_A235TppID = new Guid[] {Guid.Empty} ;
         TB_TABELAD2_A236TppCodigo = new string[] {""} ;
         TB_TABELAD2_A237TppNome = new string[] {""} ;
         TB_TABELAD2_A246TppAtivo = new bool[] {false} ;
         TB_TABELAD2_n246TppAtivo = new bool[] {false} ;
         A236TppCodigo = "";
         A237TppNome = "";
         AV2GXV236 = "";
         AV3GXV237 = "";
         AV5GXV450 = "";
         AV6GXV451 = "";
         A451NegTppNome = "";
         A450NegTppCodigo = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tb_tabeladeprecoupdateredundancy__default(),
            new Object[][] {
                new Object[] {
               TB_TABELAD2_A235TppID, TB_TABELAD2_A236TppCodigo, TB_TABELAD2_A237TppNome, TB_TABELAD2_A246TppAtivo, TB_TABELAD2_n246TppAtivo
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private string scmdbuf ;
      private bool A246TppAtivo ;
      private bool n246TppAtivo ;
      private bool AV4GXV246 ;
      private bool AV7GXV452 ;
      private bool n452NegTppAtivo ;
      private bool A452NegTppAtivo ;
      private string A236TppCodigo ;
      private string A237TppNome ;
      private string AV2GXV236 ;
      private string AV3GXV237 ;
      private string AV5GXV450 ;
      private string AV6GXV451 ;
      private string A451NegTppNome ;
      private string A450NegTppCodigo ;
      private Guid A235TppID ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private Guid aP0_TppID ;
      private IDataStoreProvider pr_default ;
      private Guid[] TB_TABELAD2_A235TppID ;
      private string[] TB_TABELAD2_A236TppCodigo ;
      private string[] TB_TABELAD2_A237TppNome ;
      private bool[] TB_TABELAD2_A246TppAtivo ;
      private bool[] TB_TABELAD2_n246TppAtivo ;
   }

   public class tb_tabeladeprecoupdateredundancy__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmTB_TABELAD2;
          prmTB_TABELAD2 = new Object[] {
          new ParDef("TppID",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmTB_TABELAD3;
          prmTB_TABELAD3 = new Object[] {
          new ParDef("NegTppAtivo",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("NegTppNome",GXType.VarChar,80,0) ,
          new ParDef("NegTppCodigo",GXType.VarChar,20,0) ,
          new ParDef("TppID",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("TB_TABELAD2", "SELECT TppID, TppCodigo, TppNome, TppAtivo FROM tb_tabeladepreco WHERE TppID = :TppID ORDER BY TppID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmTB_TABELAD2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("TB_TABELAD3", "UPDATE tb_negociopj SET NegTppAtivo=:NegTppAtivo, NegTppNome=:NegTppNome, NegTppCodigo=:NegTppCodigo  WHERE NegTppID = :TppID", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmTB_TABELAD3)
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((bool[]) buf[3])[0] = rslt.getBool(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                return;
       }
    }

 }

}
