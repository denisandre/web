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
   public class tb_generoupdateredundancy : GXProcedure
   {
      public tb_generoupdateredundancy( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", false);
      }

      public tb_generoupdateredundancy( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref int aP0_GenID )
      {
         this.A152GenID = aP0_GenID;
         initialize();
         executePrivate();
         aP0_GenID=this.A152GenID;
      }

      public int executeUdp( )
      {
         execute(ref aP0_GenID);
         return A152GenID ;
      }

      public void executeSubmit( ref int aP0_GenID )
      {
         tb_generoupdateredundancy objtb_generoupdateredundancy;
         objtb_generoupdateredundancy = new tb_generoupdateredundancy();
         objtb_generoupdateredundancy.A152GenID = aP0_GenID;
         objtb_generoupdateredundancy.context.SetSubmitInitialConfig(context);
         objtb_generoupdateredundancy.initialize();
         Submit( executePrivateCatch,objtb_generoupdateredundancy);
         aP0_GenID=this.A152GenID;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((tb_generoupdateredundancy)stateInfo).executePrivate();
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
         /* Using cursor TB_GENEROU2 */
         pr_default.execute(0, new Object[] {A152GenID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A153GenSigla = TB_GENEROU2_A153GenSigla[0];
            A154GenNome = TB_GENEROU2_A154GenNome[0];
            AV2GXV153 = A153GenSigla;
            AV3GXV154 = A154GenNome;
            AV4GXV280 = AV2GXV153;
            AV5GXV281 = AV3GXV154;
            /* Optimized UPDATE. */
            /* Using cursor TB_GENEROU3 */
            pr_default.execute(1, new Object[] {AV5GXV281, AV4GXV280, A152GenID});
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
         TB_GENEROU2_A152GenID = new int[1] ;
         TB_GENEROU2_A153GenSigla = new string[] {""} ;
         TB_GENEROU2_A154GenNome = new string[] {""} ;
         A153GenSigla = "";
         A154GenNome = "";
         AV2GXV153 = "";
         AV3GXV154 = "";
         AV4GXV280 = "";
         AV5GXV281 = "";
         A281CpjConGenNome = "";
         A280CpjConGenSigla = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tb_generoupdateredundancy__default(),
            new Object[][] {
                new Object[] {
               TB_GENEROU2_A152GenID, TB_GENEROU2_A153GenSigla, TB_GENEROU2_A154GenNome
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int A152GenID ;
      private string scmdbuf ;
      private string A153GenSigla ;
      private string A154GenNome ;
      private string AV2GXV153 ;
      private string AV3GXV154 ;
      private string AV4GXV280 ;
      private string AV5GXV281 ;
      private string A281CpjConGenNome ;
      private string A280CpjConGenSigla ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private int aP0_GenID ;
      private IDataStoreProvider pr_default ;
      private int[] TB_GENEROU2_A152GenID ;
      private string[] TB_GENEROU2_A153GenSigla ;
      private string[] TB_GENEROU2_A154GenNome ;
   }

   public class tb_generoupdateredundancy__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmTB_GENEROU2;
          prmTB_GENEROU2 = new Object[] {
          new ParDef("GenID",GXType.Int32,9,0)
          };
          Object[] prmTB_GENEROU3;
          prmTB_GENEROU3 = new Object[] {
          new ParDef("CpjConGenNome",GXType.VarChar,80,0) ,
          new ParDef("CpjConGenSigla",GXType.VarChar,20,0) ,
          new ParDef("GenID",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("TB_GENEROU2", "SELECT GenID, GenSigla, GenNome FROM tb_genero WHERE GenID = :GenID ORDER BY GenID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmTB_GENEROU2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("TB_GENEROU3", "UPDATE tb_clientepj_contato SET CpjConGenNome=:CpjConGenNome, CpjConGenSigla=:CpjConGenSigla  WHERE CpjConGenID = :GenID", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmTB_GENEROU3)
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
