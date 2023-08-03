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
   public class tb_clientepjtipoupdateredundancy : GXProcedure
   {
      public tb_clientepjtipoupdateredundancy( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", false);
      }

      public tb_clientepjtipoupdateredundancy( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref int aP0_PjtID )
      {
         this.A155PjtID = aP0_PjtID;
         initialize();
         executePrivate();
         aP0_PjtID=this.A155PjtID;
      }

      public int executeUdp( )
      {
         execute(ref aP0_PjtID);
         return A155PjtID ;
      }

      public void executeSubmit( ref int aP0_PjtID )
      {
         tb_clientepjtipoupdateredundancy objtb_clientepjtipoupdateredundancy;
         objtb_clientepjtipoupdateredundancy = new tb_clientepjtipoupdateredundancy();
         objtb_clientepjtipoupdateredundancy.A155PjtID = aP0_PjtID;
         objtb_clientepjtipoupdateredundancy.context.SetSubmitInitialConfig(context);
         objtb_clientepjtipoupdateredundancy.initialize();
         Submit( executePrivateCatch,objtb_clientepjtipoupdateredundancy);
         aP0_PjtID=this.A155PjtID;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((tb_clientepjtipoupdateredundancy)stateInfo).executePrivate();
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
         pr_default.execute(0, new Object[] {A155PjtID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A156PjtSigla = TB_CLIENTE2_A156PjtSigla[0];
            A157PjtNome = TB_CLIENTE2_A157PjtNome[0];
            AV2GXV156 = A156PjtSigla;
            AV3GXV157 = A157PjtNome;
            AV4GXV271 = AV2GXV156;
            AV5GXV272 = AV3GXV157;
            /* Optimized UPDATE. */
            /* Using cursor TB_CLIENTE3 */
            pr_default.execute(1, new Object[] {AV5GXV272, AV4GXV271, A155PjtID});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("tb_clientepj_contato");
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
         TB_CLIENTE2_A155PjtID = new int[1] ;
         TB_CLIENTE2_A156PjtSigla = new string[] {""} ;
         TB_CLIENTE2_A157PjtNome = new string[] {""} ;
         A156PjtSigla = "";
         A157PjtNome = "";
         AV2GXV156 = "";
         AV3GXV157 = "";
         AV4GXV271 = "";
         AV5GXV272 = "";
         A272CpjConTipoNome = "";
         A271CpjConTipoSigla = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tb_clientepjtipoupdateredundancy__default(),
            new Object[][] {
                new Object[] {
               TB_CLIENTE2_A155PjtID, TB_CLIENTE2_A156PjtSigla, TB_CLIENTE2_A157PjtNome
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int A155PjtID ;
      private string scmdbuf ;
      private string A156PjtSigla ;
      private string A157PjtNome ;
      private string AV2GXV156 ;
      private string AV3GXV157 ;
      private string AV4GXV271 ;
      private string AV5GXV272 ;
      private string A272CpjConTipoNome ;
      private string A271CpjConTipoSigla ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private int aP0_PjtID ;
      private IDataStoreProvider pr_default ;
      private int[] TB_CLIENTE2_A155PjtID ;
      private string[] TB_CLIENTE2_A156PjtSigla ;
      private string[] TB_CLIENTE2_A157PjtNome ;
   }

   public class tb_clientepjtipoupdateredundancy__default : DataStoreHelperBase, IDataStoreHelper
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
          new ParDef("PjtID",GXType.Int32,9,0)
          };
          Object[] prmTB_CLIENTE3;
          prmTB_CLIENTE3 = new Object[] {
          new ParDef("CpjConTipoNome",GXType.VarChar,80,0) ,
          new ParDef("CpjConTipoSigla",GXType.VarChar,20,0) ,
          new ParDef("PjtID",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("TB_CLIENTE2", "SELECT PjtID, PjtSigla, PjtNome FROM tb_clientepjtipo WHERE PjtID = :PjtID ORDER BY PjtID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmTB_CLIENTE2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("TB_CLIENTE3", "UPDATE tb_clientepj_contato SET CpjConTipoNome=:CpjConTipoNome, CpjConTipoSigla=:CpjConTipoSigla  WHERE CpjConTipoID = :PjtID", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmTB_CLIENTE3)
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
                return;
       }
    }

 }

}
