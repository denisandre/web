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
   public class tbibge_regiaoloadredundancy : GXProcedure
   {
      public tbibge_regiaoloadredundancy( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", false);
      }

      public tbibge_regiaoloadredundancy( IGxContext context )
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
         tbibge_regiaoloadredundancy objtbibge_regiaoloadredundancy;
         objtbibge_regiaoloadredundancy = new tbibge_regiaoloadredundancy();
         objtbibge_regiaoloadredundancy.context.SetSubmitInitialConfig(context);
         objtbibge_regiaoloadredundancy.initialize();
         Submit( executePrivateCatch,objtbibge_regiaoloadredundancy);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((tbibge_regiaoloadredundancy)stateInfo).executePrivate();
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
         /* Optimized UPDATE. */
         cmdBuffer=" LOCK TABLE tbibge_regiao IN EXCLUSIVE MODE "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_MASKLOCKERR | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
         /* Using cursor TBIBGE_REG2 */
         pr_default.execute(0);
         pr_default.close(0);
         pr_default.SmartCacheProvider.SetUpdated("tbibge_regiao");
         /* End optimized UPDATE. */
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
         cmdBuffer = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tbibge_regiaoloadredundancy__default(),
            new Object[][] {
                new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private string cmdBuffer ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxCommand RGZ ;
      private IDataStoreProvider pr_default ;
   }

   public class tbibge_regiaoloadredundancy__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new UpdateCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmTBIBGE_REG2;
          prmTBIBGE_REG2 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("TBIBGE_REG2", "UPDATE tbibge_regiao SET RegiaoSiglaNome=RTRIM(LTRIM(RegiaoSigla)) || ' - ' || RTRIM(LTRIM(RegiaoNome)) ", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmTBIBGE_REG2)
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

 }

}
